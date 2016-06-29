using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace T3
{
    public partial class Frm_ConsMovInventario : Form
    {
        bool _G_Bol_CargaSw = false;
        CLASES._Cls_Varios_Metodos _MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_ConsMovInventario()
        {
            InitializeComponent();
            _Mtd_Color_Estandar(this);
            _Dtp_FechDesde.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dtp_FechHasta.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().AddDays(1);
            _Mtd_Cargar_Proveedor();
            _Cmb_Proveedor.Enabled = false;
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
            string _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor,UPPER(TPROVEEDOR.c_nomb_abreviado) as c_nomb_abreviado FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND ((cglobal='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "')) order by c_nomb_abreviado";
            _MyUtilidad._Mtd_CargarCombo(_Cmb_Proveedor, _Str_Cadena);
        }
        private void _Mtd_Cargar_Grupo(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT TGRUPPROM.ccodgrupop, UPPER(TGRUPPROM.cname) as cname " +
"FROM TGRUPPROM INNER JOIN " +
"TGRUPPROD ON TGRUPPROM.ccodgrupop = TGRUPPROD.ccodgrupop AND TGRUPPROM.cdelete = TGRUPPROD.cdelete " +
"WHERE (TGRUPPROD.cproveedor = '" + _P_Str_Proveedor + "') AND (TGRUPPROM.cdelete = 0)";
            _MyUtilidad._Mtd_CargarCombo(_Cmb_Grupo, _Str_Cadena);
        }
        private void _Mtd_Cargar_Subgrupo(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            string _Str_Cadena = "SELECT TSUBGRUPOM.ccodsubgrup, UPPER(TSUBGRUPOM.cname) as cname " +
"FROM TSUBGRUPOM INNER JOIN " +
"TSUBGRUPOD ON TSUBGRUPOM.ccodsubgrup = TSUBGRUPOD.ccodsubgrup AND " +
"TSUBGRUPOM.cdelete = TSUBGRUPOD.cdelete " +
"WHERE (TSUBGRUPOM.cdelete = 0) AND (TSUBGRUPOD.cproveedor = '" + _P_Str_Proveedor + "') AND (TSUBGRUPOD.ccodgrupop = '" + _P_Str_Grupo + "')";
            _MyUtilidad._Mtd_CargarCombo(_Cmb_Subgrupo, _Str_Cadena);
        }
        private void _Mtd_Cargar_Marca(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            string _Str_Cadena = "SELECT TMARCASM.cmarca, UPPER(TMARCASM.cname) as cname " +
"FROM TMARCASM INNER JOIN " +
"TMARCAS ON TMARCASM.cmarca = TMARCAS.cmarca " +
"WHERE (TMARCASM.cdelete = 0) AND (TMARCAS.ccodgrupop = '" + _P_Str_Grupo + "') AND (TMARCAS.cproveedor = '" + _P_Str_Proveedor + "')";
            _MyUtilidad._Mtd_CargarCombo(_Cmb_Marca, _Str_Cadena);
        }
        private void _Mtd_Cargar_TipoMov()
        {
            string _Str_Cadena = "SELECT ctmovimiento, RTRIM(UPPER(cname)) as cname FROM TTMOVIMIENTO where cdelete='0'";
            _MyUtilidad._Mtd_CargarCombo(_Cmb_Tipo_Mov,_Str_Cadena);
        }
        private void _Mtd_Restablecer()
        {
            string _Str_Sql = "Select DISTINCT cproducto,produc_descrip AS cnamef,cpresentaciondescrip,'0' as Seleccionar from VST_MOVIMIENTOINVENTARIO where 0>1";
            _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0];
            _Txt_CodigoIn.Text = "";
            _Txt_CodigoEs.Text = "";
            _Chbox_Proveedores.Checked = false;
            _Chbox_Grupos.Checked = false;
            _Chbox_Subgrupos.Checked = false;
            _Chbox_Marcas.Checked = false;
            _ChBox_Tipo_Mov.Checked = true;
            _Cmb_Proveedor.Enabled = true;
            _Dtp_FechDesde.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dtp_FechHasta.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().AddDays(1);
            _Chbox_1.Checked = false;
        }

        private string _Mtd_Buscar()
        {
            string _Str_Cadena = "";
            bool _Bol_Entrada = false;
            if (_Chbox_1.Checked)
            { _Str_Cadena = "where cdatemov>='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_FechDesde.Value) + "' and cdatemov<='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_FechHasta.Value) + "'"; _Bol_Entrada = true; }
            if (_Bol_Entrada)
            {
                if (_Cmb_Subgrupo.SelectedIndex > 0)
                { _Str_Cadena =_Str_Cadena+ " and cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "' and cgrupo='" + _Cmb_Grupo.SelectedValue.ToString() + "' and csubgrupo='" + _Cmb_Subgrupo.SelectedValue.ToString() + "'"; }
                else if (_Cmb_Grupo.SelectedIndex > 0)
                { _Str_Cadena = _Str_Cadena + " and cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "' and cgrupo='" + _Cmb_Grupo.SelectedValue.ToString() + "'"; }
                else if (_Cmb_Subgrupo.SelectedIndex < 1 & _Cmb_Grupo.SelectedIndex < 1 & _Cmb_Proveedor.SelectedIndex > 0)
                { _Str_Cadena = _Str_Cadena + " and cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "'"; }
            }
            else
            {
                if (_Cmb_Subgrupo.SelectedIndex > 0)
                { _Str_Cadena = "where cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "' and cgrupo='" + _Cmb_Grupo.SelectedValue.ToString() + "' and csubgrupo='" + _Cmb_Subgrupo.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
                else if (_Cmb_Grupo.SelectedIndex > 0)
                { _Str_Cadena = "where cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "' and cgrupo='" + _Cmb_Grupo.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
                else if (_Cmb_Subgrupo.SelectedIndex < 1 & _Cmb_Grupo.SelectedIndex < 1 & _Cmb_Proveedor.SelectedIndex > 0)
                { _Str_Cadena = "where cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
            }
            if (_Bol_Entrada)
            {
                if (_Cmb_Marca.SelectedIndex > 0)
                { _Str_Cadena = _Str_Cadena + " and cmarca='" + _Cmb_Marca.SelectedValue.ToString() + "'"; }
            }
            else
            {
                if (_Cmb_Marca.SelectedIndex > 0)
                { _Str_Cadena = "where cmarca='" + _Cmb_Marca.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
            }
            if (_Bol_Entrada)
            {
                if (_Txt_CodigoIn.Text.Trim().Length > 0)
                { _Str_Cadena = _Str_Cadena + " and ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%')"; }
                if (_Txt_CodigoEs.Text.Trim().Length > 0)
                { _Str_Cadena = _Str_Cadena + " and cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; }
            }
            else
            {
                if (_Txt_CodigoIn.Text.Trim().Length > 0 & _Txt_CodigoEs.Text.Trim().Length == 0)
                { _Str_Cadena = "where ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%')"; _Bol_Entrada = true; }
                else if (_Txt_CodigoIn.Text.Trim().Length == 0 & _Txt_CodigoEs.Text.Trim().Length > 0)
                { _Str_Cadena = "where cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; _Bol_Entrada = true; }
                else if (_Txt_CodigoIn.Text.Trim().Length > 0 & _Txt_CodigoEs.Text.Trim().Length > 0)
                { _Str_Cadena = "where ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%') and cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; _Bol_Entrada = true; }
            }
            bool _Bol_Tipo_Mov = false;
            if (_Bol_Entrada)
            {
                if (_Cmb_Tipo_Mov.SelectedIndex > 0)
                {
                    _Str_Cadena = _Str_Cadena + " and ctmovimiento='" + _Cmb_Tipo_Mov.SelectedValue + "'";
                }
                else if (_Cmb_Tipo_Mov.SelectedIndex < 1 & !_ChBox_Tipo_Mov.Checked)
                {
                    MessageBox.Show("Debe especificar un tipo de movimiento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    _Str_Cadena = "";
                    _Bol_Tipo_Mov = true;
                }
            }
            else
            {
                if (_Cmb_Tipo_Mov.SelectedIndex > 0)
                {
                    _Str_Cadena = "where ctmovimiento='" + _Cmb_Tipo_Mov.SelectedValue + "'";
                }
                else if (_Cmb_Tipo_Mov.SelectedIndex < 1 & !_ChBox_Tipo_Mov.Checked)
                {
                    MessageBox.Show("Debe especificar un tipo de movimiento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    _Str_Cadena = "";
                    _Bol_Tipo_Mov = true;
                }
            }
            if (_Str_Cadena.Length > 0)
            {                
                return _Str_Cadena;
            }
            else
            {
                if (!_Bol_Tipo_Mov)
                {
                    MessageBox.Show("Debe especificar algún criterio de busqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                return "";
            }
        }
        private bool _Mtd_Seleccionar()
        {
            Cursor = Cursors.WaitCursor;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Seleccionar"].Value).Trim() == "1")
                { Cursor = Cursors.Default; return true; }
            }
            Cursor = Cursors.Default;
            return false;
        }
        private void Frm_ConsMovInventario_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }
        string _Str_Consulta = "";
        private void _Mtd_Cosultar()
        {
            if (_Rbt_Filtro.Checked)
            {
                string _Str_Cadena = _Str_Consulta;
                if (_Str_Cadena.Trim().Length > 0)
                {
                    string _Str_Sql = "Select DISTINCT cproducto,produc_descrip AS cnamef,cpresentaciondescrip,'0' as Seleccionar from VST_MOVIMIENTOINVENTARIO " + _Str_Cadena + " and ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY cproducto";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    _Mtd_CargarGrid(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql),_Dg_Grid);
                    if (_Ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron registros...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                string _Str_Sql = "Select DISTINCT cproducto,produc_descrip AS cnamef,cpresentaciondescrip,'0' as Seleccionar from VST_MOVIMIENTOINVENTARIO Where ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY cproducto";
                _Mtd_CargarGrid(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql), _Dg_Grid);
            }
        }
        delegate void SetDataSetsCallback(DataSet _P_Ds, DataGridView _P_Dg_Grid);
        private void _Mtd_CargarGrid(DataSet _P_Ds, DataGridView _P_Dg_Grid)
        {
            if (_P_Dg_Grid.InvokeRequired)
            {
                SetDataSetsCallback _Sets = new SetDataSetsCallback(_Mtd_CargarGrid);
                this.Invoke(_Sets, new object[] { _P_Ds, _P_Dg_Grid });
            }
            else
            {
                _P_Dg_Grid.DataSource = _P_Ds.Tables[0];
            }
        }
        private void _Bt_Consulta_Click(object sender, EventArgs e)
        {
            if (_Rbt_Filtro.Checked)
            { _Str_Consulta = _Mtd_Buscar(); }
            else
            { _Str_Consulta = ""; }
            if (!_Rbt_Filtro.Checked | (_Rbt_Filtro.Checked & _Str_Consulta.Trim().Length > 0))
            {
                Thread _Thr_Thread = new Thread(new ThreadStart(_Mtd_Cosultar));
                _Thr_Thread.Start();
                while (!_Thr_Thread.IsAlive) ;
                Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread, "Espere por favor...");
                _Frm_Form.ShowDialog(this);
                _Frm_Form.Dispose();
            }
        }

        private void _Rbt_Filtro_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Filtro.Checked)
            {
                _Mtd_Restablecer();
                _Chbox_Proveedores.Enabled = true;
                _Chbox_Grupos.Enabled = true;
                _Chbox_Subgrupos.Enabled = true;
                _Chbox_Marcas.Enabled = true;
                _Grb_1.Enabled = true;
                _Grb_2.Enabled = true;
                _Grb_3.Enabled = true;
                _Bt_Restablecer.Enabled = true;
            }
        }

        private void _Rbt_Todo_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Todo.Checked)
            {
                _Mtd_Restablecer();
                _Grb_1.Enabled = false;
                _Grb_2.Enabled = false;
                _Grb_3.Enabled = false;
                _Bt_Restablecer.Enabled = false;
            }
        }

        private void _ChBox_Tipo_Mov_CheckedChanged(object sender, EventArgs e)
        {
            if (_ChBox_Tipo_Mov.Checked)
            {
                _Cmb_Tipo_Mov.SelectedIndex = -1;
                _Cmb_Tipo_Mov.Enabled = false;
            }
            else
            {
                _Cmb_Tipo_Mov.Enabled = true;
            }
        }

        private void _Bt_Restablecer_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Restablecer();
            Cursor = Cursors.Default;
        }

        private void _Chbox_Proveedores_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Proveedores.Checked)
            { _Cmb_Proveedor.Enabled = true; }
            else
            { _Cmb_Proveedor.Enabled = false; _Cmb_Proveedor.SelectedIndex = -1; }
        }

        private void _Chbox_Grupos_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Grupos.Checked)
            { _Cmb_Grupo.Enabled = true; }
            else
            { _Cmb_Grupo.Enabled = false; _Cmb_Grupo.SelectedIndex = -1; }
        }

        private void _Chbox_Subgrupos_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Subgrupos.Checked)
            { _Cmb_Subgrupo.Enabled = true; }
            else
            { _Cmb_Subgrupo.Enabled = false; _Cmb_Subgrupo.SelectedIndex = -1; }
        }

        private void _Chbox_Marcas_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Marcas.Checked)
            { _Cmb_Marca.Enabled = true; }
            else
            { _Cmb_Marca.Enabled = false; _Cmb_Marca.SelectedIndex = -1; }
        }
        
        private void _Cmb_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Chbox_Proveedores.CheckedChanged -= new EventHandler(_Chbox_Proveedores_CheckedChanged);
            if (_Cmb_Proveedor.SelectedIndex < 1)
            {
                _Cmb_Grupo.DataSource = null;
                _Cmb_Grupo.Enabled = false;
                _Chbox_Proveedores.Checked = false;
                _Cmb_Proveedor.Enabled = true;
            }
            else
            {
                _Cmb_Grupo.Enabled = true;
                _Chbox_Proveedores.Checked = true;
                _Cmb_Grupo.SelectedIndex = -1;
            }
            _Chbox_Proveedores.CheckedChanged += new EventHandler(_Chbox_Proveedores_CheckedChanged);
        }

        private void _Cmb_Grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Chbox_Grupos.CheckedChanged -= new EventHandler(_Chbox_Grupos_CheckedChanged);
            if (_Cmb_Grupo.SelectedIndex > 0)
            {
                _Chbox_Grupos.Checked = true;
                _Cmb_Subgrupo.Enabled = true;
                _Cmb_Marca.Enabled = true;
            }
            else
            {
                _Cmb_Subgrupo.DataSource = null;
                _Cmb_Marca.DataSource = null;
                _Chbox_Grupos.Checked = false;
                _Cmb_Subgrupo.Enabled = false;
                _Cmb_Marca.Enabled = false;
                if (_Chbox_Grupos.Checked)
                {
                    _Cmb_Grupo.Enabled = true;
                }
                else
                { _Cmb_Grupo.Enabled = false; }
            }
            _Chbox_Grupos.CheckedChanged += new EventHandler(_Chbox_Grupos_CheckedChanged);
        }

        private void _Cmb_Subgrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Chbox_Subgrupos.CheckedChanged -= new EventHandler(_Chbox_Subgrupos_CheckedChanged);
            if (_Cmb_Subgrupo.SelectedIndex > 0)
            { 
                _Chbox_Subgrupos.Checked = true; 
            }
            else
            { 
                _Chbox_Subgrupos.Checked = false; 
            }
            _Chbox_Subgrupos.CheckedChanged += new EventHandler(_Chbox_Subgrupos_CheckedChanged);
        }

        private void _Cmb_Marca_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Chbox_Marcas.CheckedChanged -= new EventHandler(_Chbox_Marcas_CheckedChanged);
            if (_Cmb_Marca.SelectedIndex > 0)
            { 
                _Chbox_Marcas.Checked = true; 
            }
            else
            { 
                _Chbox_Marcas.Checked = false; 
            }
            _Chbox_Marcas.CheckedChanged += new EventHandler(_Chbox_Marcas_CheckedChanged);
        }

        private void _Dtp_FechDesde_ValueChanged(object sender, EventArgs e)
        {
            if (_Dtp_FechDesde.Value >= _Dtp_FechHasta.Value)
            {
                _Dtp_FechHasta.Value = _Dtp_FechDesde.Value.AddDays(1);
            }
        }

        private void _Chbox_1_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_1.Checked)
            { _Dtp_FechDesde.Enabled = true; _Dtp_FechHasta.Enabled = true; }
            else
            { _Dtp_FechDesde.Enabled = false; _Dtp_FechHasta.Enabled = false; }
        }

        private void _Cmb_Tipo_Mov_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_TipoMov();
        }

        private void _Bt_Imprimir_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            REPORTESS _Frm = new REPORTESS("T3.Report.rMovimiento", ((DataTable)_Dg_Grid2.DataSource), "Section2", "cabecera", "rif", "nit");
            Cursor = Cursors.Default;
            _Frm.MdiParent = this.MdiParent;
            _Frm.Dock = DockStyle.Fill;
            _Frm.Show();
        }
        private DataTable _Mtd_GetDtReporte()
        {
            bool _Bol_Sw = false;
            string _Str_Sql = "SELECT * FROM VST_MOVIMIENTOINVENTARIO WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds_Reporte = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            DataTable _Dt_Grid = ((DataTable)_Dg_Grid2.DataSource);
            foreach (DataRow _DRow_Reporte in _Ds_Reporte.Tables[0].Rows)
            {
                _Bol_Sw = false;
                foreach (DataRow _DRow_Grid in _Dt_Grid.Rows)
                {
                    if (_DRow_Grid["cmovinvtario"].ToString() == _DRow_Reporte["cmovinvtario"].ToString())
                    {
                        _Bol_Sw = true;
                        break;
                    }
                }
                if (!_Bol_Sw)
                {
                    _Ds_Reporte.Tables[0].Rows.Remove(_DRow_Reporte);
                }
            }
            return _Ds_Reporte.Tables[0];
        }
        private void _Lnk_Deseleccionar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (_Rbt_Filtro.Checked)
            {
                if (_Dg_Grid.Rows.Count > 0)
                {
                    string _Str_Cadena = _Mtd_Buscar();
                    if (_Str_Cadena.Trim().Length > 0)
                    {
                        string _Str_Sql = "Select DISTINCT cproducto,produc_descrip AS cnamef,cpresentaciondescrip,'0' as Seleccionar from VST_MOVIMIENTOINVENTARIO " + _Str_Cadena + " and ccompany='" + Frm_Padre._Str_Comp + "'";
                        _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0];
                    }
                }
            }
            else
            {
                if (_Dg_Grid.Rows.Count > 0)
                {
                    Cursor = Cursors.WaitCursor;
                    string _Str_Sql = "Select DISTINCT cproducto,produc_descrip AS cnamef,cpresentaciondescrip,'0' as Seleccionar from VST_MOVIMIENTOINVENTARIO where ccompany='" + Frm_Padre._Str_Comp + "'";
                    _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0];
                    Cursor = Cursors.Default;
                }
            }
            Cursor = Cursors.Default;
        }

        private void _Lnk_Todos_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (_Rbt_Filtro.Checked)
            {
                if (_Dg_Grid.Rows.Count > 0)
                {
                    string _Str_Cadena = _Mtd_Buscar();
                    if (_Str_Cadena.Trim().Length > 0)
                    {
                        string _Str_Sql = "Select DISTINCT cproducto,produc_descrip AS cnamef,cpresentaciondescrip,'1' as Seleccionar from VST_MOVIMIENTOINVENTARIO " + _Str_Cadena + " and ccompany='" + Frm_Padre._Str_Comp + "'";
                        _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0];
                    }
                }
            }
            else
            {
                if (_Dg_Grid.Rows.Count > 0)
                {
                    Cursor = Cursors.WaitCursor;
                    string _Str_Sql = "Select DISTINCT cproducto,produc_descrip AS cnamef,cpresentaciondescrip,'1' as Seleccionar from VST_MOVIMIENTOINVENTARIO where ccompany='" + Frm_Padre._Str_Comp + "'";
                    _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0];
                    Cursor = Cursors.Default;
                }
            }
            Cursor = Cursors.Default;
        }

        private void _Lnk_Mostrar_Click(object sender, EventArgs e)
        {
            if (_Mtd_Seleccionar())
            {
                _G_Bol_CargaSw = true;
                _Tb_Tab.SelectedIndex = 1;
                _G_Bol_CargaSw = false;
            }
            else
            {
                MessageBox.Show("No se han seleccionado productos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }
        private void _Mtd_CargarGridMovimientos()
        {
            string _Str_Filtro = "";
            if (_Chbox_1.Checked)
            { _Str_Filtro = "AND cdatemov>='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_FechDesde.Value) + "' and cdatemov<='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_FechHasta.Value) + "'"; }
            if (_Cmb_Tipo_Mov.SelectedIndex > 0)
            { _Str_Filtro += " AND ctmovimiento='" + _Cmb_Tipo_Mov.SelectedValue + "'"; }
            object[] _My_Obj = new object[0];
            string _Str_Sql = "";
            if (_Chk_Lote.Checked) 
            {
                _Str_Sql = "Select cdatemov,cproducto,produc_descrip,cpresentaciondescrip,cidproductod,cprecioventamax,cnumdocu,RTRIM(cname) as cname,cexisant_u1,cexisant_u2,ccostbrutomovant,ccostnetomovant,cexismov_u1,cexismov_u2,ccostbrutomov,ccostnetomov,cexisdes_u1,cexisdes_u2, '' AS cautoconsumo,ccostbrutomovdes,ccostnetomovdes,cmovinvtario,cproveedor,c_nomb_comer,ctmovimiento,cgrupo,GrupoDes FROM VST_MOVIMIENTOINVENTARIO_LOTES where ccompany='" + Frm_Padre._Str_Comp + "' AND cmovinvtario=-1 ORDER BY cmovinvtario ASC";
            }
            else
            {
                _Str_Sql = "Select cdatemov,cproducto,produc_descrip,cpresentaciondescrip,cidproductod,cprecioventamax,cnumdocu,RTRIM(cname) as cname,cexisant_u1,cexisant_u2,ccostbrutomovant,ccostnetomovant,cexismov_u1,cexismov_u2,ccostbrutomov,ccostnetomov,cexisdes_u1,cexisdes_u2, '' AS cautoconsumo,ccostbrutomovdes,ccostnetomovdes,cmovinvtario,cproveedor,c_nomb_comer,ctmovimiento,cgrupo,GrupoDes FROM VST_MOVIMIENTOINVENTARIO where ccompany='" + Frm_Padre._Str_Comp + "' AND cmovinvtario=-1 ORDER BY cmovinvtario ASC";
            }
                DataSet _Ds_MovInv = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            DataSet _Ds_MovInvTemp = new DataSet();
            DataColumn[] _DtColPk = new DataColumn[1];
            //-------------------------
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["Seleccionar"].Value).Trim() == "1")
                {
                    if (_Chk_Lote.Checked)
                    {
                        _Str_Sql = "Select cdatemov,cproducto,produc_descrip,cpresentaciondescrip,cidproductod,cprecioventamax,cnumdocu,RTRIM(cname) as cname,cexisant_u1,cexisant_u2,ccostbrutomovant,ccostnetomovant,cexismov_u1,cexismov_u2,ccostbrutomov,ccostnetomov,cexisdes_u1,cexisdes_u2, '' AS cautoconsumo,ccostbrutomovdes,ccostnetomovdes,cmovinvtario,cproveedor,c_nomb_comer,ctmovimiento,cgrupo,GrupoDes FROM VST_MOVIMIENTOINVENTARIO_LOTES where ccompany='" + Frm_Padre._Str_Comp + "' AND cproducto='" + Convert.ToString(_Dg_Row.Cells[0].Value).Trim() + "'" + _Str_Filtro + "  ORDER BY cmovinvtario ASC";
                    }
                    else 
                    {
                        _Str_Sql = "Select cdatemov,cproducto,produc_descrip,cpresentaciondescrip,cidproductod,cprecioventamax,cnumdocu,RTRIM(cname) as cname,cexisant_u1,cexisant_u2,ccostbrutomovant,ccostnetomovant,cexismov_u1,cexismov_u2,ccostbrutomov,ccostnetomov,cexisdes_u1,cexisdes_u2, '' AS cautoconsumo,ccostbrutomovdes,ccostnetomovdes,cmovinvtario,cproveedor,c_nomb_comer,ctmovimiento,cgrupo,GrupoDes FROM VST_MOVIMIENTOINVENTARIO where ccompany='" + Frm_Padre._Str_Comp + "' AND cproducto='" + Convert.ToString(_Dg_Row.Cells[0].Value).Trim() + "'" + _Str_Filtro + "  ORDER BY cmovinvtario ASC";
                    }
                        _Ds_MovInvTemp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    foreach (DataRow _Row in _Ds_MovInvTemp.Tables[0].Rows)
                    {
                        _Ds_MovInv.Tables[0].Rows.Add(_Row.ItemArray);
                    }
                }
            }
            //-------------------------

            _Mtd_CargarGrid(_Ds_MovInv, _Dg_Grid2);
            if (_Chk_Lote.Checked)
            {
                _Dg_Grid2.Columns["clmLote"].Visible = true;
                _Dg_Grid2.Columns["clmPreMax"].Visible = true;
            }
            else
            {
                _Dg_Grid2.Columns["clmLote"].Visible = false;
                _Dg_Grid2.Columns["clmPreMax"].Visible = false;
            }
        }
        private void Frm_ConsMovInventario_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_G_Bol_CargaSw & e.TabPageIndex == 1)
            {
                e.Cancel = true; 
            }
        }

        private void _Tb_Tab_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                Cursor = Cursors.WaitCursor;
                Thread _Thr_Thread = new Thread(new ThreadStart(_Mtd_CargarGridMovimientos));
                _Thr_Thread.Start();
                while (!_Thr_Thread.IsAlive) ;
                Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread, "Espere por favor...");
                _Frm_Form.ShowDialog(this);
                _Frm_Form.Dispose();
                for (int _Int_I = 6; _Int_I <= 18; _Int_I++)
                {
                    if (_Int_I <= 9)
                    { _Dg_Grid2.Columns[_Int_I].DefaultCellStyle.BackColor = Color.FromArgb(192, 192, 255); }
                    else if (_Int_I <= 13)
                    { _Dg_Grid2.Columns[_Int_I].DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 128); }
                    else if (_Int_I <= 17)
                    { _Dg_Grid2.Columns[_Int_I].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192); }
                }
                _Dg_Grid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                Cursor = Cursors.Default;
            }
        }

        private void _Cmb_Proveedor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Cmb_Proveedor.SelectedIndexChanged -= new EventHandler(_Cmb_Proveedor_SelectedIndexChanged);
            _Mtd_Cargar_Proveedor();
            _Cmb_Proveedor.SelectedIndexChanged += new EventHandler(_Cmb_Proveedor_SelectedIndexChanged);
            this.Cursor = Cursors.Default;
        }

        private void _Cmb_Grupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Cmb_Grupo.SelectedIndexChanged -= new EventHandler(_Cmb_Grupo_SelectedIndexChanged);
            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                _Mtd_Cargar_Grupo(_Cmb_Proveedor.SelectedValue.ToString());
            }
            else
            { _Cmb_Grupo.SelectedValue = null; }
            _Cmb_Grupo.SelectedIndexChanged += new EventHandler(_Cmb_Grupo_SelectedIndexChanged);
            this.Cursor = Cursors.Default;
        }

        private void _Cmb_Subgrupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Cmb_Subgrupo.SelectedIndexChanged -= new EventHandler(_Cmb_Subgrupo_SelectedIndexChanged);
            if (_Cmb_Proveedor.SelectedIndex > 0 & _Cmb_Grupo.SelectedIndex > 0)
            {
                _Mtd_Cargar_Subgrupo(_Cmb_Proveedor.SelectedValue.ToString(), _Cmb_Grupo.SelectedValue.ToString());
            }
            else
            { _Cmb_Subgrupo.SelectedValue = null; }
            _Cmb_Subgrupo.SelectedIndexChanged += new EventHandler(_Cmb_Subgrupo_SelectedIndexChanged);
            this.Cursor = Cursors.Default;
        }

        private void _Cmb_Marca_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Cmb_Marca.SelectedIndexChanged -= new EventHandler(_Cmb_Marca_SelectedIndexChanged);
            if (_Cmb_Proveedor.SelectedIndex > 0 & _Cmb_Grupo.SelectedIndex > 0)
            {
                _Mtd_Cargar_Marca(_Cmb_Proveedor.SelectedValue.ToString(), _Cmb_Grupo.SelectedValue.ToString());
            }
            else
            { _Cmb_Marca.SelectedValue = null; }
            _Cmb_Marca.SelectedIndexChanged += new EventHandler(_Cmb_Marca_SelectedIndexChanged);
            this.Cursor = Cursors.Default;
        }

        private void _Btn_Exportar_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid2.RowCount > 0)
            {
                try
                {
                    if (_Sfd_1.ShowDialog() == DialogResult.OK)
                    {
                        Cursor = Cursors.WaitCursor;
                        Clases._Cls_ExcelUtilidades _MyExcel = new T3.Clases._Cls_ExcelUtilidades();

                        //Obtenemos el DataTable a exportar
                        var _Dt_Exportar = ((DataTable) _Dg_Grid2.DataSource).Copy();

                        //Removemos las Columnas no Necesarias
                        var _Col_Columnas = _Dg_Grid2.Columns;
                        string[] remove_col = new string[] {"_Dg_Grid2Col_cproveedor", 
                                                            "_Dg_Grid2Col_c_nomb_comer", 
                                                            "_Dg_Grid2Col_ctmovimiento", 
                                                            "_Dg_Grid2Col_cgrupo" };
                        string[] remove_dt = new string[] { "cproveedor", 
                                                            "c_nomb_comer", 
                                                            "ctmovimiento", 
                                                            "cgrupo" };
                        foreach (var item in remove_dt)
                        {
                            if (_Dt_Exportar.Columns.Contains(item.ToString()))
                                _Dt_Exportar.Columns.Remove(item.ToString());
                        }
                        foreach (var item in remove_col)
                        {
                            if (_Col_Columnas.Contains(item.ToString()))
                                _Col_Columnas.Remove(item.ToString());
                        }
                        //-----------------------------------

                        _MyExcel._Mtd_DatasetToExcel(_Dt_Exportar, _Sfd_1.FileName, "MOVIMIEN_INVENT_" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString(), _Col_Columnas);
                        _MyExcel = null;
                        Cursor = Cursors.Default;
                    }
                }
                catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar exportar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

    }
}