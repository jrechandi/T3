using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_CategProvee : Form
    {
        public Frm_CategProvee()
        {
            InitializeComponent();
        }
        string[] _str_Valores = new string[5];
        string[] _Str_Necesarios = new string[3];
        string[] _Str_Campos = new string[5];
        Control[] _Ctrl_Controles = new Control[5];
        string[] _Str_Where = new string[1];
        string[] _Str_NoRep = new string[1];
        string[] _Str_Deshabi = new string[1];
        int[] _Int_CodDes = new int[2];
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        public void _Mtd_Entrada()
        {
            try
            {
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ccatproveedor FROM TCATPROVEEDOR where cdelete='0' ORDER BY ccatproveedor  DESC ");
                object[] _Obj_f = new object[20];
                _Obj_f = _Ds.Tables[0].Rows[0].ItemArray;
                _Txt_Cod.Text = Convert.ToString(Convert.ToInt32(_Obj_f[0].ToString()) + 1);

            }
            catch
            {
                _Txt_Cod.Text = "1";
            }
        }
        private void Frm_CategProvee_Load(object sender, EventArgs e)
        {
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select ccatproveedor as Código,cnombre as Descripción from TCATPROVEEDOR where cdelete='0'");
            _Dg_Grid.DataSource = _Ds_Data.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            _Mtd_Sorted();
            _Mtd_Comb_Tipo();
            _Mtd_Cargar();
        }
        public void _Mtd_Sorted()
        {
            for (int _Int_i = 0; _Int_i < _Dg_Grid.Columns.Count; _Int_i++)
            {
                _Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        TextBox _Txt_Cdelete = new TextBox();
        TextBox _Txt_Cuser = new TextBox();
        DateTimePicker _Dtp_Date2 = new DateTimePicker();
        private void Frm_CategProvee_Activated(object sender, EventArgs e)
        {
            _Mtd_Cargar();
            _Er_Error.Dispose();
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Str_Cadena_Consulta_Formato = "Select ccatproveedor as Código,cnombre as Descripción from TCATPROVEEDOR";
            CONTROLES._Ctrl_Buscar._Str_Cadena_Consulta = "Select ccatproveedor,cnombre,ctcount,ctretencion,ctcountc,cglobal from TCATPROVEEDOR";
            //CONTROLES._Ctrl_Buscar._Str_Cadena_Consulta_Where = "c_id_departamento";
            CONTROLES._Ctrl_Buscar._Str_Tabla = "TCATPROVEEDOR";
            CONTROLES._Ctrl_Buscar._Str_Where_Vista_Grid = "cdelete='0'";
            //-------------------------------------------------------
            _Ctrl_Controles[0] = _Txt_Cod;
            _Ctrl_Controles[1] = _Txt_Des;
            _Ctrl_Controles[2] = _Cbox_Cuenta;
            _Ctrl_Controles[3] = _Cbox_Contra;
            _Ctrl_Controles[4] = _Cbox_TipPro;
            //-------------------------------------------------------
            _Str_Campos[0] = "ccatproveedor";
            _Str_Campos[1] = "cnombre";
            _Str_Campos[2] = "ctcount";
            _Str_Campos[3] = "ctcountc";
            _Str_Campos[4] = "cglobal";
            //------------------------------------------------------
            _Str_Where[0] = "ccatproveedor";
            //-------------------------------------------------------
            _Str_NoRep[0] = "0";
            //-------------------------------------------------------
            _Str_Deshabi[0] = "0";
            //-------------------------------------------------------
            _Int_CodDes[0] = 0;
            _Int_CodDes[1] = 1;
            //-------------------------------------------------------
            CONTROLES._Ctrl_Buscar._Ctrl_Controles = _Ctrl_Controles;
            CONTROLES._Ctrl_Buscar._Str_Campos = _Str_Campos;
            CONTROLES._Ctrl_Buscar._Str_Cadena_Consulta_Where = _Str_Where;
            CONTROLES._Ctrl_Buscar._Er_Control_Error = _Er_Error;
            CONTROLES._Ctrl_Buscar._Dg_Datagrid = _Dg_Grid;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Str_NoseDebeRepetir = _Str_NoRep;
            CONTROLES._Ctrl_Buscar._Int_Codigo_Descripcion = _Int_CodDes;
            CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
            CONTROLES._Ctrl_Buscar._Int_Foco = 5;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Str_Deshabilitados = _Str_Deshabi;
            CONTROLES._Ctrl_Buscar._Txt_TpoFind.Text = "N";
            CLASES._Cls_Varios_Metodos _Cls_CL = new T3.CLASES._Cls_Varios_Metodos(_Ctrl_Controles);
            _Cls_CL._Mtd_Foco();
        }
        clslibraryconssa._Cls_Formato Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public void _Mtd_llenar()
        {
            _str_Valores[0] = _Txt_Cod.Text.ToUpper();
            _str_Valores[1] = _Txt_Des.Text.ToUpper();
            try
            {
                if (_Cbox_Cuenta.Items.Count > 0 & _Cbox_Cuenta.SelectedValue != null & _Cbox_Cuenta.SelectedValue.ToString() != "nulo")
                {
                    _str_Valores[2] = _Cbox_Cuenta.SelectedValue.ToString();
                }
                else { _str_Valores[2] = "nulo"; }
            }
            catch { }
            try
            {
                if (_Cbox_Contra.Items.Count > 0 & _Cbox_Contra.SelectedValue != null & _Cbox_Contra.SelectedValue.ToString() != "nulo")
                {
                    _str_Valores[3] = _Cbox_Contra.SelectedValue.ToString();
                }
                else { _str_Valores[3] = "nulo"; }
            }
            catch { }
            try
            {
                if (_Cbox_TipPro.Items.Count > 0 & _Cbox_TipPro.SelectedValue != null & _Cbox_TipPro.SelectedValue.ToString() != "nulo")
                {
                    _str_Valores[4] = _Cbox_TipPro.SelectedValue.ToString();
                }
                else { _str_Valores[4] = "nulo"; }
            }
            catch { }
            //----------------------------------------------
            _Str_Necesarios[0] = "0";
            _Str_Necesarios[1] = "1";
            _Str_Necesarios[2] = "4";
            //------------------------------------------------
            CONTROLES._Ctrl_Buscar._Str_Valores = _str_Valores;
            CONTROLES._Ctrl_Buscar._Str_Necesario = _Str_Necesarios;
        }
        public void _Mtd_Cargar()
        {
            _Cbox_Cuenta.DataSource = null;
            _Cbox_TipPro.DataSource = null;
            DataSet _Ds;
            DataRow _Row;
            try
            {
                //--------------------------------------
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cname + ' ' + ccount AS nombre, ccount AS cuenta FROM TCOUNT WHERE cdelete = '0' and ccompany='" + Frm_Padre._Str_Comp + "'");
                _Row = _Ds.Tables[0].NewRow();
                _Row["nombre"] = "...";
                _Row["cuenta"] = "nulo";
                _Ds.Tables[0].Rows.Add(_Row);
                _Cbox_Cuenta.DataSource = _Ds.Tables[0];
                _Cbox_Cuenta.DisplayMember = "nombre";
                _Cbox_Cuenta.ValueMember = "cuenta";
                _Cbox_Cuenta.SelectedValue = "nulo";
            }
            catch { }
            try
            {
                _Cbox_TipPro.DataSource = _Ds_.Tables[0];
                _Cbox_TipPro.DisplayMember = "descripcion";
                _Cbox_TipPro.ValueMember = "clave";
                _Cbox_TipPro.SelectedValue = "nulo";
            }
            catch { }
        }
        public void _Mtd_Cargar_Contra(string _P_Str_Cuenta)
        {
            _Cbox_Contra.DataSource = null;
            DataSet _Ds;
            DataRow _Row;
            try
            {
                //--------------------------------------
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cname + ' ' + ccount AS nombre, ccount AS cuenta FROM TCOUNT WHERE cdelete = '0' and ccompany='" + Frm_Padre._Str_Comp + "' and ccount<>'"+_P_Str_Cuenta+"'");
                _Row = _Ds.Tables[0].NewRow();
                _Row["nombre"] = "...";
                _Row["cuenta"] = "nulo";
                _Ds.Tables[0].Rows.Add(_Row);
                _Cbox_Contra.DataSource = _Ds.Tables[0];
                _Cbox_Contra.DisplayMember = "nombre";
                _Cbox_Contra.ValueMember = "cuenta";
                _Cbox_Contra.SelectedValue = "nulo";
            }
            catch { }
        }
        private void Frm_CategProvee_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Dg_Grid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                CONTROLES._Ctrl_Buscar._txt_text.Text = "";
                CONTROLES._Ctrl_Buscar._txt_text.Text = _Dg_Grid.CurrentCell.RowIndex.ToString();
            }
            catch
            {
            }
        }
        public void _Mtd_Ini()
        {
            _Txt_Cod.Text = "";
            _Txt_Des.Text = "";
            _Mtd_Cargar();
        }

        private void _Tb_Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
        }

        private void _Txt_Cod_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
        }

        private void _Txt_Des_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
        }

        private void _Cbox_Cuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Cbox_Cuenta.DataSource!=null)
            {
                if (_Cbox_Cuenta.SelectedValue.ToString() != "nulo")
                {
                    _Mtd_Cargar_Contra(_Cbox_Cuenta.SelectedValue.ToString());
                }
                else
                {
                    _Cbox_Contra.DataSource = null;
                }
            }
            else
            {
                _Cbox_Contra.DataSource = null;
            }
        }

        private void _Cbox_Contra_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        DataSet _Ds_ = new DataSet();
        public void _Mtd_Comb_Tipo()
        {
            _Ds_.Tables.Add("Tabla");
            _Ds_.Tables[0].Columns.Add("clave");
            _Ds_.Tables[0].Columns.Add("descripcion");
            DataRow _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["clave"] = "0";
            _DRow_["descripcion"] = "Servicio";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["clave"] = "1";
            _DRow_["descripcion"] = "Materia Prima";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["clave"] = "2";
            _DRow_["descripcion"] = "Otros";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["clave"] = "nulo";
            _DRow_["descripcion"] = "...";
            _Ds_.Tables[0].Rows.Add(_DRow_);

        }

        private void _Cbox_TipPro_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Cbox_TipPro.DataSource != null)
            {
                if (_Cbox_TipPro.SelectedValue.ToString() == "0")
                {
                    _Str_Necesarios = new string[6];
                    _Str_Necesarios[0] = "0";
                    _Str_Necesarios[1] = "1";
                    _Str_Necesarios[2] = "2";
                    _Str_Necesarios[3] = "3";
                    _Str_Necesarios[4] = "4";
                    _Str_Necesarios[5] = "5";
                    CONTROLES._Ctrl_Buscar._Str_Necesario = _Str_Necesarios;
                }
                else
                {
                    _Str_Necesarios = new string[3];
                    _Str_Necesarios[0] = "0";
                    _Str_Necesarios[1] = "1";
                    _Str_Necesarios[2] = "5";
                    CONTROLES._Ctrl_Buscar._Str_Necesario = _Str_Necesarios;
                }
            }
        }

        private void _Dg_Grid_SelectionChanged(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Txt_UnClick.Text = _Dg_Grid.CurrentCell.RowIndex.ToString();
            CONTROLES._Ctrl_Buscar._Int_UnClick = _Dg_Grid.CurrentCell.RowIndex;
        }

        private void _Dg_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
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
    }
}