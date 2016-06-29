using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Reporting.WinForms;
namespace T3
{
    public partial class Frm_ConsultaAuxiliarCont : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_ConsultaAuxiliarCont()
        {
            InitializeComponent();
            DateTime _Dt_Fecha = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            DateTime _Dt_Fecha_2 = Convert.ToDateTime("01/" + _Dt_Fecha.Month.ToString() + "/" + _Dt_Fecha.Year.ToString());
            _Dtp_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(_Dt_Fecha_2));
            _Dtp_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(_Dt_Fecha_2));
            _Dtp_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(_Dt_Fecha_2));
            _Dtp_Hasta.Enabled = false;
            _Dtp_Desde.Enabled = false;
        }
        CLASES._Cls_Varios_Metodos _Cls_Variosmetodos = new CLASES._Cls_Varios_Metodos(true);
        private void Frm_ConsultaAuxiliarCont_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_LlenarTreeView();
            _Mtd_Clasificacion();
            Cursor = Cursors.Default;
        }
        private void _Mtd_CargarCuentas(TreeView _Tre_View)
        {
            bool _Bol_Sw = false;
            DataSet _Ds_Aux;
            string _Str_NodoPadre = "", _Str_Nodo = "", _Str_NodoName = "", _Str_NodoPadreName = "";
            string _Str_Sql = "SELECT ccount,cname,cauxiliary,ctcount FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0 AND cactivate=1 ORDER BY ccount";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {

                _Str_Nodo = _Drow["ccount"].ToString().Trim();
                _Str_NodoName = _Drow["cname"].ToString().Trim();
                if (_Str_Nodo.IndexOf(".") > -1)
                {
                    _Str_NodoPadre = _Str_Nodo.Substring(0, _Str_Nodo.LastIndexOf("."));
                    _Str_Sql = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_NodoPadre + "'";
                    _Ds_Aux = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds_Aux.Tables[0].Rows.Count > 0)
                    {
                        _Str_NodoPadreName = _Ds_Aux.Tables[0].Rows[0]["cname"].ToString().Trim();
                    }
                    TreeNode[] _My_nodes = _Tre_View.Nodes.Find(_Str_NodoPadre, true);
                    foreach (TreeNode _My_Nodo in _My_nodes)
                    {
                        _Bol_Sw = true;
                        _My_Nodo.Nodes.Add(_Str_Nodo, _Str_Nodo + ": " + _Str_NodoName);
                        if (_Drow["cauxiliary"].ToString().Trim() == "1")
                        {
                            TreeNode[] _My_nodes_Aux = _Tre_View.Nodes.Find(_Str_Nodo, true);
                            _My_nodes_Aux[0].Tag = "1";
                        }
                        else
                        {
                            if (_Drow["ctcount"].ToString().Trim() == "D")
                            {
                                TreeNode[] _My_nodes_Aux = _Tre_View.Nodes.Find(_Str_Nodo, true);
                                _Tre_View.Nodes.Remove(_My_nodes_Aux[0]);
                            }
                            else
                            {
                                TreeNode[] _My_nodes_Aux = _Tre_View.Nodes.Find(_Str_Nodo, true);
                                _My_nodes_Aux[0].Tag = "0";
                            }
                        }

                    }
                    if (!_Bol_Sw)
                    {//INGRESO EL NODO PADRE
                        _Tre_View.Nodes.Add(_Str_NodoPadre, _Str_NodoPadre + ": " + _Str_NodoPadreName);
                        if (_Drow["cauxiliary"].ToString().Trim() == "1")
                        {
                            TreeNode[] _My_nodes_Aux = _Tre_View.Nodes.Find(_Str_NodoPadre, true);
                            _My_nodes_Aux[0].Tag = "1";
                        }
                        else
                        {
                            TreeNode[] _My_nodes_Aux = _Tre_View.Nodes.Find(_Str_NodoPadre, true);
                            _My_nodes_Aux[0].Tag = "0";
                        }
                    }
                }
                else
                {
                    _Tre_View.Nodes.Add(_Str_Nodo, _Str_Nodo + ": " + _Str_NodoName);
                    if (_Drow["cauxiliary"].ToString().Trim() == "1")
                    {
                        TreeNode[] _My_nodes_Aux = _Tre_View.Nodes.Find(_Str_Nodo, true);
                        _My_nodes_Aux[0].Tag = "1";
                    }
                    else
                    {
                        if (_Drow["ctcount"].ToString().Trim() == "D")
                        {
                            TreeNode[] _My_nodes_Aux = _Tre_View.Nodes.Find(_Str_Nodo, true);
                            _Tre_View.Nodes.Remove(_My_nodes_Aux[0]);
                        }
                        else
                        {
                            TreeNode[] _My_nodes_Aux = _Tre_View.Nodes.Find(_Str_Nodo, true);
                            _My_nodes_Aux[0].Tag = "0";
                        }
                    }
                }

            }
            _Tre_View.CollapseAll();
        }
        private string _Mtd_DescripcionTipoAux(string _P_Str_Tipo)
        {
            string _Str_Cadena = "SELECT RTRIM(cidtipoauxiliar)+': '+RTRIM(cdescripcion) FROM TTIPAUXILIARCONT WHERE cactivo='1' AND cdelete='0' AND cidtipoauxiliar='" + _P_Str_Tipo + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim().ToUpper();
        }
        private bool _Mtd_EjecitarComparacionNodos(string _P_Str_NodoActual,string _P_Str_NodoComparar)
        {
            string _Str_Cadena="SELECT CASE WHEN '" + _P_Str_NodoComparar + "'>'" + _P_Str_NodoActual + "' THEN 1 ELSE 0 END";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim() == "1";
        }
        private void _Mtd_CargarTreeView(TreeView _Tre_View)
        {
            _Tre_View.Nodes.Clear();
            string _Str_Cadena = "SELECT DISTINCT SUBSTRING(cidtipoauxiliar,1,1) FROM TTIPAUXILIARCONT WHERE cactivo='1' AND cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            DataSet _Ds2 = new DataSet();
            foreach (DataRow _Row_Padre in _Ds.Tables[0].Rows)
            {
                _Tre_View.Nodes.Add(_Mtd_DescripcionTipoAux(_Row_Padre[0].ToString().Trim()));
                _Tre_View.Nodes[_Tre_View.Nodes.Count - 1].Name = _Row_Padre[0].ToString().Trim();
                _Str_Cadena = "SELECT cidtipoauxiliar FROM TTIPAUXILIARCONT WHERE cactivo='1' AND cdelete='0' AND cidtipoauxiliar LIKE '" + _Row_Padre[0].ToString().Trim() + "%'";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                foreach (DataRow _Row_Nodos in _Ds2.Tables[0].Rows)
                {
                    foreach (TreeNode _TreN in _Tre_View.Nodes)
                    {
                        if (_Row_Nodos[0].ToString().Trim().Length != 1)
                        { _Mtd_RecorrerNodo(_TreN, _Row_Nodos[0].ToString().Trim(), true); }
                    }
                }
            }
        }
        private void _Mtd_RecorrerNodo(TreeNode _Pr_Nodo, string _P_Str_NuevoNodo, bool _P_Bol_Sw)
        {
            if (_Pr_Nodo.Nodes.Count > 0 | !_P_Bol_Sw)
            {
                foreach (TreeNode _My_Nodo in _Pr_Nodo.Nodes)
                {
                    if (_P_Str_NuevoNodo.Remove(_P_Str_NuevoNodo.Length - 2) == _My_Nodo.Name)
                    {
                        _My_Nodo.Nodes.Add(_Mtd_DescripcionTipoAux(_P_Str_NuevoNodo));
                        _My_Nodo.Nodes[_My_Nodo.Nodes.Count - 1].Name = _P_Str_NuevoNodo;
                        break;
                    }
                    else
                    {

                        _Mtd_RecorrerNodo(_My_Nodo, _P_Str_NuevoNodo, false);
                    }
                }
            }
            else
            {
                _Pr_Nodo.Nodes.Add(_Mtd_DescripcionTipoAux(_P_Str_NuevoNodo));
                _Pr_Nodo.Nodes[_Pr_Nodo.Nodes.Count - 1].Name = _P_Str_NuevoNodo;
            }
        }
        private void _Mtd_BorrarCuentas(TreeView _Tre_View)
        {
            try
            {
                bool _Bol_Borrar = true;
            B:
                int _Int_Nodos = _Tre_View.Nodes.Count;
                foreach (TreeNode _Tre_Nodo in _Tre_View.Nodes)
                {
                    if (_Int_Nodos > _Tre_View.Nodes.Count)
                    {
                        goto B;
                    }
                    if (_Tre_Nodo.Nodes.Count == 0 && _Tre_Nodo.Tag.ToString() == "0")
                    {
                        _Tre_View.Nodes.Remove(_Tre_Nodo);
                    }
                    else
                    {
                        _Mtd_BorrarCuentasDetail(_Tre_View, _Tre_Nodo);
                    }
                    if (_Tre_Nodo.Nodes.Count > 0)
                    {
                        _Bol_Borrar = false;
                    }
                    if (_Bol_Borrar)
                    {
                        _Tre_View.Nodes.Remove(_Tre_Nodo);
                    }
                    _Bol_Borrar = true;
                }

            }
            catch
            {
            }
        }
        private void _Mtd_BorrarCuentasDetail(TreeView _Tre_View, TreeNode _Tre_Nodo)
        {
            try
            {
            A:
                int _Int_Nodos = _Tre_Nodo.Nodes.Count;
                foreach (TreeNode _Tre_Nodo_ in _Tre_Nodo.Nodes)
                {
                    if (_Int_Nodos > _Tre_Nodo.Nodes.Count)
                    {
                        goto A;
                    }
                    if (_Tre_Nodo_.Nodes.Count == 0 && _Tre_Nodo_.Tag.ToString() == "0")
                    {
                        _Tre_View.Nodes.Remove(_Tre_Nodo_);
                    }
                    else
                    {
                        _Mtd_BorrarCuentasDetail(_Tre_View, _Tre_Nodo_);
                    }
                }
            }
            catch
            {
            }
        }

        private void _Tree_CuentaCont_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (!(e.Node.Tag.ToString() == "1"))
            {
                e.Cancel = true;
            }
        }
        private void _Mtd_LlenarTreeView()
        {
            _Tree_CuentaCont.Nodes.Clear();
            _Tree_CuentaCont.CheckBoxes = true;
            _Tree_CuentaTipo.Nodes.Clear();
            _Tree_CuentaTipo.CheckBoxes = true;
            _Mtd_CargarTreeView(_Tree_CuentaTipo);
            _Mtd_CargarCuentas(_Tree_CuentaCont);
            _Mtd_BorrarCuentas(_Tree_CuentaCont);
        }
        private void _Mtd_CargarMeses()
        {
            string _Str_Sql = "SELECT DISTINCT CONVERT(DATETIME,'01'+'/'+CONVERT(VARCHAR,cmontacco)+'/'+CONVERT(VARCHAR,cyearacco)) AS EEE,CONVERT(VARCHAR,cmontacco)+'-'+CONVERT(VARCHAR,cyearacco) AS CVALOR FROM TMESCONTABLE WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND cmontacco>0 and cyearacco>0 ORDER BY EEE DESC ";
            //string _Str_Sql = "SELECT cmontacco,CONVERT(VARCHAR,cmontacco)+'-'+CONVERT(VARCHAR,cyearacco) FROM TMESCONTABLE where ccompany='" + Frm_Padre._Str_Comp + "' AND cmontacco>0 and cyearacco>0";
            _Cls_Variosmetodos._Mtd_CargarCombo(_Cmb_AnoContable, _Str_Sql);
        }
        private void _Mtd_Clasificacion()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_Clasificacion.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            string[,] _Str_Clasificacion = null;
            _Str_Clasificacion = new string[,] { { "Clientes", "1" }, { "Proveedor Materia Prima", "2" }, { "Proveedor de Servicio u otros", "3" }, { "Empleados", "5" }, { "Banco", "6" }, { "Activo", "7" }, { "Compañía relacionada", "9" }, { "Accionistas", "8" } };
            for (int i = 0; i < _Str_Clasificacion.GetLength(0); i++)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_Str_Clasificacion[i, 0].ToUpper(), _Str_Clasificacion[i, 1]));
            }
            _Cmb_Clasificacion.DataSource = _myArrayList;
            _Cmb_Clasificacion.DisplayMember = "Display";
            _Cmb_Clasificacion.ValueMember = "Value";
            _Cmb_Clasificacion.SelectedValue = "nulo";
        }
        private void _Rbt_CompSaldo_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_CompSaldo.Checked)
            {
                _Rpt_ReportAuxConta.Reset();
                _Rpt_ReportAuxClasif.Reset();
                _Rpt_ReportAuxTipo.Reset();
                _Pnl_Fechas.Visible = false;
            }
        }

        private void _Rbt_CompDetallada_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_CompDetallada.Checked)
            {
                _Rpt_ReportAuxConta.Reset();
                _Rpt_ReportAuxClasif.Reset();
                _Rpt_ReportAuxTipo.Reset();
                _Mtd_CargarMeses();
                _Pnl_Fechas.Visible = true;
            }
        }
        private string[] _Mtd_ExtraerMesAno(string _P_Str_Items)
        {
            int _Int_i = _P_Str_Items.Trim().IndexOf("-");
            return new string[] { _P_Str_Items.Substring(0, _Int_i).Trim(), _P_Str_Items.Substring(_Int_i + 1).Trim() };
        }
        private void _Cmb_AnoContable_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarMeses();
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

        //--------------------------------------------------------------
        private void _Mtd_Checked(TreeNode _Pr_Nodo, bool _P_Bol_Check)
        {
            foreach (TreeNode _My_Nodo in _Pr_Nodo.Nodes)
            {
                _My_Nodo.Checked = _P_Bol_Check;
                _Mtd_Checked(_My_Nodo, _P_Bol_Check);
            }
        }
        private void _Mtd_Seleccionar(TreeView _P_TreeV, bool _P_Bol_Check)
        {
            if (_P_Bol_Check)
            { _P_TreeV.ExpandAll(); }
            else
            { _P_TreeV.CollapseAll(); }
            foreach (TreeNode _TreN in _P_TreeV.Nodes)
            {
                _Mtd_Checked(_TreN, _P_Bol_Check);
            }
        }    
        private DataSet _Mtd_CrearDataSets()
        {
            string _Str_Cadena = "SELECT cname, ccompany, cnumdocu, ctdocument, cfechaemision, cfechavencimiento, cmonto, cidtipoauxiliar, cidmovauxiliar, cidauxiliarcont, cidcomprob, cdebe, chaber, cactivo, cmontacco, cyearacco, cnameaux, ccount,cnumdocuafec,cclasificauxiliar FROM VST_T3_MOVINAUXILIAR WHERE 0>1";
            if (_Tb_Tab.SelectedIndex == 0)
            { return _Mtd_RecorrerSeleccionados(_Tree_CuentaCont, Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena)); }
            else if (_Tb_Tab.SelectedIndex == 1)
            { return _Mtd_LLenarDataSetsClasif(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena)); }
            else
            { return _Mtd_RecorrerSeleccionados(_Tree_CuentaTipo, Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena)); }
        }
        private DataSet _Mtd_LLenarDataSetsClasif(DataSet _P_Ds_DataSet)
        {
            if (_Rb_Todos.Checked)
            {
                _Mtd_CargarDataSets("", _P_Ds_DataSet, true);
            }
            else
            {
                foreach (int _Int_Index in _ChkList_Aux_Clasif.CheckedIndices)
                {
                    _Mtd_CargarDataSets(_Str_ID_Aux_Clasif[_Int_Index].ToString(), _P_Ds_DataSet, false);
                }
            }
            return _P_Ds_DataSet;
        }
        private DataSet _Mtd_RecorrerSeleccionados(TreeView _P_TreeV, DataSet _P_Ds_DataSet)
        {
            foreach (TreeNode _TreN in _P_TreeV.Nodes)
            {
                _Mtd_LLenarDataSetsCuent(_TreN, _P_Ds_DataSet);
            }
            return _P_Ds_DataSet;
        }
        private void _Mtd_LLenarDataSetsCuent(TreeNode _Pr_Nodo, DataSet _P_Ds_DataSet)
        {
            foreach (TreeNode _My_Nodo in _Pr_Nodo.Nodes)
            {
                if (_My_Nodo.Checked)
                {
                    _Mtd_CargarDataSets(_My_Nodo.Name.Trim(), _P_Ds_DataSet, false);
                }
                _Mtd_LLenarDataSetsCuent(_My_Nodo, _P_Ds_DataSet);
            }
        }

        private void _Mtd_CargarDataSets(string _P_Str_Criterio, DataSet _P_Ds_DataSet, bool _P_Bol_Todo)//El Último parametro solo se utiliza para la consulta por Clasificación
        {
            //------------
            string _Str_Cadena = "";
            if (_Tb_Tab.SelectedIndex == 0)
            { _Str_Cadena = "SELECT cname, ccompany, cnumdocu, ctdocument, cfechaemision, cfechavencimiento, cmonto, cidtipoauxiliar, cidmovauxiliar, cidauxiliarcont, cidcomprob, cdebe, chaber, cactivo, cmontacco, cyearacco, cnameaux, ccount, cnumdocuafec,cclasificauxiliar FROM VST_T3_MOVINAUXILIAR WHERE (ccompany = '" + Frm_Padre._Str_Comp + "') AND (ccount='" + _P_Str_Criterio + "')"; }
            else if (_Tb_Tab.SelectedIndex == 1)
            {
                if (Convert.ToString(_Cmb_Clasificacion.SelectedValue) == "1") //Clientes
                {
                    if (_P_Bol_Todo)
                    { _Str_Cadena = "SELECT cname, ccompany, cnumdocu, ctdocument, cfechaemision, cfechavencimiento, cmonto, cidtipoauxiliar, cidmovauxiliar, cidauxiliarcont, cidcomprob, cdebe, chaber, cactivo, cmontacco, cyearacco, cnameaux, ccount, cnumdocuafec,cclasificauxiliar FROM VST_T3_MOVINAUXILIAR WHERE (ccompany = '" + Frm_Padre._Str_Comp + "') AND ((cclasificauxiliar='" + Convert.ToString(_Cmb_Clasificacion.SelectedValue) + "') OR (cclasificauxiliar='9'))"; }
                    else
                    { _Str_Cadena = "SELECT cname, ccompany, cnumdocu, ctdocument, cfechaemision, cfechavencimiento, cmonto, cidtipoauxiliar, cidmovauxiliar, cidauxiliarcont, cidcomprob, cdebe, chaber, cactivo, cmontacco, cyearacco, cnameaux, ccount, cnumdocuafec,cclasificauxiliar FROM VST_T3_MOVINAUXILIAR WHERE (ccompany = '" + Frm_Padre._Str_Comp + "') AND ((cclasificauxiliar='" + Convert.ToString(_Cmb_Clasificacion.SelectedValue) + "') OR (cclasificauxiliar='9')) AND (cidauxiliarcont='" + _P_Str_Criterio + "')"; }
                }
                else if (Convert.ToString(_Cmb_Clasificacion.SelectedValue) == "3") //Proveedor Servicios u Otros
                {
                    if (_P_Bol_Todo)
                    { _Str_Cadena = "SELECT cname, ccompany, cnumdocu, ctdocument, cfechaemision, cfechavencimiento, cmonto, cidtipoauxiliar, cidmovauxiliar, cidauxiliarcont, cidcomprob, cdebe, chaber, cactivo, cmontacco, cyearacco, cnameaux, ccount, cnumdocuafec,cclasificauxiliar FROM VST_T3_MOVINAUXILIAR WHERE (ccompany = '" + Frm_Padre._Str_Comp + "') AND ((cclasificauxiliar='" + Convert.ToString(_Cmb_Clasificacion.SelectedValue) + "') OR (cclasificauxiliar='4') OR (cclasificauxiliar='9'))"; }
                    else
                    { _Str_Cadena = "SELECT cname, ccompany, cnumdocu, ctdocument, cfechaemision, cfechavencimiento, cmonto, cidtipoauxiliar, cidmovauxiliar, cidauxiliarcont, cidcomprob, cdebe, chaber, cactivo, cmontacco, cyearacco, cnameaux, ccount, cnumdocuafec,cclasificauxiliar FROM VST_T3_MOVINAUXILIAR WHERE (ccompany = '" + Frm_Padre._Str_Comp + "') AND ((cclasificauxiliar='" + Convert.ToString(_Cmb_Clasificacion.SelectedValue) + "') OR (cclasificauxiliar='4') OR (cclasificauxiliar='9')) AND (cidauxiliarcont='" + _P_Str_Criterio + "')"; }
                }
                else if (Convert.ToString(_Cmb_Clasificacion.SelectedValue) == "9") //Compañias relacionadas
                {
                    if (_P_Bol_Todo)
                    {
                        //Se cambio segun ticket 6475//_Str_Cadena = "SELECT cname, ccompany, cnumdocu, ctdocument, cfechaemision, cfechavencimiento, cmonto, cidtipoauxiliar, cidmovauxiliar, cidauxiliarcont, cidcomprob, cdebe, chaber, cactivo, cmontacco, cyearacco, cnameaux, ccount, cnumdocuafec,cclasificauxiliar FROM VST_T3_MOVINAUXILIAR WHERE (ccompany = '" + Frm_Padre._Str_Comp + "') AND (cclasificauxiliar='9')";
                        _Str_Cadena = "SELECT VST_T3_MOVINAUXILIAR.cname, VST_T3_MOVINAUXILIAR.ccompany, VST_T3_MOVINAUXILIAR.cnumdocu, VST_T3_MOVINAUXILIAR.ctdocument, VST_T3_MOVINAUXILIAR.cfechaemision, VST_T3_MOVINAUXILIAR.cfechavencimiento, VST_T3_MOVINAUXILIAR.cmonto, VST_T3_MOVINAUXILIAR.cidtipoauxiliar, VST_T3_MOVINAUXILIAR.cidmovauxiliar, VST_T3_MOVINAUXILIAR.cidauxiliarcont, VST_T3_MOVINAUXILIAR.cidcomprob, VST_T3_MOVINAUXILIAR.cdebe, VST_T3_MOVINAUXILIAR.chaber, VST_T3_MOVINAUXILIAR.cactivo, VST_T3_MOVINAUXILIAR.cmontacco, VST_T3_MOVINAUXILIAR.cyearacco, VST_T3_MOVINAUXILIAR.CNAMEAUX, VST_T3_MOVINAUXILIAR.ccount, VST_T3_MOVINAUXILIAR.cnumdocuafec, VST_T3_MOVINAUXILIAR.cclasificauxiliar FROM VST_T3_MOVINAUXILIAR INNER JOIN TICRELAPROCLI ON VST_T3_MOVINAUXILIAR.cidauxiliarcont = TICRELAPROCLI.cproveedor ";
                        _Str_Cadena += "WHERE (VST_T3_MOVINAUXILIAR.ccompany = '" + Frm_Padre._Str_Comp + "') AND (VST_T3_MOVINAUXILIAR.cclasificauxiliar='9')";
                    }
                    else
                    {
                        //Se cambio segun ticket 6475////_Str_Cadena = "SELECT cname, ccompany, cnumdocu, ctdocument, cfechaemision, cfechavencimiento, cmonto, cidtipoauxiliar, cidmovauxiliar, cidauxiliarcont, cidcomprob, cdebe, chaber, cactivo, cmontacco, cyearacco, cnameaux, ccount, cnumdocuafec,cclasificauxiliar FROM VST_T3_MOVINAUXILIAR WHERE (ccompany = '" + Frm_Padre._Str_Comp + "') AND (cclasificauxiliar='9') AND (cidauxiliarcont='" + _P_Str_Criterio + "')";
                        _Str_Cadena = "SELECT VST_T3_MOVINAUXILIAR.cname, VST_T3_MOVINAUXILIAR.ccompany, VST_T3_MOVINAUXILIAR.cnumdocu, VST_T3_MOVINAUXILIAR.ctdocument, VST_T3_MOVINAUXILIAR.cfechaemision, VST_T3_MOVINAUXILIAR.cfechavencimiento, VST_T3_MOVINAUXILIAR.cmonto, VST_T3_MOVINAUXILIAR.cidtipoauxiliar, VST_T3_MOVINAUXILIAR.cidmovauxiliar, VST_T3_MOVINAUXILIAR.cidauxiliarcont, VST_T3_MOVINAUXILIAR.cidcomprob, VST_T3_MOVINAUXILIAR.cdebe, VST_T3_MOVINAUXILIAR.chaber, VST_T3_MOVINAUXILIAR.cactivo, VST_T3_MOVINAUXILIAR.cmontacco, VST_T3_MOVINAUXILIAR.cyearacco, VST_T3_MOVINAUXILIAR.CNAMEAUX, VST_T3_MOVINAUXILIAR.ccount, VST_T3_MOVINAUXILIAR.cnumdocuafec, VST_T3_MOVINAUXILIAR.cclasificauxiliar FROM VST_T3_MOVINAUXILIAR INNER JOIN TICRELAPROCLI ON VST_T3_MOVINAUXILIAR.cidauxiliarcont = TICRELAPROCLI.cproveedor ";
                        _Str_Cadena += "WHERE (VST_T3_MOVINAUXILIAR.ccompany = '" + Frm_Padre._Str_Comp + "') AND (VST_T3_MOVINAUXILIAR.cclasificauxiliar='9') AND (VST_T3_MOVINAUXILIAR.cidauxiliarcont='" + _P_Str_Criterio + "')";
                    }
                }
                else
                {
                    if (_P_Bol_Todo)
                    { _Str_Cadena = "SELECT cname, ccompany, cnumdocu, ctdocument, cfechaemision, cfechavencimiento, cmonto, cidtipoauxiliar, cidmovauxiliar, cidauxiliarcont, cidcomprob, cdebe, chaber, cactivo, cmontacco, cyearacco, cnameaux, ccount, cnumdocuafec,cclasificauxiliar FROM VST_T3_MOVINAUXILIAR WHERE (ccompany = '" + Frm_Padre._Str_Comp + "') AND (cclasificauxiliar='" + Convert.ToString(_Cmb_Clasificacion.SelectedValue) + "')"; }
                    else
                    { _Str_Cadena = "SELECT cname, ccompany, cnumdocu, ctdocument, cfechaemision, cfechavencimiento, cmonto, cidtipoauxiliar, cidmovauxiliar, cidauxiliarcont, cidcomprob, cdebe, chaber, cactivo, cmontacco, cyearacco, cnameaux, ccount, cnumdocuafec,cclasificauxiliar FROM VST_T3_MOVINAUXILIAR WHERE (ccompany = '" + Frm_Padre._Str_Comp + "') AND (cclasificauxiliar='" + Convert.ToString(_Cmb_Clasificacion.SelectedValue) + "') AND (cidauxiliarcont='" + _P_Str_Criterio + "')"; }
                }
            }
            else
            { _Str_Cadena = "SELECT cname, ccompany, cnumdocu, ctdocument, cfechaemision, cfechavencimiento, cmonto, cidtipoauxiliar, cidmovauxiliar, cidauxiliarcont, cidcomprob, cdebe, chaber, cactivo, cmontacco, cyearacco, cnameaux, ccount, cnumdocuafec,cclasificauxiliar FROM VST_T3_MOVINAUXILIAR WHERE (ccompany = '" + Frm_Padre._Str_Comp + "') AND (cidtipoauxiliar='" + _P_Str_Criterio + "')"; }
            //------------
            if (_Rbt_CompSaldo.Checked)
            { _Str_Cadena += " AND (cactivo = '1')"; }
            else
            {
                if (_Rbt_PorAno.Checked)
                {
                    _Str_Cadena += " AND (CONVERT(VARCHAR,cmontacco)+'-'+CONVERT(VARCHAR,cyearacco)='" + _Cmb_AnoContable.Text.Trim() + "')";
                }
                else if(_Rbt_PorMes.Checked)
                {
                    DateTime _Dt_FechaIni=Convert.ToDateTime("01/"+_Dtp_Desde.Value.Month.ToString()+"/"+_Dtp_Desde.Value.Year.ToString());
                    DateTime _Dt_FechaFin = Convert.ToDateTime("01/" + _Dtp_Hasta.Value.Month.ToString() + "/" + _Dtp_Hasta.Value.Year.ToString()).AddMonths(1).AddDays(-1);
                    _Str_Cadena += " AND convert(datetime,'01/'+convert(varchar,cmontacco)+'/'+convert(varchar,cyearacco)) BETWEEN '" + _Dt_FechaIni.ToString("dd/MM/yyyy") + "' and '" + _Dt_FechaFin.ToString("dd/MM/yyyy") + "'";
                }
            }
            _Str_Cadena += " ORDER BY cidauxiliarcont";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _P_Ds_DataSet.Tables[0].Rows.Add(_Row.ItemArray);
            }
        }
        private void _Mtd_Consultar()
        {
            ReportViewer _Rpt_Report;
            if (_Tb_Tab.SelectedIndex == 0)
            { _Rpt_Report = _Rpt_ReportAuxConta; }
            else if (_Tb_Tab.SelectedIndex == 1)
            { _Rpt_Report = _Rpt_ReportAuxClasif; }
            else
            { _Rpt_Report = _Rpt_ReportAuxTipo; }
            if (_Rbt_CompSaldo.Checked)
            {
                Cursor = Cursors.WaitCursor;
                DataSet _Ds = _Mtd_CrearDataSets();
                Cursor = Cursors.Default;
                _Rpt_Report.Reset(); 
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    Cursor = Cursors.WaitCursor;
                    _Rpt_Report.LocalReport.ReportEmbeddedResource = "T3.ReportServLocal.Rpt_AuxContable.rdlc";
                    _Rpt_Report.LocalReport.DataSources.Add(new ReportDataSource("DataSetRpt_VST_T3_MOVINAUXILIAR", _Ds.Tables[0]));
                    _Rpt_Report.LocalReport.Refresh();
                    _Rpt_Report.RefreshReport();
                    Cursor = Cursors.Default;
                }
                else
                { MessageBox.Show("La consulta no devolvio registros", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else
            {
                if (_Rbt_PorAno.Checked)
                {
                    if (_Cmb_AnoContable.SelectedIndex > 0)
                    {
                        Cursor = Cursors.WaitCursor;
                        DataSet _Ds = _Mtd_CrearDataSets();
                        Cursor = Cursors.Default;
                        _Rpt_Report.Reset();
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            Cursor = Cursors.WaitCursor;
                            _Rpt_Report.LocalReport.ReportEmbeddedResource = "T3.ReportServLocal.Rpt_AuxContable.rdlc";
                            _Rpt_Report.LocalReport.DataSources.Add(new ReportDataSource("DataSetRpt_VST_T3_MOVINAUXILIAR", _Ds.Tables[0]));
                            _Rpt_Report.LocalReport.Refresh();
                            _Rpt_Report.RefreshReport();
                            Cursor = Cursors.Default;
                        }
                        else
                        { MessageBox.Show("La consulta no devolvio registros", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una cuenta contable para realizar la consulta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (_Rbt_PorMes.Checked)
                {
                    Cursor = Cursors.WaitCursor;
                    DataSet _Ds = _Mtd_CrearDataSets();
                    Cursor = Cursors.Default;
                    _Rpt_Report.Reset();
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        Cursor = Cursors.WaitCursor;
                        _Rpt_Report.LocalReport.ReportEmbeddedResource = "T3.ReportServLocal.Rpt_AuxContable.rdlc";
                        _Rpt_Report.LocalReport.DataSources.Add(new ReportDataSource("DataSetRpt_VST_T3_MOVINAUXILIAR", _Ds.Tables[0]));
                        _Rpt_Report.LocalReport.Refresh();
                        _Rpt_Report.RefreshReport();
                        Cursor = Cursors.Default;
                    }
                    else
                    { MessageBox.Show("La consulta no devolvio registros", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
            }
        }
        private void _Bt_Selec_Click(object sender, EventArgs e)
        {
            _Mtd_Seleccionar(_Tree_CuentaCont, true);
        }

        private void _Bt_Quit_Click(object sender, EventArgs e)
        {
            _Mtd_Seleccionar(_Tree_CuentaCont, false);
        }

        private void _Btn_ExpandirCont_Click(object sender, EventArgs e)
        {
            _Tree_CuentaCont.ExpandAll();
            _Tree_CuentaCont.SelectedNode = _Tree_CuentaCont.Nodes[0];
        }

        private void _Btn_ColapsarCont_Click(object sender, EventArgs e)
        {
            _Tree_CuentaCont.CollapseAll();
            _Tree_CuentaCont.SelectedNode = _Tree_CuentaCont.Nodes[0];
        }

        private void _Cmb_Clasificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ChkList_Aux_Clasif.Items.Clear();
            _Str_ID_Aux_Clasif = new string[0];
            _Rb_Elegir.Enabled = _Cmb_Clasificacion.SelectedIndex > 0;
            _Rb_Todos.Enabled = _Cmb_Clasificacion.SelectedIndex > 0;
            _Bt_Consultar_Clasif.Enabled = _Cmb_Clasificacion.SelectedIndex > 0;
            _Bt_Agregar.Enabled = _Rb_Elegir.Enabled & _Rb_Elegir.Checked;
            _Bt_Eliminar.Enabled = _Rb_Elegir.Enabled & _Rb_Elegir.Checked;
        }

        private void _Rb_Elegir_CheckedChanged(object sender, EventArgs e)
        {
            _Bt_Agregar.Enabled = _Rb_Elegir.Enabled & _Rb_Elegir.Checked;
            _Bt_Eliminar.Enabled = _Rb_Elegir.Enabled & _Rb_Elegir.Checked;
        }

        private void _Bt_Eliminar_Click(object sender, EventArgs e)
        {
            _ChkList_Aux_Clasif.Items.Clear();
            _Str_ID_Aux_Clasif = new string[0];
        }

        string[] _Str_ID_Aux_Clasif = new string[0];
        private void _Mtd_ID_AuxiliarContClasif(string _P_Str_ID)
        {
            _Str_ID_Aux_Clasif = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_ID_Aux_Clasif, _Str_ID_Aux_Clasif.Length + 1);
            _Str_ID_Aux_Clasif[_Str_ID_Aux_Clasif.Length - 1] = _P_Str_ID;
        }
        string[] _Str_ID_Aux_Tipo = new string[0];
        private void _Mtd_ID_AuxiliarContTipo(string _P_Str_ID)
        {
            _Str_ID_Aux_Tipo = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_ID_Aux_Tipo, _Str_ID_Aux_Tipo.Length + 1);
            _Str_ID_Aux_Tipo[_Str_ID_Aux_Tipo.Length - 1] = _P_Str_ID;
        }
        private string _Mtd_NoMostrar(int _P_Int_Clasificacion)
        {
            string _Str_Cadena = "";
            if (_P_Int_Clasificacion == 1)
            {
                foreach (string _Str_Temp in _Str_ID_Aux_Clasif)
                {
                    _Str_Cadena += " AND (ccliente<>'" + _Str_Temp + "')";
                }
            }
            else if (_P_Int_Clasificacion == 2 | _P_Int_Clasificacion == 3 | _P_Int_Clasificacion == 4)
            {
                foreach (string _Str_Temp in _Str_ID_Aux_Clasif)
                {
                    _Str_Cadena += " AND (TPROVEEDOR.cproveedor<>'" + _Str_Temp + "')";
                }
            }
            else if (_P_Int_Clasificacion == 6)
            {
                foreach (string _Str_Temp in _Str_ID_Aux_Clasif)
                {
                    _Str_Cadena += " AND (cbanco<>'" + _Str_Temp + "')";
                }
            }
            return _Str_Cadena;
        }
        private void _Bt_Agregar_Click(object sender, EventArgs e)
        {
            string _Str_Cadena = "";
            TextBox _Txt_ID_Auxiliar = new TextBox();
            if (Convert.ToString(_Cmb_Clasificacion.SelectedValue).Trim() == "1")
            {
                Cursor = Cursors.WaitCursor;
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(75, _Txt_ID_Auxiliar, 0, _Mtd_NoMostrar(Convert.ToInt32(_Cmb_Clasificacion.SelectedValue)));
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
            }
            else if (Convert.ToString(_Cmb_Clasificacion.SelectedValue).Trim() == "2")
            {
                _Str_Cadena = " AND cglobal='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "'";
                Cursor = Cursors.WaitCursor;
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(50, _Txt_ID_Auxiliar, 0, _Str_Cadena + _Mtd_NoMostrar(Convert.ToInt32(_Cmb_Clasificacion.SelectedValue)));
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
            }
            else if (Convert.ToString(_Cmb_Clasificacion.SelectedValue).Trim() == "3")
            {
                _Str_Cadena = " AND (cglobal='0' or cglobal='2') AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "'";
                Cursor = Cursors.WaitCursor;
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(50, _Txt_ID_Auxiliar, 0, _Str_Cadena + _Mtd_NoMostrar(Convert.ToInt32(_Cmb_Clasificacion.SelectedValue)));
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
            }
            else if (Convert.ToString(_Cmb_Clasificacion.SelectedValue).Trim() == "4")
            {
                _Str_Cadena = " AND cglobal='2' AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "'";
                Cursor = Cursors.WaitCursor;
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(50, _Txt_ID_Auxiliar, 0, _Str_Cadena + _Mtd_NoMostrar(Convert.ToInt32(_Cmb_Clasificacion.SelectedValue)));
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
            }
            else if (Convert.ToString(_Cmb_Clasificacion.SelectedValue).Trim() == "6")
            {
                Cursor = Cursors.WaitCursor;
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(76, _Txt_ID_Auxiliar, 0, _Mtd_NoMostrar(Convert.ToInt32(_Cmb_Clasificacion.SelectedValue)));
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
            }
            else if (Convert.ToString(_Cmb_Clasificacion.SelectedValue).Trim() == "9")
            {
                Cursor = Cursors.WaitCursor;
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(95, _Txt_ID_Auxiliar, 0, "");
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
            }
            if (_Txt_ID_Auxiliar.Text.Trim().Length > 0)
            {
                _ChkList_Aux_Clasif.Items.Add(Convert.ToString(_Txt_ID_Auxiliar.Tag).Trim() + " - " + _Txt_ID_Auxiliar.Text);
                _ChkList_Aux_Clasif.SetItemChecked(_ChkList_Aux_Clasif.Items.Count - 1, true);
                _Mtd_ID_AuxiliarContClasif(Convert.ToString(_Txt_ID_Auxiliar.Tag));
            }
        }
        private void _Bt_Consultar_Cuent_Click(object sender, EventArgs e)
        {
            _Err_Error.Dispose();
            _Mtd_Consultar();
        }

        private void _Bt_Consultar_Clasif_Click(object sender, EventArgs e)
        {
            _Err_Error.Dispose();
            _Mtd_Consultar();
        }

        private void _Bt_Consultar_Tipo_Click(object sender, EventArgs e)
        {
            _Err_Error.Dispose();
            _Mtd_Consultar();
        }

        private void _Btn_ExpandirTip_Click(object sender, EventArgs e)
        {
            _Tree_CuentaTipo.ExpandAll();
            _Tree_CuentaTipo.SelectedNode = _Tree_CuentaTipo.Nodes[0];
        }

        private void _Btn_ColapsarTip_Click(object sender, EventArgs e)
        {
            _Tree_CuentaTipo.CollapseAll();
            _Tree_CuentaTipo.SelectedNode = _Tree_CuentaTipo.Nodes[0];
        }

        private void _Rb_Todos_CheckedChanged(object sender, EventArgs e)
        {
            _ChkList_Aux_Clasif.Items.Clear();
            _Str_ID_Aux_Clasif = new string[0];
        }

        private void _Bt_Selec_Tip_Click(object sender, EventArgs e)
        {
            _Mtd_Seleccionar(_Tree_CuentaTipo, true);
        }

        private void _Bt_Quit_Tip_Click(object sender, EventArgs e)
        {
            _Mtd_Seleccionar(_Tree_CuentaTipo, false);
        }

        private void _Tree_CuentaTipo_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            { e.Cancel = true; }
        }

        private void _Dtp_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dtp_Desde.MaxDate = _Dtp_Hasta.Value;
        }

        private void _Rbt_PorAno_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_PorAno.Checked)
            {
                _Dtp_Desde.Enabled = false;
                _Dtp_Hasta.Enabled = false;
                _Dtp_Desde.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
                _Dtp_Desde.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
                _Dtp_Hasta.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
                _Cmb_AnoContable.Enabled = true;
            }
        }

        private void _Rbt_PorMes_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_PorMes.Checked)
            {
                _Dtp_Desde.Enabled = true;
                _Dtp_Hasta.Enabled = true;
                _Dtp_Desde.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
                _Dtp_Desde.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
                _Dtp_Hasta.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
                _Cmb_AnoContable.Enabled = false;
                _Cmb_AnoContable.SelectedIndex = 0;
            }
        }

        //--------------------------------------------------------------
    }
}
