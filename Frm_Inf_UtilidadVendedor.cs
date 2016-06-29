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
    public partial class Frm_Inf_UtilidadVendedor : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_Variosmetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_UtilidadVendedor()
        {
            InitializeComponent();
            reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_UtilidadVendedores";
            _Mtd_Cargar_Proveedor();
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
        private void _Mtd_Cargar_Proveedor()
        {
            string _Str_Cadena = "select distinct VST_PROVGERAREAVENHISTSINFREGIONAL.cproveedor as cproveedor,VST_PROVGERAREAVENHISTSINFREGIONAL.c_nomb_abreviado as c_nomb_abreviado from VST_PROVGERAREAVENHISTSINFREGIONAL ORDER BY VST_PROVGERAREAVENHISTSINFREGIONAL.c_nomb_abreviado";
            _Cls_Variosmetodos._Mtd_CargarCombo(_Cmb_Proveedor, _Str_Cadena);
        }
        private void _Mtd_Cargar_Grupo(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT distinct dbo.TGRUPPROM.ccodgrupop, dbo.TGRUPPROM.cname " +
             "FROM dbo.TGRUPPROM INNER JOIN " +
             "dbo.TGRUPPROD ON dbo.TGRUPPROM.ccodgrupop = dbo.TGRUPPROD.ccodgrupop AND " +
             "dbo.TGRUPPROM.cdelete = dbo.TGRUPPROD.cdelete INNER JOIN " +
             "dbo.TPRODUCTO ON dbo.TGRUPPROD.cproveedor = dbo.TPRODUCTO.cproveedor AND dbo.TGRUPPROD.ccodgrupop = dbo.TPRODUCTO.cgrupo " +
             "where (TGRUPPROD.cproveedor = '" + _P_Str_Proveedor + "') AND (TGRUPPROM.cdelete = 0) AND (TPRODUCTO.cdelete=0) ORDER BY TGRUPPROM.cname";
            _Cls_Variosmetodos._Mtd_CargarCombo(_Cmb_Grupo, _Str_Cadena);
        }
        private void _Mtd_Cargar_Subgrupo(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            string _Str_Cadena = "SELECT distinct dbo.TSUBGRUPOM.ccodsubgrup, dbo.TSUBGRUPOM.cname " +
              "FROM dbo.TSUBGRUPOM INNER JOIN " +
              "dbo.TSUBGRUPOD ON dbo.TSUBGRUPOM.ccodsubgrup = dbo.TSUBGRUPOD.ccodsubgrup AND " +
              "dbo.TSUBGRUPOM.cdelete = dbo.TSUBGRUPOD.cdelete INNER JOIN " +
              "dbo.TPRODUCTO ON dbo.TSUBGRUPOD.cproveedor = dbo.TPRODUCTO.cproveedor AND " +
              "dbo.TSUBGRUPOD.ccodsubgrup = dbo.TPRODUCTO.csubgrupo AND dbo.TSUBGRUPOD.ccodgrupop = dbo.TPRODUCTO.cgrupo " +
              "where (TSUBGRUPOM.cdelete = 0) AND (TSUBGRUPOD.cproveedor = '" + _P_Str_Proveedor + "') AND (TSUBGRUPOD.ccodgrupop = '" + _P_Str_Grupo + "') AND (TPRODUCTO.cdelete=0) ORDER BY TSUBGRUPOM.cname";
            _Cls_Variosmetodos._Mtd_CargarCombo(_Cmb_Subgrupo, _Str_Cadena);
        }
        private void _Mtd_Cargar_Marca(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            string _Str_Cadena = "SELECT distinct dbo.TMARCASM.cmarca, dbo.TMARCASM.cname " +
            "FROM dbo.TMARCASM INNER JOIN " +
            "dbo.TMARCAS ON dbo.TMARCASM.cmarca = dbo.TMARCAS.cmarca INNER JOIN " +
            "dbo.TPRODUCTO ON dbo.TMARCASM.cmarca = dbo.TPRODUCTO.cmarca " +
            "where (TMARCASM.cdelete = 0) AND (TMARCAS.ccodgrupop = '" + _P_Str_Grupo + "') AND (TMARCAS.cproveedor = '" + _P_Str_Proveedor + "') AND (TPRODUCTO.cdelete=0) ORDER BY TMARCASM.cname";
            _Cls_Variosmetodos._Mtd_CargarCombo(_Cmb_Marca, _Str_Cadena);
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
        private void _Mtd_HabilitarParametros()
        {
            _Mtd_Restablecer();
            if (_Rbt_L_Provee.Checked)
            {
                _Txt_Producto.Enabled = false;
                _Chbox_Grupos.Enabled = false;
                _Chbox_Subgrupos.Enabled = false;
                _Chbox_Marcas.Enabled = false;
            }
            else if (_Rbt_L_Grupo.Checked)
            {
                _Txt_Producto.Enabled = false;
                _Chbox_Grupos.Enabled = true;
                _Chbox_Subgrupos.Enabled = false;
                _Chbox_Marcas.Enabled = false;
            }
            else
            {
                _Txt_Producto.Enabled = true;
                _Chbox_Grupos.Enabled = true;
                _Chbox_Subgrupos.Enabled = true;
                _Chbox_Marcas.Enabled = true;
            }
        }
        private void _Mtd_Busqueda(string _P_Str_Proveedor, string _P_Str_Grupo, string _P_Str_SubGrupo, string _P_Str_Marca, string _P_Str_Producto, string _P_Str_TipoInforme)
        {
            reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[10];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            parm[2] = new ReportParameter("CFECHAI", _Ctrl_ConsultaMes1._Str_FechaInicio);
            parm[3] = new ReportParameter("CFECHAF", _Ctrl_ConsultaMes1._Str_FechaFinal);
            parm[4] = new ReportParameter("CPROVEEDOR", _P_Str_Proveedor);
            parm[5] = new ReportParameter("CPRODUCTO", _P_Str_Producto);
            parm[6] = new ReportParameter("CGRUPO", _P_Str_Grupo);
            parm[7] = new ReportParameter("CSUBGRUPO", _P_Str_SubGrupo);
            parm[8] = new ReportParameter("CMARCA", _P_Str_Marca);
            parm[9] = new ReportParameter("CTIPOINFORME", _P_Str_TipoInforme);
            reportViewer1.ServerReport.SetParameters(parm);
            reportViewer1.ServerReport.Refresh();
            reportViewer1.RefreshReport();
        }
        private void Frm_Inf_UtilidadProvee_Load(object sender, EventArgs e)
        {
            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();
        }

        private void _Rbt_L_Provee_CheckedChanged(object sender, EventArgs e)
        {
            //reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_UtilidadProveedor";
            _Mtd_HabilitarParametros();
        }

        private void _Rbt_L_Grupo_CheckedChanged(object sender, EventArgs e)
        {
            //reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_UtilidadLineaProv";
            _Mtd_HabilitarParametros();
        }
        private void _Rbt_L_Producto_CheckedChanged(object sender, EventArgs e)
        {
            //reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_UtilidadProductos";
            _Mtd_HabilitarParametros();
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

        private void _Bt_Restablecer_Click(object sender, EventArgs e)
        {
            _Mtd_HabilitarParametros();
        }

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            string _Str_Proveedor = "";
            string _Str_Grupo = "";
            string _Str_SubGrupo = "";
            string _Str_Marca = "";
            string _Str_Producto = "";
            string _Str_TipoInforme = "0";
            if (_Rbt_Detallado.Checked)
            {
                _Str_TipoInforme = "1";
            }
            if (_Cmb_Proveedor.SelectedIndex > 0)
            { _Str_Proveedor = _Cmb_Proveedor.SelectedValue.ToString().Trim(); }
            else
            { _Str_Proveedor = "nulo"; }
            //--------------
            if (_Cmb_Grupo.SelectedIndex > 0)
            { _Str_Grupo = _Cmb_Grupo.SelectedValue.ToString().Trim(); }
            else
            { _Str_Grupo = "nulo"; }
            //--------------
            if (_Cmb_Subgrupo.SelectedIndex > 0)
            { _Str_SubGrupo = _Cmb_Subgrupo.SelectedValue.ToString().Trim(); }
            else
            { _Str_SubGrupo = "nulo"; }
            //--------------
            if (_Cmb_Marca.SelectedIndex > 0)
            { _Str_Marca = _Cmb_Marca.SelectedValue.ToString().Trim(); }
            else
            { _Str_Marca = "nulo"; }
            //--------------
            if (_Txt_Producto.Text.Trim().Length > 0)
            { _Str_Producto = _Txt_Producto.Text.Trim(); }
            else
            { _Str_Producto = "nulo"; }
            //--------------
            if (_Ctrl_ConsultaMes1._Bol_Listo)
            {
                this.Cursor = Cursors.WaitCursor;
                _Mtd_Busqueda(_Str_Proveedor, _Str_Grupo, _Str_SubGrupo, _Str_Marca, _Str_Producto, _Str_TipoInforme);
                this.Cursor = Cursors.Default;
            }
            else
            { MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
    }
}