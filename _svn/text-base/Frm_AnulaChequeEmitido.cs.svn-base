using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using T3.Clases;

namespace T3
{
    public partial class Frm_AnulaChequeEmitido : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_AnulaChequeEmitido()
        {
            InitializeComponent();
        }
        int _Int_Notificador = 0;
        public Frm_AnulaChequeEmitido(int _P_Int_Notificador)
        {
            InitializeComponent();
            _Int_Notificador = _P_Int_Notificador;
            this.Text += _Int_Notificador == 1 ? " (Por Aprobar)" : " (Por Imprimir)";
        }
        private void _Mtd_Color_Estandar(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Color_Estandar(_Ctrl);
                }
                new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco();
            }
        }
        private void _Mtd_Sorted(DataGridView _P_Dg_Grid)
        {
            for (int _Int_i = 0; _Int_i < _P_Dg_Grid.Columns.Count; _Int_i++)
            {
                _P_Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
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
        private void _Mtd_VisualizarComprobanteAnul(string _P_Str_Comprobante)
        {
            _Dg_Comprobante.Rows.Clear();
            string _Str_Cadena = "SELECT CASE WHEN TCOUNTINAC.ccountactiva IS NULL THEN TCOMPROBAND.ccount ELSE TCOUNTINAC.ccountactiva END AS ccount,CASE WHEN TCOUNTINAC.ccountactiva IS NULL THEN LTRIM(RTRIM(TCOMPROBAND.cdescrip)) ELSE REPLACE(TCOMPROBAND.cdescrip COLLATE DATABASE_DEFAULT, LTRIM(RTRIM(TCOUNT.cname)),LTRIM(RTRIM(TCOUNT_1.cname))) END + ' ANULACIÓN' AS cdescrip,ctotdebe,ctothaber " +
                "FROM TCOUNT AS TCOUNT_1 INNER JOIN " +
                "TCOUNTINAC ON TCOUNT_1.ccompany = TCOUNTINAC.ccompany AND TCOUNT_1.ccount = TCOUNTINAC.ccountactiva RIGHT OUTER JOIN " +
                "TCOMPROBAND INNER JOIN " +
                "TCOUNT ON TCOMPROBAND.ccompany = TCOUNT.ccompany AND TCOMPROBAND.ccount = TCOUNT.ccount ON  " +
                "TCOUNTINAC.ccompany = TCOMPROBAND.ccompany AND TCOUNTINAC.ccountinactiva = TCOMPROBAND.ccount WHERE TCOMPROBAND.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBAND.cidcomprob='" + _P_Str_Comprobante + "' ORDER BY corder ASC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            object _Ob_Debe = "";
            object _Ob_Haber = "";
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Ob_Debe = "";
                    _Ob_Haber = "";
                    //----------------------------------------------------
                    if (_Row["ctotdebe"] != System.DBNull.Value)
                    {
                        if (Convert.ToDouble(_Row["ctotdebe"].ToString().Trim()) != 0)
                        { _Ob_Debe = Convert.ToDouble(_Row["ctotdebe"].ToString().Trim()).ToString("#,##0.00"); }
                    }
                    if (_Row["ctothaber"] != System.DBNull.Value)
                    {
                        if (Convert.ToDouble(_Row["ctothaber"].ToString().Trim()) != 0)
                        { _Ob_Haber = Convert.ToDouble(_Row["ctothaber"].ToString().Trim()).ToString("#,##0.00"); }
                    }
                    //----------------------------------------------------
                    _Dg_Comprobante.Rows.Add(new object[] { _Row["ccount"].ToString().Trim(), "", _Row["cdescrip"].ToString().Trim(), _Ob_Haber, _Ob_Debe });
                }
                if (_Dg_Comprobante.RowCount > 0)
                {
                    _Dg_Comprobante.Rows.Add(new object[] { null, null, "TOTAL", _Mtd_TotalDebeHaber(4), _Mtd_TotalDebeHaber(3) });
                }
            }
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_VisualizarComprobanteExis(string _P_Str_Comprobante)
        {
            _Dg_Comprobante.Rows.Clear();
            string _Str_Cadena = "SELECT ccount,cdescrip,ctotdebe,ctothaber FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "' ORDER BY corder ASC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            object _Ob_Debe = "";
            object _Ob_Haber = "";
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Ob_Debe = "";
                    _Ob_Haber = "";
                    //----------------------------------------------------
                    if (_Row["ctotdebe"] != System.DBNull.Value)
                    {
                        if (Convert.ToDouble(_Row["ctotdebe"].ToString().Trim()) != 0)
                        { _Ob_Debe = Convert.ToDouble(_Row["ctotdebe"].ToString().Trim()).ToString("#,##0.00"); }
                    }
                    if (_Row["ctothaber"] != System.DBNull.Value)
                    {
                        if (Convert.ToDouble(_Row["ctothaber"].ToString().Trim()) != 0)
                        { _Ob_Haber = Convert.ToDouble(_Row["ctothaber"].ToString().Trim()).ToString("#,##0.00"); }
                    }
                    //----------------------------------------------------
                    _Dg_Comprobante.Rows.Add(new object[] { _Row["ccount"].ToString().Trim(), "", _Row["cdescrip"].ToString().Trim(), _Ob_Debe, _Ob_Haber });
                }
                if (_Dg_Comprobante.RowCount > 0)
                {
                    _Dg_Comprobante.Rows.Add(new object[] { null, null, "TOTAL", _Mtd_TotalDebeHaber(3), _Mtd_TotalDebeHaber(4) });
                }
            }
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        string _Str_Comprobante = "";
        string _Str_OrdenPago = "";
        string _Str_ID_EmisionCheq = "";
        private void _Mtd_CargarInformacion(string _P_Str_ID_EmisionCheq)
        {
            string _Str_Cadena = "SELECT cnumcheqtransac, LTRIM(RTRIM(cbanco)) AS cbanco, cname, cnumcuentad, cbeneficiario, cconcepto, dbo.Fnc_Formatear(cmontototal) AS cmontototal, cidordpago, cidcomprob FROM VST_CHEQUES_EMITIDOS WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidemisioncheq='" + _P_Str_ID_EmisionCheq + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Cheque.Text = _Ds.Tables[0].Rows[0]["cnumcheqtransac"].ToString().Trim(); 
                _Txt_Banco.Tag = _Ds.Tables[0].Rows[0]["cbanco"].ToString().Trim();
                _Txt_Banco.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                _Txt_Cuenta.Text = _Ds.Tables[0].Rows[0]["cnumcuentad"].ToString().Trim();
                _Txt_Beneficiario.Text = _Ds.Tables[0].Rows[0]["cbeneficiario"].ToString().Trim();
                _Txt_Concepto.Text = _Ds.Tables[0].Rows[0]["cconcepto"].ToString().Trim();
                _Txt_Monto.Text = _Ds.Tables[0].Rows[0]["cmontototal"].ToString().Trim();
                _Str_OrdenPago = _Ds.Tables[0].Rows[0]["cidordpago"].ToString().Trim();
                _Str_Comprobante = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
                _Str_ID_EmisionCheq = _P_Str_ID_EmisionCheq;
                _Mtd_VisualizarComprobanteAnul(_Str_Comprobante);
            }
        }
        private void _Mtd_Actualizar()
        {
            string _Str_Cadena = "SELECT TANULCHEQEMITIDO.cnumcheque AS [Cheque/Transf], TANULCHEQEMITIDO.cfpago AS Tipo, TBANCO.cname AS Banco, TANULCHEQEMITIDO.cnumcuentad AS Cuenta, CONVERT(VARCHAR,TANULCHEQEMITIDO.cfechanulado,103) AS Fecha,RTRIM(LTRIM(TANULCHEQEMITIDO.cbanco)) AS cbanco, CASE WHEN ISNULL(TANULCHEQEMITIDO.cidcomprobanul,0)=0 THEN 'POR APROBAR' WHEN ISNULL(TCOMPROBANC.cstatus,0)=0 THEN 'POR IMPRIMIR' ELSE 'ANULADO' END AS Estatus FROM TANULCHEQEMITIDO INNER JOIN TBANCO ON TANULCHEQEMITIDO.ccompany = TBANCO.ccompany AND TANULCHEQEMITIDO.cbanco = TBANCO.cbanco LEFT JOIN TCOMPROBANC ON TANULCHEQEMITIDO.ccompany=TCOMPROBANC.ccompany AND TANULCHEQEMITIDO.cidcomprobanul=TCOMPROBANC.cidcomprob WHERE (TANULCHEQEMITIDO.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TANULCHEQEMITIDO.ccompany = '" + Frm_Padre._Str_Comp + "')";
            if (_Int_Notificador == 1)
                _Str_Cadena += " AND ISNULL(TANULCHEQEMITIDO.cidcomprobanul,0)='0'";
            else if (_Int_Notificador == 2)
                _Str_Cadena += " AND ISNULL(TCOMPROBANC.cstatus,0)='0'";
            else
                _Str_Cadena += "AND CONVERT(DATETIME,CONVERT(VARCHAR,cfechanulado,103)) BETWEEN '" + _Ctrl_ConsultaMes1._Str_FechaInicio + "' AND '" + _Ctrl_ConsultaMes1._Str_FechaFinal + "'";
            _Str_Cadena += " ORDER BY cnumcheque";
            Cursor = Cursors.WaitCursor;
            _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid.Columns["cbanco"].Visible = false;
            Cursor = Cursors.Default;
        }
        private void _Mtd_Ini()
        {
            _Str_OrdenPago = "";
            _Str_Comprobante = "";
            _Str_ID_EmisionCheq = "";
            _Bt_Anular.Enabled = false;
            _Bt_Rechazar.Enabled = false;
            _Bt_Buscar.Enabled = false;
            _Txt_Motivo.Enabled = false;
            _Txt_Cheque.Text = "";
            _Txt_Banco.Tag = "";
            _Txt_Banco.Text = "";
            _Txt_Cuenta.Text = "";
            _Txt_Concepto.Text = "";
            _Txt_Beneficiario.Text = "";
            _Txt_Monto.Text = "";
            _Txt_Motivo.Text = "";
            _Bt_Solicitar.Visible = true;
            _Bt_Anular.Visible = false;
            _Bt_Rechazar.Visible = false;
            _Bt_Imprimir.Visible = false;
        }
        public void _Mtd_Nuevo()
        {
            _Dg_Comprobante.Rows.Clear();
            _Pnl_Clave.Visible = false;
            _Mtd_Ini();
            _Bt_Buscar.Enabled = true;
            _Tb_Tab.SelectedIndex = 1;
            _Bt_Buscar.Focus();
        }
        private string _Mtd_ObtenerIDChequera(string _P_Str_Banco, string _P_Str_NumCuenta, string _P_Str_NumCheque)
        {
            string _Str_Cadena = "SELECT cidchequera FROM TCHEQUERAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _P_Str_Banco + "' AND cnumcuentad='" + _P_Str_NumCuenta + "' AND '" + _P_Str_NumCheque + "' BETWEEN cnumcheqdesde AND cnumcheqhasta";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "";
        }
        private void _Mtd_InsertAuxiliarCont(string _P_Str_Comprob, string _P_Str_ComprobAnul)
        {
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _P_Str_ComprobAnul);
            string _Str_Cadena = "INSERT INTO TCOMPROBANDD (ccompany,cidcomprob,ccount,cidtipoauxiliar,cidauxiliarcont,cdescrip,ctdocument,cnumdocu,cfechaemision,cfechavencimiento,cdebe,chaber,cmontacco,cyearacco,cstatus,cclasificauxiliar) SELECT TCOMPROBANDD.ccompany,'" + _P_Str_ComprobAnul + "',CASE WHEN TCOUNTINAC.ccountactiva IS NULL THEN TCOMPROBANDD.ccount ELSE TCOUNTINAC.ccountactiva END,CASE WHEN TCOUNTINAC.ccountactiva IS NULL THEN TCOMPROBANDD.cidtipoauxiliar ELSE TTIPAUXILIARCONTD.cidtipoauxiliar END,cidauxiliarcont,CASE WHEN TCOUNTINAC.ccountactiva IS NULL THEN LTRIM(RTRIM(TCOMPROBANDD.cdescrip)) ELSE REPLACE(TCOMPROBANDD.cdescrip COLLATE DATABASE_DEFAULT, LTRIM(RTRIM(TCOUNT.cname)),LTRIM(RTRIM(TCOUNT_1.cname))) END + ' ANULACIÓN',TCOMPROBANDD.ctdocument,cnumdocu,cfechaemision,cfechavencimiento,chaber,cdebe,'" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Month + "','" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Year + "','0',CASE WHEN TCOUNTINAC.ccountactiva IS NULL THEN TCOMPROBANDD.cclasificauxiliar ELSE TCOUNT_1.cclasificauxiliar END " +
                "FROM TCOUNT AS TCOUNT_1 INNER JOIN " +
                "TCOUNTINAC ON TCOUNT_1.ccompany = TCOUNTINAC.ccompany AND TCOUNT_1.ccount = TCOUNTINAC.ccountactiva LEFT OUTER JOIN " +
                "TTIPAUXILIARCONTD ON TCOUNT_1.ccount = TTIPAUXILIARCONTD.ctcount RIGHT OUTER JOIN " +
                "TCOMPROBANDD INNER JOIN " +
                "TCOUNT ON TCOMPROBANDD.ccompany = TCOUNT.ccompany AND TCOMPROBANDD.ccount = TCOUNT.ccount ON " +
                "(TTIPAUXILIARCONTD.ctdocument = TCOMPROBANDD.ctdocument OR TTIPAUXILIARCONTD.ctdocument IS NULL) AND TCOUNTINAC.ccompany = TCOMPROBANDD.ccompany AND " +
                "TCOUNTINAC.ccountinactiva = TCOMPROBANDD.ccount WHERE TCOMPROBANDD.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBANDD.cidcomprob='" + _P_Str_Comprob + "' AND (TCOUNT_1.cauxiliary='1' OR TCOUNTINAC.ccountactiva IS NULL)";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private string _Mtd_CrearComprobanteAnulacion(string _P_Str_Comprobante)
        {
            int _Int_Comprobante =_Cls_VariosMetodos._Mtd_Consecutivo_TCOMPROBANC();
            string _Str_Cadena = "INSERT INTO TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) SELECT ccompany,'" + _Int_Comprobante + "',ctypcomp,cname,'" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Year + "','" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Month + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',ctotdebe,ctothaber,cbalance,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','0','0' FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "INSERT INTO TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,ctothaber,cdateadd,cuseradd,cdescrip) SELECT TCOMPROBAND.ccompany,'" + _Int_Comprobante + "',corder,CASE WHEN TCOUNTINAC.ccountactiva IS NULL THEN TCOMPROBAND.ccount ELSE TCOUNTINAC.ccountactiva END,ctdocument,cnumdocu,cdatedocu,ctothaber,ctotdebe,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',CASE WHEN TCOUNTINAC.ccountactiva IS NULL THEN LTRIM(RTRIM(TCOMPROBAND.cdescrip)) ELSE REPLACE(TCOMPROBAND.cdescrip COLLATE DATABASE_DEFAULT, LTRIM(RTRIM(TCOUNT.cname)),LTRIM(RTRIM(TCOUNT_1.cname))) END + ' ANULACIÓN' " +
                "FROM TCOUNT AS TCOUNT_1 INNER JOIN " +
                "TCOUNTINAC ON TCOUNT_1.ccompany = TCOUNTINAC.ccompany AND TCOUNT_1.ccount = TCOUNTINAC.ccountactiva RIGHT OUTER JOIN " +
                "TCOMPROBAND INNER JOIN " +
                "TCOUNT ON TCOMPROBAND.ccompany = TCOUNT.ccompany AND TCOMPROBAND.ccount = TCOUNT.ccount ON  " +
                "TCOUNTINAC.ccompany = TCOMPROBAND.ccompany AND TCOUNTINAC.ccountinactiva = TCOMPROBAND.ccount WHERE TCOMPROBAND.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBAND.cidcomprob='" + _P_Str_Comprobante + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            return _Int_Comprobante.ToString();
        }
        private bool _Mtd_EsCheque()
        {
            string _Str_Cadena = "SELECT cidemisioncheq FROM TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidemisioncheq='" + _Str_ID_EmisionCheq + "' AND cfpago='CHEQ'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }
        private void _Mtd_ConciliarAuto(string P_Str_Comprobante, string P_Str_cnumdocu)
        {
            string _Str_Cadena = "SELECT ccount FROM VST_CUENTBANCCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cnumcuenta='" + _Txt_Cuenta.Text + "' AND cbanco='" + _Txt_Banco.Tag + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Cadena = "SELECT cregdate FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + P_Str_Comprobante + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    var _Dt_cregdate = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cregdate"]);
                    _Cls_RutinasConciliacion._Mtd_AgregarRegistroParaMarcajeChequesAnulados(Frm_Padre._Str_Comp, _Txt_Banco.Tag.ToString(), _Txt_Cuenta.Text, P_Str_Comprobante, _Dt_cregdate, P_Str_cnumdocu);
                }
            }
        }

        private bool _Mtd_ChequeConciliado(string P_Str_Comprobante)
        {
            double _Dbl_monto = 0;
            double.TryParse(_Txt_Monto.Text, out _Dbl_monto);

            if (_Dbl_monto > 0)
            {
                //Obtenemos el corder del cheque
                var _Str_Monto = CLASES._Cls_Varios_Metodos._Mtd_MontosSQL_Float(_Dbl_monto);
                var _Str_Cadena = "SELECT corder " +
                                     "FROM TCOMPROBAND " +
                                     "WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + P_Str_Comprobante + "' AND cdescrip LIKE 'CHEQUE%' AND (ctotdebe='" + _Str_Monto + "' OR ctothaber='" + _Str_Monto + "')";
                var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                //Si hay un corder
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    var _Str_corder = _Ds.Tables[0].Rows[0][0].ToString();
                    _Str_Cadena = "SELECT ccount FROM VST_CUENTBANCCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cnumcuenta='" + _Txt_Cuenta.Text + "' AND cbanco='" + _Txt_Banco.Tag + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        //Buscamos en la tabla de conciliaciones manuales, aprobadas (esto es solo válido para conciliaciones finalizadas ó aun en proceso)
                        //_Str_Cadena = "SELECT TCONCILIACIOND_MANUALV2.cidconciliacion " +
                        //              "FROM TCONCILIACIOND_MANUALV2 INNER JOIN TCONCILIACION ON TCONCILIACIOND_MANUALV2.cidconciliacion = TCONCILIACION.cidconciliacion AND TCONCILIACIOND_MANUALV2.ccompany = TCONCILIACION.ccompany  " +
                        //              "WHERE (TCONCILIACION.cdelete = 0) AND (TCONCILIACIOND_MANUALV2.ccompany='" + Frm_Padre._Str_Comp + "') AND (TCONCILIACIOND_MANUALV2.cidcomprob='" + P_Str_Comprobante + "') AND (TCONCILIACIOND_MANUALV2.corder='" + _Str_corder + "') AND (TCONCILIACION.cnumcuenta='" + _Txt_Cuenta.Text + "') AND (TCONCILIACION.cbanco='" + _Txt_Banco.Tag + "') ";
                        _Str_Cadena = "SELECT TCONCILIACIOND_MANUALV2.cidconciliacion FROM TCONCILIACIOND_MANUALV2 WHERE (TCONCILIACIOND_MANUALV2.cdelete = 0) AND (TCONCILIACIOND_MANUALV2.ccompany='" + Frm_Padre._Str_Comp + "') AND (TCONCILIACIOND_MANUALV2.cidcomprob='" + P_Str_Comprobante + "') AND (TCONCILIACIOND_MANUALV2.corder='" + _Str_corder + "')";
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                            return true;

                        //Buscamos en la tabla de comprobantes (esto es solo válido para conciliaciones terminadas)
                        _Str_Cadena = "SELECT cconciliado FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + P_Str_Comprobante + "' AND corder='" + _Str_corder + "' AND ccount='" + _Ds.Tables[0].Rows[0]["ccount"].ToString().Trim() + "' AND cconciliado>0";
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                            return true;
                    }
                }
            }
            return false;
        }

        void _Mtd_SolicitarAnulacion()
        {
            var _Str_FPago = "TRANSF";
            if (_Mtd_EsCheque())
            {
                _Str_FPago = "CHEQ";
            }
            string _Str_Cadena = "INSERT INTO TANULCHEQEMITIDO (cgroupcomp,ccompany,cbanco,cnumcuentad,cnumcheque,cidordpago,cnotadeanul,cmonto,cfechanulado,cuseranulado,cfpago,cidcomprobanul) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + Convert.ToString(_Txt_Banco.Tag).Trim() + "','" + _Txt_Cuenta.Text.Trim() + "','" + _Txt_Cheque.Text.Trim() + "','" + _Str_OrdenPago + "','" + _Txt_Motivo.Text.Trim().ToUpper() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Monto.Text)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + Frm_Padre._Str_Use + "','" + _Str_FPago + "','0')";
            Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
        }

        void _Mtd_RechazarAnulacion()
        {
            string _Str_Cadena = "DELETE FROM TANULCHEQEMITIDO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdenPago + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
        }

        private string _Mtd_Anular()
        {
            string _Str_Cadena = "UPDATE TEMICHEQTRANSM SET canulado=1 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidemisioncheq='" + _Str_ID_EmisionCheq + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "UPDATE TPAGOSCXPM SET canulado=1,cidemisioncheq='" + _Str_ID_EmisionCheq + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdenPago + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            string _Str_TipoDocNd = _Cls_VariosMetodos._Mtd_TipoDocumentFACT_CXP("ctipodocnd");
            _Str_Cadena = "SELECT cproveedor,ctipodocument,cnumdocu,ISNULL(cmontocancelar,0) AS cmontocancelar,ISNULL(cncppp,0) as cncppp FROM TPAGOSCXPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdenPago + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_Cadena = "UPDATE TFACTPPAGARM SET cordenpaghecha='0',csaldo=csaldo+" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL_Float(Convert.ToDouble(_Row["cmontocancelar"].ToString().Trim())) + ",cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Row["cproveedor"].ToString().Trim() + "' AND ctipodocument='" + _Row["ctipodocument"].ToString().Trim() + "' AND cnumdocu='" + _Row["cnumdocu"].ToString().Trim() + "' AND ctotal>0";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "UPDATE TMOVCXPM SET csaldo=csaldo+" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL_Float(Convert.ToDouble(_Row["cmontocancelar"].ToString().Trim())) + ",cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Row["cproveedor"].ToString().Trim() + "' AND ctipodocument='" + _Row["ctipodocument"].ToString().Trim() + "' AND cnumdocu='" + _Row["cnumdocu"].ToString().Trim() + "' AND ctotal>0";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "UPDATE TFACTPPAGARM SET cordenpaghecha='0',csaldo=(csaldo+" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL_Float(Convert.ToDouble(_Row["cmontocancelar"].ToString().Trim())) + ")*-1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Row["cproveedor"].ToString().Trim() + "' AND ctipodocument='" + _Row["ctipodocument"].ToString().Trim() + "' AND cnumdocu='" + _Row["cnumdocu"].ToString().Trim() + "' AND ctotal<0";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "UPDATE TMOVCXPM SET csaldo=(csaldo+" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL_Float(Convert.ToDouble(_Row["cmontocancelar"].ToString().Trim())) + ")*-1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Row["cproveedor"].ToString().Trim() + "' AND ctipodocument='" + _Row["ctipodocument"].ToString().Trim() + "' AND cnumdocu='" + _Row["cnumdocu"].ToString().Trim() + "' AND ctotal<0";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                //Si hay AVISOS de Cobro CXP les devuelvo el saldo
                if (_Row["ctipodocument"].ToString() == "AVISOCXP")
                {
                    _Str_Cadena = "update TAVISOPAGM set cestado=0,csaldo=cmonto,cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' where ccompany='" + Frm_Padre._Str_Comp + "' and ccodavisopag='" + _Row["cnumdocu"].ToString() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                //-------------------------------------------------------------
                if (Convert.ToInt32(_Row["cncppp"].ToString()) > 0)
                {
                    string _Str_IdNd = _Row["cncppp"].ToString();
                    _Str_Cadena = "SELECT cidcomprob,cproveedor FROM TNOTADEBITOCP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp='" + _Str_IdNd + "'";
                    DataSet _Ds_Nd = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds_Nd.Tables[0].Rows.Count > 0)
                    {
                        string _Str_ComprobanteNd = _Ds_Nd.Tables[0].Rows[0]["cidcomprob"].ToString();
                        string _Str_ProveedorNd = _Ds_Nd.Tables[0].Rows[0]["cproveedor"].ToString();
                        string _Str_Id_ComprobAnulNd = _Mtd_CrearComprobanteAnulacion(_Str_ComprobanteNd);
                        _Mtd_InsertAuxiliarCont(_Str_ComprobanteNd, _Str_Id_ComprobAnulNd);
                        _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1',cname=RTRIM(cname)+ ' ANULACIÓN',cdateupd=getdate() WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Id_ComprobAnulNd + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "UPDATE TNOTADEBITOCP SET cidcomprobanul=" + _Str_Id_ComprobAnulNd + ",canulado='1',cfechaanul='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cdateupd=getdate(),cuserupd='" + Frm_Padre._Str_Use + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Str_IdNd + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "UPDATE TFACTPPAGARM SET canulado='1',cactivo='0',cordenpaghecha='0',cdateupd=getdate(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_ProveedorNd + "' AND ctipodocument='" + _Str_TipoDocNd + "' AND cnumdocu='" + _Str_IdNd + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "UPDATE TMOVCXPM SET canulado='1',cactivo='0',cdateupd=getdate(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_ProveedorNd + "' AND ctipodocument='" + _Str_TipoDocNd + "' AND cnumdocu='" + _Str_IdNd + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                }
                //-------------------------------------------------------------
            }
            _Mtd_DesSaldarDocumentosCxC(_Str_OrdenPago);
            //-------------------------------------------------------------
            var _Str_FPago = "TRANSF";
            if (_Mtd_EsCheque())
            {
                _Str_FPago = "CHEQ";
                string _Str_ID_Chequera = _Mtd_ObtenerIDChequera(Convert.ToString(_Txt_Banco.Tag).Trim(), _Txt_Cuenta.Text, _Txt_Cheque.Text.Trim());
                if (_Str_ID_Chequera.Trim().Length > 0)
                {
                    _Str_Cadena = "UPDATE TCHEQUERAD SET canulado='1',cfechanulado=GETDATE(),cuseranulado='" + Frm_Padre._Str_Use + "',cobservacionanul='DESDE ANULACIÓN DE CHEQUES EMITIDOS' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidchequera='" + _Str_ID_Chequera + "' AND cnumcheque='" + _Txt_Cheque.Text.Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
            }
            //-------------------------------------------------------------
            var _Str_cnumdocu = _Txt_Cheque.Text;
            _Mtd_ConciliarAuto(_Str_Comprobante, _Str_cnumdocu);
            string _Str_Id_ComprobAnul = _Mtd_CrearComprobanteAnulacion(_Str_Comprobante);
            _Mtd_ConciliarAuto(_Str_Id_ComprobAnul, _Str_cnumdocu);
            _Mtd_InsertAuxiliarCont(_Str_Comprobante, _Str_Id_ComprobAnul);
            _Str_Cadena = "UPDATE TCOMPROBANC SET cname=RTRIM(cname)+ ' ANULACIÓN' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Id_ComprobAnul + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            //------------------
            _Str_Cadena = "UPDATE TANULCHEQEMITIDO SET cidcomprobanul='" + _Str_Id_ComprobAnul + "',cfechanulado='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cuseranulado='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdenPago + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            //------------------
            _Str_Cadena = "SELECT cidordpago FROM TREPOSICIONESM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdenPago + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Cadena = "UPDATE TREPOSICIONESM SET cidordpago='0',cbanco='',cfpago='',cnumcuenta='',cordenpaghecha='0',cestatusfirma='0',cestatusreposicion='0',cyearacco='" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year + "',cmontacco='" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdenPago + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            //------------------
            return _Str_Id_ComprobAnul;
        }
        /// <summary>
        /// Des-Salda los documentos CxC de intercompañía.
        /// </summary>
        /// <param name="_P_Str_OrdPago">Id de la orden de pago</param>
        private void _Mtd_DesSaldarDocumentosCxC(string _P_Str_OrdPago)
        {
            string _Str_Cadena = "select ctipodocument,cnumdocu from TPAGOSCXCD where ccompany='" + Frm_Padre._Str_Comp + "' and cidordpago='" + _P_Str_OrdPago + "' and isnull(cdelete,0)=0";
            DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _DRow in _Ds_DataSet.Tables[0].Rows)
            {
                //N/C, N/D, FACT -> CxC
                if ((_DRow["ctipodocument"].ToString() == "N/C") || (_DRow["ctipodocument"].ToString() == "N/D") || (_DRow["ctipodocument"].ToString() == "FACT"))
                {
                    //Solo N/C CxC
                    if (_DRow["ctipodocument"].ToString() == "N/C")
                    {
                        string _Str_Sql2 = "update TNOTACREDICC set cdescontada=0,cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cidnotcredicc='" + _DRow["cnumdocu"].ToString() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql2);
                    }
                    string _Str_Sql = "update TSALDOCLIENTED set csaldofactura=cmontofactci,cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' where ccompany='" + Frm_Padre._Str_Comp + "' and ctipodocument='" + _DRow["ctipodocument"].ToString() + "' and cnumdocu='" + _DRow["cnumdocu"].ToString() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
                //Solo AVISO CxC (Aviso de Cobro CXC)
                if (_DRow["ctipodocument"].ToString() == "AVISOCXC")
                {
                    string _Str_Sql = "update TAVISOCOBM set cestado=0,cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' where ccompany='" + Frm_Padre._Str_Comp + "' and ccodavisocob='" + _DRow["cnumdocu"].ToString() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
            }
        }

        private bool _Mtd_ImprimirComprobante(string _P_Str_Comprobante)
        {
            try
            {
                PrintDialog _Print = new PrintDialog();
            _Print:
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rInfcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _P_Str_Comprobante + "'", _Print, true);
                    Cursor = Cursors.Default;
                    if (MessageBox.Show("¿La impresión se ha realizado correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        return true;
                    }
                    else
                    {
                        _Frm.Close();
                        _Frm.Dispose();
                        goto _Print;
                    }
                }
            }
            catch (Exception _Ex) { Cursor = Cursors.Default; MessageBox.Show("Error al intentar imprimir. " + _Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return false;
        }

        private void Frm_AnulaChequeEmitido_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();
            _Ctrl_ConsultaMes1._Mtd_Year();
            _Mtd_Color_Estandar(this);
            _Mtd_Sorted(_Dg_Grid);
            _Mtd_Sorted(_Dg_Comprobante);
            if (_Ctrl_ConsultaMes1._Cmb_Year.Items.Count > 0)
            {
                _Ctrl_ConsultaMes1._Cmb_Year.SelectedIndex = 1;
                _Ctrl_ConsultaMes1._Cmb_Month.SelectedIndex = 1;
                if (_Ctrl_ConsultaMes1._Bol_Listo)
                {
                    _Mtd_Actualizar();
                }
            }
        }

        private void Frm_AnulaChequeEmitido_Activated(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ANUL_CHEQEMIT_SOL"))
            {
                CONTROLES._Ctrl_Buscar._Bl_Especial = true;
                CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = true;
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
                CONTROLES._Ctrl_Buscar._frm_Formulario = this;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            else
            {
                CONTROLES._Ctrl_Buscar._Bl_Especial = false;
                CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
            }
        }

        bool _Mtd_AnulacionCargada(string _P_Str_Id_EmisionCheq)
        {
            string _Str_Cadena = "select TANULCHEQEMITIDO.cidordpago from TANULCHEQEMITIDO inner join VST_CHEQUES_EMITIDOS on TANULCHEQEMITIDO.cgroupcomp=VST_CHEQUES_EMITIDOS.cgroupcomp and TANULCHEQEMITIDO.ccompany=VST_CHEQUES_EMITIDOS.ccompany and TANULCHEQEMITIDO.cidordpago=VST_CHEQUES_EMITIDOS.cidordpago WHERE TANULCHEQEMITIDO.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TANULCHEQEMITIDO.ccompany='" + Frm_Padre._Str_Comp + "' and VST_CHEQUES_EMITIDOS.cidemisioncheq='" + _P_Str_Id_EmisionCheq + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            Frm_ChequesEmit _Frm = new Frm_ChequesEmit();
            _Frm.ShowDialog(this);
            if (Convert.ToString(_Frm.Tag).Trim().Length > 0)
            {
                if (_Mtd_AnulacionCargada(Convert.ToString(_Frm.Tag).Trim()))
                {
                    MessageBox.Show("Ya se ha solicitado la anulación del cheque seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                _Mtd_CargarInformacion(Convert.ToString(_Frm.Tag).Trim());
                _Txt_Motivo.Enabled = true;
                _Txt_Motivo.Focus();
            }
        }

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            if (_Ctrl_ConsultaMes1._Bol_Listo)
            {
                _Mtd_Actualizar();
            }
            else
            { MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                _Mtd_Ini();
                if (_Ctrl_ConsultaMes1._Cmb_Year.Items.Count > 0)
                {
                    _Ctrl_ConsultaMes1._Cmb_Year.SelectedIndex = 1;
                    _Ctrl_ConsultaMes1._Cmb_Month.SelectedIndex = 1;
                    if (_Ctrl_ConsultaMes1._Bol_Listo)
                    {
                        _Mtd_Actualizar();
                    }
                }
            }
            else if (!_Bt_Buscar.Enabled & _Txt_Cheque.Text.Trim().Length == 0 & e.TabPageIndex == 1)
            { e.Cancel = true; }
        }

        private void Frm_AnulaChequeEmitido_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Bt_Anular_Click(object sender, EventArgs e)
        {
            if (_Txt_Cheque.Text.Trim().Length > 0 && Convert.ToString(_Txt_Banco.Tag).Trim().Length > 0 && _Txt_Cuenta.Text.Trim().Length > 0 && _Str_Comprobante.Trim().Length > 0 && _Str_OrdenPago.Trim().Length > 0 && _Str_ID_EmisionCheq.Trim().Length > 0)
            {
                if (_Mtd_ChequeConciliado(_Str_Comprobante))
                {
                    MessageBox.Show("No se puede realizar la operación, el registro del cheque o transferencia ha sido conciliado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //-------------------
                if (_Mtd_CuentasInactivas(_Str_OrdenPago, _Str_Comprobante))
                    return;
                //-------------------
                if (MessageBox.Show("Esta seguro de anular la emisión de cheque", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { _Int_Sw = 3; _Pnl_Clave.Visible = true; }
            }
            else
            {
                MessageBox.Show("No se puede realizar la operación porque no se obtuvieron algunos datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool _Mtd_CuentasInactivas(string _P_Str_OrdenPago,string _P_Str_ComprobInicial)
        {
            var _Str_ComprobanteNd = "";
            string _Str_Cadena = "SELECT TNOTADEBITOCP.cidcomprob " +
                    "FROM TPAGOSCXPD INNER JOIN " +
                    "TNOTADEBITOCP ON TPAGOSCXPD.ccompany = TNOTADEBITOCP.ccompany AND " +
                    "TPAGOSCXPD.cgroupcomp = TNOTADEBITOCP.cgroupcomp AND TPAGOSCXPD.cncppp = TNOTADEBITOCP.cidnotadebitocxp " +
                    "WHERE TPAGOSCXPD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TPAGOSCXPD.ccompany='" + Frm_Padre._Str_Comp + "' AND TPAGOSCXPD.cidordpago='" + _P_Str_OrdenPago + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
                _Str_ComprobanteNd = _Ds.Tables[0].Rows[0][0].ToString();
            if (_Cls_VariosMetodos._Mtd_CuentasInactivas(_P_Str_ComprobInicial) |
               (!string.IsNullOrEmpty(_Str_ComprobanteNd) && _Cls_VariosMetodos._Mtd_CuentasInactivas(_Str_ComprobanteNd)))
            {
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                MessageBox.Show("El comprobante inicial tiene cuentas inactivas.\nDebe reemplazar las cuentas inactivas desde el notificador 'CUENTAS CONTABLES INACTIVAS POR REEMPLAZAR' para realizar la anulación.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }

        private void _Txt_Motivo_TextChanged(object sender, EventArgs e)
        {
            _Bt_Solicitar.Enabled = _Bt_Solicitar.Visible && _Txt_Motivo.Text.Trim().Length > 0;
        }

        private void _Txt_Motivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)13))
            {
                if (_Bt_Anular.Visible && _Bt_Anular.Enabled)
                { _Bt_Anular.Focus(); }
                else if(_Bt_Solicitar.Visible && _Bt_Solicitar.Enabled)
                { _Bt_Solicitar.Focus(); }
            }
        }

        string _Str_Comprobante_Anul_Imp;

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                if (e.RowIndex != -1)
                {
                    string _Str_Cadena = "SELECT TANULCHEQEMITIDO.cnumcheque, TBANCO.cname, TANULCHEQEMITIDO.cnumcuentad, TANULCHEQEMITIDO.cnotadeanul, dbo.Fnc_Formatear(TANULCHEQEMITIDO.cmonto) AS cmonto, VST_CHEQUES_EMITIDOS.cconcepto, VST_CHEQUES_EMITIDOS.cbeneficiario, ISNULL(TANULCHEQEMITIDO.cidcomprobanul,0) AS cidcomprobanul, VST_CHEQUES_EMITIDOS.cidcomprob, VST_CHEQUES_EMITIDOS.cidordpago, TANULCHEQEMITIDO.cbanco, ISNULL(TCOMPROBANC.cstatus,0) AS cstatus, VST_CHEQUES_EMITIDOS.cidemisioncheq FROM TANULCHEQEMITIDO INNER JOIN TBANCO ON TANULCHEQEMITIDO.ccompany = TBANCO.ccompany AND TANULCHEQEMITIDO.cbanco = TBANCO.cbanco INNER JOIN VST_CHEQUES_EMITIDOS ON TANULCHEQEMITIDO.cgroupcomp = VST_CHEQUES_EMITIDOS.cgroupcomp AND TANULCHEQEMITIDO.ccompany = VST_CHEQUES_EMITIDOS.ccompany AND TANULCHEQEMITIDO.cidordpago = VST_CHEQUES_EMITIDOS.cidordpago LEFT JOIN TCOMPROBANC ON TANULCHEQEMITIDO.ccompany=TCOMPROBANC.ccompany AND TANULCHEQEMITIDO.cidcomprobanul=TCOMPROBANC.cidcomprob WHERE (TANULCHEQEMITIDO.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TANULCHEQEMITIDO.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TANULCHEQEMITIDO.cbanco = '" + _Dg_Grid.Rows[e.RowIndex].Cells["cbanco"].Value.ToString() + "') AND (TANULCHEQEMITIDO.cnumcuentad = '" + _Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value.ToString() + "') AND (TANULCHEQEMITIDO.cnumcheque = '" + _Dg_Grid.Rows[e.RowIndex].Cells["Cheque/Transf"].Value.ToString() + "') AND (TANULCHEQEMITIDO.cfpago = '" + _Dg_Grid.Rows[e.RowIndex].Cells["Tipo"].Value.ToString() + "')";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Mtd_Ini();
                        _Txt_Cheque.Text = _Ds.Tables[0].Rows[0]["cnumcheque"].ToString().Trim();
                        _Txt_Banco.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                        _Txt_Cuenta.Text = _Ds.Tables[0].Rows[0]["cnumcuentad"].ToString().Trim();
                        _Txt_Beneficiario.Text = _Ds.Tables[0].Rows[0]["cbeneficiario"].ToString().Trim();
                        _Txt_Concepto.Text = _Ds.Tables[0].Rows[0]["cconcepto"].ToString().Trim();
                        _Txt_Monto.Text = _Ds.Tables[0].Rows[0]["cmonto"].ToString().Trim();
                        _Txt_Motivo.Text = _Ds.Tables[0].Rows[0]["cnotadeanul"].ToString().Trim();
                        if (_Ds.Tables[0].Rows[0]["cidcomprobanul"].ToString() == "0")
                        {
                            if (_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ANUL_CHEQEMIT"))
                            {
                                //------------
                                _Txt_Banco.Tag = _Ds.Tables[0].Rows[0]["cbanco"].ToString().Trim();
                                _Str_OrdenPago = _Ds.Tables[0].Rows[0]["cidordpago"].ToString().Trim();
                                _Str_ID_EmisionCheq = _Ds.Tables[0].Rows[0]["cidemisioncheq"].ToString().Trim();
                                _Str_Comprobante = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim();
                                //------------
                                _Bt_Solicitar.Visible = false;
                                _Bt_Anular.Visible = true;
                                _Bt_Anular.Enabled = true;
                                _Bt_Rechazar.Visible = true;
                                _Bt_Rechazar.Enabled = true;
                            }
                            _Mtd_VisualizarComprobanteAnul(_Ds.Tables[0].Rows[0]["cidcomprob"].ToString().Trim());
                        }
                        else
                        {
                            //------------
                            _Str_Comprobante_Anul_Imp = _Ds.Tables[0].Rows[0]["cidcomprobanul"].ToString().Trim();
                            //------------
                            _Mtd_VisualizarComprobanteExis(_Ds.Tables[0].Rows[0]["cidcomprobanul"].ToString().Trim());
                            if (_Ds.Tables[0].Rows[0]["cstatus"].ToString() == "0")
                            {
                                _Bt_Solicitar.Visible = false;
                                _Bt_Imprimir.Visible = true;
                            }
                        }
                        _Tb_Tab.SelectedIndex = 1;
                    }
                }
            }
        }

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                _Pnl_Clave.Visible = false;
                if (_Int_Sw == 1)
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_SolicitarAnulacion();
                    Cursor = Cursors.Default;
                }
                else if (_Int_Sw == 2)
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_RechazarAnulacion();
                    Cursor = Cursors.Default;
                }
                else
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_Anular();
                    Cursor = Cursors.Default;
                }
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Tb_Tab.SelectedIndex = 0;
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Tb_Tab.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Tb_Tab.Enabled = true; }
        }
        int _Int_Sw = 0;
        private void _Bt_Solicitar_Click(object sender, EventArgs e)
        {
            if (_Mtd_ChequeConciliado(_Str_Comprobante))
            {
                MessageBox.Show("No se puede realizar la operación, el registro del cheque o transferencia ha sido conciliado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //-------------------
            _Int_Sw = 1;
            _Pnl_Clave.Visible = true;
        }

        private void _Bt_Imprimir_Click(object sender, EventArgs e)
        {
            if (_Mtd_ImprimirComprobante(_Str_Comprobante_Anul_Imp))
            {
                Cursor = Cursors.WaitCursor;
                string _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1',clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_Comprobante_Anul_Imp + "' AND ISNULL(cstatus,0)='0'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                Cursor = Cursors.Default;
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                MessageBox.Show("Se ha actualizado el comprobante.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Tb_Tab.SelectedIndex = 0;
            }
        }

        private void _Bt_Rechazar_Click(object sender, EventArgs e)
        {
            _Int_Sw = 2;
            _Pnl_Clave.Visible = true;
        }
    }
}
