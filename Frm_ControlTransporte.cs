using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ControlTransporte : Form
    {
        int _Int_Estatus = 0;
        string _Str_ThisText = "";
        public Frm_ControlTransporte()
        {
            InitializeComponent();
            _Str_ThisText = this.Text;
            _Mtd_Color_Estandar(this);
            _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
        }
        public Frm_ControlTransporte(int _P_Int_Estatus)
        {
            InitializeComponent();
            _Str_ThisText = this.Text;
            _Mtd_Color_Estandar(this);
            _Int_Estatus = _P_Int_Estatus;
            _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
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
        private void _Mtd_Actualizar(int _P_Int_Estatus, string _P_Str_Placa)
        {
            string _Str_Cadena = "";
            if (_P_Str_Placa.Trim().Length == 0)
            {
                if (_P_Int_Estatus == 0)
                { _Str_Cadena = "Select cplaca,cmarca,cmodelo,cname,ccapcarg,cocupado,cesperando,CASE WHEN exists(select cplaca from TGUIADESPACHOM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cliqguidespacho='0' and TGUIADESPACHOM.cplaca=VST_CONTROLTRANSPORTE.cplaca) THEN '1' WHEN exists(select cplaca from TPRECARGAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimprimeguiadesp='0' and TPRECARGAM.cplaca=VST_CONTROLTRANSPORTE.cplaca) THEN '2' ELSE '3' END as Estatus from VST_CONTROLTRANSPORTE where (cocupado='1' and cesperando='0' and exists(select cplaca from TGUIADESPACHOM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cliqguidespacho='0' and TGUIADESPACHOM.cplaca=VST_CONTROLTRANSPORTE.cplaca)) or (cocupado='1' and cesperando='0' and exists(select cplaca from TPRECARGAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimprimeguiadesp='0' and TPRECARGAM.cplaca=VST_CONTROLTRANSPORTE.cplaca)) or (cocupado='0' and cesperando='1') order by Estatus"; }
                else if (_P_Int_Estatus == 1)
                { _Str_Cadena = "Select cplaca,cmarca,cmodelo,cname,ccapcarg,cocupado,cesperando,'1' as Estatus from VST_CONTROLTRANSPORTE where (cocupado='1' and cesperando='0' and exists(select cplaca from TGUIADESPACHOM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cliqguidespacho='0' and TGUIADESPACHOM.cplaca=VST_CONTROLTRANSPORTE.cplaca)) order by cplaca"; }
                else if (_P_Int_Estatus == 2)
                { _Str_Cadena = "Select cplaca,cmarca,cmodelo,cname,ccapcarg,cocupado,cesperando,'2' as Estatus from VST_CONTROLTRANSPORTE where (cocupado='1' and cesperando='0' and exists(select cplaca from TPRECARGAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimprimeguiadesp='0' and TPRECARGAM.cplaca=VST_CONTROLTRANSPORTE.cplaca)) order by cplaca"; }
                else if (_P_Int_Estatus == 3)
                { _Str_Cadena = "Select cplaca,cmarca,cmodelo,cname,ccapcarg,cocupado,cesperando,'3' as Estatus from VST_CONTROLTRANSPORTE where (cocupado='0' and cesperando='1') order by cplaca"; }
            }
            else
            {
                if (_P_Int_Estatus == 0)
                { _Str_Cadena = "Select cplaca,cmarca,cmodelo,cname,ccapcarg,cocupado,cesperando,CASE WHEN exists(select cplaca from TGUIADESPACHOM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cliqguidespacho='0' and TGUIADESPACHOM.cplaca=VST_CONTROLTRANSPORTE.cplaca) THEN '1' WHEN exists(select cplaca from TPRECARGAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimprimeguiadesp='0' and TPRECARGAM.cplaca=VST_CONTROLTRANSPORTE.cplaca) THEN '2' ELSE '3' END as Estatus from VST_CONTROLTRANSPORTE where (cocupado='1' and cesperando='0' and exists(select cplaca from TGUIADESPACHOM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cliqguidespacho='0' and TGUIADESPACHOM.cplaca=VST_CONTROLTRANSPORTE.cplaca)) or (cocupado='1' and cesperando='0' and exists(select cplaca from TPRECARGAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimprimeguiadesp='0' and TPRECARGAM.cplaca=VST_CONTROLTRANSPORTE.cplaca)) or (cocupado='0' and cesperando='1') and cplaca LIKE '" + _P_Str_Placa + "%' order by Estatus"; }
                else if (_P_Int_Estatus == 1)
                { _Str_Cadena = "Select cplaca,cmarca,cmodelo,cname,ccapcarg,cocupado,cesperando,'1' as Estatus from VST_CONTROLTRANSPORTE where (cocupado='1' and cesperando='0' and exists(select cplaca from TGUIADESPACHOM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cliqguidespacho='0' and TGUIADESPACHOM.cplaca=VST_CONTROLTRANSPORTE.cplaca)) and cplaca LIKE '" + _P_Str_Placa + "%' order by cplaca"; }
                else if (_P_Int_Estatus == 2)
                { _Str_Cadena = "Select cplaca,cmarca,cmodelo,cname,ccapcarg,cocupado,cesperando,'2' as Estatus from VST_CONTROLTRANSPORTE where (cocupado='1' and cesperando='0' and exists(select cplaca from TPRECARGAM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimprimeguiadesp='0' and TPRECARGAM.cplaca=VST_CONTROLTRANSPORTE.cplaca)) and cplaca LIKE '" + _P_Str_Placa + "%' order by cplaca"; }
                else if (_P_Int_Estatus == 3)
                { _Str_Cadena = "Select cplaca,cmarca,cmodelo,cname,ccapcarg,cocupado,cesperando,'3' as Estatus from VST_CONTROLTRANSPORTE where (cocupado='0' and cesperando='1') and cplaca LIKE '" + _P_Str_Placa + "%' order by cplaca"; }
            }
            Cursor = Cursors.WaitCursor;
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
            _Dg_Grid.ClearSelection();
            //--------------------------------------------------------------------
            if (_P_Int_Estatus == 0)
            { this.Text = _Str_ThisText + " (Todos los estatus)"; }
            else if (_P_Int_Estatus == 1)
            { this.Text = _Str_ThisText + " (Despachando)"; }
            else if (_P_Int_Estatus == 2)
            { this.Text = _Str_ThisText + " (Cargando)"; }
            else if (_P_Int_Estatus == 3)
            { this.Text = _Str_ThisText + " (Desocupado)"; }
        }

        private void Frm_ControlTransporte_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Dg_Grid.ClearSelection();
        }

        private void _Tool_ConsTodos_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 0;
            _Tool_Consulta.Text = "";
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
            Cursor = Cursors.Default;
        }

        private void _Tool_ConsDespa_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 1;
            _Tool_Consulta.Text = "";
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
            Cursor = Cursors.Default;
        }

        private void _Tool_ConsCarg_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 2;
            _Tool_Consulta.Text = "";
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
            Cursor = Cursors.Default;
        }

        private void _Tool_ConsDeso_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 3;
            _Tool_Consulta.Text = "";
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
            Cursor = Cursors.Default;
        }

        private void _Tool_BusTodos_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 0;
        }

        private void _Tool_BusDespa_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 1;
        }

        private void _Tool_BusCarg_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 2;
        }

        private void _Tool_BusDeso_Click(object sender, EventArgs e)
        {
            _Int_Estatus = 3;
        }

        private void _ToolBt_Actualizar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
            Cursor = Cursors.Default;
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            _Tool_Consulta.Text = "";
            _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
        }

        private void _Tool_Consulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                _Mtd_Actualizar(_Int_Estatus, _Tool_Consulta.Text);
            }
        }
        private void _Dg_Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Estatus"].Value == null)
                { _Dg_Grid.Rows[e.RowIndex].Cells["Estatus"].Value = 0; }
                if (_Dg_Grid.Rows[e.RowIndex].Cells["cocupado"].Value == null)
                { _Dg_Grid.Rows[e.RowIndex].Cells["cocupado"].Value = 0; }
                if (_Dg_Grid.Rows[e.RowIndex].Cells["cesperando"].Value == null)
                { _Dg_Grid.Rows[e.RowIndex].Cells["cesperando"].Value = 0; }
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Estatus"].Value.ToString().Trim() == "1" & _Dg_Grid.Rows[e.RowIndex].Cells["cocupado"].Value.ToString().Trim() == "1" & _Dg_Grid.Rows[e.RowIndex].Cells["cesperando"].Value.ToString().Trim() == "0")
                { e.Value = new Bitmap(GetType(), "Multimedia._Tool_Despachando.ico"); }
                else if (_Dg_Grid.Rows[e.RowIndex].Cells["Estatus"].Value.ToString().Trim() == "2" & _Dg_Grid.Rows[e.RowIndex].Cells["cocupado"].Value.ToString().Trim() == "1" & _Dg_Grid.Rows[e.RowIndex].Cells["cesperando"].Value.ToString().Trim() == "0")
                { e.Value = new Bitmap(GetType(), "Multimedia._Tool_Precarga.ico"); }
                else
                { e.Value = new Bitmap(GetType(), "Multimedia._Tool_Desocupado.ico"); }
            }
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Grid.CurrentCell == null)
            { e.Cancel = true; }
            else
            {
                if (!(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Estatus"].Value.ToString().Trim() == "1" & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cocupado"].Value.ToString().Trim() == "1" & _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cesperando"].Value.ToString().Trim() == "0"))
                { e.Cancel = true; }
            }
        }

        private void informaciónDelTransporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                Frm_Ttransporte _Frm = new Frm_Ttransporte(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[1].Value.ToString());
                _Frm.ShowDialog(this);
            }
        }

        private void Frm_ControlTransporte_Activated(object sender, EventArgs e)
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
    }
}