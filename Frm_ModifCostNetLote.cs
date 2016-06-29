using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ModifCostNetLote : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_ModifCostNetLote(string _P_Str_Producto, string _P_Str_Descripcion)
        {
            InitializeComponent();
            _Txt_Producto.Text = _P_Str_Producto;
            _Txt_Descripcion.Text = _P_Str_Descripcion;
            _Mtd_Actualizar(_P_Str_Producto);
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

        private void Frm_ModifCostNetLote_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
            _Pnl_Lote.Left = (this.Width / 2) - (_Pnl_Lote.Width / 2);
            _Pnl_Lote.Top = (this.Height / 2) - (_Pnl_Lote.Height / 2);
        }

        private void _Cntx_Txt_MenuModif_Click(object sender, EventArgs e)
        {
            _Pnl_Lote.Visible = true;
            _Txt_Lote.Text = Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Lote"].Value);
            _Txt_CostoBruto.Text = Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Costo Bruto"].Value);
            _Txt_CostoNeto.Text = Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Costo Neto"].Value);
            _Txt_CostoNeto.Focus();
        }

        private void _Bt_Cerrar_Click(object sender, EventArgs e)
        {
            _Pnl_Lote.Visible = false;
        }

        private void _Pnl_Lote_VisibleChanged(object sender, EventArgs e)
        {
            _Txt_Producto.Enabled = !_Pnl_Lote.Visible;
            _Txt_Descripcion.Enabled = !_Pnl_Lote.Visible;
            _Dg_Grid.Enabled = !_Pnl_Lote.Visible;
        }

        private void _Txt_CostoNeto_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_CostoNeto, e, 15, 2);
        }

        private void _Txt_CostoNeto_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_CostoNeto.Text)) { _Txt_CostoNeto.Text = ""; }
        }

        private void _Bt_Modificar_Click(object sender, EventArgs e)
        {
            double _Dbl_CostoBruto = 0;
            double _Dbl_CostoNeto = 0;
            double.TryParse(_Txt_CostoBruto.Text, out _Dbl_CostoBruto);
            double.TryParse(_Txt_CostoNeto.Text, out _Dbl_CostoNeto);
            if (_Dbl_CostoNeto <= 0)
            {
                MessageBox.Show("El costo neto debe ser mayor a cero(0).", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (_Dbl_CostoNeto > _Dbl_CostoBruto)
            {
                MessageBox.Show("El costo neto no debe ser mayor al costo bruto.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (new Frm_MessageBox("¿Esta seguro de modificar el costo neto del lote '" + _Txt_Lote.Text + "' del producto:\n'" + _Txt_Producto.Text + "' " + _Txt_Descripcion.Text + "?", "Precaución", SystemIcons.Warning, 2).ShowDialog() == DialogResult.Yes)
            {
                try
                {
                    _Mtd_ModificarCostoNeto(_Txt_Producto.Text, _Txt_Lote.Text, _Dbl_CostoNeto);
                    _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Costo Neto"].Value = _Dbl_CostoNeto.ToString("#,##0.00");
                    _Pnl_Lote.Visible = false;
                    MessageBox.Show("EL costo neto del lote '" + _Txt_Lote.Text + "' del producto: '" + _Txt_Producto.Text + "' " + _Txt_Descripcion.Text + "\nha sido modificado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception _Ex)
                {
                    _Pnl_Lote.Visible = false;
                    MessageBox.Show("Error al momento de realizar la operación.\n" + _Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            { _Pnl_Lote.Visible = false; }
        }

        void _Mtd_Actualizar(string _P_Str_Producto)
        {
            string _Str_Cadena = "SELECT cidproductod AS Lote, CONVERT(VARCHAR,cdateadd,103) AS [Fecha de Creación], dbo.Fnc_Formatear(cprecioventamax) AS PVJusto, dbo.Fnc_Formatear(ccostobrutolote) AS [Costo Bruto], dbo.Fnc_Formatear(ccostonetolote) AS [Costo Neto] FROM TPRODUCTOD WHERE cproducto='" + _P_Str_Producto + "' ORDER BY cdateadd DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns["Lote"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["Fecha de Creación"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns["PVJusto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["Costo Bruto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["Costo Neto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
        }

        void _Mtd_ModificarCostoNeto(string _P_Str_Producto, string _P_Str_Lote, double _P_Dbl_CostoNeto)
        {
            string _Str_Cadena = "UPDATE T3TPRODUCTOPMV SET ccostonetolote='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_CostoNeto) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cproducto='" + _P_Str_Producto + "' AND cidproductod='" + _P_Str_Lote + "'";
            Program._MyClsCnn._mtd_conexionSQL2012._Mtd_EjecutarSentencia(_Str_Cadena);
            Program._MyClsCnn._mtd_conexion2._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "UPDATE TPRODUCTOPMV SET ccostonetolote='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_CostoNeto) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cproducto='" + _P_Str_Producto + "' AND cidproductod='" + _P_Str_Lote + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "UPDATE TPRODUCTOD SET ccostonetolote='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_P_Dbl_CostoNeto) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cproducto='" + _P_Str_Producto + "' AND cidproductod='" + _P_Str_Lote + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
    }
}
