using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
namespace T3
{
    public partial class Frm_ConsultaComprobante : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        string _Str_SentenciaReport = "";
        public Frm_ConsultaComprobante()
        {
            InitializeComponent();
            _Mtd_CargarTipoReporte();
            _Mtd_CargarTipoComprob();
            _Mtd_CargarMeses(Convert.ToInt32(_Cmb_Reporte.SelectedValue));
        }
        public Frm_ConsultaComprobante(bool _P_Bol_Tabs)
        {
            InitializeComponent();
            _Mtd_CargarTipoReporte();
            _Mtd_CargarTipoComprob();
            _Cmb_Reporte.SelectedValue = "3";
            _Mtd_CargarMeses(Convert.ToInt32(_Cmb_Reporte.SelectedValue));
            Cursor = Cursors.WaitCursor;
            this._Rpv_Main.ReportSource = null;
            _Str_SentenciaReport = _Mtd_Buscar();
            Cursor = Cursors.Default;
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
        private string[] _Mtd_ExtraerMesAno(string _P_Str_Items)
        {
            int _Int_i = _P_Str_Items.Trim().IndexOf("-");
            return new string[] { _P_Str_Items.Substring(0, _Int_i).Trim(), _P_Str_Items.Substring(_Int_i + 1).Trim() };
        }
        private void _Mtd_CargarTipoComprob()
        {
            string _Str_Cadena = "Select ctypcompro,ctypcompro COLLATE DATABASE_DEFAULT+'-'+cname COLLATE DATABASE_DEFAULT from TTCOMPROBAN";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_TipComp, _Str_Cadena);
        }
        private void _Mtd_CargarMeses(int _P_Int_TipoReporte)
        {
            string _Str_Cadena = "";
            //_Str_Cadena = "SELECT CONVERT(VARCHAR,cmontacco)+'-'+CONVERT(VARCHAR,cyearacco),CONVERT(VARCHAR,cmontacco)+'-'+CONVERT(VARCHAR,cyearacco) FROM TMESCONTABLE WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            _Str_Cadena = "SELECT CONVERT(VARCHAR,cmontacco)+'-'+CONVERT(VARCHAR,cyearacco),REPLACE(STR(CONVERT(VARCHAR,cmontacco), 2), SPACE(1), '0')+'-'+CONVERT(VARCHAR,cyearacco) FROM TMESCONTABLE WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            if (_P_Int_TipoReporte == 1)
            { _Str_Cadena += " AND ccerrado='1'"; }
            else if (_P_Int_TipoReporte > 1)
            { _Str_Cadena += " AND ccerrado='0'"; }
            //Ordenamiento
            _Str_Cadena += " ORDER BY cyearacco DESC,cmontacco DESC ";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Mes, _Str_Cadena);
        }
        private void _Mtd_CargarTipoReporte()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_Reporte.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Todos", "0"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Comprobantes cerrados", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Comprobantes actualizados", "2"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Comprobantes por actualizar", "3"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Anulados por el sistema", "4"));
            //_myArrayList.Add(new T3.Clases._Cls_ArrayList("Comprobantes descuadrados", "5"));
            _Cmb_Reporte.DataSource = _myArrayList;
            _Cmb_Reporte.DisplayMember = "Display";
            _Cmb_Reporte.ValueMember = "Value";
            _Cmb_Reporte.SelectedValue = "0";
            _Cmb_Reporte.DataSource = _myArrayList;
        }
        private void _Mtd_Ini()
        {
            _Mtd_CargarTipoReporte();
            _Mtd_CargarTipoComprob();
            _Mtd_CargarMeses(Convert.ToInt32(_Cmb_Reporte.SelectedValue));
            this._Rpv_Main.ReportSource = null;
            _Dg_Grid.DataSource = null;
            _Txt_Descripcion.Text = "";
            _Txt_Comprobante.Text = "";
            _Chk_DesHas.Checked = false;
        }
        private void _Mtd_Ini2()
        {
            if (_Cmb_TipComp.DataSource != null) { _Cmb_TipComp.SelectedIndex = 0; }
            if (_Cmb_Mes.DataSource != null) { _Cmb_Mes.SelectedIndex = 0; }
            this._Rpv_Main.ReportSource = null;
            _Dg_Grid.DataSource = null;
            _Txt_Descripcion.Text = "";
            _Txt_Comprobante.Text = "";
            _Chk_DesHas.Checked = false;
        }
        private string _Mtd_Buscar()
        {
            _Er_Error.Dispose();
            if (_Chk_DesHas.Checked)
            {
                if (_Txt_Comprobante.Text.Trim().Length > 0 & _Txt_Hasta.Text.Trim().Length > 0)
                {
                    if (Convert.ToInt32(_Txt_Comprobante.Text) > 0 & Convert.ToInt32(_Txt_Hasta.Text) > 0)
                    {
                        if (Convert.ToInt32(_Txt_Comprobante.Text) <= Convert.ToInt32(_Txt_Hasta.Text))
                        {
                            return _Mtd_EjecutarSentencia();
                        }
                        else
                        { MessageBox.Show("El número de comprobante hasta debe ser mayor que el número de comprobante desde", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    }
                    else
                    {
                        if (Convert.ToInt32(_Txt_Comprobante.Text) == 0) { _Er_Error.SetError(_Txt_Comprobante, "Información requerida!!!"); }
                        if (Convert.ToInt32(_Txt_Hasta.Text) == 0) { _Er_Error.SetError(_Txt_Hasta, "Información requerida!!!"); }
                    }
                }
                else
                {
                    if (_Txt_Comprobante.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Comprobante, "Información requerida!!!"); }
                    if (_Txt_Hasta.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Hasta, "Información requerida!!!"); }
                }
            }
            else
            {
                return _Mtd_EjecutarSentencia();
            }
            return "";
        }
        private string _Mtd_EjecutarSentencia()
        {
            string _Str_Criterio = "";
            string _Str_CadenaGrid = "SELECT CONVERT(VARCHAR,ISNULL(TCOMPROBANC.ctypcomp,0))+'-'+CONVERT(VARCHAR,ISNULL(TCOMPROBANC.cmontacco,0))+'-'+CONVERT(VARCHAR,ISNULL(TCOMPROBANC.cyearacco,0))+'-'+CONVERT(VARCHAR,ISNULL(TCOMPROBANC.cidcorrel,0)) AS Código, TCOMPROBANC.cname AS Descripción, CONVERT(VARCHAR,TCOMPROBANC.cregdate,103) AS Fecha, TCOMPROBANC.cidcomprob as Comprobante,CASE WHEN TMESCONTABLE.ccerrado='1' AND TCOMPROBANC.cstatus='1' THEN 'CERRADO' WHEN TMESCONTABLE.ccerrado='0' AND TCOMPROBANC.cstatus='1' THEN 'ACTUALIZADO' WHEN TMESCONTABLE.ccerrado='0' AND (TCOMPROBANC.cstatus<>'1' AND TCOMPROBANC.cstatus<>'9') THEN 'POR ACTUALIZAR' WHEN TCOMPROBANC.cstatus='9' THEN 'ANULADO POR SISTEMA' END AS Tipo " +
            "FROM TCOMPROBANC INNER JOIN " +
            "TMESCONTABLE ON TCOMPROBANC.cyearacco = TMESCONTABLE.cyearacco AND " +
            "TCOMPROBANC.cmontacco = TMESCONTABLE.cmontacco AND TCOMPROBANC.ccompany = TMESCONTABLE.ccompany WHERE TCOMPROBANC.ccompany='" + Frm_Padre._Str_Comp + "'";
            //----------
            string _Str_CadenaReport = "SELECT TCOMPROBANC.cidcomprob, TCOMPROBANC.ccompany, TCOMPROBANC.cname, TCOMPROBANC.cregdate, " +
            "TCOMPROBAND.corder, TCOMPROBAND.ccount, TCOMPROBAND.cdescrip, TCOMPROBAND.ctotdebe, TCOMPROBAND.ctothaber, " +
            "TCOMPROBAND.cnumdocu, TCOMPROBAND.ctdocument, TCOMPROBANC.ctotdebe AS TotalDebe, " +
            "TCOMPROBANC.ctothaber AS TotalHaber, TCOMPROBANC.cyearacco, TCOMPROBANC.cmontacco, TCOMPROBANC.ctypcomp, " +
            "TCOMPROBANC.cidcorrel,CONVERT(VARCHAR,ISNULL(TCOMPROBANC.ctypcomp,0))+'-'+CONVERT(VARCHAR,ISNULL(TCOMPROBANC.cmontacco,0))+'-'+CONVERT(VARCHAR,ISNULL(TCOMPROBANC.cyearacco,0))+'-'+CONVERT(VARCHAR,ISNULL(TCOMPROBANC.cidcorrel,0)) AS Mascara " +
            "FROM TCOMPROBANC INNER JOIN " +
            "TCOMPROBAND ON TCOMPROBANC.ccompany = TCOMPROBAND.ccompany AND " +
            "TCOMPROBANC.cidcomprob = TCOMPROBAND.cidcomprob INNER JOIN " +
            "TMESCONTABLE ON TCOMPROBANC.cyearacco = TMESCONTABLE.cyearacco AND " +
            "TCOMPROBANC.cmontacco = TMESCONTABLE.cmontacco AND TCOMPROBAND.ccompany = TMESCONTABLE.ccompany WHERE TCOMPROBANC.ccompany='" + Frm_Padre._Str_Comp + "'";
            //---------------------------------------
            if (Convert.ToInt32(_Cmb_Reporte.SelectedValue)==1)
            { _Str_Criterio += " AND TMESCONTABLE.ccerrado='1' AND TCOMPROBANC.cstatus='1'"; }
            else if (Convert.ToInt32(_Cmb_Reporte.SelectedValue) == 2)
            { _Str_Criterio += " AND TMESCONTABLE.ccerrado='0' AND TCOMPROBANC.cstatus='1'"; }
            else if (Convert.ToInt32(_Cmb_Reporte.SelectedValue) == 3)
            { _Str_Criterio += " AND TMESCONTABLE.ccerrado='0' AND (TCOMPROBANC.cstatus<>'1' AND TCOMPROBANC.cstatus<>'9') AND NOT EXISTS(SELECT cidcomprob FROM TPAGOSCXPM WHERE TPAGOSCXPM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TPAGOSCXPM.ccompany=TCOMPROBANC.ccompany AND TPAGOSCXPM.cidcomprob=TCOMPROBANC.cidcomprob) AND NOT EXISTS(SELECT cidcomprob FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBANRETC.cidcomprob=TCOMPROBANC.cidcomprob) AND NOT EXISTS(SELECT cidcomprob FROM TCOMPROBANISLRC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBANISLRC.cidcomprob=TCOMPROBANC.cidcomprob) AND NOT EXISTS(SELECT cidcomprob FROM TNOTARECEPC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND TNOTARECEPC.cidcomprob=TCOMPROBANC.cidcomprob)"; }
            else if (Convert.ToInt32(_Cmb_Reporte.SelectedValue) == 4)
            { _Str_Criterio += " AND TCOMPROBANC.cstatus='9'"; }
            //---------------------------------------
            if (Convert.ToString(_Cmb_TipComp.SelectedValue).Trim() != "nulo")
            { _Str_Criterio += " AND TCOMPROBANC.ctypcomp='" + Convert.ToString(_Cmb_TipComp.SelectedValue).Trim() + "'"; }
            //---------------------------------------
            if (Convert.ToString(_Cmb_Mes.SelectedValue).Trim() != "nulo")
            {
                string[] _Str_MesAno = new string[2];
                _Str_MesAno = _Mtd_ExtraerMesAno(Convert.ToString(_Cmb_Mes.SelectedValue));
                _Str_Criterio += " AND TCOMPROBANC.cmontacco='" + _Str_MesAno[0] + "' AND TCOMPROBANC.cyearacco='" + _Str_MesAno[1] + "'";
            }
            //---------------------------------------
            if (_Chk_DesHas.Checked)
            { _Str_Criterio += " AND TCOMPROBANC.cidcorrel BETWEEN '" + _Txt_Comprobante.Text.Trim() + "' AND '" + _Txt_Hasta.Text.Trim() + "'"; }
            else
            { if (_Txt_Comprobante.Text.Trim().Length > 0) { _Str_Criterio += " AND TCOMPROBANC.cidcorrel='" + _Txt_Comprobante.Text.Trim() + "'"; } }
            //---------------------------------------
            if (_Txt_Descripcion.Text.Trim().Length > 0)
            { _Str_Criterio += " AND EXISTS(SELECT cidcomprob FROM TCOMPROBAND WHERE TCOMPROBAND.ccompany=TCOMPROBANC.ccompany AND TCOMPROBAND.cidcomprob=TCOMPROBANC.cidcomprob AND TCOMPROBAND.cdescrip LIKE '%" + _Txt_Descripcion.Text.Trim() + "%')"; }
            //---------------------------------------
            _Str_Criterio += " ORDER BY TCOMPROBANC.cidcomprob ASC";
            //---------------------------------------
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_CadenaGrid + _Str_Criterio);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns["Comprobante"].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            return _Str_CadenaReport + _Str_Criterio;
        }
        Report.rInfcomprobante _My_Reporte_G;
        private void _Mtd_CargarReporte(string _P_Str_Cadena, bool _P_Bol_AnuladoPorSistema)
        {
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_P_Str_Cadena);
            _Ds.Tables[0].TableName = "vst_reportecomprobante";
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Mtd_CargarComprobantes(_P_Str_Cadena, _Cmb_Reporte.SelectedValue);
                Report.rInfcomprobante _My_Reporte = new T3.Report.rInfcomprobante();
                _My_Reporte.SetDataSource(_Ds.Tables[0]);
                Section _sec = _My_Reporte.ReportDefinition.Sections["Section1"];
                TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                TextObject tex2 = _sec.ReportObjects["rif"] as TextObject;
                tex2.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(crif) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                TextObject tex3 = _sec.ReportObjects["Direccion"] as TextObject;
                tex3.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(caddressl) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                TextObject tex4 = _sec.ReportObjects["Telefonos"] as TextObject;
                tex4.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cphone1) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                TextObject tex5 = _sec.ReportObjects["Email"] as TextObject;
                tex5.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cemail) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                if (_P_Bol_AnuladoPorSistema)
                {
                    TextObject tex6 = _sec.ReportObjects["Text12"] as TextObject;
                    tex6.Text = "(Anulado por el sistema)";
                }
                this._Rpv_Main.ReportSource = _My_Reporte;
                _Rpv_Main.RefreshReport();
                _My_Reporte_G = _My_Reporte;
                //_My_Reporte.Close();
                //_My_Reporte.Dispose();                
            }
            else
            {
                this._Rpv_Main.ReportSource = null;
            }
        }
        private void _Mtd_CargarReporteCheq(string _P_Str_Cadena, bool _P_Bol_AnuladoPorSistema)
        {
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_P_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Mtd_CargarComprobantes(_P_Str_Cadena, _Cmb_Reporte.SelectedValue);
                Report.rComprobanEgresoCheque _My_Reporte = new T3.Report.rComprobanEgresoCheque();
                _My_Reporte.SetDataSource(_Ds.Tables[0]);
                if (_P_Bol_AnuladoPorSistema)
                {
                    Section _sec = _My_Reporte.ReportDefinition.Sections["GroupHeaderSection2"];
                    TextObject tex1 = _sec.ReportObjects["Text1"] as TextObject;
                    tex1.Text = "(Anulado por el sistema)";
                }
                this._Rpv_Main.ReportSource = _My_Reporte;
                _Rpv_Main.RefreshReport();
                //_My_Reporte.Close();
                //_My_Reporte.Dispose();
            }
            else
            {
                this._Rpv_Main.ReportSource = null;
            }
        }
        string[] _Str_Comprob;
        private void _Mtd_CargarComprobantes(string _P_Str_Cadena, object _P_Ob_Consulta)
        {
            _Str_Comprob = new string[0];
            if (Convert.ToInt32(_P_Ob_Consulta) == 3)
            {
                _P_Str_Cadena = "SELECT TCOMPROBANC.cidcomprob " +
                "FROM TCOMPROBANC INNER JOIN " +
                "TMESCONTABLE ON TCOMPROBANC.cyearacco = TMESCONTABLE.cyearacco AND " +
                "TCOMPROBANC.cmontacco = TMESCONTABLE.cmontacco AND TCOMPROBANC.ccompany = TMESCONTABLE.ccompany " + _P_Str_Cadena.Substring(_P_Str_Cadena.IndexOf("WHERE"));
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_P_Str_Cadena);
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Str_Comprob = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Comprob, _Str_Comprob.Length + 1);
                    _Str_Comprob[_Str_Comprob.Length - 1] = Convert.ToString(_Row["cidcomprob"].ToString().Trim());
                }
            }
        }
        private void _Mtd_ImprimirActulizarComp()
        {
            string _Str_Cadena = "";
            PrintDialog _Print = new PrintDialog();
            if (_Print.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //---Configuración de impresión.
                    var _PageSettings = new System.Drawing.Printing.PageSettings();
                    _PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
                    _PageSettings.Landscape = false;
                    var _PrtSettings = new System.Drawing.Printing.PrinterSettings { PrinterName = _Print.PrinterSettings.PrinterName, Copies = _Print.PrinterSettings.Copies, Collate = _Print.PrinterSettings.Collate };
                    _My_Reporte_G.PrintToPrinter(_PrtSettings, _PageSettings, false);
                    //---Configuración de impresión.
                    if (MessageBox.Show("¿La impresión se ha realizado correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Cursor = Cursors.WaitCursor;
                        foreach (string _Str in _Str_Comprob)
                        {
                            _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1',cdateupd=getdate(),cuserupd='"+Frm_Padre._Str_Use+"' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                        MessageBox.Show("La operación ha sido realizadad correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //-----------------
                        this._Rpv_Main.ReportSource = null;
                        _Pnl_Superior.Visible = false;
                        _Str_SentenciaReport = _Mtd_Buscar();
                        Cursor = Cursors.Default;
                        _Tb_Tab.SelectedIndex = 0;
                        //-----------------
                    }
                }
                catch (Exception _Ex)
                {
                    MessageBox.Show("Error al conectarse con la impresora" + _Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void _Mtd_CofigTab2(object _P_Ob_Consulta)
        {
            if (Convert.ToInt32(_P_Ob_Consulta) == 3)
            {
                _Rpv_Main.ShowPrintButton = false;
                _Pnl_Superior.Visible = true;
            }
            else
            {
                _Rpv_Main.ShowPrintButton = true;
                _Pnl_Superior.Visible = false;
            }
        }
        
        private bool _Mtd_ComprobCheque(string _P_Str_Comprobante)
        {
            string _Str_Cadena = "SELECT cidcomprob FROM TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_ComprobRetImp(string _P_Str_Comprobante)
        {
            string _Str_Cadena = "SELECT cidcomprob FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_ComprobRetIslr(string _P_Str_Comprobante)
        {
            string _Str_Cadena = "SELECT cidcomprob FROM TCOMPROBANISLRC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_ComprobNR(string _P_Str_Comprobante)
        {
            string _Str_Cadena = "SELECT cidcomprob FROM TNOTARECEPC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_ComprobManual(string _P_Str_Comprobante)
        {
            string _Str_Cadena = "SELECT cidcomprob FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "' AND csistema='0'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_ComprobActualizado(string _P_Str_Comprobante)
        {
            string _Str_Cadena = "SELECT cidcomprob FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "' AND cstatus='1'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_ComprobAnuladoPorSistema(string _P_Str_Comprobante)
        {
            string _Str_Cadena = "SELECT cidcomprob FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "' AND cstatus='9'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void Frm_ConsultaComprobante_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Mtd_Color_Estandar(this);
        }

        private void _Cmb_TipComp_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarTipoComprob();
        }

        private void _Cmb_Mes_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarMeses(Convert.ToInt32(_Cmb_Reporte.SelectedValue));
        }

        private void _Txt_Comprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Comprobante, e, 10, 0);
        }

        private void _Txt_Hasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Hasta, e, 10, 0);
        }

        private void Frm_ConsultaComprobante_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            this._Rpv_Main.ReportSource = null;
            _Str_SentenciaReport = _Mtd_Buscar();
            Cursor = Cursors.Default;
        }
        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                e.Cancel = true;
            }
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (_Dg_Grid.CurrentCell != null)
                {
                    string _Str_Cadena = "SELECT TCOMPROBANC.cidcomprob, TCOMPROBANC.ccompany, TCOMPROBANC.cname, TCOMPROBANC.cregdate, " +
                    "TCOMPROBAND.corder, TCOMPROBAND.ccount, TCOMPROBAND.cdescrip, TCOMPROBAND.ctotdebe, TCOMPROBAND.ctothaber, " +
                    "TCOMPROBAND.cnumdocu, TCOMPROBAND.ctdocument, TCOMPROBANC.ctotdebe AS TotalDebe, " +
                    "TCOMPROBANC.ctothaber AS TotalHaber, TCOMPROBANC.cyearacco, TCOMPROBANC.cmontacco, TCOMPROBANC.ctypcomp, " +
                    "TCOMPROBANC.cidcorrel,CONVERT(VARCHAR,ISNULL(TCOMPROBANC.ctypcomp,0))+'-'+CONVERT(VARCHAR,ISNULL(TCOMPROBANC.cmontacco,0))+'-'+CONVERT(VARCHAR,ISNULL(TCOMPROBANC.cyearacco,0))+'-'+CONVERT(VARCHAR,ISNULL(TCOMPROBANC.cidcorrel,0)) AS Mascara " +
                    "FROM TCOMPROBANC INNER JOIN " +
                    "TCOMPROBAND ON TCOMPROBANC.ccompany = TCOMPROBAND.ccompany AND " +
                    "TCOMPROBANC.cidcomprob = TCOMPROBAND.cidcomprob INNER JOIN " +
                    "TMESCONTABLE ON TCOMPROBANC.cyearacco = TMESCONTABLE.cyearacco AND " +
                    "TCOMPROBANC.cmontacco = TMESCONTABLE.cmontacco AND TCOMPROBAND.ccompany = TMESCONTABLE.ccompany WHERE TCOMPROBANC.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBANC.cidcomprob='" + Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Comprobante"].Value) + "'";
                    _Mtd_CofigTab2(_Cmb_Reporte.SelectedValue);
                    _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                    _Tb_Tab.SelectedIndex = 1;
                    _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                    if (_Mtd_ComprobCheque(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Comprobante"].Value)))
                    {
                        string _Str_CadenaCheq = "SELECT * FROM VST_COMPROP_CHEQUE_EGRESO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobcheque='" + Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Comprobante"].Value) + "'";
                        bool _Bol_Transf = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_CadenaCheq).Tables[0].Rows.Count == 0;
                        if (_Mtd_ComprobAnuladoPorSistema(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Comprobante"].Value)))
                        {
                            if (_Bol_Transf)
                            {
                                Cursor = Cursors.WaitCursor;
                                _Mtd_CargarReporte(_Str_Cadena, true);
                                Cursor = Cursors.Default;
                            }
                            else
                            {
                                Cursor = Cursors.WaitCursor;
                                _Mtd_CargarReporteCheq(_Str_CadenaCheq, true);
                                Cursor = Cursors.Default;
                            }
                        }
                        else
                        {
                            if (_Bol_Transf)
                            {
                                Cursor = Cursors.WaitCursor;
                                _Mtd_CargarReporte(_Str_Cadena, false);
                                Cursor = Cursors.Default;
                            }
                            else
                            {
                                Cursor = Cursors.WaitCursor;
                                _Mtd_CargarReporteCheq(_Str_CadenaCheq, false);
                                Cursor = Cursors.Default;
                            }
                            _Rpv_Main.ShowPrintButton = _Mtd_ComprobActualizado(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Comprobante"].Value));
                            _Pnl_Superior.Visible = false;
                        }
                    }
                    else if (_Mtd_ComprobAnuladoPorSistema(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Comprobante"].Value)))
                    {
                        Cursor = Cursors.WaitCursor;
                        _Mtd_CargarReporte(_Str_Cadena, true);
                        Cursor = Cursors.Default;
                    }
                    else if ((_Mtd_ComprobRetImp(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Comprobante"].Value)) | _Mtd_ComprobRetIslr(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Comprobante"].Value)) | _Mtd_ComprobNR(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Comprobante"].Value)) | _Mtd_ComprobManual(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Comprobante"].Value))) & !_Mtd_ComprobActualizado(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Comprobante"].Value)))
                    {
                        //_Rpv_Main.ShowPrintButton = false;
                        _Pnl_Superior.Visible = false;
                        Cursor = Cursors.WaitCursor;
                        _Mtd_CargarReporte(_Str_Cadena, false);
                        Cursor = Cursors.Default;
                    }
                    else
                    {
                        Cursor = Cursors.WaitCursor;
                        _Mtd_CargarReporte(_Str_Cadena, false);
                        Cursor = Cursors.Default;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("La operación no se ha podido realizar correctamente, intente nuevamente.", 
                                "Información", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
            }
        }

        private void _Cmb_Reporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_Ini2();
        }

        private void _Chk_DesHas_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chk_DesHas.Checked)
            { _Txt_Hasta.Visible = true; }
            else
            { _Txt_Hasta.Visible = false; _Txt_Hasta.Text = ""; }
        }

        private void _Ctrl_Contex_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Grid.CurrentCell == null)
            { e.Cancel = true; }
        }

        private void verTodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cursor = Cursors.WaitCursor;
            //this._Rpv_Main.ReportSource = null;
            //if (_Str_SentenciaReport.Trim().Length > 0)
            //{
            //    _Mtd_CargarReporte(_Str_SentenciaReport);
            //    if (_Dg_Grid.RowCount > 0)
            //    { _Mtd_CofigTab2(_Cmb_Reporte.SelectedValue); _Tb_Tab.SelectedIndex = 1; }
            //    else
            //    { MessageBox.Show("No existen registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            //}
            //Cursor = Cursors.Default;
        }

        private void _Bt_Imprimir_Click(object sender, EventArgs e)
        {
            _Mtd_ImprimirActulizarComp();
        }

        private void Frm_ConsultaComprobante_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Rpv_Main.Dispose();
            _Rpv_Main = null;
        }
    }
}
