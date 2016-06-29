using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;

namespace T3
{
    public partial class Frm_IncDistribucion : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        bool _Bol_PermisoConfirmado = false;
        bool _Bol_UsuarioLider = false;
        public Frm_IncDistribucion()
        {
            InitializeComponent();
            _Bol_PermisoConfirmado = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & (_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_DIS") | _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_V_INCT_DIS"));
            _Bol_UsuarioLider = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_DIS");
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
            { _Str_Cadena += " AND NOT EXISTS(SELECT cidgrupincentivar FROM TINCDISTRIBU WHERE cgroupcomp=TGRUPOIV.cgroupcomp AND ccompany=TGRUPOIV.ccompany AND cidgrupincentivar=TGRUPOIV.cidgrupincentivar)"; }
            _Str_Cadena += " ORDER BY cdescripcion";
            _Cls_VariosMetodos._Mtd_CargarCombo(_P_Cmb_Combo, _Str_Cadena);
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
        private int _Mtd_ValidarGuardar(string _P_Str_IncDistrib, string _P_Str_Proveedor, string _P_Str_Grupo, int _P_Int_Año, int _P_Int_Mes)
        {
            if (_P_Str_IncDistrib.Trim().Length > 0)
            {
                var _Var_Datos = from Campos in Program._Dat_Tablas.TINCDISTRIBUD
                                 where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidincdistribu ==Convert.ToInt32(_P_Str_IncDistrib) & Campos.cproveedor == _P_Str_Proveedor & Campos.cgrupo == _P_Str_Grupo & Campos.cano == Convert.ToDecimal(_P_Int_Año) & Campos.cmes == Convert.ToDecimal(_P_Int_Mes)
                                 select Campos.cidincdistribud;
                if (_Var_Datos.Count() > 0) { return _Var_Datos.Single(); }
            }
            return 0;
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
            string _Str_Cadena = "SELECT distinct dbo.TGRUPPROM.ccodgrupop, dbo.TGRUPPROM.cname " +
            "FROM dbo.TGRUPPROM INNER JOIN " +
            "dbo.TGRUPPROD ON dbo.TGRUPPROM.ccodgrupop = dbo.TGRUPPROD.ccodgrupop AND " +
            "dbo.TGRUPPROM.cdelete = dbo.TGRUPPROD.cdelete INNER JOIN " +
            "dbo.TPRODUCTO ON dbo.TGRUPPROD.cproveedor = dbo.TPRODUCTO.cproveedor AND dbo.TGRUPPROD.ccodgrupop = dbo.TPRODUCTO.cgrupo " +
            "where NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE TGRUPPROD.cproveedor=TFILTROREGIONALP.cproveedor and TPRODUCTO.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') " +
            "AND (TGRUPPROD.cproveedor = '" + _P_Str_Proveedor + "') AND (TGRUPPROM.cdelete = 0) AND (TPRODUCTO.cdelete=0) ORDER BY TGRUPPROM.cname";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Linea, _Str_Cadena);
        }
        private void _Mtd_Actualizar()
        {
            var _Var_Datos = from Campos in Program._Dat_Vistas.VST_INC_DISTRIBU
                             where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp
                             select new { Grupo_Insentivo = Campos.cidgrupincentivar, Descripción = Campos.cdescripcion, Campos.cidcargonom };
            if (_Cmb_Cargo.SelectedIndex > 0)
            { _Var_Datos = _Var_Datos.Where(c => c.cidcargonom == Convert.ToString(_Cmb_Cargo.SelectedValue).Trim()); }
            _Dg_Grid.DataSource = _Var_Datos;
            _Dg_Grid.Columns["Grupo_Insentivo"].Visible = false;
            _Dg_Grid.Columns["cidcargonom"].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_ActualizarDetalle(int _P_Int_IncDistrib)
        {

            using (DataContext._Dat_CntxVistasDataContext _Dat_CntxVista = new T3.DataContext._Dat_CntxVistasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex))
            {
                _Dg_Detalle.Rows.Clear();
                var _Var_Datos = from Campos in _Dat_CntxVista.VST_INC_DISTRIBU_D
                                 where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidincdistribu == _P_Int_IncDistrib
                                 select new { Proveedor = Campos.c_nomb_abreviado, Línea = Campos.cname, Año = Campos.cano, Mes = Campos.cmes, Comisión = Campos.ccomision, Campos.cidincdistribud, Campos.cproveedor, Campos.cgrupo };
                if (_Cmb_Proveedor.SelectedIndex > 0)
                { _Var_Datos = _Var_Datos.Where(c => c.cproveedor == Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim()); }
                if (_Cmb_Linea.SelectedIndex > 0)
                { _Var_Datos = _Var_Datos.Where(c => c.cgrupo == Convert.ToString(_Cmb_Linea.SelectedValue).Trim()); }
                if (_Cmb_Ano.SelectedIndex > 0)
                { _Var_Datos = _Var_Datos.Where(c => c.Año == Convert.ToInt32(_Cmb_Ano.Text)); }
                if (_Cmb_Mes.SelectedIndex > 0)
                { _Var_Datos = _Var_Datos.Where(c => c.Mes == Convert.ToInt32(_Cmb_Mes.Text)); }

                _Var_Datos.ToList().ForEach(x =>
                {
                    _Dg_Detalle.Rows.Add(new object[] { x.Proveedor, x.Línea, x.Año, x.Mes, x.Comisión, x.cidincdistribud, x.cproveedor, x.cgrupo });
                }
                );
                _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
        private void _Mtd_PrepararGridParaEdicionGer(string _P_Str_IncDistrib)
        {
            _Dg_Detalle.Rows.Clear();
            if (_P_Str_IncDistrib.Trim().Length == 0)
            { _P_Str_IncDistrib = "0"; }
            string _Str_Cadena = "SELECT DISTINCT c_nomb_abreviado AS Proveedor, cname AS Línea, cano AS Año, cmes AS Mes, ccomision AS Comisión,cidincdistribud, cproveedor, cgrupo FROM VST_INC_DISTRIBU_D WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cano ='" + Convert.ToInt32(_Cmb_Ano.Text) + "' AND cmes ='" + Convert.ToInt32(_Cmb_Mes.Text) + "' AND cidincdistribu='" + _P_Str_IncDistrib + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                _Str_Cadena = "SELECT DISTINCT c_nomb_abreviado AS Proveedor, cname AS Línea, cano AS Año, cmes AS Mes, 0 AS Comisión, 0 AS  cidincdistribud, cproveedor, cgrupo FROM VST_INC_DISTRIBU_D WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cano ='" + Convert.ToInt32(_Cmb_Ano.Text) + "' AND cmes ='" + Convert.ToInt32(_Cmb_Mes.Text) + "' AND cvendedor=1";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            }
            _Ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(x =>
            {
                _Dg_Detalle.Rows.Add(new object[] { x[0], x[1], x[2], x[3], x[4], x[5], x[6], x[7] });
            }
            );
            _Dg_Detalle.Columns["Comision"].ReadOnly = false;
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_DesHabilitar_Pnl_Detalle_1()
        {
            _Cmb_Cargo_D.Enabled = false;
            _Cmb_Grupo_D.Enabled = false;
            _Num_cporcpromedio.Enabled = false;
            _Num_cporcindividual.Enabled = false;
            _Num_PorcVolumentVtasMin.Enabled = false;            
        }
        private void _Mtd_DesHabilitar_Pnl_Detalle_2()
        {
            _Cmb_Proveedor.Enabled = false;
            _Cmb_Linea.Enabled = false;
            _Cmb_Ano.Enabled = false;
            _Cmb_Mes.Enabled = false;
            _Txt_ccomision.Enabled = false;
            _Bt_Agregar.Enabled = false;
            _Bt_Eliminar.Enabled = false;
            _Bt_Guardar.Enabled = false;
            _Bt_Cancelar.Enabled = false;
        }
        private void _Mtd_IniPnl_Detalle_1()
        {
            _Txt_cidincdistribu.Text = "";
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarCargos(_Cmb_Cargo_D);
            Cursor = Cursors.Default;
            _Cmb_Grupo_D.DataSource = null;
            _Num_cporcpromedio.Value = 0;
            _Num_cporcindividual.Value = 0;
            _Num_PorcVolumentVtasMin.Value = 0;
            _Lbl_PorcVolumentVtasMin.Enabled = false;
        }
        private void _Mtd_IniPnl_Detalle_2()
        {
            _Cmb_Proveedor.DataSource = null;
            _Cmb_Linea.DataSource = null;
            _Cmb_Ano.Items.Clear();
            _Cmb_Mes.Items.Clear();
            _Txt_ccomision.Text = "";
        }
        private void _Mtd_Ini()
        {
            _Mtd_DesHabilitar_Pnl_Detalle_1();
            _Mtd_DesHabilitar_Pnl_Detalle_2();
            _Mtd_IniPnl_Detalle_1();
            _Mtd_IniPnl_Detalle_2();
            _Pnl_Detalle_2.Enabled = false;
            _Dg_Detalle.Rows.Clear();
        }
        public void _Mtd_Nuevo()
        {
            _Mtd_Ini();
            _Er_Error.Dispose();
            _Cmb_Cargo_D.Enabled = true;
            _Pnl_Detalle_2.Enabled = true;
            _Tb_Tab.SelectedIndex = 1;
            _Cmb_Cargo_D.Focus();
        }
        private bool _Mtd_Existe(int _P_Int_GrupoInc)
        {
            return (from Campos in Program._Dat_Tablas.TINCDISTRIBU
                    where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == _P_Int_GrupoInc
                    select Campos.cidgrupincentivar).Count() > 0;
        }
        private int _Mtd_InsertarEditarMaestra(int _P_Int_GrupoInc)
        {
            DataContext.TINCDISTRIBU _T_TUNITRIBUT;
            bool _Bol_Existe = _Mtd_Existe(_P_Int_GrupoInc);
            if (_Bol_Existe)
            { _T_TUNITRIBUT = Program._Dat_Tablas.TINCDISTRIBU.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidgrupincentivar == _P_Int_GrupoInc); }
            else
            {
                _Cmb_Cargo_D.Enabled = false; _Cmb_Grupo_D.Enabled = false;
                _T_TUNITRIBUT = new T3.DataContext.TINCDISTRIBU();
                _T_TUNITRIBUT.cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp);
                _T_TUNITRIBUT.ccompany = Frm_Padre._Str_Comp;
                _T_TUNITRIBUT.cidincdistribu = new _Cls_Consecutivos()._Mtd_IncDis();
                _T_TUNITRIBUT.cidgrupincentivar = _P_Int_GrupoInc;
            }
            _T_TUNITRIBUT.cporcpromedio = _Num_cporcpromedio.Value;
            _T_TUNITRIBUT.cporcindividual = _Num_cporcindividual.Value;
            _T_TUNITRIBUT.cporcvolventas = _Num_PorcVolumentVtasMin.Value;
            if (_Bol_Existe)
            {
                _T_TUNITRIBUT.cdateupd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _T_TUNITRIBUT.cuserupd = Frm_Padre._Str_Use;
            }
            else
            {
                _T_TUNITRIBUT.cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _T_TUNITRIBUT.cuseradd = Frm_Padre._Str_Use;
                Program._Dat_Tablas.TINCDISTRIBU.InsertOnSubmit(_T_TUNITRIBUT);
            }
            Program._Dat_Tablas.SubmitChanges();
            _Txt_cidincdistribu.Text = _T_TUNITRIBUT.cidincdistribu.ToString();
            return _T_TUNITRIBUT.cidincdistribu;
        }
        private void _Mtd_InsertarRegistros(int _P_Int_GrupoInc,bool _P_Bol_Vendedor)
        {
            int _P_Int_IncDistrib = _Mtd_InsertarEditarMaestra(_P_Int_GrupoInc);
            //------------------------------------
            if (_P_Bol_Vendedor)
            {
                DataContext.TINCDISTRIBUD _T_TINCDISTRIBUD = new T3.DataContext.TINCDISTRIBUD()
                {
                    cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp),
                    ccompany = Frm_Padre._Str_Comp,
                    cidincdistribu = _P_Int_IncDistrib,
                    cidincdistribud = new _Cls_Consecutivos()._Mtd_IncDisDetalle(_P_Int_IncDistrib),
                    cproveedor = Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim(),
                    cgrupo = Convert.ToString(_Cmb_Linea.SelectedValue).Trim(),
                    cano = Convert.ToInt32(_Cmb_Ano.Text),
                    cmes = Convert.ToInt32(_Cmb_Mes.Text),
                    ccomision = Convert.ToDecimal(_Txt_ccomision.Text),
                    cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ(),
                    cuseradd = Frm_Padre._Str_Use
                };
                Program._Dat_Tablas.TINCDISTRIBUD.InsertOnSubmit(_T_TINCDISTRIBUD);
                //------------------------------------
                Program._Dat_Tablas.SubmitChanges();
            }
            else
            {
                _Dg_Detalle.Rows.Cast<DataGridViewRow>().ToList().ForEach(x =>
                {
                    DataContext.TINCDISTRIBUD _T_TINCDISTRIBUD = Program._Dat_Tablas.TINCDISTRIBUD.Where(y => y.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & y.ccompany == Frm_Padre._Str_Comp & y.cidincdistribu == _P_Int_IncDistrib & y.cidincdistribud == Convert.ToInt32(x.Cells["cidincdistribud"].Value)).SingleOrDefault();
                    if (_T_TINCDISTRIBUD != null)
                    {
                        _T_TINCDISTRIBUD.ccomision = Convert.ToDecimal(x.Cells["Comision"].Value);
                    }
                    else
                    {
                        _T_TINCDISTRIBUD = new T3.DataContext.TINCDISTRIBUD()
                        {
                            cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp),
                            ccompany = Frm_Padre._Str_Comp,
                            cidincdistribu = _P_Int_IncDistrib,
                            cidincdistribud = new _Cls_Consecutivos()._Mtd_IncDisDetalle(_P_Int_IncDistrib),
                            cproveedor = Convert.ToString(x.Cells["cproveedor"].Value),
                            cgrupo = Convert.ToString(x.Cells["cgrupo"].Value),
                            cano = Convert.ToInt32(_Cmb_Ano.Text),
                            cmes = Convert.ToInt32(_Cmb_Mes.Text),
                            ccomision = Convert.ToDecimal(x.Cells["Comision"].Value),
                            cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ(),
                            cuseradd = Frm_Padre._Str_Use
                        };
                        Program._Dat_Tablas.TINCDISTRIBUD.InsertOnSubmit(_T_TINCDISTRIBUD);
                    }
                    //------------------------------------
                    Program._Dat_Tablas.SubmitChanges();
                });
            }
        }
        private void _Mtd_GuardarDetalleGte()
        {
            using (DataContext._Dat_CntxTablasDataContext _Dat_CntxTabla = new T3.DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex))
            {
                using (DataContext._Dat_CntxVistasDataContext _Dat_Cntx = new T3.DataContext._Dat_CntxVistasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex))
                {
                    if (_Txt_GerA.Enabled)
                    {
                        var _Var_cidincdistribu = _Dat_Cntx.VST_INC_DISTRIBU_GTE.Where(x => x.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & x.ccompany == Frm_Padre._Str_Comp & x.cgerarea == 1).SingleOrDefault();
                        if (_Var_cidincdistribu != null)
                        {
                            DataContext.TINCDISTRIBUD _T_TINCDISTRIBUD = new T3.DataContext.TINCDISTRIBUD()
                            {
                                cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp),
                                ccompany = Frm_Padre._Str_Comp,
                                cidincdistribu = _Var_cidincdistribu.cidincdistribu,
                                cidincdistribud = new _Cls_Consecutivos()._Mtd_IncDisDetalle(_Var_cidincdistribu.cidincdistribu),
                                cproveedor = Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim(),
                                cgrupo = Convert.ToString(_Cmb_Linea.SelectedValue).Trim(),
                                cano = Convert.ToInt32(_Cmb_Ano.Text),
                                cmes = Convert.ToInt32(_Cmb_Mes.Text),
                                ccomision = Convert.ToDecimal(_Txt_GerA.Text),
                                cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ(),
                                cuseradd = Frm_Padre._Str_Use
                            };
                            _Dat_CntxTabla.TINCDISTRIBUD.InsertOnSubmit(_T_TINCDISTRIBUD);
                            _Dat_CntxTabla.SubmitChanges();
                        }
                    }
                    if (_Txt_GerV.Enabled)
                    {
                        var _Var_cidincdistribu = _Dat_Cntx.VST_INC_DISTRIBU_GTE.Where(x => x.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & x.ccompany == Frm_Padre._Str_Comp & x.cgventas == 1).SingleOrDefault();
                        if (_Var_cidincdistribu != null)
                        {
                            DataContext.TINCDISTRIBUD _T_TINCDISTRIBUD = new T3.DataContext.TINCDISTRIBUD()
                            {
                                cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp),
                                ccompany = Frm_Padre._Str_Comp,
                                cidincdistribu = _Var_cidincdistribu.cidincdistribu,
                                cidincdistribud = new _Cls_Consecutivos()._Mtd_IncDisDetalle(_Var_cidincdistribu.cidincdistribu),
                                cproveedor = Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim(),
                                cgrupo = Convert.ToString(_Cmb_Linea.SelectedValue).Trim(),
                                cano = Convert.ToInt32(_Cmb_Ano.Text),
                                cmes = Convert.ToInt32(_Cmb_Mes.Text),
                                ccomision = Convert.ToDecimal(_Txt_GerV.Text),
                                cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ(),
                                cuseradd = Frm_Padre._Str_Use
                            };
                            _Dat_CntxTabla.TINCDISTRIBUD.InsertOnSubmit(_T_TINCDISTRIBUD);
                            _Dat_CntxTabla.SubmitChanges();
                        }
                    }
                    if (_Txt_GerC.Enabled)
                    {
                        var _Var_cidincdistribu = _Dat_Cntx.VST_INC_DISTRIBU_GTE.Where(x => x.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & x.ccompany == Frm_Padre._Str_Comp & x.cgercomer == 1).SingleOrDefault();
                        if (_Var_cidincdistribu != null)
                        {
                            DataContext.TINCDISTRIBUD _T_TINCDISTRIBUD = new T3.DataContext.TINCDISTRIBUD()
                            {
                                cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp),
                                ccompany = Frm_Padre._Str_Comp,
                                cidincdistribu = _Var_cidincdistribu.cidincdistribu,
                                cidincdistribud = new _Cls_Consecutivos()._Mtd_IncDisDetalle(_Var_cidincdistribu.cidincdistribu),
                                cproveedor = Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim(),
                                cgrupo = Convert.ToString(_Cmb_Linea.SelectedValue).Trim(),
                                cano = Convert.ToInt32(_Cmb_Ano.Text),
                                cmes = Convert.ToInt32(_Cmb_Mes.Text),
                                ccomision = Convert.ToDecimal(_Txt_GerC.Text),
                                cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ(),
                                cuseradd = Frm_Padre._Str_Use
                            };
                            _Dat_CntxTabla.TINCDISTRIBUD.InsertOnSubmit(_T_TINCDISTRIBUD);
                            _Dat_CntxTabla.SubmitChanges();
                        }
                    }
                }
            }
        }
        private void _Mtd_CargarFormulario(int _P_Int_GrupoInc, string _P_Str_Cargo)
        {
            var _Var_Datos = (from Campos in Program._Dat_Tablas.TINCDISTRIBU
                              where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == _P_Int_GrupoInc
                              select Campos).Single();
            _Txt_cidincdistribu.Text = _Var_Datos.cidincdistribu.ToString();
            _Cmb_Cargo_D.SelectedIndexChanged -= new EventHandler(_Cmb_Cargo_D_SelectedIndexChanged);
            _Cmb_Cargo_D.SelectedValue = _P_Str_Cargo;
            _Cmb_Cargo_D.SelectedIndexChanged += new EventHandler(_Cmb_Cargo_D_SelectedIndexChanged);
            _Mtd_CargarGrupos(_Cmb_Grupo_D, _Cmb_Cargo_D, true);
            _Cmb_Grupo_D.SelectedValue = _P_Int_GrupoInc.ToString();
            _Num_cporcpromedio.Value = Convert.ToDecimal(_Var_Datos.cporcpromedio);
            _Num_cporcindividual.Value = Convert.ToDecimal(_Var_Datos.cporcindividual);
            _Mtd_HabilitarPorVentasMin(_P_Str_Cargo);
            _Num_PorcVolumentVtasMin.Value = Convert.ToDecimal(_Var_Datos.cporcvolventas);
        }
        private void _Mtd_EliminarRegistros(int _P_Int_IncDistrib)
        {
            var _Var_Datos = from Campos in _Dg_Detalle.Rows.Cast<DataGridViewRow>()
                             where Campos.Selected
                             select Campos;
            foreach (DataGridViewRow _DgRow in _Var_Datos)
            {
                _Mtd_EliminarRegistrosGtes(Convert.ToInt32(_DgRow.Cells["Ano"].Value), Convert.ToInt32(_DgRow.Cells["Mes"].Value), Convert.ToString(_DgRow.Cells["cproveedor"].Value), Convert.ToString(_DgRow.Cells["cgrupo"].Value));
                Program._Dat_Tablas.TINCDISTRIBUD.DeleteOnSubmit(Program._Dat_Tablas.TINCDISTRIBUD.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincdistribu == _P_Int_IncDistrib & c.cidincdistribud == Convert.ToInt32(_DgRow.Cells["cidincdistribud"].Value)));
            }
            Program._Dat_Tablas.SubmitChanges();
        }
        private void _Mtd_EliminarRegistrosGtes(int _P_Int_Ano, int _P_Int_Mes, string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            using (DataContext._Dat_CntxTablasDataContext _Dat_CntxTabla = new T3.DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex))
            {
                using (DataContext._Dat_CntxVistasDataContext _Dat_CntxVista = new T3.DataContext._Dat_CntxVistasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex))
                {
                    var _Var_cidincdistribu = _Dat_CntxVista.VST_INC_DISTRIBU_GTE.Where(x => x.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & x.ccompany == Frm_Padre._Str_Comp & x.cgerarea == 1).SingleOrDefault();
                    if (_Var_cidincdistribu != null)
                    {
                        DataContext.TINCDISTRIBUD _T_TINCDISTRIBUD = _Dat_CntxTabla.TINCDISTRIBUD.Where(x => x.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & x.ccompany == Frm_Padre._Str_Comp & x.cidincdistribu == _Var_cidincdistribu.cidincdistribu & x.cano == _P_Int_Ano & x.cmes == _P_Int_Mes & x.cproveedor == _P_Str_Proveedor & x.cgrupo == _P_Str_Grupo).SingleOrDefault();
                        if (_T_TINCDISTRIBUD != null)
                        {
                            _Dat_CntxTabla.TINCDISTRIBUD.DeleteOnSubmit(_T_TINCDISTRIBUD);
                        }
                    }
                    _Var_cidincdistribu = _Dat_CntxVista.VST_INC_DISTRIBU_GTE.Where(x => x.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & x.ccompany == Frm_Padre._Str_Comp & x.cgventas == 1).SingleOrDefault();
                    if (_Var_cidincdistribu != null)
                    {
                        DataContext.TINCDISTRIBUD _T_TINCDISTRIBUD = _Dat_CntxTabla.TINCDISTRIBUD.Where(x => x.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & x.ccompany == Frm_Padre._Str_Comp & x.cidincdistribu == _Var_cidincdistribu.cidincdistribu & x.cano == _P_Int_Ano & x.cmes == _P_Int_Mes & x.cproveedor == _P_Str_Proveedor & x.cgrupo == _P_Str_Grupo).SingleOrDefault();
                        if (_T_TINCDISTRIBUD != null)
                        {
                            _Dat_CntxTabla.TINCDISTRIBUD.DeleteOnSubmit(_T_TINCDISTRIBUD);
                        }
                    }
                    _Var_cidincdistribu = _Dat_CntxVista.VST_INC_DISTRIBU_GTE.Where(x => x.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & x.ccompany == Frm_Padre._Str_Comp & x.cgercomer == 1).SingleOrDefault();
                    if (_Var_cidincdistribu != null)
                    {
                        DataContext.TINCDISTRIBUD _T_TINCDISTRIBUD = _Dat_CntxTabla.TINCDISTRIBUD.Where(x => x.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & x.ccompany == Frm_Padre._Str_Comp & x.cidincdistribu == _Var_cidincdistribu.cidincdistribu & x.cano == _P_Int_Ano & x.cmes == _P_Int_Mes & x.cproveedor == _P_Str_Proveedor & x.cgrupo == _P_Str_Grupo).SingleOrDefault();
                        if (_T_TINCDISTRIBUD != null)
                        {
                            _Dat_CntxTabla.TINCDISTRIBUD.DeleteOnSubmit(_T_TINCDISTRIBUD);
                        }
                    }
                }
                _Dat_CntxTabla.SubmitChanges();
            }
        }
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            if (_Cmb_Cargo_D.SelectedIndex > 0 & _Cmb_Grupo_D.SelectedIndex > 0 & _Num_cporcpromedio.Value > 0 & _Num_cporcindividual.Value > 0)
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
                    if (_Mtd_TipoCargo(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 'G' & _Dg_Detalle.RowCount > 0)
                    {
                        _Dg_Detalle.EndEdit();
                        _Mtd_GuardarDetalle(false);
                    }
                    MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor = Cursors.WaitCursor;
                    _Mtd_Actualizar();
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                if (_Cmb_Cargo_D.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Cargo_D, "Información requerida!!!"); }
                if (_Cmb_Grupo_D.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Grupo_D, "Información requerida!!!"); }
                if (_Num_cporcindividual.Value == 0) { _Er_Error.SetError(_Num_cporcindividual, "Información requerida!!!"); }
                if (_Num_cporcpromedio.Value == 0) { _Er_Error.SetError(_Num_cporcpromedio, "Información requerida!!!"); }
                if (_Num_cporcindividual.Value == 0) { _Er_Error.SetError(_Num_cporcindividual, "Información requerida!!!"); }
            }
            return false;
        }
        public bool _Mtd_Editar()
        {
            return _Mtd_Guardar();
        }
        public void _Mtd_Habilitar()
        {
            _Num_cporcpromedio.Enabled = true;
            _Num_cporcindividual.Enabled = true;
            _Pnl_Detalle_2.Enabled = true;
            _Bt_Eliminar.Enabled = _Dg_Detalle.RowCount > 0 & _Bol_UsuarioLider & _Mtd_TipoCargo(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 'A';
            _Bt_Agregar.Enabled = _Bol_UsuarioLider & _Cmb_Grupo_D.SelectedIndex > 0;
            _Mtd_HabilitarPorVentasMin(Convert.ToString(_Cmb_Cargo_D.SelectedValue).Trim());
            _Dg_Detalle.Columns["Comision"].ReadOnly = _Mtd_TipoCargo(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 'A';
            _Bt_Guardar.Enabled = _Mtd_TipoCargo(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 'G' & _Bt_Agregar.Enabled;
        }
        private void _Mtd_EliminarRegistro(int _P_Int_IncDistrib, int _P_Int_IncDistrib_D)
        {
            Program._Dat_Tablas.TINCDISTRIBUD.DeleteOnSubmit(Program._Dat_Tablas.TINCDISTRIBUD.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidincdistribu == _P_Int_IncDistrib & c.cidincdistribud == _P_Int_IncDistrib_D));
            Program._Dat_Tablas.SubmitChanges();
        }
        private void _Mtd_EliminarRegistros()
        {
            var _Var_Datos = from Campos in _Dg_Grid.Rows.Cast<DataGridViewRow>()
                             where Campos.Selected
                             select Campos;
            foreach (DataGridViewRow _DgRow in _Var_Datos)
            {
                var _Var_cidincdistribu = (from Campos in Program._Dat_Tablas.TINCDISTRIBU
                                  where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidgrupincentivar == Convert.ToInt32(_DgRow.Cells["Grupo_Insentivo"].Value)
                                  select Campos.cidincdistribu).Single();
                //--------------------------------------------------------------------
                var _Var_TINCDISTRIBUD = from Campos in Program._Dat_Tablas.TINCDISTRIBUD where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidincdistribu == _Var_cidincdistribu select Campos;
                if (_Var_TINCDISTRIBUD.Count() > 0) { Program._Dat_Tablas.TINCDISTRIBUD.DeleteAllOnSubmit(_Var_TINCDISTRIBUD); }
                //--------------------------------------------------------------------
                Program._Dat_Tablas.TINCDISTRIBU.DeleteOnSubmit(Program._Dat_Tablas.TINCDISTRIBU.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidgrupincentivar == Convert.ToInt32(_DgRow.Cells["Grupo_Insentivo"].Value)));
            }
            Program._Dat_Tablas.SubmitChanges();
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
        private void Frm_IncDistribucion_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            if (_Bol_PermisoConfirmado)
            {
                _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
                _Pnl_Ger.Left = (this.Width / 2) - (_Pnl_Ger.Width / 2);
                _Pnl_Ger.Top = (this.Height / 2) - (_Pnl_Ger.Height / 2);
                Cursor = Cursors.WaitCursor;
                _Mtd_Color_Estandar(this);
                _Mtd_CargarCargos(_Cmb_Cargo);
                _Mtd_Actualizar();
                Cursor = Cursors.Default;
            }
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

        private void _Cmb_Ano_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Ano.SelectedIndex > 0)
            { Cursor = Cursors.WaitCursor; _Mtd_CargarMeses(Convert.ToInt32(_Cmb_Ano.Text)); Cursor = Cursors.Default; _Cmb_Mes.Enabled = true; }
            else
            { _Cmb_Mes.Items.Clear(); _Cmb_Mes.Enabled = false; }
            _Txt_ccomision.Enabled =_Bol_UsuarioLider & _Cmb_Proveedor.SelectedIndex > 0 & _Cmb_Linea.SelectedIndex > 0 & _Cmb_Ano.SelectedIndex > 0 & _Cmb_Mes.SelectedIndex > 0;
            _Txt_ccomision.Text = "";
            _Dg_Detalle.Rows.Clear();
        }

        private void Frm_IncDistribucion_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_DIS");
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = !_Num_cporcindividual.Enabled & _Num_cporcindividual.Value > 0 & _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_DIS");
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _Tb_Tab.SelectedIndex == 1 & !((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled & _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_DIS");
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
        }

        private void Frm_IncDistribucion_FormClosing(object sender, FormClosingEventArgs e)
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
                e.Cancel = !_Cmb_Cargo_D.Enabled;
            }
            else
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                _Mtd_Ini();
            }
        }

        private void _Cmb_Proveedor_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Cargar_Proveedor(Convert.ToString(_Cmb_Grupo_D.SelectedValue).Trim());
            Cursor = Cursors.Default;
        }

        private void _Cmb_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Proveedor.SelectedIndex > 0)
            { Cursor = Cursors.WaitCursor; _Mtd_Cargar_Linea(Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim()); Cursor = Cursors.Default; _Cmb_Linea.Enabled = true; }
            else
            { _Cmb_Linea.DataSource = null; _Cmb_Linea.Enabled = false; }
        }

        private void _Cmb_Grupo_D_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            _Num_cporcpromedio.Enabled = _Cmb_Grupo_D.SelectedIndex > 0; 
            _Num_cporcindividual.Enabled = _Cmb_Grupo_D.SelectedIndex > 0;
            _Num_cporcpromedio.Value = 0; _Num_cporcindividual.Value = 0;
            if (_Cmb_Grupo_D.SelectedIndex <= 0)
            { _Mtd_DesHabilitar_Pnl_Detalle_2(); _Mtd_IniPnl_Detalle_2(); }
            _Bt_Agregar.Enabled = _Bol_UsuarioLider & _Cmb_Grupo_D.SelectedIndex > 0 & ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled;
            _Dg_Detalle.Rows.Clear();
        }

        private void _Bt_Agregar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            _Mtd_IniPnl_Detalle_2();
            _Mtd_DesHabilitar_Pnl_Detalle_2();
            _Bt_Eliminar.Enabled = _Dg_Detalle.RowCount > 0 & _Mtd_TipoCargo(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 'A';
            if (_Num_cporcpromedio.Value > 0 & _Num_cporcindividual.Value > 0)
            {
                _Mtd_Cargar_Proveedor(Convert.ToString(_Cmb_Grupo_D.SelectedValue).Trim());
                _Cmb_Proveedor.Enabled = _Mtd_TipoCargo(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 'A'; 
                _Cmb_Proveedor.Focus(); 
                _Bt_Cancelar.Enabled = true;
                _Mtd_CargarAños(); 
                _Cmb_Ano.Enabled = true;
            }
            else
            {
                _Bt_Agregar.Enabled = true;
                if (_Num_cporcpromedio.Value == 0)
                { _Er_Error.SetError(_Num_cporcpromedio, "Información requerida!!!"); }
                if (_Num_cporcindividual.Value == 0)
                { _Er_Error.SetError(_Num_cporcindividual, "Información requerida!!!"); }
            }
        }

        private void _Cmb_Mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Txt_ccomision.Enabled = _Bol_UsuarioLider & _Cmb_Proveedor.SelectedIndex > 0 & _Cmb_Linea.SelectedIndex > 0 & _Cmb_Ano.SelectedIndex > 0 & _Cmb_Mes.SelectedIndex > 0;
            _Txt_ccomision.Text = "";
            _Dg_Detalle.Rows.Clear();
            if (_Cmb_Mes.SelectedIndex > 0 & _Mtd_TipoCargo(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 'G' & ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled & !_Bt_Agregar.Enabled)
            {
                _Mtd_PrepararGridParaEdicionGer(_Txt_cidincdistribu.Text);
                _Bt_Guardar.Enabled = true;
            }
        }

        private void _Cmb_Ano_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarAños();
            Cursor = Cursors.Default;
        }

        private void _Cmb_Mes_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarMeses(Convert.ToInt32(_Cmb_Ano.Text));
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
            _Txt_ccomision.Enabled =_Bol_UsuarioLider & _Cmb_Proveedor.SelectedIndex > 0 & _Cmb_Linea.SelectedIndex > 0 & _Cmb_Ano.SelectedIndex > 0 & _Cmb_Mes.SelectedIndex > 0;
            _Txt_ccomision.Text = "";
            _Dg_Detalle.Rows.Clear();
        }

        private void _Txt_ccomision_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_ccomision.Text))
            { _Txt_ccomision.Text = ""; }
            _Bt_Guardar.Enabled = _Mtd_VerifContTextBoxNumeric(_Txt_ccomision);
        }

        private void _Txt_ccomision_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_ccomision, e, 15, 2);
        }

        private void _Cmb_Cargo_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarCargos(_Cmb_Cargo);
            Cursor = Cursors.Default;
        }

        private void Frm_IncDistribucion_Shown(object sender, EventArgs e)
        {
            if (!_Bol_PermisoConfirmado)
            { MessageBox.Show("Su usuario no tiene permisos para entrar en este módulo", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close(); }
            else
            { _Cmb_Cargo.Focus(); }
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
            Cursor = Cursors.Default;
        }
        private bool _Mtd_MostrarPanelGer()
        {
            _Txt_GerA.Enabled = false;
            _Txt_GerV.Enabled = false;
            _Txt_GerC.Enabled = false;
            bool _Bol_MostrarPanelGer = false;
            using (DataContext._Dat_CntxVistasDataContext _Dat_Cntx = new T3.DataContext._Dat_CntxVistasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex))
            {
                var _Var_Datos = from campos in _Dat_Cntx.VST_INC_DISTRIBU_D where campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & campos.ccompany == Frm_Padre._Str_Comp & campos.cano == Convert.ToInt32(_Cmb_Ano.Text) & campos.cmes == Convert.ToInt32(_Cmb_Mes.Text) & campos.cvendedor == 0 select campos;
                //----------------
                var _Var_Temp = _Var_Datos.Where(x => x.cgerarea == 1 & x.cproveedor == Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim() & x.cgrupo == Convert.ToString(_Cmb_Linea.SelectedValue).Trim());
                if (_Var_Temp.Count() > 0)
                {
                    _Txt_GerA.Text = _Var_Temp.Single().ccomision;
                }
                else
                {
                    _Txt_GerA.Text = "0";
                    if (_Var_Datos.Where(x => x.cgerarea == 1).Count() > 0)
                    {
                        _Txt_GerA.Enabled = true;
                        _Bol_MostrarPanelGer = true;
                    }
                }
                //----------------
                _Var_Temp = _Var_Datos.Where(x => x.cgventas == 1 & x.cproveedor == Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim() & x.cgrupo == Convert.ToString(_Cmb_Linea.SelectedValue).Trim());
                if (_Var_Temp.Count() > 0)
                {
                    _Txt_GerV.Text = _Var_Temp.Single().ccomision;
                }
                else
                {
                    _Txt_GerV.Text = "0";
                    if (_Var_Datos.Where(x => x.cgventas == 1).Count() > 0)
                    {
                        _Txt_GerV.Enabled = true;
                        _Bol_MostrarPanelGer = true;
                    }
                }
                //----------------
                _Var_Temp = _Var_Datos.Where(x => x.cgercomer == 1 & x.cproveedor == Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim() & x.cgrupo == Convert.ToString(_Cmb_Linea.SelectedValue).Trim());
                if (_Var_Temp.Count() > 0)
                {
                    _Txt_GerC.Text = _Var_Temp.Single().ccomision;
                }
                else
                {
                    _Txt_GerC.Text = "0";
                    if (_Var_Datos.Where(x => x.cgercomer == 1).Count() > 0)
                    {
                        _Txt_GerC.Enabled = true;
                        _Bol_MostrarPanelGer = true;
                    }
                }
                //----------------
            }
            _Pnl_Ger.Visible = _Bol_MostrarPanelGer;
            return _Bol_MostrarPanelGer;
        }
        private void _Bt_Guardar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Num_cporcpromedio.Value > 0 & _Num_cporcindividual.Value > 0)
            {
                if (_Mtd_TipoCargo(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 'A')
                {
                    bool _Bol_CompletarOperacion = true;
                    int _Int_IncDistrib_D = _Mtd_ValidarGuardar(_Txt_cidincdistribu.Text.Trim(), Convert.ToString(_Cmb_Proveedor.SelectedValue), Convert.ToString(_Cmb_Linea.SelectedValue), Convert.ToInt32(_Cmb_Ano.Text), Convert.ToInt32(_Cmb_Mes.Text));
                    if (_Int_IncDistrib_D > 0)
                    {
                        if (MessageBox.Show("Ya existe un parámetro igual al que intenta registrar.\n¿Desea reemplazar el parámetro existente por este otro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _Mtd_EliminarRegistro(Convert.ToInt32(_Txt_cidincdistribu.Text), _Int_IncDistrib_D);
                        }
                        else
                        { _Bol_CompletarOperacion = false; }
                    }
                    if (_Bol_CompletarOperacion)
                    {
                        if (!_Mtd_MostrarPanelGer())
                        {
                            _Mtd_GuardarDetalle(true);
                        }
                    }
                }
                else
                {
                    if (_Dg_Detalle.RowCount > 0)
                    {
                        _Mtd_GuardarDetalle(false);
                        MessageBox.Show("Los datos han sido actualizados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Bt_Guardar.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Debe existir un por lo menos un detalle para guardar.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                if (_Num_cporcpromedio.Value == 0) { _Er_Error.SetError(_Num_cporcpromedio, "Información requerida!!!"); }
                if (_Num_cporcindividual.Value == 0) { _Er_Error.SetError(_Num_cporcindividual, "Información requerida!!!"); }
            }
        }

        private void _Mtd_GuardarDetalle(bool _P_Bol_Ger)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_InsertarRegistros(Convert.ToInt32(_Cmb_Grupo_D.SelectedValue), _P_Bol_Ger);
            _Mtd_IniPnl_Detalle_2();
            _Mtd_DesHabilitar_Pnl_Detalle_2();
            _Mtd_Actualizar();
            _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_cidincdistribu.Text));
            _Bt_Agregar.Enabled = true;
            Cursor = Cursors.Default;
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count == 1)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_IniPnl_Detalle_1();
                _Mtd_CargarFormulario(Convert.ToInt32(_Dg_Grid.Rows[e.RowIndex].Cells["Grupo_Insentivo"].Value), Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["cidcargonom"].Value));
                _Mtd_DesHabilitar_Pnl_Detalle_1();
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_DIS");
                _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                _Tb_Tab.SelectedIndex = 1;
                _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                Cursor = Cursors.Default;
                _Pnl_Detalle_2.Enabled = true;
                _Mtd_Cargar_Proveedor(Convert.ToString(_Cmb_Grupo_D.SelectedValue).Trim());
                _Cmb_Proveedor.Enabled = _Mtd_TipoCargo(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 'A';
                _Mtd_CargarAños();
                _Cmb_Ano.Enabled = true;
                _Dg_Detalle.RowsAdded -= new DataGridViewRowsAddedEventHandler(_Dg_Detalle_RowsAdded);
                _Dg_Detalle.RowsRemoved -= new DataGridViewRowsRemovedEventHandler(_Dg_Detalle_RowsRemoved);
                Cursor = Cursors.WaitCursor;
                _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_cidincdistribu.Text));
                Cursor = Cursors.Default;
                _Dg_Detalle.Columns["Comision"].ReadOnly = true;
                _Dg_Detalle.RowsAdded += new DataGridViewRowsAddedEventHandler(_Dg_Detalle_RowsAdded);
                _Dg_Detalle.RowsRemoved += new DataGridViewRowsRemovedEventHandler(_Dg_Detalle_RowsRemoved);
            }
        }

        private void _Dg_Detalle_DataSourceChanged(object sender, EventArgs e)
        {
            //_Bt_Eliminar.Enabled = _Dg_Detalle.RowCount > 0 & _Bol_UsuarioLider & ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled;
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            _Mtd_IniPnl_Detalle_2();
            _Mtd_DesHabilitar_Pnl_Detalle_2();
            _Bt_Eliminar.Enabled = _Dg_Detalle.RowCount > 0 & _Mtd_TipoCargo(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 'A';
            _Bt_Agregar.Enabled = true;
        }

        private void _Bt_Eliminar_Click(object sender, EventArgs e)
        {
            if (_Dg_Detalle.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Esta seguro de elimiar los registros seleccionados?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_EliminarRegistros(Convert.ToInt32(_Txt_cidincdistribu.Text));
                    _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_cidincdistribu.Text));
                    Cursor = Cursors.Default;
                }
            }
            else
            { MessageBox.Show("Debe seleccionar los registros que desea eliminar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
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
            e.Cancel = _Dg_Grid.SelectedRows.Count == 0 | !(_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_C_E_INCT_DIS"));
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de eliminar los registros selecionados", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                _Pnl_Clave.Visible = true;
            }
        }

        private void _Bt_Filtrar_Click(object sender, EventArgs e)
        {
            if (_Txt_cidincdistribu.Text.Trim().Length > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_cidincdistribu.Text));
                Cursor = Cursors.Default;
            }
            else
            { MessageBox.Show("Aún no existen registros", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Bt_Copiar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_IncCopiar _Frm = new Frm_IncCopiar(1);
            Cursor = Cursors.Default;
            if (_Frm.ShowDialog() == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Actualizar();
                Cursor = Cursors.Default;
            }
        }
        bool _Bol_Boleano = false;
        private void _Dg_Detalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!_Bol_Boleano)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
                _Bol_Boleano = true;
            }
        }
        void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_Dg_Detalle.Columns[_Dg_Detalle.CurrentCell.ColumnIndex].Name == "Comision")
            {
                _Cls_VariosMetodos._Mtd_Valida_Numeros((TextBox)sender, e, 15, 2);
            }
        }
        string _Str_Temp_Monto = "";
        private void _Dg_Detalle_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (_Dg_Detalle.Columns[e.ColumnIndex].Name == "Comision")
            {
                if (_Dg_Detalle.Rows[e.RowIndex].Cells["Comision"].Value != null)
                {
                    _Str_Temp_Monto = Convert.ToString(_Dg_Detalle.Rows[e.RowIndex].Cells["Comision"].Value).Trim();
                }
            }
        }

        private void _Dg_Detalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_Dg_Detalle.Columns[e.ColumnIndex].Name == "Comision")
            {
                if (_Dg_Detalle.Rows[e.RowIndex].Cells["Comision"].Value != null)
                {
                    double _Dbl_MontoTemp = 0;
                    if (!double.TryParse(Convert.ToString(_Dg_Detalle.Rows[e.RowIndex].Cells["Comision"].Value).Trim(), out _Dbl_MontoTemp))
                    {
                        _Dg_Detalle.Rows[e.RowIndex].Cells["Comision"].Value = _Str_Temp_Monto;
                    }
                }
                else
                { _Dg_Detalle.Rows[e.RowIndex].Cells["Comision"].Value = _Str_Temp_Monto; }
            }
        }

        private void _Dg_Detalle_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            _Bt_Eliminar.Enabled = _Dg_Detalle.RowCount > 0 & _Bol_UsuarioLider & ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled & _Mtd_TipoCargo(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 'A';
        }

        private void _Dg_Detalle_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            _Bt_Eliminar.Enabled = _Dg_Detalle.RowCount > 0 & _Bol_UsuarioLider & ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled & _Mtd_TipoCargo(Convert.ToString(_Cmb_Cargo_D.SelectedValue)) == 'A';
        }

        private void _Pnl_Ger_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Ger.Visible)
            { _Tb_Tab.Enabled = false; }
            else { _Tb_Tab.Enabled = true; }
        }

        private void _Txt_Ger_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(((TextBox)sender).Text))
            { ((TextBox)sender).Text = ""; }
        }

        private void _Txt_Ger_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(((TextBox)sender), e, 15, 2);
        }

        private void _Bt_CancelarGer_Click(object sender, EventArgs e)
        {
            _Pnl_Ger.Visible = false;
        }

        private void _Bt_AceptarGer_Click(object sender, EventArgs e)
        {
            if (_Txt_GerA.Text.Trim().Length == 0) { _Txt_GerA.Text = "0"; }
            if (_Txt_GerV.Text.Trim().Length == 0) { _Txt_GerV.Text = "0"; }
            if (_Txt_GerC.Text.Trim().Length == 0) { _Txt_GerC.Text = "0"; }
            Cursor = Cursors.WaitCursor;
            _Mtd_GuardarDetalleGte();
            Cursor = Cursors.Default;
            _Pnl_Ger.Visible = false;
            _Mtd_GuardarDetalle(true);
        }
    }
}












