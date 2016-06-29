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
    public partial class Frm_IncVentas : Form
    {
        int _Int_GrupoIncVta = 0;
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        bool _Bol_PermisoConfirmado = false;
        public Frm_IncVentas()
        {
            InitializeComponent();
            _Bol_PermisoConfirmado = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & (_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_VVTAS") | _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_V_INCT_VVTAS"));
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
        private void _Mtd_HeaderText(DataGridView _P_Dg_Grid)
        {
            foreach (DataGridViewColumn _Dg_Col in _P_Dg_Grid.Columns)
            {
                _Dg_Col.HeaderText = _Dg_Col.HeaderText.Replace("_", " ");
            }
        }
        private void _Mtd_CargarCargos(ComboBox _P_Cmb_Combo)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT cidcargonom, cdescripcion FROM TCARGOSNOM WHERE ISNULL(cdelete,0)='0' AND (cgercomer='1' OR cgerarea='1' OR cvendedor='1' OR cgventas='1')";
            _Str_Cadena += " ORDER BY cdescripcion";
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
            { _Str_Cadena += " AND NOT EXISTS(SELECT cidgrupincentivar FROM TINCVTAS WHERE cgroupcomp=TGRUPOIV.cgroupcomp AND ccompany=TGRUPOIV.ccompany AND cidgrupincentivar=TGRUPOIV.cidgrupincentivar)"; }
            _Str_Cadena += " ORDER BY cdescripcion";
            _Cls_VariosMetodos._Mtd_CargarCombo(_P_Cmb_Combo, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }
        public void _Mtd_DesHabilitar()
        {
            _Pnl_Superior.Enabled = false;
            _Pnl_Detalle.Enabled = false;
            //-----
            _GrpB_Cond11.Enabled = false;
            _GrpB_Cond12.Enabled = false;
            _GrpB_Cond13.Enabled = false;
        }
        public void _Mtd_Habilitar()
        {
            _Pnl_Superior.Enabled = true;
            _Pnl_Detalle.Enabled = true;
        }
        public void _Mtd_Ini()
        {
            _Er_Error.Dispose();
            _Rbt_Fijo.Checked = false;
            _Rbt_Periodo.Checked = false;
            _Dtp_Desde.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dtp_Desde.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dtp_Hasta.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            //--------------------------------
            _Int_GrupoIncVta = 0;
            //--------------------------------
            _Txt_cuota_ccondicion1.Text = "";
            _Txt_cuota_ccondicion2.Text = "";
            _Txt_cuota_ccondicion3.Text = "";
            //-----
            _Txt_cuota_ccomision1.Text = "";
            _Txt_cuota_ccomision2.Text = "";
            _Txt_cuota_ccomision3.Text = "";
            //-----
            _Lbl_Grupo.Text = "";
        }
        public void _Mtd_Nuevo()
        {
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            _Mtd_DesHabilitar();
            _Mtd_Ini();
            _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Tb_Tab.SelectedIndex = 1;
            _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Pnl_Parametros.Visible = true;
        }
        private void _Mtd_Actualizar()
        {
            var _Var_Datos = from Campos in Program._Dat_Vistas.VST_INC_VTAS
                             where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp
                             select new { Grupo_Incentivo = Campos.cidgrupincentivar, Descripción = Campos.cdescripcion, Fíjo = Campos.civfijo == 1 ? "Sí" : "No", Campos.cidcargonom };
            if (_Cmb_Cargo.SelectedIndex > 0)
            { _Var_Datos = _Var_Datos.Where(c => c.cidcargonom == Convert.ToString(_Cmb_Cargo.SelectedValue).Trim()); }
            _Dg_Grid.DataSource = _Var_Datos;
            _Dg_Grid.Columns["Grupo_Incentivo"].Visible = false;
            _Dg_Grid.Columns["cidcargonom"].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private bool _Mtd_Existe(int _P_Int_GrupoInc)
        {
            return (from Campos in Program._Dat_Tablas.TINCVTAS
                    where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == _P_Int_GrupoInc
                    select Campos.cidgrupincentivar).Count() > 0;
        }
        private void _Mtd_DesHabilitarGroupBox(Panel _P_Pnl_Panel, Control _P_Grb_Excepcion)
        {
            //foreach (Control _Ctrl in _P_Pnl_Panel.Controls)
            //{
            //    if (_Ctrl.GetType() == typeof(GroupBox) & _Ctrl.Name != _P_Grb_Excepcion.Name)
            //    { _Ctrl.Enabled = false; }
            //}
        }
        private void _Mtd_Igualar(int _P_Int_GrupoInc)
        {
            var _Var_Datos = (from Campos in Program._Dat_Tablas.TINCVTAS
                              where Campos.cgroupcomp == (Convert.ToInt32(Frm_Padre._Str_GroupComp)) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == _P_Int_GrupoInc
                              select Campos).Single();
            _Int_GrupoIncVta = _P_Int_GrupoInc;
            if (_Var_Datos.civfijo == 1)
            {
                _Rbt_Fijo.CheckedChanged -= new EventHandler(_Rbt_Fijo_CheckedChanged);
                _Rbt_Fijo.Checked = true;
                _Rbt_Fijo.CheckedChanged += new EventHandler(_Rbt_Fijo_CheckedChanged);
            }
            else
            {
                _Rbt_Periodo.CheckedChanged -= new EventHandler(_Rbt_Periodo_CheckedChanged);
                _Rbt_Periodo.Checked = true;
                _Rbt_Periodo.CheckedChanged += new EventHandler(_Rbt_Periodo_CheckedChanged);
                _Dtp_Hasta.Value = (DateTime)_Var_Datos.cfechahasta;
                _Dtp_Desde.Value = (DateTime)_Var_Datos.cfechadesde;
            }
            //----------------------------------------
            _Txt_cuota_ccondicion1.Text = _Var_Datos.ccondicion1;
            _Txt_cuota_ccondicion2.Text = _Var_Datos.ccondicion2;
            _Txt_cuota_ccondicion3.Text = _Var_Datos.ccondicion3;
            //------------
            _Txt_cuota_ccomision1.Text = Convert.ToString(_Var_Datos.ccomision1);
            _Txt_cuota_ccomision2.Text = Convert.ToString(_Var_Datos.ccomision2);
            _Txt_cuota_ccomision3.Text = Convert.ToString(_Var_Datos.ccomision3);
        }
        private void _Mtd_GuardarTINCVTAS(int _P_Int_GrupoInc)
        {
            DataContext.TINCVTAS _T_TINCVTAS;
            bool _Bol_Existe = _Mtd_Existe(_P_Int_GrupoInc);
            if (_Bol_Existe)
            { _T_TINCVTAS = Program._Dat_Tablas.TINCVTAS.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidgrupincentivar == _P_Int_GrupoInc); }
            else
            {
                _T_TINCVTAS = new T3.DataContext.TINCVTAS();
                _T_TINCVTAS.cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp);
                _T_TINCVTAS.ccompany = Frm_Padre._Str_Comp;
                _T_TINCVTAS.cidincvtas = new _Cls_Consecutivos()._Mtd_IncVta();
                _T_TINCVTAS.cidgrupincentivar = _P_Int_GrupoInc;
            }
            _T_TINCVTAS.civfijo = Convert.ToByte(_Rbt_Fijo.Checked);
            _T_TINCVTAS.cfechadesde = _Dtp_Desde.Value;
            _T_TINCVTAS.cfechahasta = _Dtp_Hasta.Value;
            _T_TINCVTAS.ccondicion1 = _Txt_cuota_ccondicion1.Text;
            _T_TINCVTAS.ccondicion2 = _Txt_cuota_ccondicion2.Text;
            _T_TINCVTAS.ccondicion3 = _Txt_cuota_ccondicion3.Text;
            //------------
            _T_TINCVTAS.ccomision1 = Convert.ToDecimal(_Txt_cuota_ccomision1.Text);
            _T_TINCVTAS.ccomision2 = Convert.ToDecimal(_Txt_cuota_ccomision2.Text);
            _T_TINCVTAS.ccomision3 = Convert.ToDecimal(_Txt_cuota_ccomision3.Text);
            if (_Bol_Existe)
            {
                _T_TINCVTAS.cdateupd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _T_TINCVTAS.cuserupd = Frm_Padre._Str_Use;
            }
            else
            {
                _T_TINCVTAS.cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _T_TINCVTAS.cuseradd = Frm_Padre._Str_Use;
                Program._Dat_Tablas.TINCVTAS.InsertOnSubmit(_T_TINCVTAS); 
            }
            Program._Dat_Tablas.SubmitChanges();
        }
        public bool _Mtd_Editar()
        {
            return _Mtd_Guardar();
        }
        public bool _Mtd_Guardar()
        {
            if (_Rbt_Fijo.Checked | _Rbt_Periodo.Checked)
            {
                if (_Mtd_InfCompleta())
                {
                    if (_Mtd_VerifCampOblig())
                    {
                        if (_Mtd_ValidarCondiciones(new TextBox[] { _Txt_cuota_ccondicion1, _Txt_cuota_ccondicion2, _Txt_cuota_ccondicion3 }))
                        {
                            if (_Txt_cuota_ccomision1.Text.Trim().Length == 0) { _Txt_cuota_ccomision1.Text = "0"; }
                            if (_Txt_cuota_ccomision2.Text.Trim().Length == 0) { _Txt_cuota_ccomision2.Text = "0"; }
                            if (_Txt_cuota_ccomision3.Text.Trim().Length == 0) { _Txt_cuota_ccomision3.Text = "0"; }
                            Cursor = Cursors.WaitCursor;
                            _Mtd_GuardarTINCVTAS(_Int_GrupoIncVta);
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
                _Er_Error.SetError(_Rbt_Fijo, "Selección");
                _Er_Error.SetError(_Lbl_Periodo, "Selección");
            }
            return false;
        }
        private bool _Mtd_VerifCampOblig()
        {
            if
                   (
                   !((_Txt_cuota_ccomision1.Text.Trim().Length > 0 & _Mtd_VerifContTextBoxNumeric(_Txt_cuota_ccomision1))
                   |
                   (_Txt_cuota_ccomision2.Text.Trim().Length > 0 & _Mtd_VerifContTextBoxNumeric(_Txt_cuota_ccomision2))
                   |
                   (_Txt_cuota_ccomision3.Text.Trim().Length > 0 & _Mtd_VerifContTextBoxNumeric(_Txt_cuota_ccomision3))
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
        private bool _Mtd_InfCompleta()
        {
            if (
                     !_Mtd_VerificarInfCompleta(_Txt_cuota_ccondicion1, _Txt_cuota_ccomision1)
                     |
                     !_Mtd_VerificarInfCompleta(_Txt_cuota_ccondicion2, _Txt_cuota_ccomision2)
                     |
                     !_Mtd_VerificarInfCompleta(_Txt_cuota_ccondicion3, _Txt_cuota_ccomision3)
                     )
            {
                MessageBox.Show("Existen registros con datos incompletos. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void _Mtd_HabilitarTextbox()
        {
            if (_Lbl_Grupo.Text.Trim().Length == 0)
            {
                _GrpB_Cond11.Enabled = true;
                _GrpB_Cond12.Enabled = true;
                _GrpB_Cond13.Enabled = true;
            }

        }
        private void _Mtd_EliminarRegistros()
        {
            var _Var_Datos = from Campos in _Dg_Grid.Rows.Cast<DataGridViewRow>()
                             where Campos.Selected
                             select Campos;
            foreach (DataGridViewRow _DgRow in _Var_Datos)
            {
                Program._Dat_Tablas.TINCVTAS.DeleteOnSubmit(Program._Dat_Tablas.TINCVTAS.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidgrupincentivar == Convert.ToInt32(_DgRow.Cells["Grupo_Incentivo"].Value)));
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
        private string _Mtd_DescripCargo(string _P_Str_cidcargonom)
        {
            return (from Campos in Program._Dat_Tablas.TCARGOSNOM
                    where Campos.cidcargonom == _P_Str_cidcargonom
                    select Campos.cdescripcion).Single().Trim().ToUpper();
        }
        private void Frm_IncVentas_Load(object sender, EventArgs e)
        {
            if (_Bol_PermisoConfirmado)
            {
                _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
                _Pnl_Parametros.Left = (this.Width / 2) - (_Pnl_Parametros.Width / 2);
                _Pnl_Parametros.Top = (this.Height / 2) - (_Pnl_Parametros.Height / 2);
                Cursor = Cursors.WaitCursor;
                _Mtd_Color_Estandar(this);
                _Mtd_CargarCargos(_Cmb_Cargo);
                _Mtd_Actualizar();
                Cursor = Cursors.Default;
            }
        }

        private void Frm_IncVentas_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_VVTAS");
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _Pnl_Superior.Enabled;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = ((_Rbt_Fijo.Checked | _Rbt_Periodo.Checked) & !_Pnl_Superior.Enabled) & _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_VVTAS");
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
        }

        private void Frm_IncVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
            Cursor = Cursors.Default;
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                e.Cancel = !_Pnl_Superior.Enabled;
            }
            else
            {
                _Mtd_DesHabilitar();
                _Mtd_Ini();
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
        private void _Txt_cuota_ccomision1_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_cuota_ccomision1.Text)) { _Txt_cuota_ccomision1.Text = ""; }
        }

        private void _Txt_cuota_ccomision2_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_cuota_ccomision2.Text)) { _Txt_cuota_ccomision2.Text = ""; }
        }

        private void _Txt_cuota_ccomision3_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_cuota_ccomision3.Text)) { _Txt_cuota_ccomision3.Text = ""; }
        }

        private void _Txt_cuota_ccomision1_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_cuota_ccomision1, e, 10, 2);
        }

        private void _Txt_cuota_ccomision2_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_cuota_ccomision2, e, 10, 2);
        }

        private void _Txt_cuota_ccomision3_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_cuota_ccomision3, e, 10, 2);
        }

        private void _Pnl_Parametros_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Parametros.Visible)
            { 
                _Tb_Tab.Enabled = false;
                Cursor = Cursors.WaitCursor;
                _Mtd_CargarCargos(_Cmb_Cargo_D);
                Cursor = Cursors.Default;
                _Cmb_Grupo_D.DataSource = null;
                _Cmb_Grupo_D.Enabled = false;
                _Cmb_Cargo_D.Focus();
                _Bt_Aceptar.Enabled = false;
            }
            else
            { _Tb_Tab.Enabled = true; }
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
            { _Cmb_Grupo_D.DataSource = null; _Cmb_Grupo_D.Enabled = false; }
        }

        private void _Cmb_Grupo_D_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarGrupos(_Cmb_Grupo_D, _Cmb_Cargo_D, false);
        }

        private void _Cmb_Grupo_D_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Bt_Aceptar.Enabled = _Cmb_Grupo_D.SelectedIndex > 0;
            if (_Cmb_Grupo_D.SelectedIndex > 0)
            {
                _Lbl_Grupo.Text = "Cargo:\n" + _Cmb_Cargo_D.Text.Trim().ToUpper() + "\nGrupo:\n" + _Cmb_Grupo_D.Text.Trim().ToUpper();
            }
            else
            { _Lbl_Grupo.Text = ""; }
        }

        private void _Bt_Cerrar_Click(object sender, EventArgs e)
        {
            _Pnl_Parametros.Visible = false;
            _Tb_Tab.SelectedIndex = 0;
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Parametros.Visible = false;
            _Tb_Tab.SelectedIndex = 0;
        }
        private void _Bt_Cuota_Condicion1_Click(object sender, EventArgs e)
        {
            _GrpB_Cond11.Enabled = !_GrpB_Cond11.Enabled;
            _Txt_cuota_ccondicion1.Focus();
            _Mtd_DesHabilitarGroupBox(_Pnl_Detalle, _GrpB_Cond11);
        }

        private void _Bt_Cuota_Condicion2_Click(object sender, EventArgs e)
        {
            _GrpB_Cond12.Enabled = !_GrpB_Cond12.Enabled;
            _Txt_cuota_ccondicion2.Focus();
            _Mtd_DesHabilitarGroupBox(_Pnl_Detalle, _GrpB_Cond12);
        }

        private void _Bt_Cuota_Condicion3_Click(object sender, EventArgs e)
        {
            _GrpB_Cond13.Enabled = !_GrpB_Cond13.Enabled;
            _Txt_cuota_ccondicion3.Focus();
            _Mtd_DesHabilitarGroupBox(_Pnl_Detalle, _GrpB_Cond13);
        }

        private void _Dtp_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dtp_Desde.MaxDate = _Dtp_Hasta.Value;
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (_Mtd_Existe(Convert.ToInt32(_Cmb_Grupo_D.SelectedValue)))
            { MessageBox.Show("Ya existen parámetros creados para el grupo elegido. Por favor elija un grupo diferente...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            else
            {
                _Int_GrupoIncVta = Convert.ToInt32(_Cmb_Grupo_D.SelectedValue);
                //_Er_Error.SetError(_Rbt_Fijo, "Selección");
                //_Er_Error.SetError(_Lbl_Periodo, "Selección");
                _Rbt_Fijo.Checked = true;
                _Pnl_Parametros.Visible = false;
                _Pnl_Superior.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
            }
        }

        private void _Rbt_Fijo_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Fijo.Checked)
            { _Pnl_Detalle.Enabled = true; _Er_Error.Dispose(); _Mtd_HabilitarTextbox(); }
        }
        private void _Rbt_Periodo_CheckedChanged(object sender, EventArgs e)
        {
            _Grb_Fechas.Enabled = _Rbt_Periodo.Checked;
            if (_Rbt_Periodo.Checked)
            { _Pnl_Detalle.Enabled = true; _Er_Error.Dispose(); _Mtd_HabilitarTextbox(); }
        }

        private void _Lbl_Periodo_Click(object sender, EventArgs e)
        {
            _Rbt_Periodo.Checked = true;
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count == 1)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Igualar(Convert.ToInt32(_Dg_Grid.Rows[e.RowIndex].Cells["Grupo_Incentivo"].Value));
                _Lbl_Grupo.Text = "Cargo:\n" + _Mtd_DescripCargo(Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["cidcargonom"].Value).Trim()) + "\nGrupo:\n" + Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Descripción"].Value).Trim();
                _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                _Tb_Tab.SelectedIndex = 1;
                _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_VVTAS");
                Cursor = Cursors.Default;
            }
        }

        private void Frm_IncVentas_Shown(object sender, EventArgs e)
        {
            if (!_Bol_PermisoConfirmado)
            { MessageBox.Show("Su usuario no tiene permisos para entrar en este módulo", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close(); }
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

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _Dg_Grid.SelectedRows.Count == 0 | !(_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_VVTAS"));
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de eliminar los registros selecionados", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                _Pnl_Clave.Visible = true;
            }
        }
    }
}
