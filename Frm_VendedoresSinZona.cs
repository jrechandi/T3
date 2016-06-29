using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_VendedoresSinZona : Form
    {
        public Frm_VendedoresSinZona()
        {
            InitializeComponent();
            _Mtd_Color_Estandar(_Tb_Tab);
            _Mtd_Actualizar();
        }
        public Frm_VendedoresSinZona(string _P_Str_Vendedor,string _P_Str_Grupo)
        {
            InitializeComponent();
            _Mtd_Color_Estandar(_Tb_Tab);
            _Mtd_Actualizar();
            int _Int_Row = 0;
            bool _Bol_Encontrado = false;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Cells[0].Value.ToString().Trim() == _P_Str_Vendedor.Trim() & _Dg_Row.Cells[3].Value.ToString().Trim() == _P_Str_Grupo.Trim())
                { _Bol_Encontrado = true; break; }
                _Int_Row++;
            }
            if (_Bol_Encontrado)
            {
                DataGridViewCell _Dg_Cel = _Dg_Grid.Rows[_Int_Row].Cells[0];
                _Dg_Grid.CurrentCell = _Dg_Cel;
                _Mtd_RowHeaderMouseClick();
            }
        }
        private void _Mtd_RowHeaderMouseClick()
        {
            _Txt_Codigo.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim();
            _Txt_Nombre.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[1].Value.ToString().Trim();
            _Txt_Grupo.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[2].Value.ToString().Trim();
            _Str_Grupovta = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString().Trim();
            _Mtd_Actualizar_Zonas(_Str_Grupovta);
            _Tb_Tab.SelectedIndex = 1;
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
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Nombre");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cvendedor";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "select cvendedor as Código,cname as Nombre,(Select top 1 cname from TGRUPOVTAM where TGRUPOVTAM.cgrupovta=TVENDEDOR.c_grupo_vta) as [G. Ventas],c_grupo_vta from TVENDEDOR where c_activo='1' AND cdelete='0' and c_tipo_vend='1' and ccompany='" + Frm_Padre._Str_Comp + "' AND NOT EXISTS(SELECT * FROM  TZONAVENDEDOR WHERE (cdelete='0') AND (TVENDEDOR.ccompany =TZONAVENDEDOR.ccompany) AND (TVENDEDOR.cvendedor = TZONAVENDEDOR.cvendedor))";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Vendedores", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.Columns[3].Visible = false;
        }
        private void _Mtd_Actualizar_Zonas(string _P_Str_Grupo)
        {
            string _Str_Cadena = "Select c_zona as Zona,cname as Descripción from TZONAVENTA where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and cgrupovta='" + _P_Str_Grupo + "' AND NOT EXISTS(SELECT * FROM  TZONAVENDEDOR WHERE (cdelete='0') AND (TZONAVENTA.ccompany =TZONAVENDEDOR.ccompany) AND (TZONAVENTA.c_zona = TZONAVENDEDOR.c_zona))";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Zonas.DataSource = _Ds.Tables[0];
            _Dg_Zonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Agregar2(string _P_Str_Codigo,string _P_Str_Zona)
        {
            string _Str_Cadena = "Select cdelete from TZONAVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _P_Str_Zona + "' and cvendedor='" + _P_Str_Codigo + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                _Str_Cadena = "'" + Frm_Padre._Str_Comp + "','" + _P_Str_Zona + "','" + _P_Str_Codigo + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0'";
                Program._MyClsCnn._mtd_conexion._Mtd_Insertar("TZONAVENDEDOR", "ccompany,c_zona,cvendedor,cdateadd,cuseradd,cdelete", _Str_Cadena);
            }
            else
            {
                if (_Ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    if (MessageBox.Show("El vendedor (" + _P_Str_Codigo + ") fue eliminado de la zona de ventas (" + _P_Str_Zona + "). ¿Desea volver a agregarlo?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Program._MyClsCnn._mtd_conexion._Mtd_modificar("TZONAVENDEDOR", "cdelete='0',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "'", "ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _P_Str_Zona + "' and cvendedor='" + _P_Str_Codigo + "'");
                    }
                }
            }
            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
        }
        private void Frm_VendedoresSinZona_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
        string _Str_Grupovta = "";
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Txt_Codigo.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                _Txt_Nombre.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                _Txt_Grupo.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, e.RowIndex);
                _Str_Grupovta = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, e.RowIndex);
                _Mtd_Actualizar_Zonas(_Str_Grupovta);
                _Tb_Tab.SelectedIndex = 1;
                Cursor = Cursors.Default;
            }
        }

        private void _Dg_Zonas_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Zonas.Rows.Count > 0)
            {
                if (MessageBox.Show("¿Esta seguro de asignar esta zona a este vendedor?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_Agregar2(_Txt_Codigo.Text.Trim(), _Dg_Zonas.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                    _Mtd_Actualizar();
                    _Dg_Zonas.DataSource = null;
                    _Txt_Codigo.Text = "";
                    _Txt_Grupo.Text = "";
                    _Txt_Nombre.Text = "";
                    _Str_Grupovta = "";
                    _Tb_Tab.SelectedIndex = 0;
                    Cursor = Cursors.Default;
                }
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

        private void _Dg_Zonas_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgZonasInfo.Visible = true;
            }
            else
            {
                _Lbl_DgZonasInfo.Visible = false;
            }
        }

        private void Frm_VendedoresSinZona_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_VendedoresSinZona_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
    }
}