using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_GrupodeVentas : Form
    {
        public Frm_GrupodeVentas()
        {
            InitializeComponent();
        }
        Control[] _Ctrl_Controles = new Control[2];
        private void Frm_GrupodeVentas_Load(object sender, EventArgs e)
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cgrupovta";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "Select cgrupovta as Código,cname as Descripción from TGRUPOVTAM where cdelete='0'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Grupos de Venta", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            _Mtd_Actualizar();
        }
        private void _Mtd_Actualizar()
        {
            string _Str_Cadena = "Select cgrupovta as Código,cname as Descripción from TGRUPOVTAM where cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public void _Mtd_Cancelar()
        {
            _Mtd_Ini();
            _Mtd_Deshabilitar_Todo();
        }
        public void _Mtd_Ini()
        {
            _Txt_Codigo.Text = "";
            _Txt_Descripcion.Text = "";
            _Mtd_Habilitar();
            _Txt_Codigo.Enabled = true;
        }
        public void _Mtd_Habilitar()
        {
            _Txt_Codigo.Enabled = false;
            _Txt_Descripcion.Enabled = true;
        }
        public void _Mtd_BotonesMenu()
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            if (!_Txt_Descripcion.Enabled & _Txt_Descripcion.Text.Trim().Length > 0)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
            }
            else if (!_Txt_Codigo.Enabled & _Txt_Codigo.Text.Trim().Length > 0 & _Txt_Descripcion.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
            }
            else if (_Txt_Codigo.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            }
        }
        private void Frm_GrupodeVentas_Activated(object sender, EventArgs e)
        {
            _Mtd_BotonesMenu();
            //CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            //CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            //CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            //CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            //CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
            //_Ctrl_Controles[0] = _Txt_Codigo;
            //_Ctrl_Controles[1] = _Txt_Descripcion;
            //CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            //CLASES._Cls_Varios_Metodos _Cls_CL = new T3.CLASES._Cls_Varios_Metodos(_Ctrl_Controles);
            //_Cls_CL._Mtd_Foco();
            ////____________________________________________
            //if (!_Txt_Descripcion.Enabled & _Txt_Descripcion.Text.Trim().Length > 0)
            //{
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
            //}
            //else if (!_Txt_Codigo.Enabled & _Txt_Codigo.Text.Trim().Length > 0 & _Txt_Descripcion.Enabled)
            //{
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            //    CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
            //}
            //else if (_Txt_Codigo.Enabled)
            //{
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            //}
            ////_____________________________________________
        }

        private void Frm_GrupodeVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        public void _Mtd_Nuevo()
        {
            _Er_Error.Dispose();
            _Mtd_Ini();
            _Tb_Tab.SelectedIndex = 1;
            _Txt_Codigo.Focus();
        }
        private void _Mtd_Deshabilitar_Todo()
        {
            _Txt_Codigo.Enabled = false;
            _Txt_Descripcion.Enabled = false;
        }
        public bool _Mtd_Guardar()
        {
            if (_Txt_Codigo.Text.Trim().Length > 0 & _Txt_Descripcion.Text.Trim().Length > 0)
            {
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TGRUPOVTAM where cgrupovta='" + _Txt_Codigo.Text.Trim() + "'"))
                {
                    MessageBox.Show("El registro ya existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    string _Str_Cadena = "insert into TGRUPOVTAM (cgrupovta,cname,cdateadd,cuseradd,cdelete) values('" + _Txt_Codigo.Text.Trim().ToUpper() + "','" + _Txt_Descripcion.Text.Trim().ToUpper() + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    MessageBox.Show("El registro fue agregado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_Actualizar();
                    _Mtd_Ini();
                    _Mtd_Deshabilitar_Todo();
                    _Tb_Tab.SelectedIndex = 0;
                    _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    _Er_Error.Dispose();
                    return true;
                }
            }
            else
            {
                if (_Txt_Codigo.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Codigo, "Iformación requerida!!!"); }
                if (_Txt_Descripcion.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Descripcion, "Iformación requerida!!!"); }
                return false;
            }
        }
        public bool _Mtd_Editar()
        {
            if (_Txt_Codigo.Text.Trim().Length > 0 & _Txt_Descripcion.Text.Trim().Length > 0)
            {
                string _Str_Cadena = "UPDATE TGRUPOVTAM Set cgrupovta='" + _Txt_Codigo.Text.Trim().ToUpper() + "',cname='" + _Txt_Descripcion.Text.Trim().ToUpper() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0' where cgrupovta='" + _Txt_Codigo.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                MessageBox.Show("El registro fue modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Actualizar();
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
                _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Er_Error.Dispose();
                return true;
            }
            else
            {
                if (_Txt_Codigo.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Codigo, "Iformación requerida!!!"); }
                if (_Txt_Descripcion.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Descripcion, "Iformación requerida!!!"); }
                return false;
            }
        }
        public bool _Mtd_Eliminar()
        {
            DialogResult eli = MessageBox.Show("Esta seguro de Eliminar el registro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (eli == DialogResult.Yes)
            {
                string _Str_Cadena = "UPDATE TGRUPOVTAM Set cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' where cgrupovta='" + _Txt_Codigo.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                MessageBox.Show("El registro fue eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Actualizar();
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
            }
            else
            {
                _Mtd_Actualizar();
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
            }
            return true;
        }

        private void _Dg_Grid_DoubleClick(object sender, EventArgs e)
        {
            if (_Dg_Grid.Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Er_Error.Dispose();
                _Mtd_Deshabilitar_Todo();
                _Txt_Codigo.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, _Dg_Grid.CurrentCell.RowIndex);
                _Txt_Descripcion.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, _Dg_Grid.CurrentCell.RowIndex);
                _Mtd_BotonesMenu();
                Cursor = Cursors.Default;
                _Tb_Tab.SelectedIndex = 1;
            }
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_Txt_Descripcion.Text.Trim().Length == 0 & !_Txt_Descripcion.Enabled & e.TabPageIndex != 0)
            { e.Cancel = true; }
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