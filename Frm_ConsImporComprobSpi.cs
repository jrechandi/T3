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
    public partial class Frm_ConsImporComprobSpi : Form
    {
        public Frm_ConsImporComprobSpi()
        {
            InitializeComponent();
            _Mtd_Actualizar();
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
        private void _Mtd_Actualizar()
        {
            Cursor = Cursors.WaitCursor;
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Id Captura");
            _Tsm_Menu[1] = new ToolStripMenuItem("Fecha");
            _Tsm_Menu[2] = new ToolStripMenuItem("Comprobante");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "cidcapturaspi";
            _Str_Campos[1] = "cfechacaptura";
            _Str_Campos[2] = "codigo";
            string _Str_Cadena = "SELECT DISTINCT cidcapturaspi As [Id Captura],cfechacaptura AS Fecha,codigo as Comprobante FROM VST_CALINCIMPORTSPI WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Capturas de SPI", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }
        private void _Mtd_ActualizarDetalle(string _P_Str_IdCapturaSpi)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT cidcapturaspi,ccount As Cuenta,cdescrip As Descripción,dbo.Fnc_Formatear(cdebe) As Debe,dbo.Fnc_Formatear(chaber) As Haber FROM VST_CALINCIMPORTSPI WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcapturaspi='" + _P_Str_IdCapturaSpi + "'";
            _Str_Cadena += " UNION ";
            _Str_Cadena += "SELECT cidcapturaspi,'TOTAL:','',dbo.Fnc_Formatear(SUM(cdebe)) As Debe,dbo.Fnc_Formatear(SUM(chaber)) As Haber FROM VST_CALINCIMPORTSPI WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcapturaspi='" + _P_Str_IdCapturaSpi + "' GROUP BY cidcapturaspi ORDER BY cidcapturaspi";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Detalle.Rows.Clear();
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Dg_Detalle.Rows.Add(new object[] { _Row[1].ToString().Trim(), _Row[2].ToString().Trim(), _Row[3].ToString().Trim(), _Row[4].ToString().Trim() });
            }
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Detalle.Rows[_Dg_Detalle.RowCount - 1].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Cursor = Cursors.Default;
        }
        private void Frm_ConsImporComprobSpi_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Mtd_Color_Estandar(this);
        }

        private void Frm_ConsImporComprobSpi_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            { e.Cancel = _Txt_Captura.Text.Trim().Length == 0; }
            else
            { _Txt_Captura.Text = ""; _Txt_Fecha.Text = ""; _Txt_Comprobante.Text = ""; }
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count == 1)
            {
                _Txt_Captura.Text = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Id Captura"].Value).Trim();
                _Txt_Fecha.Text = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Fecha"].Value).Trim();
                _Txt_Comprobante.Text = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Comprobante"].Value).Trim();
                _Mtd_ActualizarDetalle(_Txt_Captura.Text);
                _Tb_Tab.SelectedIndex = 1;
            }
        }
    }
}
