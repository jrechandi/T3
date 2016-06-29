using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace T3.CONTROLES
{
    public partial class _Ctrl_BusquedaPage : UserControl
    {
        public _Ctrl_BusquedaPage()
        {
            InitializeComponent();
        }

        bool _Bol_SwFiltrado = false;
        public Int64 _Int_RegSel = 0;
        public Int64 _Int_RegOmitidos = 0;
        public Int64 _Int_RegTot = 0;
        Int64 _Int_Npage = 0;
        Int64 _Int_Apage = 0;
        string _G_Str_OrderBy = "";
        string _Str_Gtabla = "";
        string _Str_GsqlFiltro = "";
        string _Str_Cadena_Consulta_Formato = "";
        string[] _Str_Codigo_Descripcion;
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
            try
            {
                _Dta_View_.Sort = _Str_Campo + " " + _Str_Sort;
            }
            catch
            {
            }
        }
        public void _Mtd_Inicializar(string _P_Str_CadenaSql, string[] _P_Str_Codigo_Descripcion, string _P_Str_Cabecera, ToolStripMenuItem[] _P_Tsm_Menu, DataGridView _P_Dg_Grig, string _P_Str_Tabla, string _P_Str_Filtro, Int64 _P_Int_RegSel, string _P_Str_OrderBy)
        {
            _Str_Gtabla = _P_Str_Tabla;
            _Str_GsqlFiltro = _P_Str_Filtro;
            _Int_RegTot = _Mtd_GetTotalReg();
            _Int_RegSel = _P_Int_RegSel;
            _Str_Cadena_Consulta_Formato = _P_Str_CadenaSql;
            _G_Str_OrderBy = _P_Str_OrderBy;
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

            if (_Txt_Page.Text != "")
            {
                _Mtd_Actulizar();
            }
            else
            {
                _Txt_Page.Text = "1";
            }
            _Dg_Grig.Sorted += new EventHandler(_Dg_Grig_Sorted);
        }
        string _Str_GroupBy = "";
        public void _Mtd_Inicializar2(string _P_Str_CadenaSql, string[] _P_Str_Codigo_Descripcion, string _P_Str_Cabecera, ToolStripMenuItem[] _P_Tsm_Menu, DataGridView _P_Dg_Grig, string _P_Str_GroupBy, string _P_Str_Tabla, string _P_Str_Filtro, Int64 _P_Int_RegSel)
        {
            _Str_Cadena_Consulta_Formato = _P_Str_CadenaSql;
            _Str_Codigo_Descripcion = _P_Str_Codigo_Descripcion;
            _Int_RegTot = _Mtd_GetTotalReg();
            _Int_RegSel = _P_Int_RegSel;
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
            if (_Txt_Page.Text != "")
            {
                _Mtd_Actulizar();
            }
            else
            {
                _Txt_Page.Text = "1";
            }
            _Dg_Grig.Sorted += new EventHandler(_Dg_Grig_Sorted);
        }
        int _Int_Personalizado = -1;
        bool _Bol_Personalzado = false;
        string[] _Str_CamposFiltro;
        string[] _Str_CamposFiltroName;
        string[] _Str_CamposFiltroType;
        string[] _Str_CamposFiltroStyle;
        string _Str_FindSql_Lista;
        public void _Mtd_Inicializar(string _P_Str_CadenaSql, string[] _P_Str_Codigo_Descripcion, string _P_Str_Cabecera, ToolStripMenuItem[] _P_Tsm_Menu, DataGridView _P_Dg_Grig, string[] _P_Str_CamposFiltro, string[] _P_Str_CamposFiltroName, string[] _P_Str_CamposFiltroType, string[] _P_Str_CamposFiltroStyle, string _P_Str_FindSql_Lista)
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
        private void _Mtd_Actulizar()
        {
            //double _Dbl_Pages = 0;
            string _Str_Sql = _Str_Cadena_Consulta_Formato.Replace("?sel", _Int_RegSel.ToString()).Replace("?omi", _Int_RegOmitidos.ToString());
            DataSet _Ds_Data = new DataSet();
            if (_Str_GroupBy.Trim().Length == 0)
            {
                if (_G_Str_OrderBy.Length > 0)
                {
                    _Str_Sql = _Str_Sql + " " + _Str_GroupBy + " " + _G_Str_OrderBy;
                }
                else
                { 
                
                }
            }
            else
            {
                if (_G_Str_OrderBy.Length > 0)
                {
                    _Str_Sql = _Str_Sql + " " + _G_Str_OrderBy;
                }
                else
                {
                    _Str_Sql = _Str_Sql + " " + _Str_GroupBy;
                }
                
                
            }
            _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_Grig.DataSource = _Ds_Data.Tables[0]; toolStripComboBox1.Text = ""; _Int_Pos = -1;
            _Mtd_GetTotalReg();
            _Int_Npage = _Int_RegTot / _Int_RegSel;
            _Int_Npage++;
            _Int_Apage = _Int_RegOmitidos / _Int_RegSel;
            _Int_Apage++;
            _Lbl_de.Text = " / " + _Int_Npage.ToString();
            _Txt_Page.TextChanged -= new EventHandler(_Txt_Page_TextChanged);
            _Txt_Page.Text = _Int_Apage.ToString();
            _Txt_Page.TextChanged += new EventHandler(_Txt_Page_TextChanged);
            _Dg_Grig.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Bol_SwFiltrado = false;
            toolStripSplitButton1.DropDownItems[0].PerformClick();
            _Dg_Grig.Sorted += new EventHandler(_Dg_Grig_Sorted);
        }
        public void _Mtd_filtrar_Grid()
        {
            //_G_Str_OrderBy
            try
            {
                string _Str_Sql = _Str_Cadena_Consulta_Formato.Replace("?sel", _Int_RegSel.ToString()).Replace("?omi", _Int_RegOmitidos.ToString());
                DataSet _Ds_Data;
                if (_Str_GroupBy.Trim().Length == 0)
                {
                    if (_G_Str_OrderBy.Length > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " LIKE '%" + toolStripComboBox1.Text + "%' ORDER BY " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " ASC";
                    }
                    else
                    {
                        _Str_Sql = _Str_Sql + " AND " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " LIKE '%" + toolStripComboBox1.Text + "%' ORDER BY " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " ASC";
                    }
                    
                }
                else
                {
                    if (_G_Str_OrderBy.Length > 0)
                    {
                        _Str_Sql = _Str_Sql + " AND " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " LIKE '%" + toolStripComboBox1.Text + "%' " + _Str_GroupBy + " ORDER BY " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " ASC";
                    }
                    else
                    {
                        _Str_Sql = _Str_Sql + " AND " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " LIKE '%" + toolStripComboBox1.Text + "%' " + _Str_GroupBy + " ORDER BY " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " ASC";
                    }
                    
                }
                _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                _Dg_Grig.DataSource = _Ds_Data.Tables[0];
                _Mtd_GetTotalRegFiltrado();
                //_Int_RegOmitidos = 0;
                _Int_Npage = _Int_RegTot / _Int_RegSel;
                _Int_Npage++;
                _Int_Apage = _Int_RegOmitidos / _Int_RegSel;
                _Int_Apage++;
                _Lbl_de.Text = " / " + _Int_Npage.ToString();
                _Txt_Page.TextChanged -= new EventHandler(_Txt_Page_TextChanged);
                _Txt_Page.Text = _Int_Apage.ToString();
                _Txt_Page.TextChanged += new EventHandler(_Txt_Page_TextChanged);
                _Dg_Grig.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Bol_SwFiltrado = true;
            }
            catch { }
            _Dg_Grig.Sorted += new EventHandler(_Dg_Grig_Sorted);
        }
        int _Int_Pos = -1;
        private void _Bt_actualizar_Click(object sender, EventArgs e)
        {
            _Mtd_Actulizar();
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            _Dta_View_ = null;
            _Bol_SwFiltrado = false;
            if (_Int_Pos == -1)
            { MessageBox.Show("Debe seleccionar el criterio de la busqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else
            { _Int_RegOmitidos = 0; _Mtd_filtrar_Grid(); }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            _Dta_View_ = null;
        }

        private void _Ctrl_Busqueda_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Top;
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Inyeccion_Sql(this, true);
        }

        private void _Btn_Next_Click(object sender, EventArgs e)
        {
            if (_Bol_SwFiltrado)
            {
                _Mtd_GetTotalRegFiltrado();
            }
            else
            {
                _Mtd_GetTotalReg();
            }
            _Int_RegOmitidos = _Int_RegOmitidos + _Int_RegSel;
            _Int_Npage = _Int_RegTot / _Int_RegSel;
            if (_Int_RegOmitidos <= _Int_RegTot)
            {
                //_Int_RegOmitidos = _Int_RegOmitidos + _Int_RegSel;
                if (_Bol_SwFiltrado)
                {
                    _Mtd_filtrar_Grid();
                }
                else
                {
                    _Mtd_Actulizar();
                }

            }
            else
            {
                _Int_RegOmitidos = _Int_RegOmitidos - _Int_RegSel;
            }
        }

        private void _Btn_Antes_Click(object sender, EventArgs e)
        {
            if (_Bol_SwFiltrado)
            {
                _Mtd_GetTotalRegFiltrado();
            }
            else
            {
                _Mtd_GetTotalReg();
            }
            _Int_Npage = _Int_RegTot / _Int_RegSel;
            if (_Int_RegOmitidos > 0)
            {
                _Int_RegOmitidos = _Int_RegOmitidos - _Int_RegSel;
                if (_Bol_SwFiltrado)
                {
                    _Mtd_filtrar_Grid();
                }
                else
                {
                    _Mtd_Actulizar();
                }
            }
        }
        
        private Int64 _Mtd_GetTotalReg()
        {
            Int64 _Int_R = 0;
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT COUNT(*) FROM " + _Str_Gtabla + " " + _Str_GsqlFiltro);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Int_R = Convert.ToInt64(_Ds.Tables[0].Rows[0][0]);
                _Int_RegTot = _Int_R;
            }
            return _Int_R;
        }
        private Int64 _Mtd_GetTotalRegFiltrado()
        {
            Int64 _Int_R = 0;
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT COUNT(*) FROM " + _Str_Gtabla + " " + _Str_GsqlFiltro + " AND " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " LIKE '%" + toolStripComboBox1.Text + "%'");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Int_R = Convert.ToInt64(_Ds.Tables[0].Rows[0][0]);
                _Int_RegTot = _Int_R;
            }
            return _Int_R;
        }

        private void _Ctrl_BusquedaPage_SizeChanged(object sender, EventArgs e)
        {
            //label1.Width = (this.Width - (_Btn_Antes.Width + _Btn_Next.Width + (_Txt_Page.Width/3))) / 2;
            _Lbl_de.Width = (this.Width - (_Btn_Antes.Width + _Btn_Next.Width + (_Txt_Page.Width/3))) / 2;
        }

        private void _Txt_Page_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Page_TextChanged(object sender, EventArgs e)
        {
            Int64 _Int_P = 1;
            if (_Txt_Page.Text != "")
            {
                if (Convert.ToInt64(_Txt_Page.Text) > 0)
                {
                    _Mtd_GetTotalReg();
                    _Int_Npage = _Int_RegTot / _Int_RegSel;
                    _Int_Npage++;
                    _Int_P = Convert.ToInt64(_Txt_Page.Text);
                    if (_Int_P > _Int_Npage)
                    {
                        _Txt_Page.TextChanged -= new EventHandler(_Txt_Page_TextChanged);
                        _Txt_Page.Text = _Int_Npage.ToString();
                        _Txt_Page.TextChanged += new EventHandler(_Txt_Page_TextChanged);
                        _Int_P = _Int_Npage;
                    }
                    _Int_P--;
                    _Int_RegOmitidos = _Int_RegSel * _Int_P;
                    if (_Bol_SwFiltrado)
                    {
                        _Mtd_filtrar_Grid();
                    }
                    else
                    {
                        _Mtd_Actulizar();
                    }
                }
                else
                {
                    _Txt_Page.Text = "1";
                }
            }
            else
            { 
            }
            
        }

        private void _Txt_Page_Leave(object sender, EventArgs e)
        {
            if (_Txt_Page.Text == "")
            {
                _Txt_Page.Text = "1";
            }
        }
    }
}
