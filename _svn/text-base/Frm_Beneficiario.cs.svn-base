using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
namespace T3
{
    public partial class Frm_Beneficiario : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Beneficiario()
        {
            InitializeComponent();
            _Mtd_CargarTipoBeneficiario();
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
        private void Frm_Beneficiario_Load(object sender, EventArgs e)
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Nombre");
            _Tsm_Menu[1] = new ToolStripMenuItem("Apellido");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cnombre";
            _Str_Campos[1] = "capellido";
            string _Str_Cadena = "SELECT cbeneficiario AS Código,crif as Rif,cnombre as Nombres,capellido as Apellidos,cdescripcion as Tipo,ctipobeneficiarioid from VST_T3_BENEFICIARIOS where 0=0";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Beneficiarios", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            _Mtd_Actualizar();
            _Mtd_Color_Estandar(this);
        }
        private void _Mtd_CargarTipoBeneficiario()
        {
            _Cmb_TipoBeneficiario.DataSource = null;
            DataSet _Ds;
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctipobeneficiarioid,cdescripcion FROM TTIPOBENEFICIARIO ORDER BY cdescripcion ASC");
            _Cmb_TipoBeneficiario.DataSource = _Ds.Tables[0];
            _Cmb_TipoBeneficiario.DisplayMember = "cdescripcion";
            _Cmb_TipoBeneficiario.ValueMember = "ctipobeneficiarioid";
            _Cmb_TipoBeneficiario.SelectedIndex = -1;
        }
        public void _Mtd_Ini()
        {
            _Txt_BeneficiarioId.Text = "";
            _Txt_Descripcion.Text = "";
            _Txt_Apellido.Text = "";
            _Cmb_TipoBeneficiario.SelectedIndex=-1;
            _Txt_Rif.Text = "";
            _Rbt_Rif.Checked = true;
            _Mtd_Habilitar();
        }
        public void _Mtd_Habilitar()
        {
            _Txt_BeneficiarioId.Enabled = true;
            _Txt_Descripcion.Enabled = true;
            _Txt_Rif.Enabled = true;
            _Txt_Apellido.Enabled = true;
            _Cmb_TipoBeneficiario.Enabled = true;
            _Pnl_SeleccTipo.Enabled = true;
        }

        private void Frm_Beneficiario_Activated(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_MODIFICAR_BEN"))
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
                else if (!_Txt_BeneficiarioId.Enabled & _Txt_BeneficiarioId.Text.Trim().Length > 0 & _Txt_Descripcion.Enabled)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                }
                else if (_Txt_BeneficiarioId.Enabled)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                }
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
                //_____________________________________________
            }
            else
            {
                CONTROLES._Ctrl_Buscar._Bl_Especial = false;
                CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
            }
        }

        private void Frm_Beneficiario_FormClosing(object sender, FormClosingEventArgs e)
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
            try
            {                
                _Er_Error.Dispose();
                bool _Bol_RegexRif = true;
                System.Text.RegularExpressions.Regex RegexValidation = null;
                if (_Rbt_Rif.Checked)
                {
                    RegexValidation = new System.Text.RegularExpressions.Regex(@"(J|V|P|E|G)\-[0-9]{8}\-[0-9]{1}");
                }
                else
                {
                    RegexValidation = new System.Text.RegularExpressions.Regex(@"(V|E)\-[0-9]{8}");
                }
                _Txt_Rif.Text = _Txt_Rif.Text.ToUpper();
                if (!RegexValidation.IsMatch(_Txt_Rif.Text))
                {
                    _Bol_RegexRif = false;
                }
                if (_Bol_RegexRif && _Txt_Descripcion.Text.Trim().Length > 0 && _Txt_Apellido.Text.Trim().Length > 0 & _Cmb_TipoBeneficiario.SelectedIndex > -1)
                {
                    string _Str_Cadena = "INSERT INTO TBENEFICIARIO (crif,cnombre,capellido,ctipobeneficiarioid,CDATEADD,CUSERADD,CDELETE)";
                    _Str_Cadena += "values('" + _Txt_Rif.Text.Trim().ToUpper() + "','" + _Txt_Descripcion.Text.Trim().ToUpper() + "','" + _Txt_Apellido.Text.Trim().ToUpper() + "','" + _Cmb_TipoBeneficiario.SelectedValue.ToString() + "',GETDATE(),'" + Frm_Padre._Str_Use + "',0)";
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
                else
                {
                    if (!_Bol_RegexRif)
                    {
                        _Er_Error.SetError(_Txt_Rif, "Por favor verifique que el valor introducido en la cédula o rif sea correcto");
                    }
                    if (_Txt_Descripcion.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Descripcion, "Información requerida!!!"); }
                    if (_Txt_Apellido.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Apellido, "Información requerida!!!"); }
                    if (_Cmb_TipoBeneficiario.SelectedIndex < 0) { _Er_Error.SetError(_Cmb_TipoBeneficiario, "Información requerida!!!"); }
                    return false;
                }
            }
            catch(Exception ou)
            {
                if (ou.Message.ToString().IndexOf("IX_TBENEFICIARIO") != -1)
                {
                    MessageBox.Show("Disculpe, ya existe un beneficiario con el rif o cédula "+_Txt_Rif.Text, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return false;
            }
        }
        public bool _Mtd_Editar()
        {
            try
            {
                _Er_Error.Dispose();
                bool _Bol_RegexRif = true;
                System.Text.RegularExpressions.Regex RegexValidation = null;
                if (_Rbt_Rif.Checked)
                {
                    RegexValidation = new System.Text.RegularExpressions.Regex(@"(J|V|P|E|G)\-[0-9]{8}\-[0-9]{1}");
                }
                else
                {
                    RegexValidation = new System.Text.RegularExpressions.Regex(@"(V|E)\-[0-9]{8}");
                }
                _Txt_Rif.Text = _Txt_Rif.Text.ToUpper();
                if (!RegexValidation.IsMatch(_Txt_Rif.Text))
                {
                    _Bol_RegexRif = false;
                }
                if (_Bol_RegexRif && _Txt_Descripcion.Text.Trim().Length > 0 && _Txt_Apellido.Text.Trim().Length > 0 & _Cmb_TipoBeneficiario.SelectedIndex > -1)
                {
                    string _Str_Cadena = "UPDATE TBENEFICIARIO Set capellido='"+_Txt_Apellido.Text+"',cdateupd=getdate(),cuserupd='" + Frm_Padre._Str_Use + "',crif='" + _Txt_Rif.Text.Trim().ToUpper() + "',cnombre='" + _Txt_Descripcion.Text.Trim().ToUpper() + "',ctipobeneficiarioid='" + _Cmb_TipoBeneficiario.SelectedValue.ToString() + "' where cbeneficiario='" + _Txt_BeneficiarioId.Text.Trim() + "'";
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
                    if (!_Bol_RegexRif)
                    {
                        _Er_Error.SetError(_Txt_Rif, "Por favor verifique que el valor introducido en la cédula o rif sea correcto");
                    }
                    if (_Txt_Descripcion.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Descripcion, "Información requerida!!!"); }
                    if (_Txt_Apellido.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Apellido, "Información requerida!!!"); }
                    if (_Cmb_TipoBeneficiario.SelectedIndex < 0) { _Er_Error.SetError(_Cmb_TipoBeneficiario, "Información requerida!!!"); }
                    return false;
                }
            }
            catch (Exception ou)
            {
                if (ou.Message.ToString().IndexOf("IX_TBENEFICIARIO") != -1)
                {
                    MessageBox.Show("Disculpe, ya existe un beneficiario con el rif o cédula " + _Txt_Rif.Text, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return false;
            }
        }
        public bool _Mtd_Eliminar()
        {
            DialogResult eli = MessageBox.Show("Esta seguro de Eliminar el registro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (eli == DialogResult.Yes)
            {
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia("UPDATE TBENEFICIARIO SET CDELETE='1',CDATEDEL=GETDATE(),CUSERDEL='" + Frm_Padre._Str_Use + "' where cbeneficiario='" + _Txt_BeneficiarioId.Text.Trim().ToUpper() + "'");
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
            string _Str_Cadena = "SELECT cbeneficiario AS Código,crif as Rif,cnombre as Nombres,capellido as Apellidos,cdescripcion as Tipo,ctipobeneficiarioid from VST_T3_BENEFICIARIOS where CDELETE=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns[5].Visible=false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Deshabilitar_Todo()
        {
            _Txt_BeneficiarioId.Enabled = false;
            _Txt_Descripcion.Enabled = false;
            _Txt_Apellido.Enabled = false;
            _Cmb_TipoBeneficiario.Enabled = false;
            _Txt_Rif.Enabled = false;
            _Pnl_SeleccTipo.Enabled = false;
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
                string _Str_Rif=_Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                _Txt_BeneficiarioId.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0,e.RowIndex);
                if (_Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex) != null)
                {
                    if (_Str_Rif.Split('-').Count() > 2)
                    {
                        _Rbt_Rif.Checked = true;
                    }
                    else
                    {
                        _Rbt_Cedula.Checked = true;
                    }
                }
                _Txt_Rif.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex);
                _Txt_Descripcion.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, e.RowIndex);
                _Txt_Apellido.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, e.RowIndex);
                _Cmb_TipoBeneficiario.SelectedValue= _Ctrl_Busqueda1._Mtd_RetornarStringCelda(5, e.RowIndex);
                if (_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_MODIFICAR_BEN"))
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                }
                else
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                }
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

        private void _Cmb_TipoBeneficiario_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarTipoBeneficiario();
        }

        private void _Rbt_Cedula_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Cedula.Checked)
            {
                _Txt_Rif.Mask = "L-00000000";
            }
        }

        private void _Rbt_Rif_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Rif.Checked)
            {
                _Txt_Rif.Mask = "L-00000000-0";
            }
        }
    }
}