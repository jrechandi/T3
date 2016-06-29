using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConsultaPreFactura : Form
    {
        int _Int_Estatus = 0;
        string _Str_ThisText = "";
        public Frm_ConsultaPreFactura()
        {
            InitializeComponent();
            _Str_ThisText = this.Text;
            _Mtd_Color_Estandar(this);
            _Rb_Esperando.Checked = true;
        }
        public Frm_ConsultaPreFactura(int _P_Int_Estatus)
        {
            InitializeComponent();
            _Str_ThisText = this.Text;
            _Mtd_Color_Estandar(this);
            _Int_Estatus = _P_Int_Estatus;
            if (_P_Int_Estatus == 0)
            { _Rb_Todos.Checked = true; }
            else if (_P_Int_Estatus == 1)
            { _Rb_Esperando.Checked = true; }
            else if (_P_Int_Estatus == 2)
            { _Rb_EnPrecarga.Checked = true; }
            else
            { _Rb_Facturado.Checked = true; }
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
            string _Str_Cadena = "SELECT CONVERT(VARCHAR, c_fecha_pedido,103) AS c_fecha_pedido,cpedido,cpfactura,c_nomb_comer AS c_nomb_comer,cname AS cname,cempaques,dbo.Fnc_Formatear(c_montotot_si) AS c_montotot_si,CONVERT(VARCHAR,cefectividad)+'%' AS cefectividad,cefectividad AS cefectividad2,ccliente,cfacturado,clistofacturar,cprecarga,cbackorder,cvendedor,cunidades,c_factdevuelta,DATEDIFF(dd,c_fecha_pedido,getdate()) AS Dias FROM VST_PREFACTURAS WHERE 0>1";
            _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
        }
        public void _Mtd_Actualizar()
        {
            if (_Ctrl_ConsultaMes1._Bol_Listo)
            {
                string _Str_Cadena = "SELECT CONVERT(VARCHAR, c_fecha_pedido,103) AS c_fecha_pedido,cpedido,cpfactura,c_nomb_comer AS c_nomb_comer,cname AS cname,cempaques,dbo.Fnc_Formatear(c_montotot_si) AS c_montotot_si,CONVERT(VARCHAR,cefectividad)+'%' AS cefectividad,cefectividad AS cefectividad2,ccliente,cfacturado,clistofacturar,cprecarga,cbackorder,cvendedor,cunidades,c_factdevuelta,DATEDIFF(dd,c_fecha_pedido,getdate()) AS Dias FROM VST_PREFACTURAS";
                string _Str_Where = "";
                //-----------------------------
                if (_Int_Estatus == 0)
                { _Str_Where = "WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND c_facturaanul=0 AND ((clistofacturar='1' AND cprecarga='0' AND cfacturado='0') OR (clistofacturar='1' AND cprecarga>'0' AND cfacturado='0') OR (cfacturado='1') OR (c_factdevuelta='1' AND cprecarga='0')) AND CONVERT(DATETIME,CONVERT(VARCHAR,c_fecha_pedido,103)) BETWEEN '" + _Ctrl_ConsultaMes1._Str_FechaInicio + "' AND '" + _Ctrl_ConsultaMes1._Str_FechaFinal + "'"; }
                else if (_Int_Estatus == 1)
                { _Str_Where = "WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND c_facturaanul=0 AND ((clistofacturar='1' AND cprecarga='0' AND cfacturado='0') OR (c_factdevuelta='1' AND cprecarga='0')) AND CONVERT(DATETIME,CONVERT(VARCHAR,c_fecha_pedido,103)) BETWEEN '" + _Ctrl_ConsultaMes1._Str_FechaInicio + "' AND '" + _Ctrl_ConsultaMes1._Str_FechaFinal + "'"; }
                else if (_Int_Estatus == 2)
                { _Str_Where = "WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND (clistofacturar='1' AND cprecarga>'0' AND cfacturado='0') AND CONVERT(DATETIME,CONVERT(VARCHAR,c_fecha_pedido,103)) BETWEEN '" + _Ctrl_ConsultaMes1._Str_FechaInicio + "' AND '" + _Ctrl_ConsultaMes1._Str_FechaFinal + "'"; }
                else if (_Int_Estatus == 3)
                { _Str_Where = "WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND c_facturaanul=0 AND ((cfacturado='1' AND c_factdevuelta='0') OR (cfacturado='1' AND c_factdevuelta='1' AND cprecarga>'0')) AND CONVERT(DATETIME,CONVERT(VARCHAR,c_fecha_pedido,103)) BETWEEN '" + _Ctrl_ConsultaMes1._Str_FechaInicio + "' AND '" + _Ctrl_ConsultaMes1._Str_FechaFinal + "'"; }
                //-----------------------------
                _Str_Cadena += " " + _Str_Where;
                //-----------------------------
                if (_Txt_Prefactura.Text.Trim().Length > 0)
                {
                    _Str_Cadena += " AND cpfactura like '" + _Txt_Prefactura.Text.Trim() + "%'";
                }
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
                _Str_Cadena += " ORDER BY cpfactura,c_fecha_pedido DESC";
                //-----------------------------
                Cursor = Cursors.WaitCursor;
                _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
                //_Ctrl_Page1._Int_R = 0;
                //_Ctrl_Page1._Mtd_Inicializar(_Str_Cadena, _Dg_Grid, "VST_PREFACTURAS", _Str_Where, 100, "order by cpfactura,c_fecha_pedido DESC", "cpfactura", "SP_PAGINCONSULTPREFACTURA");
                _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                Cursor = Cursors.Default;
                _Dg_Grid.ClearSelection();
                //--------------------------------------------------------------------
                _Mtd_Verificar_PrefacturasDev();
            }
            else
            {
                if (this.MdiParent != null)
                {//Si es null no debe mostrar el mensaje porque significa que el metodo no esta siendo llamado desde este formulario sino desde Control Despacho.
                    MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void _Mtd_Verificar_PrefacturasDev()
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Cells["c_factdevuelta"].Value.ToString().Trim() == "1" & _Dg_Row.Cells["cprecarga"].Value.ToString().Trim() == "0")
                { _Dg_Row.DefaultCellStyle.BackColor = Color.Khaki; }
                else
                { _Dg_Row.DefaultCellStyle.BackColor = Color.White; }
            }
        }
        bool _Bol_Sw = true;
        private void Frm_ConsultaPreFactura_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
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

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
            Cursor = Cursors.Default;
        }

        private void verDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                int _Int_Estatus_Temp = 0;
                if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["clistofacturar"].Value == null)
                { _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["clistofacturar"].Value = 0; }
                if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cprecarga"].Value == null)
                { _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cprecarga"].Value = 0; }
                if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cfacturado"].Value == null)
                { _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cfacturado"].Value = 0; }
                if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["c_factdevuelta"].Value == null)
                { _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["c_factdevuelta"].Value = 0; }
                if ((_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cfacturado"].Value.ToString().Trim() == "1" & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["c_factdevuelta"].Value.ToString().Trim() == "0") | (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cfacturado"].Value.ToString().Trim() == "1" & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["c_factdevuelta"].Value.ToString().Trim() == "1" & Convert.ToInt32(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cprecarga"].Value) > 0))
                { _Int_Estatus_Temp = 3; }
                else if ((_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["clistofacturar"].Value.ToString().Trim() == "1" & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cprecarga"].Value.ToString().Trim() == "0" & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cfacturado"].Value.ToString().Trim() == "0") | (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["c_factdevuelta"].Value.ToString().Trim() == "1" & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cprecarga"].Value.ToString().Trim() == "0"))
                { _Int_Estatus_Temp = 1; }
                else if (_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["clistofacturar"].Value.ToString().Trim() == "1" & Convert.ToInt32(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cprecarga"].Value) > 0 & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cfacturado"].Value.ToString().Trim() == "0")
                { _Int_Estatus_Temp = 2; }
                Frm_ConsultaPreFacturaDetalle _Frm = new Frm_ConsultaPreFacturaDetalle(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cpfactura"].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cpedido"].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["c_fecha_pedido"].Value.ToString(),
                                                                               _Int_Estatus_Temp, _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["ccliente"].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["c_nomb_comer"].Value.ToString().Trim(),
                                                                               _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cvendedor"].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cname"].Value.ToString(),
                                                                               _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cempaques"].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cunidades"].Value.ToString(),
                                                                               _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["c_montotot_si"].Value.ToString(),
                                                                               Convert.ToInt32(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cbackorder"].Value.ToString()), Frm_Padre._Str_Comp, this);
                _Frm.ShowDialog(this);
            }
        }
        private void Frm_ConsultaPreFactura_Activated(object sender, EventArgs e)
        {
            if (_Bol_Sw)
            { _Mtd_Verificar_PrefacturasDev(); _Bol_Sw = false; }
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

        private void _Dg_Grid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_Verificar_PrefacturasDev();
            this.Cursor = Cursors.Default;
        }

        private void _Rb_Todos_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Todos.Checked)
            {
                this.Text = _Str_ThisText + " (" + _Rb_Todos.Text + ")";
                _Int_Estatus = 0;
                _Mtd_IniGrid();
                _Txt_Prefactura.Text = "";
            }
        }

        private void _Rb_Esperando_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Esperando.Checked)
            {
                this.Text = _Str_ThisText + " (" + _Rb_Esperando.Text + ")";
                _Int_Estatus = 1;
                _Mtd_IniGrid();
                _Txt_Prefactura.Text = "";
            }
        }

        private void _Rb_EnPrecarga_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_EnPrecarga.Checked)
            {
                this.Text = _Str_ThisText + " (" + _Rb_EnPrecarga.Text + ")";
                _Int_Estatus = 2;
                _Mtd_IniGrid();
                _Txt_Prefactura.Text = "";
            }
        }

        private void _Rb_Facturado_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Facturado.Checked)
            {
                this.Text = _Str_ThisText + " (" + _Rb_Facturado.Text + ")";
                _Int_Estatus = 3;
                _Mtd_IniGrid();
                _Txt_Prefactura.Text = "";
            }
        }

        private void _Txt_Prefactura_TextChanged(object sender, EventArgs e)
        {
            if (!new CLASES._Cls_Varios_Metodos(true)._Mtd_IsNumeric(_Txt_Prefactura.Text))
            {
                _Txt_Prefactura.Text = "";
            }
        }

        private void _Txt_Prefactura_KeyPress(object sender, KeyPressEventArgs e)
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

        private void _Txt_Pedido_TextChanged(object sender, EventArgs e)
        {
            if (!new CLASES._Cls_Varios_Metodos(true)._Mtd_IsNumeric(_Txt_Pedido.Text))
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

        private void _Btn_Exportar_Click(object sender, EventArgs e)
        {
            Clases._Cls_ExcelUtilidades _MyExcel = new T3.Clases._Cls_ExcelUtilidades();

            Cursor = Cursors.WaitCursor;

            if (this._Ctr_Dialogo.ShowDialog() == DialogResult.OK)
            {
                if (this._Ctr_Dialogo.FileName != "")
                {
                    _MyExcel._Mtd_DatasetToExcel((DataTable)this._Dg_Grid.DataSource, this._Ctr_Dialogo.FileName, "Prefacturas");
                }
            }

            _MyExcel = null;

            Cursor = Cursors.Default;
        }
    }
}