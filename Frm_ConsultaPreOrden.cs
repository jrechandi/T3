using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConsultaPreOrden : Form
    {
      clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");  
      public Frm_ConsultaPreOrden()
        {
            InitializeComponent();
        }

        private void Frm_ConsultaPreOrden_Load(object sender, EventArgs e)
        {
            //al cambiar el selectedIndex del combo, se dispara _Mtd_LlenarGridPrincipal automaticamente...
            _Cb_Status.SelectedIndex = 0;
            
            //_Mtd_LlenarGridPrincipal();

            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();

            if (_Ctrl_ConsultaMes1._Cmb_Year.Items.Count > 0) _Ctrl_ConsultaMes1._Cmb_Year.SelectedIndex = 1;
            if (_Ctrl_ConsultaMes1._Cmb_Month.Items.Count > 0) _Ctrl_ConsultaMes1._Cmb_Month.SelectedIndex = 1;
            

            //_Bt_Find.PerformClick();
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
        private void _Mtd_LlenarGridPrincipal()
        {
            string _Str_NombreBusqueda = "Pre-Ordenes de Compra";
            string _Str_NombreVista = "VST_CONSULTAPREORDEN";
            long _Lon_CantidadRegistrosPorPagina = 100;

            string Str_statusSeleccionado = "";
            switch (_Cb_Status.SelectedIndex)
            {
                case 0: // todos;
                  Str_statusSeleccionado = "";
                break;  
                case 1: // en proceso
                    Str_statusSeleccionado = "0";
                    break;
                case 2: // esperando por proveedor
                    Str_statusSeleccionado = "2";
                    break;
                case 3: // esperando por gerente
                    Str_statusSeleccionado = "3";
                    break;
                case 4: // orden de compra generada
                    Str_statusSeleccionado = "4";
                    break;
                case 5: // rechazada
                    Str_statusSeleccionado = "6";
                    break;
                case 6: // excedentes por aprobar
                    Str_statusSeleccionado = "5";
                    break;
            }

            string _Str_SQLSelect = "SELECT top ?sel Codigo, Fecha, Proveedor, Cajas, Total," + " ";
            _Str_SQLSelect += "CASE WHEN statusPreoc = 0 THEN 'EN PROCESO' ELSE" + " ";
            _Str_SQLSelect += "  CASE WHEN statusPreoc = 2 THEN 'ESPERANDO POR PROVEEDOR' ELSE" + " ";
            _Str_SQLSelect += "    CASE WHEN statusPreoc = 3 THEN 'ESPERANDO POR GERENTE' ELSE" + " ";
            _Str_SQLSelect += "      CASE WHEN statusPreoc = 4 THEN 'OC GENERADA' ELSE" + " ";
            _Str_SQLSelect += "        CASE WHEN statusPreoc = 6 THEN 'RECHAZADA' ELSE" + " ";
            _Str_SQLSelect += "          CASE WHEN statusPreoc = 5 THEN 'EXCEDENTES POR APROBAR' ELSE '' END" + " ";
            _Str_SQLSelect += "        END" + " ";
            _Str_SQLSelect += "      END" + " ";
            _Str_SQLSelect += "    END" + " ";
            _Str_SQLSelect += "  END" + " ";
            _Str_SQLSelect += "END" + " ";
            _Str_SQLSelect += "as Estatus" + " ";
            
            if (_Cb_Status.SelectedIndex == 0)
              _Str_SQLSelect += "FROM VST_CONSULTAPREORDEN WHERE NOT Codigo IN (SELECT top ?omi Codigo FROM VST_CONSULTAPREORDEN WHERE ccompany = '" + Frm_Padre._Str_Comp + "' ORDER BY codigo) AND ccompany = '" + Frm_Padre._Str_Comp + "' AND FECHA >= CONVERT (DATETIME,'" + _Ctrl_ConsultaMes1._Str_FechaInicio + "') AND FECHA <= CONVERT(DATETIME,'" + _Ctrl_ConsultaMes1._Str_FechaFinal + "')";
            else
              _Str_SQLSelect += "FROM VST_CONSULTAPREORDEN WHERE NOT Codigo IN (SELECT top ?omi Codigo FROM VST_CONSULTAPREORDEN WHERE ccompany = '" + Frm_Padre._Str_Comp + "' AND statusPreoc = " + Str_statusSeleccionado + " ORDER BY codigo) AND ccompany = '" + Frm_Padre._Str_Comp + "'" + " AND FECHA >= CONVERT (DATETIME,'" + _Ctrl_ConsultaMes1._Str_FechaInicio + "') AND FECHA <= CONVERT(DATETIME,'" + _Ctrl_ConsultaMes1._Str_FechaFinal + "') AND statusPreoc = " + Str_statusSeleccionado;
            
            string _Str_SQLOrderBy = "ORDER BY codigo" + " ";

            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Codigo");
            _Tsm_Menu[1] = new ToolStripMenuItem("Proveedor");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "Codigo";
            _Str_Campos[1] = "Proveedor";

            _Ctrl_BusquedaPage1._Mtd_Inicializar(_Str_SQLSelect, _Str_Campos, _Str_NombreBusqueda, _Tsm_Menu, _Dg_Grid, _Str_NombreVista, "WHERE ccompany = '" + Frm_Padre._Str_Comp + "'", _Lon_CantidadRegistrosPorPagina, _Str_SQLOrderBy);

            _Dg_Grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            _Dg_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________
        }

        private void _Cb_Status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _Dg_Grid_DoubleClick(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (_Dg_Grid.Rows[0].Cells[0].Value != null)
            {
                string _Str_CodigoSeleccionado = _Ctrl_BusquedaPage1._Mtd_RetornarStringCelda(0, _Dg_Grid.CurrentCell.RowIndex);
                _Mtd_MostrarEncabezado(_Str_CodigoSeleccionado);
                _Mtd_LlenarGridDetalle(_Str_CodigoSeleccionado);

                _Tb_Tab.SelectedIndex = 1;
            }
            Cursor = Cursors.Default;
        }

        private void _Mtd_MostrarEncabezado(string _Str_Codigo)
        {
            string _Str_SQL = "";
            _Str_SQL += "SELECT Codigo, Fecha, Proveedor, Cajas, Monto, Impuesto, Total " + " ";
            _Str_SQL += "FROM VST_CONSULTAPREORDEN" + " ";
            _Str_SQL += "WHERE codigo = " + _Str_Codigo + " AND ccompany = '" + Frm_Padre._Str_Comp + "'" + " ";

            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count != 0)
            {
                _Txt_Codigo.Text = _Str_Codigo;
                _Txt_Fecha.Text = _Ds.Tables[0].Rows[0]["Fecha"].ToString();
                _Txt_Proveedor.Text = _Ds.Tables[0].Rows[0]["Proveedor"].ToString();
                _Txt_Monto.Text = _Ds.Tables[0].Rows[0]["Monto"].ToString();
                _Txt_Impuesto.Text = _Ds.Tables[0].Rows[0]["Impuesto"].ToString();
                _Txt_Total.Text = _Ds.Tables[0].Rows[0]["Total"].ToString();
                _Txt_Cajas.Text = _Ds.Tables[0].Rows[0]["Cajas"].ToString();
            }
            else
            {
                _Mtd_LimpiarEncabezado();
                _Mtd_LimpiarDetalle();
            }
        }

        private void _Mtd_LlenarGridDetalle(string _Str_Codigo)
        {
            string _Str_SQL = "";
            _Str_SQL += "SELECT Codigo, Producto, Cajas, Monto, Impuesto, Total" + " ";
            _Str_SQL += "FROM VST_CONSULTAPREORDENDETALLE" + " ";
            _Str_SQL += "WHERE ccompany = '" + Frm_Padre._Str_Comp + "' AND cpreoc = " + _Str_Codigo + " ";

            DataSet _Ds = new DataSet();
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            _Dg_Detalle.DataSource = _Ds.Tables[0];
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            _Dg_Detalle.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _Dg_Detalle.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _Dg_Detalle.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Detalle.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = _Txt_Codigo.Text.Trim().Length == 0 & e.TabPageIndex == 1;
        }

        private void _Mtd_LimpiarEncabezado()
        {
            _Txt_Codigo.Text = "";
            _Txt_Fecha.Text = "";
            _Txt_Proveedor.Text = "";
            _Txt_Monto.Text = "";
            _Txt_Impuesto.Text = "";
            _Txt_Total.Text = "";
            _Txt_Cajas.Text = "";
        }

        private void _Mtd_LimpiarDetalle()
        {
            _Dg_Detalle.DataSource = null;
        }

        private Boolean _Mtd_ValidarParametros()
        {
          // switch de validacion, está por omision en true, y si alguna de las validaciones se dispara, el switch se vuelve false
          Boolean _Boo_Valido = true;
          //_Er_Error.Dispose();

          // si se selecciona el radio de mes y año, entonces tiene que seleccinar un mes y un año
          if (!_Ctrl_ConsultaMes1._Bol_Listo)
          {
            _Boo_Valido = false;
            MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }

          return _Boo_Valido;
        }

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
          if (_Mtd_ValidarParametros())
            _Mtd_LlenarGridPrincipal();
          else
            _Dg_Grid.DataSource = null;

          _Mtd_LimpiarEncabezado();
          _Mtd_LimpiarDetalle();
        }

        private void _Dg_Grid_MouseEnter(object sender, EventArgs e)
        {
          _Lbl_DgInfo.Visible = true;
        }

        private void _Dg_Grid_MouseLeave(object sender, EventArgs e)
        {
          _Lbl_DgInfo.Visible = false;
        }

        private void _Btn_Imprimir_Click(object sender, EventArgs e)
        {
                _Mtd_ImprimirPreOrden(_Txt_Codigo.Text);
        }
        private void _Mtd_ImprimirPreOrden(string _P_Str_PreOrden)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Inf_Varios _Frm_Inf = new Frm_Inf_Varios(6, Frm_Padre._Str_Comp, _Mtd_NombComp(), _P_Str_PreOrden, _Mtd_CodigoProveedorSegunCodigoPOC(_P_Str_PreOrden), _Txt_Proveedor.Text, _Txt_Fecha.Text);
            Cursor = Cursors.Default;
            _Frm_Inf.MdiParent = this.MdiParent;
            _Frm_Inf.Dock = DockStyle.Fill;
            _Frm_Inf.Show();
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

        private string _Mtd_CodigoProveedorSegunCodigoPOC(string _Str_CodigoPOC)
        {
            string _Str_Cadena = "SELECT cproveedor from TPREORDENCM where cpreoc = " + _Str_CodigoPOC + " AND ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
            }
            return "";
        }

    }
}
