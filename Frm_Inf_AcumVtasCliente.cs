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
    public partial class Frm_Inf_AcumVtasCliente : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_AcumVtasCliente()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_AcumVtasPorCliente";
            _Mtd_ProveedorPorGerente("", "");
            _Mtd_Color_Estandar(this);
        }
        private void _Mtd_Gerentes(string _Str_Compania, string _Str_FechaI, string _Str_FechaF)
        {
            try
            {
                string _Str_SentenciaSQL = "SELECT DISTINCT TVENDEDOR.CVENDEDOR,TVENDEDOR.CVENDEDOR + ' - ' +TVENDEDOR.CNAME AS CNAME FROM THISTVENZONA INNER JOIN TVENDEDOR ON TVENDEDOR.CCOMPANY=THISTVENZONA.CCOMPANY AND TVENDEDOR.CVENDEDOR=THISTVENZONA.CGERAREA WHERE THISTVENZONA.CCOMPANY='" + _Str_Compania + "' AND THISTVENZONA.CFECHAF IS NULL OR THISTVENZONA.CCOMPANY='" + _Str_Compania + "' AND THISTVENZONA.CFECHAF>'" + _Str_FechaI + "'";
                DataSet _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                _myUtilidad._Mtd_CargarCombo(_Cmb_GerArea, _DS_DataSet,"CNAME","CVENDEDOR");
                if (_DS_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Chk_GerArea.Enabled = true;
                    _Chk_GerArea.Checked = false;
                    _Cmb_GerArea.Enabled = true;
                    _Cmb_GerArea.SelectedIndex = -1;
                }
                else
                {
                    _Chk_GerArea.Enabled = false;
                    _Chk_GerArea.Checked = false;
                    _Cmb_GerArea.Enabled = false;
                    _Cmb_GerArea.SelectedIndex = -1;
                }
            }
            catch
            {
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
            string _Str_Cadena = "select distinct VST_PRODUCTOS_A.cproveedor as cproveedor,VST_PRODUCTOS_A.c_nomb_abreviado as c_nomb_abreviado from VST_PRODUCTOS_A where NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE VST_PRODUCTOS_A.cproveedor=TFILTROREGIONALP.cproveedor and VST_PRODUCTOS_A.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') and VST_PRODUCTOS_A.cdelete=0 ORDER BY VST_PRODUCTOS_A.c_nomb_abreviado";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Proveedor, _Str_Cadena);
        }
        private void _Mtd_Cargar_Grupo(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT distinct dbo.TGRUPPROM.ccodgrupop, dbo.TGRUPPROM.cname " +
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
            "where NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE TPRODUCTO.cproveedor=TFILTROREGIONALP.cproveedor and TPRODUCTO.cproducto=TFILTROREGIONALP.cproducto and TPRODUCTO.cmarca=TFILTROREGIONALP.cmarca and TFILTROREGIONALP.ccompany='"+Frm_Padre._Str_Comp+"' and TFILTROREGIONALP.cdelete='0') " +
            "AND (TMARCASM.cdelete = 0) AND (TMARCAS.ccodgrupop = '" + _P_Str_Grupo + "') AND (TMARCAS.cproveedor = '" + _P_Str_Proveedor + "') AND (TPRODUCTO.cdelete=0) ORDER BY TMARCASM.cname";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Marca, _Str_Cadena);
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
            _Chk_TodosLosCliente.Checked = false;
            _Txt_Cliente.Text = "";
            _Chk_Vendedor.Checked = false;
            _Cmb_GerArea.SelectedIndex = -1;
            _Cmb_GerArea.Enabled = false;
            _Cmb_Vendedor.Enabled = false;
            _Cmb_Proveedor.Enabled = false;
            _Chk_GerArea.Checked = false;
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

        private void _Mtd_Busqueda(string _P_Str_Proveedor, string _P_Str_Grupo, string _P_Str_SubGrupo, string _P_Str_Marca, string _P_Str_Producto, string _Str_GerArea, string _Str_Vendedor, string _Str_Cliente)
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] _Rpt_Param = new ReportParameter[12];
            _Rpt_Param[0] = new ReportParameter("CPROVEEDOR", _P_Str_Proveedor);
            _Rpt_Param[1] = new ReportParameter("CGRUPO", _P_Str_Grupo);
            _Rpt_Param[2] = new ReportParameter("CNOMBCOMP", _Mtd_NombComp());
            _Rpt_Param[3] = new ReportParameter("MARCA", _P_Str_Marca);
            _Rpt_Param[4] = new ReportParameter("CSUBGRUPO", _P_Str_SubGrupo);
            _Rpt_Param[5] = new ReportParameter("CPRODUCTO", _P_Str_Producto);
            _Rpt_Param[6] = new ReportParameter("CVENDEDOR", _Str_Vendedor);
            _Rpt_Param[7] = new ReportParameter("CCLIENTE", _Str_Cliente);
            _Rpt_Param[8] = new ReportParameter("CGERAREA", _Str_GerArea);
            _Rpt_Param[9] = new ReportParameter("CFECHAI", _Ctrl_ConsultaMes1._Str_FechaInicio);
            _Rpt_Param[10] = new ReportParameter("CFECHAF", _Ctrl_ConsultaMes1._Str_FechaFinal);
            _Rpt_Param[11] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            _Rpt_Report.ServerReport.SetParameters(_Rpt_Param);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }
        private void Frm_Inf_Productos_Load(object sender, EventArgs e)
        {
            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();
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

        private void _Bt_Restablecer_Click(object sender, EventArgs e)
        {
            _Mtd_Restablecer();
        }

        private void _Cmb_Proveedor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_GerArea = "";
            string _Str_Vendedor = "";
            if (_Cmb_Vendedor.SelectedIndex > 0)
            {
                _Str_Vendedor = _Cmb_Vendedor.SelectedValue.ToString();
            }
            if (_Cmb_GerArea.SelectedIndex > 0)
            {
                _Str_GerArea = _Cmb_GerArea.SelectedValue.ToString();
            }
            _Mtd_ProveedorPorGerente(_Str_GerArea,_Str_Vendedor);
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
            string _Str_Proveedor = "null";
            string _Str_Grupo = "null";
            string _Str_SubGrupo = "null";
            string _Str_Marca = "null";
            string _Str_Producto = "null";
            string _Str_Cliente = "0";
            string _Str_GerArea = "null";
            string _Str_Vendedor = "null";

            if (_Cmb_GerArea.SelectedIndex > 0)
            { _Str_GerArea = _Cmb_GerArea.SelectedValue.ToString().Trim(); }
            else
            { _Str_GerArea = "null"; }
            //--------------
            if (_Cmb_Vendedor.SelectedIndex > 0)
            { _Str_Vendedor = _Cmb_Vendedor.SelectedValue.ToString().Trim(); }
            else
            { _Str_Vendedor = "null"; }
            //--------------
            if (_Txt_Cliente.Text.Trim().Length> 0)
            { _Str_Cliente = _Txt_Cliente.Text.ToString().Trim(); }
            else
            { _Str_Cliente = "0"; }
            //--------------
            if (_Cmb_Proveedor.SelectedIndex > 0)
            { _Str_Proveedor = _Cmb_Proveedor.SelectedValue.ToString().Trim(); }
            else
            { _Str_Proveedor = "null"; }
            //--------------
            if (_Cmb_Grupo.SelectedIndex > 0)
            { _Str_Grupo = _Cmb_Grupo.SelectedValue.ToString().Trim(); }
            else
            { _Str_Grupo = "null"; }
            //--------------
            if (_Cmb_Subgrupo.SelectedIndex > 0)
            { _Str_SubGrupo = _Cmb_Subgrupo.SelectedValue.ToString().Trim(); }
            else
            { _Str_SubGrupo = "null"; }
            //--------------
            if (_Cmb_Marca.SelectedIndex > 0)
            { _Str_Marca = _Cmb_Marca.SelectedValue.ToString().Trim(); }
            else
            { _Str_Marca = "null"; }
            //--------------
            if (_Txt_Producto.Text.Trim().Length > 0)
            { _Str_Producto = _Txt_Producto.Text.Trim(); }
            else
            { _Str_Producto = "null"; }
            //--------------
            if (_Ctrl_ConsultaMes1._Bol_Listo)
            {
                this.Cursor = Cursors.WaitCursor;
                _Mtd_Busqueda(_Str_Proveedor, _Str_Grupo, _Str_SubGrupo, _Str_Marca, _Str_Producto, _Str_GerArea, _Str_Vendedor, _Str_Cliente);
                this.Cursor = Cursors.Default;
            }
            else
            { MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Btn_VerGerentes_Click(object sender, EventArgs e)
        {
            if (_Ctrl_ConsultaMes1._Bol_Listo)
            {
                _Mtd_Gerentes(Frm_Padre._Str_Comp, _Ctrl_ConsultaMes1._Str_FechaInicio, _Ctrl_ConsultaMes1._Str_FechaFinal);
            }
            else
            { MessageBox.Show("Debe seleccionar un año y un mes para realizar la operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Cmb_GerArea_DropDown(object sender, EventArgs e)
        {
            if (_Ctrl_ConsultaMes1._Bol_Listo)
            {
                _Mtd_Gerentes(Frm_Padre._Str_Comp, _Ctrl_ConsultaMes1._Str_FechaInicio, _Ctrl_ConsultaMes1._Str_FechaFinal);
            }
            else
            { MessageBox.Show("Debe seleccionar un año y un mes para realizar la operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Cmb_GerArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_GerArea.SelectedIndex > 0)
            {                
                _Chk_GerArea.Checked = true;
                _Cmb_Vendedor.Enabled = true;
                _Chk_Vendedor.Enabled = true;
                _Cmb_Vendedor.SelectedIndex = -1;
                _Mtd_ProveedorPorGerente(_Cmb_GerArea.SelectedValue.ToString(), "");
                if (_Ctrl_ConsultaMes1._Bol_Listo)
                {
                    _Mtd_VerVendedores(_Cmb_GerArea.SelectedValue.ToString(), _Ctrl_ConsultaMes1._Str_FechaInicio, _Ctrl_ConsultaMes1._Str_FechaFinal);
                }
                else
                { MessageBox.Show("Debe seleccionar un año y un mes para realizar la operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else
            {
                _Chk_Vendedor.Checked = false;
                _Cmb_Vendedor.DataSource = null;
                _Cmb_Vendedor.Enabled = false;
            }
        }
        private void _Mtd_VerVendedores(string _Str_GerArea, string _Str_FechaI, string _Str_FechaF)
        {
            try
            {
                if (_Str_GerArea != "nulo")
                {
                    string _Str_SentenciaSQL = "SELECT DISTINCT TVENDEDOR.CVENDEDOR,TVENDEDOR.CVENDEDOR + ' - ' +TVENDEDOR.CNAME AS CNAME,CONVERT(NUMERIC(18,0),REPLACE(REPLACE(TVENDEDOR.CVENDEDOR,'_',''),RTRIM(TVENDEDOR.CCOMPANY),'')) AS Cod FROM TVENDEDOR INNER JOIN THISTVENZONA ON TVENDEDOR.CCOMPANY=THISTVENZONA.CCOMPANY AND TVENDEDOR.CVENDEDOR=THISTVENZONA.CVENDEDOR WHERE THISTVENZONA.CGERAREA='" + _Str_GerArea + "' AND THISTVENZONA.CCOMPANY='" + Frm_Padre._Str_Comp + "' AND THISTVENZONA.CFECHAF IS NULL OR THISTVENZONA.CCOMPANY='" + Frm_Padre._Str_Comp + "' AND THISTVENZONA.CFECHAF>'" + _Str_FechaI + "' AND THISTVENZONA.CGERAREA='" + _Str_GerArea + "' ORDER BY Cod";
                    DataSet _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                    _myUtilidad._Mtd_CargarCombo(_Cmb_Vendedor, _DS_DataSet, "CNAME", "CVENDEDOR");
                }
            }
            catch
            {
            }
        }
        private void _Cmb_Vendedor_DropDown(object sender, EventArgs e)
        {
            if (_Ctrl_ConsultaMes1._Bol_Listo)
            {
                _Mtd_VerVendedores(_Cmb_GerArea.SelectedValue.ToString(), _Ctrl_ConsultaMes1._Str_FechaInicio, _Ctrl_ConsultaMes1._Str_FechaFinal);
            }
            else
            { MessageBox.Show("Debe seleccionar un año y un mes para realizar la operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private void _Mtd_ProveedorPorGerente(string _Str_GerArea, string _Str_Vendedor)
        {
            try
            {
                string _Str_SentenciaSQL = "";
                if (_Str_GerArea != "")
                {
                    if (_Str_Vendedor != "")
                    {
                        _Str_SentenciaSQL = "select distinct VST_PROVGERAREAVENHISTSINFREGIONAL.c_nomb_abreviado as c_nomb_abreviado,VST_PROVGERAREAVENHISTSINFREGIONAL.cproveedor as cproveedor from VST_PROVGERAREAVENHISTSINFREGIONAL WHERE VST_PROVGERAREAVENHISTSINFREGIONAL.ccompany='" + Frm_Padre._Str_Comp + "' and VST_PROVGERAREAVENHISTSINFREGIONAL.cgerarea='" + _Str_GerArea + "' and VST_PROVGERAREAVENHISTSINFREGIONAL.cvendedor='" + _Str_Vendedor + "'";
                    }
                    else
                    {
                        _Str_SentenciaSQL = "select distinct VST_PROVGERAREAVENHISTSINFREGIONAL.c_nomb_abreviado as c_nomb_abreviado,VST_PROVGERAREAVENHISTSINFREGIONAL.cproveedor as cproveedor from VST_PROVGERAREAVENHISTSINFREGIONAL WHERE VST_PROVGERAREAVENHISTSINFREGIONAL.ccompany='" + Frm_Padre._Str_Comp + "' and VST_PROVGERAREAVENHISTSINFREGIONAL.cgerarea='" + _Str_GerArea + "'";
                    }
                }
                else
                {
                    _Str_SentenciaSQL = "select distinct VST_PROVGERAREAVENHISTSINFREGIONAL.c_nomb_abreviado as c_nomb_abreviado,VST_PROVGERAREAVENHISTSINFREGIONAL.cproveedor as cproveedor from VST_PROVGERAREAVENHISTSINFREGIONAL WHERE VST_PROVGERAREAVENHISTSINFREGIONAL.ccompany='" + Frm_Padre._Str_Comp + "'";
                }
                DataSet _Ds_ = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                _myUtilidad._Mtd_CargarCombo(_Cmb_Proveedor, _Ds_, "c_nomb_abreviado", "cproveedor");
                if (_Ds_.Tables[0].Rows.Count > 0)
                {
                    _Cmb_Proveedor.Enabled = true;
                }
                else
                {

                }
            }
            catch (Exception ou)
            {
                string error = ou.Message.ToString();
            }
        }
        private void _Cmb_Vendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Vendedor.SelectedIndex > 0)
            {
                _Chk_Vendedor.CheckedChanged -= new EventHandler(_Chk_Vendedor_CheckedChanged);
                _Chk_Vendedor.Checked = true;
                _Chk_Vendedor.CheckedChanged += new EventHandler(_Chk_Vendedor_CheckedChanged);
                _Mtd_ProveedorPorGerente(_Cmb_GerArea.SelectedValue.ToString(), _Cmb_Vendedor.SelectedValue.ToString());
            }
            else
            {
                _Chk_Vendedor.CheckedChanged -= new EventHandler(_Chk_Vendedor_CheckedChanged);
                _Chk_Vendedor.Checked = false;
                _Chk_Vendedor.CheckedChanged += new EventHandler(_Chk_Vendedor_CheckedChanged);
            }
            if (_Cmb_Vendedor.SelectedIndex > 0)
            {
                _Mtd_ProveedorPorGerente(_Cmb_GerArea.SelectedValue.ToString(), _Cmb_Vendedor.SelectedValue.ToString());
            }
        }

        private void _Btn_BuscarCliente_Click(object sender, EventArgs e)
        {
            if (_Ctrl_ConsultaMes1._Bol_Listo)
            {
                string _Str_Gerente = "nulo";
                string _Str_Vendedor = "nulo";
                string _Str_Where = " AND (CFECHAF IS NULL OR CFECHAF>'" + _Ctrl_ConsultaMes1._Str_FechaInicio + "') AND (CFECHAFCLI IS NULL OR CFECHAFCLI>'" + _Ctrl_ConsultaMes1._Str_FechaInicio + "')";
                if (_Cmb_GerArea.SelectedIndex > 0)
                {
                    _Str_Gerente = _Cmb_GerArea.SelectedValue.ToString();
                    _Str_Where += " AND CGERAREA='" + _Str_Gerente + "'";
                }
                if (_Cmb_Vendedor.SelectedIndex > 0)
                {
                    _Str_Vendedor = _Cmb_Vendedor.SelectedValue.ToString();
                    _Str_Where += " AND cvendedor='" + _Str_Vendedor + "'";
                }
                Frm_Busqueda2 _Frm_Busq = new Frm_Busqueda2(59, _Txt_Cliente, 0, _Str_Where);
                _Frm_Busq.ShowDialog();
                _Chk_TodosLosCliente.CheckedChanged -= new EventHandler(_Chk_TodosLosCliente_CheckedChanged);
                _Chk_TodosLosCliente.Checked = false;
                _Chk_TodosLosCliente.CheckedChanged += new EventHandler(_Chk_TodosLosCliente_CheckedChanged);

            }
            else
            { MessageBox.Show("Debe seleccionar un año y un mes para realizar la operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Chk_TodosLosCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chk_TodosLosCliente.Checked)
            {
                _Txt_Cliente.Text = "";
            }
        }

        private void _Chk_Vendedor_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chk_Vendedor.Checked & _Cmb_GerArea.SelectedIndex>0 & _Ctrl_ConsultaMes1._Bol_Listo)
            { _Cmb_Vendedor.Enabled = true; _Mtd_VerVendedores(_Cmb_GerArea.SelectedValue.ToString(), _Ctrl_ConsultaMes1._Str_FechaInicio, _Ctrl_ConsultaMes1._Str_FechaFinal); }
            else
            { _Cmb_Vendedor.Enabled = false; _Cmb_Vendedor.SelectedIndex = -1; }
        }
    }
}