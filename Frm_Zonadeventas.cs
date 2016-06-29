using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Zonadeventas : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        string _Str_MyProceso = "";
        public Frm_Zonadeventas()
        {
            InitializeComponent();
            if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
            {
                _Mtd_Cargar_Información(Frm_Padre._Str_Use);
            }
            else
            {
                _Mtd_Cargar_Información();
            }
        }
        public Frm_Zonadeventas(string _P_Str_Zona,string _P_Str_Descripcion,string _P_Str_Grupo)
        {
            InitializeComponent();
            if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
            {
                _Mtd_Cargar_Información(Frm_Padre._Str_Use);
            }
            else
            {
                _Mtd_Cargar_Información();
            }
            _Er_Error.Dispose();
            _Mtd_Deshabilitar_Todo();
            _Txt_Codigo.Text = _P_Str_Zona;
            _Txt_Descripcion.Text = _P_Str_Descripcion;
            _Cmb_Grupo.SelectedValue = _P_Str_Grupo;
            _Bt_Clientes.Enabled = true;
            _Bt_Vendedores.Enabled = true;
            if (_Cmb_Grupo.SelectedIndex > 0)
            {
                string _Str_Cadena = "Select cestate from TZONAVENTAD where c_zona='" + _Txt_Codigo.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cgrupovta='" + _Cmb_Grupo.SelectedValue.ToString() + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                foreach (DataRow _Drow in _Ds.Tables[0].Rows)
                {
                    for (int _I = 0; _I < _Clis_Estados.Items.Count; _I++)
                    {
                        if (((Clases._Cls_ArrayList)_Clis_Estados.Items[_I]).Value == _Drow[0].ToString())
                        {
                            _Clis_Estados.SetItemChecked(_I, true);
                        }
                    }
                }
                _Mtd_Seleccionar_Municipios();
                _Mtd_Cargar_Parroquia();
                _Mtd_Seleccionar_Parroquias();
            }
            _Tb_Tab.SelectedIndex = 1;
        }
        Control[] _Ctrl_Controles = new Control[3];
        private void Frm_Zonadeventas_Load(object sender, EventArgs e)
        {

        }
        private void _Mtd_Cargar_Información()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            _Tsm_Menu[2] = new ToolStripMenuItem("Grupo de Vta.");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "c_zona";
            _Str_Campos[1] = "c_zona_name";
            _Str_Campos[2] = "cgrupovta_name";
            string _Str_Cadena = "SELECT c_zona AS Código, RTRIM(c_zona_name) AS Descripción, RTRIM(cgrupovta_name) AS [Grupo de Vta.], cgrupovta " +
"FROM VST_GRUPOVTA_ZONAVTA " +
"WHERE c_zona_cdelete = 0 AND cgrupovta_cdelete=0 AND ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Zonas de Venta", _Tsm_Menu, _Dg_Grid,true,"");
            //___________________________________
            _Mtd_Actualizar();
            _Mtd_Cargar_Cmb_Estado();
            _Mtd_Cargar_Cmb_Grupo();
        }
        private void _Mtd_Cargar_Información(string _Pr_Str_Gerente)
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            _Tsm_Menu[2] = new ToolStripMenuItem("Grupo de Vta.");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "c_zona";
            _Str_Campos[1] = "c_zona_name";
            _Str_Campos[2] = "cgrupovta_name";
            string _Str_Cadena = "SELECT c_zona AS Código, RTRIM(c_zona_name) AS Descripción, RTRIM(cgrupovta_name) AS [Grupo de Vta.], cgrupovta " +
"FROM VST_GRUPOVTA_ZONAVTA " +
"WHERE c_zona_cdelete = 0 AND cgrupovta_cdelete=0 AND ccompany='" + Frm_Padre._Str_Comp + "' AND cgerarea='" + _Pr_Str_Gerente + "'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Zonas de Venta", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            _Mtd_Actualizar(_Pr_Str_Gerente);
            _Mtd_Cargar_Cmb_Estado();
            _Mtd_Cargar_Cmb_Grupo();
        }
        private void _Mtd_Actualizar()
        {
            string _Str_Cadena = "SELECT DISTINCT c_zona AS Código, RTRIM(c_zona_name) AS Descripción, RTRIM(cgrupovta_name) AS [Grupo de Vta.], cgrupovta " +
"FROM VST_GRUPOVTA_ZONAVTA " +
"WHERE c_zona_cdelete = 0 AND cgrupovta_cdelete=0 AND ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Actualizar(string _Pr_Str_Gerente)
        {
            string _Str_Cadena = "SELECT DISTINCT c_zona AS Código, RTRIM(c_zona_name) AS Descripción, RTRIM(cgrupovta_name) AS [Grupo de Vta.], cgrupovta " +
"FROM VST_GRUPOVTA_ZONAVTA " +
"WHERE c_zona_cdelete = 0 AND cgrupovta_cdelete=0 AND ccompany='" + Frm_Padre._Str_Comp + "' AND cgerarea='" + _Pr_Str_Gerente + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Cargar_Cmb_Grupo()
        {
            //--------------------------------------
            string _Str_Sql = "SELECT DISTINCT TGRUPOVTAM.cgrupovta, TGRUPOVTAM.cname " +
 "FROM TGRUPPROVEE INNER JOIN " +
 "TGRUPOVTAM ON TGRUPPROVEE.cgrupovta = TGRUPOVTAM.cgrupovta " +
 "WHERE (TGRUPOVTAM.cdelete = 0) AND (TGRUPPROVEE.ccompany = '" + Frm_Padre._Str_Comp + "') AND NOT(TGRUPOVTAM.cname is null) " +
 "ORDER BY TGRUPOVTAM.cname";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Grupo, _Str_Sql);
        }
        private void _Mtd_Cargar_Cmb_Estado()
        {
            _myUtilidad._Mtd_CargarCheckList(_Clis_Estados, "Select cestate,UPPER(cname) as cname from TESTATE where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' ORDER BY cname ASC");
        }
        public void _Mtd_Cancelar()
        {
            _Mtd_Ini();
            _Mtd_Deshabilitar_Todo();
        }
        public void _Mtd_Ini()
        {
            _Str_MyProceso ="";
            _Txt_Codigo.Text = "";
            _Txt_Descripcion.Text = "";
            _Clis_Municipios.Items.Clear();
            _Clis_Parroquias.Items.Clear();
            _Rb_QuitMu.Checked = false;
            _Rb_QuitPa.Checked = false;
            _Rb_SelcMu.Checked = false;
            _Rb_SelcPa.Checked = false;
            //_Mtd_Cargar_Cmb_Estado();
            _Clis_Estados.DataSource = null;
            _Mtd_Cargar_Cmb_Grupo();

            _Txt_Descripcion.Enabled = true;
            _Cmb_Grupo.Enabled = false;
            _Grb_1.Enabled = true;
            _Grb_2.Enabled = true;
            _Clis_Municipios.Enabled = true;
            _Clis_Parroquias.Enabled = true;

            _Clis_Estados.Enabled = false;
            _Txt_Codigo.Enabled = true;
            _Cmb_Grupo.Enabled = true;
            _Bt_Clientes.Enabled = false;
            _Bt_Vendedores.Enabled = false;
        }
        public void _Mtd_Habilitar()
        {
            _Str_MyProceso = "M";
            _Txt_Codigo.Enabled = false;
            _Txt_Descripcion.Enabled = true;
            _Cmb_Grupo.Enabled = false;
            _Grb_1.Enabled = true;
            _Grb_2.Enabled = true;
            _Clis_Municipios.Enabled = true;
            _Clis_Parroquias.Enabled = true;
            _Clis_Estados.Enabled = true;
            //_Cmb_Ciudad.Enabled = true;
        }

        private void _Cmb_Grupo_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Cmb_Grupo();
        }

        private void Frm_Zonadeventas_Activated(object sender, EventArgs e)
        {
            _Ctrl_Controles[0] = _Txt_Codigo;
            _Ctrl_Controles[1] = _Txt_Descripcion;
            _Ctrl_Controles[2] = _Cmb_Grupo;
            CONTROLES._Ctrl_Buscar._Txt_TpoFind.Text = "PA";
            CONTROLES._Ctrl_Buscar._Ctrl_Controles = _Ctrl_Controles;
            CONTROLES._Ctrl_Buscar._Er_Control_Error = _Er_Error;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CLASES._Cls_Varios_Metodos _Cls_CL = new T3.CLASES._Cls_Varios_Metodos(_Ctrl_Controles);
            _Cls_CL._Mtd_Foco();
            //____________________________________________
            if (!_Txt_Descripcion.Enabled & _Txt_Descripcion.Text.Trim().Length > 0)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
            }
            else if (!_Txt_Codigo.Enabled & _Txt_Codigo.Text.Trim().Length > 0 & _Txt_Descripcion.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
            }
            else if (_Txt_Codigo.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            }
            //_____________________________________________
        }

        private void Frm_Zonadeventas_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        public void _Mtd_Nuevo()
        {
            _Er_Error.Dispose();
            _Mtd_Ini();
            
            _Tb_Tab.SelectedIndex = 1;
            _Cmb_Grupo.Focus();
            _Str_MyProceso = "N";
            _Rb_QuitMu.Enabled = false;
            _Rb_QuitPa.Enabled = false;
            _Rb_SelcMu.Enabled = false;
            _Rb_SelcPa.Enabled = false;
        }
        private void _Mtd_Deshabilitar_Todo()
        {
            _Txt_Codigo.Enabled = false;
            _Txt_Descripcion.Enabled = false;
            _Cmb_Grupo.Enabled = false;
            _Grb_1.Enabled = false;
            _Grb_2.Enabled = false;
            _Clis_Municipios.Enabled = false;
            _Clis_Parroquias.Enabled = false;
            _Clis_Estados.Enabled = false;
            _Bt_Clientes.Enabled = false;
            _Bt_Vendedores.Enabled = false;
        }
        public bool _Mtd_Guardar()
        {
            bool _Bol_Validar = false;
            if (_Cmb_Grupo.SelectedIndex > 0)
            { _Mtd_Entrada(_Cmb_Grupo.SelectedValue.ToString().Trim()); }
            else
            { _Txt_Codigo.Text = ""; }
            foreach (object _ob in _Clis_Parroquias.CheckedItems)
            {
                _Bol_Validar = true;
            }
            if (_Txt_Codigo.Text.Trim().Length > 0 & _Txt_Descripcion.Text.Trim().Length > 0 & _Cmb_Grupo.SelectedIndex > 0 & _Bol_Validar & _Clis_Estados.CheckedItems.Count > 0)
            {
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TZONAVENTA where c_zona='" + _Txt_Codigo.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cgrupovta='" + _Cmb_Grupo.SelectedValue.ToString() + "'"))
                {
                    MessageBox.Show("El registro ya existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    string _Str_Cadena = "insert into TZONAVENTA (c_zona,ccompany,cname,cgrupovta,cdateadd,cuseradd,cdelete) values('" + _Txt_Codigo.Text.Trim().ToUpper() + "','" + Frm_Padre._Str_Comp + "','" + _Txt_Descripcion.Text.Trim().ToUpper() + "','" + _Cmb_Grupo.SelectedValue.ToString().Trim() + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Mtd_Guardar_Items();
                    MessageBox.Show("El registro fue agregado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
                    {
                        _Mtd_Actualizar(Frm_Padre._Str_Use);
                    }
                    else
                    {
                        _Mtd_Actualizar();
                    }
                    _Mtd_Ini();
                    _Mtd_Deshabilitar_Todo();
                    _Tb_Tab.SelectedIndex = 0;
                    _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    _Er_Error.Dispose();
                    return true;
                }
            }
            else
            {
                if (_Txt_Codigo.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Codigo, "Información requerida!!!"); }
                if (_Txt_Descripcion.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Descripcion, "Información requerida!!!"); }
                if (_Cmb_Grupo.SelectedIndex < 1) { _Er_Error.SetError(_Cmb_Grupo, "Información requerida!!!"); }
                if (_Clis_Estados.CheckedItems.Count == 0) { _Er_Error.SetError(_Clis_Estados, "Información requerida!!!"); }
                if (!_Bol_Validar) { _Er_Error.SetError(_Clis_Parroquias, "Información requerida!!!"); }
                return false;
            }
        }
        public bool _Mtd_Editar()
        {
            bool _Bol_Validar = false;
            foreach (object _ob in _Clis_Parroquias.CheckedItems)
            {
                _Bol_Validar = true;
            }
            if (_Txt_Codigo.Text.Trim().Length > 0 & _Txt_Descripcion.Text.Trim().Length > 0 & _Cmb_Grupo.SelectedIndex > 0 & _Bol_Validar & _Clis_Estados.CheckedItems.Count > 0)
            {
                string _Str_Cadena = "UPDATE TZONAVENTA Set c_zona='" + _Txt_Codigo.Text.Trim().ToUpper() + "',ccompany='" + Frm_Padre._Str_Comp + "',cgrupovta='" + _Cmb_Grupo.SelectedValue.ToString().Trim() + "',cname='" + _Txt_Descripcion.Text.Trim().ToUpper() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0' where c_zona='" + _Txt_Codigo.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Mtd_Guardar_Items();
                MessageBox.Show("El registro fue modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
                {
                    _Mtd_Actualizar(Frm_Padre._Str_Use);
                }
                else
                {
                    _Mtd_Actualizar();
                }
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
                _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Er_Error.Dispose();
                return true;
            }
            else
            {
                if (_Txt_Codigo.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Codigo, "In   formación requerida!!!"); }
                if (_Txt_Descripcion.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Descripcion, "Información requerida!!!"); }
                if (_Cmb_Grupo.SelectedIndex < 1) { _Er_Error.SetError(_Cmb_Grupo, "Información requerida!!!"); }
                if (_Clis_Estados.CheckedItems.Count == 0) { _Er_Error.SetError(_Clis_Estados, "Información requerida!!!"); }
                //if (_Cmb_Ciudad.SelectedIndex < 1) { _Er_Error.SetError(_Cmb_Ciudad, "Información requerida!!!"); }
                if (!_Bol_Validar) { _Er_Error.SetError(_Clis_Parroquias, "Iformación requerida!!!"); }
                return false;
            }
        }
        public bool _Mtd_Eliminar()
        {
            bool _Bol_Vendedores = false;
            bool _Bol_Clientes = false;
            //____________________________________________
            string _Str_Cadena = "Select * from TZONAVENDEDOR where c_zona='" + _Txt_Codigo.Text.Trim() + "' and ccompany='"+Frm_Padre._Str_Comp+"'";
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
            { _Bol_Vendedores = true; }
            _Str_Cadena = "Select * from TZONACLIENTE where c_zona='" + _Txt_Codigo.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
            { _Bol_Clientes = true; }
            //____________________________________________
            if (_Bol_Clientes & !_Bol_Vendedores)
            { MessageBox.Show("No se puede eliminar esta zona porque tiene clientes asignados","Información",MessageBoxButtons.OK,MessageBoxIcon.Stop); }
            else if (!_Bol_Clientes & _Bol_Vendedores)
            { MessageBox.Show("No se puede eliminar esta zona porque tiene vendedores asignados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
            else if (_Bol_Clientes & _Bol_Vendedores)
            { MessageBox.Show("No se puede eliminar esta zona porque tiene clientes y vendedores asignados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
            else if (!_Bol_Clientes & !_Bol_Vendedores)
            {
                DialogResult eli = MessageBox.Show("Esta seguro de Eliminar el registro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (eli == DialogResult.Yes)
                {
                    _Str_Cadena = "UPDATE TZONAVENTA Set cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' where c_zona='" + _Txt_Codigo.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    MessageBox.Show("El registro fue eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
                    {
                        _Mtd_Actualizar(Frm_Padre._Str_Use);
                    }
                    else
                    {
                        _Mtd_Actualizar();
                    }
                    _Mtd_Ini();
                    _Mtd_Deshabilitar_Todo();
                    _Tb_Tab.SelectedIndex = 0;
                }
                else
                {
                    if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
                    {
                        _Mtd_Actualizar(Frm_Padre._Str_Use);
                    }
                    else
                    {
                        _Mtd_Actualizar();
                    }
                    _Mtd_Ini();
                    _Mtd_Deshabilitar_Todo();
                    _Tb_Tab.SelectedIndex = 0;
                }
            }
            if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
            {
                _Mtd_Actualizar(Frm_Padre._Str_Use);
            }
            else
            {
                _Mtd_Actualizar();
            }
            _Mtd_Ini();
            _Mtd_Deshabilitar_Todo();
            _Tb_Tab.SelectedIndex = 0;
            return true;
        }
        private void _Mtd_Cargar_Municipio(string _Pr_Str_Estate, bool _Pr_Bol_Sw)
        {
            bool _Bol_SwOmitir = false;
            string _Str_EstadoOmit = "";
            string _Str_Filtro = "";
            _Clis_Municipios.Items.Clear();
            foreach (object _MyObjEstate in _Clis_Estados.CheckedItems)
            {
                _Bol_SwOmitir = false;
                if (_Pr_Str_Estate.Length > 0)
                {
                    if (!_Pr_Bol_Sw)
                    {//OMITO ESTADO
                        if (((Clases._Cls_ArrayList)_MyObjEstate).Value == _Pr_Str_Estate)
                        {
                            _Bol_SwOmitir = true;
                        }
                    }
                }
                if (!_Bol_SwOmitir)
                {
                    _Str_Filtro = _Str_Filtro + "cestate='" + ((Clases._Cls_ArrayList)_MyObjEstate).Value + "' OR ";
                }
            }
            if (_Str_Filtro.Length > 0 || (_Pr_Str_Estate.Length > 0 && _Pr_Bol_Sw))
            {
                if (_Pr_Str_Estate.Length > 0 && _Pr_Bol_Sw)
                {
                    _Str_Filtro = _Str_Filtro + "cestate='" + _Pr_Str_Estate + "' OR ";
                }
                else
                {
 
                }
                _Str_Filtro = _Str_Filtro.Substring(0, _Str_Filtro.Length - 4);
                string _Str_Cadena = "Select cmunicipio,cname from TMUNICIPIO where cdelete='0' and (" + _Str_Filtro + ") ORDER BY cname ASC";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Clis_Municipios.Items.Add(_Row[0].ToString().Trim() + "-" + _Row[1].ToString().Trim());
                }
            }
        }
        private int _Mtd_Extraer_Codigo2(string _P_Str_Items)
        {
            int _Int_i = _P_Str_Items.Trim().IndexOf("-");
            return Convert.ToInt32(_P_Str_Items.Trim().Substring(_Int_i + 1).Trim());
        }
        private string _Mtd_Extraer_Codigo(string _P_Str_Items)
        {
            int _Int_i = _P_Str_Items.Trim().IndexOf("-");
            return _P_Str_Items.Trim().Substring(0, _Int_i).Trim();
        }
        private void _Mtd_Cargar_Parroquia()
        {
            _Clis_Parroquias.Items.Clear();
            foreach (object _Ob in _Clis_Municipios.CheckedItems)
            {
                string _Str_Clave = _Mtd_Extraer_Codigo(_Ob.ToString());
                string _Str_Cadena = "Select cparroquia,cname from TPARROQUIA where cdelete='0' and cmunicipio='" + _Str_Clave + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Clis_Parroquias.Items.Add(_Ob.ToString() + ">>>" + _Row[0].ToString().Trim() + "-" + _Row[1].ToString().Trim());
                }
            }
        }
        private string _Mtd_Extraer_Segundo_Codigo(string _P_Str_Items)
        {
            int _Int_i = _P_Str_Items.Trim().IndexOf(">>>");
            _P_Str_Items = _P_Str_Items.Trim().Substring(_Int_i).Trim();
            _Int_i = _P_Str_Items.Trim().IndexOf("-");
            return _P_Str_Items.Trim().Substring(3, _Int_i-3).Trim();
        }
        private void _Mtd_Guardar_Items()
        {
            if (_Cmb_Grupo.SelectedIndex > 0)
            {
                DataSet _Ds;
                string _Str_Estado = "null";
                string _Str_Cadena = "Delete from TZONAVENTAD where c_zona='" + _Txt_Codigo.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cgrupovta='" + _Cmb_Grupo.SelectedValue.ToString() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                foreach (object _Ob in _Clis_Parroquias.CheckedItems)
                {
                    
                    string _Str_Municipio = _Mtd_Extraer_Codigo(_Ob.ToString());
                    string _Str_Parroquia = _Mtd_Extraer_Segundo_Codigo(_Ob.ToString());
                    _Str_Cadena = "SELECT cestate FROM TMUNICIPIO WHERE cmunicipio='" + _Str_Municipio + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_Estado = "'" + _Ds.Tables[0].Rows[0][0].ToString() + "'";
                    }
                    _Str_Cadena = "insert into TZONAVENTAD (c_zona,ccompany,cgrupovta,cestate,cmunicipio,cparroquia) values('" + _Txt_Codigo.Text.Trim().ToUpper() + "','" + Frm_Padre._Str_Comp + "','" + _Cmb_Grupo.SelectedValue.ToString() + "'," + _Str_Estado + ",'" + _Str_Municipio + "','" + _Str_Parroquia + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
            }
        }
        private void _Mtd_Seleccionar_Municipios()
        {
            string _Str_Cadena = "Select DISTINCT cmunicipio from TZONAVENTAD where c_zona='" + _Txt_Codigo.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cgrupovta='"+_Cmb_Grupo.SelectedValue.ToString()+"'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                for (int _Int_I = 0; _Int_I <= _Clis_Municipios.Items.Count-1; _Int_I++)
                {
                    if (_Row[0].ToString().Trim() == _Mtd_Extraer_Codigo(_Clis_Municipios.Items[_Int_I].ToString()))
                    {
                        _Clis_Municipios.SetItemChecked(_Int_I, true);
                    }
                }
            }
        }
        private void _Mtd_Seleccionar_Parroquias()
        {
            string _Str_Cadena = "Select cmunicipio,cparroquia from TZONAVENTAD where c_zona='" + _Txt_Codigo.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cgrupovta='" + _Cmb_Grupo.SelectedValue.ToString() + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                for (int _Int_I = 0; _Int_I <= _Clis_Parroquias.Items.Count-1; _Int_I++)
                {
                    if (_Row[0].ToString().Trim() == _Mtd_Extraer_Codigo(_Clis_Parroquias.Items[_Int_I].ToString()) & _Row[1].ToString().Trim() == _Mtd_Extraer_Segundo_Codigo(_Clis_Parroquias.Items[_Int_I].ToString()))
                    {
                        _Clis_Parroquias.SetItemChecked(_Int_I, true);
                    }
                }
            }
        }

        private void _Rb_SelcMu_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_SelcMu.Checked)
            {
                _Mtd_Cargar_Municipio("",false);
                for (int _Int_I = 0; _Int_I <= _Clis_Municipios.Items.Count-1; _Int_I++)
                {
                    _Clis_Municipios.SetItemChecked(_Int_I, true);
                }
                _Mtd_Cargar_Parroquia();
                _Mtd_Seleccionar_Parroquias();
            }
        }

        private void _Rb_QuitMu_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_QuitMu.Checked)
            {
                _Mtd_Cargar_Municipio("",false);
                _Mtd_Seleccionar_Municipios();
                _Mtd_Cargar_Parroquia();
                _Mtd_Seleccionar_Parroquias();
            }
        }

        private void _Rb_SelcPa_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_SelcPa.Checked)
            {
                _Mtd_Cargar_Parroquia();
                for (int _Int_I = 0; _Int_I <= _Clis_Parroquias.Items.Count-1; _Int_I++)
                {
                    _Clis_Parroquias.SetItemChecked(_Int_I, true);
                }
            }
        }

        private void _Rb_QuitPa_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_QuitPa.Checked)
            {
                _Mtd_Cargar_Parroquia();
                _Mtd_Seleccionar_Parroquias();
            }
        }

        private void _Bt_Agregar_Click(object sender, EventArgs e)
        {
            _Mtd_Cargar_Parroquia();
            _Mtd_Seleccionar_Parroquias();
        }

        public void _Mtd_Entrada(string _P_Str_Grupo)
        {
            string _St_Cadena = "SELECT c_zona FROM TZONAVENTA where ccompany='" + Frm_Padre._Str_Comp + "' and cgrupovta='" + _P_Str_Grupo + "' and c_zona LIKE ('%-%')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_St_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                bool _Bol_B = true;
                int _Int_Codigo = 0;
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    if (_Bol_B)
                    { _Int_Codigo = _Mtd_Extraer_Codigo2(_Row[0].ToString()); }
                    if (_Mtd_Extraer_Codigo2(_Row[0].ToString()) > _Int_Codigo)
                    { _Int_Codigo = _Mtd_Extraer_Codigo2(_Row[0].ToString()); }
                }
                _Int_Codigo++;
                if (_Int_Codigo < 10)
                { _Txt_Codigo.Text = _P_Str_Grupo + "-0" + _Int_Codigo.ToString(); }
                else
                { _Txt_Codigo.Text = _P_Str_Grupo + "-" + _Int_Codigo.ToString(); }
            }
            else
            { _Txt_Codigo.Text = _P_Str_Grupo + "-01"; }

        }

        private void _Pnl_Grupo_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Grupo.Visible)
            { _Tb_Tab.Enabled = false; _Er_Error.Dispose(); _Txt_Descripcion_Copiar.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[1].Value.ToString().Trim(); _Mtd_Cargar_Copiar(); _Cmb_Grupo_Copiar.SelectedIndex=0; _Cmb_Grupo_Copiar.Focus(); }
            else
            { _Tb_Tab.Enabled = true;}
        }

        private void copiarZonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Pnl_Grupo.Visible = true;
        }
        private void _Mtd_Cargar_Copiar()
        {
            _myUtilidad._Mtd_CargarCombo(_Cmb_Grupo_Copiar, "SELECT cgrupovta,UPPER(cname) as cname FROM TGRUPOVTAM where cgrupovta<>'" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString().Trim() + "' and cdelete='0' ORDER BY cname ASC");
        }
        public string _Mtd_Entrada_Copiar(string _P_Str_Grupo)
        {
            string _St_Cadena = "SELECT c_zona FROM TZONAVENTA where ccompany='" + Frm_Padre._Str_Comp + "' and cgrupovta='" + _P_Str_Grupo + "' and c_zona LIKE ('%-%')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_St_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                bool _Bol_B = true;
                int _Int_Codigo = 0;
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    if (_Bol_B)
                    { _Int_Codigo = _Mtd_Extraer_Codigo2(_Row[0].ToString()); }
                    if (_Mtd_Extraer_Codigo2(_Row[0].ToString()) > _Int_Codigo)
                    { _Int_Codigo = _Mtd_Extraer_Codigo2(_Row[0].ToString()); }
                }
                _Int_Codigo++;
                if (_Int_Codigo < 10)
                { return _P_Str_Grupo + "-0" + _Int_Codigo.ToString(); }
                else
                { return  _P_Str_Grupo + "-" + _Int_Codigo.ToString(); }
            }
            else
            { return  _P_Str_Grupo + "-01"; }

        }
        private void _Cmb_Grupo_Copiar_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Copiar();
        }
        private void _Mtd_Copiar(string _P_Str_Zona, string _P_Str_Zona_Creada, string _P_Str_Grupo, string _P_Str_Grupo_Nuevo, string _P_Str_Descrpcion)
        {
            string _Str_Cadena = "insert into TZONAVENTA (c_zona,ccompany,cname,cgrupovta,cdateadd,cuseradd,cdelete) values('" + _P_Str_Zona_Creada + "','" + Frm_Padre._Str_Comp + "','" + _P_Str_Descrpcion + "','" + _P_Str_Grupo_Nuevo + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "Select cestate,ccity,cmunicipio,cparroquia from TZONAVENTAD where c_zona='" + _P_Str_Zona + "' and cgrupovta='" + _P_Str_Grupo + "' and ccompany='"+Frm_Padre._Str_Comp+"'";
            DataSet _Ds=Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_Cadena = "insert into TZONAVENTAD (c_zona,ccompany,cgrupovta,cestate,ccity,cmunicipio,cparroquia) values('" + _P_Str_Zona_Creada + "','" + Frm_Padre._Str_Comp + "','" + _P_Str_Grupo_Nuevo + "','" + _Row["cestate"].ToString() + "','" + _Row["ccity"].ToString() + "','" + _Row["cmunicipio"].ToString() + "','" + _Row["cparroquia"].ToString() + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
        }
        private void _Bt_Copiar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (_Cmb_Grupo_Copiar.SelectedIndex > 0)
            {
                string _Str_Codigo=_Mtd_Entrada_Copiar(_Cmb_Grupo_Copiar.SelectedValue.ToString().Trim());
                _Mtd_Copiar(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim(), _Str_Codigo, _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString().Trim(), _Cmb_Grupo_Copiar.SelectedValue.ToString().Trim(), _Txt_Descripcion_Copiar.Text.Trim());
                if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
                {
                    _Mtd_Actualizar(Frm_Padre._Str_Use);
                }
                else
                {
                    _Mtd_Actualizar();
                }
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Pnl_Grupo.Visible = false;
                MessageBox.Show("La zona fue copiada con el código " + _Str_Codigo,"Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                if (_Cmb_Grupo_Copiar.SelectedIndex < 1) { _Er_Error.SetError(_Cmb_Grupo_Copiar, "Información requerida!!!"); }
                if (_Txt_Descripcion_Copiar.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Descripcion_Copiar, "Información requerida!!!"); }
            }
            Cursor = Cursors.Default;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Grid.Rows.Count == 0)
            { contextMenuStrip1.Hide(); }
            else
            { contextMenuStrip1.Show(); }
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Grupo.Visible = false;
        }

        private void _Bt_Clientes_Click(object sender, EventArgs e)
        {
            Frm_ZonaporCliente _Frm = new Frm_ZonaporCliente(_Txt_Codigo.Text.Trim(), _Cmb_Grupo.SelectedValue.ToString().Trim());
            _Frm.MdiParent = this.MdiParent;
            _Frm.Show();
        }

        private void _Bt_Vendedores_Click(object sender, EventArgs e)
        {
            Frm_ZonaporVendedor _Frm = new Frm_ZonaporVendedor(_Txt_Codigo.Text.Trim(), _Cmb_Grupo.SelectedValue.ToString().Trim());
            _Frm.MdiParent = this.MdiParent;
            _Frm.Show();
        }

        private void _Clis_Municipios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Rb_QuitPa.Checked = false;
            _Rb_SelcPa.Checked = false;
            _Mtd_Cargar_Parroquia();
            _Mtd_Seleccionar_Parroquias();
            Cursor = Cursors.Default;
        }

        private void _Clis_Municipios_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Rb_QuitPa.Checked = false;
            _Rb_SelcPa.Checked = false;
            _Mtd_Cargar_Parroquia();
            _Mtd_Seleccionar_Parroquias();
            Cursor = Cursors.Default;
        }

        private void _Tb_Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Tb_Tab.SelectedIndex == 0)
            {
                if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
                {
                    _Mtd_Actualizar(Frm_Padre._Str_Use);
                }
                else
                {
                    _Mtd_Actualizar();
                }
            }
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_Txt_Descripcion.Text.Trim().Length == 0 & !_Txt_Descripcion.Enabled & e.TabPageIndex != 0)
            { e.Cancel = true; }
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

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Ini();
                _Er_Error.Dispose();
                _Mtd_Deshabilitar_Todo();
                _Txt_Codigo.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, _Dg_Grid.CurrentCell.RowIndex);
                _Txt_Descripcion.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, _Dg_Grid.CurrentCell.RowIndex);
                _Cmb_Grupo.SelectedValue = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, _Dg_Grid.CurrentCell.RowIndex); 
                _Mtd_Cargar_Cmb_Estado();
                string _Str_Cadena = "Select cestate from TZONAVENTAD where c_zona='" + _Txt_Codigo.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cgrupovta='" + _Cmb_Grupo.SelectedValue.ToString() + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                foreach (DataRow _Drow in _Ds.Tables[0].Rows)
                {
                    for (int _I=0; _I < _Clis_Estados.Items.Count;_I++)
                    {
                        if (_Drow["cestate"].ToString().Trim() == ((Clases._Cls_ArrayList)_Clis_Estados.Items[_I]).Value.Trim())
                        {
                            _Clis_Estados.SetItemChecked(_I, true);
                        }
                    }
                }
                _Bt_Clientes.Enabled = true;
                _Bt_Vendedores.Enabled = true;
                _Mtd_Seleccionar_Municipios();
                _Mtd_Cargar_Parroquia();
                _Mtd_Seleccionar_Parroquias();
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                _Tb_Tab.SelectedIndex = 1;
                Cursor = Cursors.Default;
            }
        }

        private void _Cmb_Grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                if (_Cmb_Grupo.SelectedIndex > 0)
                {
                    _Clis_Estados.Enabled = true;
                    _Mtd_Cargar_Cmb_Estado();
                }
                else
                {
                    _Clis_Estados.Enabled = false;
                    _Clis_Estados.DataSource = null;
                    _Clis_Municipios.Items.Clear();
                    _Clis_Parroquias.Items.Clear();

                }
                _Rb_SelcMu.Checked = false;
                _Rb_QuitMu.Checked = false;
                _Rb_SelcPa.Checked = false;
                _Rb_QuitPa.Checked = false;
            }
        }

        private void _Clis_Estados_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                _Mtd_Cargar_Municipio(((Clases._Cls_ArrayList)_Clis_Estados.Items[e.Index]).Value,true);
            }
            else
            {
                _Mtd_Cargar_Municipio(((Clases._Cls_ArrayList)_Clis_Estados.Items[e.Index]).Value, false);
            }
            if (_Str_MyProceso == "M")
            {
                _Mtd_Seleccionar_Municipios();
                _Mtd_Cargar_Parroquia();
                _Mtd_Seleccionar_Parroquias();
            }
            if (_Clis_Estados.CheckedItems.Count > 0)
            {
                if (_Clis_Estados.CheckedItems.Count == 1 && e.NewValue == CheckState.Unchecked)
                {
                    _Clis_Municipios.Items.Clear();
                    _Clis_Parroquias.Items.Clear();
                    _Rb_QuitMu.Checked = false;
                    _Rb_QuitPa.Checked = false;
                    _Rb_SelcMu.Checked = false;
                    _Rb_SelcPa.Checked = false;
                    _Rb_QuitMu.Enabled = false;
                    _Rb_QuitPa.Enabled = false;
                    _Rb_SelcMu.Enabled = false;
                    _Rb_SelcPa.Enabled = false;
                }
                else if (_Clis_Estados.CheckedItems.Count == 1 && e.NewValue == CheckState.Checked)
                {
                    _Rb_QuitMu.Enabled = true;
                    //_Rb_QuitPa.Enabled = true;
                    _Rb_SelcMu.Enabled = true;
                    //_Rb_SelcPa.Enabled = true;
                }
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                _Clis_Municipios.Items.Clear();
                _Clis_Parroquias.Items.Clear();
                _Rb_QuitMu.Checked = false;
                _Rb_QuitPa.Checked = false;
                _Rb_SelcMu.Checked = false;
                _Rb_SelcPa.Checked = false;
                _Rb_QuitMu.Enabled = false;
                _Rb_QuitPa.Enabled = false;
                _Rb_SelcMu.Enabled = false;
                _Rb_SelcPa.Enabled = false;
            }
            else
            {
                _Rb_QuitMu.Enabled = true;
                //_Rb_QuitPa.Enabled = true;
                _Rb_SelcMu.Enabled = true;
                //_Rb_SelcPa.Enabled = true;
            }
        }

        private void _Clis_Parroquias_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }

        private void _Clis_Municipios_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_Clis_Municipios.CheckedItems.Count > 0)
            {
                if (_Clis_Municipios.CheckedItems.Count == 1 && e.NewValue == CheckState.Unchecked)
                {
                    _Rb_QuitPa.Checked = false;
                    _Rb_SelcPa.Checked = false;
                    _Rb_QuitPa.Enabled = false;
                    _Rb_SelcPa.Enabled = false;
                }
                else if (_Clis_Municipios.CheckedItems.Count == 1 && e.NewValue == CheckState.Checked)
                {
                    _Rb_QuitPa.Enabled = true;
                    _Rb_SelcPa.Enabled = true;
                }
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                _Rb_QuitPa.Checked = false;
                _Rb_SelcPa.Checked = false;
                _Rb_QuitPa.Enabled = false;
                _Rb_SelcPa.Enabled = false;
            }
            else
            {
                _Rb_QuitPa.Enabled = true;
                _Rb_SelcPa.Enabled = true;
            }
        }
    }
}