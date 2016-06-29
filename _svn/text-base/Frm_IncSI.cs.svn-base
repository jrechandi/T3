// código verificado el 22/10/2012, conjunto de cambios 1733 por lordonez

using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_IncSI : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        bool _Bol_PermisoConfirmado = false;
        bool _Bol_UsuarioLider = false;
        bool _Bol_Nuevo = false;
        public Frm_IncSI()
        {
            InitializeComponent();
            _Bol_PermisoConfirmado = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & (_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_SI") | _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_V_INCT_SI"));
            _Bol_UsuarioLider = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_SI");
            _Bt_Copiar.Enabled = _Bol_UsuarioLider;
        }

        /// <summary>
        /// Retorna un valor que indica si un TextBox contiene valor numérico mayor a cero.
        /// </summary>
        /// <param name="_P_Txt_TextBox">Instancia de un TextBox</param>
        /// <returns>Bool</returns>
        private bool _Mtd_VerifContTextBoxNumeric(TextBox _P_Txt_TextBox)
        {
            if (_P_Txt_TextBox.Text.Trim().Length > 0)
            {
                if (Convert.ToDouble(_P_Txt_TextBox.Text) > 0)
                { return true; }
            }
            return false;
        }

        /// <summary>
        /// Configura el estilo visual de un control y sus controles secundarios.
        /// </summary>
        /// <param name="_P_Ctrl_Control">Instancia de un control</param>
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

        /// <summary>
        /// Carga los cargos en una instancia de ComboBox.
        /// </summary>
        /// <param name="_P_Cmb_Combo">ComboBox donde se cargara la consulta.</param>
        private void _Mtd_CargarCargos(ComboBox _P_Cmb_Combo)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT cidcargonom, cdescripcion FROM TCARGOSNOM WHERE ISNULL(cdelete,0)='0' AND (cgerarea='1' OR cvendedor='1' OR cgventas='1')";
            _Str_Cadena += " ORDER BY cdescripcion";
            _Cls_VariosMetodos._Mtd_CargarCombo(_P_Cmb_Combo, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Carga los grupos en una instancia de ComboBox según el cargo especificado y un valor que
        /// indica si se esta consultando o se está creando un nuevo registro.
        /// </summary>
        /// <param name="_P_Cmb_Combo">ComboBox donde se cargara la consulta.</param>
        /// <param name="_P_Cmb_ComboFiltro">ComboBox con los cargos</param>
        /// <param name="_P_Bol_Consulta">Valor que indica si se esta consultando o se está creando un nuevo registro</param>
        private void _Mtd_CargarGrupos(ComboBox _P_Cmb_Combo, ComboBox _P_Cmb_ComboFiltro, bool _P_Bol_Consulta)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT cidgrupincentivar, cdescripcion FROM TGRUPOIV WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'";
            if (_P_Cmb_ComboFiltro.SelectedIndex > 0)
            { _Str_Cadena += " AND cidcargonom='" + Convert.ToString(_P_Cmb_ComboFiltro.SelectedValue).Trim() + "'"; }
            if (!_P_Bol_Consulta)
            { _Str_Cadena += " AND NOT EXISTS(SELECT cidgrupincentivar FROM TINCSIM WHERE ccompany=TGRUPOIV.ccompany AND cidgrupincentivar=TGRUPOIV.cidgrupincentivar)"; }
            _Str_Cadena += " ORDER BY cdescripcion";
            _Cls_VariosMetodos._Mtd_CargarCombo(_P_Cmb_Combo, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Carga los canales en un ComboBox
        /// </summary>
        private void _Mtd_CargarCanal()
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT RTRIM(ccanal), RTRIM(cname) FROM TTCANAL WHERE ISNULL(cdelete,0)='0' ORDER BY cname ASC";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Canal, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Carga los establecimientos según el canal especificado.
        /// </summary>
        /// <param name="_P_Cmb_ComboFiltro">ComboBox con los canales</param>
        private void _Mtd_CargarEstablecimiento(ComboBox _P_Cmb_ComboFiltro)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT RTRIM(ctestablecim), RTRIM(cname) FROM TTESTABLECIM WHERE ISNULL(cdelete,0)='0'";
            _Str_Cadena += " AND ccanal='" + Convert.ToString(_P_Cmb_ComboFiltro.SelectedValue).Trim() + "'";
            _Str_Cadena += " ORDER BY cname";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Establecimiento, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Carga los años en un ComboBox
        /// </summary>
        private void _Mtd_CargarAños()
        {
            _Cmb_Ano.Items.Clear();
            _Cmb_Ano.Items.Add("...");
            for (int _Int_I = 2010; _Int_I <= CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().AddYears(2).Year; _Int_I++)
            {
                _Cmb_Ano.Items.Add(_Int_I);
            }
            _Cmb_Ano.SelectedIndex = 0;
        }

        /// <summary>
        /// Carga los meses en un ComboBox según el año especificado.
        /// </summary>
        /// <param name="_P_Int_Año">Año seleccionado</param>
        private void _Mtd_CargarMeses(int _P_Int_Año)
        {
            _Cmb_Mes.Items.Clear();
            _Cmb_Mes.Items.Add("...");
            for (int _Int_I = 1; _Int_I <= 12; _Int_I++)
            {
                _Cmb_Mes.Items.Add(_Int_I);
            }
            _Cmb_Mes.SelectedIndex = 0;
        }

        /// <summary>
        /// Carga en un ComboBox los proveedores según el grupo de incentivo seleccionado.
        /// </summary>
        /// <param name="_P_Str_Grupo">Grupo de incentivo seleccionado</param>
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

        /// <summary>
        /// Carga en un ComboBox las líneas según el proveedor seleccionado.
        /// </summary>
        /// <param name="_P_Str_Proveedor">Id del Proveedor seleccionado</param>
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

        /// <summary>
        /// Carga en un ComboBox los subgrupos según el proveedor y línea seelccionado.
        /// </summary>
        /// <param name="_P_Str_Proveedor">Id del proveedor seleccionado</param>
        /// <param name="_P_Str_Grupo">Id de la línea seleccionada</param>
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

        /// <summary>
        /// Inicaliza los controles pertenecientes al panel _Pnl_Detalle_1.
        /// </summary>
        private void _Mtd_IniPnl_Detalle_1()
        {
            _Txt_cidincsim.Text = "";
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarCargos(_Cmb_Cargo_D);
            Cursor = Cursors.Default;
            _Cmb_Grupo_D.DataSource = null;
        }

        /// <summary>
        /// Inicaliza los controles pertenecientes al groupBox _GrpB_Negociacion.
        /// </summary>
        private void _Mtd_IniGrpB_Negociacion()
        {
            _Txt_ccomisionmensual.Text = "";
            _Num_PorcVolumentVtasMin.Value = 0;
            _Num_PorcSurtIdealMin.Value = 0;
        }

        /// <summary>
        /// Inicaliza los controles pertenecientes al panel _Pnl_Detalle_2.
        /// </summary>
        private void _Mtd_IniPnl_Detalle_2()
        {
            _Cmb_Canal.DataSource = null;
            _Cmb_Establecimiento.DataSource = null;
            _Cmb_Ano.Items.Clear();
            _Cmb_Mes.Items.Clear();
        }

        /// <summary>
        /// Inicaliza los controles pertenecientes al panel _Pnl_Detalle_3.
        /// </summary>
        private void _Mtd_IniPnl_Detalle_3()
        {
            _Cmb_Proveedor.DataSource = null;
            _Cmb_Linea.DataSource = null;
            _Cmb_Subgrupo.DataSource = null;
            _Txt_Producto.Tag = ""; _Txt_Producto.Text = "";
        }

        /// <summary>
        /// Deshabilita los controles pertenecientes al panel _Pnl_Detalle_1.
        /// </summary>
        private void _Mtd_Deshabilitar_Pnl_Detalle_1()
        {
            _Cmb_Cargo_D.Enabled = false;
            _Cmb_Grupo_D.Enabled = false;
        }

        /// <summary>
        /// Habilita o deshabilita los controles pertenecientes al groupbox _GrpB_Negociacion
        /// según el valor especificado.
        /// </summary>
        /// <param name="_P_Bol_Habilitar">Valor que indica si se habilitan o deshabilitan los controles.</param>
        private void _Mtd_Habilitar_GrpB_Negociacion(bool _P_Bol_Habilitar)
        {
            _Txt_ccomisionmensual.Enabled = _P_Bol_Habilitar;
            if (_P_Bol_Habilitar)
            {
                _Mtd_HabilitarPorVentasMin(Convert.ToString(_Cmb_Cargo_D.SelectedValue).Trim());
            }
            else
            {
                _Num_PorcVolumentVtasMin.Enabled = false;
                _Lbl_PorcVolumentVtasMin.Enabled = false;
                _Num_PorcSurtIdealMin.Enabled = false;
                _Lbl_PorcSurtIdealMin.Enabled = false;
            }
        }

        /// <summary>
        /// Deshabilita los controles pertenecientes al panel _Pnl_Detalle_2.
        /// </summary>
        private void _Mtd_Deshabilitar_Pnl_Detalle_2()
        {
            _Cmb_Canal.Enabled = false;
            _Cmb_Establecimiento.Enabled = false;
            _Cmb_Ano.Enabled = false;
            _Cmb_Mes.Enabled = false;
        }

        /// <summary>
        /// Deshabilita los controles pertenecientes al panel _Pnl_Detalle_3.
        /// </summary>
        private void _Mtd_Deshabilitar_Pnl_Detalle_3()
        {
            _Cmb_Proveedor.Enabled = false;
            _Cmb_Linea.Enabled = false;
            _Cmb_Subgrupo.Enabled = false;
            _Txt_Producto.Enabled = false;
        }

        /// <summary>
        /// Habilita los controles iniciales para la edición del incentivo.
        /// </summary>
        public void _Mtd_Habilitar()
        {
            _GrpB_Negociacion.Enabled = true;
            _Pnl_Detalle_2.Enabled = _Mtd_TipoVendedor(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 1;
            _Bt_Eliminar.Enabled = _Dg_Detalle.RowCount > 0 & _Bol_UsuarioLider;
            _Bt_Agregar.Enabled = _Bol_UsuarioLider & _Cmb_Canal.SelectedIndex > 0 & _Cmb_Establecimiento.SelectedIndex > 0 & _Cmb_Ano.SelectedIndex > 0 & _Cmb_Mes.SelectedIndex > 0;
        }

        /// <summary>
        /// Inicializa los controles del formulario.
        /// </summary>
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

        /// <summary>
        /// Configura el formulario para crear un nuevo incentivo.
        /// </summary>
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

        /// <summary>
        /// Valida los controles que pertenecen al groupbox _GrpB_Negociacion.
        /// </summary>
        /// <returns></returns>
        private bool _Mtd_Validar_GrpB_Negociacion()
        {
            _Er_Error.Dispose();
            if (_Mtd_VerifContTextBoxNumeric(_Txt_ccomisionmensual))
            {
                return true;
            }
            else
            {
                if (!_Bol_Nuevo & _Tb_Tab.SelectedIndex == 1)
                {
                    if (!_Mtd_VerifContTextBoxNumeric(_Txt_ccomisionmensual)) { _Er_Error.SetError(_Txt_ccomisionmensual, "Información requerida!!!"); }
                }
            }
            return false;
        }

        /// <summary>
        /// Selecciona el subgrupo en el combobox según el producto selecionado.
        /// </summary>
        /// <param name="_P_Str_Producto">Id del producto seleccionado</param>
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

        /// <summary>
        /// Carga los datos en el grid principal del formulario.
        /// </summary>
        private void _Mtd_Actualizar()
        {
            Program._Dat_Vistas = new DataContext._Dat_CntxVistasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            var _Var_Datos = from Campos in Program._Dat_Vistas.VST_INC_SI
                             where Campos.ccompany == Frm_Padre._Str_Comp
                             select new { Grupo_Incentivo = Campos.cidgrupincentivar, Descripción = Campos.cdescripcion, Campos.cidcargonom };
            if (_Cmb_Cargo.SelectedIndex > 0)
            { _Var_Datos = _Var_Datos.Where(c => c.cidcargonom == Convert.ToString(_Cmb_Cargo.SelectedValue).Trim()); }
            _Dg_Grid.DataSource = _Var_Datos;
            _Dg_Grid.Columns["Grupo_Incentivo"].Visible = false;
            _Dg_Grid.Columns["cidcargonom"].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// Inicializa el grid del detalle para crear sus columnas.
        /// </summary>
        private void _Mtd_IniGrid_Detalle()
        {
            var _Var_Datos = from Campos in Program._Dat_Vistas.VST_INC_SI_D
                             where 0 > 1
                             select new { Campos.cano, Campos.ccuarto, Campos.cdesccanal, Campos.cdesctestable, Campos.cproducto, Campos.cdescripcion, Campos.cidincsid, Campos.ccanal, Campos.ctestable };
            _Dg_Detalle.DataSource = _Var_Datos;
            _Dg_Detalle.Columns["cidincsid"].Visible = false;
            _Dg_Detalle.Columns["ccanal"].Visible = false;
            _Dg_Detalle.Columns["ctestable"].Visible = false;
        }

        /// <summary>
        /// Establece en un textbox el cuarto según el mes seleccionado.
        /// </summary>
        /// <param name="_P_Txt_Cuarto">Textbox donde se establece el cuarto</param>
        private void _Mtd_EstablecerCuartoDesc(TextBox _P_Txt_Cuarto)
        {
            _P_Txt_Cuarto.Tag = 0;
            _P_Txt_Cuarto.Text = "";
            if (_Cmb_Mes.SelectedIndex > 0)
            {
                Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
                int _Int_Mes = Convert.ToInt32(_Cmb_Mes.Text);
                var _Var_Datos = Program._Dat_Tablas.TCONFIGINCVTASCUARTOS.Where(x => x.cmescalendario == _Int_Mes && x.cdelete == 0).FirstOrDefault();
                if (_Var_Datos != null)
                {
                    _P_Txt_Cuarto.Tag = _Var_Datos.ccuarto;
                    _P_Txt_Cuarto.Text = "Q" + _Var_Datos.ccuarto + " - " + _Var_Datos.cmescuarto;
                }
            }
        }

        /// <summary>
        /// Carga los datos en el grid del detalle del formulario según el id de incentivo seleccionado.
        /// </summary>
        /// <param name="_P_Int_IncSI">Id del incentivo selecionado.</param>
        private void _Mtd_ActualizarDetalle(int _P_Int_IncSI)
        {
            Program._Dat_Vistas = new DataContext._Dat_CntxVistasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            var _Var_Datos = from Campos in Program._Dat_Vistas.VST_INC_SI_D
                             where Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidincsim == _P_Int_IncSI
                             select new { Campos.cano, Campos.ccuarto, Campos.cdesccanal, Campos.cdesctestable, Campos.cproducto, Campos.cdescripcion, Campos.cidincsid, Campos.ccanal, Campos.ctestable };
            
            if (_Cmb_Canal.SelectedIndex > 0) { _Var_Datos = _Var_Datos.Where(c => c.ccanal == Convert.ToString(_Cmb_Canal.SelectedValue).Trim()); }
            if (_Cmb_Establecimiento.SelectedIndex > 0) { _Var_Datos = _Var_Datos.Where(c => c.ctestable == Convert.ToString(_Cmb_Establecimiento.SelectedValue).Trim()); }
            if (_Cmb_Ano.SelectedIndex > 0) { _Var_Datos = _Var_Datos.Where(c => c.cano == Convert.ToInt32(_Cmb_Ano.Text)); }
            if (_Cmb_Mes.SelectedIndex > 0) 
            {
                _Var_Datos = _Var_Datos.Where(c => c.ccuarto == Convert.ToInt32(_Txt_Cuarto.Tag)); 
            }

            _Dg_Detalle.DataSource = _Var_Datos.OrderBy(x => x.cano).OrderBy(x => x.ccuarto);
            _Dg_Detalle.Columns["cidincsid"].Visible = false;
            _Dg_Detalle.Columns["ccanal"].Visible = false;
            _Dg_Detalle.Columns["ctestable"].Visible = false;
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// Retorna un valor que indica el tipo de cargo de la entidad a la que se le está cargando el incentivo.
        /// </summary>
        /// <param name="_P_Str_Cargo">Id del cargo.</param>
        /// <returns>1-Vendedor, 2-Gerente de area, 3-Gerente de ventas, 0-Nulo</returns>
        private byte _Mtd_TipoVendedor(string _P_Str_Cargo)
        {
            var _Var_Datos = (from Campos in Program._Dat_Tablas.TCARGOSNOM
                              where Campos.cidcargonom == _P_Str_Cargo
                              select Campos);
            if (_Var_Datos.Count() > 0)
            {
                if (_Var_Datos.Single().cvendedor == 1)
                { return 1; }
                else if (_Var_Datos.Single().cgerarea==1)
                { return 2; }
                else if (_Var_Datos.Single().cgventas == 1)
                { return 3; }
            }
            return 0;
        }

        /// <summary>
        /// Retorna un valor que indica si exsite un insentivo según el grupo de incentivo seleccionado.
        /// </summary>
        /// <param name="_P_Int_GrupoInc">Id del grupo de incentivo seleccionado</param>
        /// <returns>Verdadero o falso.</returns>
        private bool _Mtd_Existe(int _P_Int_GrupoInc)
        {
            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            return (from Campos in Program._Dat_Tablas.TINCSIM
                    where Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == _P_Int_GrupoInc
                    select Campos.cidgrupincentivar).Count() > 0;
        }

        /// <summary>
        /// Retorna una instancia de la entidad TINCSID según los parámetros especificados.
        /// </summary>
        /// <param name="_P_Str_IncSI">Id del incentivo</param>
        /// <param name="_P_Str_Canal">Id del canal</param>
        /// <param name="_P_Str_Establecimiento">Id del establecimiento</param>
        /// <param name="_P_Int_Año">Año</param>
        /// <param name="_P_Int_Cuarto">Cuarto</param>
        /// <param name="_P_Str_Producto">Id del producto.</param>
        /// <returns>Instancia de la entidad TINCSID</returns>
        private DataContext.TINCSID _Mtd_EndidadTINCSID(string _P_Str_IncSI, string _P_Str_Canal, string _P_Str_Establecimiento, int _P_Int_Año, int _P_Int_Cuarto, string _P_Str_Producto)
        {
            return (from Campos in Program._Dat_Tablas.TINCSID
                    where Campos.cidincsim == Convert.ToInt32(_P_Str_IncSI) && Campos.ccanal == _P_Str_Canal && Campos.ctestable == _P_Str_Establecimiento && Campos.cano == _P_Int_Año && Campos.ccuarto == _P_Int_Cuarto && Campos.cproducto == _P_Str_Producto
                    select Campos).FirstOrDefault();
        }

        /// <summary>
        /// Retorna un valor que indica si se puede insertar un detalle o no, filtrando la consulta
        /// por los parámetros especificados.
        /// </summary>
        /// <param name="_P_Str_IncSI">Id del incentivo</param>
        /// <param name="_P_Str_Canal">Id del canal</param>
        /// <param name="_P_Str_Establecimiento">Id del establecimiento</param>
        /// <param name="_P_Int_Año">Año</param>
        /// <param name="_P_Int_Cuarto">Cuarto</param>
        /// <returns>Verdadero o falso.</returns>
        private bool _Mtd_SePuedeInsertarDetalle(string _P_Str_IncSI, string _P_Str_Canal, string _P_Str_Establecimiento, int _P_Int_Año, int _P_Int_Cuarto, string _P_Str_Producto)
        {
            Cursor = Cursors.WaitCursor;
            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            if (Program._Dat_Tablas.TINCSID.Where(x => x.cidincsim == Convert.ToInt32(_P_Str_IncSI) && x.ccanal == _P_Str_Canal && x.ctestable == _P_Str_Establecimiento && x.cano == _P_Int_Año && x.ccuarto == _P_Int_Cuarto && x.cproducto != _P_Str_Producto).Count() >= 40)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("No se puede insertar el registro. El límite máximo(40) de productos a registrar ha sido alcanzado", "Restricción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            Cursor = Cursors.Default;
            return true;
        }

        /// <summary>
        /// Retorna un valor que indica si se puede insertar un detalle o no, filtrando la consulta
        /// por los parámetros especificados.
        /// </summary>
        /// <param name="_P_Str_IncSI">Id del incentivo</param>
        /// <param name="_P_Str_Canal">Id del canal</param>
        /// <param name="_P_Str_Establecimiento">Id del establecimiento</param>
        /// <param name="_P_Int_Año">Año</param>
        /// <param name="_P_Int_Cuarto">Cuarto</param>
        /// <param name="_P_Dg_Grid">Grid que contiene los datos para guardar los detalles.</param>
        /// <returns>Verdadero o falso.</returns>
        private bool _Mtd_SePuedeInsertarDetalle(string _P_Str_IncSI, string _P_Str_Canal, string _P_Str_Establecimiento, int _P_Int_Año, int _P_Int_Cuarto, string _P_Str_Producto, DataGridView _P_Dg_Grid)
        {
            Cursor = Cursors.WaitCursor;
            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            var _Var_Datos = Program._Dat_Tablas.TINCSID.Where(x => x.cidincsim == Convert.ToInt32(_P_Str_IncSI) && x.ccanal == _P_Str_Canal && x.ctestable == _P_Str_Establecimiento && x.cano == _P_Int_Año && x.ccuarto == _P_Int_Cuarto);
            var intCantidadNoExistentes = _P_Dg_Grid.SelectedRows.Cast<DataGridViewRow>().Select(c => Convert.ToString(c.Cells[0].Value)).Count(x => !_Var_Datos.Select(c => c.cproducto).Contains(x));
            //var intCantidadExistentes = _Var_Datos.Count(x => !_P_Dg_Grid.Rows.Cast<DataGridViewRow>().Select(c => Convert.ToString(c.Cells[0].Value)).Contains(x.cproducto));
            var intCantidadExistentes = _Var_Datos.Count();
            if (intCantidadNoExistentes + intCantidadExistentes > 40)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("No se pueden insertar registros. La cantidad de productos a registrar supera el límite máximo(40) de productos permitidos.", "Restricción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            Cursor = Cursors.Default;
            return true;
        }

        /// <summary>
        /// Inserta o edita los registros en la tabla maestra (TINCSIM) según el grupo de incentivo seleccionado.
        /// </summary>
        /// <param name="_P_Int_GrupoInc">Id del grupo de incentivo seleccionado</param>
        /// <returns>Id del incentivo creado.</returns>
        private int _Mtd_InsertarEditarMaestra(int _P_Int_GrupoInc)
        {
            DataContext.TINCSIM _T_TINCSIM;
            bool _Bol_Existe = _Mtd_Existe(_P_Int_GrupoInc);
            if (_Bol_Existe)
            { _T_TINCSIM = Program._Dat_Tablas.TINCSIM.Single(c => c.ccompany == Frm_Padre._Str_Comp & c.cidgrupincentivar == _P_Int_GrupoInc); }
            else
            {
                _Cmb_Cargo_D.Enabled = false; _Cmb_Grupo_D.Enabled = false;
                _T_TINCSIM = new T3.DataContext.TINCSIM();
                _T_TINCSIM.ccompany = Frm_Padre._Str_Comp;
                _T_TINCSIM.cidgrupincentivar = _P_Int_GrupoInc;
            }
            _T_TINCSIM.ccomisionmensual = Convert.ToDecimal(_Txt_ccomisionmensual.Text);
            _T_TINCSIM.ctipovendedor = _Mtd_TipoVendedor(Convert.ToString(_Cmb_Cargo_D.SelectedValue));
            _T_TINCSIM.cvvporcmin = _Num_PorcVolumentVtasMin.Value;
            _T_TINCSIM.csiporcmin = _Num_PorcSurtIdealMin.Value;
            if (_Bol_Existe)
            {
                _T_TINCSIM.cdateupd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _T_TINCSIM.cuserupd = Frm_Padre._Str_Use;
            }
            else
            {
                _T_TINCSIM.cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _T_TINCSIM.cuseradd = Frm_Padre._Str_Use;
                Program._Dat_Tablas.TINCSIM.InsertOnSubmit(_T_TINCSIM);
            }
            Program._Dat_Tablas.SubmitChanges();
            _Txt_cidincsim.Text = _T_TINCSIM.cidincsim.ToString();
            return (int)_T_TINCSIM.cidincsim;
        }

        /// <summary>
        /// Inserta los registros en la tabla del detalle (TINCSID) según el grupo de incentivo seleccionado.
        /// </summary>
        /// <param name="_P_Int_GrupoInc">Id del grupo de incentivo seleccionado</param>
        private void _Mtd_InsertarRegistros(int _P_Int_GrupoInc)
        {
            int _Int_IncSI = _Mtd_InsertarEditarMaestra(_P_Int_GrupoInc);
            var _Var_TINCSID = _Mtd_EndidadTINCSID(Convert.ToString(_Int_IncSI), Convert.ToString(_Cmb_Canal.SelectedValue).Trim(), Convert.ToString(_Cmb_Establecimiento.SelectedValue).Trim(), Convert.ToInt32(_Cmb_Ano.Text), Convert.ToInt32(_Txt_Cuarto.Tag), Convert.ToString(_Txt_Producto.Tag).Trim());
            if (_Var_TINCSID != null)
            {
                Program._Dat_Tablas.TINCSID.DeleteOnSubmit(_Var_TINCSID);
                Program._Dat_Tablas.SubmitChanges();
            }
            //------------------------------------
            DataContext.TINCSID _T_TINCSID = new T3.DataContext.TINCSID()
            {
                cidincsim = _Int_IncSI,
                cano = Convert.ToInt32(_Cmb_Ano.Text),
                ccuarto = (byte)Convert.ToInt32(_Txt_Cuarto.Tag),
                ccanal = Convert.ToString(_Cmb_Canal.SelectedValue).Trim(),
                ctestable = Convert.ToString(_Cmb_Establecimiento.SelectedValue).Trim(),
                cproducto = Convert.ToString(_Txt_Producto.Tag).Trim(),
                cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ(),
                cuseradd = Frm_Padre._Str_Use
            };
            //------------------------------------
            Program._Dat_Tablas.TINCSID.InsertOnSubmit(_T_TINCSID);
            //------------------------------------
            Program._Dat_Tablas.SubmitChanges();
        }

        /// <summary>
        /// Inserta los registros en la tabla del detalle (TINCSID) según el grupo de incentivo seleccionado y un grid
        /// que contiene los productos a insertar.
        /// </summary>
        /// <param name="_P_Int_GrupoInc">Id del grupo de incentivo seleccionado</param>
        /// <param name="_P_Dg_Grid">Grid que contiene los productos a insertar</param>
        private void _Mtd_InsertarRegistros(int _P_Int_GrupoInc, DataGridView _P_Dg_Grid)
        {
            int _Int_IncSI = _Mtd_InsertarEditarMaestra(_P_Int_GrupoInc);
            //------------------------------------
            foreach (DataGridViewRow _Dg_Row in _P_Dg_Grid.SelectedRows)
            {
                var _Var_TINCSID = _Mtd_EndidadTINCSID(Convert.ToString(_Int_IncSI), Convert.ToString(_Cmb_Canal.SelectedValue).Trim(), Convert.ToString(_Cmb_Establecimiento.SelectedValue).Trim(), Convert.ToInt32(_Cmb_Ano.Text), Convert.ToInt32(_Txt_Cuarto.Tag), Convert.ToString(_Dg_Row.Cells[0].Value).Trim());
                if (_Var_TINCSID != null)
                {
                    Program._Dat_Tablas.TINCSID.DeleteOnSubmit(_Var_TINCSID);
                    Program._Dat_Tablas.SubmitChanges();
                }
                //------------------------------------
                DataContext.TINCSID _T_TINCSID = new T3.DataContext.TINCSID()
                {
                    cidincsim = _Int_IncSI,
                    cano = Convert.ToInt32(_Cmb_Ano.Text),
                    ccuarto = (byte)Convert.ToInt32(_Txt_Cuarto.Tag),
                    ccanal = Convert.ToString(_Cmb_Canal.SelectedValue).Trim(),
                    ctestable = Convert.ToString(_Cmb_Establecimiento.SelectedValue).Trim(),
                    cproducto = Convert.ToString(_Dg_Row.Cells[0].Value).Trim(),
                    cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ(),
                    cuseradd = Frm_Padre._Str_Use
                };
                //------------------------------------
                Program._Dat_Tablas.TINCSID.InsertOnSubmit(_T_TINCSID);
                Program._Dat_Tablas.SubmitChanges();
            }
        }
        
        /// <summary>
        /// Valida los datos necesarios, invoca los metódos de insertar registros
        /// y retorna un valor que indica si se realizó el guardado correctamente.
        /// </summary>
        /// <returns>Verdadero o falso.</returns>
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            if (_Cmb_Cargo_D.SelectedIndex > 0 & _Cmb_Grupo_D.SelectedIndex > 0 & _Mtd_Validar_GrpB_Negociacion())
            {
                if (_Num_PorcVolumentVtasMin.Enabled && _Num_PorcVolumentVtasMin.Value == 0 || _Num_PorcSurtIdealMin.Enabled && _Num_PorcSurtIdealMin.Value == 0)
                {
                    if (_Num_PorcVolumentVtasMin.Enabled && _Num_PorcVolumentVtasMin.Value == 0)
                        _Er_Error.SetError(_Num_PorcVolumentVtasMin, "Información requerida!!!");
                    if(_Num_PorcSurtIdealMin.Enabled && _Num_PorcSurtIdealMin.Value == 0)
                        _Er_Error.SetError(_Num_PorcSurtIdealMin, "Información requerida!!!");
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
                    if (_Mtd_TipoVendedor(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 2)
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

        /// <summary>
        /// Guarda un detalle.
        /// </summary>
        private void _Mtd_GuardarDetalle()
        {

            if (!_Mtd_SePuedeInsertarDetalle(_Txt_cidincsim.Text, Convert.ToString(_Cmb_Canal.SelectedValue).Trim(), Convert.ToString(_Cmb_Establecimiento.SelectedValue).Trim(), Convert.ToInt32(_Cmb_Ano.Text), Convert.ToInt32(_Txt_Cuarto.Tag), Convert.ToString(_Txt_Producto.Tag).Trim()))
                return;
            Cursor = Cursors.WaitCursor;
            _Mtd_InsertarRegistros(Convert.ToInt32(_Cmb_Grupo_D.SelectedValue));
            _Mtd_Actualizar();
            _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_cidincsim.Text));
            _Txt_Producto.Tag = ""; _Txt_Producto.Text = "";
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Guarda los detalles según los datos de un grid y retorna un valor que indica si los datos fueron guardados.
        /// </summary>
        /// <param name="_P_Dg_Grid">Grid que contiene los datos para guardar los detalles.</param>
        /// <returns>Verdadero o falso.</returns>
        public bool _Mtd_Guardar_(DataGridView _P_Dg_Grid)
        {
            if (!_Mtd_SePuedeInsertarDetalle(_Txt_cidincsim.Text, Convert.ToString(_Cmb_Canal.SelectedValue).Trim(), Convert.ToString(_Cmb_Establecimiento.SelectedValue).Trim(), Convert.ToInt32(_Cmb_Ano.Text), Convert.ToInt32(_Txt_Cuarto.Tag), Convert.ToString(_Txt_Producto.Tag).Trim(), _P_Dg_Grid))
                return false;
            Cursor = Cursors.WaitCursor;
            _Mtd_InsertarRegistros(Convert.ToInt32(_Cmb_Grupo_D.SelectedValue), _P_Dg_Grid);
            _Mtd_Actualizar();
            _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_cidincsim.Text));
            Cursor = Cursors.Default;
            return true;
        }

        /// <summary>
        /// Método que invoca la metodo guardar y retorna si se realizó el guardado o no.
        /// (Necesario asi por la botonera principal del sistema)
        /// </summary>
        /// <returns>Verdadero o falso.</returns>
        public bool _Mtd_Editar()
        {
            return _Mtd_Guardar();
        }

        /// <summary>
        /// Elimina un incentivo y su detalle.
        /// </summary>
        private void _Mtd_EliminarRegistros()
        {
            var _Var_Datos = from Campos in _Dg_Grid.Rows.Cast<DataGridViewRow>()
                             where Campos.Selected
                             select Campos;
            foreach (DataGridViewRow _DgRow in _Var_Datos)
            {
                var _Var_cidincsim = (from Campos in Program._Dat_Tablas.TINCSIM
                                           where Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == Convert.ToInt32(_DgRow.Cells["Grupo_Incentivo"].Value)
                                      select Campos.cidincsim).Single();
                //--------------------------------------------------------------------
                var _Var_TINCSIMD = from Campos in Program._Dat_Tablas.TINCSID where Campos.cidincsim == _Var_cidincsim select Campos;
                if (_Var_TINCSIMD.Count() > 0) { Program._Dat_Tablas.TINCSID.DeleteAllOnSubmit(_Var_TINCSIMD); }
                //--------------------------------------------------------------------
                Program._Dat_Tablas.TINCSIM.DeleteOnSubmit(Program._Dat_Tablas.TINCSIM.Single(c => c.cidincsim == _Var_cidincsim));
            }
            Program._Dat_Tablas.SubmitChanges();
        }

        /// <summary>
        /// Elimina los detalles seleccionados de un incentivo.
        /// </summary>
        /// <param name="_P_Str_IncSI">Id del incentivo al que se le eliminaran los detalles seleecionados.</param>
        private void _Mtd_EliminarRegistros(int _P_Str_IncSI)
        {
            var _Var_Datos = from Campos in _Dg_Detalle.Rows.Cast<DataGridViewRow>()
                             where Campos.Selected
                             select Campos;
            foreach (DataGridViewRow _DgRow in _Var_Datos)
            {
                Program._Dat_Tablas.TINCSID.DeleteOnSubmit(Program._Dat_Tablas.TINCSID.Single(c => c.cidincsim == _P_Str_IncSI & c.cidincsid == Convert.ToInt32(_DgRow.Cells["cidincsid"].Value)));
            }
            Program._Dat_Tablas.SubmitChanges();
        }

        /// <summary>
        /// Carga los controles con los datos del incentivo seleccioando.
        /// </summary>
        /// <param name="_P_Int_GrupoInc">Id del grupo de incentivo</param>
        /// <param name="_P_Str_Cargo">Id del cargo el incentivo</param>
        private void _Mtd_CargarFormulario(int _P_Int_GrupoInc, string _P_Str_Cargo)
        {
            var _Var_Datos = (from Campos in Program._Dat_Tablas.TINCSIM
                              where Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == _P_Int_GrupoInc
                              select Campos).Single();
            _Txt_cidincsim.Text = _Var_Datos.cidincsim.ToString();
            _Cmb_Cargo_D.SelectedIndexChanged -= new EventHandler(_Cmb_Cargo_D_SelectedIndexChanged);
            _Cmb_Cargo_D.SelectedValue = _P_Str_Cargo;
            _Cmb_Cargo_D.SelectedIndexChanged += new EventHandler(_Cmb_Cargo_D_SelectedIndexChanged);
            _Mtd_CargarGrupos(_Cmb_Grupo_D, _Cmb_Cargo_D, true);
            _Cmb_Grupo_D.SelectedValue = _P_Int_GrupoInc.ToString();
            _Txt_ccomisionmensual.Text = _Var_Datos.ccomisionmensual.ToString();
            _Num_PorcVolumentVtasMin.Value = Convert.ToDecimal(_Var_Datos.cvvporcmin);
            _Num_PorcSurtIdealMin.Value = Convert.ToDecimal(_Var_Datos.csiporcmin);
        }

        /// <summary>
        /// Verifica si una cadena tiene un valor numerico mayor a cero.
        /// </summary>
        /// <param name="_P_Str_Monto">Cadena con el valor</param>
        /// <returns>Verdadero o falso.</returns>
        public bool _Mtd_VerificarMonto(string _P_Str_Monto)
        {
            try
            {
                return Convert.ToDouble(_P_Str_Monto) >= 0;
            }
            catch { return false; }
        }

        /// <summary>
        /// Habilita los porcentajes según el tipo de cargo seleecionado.
        /// </summary>
        /// <param name="_P_Str_Cargo">Id del cargo seleccionado.</param>
        private void _Mtd_HabilitarPorVentasMin(string _P_Str_Cargo)
        {
            if ((from Campos in Program._Dat_Tablas.TCARGOSNOM
                 where Campos.cidcargonom == _P_Str_Cargo & Campos.cvendedor == 1
                 select Campos.cidcargonom).Count() > 0)
            {
                _Lbl_PorcVolumentVtasMin.Enabled = true;
                _Num_PorcVolumentVtasMin.Enabled = true;
                _Lbl_PorcSurtIdealMin.Enabled = true;
                _Num_PorcSurtIdealMin.Enabled = true;
            }
            else
            {
                _Lbl_PorcVolumentVtasMin.Enabled = false;
                _Num_PorcVolumentVtasMin.Enabled = false;
                _Num_PorcVolumentVtasMin.Value = 0;
                _Lbl_PorcSurtIdealMin.Enabled = false;
                _Num_PorcSurtIdealMin.Enabled = false;
                _Num_PorcSurtIdealMin.Value = 0;
            }
        }

        private void Frm_IncSI_Load(object sender, EventArgs e)
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

        private void Frm_IncSI_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_SI");
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = (!_Pnl_Detalle_1.Enabled & !_GrpB_Negociacion.Enabled & !_Pnl_Detalle_3.Visible) & _Mtd_VerifContTextBoxNumeric(_Txt_ccomisionmensual) & _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_SI");
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _Tb_Tab.SelectedIndex == 1 & !((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled & _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_SI");
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
        }

        private void Frm_IncSI_FormClosing(object sender, FormClosingEventArgs e)
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
            _Pnl_Detalle_2.Enabled = _Cmb_Grupo_D.SelectedIndex > 0 & _Mtd_TipoVendedor(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 1;
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
            _Mtd_Habilitar_GrpB_Negociacion(!_Txt_ccomisionmensual.Enabled);
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
            { _Cmb_Mes.Items.Clear(); _Cmb_Mes.Enabled = false; _Mtd_EstablecerCuartoDesc(_Txt_Cuarto); }
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
            _Mtd_EstablecerCuartoDesc(_Txt_Cuarto);
            _Bt_Agregar.Enabled = _Bol_UsuarioLider & _Cmb_Canal.SelectedIndex > 0 & _Cmb_Establecimiento.SelectedIndex > 0 & _Cmb_Ano.SelectedIndex > 0 & _Cmb_Mes.SelectedIndex > 0 & ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled;
        }
        private void Frm_IncSI_Shown(object sender, EventArgs e)
        {
            if (!_Bol_PermisoConfirmado)
            { MessageBox.Show("Su usuario no tiene permisos para entrar en este módulo", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close(); }
            else
            { _Cmb_Cargo.Focus(); }
        }

        private void _Bt_Filtrar_Click(object sender, EventArgs e)
        {
            if (_Txt_cidincsim.Text.Trim().Length > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_cidincsim.Text));
                Cursor = Cursors.Default;
            }
            else
            { MessageBox.Show("Aún no existen registros", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Bt_Agregar_Click(object sender, EventArgs e)
        {
            if (_Txt_cidincsim.Text.Trim().Length > 0)
            {
                _Pnl_Detalle_1.Enabled = false;
                _GrpB_Negociacion.Enabled = false;
                _Pnl_Detalle_2.Enabled = false;
                _Mtd_IniPnl_Detalle_3();
                _Mtd_Deshabilitar_Pnl_Detalle_3();
                _Pnl_Detalle_3.Visible = true;
                _Mtd_Cargar_Proveedor(Convert.ToString(_Cmb_Grupo_D.SelectedValue).Trim());
                _Cmb_Proveedor.Enabled = true;
                _Cmb_Proveedor.Focus();
                Cursor = Cursors.WaitCursor;
                _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_cidincsim.Text));
                Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Debe guardar la información seleccionada antes de cargar el detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Txt_ccomisiontotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_ccomisionmensual, e, 15, 2);
        }

        private void _Txt_ccomisiontotal_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_ccomisionmensual.Text)) { _Txt_ccomisionmensual.Text = ""; }
            _Cmb_Canal.Enabled = _Mtd_Validar_GrpB_Negociacion() & _Mtd_TipoVendedor(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 1;
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
                _Bt_Buscar.Enabled = true;
            }
            else
            {
                _Cmb_Linea.DataSource = null; _Cmb_Linea.Enabled = false;
                _Bt_Buscar.Enabled = false;
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
                _Txt_Producto.Tag = ""; _Txt_Producto.Text = ""; _Txt_Producto.Enabled = true;
            }
            else
            {
                _Cmb_Subgrupo.DataSource = null; _Cmb_Subgrupo.Enabled = false;
                _Txt_Producto.Tag = ""; _Txt_Producto.Text = ""; _Txt_Producto.Enabled = false;
            }
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
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
            _Pnl_Detalle_1.Enabled = _Txt_cidincsim.Text.Trim().Length == 0;
            _Bt_Agregar.Focus();
        }
        private void _Bt_Guardar_Click(object sender, EventArgs e)
        {
            _Mtd_GuardarDetalle();
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
                    _Mtd_EliminarRegistros(Convert.ToInt32(_Txt_cidincsim.Text));
                    _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_cidincsim.Text));
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
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_SI");
                _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                _Tb_Tab.SelectedIndex = 1;
                _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                Cursor = Cursors.Default;
                _Pnl_Detalle_2.Enabled = _Mtd_TipoVendedor(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 1;
                _Mtd_CargarCanal();
                _Cmb_Canal.Enabled = _Mtd_TipoVendedor(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 1;
                _Mtd_CargarAños();
                _Cmb_Ano.Enabled = _Cmb_Canal.Enabled;
                _Dg_Detalle.DataSourceChanged -= new EventHandler(_Dg_Detalle_DataSourceChanged);
                Cursor = Cursors.WaitCursor;
                _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_cidincsim.Text));
                Cursor = Cursors.Default;
                _Dg_Detalle.DataSourceChanged += new EventHandler(_Dg_Detalle_DataSourceChanged);
            }
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _Dg_Grid.SelectedRows.Count == 0 | !(_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_SI"));
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
            Frm_IncCopiar _Frm = new Frm_IncCopiar(2);
            Cursor = Cursors.Default;
            if (_Frm.ShowDialog() == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Actualizar();
                Cursor = Cursors.Default;
            }
        }

        private void _Txt_Producto_TextChanged(object sender, EventArgs e)
        {
            _Bt_Guardar.Enabled = _Txt_Producto.Text.Trim().Length > 0;
        }


    }
}
