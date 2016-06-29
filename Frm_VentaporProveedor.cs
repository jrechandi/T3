using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_VentaporProveedor : Form
    {
        public Frm_VentaporProveedor()
        {
            InitializeComponent();
        }

        private void Frm_VentaporProveedor_Load(object sender, EventArgs e)
        {
            _Mtd_Refrescar();
        }

        private void _bt_Agregar_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid1.Rows.Count > 0)
            {
                Frm_Mantenimientos fr= new Frm_Mantenimientos(this, _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString(), 1);
                fr.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe selecionar un grupo de ventas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void _Mtd_Evento()
        {   
            string _Str_Cadena = "SELECT TPROVEEDOR.cproveedor as Código, TPROVEEDOR.c_nomb_comer as Descripción FROM TPROVEEDOR INNER JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE (TGRUPPROVEE.cdelete = 0) AND " + "(TGRUPPROVEE.ccompany ='" + Frm_Padre._Str_Comp + "')" + " and (TGRUPPROVEE.cgrupovta='" + _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid2.DataSource = _Ds.Tables[0];
            _Dg_Grid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Refrescar()
        {
            string _Str_Cadena = "select cgrupovta as [Código],cname as Descripción from TGRUPOVTAM where cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid1.DataSource = _Ds.Tables[0];
            _Dg_Grid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid2.DataSource = null;
        }

        private void _Bt_Actualizar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Refrescar();
            Cursor = Cursors.Default;
        }
        private void _Mtd_Eliminar()
        {
            Program._MyClsCnn._mtd_conexion._Mtd_modificar("TGRUPPROVEE", "cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "', cdelete='1'", "ccompany='" + Frm_Padre._Str_Comp + "' and cgrupovta='" + _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "' and cproveedor='" + _Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'");
        }

        private void _Bt_Eliminar_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid2.Rows.Count > 0)
            {
                DialogResult eli = MessageBox.Show("Esta seguro de Eliminar el registro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (eli == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_Eliminar();
                    _Mtd_Evento();
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                MessageBox.Show("Debe selecionar algún Proveedor", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
        }

        private void _Dg_Grid1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid1.Rows.Count > 0)
            {
                string _Str_Cadena = "SELECT TPROVEEDOR.cproveedor as Código, TPROVEEDOR.c_nomb_comer as Descripción FROM TPROVEEDOR INNER JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE (TGRUPPROVEE.cdelete = 0) AND " + "(TGRUPPROVEE.ccompany ='" + Frm_Padre._Str_Comp + "')" + " and (TGRUPPROVEE.cgrupovta='" + _Dg_Grid1.Rows[_Dg_Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "')";
                DataSet j = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Dg_Grid2.DataSource = j.Tables[0];
            }
        }
    }
}