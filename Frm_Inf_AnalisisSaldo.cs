using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Threading;
using System.Linq;

namespace T3
{
    public partial class Frm_Inf_AnalisisSaldo : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_AnalisisSaldo()
        {
            InitializeComponent();
            _Txt_Caja.Text = "";
            _Txt_Caja.Tag = "";
            _Txt_Caja.Enabled = false;
            _Bt_Caja.Enabled = false;
            label5.Visible = false;
            _Txt_Caja.Visible = false;
            _Bt_Caja.Visible = false;

            _Cb_MesAnoCierre.Visible = false;
            label3.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            _Mtd_MesAnoCierreContable();
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_MesAnoCierreContable()
        {
            try
            {
                string _Str_SentenciaSQL = "SELECT DISTINCT CONVERT(DATETIME,'01'+'/'+CONVERT(VARCHAR,CMES)+'/'+CONVERT(VARCHAR,CANO)) AS EEE,CONVERT(VARCHAR,CANO)+'-'+CONVERT(VARCHAR,CMES) AS CVALOREAL,CONVERT(VARCHAR,YEAR(DATEADD(mm,-1,CONVERT(DATETIME,'01'+'/'+CONVERT(VARCHAR,CMES)+'/'+CONVERT(VARCHAR,CANO)))))+'-'+CONVERT(VARCHAR,MONTH(DATEADD(mm,-1,CONVERT(DATETIME,'01'+'/'+CONVERT(VARCHAR,CMES)+'/'+CONVERT(VARCHAR,CANO)))))"+
" AS CVALOR FROM TSALDOCARTERAHISTORICO WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' ORDER BY EEE DESC ";
                DataSet _Ds_DataSet=new DataSet();
                _Ds_DataSet=Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                _myUtilidad._Mtd_CargarCombo(_Cb_MesAnoCierre, _Ds_DataSet,"CVALOR","CVALOREAL");
            }
            catch
            {
            }
        }
        public Frm_Inf_AnalisisSaldo(string _P_Str_Cliente)
        {
            InitializeComponent();
            _Rb_Cliente.Checked = true;
            _Mtd_CargarCliente();
            _Cb_ZonaVendedor.SelectedValue = _P_Str_Cliente;
            _Cb_ZonaVendedor.Enabled = true;
        }

        private void _Mtd_CargarLimteCredito()
        {
            string _Str_Sql = "SELECT ccodlimite,cdescripcion FROM TLIMITCREDITO WHERE cdelete=0 ORDER BY cdescripcion";
            _myUtilidad._Mtd_CargarCombo(_Cb_EscalaCredito, _Str_Sql);
        }
        private void _Mtd_CargarTpoDoc()
        {

            string _Str_Sql = "SELECT ctipdocfact,ctipdoccheqdev,ctipdocnotdeb,ctipdocnotcred,ctipdoccheq FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            if (_Ds.Tables[0].Rows.Count > 0)
            {

                _myArrayList.Add(new T3.Clases._Cls_ArrayList("FACTURAS", Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]).Trim()));
                _myArrayList.Add(new T3.Clases._Cls_ArrayList("CHEQUES DEVUELTOS", Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdoccheqdev"]).Trim()));
                _myArrayList.Add(new T3.Clases._Cls_ArrayList("ND", Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocnotdeb"]).Trim()));
                _myArrayList.Add(new T3.Clases._Cls_ArrayList("NC", Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocnotcred"]).Trim()));
                _myArrayList.Add(new T3.Clases._Cls_ArrayList("CHEQUES EN TRANSITO", Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdoccheq"]).Trim()));
                _Cb_TpoDoc.DataSource = _myArrayList;
                _Cb_TpoDoc.DisplayMember = "Display";
                _Cb_TpoDoc.ValueMember = "Value";
                _Cb_TpoDoc.SelectedValue = "nulo";
            }
        }
        private void _Mtd_CargarZona()
        {
            string _Str_Sql = "SELECT c_zona,cname FROM TZONAVENTA WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_ZonaVendedor, _Str_Sql);
        }
        private void _Mtd_CargarVendedor()
        {
            string _Str_Sql = "SELECT cvendedor,(RTRIM(cvendedor)+'-'+RTRIM(cname)) AS vendedor_descrip FROM TVENDEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0 ORDER BY CAST(REPLACE(cvendedor,RTRIM(ccompany)+'_','') AS INTEGER)";
            _myUtilidad._Mtd_CargarCombo(_Cb_ZonaVendedor, _Str_Sql);
        }
        private void _Mtd_CargarCliente()
        {
            string _Str_Sql = "SELECT ccliente,(RTRIM(ccliente)+'-'+RTRIM(c_nomb_comer)) AS cliente_descrip FROM TCLIENTE WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND EXISTS (SELECT TSALDOCLIENTED.ccliente FROM dbo.TSALDOCLIENTED WHERE dbo.TSALDOCLIENTED.cgroupcomp=TCLIENTE.cgroupcomp AND dbo.TSALDOCLIENTED.ccliente=TCLIENTE.ccliente) ORDER BY ccliente";
            _myUtilidad._Mtd_CargarCombo(_Cb_ZonaVendedor, _Str_Sql);
        }

        private void _Cb_EscalaCredito_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_CargarLimteCredito();
            this.Cursor = Cursors.Default;
        }

        private void _Cb_TpoDoc_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_CargarTpoDoc();
            this.Cursor = Cursors.Default;
        }

        private void _Cb_ZonaVendedor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (_Rb_Vendedor.Checked)
            {
                _Mtd_CargarVendedor();
            }
            else if (_Rb_Cliente.Checked)
            {
                _Mtd_CargarCliente();
            }
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_BusquedaPorCierre()
        {
            string _Str_Vendedor = "0";
            string _Str_Cliente = "0";
            string _Str_CodLimit = "0";
            string _Str_TipoDoc = "0";
            //-----------------------------------------------------------------------
            if (_Rb_Vendedor.Checked && _Cb_ZonaVendedor.SelectedIndex > 0)
            { _Str_Vendedor = _Cb_ZonaVendedor.SelectedValue.ToString().Trim(); }
            else if (_Rb_Cliente.Checked && _Cb_ZonaVendedor.SelectedIndex > 0)
            { _Str_Cliente = _Cb_ZonaVendedor.SelectedValue.ToString().Trim(); }
            //--------------
            if (_Rb_EscalaCredito.Checked && _Cb_EscalaCredito.SelectedIndex > 0)
            { _Str_CodLimit = _Cb_EscalaCredito.SelectedValue.ToString().Trim(); }
            else if (_Rb_TpoDoc.Checked && _Cb_TpoDoc.SelectedIndex > 0)
            { _Str_TipoDoc = _Cb_TpoDoc.SelectedValue.ToString(); }
            //-----------------------------------------------------------------------
            string _Str_Sql = "EXEC PA_ANALISISSALDOPORCAJA '" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Txt_Caja.Text.Trim() + "','" + _Txt_Caja.Tag + "','" + _Str_Vendedor + "','" + _Str_Cliente + "','" + _Str_CodLimit + "','" + _Str_TipoDoc + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Ds.Tables[0].TableName = "VST_SALDOS_ALLDOCS_DEMO";
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_Reporte = "";
                if (_Chk_Imp.Checked)
                {
                    _Str_Reporte = "T3.Report.rSaldoAnalisisDetVendCI";
                }
                else
                { _Str_Reporte = "T3.Report.rSaldoAnalisisDetVendSI"; }
                ReportClass _MyReport = (ReportClass)Activator.CreateInstance(Type.GetType(_Str_Reporte));
                _MyReport.SetDataSource(_Ds.Tables[0]);
                Section _sec = _MyReport.ReportDefinition.Sections["Section2"];
                TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                _Rpv_Main.ReportSource = _MyReport;
                _Rpv_Main.RefreshReport();
            }
            else
            {
                MessageBox.Show("No se encontró información.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _Rpv_Main.ReportSource = null;
            }
        }
        private void _Mtd_Busqueda()
        {
            string _Str_Sql = "";
            DataSet _Ds;
            if (_Rb_Vendedor.Checked)
            {
                if (_Chk_Imp.Checked)
                {
                    if (_Rbt_CierreMes.Checked)
                    {
                        string _Str_Mes="";
                        string _Str_Ano = "";
                        string[] _Str_MesAno = _Cb_MesAnoCierre.SelectedValue.ToString().Split('-');
                        _Str_Mes = _Str_MesAno[1];
                        _Str_Ano = _Str_MesAno[0];
                        _Str_Sql = "SELECT * FROM TSALDOCARTERAHISTORICO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0 AND CMES='"+_Str_Mes+"' AND CANO='"+_Str_Ano+"'";
                    }
                    else if (_Rbt_Actual.Checked)
                    {
                        _Str_Sql = "SELECT * FROM VST_SALDOS_ALLDOCS_DEMO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0";
                    }
                    else
                    {
                        _Str_Sql = "SELECT * FROM TSALDOCARTERAHISTORICOCAJA WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0 AND CCAJA='"+_Txt_Caja.Text+"'";
                    }
                    if (_Rb_EscalaCredito.Checked && _Cb_EscalaCredito.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ccodlimite='" + _Cb_EscalaCredito.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_TpoDoc.Checked && _Cb_TpoDoc.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ctipodocument='" + _Cb_TpoDoc.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_TpoDoc.Checked && _Cb_TpoDoc.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ctipodocument='" + _Cb_TpoDoc.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_Vendedor.Checked && _Cb_ZonaVendedor.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND cvendedor='" + _Cb_ZonaVendedor.SelectedValue.ToString() + "'";
                    }
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        Report.rSaldoAnalisisDetVendCI _MyReport = new T3.Report.rSaldoAnalisisDetVendCI();
                        _MyReport.SetDataSource(_Ds.Tables[0]);
                        Section _sec = _MyReport.ReportDefinition.Sections["Section2"];
                        TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                        tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                        _Rpv_Main.ReportSource = _MyReport;
                        _Rpv_Main.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró información.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _Rpv_Main.ReportSource = null;
                    }
                }
                else
                {
                    if (_Rbt_CierreMes.Checked)
                    {
                        string _Str_Mes = "";
                        string _Str_Ano = "";
                        string[] _Str_MesAno = _Cb_MesAnoCierre.SelectedValue.ToString().Split('-');
                        _Str_Mes = _Str_MesAno[1];
                        _Str_Ano = _Str_MesAno[0];
                        _Str_Sql = "SELECT * FROM TSALDOCARTERAHISTORICO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0 AND CMES='" + _Str_Mes + "' AND CANO='" + _Str_Ano + "'";
                    }
                    else if (_Rbt_Actual.Checked)
                    {
                        _Str_Sql = "SELECT * FROM VST_SALDOS_ALLDOCS_DEMO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0";
                    }
                    else
                    {
                        _Str_Sql = "SELECT * FROM TSALDOCARTERAHISTORICOCAJA WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0 AND CCAJA='" + _Txt_Caja.Text + "'";
                    }
                    if (_Rb_EscalaCredito.Checked && _Cb_EscalaCredito.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ccodlimite='" + _Cb_EscalaCredito.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_TpoDoc.Checked && _Cb_TpoDoc.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ctipodocument='" + _Cb_TpoDoc.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_TpoDoc.Checked && _Cb_TpoDoc.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ctipodocument='" + _Cb_TpoDoc.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_Vendedor.Checked && _Cb_ZonaVendedor.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND cvendedor='" + _Cb_ZonaVendedor.SelectedValue.ToString() + "'";
                    }
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        Report.rSaldoAnalisisDetVendSI _MyReport = new T3.Report.rSaldoAnalisisDetVendSI();
                        _MyReport.SetDataSource(_Ds.Tables[0]);
                        Section _sec = _MyReport.ReportDefinition.Sections["Section2"];
                        TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                        tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                        _Rpv_Main.ReportSource = _MyReport;
                        _Rpv_Main.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró información.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _Rpv_Main.ReportSource = null;
                    }
                }
            }
            else if (_Rb_Cliente.Checked)
            {
                if (_Chk_Imp.Checked)
                {
                    if (_Rbt_CierreMes.Checked)
                    {
                        string _Str_Mes = "";
                        string _Str_Ano = "";
                        string[] _Str_MesAno = _Cb_MesAnoCierre.SelectedValue.ToString().Split('-');
                        _Str_Mes = _Str_MesAno[1];
                        _Str_Ano = _Str_MesAno[0];
                        _Str_Sql = "SELECT * FROM TSALDOCARTERAHISTORICO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0 AND CMES='" + _Str_Mes + "' AND CANO='" + _Str_Ano + "'";
                    }
                    else if (_Rbt_Actual.Checked)
                    {
                        _Str_Sql = "SELECT * FROM VST_SALDOS_ALLDOCS_DEMO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0";
                    }
                    else
                    {
                        _Str_Sql = "SELECT * FROM TSALDOCARTERAHISTORICOCAJA WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0 AND CCAJA='" + _Txt_Caja.Text + "'";
                    }
                    if (_Rb_EscalaCredito.Checked && _Cb_EscalaCredito.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ccodlimite='" + _Cb_EscalaCredito.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_TpoDoc.Checked && _Cb_TpoDoc.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ctipodocument='" + _Cb_TpoDoc.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_TpoDoc.Checked && _Cb_TpoDoc.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ctipodocument='" + _Cb_TpoDoc.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_Cliente.Checked && _Cb_ZonaVendedor.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ccliente='" + _Cb_ZonaVendedor.SelectedValue.ToString() + "'";
                    }
                    
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        Report.rSaldoAnalisisClienteCI _MyReport = new T3.Report.rSaldoAnalisisClienteCI();
                        _MyReport.SetDataSource(_Ds.Tables[0]);
                        Section _sec = _MyReport.ReportDefinition.Sections["Section2"];
                        TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                        tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                        _Rpv_Main.ReportSource = _MyReport;
                        _Rpv_Main.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró información.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _Rpv_Main.ReportSource = null;
                    }
                }
                else
                {
                    if (_Rbt_CierreMes.Checked)
                    {
                        string _Str_Mes = "";
                        string _Str_Ano = "";
                        string[] _Str_MesAno = _Cb_MesAnoCierre.SelectedValue.ToString().Split('-');
                        _Str_Mes = _Str_MesAno[1];
                        _Str_Ano = _Str_MesAno[0];
                        _Str_Sql = "SELECT * FROM TSALDOCARTERAHISTORICO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0 AND CMES='" + _Str_Mes + "' AND CANO='" + _Str_Ano + "'";
                    }
                    else if (_Rbt_Actual.Checked)
                    {
                        _Str_Sql = "SELECT * FROM VST_SALDOS_ALLDOCS_DEMO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0";
                    }
                    else
                    {
                        _Str_Sql = "SELECT * FROM TSALDOCARTERAHISTORICOCAJA WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0 AND CCAJA='" + _Txt_Caja.Text + "'";
                    }
                    if (_Rb_EscalaCredito.Checked && _Cb_EscalaCredito.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ccodlimite='" + _Cb_EscalaCredito.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_TpoDoc.Checked && _Cb_TpoDoc.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ctipodocument='" + _Cb_TpoDoc.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_TpoDoc.Checked && _Cb_TpoDoc.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ctipodocument='" + _Cb_TpoDoc.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_Cliente.Checked && _Cb_ZonaVendedor.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ccliente='" + _Cb_ZonaVendedor.SelectedValue.ToString() + "'";
                    }
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        Report.rSaldoAnalisisClienteSI _MyReport = new T3.Report.rSaldoAnalisisClienteSI();
                        _MyReport.SetDataSource(_Ds.Tables[0]);
                        Section _sec = _MyReport.ReportDefinition.Sections["Section2"];
                        TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                        tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                        _Rpv_Main.ReportSource = _MyReport;
                        _Rpv_Main.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró información.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _Rpv_Main.ReportSource = null;
                    }
                }
            }
        }
        private void _Mtd_BusquedaExport()
        {
            string _Str_Sql = "";
            DataSet _Ds;
            if (_Rb_Vendedor.Checked)
            {
                if (_Chk_Imp.Checked)
                {
                    if (_Rbt_CierreMes.Checked)
                    {
                        string _Str_Mes = "";
                        string _Str_Ano = "";
                        string[] _Str_MesAno = _Cb_MesAnoCierre.SelectedValue.ToString().Split('-');
                        _Str_Mes = _Str_MesAno[1];
                        _Str_Ano = _Str_MesAno[0];
                        _Str_Sql = "SELECT cvendedor AS Vendedor,REPLACE(vendedor_descrip,LTRIM(RTRIM(cvendedor))+'-','') AS Nombre,ccliente AS Cliente,c_nomb_comer AS Descripción,tipodoc_complet AS [Tipo Documento],cnumdocu AS Documento,CONVERT(VARCHAR,cfechafact,103) AS [Fecha Doc.],CASE WHEN (tipodoc_complet = 'N/C./APLICAR') AND  (cfechaentrega IS NULL) THEN CONVERT(VARCHAR,ISNULL(cfechaentrega,cfechafact),103) ELSE  CONVERT(VARCHAR,cfechaentrega,103) END  AS [Fecha Entrega],CONVERT(VARCHAR,cfelimitcobro,103) AS [Fecha Venc.],dbo.Fnc_Formatear(csaldofactura) AS [Saldo Doc.],dbo.Fnc_Formatear(por_vencer) AS [Por Vencer],dbo.Fnc_Formatear(hasta15) AS [Hasta 15],dbo.Fnc_Formatear(hasta30) AS [De 16 a 30],dbo.Fnc_Formatear(hasta45) AS [De 31 a 45],dbo.Fnc_Formatear(hastamas45) AS [Mas de 45],dias_vence AS [Días Vencid.] FROM TSALDOCARTERAHISTORICO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0 AND CMES='" + _Str_Mes + "' AND CANO='" + _Str_Ano + "'";
                    }
                    else if (_Rbt_Actual.Checked)
                    {
                        _Str_Sql = "SELECT cvendedor AS Vendedor,REPLACE(vendedor_descrip,LTRIM(RTRIM(cvendedor))+'-','') AS Nombre,ccliente AS Cliente,c_nomb_comer AS Descripción,tipodoc_complet AS [Tipo Documento],cnumdocu AS Documento,CONVERT(VARCHAR,cfechafact,103) AS [Fecha Doc.],CASE WHEN (tipodoc_complet = 'N/C./APLICAR') AND  (cfechaentrega IS NULL) THEN CONVERT(VARCHAR,ISNULL(cfechaentrega,cfechafact),103) ELSE  CONVERT(VARCHAR,cfechaentrega,103) END  AS [Fecha Entrega],CONVERT(VARCHAR,cfelimitcobro,103) AS [Fecha Venc.],dbo.Fnc_Formatear(csaldofactura) AS [Saldo Doc.],dbo.Fnc_Formatear(por_vencer) AS [Por Vencer],dbo.Fnc_Formatear(hasta15) AS [Hasta 15],dbo.Fnc_Formatear(hasta30) AS [De 16 a 30],dbo.Fnc_Formatear(hasta45) AS [De 31 a 45],dbo.Fnc_Formatear(hastamas45) AS [Mas de 45],dias_vence AS [Días Vencid.] FROM VST_SALDOS_ALLDOCS_DEMO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0";
                    }
                    else
                    {
                        _Str_Sql = "SELECT cvendedor AS Vendedor,REPLACE(vendedor_descrip,LTRIM(RTRIM(cvendedor))+'-','') AS Nombre,ccliente AS Cliente,c_nomb_comer AS Descripción,tipodoc_complet AS [Tipo Documento],cnumdocu AS Documento,CONVERT(VARCHAR,cfechafact,103) AS [Fecha Doc.],CASE WHEN (tipodoc_complet = 'N/C./APLICAR') AND  (cfechaentrega IS NULL) THEN CONVERT(VARCHAR,ISNULL(cfechaentrega,cfechafact),103) ELSE  CONVERT(VARCHAR,cfechaentrega,103) END  AS [Fecha Entrega],CONVERT(VARCHAR,cfelimitcobro,103) AS [Fecha Venc.],dbo.Fnc_Formatear(csaldofactura) AS [Saldo Doc.],dbo.Fnc_Formatear(por_vencer) AS [Por Vencer],dbo.Fnc_Formatear(hasta15) AS [Hasta 15],dbo.Fnc_Formatear(hasta30) AS [De 16 a 30],dbo.Fnc_Formatear(hasta45) AS [De 31 a 45],dbo.Fnc_Formatear(hastamas45) AS [Mas de 45],dias_vence AS [Días Vencid.] FROM TSALDOCARTERAHISTORICOCAJA WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0 AND CCAJA='" + _Txt_Caja.Text + "'";
                    }
                    if (_Rb_EscalaCredito.Checked && _Cb_EscalaCredito.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ccodlimite='" + _Cb_EscalaCredito.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_TpoDoc.Checked && _Cb_TpoDoc.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ctipodocument='" + _Cb_TpoDoc.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_TpoDoc.Checked && _Cb_TpoDoc.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ctipodocument='" + _Cb_TpoDoc.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_Vendedor.Checked && _Cb_ZonaVendedor.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND cvendedor='" + _Cb_ZonaVendedor.SelectedValue.ToString() + "'";
                    }
                    _Str_Sql += " ORDER BY cvendedor "; //Ordenacion
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            if (_Sfd_1.ShowDialog() == DialogResult.OK)
                            {
                                Cursor = Cursors.WaitCursor;
                                _Ds_Temp = _Ds;
                                Cursor = Cursors.Default;
                                Thread _Thr_Thread = new Thread(new ThreadStart(_Mtd_Consultar));
                                _Thr_Thread.Start();
                                while (!_Thr_Thread.IsAlive) ;
                                Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread, "Espere por favor...");
                                _Frm_Form.ShowDialog(this);
                                _Frm_Form.Dispose();
                            }
                        }
                        catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar exportar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró información.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _Rpv_Main.ReportSource = null;
                    }
                }
                else
                {
                    if (_Rbt_CierreMes.Checked)
                    {
                        string _Str_Mes = "";
                        string _Str_Ano = "";
                        string[] _Str_MesAno = _Cb_MesAnoCierre.SelectedValue.ToString().Split('-');
                        _Str_Mes = _Str_MesAno[1];
                        _Str_Ano = _Str_MesAno[0];
                        _Str_Sql = "SELECT cvendedor AS Vendedor,REPLACE(vendedor_descrip,LTRIM(RTRIM(cvendedor))+'-','') AS Nombre,ccliente AS Cliente,c_nomb_comer AS Descripción,tipodoc_complet AS [Tipo Documento],cnumdocu AS Documento,CONVERT(VARCHAR,cfechafact,103) AS [Fecha Doc.],CASE WHEN (tipodoc_complet = 'N/C./APLICAR') AND  (cfechaentrega IS NULL) THEN CONVERT(VARCHAR,ISNULL(cfechaentrega,cfechafact),103) ELSE  CONVERT(VARCHAR,cfechaentrega,103) END  AS [Fecha Entrega],CONVERT(VARCHAR,cfelimitcobro,103) AS [Fecha Venc.],dbo.Fnc_Formatear(csaldofacturasi) AS [Saldo Doc.],dbo.Fnc_Formatear(por_vencer_si) AS [Por Vencer],dbo.Fnc_Formatear(hasta15_si) AS [Hasta 15],dbo.Fnc_Formatear(hasta30_si) AS [De 16 a 30],dbo.Fnc_Formatear(hasta45_si) AS [De 31 a 45],dbo.Fnc_Formatear(hastamas45_si) AS [Mas de 45],dias_vence AS [Días Vencid.] FROM TSALDOCARTERAHISTORICO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0 AND CMES='" + _Str_Mes + "' AND CANO='" + _Str_Ano + "'";
                    }
                    else if (_Rbt_Actual.Checked)
                    {
                        _Str_Sql = "SELECT cvendedor AS Vendedor,REPLACE(vendedor_descrip,LTRIM(RTRIM(cvendedor))+'-','') AS Nombre,ccliente AS Cliente,c_nomb_comer AS Descripción,tipodoc_complet AS [Tipo Documento],cnumdocu AS Documento,CONVERT(VARCHAR,cfechafact,103) AS [Fecha Doc.],CASE WHEN (tipodoc_complet = 'N/C./APLICAR') AND  (cfechaentrega IS NULL) THEN CONVERT(VARCHAR,ISNULL(cfechaentrega,cfechafact),103) ELSE  CONVERT(VARCHAR,cfechaentrega,103) END  AS [Fecha Entrega],CONVERT(VARCHAR,cfelimitcobro,103) AS [Fecha Venc.],dbo.Fnc_Formatear(csaldofacturasi) AS [Saldo Doc.],dbo.Fnc_Formatear(por_vencer_si) AS [Por Vencer],dbo.Fnc_Formatear(hasta15_si) AS [Hasta 15],dbo.Fnc_Formatear(hasta30_si) AS [De 16 a 30],dbo.Fnc_Formatear(hasta45_si) AS [De 31 a 45],dbo.Fnc_Formatear(hastamas45_si) AS [Mas de 45],dias_vence AS [Días Vencid.] FROM VST_SALDOS_ALLDOCS_DEMO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0";
                    }
                    else
                    {
                        _Str_Sql = "SELECT cvendedor AS Vendedor,REPLACE(vendedor_descrip,LTRIM(RTRIM(cvendedor))+'-','') AS Nombre,ccliente AS Cliente,c_nomb_comer AS Descripción,tipodoc_complet AS [Tipo Documento],cnumdocu AS Documento,CONVERT(VARCHAR,cfechafact,103) AS [Fecha Doc.],CASE WHEN (tipodoc_complet = 'N/C./APLICAR') AND  (cfechaentrega IS NULL) THEN CONVERT(VARCHAR,ISNULL(cfechaentrega,cfechafact),103) ELSE  CONVERT(VARCHAR,cfechaentrega,103) END  AS [Fecha Entrega],CONVERT(VARCHAR,cfelimitcobro,103) AS [Fecha Venc.],dbo.Fnc_Formatear(csaldofacturasi) AS [Saldo Doc.],dbo.Fnc_Formatear(por_vencer_si) AS [Por Vencer],dbo.Fnc_Formatear(hasta15_si) AS [Hasta 15],dbo.Fnc_Formatear(hasta30_si) AS [De 16 a 30],dbo.Fnc_Formatear(hasta45_si) AS [De 31 a 45],dbo.Fnc_Formatear(hastamas45_si) AS [Mas de 45],dias_vence AS [Días Vencid.] FROM TSALDOCARTERAHISTORICOCAJA WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0 AND CCAJA='" + _Txt_Caja.Text + "'";
                    }
                    if (_Rb_EscalaCredito.Checked && _Cb_EscalaCredito.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ccodlimite='" + _Cb_EscalaCredito.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_TpoDoc.Checked && _Cb_TpoDoc.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ctipodocument='" + _Cb_TpoDoc.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_TpoDoc.Checked && _Cb_TpoDoc.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ctipodocument='" + _Cb_TpoDoc.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_Vendedor.Checked && _Cb_ZonaVendedor.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND cvendedor='" + _Cb_ZonaVendedor.SelectedValue.ToString() + "'";
                    }
                    _Str_Sql += " ORDER BY cvendedor "; //Ordenacion
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            if (_Sfd_1.ShowDialog() == DialogResult.OK)
                            {
                                Cursor = Cursors.WaitCursor;
                                _Ds_Temp = _Ds;
                                Cursor = Cursors.Default;
                                Thread _Thr_Thread = new Thread(new ThreadStart(_Mtd_Consultar));
                                _Thr_Thread.Start();
                                while (!_Thr_Thread.IsAlive) ;
                                Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread, "Espere por favor...");
                                _Frm_Form.ShowDialog(this);
                                _Frm_Form.Dispose();
                            }
                        }
                        catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar exportar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró información.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _Rpv_Main.ReportSource = null;
                    }
                }
            }
            else if (_Rb_Cliente.Checked)
            {
                if (_Chk_Imp.Checked)
                {
                    if (_Rbt_CierreMes.Checked)
                    {
                        string _Str_Mes = "";
                        string _Str_Ano = "";
                        string[] _Str_MesAno = _Cb_MesAnoCierre.SelectedValue.ToString().Split('-');
                        _Str_Mes = _Str_MesAno[1];
                        _Str_Ano = _Str_MesAno[0];
                        _Str_Sql = "SELECT cvendedor AS Vendedor,REPLACE(vendedor_descrip,LTRIM(RTRIM(cvendedor))+'-','') AS Nombre,ccliente AS Cliente,c_nomb_comer AS Descripción,tipodoc_complet AS [Tipo Documento],cnumdocu AS Documento,CONVERT(VARCHAR,cfechafact,103) AS [Fecha Doc.],CASE WHEN (tipodoc_complet = 'N/C./APLICAR') AND  (cfechaentrega IS NULL) THEN CONVERT(VARCHAR,ISNULL(cfechaentrega,cfechafact),103) ELSE  CONVERT(VARCHAR,cfechaentrega,103) END  AS [Fecha Entrega],CONVERT(VARCHAR,cfelimitcobro,103) AS [Fecha Venc.],dbo.Fnc_Formatear(csaldofactura) AS [Saldo Doc.],dbo.Fnc_Formatear(por_vencer) AS [Por Vencer],dbo.Fnc_Formatear(hasta15) AS [Hasta 15],dbo.Fnc_Formatear(hasta30) AS [De 16 a 30],dbo.Fnc_Formatear(hasta45) AS [De 31 a 45],dbo.Fnc_Formatear(hastamas45) AS [Mas de 45],dias_vence AS [Días Vencid.] FROM TSALDOCARTERAHISTORICO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0 AND CMES='" + _Str_Mes + "' AND CANO='" + _Str_Ano + "'";
                    }
                    else if (_Rbt_Actual.Checked)
                    {
                        _Str_Sql = "SELECT cvendedor AS Vendedor,REPLACE(vendedor_descrip,LTRIM(RTRIM(cvendedor))+'-','') AS Nombre,ccliente AS Cliente,c_nomb_comer AS Descripción,tipodoc_complet AS [Tipo Documento],cnumdocu AS Documento,CONVERT(VARCHAR,cfechafact,103) AS [Fecha Doc.],CASE WHEN (tipodoc_complet = 'N/C./APLICAR') AND  (cfechaentrega IS NULL) THEN CONVERT(VARCHAR,ISNULL(cfechaentrega,cfechafact),103) ELSE  CONVERT(VARCHAR,cfechaentrega,103) END  AS [Fecha Entrega],CONVERT(VARCHAR,cfelimitcobro,103) AS [Fecha Venc.],dbo.Fnc_Formatear(csaldofactura) AS [Saldo Doc.],dbo.Fnc_Formatear(por_vencer) AS [Por Vencer],dbo.Fnc_Formatear(hasta15) AS [Hasta 15],dbo.Fnc_Formatear(hasta30) AS [De 16 a 30],dbo.Fnc_Formatear(hasta45) AS [De 31 a 45],dbo.Fnc_Formatear(hastamas45) AS [Mas de 45],dias_vence AS [Días Vencid.] FROM VST_SALDOS_ALLDOCS_DEMO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0";
                    }
                    else
                    {
                        _Str_Sql = "SELECT cvendedor AS Vendedor,REPLACE(vendedor_descrip,LTRIM(RTRIM(cvendedor))+'-','') AS Nombre,ccliente AS Cliente,c_nomb_comer AS Descripción,tipodoc_complet AS [Tipo Documento],cnumdocu AS Documento,CONVERT(VARCHAR,cfechafact,103) AS [Fecha Doc.],CASE WHEN (tipodoc_complet = 'N/C./APLICAR') AND  (cfechaentrega IS NULL) THEN CONVERT(VARCHAR,ISNULL(cfechaentrega,cfechafact),103) ELSE  CONVERT(VARCHAR,cfechaentrega,103) END  AS [Fecha Entrega],CONVERT(VARCHAR,cfelimitcobro,103) AS [Fecha Venc.],dbo.Fnc_Formatear(csaldofactura) AS [Saldo Doc.],dbo.Fnc_Formatear(por_vencer) AS [Por Vencer],dbo.Fnc_Formatear(hasta15) AS [Hasta 15],dbo.Fnc_Formatear(hasta30) AS [De 16 a 30],dbo.Fnc_Formatear(hasta45) AS [De 31 a 45],dbo.Fnc_Formatear(hastamas45) AS [Mas de 45],dias_vence AS [Días Vencid.] FROM TSALDOCARTERAHISTORICOCAJA WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0 AND CCAJA='" + _Txt_Caja.Text + "'";
                    }
                    if (_Rb_EscalaCredito.Checked && _Cb_EscalaCredito.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ccodlimite='" + _Cb_EscalaCredito.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_TpoDoc.Checked && _Cb_TpoDoc.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ctipodocument='" + _Cb_TpoDoc.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_TpoDoc.Checked && _Cb_TpoDoc.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ctipodocument='" + _Cb_TpoDoc.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_Cliente.Checked && _Cb_ZonaVendedor.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ccliente='" + _Cb_ZonaVendedor.SelectedValue.ToString() + "'";
                    }

                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            if (_Sfd_1.ShowDialog() == DialogResult.OK)
                            {
                                Cursor = Cursors.WaitCursor;
                                _Ds_Temp = _Ds;
                                Cursor = Cursors.Default;
                                Thread _Thr_Thread = new Thread(new ThreadStart(_Mtd_Consultar));
                                _Thr_Thread.Start();
                                while (!_Thr_Thread.IsAlive) ;
                                Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread, "Espere por favor...");
                                _Frm_Form.ShowDialog(this);
                                _Frm_Form.Dispose();
                            }
                        }
                        catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar exportar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró información.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _Rpv_Main.ReportSource = null;
                    }
                }
                else
                {
                    if (_Rbt_CierreMes.Checked)
                    {
                        string _Str_Mes = "";
                        string _Str_Ano = "";
                        string[] _Str_MesAno = _Cb_MesAnoCierre.SelectedValue.ToString().Split('-');
                        _Str_Mes = _Str_MesAno[1];
                        _Str_Ano = _Str_MesAno[0];
                        _Str_Sql = "SELECT cvendedor AS Vendedor,REPLACE(vendedor_descrip,LTRIM(RTRIM(cvendedor))+'-','') AS Nombre,ccliente AS Cliente,c_nomb_comer AS Descripción,tipodoc_complet AS [Tipo Documento],cnumdocu AS Documento,CONVERT(VARCHAR,cfechafact,103) AS [Fecha Doc.],CASE WHEN (tipodoc_complet = 'N/C./APLICAR') AND  (cfechaentrega IS NULL) THEN CONVERT(VARCHAR,ISNULL(cfechaentrega,cfechafact),103) ELSE  CONVERT(VARCHAR,cfechaentrega,103) END  AS [Fecha Entrega],CONVERT(VARCHAR,cfelimitcobro,103) AS [Fecha Venc.],dbo.Fnc_Formatear(csaldofactura) AS [Saldo Doc.],dbo.Fnc_Formatear(por_vencer) AS [Por Vencer],dbo.Fnc_Formatear(hasta15) AS [Hasta 15],dbo.Fnc_Formatear(hasta30) AS [De 16 a 30],dbo.Fnc_Formatear(hasta45) AS [De 31 a 45],dbo.Fnc_Formatear(hastamas45) AS [Mas de 45],dias_vence AS [Días Vencid.] FROM TSALDOCARTERAHISTORICO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0 AND CMES='" + _Str_Mes + "' AND CANO='" + _Str_Ano + "'";
                    }
                    else if (_Rbt_Actual.Checked)
                    {
                        _Str_Sql = "SELECT cvendedor AS Vendedor,REPLACE(vendedor_descrip,LTRIM(RTRIM(cvendedor))+'-','') AS Nombre,ccliente AS Cliente,c_nomb_comer AS Descripción,tipodoc_complet AS [Tipo Documento],cnumdocu AS Documento,CONVERT(VARCHAR,cfechafact,103) AS [Fecha Doc.],CASE WHEN (tipodoc_complet = 'N/C./APLICAR') AND  (cfechaentrega IS NULL) THEN CONVERT(VARCHAR,ISNULL(cfechaentrega,cfechafact),103) ELSE  CONVERT(VARCHAR,cfechaentrega,103) END  AS [Fecha Entrega],CONVERT(VARCHAR,cfelimitcobro,103) AS [Fecha Venc.],dbo.Fnc_Formatear(csaldofactura) AS [Saldo Doc.],dbo.Fnc_Formatear(por_vencer) AS [Por Vencer],dbo.Fnc_Formatear(hasta15) AS [Hasta 15],dbo.Fnc_Formatear(hasta30) AS [De 16 a 30],dbo.Fnc_Formatear(hasta45) AS [De 31 a 45],dbo.Fnc_Formatear(hastamas45) AS [Mas de 45],dias_vence AS [Días Vencid.] FROM VST_SALDOS_ALLDOCS_DEMO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0";
                    }
                    else
                    {
                        _Str_Sql = "SELECT cvendedor AS Vendedor,REPLACE(vendedor_descrip,LTRIM(RTRIM(cvendedor))+'-','') AS Nombre,ccliente AS Cliente,c_nomb_comer AS Descripción,tipodoc_complet AS [Tipo Documento],cnumdocu AS Documento,CONVERT(VARCHAR,cfechafact,103) AS [Fecha Doc.],CASE WHEN (tipodoc_complet = 'N/C./APLICAR') AND  (cfechaentrega IS NULL) THEN CONVERT(VARCHAR,ISNULL(cfechaentrega,cfechafact),103) ELSE  CONVERT(VARCHAR,cfechaentrega,103) END  AS [Fecha Entrega],CONVERT(VARCHAR,cfelimitcobro,103) AS [Fecha Venc.],dbo.Fnc_Formatear(csaldofactura) AS [Saldo Doc.],dbo.Fnc_Formatear(por_vencer) AS [Por Vencer],dbo.Fnc_Formatear(hasta15) AS [Hasta 15],dbo.Fnc_Formatear(hasta30) AS [De 16 a 30],dbo.Fnc_Formatear(hasta45) AS [De 31 a 45],dbo.Fnc_Formatear(hastamas45) AS [Mas de 45],dias_vence AS [Días Vencid.] FROM TSALDOCARTERAHISTORICOCAJA WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0 AND CCAJA='" + _Txt_Caja.Text + "'";
                    }
                    if (_Rb_EscalaCredito.Checked && _Cb_EscalaCredito.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ccodlimite='" + _Cb_EscalaCredito.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_TpoDoc.Checked && _Cb_TpoDoc.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ctipodocument='" + _Cb_TpoDoc.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_TpoDoc.Checked && _Cb_TpoDoc.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ctipodocument='" + _Cb_TpoDoc.SelectedValue.ToString() + "'";
                    }
                    if (_Rb_Cliente.Checked && _Cb_ZonaVendedor.SelectedIndex > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND ccliente='" + _Cb_ZonaVendedor.SelectedValue.ToString() + "'";
                    }
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            if (_Sfd_1.ShowDialog() == DialogResult.OK)
                            {
                                Cursor = Cursors.WaitCursor;
                                _Ds_Temp = _Ds;
                                Cursor = Cursors.Default;
                                Thread _Thr_Thread = new Thread(new ThreadStart(_Mtd_Consultar));
                                _Thr_Thread.Start();
                                while (!_Thr_Thread.IsAlive) ;
                                Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread, "Espere por favor...");
                                _Frm_Form.ShowDialog(this);
                                _Frm_Form.Dispose();
                            }
                        }
                        catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar exportar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró información.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _Rpv_Main.ReportSource = null;
                    }
                }
            }
        }

        private void _Mtd_BusquedaPorCierreExport()
        {
            string _Str_Vendedor = "0";
            string _Str_Cliente = "0";
            string _Str_CodLimit = "0";
            string _Str_TipoDoc = "0";
            //-----------------------------------------------------------------------
            if (_Rb_Vendedor.Checked && _Cb_ZonaVendedor.SelectedIndex > 0)
            { _Str_Vendedor = _Cb_ZonaVendedor.SelectedValue.ToString().Trim(); }
            else if (_Rb_Cliente.Checked && _Cb_ZonaVendedor.SelectedIndex > 0)
            { _Str_Cliente = _Cb_ZonaVendedor.SelectedValue.ToString().Trim(); }
            //--------------
            if (_Rb_EscalaCredito.Checked && _Cb_EscalaCredito.SelectedIndex > 0)
            { _Str_CodLimit = _Cb_EscalaCredito.SelectedValue.ToString().Trim(); }
            else if (_Rb_TpoDoc.Checked && _Cb_TpoDoc.SelectedIndex > 0)
            { _Str_TipoDoc = _Cb_TpoDoc.SelectedValue.ToString(); }
            //-----------------------------------------------------------------------
            string _Str_Sql = "EXEC PA_ANALISISSALDOPORCAJA '" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Txt_Caja.Text.Trim() + "','" + _Txt_Caja.Tag + "','" + _Str_Vendedor + "','" + _Str_Cliente + "','" + _Str_CodLimit + "','" + _Str_TipoDoc + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Ds.Tables[0].TableName = "VST_SALDOS_ALLDOCS_DEMO";
            //------
            List<string> _ListaColumnas = new List<string>();
            _ListaColumnas.Add("cvendedor");
            _ListaColumnas.Add("vendedor_descrip");
            _ListaColumnas.Add("ccliente");
            _ListaColumnas.Add("c_nomb_comer");
            _ListaColumnas.Add("tipodoc_complet");
            _ListaColumnas.Add("cnumdocu");
            _ListaColumnas.Add("cfechafact");
            _ListaColumnas.Add("cfechaentrega");
            _ListaColumnas.Add("cfelimitcobro");
            _ListaColumnas.Add("csaldofactura");
            _ListaColumnas.Add("por_vencer");
            _ListaColumnas.Add("hasta15");
            _ListaColumnas.Add("hasta30");
            _ListaColumnas.Add("hasta45");
            _ListaColumnas.Add("hastamas45");
            _ListaColumnas.Add("dias_vence");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                //------
                _Ds.Tables[0].Columns.Cast<DataColumn>().ToList().ForEach(_Dg_Column =>
                {
                    if (!_ListaColumnas.Exists(x => x == _Dg_Column.ColumnName))
                    {
                        _Ds.Tables[0].Columns.Remove(_Dg_Column);
                    }
                    else
                    {
                        if (_Dg_Column.ColumnName == "cvendedor")
                        {
                            _Dg_Column.ColumnName = "Vendedor";
                        }
                        else if (_Dg_Column.ColumnName == "vendedor_descrip")
                        {
                            _Ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(x => {
                                x["vendedor_descrip"] = x["vendedor_descrip"].ToString().Trim().Replace(x["Vendedor"].ToString().Trim() + "-", "");
                            });
                            _Dg_Column.ColumnName = "Nombre";
                        }
                        else if (_Dg_Column.ColumnName == "ccliente")
                        {
                            _Dg_Column.ColumnName = "Cliente";
                        }
                        else if (_Dg_Column.ColumnName == "c_nomb_comer")
                        {
                            _Dg_Column.ColumnName = "Descripción";
                        }
                        else if (_Dg_Column.ColumnName == "tipodoc_complet")
                        {
                            _Dg_Column.ColumnName = "Tipo Documento";
                        }
                        else if (_Dg_Column.ColumnName == "cnumdocu")
                        {
                            _Dg_Column.ColumnName = "Documento";
                        }
                        else if (_Dg_Column.ColumnName == "cfechafact")
                        {
                            _Ds.Tables[0].Rows.Cast<DataRow>().Where(x => x["cfechafact"] != System.DBNull.Value).ToList().ForEach(x =>
                            {
                                x["cfechafact"] = Convert.ToDateTime(x["cfechafact"]).ToString("dd/MM/yyyy");
                            });
                            _Dg_Column.ColumnName = "Fecha Doc.";
                        }
                        else if (_Dg_Column.ColumnName == "cfechaentrega")
                        {
                            _Ds.Tables[0].Rows.Cast<DataRow>().Where(x => x["cfechaentrega"] != System.DBNull.Value).ToList().ForEach(x =>
                            {
                                x["cfechaentrega"] = Convert.ToDateTime(x["cfechaentrega"]).ToString("dd/MM/yyyy");
                            });
                            _Dg_Column.ColumnName = "Fecha Entrega";
                        }
                        else if (_Dg_Column.ColumnName == "cfelimitcobro")
                        {
                            _Ds.Tables[0].Rows.Cast<DataRow>().Where(x => x["cfelimitcobro"] != System.DBNull.Value).ToList().ForEach(x =>
                            {
                                x["cfelimitcobro"] = Convert.ToDateTime(x["cfelimitcobro"]).ToString("dd/MM/yyyy");
                            });
                            _Dg_Column.ColumnName = "Fecha Venc.";
                        }
                        else if (_Dg_Column.ColumnName == "csaldofactura")
                        {
                            _Ds.Tables[0].Rows.Cast<DataRow>().Where(x => x["csaldofactura"] != System.DBNull.Value).ToList().ForEach(x =>
                            {
                                x["csaldofactura"] = Convert.ToDouble(x["csaldofactura"]).ToString("#,##0.00");
                            });
                            _Dg_Column.ColumnName = "Saldo Doc.";
                        }
                        else if (_Dg_Column.ColumnName == "por_vencer")
                        {
                            _Ds.Tables[0].Rows.Cast<DataRow>().Where(x => x["por_vencer"] != System.DBNull.Value).ToList().ForEach(x =>
                            {
                                x["por_vencer"] = Convert.ToDouble(x["por_vencer"]).ToString("#,##0.00");
                            });
                            _Dg_Column.ColumnName = "Por Vencer";
                        }
                        else if (_Dg_Column.ColumnName == "hasta15")
                        {
                            _Ds.Tables[0].Rows.Cast<DataRow>().Where(x => x["hasta15"] != System.DBNull.Value).ToList().ForEach(x =>
                            {
                                x["hasta15"] = Convert.ToDouble(x["hasta15"]).ToString("#,##0.00");
                            });
                            _Dg_Column.ColumnName = "Hasta 15";
                        }
                        else if (_Dg_Column.ColumnName == "hasta30")
                        {
                            _Ds.Tables[0].Rows.Cast<DataRow>().Where(x => x["hasta30"] != System.DBNull.Value).ToList().ForEach(x =>
                            {
                                x["hasta30"] = Convert.ToDouble(x["hasta30"]).ToString("#,##0.00");
                            });
                            _Dg_Column.ColumnName = "De 16 a 30";
                        }
                        else if (_Dg_Column.ColumnName == "hastamas45")
                        {
                            _Ds.Tables[0].Rows.Cast<DataRow>().Where(x => x["hastamas45"] != System.DBNull.Value).ToList().ForEach(x =>
                            {
                                x["hastamas45"] = Convert.ToDouble(x["hastamas45"]).ToString("#,##0.00");
                            });
                            _Dg_Column.ColumnName = "Mas de 45";
                        }
                        else if (_Dg_Column.ColumnName == "dias_vence")
                        {
                            _Dg_Column.ColumnName = "Días Vencid.";
                        }
                    }
                });
                //------
                try
                {
                    if (_Sfd_1.ShowDialog() == DialogResult.OK)
                    {
                        Cursor = Cursors.WaitCursor;
                        _Ds_Temp = _Ds;
                        Cursor = Cursors.Default;
                        Thread _Thr_Thread = new Thread(new ThreadStart(_Mtd_Consultar));
                        _Thr_Thread.Start();
                        while (!_Thr_Thread.IsAlive) ;
                        Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread, "Espere por favor...");
                        _Frm_Form.ShowDialog(this);
                        _Frm_Form.Dispose();
                    }
                }
                catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar exportar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else
            {
                MessageBox.Show("No se encontró información.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _Rpv_Main.ReportSource = null;
            }
        }

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (_Rbt_CierreMes.Checked)
            {
                if (_Cb_MesAnoCierre.Items.Count == 0)
                {
                    MessageBox.Show("Disculpe no existe cierres mensuales registrados en la base de datos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (_Cb_MesAnoCierre.SelectedValue != null)
                    {
                        if (_Cb_MesAnoCierre.SelectedIndex > 0)
                        {
                            _Mtd_Busqueda();
                        }
                        else
                        {
                            MessageBox.Show("Disculpe debe seleccionar el mes y el año para la búsqueda por cierre mensual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Disculpe debe seleccionar el mes y el año para la búsqueda por cierre mensual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                if (_Rbt_Cierres.Checked)
                {
                    _Er_Error.Dispose();
                    if (_Txt_Caja.Text.Trim().Length > 0)
                    {
                        string _Str_SentenciaSQL = "SELECT TOP 1 CCAJA FROM TSALDOCARTERAHISTORICOCAJA WHERE CGROUPCOMP='" + Frm_Padre._Str_GroupComp + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CCAJA='" + _Txt_Caja.Text + "'";
                        DataSet _Ds_DataSet = new DataSet();
                        _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                        if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                        {
                            _Mtd_Busqueda();
                        }
                        else
                        {
                            _Mtd_BusquedaPorCierre();
                        }
                    }
                    else
                    { _Er_Error.SetError(_Bt_Caja, "Información requerida."); }
                }
                else
                { _Mtd_Busqueda(); }
            }
            this.Cursor = Cursors.Default;
        }
        private void _Rb_Vendedor_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Vendedor.Checked)
            {
                _Cb_ZonaVendedor.Enabled = true;
            }
            _Cb_ZonaVendedor.SelectedIndex = -1;
        }

        private void _Rb_EscalaCredito_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_EscalaCredito.Checked)
            {
                _Cb_EscalaCredito.Enabled = true;
            }
            else
            {
                _Cb_EscalaCredito.SelectedIndex = -1;
                _Cb_EscalaCredito.Enabled = true;
            }
        }

        private void _Rb_TpoDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_TpoDoc.Checked)
            {
                _Cb_TpoDoc.Enabled = true;
            }
            else
            {
                _Cb_TpoDoc.SelectedIndex = -1;
                _Cb_TpoDoc.Enabled = false;
            }
        }

        private void _Rb_SinFiltro_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_SinFiltro.Checked)
            {
                _Cb_EscalaCredito.Enabled = false;
                _Cb_TpoDoc.Enabled = false;
            }
        }

        private void _Rbt_Cierres_CheckedChanged(object sender, EventArgs e)
        {
            _Txt_Caja.Text = "";
            _Txt_Caja.Tag = "";
            _Txt_Caja.Enabled = _Rbt_Cierres.Checked;
            _Bt_Caja.Enabled = _Rbt_Cierres.Checked;
            label5.Visible = true;
            _Txt_Caja.Visible = true;
            _Bt_Caja.Visible = true;
            _Cb_MesAnoCierre.Visible = false;
            label3.Visible = false;
        }
        private string _Mtd_FechaCaja(string _P_Str_Caja)
        {
            string _Str_Cadena = "SELECT cfecha FROM TCAJACXC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidcaja='" + _P_Str_Caja + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    return _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0][0]));
                }
            }
            return _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ());
        }
        private void _Bt_Caja_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(52, _Txt_Caja, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
            if (_Txt_Caja.Text.Trim().Length > 0)
            {
                _Txt_Caja.Tag = _Mtd_FechaCaja(_Txt_Caja.Text.Trim()).Trim();
            }
        }

        private void Frm_Inf_AnalisisSaldo_Load(object sender, EventArgs e)
        {

        }
        private DataSet _Mtd_DataSets()
        {
            string _Str_Cadena = "";
            if (_Chk_Imp.Checked)
            { _Str_Cadena = "SELECT cvendedor AS Vendedor,REPLACE(vendedor_descrip,LTRIM(RTRIM(cvendedor))+'-','') AS Nombre,ccliente AS Cliente,c_nomb_comer AS Descripción,tipodoc_complet AS [Tipo Documento],cnumdocu AS Documento,CONVERT(VARCHAR,cfechafact,103) AS [Fecha Doc.],CONVERT(VARCHAR,cfelimitcobro,103) AS [Fecha Venc.],dbo.Fnc_Formatear(csaldofactura) AS [Saldo Doc.],dbo.Fnc_Formatear(por_vencer) AS [Por Vencer],dbo.Fnc_Formatear(hasta15) AS [Hasta 15],dbo.Fnc_Formatear(hasta30) AS [De 16 a 30],dbo.Fnc_Formatear(hasta45) AS [De 31 a 45],dbo.Fnc_Formatear(hastamas45) AS [Mas de 45],dias_vence AS [Días Vencid.] FROM dbo.VST_SALDOS_ALLDOCS_DEMO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0"; }
            else
            { _Str_Cadena = "SELECT cvendedor AS Vendedor,REPLACE(vendedor_descrip,LTRIM(RTRIM(cvendedor))+'-','') AS Nombre,ccliente AS Cliente,c_nomb_comer AS Descripción,tipodoc_complet AS [Tipo Documento],cnumdocu AS Documento,CONVERT(VARCHAR,cfechafact,103) AS [Fecha Doc.],CONVERT(VARCHAR,cfelimitcobro,103) AS [Fecha Venc.],dbo.Fnc_Formatear(csaldofacturasi) AS [Saldo Doc.],dbo.Fnc_Formatear(por_vencer_si) AS [Por Vencer],dbo.Fnc_Formatear(hasta15_si) AS [Hasta 15],dbo.Fnc_Formatear(hasta30_si) AS [De 16 a 30],dbo.Fnc_Formatear(hasta45_si) AS [De 31 a 45],dbo.Fnc_Formatear(hastamas45_si) AS [Mas de 45],dias_vence AS [Días Vencid.] FROM dbo.VST_SALDOS_ALLDOCS_DEMO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0"; }
            //--------------------
            if (_Rb_EscalaCredito.Checked && _Cb_EscalaCredito.SelectedIndex > 0)
            {
                _Str_Cadena += " AND ccodlimite='" + _Cb_EscalaCredito.SelectedValue.ToString() + "'";
            }
            if (_Rb_TpoDoc.Checked && _Cb_TpoDoc.SelectedIndex > 0)
            {
                _Str_Cadena += " AND ctipodocument='" + _Cb_TpoDoc.SelectedValue.ToString() + "'";
            }
            if (_Rb_TpoDoc.Checked && _Cb_TpoDoc.SelectedIndex > 0)
            {
                _Str_Cadena += " AND ctipodocument='" + _Cb_TpoDoc.SelectedValue.ToString() + "'";
            }
            if (_Rb_Vendedor.Checked)
            {
                if (_Rb_Vendedor.Checked && _Cb_ZonaVendedor.SelectedIndex > 0)
                {
                    _Str_Cadena += " AND cvendedor='" + _Cb_ZonaVendedor.SelectedValue.ToString() + "'";
                }
            }
            else
            {
                if (_Rb_Cliente.Checked && _Cb_ZonaVendedor.SelectedIndex > 0)
                {
                    _Str_Cadena += " AND ccliente='" + _Cb_ZonaVendedor.SelectedValue.ToString() + "'";
                }
            }
            //--------------------
            _Str_Cadena += " ORDER BY cvendedor,ccliente";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
        }
        private void _Mtd_Consultar()
        {
            Clases._Cls_ExcelUtilidades _MyExcel = new T3.Clases._Cls_ExcelUtilidades();
            _MyExcel._Mtd_DatasetToExcel(_Ds_Temp.Tables[0], _Sfd_1.FileName, "ANLSIS_SLD_" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString());
            _MyExcel = null;
        }
        DataSet _Ds_Temp;
        private void _Bt_Exportar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (_Rbt_CierreMes.Checked)
            {
                if (_Cb_MesAnoCierre.Items.Count == 0)
                {
                    MessageBox.Show("Disculpe no existe cierres mensuales registrados en la base de datos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (_Cb_MesAnoCierre.SelectedValue != null)
                    {
                        if (_Cb_MesAnoCierre.SelectedIndex > 0)
                        {
                            _Mtd_BusquedaExport();
                        }
                        else
                        {
                            MessageBox.Show("Disculpe debe seleccionar el mes y el año para la búsqueda por cierre mensual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Disculpe debe seleccionar el mes y el año para la búsqueda por cierre mensual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                if (_Rbt_Cierres.Checked)
                {
                    _Er_Error.Dispose();
                    if (_Txt_Caja.Text.Trim().Length > 0)
                    {
                        string _Str_SentenciaSQL = "SELECT TOP 1 CCAJA FROM TSALDOCARTERAHISTORICOCAJA WHERE CGROUPCOMP='" + Frm_Padre._Str_GroupComp + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CCAJA='" + _Txt_Caja.Text + "'";
                        DataSet _Ds_DataSet = new DataSet();
                        _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                        if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                        {
                            _Mtd_BusquedaExport();
                        }
                        else
                        {
                            _Mtd_BusquedaPorCierreExport();
                        }
                    }
                    else
                    { _Er_Error.SetError(_Bt_Caja, "Información requerida."); }
                }
                else
                { _Mtd_BusquedaExport(); }
            }
            this.Cursor = Cursors.Default;
        }

        private void _Rbt_Actual_CheckedChanged(object sender, EventArgs e)
        {
            _Txt_Caja.Text = "";
            _Txt_Caja.Tag = "";
            _Txt_Caja.Enabled = false;
            _Bt_Caja.Enabled = false;
            label5.Visible = false;
            _Txt_Caja.Visible = false;
            _Bt_Caja.Visible = false;

            _Cb_MesAnoCierre.Visible = false;
            label3.Visible = false;
        }

        private void _Rbt_CierreMes_CheckedChanged(object sender, EventArgs e)
        {
            _Txt_Caja.Text = "";
            _Txt_Caja.Tag = "";
            _Txt_Caja.Enabled = false;
            _Bt_Caja.Enabled = false;
            label5.Visible = false;
            _Txt_Caja.Visible = false;
            _Bt_Caja.Visible = false;
            _Cb_MesAnoCierre.Visible = true;
            label3.Visible = true;            
        }

        private void _Cb_MesAnoCierre_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_MesAnoCierreContable();
            this.Cursor = Cursors.Default;
        }
    }
}