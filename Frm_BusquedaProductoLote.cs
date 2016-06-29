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
    public partial class Frm_BusquedaProductoLote : Form
    {
        bool _Bol_Salida_;
        bool _Bol_AjusteIntegrado;
        string _Str_NotaRecepcion = "";
        TextBox _Txt_TextBoxCod = new TextBox();
        TextBox _Txt_TextBoxDes = new TextBox();
        TextBox _Txt_TextBoxLote = new TextBox();
        TextBox _Txt_TextBoxPMV = new TextBox();
        TextBox _Txt_TextBoxCodLote = new TextBox();
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_BusquedaProductoLote()
        {
            InitializeComponent();
        }
        public Frm_BusquedaProductoLote(bool _P_Bol_AjusteSalida, string _P_Str_Proveedor, string _P_Str_NotaRecepcion, TextBox _P_Txt_CodProducto, TextBox _P_Txt_ProductoDesc, TextBox _P_Txt_Lote, TextBox _P_Txt_Pmv)
        {
            InitializeComponent();
            _Mtd_Cargar_Proveedor();
            _Txt_TextBoxCod = _P_Txt_CodProducto;
            _Txt_TextBoxDes = _P_Txt_ProductoDesc;
            _Txt_TextBoxLote = _P_Txt_Lote;
            _Txt_TextBoxPMV = _P_Txt_Pmv;
            _Cmb_Proveedor.SelectedValue = _P_Str_Proveedor;
            _Cmb_Proveedor.Enabled = false;
            _Str_NotaRecepcion = _P_Str_NotaRecepcion;
            _Bol_AjusteIntegrado = true;
            _Bol_Salida_ = _P_Bol_AjusteSalida;
        }
        public Frm_BusquedaProductoLote(bool _Bol_Salida,TextBox _Txt_CodProducto,TextBox _Txt_Nombre, TextBox _Txt_Lote,TextBox _Txt_PMV, TextBox _Txt_CodLote)
        {
            InitializeComponent();
            _Mtd_Cargar_Proveedor();
            _Txt_TextBoxCod = _Txt_CodProducto;
            _Txt_TextBoxDes = _Txt_Nombre;
            _Txt_TextBoxLote = _Txt_Lote;
            _Txt_TextBoxPMV = _Txt_PMV;
            _Txt_TextBoxCodLote = _Txt_CodLote;
            _Bol_Salida_ = _Bol_Salida;
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        private void _Txt_CodProducto_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void _Txt_CodLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_CodLote_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_CodLote.Text))
            {
                _Txt_CodLote.Text = "";
            }
        }

        private void _Mtd_Cargar_Proveedor()
        {
            string _Str_Cadena = "select distinct VST_PRODUCTOS_A.cproveedor as cproveedor,VST_PRODUCTOS_A.c_nomb_abreviado as c_nomb_abreviado from VST_PRODUCTOS_A where NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE VST_PRODUCTOS_A.cproveedor=TFILTROREGIONALP.cproveedor and VST_PRODUCTOS_A.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') and VST_PRODUCTOS_A.cdelete=0 AND VST_PRODUCTOS_A.companyprov='" + Frm_Padre._Str_Comp + "' ORDER BY VST_PRODUCTOS_A.c_nomb_abreviado ";
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
            if (_Cmb_Grupo.Items.Count > 0)
            {
                _Cmb_Grupo.Enabled = true;
            }
            else
            {
                _Cmb_Grupo.Enabled = false;
            }
        }
        private void _Mtd_Cargar_Subgrupo(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            string _Str_Cadena = "SELECT distinct RTRIM(dbo.TSUBGRUPOM.ccodsubgrup) AS ccodsubgrup, RTRIM(dbo.TSUBGRUPOM.cname) AS cnamesub " +
            "FROM dbo.TSUBGRUPOM INNER JOIN " +
            "dbo.TSUBGRUPOD ON dbo.TSUBGRUPOM.ccodsubgrup = dbo.TSUBGRUPOD.ccodsubgrup AND " +
            "dbo.TSUBGRUPOM.cdelete = dbo.TSUBGRUPOD.cdelete INNER JOIN " +
            "dbo.TPRODUCTO ON dbo.TSUBGRUPOD.cproveedor = dbo.TPRODUCTO.cproveedor AND " +
            "dbo.TSUBGRUPOD.ccodsubgrup = dbo.TPRODUCTO.csubgrupo AND dbo.TSUBGRUPOD.ccodgrupop = dbo.TPRODUCTO.cgrupo " +
            "where NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE TPRODUCTO.cproveedor=TFILTROREGIONALP.cproveedor and TPRODUCTO.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') " +
            "AND (TSUBGRUPOM.cdelete = 0) AND (TSUBGRUPOD.cproveedor = '" + _P_Str_Proveedor + "') AND (TSUBGRUPOD.ccodgrupop = '" + _P_Str_Grupo + "') AND (TPRODUCTO.cdelete=0) ORDER BY cnamesub";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Subgrupo, _Str_Cadena);
            if (_Cmb_Subgrupo.Items.Count > 0)
            {
                _Cmb_Subgrupo.Enabled = true;
            }
            else
            {
                _Cmb_Subgrupo.Enabled = false;
            }
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

        private void _Cmb_Grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (_Cmb_Proveedor.SelectedIndex > 0 && _Cmb_Grupo.SelectedIndex > 0)
            {
                _Mtd_Cargar_Subgrupo(_Cmb_Proveedor.SelectedValue.ToString(), _Cmb_Grupo.SelectedValue.ToString());
            }
            this.Cursor = Cursors.Default;
        }

        private void _Cmb_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                _Mtd_Cargar_Grupo(_Cmb_Proveedor.SelectedValue.ToString());
            }
            this.Cursor = Cursors.Default;
        }

        private void _Bt_Restablecer_Click(object sender, EventArgs e)
        {
            _Mtd_Restablecer();
        }
        private void _Mtd_Restablecer()
        {
            _Cmb_Proveedor.SelectedIndex = 0;
            //_Cmb_Grupo.SelectedIndex = 0;
            _Cmb_Grupo.Enabled = false;
            //_Cmb_Subgrupo.SelectedIndex = 0;
            _Cmb_Subgrupo.Enabled = false;
            _Txt_CodProducto.Text = "";
            _Txt_CodLote.Text = "";
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            if (_Bol_AjusteIntegrado)
                _Mtd_BuscarAjusteIntegrado();
            else
                _Mtd_Buscar();
        }
        private void _Mtd_Buscar()
        {
            string _Str_SQL = "SELECT cproducto,cidproductod,cprecioventamax,cnamefc FROM  VST_T3_PRODUCTOLOTECOMPANIA WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'";
            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                _Str_SQL+=" AND CPROVEEDOR='"+_Cmb_Proveedor.SelectedValue.ToString()+"'";
            }
            if (_Cmb_Grupo.SelectedIndex > 0)
            {
                _Str_SQL += " AND cgrupo='" + _Cmb_Grupo.SelectedValue.ToString() + "'";
            }
            if (_Cmb_Subgrupo.SelectedIndex > 0)
            {
                _Str_SQL += " AND csubgrupo='" + _Cmb_Subgrupo.SelectedValue.ToString() + "'";
            }
            if (_Txt_CodProducto.Text.Trim().Length> 0)
            {
                _Str_SQL += " AND cproducto='" + _Txt_CodProducto.Text.Trim() + "'";
            }
            if (_Txt_CodLote.Text.Trim().Length > 0)
            {
                _Str_SQL += " AND cidproductod='" + _Txt_CodLote.Text.Trim() + "'";
            }
            if (_Bol_Salida_)
            {
                _Str_SQL += " AND unidades>0";
            }
            _Str_SQL += " ORDER BY cproducto ASC,cidproductod DESC";
            Cursor = Cursors.WaitCursor;
            DataSet _Ds_DataSet= Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            _Dtg_Productos.DataSource = _Ds_DataSet.Tables[0].DefaultView;
            _Dtg_Productos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }

        private void _Mtd_BuscarAjusteIntegrado()
        {
            string _Str_SQL = "";
            if (_Bol_Salida_)
                _Str_SQL = "SELECT VST_T3_PRODUCTOLOTECOMPANIA.cproducto,VST_T3_PRODUCTOLOTECOMPANIA.cidproductod,VST_T3_PRODUCTOLOTECOMPANIA.cprecioventamax,VST_T3_PRODUCTOLOTECOMPANIA.cnamefc FROM  VST_T3_PRODUCTOLOTECOMPANIA INNER JOIN TNOTARECEPD ON  VST_T3_PRODUCTOLOTECOMPANIA.ccompany=TNOTARECEPD.ccompany AND VST_T3_PRODUCTOLOTECOMPANIA.cproducto=TNOTARECEPD.cproducto AND VST_T3_PRODUCTOLOTECOMPANIA.cidproductod=TNOTARECEPD.cidproductod WHERE VST_T3_PRODUCTOLOTECOMPANIA.ccompany='" + Frm_Padre._Str_Comp + "' AND TNOTARECEPD.cidnotrecepc='" + _Str_NotaRecepcion + "' AND VST_T3_PRODUCTOLOTECOMPANIA.unidades>0";
            else
                _Str_SQL = "SELECT VST_T3_PRODUCTOLOTECOMPANIA.cproducto,VST_T3_PRODUCTOLOTECOMPANIA.cidproductod,VST_T3_PRODUCTOLOTECOMPANIA.cprecioventamax,VST_T3_PRODUCTOLOTECOMPANIA.cnamefc FROM  VST_T3_PRODUCTOLOTECOMPANIA WHERE VST_T3_PRODUCTOLOTECOMPANIA.ccompany='" + Frm_Padre._Str_Comp + "'";
            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                _Str_SQL += " AND VST_T3_PRODUCTOLOTECOMPANIA.cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "'";
            }
            if (_Cmb_Grupo.SelectedIndex > 0)
            {
                _Str_SQL += " AND VST_T3_PRODUCTOLOTECOMPANIA.cgrupo='" + _Cmb_Grupo.SelectedValue.ToString() + "'";
            }
            if (_Cmb_Subgrupo.SelectedIndex > 0)
            {
                _Str_SQL += " AND VST_T3_PRODUCTOLOTECOMPANIA.csubgrupo='" + _Cmb_Subgrupo.SelectedValue.ToString() + "'";
            }
            if (_Txt_CodProducto.Text.Trim().Length > 0)
            {
                _Str_SQL += " AND VST_T3_PRODUCTOLOTECOMPANIA.cproducto='" + _Txt_CodProducto.Text.Trim() + "'";
            }
            if (_Txt_CodLote.Text.Trim().Length > 0)
            {
                _Str_SQL += " AND VST_T3_PRODUCTOLOTECOMPANIA.cidproductod='" + _Txt_CodLote.Text.Trim() + "'";
            }
            _Str_SQL += " ORDER BY VST_T3_PRODUCTOLOTECOMPANIA.cproducto ASC,VST_T3_PRODUCTOLOTECOMPANIA.cidproductod DESC";
            Cursor = Cursors.WaitCursor;
            DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            _Dtg_Productos.DataSource = _Ds_DataSet.Tables[0].DefaultView;
            _Dtg_Productos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }

        private void _Dtg_Productos_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _Txt_TextBoxCod.Text = _Dtg_Productos.Rows[e.RowIndex].Cells[0].Value.ToString();
            _Txt_TextBoxDes.Text = _Dtg_Productos.Rows[e.RowIndex].Cells[3].Value.ToString();
            _Txt_TextBoxLote.Text = _Dtg_Productos.Rows[e.RowIndex].Cells[1].Value.ToString();
            _Txt_TextBoxPMV.Text = _Dtg_Productos.Rows[e.RowIndex].Cells[2].Value.ToString();
            _Txt_TextBoxCodLote.Text = _Dtg_Productos.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void Frm_BusquedaProductoLote_Load(object sender, EventArgs e)
        {

        }
    }
}
