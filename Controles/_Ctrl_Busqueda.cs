using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace T3.Controles
{
    public partial class _Ctrl_Busqueda : UserControl
    {
        public _Ctrl_Busqueda()
        {
            InitializeComponent();            
        }
        DataGridView _Dg_Grig = new DataGridView();
        public string _Mtd_RetornarStringCelda(int _Int_Columna, int _Int_Fila)
        {
            if (_Dta_View_ == null)
            {
                return _Dg_Grig.Rows[_Int_Fila].Cells[_Int_Columna].Value.ToString().Trim();
            }
            else
            {
                return _Dta_View_[_Int_Fila].Row[_Int_Columna].ToString().Trim();
            }
        }
        public string _Mtd_RetornarStringCelda(string _Str_Columna, int _Int_Fila)
        {
            if (_Dta_View_ == null)
            {
                return _Dg_Grig.Rows[_Int_Fila].Cells[_Str_Columna].Value.ToString().Trim();
            }
            else
            {
                return _Dta_View_[_Int_Fila].Row[_Str_Columna].ToString().Trim();
            }
        }
        public DataView _Dta_View_;
        void _Dg_Grig_Sorted(object sender, EventArgs e)
        {
            string _Str_Sort = ((DataGridView)sender).SortOrder.ToString();
            if (_Str_Sort == "Ascending")
            {
                _Str_Sort = "Asc";
            }
            else
            {
                _Str_Sort = "desc";
            }
            string _Str_Campo = ((DataGridView)sender).SortedColumn.DataPropertyName.ToString();
            DataTable _Dta_Table = new DataTable();
            _Dta_Table = (DataTable)((DataGridView)sender).DataSource;
            _Dta_View_ = _Dta_Table.DefaultView;
            _Dta_View_.Sort = _Str_Campo + " " + _Str_Sort;
        }
        bool _Bol_WithDs = false;
        string _Str_Cadena_Consulta_Formato = "";
        string _G_Str_OrderBy = "";
        string[] _Str_Codigo_Descripcion;       
        public void _Mtd_Inicializar(string _P_Str_CadenaSql, string[] _P_Str_Codigo_Descripcion, string _P_Str_Cabecera, ToolStripMenuItem[] _P_Tsm_Menu,DataGridView _P_Dg_Grig)
        {
            _Str_Cadena_Consulta_Formato = _P_Str_CadenaSql;
            _Str_Codigo_Descripcion = _P_Str_Codigo_Descripcion;
            _Lb_Etiquea.Text = _P_Str_Cabecera;
            _Dg_Grig = _P_Dg_Grig;
            toolStripSplitButton1.DropDownItems.Clear();
            int _Int_i = 0;
            foreach (ToolStripMenuItem _Tsm_Item in _P_Tsm_Menu)
            {
                _Tsm_Item.Click += new EventHandler(_Tsm_Item_Click);
                _Tsm_Item.Tag = _Int_i;
                _Int_i++;
            }
            toolStripSplitButton1.DropDownItems.AddRange(_P_Tsm_Menu);
            _Mtd_Actulizar();
            _Dg_Grig.Sorted += new EventHandler(_Dg_Grig_Sorted);
        }
        public void _Mtd_Inicializar(string _P_Str_CadenaSql, string[] _P_Str_Codigo_Descripcion, string _P_Str_Cabecera, ToolStripMenuItem[] _P_Tsm_Menu, DataGridView _P_Dg_Grig,bool _P_Bol_WithDs, string _P_Str_GroupBy)
        {
            _Str_Cadena_Consulta_Formato = _P_Str_CadenaSql;
            _Str_Codigo_Descripcion = _P_Str_Codigo_Descripcion;
            _Lb_Etiquea.Text = _P_Str_Cabecera;
            _Dg_Grig = _P_Dg_Grig;
            _Str_GroupBy = _P_Str_GroupBy;
            toolStripSplitButton1.DropDownItems.Clear();
            int _Int_i = 0;
            foreach (ToolStripMenuItem _Tsm_Item in _P_Tsm_Menu)
            {
                _Tsm_Item.Click += new EventHandler(_Tsm_Item_Click);
                _Tsm_Item.Tag = _Int_i;
                _Int_i++;
            }
            toolStripSplitButton1.DropDownItems.AddRange(_P_Tsm_Menu);
            _Bol_WithDs = _P_Bol_WithDs;
            if (_P_Bol_WithDs)
            {
                _Mtd_Actulizar();
            }
            else
            {
                _Mtd_ActulizarSinDs();
            }
            _Dg_Grig.Sorted += new EventHandler(_Dg_Grig_Sorted);
        }
        public void _Mtd_Inicializar(string _P_Str_CadenaSql, string[] _P_Str_Codigo_Descripcion, string _P_Str_Cabecera, ToolStripMenuItem[] _P_Tsm_Menu, DataGridView _P_Dg_Grig, bool _P_Bol_WithDs, string _P_Str_GroupBy, string _P_Str_OrderBy)
        {
            _Str_Cadena_Consulta_Formato = _P_Str_CadenaSql;
            _Str_Codigo_Descripcion = _P_Str_Codigo_Descripcion;
            _G_Str_OrderBy = _P_Str_OrderBy;
            _Lb_Etiquea.Text = _P_Str_Cabecera;
            _Dg_Grig = _P_Dg_Grig;
            _Str_GroupBy = _P_Str_GroupBy;
            toolStripSplitButton1.DropDownItems.Clear();
            int _Int_i = 0;
            foreach (ToolStripMenuItem _Tsm_Item in _P_Tsm_Menu)
            {
                _Tsm_Item.Click += new EventHandler(_Tsm_Item_Click);
                _Tsm_Item.Tag = _Int_i;
                _Int_i++;
            }
            toolStripSplitButton1.DropDownItems.AddRange(_P_Tsm_Menu);
            _Bol_WithDs = _P_Bol_WithDs;
            if (_P_Bol_WithDs)
            {
                _Mtd_Actulizar();
            }
            else
            {
                _Mtd_ActulizarSinDs();
            }
            _Dg_Grig.Sorted += new EventHandler(_Dg_Grig_Sorted);
        }
        string _Str_GroupBy = "";
        public void _Mtd_Inicializar2(string _P_Str_CadenaSql, string[] _P_Str_Codigo_Descripcion, string _P_Str_Cabecera, ToolStripMenuItem[] _P_Tsm_Menu, DataGridView _P_Dg_Grig,string _P_Str_GroupBy)
        {
            _Str_Cadena_Consulta_Formato = _P_Str_CadenaSql;
            _Str_Codigo_Descripcion = _P_Str_Codigo_Descripcion;
            _Str_GroupBy = _P_Str_GroupBy;
            _Lb_Etiquea.Text = _P_Str_Cabecera;
            _Dg_Grig = _P_Dg_Grig;
            toolStripSplitButton1.DropDownItems.Clear();
            int _Int_i = 0;
            foreach (ToolStripMenuItem _Tsm_Item in _P_Tsm_Menu)
            {
                _Tsm_Item.Click += new EventHandler(_Tsm_Item_Click);
                _Tsm_Item.Tag = _Int_i;
                _Int_i++;
            }
            toolStripSplitButton1.DropDownItems.AddRange(_P_Tsm_Menu);
            _Mtd_Actulizar();
            _Dg_Grig.Sorted += new EventHandler(_Dg_Grig_Sorted);
        }
        int _Int_Personalizado = -1;
        bool _Bol_Personalzado = false;
        string[] _Str_CamposFiltro;
        string[] _Str_CamposFiltroName;
        string[] _Str_CamposFiltroType;
        string[] _Str_CamposFiltroStyle;
        string _Str_FindSql_Lista;
        public void _Mtd_Inicializar(string _P_Str_CadenaSql, string[] _P_Str_Codigo_Descripcion, string _P_Str_Cabecera, ToolStripMenuItem[] _P_Tsm_Menu, DataGridView _P_Dg_Grig,string[] _P_Str_CamposFiltro,string[] _P_Str_CamposFiltroName,string[] _P_Str_CamposFiltroType,string[] _P_Str_CamposFiltroStyle,string _P_Str_FindSql_Lista)
        {
            _Str_CamposFiltro = _P_Str_CamposFiltro;
            _Str_CamposFiltroName = _P_Str_CamposFiltroName;
            _Str_CamposFiltroType = _P_Str_CamposFiltroType;
            _Str_CamposFiltroStyle = _P_Str_CamposFiltroStyle;
            _Str_FindSql_Lista = _P_Str_FindSql_Lista;
            _Str_Cadena_Consulta_Formato = _P_Str_CadenaSql;
            _Str_Codigo_Descripcion = _P_Str_Codigo_Descripcion;
            _Lb_Etiquea.Text = _P_Str_Cabecera;
            _Dg_Grig = _P_Dg_Grig;
            toolStripSplitButton1.DropDownItems.Clear();
            int _Int_i = 0;
            foreach (ToolStripMenuItem _Tsm_Item in _P_Tsm_Menu)
            {
                _Tsm_Item.Click += new EventHandler(_Tsm_Item_Click);
                _Tsm_Item.Tag = _Int_i;
                _Int_i++;
            }
            toolStripSplitButton1.DropDownItems.AddRange(_P_Tsm_Menu);
            ToolStripMenuItem _Tsm_Item2 = new ToolStripMenuItem("Personalizada");
            _Tsm_Item2.Click += new EventHandler(_Tsm_Item_Click);
            _Tsm_Item2.Tag = _Int_i;
            _Int_Personalizado = _Int_i;
            toolStripSplitButton1.DropDownItems.Add(_Tsm_Item2);
            _Mtd_Actulizar();
            _Bol_Personalzado = true;
            _Dg_Grig.Sorted += new EventHandler(_Dg_Grig_Sorted);
        }
        void _Tsm_Item_Click(object sender, EventArgs e)
        {
            _Int_Pos = Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
            if (_Int_Pos != -1 & _Int_Pos == _Int_Personalizado & _Bol_Personalzado)
            {
                string _Str_Sql;
                Frm_FIND Frm_FIND1 = new Frm_FIND(_Str_CamposFiltro, _Str_CamposFiltroName, _Str_CamposFiltroType, _Str_CamposFiltroStyle, _Str_FindSql_Lista);
                try
                {
                    Frm_FIND1.ShowDialog();
                    if (Frm_FIND1._Str_Result != "")
                    {
                        _Str_Sql = _Str_Cadena_Consulta_Formato + Frm_FIND1._Str_Result;
                       DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        _Dg_Grig.DataSource = _Ds_Data.Tables[0];
                        _Dg_Grig.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    }
                    Frm_FIND1 = null;
                }
                catch { Frm_FIND1 = null; }
                _Int_Pos = -1;
            }
        }
        private void _Mtd_ActulizarSinDs()
        {
            int _Int_C =0;
            string _Str_Sql = "";
            DataSet _Ds_Data = new DataSet();
            if (_Str_GroupBy.Trim().Length == 0)
            {
                _Str_Sql = _Str_Cadena_Consulta_Formato;
                //_Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena_Consulta_Formato);
            }
            else
            {
                _Str_Sql = _Str_Cadena_Consulta_Formato + " " + _Str_GroupBy;
                //_Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena_Consulta_Formato + " " + _Str_GroupBy);
            }
            if (_G_Str_OrderBy.Length > 0)
            {
                _Str_Sql = _Str_Sql + " ORDER BY " + _G_Str_OrderBy;
            }
            _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            object[] _Str_RowNew = new object[_Ds_Data.Tables[0].Columns.Count];
            _Dg_Grig.Columns.Clear();
            foreach (DataColumn _DataC in _Ds_Data.Tables[0].Columns)
            {
                _Dg_Grig.Columns.Add("_DgCol" + _Int_C.ToString(), _DataC.Caption);
            }
            _Dg_Grig.Rows.Clear();
            foreach (DataRow _DataR in _Ds_Data.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_Grig.Rows.Add(_Str_RowNew);
            }
            //_Dg_Grig.DataSource = _Ds_Data.Tables[0]; 
            toolStripComboBox1.Text = ""; 
            _Int_Pos = -1;
            _Dg_Grig.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            toolStripSplitButton1.DropDownItems[0].PerformClick();
            _Dg_Grig.Sorted += new EventHandler(_Dg_Grig_Sorted);
        }
        private void _Mtd_Actulizar()
        {
            string _Str_Sql = "";
            DataSet _Ds_Data = new DataSet();
            if (_Str_GroupBy.Trim().Length == 0)
            {
                _Str_Sql = _Str_Cadena_Consulta_Formato;
                //_Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena_Consulta_Formato);
            }
            else
            {
                _Str_Sql = _Str_Cadena_Consulta_Formato + " " + _Str_GroupBy;
                //_Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena_Consulta_Formato+" "+_Str_GroupBy);
            }
            if (_G_Str_OrderBy.Length > 0)
            {
                _Str_Sql = _Str_Sql + " ORDER BY " + _G_Str_OrderBy;
            }
            _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_Grig.DataSource = _Ds_Data.Tables[0]; toolStripComboBox1.Text = ""; _Int_Pos = -1;
            _Dg_Grig.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            toolStripSplitButton1.DropDownItems[0].PerformClick();
            _Dg_Grig.Sorted += new EventHandler(_Dg_Grig_Sorted);
            _Dta_View_ = ((DataTable)_Dg_Grig.DataSource).DefaultView;
        }
        public void _Mtd_filtrar_Grid()
        {
            try
            {
                string _Str_Sql = "";
                DataSet _Ds_Data;
                if (_Str_GroupBy.Trim().Length == 0)
                {
                    if (_G_Str_OrderBy.Length == 0)
                    {
                        _Str_Sql = _Str_Cadena_Consulta_Formato + " AND " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " LIKE '%" + toolStripComboBox1.Text + "%' ORDER BY " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " ASC";
                    }
                    else
                    {
                        _Str_Sql = _Str_Cadena_Consulta_Formato + " AND " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " LIKE '%" + toolStripComboBox1.Text + "%'";
                    }
                }
                else
                {
                    if (_G_Str_OrderBy.Length == 0)
                    {
                        _Str_Sql = _Str_Cadena_Consulta_Formato + " AND " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " LIKE '%" + toolStripComboBox1.Text + "%' " + _Str_GroupBy + " ORDER BY " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " ASC";
                    }
                    else
                    {
                        _Str_Sql = _Str_Cadena_Consulta_Formato + " AND " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " LIKE '%" + toolStripComboBox1.Text + "%' " + _Str_GroupBy;
                    }
                }
                if (_G_Str_OrderBy.Length > 0)
                {
                    _Str_Sql = _Str_Sql + " ORDER BY " + _G_Str_OrderBy;
                }
                _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Bol_WithDs)
                {
                    _Dg_Grig.DataSource = _Ds_Data.Tables[0];
                    _Dta_View_ = ((DataTable)_Dg_Grig.DataSource).DefaultView;
                }
                else
                {
                    object[] _Str_RowNew = new object[_Ds_Data.Tables[0].Columns.Count];
                    _Dg_Grig.Rows.Clear();
                    foreach (DataRow _DataR in _Ds_Data.Tables[0].Rows)
                    {
                        Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                        _Dg_Grig.Rows.Add(_Str_RowNew);
                    }
                }
                _Dg_Grig.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch { }
        }

        int _Int_Pos = -1;
        private void _Bt_actualizar_Click(object sender, EventArgs e)
        {
            _Dta_View_ = null;
            _Mtd_Actulizar();
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            _Dta_View_ = null;
            if (_Int_Pos == -1)
            { MessageBox.Show("Debe seleccionar el criterio de la busqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else
            { _Mtd_filtrar_Grid(); }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void _Ctrl_Busqueda_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Top;
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Inyeccion_Sql(this, true);
        }
    }
}
