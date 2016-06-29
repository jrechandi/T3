using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_RutasSegunPref : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_RutasSegunPref()
        {
            InitializeComponent();
        }
        private void _Mtd_Actualizar_Dg_GridRutas()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "EXEC PA_RUTASSEGUNPREF '" + Frm_Padre._Str_GroupComp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_GridRutas.DataSource = _Ds.Tables[0];
            _Dg_GridRutas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (_Dg_GridRutas.CurrentCell != null)
            {
                Frm_RutaDespacho _Frm = new Frm_RutaDespacho(_Dg_GridRutas.Rows[_Dg_GridRutas.CurrentCell.RowIndex].Cells[0].Value.ToString());
                _Frm.MdiParent = this.MdiParent;
                _Frm.Show();
            }
        }

        private void Frm_RutasSegunPref_Load(object sender, EventArgs e)
        {
            _Mtd_Actualizar_Dg_GridRutas();
        }
        private void _Link_Exp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_Dg_GridRutas.RowCount > 0)
            {
                SaveFileDialog _Sfd_1 = new SaveFileDialog();
                _Sfd_1.FileName = "RutasSegPref.xls";
                if (_Sfd_1.ShowDialog() == DialogResult.OK)
                {
                    if (_Sfd_1.FileName.Trim().Length > 0)
                    {
                        Cursor = Cursors.WaitCursor;
                        _Cls_VariosMetodos._Mtd_GridViewtoExcel(_Dg_GridRutas, _Sfd_1.FileName);
                        Cursor = Cursors.Default;
                        MessageBox.Show("Exportación Completa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}