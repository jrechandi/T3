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
    public partial class Frm_Inf_PreFactResProv : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_PreFactResProv()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_PreFactResProv";
        }

        private void _Mtd_ClienteSegunPedido(string _Str_CodigoPedido, out string _Str_CodigoCliente, out string _Str_NombreCliente)
        {
            string _Str_SQL = "";

            _Str_SQL += "SELECT TCLIENTE.ccliente, TCLIENTE.c_nomb_comer" + " ";
            _Str_SQL += "FROM TCOTPEDFACM INNER JOIN TCLIENTE ON TCOTPEDFACM.ccliente = TCLIENTE.ccliente" + " ";
            _Str_SQL += "WHERE TCOTPEDFACM.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOTPEDFACM.cpedido = " + _Str_CodigoPedido + " ";

            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count != 0)
            {
                _Str_CodigoCliente = _Ds.Tables[0].Rows[0][0].ToString();
                _Str_NombreCliente = _Ds.Tables[0].Rows[0][1].ToString().Trim();
            }
            else
            {
                _Str_CodigoCliente = "";
                _Str_NombreCliente = "";
            }
        }

        private void _Mtd_VendedorSegunPedido(string _Str_CodigoPedido, out string _Str_CodigoVendedor, out string _Str_NombreVendedor)
        {
            string _Str_SQL = "";

            _Str_SQL += "SELECT TVENDEDOR.cvendedor, TVENDEDOR.cname" + " ";
            _Str_SQL += "FROM TVENDEDOR INNER JOIN TCOTPEDFACM ON TVENDEDOR.ccompany = TCOTPEDFACM.ccompany AND TVENDEDOR.cvendedor = TCOTPEDFACM.cvendedor" + " ";
            _Str_SQL += "WHERE TCOTPEDFACM.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOTPEDFACM.cpedido = " + _Str_CodigoPedido + " ";

            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count != 0)
            {
                _Str_CodigoVendedor = _Ds.Tables[0].Rows[0][0].ToString();
                _Str_NombreVendedor = _Ds.Tables[0].Rows[0][1].ToString().Trim();
            }
            else
            {
                _Str_CodigoVendedor = "";
                _Str_NombreVendedor = "";
            }
        }

        private void _Mtd_MostrarReporte()
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[8];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CPEDIDO", !string.IsNullOrEmpty(Convert.ToString(_Txt_Pedido.Text)) ? Convert.ToString(_Txt_Pedido.Text) : "0");
            parm[2] = new ReportParameter("CCLIENTE", !string.IsNullOrEmpty(Convert.ToString(_Txt_Cliente.Tag)) ? Convert.ToString(_Txt_Cliente.Tag) : "0");
            parm[3] = new ReportParameter("CVENDEDOR", !string.IsNullOrEmpty(Convert.ToString(_Txt_Vendedor.Tag)) ? Convert.ToString(_Txt_Vendedor.Tag) : "");
            parm[4] = new ReportParameter("CFECHADESDE", _Ctrl_ConsultaMes1._Str_FechaInicio);
            parm[5] = new ReportParameter("CFECHAHASTA", _Ctrl_ConsultaMes1._Str_FechaFinal);
            parm[6] = new ReportParameter("CNOMBCOMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            parm[7] = new ReportParameter("CENPRECARGA", _Rb_Todas.Checked ? "2" : Convert.ToInt32(_Rb_PreCargadas.Checked).ToString());
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }

        private void Frm_Inf_PreFactResProv_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_Inf_PreFactResProv_Load(object sender, EventArgs e)
        {
            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();
        }

        private void _Bt_Cliente_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(64, _Txt_Cliente, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
        }

        private void _Bt_LimpiarCliente_Click(object sender, EventArgs e)
        {
            _Txt_Cliente.Text = ""; _Txt_Cliente.Tag = "";
        }

        private void _Bt_Vendedor_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(69, _Txt_Vendedor, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
        }

        private void _Bt_LimpiarVendedor_Click(object sender, EventArgs e)
        {
            _Txt_Vendedor.Text = ""; _Txt_Vendedor.Tag = "";
        }

        private void _Bt_LimpiarPedido_Click(object sender, EventArgs e)
        {
            _Txt_Pedido.Text = "";
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            if (!_Ctrl_ConsultaMes1._Bol_Listo)
            {
                MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _Mtd_MostrarReporte();
        }

        private void _Txt_Pedido_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_Pedido.Text)) { _Txt_Pedido.Text = ""; }
        }

        private void _Txt_Pedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Pedido, e, 8, 0);
        }
    }
}