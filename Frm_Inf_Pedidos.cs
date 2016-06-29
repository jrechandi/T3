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
    public partial class Frm_Inf_Pedidos : Form
    {
        public Frm_Inf_Pedidos()
        {
            InitializeComponent();
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

        private void _Mtd_LimpiarTodo()
        {
            _Txt_Vendedor.Text = ""; _Txt_Vendedor.Tag = "";
            _Txt_Pedido.Text = ""; _Txt_Pedido.Tag = "";
            _Txt_Cliente.Text = ""; _Txt_Cliente.Tag = "";
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

        private string _Mtd_PedidoSegunFactura(string _Str_CodigoFactura)
        {
            string _Str_SQL = "";

            _Str_SQL += "SELECT cpedido" + " ";
            _Str_SQL += "FROM TFACTURAM" + " ";
            _Str_SQL += "WHERE cfactura = " + _Str_CodigoFactura + " ";

            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count != 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }

        private Boolean _Mtd_ValidarParametros()
        {
            // switch de validacion, está por omision en true, y si alguna de las validaciones se dispara, el switch se vuelve false
            Boolean _Boo_Valido = true;
            _Er_Error.Dispose();

            // si se selecciona el radio de mes y año, entonces tiene que seleccinar un mes y un año
            if (!_Ctrl_ConsultaMes1._Bol_Listo)
            {
                _Boo_Valido = false;
                MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return _Boo_Valido;
        }

        private void _Mtd_MostrarReporte()
        {
            string _Str_NombreLogicoReporte = "Rpt_EfectividadPedido";

            string _Str_CodigoVendedor = "0";
            string _Str_CodigoPedido = "0";
            string _Str_CodigoCliente = "0";
            string _Str_Detallado = "0";

            if (_Txt_Vendedor.Tag.ToString() != "") _Str_CodigoVendedor = _Txt_Vendedor.Tag.ToString();
            if (_Txt_Pedido.Tag.ToString() != "") _Str_CodigoPedido = _Txt_Pedido.Tag.ToString();
            if (_Txt_Cliente.Tag.ToString() != "") _Str_CodigoCliente = _Txt_Cliente.Tag.ToString();

            // el parámetro 'detallado' del reporte indica: 0=por pedido, 1=por grupo de producto, 2=por producto
            if (_Rb_Ped.Checked) _Str_Detallado = "0";
            if (_Rb_Grup.Checked) _Str_Detallado = "1";
            if (_Rb_Prod.Checked) _Str_Detallado = "2";

            reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[8];

            parm[0] = new ReportParameter("ccompany", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("nombreEmpresa", _Mtd_NombComp());

            parm[2] = new ReportParameter("fechaInicial", _Ctrl_ConsultaMes1._Str_FechaInicio);
            parm[3] = new ReportParameter("fechaFinal", _Ctrl_ConsultaMes1._Str_FechaFinal);

            parm[4] = new ReportParameter("cpedido", _Str_CodigoPedido);
            parm[5] = new ReportParameter("cvendedor", _Str_CodigoVendedor);
            parm[6] = new ReportParameter("ccliente", _Str_CodigoCliente);
            // el parámetro 'detallado' del reporte indica: 0=por pedido, 1=por grupo de producto, 2=por producto
            parm[7] = new ReportParameter("detallado", _Str_Detallado);



            //parm[3] = new ReportParameter("CGERAREA", "NULL");
            reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + _Str_NombreLogicoReporte;
            reportViewer1.ServerReport.SetParameters(parm);
            this.reportViewer1.ServerReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

// ==========================================================================================================================================

        private void Frm_Inf_AcumVtaGerArea_Load(object sender, EventArgs e)
        {
            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();
            _Mtd_LimpiarTodo();
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            if (_Mtd_ValidarParametros())
            {
                _Mtd_MostrarReporte();
            }
        }

        private void _Bt_LimpiarVendedor_Click(object sender, EventArgs e)
        {
            _Txt_Vendedor.Text = ""; _Txt_Vendedor.Tag = "";
        }

        private void _Bt_LimpiarPedido_Click(object sender, EventArgs e)
        {
            _Txt_Pedido.Text = ""; _Txt_Pedido.Tag = "";
        }

        private void Bt_LimpiarCliente_Click(object sender, EventArgs e)
        {
            _Txt_Cliente.Text = ""; _Txt_Cliente.Tag = "";
        }

        private void _Bt_Pedido_Click(object sender, EventArgs e)
        {
            // guarda el valor actual, antes de buscar, para comparar luego si se selecciono algo
            string _Str_ValorAnterior = _Txt_Pedido.Tag.ToString();

            string _Str_ParametroBusqueda = "";
            if (_Txt_Cliente.Tag.ToString() != "") _Str_ParametroBusqueda += " AND TCLIENTE.ccliente = " + _Txt_Cliente.Tag.ToString() + " ";
            if (_Txt_Vendedor.Tag.ToString() != "") _Str_ParametroBusqueda += " AND TVENDEDOR.cvendedor = '" + _Txt_Vendedor.Tag.ToString() + "' ";

            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(70, _Txt_Pedido, 0, _Str_ParametroBusqueda);
            Cursor = Cursors.Default;
            _Frm.ShowDialog();

            // se trae el cliente y el vendedor si el usuario ha seleccionó algun pedido
            if (_Str_ValorAnterior != _Txt_Pedido.Tag.ToString())
            {
                // muestra el cliente
                string _Str_CodigoCliente = "";
                string _Str_NombreCliente = "";
                _Mtd_ClienteSegunPedido(_Txt_Pedido.Tag.ToString(), out _Str_CodigoCliente, out _Str_NombreCliente);
                _Txt_Cliente.Tag = _Str_CodigoCliente;
                //_Txt_Cliente.Text = _Str_CodigoCliente + " - " + _Str_NombreCliente;
                _Txt_Cliente.Text = _Str_NombreCliente;

                // muestra el vendedor
                string _Str_CodigoVendedor = "";
                string _Str_NombreVendedor = "";
                _Mtd_VendedorSegunPedido(_Txt_Pedido.Tag.ToString(), out _Str_CodigoVendedor, out _Str_NombreVendedor);
                _Txt_Vendedor.Tag = _Str_CodigoVendedor;
                //_Txt_Vendedor.Text = _Str_CodigoVendedor + " - " + _Str_NombreVendedor;
                _Txt_Vendedor.Text = _Str_NombreVendedor;
            }
        }

        private void Bt_Cliente_Click(object sender, EventArgs e)
        {
            // guarda el valor actual, antes de buscar, para comparar luego si se seleccionó algo
            string _Str_ValorAnterior = _Txt_Cliente.Tag.ToString();

            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(64, _Txt_Cliente, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();

            // borra el pedido y el vendedor si se se seleccionó algo
            if (_Str_ValorAnterior != _Txt_Cliente.Tag.ToString())
            {
                _Txt_Vendedor.Text = ""; _Txt_Vendedor.Tag = "";
                _Txt_Pedido.Text = ""; _Txt_Pedido.Tag = "";
            }

        }

        private void _Bt_Vendedor_Click(object sender, EventArgs e)
        {
            // guarda el valor actual, antes de buscar, para comparar luego si se seleccionó algo
            string _Str_ValorAnterior = _Txt_Vendedor.Tag.ToString();

            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(69, _Txt_Vendedor, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();

            // borra el pedido y el cliente si se se seleccionó algo
            if (_Str_ValorAnterior != _Txt_Cliente.Tag.ToString())
            {
                _Txt_Cliente.Text = ""; _Txt_Cliente.Tag = "";
                _Txt_Pedido.Text = ""; _Txt_Pedido.Tag = "";
            }
        }  
    }
}