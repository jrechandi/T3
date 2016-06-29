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
    public partial class Frm_SelecProductos : Form
    {
        int _Int_Sw = 0;
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_SelecProductos()
        {
            InitializeComponent();
        }
        public Frm_SelecProductos(int _P_Int_Sw)
        {
            InitializeComponent();
            _Int_Sw = _P_Int_Sw;
            if (_Int_Sw == 2)
            {
                _Bt_Agregar.Text = "Generar tarjetas";
            }
            _Chbox_Proveedores.Checked = true;
            _Mtd_Color_Estandar(this);
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
        private string _Mtd_ConsultaSql(int _P_Int_Sw)
        {
            if (_P_Int_Sw == 1)//Consulta estandar.
            { return "SELECT cproducto AS Producto,RTRIM(produc_descrip) + '. ' + produc_descrip_2 AS Descripción FROM VST_PRODUCTOS_A WHERE cactivate='1' AND NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE VST_PRODUCTOS_A.cproveedor=TFILTROREGIONALP.cproveedor and VST_PRODUCTOS_A.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') AND (VST_PRODUCTOS_A.cdelete=0) AND (VST_PRODUCTOS_A.companyprov='" + Frm_Padre._Str_Comp + "')"; }
            else if (_P_Int_Sw == 2)//Consulta estandar con el sieguiente filtro: Que no exista en TINVFISICOD. Devuelve los productos a los que no se generó tarjeta.
            { return "SELECT VST_PRODUCTOS_A.cproducto AS Producto,RTRIM(produc_descrip) + '. ' + produc_descrip_2 AS Descripción,TPRODUCTOD.cidproductod AS [Lote],TPRODUCTOD.cprecioventamax AS PMV FROM VST_PRODUCTOS_A INNER JOIN TPRODUCTOD ON VST_PRODUCTOS_A.cproducto = TPRODUCTOD.cproducto WHERE cactivate='1' AND NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE VST_PRODUCTOS_A.cproveedor=TFILTROREGIONALP.cproveedor and VST_PRODUCTOS_A.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') AND (VST_PRODUCTOS_A.cdelete=0) AND (VST_PRODUCTOS_A.companyprov='" + Frm_Padre._Str_Comp + "') AND NOT EXISTS(SELECT cproducto FROM TINVFISICOD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cproducto=VST_PRODUCTOS_A.cproducto AND TINVFISICOD.cidproductod=TPRODUCTOD.cidproductod)"; }
            return "";
        }
        private void _Mtd_Cargar_Proveedor()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT DISTINCT VST_PRODUCTOS_A.cproveedor AS cproveedor,VST_PRODUCTOS_A.c_nomb_abreviado AS c_nomb_abreviado FROM VST_PRODUCTOS_A WHERE NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE VST_PRODUCTOS_A.cproveedor=TFILTROREGIONALP.cproveedor AND VST_PRODUCTOS_A.cproducto=TFILTROREGIONALP.cproducto AND TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' AND TFILTROREGIONALP.cdelete='0') AND VST_PRODUCTOS_A.cdelete=0 AND VST_PRODUCTOS_A.companyprov='" + Frm_Padre._Str_Comp + "' ORDER BY VST_PRODUCTOS_A.c_nomb_abreviado";
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
        private void _Mtd_Restablecer()
        {
            _Txt_Descripcion.Text = "";
            _Txt_Producto.Text = "";
            _Chbox_Proveedores.Checked = true;
            _Mtd_Cargar_Proveedor();
            _Chbox_Grupos.Checked = false;
            _Chbox_Subgrupos.Checked = false;
            _Chbox_Marcas.Checked = false;
            _Dg_Grid.DataSource = null;
            _Dg_Grid.Columns.Clear();
            _Bt_Marcar.Enabled = false;
            _Bt_Desmarcar.Enabled = false;
            _Bt_Agregar.Enabled = false;
        }

        private string _Mtd_Filtro()
        {
            string _Str_Cadena = "";
            if (_Cmb_Proveedor.SelectedIndex > 0)
            { _Str_Cadena += " AND cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "'"; }
            if (_Cmb_Grupo.SelectedIndex > 0)
            { _Str_Cadena += " AND cgrupo='" + _Cmb_Grupo.SelectedValue.ToString() + "'"; }
            if (_Cmb_Subgrupo.SelectedIndex > 0)
            { _Str_Cadena += " AND csubgrupo='" + _Cmb_Subgrupo.SelectedValue.ToString() + "'"; }
            if (_Cmb_Marca.SelectedIndex > 0)
            { _Str_Cadena += " AND cmarca='" + _Cmb_Marca.SelectedValue.ToString() + "'"; }
            if (_Txt_Descripcion.Text.Trim().Length > 0)
            { _Str_Cadena += " AND cnamef LIKE '%" + _Txt_Descripcion.Text.Trim() + "%'"; }
            return _Str_Cadena;
        }

        private DataSet _Mtd_RetornarDataSet(string _P_Str_ConsultaSql)
        {
            string _Str_Cadena = "SELECT cproducto AS Producto,RTRIM(produc_descrip) + '. ' + produc_descrip_2 AS Descripción FROM VST_PRODUCTOS_A WHERE 0>1";
            if (_Int_Sw == 2)
                _Str_Cadena = "SELECT VST_PRODUCTOS_A.cproducto AS Producto,RTRIM(produc_descrip) + '. ' + produc_descrip_2 AS Descripción,TPRODUCTOD.cidproductod AS [Lote],TPRODUCTOD.cprecioventamax AS PMV FROM VST_PRODUCTOS_A INNER JOIN TPRODUCTOD ON VST_PRODUCTOS_A.cproducto = TPRODUCTOD.cproducto WHERE 0>1";
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
            _Dg_Grid.Columns.Clear();
            DataGridViewCheckBoxColumn _Dg_Col = new DataGridViewCheckBoxColumn(false);
            _Dg_Col.Name = "Select";
            _Dg_Col.HeaderText = "Seleccionar";
            _Dg_Col.FalseValue = false;
            _Dg_Col.TrueValue = true;
            _Dg_Grid.Columns.Insert(0, _Dg_Col);
        }
        private void Frm_SelecProductos_Load(object sender, EventArgs e)
        {

        }

        private void _Cmb_Proveedor_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Proveedor();
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
            { _Cmb_Proveedor.Enabled = true; _Mtd_Cargar_Proveedor(); }
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
        private void _Mtd_Seleccionar(bool _P_Bol_Select)
        {
            Cursor = Cursors.WaitCursor;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                _Dg_Row.Cells["Select"].Value = _P_Bol_Select;
            }
            Cursor = Cursors.Default;
        }
        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            DataSet _Ds;
            string _Str_ConsultaSql = _Mtd_ConsultaSql(_Int_Sw) + _Mtd_Filtro();
            this.Cursor = Cursors.WaitCursor;
            if (_Txt_Producto.Text.IndexOf(",") != -1)
            { _Ds = _Mtd_RetornarDataSet(_Str_ConsultaSql); }
            else
            {
                if (_Txt_Producto.Text.Trim().Length > 0)
                { _Str_ConsultaSql += " AND VST_PRODUCTOS_A.cproducto LIKE '%" + _Txt_Producto.Text.Trim() + "%'"; }
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_ConsultaSql); 
            }
            //-------------
            _Bt_Marcar.Enabled = _Ds.Tables[0].Rows.Count > 0;
            _Bt_Desmarcar.Enabled = _Ds.Tables[0].Rows.Count > 0;
            _Bt_Agregar.Enabled = _Ds.Tables[0].Rows.Count > 0;
            //-------------
            if (_Ds.Tables[0].Rows.Count == 0)
            { this.Cursor = Cursors.Default; _Dg_Grid.DataSource = null; MessageBox.Show("No se encontraron registros...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else
            {
                _Mtd_CrearColumnSelect();
                _Dg_Grid.DataSource = _Ds.Tables[0]; _Dg_Grid.Sort(_Dg_Grid.Columns["Producto"], ListSortDirection.Ascending); this.Cursor = Cursors.Default; _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Dg_Grid.Columns["Producto"].ReadOnly = true;
                _Dg_Grid.Columns["Descripción"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                _Dg_Grid.Columns["Lote"].ReadOnly = true;
                _Dg_Grid.Columns["PMV"].ReadOnly = true;
                _Dg_Grid.Columns["PMV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dg_Grid.Columns["Descripción"].ReadOnly = true;
            }
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
            if (_Int_Sw == 2)
            {
                if (_Dg_Grid.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["Select"].Value)).Count() > 0)
                {
                    if (MessageBox.Show("¿Esta seguro de generar las tarjetas para los productos seleccionados?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    { this.DialogResult = DialogResult.Yes; this.Close(); }
                }
                else
                { MessageBox.Show("Debe seleccionar por lo menos un producto para realizar la operación.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            }
        }
    }
}