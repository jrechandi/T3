using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using T3.Cobranza;
using System.Transactions;

namespace T3
{
    namespace Cobranza
    {

        #region Tipos

        /// <summary>Estados del formulario de pago.</summary>
        public enum TiposEstadoPago
        {
            EstadoPagoNuevo = 0,
            EstadoPagoConsultar,
            EstadoPagoEditar,
            EstadoInicial
        }

        /// <summary>Datos de la guía.</summary>
        public class Pago
        {
            /// <summary>Código de la compañía.</summary>
            public string Compañia { set; get; }

            /// <summary>Código de la guía.</summary>
            public string Guia { set; get; }

            /// <summary>Código del cliente.</summary>
            public string Cliente { set; get; }

            /// <summary>Bandera para indicar si el pago es con cheque, de lo contrario es con depódito.</summary>
            public bool ConCheque { set; get; }
        }

        #endregion
    }

    public partial class Frm_RC_Pago : Form
    {
        #region Variables

        /// <summary>Estados del formulario de pago.</summary>
        private TiposEstadoPago _G_Estado_Formulario;

        /// <summary>Instancia del pago, solo de uso interno.</summary>
        private Pago _G_Enum_Pago = new Pago();

        private string _G_Str_cidpago = "";
        private bool _G_Bol_EsCasaMatriz = false;

        #endregion

        #region Métodos

        /// <summary>Constructor del formulario.</summary>
        /// <param name="_P_Str_Guia">Código de la guía de despacho.</param>
        /// <param name="_P_Str_Cliente">Código del cliente de la guía.</param>
        /// <param name="_P_Bol_ConCheque">Al ser verdadero se muestra la pantalla de los pagos con cheques, de lo contrario, pagos con depósitos.</param>
        public Frm_RC_Pago(string _P_Str_Guia, string _P_Str_Cliente, bool _P_Bol_ConCheque, bool _P_Bol_EsCasaMatriz)
        {
            InitializeComponent();

            _G_Enum_Pago.Guia = _P_Str_Guia;
            _G_Enum_Pago.Cliente = _P_Str_Cliente;
            _G_Enum_Pago.ConCheque = _P_Bol_ConCheque;
            _G_Bol_EsCasaMatriz = _P_Bol_EsCasaMatriz;
            _G_Estado_Formulario = TiposEstadoPago.EstadoPagoConsultar;
        }

        /// <summary>Este método permite llenar el combo de compañías.</summary>
        /// <param name="_P_Obj_Combo">Combo donde se muestran las compañías de los documentos de la guía.</param>
        /// <param name="_P_Str_Guia">Número de la guía de despacho.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        private void _Mtd_CargarCompañias(ComboBox _P_Obj_Combo, string _P_Str_Guia, string _P_Str_Cliente)
        {
            string _Str_SQL;

            _Str_SQL = "SELECT DISTINCT TCOMPANY.ccompany, TCOMPANY.cname " +
                       "FROM TCOMPANY INNER JOIN TTRCDOCUMENTO ON TCOMPANY.ccompany = TTRCDOCUMENTO.ccompany INNER JOIN TCLIENTE ON TTRCDOCUMENTO.ccliente = TCLIENTE.ccliente INNER JOIN TGROUPCOMPANYD ON TCOMPANY.ccompany = TGROUPCOMPANYD.ccompany AND TCLIENTE.cgroupcomp = TGROUPCOMPANYD.cgroupcomp " +
                       "WHERE (TGROUPCOMPANYD.cdelete = 0) AND (TCLIENTE.cdelete = 0) AND (TTRCDOCUMENTO.cdelete = 0) AND (TCOMPANY.cdelete = 0) ";
            if (_G_Bol_EsCasaMatriz)
            {
                _Str_SQL += " AND (TTRCDOCUMENTO.cguia=" + _P_Str_Guia + ") and ((TTRCDOCUMENTO.ccliente = '" + _P_Str_Cliente + "') OR (TCLIENTE.c_casa_matriz ='" + _P_Str_Cliente + "'))";
            }
            else
            {
                _Str_SQL += " AND (TTRCDOCUMENTO.cguia=" + _P_Str_Guia + ") and (TTRCDOCUMENTO.ccliente=" + _P_Str_Cliente + ") ";
            }

            DataSet dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsResultados.Tables[0].Rows.Count > 0)
            {
                _P_Obj_Combo.DataSource = dsResultados.Tables[0];
                _P_Obj_Combo.DisplayMember = "cname";
                _P_Obj_Combo.ValueMember = "ccompany";
            }
            else
            {
                _P_Obj_Combo.DataSource = null;
            }
        }

        /// <summary>Este método permite cargar los pagos según la guía y el cliente en el combo de documentos.</summary>
        /// <param name="_P_Obj_Combo">Combo donde se muestran las compañías de los documentos de la guía.</param>
        /// <param name="_P_Str_Compañia">Código de la compañía.</param>
        /// <param name="_P_Str_Guia">Número de la guía de despacho.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>        
        private void _Mtd_CargarDocumentos(ComboBox _P_Obj_Combo, string _P_Str_Compañia, string _P_Str_Guia, string _P_Str_Cliente)
        {
            string _Str_SQL;

            _Str_SQL = "select cidpago, ('" + ((_G_Enum_Pago.ConCheque) ? "Cheque" : "Dep.") +
                       ": ' + convert(varchar, cnumerodoc) + ' - Bs F. ' + dbo.Fnc_Formatear(cmontototal) + ' - [' + ltrim(rtrim(cname)) + ']') as cdescripcion from TTRCPAGOM";
            _Str_SQL += " inner join TBANCO on TTRCPAGOM.cbanco = TBANCO.cbanco and TTRCPAGOM.ccompany = TBANCO.ccompany";
            _Str_SQL += " where ((ctipodoc='" + ((_G_Enum_Pago.ConCheque) ? "C" : "D") + "') and (TTRCPAGOM.ccompany='" + _P_Str_Compañia.Trim() + "') and (cguia=" + _P_Str_Guia + ") and (ccliente=" +
                        _P_Str_Cliente + "));";

            DataSet dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsResultados.Tables[0].Rows.Count > 0)
            {
                _P_Obj_Combo.DataSource = dsResultados.Tables[0];
                _P_Obj_Combo.DisplayMember = "cdescripcion";
                _P_Obj_Combo.ValueMember = "cidpago";
            }
            else
            {
                _P_Obj_Combo.DataSource = null;
            }
        }

        /// <summary>Este método permite cargar los datos del documento, es decir, los pagos.</summary>
        /// <param name="_P_Str_Compañia">Código de la compañía.</param>
        /// <param name="_P_Str_Guia">Número de la guía de despacho.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        /// <param name="_P_Str_Documento">Código del pago.</param>
        private void _Mtd_CargarDatosDocumento(string _P_Str_Compañia, string _P_Str_Guia, string _P_Str_Cliente, string _P_Str_Documento)
        {
            string _Str_SQL;

            _Str_SQL = "select cidpago, cnumerodoc, cbanco, cfechaemision, cfechadeposito, cmontototal from TTRCPAGOM";
            _Str_SQL += " where ((ccompany='" + _P_Str_Compañia.Trim() + "') and (cidpago=" + _P_Str_Documento + ") and (ccliente=" + _P_Str_Cliente + ") and (cguia=" + _P_Str_Guia + ") and (ctipodoc='" +
                        ((_G_Enum_Pago.ConCheque) ? "C" : "D") + "'));";

            DataSet dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsResultados.Tables[0].Rows.Count > 0)
            {
                _Txt_IdDocumento.Text = dsResultados.Tables[0].Rows[0]["cidpago"].ToString();

                _Txt_NumeroDocumento.Text = dsResultados.Tables[0].Rows[0]["cnumerodoc"].ToString();
                _Txt_NumeroDocumento.Enabled = false;

                _Cmb_BancosDocumento.SelectedValue = dsResultados.Tables[0].Rows[0]["cbanco"].ToString();
                _Cmb_BancosDocumento.Enabled = false;

                _Dtp_FechaEmision.Value = Convert.ToDateTime(dsResultados.Tables[0].Rows[0]["cfechaemision"].ToString());
                _Dtp_FechaEmision.Enabled = false;

                _Dtp_FechaDepositar.Value = Convert.ToDateTime(dsResultados.Tables[0].Rows[0]["cfechadeposito"].ToString());
                _Dtp_FechaDepositar.Enabled = false;

                _Txt_MontoDocumento.Tag = dsResultados.Tables[0].Rows[0]["cmontototal"].ToString();
                _Txt_MontoDocumento.Text = Convert.ToDouble(dsResultados.Tables[0].Rows[0]["cmontototal"].ToString()).ToString("c");
                _Txt_MontoDocumento.Enabled = false;
            }
        }

        /// <summary>Este método permite cargar los bancos en combo correspondiente.</summary>
        /// <param name="_P_Obj_Combo">Combo del banco.</param>
        /// <param name="_P_Str_Compañia">Código de la compañía.</param>        
        private void _Mtd_CargarBancos(ComboBox _P_Obj_Combo, string _P_Str_Compañia)
        {
            string _Str_SQL;

            //Valor por defecto
            _Str_SQL = "select 'nulo' as cbanco, '...' as cname UNION ";


            if (_G_Enum_Pago.ConCheque)
            {
                _Str_SQL += " select cbanco, REPLACE(REPLACE(LTRIM(RTRIM(CNAME)),'BANCO DE ',''),'BANCO ','') AS CNAME from TBANCO where ((ccompany='" + _P_Str_Compañia.Trim() + "') and (cdelete=0)) order by cname asc;";
            }
            else
            {
                _Str_SQL += "select TBANCO.cbanco, LTRIM(RTRIM((REPLACE(REPLACE(LTRIM(RTRIM(TBANCO.CNAME)),'BANCO DE ',''),'BANCO ','')  + ' - CTA: ' + ltrim(rtrim(cnumcuenta))))) as cname from TBANCO";
                _Str_SQL += " inner join TCUENTBANC on TBANCO.ccompany = TCUENTBANC.ccompany and TBANCO.cbanco = TCUENTBANC.cbanco";
                _Str_SQL += " where ((TBANCO.ccompany='" + _P_Str_Compañia.Trim() + "') and (TBANCO.cdelete=0)) order by TBANCO.cname asc;";
            }

            DataSet dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            _P_Obj_Combo.DataSource = dsResultados.Tables[0];
            _P_Obj_Combo.DisplayMember = "cname";
            _P_Obj_Combo.ValueMember = "cbanco";
        }

        /// <summary>Este método permite cargar las facturas del cliente según la guía.</summary>
        /// <param name="_P_Str_Compañia">Código de la compañía.</param>
        /// <param name="_P_Str_Guia">Código de la guía de despacho.</param>
        /// <param name="_P_Str_Cliente">Código del cliente de la guía de despacho.</param>
        /// <param name="_P_Str_Pago"></param>
        private void _Mtd_CargarFacturas(string _P_Str_Compañia, string _P_Str_Guia, string _P_Str_Cliente, string _P_Str_Pago)
        {
            var _Ds_Resultados = _Mtd_ObtenerFacturas(_P_Str_Compañia, _P_Str_Guia, _P_Str_Cliente, _P_Str_Pago);
            _Dtg_Facturas.DataSource = _Ds_Resultados.Tables[0];
        }

        private bool _Mtd_HayDocumentosPorPagar(string _P_Str_Compañia, string _P_Str_Guia, string _P_Str_Cliente, string _P_Str_Pago)
        {
            var _Ds_Resultados = _Mtd_ObtenerFacturas(_P_Str_Compañia, _P_Str_Guia, _P_Str_Cliente, _P_Str_Pago);
            return _Ds_Resultados.Tables[0].Rows.Count > 0;
        }

        //Obtiene los documentos por pagar
        private DataSet _Mtd_ObtenerFacturas(string _P_Str_Compañia, string _P_Str_Guia, string _P_Str_Cliente, string _P_Str_Pago)
        {
            string _Str_SQL;

            if (_G_Estado_Formulario == TiposEstadoPago.EstadoPagoNuevo)
            {
                _Str_SQL = "select TGUIADESPACHOD.ccompany, TGUIADESPACHOD.cfactura, TFACTURAM.c_numerocontrol, convert(varchar, TFACTURAM.c_fecha_factura, 103) as c_fecha_factura, convert(varchar, TSALDOCLIENTED.cfechaentrega, 103) as cfechaentrega,";
                _Str_SQL += " 0.0 as cmontoapagar,";
                _Str_SQL += " 0.0 as cabono,";
                _Str_SQL += " TTRCDOCUMENTO.cmontodocumento AS cmontototal, TTRCDOCUMENTO.cmontosaldo, 0.0 as cmontopagadoporpago,";
                _Str_SQL += " TFACTURAM.c_montotot_si_bs AS cmontototalsinimpuesto, TFACTURAM.c_impuesto_bs AS cmontototalimpuesto,TFACTURAM.ccliente,(CONVERT(VARCHAR,TCLIENTE.ccliente) + ' - ' + TCLIENTE.c_nomb_comer) AS cNombreCliente ";
                _Str_SQL += " FROM TSALDOCLIENTED INNER JOIN TCONFIGCXC ON TSALDOCLIENTED.ctipodocument = TCONFIGCXC.ctipdocfact AND TSALDOCLIENTED.ccompany = TCONFIGCXC.ccompany INNER JOIN TGUIADESPACHOD INNER JOIN TFACTURAM ON TGUIADESPACHOD.cfactura = TFACTURAM.cfactura AND TGUIADESPACHOD.ccompany = TFACTURAM.ccompany AND TGUIADESPACHOD.cgroupcomp = TFACTURAM.cgroupcomp INNER JOIN TVENDEDOR ON TFACTURAM.cvendedor = TVENDEDOR.cvendedor AND TFACTURAM.ccompany = TVENDEDOR.ccompany ON TSALDOCLIENTED.cgroupcomp = TFACTURAM.cgroupcomp AND TSALDOCLIENTED.ccompany = TFACTURAM.ccompany AND TSALDOCLIENTED.cnumdocu = TFACTURAM.cfactura INNER JOIN TTRCDOCUMENTO ON TSALDOCLIENTED.ccompany = TTRCDOCUMENTO.ccompany AND TSALDOCLIENTED.ccliente = TTRCDOCUMENTO.ccliente AND TSALDOCLIENTED.cnumdocu = TTRCDOCUMENTO.cfactura INNER JOIN TCLIENTE ON TFACTURAM.cgroupcomp = TCLIENTE.cgroupcomp AND TFACTURAM.ccliente = TCLIENTE.ccliente ";
                _Str_SQL += " WHERE ((TGUIADESPACHOD.ccompany='" + _P_Str_Compañia.Trim() + "') and (TGUIADESPACHOD.cguiadesp=" + _P_Str_Guia + ") and (TGUIADESPACHOD.c_fact_anul=0) and (c_estatus='PAG') AND (ISNULL(csinretencion,0)=0) ";
                _Str_SQL += ((_G_Estado_Formulario == TiposEstadoPago.EstadoPagoNuevo) ? " and (TTRCDOCUMENTO.ccancelada=0))" : "");
                _Str_SQL += " AND (ISNULL(TCLIENTE.cdelete,0)=0) ";
                if (_G_Bol_EsCasaMatriz)
                {
                    _Str_SQL += " AND ((TFACTURAM.ccliente=" + _P_Str_Cliente + ") OR ((TTRCDOCUMENTO.ccliente = '" + _P_Str_Cliente + "') OR ((TCLIENTE.c_casa_matriz ='" + _P_Str_Cliente + "') AND NOT EXISTS (SELECT TTRCPAGOM.ccliente FROM TTRCPAGOM WHERE CONVERT(VARCHAR,TTRCPAGOM.ccliente) = CONVERT(VARCHAR,TCLIENTE.ccliente) AND TTRCPAGOM.ccompany = TTRCDOCUMENTO.ccompany AND TTRCPAGOM.cguia = TTRCDOCUMENTO.cguia))) AND (ISNULL(TCLIENTE.cdelete,0)=0)) ";
                }
                else
                {
                    _Str_SQL += " AND (TFACTURAM.ccliente=" + _P_Str_Cliente + ") ";
                }
            }
            else
            {
                _Str_SQL = "select TGUIADESPACHOD.ccompany, TGUIADESPACHOD.cfactura, TFACTURAM.c_numerocontrol, convert(varchar, TFACTURAM.c_fecha_factura, 103) as c_fecha_factura, convert(varchar, TSALDOCLIENTED.cfechaentrega, 103) as cfechaentrega,";
                _Str_SQL += " 0.0 as cmontoapagar,";
                _Str_SQL += " 0.0 as cabono,";
                _Str_SQL += " TTRCDOCUMENTO.cmontodocumento AS cmontototal, TTRCDOCUMENTO.cmontosaldo, 0.0 as cmontopagadoporpago,";
                _Str_SQL += " TFACTURAM.c_montotot_si_bs AS cmontototalsinimpuesto, TFACTURAM.c_impuesto_bs AS cmontototalimpuesto,TFACTURAM.ccliente,(CONVERT(VARCHAR,TCLIENTE.ccliente) + ' - ' + TCLIENTE.c_nomb_comer) AS cNombreCliente ";

                _Str_SQL += " FROM TSALDOCLIENTED INNER JOIN TCONFIGCXC ON TSALDOCLIENTED.ctipodocument = TCONFIGCXC.ctipdocfact AND TSALDOCLIENTED.ccompany = TCONFIGCXC.ccompany INNER JOIN TGUIADESPACHOD INNER JOIN TFACTURAM ON TGUIADESPACHOD.cfactura = TFACTURAM.cfactura AND TGUIADESPACHOD.ccompany = TFACTURAM.ccompany AND TGUIADESPACHOD.cgroupcomp = TFACTURAM.cgroupcomp INNER JOIN TVENDEDOR ON TFACTURAM.cvendedor = TVENDEDOR.cvendedor AND TFACTURAM.ccompany = TVENDEDOR.ccompany ON TSALDOCLIENTED.cgroupcomp = TFACTURAM.cgroupcomp AND TSALDOCLIENTED.ccompany = TFACTURAM.ccompany AND TSALDOCLIENTED.cnumdocu = TFACTURAM.cfactura INNER JOIN TTRCDOCUMENTO ON TSALDOCLIENTED.ccompany = TTRCDOCUMENTO.ccompany AND TSALDOCLIENTED.ccliente = TTRCDOCUMENTO.ccliente AND TSALDOCLIENTED.cnumdocu = TTRCDOCUMENTO.cfactura INNER JOIN TCLIENTE ON TFACTURAM.cgroupcomp = TCLIENTE.cgroupcomp AND TFACTURAM.ccliente = TCLIENTE.ccliente ";

                _Str_SQL += " where ((TGUIADESPACHOD.ccompany='" + _P_Str_Compañia.Trim() + "') and (TGUIADESPACHOD.cguiadesp=" + _P_Str_Guia + ") and (TGUIADESPACHOD.c_fact_anul=0) and (c_estatus='PAG') AND (ISNULL(csinretencion,0)=0) ";
                _Str_SQL += " and (TTRCDOCUMENTO.ccancelada=0) and (TGUIADESPACHOD.cfactura not in (select cfactura from TTRCPAGOD where (TTRCPAGOD.cidpago=" + _P_Str_Pago + "))))";
                _Str_SQL += " AND (ISNULL(TCLIENTE.cdelete,0)=0) ";

                if (_G_Bol_EsCasaMatriz)
                {
                    _Str_SQL += " AND ((TFACTURAM.ccliente=" + _P_Str_Cliente + ") OR ((TTRCDOCUMENTO.ccliente = '" + _P_Str_Cliente + "') OR ((TCLIENTE.c_casa_matriz ='" + _P_Str_Cliente + "') AND NOT EXISTS (SELECT TTRCPAGOM.ccliente FROM TTRCPAGOM WHERE CONVERT(VARCHAR,TTRCPAGOM.ccliente) = CONVERT(VARCHAR,TCLIENTE.ccliente)  AND TTRCPAGOM.ccompany = TTRCDOCUMENTO.ccompany AND TTRCPAGOM.cguia = TTRCDOCUMENTO.cguia))) AND (ISNULL(TCLIENTE.cdelete,0)=0)) ";
                }
                else
                {
                    _Str_SQL += " and (TFACTURAM.ccliente=" + _P_Str_Cliente + ") ";
                }

                _Str_SQL += " union";

                _Str_SQL += " select TGUIADESPACHOD.ccompany, TGUIADESPACHOD.cfactura, TFACTURAM.c_numerocontrol, convert(varchar, TFACTURAM.c_fecha_factura, 103) as c_fecha_factura, convert(varchar, TSALDOCLIENTED.cfechaentrega, 103) as cfechaentrega,";
                _Str_SQL += " 0.0 as cmontoapagar,";
                _Str_SQL += " 0.0 as cabono,";
                _Str_SQL += " TTRCDOCUMENTO.cmontodocumento as cmontototal, TTRCDOCUMENTO.cmontosaldo, TTRCPAGOD.cmontoabono as cmontopagadoporpago,";
                _Str_SQL += " TFACTURAM.c_montotot_si_bs AS cmontototalsinimpuesto, TFACTURAM.c_impuesto_bs AS cmontototalimpuesto,TFACTURAM.ccliente,(CONVERT(VARCHAR,TCLIENTE.ccliente) + ' - ' + TCLIENTE.c_nomb_comer) AS cNombreCliente ";

                _Str_SQL += " FROM TSALDOCLIENTED INNER JOIN TCONFIGCXC ON TSALDOCLIENTED.ctipodocument = TCONFIGCXC.ctipdocfact AND TSALDOCLIENTED.ccompany = TCONFIGCXC.ccompany INNER JOIN TGUIADESPACHOD INNER JOIN TFACTURAM ON TGUIADESPACHOD.cfactura = TFACTURAM.cfactura AND TGUIADESPACHOD.ccompany = TFACTURAM.ccompany AND TGUIADESPACHOD.cgroupcomp = TFACTURAM.cgroupcomp INNER JOIN TVENDEDOR ON TFACTURAM.cvendedor = TVENDEDOR.cvendedor AND TFACTURAM.ccompany = TVENDEDOR.ccompany ON TSALDOCLIENTED.cgroupcomp = TFACTURAM.cgroupcomp AND TSALDOCLIENTED.ccompany = TFACTURAM.ccompany AND TSALDOCLIENTED.cnumdocu = TFACTURAM.cfactura INNER JOIN TTRCDOCUMENTO ON TSALDOCLIENTED.ccompany = TTRCDOCUMENTO.ccompany AND TSALDOCLIENTED.ccliente = TTRCDOCUMENTO.ccliente AND TSALDOCLIENTED.cnumdocu = TTRCDOCUMENTO.cfactura INNER JOIN TTRCPAGOD ON TTRCDOCUMENTO.cfactura = TTRCPAGOD.cfactura INNER JOIN TCLIENTE ON TFACTURAM.cgroupcomp = TCLIENTE.cgroupcomp AND TFACTURAM.ccliente = TCLIENTE.ccliente ";

                _Str_SQL += " where ((TGUIADESPACHOD.ccompany='" + _P_Str_Compañia.Trim() + "') and (TGUIADESPACHOD.cguiadesp=" + _P_Str_Guia + ") and (TGUIADESPACHOD.c_fact_anul=0) and (c_estatus='PAG') AND (ISNULL(csinretencion,0)=0) ";
                _Str_SQL += " and (TTRCPAGOD.cidpago=" + _P_Str_Pago + ")) ";
                _Str_SQL += " AND (ISNULL(TCLIENTE.cdelete,0)=0) ";

                if (_G_Bol_EsCasaMatriz)
                {
                    _Str_SQL += " AND ((TFACTURAM.ccliente=" + _P_Str_Cliente + ") OR ((TTRCDOCUMENTO.ccliente = '" + _P_Str_Cliente + "') OR ((TCLIENTE.c_casa_matriz ='" + _P_Str_Cliente + "') AND NOT EXISTS (SELECT TTRCPAGOM.ccliente FROM TTRCPAGOM WHERE CONVERT(VARCHAR,TTRCPAGOM.ccliente) = CONVERT(VARCHAR,TCLIENTE.ccliente) AND TTRCPAGOM.ccompany = TTRCDOCUMENTO.ccompany AND TTRCPAGOM.cguia = TTRCDOCUMENTO.cguia) )) AND (ISNULL(TCLIENTE.cdelete,0)=0)) ";
                }
                else
                {
                    _Str_SQL += " and (TFACTURAM.ccliente=" + _P_Str_Cliente + ") ";
                }

            }
            var _Ds_Resultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            return _Ds_Resultados;
        }



        /// <summary>Este método permite cargar las facturas del cliente según la guía.</summary>
        /// <param name="_P_Str_Compañia">Código de la compañía.</param>
        /// <param name="_P_Str_Guia">Código de la guía de despacho.</param>
        /// <param name="_P_Str_Cliente">Código del cliente de la guía de despacho.</param>
        /// <param name="_P_Dg"></param>
        private void _Mtd_CargarMontoAPagarFacturas(string _P_Str_Compañia, string _P_Str_Guia, string _P_Str_Cliente, DataGridView _P_Dg, TiposEstadoPago _P_EstadoActualFormulario)
        {
            _Dtg_Facturas.Rows.Cast<DataGridViewRow>().ToList().ForEach(_Row =>
                {
                    //Obtenemos los valores
                    var _Str_cfactura = _Row.Cells["colNumeroFactura"].Value.ToString();
                    var _Dbl_MontoTotal = Convert.ToDouble(_Row.Cells["cmontototal"].Value);
                    var _Dbl_MontoSaldo = Convert.ToDouble(_Row.Cells["cmontosaldo"].Value);
                    var _Dbl_MontoAbonado = Convert.ToDouble(_Row.Cells["cmontopagadoporpago"].Value);
                    var _Dbl_MontoAPAgar = Convert.ToDouble(_Row.Cells["cmontoapagar"].Value);
                    var _Dbl_MontoRetencion = _Mtd_ObtenerMontoRetencion(_Str_cfactura);
                    var _Dbl_MontoNotasCredito = _Mtd_ObtenerMontoNotasCredito(_Str_cfactura);

                    switch (_P_EstadoActualFormulario)
                    {
                        case TiposEstadoPago.EstadoPagoNuevo:

                            //Calculamos
                            //Pasamos el resultado del calculo
                            _Row.Cells["cmontoapagar"].Value = _Dbl_MontoSaldo;
                            break;

                        case TiposEstadoPago.EstadoPagoEditar:
                            //Pasamos el resultado del calculo
                            _Row.Cells["cmontoapagar"].Value = _Dbl_MontoSaldo + _Dbl_MontoNotasCredito + _Dbl_MontoRetencion + _Dbl_MontoAbonado;
                            break;
                        case TiposEstadoPago.EstadoPagoConsultar:
                            //Pasamos el resultado del calculo
                            _Row.Cells["cmontoapagar"].Value = _Dbl_MontoAbonado;

                            break;
                        case TiposEstadoPago.EstadoInicial:
                            //Pasamos el resultado del calculo
                            _Row.Cells["cmontoapagar"].Value = 0;

                            break;
                    }

                });

        }

        /// <summary>Este método permite verificar si tiene retención la factura.</summary>
        /// <param name="_P_Str_Compañia"></param>
        /// <param name="_P_Str_Guia"></param>
        /// <param name="_P_Str_Factura">Código de la factura.</param>
        /// <param name="_P_Str_IdPago"></param>
        /// <returns>Verdadero si la factura ya tiene retención asignada.</returns>
        public static bool _Mtd_ExisteRetencionGuardada(string _P_Str_Compañia, string _P_Str_Guia, string _P_Str_Factura, string _P_Str_IdPago)
        {
            var _Bol_Existe = false;
            var _Str_SQL = "SELECT TTRCPAGOM.cidpago FROM TTRCPAGOM INNER JOIN TTRCRETENCION ON TTRCPAGOM.cidpago = TTRCRETENCION.cidpago " +
                           "WHERE (TTRCRETENCION.cdelete = 0) AND (TTRCPAGOM.ccompany='" + _P_Str_Compañia.Trim() + "') AND (TTRCPAGOM.cguia=" + _P_Str_Guia + ") AND (TTRCRETENCION.cfactura=" + _P_Str_Factura + ") ";
            if (_P_Str_IdPago != "") _Str_SQL += " AND (TTRCPAGOM.cidpago <> '" + _P_Str_IdPago + "')";
            var oResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (oResultado.Tables[0].Rows.Count > 0)
            {
                if (oResultado.Tables[0].Rows[0]["cidpago"].ToString() != "")
                {
                    _Bol_Existe = true;
                }
            }
            return _Bol_Existe;
        }


        /// <summary>Este método calcula el monto de la retención y lo asigna al control.</summary>
        /// <param name="_P_Str_Compañia">Código de la compañía para efecutar el filtro.</param>
        /// <param name="_P_Str_Factura">Código de la factura para efecutar el filtro.</param>
        private double _Mtd_ObtenerMontoRetencionCalculado(string _P_Str_Compañia, string _P_Str_Factura, string _P_Str_ccliente)
        {
            double _Dbl_MontoImpuesto = 0;
            double _Dbl_MontoPorcentaje = 0;
            double _Dbl_MontoMaximoImpuesto = 0;

            //Solo si el cliente es contribuyente
            var _Bol_ClienteContribuyente = _Mtd_ClienteEsContribuyenteEspecial(_P_Str_ccliente);

            //Valores
            _Dbl_MontoImpuesto = _Mtd_ObtenerImpuesto(_P_Str_Compañia, _P_Str_Factura);
            _Dbl_MontoPorcentaje = _Mtd_ObtenerPorcentajeRetencionImpuesto(_P_Str_Compañia);
            _Dbl_MontoMaximoImpuesto = _Dbl_MontoImpuesto*(_Dbl_MontoPorcentaje/100);

            //redondeos
            _Dbl_MontoMaximoImpuesto = Math.Round(_Dbl_MontoMaximoImpuesto, 2);

            //Si se dan estas dos condiciones
            var _Dbl_Resultado = 0.0;
            if (_Bol_ClienteContribuyente & (_Dbl_MontoImpuesto > 0))
            {
                _Dbl_Resultado = _Dbl_MontoMaximoImpuesto;
            }
            //devuelvo
            return _Dbl_Resultado;

        }

        /// <summary>Este método calcula el monto de las notas de credito asignadas a la factura</summary>
        /// <param name="_P_Str_Factura">Código de la factura para efecutar el filtro.</param>
        /// <param name="_P_Dg"></param>
        private double _Mtd_ObtenerMontoNotasCredito(string _P_Str_Factura)
        {
            double _Dbl_Monto = 0;

            //Notas de Credito
            _Dtg_NotasCreditos.Rows.Cast<DataGridViewRow>()
                              .Where(_Row => Convert.ToBoolean(_Row.Cells["colSeleccionarNC"].Value))
                              .ToList().ForEach(_Row =>
                                  {
                                      //solo si tiene la factura 
                                      if (_Row.Cells["colFacturaNC"].Value.ToString() == _P_Str_Factura) _Dbl_Monto += Convert.ToDouble(_Row.Cells["colMontoNC"].Value);
                                  });
            //devuelvo
            return _Dbl_Monto;

        }


        private double _Mtd_ObtenerMontoRetencion(string _P_Str_Factura)
        {
            double _Dbl_Monto = 0;

            //Retenciones
            _Dtg_Retenciones.Rows.Cast<DataGridViewRow>()
                            .ToList().ForEach(_Row =>
                                {
                                    if (_Row.Cells["colRetencionFactura"].Value.ToString() == _P_Str_Factura) _Dbl_Monto += Convert.ToDouble(_Row.Cells["colRetencionMonto"].Value);
                                });
            //devuelvo
            return _Dbl_Monto;
        }


        /// <summary>Este método permite obtener el impuesto de la factura para validar que no se sobrepase.</summary>
        /// <param name="_P_Str_Compañia">Código de la compañía para efecutar el filtro.</param>
        /// <param name="_P_Str_Factura">Código de la factura para efecutar el filtro.</param>
        /// <returns>Impuesto de la factura.</returns>
        public static double _Mtd_ObtenerImpuesto(string _P_Str_Compañia, string _P_Str_Factura)
        {
            double _Dbl_MontoImpuesto = 0;

            string sSQL = "select c_impuesto_bs from TFACTURAM where ((ccompany='" + _P_Str_Compañia.Trim() + "') and (cfactura=" + _P_Str_Factura + "));";

            DataSet oResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);

            if (oResultado.Tables[0].Rows.Count > 0)
            {
                if (oResultado.Tables[0].Rows[0]["c_impuesto_bs"].ToString() != "")
                {
                    _Dbl_MontoImpuesto = Convert.ToDouble(oResultado.Tables[0].Rows[0]["c_impuesto_bs"].ToString());
                }
            }

            return _Dbl_MontoImpuesto;
        }

        /// <summary>Este método permite obtener el porcentaje maximo de la retencion de impuesto.</summary>
        /// <param name="_P_Str_Compañia">Código de la compañía para efecutar el filtro.</param>
        public static double _Mtd_ObtenerPorcentajeRetencionImpuesto(string _P_Str_Compañia)
        {
            double _Dbl_Valor = 0;

            string sSQL = "select cporcentajeretencioncobranza from TCONFIGCXC where ccompany='" + _P_Str_Compañia.Trim() + "'";

            DataSet oResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);

            if (oResultado.Tables[0].Rows.Count > 0)
            {
                if (oResultado.Tables[0].Rows[0]["cporcentajeretencioncobranza"].ToString() != "")
                {
                    _Dbl_Valor = Convert.ToDouble(oResultado.Tables[0].Rows[0]["cporcentajeretencioncobranza"].ToString());
                }
            }
            return _Dbl_Valor;
        }


        /// <summary>Este método permite cargar las notas de crédito del cliente sin aplicar.</summary>
        /// <param name="_P_Str_Compañia">Código de la compañia.</param>
        /// <param name="_P_Str_Guia">Nñumero de la guia de despacho.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        private void _Mtd_CargarNotasCredito(string _P_Str_Compañia, string _P_Str_Guia, string _P_Str_Cliente)
        {
            string _Str_SQL = "";

            _Str_SQL = " select TNOTACREDICC.ccompany, cidnotcredicc, ctotaldocu, TCLIENTE.ccliente, (CONVERT(VARCHAR,TCLIENTE.ccliente) + ' - ' + TCLIENTE.c_nomb_comer) AS cNombreCliente ";
            _Str_SQL += " from TNOTACREDICC INNER JOIN TCLIENTE ON TNOTACREDICC.cgroupcomp = TCLIENTE.cgroupcomp AND TNOTACREDICC.ccliente = TCLIENTE.ccliente ";
            _Str_SQL +=  " where ";

            if ((_G_Estado_Formulario == TiposEstadoPago.EstadoPagoNuevo))
            {
                _Str_SQL += " cidnotcredicc not in ";
                _Str_SQL += " (select TTRCNOTACREDD.cnotacredito ";
                _Str_SQL += " from TTRCNOTACREDD inner join TTRCPAGOD on TTRCNOTACREDD.cidpago = TTRCPAGOD.cidpago and TTRCNOTACREDD.cfactura = TTRCPAGOD.cfactura inner join TTRCPAGOM on TTRCPAGOD.cidpago = TTRCPAGOM.cidpago inner join TTRCDOCUMENTO ON TTRCPAGOM.ccompany = TTRCDOCUMENTO.ccompany and TTRCPAGOM.cguia = TTRCDOCUMENTO.cguia and TTRCPAGOD.cfactura = TTRCDOCUMENTO.cfactura ";
                _Str_SQL += " where (TTRCDOCUMENTO.ccompany='" + _P_Str_Compañia.Trim() + "') and (TTRCDOCUMENTO.cguia = " + _P_Str_Guia + ")) ";
                _Str_SQL += " and (TNOTACREDICC.ccompany = '" + _P_Str_Compañia.Trim() + "')  and (TNOTACREDICC.cdescontada=0) and (TNOTACREDICC.canulado=0) and (TNOTACREDICC.cactivo=1) ";
                if (_G_Bol_EsCasaMatriz)
                {
                    _Str_SQL += " AND ((TNOTACREDICC.ccliente=" + _P_Str_Cliente + ") OR (TCLIENTE.c_casa_matriz='" + _P_Str_Cliente + "'))";
                }
                else
                {
                    _Str_SQL += " AND (TNOTACREDICC.ccliente=" + _P_Str_Cliente + ") ";
                }
                _Str_SQL += " order by cidnotcredicc ";
            }
            else if (_G_Estado_Formulario == TiposEstadoPago.EstadoPagoEditar)
            {
                _Str_SQL += " cidnotcredicc in ";
                _Str_SQL += " (select TTRCNOTACREDD.cnotacredito ";
                _Str_SQL += " from TTRCNOTACREDD inner join TTRCPAGOD on TTRCNOTACREDD.cidpago = TTRCPAGOD.cidpago and TTRCNOTACREDD.cfactura = TTRCPAGOD.cfactura inner join TTRCPAGOM on TTRCPAGOD.cidpago = TTRCPAGOM.cidpago inner join TTRCDOCUMENTO ON TTRCPAGOM.ccompany = TTRCDOCUMENTO.ccompany and TTRCPAGOM.cguia = TTRCDOCUMENTO.cguia and TTRCPAGOD.cfactura = TTRCDOCUMENTO.cfactura ";
                _Str_SQL += " where (TTRCDOCUMENTO.ccompany='" + _P_Str_Compañia.Trim() + "') and (TTRCDOCUMENTO.cguia = " + _P_Str_Guia + ") and (TTRCPAGOM.cidpago = '" + _Txt_IdDocumento.Text + "')) ";
                _Str_SQL += " and (TNOTACREDICC.ccompany = '" + _P_Str_Compañia.Trim() + "')  and (TNOTACREDICC.cdescontada=0) and (TNOTACREDICC.canulado=0) and (TNOTACREDICC.cactivo=1) ";
                if (_G_Bol_EsCasaMatriz)
                {
                    _Str_SQL += " AND ((TNOTACREDICC.ccliente=" + _P_Str_Cliente + ") OR (TCLIENTE.c_casa_matriz='" + _P_Str_Cliente + "'))";
                }
                else
                {
                    _Str_SQL += " AND (TNOTACREDICC.ccliente=" + _P_Str_Cliente + ") ";
                }

                _Str_SQL += " union ";

                _Str_SQL += " select TNOTACREDICC.ccompany, cidnotcredicc, ctotaldocu, TCLIENTE.ccliente, (CONVERT(VARCHAR,TCLIENTE.ccliente) + ' - ' + TCLIENTE.c_nomb_comer) AS cNombreCliente ";
                _Str_SQL += " from TNOTACREDICC INNER JOIN TCLIENTE ON TNOTACREDICC.cgroupcomp = TCLIENTE.cgroupcomp AND TNOTACREDICC.ccliente = TCLIENTE.ccliente ";
                _Str_SQL += " where ";
                _Str_SQL += " and cidnotcredicc NOT in ";
                _Str_SQL += " (select TTRCNOTACREDD.cnotacredito ";
                _Str_SQL += " from TTRCNOTACREDD inner join TTRCPAGOD on TTRCNOTACREDD.cidpago = TTRCPAGOD.cidpago and TTRCNOTACREDD.cfactura = TTRCPAGOD.cfactura inner join TTRCPAGOM on TTRCPAGOD.cidpago = TTRCPAGOM.cidpago inner join TTRCDOCUMENTO ON TTRCPAGOM.ccompany = TTRCDOCUMENTO.ccompany and TTRCPAGOM.cguia = TTRCDOCUMENTO.cguia and TTRCPAGOD.cfactura = TTRCDOCUMENTO.cfactura ";
                _Str_SQL += " where (TTRCDOCUMENTO.ccompany='" + _P_Str_Compañia.Trim() + "') and (TTRCDOCUMENTO.ccliente=" + _P_Str_Cliente + ") and (TTRCDOCUMENTO.cguia = " + _P_Str_Guia + "))";
                _Str_SQL += " and  (TNOTACREDICC.ccompany = '" + _P_Str_Compañia.Trim() + "') and (TNOTACREDICC.cdescontada=0) and (TNOTACREDICC.canulado=0) and (TNOTACREDICC.cactivo=1)";
                if (_G_Bol_EsCasaMatriz)
                {
                    _Str_SQL += " AND ((TNOTACREDICC.ccliente=" + _P_Str_Cliente + ") OR (TCLIENTE.c_casa_matriz='" + _P_Str_Cliente + "'))";
                }
                else
                {
                    _Str_SQL += " AND (TNOTACREDICC.ccliente=" + _P_Str_Cliente + ") ";
                }
            }
            else if (_G_Estado_Formulario == TiposEstadoPago.EstadoPagoConsultar)
            {
                _Str_SQL += " cidnotcredicc in ";
                _Str_SQL +=  "(select TTRCNOTACREDD.cnotacredito ";
                _Str_SQL += " from TTRCNOTACREDD inner join TTRCPAGOD on TTRCNOTACREDD.cidpago = TTRCPAGOD.cidpago and TTRCNOTACREDD.cfactura = TTRCPAGOD.cfactura inner join TTRCPAGOM on TTRCPAGOD.cidpago = TTRCPAGOM.cidpago inner join TTRCDOCUMENTO ON TTRCPAGOM.ccompany = TTRCDOCUMENTO.ccompany and TTRCPAGOM.cguia = TTRCDOCUMENTO.cguia and TTRCPAGOD.cfactura = TTRCDOCUMENTO.cfactura ";
                _Str_SQL += " where (TTRCDOCUMENTO.ccompany='" + _P_Str_Compañia.Trim() + "')  and (TTRCDOCUMENTO.cguia = " + _P_Str_Guia + ") and (TTRCPAGOM.cidpago = '" + _Txt_IdDocumento.Text + "')) ";
                _Str_SQL += " and (TNOTACREDICC.ccompany = '" + _P_Str_Compañia.Trim() + "')  and (TNOTACREDICC.cdescontada=0) and (TNOTACREDICC.canulado=0) and (TNOTACREDICC.cactivo=1) ";
                if (_G_Bol_EsCasaMatriz)
                {
                    _Str_SQL += " AND ((TNOTACREDICC.ccliente=" + _P_Str_Cliente + ") OR (TCLIENTE.c_casa_matriz='" + _P_Str_Cliente + "'))";
                }
                else
                {
                    _Str_SQL += " AND (TNOTACREDICC.ccliente=" + _P_Str_Cliente + ") ";
                }

                _Str_SQL += " union ";

                _Str_SQL += " select TNOTACREDICC.ccompany, cidnotcredicc, ctotaldocu, TCLIENTE.ccliente, (CONVERT(VARCHAR,TCLIENTE.ccliente) + ' - ' + TCLIENTE.c_nomb_comer) AS cNombreCliente ";
                _Str_SQL += " from TNOTACREDICC INNER JOIN TCLIENTE ON TNOTACREDICC.cgroupcomp = TCLIENTE.cgroupcomp AND TNOTACREDICC.ccliente = TCLIENTE.ccliente ";
                _Str_SQL += " where ";
                _Str_SQL += " cidnotcredicc NOT in ";
                _Str_SQL += " (select TTRCNOTACREDD.cnotacredito ";
                _Str_SQL += " from TTRCNOTACREDD inner join TTRCPAGOD on TTRCNOTACREDD.cidpago = TTRCPAGOD.cidpago and TTRCNOTACREDD.cfactura = TTRCPAGOD.cfactura inner join TTRCPAGOM on TTRCPAGOD.cidpago = TTRCPAGOM.cidpago inner join TTRCDOCUMENTO ON TTRCPAGOM.ccompany = TTRCDOCUMENTO.ccompany and TTRCPAGOM.cguia = TTRCDOCUMENTO.cguia and TTRCPAGOD.cfactura = TTRCDOCUMENTO.cfactura ";
                _Str_SQL += " where (TTRCDOCUMENTO.ccompany='" + _P_Str_Compañia.Trim() + "') and (TTRCDOCUMENTO.ccliente=" + _P_Str_Cliente + ") and (TTRCDOCUMENTO.cguia = " + _P_Str_Guia + "))";
                _Str_SQL += " and (TNOTACREDICC.ccompany = '" + _P_Str_Compañia.Trim() + "') and (TNOTACREDICC.cdescontada=0) and (TNOTACREDICC.canulado=0) and (TNOTACREDICC.cactivo=1) ";
                if (_G_Bol_EsCasaMatriz)
                {
                    _Str_SQL += " AND ((TNOTACREDICC.ccliente=" + _P_Str_Cliente + ") OR (TCLIENTE.c_casa_matriz='" + _P_Str_Cliente + "'))";
                }
                else
                {
                    _Str_SQL += " AND (TNOTACREDICC.ccliente=" + _P_Str_Cliente + ") ";
                }
            
            }
            else
            {
                _Str_SQL += " (TNOTACREDICC.ccompany = '" + _P_Str_Compañia.Trim() + "') and (TNOTACREDICC.ccliente=" + _P_Str_Cliente + ") and (TNOTACREDICC.cdescontada=0) and (TNOTACREDICC.canulado=0) and (TNOTACREDICC.cactivo=1) order by cidnotcredicc;";
            }

            DataSet dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            _Dtg_NotasCreditos.DataSource = dsResultados.Tables[0];
        }

        /// <summary>Este método permite cargar las retenciones aplicadas a las facturas del clietne.</summary>
        /// <param name="_P_Str_Compañia">Código de la compañía.</param>
        /// <param name="_P_Str_Guia">Número de la guía de despacho.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        /// <param name="_P_Str_IdPago">Identificador del pago o código del pago.</param>
        private void _Mtd_CargarRetenciones(string _P_Str_Compañia, string _P_Str_Guia, string _P_Str_Cliente, string _P_Str_IdPago)
        {
            string _Str_SQL;

            _Str_SQL = "select cnumretencion, TTRCPAGOD.cfactura, TTRCRETENCION.cmonto, TTRCRETENCION.cfechaemision, '' as cnumerocontrol from TTRCPAGOM";
            _Str_SQL += " inner join TTRCPAGOD on TTRCPAGOM.cidpago = TTRCPAGOD.cidpago";
            _Str_SQL += " inner join TTRCRETENCION on TTRCPAGOD.cidpago = TTRCRETENCION.cidpago and TTRCPAGOD.ciddetalle = TTRCRETENCION.ciddetalle";
            _Str_SQL += " where ((ccompany='" + _P_Str_Compañia.Trim() + "') and (cguia=" + _P_Str_Guia + ") and (ccliente=" + _P_Str_Cliente + ") and (TTRCPAGOM.cidpago=" + _P_Str_IdPago + "));";

            DataSet dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            _Dtg_Retenciones.DataSource = dsResultados.Tables[0];
        }

        private int _Mtd_ObtenerCantidadFacturasSinRetencion(DataGridView _P_Dgt_Facturas, DataGridView _P_Dgt_Retenciones)
        {
            int _Int_Contador = 0;
            _P_Dgt_Facturas.Rows.Cast<DataGridViewRow>()
                           .Where(_Row => Convert.ToBoolean(_Row.Cells["colSeleccionarFactura"].Value) && (Convert.ToDouble(_Row.Cells["cmontototalimpuesto"].Value) > 0))
                           .ToList().ForEach(x =>
                               {
                                   var _Str_Cfactura = x.Cells["colNumeroFactura"].Value.ToString();
                                   var _Str_ccliente = x.Cells["colClienteFactura"].Value.ToString();

                                   //Si esta en el grid
                                   var _Bol_ExisteEngrid = _P_Dgt_Retenciones.Rows.Cast<DataGridViewRow>().Any(y => y.Cells["colRetencionFactura"].Value.ToString() == _Str_Cfactura);
                                   var _Bol_ExisteEnBd = _Mtd_ExisteRetencionSegunFacturaEnBaseDeDatos(_G_Enum_Pago.Compañia, _G_Enum_Pago.Guia, _Str_ccliente, _Str_Cfactura, _Txt_IdDocumento.Text);

                                   if (!_Bol_ExisteEngrid & !_Bol_ExisteEnBd)
                                   {
                                       _Int_Contador++;
                                   }
                               });
            return _Int_Contador;
        }

        /// <summary>Este método permite marcar las facturas en el grid.</summary>
        /// <param name="_P_Str_IdPago">Identificador o código del pago.</param>
        private void _Mtd_MarcarFacturas(string _P_Str_IdPago)
        {
            string _Str_SQL;

            _Str_SQL = "select cfactura from TTRCPAGOD where (cidpago=" + _P_Str_IdPago + ");";

            DataSet dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsResultados.Tables[0].Rows.Count > 0)
            {
                foreach (DataGridViewRow oFila in _Dtg_Facturas.Rows)
                {
                    DataGridViewCheckBoxCell oCeldaSeleccion = (DataGridViewCheckBoxCell) oFila.Cells[0];

                    oCeldaSeleccion.Value = false;
                }

                foreach (DataRow oFila in dsResultados.Tables[0].Rows)
                {
                    foreach (DataGridViewRow oFactura in _Dtg_Facturas.Rows)
                    {
                        if (oFactura.Cells[2].Value.ToString() == oFila[0].ToString())
                        {
                            DataGridViewCheckBoxCell oCeldaSeleccion = (DataGridViewCheckBoxCell) oFactura.Cells[0];

                            oCeldaSeleccion.Value = true;
                        }
                    }
                }
            }
        }

        /// <summary>Este método permite marcar las notas de crédito en el grid.</summary>
        /// <param name="_P_Str_Compañia">Código de la compañía.</param>
        /// <param name="_P_Str_Guia">Número de la guía de despacho.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        /// <param name="_P_Str_cidpago"></param>
        private void _Mtd_MarcarNotasCredito(string _P_Str_Compañia, string _P_Str_Guia, string _P_Str_Cliente, string _P_Str_cidpago)
        {
            string _Str_SQL;

            _Str_SQL = "select cnotacredito, TTRCPAGOD.cfactura from TTRCPAGOD";
            _Str_SQL += " inner join TTRCPAGOM on TTRCPAGOD.cidpago = TTRCPAGOM.cidpago";
            _Str_SQL += " inner join TTRCNOTACREDD on TTRCPAGOD.cidpago = TTRCNOTACREDD.cidpago and TTRCPAGOD.cfactura = TTRCNOTACREDD.cfactura";
            _Str_SQL += " where ((ccompany='" + _P_Str_Compañia.Trim() + "') and (cguia=" + _P_Str_Guia + ") and (ccliente=" + _P_Str_Cliente + ") AND (TTRCPAGOM.cidpago = '" + _P_Str_cidpago + "'));";

            DataSet dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            //Desmarcamos todas las notas de credito
            foreach (DataGridViewRow oNota in _Dtg_NotasCreditos.Rows)
            {
                var oCeldaSeleccion = (DataGridViewCheckBoxCell) oNota.Cells[0];
                oCeldaSeleccion.Value = false;
            }

            if (dsResultados.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow oFila in dsResultados.Tables[0].Rows)
                {
                    foreach (DataGridViewRow oNota in _Dtg_NotasCreditos.Rows)
                    {
                        if (oNota.Cells["colNumeroNC"].Value.ToString() == oFila["cnotacredito"].ToString())
                        {
                            var oCeldaSeleccion = (DataGridViewCheckBoxCell) oNota.Cells["colSeleccionarNC"];
                            var oComboFactura = (DataGridViewComboBoxCell) oNota.Cells["colFacturaNC"];
                            //Seleccionamos
                            oCeldaSeleccion.Value = true;
                            //Agregamos la factura al combo
                            oComboFactura.DataSource = _Mtd_AgregarComboFacturasAgregar(oFila["cfactura"].ToString());
                            //Seleccionamos la factura
                            oComboFactura.Value = oFila["cfactura"].ToString();
                        }
                    }
                }
            }
        }

        /// <summary>Este método permite guardar el pago en las tablas temporales.</summary>
        private void _Mtd_GuardarPago()
        {
            string _Str_IdPago;
            string _Str_IdDetalle;
            string _Str_SQL;

            /*
             * Este bloque hace lo siguiente:
             * 
             *  - Si el estado del formulario es nuevo, entonces se crea un nuevo encabezado con la función _Mtd_GuardarDocumento.
             *  - En caso contrario, se toma el id del pago de la tabla TTRCPAGOM.
             */

            if (_G_Estado_Formulario == TiposEstadoPago.EstadoPagoNuevo)
            {
                _Str_IdPago = _Mtd_GuardarDocumento
                    (
                        _Cmb_Compañia.SelectedValue.ToString(),
                        _G_Enum_Pago.Guia,
                        _G_Enum_Pago.Cliente,
                        _Txt_NumeroDocumento.Text.Trim(),
                        _Cmb_BancosDocumento.SelectedValue.ToString(),
                        _Dtp_FechaEmision.Value,
                        _Dtp_FechaDepositar.Value,
                        Convert.ToDouble(_Txt_MontoDocumento.Tag.ToString())
                    );
            }
            else
            {
                _Str_IdPago = _Txt_IdDocumento.Text;


                //Si es depósito, obtemos la parte del udpate de cuenta bancariaq
                var _Str_CuentaBancaria = "";
                if (!_G_Enum_Pago.ConCheque)
                {
                    DataRowView dsBanco = (DataRowView) _Cmb_BancosDocumento.SelectedItem;
                    var _Str_Datos = dsBanco[1].ToString().Split(':');
                    _Str_CuentaBancaria = ",ccuentabancaria = '" + _Str_Datos[1].Trim() + "' ";
                }

                _Str_SQL = "update TTRCPAGOM " +
                           "set " +

                           "cnumerodoc='" + _Txt_NumeroDocumento.Text.Trim() + "' " +
                           ",cbanco=" + _Cmb_BancosDocumento.SelectedValue.ToString() + " " +
                           _Str_CuentaBancaria +
                           ",cfechaemision=convert(datetime, '" + _Dtp_FechaEmision.Value.ToShortDateString() + "', 103) " +
                           ",cfechadeposito=convert(datetime, '" + _Dtp_FechaDepositar.Value.ToShortDateString() + "', 103) " +
                           ",cmontototal=" + _Txt_MontoDocumento.Tag.ToString().Replace(",", ".") + " " +
                           ", cdateupd=getdate() " +
                           ", cuserupd='" + Frm_Padre._Str_Use + "' " + 
                           "where (cidpago=" + _Str_IdPago + ") and (ccompany='" + _G_Enum_Pago.Compañia.Trim() + "') and (cguia=" + _G_Enum_Pago.Guia + ") and (ccliente=" + _G_Enum_Pago.Cliente + ");";

                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
            }
            //Paso el codigo a la global
            _G_Str_cidpago = _Str_IdPago;

            /*
             * Este bloque hace lo siguiente:
             * 
             *  - Recorremos el grid de facturas y guardamos cada factura en TTRCPAGOD.
             *  - Recorremos el grid de notas y guardamos cada nota en TTRCNOTACREDD.
             *  - Recorremos el grid de retenciones y guardamos cada retención en TTRCRETENCION.
             */

            var _Dbl_MontoSaldoFactura = 0.0;
            var _Dbl_MontoNc = 0.0;
            var _Dbl_MontoRetencion = 0.0;
            var _Dbl_MontoSaldoPago = 0.0;
            var _Dbl_MontoAPagar = 0.0;

            _Dbl_MontoSaldoPago = (((_Txt_MontoDocumento.Tag == null) || (_Txt_MontoDocumento.Tag == "")) ? 0 : Convert.ToDouble(_Txt_MontoDocumento.Tag.ToString()));

            foreach (DataGridViewRow oFactura in _Dtg_Facturas.Rows)
            {
                if ((oFactura.Cells[0].Value != null) && ((bool) oFactura.Cells[0].Value))
                {
                    var _Str_cfactura = oFactura.Cells["colNumeroFactura"].Value.ToString();

                    //Obtenemos los datos del documento
                    _Dbl_MontoSaldoFactura = Convert.ToDouble(oFactura.Cells["cmontoapagar"].Value.ToString());
                    _Dbl_MontoNc = _Mtd_ObtenerMontoNotasCredito(_Str_cfactura);
                    _Dbl_MontoRetencion = _Mtd_ObtenerMontoRetencion(_Str_cfactura);

                    //Obtenemos los datos del documento
                    _Dbl_MontoSaldoFactura = _Dbl_MontoSaldoFactura - _Dbl_MontoNc - _Dbl_MontoRetencion;

                    //Redondeamos
                    _Dbl_MontoSaldoPago = Math.Round(_Dbl_MontoSaldoPago, 2);
                    _Dbl_MontoSaldoFactura = Math.Round(_Dbl_MontoSaldoFactura, 2);

                    if (_Dbl_MontoSaldoFactura <= _Dbl_MontoSaldoPago) 
                        _Dbl_MontoAPagar = _Dbl_MontoSaldoFactura;
                    else 
                        _Dbl_MontoAPagar = _Dbl_MontoSaldoPago;

                    //Descontamos del pago
                    _Dbl_MontoSaldoPago -= _Dbl_MontoAPagar;

                    //solo si, tiene o NC o  algun pago
                    if ((_Dbl_MontoNc > 0) || (_Dbl_MontoAPagar > 0))
                    {
                        _Str_IdDetalle = _Mtd_GuardarFactura
                            (
                                _Str_IdPago,
                                oFactura.Cells["colNumeroFactura"].Value.ToString(),
                                oFactura.Cells["colNumeroControl"].Value.ToString(),
                                Convert.ToDateTime(oFactura.Cells["colFechaEmisionFactura"].Value.ToString()),
                                Convert.ToDateTime(oFactura.Cells["colFechaEntregaFactura"].Value.ToString()),
                                _Dbl_MontoAPagar
                            );
                    }

                    foreach (DataGridViewRow oNota in _Dtg_NotasCreditos.Rows)
                    {
                        if ((oNota.Cells[0].Value != null) && ((bool) oNota.Cells[0].Value) && (oNota.Cells[1].Value != null))
                        {
                            if (!_Mtd_ExisteNotaCredito(_Str_IdPago, oNota.Cells[3].Value.ToString()))
                            {
                                _Mtd_GuardarNotaCredito
                                    (
                                        _Str_IdPago,
                                        oNota.Cells[3].Value.ToString(),
                                        oNota.Cells[1].Value.ToString(),
                                        Convert.ToDouble(oNota.Cells[4].Value.ToString())
                                    );
                            }
                        }
                    }

                    foreach (DataGridViewRow oRetencion in _Dtg_Retenciones.Rows)
                    {
                        if (oRetencion.Cells["colRetencionFactura"].Value.ToString() == oFactura.Cells["colNumeroFactura"].Value.ToString())
                        {
                            _Mtd_GuardarRetencion
                                (
                                    _Str_IdPago,
                                    oRetencion.Cells["colRetencionFactura"].Value.ToString(),
                                    oRetencion.Cells["colRetencion"].Value.ToString(),
                                    Convert.ToDateTime(oRetencion.Cells["colRetencionFecha"].Value.ToString()),
                                    Convert.ToDouble(oRetencion.Cells["colRetencionMonto"].Value.ToString())
                                );
                        }
                    }
                }
            }
        }

        /// <summary>Este método permite crea un nuevo encabezado en TTRCPAGOM.</summary>
        /// <param name="_P_Str_Compañia">Código de la compañía.</param>
        /// <param name="_P_Str_Guia">Número de la guía de despacho.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        /// <param name="_P_Str_Numero">Número del pago.</param>
        /// <param name="_P_Str_Banco">Código del banco.</param>
        /// <param name="_P_Dat_FechaEmision">Fecha de emisión.</param>
        /// <param name="_P_Dat_FechaDepositar">Fecha de depósito.</param>
        /// <param name="_P_Dbl_MontoTotal">Monto total del pago.</param>
        /// <returns>Identificador interno o código del pago.</returns>
        private string _Mtd_GuardarDocumento(string _P_Str_Compañia,
                                             string _P_Str_Guia,
                                             string _P_Str_Cliente,
                                             string _P_Str_Numero,
                                             string _P_Str_Banco,
                                             DateTime _P_Dat_FechaEmision,
                                             DateTime _P_Dat_FechaDepositar,
                                             double _P_Dbl_MontoTotal)
        {
            string _Str_SQL;
            string _Str_IdPago = "";
            string[] _Str_CuentaBancaria = null;

            DataSet dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select isnull((max(cidpago) + 1), 1) as cidpago from TTRCPAGOM;");

            if (dsResultados.Tables[0].Rows.Count > 0)
            {
                _Str_IdPago = dsResultados.Tables[0].Rows[0]["cidpago"].ToString();

                if (!_G_Enum_Pago.ConCheque)
                {
                    DataRowView dsBanco = (DataRowView) _Cmb_BancosDocumento.SelectedItem;

                    _Str_CuentaBancaria = dsBanco[1].ToString().Split(':');
                }

                _Str_SQL = "insert into TTRCPAGOM (cidpago, ccompany, cguia, ccliente, cnumerodoc, ctipodoc, cbanco," + ((_G_Enum_Pago.ConCheque) ? "" : " ccuentabancaria,") +
                           " cfechaemision, cfechadeposito, cmontototal, cdateadd, cuseradd, cdelete)";
                _Str_SQL += " values (" + _Str_IdPago + ", '" + _P_Str_Compañia.Trim() + "', " + _P_Str_Guia + ", " + _P_Str_Cliente + ", '" + _P_Str_Numero + "', '" + ((_G_Enum_Pago.ConCheque) ? "C" : "D") +
                            "', '" + _P_Str_Banco.Trim() + "'," + ((_G_Enum_Pago.ConCheque) ? "" : " '" + _Str_CuentaBancaria[1].Trim() + "',") + " convert(datetime, '" + _P_Dat_FechaEmision.ToShortDateString() +
                            "', 103), convert(datetime, '" + _P_Dat_FechaDepositar.ToShortDateString() + "', 103), " + _P_Dbl_MontoTotal.ToString().Replace(",", ".") + ", getdate(), '" + Frm_Padre._Str_Use +
                            "', 0);";

                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
            }

            return _Str_IdPago;
        }

        /// <summary>Este método guarda las facturas seleccionadas en la tabla temporal TTRCPAGOD.</summary>
        /// <param name="_P_Str_IdPago">Identificador interno o código del pago.</param>
        /// <param name="_P_Str_Factura">Código de la factura.</param>
        /// <param name="_P_Str_NumeroControl">Número de control de la factura.</param>
        /// <param name="_P_Dat_FechaEmision">Fecha de emisión de la factura.</param>
        /// <param name="_P_Dat_FechaEntrega">Fecha de entrega de la factura.</param>
        /// <param name="_P_Dbl_MontoAbono">Monto del abono de la factura.</param>
        /// <returns>Identificador interno o código de la factura.</returns>
        private string _Mtd_GuardarFactura(string _P_Str_IdPago, string _P_Str_Factura, string _P_Str_NumeroControl, DateTime _P_Dat_FechaEmision, DateTime _P_Dat_FechaEntrega, double _P_Dbl_MontoAbono)
        {
            string _Str_SQL;
            string _Str_IdDetalle = "";

            _Str_SQL = "select isnull((max(ciddetalle) + 1), 1) as ciddetalle from TTRCPAGOD where (cidpago='" + _P_Str_IdPago + "');";

            DataSet dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsResultados.Tables[0].Rows.Count > 0)
            {
                _Str_IdDetalle = dsResultados.Tables[0].Rows[0]["ciddetalle"].ToString();

                _Str_SQL = "insert into TTRCPAGOD (cidpago, ciddetalle, cfactura, cnumerocontrol, cfechaemision, cfechaentrega, cmontoabono, cdateadd, cuseradd, cdelete)";
                _Str_SQL += " values (" + _P_Str_IdPago + ", " + _Str_IdDetalle + ", " + _P_Str_Factura + ", " + _P_Str_NumeroControl + ", convert(datetime, '" + _P_Dat_FechaEmision.ToShortDateString() +
                            "', 103), convert(datetime, '" + _P_Dat_FechaEntrega.ToShortDateString() + "', 103), " + _P_Dbl_MontoAbono.ToString().Replace(",", ".") + ", getdate(), '" + Frm_Padre._Str_Use +
                            "', 0);";

                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
            }

            return _Str_IdDetalle;
        }

        /// <summary>Este método guarda las notas de crédito seleccionadas en la tabla temporal TTRCNOTACREDD.</summary>
        /// <param name="_P_Str_IdPago">Identificador interno o código del pago.</param>
        /// <param name="_P_Str_NotaCredito">Número de la nota de cr´dito.</param>
        /// <param name="_P_Str_Factura">Número de la factura.</param>
        /// <param name="_P_Dbl_Monto">Monto de la nota de crédito.</param>
        private void _Mtd_GuardarNotaCredito(string _P_Str_IdPago, string _P_Str_NotaCredito, string _P_Str_Factura, double _P_Dbl_Monto)
        {
            string _Str_SQL;
            string _Str_IdDetalle;

            _Str_SQL = "select isnull((max(ciddetalle) + 1), 1) as ciddetalle from TTRCNOTACREDD where (cidpago='" + _P_Str_IdPago + "');";

            DataSet dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsResultados.Tables[0].Rows.Count > 0)
            {
                _Str_IdDetalle = dsResultados.Tables[0].Rows[0]["ciddetalle"].ToString();

                _Str_SQL = "insert into TTRCNOTACREDD (cidpago, ciddetalle, cfactura, cnotacredito, cmonto, cdateadd, cuseradd, cdelete)";
                _Str_SQL += " values (" + _P_Str_IdPago + ", " + _Str_IdDetalle + ", " + _P_Str_Factura + ", " + _P_Str_NotaCredito + ", " + _P_Dbl_Monto.ToString().Replace(",", ".") + ", getdate(), '" +
                            Frm_Padre._Str_Use + "', 0);";

                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
            }
        }

        /// <summary>Este método guarda la retención en la tabla temporal TTRCRETENCION.</summary>
        /// <param name="_P_Str_IdPago">Identificador interno o código del pago.</param>
        /// <param name="_P_Str_Factura">Número de la factura.</param>
        /// <param name="_P_Str_NumeroRetencion">Número de la retención.</param>
        /// <param name="_P_Dat_FechaEmision">Fecha de emisión de la retención.</param>
        /// <param name="_P_Dbl_Monto">Monto de la retención.</param>
        private void _Mtd_GuardarRetencion(string _P_Str_IdPago, string _P_Str_Factura, string _P_Str_NumeroRetencion, DateTime _P_Dat_FechaEmision, double _P_Dbl_Monto)
        {
            string _Str_SQL;
            string _Str_IdDetalle;

            _Str_SQL = "select isnull((max(ciddetalle) + 1), 1) as ciddetalle from TTRCRETENCION where (cidpago='" + _P_Str_IdPago + "');";

            DataSet dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsResultados.Tables[0].Rows.Count > 0)
            {
                _Str_IdDetalle = dsResultados.Tables[0].Rows[0]["ciddetalle"].ToString();

                _Str_SQL = "insert into TTRCRETENCION (cidpago, ciddetalle, cfactura, cnumretencion, cfechaemision, cmonto, cdateadd, cuseradd, cdelete)";
                _Str_SQL += " values (" + _P_Str_IdPago + ", " + _Str_IdDetalle + ", " + _P_Str_Factura + ", '" + _P_Str_NumeroRetencion + "', convert(datetime, '" + _P_Dat_FechaEmision.ToShortDateString() +
                            "', 103), " + _P_Dbl_Monto.ToString().Replace(",", ".") + ", getdate(), '" + Frm_Padre._Str_Use + "', 0);";

                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
            }
        }

        /// <summary>Este método permite verificar si el cliente retiene impuesto.</summary>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        /// <returns>Verdadero si es un cliente que retiene impuesto.</returns>
        public static bool _Mtd_ClienteEsContribuyenteEspecial(string _P_Str_Cliente)
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

        private bool _Mtd_ExistenFacturasQueRequierenRetencion(DataGridView _P_Dg)
        {
            //Si existe algun documento seleccionado que tenga impuesto
            var _Bol_ExisteFacturasParaRetencion = _P_Dg.Rows.Cast<DataGridViewRow>()
                                                         .Where(x => Convert.ToBoolean(x.Cells[0].Value))
                                                         .Where(x => Convert.ToDouble(x.Cells["cmontototalimpuesto"].Value) > 0)
                                                         .Any(x => _Mtd_ClienteEsContribuyenteEspecial(x.Cells["colClienteFactura"].Value.ToString()));
            return _Bol_ExisteFacturasParaRetencion;
        }


        /// <summary>Este método permite verificar si existe un documento sea un cheque o un depósito.</summary>
        /// <param name="_P_Str_Compañia">Código de la compañía.</param>
        /// <param name="_P_Str_Guia">Número de la guía de despacho.</param>
        /// <param name="_P_Str_Cliente">Código del cliente.</param>
        /// <param name="_P_Str_Numero">Número del documento.</param>
        /// <param name="_P_Str_Banco">Código del banco.</param>
        /// <returns>Verdadero si existe un documento en la tabla TTRCPAGOM.</returns>
        private bool _Mtd_ExisteDocumento(string _P_Str_Compañia, string _P_Str_Guia, string _P_Str_Cliente, string _P_Str_Numero, string _P_Str_Banco, string _P_Str_IdPago)
        {
            var _Str_SQL = "";

            //Si pasamos el id del pago obtenemos el número de relacion
            var _Str_cidrelacobro = "";
            if (_P_Str_IdPago != "")
            {
                //Obtenemos la relacion de la guia
                _Str_SQL = "select cidrelacobro from trelaccobm where (ccompany='" + _P_Str_Compañia.Trim() + "') and (cguiacobro = '" + _P_Str_Guia + "')";
                var dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (dsResultados.Tables[0].Rows.Count > 0)
                {
                    _Str_cidrelacobro = dsResultados.Tables[0].Rows[0][0].ToString();
                }
            }


            if (_G_Enum_Pago.ConCheque) //CHEQUE
            {
                //Verificamos si existe en las temporales
                var _Bol_ExisteEnTemporales = false;
                _Str_SQL = "select cidpago from TTRCPAGOM where (ccompany='" + _P_Str_Compañia.Trim() + "') and (ccliente=" + _P_Str_Cliente + ") and (cnumerodoc='" + _P_Str_Numero + "') and (ctipodoc='" + ((_G_Enum_Pago.ConCheque) ? "C" : "D") + "') and (cbanco='" + _P_Str_Banco.Trim() + "') ";
                if (_P_Str_IdPago != "")
                {
                    _Str_SQL += "and cidpago <> '" + _P_Str_IdPago + "'";
                }
                var  dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (dsResultados.Tables[0].Rows.Count > 0)
                {
                    _Bol_ExisteEnTemporales = true;
                }

                //Sino existe en las temporales, buscamos si existe en las finales
                if (!_Bol_ExisteEnTemporales)
                {
                    //Si estamos editando
                    if (_P_Str_IdPago != "") //Editando
                    {
                        double _Dbl_cmontocheque = 0;

                        //Cargo los datos del pago 
                        _Str_SQL = "select * from TTRCPAGOM where (ccompany='" + _P_Str_Compañia.Trim() + "') and (cidpago=" + _P_Str_IdPago + ")";
                        dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                        if (dsResultados.Tables[0].Rows.Count > 0)
                        {
                            _Dbl_cmontocheque = Convert.ToDouble(dsResultados.Tables[0].Rows[0]["cmontototal"]);

                            //Buscarmos si existe un pago en finales distinto
                            _Str_SQL = "SELECT cidrelacobro " +
                                       "FROM TRELACCOBDCHEQ " +
                                       "WHERE" +
                                       "(ccompany='" + _P_Str_Compañia.Trim() + "') " +
                                       "AND (ccliente=" + _P_Str_Cliente + ") " +
                                       "AND (cbancocheque='" + _P_Str_Banco.Trim() + "') " +
                                       "AND (cnumcheque='" + _P_Str_Numero + "')" +
                                       "AND (cmontocheq<>'" + _Dbl_cmontocheque.ToString().Replace(',', '.') + "') ";
                            //Si viene una relacion la obviamos
                            if (_Str_cidrelacobro != "") 
                            {
                                _Str_SQL += "AND (cidrelacobro <> '" + _Str_cidrelacobro + "')";
                            }
                            dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                            if (dsResultados.Tables[0].Rows.Count > 0)
                            {
                                return true;
                            }
                            return false;

                        }
                        return false;
                    }
                    else //Nuevo
                    {
                        _Str_SQL = "SELECT cidrelacobro " +
                                   "FROM TRELACCOBDCHEQ " +
                                   "WHERE" +
                                   "(ccompany='" + _P_Str_Compañia.Trim() + "') " +
                                   "AND (ccliente=" + _P_Str_Cliente + ") " +
                                   "AND (cbancocheque='" + _P_Str_Banco.Trim() + "') " +
                                   "AND (cnumcheque='" + _P_Str_Numero + "') ";
                        //Si viene una relacion la obviamos
                        if (_Str_cidrelacobro != "")
                        {
                            _Str_SQL += "AND (cidrelacobro <> '" + _Str_cidrelacobro + "')";
                        }
                        dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                        if (dsResultados.Tables[0].Rows.Count > 0)
                        {
                            return true;
                        }
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else //DEPOSITO
            {
                //Verificamos si existe en las temporales
                var _Bol_ExisteEnTemporales = false;
                _Str_SQL = "select cidpago from TTRCPAGOM where ((ccompany='" + _P_Str_Compañia.Trim() + "') and (cguia=" + _P_Str_Guia + ") and (ccliente=" + _P_Str_Cliente + ") and (cnumerodoc='" + _P_Str_Numero + "') and (ctipodoc='" + ((_G_Enum_Pago.ConCheque) ? "C" : "D") + "') and (cbanco='" + _P_Str_Banco.Trim() + "')) ";
                if (_P_Str_IdPago != "")
                {
                    _Str_SQL += "and (cidpago <> '" + _P_Str_IdPago + "') ";
                }
                var dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (dsResultados.Tables[0].Rows.Count > 0)
                {
                    _Bol_ExisteEnTemporales = true;
                }

                //Sino existe en las temporales, buscamos si existe en las finales
                if (!_Bol_ExisteEnTemporales)
                {
                    //Si estamos editando
                    if (_P_Str_IdPago != "") //Editando
                    {
                        double _Dbl_cmontodeposito = 0;

                        //Cargo los datos del pago 
                        _Str_SQL = "select * from TTRCPAGOM where (ccompany='" + _P_Str_Compañia.Trim() + "') and (cidpago=" + _P_Str_IdPago + ")";
                        dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                        if (dsResultados.Tables[0].Rows.Count > 0)
                        {
                            _Dbl_cmontodeposito = Convert.ToDouble(dsResultados.Tables[0].Rows[0]["cmontototal"]);

                            //Buscarmos si existe un pago en finales distinto
                            _Str_SQL = "SELECT cidrelacobro " +
                                       "FROM TRELACCOBDDEPM " +
                                       "WHERE" +
                                       "(ccompany='" + _P_Str_Compañia.Trim() + "') " +
                                       "AND (cbancodepo='" + _P_Str_Banco.Trim() + "') " +
                                       "AND (cnumdepo='" + _P_Str_Numero + "') ";
                                       //"AND (cmontodepo <>'" + _Dbl_cmontodeposito.ToString().Replace(',', '.') + "')" 
                            //Si viene una relacion la obviamos
                            if (_Str_cidrelacobro != "")
                            {
                                _Str_SQL += "AND (cidrelacobro <> '" + _Str_cidrelacobro + "')";
                            }
                            dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                            if (dsResultados.Tables[0].Rows.Count > 0)
                            {
                                return true;
                            }
                            return false;

                        }
                        return false;
                    }
                    else //Nuevo
                    {
                        _Str_SQL = "SELECT cidrelacobro " +
                                   "FROM TRELACCOBDDEPM " +
                                   "WHERE" +
                                   "(ccompany='" + _P_Str_Compañia.Trim() + "') " +
                                   "AND (cbancodepo='" + _P_Str_Banco.Trim() + "') " +
                                   "AND (cnumdepo='" + _P_Str_Numero + "') ";
                        //Si viene una relacion la obviamos
                        if (_Str_cidrelacobro != "")
                        {
                            _Str_SQL += "AND (cidrelacobro <> '" + _Str_cidrelacobro + "')";
                        }
                        dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                        if (dsResultados.Tables[0].Rows.Count > 0)
                        {
                            return true;
                        }
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Valida que existan todos las retenciones de todas las facturas si se da el caso
        /// </summary>
        /// <param name="_P_Str_Compañia"></param>
        /// <param name="_P_Str_Guia"></param>
        /// <param name="_P_Str_Cliente"></param>
        /// <param name="_P_Dg_Facturas"></param>
        /// <param name="_P_Dg_Retenciones"></param>
        /// <param name="_P_Lst_Facturas"></param>
        /// <param name="_P_Str_IdPago"></param>
        /// <returns></returns>
        private bool _Mtd_EstanTodasLasRetencionesCargadas(string _P_Str_Compañia,
                                                           string _P_Str_Guia,
                                                           DataGridView _P_Dg_Facturas,
                                                           DataGridView _P_Dg_Retenciones,
                                                           out List<string> _P_Lst_Facturas,
                                                           string _P_Str_IdPago)
        {
            List<string> _Lst_FacturasSinRetenciones = new List<string>();
            //Solo si existen facturas que requieren retencion
            if (_Mtd_ExistenFacturasQueRequierenRetencion(_P_Dg_Facturas))
            {
                //Inicializamos
                var _Lst_FacturasAValidar = new Dictionary<string, string>();

                //Cargo la lista de facturas
                _P_Dg_Facturas.Rows.Cast<DataGridViewRow>()
                              .Where(x => Convert.ToBoolean(x.Cells[0].Value))
                              .Where(x => Convert.ToDouble(x.Cells["cmontototalimpuesto"].Value) > 0)
                              .Where(x => _Mtd_ClienteEsContribuyenteEspecial(x.Cells["colClienteFactura"].Value.ToString()))
                              .ToList()
                              .ForEach(x => _Lst_FacturasAValidar.Add(x.Cells["colNumeroFactura"].Value.ToString(), x.Cells["colClienteFactura"].Value.ToString()));

                //Verificamos
                foreach (KeyValuePair<string, string> _Dic_RegistroAValidar in _Lst_FacturasAValidar)
                {
                    //Verificamos si esta en memoria
                    var _Bol_ExisteEnGridRetenciones = _P_Dg_Retenciones.Rows.Cast<DataGridViewRow>().Any(x => x.Cells["colRetencionFactura"].Value.ToString() == _Dic_RegistroAValidar.Key);
                    //Verificamos si esta en la base de datos
                    var _Bol_ExisteEnBaseDatosRetenciones = _Mtd_ExisteRetencionSegunFacturaEnBaseDeDatos(_P_Str_Compañia, _P_Str_Guia, _Dic_RegistroAValidar.Value, _Dic_RegistroAValidar.Key, _P_Str_IdPago);

                    if ((_Bol_ExisteEnGridRetenciones == false) & (_Bol_ExisteEnBaseDatosRetenciones == false))
                    {
                        _Lst_FacturasSinRetenciones.Add(_Dic_RegistroAValidar.Key);
                    }
                }
                //Devolvemos
                if (_Lst_FacturasSinRetenciones.Count > 0)
                {
                    _P_Lst_Facturas = _Lst_FacturasSinRetenciones;
                    return false;
                }
                _P_Lst_Facturas = _Lst_FacturasSinRetenciones;
                return true;
            }

            //Por defecto si todo esta bien decimos que existe
            _P_Lst_Facturas = _Lst_FacturasSinRetenciones;
            return true; //
        }

        /// <summary>
        /// Obtiene una lista de facturas que requieren devolucion cargada 
        /// </summary>
        /// <param name="_P_Str_Compañia"></param>
        /// <param name="_P_Str_Guia"></param>
        /// <param name="_P_Str_Cliente"></param>
        /// <returns></returns>
        private List<string> _Mtd_ObtenerListaFacturasRequierenDevolucion(string _P_Str_Compañia, string _P_Str_Guia, string _P_Str_Cliente)
        {
            var _Lst_Facturas = new List<string>();
            var _Str_Sql = "SELECT DISTINCT TGUIADESPACHOD.cfactura FROM TGUIADESPACHOD INNER JOIN TGUIADESPACHOM ON TGUIADESPACHOD.cgroupcomp = TGUIADESPACHOM.cgroupcomp AND TGUIADESPACHOD.cguiadesp = TGUIADESPACHOM.cguiadesp INNER JOIN TFACTURAM ON TGUIADESPACHOD.cfactura = TFACTURAM.cfactura AND TGUIADESPACHOD.cgroupcomp = TFACTURAM.cgroupcomp AND TGUIADESPACHOD.ccompany = TFACTURAM.ccompany  " +
                           "WHERE TGUIADESPACHOD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TGUIADESPACHOD.ccompany='" + _P_Str_Compañia + "' AND (TGUIADESPACHOD.cguiadesp = '" + _P_Str_Guia + "') AND (TFACTURAM.ccliente = '" + _P_Str_Cliente + "') AND (TGUIADESPACHOD.c_estatus='PAG' AND TGUIADESPACHOD.c_cancelaciontot='0') AND TGUIADESPACHOM.cestatusfirma='2' ";
            var _Ds_Resultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Resultados.Tables[0].Rows.Count > 0)
            {
                _Ds_Resultados.Tables[0].AsEnumerable().ToList().ForEach(_Row => _Lst_Facturas.Add(_Row["cfactura"].ToString()));
            }
            return _Lst_Facturas;
        }

        /// <summary>
        /// Valida que existan esten cargadoas y asignadas todas las devoluciones y notas de credito
        /// </summary>
        /// <param name="_P_Str_Compañia"></param>
        /// <param name="_P_Str_Guia"></param>
        /// <param name="_P_Str_Cliente"></param>
        /// <param name="_P_Dg_Facturas"></param>
        /// <param name="_P_Lst_Facturas"></param>
        /// <returns></returns>
        private bool _Mtd_EstanTodasLasDeDevolucionNcGeneradasCargadas(
                                                                       string _P_Str_Compañia,
                                                                       string _P_Str_Guia,
                                                                       string _P_Str_Cliente,
                                                                       DataGridView _P_Dg_Facturas,
                                                                       out List<string> _P_Lst_Facturas
                                                                      )
        {
            //
            var _Lst_FacturasSinDevoluciones = new List<string>();


            //Cargo la lista de facturas que requiere devolucion
            var _Lst_FacturasRequierenDevolucion = _Mtd_ObtenerListaFacturasRequierenDevolucion(_P_Str_Compañia, _P_Str_Guia, _P_Str_Cliente);

            //Si no hay facturas que requieran devolucion
            if (_Lst_FacturasRequierenDevolucion.Count == 0)
            {
                _P_Lst_Facturas = _Lst_FacturasSinDevoluciones;
                return true; 
            }

            //Cargo la lista de facturas en grid
            var _Lst_FacturasAValidar =
                _P_Dg_Facturas.Rows.Cast<DataGridViewRow>()
                                .Where(x => Convert.ToBoolean(x.Cells[0].Value))
                                .Select(x => x.Cells["colNumeroFactura"].Value.ToString())
                                .ToList();

            //Verificamos
            foreach (string _Str_FacturaAValidar in _Lst_FacturasAValidar)
            {
                //verificamos si la factura requiere devolucion
                var _Bol_RequiereDevolucion = _Lst_FacturasRequierenDevolucion.Contains(_Str_FacturaAValidar);
                if (_Bol_RequiereDevolucion)
                {
                    //Verificamos si existe la devolucion aprobada
                    var _Bol_ExisteEnBaseDatosDevolucionAprobada = _Mtd_ExisteDevolucionConNCSegunFacturaEnBaseDeDatos(Frm_Padre._Str_GroupComp, _P_Str_Compañia, _P_Str_Cliente, _Str_FacturaAValidar);
                    if (_Bol_ExisteEnBaseDatosDevolucionAprobada == false)
                    {
                        _Lst_FacturasSinDevoluciones.Add(_Str_FacturaAValidar);
                    }
                }
            }
            //Devolvemos
            if (_Lst_FacturasSinDevoluciones.Count > 0)
            {
                _P_Lst_Facturas = _Lst_FacturasSinDevoluciones;
                return false;
            }
            _P_Lst_Facturas = _Lst_FacturasSinDevoluciones;
            return true;
        }

        /// <summary>
        /// Valida que las facturas que estan pagadas con devolucion tengan por lo menos una nc seleccionada
        /// </summary>
        /// <param name="_P_Str_Compañia"></param>
        /// <param name="_P_Str_Guia"></param>
        /// <param name="_P_Str_Cliente"></param>
        /// <param name="_P_Dg_Facturas"></param>
        /// <param name="_P_Lst_Facturas"></param>
        /// <param name="_P_Str_IdPago"></param>
        /// <returns></returns>
        private bool _Mtd_EstanTodasLasFacturaParcialesConNcSeleccionada(
                                                                          string _P_Str_Compañia,
                                                                          string _P_Str_Guia,
                                                                          string _P_Str_Cliente,
                                                                          DataGridView _P_Dg_Facturas,
                                                                          out List<string> _P_Lst_Facturas,
                                                                          string _P_Str_IdPago
                                                                         )
        {
            //
            var _Lst_FacturasSinNcSeleccionadas = new List<string>();

            //Cargo la lista de facturas que requiere devolucion
            var _Lst_FacturasRequierenDevolucion = _Mtd_ObtenerListaFacturasRequierenDevolucion(_P_Str_Compañia, _P_Str_Guia, _P_Str_Cliente);

            //Si no hay facturas que requieran devolucion
            if (_Lst_FacturasRequierenDevolucion.Count == 0)
            {
                _P_Lst_Facturas = _Lst_FacturasSinNcSeleccionadas;
                return true;
            }

            //Cargo la lista de facturas en grid
            var _Lst_FacturasAValidar =
                _P_Dg_Facturas.Rows.Cast<DataGridViewRow>()
                                .Where(x => Convert.ToBoolean(x.Cells[0].Value))
                                .Select(x => x.Cells["colNumeroFactura"].Value.ToString())
                                .ToList();

            //Verificamos
            foreach (string _Str_FacturaAValidar in _Lst_FacturasAValidar)
            {
                //verificamos si la factura requiere devolucion
                var _Bol_RequiereDevolucion = _Lst_FacturasRequierenDevolucion.Contains(_Str_FacturaAValidar);
                if (_Bol_RequiereDevolucion)
                {
                    //Verificamos si tiene seleccionada por lo menos una NC
                    var _Bol_ExisteEnGridNc = _Dtg_NotasCreditos.Rows.Cast<DataGridViewRow>().Any(x => Convert.ToBoolean(x.Cells["colSeleccionarNC"].Value) && x.Cells["colFacturaNC"].Value.ToString() == _Str_FacturaAValidar);

                    //Verificamos si esta en la base de datos excepto el actual
                    var _Bol_ExisteEnBaseDatosNcSeleccionada = _Mtd_ExisteNcSeleccionadaSegunFacturaEnBaseDeDatos(_P_Str_Compañia, _P_Str_Guia, _P_Str_Cliente, _Str_FacturaAValidar, _P_Str_IdPago);

                    if ((_Bol_ExisteEnGridNc == false) & (_Bol_ExisteEnBaseDatosNcSeleccionada == false))
                    {
                        _Lst_FacturasSinNcSeleccionadas.Add(_Str_FacturaAValidar);
                    }
                }
            }
            //Devolvemos
            if (_Lst_FacturasSinNcSeleccionadas.Count > 0)
            {
                _P_Lst_Facturas = _Lst_FacturasSinNcSeleccionadas;
                return false;
            }
            _P_Lst_Facturas = _Lst_FacturasSinNcSeleccionadas;
            return true;
        }

        /// <summary>
        /// Este método permite verificar si existe la retención ya cargada en la base de datos en el sistema.
        /// </summary>
        /// <param name="_P_Str_Compañia"></param>
        /// <param name="_P_Str_Guia"></param>
        /// <param name="_P_Str_Cliente"></param>
        /// <param name="_P_Str_cfactura"></param>
        /// <param name="_P_Str_IdPago"></param>
        /// <returns></returns>
        private bool _Mtd_ExisteRetencionSegunFacturaEnBaseDeDatos(string _P_Str_Compañia, string _P_Str_Guia, string _P_Str_Cliente, string _P_Str_cfactura, string _P_Str_IdPago)
        {
            var _Str_SQL = "SELECT TTRCPAGOM.cidpago, TTRCPAGOM.ccompany, TTRCPAGOM.cguia, TTRCPAGOM.ccliente, TTRCRETENCION.cfactura " +
                           "FROM TTRCPAGOM INNER JOIN TTRCRETENCION ON TTRCPAGOM.cidpago = TTRCRETENCION.cidpago " +
                           "WHERE (TTRCPAGOM.cdelete = 0) AND (TTRCRETENCION.cdelete = 0) " +
                           "AND (TTRCRETENCION.cfactura = '" + _P_Str_cfactura + "') AND (TTRCPAGOM.ccompany = '" + _P_Str_Compañia + "') AND (TTRCPAGOM.cguia = '" + _P_Str_Guia +
                           "')"; 
            //" AND (TTRCPAGOM.ccliente = '" + _P_Str_Cliente + "')";
            if (_P_Str_IdPago != "") _Str_SQL += " AND (TTRCPAGOM.cidpago <> '" + _P_Str_IdPago + "')";
            var dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            return (dsResultados.Tables[0].Rows.Count > 0);
        }

        /// <summary>
        /// Este método permite verificar si la factura ya tiene seleccionada una nota de credito
        /// </summary>
        /// <param name="_P_Str_Compañia"></param>
        /// <param name="_P_Str_Guia"></param>
        /// <param name="_P_Str_Cliente"></param>
        /// <param name="_P_Str_cfactura"></param>
        /// <param name="_P_Str_IdPago"></param>
        /// <returns></returns>
        private bool _Mtd_ExisteNcSeleccionadaSegunFacturaEnBaseDeDatos(string _P_Str_Compañia, string _P_Str_Guia, string _P_Str_Cliente, string _P_Str_cfactura, string _P_Str_IdPago)
        {
            var _Str_SQL = "SELECT TTRCPAGOM.cidpago, TTRCPAGOM.ccompany, TTRCPAGOM.cguia, TTRCPAGOM.ccliente, TTRCNOTACREDD.cfactura FROM TTRCPAGOM INNER JOIN TTRCNOTACREDD ON TTRCPAGOM.cidpago = TTRCNOTACREDD.cidpago  " +
                           "WHERE (TTRCPAGOM.cdelete = 0) AND (TTRCNOTACREDD.cdelete = 0) " +
                           "AND (TTRCNOTACREDD.cfactura = '" + _P_Str_cfactura + "') AND (TTRCPAGOM.ccompany = '" + _P_Str_Compañia + "') AND (TTRCPAGOM.cguia = '" + _P_Str_Guia +
                           "') AND (TTRCPAGOM.ccliente = '" + _P_Str_Cliente + "')";
            if (_P_Str_IdPago != "") _Str_SQL += " AND (TTRCPAGOM.cidpago <> '" + _P_Str_IdPago + "')";
            var dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            return (dsResultados.Tables[0].Rows.Count > 0);
        }

        /// <summary>
        /// Este método permite verificar si existe la devolucion y aprobada
        /// </summary>
        /// <param name="_P_Str_Compañia"></param>
        /// <param name="_P_Str_cfactura"></param>
        /// <returns></returns>
        private bool _Mtd_ExisteDevolucionConNCSegunFacturaEnBaseDeDatos(string _P_Str_GrupoCompañia, string _P_Str_Compañia, string _P_Str_Cliente, string _P_Str_cfactura)
        {
            var _Str_SQL = "SELECT cfactura FROM TDEVVENTAM WHERE cgroupcomp = '" + _P_Str_GrupoCompañia + "' AND ccompany = '" + _P_Str_Compañia + "' AND cfactura = '" + _P_Str_cfactura + "' AND ccliente = '" + _P_Str_Cliente + "' AND cimprimenc = '1' AND cimprimenr = '1' AND isnull(cdelete,0)=0";
            var dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            return (dsResultados.Tables[0].Rows.Count > 0);
        }


        /// <summary>Este método permite verificar si existe la nota de crédito.</summary>
        /// <param name="_P_Str_IdPago">Identificador o código del pago.</param>
        /// <param name="_P_Str_NotaCredito">Código de la nota de crédito.</param>
        /// <returns>Verdadero si existe la nota en la tabla TTRCNOTACREDD.</returns>
        private bool _Mtd_ExisteNotaCredito(string _P_Str_IdPago, string _P_Str_NotaCredito)
        {
            if (_P_Str_IdPago == "") return false;

            string _Str_SQL;

            _Str_SQL = "select ciddetalle from TTRCNOTACREDD where ((cidpago=" + _P_Str_IdPago + ") and (cnotacredito=" + _P_Str_NotaCredito + "));";

            DataSet dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsResultados.Tables[0].Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>Este método permite verificar si existe la retención.</summary>
        /// <returns>Verdadero si existe la nota en la tabla TTRCNOTACREDD.</returns>
        public static bool _Mtd_ExisteRetencion(string _P_Str_Compañia, string _P_Str_Guia, string _P_Str_Cliente, string _P_Str_IdPago, string _P_Str_Factura, out Double _P_Dbl_Monto)
        {
            if (_P_Str_IdPago == "")
            {
                _P_Dbl_Monto = 0;
                return false;
            }

            var _Str_SQL = "SELECT TTRCPAGOM.cidpago, TTRCRETENCION.cmonto FROM TTRCPAGOM INNER JOIN TTRCRETENCION ON TTRCPAGOM.cidpago = TTRCRETENCION.cidpago " +
                           "WHERE (TTRCRETENCION.cdelete = 0) AND (TTRCPAGOM.ccompany='" + _P_Str_Compañia.Trim() + "') AND (TTRCPAGOM.cguia=" + _P_Str_Guia + ") AND (TTRCPAGOM.ccliente=" + _P_Str_Cliente +
                           ") AND (TTRCRETENCION.cfactura=" + _P_Str_Factura + ") AND (TTRCPAGOM.cidpago = '" + _P_Str_IdPago + "')";
            var oResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (oResultado.Tables[0].Rows.Count > 0)
            {
                if (oResultado.Tables[0].Rows[0]["cidpago"].ToString() != "")
                {
                    _P_Dbl_Monto = Convert.ToDouble(oResultado.Tables[0].Rows[0]["cmonto"]);
                    return true;
                }
            }
            _P_Dbl_Monto = 0;
            return false;
        }


        /// <summary>Este método verifica si el monto de las notas no supera el monto de la factura a la que están asignadas.</summary>
        /// <param name="_P_Str_Factura">Código de la factura.</param>
        /// <returns>Verdadero si el monto de las notas supera al de la factura.</returns>
        private bool _Mtd_EsValidoSaldoFacturaContraNotasCredito(string _P_Str_Factura)
        {
            bool _Bol_Validar = true;
            double _Dbl_MontoNota = 0;

            foreach (DataGridViewRow oNota in _Dtg_NotasCreditos.Rows)
            {
                if ((oNota.Cells[0].Value != null) && (oNota.Cells[1].Value != null))
                {
                    if (((bool) oNota.Cells[0].Value) && (oNota.Cells[1].Value.ToString() == _P_Str_Factura))
                    {
                        _Dbl_MontoNota += Convert.ToDouble(oNota.Cells["colMontoNC"].Value.ToString());
                    }
                }
            }

            foreach (DataGridViewRow oFactura in _Dtg_Facturas.Rows)
            {
                if (oFactura.Cells[0].Value != null)
                {
                    if (((bool) oFactura.Cells[0].Value) && (oFactura.Cells[2].Value.ToString() == _P_Str_Factura))
                    {
                        //Cuando es nuevo
                        if (_G_Estado_Formulario == TiposEstadoPago.EstadoPagoNuevo)
                        {
                            if (_Dbl_MontoNota > Convert.ToDouble(oFactura.Cells["cmontosaldo"].Value.ToString()))
                            {
                                _Bol_Validar = false;
                            }
                        }
                        else
                        {
                            if (_Dbl_MontoNota > Convert.ToDouble(oFactura.Cells["cmontoapagar"].Value.ToString()))
                            {
                                _Bol_Validar = false;
                            }
                        }
                    }
                }
            }

            return _Bol_Validar;
        }

        /// <summary>Este método permite verificar si las facturas están seleccionadas.</summary>
        /// <param name="_P_Str_Factura">Código de la factura.</param>
        /// <returns>Verdadero si la factura la factura está marcada en el grid.</returns>
        private bool _Mtd_VerificarFacturaSeleccionada(string _P_Str_Factura)
        {
            bool _Bol_Validar = true;

            foreach (DataGridViewRow oFactura in _Dtg_Facturas.Rows)
            {
                if (oFactura.Cells[0].Value != null)
                {
                    if ((!(bool) oFactura.Cells[0].Value) && (oFactura.Cells[2].Value.ToString() == _P_Str_Factura))
                    {
                        _Bol_Validar = false;
                    }
                }
            }

            return _Bol_Validar;
        }

        /// <summary>Este método permite obtener el saldo del documento.</summary>        
        /// <returns>Saldo del documento.</returns>
        private double _Mtd_ObtenerSaldoDelosDocumentosSeleccionados()
        {
            var _Dbl_MontoAbono = (((_Txt_MontoDocumento.Tag == null) || (_Txt_MontoDocumento.Tag == "")) ? 0 : Convert.ToDouble(_Txt_MontoDocumento.Tag.ToString()));
            var _Dbl_MontoSaldoFacturas = 0.0;
            var _Dbl_MontoNotasCredito = 0.0;
            var _Dbl_MontoRetenciones = 0.0;
            var _Dbl_MontoSaldo = 0.0;
            //Saldo Documentos
            _Dtg_Facturas.Rows.Cast<DataGridViewRow>().ToList().ForEach(_Row =>
                {
                    _Dbl_MontoSaldoFacturas += _Mtd_ObtenerMontoAPagarFactura(_Row.Cells["colNumeroFactura"].Value.ToString());
                });
            //Notas de Credito
            _Dtg_NotasCreditos.Rows.Cast<DataGridViewRow>()
                              .Where(_Row => Convert.ToBoolean(_Row.Cells["colSeleccionarNC"].Value))
                              .ToList().ForEach(_Row =>
                                  {
                                      //solo si tiene una factura selecionada
                                      if (_Row.Cells["colFacturaNC"].Value.ToString() != "NO SELECCIONADA") _Dbl_MontoNotasCredito += Convert.ToDouble(_Row.Cells["colMontoNC"].Value);
                                  });
            //Retenciones
            _Dtg_Retenciones.Rows.Cast<DataGridViewRow>().ToList().ForEach(_Row =>
                {
                    //Si la retención existe en la BD para el pago actual ya esta descontada en el saldo del documento
                    var _Dbl_Monto = 0.0;
                    if (!_Mtd_ExisteRetencion(_G_Enum_Pago.Compañia, _G_Enum_Pago.Guia, _G_Enum_Pago.Cliente, _Txt_IdDocumento.Text, _Row.Cells["colRetencionFactura"].Value.ToString(), out _Dbl_Monto))
                    {
                        var _Dbl_MontoGrid = Convert.ToDouble((_Row.Cells["colRetencionMonto"].Value));
                        _Dbl_MontoRetenciones += _Dbl_MontoGrid;
                    }
                    else
                    {
                        var _Dbl_MontoGrid = Convert.ToDouble((_Row.Cells["colRetencionMonto"].Value));
                        _Dbl_Monto = Math.Round(_Dbl_Monto, 2);
                        _Dbl_MontoGrid = Math.Round(_Dbl_MontoGrid, 2);
                        if (_Dbl_MontoGrid != _Dbl_Monto) _Dbl_MontoRetenciones += _Dbl_MontoGrid;
                        else _Dbl_MontoRetenciones += _Dbl_Monto;
                    }
                });


            _Dbl_MontoSaldo = _Dbl_MontoSaldoFacturas - _Dbl_MontoNotasCredito - _Dbl_MontoRetenciones - _Dbl_MontoAbono;

            //Cambiamos signo
            _Dbl_MontoSaldo = _Dbl_MontoSaldo*(-1);

            //redondeamos
            _Dbl_MontoSaldo = Math.Round(_Dbl_MontoSaldo, 2);

            return _Dbl_MontoSaldo;
        }

        private double _Mtd_ObtenerSaldoDelPago()
        {
            var _Dbl_MontoPago = (((_Txt_MontoDocumento.Tag == null) || (_Txt_MontoDocumento.Tag == "")) ? 0 : Convert.ToDouble(_Txt_MontoDocumento.Tag.ToString()));
            var _Dbl_MontoFacturas = 0.0;
            var _Dbl_MontoNotasCredito = 0.0;
            var _Dbl_MontoRetenciones = 0.0;
            var _Dbl_MontoSaldoDocumentos = 0.0;
            var _Dbl_MontoSaldoPago = 0.0;
            //Saldo Documentos
            _Dtg_Facturas.Rows.Cast<DataGridViewRow>().ToList().ForEach(_Row =>
                {
                    var _Str_cfactura = _Row.Cells["colNumeroFactura"].Value.ToString();
                    _Dbl_MontoFacturas += _Mtd_ObtenerMontoAPagarFactura(_Str_cfactura);
                    _Dbl_MontoNotasCredito += _Mtd_ObtenerMontoNotasCredito(_Str_cfactura);
                    _Dbl_MontoRetenciones += _Mtd_ObtenerMontoRetencion(_Str_cfactura);
                });
            _Dbl_MontoSaldoDocumentos = _Dbl_MontoFacturas - _Dbl_MontoNotasCredito - _Dbl_MontoRetenciones;
            _Dbl_MontoSaldoPago = _Dbl_MontoPago - _Dbl_MontoSaldoDocumentos;
            _Dbl_MontoSaldoPago = Math.Round(_Dbl_MontoSaldoPago, 2);
            return _Dbl_MontoSaldoPago;
        }


        /// <summary>Este método obtiene el saldo de los documentos seleccionados desde la Base de Datls.</summary>        
        /// <returns>Saldo del documento.</returns>
        private double _Mtd_ObtenerSaldoDocumentosSeleccionados(string _P_Str_cidpago)
        {
            string _Str_SQL;
            var _Dbl_Saldo = 0.0;

            _Str_SQL =
                "SELECT TTRCPAGOM.cidpago, SUM(TTRCDOCUMENTO.cmontosaldo) AS SumaDeSaldos FROM TTRCPAGOD INNER JOIN TTRCPAGOM ON TTRCPAGOD.cidpago = TTRCPAGOM.cidpago INNER JOIN TTRCDOCUMENTO ON TTRCPAGOM.ccompany = TTRCDOCUMENTO.ccompany AND TTRCPAGOM.cguia = TTRCDOCUMENTO.cguia AND TTRCPAGOD.cfactura = TTRCDOCUMENTO.cfactura AND TTRCPAGOM.ccliente = TTRCDOCUMENTO.ccliente " +
                "WHERE (TTRCPAGOD.cdelete = 0) AND (TTRCPAGOM.cdelete = 0) AND (TTRCDOCUMENTO.cdelete = 0) AND (TTRCPAGOM.cidpago = '" + _P_Str_cidpago + "') GROUP BY TTRCPAGOM.cidpago ";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Dbl_Saldo = Convert.ToDouble(_Ds.Tables[0].Rows[0]["SumaDeSaldos"]);
            }
            return _Dbl_Saldo;
        }


        /// <summary>Este método permite obtener el saldo de la factura.</summary>
        /// <param name="_P_Str_Factura">Código de la factura.</param>
        /// <returns>Saldo de la factura menos las notas de crédito y retenciones.</returns>
        private double _Mtd_ObtenerMontoAPagarFactura(string _P_Str_Factura)
        {
            double _Dbl_TotalFactura = 0;
            foreach (DataGridViewRow oFactura in _Dtg_Facturas.Rows)
            {
                if (oFactura.Cells[0].Value != null)
                {
                    if (((bool) oFactura.Cells[0].Value) && (oFactura.Cells[2].Value.ToString() == _P_Str_Factura))
                    {
                        _Dbl_TotalFactura = Convert.ToDouble(oFactura.Cells["cmontoapagar"].Value.ToString());
                    }
                }
            }
            return _Dbl_TotalFactura;
        }

        /// <summary>Este método permite eliminar un pago y actualizar la relación de cobranza eliminandolo de sus detalles.</summary>
        /// <param name="_P_Str_IdPago">Identificador o código interno del pago.</param>
        /// <param name="_P_Bol_SoloTablasFinales">indica si solo se van a eliminar las tablas finales</param>
        private void _Mtd_EliminarPago(string _P_Str_IdPago, bool _P_Bol_SoloTablasFinales = false)
        {
            string _Str_SQL;
            string _Str_IdRelacion = "";
            var _Str_IdCheque = "";
            var _Str_IdDeposito = "";

            //Obtenemos el identificador de la relacion de los documentos involucrados en el detalle del pago
            _Str_SQL = "SELECT TTRCDOCUMENTO.cidrelacion, TTRCPAGOM.ccliente ";
            _Str_SQL += " FROM TTRCPAGOM INNER JOIN TTRCPAGOD ON TTRCPAGOM.cidpago = TTRCPAGOD.cidpago INNER JOIN TTRCDOCUMENTO ON TTRCPAGOM.ccompany = TTRCDOCUMENTO.ccompany AND TTRCPAGOD.cfactura = TTRCDOCUMENTO.cfactura ";
            _Str_SQL += " WHERE (TTRCPAGOM.cdelete = 0) AND (TTRCPAGOD.cdelete = 0) AND (TTRCDOCUMENTO.cdelete = 0) AND (TTRCPAGOM.cidpago = '" + _P_Str_IdPago + "') and not TTRCDOCUMENTO.cidrelacion is null ";
            var _Ds_Relacion = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds_Relacion.Tables[0].Rows.Count > 0)
            {
                //Obtenemos los valores
                _Str_IdRelacion = _Ds_Relacion.Tables[0].Rows[0]["cidrelacion"].ToString();
            }

            //Si existe relacion entonces borramos de las tablas de la relacion (TABLAS FINALES)
            if (_Str_IdRelacion != "")
            {
                /*
                 * Aqui se hace lo siguiente:
                 * 
                 *  - Se busca el identificador del cheque en la relación de cobranza en TRELACCOBDCHEQ.
                 *  - Se borra el cheque de las tablas TRELACCOBDCHEQ.
                 *  - Se borra el cheque de la tabla TRELACCOBDD.
                 */

                //Buscamos los cheques del cliente (maestra)
                _Str_SQL = "select ciddrelacobro_cheq from TRELACCOBDCHEQ " +
                           "where ((ccompany='" + _G_Enum_Pago.Compañia.Trim() + "') and (cgroupcomp=" + Frm_Padre._Str_GroupComp + ") " +
                           "and (cidrelacobro='" + _Str_IdRelacion + "') and (ccliente=" + _G_Enum_Pago.Cliente + "));";
                var _Ds_Cheques = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                foreach (DataRow _oCheque in _Ds_Cheques.Tables[0].Rows)
                {
                    //Obtenemos el identificador del cheque
                    _Str_IdCheque = _oCheque["ciddrelacobro_cheq"].ToString();

                    //Borramos el cheque
                    _Str_SQL = "delete from TRELACCOBDCHEQ " +
                               "where ((cgroupcomp=" + Frm_Padre._Str_GroupComp + ") and (ccompany='" + _G_Enum_Pago.Compañia.Trim() + "') " +
                               "and (cidrelacobro='" + _Str_IdRelacion + "') and (ccliente=" + _G_Enum_Pago.Cliente + ")" +
                               "and (ciddrelacobro_cheq = '" + _Str_IdCheque + "'));";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                    //Borramos los documentos que fueron pagados por el cheque
                    _Str_SQL = "delete from TRELACCOBDD " +
                               "where ((cgroupcomp=" + Frm_Padre._Str_GroupComp + ") and (ccompany='" + _G_Enum_Pago.Compañia.Trim() + "') " +
                               "and (cidrelacobro='" + _Str_IdRelacion + "') and (cidrelaciondetalle='" + _Str_IdCheque + "') and (cidrelaciondep=0));";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                }
                
                /*
                 * Aqui se hace lo siguiente:
                 * 
                 *  - Se busca el identificador del depósito en la relación de cobranza en TRELACCOBDDEPM.
                 *  - Se busca el detalle del depósito en la relación de cobranza en TRELACCOBDDEPD.
                 *  - Se borra el depósito de las tablas TRELACCOBDDEPM y de TRELACCOBDDEPD.
                 *  - Se borra el depósito de la tabla TRELACCOBDD.
                 */

                //Buscamos el depósito (maestra)
                _Str_SQL = "select ciddrelacobrodep from TRELACCOBDDEPD " +
                            "where (cgroupcomp=" + Frm_Padre._Str_GroupComp + ") and (ccompany='" + _G_Enum_Pago.Compañia.Trim() + "') " +
                            "and (cidrelacobro='" + _Str_IdRelacion + "') and (ccliente=" + _G_Enum_Pago.Cliente + ") ";

                var _Ds_Depositos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                foreach (DataRow _oDeposito in _Ds_Depositos.Tables[0].Rows)
                {
                    //Obtenemos el identificador del depósito
                    _Str_IdDeposito = _oDeposito["ciddrelacobrodep"].ToString();

                    //Borramos el depósito (detalle)
                    _Str_SQL = "delete from TRELACCOBDDEPD " +
                               "where (cgroupcomp=" + Frm_Padre._Str_GroupComp + ") and (ccompany='" + _G_Enum_Pago.Compañia.Trim() + "') " +
                               "and (cidrelacobro='" + _Str_IdRelacion + "') and (ciddrelacobrodep=" + _Str_IdDeposito + ") and (ccliente=" + _G_Enum_Pago.Cliente + ") ";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                    //Borramos el depósito (maestra)
                    _Str_SQL = "delete from TRELACCOBDDEPM " +
                               "where (cgroupcomp=" + Frm_Padre._Str_GroupComp + ") and (ccompany='" + _G_Enum_Pago.Compañia.Trim() + "') " +
                               "and (cidrelacobro='" + _Str_IdRelacion + "') and (ciddrelacobro_dep=" + _Str_IdDeposito + ") ";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                    //Borramos los documentos que fueron pagados por el depósito
                    _Str_SQL = "delete from TRELACCOBDD " +
                               "where (cgroupcomp=" + Frm_Padre._Str_GroupComp + ") and (ccompany='" + _G_Enum_Pago.Compañia.Trim() + "') " +
                               "and (cidrelacobro='" + _Str_IdRelacion + "') and (cidrelaciondep=" + _Str_IdDeposito + ") ";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                }


                /*
                * Aqui se hace lo siguiente:
                * 
                *  - Se busca las facturas del pago.
                *  - Se busca si esa factura la tiene asignada otro pago.
                *  - Si no tiene otros pagos asignados, se borra de la tabla TRELACCOBD.
                */

                //Cargamos los documentos afectados por el pago
                _Str_SQL = "select cfactura from TTRCPAGOD where (cidpago=" + _P_Str_IdPago + ");";
                var _Ds_Documentos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (_Ds_Documentos.Tables[0].Rows.Count > 0)
                {
                    //Recorremos cada documento
                    foreach (DataRow oDocumento in _Ds_Documentos.Tables[0].Rows)
                    {
                        //Buscamos si ese documento tiene registrado un pago distinto al que se esta eliminando
                        _Str_SQL = "select cidpago from TTRCPAGOD where ((cfactura=" + oDocumento["cfactura"].ToString() + ") and (cidpago<>" + _P_Str_IdPago + "));";
                        DataSet oPagos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                        //Si no hay mas pagos
                        if (oPagos.Tables[0].Rows.Count == 0)
                        {
                            //Borramos el detalle del pago del documento en la relacion
                            _Str_SQL = "delete from TRELACCOBD " +
                                       "where (cgroupcompany=" + Frm_Padre._Str_GroupComp + ") and (ccompany='" + _G_Enum_Pago.Compañia.Trim() + "') " +
                                       "and (cidrelacobro='" + _Str_IdRelacion + "') and (cnumdocu=" + oDocumento["cfactura"].ToString() + ") ";

                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                        }
                    }
                }

            } // fin del borrado de las (tablas finales)


            /*
             * Aqui se hace lo siguiente:
             * 
             *  - Se actualizan los saldos de las facturas que toco el pago en TTRCDOCUMENTO.
             *  - Se actualiza el estatus de las facturas.
             */

            _Str_SQL = "select cfactura, cmontoabono from TTRCPAGOD where (cidpago=" + _P_Str_IdPago + ");";
            var _Ds_Facturas = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (_Ds_Facturas.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow oFactura in _Ds_Facturas.Tables[0].Rows)
                {
                    _Str_SQL = "update TTRCDOCUMENTO set ccancelada=0, " + ((_G_Enum_Pago.ConCheque) ? "cmontocobradocheque=(cmontocobradocheque-(" : "cmontocobradoefectivo=(cmontocobradoefectivo-(") + oFactura["cmontoabono"].ToString().Replace(",", ".") + "))";
                    _Str_SQL += " where (cfactura=" + oFactura["cfactura"].ToString() + ") and (ccompany='" + _G_Enum_Pago.Compañia.Trim() + "') and (cguia=" + _G_Enum_Pago.Guia + ") ";

                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                }
            }

            /*
             * Aqui se hace lo siguiente:
             * 
             *  - Se borran los datos de la tablas temporales según el pago.
             */

            if (!_P_Bol_SoloTablasFinales)
            {
                _Str_SQL = "delete from TTRCRETENCION where (cidpago=" + _P_Str_IdPago + ");";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                _Str_SQL = "delete from TTRCNOTACREDD where (cidpago=" + _P_Str_IdPago + ");";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                _Str_SQL = "delete from TTRCPAGOD where (cidpago=" + _P_Str_IdPago + ");";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                _Str_SQL = "delete from TTRCPAGOM where (cidpago=" + _P_Str_IdPago + ");";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
            }

            //Actualizamos la tabla de documentos en las relaciones finales
            if (_Str_IdRelacion != "")
            {
                // -- - -- INICIO -- - -- 
                /*  
                 *  Se actualiza la tabla TRELACCOBD segun el detalle de cada pago de cada documento
                 * 
                 */
                //Cargamos todos los documentos de la relacion
                _Str_SQL = "SELECT ctipodocument, cnumdocu, ccliente ";
                _Str_SQL += " FROM TRELACCOBD ";
                _Str_SQL += " WHERE (TRELACCOBD.cdelete = 0) AND (TRELACCOBD.cgroupcompany = '" + Frm_Padre._Str_GroupComp + "') AND (TRELACCOBD.ccompany = '" + _G_Enum_Pago.Compañia + "') AND (TRELACCOBD.cidrelacobro='" + _Str_IdRelacion + "') ";
                var _Ds_Documentos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (_Ds_Documentos.Tables[0].Rows.Count > 0)
                {
                    //Recorremos cada documento
                    foreach (DataRow oDocumento in _Ds_Documentos.Tables[0].Rows)
                    {
                        //Variables
                        var _Str_ctipodocument = oDocumento["ctipodocument"].ToString();
                        var _Str_cnumdocu = oDocumento["cnumdocu"].ToString();
                        var _Str_ccliente = oDocumento["ccliente"].ToString();

                        //Obtenemos el total de pagos del documento desde la tabla de TRELACCOBDD
                        _Str_SQL = "SELECT SUM(cmontodeefectivo) AS MontoTotal " +
                                   "FROM TRELACCOBDD " +
                                   "WHERE (TRELACCOBDD.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TRELACCOBDD.ccompany = '" + _G_Enum_Pago.Compañia + "') AND (TRELACCOBDD.cidrelacobro='" + _Str_IdRelacion + "') " +
                                   "AND (TRELACCOBDD.ctipodocument = '" + _Str_ctipodocument + "') AND (TRELACCOBDD.cnumdocu = '" + _Str_cnumdocu + "')  AND (TRELACCOBDD.ccliente = '" + _Str_ccliente + "')";
                        var _Ds_DetallePagosDocumentos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                        if (_Ds_DetallePagosDocumentos.Tables[0].Rows.Count > 0)
                        {
                            double _Dbl_MontoPagado = 0;
                            double.TryParse(_Ds_DetallePagosDocumentos.Tables[0].Rows[0]["MontoTotal"].ToString(), out _Dbl_MontoPagado);
                            _Dbl_MontoPagado = Math.Round(_Dbl_MontoPagado, 2);
                            if (_Dbl_MontoPagado > 0)
                            {
                                _Str_SQL = "UPDATE TRELACCOBD " +
                                           "SET " +
                                           "cmontocancel = " + _Dbl_MontoPagado.ToString().Replace(",", ".") + " " +
                                           ",cdateupd = getdate() " +
                                           ",cuserupd = '" + Frm_Padre._Str_Use + "' " +
                                           "WHERE (cgroupcompany=" + Frm_Padre._Str_GroupComp + ") AND (ccompany='" + _G_Enum_Pago.Compañia.Trim() + "') " +
                                           "AND (cidrelacobro='" + _Str_IdRelacion + "') AND (cnumdocu='" + _Str_cnumdocu + "')  AND (ccliente='" + _Str_ccliente + "') ";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                            }
                            else
                            {
                                _Str_SQL = "DELETE TRELACCOBD " +
                                           "WHERE (cgroupcompany=" + Frm_Padre._Str_GroupComp + ") AND (ccompany='" + _G_Enum_Pago.Compañia.Trim() + "') " +
                                           "AND (cidrelacobro='" + _Str_IdRelacion + "') AND (cnumdocu='" + _Str_cnumdocu + "')  AND (ccliente='" + _Str_ccliente + "') ";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                            }
                        }
                        else
                        {
                            _Str_SQL = "DELETE TRELACCOBD " +
                                       "WHERE (cgroupcompany=" + Frm_Padre._Str_GroupComp + ") AND (ccompany='" + _G_Enum_Pago.Compañia.Trim() + "') " +
                                       "AND (cidrelacobro='" + _Str_IdRelacion + "') AND (cnumdocu='" + _Str_cnumdocu + "')  AND (ccliente='" + _Str_ccliente + "') ";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                        }
                    }
                }

                /*
                * Aqui se hace lo siguiente:
                * 
                *  - Se verifica si hay documentos en el detalle de la relación.
                *  - En caso de que no tenga documentos, se borra el encabezado.
                */

                _Str_SQL = "select cidrelacobro from TRELACCOBD where ((cgroupcompany=" + Frm_Padre._Str_GroupComp + ") and (ccompany='" + _G_Enum_Pago.Compañia.Trim() + "') and (cidrelacobro='" + _Str_IdRelacion + "'));";
                DataSet _Ds_DetalleRelacion = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if ((_Ds_DetalleRelacion.Tables[0].Rows.Count == 0) && (_Str_IdRelacion != ""))
                {
                    //Borramos las tablas verdaderas
                    _Str_SQL = "DELETE FROM TRELACCOBDCHEQ WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _G_Enum_Pago.Compañia.Trim() + "' AND cidrelacobro='" + _Str_IdRelacion + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                    _Str_SQL = "DELETE FROM TRELACCOBDDEPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _G_Enum_Pago.Compañia.Trim() + "' AND cidrelacobro='" + _Str_IdRelacion + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                    _Str_SQL = "DELETE FROM TRELACCOBDD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _G_Enum_Pago.Compañia.Trim() + "' AND cidrelacobro='" + _Str_IdRelacion + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                    _Str_SQL = "DELETE FROM TRELACCOBDDEPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _G_Enum_Pago.Compañia.Trim() + "' AND cidrelacobro='" + _Str_IdRelacion + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                    _Str_SQL = "DELETE FROM TRELACCOBD WHERE cgroupcompany='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _G_Enum_Pago.Compañia.Trim() + "' AND cidrelacobro='" + _Str_IdRelacion + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                    _Str_SQL = "DELETE FROM TRELACCOBM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _G_Enum_Pago.Compañia.Trim() + "' AND cidrelacobro='" + _Str_IdRelacion + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                    _Str_SQL = "update TTRCDOCUMENTO set cidrelacion=NULL, cmontosaldo=0 where ((ccompany='" + _G_Enum_Pago.Compañia.Trim() + "') and (cguia=" + _G_Enum_Pago.Guia + "));";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                }
            }
        }

        /// <summary>Este método permite eliminar un documento del detalle del pago.</summary>
        /// <param name="_P_Str_IdPago">Identificador o código interno del pago.</param>
        private void _Mtd_EliminarDocumentos(string _P_Str_IdPago)
        {
            string _Str_SQL;

            _Str_SQL = "select cfactura from TTRCPAGOD where (cidpago=" + _P_Str_IdPago + ");";

            DataSet dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (dsResultados.Tables[0].Rows.Count > 0)
            {
                _G_Estado_Formulario = TiposEstadoPago.EstadoPagoConsultar;

                foreach (DataRow oFactura in dsResultados.Tables[0].Rows)
                {
                    _Str_SQL = "select cmonto from TTRCNOTACREDD WHERE ((cidpago=" + _Txt_IdDocumento.Text + ") and (cfactura=" + oFactura["cfactura"].ToString() + "));";

                    DataSet dsNotas = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                    if (dsNotas.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow oNota in dsNotas.Tables[0].Rows)
                        {
                            _Str_SQL = "update TTRCDOCUMENTO set cmontonotacredito = (cmontonotacredito - " + oNota["cmonto"].ToString().Replace(",", ".") + ")";
                            _Str_SQL += " where ((ccompany='" + _G_Enum_Pago.Compañia + "') and (cfactura=" + oFactura["cfactura"].ToString() + ") and (cguia=" + _G_Enum_Pago.Guia + ") and (ccliente=" +
                                        _G_Enum_Pago.Cliente + "));";

                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                        }
                    }

                    _Str_SQL = "select cmonto from TTRCRETENCION WHERE ((cidpago=" + _Txt_IdDocumento.Text + ") and (cfactura=" + oFactura["cfactura"].ToString() + "));";

                    DataSet dsRetenciones = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                    if (dsRetenciones.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow oRetencion in dsRetenciones.Tables[0].Rows)
                        {
                            _Str_SQL = "update TTRCDOCUMENTO set cmontoretencion = (cmontoretencion - " + oRetencion["cmonto"].ToString().Replace(",", ".") + ")";
                            _Str_SQL += " where ((ccompany='" + _G_Enum_Pago.Compañia + "') and (cfactura=" + oFactura["cfactura"].ToString() + ") and (cguia=" + _G_Enum_Pago.Guia + ") and (ccliente=" +
                                        _G_Enum_Pago.Cliente + "));";

                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                        }
                    }

                    _Str_SQL = "update TTRCDOCUMENTO set " + ((_G_Enum_Pago.ConCheque) ? "cmontocobradocheque = (cmontocobradocheque - " : "cmontocobradoefectivo = (cmontocobradoefectivo - ") +
                               _Txt_MontoDocumento.Tag.ToString().Replace(",", ".") + "), ccancelada=0, cdateupd=getdate(), cuserupd='" + Frm_Padre._Str_Use + "'";
                    _Str_SQL += " where ((cfactura=" + oFactura["cfactura"].ToString() + ") and (ccompany='" + _G_Enum_Pago.Compañia + "') and (cguia=" + _G_Enum_Pago.Guia + ") and (ccliente=" +
                                _G_Enum_Pago.Cliente + "));";

                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                }

                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia("delete from TTRCRETENCION where (cidpago=" + _P_Str_IdPago + ");");
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia("delete from TTRCNOTACREDD where (cidpago=" + _P_Str_IdPago + ");");
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia("delete from TTRCPAGOD where (cidpago=" + _P_Str_IdPago + ");");
            }
        }

        /// <summary>Este método permite obtener el límite del faltante de la tabla TCONFIGCXC para la validación.</summary>
        /// <param name="_P_Str_Compañia">Código de la compañía.</param>
        /// <returns>Valor decimal que indica el límite que no debe sobrepasar el faltante.</returns>
        private double _Mtd_ObtenerLimiteFaltante(string _P_Str_Compañia)
        {
            string _Str_SQL;

            _Str_SQL = "select isnull(climitefaltante, 0) as climitefaltante from TCONFIGCXC where (ccompany='" + _P_Str_Compañia + "');";

            DataSet dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            return (Convert.ToDouble(dsResultados.Tables[0].Rows[0]["climitefaltante"].ToString()));
        }

        /// <summary>Este método permite determinar cuantas notas están aplicadas a una factura.</summary>
        /// <param name="_P_Str_Factura">Código de la factura.</param>
        /// <returns>Cantidad de notas, es para validar que no sean más de tres.</returns>
        private int _Mtd_NumeroNotasAplicadas(string _P_Str_Factura)
        {
            int _Int_TotalNotas = 0;

            foreach (DataGridViewRow oNota in _Dtg_NotasCreditos.Rows)
            {
                if ((oNota.Cells["colSeleccionarNC"].Value != null) && (oNota.Cells["colFacturaNC"].Value != null))
                {
                    if (((bool) oNota.Cells["colSeleccionarNC"].Value) && (oNota.Cells["colFacturaNC"].Value.ToString() == _P_Str_Factura))
                    {
                        _Int_TotalNotas += 1;
                    }
                }
            }

            return _Int_TotalNotas;
        }

        #endregion

        #region Eventos

        private void Frm_RC_PagoCheque_Load(object sender, EventArgs e)
        {
            if (_G_Enum_Pago.ConCheque)
            {
                _Grp_Documentos.Text = "Datos del Cheques";

                _Lbl_Documentos.Text = "Cheques";

                _Lbl_NumeroDocumento.Text = "Número de cheque:";
                _Lbl_MontoDocumento.Text = "Monto del cheque:";

                Text = "Cobro con cheque";

                _Lbl_FechaEmisión.Text = "Fecha de emisión:";
                _Lbl_FechaDepositar.Visible = true;
                _Dtp_FechaDepositar.Visible = true;
            }
            else
            {
                _Grp_Documentos.Text = "Datos del Depósito";

                _Lbl_Documentos.Text = "Depósitos";

                _Lbl_NumeroDocumento.Text = "Número de depósito:";
                _Lbl_MontoDocumento.Text = "Monto del depósito:";

                Text = "Cobro con depósito";

                _Lbl_FechaEmisión.Text = "Fecha del depósito:";
                _Lbl_FechaDepositar.Visible = false;
                _Dtp_FechaDepositar.Visible = false;
            }

            //Cargamos las compañias
            _Mtd_CargarCompañias(_Cmb_Compañia, _G_Enum_Pago.Guia, _G_Enum_Pago.Cliente);

            //Inicializamos las variables
            var oCompañia = (DataRowView) _Cmb_Compañia.SelectedItem;
            _G_Enum_Pago.Compañia = oCompañia[0].ToString();

            //Cargamos los pagos antes cargados
            _Mtd_CargarDocumentos(_Cmb_Documentos, _G_Enum_Pago.Compañia, _G_Enum_Pago.Guia, _G_Enum_Pago.Cliente);

            //Por defecto
            _Mtd_LimpiarControles();
            _Mtd_HabilitarControles(false);
            _Mtd_ColocarBotones(TiposEstadoPago.EstadoInicial);

            //En funcion a los datos ajustamos los controles
            _Cmb_Documentos.Enabled = _Cmb_Documentos.Items.Count > 0;
            _Cmb_Documentos.SelectedIndex = -1;

        }

        private void Frm_RC_Pago_Resize(object sender, EventArgs e)
        {
            Width = 657;
            Height = 624;
        }

        private void _Cmb_Compañia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRowView oCompañia = (DataRowView) _Cmb_Compañia.SelectedItem;

            _G_Enum_Pago.Compañia = oCompañia[0].ToString();

            _Mtd_LimpiarControles();
            _Mtd_HabilitarControles(false);

            _Mtd_CargarBancos(_Cmb_BancosDocumento, _G_Enum_Pago.Compañia);
            _Mtd_CargarDocumentos(_Cmb_Documentos, _G_Enum_Pago.Compañia, _G_Enum_Pago.Guia, _G_Enum_Pago.Cliente);

            _Cmb_Documentos.SelectedIndex = -1;
            _Cmb_Documentos.Enabled = ((_Cmb_Documentos.Items.Count > 0) ? true : false);

            _Cmb_BancosDocumento.SelectedIndex = -1;

        }

        private void _Cmb_Documentos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var oDocumento = (DataRowView) _Cmb_Documentos.SelectedItem;

            if (oDocumento != null)
            {
                var oCompañia = (DataRowView) _Cmb_Compañia.SelectedItem;

                _G_Estado_Formulario = TiposEstadoPago.EstadoPagoConsultar;

                _Mtd_LimpiarControles();
                _Mtd_HabilitarControles(false);

                _G_Enum_Pago.Compañia = oCompañia[0].ToString();

                _Mtd_CargarBancos(_Cmb_BancosDocumento, _G_Enum_Pago.Compañia);
                _Mtd_CargarDatosDocumento(_G_Enum_Pago.Compañia, _G_Enum_Pago.Guia, _G_Enum_Pago.Cliente, oDocumento["cidpago"].ToString());

                _Mtd_CargarFacturas(_G_Enum_Pago.Compañia, _G_Enum_Pago.Guia, _G_Enum_Pago.Cliente, _Txt_IdDocumento.Text);
                _Mtd_CargarNotasCredito(_G_Enum_Pago.Compañia, _G_Enum_Pago.Guia, _G_Enum_Pago.Cliente);
                _Mtd_CargarRetenciones(_G_Enum_Pago.Compañia, _G_Enum_Pago.Guia, _G_Enum_Pago.Cliente, _Txt_IdDocumento.Text);

                _Mtd_MarcarFacturas(_Txt_IdDocumento.Text);
                _Mtd_MarcarNotasCredito(_G_Enum_Pago.Compañia, _G_Enum_Pago.Guia, _G_Enum_Pago.Cliente, _Txt_IdDocumento.Text);

                _Mtd_CargarMontoAPagarFacturas(_G_Enum_Pago.Compañia, _G_Enum_Pago.Guia, _G_Enum_Pago.Cliente, _Dtg_Facturas, TiposEstadoPago.EstadoPagoConsultar);

                _Btn_AgregarRetencion.Enabled = false;

                _Txt_Saldo.Text = "";

                _Mtd_ColocarBotones(TiposEstadoPago.EstadoPagoConsultar);
            }
        }

        private void _Dtg_Facturas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (_Dtg_Facturas.IsCurrentCellDirty)
            {
                _Dtg_Facturas.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void _Dtg_Facturas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var _Str_ccliente = _Dtg_Facturas.Rows[e.RowIndex].Cells["colClienteFactura"].Value.ToString();
                var _Int_CantidadFacturasSinRetencion = _Mtd_ObtenerCantidadFacturasSinRetencion(_Dtg_Facturas, _Dtg_Retenciones);
                _Btn_AgregarRetencion.Enabled = _Mtd_ExistenFacturasQueRequierenRetencion( _Dtg_Facturas) && (_Int_CantidadFacturasSinRetencion > 0) && ((_G_Estado_Formulario == TiposEstadoPago.EstadoPagoEditar) | (_G_Estado_Formulario == TiposEstadoPago.EstadoPagoNuevo));
                _Txt_Saldo.Text = _Mtd_ObtenerSaldoDelosDocumentosSeleccionados().ToString("c");

                //Destiladmos las notas de credito que estaba asociadas a a factura
                _Dtg_Facturas.Rows.Cast<DataGridViewRow>().Where(x => !Convert.ToBoolean(x.Cells["colSeleccionarFactura"].Value)).ToList().ForEach(_Factura =>
                    {
                        var _Str_cfactura = _Factura.Cells["colNumeroFactura"].Value.ToString();
                        _Dtg_NotasCreditos.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["colFacturaNC"].Value != null && x.Cells["colFacturaNC"].Value.ToString() == _Str_cfactura).ToList().ForEach(_Nc =>
                            {
                                _Nc.Cells["colFacturaNC"].Value = "NO SELECCIONADA";
                                _Nc.Cells["colSeleccionarNC"].Value = false;
                            });
                    });

                //Calculamos el saldo del pago con respecto a las factura seleccionada, sino alcanza a pagar nada, no permito seleccionarla
                //Solo si no es consulta
                if (_G_Estado_Formulario != TiposEstadoPago.EstadoPagoConsultar)
                {
                    //Solo si ha cargado algun pago
                    var _Dbl_MontoPago = (((_Txt_MontoDocumento.Tag == null) || (_Txt_MontoDocumento.Tag == "")) ? 0 : Convert.ToDouble(_Txt_MontoDocumento.Tag.ToString()));
                    if (_Dbl_MontoPago > 0)
                    {
                        var _Dbl_SaldoPago = _Mtd_ObtenerSaldoDelPago();
                        var _Dbl_MontoAPagarFactura = Convert.ToDouble(_Dtg_Facturas.Rows[e.RowIndex].Cells["cmontoapagar"].Value);
                        _Dbl_SaldoPago += _Dbl_MontoAPagarFactura;
                        if (_Dbl_SaldoPago <= 0)
                        {
                            //Mensaje
                            MessageBox.Show
                                (
                                    "Esta factura no puede ser seleccionada ya que el total de las facturas sobrepasa el monto del pago",
                                    "Advertencia",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                            _Dtg_Facturas.EndEdit();
                            //Destildamos la factura actualmente seleccionada
                            _Dtg_Facturas.Rows[e.RowIndex].Cells["colSeleccionarFactura"].Value = false;
                        }
                    }
                }
            }
        }

        private void _Dtg_Facturas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //e.Cancel = true;
        }

        private void _Dtg_NotasCreditos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var oCombo = (DataGridViewComboBoxCell) _Dtg_NotasCreditos.Rows[e.RowIndex].Cells[1];
            //var _Item_ = new { cfactura = "" };
            //var _Lst_ = _Mtd_ConvertirEnList(_Item_);
            //_Lst_.Add(new { cfactura = "NO SELECCIONADA" });
            //oCombo.DataSource = _Lst_; 
            oCombo.DataSource = _Mtd_InicializarListaComboFacturas();
            oCombo.DisplayMember = "Display";
            oCombo.ValueMember = "Value";
        }

        private ArrayList _Mtd_InicializarListaComboFacturas()
        {
            var _myArrayList = new System.Collections.ArrayList
                {
                    new T3.Clases._Cls_ArrayList("NO SELECCIONADA", "NO SELECCIONADA")
                };
            return _myArrayList;
        }

        private ArrayList _Mtd_AgregarComboFacturasAgregar(string _P_Str_cfactura)
        {
            var _myArrayList = _Mtd_InicializarListaComboFacturas();
            _myArrayList.Add(new T3.Clases._Cls_ArrayList(_P_Str_cfactura, _P_Str_cfactura));
            return _myArrayList;
        }

        private List<T> _Mtd_ConvertirEnList<T>(T itemOftype)
        {
            var newList = new List<T>();
            return newList;
        }

        private void _Dtg_NotasCreditos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (_Dtg_Facturas.Rows.Count > 0)
            {
                var _Lst_Facturas = _Mtd_InicializarListaComboFacturas();
                var _Str_cclienteNC = _Dtg_NotasCreditos.Rows[e.RowIndex].Cells["colClienteNC"].Value.ToString();

                DataGridViewComboBoxCell oCombo = (DataGridViewComboBoxCell) _Dtg_NotasCreditos.Rows[e.RowIndex].Cells[1];
                var _ItemsSeleccionados = _Dtg_Facturas.Rows.Cast<DataGridViewRow>()
                                                       .Where(x => Convert.ToBoolean(x.Cells["colSeleccionarFactura"].Value) && x.Cells["colClienteFactura"].Value.ToString() == _Str_cclienteNC)
                                                       .Select(x => new
                                                           {
                                                               cfactura = x.Cells["colNumeroFactura"].Value.ToString()
                                                           }).ToList();

                //Pasamos los valores
                _ItemsSeleccionados.ToList().ForEach(x =>
                    {
                        var _Item = new Clases._Cls_ArrayList(x.cfactura, x.cfactura);
                        _Lst_Facturas.Add(_Item);
                    });

                oCombo.DataSource = _Lst_Facturas;
                oCombo.DisplayMember = "Display";
                oCombo.ValueMember = "Value";
            }
        }

        private void _Dtg_NotasCreditos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < _Dtg_NotasCreditos.Rows.Count; i++)
            {
                _Dtg_NotasCreditos.Rows[i].Cells["colFacturaNC"].Value = "NO SELECCIONADA";
                ;
            }
        }


        private void _Dtg_NotasCreditos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (_Dtg_NotasCreditos.IsCurrentCellDirty)
            {
                _Dtg_NotasCreditos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void _Dtg_NotasCreditos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewCheckBoxCell oCelda = (DataGridViewCheckBoxCell) _Dtg_NotasCreditos.Rows[e.RowIndex].Cells["colSeleccionarNC"];
                DataGridViewComboBoxCell oFactura = (DataGridViewComboBoxCell) _Dtg_NotasCreditos.Rows[e.RowIndex].Cells["colFacturaNC"];

                if ((bool) oCelda.Value)
                {
                    oFactura.ReadOnly = false;
                }
                else
                {
                    _Dtg_NotasCreditos.Rows[e.RowIndex].Cells["colSeleccionarNC"].Value = false;
                    _Dtg_NotasCreditos.Rows[e.RowIndex].Cells["colFacturaNC"].Value = "NO SELECCIONADA";
                    oFactura.ReadOnly = true;
                    _Dtg_NotasCreditos.EndEdit();
                    _Txt_Saldo.Text = _Mtd_ObtenerSaldoDelosDocumentosSeleccionados().ToString("c");
                }
            }
            else if (e.ColumnIndex == 1)
            {
                if (_Dtg_NotasCreditos.Rows.Count > 0)
                {
                    using (DataGridViewRow oFila = _Dtg_NotasCreditos.Rows[e.RowIndex])
                    {
                        if (oFila.Cells[1].Value != null)
                        {
                            //No validamos si estamos en consulta
                            if (_G_Estado_Formulario != TiposEstadoPago.EstadoPagoConsultar)
                            {
                                if (!_Mtd_EsValidoSaldoFacturaContraNotasCredito(oFila.Cells["colFacturaNC"].Value.ToString()))
                                {
                                    MessageBox.Show
                                        (
                                            "El total de las notas aplicadas supera el monto de la factura.",
                                            "Advertencia",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error
                                        );

                                    oFila.Cells["colSeleccionarNC"].Value = false;
                                    oFila.Cells["colFacturaNC"].Value = "NO SELECCIONADA";

                                    _Dtg_NotasCreditos.EndEdit();

                                    return;
                                }
                                else if (!_Mtd_VerificarFacturaSeleccionada(oFila.Cells["colFacturaNC"].Value.ToString()))
                                {
                                    MessageBox.Show
                                        (
                                            "La factura no ha sido seleccionada.",
                                            "Advertencia",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error
                                        );


                                    oFila.Cells["colSeleccionarNC"].Value = false;
                                    oFila.Cells["colFacturaNC"].Value = "NO SELECCIONADA";

                                    _Dtg_NotasCreditos.EndEdit();

                                    return;
                                }

                                //Validamos que solo se puedan seleccionar maximo 3 factuas
                                var _Int_TotalNotas = 0;
                                var _Str_cfactura = oFila.Cells["colFacturaNC"].Value.ToString();
                                _Int_TotalNotas = _Mtd_NumeroNotasAplicadas(_Str_cfactura);
                                if (_Int_TotalNotas > 3)
                                {
                                    MessageBox.Show
                                        (
                                            "Solo se permiten 3 notas de crédito para la factura #" + _Str_cfactura + ".",
                                            "Advertencia",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information
                                        );

                                    oFila.Cells["colSeleccionarNC"].Value = false;
                                    oFila.Cells["colFacturaNC"].Value = "NO SELECCIONADA";

                                    _Dtg_NotasCreditos.EndEdit();

                                    return;
                                }

                            }

                            //Recalculamos los saldos de los documentos
                            //_Mtd_CargarMontoAPagarFacturas(_G_Enum_Pago.Compañia, _G_Enum_Pago.Guia, _G_Enum_Pago.Cliente, _Dtg_Facturas, _G_Estado_Formulario);

                            //Recalculamos el saldo 
                            _Txt_Saldo.Text = _Mtd_ObtenerSaldoDelosDocumentosSeleccionados().ToString("c");
                        }
                    }
                }
            }
        }

        private void _Dtg_NotasCreditos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //e.Cancel = true;
        }

        private void _Mtd_LimpiarControles()
        {
            //_Cmb_Documentos.SelectedIndex = -1;

            _Cmb_BancosDocumento.SelectedIndex = -1;

            _Dtp_FechaEmision.Value = DateTime.Now;
            _Dtp_FechaDepositar.Value = DateTime.Now;

            _Txt_NumeroDocumento.Tag = "";
            _Txt_NumeroDocumento.Text = "";

            _Txt_MontoDocumento.Tag = "";
            _Txt_MontoDocumento.Text = "";

            _Txt_Saldo.Tag = "";
            _Txt_Saldo.Text = "";

            _Txt_IdDocumento.Text = "";

            DataTable dtFacturas = (DataTable) _Dtg_Facturas.DataSource;

            if (dtFacturas != null)
            {
                dtFacturas.Clear();
            }

            DataTable dtNotas = (DataTable) _Dtg_NotasCreditos.DataSource;

            if (dtNotas != null)
            {
                dtNotas.Clear();
            }

            DataTable dtRetenciones = (DataTable) _Dtg_Retenciones.DataSource;

            if (dtRetenciones != null)
            {
                dtRetenciones.Clear();
            }
        }

        private void _Mtd_HabilitarControles(bool _P_Bol_Habilitar)
        {
            _Cmb_Documentos.Enabled = !_P_Bol_Habilitar;
            _Cmb_Compañia.Enabled = !_P_Bol_Habilitar;
            _Cmb_BancosDocumento.Enabled = _P_Bol_Habilitar;

            _Dtp_FechaEmision.Enabled = _P_Bol_Habilitar;
            _Dtp_FechaDepositar.Enabled = _P_Bol_Habilitar;
            _Txt_NumeroDocumento.Enabled = _P_Bol_Habilitar;
            _Txt_MontoDocumento.Enabled = _P_Bol_Habilitar;

            _Grp_Facturas.Enabled = _P_Bol_Habilitar;
            _Grp_NotasCredito.Enabled = _P_Bol_Habilitar;
            _Grp_Retenciones.Enabled = _P_Bol_Habilitar;
            _Btn_AgregarRetencion.Enabled = false;
        }

        private void _Mtd_ColocarBotones(TiposEstadoPago _P_EstadoFormulario)
        {
            switch (_P_EstadoFormulario)
            {
                case TiposEstadoPago.EstadoPagoNuevo:
                case TiposEstadoPago.EstadoPagoEditar:
                    _Btn_Nuevo.Enabled = false;
                    _Btn_Editar.Enabled = false;
                    _Btn_Eliminar.Enabled = false;
                    _Btn_Cancelar.Enabled = true;
                    _Btn_Guardar.Enabled = true;
                    break;
                case TiposEstadoPago.EstadoPagoConsultar:
                    _Btn_Nuevo.Enabled = true;
                    _Btn_Editar.Enabled = true;
                    _Btn_Eliminar.Enabled = true;
                    _Btn_Cancelar.Enabled = true;
                    _Btn_Guardar.Enabled = false;
                    break;
                case TiposEstadoPago.EstadoInicial:
                    _Btn_Nuevo.Enabled = true;
                    _Btn_Editar.Enabled = false;
                    _Btn_Eliminar.Enabled = false;
                    _Btn_Cancelar.Enabled = false;
                    _Btn_Guardar.Enabled = false;
                    break;
            }
        }

        private void _Btn_Nuevo_Click(object sender, EventArgs e)
        {
            _G_Estado_Formulario = TiposEstadoPago.EstadoPagoNuevo;

            //Validacion
            if (!_Mtd_HayDocumentosPorPagar(_G_Enum_Pago.Compañia, _G_Enum_Pago.Guia, _G_Enum_Pago.Cliente, ""))
            {
                MessageBox.Show
                    (
                        "No existe documentos con saldo pendiente.",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                _G_Estado_Formulario = TiposEstadoPago.EstadoPagoConsultar;
                return;
            }
            
            _Cmb_Documentos.SelectedIndex = -1;
            _Mtd_LimpiarControles();

            DataRowView oCompañia = (DataRowView) _Cmb_Compañia.SelectedItem;

            _Mtd_CargarBancos(_Cmb_BancosDocumento, _G_Enum_Pago.Compañia);
            _Mtd_CargarFacturas(_G_Enum_Pago.Compañia, _G_Enum_Pago.Guia, _G_Enum_Pago.Cliente, "");
            _Mtd_CargarNotasCredito(_G_Enum_Pago.Compañia, _G_Enum_Pago.Guia, _G_Enum_Pago.Cliente);

            DataSet dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select '' as cnumretencion, '' as cfactura, 0.0 as cmonto, '' as cfechaemision, '' as cnumerocontrol;");
            dsResultados.Tables[0].Clear();
            _Dtg_Retenciones.DataSource = dsResultados.Tables[0];

            //Calculamos los montos a pagar de los documentos
            _Mtd_CargarMontoAPagarFacturas(_G_Enum_Pago.Compañia, _G_Enum_Pago.Guia, _G_Enum_Pago.Cliente, _Dtg_Facturas, TiposEstadoPago.EstadoPagoNuevo);

            //Por defectgo
            _Mtd_HabilitarControles(true);
            _Mtd_ColocarBotones(TiposEstadoPago.EstadoPagoNuevo);

            //Ajustamos los controles
            _Txt_Saldo.Text = _Mtd_ObtenerSaldoDelosDocumentosSeleccionados().ToString("c");
            _Cmb_BancosDocumento.Focus();
        }

        private void _Btn_Editar_Click(object sender, EventArgs e)
        {
            _G_Estado_Formulario = TiposEstadoPago.EstadoPagoEditar;
            //Calculamos los montos a pagar de los documentos
            _Mtd_CargarMontoAPagarFacturas(_G_Enum_Pago.Compañia, _G_Enum_Pago.Guia, _G_Enum_Pago.Cliente, _Dtg_Facturas, TiposEstadoPago.EstadoPagoEditar);
            _Mtd_HabilitarControles(true);
            _Cmb_Compañia.Enabled = false;
            _Mtd_ColocarBotones(TiposEstadoPago.EstadoPagoEditar);
            _Txt_Saldo.Text = _Mtd_ObtenerSaldoDelosDocumentosSeleccionados().ToString("c");
            _Btn_AgregarRetencion.Enabled = _Mtd_ExistenFacturasQueRequierenRetencion(_Dtg_Facturas);
        }

        private void _Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el pago?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                _Mtd_EliminarPago(_Txt_IdDocumento.Text);

                foreach (DataGridViewRow oFila in _Dtg_Facturas.Rows)
                {
                    if (oFila.Cells[0].Value != null)
                    {
                        if ((bool) oFila.Cells[0].Value)
                        {
                            Frm_RC_DocumentosClientes._Mtd_ActualizarSaldo(_G_Enum_Pago.Compañia, _G_Enum_Pago.Guia, _G_Enum_Pago.Cliente, oFila.Cells[2].Value.ToString());
                        }
                    }
                }

                _Mtd_LimpiarControles();

                _Mtd_CargarDocumentos(_Cmb_Documentos, _G_Enum_Pago.Compañia, _G_Enum_Pago.Guia, _G_Enum_Pago.Cliente);

                if (_Cmb_Documentos.Items.Count == 0)
                {
                    Close();
                }
                else
                {
                    _Cmb_Documentos.SelectedIndex = -1;
                    _Cmb_Documentos.Enabled = true;
                }

                _Mtd_HabilitarControles(false);
                _Mtd_ColocarBotones(TiposEstadoPago.EstadoInicial);
            }
        }

        private void _Btn_Cancelar_Click_1(object sender, EventArgs e)
        {
            _Mtd_LimpiarControles();

            _Mtd_CargarDocumentos(_Cmb_Documentos, _G_Enum_Pago.Compañia, _G_Enum_Pago.Guia, _G_Enum_Pago.Cliente);

            _G_Estado_Formulario = TiposEstadoPago.EstadoInicial;
            _Mtd_HabilitarControles(false);
            _Mtd_ColocarBotones(TiposEstadoPago.EstadoInicial);

            if (_Cmb_Documentos.Items.Count == 0)
            {
                //Close();
                _Cmb_Documentos.SelectedIndex = -1;
                _Cmb_Documentos.Enabled = false;
            }
            else
            {
                _Cmb_Documentos.SelectedIndex = -1;
                _Cmb_Documentos.Enabled = true;
            }

        }

        private void _Btn_AgregarRetencion_Click(object sender, EventArgs e)
        {
            bool _Bol_Seleccionada = false;

            if (_Dtg_Facturas.Rows.Count > 0)
            {
                foreach (DataGridViewRow oFila in _Dtg_Facturas.Rows)
                {
                    if (oFila.Cells[0].Value != null)
                    {
                        if ((bool) oFila.Cells[0].Value)
                        {
                            _Bol_Seleccionada = true;

                            break;
                        }
                    }
                }

                if (_Bol_Seleccionada)
                {
                    var _Int_CantidadFacturasSinRetencion = _Mtd_ObtenerCantidadFacturasSinRetencion(_Dtg_Facturas, _Dtg_Retenciones);

                    if (_Int_CantidadFacturasSinRetencion == 0)
                    {
                        //Mensaje
                        MessageBox.Show
                            (
                                "Todas las facturas seleccionadas ya tiene cargada su retención",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        return;
                    }

                    var Frm_Retencion = new Frm_RC_Retencion(TiposEstadoRetencion.EstadoRetencionNuevo, _G_Enum_Pago.Compañia, _G_Enum_Pago.Guia);
                    Frm_Retencion.Facturas = _Dtg_Facturas;
                    Frm_Retencion.NotasCredito = _Dtg_NotasCreditos;
                    Frm_Retencion.Retencion = _Dtg_Retenciones;
                    Frm_Retencion.IdPago = _Txt_IdDocumento.Text;
                    Frm_Retencion.ShowDialog();

                    _Txt_Saldo.Text = _Mtd_ObtenerSaldoDelosDocumentosSeleccionados().ToString("c");
                }
                else
                {
                    MessageBox.Show
                        (
                            "Debe seleccionar una factura.",
                            "Advertencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                    return;
                }
            }
        }

        private void _Btn_Guardar_Click(object sender, EventArgs e)
        {
            bool _Bol_Seleccionada = false;
            int _Int_TotalNotas = 0;

            try
            {
                if (_Cmb_BancosDocumento.SelectedIndex == 0)
                {
                    MessageBox.Show
                        (
                            "Indica el banco del documento.",
                            "Advertencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                    _Cmb_BancosDocumento.Focus();

                    return;
                }

                if (_Txt_NumeroDocumento.Text == "")
                {
                    MessageBox.Show
                        (
                            "Indica el número del " + ((_G_Enum_Pago.ConCheque) ? "cheque" : "depósito") + ".",
                            "Advertencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                    _Txt_NumeroDocumento.Focus();

                    return;
                }

                if (_Txt_MontoDocumento.Text == "")
                {
                    MessageBox.Show
                        (
                            "Indica el monto del " + ((_G_Enum_Pago.ConCheque) ? "cheque" : "depósito") + ".",
                            "Advertencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                    _Txt_MontoDocumento.Focus();

                    return;
                }

                //Se quito esto por el ticket 19297, en el cual cargaron un pago por cero bolivares
                double _Dbl_MontoDocumento = 0.0;
                _Dbl_MontoDocumento = (((_Txt_MontoDocumento.Tag == null) || (_Txt_MontoDocumento.Tag == "")) ? 0 : Convert.ToDouble(_Txt_MontoDocumento.Tag.ToString()));
                _Dbl_MontoDocumento = Math.Round(_Dbl_MontoDocumento,2);
                if (_Dbl_MontoDocumento == 0)
                {
                    MessageBox.Show
                        (
                            "No se  permite que el monto del pago sea cero (0)",
                            "Advertencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    _Txt_MontoDocumento.Focus();
                    return;
                }

                if (_Dtp_FechaEmision.Value.Date > DateTime.Now.Date)
                {
                    MessageBox.Show
                        (
                            "La fecha de emisión no puede superar la fecha actual.",
                            "Advertencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                    return;
                }

                if (_Dtp_FechaDepositar.Visible)
                {
                    if (_Dtp_FechaDepositar.Value.Date < _Dtp_FechaEmision.Value.Date)
                    {
                        MessageBox.Show
                            (
                                "La fecha de depósito no puede ser menor a la de emisión.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                        return;
                    }
                }

                //Solo se permite a partir de mañana
                if (_Dtp_FechaDepositar.Visible)
                {
                    if (_Dtp_FechaDepositar.Value.Date <= DateTime.Now.Date)
                    {
                        MessageBox.Show
                            (
                                "La fecha de depósito tiene que ser mayor al día de hoy..",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                        return;
                    }
                }

                foreach (DataGridViewRow oFactura in _Dtg_Facturas.Rows)
                {
                    var _Str_cfactura = oFactura.Cells["colNumeroFactura"].ToString();
                    _Int_TotalNotas = _Mtd_NumeroNotasAplicadas(_Str_cfactura);

                    if (_Int_TotalNotas > 3)
                    {
                        MessageBox.Show
                            (
                                "Solo se permiten 3 notas de crédito para la factura #" + _Str_cfactura + ".",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                        return;
                    }
                }

                foreach (DataGridViewRow oFactura in _Dtg_Facturas.Rows)
                {
                    if (oFactura.Cells[0].Value != null)
                    {
                        if ((bool) oFactura.Cells[0].Value)
                        {
                            _Bol_Seleccionada = true;

                            break;
                        }
                    }
                }

                if (!_Bol_Seleccionada)
                {
                    MessageBox.Show
                        (
                            "Debe seleccionar por lo menos una factura.",
                            "Advertencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                    return;
                }

                foreach (DataGridViewRow oNota in _Dtg_NotasCreditos.Rows)
                {
                    if (oNota.Cells[0].Value != null)
                    {
                        if ((bool) oNota.Cells[0].Value)
                        {
                            if (oNota.Cells["colFacturaNC"].Value == "NO SELECCIONADA")
                            {
                                MessageBox.Show
                                    (
                                        "Indique una factura para la nota de crédito seleccionada.",
                                        "Advertencia",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information
                                    );

                                return;
                            }
                            else
                            {
                                if (oNota.Cells[1].Value.ToString() == "")
                                {
                                    MessageBox.Show
                                        (
                                            "Indique una factura para la nota de crédito seleccionada.",
                                            "Advertencia",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information
                                        );

                                    return;
                                }
                            }
                        }
                    }
                }

                if (_Mtd_ExisteDocumento(_Cmb_Compañia.SelectedValue.ToString(), _G_Enum_Pago.Guia, _G_Enum_Pago.Cliente, _Txt_NumeroDocumento.Text, _Cmb_BancosDocumento.SelectedValue.ToString(), _Txt_IdDocumento.Text)) 
                {
                    MessageBox.Show
                        (
                            "Ya existe el número de " + ((_G_Enum_Pago.ConCheque) ? "cheque" : "depósito") + ".",
                            "Advertencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                    return;
                }

                // Fue mandada a quitar por Roberto el día 08-09-2014
                ////- = - = - = - = - = - = - = - = - = - = - = - = - = - =  VALIDACIONES DE LAS NOTAS DE DEVOLUCION - = - = - = - = - = - = - = - = - = - = - = - = - = - = 
                ////Verificamos si es el caso de documento pagado con devolucion
                ////Debe existir la devolucion, debe estar aprobada, y si genero notas de credito, deben estar generadas e impresas
                //var _Lst_FacturasSinDevoluciones = new List<string>();
                //if (
                //    !_Mtd_EstanTodasLasDeDevolucionNcGeneradasCargadas(_Cmb_Compañia.SelectedValue.ToString(),
                //                                                       _G_Enum_Pago.Guia,
                //                                                       _G_Enum_Pago.Cliente,
                //                                                       _Dtg_Facturas,
                //                                                       out _Lst_FacturasSinDevoluciones)
                //    )
                //{
                //    var _Str_Mensaje = "";
                //    if (_Lst_FacturasSinDevoluciones.Count > 1)
                //        _Str_Mensaje += "Las Facturas ";
                //    else
                //        _Str_Mensaje += "La Factura ";
                //    var _Int_Contador = 0;
                //    _Lst_FacturasSinDevoluciones.ForEach(x =>
                //    {
                //        _Int_Contador++;
                //        _Str_Mensaje += x;
                //        if (_Int_Contador < _Lst_FacturasSinDevoluciones.Count) _Str_Mensaje += ", ";
                //    });
                //    if (_Lst_FacturasSinDevoluciones.Count > 1)
                //        _Str_Mensaje += " tienen devoluciones por procesar, culmine dicho proceso y vuelva intentar el posteo del cobro ";
                //    else
                //        _Str_Mensaje += " tiene una devolución por procesar, culmine dicho proceso y vuelva intentar el posteo del cobro ";
                //    MessageBox.Show
                //        (
                //            _Str_Mensaje,
                //            "Advertencia",
                //            MessageBoxButtons.OK,
                //            MessageBoxIcon.Information
                //        );

                //    return;
                //}

                ////- = - = - = - = - = - = - = - = - = - = - = - = - = - =  VALIDACIONES DE LAS SELECCION DE LAS NC POR FACTURAS CON DEVOLUCIONES - = - = - = - = - = - = - = - = - = - = - = - = - = - = 
                ////Se debe validar que cuando la factura sea parcial tenga obligatoriamente seleccionada una nota de credito
                //var _Lst_FacturasSinNcSeleccionadas = new List<string>();
                //if (
                //    !_Mtd_EstanTodasLasFacturaParcialesConNcSeleccionada(_Cmb_Compañia.SelectedValue.ToString(),
                //                                                         _G_Enum_Pago.Guia,
                //                                                         _G_Enum_Pago.Cliente,
                //                                                         _Dtg_Facturas,
                //                                                         out _Lst_FacturasSinNcSeleccionadas,
                //                                                         _Txt_IdDocumento.Text)
                //    )
                //{
                //    var _Str_Mensaje = "";
                //    if (_Lst_FacturasSinNcSeleccionadas.Count > 1)
                //        _Str_Mensaje += "Las Facturas ";
                //    else
                //        _Str_Mensaje += "La Factura ";
                //    var _Int_Contador = 0;
                //    _Lst_FacturasSinNcSeleccionadas.ForEach(x =>
                //    {
                //        _Int_Contador++;
                //        _Str_Mensaje += x;
                //        if (_Int_Contador < _Lst_FacturasSinNcSeleccionadas.Count) _Str_Mensaje += ", ";
                //    });
                //    if (_Lst_FacturasSinNcSeleccionadas.Count > 1)
                //        _Str_Mensaje += " le falta seleccionar las NC correspondientes ";
                //    else
                //        _Str_Mensaje += " le falta seleccionar la NC correspondiente ";
                //    MessageBox.Show
                //        (
                //            _Str_Mensaje,
                //            "Advertencia",
                //            MessageBoxButtons.OK,
                //            MessageBoxIcon.Information
                //        );

                //    return;
                //}

                //- = - = - = - = - = - = - = - = - = - = - = - = - = - =  VALIDACIONES LAS RETENCIONES - = - = - = - = - = - = - = - = - = - = - = - = - = - = 
                //Verificamos si es el caso que exista una retencion
                var _Lst_FacturasSinRetenciones = new List<string>();
                if (
                    !_Mtd_EstanTodasLasRetencionesCargadas(_Cmb_Compañia.SelectedValue.ToString(),
                                                           _G_Enum_Pago.Guia,
                                                           _Dtg_Facturas,
                                                           _Dtg_Retenciones,
                                                           out _Lst_FacturasSinRetenciones,
                                                           _Txt_IdDocumento.Text))
                {
                    var _Str_Mensaje = "Debe cargar la retencíon de la factura";
                    if (_Lst_FacturasSinRetenciones.Count > 1) _Str_Mensaje += "(s) ";
                    else _Str_Mensaje += " ";
                    var _Int_Contador = 0;
                    _Lst_FacturasSinRetenciones.ForEach(x =>
                        {
                            _Int_Contador++;
                            _Str_Mensaje += x;
                            if (_Int_Contador < _Lst_FacturasSinRetenciones.Count) _Str_Mensaje += ", ";
                        });
                    MessageBox.Show
                        (
                            _Str_Mensaje,
                            "Advertencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                    return;
                }

                //Obtenemos el saldo del pago
                var _Dbl_SaldoPago = _Mtd_ObtenerSaldoDelPago();

                //En funcion al saldo del pago mostramos mensajes
                if (_Dbl_SaldoPago < 0)
                {

                    //Si estabamos editando eliminamos los documentos
                    if (_G_Estado_Formulario == TiposEstadoPago.EstadoPagoEditar) _Mtd_EliminarDocumentos(_Txt_IdDocumento.Text);

                    //Guardamos 
                    _Mtd_GuardarPago();

                    //Eliminamos el pago de las tablas finales
                    _Mtd_EliminarPagosClienteTablasFinales();

                    //Actualizamos lo saldos
                    _Dtg_Facturas.Rows.Cast<DataGridViewRow>()
                                 .ToList()
                                 .ForEach(_Row => Frm_RC_DocumentosClientes._Mtd_ActualizarSaldo(_G_Enum_Pago.Compañia, _G_Enum_Pago.Guia, _G_Enum_Pago.Cliente, _Row.Cells["colNumeroFactura"].Value.ToString()));

                    //Obtenemos el saldo de los documentos
                    var _Dbl_SaldosDocumentosSeleccionados = _Mtd_ObtenerSaldoDocumentosSeleccionados(_G_Str_cidpago);

                    if (_Dbl_SaldosDocumentosSeleccionados > 0)
                    {
                        MessageBox.Show
                            (
                                "Existe un FALTANTE de " + Math.Abs(_Dbl_SaldosDocumentosSeleccionados).ToString("c") + ".",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                    }

                    Close();
                }
                else if (_Dbl_SaldoPago > 0)
                {
                    if (MessageBox.Show("Existe un SOBRANTE de " + _Dbl_SaldoPago.ToString("c") + ".", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) ==
                        System.Windows.Forms.DialogResult.OK)
                    {
                        //Si estabmos editando eliminamos los documentos
                        if (_G_Estado_Formulario == TiposEstadoPago.EstadoPagoEditar) _Mtd_EliminarDocumentos(_Txt_IdDocumento.Text);

                        //Guardamos 
                        _Mtd_GuardarPago();

                        //Eliminamos el pago de las tablas finales
                        _Mtd_EliminarPagosClienteTablasFinales();

                        //Cerramos el formulario
                        Close();
                    }
                }
                else
                {
                    //Si estabmos editando eliminamos los documentos
                    if (_G_Estado_Formulario == TiposEstadoPago.EstadoPagoEditar) _Mtd_EliminarDocumentos(_Txt_IdDocumento.Text);

                    //Guardamos 
                    _Mtd_GuardarPago();

                    //Eliminamos todos los pagos que se hayan pasado a las tablas finales
                    _Mtd_EliminarPagosClienteTablasFinales();

                    //Cerramos el formulario
                    Close();
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

        private void _Mtd_EliminarPagosClienteTablasFinales()
        {
            //Cargamos los pagos del cliente
            var _Str_SQL = "select cidpago from TTRCPAGOM where ccompany='" + _G_Enum_Pago.Compañia + "' and cguia='" + _G_Enum_Pago.Guia + "' and ccliente='" + _G_Enum_Pago.Cliente + "' and cdelete='0' ";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    var _Str_cidpago = _Row["cidpago"].ToString();
                    _Mtd_EliminarPago(_Str_cidpago, true);
                }
            }
        }

        private void _Btn_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _Txt_NumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void _Txt_MontoDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar)) && (e.KeyChar != ',') && (e.KeyChar != '.')))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.'))
            {
                e.KeyChar = ',';
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
            
            _Txt_Saldo.Text = _Mtd_ObtenerSaldoDelosDocumentosSeleccionados().ToString("c");
        }

        private void _Txt_MontoDocumento_Leave(object sender, EventArgs e)
        {
            if (_Txt_MontoDocumento.Text != "")
            {
                _Txt_MontoDocumento.Tag = Convert.ToDouble(_Txt_MontoDocumento.Text);
                _Txt_MontoDocumento.Text = Convert.ToDouble(_Txt_MontoDocumento.Tag.ToString()).ToString("c");
            }
            else
            {
                if (_Txt_MontoDocumento.Tag != null)
                {
                    _Txt_MontoDocumento.Text = _Txt_MontoDocumento.Tag.ToString();
                }
            }
            _Txt_Saldo.Text = _Mtd_ObtenerSaldoDelosDocumentosSeleccionados().ToString("c");
        }

        private void _Txt_MontoDocumento_Enter(object sender, EventArgs e)
        {
            if (_Txt_MontoDocumento.Tag != null)
            {
                _Txt_MontoDocumento.Text = _Txt_MontoDocumento.Tag.ToString();
            }
        }

        private void _Txt_MontoDocumento_Click(object sender, EventArgs e)
        {
            if (_Txt_MontoDocumento.Tag != null)
            {
                _Txt_MontoDocumento.Text = _Txt_MontoDocumento.Tag.ToString();
            }
        }

        private void _Mnu_Eliminar_Click(object sender, EventArgs e)
        {
            _Dtg_Retenciones.Rows.Remove(_Dtg_Retenciones.CurrentRow);

            _Txt_Saldo.Text = _Mtd_ObtenerSaldoDelosDocumentosSeleccionados().ToString("c");
        }

        private void _Dtp_FechaEmision_ValueChanged(object sender, EventArgs e)
        {
            if (_Dtp_FechaEmision.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show
                    (
                        "La fecha de emisión no puede ser mayor al día de hoy.",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                _Dtp_FechaEmision.Value = DateTime.Now.Date;

                return;
            }
        }

        private void _Dtp_FechaDepositar_ValueChanged(object sender, EventArgs e)
        {
            if (_Dtp_FechaDepositar.Value.Date < _Dtp_FechaEmision.Value.Date)
            {
                MessageBox.Show
                    (
                        "La fecha de depósito no puede ser menor a la de emisión.",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                _Dtp_FechaDepositar.Value = DateTime.Now.Date;

                return;
            }
        }

        #endregion
    }
}