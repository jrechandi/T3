using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace T3
{
    public partial class Frm_Inf_InventarioSica : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VarioMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_Inf_InventarioSica()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_InventarioSica";
            _Mtd_Rubros();
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
        private void _Mtd_Cargar_Proveedor(string _P_Str_Rubro)
        {
            string _Str_Cadena = "select distinct VST_PRODUCTOS_A.cproveedor as cproveedor,VST_PRODUCTOS_A.c_nomb_abreviado as c_nomb_abreviado from VST_PRODUCTOS_A INNER JOIN TSICARUBROSD ON TSICARUBROSD.CPRODUCTO=VST_PRODUCTOS_A.CPRODUCTO WHERE TSICARUBROSD.ccodigorubro='" + _P_Str_Rubro + "' AND TSICARUBROSD.CDELETE='0' AND VST_PRODUCTOS_A.companyprov='" + Frm_Padre._Str_Comp + "' AND NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE VST_PRODUCTOS_A.cproveedor=TFILTROREGIONALP.cproveedor and VST_PRODUCTOS_A.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') and VST_PRODUCTOS_A.cdelete=0 ORDER BY VST_PRODUCTOS_A.c_nomb_abreviado";
            _Cls_VarioMetodos._Mtd_CargarCombo(_Cmb_Proveedor, _Str_Cadena);
        }
        private void _Mtd_Cargar_Grupo(string _P_Str_Proveedor, string _Str_Rubro)
        {
            string _Str_Cadena = "SELECT distinct dbo.TGRUPPROM.ccodgrupop, dbo.TGRUPPROM.cname " +
            "FROM dbo.TGRUPPROM INNER JOIN " +
            "dbo.TGRUPPROD ON dbo.TGRUPPROM.ccodgrupop = dbo.TGRUPPROD.ccodgrupop AND " +
            "dbo.TGRUPPROM.cdelete = dbo.TGRUPPROD.cdelete INNER JOIN " +
            "dbo.TPRODUCTO ON dbo.TGRUPPROD.cproveedor = dbo.TPRODUCTO.cproveedor AND dbo.TGRUPPROD.ccodgrupop = dbo.TPRODUCTO.cgrupo " +
            " INNER JOIN TSICARUBROSD ON TSICARUBROSD.CPRODUCTO=TPRODUCTO.CPRODUCTO WHERE TSICARUBROSD.CDELETE='0' AND TSICARUBROSD.ccodigorubro='" + _Str_Rubro + "' AND NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE TGRUPPROD.cproveedor=TFILTROREGIONALP.cproveedor and TPRODUCTO.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') " +
            "AND (TGRUPPROD.cproveedor = '" + _P_Str_Proveedor + "') AND (TGRUPPROM.cdelete = 0) AND (TPRODUCTO.cdelete=0) ORDER BY TGRUPPROM.cname";
            _Cls_VarioMetodos._Mtd_CargarCombo(_Cmb_Grupo, _Str_Cadena);
        }
        private void _Mtd_Cargar_Subgrupo(string _P_Str_Proveedor, string _P_Str_Grupo, string _Str_Rubro)
        {
            string _Str_Cadena = "SELECT distinct dbo.TSUBGRUPOM.ccodsubgrup, dbo.TSUBGRUPOM.cname " +
            "FROM dbo.TSUBGRUPOM INNER JOIN " +
            "dbo.TSUBGRUPOD ON dbo.TSUBGRUPOM.ccodsubgrup = dbo.TSUBGRUPOD.ccodsubgrup AND " +
            "dbo.TSUBGRUPOM.cdelete = dbo.TSUBGRUPOD.cdelete INNER JOIN " +
            "dbo.TPRODUCTO ON dbo.TSUBGRUPOD.cproveedor = dbo.TPRODUCTO.cproveedor AND " +
            "dbo.TSUBGRUPOD.ccodsubgrup = dbo.TPRODUCTO.csubgrupo AND dbo.TSUBGRUPOD.ccodgrupop = dbo.TPRODUCTO.cgrupo " +
            " INNER JOIN TSICARUBROSD ON TSICARUBROSD.CPRODUCTO=TPRODUCTO.CPRODUCTO where TSICARUBROSD.CDELETE='0' AND TSICARUBROSD.ccodigorubro='" + _Str_Rubro + "' AND NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE TPRODUCTO.cproveedor=TFILTROREGIONALP.cproveedor and TPRODUCTO.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') " +
            "AND (TSUBGRUPOM.cdelete = 0) AND (TSUBGRUPOD.cproveedor = '" + _P_Str_Proveedor + "') AND (TSUBGRUPOD.ccodgrupop = '" + _P_Str_Grupo + "') AND (TPRODUCTO.cdelete=0) ORDER BY TSUBGRUPOM.cname";
            _Cls_VarioMetodos._Mtd_CargarCombo(_Cmb_Subgrupo, _Str_Cadena);
        }
        private void _Mtd_Restablecer()
        {
            _Txt_Producto.Text = "";
            if (_Chk_Rubro.Enabled)
            {
                _Chk_Rubro.Checked = false;
                _Cmb_RubroSica.Enabled = true;
            }
            _Chbox_Proveedores.Checked = false;
            _Chbox_Grupos.Checked = false;
            _Chbox_Subgrupos.Checked = false;
            _Chk_Rubro.Checked = false;
        }

        private void _Chbox_Proveedores_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Proveedores.Checked)
            { _Cmb_Proveedor.Enabled = true; _Mtd_Cargar_Proveedor(_Cmb_RubroSica.SelectedValue.ToString()); }
            else
            { _Cmb_Proveedor.Enabled = false; _Cmb_Proveedor.SelectedIndex = -1; }
        }

        private void _Chbox_Grupos_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Grupos.Checked && _Cmb_Proveedor.SelectedIndex > 0)
            {
                _Cmb_Grupo.Enabled = true;
                _Mtd_Cargar_Grupo(_Cmb_Proveedor.SelectedValue.ToString(), _Cmb_RubroSica.SelectedValue.ToString());
            }
            else
            { _Cmb_Grupo.Enabled = false; _Cmb_Grupo.SelectedIndex = -1; }
        }

        private void _Chbox_Subgrupos_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Subgrupos.Checked)
            {
                if (_Cmb_Proveedor.SelectedIndex > 0 && _Cmb_Grupo.SelectedIndex > 0)
                {
                    _Cmb_Subgrupo.Enabled = true;
                    _Mtd_Cargar_Subgrupo(_Cmb_Proveedor.SelectedValue.ToString(), _Cmb_Grupo.SelectedValue.ToString(), _Cmb_RubroSica.SelectedValue.ToString());
                }
            }
            else
            { _Cmb_Subgrupo.Enabled = false; _Cmb_Subgrupo.SelectedIndex = -1; }
        }
        private void _Mtd_Rubros()
        {
            try
            {
                string _Str_Cadena = "SELECT ccodigorubro,upper(cnombre) as cnombre  FROM TSICARUBROSM WHERE CDELETE='0' ORDER BY CNOMBRE ASC";
                _Cls_VarioMetodos._Mtd_CargarCombo(_Cmb_RubroSica, _Str_Cadena);
            }
            catch (Exception _Exc_Error)
            {

            }
        }

        private void _Cmb_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                _Chbox_Proveedores.CheckedChanged -= new EventHandler(_Chbox_Proveedores_CheckedChanged);
                _Chbox_Proveedores.Checked = true;
                _Chbox_Proveedores.CheckedChanged += new EventHandler(_Chbox_Proveedores_CheckedChanged);
                _Cmb_Grupo.Enabled = true;
                _Cmb_Grupo.DataSource = null;
                _Cmb_Subgrupo.DataSource = null;
            }
            else
            {
                _Chbox_Grupos.Checked = false;
                _Cmb_Grupo.DataSource = null;
                _Cmb_Grupo.Enabled = false;
                _Chbox_Subgrupos.Checked = false;
                _Cmb_Subgrupo.DataSource = null;
                _Cmb_Subgrupo.Enabled = false;
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
                _Cmb_Subgrupo.DataSource = null;
            }
            else
            {
                _Chbox_Subgrupos.Checked = false;
                _Cmb_Subgrupo.DataSource = null;
                _Cmb_Subgrupo.Enabled = false;
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

        private void _Cmb_Proveedor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_Cargar_Proveedor(_Cmb_RubroSica.SelectedValue.ToString());
            this.Cursor = Cursors.Default;
        }

        private void _Cmb_Grupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                _Mtd_Cargar_Grupo(_Cmb_Proveedor.SelectedValue.ToString(), _Cmb_RubroSica.SelectedValue.ToString());
            }
            this.Cursor = Cursors.Default;
        }

        private void _Cmb_Subgrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (_Cmb_Proveedor.SelectedIndex > 0 && _Cmb_Grupo.SelectedIndex > 0)
            {
                _Mtd_Cargar_Subgrupo(_Cmb_Proveedor.SelectedValue.ToString(), _Cmb_Grupo.SelectedValue.ToString(), _Cmb_RubroSica.SelectedValue.ToString());
            }
            this.Cursor = Cursors.Default;
        }

        private void _Cbm_RubroSica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_RubroSica.SelectedIndex > 0)
            {
                _Chk_Rubro.CheckedChanged -= new EventHandler(_Chk_Rubro_CheckedChanged);
                _Chk_Rubro.Checked = true;
                _Chk_Rubro.CheckedChanged += new EventHandler(_Chk_Rubro_CheckedChanged);
                _Cmb_Proveedor.Enabled = true;
                _Cmb_Proveedor.DataSource = null;
                _Cmb_Grupo.DataSource = null;
                _Cmb_Subgrupo.DataSource = null;
            }
            else
            {
                _Chbox_Proveedores.Checked = false;
                _Cmb_Proveedor.DataSource = null;
                _Cmb_Proveedor.Enabled = false;
                _Chbox_Grupos.Checked = false;
                _Cmb_Grupo.DataSource = null;
                _Cmb_Grupo.Enabled = false;
                _Chbox_Subgrupos.Checked = false;
                _Cmb_Subgrupo.DataSource = null;
                _Cmb_Subgrupo.Enabled = false;
            }
        }

        private void _Chk_Rubro_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chk_Rubro.Checked)
            { _Cmb_RubroSica.Enabled = true; _Mtd_Rubros(); }
            else
            { _Cmb_RubroSica.Enabled = false; _Cmb_RubroSica.SelectedIndex = -1; }
        }

        private void _Bt_Restablecer_Click(object sender, EventArgs e)
        {
            _Mtd_Restablecer();
        }
        private string _Mtd_NombComp()
        {
            string _Str_Cadena = "Select cname from dbo.TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
            }
            return "";
        }
        private void _Mtd_Busqueda(string _P_Str_Proveedor, string _P_Str_Grupo, string _P_Str_SubGrupo, string _P_Str_Producto, string _P_Str_Rubro, string _P_Str_TipoReporte)
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[8];
            parm[0] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            parm[1] = new ReportParameter("CPROVEEDOR", _P_Str_Proveedor);
            parm[2] = new ReportParameter("CGRUPO", _P_Str_Grupo);
            parm[3] = new ReportParameter("CSUBGRUPO", _P_Str_SubGrupo);
            parm[4] = new ReportParameter("CPRODUCTO", _P_Str_Producto);
            parm[5] = new ReportParameter("CIDSICARUBROM", _P_Str_Rubro);
            parm[6] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[7] = new ReportParameter("CTIPOREPORTE", _P_Str_TipoReporte);
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }
        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            string _Str_Proveedor = "null";
            string _Str_Grupo = "null";
            string _Str_SubGrupo = "null";
            string _Str_Producto = "null";
            string _Str_Rubro = "0";
            if (_Cmb_Proveedor.SelectedIndex > 0)
            { _Str_Proveedor = _Cmb_Proveedor.SelectedValue.ToString().Trim(); }
            //--------------
            if (_Cmb_Grupo.SelectedIndex > 0)
            { _Str_Grupo = _Cmb_Grupo.SelectedValue.ToString().Trim(); }
            //--------------
            if (_Cmb_Subgrupo.SelectedIndex > 0)
            { _Str_SubGrupo = _Cmb_Subgrupo.SelectedValue.ToString().Trim(); }
            //--------------
            if (_Txt_Producto.Text.Trim().Length > 0)
            { _Str_Producto = _Txt_Producto.Text.Trim(); }
            //--------------
            if (_Chk_Rubro.Checked)
            {
                if (_Cmb_RubroSica.SelectedIndex > 0)
                {
                    _Str_Rubro = _Cmb_RubroSica.SelectedValue.ToString().Trim();
                }
            }
            string _Str_TipoReporte = "1";
            if (_Chk_Detallado.Checked)
            {
                _Str_TipoReporte = "0";
            }
            //--------------
            this.Cursor = Cursors.WaitCursor;
            _Mtd_Busqueda(_Str_Proveedor, _Str_Grupo, _Str_SubGrupo, _Str_Producto, _Str_Rubro, _Str_TipoReporte);
            this.Cursor = Cursors.Default;
        }

        private void _Cbm_RubroSica_DropDown(object sender, EventArgs e)
        {
            _Mtd_Rubros();
        }
    }
}
