using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_BusquedaAvanzada : Form
    {
        public Frm_BusquedaAvanzada()
        {
            InitializeComponent();
        }
        Form  _Frm_Formuario=new Form();
        //string _Str_Where_Ini = "";
        public Frm_BusquedaAvanzada(Form _P_Frm_Fomulario)//,string _P_Str_Where_Ini)
        {
            InitializeComponent();
            _Frm_Formuario = _P_Frm_Fomulario;
            //_Str_Where_Ini = _P_Str_Where_Ini;
            _Mtd_Cargar_Proveedor();
            //_Mtd_Cargar_Marca();
            _Mtd_Cargar_Unidad1();
            _Mtd_Cargar_Unidad2();
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
            _Cmb_Proveedor.DataSource = null;
            _Cmb_Grupo.DataSource = null;
            DataSet _Ds;
            string _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor AS cproveedor, TPROVEEDOR.c_nomb_abreviado AS c_nomb_abreviado FROM TPROVEEDOR INNER JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor =TGRUPPROVEE.cproveedor INNER JOIN TPRODUCTO ON TPROVEEDOR.cproveedor = TPRODUCTO.cproveedor WHERE (NOT EXISTS (SELECT cproveedor FROM  TFILTROREGIONALP WHERE  (TPROVEEDOR.cproveedor = cproveedor) AND (TPRODUCTO.cproducto = cproducto) AND (cdelete = '0') AND TFILTROREGIONALP.CCOMPANY='" + Frm_Padre._Str_Comp + "')) AND TGRUPPROVEE.CCOMPANY='" + Frm_Padre._Str_Comp + "' AND TGRUPPROVEE.CDELETE='0' AND TPROVEEDOR.cglobal=1 AND ISNULL(TPROVEEDOR.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND TPRODUCTO.cactivate='1' order by TPROVEEDOR.c_nomb_abreviado";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Cmb_Proveedor.DataSource = _Ds.Tables[0];
            _Cmb_Proveedor.DisplayMember = "c_nomb_abreviado";
            _Cmb_Proveedor.ValueMember = "cproveedor";
            _Cmb_Proveedor.SelectedIndex = -1;
        }
        private void _Mtd_Cargar_Grupo(string _P_Str_Proveedor)
        {
            _Cmb_Grupo.DataSource = null;
            DataSet _Ds;
            string _Str_Cadena = "SELECT DISTINCT TGRUPPROM.ccodgrupop as ccodgrupop, RTRIM(TGRUPPROM.cname) AS cname" +
" FROM         TGRUPPROM INNER JOIN"+
                      " TPRODUCTO ON TGRUPPROM.ccodgrupop = TPRODUCTO.cgrupo"+
" WHERE     (TGRUPPROM.cdelete = 0) AND (TPRODUCTO.cdelete = '0') AND (NOT EXISTS"+
                          "(SELECT     cproducto"+
                            " FROM          TFILTROREGIONALP"+
                            " WHERE      (TGRUPPROM.ccodgrupop = cgrupo) AND (TPRODUCTO.cproveedor = cproveedor) AND (TPRODUCTO.cproducto = cproducto) "+
                                                   " AND (cdelete = 0) and TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "')) and TPRODUCTO.cproveedor='"+_Cmb_Proveedor.SelectedValue.ToString()+"' order by TGRUPPROM.cname";
//            string _Str_Cadena = "SELECT TGRUPPROM.ccodgrupop, TGRUPPROM.cname " +
//"FROM TGRUPPROM INNER JOIN " +
//"TGRUPPROD ON TGRUPPROM.ccodgrupop = TGRUPPROD.ccodgrupop AND TGRUPPROM.cdelete = TGRUPPROD.cdelete " +
//"WHERE (TGRUPPROD.cproveedor = '" + _P_Str_Proveedor + "') AND (TGRUPPROM.cdelete = 0)";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Cmb_Grupo.DataSource = _Ds.Tables[0];
            _Cmb_Grupo.DisplayMember = "cname";
            _Cmb_Grupo.ValueMember = "ccodgrupop";
            _Cmb_Grupo.SelectedIndex = -1;
        }
        private void _Mtd_Cargar_Subgrupo(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            _Cmb_Subgrupo.DataSource = null;
            DataSet _Ds;
            string _Str_Cadena = "SELECT DISTINCT TSUBGRUPOM.ccodsubgrup as ccodsubgrup, RTRIM(TSUBGRUPOM.cname) AS cname" +
" FROM         TPRODUCTO INNER JOIN" +
 "                     TSUBGRUPOM ON TPRODUCTO.csubgrupo = TSUBGRUPOM.ccodsubgrup" +
" WHERE     (NOT EXISTS" +
                          "(SELECT     cproducto" +
                            " FROM          TFILTROREGIONALP" +
                            " WHERE      (TPRODUCTO.cproveedor = cproveedor) AND (TPRODUCTO.cgrupo = cgrupo) AND (TPRODUCTO.cproducto = cproducto) AND " +
                                                   " (TPRODUCTO.csubgrupo = csubgrupo) AND (cdelete = '0') and ccompany='" + Frm_Padre._Str_Comp + "')) and TPRODUCTO.cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "' and TPRODUCTO.cgrupo='"+_Cmb_Grupo.SelectedValue.ToString()+"' AND (TSUBGRUPOM.cdelete = '0') AND " +
                      " (TPRODUCTO.cdelete = '0') order by TSUBGRUPOM.cname";
//            string _Str_Cadena = "SELECT TSUBGRUPOM.ccodsubgrup, TSUBGRUPOM.cname " +
//"FROM TSUBGRUPOM INNER JOIN " +
//"TSUBGRUPOD ON TSUBGRUPOM.ccodsubgrup = TSUBGRUPOD.ccodsubgrup AND " +
//"TSUBGRUPOM.cdelete = TSUBGRUPOD.cdelete " +
//"WHERE (TSUBGRUPOM.cdelete = 0) AND (TSUBGRUPOD.cproveedor = '" + _P_Str_Proveedor + "') AND (TSUBGRUPOD.ccodgrupop = '" + _P_Str_Grupo + "')";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Cmb_Subgrupo.DataSource = _Ds.Tables[0];
            _Cmb_Subgrupo.DisplayMember = "cname";
            _Cmb_Subgrupo.ValueMember = "ccodsubgrup";
            _Cmb_Subgrupo.SelectedIndex = -1;
        }
        private void _Mtd_Cargar_Marca(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            _Cmb_Marca.DataSource = null;
            DataSet _Ds;
            string _Str_Cadena = "SELECT DISTINCT TMARCASM.cmarca as cmarca, RTRIM(TMARCASM.cname) AS cname" +
" FROM         TPRODUCTO INNER JOIN" +
               "       TMARCASM ON TPRODUCTO.cmarca = TMARCASM.cmarca" +
" WHERE     (TMARCASM.cdelete = 0) AND (TPRODUCTO.cdelete = N'0') AND (NOT EXISTS" +
 "                         (SELECT     cproducto" +
  "                          FROM          TFILTROREGIONALP" +
   "                         WHERE      (TMARCASM.cmarca = cmarca) AND (TPRODUCTO.cproducto = cproducto) AND (TPRODUCTO.cproveedor = cproveedor) AND " +
    "                                               (TPRODUCTO.cgrupo = cgrupo) AND (TPRODUCTO.csubgrupo = csubgrupo) AND (cdelete = 0) and ccompany='" + Frm_Padre._Str_Comp + "')) and TPRODUCTO.cproveedor='"+_Cmb_Proveedor.SelectedValue.ToString()+"' order by TMARCASM.cname asc";
//            string _Str_Cadena = "SELECT TMARCASM.cmarca, TMARCASM.cname " +
//"FROM TMARCASM INNER JOIN " +
//"TMARCAS ON TMARCASM.cmarca = TMARCAS.cmarca " +
//"WHERE (TMARCASM.cdelete = 0) AND (TMARCAS.ccodgrupop = '" + _P_Str_Grupo + "') AND (TMARCAS.cproveedor = '" + _P_Str_Proveedor + "')";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Cmb_Marca.DataSource = _Ds.Tables[0];
            _Cmb_Marca.DisplayMember = "cname";
            _Cmb_Marca.ValueMember = "cmarca";
            _Cmb_Marca.SelectedIndex = -1;
        }
        private void _Mtd_Cargar_Unidad1()
        {
            _Cmb_Unidad1.DataSource = null;
            DataSet _Ds;
            string _Str_Cadena = "SELECT cunidadman, cname FROM TUNIMAN WHERE (cdelete = 0)";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Cmb_Unidad1.DataSource = _Ds.Tables[0];
            _Cmb_Unidad1.DisplayMember = "cname";
            _Cmb_Unidad1.ValueMember = "cunidadman";
            _Cmb_Unidad1.SelectedIndex = -1;
        }
        private void _Mtd_Cargar_Unidad2()
        {
            _Cmb_Unidad2.DataSource = null;
            DataSet _Ds;
            string _Str_Cadena = "SELECT cunidadman, cname FROM TUNIMAN WHERE (cdelete = 0)";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Cmb_Unidad2.DataSource = _Ds.Tables[0];
            _Cmb_Unidad2.DisplayMember = "cname";
            _Cmb_Unidad2.ValueMember = "cunidadman";
            _Cmb_Unidad2.SelectedIndex = -1;
        }
        private void _Mtd_Restablecer()
        {
            _Txt_Buscar.Text = "";
            _Txt_CodigoEs.Text = "";
            _Txt_CodigoIn.Text = "";
            _Chbox_Comisionables.Checked = false;
            _Chbox_Promocional.Checked = false;
            _Chbox_Regular.Checked = false;
            _Chbox_Proveedores.Checked = false;
            _Chbox_Grupos.Checked = false;
            _Chbox_Subgrupos.Checked = false;
            _Chbox_Marcas.Checked = false;
            _Chbox_Unidad1.Checked = false;
            _Chbox_Unidad2.Checked = false;
            _Cmb_Proveedor.Enabled = true;
            //_Frm_Formuario.GetType().GetMethod("_Mtd_Actualizar_Avanzado").Invoke(_Frm_Formuario, new object[] { _Str_Where_Ini });
        }
        private string _Mtd_Buscar()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "";
            bool _Bol_Entrada = false;
            if (_Cmb_Subgrupo.SelectedIndex != -1)
            { _Str_Cadena = "where TPRODUCTO.cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "' and TPRODUCTO.cgrupo='" + _Cmb_Grupo.SelectedValue.ToString() + "' and TPRODUCTO.csubgrupo='" + _Cmb_Subgrupo.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
            else if (_Cmb_Grupo.SelectedIndex != -1)
            { _Str_Cadena = "where TPRODUCTO.cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "' and TPRODUCTO.cgrupo='" + _Cmb_Grupo.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
            else if (_Cmb_Subgrupo.SelectedIndex == -1 & _Cmb_Grupo.SelectedIndex == -1 & _Cmb_Proveedor.SelectedIndex != -1)
            { _Str_Cadena = "where TPRODUCTO.cproveedor='" + _Cmb_Proveedor.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
            if (_Bol_Entrada)
            {
                if (_Cmb_Marca.SelectedIndex != -1)
                { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.cmarca='" + _Cmb_Marca.SelectedValue.ToString() + "'"; }
            }
            else
            {
                if (_Cmb_Marca.SelectedIndex != -1)
                { _Str_Cadena = "where TPRODUCTO.cmarca='" + _Cmb_Marca.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
            }
            if (_Bol_Entrada)
            {
                if (_Cmb_Unidad1.SelectedIndex != -1 & _Cmb_Unidad2.SelectedIndex == -1)
                { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.cunidadma1='" + _Cmb_Unidad1.SelectedValue.ToString() + "'"; }
                else if (_Cmb_Unidad1.SelectedIndex == -1 & _Cmb_Unidad2.SelectedIndex != -1)
                { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.cunidadma2='" + _Cmb_Unidad2.SelectedValue.ToString() + "'"; }
                else if (_Cmb_Unidad1.SelectedIndex != -1 & _Cmb_Unidad2.SelectedIndex != -1)
                { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.cunidadma1='" + _Cmb_Unidad1.SelectedValue.ToString() + "' and TPRODUCTO.cunidadma2='" + _Cmb_Unidad2.SelectedValue.ToString() + "'"; }
                if (_Chbox_Comisionables.Checked & !_Chbox_Promocional.Checked & !_Chbox_Regular.Checked)
                { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.ccomision='1'"; }
                else if (_Chbox_Comisionables.Checked & _Chbox_Promocional.Checked & !_Chbox_Regular.Checked)
                { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.ccomision='1' and TPRODUCTO.cprodregular is not null"; }
                else if (_Chbox_Comisionables.Checked & !_Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.ccomision='1' and TPRODUCTO.cprodregular is null"; }
                else if (!_Chbox_Comisionables.Checked & _Chbox_Promocional.Checked & !_Chbox_Regular.Checked)
                { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.cprodregular is not null"; }
                else if (!_Chbox_Comisionables.Checked & !_Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.cprodregular is null"; }
                else if (!_Chbox_Comisionables.Checked & _Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                { _Str_Cadena = _Str_Cadena + " and 0=0"; }
                if (_Txt_Buscar.Text.Trim().Length > 0)
                { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.cnamef like('%" + _Txt_Buscar.Text.Trim() + "%')"; }
                if (_Txt_CodigoEs.Text.Trim().Length > 0)
                { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; }
                if (_Txt_CodigoIn.Text.Trim().Length > 0)
                { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%')"; }
            }
            else
            {
                _Bol_Entrada = false;
                if (_Cmb_Unidad1.SelectedIndex != -1 & _Cmb_Unidad2.SelectedIndex == -1)
                { _Str_Cadena = "where TPRODUCTO.cunidadma1='" + _Cmb_Unidad1.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
                else if (_Cmb_Unidad1.SelectedIndex == -1 & _Cmb_Unidad2.SelectedIndex != -1)
                { _Str_Cadena = "where TPRODUCTO.cunidadma2='" + _Cmb_Unidad2.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
                else if (_Cmb_Unidad1.SelectedIndex != -1 & _Cmb_Unidad2.SelectedIndex != -1)
                { _Str_Cadena = "where TPRODUCTO.cunidadma1='" + _Cmb_Unidad1.SelectedValue.ToString() + "' and TPRODUCTO.cunidadma2='" + _Cmb_Unidad2.SelectedValue.ToString() + "'"; _Bol_Entrada = true; }
                if (_Bol_Entrada)
                {
                    if (_Chbox_Comisionables.Checked & !_Chbox_Promocional.Checked & !_Chbox_Regular.Checked)
                    { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.ccomision='1'"; }
                    else if (_Chbox_Comisionables.Checked & _Chbox_Promocional.Checked & !_Chbox_Regular.Checked)
                    { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.ccomision='1' and TPRODUCTO.cprodregular is not null"; }
                    else if (_Chbox_Comisionables.Checked & !_Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                    { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.ccomision='1' and TPRODUCTO.cprodregular is null"; }
                    else if (!_Chbox_Comisionables.Checked & _Chbox_Promocional.Checked & !_Chbox_Regular.Checked)
                    { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.cprodregular is not null"; }
                    else if (!_Chbox_Comisionables.Checked & !_Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                    { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.cprodregular is null"; }
                    else if (!_Chbox_Comisionables.Checked & _Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                    { _Str_Cadena = _Str_Cadena + " and 0=0"; }
                    if (_Txt_Buscar.Text.Trim().Length > 0)
                    { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.cnamef like('%" + _Txt_Buscar.Text.Trim() + "%')"; }
                    if (_Txt_CodigoEs.Text.Trim().Length > 0)
                    { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; }
                    if (_Txt_CodigoIn.Text.Trim().Length > 0)
                    { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%')"; }
                }
                else
                {
                    _Bol_Entrada = false;
                    if (_Chbox_Comisionables.Checked & !_Chbox_Promocional.Checked & !_Chbox_Regular.Checked)
                    { _Str_Cadena = "where TPRODUCTO.ccomision='1'"; _Bol_Entrada = true; }
                    else if (_Chbox_Comisionables.Checked & _Chbox_Promocional.Checked & !_Chbox_Regular.Checked)
                    { _Str_Cadena = "where TPRODUCTO.ccomision='1' and TPRODUCTO.cprodregular is not null"; _Bol_Entrada = true; }
                    else if (_Chbox_Comisionables.Checked & !_Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                    { _Str_Cadena = "where TPRODUCTO.ccomision='1' and TPRODUCTO.cprodregular is null"; _Bol_Entrada = true; }
                    else if (!_Chbox_Comisionables.Checked & _Chbox_Promocional.Checked & !_Chbox_Regular.Checked)
                    { _Str_Cadena = "where TPRODUCTO.cprodregular is not null"; _Bol_Entrada = true; }
                    else if (!_Chbox_Comisionables.Checked & !_Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                    { _Str_Cadena = "where TPRODUCTO.cprodregular is null"; _Bol_Entrada = true; }
                    else if (!_Chbox_Comisionables.Checked & _Chbox_Promocional.Checked & _Chbox_Regular.Checked)
                    { _Str_Cadena = "where 0=0"; _Bol_Entrada = true; }
                    if (_Bol_Entrada)
                    {
                        if (_Txt_Buscar.Text.Trim().Length > 0)
                        { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.cnamef like('%" + _Txt_Buscar.Text.Trim() + "%')"; }
                        if (_Txt_CodigoEs.Text.Trim().Length > 0)
                        { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; }
                        if (_Txt_CodigoIn.Text.Trim().Length > 0)
                        { _Str_Cadena = _Str_Cadena + " and TPRODUCTO.ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%')"; }
                    }
                    else
                    {
                        if (_Txt_Buscar.Text.Trim().Length > 0 & _Txt_CodigoEs.Text.Trim().Length == 0 & _Txt_CodigoIn.Text.Trim().Length == 0)
                        { _Str_Cadena = "where TPRODUCTO.cnamef like('%" + _Txt_Buscar.Text.Trim() + "%')"; }
                        else if (_Txt_Buscar.Text.Trim().Length == 0 & _Txt_CodigoEs.Text.Trim().Length > 0 & _Txt_CodigoIn.Text.Trim().Length == 0)
                        { _Str_Cadena = "where TPRODUCTO.cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; }
                        else if (_Txt_Buscar.Text.Trim().Length == 0 & _Txt_CodigoEs.Text.Trim().Length == 0 & _Txt_CodigoIn.Text.Trim().Length > 0)
                        { _Str_Cadena = "where TPRODUCTO.ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%')"; }
                        else if (_Txt_Buscar.Text.Trim().Length > 0 & _Txt_CodigoEs.Text.Trim().Length > 0 & _Txt_CodigoIn.Text.Trim().Length == 0)
                        { _Str_Cadena = "where TPRODUCTO.cnamef like('%" + _Txt_Buscar.Text.Trim() + "%') and TPRODUCTO.cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; }
                        else if (_Txt_Buscar.Text.Trim().Length > 0 & _Txt_CodigoEs.Text.Trim().Length == 0 & _Txt_CodigoIn.Text.Trim().Length > 0)
                        { _Str_Cadena = "where TPRODUCTO.cnamef like('%" + _Txt_Buscar.Text.Trim() + "%') and TPRODUCTO.ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%')"; }
                        else if (_Txt_Buscar.Text.Trim().Length == 0 & _Txt_CodigoEs.Text.Trim().Length > 0 & _Txt_CodigoIn.Text.Trim().Length > 0)
                        { _Str_Cadena = "where TPRODUCTO.ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%') and TPRODUCTO.cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; }
                        else if (_Txt_Buscar.Text.Trim().Length > 0 & _Txt_CodigoEs.Text.Trim().Length > 0 & _Txt_CodigoIn.Text.Trim().Length > 0)
                        { _Str_Cadena = "where TPRODUCTO.cnamef like('%" + _Txt_Buscar.Text.Trim() + "%') and TPRODUCTO.ccodfabrica like('%" + _Txt_CodigoIn.Text.Trim() + "%') and TPRODUCTO.cproducto like('%" + _Txt_CodigoEs.Text.Trim() + "%')"; }
                    }
                }
            }
            if (_Str_Cadena.Length > 0)
            {
                Cursor = Cursors.Default;
                return _Str_Cadena;
            }
            else
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Debe especificar algún criterio de busqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return "";
            }
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

        private void _Chbox_Unidad1_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Unidad1.Checked)
            { _Cmb_Unidad1.Enabled = true; }
            else
            { _Cmb_Unidad1.Enabled = false; _Cmb_Unidad1.SelectedIndex = -1; }
        }

        private void _Chbox_Unidad2_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Unidad2.Checked)
            { _Cmb_Unidad2.Enabled = true; }
            else
            { _Cmb_Unidad2.Enabled = false; _Cmb_Unidad2.SelectedIndex = -1; }
        }
        bool _Bol_Sw = false;
        private void _Cmb_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Proveedor.SelectedIndex != -1)
            { _Mtd_Cargar_Grupo(_Cmb_Proveedor.SelectedValue.ToString()); _Chbox_Proveedores.Checked = true; _Cmb_Grupo.Enabled = true; }
            else
            {
                _Cmb_Grupo.DataSource = null; _Cmb_Grupo.Enabled = false; _Chbox_Proveedores.Checked = false; _Cmb_Proveedor.Enabled = true;
                if (_Bol_Sw)
                {
                    if (_Chbox_Proveedores.Checked)
                    {
                        _Cmb_Proveedor.Enabled = true;
                    }
                    else
                    { _Cmb_Proveedor.Enabled = false; }
                }
                _Bol_Sw = true;
            }
        }

        private void _Cmb_Grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Grupo.SelectedIndex != -1)
            {
                _Mtd_Cargar_Subgrupo(_Cmb_Proveedor.SelectedValue.ToString(), _Cmb_Grupo.SelectedValue.ToString());
                _Mtd_Cargar_Marca(_Cmb_Proveedor.SelectedValue.ToString(), _Cmb_Grupo.SelectedValue.ToString());
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
        }

        private void _Cmb_Subgrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Subgrupo.SelectedIndex != -1)
            { _Chbox_Subgrupos.Checked = true; }
            else
            { _Chbox_Subgrupos.Checked = false; }
        }

        private void _Cmb_Marca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Marca.SelectedIndex != -1)
            { _Chbox_Marcas.Checked = true; }
            else
            { _Chbox_Marcas.Checked = false; }
        }

        private void Frm_BusquedaAvanzada_Load(object sender, EventArgs e)
        {

        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            string _Str_Cadena = _Mtd_Buscar();
            if (_Str_Cadena.Trim().Length > 0)
            {
                _Frm_Formuario.GetType().GetMethod("_Mtd_Actualizar_Avanzado").Invoke(_Frm_Formuario, new object[] { _Str_Cadena });
                _Str_Cadena = "Select * from TPRODUCTO " + _Str_Cadena + " and not exists(select cproducto from TFILTROREGIONALP where TFILTROREGIONALP.cproducto=TPRODUCTO.cproducto and TFILTROREGIONALP.cdelete='0')";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
                { MessageBox.Show("No se encontraron registros...","Información",MessageBoxButtons.OK,MessageBoxIcon.Exclamation); }
                _Mtd_Ini();
                this.Hide();
            }
        }

        private void _Bt_Restablecer_Click(object sender, EventArgs e)
        {
            _Mtd_Ini();
            _Mtd_Restablecer();
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Mtd_Ini();
            this.Close();
        }
        private void _Mtd_Ini()
        {
            _Mtd_Cargar_Proveedor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _Str_Cadena = _Mtd_Buscar();
            if (_Str_Cadena.Trim().Length > 0)
            {
                _Frm_Formuario.GetType().GetMethod("_Mtd_Actualizar_ProductosDesmarcar").Invoke(_Frm_Formuario, new object[] { _Str_Cadena });
                _Str_Cadena = "Select * from TPRODUCTO " + _Str_Cadena;
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
                { MessageBox.Show("No se encontraron registros...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                _Mtd_Ini();
                this.Hide();
            }
        }
    }
}