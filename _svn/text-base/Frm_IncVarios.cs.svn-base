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
    public partial class Frm_IncVarios : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        bool _Bol_PermisoConfirmado = false;
        public Frm_IncVarios()
        {
            InitializeComponent();
            _Bol_PermisoConfirmado = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & (_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_VAR") | _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_V_INCT_VAR"));
        }
        private bool _Mtd_VerifContTextBoxNumeric(TextBox _P_Txt_TextBox)
        {
            if (_P_Txt_TextBox.Text.Trim().Length > 0)
            {
                if (Convert.ToDouble(_P_Txt_TextBox.Text) > 0)
                { return true; }
            }
            return false;
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
                    if (_Ctrl.GetType() != typeof(RadioButton))
                    { new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco(); }
                }
            }
        }
        private void _Mtd_CargarCargos(ComboBox _P_Cmb_Combo)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT cidcargonom, cdescripcion FROM TCARGOSNOM WHERE ISNULL(cdelete,0)='0' AND (cgerarea='1' OR cvendedor='1') ORDER BY cdescripcion";
            _Cls_VariosMetodos._Mtd_CargarCombo(_P_Cmb_Combo, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_CargarGrupos(ComboBox _P_Cmb_Combo, ComboBox _P_Cmb_ComboFiltro, bool _P_Bol_Consulta)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT cidgrupincentivar, cdescripcion FROM TGRUPOIV WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'";
            if (_P_Cmb_ComboFiltro.SelectedIndex > 0)
            { _Str_Cadena += " AND cidcargonom='" + Convert.ToString(_P_Cmb_ComboFiltro.SelectedValue).Trim() + "'"; }
            if (!_P_Bol_Consulta)
            { _Str_Cadena += " AND NOT EXISTS(SELECT cidgrupincentivar FROM TINCVARIOS WHERE cgroupcomp=TGRUPOIV.cgroupcomp AND ccompany=TGRUPOIV.ccompany AND cidgrupincentivar=TGRUPOIV.cidgrupincentivar)"; }
            _Str_Cadena += " ORDER BY cdescripcion";
            _Cls_VariosMetodos._Mtd_CargarCombo(_P_Cmb_Combo, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_Actualizar()
        {
            var _Var_Datos = from Campos in Program._Dat_Vistas.VST_INC_VARIOS
                             where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp
                             select new { Grupo_Insentivo = Campos.cidgrupincentivar, Descripción = Campos.cdescripcion, Campos.cidcargonom };
            if (_Cmb_Cargo.SelectedIndex > 0)
            { _Var_Datos = _Var_Datos.Where(c => c.cidcargonom == Convert.ToString(_Cmb_Cargo.SelectedValue).Trim()); }
            _Dg_Grid.DataSource = _Var_Datos;
            _Dg_Grid.Columns["Grupo_Insentivo"].Visible = false;
            _Dg_Grid.Columns["cidcargonom"].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Habilitar(bool _P_Bol_Habilitar)
        {
            _Cmb_Cargo_D.Enabled = _P_Bol_Habilitar;
            _Cmb_Grupo_D.Enabled = false;
            _Txt_ccondicion_devolucion.Enabled = false;
            _Txt_ccomisionpag_devolucion.Enabled = false;
            _Txt_ccondicion_efectividad.Enabled = false;
            _Txt_ccomisionpag_efectividad.Enabled = false;
            _Txt_cmontominvisefec.Enabled = false;
            _Txt_ccondicion_activacion.Enabled = false;
            _Txt_ccomisionpag_activacion.Enabled = false;
            _Pnl_Detalle_2.Enabled = false;
        }
        public void _Mtd_Habilitar()
        {
            _Pnl_Detalle_2.Enabled = true;
        }
        private void _Mtd_Ini()
        {
            _Txt_cidincvarios.Text = "";
            _Mtd_CargarCargos(_Cmb_Cargo_D);
            _Txt_ccondicion_devolucion.Text = "";
            _Txt_ccomisionpag_devolucion.Text = "";
            _Txt_ccondicion_efectividad.Text = "";
            _Txt_ccomisionpag_efectividad.Text = "";
            _Txt_cmontominvisefec.Text = "";
            _Txt_ccondicion_activacion.Text = "";
            _Txt_ccomisionpag_activacion.Text = "";
        }
        public void _Mtd_Nuevo()
        {
            _Er_Error.Dispose();
            _Mtd_Ini();
            _Mtd_Habilitar(true);
            _Tb_Tab.SelectedIndex = 1;
            _Txt_ccondicion_devolucion.Enabled = true;
            _Txt_ccomisionpag_devolucion.Enabled = true;
            _Txt_ccondicion_efectividad.Enabled = true;
            _Txt_ccomisionpag_efectividad.Enabled = true;
            _Txt_cmontominvisefec.Enabled = true;
            _Txt_ccondicion_activacion.Enabled = true;
            _Txt_ccomisionpag_activacion.Enabled = true;
            _Cmb_Cargo_D.Focus();
        }
        private void _Mtd_CargarFormulario(int _P_Int_GrupoInc, string _P_Str_Cargo)
        {
            var _Var_Datos = (from Campos in Program._Dat_Tablas.TINCVARIOS
                              where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == _P_Int_GrupoInc
                              select Campos).Single();
            _Txt_cidincvarios.Text = _Var_Datos.cidincvarios.ToString();
            _Cmb_Cargo_D.SelectedIndexChanged -= new EventHandler(_Cmb_Cargo_D_SelectedIndexChanged);
            _Cmb_Cargo_D.SelectedValue = _P_Str_Cargo;
            _Cmb_Cargo_D.SelectedIndexChanged += new EventHandler(_Cmb_Cargo_D_SelectedIndexChanged);
            _Mtd_CargarGrupos(_Cmb_Grupo_D, _Cmb_Cargo_D, true);
            _Cmb_Grupo_D.SelectedValue = _P_Int_GrupoInc.ToString();
            _Txt_ccondicion_devolucion.Text = _Var_Datos.ccondiciondev;
            _Txt_ccomisionpag_devolucion.Text = _Var_Datos.ccomisionpagdev.ToString();
            _Txt_ccondicion_efectividad.Text = _Var_Datos.ccondicionefect;
            _Txt_ccomisionpag_efectividad.Text = _Var_Datos.ccomisionpagefect.ToString();
            _Txt_cmontominvisefec.Text = _Var_Datos.cmontominvisefec.ToString();
            _Txt_ccondicion_activacion.Text = _Var_Datos.ccondicionactivac;
            _Txt_ccomisionpag_activacion.Text = _Var_Datos.ccomisionpagactivac.ToString();
            _Pnl_Detalle_2.Enabled = false;
        }
        private bool _Mtd_Existe(int _P_Int_GrupoInc)
        {
            return (from Campos in Program._Dat_Tablas.TINCVARIOS
                    where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == _P_Int_GrupoInc
                    select Campos.cidgrupincentivar).Count() > 0;
        }
        private void _Mtd_InsertarRegistro(int _P_Int_GrupoInc)
        {
            DataContext.TINCVARIOS _T_TINCVARIOS;
            bool _Bol_Existe = _Mtd_Existe(_P_Int_GrupoInc);
            if (_Bol_Existe)
            { _T_TINCVARIOS = Program._Dat_Tablas.TINCVARIOS.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidgrupincentivar == _P_Int_GrupoInc); }
            else
            {
                _T_TINCVARIOS = new T3.DataContext.TINCVARIOS();
                _T_TINCVARIOS.cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp);
                _T_TINCVARIOS.ccompany = Frm_Padre._Str_Comp;
                _T_TINCVARIOS.cidincvarios = new _Cls_Consecutivos()._Mtd_IncVar();
                _T_TINCVARIOS.cidgrupincentivar = _P_Int_GrupoInc;
            }
            _T_TINCVARIOS.ccondiciondev = _Txt_ccondicion_devolucion.Text.Trim().ToUpper();
            _T_TINCVARIOS.ccomisionpagdev = Convert.ToDecimal(_Txt_ccomisionpag_devolucion.Text);
            _T_TINCVARIOS.ccondicionefect = _Txt_ccondicion_efectividad.Text.Trim().ToUpper();
            _T_TINCVARIOS.ccomisionpagefect = Convert.ToDecimal(_Txt_ccomisionpag_efectividad.Text);
            _T_TINCVARIOS.cmontominvisefec = Convert.ToDecimal(_Txt_cmontominvisefec.Text);
            _T_TINCVARIOS.ccondicionactivac = _Txt_ccondicion_activacion.Text.Trim().ToUpper();
            _T_TINCVARIOS.ccomisionpagactivac = Convert.ToDecimal(_Txt_ccomisionpag_activacion.Text);
            if (_Bol_Existe)
            {
                _T_TINCVARIOS.cdateupd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _T_TINCVARIOS.cuserupd = Frm_Padre._Str_Use;
            }
            else
            {
                _T_TINCVARIOS.cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _T_TINCVARIOS.cuseradd = Frm_Padre._Str_Use;
                Program._Dat_Tablas.TINCVARIOS.InsertOnSubmit(_T_TINCVARIOS);
            }
            Program._Dat_Tablas.SubmitChanges();
        }
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            if (_Cmb_Grupo_D.SelectedIndex > 0 & _Cmb_Cargo_D.SelectedIndex > 0)
            {
                if (_Mtd_InfCompleta())
                {
                    if (_Mtd_VerifCampOblig())
                    {
                        if (_Mtd_ValidarCondiciones(new TextBox[] { _Txt_ccondicion_devolucion }) & _Mtd_ValidarCondiciones(new TextBox[] { _Txt_ccondicion_efectividad }) & _Mtd_ValidarCondiciones(new TextBox[] { _Txt_ccondicion_activacion })) 
                        {
                            if (_Txt_ccomisionpag_devolucion.Text.Trim().Length == 0) { _Txt_ccomisionpag_devolucion.Text = "0"; }
                            if (_Txt_ccomisionpag_efectividad.Text.Trim().Length == 0) { _Txt_ccomisionpag_efectividad.Text = "0"; }
                            if (_Txt_cmontominvisefec.Text.Trim().Length == 0) { _Txt_cmontominvisefec.Text = "0"; }
                            if (_Txt_ccomisionpag_activacion.Text.Trim().Length == 0) { _Txt_ccomisionpag_activacion.Text = "0"; }
                            Cursor = Cursors.WaitCursor;
                            _Mtd_InsertarRegistro(Convert.ToInt32(_Cmb_Grupo_D.SelectedValue));
                            Cursor = Cursors.Default;
                            MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cursor = Cursors.WaitCursor;
                            _Mtd_Actualizar();
                            _Tb_Tab.SelectedIndex = 0;
                            Cursor = Cursors.Default;
                            return true;
                        }
                        else
                        { MessageBox.Show("Una o más condiciones han sido creadas incorrectamente. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                    }
                }
            }
            else
            {
                if (_Cmb_Grupo_D.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Grupo_D, "Información requerida!!!"); }
                if (_Cmb_Cargo_D.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Cargo_D, "Información requerida!!!"); }
            }
            return false;
        }
        public bool _Mtd_Editar()
        {
            return _Mtd_Guardar();
        }
        private bool _Mtd_VerifCampOblig()
        {
            if
                   (
                   !((_Txt_ccondicion_devolucion.Text.Trim().Length > 0 & _Mtd_VerifContTextBoxNumeric(_Txt_ccomisionpag_devolucion))
                   |
                   (_Txt_ccondicion_efectividad.Text.Trim().Length > 0 & _Mtd_VerifContTextBoxNumeric(_Txt_ccomisionpag_efectividad) & _Mtd_VerifContTextBoxNumeric(_Txt_cmontominvisefec))
                   |
                   (_Txt_ccondicion_activacion.Text.Trim().Length > 0 & _Mtd_VerifContTextBoxNumeric(_Txt_ccomisionpag_activacion))
                   ))
            {
                MessageBox.Show("Debe ingresar por lo menos una información completa en las condiciones.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private bool _Mtd_VerificarInfCompleta(TextBox _P_Txt_Textbox1, TextBox _P_Txt_Textbox2)
        {
            if (_P_Txt_Textbox1.Text.Trim().Length > 0 & !_Mtd_VerifContTextBoxNumeric(_P_Txt_Textbox2))
            { return false; }
            else if (_P_Txt_Textbox1.Text.Trim().Length == 0 & _Mtd_VerifContTextBoxNumeric(_P_Txt_Textbox2))
            { return false; }
            return true;
        }
        private bool _Mtd_VerificarInfCompletaEfec(TextBox _P_Txt_Textbox1, TextBox _P_Txt_Textbox2, TextBox _P_Txt_Textbox3)
        {
            if (_P_Txt_Textbox1.Text.Trim().Length > 0 & (!_Mtd_VerifContTextBoxNumeric(_P_Txt_Textbox2) | !_Mtd_VerifContTextBoxNumeric(_P_Txt_Textbox3)))
            { return false; }
            else if (_Mtd_VerifContTextBoxNumeric(_P_Txt_Textbox2) & (_P_Txt_Textbox1.Text.Trim().Length == 0 | !_Mtd_VerifContTextBoxNumeric(_P_Txt_Textbox3)))
            { return false; }
            else if (_Mtd_VerifContTextBoxNumeric(_P_Txt_Textbox3) & (_P_Txt_Textbox1.Text.Trim().Length == 0 | !_Mtd_VerifContTextBoxNumeric(_P_Txt_Textbox2)))
            { return false; }
            else if (_P_Txt_Textbox1.Text.Trim().Length > 0 & _Mtd_VerifContTextBoxNumeric(_P_Txt_Textbox2) & !_Mtd_VerifContTextBoxNumeric(_P_Txt_Textbox3))
            { return false; }
            else if (_P_Txt_Textbox1.Text.Trim().Length > 0 & !_Mtd_VerifContTextBoxNumeric(_P_Txt_Textbox2) & _Mtd_VerifContTextBoxNumeric(_P_Txt_Textbox3))
            { return false; }
            else if (_P_Txt_Textbox1.Text.Trim().Length == 0 & _Mtd_VerifContTextBoxNumeric(_P_Txt_Textbox2) & _Mtd_VerifContTextBoxNumeric(_P_Txt_Textbox3))
            { return false; }
            return true;
        }
        private bool _Mtd_InfCompleta()
        {
            if (
                     !_Mtd_VerificarInfCompleta(_Txt_ccondicion_devolucion, _Txt_ccomisionpag_devolucion)
                     |
                     !_Mtd_VerificarInfCompletaEfec(_Txt_ccondicion_efectividad, _Txt_ccomisionpag_efectividad, _Txt_cmontominvisefec)
                     |
                     !_Mtd_VerificarInfCompleta(_Txt_ccondicion_activacion, _Txt_ccomisionpag_activacion)
                     )
            {
                MessageBox.Show("Existen registros con datos incompletos. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void _Mtd_EliminarRegistros()
        {
            var _Var_Datos = from Campos in _Dg_Grid.Rows.Cast<DataGridViewRow>()
                             where Campos.Selected
                             select Campos;
            foreach (DataGridViewRow _DgRow in _Var_Datos)
            {
                Program._Dat_Tablas.TINCVARIOS.DeleteOnSubmit(Program._Dat_Tablas.TINCVARIOS.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidgrupincentivar == Convert.ToInt32(_DgRow.Cells["Grupo_Insentivo"].Value)));
            }
            Program._Dat_Tablas.SubmitChanges();
        }
        public bool _Mtd_VerificarMonto(string _P_Str_Monto)
        {
            try
            {
                return Convert.ToDouble(_P_Str_Monto) >= 0;
            }
            catch { return false; }
        }
        private double[] _Mtd_VerificarCondicion(string _P_Str_Condicion)
        {
            string[] _Str_Partes = new string[5];
            string[] _Str_Cadena = _P_Str_Condicion.Trim().Split(new char[] { ' ' });
            try
            {
                //----------------------------------------------Dividir Parte 1
                if (_Str_Cadena[0].IndexOf(">=") != -1)//
                {
                    _Str_Partes[0] = _Str_Cadena[0].Substring(0, 2);
                    _Str_Partes[1] = _Str_Cadena[0].Substring(2);
                }
                //----------------------------------------------
                try
                {
                    //----------------------------------------------Operador Relacional
                    _Str_Partes[2] = _Str_Cadena[1];
                    //----------------------------------------------
                    //----------------------------------------------Dividir Parte 2
                    if (_Str_Cadena[2].IndexOf("<") != -1)//
                    {
                        _Str_Partes[3] = _Str_Cadena[2].Substring(0, 1);
                        _Str_Partes[4] = _Str_Cadena[2].Substring(1);
                    }
                    //----------------------------------------------
                    string _Str_PrimerOperador = _Str_Partes[0];
                    string _Str_PrimerMonto = _Str_Partes[1];
                    string _Str_OperadorRelacional = _Str_Partes[2];
                    string _Str_SegundoOperador = _Str_Partes[3];
                    string _Str_SegundoMonto = _Str_Partes[4];
                    if (_Str_PrimerOperador == ">=" & _Mtd_VerificarMonto(_Str_PrimerMonto) & _Str_OperadorRelacional.ToUpper() == "Y" & _Str_SegundoOperador == "<" & _Mtd_VerificarMonto(_Str_SegundoMonto))
                    {
                        if (Convert.ToDouble(_Str_SegundoMonto) > Convert.ToDouble(_Str_PrimerMonto))
                        { return new double[] { Convert.ToDouble(_Str_PrimerMonto), Convert.ToDouble(_Str_SegundoMonto) }; }
                    }
                }
                catch
                {
                    string _Str_PrimerOperador = _Str_Partes[0];
                    string _Str_PrimerMonto = _Str_Partes[1];
                    if (_Str_PrimerOperador == ">=" & _Mtd_VerificarMonto(_Str_PrimerMonto))
                    {
                        return new double[] { Convert.ToDouble(_Str_PrimerMonto), 0 };
                    }
                }
            }
            catch { }
            return null;
        }
        private bool _Mtd_ValidarCondiciones(TextBox[] _P_Txt_TextBoxs)
        {
            double[] _Dbl_Montos;
            double _Dbl_PrimerMontoActual = 0;
            double _Dbl_SegundoMontoAnterior = -1;
            bool _Bol_PrimeraCondicion = true;
            foreach (TextBox _Txt_TextBox in _P_Txt_TextBoxs)
            {
                _Txt_TextBox.Text = _Txt_TextBox.Text.Trim();
                if (_Txt_TextBox.Text.Trim().Length > 0)
                {
                    _Dbl_Montos = _Mtd_VerificarCondicion(_Txt_TextBox.Text);
                    if (_Dbl_Montos == null)
                    { return false; }
                    if (_Bol_PrimeraCondicion)
                    {
                        _Dbl_SegundoMontoAnterior = _Dbl_Montos[1];
                        _Bol_PrimeraCondicion = false;
                    }
                    else
                    {
                        _Dbl_PrimerMontoActual = _Dbl_Montos[0];
                        if (_Dbl_PrimerMontoActual == _Dbl_SegundoMontoAnterior & _Dbl_SegundoMontoAnterior > 0)
                        {
                            _Dbl_SegundoMontoAnterior = _Dbl_Montos[1];
                        }
                        else
                        { return false; }
                    }
                }
            }
            return true;
        }
        private void Frm_IncVarios_Load(object sender, EventArgs e)
        {
            if (_Bol_PermisoConfirmado)
            {
                _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
                Cursor = Cursors.WaitCursor;
                _Mtd_Color_Estandar(this);
                _Mtd_CargarCargos(_Cmb_Cargo);
                _Mtd_Actualizar();
                Cursor = Cursors.Default;
            }
        }

        private void Frm_IncVarios_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_VAR");
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = !_Pnl_Detalle_2.Enabled & (_Txt_ccondicion_devolucion.Text.Trim().Length > 0 | _Txt_ccondicion_efectividad.Text.Trim().Length > 0 | _Txt_ccondicion_activacion.Text.Trim().Length > 0) & _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_VAR");
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _Tb_Tab.SelectedIndex == 1 & !((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled & _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_VAR");
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
        }

        private void Frm_IncVarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_IncVarios_Shown(object sender, EventArgs e)
        {
            if (!_Bol_PermisoConfirmado)
            { MessageBox.Show("Su usuario no tiene permisos para entrar en este módulo", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close(); }
            else
            { _Cmb_Cargo.Focus(); }
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            { e.Cancel = !_Cmb_Cargo_D.Enabled & _Cmb_Cargo_D.SelectedIndex <= 0; }
            else
            {
                _Mtd_Ini();
                _Mtd_Habilitar(false);
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            }
        }

        private void _Cmb_Cargo_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarCargos(_Cmb_Cargo);
            Cursor = Cursors.Default;
        }

        private void _Cmb_Cargo_D_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarCargos(_Cmb_Cargo_D);
            Cursor = Cursors.Default;
        }

        private void _Cmb_Cargo_D_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Cargo_D.SelectedIndex > 0)
            { _Mtd_CargarGrupos(_Cmb_Grupo_D, _Cmb_Cargo_D, false); _Cmb_Grupo_D.Enabled = true; }
            else
            { _Cmb_Grupo_D.SelectedIndex = -1; _Cmb_Grupo_D.DataSource = null; _Cmb_Grupo_D.Enabled = false; }
        }

        private void _Cmb_Grupo_D_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarGrupos(_Cmb_Grupo_D, _Cmb_Cargo_D, false);
            Cursor = Cursors.Default;
        }

        private void _Cmb_Grupo_D_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            _Pnl_Detalle_2.Enabled = _Cmb_Grupo_D.SelectedIndex > 0;
            _Txt_ccondicion_devolucion.Text = "";
            _Txt_ccomisionpag_devolucion.Text = "";
            _Txt_ccondicion_efectividad.Text = "";
            _Txt_ccomisionpag_efectividad.Text = "";
            _Txt_ccondicion_activacion.Text = "";
            _Txt_ccomisionpag_activacion.Text = "";
        }

        private void _Bt_Devolucion_Click(object sender, EventArgs e)
        {
            _Txt_ccondicion_devolucion.Enabled = !_Txt_ccondicion_devolucion.Enabled;
            _Txt_ccomisionpag_devolucion.Enabled = !_Txt_ccomisionpag_devolucion.Enabled;
            _Txt_ccondicion_devolucion.Focus();
            //-----------
            //_Txt_ccondicion_efectividad.Enabled = false;
            //_Txt_ccomisionpag_efectividad.Enabled = false;
            //_Txt_ccondicion_activacion.Enabled = false;
            //_Txt_ccomisionpag_activacion.Enabled = false;
            //-----------
        }

        private void _Bt_Efectividad_Click(object sender, EventArgs e)
        {
            _Txt_ccondicion_efectividad.Enabled = !_Txt_ccondicion_efectividad.Enabled;
            _Txt_ccomisionpag_efectividad.Enabled = !_Txt_ccomisionpag_efectividad.Enabled;
            _Txt_cmontominvisefec.Enabled = !_Txt_cmontominvisefec.Enabled;
            _Txt_ccondicion_efectividad.Focus();
            //-----------
            //_Txt_ccondicion_devolucion.Enabled = false;
            //_Txt_ccomisionpag_devolucion.Enabled = false;
            //_Txt_ccondicion_activacion.Enabled = false;
            //_Txt_ccomisionpag_activacion.Enabled = false;
            //-----------
        }

        private void _Bt_Activacion_Click(object sender, EventArgs e)
        {
            _Txt_ccondicion_activacion.Enabled = !_Txt_ccondicion_activacion.Enabled;
            _Txt_ccomisionpag_activacion.Enabled = !_Txt_ccomisionpag_activacion.Enabled;
            _Txt_ccondicion_activacion.Focus();
            //-----------
            //_Txt_ccondicion_devolucion.Enabled = false;
            //_Txt_ccomisionpag_devolucion.Enabled = false;
            //_Txt_ccondicion_efectividad.Enabled = false;
            //_Txt_ccomisionpag_efectividad.Enabled = false;
            //-----------
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count == 1)
            {
                _Er_Error.Dispose();
                Cursor = Cursors.WaitCursor;
                _Mtd_CargarCargos(_Cmb_Cargo_D);
                _Mtd_CargarFormulario(Convert.ToInt32(_Dg_Grid.Rows[e.RowIndex].Cells["Grupo_Insentivo"].Value), Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["cidcargonom"].Value));
                _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                _Tb_Tab.SelectedIndex = 1;
                _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_VAR");
                Cursor = Cursors.Default;
            }
        }

        private void _Txt_ccomisionpag_devolucion_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_ccomisionpag_devolucion.Text)) { _Txt_ccomisionpag_devolucion.Text = ""; }
        }

        private void _Txt_ccomisionpag_efectividad_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_ccomisionpag_efectividad.Text)) { _Txt_ccomisionpag_efectividad.Text = ""; }
        }

        private void _Txt_ccomisionpag_activacion_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_ccomisionpag_activacion.Text)) { _Txt_ccomisionpag_activacion.Text = ""; }
        }

        private void _Txt_ccomisionpag_devolucion_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_ccomisionpag_devolucion, e, 10, 2);
        }

        private void _Txt_ccomisionpag_efectividad_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_ccomisionpag_efectividad, e, 10, 2);
        }

        private void _Txt_ccomisionpag_activacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_ccomisionpag_activacion, e, 10, 2);
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
            Cursor = Cursors.Default;
        }

        private void _Txt_cmontominvisefec_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_cmontominvisefec.Text)) { _Txt_cmontominvisefec.Text = ""; }
        }

        private void _Txt_cmontominvisefec_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_cmontominvisefec, e, 10, 2);
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _Dg_Grid.SelectedRows.Count == 0 | !(_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_VAR"));
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de eliminar los registros selecionados", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                _Pnl_Clave.Visible = true;
            }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Tb_Tab.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else { _Tb_Tab.Enabled = true; }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                _Pnl_Clave.Enabled = false;
                Cursor = Cursors.WaitCursor;
                _Mtd_EliminarRegistros();
                _Mtd_Actualizar();
                Cursor = Cursors.Default;
                _Pnl_Clave.Enabled = true;
                _Pnl_Clave.Visible = false;
                MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }
    }
}
