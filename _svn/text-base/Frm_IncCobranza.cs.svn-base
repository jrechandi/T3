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
    public partial class Frm_IncCobranza : Form
    {
        string _Str_TipoCargo = "";
        int _Int_GrupoIncCob = 0;
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        bool _Bol_PermisoConfirmado = false;
        public Frm_IncCobranza()
        {
            InitializeComponent();
            _Bol_PermisoConfirmado = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & (_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_COB") | _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_V_INCT_COB"));
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
            { _Str_Cadena += " AND NOT EXISTS(SELECT cidgrupincentivar FROM TINCCOB WHERE cgroupcomp=TGRUPOIV.cgroupcomp AND ccompany=TGRUPOIV.ccompany AND cidgrupincentivar=TGRUPOIV.cidgrupincentivar)"; }
            _Str_Cadena += " ORDER BY cdescripcion";
            _Cls_VariosMetodos._Mtd_CargarCombo(_P_Cmb_Combo, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }
        public void _Mtd_DesHabilitar()
        {
            _Pnl_Superior.Enabled = false;
            _Tb_Detalle.Enabled = false;
            _GrpB_Cond1.Enabled = false;
            _GrpB_Cond2.Enabled = false;
            _GrpB_Cond3.Enabled = false;
            _GrpB_Cond4.Enabled = false;
            _GrpB_Cond5.Enabled = false;
            //-----
            _GrpB_Cond11.Enabled = false;
            _GrpB_Cond12.Enabled = false;
            _GrpB_Cond13.Enabled = false;
        }
        public void _Mtd_Habilitar()
        {
            _Pnl_Superior.Enabled = true;
            _Pnl_Asesor.Enabled = true; _Pnl_Cuota.Enabled = true;
        }
        public void _Mtd_Ini()
        {
            _Er_Error.Dispose();
            _Rbt_Fijo.Checked = false;
            _Rbt_Periodo.Checked = false;
            _Dtp_Desde.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dtp_Desde.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dtp_Hasta.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Pnl_Asesor.Enabled = true; _Pnl_Cuota.Enabled = true;
            //--------------------------------
            _Int_GrupoIncCob = 0;
            _Str_TipoCargo = "";
            _Tb_Detalle.SelectedIndex = 0;
            _Num_cporcactivaclient_a.Value = 0;
            //--------------------------------
            _Txt_ccondicion1_asesor.Text = "";
            _Txt_ccondicion2_asesor.Text = "";
            _Txt_ccondicion3_asesor.Text = "";
            _Txt_ccondicion4_asesor.Text = "";
            _Txt_ccondicion5_asesor.Text = "";
            //-----
            _Num_cporccomision1_asesor.Value = 0;
            _Num_cporccomision2_asesor.Value = 0;
            _Num_cporccomision3_asesor.Value = 0;
            _Num_cporccomision4_asesor.Value = 0;
            _Num_cporccomision5_asesor.Value = 0;
            //-----
            _Num_cporccomisiondomfer1_asesor.Value = 0;
            _Num_cporccomisiondomfer2_asesor.Value = 0;
            _Num_cporccomisiondomfer3_asesor.Value = 0;
            _Num_cporccomisiondomfer4_asesor.Value = 0;
            _Num_cporccomisiondomfer5_asesor.Value = 0;
            //--------------------------------
            _Txt_cuota_ccondicion1.Text = "";
            _Txt_cuota_ccondicion2.Text = "";
            _Txt_cuota_ccondicion3.Text = "";
            //-----
            _Txt_cuota_ccomision1.Text = "";
            _Txt_cuota_ccomision2.Text = "";
            _Txt_cuota_ccomision3.Text = "";
            //-----
            _Bt_Cuota_Condicion3.Enabled = true;
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
            var _Var_Datos = from Campos in Program._Dat_Vistas.VST_INC_COB
                             where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp
                             select new { Grupo_Insentivo = Campos.cidgrupincentivar, Descripción = Campos.cdescripcion, Fíjo = Campos.civfijo == 1 ? "Sí" : "No", Campos.cidcargonom };
            if (_Cmb_Cargo.SelectedIndex > 0)
            { _Var_Datos = _Var_Datos.Where(c => c.cidcargonom == Convert.ToString(_Cmb_Cargo.SelectedValue).Trim()); }
            _Dg_Grid.DataSource = _Var_Datos;
            _Dg_Grid.Columns["Grupo_Insentivo"].Visible = false;
            _Dg_Grid.Columns["cidcargonom"].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private bool _Mtd_Existe(int _P_Int_GrupoInc)
        {
            return (from Campos in Program._Dat_Tablas.TINCCOB
                    where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == _P_Int_GrupoInc
                    select Campos.cidgrupincentivar).Count() > 0;
        }
        private void _Mtd_HabilitarTextbox(string _P_Str_DescripCargo)
        {
            if (_Lbl_Grupo.Text.Trim().Length == 0)
            {
                if (_P_Str_DescripCargo == "Vendedor")
                {
                    _GrpB_Cond1.Enabled = true;
                    _GrpB_Cond2.Enabled = true;
                    _GrpB_Cond3.Enabled = true;
                    _GrpB_Cond4.Enabled = true;
                    _GrpB_Cond5.Enabled = true;
                    _GrpB_Cond11.Enabled = true;
                    _GrpB_Cond12.Enabled = true;
                    _GrpB_Cond13.Enabled = true;
                }
                else
                {
                    _GrpB_Cond11.Enabled = true;
                    _GrpB_Cond12.Enabled = true;
                }
            }

        }
        private void _Mtd_Habilitar_Tb_Detalle(string _P_Str_Cargo)
        {
            if ((from Campos in Program._Dat_Tablas.TCARGOSNOM
                 where Campos.cidcargonom == _P_Str_Cargo & Campos.cvendedor == 1
                 select Campos.cidcargonom).Count() > 0)
            {
                _Str_TipoCargo = "Vendedor";
            }
            else if ((from Campos in Program._Dat_Tablas.TCARGOSNOM
                      where Campos.cidcargonom == _P_Str_Cargo & Campos.cgerarea == 1
                      select Campos.cidcargonom).Count() > 0)
            {
                _Str_TipoCargo = "GerArea"; _Tb_Detalle.SelectedIndex = 1; _Bt_Cuota_Condicion3.Enabled = false;
            }
            else if ((from Campos in Program._Dat_Tablas.TCARGOSNOM
                      where Campos.cidcargonom == _P_Str_Cargo & Campos.cgventas == 1
                      select Campos.cidcargonom).Count() > 0)
            {
                _Str_TipoCargo = "GerVentas"; _Tb_Detalle.SelectedIndex = 1; _Bt_Cuota_Condicion3.Enabled = false;
            }
            else if ((from Campos in Program._Dat_Tablas.TCARGOSNOM//Se hace de esta manera por si acaso en un futuro se agregan mas cargos
                      where Campos.cidcargonom == _P_Str_Cargo & Campos.cgercomer == 1
                      select Campos.cidcargonom).Count() > 0)
            {
                _Str_TipoCargo = "GerComer"; _Tb_Detalle.SelectedIndex = 1; _Bt_Cuota_Condicion3.Enabled = false;
            }
        }
        private void _Mtd_DesHabilitarGroupBox(Panel _P_Pnl_Panel, Control _P_Grb_Excepcion)
        {
            //foreach (Control _Ctrl in _P_Pnl_Panel.Controls)
            //{
            //    if (_Ctrl.GetType() == typeof(GroupBox) & _Ctrl.Name != _P_Grb_Excepcion.Name)
            //    { _Ctrl.Enabled = false; }
            //}
        }
        private string _Mtd_ObtenerTipoCargo(int _P_Int_GrupoInc)
        {
            return (from Campos in Program._Dat_Tablas.TGRUPOIV
                                 where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == _P_Int_GrupoInc
                                 select Campos.cidcargonom).Single().Trim();
        }
        private void _Mtd_Igualar(int _P_Int_GrupoInc)
        {
            var _Var_Datos = (from Campos in Program._Dat_Tablas.TINCCOB
                              where Campos.cgroupcomp == (Convert.ToInt32(Frm_Padre._Str_GroupComp)) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == _P_Int_GrupoInc
                              select Campos).Single();
            _Int_GrupoIncCob = _P_Int_GrupoInc;
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
            _Mtd_Habilitar_Tb_Detalle(_Mtd_ObtenerTipoCargo(_P_Int_GrupoInc));
            switch (_Str_TipoCargo)
            {
                case "Vendedor":
                    _Num_cporcactivaclient_a.Value = (decimal)_Var_Datos.cporcactivaclient_a;
                    _Txt_ccondicion1_asesor.Text = _Var_Datos.ccondicion1_asesor;
                    _Txt_ccondicion2_asesor.Text = _Var_Datos.ccondicion2_asesor;
                    _Txt_ccondicion3_asesor.Text = _Var_Datos.ccondicion3_asesor;
                    _Txt_ccondicion4_asesor.Text = _Var_Datos.ccondicion4_asesor;
                    _Txt_ccondicion5_asesor.Text = _Var_Datos.ccondicion5_asesor;
                    //------------
                    _Num_cporccomision1_asesor.Value = (decimal)_Var_Datos.cporccomision1_asesor;
                    _Num_cporccomision2_asesor.Value = (decimal)_Var_Datos.cporccomision2_asesor;
                    _Num_cporccomision3_asesor.Value = (decimal)_Var_Datos.cporccomision3_asesor;
                    _Num_cporccomision4_asesor.Value = (decimal)_Var_Datos.cporccomision4_asesor;
                    _Num_cporccomision5_asesor.Value = (decimal)_Var_Datos.cporccomision5_asesor;
                    //------------
                    _Num_cporccomisiondomfer1_asesor.Value = (decimal)_Var_Datos.cporccomisiondomfer1_asesor;
                    _Num_cporccomisiondomfer2_asesor.Value = (decimal)_Var_Datos.cporccomisiondomfer2_asesor;
                    _Num_cporccomisiondomfer3_asesor.Value = (decimal)_Var_Datos.cporccomisiondomfer3_asesor;
                    _Num_cporccomisiondomfer4_asesor.Value = (decimal)_Var_Datos.cporccomisiondomfer4_asesor;
                    _Num_cporccomisiondomfer5_asesor.Value = (decimal)_Var_Datos.cporccomisiondomfer5_asesor;
                    //----------------------------------------
                    _Txt_cuota_ccondicion1.Text = _Var_Datos.ccobertura1_asesor;
                    _Txt_cuota_ccondicion2.Text = _Var_Datos.ccobertura2_asesor;
                    _Txt_cuota_ccondicion3.Text = _Var_Datos.ccobertura3_asesor;
                    //------------
                    _Txt_cuota_ccomision1.Text = Convert.ToString(_Var_Datos.ccomisioncob1_asesor);
                    _Txt_cuota_ccomision2.Text = Convert.ToString(_Var_Datos.ccomisioncob2_asesor);
                    _Txt_cuota_ccomision3.Text = Convert.ToString(_Var_Datos.ccomisioncob3_asesor);
                    break;
                case "GerArea":
                    _Txt_cuota_ccondicion1.Text = _Var_Datos.ccondicion1_garea;
                    _Txt_cuota_ccondicion2.Text = _Var_Datos.ccondicion2_garea;
                    //------------
                    _Txt_cuota_ccomision1.Text = Convert.ToString(_Var_Datos.ccomision1_garea);
                    _Txt_cuota_ccomision2.Text = Convert.ToString(_Var_Datos.ccomision2_garea);
                    break;
                case "GerVentas":
                    _Txt_cuota_ccondicion1.Text = _Var_Datos.ccondicion1_gvtas;
                    _Txt_cuota_ccondicion2.Text = _Var_Datos.ccondicion2_gvtas;
                    //------------
                    _Txt_cuota_ccomision1.Text = Convert.ToString(_Var_Datos.ccomision1_gvtas);
                    _Txt_cuota_ccomision2.Text = Convert.ToString(_Var_Datos.ccomision2_gvtas);
                    break;
                case "GerComer":
                    _Txt_cuota_ccondicion1.Text = _Var_Datos.ccondicion1_gcomer;
                    _Txt_cuota_ccondicion2.Text = _Var_Datos.ccondicion2_gcomer;
                    //------------
                    _Txt_cuota_ccomision1.Text = Convert.ToString(_Var_Datos.ccomision1_gcomer);
                    _Txt_cuota_ccomision2.Text = Convert.ToString(_Var_Datos.ccomision2_gcomer);
                    break;
                default:
                    break;
            }
        }
        private void _Mtd_GuardarTINCCOB(int _P_Int_GrupoInc)
        {
            DataContext.TINCCOB _T_TINCCOB;
            bool _Bol_Existe = _Mtd_Existe(_P_Int_GrupoInc);
            if (_Bol_Existe)
            { _T_TINCCOB = Program._Dat_Tablas.TINCCOB.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidgrupincentivar == _P_Int_GrupoInc); }
            else
            {
                _T_TINCCOB = new T3.DataContext.TINCCOB();
                _T_TINCCOB.cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp);
                _T_TINCCOB.ccompany = Frm_Padre._Str_Comp;
                _T_TINCCOB.cidinccob = new _Cls_Consecutivos()._Mtd_IncCob();
                _T_TINCCOB.cidgrupincentivar = _P_Int_GrupoInc;
            }
            _T_TINCCOB.civfijo = Convert.ToByte(_Rbt_Fijo.Checked);
            _T_TINCCOB.cfechadesde = _Dtp_Desde.Value;
            _T_TINCCOB.cfechahasta = _Dtp_Hasta.Value;
            switch (_Str_TipoCargo)
            {
                case "Vendedor":
                    _T_TINCCOB.cporcactivaclient_a = _Num_cporcactivaclient_a.Value;
                    _T_TINCCOB.ccondicion1_asesor = _Txt_ccondicion1_asesor.Text;
                    _T_TINCCOB.ccondicion2_asesor = _Txt_ccondicion2_asesor.Text;
                    _T_TINCCOB.ccondicion3_asesor = _Txt_ccondicion3_asesor.Text;
                    _T_TINCCOB.ccondicion4_asesor = _Txt_ccondicion4_asesor.Text;
                    _T_TINCCOB.ccondicion5_asesor = _Txt_ccondicion5_asesor.Text;
                    //------------
                    _T_TINCCOB.cporccomision1_asesor = _Num_cporccomision1_asesor.Value;
                    _T_TINCCOB.cporccomision2_asesor = _Num_cporccomision2_asesor.Value;
                    _T_TINCCOB.cporccomision3_asesor = _Num_cporccomision3_asesor.Value;
                    _T_TINCCOB.cporccomision4_asesor = _Num_cporccomision4_asesor.Value;
                    _T_TINCCOB.cporccomision5_asesor = _Num_cporccomision5_asesor.Value;
                    //------------
                    _T_TINCCOB.cporccomisiondomfer1_asesor = _Num_cporccomisiondomfer1_asesor.Value;
                    _T_TINCCOB.cporccomisiondomfer2_asesor = _Num_cporccomisiondomfer2_asesor.Value;
                    _T_TINCCOB.cporccomisiondomfer3_asesor = _Num_cporccomisiondomfer3_asesor.Value;
                    _T_TINCCOB.cporccomisiondomfer4_asesor = _Num_cporccomisiondomfer4_asesor.Value;
                    _T_TINCCOB.cporccomisiondomfer5_asesor = _Num_cporccomisiondomfer5_asesor.Value;
                    //----------------------------------------
                    _T_TINCCOB.ccobertura1_asesor = _Txt_cuota_ccondicion1.Text;
                    _T_TINCCOB.ccobertura2_asesor = _Txt_cuota_ccondicion2.Text;
                    _T_TINCCOB.ccobertura3_asesor = _Txt_cuota_ccondicion3.Text;
                    //------------
                    _T_TINCCOB.ccomisioncob1_asesor = Convert.ToDecimal(_Txt_cuota_ccomision1.Text);
                    _T_TINCCOB.ccomisioncob2_asesor = Convert.ToDecimal(_Txt_cuota_ccomision2.Text);
                    _T_TINCCOB.ccomisioncob3_asesor = Convert.ToDecimal(_Txt_cuota_ccomision3.Text);
                    break;
                case "GerArea":
                    _T_TINCCOB.ccondicion1_garea = _Txt_cuota_ccondicion1.Text;
                    _T_TINCCOB.ccondicion2_garea = _Txt_cuota_ccondicion2.Text;
                    //------------
                    _T_TINCCOB.ccomision1_garea = Convert.ToDecimal(_Txt_cuota_ccomision1.Text);
                    _T_TINCCOB.ccomision2_garea = Convert.ToDecimal(_Txt_cuota_ccomision2.Text);
                    break;
                case "GerVentas":
                    _T_TINCCOB.ccondicion1_gvtas = _Txt_cuota_ccondicion1.Text;
                    _T_TINCCOB.ccondicion2_gvtas = _Txt_cuota_ccondicion2.Text;
                    //------------
                    _T_TINCCOB.ccomision1_gvtas = Convert.ToDecimal(_Txt_cuota_ccomision1.Text);
                    _T_TINCCOB.ccomision2_gvtas = Convert.ToDecimal(_Txt_cuota_ccomision2.Text);
                    break;
                case "GerComer":
                    _T_TINCCOB.ccondicion1_gcomer = _Txt_cuota_ccondicion1.Text;
                    _T_TINCCOB.ccondicion2_gcomer = _Txt_cuota_ccondicion2.Text;
                    //------------
                    _T_TINCCOB.ccomision1_gcomer = Convert.ToDecimal(_Txt_cuota_ccomision1.Text);
                    _T_TINCCOB.ccomision2_gcomer = Convert.ToDecimal(_Txt_cuota_ccomision2.Text);
                    break;
                default:
                    break;
            }
            if (_Bol_Existe)
            {
                _T_TINCCOB.cdateupd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _T_TINCCOB.cuserupd = Frm_Padre._Str_Use;
            }
            else
            {
                _T_TINCCOB.cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _T_TINCCOB.cuseradd = Frm_Padre._Str_Use;
                Program._Dat_Tablas.TINCCOB.InsertOnSubmit(_T_TINCCOB); 
            }
            Program._Dat_Tablas.SubmitChanges();
        }
        public bool _Mtd_Editar()
        {
            return _Mtd_Guardar();
        }
        private bool _Mtd_VerifCampObligVendedor()
        {
            if (_Str_TipoCargo == "Vendedor")
            {
                if (
                    !((_Txt_ccondicion1_asesor.Text.Trim().Length > 0 & _Num_cporccomision1_asesor.Value > 0 & _Num_cporccomisiondomfer1_asesor.Value > 0)
                    |
                    (_Txt_ccondicion2_asesor.Text.Trim().Length > 0 & _Num_cporccomision2_asesor.Value > 0 & _Num_cporccomisiondomfer2_asesor.Value > 0)
                    |
                    (_Txt_ccondicion3_asesor.Text.Trim().Length > 0 & _Num_cporccomision3_asesor.Value > 0 & _Num_cporccomisiondomfer3_asesor.Value > 0)
                    |
                    (_Txt_ccondicion4_asesor.Text.Trim().Length > 0 & _Num_cporccomision4_asesor.Value > 0 & _Num_cporccomisiondomfer4_asesor.Value > 0)
                    |
                    (_Txt_ccondicion5_asesor.Text.Trim().Length > 0 & _Num_cporccomision5_asesor.Value > 0 & _Num_cporccomisiondomfer5_asesor.Value > 0)
                    ))
                {
                    MessageBox.Show("Debe ingresar por lo menos una información completa en la pestaña (Asesor Comercial (Días)).", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if
                    (
                    !((_Txt_cuota_ccomision1.Text.Trim().Length > 0 & _Mtd_VerifContTextBoxNumeric(_Txt_cuota_ccomision1))
                    |
                    (_Txt_cuota_ccomision2.Text.Trim().Length > 0 & _Mtd_VerifContTextBoxNumeric(_Txt_cuota_ccomision2))
                    |
                    (_Txt_cuota_ccomision3.Text.Trim().Length > 0 & _Mtd_VerifContTextBoxNumeric(_Txt_cuota_ccomision3))
                    ))
                {
                    MessageBox.Show("Debe ingresar por lo menos una información completa en la pestaña (Cuota).", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                if (
                   !((_Txt_cuota_ccomision1.Text.Trim().Length > 0 & _Mtd_VerifContTextBoxNumeric(_Txt_cuota_ccomision1))
                   |
                   (_Txt_cuota_ccomision2.Text.Trim().Length > 0 & _Mtd_VerifContTextBoxNumeric(_Txt_cuota_ccomision2))
                   |
                   (_Txt_cuota_ccomision3.Text.Trim().Length > 0 & _Mtd_VerifContTextBoxNumeric(_Txt_cuota_ccomision3))
                   ))
                {
                    MessageBox.Show("Debe ingresar por lo menos una información completa en la pestaña (Cuota).", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }
        private bool _Mtd_VerificarInfCompletaAseComer(TextBox _P_Txt_Textbox, NumericUpDown _P_NumUpDown1, NumericUpDown _P_NumUpDown2)
        {
            if (((Control)_P_NumUpDown1).Text.Trim().Length == 0) { _P_NumUpDown1.Value = 0; }
            if (((Control)_P_NumUpDown2).Text.Trim().Length == 0) { _P_NumUpDown2.Value = 0; }
            if (_P_Txt_Textbox.Text.Trim().Length > 0 & (_P_NumUpDown1.Value == 0 | _P_NumUpDown2.Value == 0))
            { return false; }
            else if (_P_NumUpDown1.Value > 0 & (_P_Txt_Textbox.Text.Trim().Length == 0 & _P_NumUpDown2.Value == 0))
            { return false; }
            else if (_P_NumUpDown2.Value > 0 & (_P_Txt_Textbox.Text.Trim().Length == 0 & _P_NumUpDown1.Value == 0))
            { return false; }
            else if (_P_Txt_Textbox.Text.Trim().Length > 0 & _P_NumUpDown1.Value > 0 & _P_NumUpDown2.Value == 0)
            { return false; }
            else if (_P_Txt_Textbox.Text.Trim().Length > 0 & _P_NumUpDown1.Value == 0 & _P_NumUpDown2.Value > 0)
            { return false; }
            else if (_P_Txt_Textbox.Text.Trim().Length == 0 & _P_NumUpDown1.Value > 0 & _P_NumUpDown2.Value > 0)
            { return false; }
            return true;
        }
        private bool _Mtd_VerificarInfCompletaCuota(TextBox _P_Txt_Textbox1, TextBox _P_Txt_Textbox2)
        {
            if (_P_Txt_Textbox1.Text.Trim().Length > 0 & !_Mtd_VerifContTextBoxNumeric(_P_Txt_Textbox2))
            { return false; }
            else if (_P_Txt_Textbox1.Text.Trim().Length == 0 & _Mtd_VerifContTextBoxNumeric(_P_Txt_Textbox2))
            { return false; }
            return true;
        }
        private bool _Mtd_InfCompleta()
        {
            if (_Str_TipoCargo == "Vendedor")
            {
                if (
                    !_Mtd_VerificarInfCompletaAseComer(_Txt_ccondicion1_asesor, _Num_cporccomision1_asesor, _Num_cporccomisiondomfer1_asesor)
                    |
                    !_Mtd_VerificarInfCompletaAseComer(_Txt_ccondicion2_asesor, _Num_cporccomision2_asesor, _Num_cporccomisiondomfer2_asesor)
                    |
                    !_Mtd_VerificarInfCompletaAseComer(_Txt_ccondicion3_asesor, _Num_cporccomision3_asesor, _Num_cporccomisiondomfer3_asesor)
                    |
                    !_Mtd_VerificarInfCompletaAseComer(_Txt_ccondicion4_asesor, _Num_cporccomision4_asesor, _Num_cporccomisiondomfer4_asesor)
                    |
                    !_Mtd_VerificarInfCompletaAseComer(_Txt_ccondicion5_asesor, _Num_cporccomision5_asesor, _Num_cporccomisiondomfer5_asesor)
                    )
                {
                    MessageBox.Show("Existen condiciones con datos incompletos. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if
                    (
                    !_Mtd_VerificarInfCompletaCuota(_Txt_cuota_ccondicion1, _Txt_cuota_ccomision1)
                    |
                    !_Mtd_VerificarInfCompletaCuota(_Txt_cuota_ccondicion2, _Txt_cuota_ccomision2)
                    |
                    !_Mtd_VerificarInfCompletaCuota(_Txt_cuota_ccondicion3, _Txt_cuota_ccomision3)
                    )
                {
                    MessageBox.Show("Existen condiciones con datos incompletos. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                if(
                  !_Mtd_VerificarInfCompletaCuota(_Txt_cuota_ccondicion1, _Txt_cuota_ccomision1)
                  |
                  !_Mtd_VerificarInfCompletaCuota(_Txt_cuota_ccondicion2, _Txt_cuota_ccomision2)
                  |
                  !_Mtd_VerificarInfCompletaCuota(_Txt_cuota_ccondicion3, _Txt_cuota_ccomision3)
                  )
                {
                    MessageBox.Show("Existen registros con datos incompletos. Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }
        public bool _Mtd_Guardar()
        {
            if (_Rbt_Fijo.Checked | _Rbt_Periodo.Checked)
            {
                if (_Mtd_InfCompleta())
                {
                    if (_Mtd_VerifCampObligVendedor())
                    {
                        bool _Bol_Asesor = _Mtd_ValidarCondiciones(new TextBox[] { _Txt_ccondicion1_asesor, _Txt_ccondicion2_asesor, _Txt_ccondicion3_asesor, _Txt_ccondicion4_asesor, _Txt_ccondicion5_asesor });
                        bool _Bol_Cuota = _Mtd_ValidarCondiciones(new TextBox[] { _Txt_cuota_ccondicion1, _Txt_cuota_ccondicion2, _Txt_cuota_ccondicion3 });
                        if (_Bol_Asesor & _Bol_Cuota)
                        {
                            if (_Txt_cuota_ccomision1.Text.Trim().Length == 0) { _Txt_cuota_ccomision1.Text = "0"; }
                            if (_Txt_cuota_ccomision2.Text.Trim().Length == 0) { _Txt_cuota_ccomision2.Text = "0"; }
                            if (_Txt_cuota_ccomision3.Text.Trim().Length == 0) { _Txt_cuota_ccomision3.Text = "0"; }
                            Cursor = Cursors.WaitCursor;
                            _Mtd_GuardarTINCCOB(_Int_GrupoIncCob);
                            Cursor = Cursors.Default;
                            MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cursor = Cursors.WaitCursor;
                            _Mtd_Actualizar();
                            _Tb_Tab.SelectedIndex = 0;
                            Cursor = Cursors.Default;
                            return true;
                        }
                        else
                        {
                            if (!_Bol_Asesor)
                            { MessageBox.Show("Una o más condiciones han sido creadas incorrectamente en la pestaña (Asesor Comercial (Días)). Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                            else
                            { MessageBox.Show("Una o más condiciones han sido creadas incorrectamente en la pestaña (Cuota). Por favor verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                        }
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
        private void _Mtd_EliminarRegistros()
        {
            var _Var_Datos = from Campos in _Dg_Grid.Rows.Cast<DataGridViewRow>()
                             where Campos.Selected
                             select Campos;
            foreach (DataGridViewRow _DgRow in _Var_Datos)
            {
                Program._Dat_Tablas.TINCCOB.DeleteOnSubmit(Program._Dat_Tablas.TINCCOB.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidgrupincentivar == Convert.ToInt32(_DgRow.Cells["Grupo_Insentivo"].Value)));
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
        private void Frm_IncCobranza_Load(object sender, EventArgs e)
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

        private void Frm_IncCobranza_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_COB");
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _Pnl_Superior.Enabled;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = ((_Rbt_Fijo.Checked | _Rbt_Periodo.Checked) & !_Pnl_Superior.Enabled) & _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_COB");
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
        }

        private void Frm_IncCobranza_FormClosing(object sender, FormClosingEventArgs e)
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

        private void _Bt_Condicion1_Click(object sender, EventArgs e)
        {
            _GrpB_Cond1.Enabled = !_GrpB_Cond1.Enabled;
            _Txt_ccondicion1_asesor.Focus();
            _Mtd_DesHabilitarGroupBox(_Pnl_Asesor, _GrpB_Cond1);
        }

        private void _Bt_Condicion2_Click(object sender, EventArgs e)
        {
            _GrpB_Cond2.Enabled = !_GrpB_Cond2.Enabled;
            _Txt_ccondicion2_asesor.Focus();
            _Mtd_DesHabilitarGroupBox(_Pnl_Asesor, _GrpB_Cond2);
        }

        private void _Bt_Condicion3_Click(object sender, EventArgs e)
        {
            _GrpB_Cond3.Enabled = !_GrpB_Cond3.Enabled;
            _Txt_ccondicion3_asesor.Focus();
            _Mtd_DesHabilitarGroupBox(_Pnl_Asesor, _GrpB_Cond3);
        }

        private void _Bt_Condicion4_Click(object sender, EventArgs e)
        {
            _GrpB_Cond4.Enabled = !_GrpB_Cond4.Enabled;
            _Txt_ccondicion4_asesor.Focus();
            _Mtd_DesHabilitarGroupBox(_Pnl_Asesor, _GrpB_Cond4);
        }

        private void _Bt_Condicion5_Click(object sender, EventArgs e)
        {
            _GrpB_Cond5.Enabled = !_GrpB_Cond5.Enabled;
            _Txt_ccondicion5_asesor.Focus();
            _Mtd_DesHabilitarGroupBox(_Pnl_Asesor, _GrpB_Cond5);
        }

        private void _Bt_Cuota_Condicion1_Click(object sender, EventArgs e)
        {
            _GrpB_Cond11.Enabled = !_GrpB_Cond11.Enabled;
            _Txt_cuota_ccondicion1.Focus();
            _Mtd_DesHabilitarGroupBox(_Pnl_Cuota, _GrpB_Cond11);
        }

        private void _Bt_Cuota_Condicion2_Click(object sender, EventArgs e)
        {
            _GrpB_Cond12.Enabled = !_GrpB_Cond12.Enabled;
            _Txt_cuota_ccondicion2.Focus();
            _Mtd_DesHabilitarGroupBox(_Pnl_Cuota, _GrpB_Cond12);
        }

        private void _Bt_Cuota_Condicion3_Click(object sender, EventArgs e)
        {
            _GrpB_Cond13.Enabled = !_GrpB_Cond13.Enabled;
            _Txt_cuota_ccondicion3.Focus();
            _Mtd_DesHabilitarGroupBox(_Pnl_Cuota, _GrpB_Cond13);
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
                _Int_GrupoIncCob = Convert.ToInt32(_Cmb_Grupo_D.SelectedValue);
                _Mtd_Habilitar_Tb_Detalle(Convert.ToString(_Cmb_Cargo_D.SelectedValue).Trim());
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
            { _Tb_Detalle.Enabled = true; _Er_Error.Dispose(); _Mtd_HabilitarTextbox(_Str_TipoCargo); }
        }
        private void _Rbt_Periodo_CheckedChanged(object sender, EventArgs e)
        {
            _Grb_Fechas.Enabled = _Rbt_Periodo.Checked;
            if (_Rbt_Periodo.Checked)
            { _Tb_Detalle.Enabled = true; _Er_Error.Dispose(); _Mtd_HabilitarTextbox(_Str_TipoCargo); }
        }
        private void _Tb_Detalle_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_Str_TipoCargo == "Vendedor")
            { e.Cancel = e.TabPageIndex > 1; }
            else if (_Str_TipoCargo == "GerArea" | _Str_TipoCargo == "GerVentas" | _Str_TipoCargo == "GerComer")//Se hace de esta manera por si acaso en un futuro se agregan mas cargos
            { e.Cancel = e.TabPageIndex != 1; }
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
                _Mtd_Igualar(Convert.ToInt32(_Dg_Grid.Rows[e.RowIndex].Cells["Grupo_Insentivo"].Value));
                _Lbl_Grupo.Text = "Grupo:\n" + Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Descripción"].Value).Trim();
                _Tb_Detalle.Enabled = true; _Pnl_Asesor.Enabled = false; _Pnl_Cuota.Enabled = false;
                _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                _Tb_Tab.SelectedIndex = 1;
                _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_COB");
                Cursor = Cursors.Default;
            }
        }

        private void Frm_IncCobranza_Shown(object sender, EventArgs e)
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
            e.Cancel = _Dg_Grid.SelectedRows.Count == 0 | !(_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_COB"));
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
