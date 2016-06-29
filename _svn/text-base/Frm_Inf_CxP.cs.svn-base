using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace T3
{
    public partial class Frm_Inf_CxP : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_CxP()
        {
            InitializeComponent();
            //-------------------
            _Mtd_CargarTipoProv();
            _Mtd_CargarCategProv();
            _Mtd_CargarProvee();
            _Mtd_Color_Estandar(this);
            //-------------------
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_CxP";
        }
        private void _Mtd_Color_Estandar(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Color_Estandar(_Ctrl);
                }
                else
                {
                    new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco();
                }
            }
        }
        private void _Mtd_CargarTipoProv()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_TipoProv.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("SERVICIO", "0"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("MATERIA PRIMA", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("OTROS", "2"));
            _Cmb_TipoProv.DataSource = _myArrayList;
            _Cmb_TipoProv.DisplayMember = "Display";
            _Cmb_TipoProv.ValueMember = "Value";
            _Cmb_TipoProv.SelectedValue = "nulo";
            _Cmb_TipoProv.DataSource = _myArrayList;
            _Cmb_TipoProv.SelectedIndex = 0;
        }
        private void _Mtd_CargarCategProv()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT ccatproveedor,UPPER(cnombre) AS Nombre FROM TCATPROVEEDOR WHERE cdelete='0'";
            if (_Cmb_TipoProv.SelectedIndex > 0)
            { _Str_Cadena += " AND cglobal='" + _Cmb_TipoProv.SelectedValue.ToString().Trim() + "'"; }
            _Str_Cadena += " ORDER BY Nombre";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_CategProv, _Str_Cadena);
            Cursor = Cursors.Default;
        }
        private void _Mtd_CargarProvee()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor =TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1'";
            if (_Cmb_TipoProv.SelectedIndex > 0)
            {
                if (_Cmb_TipoProv.SelectedValue.ToString().Trim() == "0" | _Cmb_TipoProv.SelectedValue.ToString().Trim() == "2")
                { _Str_Cadena += " AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "' AND TPROVEEDOR.cglobal='" + _Cmb_TipoProv.SelectedValue.ToString().Trim() + "'"; }
                else
                { _Str_Cadena += " AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "' AND cglobal='" + _Cmb_TipoProv.SelectedValue.ToString().Trim() + "'"; }
            }
            else
            { _Str_Cadena += " AND ((TGRUPPROVEE.CCOMPANY='" + Frm_Padre._Str_Comp + "' AND TPROVEEDOR.cglobal='1') OR (TPROVEEDOR.cglobal<>'1' AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "'))"; }
            //-----------
            if (_Cmb_CategProv.SelectedIndex > 0)
            { _Str_Cadena += " AND TPROVEEDOR.ccatproveedor='" + _Cmb_CategProv.SelectedValue.ToString().Trim() + "'"; }
            //_Str_Cadena += " ORDER BY TPROVEEDOR.c_nomb_abreviado";

            //Union PQseada para que salgan los proveedores no activos
            _Str_Cadena += " UNION ";
            _Str_Cadena += " SELECT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado ";
            _Str_Cadena += " FROM TPROVEEDOR INNER JOIN ";
            _Str_Cadena += " TPROVEEDORHISTORICO ON TPROVEEDOR.cproveedor = TPROVEEDORHISTORICO.cproveedor AND TPROVEEDOR.c_rif = TPROVEEDORHISTORICO.c_rif ";
            _Str_Cadena += " WHERE ";
            _Str_Cadena += " TPROVEEDORHISTORICO.ccompany='" + Frm_Padre._Str_Comp + "' ";
            _Str_Cadena += " ORDER BY TPROVEEDOR.c_nomb_abreviado";
            
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Proveedor, _Str_Cadena);
            Cursor = Cursors.Default;
        }
        private string _Mtd_NombComp()
        {
            string _Str_Cadena = "Select cname from dbo.TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
            }
            return "";
        }
        private void _Mtd_Busqueda(string _P_Str_Filtro, string _P_Str_Tipo, string _P_Str_CatProvee, string _P_Str_Proveedor)
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[7];
            parm[0] = new ReportParameter("CFILTRO", _P_Str_Filtro);
            parm[1] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
            parm[2] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[3] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            parm[4] = new ReportParameter("CGLOBAL", _P_Str_Tipo);
            parm[5] = new ReportParameter("CCATPROVEEDOR", _P_Str_CatProvee);
            parm[6] = new ReportParameter("CPROVEEDOR", _P_Str_Proveedor);
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }
        private void Frm_Inf_CxP_Load(object sender, EventArgs e)
        {

        }

        private void _Cmb_TipoProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_CargarCategProv();
            _Mtd_CargarProvee();
        }

        private void _Cmb_CategProv_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarCategProv();
        }

        private void _Cmb_CategProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_CargarProvee();
        }

        private void _Cmb_Proveedor_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarProvee();
        }

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            string _Str_Tipo = "9";
            string _Str_CatProvee = "nulo";
            string _Str_Proveedor = "nulo";
            string _Str_Filtro = "";
            if (_Cmb_TipoProv.SelectedIndex > 0)
            { _Str_Tipo = Convert.ToString(_Cmb_TipoProv.SelectedValue).Trim(); }
            //---
            if (_Cmb_CategProv.SelectedIndex > 0)
            { _Str_CatProvee = Convert.ToString(_Cmb_CategProv.SelectedValue).Trim(); }
            //---
            if (_Cmb_Proveedor.SelectedIndex > 0)
            { _Str_Proveedor = Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim(); }
            if (_Rb_T.Checked)
            { _Str_Filtro = "TODOS"; }
            else if (_Rb_V.Checked)
            { _Str_Filtro = "VENCIDAS"; }
            else if (_Rb_P.Checked)
            { _Str_Filtro = "POR_VENCER"; }
            else
            { _Str_Filtro = "CANCELADAS"; }
            Cursor = Cursors.WaitCursor;
            _Mtd_Busqueda(_Str_Filtro, _Str_Tipo, _Str_CatProvee, _Str_Proveedor);
            Cursor = Cursors.Default;
        }
    }
}