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
    public partial class Frm_Inf_VentasAcumProdvend : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VeriosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_VentasAcumProdvend()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_VentasAcumProdVend";
            _Txt_Proveedor.Tag = "nulo";
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
        private void _Mtd_CargarVendedores()
        {
            if (_Rb_Act.Checked)
            {
                string _Str_Sql = "SELECT cvendedor,cvendedor+'-'+cname from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' AND c_activo='1' ORDER BY CAST(REPLACE(cvendedor,LTRIM(RTRIM(ccompany))+'_','') AS INTEGER)";
                _Cls_VeriosMetodos._Mtd_CargarCombo(_Cb_Vendedor, _Str_Sql,true);
            }
            else
            {
                string _Str_Sql = "SELECT cvendedor,cvendedor+'-'+cname from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' AND c_activo='0' ORDER BY CAST(REPLACE(cvendedor,LTRIM(RTRIM(ccompany))+'_','') AS INTEGER)";
                _Cls_VeriosMetodos._Mtd_CargarCombo(_Cb_Vendedor, _Str_Sql, true);
            }
        }
        private void _Mtd_Busqueda(string _P_Str_Vendedor, string _P_Str_Proveedor)
        {
            if (_P_Str_Vendedor == "nulo")
            {
                _P_Str_Vendedor = "NULL";
            }
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[7];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CNOMBCOMP", _Mtd_NombComp());
            parm[2] = new ReportParameter("CVENDEDOR", _P_Str_Vendedor);
            parm[3] = new ReportParameter("CPROVEEDOR", _P_Str_Proveedor);
            parm[4] = new ReportParameter("CFECHAI", _Ctrl_ConsultaMes1._Str_FechaInicio);
            parm[5] = new ReportParameter("CFECHAF", _Ctrl_ConsultaMes1._Str_FechaFinal);
            if (_P_Str_Proveedor.ToString().Trim() == "nulo")
            { parm[6] = new ReportParameter("CTITULO", "VENTAS ACUMULADAS POR PRODUCTOS Y VENDEDOR (TODOS)"); }
            else
            { parm[6] = new ReportParameter("CTITULO", "VENTAS ACUMULADAS POR PRODUCTOS Y VENDEDOR (UN PROVEEDOR)"); }
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Ctrl_ConsultaMes1._Bol_Listo)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Busqueda(_Cb_Vendedor.SelectedValue.ToString(), _Txt_Proveedor.Tag.ToString().Trim());
                Cursor = Cursors.Default;
            }
            else
            { MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(33);
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
            if (_Frm._Str_FrmResult == "1")
            {
                _Txt_Proveedor.Tag = _Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString().ToUpper();
                _Txt_Proveedor.Text = _Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells[1].Value.ToString().ToUpper();
            }
        }

        private void Frm_Inf_VentasAcumProdvend_Load(object sender, EventArgs e)
        {
            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();
            _Mtd_CargarVendedores();
        }

        private void _Bt_Limpiar_Click(object sender, EventArgs e)
        {
            _Txt_Proveedor.Tag = "nulo";
            _Txt_Proveedor.Text = "";
        }

        private void _Cb_Vendedor_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarVendedores();
        }

        private void _Rb_Act_CheckedChanged(object sender, EventArgs e)
        {
            if (_Cb_Vendedor.DataSource != null) { _Cb_Vendedor.SelectedIndex = 0; }
        }
    }
}