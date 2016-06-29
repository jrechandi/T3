using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using T3.Clases;

namespace T3
{
    public partial class Frm_IC_Cobranza : Form
    {
        string _G_Str_SentenciaSQL;
        string _G_Str_ValorCeldaTem = "XXXX";
        DataSet _G_Ds_CobranzaEncabezado = new DataSet();
        DataSet _G_Ds_CobranzaDetalle = new DataSet();
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public enum _G_EnumTipoDeProceso : byte { Creando = 0, Modificando, Consultando, EnEspera };
        public enum _G_EnumTipoDeEstado : int { PorAprobar = 0, Aprobada, Devuelta };
        _G_EnumTipoDeEstado _G_Int_EstadoCobranza;
        _G_EnumTipoDeProceso _G_Int_Proceso = _G_EnumTipoDeProceso.EnEspera;
        int _G_Int_IdDocumento;
        string _G_Str_MensajeDeError = "";
        bool _G_Bol_PermisoCreacion;
        bool _G_Bol_PermisoAprobacion;
        int _G_Int_cidiccobram;
        int _G_Int_cidcobranzaic;
        int _G_Int_cidcomprob;
        bool _G_Bol_FormularioYaCargado = false;
        int _G_Int_EstadoCobranzaConsulta;

        public Frm_IC_Cobranza()
        {
            InitializeComponent();
        }

        public Frm_IC_Cobranza(int _P_Int_EstadoCobranza)
        {
            InitializeComponent();
            _G_Int_EstadoCobranzaConsulta = _P_Int_EstadoCobranza;
        }

        /// <summary>
        /// Inicializa el Formulario para crear un Cobranza Intercompañia, segun los parámetros dados
        /// </summary>
        /// <param name="_P_Str_cproveedor">Proveedor</param>
        /// <param name="_P_Str_ctipodocumento">Tipos de documento</param>
        /// <param name="_P_Str_cnumdocu">Numeros de documento</param>
        public Frm_IC_Cobranza(string _P_Str_cproveedor, string[] _P_Str_ctipodocumento, string[] _P_Str_cnumdocu, Form _P_Form_MdiParent)
        {
            InitializeComponent();
            this.MdiParent = _P_Form_MdiParent;
            _Mtd_CargarCombosCompañiasRelacionadas();
            _Mtd_CargarComboEstado();
            _Mtd_CargarComboTiposDocumentoDePago();
            _Mtd_CargarPermisos();
            int _Int_Indice;
            string _Str_ctipodocumento;
            string _Str_cnumdocu;
            //Valido
            if (_P_Str_ctipodocumento.Length == 0)
            {
                return;
            }
            else if (_P_Str_ctipodocumento == null)
            {
                return;
            }
            else if (_P_Str_cnumdocu == null)
            {
                return;
            }
            //Si todo bien
            //Inicializo el formulario en nuevo
            _Mtd_Nuevo();
            //Selecciono el Proveedor proporcionado
            _Cmb_CompaniaRelacionada.SelectedValue = _P_Str_cproveedor;
            //Cargo los Documentos (SEGUN NOBRE LARGO)
            for (_Int_Indice = 0; _Int_Indice < _P_Str_ctipodocumento.GetLength(0); _Int_Indice++)
            {
                //Obtengo los valores
                _Str_ctipodocumento = _P_Str_ctipodocumento[_Int_Indice];
                _Str_cnumdocu = _P_Str_cnumdocu[_Int_Indice];

                //Consulto desde la Vista
                _G_Str_SentenciaSQL = "";
                _G_Str_SentenciaSQL += "SELECT ";
                _G_Str_SentenciaSQL += "CONVERT(varchar,cfechaemision,103) AS [Emisión] ";
                _G_Str_SentenciaSQL += ",CONVERT(varchar,cfechavencimiento,103) AS [Vencimiento] ";
                _G_Str_SentenciaSQL += ",cnumdocu AS [Documento] ";
                _G_Str_SentenciaSQL += ",ctipo AS [Tipo] ";
                _G_Str_SentenciaSQL += ",cmonto AS [Monto] ";
                _G_Str_SentenciaSQL += "FROM [VST_CONSOLIDADO_INTERCOMPANIAS] ";
                _G_Str_SentenciaSQL += "WHERE ";
                _G_Str_SentenciaSQL += "cproveedor = '" + _P_Str_cproveedor + "' ";
                _G_Str_SentenciaSQL += "AND ";
                _G_Str_SentenciaSQL += "ccompany = '" + Frm_Padre._Str_Comp + "' ";
                _G_Str_SentenciaSQL += "AND ";
                _G_Str_SentenciaSQL += "ctipo = '" + _Str_ctipodocumento + "' ";
                _G_Str_SentenciaSQL += "AND ";
                _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_cnumdocu + "' ";

                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
                DataRow _Dtr_Registro = _Ds.Tables[0].Rows[0];

                //Paso los datos
                string _Str_FechaEmision = _Dtr_Registro["Emisión"].ToString();
                string _Str_Vencimiento = _Dtr_Registro["Vencimiento"].ToString();
                string _Str_Documento = _Dtr_Registro["Documento"].ToString();
                string _Str_Monto = Convert.ToDouble(_Dtr_Registro["Monto"].ToString()).ToString("#,##0.00");
                string _Str_TipoDocumentoLargo = _Dtr_Registro["Tipo"].ToString();
                string _Str_TipoDocumentoCorto = _Mtd_ConvertirTipoDocumentoDeLargoACorto(_Str_TipoDocumentoLargo);
                int _Int_IndiceFilaNueva;

                //En función al tipo de documento
                switch (_Str_TipoDocumentoLargo)
                {
                    case "FACTURA CXC":
                    case "NOTA DE DEBITO CXP":
                    case "NOTA DE CREDITO PROVEEDOR CXP":
                    case "NOTA DE DEBITO CXC":
                    case "AVISO DE COBRO CXC":
                        //Agrego al grid
                        _Int_IndiceFilaNueva = _Dg_DocCobr.RowCount;
                        _Dg_DocCobr.Rows.Add();
                        _Dg_DocCobr["_Dg_DocCob_Col_Emision", _Int_IndiceFilaNueva].Value = _Str_FechaEmision;
                        _Dg_DocCobr["_Dg_DocCob_Col_Vencimiento", _Int_IndiceFilaNueva].Value = _Str_Vencimiento;
                        _Dg_DocCobr["_Dg_DocCob_Col_Documento", _Int_IndiceFilaNueva].Value = _Str_Documento;
                        _Dg_DocCobr["_Dg_DocCob_Col_Tipo", _Int_IndiceFilaNueva].Value = _Str_TipoDocumentoLargo;
                        _Dg_DocCobr["_Dg_DocCob_Col_Monto", _Int_IndiceFilaNueva].Value = Convert.ToDouble(_Str_Monto).ToString("#,##0.00");
                        break;
                    case "FACTURA CXP":
                    case "NOTA DE CREDITO CXP":
                    case "NOTA DE DEBITO PROVEEDOR CXP":
                    case "NOTA DE CREDITO CXC":
                    case "AVISO DE COBRO CXP":
                        _Int_IndiceFilaNueva = _Dg_DocPago.RowCount;
                        _Dg_DocPago.Rows.Add();
                        _Dg_DocPago["_Dg_DocPag_Col_Emision", _Int_IndiceFilaNueva].Value = _Str_FechaEmision;
                        _Dg_DocPago["_Dg_DocPag_Col_Vencimiento", _Int_IndiceFilaNueva].Value = _Str_Vencimiento;
                        _Dg_DocPago["_Dg_DocPag_Col_Documento", _Int_IndiceFilaNueva].Value = _Str_Documento;
                        _Dg_DocPago["_Dg_DocPag_Col_Tipo", _Int_IndiceFilaNueva].Value = _Str_TipoDocumentoLargo;
                        _Dg_DocPago["_Dg_DocPag_Col_Monto", _Int_IndiceFilaNueva].Value = Convert.ToDouble(_Str_Monto).ToString("#,##0.00");
                        _Dg_DocPago["_Dg_DocPag_Col_BancoEmisor", _Int_IndiceFilaNueva].Value = "NO APLICA";
                        _Dg_DocPago["_Dg_DocPag_Col_BancoDeposito", _Int_IndiceFilaNueva].Value = "NO APLICA";
                        _Dg_DocPago["_Dg_DocPag_Col_NumeroCuenta", _Int_IndiceFilaNueva].Value = "NO APLICA";
                        _Dg_DocPago["_Dg_DocPag_Col_cbancoemisor", _Int_IndiceFilaNueva].Value = "NO APLICA";
                        _Dg_DocPago["_Dg_DocPag_Col_cbancodeposito", _Int_IndiceFilaNueva].Value = "NO APLICA";
                        _Dg_DocPago["_Dg_DocPag_Col_cnumcuenta", _Int_IndiceFilaNueva].Value = "NO APLICA";
                        break;
                    case "CHEQUE":
                    case "TRANSFERENCIA":
                        _Int_IndiceFilaNueva = _Dg_DocPago.RowCount;
                        _Dg_DocPago.Rows.Add();
                        _Dg_DocPago["_Dg_DocPag_Col_Emision", _Int_IndiceFilaNueva].Value = _Str_FechaEmision;
                        _Dg_DocPago["_Dg_DocPag_Col_Vencimiento", _Int_IndiceFilaNueva].Value = _Str_Vencimiento;
                        _Dg_DocPago["_Dg_DocPag_Col_Documento", _Int_IndiceFilaNueva].Value = _Str_Documento;
                        _Dg_DocPago["_Dg_DocPag_Col_Tipo", _Int_IndiceFilaNueva].Value = _Str_TipoDocumentoLargo;
                        _Dg_DocPago["_Dg_DocPag_Col_Monto", _Int_IndiceFilaNueva].Value = Convert.ToDouble(_Str_Monto).ToString("#,##0.00");
                        _Dg_DocPago["_Dg_DocPag_Col_BancoEmisor", _Int_IndiceFilaNueva].Value = "NO APLICA";
                        _Dg_DocPago["_Dg_DocPag_Col_BancoDeposito", _Int_IndiceFilaNueva].Value = "NO APLICA";
                        _Dg_DocPago["_Dg_DocPag_Col_NumeroCuenta", _Int_IndiceFilaNueva].Value = "NO APLICA";
                        _Dg_DocPago["_Dg_DocPag_Col_cbancoemisor", _Int_IndiceFilaNueva].Value = "NO APLICA";
                        _Dg_DocPago["_Dg_DocPag_Col_cbancodeposito", _Int_IndiceFilaNueva].Value = "NO APLICA";
                        _Dg_DocPago["_Dg_DocPag_Col_cnumcuenta", _Int_IndiceFilaNueva].Value = "NO APLICA";
                        break;
                }
            }

            //Actualizmos los Montos
            _Mtd_ActualizarMontosGrids();

            //Bandera par que no recargue el formulario
            _G_Bol_FormularioYaCargado = true;
        }
        /// <summary>
        /// Cargar Cobranza según su Id
        /// </summary>
        /// <param name="_P_Int_IdDocumento"></param>
        public void _Mtd_CargarCobranza(string _P_Str_ccompany, int _P_Int_IdDocumento)
        {
            //Cargo los Datos del Encabezado
            _G_Str_SentenciaSQL = "SELECT ";
            _G_Str_SentenciaSQL += " CONVERT(VARCHAR,TICCOBRAM.cfecha,103) AS [Fecha] ";
            _G_Str_SentenciaSQL += ", TICCOBRAM.ccompany as [Cod com.] ";
            _G_Str_SentenciaSQL += ", TPROVEEDOR.c_nomb_comer as [Compañía relacionada] ";
            _G_Str_SentenciaSQL += ", dbo.Fnc_Formatear(cmonto) as [Monto] ";
            _G_Str_SentenciaSQL += ", TICCOBRAM.cestado ";
            _G_Str_SentenciaSQL += ", TICCOBRAM.cproveedor ";
            _G_Str_SentenciaSQL += ", TICCOBRAM.cidcomprob ";
            _G_Str_SentenciaSQL += ", TICCOBRAM.cidcobranzaic ";
            _G_Str_SentenciaSQL += ", TICCOBRAM.cidiccobram ";
            _G_Str_SentenciaSQL += ", [Estado] = ";
            _G_Str_SentenciaSQL += "     CASE cestado ";
            _G_Str_SentenciaSQL += "       WHEN 0 THEN 'POR APROBAR' ";
            _G_Str_SentenciaSQL += "       WHEN 1 THEN 'APROBADA' ";
            _G_Str_SentenciaSQL += "       WHEN 2 THEN 'DEVUELTA' ";
            _G_Str_SentenciaSQL += "     END ";
            _G_Str_SentenciaSQL += "FROM TICCOBRAM INNER JOIN TPROVEEDOR ";
            _G_Str_SentenciaSQL += "ON TICCOBRAM.cproveedor = TPROVEEDOR.cproveedor ";
            _G_Str_SentenciaSQL += "WHERE ";
            _G_Str_SentenciaSQL += "TICCOBRAM.CCOMPANY='" + _P_Str_ccompany + "' ";
            _G_Str_SentenciaSQL += "AND ";
            _G_Str_SentenciaSQL += "TICCOBRAM.cidcobranzaic = " + _P_Int_IdDocumento + " ";
            _G_Ds_CobranzaEncabezado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);

            //Cargo los Datos de los Detalles DE CxC
            _G_Str_SentenciaSQL = "";
            _G_Str_SentenciaSQL += "SELECT ";
            _G_Str_SentenciaSQL += "CONVERT(varchar,cfechaemision,103) AS [Emisión] ";
            _G_Str_SentenciaSQL += ",CONVERT(varchar,cfechavencimiento,103) AS [Vencimiento] ";
            _G_Str_SentenciaSQL += ",CONVERT(VARCHAR, cnumdocu) AS [Documento] ";
            _G_Str_SentenciaSQL += ",ctipodocument AS [Tipo] ";
            _G_Str_SentenciaSQL += ",'NO APLICA' AS [Banco emisor] ";
            _G_Str_SentenciaSQL += ",'NO APLICA' AS [Banco deposito] ";
            _G_Str_SentenciaSQL += ",'NO APLICA' AS [Numero cuenta] ";
            _G_Str_SentenciaSQL += ",cmonto AS [Monto] ";
            _G_Str_SentenciaSQL += ",ccompany ";
            _G_Str_SentenciaSQL += ",'NO APLICA'  AS  [cbancoemisor] ";
            _G_Str_SentenciaSQL += ",'NO APLICA'  AS  [cbancodeposito] ";
            _G_Str_SentenciaSQL += ",'NO APLICA'  AS  [cnumcuenta] ";
            _G_Str_SentenciaSQL += ",'TICCOBRAD_CXC'  AS  [Archivo] ";
            _G_Str_SentenciaSQL += "FROM TICCOBRAD_CXC ";
            _G_Str_SentenciaSQL += "WHERE ";
            _G_Str_SentenciaSQL += "cidcobranzaic = " + _P_Int_IdDocumento + " ";
            _G_Str_SentenciaSQL += "AND ";
            _G_Str_SentenciaSQL += "ccompany = '" + _P_Str_ccompany + "' ";

            _G_Str_SentenciaSQL += "UNION ALL ";

            //Cargo los Datos de los Detalles DE CxP
            _G_Str_SentenciaSQL += "SELECT ";
            _G_Str_SentenciaSQL += "CONVERT(varchar,cfechaemision,103) AS [Emisión] ";
            _G_Str_SentenciaSQL += ",CONVERT(varchar,cfechavencimiento,103) AS [Vencimiento] ";
            _G_Str_SentenciaSQL += ",CONVERT(VARCHAR, cnumdocu) AS [Documento] ";
            _G_Str_SentenciaSQL += ",ctipodocument AS [Tipo] ";
            _G_Str_SentenciaSQL += ",'NO APLICA' AS [Banco emisor] ";
            _G_Str_SentenciaSQL += ",'NO APLICA' AS [Banco deposito] ";
            _G_Str_SentenciaSQL += ",'NO APLICA' AS [Numero cuenta] ";
            _G_Str_SentenciaSQL += ",cmonto AS [Monto] ";
            _G_Str_SentenciaSQL += ",ccompany ";
            _G_Str_SentenciaSQL += ",'NO APLICA'  AS  [cbancoemisor] ";
            _G_Str_SentenciaSQL += ",'NO APLICA'  AS  [cbancodeposito] ";
            _G_Str_SentenciaSQL += ",'NO APLICA'  AS  [cnumcuenta] ";
            _G_Str_SentenciaSQL += ",'TICCOBRAD_CXP'  AS  [Archivo] ";
            _G_Str_SentenciaSQL += "FROM TICCOBRAD_CXP ";
            _G_Str_SentenciaSQL += "WHERE ";
            _G_Str_SentenciaSQL += "cidcobranzaic = " + _P_Int_IdDocumento + " ";
            _G_Str_SentenciaSQL += "AND ";
            _G_Str_SentenciaSQL += "ccompany = '" + _P_Str_ccompany + "' ";

            _G_Str_SentenciaSQL += "UNION ALL ";

            //Cargo los Datos de los Detalles DE Pag
            _G_Str_SentenciaSQL += "SELECT ";
            _G_Str_SentenciaSQL += "CONVERT(varchar,cfechaemision,103) AS [Emisión] ";
            _G_Str_SentenciaSQL += ",CONVERT(varchar,cfechavencimiento,103) AS [Vencimiento] ";
            _G_Str_SentenciaSQL += ",cnumdocu AS [Documento] ";
            _G_Str_SentenciaSQL += ",ctipodocument AS [Tipo] ";
            _G_Str_SentenciaSQL += ",TBANCOEMISOR.cname AS [Banco Emisor] ";
            _G_Str_SentenciaSQL += ",TBANCODEPOSITO.cname AS [Banco Deposito] ";
            _G_Str_SentenciaSQL += ",TCUENTBANCDEPOSITO.cname AS [Numero Cuenta] ";
            _G_Str_SentenciaSQL += ",cmonto AS [Monto] ";
            _G_Str_SentenciaSQL += ",TICCOBRAD_PAG.ccompany ";
            _G_Str_SentenciaSQL += ",TICCOBRAD_PAG.cbancoemisor ";
            _G_Str_SentenciaSQL += ",TICCOBRAD_PAG.cbancodeposito ";
            _G_Str_SentenciaSQL += ",TICCOBRAD_PAG.cnumcuenta ";
            _G_Str_SentenciaSQL += ",'TICCOBRAD_PAG' AS [Archivo] ";

            _G_Str_SentenciaSQL += "FROM ";
            _G_Str_SentenciaSQL += "TCUENTBANC AS TCUENTBANCDEPOSITO INNER JOIN ";
            _G_Str_SentenciaSQL += "TBANCO AS TBANCODEPOSITO INNER JOIN ";
            _G_Str_SentenciaSQL += "TICCOBRAD_PAG INNER JOIN ";
            _G_Str_SentenciaSQL += "TBANCO AS TBANCOEMISOR ";
            _G_Str_SentenciaSQL += "ON TICCOBRAD_PAG.ccompany = TBANCOEMISOR.ccompany AND TICCOBRAD_PAG.cbancoemisor = TBANCOEMISOR.cbanco ";
            _G_Str_SentenciaSQL += "ON TBANCODEPOSITO.ccompany = TICCOBRAD_PAG.ccompany AND TBANCODEPOSITO.cbanco = TICCOBRAD_PAG.cbancodeposito ";
            _G_Str_SentenciaSQL += "ON TCUENTBANCDEPOSITO.ccompany = TBANCODEPOSITO.ccompany AND TCUENTBANCDEPOSITO.cbanco = TBANCODEPOSITO.cbanco ";

            _G_Str_SentenciaSQL += "WHERE ";
            _G_Str_SentenciaSQL += "cidcobranzaic = " + _P_Int_IdDocumento + " ";
            _G_Str_SentenciaSQL += "AND ";
            _G_Str_SentenciaSQL += "TICCOBRAD_PAG.ccompany = '" + _P_Str_ccompany + "' ";

            _G_Ds_CobranzaDetalle = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);

            //Ids
            _G_Int_cidiccobram = Convert.ToInt32(_G_Ds_CobranzaEncabezado.Tables[0].Rows[0]["cidiccobram"].ToString());
            _G_Int_cidcobranzaic = Convert.ToInt32(_G_Ds_CobranzaEncabezado.Tables[0].Rows[0]["cidcobranzaic"].ToString());
            _G_Int_cidcomprob = Convert.ToInt32(_G_Ds_CobranzaEncabezado.Tables[0].Rows[0]["cidcomprob"].ToString());

            //Cargamos los Controles del Detalle
            _Txt_IdCobranza.Text = _P_Int_IdDocumento.ToString();
            _Cmb_CompaniaRelacionada.SelectedValue = _G_Ds_CobranzaEncabezado.Tables[0].Rows[0]["cproveedor"].ToString();
            _Txt_Estado.Text = _G_Ds_CobranzaEncabezado.Tables[0].Rows[0]["Estado"].ToString();
            _G_Int_EstadoCobranza = (_G_EnumTipoDeEstado)Enum.Parse(typeof(_G_EnumTipoDeEstado), _G_Ds_CobranzaEncabezado.Tables[0].Rows[0]["cestado"].ToString());
            _Txt_Fecha.Text = Convert.ToString(_G_Ds_CobranzaEncabezado.Tables[0].Rows[0]["Fecha"].ToString());

            //Cargamos los Detalles
            _Dg_DocCobr.Rows.Clear();
            _Dg_DocPago.Rows.Clear();

            foreach (DataRow _Dtr_Registro in _G_Ds_CobranzaDetalle.Tables[0].Rows)
            {
                //Obtengo los valoree
                string _Str_FechaEmision = _Dtr_Registro["Emisión"].ToString();
                string _Str_Vencimiento = _Dtr_Registro["Vencimiento"].ToString();
                string _Str_Documento = _Dtr_Registro["Documento"].ToString();
                string _Str_Monto = Convert.ToDouble(_Dtr_Registro["Monto"].ToString()).ToString("#,##0.00");

                string _Str_Archivo = _Dtr_Registro["Archivo"].ToString();

                string _Str_TipoDocumentoOriginal = _Dtr_Registro["Tipo"].ToString();
                string _Str_TipoDocumentoLargo = _Mtd_ConvertirTipoDocumentoDeCortoALargo(_Str_TipoDocumentoOriginal, _Str_Archivo);

                string _Str_BancoEmisor = _Dtr_Registro["Banco Emisor"].ToString();
                string _Str_BancoDesposito = _Dtr_Registro["Banco Deposito"].ToString();
                string _Str_NumeroCuenta = _Dtr_Registro["Numero Cuenta"].ToString();

                string _Str_Compañia = _Dtr_Registro["ccompany"].ToString();

                string _Str_cbancoemisor = _Dtr_Registro["cbancoemisor"].ToString();
                string _Str_cbancodeposito = _Dtr_Registro["cbancodeposito"].ToString();
                string _Str_cnumcuenta = _Dtr_Registro["cnumcuenta"].ToString();

                int _Int_IndiceFilaNueva;

                //En función al tipo de documento
                switch (_Str_TipoDocumentoLargo)
                {
                    case "FACTURA CXC":
                    case "NOTA DE CREDITO CXC":
                    case "NOTA DE DEBITO CXC":
                    case "AVISO DE COBRO CXC":
                        _Int_IndiceFilaNueva = _Dg_DocCobr.RowCount;
                        _Dg_DocCobr.Rows.Add();
                        _Dg_DocCobr["_Dg_DocCob_Col_Emision", _Int_IndiceFilaNueva].Value = _Str_FechaEmision;
                        _Dg_DocCobr["_Dg_DocCob_Col_Vencimiento", _Int_IndiceFilaNueva].Value = _Str_Vencimiento;
                        _Dg_DocCobr["_Dg_DocCob_Col_Documento", _Int_IndiceFilaNueva].Value = _Str_Documento;
                        _Dg_DocCobr["_Dg_DocCob_Col_Tipo", _Int_IndiceFilaNueva].Value = _Str_TipoDocumentoLargo;
                        _Dg_DocCobr["_Dg_DocCob_Col_Monto", _Int_IndiceFilaNueva].Value = Convert.ToDouble(_Str_Monto).ToString("#,##0.00");
                        break;
                    case "FACTURA CXP":
                    case "NOTA DE CREDITO CXP":
                    case "NOTA DE DEBITO CXP":
                    case "NOTA DE CREDITO PROVEEDOR CXP":
                    case "NOTA DE DEBITO PROVEEDOR CXP":
                    case "AVISO DE COBRO CXP":
                        _Int_IndiceFilaNueva = _Dg_DocPago.RowCount;
                        _Dg_DocPago.Rows.Add();
                        _Dg_DocPago["_Dg_DocPag_Col_Emision", _Int_IndiceFilaNueva].Value = _Str_FechaEmision;
                        _Dg_DocPago["_Dg_DocPag_Col_Vencimiento", _Int_IndiceFilaNueva].Value = _Str_Vencimiento;
                        _Dg_DocPago["_Dg_DocPag_Col_Documento", _Int_IndiceFilaNueva].Value = _Str_Documento;
                        _Dg_DocPago["_Dg_DocPag_Col_Tipo", _Int_IndiceFilaNueva].Value = _Str_TipoDocumentoLargo;
                        _Dg_DocPago["_Dg_DocPag_Col_Monto", _Int_IndiceFilaNueva].Value = Convert.ToDouble(_Str_Monto).ToString("#,##0.00");
                        _Dg_DocPago["_Dg_DocPag_Col_BancoEmisor", _Int_IndiceFilaNueva].Value = "NO APLICA";
                        _Dg_DocPago["_Dg_DocPag_Col_BancoDeposito", _Int_IndiceFilaNueva].Value = "NO APLICA";
                        _Dg_DocPago["_Dg_DocPag_Col_NumeroCuenta", _Int_IndiceFilaNueva].Value = "NO APLICA";
                        _Dg_DocPago["_Dg_DocPag_Col_cbancoemisor", _Int_IndiceFilaNueva].Value = "NO APLICA";
                        _Dg_DocPago["_Dg_DocPag_Col_cbancodeposito", _Int_IndiceFilaNueva].Value = "NO APLICA";
                        _Dg_DocPago["_Dg_DocPag_Col_cnumcuenta", _Int_IndiceFilaNueva].Value = "NO APLICA";
                        break;
                    case "CHEQUE":
                    case "TRANSFERENCIA":
                        _Int_IndiceFilaNueva = _Dg_DocPago.RowCount;
                        _Dg_DocPago.Rows.Add();
                        _Dg_DocPago["_Dg_DocPag_Col_Emision", _Int_IndiceFilaNueva].Value = _Str_FechaEmision;
                        _Dg_DocPago["_Dg_DocPag_Col_Vencimiento", _Int_IndiceFilaNueva].Value = _Str_Vencimiento;
                        _Dg_DocPago["_Dg_DocPag_Col_Documento", _Int_IndiceFilaNueva].Value = _Str_Documento;
                        _Dg_DocPago["_Dg_DocPag_Col_Tipo", _Int_IndiceFilaNueva].Value = _Str_TipoDocumentoLargo;
                        _Dg_DocPago["_Dg_DocPag_Col_Monto", _Int_IndiceFilaNueva].Value = Convert.ToDouble(_Str_Monto).ToString("#,##0.00");

                        _Dg_DocPago["_Dg_DocPag_Col_BancoEmisor", _Int_IndiceFilaNueva].Value = _Str_BancoEmisor;
                        _Dg_DocPago["_Dg_DocPag_Col_BancoDeposito", _Int_IndiceFilaNueva].Value = _Str_BancoDesposito;
                        _Dg_DocPago["_Dg_DocPag_Col_NumeroCuenta", _Int_IndiceFilaNueva].Value = _Str_NumeroCuenta;

                        _Dg_DocPago["_Dg_DocPag_Col_cbancoemisor", _Int_IndiceFilaNueva].Value = _Str_cbancoemisor;
                        _Dg_DocPago["_Dg_DocPag_Col_cbancodeposito", _Int_IndiceFilaNueva].Value = _Str_cbancodeposito;
                        _Dg_DocPago["_Dg_DocPag_Col_cnumcuenta", _Int_IndiceFilaNueva].Value = _Str_cnumcuenta;
                        break;
                }
            }


            //Mostramos los Montos
            _Txt_MontoTotalDocumentosCobrados.Text = _Mtd_CalcularTotalMontosDocumentoCobrados().ToString("#,##0.00");
            _Txt_MontoTotalDocumentosDePago.Text = _Mtd_CalcularTotalMontosDocumentoDePago().ToString("#,##0.00");

            //Para el Comprobante contable
            if (_G_Int_EstadoCobranza == _G_EnumTipoDeEstado.Aprobada)
            {
                _Bt_VisualizarComprobante.Text = "Visualizar comprobante...";
                _Bt_VisualizarComprobante.Enabled = false;
            }
            else if (_G_Int_EstadoCobranza == _G_EnumTipoDeEstado.Devuelta)
            {
                _Bt_VisualizarComprobante.Text = "Visualizar comprobante...";
                _Bt_VisualizarComprobante.Enabled = false;
            }
            else if (_G_Int_EstadoCobranza == _G_EnumTipoDeEstado.PorAprobar)
            {
                _Bt_VisualizarComprobante.Text = "Visualizar comprobante...";
                _Bt_VisualizarComprobante.Enabled = false;
            }
            _Mtd_VisualizarComprobanteEmitido();


        }
        /// <summary>
        /// Calcula el Monto Total de grid de Documentos Cobrados
        /// </summary>
        /// <returns></returns>
        private double _Mtd_CalcularTotalMontosDocumentoCobrados()
        {
            double _Dbl_Acum = 0;
            foreach (DataGridViewRow _DgRow in _Dg_DocCobr.Rows)
            {
                if (Convert.ToString(_DgRow.Cells["_Dg_DocCob_Col_Monto"].Value) != "")
                {
                    _Dbl_Acum += Convert.ToDouble(_DgRow.Cells["_Dg_DocCob_Col_Monto"].Value);
                }
            }
            return _Dbl_Acum;
        }
        /// <summary>
        /// Calcula el Monto Total de grid de Documentos de Pago
        /// </summary>
        /// <returns></returns>
        private double _Mtd_CalcularTotalMontosDocumentoDePago()
        {
            double _Dbl_Acum = 0;
            foreach (DataGridViewRow _DgRow in _Dg_DocPago.Rows)
            {
                if (Convert.ToString(_DgRow.Cells["_Dg_DocPag_Col_Monto"].Value) != "")
                {
                    _Dbl_Acum += Convert.ToDouble(_DgRow.Cells["_Dg_DocPag_Col_Monto"].Value);
                }
            }
            return _Dbl_Acum;
        }

        private void _Mtd_ColocarBotones()
        {
            if (_G_Int_Proceso == _G_EnumTipoDeProceso.Creando)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
                _Bt_AprobarCobranza.Enabled = false;
                _Bt_DevolverCobranza.Enabled = false;
                _Bt_GuadarCobranza.Enabled = true;
                _Bt_Cancelar.Enabled = true;
            }
            else if (_G_Int_Proceso == _G_EnumTipoDeProceso.Modificando)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
                _Bt_AprobarCobranza.Enabled = false;
                _Bt_DevolverCobranza.Enabled = false;
                _Bt_GuadarCobranza.Enabled = true;
                _Bt_Cancelar.Enabled = true;
            }
            else if (_G_Int_Proceso == _G_EnumTipoDeProceso.Consultando)
            {
                if (_G_Int_EstadoCobranza == _G_EnumTipoDeEstado.Aprobada)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
                    _Bt_AprobarCobranza.Enabled = false;
                    _Bt_DevolverCobranza.Enabled = false;
                    _Bt_GuadarCobranza.Enabled = false;
                    _Bt_Cancelar.Enabled = true;
                }
                else if (_G_Int_EstadoCobranza == _G_EnumTipoDeEstado.Devuelta)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true & _G_Bol_PermisoCreacion; 
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
                    _Bt_AprobarCobranza.Enabled = false;
                    _Bt_DevolverCobranza.Enabled = false;
                    _Bt_GuadarCobranza.Enabled = false;
                    _Bt_Cancelar.Enabled = true;
                }
                else if (_G_Int_EstadoCobranza == _G_EnumTipoDeEstado.PorAprobar)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
                    _Bt_AprobarCobranza.Enabled = true & _G_Bol_PermisoAprobacion;
                    _Bt_DevolverCobranza.Enabled = true & _G_Bol_PermisoAprobacion;
                    _Bt_GuadarCobranza.Enabled = false;
                    _Bt_Cancelar.Enabled = true;
                }
            }
            else if (_G_Int_Proceso == _G_EnumTipoDeProceso.EnEspera)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true & _G_Bol_PermisoCreacion;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
                _Bt_AprobarCobranza.Enabled = false;
                _Bt_DevolverCobranza.Enabled = false;
                _Bt_GuadarCobranza.Enabled = false;
                _Bt_Cancelar.Enabled = false;
            }
        }
        private void _Mtd_CargarPermisos()
        {
            _G_Bol_PermisoCreacion = _myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_IC_COBRANZA_CREAR");
            _G_Bol_PermisoAprobacion = _myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_IC_COBRANZA_APROBAR");
        }
        private void Frm_CobranzaIC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            if (!_G_Bol_FormularioYaCargado)
            {
                _G_Int_Proceso = _G_EnumTipoDeProceso.EnEspera;
                _Mtd_CargarCombosCompañiasRelacionadas();
                _Mtd_CargarComboEstado();
                //Selecciono el item del combo a mostrar
                _Cmb_Estado.SelectedIndex = _G_Int_EstadoCobranzaConsulta;
                _Mtd_CargarComboTiposDocumentoDePago();
                _Mtd_Consultar();
                _Mtd_Deshabilitar();
                _Mtd_ColocarBotones();
                _Mtd_CargarPermisos();
            }

        }
        private void _Mtd_CargarCombo(ComboBox _Pr_Cb, string _Str_Sql)
        {
            DataSet _Ds;
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Pr_Cb.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("TODAS", "nulo"));
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString(), _DRow[0].ToString().Trim()));
            }
            _Pr_Cb.DataSource = _myArrayList;
            _Pr_Cb.DisplayMember = "Display";
            _Pr_Cb.ValueMember = "Value";
            _Pr_Cb.SelectedValue = "nulo";
        }

        /// <summary>
        /// Carga del combo de compañías relacionadas
        /// </summary>
        private void _Mtd_CargarCombosCompañiasRelacionadas()
        {
            try
            {
                _G_Str_SentenciaSQL = "SELECT ";
                _G_Str_SentenciaSQL += "TPROVEEDOR.cproveedor";
                _G_Str_SentenciaSQL += ",TPROVEEDOR.cproveedor + ' - ' + TPROVEEDOR.c_nomb_comer AS c_nomb_abreviado ";
                _G_Str_SentenciaSQL += "FROM TICRELAPROCLI INNER JOIN TPROVEEDOR ";
                _G_Str_SentenciaSQL += "ON TICRELAPROCLI.cproveedor = TPROVEEDOR.cproveedor ";
                _G_Str_SentenciaSQL += "WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                //En Consulta
                _Mtd_CargarCombo(_Cmb_CompaniaRelacionadaCons, _G_Str_SentenciaSQL);
                //En Detalle
                _myUtilidad._Mtd_CargarCombo(_Cmb_CompaniaRelacionada, _G_Str_SentenciaSQL);
            }
            catch
            {
            }
        }
        /// <summary>
        /// Carga el Combo de los Estados
        /// </summary>
        private void _Mtd_CargarComboEstado()
        {

            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("TODAS", "nulo"));
            string[,] _Str_Listado = null;
            _Str_Listado = new string[,] { { "POR APROBAR", "0" }, { "APROBADAS", "1" }, { "DEVUELTAS", "2" } };
            for (int _Int_I = 0; _Int_I < _Str_Listado.GetLength(0); _Int_I++)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_Str_Listado[_Int_I, 0].ToUpper(), _Str_Listado[_Int_I, 1]));
            }
            _Cmb_Estado.DataSource = _myArrayList;
            _Cmb_Estado.DisplayMember = "Display";
            _Cmb_Estado.ValueMember = "Value";
            _Cmb_Estado.SelectedValue = "0";
        }
        /// <summary>
        /// Carga Combo de tipos de documento de pago
        /// </summary>
        private void _Mtd_CargarComboTiposDocumentoDePago()
        {

            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            //_myArrayList.Add(new T3.Clases._Cls_ArrayList("TODAS", "nulo"));
            string[,] _Str_Listado = null;
            _Str_Listado = new string[,] { { "DOCUMENTO INTERCOMPAÑIA", "0" }, { "CHEQUE O TRANSFERENCIA", "1" } };
            for (int _Int_I = 0; _Int_I < _Str_Listado.GetLength(0); _Int_I++)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_Str_Listado[_Int_I, 0].ToUpper(), _Str_Listado[_Int_I, 1]));
            }
            _Cmb_TipoDeDocumentoDePago.DataSource = _myArrayList;
            _Cmb_TipoDeDocumentoDePago.DisplayMember = "Display";
            _Cmb_TipoDeDocumentoDePago.ValueMember = "Value";
            _Cmb_TipoDeDocumentoDePago.SelectedValue = "0";
        }
        /// <summary>
        /// Evento del boton consultar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Btn_Consultar_Click(object sender, EventArgs e)
        {
            _Mtd_Consultar();
        }
        /// <summary>
        /// Método para la consulta de cobranza por estatus por estatus 
        /// </summary>
        private void _Mtd_Consultar()
        {
            try
            {
                string _Str_Proveedor = "";
                if (_Cmb_CompaniaRelacionadaCons.SelectedValue != null)
                {
                    if (_Cmb_CompaniaRelacionadaCons.SelectedValue.ToString() != "nulo")
                    {
                        _Str_Proveedor = _Cmb_CompaniaRelacionadaCons.SelectedValue.ToString();
                    }
                }

                string _Str_Estado = "";
                if (_Cmb_Estado.SelectedValue != null)
                {
                    if (_Cmb_Estado.SelectedValue.ToString() != "nulo")
                    {
                        _Str_Estado = _Cmb_Estado.SelectedValue.ToString();
                    }
                }

                string _Str_Where = "";
                if (_Str_Proveedor.Length > 0)
                {
                    _Str_Where += " AND TICCOBRAM.cproveedor = '" + _Str_Proveedor + "' ";
                }
                if (_Str_Estado.Length > 0)
                {
                    _Str_Where += " AND TICCOBRAM.cestado = " + _Str_Estado + " ";
                }

                _G_Str_SentenciaSQL = "SELECT ";
                _G_Str_SentenciaSQL += " CONVERT(VARCHAR,TICCOBRAM.cfecha,103) AS [Fecha] ";
                _G_Str_SentenciaSQL += ", TICCOBRAM.cproveedor as [Cod com.] ";
                _G_Str_SentenciaSQL += ", TPROVEEDOR.c_nomb_comer as [Compañía relacionada] ";
                _G_Str_SentenciaSQL += ", dbo.Fnc_Formatear(cmonto) as [Monto] ";
                _G_Str_SentenciaSQL += ", [Estado] = ";
                _G_Str_SentenciaSQL += "     CASE cestado ";
                _G_Str_SentenciaSQL += "       WHEN 0 THEN 'POR APROBAR' ";
                _G_Str_SentenciaSQL += "       WHEN 1 THEN 'APROBADA' ";
                _G_Str_SentenciaSQL += "       WHEN 2 THEN 'DEVUELTA' ";
                _G_Str_SentenciaSQL += "     END ";
                _G_Str_SentenciaSQL += ", TICCOBRAM.cidiccobram as [cidiccobram] ";
                _G_Str_SentenciaSQL += ", TICCOBRAM.cidcobranzaic as [cidcobranzaic] ";
                _G_Str_SentenciaSQL += ", TICCOBRAM.cestado as [cestado] ";
                _G_Str_SentenciaSQL += "FROM TICCOBRAM INNER JOIN TPROVEEDOR ";
                _G_Str_SentenciaSQL += "ON TICCOBRAM.cproveedor = TPROVEEDOR.cproveedor ";
                _G_Str_SentenciaSQL += "WHERE ";
                _G_Str_SentenciaSQL += "TICCOBRAM.CCOMPANY='" + Frm_Padre._Str_Comp + "'" + _Str_Where;

                _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL).Tables[0];
                _Dg_Grid.Columns["Compañía relacionada"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                _Dg_Grid.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns["cidiccobram"].Visible = false;
                _Dg_Grid.Columns["cidcobranzaic"].Visible = false;
                _Dg_Grid.Columns["cestado"].Visible = false;
            }
            catch (Exception _Err_)
            {
            }

        }
        /// <summary>
        /// Método nuevo de la botonera
        /// </summary>
        public void _Mtd_Nuevo()
        {
            _G_Int_Proceso = _G_EnumTipoDeProceso.Creando;
            _Mtd_Ini();
            _Txt_Fecha.Text = _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate());
            _Tb_Tab.SelectedIndex = 1;
            _Mtd_ColocarBotones();
        }
        /// <summary>
        /// Evento activated del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_CobranzaIC_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;

            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true & _G_Bol_PermisoCreacion;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;

            //_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" 
            //_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_IC_COBRANZA_CREAR");
            //_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_IC_COBRANZA_APROBAR");


        }

        public void _Mtd_Cancelar()
        {
            _G_Int_Proceso = _G_EnumTipoDeProceso.EnEspera;
            _Mtd_Consultar();
            _Mtd_Deshabilitar();
            _Mtd_ColocarBotones();
            _Tb_Tab.SelectedIndex = 0;
        }
        /// <summary>
        /// Método que inicializa el formulario
        /// </summary>
        public void _Mtd_Ini()
        {
            //Controles
            _Cmb_CompaniaRelacionada.SelectedIndex = 0;
            _Cmb_CompaniaRelacionada.Enabled = true;
            _Txt_Estado.Text = "POR APROBAR";
            _Txt_Fecha.Text = "";
            //Documentos Cobrados
            _Dg_DocCobr.Rows.Clear();
            _Txt_MontoTotalDocumentosCobrados.Text = "0,00";
            _Bt_AgregarDocumentosCobrados.Enabled = true;
            //Documentos de Pago
            _Dg_DocPago.Rows.Clear();
            _Txt_MontoTotalDocumentosDePago.Text = "0,00";
            _Cmb_TipoDeDocumentoDePago.Enabled = true;
            _Bt_AgregarDocumentosDePago.Enabled = true;
            //Comprobante
            _Bt_VisualizarComprobante.Enabled = true;
            _Dg_Comprobante.Rows.Clear();
            //Grid del Comprobante
            //_Dg_Comprobante.CellClick -= new DataGridViewCellEventHandler(_Dg_Comprobante_CellClick);
            //_Dg_Comprobante.CellEndEdit -= new DataGridViewCellEventHandler(_Dg_Comprobante_CellEndEdit);
            //_Dg_Comprobante.CellBeginEdit -= new DataGridViewCellCancelEventHandler(_Dg_Comprobante_CellBeginEdit);
            //_Dg_Comprobante.EditingControlShowing -= new DataGridViewEditingControlShowingEventHandler(_Dg_Comprobante_EditingControlShowing);
            //_Dg_Comprobante.CellClick += new DataGridViewCellEventHandler(_Dg_Comprobante_CellClick);
            //_Dg_Comprobante.CellEndEdit += new DataGridViewCellEventHandler(_Dg_Comprobante_CellEndEdit);
            //_Dg_Comprobante.CellBeginEdit += new DataGridViewCellCancelEventHandler(_Dg_Comprobante_CellBeginEdit);
            //_Dg_Comprobante.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(_Dg_Comprobante_EditingControlShowing);
        }

        /// <summary>
        /// Evento de FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_CobranzaIC_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        /// <summary>
        /// Verifica si el monto es mayor a 0 o está vacio.
        /// </summary>
        /// <param name="_P_Txt_TextBox"></param>
        /// <returns></returns>
        private bool _Mtd_VerifContTextBoxNumeric(TextBox _P_Txt_TextBox)
        {
            if (_P_Txt_TextBox.Text.Trim().Length > 0)
            {
                if (Convert.ToDouble(_P_Txt_TextBox.Text) > 0)
                { return true; }
            }
            return false;
        }
        /// <summary>
        /// Evento del botón
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Bt_VisualizarComprobante_Click(object sender, EventArgs e)
        {
            if (_Mtd_Validar(false))
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_VisualizarComprobante();
                Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// Verifica si todas las cuentas existen
        /// </summary>
        /// <returns></returns>
        private bool _Mtd_VerificarCuentas()
        {
            DataSet _Ds = new DataSet();
            string _Str_Cadena = "";
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells[0].Value).Trim().Length > 0)
                {
                    _Str_Cadena = "Select ctcount from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _Dg_Row.Cells[0].Value.ToString() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count == 0)
                    { return false; }
                    else if (_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper() != "D")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Método que valida al guardar la Cobranza
        /// </summary>
        /// <returns>Retorna si es valido o no</returns>
        private bool _Mtd_Validar(bool _P_Bol_ValidarComprobante = true)
        {
            _Er_Error.Dispose();
            //No se ha cargado el combo de las compañias relacionadas
            if (_Cmb_CompaniaRelacionada.SelectedValue == null)
            {
                _Er_Error.SetError(_Cmb_CompaniaRelacionada, "Información Requerida!!!");
                MessageBox.Show("Debe seleccionar una compañia relacionada.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //No se ha seleccionado la compañia relacionada
            if (_Cmb_CompaniaRelacionada.SelectedValue.ToString() == "nulo")
            {
                _Er_Error.SetError(_Cmb_CompaniaRelacionada, "Información Requerida!!!");
                MessageBox.Show("Debe seleccionar una compañia relacionada.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //El comprobante contable esta vacio
            if (_Dg_Comprobante.RowCount == 0 && _P_Bol_ValidarComprobante)
            {
                _Er_Error.SetError(_Dg_Comprobante, "Información Requerida!!!");
                MessageBox.Show("Debe generar la vista previa del comprobante contable antes de continuar.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //El comprobante contable no esta cuadrado
            if (!_Mtd_EstaCuadradoComprobanteContable() && _P_Bol_ValidarComprobante)
            {
                _Er_Error.SetError(_Dg_Comprobante, "Información Requerida!!!");
                MessageBox.Show("El comprobante contable no está cuadrado. Por favor verifique.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //No hay documentos cobrados
            if (_Dg_DocCobr.RowCount == 0)
            {
                _Er_Error.SetError(_Txt_MontoTotalDocumentosCobrados, "Información Requerida!!!");
                MessageBox.Show("No hay documentos cobrados. Por favor verifique.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //El monto de los documentos cobrados es menor que cero
            if (Convert.ToDouble(_Txt_MontoTotalDocumentosCobrados.Text) < 0)
            {
                _Er_Error.SetError(_Txt_MontoTotalDocumentosCobrados, "Información Requerida!!!");
                MessageBox.Show("El monto total de documentos cobrados debe ser mayor o igual a cero. Por favor verifique.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //El monto de los documentos de pago es mayor a cero
            if (Convert.ToDouble(_Txt_MontoTotalDocumentosDePago.Text) > 0)
            {
                _Er_Error.SetError(_Txt_MontoTotalDocumentosDePago, "Información Requerida!!!");
                MessageBox.Show("El monto total de documentos de pago debe ser menor o igual a cero. Por favor verifique.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Diferencia entre documentos cobrados y de pago
            double _Dbl_Saldo = Math.Round(Convert.ToDouble(_Txt_MontoTotalDocumentosCobrados.Text) + Convert.ToDouble(_Txt_MontoTotalDocumentosDePago.Text), 2);
            if (_Dbl_Saldo != 0)
            {
                _Er_Error.SetError(_Txt_MontoTotalDocumentosCobrados, "Información Requerida!!!");
                _Er_Error.SetError(_Txt_MontoTotalDocumentosDePago, "Información Requerida!!!");
                MessageBox.Show("El monto total de documentos cobrados y el monto total de documentos de pago deben saldarse entre sí. Por favor verifique.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Documentos cobrados validos
            if (!_Mtd_VerificarSiSonValidosDocumentosCobrados())
            {
                _Er_Error.SetError(_Dg_DocCobr, "Información Requerida!!!");
                MessageBox.Show(_G_Str_MensajeDeError, "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Documentos de pago validos
            if (!_Mtd_VerificarSiSonValidosDocumentosDePago())
            {
                _Er_Error.SetError(_Dg_DocPago, "Información Requerida!!!");
                MessageBox.Show(_G_Str_MensajeDeError, "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Si lleganos aqui, pasaron todas la validaciones
            return true;
        }
        private bool _Mtd_VerificarSiSonValidosDocumentosCobrados()
        {
            _G_Str_MensajeDeError = "";
            string _Str_SQL = "";
            string _Str_Compañia = "";
            string _Str_Proveedor = "";
            string _Str_TipoDocumentoLargo = "";
            string _Str_TipoDocumentoCorto = "";
            string _Str_cbancoemisor = "";
            string _Str_NombreTabla = "";
            string _Str_NumeroDocumento;
            int _Int_NumeroDeCobranza;
            DataSet _Ds;
            //recorro los documentos
            foreach (DataGridViewRow _DgRow in _Dg_DocCobr.Rows)
            {

                //Tomo los valores
                _Str_Compañia = Frm_Padre._Str_Comp;
                _Str_Proveedor = _Cmb_CompaniaRelacionada.SelectedValue.ToString();
                _Str_TipoDocumentoLargo = _DgRow.Cells["_Dg_DocCob_Col_Tipo"].Value.ToString();
                _Str_TipoDocumentoCorto = _Mtd_ConvertirTipoDocumentoDeLargoACorto(_Str_TipoDocumentoLargo);
                _Str_NombreTabla = _Mtd_ConvertirTipoDocumentoLargoANombreDeTabla(_Str_TipoDocumentoLargo);
                _Str_NumeroDocumento = _DgRow.Cells["_Dg_DocCob_Col_Documento"].Value.ToString();
                _Str_cbancoemisor = "";

                //En función al tipo de Documento verifico en que tabla puede estar para verificar si existe
                switch (_Str_NombreTabla)
                {
                    case "TICCOBRAD_CXC":
                        //Genero el SQL de busqueda
                        _Str_SQL += "";
                        _Str_SQL += "SELECT ";
                        _Str_SQL += "TICCOBRAM.ccompany ";
                        _Str_SQL += ",TICCOBRAM.cproveedor ";
                        _Str_SQL += ",TICCOBRAD_CXC.ctipodocument ";
                        _Str_SQL += ",TICCOBRAD_CXC.cnumdocu ";
                        _Str_SQL += ",TICCOBRAM.cidcobranzaic ";
                        _Str_SQL += "FROM ";
                        _Str_SQL += "TICCOBRAM INNER JOIN ";
                        _Str_SQL += "TICCOBRAD_CXC ";
                        _Str_SQL += "ON dbo.TICCOBRAM.ccompany = dbo.TICCOBRAD_CXC.ccompany ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "TICCOBRAM.cidcobranzaic = dbo.TICCOBRAD_CXC.cidcobranzaic ";
                        _Str_SQL += "WHERE ";
                        _Str_SQL += "(dbo.TICCOBRAM.cestado <> " + (int)_G_EnumTipoDeEstado.Devuelta + ") ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAM.ccompany = '" + _Str_Compañia + "') ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAD_CXC.cnumdocu = " + _Str_NumeroDocumento + ") ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAD_CXC.ctipodocument = '" + _Str_TipoDocumentoCorto + "') ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAM.cproveedor = '" + _Str_Proveedor + "') ";
                        //Si estamos modificando, tampoco tome en cuenta la cobranza actual
                        if (_G_Int_Proceso == _G_EnumTipoDeProceso.Modificando)
                        {
                            _Str_SQL += "AND ";
                            _Str_SQL += "(TICCOBRAM.cidcobranzaic <> " + _G_Int_cidcobranzaic + ") ";
                        }
                        //Consulto
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                        //Verifico
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            //Obtengo el Numer de Cobranza
                            _Int_NumeroDeCobranza = Convert.ToInt32(_Ds.Tables[0].Rows[0]["cidcobranzaic"].ToString());
                            //Genero el Mensaje
                            _G_Str_MensajeDeError += "El siguiente documento ya se encuentra en la Cobranza No. " + _Int_NumeroDeCobranza + ". Por favor verifique:  -" + _Str_TipoDocumentoLargo + "-, No. " + _Str_NumeroDocumento + "";
                            return false;
                        }
                        break;
                    case "TICCOBRAD_CXP":
                        //Genero el SQL de busqueda
                        _Str_SQL += "";
                        _Str_SQL += "SELECT ";
                        _Str_SQL += "TICCOBRAM.ccompany ";
                        _Str_SQL += ",TICCOBRAM.cproveedor ";
                        _Str_SQL += ",TICCOBRAD_CXP.ctipodocument ";
                        _Str_SQL += ",TICCOBRAD_CXP.cnumdocu ";
                        _Str_SQL += ",TICCOBRAM.cidcobranzaic ";
                        _Str_SQL += "FROM ";
                        _Str_SQL += "TICCOBRAM INNER JOIN ";
                        _Str_SQL += "TICCOBRAD_CXP ";
                        _Str_SQL += "ON dbo.TICCOBRAM.ccompany = dbo.TICCOBRAD_CXP.ccompany ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "TICCOBRAM.cidcobranzaic = dbo.TICCOBRAD_CXP.cidcobranzaic ";
                        _Str_SQL += "WHERE ";
                        _Str_SQL += "(dbo.TICCOBRAM.cestado <> " + (int)_G_EnumTipoDeEstado.Devuelta + ") ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAM.ccompany = '" + _Str_Compañia + "') ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAD_CXP.cnumdocu = " + _Str_NumeroDocumento + ") ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAD_CXP.ctipodocument = '" + _Str_TipoDocumentoCorto + "') ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAM.cproveedor = '" + _Str_Proveedor + "') ";
                        //Si estamos modificando, tampoco tome en cuenta la cobranza actual
                        if (_G_Int_Proceso == _G_EnumTipoDeProceso.Modificando)
                        {
                            _Str_SQL += "AND ";
                            _Str_SQL += "(TICCOBRAM.cidcobranzaic <> " + _G_Int_cidcobranzaic + ") ";
                        }
                        //Consulto
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                        //Verifico
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            //Obtengo el Numer de Cobranza
                            _Int_NumeroDeCobranza = Convert.ToInt32(_Ds.Tables[0].Rows[0]["cidcobranzaic"].ToString());
                            //Genero el Mensaje
                            _G_Str_MensajeDeError += "El siguiente documento ya se encuentra en la Cobranza No. " + _Int_NumeroDeCobranza + ". Por favor verifique:  -" + _Str_TipoDocumentoLargo + "-, No. " + _Str_NumeroDocumento + "";
                            return false;
                        }
                        break;
                    case "TICCOBRAD_PAG":
                        //Genero el SQL de busqueda
                        _Str_SQL += "";
                        _Str_SQL += "SELECT ";
                        _Str_SQL += "TICCOBRAM.ccompany ";
                        _Str_SQL += ",TICCOBRAM.cproveedor ";
                        _Str_SQL += ",TICCOBRAD_PAG.ctipodocument ";
                        _Str_SQL += ",TICCOBRAD_PAG.cnumdocu ";
                        _Str_SQL += ",TICCOBRAM.cidcobranzaic ";
                        _Str_SQL += "FROM ";
                        _Str_SQL += "TICCOBRAM INNER JOIN ";
                        _Str_SQL += "TICCOBRAD_PAG ";
                        _Str_SQL += "ON dbo.TICCOBRAM.ccompany = dbo.TICCOBRAD_PAG.ccompany ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "TICCOBRAM.cidcobranzaic = dbo.TICCOBRAD_PAG.cidcobranzaic ";
                        _Str_SQL += "WHERE ";
                        _Str_SQL += "(dbo.TICCOBRAM.cestado <> " + (int)_G_EnumTipoDeEstado.Devuelta + ") ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAD_PAG.cnumdocu = " + _Str_NumeroDocumento + ") ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAD_PAG.ctipodocument = '" + _Str_TipoDocumentoCorto + "') ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAD_PAG.cbancoemisor = '" + _Str_cbancoemisor + "') ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAM.ccompany = '" + _Str_Compañia + "') ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAM.cproveedor = '" + _Str_Proveedor + "') ";
                        //Si estamos modificando, tampoco tome en cuenta la cobranza actual
                        if (_G_Int_Proceso == _G_EnumTipoDeProceso.Modificando)
                        {
                            _Str_SQL += "AND ";
                            _Str_SQL += "(TICCOBRAM.cidcobranzaic <> " + _G_Int_cidcobranzaic + ") ";
                        }
                        //Consulto
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                        //Verifico
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            //Obtengo el Numer de Cobranza
                            _Int_NumeroDeCobranza = Convert.ToInt32(_Ds.Tables[0].Rows[0]["cidcobranzaic"].ToString());
                            //Genero el Mensaje
                            _G_Str_MensajeDeError += "El siguiente documento ya se encuentra en la Cobranza No. " + _Int_NumeroDeCobranza + ". Por favor verifique:  -" + _Str_TipoDocumentoLargo + "-, No. " + _Str_NumeroDocumento + "";
                            return false;
                        }
                        break;
                }

            }
            return true;
        }
        private bool _Mtd_VerificarSiSonValidosDocumentosDePago()
        {
            _G_Str_MensajeDeError = "";
            string _Str_SQL = "";
            string _Str_Compañia = "";
            string _Str_Proveedor = "";
            string _Str_TipoDocumentoLargo = "";
            string _Str_TipoDocumentoCorto = "";
            string _Str_cbancoemisor = "";
            string _Str_NombreTabla = "";
            string _Str_NumeroDocumento;
            int _Int_NumeroDeCobranza;
            DataSet _Ds;
            //recorro los documentos
            foreach (DataGridViewRow _DgRow in _Dg_DocPago.Rows)
            {
                //Tomo los valores
                _Str_Compañia = Frm_Padre._Str_Comp;
                _Str_Proveedor = _Cmb_CompaniaRelacionada.SelectedValue.ToString();
                _Str_TipoDocumentoLargo = _DgRow.Cells["_Dg_DocPag_Col_Tipo"].Value.ToString();
                _Str_TipoDocumentoCorto = _Mtd_ConvertirTipoDocumentoDeLargoACorto(_Str_TipoDocumentoLargo);
                _Str_NombreTabla = _Mtd_ConvertirTipoDocumentoLargoANombreDeTabla(_Str_TipoDocumentoLargo);
                _Str_cbancoemisor = _DgRow.Cells["_Dg_DocPag_Col_cbancoemisor"].Value.ToString();
                _Str_NumeroDocumento = _DgRow.Cells["_Dg_DocPag_Col_Documento"].Value.ToString();
                //En función al tipo de Documento verifico en que tabla puede estar para verificar si existe
                switch (_Str_NombreTabla)
                {
                    case "TICCOBRAD_CXC":
                        //Genero el SQL de busqueda
                        _Str_SQL += "";
                        _Str_SQL += "SELECT ";
                        _Str_SQL += "TICCOBRAM.ccompany ";
                        _Str_SQL += ",TICCOBRAM.cproveedor ";
                        _Str_SQL += ",TICCOBRAD_CXC.ctipodocument ";
                        _Str_SQL += ",TICCOBRAD_CXC.cnumdocu ";
                        _Str_SQL += ",TICCOBRAM.cidcobranzaic ";
                        _Str_SQL += "FROM ";
                        _Str_SQL += "TICCOBRAM INNER JOIN ";
                        _Str_SQL += "TICCOBRAD_CXC ";
                        _Str_SQL += "ON dbo.TICCOBRAM.ccompany = dbo.TICCOBRAD_CXC.ccompany ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "TICCOBRAM.cidcobranzaic = dbo.TICCOBRAD_CXC.cidcobranzaic ";
                        _Str_SQL += "WHERE ";
                        _Str_SQL += "(dbo.TICCOBRAM.cestado <> " + (int)_G_EnumTipoDeEstado.Devuelta + ") ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAM.ccompany = '" + _Str_Compañia + "') ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAD_CXC.cnumdocu = " + _Str_NumeroDocumento + ") ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAD_CXC.ctipodocument = '" + _Str_TipoDocumentoCorto + "') ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAM.cproveedor = '" + _Str_Proveedor + "') ";
                        //Si estamos modificando, tampoco tome en cuenta la cobranza actual
                        if (_G_Int_Proceso == _G_EnumTipoDeProceso.Modificando)
                        {
                            _Str_SQL += "AND ";
                            _Str_SQL += "(TICCOBRAM.cidcobranzaic <> " + _G_Int_cidcobranzaic + ") ";
                        }
                        //Consulto
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                        //Verifico
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            //Obtengo el Numer de Cobranza
                            _Int_NumeroDeCobranza = Convert.ToInt32(_Ds.Tables[0].Rows[0]["cidcobranzaic"].ToString());
                            //Genero el Mensaje
                            _G_Str_MensajeDeError += "El siguiente documento ya se encuentra en la Cobranza No. " + _Int_NumeroDeCobranza + ". Por favor verifique:  -" + _Str_TipoDocumentoLargo + "-, No. " + _Str_NumeroDocumento + "";
                            return false;
                        }
                        break;
                    case "TICCOBRAD_CXP":
                        //Genero el SQL de busqueda
                        _Str_SQL += "";
                        _Str_SQL += "SELECT ";
                        _Str_SQL += "TICCOBRAM.ccompany ";
                        _Str_SQL += ",TICCOBRAM.cproveedor ";
                        _Str_SQL += ",TICCOBRAD_CXP.ctipodocument ";
                        _Str_SQL += ",TICCOBRAD_CXP.cnumdocu ";
                        _Str_SQL += ",TICCOBRAM.cidcobranzaic ";
                        _Str_SQL += "FROM ";
                        _Str_SQL += "TICCOBRAM INNER JOIN ";
                        _Str_SQL += "TICCOBRAD_CXP ";
                        _Str_SQL += "ON dbo.TICCOBRAM.ccompany = dbo.TICCOBRAD_CXP.ccompany ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "TICCOBRAM.cidcobranzaic = dbo.TICCOBRAD_CXP.cidcobranzaic ";
                        _Str_SQL += "WHERE ";
                        _Str_SQL += "(dbo.TICCOBRAM.cestado <> " + (int)_G_EnumTipoDeEstado.Devuelta + ") ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAM.ccompany = '" + _Str_Compañia + "') ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAD_CXP.cnumdocu = '" + _Str_NumeroDocumento + "') ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAD_CXP.ctipodocument = '" + _Str_TipoDocumentoCorto + "') ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAM.cproveedor = '" + _Str_Proveedor + "') ";
                        //Si estamos modificando, tampoco tome en cuenta la cobranza actual
                        if (_G_Int_Proceso == _G_EnumTipoDeProceso.Modificando)
                        {
                            _Str_SQL += "AND ";
                            _Str_SQL += "(TICCOBRAM.cidcobranzaic <> " + _G_Int_cidcobranzaic + ") ";
                        }
                        //Consulto
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                        //Verifico
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            //Obtengo el Numer de Cobranza
                            _Int_NumeroDeCobranza = Convert.ToInt32(_Ds.Tables[0].Rows[0]["cidcobranzaic"].ToString());
                            //Genero el Mensaje
                            _G_Str_MensajeDeError += "El siguiente documento ya se encuentra en la Cobranza No. " + _Int_NumeroDeCobranza + ". Por favor verifique:  -" + _Str_TipoDocumentoLargo + "-, No. " + _Str_NumeroDocumento + "";
                            return false;
                        }
                        break;
                    case "TICCOBRAD_PAG":
                        //Genero el SQL de busqueda
                        _Str_SQL += "";
                        _Str_SQL += "SELECT ";
                        _Str_SQL += "TICCOBRAM.ccompany ";
                        _Str_SQL += ",TICCOBRAM.cproveedor ";
                        _Str_SQL += ",TICCOBRAD_PAG.ctipodocument ";
                        _Str_SQL += ",TICCOBRAD_PAG.cnumdocu ";
                        _Str_SQL += ",TICCOBRAM.cidcobranzaic ";
                        _Str_SQL += "FROM ";
                        _Str_SQL += "TICCOBRAM INNER JOIN ";
                        _Str_SQL += "TICCOBRAD_PAG ";
                        _Str_SQL += "ON dbo.TICCOBRAM.ccompany = dbo.TICCOBRAD_PAG.ccompany ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "TICCOBRAM.cidcobranzaic = dbo.TICCOBRAD_PAG.cidcobranzaic ";
                        _Str_SQL += "WHERE ";
                        _Str_SQL += "(dbo.TICCOBRAM.cestado <> " + (int)_G_EnumTipoDeEstado.Devuelta + ") ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAD_PAG.cnumdocu = '" + _Str_NumeroDocumento + "') ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAD_PAG.ctipodocument = '" + _Str_TipoDocumentoCorto + "') ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAD_PAG.cbancoemisor = '" + _Str_cbancoemisor + "') ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAM.ccompany = '" + _Str_Compañia + "') ";
                        _Str_SQL += "AND ";
                        _Str_SQL += "(TICCOBRAM.cproveedor = '" + _Str_Proveedor + "') ";
                        //Si estamos modificando, tampoco tome en cuenta la cobranza actual
                        if (_G_Int_Proceso == _G_EnumTipoDeProceso.Modificando)
                        {
                            _Str_SQL += "AND ";
                            _Str_SQL += "(TICCOBRAM.cidcobranzaic <> " + _G_Int_cidcobranzaic + ") ";
                        }
                        //Consulto
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                        //Verifico
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            //Obtengo el Numer de Cobranza
                            _Int_NumeroDeCobranza = Convert.ToInt32(_Ds.Tables[0].Rows[0]["cidcobranzaic"].ToString());
                            //Genero el Mensaje
                            _G_Str_MensajeDeError += "El siguiente documento ya se encuentra en la Cobranza No. " + _Int_NumeroDeCobranza + ". Por favor verifique:  -" + _Str_TipoDocumentoLargo + "-, No. " + _Str_NumeroDocumento + "";
                            return false;
                        }
                        break;
                }
            }
            return true;
        }
        private bool _Mtd_EstaCuadradoComprobanteContable()
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            object _Ob_DebeD = new object();
            object _Ob_HaberD = new object();
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells["Cuenta"].Value != null)
                {
                    if (_Dg_Row.Cells["Cuenta"].Value.ToString().Trim().Length > 0)
                    {
                        _Ob_DebeD = _Dg_Row.Cells["Debe"].Value;
                        if (_Ob_DebeD == null)
                        { _Ob_DebeD = 0; }
                        else if (_Ob_DebeD.ToString().Trim().Length == 0)
                        { _Ob_DebeD = 0; }
                        //---------------------------
                        _Ob_HaberD = _Dg_Row.Cells["Haber"].Value;
                        if (_Ob_HaberD == null)
                        { _Ob_HaberD = 0; }
                        else if (_Ob_HaberD.ToString().Trim().Length == 0)
                        { _Ob_HaberD = 0; }
                        _Dbl_Debe += Convert.ToDouble(_Ob_DebeD);
                        _Dbl_Haber += Convert.ToDouble(_Ob_HaberD);
                    }
                }
            }
            //verifico
            double _Dbl_Saldo = Math.Round(_Dbl_Debe - _Dbl_Haber, 2);
            if (_Dbl_Saldo == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Método para visualizar el comprobante contable para la carga.
        /// </summary>
        /// <param name="_P_Str_ProcesoCont">Código del Proceso contable</param>
        private void _Mtd_VisualizarComprobante()
        {
            string _Str_ProcesoCont = "P_CXC_COBRO_CIA_RELA";
            //Borro el grid del comprobante
            _Dg_Comprobante.Rows.Clear();
            //Inicializo la clase
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont(_Str_ProcesoCont);
            //Cargo la Plantilla en el grid
            _My_Cls_ProcesosCont._Mtd_Proceso_P_CXC_COBRO_CIA_RELA(_Dg_Comprobante);
            //Verifico que se hayan traido la plantilla
            if (_Dg_Comprobante.RowCount > 0)
            {

                //Obtengo la plantilla de los Cheques y Transferencias
                PlantillaCuentaContable _Plantilla_ChequesYTransferencias_IC = new PlantillaCuentaContable();
                _Plantilla_ChequesYTransferencias_IC.Cuenta = "";
                _Plantilla_ChequesYTransferencias_IC.Descripcion = "";
                _Plantilla_ChequesYTransferencias_IC.Naturaleza = "D"; 

                //Obtengo la plantilla de las CXC IC
                PlantillaCuentaContable _Plantilla_CxC_IC = new PlantillaCuentaContable();
                _Plantilla_CxC_IC.Cuenta = _Dg_Comprobante.Rows[0].Cells["Cuenta"].Value.ToString();
                _Plantilla_CxC_IC.Descripcion = _Dg_Comprobante.Rows[0].Cells["Descripcion"].Value.ToString();
                if (_Dg_Comprobante.Rows[0].Cells["Debe"].Value.ToString() == "")
                { _Plantilla_CxC_IC.Naturaleza = "H"; }
                else
                { _Plantilla_CxC_IC.Naturaleza = "D"; }

                //Obtengo la plantilla de las CXP IC
                PlantillaCuentaContable _Plantilla_CxP_IC = new PlantillaCuentaContable();
                _Plantilla_CxP_IC.Cuenta = _Dg_Comprobante.Rows[1].Cells["Cuenta"].Value.ToString();
                _Plantilla_CxP_IC.Descripcion = _Dg_Comprobante.Rows[1].Cells["Descripcion"].Value.ToString();
                if (_Dg_Comprobante.Rows[1].Cells["Debe"].Value.ToString() == "")
                { _Plantilla_CxP_IC.Naturaleza = "H"; }
                else
                { _Plantilla_CxP_IC.Naturaleza = "D"; }


                //Borro el comprobante, porque ya obtuve las plantillas necesarias
                _Dg_Comprobante.Rows.Clear();

                //Cargo las cuentas los documentos cobrados
                foreach (DataGridViewRow _DgRow in _Dg_DocCobr.Rows)
                {
                    //Tomo los valores
                    string _Str_Compañia = Frm_Padre._Str_Comp;
                    string _Str_cprovedor = _Cmb_CompaniaRelacionada.SelectedValue.ToString();
                    string _Str_Proveedor = _Mtd_ObtenerProveedor(_Str_cprovedor);
                    string _Str_Cliente = _Mtd_ObtenerCliente(_Str_cprovedor);
                    string _Str_TipoDocumento = _DgRow.Cells["_Dg_DocCob_Col_Tipo"].Value.ToString();
                    string _Str_TipoDocumentoCorto = _Mtd_ConvertirTipoDocumentoDeLargoACorto(_Str_TipoDocumento);
                    string _Str_FechaEmision = _DgRow.Cells["_Dg_DocCob_Col_Emision"].Value.ToString();
                    string _Str_FechaVencimiento = _DgRow.Cells["_Dg_DocCob_Col_Vencimiento"].Value.ToString();
                    String _Str_BancoEmisor = "";
                    String _Str_BancoDeposito = "";
                    String _Str_cbancoemisor = "";
                    String _Str_cbancodeposito = "";
                    String _Str_cnumcuenta = "";
                    string _Str_NumeroDocumento = _DgRow.Cells["_Dg_DocCob_Col_Documento"].Value.ToString();
                    decimal _Dcl_Monto = Convert.ToDecimal(_DgRow.Cells["_Dg_DocCob_Col_Monto"].Value);

                    //Genero los valores a guardar en el comprobante
                    string _Str_Cuenta = "";
                    string _Str_Naturaleza = "";
                    string _Str_Descripcion = "";
                    switch (_Str_TipoDocumento)
                    {
                        case "FACTURA CXC":
                            _Str_Cuenta = _Plantilla_CxC_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_CxC_IC.Naturaleza;
                            _Str_Descripcion = _Plantilla_CxC_IC.Descripcion + " " + _Str_Cliente + " " + " COBRO " + _Str_TipoDocumento + ":" + _Str_NumeroDocumento + " VEC:" + _Str_FechaVencimiento;
                            break;
                        case "NOTA DE DEBITO CXP":
                            _Str_Cuenta = _Plantilla_CxP_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_CxP_IC.Naturaleza;
                            _Str_Descripcion = _Plantilla_CxP_IC.Descripcion + " " + _Str_Proveedor + " SEGUN " + _Str_TipoDocumento + " #" + _Str_NumeroDocumento;
                            break;
                        case "NOTA DE CREDITO PROVEEDOR CXP":
                            _Str_Cuenta = _Plantilla_CxP_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_CxP_IC.Naturaleza;
                            _Str_Descripcion = _Plantilla_CxP_IC.Descripcion + " " + _Str_Proveedor + " SEGUN " + _Str_TipoDocumento + " #" + _Str_NumeroDocumento;
                            break;
                        case "NOTA DE DEBITO CXC":
                            _Str_Cuenta = _Plantilla_CxC_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_CxC_IC.Naturaleza;
                            _Str_Descripcion = _Plantilla_CxC_IC.Descripcion + " " + _Str_Cliente + " " + " COBRO " + _Str_TipoDocumento + " #" + _Str_NumeroDocumento;
                            break;
                        case "FACTURA CXP":
                            _Str_Cuenta = _Plantilla_CxP_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_CxP_IC.Naturaleza;
                            _Str_Descripcion = _Plantilla_CxP_IC.Descripcion + " " + _Str_Proveedor + " CANCELACION " + _Str_TipoDocumento + ":" + _Str_NumeroDocumento + " VEC:" + _Str_FechaVencimiento;
                            break;
                        case "NOTA DE CREDITO CXP":
                            _Str_Cuenta = _Plantilla_CxP_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_CxP_IC.Naturaleza;
                            _Str_Descripcion = _Plantilla_CxP_IC.Descripcion + " " + _Str_Proveedor + " CANCELACION " + _Str_TipoDocumento + " #" + _Str_NumeroDocumento;
                            break;
                        case "NOTA DE DEBITO PROVEEDOR CXP":
                            _Str_Cuenta = _Plantilla_CxP_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_CxP_IC.Naturaleza;
                            _Str_Descripcion = _Plantilla_CxP_IC.Descripcion + " " + _Str_Proveedor + " CANCELACION " + _Str_TipoDocumento + " #" + _Str_NumeroDocumento;
                            break;
                        case "NOTA DE CREDITO CXC":
                            _Str_Cuenta = _Plantilla_CxC_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_CxC_IC.Naturaleza;
                            _Str_Descripcion = _Plantilla_CxC_IC.Descripcion + " " + _Str_Cliente + " " + " SEGUN " + _Str_TipoDocumento + " #" + _Str_NumeroDocumento;
                            break;
                        case "CHEQUE":
                            _Str_Cuenta = _Plantilla_ChequesYTransferencias_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_ChequesYTransferencias_IC.Naturaleza;
                            _Str_Descripcion = _Str_BancoDeposito + " CHEQUE #" + _Str_NumeroDocumento + " DEL BANCO " + _Str_BancoEmisor;
                            break;
                        case "TRANSFERENCIA":
                            _Str_Cuenta = _Plantilla_ChequesYTransferencias_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_ChequesYTransferencias_IC.Naturaleza;
                            _Str_Descripcion = _Str_BancoDeposito + " TRANSFERENCIA #" + _Str_NumeroDocumento + " DEL BANCO " + _Str_BancoEmisor;
                            break;
                        case "AVISO DE COBRO CXC":
                            _Str_Cuenta = _Plantilla_CxC_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_CxC_IC.Naturaleza;
                            _Str_Descripcion = _Plantilla_CxC_IC.Descripcion + " AVISO DE COBRO CXC A " + _Str_Cliente + " #" + _Str_NumeroDocumento;
                            break;
                        case "AVISO DE COBRO CXP":
                            _Str_Cuenta = _Plantilla_CxP_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_CxP_IC.Naturaleza;
                            _Str_Descripcion = _Plantilla_CxP_IC.Descripcion + " AVISO DE COBRO CXP A " + _Str_Proveedor + " #" + _Str_NumeroDocumento;
                            break;
                    }
                    //Montos
                    decimal _Dcl_Debe = 0;
                    decimal _Dcl_Haber = 0;
                    //En funcion al tipo de documento digo como es la naturalidad
                    string _Str_Naturalidad = "";
                    switch (_Str_TipoDocumento)
                    {
                        case "FACTURA CXC":
                        case "NOTA DE DEBITO CXC":
                        case "FACTURA CXP":
                        case "NOTA DE CREDITO CXP":
                        case "NOTA DE DEBITO PROVEEDOR CXP":
                        case "CHEQUE":
                        case "TRANSFERENCIA":
                        case "AVISO DE COBRO CXC":
                        case "AVISO DE COBRO CXP":
                            _Str_Naturalidad = "NATURAL";
                            break;
                        case "NOTA DE DEBITO CXP":
                        case "NOTA DE CREDITO PROVEEDOR CXP":
                        case "NOTA DE CREDITO CXC":
                            _Str_Naturalidad = "ANTINATURAL";
                            break;
                    }
                    //En Funcion al la Naturaleza y Naturalidad
                    if (_Str_Naturaleza == "D") //Naturaleza Debe
                    {
                        if (_Str_Naturalidad == "NATURAL")
                        {
                            _Dcl_Debe = _Dcl_Monto;
                        }
                        else
                        {
                            _Dcl_Haber = _Dcl_Monto;
                        }
                    }
                    else //Naturaleza Haber
                    {
                        if (_Str_Naturalidad == "NATURAL")
                        {
                            _Dcl_Haber = _Dcl_Monto;
                        }
                        else
                        {
                            _Dcl_Debe = _Dcl_Monto;
                        }
                    }


                    //Genero el detalle 
                    _Dg_Comprobante.Rows.Add();
                    _Dg_Comprobante["Cuenta", _Dg_Comprobante.RowCount - 1].Value = _Str_Cuenta;
                    _Dg_Comprobante["Descripcion", _Dg_Comprobante.RowCount - 1].Value = _Str_Descripcion;
                    _Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = _Str_TipoDocumentoCorto;
                    _Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = _Str_NumeroDocumento;
                    _Dg_Comprobante["_Col_Fecha_Emision", _Dg_Comprobante.RowCount - 1].Value = _Str_FechaEmision;
                    _Dg_Comprobante["_Col_Fecha_Vencimiento", _Dg_Comprobante.RowCount - 1].Value = _Str_FechaVencimiento;

                    if (_Dcl_Debe == 0)
                    {
                        //_Dg_Comprobante["Debe", _Dg_Comprobante.RowCount - 1].Value = "";
                    }
                    else
                    {
                        _Dg_Comprobante["Debe", _Dg_Comprobante.RowCount - 1].Value = _Dcl_Debe.ToString("#,##0.00").Replace("-", "");
                    }

                    if (_Dcl_Haber == 0)
                    {
                        //_Dg_Comprobante["Haber", _Dg_Comprobante.RowCount - 1].Value = "";
                    }
                    else
                    {
                        _Dg_Comprobante["Haber", _Dg_Comprobante.RowCount - 1].Value = _Dcl_Haber.ToString("#,##0.00").Replace("-", "");
                    }
                }

                //Cargo las cuentas por PAGAR
                foreach (DataGridViewRow _DgRow in _Dg_DocPago.Rows)
                {
                    //Tomo los valores
                    string _Str_Compañia = Frm_Padre._Str_Comp;
                    string _Str_cprovedor = _Cmb_CompaniaRelacionada.SelectedValue.ToString();
                    string _Str_Proveedor = _Mtd_ObtenerProveedor(_Str_cprovedor);
                    string _Str_Cliente = _Mtd_ObtenerCliente(_Str_cprovedor);
                    string _Str_TipoDocumento = _DgRow.Cells["_Dg_DocPag_Col_Tipo"].Value.ToString();
                    string _Str_TipoDocumentoCorto = _Mtd_ConvertirTipoDocumentoDeLargoACorto(_Str_TipoDocumento);
                    string _Str_FechaEmision = _DgRow.Cells["_Dg_DocPag_Col_Emision"].Value.ToString();
                    string _Str_FechaVencimiento = _DgRow.Cells["_Dg_DocPag_Col_Vencimiento"].Value.ToString();
                    String _Str_BancoEmisor = _DgRow.Cells["_Dg_DocPag_Col_BancoEmisor"].Value.ToString();
                    String _Str_BancoDeposito = _DgRow.Cells["_Dg_DocPag_Col_BancoDeposito"].Value.ToString();
                    String _Str_NumeroCuenta = _DgRow.Cells["_Dg_DocPag_Col_NumeroCuenta"].Value.ToString();
                    String _Str_cbancoemisor = _DgRow.Cells["_Dg_DocPag_Col_cbancoemisor"].Value.ToString();
                    String _Str_cbancodeposito = _DgRow.Cells["_Dg_DocPag_Col_cbancodeposito"].Value.ToString();
                    String _Str_cnumcuenta = _DgRow.Cells["_Dg_DocPag_Col_cnumcuenta"].Value.ToString();
                    string _Str_NumeroDocumento = _DgRow.Cells["_Dg_DocPag_Col_Documento"].Value.ToString();
                    decimal _Dcl_Monto = Convert.ToDecimal(_DgRow.Cells["_Dg_DocPag_Col_Monto"].Value);

                    //En funcion al tipo de Documento
                    string _Str_Cuenta = "";
                    string _Str_Naturaleza = "";
                    string _Str_Descripcion = "";
                    decimal _Dcl_Debe = 0;
                    decimal _Dcl_Haber = 0;
                    //En funcion al tipo de Documento obtengo el numero de cuenta
                    if (_Str_TipoDocumento == "CHEQUE" || _Str_TipoDocumento == "TRANSFERENCIA")
                    {
                        //Genero los valores a guardar en el comprobante
                        _Str_Cuenta = _Mtd_ObtenerCuentaContableDesdeCuentaBancaria(Frm_Padre._Str_Comp, _Str_cnumcuenta);
                    }
                    else
                    {
                        //Genero los valores a guardar en el comprobante
                        _Str_Cuenta = _Plantilla_CxP_IC.Cuenta;
                    }
                    //Genero la Descripcion
                    switch (_Str_TipoDocumento)
                    {
                        case "FACTURA CXC":
                            _Str_Cuenta = _Plantilla_CxC_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_CxC_IC.Naturaleza;
                            _Str_Descripcion = _Plantilla_CxC_IC.Descripcion + " " + _Str_Cliente + " " + " COBRO " + _Str_TipoDocumento + ":" + _Str_NumeroDocumento + " VEC:" + _Str_FechaVencimiento;
                            break;
                        case "NOTA DE DEBITO CXP":
                            _Str_Cuenta = _Plantilla_CxP_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_CxP_IC.Naturaleza;
                            _Str_Descripcion = _Plantilla_CxP_IC.Descripcion + " " + _Str_Proveedor + " SEGUN " + _Str_TipoDocumento + " #" + _Str_NumeroDocumento;
                            break;
                        case "NOTA DE CREDITO PROVEEDOR CXP":
                            _Str_Cuenta = _Plantilla_CxP_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_CxP_IC.Naturaleza;
                            _Str_Descripcion = _Plantilla_CxP_IC.Descripcion + " " + _Str_Proveedor + " SEGUN " + _Str_TipoDocumento + " #" + _Str_NumeroDocumento;
                            break;
                        case "NOTA DE DEBITO CXC":
                            _Str_Cuenta = _Plantilla_CxC_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_CxC_IC.Naturaleza;
                            _Str_Descripcion = _Plantilla_CxC_IC.Descripcion + " " + _Str_Cliente + " " + " COBRO " + _Str_TipoDocumento + " #" + _Str_NumeroDocumento;
                            break;
                        case "FACTURA CXP":
                            _Str_Cuenta = _Plantilla_CxP_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_CxP_IC.Naturaleza;
                            _Str_Descripcion = _Plantilla_CxP_IC.Descripcion + " " + _Str_Proveedor + " CANCELACION " + _Str_TipoDocumento + ":" + _Str_NumeroDocumento + " VEC:" + _Str_FechaVencimiento;
                            break;
                        case "NOTA DE CREDITO CXP":
                            _Str_Cuenta = _Plantilla_CxP_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_CxP_IC.Naturaleza;
                            _Str_Descripcion = _Plantilla_CxP_IC.Descripcion + " " + _Str_Proveedor + " CANCELACION " + _Str_TipoDocumento + " #" + _Str_NumeroDocumento;
                            break;
                        case "NOTA DE DEBITO PROVEEDOR CXP":
                            _Str_Cuenta = _Plantilla_CxP_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_CxP_IC.Naturaleza;
                            _Str_Descripcion = _Plantilla_CxP_IC.Descripcion + " " + _Str_Proveedor + " CANCELACION " + _Str_TipoDocumento + " #" + _Str_NumeroDocumento;
                            break;
                        case "NOTA DE CREDITO CXC":
                            _Str_Cuenta = _Plantilla_CxC_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_CxC_IC.Naturaleza;
                            _Str_Descripcion = _Plantilla_CxC_IC.Descripcion + " " + _Str_Cliente + " " + " SEGUN " + _Str_TipoDocumento + " #" + _Str_NumeroDocumento;
                            break;
                        case "CHEQUE":
                            //_Str_Cuenta = _Plantilla_ChequesYTransferencias_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_ChequesYTransferencias_IC.Naturaleza;
                            _Str_Descripcion = _Str_BancoDeposito + " CHEQUE #" + _Str_NumeroDocumento + " DEL BANCO " + _Str_BancoEmisor;
                            break;
                        case "TRANSFERENCIA":
                            //_Str_Cuenta = _Plantilla_ChequesYTransferencias_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_ChequesYTransferencias_IC.Naturaleza;
                            _Str_Descripcion = _Str_BancoDeposito + " TRANSFERENCIA #" + _Str_NumeroDocumento + " DEL BANCO " + _Str_BancoEmisor;
                            break;
                        case "AVISO DE COBRO CXC":
                            _Str_Cuenta = _Plantilla_CxC_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_CxC_IC.Naturaleza;
                            _Str_Descripcion = _Plantilla_CxC_IC.Descripcion + " AVISO DE COBRO CXC A " + _Str_Cliente + " #" + _Str_NumeroDocumento;
                            break;
                        case "AVISO DE COBRO CXP":
                            _Str_Cuenta = _Plantilla_CxP_IC.Cuenta;
                            _Str_Naturaleza = _Plantilla_CxP_IC.Naturaleza;
                            _Str_Descripcion = _Plantilla_CxP_IC.Descripcion + " AVISO DE COBRO CXP A " + _Str_Proveedor + " #" + _Str_NumeroDocumento;
                            break;
                    }
                    //En funcion al tipo de documento digo como es la naturalidad
                    string _Str_Naturalidad = "";
                    switch (_Str_TipoDocumento)
                    {
                        case "FACTURA CXC":
                        case "NOTA DE DEBITO CXC":
                        case "FACTURA CXP":
                        case "NOTA DE CREDITO CXP":
                        case "NOTA DE DEBITO PROVEEDOR CXP":
                        case "CHEQUE":
                        case "TRANSFERENCIA":
                        case "AVISO DE COBRO CXC":
                        case "AVISO DE COBRO CXP":
                            _Str_Naturalidad = "NATURAL";
                            break;
                        case "NOTA DE DEBITO CXP":
                        case "NOTA DE CREDITO PROVEEDOR CXP":
                        case "NOTA DE CREDITO CXC":
                            _Str_Naturalidad = "ANTINATURAL";
                            break;
                    }
                    //En Funcion al la Naturaleza y Naturalidad
                    if (_Str_Naturaleza == "D") //Naturaleza Debe
                    {
                        if (_Str_Naturalidad == "NATURAL")
                        {
                            _Dcl_Debe = _Dcl_Monto;
                        }
                        else
                        {
                            _Dcl_Haber = _Dcl_Monto;
                        }
                    }
                    else //Naturaleza Haber
                    {
                        if (_Str_Naturalidad == "NATURAL")
                        {
                            _Dcl_Haber = _Dcl_Monto;
                        }
                        else
                        {
                            _Dcl_Debe = _Dcl_Monto;
                        }
                    }


                    //Genero el detalle 
                    _Dg_Comprobante.Rows.Add();
                    _Dg_Comprobante["Cuenta", _Dg_Comprobante.RowCount - 1].Value = _Str_Cuenta;
                    _Dg_Comprobante["Descripcion", _Dg_Comprobante.RowCount - 1].Value = _Str_Descripcion;
                    _Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = _Str_TipoDocumentoCorto;
                    _Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = _Str_NumeroDocumento;
                    _Dg_Comprobante["_Col_Fecha_Emision", _Dg_Comprobante.RowCount - 1].Value = _Str_FechaEmision;
                    _Dg_Comprobante["_Col_Fecha_Vencimiento", _Dg_Comprobante.RowCount - 1].Value = _Str_FechaVencimiento;

                    if (_Dcl_Debe == 0)
                    {
                        //_Dg_Comprobante["Debe", _Dg_Comprobante.RowCount - 1].Value = "";
                    }
                    else
                    {
                        _Dg_Comprobante["Debe", _Dg_Comprobante.RowCount - 1].Value = _Dcl_Debe.ToString("#,##0.00").Replace("-", "");
                    }

                    if (_Dcl_Haber == 0)
                    {
                        //_Dg_Comprobante["Haber", _Dg_Comprobante.RowCount - 1].Value = "";
                    }
                    else
                    {
                        _Dg_Comprobante["Haber", _Dg_Comprobante.RowCount - 1].Value = _Dcl_Haber.ToString("#,##0.00").Replace("-", "");
                    }
                }

                //Agrego la fila TOTAL
                _Dg_Comprobante.Rows.Add(new object[] { null, null, "TOTAL", _Mtd_TotalDebeHaber(3), _Mtd_TotalDebeHaber(4) });
            }
            //Hago que las columnas dle grid sean auto ajustables
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        private string _Mtd_ObtenerCuentaContableDesdeCuentaBancaria(string _P_Str_ccompany, string _P_Str_cnumcuenta)
        {
            string _SQL;
            DataSet _Ds;
            string _Str_CuentaContable = "";
            _SQL = "SELECT ccount FROM TCUENTBANC WHERE CCOMPANY='" + _P_Str_ccompany + "' AND cnumcuenta ='" + _P_Str_cnumcuenta + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_SQL);
            _Str_CuentaContable = _Ds.Tables[0].Rows[0]["ccount"].ToString();
            return _Str_CuentaContable;

        }
        private string _Mtd_ObtenerNombreBancoyCuentaDesdeCuentaBancaria(string _P_Str_ccompany, string _P_Str_cnumcuenta)
        {
            string _SQL;
            DataSet _Ds;
            string _Str_CuentaContable = "";
            _SQL = "SELECT cname FROM TCUENTBANC WHERE CCOMPANY='" + _P_Str_ccompany + "' AND cnumcuenta ='" + _P_Str_cnumcuenta + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_SQL);
            _Str_CuentaContable = _Ds.Tables[0].Rows[0]["cname"].ToString();
            return _Str_CuentaContable;

        }
        private string _Mtd_ObtenerCliente(string _P_Str_cproveedor)
        {
            string _SQL;
            DataSet _Ds;
            string _Str_Cliente = "";
            _SQL = "SELECT ";
            _SQL += "TCLIENTE.c_nomb_comer AS Cliente ";
            _SQL += "FROM TCLIENTE INNER JOIN TICRELAPROCLI ON TCLIENTE.ccliente = TICRELAPROCLI.ccliente ";
            _SQL += "WHERE ";
            _SQL += "[cproveedor]='" + _P_Str_cproveedor + "' ";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_SQL);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Cliente = _Ds.Tables[0].Rows[0]["Cliente"].ToString();
            }
            return _Str_Cliente;
        }
        private string _Mtd_ObtenerProveedor(string _P_Str_cproveedor)
        {
            string _SQL;
            DataSet _Ds;
            string _Str_Proveedor = "";
            _SQL = "SELECT ";
            _SQL += "c_nomb_comer ";
            _SQL += "FROM TPROVEEDOR ";
            _SQL += "WHERE ";
            _SQL += "CCOMPANY='" + Frm_Padre._Str_Comp + "' ";
            _SQL += "AND ";
            _SQL += "cproveedor = '" + _P_Str_cproveedor + "' ";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_SQL);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Proveedor = _Ds.Tables[0].Rows[0]["c_nomb_comer"].ToString();
            }
            return _Str_Proveedor;
        }
        /// <summary>
        /// Método que devuelve la suma de las filas del debe o el haber según sea el caso
        /// </summary>
        /// <param name="_P_Int_Col_Index">Número de columna del grid</param>
        /// <returns></returns>
        private string _Mtd_TotalDebeHaber(int _P_Int_Col_Index)
        {
            double _Dbl_Total = 0;
            object _Ob_Valor = new object();
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (_Dg_Row.Cells[0].Value.ToString().Trim().Length > 0)
                    {
                        _Ob_Valor = _Dg_Row.Cells[_P_Int_Col_Index].Value;
                        if (_Ob_Valor == null)
                        { _Ob_Valor = 0; }
                        else if (_Ob_Valor.ToString().Trim().Length == 0)
                        { _Ob_Valor = 0; }
                        _Dbl_Total += Convert.ToDouble(_Ob_Valor);
                    }
                }
            }
            return _Dbl_Total.ToString("#,##0.00");
        }
        /// <summary>
        /// Método que habilita las celda con XXXX
        /// </summary>
        /// <param name="_P_Bol_Habilitar">Booleano para habilitar o deshabilitar</param>
        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_G_Int_Proceso == _G_EnumTipoDeProceso.Creando)
            {
                if (e.TabPageIndex == 0)
                {
                    if (MessageBox.Show("Se perderá cualquier dato que haya ingresado en la cobranza que está creando. ¿Está seguro?", "Información", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        _Mtd_Cancelar();
                        _G_Int_Proceso = _G_EnumTipoDeProceso.EnEspera;
                        _Er_Error.Dispose();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            else if (_G_Int_Proceso == _G_EnumTipoDeProceso.Modificando)
            {
                if (e.TabPageIndex == 0)
                {
                    if (MessageBox.Show("Se perderá cualquier dato que haya ingresado en la cobranza que está modificando. ¿Está seguro?", "Información", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        _Mtd_Cancelar();
                        _G_Int_Proceso = _G_EnumTipoDeProceso.EnEspera;
                        _Er_Error.Dispose();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            else if (_G_Int_Proceso == _G_EnumTipoDeProceso.Consultando)
            {
                if (e.TabPageIndex == 0)
                {
                    _Mtd_Cancelar();
                    _G_Int_Proceso = _G_EnumTipoDeProceso.EnEspera;
                    _Er_Error.Dispose();
                }
            }
            else if (_G_Int_Proceso == _G_EnumTipoDeProceso.EnEspera)
            {
                if (e.TabPageIndex == 1)
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Devuelve un valor que indica si la cuenta es una cuenta de detalle
        /// </summary>
        /// <param name="_P_Str_Cuenta">Cuenta</param>
        /// <returns>Booleano si es valido o no</returns>
        private bool _Mtd_CuentaDetalle(string _P_Str_Cuenta)
        {
            string _Str_Cadena = "Select ctcount from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' AND cactivate='1' AND ccount='" + _P_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper() == "D")
                { return true; }
            }
            return false;
        }
        /// <summary>
        /// Verifica si la cuenta ya ha sido ingresada.
        /// </summary>
        /// <param name="_P_Str_Cuenta">Cuenta</param>
        /// <param name="_P_Int_RowIndex">Índice de la fila</param>
        /// <returns>Booleano si es valido o no</returns>
        private bool _Mtd_ValidarCuenta(string _P_Str_Cuenta, int _P_Int_RowIndex)
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (_Dg_Row.Cells[0].Value.ToString().Trim() == _P_Str_Cuenta & _Dg_Row.Index != _P_Int_RowIndex)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Método para obtener la descripción de la cuenta
        /// </summary>
        /// <param name="_P_Str_Cuenta">Código de la cuenta</param>
        /// <returns>Descripción de la cuenta</returns>
        private string _Mtd_ObtenerDescripCuenta(string _P_Str_Cuenta)
        {
            string _Str_Descrip = "";
            string _Str_Proveedor = "";
            _Er_Error.Dispose();
            if (_Cmb_CompaniaRelacionada.SelectedValue != null)
            {
                if (_Cmb_CompaniaRelacionada.SelectedValue.ToString() != "nulo")
                {
                    _Str_Proveedor = _Cmb_CompaniaRelacionada.SelectedValue.ToString();
                }
            }
            _Str_Descrip = _Mtd_ObtenerDescripComerProveedor(_Str_Proveedor);
            string _Str_Cadena = "Select cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _P_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper() + " " + _Str_Descrip; }
            else
            { return ""; }
        }
        /// <summary>
        /// Método para obtener la descripción del proveedor
        /// </summary>
        /// <param name="_P_Str_Proveedor">Código del proveedor</param>
        /// <returns>Nombre del proveedor</returns>
        private string _Mtd_ObtenerDescripComerProveedor(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) AND cproveedor='" + _P_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(); }
            else
            { return ""; }
        }

        private void _Dg_Comprobante_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                if (_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    if (_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim().Length == 0)
                    {
                        _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _G_Str_ValorCeldaTem;
                    }
                    else
                    {
                        if (_Mtd_CuentaDetalle(_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim()))
                        {
                            if (!_Mtd_ValidarCuenta(_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim(), e.RowIndex))
                            { _Dg_Comprobante.Rows[e.RowIndex].Cells[2].Value = _Mtd_ObtenerDescripCuenta(_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim()); }
                            else
                            { MessageBox.Show("La cuenta que introdujo ya existe. Debe ingresar una cuenta diferente", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _G_Str_ValorCeldaTem; }
                        }
                        else
                        { MessageBox.Show("Debe ingresar una cuenta de detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _G_Str_ValorCeldaTem; }
                    }
                }
                else
                { _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _G_Str_ValorCeldaTem; }
            }
        }
        bool _G_Bol_Boleano = false;
        private void _Dg_Comprobante_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!_G_Bol_Boleano)
            {
                e.Control.TextChanged += new EventHandler(Control_TextChanged);
                _G_Bol_Boleano = true;
            }
        }
        void Control_TextChanged(object sender, EventArgs e)
        {
            if (_Dg_Comprobante.CurrentCell.ColumnIndex == 0)
            {
                _Mtd_MostrarToolTipsCell(((TextBox)sender).Text, ((TextBox)sender).Font);
            }
        }
        /// <summary>
        /// Muestra en un ToolTips la descripción de la cuenta que se esta introduciendo manualmente
        /// </summary>
        /// <param name="_P_Str_Cuenta"></param>
        private void _Mtd_MostrarToolTipsCell(string _P_Str_Cuenta, Font _P_Fnt_Fuente)
        {
            if (_P_Str_Cuenta.Trim().Length > 0)
            {
                string _Str_Cadena = "Select cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _P_Str_Cuenta.Trim() + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Tlt_Tips.Show(_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(), this, (_Dg_Comprobante.Location.X + (_Dg_Comprobante.Width / 2)) - (Convert.ToInt32(CreateGraphics().MeasureString(_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(), _P_Fnt_Fuente).Width) / 2), this.Height - 50, 2000);
                }
                else
                {
                    _Tlt_Tips.Hide(this);
                }
            }
            else
            { _Tlt_Tips.Hide(this); }
        }

        private void _Cmb_CompaniaRelacionada_DropDown(object sender, EventArgs e)
        {
            _Dg_DocCobr.Rows.Clear();
            _Txt_MontoTotalDocumentosCobrados.Text = "0,00";
            _Dg_DocPago.Rows.Clear();
            _Txt_MontoTotalDocumentosDePago.Text = "0,00";
            _Dg_Comprobante.Rows.Clear();
            _Mtd_CargarCombosCompañiasRelacionadas();
        }

        private void _Cmb_CompaniaRelacionadaCons_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarCombosCompañiasRelacionadas();
        }

        private void _Cmb_CompaniaRelacionada_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Dg_DocCobr.Rows.Clear();
            _Txt_MontoTotalDocumentosCobrados.Text = "0,00";
            _Dg_DocPago.Rows.Clear();
            _Txt_MontoTotalDocumentosDePago.Text = "0,00";
            _Dg_Comprobante.Rows.Clear();
        }
        public bool _Mtd_Editar()
        {
            return _Mtd_Guardar();
        }
        /// <summary>
        /// Método para Guardar la cobranza
        /// </summary>
        public bool _Mtd_Guardar()
        {
            if (_Mtd_Validar())
            {
                if (_Dg_Comprobante.Rows.Count > 0)
                {
                    //En función a lo que se este haciendo el focmulario
                    if (_G_Int_Proceso == _G_EnumTipoDeProceso.Creando)
                    {
                        _Mtd_GenerarCobranzaYComprobante(Frm_Padre._Str_Comp);
                    }
                    else if (_G_Int_Proceso == _G_EnumTipoDeProceso.Modificando)
                    {
                        _Mtd_GenerarCobranzaYComprobante(Frm_Padre._Str_Comp, _G_Int_cidiccobram, _G_Int_cidcobranzaic, _G_Int_cidcomprob);
                    }
                    return true;
                }
                else
                {
                    MessageBox.Show("Debe visualizar y completar el comprobante contable.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return false;
        }
        private string _Mtd_ConvertirTipoDocumentoDeLargoACorto(string _P_Str_TipoDocumentoLargo)
        {
            string _Str_TipoDocumentoCorto = "";
            switch (_P_Str_TipoDocumentoLargo)
            {
                case "FACTURA CXC":
                    _Str_TipoDocumentoCorto = "FACT";
                    break;
                case "NOTA DE DEBITO CXC":
                    _Str_TipoDocumentoCorto = "N/D";
                    break;
                case "NOTA DE CREDITO CXC":
                    _Str_TipoDocumentoCorto = "N/C";
                    break;
                case "FACTURA CXP":
                    _Str_TipoDocumentoCorto = "FACT";
                    break;
                case "NOTA DE DEBITO CXP":
                    _Str_TipoDocumentoCorto = "N/D";
                    break;
                case "NOTA DE CREDITO CXP":
                    _Str_TipoDocumentoCorto = "N/C";
                    break;
                case "NOTA DE CREDITO PROVEEDOR CXP":
                    _Str_TipoDocumentoCorto = "NCP";
                    break;
                case "NOTA DE DEBITO PROVEEDOR CXP":
                    _Str_TipoDocumentoCorto = "NDP";
                    break;
                case "CHEQUE":
                    _Str_TipoDocumentoCorto = "CHEQ";
                    break;
                case "TRANSFERENCIA":
                    _Str_TipoDocumentoCorto = "TRANSB";
                    break;
                case "AVISO DE COBRO CXC":
                    _Str_TipoDocumentoCorto = "AVISOCXC";
                    break;
                case "AVISO DE COBRO CXP":
                    _Str_TipoDocumentoCorto = "AVISOCXP";
                    break;
            }
            return _Str_TipoDocumentoCorto;
        }
        private string _Mtd_ConvertirTipoDocumentoDeCortoALargo(string _P_Str_TipoDocumentoCorto, string _P_Str_NombreTabla)
        {
            string _Str_TipoDocumentoLargo = "";
            switch (_P_Str_NombreTabla)
            {
                case "TICCOBRAD_CXC":
                    switch (_P_Str_TipoDocumentoCorto)
                    {
                        case "FACT":
                            _Str_TipoDocumentoLargo = "FACTURA CXC";
                            break;
                        case "N/D":
                            _Str_TipoDocumentoLargo = "NOTA DE DEBITO CXC";
                            break;
                        case "N/C":
                            _Str_TipoDocumentoLargo = "NOTA DE CREDITO CXC";
                            break;
                        case "AVISOCXC":
                            _Str_TipoDocumentoLargo = "AVISO DE COBRO CXC";
                            break;
                    }
                    break;
                case "TICCOBRAD_CXP":
                    switch (_P_Str_TipoDocumentoCorto)
                    {
                        case "FACT":
                            _Str_TipoDocumentoLargo = "FACTURA CXP";
                            break;
                        case "N/D":
                            _Str_TipoDocumentoLargo = "NOTA DE DEBITO CXP";
                            break;
                        case "N/C":
                            _Str_TipoDocumentoLargo = "NOTA DE CREDITO CXP";
                            break;
                        case "NCP":
                            _Str_TipoDocumentoLargo = "NOTA DE CREDITO PROVEEDOR CXP";
                            break;
                        case "NDP":
                            _Str_TipoDocumentoLargo = "NOTA DE DEBITO PROVEEDOR CXP";
                            break;
                        case "AVISOCXP":
                            _Str_TipoDocumentoLargo = "AVISO DE COBRO CXP";
                            break;
                    }
                    break;
                case "TICCOBRAD_PAG":
                    switch (_P_Str_TipoDocumentoCorto)
                    {
                        case "CHEQ":
                            _Str_TipoDocumentoLargo = "CHEQUE";
                            break;
                        case "TRANSB":
                            _Str_TipoDocumentoLargo = "TRANSFERENCIA";
                            break;
                    }
                    break;
            }
            return _Str_TipoDocumentoLargo;
        }
        private string _Mtd_ConvertirTipoDocumentoLargoANombreDeTabla(string _P_Str_TipoDocumentoLargo)
        {
            string _Str_NombreDeTabla = "";
            switch (_P_Str_TipoDocumentoLargo)
            {
                case "FACTURA CXC":
                case "NOTA DE DEBITO CXC":
                case "NOTA DE CREDITO CXC":
                case "AVISO DE COBRO CXC":
                    _Str_NombreDeTabla = "TICCOBRAD_CXC";
                    break;
                case "FACTURA CXP":
                case "NOTA DE DEBITO CXP":
                case "NOTA DE CREDITO CXP":
                case "NOTA DE CREDITO PROVEEDOR CXP":
                case "NOTA DE DEBITO PROVEEDOR CXP":
                case "AVISO DE COBRO CXP":
                    _Str_NombreDeTabla = "TICCOBRAD_CXP";
                    break;
                case "CHEQUE":
                case "TRANSFERENCIA":
                    _Str_NombreDeTabla = "TICCOBRAD_PAG";
                    break;
            }
            return _Str_NombreDeTabla;
        }
        /// <summary>
        /// Método que registra la cobranza por aprobar y el comprobante contable inexistente
        /// </summary>
        private void _Mtd_GenerarCobranzaYComprobante(string _P_Str_Comp, int _P_Int_cidiccobram = 0, int _P_Int_cidcobranzaic = 0, int _P_Int_cidcomprob = 0)
        {
            //try
            //{
            //Variables de Trabajo del metodo
            int _Int_cidiccobram;
            int _Int_cidcobranzaic;
            int _Int_cidcomprob;

            //Si no se manda el codigo del registro (Creando)
            if (_P_Int_cidiccobram == 0)
            {
                //Genero el nuevo ID de la cobranza
                _G_Str_SentenciaSQL = "SELECT ISNULL(MAX(cidcobranzaic),0)+1 FROM TICCOBRAM WHERE CCOMPANY='" + _P_Str_Comp + "'";
                _G_Ds_CobranzaEncabezado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
                _Int_cidcobranzaic = Convert.ToInt32(_G_Ds_CobranzaEncabezado.Tables[0].Rows[0][0].ToString());
                _Txt_IdCobranza.Text = _Int_cidcobranzaic.ToString();

                //Registro del comprobante contable
                _Int_cidcomprob = _Mtd_GenerarComprobante();
            }
            else
            {
                //Paso los datos a las variables de trabajo
                _Int_cidiccobram = _P_Int_cidiccobram;
                _Int_cidcobranzaic = _P_Int_cidcobranzaic;
                _Int_cidcomprob = _P_Int_cidcomprob;

                //Edito el comprobante
                _Int_cidcomprob = _Mtd_GenerarComprobante(_Int_cidcomprob);
            }

            //Si no se manda el codigo del registro (Creando)
            if (_P_Int_cidiccobram == 0)
            {
                //Guardo la cobranza nueva
                _G_Str_SentenciaSQL = "";
                _G_Str_SentenciaSQL += "INSERT INTO TICCOBRAM ";
                _G_Str_SentenciaSQL += "([ccompany],[cidcobranzaic],[cfecha],[cproveedor],[cmonto],[cestado],[cuserregis],[cuseraprob],[cfechaaprob],[cidcomprob],[cdateadd],[cuseradd]) ";
                _G_Str_SentenciaSQL += " VALUES ";
                _G_Str_SentenciaSQL += "('" + Frm_Padre._Str_Comp + "'," + _Int_cidcobranzaic + ",'" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Txt_Fecha.Text)) + "','" + _Cmb_CompaniaRelacionada.SelectedValue.ToString() + "'," + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDecimal(_Txt_MontoTotalDocumentosCobrados.Text)) + "," + (byte)_G_EnumTipoDeEstado.PorAprobar + ",'" + Frm_Padre._Str_Use + "','',null," + _Int_cidcomprob + ",GETDATE(),'" + Frm_Padre._Str_Use + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
            }
            else
            {
                //Edito la cobranza 
                _G_Str_SentenciaSQL = "";
                _G_Str_SentenciaSQL += "UPDATE TICCOBRAM ";
                _G_Str_SentenciaSQL += "SET ";
                _G_Str_SentenciaSQL += "  cestado = " + (int)_G_EnumTipoDeEstado.PorAprobar + " ";
                _G_Str_SentenciaSQL += ",  cfecha = '" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Txt_Fecha.Text)) + "' ";
                _G_Str_SentenciaSQL += ", cproveedor = '" + _Cmb_CompaniaRelacionada.SelectedValue.ToString() + "' ";
                _G_Str_SentenciaSQL += ", cmonto = " + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDecimal(_Txt_MontoTotalDocumentosCobrados.Text)) + " ";
                _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                _G_Str_SentenciaSQL += ", cuserupd = '" + _P_Str_Comp + "' ";
                _G_Str_SentenciaSQL += "WHERE cidiccobram = " + _P_Int_cidcobranzaic + "";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
            }

            //Si  se manda el codigo del registro (Modificando)
            if (_P_Int_cidiccobram != 0)
            {
                //Borro las tablas detalles
                _G_Str_SentenciaSQL = "";
                _G_Str_SentenciaSQL += "DELETE TICCOBRAD_CXC ";
                _G_Str_SentenciaSQL += "WHERE ";
                _G_Str_SentenciaSQL += "ccompany = '" + _P_Str_Comp + "' ";
                _G_Str_SentenciaSQL += "AND ";
                _G_Str_SentenciaSQL += "cidcobranzaic = " + _Int_cidcobranzaic + " ";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);

                //Borro las tablas detalles
                _G_Str_SentenciaSQL = "";
                _G_Str_SentenciaSQL += "DELETE TICCOBRAD_CXP ";
                _G_Str_SentenciaSQL += "WHERE ";
                _G_Str_SentenciaSQL += "ccompany = '" + _P_Str_Comp + "' ";
                _G_Str_SentenciaSQL += "AND ";
                _G_Str_SentenciaSQL += "cidcobranzaic = " + _Int_cidcobranzaic + " ";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);

                //Borro las tablas detalles
                _G_Str_SentenciaSQL = "";
                _G_Str_SentenciaSQL += "DELETE TICCOBRAD_PAG ";
                _G_Str_SentenciaSQL += "WHERE ";
                _G_Str_SentenciaSQL += "ccompany = '" + _P_Str_Comp + "' ";
                _G_Str_SentenciaSQL += "AND ";
                _G_Str_SentenciaSQL += "cidcobranzaic = " + _Int_cidcobranzaic + " ";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
            }

            //Guardo Los Detalles
            //Recorro los documentos cobrados
            foreach (DataGridViewRow _DgRow in _Dg_DocCobr.Rows)
            {
                //Tomo los valores
                string _Str_Compañia = Frm_Padre._Str_Comp;
                string _Str_Proveedor = _Cmb_CompaniaRelacionada.SelectedValue.ToString();
                string _Str_TipoDocumentoLargo = _DgRow.Cells["_Dg_DocCob_Col_Tipo"].Value.ToString();
                string _Str_TipoDocumentoCorto = _Mtd_ConvertirTipoDocumentoDeLargoACorto(_Str_TipoDocumentoLargo);
                DateTime _Dt_FechaEmision = Convert.ToDateTime(_DgRow.Cells["_Dg_DocCob_Col_Emision"].Value.ToString());
                DateTime _Dt_FechaVencimiento = Convert.ToDateTime(_DgRow.Cells["_Dg_DocCob_Col_Vencimiento"].Value.ToString());
                String _Str_cbancoemisor = "";
                String _Str_cbancodeposito = "";
                String _Str_cnumcuenta = "";
                string _Str_NumeroDocumento = _DgRow.Cells["_Dg_DocCob_Col_Documento"].Value.ToString();
                decimal _Dcl_Monto = Convert.ToDecimal(_DgRow.Cells["_Dg_DocCob_Col_Monto"].Value);
                //En función al tipo de documento
                switch (_Str_TipoDocumentoLargo)
                {
                    case "FACTURA CXC":
                    case "NOTA DE DEBITO CXC":
                    case "NOTA DE CREDITO CXC":
                    case "AVISO DE COBRO CXC":
                        //Verifico si el registro existe
                        if (_Mtd_ExisteRegistro_TICOBRAD_CXC(_Str_Compañia, Convert.ToInt32(_Str_NumeroDocumento), _Str_TipoDocumentoCorto)) //Si existe Modifico
                        {
                            //Genero el SQL
                            _G_Str_SentenciaSQL = "";
                            _G_Str_SentenciaSQL += "UPDATE TICCOBRAD_CXC ";
                            _G_Str_SentenciaSQL += "SET ";
                            _G_Str_SentenciaSQL += "  cidcobranzaic = " + _Int_cidcobranzaic + " ";
                            _G_Str_SentenciaSQL += ", cmonto = " + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcl_Monto) + " ";
                            _G_Str_SentenciaSQL += ", cdateadd = GETDATE()";
                            _G_Str_SentenciaSQL += ", cuseradd = '" + Frm_Padre._Str_Use + "' ";
                            _G_Str_SentenciaSQL += "WHERE ";
                            _G_Str_SentenciaSQL += "ccompany = '" + _Str_Compañia + "' ";
                            _G_Str_SentenciaSQL += " AND ";
                            _G_Str_SentenciaSQL += "cnumdocu = " + Convert.ToInt32(_Str_NumeroDocumento) + " ";
                            _G_Str_SentenciaSQL += " AND ";
                            _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        }
                        else //Sino existe Inserto
                        {
                            //Genero el SQL
                            _G_Str_SentenciaSQL = "";
                            _G_Str_SentenciaSQL += "INSERT INTO TICCOBRAD_CXC ";
                            _G_Str_SentenciaSQL += "([cidcobranzaic],[ccompany],[cnumdocu],[ctipodocument],[cfechaemision],[cfechavencimiento],[cmonto],[cdateadd],[cuseradd]) ";
                            _G_Str_SentenciaSQL += " VALUES ";
                            _G_Str_SentenciaSQL += "(" + _Int_cidcobranzaic + ",'" + _Str_Compañia + "'," + Convert.ToInt32(_Str_NumeroDocumento) + ",'" + _Str_TipoDocumentoCorto + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Dt_FechaEmision)) + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Dt_FechaVencimiento)) + "'," + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcl_Monto) + ",GETDATE(),'" + Frm_Padre._Str_Use + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        }
                        break;
                    case "FACTURA CXP":
                    case "NOTA DE DEBITO CXP":
                    case "NOTA DE CREDITO CXP":
                    case "NOTA DE DEBITO PROVEEDOR CXP":
                    case "NOTA DE CREDITO PROVEEDOR CXP":
                    case "AVISO DE COBRO CXP":
                        //Verifico si el registro existe
                        if (_Mtd_ExisteRegistro_TICOBRAD_CXP(_Str_Compañia, _Str_NumeroDocumento, _Str_TipoDocumentoCorto, _Str_Proveedor)) //Si existe Modifico
                        {
                            //Genero el SQL
                            _G_Str_SentenciaSQL = "";
                            _G_Str_SentenciaSQL += "UPDATE TICCOBRAD_CXP ";
                            _G_Str_SentenciaSQL += "SET ";
                            _G_Str_SentenciaSQL += "  cidcobranzaic = " + _Int_cidcobranzaic + " ";
                            _G_Str_SentenciaSQL += ", cmonto = " + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcl_Monto) + " ";
                            _G_Str_SentenciaSQL += ", cdateadd = GETDATE()";
                            _G_Str_SentenciaSQL += ", cuseradd = '" + Frm_Padre._Str_Use + "' ";
                            _G_Str_SentenciaSQL += "WHERE ";
                            _G_Str_SentenciaSQL += "ccompany = '" + _Str_Compañia + "' ";
                            _G_Str_SentenciaSQL += " AND ";
                            _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                            _G_Str_SentenciaSQL += " AND ";
                            _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                            _G_Str_SentenciaSQL += " AND ";
                            _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        }
                        else //Sino existe Inserto
                        {
                            //Genero el SQL
                            _G_Str_SentenciaSQL = "";
                            _G_Str_SentenciaSQL += "INSERT INTO TICCOBRAD_CXP ";
                            _G_Str_SentenciaSQL += "([cidcobranzaic],[ccompany],[cnumdocu],[ctipodocument],[cproveedor],[cfechaemision],[cfechavencimiento],[cmonto],[cdateadd],[cuseradd]) ";
                            _G_Str_SentenciaSQL += " VALUES ";
                            _G_Str_SentenciaSQL += "(" + _Int_cidcobranzaic + ",'" + _Str_Compañia + "','" + _Str_NumeroDocumento + "','" + _Str_TipoDocumentoCorto + "','" + _Str_Proveedor + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Dt_FechaEmision)) + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Dt_FechaVencimiento)) + "'," + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcl_Monto) + ",GETDATE(),'" + Frm_Padre._Str_Use + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        }
                        break;
                    case "CHEQUE":
                    case "TRANSFERENCIA":
                        //Verifico si el registro existe
                        if (_Mtd_ExisteRegistro_TICOBRAD_PAG(_Str_NumeroDocumento, _Str_TipoDocumentoCorto, _Str_cbancoemisor)) //Si existe Modifico
                        {
                            //Genero el SQL
                            _G_Str_SentenciaSQL = "";
                            _G_Str_SentenciaSQL += "UPDATE TICCOBRAD_PAG ";
                            _G_Str_SentenciaSQL += "SET ";
                            _G_Str_SentenciaSQL += "  cidcobranzaic = " + _Int_cidcobranzaic + " ";
                            _G_Str_SentenciaSQL += ", cbancodeposito = '" + _Str_cbancodeposito + "' ";
                            _G_Str_SentenciaSQL += ", cnumcuenta = '" + _Str_cnumcuenta + "' ";
                            _G_Str_SentenciaSQL += ", cfechaemision = '" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Dt_FechaEmision)) + "' ";
                            _G_Str_SentenciaSQL += ", cfechavencimiento = '" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Dt_FechaVencimiento)) + "' ";
                            _G_Str_SentenciaSQL += ", cmonto = " + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcl_Monto) + " ";
                            _G_Str_SentenciaSQL += ", cdateadd = GETDATE()";
                            _G_Str_SentenciaSQL += ", cuseradd = '" + Frm_Padre._Str_Use + "' ";
                            _G_Str_SentenciaSQL += "WHERE ";
                            _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                            _G_Str_SentenciaSQL += " AND ";
                            _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                            _G_Str_SentenciaSQL += " AND ";
                            _G_Str_SentenciaSQL += "cbancoemisor = '" + _Str_cbancoemisor + "' ";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        }
                        else //Sino existe Inserto
                        {
                            //Genero el SQL
                            _G_Str_SentenciaSQL = "";
                            _G_Str_SentenciaSQL += "INSERT INTO TICCOBRAD_PAG ";
                            _G_Str_SentenciaSQL += "([cidcobranzaic],[ccompany],[cnumdocu],[ctipodocument],[cbancoemisor],[cbancodeposito],[cnumcuenta],[cfechaemision],[cfechavencimiento],[cmonto],[cdateadd],[cuseradd]) ";
                            _G_Str_SentenciaSQL += " VALUES ";
                            _G_Str_SentenciaSQL += "(" + _Int_cidcobranzaic + ",'" + _Str_Compañia + "','" + _Str_NumeroDocumento + "','" + _Str_TipoDocumentoCorto + "','" + _Str_cbancoemisor + "','" + _Str_cbancodeposito + "','" + _Str_cnumcuenta + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Dt_FechaEmision)) + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Dt_FechaVencimiento)) + "'," + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcl_Monto) + ",GETDATE(),'" + Frm_Padre._Str_Use + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        }
                        break;
                }
            }

            //Recorro los documentos de pago
            foreach (DataGridViewRow _DgRow in _Dg_DocPago.Rows)
            {
                //Tomo los valores
                string _Str_Compañia = Frm_Padre._Str_Comp;
                string _Str_Proveedor = _Cmb_CompaniaRelacionada.SelectedValue.ToString();
                string _Str_TipoDocumentoLargo = _DgRow.Cells["_Dg_DocPag_Col_Tipo"].Value.ToString();
                string _Str_TipoDocumentoCorto = _Mtd_ConvertirTipoDocumentoDeLargoACorto(_Str_TipoDocumentoLargo);
                DateTime _Dt_FechaEmision = Convert.ToDateTime(_DgRow.Cells["_Dg_DocPag_Col_Emision"].Value.ToString());
                DateTime _Dt_FechaVencimiento = Convert.ToDateTime(_DgRow.Cells["_Dg_DocPag_Col_Vencimiento"].Value.ToString());
                String _Str_cbancoemisor = _DgRow.Cells["_Dg_DocPag_Col_cbancoemisor"].Value.ToString();
                String _Str_cbancodeposito = _DgRow.Cells["_Dg_DocPag_Col_cbancodeposito"].Value.ToString();
                String _Str_cnumcuenta = _DgRow.Cells["_Dg_DocPag_Col_cnumcuenta"].Value.ToString();
                string _Str_NumeroDocumento = _DgRow.Cells["_Dg_DocPag_Col_Documento"].Value.ToString();
                decimal _Dcl_Monto = Convert.ToDecimal(_DgRow.Cells["_Dg_DocPag_Col_Monto"].Value);
                //En función al tipo de documento
                switch (_Str_TipoDocumentoLargo)
                {
                    case "FACTURA CXC":
                    case "NOTA DE DEBITO CXC":
                    case "NOTA DE CREDITO CXC":
                    case "AVISO DE COBRO CXC":
                        //Verifico si el registro existe
                        if (_Mtd_ExisteRegistro_TICOBRAD_CXC(_Str_Compañia, Convert.ToInt32(_Str_NumeroDocumento), _Str_TipoDocumentoCorto)) //Si existe Modifico
                        {
                            //Genero el SQL
                            _G_Str_SentenciaSQL = "";
                            _G_Str_SentenciaSQL += "UPDATE TICCOBRAD_CXC ";
                            _G_Str_SentenciaSQL += "SET ";
                            _G_Str_SentenciaSQL += "  cidcobranzaic = " + _Int_cidcobranzaic + " ";
                            _G_Str_SentenciaSQL += ", cmonto = " + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcl_Monto) + " ";
                            _G_Str_SentenciaSQL += ", cdateadd = GETDATE()";
                            _G_Str_SentenciaSQL += ", cuseradd = '" + Frm_Padre._Str_Use + "' ";
                            _G_Str_SentenciaSQL += "WHERE ";
                            _G_Str_SentenciaSQL += "ccompany = '" + _Str_Compañia + "' ";
                            _G_Str_SentenciaSQL += " AND ";
                            _G_Str_SentenciaSQL += "cnumdocu = " + Convert.ToInt32(_Str_NumeroDocumento) + " ";
                            _G_Str_SentenciaSQL += " AND ";
                            _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        }
                        else //Sino existe Inserto
                        {
                            //Genero el SQL
                            _G_Str_SentenciaSQL = "";
                            _G_Str_SentenciaSQL += "INSERT INTO TICCOBRAD_CXC ";
                            _G_Str_SentenciaSQL += "([cidcobranzaic],[ccompany],[cnumdocu],[ctipodocument],[cfechaemision],[cfechavencimiento],[cmonto],[cdateadd],[cuseradd]) ";
                            _G_Str_SentenciaSQL += " VALUES ";
                            _G_Str_SentenciaSQL += "(" + _Int_cidcobranzaic + ",'" + _Str_Compañia + "'," + Convert.ToInt32(_Str_NumeroDocumento) + ",'" + _Str_TipoDocumentoCorto + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Dt_FechaEmision)) + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Dt_FechaVencimiento)) + "'," + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcl_Monto) + ",GETDATE(),'" + Frm_Padre._Str_Use + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        }
                        break;
                    case "FACTURA CXP":
                    case "NOTA DE DEBITO CXP":
                    case "NOTA DE CREDITO CXP":
                    case "NOTA DE DEBITO PROVEEDOR CXP":
                    case "NOTA DE CREDITO PROVEEDOR CXP":
                    case "AVISO DE COBRO CXP":
                        //Verifico si el registro existe
                        if (_Mtd_ExisteRegistro_TICOBRAD_CXP(_Str_Compañia, _Str_NumeroDocumento, _Str_TipoDocumentoCorto, _Str_Proveedor)) //Si existe Modifico
                        {
                            //Genero el SQL
                            _G_Str_SentenciaSQL = "";
                            _G_Str_SentenciaSQL += "UPDATE TICCOBRAD_CXP ";
                            _G_Str_SentenciaSQL += "SET ";
                            _G_Str_SentenciaSQL += "  cidcobranzaic = " + _Int_cidcobranzaic + " ";
                            _G_Str_SentenciaSQL += ", cmonto = " + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcl_Monto) + " ";
                            _G_Str_SentenciaSQL += ", cdateadd = GETDATE()";
                            _G_Str_SentenciaSQL += ", cuseradd = '" + Frm_Padre._Str_Use + "' ";
                            _G_Str_SentenciaSQL += "WHERE ";
                            _G_Str_SentenciaSQL += "ccompany = '" + _Str_Compañia + "' ";
                            _G_Str_SentenciaSQL += " AND ";
                            _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                            _G_Str_SentenciaSQL += " AND ";
                            _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                            _G_Str_SentenciaSQL += " AND ";
                            _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        }
                        else //Sino existe Inserto
                        {
                            //Genero el SQL
                            _G_Str_SentenciaSQL = "";
                            _G_Str_SentenciaSQL += "INSERT INTO TICCOBRAD_CXP ";
                            _G_Str_SentenciaSQL += "([cidcobranzaic],[ccompany],[cnumdocu],[ctipodocument],[cproveedor],[cfechaemision],[cfechavencimiento],[cmonto],[cdateadd],[cuseradd]) ";
                            _G_Str_SentenciaSQL += " VALUES ";
                            _G_Str_SentenciaSQL += "(" + _Int_cidcobranzaic + ",'" + _Str_Compañia + "','" + _Str_NumeroDocumento + "','" + _Str_TipoDocumentoCorto + "','" + _Str_Proveedor + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Dt_FechaEmision)) + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Dt_FechaVencimiento)) + "'," + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcl_Monto) + ",GETDATE(),'" + Frm_Padre._Str_Use + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        }
                        break;
                    case "CHEQUE":
                    case "TRANSFERENCIA":
                        //Verifico si el registro existe
                        if (_Mtd_ExisteRegistro_TICOBRAD_PAG(_Str_NumeroDocumento, _Str_TipoDocumentoCorto, _Str_cbancoemisor)) //Si existe Modifico
                        {
                            //Genero el SQL
                            _G_Str_SentenciaSQL = "";
                            _G_Str_SentenciaSQL += "UPDATE TICCOBRAD_PAG ";
                            _G_Str_SentenciaSQL += "SET ";
                            _G_Str_SentenciaSQL += "  cidcobranzaic = " + _Int_cidcobranzaic + " ";
                            _G_Str_SentenciaSQL += ", cbancodeposito = '" + _Str_cbancodeposito + "' ";
                            _G_Str_SentenciaSQL += ", cnumcuenta = '" + _Str_cnumcuenta + "' ";
                            _G_Str_SentenciaSQL += ", cfechaemision = '" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Dt_FechaEmision)) + "' ";
                            _G_Str_SentenciaSQL += ", cfechavencimiento = '" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Dt_FechaVencimiento)) + "' ";
                            _G_Str_SentenciaSQL += ", cmonto = " + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcl_Monto) + " ";
                            _G_Str_SentenciaSQL += ", cdateadd = GETDATE()";
                            _G_Str_SentenciaSQL += ", cuseradd = '" + Frm_Padre._Str_Use + "' ";
                            _G_Str_SentenciaSQL += "WHERE ";
                            _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                            _G_Str_SentenciaSQL += " AND ";
                            _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                            _G_Str_SentenciaSQL += " AND ";
                            _G_Str_SentenciaSQL += "cbancoemisor = '" + _Str_cbancoemisor + "' ";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        }
                        else //Sino existe Inserto
                        {
                            //Genero el SQL
                            _G_Str_SentenciaSQL = "";
                            _G_Str_SentenciaSQL += "INSERT INTO TICCOBRAD_PAG ";
                            _G_Str_SentenciaSQL += "([cidcobranzaic],[ccompany],[cnumdocu],[ctipodocument],[cbancoemisor],[cbancodeposito],[cnumcuenta],[cfechaemision],[cfechavencimiento],[cmonto],[cdateadd],[cuseradd]) ";
                            _G_Str_SentenciaSQL += " VALUES ";
                            _G_Str_SentenciaSQL += "(" + _Int_cidcobranzaic + ",'" + _Str_Compañia + "','" + _Str_NumeroDocumento + "','" + _Str_TipoDocumentoCorto + "','" + _Str_cbancoemisor + "','" + _Str_cbancodeposito + "','" + _Str_cnumcuenta + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Dt_FechaEmision)) + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Dt_FechaVencimiento)) + "'," + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcl_Monto) + ",GETDATE(),'" + Frm_Padre._Str_Use + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        }
                        break;
                }
            }

            //Mensaje
            MessageBox.Show("La cobranza ha sido guardada satisfactoriamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //coloco en formulario en espera
            _Mtd_Cancelar();
            //}
            //catch (Exception _Err_)
            //{
            //}
        }
        private bool _Mtd_ExisteRegistro_TICOBRAD_CXC(string _P_Str_ccompany, int _P_Int_cnumdocu, string _P_Str_ctipodocument)
        {
            string _SQL = "";
            DataSet _Ds;
            _SQL += "SELECT cidcobranzaic FROM TICCOBRAD_CXC ";
            _SQL += " WHERE ";
            _SQL += "ccompany = '" + _P_Str_ccompany + "' ";
            _SQL += "AND ";
            _SQL += "cnumdocu = " + _P_Int_cnumdocu + " ";
            _SQL += "AND ";
            _SQL += "ctipodocument = '" + _P_Str_ctipodocument + "' ";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_SQL);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool _Mtd_ExisteRegistro_TICOBRAD_CXP(string _P_Str_ccompany, string _P_Str_cnumdocu, string _P_Str_ctipodocument, string _P_Str_cproveedor)
        {
            string _SQL = "";
            DataSet _Ds;
            _SQL += "SELECT cidcobranzaic FROM TICCOBRAD_CXP ";
            _SQL += " WHERE ";
            _SQL += "ccompany = '" + _P_Str_ccompany + "' ";
            _SQL += "AND ";
            _SQL += "cnumdocu = '" + _P_Str_cnumdocu + "' ";
            _SQL += "AND ";
            _SQL += "ctipodocument = '" + _P_Str_ctipodocument + "' ";
            _SQL += "AND ";
            _SQL += "cproveedor = '" + _P_Str_cproveedor + "' ";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_SQL);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool _Mtd_ExisteRegistro_TICOBRAD_PAG(string _P_Str_cnumdocu, string _P_Str_ctipodocument, string _P_Str_cbancoemisor)
        {
            string _SQL = "";
            DataSet _Ds;
            _SQL += "SELECT cidcobranzaic FROM TICCOBRAD_PAG ";
            _SQL += " WHERE ";
            _SQL += "cnumdocu = '" + _P_Str_cnumdocu + "' ";
            _SQL += "AND ";
            _SQL += "ctipodocument = '" + _P_Str_ctipodocument + "' ";
            _SQL += "AND ";
            _SQL += "cbancoemisor = '" + _P_Str_cbancoemisor + "' ";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_SQL);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Método que se usa para el cierre del proceso.
        /// </summary>
        private void _Mtd_TerminarProceso()
        {
            _G_Int_Proceso = _G_EnumTipoDeProceso.EnEspera;
            _Mtd_Consultar();
            _Tb_Tab.SelectedIndex = 0;
            _Mtd_ColocarBotones();
        }
        /// <summary>
        /// Método que genera el comprobante contable de la cobranza
        /// </summary>
        /// <returns>Retorna el id del comprobante contable</returns>
        private int _Mtd_GenerarComprobante(int _P_Int_cidcomprob = 0)
        {
            //vARIABLES
            int _Int_Comprobante;
            string _Str_SQL;
            //-------------------------------------------------------
            string _Str_ProcesoCont = "P_CXC_COBRO_CIA_RELA";
            Clases._Cls_ProcesosCont _Cls_Proceso_Cont = new T3.Clases._Cls_ProcesosCont(_Str_ProcesoCont);
            string _Str_Cconceptocomp = _Cls_Proceso_Cont._Field_ConceptoComprobante;
            string _Str_Ctypcompro = _Cls_Proceso_Cont._Field_TipoComprobante;
            //-------------------------------------------------------

            if (_P_Int_cidcomprob == 0) //GENERO
            {
                _Int_Comprobante = _myUtilidad._Mtd_Consecutivo_TCOMPROBANC();
                _Str_SQL = "INSERT INTO TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante + "','" + _Str_Ctypcompro + "','" + _Str_Cconceptocomp + "','" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Mtd_TotalDebeHaber(3))) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Mtd_TotalDebeHaber(4))) + "','0',GETDATE(),'" + Frm_Padre._Str_Use + "','1','9')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
            }
            else // MODIFICO
            {
                //Paso la Id del comprobante a modificar
                _Int_Comprobante = _P_Int_cidcomprob;
                //Actualizo el Comprobante
                _Str_SQL = "UPDATE TCOMPROBANC ";
                _Str_SQL += " SET ";
                _Str_SQL += "  cstatus = 9 ";
                _Str_SQL += ", cdateupd = GETDATE() ";
                _Str_SQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                _Str_SQL += "WHERE ";
                _Str_SQL += "ccompany='" + Frm_Padre._Str_Comp + "' ";
                _Str_SQL += "AND ";
                _Str_SQL += "cidcomprob = " + _G_Int_cidcomprob;
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                //Borro el Detalle del comprobante
                _Str_SQL = "";
                _Str_SQL += "DELETE TCOMPROBAND ";
                _Str_SQL += "WHERE ";
                _Str_SQL += "ccompany = '" + Frm_Padre._Str_Comp + "' ";
                _Str_SQL += "AND ";
                _Str_SQL += "cidcomprob = " + _G_Int_cidcomprob + " ";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                //Borro el Detalle Detalle del comprobante
                _Str_SQL = "";
                _Str_SQL += "DELETE TCOMPROBANDD ";
                _Str_SQL += "WHERE ";
                _Str_SQL += "ccompany = '" + Frm_Padre._Str_Comp + "' ";
                _Str_SQL += "AND ";
                _Str_SQL += "cidcomprob = " + _G_Int_cidcomprob + " ";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                //Genero de nuevo el detalle del comprobante
            }
            //-------------------------------------------------------
            object _Ob_DebeD = new object();
            object _Ob_HaberD = new object();
            string _Str_DescripD = "";
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (_Dg_Row.Cells[0].Value.ToString().Trim().Length > 0)
                    {
                        _Ob_DebeD = _Dg_Row.Cells[3].Value;
                        if (_Ob_DebeD == null)
                        { _Ob_DebeD = 0; }
                        else if (_Ob_DebeD.ToString().Trim().Length == 0)
                        { _Ob_DebeD = 0; }
                        //---------------------------
                        _Ob_HaberD = _Dg_Row.Cells[4].Value;
                        if (_Ob_HaberD == null)
                        { _Ob_HaberD = 0; }
                        else if (_Ob_HaberD.ToString().Trim().Length == 0)
                        { _Ob_HaberD = 0; }
                        //---------------------------
                        _Str_DescripD = Convert.ToString(_Dg_Row.Cells[2].Value).Trim().ToUpper() + " SEGÚN COBRANZA N° " + _Txt_IdCobranza.Text;
                        //------------------------------------------------------------------------
                        _Str_SQL = "INSERT INTO TCOMPROBAND (ccompany,cidcomprob,corder,ccount,cdescrip,ctdocument,cnumdocu,cdatedocu,ctotdebe,ctothaber,cdateadd,cuseradd)";
                        _Str_SQL += " VALUES('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante.ToString() + "','" + (_Dg_Row.Index + 1) + "','" + Convert.ToString(_Dg_Row.Cells[0].Value).Trim() + "','" + _Str_DescripD + "','" + Convert.ToString(_Dg_Row.Cells["_Col_Tipo_Doc"].Value).Trim() + "','" + _Txt_IdCobranza.Text.Trim().ToUpper() + "',GETDATE(),'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_DebeD)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_HaberD)) + "',GETDATE(),'" + Frm_Padre._Str_Use + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                        if (Convert.ToDouble(_Ob_DebeD) > 0)
                        {
                            CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(), Convert.ToString(_Dg_Row.Cells[0].Value).Trim(), _Cmb_CompaniaRelacionada.SelectedValue.ToString(), _Str_DescripD, Convert.ToString(_Dg_Row.Cells["_Col_Tipo_Doc"].Value).Trim(), Convert.ToString(_Dg_Row.Cells["_Col_Documento"].Value).Trim(), Convert.ToString(_Dg_Row.Cells["_Col_Fecha_Emision"].Value).Trim(), Convert.ToString(_Dg_Row.Cells["_Col_Fecha_Vencimiento"].Value).Trim(), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_DebeD)), Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), "D");
                        }
                        else
                        {
                            CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(), Convert.ToString(_Dg_Row.Cells[0].Value).Trim(), _Cmb_CompaniaRelacionada.SelectedValue.ToString(), _Str_DescripD, Convert.ToString(_Dg_Row.Cells["_Col_Tipo_Doc"].Value).Trim(), Convert.ToString(_Dg_Row.Cells["_Col_Documento"].Value).Trim(), Convert.ToString(_Dg_Row.Cells["_Col_Fecha_Emision"].Value).Trim(), Convert.ToString(_Dg_Row.Cells["_Col_Fecha_Vencimiento"].Value).Trim(), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_HaberD)), Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), "H");
                        }

                    }
                }
            }
            return _Int_Comprobante;
        }
        public void _Mtd_Habilitar()
        {
            if (_G_Int_Proceso == _G_EnumTipoDeProceso.Creando)
            {
            }
            else if (_G_Int_Proceso == _G_EnumTipoDeProceso.Modificando)
            {
            }
            if (_G_Int_EstadoCobranza == _G_EnumTipoDeEstado.Aprobada)
            {
            }
            else if (_G_Int_EstadoCobranza == _G_EnumTipoDeEstado.Devuelta)
            {
                _Cmb_CompaniaRelacionada.Enabled = false;
                _Txt_Estado.Enabled = false;
                _Txt_Fecha.Enabled = false;

                _Bt_AgregarDocumentosCobrados.Enabled = true;
                _Bt_AgregarDocumentosDePago.Enabled = true;
                _Cmb_TipoDeDocumentoDePago.Enabled = true;
                _Bt_VisualizarComprobante.Enabled = true;

                _Bt_AprobarCobranza.Enabled = false;
                _Bt_DevolverCobranza.Enabled = false;
                _Bt_GuadarCobranza.Enabled = true;
                _Bt_Cancelar.Enabled = true;

                _G_Int_Proceso = _G_EnumTipoDeProceso.Modificando;
            }
            else if (_G_Int_Proceso == _G_EnumTipoDeProceso.Consultando)
            {
                if (_G_Int_EstadoCobranza == _G_EnumTipoDeEstado.Aprobada)
                {
                }
                else if (_G_Int_EstadoCobranza == _G_EnumTipoDeEstado.Devuelta)
                {
                }
                else if (_G_Int_EstadoCobranza == _G_EnumTipoDeEstado.PorAprobar)
                {
                    _Cmb_CompaniaRelacionada.Enabled = false;
                    _Txt_Estado.Enabled = false;
                    _Txt_Fecha.Enabled = false;

                    _Bt_AgregarDocumentosCobrados.Enabled = true;
                    _Bt_AgregarDocumentosDePago.Enabled = true;
                    _Cmb_TipoDeDocumentoDePago.Enabled = true;
                    _Bt_VisualizarComprobante.Enabled = true;

                    _Bt_AprobarCobranza.Enabled = false;
                    _Bt_DevolverCobranza.Enabled = false;
                    _Bt_GuadarCobranza.Enabled = false;
                    _Bt_Cancelar.Enabled = true;
                }
            }
            else if (_G_Int_Proceso == _G_EnumTipoDeProceso.EnEspera)
            {
            }
        }
        /// <summary>
        /// Método para deshabilitar el formulario
        /// </summary>
        private void _Mtd_Deshabilitar()
        {
            //_Bt_VisualizarComprobante.Enabled = false;
            _Cmb_CompaniaRelacionada.Enabled = false;
            _Txt_Estado.Enabled = false;
            _Txt_Fecha.Enabled = false;
            _Bt_AgregarDocumentosCobrados.Enabled = false;
            _Bt_AgregarDocumentosDePago.Enabled = false;
            _Cmb_TipoDeDocumentoDePago.Enabled = false;
            _Bt_AprobarCobranza.Enabled = false;
            _Bt_DevolverCobranza.Enabled = false;
            _Bt_GuadarCobranza.Enabled = false;
            _Bt_Cancelar.Enabled = false;
        }
        /// <summary>
        /// Método que permite visualizar el comprobante emitido
        /// </summary>
        private void _Mtd_VisualizarComprobanteEmitido()
        {
            try
            {
                //Borro el comprobante
                _Dg_Comprobante.Rows.Clear();
                //Genero la consulta del detalle del comprobante
                _G_Str_SentenciaSQL = "SELECT ccount, cdescrip,ctotdebe, ctothaber, ctdocument FROM TCOMPROBAND WHERE CIDCOMPROB='" + _G_Int_cidcomprob + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                _G_Ds_CobranzaEncabezado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
                //Recorro
                foreach (DataRow _Dtw_Item in _G_Ds_CobranzaEncabezado.Tables[0].Rows)
                {
                    _Dg_Comprobante.Rows.Add();
                    _Dg_Comprobante[0, _Dg_Comprobante.RowCount - 1].Value = _Dtw_Item["ccount"].ToString().Trim();

                    String _Str_Descripcion = _Dtw_Item["cdescrip"].ToString().Trim();
                    _Str_Descripcion = _Str_Descripcion.Remove(_Str_Descripcion.IndexOf(" SEGÚN COBRANZA N° "));
                    _Dg_Comprobante[2, _Dg_Comprobante.RowCount - 1].Value = _Str_Descripcion;

                    _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = _Dtw_Item["ctdocument"].ToString().Trim();
                    if (Convert.ToDouble(_Dtw_Item["ctotdebe"].ToString()) > 0)
                    {
                        _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = Convert.ToDouble(_Dtw_Item["ctotdebe"].ToString()).ToString("#,##0.00");
                        _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = "";
                    }
                    else
                    {
                        _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = "";
                        _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = Convert.ToDouble(_Dtw_Item["ctothaber"].ToString()).ToString("#,##0.00");
                    }
                }
                if (_Dg_Comprobante.RowCount > 0)
                {
                    _Dg_Comprobante.Rows.Add(new object[] { null, null, "TOTAL", _Mtd_TotalDebeHaber(3), _Mtd_TotalDebeHaber(4) });
                }
                //                _Mtd_HabilitarCeldaXXXX(true);
                _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            catch
            {
            }
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _G_EnumTipoDeEstado _Int_cestado;

            //Bandera
            _G_Int_Proceso = _G_EnumTipoDeProceso.Consultando;
            //Cargo los Controles
            _Mtd_CargarCombosCompañiasRelacionadas();
            _Mtd_CargarComboEstado();
            //Obtengo los Datos seleccionados
            _G_Int_IdDocumento = Convert.ToInt32(_Dg_Grid.Rows[e.RowIndex].Cells["cidcobranzaic"].Value.ToString());
            _Int_cestado = (_G_EnumTipoDeEstado)Convert.ToInt32(_Dg_Grid.Rows[e.RowIndex].Cells["cestado"].Value.ToString());
            //Cargo la Cobranza
            _Mtd_CargarCobranza(Frm_Padre._Str_Comp, _G_Int_IdDocumento);

            //En función al Estado de la Cobranza
            if (_Int_cestado == _G_EnumTipoDeEstado.Aprobada)
            {
                //Activar Botones
                _Bt_AprobarCobranza.Enabled = false;
                _Bt_DevolverCobranza.Enabled = false;
                _Mtd_Deshabilitar();
                _Tb_Tab.SelectedIndex = 1;
            }
            else if (_Int_cestado == _G_EnumTipoDeEstado.Devuelta)
            {
                //Activar Botones
                _Bt_AprobarCobranza.Enabled = false;
                _Bt_DevolverCobranza.Enabled = false;
                _Mtd_Deshabilitar();
                _Tb_Tab.SelectedIndex = 1;
            }
            else if (_Int_cestado == _G_EnumTipoDeEstado.PorAprobar)
            {
                //Activar Botones
                _Bt_AprobarCobranza.Enabled =  _G_Bol_PermisoAprobacion;
                _Bt_DevolverCobranza.Enabled = _G_Bol_PermisoAprobacion;
                _Mtd_Deshabilitar();
                _Tb_Tab.SelectedIndex = 1;
            }

            _G_Int_Proceso = _G_EnumTipoDeProceso.Consultando;
            _Mtd_ColocarBotones();

        }

        private string _Mtd_GenerarFiltradoParaDocumentosCobrados()
        {
            string _Str_Resultado = "";
            string _Str_Compañia = "";
            string _Str_Proveedor = "";
            string _Str_TipoDocumento = "";
            string _Str_NumeroDocumento;
            int _Int_Contador = 0;
            //Genero el SQl para Filtrar el Grid
            if (_Dg_DocCobr.Rows.Count > 0)
            {
                _Str_Resultado += " AND NOT (";
            }
            //Por cada fila
            foreach (DataGridViewRow _DgRow in _Dg_DocCobr.Rows)
            {
                //Tomo los valores
                _Str_Compañia = Frm_Padre._Str_Comp;
                _Str_Proveedor = _Cmb_CompaniaRelacionada.SelectedValue.ToString();
                _Str_TipoDocumento = _DgRow.Cells["_Dg_DocCob_Col_Tipo"].Value.ToString();
                _Str_NumeroDocumento = _DgRow.Cells["_Dg_DocCob_Col_Documento"].Value.ToString();
                //Genero el SQL
                if (_Int_Contador > 0)
                {
                    _Str_Resultado += " AND ";
                }
                _Str_Resultado += " (ctipo = '" + _Str_TipoDocumento + "' AND cnumdocu = " + _Str_NumeroDocumento + ") ";
                _Int_Contador++;
            }
            if (_Dg_DocCobr.Rows.Count > 0)
            {
                _Str_Resultado += ") ";
            }
            //Devuelvo
            return _Str_Resultado;
        }
        private string _Mtd_GenerarFiltradoParaDocumentosDePago()
        {
            string _Str_Resultado = "";
            string _Str_Compañia = "";
            string _Str_Proveedor = "";
            string _Str_TipoDocumento = "";
            string _Str_NumeroDodumento;
            int _Int_Contador = 0;
            //Genero el SQl para Filtrar el Grid
            if (_Dg_DocPago.Rows.Count > 0)
            {
                _Str_Resultado += " AND NOT (";
            }
            //Por cada fila
            foreach (DataGridViewRow _DgRow in _Dg_DocPago.Rows)
            {
                //Tomo los valores
                _Str_Compañia = Frm_Padre._Str_Comp;
                _Str_Proveedor = _Cmb_CompaniaRelacionada.SelectedValue.ToString();
                _Str_TipoDocumento = _DgRow.Cells["_Dg_DocPag_Col_Tipo"].Value.ToString();
                _Str_NumeroDodumento = _DgRow.Cells["_Dg_DocPag_Col_Documento"].Value.ToString();
                //Genero el SQL
                if (_Int_Contador > 0)
                {
                    _Str_Resultado += " AND ";
                }
                _Str_Resultado += " (ctipo = '" + _Str_TipoDocumento + "' AND cnumdocu = '" + _Str_NumeroDodumento + "') ";
                _Int_Contador++;
            }
            if (_Dg_DocPago.Rows.Count > 0)
            {
                _Str_Resultado += ") ";
            }
            //Devuelvo
            return _Str_Resultado;
        }
        private void _Bt_AgregarDocumentosCobrados_Click(object sender, EventArgs e)
        {
            //Valido si hay proveedor seleccionado
            if (_Cmb_CompaniaRelacionada.SelectedValue.ToString() == "nulo")
            {
                MessageBox.Show("Deben seleccionar una compañía relacionada", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Er_Error.SetError(_Cmb_CompaniaRelacionada, "Información requerida!!!");
                return;
            }

            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(91, _Cmb_CompaniaRelacionada.SelectedValue.ToString(), _Mtd_GenerarFiltradoParaDocumentosCobrados());
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
            if (_Frm._Str_FrmResult == "1")
            {
                int _Int_IndiceFilaActual = _Frm._Dg_Grid.CurrentCell.RowIndex;
                int _Int_IndiceFilaNueva;

                //Verifico que el Documento ya no este en una orden de pago
                string _Str_CodigoProveedor = _Cmb_CompaniaRelacionada.SelectedValue.ToString();
                string _Str_TipoDocumento = _Frm._Dg_Grid.Rows[_Int_IndiceFilaActual].Cells["Tipo"].Value.ToString().ToUpper();
                string _Str_NumeroDocumento = _Frm._Dg_Grid.Rows[_Int_IndiceFilaActual].Cells["Documento"].Value.ToString().ToUpper();
                string _Str_CodigoOrdenPago = _Cls_RutinasIc._Mtd_DocumentoSeEncuentraEnOrdenPagoNoAnulada(_Str_CodigoProveedor, _Str_TipoDocumento, _Str_NumeroDocumento);
                if (_Str_CodigoOrdenPago != "")
                {
                    MessageBox.Show("El siguiente documento ya se encuentra en la orden de pago No. " + _Str_CodigoOrdenPago + " . Por favor verifique: \n" + _Str_TipoDocumento + ", No. " + _Str_NumeroDocumento, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Añado la Fila
                _Dg_DocCobr.Rows.Add();
                //Guardo el indice de la nueva fila
                _Int_IndiceFilaNueva = _Dg_DocCobr.RowCount - 1;
                //Paso los Datos
                _Dg_DocCobr["_Dg_DocCob_Col_Emision", _Int_IndiceFilaNueva].Value = _Frm._Dg_Grid.Rows[_Int_IndiceFilaActual].Cells["Emisión"].Value.ToString().ToUpper();
                _Dg_DocCobr["_Dg_DocCob_Col_Vencimiento", _Int_IndiceFilaNueva].Value = _Frm._Dg_Grid.Rows[_Int_IndiceFilaActual].Cells["Vencimiento"].Value.ToString().ToUpper();
                _Dg_DocCobr["_Dg_DocCob_Col_Documento", _Int_IndiceFilaNueva].Value = _Frm._Dg_Grid.Rows[_Int_IndiceFilaActual].Cells["Documento"].Value.ToString().ToUpper();
                _Dg_DocCobr["_Dg_DocCob_Col_Tipo", _Int_IndiceFilaNueva].Value = _Frm._Dg_Grid.Rows[_Int_IndiceFilaActual].Cells["Tipo"].Value.ToString().ToUpper();
                _Dg_DocCobr["_Dg_DocCob_Col_Monto", _Int_IndiceFilaNueva].Value = _Frm._Dg_Grid.Rows[_Int_IndiceFilaActual].Cells["Monto"].Value.ToString().ToUpper();
                //Actualizo los Montos
                _Mtd_ActualizarMontosGrids();
            }
            _Frm.Dispose();
            _Frm = null;


        }
        private void _Bt_AgregarDocumentosDePago_Click(object sender, EventArgs e)
        {
            //Valido si hay proveedor seleccionado
            if (_Cmb_CompaniaRelacionada.SelectedValue.ToString() == "nulo")
            {
                MessageBox.Show("Deben seleccionar una compañía relacionada", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Er_Error.SetError(_Cmb_CompaniaRelacionada, "Información requerida!!!");
                return;
            }

            //En función al combo de tipo de documento
            if (_Cmb_TipoDeDocumentoDePago.SelectedIndex == 0) //Documento Intercompañía
            {
                Cursor = Cursors.WaitCursor;
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(92, _Cmb_CompaniaRelacionada.SelectedValue.ToString(), _Mtd_GenerarFiltradoParaDocumentosDePago());
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
                if (_Frm._Str_FrmResult == "1")
                {
                    int _Int_IndiceFilaActual = _Frm._Dg_Grid.CurrentCell.RowIndex;
                    int _Int_IndiceFilaNueva;

                    //Verifico que el Documento ya no este en una orden de pago
                    string _Str_CodigoProveedor = _Cmb_CompaniaRelacionada.SelectedValue.ToString();
                    string _Str_TipoDocumento = _Frm._Dg_Grid.Rows[_Int_IndiceFilaActual].Cells["Tipo"].Value.ToString().ToUpper();
                    string _Str_NumeroDocumento = _Frm._Dg_Grid.Rows[_Int_IndiceFilaActual].Cells["Documento"].Value.ToString().ToUpper();
                    string _Str_CodigoOrdenPago = _Cls_RutinasIc._Mtd_DocumentoSeEncuentraEnOrdenPagoNoAnulada(_Str_CodigoProveedor, _Str_TipoDocumento, _Str_NumeroDocumento);
                    if (_Str_CodigoOrdenPago != "")
                    {
                        MessageBox.Show("El siguiente documento ya se encuentra en la orden de pago No. " + _Str_CodigoOrdenPago + " . Por favor verifique: \n" + _Str_TipoDocumento + ", No. " + _Str_NumeroDocumento, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    
                    //Añado la Fila
                    _Dg_DocPago.Rows.Add();
                    //Guardo el indice de la nueva fila
                    _Int_IndiceFilaNueva = _Dg_DocPago.RowCount - 1;
                    //Paso los Datos
                    _Dg_DocPago["_Dg_DocPag_Col_Emision", _Int_IndiceFilaNueva].Value = _Frm._Dg_Grid.Rows[_Int_IndiceFilaActual].Cells["Emisión"].Value.ToString().ToUpper();
                    _Dg_DocPago["_Dg_DocPag_Col_Vencimiento", _Int_IndiceFilaNueva].Value = _Frm._Dg_Grid.Rows[_Int_IndiceFilaActual].Cells["Vencimiento"].Value.ToString().ToUpper();
                    _Dg_DocPago["_Dg_DocPag_Col_Documento", _Int_IndiceFilaNueva].Value = _Frm._Dg_Grid.Rows[_Int_IndiceFilaActual].Cells["Documento"].Value.ToString().ToUpper();
                    _Dg_DocPago["_Dg_DocPag_Col_Tipo", _Int_IndiceFilaNueva].Value = _Frm._Dg_Grid.Rows[_Int_IndiceFilaActual].Cells["Tipo"].Value.ToString().ToUpper();
                    _Dg_DocPago["_Dg_DocPag_Col_BancoEmisor", _Int_IndiceFilaNueva].Value = "NO APLICA";
                    _Dg_DocPago["_Dg_DocPag_Col_BancoDeposito", _Int_IndiceFilaNueva].Value = "NO APLICA";
                    _Dg_DocPago["_Dg_DocPag_Col_NumeroCuenta", _Int_IndiceFilaNueva].Value = "NO APLICA";
                    _Dg_DocPago["_Dg_DocPag_Col_Monto", _Int_IndiceFilaNueva].Value = _Frm._Dg_Grid.Rows[_Int_IndiceFilaActual].Cells["Monto"].Value.ToString().ToUpper();
                    _Dg_DocPago["_Dg_DocPag_Col_cbancoemisor", _Int_IndiceFilaNueva].Value = "NO APLICA";
                    _Dg_DocPago["_Dg_DocPag_Col_cbancodeposito", _Int_IndiceFilaNueva].Value = "NO APLICA";
                    _Dg_DocPago["_Dg_DocPag_Col_cnumcuenta", _Int_IndiceFilaNueva].Value = "NO APLICA";
                    //Actualizo los Montos
                    _Mtd_ActualizarMontosGrids();
                }
                _Frm.Dispose();
                _Frm = null;
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                Frm_IC_CobranzaPago _Frm = new Frm_IC_CobranzaPago(this);
                Cursor = Cursors.Default;
                if (_Frm.ShowDialog(this) == DialogResult.OK)
                {
                    int _Int_IndiceFilaNueva;
                    //Añado la Fila
                    _Dg_DocPago.Rows.Add();
                    //Guardo el indice de la nueva fila
                    _Int_IndiceFilaNueva = _Dg_DocPago.RowCount - 1;
                    //Paso los Datos
                    _Dg_DocPago["_Dg_DocPag_Col_Emision", _Int_IndiceFilaNueva].Value = _Cls_Formato._Mtd_fecha(_Frm._Dtp_FechaEmision.Value);
                    _Dg_DocPago["_Dg_DocPag_Col_Vencimiento", _Int_IndiceFilaNueva].Value = _Cls_Formato._Mtd_fecha(_Frm._Dtp_FechaEmision.Value);
                    _Dg_DocPago["_Dg_DocPag_Col_Documento", _Int_IndiceFilaNueva].Value = _Frm._Txt_NumeroDocumento.Text;
                    if (_Frm._Opt_Cheque.Checked == true)
                    {
                        _Dg_DocPago["_Dg_DocPag_Col_Tipo", _Int_IndiceFilaNueva].Value = "CHEQUE";
                    }
                    else if (_Frm._Opt_Transferencia.Checked == true)
                    {
                        _Dg_DocPago["_Dg_DocPag_Col_Tipo", _Int_IndiceFilaNueva].Value = "TRANSFERENCIA";
                    }
                    _Dg_DocPago["_Dg_DocPag_Col_Monto", _Int_IndiceFilaNueva].Value = "-" + _Frm._Txt_Monto.Text;

                    _Dg_DocPago["_Dg_DocPag_Col_BancoEmisor", _Int_IndiceFilaNueva].Value = _Frm._Cmb_BancoQueEmite.Text;
                    _Dg_DocPago["_Dg_DocPag_Col_BancoDeposito", _Int_IndiceFilaNueva].Value = _Frm._Cmb_BancoEnQueFueDepositado.Text;
                    _Dg_DocPago["_Dg_DocPag_Col_NumeroCuenta", _Int_IndiceFilaNueva].Value = _Frm._Cmb_CuentaEnQueFueDepositado.SelectedValue;

                    _Dg_DocPago["_Dg_DocPag_Col_cbancoemisor", _Int_IndiceFilaNueva].Value = _Frm._Cmb_BancoQueEmite.SelectedValue;
                    _Dg_DocPago["_Dg_DocPag_Col_cbancodeposito", _Int_IndiceFilaNueva].Value = _Frm._Cmb_BancoEnQueFueDepositado.SelectedValue;
                    _Dg_DocPago["_Dg_DocPag_Col_cnumcuenta", _Int_IndiceFilaNueva].Value = _Frm._Cmb_CuentaEnQueFueDepositado.SelectedValue;
                    //Actualizo los Montos
                    _Mtd_ActualizarMontosGrids();
                }
                _Frm.Dispose();
                _Frm = null;
            }

        }
        public bool _Mtd_ExisteTipoDocumentoBancoNumeroDePago(string _P_Str_TipoDocumento, string _P_Str_cbanco, string _P_Str_NumeroDocumento)
        {
            //Por cada fila
            foreach (DataGridViewRow _DgRow in _Dg_DocPago.Rows)
            {
                //Tomo los valores
                string _Str_Compañia = Frm_Padre._Str_Comp;
                string _Str_Proveedor = _Cmb_CompaniaRelacionada.SelectedValue.ToString();
                string _Str_TipoDocumento = _DgRow.Cells["_Dg_DocPag_Col_Tipo"].Value.ToString();
                string _Str_cbanco = _DgRow.Cells["_Dg_DocPag_Col_cbancoemisor"].Value.ToString();
                string _Str_NumeroDocumento = _DgRow.Cells["_Dg_DocPag_Col_Documento"].Value.ToString();
                //Verifico
                if (_Str_TipoDocumento == _P_Str_TipoDocumento && _Str_cbanco == _P_Str_cbanco && _Str_NumeroDocumento == _P_Str_NumeroDocumento)
                {
                    return true;
                }
            }
            return false;
        }

        private void _Mtd_ActualizarMontosGrids()
        {
            //Calculo el Monto Total de los Documentos Cobrados
            //Actualizo el Monto
            _Txt_MontoTotalDocumentosCobrados.Text = _Mtd_CalcularTotalMontosDocumentoCobrados().ToString("#,##0.00");
            //Actualizo el Monto
            _Txt_MontoTotalDocumentosDePago.Text = _Mtd_CalcularTotalMontosDocumentoDePago().ToString("#,##0.00");
            //Vacio el Grid de Comprobante
            _Dg_Comprobante.Rows.Clear();
        }

        private void _Tol_EliminarDocumentoCob_Click(object sender, EventArgs e)
        {
            //Elimino la Fila Seleccionada
            _Dg_DocCobr.Rows.Remove(_Dg_DocCobr.Rows[_Dg_DocCobr.CurrentCell.RowIndex]);
            //Actualizo los Montos
            _Mtd_ActualizarMontosGrids();

        }
        private void _Tol_EliminarDocumentoPag_Click(object sender, EventArgs e)
        {
            //Elimino la Fila Seleccionada
            _Dg_DocPago.Rows.Remove(_Dg_DocPago.Rows[_Dg_DocPago.CurrentCell.RowIndex]);
            //Actualizo los Montos
            _Mtd_ActualizarMontosGrids();
        }


        private void _Cntx_MenuDocCob_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _Dg_DocCobr.SelectedRows.Count == 0;
            if (_G_Int_Proceso != _G_EnumTipoDeProceso.Creando && _G_Int_Proceso != _G_EnumTipoDeProceso.Modificando)
            {
                e.Cancel = true;
            }
        }
        private void _Cntx_MenuDocPag_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _Dg_DocPago.SelectedRows.Count == 0;
            if (_G_Int_Proceso != _G_EnumTipoDeProceso.Creando && _G_Int_Proceso != _G_EnumTipoDeProceso.Modificando)
            {
                e.Cancel = true;
            }
        }

        private void _Bt_AprobarCobranza_Click(object sender, EventArgs e)
        {
            _Mtd_AprobarCobranza();
        }
        private void _Bt_RechazarCobranza_Click(object sender, EventArgs e)
        {
            _Mtd_DevolverCobranza();
        }
        private void _Bt_GuadarCobranza_Click(object sender, EventArgs e)
        {
            _Mtd_Guardar();
        }
        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Mtd_Cancelar();
        }

        private void _Mtd_AprobarCobranza()
        {
            //Guardo la aprobacion
            _G_Str_SentenciaSQL = "";
            _G_Str_SentenciaSQL += "UPDATE TICCOBRAM ";
            _G_Str_SentenciaSQL += "SET ";
            _G_Str_SentenciaSQL += "  cestado = " + (int)_G_EnumTipoDeEstado.Aprobada + " ";
            _G_Str_SentenciaSQL += ", cfechaaprob  = GETDATE() ";
            _G_Str_SentenciaSQL += ", cuseraprob = '" + Frm_Padre._Str_Comp + "' ";
            _G_Str_SentenciaSQL += "WHERE cidiccobram = " + _G_Int_cidiccobram + "";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);

            //Guardo Los Detalles
            //Recorro los documentos cobrados
            foreach (DataGridViewRow _DgRow in _Dg_DocCobr.Rows)
            {
                //Tomo los valores
                string _Str_cgroupcomp = Frm_Padre._Str_GroupComp;
                string _Str_ccompany = Frm_Padre._Str_Comp;
                string _Str_Proveedor = _Cmb_CompaniaRelacionada.SelectedValue.ToString();
                string _Str_TipoDocumentoLargo = _DgRow.Cells["_Dg_DocCob_Col_Tipo"].Value.ToString();
                string _Str_TipoDocumentoCorto = _Mtd_ConvertirTipoDocumentoDeLargoACorto(_Str_TipoDocumentoLargo);
                DateTime _Dt_FechaEmision = Convert.ToDateTime(_DgRow.Cells["_Dg_DocCob_Col_Emision"].Value.ToString());
                DateTime _Dt_FechaVencimiento = Convert.ToDateTime(_DgRow.Cells["_Dg_DocCob_Col_Vencimiento"].Value.ToString());
                String _Str_cbancoemisor = "";
                String _Str_cbancodeposito = "";
                String _Str_cnumcuenta = "";
                string _Str_NumeroDocumento = _DgRow.Cells["_Dg_DocCob_Col_Documento"].Value.ToString();
                decimal _Dcl_Monto = Convert.ToDecimal(_DgRow.Cells["_Dg_DocCob_Col_Monto"].Value);
                //En función al tipo de documento
                switch (_Str_TipoDocumentoLargo)
                {
                    case "FACTURA CXC":
                        //Actualizo TSALDOCLIENTED
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TSALDOCLIENTED ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldofactura = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = " + _Str_NumeroDocumento + " ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        break;
                    case "NOTA DE DEBITO CXC":
                        //Actualizo TSALDOCLIENTED
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TSALDOCLIENTED ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldofactura = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = " + _Str_NumeroDocumento + " ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        break;
                    case "NOTA DE CREDITO CXC":
                        //Actualizo TNOTACREDICC
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TNOTACREDICC ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " cdescontada = 1 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cidnotcredicc = " + _Str_NumeroDocumento + " ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        //Actualizo TSALDOCLIENTED
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TSALDOCLIENTED ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldofactura = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = " + _Str_NumeroDocumento + " ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        break;
                    case "FACTURA CXP":
                        //Actualizo TMOVCXPM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TMOVCXPM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        //Actualizo TFACTPPAGARM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TFACTPPAGARM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        break;
                    case "NOTA DE DEBITO CXP":
                        //Actualizo TMOVCXPM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TMOVCXPM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        //Actualizo TNOTADEBITOCP
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TNOTADEBITOCP ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " cdescontada = 1 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cidnotadebitocxp = " + _Str_NumeroDocumento + " ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        //Actualizo TFACTPPAGARM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TFACTPPAGARM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        break;
                    case "NOTA DE CREDITO CXP":
                        //Actualizo TMOVCXPM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TMOVCXPM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        //Actualizo TFACTPPAGARM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TFACTPPAGARM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        break;
                    case "NOTA DE DEBITO PROVEEDOR CXP":
                        //Actualizo TMOVCXPM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TMOVCXPM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        //Actualizo TFACTPPAGARM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TFACTPPAGARM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = " + _Str_NumeroDocumento + " ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        break;
                    case "NOTA DE CREDITO PROVEEDOR CXP":
                        //Actualizo TMOVCXPM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TMOVCXPM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        //Actualizo TFACTPPAGARM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TFACTPPAGARM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        break;
                    case "CHEQUE":
                        break;
                    case "TRANSFERENCIA":
                        break;
                    case "AVISO DE COBRO CXC":
                        //Actualizo TAVISOCOBM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TAVISOCOBM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " cestado = 1 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccodavisocob = " + _Str_NumeroDocumento + " ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        break;
                    case "AVISO DE COBRO CXP":
                        //Actualizo TAVISOPAGM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TAVISOPAGM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " cestado = 1 ";
                        _G_Str_SentenciaSQL += ", csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccodavisopag = " + _Str_NumeroDocumento + " ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        break;
                }
            }

            //Recorro los documentos de pago
            foreach (DataGridViewRow _DgRow in _Dg_DocPago.Rows)
            {
                //Tomo los valores
                string _Str_cgroupcomp = Frm_Padre._Str_GroupComp;
                string _Str_ccompany = Frm_Padre._Str_Comp;
                string _Str_Proveedor = _Cmb_CompaniaRelacionada.SelectedValue.ToString();
                string _Str_TipoDocumentoLargo = _DgRow.Cells["_Dg_DocPag_Col_Tipo"].Value.ToString();
                string _Str_TipoDocumentoCorto = _Mtd_ConvertirTipoDocumentoDeLargoACorto(_Str_TipoDocumentoLargo);
                DateTime _Dt_FechaEmision = Convert.ToDateTime(_DgRow.Cells["_Dg_DocPag_Col_Emision"].Value.ToString());
                DateTime _Dt_FechaVencimiento = Convert.ToDateTime(_DgRow.Cells["_Dg_DocPag_Col_Vencimiento"].Value.ToString());
                String _Str_cbancoemisor = _DgRow.Cells["_Dg_DocPag_Col_cbancoemisor"].Value.ToString();
                String _Str_cbancodeposito = _DgRow.Cells["_Dg_DocPag_Col_cbancodeposito"].Value.ToString();
                String _Str_cnumcuenta = _DgRow.Cells["_Dg_DocPag_Col_cnumcuenta"].Value.ToString();
                string _Str_NumeroDocumento = _DgRow.Cells["_Dg_DocPag_Col_Documento"].Value.ToString();
                decimal _Dcl_Monto = Convert.ToDecimal(_DgRow.Cells["_Dg_DocPag_Col_Monto"].Value);
                //En función al tipo de documento
                switch (_Str_TipoDocumentoLargo)
                {
                    case "FACTURA CXC":
                        //Actualizo TSALDOCLIENTED
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TSALDOCLIENTED ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldofactura = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = " + _Str_NumeroDocumento + " ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        break;
                    case "NOTA DE DEBITO CXC":
                        //Actualizo TSALDOCLIENTED
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TSALDOCLIENTED ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldofactura = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = " + _Str_NumeroDocumento + " ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        break;
                    case "NOTA DE CREDITO CXC":
                        //Actualizo TNOTACREDICC
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TNOTACREDICC ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " cdescontada = 1 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cidnotcredicc = " + _Str_NumeroDocumento + " ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        //Actualizo TSALDOCLIENTED
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TSALDOCLIENTED ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldofactura = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = " + _Str_NumeroDocumento + " ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        break;
                    case "FACTURA CXP":
                        //Actualizo TMOVCXPM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TMOVCXPM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        //Actualizo TFACTPPAGARM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TFACTPPAGARM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        break;
                    case "NOTA DE DEBITO CXP":
                        //Actualizo TMOVCXPM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TMOVCXPM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        //Actualizo TNOTADEBITOCP
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TNOTADEBITOCP ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " cdescontada = 1 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cidnotadebitocxp = " + _Str_NumeroDocumento + " ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        //Actualizo TFACTPPAGARM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TFACTPPAGARM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        break;
                    case "NOTA DE CREDITO CXP":
                        //Actualizo TMOVCXPM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TMOVCXPM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        //Actualizo TFACTPPAGARM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TFACTPPAGARM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        break;
                    case "NOTA DE DEBITO PROVEEDOR CXP":
                        //Actualizo TMOVCXPM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TMOVCXPM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = " + _Str_NumeroDocumento + " ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        //Actualizo TFACTPPAGARM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TFACTPPAGARM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        break;
                    case "NOTA DE CREDITO PROVEEDOR CXP":
                        //Actualizo TMOVCXPM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TMOVCXPM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        //Actualizo TFACTPPAGARM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TFACTPPAGARM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "cgroupcomp = '" + _Str_cgroupcomp + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ctipodocument = '" + _Str_TipoDocumentoCorto + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cnumdocu = '" + _Str_NumeroDocumento + "' ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        break;
                    case "CHEQUE":
                        break;
                    case "TRANSFERENCIA":
                        break;
                    case "AVISO DE COBRO CXC":
                        //Actualizo TAVISOCOBM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TAVISOCOBM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " cestado = 1 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccodavisocob = " + _Str_NumeroDocumento + " ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        break;
                    case "AVISO DE COBRO CXP":
                        //Actualizo TAVISOPAGM
                        _G_Str_SentenciaSQL = "";
                        _G_Str_SentenciaSQL += "UPDATE TAVISOPAGM ";
                        _G_Str_SentenciaSQL += "SET ";
                        _G_Str_SentenciaSQL += " cestado = 1 ";
                        _G_Str_SentenciaSQL += ", csaldo = 0 ";
                        _G_Str_SentenciaSQL += ", cdateupd = GETDATE() ";
                        _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
                        _G_Str_SentenciaSQL += "WHERE ";
                        _G_Str_SentenciaSQL += "ccompany = '" + _Str_ccompany + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "cproveedor = '" + _Str_Proveedor + "' ";
                        _G_Str_SentenciaSQL += "AND ";
                        _G_Str_SentenciaSQL += "ccodavisopag = " + _Str_NumeroDocumento + " ";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                        break;
                }
            }

            //Actualizo el Comprobante Contable
            string _Str_SQL;
            //Actualizo el Comprobanted
            _Str_SQL = "UPDATE TCOMPROBANC ";
            _Str_SQL += " SET ";
            _Str_SQL += "  cstatus = 0 ";
            _Str_SQL += ", cdateupd = GETDATE() ";
            _Str_SQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
            _Str_SQL += "WHERE ";
            _Str_SQL += "ccompany='" + Frm_Padre._Str_Comp + "' ";
            _Str_SQL += "AND ";
            _Str_SQL += "cidcomprob = " + _G_Int_cidcomprob;
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

            //Mensaje
            MessageBox.Show("La cobranza No. " + _G_Int_cidcobranzaic + " ha sido guardada satisfactoriamente. El comprobante contable No. " + _Mtd_RetornarCorrel(_G_Int_cidcomprob.ToString()) + " puede ser impreso desde el notificador de comprobantes por actualizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Devuelvo el formulario su estado en espera
            _Mtd_Cancelar();
        }

        private string _Mtd_RetornarCorrel(string _P_Str_Comprobante)
        {
            string _Str_Cadena = "SELECT CONVERT(VARCHAR,ISNULL(TCOMPROBANC.ctypcomp,0))+'-'+CONVERT(VARCHAR,ISNULL(TCOMPROBANC.cmontacco,0))+'-'+CONVERT(VARCHAR,ISNULL(TCOMPROBANC.cyearacco,0))+'-'+CONVERT(VARCHAR,ISNULL(TCOMPROBANC.cidcorrel,0)) FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "0";
        }

        private void _Mtd_DevolverCobranza()
        {
            //Guardo el rechazo
            _G_Str_SentenciaSQL = "";
            _G_Str_SentenciaSQL += "UPDATE TICCOBRAM ";
            _G_Str_SentenciaSQL += "SET ";
            _G_Str_SentenciaSQL += "  cestado = " + (int)_G_EnumTipoDeEstado.Devuelta;
            _G_Str_SentenciaSQL += ", cdateupd  = GETDATE() ";
            _G_Str_SentenciaSQL += ", cuserupd = '" + Frm_Padre._Str_Use + "' ";
            _G_Str_SentenciaSQL += "WHERE cidiccobram = " + _G_Int_cidiccobram + "";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
            //Mensaje
            MessageBox.Show("La cobranza ha sido devuelta satisfactoriamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Devuelvo el formulario su estado en espera
            _Mtd_Cancelar();

        }

        private void _Dg_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == -1) && (e.RowIndex > -1))
            {
                this._Lbl_DgInfo.Visible = true;
            }
            else
            {
                this._Lbl_DgInfo.Visible = false;
            }
        }

    }

    public class PlantillaCuentaContable
    {
        public string Cuenta;
        public string Descripcion;
        public string Naturaleza;
    }
}
