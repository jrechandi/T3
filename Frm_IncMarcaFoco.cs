
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
    public partial class Frm_IncMarcaFoco : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        bool _Bol_PermisoConfirmado = false;
        bool _Bol_UsuarioLider = false;
        bool _Bol_Nuevo = false;
        public Frm_IncMarcaFoco()
        {
            InitializeComponent();
            _Bol_PermisoConfirmado = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & (_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_MARCF") | _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_V_INCT_MARCF"));
            _Bol_UsuarioLider = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_MARCF");
            _Bt_Copiar.Enabled = _Bol_UsuarioLider;
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
            string _Str_Cadena = "SELECT cidcargonom, cdescripcion FROM TCARGOSNOM WHERE ISNULL(cdelete,0)='0' AND (cgerarea='1' OR cvendedor='1' OR cgventas='1')";
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
            { _Str_Cadena += " AND NOT EXISTS(SELECT cidgrupincentivar FROM TINCMARCAFOCO WHERE cgroupcomp=TGRUPOIV.cgroupcomp AND ccompany=TGRUPOIV.ccompany AND cidgrupincentivar=TGRUPOIV.cidgrupincentivar)"; }
            _Str_Cadena += " ORDER BY cdescripcion";
            _Cls_VariosMetodos._Mtd_CargarCombo(_P_Cmb_Combo, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_CargarCanal()
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT RTRIM(ccanal), RTRIM(cname) FROM TTCANAL WHERE ISNULL(cdelete,0)='0' ORDER BY cname ASC";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Canal, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_CargarEstablecimiento(ComboBox _P_Cmb_ComboFiltro)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT RTRIM(ctestablecim), RTRIM(cname) FROM TTESTABLECIM WHERE ISNULL(cdelete,0)='0'";
            _Str_Cadena += " AND ccanal='" + Convert.ToString(_P_Cmb_ComboFiltro.SelectedValue).Trim() + "'";
            _Str_Cadena += " ORDER BY cname";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Establecimiento, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_CargarAños()
        {
            _Cmb_Ano.Items.Clear();
            _Cmb_Ano.Items.Add("...");
            //for (int _Int_I = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Year; _Int_I <= CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().AddYears(2).Year; _Int_I++)
            for (int _Int_I = 2010; _Int_I <= CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().AddYears(2).Year; _Int_I++)
            {
                _Cmb_Ano.Items.Add(_Int_I);
            }
            _Cmb_Ano.SelectedIndex = 0;
        }
        private void _Mtd_CargarMeses(int _P_Int_Año)
        {
            _Cmb_Mes.Items.Clear();
            _Cmb_Mes.Items.Add("...");
            //int _Int_Mes = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Month;
            //if (_P_Int_Año > CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Year)
            //{ _Int_Mes = 1; }
            //for (int _Int_I = _Int_Mes; _Int_I <= 12; _Int_I++)
            for (int _Int_I = 1; _Int_I <= 12; _Int_I++)
            {
                _Cmb_Mes.Items.Add(_Int_I);
            }
            _Cmb_Mes.SelectedIndex = 0;
        }
        private void _Mtd_Cargar_Proveedor(string _P_Str_Grupo)
        {
            string _Str_Cadena = "SELECT DISTINCT VST_PRODUCTOS_A.cproveedor, VST_PRODUCTOS_A.c_nomb_abreviado " +
                                 "FROM TGRUPPROVEE INNER JOIN " +
                                 "TGRUPOIV ON TGRUPPROVEE.cgrupovta = TGRUPOIV.cgrupovta AND " +
                                 "TGRUPPROVEE.ccompany = TGRUPOIV.ccompany INNER JOIN " +
                                 "VST_PRODUCTOS_A ON TGRUPPROVEE.cproveedor = VST_PRODUCTOS_A.cproveedor AND " +
                                 "TGRUPOIV.ccompany = VST_PRODUCTOS_A.companyprov " +
                                 "WHERE (NOT EXISTS (SELECT cproveedor FROM TFILTROREGIONALP " +
                                 "WHERE (VST_PRODUCTOS_A.cproveedor = cproveedor) AND (VST_PRODUCTOS_A.cproducto = cproducto) AND (ccompany = '" + Frm_Padre._Str_Comp + "') AND (cdelete = '0'))) AND (TGRUPOIV.cidgrupincentivar = '" + _P_Str_Grupo + "') and VST_PRODUCTOS_A.cdelete=0 AND VST_PRODUCTOS_A.companyprov='" + Frm_Padre._Str_Comp + "' ORDER BY VST_PRODUCTOS_A.c_nomb_abreviado";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Proveedor, _Str_Cadena);
        }
        private void _Mtd_Cargar_Linea(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT distinct TGRUPPROM.ccodgrupop, TGRUPPROM.cname " +
            "FROM dbo.TGRUPPROM INNER JOIN " +
            "TGRUPPROD ON TGRUPPROM.ccodgrupop = TGRUPPROD.ccodgrupop AND " +
            "TGRUPPROM.cdelete = TGRUPPROD.cdelete INNER JOIN " +
            "TPRODUCTO ON TGRUPPROD.cproveedor = TPRODUCTO.cproveedor AND TGRUPPROD.ccodgrupop = TPRODUCTO.cgrupo " +
            "WHERE NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE TGRUPPROD.cproveedor=TFILTROREGIONALP.cproveedor and TPRODUCTO.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') " +
            "AND (TGRUPPROD.cproveedor = '" + _P_Str_Proveedor + "') AND (TGRUPPROM.cdelete = 0) AND (TPRODUCTO.cdelete=0) ORDER BY TGRUPPROM.cname";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Linea, _Str_Cadena);
        }
        private void _Mtd_Cargar_Subgrupo(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            string _Str_Cadena = "SELECT DISTINCT RTRIM(TSUBGRUPOM.ccodsubgrup) AS ccodsubgrup, RTRIM(TSUBGRUPOM.cname) AS cnamesub " +
            "FROM TSUBGRUPOM INNER JOIN " +
            "TSUBGRUPOD ON TSUBGRUPOM.ccodsubgrup = TSUBGRUPOD.ccodsubgrup AND " +
            "TSUBGRUPOM.cdelete = TSUBGRUPOD.cdelete INNER JOIN " +
            "TPRODUCTO ON TSUBGRUPOD.cproveedor = TPRODUCTO.cproveedor AND " +
            "TSUBGRUPOD.ccodsubgrup = TPRODUCTO.csubgrupo AND TSUBGRUPOD.ccodgrupop = TPRODUCTO.cgrupo " +
            "WHERE NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE TPRODUCTO.cproveedor=TFILTROREGIONALP.cproveedor and TPRODUCTO.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') " +
            "AND (TSUBGRUPOM.cdelete = 0) AND (TSUBGRUPOD.cproveedor = '" + _P_Str_Proveedor + "') AND (TSUBGRUPOD.ccodgrupop = '" + _P_Str_Grupo + "') AND (TPRODUCTO.cdelete=0) ORDER BY cnamesub";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Subgrupo, _Str_Cadena);
        }
        private void _Mtd_IniPnl_Detalle_1()
        {
            _Txt_cidincmarcafoco.Text = "";
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarCargos(_Cmb_Cargo_D);
            Cursor = Cursors.Default;
            _Cmb_Grupo_D.DataSource = null;
        }
        private void _Mtd_IniGrpB_Negociacion()
        {
            _Txt_ccomisiontotal.Text = "";
            _Num_PorcVolumentVtasMin.Value = 0;
        }
        private void _Mtd_IniPnl_Detalle_2()
        {
            _Cmb_Canal.DataSource = null;
            _Cmb_Establecimiento.DataSource = null;
            _Cmb_Ano.Items.Clear();
            _Cmb_Mes.Items.Clear();
        }
        private void _Mtd_IniPnl_Detalle_3()
        {
            _Cmb_Proveedor.DataSource = null;
            _Cmb_Linea.DataSource = null;
            _Cmb_Subgrupo.DataSource = null;
            _Txt_Producto.Tag = ""; _Txt_Producto.Text = "";
            _Num_cporcactivamin.Value = 0;
        }
        private void _Mtd_Deshabilitar_Pnl_Detalle_1()
        {
            _Cmb_Cargo_D.Enabled = false;
            _Cmb_Grupo_D.Enabled = false;
        }
        private void _Mtd_Habilitar_GrpB_Negociacion(bool _P_Bol_Habilitar)
        {
            _Txt_ccomisiontotal.Enabled = _P_Bol_Habilitar;
            if (_P_Bol_Habilitar)
            {
                _Mtd_HabilitarPorVentasMin(Convert.ToString(_Cmb_Cargo_D.SelectedValue).Trim());
            }
            else
            {
                _Num_PorcVolumentVtasMin.Enabled = false;
                _Lbl_PorcVolumentVtasMin.Enabled = false;
            }
        }
        private void _Mtd_Deshabilitar_Pnl_Detalle_2()
        {
            _Cmb_Canal.Enabled = false;
            _Cmb_Establecimiento.Enabled = false;
            _Cmb_Ano.Enabled = false;
            _Cmb_Mes.Enabled = false;
        }
        private void _Mtd_Deshabilitar_Pnl_Detalle_3()
        {
            _Cmb_Proveedor.Enabled = false;
            _Cmb_Linea.Enabled = false;
            _Cmb_Subgrupo.Enabled = false;
            _Txt_Producto.Enabled = false;
            _Num_cporcactivamin.Enabled = false;
        }
        public void _Mtd_Habilitar()
        {
            _GrpB_Negociacion.Enabled = true;
            _Pnl_Detalle_2.Enabled = _Mtd_TipoCargo(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 'A';
            _Bt_Eliminar.Enabled = _Dg_Detalle.RowCount > 0 & _Bol_UsuarioLider;
            _Bt_Agregar.Enabled = _Bol_UsuarioLider & _Cmb_Canal.SelectedIndex > 0 & _Cmb_Establecimiento.SelectedIndex > 0 & _Cmb_Ano.SelectedIndex > 0 & _Cmb_Mes.SelectedIndex > 0;
        }
        private void _Mtd_Ini()
        {
            _Mtd_IniPnl_Detalle_1();
            _Mtd_IniGrpB_Negociacion();
            _Mtd_IniPnl_Detalle_2();
            _Mtd_IniPnl_Detalle_3();
            _Mtd_Deshabilitar_Pnl_Detalle_1();
            _Mtd_Habilitar_GrpB_Negociacion(false);
            _Mtd_Deshabilitar_Pnl_Detalle_2();
            _Mtd_Deshabilitar_Pnl_Detalle_3();
            _Pnl_Detalle_1.Enabled = false;
            _GrpB_Negociacion.Enabled = false;
            _Pnl_Detalle_2.Enabled = false;
            _Pnl_Detalle_3.Visible = false;
            _Mtd_IniGrid_Detalle();
        }
        public void _Mtd_Nuevo()
        {
            _Bol_Nuevo = true;
            _Mtd_Ini();
            _Bol_Nuevo = false;
            _Er_Error.Dispose();
            _Pnl_Detalle_1.Enabled = true;
            _Cmb_Cargo_D.Enabled = true;
            _Tb_Tab.SelectedIndex = 1;
            _Cmb_Cargo_D.Focus();
        }
        private bool _Mtd_Validar_GrpB_Negociacion()
        {
            _Er_Error.Dispose();
            if (_Mtd_VerifContTextBoxNumeric(_Txt_ccomisiontotal))
            {
                return true;
            }
            else
            {
                if (!_Bol_Nuevo & _Tb_Tab.SelectedIndex == 1)
                {
                    if (!_Mtd_VerifContTextBoxNumeric(_Txt_ccomisiontotal)) { _Er_Error.SetError(_Txt_ccomisiontotal, "Información requerida!!!"); }
                }
            }
            return false;
        }
        private void _Mtd_SelecSubGrupo(string _P_Str_Producto)
        {
            var _Var_Datos = (from Campos in Program._Dat_Tablas.TPRODUCTO
                             where Campos.cproducto == _P_Str_Producto
                              select Campos.csubgrupo).Single();
            _Cmb_Subgrupo.SelectedIndexChanged -= new EventHandler(_Cmb_Subgrupo_SelectedIndexChanged);
            //---------------------
            if (_Cmb_Subgrupo.SelectedIndex <= 0) { _Cmb_Subgrupo.SelectedValue = _Var_Datos.Trim(); }
            //---------------------
            _Cmb_Subgrupo.SelectedIndexChanged += new EventHandler(_Cmb_Subgrupo_SelectedIndexChanged);
        }
        private void _Mtd_Actualizar()
        {
            var _Var_Datos = from Campos in Program._Dat_Vistas.VST_INC_MARCF
                             where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp
                             select new { Grupo_Incentivo = Campos.cidgrupincentivar, Descripción = Campos.cdescripcion, Campos.cidcargonom };
            if (_Cmb_Cargo.SelectedIndex > 0)
            { _Var_Datos = _Var_Datos.Where(c => c.cidcargonom == Convert.ToString(_Cmb_Cargo.SelectedValue).Trim()); }
            _Dg_Grid.DataSource = _Var_Datos;
            _Dg_Grid.Columns["Grupo_Incentivo"].Visible = false;
            _Dg_Grid.Columns["cidcargonom"].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_IniGrid_Detalle()
        {
            var _Var_Datos = from Campos in Program._Dat_Vistas.VST_INC_MARCF_D
                             where 0 > 1
                             select new { Campos.cano, Campos.cmes, Campos.cdesccanal, Campos.cdesctestable, Campos.cdesctelemento, Campos.ccodelemento, Campos.cdescripcion, PorcActMin = Campos.cporcactivamin.ToString() + " %", Campos.cidincmarcafocod, Campos.ccanal, Campos.cestable };
            _Dg_Detalle.DataSource = _Var_Datos;
            _Dg_Detalle.Columns["cidincmarcafocod"].Visible = false;
            _Dg_Detalle.Columns["ccanal"].Visible = false;
            _Dg_Detalle.Columns["cestable"].Visible = false;
        }
        private void _Mtd_ActualizarDetalle(int _P_Int_IncMarcf)
        {
            var _Var_Datos = from Campos in Program._Dat_Vistas.VST_INC_MARCF_D
                             where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidincmarcafoco == _P_Int_IncMarcf
                             select new { Campos.cano, Campos.cmes, Campos.cdesccanal, Campos.cdesctestable, Campos.cdesctelemento, Campos.ccodelemento, Campos.cdescripcion, PorcActMin = Campos.cporcactivamin.ToString() + " %", Campos.cidincmarcafocod, Campos.ccanal, Campos.cestable };
            
            if (_Cmb_Canal.SelectedIndex > 0) { _Var_Datos = _Var_Datos.Where(c => c.ccanal == Convert.ToString(_Cmb_Canal.SelectedValue).Trim()); }
            if (_Cmb_Establecimiento.SelectedIndex > 0) { _Var_Datos = _Var_Datos.Where(c => c.cestable == Convert.ToString(_Cmb_Establecimiento.SelectedValue).Trim()); }
            if (_Cmb_Ano.SelectedIndex > 0) { _Var_Datos = _Var_Datos.Where(c => c.cano == Convert.ToInt32(_Cmb_Ano.Text)); }
            if (_Cmb_Mes.SelectedIndex > 0) { _Var_Datos = _Var_Datos.Where(c => c.cmes == Convert.ToInt32(_Cmb_Mes.Text)); }

            _Dg_Detalle.DataSource = _Var_Datos;
            _Dg_Detalle.Columns["cidincmarcafocod"].Visible = false;
            _Dg_Detalle.Columns["ccanal"].Visible = false;
            _Dg_Detalle.Columns["cestable"].Visible = false;
            //_Dg_Detalle.Columns["cano"].Visible = false;
            //_Dg_Detalle.Columns["cmes"].Visible = false;
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private bool _Mtd_ValidarGuardar(string _P_Str_IncMarcf, string _P_Str_Canal, string _P_Str_Establecimiento, int _P_Int_Año, int _P_Int_Mes, string _P_Str_Proveedor)
        {
            if (_P_Str_IncMarcf.Trim().Length > 0)
            {
                var _Var_Datos = (from Campos in Program._Dat_Tablas.TINCMARCAFOCOD
                                  where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & Campos.ccanal == _P_Str_Canal & Campos.cestable == _P_Str_Establecimiento & Campos.cano == _P_Int_Año & Campos.cmes == _P_Int_Mes & Campos.cproveedor == _P_Str_Proveedor
                                  select new { Campos.cidincmarcafocod, Campos.cproveedor , Campos.cgrupo, Campos.csubgrupo, Campos.cproducto, Campos.ctodos }).OrderByDescending(c => c.cidincmarcafocod);
                if (Convert.ToString(_Txt_Producto.Tag).Trim().Length > 0)
                {
                    if (_Var_Datos.Where(c => c.cproducto == Convert.ToString(_Txt_Producto.Tag).Trim()).Count() > 0)
                    {
                        Program._Dat_Tablas.TINCMARCAFOCOD.DeleteOnSubmit(Program._Dat_Tablas.TINCMARCAFOCOD.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & c.ccanal == _P_Str_Canal & c.cestable == _P_Str_Establecimiento & c.cano == _P_Int_Año & c.cmes == _P_Int_Mes & c.cproveedor == _P_Str_Proveedor & c.cgrupo == Convert.ToString(_Cmb_Linea.SelectedValue).Trim() & c.cproducto == Convert.ToString(_Txt_Producto.Tag).Trim()));
                        Program._Dat_Tablas.SubmitChanges();
                    }
                    else
                    {
                        if (Program._Dat_Tablas.TINCMARCAFOCOD.Where(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & c.ccanal == _P_Str_Canal & c.cestable == _P_Str_Establecimiento & c.cano == _P_Int_Año & c.cmes == _P_Int_Mes & c.cproveedor == _P_Str_Proveedor & c.cgrupo == Convert.ToString(_Cmb_Linea.SelectedValue).Trim() & c.csubgrupo == Convert.ToString(_Cmb_Subgrupo.SelectedValue).Trim() & c.ctodos == 'S').Count() > 0)
                        {
                            if (MessageBox.Show("Existen niveles de parámetros mayores al nivel que intenta registrar.\nSi registra este nivel se eliminarán los niveles superiores a este.\n¿Desea registrar el nivel?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Program._Dat_Tablas.TINCMARCAFOCOD.DeleteOnSubmit(Program._Dat_Tablas.TINCMARCAFOCOD.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & c.ccanal == _P_Str_Canal & c.cestable == _P_Str_Establecimiento & c.cano == _P_Int_Año & c.cmes == _P_Int_Mes & c.cproveedor == _P_Str_Proveedor & c.cgrupo == Convert.ToString(_Cmb_Linea.SelectedValue).Trim() & c.csubgrupo == Convert.ToString(_Cmb_Subgrupo.SelectedValue).Trim() & c.ctodos == 'S'));
                                Program._Dat_Tablas.SubmitChanges();
                            }
                            else
                            { return false; }
                        }
                        else if (Program._Dat_Tablas.TINCMARCAFOCOD.Where(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & c.ccanal == _P_Str_Canal & c.cestable == _P_Str_Establecimiento & c.cano == _P_Int_Año & c.cmes == _P_Int_Mes & c.cproveedor == _P_Str_Proveedor & c.cgrupo == Convert.ToString(_Cmb_Linea.SelectedValue).Trim() & c.ctodos == 'G').Count() > 0)
                        {
                            if (MessageBox.Show("Existen niveles de parámetros mayores al nivel que intenta registrar.\nSi registra este nivel se eliminarán los niveles superiores a este.\n¿Desea registrar el nivel?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Program._Dat_Tablas.TINCMARCAFOCOD.DeleteOnSubmit(Program._Dat_Tablas.TINCMARCAFOCOD.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & c.ccanal == _P_Str_Canal & c.cestable == _P_Str_Establecimiento & c.cano == _P_Int_Año & c.cmes == _P_Int_Mes & c.cproveedor == _P_Str_Proveedor & c.cgrupo == Convert.ToString(_Cmb_Linea.SelectedValue).Trim() & c.ctodos == 'G'));
                                Program._Dat_Tablas.SubmitChanges();
                            }
                            else
                            { return false; }
                        }
                        else if (Program._Dat_Tablas.TINCMARCAFOCOD.Where(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & c.ccanal == _P_Str_Canal & c.cestable == _P_Str_Establecimiento & c.cano == _P_Int_Año & c.cmes == _P_Int_Mes & c.cproveedor == _P_Str_Proveedor & c.ctodos == 'R').Count() > 0)
                        {
                            if (MessageBox.Show("Existen niveles de parámetros mayores al nivel que intenta registrar.\nSi registra este nivel se eliminarán los niveles superiores a este.\n¿Desea registrar el nivel?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Program._Dat_Tablas.TINCMARCAFOCOD.DeleteOnSubmit(Program._Dat_Tablas.TINCMARCAFOCOD.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & c.ccanal == _P_Str_Canal & c.cestable == _P_Str_Establecimiento & c.cano == _P_Int_Año & c.cmes == _P_Int_Mes & c.cproveedor == _P_Str_Proveedor & c.ctodos == 'R'));
                                Program._Dat_Tablas.SubmitChanges();
                            }
                            else
                            { return false; }
                        }
                    }
                }
                else if (_Cmb_Subgrupo.SelectedIndex > 0)
                {
                    if (_Var_Datos.Where(c => c.csubgrupo == Convert.ToString(_Cmb_Subgrupo.SelectedValue).Trim() & c.ctodos == 'S').Count() > 0)
                    {
                        Program._Dat_Tablas.TINCMARCAFOCOD.DeleteAllOnSubmit(Program._Dat_Tablas.TINCMARCAFOCOD.Where(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & c.ccanal == _P_Str_Canal & c.cestable == _P_Str_Establecimiento & c.cano == _P_Int_Año & c.cmes == _P_Int_Mes & c.cproveedor == _P_Str_Proveedor & c.cgrupo == Convert.ToString(_Cmb_Linea.SelectedValue).Trim() & c.csubgrupo == Convert.ToString(_Cmb_Subgrupo.SelectedValue).Trim()));
                        Program._Dat_Tablas.SubmitChanges();
                    }
                    else
                    {
                        if (Program._Dat_Tablas.TINCMARCAFOCOD.Where(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & c.ccanal == _P_Str_Canal & c.cestable == _P_Str_Establecimiento & c.cano == _P_Int_Año & c.cmes == _P_Int_Mes & c.cproveedor == _P_Str_Proveedor & c.cgrupo == Convert.ToString(_Cmb_Linea.SelectedValue).Trim() & c.ctodos == 'G').Count() > 0)
                        {
                            if (MessageBox.Show("Existen niveles de parámetros mayores al nivel que intenta registrar.\nSi registra este nivel se eliminarán los niveles superiores a este.\n¿Desea registrar el nivel?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Program._Dat_Tablas.TINCMARCAFOCOD.DeleteAllOnSubmit(Program._Dat_Tablas.TINCMARCAFOCOD.Where(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & c.ccanal == _P_Str_Canal & c.cestable == _P_Str_Establecimiento & c.cano == _P_Int_Año & c.cmes == _P_Int_Mes & c.cproveedor == _P_Str_Proveedor & c.cgrupo == Convert.ToString(_Cmb_Linea.SelectedValue).Trim() & c.ctodos == 'G'));
                                Program._Dat_Tablas.SubmitChanges();
                            }
                            else
                            { return false; }
                        }
                        else if (Program._Dat_Tablas.TINCMARCAFOCOD.Where(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & c.ccanal == _P_Str_Canal & c.cestable == _P_Str_Establecimiento & c.cano == _P_Int_Año & c.cmes == _P_Int_Mes & c.cproveedor == _P_Str_Proveedor & c.ctodos == 'R').Count() > 0)
                        {
                            if (MessageBox.Show("Existen niveles de parámetros mayores al nivel que intenta registrar.\nSi registra este nivel se eliminarán los niveles superiores a este.\n¿Desea registrar el nivel?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Program._Dat_Tablas.TINCMARCAFOCOD.DeleteAllOnSubmit(Program._Dat_Tablas.TINCMARCAFOCOD.Where(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & c.ccanal == _P_Str_Canal & c.cestable == _P_Str_Establecimiento & c.cano == _P_Int_Año & c.cmes == _P_Int_Mes & c.cproveedor == _P_Str_Proveedor & c.ctodos == 'R'));
                                Program._Dat_Tablas.SubmitChanges();
                            }
                            else
                            { return false; }
                        }
                        else if (_Var_Datos.Count(c => c.csubgrupo == Convert.ToString(_Cmb_Subgrupo.SelectedValue).Trim() & c.ctodos != 'S') > 0)
                        {
                            if (MessageBox.Show("Existen niveles de parámetros menores al nivel que intenta registrar.\nSi registra este nivel se eliminarán los niveles inferiores a este.\n¿Desea registrar el nivel?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Program._Dat_Tablas.TINCMARCAFOCOD.DeleteAllOnSubmit(Program._Dat_Tablas.TINCMARCAFOCOD.Where(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & c.ccanal == _P_Str_Canal & c.cestable == _P_Str_Establecimiento & c.cano == _P_Int_Año & c.cmes == _P_Int_Mes & c.cproveedor == _P_Str_Proveedor & c.cgrupo == Convert.ToString(_Cmb_Linea.SelectedValue).Trim() & c.csubgrupo == Convert.ToString(_Cmb_Subgrupo.SelectedValue).Trim()));
                                Program._Dat_Tablas.SubmitChanges();
                            }
                            else
                            { return false; }
                        }
                    }
                }
                else if (_Cmb_Linea.SelectedIndex > 0)
                {
                    if (_Var_Datos.Where(c => c.cgrupo == Convert.ToString(_Cmb_Linea.SelectedValue).Trim() & c.ctodos == 'G').Count() > 0)
                    {
                        Program._Dat_Tablas.TINCMARCAFOCOD.DeleteAllOnSubmit(Program._Dat_Tablas.TINCMARCAFOCOD.Where(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & c.ccanal == _P_Str_Canal & c.cestable == _P_Str_Establecimiento & c.cano == _P_Int_Año & c.cmes == _P_Int_Mes & c.cproveedor == _P_Str_Proveedor & c.cgrupo == Convert.ToString(_Cmb_Linea.SelectedValue).Trim()));
                        Program._Dat_Tablas.SubmitChanges();
                    }
                    else
                    {
                        if (Program._Dat_Tablas.TINCMARCAFOCOD.Where(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & c.ccanal == _P_Str_Canal & c.cestable == _P_Str_Establecimiento & c.cano == _P_Int_Año & c.cmes == _P_Int_Mes & c.cproveedor == _P_Str_Proveedor & c.ctodos == 'R').Count() > 0)
                        {
                            if (MessageBox.Show("Existen niveles de parámetros mayores al nivel que intenta registrar.\nSi registra este nivel se eliminarán los niveles superiores a este.\n¿Desea registrar el nivel?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Program._Dat_Tablas.TINCMARCAFOCOD.DeleteAllOnSubmit(Program._Dat_Tablas.TINCMARCAFOCOD.Where(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & c.ccanal == _P_Str_Canal & c.cestable == _P_Str_Establecimiento & c.cano == _P_Int_Año & c.cmes == _P_Int_Mes & c.cproveedor == _P_Str_Proveedor & c.ctodos == 'R'));
                                Program._Dat_Tablas.SubmitChanges();
                            }
                            else
                            { return false; }
                        }
                        else if (_Var_Datos.Count(c => c.cgrupo == Convert.ToString(_Cmb_Linea.SelectedValue).Trim() & c.ctodos != 'G') > 0)
                        {
                            if (MessageBox.Show("Existen niveles de parámetros menores al nivel que intenta registrar.\nSi registra este nivel se eliminarán los niveles inferiores a este.\n¿Desea registrar el nivel?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Program._Dat_Tablas.TINCMARCAFOCOD.DeleteAllOnSubmit(Program._Dat_Tablas.TINCMARCAFOCOD.Where(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & c.ccanal == _P_Str_Canal & c.cestable == _P_Str_Establecimiento & c.cano == _P_Int_Año & c.cmes == _P_Int_Mes & c.cproveedor == _P_Str_Proveedor & c.cgrupo == Convert.ToString(_Cmb_Linea.SelectedValue).Trim()));
                                Program._Dat_Tablas.SubmitChanges();
                            }
                            else
                            { return false; }
                        }
                    }
                }
                else
                {
                    if (_Var_Datos.Where(c => c.cproveedor == Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim() & c.ctodos == 'R').Count() > 0)
                    {
                        Program._Dat_Tablas.TINCMARCAFOCOD.DeleteAllOnSubmit(Program._Dat_Tablas.TINCMARCAFOCOD.Where(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & c.ccanal == _P_Str_Canal & c.cestable == _P_Str_Establecimiento & c.cano == _P_Int_Año & c.cmes == _P_Int_Mes & c.cproveedor == _P_Str_Proveedor));
                        Program._Dat_Tablas.SubmitChanges();
                    }
                    else
                    {
                        if (_Var_Datos.Where(c => c.cproveedor == Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim() & c.ctodos != 'R').Count() > 0)
                        {
                            if (MessageBox.Show("Existen niveles de parámetros menores al nivel que intenta registrar.\nSi registra este nivel se eliminarán los niveles inferiores a este.\n¿Desea registrar el nivel?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Program._Dat_Tablas.TINCMARCAFOCOD.DeleteAllOnSubmit(Program._Dat_Tablas.TINCMARCAFOCOD.Where(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & c.ccanal == _P_Str_Canal & c.cestable == _P_Str_Establecimiento & c.cano == _P_Int_Año & c.cmes == _P_Int_Mes & c.cproveedor == _P_Str_Proveedor));
                                Program._Dat_Tablas.SubmitChanges();
                            }
                            else
                            { return false; }
                        }
                    }
                }
            }
            return true;
        }
        private bool _Mtd_ExisteEnConjunto(string _P_Str_IncMarcf, string _P_Str_Canal, string _P_Str_Establecimiento, int _P_Int_Año, int _P_Int_Mes)
        {
            char _Chr_TipoTodos = _Mtd_TipoTodos();
            var _Var_Datos = from Campos in Program._Dat_Vistas.VST_INC_MARCF_PRODUCTOS
                             where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & Campos.ccanal == _P_Str_Canal & Campos.cestable == _P_Str_Establecimiento & Campos.cano == _P_Int_Año & Campos.cmes == _P_Int_Mes & Campos.ctodos == 'C'
                             select Campos;
            switch (_Chr_TipoTodos)
            {
                case 'P':
                    return _Var_Datos.Where(c => c.cproducto == Convert.ToString(_Txt_Producto.Tag).Trim()).Count() > 0;
                case 'S':
                    return _Var_Datos.Where(c => c.csubgrupo == Convert.ToString(_Cmb_Subgrupo.SelectedValue).Trim()).Count() > 0;
                case 'G':
                    return _Var_Datos.Where(c => c.cgrupo == Convert.ToString(_Cmb_Linea.SelectedValue).Trim()).Count() > 0;
                default:
                    return _Var_Datos.Where(c => c.cproveedor == Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim()).Count() > 0;
            }       
        }
        private bool _Mtd_ExisteEnConjunto(string _P_Str_IncMarcf, string _P_Str_Canal, string _P_Str_Establecimiento, int _P_Int_Año, int _P_Int_Mes, DataGridView _P_Dg_Grid)
        {
            return (from Campos in Program._Dat_Vistas.VST_INC_MARCF_PRODUCTOS
                    where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & Campos.ccanal == _P_Str_Canal & Campos.cestable == _P_Str_Establecimiento & Campos.cano == _P_Int_Año & Campos.cmes == _P_Int_Mes & Campos.ctodos == 'C' & _P_Dg_Grid.SelectedRows.Cast<DataGridViewRow>().Select(c => Convert.ToString(c.Cells["Producto"].Value).Trim()).Contains(Campos.cproducto)
                    select Campos.cproducto).Count() > 0;
        }
        private int _Mtd_LineasCargadasPorFiltro(string _P_Str_IncMarcf, string _P_Str_Canal, string _P_Str_Establecimiento, int _P_Int_Año, int _P_Int_Mes, string _P_Str_Proveedor)
        {
            return (from Campos in Program._Dat_Tablas.TINCMARCAFOCOD
                   where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & Campos.ccanal == _P_Str_Canal & Campos.cestable == _P_Str_Establecimiento & Campos.cano == _P_Int_Año & Campos.cmes == _P_Int_Mes & Campos.cproveedor == _P_Str_Proveedor
                    select Campos).Count();
        }
        private char _Mtd_TipoTodos()
        {
            if (Convert.ToString(_Txt_Producto.Tag).Trim().Length > 0)
            { return 'P'; }
            else if (_Cmb_Subgrupo.SelectedIndex > 0)
            { return 'S'; }
            else if (_Cmb_Linea.SelectedIndex > 0)
            { return 'G'; }
            else
            { return 'R'; }
        }
        private char _Mtd_TipoCargo(string _P_Str_Cargo)
        {
            var _Var_Datos = (from Campos in Program._Dat_Tablas.TCARGOSNOM
                              where Campos.cidcargonom == _P_Str_Cargo
                              select Campos);
            if (_Var_Datos.Count() > 0)
            {
                if (_Var_Datos.Single().cvendedor == 1)
                { return 'A'; }
                else
                { return 'G'; }
            }
            return 'N';//N de Nulo
        }
        private bool _Mtd_Existe(int _P_Int_GrupoInc)
        {
            return (from Campos in Program._Dat_Tablas.TINCMARCAFOCO
                    where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == _P_Int_GrupoInc
                    select Campos.cidgrupincentivar).Count() > 0;
        }
        private bool _Mtd_ExisteProducto(string _P_Str_IncMarcf, string _P_Str_Canal, string _P_Str_Establecimiento, int _P_Int_Año, int _P_Int_Mes, string _P_Str_Proveedor, string _P_Str_Linea, string _P_Str_Producto)
        {
            return (from Campos in Program._Dat_Tablas.TINCMARCAFOCOD
                    where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidincmarcafoco == Convert.ToInt32(_P_Str_IncMarcf) & Campos.ccanal == _P_Str_Canal & Campos.cestable == _P_Str_Establecimiento & Campos.cano == _P_Int_Año & Campos.cmes == _P_Int_Mes & Campos.cproveedor == _P_Str_Proveedor & Campos.cgrupo == _P_Str_Linea & Campos.cproducto == _P_Str_Producto
                    select Campos).Count() > 0;
        }
        private int _Mtd_InsertarEditarMaestra(int _P_Int_GrupoInc)
        {
            DataContext.TINCMARCAFOCO _T_TINCMARCAFOCO;
            bool _Bol_Existe = _Mtd_Existe(_P_Int_GrupoInc);
            if (_Bol_Existe)
            { _T_TINCMARCAFOCO = Program._Dat_Tablas.TINCMARCAFOCO.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidgrupincentivar == _P_Int_GrupoInc); }
            else
            {
                _Cmb_Cargo_D.Enabled = false; _Cmb_Grupo_D.Enabled = false;
                _T_TINCMARCAFOCO = new T3.DataContext.TINCMARCAFOCO();
                _T_TINCMARCAFOCO.cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp);
                _T_TINCMARCAFOCO.ccompany = Frm_Padre._Str_Comp;
                _T_TINCMARCAFOCO.cidincmarcafoco = new _Cls_Consecutivos()._Mtd_IncMar();
                _T_TINCMARCAFOCO.cidgrupincentivar = _P_Int_GrupoInc;
            }
            _T_TINCMARCAFOCO.casesorgerente = _Mtd_TipoCargo(Convert.ToString(_Cmb_Cargo_D.SelectedValue));
            _T_TINCMARCAFOCO.ccomisiontotal = Convert.ToDecimal(_Txt_ccomisiontotal.Text);
            _T_TINCMARCAFOCO.cporcvolventas = _Num_PorcVolumentVtasMin.Value;
            if (_Bol_Existe)
            {
                _T_TINCMARCAFOCO.cdateupd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _T_TINCMARCAFOCO.cuserupd = Frm_Padre._Str_Use;
            }
            else
            {
                _T_TINCMARCAFOCO.cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _T_TINCMARCAFOCO.cuseradd = Frm_Padre._Str_Use;
                Program._Dat_Tablas.TINCMARCAFOCO.InsertOnSubmit(_T_TINCMARCAFOCO);
            }
            Program._Dat_Tablas.SubmitChanges();
            _Txt_cidincmarcafoco.Text = _T_TINCMARCAFOCO.cidincmarcafoco.ToString();
            return _T_TINCMARCAFOCO.cidincmarcafoco;
        }
        private void _Mtd_InsertarRegistros(int _P_Int_GrupoInc)
        {
            int _P_Int_IncMarcf = _Mtd_InsertarEditarMaestra(_P_Int_GrupoInc);
            //------------------------------------
            DataContext.TINCMARCAFOCOD _T_TINCMARCAFOCOD = new T3.DataContext.TINCMARCAFOCOD()
            {
                cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp),
                ccompany = Frm_Padre._Str_Comp,
                cidincmarcafoco = _P_Int_IncMarcf,
                cidincmarcafocod = new _Cls_Consecutivos()._Mtd_IncMarDetalle(_P_Int_IncMarcf),
                cano = Convert.ToInt32(_Cmb_Ano.Text),
                cmes = Convert.ToInt32(_Cmb_Mes.Text),
                ccanal = Convert.ToString(_Cmb_Canal.SelectedValue).Trim(),
                cestable = Convert.ToString(_Cmb_Establecimiento.SelectedValue).Trim(),
                cproveedor = Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim(),
                cgrupo = Convert.ToString(_Cmb_Linea.SelectedValue).Trim()
            };
            if (_Cmb_Subgrupo.SelectedIndex > 0)
            { _T_TINCMARCAFOCOD.csubgrupo = Convert.ToString(_Cmb_Subgrupo.SelectedValue).Trim(); }
            if (Convert.ToString(_Txt_Producto.Tag).Trim().Length > 0)
            { _T_TINCMARCAFOCOD.cproducto = Convert.ToString(_Txt_Producto.Tag).Trim(); }
            _T_TINCMARCAFOCOD.ctodos = _Mtd_TipoTodos();
            _T_TINCMARCAFOCOD.cporcactivamin = _Num_cporcactivamin.Value;
            _T_TINCMARCAFOCOD.cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _T_TINCMARCAFOCOD.cuseradd = Frm_Padre._Str_Use;
            //------------------------------------
            Program._Dat_Tablas.TINCMARCAFOCOD.InsertOnSubmit(_T_TINCMARCAFOCOD);
            //------------------------------------
            Program._Dat_Tablas.SubmitChanges();
        }
        private void _Mtd_InsertarRegistros(int _P_Int_GrupoInc, DataGridView _P_Dg_Grid)
        {
            int _P_Int_IncMarcf = _Mtd_InsertarEditarMaestra(_P_Int_GrupoInc);
            //------------------------------------
            foreach (DataGridViewRow _Dg_Row in _P_Dg_Grid.SelectedRows)
            {
                if (_Mtd_ExisteProducto(Convert.ToString(_P_Int_IncMarcf), Convert.ToString(_Cmb_Canal.SelectedValue).Trim(), Convert.ToString(_Cmb_Establecimiento.SelectedValue).Trim(), Convert.ToInt32(_Cmb_Ano.Text), Convert.ToInt32(_Cmb_Mes.Text), Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim(), Convert.ToString(_Cmb_Linea.SelectedValue).Trim(), Convert.ToString(_Dg_Row.Cells[0].Value).Trim()))
                {
                    Program._Dat_Tablas.TINCMARCAFOCOD.DeleteOnSubmit(Program._Dat_Tablas.TINCMARCAFOCOD.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincmarcafoco == _P_Int_IncMarcf & c.ccanal == Convert.ToString(_Cmb_Canal.SelectedValue).Trim() & c.cestable == Convert.ToString(_Cmb_Establecimiento.SelectedValue).Trim() & c.cano == Convert.ToInt32(_Cmb_Ano.Text) & c.cmes == Convert.ToInt32(_Cmb_Mes.Text) & c.cproveedor == Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim() & c.cgrupo == Convert.ToString(_Cmb_Linea.SelectedValue).Trim() & c.cproducto == Convert.ToString(_Dg_Row.Cells[0].Value).Trim()));
                    Program._Dat_Tablas.SubmitChanges();
                }
                //------------------------------------
                DataContext.TINCMARCAFOCOD _T_TINCMARCAFOCOD = new T3.DataContext.TINCMARCAFOCOD()
                {
                    cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp),
                    ccompany = Frm_Padre._Str_Comp,
                    cidincmarcafoco = _P_Int_IncMarcf,
                    cidincmarcafocod = new _Cls_Consecutivos()._Mtd_IncMarDetalle(_P_Int_IncMarcf),
                    cano = Convert.ToInt32(_Cmb_Ano.Text),
                    cmes = Convert.ToInt32(_Cmb_Mes.Text),
                    ccanal = Convert.ToString(_Cmb_Canal.SelectedValue).Trim(),
                    cestable = Convert.ToString(_Cmb_Establecimiento.SelectedValue).Trim(),
                    cproveedor = Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim(),
                    cgrupo = Convert.ToString(_Cmb_Linea.SelectedValue).Trim()
                };
                if (_Cmb_Subgrupo.SelectedIndex > 0)
                { _T_TINCMARCAFOCOD.csubgrupo = Convert.ToString(_Cmb_Subgrupo.SelectedValue).Trim(); }
                if (Convert.ToString(_Txt_Producto.Tag).Trim().Length > 0)
                { _T_TINCMARCAFOCOD.cproducto = Convert.ToString(_Dg_Row.Cells[0].Value).Trim(); }
                _T_TINCMARCAFOCOD.ctodos = 'P';
                _T_TINCMARCAFOCOD.cporcactivamin = _Num_cporcactivamin.Value;
                _T_TINCMARCAFOCOD.cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _T_TINCMARCAFOCOD.cuseradd = Frm_Padre._Str_Use;
                //------------------------------------
                Program._Dat_Tablas.TINCMARCAFOCOD.InsertOnSubmit(_T_TINCMARCAFOCOD);
                Program._Dat_Tablas.SubmitChanges();
            }
        }
        private void _Mtd_InsertarRegistros(int _P_Int_GrupoInc, int _P_Int_Conjunto, string _P_Str_DesConjunto, decimal _P_Dec_PorcAct, DataGridView _P_Dg_Grid)
        {
            int _P_Int_IncMarcf = _Mtd_InsertarEditarMaestra(_P_Int_GrupoInc);
            //------------------------------------
            DataContext.TINCMARCAFOCOD _T_TINCMARCAFOCOD;
            //------------------------------------
            if (Program._Dat_Tablas.TINCMARCAFOCOD.Where(c => c.cconjunto == _P_Int_Conjunto).Count() > 0)
            {
                _T_TINCMARCAFOCOD = Program._Dat_Tablas.TINCMARCAFOCOD.Single(c => c.cconjunto == _P_Int_Conjunto);
                _T_TINCMARCAFOCOD.cconjuntodesc = _P_Str_DesConjunto;
                _T_TINCMARCAFOCOD.cporcactivamin = _P_Dec_PorcAct;
                _T_TINCMARCAFOCOD.cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _T_TINCMARCAFOCOD.cuseradd = Frm_Padre._Str_Use;
                Program._Dat_Tablas.TINCMARCAFOCODD.DeleteAllOnSubmit(Program._Dat_Tablas.TINCMARCAFOCODD.Where(c => c.cconjunto == _P_Int_Conjunto));
            }
            else
            {
                _T_TINCMARCAFOCOD = new T3.DataContext.TINCMARCAFOCOD()
                {
                    cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp),
                    ccompany = Frm_Padre._Str_Comp,
                    cidincmarcafoco = _P_Int_IncMarcf,
                    cidincmarcafocod = new _Cls_Consecutivos()._Mtd_IncMarDetalle(_P_Int_IncMarcf),
                    cano = Convert.ToInt32(_Cmb_Ano.Text),
                    cmes = Convert.ToInt32(_Cmb_Mes.Text),
                    ccanal = Convert.ToString(_Cmb_Canal.SelectedValue).Trim(),
                    cestable = Convert.ToString(_Cmb_Establecimiento.SelectedValue).Trim(),
                    cconjunto = _P_Int_Conjunto,
                    ctodos = 'C',
                    cconjuntodesc = _P_Str_DesConjunto,
                    cporcactivamin = _P_Dec_PorcAct,
                    cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ(),
                    cuseradd = Frm_Padre._Str_Use
                };
                Program._Dat_Tablas.TINCMARCAFOCOD.InsertOnSubmit(_T_TINCMARCAFOCOD);
            }
            //------------------------------------
            Program._Dat_Tablas.SubmitChanges();
            //------------------------------------
            foreach (DataGridViewRow _Dg_Row in _P_Dg_Grid.Rows)
            {
                DataContext.TINCMARCAFOCODD _T_TINCMARCAFOCODD = new T3.DataContext.TINCMARCAFOCODD()
                {
                    cconjunto = _P_Int_Conjunto,
                    cproducto = Convert.ToString(_Dg_Row.Cells["Producto"].Value).Trim()
                };
                //------------------------------------
                Program._Dat_Tablas.TINCMARCAFOCODD.InsertOnSubmit(_T_TINCMARCAFOCODD);
                Program._Dat_Tablas.SubmitChanges();
            }
            //------------------------------------
        }
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            if (_Cmb_Cargo_D.SelectedIndex > 0 & _Cmb_Grupo_D.SelectedIndex > 0 & _Mtd_Validar_GrpB_Negociacion())
            {
                if (_Num_PorcVolumentVtasMin.Enabled && _Num_PorcVolumentVtasMin.Value == 0)
                {
                    _Er_Error.SetError(_Num_PorcVolumentVtasMin, "Información requerida!!!");
                }
                else
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_InsertarEditarMaestra(Convert.ToInt32(_Cmb_Grupo_D.SelectedValue));
                    Cursor = Cursors.Default;
                    MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor = Cursors.WaitCursor;
                    _Mtd_Actualizar();
                    Cursor = Cursors.Default;
                    if (_Mtd_TipoCargo(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 'G')
                    { _Tb_Tab.SelectedIndex = 0; }
                }
            }
            else
            {
                if (_Cmb_Cargo_D.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Cargo_D, "Información requerida!!!"); }
                if (_Cmb_Grupo_D.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Grupo_D, "Información requerida!!!"); }
            }
            return false;
        }
        private void _Mtd_Guardar(bool _P_Bol_GuadarContinuar)
        {
            _Er_Error.Dispose();
            if (_Num_cporcactivamin.Value > 0)
            {
                bool _Bol_CompletarOperacion = _Mtd_ValidarGuardar(_Txt_cidincmarcafoco.Text.Trim(), Convert.ToString(_Cmb_Canal.SelectedValue).Trim(), Convert.ToString(_Cmb_Establecimiento.SelectedValue).Trim(), Convert.ToInt32(_Cmb_Ano.Text), Convert.ToInt32(_Cmb_Mes.Text), Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim());
                if (_Bol_CompletarOperacion)
                {
                    if (_Mtd_ExisteEnConjunto(_Txt_cidincmarcafoco.Text.Trim(), Convert.ToString(_Cmb_Canal.SelectedValue).Trim(), Convert.ToString(_Cmb_Establecimiento.SelectedValue).Trim(), Convert.ToInt32(_Cmb_Ano.Text), Convert.ToInt32(_Cmb_Mes.Text)))
                    { MessageBox.Show("El nivel o item que intenta registrar se encuentra relacionado con uno o más conjuntos.\nPara realizar la operación debe eliminar dicha relación editando o eliminando estos conjuntos.", "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else
                    {
                        Cursor = Cursors.WaitCursor;
                        _Mtd_InsertarRegistros(Convert.ToInt32(_Cmb_Grupo_D.SelectedValue));
                        _Mtd_Actualizar();
                        _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_cidincmarcafoco.Text));
                        if (_P_Bol_GuadarContinuar)
                        {
                            int _Int_LineasCargadasPorFiltro = _Mtd_LineasCargadasPorFiltro(_Txt_cidincmarcafoco.Text.Trim(), Convert.ToString(_Cmb_Canal.SelectedValue).Trim(), Convert.ToString(_Cmb_Establecimiento.SelectedValue).Trim(), Convert.ToInt32(_Cmb_Ano.Text), Convert.ToInt32(_Cmb_Mes.Text), Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim());
                            if (_Int_LineasCargadasPorFiltro < _Cmb_Linea.Items.Count - 1)
                            { Cursor = Cursors.WaitCursor; _Mtd_Cargar_Linea(Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim()); Cursor = Cursors.Default; _Cmb_Linea.Focus(); }
                            else
                            { Cursor = Cursors.WaitCursor; _Mtd_Cargar_Proveedor(Convert.ToString(_Cmb_Grupo_D.SelectedValue).Trim()); Cursor = Cursors.Default; _Cmb_Proveedor.Focus(); }
                        }
                        else
                        { _Bt_Cancelar.PerformClick(); }
                        Cursor = Cursors.Default;
                    }
                }
            }
            else
            {
                _Er_Error.SetError(_Num_cporcactivamin, "Información requerida!!!");
            }
        }
        public bool _Mtd_Guardar_(DataGridView _P_Dg_Grid)
        {
            bool _Bol_CompletarOperacion = _Mtd_ValidarGuardar(_Txt_cidincmarcafoco.Text.Trim(), Convert.ToString(_Cmb_Canal.SelectedValue).Trim(), Convert.ToString(_Cmb_Establecimiento.SelectedValue).Trim(), Convert.ToInt32(_Cmb_Ano.Text), Convert.ToInt32(_Cmb_Mes.Text), Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim());
            if (_Bol_CompletarOperacion)
            {
                if (_Mtd_ExisteEnConjunto(_Txt_cidincmarcafoco.Text.Trim(), Convert.ToString(_Cmb_Canal.SelectedValue).Trim(), Convert.ToString(_Cmb_Establecimiento.SelectedValue).Trim(), Convert.ToInt32(_Cmb_Ano.Text), Convert.ToInt32(_Cmb_Mes.Text), _P_Dg_Grid))
                { MessageBox.Show("Uno o mas productos se encuentra relacionados con conjuntos.\nPara realizar la operación debe eliminar dicha relación editando o eliminando estos conjuntos.", "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
                else
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_InsertarRegistros(Convert.ToInt32(_Cmb_Grupo_D.SelectedValue), _P_Dg_Grid);
                    _Mtd_Actualizar();
                    _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_cidincmarcafoco.Text));
                    _Bt_Cancelar.PerformClick();
                    Cursor = Cursors.Default;
                }
            }
            return true;
        }
        public void _Mtd_Guardar_(int _P_Int_Conjunto, string _P_Str_DesConjunto, decimal _P_Dec_PorcAct, DataGridView _P_Dg_Grid)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_InsertarRegistros(Convert.ToInt32(_Cmb_Grupo_D.SelectedValue), _P_Int_Conjunto, _P_Str_DesConjunto, _P_Dec_PorcAct, _P_Dg_Grid);
            _Mtd_Actualizar();
            _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_cidincmarcafoco.Text));
            _Bt_Cancelar.PerformClick();
            Cursor = Cursors.Default;
        }
        public bool _Mtd_Editar()
        {
            return _Mtd_Guardar();
        }
        private void _Mtd_EliminarRegistros()
        {
            var _Var_Datos = from Campos in _Dg_Grid.Rows.Cast<DataGridViewRow>()
                             where Campos.Selected
                             select Campos;
            foreach (DataGridViewRow _DgRow in _Var_Datos)
            {
                var _Var_cidincmarcafoco = (from Campos in Program._Dat_Tablas.TINCMARCAFOCO
                                           where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == Convert.ToInt32(_DgRow.Cells["Grupo_Incentivo"].Value)
                                            select Campos.cidincmarcafoco).Single();
                //--------------------------------------------------------------------
                var _Var_Conjuntos = from Campos in Program._Dat_Tablas.TINCMARCAFOCOD
                                             where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidincmarcafoco == _Var_cidincmarcafoco & Campos.cconjunto > 0
                                             select Campos.cconjunto;
                //--------------------------------------------------------------------
                var _Var_TINCMARCAFOCODD = from Campos in Program._Dat_Tablas.TINCMARCAFOCODD.AsEnumerable() where _Var_Conjuntos.Contains(Campos.cconjunto) select Campos;
                if (_Var_TINCMARCAFOCODD.Count() > 0) { Program._Dat_Tablas.TINCMARCAFOCODD.DeleteAllOnSubmit(_Var_TINCMARCAFOCODD); }
                //--------------------------------------------------------------------
                var _Var_TINCMARCAFOCOD = from Campos in Program._Dat_Tablas.TINCMARCAFOCOD where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidincmarcafoco == _Var_cidincmarcafoco select Campos;
                if (_Var_TINCMARCAFOCOD.Count() > 0) { Program._Dat_Tablas.TINCMARCAFOCOD.DeleteAllOnSubmit(_Var_TINCMARCAFOCOD); }
                //--------------------------------------------------------------------
                Program._Dat_Tablas.TINCMARCAFOCO.DeleteOnSubmit(Program._Dat_Tablas.TINCMARCAFOCO.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidgrupincentivar == Convert.ToInt32(_DgRow.Cells["Grupo_Incentivo"].Value)));
            }
            Program._Dat_Tablas.SubmitChanges();
        }
        private void _Mtd_EliminarRegistros(int _P_Str_IncMarcf)
        {
            var _Var_Datos = from Campos in _Dg_Detalle.Rows.Cast<DataGridViewRow>()
                             where Campos.Selected
                             select Campos;
            foreach (DataGridViewRow _DgRow in _Var_Datos)
            {
                //--------------------------------------------------------------------
                var _Var_Conjuntos = from Campos in Program._Dat_Tablas.TINCMARCAFOCOD
                                     where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidincmarcafoco == _P_Str_IncMarcf & Campos.cidincmarcafocod == Convert.ToInt32(_DgRow.Cells["cidincmarcafocod"].Value) & Campos.cconjunto > 0
                                     select Campos.cconjunto;
                //--------------------------------------------------------------------
                var _Var_TINCMARCAFOCODD = from Campos in Program._Dat_Tablas.TINCMARCAFOCODD.AsEnumerable() where _Var_Conjuntos.Contains(Campos.cconjunto) select Campos;
                if (_Var_TINCMARCAFOCODD.Count() > 0) { Program._Dat_Tablas.TINCMARCAFOCODD.DeleteAllOnSubmit(_Var_TINCMARCAFOCODD); }
                //--------------------------------------------------------------------
                Program._Dat_Tablas.TINCMARCAFOCOD.DeleteOnSubmit(Program._Dat_Tablas.TINCMARCAFOCOD.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincmarcafoco == _P_Str_IncMarcf & c.cidincmarcafocod == Convert.ToInt32(_DgRow.Cells["cidincmarcafocod"].Value)));
            }
            Program._Dat_Tablas.SubmitChanges();
        }
        private void _Mtd_CargarFormulario(int _P_Int_GrupoInc, string _P_Str_Cargo)
        {
            var _Var_Datos = (from Campos in Program._Dat_Tablas.TINCMARCAFOCO
                              where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == _P_Int_GrupoInc
                              select Campos).Single();
            _Txt_cidincmarcafoco.Text = _Var_Datos.cidincmarcafoco.ToString();
            _Cmb_Cargo_D.SelectedIndexChanged -= new EventHandler(_Cmb_Cargo_D_SelectedIndexChanged);
            _Cmb_Cargo_D.SelectedValue = _P_Str_Cargo;
            _Cmb_Cargo_D.SelectedIndexChanged += new EventHandler(_Cmb_Cargo_D_SelectedIndexChanged);
            _Mtd_CargarGrupos(_Cmb_Grupo_D, _Cmb_Cargo_D, true);
            _Cmb_Grupo_D.SelectedValue = _P_Int_GrupoInc.ToString();
            _Txt_ccomisiontotal.Text = _Var_Datos.ccomisiontotal.ToString();
            _Num_PorcVolumentVtasMin.Value = Convert.ToDecimal(_Var_Datos.cporcvolventas);
            //_Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_cidincmarcafoco.Text));
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
        private int _Mtd_RetornarConjunto(int _P_Str_IncMarcf, int _P_Str_IncMarcf_D)
        {
            var _Var_Datos = (from Campos in Program._Dat_Tablas.TINCMARCAFOCOD
                              where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidincmarcafoco == _P_Str_IncMarcf & Campos.cidincmarcafocod == _P_Str_IncMarcf_D
                              select Campos.cconjunto).Single();
            if (_Var_Datos.ToString().Trim().Length == 0)
            { return 0; }
            return (int)_Var_Datos;
        }
        private void Frm_IncMarcaFoco_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
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

        private void Frm_IncMarcaFoco_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_MARCF");
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = (!_Pnl_Detalle_1.Enabled & !_GrpB_Negociacion.Enabled & !_Pnl_Detalle_3.Visible) & _Mtd_VerifContTextBoxNumeric(_Txt_ccomisiontotal) & _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_MARCF");
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _Tb_Tab.SelectedIndex == 1 & !((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled & _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_MARCF");
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
        }

        private void Frm_IncMarcaFoco_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                e.Cancel = !_Pnl_Detalle_1.Enabled;
            }
            else
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                _Mtd_Ini();
            }
        }

        private void _Cmb_Cargo_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarCargos(_Cmb_Cargo);
            Cursor = Cursors.Default;
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
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
            { Cursor = Cursors.WaitCursor; _Mtd_HabilitarPorVentasMin(Convert.ToString(_Cmb_Cargo_D.SelectedValue).Trim()); _Mtd_CargarGrupos(_Cmb_Grupo_D, _Cmb_Cargo_D, false); Cursor = Cursors.Default; _Cmb_Grupo_D.Enabled = true; }
            else
            { _Cmb_Grupo_D.SelectedIndex = -1; _Cmb_Grupo_D.DataSource = null; _Cmb_Grupo_D.Enabled = false; }
        }
        private void _Mtd_HabilitarPorVentasMin(string _P_Str_Cargo)
        {
            if ((from Campos in Program._Dat_Tablas.TCARGOSNOM
                 where Campos.cidcargonom == _P_Str_Cargo & Campos.cvendedor == 1
                 select Campos.cidcargonom).Count() > 0)
            {
                _Lbl_PorcVolumentVtasMin.Enabled = true;
                _Num_PorcVolumentVtasMin.Enabled = true;
            }
            else
            {
                _Lbl_PorcVolumentVtasMin.Enabled = false;
                _Num_PorcVolumentVtasMin.Enabled = false;
                _Num_PorcVolumentVtasMin.Value = 0;
            }
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
            _Mtd_IniGrpB_Negociacion();
            _Mtd_Habilitar_GrpB_Negociacion(false);
            _GrpB_Negociacion.Enabled = _Cmb_Grupo_D.SelectedIndex > 0;
            _Pnl_Detalle_2.Enabled = _Cmb_Grupo_D.SelectedIndex > 0 & _Mtd_TipoCargo(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 'A';
            _Mtd_CargarCanal();
            _Mtd_CargarAños();
            if (_Cmb_Grupo_D.SelectedIndex > 0)
            {
                _Mtd_Habilitar_GrpB_Negociacion(_Pnl_Detalle_1.Enabled);
                _Mtd_Validar_GrpB_Negociacion(); 
            }
        }

        private void _Bt_Editcion_1_Click(object sender, EventArgs e)
        {
            _Mtd_Habilitar_GrpB_Negociacion(!_Txt_ccomisiontotal.Enabled);
        }

        private void _Cmb_Canal_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarCanal();
            Cursor = Cursors.Default;
        }

        private void _Cmb_Canal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Canal.SelectedIndex > 0)
            { Cursor = Cursors.WaitCursor; _Mtd_CargarEstablecimiento(_Cmb_Canal); Cursor = Cursors.Default; _Cmb_Establecimiento.Enabled = true; }
            else
            { _Cmb_Establecimiento.SelectedIndex = -1; _Cmb_Establecimiento.DataSource = null; _Cmb_Establecimiento.Enabled = false; }
            _Bt_Agregar.Enabled = _Bol_UsuarioLider & _Cmb_Canal.SelectedIndex > 0 & _Cmb_Establecimiento.SelectedIndex > 0 & _Cmb_Ano.SelectedIndex > 0 & _Cmb_Mes.SelectedIndex > 0 & ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled;
        }

        private void _Cmb_Establecimiento_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarEstablecimiento(_Cmb_Canal);
            Cursor = Cursors.Default;
        }
        private void _Cmb_Establecimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Bt_Agregar.Enabled = _Bol_UsuarioLider & _Cmb_Canal.SelectedIndex > 0 & _Cmb_Establecimiento.SelectedIndex > 0 & _Cmb_Ano.SelectedIndex > 0 & _Cmb_Mes.SelectedIndex > 0 & ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled;
            _Mtd_IniGrid_Detalle();
        }

        private void _Cmb_Ano_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarAños();
            Cursor = Cursors.Default;
        }

        private void _Cmb_Ano_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Ano.SelectedIndex > 0)
            { Cursor = Cursors.WaitCursor; _Mtd_CargarMeses(Convert.ToInt32(_Cmb_Ano.Text)); Cursor = Cursors.Default; _Cmb_Mes.Enabled = true; }
            else
            { _Cmb_Mes.Items.Clear(); _Cmb_Mes.Enabled = false; }
            _Bt_Agregar.Enabled = _Bol_UsuarioLider & _Cmb_Canal.SelectedIndex > 0 & _Cmb_Establecimiento.SelectedIndex > 0 & _Cmb_Ano.SelectedIndex > 0 & _Cmb_Mes.SelectedIndex > 0 & ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled;
            _Mtd_IniGrid_Detalle();
        }

        private void _Cmb_Mes_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarMeses(Convert.ToInt32(_Cmb_Ano.Text));
            Cursor = Cursors.Default;
        }

        private void _Cmb_Mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Mes.SelectedIndex == 0)
            { _Mtd_IniGrid_Detalle(); }
            _Bt_Agregar.Enabled = _Bol_UsuarioLider & _Cmb_Canal.SelectedIndex > 0 & _Cmb_Establecimiento.SelectedIndex > 0 & _Cmb_Ano.SelectedIndex > 0 & _Cmb_Mes.SelectedIndex > 0 & ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled;
        }
        private void Frm_IncMarcaFoco_Shown(object sender, EventArgs e)
        {
            if (!_Bol_PermisoConfirmado)
            { MessageBox.Show("Su usuario no tiene permisos para entrar en este módulo", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close(); }
            else
            { _Cmb_Cargo.Focus(); }
        }

        private void _Bt_Filtrar_Click(object sender, EventArgs e)
        {
            if (_Txt_cidincmarcafoco.Text.Trim().Length > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_cidincmarcafoco.Text));
                Cursor = Cursors.Default;
            }
            else
            { MessageBox.Show("Aún no existen registros", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Bt_Agregar_Click(object sender, EventArgs e)
        {
            if (_Txt_cidincmarcafoco.Text.Trim().Length > 0)
            {
                _Pnl_Detalle_1.Enabled = false;
                _GrpB_Negociacion.Enabled = false;
                _Pnl_Detalle_2.Enabled = false;
                _Mtd_IniPnl_Detalle_3();
                _Mtd_Deshabilitar_Pnl_Detalle_3();
                _Pnl_Detalle_3.Visible = true;
                _Num_cporcactivamin.Enabled = true;
                _Mtd_Cargar_Proveedor(Convert.ToString(_Cmb_Grupo_D.SelectedValue).Trim());
                _Cmb_Proveedor.Enabled = true;
                _Cmb_Proveedor.Focus();
                Cursor = Cursors.WaitCursor;
                _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_cidincmarcafoco.Text));
                Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Debe guardar las condiciones antes de cargar el detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Txt_ccomisiontotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_ccomisiontotal, e, 15, 2);
        }

        private void _Txt_ccomisiontotal_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_ccomisiontotal.Text)) { _Txt_ccomisiontotal.Text = ""; }
            _Cmb_Canal.Enabled = _Mtd_Validar_GrpB_Negociacion() & _Mtd_TipoCargo(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 'A';
            if (!_Cmb_Canal.Enabled) { _Cmb_Establecimiento.Enabled = false; }
            else if (_Cmb_Canal.SelectedIndex > 0)
            { _Cmb_Establecimiento.Enabled = true; }
            _Cmb_Ano.Enabled = _Cmb_Canal.Enabled;
            if (!_Cmb_Ano.Enabled) { _Cmb_Mes.Enabled = false; }
            else if (_Cmb_Ano.SelectedIndex > 0)
            { _Cmb_Mes.Enabled = true; }
        }

        private void _Cmb_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Proveedor.SelectedIndex > 0)
            { 
                Cursor = Cursors.WaitCursor; _Mtd_Cargar_Linea(Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim()); Cursor = Cursors.Default; _Cmb_Linea.Enabled = true;
                _Num_cporcactivamin.Value = 0; _Num_cporcactivamin.Enabled = true;
                _Bt_Guardar.Enabled = true; _Bt_Guardar_Continuar.Enabled = true;
            }
            else
            {
                _Cmb_Linea.DataSource = null; _Cmb_Linea.Enabled = false;
                _Num_cporcactivamin.Value = 0; _Num_cporcactivamin.Enabled = false;
                _Bt_Guardar.Enabled = false; _Bt_Guardar_Continuar.Enabled = false;
            }
        }

        private void _Cmb_Proveedor_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Cargar_Proveedor(Convert.ToString(_Cmb_Grupo_D.SelectedValue).Trim());
            Cursor = Cursors.Default;
        }

        private void _Cmb_Linea_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Cargar_Linea(Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim());
            Cursor = Cursors.Default;
        }

        private void _Cmb_Linea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Linea.SelectedIndex > 0)
            {
                Cursor = Cursors.WaitCursor; _Mtd_Cargar_Subgrupo(Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim(), Convert.ToString(_Cmb_Linea.SelectedValue).Trim()); Cursor = Cursors.Default; _Cmb_Subgrupo.Enabled = true;
                _Txt_Producto.Tag = ""; _Txt_Producto.Text = ""; _Txt_Producto.Enabled = true; _Bt_Buscar.Enabled = true;
            }
            else
            {
                _Cmb_Subgrupo.DataSource = null; _Cmb_Subgrupo.Enabled = false;
                _Txt_Producto.Tag = ""; _Txt_Producto.Text = ""; _Txt_Producto.Enabled = false; _Bt_Buscar.Enabled = false;
            }
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Num_cporcactivamin.Value > 0)
            {
                string _Str_Proveedor = "";
                string _Str_Grupo = "";
                string _Str_Subgrupo = "";
                string _Str_Marca = "";
                if (_Cmb_Proveedor.SelectedIndex > 0)
                { _Str_Proveedor = Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim(); }
                if (_Cmb_Linea.SelectedIndex > 0)
                { _Str_Grupo = Convert.ToString(_Cmb_Linea.SelectedValue).Trim(); }
                if (_Cmb_Subgrupo.SelectedIndex > 0)
                { _Str_Subgrupo = Convert.ToString(_Cmb_Subgrupo.SelectedValue).Trim(); }
                TextBox _Txt_TemporalCod = new TextBox();
                Cursor = Cursors.WaitCursor;
                Frm_BusquedaAvanzada2 _Frm = new Frm_BusquedaAvanzada2(this, _Txt_TemporalCod, _Txt_Producto, "", _Str_Proveedor, _Str_Grupo, _Str_Subgrupo, _Str_Marca);
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
                if (_Txt_TemporalCod.Text.Trim().Length > 0)
                {
                    _Txt_Producto.Tag = _Txt_TemporalCod.Text.Trim();
                    _Mtd_SelecSubGrupo(_Txt_TemporalCod.Text.Trim());
                }
                else
                { _Txt_Producto.Tag = ""; }
            }
            else
            {
                _Er_Error.SetError(_Num_cporcactivamin, "Información requerida!!!");
            }
        }

        private void _Cmb_Subgrupo_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor; _Mtd_Cargar_Subgrupo(Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim(), Convert.ToString(_Cmb_Linea.SelectedValue).Trim()); Cursor = Cursors.Default;
        }

        private void _Cmb_Subgrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Txt_Producto.Tag = ""; _Txt_Producto.Text = "";
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Mtd_IniPnl_Detalle_3();
            _Mtd_Deshabilitar_Pnl_Detalle_3();
            _Pnl_Detalle_3.Visible = false;
            _GrpB_Negociacion.Enabled = true;
            _Pnl_Detalle_2.Enabled = true;
            _Pnl_Detalle_1.Enabled = _Txt_cidincmarcafoco.Text.Trim().Length == 0;
            _Bt_Agregar.Focus();
        }
        private void _Bt_Guardar_Click(object sender, EventArgs e)
        {
            _Mtd_Guardar(false);
        }

        private void _Bt_Guardar_Continuar_Click(object sender, EventArgs e)
        {
            _Mtd_Guardar(true);
        }

        private void _Dg_Detalle_DataSourceChanged(object sender, EventArgs e)
        {
            _Bt_Eliminar.Enabled = _Dg_Detalle.RowCount > 0 & _Bol_UsuarioLider & ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled;
        }

        private void _Bt_Eliminar_Click(object sender, EventArgs e)
        {
            if (_Dg_Detalle.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Esta seguro de elimiar los registros seleccionados?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_EliminarRegistros(Convert.ToInt32(_Txt_cidincmarcafoco.Text));
                    _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_cidincmarcafoco.Text));
                    Cursor = Cursors.Default;
                }
            }
            else
            { MessageBox.Show("Debe seleccionar los registros que desea eliminar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count == 1)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_IniPnl_Detalle_1();
                _Mtd_CargarFormulario(Convert.ToInt32(_Dg_Grid.Rows[e.RowIndex].Cells["Grupo_Incentivo"].Value), Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["cidcargonom"].Value));
                _Pnl_Detalle_1.Enabled = false;
                _GrpB_Negociacion.Enabled = false;
                _Pnl_Detalle_2.Enabled = false;
                _Pnl_Detalle_3.Visible = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_MARCF");
                _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                _Tb_Tab.SelectedIndex = 1;
                _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                Cursor = Cursors.Default;
                _Pnl_Detalle_2.Enabled = _Mtd_TipoCargo(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 'A';
                _Mtd_CargarCanal();
                _Cmb_Canal.Enabled = _Mtd_TipoCargo(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 'A';
                _Mtd_CargarAños();
                _Cmb_Ano.Enabled = _Cmb_Canal.Enabled;
                _Dg_Detalle.DataSourceChanged -= new EventHandler(_Dg_Detalle_DataSourceChanged);
                Cursor = Cursors.WaitCursor;
                _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_cidincmarcafoco.Text));
                Cursor = Cursors.Default;
                _Dg_Detalle.DataSourceChanged += new EventHandler(_Dg_Detalle_DataSourceChanged);
            }
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _Dg_Grid.SelectedRows.Count == 0 | !(_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_MARCF"));
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

        private void _Bt_Copiar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_IncCopiar _Frm = new Frm_IncCopiar(0);
            Cursor = Cursors.Default;
            if (_Frm.ShowDialog() == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Actualizar();
                Cursor = Cursors.Default;
            }
        }

        private void _Bt_Crear_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_IncConjunto _Frm = new Frm_IncConjunto(this, Convert.ToString(_Cmb_Grupo_D.SelectedValue).Trim(), 0, "", _Txt_cidincmarcafoco.Text.Trim(), Convert.ToString(_Cmb_Canal.SelectedValue).Trim(), Convert.ToString(_Cmb_Establecimiento.SelectedValue).Trim(), Convert.ToInt32(_Cmb_Ano.Text), Convert.ToInt32(_Cmb_Mes.Text));
            Cursor = Cursors.Default;
            if (_Frm.ShowDialog(this) == DialogResult.Yes)
            {
                MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Cntx_Conjunto_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Detalle.SelectedRows.Count == 1)
            {
                if (((Frm_Padre)Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_guardar2.Enabled & _Cmb_Canal.SelectedIndex > 0 & _Cmb_Establecimiento.SelectedIndex > 0 & _Cmb_Ano.SelectedIndex > 0 & _Cmb_Mes.SelectedIndex > 0)
                {
                    e.Cancel = !(_Mtd_RetornarConjunto(Convert.ToInt32(_Txt_cidincmarcafoco.Text), Convert.ToInt32(_Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["cidincmarcafocod"].Value)) > 0);
                }
                else
                { e.Cancel = true; }
            }
            else
            { e.Cancel = true; }
        }

        private void _Tol_Editar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_IncConjunto _Frm = new Frm_IncConjunto(this, Convert.ToString(_Cmb_Grupo_D.SelectedValue).Trim(), _Mtd_RetornarConjunto(Convert.ToInt32(_Txt_cidincmarcafoco.Text), Convert.ToInt32(_Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["cidincmarcafocod"].Value)), Convert.ToString(_Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["cdescripcion"].Value).Trim(), _Txt_cidincmarcafoco.Text.Trim(), Convert.ToString(_Cmb_Canal.SelectedValue).Trim(), Convert.ToString(_Cmb_Establecimiento.SelectedValue).Trim(), Convert.ToInt32(_Cmb_Ano.Text), Convert.ToInt32(_Cmb_Mes.Text));
            Cursor = Cursors.Default;
            if (_Frm.ShowDialog(this) == DialogResult.Yes)
            {
                MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }
    }
}
