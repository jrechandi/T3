using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Busqueda : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_Variosmetodos = new CLASES._Cls_Varios_Metodos(true);
        public int[] _Int_FrmGridColsOcultas;
        string[] _Str_Codigo_Descripcion=new string[2];
        string _Str_Cadena_Consulta_Formato;
        TextBox _Txt_Descri = new TextBox();
        TextBox _Txt_Codigo = new TextBox();
        bool _Bol_Boleano = false;
        int _Int_Pos1=-1;
        int _Int_Pos2 = -1;
        public Frm_Busqueda(TextBox _P_Txt_Codigo, TextBox _P_Txt_Descrip, string _P_Str_CadenaSql, string[] _P_Str_Codigo_Descripcion, string _P_Str_Cabecera, ToolStripMenuItem[] _P_Tsm_Menu, int _P_Int_Pos1, int _P_Int_Pos2)
        {
            InitializeComponent();
            _Int_Pos1 = _P_Int_Pos1;
            _Int_Pos2 = _P_Int_Pos2;
            _Txt_Descri = _P_Txt_Descrip;
            _Txt_Codigo = _P_Txt_Codigo;
            _Str_Cadena_Consulta_Formato = _P_Str_CadenaSql;
            _Str_Codigo_Descripcion = _P_Str_Codigo_Descripcion;
            _Lb_Etiquea.Text = _P_Str_Cabecera;
            toolStripSplitButton1.DropDownItems.Clear();
            int _Int_i = 0;
            foreach (ToolStripMenuItem _Tsm_Item in _P_Tsm_Menu)
            {
                _Tsm_Item.Click += new EventHandler(_Tsm_Item_Click);
                _Tsm_Item.Tag = _Int_i;
                _Int_i++;
            }
            toolStripSplitButton1.DropDownItems.AddRange(_P_Tsm_Menu);
            _Bol_Boleano = false;
            toolStripSplitButton2.Visible = false;
        }
        bool _Bol_Derecha = false;
        public Frm_Busqueda(TextBox _P_Txt_Codigo, TextBox _P_Txt_Descrip, string _P_Str_CadenaSql, string[] _P_Str_Codigo_Descripcion, string _P_Str_Cabecera, ToolStripMenuItem[] _P_Tsm_Menu, int _P_Int_Pos1, int _P_Int_Pos2,bool _Bol_True)
        {
            InitializeComponent();
            _Bol_Derecha = true;
            _Int_Pos1 = _P_Int_Pos1;
            _Int_Pos2 = _P_Int_Pos2;
            _Txt_Descri = _P_Txt_Descrip;
            _Txt_Codigo = _P_Txt_Codigo;
            _Str_Cadena_Consulta_Formato = _P_Str_CadenaSql;
            _Str_Codigo_Descripcion = _P_Str_Codigo_Descripcion;
            _Lb_Etiquea.Text = _P_Str_Cabecera;
            toolStripSplitButton1.DropDownItems.Clear();
            int _Int_i = 0;
            foreach (ToolStripMenuItem _Tsm_Item in _P_Tsm_Menu)
            {
                _Tsm_Item.Click += new EventHandler(_Tsm_Item_Click);
                _Tsm_Item.Tag = _Int_i;
                _Int_i++;
            }
            toolStripSplitButton1.DropDownItems.AddRange(_P_Tsm_Menu);
            _Bol_Boleano = false;
            toolStripSplitButton2.Visible = false;
        }
        public Frm_Busqueda(string _P_Str_CadenaSql, string[] _P_Str_Codigo_Descripcion, string _P_Str_Cabecera, ToolStripMenuItem[] _P_Tsm_Menu)
        {
            InitializeComponent();
            _Str_Cadena_Consulta_Formato = _P_Str_CadenaSql;
            _Str_Codigo_Descripcion = _P_Str_Codigo_Descripcion;
            _Lb_Etiquea.Text = _P_Str_Cabecera;
            toolStripSplitButton1.DropDownItems.Clear();
            int _Int_i = 0;
            foreach (ToolStripMenuItem _Tsm_Item in _P_Tsm_Menu)
            {
                _Tsm_Item.Click += new EventHandler(_Tsm_Item_Click);
                _Tsm_Item.Tag = _Int_i;
                _Int_i++;
            }
            toolStripSplitButton1.DropDownItems.AddRange(_P_Tsm_Menu);
            _Bol_Boleano = true;
            toolStripSplitButton2.Visible = true;
            _Int_Pos = 0;
        }
        string _Form = "";
        public Frm_Busqueda(string _P_Str_CadenaSql, string[] _P_Str_Codigo_Descripcion, string _P_Str_Cabecera, ToolStripMenuItem[] _P_Tsm_Menu,string _P_Form)
        {
            InitializeComponent();
            _Form = _P_Form;
            _Str_Cadena_Consulta_Formato = _P_Str_CadenaSql;
            _Str_Codigo_Descripcion = _P_Str_Codigo_Descripcion;
            _Lb_Etiquea.Text = _P_Str_Cabecera;
            toolStripSplitButton1.DropDownItems.Clear();
            int _Int_i = 0;
            foreach (ToolStripMenuItem _Tsm_Item in _P_Tsm_Menu)
            {
                _Tsm_Item.Click += new EventHandler(_Tsm_Item_Click);
                _Tsm_Item.Tag = _Int_i;
                _Int_i++;
            }
            toolStripSplitButton1.DropDownItems.AddRange(_P_Tsm_Menu);
            _Bol_Boleano = true;
            toolStripSplitButton2.Visible = true;
            _Int_Pos = 0;
        }
        bool _Bol_UnTextbox = false;
        public Frm_Busqueda(string _P_Str_CadenaSql, string[] _P_Str_Codigo_Descripcion, string _P_Str_Cabecera, ToolStripMenuItem[] _P_Tsm_Menu,TextBox _P_Txt_Codigo)
        {
            InitializeComponent();
            _Str_Cadena_Consulta_Formato = _P_Str_CadenaSql;
            _Str_Codigo_Descripcion = _P_Str_Codigo_Descripcion;
            _Lb_Etiquea.Text = _P_Str_Cabecera;
            toolStripSplitButton1.DropDownItems.Clear();
            int _Int_i = 0;
            foreach (ToolStripMenuItem _Tsm_Item in _P_Tsm_Menu)
            {
                _Tsm_Item.Click += new EventHandler(_Tsm_Item_Click);
                _Tsm_Item.Tag = _Int_i;
                _Int_i++;
            }
            toolStripSplitButton1.DropDownItems.AddRange(_P_Tsm_Menu);
            _Bol_Boleano = true;
            toolStripSplitButton2.Visible = true;
            _Int_Pos = 0;
            _Bol_UnTextbox = true;
            _Txt_Codigo = _P_Txt_Codigo;
        }
        public Frm_Busqueda(string _P_Str_CadenaSql, string[] _P_Str_Codigo_Descripcion, string _P_Str_Cabecera, ToolStripMenuItem[] _P_Tsm_Menu,bool _P_Bol_Sw)
        {
            InitializeComponent();
            _Str_Cadena_Consulta_Formato = _P_Str_CadenaSql;
            _Str_Codigo_Descripcion = _P_Str_Codigo_Descripcion;
            _Lb_Etiquea.Text = _P_Str_Cabecera;
            toolStripSplitButton1.DropDownItems.Clear();
            int _Int_i = 0;
            foreach (ToolStripMenuItem _Tsm_Item in _P_Tsm_Menu)
            {
                _Tsm_Item.Click += new EventHandler(_Tsm_Item_Click);
                _Tsm_Item.Tag = _Int_i;
                _Int_i++;
            }
            toolStripSplitButton1.DropDownItems.AddRange(_P_Tsm_Menu);
            _Bol_Boleano = true;
            toolStripSplitButton2.Visible = false;
        }
        string _Str_Cadena_Navegador1="";
        string _Str_Cadena_Navegador2 = "";
        string _Str_Cadena_Navegador3 = "";
        bool _Bol_Navegador = false;
        bool _Bol_Local = false;
        public Frm_Busqueda(string _P_Str_CadenaSql, string[] _P_Str_Codigo_Descripcion, string _P_Str_Cabecera, ToolStripMenuItem[] _P_Tsm_Menu, string _P_Str_Cadena_Navegador1, string _P_Str_Cadena_Navegador3,bool _P_Bol_Local)
        {
            InitializeComponent();
            _Str_Cadena_Navegador1 = _P_Str_Cadena_Navegador1;
            _Str_Cadena_Navegador3 = _P_Str_Cadena_Navegador3;
            _Str_Cadena_Consulta_Formato = _P_Str_CadenaSql;
            _Str_Codigo_Descripcion = _P_Str_Codigo_Descripcion;
            _Lb_Etiquea.Text = _P_Str_Cabecera;
            _Bol_Navegador = true;
            this._Dg_Datagrid.ContextMenuStrip = _Ctrl_Contex2;
            toolStripSplitButton1.DropDownItems.Clear();
            int _Int_i = 0;
            foreach (ToolStripMenuItem _Tsm_Item in _P_Tsm_Menu)
            {
                _Tsm_Item.Click += new EventHandler(_Tsm_Item_Click);
                _Tsm_Item.Tag = _Int_i;
                _Int_i++;
            }
            toolStripSplitButton1.DropDownItems.AddRange(_P_Tsm_Menu);
            _Bol_Boleano = true;
            toolStripSplitButton2.Visible = false;
            _Bol_Local = _P_Bol_Local;
        }
        //CONSTRUCTOR PARA UTILIZAR ESTE FORM EN MODAL
        int _Int_FrmModalAux = 0;
        public string _Str_FrmResultado = "";
        public Frm_Busqueda(string _P_Str_CadenaSql, string[] _P_Str_Codigo_Descripcion, string _P_Str_Cabecera, ToolStripMenuItem[] _P_Tsm_Menu, int _Pr_Int_Aux)
        {
            InitializeComponent();
            if (_Pr_Int_Aux == 0)
            { _Int_FrmModalAux = 1; }
            else
            { _Int_FrmModalAux = _Pr_Int_Aux; }
            _Str_Cadena_Consulta_Formato = _P_Str_CadenaSql;
            _Str_Codigo_Descripcion = _P_Str_Codigo_Descripcion;
            _Lb_Etiquea.Text = _P_Str_Cabecera;
            toolStripSplitButton1.DropDownItems.Clear();
            int _Int_i = 0;
            foreach (ToolStripMenuItem _Tsm_Item in _P_Tsm_Menu)
            {
                _Tsm_Item.Click += new EventHandler(_Tsm_Item_Click);
                _Tsm_Item.Tag = _Int_i;
                _Int_i++;
            }
            toolStripSplitButton1.DropDownItems.AddRange(_P_Tsm_Menu);
            _Bol_Boleano = true;
            toolStripSplitButton2.Visible = true;
            _Int_Pos = 0;
        }



        void _Tsm_Item_Click(object sender, EventArgs e)
        {
            _Int_Pos = Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
        }
        int _Int_Pos = -1;
        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            if (_Bol_Navegador)
            {
                if (_Bol_Local)
                {
                    if (_Int_Pos == -1)
                    { MessageBox.Show("Debe seleccionar el criterio de la busqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    else
                    { _Mtd_filtrar_Grid(); }
                }
                else
                {
                    if (_Int_Pos == -1)
                    { MessageBox.Show("Debe seleccionar el criterio de la busqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    else
                    { _Mtd_filtrar_Grid2(); }
                }
            }
            else
            {
                if (_Int_Pos == -1)
                { MessageBox.Show("Debe seleccionar el criterio de la busqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                else
                { _Mtd_filtrar_Grid(); }
            }
        }
        bool _Bol_Sw = true;
        public void _Mtd_filtrar_Grid()
        {
            try
            {
                if (toolStripSplitButton2.Visible)
                {
                    if (_Bol_Sw)
                    { _Int_Pos = 0; _Bol_Sw = false; }
                    DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena_Consulta_Formato +_Str_Concatenar+" AND " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " LIKE '%" + toolStripComboBox1.Text + "%' ORDER BY " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " ASC");
                    _Dg_Datagrid.DataSource = _Ds_Data.Tables[0];
                    _Dg_Datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena_Consulta_Formato + " AND " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " LIKE '%" + toolStripComboBox1.Text + "%' ORDER BY " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " ASC");
                    _Dg_Datagrid.DataSource = _Ds_Data.Tables[0];
                    _Dg_Datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch { }
        }
        public void _Mtd_filtrar_Grid2()
        {
            try
            {
                if (toolStripSplitButton2.Visible)
                {
                    if (_Bol_Sw)
                    { _Int_Pos = 0; _Bol_Sw = false; }
                    DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion2._Mtd_RetornarDataset(_Str_Cadena_Consulta_Formato + _Str_Concatenar + " AND " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " LIKE '%" + toolStripComboBox1.Text + "%' ORDER BY " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " ASC");
                    _Dg_Datagrid.DataSource = _Ds_Data.Tables[0];
                    _Dg_Datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion2._Mtd_RetornarDataset(_Str_Cadena_Consulta_Formato + " AND " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " LIKE '%" + toolStripComboBox1.Text + "%' ORDER BY " + _Str_Codigo_Descripcion[_Int_Pos].ToString() + " ASC");
                    _Dg_Datagrid.DataSource = _Ds_Data.Tables[0];
                    _Dg_Datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch { }
        }
        private void clavePrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Int_Pos = 0;
        }

        private void descripciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Int_Pos = 1;
        }

        private void _Bt_actualizar_Click(object sender, EventArgs e)
        {
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena_Consulta_Formato);
            try { _Dg_Datagrid.DataSource = _Ds_Data.Tables[0]; toolStripComboBox1.Text = ""; _Int_Pos = -1; }
            catch { }
        }
        public void _Mtd_Acualizar()
        {
            DataSet _Ds_Data = new DataSet();
            if (_Bol_Navegador)
            {
                if (_Bol_Local)
                {
                    _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena_Consulta_Formato);
                }
                else
                {
                    _Ds_Data = Program._MyClsCnn._mtd_conexion2._Mtd_RetornarDataset(_Str_Cadena_Consulta_Formato);
                }
            }
            else
            { _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena_Consulta_Formato); }
            try
            {
                _Dg_Datagrid.DataSource = _Ds_Data.Tables[0]; toolStripComboBox1.Text = ""; _Int_Pos = -1; _Dg_Datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if ((_Bol_Navegador & _Bol_Local) | _Bol_UnTextbox)
                { _Dg_Datagrid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; _Dg_Datagrid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; _Dg_Datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; }
                if (_Int_FrmGridColsOcultas != null)
                {
                    foreach (int _Int_C in _Int_FrmGridColsOcultas)
                    {
                        _Dg_Datagrid.Columns[_Int_C].Visible = false;
                    }
                }
                if (_Bol_Derecha)
                {
                    _Dg_Datagrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch { }
        }
        private void Frm_Busqueda_Load(object sender, EventArgs e)
        {
            _Mtd_Acualizar();
        }
        private void _Dg_Datagrid_DoubleClick(object sender, EventArgs e)
        {
          
            
        }
        string _Str_Concatenar = "";
        private void servisioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Str_Concatenar = " AND cglobal='0'";
            _Mtd_filtrar_Grid();
        }

        private void materiaPrimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Str_Concatenar = " AND cglobal='1'";
            _Mtd_filtrar_Grid();
        }

        private void otrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Str_Concatenar = " AND cglobal='2'";
            _Mtd_filtrar_Grid();
        }

        private void Frm_Busqueda_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Dg_Datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void _Dg_Datagrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgInfo.Visible = true;
            }
            else
            {
                _Lbl_DgInfo.Visible = false;
            }
        }

        private void _Ctrl_Contex1_MItem1_Click(object sender, EventArgs e)
        {
            _Str_FrmResultado = _Dg_Datagrid.SelectedRows.Count.ToString();
            this.Close();
        }

        private void _Ctrl_Contex2_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Datagrid.CurrentCell.RowIndex == -1)
            { e.Cancel = true; }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_Cls_Variosmetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CIERRE_OCLLEGAR"))
            {
                _Ctrl_Clave _Ctrl = new _Ctrl_Clave(3, this);
            }
            else
            {
                MessageBox.Show("Usted no tiene permiso para realizar esta operacion", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Dg_Datagrid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Datagrid.SelectedRows.Count > 0)
            {
                if (!_Bol_Boleano)
                {
                    try
                    {
                        _Str_FrmResultado = _Dg_Datagrid.Rows[_Dg_Datagrid.CurrentCell.RowIndex].Cells[_Int_Pos1].Value.ToString();
                        _Txt_Codigo.Text = _Dg_Datagrid.Rows[_Dg_Datagrid.CurrentCell.RowIndex].Cells[_Int_Pos1].Value.ToString(); _Txt_Descri.Text = _Dg_Datagrid.Rows[_Dg_Datagrid.CurrentCell.RowIndex].Cells[_Int_Pos2].Value.ToString(); this.Close();
                    }
                    catch { }
                }
                if (_Bol_Navegador)
                {
                    try
                    {
                        _Str_Cadena_Navegador2 = _Dg_Datagrid.Rows[_Dg_Datagrid.CurrentCell.RowIndex].Cells[0].Value.ToString();
                        string _Str_Cadena = _Str_Cadena_Navegador1 + osio.encriptar(_Str_Cadena_Navegador2) + _Str_Cadena_Navegador3;
                        Frm_Navegador _Frm = new Frm_Navegador(_Str_Cadena, false);
                        _Frm.MdiParent = this.MdiParent;
                        _Frm.Dock = DockStyle.Fill;
                        _Frm.Show();
                    }
                    catch { }
                }
                if (_Bol_UnTextbox)
                {
                    try
                    {
                        _Str_FrmResultado = _Dg_Datagrid.Rows[_Dg_Datagrid.CurrentCell.RowIndex].Cells[0].Value.ToString();
                        _Txt_Codigo.Text = _Dg_Datagrid.Rows[_Dg_Datagrid.CurrentCell.RowIndex].Cells[0].Value.ToString(); this.Close();
                    }
                    catch { }
                }
                if (_Form != "")
                {
                    Form _Frm = (Form)Activator.CreateInstance(Type.GetType(_Form), new object[] { _Dg_Datagrid.Rows[_Dg_Datagrid.CurrentCell.RowIndex].Cells[0].Value.ToString() });
                    _Frm.Show();
                    _Frm.MdiParent = this.MdiParent;
                    this.Close();
                }
                //PARA QUE DEVUELVA EL VALOR COMO MODAL
                if (_Int_FrmModalAux != 0)
                {
                    try
                    { _Str_FrmResultado = _Dg_Datagrid.Rows[_Dg_Datagrid.CurrentCell.RowIndex].Cells[0].Value.ToString(); this.Close(); }
                    catch { }
                }
            }
        }

    }
}