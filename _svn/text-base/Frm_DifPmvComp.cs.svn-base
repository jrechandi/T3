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
    public partial class Frm_DifPmvComp : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        string _Str_Proveedor = "";
        string _Str_NombProveedor = "";
        public Frm_DifPmvComp()
        {
            InitializeComponent();
            _Mtd_Actualizar();
        }
        private void _Mtd_Actualizar()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT DISTINCT cidnotrecepc AS NR,CONVERT(VARCHAR,cfechanotarecepcion,103) AS [Fecha NR],c_nomb_comer as Proveedor,cproveedor FROM VST_PMVNOTIFICADOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(cndgenerado,0)=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns["NR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns["Fecha NR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns["cproveedor"].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }
        private void _Mtd_ActualizarDetalle(string _P_Str_NR)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT cproducto AS Producto,cnamefc AS Descripción,dbo.Fnc_Formatear(cpmvfactura) AS [Monto Fact.],dbo.Fnc_Formatear(cpmvdescrecep) AS [Monto NR.] FROM VST_PMVNOTIFICADOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotrecepc='" + _P_Str_NR + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Detalle.DataSource = _Ds.Tables[0];
            _Dg_Detalle.Columns["Monto Fact."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns["Monto NR."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Detalle.Columns["Descripción"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Cursor = Cursors.Default;
        }
        private bool _Mtd_ExisteND(string _P_Str_ND)
        {
            string _Str_Cadena = "SELECT cidnotadebitocxp FROM TNOTADEBITOCP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp='" + _P_Str_ND + "' AND cestatusfirma<>'9'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }
        private void _Mtd_ActualizarInformacion(string _P_Str_NR,string _P_Str_ND)
        {
            string _Str_Cadena = "UPDATE TPMVNOTIFICADORM SET cidnotadebitocxp='" + _P_Str_ND + "',cndgenerado='1' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotrecepc='" + _P_Str_NR + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
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

        private void _Txt_ND_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_ND.Text))
            {
                _Txt_ND.Text = "";
            }
        }

        private void _Txt_ND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void Frm_DifPmvComp_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
        }

        private void _Bt_Actualizar_Click(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                e.Cancel = _Txt_NR.Text.Trim().Length == 0;
            }
            else
            {
                _Txt_NR.Text = "";
                _Txt_FechNR.Text = "";
                _Str_Proveedor = "";
                _Str_NombProveedor = "";
                _Dg_Detalle.DataSource = null;
            }
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count == 1)
            {
                _Txt_NR.Text = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["NR"].Value);
                _Txt_FechNR.Text = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Fecha NR"].Value);
                _Str_Proveedor = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["cproveedor"].Value);
                _Str_NombProveedor = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Proveedor"].Value);
                _Mtd_ActualizarDetalle(Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["NR"].Value));
                _Tb_Tab.SelectedIndex = 1;
            }
        }

        private void _Bt_Quitar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Txt_ND.Text.Trim().Length > 0)
            {
                if (_Mtd_ExisteND(_Txt_ND.Text.Trim()))
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_ActualizarInformacion(_Txt_NR.Text.Trim(), _Txt_ND.Text.Trim());
                    _Mtd_Actualizar();
                    _Tb_Tab.SelectedIndex = 0;
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                    Cursor = Cursors.Default;
                    MessageBox.Show("La operación ha sido realizada exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("La ND que introdujo no existe. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _Txt_ND.SelectAll();
                    _Txt_ND.Focus();
                }
            }
            else
            { _Er_Error.SetError(_Txt_ND, "Información requerida!!!"); }
        }

        private void _Bt_Generar_Click(object sender, EventArgs e)
        {
            Frm_NotaDebito _Frm = new Frm_NotaDebito(true, _Txt_NR.Text.Trim(), _Str_Proveedor, _Str_NombProveedor);
            _Frm.Name = "NotaDebito_Temp";
            _Frm.MdiParent = this.MdiParent;
            _Frm.Show();
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.PerformClick();
            this.Close();
        }
    }
}
