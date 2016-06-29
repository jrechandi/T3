using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_TipoTransporte : Form
    {
        public Frm_TipoTransporte()
        {
            InitializeComponent();
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
        public int _Mtd_Entrada()
        {
            string _Str_Cadena = "SELECT cttransporte FROM TTTRANSPORTE ORDER BY CAST(cttransporte AS INTEGER) DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString().Trim()) + 1;
            }
        }
        private void Frm_TipoTransporte_Load(object sender, EventArgs e)
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Tipo");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cttransporte";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "SELECT cttransporte AS Tipo,cname as Descripción,dbo.Fnc_Formatear(climitebs) as [Límite de Bs.] from TTTRANSPORTE where 0=0";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Tipo de Transporte", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            _Mtd_Actualizar();
            _Mtd_Color_Estandar(this);
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda(_Txt_Bs);
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        public void _Mtd_Ini()
        {
            _Txt_Tipo.Text = "";
            _Txt_Descripcion.Text = "";
            _Txt_Bs.Text = "";
            _Mtd_Habilitar();
            _Txt_Tipo.Enabled = true;
        }
        public void _Mtd_Habilitar()
        {
            _Txt_Tipo.Enabled = false;
            _Txt_Descripcion.Enabled = true;
            _Txt_Bs.Enabled = true;
        }

        private void Frm_TipoTransporte_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Txt_TpoFind.Text = "PA";
            CONTROLES._Ctrl_Buscar._Er_Control_Error = _Er_Error;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            //____________________________________________
            if (!_Txt_Descripcion.Enabled & _Txt_Descripcion.Text.Trim().Length > 0)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
            }
            else if (!_Txt_Tipo.Enabled & _Txt_Tipo.Text.Trim().Length > 0 & _Txt_Descripcion.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
            }
            else if (_Txt_Tipo.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            }
            //_____________________________________________
        }

        private void Frm_TipoTransporte_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        public void _Mtd_Nuevo()
        {
            _Er_Error.Dispose();
            _Mtd_Ini();
            _Tb_Tab.SelectedIndex = 1;
            _Txt_Descripcion.Focus();
        }
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            _Txt_Tipo.Text = _Mtd_Entrada().ToString();
            if (_Txt_Tipo.Text.Trim().Length > 0 & _Txt_Descripcion.Text.Trim().Length > 0 & _Txt_Bs.Text.Trim().Length > 0)
            {
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TTTRANSPORTE where cttransporte='" + _Txt_Tipo.Text.Trim() + "'"))
                {
                    MessageBox.Show("El registro ya existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    string _Str_Cadena = "insert into TTTRANSPORTE (cttransporte,cname,climitebs) values('" + _Txt_Tipo.Text.Trim().ToUpper() + "','" + _Txt_Descripcion.Text.Trim().ToUpper() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Bs.Text.Trim())) + "')";
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
                if (_Txt_Tipo.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Tipo, "Iformación requerida!!!"); }
                if (_Txt_Descripcion.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Descripcion, "Iformación requerida!!!"); }
                if (_Txt_Bs.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Bs, "Iformación requerida!!!"); }
                return false;
            }
        }
        public bool _Mtd_Editar()
        {
            _Er_Error.Dispose();
            if (_Txt_Tipo.Text.Trim().Length > 0 & _Txt_Descripcion.Text.Trim().Length > 0 & _Txt_Bs.Text.Trim().Length > 0)
            {
                string _Str_Cadena = "UPDATE TTTRANSPORTE Set cttransporte='" + _Txt_Tipo.Text.Trim().ToUpper() + "',cname='" + _Txt_Descripcion.Text.Trim().ToUpper() + "',climitebs='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Bs.Text.Trim())) + "' where cttransporte='" + _Txt_Tipo.Text.Trim() + "'";
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
                if (_Txt_Tipo.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Tipo, "Iformación requerida!!!"); }
                if (_Txt_Descripcion.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Descripcion, "Iformación requerida!!!"); }
                if (_Txt_Bs.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Bs, "Iformación requerida!!!"); }
                return false;
            }
        }
        public bool _Mtd_Eliminar()
        {
            DialogResult eli = MessageBox.Show("Esta seguro de Eliminar el registro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (eli == DialogResult.Yes)
            {
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia("Delete from TTTRANSPORTE where cttransporte='" + _Txt_Tipo.Text.Trim().ToUpper() + "'");
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
        private void _Mtd_Actualizar()
        {
            string _Str_Cadena = "SELECT cttransporte AS Tipo,cname as Descripción,dbo.Fnc_Formatear(climitebs) as [Límite de Bs.] from TTTRANSPORTE ORDER BY CAST(cttransporte AS INTEGER) ";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Deshabilitar_Todo()
        {
            _Txt_Tipo.Enabled = false;
            _Txt_Descripcion.Enabled = false;
            _Txt_Bs.Enabled = false;
        }

        private void _Tb_Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                Cursor = Cursors.WaitCursor;
                _Er_Error.Dispose();
                _Mtd_Deshabilitar_Todo();
                _Txt_Tipo.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0,e.RowIndex);
                _Txt_Descripcion.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                _Txt_Bs.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, e.RowIndex);
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                _Tb_Tab.SelectedIndex = 1;
                Cursor = Cursors.Default;
            }
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_Txt_Descripcion.Text.Trim().Length == 0 & !_Txt_Descripcion.Enabled & e.TabPageIndex != 0)
            { e.Cancel = true; }
        }

        private void _Dg_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex>-1)
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