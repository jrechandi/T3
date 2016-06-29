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
    public partial class Frm_IncConjunto : Form
    {
        string _Str_GrupoInc = "";
        string _Str_IncMarcf = "";
        string _Str_Canal = "";
        string _Str_Establecimiento = "";
        int _Int_Año = 0;
        int _Int_Mes = 0;
        int _Int_Conjunto = 0;
        Frm_IncMarcaFoco _Frm_IncMarcaFoco;
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_IncConjunto()
        {
            InitializeComponent();
        }
        public Frm_IncConjunto(Frm_IncMarcaFoco _P_Frm_IncMarcaFoco, string _P_Str_GrupoInc, int _P_Int_Conjunto, string _P_Str_Descripcion, string _P_Str_IncMarcf, string _P_Str_Canal, string _P_Str_Establecimiento, int _P_Int_Año, int _P_Int_Mes)
        {
            InitializeComponent();
            _Frm_IncMarcaFoco = _P_Frm_IncMarcaFoco;
            _Str_GrupoInc = _P_Str_GrupoInc;
            _Int_Conjunto = _P_Int_Conjunto;
            _Txt_DesConjunto.Text = _P_Str_Descripcion;
            _Str_IncMarcf = _P_Str_IncMarcf;
            _Str_Canal = _P_Str_Canal;
            _Str_Establecimiento = _P_Str_Establecimiento;
            _Int_Año = _P_Int_Año;
            _Int_Mes = _P_Int_Mes;
            _Num_cporcactivamin.Value = _Mtd_PorcActivacion(_P_Int_Conjunto);
            _Chbox_Proveedores.Checked = true;
            _Mtd_Color_Estandar(this);
            _Mtd_Actualizar();
            _Mtd_Buscar();
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
                    new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco();
                }
            }
        }
        private string _Mtd_ConsultaSql()
        {
            return "SELECT cproducto AS Producto, RTRIM(produc_descrip) + '. ' + produc_descrip_2 AS Descripción FROM TGRUPPROVEE INNER JOIN TGRUPOIV ON TGRUPPROVEE.cgrupovta = TGRUPOIV.cgrupovta AND TGRUPPROVEE.ccompany = TGRUPOIV.ccompany INNER JOIN VST_PRODUCTOS_A ON TGRUPPROVEE.cproveedor = VST_PRODUCTOS_A.cproveedor AND TGRUPOIV.ccompany = VST_PRODUCTOS_A.companyprov WHERE (NOT EXISTS (SELECT cproveedor FROM TFILTROREGIONALP WHERE (VST_PRODUCTOS_A.cproveedor = cproveedor) AND (VST_PRODUCTOS_A.cproducto = cproducto) AND (ccompany = '" + Frm_Padre._Str_Comp + "') AND (cdelete = '0'))) AND (TGRUPOIV.cidgrupincentivar = '" + _Str_GrupoInc + "') and VST_PRODUCTOS_A.cdelete=0 AND VST_PRODUCTOS_A.companyprov='" + Frm_Padre._Str_Comp + "'";
        }
        private void _Mtd_Cargar_Proveedor(string _P_Str_Grupo)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT DISTINCT VST_PRODUCTOS_A.cproveedor, VST_PRODUCTOS_A.c_nomb_abreviado " +
            "FROM TGRUPPROVEE INNER JOIN " +
            "TGRUPOIV ON TGRUPPROVEE.cgrupovta = TGRUPOIV.cgrupovta AND " +
            "TGRUPPROVEE.ccompany = TGRUPOIV.ccompany INNER JOIN " +
            "VST_PRODUCTOS_A ON TGRUPPROVEE.cproveedor = VST_PRODUCTOS_A.cproveedor AND " +
            "TGRUPOIV.ccompany = VST_PRODUCTOS_A.companyprov " +
            "WHERE (NOT EXISTS (SELECT cproveedor FROM TFILTROREGIONALP " +
            "WHERE (VST_PRODUCTOS_A.cproveedor = cproveedor) AND (VST_PRODUCTOS_A.cproducto = cproducto) AND (ccompany = '" + Frm_Padre._Str_Comp + "') AND (cdelete = '0'))) AND (TGRUPOIV.cidgrupincentivar = '" + _P_Str_Grupo + "') and VST_PRODUCTOS_A.cdelete=0 AND VST_PRODUCTOS_A.companyprov='" + Frm_Padre._Str_Comp + "' ORDER BY VST_PRODUCTOS_A.c_nomb_abreviado";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Proveedor, _Str_Cadena);
            Cursor = Cursors.Default;
        }
        private void _Mtd_Cargar_Grupo(string _P_Str_Proveedor)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT DISTINCT RTRIM(TGRUPPROM.ccodgrupop) AS ccodgrupop, TGRUPPROM.cname " +
            "FROM TGRUPPROM INNER JOIN " +
            "TGRUPPROD ON TGRUPPROM.ccodgrupop = TGRUPPROD.ccodgrupop AND " +
            "TGRUPPROM.cdelete = TGRUPPROD.cdelete INNER JOIN " +
            "TPRODUCTO ON TGRUPPROD.cproveedor = TPRODUCTO.cproveedor AND TGRUPPROD.ccodgrupop = TPRODUCTO.cgrupo " +
            "WHERE NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE TGRUPPROD.cproveedor=TFILTROREGIONALP.cproveedor AND TPRODUCTO.cproducto=TFILTROREGIONALP.cproducto AND TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' AND TFILTROREGIONALP.cdelete='0') " +
            "AND (TGRUPPROD.cproveedor = '" + _P_Str_Proveedor + "') AND (TGRUPPROM.cdelete = 0) AND (TPRODUCTO.cdelete=0) ORDER BY TGRUPPROM.cname";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Grupo, _Str_Cadena);
            Cursor = Cursors.Default;
        }
        private void _Mtd_Cargar_Subgrupo(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT DISTINCT RTRIM(TSUBGRUPOM.ccodsubgrup) AS ccodsubgrup, RTRIM(TSUBGRUPOM.cname) AS cnamesub " +
            "FROM TSUBGRUPOM INNER JOIN " +
            "TSUBGRUPOD ON TSUBGRUPOM.ccodsubgrup = TSUBGRUPOD.ccodsubgrup AND " +
            "TSUBGRUPOM.cdelete = TSUBGRUPOD.cdelete INNER JOIN " +
            "TPRODUCTO ON TSUBGRUPOD.cproveedor = TPRODUCTO.cproveedor AND " +
            "TSUBGRUPOD.ccodsubgrup = TPRODUCTO.csubgrupo AND TSUBGRUPOD.ccodgrupop = TPRODUCTO.cgrupo " +
            "WHERE NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE TPRODUCTO.cproveedor=TFILTROREGIONALP.cproveedor AND TPRODUCTO.cproducto=TFILTROREGIONALP.cproducto AND TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' AND TFILTROREGIONALP.cdelete='0') " +
            "AND (TSUBGRUPOM.cdelete = 0) AND (TSUBGRUPOD.cproveedor = '" + _P_Str_Proveedor + "') AND (TSUBGRUPOD.ccodgrupop = '" + _P_Str_Grupo + "') AND (TPRODUCTO.cdelete=0) ORDER BY cnamesub";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Subgrupo, _Str_Cadena);
            Cursor = Cursors.Default;
        }
        private void _Mtd_Cargar_Marca(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT DISTINCT RTRIM(TMARCASM.cmarca) AS cmarca, RTRIM(TMARCASM.cname) AS cnamemarc " +
            "FROM TMARCASM INNER JOIN " +
            "TMARCAS ON TMARCASM.cmarca = TMARCAS.cmarca INNER JOIN " +
            "TPRODUCTO ON TMARCASM.cmarca = TPRODUCTO.cmarca " +
            "WHERE NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE TPRODUCTO.cproveedor=TFILTROREGIONALP.cproveedor AND TPRODUCTO.cproducto=TFILTROREGIONALP.cproducto AND TPRODUCTO.cmarca=TFILTROREGIONALP.cmarca AND TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' AND TFILTROREGIONALP.cdelete='0') " +
            "AND (TMARCASM.cdelete = 0) AND (TMARCAS.ccodgrupop = '" + _P_Str_Grupo + "') AND (TMARCAS.cproveedor = '" + _P_Str_Proveedor + "') AND (TPRODUCTO.cdelete=0) ORDER BY cnamemarc";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Marca, _Str_Cadena);
            Cursor = Cursors.Default;
        }
        public void _Mtd_Restablecer()
        {
            _Txt_Descripcion.Text = "";
            _Txt_Producto.Text = "";
            _Chbox_Proveedores.Checked = true;
            _Mtd_Cargar_Proveedor(_Str_GrupoInc);
            _Chbox_Grupos.Checked = false;
            _Chbox_Subgrupos.Checked = false;
            _Chbox_Marcas.Checked = false;
            _Dg_ProdBusqueda.DataSource = null;
            _Dg_ProdBusqueda.Columns.Clear();
            _Bt_Marcar.Enabled = false;
            _Bt_Desmarcar.Enabled = false;
            _Bt_Agregar.Enabled = false;
        }

        private string _Mtd_Filtro()
        {
            string _Str_Cadena = "";
            if (_Cmb_Proveedor.SelectedIndex > 0)
            { _Str_Cadena += " AND VST_PRODUCTOS_A.cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "'"; }
            if (_Cmb_Grupo.SelectedIndex > 0)
            { _Str_Cadena += " AND VST_PRODUCTOS_A.cgrupo='" + _Cmb_Grupo.SelectedValue.ToString() + "'"; }
            if (_Cmb_Subgrupo.SelectedIndex > 0)
            { _Str_Cadena += " AND VST_PRODUCTOS_A.csubgrupo='" + _Cmb_Subgrupo.SelectedValue.ToString() + "'"; }
            if (_Cmb_Marca.SelectedIndex > 0)
            { _Str_Cadena += " AND VST_PRODUCTOS_A.cmarca='" + _Cmb_Marca.SelectedValue.ToString() + "'"; }
            if (_Txt_Descripcion.Text.Trim().Length > 0)
            { _Str_Cadena += " AND RTRIM(VST_PRODUCTOS_A.produc_descrip) + '. ' + VST_PRODUCTOS_A.produc_descrip_2 LIKE '%" + _Txt_Descripcion.Text.Trim() + "%'"; }
            return _Str_Cadena;
        }

        private DataSet _Mtd_RetornarDataSet(string _P_Str_ConsultaSql)
        {
            string _Str_Cadena = "SELECT cproducto AS Producto,RTRIM(produc_descrip) + '. ' + produc_descrip_2 AS Descripción FROM VST_PRODUCTOS_A WHERE 0>1";
            string _Str_Filtro = _Mtd_Filtro();
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            DataSet _DsTemp;
            string[] _P_Str_Productos = _Txt_Producto.Text.Split(new char[] { ',' });
            foreach (string _Str_Prod in _P_Str_Productos)
            {
                _Str_Cadena = _P_Str_ConsultaSql + " AND VST_PRODUCTOS_A.cproducto='" + _Str_Prod + "'";
                _DsTemp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_DsTemp.Tables[0].Rows.Count > 0)
                {
                    _Ds.Tables[0].Rows.Add(new object[] { _DsTemp.Tables[0].Rows[0]["Producto"].ToString().Trim(), _DsTemp.Tables[0].Rows[0]["Descripción"].ToString().Trim() });
                }
            }
            return _Ds;
        }
        private void _Mtd_CrearColumnSelect()
        {
            _Dg_ProdBusqueda.Columns.Clear();
            DataGridViewCheckBoxColumn _Dg_Col = new DataGridViewCheckBoxColumn(false);
            _Dg_Col.Name = "Select";
            _Dg_Col.HeaderText = "Seleccionar";
            _Dg_Col.FalseValue = false;
            _Dg_Col.TrueValue = true;
            _Dg_ProdBusqueda.Columns.Insert(0, _Dg_Col);
        }
        private void _Mtd_QuitarProductos()
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_ProdConjunto.SelectedRows)
            {
                _Dg_ProdConjunto.Rows.Remove(_Dg_Row);
            }
            _Dg_ProdConjunto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Seleccionar(bool _P_Bol_Select)
        {
            Cursor = Cursors.WaitCursor;
            foreach (DataGridViewRow _Dg_Row in _Dg_ProdBusqueda.Rows)
            {
                _Dg_Row.Cells["Select"].Value = _P_Bol_Select;
            }
            Cursor = Cursors.Default;
        }
        private void _Mtd_Actualizar()
        {
            _Dg_ProdConjunto.Rows.Clear();
            var _Var_Datos = from CamposTINCMARCAFOCODD in Program._Dat_Tablas.TINCMARCAFOCODD
                             join CamposTPRODUCTO in Program._Dat_Tablas.TPRODUCTO on CamposTINCMARCAFOCODD.cproducto equals CamposTPRODUCTO.cproducto
                             where CamposTINCMARCAFOCODD.cconjunto == _Int_Conjunto
                             select new { Producto = CamposTINCMARCAFOCODD.cproducto, Descripción = CamposTPRODUCTO.cnamefc };
            foreach (var _Var in _Var_Datos)
            {
                _Dg_ProdConjunto.Rows.Add(new object[] { _Var.Producto, _Var.Descripción });
            }
            _Dg_ProdConjunto.Sort(_Dg_ProdConjunto.Columns["Producto"], ListSortDirection.Ascending);
            _Dg_ProdConjunto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private decimal _Mtd_PorcActivacion(int _P_Int_Conjunto)
        {
            var _Var_Datos = from Campos in Program._Dat_Tablas.TINCMARCAFOCOD where Campos.cconjunto == _P_Int_Conjunto select Campos.cporcactivamin;
            if (_Var_Datos.Count() > 0) { return (decimal)_Var_Datos.Single(); }
            return 0;
        }
        private bool _Mtd_ProductosOmitidos(int _P_Int_Conjunto, string _P_Str_Producto)
        {
            var _Var_Datos = from Campos in Program._Dat_Vistas.VST_INC_MARCF_PRODUCTOS
                             where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidincmarcafoco == Convert.ToInt32(_Str_IncMarcf) & Campos.ccanal == _Str_Canal & Campos.cestable == _Str_Establecimiento & Campos.cano == _Int_Año & Campos.cmes == _Int_Mes & Campos.cproducto == _P_Str_Producto
                             select Campos;
            if (_Var_Datos.Count(c => c.cconjunto == _P_Int_Conjunto) > 0)//Se puede agregar. Pertenece al conjunto que se esta editando.
            { return false; }
            return _Var_Datos.Count() > 0;
        }
        public void _Mtd_Buscar()
        {
            DataSet _Ds;
            string _Str_ConsultaSql = _Mtd_ConsultaSql() + _Mtd_Filtro();
            this.Cursor = Cursors.WaitCursor;
            if (_Txt_Producto.Text.IndexOf(",") != -1)
            { _Ds = _Mtd_RetornarDataSet(_Str_ConsultaSql); }
            else
            {
                if (_Txt_Producto.Text.Trim().Length > 0)
                { _Str_ConsultaSql += " AND cproducto LIKE '%" + _Txt_Producto.Text.Trim() + "%'"; }
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_ConsultaSql);
            }
            //-------------
            _Bt_Marcar.Enabled = _Ds.Tables[0].Rows.Count > 0;
            _Bt_Desmarcar.Enabled = _Ds.Tables[0].Rows.Count > 0;
            _Bt_Agregar.Enabled = _Ds.Tables[0].Rows.Count > 0;
            //-------------
            if (_Ds.Tables[0].Rows.Count == 0)
            { this.Cursor = Cursors.Default; _Dg_ProdBusqueda.DataSource = null; MessageBox.Show("No se encontraron registros...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else
            {
                _Mtd_CrearColumnSelect();
                //---------------------------------
                var _Var_ProducConjunto = from Campos in _Dg_ProdConjunto.Rows.Cast<DataGridViewRow>()
                                          select Convert.ToString(Campos.Cells["Producto"].Value).Trim();
                //---------------------------------
                var _Var_ProducBusqueda = from Campos in _Ds.Tables[0].AsEnumerable() where !_Var_ProducConjunto.Contains(Campos["Producto"].ToString().Trim()) select Campos;
                //---------------------------------
                if (_Var_ProducBusqueda.Count() > 0)
                { _Dg_ProdBusqueda.DataSource = _Var_ProducBusqueda.CopyToDataTable(); }
                else
                {
                    _Str_ConsultaSql = "SELECT cproducto AS Producto,cnamefc AS Descripción FROM TPRODUCTO WHERE 0>1";//Esto es para que se vean columnas. Cuestión de presentación del grid.
                    _Dg_ProdBusqueda.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_ConsultaSql).Tables[0];
                }
                _Dg_ProdBusqueda.Sort(_Dg_ProdBusqueda.Columns["Producto"], ListSortDirection.Ascending); this.Cursor = Cursors.Default; _Dg_ProdBusqueda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Dg_ProdBusqueda.Columns["Producto"].ReadOnly = true;
                _Dg_ProdBusqueda.Columns["Descripción"].ReadOnly = true;
            }
        }
        private void Frm_IncConjunto_Load(object sender, EventArgs e)
        {

        }

        private void _Cmb_Proveedor_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Proveedor(_Str_GrupoInc);
        }

        private void _Cmb_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                _Chbox_Proveedores.CheckedChanged -= new EventHandler(_Chbox_Proveedores_CheckedChanged);
                _Chbox_Proveedores.Checked = true;
                _Chbox_Proveedores.CheckedChanged += new EventHandler(_Chbox_Proveedores_CheckedChanged);
                _Chbox_Grupos.Checked = true;
            }
            else
            {
                _Chbox_Grupos.Checked = false;
                _Cmb_Grupo.DataSource = null;
                _Cmb_Grupo.Enabled = false;
                _Chbox_Subgrupos.Checked = false;
                _Cmb_Subgrupo.DataSource = null;
                _Cmb_Subgrupo.Enabled = false;
                _Chbox_Marcas.Checked = false;
                _Cmb_Marca.DataSource = null;
                _Cmb_Marca.Enabled = false;
            }
        }

        private void _Cmb_Grupo_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                _Mtd_Cargar_Grupo(_Cmb_Proveedor.SelectedValue.ToString());
            }
        }

        private void _Cmb_Grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Grupo.SelectedIndex > 0)
            {
                _Chbox_Grupos.CheckedChanged -= new EventHandler(_Chbox_Grupos_CheckedChanged);
                _Chbox_Grupos.Checked = true;
                _Chbox_Grupos.CheckedChanged += new EventHandler(_Chbox_Grupos_CheckedChanged);
                _Chbox_Subgrupos.Checked = true;
                _Chbox_Marcas.Checked = true;
            }
            else
            {
                _Chbox_Subgrupos.Checked = false;
                _Cmb_Subgrupo.DataSource = null;
                _Cmb_Subgrupo.Enabled = false;
                _Chbox_Marcas.Checked = false;
                _Cmb_Marca.DataSource = null;
                _Cmb_Marca.Enabled = false;
            }
        }

        private void _Cmb_Subgrupo_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_Proveedor.SelectedIndex > 0 && _Cmb_Grupo.SelectedIndex > 0)
            {
                _Mtd_Cargar_Subgrupo(_Cmb_Proveedor.SelectedValue.ToString(), _Cmb_Grupo.SelectedValue.ToString());
            }
        }

        private void _Cmb_Subgrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Subgrupo.SelectedIndex > 0)
            {
                _Chbox_Subgrupos.CheckedChanged -= new EventHandler(_Chbox_Subgrupos_CheckedChanged);
                _Chbox_Subgrupos.Checked = true;
                _Chbox_Subgrupos.CheckedChanged += new EventHandler(_Chbox_Subgrupos_CheckedChanged);
            }
        }

        private void _Cmb_Marca_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_Proveedor.SelectedIndex > 0 && _Cmb_Grupo.SelectedIndex > 0)
            {
                _Mtd_Cargar_Marca(_Cmb_Proveedor.SelectedValue.ToString(), _Cmb_Grupo.SelectedValue.ToString());
            }
        }

        private void _Cmb_Marca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Marca.SelectedIndex > 0)
            {
                _Chbox_Marcas.CheckedChanged -= new EventHandler(_Chbox_Marcas_CheckedChanged);
                _Chbox_Marcas.Checked = true;
                _Chbox_Marcas.CheckedChanged += new EventHandler(_Chbox_Marcas_CheckedChanged);
            }
        }

        private void _Chbox_Proveedores_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Proveedores.Checked)
            { _Cmb_Proveedor.Enabled = true; _Mtd_Cargar_Proveedor(_Str_GrupoInc); }
            else
            { _Cmb_Proveedor.Enabled = false; _Cmb_Proveedor.SelectedIndex = -1; }
        }

        private void _Chbox_Grupos_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Grupos.Checked & _Cmb_Proveedor.SelectedIndex > 0)
            { _Cmb_Grupo.Enabled = true; _Mtd_Cargar_Grupo(_Cmb_Proveedor.SelectedValue.ToString()); }
            else
            { _Cmb_Grupo.Enabled = false; _Cmb_Grupo.SelectedIndex = -1; }
        }

        private void _Chbox_Subgrupos_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Subgrupos.Checked & _Cmb_Proveedor.SelectedIndex > 0 & _Cmb_Grupo.SelectedIndex > 0)
            { _Cmb_Subgrupo.Enabled = true; _Mtd_Cargar_Subgrupo(Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim(), Convert.ToString(_Cmb_Grupo.SelectedValue).Trim()); }
            else
            { _Cmb_Subgrupo.Enabled = false; _Cmb_Subgrupo.SelectedIndex = -1; }
        }

        private void _Chbox_Marcas_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Marcas.Checked & _Cmb_Proveedor.SelectedIndex > 0 & _Cmb_Grupo.SelectedIndex > 0)
            { _Cmb_Marca.Enabled = true; _Mtd_Cargar_Marca(Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim(), Convert.ToString(_Cmb_Grupo.SelectedValue).Trim()); }
            else
            { _Cmb_Marca.Enabled = false; _Cmb_Marca.SelectedIndex = -1; }
        }

        private void _Bt_Restablecer_Click(object sender, EventArgs e)
        {
            _Mtd_Restablecer();
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            _Mtd_Buscar();
        }

        private void _Bt_Marcar_Click(object sender, EventArgs e)
        {
            _Mtd_Seleccionar(true);
        }

        private void _Bt_Desmarcar_Click(object sender, EventArgs e)
        {
            _Mtd_Seleccionar(false);
        }

        private void _Bt_Agregar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var _Var_Datos = from Campos in _Dg_ProdBusqueda.Rows.Cast<DataGridViewRow>() where Convert.ToBoolean(((DataGridViewCheckBoxCell)Campos.Cells["Select"]).Value) == true select Campos;
            if (_Var_Datos.Count() > 0)
            {
                bool _Bol_ProductosOmitido = false;
                foreach (var _Var in _Var_Datos)
                {
                    if (!_Mtd_ProductosOmitidos(_Int_Conjunto, Convert.ToString(_Var.Cells["Producto"].Value).Trim()))
                    { _Dg_ProdConjunto.Rows.Add(new object[] { Convert.ToString(_Var.Cells["Producto"].Value).Trim(), Convert.ToString(_Var.Cells["Descripción"].Value).Trim() }); }
                    else
                    { _Bol_ProductosOmitido = true; }
                }
                Cursor = Cursors.Default;
                _Mtd_Buscar();
                if (_Bol_ProductosOmitido)
                { MessageBox.Show("Uno o más productos no pudieron ser agregados porque estan relacionados con otros parámetros o conjuntos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else
            { Cursor = Cursors.Default; MessageBox.Show("Debe seleccionar por lo menos un producto para realizar la operación.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void _Bt_Crear_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Dg_ProdConjunto.RowCount > 0)
            {
                if (_Txt_DesConjunto.Text.Trim().Length > 0 & _Num_cporcactivamin.Value > 0)
                {
                    if (MessageBox.Show("¿Esta seguro de crear el conjunto con los productos agregados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Cursor = Cursors.WaitCursor;
                        if (_Int_Conjunto > 0)
                        { _Frm_IncMarcaFoco._Mtd_Guardar_(_Int_Conjunto, _Txt_DesConjunto.Text.Trim().ToUpper(), _Num_cporcactivamin.Value, _Dg_ProdConjunto); }
                        else
                        { _Frm_IncMarcaFoco._Mtd_Guardar_(new _Cls_Consecutivos()._Mtd_IncConjunto(), _Txt_DesConjunto.Text.Trim().ToUpper(), _Num_cporcactivamin.Value, _Dg_ProdConjunto); }
                        Cursor = Cursors.Default;
                        this.DialogResult = DialogResult.Yes; this.Close();
                    }
                }
                else
                { 
                    if (_Txt_DesConjunto.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_DesConjunto, "Información requerida!!!"); }
                    if (_Num_cporcactivamin.Value <= 0) { _Er_Error.SetError(_Num_cporcactivamin, "Información requerida!!!"); }
                }
            }
            else
            { MessageBox.Show("Debe agregar por lo menos un producto para realizar la operación.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _Dg_ProdConjunto.SelectedRows.Count == 0;
        }

        private void _Tol_Quitar_Click(object sender, EventArgs e)
        {
            _Mtd_QuitarProductos();
            _Mtd_Buscar();
        }

        private void _Bt_ResConjunto_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
            Cursor = Cursors.Default;
            _Mtd_Buscar();
        }

        private void _Bt_Traer_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_IncConjSelect _Frm = new Frm_IncConjSelect(_Str_GrupoInc, _Txt_Producto);
            Cursor = Cursors.Default;
            _Frm.ShowDialog(this);
        }
    }
}