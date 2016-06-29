using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;


namespace T3
{
    public partial class Frm_AutorizacionLote : Form
    {
        #region Costumbres y tradiciones originales de una Cultura Antigua (No Alterar)

        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_AutorizacionLote()
        {
            InitializeComponent();
            //Culto Antiguo para la invocación del contenido de los combos
            _Mtd_Cargar_Proveedor();
            _Mtd_Cargar_Canal();
            _Mtd_Color_Estandar(this);
        }

        public Frm_AutorizacionLote(bool Mostrar)
        {
            InitializeComponent();

            _Cmb_Estado.SelectedIndex = 0;
            if(Mostrar) _Bt_Find_Click(null, null);
            
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
            string _Str_Cadena = "select distinct VST_PRODUCTOS_A.cproveedor as cproveedor,VST_PRODUCTOS_A.c_nomb_abreviado as c_nomb_abreviado from VST_PRODUCTOS_A where VST_PRODUCTOS_A.companyprov='"+Frm_Padre._Str_Comp+"' AND NOT EXISTS(SELECT * FROM TFILTROREGIONALP WHERE VST_PRODUCTOS_A.cproveedor=TFILTROREGIONALP.cproveedor and VST_PRODUCTOS_A.cproducto=TFILTROREGIONALP.cproducto and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' and TFILTROREGIONALP.cdelete='0') and VST_PRODUCTOS_A.cdelete=0 ORDER BY VST_PRODUCTOS_A.c_nomb_abreviado";
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
       
        private void _Mtd_Cargar_Canal()
        {
            string _Str_Cadena = "SELECT clistaprecio,cname FROM TTCANAL ORDER BY cname";
            
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
                _Cmb_Estado.Enabled = true;
            }
            else { _Cmb_Estado.Enabled = false; }
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

       
      

        private void Frm_Inf_ListadPrecio_Load(object sender, EventArgs e)
        {
            //Frm_Padre._Str_GroupComp
            this.Dock = DockStyle.Fill;
        }

     
        #endregion


        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            string _Str_Proveedor = "";
            string _Str_Grupo = "";
            string _Str_SubGrupo = "";
            

            string _Str_Estado = "";
            string _Str_Recepcion = "";
            string _Str_Producto = "";


            //--------------
            if (_Txt_Producto.Text.Trim().Length > 0)
            { _Str_Producto = _Txt_Producto.Text.Trim(); }
            else
            { _Str_Producto = "nulo"; }
            //--------------

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

           
            if (_Cmb_Estado.SelectedIndex >= 0)
            {
                _Str_Estado = "VST_CONSULTASLOTES.cautorizado='" + _Cmb_Estado.SelectedIndex.ToString() + "'";
                if (_Cmb_Estado.SelectedIndex == 2) _Str_Estado = " (VST_CONSULTASLOTES.cautorizado='0' or VST_CONSULTASLOTES.cautorizado='1') ";
            }
            else
            {
                _Str_Estado = "VST_CONSULTASLOTES.cautorizado='0'";
            }


            //--------------
            if (_Txt_Recepcion.Text.Trim().Length > 0)
            { _Str_Recepcion = _Txt_Recepcion.Text.Trim(); }
            else
            { _Str_Recepcion = "nulo"; }
            //--------------

            this.Cursor = Cursors.WaitCursor;
            _Mtd_Busqueda(_Str_Proveedor, _Str_Grupo, _Str_SubGrupo, _Str_Estado, _Str_Recepcion, _Str_Producto);
            this.Cursor = Cursors.Default;

        }




        private void _Mtd_Busqueda(string _P_Str_Proveedor, string _P_Str_Grupo, string _P_Str_SubGrupo, string _P_Str_cautorizado, string _P_Str_Recepcion, string _P_Str_Producto)
        {
            if (_Cmb_Estado.SelectedIndex == -1) _Cmb_Estado.SelectedIndex = 0;

            string _Str_Cadena = "select VST_CONSULTASLOTES.*,VST_T3_EMPUNDLOTESAUTORIZADOS.empaques, VST_T3_EMPUNDLOTESAUTORIZADOS.unidades from VST_CONSULTASLOTES";

            _Str_Cadena += " LEFT JOIN VST_T3_EMPUNDLOTESAUTORIZADOS ON VST_CONSULTASLOTES.cproducto = VST_T3_EMPUNDLOTESAUTORIZADOS.cproducto";
            _Str_Cadena += " where VST_CONSULTASLOTES.cdelete='0'";

            if (_P_Str_Proveedor != "nulo") _Str_Cadena += " and VST_CONSULTASLOTES.cproveedor='" + _P_Str_Proveedor + "' ";
            if (_P_Str_Grupo != "nulo") _Str_Cadena += " and VST_CONSULTASLOTES.cgrupo='" + _P_Str_Grupo + "' ";
            if (_P_Str_SubGrupo != "nulo") _Str_Cadena += " and VST_CONSULTASLOTES.csubgrupo='" + _P_Str_SubGrupo + "' ";
            if (_P_Str_cautorizado != "nulo") _Str_Cadena += " and " + _P_Str_cautorizado ;
            if (_P_Str_Recepcion != "nulo") _Str_Cadena += " and VST_CONSULTASLOTES.cidproductod='" + _P_Str_Recepcion + "' ";
            if (_P_Str_Producto != "nulo") _Str_Cadena += " and VST_CONSULTASLOTES.cproducto='" + _P_Str_Producto + "' ";
            
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            _Dg_Lotes.AutoGenerateColumns = false;
            _Dg_Lotes.Columns[1].ReadOnly = _Cmb_Estado.SelectedIndex != 0;
            _Dg_Lotes.DataSource = _Ds.Tables[0];
            _Dg_Lotes.Columns["clmFR"].DefaultCellStyle.Format = "d";
            _Dg_Lotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (_Cmb_Estado.SelectedIndex == 0)
            {
                _Dg_Lotes.Columns[9].Visible = true;
                _Dg_Lotes.Columns[10].Visible = true;
            }
            else
            {
                _Dg_Lotes.Columns[9].Visible = false;
                _Dg_Lotes.Columns[10].Visible = false;
            }
        }

        private void _Btn_Autorizar_Click(object sender, EventArgs e)
        {
            bool _Bol_Aprobado=false;
            if (_Dg_Lotes.Rows.Count > 0 && _Cmb_Estado.SelectedIndex == 0 && MessageBox.Show(@"¿Desea Autorizar TODOS los Lotes seleccionados?", @"Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in _Dg_Lotes.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[1].Value) )
                    {
                        _Bol_Aprobado = true;
                        string _Str_Cadena =
                            "UPDATE [TPRODUCTOD] SET [cautorizado] = 1,[cfechaautorizado] = getdate(),[cuserautorizado] = '" +
                            Frm_Padre._Str_Use.ToUpper() + "' WHERE cidproductod='" + item.Cells[0].Value + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                       
                    }
                }
                if (_Bol_Aprobado)
                {
                    MessageBox.Show(@"Se Autorizaron los Lotes Correctamente.", @"Aviso", MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);
                    _Bt_Find_Click(null, null);
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                }
            }
        }
    }

    
}