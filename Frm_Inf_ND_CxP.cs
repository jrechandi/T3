using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Microsoft.Reporting.WinForms;
namespace T3
{
    public partial class Frm_Inf_ND_CxP : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);

        #region Métodos para mostrar las notas de débito de proveedores.

        /// <summary>Si es verdadero al púlsar el botón de consultar mostar el reporte de notas de débito de proveedores.</summary>
        private bool bMostrarNDP;

        /// <summary>Mètodo que llama el reporte de notas de débito de proveedores.</summary>
        private void mostrarNotasDebitoProveedores()
        {
            oVisor.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);

            ReportParameter[] oParametros = new ReportParameter[6];

            oParametros[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            oParametros[1] = new ReportParameter("CPROVEEDOR", (_Cb_ProveedorFind.SelectedValue.ToString() != "nulo") ? _Cb_ProveedorFind.SelectedValue.ToString().Trim() : "");
            oParametros[2] = new ReportParameter("CFECHADESDE", _Cls_Formato._Mtd_fecha(_Dt_Desde.Value));
            oParametros[3] = new ReportParameter("CFECHAHASTA", _Cls_Formato._Mtd_fecha(_Dt_Hasta.Value));
            oParametros[4] = new ReportParameter("CCATPROVEEDOR", (_Cb_CatProveFind.SelectedValue.ToString() != "nulo") ? _Cb_CatProveFind.SelectedValue.ToString().Trim() : "");
            oParametros[5] = new ReportParameter("CGLOBAL", (_Cb_TpoProveFind.SelectedValue.ToString() != "nulo") ? _Cb_TpoProveFind.SelectedValue.ToString().Trim() : "");

            oVisor.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            oVisor.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_CxP_NDP";
            oVisor.ServerReport.SetParameters(oParametros);
            oVisor.ServerReport.Refresh();
            oVisor.RefreshReport();
        }

        #endregion

        public Frm_Inf_ND_CxP(bool pMostrarNDP = false)
        {
            InitializeComponent();

            _Mtd_CargarTipoProv();
            _Mtd_CargarCategProv();
            _Mtd_CargarProvee();

            bMostrarNDP = pMostrarNDP;

            if (pMostrarNDP)
                this.Text = "Reporte de notas de débito del proveedor";
            else
                this.Text = "Reporte de notas de débito al proveedor";
        }

        private void _Mtd_CargarTipoProv()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cb_TpoProveFind.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("SERVICIO", "0"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("MATERIA PRIMA", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("OTROS", "2"));
            _Cb_TpoProveFind.DataSource = _myArrayList;
            _Cb_TpoProveFind.DisplayMember = "Display";
            _Cb_TpoProveFind.ValueMember = "Value";
            _Cb_TpoProveFind.SelectedValue = "nulo";
            _Cb_TpoProveFind.DataSource = _myArrayList;
            _Cb_TpoProveFind.SelectedIndex = 0;
        }
        private void _Mtd_CargarCategProv()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT ccatproveedor,UPPER(cnombre) AS Nombre FROM TCATPROVEEDOR WHERE cdelete='0'";
            if (_Cb_TpoProveFind.SelectedIndex > 0)
            { _Str_Cadena += " AND cglobal='" + _Cb_TpoProveFind.SelectedValue.ToString().Trim() + "'"; }
            _Str_Cadena += " ORDER BY Nombre";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cb_CatProveFind, _Str_Cadena);
            Cursor = Cursors.Default;
        }
        private void _Mtd_CargarProvee()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1'";
            if (_Cb_TpoProveFind.SelectedIndex > 0)
            {
                if (_Cb_TpoProveFind.SelectedValue.ToString().Trim() == "0" | _Cb_TpoProveFind.SelectedValue.ToString().Trim() == "2")
                { _Str_Cadena += " AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "' AND TPROVEEDOR.cglobal='" + _Cb_TpoProveFind.SelectedValue.ToString().Trim() + "'"; }
                else
                { _Str_Cadena += " AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "' AND cglobal='" + _Cb_TpoProveFind.SelectedValue.ToString().Trim() + "'"; }
            }
            else
            { _Str_Cadena += " AND ((TGRUPPROVEE.CCOMPANY='" + Frm_Padre._Str_Comp + "' AND TPROVEEDOR.cglobal='1') OR (TPROVEEDOR.cglobal<>'1' AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "'))"; }
            //-----------
            if (_Cb_CatProveFind.SelectedIndex > 0)
            { _Str_Cadena += " AND TPROVEEDOR.ccatproveedor='" + _Cb_CatProveFind.SelectedValue.ToString().Trim() + "'"; }
            //_Str_Cadena += " ORDER BY TPROVEEDOR.c_nomb_abreviado";

            //Union PQseada para que salgan los proveedores no activos
            _Str_Cadena += " UNION ";
            _Str_Cadena += " SELECT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado ";
            _Str_Cadena += " FROM TPROVEEDOR INNER JOIN ";
            _Str_Cadena += " TPROVEEDORHISTORICO ON TPROVEEDOR.cproveedor = TPROVEEDORHISTORICO.cproveedor AND TPROVEEDOR.c_rif = TPROVEEDORHISTORICO.c_rif ";
            _Str_Cadena += " WHERE ";
            _Str_Cadena += " TPROVEEDORHISTORICO.ccompany='" + Frm_Padre._Str_Comp + "' ";
            _Str_Cadena += " ORDER BY TPROVEEDOR.c_nomb_abreviado";
            
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cb_ProveedorFind, _Str_Cadena);
            Cursor = Cursors.Default;
        }
        private void _Mtd_CargarCatProveFind(string _P_Str_Tipo)
        {
            _Cb_CatProveFind.SelectedIndexChanged -= new EventHandler(_Cb_CatProveFind_SelectedIndexChanged);
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cb_CatProveFind, "Select ccatproveedor,UPPER(cnombre) AS cnombre from TCATPROVEEDOR where cdelete='0' and cglobal='" + _P_Str_Tipo + "' ORDER BY cnombre");
            _Cb_CatProveFind.SelectedIndexChanged += new EventHandler(_Cb_CatProveFind_SelectedIndexChanged);
        }

        private void Frm_Inf_ND_CxP_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Dt_Desde.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dt_Desde.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dt_Hasta.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
        }

        private void _Cb_TpoProveFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_CargarCategProv();
            _Mtd_CargarProvee();
        }

        private void _Cb_CatProveFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_CargarProvee();
        }

        private void _Lkbl_Hoy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Dt_Desde.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dt_Desde.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dt_Hasta.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
        }

        private void _Lkbl_Ayer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Dt_Desde.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().AddDays(-1);
            _Dt_Desde.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().AddDays(-1);
            _Dt_Hasta.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().AddDays(-1);
        }

        private void _Dt_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dt_Desde.MaxDate = _Dt_Hasta.Value;
        }

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (bMostrarNDP)
            {
                mostrarNotasDebitoProveedores();
                Cursor = Cursors.Default;
                return;
            }

            string _Str_Sql = "", _Str_Filtro = "";
            if (_Rb_NoImpresa.Checked)
            {
                _Str_Filtro = _Str_Filtro + " cimpresa=0";
            }
            else if (_Rb_Impresa.Checked)
            {
                _Str_Filtro = _Str_Filtro + " cimpresa=1";
            }
            _Str_Filtro = _Str_Filtro + " AND canulado=0";
            if (_Cb_TpoProveFind.SelectedIndex > 0)
            { _Str_Filtro += " AND cglobal=" + Convert.ToString(_Cb_TpoProveFind.SelectedValue).Trim(); }
            //---
            if (_Cb_CatProveFind.SelectedIndex > 0)
            { _Str_Filtro += " AND ccatproveedor='" + Convert.ToString(_Cb_CatProveFind.SelectedValue).Trim() + "'"; }
            //---
            if (_Cb_ProveedorFind.SelectedIndex > 0)
            { _Str_Filtro += " AND cproveedor='" + Convert.ToString(_Cb_ProveedorFind.SelectedValue).Trim() + "'"; }
            _Str_Filtro = _Str_Filtro + " AND convert(datetime,convert(varchar(255),cfechand,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dt_Desde.Value) + "' AND '" + _Cls_Formato._Mtd_fecha(_Dt_Hasta.Value) + "'";
            _Str_Sql = "SELECT * FROM VST_TNOTADEBITOCP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND " + _Str_Filtro;
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                Report.rInfNDcxp _My_Reporte = new T3.Report.rInfNDcxp();
                _My_Reporte.SetDataSource(_Ds.Tables[0]);

                Section _sec = _My_Reporte.ReportDefinition.Sections["Section2"];
                TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                DataSet dsResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT crif, rtrim(cname) as cname FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                tex1.Text = (dsResultado.Tables[0].Rows[0]["cname"].ToString() + "\r\n" + dsResultado.Tables[0].Rows[0]["crif"].ToString());

                TextObject tex2 = _sec.ReportObjects["Txt_Rango"] as TextObject;
                tex2.Text = "Del: " + _Cls_Formato._Mtd_fecha(_Dt_Desde.Value.Date) + " al " + _Cls_Formato._Mtd_fecha(_Dt_Hasta.Value.Date);

                this._Rpv_Main.ReportSource = _My_Reporte;
                _Rpv_Main.RefreshReport();
            }
            else
            {
                this._Rpv_Main.ReportSource = null;
                MessageBox.Show("No existen ND.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            //string _Str_Sql = "", _Str_Filtro = "";
            //if (_Rb_NoImpresa.Checked)
            //{
            //    _Str_Filtro = _Str_Filtro + " cimpresa=0";
            //}
            //else if (_Rb_Impresa.Checked)
            //{
            //    _Str_Filtro = _Str_Filtro + " cimpresa=1";
            //}
            //_Str_Filtro = _Str_Filtro + " AND canulado=0";
            //if (_Cb_ProveedorFind.SelectedIndex > 0)
            //{ _Str_Filtro = _Str_Filtro + " AND cproveedor='" + Convert.ToString(_Cb_ProveedorFind.SelectedValue) + "'"; }
            //if (_Cb_TpoProveFind.SelectedIndex > 0)
            //{
            //    _Str_Filtro = _Str_Filtro + " AND cglobal=" + Convert.ToString(_Cb_TpoProveFind.SelectedValue);
            //    if (_Cb_TpoProveFind.SelectedValue.ToString() != "1")
            //    {
            //        _Str_Filtro = _Str_Filtro + " AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
            //    }
            //}
            //if (_Cb_CatProveFind.SelectedIndex > 0)
            //{
            //    if (_Cb_CatProveFind.SelectedIndex > 0)
            //    { _Str_Filtro = _Str_Filtro + " AND ccatproveedor='" + Convert.ToString(_Cb_CatProveFind.SelectedValue) + "'"; }
            //}
            //_Str_Filtro = _Str_Filtro + " AND convert(datetime,convert(varchar(255),cfechand,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dt_Desde.Value) + "' AND '" + _Cls_Formato._Mtd_fecha(_Dt_Hasta.Value) + "'";
            //_Str_Sql = "SELECT * FROM VST_TNOTADEBITOCP_DEMO WHERE" + _Str_Filtro;
            //DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //if (_Ds.Tables[0].Rows.Count > 0)
            //{
            //    Report.rInfNDcxp_demo _My_Reporte = new T3.Report.rInfNDcxp_demo();
            //    _My_Reporte.SetDataSource(_Ds.Tables[0]);
            //    Section _sec = _My_Reporte.ReportDefinition.Sections["Section2"];
            //    TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
            //    tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();

            //    TextObject tex2 = _sec.ReportObjects["Txt_Rango"] as TextObject;
            //    tex2.Text = "Del: " + _Cls_Formato._Mtd_fecha(_Dt_Desde.Value.Date) + " al " + _Cls_Formato._Mtd_fecha(_Dt_Hasta.Value.Date);

            //    this._Rpv_Main.ReportSource = _My_Reporte;
            //    _Rpv_Main.RefreshReport();
            //}
            //else
            //{
            //    this._Rpv_Main.ReportSource = null;
            //    MessageBox.Show("No existen ND.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //this.Cursor = Cursors.Default;
        }

        private void _Cb_CatProveFind_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarCategProv();
        }

        private void _Cb_ProveedorFind_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarProvee();
        }
    }
}