using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
namespace T3.CONTROLES
{//Where para c_visita='0'
    public partial class _Ctrl_Buscar : UserControl
    {
        public _Ctrl_Buscar()
        {
            InitializeComponent();
        }

        private void _Ctrl_Buscar_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Top;
            _txt_ExistForm.TextChanged += new EventHandler(_txt_ExistForm_TextChanged);
            _txt_text.TextChanged += new EventHandler(_txt_text_TextChanged);
            _Txt_UnClick.TextChanged += new EventHandler(_Txt_UnClick_TextChanged);
            _Txt_TpoFind.TextChanged  += new EventHandler(_Txt_TpoFind_TextChanged); //NUEVOOOOO
            _Txt_Editando.TextChanged += new EventHandler(_Txt_Editando_TextChanged);
            _Txt_UnBoton.TextChanged += new EventHandler(_Txt_UnBoton_TextChanged);
            _Txt_BotonCtrl.TextChanged += new EventHandler(_Txt_BotonCtrl_TextChanged);
            _frm_Formulario = new Form();
        }

        void _Txt_BotonCtrl_TextChanged(object sender, EventArgs e)
        {
            string[] _Str_Cad;
            char[] delimiterChars = { ',' };
            _Str_Cad = _Txt_BotonCtrl.Text.Split(delimiterChars);
            foreach (string _Str_A in _Str_Cad)
            {
                if (_Bl_Especial)
                {
                    if (_Str_A == "NT")
                    { _Bt_nuevo2.Enabled = true; }
                    if (_Str_A == "NF")
                    { _Bt_nuevo2.Enabled = false; }
                    if (_Str_A == "MT")
                    { _Bt_editar2.Enabled = true; }
                    if (_Str_A == "MF")
                    { _Bt_editar2.Enabled = false; }
                    if (_Str_A == "GT")
                    { _Bt_guardar2.Enabled = true; }
                    if (_Str_A == "GF")
                    { _Bt_guardar2.Enabled = false; }
                    if (_Str_A == "ET")
                    { _Bt_borrar2.Enabled = true; }
                    if (_Str_A == "EF")
                    { _Bt_borrar2.Enabled = false; }
                    if (_Str_A == "AT")
                    { _Bt_actualizar2.Enabled = true; }
                    if (_Str_A == "AF")
                    { _Bt_actualizar2.Enabled = false; }
                    if (_Str_A == "CT")
                    { _Bt_cancelar2.Enabled = true; }
                    if (_Str_A == "CF")
                    { _Bt_cancelar2.Enabled = false; }

                }
                else
                {
                    if (_Str_A == "NT")
                    { _Bt_nuevo.Enabled = true; }
                    if (_Str_A == "NF")
                    { _Bt_nuevo.Enabled = false; }
                    if (_Str_A == "MT")
                    { _Bt_editar.Enabled = true; }
                    if (_Str_A == "MF")
                    { _Bt_editar.Enabled = false; }
                    if (_Str_A == "GT")
                    { _Bt_guardar.Enabled = true; }
                    if (_Str_A == "GF")
                    { _Bt_guardar.Enabled = false; }
                    if (_Str_A == "ET")
                    { _Bt_borrar.Enabled = true; }
                    if (_Str_A == "EF")
                    { _Bt_borrar.Enabled = false; }
                    if (_Str_A == "AT")
                    { _Bt_actualizar.Enabled = true; }
                    if (_Str_A == "AF")
                    { _Bt_actualizar.Enabled = false; }
                    if (_Str_A == "CT")
                    { _Bt_cancelar.Enabled = true; }
                    if (_Str_A == "CF")
                    { _Bt_cancelar.Enabled = false; }
                }
            }
            _Txt_BotonCtrl.Text = "";
        }

        void _Txt_UnBoton_TextChanged(object sender, EventArgs e)
        {
            if (_Txt_UnBoton.Text.Length > 0)
            {
                if (_Txt_UnBoton.Text == "Nuevo")
                { _Bt_nuevo2.Enabled = true; }
                else if (_Txt_UnBoton.Text == "Editar")
                { _Bt_editar2.Enabled = true; }
                else if (_Txt_UnBoton.Text == "Agregar")
                { _Bt_guardar2.Enabled = true; }
                else if (_Txt_UnBoton.Text == "Eliminar")
                { _Bt_borrar2.Enabled = true; }
            }
        }

        void _Txt_Editando_TextChanged(object sender, EventArgs e)
        {
            if (_Txt_Editando.Text.Length > 0)
            {
                _Bt_editar2.Enabled = true;
                _Bt_borrar2.Enabled = true;
            }
        }

        void _Txt_UnClick_TextChanged(object sender, EventArgs e)
        {
            if (_Txt_UnClick.Text != "")
            {
                _Bt_borrar.Enabled = true;
            }
        }
        void _Txt_TpoFind_TextChanged(object sender, EventArgs e)//NUEVOOOOO
        {
            if ((_Txt_TpoFind.Text == "") || (_Txt_TpoFind.Text == "N"))
            {
                personalizadaToolStripMenuItem.Visible = false;
            }
            else
            {
                if (_Txt_TpoFind.Text == "P")
                {
                    personalizadaToolStripMenuItem.Visible = true;
                }
                else
                {//NUEVOOO************************************
                    if (_Txt_TpoFind.Text == "PA")
                    {
                        clavePrincipalToolStripMenuItem.Visible = false;
                        descripciónToolStripMenuItem.Visible = false; 
                        personalizadaToolStripMenuItem.Visible = true;
                    }
                }
            }
        }
        public void _Mtd_Mostrar_MenuNomal()
        {
            _Bt_nuevo.Visible = true;
            _Bt_nuevo2.Visible = false;
            _Bt_editar.Visible = true;
            _Bt_editar2.Visible = false;
            _Bt_guardar.Visible = true;
            _Bt_guardar2.Visible = false;
            _Bt_borrar.Visible = true;
            _Bt_borrar2.Visible = false;
            _Bt_actualizar.Visible = true;
            _Bt_actualizar2.Visible = false;
            _Bt_cancelar.Visible = true;
            _Bt_cancelar2.Visible = false;
        }
        public void _Mtd_Mostrar_MenuEspecial()
        {
            _Bt_nuevo.Visible = false;
            _Bt_nuevo2.Visible = true;
            _Bt_editar.Visible = false;
            _Bt_editar2.Visible = true;
            _Bt_guardar.Visible = false;
            _Bt_guardar2.Visible = true;
            _Bt_borrar.Visible = false;
            _Bt_borrar2.Visible = true;
            _Bt_actualizar.Visible = false;
            _Bt_actualizar2.Visible = true;
            _Bt_cancelar.Visible = false;
            _Bt_cancelar2.Visible = true;
        }
        void _txt_ExistForm_TextChanged(object sender, EventArgs e)
        {
            if (_txt_ExistForm.Text=="Abierto")
            {
                if (_Bl_Especial)
                {
                    _Mtd_Mostrar_MenuEspecial();
                }
                else
                {
                    _Mtd_Mostrar_MenuNomal();
                }
                _Mtd_Habilitar_Menu();
                //toolStripComboBox1.Enabled = true;
            }
            else
            {
                if (_Bl_Especial)
                {
                    _Mtd_Mostrar_MenuEspecial();
                }
                else
                {
                    _Mtd_Mostrar_MenuNomal();
                }
                _Mtd_Des_Habilitar_Menu();
                //toolStripComboBox1.Enabled = false;
            }
        }
        void _txt_text_TextChanged(object sender, EventArgs e)
        {

           try 
           {
               if (_Bl_Modifi)
               { }
               else
               { _Mtd_Igualar(); _Mtd_Deshabilitar();}
           _Bt_editar.Enabled = true;
           _Bt_guardar.Enabled = false;
           _Bt_borrar.Enabled = true;
           _Bt_actualizar.Enabled = true;
           }
           catch { }
        }
        public static Form _frm_Formulario;
        public static string[] _Str_Valores;
        public static string[] _Str_Necesario;
        public static string[] _Str_Campos;
        public static string _Str_Where_Vista_Grid;
        public static Control[] _Ctrl_Controles;
        public static string[] _Str_Cadena_Consulta_Where;
        public static string[] _Str_NoseDebeRepetir;
        public static int[] _Int_Codigo_Descripcion;
        public static string _Str_Cadena_Consulta_Formato;
        public static string _Str_Cadena_Consulta_Formato_Busqueda;
        public static string _Str_Cadena_Consulta;
        public static ErrorProvider _Er_Control_Error;
        public static DataGridView _Dg_Datagrid=new DataGridView();
        public static TabControl _Tb_Tab;
        public static string _Str_Tabla;
        public string _Str_Campo;
        public string _Str_Valor;
        public string _Str_Campo_where;
        public string _Str_Campo_Mod;
        public string _Str_Consulta;
        public static string[] _Str_Deshabilitados;
        public static TextBox _txt_text=new TextBox();
        public static TextBox _txt_ExistForm=new TextBox();
        public static TextBox _Txt_TpoFind = new TextBox();
        public static TextBox _Txt_UnClick = new TextBox();
        public static TextBox _Txt_Editando = new TextBox();
        public static TextBox _Txt_UnBoton = new TextBox();
        public static int _Int_Foco;
        public static int _Int_UnClick;
        DataSet _Ds_Data;
        public static string[] _Str_campos_Consulta;
        public static bool _Bl_Modifi = false;
        public static bool _Bl_Especial=false;
        //NUEVO**************************************
        public static string[] _Str_CamposFiltro;
        public static string[] _Str_CamposFiltroName;
        public static string[] _Str_CamposFiltroType;
        public static string[] _Str_CamposFiltroStyle;
        public static string _Str_FindSql_Lista="";
        object[] _Obj_Proceso = new object[1];
        //*******************************************
        public static TextBox _Txt_BotonCtrl = new TextBox();
        //NUEVO**************************************
        public static Image[] _Img_Save;
        public static string[] _Str_ImgCampos;
        //*******************************************
        public void _Mtd_Deshabilitar()
        {
            int _Int_i = 0;
            if (_Ctrl_Controles != null)
            {
                foreach (Control _Ctrl_C in _Ctrl_Controles)
                {
                    _Ctrl_Controles[_Int_i].Enabled = false;
                    _Int_i++;
                }
            }
        }
        public void _Mtd_Habilitar_modi()
        {
            int _Int_i = 0;
            foreach (Control _Ctrl_C in _Ctrl_Controles)
            {
                //if(_Int_i!=Convert.ToInt32(_Str_Necesario[_Int_i].ToString()))
                bool _bl_sw = false;
                foreach (string _Str2 in _Str_Deshabilitados)
                {
                    if (_Int_i == Convert.ToInt32(_Str2))
                    {
                        _bl_sw = true;
                    }
                }
                if (_bl_sw)
                {
                    _Ctrl_Controles[_Int_i].Enabled = false ;
                }
                else
                {
                    _Ctrl_Controles[_Int_i].Enabled = true;
                }
                _Int_i++;
            }
        }
        public void _Mtd_Habilitar()
        {
            int _Int_i = 0;
            foreach (Control _Ctrl_C in _Ctrl_Controles)
            {
                _Ctrl_Controles[_Int_i].Enabled = true;
                _Int_i++;
            }
        }
        private void _Bt_nuevo_Click(object sender, EventArgs e)
        {

            try
            {
                _Bl_Modifi = false; _txt_text.Text = ""; _frm_Formulario.GetType().GetMethod("_Mtd_Ini").Invoke(_frm_Formulario, null); _Tb_Tab.SelectedIndex = 1; _Er_Control_Error.Dispose(); _Mtd_Habilitar(); _Ctrl_Controles[_Int_Foco].Focus();
            _Bt_guardar.Enabled = true;
            _Bt_actualizar.Enabled = true;
            _Bt_editar.Enabled = false;
            _Bt_borrar.Enabled = false;
            _Bt_actualizar.Enabled = true;
                try
                {
                    //NUEVO***********************************************************************************
                    _frm_Formulario.GetType().GetMethod("_Mtd_Proceso_Add").Invoke(_frm_Formulario, null);
                    //****************************************************************************************
                }
                catch { }
            _frm_Formulario.GetType().GetMethod("_Mtd_Entrada").Invoke(_frm_Formulario, null);
            }
            catch { }
        }
        public bool _Mtd_Validar2()
        {
            try
            {
                bool _bl_sw = true;
                _frm_Formulario.GetType().GetMethod("_Mtd_llenar").Invoke(_frm_Formulario, null); 
                foreach (string d in _Str_Necesario)
                {
                    try
                    {
                        if (_Str_Valores[int.Parse(d)].ToString().Trim().Length < 1 | _Str_Valores[int.Parse(d)].ToString().Trim()=="nulo")
                        {
                            _Er_Control_Error.SetError(_Ctrl_Controles[int.Parse(d)], "Información Requerida!!!");
                            _bl_sw = false;
                            _Int_i = -1;
                            _Int_ii = -1;
                            _Bol_B = true;
                            _Mtd_Recorrer(int.Parse(d), _Tb_Tab);
                        }
                    }
                    catch { }
                }
                if (_bl_sw == false)
                {
                    _Tb_Tab.SelectedIndex = _Int_i;
                }
                return _bl_sw;
            }
            catch { return false; }
        }
        public bool _Mtd_Validar1()
        {
            try
            {
                bool _bl_sw = true;
                try
                {
                    _frm_Formulario.GetType().GetMethod("_Mtd_Entrada").Invoke(_frm_Formulario, null);
                    _frm_Formulario.GetType().GetMethod("_Mtd_llenar").Invoke(_frm_Formulario, null);
                }
                catch { _frm_Formulario.GetType().GetMethod("_Mtd_llenar").Invoke(_frm_Formulario, null); }
                foreach (string d in _Str_Necesario)
                {
                    try
                    {
                        if (_Str_Valores[int.Parse(d)].ToString().Trim().Length < 1 | _Str_Valores[int.Parse(d)].ToString().Trim() == "nulo")
                        {
                            _Er_Control_Error.SetError(_Ctrl_Controles[int.Parse(d)], "Información Requerida!!!");
                            _bl_sw = false;
                            _Int_i = -1;
                            _Int_ii = -1;
                           _Bol_B = true;
                            _Mtd_Recorrer(int.Parse(d),_Tb_Tab);
                        }
                    }
                    catch { }
                }
                if (_bl_sw == false)
                {
                    _Tb_Tab.SelectedIndex = _Int_i;
                }
                return _bl_sw;
            }
            catch { return false; }
        }
        int _Int_i = -1;
        int _Int_ii = -1;
        bool _Bol_B = true;
        public void _Mtd_Recorrer(int _P_Int_,Control _P_Ctrl)
        {
            if (_P_Ctrl.GetType() == typeof(TabPage))
            {
                _Int_ii++;
            }
            foreach (Control _Ctrl in _P_Ctrl.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Recorrer(_P_Int_, _Ctrl);
                }
                else
                {
                    if (_Ctrl.Name == _Ctrl_Controles[_P_Int_].Name & _Bol_B==true)
                    {
                        _Int_i = _Int_ii;
                        _Bol_B = false;
                    }
                }
            }
        }
        public void _Mtd_Descomprimir_Agre()
        {

            _Str_Campo = "";
            _Str_Valor="'";
            foreach (string s1 in _Str_Campos)
            {
                _Str_Campo = _Str_Campo + s1 + ",";
            }
            _Str_Campo = _Str_Campo.Trim().Substring(0,_Str_Campo.Trim().Length - 1);
            //-------------------------------------
            foreach (string s2 in _Str_Valores)
            {
                _Str_Valor = _Str_Valor + s2 + "','";
            }
            _Str_Valor = _Str_Valor.Trim().Substring(0,_Str_Valor.Trim().Length - 2);
        }
        public void _Mtd_Descomprimir_Modi()
        {
            _Str_Campo_Mod = "";
            int _Int_i=0;
            foreach (string s1 in _Str_Campos)
            {
                if (_Str_Valores[_Int_i].ToString() != "System.Byte[]")
                {
                    _Str_Campo_Mod = _Str_Campo_Mod + s1 + "='" + _Str_Valores[_Int_i].ToString() + "',";
                }
                _Int_i++;
            }
            _Str_Campo_Mod = _Str_Campo_Mod.Trim().Substring(0, _Str_Campo_Mod.Trim().Length - 1);
        }
        public void _Mtd_Descomprimir_consulta()
        {
            _Str_Consulta = "";
            foreach (string s1 in _Str_Cadena_Consulta_Where)
            {
                _Str_Consulta = _Str_Consulta + s1 + ",";
            }
            _Str_Consulta = _Str_Consulta.Trim().Substring(0, _Str_Consulta.Trim().Length - 1);
        }
        public void _Preparar_Ds_Data()
        {
            _Mtd_Descomprimir_consulta();
            if (toolStripComboBox1.Text.Trim().Length > 0)
            {
                if (_Str_Cadena_Consulta_Where.ToString().Trim().Length > 0)
                { _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select " + _Str_Consulta + " from " + _Str_Tabla + " where " + _Str_Where_Vista_Grid + " AND " + _Str_Campos[_Int_Codigo_Descripcion[_Int_Pos]].ToString() + " LIKE '%" + toolStripComboBox1.Text + "%' ORDER BY " + _Str_Campos[_Int_Codigo_Descripcion[_Int_Pos]].ToString() + " ASC"); }
                else
                { _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select " + _Str_Consulta + " from " + _Str_Tabla + " where " + _Str_Campos[_Int_Codigo_Descripcion[_Int_Pos]].ToString() + " LIKE '%" + toolStripComboBox1.Text + "%' ORDER BY " + _Str_Campos[_Int_Codigo_Descripcion[_Int_Pos]].ToString() + " ASC"); }
            }
            else
            {
                _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select " + _Str_Consulta + " from " + _Str_Tabla + " Where " + _Str_Where_Vista_Grid);
            }
        }
        public void _Mtd_Descomprimir_Where(int _P_Int_NumeroFila)
        {
            //_Mtd_Descomprimir_consulta();
            //_Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select " + _Str_Consulta + " from " + _Str_Tabla +" Where "+ _Str_Where_Vista_Grid);
            _Preparar_Ds_Data();
            _Str_Campo_where= "";
            int _Int_i = 0;
            foreach (string s1 in _Str_Cadena_Consulta_Where)
            {
                try
                {
                    DateTime _dt_ = Convert.ToDateTime(_Ds_Data.Tables[0].Rows[_P_Int_NumeroFila][s1].ToString().Substring(0, 10));
                    string _Str_cadena = _Ds_Data.Tables[0].Rows[_P_Int_NumeroFila][s1].ToString().Substring(0, 10);
                    _Str_Campo_where = _Str_Campo_where + s1 + "='" + _Str_cadena + "' and ";
                }
                catch 
                {
                    _Str_Campo_where = _Str_Campo_where + s1 + "='" + _Ds_Data.Tables[0].Rows[_P_Int_NumeroFila][s1].ToString() + "' and ";
                }
                _Int_i++;
            }
            _Str_Campo_where = _Str_Campo_where.Trim().Substring(0, _Str_Campo_where.Trim().Length - 4);
        }
        clslibraryconssa._Cls_Formato Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public void _Mtd_Agregar()
        {
            try
            {
                if (!_Bl_Especial)
                {
                    try
                    { Program._MyClsCnn._mtd_conexion._Mtd_Insertar(_Str_Tabla, _Str_Campo + ",cdateadd,cuseradd,cdelete", _Str_Valor + ",GETDATE(),'"+ Frm_Padre._Str_Use +"','0'"); }
                    catch
                    { Program._MyClsCnn._mtd_conexion._Mtd_Insertar(_Str_Tabla, _Str_Campo, _Str_Valor); }
                }
                else
                {
                    _frm_Formulario.GetType().GetMethod("_Mtd_Guardar").Invoke(_frm_Formulario, null);
                }
                _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena_Consulta_Formato + " Where " + _Str_Where_Vista_Grid);
                try { _Dg_Datagrid.DataSource = _Ds_Data.Tables[0];}
                catch { }
                MessageBox.Show("El registro fue insertado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception de) { MessageBox.Show(de.Message); }
        }
        public void _Mtd_Modificar()
        {
            try
            {
                if (!_Bl_Especial)
                {
                    try
                    { Program._MyClsCnn._mtd_conexion._Mtd_modificar(_Str_Tabla, _Str_Campo_Mod + ",cdateupd=GETDATE(),cuserupd='"+ Frm_Padre._Str_Use+"',cdelete='0'", _Str_Campo_where); }
                    catch
                    { Program._MyClsCnn._mtd_conexion._Mtd_modificar(_Str_Tabla, _Str_Campo_Mod, _Str_Campo_where); }
                }
                else
                {
                    _frm_Formulario.GetType().GetMethod("_Mtd_Modificar").Invoke(_frm_Formulario, null);
                }
                _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena_Consulta_Formato + " Where " + _Str_Where_Vista_Grid);
                try { _Dg_Datagrid.DataSource = _Ds_Data.Tables[0];}
                catch { }
                MessageBox.Show("El registro fue modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception de) { MessageBox.Show(de.Message); }
        }
        public void _Mtd_Eliminar()
        {
            try
            {
                if (!_Bl_Especial)
                {
                    try
                    { Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia("update " + _Str_Tabla + " set cdelete='1',cdatedel=GETDATE(),cuserdel='"+Frm_Padre._Str_Use+"' where " + _Str_Campo_where); }
                    catch
                    { Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia("Delete from " + _Str_Tabla + " where " + _Str_Campo_where); }
                }
                else
                {
                    _frm_Formulario.GetType().GetMethod("_Mtd_Eliminar").Invoke(_frm_Formulario, null);
                }
                _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena_Consulta_Formato + " Where " + _Str_Where_Vista_Grid);
                try { _Dg_Datagrid.DataSource = _Ds_Data.Tables[0];}
                catch { }
                MessageBox.Show("El registro fue eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { } 
        }
        clslibraryconssa._Cls_Formato _For = new clslibraryconssa._Cls_Formato("es-VE");
        public string _Mtd_NoRepetir()
        {
            string _Str_NoRepetir = "";
            string _Str_Uno1="El valor ";
            string _Str_Uno2 = " ya se encuentra registrado. Debe ingresar un valor diferente";
            string _Str_Dos1 = "Los valores ";
            string _Str_Dos2 = " ya se encuentran registrados. Debe ingresar valores diferentes";
            int _Int_j = 0;
            try
            {
                foreach (string _Str1 in _Str_NoseDebeRepetir)
                {
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from " + _Str_Tabla + " where " + _Str_Campos[Convert.ToInt32(_Str1)] + "='" + _Str_Valores[Convert.ToInt32(_Str1)].ToString() + "'").Tables[0].Rows.Count > 0)
                    {
                        _Str_NoRepetir = _Str_NoRepetir + _Str_Valores[Convert.ToInt32(_Str1)].ToString() + ",";
                        _Int_j++;
                    }
                }
                _Str_NoRepetir = _Str_NoRepetir.Substring(0, _Str_NoRepetir.Length - 1);
                if (_Int_j == 1)
                {
                    _Str_NoRepetir = _Str_Uno1 + _Str_NoRepetir + _Str_Uno2;
                }
                if (_Int_j > 1)
                {
                    _Str_NoRepetir = _Str_Dos1 + _Str_NoRepetir + _Str_Dos2;
                }
                if (_Int_j ==0)
                {
                    _Str_NoRepetir = "null";
                }
            }
            catch { _Str_NoRepetir = "null";}
            return _Str_NoRepetir;
        }
        DataRow row;
        public void _Mtd_Igualar()
        {
            bool _bl_sw = false;  
            try
            {
                //_Mtd_Descomprimir_Where(Convert.ToInt32(_txt_text.Text));
                _Str_Campo_where = _txt_text.Text;
                _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena_Consulta + " where " + _Str_Campo_where);
                row = _Ds_Data.Tables[0].Rows[0];
            }
            catch {  }
                int _Int_i = 0;
                foreach (DataColumn col in _Ds_Data.Tables[0].Columns)
                {
                    _bl_sw = true;
                        if (_Ctrl_Controles[_Int_i].GetType() == typeof(System.Windows.Forms.TextBox))
                        {
                            _Ctrl_Controles[_Int_i].Text = row[_Str_Campos[_Int_i].ToString()].ToString();
                        }
                    if (_Ctrl_Controles[_Int_i].GetType() == typeof(System.Windows.Forms.CheckBox))
                    {
                        if (row[_Str_Campos[_Int_i].ToString()].ToString() == "1")
                        { ((CheckBox)_Ctrl_Controles[_Int_i]).Checked = true; }
                        if (row[_Str_Campos[_Int_i].ToString()].ToString() == "0")
                        { ((CheckBox)_Ctrl_Controles[_Int_i]).Checked = false; }
                        if (row[_Str_Campos[_Int_i].ToString()].ToString().Trim().Length > 3 & row[_Str_Campos[_Int_i].ToString()].ToString() != "1" & row[_Str_Campos[_Int_i].ToString()].ToString() != "0")
                        { ((CheckBox)_Ctrl_Controles[_Int_i]).Checked = true; }
                    }
                    if (_Ctrl_Controles[_Int_i].GetType() == typeof(System.Windows.Forms.RadioButton))
                    {
                        if (row[_Str_Campos[_Int_i].ToString()].ToString() == "1")
                        { ((RadioButton)_Ctrl_Controles[_Int_i]).Checked = true; }
                        if (row[_Str_Campos[_Int_i].ToString()].ToString() == "0")
                        { ((RadioButton)_Ctrl_Controles[_Int_i]).Checked = false; }
                    }
                    if (_Ctrl_Controles[_Int_i].GetType() == typeof(System.Windows.Forms.ComboBox))
                    {
                        ((ComboBox)_Ctrl_Controles[_Int_i]).SelectedValue = row[_Str_Campos[_Int_i].ToString()].ToString();
                    }
                    if (_Ctrl_Controles[_Int_i].GetType() == typeof(System.Windows.Forms.DateTimePicker))
                    {
                        ((DateTimePicker)_Ctrl_Controles[_Int_i]).Value = Convert.ToDateTime(row[_Str_Campos[_Int_i].ToString()].ToString());
                    }
                    if (_Ctrl_Controles[_Int_i].GetType() == typeof(System.Windows.Forms.MonthCalendar))
                    {
                        ((MonthCalendar)_Ctrl_Controles[_Int_i]).SetDate(Convert.ToDateTime(row[_Str_Campos[_Int_i].ToString()].ToString()));
                    }
                    if (_Ctrl_Controles[_Int_i].GetType() == typeof(System.Windows.Forms.NumericUpDown))
                    {
                        try
                        {
                            if (row[_Str_Campos[_Int_i].ToString()].ToString().Trim().Length == 0)
                            { ((NumericUpDown)_Ctrl_Controles[_Int_i]).Value = 0; }
                            else
                            { ((NumericUpDown)_Ctrl_Controles[_Int_i]).Value = Convert.ToInt32(row[_Str_Campos[_Int_i].ToString()].ToString()); }
                        }
                        catch { }
                    }
                    if (_Ctrl_Controles[_Int_i].GetType() == typeof(System.Windows.Forms.PictureBox))
                    {
                        try
                        {
                            ((PictureBox)_Ctrl_Controles[_Int_i]).Image = _Mtd_convertirByteparaImage(((byte[])row[_Str_Campos[_Int_i]]));
                        }
                        catch { ((PictureBox)_Ctrl_Controles[_Int_i]).Image = null; }
                    }
                    _Int_i++;
                }
                if (_bl_sw)
                {
                    _Tb_Tab.SelectedIndex = 1;
                    //_Ctrl_Controles[0].Enabled = false;
                }
        }
        public Image _Mtd_convertirByteparaImage(byte[] _by_p_)
        {
            byte[] _by_imageBuffer = _by_p_;
            System.IO.MemoryStream _ms = new System.IO.MemoryStream(_by_imageBuffer);
            Image _img_h = Image.FromStream(_ms);
            return _img_h;
        }
        private void _Bt_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                //string _Str_Message=_Mtd_NoRepetir();
                //if (_Mtd_Validar())
                //{
                    //if (_Str_Message == "null")
                    //{
                        if (_Bl_Modifi)
                        {
                            if (_Mtd_Validar2())
                            {
                                _Mtd_Descomprimir_Modi();
                                //_Mtd_Descomprimir_Where(Convert.ToInt32(_txt_text.Text));
                                _Str_Campo_where = _txt_text.Text;
                                _Mtd_Modificar();
                                try
                                {
                                    _frm_Formulario.GetType().GetMethod("_Mtd_Ini2").Invoke(_frm_Formulario, null);
                                    _Bt_editar.Enabled = true;
                                    _Bt_guardar.Enabled = false;
                                    _Bt_borrar.Enabled = true;
                                }
                                catch
                                {
                                    _txt_text.Text = ""; _frm_Formulario.GetType().GetMethod("_Mtd_Ini").Invoke(_frm_Formulario, null); _Tb_Tab.SelectedIndex = 0; _Bl_Modifi = false; _Mtd_Deshabilitar();
                                    _Bt_editar.Enabled = false;
                                    _Bt_guardar.Enabled = false;
                                    _Bt_borrar.Enabled = false;
                                }
                            }
                        }
                        else
                        {
                            if (_Mtd_Validar1())
                            {
                                string _Str_Message = _Mtd_NoRepetir();
                                if (_Str_Message == "null")
                                {
                                    _Mtd_Descomprimir_Agre();
                                    _Mtd_Agregar();
                                    try
                                    {
                                        _frm_Formulario.GetType().GetMethod("_Mtd_Ini2").Invoke(_frm_Formulario, null);
                                        _Bt_editar.Enabled = true;
                                        _Bt_guardar.Enabled = false;
                                        _Bt_borrar.Enabled = true;
                                    }
                                    catch
                                    {
                                        _txt_text.Text = ""; _frm_Formulario.GetType().GetMethod("_Mtd_Ini").Invoke(_frm_Formulario, null); _Tb_Tab.SelectedIndex = 0; _Bl_Modifi = false; _Mtd_Deshabilitar();
                                        _Bt_editar.Enabled = false;
                                        _Bt_guardar.Enabled = false;
                                        _Bt_borrar.Enabled = false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(_Str_Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        //}
                    //}
                    //else
                    //{
                    //    MessageBox.Show(_Str_Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }
                _Dg_Datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch { }
        }
        private void _Bt_editar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (_Mtd_Validar())
                //{
                    _Mtd_Habilitar_modi();
                    _Bl_Modifi = true;
                    _Bt_editar.Enabled = false;
                    _Bt_guardar.Enabled = true;
                    _Bt_borrar.Enabled = true;
                    //_Mtd_Descomprimir_Modi();
                    //_Mtd_Descomprimir_Where();
                    //_Mtd_Modificar();
                    //try { _txt_text.Text = ""; _frm_Formulario.GetType().GetMethod("_Mtd_Ini").Invoke(_frm_Formulario, null); _Tb_Tab.SelectedIndex = 0; }
                    //catch { }
                //}
            }
            catch { }
        }

        private void _Bt_borrar_Click(object sender, EventArgs e)
        {
           bool _Bol_Bl = false;
            try
            {
                if (_txt_text.Text.Length<1)
                {
                }
                else
                {
                    DialogResult _Dial= MessageBox.Show("Esta seguuro de eliminar el registro?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (_Dial == DialogResult.Yes)
                    {
                        //_Mtd_Descomprimir_Where(Convert.ToInt32(_txt_text.Text));
                        _Str_Campo_where = _txt_text.Text;
                        _Mtd_Eliminar();
                        //try { _txt_text.Text = ""; _frm_Formulario.GetType().GetMethod("_Mtd_Ini").Invoke(_frm_Formulario, null); _Tb_Tab.SelectedIndex = 0; }
                        //catch { }
                        try { _frm_Formulario.GetType().GetMethod("_Mtd_Ini3").Invoke(_frm_Formulario, null); _txt_text.Text = ""; _frm_Formulario.GetType().GetMethod("_Mtd_Ini").Invoke(_frm_Formulario, null); _Tb_Tab.SelectedIndex = 0; }
                        catch { _txt_text.Text = ""; _frm_Formulario.GetType().GetMethod("_Mtd_Ini").Invoke(_frm_Formulario, null); _Tb_Tab.SelectedIndex = 0;}
                    }
                    else
                    {
                        try { _txt_text.Text = ""; _frm_Formulario.GetType().GetMethod("_Mtd_Ini").Invoke(_frm_Formulario, null); _Tb_Tab.SelectedIndex = 0; }
                        catch { }
                    }
                    _Bol_Bl = true;
                    _Dg_Datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch { }
            try
            {
                if (!_Bol_Bl)
                {
                    DialogResult _Dial = MessageBox.Show("Esta seguuro de eliminar el registro?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (_Dial == DialogResult.Yes)
                    {
                        //_Mtd_Descomprimir_Where(_Int_UnClick);
                        _Str_Campo_where = _Txt_UnClick.Text;
                        _Mtd_Eliminar();
                        //try { _txt_text.Text = ""; _frm_Formulario.GetType().GetMethod("_Mtd_Ini").Invoke(_frm_Formulario, null); _Tb_Tab.SelectedIndex = 0; }
                        //catch { }
                        try { _frm_Formulario.GetType().GetMethod("_Mtd_Ini3").Invoke(_frm_Formulario, null); _txt_text.Text = ""; _frm_Formulario.GetType().GetMethod("_Mtd_Ini").Invoke(_frm_Formulario, null); _Tb_Tab.SelectedIndex = 0; }
                        catch { _txt_text.Text = ""; _frm_Formulario.GetType().GetMethod("_Mtd_Ini").Invoke(_frm_Formulario, null); _Tb_Tab.SelectedIndex = 0; }
                    }
                    else
                    {
                        try { _txt_text.Text = ""; _frm_Formulario.GetType().GetMethod("_Mtd_Ini").Invoke(_frm_Formulario, null); _Tb_Tab.SelectedIndex = 0; }
                        catch { }
                    }
                    _Dg_Datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch { }
            _Bt_editar.Enabled = false;
        }

        private void _Tst_barra_mdi_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        int _Int_Pos = -1;
        private void clavePrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Int_Pos = 0;
        }
        public void _Mtd_filtrar_Grid()
        {
            try
            {
                if (_Str_Cadena_Consulta_Where.ToString().Trim().Length > 0)
                { _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena_Consulta_Formato + " where " + _Str_Where_Vista_Grid + " AND " + _Str_Campos[_Int_Codigo_Descripcion[_Int_Pos]].ToString() + " LIKE '%" + toolStripComboBox1.Text + "%' ORDER BY " + _Str_Campos[_Int_Codigo_Descripcion[_Int_Pos]].ToString() + " ASC"); }
                else
                { _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena_Consulta_Formato + " where " + _Str_Campos[_Int_Codigo_Descripcion[_Int_Pos]].ToString() + " LIKE '%" + toolStripComboBox1.Text + "%' ORDER BY " + _Str_Campos[_Int_Codigo_Descripcion[_Int_Pos]].ToString() + " ASC"); }
                _Dg_Datagrid.DataSource = _Ds_Data.Tables[0];
            }
            catch { }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            if (!_Bl_Especial)
            {
                if (_frm_Formulario.Name != "")
                {
                    if (_Int_Pos == -1)
                    { MessageBox.Show("Debe seleccionar el criterio de la busqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    else
                    { _Mtd_filtrar_Grid(); }
                }
            }
            else
            { 

            }
        }

        private void descripciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Int_Pos = 1;
        }

        private void _Bt_actualizar_Click(object sender, EventArgs e)
        {
            _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena_Consulta_Formato + " Where " + _Str_Where_Vista_Grid);
            try {_Dg_Datagrid.DataSource = _Ds_Data.Tables[0]; toolStripComboBox1.Text = ""; _Int_Pos = -1; }
            catch { }
            _Dg_Datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public void _Mtd_Habilitar_Menu()
        {
            if (_Bl_Especial)
            {
                _Bt_nuevo2.Enabled = true;
                _Bt_cancelar2.Enabled = true;
            }
            else
            {
                _Bt_nuevo.Enabled = true;
                _Bt_cancelar.Enabled = true;
            }
        }
        public void _Mtd_Des_Habilitar_Menu()
        {
            if (_Bl_Especial)
            {
                _Bt_nuevo2.Enabled = false;
                _Bt_editar2.Enabled = false;
                _Bt_guardar2.Enabled = false;
                _Bt_borrar2.Enabled = false;
                _Bt_actualizar2.Enabled = false;
                _Bt_cancelar2.Enabled = false;
            }
            else
            {
                _Bt_nuevo.Enabled = false;
                _Bt_editar.Enabled = false;
                _Bt_guardar.Enabled = false;
                _Bt_borrar.Enabled = false;
                _Bt_actualizar.Enabled = false;
                _Bt_cancelar.Enabled = false;
            }
        }

        private void _Bt_salir_Click(object sender, EventArgs e)
        {
            Form _Frm_Padre = this.FindForm();
            _Frm_Padre.Close();
        }

        private void _Bt_cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                _txt_text.Text = ""; _frm_Formulario.GetType().GetMethod("_Mtd_Ini").Invoke(_frm_Formulario, null); _Tb_Tab.SelectedIndex = 0; _Bl_Modifi = false; _Mtd_Deshabilitar();
                _Bt_nuevo.Enabled = true;
                _Bt_editar.Enabled = false;
                _Bt_guardar.Enabled = false;
                _Bt_borrar.Enabled = false;
                _Bt_actualizar.Enabled = false;
            }
            catch { }

            _Dg_Datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void personalizadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _Str_Sql;
            Frm_FIND Frm_FIND1 = new Frm_FIND(_Str_CamposFiltro, _Str_CamposFiltroName, _Str_CamposFiltroType, _Str_CamposFiltroStyle,_Str_FindSql_Lista);
            try
            {
                Frm_FIND1.ShowDialog();
                if (Frm_FIND1._Str_Result != "")
                {
                    if (Convert.ToString(_Str_Where_Vista_Grid).Trim().Length > 0)
                    {
                        _Str_Sql = _Str_Cadena_Consulta_Formato + " where " + _Str_Where_Vista_Grid + Frm_FIND1._Str_Result;
                        _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    }
                    else
                    {
                        _Str_Sql = _Str_Cadena_Consulta_Formato + " where " + Frm_FIND1._Str_Result;
                        _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    }
                    _Dg_Datagrid.DataSource = _Ds_Data.Tables[0];
                    _Dg_Datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                Frm_FIND1 = null; 
            }
            catch {Frm_FIND1 = null;}
        }
        public static bool _Bol_SoloNuevo = false;
        private void _Bt_nuevo2_Click(object sender, EventArgs e)
        {
            _frm_Formulario.GetType().GetMethod("_Mtd_Nuevo").Invoke(_frm_Formulario, null);
            if (!_Bol_SoloNuevo)
            {
                _Bt_editar2.Enabled = false;
                _Bt_borrar2.Enabled = false;
                _Bt_guardar2.Enabled = true;
                _Bl_Modifi = false;
                try
                {
                    _frm_Formulario.GetType().GetMethod("_Mtd_BotonesMenu").Invoke(_frm_Formulario, null);
                }
                catch
                { }
            }
        }
        private void _Bt_editar2_Click(object sender, EventArgs e)
        {
            _frm_Formulario.GetType().GetMethod("_Mtd_Habilitar").Invoke(_frm_Formulario, null);
            _Bt_editar2.Enabled = false;
            _Bt_guardar2.Enabled = true;
            _Bl_Modifi = true;
        }

        private void _Bt_guardar2_Click(object sender, EventArgs e)
        {
            ((Frm_Padre)this.FindForm())._Pnl_Espera.Visible = true;
            System.Threading.Thread myThread = new System.Threading.Thread(new
            System.Threading.ThreadStart(DoUpdate));
            myThread.Start();
        }
        private void _Bt_borrar2_Click(object sender, EventArgs e)
        {
            if ((bool)(_frm_Formulario.GetType().GetMethod("_Mtd_Eliminar").Invoke(_frm_Formulario, null)))
            {
                _Txt_Editando.Text = "";
                _Bl_Modifi = false;
                _Bt_editar2.Enabled = false;
                _Bt_borrar2.Enabled = false;
                _Bt_guardar2.Enabled = false;
            }
        }

        private void _Bt_cancelar2_Click(object sender, EventArgs e)
        {
            _Bt_nuevo2.Enabled = true;
            _Bt_editar2.Enabled = false;
            _Bt_guardar2.Enabled = false;
            _Bt_borrar2.Enabled = false;
            _Bt_actualizar2.Enabled = false;
            _txt_text.Text = ""; _Mtd_Deshabilitar();
            _frm_Formulario.GetType().GetMethod("_Mtd_Ini").Invoke(_frm_Formulario, null);
            try
            {
                _Tb_Tab.SelectedIndex = 0;
            }
            catch { }
            _Bl_Modifi = false;
            try
            {
                _frm_Formulario.GetType().GetMethod("_Mtd_Cancelar").Invoke(_frm_Formulario, null);
            }
            catch
            {
 
            }
        }
        public void _Mtd_GuardarImagenes()
        {
            string _Str_Sql;
            int I = 0;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            cmd.Connection = conn;
            conn.Open();
            //_Img_Save Vector para Salvar las Imagenes
            //_Str_ImgCampos campos de imagen
            if (_Img_Save != null)
            {
                foreach (Image _Img_My in _Img_Save)
                {
                    if (_Img_Save[I] != null)
                    {
                        _Str_Sql = "UPDATE " + _Str_Tabla + " SET " + _Str_ImgCampos[I].ToString() + "=@" + _Str_ImgCampos[I].ToString();
                        _Str_Sql = _Str_Sql + " WHERE " + _Str_Campo_where;
                        cmd.CommandText = _Str_Sql;
                        // Creando los parámetros necesarios
                        cmd.Parameters.Add("@" + _Str_ImgCampos[I].ToString(), System.Data.SqlDbType.Image);
                        // Asignando el valor de la imagen
                        // Se guarda la imagen en el buffer
                        //_Img_Save[I].Save(ms, _Img_Save[I].RawFormat);
                        _Img_Save[I].Save(ms, _Img_Save[I].RawFormat);
                        // Se extraen los bytes del buffer para asignarlos como valor para el 
                        // parámetro.
                        cmd.Parameters["@" + _Str_ImgCampos[I].ToString()].Value = ms.GetBuffer();
                        cmd.ExecuteNonQuery();
                    }
                    I++;
                }
            }
            conn.Close();
            cmd.Dispose();
            conn.Dispose();
        }

        private void _Bt_cerrar_sesion_Click(object sender, EventArgs e)
        {
            Form _Frm = this.FindForm();
            ((Frm_Padre)_Frm)._Bol_Cerrar = false;
            _Frm.Close();
            Cursor = Cursors.WaitCursor;
            //new CLASES._Cls_Varios_Metodos(true)._Mtd_Cerrar_T3_Popup("T3BUGS");
            _Mtd_EliminarUsuarioRestric(Frm_Padre._Str_Use);
            Cursor = Cursors.Default;
            ((Frm_Padre)_Frm)._Frm_Security.Show();
        }
        private string _Mtd_ObtenerIP()
        {
            //return System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[0].ToString().Trim();
            string _Str_Host = System.Net.Dns.GetHostName();
            string _Str_IP = "";

            for (int i = 0; i <= System.Net.Dns.GetHostEntry(_Str_Host).AddressList.Length - 1; i++)
            {
                _Str_IP = System.Net.Dns.GetHostEntry(_Str_Host).AddressList[i].ToString();

                // primero evalua si existe un IP estandar de la red SODICA
                if (_Str_IP.IndexOf("192.168.0.") != -1) return _Str_IP; // denca
                if (_Str_IP.IndexOf("192.168.1.") != -1) return _Str_IP; // conssa
                if (_Str_IP.IndexOf("192.168.2.") != -1) return _Str_IP; // mcy
                if (_Str_IP.IndexOf("192.168.3.") != -1) return _Str_IP; // mcbo
                if (_Str_IP.IndexOf("192.168.4.") != -1) return _Str_IP; // scb
                if (_Str_IP.IndexOf("192.168.5.") != -1) return _Str_IP; // pzo
                if (_Str_IP.IndexOf("192.168.6.") != -1) return _Str_IP; // bna
                if (_Str_IP.IndexOf("192.168.7.") != -1) return _Str_IP; // val
                if (_Str_IP.IndexOf("192.168.8.") != -1) return _Str_IP; // bqto
                if (_Str_IP.IndexOf("192.168.9.") != -1) return _Str_IP; // ccs
                if (_Str_IP.IndexOf("192.168.10.") != -1) return _Str_IP; // bnas

                if (_Str_IP.IndexOf("192.168.11.") != -1) return _Str_IP; // ¿futuro?
                if (_Str_IP.IndexOf("192.168.12.") != -1) return _Str_IP; // ¿futuro?
                if (_Str_IP.IndexOf("192.168.13.") != -1) return _Str_IP; // ¿futuro?
                if (_Str_IP.IndexOf("192.168.14.") != -1) return _Str_IP; // ¿futuro?
                if (_Str_IP.IndexOf("192.168.15.") != -1) return _Str_IP; // ¿futuro?
            }

            // si no encuentra un IP estándar, entonces devuelve el primero que no sea IPV6
            for (int i = 0; i <= System.Net.Dns.GetHostEntry(_Str_Host).AddressList.Length - 1; i++)
            {
                if (System.Net.Dns.GetHostEntry(_Str_Host).AddressList[i].IsIPv6LinkLocal == false)
                {
                    _Str_IP = System.Net.Dns.GetHostEntry(_Str_Host).AddressList[i].ToString();
                }
            }

            return _Str_IP;
        }

        private void _Mtd_EliminarUsuarioRestric(string _Str_User)
        {
            try
            {
                if (!Frm_Padre._Bol_ClaveMaestra)
                {
                    string _Str_SQL = "DELETE FROM TUSERONLINE WHERE CUSER='" + _Str_User + "' AND CIP='" + _Mtd_ObtenerIP() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                }
            }
            catch
            {
            }
        }
        private delegate void UpdateStatusDelegate();
        private void DoUpdate()
        {
            if (this.InvokeRequired)
            {
                // we were called on a worker thread
                // marshal the call to the user interface thread
                this.Invoke(new UpdateStatusDelegate(DoUpdate));
                return;
            }
            string _Str_Titulo = _frm_Formulario.Text;
            // this code can only be reached
            // by the user interface thread
            if (_Bl_Modifi)
            {
                Cursor = Cursors.WaitCursor;
                _frm_Formulario.Text = _frm_Formulario.Text + " Procesando...";
                if ((bool)(_frm_Formulario.GetType().GetMethod("_Mtd_Editar").Invoke(_frm_Formulario, null)))
                {
                    _Txt_Editando.Text = "";
                    _Bl_Modifi = false;
                    _Bt_editar2.Enabled = false;
                    _Bt_borrar2.Enabled = false;
                    _Bt_guardar2.Enabled = false;
                    try
                    { _frm_Formulario.GetType().GetMethod("_Mtd_BotonesMenu").Invoke(_frm_Formulario, null); }
                    catch
                    { }
                }
                ((Frm_Padre)this.FindForm())._Pnl_Espera.Visible = false;
                _frm_Formulario.Text = _Str_Titulo;
                Cursor = Cursors.Default;
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                _frm_Formulario.Text = _frm_Formulario.Text + " Procesando...";
                if ((bool)(_frm_Formulario.GetType().GetMethod("_Mtd_Guardar").Invoke(_frm_Formulario, null)))
                {
                    Cursor = Cursors.WaitCursor;
                    _Txt_Editando.Text = "";
                    _Bl_Modifi = false;
                    _Bt_editar2.Enabled = false;
                    _Bt_borrar2.Enabled = false;
                    _Bt_guardar2.Enabled = false;
                    try
                    { _frm_Formulario.GetType().GetMethod("_Mtd_BotonesMenu").Invoke(_frm_Formulario, null); }
                    catch
                    { }
                }
                ((Frm_Padre)this.FindForm())._Pnl_Espera.Visible = false;
                _frm_Formulario.Text = _Str_Titulo;
                Cursor = Cursors.Default;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (((Frm_Padre)this.FindForm())._Frm_Contenedor.Visible)
            { ((Frm_Padre)this.FindForm())._Frm_Contenedor.Hide(); }
            else
            { ((Frm_Padre)this.FindForm())._Frm_Contenedor.Show(); }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            _Ctrl_Comp _Ctrl_Com = new _Ctrl_Comp();
        }
    }
}