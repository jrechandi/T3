using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConsultaPedidos : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        int _Int_Estatus = 1;
        string _Str_ThisText = "";
        public Frm_ConsultaPedidos()
        {
            InitializeComponent();
            _Str_ThisText = this.Text;
            _Mtd_Color_Estandar(this);
            _Rb_Todos.Checked = true;
        }
        public Frm_ConsultaPedidos(int _P_Int_Estatus)
        {
            InitializeComponent();
            _Str_ThisText = this.Text;
            _Mtd_Color_Estandar(this);
            _Int_Estatus = _P_Int_Estatus;
            if (_P_Int_Estatus == 1)
            { _Rb_Todos.Checked = true; }
            else if (_P_Int_Estatus == 2)
            { _Rb_Bloqueados.Checked = true; }
            else if (_P_Int_Estatus == 3)
            { _Rb_Rechazados.Checked = true; }
            else if (_P_Int_Estatus == 4)
            { _Rb_Facturar.Checked = true; }
            else
            { _Rb_Anulados.Checked = true; }
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
        private void _Mtd_IniGrid()
        {
            string _Str_Cadena = "SELECT CONVERT(varchar, c_fecha_pedido,103) as c_fecha_pedido,cpedido,ccliente,c_nomb_comer,cnamevendedor,cnamefpago,cempaques,dbo.Fnc_Formatear(c_montotot_si) AS c_montotot_si,cstatus,c_rif,cvendedor,cfpago,c_bloqbackorder,c_rechabackorder,cunidades,cbackorder,CONVERT(varchar,cefectividad)+'%' AS cefectividad,cefectividad AS cefectividad2,c_montotot_si AS montoparaordenar from VST_CONSULTAPEDIDOS WHERE 0>1";
            _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
        }
        public void _Mtd_Actualizar()
        {
            if (_Ctrl_ConsultaMes1._Bol_Listo)
            {
                string _Str_Cadena = "SELECT CONVERT(varchar, c_fecha_pedido,103) as c_fecha_pedido,cpedido,ccliente,c_nomb_comer,cnamevendedor,cnamefpago,cempaques,dbo.Fnc_Formatear(c_montotot_si) AS c_montotot_si,cstatus,c_rif,cvendedor,cfpago,c_bloqbackorder,c_rechabackorder,cunidades,cbackorder,CONVERT(varchar,cefectividad)+'%' AS cefectividad,cefectividad AS cefectividad2,c_montotot_si AS montoparaordenar from VST_CONSULTAPEDIDOS";
                string _Str_Where = "";
                //-----------------------------
                if (_Int_Estatus == 1)
                { _Str_Where = "WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cstatus<>'7' AND c_pendientebackorder='0' AND CONVERT(DATETIME,CONVERT(VARCHAR,c_fecha_pedido,103)) BETWEEN '" + _Ctrl_ConsultaMes1._Str_FechaInicio + "' AND '" + _Ctrl_ConsultaMes1._Str_FechaFinal + "'"; }
                else if (_Int_Estatus == 2)
                { _Str_Where = "WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cstatus='3' and isnull(caprobadocredito,0)=0 AND CONVERT(DATETIME,CONVERT(VARCHAR,c_fecha_pedido,103)) BETWEEN '" + _Ctrl_ConsultaMes1._Str_FechaInicio + "' AND '" + _Ctrl_ConsultaMes1._Str_FechaFinal + "'"; }
                else if (_Int_Estatus == 3)
                { _Str_Where = "WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND c_rechabackorder='1' AND cstatus='9' AND c_pendientebackorder='0' AND CONVERT(DATETIME,CONVERT(VARCHAR,c_fecha_pedido,103)) BETWEEN '" + _Ctrl_ConsultaMes1._Str_FechaInicio + "' AND '" + _Ctrl_ConsultaMes1._Str_FechaFinal + "'"; }
                else if (_Int_Estatus == 4)
                { _Str_Where = "WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cstatus='4' AND cfactura='0' AND CONVERT(DATETIME,CONVERT(VARCHAR,c_fecha_pedido,103)) BETWEEN '" + _Ctrl_ConsultaMes1._Str_FechaInicio + "' AND '" + _Ctrl_ConsultaMes1._Str_FechaFinal + "'"; }
                else if (_Int_Estatus == 5)
                { _Str_Where = "WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cstatus='7' AND CONVERT(DATETIME,CONVERT(VARCHAR,c_fecha_pedido,103)) BETWEEN '" + _Ctrl_ConsultaMes1._Str_FechaInicio + "' AND '" + _Ctrl_ConsultaMes1._Str_FechaFinal + "'"; }
                //-----------------------------
                _Str_Cadena += " " + _Str_Where;
                //-----------------------------
                if (_Txt_Pedido.Text.Trim().Length > 0)
                {
                    _Str_Cadena += " AND cpedido like '" + _Txt_Pedido.Text.Trim() + "%'";
                }
                //-----------------------------
                if (_Txt_Cliente.Text.Trim().Length > 0)
                {
                    _Str_Cadena += " AND ccliente='" + Convert.ToString(_Txt_Cliente.Tag).Trim() + "'";
                }
                //-----------------------------
                if (_Txt_Vendedor.Text.Trim().Length > 0)
                {
                    _Str_Cadena += " AND cvendedor='" + Convert.ToString(_Txt_Vendedor.Tag).Trim() + "'";
                }
                //-----------------------------
                _Str_Cadena += " ORDER BY cpedido,c_fecha_pedido DESC";
                //-----------------------------
                Cursor = Cursors.WaitCursor;
                _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
                //_Ctrl_Page1._Int_R = 0;
                //_Ctrl_Page1._Mtd_Inicializar(_Str_Cadena, _Dg_Grid, "VST_CONSULTAPEDIDOS", _Str_Where, 100, "ORDER BY cpedido,c_fecha_pedido DESC", "cpedido", "PA_PAGINCONSULTPEDIDO");
                _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                Cursor = Cursors.Default;
                _Dg_Grid.ClearSelection();
            }
            else
            {
                if (this.MdiParent != null)
                {//Si es null no debe mostrar el mensaje porque significa que el metodo no esta siendo llamado desde este formulario sino desde Control Despacho.
                    MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
        private void Frm_ConsultaPedidos_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();
            if (_Rb_Todos.Checked)
            {
                _Ctrl_ConsultaMes1._Mtd_Year();
                if (_Ctrl_ConsultaMes1._Cmb_Year.Items.Count > 1)
                { _Ctrl_ConsultaMes1._Cmb_Year.SelectedIndex = 1; _Ctrl_ConsultaMes1._Cmb_Month.SelectedIndex = 1; }
            }
            else
            {
                DateTime _Dtp_Temp = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _Dtp_Temp = _Dtp_Temp.AddMonths(-3);
                _Ctrl_ConsultaMes1._Rb_Rango.Checked = true;
                _Ctrl_ConsultaMes1._Dtp_Desde.Value = new DateTime(_Dtp_Temp.Year, _Dtp_Temp.Month, 1);
            }
            _Mtd_Actualizar();
            _Dg_Grid.ClearSelection();
        }

        private void Frm_ConsultaPedidos2_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Dg_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgInfo.Visible = true;
            }
            else
            {
                _Lbl_DgInfo.Visible = false;
            }
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count == 1)
            {
                if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["C_RECHABACKORDER"].Value.ToString().Trim() == "1" & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cstatus"].Value.ToString().Trim() != "7")
                { _Items_Anular.Visible = true; }
                else
                { _Items_Anular.Visible = false; }
            }
            else
            { e.Cancel = true; }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Pnl_Superior.Enabled = false; _Dg_Grid.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Pnl_Superior.Enabled = true; _Dg_Grid.Enabled = true; }
        }

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                _Pnl_Clave.Visible = false;
                Cursor = Cursors.WaitCursor;
                string _Str_Cadena = "Update TCOTPEDFACM set cstatus='7',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cpedido='" + Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cpedido"].Value).Trim() + "'  and CCOTIZACION='" + Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cpedido"].Value).Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                Cursor = Cursors.Default;
                Cursor = Cursors.WaitCursor;
                _Mtd_Actualizar();
                Cursor = Cursors.Default;
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void verDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                int _Int_Estatus_Temp = 0;
                if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cstatus"].Value.ToString().Trim() == "3")
                { _Int_Estatus_Temp = 1; }
                else if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["C_RECHABACKORDER"].Value.ToString().Trim() == "1" & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cstatus"].Value.ToString().Trim() != "7")
                { _Int_Estatus_Temp = 3; }
                else if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cstatus"].Value.ToString().Trim() == "4")
                { _Int_Estatus_Temp = 4; }
                else if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cstatus"].Value.ToString().Trim() == "7")
                { _Int_Estatus_Temp = 5; }
                Frm_ConsultaPedidosDetalle _Frm = new Frm_ConsultaPedidosDetalle(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cpedido"].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["c_fecha_pedido"].Value.ToString(),
                                                                               _Int_Estatus_Temp, _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["ccliente"].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["ccliente"].Value.ToString() + " - " + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["c_nomb_comer"].Value.ToString().Trim(),
                                                                               _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cvendedor"].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cnamevendedor"].Value.ToString(),
                                                                               _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cempaques"].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cunidades"].Value.ToString(),
                                                                               _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["c_montotot_si"].Value.ToString(), Convert.ToDouble(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cefectividad2"].Value.ToString()),
                                                                               Convert.ToInt32(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cbackorder"].Value.ToString()), this);
                _Frm.ShowDialog(this);
            }
        }

        private void _Items_Anular_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = true;
        }

        private void _Dg_Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["c_rechabackorder"].Value != null)
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells["c_rechabackorder"].Value.ToString().Trim() == "1")
                    { e.Value = new Bitmap(GetType(), "Multimedia._Tool_ConsPedRechExis.ico"); }
                }
                if (_Dg_Grid.Rows[e.RowIndex].Cells["cstatus"].Value != null)
                {
                    switch (_Dg_Grid.Rows[e.RowIndex].Cells["cstatus"].Value.ToString())
                    {
                        case "3":
                            e.Value = new Bitmap(GetType(), "Multimedia._Tool_ConsPedBloExis.ico");
                            //_Dg_Grid.Rows[e.RowIndex].Cells["cefectividad"].Value = "0.0%";
                            //_Dg_Grid.Rows[e.RowIndex].Cells["cefectividad2"].Value = "0";
                            break;
                        case "4":
                            e.Value = new Bitmap(GetType(), "Multimedia._Tool_ConsPedFac.ico");
                            break;
                        case "7":
                            e.Value = new Bitmap(GetType(), "Multimedia._Tool_ConsPedAnul.ico");
                            break;
                        case "2":
                            e.Value = new Bitmap(GetType(), "Multimedia._Tool_Espera.ico");
                            break;
                    }
                }
            }
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
            Cursor = Cursors.Default;
        }

        private void _Rb_Todos_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Todos.Checked)
            {
                this.Text = _Str_ThisText + " (" + _Rb_Todos.Text + ")";
                _Int_Estatus = 1;
                _Mtd_IniGrid();
                _Txt_Pedido.Text = "";
            }
        }

        private void _Rb_Bloqueados_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Bloqueados.Checked)
            {
                this.Text = _Str_ThisText + " (" + _Rb_Bloqueados.Text + ")";
                _Int_Estatus = 2;
                _Mtd_IniGrid();
                _Txt_Pedido.Text = "";
            }
        }

        private void _Rb_Rechazados_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Rechazados.Checked)
            {
                this.Text = _Str_ThisText + " (" + _Rb_Rechazados.Text + ")";
                _Int_Estatus = 3;
                _Mtd_IniGrid();
                _Txt_Pedido.Text = "";
            }
        }

        private void _Rb_Facturar_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Facturar.Checked)
            {
                this.Text = _Str_ThisText + " (" + _Rb_Facturar.Text + ")";
                _Int_Estatus = 4;
                _Mtd_IniGrid();
                _Txt_Pedido.Text = "";
            }
        }

        private void _Rb_Anulados_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Anulados.Checked)
            {
                this.Text = _Str_ThisText + " (" + _Rb_Anulados.Text + ")";
                _Int_Estatus = 5;
                _Mtd_IniGrid();
                _Txt_Pedido.Text = "";
            }
        }

        private void _Txt_Pedido_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_Pedido.Text))
            {
                _Txt_Pedido.Text = "";
            }
        }

        private void _Txt_Pedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == (char)13)
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_Actualizar();
                    Cursor = Cursors.Default;
                }
            }
        }

        private void Bt_Cliente_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(64, _Txt_Cliente, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
        }

        private void _Bt_Vendedor_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(69, _Txt_Vendedor, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
        }

        private void Bt_LimpiarCliente_Click(object sender, EventArgs e)
        {
            _Txt_Cliente.Text = ""; _Txt_Cliente.Tag = "";
        }

        private void _Bt_LimpiarVendedor_Click(object sender, EventArgs e)
        {
            _Txt_Vendedor.Text = ""; _Txt_Vendedor.Tag = "";
        }
        private void _Mtd_Sort(string _P_Str_ColName,string _P_Str_ColNameSort)
        {
            _Dg_Grid.Columns[_P_Str_ColName].SortMode = DataGridViewColumnSortMode.Programmatic;
            if (_Dg_Grid.Columns[_P_Str_ColName].HeaderCell.SortGlyphDirection.Equals(SortOrder.None) | _Dg_Grid.Columns[_P_Str_ColName].HeaderCell.SortGlyphDirection.Equals(SortOrder.Descending))
            {
                _Dg_Grid.Sort(_Dg_Grid.Columns[_P_Str_ColNameSort], ListSortDirection.Ascending);
                _Dg_Grid.Columns[_P_Str_ColName].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            }
            else
            {
                _Dg_Grid.Sort(_Dg_Grid.Columns[_P_Str_ColNameSort], ListSortDirection.Descending);
                _Dg_Grid.Columns[_P_Str_ColName].HeaderCell.SortGlyphDirection = SortOrder.Descending;
            }
        }
        private void _Dg_Grid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.Columns[e.ColumnIndex].Name == "c_montotot_si" | _Dg_Grid.Columns[e.ColumnIndex].Name == "cefectividad1")
            {
                _Dg_Grid.Columns["c_montotot_si"].Tag = "montoparaordenar";
                _Dg_Grid.Columns["cefectividad1"].Tag = "cefectividad2";
                _Mtd_Sort(_Dg_Grid.Columns[e.ColumnIndex].Name, Convert.ToString(_Dg_Grid.Columns[e.ColumnIndex].Tag));
            }
        }

        private void _Btn_Exportar_Click(object sender, EventArgs e)
        {
            Clases._Cls_ExcelUtilidades _MyExcel = new T3.Clases._Cls_ExcelUtilidades();

            Cursor = Cursors.WaitCursor;

            if (this._Ctr_Dialogo.ShowDialog() == DialogResult.OK)
            {
                if (this._Ctr_Dialogo.FileName != "")
                {
                    _MyExcel._Mtd_DatasetToExcel((DataTable)this._Dg_Grid.DataSource, this._Ctr_Dialogo.FileName, "Pedidos");
                }
            }

            _MyExcel = null;

            Cursor = Cursors.Default;
        }
    }
}
