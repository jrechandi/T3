using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace T3
{
    public partial class Frm_Inf_AnalisisCompInv : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_AnalisisCompInv()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_InfAnalisisCompInv";
            _Mtd_Cargar_Proveedor();
            _Mtd_Color_Estandar(this);
            _Bt_Generar.Enabled = _myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_GENERAR_PREORDEN");
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
            string _Str_Cadena = "SELECT DISTINCT VST_PRODUCTOS_A.cproveedor as cproveedor,VST_PRODUCTOS_A.c_nomb_abreviado as c_nomb_abreviado FROM VST_PRODUCTOS_A WHERE NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE VST_PRODUCTOS_A.cproveedor=TFILTROREGIONALP.cproveedor and VST_PRODUCTOS_A.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') AND VST_PRODUCTOS_A.companyprov='" + Frm_Padre._Str_Comp + "' and VST_PRODUCTOS_A.cdelete=0 ORDER BY VST_PRODUCTOS_A.c_nomb_abreviado";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Proveedor, _Str_Cadena);
        }
        private void _Mtd_Cargar_Grupo(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT distinct dbo.TGRUPPROM.ccodgrupop, dbo.TGRUPPROM.cname " +
            "FROM dbo.TGRUPPROM INNER JOIN " +
            "dbo.TGRUPPROD ON dbo.TGRUPPROM.ccodgrupop = dbo.TGRUPPROD.ccodgrupop AND " +
            "dbo.TGRUPPROM.cdelete = dbo.TGRUPPROD.cdelete INNER JOIN " +
            "dbo.TPRODUCTO ON dbo.TGRUPPROD.cproveedor = dbo.TPRODUCTO.cproveedor AND dbo.TGRUPPROD.ccodgrupop = dbo.TPRODUCTO.cgrupo " +
            "where NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE TGRUPPROD.cproveedor=TFILTROREGIONALP.cproveedor and TPRODUCTO.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='"+Frm_Padre._Str_Comp+"' and TFILTROREGIONALP.cdelete='0') " +
            "AND (TGRUPPROD.cproveedor = '" + _P_Str_Proveedor + "') AND (TGRUPPROM.cdelete = 0) AND (TPRODUCTO.cdelete=0) ORDER BY TGRUPPROM.cname";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Grupo, _Str_Cadena);
        }
        private void _Mtd_Cargar_Subgrupo(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            string _Str_Cadena = "SELECT distinct dbo.TSUBGRUPOM.ccodsubgrup, dbo.TSUBGRUPOM.cname " +
            "FROM dbo.TSUBGRUPOM INNER JOIN " +
            "dbo.TSUBGRUPOD ON dbo.TSUBGRUPOM.ccodsubgrup = dbo.TSUBGRUPOD.ccodsubgrup AND " +
            "dbo.TSUBGRUPOM.cdelete = dbo.TSUBGRUPOD.cdelete INNER JOIN " +
            "dbo.TPRODUCTO ON dbo.TSUBGRUPOD.cproveedor = dbo.TPRODUCTO.cproveedor AND " +
            "dbo.TSUBGRUPOD.ccodsubgrup = dbo.TPRODUCTO.csubgrupo AND dbo.TSUBGRUPOD.ccodgrupop = dbo.TPRODUCTO.cgrupo " +
            "where NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE TPRODUCTO.cproveedor=TFILTROREGIONALP.cproveedor and TPRODUCTO.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') " +
            "AND (TSUBGRUPOM.cdelete = 0) AND (TSUBGRUPOD.cproveedor = '" + _P_Str_Proveedor + "') AND (TSUBGRUPOD.ccodgrupop = '" + _P_Str_Grupo + "') AND (TPRODUCTO.cdelete=0) ORDER BY TSUBGRUPOM.cname";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Subgrupo, _Str_Cadena);
        }
        private void _Mtd_Cargar_Marca(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            string _Str_Cadena = "SELECT distinct dbo.TMARCASM.cmarca, dbo.TMARCASM.cname " +
            "FROM dbo.TMARCASM INNER JOIN " +
            "dbo.TMARCAS ON dbo.TMARCASM.cmarca = dbo.TMARCAS.cmarca INNER JOIN " +
            "dbo.TPRODUCTO ON dbo.TMARCASM.cmarca = dbo.TPRODUCTO.cmarca " +
            "where NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE TPRODUCTO.cproveedor=TFILTROREGIONALP.cproveedor and TPRODUCTO.cproducto=TFILTROREGIONALP.cproducto and TPRODUCTO.cmarca=TFILTROREGIONALP.cmarca and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') " +
            "AND (TMARCASM.cdelete = 0) AND (TMARCAS.ccodgrupop = '" + _P_Str_Grupo + "') AND (TMARCAS.cproveedor = '" + _P_Str_Proveedor + "') AND (TPRODUCTO.cdelete=0) ORDER BY TMARCASM.cname";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Marca, _Str_Cadena);
        }
        private void _Mtd_Cargar_Estratificacion(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT TESTRATABCDM.cestratificacion,TESTRATABCDM.cestratificacion FROM TESTRATABCDD INNER JOIN TESTRATABCDM ON TESTRATABCDD.cestratificacion = TESTRATABCDM.cestratificacion WHERE TESTRATABCDD.ccompany = '" + Frm_Padre._Str_Comp + "' AND TESTRATABCDD.cproveedor = '" + _P_Str_Proveedor + "'";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Estratificacion, _Str_Cadena);
        }
        private void _Mtd_Restablecer()
        {
            _Txt_Producto.Text = "";
            if (_Chbox_Proveedores.Enabled)
            {
                _Chbox_Proveedores.Checked = false;
                _Cmb_Proveedor.Enabled = true;
            }
            _Chbox_Grupos.Checked = false;
            _Chbox_Subgrupos.Checked = false;
            _Chbox_Marcas.Checked = false;
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
        private void _Mtd_Busqueda(string _P_Str_Proveedor, string _P_Str_Grupo, string _P_Str_SubGrupo, string _P_Str_Marca, string _P_Str_Producto, string _P_Str_Estratificacion)
        {
            ReportParameter[] parm = new ReportParameter[8];
            parm[0] = new ReportParameter("CPROVEEDOR", _P_Str_Proveedor);
            parm[1] = new ReportParameter("CPRODUCTO", _P_Str_Producto);
            parm[2] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            parm[3] = new ReportParameter("CGRUPO", _P_Str_Grupo);
            parm[4] = new ReportParameter("CSUBGRUPO", _P_Str_SubGrupo);
            parm[5] = new ReportParameter("CMARCA", _P_Str_Marca);
            parm[6] = new ReportParameter("CESTRATIFICACION", _P_Str_Estratificacion);
            parm[7] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }

        private void Frm_Inf_Productos_Load(object sender, EventArgs e)
        {

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
            if (_Chbox_Grupos.Checked && _Cmb_Proveedor.SelectedIndex > 0)
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
                if (_Cmb_Proveedor.SelectedIndex > 0 && _Cmb_Grupo.SelectedIndex > 0)
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
                if (_Cmb_Proveedor.SelectedIndex > 0 && _Cmb_Grupo.SelectedIndex > 0)
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
            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                _Chbox_Proveedores.CheckedChanged -= new EventHandler(_Chbox_Proveedores_CheckedChanged);
                _Chbox_Proveedores.Checked = true;
                _Chbox_Proveedores.CheckedChanged += new EventHandler(_Chbox_Proveedores_CheckedChanged);
                _Cmb_Grupo.Enabled = true;
                _Cmb_Estratificacion.Enabled = true;
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
                _Chk_Estra.Checked = false;
                _Cmb_Estratificacion.DataSource = null;
                _Cmb_Estratificacion.Enabled = false;
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

        private void _Bt_Restablecer_Click(object sender, EventArgs e)
        {
            _Mtd_Restablecer();
        }

        private void _Cmb_Proveedor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_Cargar_Proveedor();
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

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            string _Str_Proveedor = "nulo";
            string _Str_Grupo = "nulo";
            string _Str_SubGrupo = "nulo";
            string _Str_Marca = "nulo";
            string _Str_Producto = "nulo";
            string _Str_Estratificacion = "nulo";
            if (_Cmb_Proveedor.SelectedIndex>0)
            { _Str_Proveedor = _Cmb_Proveedor.SelectedValue.ToString().Trim(); }
            //--------------
            if (_Cmb_Grupo.SelectedIndex > 0)
            { _Str_Grupo = _Cmb_Grupo.SelectedValue.ToString().Trim(); }
            //--------------
            if (_Cmb_Subgrupo.SelectedIndex > 0)
            { _Str_SubGrupo = _Cmb_Subgrupo.SelectedValue.ToString().Trim(); }
            //--------------
            if (_Cmb_Marca.SelectedIndex > 0)
            { _Str_Marca = _Cmb_Marca.SelectedValue.ToString().Trim(); }
            //--------------
            if (_Txt_Producto.Text.Trim().Length > 0)
            { _Str_Producto = _Txt_Producto.Text.Trim(); }
            //--------------
            if (_Cmb_Estratificacion.SelectedIndex > 0)
            { _Str_Estratificacion = _Cmb_Estratificacion.SelectedValue.ToString().Trim(); }
            this.Cursor = Cursors.WaitCursor;
            _Mtd_Busqueda(_Str_Proveedor, _Str_Grupo, _Str_SubGrupo, _Str_Marca, _Str_Producto, _Str_Estratificacion);
            this.Cursor = Cursors.Default;
        }

        private void _Chk_Estra_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chk_Estra.Checked && _Cmb_Proveedor.SelectedIndex > 0)
            {
                _Cmb_Estratificacion.Enabled = true;
                _Mtd_Cargar_Estratificacion(_Cmb_Proveedor.SelectedValue.ToString());
            }
            else
            { _Cmb_Estratificacion.Enabled = false; _Cmb_Estratificacion.SelectedIndex = -1; }
        }

        private void _Bt_Generar_Click(object sender, EventArgs e)
        {
            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                string _Str_Proveedor = "nulo";
                string _Str_Grupo = "nulo";
                string _Str_SubGrupo = "nulo";
                string _Str_Marca = "nulo";
                string _Str_Producto = "nulo";
                string _Str_Estratificacion = "nulo";
                if (_Cmb_Proveedor.SelectedIndex > 0)
                { _Str_Proveedor = _Cmb_Proveedor.SelectedValue.ToString().Trim(); }
                //--------------
                if (_Cmb_Grupo.SelectedIndex > 0)
                { _Str_Grupo = _Cmb_Grupo.SelectedValue.ToString().Trim(); }
                //--------------
                if (_Cmb_Subgrupo.SelectedIndex > 0)
                { _Str_SubGrupo = _Cmb_Subgrupo.SelectedValue.ToString().Trim(); }
                //--------------
                if (_Cmb_Marca.SelectedIndex > 0)
                { _Str_Marca = _Cmb_Marca.SelectedValue.ToString().Trim(); }
                //--------------
                if (_Txt_Producto.Text.Trim().Length > 0)
                { _Str_Producto = _Txt_Producto.Text.Trim(); }
                //--------------
                if (_Cmb_Estratificacion.SelectedIndex > 0)
                { _Str_Estratificacion = _Cmb_Estratificacion.SelectedValue.ToString().Trim(); }
                Cursor = Cursors.WaitCursor;
                Frm_PreOrden _Frm = new Frm_PreOrden(_Str_Proveedor, _Str_Grupo, _Str_SubGrupo, _Str_Marca, _Str_Producto, _Str_Estratificacion);
                Cursor = Cursors.Default;
                _Frm.MdiParent = this.MdiParent;
                _Frm.Dock = DockStyle.Fill;
                _Frm.Show();
            }
            else
            { MessageBox.Show("Debe elegir un proveedor para realizar la operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Cmb_Estratificacion_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                _Mtd_Cargar_Estratificacion(_Cmb_Proveedor.SelectedValue.ToString());
            }
            this.Cursor = Cursors.Default;
        }
    }
}