using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_GrupoUsurario : Form
    {
        public Frm_GrupoUsurario()
        {
            InitializeComponent();
        }
        string[] _str_Valores = new string[2];
        string[] _Str_Necesarios = new string[2];
        string[] _Str_Campos = new string[2];
        Control[] _Ctrl_Controles = new Control[2];
        string[] _Str_Where = new string[1];
        string[] _Str_NoRep = new string[1];
        string[] _Str_Deshabi = new string[1];
        int[] _Int_CodDes = new int[2];
        private void Frm_GrupoUsurario_Load(object sender, EventArgs e)
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cgroup";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "Select cgroup as Código,cname as Descripción from TGROUP where cdelete='0'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Grupos", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cgroup as Código,cname as Descripción from TGROUP where cdelete='0'");
            _Dg_Grid.DataSource = _Ds_Data.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            _Mtd_Sorted();
            _Txt_Ccompany.Text = Frm_Padre._Str_Comp;
        }
        public void _Mtd_Sorted()
        {
            for (int _Int_i = 0; _Int_i < _Dg_Grid.Columns.Count; _Int_i++)
            {
                _Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        TextBox _Txt_Ccompany = new TextBox();
        private void Frm_GrupoUsurario_Activated(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Str_Cadena_Consulta_Formato = "Select cgroup as Código,cname as Descripción from TGROUP";
            CONTROLES._Ctrl_Buscar._Str_Cadena_Consulta = "Select cgroup,cname from TGROUP";
            //CONTROLES._Ctrl_Buscar._Str_Cadena_Consulta_Where = "c_id_departamento";
            CONTROLES._Ctrl_Buscar._Str_Tabla = "TGROUP";
            CONTROLES._Ctrl_Buscar._Str_Where_Vista_Grid = "cdelete='0'";
            //-------------------------------------------------------
            _Ctrl_Controles[0] = _Txt_Cod;
            _Ctrl_Controles[1] = _Txt_Des;
            //-------------------------------------------------------
            _Str_Campos[0] = "cgroup";
            _Str_Campos[1] = "cname";
            //------------------------------------------------------
            _Str_Where[0] = "cgroup";
            //-------------------------------------------------------
            _Str_NoRep[0] = "0";
            //-------------------------------------------------------
            _Str_Deshabi[0] = "0";
            //-------------------------------------------------------
            _Int_CodDes[0] = 0;
            _Int_CodDes[1] = 1;
            //-------------------------------------------------------
            CONTROLES._Ctrl_Buscar._Ctrl_Controles = _Ctrl_Controles;
            CONTROLES._Ctrl_Buscar._Str_Campos = _Str_Campos;
            CONTROLES._Ctrl_Buscar._Str_Cadena_Consulta_Where = _Str_Where;
            CONTROLES._Ctrl_Buscar._Er_Control_Error = _Er_Error;
            CONTROLES._Ctrl_Buscar._Dg_Datagrid = _Dg_Grid;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Str_NoseDebeRepetir = _Str_NoRep;
            CONTROLES._Ctrl_Buscar._Int_Codigo_Descripcion = _Int_CodDes;
            CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
            CONTROLES._Ctrl_Buscar._Int_Foco = 0;
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._Str_Deshabilitados = _Str_Deshabi;
            CONTROLES._Ctrl_Buscar._Txt_TpoFind.Text = "N";
            CLASES._Cls_Varios_Metodos _Cls_CL = new T3.CLASES._Cls_Varios_Metodos(_Ctrl_Controles);
            _Cls_CL._Mtd_Foco();
            //____________________________________________
            if (!_Txt_Cod.Enabled & !_Txt_Des.Enabled & _Txt_Cod.Text.Trim().Length>0 & _Txt_Des.Text.Trim().Length>0)
            {
                if (_Dg_Grid.Rows.Count > 0)
                {
                    CONTROLES._Ctrl_Buscar._txt_text.Text = "";
                    CONTROLES._Ctrl_Buscar._txt_text.Text = "cgroup='" + _Txt_Cod.Text + "'";
                }
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar.Enabled = true;
            }
            else if (!_Txt_Cod.Enabled & _Txt_Des.Enabled)
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                if (_Dg_Grid.Rows.Count > 0)
                {
                    CONTROLES._Ctrl_Buscar._txt_text.Text = "";
                    CONTROLES._Ctrl_Buscar._txt_text.Text = "cgroup='" + _Txt_Cod.Text + "'";
                }
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar.Enabled = false;
            }
            else if (_Txt_Cod.Enabled & _Txt_Des.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar.Enabled = false;
            }
            //_____________________________________________
        }
        clslibraryconssa._Cls_Formato Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public void _Mtd_llenar()
        {
            _str_Valores[0] = _Txt_Cod.Text.ToUpper();
            _str_Valores[1] = _Txt_Des.Text.ToUpper();
            //----------------------------------------------
            _Str_Necesarios[0] = "0";
            _Str_Necesarios[1] = "1";
            //------------------------------------------------
            CONTROLES._Ctrl_Buscar._Str_Valores = _str_Valores;
            CONTROLES._Ctrl_Buscar._Str_Necesario = _Str_Necesarios;
        }

        private void Frm_GrupoUsurario_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Dg_Grid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                //CONTROLES._Ctrl_Buscar._txt_text.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString();
                CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
                CONTROLES._Ctrl_Buscar._txt_text.Text = "";
                CONTROLES._Ctrl_Buscar._txt_text.Text = "cgroup='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, _Dg_Grid.CurrentCell.RowIndex) + "'";
                
            }
            catch
            {
            }
            Cursor = Cursors.Default;
        }
        public void _Mtd_Ini()
        {
            _Txt_Cod.Text = "";
            _Txt_Des.Text = "";
        }

        private void _Tb_Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
        }

        private void _Txt_Cod_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
        }

        private void _Txt_Des_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
        }

        private void Frm_GrupoUsurario_Leave(object sender, EventArgs e)
        {
            //inicial _Frm = new inicial();
            //_Frm._Mtd_Crear_menu(_p);
            //_Frm.Dispose();
        }

        private void _Dg_Grid_SelectionChanged(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Txt_UnClick.Text = "cgroup='" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'";
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