using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_BusquedaAvanzada2 : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public string _Str_FrmResult = "";
        public Frm_BusquedaAvanzada2()
        {
            InitializeComponent();
        }
        TextBox _Txt_TextBoxCod = new TextBox();
        TextBox _Txt_TextBoxDes = new TextBox();
        string _Str_Where = "";
        string _Str_Vendedor = "";
        public Frm_BusquedaAvanzada2(TextBox _P_Txt_TextBoxCod, TextBox _P_Txt_TextBoxDes,string _P_Str_Where)
        {
            InitializeComponent();
            _Txt_TextBoxCod = _P_Txt_TextBoxCod;
            _Txt_TextBoxDes = _P_Txt_TextBoxDes;
            _Str_Where = _P_Str_Where;
            _Mtd_Cargar_Proveedor();
            _Mtd_Color_Estandar(this);
        }
        public Frm_BusquedaAvanzada2(TextBox _P_Txt_TextBoxCod, TextBox _P_Txt_TextBoxDes, string _P_Str_Vendedor, bool _P_Bol_PorGrupoVta)
        {
            InitializeComponent();
            _Txt_TextBoxCod = _P_Txt_TextBoxCod;
            _Txt_TextBoxDes = _P_Txt_TextBoxDes;
            _Str_Vendedor = _P_Str_Vendedor;
            _Mtd_Cargar_Proveedor(_P_Str_Vendedor);
            _Mtd_Color_Estandar(this);
        }
        public Frm_BusquedaAvanzada2(TextBox _P_Txt_TextBoxCod, TextBox _P_Txt_TextBoxDes, string _P_Str_Where,string _P_Str_Proveedor)
        {
            InitializeComponent();
            _Txt_TextBoxCod = _P_Txt_TextBoxCod;
            _Txt_TextBoxDes = _P_Txt_TextBoxDes;
            _Str_Where = _P_Str_Where;
            _Mtd_Cargar_Proveedor();
            _Mtd_Color_Estandar(this);
            _Chbox_Proveedores.Checked = true;
            _Cmb_Proveedor.SelectedValue = _P_Str_Proveedor;
            _Chbox_Proveedores.Enabled = false;
            _Cmb_Proveedor.Enabled = false;
        }
        Form _Frm_Formulario;
        public Frm_BusquedaAvanzada2(Form _P_Frm_Formulario,TextBox _P_Txt_TextBoxCod, TextBox _P_Txt_TextBoxDes, string _P_Str_Where, string _P_Str_Proveedor, string _P_Str_Grupo, string _P_Str_SubGrupo, string _P_Str_Marca)
        {
            InitializeComponent();
            _Frm_Formulario = _P_Frm_Formulario;
            _Dg_Grid.ContextMenuStrip = _Cntx_Menu;
            _Txt_TextBoxCod = _P_Txt_TextBoxCod;
            _Txt_TextBoxDes = _P_Txt_TextBoxDes;
            _Str_Where = _P_Str_Where;
            _Mtd_Cargar_Proveedor();
            _Mtd_Color_Estandar(this);
            if (_P_Str_Proveedor.Trim().Length > 0)
            {
                _Chbox_Proveedores.Checked = true;
                _Cmb_Proveedor.SelectedValue = _P_Str_Proveedor;
                _Chbox_Proveedores.Enabled = false;
                _Cmb_Proveedor.Enabled = false;
                //----------------------
                if (_P_Str_Grupo.Trim().Length > 0)
                {
                    _Chbox_Grupos.Checked = true;
                    _Cmb_Grupo.SelectedValue = _P_Str_Grupo;
                    _Chbox_Grupos.Enabled = false;
                    _Cmb_Grupo.Enabled = false;
                    //----------------------
                    if (_P_Str_SubGrupo.Trim().Length > 0)
                    {
                        _Chbox_Subgrupos.Checked = true;
                        _Cmb_Subgrupo.SelectedValue = _P_Str_SubGrupo;
                        _Chbox_Subgrupos.Enabled = false;
                        _Cmb_Subgrupo.Enabled = false;
                    }
                    if (_P_Str_Marca.Trim().Length > 0)
                    {
                        _Chbox_Marcas.Checked = true;
                        _Cmb_Marca.SelectedValue = _P_Str_Marca;
                        _Chbox_Marcas.Enabled = false;
                        _Cmb_Marca.Enabled = false;
                    }
                }
            }
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
        private void _Mtd_Cargar_Proveedor()
        {
            string _Str_Cadena = "select distinct VST_PRODUCTOS_A.cproveedor as cproveedor,VST_PRODUCTOS_A.c_nomb_abreviado as c_nomb_abreviado from VST_PRODUCTOS_A where NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE VST_PRODUCTOS_A.cproveedor=TFILTROREGIONALP.cproveedor and VST_PRODUCTOS_A.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') and VST_PRODUCTOS_A.cdelete=0 AND VST_PRODUCTOS_A.companyprov='" + Frm_Padre._Str_Comp + "' ORDER BY VST_PRODUCTOS_A.c_nomb_abreviado ";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Proveedor, _Str_Cadena);
        }
        private void _Mtd_Cargar_Proveedor(string _P_Str_Vendedor)
        {
            string _Str_Cadena = "SELECT DISTINCT VST_PRODUCTOS_A.cproveedor, VST_PRODUCTOS_A.c_nomb_abreviado FROM TVENDEDOR INNER JOIN TGRUPPROVEE ON TVENDEDOR.ccompany = TGRUPPROVEE.ccompany AND TVENDEDOR.c_grupo_vta = TGRUPPROVEE.cgrupovta INNER JOIN VST_PRODUCTOS_A ON TGRUPPROVEE.cproveedor = VST_PRODUCTOS_A.cproveedor WHERE (TVENDEDOR.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TVENDEDOR.cvendedor = '" + _P_Str_Vendedor + "') AND (TGRUPPROVEE.cdelete = 0) AND NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE VST_PRODUCTOS_A.cproveedor=TFILTROREGIONALP.cproveedor and VST_PRODUCTOS_A.cproducto=TFILTROREGIONALP.cproducto AND TFILTROREGIONALP.ccompany=TVENDEDOR.ccompany AND TFILTROREGIONALP.cdelete='0') AND VST_PRODUCTOS_A.cdelete=0 ORDER BY VST_PRODUCTOS_A.c_nomb_abreviado";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Proveedor, _Str_Cadena);
        }
        private void _Mtd_Cargar_Grupo(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT distinct RTRIM(dbo.TGRUPPROM.ccodgrupop) AS ccodgrupop, dbo.TGRUPPROM.cname " +
            "FROM dbo.TGRUPPROM INNER JOIN " +
            "dbo.TGRUPPROD ON dbo.TGRUPPROM.ccodgrupop = dbo.TGRUPPROD.ccodgrupop AND " +
            "dbo.TGRUPPROM.cdelete = dbo.TGRUPPROD.cdelete INNER JOIN " +
            "dbo.TPRODUCTO ON dbo.TGRUPPROD.cproveedor = dbo.TPRODUCTO.cproveedor AND dbo.TGRUPPROD.ccodgrupop = dbo.TPRODUCTO.cgrupo " +
            "where NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE TGRUPPROD.cproveedor=TFILTROREGIONALP.cproveedor and TPRODUCTO.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') " +
            "AND (TGRUPPROD.cproveedor = '" + _P_Str_Proveedor + "') AND (TGRUPPROM.cdelete = 0) AND (TPRODUCTO.cdelete=0) ORDER BY TGRUPPROM.cname";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Grupo, _Str_Cadena);
        }
        private void _Mtd_Cargar_Subgrupo(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            string _Str_Cadena = "SELECT distinct RTRIM(dbo.TSUBGRUPOM.ccodsubgrup) AS ccodsubgrup, RTRIM(dbo.TSUBGRUPOM.cname) AS cnamesub " +
            "FROM dbo.TSUBGRUPOM INNER JOIN "+
            "dbo.TSUBGRUPOD ON dbo.TSUBGRUPOM.ccodsubgrup = dbo.TSUBGRUPOD.ccodsubgrup AND "+
            "dbo.TSUBGRUPOM.cdelete = dbo.TSUBGRUPOD.cdelete INNER JOIN "+
            "dbo.TPRODUCTO ON dbo.TSUBGRUPOD.cproveedor = dbo.TPRODUCTO.cproveedor AND "+
            "dbo.TSUBGRUPOD.ccodsubgrup = dbo.TPRODUCTO.csubgrupo AND dbo.TSUBGRUPOD.ccodgrupop = dbo.TPRODUCTO.cgrupo "+
            "where NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE TPRODUCTO.cproveedor=TFILTROREGIONALP.cproveedor and TPRODUCTO.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='"+Frm_Padre._Str_Comp+"' and TFILTROREGIONALP.cdelete='0') " +
            "AND (TSUBGRUPOM.cdelete = 0) AND (TSUBGRUPOD.cproveedor = '" + _P_Str_Proveedor + "') AND (TSUBGRUPOD.ccodgrupop = '" + _P_Str_Grupo + "') AND (TPRODUCTO.cdelete=0) ORDER BY cnamesub";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Subgrupo, _Str_Cadena);
        }
        private void _Mtd_Cargar_Marca(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            string _Str_Cadena = "SELECT distinct RTRIM(dbo.TMARCASM.cmarca) AS cmarca, RTRIM(dbo.TMARCASM.cname) AS cnamemarc " +
            "FROM dbo.TMARCASM INNER JOIN " +
            "dbo.TMARCAS ON dbo.TMARCASM.cmarca = dbo.TMARCAS.cmarca INNER JOIN " +
            "dbo.TPRODUCTO ON dbo.TMARCASM.cmarca = dbo.TPRODUCTO.cmarca " +
            "where NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE TPRODUCTO.cproveedor=TFILTROREGIONALP.cproveedor and TPRODUCTO.cproducto=TFILTROREGIONALP.cproducto and TPRODUCTO.cmarca=TFILTROREGIONALP.cmarca and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') " +
            "AND (TMARCASM.cdelete = 0) AND (TMARCAS.ccodgrupop = '" + _P_Str_Grupo + "') AND (TMARCAS.cproveedor = '" + _P_Str_Proveedor + "') AND (TPRODUCTO.cdelete=0) ORDER BY cnamemarc";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Marca, _Str_Cadena);
        }
        private void _Mtd_Restablecer()
        {
            _Txt_Buscar.Text = "";
            _Txt_CodigoEs.Text = "";
            if (_Chbox_Proveedores.Enabled)
            {
                _Chbox_Proveedores.Checked = false;
                _Cmb_Proveedor.Enabled = true;
            }
            if (_Chbox_Grupos.Enabled)
            {
                _Chbox_Grupos.Checked = false;
            }
            if (_Chbox_Subgrupos.Enabled)
            {
                _Chbox_Subgrupos.Checked = false;
            }
            _Chbox_Marcas.Checked = false;
        }
        private string _Mtd_Buscar()
        {
            string _Str_Cadena = "";
            bool _Bol_Entrada = false;
            if (_Cmb_Subgrupo.SelectedIndex >0)
            { _Str_Cadena = "where cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "' and cgrupo='" + _Cmb_Grupo.SelectedValue.ToString() + "' and csubgrupo='" + _Cmb_Subgrupo.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
            else if (_Cmb_Grupo.SelectedIndex >0)
            { _Str_Cadena = "where cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "' and cgrupo='" + _Cmb_Grupo.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
            else if (_Cmb_Subgrupo.SelectedIndex < 1 & _Cmb_Grupo.SelectedIndex < 1 & _Cmb_Proveedor.SelectedIndex > 0 )
            { _Str_Cadena = "where cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
            if (_Bol_Entrada)
            {
                if (_Cmb_Marca.SelectedIndex >0)
                { _Str_Cadena = _Str_Cadena + " and cmarca='" + _Cmb_Marca.SelectedValue.ToString() + "'"; }
            }
            else
            {
                if (_Cmb_Marca.SelectedIndex >0)
                { _Str_Cadena = "where cmarca='" + _Cmb_Marca.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
            }
            if (_Bol_Entrada)
            {
                if (_Txt_Buscar.Text.Trim().Length > 0)
                { _Str_Cadena = _Str_Cadena + " and cnamef like('%" + _Txt_Buscar.Text.Trim() + "%')"; }
                if (_Txt_CodigoEs.Text.Trim().Length > 0)
                { _Str_Cadena = _Str_Cadena + " and cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; }
            }
            else
            {
                if (_Txt_Buscar.Text.Trim().Length > 0 & _Txt_CodigoEs.Text.Trim().Length == 0)
                { _Str_Cadena = "where cnamef like('%" + _Txt_Buscar.Text.Trim() + "%')"; }
                else if (_Txt_Buscar.Text.Trim().Length == 0 & _Txt_CodigoEs.Text.Trim().Length > 0)
                { _Str_Cadena = "where cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; }
                else if (_Txt_Buscar.Text.Trim().Length > 0 & _Txt_CodigoEs.Text.Trim().Length > 0)
                { _Str_Cadena = "where cnamef like('%" + _Txt_Buscar.Text.Trim() + "%') and cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; }
            }
            if (_Str_Cadena.Length > 0)
            {
                return _Str_Cadena;
            }
            else
            {
                MessageBox.Show("Debe especificar algún criterio de busqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return "";
            }
        }
        private string _Mtd_Buscar2()
        {
            string _Str_Cadena = "";
            if (_Cmb_Proveedor.SelectedIndex > 0)
            { _Str_Cadena += " and cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "'"; }
            if (_Cmb_Grupo.SelectedIndex > 0)
            { _Str_Cadena += " and cgrupo='" + _Cmb_Grupo.SelectedValue.ToString() + "'"; }
            if (_Cmb_Subgrupo.SelectedIndex > 0)
            { _Str_Cadena += " and csubgrupo='" + _Cmb_Subgrupo.SelectedValue.ToString() + "'"; }
            if (_Cmb_Marca.SelectedIndex > 0)
            { _Str_Cadena += " and cmarca='" + _Cmb_Marca.SelectedValue.ToString() + "'"; }
            if (_Txt_Buscar.Text.Trim().Length > 0)
            { _Str_Cadena += " and cnamef like('%" + _Txt_Buscar.Text.Trim() + "%')"; }
            return _Str_Cadena;
        }
        private void Frm_BusquedaAvanzada2_Load(object sender, EventArgs e)
        {

        }

        private void _Chbox_Proveedores_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Proveedores.Checked)
            { _Cmb_Proveedor.Enabled = true; if (_Str_Vendedor.Trim().Length > 0) { _Mtd_Cargar_Proveedor(_Str_Vendedor); } else { _Mtd_Cargar_Proveedor(); } }
            else
            { _Cmb_Proveedor.Enabled = false; _Cmb_Proveedor.SelectedIndex = -1; }
        }

        private void _Chbox_Grupos_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Grupos.Checked && _Cmb_Proveedor.SelectedIndex>0)
            { 
                _Cmb_Grupo.Enabled = true;
                _Mtd_Cargar_Grupo(_Cmb_Proveedor.SelectedValue.ToString()); 
            }
            else
            { _Cmb_Grupo.Enabled = false; _Cmb_Grupo.SelectedIndex = -1; }
        }

        private void _Chbox_Subgrupos_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Subgrupos.Checked)
            { 
                if (_Cmb_Proveedor.SelectedIndex > 0 && _Cmb_Grupo.SelectedIndex>0)
                {
                    _Cmb_Subgrupo.Enabled = true;
                    _Mtd_Cargar_Subgrupo(_Cmb_Proveedor.SelectedValue.ToString(), _Cmb_Grupo.SelectedValue.ToString());
                }
            }
            else
            { _Cmb_Subgrupo.Enabled = false; _Cmb_Subgrupo.SelectedIndex = -1; }
        }

        private void _Chbox_Marcas_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Marcas.Checked)
            {
                if (_Cmb_Proveedor.SelectedIndex > 0 && _Cmb_Grupo.SelectedIndex>0)
                {
                    _Cmb_Marca.Enabled = true;
                    _Mtd_Cargar_Marca(_Cmb_Proveedor.SelectedValue.ToString(), _Cmb_Grupo.SelectedValue.ToString());
                }
            }
            else
            { _Cmb_Marca.Enabled = false; _Cmb_Marca.SelectedIndex = -1; }
        }
        private void _Cmb_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Proveedor.SelectedIndex >0)
            {
                _Chbox_Proveedores.CheckedChanged -= new EventHandler(_Chbox_Proveedores_CheckedChanged);
                _Chbox_Proveedores.Checked = true;
                _Chbox_Proveedores.CheckedChanged += new EventHandler(_Chbox_Proveedores_CheckedChanged);
                _Cmb_Grupo.Enabled = true;
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

        private void _Cmb_Grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Grupo.SelectedIndex > 0)
            {
                _Chbox_Grupos.CheckedChanged -= new EventHandler(_Chbox_Grupos_CheckedChanged);
                _Chbox_Grupos.Checked = true;
                _Chbox_Grupos.CheckedChanged += new EventHandler(_Chbox_Grupos_CheckedChanged);
                _Cmb_Subgrupo.Enabled = true;
                _Cmb_Marca.Enabled = true;
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

        private void _Cmb_Subgrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Subgrupo.SelectedIndex > 0)
            {
                _Chbox_Subgrupos.CheckedChanged -= new EventHandler(_Chbox_Subgrupos_CheckedChanged);
                _Chbox_Subgrupos.Checked = true;
                _Chbox_Subgrupos.CheckedChanged += new EventHandler(_Chbox_Subgrupos_CheckedChanged);
            }
            else
            {

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
            else
            {

            }
        }

        private void _Bt_Restablecer_Click(object sender, EventArgs e)
        {
            _Mtd_Restablecer();
        }
        private DataSet _Mtd_RetornarDataSet()
        {
            string _Str_Cadena = "Select cproducto as Producto,RTRIM(produc_descrip) + '. ' + produc_descrip_2 as Descripción from VST_PRODUCTOS_A WHERE 0>1";
            string _Str_Filtro = _Mtd_Buscar2();
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            DataSet _DsTemp;
            string[] _P_Str_Productos = _Txt_CodigoEs.Text.Split(new char[] { ',' });
            foreach (string _Str_Prod in _P_Str_Productos)
            {
                _Str_Cadena = "Select cproducto as Producto,RTRIM(produc_descrip) + '. ' + produc_descrip_2 as Descripción from VST_PRODUCTOS_A WHERE 1>0" + _Str_Filtro + " " + _Str_Where +
                              " AND cactivate='1' AND NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE VST_PRODUCTOS_A.cproveedor=TFILTROREGIONALP.cproveedor and VST_PRODUCTOS_A.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') AND (VST_PRODUCTOS_A.cdelete=0) AND (VST_PRODUCTOS_A.companyprov='" + Frm_Padre._Str_Comp + "') AND VST_PRODUCTOS_A.cproducto='" + _Str_Prod + "'";
                _DsTemp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_DsTemp.Tables[0].Rows.Count > 0)
                {
                    _Ds.Tables[0].Rows.Add(new object[] { _DsTemp.Tables[0].Rows[0]["Producto"].ToString().Trim(), _DsTemp.Tables[0].Rows[0]["Descripción"].ToString().Trim() });
                }
            }
            return _Ds;
        }
        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            DataSet _Ds;
            string _Str_Cadena = "";
            string _Str_Filtro = _Mtd_Buscar();
            if (_Str_Filtro.Trim().Length > 0)
            {
                if (_Str_Vendedor.Trim().Length == 0 | (_Str_Vendedor.Trim().Length > 0 & _Txt_CodigoEs.Text.Trim().Length == 0 & _Txt_Buscar.Text.Trim().Length == 0) | (_Str_Vendedor.Trim().Length > 0 & _Cmb_Proveedor.SelectedIndex > 0))
                {
                    _Str_Cadena = "Select cproducto as Producto,RTRIM(produc_descrip) + '. ' + produc_descrip_2 as Descripción from VST_PRODUCTOS_A " + _Str_Filtro + " " + _Str_Where +
                    " AND cactivate='1' AND NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE VST_PRODUCTOS_A.cproveedor=TFILTROREGIONALP.cproveedor and VST_PRODUCTOS_A.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') AND (VST_PRODUCTOS_A.cdelete=0) AND (VST_PRODUCTOS_A.companyprov='" + Frm_Padre._Str_Comp + "') ";
                    this.Cursor = Cursors.WaitCursor;
                    if (_Txt_CodigoEs.Text.IndexOf(",") != -1)
                    { _Ds = _Mtd_RetornarDataSet(); }
                    else
                    { _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena); }
                    this.Cursor = Cursors.Default;
                    if (_Ds.Tables[0].Rows.Count == 0)
                    { _Dg_Grid.DataSource = null; MessageBox.Show("No se encontraron registros...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    else
                    { _Dg_Grid.DataSource = _Ds.Tables[0]; _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; }
                }
                else
                { MessageBox.Show("Debe seleccionar un proveedor para ejecutar la consulta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _Txt_TextBoxCod.Text = _Dg_Grid.Rows[e.RowIndex].Cells[0].Value.ToString();
            _Txt_TextBoxDes.Text = _Dg_Grid.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.Close();
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

        private void _Cmb_Proveedor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (_Str_Vendedor.Trim().Length > 0) { _Mtd_Cargar_Proveedor(_Str_Vendedor); } else { _Mtd_Cargar_Proveedor(); }
            this.Cursor = Cursors.Default;
        }

        private void _Cmb_Grupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                _Mtd_Cargar_Grupo(_Cmb_Proveedor.SelectedValue.ToString());
            }
            this.Cursor = Cursors.Default;
        }

        private void _Cmb_Subgrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (_Cmb_Proveedor.SelectedIndex > 0 && _Cmb_Grupo.SelectedIndex > 0)
            {
                _Mtd_Cargar_Subgrupo(_Cmb_Proveedor.SelectedValue.ToString(), _Cmb_Grupo.SelectedValue.ToString());
            }
            this.Cursor = Cursors.Default;
        }

        private void _Cmb_Marca_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (_Cmb_Proveedor.SelectedIndex > 0 && _Cmb_Grupo.SelectedIndex > 0)
            {
                _Mtd_Cargar_Marca(_Cmb_Proveedor.SelectedValue.ToString(), _Cmb_Grupo.SelectedValue.ToString());
            }
            this.Cursor = Cursors.Default;
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _Dg_Grid.SelectedRows.Count == 0;
        }

        private void AgregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ((dynamic)_Frm_Formulario)._Txt_Producto.Tag = "Nulo";
            bool _Bol_Guadado = ((dynamic)_Frm_Formulario)._Mtd_Guardar_(_Dg_Grid);
            Cursor = Cursors.Default;
            if (_Bol_Guadado) { this.Close(); }
        }
    }
}