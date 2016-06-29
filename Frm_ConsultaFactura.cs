using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConsultaFactura : Form
    {
        public Frm_ConsultaFactura()
        {
            InitializeComponent();
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
        private void _Mtd_IniGrid()
        {
            string _Str_Cadena = "SELECT cfactura,CONVERT(VARCHAR,c_fecha_factura,103) AS c_fecha_factura,RTRIM(cliente_descrip) AS cliente_descrip,cmontotot_factura,cstsdespacho,null AS obs1,cstscobrado,null AS obs2,cstsgeneral,ISNULL(TVENDEDOR.cvendedor+'-'+TVENDEDOR.cname,'CREADO POR OFICINA') AS cvendedorname,TVENDEDOR.cvendedor,ccliente,DATEPART(day,c_fecha_factura-c_fecha_pedido) AS diassinfact FROM VST_FACTURA_MAIN LEFT JOIN TVENDEDOR ON VST_FACTURA_MAIN.cvendedor=TVENDEDOR.cvendedor WHERE 0>1";
            _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
        }
        public void _Mtd_Actualizar()
        {
            if (_Ctrl_ConsultaMes1._Bol_Listo)
            {
                string _Str_Cadena = "SELECT cfactura,CONVERT(VARCHAR,c_fecha_factura,103) AS c_fecha_factura,RTRIM(cliente_descrip) AS cliente_descrip,cmontotot_factura,cstsdespacho,null AS obs1,cstscobrado,null AS obs2,cstsgeneral,ISNULL(TVENDEDOR.cvendedor+'-'+TVENDEDOR.cname,'CREADO POR OFICINA') AS cvendedorname,TVENDEDOR.cvendedor,ccliente,DATEPART(day,c_fecha_factura-c_fecha_pedido) AS diassinfact FROM VST_FACTURA_MAIN LEFT JOIN TVENDEDOR ON VST_FACTURA_MAIN.cvendedor=TVENDEDOR.cvendedor";
                string _Str_Where = "WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND VST_FACTURA_MAIN.ccompany='" + Frm_Padre._Str_Comp + "' AND CONVERT(DATETIME,CONVERT(VARCHAR,c_fecha_factura,103)) BETWEEN '" + _Ctrl_ConsultaMes1._Str_FechaInicio + "' AND '" + _Ctrl_ConsultaMes1._Str_FechaFinal + "'";
                //-----------------------------
                _Str_Cadena += " " + _Str_Where;
                //-----------------------------
                if (_Txt_Factura.Text.Trim().Length > 0)
                {
                    _Str_Cadena += " AND cfactura like '" + _Txt_Factura.Text.Trim() + "%'";
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
                    _Str_Cadena += " AND VST_FACTURA_MAIN.cvendedor='" + Convert.ToString(_Txt_Vendedor.Tag).Trim() + "'";
                }
                //-----------------------------
                _Str_Cadena += " ORDER BY cfactura";
                //-----------------------------
                Cursor = Cursors.WaitCursor;
                _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
                _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                Cursor = Cursors.Default;
                _Dg_Grid.ClearSelection();
                //--------------------------------------------------------------------
            }
            else
            {
                if (this.MdiParent != null)
                {
                    MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void Frm_ConsultaFactura_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
            Cursor = Cursors.Default;
        }
        private void Frm_ConsultaFactura_Activated(object sender, EventArgs e)
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

        private void _Txt_Factura_TextChanged(object sender, EventArgs e)
        {
            if (!new CLASES._Cls_Varios_Metodos(true)._Mtd_IsNumeric(_Txt_Factura.Text))
            {
                _Txt_Factura.Text = "";
            }
        }

        private void _Txt_Factura_KeyPress(object sender, KeyPressEventArgs e)
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

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Cursor = Cursors.WaitCursor;
                Frm_ConsultaFacturaDetalle _Frm = new Frm_ConsultaFacturaDetalle(Convert.ToString(_Dg_Grid["_Dg_Grid_ColFactura", e.RowIndex].Value).Trim());
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
                _Frm.Dispose();
            }
        }

        private void _Dg_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 & e.ColumnIndex != -1)
            {
                string _Str_Sql = "";
                DataSet _Ds;
                if (_Dg_Grid.Columns[e.ColumnIndex].Name == "_Dg_Grid_ColStsDespachoObs")
                {
                    _Str_Sql = "SELECT c_ped_obs FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + Convert.ToString(_Dg_Grid["_Dg_Grid_ColFactura", e.RowIndex].Value).Trim() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        Frm_FactObs _Frm = new Frm_FactObs(_Ds.Tables[0].Rows[0][0].ToString().Trim(), "FACTURA " + Convert.ToString(_Dg_Grid["_Dg_Grid_ColFactura", e.RowIndex].Value).Trim());
                        _Frm.ShowDialog();
                    }
                }
                else if (_Dg_Grid.Columns[e.ColumnIndex].Name == "_Dg_Grid_ColStsCobObs")
                {
                    _Str_Sql = "SELECT c_obs_cob FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + Convert.ToString(_Dg_Grid["_Dg_Grid_ColFactura", e.RowIndex].Value).Trim() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        Frm_FactObs _Frm = new Frm_FactObs(_Ds.Tables[0].Rows[0][0].ToString().Trim(), "FACTURA " + Convert.ToString(_Dg_Grid["_Dg_Grid_ColFactura", e.RowIndex].Value).Trim());
                        _Frm.ShowDialog();
                    }
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
                    _MyExcel._Mtd_DatasetToExcel((DataTable)this._Dg_Grid.DataSource, this._Ctr_Dialogo.FileName, "Facturas");
                }
            }

            _MyExcel = null;

            Cursor = Cursors.Default;
        }
    }
}