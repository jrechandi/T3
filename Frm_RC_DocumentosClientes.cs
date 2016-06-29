using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using T3.CLASES;
using clslibraryconssa;
using System.Transactions;
using System.Data.SqlClient;
using T3.Cobranza;

namespace T3
{
    namespace Cobranza
    {
        #region Tipos

        /// <summary>Estados del formulario de documentos.</summary>
        public enum TiposEstadoRelacion
        {
            EstadoPagoNueva = 0,
            EstadoPagoEditando
        }

        #endregion
    }

    public partial class Frm_RC_DocumentosClientes : Form
    {
        #region Variables

        /// <summary>Código de la guía de despacho.</summary>
        private string _G_Str_GuiaDespacho;

        /// <summary>Código del cliente de la guía de despacho.</summary>
        private string _G_Str_Cliente;

        /// <summary></summary>
        private TiposEstadoRelacion _G_Enum_Estado;

        /// <summary>
        /// Indica si el cliente actual es casa matriz
        /// </summary>
        private bool _G_Bol_EsCasaMatriz = false;


        #endregion

        #region Métodos

        /// <summary>Contructor del formulario.</summary>
        /// <param name="_P_Str_Guia">Código de la guía de despacho.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        /// <param name="_P_Enum_Estado">Estado del formulario.</param>
        public Frm_RC_DocumentosClientes(string _P_Str_Guia, string _P_Str_Cliente, TiposEstadoRelacion _P_Enum_Estado)
        {
            _G_Str_GuiaDespacho = _P_Str_Guia;

            _G_Str_Cliente = _P_Str_Cliente;

            _G_Enum_Estado = _P_Enum_Estado;

            InitializeComponent();
        }

        /// <summary>Carga los documentos del cliente según la guía o la relación de cobranza.</summary>
        /// <param name="_P_Str_Guia">Código de la guía de despacho.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        /// <param name="_P_Bol_ActualizarSaldos">Bandera que indica que se deben actualizar los saldos, solo se va a llamar en el constructor</param>
        private void _Mtd_CargarDocumentos(string _P_Str_Guia, string _P_Str_Cliente, bool _P_Bol_ActualizarSaldos = false)
        {
            string _Str_SQL;

            /* 
             *  Aqui se hace lo siguiente:
             * 
             *      1. Se verifica si la guía tiene una relación de cobranza asignada, se toman los documentos de la misma, si la tiene.
             *      2. En caso contrario, se busca en el detalle de la guía los documentos y se genera un nuevo detalle.
             */

            //Insertamos siempre que no exista
            if (_G_Bol_EsCasaMatriz)
            {
                _Str_SQL = "insert into TTRCDOCUMENTO (ccompany, cguia, ccliente, cfactura, cmontodocumento,cmontodocumentosinimpuesto,cmontodocumentoimpuesto, cmontosaldo, cvendedor, cdelete, cdateadd, cuseradd, cmontonotacredito, cmontoretencion, cmontocobradocheque, cmontocobradoefectivo)";
                _Str_SQL += " select TGUIADESPACHOD.ccompany, TGUIADESPACHOD.cguiadesp, TFACTURAM.ccliente, TGUIADESPACHOD.cfactura, (TFACTURAM.c_montotot_si_bs + TFACTURAM.c_impuesto_bs) AS cmontototal,TFACTURAM.c_montotot_si_bs AS cmontodocumentosinimpuesto, TFACTURAM.c_impuesto_bs AS cmontodocumentoimpuesto, (TFACTURAM.c_montotot_si_bs + TFACTURAM.c_impuesto_bs) AS csaldo, TFACTURAM.cvendedor, 0, getdate(), '" + Frm_Padre._Str_Use + "', 0, 0, 0, 0 ";
                _Str_SQL += " FROM TGUIADESPACHOD INNER JOIN TFACTURAM ON TGUIADESPACHOD.cfactura = TFACTURAM.cfactura AND TGUIADESPACHOD.ccompany = TFACTURAM.ccompany AND TGUIADESPACHOD.cgroupcomp = TFACTURAM.cgroupcomp INNER JOIN TSALDOCLIENTED INNER JOIN TCONFIGCXC ON TSALDOCLIENTED.ctipodocument = TCONFIGCXC.ctipdocfact AND TSALDOCLIENTED.ccompany = TCONFIGCXC.ccompany ON TFACTURAM.cgroupcomp = TSALDOCLIENTED.cgroupcomp AND TFACTURAM.ccompany = TSALDOCLIENTED.ccompany AND TFACTURAM.cfactura = TSALDOCLIENTED.cnumdocu AND ROUND(TFACTURAM.c_montotot_si_bs + TFACTURAM.c_impuesto_bs, 2) = ROUND(TSALDOCLIENTED.csaldofactura, 2) AND TFACTURAM.ccliente = TSALDOCLIENTED.ccliente INNER JOIN TCLIENTE ON TFACTURAM.cgroupcomp = TCLIENTE.cgroupcomp AND TFACTURAM.ccliente = TCLIENTE.ccliente ";
                _Str_SQL += " where (TGUIADESPACHOD.cguiadesp=" + _P_Str_Guia + ") AND (TGUIADESPACHOD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "') AND (TGUIADESPACHOD.c_fact_anul = 0) AND ( (TGUIADESPACHOD.c_estatus='PAG' AND TGUIADESPACHOD.c_cancelaciontot='1') OR (TGUIADESPACHOD.c_estatus='PAG' AND TGUIADESPACHOD.c_cancelaciontot='0')) AND (ISNULL(TGUIADESPACHOD.csinretencion,0)=0) AND (ROUND(TSALDOCLIENTED.csaldofactura,2) =ROUND((TFACTURAM.c_montotot_si_bs + TFACTURAM.c_impuesto_bs),2)) AND ((TFACTURAM.ccliente='" + _P_Str_Cliente + "') OR (TCLIENTE.c_casa_matriz='" + _P_Str_Cliente + "')) AND (ISNULL(TCLIENTE.cdelete,0)=0) " + 
                            " AND NOT EXISTS (SELECT TTRCDOCUMENTO.cfactura FROM TTRCDOCUMENTO WHERE TTRCDOCUMENTO.ccompany = TGUIADESPACHOD.ccompany AND TTRCDOCUMENTO.cfactura = TFACTURAM.cfactura AND TTRCDOCUMENTO.cdelete = 0) ";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
            }
            else
            {
                _Str_SQL = "insert into TTRCDOCUMENTO (ccompany, cguia, ccliente, cfactura, cmontodocumento,cmontodocumentosinimpuesto,cmontodocumentoimpuesto, cmontosaldo, cvendedor, cdelete, cdateadd, cuseradd, cmontonotacredito, cmontoretencion, cmontocobradocheque, cmontocobradoefectivo)";
                _Str_SQL += " select TGUIADESPACHOD.ccompany, TGUIADESPACHOD.cguiadesp, TFACTURAM.ccliente, TGUIADESPACHOD.cfactura, (TFACTURAM.c_montotot_si_bs + TFACTURAM.c_impuesto_bs) AS cmontototal,TFACTURAM.c_montotot_si_bs AS cmontodocumentosinimpuesto, TFACTURAM.c_impuesto_bs AS cmontodocumentoimpuesto, (TFACTURAM.c_montotot_si_bs + TFACTURAM.c_impuesto_bs) AS csaldo, TFACTURAM.cvendedor, 0, getdate(), '" + Frm_Padre._Str_Use + "', 0, 0, 0, 0 ";
                _Str_SQL += " from TGUIADESPACHOD INNER JOIN TFACTURAM ON TGUIADESPACHOD.cfactura = TFACTURAM.cfactura AND TGUIADESPACHOD.ccompany = TFACTURAM.ccompany AND TGUIADESPACHOD.cgroupcomp = TFACTURAM.cgroupcomp INNER JOIN TSALDOCLIENTED INNER JOIN TCONFIGCXC ON TSALDOCLIENTED.ctipodocument = TCONFIGCXC.ctipdocfact AND TSALDOCLIENTED.ccompany = TCONFIGCXC.ccompany ON  TFACTURAM.cgroupcomp = TSALDOCLIENTED.cgroupcomp AND TFACTURAM.ccompany = TSALDOCLIENTED.ccompany AND TFACTURAM.cfactura = TSALDOCLIENTED.cnumdocu ";
                _Str_SQL += " where (TGUIADESPACHOD.cguiadesp=" + _P_Str_Guia + ") AND (TFACTURAM.ccliente=" + _P_Str_Cliente + ") AND (TGUIADESPACHOD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "') AND (TGUIADESPACHOD.c_fact_anul = 0) AND ( (TGUIADESPACHOD.c_estatus='PAG' AND TGUIADESPACHOD.c_cancelaciontot='1') OR (TGUIADESPACHOD.c_estatus='PAG' AND TGUIADESPACHOD.c_cancelaciontot='0')) AND (ISNULL(TGUIADESPACHOD.csinretencion,0)=0) AND (ROUND(TSALDOCLIENTED.csaldofactura,2) =ROUND((TFACTURAM.c_montotot_si_bs + TFACTURAM.c_impuesto_bs),2)) " +
                            " AND NOT EXISTS (SELECT TTRCDOCUMENTO.cfactura FROM TTRCDOCUMENTO WHERE TTRCDOCUMENTO.ccompany = TGUIADESPACHOD.ccompany AND TTRCDOCUMENTO.cfactura = TFACTURAM.cfactura AND TTRCDOCUMENTO.cdelete = 0) ";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
            }
            

            //Recalculamos lo saldos (para evitar loco de cero saldo al iniciar)
            if (_P_Bol_ActualizarSaldos)
            {
                //Cargamos los documentos a los cuales se les va a recalcular el saldo
                if (_G_Bol_EsCasaMatriz)
                {
                    _Str_SQL = "select ccompany,TTRCDOCUMENTO.ccliente, cfactura from TTRCDOCUMENTO INNER JOIN TCLIENTE ON TTRCDOCUMENTO.ccliente = TCLIENTE.ccliente ";
                    _Str_SQL += " where (TTRCDOCUMENTO.cguia=" + _P_Str_Guia + ") and  (TCLIENTE.cgroupcomp='" + Frm_Padre._Str_GroupComp + "') " +
                                " and ((TTRCDOCUMENTO.ccliente='" + _P_Str_Cliente + "') OR (TCLIENTE.c_casa_matriz ='" + _P_Str_Cliente + "'))";
                }
                else
                {
                    _Str_SQL = "select ccompany,ccliente, cfactura from TTRCDOCUMENTO";
                    _Str_SQL += " where ((cguia=" + _P_Str_Guia + ") and (ccliente=" + _P_Str_Cliente + "));";
                }
                var _Ds_Documentos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                foreach (DataRow _Row in _Ds_Documentos.Tables[0].Rows)
                {
                    _Mtd_ActualizarSaldo(_Row["ccompany"].ToString(), _P_Str_Guia, _Row["ccliente"].ToString(), _Row["cfactura"].ToString());
                }
            }

            //Espera loca anti-depre-saldo-cero .. un flechazo como dice roberto...
            Thread.Sleep(200);

            //Cargamos los documentos
            if (_G_Bol_EsCasaMatriz)
            {
                _Str_SQL = "select TTRCDOCUMENTO.ccompany, (CONVERT(VARCHAR,TCLIENTE.ccliente) + ' - ' + TCLIENTE.c_nomb_comer) AS cNombreCliente, cfactura, TTRCDOCUMENTO.cvendedor, (TVENDEDOR.cvendedor + ' - ' + TVENDEDOR.cname) as cname, cmontodocumento, cmontonotacredito, cmontoretencion, cmontocobradocheque, cmontocobradoefectivo, abs(cmontosaldo) as cmontosaldo, TCLIENTE.ccliente " +
                           " FROM TTRCDOCUMENTO INNER JOIN TVENDEDOR ON TTRCDOCUMENTO.cvendedor = TVENDEDOR.cvendedor AND TTRCDOCUMENTO.ccompany = TVENDEDOR.ccompany INNER JOIN TCLIENTE ON TTRCDOCUMENTO.ccliente = TCLIENTE.ccliente  " +
                           " where (cguia=" + _P_Str_Guia + ") AND ((TTRCDOCUMENTO.ccliente = '" + _P_Str_Cliente + "') OR ((TCLIENTE.c_casa_matriz ='" + _P_Str_Cliente + "') AND NOT EXISTS (SELECT TTRCPAGOM.ccliente FROM TTRCPAGOM WHERE CONVERT(VARCHAR,TTRCPAGOM.ccliente) = CONVERT(VARCHAR,TCLIENTE.ccliente)  AND TTRCPAGOM.ccompany = TTRCDOCUMENTO.ccompany AND TTRCPAGOM.cguia = TTRCDOCUMENTO.cguia))) AND (ISNULL(TCLIENTE.cdelete,0)=0) ";

            }
            else
            {
                _Str_SQL = "select TTRCDOCUMENTO.ccompany, (CONVERT(VARCHAR,TCLIENTE.ccliente) + ' - ' + TCLIENTE.c_nomb_comer) AS cNombreCliente, cfactura, TTRCDOCUMENTO.cvendedor, (TVENDEDOR.cvendedor + ' - ' + TVENDEDOR.cname) as cname, cmontodocumento, cmontonotacredito, cmontoretencion, cmontocobradocheque, cmontocobradoefectivo, abs(cmontosaldo) as cmontosaldo, TCLIENTE.ccliente " +
                           "FROM TTRCDOCUMENTO INNER JOIN TVENDEDOR ON TTRCDOCUMENTO.cvendedor = TVENDEDOR.cvendedor AND TTRCDOCUMENTO.ccompany = TVENDEDOR.ccompany INNER JOIN TCLIENTE ON TTRCDOCUMENTO.ccliente = TCLIENTE.ccliente  " +
                           " where ((TTRCDOCUMENTO.cguia=" + _P_Str_Guia + ") and (TTRCDOCUMENTO.ccliente=" + _P_Str_Cliente + "));";
            }
            var _Ds_Detalle = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            _Dtg_Documentos.DataSource = _Ds_Detalle.Tables[0].DefaultView;

            //Ocultamos la columna que no deberia
            if (_G_Bol_EsCasaMatriz)
            {
                var _Dg_Columna_colNombreCliente = _Dtg_Documentos.Columns["colNombreCliente"];
                if (_Dg_Columna_colNombreCliente != null)
                {
                    _Dg_Columna_colNombreCliente.Visible = true;
                    _Dg_Columna_colNombreCliente.Width = 135;
                }
                var _Dg_Columna_colFactura = _Dtg_Documentos.Columns["colFactura"];
                if (_Dg_Columna_colFactura != null) 
                {
                    _Dg_Columna_colFactura.Width = 70;
                }
                var _Dg_Columna_colCobrador = _Dtg_Documentos.Columns["colCobrador"];
                if (_Dg_Columna_colCobrador != null) 
                {
                    _Dg_Columna_colCobrador.Width = 115;
                }
            }
            else
            {
                var _Dg_Columna_colNombreCliente = _Dtg_Documentos.Columns["colNombreCliente"];
                if (_Dg_Columna_colNombreCliente != null)
                {
                    _Dg_Columna_colNombreCliente.Visible = false;
                    _Dg_Columna_colNombreCliente.Width = 135;
                }
                var _Dg_Columna_colFactura = _Dtg_Documentos.Columns["colFactura"];
                if (_Dg_Columna_colFactura != null)
                {
                    _Dg_Columna_colFactura.Width = 100;
                }
                var _Dg_Columna_colCobrador = _Dtg_Documentos.Columns["colCobrador"];
                if (_Dg_Columna_colCobrador != null)
                {
                    _Dg_Columna_colCobrador.Width = 220;
                }
            }

            var _Dbl_TotalCobros = (_Mtd_TotalCheques(_G_Str_GuiaDespacho, _G_Str_Cliente) + _Mtd_TotalDepositos(_G_Str_GuiaDespacho, _G_Str_Cliente));
            var _Dbl_TotalDocumentos = _Mtd_TotalDocumentos(_G_Str_GuiaDespacho, _G_Str_Cliente);

            var _Dbl_Sobrante = _Mtd_TotalSobrante(_G_Str_GuiaDespacho, _G_Str_Cliente);
            var _Dbl_Faltante = _Mtd_ObtenerSaldo(_G_Str_GuiaDespacho, _G_Str_Cliente);

            //Quitamos signos
            _Dbl_TotalCobros = Math.Abs(_Dbl_TotalCobros);
            _Dbl_TotalDocumentos = Math.Abs(_Dbl_TotalDocumentos);
            _Dbl_Sobrante = Math.Abs(_Dbl_Sobrante);
            _Dbl_Faltante = Math.Abs(_Dbl_Faltante);

            //Redondeamos
            _Dbl_TotalCobros = Math.Round(_Dbl_TotalCobros, 2);
            _Dbl_TotalDocumentos = Math.Round(_Dbl_TotalDocumentos, 2);
            _Dbl_Sobrante = Math.Round(_Dbl_Sobrante, 2);
            _Dbl_Faltante = Math.Round(_Dbl_Faltante, 2);


            //Cuando hayan cobros
            if (_Dbl_TotalCobros > 0)
            {
                if ((_Dbl_Faltante == 0))
                {
                    _Lbl_Faltante.Visible = false;
                    _Txt_Faltante.Visible = false;
                }
                else
                {
                    _Lbl_Faltante.Visible = true;
                    _Txt_Faltante.Visible = true;
                    _Txt_Faltante.Text = Math.Round(Math.Abs(_Dbl_Faltante), 2).ToString("c");
                }
                if ( (_Dbl_Sobrante == 0))
                {
                    _Lbl_Sobrante.Visible = false;
                    _Txt_Sobrante.Visible = false;
                }
                else
                {
                    _Lbl_Sobrante.Visible = true;
                    _Txt_Sobrante.Visible = true;
                    _Txt_Sobrante.Text = Math.Round(Math.Abs(_Dbl_Sobrante), 2).ToString("c");
                }
                
            }
            else 
            {
                _Lbl_Faltante.Visible = false;
                _Txt_Faltante.Visible = false;
                _Lbl_Sobrante.Visible = false;
                _Txt_Sobrante.Visible = false;
            }

            //Mostramos el total cobrado
            _Txt_TotalCobrado.Text = _Dbl_TotalCobros.ToString("c");
        }

        /// <summary>Este método permite obtener el saldo del cliente en la guía.</summary>
        /// <param name="_P_Str_Guia">Código de la guía de despacho.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>       
        /// <returns>Monto del saldo de los pagos.</returns>
        private double _Mtd_ObtenerSaldo(string _P_Str_Guia, string _P_Str_Cliente)
        {
            string _Str_SQL;
            double _Dbl_MontoTotalDocumento = 0;
            double _Dbl_MontoTotalNotaCredito = 0;
            double _Dbl_MontoTotalRetencion = 0;
            double _Dbl_MontoTotalCobradoCheque = 0;
            double _Dbl_MontoTotalCobradoEfectivo = 0;
            double _Dbl_Diferencia;

            //Totalizamos los documentos
            _Str_SQL = "SELECT SUM(cmontodocumento) AS MontoTotalDocumento,SUM(cmontonotacredito) AS MontoTotalNotaCredito,SUM(cmontoretencion) AS MontoTotalRetencion,SUM(cmontocobradocheque) AS MontoTotalCobradoCheque,SUM(cmontocobradoefectivo) AS MontoTotalCobradoEfectivo ";
            _Str_SQL += "FROM TTRCDOCUMENTO INNER JOIN TCLIENTE ON TTRCDOCUMENTO.ccliente = TCLIENTE.ccliente ";
            _Str_SQL += "WHERE ";
            _Str_SQL += " (ISNULL(TTRCDOCUMENTO.cdelete,0)=0) AND (ISNULL(TCLIENTE.cdelete,0)=0) ";
            _Str_SQL += " AND (cguia = '" + _P_Str_Guia + "') ";
            if (_G_Bol_EsCasaMatriz)
            {
                _Str_SQL += "  AND ( (TTRCDOCUMENTO.ccliente = '" + _P_Str_Cliente + "') OR ( (TCLIENTE.c_casa_matriz = '" + _P_Str_Cliente + "') AND ((TTRCDOCUMENTO.cmontocobradocheque > 0) OR (TTRCDOCUMENTO.cmontocobradoefectivo > 0)) AND NOT EXISTS (SELECT TTRCPAGOM.ccliente FROM TTRCPAGOM WHERE CONVERT(VARCHAR, TTRCPAGOM.ccliente) = CONVERT(VARCHAR, TCLIENTE.ccliente)  AND TTRCPAGOM.ccompany = TTRCDOCUMENTO.ccompany AND TTRCPAGOM.cguia = TTRCDOCUMENTO.cguia) ) )  ";
            }
            else
            {
                _Str_SQL += " AND (TTRCDOCUMENTO.ccliente=" + _P_Str_Cliente + ") ";
            }
            
            var dsResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (dsResultado.Tables[0].Rows.Count > 0)
            {
                double.TryParse(dsResultado.Tables[0].Rows[0]["MontoTotalDocumento"].ToString(), out _Dbl_MontoTotalDocumento);
                double.TryParse(dsResultado.Tables[0].Rows[0]["MontoTotalNotaCredito"].ToString(), out _Dbl_MontoTotalNotaCredito);
                double.TryParse(dsResultado.Tables[0].Rows[0]["MontoTotalRetencion"].ToString(), out _Dbl_MontoTotalRetencion);
                double.TryParse(dsResultado.Tables[0].Rows[0]["MontoTotalCobradoCheque"].ToString(), out _Dbl_MontoTotalCobradoCheque);
                double.TryParse(dsResultado.Tables[0].Rows[0]["MontoTotalCobradoEfectivo"].ToString(), out _Dbl_MontoTotalCobradoEfectivo);
            }

            //Calculo la diferencia
            _Dbl_Diferencia = (_Dbl_MontoTotalNotaCredito + _Dbl_MontoTotalRetencion + _Dbl_MontoTotalCobradoCheque + _Dbl_MontoTotalCobradoEfectivo) - _Dbl_MontoTotalDocumento;

            return _Dbl_Diferencia;
        }

        /// <summary>Este método permite obtener el saldo del cliente en la guía.</summary>
        /// <param name="_P_Str_Guia">Código de la guía de despacho.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>       
        /// <returns>Monto del saldo de los pagos.</returns>
        private double _Mtd_TotalDocumentos(string _P_Str_Guia, string _P_Str_Cliente)
        {
            string _Str_SQL;
            double _Dbl_MontoTotalDocumento = 0;
            double _Dbl_MontoTotalNotaCredito = 0;
            double _Dbl_MontoTotalRetencion = 0;
            double _Dbl_MontoTotalCobradoCheque = 0;
            double _Dbl_MontoTotalCobradoEfectivo = 0;
            double _Dbl_Diferencia;

            //Totalizamos los documentos
            _Str_SQL = "SELECT SUM(cmontodocumento) AS MontoTotalDocumento,SUM(cmontonotacredito) AS MontoTotalNotaCredito,SUM(cmontoretencion) AS MontoTotalRetencion,SUM(cmontocobradocheque) AS MontoTotalCobradoCheque,SUM(cmontocobradoefectivo) AS MontoTotalCobradoEfectivo ";
            _Str_SQL += "FROM TTRCDOCUMENTO INNER JOIN TCLIENTE ON TTRCDOCUMENTO.ccliente = TCLIENTE.ccliente ";
            _Str_SQL += "WHERE ";
            _Str_SQL += " (ISNULL(TTRCDOCUMENTO.cdelete,0)=0) AND (ISNULL(TCLIENTE.cdelete,0)=0) ";
            _Str_SQL += " AND (cguia = '" + _P_Str_Guia + "') ";
            if (_G_Bol_EsCasaMatriz)
            {
                _Str_SQL += " AND ((TTRCDOCUMENTO.ccliente=" + _P_Str_Cliente + ") OR (TCLIENTE.c_casa_matriz='" + _P_Str_Cliente + "'))";
            }
            else
            {
                _Str_SQL += " AND (TTRCDOCUMENTO.ccliente=" + _P_Str_Cliente + ") ";
            }

            var dsResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (dsResultado.Tables[0].Rows.Count > 0)
            {
                if (dsResultado.Tables[0].Rows[0]["MontoTotalDocumento"].ToString() != "")
                    _Dbl_MontoTotalDocumento = Convert.ToDouble(dsResultado.Tables[0].Rows[0]["MontoTotalDocumento"].ToString());
                if (dsResultado.Tables[0].Rows[0]["MontoTotalNotaCredito"].ToString() != "")
                    _Dbl_MontoTotalNotaCredito = Convert.ToDouble(dsResultado.Tables[0].Rows[0]["MontoTotalNotaCredito"].ToString());
                if (dsResultado.Tables[0].Rows[0]["MontoTotalRetencion"].ToString() != "")
                    _Dbl_MontoTotalRetencion = Convert.ToDouble(dsResultado.Tables[0].Rows[0]["MontoTotalRetencion"].ToString());
                if (dsResultado.Tables[0].Rows[0]["MontoTotalCobradoCheque"].ToString() != "")
                    _Dbl_MontoTotalCobradoCheque = Convert.ToDouble(dsResultado.Tables[0].Rows[0]["MontoTotalCobradoCheque"].ToString());
                if (dsResultado.Tables[0].Rows[0]["MontoTotalCobradoEfectivo"].ToString() != "")
                    _Dbl_MontoTotalCobradoEfectivo = Convert.ToDouble(dsResultado.Tables[0].Rows[0]["MontoTotalCobradoEfectivo"].ToString());
            }

            //Calculo la diferencia
            _Dbl_Diferencia = _Dbl_MontoTotalDocumento - (_Dbl_MontoTotalNotaCredito + _Dbl_MontoTotalRetencion);

            return _Dbl_Diferencia;
        }

        /// <summary>Este método permite obtener el saldo del cliente en la guía.</summary>
        /// <param name="_P_Str_Guia">Código de la guía de despacho.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>       
        /// <returns>Monto del saldo de los pagos.</returns>
        private double _Mtd_TotalSobrante(string _P_Str_Guia, string _P_Str_Cliente)
        {
            string _Str_SQL;
            double _Dbl_MontoTotalSaldo = 0;
            double _Dbl_MontoTotalPago = 0;
            double _Dbl_Sobrante = 0;

            //obtenemos todos los pagos 
            _Str_SQL = "SELECT TTRCPAGOM.cidpago " +
                       "FROM TTRCPAGOM " + 
                       "WHERE (cguia = '" + _P_Str_Guia + "') AND (ccliente = '" + _P_Str_Cliente + "') AND (ISNULL(cdelete,0)=0)";
            var dsResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (dsResultado.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _RowPagos in dsResultado.Tables[0].Rows)
                {
                    var _Str_cidpago = _RowPagos["cidpago"].ToString();

                    //Consutamos el detalle del pago
                    _Str_SQL =
                        "SELECT SUM(TTRCDOCUMENTO.cmontodocumento) AS SumaTotalDocumentos, SUM(TTRCDOCUMENTO.cmontodocumentosinimpuesto) AS SumaTotalBase, SUM(TTRCDOCUMENTO.cmontodocumentoimpuesto) AS SumaTotalImpuesto, SUM(TTRCDOCUMENTO.cmontonotacredito) AS SumaTotalNotasCredito, SUM(TTRCDOCUMENTO.cmontoretencion) AS SumaTotalRetenciones, SUM(TTRCPAGOD.cmontoabono) AS SumaTotalCobrado, SUM(TTRCDOCUMENTO.cmontosaldo) AS SumaTotalSaldo, TTRCPAGOM.cmontototal AS SumaTotalPago " +
                        "FROM TTRCPAGOD INNER JOIN TTRCPAGOM ON TTRCPAGOD.cidpago = TTRCPAGOM.cidpago INNER JOIN TTRCDOCUMENTO ON TTRCPAGOD.cfactura = TTRCDOCUMENTO.cfactura AND TTRCPAGOM.ccompany = TTRCDOCUMENTO.ccompany AND TTRCPAGOM.cguia = TTRCDOCUMENTO.cguia " +
                        "WHERE (TTRCPAGOM.cdelete = 0) AND (TTRCDOCUMENTO.cdelete = 0) AND (TTRCPAGOD.cdelete = 0) AND (TTRCPAGOM.cidpago = '" + _Str_cidpago + "') " + 
                        "GROUP BY TTRCPAGOM.cidpago, TTRCPAGOM.cmontototal";
                    var dsDetalle = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                    if (dsDetalle.Tables[0].Rows.Count > 0)
                    {
                        _Dbl_MontoTotalSaldo += Convert.ToDouble(dsDetalle.Tables[0].Rows[0]["SumaTotalCobrado"]);
                        _Dbl_MontoTotalPago += Convert.ToDouble(dsDetalle.Tables[0].Rows[0]["SumaTotalPago"])  ;
                    }
                }
            }

            //Calculo 
            _Dbl_Sobrante = _Dbl_MontoTotalPago - _Dbl_MontoTotalSaldo;

            //Redondeo
            _Dbl_Sobrante = Math.Round(_Dbl_Sobrante, 2);

            //
            var _Dbl_Resultado = _Dbl_Sobrante < 0 ? 0 : _Dbl_Sobrante;

            return _Dbl_Resultado;
        }


        /// <summary>Este método permite obtener el total de los cheques del cliente en la guía.</summary>
        /// <param name="_P_Str_Guia">Código de la guía de despacho.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        /// <returns>Monto del total de cheques de los pagos.</returns>
        private double _Mtd_TotalCheques(string _P_Str_Guia, string _P_Str_Cliente)
        {
            string _Str_SQL;
            double _Dbl_Total = 0;

            _Str_SQL = "select isnull(sum(cmontototal), 0) as cmontototal from TTRCPAGOM ";
            _Str_SQL += " where ((cguia=" + _P_Str_Guia + ") and (ccliente='" + _P_Str_Cliente + "') and (ctipodoc='C'));";

            DataSet dsResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsResultado.Tables[0].Rows.Count > 0)
            {
                _Dbl_Total = Convert.ToDouble(dsResultado.Tables[0].Rows[0]["cmontototal"].ToString());
            }

            return _Dbl_Total;
        }

        /// <summary>Este método permite obtener el total de los depositos del cliente en la guía.</summary>
        /// <param name="_P_Str_Guia">Código de la guía de despacho.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        /// <returns>Monto del total de depósitos de los pagos.</returns>
        private double _Mtd_TotalDepositos(string _P_Str_Guia, string _P_Str_Cliente)
        {
            string _Str_SQL;
            double _Dbl_Total = 0;

            _Str_SQL = "select isnull(sum(cmontototal), 0) as cmontototal from TTRCPAGOM ";
            _Str_SQL += " where ((cguia=" + _P_Str_Guia + ") and (ccliente='" + _P_Str_Cliente + "') and (ctipodoc='D'));";

            DataSet dsResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsResultado.Tables[0].Rows.Count > 0)
            {
                _Dbl_Total = Convert.ToDouble(dsResultado.Tables[0].Rows[0]["cmontototal"].ToString());
            }

            return _Dbl_Total;
        }

        /// <summary>Obtiene el nombre del cliente de la guía de despacho.</summary>
        /// <param name="_P_Str_Cliente">Código del cliente</param>
        private void _Mtd_MostrarCliente(string _P_Str_Cliente)
        {
            var _Ds_Resultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select c_nomb_comer, c_clasifica from TCLIENTE where (ccliente=" + _P_Str_Cliente + ");");

            Text = Text.Replace("Documentos", _P_Str_Cliente);
            Text = Text.Replace("[Nombre]", _Ds_Resultado.Tables[0].Rows[0]["c_nomb_comer"].ToString());

            var _Str_TipoCliente = "";
            _Str_TipoCliente = _Mtd_ClienteEsContribuyenteEspecial(_P_Str_Cliente) ? " - CONTRIBUYENTE ESPECIAL" : " - CONTRIBUYENTE REGULAR";

            var _Str_CasaMatriz = "";
            _G_Bol_EsCasaMatriz = _Ds_Resultado.Tables[0].Rows[0]["c_clasifica"].ToString() == "C";
            _Str_CasaMatriz = _G_Bol_EsCasaMatriz ? " - (CASA MATRIZ)" : "";

            //Mostramos
            Text = Text + _Str_TipoCliente + _Str_CasaMatriz;
        }


        /// <summary>Este método permite verificar si el cliente retiene impuesto.</summary>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        /// <returns>Verdadero si es un cliente que retiene impuesto.</returns>
        private bool _Mtd_ClienteEsContribuyenteEspecial(string _P_Str_Cliente)
        {
            string _Str_SQL;
            bool _Bol_Validar = false;

            _Str_SQL = "select cretieneimp from TCLIENTE inner join TCONTRIBUYENTE on TCLIENTE.c_tip_contribuy = TCONTRIBUYENTE.CCONTRIBUYENTE";
            _Str_SQL += " where (tcliente.CCLIENTE='" + _P_Str_Cliente + "');";

            DataSet dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsResultados.Tables[0].Rows.Count > 0)
            {
                _Bol_Validar = ((dsResultados.Tables[0].Rows[0]["cretieneimp"].ToString() == "1") ? true : false);
            }

            return _Bol_Validar;
        }

        /// <summary>Este método permite los saldos del cliente de la guía.</summary>
        /// <param name="_P_Str_Compañia">Código de la compañia.</param>
        /// <param name="_P_Str_Guia">Código de la guía.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        /// <param name="_P_Str_Factura">Número de factura.</param>
        public static void _Mtd_ActualizarSaldo(string _P_Str_Compañia, string _P_Str_Guia, string _P_Str_Cliente, string _P_Str_Factura)
        {
            string _Str_SQL;

            _Str_SQL = "select isnull(sum(TTRCNOTACREDD.cmonto), 0) as cmonto from TTRCNOTACREDD inner join TTRCPAGOM on TTRCNOTACREDD.cidpago = TTRCPAGOM.cidpago";
            _Str_SQL += " where ((TTRCPAGOM.ccompany='" + _P_Str_Compañia + "') and (TTRCPAGOM.cguia=" + _P_Str_Guia + ") and (cfactura=" + _P_Str_Factura + "));";

            DataSet dsNotas = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsNotas.Tables[0].Rows.Count > 0)
            {
                _Str_SQL = "update TTRCDOCUMENTO set cmontonotacredito = " + dsNotas.Tables[0].Rows[0]["cmonto"].ToString().Replace(",", ".");
                _Str_SQL += " where ((cguia=" + _P_Str_Guia + ") and (ccliente=" + _P_Str_Cliente + ") and (cfactura=" + _P_Str_Factura + "));";

                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
            }

            _Str_SQL = "select isnull(sum(TTRCRETENCION.cmonto), 0) as cmonto from TTRCRETENCION inner join TTRCPAGOD on TTRCRETENCION.cidpago = TTRCPAGOD.cidpago and TTRCRETENCION.cfactura = TTRCPAGOD.cfactura inner join TTRCPAGOM on TTRCPAGOD.cidpago = TTRCPAGOM.cidpago";
            _Str_SQL += " where ((TTRCPAGOM.ccompany='" + _P_Str_Compañia + "') and (TTRCPAGOM.cguia=" + _P_Str_Guia + ") and (TTRCRETENCION.cfactura=" + _P_Str_Factura + "));";

            DataSet dsRetenciones = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsRetenciones.Tables[0].Rows.Count > 0)
            {
                _Str_SQL = "update TTRCDOCUMENTO set cmontoretencion=" + dsRetenciones.Tables[0].Rows[0]["cmonto"].ToString().Replace(",", ".");
                _Str_SQL += " where ((cguia=" + _P_Str_Guia + ") and (ccliente=" + _P_Str_Cliente + ") and (cfactura=" + _P_Str_Factura + "));";

                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
            }

            _Str_SQL = "select isnull(sum(TTRCPAGOD.cmontoabono), 0) as cmontoabono from TTRCPAGOD inner join TTRCPAGOM on TTRCPAGOD.cidpago = TTRCPAGOM.cidpago";
            _Str_SQL += " where ((TTRCPAGOM.ccompany='" + _P_Str_Compañia + "') and (TTRCPAGOD.cfactura=" + _P_Str_Factura + ") and (TTRCPAGOM.ctipodoc='C') and (TTRCPAGOM.cguia=" + _P_Str_Guia + "));";
            
            DataSet dsCheques = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsCheques.Tables[0].Rows.Count > 0)
            {
                _Str_SQL = "update TTRCDOCUMENTO set cmontocobradocheque = " + dsCheques.Tables[0].Rows[0]["cmontoabono"].ToString().Replace(",", ".");
                _Str_SQL += " where ((cguia=" + _P_Str_Guia + ") and (ccliente=" + _P_Str_Cliente + ") and (cfactura=" + _P_Str_Factura + "));";

                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
            }

            _Str_SQL = "select isnull(sum(TTRCPAGOD.cmontoabono), 0) as cmontoabono from TTRCPAGOD inner join TTRCPAGOM on TTRCPAGOD.cidpago = TTRCPAGOM.cidpago";
            _Str_SQL += " where ((TTRCPAGOM.ccompany='" + _P_Str_Compañia + "') and (TTRCPAGOD.cfactura=" + _P_Str_Factura + ") and (TTRCPAGOM.ctipodoc='D') and (TTRCPAGOM.cguia=" + _P_Str_Guia + "));";

            DataSet dsDepositos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsDepositos.Tables[0].Rows.Count > 0)
            {
                _Str_SQL = "update TTRCDOCUMENTO set cmontocobradoefectivo = " + dsDepositos.Tables[0].Rows[0]["cmontoabono"].ToString().Replace(",", ".");
                _Str_SQL += " where ((cguia=" + _P_Str_Guia + ") and (ccliente=" + _P_Str_Cliente + ") and (cfactura=" + _P_Str_Factura + "));";

                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
            }

            _Str_SQL = "update TTRCDOCUMENTO set cmontosaldo = (cmontodocumento - (cmontonotacredito + cmontoretencion + cmontocobradocheque + cmontocobradoefectivo)), cdateupd=getdate(), cuserupd='" + Frm_Padre._Str_Use + "'";
            _Str_SQL += " where (ccompany='" + _P_Str_Compañia + "') and (cguia=" + _P_Str_Guia + ") and (cfactura=" + _P_Str_Factura + ") ";

            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

            _Str_SQL = "select cmontodocumento, cmontocobradocheque, cmontocobradoefectivo, cmontosaldo, ccancelada from TTRCDOCUMENTO where ((ccompany='" + _P_Str_Compañia + "') and (cguia=" + _P_Str_Guia + ") and (ccliente=" + _P_Str_Cliente + ") and (cfactura=" + _P_Str_Factura + "));";

            DataSet dsSaldos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsSaldos.Tables[0].Rows.Count > 0)
            {
                var _Bol_Cancelada = Convert.ToInt32(dsSaldos.Tables[0].Rows[0]["ccancelada"].ToString());
                var _Dbl_MontoSaldo = Convert.ToDouble(dsSaldos.Tables[0].Rows[0]["cmontosaldo"].ToString());                

                if (_Dbl_MontoSaldo == 0)
                {
                    _Str_SQL = "update TTRCDOCUMENTO set ccancelada=1 where ((ccompany='" + _P_Str_Compañia + "') and (cguia=" + _P_Str_Guia + ") and (ccliente=" + _P_Str_Cliente + ") and (cfactura=" + _P_Str_Factura + "));";
                }
                else
                {
                    _Str_SQL = "update TTRCDOCUMENTO set ccancelada=0 where ((ccompany='" + _P_Str_Compañia + "') and (cguia=" + _P_Str_Guia + ") and (ccliente=" + _P_Str_Cliente + ") and (cfactura=" + _P_Str_Factura + "));";
                }
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
            }
        }

        /// <summary>Este método crea el encabezado de la relación de cobranza.</summary>
        /// <param name="_P_Str_Grupo">Código del grupo de compañía.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        /// <param name="_P_Str_Guia">Código de la guía.</param>
        private void _Mtd_GuardarRelacion(string _P_Str_Grupo, string _P_Str_Cliente, string _P_Str_Guia)
        {
            string _Str_SQL;
            string _Str_IdRelacion = "";

            DataSet dsEmpresas = _Mtd_ObtenerEmpresasGuia(_P_Str_Guia);

            foreach (DataRow oEmpresa in dsEmpresas.Tables[0].Rows)
            {
                if (_Mtd_TienePagoCompañia(oEmpresa["ccompany"].ToString(), _P_Str_Cliente, _P_Str_Guia))
                {
                    DataSet dsUsuario = _Mtd_ObtenerUsuario(oEmpresa["ccompany"].ToString());

                    if (dsUsuario.Tables[0].Rows.Count > 0)
                    {
                        //Buscamos si ya alguno de los documentos tiene un cidrelacion guardada
                        _Str_SQL = "select distinct cidrelacion from TTRCDOCUMENTO where ((cguia=" + _P_Str_Guia + ") and (ccompany='" + oEmpresa["ccompany"].ToString() + "') and (cidrelacion is not null));";
                        DataSet dsRelaciones = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                        if (dsRelaciones.Tables[0].Rows.Count == 0) //Si no existe
                        {
                            //Buscamos si existe una relación para la compañia y al guia  (esto ocurre cuando hay un error en el documento)
                            _Str_SQL = "select cidrelacobro from TRELACCOBM where (cgroupcomp=" + Frm_Padre._Str_GroupComp + ") AND (ccompany='" + oEmpresa["ccompany"].ToString() + "') AND (cguiacobro = '" + _P_Str_Guia + "')";
                            var _Ds_Relacion = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                            if (_Ds_Relacion.Tables[0].Rows.Count > 0)
                            {
                                //Editamos
                                _Str_IdRelacion = _Ds_Relacion.Tables[0].Rows[0]["cidrelacobro"].ToString();
                                _Str_SQL = "update TRELACCOBM set cdateupd=getdate(), cuserupd='" + Frm_Padre._Str_Use + "' where ((cidrelacobro=" + _Str_IdRelacion + ") and (ccompany='" + oEmpresa["ccompany"].ToString() + "'));";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                            }
                            else
                            {
                                //Insertamos
                                _Str_SQL = "select (isnull(max(cidrelacobro), 0) + 1) as cidrelacobro from TRELACCOBM where (cgroupcomp=" + Frm_Padre._Str_GroupComp + ");";
                                DataSet dsMaximo = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                                if (dsMaximo.Tables[0].Rows.Count > 0)
                                {
                                    _Str_IdRelacion = dsMaximo.Tables[0].Rows[0]["cidrelacobro"].ToString();
                                    _Str_SQL = "insert into TRELACCOBM (cgroupcomp, ccompany, cvendedor, ctipocobro, cidrelacobro, cfecharela, cgerarea, cguiacobro, cdateadd, cuseradd, cdelete, ccobrooficina, caprobado, caprobadocredito, crelalista)";
                                    _Str_SQL += " values (" + _P_Str_Grupo + ", '" + oEmpresa["ccompany"].ToString() + "', '" + dsUsuario.Tables[0].Rows[0]["cvendedor"].ToString() + "', 1, " + _Str_IdRelacion + ", '" + new _Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "', '" + dsUsuario.Tables[0].Rows[0]["cgerarea"].ToString().Trim() + "', " + _P_Str_Guia + ", getdate(), '" + Frm_Padre._Str_Use + "', 0, 1, 1, 0, 1);";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                                }
                            }
                        }
                        else
                        {
                            _Str_IdRelacion = dsRelaciones.Tables[0].Rows[0]["cidrelacion"].ToString();
                        }

                        _Mtd_GuardarDocumentos(oEmpresa["ccompany"].ToString(), _P_Str_Grupo, _P_Str_Guia, _G_Str_Cliente, _Str_IdRelacion);

                        if (dsRelaciones.Tables[0].Rows.Count > 0)
                        {
                            if (dsRelaciones.Tables[0].Rows[0]["cidrelacion"].ToString() != "")
                            {
                                _Str_SQL = "update TRELACCOBM set cdateupd=getdate(), cuserupd='" + Frm_Padre._Str_Use + "' where ((cidrelacobro=" + _Str_IdRelacion + ") and (ccompany='" + oEmpresa["ccompany"].ToString() + "'));";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                            }
                        }
                    }
                }
            }
        }

        private bool _Mtd_ExisteDocumentoEnPagosTemporales(string _P_Str_Compañia, string _P_Str_cfactura)
        {
            var _Str_SQL = "SELECT TTRCPAGOD.cfactura FROM TTRCPAGOM INNER JOIN TTRCPAGOD ON TTRCPAGOM.cidpago = TTRCPAGOD.cidpago WHERE (TTRCPAGOM.cdelete = 0) AND (TTRCPAGOD.cdelete = 0) AND (TTRCPAGOM.ccompany='" + _P_Str_Compañia + "') AND (TTRCPAGOD.cfactura = '" + _P_Str_cfactura + "')";
            var _Ds_Resultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            return _Ds_Resultados.Tables[0].Rows.Count > 0;
        }


        /// <summary>Este método guardar los documentos tocados por los pagos en la tabla TRELACCOBD de la relación de cobranza.</summary>
        /// <param name="_P_Str_Compañia">Código de la compañía.</param>
        /// <param name="_P_Str_Grupo">Código del grupo de compañía.</param>
        /// <param name="_P_Str_Guia">Código de la guía.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        /// <param name="_P_Str_Relacion">Código de la relación.</param>
        private void _Mtd_GuardarDocumentos(string _P_Str_Compañia, string _P_Str_Grupo, string _P_Str_Guia, string _P_Str_Cliente, string _P_Str_Relacion)
        {
            string _Str_SQL;
            string _Str_IdDetalle;
            double _Dbl_TotalCancelado = 0;
            double _Dbl_TotalCanceladoPorNc = 0;

            foreach (DataGridViewRow _Dr_Documento in _Dtg_Documentos.Rows)
            {
                if (_Dr_Documento.Cells["colCompañia"].Value.ToString() == _P_Str_Compañia)
                {
                    _Dbl_TotalCancelado = (Convert.ToDouble(_Dr_Documento.Cells["colCobradoCheque"].Value.ToString()) + Convert.ToDouble(_Dr_Documento.Cells["colCobradoEfectivo"].Value.ToString()));
                    _Dbl_TotalCanceladoPorNc = (Convert.ToDouble(_Dr_Documento.Cells["colNotaCredito"].Value.ToString()));

                    //Redondeamos
                    _Dbl_TotalCancelado = Math.Round(_Dbl_TotalCancelado, 2);
                    _Dbl_TotalCanceladoPorNc = Math.Round(_Dbl_TotalCanceladoPorNc, 2);

                    //Verificamos si existe en algun pago de las tablas temporales
                    var _Str_cfactura = _Dr_Documento.Cells["colFactura"].Value.ToString().Trim();
                    var _Str_cclientedocumento = _Dr_Documento.Cells["colCliente"].Value.ToString();
                    if (_Mtd_ExisteDocumentoEnPagosTemporales(_P_Str_Compañia,_Str_cfactura))
                    {
                        //solo si tiene algun pago o si tiene NC, es que se procesa el documento
                        if ((Math.Round(_Dbl_TotalCancelado, 2) > 0) || (Math.Round(_Dbl_TotalCanceladoPorNc, 2) > 0))
                        {
                            //Consultamos a ver si el documento ya esta posteado en la relacion (es decir ya tiene un pago anterior)
                            _Str_SQL = "select ciddrelacobro from TRELACCOBD where (cnumdocu=" + _Dr_Documento.Cells["colFactura"].Value.ToString() + ") and (cidrelacobro=" + _P_Str_Relacion + ") and (ccompany='" + _P_Str_Compañia.Trim() + "')";
                            DataSet _Ds_TRELACCOBD = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                            if (_Ds_TRELACCOBD.Tables[0].Rows.Count == 0) //Si no existe
                            {
                                _Str_SQL = "select (isnull(max(ciddrelacobro), 0) + 1) as ciddrelacobro from TRELACCOBD where ((cgroupcompany=" + _P_Str_Grupo + ") and (cidrelacobro=" + _P_Str_Relacion + ") and (cdelete=0));";

                                DataSet dsDetalle = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                                if (dsDetalle.Tables[0].Rows.Count > 0)
                                {
                                    _Str_IdDetalle = dsDetalle.Tables[0].Rows[0]["ciddrelacobro"].ToString();

                                    _Str_SQL = "select ccancelada from TTRCDOCUMENTO where ((ccompany='" + _P_Str_Compañia + "') and (cguia=" + _P_Str_Guia + ") and (cfactura=" + _Dr_Documento.Cells["colFactura"].Value.ToString() + "));";

                                    DataSet oDocumentos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                                    if (oDocumentos.Tables[0].Rows.Count > 0)
                                    {
                                        var _Str_ccancelada = oDocumentos.Tables[0].Rows[0]["ccancelada"].ToString();

                                        if (_Dbl_TotalCancelado > 0) //Si fue cancelado por el pago
                                        {
                                            _Str_SQL = "insert into TRELACCOBD (cgroupcompany, ccompany, cidrelacobro, ccliente, ciddrelacobro, ctipodocument, cnumdocu, cmontocancel, cdateadd, cuseradd, cdelete, ccanctotal, ccancabono)";
                                            _Str_SQL += " values (" + _P_Str_Grupo + ", '" + _P_Str_Compañia + "', '" + _P_Str_Relacion + "', '" + _Str_cclientedocumento + "', " + _Str_IdDetalle + ", 'FACT', " + _Str_cfactura + ", " + _Dbl_TotalCancelado.ToString().Replace(",", ".") + ", getdate(), '" + Frm_Padre._Str_Use + "', 0, " + ((_Str_ccancelada == "1") ? "1, 0" : "0, 1") + ");";
                                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                                        }
                                        else if ((_Dbl_TotalCanceladoPorNc > 0) & (_Dbl_TotalCancelado == 0)) //Si fue cancelado por NC y no por el pago
                                        {
                                            _Str_SQL = "insert into TRELACCOBD (cgroupcompany, ccompany, cidrelacobro, ccliente, ciddrelacobro, ctipodocument, cnumdocu, cmontocancel, cdateadd, cuseradd, cdelete, ccanctotal, ccancabono)";
                                            _Str_SQL += " values (" + _P_Str_Grupo + ", '" + _P_Str_Compañia + "', '" + _P_Str_Relacion + "', '" + _Str_cclientedocumento + "', " + _Str_IdDetalle + ", 'FACT', " + _Str_cfactura + ", " + _Dbl_TotalCancelado.ToString().Replace(",", ".") + ", getdate(), '" + Frm_Padre._Str_Use + "', 0, " + ((_Str_ccancelada == "1") ? "1, 0" : "0, 1") + ");";
                                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                                        }

                                        _Str_SQL = "update TTRCDOCUMENTO set cidrelacion=" + _P_Str_Relacion;
                                        _Str_SQL += " where ((ccompany='" + _P_Str_Compañia + "') and (cguia=" + _P_Str_Guia + ") and (ccliente=" + _Str_cclientedocumento + ") and (cfactura=" + _Str_cfactura + "));";
                                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                                        _Mtd_GuardarNotasCredito(_P_Str_Compañia, _P_Str_Guia, _Str_cclientedocumento, _P_Str_Relacion, _Str_cfactura);

                                        _Mtd_GuardarRetenciones(_P_Str_Compañia, _P_Str_Guia, _Str_cclientedocumento, _P_Str_Relacion, _Str_cfactura);
                                    
                                    }

                                }
                            }
                            else //Si existe
                            {
                                _Str_SQL = "select ccancelada from TTRCDOCUMENTO where ((ccompany='" + _P_Str_Compañia + "') and (cguia=" + _P_Str_Guia + ") and (ccliente=" + _Str_cclientedocumento + ") and (cfactura=" + _Str_cfactura + "));";

                                DataSet oDocumentos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                                _Str_SQL = "update TRELACCOBD set " + ((oDocumentos.Tables[0].Rows[0]["ccancelada"].ToString() == "1") ? "ccanctotal=1, ccancabono=0" : "ccanctotal=0, ccancabono=1") + ", cmontocancel=" + _Dbl_TotalCancelado.ToString().Replace(",", ".") + ", cdateupd=getdate(), cuserupd='" + Frm_Padre._Str_Use + "'";
                                _Str_SQL += " where ((cgroupcompany=" + _P_Str_Grupo + ") and (ccompany='" + _P_Str_Compañia + "') and (cidrelacobro='" + _P_Str_Relacion + "') and (ccliente=" + _Str_cclientedocumento + ") and (ctipodocument='FACT') and (cnumdocu=" + _Str_cfactura + "));";

                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                                _Mtd_GuardarNotasCredito(_P_Str_Compañia, _P_Str_Guia, _Str_cclientedocumento, _P_Str_Relacion, _Dr_Documento.Cells["colFactura"].Value.ToString().Trim());

                                _Mtd_GuardarRetenciones(_P_Str_Compañia, _P_Str_Guia, _Str_cclientedocumento, _P_Str_Relacion, _Dr_Documento.Cells["colFactura"].Value.ToString().Trim());

                            }
                        }
                    }
                }                
            }

            _Mtd_GuardarCheques(_P_Str_Grupo, _P_Str_Compañia, _P_Str_Guia, _P_Str_Cliente, _P_Str_Relacion);

            _Mtd_GuardarDepositos(_P_Str_Grupo, _P_Str_Compañia, _P_Str_Guia, _P_Str_Cliente, _P_Str_Relacion);
        }

        /// <summary>Este método guarda los cheques de la relación en la tabla TRELACCOBDCHEQ y TRELACCOBDD.</summary>
        /// <param name="_P_Str_Grupo">Código del grupo de compañia.</param>
        /// <param name="_P_Str_Compañia">Código de la compañía.</param>
        /// <param name="_P_Str_Guia">Número de la guía.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        /// <param name="_P_Str_Relacion">Número de la relación de cobranza.</param>
        private void _Mtd_GuardarCheques(string _P_Str_Grupo, string _P_Str_Compañia, string _P_Str_Guia, string _P_Str_Cliente, string _P_Str_Relacion)
        {
            string _Str_SQL;
            string _Str_IdDetalle;
            string _Str_DiasTransito;

            _Str_SQL = "select cnumerodoc, cbanco, cfechaemision, cfechadeposito, cmontototal from TTRCPAGOM";
            _Str_SQL += " where ((ccompany='" + _P_Str_Compañia + "') and (cguia=" + _P_Str_Guia + ") and (ccliente='" + _P_Str_Cliente + "') and (ctipodoc='C'));";

            DataSet dsResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsResultado.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow oFila in dsResultado.Tables[0].Rows)
                {
                    _Str_SQL = "select ciddrelacobro_cheq from TRELACCOBDCHEQ";
                    _Str_SQL += " where (cgroupcomp=" + _P_Str_Grupo + ") and (ccompany='" + _P_Str_Compañia + "')  and (cidrelacobro = '" + _P_Str_Relacion + "') and (ccliente=" + _P_Str_Cliente + ") and (cbancocheque=" + oFila["cbanco"].ToString() + ") " +
                                "and (cnumcheque = '" + oFila["cnumerodoc"].ToString() + "') ";

                    DataSet dsCheques = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                    if (dsCheques.Tables[0].Rows.Count == 0)
                    {
                        _Str_SQL = "select (isnull(max(ciddrelacobro_cheq), 0) + 1) as ciddrelacobro_cheq from TRELACCOBDCHEQ";
                        _Str_SQL += " where ((cgroupcomp=" + _P_Str_Grupo + ") and (ccompany='" + _P_Str_Compañia + "') and (cidrelacobro='" + _P_Str_Relacion + "') and (cdelete=0));";

                        DataSet dsDetalle = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                        if (dsDetalle.Tables[0].Rows.Count > 0)
                        {
                            _Str_IdDetalle = dsDetalle.Tables[0].Rows[0]["ciddrelacobro_cheq"].ToString();

                            _Str_DiasTransito = (Convert.ToDateTime(oFila["cfechaemision"].ToString()) == Convert.ToDateTime(oFila["cfechadeposito"].ToString()) ? "D" : "T");

                            _Str_SQL = "insert into TRELACCOBDCHEQ (cgroupcomp, ccompany, cidrelacobro, ciddrelacobro_cheq, cnumcheque, cbancocheque, ccliente, cfeahcaemision, cmontocheq, ccheqdiatransito, cfechaadeposit, cegresotransito, cdateadd, cuseradd, cdelete)";
                            _Str_SQL += " values (" + _P_Str_Grupo + ", '" + _P_Str_Compañia + "', '" + _P_Str_Relacion + "', " + _Str_IdDetalle + ", '" + oFila["cnumerodoc"].ToString() + "', '" + oFila["cbanco"].ToString() + "', " + _P_Str_Cliente + ", convert(datetime, '" + Convert.ToDateTime(oFila["cfechaemision"].ToString()).ToShortDateString() + "', 103), " + oFila["cmontototal"].ToString().Replace(",", ".") + ", '" + _Str_DiasTransito + "', convert(datetime, '" + Convert.ToDateTime(oFila["cfechadeposito"].ToString()).ToShortDateString() + "', 103), 0, getdate(), '" + Frm_Padre._Str_Use + "', 0);";

                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                        }
                    }
                    else
                    {
                        _Str_SQL = "update TRELACCOBDCHEQ set cmontocheq=" + oFila["cmontototal"].ToString().Replace(",", ".") + ", cfeahcaemision=convert(datetime, '" + Convert.ToDateTime(oFila["cfechaemision"].ToString()).ToShortDateString() + "', 103), cfechaadeposit=convert(datetime, '" + Convert.ToDateTime(oFila["cfechadeposito"].ToString()).ToShortDateString() + "', 103)";
                        _Str_SQL += " where ((cgroupcomp=" + _P_Str_Grupo + ") and (ccompany='" + _P_Str_Compañia + "') and (ccliente=" + _P_Str_Cliente + ") and (cbancocheque=" + oFila["cbanco"].ToString() + ") and (cnumcheque = '" + oFila["cnumerodoc"].ToString() + "') and (cidrelacobro=" + _P_Str_Relacion + ") and (ciddrelacobro_cheq=" + dsCheques.Tables[0].Rows[0]["ciddrelacobro_cheq"].ToString() + "));";

                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                    }
                }

                _Str_SQL = " SELECT DISTINCT TRELACCOBDCHEQ.ciddrelacobro_cheq, TTRCPAGOD.cfactura, TTRCPAGOD.cmontoabono, TTRCDOCUMENTO.ccliente ";
                _Str_SQL += " FROM TTRCPAGOM INNER JOIN TTRCPAGOD ON TTRCPAGOM.cidpago = TTRCPAGOD.cidpago INNER JOIN TRELACCOBDCHEQ ON TTRCPAGOM.ccompany = TRELACCOBDCHEQ.ccompany 	AND TTRCPAGOM.cnumerodoc = TRELACCOBDCHEQ.cnumcheque AND TTRCPAGOM.ccliente = TRELACCOBDCHEQ.ccliente AND TTRCPAGOM.cbanco = TRELACCOBDCHEQ.cbancocheque INNER JOIN TTRCDOCUMENTO ON TTRCPAGOM.ccompany = TTRCDOCUMENTO.ccompany AND TTRCPAGOD.cfactura = TTRCDOCUMENTO.cfactura ";
                _Str_SQL += " where ((TRELACCOBDCHEQ.cidrelacobro=" + _P_Str_Relacion + ") and (TRELACCOBDCHEQ.ccompany='" + _P_Str_Compañia + "') and (ctipodoc='C') and (TRELACCOBDCHEQ.ccliente=" + _P_Str_Cliente + ") and (TTRCPAGOM.cguia=" + _P_Str_Guia + "));";

                DataSet dsChequesIngresados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                if (dsChequesIngresados.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow oCheque in dsChequesIngresados.Tables[0].Rows)
                    {
                        var _Str_ccliente = oCheque["ccliente"].ToString();
                        var _Dbl_MontoAbono = Convert.ToDouble(oCheque["cmontoabono"].ToString());
                        _Dbl_MontoAbono = Math.Round(_Dbl_MontoAbono, 2);

                        try
                        {
                            if (_Dbl_MontoAbono > 0) //Si fue cancelado por el pago
                            {
                                _Str_SQL = "insert into TRELACCOBDD (cgroupcomp, ccompany, ctipodocument, cnumdocu, cidrelacobro, ctipocancelado, cidrelaciondetalle, cidrelaciondep, ccliente, cmontodeefectivo)";
                                _Str_SQL += " values (" + _P_Str_Grupo + ", '" + _P_Str_Compañia + "', 'FACT', " + oCheque["cfactura"].ToString() + ", " + _P_Str_Relacion + ", 2, " + oCheque["ciddrelacobro_cheq"].ToString() + ", 0, " + _Str_ccliente + ", " + oCheque["cmontoabono"].ToString().Replace(",", ".") + ");";
                            }
                            else if (_Dbl_MontoAbono == 0) //Si fue cancelado solo por Nc
                            {
                                _Str_SQL = "insert into TRELACCOBDD (cgroupcomp, ccompany, ctipodocument, cnumdocu, cidrelacobro, ctipocancelado, cidrelaciondetalle, cidrelaciondep, ccliente, cmontodeefectivo)";
                                _Str_SQL += " values (" + _P_Str_Grupo + ", '" + _P_Str_Compañia + "', 'FACT', " + oCheque["cfactura"].ToString() + ", " + _P_Str_Relacion + ", 2, " + oCheque["ciddrelacobro_cheq"].ToString() + ", 0, " + _Str_ccliente + ", " + oCheque["cmontoabono"].ToString().Replace(",", ".") + ");";
                            }

                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                        }
                        catch (SqlException e)
                        {
                            if (e.Number == 2627)
                            {
                                _Str_SQL = "update TRELACCOBDD set cmontodeefectivo=" + oCheque["cmontoabono"].ToString().Replace(",", ".");
                                _Str_SQL += " where ((cgroupcomp=" + _P_Str_Grupo + ") and (ccompany='" + _P_Str_Compañia + "') and (ctipodocument='FACT') and (cnumdocu=" + oCheque["cfactura"].ToString() + ") and (cidrelacobro=" + _P_Str_Relacion + ") and (cidrelaciondetalle=" + oCheque["ciddrelacobro_cheq"].ToString() + ") and (ccliente=" + _Str_ccliente + "));";

                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>Este método guarda los depósitos de la relación en las tablas TRELACCOBDDEPM, TRELACCOBDDEPD y TRELACCOBDD.</summary>
        /// <param name="_P_Str_Grupo">Código del grupo de compañia.</param>
        /// <param name="_P_Str_Compañia">Código de la compañía.</param>
        /// <param name="_P_Str_Guia">Número de la guía.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        /// <param name="_P_Str_Relacion">Número de la relación de cobranza.</param>
        private void _Mtd_GuardarDepositos(string _P_Str_Grupo, string _P_Str_Compañia, string _P_Str_Guia, string _P_Str_Cliente, string _P_Str_Relacion)
        {
            string _Str_SQL;
            string _Str_IdDetalle;
            string _Str_IdDetalleDeposito;

            _Str_SQL = "select cnumerodoc, cbanco, cfechaemision, ccuentabancaria, cmontototal from TTRCPAGOM";
            _Str_SQL += " where ((ccompany='" + _P_Str_Compañia + "') and (cguia=" + _P_Str_Guia + ") and (ccliente='" + _P_Str_Cliente + "') and (ctipodoc='D'));";

            DataSet dsResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsResultado.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow oFila in dsResultado.Tables[0].Rows)
                {
                    //Verificamos si ya existe el deposito 
                    _Str_SQL = "select TRELACCOBDDEPM.ciddrelacobro_dep " +
                               "FROM TRELACCOBDDEPM INNER JOIN TRELACCOBDD ON TRELACCOBDDEPM.cgroupcomp = TRELACCOBDD.cgroupcomp AND TRELACCOBDDEPM.ccompany = TRELACCOBDD.ccompany AND TRELACCOBDDEPM.cidrelacobro = TRELACCOBDD.cidrelacobro AND TRELACCOBDDEPM.ciddrelacobro_dep = TRELACCOBDD.cidrelaciondep  " +
                               "where (TRELACCOBDDEPM.cgroupcomp=" + _P_Str_Grupo + ") and (TRELACCOBDDEPM.ccompany='" + _P_Str_Compañia + "') and (TRELACCOBDDEPM.cidrelacobro='" + _P_Str_Relacion + "') and (TRELACCOBDDEPM.cnumdepo='" + oFila["cnumerodoc"].ToString() + "') and (cbancodepo=" + oFila["cbanco"].ToString() + ") and (cnumcuentadepo='" + oFila["ccuentabancaria"].ToString() + "') and (TRELACCOBDD.ccliente='" + _P_Str_Cliente + "')";
                    DataSet dsDepositos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                    if (dsDepositos.Tables[0].Rows.Count == 0)
                    {
                        _Str_SQL = "select (isnull(max(ciddrelacobro_dep), 0) + 1) as ciddrelacobro_dep from TRELACCOBDDEPM";
                        _Str_SQL += " where ((cgroupcomp=" + _P_Str_Grupo + ") and (ccompany='" + _P_Str_Compañia + "') and (cidrelacobro='" + _P_Str_Relacion + "') and (cdelete=0));";

                        DataSet dsMaximo = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                        _Str_IdDetalle = dsMaximo.Tables[0].Rows[0]["ciddrelacobro_dep"].ToString();

                        _Str_SQL = "insert into TRELACCOBDDEPM (cgroupcomp, ccompany, cidrelacobro, ciddrelacobro_dep, cnumdepo, cbancodepo, cnumcuentadepo, cfechadepo, cmontodepo, cdateadd, cuseradd, cdelete)";
                        _Str_SQL += " values (" + _P_Str_Grupo + ", '" + _P_Str_Compañia + "', '" + _P_Str_Relacion + "', " + _Str_IdDetalle + ", '" + oFila["cnumerodoc"].ToString() + "', " + oFila["cbanco"].ToString() + ", '" + oFila["ccuentabancaria"].ToString() + "', convert(datetime, '" + Convert.ToDateTime(oFila["cfechaemision"].ToString()).ToShortDateString() + "', 103), " + oFila["cmontototal"].ToString().Replace(",", ".") + ", getdate(), '" + Frm_Padre._Str_Use + "', 0);";

                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                        _Str_SQL = "select isnull((max(ciddrelacobrodep) + 1), 1) as ciddrelacobrodep from TRELACCOBDDEPD";
                        _Str_SQL += " where ((cgroupcomp=" + _P_Str_Grupo + ") and (ccompany='" + _P_Str_Compañia + "') and (cidrelacobro='" + _P_Str_Relacion + "') and (ciddrelacobrodep=" + _Str_IdDetalle + ") and (cdelete=0));";

                        DataSet dsDetalleDeposito = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                        if (dsDetalleDeposito.Tables[0].Rows.Count > 0)
                        {
                            _Str_IdDetalleDeposito = dsDetalleDeposito.Tables[0].Rows[0]["ciddrelacobrodep"].ToString();

                            _Str_SQL = "insert into TRELACCOBDDEPD (cgroupcomp, ccompany, cidrelacobro, ciddrelacobrodep, cnumdepo, ciddrelacobro_depd, ccliente, cmontodetalle, cdateadd, cuseradd, cdelete, cefectivocheq, cmontocheq, cbancocheque)";
                            _Str_SQL += " values (" + _P_Str_Grupo + ", '" + _P_Str_Compañia + "', '" + _P_Str_Relacion + "', " + _Str_IdDetalle + ", '" + oFila["cnumerodoc"].ToString() + "', " + _Str_IdDetalleDeposito + ", " + _P_Str_Cliente + ", " + oFila["cmontototal"].ToString().Replace(",", ".") + ", getdate(), '" + Frm_Padre._Str_Use + "', 0, 1, 0, 0);";

                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                        }
                    }
                    else
                    {
                        _Str_IdDetalle = dsDepositos.Tables[0].Rows[0]["ciddrelacobro_dep"].ToString();

                        _Str_SQL = "update TRELACCOBDDEPM set cmontodepo=" + oFila["cmontototal"].ToString().Replace(",", ".") + ", cfechadepo=convert(datetime, '" + Convert.ToDateTime(oFila["cfechaemision"].ToString()).ToShortDateString() + "', 103), cbancodepo=" + oFila["cbanco"].ToString() + ", cnumcuentadepo='" + oFila["ccuentabancaria"].ToString() + "'";
                        _Str_SQL += " where (cgroupcomp=" + _P_Str_Grupo + ") and (ccompany='" + _P_Str_Compañia + "') and (cidrelacobro='" + _P_Str_Relacion + "') and (cnumdepo='" + oFila["cnumerodoc"].ToString() + "') and (cbancodepo=" + oFila["cbanco"].ToString() + ") and (cnumcuentadepo='" + oFila["ccuentabancaria"].ToString() + "' and (ciddrelacobro_dep=" + _Str_IdDetalle + "));";

                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                        _Str_SQL = "update TRELACCOBDDEPD set cmontodetalle=" + oFila["cmontototal"].ToString().Replace(",", ".") + ", cdateupd=getdate(), cuserupd='" + Frm_Padre._Str_Use + "'";
                        _Str_SQL += " where (cgroupcomp=" + _P_Str_Grupo + ") and (ccompany='" + _P_Str_Compañia + "') and (cidrelacobro='" + _P_Str_Relacion + "') and (cnumdepo='" + oFila["cnumerodoc"].ToString() + "');";

                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                    }
                }

                _Str_SQL = " SELECT DISTINCT TRELACCOBDDEPM.ciddrelacobro_dep, TTRCPAGOD.cfactura, TTRCPAGOD.cmontoabono, ciddrelacobro_depd, TTRCDOCUMENTO.ccliente " +
                           " from TRELACCOBDDEPM INNER JOIN TTRCPAGOM ON TRELACCOBDDEPM.ccompany = TTRCPAGOM.ccompany AND TRELACCOBDDEPM.cnumdepo = TTRCPAGOM.cnumerodoc INNER JOIN TTRCPAGOD ON TTRCPAGOM.cidpago = TTRCPAGOD.cidpago INNER JOIN TRELACCOBDDEPD ON TRELACCOBDDEPM.ccompany = TRELACCOBDDEPD.ccompany AND TRELACCOBDDEPM.cgroupcomp = TRELACCOBDDEPD.cgroupcomp AND TRELACCOBDDEPM.cidrelacobro = TRELACCOBDDEPD.cidrelacobro AND TTRCPAGOM.ccliente = TRELACCOBDDEPD.ccliente AND TRELACCOBDDEPM.ciddrelacobro_dep = TRELACCOBDDEPD.ciddrelacobrodep INNER JOIN TTRCDOCUMENTO ON TTRCPAGOM.ccompany = TTRCDOCUMENTO.ccompany AND TTRCPAGOD.cfactura = TTRCDOCUMENTO.cfactura " + 
                           " where ((TRELACCOBDDEPM.cidrelacobro=" + _P_Str_Relacion + ") and (TRELACCOBDDEPM.ccompany='" + _P_Str_Compañia + "') and (ctipodoc='D') and (TTRCPAGOM.ccliente=" + _P_Str_Cliente + ") and (TTRCPAGOM.cguia=" + _P_Str_Guia + ")) ";

                DataSet dsDepositosIngresados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                if (dsDepositosIngresados.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow oDeposito in dsDepositosIngresados.Tables[0].Rows)
                    {
                        var _Str_ccliente = oDeposito["ccliente"].ToString();
                        var _Dbl_MontoAbono = Convert.ToDouble(oDeposito["cmontoabono"].ToString());
                        _Dbl_MontoAbono = Math.Round(_Dbl_MontoAbono, 2);

                        try
                        {

                            if (_Dbl_MontoAbono > 0) //Si fue cancelado por el pago
                            {
                                _Str_SQL = "insert into TRELACCOBDD (cgroupcomp, ccompany, ctipodocument, cnumdocu, cidrelacobro, ctipocancelado, cidrelaciondetalle, cidrelaciondep, ccliente, cmontodeefectivo)";
                                _Str_SQL += " values (" + _P_Str_Grupo + ", '" + _P_Str_Compañia + "', 'FACT', " + oDeposito["cfactura"].ToString() + ", " + _P_Str_Relacion + ", 1, " + oDeposito["ciddrelacobro_depd"].ToString() + ", " + oDeposito["ciddrelacobro_dep"].ToString() + ", " + _Str_ccliente + ", " + oDeposito["cmontoabono"].ToString().Replace(",", ".") + ")";
                            }
                            else if (_Dbl_MontoAbono == 0) //Si fue cancelado solo por Nc
                            {
                                _Str_SQL = "insert into TRELACCOBDD (cgroupcomp, ccompany, ctipodocument, cnumdocu, cidrelacobro, ctipocancelado, cidrelaciondetalle, cidrelaciondep, ccliente, cmontodeefectivo)";
                                _Str_SQL += " values (" + _P_Str_Grupo + ", '" + _P_Str_Compañia + "', 'FACT', " + oDeposito["cfactura"].ToString() + ", " + _P_Str_Relacion + ", 1,  " + oDeposito["ciddrelacobro_depd"].ToString() + ", " + oDeposito["ciddrelacobro_dep"].ToString() + ", " + _Str_ccliente + ", " + oDeposito["cmontoabono"].ToString().Replace(",", ".") + ")";
                            }

                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                        }
                        catch (SqlException e)
                        {
                            if (e.Number == 2627)
                            {
                                _Str_SQL = "update TRELACCOBDD set cmontodeefectivo=" + oDeposito["cmontoabono"].ToString().Replace(",", ".");
                                _Str_SQL += " where ((cgroupcomp=" + _P_Str_Grupo + ") and (ccompany='" + _P_Str_Compañia + "') and (ctipodocument='FACT') and (cnumdocu=" + oDeposito["cfactura"].ToString() + ") and (cidrelacobro=" + _P_Str_Relacion + ") and (ctipocancelado=1) and (cidrelaciondetalle=" + oDeposito["ciddrelacobro_depd"].ToString() + ") and (cidrelaciondep=" + oDeposito["ciddrelacobro_dep"].ToString() + ") and (ccliente=" + _Str_ccliente + "));";

                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>Este método para guardar las notas de crédito en TRELACCOBD.</summary>
        /// <param name="_P_Str_Compañia">Código de la compañia.</param>
        /// <param name="_P_Str_Guia">Número de la guía.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        /// <param name="_P_Str_Relacion">Número de la relación.</param>
        /// <param name="_P_Str_Factura">Número de factura.</param>
        private void _Mtd_GuardarNotasCredito(string _P_Str_Compañia, string _P_Str_Guia, string _P_Str_Cliente, string _P_Str_Relacion, string _P_Str_Factura)
        {
            string _Str_SQL;
            int _Int_Contador = 1;
            
            _Str_SQL = "select TTRCNOTACREDD.cnotacredito, TTRCPAGOD.cfactura from TTRCPAGOD inner join TTRCPAGOM on TTRCPAGOD.cidpago = TTRCPAGOM.cidpago inner join TTRCNOTACREDD on TTRCPAGOD.cidpago = TTRCNOTACREDD.cidpago and TTRCPAGOD.cfactura = TTRCNOTACREDD.cfactura";
            _Str_SQL += " where ((ccompany='" + _P_Str_Compañia + "') and (cguia=" + _P_Str_Guia + ") and (TTRCNOTACREDD.cfactura=" + _P_Str_Factura + "));";

            DataSet dsResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsResultado.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow oFila in dsResultado.Tables[0].Rows)
                {
                    _Str_SQL = "update TRELACCOBD set cnotacred" + _Int_Contador + "=" + oFila["cnotacredito"].ToString();
                    _Str_SQL += " where ((ccompany='" + _P_Str_Compañia + "') and (ccliente=" + _P_Str_Cliente + ") and (cidrelacobro='" + _P_Str_Relacion + "') and (cnumdocu=" + _P_Str_Factura + ") and (ctipodocument='FACT'));";

                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                    _Int_Contador += 1;
                }
            }
        }

        /// <summary>Este método para guardar las retenciones en TRELACCOBD.</summary>
        /// <param name="_P_Str_Compañia">Código de la compañia.</param>
        /// <param name="_P_Str_Guia">Número de la guía.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        /// <param name="_P_Str_Relacion">Número de la relación.</param>
        /// <param name="_P_Str_Factura">Número de factura.</param>
        private void _Mtd_GuardarRetenciones(string _P_Str_Compañia, string _P_Str_Guia, string _P_Str_Cliente, string _P_Str_Relacion, string _P_Str_Factura)
        {
            string _Str_SQL;

            _Str_SQL = "select TTRCPAGOD.cfactura, TTRCPAGOD.cnumerocontrol, TTRCRETENCION.cfechaemision, TTRCRETENCION.cmonto, TTRCRETENCION.cnumretencion";
            _Str_SQL += " from TTRCPAGOD inner join TTRCPAGOM on TTRCPAGOD.cidpago = TTRCPAGOM.cidpago inner join TTRCRETENCION on TTRCPAGOM.cidpago = TTRCRETENCION.cidpago and TTRCPAGOD.cfactura = TTRCRETENCION.cfactura";
            _Str_SQL += " where ((ccompany='" + _P_Str_Compañia + "') and (cguia=" + _P_Str_Guia + ") and (TTRCPAGOD.cfactura=" + _P_Str_Factura + "));";

            DataSet dsResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsResultado.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow oFila in dsResultado.Tables[0].Rows)
                {
                    _Str_SQL = "update TRELACCOBD set cretencioniva=1, cnumcomproclie='" + oFila["cnumretencion"].ToString() + "', cnumercontrol=" + oFila["cnumerocontrol"].ToString() + ", cmontcompretiva=" + oFila["cmonto"].ToString().Replace(",", ".") + ", cfecharetencion=convert(datetime, '" + Convert.ToDateTime(oFila["cfechaemision"].ToString()).ToShortDateString() + "', 103)";
                    _Str_SQL += " where ((ccompany='" + _P_Str_Compañia + "') and (ccliente=" + _P_Str_Cliente + ") and (cidrelacobro='" + _P_Str_Relacion + "') and (cnumdocu=" + _P_Str_Factura + ") and (ctipodocument='FACT'));";

                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                }
            }
        }

        /// <summary>Este método obtiene las empresas de la guía de despacho.</summary>
        /// <param name="_P_Str_Guia">Código de la guía de despacho.</param>
        /// <returns>Compañías en el detalle de la guía de despacho.</returns>
        private DataSet _Mtd_ObtenerEmpresasGuia(string _P_Str_Guia)
        {
            string _Str_SQL;

            _Str_SQL = "select distinct ltrim(rtrim(TGUIADESPACHOD.ccompany)) as ccompany, ltrim(rtrim(cname)) as cname from TGUIADESPACHOD";
            _Str_SQL += " inner join TCOMPANY on TGUIADESPACHOD.ccompany=TCOMPANY.ccompany";
            _Str_SQL += " where ((cguiadesp=" + _P_Str_Guia + ") and (cgroupcomp='" + Frm_Padre._Str_GroupComp + "'));";

            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
        }

        /// <summary>Este método carga el código del vendedor y su gerente de área según la compañía.</summary>
        /// <param name="_P_Str_Compañia">Código de la compañía.</param>
        /// <returns>Conjunto de resultados con los usuarios del sistema.</returns>
        private DataSet _Mtd_ObtenerUsuario(string _P_Str_Compañia)
        {
            string _Str_SQL;

            _Str_SQL = "select TCONFIGCXC.CCODIGOVENDEDOROFICINA as cvendedor, cgerarea from TCONFIGCXC";
            _Str_SQL += " inner join TVENDEDOR on TCONFIGCXC.ccompany=TVENDEDOR.ccompany and TCONFIGCXC.CCODIGOVENDEDOROFICINA=TVENDEDOR.cvendedor ";
            _Str_SQL += " where (TCONFIGCXC.ccompany=('" + _P_Str_Compañia.Trim() + "'));";

            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
        }

        /// <summary>Este método verifica si la guía tiene pago.</summary>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        /// <param name="_P_Str_Guia">Número de la guía.</param>
        /// <returns>Verdadero si el cliente de la guía tiene pagos.</returns>
        private bool _Mtd_TienePagoGuia(string _P_Str_Cliente, string _P_Str_Guia)
        {
            string _Str_SQL = "select cidpago from TTRCPAGOM where ((ccliente=" + _P_Str_Cliente + ") and (cguia=" + _P_Str_Guia + ") and (cdelete=0));";

            DataSet dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            return ((dsResultados.Tables[0].Rows.Count == 0) ? false : true);
        }

        /// <summary>Este método verifica si existen pagos por compañía.</summary>
        /// <param name="_P_Str_Compañia">Código de la compañía.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        /// <param name="_P_Str_Guia">Número de la guía.</param>
        /// <returns>Verdadero si la compañía tiene pagos cargados.</returns>
        private bool _Mtd_TienePagoCompañia(string _P_Str_Compañia, string _P_Str_Cliente, string _P_Str_Guia)
        {
            string _Str_SQL;

            _Str_SQL = "select ciddetalle from TTRCPAGOD inner join TTRCPAGOM on TTRCPAGOD.cidpago = TTRCPAGOM.cidpago where ((ccompany='" + _P_Str_Compañia + "') and (ccliente=" + _P_Str_Cliente + ") and (cguia=" + _P_Str_Guia + "));";

            DataSet dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            return ((dsResultados.Tables[0].Rows.Count == 0) ? false : true);
        }

        /// <summary>Este método devuelve el límite del fatante en la tabla de configuración.</summary>
        /// <param name="_P_Str_Compañia">Código de la compañía.</param>
        /// <returns>Valor del límite del faltante.</returns>
        public static double _Mtd_ObtenerLimiteFaltante(string _P_Str_Compañia)
        {
            string _Str_SQL;

            _Str_SQL = "select isnull(climitefaltante, 0) as climitefaltante from TCONFIGCXC where (ccompany='" + _P_Str_Compañia + "');";

            DataSet dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            return (Convert.ToDouble(dsResultados.Tables[0].Rows[0]["climitefaltante"].ToString()));
        }

        #endregion

        #region Eventos

        private void Frm_RC_DocumentosClientes_Load(object sender, EventArgs e)
        {
            /* 
             *  Aqui se hace lo siguiente:
             * 
             *      1. Se genera los encabezados de la relación o se buscan para la guía ingresada.
             *      2. Se verifica si el usuario actual está creado como un vendedor en TUSUARIOCOBRANZA.
             *      3. Se emitirá un mensaje de advertencia y se cierra el formulario cuando el usuario no sea vendedor en una de las compañías.
             *      4. Cargamos el detalle el detalle de la guía de despacho o de las relaciones de cobranza si tiene asignada.
             */

            bool _Bol_Cancelar = false;

            DataSet dsCompañias = _Mtd_ObtenerEmpresasGuia(_G_Str_GuiaDespacho);

            foreach (DataRow oFila in dsCompañias.Tables[0].Rows)
            {
                DataSet dsUsuario = _Mtd_ObtenerUsuario(oFila["ccompany"].ToString());

                if (dsUsuario.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show
                    (
                        "Para cargar las relaciones de cobranza, su usuario debe estar creado como un vendedor en " + dsCompañias.Tables[0].Rows[0]["cname"].ToString() + ".",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    _Bol_Cancelar = true;

                    break;
                }
                else
                {
                    if (dsUsuario.Tables[0].Rows[0]["cgerarea"].ToString() == "")
                    {
                        MessageBox.Show
                        (
                            "Para cargar las relaciones de cobranza, su usuario debe tener un gerente de área asignado en " + dsCompañias.Tables[0].Rows[0]["cname"].ToString() + ".",
                            "Advertencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        _Bol_Cancelar = true;

                        break;
                    }
                }
            }

            if (_Bol_Cancelar)
            {
                Close();
            }
            else
            {
                _Mtd_MostrarCliente(_G_Str_Cliente);

                _Mtd_CargarDocumentos(_G_Str_GuiaDespacho, _G_Str_Cliente, true);
            }
        }

        private void Frm_RC_DocumentosClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_G_Enum_Estado == TiposEstadoRelacion.EstadoPagoEditando)
            {

                Cursor = Cursors.WaitCursor;
                _Mtd_GuardarRelacion(Frm_Padre._Str_GroupComp, _G_Str_Cliente, _G_Str_GuiaDespacho);
                Cursor = Cursors.Default;
            }
        }

        private void _Btn_PagoCheque_Click(object sender, EventArgs e)
        {
            if (_Dtg_Documentos.Rows.Count <= 0)
            {
                MessageBox.Show ("No hay documentos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Frm_RC_Pago Frm_PagoCheque = new Frm_RC_Pago(_G_Str_GuiaDespacho, _G_Str_Cliente, true, _G_Bol_EsCasaMatriz);

            Frm_PagoCheque.ShowDialog(this);

            foreach (DataGridViewRow oFila in _Dtg_Documentos.Rows)
            {
                _Mtd_ActualizarSaldo(oFila.Cells["colCompañia"].Value.ToString(), _G_Str_GuiaDespacho, oFila.Cells["colCliente"].Value.ToString(), oFila.Cells["colFactura"].Value.ToString());
            }

            _Mtd_CargarDocumentos(_G_Str_GuiaDespacho, _G_Str_Cliente);
        }

        private void _Btn_PagoEfectivo_Click(object sender, EventArgs e)
        {
            if (_Dtg_Documentos.Rows.Count <= 0)
            {
                MessageBox.Show("No hay documentos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Frm_RC_Pago Frm_PagoEfectivo = new Frm_RC_Pago(_G_Str_GuiaDespacho, _G_Str_Cliente, false, _G_Bol_EsCasaMatriz);

            Frm_PagoEfectivo.ShowDialog(this);

            foreach (DataGridViewRow oFila in _Dtg_Documentos.Rows)
            {
                _Mtd_ActualizarSaldo(oFila.Cells["colCompañia"].Value.ToString(), _G_Str_GuiaDespacho, oFila.Cells["colCliente"].Value.ToString(), oFila.Cells["colFactura"].Value.ToString());
            }

            _Mtd_CargarDocumentos(_G_Str_GuiaDespacho, _G_Str_Cliente);
        }

        private void _Btn_Finalizar_Click(object sender, EventArgs e)
        {
            try
            {   
                if (!_Mtd_TienePagoGuia(_G_Str_Cliente, _G_Str_GuiaDespacho))
                {
                    MessageBox.Show
                    (
                        "No se han cargado pagos al cliente.",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    return;
                }

                //Calculamos los saldos
                var _Dbl_Saldo = _Mtd_ObtenerSaldo(_G_Str_GuiaDespacho, _G_Str_Cliente);

                //Redeondeamos
                _Dbl_Saldo = Math.Round(_Dbl_Saldo, 2);

                if (_Dbl_Saldo < 0) //Faltante
                {
                    if ((Math.Abs(_Dbl_Saldo) < _Mtd_ObtenerLimiteFaltante(Frm_Padre._Str_Comp)))
                    {
                        if (MessageBox.Show("¿Desea procesar la cobranza?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            _Mtd_GuardarRelacion(Frm_Padre._Str_GroupComp, _G_Str_Cliente, _G_Str_GuiaDespacho);
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show
                        (
                            "Existe un faltante de " + Math.Abs(_Dbl_Saldo).ToString("c") + ".",
                            "Advertencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                        return;
                    }
                }
                else // Sobrante
                {
                    if (MessageBox.Show("¿Desea procesar la cobranza?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        _Mtd_GuardarRelacion(Frm_Padre._Str_GroupComp, _G_Str_Cliente, _G_Str_GuiaDespacho);
                        Close();
                    }
                }
            }
            catch (TransactionAbortedException _OEx)
            {
                MessageBox.Show("Mensaje de Error al usuario : TransactionAbortedException : {0}", _OEx.Message);
            }
            catch (ApplicationException _OEx)
            {
                MessageBox.Show("Mensaje de Error al usuario : ApplicationException : {0}", _OEx.Message);
            }
        }

        private double _Mtd_ObtenerSaldoCliente()
        {
            var _Dbl_TotalCobros = (_Mtd_TotalCheques(_G_Str_GuiaDespacho, _G_Str_Cliente) + _Mtd_TotalDepositos(_G_Str_GuiaDespacho, _G_Str_Cliente));
            var _Dbl_TotalDocumentos = _Mtd_TotalDocumentos(_G_Str_GuiaDespacho, _G_Str_Cliente);

            //Quitamos signos
            _Dbl_TotalCobros = Math.Abs(_Dbl_TotalCobros);
            _Dbl_TotalDocumentos = Math.Abs(_Dbl_TotalDocumentos);

            //Redondeamos
            _Dbl_TotalCobros = Math.Round(_Dbl_TotalCobros, 2);
            _Dbl_TotalDocumentos = Math.Round(_Dbl_TotalDocumentos, 2);

            var _Dbl_Diferencia = _Dbl_TotalCobros - _Dbl_TotalDocumentos;
            _Dbl_Diferencia = Math.Round(_Dbl_Diferencia, 2);

            return _Dbl_Diferencia;
        }


        #endregion
    }
}