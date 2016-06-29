using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_NRNCND : Form
    {
        public Frm_NRNCND()
        {
            InitializeComponent();
        }
        string _Str_Cadena_Consulta_Formato="";
        string[] _Str_Codigo_Descripcion;
        int _Int_Form = 0;
        public Frm_NRNCND(string _P_Str_CadenaSql, string[] _P_Str_Codigo_Descripcion, string _P_Str_Cabecera, ToolStripMenuItem[] _P_Tsm_Menu, int _P_Int_Form)
        {
            InitializeComponent();
            _Str_Cadena_Consulta_Formato = _P_Str_CadenaSql;
            _Str_Codigo_Descripcion = _P_Str_Codigo_Descripcion;
            _Lb_Etiquea.Text = _P_Str_Cabecera;
            toolStripSplitButton1.DropDownItems.Clear();
            int _Int_i = 0;
            foreach (ToolStripMenuItem _Tsm_Item in _P_Tsm_Menu)
            {
                _Tsm_Item.Click += new EventHandler(_Tsm_Item_Click);
                _Tsm_Item.Tag = _Int_i;
                _Int_i++;
            }
            toolStripSplitButton1.DropDownItems.AddRange(_P_Tsm_Menu);
            _Int_Form = _P_Int_Form;
        }
        void _Tsm_Item_Click(object sender, EventArgs e)
        {
            _Int_Pos = Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
        }
        private void Frm_NRNCND_Load(object sender, EventArgs e)
        {
            DataSet _Ds_Data = new DataSet();
            _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena_Consulta_Formato);
            _Dg_Datagrid.DataSource = _Ds_Data.Tables[0]; toolStripComboBox1.Text = ""; _Int_Pos = -1;
        }
        public void _Mtd_filtrar_Grid()
        {
            try
            {
                DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena_Consulta_Formato + " AND " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " LIKE '%" + toolStripComboBox1.Text + "%' ORDER BY " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " ASC");
                _Dg_Datagrid.DataSource = _Ds_Data.Tables[0];
            }
            catch { }
        }
        private void _Bt_actualizar_Click(object sender, EventArgs e)
        {
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena_Consulta_Formato);
            try { _Dg_Datagrid.DataSource = _Ds_Data.Tables[0]; toolStripComboBox1.Text = ""; _Int_Pos = -1; }
            catch { }
        }
        int _Int_Pos = -1;
        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            if (_Int_Pos == -1)
            { MessageBox.Show("Debe seleccionar el criterio de la busqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else
            { _Mtd_filtrar_Grid(); }
        }

        private void _Dg_Datagrid_DoubleClick(object sender, EventArgs e)
        {
            if (_Dg_Datagrid.Rows.Count > 0)
            {
                string _Str_Cadena = "";
                DataSet _Ds = new DataSet();
                this.Cursor = Cursors.WaitCursor;
                if (_Int_Form == 1)
                {
                    _Str_Cadena = "Select cproveedor,cidrecepcion,cnumdocu,cfechadocu from vst_consultanotarecepcionmaestra where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotrecepc='" + _Dg_Datagrid.Rows[_Dg_Datagrid.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        Frm_NotaRecepcion _Frm = new Frm_NotaRecepcion(_Ds.Tables[0].Rows[0][0].ToString(), _Ds.Tables[0].Rows[0][1].ToString(), _Ds.Tables[0].Rows[0][2].ToString(), _Ds.Tables[0].Rows[0][3].ToString(), true);
                        _Frm.MdiParent = this.MdiParent;
                        _Frm.Show();
                    }
                }
                if (_Int_Form == 2)
                {
                    _Str_Cadena = "Select cidnotadebitocxp,cproveedor,cnumdocu from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Dg_Datagrid.Rows[_Dg_Datagrid.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        Frm_NotaDebito _Frm = new Frm_NotaDebito(_Ds.Tables[0].Rows[0][0].ToString(), _Ds.Tables[0].Rows[0][1].ToString(), _Ds.Tables[0].Rows[0][2].ToString());
                        _Frm.MdiParent = this.MdiParent;
                        _Frm.Show();
                    }
                }
                if (_Int_Form == 3)
                {
                    _Str_Cadena = "Select cidnotacreditocxp,cproveedor,cnumdocu from TNOTACREDICP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotacreditocxp='" + _Dg_Datagrid.Rows[_Dg_Datagrid.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        Frm_NotaCredito _Frm = new Frm_NotaCredito(_Ds.Tables[0].Rows[0][0].ToString(), _Ds.Tables[0].Rows[0][1].ToString(), _Ds.Tables[0].Rows[0][2].ToString());
                        _Frm.MdiParent = this.MdiParent;
                        _Frm.Show();
                    }
                }
                if (_Int_Form == 4)
                {
                    _Str_Cadena = "Select cproveedor,cidrecepcion,cnumdocu,cfechadocu from vst_consultanotarecepcionmaestra where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotrecepc='" + _Dg_Datagrid.Rows[_Dg_Datagrid.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        Frm_NotaRecepcion _Frm = new Frm_NotaRecepcion(_Ds.Tables[0].Rows[0][0].ToString(), _Ds.Tables[0].Rows[0][1].ToString(), _Ds.Tables[0].Rows[0][2].ToString(), _Ds.Tables[0].Rows[0][3].ToString(), 1);
                        _Frm.MdiParent = this.MdiParent;
                        _Frm.Show();
                    }
                }
                this.Cursor = Cursors.Default;
                this.Close();
            }
        }

        private void Frm_NRNCND_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Dg_Datagrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
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