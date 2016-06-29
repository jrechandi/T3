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
    public partial class Frm_Inf_Facturas : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_Facturas()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_FacturasEmitidas";
        }
        private void _Mtd_CargarClientes()
        {
            string _Str_Sql = "SELECT ccliente,CONVERT(VARCHAR,ccliente) + '-' + RTRIM(c_nomb_comer) FROM TCLIENTE WHERE cdelete=0 AND cgroupcomp='"+Frm_Padre._Str_GroupComp+"'";
            _myUtilidad._Mtd_CargarCombo(_Cb_Cliente, _Str_Sql);
        }
        private void _Mtd_CargarVendedores()
        {
            string _Str_Sql = "SELECT cvendedor,RTRIM(cvendedor) + '-' + RTRIM(cname) FROM TVENDEDOR WHERE cdelete=0 AND ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY CONVERT(NUMERIC(18,0),REPLACE(REPLACE(CVENDEDOR,'_',''),RTRIM(CCOMPANY),''))";
            _myUtilidad._Mtd_CargarCombo(_Cb_Vendedor, _Str_Sql);
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
        private void _Mtd_Busqueda(string _P_Str_Vendedor, string _P_Str_Cliente)
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[6];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CVENDEDOR", _P_Str_Vendedor);
            parm[2] = new ReportParameter("CCLIENTE", _P_Str_Cliente);
            parm[3] = new ReportParameter("CFECHAI", _Ctrl_ConsultaMes1._Str_FechaInicio);
            parm[4] = new ReportParameter("CFECHAF", _Ctrl_ConsultaMes1._Str_FechaFinal);
            parm[5] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }

        private void _Rb_Cliente_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Cliente.Checked)
            {
                _Cb_Cliente.Enabled = true;
            }
            else
            {
                _Cb_Cliente.SelectedIndex = -1;
                _Cb_Cliente.Enabled = false;
            }
        }

        private void _Rb_Vendedor_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Vendedor.Checked)
            {
                _Cb_Vendedor.Enabled = true;
            }
            else
            {
                _Cb_Vendedor.SelectedIndex = -1;
                _Cb_Vendedor.Enabled = false;
            }
        }

        private void _Rb_SinFiltro_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_SinFiltro.Checked)
            {
                _Cb_Cliente.SelectedIndex = -1;
                _Cb_Vendedor.SelectedIndex = -1;
                _Cb_Cliente.Enabled = false;
                _Cb_Vendedor.Enabled = false;
            }
        }

        private void _Cb_Cliente_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_CargarClientes();
            this.Cursor = Cursors.Default;
        }

        private void _Cb_Vendedor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_CargarVendedores();
            this.Cursor = Cursors.Default;
        }

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            if (_Ctrl_ConsultaMes1._Bol_Listo)
            {
                this.Cursor = Cursors.WaitCursor;
                _Er_Error.Dispose();
                string _Str_Vendedor = "";
                string _Str_Cliente = "";
                //-------------------------------------------
                if (_Cb_Vendedor.SelectedIndex == -1)
                { _Str_Vendedor = " "; }
                else if (_Cb_Vendedor.SelectedIndex == 0)
                { _Str_Vendedor = " "; }
                else
                { _Str_Vendedor = _Cb_Vendedor.SelectedValue.ToString(); }
                if (_Cb_Cliente.SelectedIndex == -1)
                { _Str_Cliente = "0"; }
                else if (_Cb_Cliente.SelectedIndex == 0)
                { _Str_Cliente = "0"; }
                else
                { _Str_Cliente = _Cb_Cliente.SelectedValue.ToString(); }
                //-------------------------------------------
                if (_Rb_SinFiltro.Checked)
                { _Mtd_Busqueda(_Str_Vendedor, _Str_Cliente); }
                else
                {
                    if (_Cb_Cliente.SelectedIndex > 0 | _Cb_Vendedor.SelectedIndex > 0)
                    {
                        _Mtd_Busqueda(_Str_Vendedor, _Str_Cliente);
                    }
                    else
                    {
                        if (_Rb_Cliente.Checked) { _Er_Error.SetError(_Cb_Cliente, "Información requerida."); }
                        else
                        { _Er_Error.SetError(_Cb_Vendedor, "Información requerida."); }
                    }
                }
                this.Cursor = Cursors.Default;
            }
            else
            { MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void Frm_Inf_Facturas_Load(object sender, EventArgs e)
        {
            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();
        }
    }
}