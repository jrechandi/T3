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
    public partial class Frm_Inf_IndicDespacho : Form
    {
        public Frm_Inf_IndicDespacho()
        {
            InitializeComponent();
            reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_AcumVtaGerArea";
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
          _Txt_Cliente.Text = ""; _Txt_Cliente.Tag = "";
          _Txt_Factura.Text = ""; _Txt_Factura.Tag = "";
          _Txt_Pedido.Text  = ""; _Txt_Pedido.Tag  = "";
        }
      
        private void _Mtd_ClienteSegunPedido(string _Str_CodigoPedido, out string _Str_CodigoCliente, out string _Str_NombreCliente)
        {
          string _Str_SQL = "";

          _Str_SQL += "SELECT TCLIENTE.ccliente, TCLIENTE.c_nomb_comer" + " ";
          _Str_SQL += "FROM TCOTPEDFACM INNER JOIN TCLIENTE ON TCOTPEDFACM.ccliente = TCLIENTE.ccliente" + " ";
          _Str_SQL += "WHERE TCOTPEDFACM.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOTPEDFACM.cpedido = " + _Str_CodigoPedido + "  AND TCOTPEDFACM.CCOTIZACION = " + _Str_CodigoPedido + " ";

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
            string _Str_NombreLogicoReporte = "Rpt_IndicadoresDespacho";

            string _Str_CodigoCliente = "0";
            string _Str_CodigoPedido = "0";
            string _Str_CodigoFactura = "0";

            if (_Txt_Cliente.Tag.ToString() != "") _Str_CodigoCliente = _Txt_Cliente.Tag.ToString();
            if (_Txt_Pedido.Tag.ToString() != "") _Str_CodigoPedido = _Txt_Pedido.Tag.ToString();
            if (_Txt_Factura.Tag.ToString() != "") _Str_CodigoFactura = _Txt_Factura.Tag.ToString();

            reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[7];

            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());

            parm[2] = new ReportParameter("CPEDIDO", _Str_CodigoPedido);
            parm[3] = new ReportParameter("CFACTURA", _Str_CodigoFactura);
            parm[4] = new ReportParameter("CCLIENTE", _Str_CodigoCliente);

            parm[5] = new ReportParameter("CFECHAINIBUS", _Ctrl_ConsultaMes1._Str_FechaInicio);
            parm[6] = new ReportParameter("CFECHAFINBUS", _Ctrl_ConsultaMes1._Str_FechaFinal);

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

        private void _Bt_Cliente_Click(object sender, EventArgs e)
        {
            // guarda el valor actual, antes de buscar, para comparar luego si se selecciono algo
            string _Str_ValorAnterior = _Txt_Cliente.Tag.ToString();

            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(64, _Txt_Cliente, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();

            // limpia pedido y factura, si es necesario
            if (_Str_ValorAnterior != _Txt_Cliente.Tag.ToString())
            {
                _Txt_Factura.Text = ""; _Txt_Factura.Tag = "";
                _Txt_Pedido.Text = ""; _Txt_Pedido.Tag = "";
            }
        }

        private void _Bt_Pedido_Click(object sender, EventArgs e)
        {
            string _Str_CodigoCliente = "";
            string _Str_NombreCliente = "";

            // guarda el valor actual, antes de buscar, para comparar luego si se selecciono algo
            string _Str_ValorAnterior = _Txt_Pedido.Tag.ToString();

            Cursor = Cursors.WaitCursor;

            // hay dos casos para la búsqueda:
            if (_Txt_Cliente.Tag.ToString() == "")
            {
                // 1. que el cliente esté en blanco: se llama a la búsqueda completa
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(67, _Txt_Pedido, 0, "");
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
            }
            else
            {
                // 2. que esté seleccionado algun cliente: se llama a la búsqueda filtrada
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(67, _Txt_Pedido, 0, " AND TCOTPEDFACM.ccliente = " + _Txt_Cliente.Tag.ToString());
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
            }

            // muestra el cliente, en caso de que no esté ya seleccionado
            if ((_Txt_Pedido.Tag.ToString() != "") && (_Txt_Cliente.Tag.ToString() == ""))
            {
                _Mtd_ClienteSegunPedido(_Txt_Pedido.Text, out _Str_CodigoCliente, out _Str_NombreCliente);
                _Txt_Cliente.Tag = _Str_CodigoCliente;
                _Txt_Cliente.Text = _Str_NombreCliente;
            }

            //limpia la factura, si es necesario
            if (_Str_ValorAnterior != _Txt_Pedido.Tag.ToString())
            {
                _Txt_Factura.Text = ""; _Txt_Factura.Tag = "";
            }
        }

        private void _Bt_Factura_Click(object sender, EventArgs e)
        {
            string _Str_CodigoCliente = "";
            string _Str_NombreCliente = "";
            string _Str_CodigoPedido = "";

            //string _Str_CodigoPedido = "";

            Cursor = Cursors.WaitCursor;

            // hay tres casos para la búsqueda:

            // 1. que el cliente y el pedido esten en blanco: se llama a la búsqueda sin filtros
            if ((_Txt_Cliente.Tag.ToString() == "") && (_Txt_Pedido.Tag.ToString() == ""))
            {
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(68, _Txt_Factura, 0, "");
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
            }

            // 2. que el cliente esté seleccionado, y el pedido en blanco: se llama a la búsqueda filtrada por cliente
            if ((_Txt_Cliente.Tag.ToString() != "") && (_Txt_Pedido.Tag.ToString() == ""))
            {
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(68, _Txt_Factura, 0, " AND TCLIENTE.ccliente = " + _Txt_Cliente.Tag.ToString());
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
            }

            // 3. que el cliente esté en blanco, y el pedido seleccionado: se llama a la búsqueda filtrada por cliente
            if ((_Txt_Cliente.Tag.ToString() == "") && (_Txt_Pedido.Tag.ToString() != ""))
            {
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(68, _Txt_Factura, 0, " AND TFACTURAM.cpedido = " + _Txt_Pedido.Tag.ToString());
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
            }

            // 4. que el cliente y el pedido esten seleccionados: se llama a la busqueda filtrada por cliente y pedido
            if ((_Txt_Cliente.Tag.ToString() != "") && (_Txt_Pedido.Tag.ToString() != ""))
            {
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(68, _Txt_Factura, 0, " AND TCLIENTE.ccliente = " + _Txt_Cliente.Tag.ToString() + " AND TFACTURAM.cpedido = " + _Txt_Pedido.Tag.ToString());
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
            }

            // muestra el pedido, en caso de que no esté ya seleccionado
            if ((_Txt_Factura.Tag.ToString() != "") && (_Txt_Pedido.Tag.ToString() == ""))
            {
                _Str_CodigoPedido = _Mtd_PedidoSegunFactura(_Txt_Factura.Tag.ToString());
                _Txt_Pedido.Tag = _Str_CodigoPedido;
                _Txt_Pedido.Text = _Str_CodigoPedido;
            }

            // muestra el cliente, en caso de que no esté ya seleccionado
            if ((_Txt_Pedido.Tag.ToString() != "") && (_Txt_Cliente.Tag.ToString() == ""))
            {
                _Mtd_ClienteSegunPedido(_Txt_Pedido.Text, out _Str_CodigoCliente, out _Str_NombreCliente);
                _Txt_Cliente.Tag = _Str_CodigoCliente;
                _Txt_Cliente.Text = _Str_NombreCliente;
            }

        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            if (_Mtd_ValidarParametros())
            {
                _Mtd_MostrarReporte();
            }
        }

        private void _Bt_Limpiar_P_Click(object sender, EventArgs e)
        {
            _Txt_Pedido.Tag = ""; _Txt_Pedido.Text = "";
        }

        private void _Bt_LimpiarCliente_Click(object sender, EventArgs e)
        {
            _Txt_Cliente.Tag = ""; _Txt_Cliente.Text = "";
        }

        private void _Bt_LimpiarFactura_Click(object sender, EventArgs e)
        {
            _Txt_Factura.Tag = ""; _Txt_Factura.Text = "";
        }
    }
}