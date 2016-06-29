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
    public partial class Frm_Inf_InvCompromPreFact : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_InvCompromPreFact()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_InvCompromPreFac";
            _Mtd_CargarVendedores();
            _Mtd_Color_Estandar(this);
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

        private void _Mtd_CargarVendedores()
        {
            string _Str_Sql = "SELECT cvendedor,cvendedor+'-'+cname from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' AND c_activo='1' ORDER BY CAST(REPLACE(cvendedor,LTRIM(RTRIM(ccompany))+'_','') AS INTEGER)";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cb_Vendedor, _Str_Sql, true);
        }

        private void _Mtd_Consultar()
        {
            Cursor = Cursors.WaitCursor;
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] _Rpt_Parm = new ReportParameter[10];
            _Rpt_Parm[0] = new ReportParameter("CNOMPEMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            _Rpt_Parm[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            _Rpt_Parm[2] = new ReportParameter("CVENDEDOR", _Cb_Vendedor.SelectedIndex > 0 ? _Cb_Vendedor.SelectedValue.ToString().Trim() : "nulo");
            _Rpt_Parm[3] = new ReportParameter("CPROVEEDOR", !string.IsNullOrEmpty(Convert.ToString(_Txt_Proveedor.Tag)) ? _Txt_Proveedor.Tag.ToString().Trim() : "nulo");
            _Rpt_Parm[4] = new ReportParameter("CPRODUCTO", _Txt_Producto.Text.Trim());
            _Rpt_Parm[5] = new ReportParameter("CPEDIDO", !string.IsNullOrEmpty(Convert.ToString(_Txt_Pedido.Text)) ? _Txt_Pedido.Text : "0");
            _Rpt_Parm[6] = new ReportParameter("CFECHAI", _Ctrl_ConsultaMes1._Str_FechaInicio);
            _Rpt_Parm[7] = new ReportParameter("CFECHAF", _Ctrl_ConsultaMes1._Str_FechaFinal);
            _Rpt_Parm[8] = new ReportParameter("CTODAS", Convert.ToInt32(_Chk_Todas.Checked).ToString());
            _Rpt_Parm[9] = new ReportParameter("CRANGO", _Chk_Todas.Checked ? "Todas las Fechas" : "Desde " + _Ctrl_ConsultaMes1._Str_FechaInicio + " Hasta " + _Ctrl_ConsultaMes1._Str_FechaFinal);
            _Rpt_Report.ServerReport.SetParameters(_Rpt_Parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
            Cursor = Cursors.Default;
        }

        private void _Mtd_LimpiarFiltro()
        {
            _Chk_Todas.Checked = true;
            _Mtd_CargarVendedores();
            _Txt_Proveedor.Tag = "";
            _Txt_Proveedor.Text = "";
            _Txt_Producto.Text = "";
            _Txt_Pedido.Text = "";
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            _Mtd_Consultar();
        }

        private void _Cmb_Vendedor_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarVendedores();
        }

        private void _Txt_Pedido_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_Pedido.Text)) { _Txt_Pedido.Text = ""; }
        }

        private void _Txt_Pedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Pedido, e, 8, 0);
        }

        private void _Cb_Vendedor_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarVendedores();
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

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            if (_Chk_Todas.Checked || _Ctrl_ConsultaMes1._Bol_Listo)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Consultar();
                Cursor = Cursors.Default;
            }
            else
            { MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void Frm_Inf_InvCompromPreFact_Load(object sender, EventArgs e)
        {
            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();
            _Mtd_LimpiarFiltro();
        }

        private void _Bt_Limpiar_Click(object sender, EventArgs e)
        {
            _Mtd_LimpiarFiltro();
        }

        private void _Chk_Todas_CheckedChanged(object sender, EventArgs e)
        {
            _Ctrl_ConsultaMes1.Enabled = !_Chk_Todas.Checked;
        }
    }
}