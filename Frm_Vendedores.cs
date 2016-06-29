using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace T3
{
    public partial class Frm_Vendedores : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_Vendedores()
        {
            InitializeComponent();
            
        }
        Control[] _Ctrl_Controles = new Control[9];
        string _Str_Clave;
        private void _Chbox_Gerente_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Gerente.Checked)
            {
                _Bt_Buscar.Enabled = false;
                _Txt_Gerente.Text = "";
                _Txt_Cod_Ger.Text = "";
            }
            else
            {
                _Bt_Buscar.Enabled = true;
            }
        }
        private void Frm_Vendedores_Load(object sender, EventArgs e)
        {
            _Pnl_Cambiar.Left = (this.Width / 2) - (_Pnl_Cambiar.Width / 2);
            _Pnl_Cambiar.Top = (this.Height / 2) - (_Pnl_Cambiar.Height / 2);
            _Pnl_ZonaOcupada.Left = (this.Width / 2) - (_Pnl_ZonaOcupada.Width / 2);
            _Pnl_ZonaOcupada.Top = (this.Height / 2) - (_Pnl_ZonaOcupada.Height / 2);
            if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
            {
                _Mtd_Actualizar_Ven(Frm_Padre._Str_Use);
            }
            else
            {
                _Mtd_Actualizar_Ven();
            }
            _Mtd_CargarGrupos();
            _Mtd_CargarPhone();
            //new CLASES._Cls_Varios_Metodos(true)._Mtd_Inyeccion_Sql(this);
            webCamCapture1.CaptureHeight = _Pbox_Imagen.Height;
            webCamCapture1.CaptureWidth = _Pbox_Imagen.Width;
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private int _Mtd_Extraer_Codigo(string _P_Str_Items)
        {
            int _Int_i = _P_Str_Items.Trim().IndexOf("_");
            return Convert.ToInt32(_P_Str_Items.Trim().Substring(_Int_i+1).Trim());
        }
        public void _Mtd_Entrada()
        {
            string _St_Cadena = "SELECT cvendedor FROM TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor LIKE ('%_%') ORDER BY cast(replace(cvendedor,rtrim(ccompany)+'_','') as integer) DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_St_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                int _Int_Codigo = _Mtd_Extraer_Codigo(_Ds.Tables[0].Rows[0][0].ToString().Trim());
                _Int_Codigo++;
                if (_Int_Codigo < 10)
                { _Txt_Codigo.Text = Frm_Padre._Str_Comp.Trim() + "_0" + _Int_Codigo.ToString(); }
                else
                { _Txt_Codigo.Text = Frm_Padre._Str_Comp.Trim() + "_" + _Int_Codigo.ToString(); }
            }
            else
            {
                _Txt_Codigo.Text = Frm_Padre._Str_Comp.Trim() + "_01";
            }
        }
        private void _Mtd_Actualizar()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cvendedor";
            _Str_Campos[1] = "cname";
            //string _Str_Cadena = "SELECT cvendedor AS Código,cname as Descripción,cgerarea,c_direccion,c_telefono,c_email,c_activo,c_tipo_vend,cgerarea,c_grupo_vta,c_telefono as Teléfono,(Select top 1 cname from TGRUPOVTAM where TGRUPOVTAM.cgrupovta=TVENDEDOR.c_grupo_vta) as  [G. Vtas] from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and c_tipo_vend='1'";
            string _Str_Cadena = "SELECT cvendedor AS Código,rtrim(cname) as Nombre,cgerarea,c_direccion,c_email,c_activo,c_tipo_vend,cgerarea,c_grupo_vta,c_telefono as Teléfono,(Select top 1 cname from TGRUPOVTAM where TGRUPOVTAM.cgrupovta=TVENDEDOR.c_grupo_vta) as  [G. Vtas],(Select top 1 c_zona from TZONAVENDEDOR where TZONAVENDEDOR.ccompany=TVENDEDOR.ccompany and TZONAVENDEDOR.cvendedor=TVENDEDOR.cvendedor AND TZONAVENDEDOR.cdelete='0') as Zona from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and c_tipo_vend='1'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //_Dg_Grid.DataSource = _Ds.Tables[0];
            int _Int_I = 0;
            foreach (DataGridViewColumn _Col in _Dg_Grid.Columns)
            {
                if (_Int_I > 1)
                {
                    _Col.Visible = false;
                }
                _Int_I++;
            }
            _Dg_Grid.Columns[9].Visible = false;
            _Dg_Grid.Columns[10].Visible = true;
            _Dg_Grid.Columns[11].Visible = true;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //_Mtd_Cargar();
        }

        private void Frm_Vendedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            webCamCapture1.Stop();
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        private void webCamCapture1_ImageCaptured(object source, WebCam_Capture.WebcamEventArgs e)
        {
            _Pbox_Imagen.Image = e.WebCamImage;
        }
        string _Str_Nombre_G = "";
        string _Str_Apellido_G = "";
        bool _Bol_Activo = false;
        private void _Dg_Grid_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void _Bt_Ini_Click(object sender, EventArgs e)
        {
            webCamCapture1.TimeToCapture_milliseconds = 10;
            webCamCapture1.Start(0);
        }

        private void _Bt_Det_Click(object sender, EventArgs e)
        {
            webCamCapture1.Stop();
        }
        public void _Mtd_Cancelar()
        {
            _Mtd_Ini();
            _Mtd_Deshabilitar_Todo();
        }
        public void _Mtd_Ini()
        {
            _Txt_Codigo.Text = "";
            _Txt_Direccion.Text = "";
            _Txt_Email.Text = "";
            _Txt_Gerente.Text = "";
            _Txt_Nombre.Text = "";
            _Txt_Telefono.Text = "";
            _Txt_Cod_Ger.Text = "";
            _Str_Apellido_G = "";
            _Str_Nombre_G = "";
            _Txt_Apellido.Text = "";
            _Txt_Cedula.Text = "";
            _Txt_Zona.Text = "";
            _Cmb_Grupo.SelectedIndex = -1;
            _Cb_Phone.SelectedIndex = 0;
            _Chbox_Activo.Checked = false;
            _Pbox_Imagen.Image = null;
            _Mtd_Habilitar();
            _Txt_Codigo.Enabled = true;
            _Mtd_CargarGrupos();
            _Mtd_CargarPhone();
        }
        public void _Mtd_Habilitar()
        {
            _Txt_Codigo.Enabled = false;
            _Txt_Direccion.Enabled = true;
            _Txt_Email.Enabled = true;
            _Bt_Usuario.Enabled = true;
            if (!_Rbt_Ger.Checked)
            {
                _Cmb_Grupo.Enabled = true;
            }
            _Txt_Gerente.Enabled = true;
            _Txt_Apellido.Enabled = true;
            _Txt_Cedula.Enabled = true;
            _Txt_Nombre.Enabled = true;
            _Txt_Telefono.Enabled = true;
            if ((_Txt_Codigo.Text.Trim().Length > 0 & _Chbox_Activo.Checked) | _Txt_Codigo.Text.Trim().Length == 0)
            { _Chbox_Activo.Enabled = true; }
            else
            { _Chbox_Activo.Enabled = false; }
            _Cb_Phone.Enabled = true;
        }

        private void Frm_Vendedores_Activated(object sender, EventArgs e)
        {
            _Ctrl_Controles[0] = _Txt_Codigo;
            _Ctrl_Controles[1] = _Txt_Direccion;
            _Ctrl_Controles[2] = _Txt_Email;
            _Ctrl_Controles[3] = _Txt_Gerente;
            _Ctrl_Controles[4] = _Txt_Nombre;
            _Ctrl_Controles[5] = _Txt_Telefono;
            _Ctrl_Controles[6] = _Chbox_Gerente;
            _Ctrl_Controles[7] = _Chbox_Activo;
            _Ctrl_Controles[8] = _Cmb_Grupo;
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
            if (!_Txt_Nombre.Enabled & _Txt_Nombre.Text.Trim().Length > 0)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = _myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CREAR_VEND");
            }
            else if (!_Txt_Codigo.Enabled & _Txt_Codigo.Text.Trim().Length > 0 & _Txt_Nombre.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CREAR_VEND");
                //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
            }
            else if (_Txt_Codigo.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CREAR_VEND");
                //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            }
            ((Frm_Padre)Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_nuevo2.Enabled = _myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CREAR_VEND");
            ((Frm_Padre)Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_cancelar2.Enabled = _myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CREAR_VEND");
            //_____________________________________________
            if (_Bol_Zona)
            { _Mtd_AcualizarZona(); _Bol_Zona = false; }
        }
        bool _Bol_Zona = false;
        private void _Mtd_AcualizarZona()
        {
            if (!_Txt_Nombre.Enabled & _Txt_Nombre.Text.Trim().Length > 0)
            {
                string _Str_Cadena = "Select c_zona from TZONAVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _Txt_Codigo.Text.Trim() + "' AND cdelete='0'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_Zona.Text = _Ds.Tables[0].Rows[0][0].ToString();
                    if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
                    {
                        _Mtd_Actualizar_Ven(Frm_Padre._Str_Use);
                    }
                    else
                    {
                        _Mtd_Actualizar_Ven();
                    }
                }
            }
        }
        public void _Mtd_Nuevo()
        {
            _Pnl_Nuevo.Parent = this;
            _Pnl_Nuevo.BringToFront();
            _Pnl_Nuevo.Left = (this.Width / 2) - (_Pnl_Nuevo.Width / 2);
            _Pnl_Nuevo.Top = (this.Height / 2) - (_Pnl_Nuevo.Height / 2);
            _Pnl_Nuevo.Visible = true;
        }
        private void _Mtd_Deshabilitar_Todo()
        {
            _Txt_Codigo.Enabled = false;
            _Txt_Direccion.Enabled = false;
            _Txt_Email.Enabled = false;
            _Txt_Gerente.Enabled = false;
            _Txt_Nombre.Enabled = false;
            _Bt_Usuario.Enabled = false;
            _Cmb_Grupo.Enabled = false;
            _Txt_Telefono.Enabled = false;
            _Chbox_Activo.Enabled = false;
            _Bt_Buscar.Enabled = false;
            _Txt_Apellido.Enabled = false;
            _Txt_Cedula.Enabled = false;
            _Cb_Phone.Enabled = false;
        }

        private void _Tb_Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
        }
        public void _Mtd_Guardar_Imagen()
        {
            if (_Pbox_Imagen.Image != null)
            {
                byte[] _By_ = _Mtd_convertirPicBoxImageparaByte(_Pbox_Imagen.Image);
                string da = Program._MyClsCnn._mtd_conexion._g_Str_Stringconex;
                SqlCommand cmdInsert = null;
                SqlParameter dbParamInsert;
                SqlConnection con = new SqlConnection(da);
                string _Str_Cadena = "ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _Txt_Codigo.Text.Trim() + "'";
                cmdInsert = new SqlCommand("UPDATE TVENDEDOR Set c_foto=@c_foto where " + _Str_Cadena, con);
                dbParamInsert = new SqlParameter("@c_foto", SqlDbType.VarBinary, _By_.Length, ParameterDirection.Input, false, 0, 0, "c_foto", DataRowVersion.Current, _By_);
                cmdInsert.Parameters.Add(dbParamInsert);
                cmdInsert.Connection = con;
                con.Open();
                cmdInsert.ExecuteNonQuery();
                con.Close();
            }
        }
        private byte[] _Mtd_convertirPicBoxImageparaByte(Image _img_pbImage)
        {
            System.IO.MemoryStream _ms = new System.IO.MemoryStream();
            _img_pbImage.Save(_ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return _ms.ToArray();
        }
        public Image _Mtd_convertirByteparaImage(byte[] _by_p_)
        {
            byte[] _by_imageBuffer = _by_p_;
            // Se crea un MemoryStream a partir de ese buffer
            System.IO.MemoryStream _ms = new System.IO.MemoryStream(_by_imageBuffer);
            // Se utiliza el MemoryStream para extraer la imagen
            Image _img_h = Image.FromStream(_ms);
            return _img_h;
        }
        private bool _Mtd_VerificarVendedorEnZona(string _P_Str_Vendedor,string _P_Str_GrupoVta)
        {
            if (_Str_GrupoVta.Trim().ToUpper() != _P_Str_GrupoVta.Trim().ToUpper())
            {
                string _Str_Cadena = "SELECT cvendedor FROM TZONAVENDEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cvendedor='" + _P_Str_Vendedor + "' AND ISNULL(cdelete,0)=0";
                return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
            }
            return false;
        }
        public bool _Mtd_Guardar()
        {
            _Mtd_Entrada();
            if (!_Chbox_Gerente.Checked)
            {
                if (_Txt_Codigo.Text.Trim().Length > 0 & _Txt_Nombre.Text.Trim().Length > 0 & _Txt_Direccion.Text.Trim().Length > 0 & _Txt_Telefono.Text.Trim().Length > 0 & _Txt_Gerente.Text.Trim().Length > 0 & _Cmb_Grupo.SelectedIndex > 0 & _Txt_Apellido.Text.Trim().Length > 0 & _Txt_Cedula.Text.Trim().Length > 0 & _Cb_Phone.SelectedIndex > 0)
                {
                    if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _Txt_Codigo.Text.Trim() + "'"))
                    {
                        MessageBox.Show("El registro ya existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' AND ccedula='" + _Txt_Cedula.Text.Trim() + "' AND c_activo='1' AND c_tipo_vend='1'"))
                    {
                        MessageBox.Show("Ya existe un vendedor con la cédula: " + _Txt_Cedula.Text.Trim() + ". Coloque una diferente.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return false;
                    }
                    else
                    {
                        string _Str_Nombre = _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper();
                        _Txt_Email.Text = _Mtd_Crear_Correo(_Txt_Nombre.Text.Trim().ToUpper(), _Txt_Apellido.Text.Trim().ToUpper());
                        if (_Txt_Email.Text.Trim().Length > 0)
                        {
                            string _Str_Cadena = "insert into TVENDEDOR (ccompany,cvendedor,cname,c_direccion,c_telefono,c_email,c_activo,c_tipo_vend,cgerarea,cdateadd,cuseradd,cdelete,c_grupo_vta,chostname,ccedula) values('" + Frm_Padre._Str_Comp + "','" + _Txt_Codigo.Text.Trim().ToUpper() + "','" + _Str_Nombre + "','" + _Txt_Direccion.Text.Trim().ToUpper() + "','" + _Cb_Phone.Text + _Txt_Telefono.Text.Trim().ToUpper() + "','" + _Txt_Email.Text.Trim().ToUpper() + "','" + Convert.ToInt32(_Chbox_Activo.Checked).ToString() + "','1','" + _Txt_Cod_Ger.Text + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + _Cmb_Grupo.SelectedValue + "','" + _Cb_Phone.SelectedValue.ToString() + _Txt_Telefono.Text.Trim() + "','" + _Txt_Cedula.Text.Trim() + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            _Mtd_Guardar_Imagen();
                            //----------Nuevo
                            _Mtd_Guardar_UserGroup(false, _Txt_Codigo.Text.Trim().ToUpper());
                            //----------Nuevo
                            MessageBox.Show("El registro fue agregado correctamente y la clave provisional del vendedor es: " + _Str_Clave + " recuerde que debe hacerle llegar esta clave al usuario para que pueda acceder al sistema", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
                            {
                                _Mtd_Actualizar_Ven(Frm_Padre._Str_Use);
                            }
                            else
                            {
                                _Mtd_Actualizar_Ven();
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
                            MessageBox.Show("Error en la conexión a internet para la creación del correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                else
                {
                    if (_Txt_Codigo.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Codigo, "Información requerida!!!"); }
                    if (_Txt_Direccion.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Direccion, "Información requerida!!!"); }
                    if (_Txt_Nombre.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Nombre, "Información requerida!!!"); }
                    if (_Txt_Apellido.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Apellido, "Información requerida!!!"); }
                    if (_Txt_Cedula.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Cedula, "Información requerida!!!"); }
                    if (_Txt_Telefono.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Telefono, "Información requerida!!!"); }
                    if (_Txt_Gerente.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Gerente, "Información requerida!!!"); }
                    if (_Cmb_Grupo.SelectedIndex < 1) { _Er_Error.SetError(_Cmb_Grupo, "Información requerida!!!"); }
                    if (_Cb_Phone.SelectedIndex < 1) { _Er_Error.SetError(_Cb_Phone, "Información requerida!!!"); }
                    return false;
                }
            }
            else
            {
                if (_Txt_Codigo.Text.Trim().Length > 0 & _Txt_Nombre.Text.Trim().Length > 0 & _Txt_Direccion.Text.Trim().Length > 0 & _Txt_Telefono.Text.Trim().Length > 0 & _Txt_Apellido.Text.Trim().Length > 0 & _Txt_Cedula.Text.Trim().Length > 0 & _Cb_Phone.SelectedIndex > 0)
                {
                    if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _Txt_Codigo.Text.Trim() + "'"))
                    {
                        MessageBox.Show("El registro ya existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' AND ccedula='" + _Txt_Cedula.Text.Trim() + "' AND c_activo='1' AND c_tipo_vend='2'"))
                    {
                        MessageBox.Show("Ya existe un vendedor con la cédula: " + _Txt_Cedula.Text.Trim() + ". Coloque una diferente.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return false;
                    }
                    else
                    {
                        string _Str_Nombre = _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper();
                        _Txt_Email.Text = _Mtd_Crear_Correo(_Txt_Nombre.Text.Trim().ToUpper(), _Txt_Apellido.Text.Trim().ToUpper());
                        if (_Txt_Email.Text.Trim().Length > 0)
                        {
                            string _Str_Cadena = "insert into TVENDEDOR (ccompany,cvendedor,cname,c_direccion,c_telefono,c_email,c_activo,c_tipo_vend,cdateadd,cuseradd,cdelete,c_grupo_vta,chostname,ccedula) values('" + Frm_Padre._Str_Comp + "','" + _Txt_Codigo.Text.Trim().ToUpper() + "','" + _Str_Nombre + "','" + _Txt_Direccion.Text.Trim().ToUpper() + "','" + _Cb_Phone.Text + _Txt_Telefono.Text.Trim().ToUpper() + "','" + _Txt_Email.Text.Trim().ToUpper() + "','" + Convert.ToInt32(_Chbox_Activo.Checked).ToString() + "','2',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + _Cmb_Grupo.SelectedValue + "','" + _Cb_Phone.SelectedValue.ToString() + _Txt_Telefono.Text.Trim() + "','" + _Txt_Cedula.Text.Trim() + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            _Mtd_Guardar_Imagen();
                            //----------Nuevo
                            _Mtd_Guardar_UserGroup(true, _Txt_Codigo.Text.Trim().ToUpper());
                            //----------Nuevo
                            MessageBox.Show("El registro fue agregado correctamente y la clave provisional del vendedor es: " + _Str_Clave + " recuerde que debe hacerle llegar esta clave al usuario para que pueda acceder al sistema", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Mtd_Actualizar_Ger();
                            _Mtd_Ini();
                            _Mtd_Deshabilitar_Todo();
                            _Tb_Tab.SelectedIndex = 0;
                            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                            _Er_Error.Dispose();
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Error en la conexión a internet para la creación del correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                else
                {
                    if (_Txt_Codigo.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Codigo, "Información requerida!!!"); }
                    if (_Txt_Direccion.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Direccion, "Información requerida!!!"); }
                    if (_Txt_Apellido.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Apellido, "Información requerida!!!"); }
                    if (_Txt_Cedula.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Cedula, "Información requerida!!!"); }
                    if (_Txt_Nombre.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Nombre, "Información requerida!!!"); }
                    if (_Txt_Telefono.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Telefono, "Información requerida!!!"); }
                    if (_Cb_Phone.SelectedIndex < 1) { _Er_Error.SetError(_Cb_Phone, "Información requerida!!!"); }
                    return false;
                }
            }
        }
        private bool _Mtd_Editar_1(bool _Bol_Traslado)
        {
            if (_Mtd_VerificarVendedorEnZona(_Txt_Codigo.Text.Trim(), Convert.ToString(_Cmb_Grupo.SelectedValue).Trim()))
            {
                MessageBox.Show("No se puede cambiar el grupo de ventas porque el vendedor tiene asignada una zona.\nQuite al vendedor de la zona antes de realizar esta acción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                _Str_Nombre_G = _Txt_Nombre.Text.Trim().ToUpper();
                _Str_Apellido_G = _Txt_Apellido.Text.Trim().ToUpper();
                string _Str_Nombre = _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper();
                string _Str_NombreVendedor = _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper();
                if (_Str_Nombre.Length > 50)
                {
                    _Str_Nombre = _Str_Nombre.Substring(0, 50);
                }
                string _Str_Cadena = "UPDATE TVENDEDOR Set cname='" + _Str_NombreVendedor + "',c_direccion='" + _Txt_Direccion.Text.Trim().ToUpper() + "',c_telefono='" + _Cb_Phone.Text.ToString() + _Txt_Telefono.Text.Trim().ToUpper() + "',c_email='" + _Txt_Email.Text.Trim().ToUpper() + "',c_activo='" + Convert.ToInt32(_Chbox_Activo.Checked).ToString() + "',c_tipo_vend='1',cgerarea='" + _Txt_Cod_Ger.Text + "',chostname='" + _Cb_Phone.SelectedValue.ToString() + _Txt_Telefono.Text.Trim() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',c_grupo_vta='" + _Cmb_Grupo.SelectedValue + "',ccedula='" + _Txt_Cedula.Text.Trim() + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _Txt_Codigo.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "UPDATE TUSER SET cname='"+_Str_Nombre+"',ccedula='" + _Txt_Cedula.Text.Trim().ToUpper() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cuser='" + _Txt_Codigo.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Mtd_Guardar_Imagen();
                _Mtd_Editar_UserGroup(false, _Txt_Codigo.Text.Trim().ToUpper());
                if (_Bol_Traslado) { _Mtd_TrasladoMovimiento(_Txt_Codigo.Text.Trim(), _Txt_Cod_Ger.Text.Trim()); }
                MessageBox.Show("El registro fue modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
                {
                    _Mtd_Actualizar_Ven(Frm_Padre._Str_Use);
                }
                else
                {
                    _Mtd_Actualizar_Ven();
                }
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
                _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Er_Error.Dispose();
                return true;
            }
        }
        private bool _Mtd_Editar_2(bool _Bol_Traslado)
        {
            if (_Mtd_VerificarVendedorEnZona(_Txt_Codigo.Text.Trim(), Convert.ToString(_Cmb_Grupo.SelectedValue).Trim()))
            {
                MessageBox.Show("No se puede cambiar el grupo de ventas porque el vendedor tiene asignada una zona.\nQuite al vendedor de la zona antes de realizar esta acción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                string _Str_Nombre = _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper();
                string _Str_NombreVendedor = _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper();
                if (_Str_Nombre.Length > 50)
                {
                    _Str_Nombre = _Str_Nombre.Substring(0, 50);
                }
                string _Str_Cadena = "UPDATE TVENDEDOR Set cname='" + _Str_NombreVendedor + "',c_direccion='" + _Txt_Direccion.Text.Trim().ToUpper() + "',c_telefono='" + _Cb_Phone.Text + _Txt_Telefono.Text.Trim().ToUpper() + "',c_email='" + _Txt_Email.Text.Trim().ToUpper() + "',c_activo='" + Convert.ToInt32(_Chbox_Activo.Checked).ToString() + "',c_tipo_vend='1',cgerarea='" + _Txt_Cod_Ger.Text + "',chostname='" + _Cb_Phone.SelectedValue.ToString() + _Txt_Telefono.Text.Trim() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',c_grupo_vta='" + _Cmb_Grupo.SelectedValue + "',ccedula='" + _Txt_Cedula.Text.Trim() + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _Txt_Codigo.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "UPDATE TUSER SET cname='"+_Str_Nombre.ToUpper()+"',ccedula='" + _Txt_Cedula.Text.Trim().ToUpper() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cuser='" + _Txt_Codigo.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Mtd_Guardar_Imagen();
                if (_Bol_Traslado) { _Mtd_TrasladoMovimiento(_Txt_Codigo.Text.Trim(), _Txt_Cod_Ger.Text.Trim()); }
                MessageBox.Show("El registro fue modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
                {
                    _Mtd_Actualizar_Ven(Frm_Padre._Str_Use);
                }
                else
                {
                    _Mtd_Actualizar_Ven();
                }
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
                _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Er_Error.Dispose();
                return true;
            }
        }
        private void _Mtd_TrasladoMovimiento(string _P_Str_Vendedor,string _P_Str_GerenteNuevo)
        {
            //DateTime _Dtm_TempDes = new DateTime(Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())).Year, Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())).Month, 1);
            //string _Str_Cadena = "UPDATE TMOVINVENTAS SET cgerarea='" + _P_Str_GerenteNuevo + "',cdateadd=GETDATE() WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cvendedor='" + _P_Str_Vendedor + "' AND convert(datetime,convert(varchar(255),cdatemov,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dtm_TempDes) + "' AND GETDATE()";
            //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private bool _Mtd_Inactivado(string _P_Str_Vendedor)
        {
            string _Str_Cadena = "SELECT cvendedor FROM TVENDEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cvendedor='" + _P_Str_Vendedor + "' AND c_activo='0' AND LEN(RTRIM(LTRIM(CONVERT(VARCHAR,cfechainact))))>0";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        public bool _Mtd_Editar()
        {
            if (!_Chbox_Gerente.Checked)
            {
                if (_Txt_Codigo.Text.Trim().Length > 0 & _Txt_Nombre.Text.Trim().Length > 0 & _Txt_Direccion.Text.Trim().Length > 0 & _Txt_Telefono.Text.Trim().Length > 0 & _Txt_Gerente.Text.Trim().Length > 0 & _Cmb_Grupo.SelectedIndex > 0 & _Cb_Phone.SelectedIndex > 0 & _Txt_Cedula.Text.Trim().Length > 0)
                {
                    if (_Chbox_Activo.Checked)
                    {
                        if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' AND cvendedor<>'" + _Txt_Codigo.Text.Trim() + "' AND ccedula='" + _Txt_Cedula.Text.Trim() + "' AND c_activo='1' AND c_tipo_vend='1'"))
                        {
                            MessageBox.Show("Ya existe un vendedor con la cédula: " + _Txt_Cedula.Text.Trim() + ". Coloque una diferente.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return false;
                        }
                        else
                        {
                            ////////////////////
                            string _Str_Nombre_G_D = _Txt_Nombre.Text.Trim().ToUpper() + " ";
                            _Str_Nombre_G_D = _Str_Nombre_G_D.Substring(0, _Str_Nombre_G_D.IndexOf(" "));
                            string _Str_Apellido_G_D = _Txt_Apellido.Text.Trim().ToUpper() + " ";
                            _Str_Apellido_G_D = _Str_Apellido_G_D.Substring(0, _Str_Apellido_G_D.IndexOf(" "));
                            ////////////////////
                            if (_Str_Nombre_G != _Str_Nombre_G_D | _Str_Apellido_G != _Str_Apellido_G_D | !_Bol_Activo)
                            {
                                if (_Mtd_Eliminar_Correo(_Txt_Email.Text.Trim()) & _Mtd_Crear_Correo(_Txt_Nombre.Text.Trim().ToUpper(), _Txt_Apellido.Text.Trim().ToUpper()).Trim().Length > 0)
                                {
                                    if (_Str_GerenteActual.ToUpper().Trim() != _Txt_Cod_Ger.Text.ToUpper().Trim())
                                    {
                                        if (MessageBox.Show("Se ha cambiado el gerente de área.\n Los movimientos de venta en el mes actual del gerente actual se trasladaran al nuevo gerente.\n ¿Esta seguro de cambiar el gerente actual del vendedor?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                        {
                                            return _Mtd_Editar_1(true);
                                        }
                                        return false;
                                    }
                                    else
                                    {
                                        return _Mtd_Editar_1(false);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Error en la conexión a internet para actualizar el correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }

                            }
                            else
                            {
                                if (_Str_GerenteActual.ToUpper().Trim() != _Txt_Cod_Ger.Text.ToUpper().Trim())
                                {
                                    if (MessageBox.Show("Se ha cambiado el gerente de área.\n Los movimientos de venta en el mes actual del gerente actual se trasladaran al nuevo gerente.\n ¿Esta seguro de cambiar el gerente actual del vendedor?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                    {
                                        return _Mtd_Editar_2(true);
                                    }
                                    return false;
                                }
                                else
                                {
                                    return _Mtd_Editar_2(false);
                                }
                            }
                        }
                    }
                    else
                    {
                        bool _Bol_Edit_Inac = true;
                        bool _Bol_Inactivado = false;
                        if (!_Mtd_Inactivado(_Txt_Codigo.Text.Trim()))
                        {
                            _Bol_Edit_Inac = new Frm_MessageBox("¿Esta seguro de inactivar el vendedor?", "Precaución", SystemIcons.Warning, 1).ShowDialog() == DialogResult.Yes;
                        }
                        else
                        { _Bol_Inactivado = true; }
                        if (_Bol_Edit_Inac)
                        {
                            if (_Mtd_ValidaInactivacion(_Txt_Codigo.Text.Trim(), Frm_Padre._Str_Comp))
                            {
                                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' AND cvendedor<>'" + _Txt_Codigo.Text.Trim() + "' AND ccedula='" + _Txt_Cedula.Text.Trim() + "' AND c_activo='1' AND c_tipo_vend='1'"))
                                {
                                    MessageBox.Show("Ya existe un vendedor con la cédula: " + _Txt_Cedula.Text.Trim() + ". Coloque una diferente.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    return false;
                                }
                                else
                                {
                                    if (_Mtd_VerificarVendedorEnZona(_Txt_Codigo.Text.Trim(), Convert.ToString(_Cmb_Grupo.SelectedValue).Trim()))
                                    {
                                        MessageBox.Show("No se puede cambiar el grupo de ventas porque el vendedor tiene asignada una zona.\nQuite al vendedor de la zona antes de realizar esta acción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return false;
                                    }
                                    else
                                    {
                                        if (_Mtd_Eliminar_Correo(_Txt_Email.Text.Trim()))
                                        {
                                            string _Str_Nombre = _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper();
                                            if (_Bol_Inactivado)
                                            {
                                                string _Str_Cadena = "UPDATE TVENDEDOR Set cname='" + _Str_Nombre + "',c_direccion='" + _Txt_Direccion.Text.Trim().ToUpper() + "',c_telefono='" + _Cb_Phone.Text.Trim() + _Txt_Telefono.Text.Trim().ToUpper() + "',c_email='" + _Txt_Email.Text.Trim().ToUpper() + "',c_activo='" + Convert.ToInt32(_Chbox_Activo.Checked).ToString() + "',c_tipo_vend='1',cgerarea='" + _Txt_Cod_Ger.Text + "',chostname='" + _Cb_Phone.SelectedValue.ToString() + _Txt_Telefono.Text.Trim() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',c_grupo_vta='" + _Cmb_Grupo.SelectedValue + "',ccedula='" + _Txt_Cedula.Text.Trim() + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _Txt_Codigo.Text.Trim() + "'";
                                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                            }
                                            else
                                            {
                                                //****Inactiva al vendedor***
                                                string _Str_Cadena = "UPDATE TVENDEDOR Set cname='" + _Str_Nombre + "',c_direccion='" + _Txt_Direccion.Text.Trim().ToUpper() + "',c_telefono='" + _Cb_Phone.Text.Trim() + _Txt_Telefono.Text.Trim().ToUpper() + "',c_email='" + _Txt_Email.Text.Trim().ToUpper() + "',c_activo='" + Convert.ToInt32(_Chbox_Activo.Checked).ToString() + "',cfechainact=getdate(),c_tipo_vend='1',cgerarea='" + _Txt_Cod_Ger.Text + "',chostname='" + _Cb_Phone.SelectedValue.ToString() + _Txt_Telefono.Text.Trim() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',c_grupo_vta='" + _Cmb_Grupo.SelectedValue + "',ccedula='" + _Txt_Cedula.Text.Trim() + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _Txt_Codigo.Text.Trim() + "'";
                                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                                
                                                //****Bloquea usuario del vendedor en tabla TUSER***
                                                _Str_Cadena = "update TUSER set clocked = '1', cdateupd = getdate(), cuserupd ='" + Frm_Padre._Str_Use + "' where cuser ='" + _Txt_Codigo.Text.Trim() + "'";
                                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                            }
                                            _Mtd_Guardar_Imagen();
                                            MessageBox.Show("El registro fue modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
                                            {
                                                _Mtd_Actualizar_Ven(Frm_Padre._Str_Use);
                                            }
                                            else
                                            {
                                                _Mtd_Actualizar_Ven();
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
                                            MessageBox.Show("Error en la conexión a internet para inactivar el correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("El vendedor no puede inactivarse ya que tiene prefacturas pendientes y/o facturas que no han sido entregadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        else
                        {
                            if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
                            {
                                _Mtd_Actualizar_Ven(Frm_Padre._Str_Use);
                            }
                            else
                            {
                                _Mtd_Actualizar_Ven();
                            }
                            _Mtd_Ini();
                            _Mtd_Deshabilitar_Todo();
                            _Tb_Tab.SelectedIndex = 0;
                            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                            _Er_Error.Dispose();
                            return true;
                        }
                    }
                }
                else
                {
                    if (_Txt_Codigo.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Codigo, "Información requerida!!!"); }
                    if (_Txt_Direccion.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Direccion, "Información requerida!!!"); }
                    if (_Txt_Nombre.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Nombre, "Información requerida!!!"); }
                    if (_Txt_Cedula.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Cedula, "Información requerida!!!"); }
                    if (_Txt_Telefono.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Telefono, "Información requerida!!!"); }
                    if (_Txt_Gerente.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Gerente, "Información requerida!!!"); }
                    if (_Cmb_Grupo.SelectedIndex < 1) { _Er_Error.SetError(_Cmb_Grupo, "Información requerida!!!"); }
                    if (_Cb_Phone.SelectedIndex < 1) { _Er_Error.SetError(_Cb_Phone, "Información requerida!!!"); }
                    return false;
                }
            }
            else
            {
                if (_Txt_Codigo.Text.Trim().Length > 0 & _Txt_Nombre.Text.Trim().Length > 0 & _Txt_Direccion.Text.Trim().Length > 0 & _Txt_Telefono.Text.Trim().Length > 0 & _Cb_Phone.SelectedIndex > 0 & _Txt_Cedula.Text.Trim().Length > 0)
                {
                    if (_Chbox_Activo.Checked)
                    {
                        if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' AND cvendedor<>'" + _Txt_Codigo.Text.Trim() + "' AND ccedula='" + _Txt_Cedula.Text.Trim() + "' AND c_activo='1' AND c_tipo_vend='2'"))
                        {
                            MessageBox.Show("Ya existe un vendedor con la cédula: " + _Txt_Cedula.Text.Trim() + ". Coloque una diferente.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return false;
                        }
                        else
                        {
                            ////////////////////
                            string _Str_Nombre_G_D = _Txt_Nombre.Text.Trim().ToUpper() + " ";
                            _Str_Nombre_G_D = _Str_Nombre_G_D.Substring(0, _Str_Nombre_G_D.IndexOf(" "));
                            string _Str_Apellido_G_D = _Txt_Apellido.Text.Trim().ToUpper() + " ";
                            _Str_Apellido_G_D = _Str_Apellido_G_D.Substring(0, _Str_Apellido_G_D.IndexOf(" "));
                            ////////////////////
                            if (_Str_Nombre_G != _Str_Nombre_G_D | _Str_Apellido_G != _Str_Apellido_G_D | !_Bol_Activo)
                            {
                                if (_Mtd_Eliminar_Correo(_Txt_Email.Text.Trim()) & _Mtd_Crear_Correo(_Txt_Nombre.Text.Trim().ToUpper(), _Txt_Apellido.Text.Trim().ToUpper()).Trim().Length > 0)
                                {
                                    _Str_Nombre_G = _Txt_Nombre.Text.Trim().ToUpper();
                                    _Str_Apellido_G = _Txt_Apellido.Text.Trim().ToUpper();
                                    string _Str_Nombre = _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper();
                                    if (_Str_Nombre.Length > 50)
                                    {
                                        _Str_Nombre = _Str_Nombre.Substring(0, 50);
                                    }
                                    string _Str_NombreVendedor = _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper();
                                    string _Str_Cadena = "UPDATE TVENDEDOR Set cname='" + _Str_NombreVendedor.ToUpper() + "',c_direccion='" + _Txt_Direccion.Text.Trim().ToUpper() + "',c_telefono='" + _Cb_Phone.Text.Trim() + _Txt_Telefono.Text.Trim().ToUpper() + "',c_email='" + _Txt_Email.Text.Trim().ToUpper() + "',c_activo='" + Convert.ToInt32(_Chbox_Activo.Checked).ToString() + "',c_tipo_vend='2',chostname='" + _Cb_Phone.SelectedValue.ToString() + _Txt_Telefono.Text.Trim() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',c_grupo_vta='" + _Cmb_Grupo.SelectedValue + "',ccedula='" + _Txt_Cedula.Text.Trim() + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _Txt_Codigo.Text.Trim() + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                    _Str_Cadena = "UPDATE TUSER SET cname='"+_Str_Nombre.ToUpper()+"',ccedula='" + _Txt_Cedula.Text.Trim().ToUpper() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cuser='" + _Txt_Codigo.Text.Trim() + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                    _Mtd_Guardar_Imagen();
                                    MessageBox.Show("El registro fue modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    _Mtd_Actualizar_Ger();
                                    _Mtd_Ini();
                                    _Mtd_Deshabilitar_Todo();
                                    _Tb_Tab.SelectedIndex = 0;
                                    _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                                    _Er_Error.Dispose();
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("Error en la conexión a internet para actualizar el correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                            }
                            else
                            {
                                string _Str_Nombre = _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper();
                                string _Str_NombreVendedor = _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper();
                                if (_Str_Nombre.Length > 50)
                                {
                                    _Str_Nombre = _Str_Nombre.Substring(0, 50);
                                }
                                string _Str_Cadena = "UPDATE TVENDEDOR Set cname='" + _Str_NombreVendedor.ToUpper() + "',c_direccion='" + _Txt_Direccion.Text.Trim().ToUpper() + "',c_telefono='" + _Cb_Phone.Text.Trim() + _Txt_Telefono.Text.Trim().ToUpper() + "',c_email='" + _Txt_Email.Text.Trim().ToUpper() + "',c_activo='" + Convert.ToInt32(_Chbox_Activo.Checked).ToString() + "',c_tipo_vend='2',chostname='" + _Cb_Phone.SelectedValue.ToString() + _Txt_Telefono.Text.Trim() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',c_grupo_vta='" + _Cmb_Grupo.SelectedValue + "',ccedula='" + _Txt_Cedula.Text.Trim() + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _Txt_Codigo.Text.Trim() + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                _Str_Cadena = "UPDATE TUSER SET cname='" + _Str_Nombre.ToUpper() + "',ccedula='" + _Txt_Cedula.Text.Trim().ToUpper() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cuser='" + _Txt_Codigo.Text.Trim() + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                _Mtd_Guardar_Imagen();
                                MessageBox.Show("El registro fue modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _Mtd_Actualizar_Ger();
                                _Mtd_Ini();
                                _Mtd_Deshabilitar_Todo();
                                _Tb_Tab.SelectedIndex = 0;
                                _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                                _Er_Error.Dispose();
                                return true;
                            }
                        }
                    }
                    else
                    {
                        bool _Bol_Edit_Inac = true;
                        bool _Bol_Inactivado = false;
                        if (!_Mtd_Inactivado(_Txt_Codigo.Text.Trim()))
                        {
                            _Bol_Edit_Inac = new Frm_MessageBox("¿Esta seguro de inactivar el vendedor?", "Precaución", SystemIcons.Warning, 1).ShowDialog() == DialogResult.Yes;
                        }
                        else
                        { _Bol_Inactivado = true; }
                        if (_Bol_Edit_Inac)
                        {
                            if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' AND cvendedor<>'" + _Txt_Codigo.Text.Trim() + "' AND ccedula='" + _Txt_Cedula.Text.Trim() + "' AND c_activo='1' AND c_tipo_vend='2'"))
                            {
                                MessageBox.Show("Ya existe un vendedor con la cédula: " + _Txt_Cedula.Text.Trim() + ". Coloque una diferente.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                return false;
                            }
                            else
                            {
                                if (_Mtd_Eliminar_Correo(_Txt_Email.Text.Trim()))
                                {
                                    string _Str_Nombre = _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper();
                                    if (_Bol_Inactivado)
                                    {
                                        string _Str_Cadena = "UPDATE TVENDEDOR Set cname='" + _Str_Nombre + "',c_direccion='" + _Txt_Direccion.Text.Trim().ToUpper() + "',c_telefono='" + _Cb_Phone.Text + _Txt_Telefono.Text.Trim().ToUpper() + "',c_email='" + _Txt_Email.Text.Trim().ToUpper() + "',c_activo='" + Convert.ToInt32(_Chbox_Activo.Checked).ToString() + "',c_tipo_vend='2',chostname='" + _Cb_Phone.SelectedValue.ToString() + _Txt_Telefono.Text.Trim() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',c_grupo_vta='" + _Cmb_Grupo.SelectedValue + "',ccedula='" + _Txt_Cedula.Text.Trim() + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _Txt_Codigo.Text.Trim() + "'";
                                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                    }
                                    else
                                    {
                                        //*****Inactivación de un Gerente de Ventas*****
                                        string _Str_Cadena = "UPDATE TVENDEDOR Set cname='" + _Str_Nombre + "',c_direccion='" + _Txt_Direccion.Text.Trim().ToUpper() + "',c_telefono='" + _Cb_Phone.Text + _Txt_Telefono.Text.Trim().ToUpper() + "',c_email='" + _Txt_Email.Text.Trim().ToUpper() + "',c_activo='" + Convert.ToInt32(_Chbox_Activo.Checked).ToString() + "',c_tipo_vend='2',chostname='" + _Cb_Phone.SelectedValue.ToString() + _Txt_Telefono.Text.Trim() + "',cfechainact=getdate(),cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',c_grupo_vta='" + _Cmb_Grupo.SelectedValue + "',ccedula='" + _Txt_Cedula.Text.Trim() + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _Txt_Codigo.Text.Trim() + "'";
                                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                                        //*****Inactivación de un Gerente de Ventas en tabla TUSER*****
                                        _Str_Cadena = "update TUSER set clocked = '1', cdateupd = getdate(), cuserupd = '" + Frm_Padre._Str_Use + "' where cuser ='" + _Txt_Codigo.Text.Trim() + "'";
                                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                    }
                                    _Mtd_Guardar_Imagen();
                                    MessageBox.Show("El registro fue modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    _Mtd_Actualizar_Ger();
                                    _Mtd_Ini();
                                    _Mtd_Deshabilitar_Todo();
                                    _Tb_Tab.SelectedIndex = 0;
                                    _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                                    _Er_Error.Dispose();
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("Error en la conexión a internet para inactivar el correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            _Mtd_Actualizar_Ger();
                            _Mtd_Ini();
                            _Mtd_Deshabilitar_Todo();
                            _Tb_Tab.SelectedIndex = 0;
                            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                            _Er_Error.Dispose();
                            return true;
                        }
                    }
                }
                else
                {
                    if (_Txt_Codigo.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Codigo, "Información requerida!!!"); }
                    if (_Txt_Direccion.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Direccion, "Información requerida!!!"); }
                    if (_Txt_Nombre.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Nombre, "Información requerida!!!"); }
                    if (_Txt_Cedula.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Cedula, "Información requerida!!!"); }
                    if (_Txt_Telefono.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Telefono, "Información requerida!!!"); }
                    if (_Cb_Phone.SelectedIndex < 1) { _Er_Error.SetError(_Cb_Phone, "Información requerida!!!"); }
                    return false;
                }

            }
        }
        public bool _Mtd_Eliminar()
        {
            DialogResult eli = MessageBox.Show("Esta seguro de Eliminar el registro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (eli == DialogResult.Yes)
            {
                if (_Mtd_Eliminar_Correo(_Txt_Email.Text.Trim()))
                {
                    string _Str_Cadena = "UPDATE TVENDEDOR Set cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _Txt_Codigo.Text.Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "UPDATE TUSER SET cdelete=1,cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "' WHERE cuser='" + _Txt_Codigo.Text.Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "UPDATE TZONAVENDEDOR SET cdelete=1,cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cvendedor='" + _Txt_Codigo.Text.Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    MessageBox.Show("El registro fue eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (_Chbox_Gerente.Checked)
                    { _Mtd_Actualizar_Ger(); }
                    else
                    {
                        if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
                        {
                            _Mtd_Actualizar_Ven(Frm_Padre._Str_Use);
                        }
                        else
                        {
                            _Mtd_Actualizar_Ven();
                        }
                    }
                    _Mtd_Ini();
                    _Mtd_Deshabilitar_Todo();
                    _Tb_Tab.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Error en la conexión a internet para inactivar el correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (_Chbox_Gerente.Checked)
                { _Mtd_Actualizar_Ger(); }
                else
                {
                    if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
                    {
                        _Mtd_Actualizar_Ven(Frm_Padre._Str_Use);
                    }
                    else
                    {
                        _Mtd_Actualizar_Ven();
                    }
                }
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
            }
            return true;
        }
        TextBox _Txt_Cod_Ger = new TextBox();
        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cvendedor";
            _Str_Campos[1] = "Descripción";
            string _Str_Cadena = "SELECT cvendedor AS Código,cname as Descripción from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and c_tipo_vend='2' and c_activo='1'";
            Frm_Busqueda _Frm = new Frm_Busqueda(_Txt_Cod_Ger, _Txt_Gerente, _Str_Cadena, _Str_Campos, "Transportes", _Tsm_Menu, 0, 1);
            _Frm.MdiParent = this.MdiParent;
            _Frm.Show();
        }

        private void _Txt_Telefono_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Telefono.Text))
            {
                _Txt_Telefono.Text = "";
            }
        }

        private void _Txt_Telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }
        private void _Mtd_Actualizar_Ven()
        {
            Cursor = Cursors.WaitCursor;
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cvendedor";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "SELECT cvendedor AS Código,rtrim(cname) as Nombre,cgerarea,c_direccion,c_email,c_activo,c_tipo_vend,cgerarea,c_grupo_vta,c_telefono as Teléfono,(Select top 1 cname from TGRUPOVTAM where TGRUPOVTAM.cgrupovta=TVENDEDOR.c_grupo_vta) as  [G. Vtas],(rtrim(cgerarea) + ' - ' + (SELECT rtrim(TVend.cname) FROM TVENDEDOR AS TVend where TVend.ccompany=TVENDEDOR.ccompany AND TVend.cvendedor=TVENDEDOR.cgerarea)) AS [G. Area],(Select top 1 c_zona from TZONAVENDEDOR where TZONAVENDEDOR.ccompany=TVENDEDOR.ccompany and TZONAVENDEDOR.cvendedor=TVENDEDOR.cvendedor AND TZONAVENDEDOR.cdelete='0') as Zona,ccedula from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and c_tipo_vend='1' AND c_activo='" + Convert.ToInt32(_Chk_Act.Checked) + "'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "", _Tsm_Menu, _Dg_Grid, true, "", "cast(replace(cvendedor,rtrim(ccompany)+'_','') as integer)");
            //___________________________________
            //DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //_Dg_Grid.DataSource = _Ds.Tables[0];
            for (int _I = 2; _I < 10; _I++)
            {
                _Dg_Grid.Columns[_I].Visible = false;
            }
            
            _Dg_Grid.Columns[13].Visible = false;
            //_Dg_Grid.Columns[10].Visible = true;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }
        private void _Mtd_Actualizar_Ven(string _Pr_Str_Gerente)
        {
            Cursor = Cursors.WaitCursor;
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cvendedor";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "SELECT cvendedor AS Código,rtrim(cname) as Nombre,cgerarea,c_direccion,c_email,c_activo,c_tipo_vend,cgerarea,c_grupo_vta,c_telefono as Teléfono,(Select top 1 cname from TGRUPOVTAM where TGRUPOVTAM.cgrupovta=TVENDEDOR.c_grupo_vta) as  [G. Vtas],(rtrim(cgerarea) + ' - ' + (SELECT rtrim(TVend.cname) FROM TVENDEDOR AS TVend where TVend.ccompany=TVENDEDOR.ccompany AND TVend.cvendedor=TVENDEDOR.cgerarea)) AS [G. Area],(Select top 1 c_zona from TZONAVENDEDOR where TZONAVENDEDOR.ccompany=TVENDEDOR.ccompany and TZONAVENDEDOR.cvendedor=TVENDEDOR.cvendedor AND TZONAVENDEDOR.cdelete='0') as Zona,ccedula from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and c_tipo_vend='1' AND cgerarea='" + _Pr_Str_Gerente + "' AND c_activo='" + Convert.ToInt32(_Chk_Act.Checked) + "'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            for (int _I = 2; _I < 10; _I++)
            {
                _Dg_Grid.Columns[_I].Visible = false;
            }
            _Dg_Grid.Columns[14].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }
        private void _Mtd_Actualizar_Ger()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Gvta = "";
            DataSet _DsA;
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cvendedor";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "SELECT cvendedor AS Código,rtrim(cname) as Nombre,cgerarea,c_direccion,c_email,c_activo,c_tipo_vend,cgerarea,c_grupo_vta as [G. Vtas],c_telefono as Teléfono,ccedula from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and c_tipo_vend='2' AND c_activo='" + Convert.ToInt32(_Chk_Act.Checked) + "' ORDER BY cast(replace(cvendedor,rtrim(ccompany)+'_','') as integer)";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "", _Tsm_Menu, _Dg_Grid, true, "", "");
            //___________________________________
            //DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //_Dg_Grid.DataSource = _Ds.Tables[0];
            foreach (DataGridViewRow _DgRow in _Dg_Grid.Rows)
            {
                _Str_Gvta = "";
                _Str_Cadena = "SELECT DISTINCT c_grupo_vta,(Select top 1 cname from TGRUPOVTAM where TGRUPOVTAM.cgrupovta=TVENDEDOR.c_grupo_vta) as  [GVtas_name],cgerarea FROM TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and c_tipo_vend='1' and cgerarea='" + _DgRow.Cells[0].Value.ToString() + "' and c_activo='1'";
                _DsA = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                foreach (DataRow _Drow in _DsA.Tables[0].Rows)
                {
                    _Str_Gvta = _Str_Gvta + _Drow["GVtas_name"].ToString() + ",";
                }
                if (_Str_Gvta.Length > 0)
                {
                    _Str_Gvta = _Str_Gvta.Substring(0, _Str_Gvta.Length - 1);
                }
                _DgRow.Cells[8].Value = _Str_Gvta;
            }
            _Dg_Grid.Columns[8].Visible = true;
            _Dg_Grid.Columns[9].Visible = false;
            _Dg_Grid.Columns[10].Visible = false;

            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }

        private void _Rbt_Ven_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Ven.Checked)
            {
                if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
                {
                    _Mtd_Actualizar_Ven(Frm_Padre._Str_Use);
                }
                else
                {
                    _Mtd_Actualizar_Ven();
                }
                
                _Chbox_Gerente.Checked = false; _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                this.Text = "Vendedores";
            }
            else
            {
                _Mtd_Actualizar_Ger(); _Chbox_Gerente.Checked = true; _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                this.Text = "Gerentes de Área";
            }
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
        }

        private void _Txt_Nombre_EnabledChanged(object sender, EventArgs e)
        {
            if (_Txt_Nombre.Enabled)
            {
                _Bt_Ini.Enabled = true;
                _Bt_Det.Enabled = true;
                if (!_Chbox_Gerente.Checked)
                { _Bt_Buscar.Enabled = true; }
                else
                { _Bt_Buscar.Enabled = false; }
            }
            else
            {
                _Bt_Ini.Enabled = false;
                _Bt_Det.Enabled = false;
            }
        }
        private void _Mtd_CargarGrupos()
        {
            string _Str_Sql = "SELECT DISTINCT RTRIM(TGRUPOVTAM.cgrupovta) AS cgrupovta, RTRIM(TGRUPOVTAM.cname) AS cname " +
           "FROM TGRUPPROVEE INNER JOIN " +
           "TGRUPOVTAM ON TGRUPPROVEE.cgrupovta = TGRUPOVTAM.cgrupovta " +
           "WHERE (TGRUPOVTAM.cdelete = 0) AND (TGRUPPROVEE.ccompany = '" + Frm_Padre._Str_Comp + "') AND NOT(TGRUPOVTAM.cname is null) " +
           "ORDER BY TGRUPOVTAM.cname";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Grupo, _Str_Sql);
        }
        private void _Mtd_CargarPhone()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cb_Phone.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("0414", "414"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("0424", "186"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("0416", "0"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("0412", "0"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("0426", "0"));
            _Cb_Phone.DataSource = _myArrayList;
            _Cb_Phone.DisplayMember = "Display";
            _Cb_Phone.ValueMember = "Value";
            _Cb_Phone.SelectedValue = "nulo";
        }
        private void _Mtd_Guardar_UserGroup(bool _P_Bol_Gerente,string _P_Str_User)
        {
            string _Str_Cadena = "";
            //----------------------------------------------------------
            string _Str_Cargo = "";
            if (_P_Bol_Gerente)
            { _Str_Cadena = "SELECT cidcargonom FROM TCARGOSNOM WHERE cgerarea='1'"; }
            else
            { _Str_Cadena = "SELECT cidcargonom FROM TCARGOSNOM WHERE cvendedor='1'"; }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { _Str_Cargo = _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
            _Str_Clave = _Mtd_ClaveProvisonalAzar();
            string _Str_ClaveHash = _Mtd_Hash_Clave(_Str_Clave);
            _Str_Cadena = "Select cgrupowvend,cgrupowger,cgroupgerarea from TCONFIGVENT where ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value & _Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                {
                    if (_P_Bol_Gerente)
                    {
                        string _Str_Nombre = _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper();
                        if (_Str_Nombre.Length > 50)
                        {
                            _Str_Nombre = _Str_Nombre.Substring(0, 50);
                        }
                        _Str_Cadena = "insert into TUSER (cuser,cname,cposition,cemail,cphone1,cdateadd,cuseradd,cdelete,cpassw,cvendedor,cuserweb,c_reseteo_clave,cgroup,ccedula) values('" + _P_Str_User + "','" + _Str_Nombre + "','" + _Str_Cargo + "','" + _Txt_Email.Text.Trim().ToUpper() + "','" + _Txt_Telefono.Text.Trim() + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + _Str_ClaveHash + "','" + _P_Str_User + "',1,1,'" + _Ds.Tables[0].Rows[0]["cgroupgerarea"].ToString().Trim() + "','" + _Txt_Cedula.Text.Trim() + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "Insert into TUSERGROUP (cgroup,cuser,ccompany,cdateadd,cuseradd,cdelete) values ('" + _Ds.Tables[0].Rows[0][1].ToString().Trim() + "','" + _P_Str_User + "','" + Frm_Padre._Str_Comp + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "Insert into TUSERCOMP (cuser,ccompany,cdateadd,cuseradd,cdelete) values ('" + _P_Str_User + "','" + Frm_Padre._Str_Comp + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    else
                    {
                        string _Str_Nombre = _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper();
                        if (_Str_Nombre.Length > 50)
                        {
                            _Str_Nombre = _Str_Nombre.Substring(0, 50);
                        }
                        _Str_Cadena = "insert into TUSER (cuser,cname,cposition,cemail,cphone1,cdateadd,cuseradd,cdelete,cpassw,cvendedor,cuserweb,c_reseteo_clave,ccedula) values('" + _P_Str_User + "','" + _Str_Nombre + "','" + _Str_Cargo + "','" + _Txt_Email.Text.Trim().ToUpper() + "','" + _Txt_Telefono.Text.Trim() + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + _Str_ClaveHash + "','" + _P_Str_User + "',1,1,'" + _Txt_Cedula.Text.Trim() + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "Insert into TUSERGROUP (cgroup,cuser,ccompany,cdateadd,cuseradd,cdelete) values ('" + _Ds.Tables[0].Rows[0][0].ToString().Trim() + "','" + _P_Str_User + "','" + Frm_Padre._Str_Comp + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "Insert into TUSERCOMP (cuser,ccompany,cdateadd,cuseradd,cdelete) values ('" + _P_Str_User + "','" + Frm_Padre._Str_Comp + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                }
            }
        }
        private void _Mtd_Guardar_UserGroup(string _P_Str_User)
        {
            string _Str_Cadena = "";
            //----------------------------------------------------------
            string _Str_Cargo = "";
            _Str_Cadena = "SELECT cidcargonom FROM TCARGOSNOM WHERE cvendedor='1'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { _Str_Cargo = _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
            //----------------------------------------------------------
            _Str_Cadena = "SELECT cname FROM TVENDEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cvendedor='" + _P_Str_User + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            string _Str_Nombre = _Ds.Tables[0].Rows[0][0].ToString().Trim();
            _Str_Cadena = "Select cgrupowvend,cgrupowger from TCONFIGVENT where ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Str_Clave = _Mtd_ClaveProvisonalAzar();
            string _Str_ClaveHash = _Mtd_Hash_Clave(_Str_Clave);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value & _Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                {
                    _Str_Cadena = "insert into TUSER (cuser,cname,cposition,cemail,cphone1,cdateadd,cuseradd,cdelete,cpassw,cvendedor,cuserweb,c_reseteo_clave,ccedula) values('" + _P_Str_User + "','" + _Str_Nombre + "','" + _Str_Cargo + "','" + _Txt_Email.Text.Trim().ToUpper() + "','" + _Txt_Telefono.Text.Trim() + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + _Str_ClaveHash + "','" + _P_Str_User + "',1,1,'" + _Txt_Cedula.Text.Trim() + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "Insert into TUSERGROUP (cgroup,cuser,ccompany,cdateadd,cuseradd,cdelete) values ('" + _Ds.Tables[0].Rows[0][0].ToString().Trim() + "','" + _P_Str_User + "','" + Frm_Padre._Str_Comp + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "Insert into TUSERCOMP (cuser,ccompany,cdateadd,cuseradd,cdelete) values ('" + _P_Str_User + "','" + Frm_Padre._Str_Comp + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
            }
        }
        private string _Mtd_ClaveProvisonalAzar()
        {
            Random random = new Random();
            string _Pr_Str_Clave = "" ;
            int _Int_Digito1 = random.Next(0, 9);
            int _Int_Digito2 = random.Next(0, 9);
            int _Int_Digito3 = random.Next(0, 9);
            int _Int_Digito4 = random.Next(0, 9);
            _Pr_Str_Clave= _Int_Digito1.ToString() + _Int_Digito2.ToString() + _Int_Digito3.ToString() + _Int_Digito4.ToString();
            return _Pr_Str_Clave;
        }
        private string _Mtd_Hash_Clave(string _Pr_Str_Clave)
        {
            byte[] hash = CLASES._Cls_Varios_Metodos._Mtd_ConvertString_A_ByteArray(_Pr_Str_Clave);
            byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
            string cod = BitConverter.ToString(valorhash);
            cod = cod.Replace("-", "");
            return cod; 
        }
        private void _Mtd_Editar_UserGroup(bool _P_Bol_Gerente, string _P_Str_User)
        {
            string _Str_Cadena = "";
            //----------------------------------------------------------
            string _Str_Cargo = "";
            if (_P_Bol_Gerente)
            { _Str_Cadena = "SELECT cidcargonom FROM TCARGOSNOM WHERE cgerarea='1'"; }
            else
            { _Str_Cadena = "SELECT cidcargonom FROM TCARGOSNOM WHERE cvendedor='1'"; }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { _Str_Cargo = _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
            //----------------------------------------------------------
            _Str_Cadena = "Select cgrupowvend,cgrupowger from TCONFIGVENT where ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value & _Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                {
                    if (_P_Bol_Gerente)
                    {
                        string _Str_Nombre = _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper();
                        if (_Str_Nombre.Length > 50)
                        {
                            _Str_Nombre = _Str_Nombre.Substring(0, 50);
                        }
                        _Str_Cadena = "UPDATE TUSER SET cname='" + _Str_Nombre.ToUpper() + "',cposition='" + _Str_Cargo + "',cemail='" + _Txt_Email.Text.Trim().ToUpper() + "',cphone1='" + _Txt_Telefono.Text.Trim() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cuserweb=1,ccedula='" + _Txt_Cedula.Text.Trim() + "' WHERE cuser='" + _P_Str_User + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                        _Str_Cadena = "UPDATE TUSERGROUP SET cgroup='" + _Ds.Tables[0].Rows[0][1].ToString().Trim() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cuser='" + _P_Str_User + "' AND ccompany='"+Frm_Padre._Str_Comp+"'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    else
                    {
                        string _Str_Nombre = _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper();
                        if (_Str_Nombre.Length > 50)
                        {
                            _Str_Nombre = _Str_Nombre.Substring(0, 50);
                        }

                        _Str_Cadena = "UPDATE TUSER SET cname='" + _Str_Nombre.ToUpper() + "',cposition='" + _Str_Cargo + "',cemail='" + _Txt_Email.Text.Trim().ToUpper() + "',cphone1='" + _Txt_Telefono.Text.Trim() + "',cdateupd=getdate(),cuserupd='" + Frm_Padre._Str_Use + "',cuserweb=1,ccedula='" + _Txt_Cedula.Text.Trim() + "' WHERE cuser='" + _P_Str_User + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                        _Str_Cadena = "UPDATE TUSERGROUP SET cgroup='" + _Ds.Tables[0].Rows[0][0].ToString().Trim() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cuser='" + _P_Str_User + "' AND ccompany='" + Frm_Padre._Str_Comp + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                }
            }
        }
        private void _Cmb_Grupo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_CargarGrupos();
            this.Cursor = Cursors.Default;
        }

        private void _Bt_Usuario_Click(object sender, EventArgs e)
        {
            if (_Txt_Codigo.Text.Trim().Length > 0)
            {
                string _Str_Cadena = "Select * from TUSER where cuser='" + _Txt_Codigo.Text.Trim() + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    Frm_UsuarioAdmin _Frm = new Frm_UsuarioAdmin(_Txt_Codigo.Text.Trim());
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Show();
                }
                else
                { MessageBox.Show("El usuario aún no ha sido creado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else
            { MessageBox.Show("No se puede mostrar el formulario en esta instancia","Información",MessageBoxButtons.OK,MessageBoxIcon.Information); }
        }

        private void _Bt_Cuota_Click(object sender, EventArgs e)
        {
            if (!_Txt_Nombre.Enabled & _Txt_Nombre.Text.Trim().Length > 0)
            {
                if (_Txt_Zona.Text.Trim().Length > 0)
                {
                    Frm_Cuotaventas1 _Frm = new Frm_Cuotaventas1(_Txt_Zona.Text.Trim());
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Dock = DockStyle.Fill;
                    _Frm.Show();
                }
                else
                {
                    if (_Chbox_Gerente.Checked)
                    {
                        MessageBox.Show("Debe seleccionar un vendedor y no un gerente de área para realizar esta operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    }
                    else
                    {
                        if (MessageBox.Show("El vendedor no posee zonas asignadas. ¿Desea asignar alguna zona a este vendedor?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            Frm_VendedoresSinZona _Frm = new Frm_VendedoresSinZona(_Txt_Codigo.Text.Trim(), _Cmb_Grupo.SelectedValue.ToString().Trim());
                            _Frm.MdiParent = this.MdiParent;
                            _Frm.Dock = DockStyle.Fill;
                            _Frm.Show();
                            _Bol_Zona = true;
                        }
                    }
                }
            }
            else if (!_Txt_Codigo.Enabled & _Txt_Codigo.Text.Trim().Length > 0 & _Txt_Nombre.Enabled)
            {
                MessageBox.Show("No puede realizar esta operación mientras esta editando un vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_Txt_Codigo.Enabled)
            { MessageBox.Show("Debe guardar el vendedor para realizar esta operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else if (!_Txt_Codigo.Enabled & _Txt_Codigo.Text.Trim().Length == 0)
            { MessageBox.Show("No se ha seleccionado ningún vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Bt_Ruta_Click(object sender, EventArgs e)
        {
            if (!_Txt_Nombre.Enabled & _Txt_Nombre.Text.Trim().Length > 0)
            {
                if (_Rbt_Ven.Checked)
                {
                   string _Str_Cadena = "Select c_zona from TZONAVENDEDOR where cvendedor='" + _Txt_Codigo.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    {
                        DataRow _Row = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0];
                        //_Str_Cadena = "Select * from TRUTAVISITAM where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Txt_Zona.Text.Trim() + "'";
                        //if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                        //{
                            Frm_RutaVisitas _Frm = new Frm_RutaVisitas(_Row[0].ToString(), _Cmb_Grupo.SelectedValue.ToString());
                            _Frm.MdiParent = this.MdiParent;
                            _Frm.Dock = DockStyle.Fill;
                            _Frm.Show();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("No existen rutas asignadas a la zona del vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                    }
                    else
                    {
                        if (MessageBox.Show("El vendedor no posee zonas asignadas. ¿Desea asignar alguna zona a este vendedor?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            Frm_VendedoresSinZona _Frm = new Frm_VendedoresSinZona(_Txt_Codigo.Text.Trim(), _Cmb_Grupo.SelectedValue.ToString().Trim());
                            _Frm.MdiParent = this.MdiParent;
                            _Frm.Show();
                            _Bol_Zona = true;
                        }
                    }
                }
                else
                { MessageBox.Show("Debe seleccionar un vendedor y no un gerente de área para realizar esta operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else if (!_Txt_Codigo.Enabled & _Txt_Codigo.Text.Trim().Length > 0 & _Txt_Nombre.Enabled)
            {
                MessageBox.Show("No puede realizar esta operación mientras esta editando un vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
            else if (_Txt_Codigo.Enabled)
            { MessageBox.Show("Debe guardar el vendedor para realizar esta operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else if (!_Txt_Codigo.Enabled & _Txt_Codigo.Text.Trim().Length == 0)
            { MessageBox.Show("No se ha seleccionado ningún vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Bt_Zona_Click(object sender, EventArgs e)
        {
            if (!_Txt_Nombre.Enabled & _Txt_Nombre.Text.Trim().Length > 0 & _Txt_Zona.Text.Trim().Length > 0 & !_Chbox_Gerente.Checked)
            {
                string _Str_Cadena = "Select * from TZONACLIENTE where ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Txt_Zona.Text.Trim() + "' and cgrupovta='" + _Cmb_Grupo.SelectedValue.ToString().Trim() + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                {
                    Frm_ZonaporCliente _Frm = new Frm_ZonaporCliente(_Txt_Zona.Text, _Cmb_Grupo.SelectedValue.ToString().Trim());
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Dock = DockStyle.Fill;
                    _Frm.Show();
                }
                else
                {
                    MessageBox.Show("No existen clientes asignados a la zona del vendedor","Información",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (!_Txt_Codigo.Enabled & _Txt_Codigo.Text.Trim().Length > 0 & _Txt_Nombre.Enabled)
            {
                MessageBox.Show("No puede realizar esta operación mientras esta editando un vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_Txt_Codigo.Enabled)
            { MessageBox.Show("Debe guardar el vendedor para realizar esta operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else if (!_Txt_Codigo.Enabled & _Txt_Codigo.Text.Trim().Length == 0)
            { MessageBox.Show("No se ha seleccionado ningún vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else if (!_Chbox_Gerente.Checked & _Txt_Zona.Text.Trim().Length == 0)
            {
                if (MessageBox.Show("El vendedor no posee zonas asignadas. ¿Desea asignar alguna zona a este vendedor?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Frm_VendedoresSinZona _Frm = new Frm_VendedoresSinZona(_Txt_Codigo.Text.Trim(), _Cmb_Grupo.SelectedValue.ToString().Trim());
                    _Frm.MdiParent = this.MdiParent;
                    _Frm.Dock = DockStyle.Fill;
                    _Frm.Show();
                    _Bol_Zona = true;
                }
            }
            else if (_Chbox_Gerente.Checked)
            { MessageBox.Show("Debe seleccionar un vendedor y no un gerente de área para realizar esta operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private string _Mtd_Crear_Correo(string _P_Str_Nombre,string _P_Str_Apellido)
        {
            try
            {
                _Cls_EmailValidate.Ser_EmailValidate _Cls = new T3._Cls_EmailValidate.Ser_EmailValidate();
                _Cls.Url = CLASES._Cls_Conexion._G_Str_Url_Services;
                //----------------
                _P_Str_Nombre = _P_Str_Nombre.Trim() + " ";
                _P_Str_Nombre = _P_Str_Nombre.Substring(0, _P_Str_Nombre.IndexOf(" "));
                _P_Str_Apellido = _P_Str_Apellido.Trim() + " ";
                _P_Str_Apellido = _P_Str_Apellido.Substring(0, _P_Str_Apellido.IndexOf(" "));
                //----------------
                _P_Str_Nombre = _Mtd_Quitar_Signos(_P_Str_Nombre);
                _P_Str_Apellido = _Mtd_Quitar_Signos(_P_Str_Apellido);
                string _Str_Email = _P_Str_Nombre.ToUpper().Trim().Substring(0,1) + _P_Str_Apellido.ToUpper().Trim();
                bool _bol_Existe = true;
                int _Int_I = 1;
                string _Str_Cadena = "Select cdominioemail,cabreviado from TCOMPANY where ccompany='"+Frm_Padre._Str_Comp+"'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_Email = _Str_Email+"."+ _Ds.Tables[0].Rows[0][1].ToString().Trim().ToUpper() + "@" + _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
                    while (_bol_Existe)
                    {
                        if (!_Cls._Mtd_ValidarEmailUser(_Str_Email, Frm_Padre._Str_Comp, _Txt_Nombre.Text.Trim().ToUpper()+","+_Txt_Apellido.Text.Trim().ToUpper()))
                        {
                            _Str_Email = _P_Str_Nombre.ToUpper().Trim().Substring(0, 1) + _P_Str_Apellido.ToUpper().Trim() + _Int_I.ToString().Trim() + "@" + _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
                        }
                        else
                        { _bol_Existe = false; }
                        _Int_I++;
                    }
                    _Mtd_Agregar_Correo(false, _Str_Email.ToUpper());
                    _Txt_Email.Text = _Str_Email.ToUpper();
                    return _Str_Email.ToUpper();
                }
                else
                {
                    return "";
                }
            }
            catch {  return ""; }
        }
        private bool _Mtd_Eliminar_Correo(string _P_Str_Email)
        {
            //try
            //{
            //    if ((new _Cls_EmailValidate.Ser_EmailValidate()._Mtd_BorrarEmail(_P_Str_Email)))
            //    {
            //        _Mtd_Agregar_Correo(true, _P_Str_Email.ToUpper());
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //catch { return false; }
            return true;
        }
        private string _Mtd_Quitar_Signos(string _P_Str_Cadena)
        {
            string _Str_Consignos = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜÑçÇ";
            string _Str_Sinsignos = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUNcC";
            for (int _Int_I = 0; _Int_I < _Str_Sinsignos.Length; _Int_I++)
            {
                string _Str_I = _Str_Consignos.Substring(_Int_I, 1);
                string _Str_J = _Str_Sinsignos.Substring(_Int_I, 1);
                _P_Str_Cadena = _P_Str_Cadena.Replace(_Str_I, _Str_J);
            }
            return _P_Str_Cadena;
        }
        private void _Mtd_Agregar_Correo(bool _P_Bol_Eliminar,string _P_Str_Correo)
        {
            string _Str_Cadena = "Select ccreaemail1,ccreaemail2,ccreaemail3,ccreaemail4,ccreaemail5 from TCONFIGVENT where ccompany='"+Frm_Padre._Str_Comp+"'";
            string _Str_Cemailpara = "";
            string _Str_Casunto = "";
            string _Str_Ccuerpoms="";
            if (_P_Bol_Eliminar)
            { 
                _Str_Casunto = "ELIMINACIÓN DE CORREO";
                _Str_Ccuerpoms = "<font face=\"verdana\" size=\"2\"> T3, LA EMPRESA " + Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cname from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString().Trim().ToUpper() + ", SOLICITA LA ELIMINACIÓN DEL CORREO " + _P_Str_Correo.ToUpper().Trim() + " PARA EL USUARIO " + _Txt_Nombre.Text.Trim().ToUpper() + " " + _Txt_Apellido.Text.Trim().ToUpper() + "</font>";
            }
            else
            {
                _Str_Casunto = "CREACIÓN DE CORREO";
                _Str_Ccuerpoms = "<font face=\"verdana\" size=\"2\"> T3, LA EMPRESA " + Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cname from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString().Trim().ToUpper() + ", SOLICITA LA CREACIÓN DEL CORREO " + _P_Str_Correo.ToUpper().Trim() + " PARA EL USUARIO " + _Txt_Nombre.Text.Trim().ToUpper() + " " + _Txt_Apellido.Text.Trim().ToUpper() + "</font>";
            }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Rows = _Ds.Tables[0].Rows[0];
                bool _Bol_Sw = false;
                foreach (DataColumn _Col in _Ds.Tables[0].Columns)
                {
                    if (_Rows[_Col].ToString().Trim().Length > 0)
                    {
                        if (_Bol_Sw)
                        { _Str_Cemailpara = _Str_Cemailpara + ","; }
                        _Str_Cemailpara = _Str_Cemailpara + _Rows[_Col].ToString().Trim().ToUpper();
                        _Bol_Sw = true;
                    }
                }
                if (_Bol_Sw)
                {
                    _Str_Cadena = "Insert into TEMAIL (cproceso,cfecha,cemailpara,casunto,ccuepoms)values('NUEVO_CORREO','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Str_Cemailpara + "','" + _Str_Casunto + "','" + _Str_Ccuerpoms + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
            }
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (_Rbt_Ven_N.Checked)
            { _Rbt_Ven.Checked = true; }
            else if (_Rbt_Ger_N.Checked)
            { _Rbt_Ger.Checked = true; }
            else
            {
                MessageBox.Show("Debe seleccionar una opción", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            _Pnl_Nuevo.Visible = false;
            _Er_Error.Dispose();
            _Mtd_Ini();
            _Chbox_Activo.Checked = true;
            _Tb_Tab.SelectedIndex = 1;
            _Txt_Nombre.Focus();
                        //____________________________________________
            if (!_Txt_Nombre.Enabled & _Txt_Nombre.Text.Trim().Length > 0)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
            }
            else if (!_Txt_Codigo.Enabled & _Txt_Codigo.Text.Trim().Length > 0 & _Txt_Nombre.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
            }
            else if (_Txt_Codigo.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            }
            //_____________________________________________
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Nuevo.Visible = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            if (!_Txt_Nombre.Enabled & _Txt_Nombre.Text.Trim().Length > 0)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
            }
            else
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            }
        }

        private void _Pnl_Nuevo_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Nuevo.Visible)
            { _Tb_Tab.Enabled = false; _Rbt_Ven_N.Checked = false; _Rbt_Ger_N.Checked = false; }
            else
            { _Tb_Tab.Enabled = true; }
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_Txt_Nombre.Text.Trim().Length == 0 & !_Txt_Nombre.Enabled & e.TabPageIndex != 0)
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
        string _Str_GrupoVta = "";
        string _Str_GerenteActual = "";
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            webCamCapture1.Stop();
            if (_Dg_Grid.Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Er_Error.Dispose();
                _Mtd_Deshabilitar_Todo();
                _Pbox_Imagen.Image = null;
                _Txt_Zona.Text = "";
                _Txt_Codigo.Text =_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0,e.RowIndex);
                _Txt_Direccion.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(3, e.RowIndex);
                _Txt_Email.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(4, e.RowIndex);
                _Txt_Cod_Ger.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, e.RowIndex);
                _Str_GerenteActual = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(2, e.RowIndex).ToUpper().Trim();
                _Cmb_Grupo.SelectedValue = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(8, e.RowIndex);
                _Str_GrupoVta = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(8, e.RowIndex);
                string _Str_Cadena = "Select cname from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _Txt_Cod_Ger.Text + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_Gerente.Text = _Ds.Tables[0].Rows[0][0].ToString();
                    _Txt_Zona.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(12, e.RowIndex);
                }
                string[] _Str_Split = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, e.RowIndex).Split(new char[] { ',' });
                _Txt_Nombre.Text = _Str_Split[0].ToString().Trim();
                try
                {
                    _Txt_Apellido.Text = _Str_Split[1].ToString().Trim();
                }
                catch { }
                _Txt_Cedula.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("ccedula", e.RowIndex).Trim();
                ////////////////////
                _Str_Nombre_G = _Txt_Nombre.Text.Trim().ToUpper() + " ";
                _Str_Nombre_G = _Str_Nombre_G.Substring(0, _Str_Nombre_G.IndexOf(" "));
                _Str_Apellido_G = _Txt_Apellido.Text.Trim().ToUpper() + " ";
                _Str_Apellido_G = _Str_Apellido_G.Substring(0, _Str_Apellido_G.IndexOf(" "));
                ////////////////////
                try
                {
                    _Txt_Telefono.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(9, e.RowIndex).Substring(4);
                }
                catch { }
                try
                {
                    if (_Ctrl_Busqueda1._Mtd_RetornarStringCelda(9, e.RowIndex).Substring(0, 4) == "0414")
                    {
                        _Cb_Phone.SelectedValue = "414";
                    }
                    else if (_Ctrl_Busqueda1._Mtd_RetornarStringCelda(9, e.RowIndex).Substring(0, 4) == "0424")
                    {
                        _Cb_Phone.SelectedValue = "186";
                    }
                    else if (_Ctrl_Busqueda1._Mtd_RetornarStringCelda(9, e.RowIndex).Substring(0, 4) == "0416")
                    {
                        _Cb_Phone.SelectedIndex = 3;
                    }
                    else if (_Ctrl_Busqueda1._Mtd_RetornarStringCelda(9, e.RowIndex).Substring(0, 4) == "0412")
                    {
                        _Cb_Phone.SelectedIndex = 4;
                    }
                    else if (_Ctrl_Busqueda1._Mtd_RetornarStringCelda(9, e.RowIndex).Substring(0, 4) == "0426")
                    {
                        _Cb_Phone.SelectedIndex = 5;
                    }
                    else
                    {
                        _Cb_Phone.SelectedIndex = 0;
                    }
                }
                catch { }
                _Chbox_Activo.Checked = Convert.ToBoolean(Convert.ToInt32(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(5, e.RowIndex)));
                _Bol_Activo = _Chbox_Activo.Checked;
                if (_Ctrl_Busqueda1._Mtd_RetornarStringCelda(6, e.RowIndex) == "2")
                { _Chbox_Gerente.Checked = true; }
                else
                { _Chbox_Gerente.Checked = false; }
                _Str_Cadena = "Select c_foto from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex) + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    try
                    { _Pbox_Imagen.Image = _Mtd_convertirByteparaImage(((byte[])_Ds.Tables[0].Rows[0][0])); }
                    catch { }
                }
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_editar2.Enabled = _myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CREAR_VEND") & _Chbox_Activo.Checked;
                //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                _Tb_Tab.SelectedIndex = 1;
                Cursor = Cursors.Default;
            }
        }
        private void _Mtd_CargarGruposCambio()
        {
            string _Str_Sql = "SELECT DISTINCT RTRIM(TGRUPOVTAM.cgrupovta) AS cgrupovta, RTRIM(TGRUPOVTAM.cname) AS cname " +
           "FROM TGRUPPROVEE INNER JOIN " +
           "TGRUPOVTAM ON TGRUPPROVEE.cgrupovta = TGRUPOVTAM.cgrupovta " +
           "WHERE (TGRUPOVTAM.cdelete = 0) AND (TGRUPPROVEE.ccompany = '" + Frm_Padre._Str_Comp + "') AND NOT(TGRUPOVTAM.cname is null) " +
           "ORDER BY TGRUPOVTAM.cname";
            _myUtilidad._Mtd_CargarCombo(_Cmb_GrupoC, _Str_Sql);
        }
        private void _Mtd_CargarZonas(string _P_Str_GrupoVta)
        {
            string _Str_Sql = "Select c_zona, c_zona+' - '+cname from TZONAVENTA where ccompany='" + Frm_Padre._Str_Comp + "' AND cgrupovta='" + _P_Str_GrupoVta + "' and cdelete='0' AND c_zona<>'" + _Str_ZonaVendedor + "'";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Zona, _Str_Sql);
        }
        private bool _Mtd_VentasEnMesActual(string _P_Str_Vendedor, string _P_Str_Zona)
        {
            DateTime _Dtm_TempDes = new DateTime(Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())).Year, Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())).Month, 1);
            string _Str_Cadena = "SELECT * FROM TMOVINVENTAS WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cvendedor='" + _P_Str_Vendedor + "' AND c_zona='" + _P_Str_Zona + "' AND convert(datetime,convert(varchar(255),cdatemov,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dtm_TempDes) + "' AND GETDATE() AND cproducto<>'0' AND cnumdocu<>'0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_ZonaOcupada(string _P_Str_Zona)
        {
            string _Str_Cadena = "SELECT * FROM TZONAVENDEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND c_zona='" + _P_Str_Zona + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }
        public string[] _Mtd_NuevoCodigoParaVendedores()
        {
            string _St_Cadena = "SELECT cvendedor FROM TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor LIKE ('%_%') ORDER BY cast(replace(cvendedor,rtrim(ccompany)+'_','') as integer) DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_St_Cadena);
            int _Int_Codigo = _Mtd_Extraer_Codigo(_Ds.Tables[0].Rows[0][0].ToString().Trim());
            _Int_Codigo++;
            if (_Int_Codigo < 10)
            { return new string[] { Frm_Padre._Str_Comp.Trim() + "_0" + _Int_Codigo.ToString(), Frm_Padre._Str_Comp.Trim() + "_0" + Convert.ToString(_Int_Codigo + 1) }; }
            else
            { return new string[] { Frm_Padre._Str_Comp.Trim() + "_" + _Int_Codigo.ToString(), Frm_Padre._Str_Comp.Trim() + "_" + Convert.ToString(_Int_Codigo + 1) }; }
        }
        private bool _Mtd_ValidaInactivacion(string _Str_Vendedor, string _Str_Compania)
        {
            bool _Bol_Valor = true;
            try
            {
                string _Str_SentenciaSQL = "SELECT CPFACTURA FROM TPREFACTURAM WHERE CFACTURADO='0' AND CVENDEDOR='"+_Str_Vendedor+"' AND CCOMPANY='"+_Str_Compania+"'";
                DataSet _Ds_DataSet = new DataSet();
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Bol_Valor = false;
                }
                if (_Bol_Valor)
                {
                    _Str_SentenciaSQL = "SELECT CFACTURA FROM TFACTURAM WHERE C_ENTREGACLIENTE='0' AND C_FACT_ANUL='0' AND CVENDEDOR='" + _Str_Vendedor + "' AND CCOMPANY='" + _Str_Compania + "'";
                    _Ds_DataSet = new DataSet();
                    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                    if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                    {
                        _Bol_Valor = false;
                    }
                }
            }
            catch
            {
            }
            return _Bol_Valor;
        }
        int _Int_Sw_Mensaje = 0;
        private void _Mtd_CrearVendedores(string _P_Str_VendedorActual, string _P_Str_VendedorDeZona, string _P_Str_ZonaParaVendActual, string _P_Str_ZonaParaVenddeZona, string _P_Str_GerenteParaVendActual, string _P_Str_GerenteParaVendDeZona, string _P_Str_GrupoVtaParaVendActual, string _P_Str_GrupoVtaParaVendDeZona, bool _P_Bol_Intercambio, bool _P_Bol_Vendedor_Renuncio)
        {
            string _Str_Cadena = "";
            try
            {
                if (_P_Bol_Intercambio)
                {
                    //ELIMINO AMBOS VENDEDORES DE SUS RESPECTIVAS ZONAS
                    _Str_Cadena = "UPDATE TZONAVENDEDOR SET CDELETE='1',CDATEUPD=GETDATE() WHERE CVENDEDOR='" + _P_Str_VendedorDeZona + "' AND C_ZONA='" + _P_Str_ZonaParaVendActual + "' AND CDELETE='0' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "UPDATE TZONAVENDEDOR SET CDELETE='1',CDATEUPD=GETDATE() WHERE CVENDEDOR='" + _P_Str_VendedorActual + "' AND C_ZONA='" + _P_Str_ZonaParaVenddeZona + "' AND CDELETE='0' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                    //INGRESO LAS ZONAS NUEVAS A LOS VENDEDORES DESPUES DEL CAMBIO
                    _Str_Cadena = "SELECT CVENDEDOR FROM TZONAVENDEDOR WHERE CVENDEDOR='" + _P_Str_VendedorActual + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND C_ZONA='" + _P_Str_ZonaParaVendActual + "'";
                    DataSet _Ds_DataSet = new DataSet();
                    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                    {
                        _Str_Cadena = "UPDATE TZONAVENDEDOR SET CDELETE='0',CDATEUPD=GETDATE() WHERE CVENDEDOR='" + _P_Str_VendedorActual + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND C_ZONA='" + _P_Str_ZonaParaVendActual + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    else
                    {
                        _Str_Cadena = "INSERT INTO TZONAVENDEDOR (ccompany,c_zona,cvendedor,cdateadd,cuseradd,cdelete)VALUES('" + Frm_Padre._Str_Comp + "','" + _P_Str_ZonaParaVendActual + "','" + _P_Str_VendedorActual + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    _Str_Cadena = "SELECT CVENDEDOR FROM TZONAVENDEDOR WHERE CVENDEDOR='" + _P_Str_VendedorDeZona + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND C_ZONA='" + _P_Str_ZonaParaVenddeZona + "'";
                    _Ds_DataSet = new DataSet();
                    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);                    
                    if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                    {
                        _Str_Cadena = "UPDATE TZONAVENDEDOR SET CDELETE='0',CDATEUPD=GETDATE() WHERE CVENDEDOR='" + _P_Str_VendedorDeZona + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND C_ZONA='" + _P_Str_ZonaParaVenddeZona + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    else
                    {
                        _Str_Cadena = "INSERT INTO TZONAVENDEDOR (ccompany,c_zona,cvendedor,cdateadd,cuseradd,cdelete)VALUES('" + Frm_Padre._Str_Comp + "','" + _P_Str_ZonaParaVenddeZona + "','" + _P_Str_VendedorDeZona + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }

                    //MODIFICO LOS GRUPOS DE VTAS DE AMBOS VENDEDORES
                    _Str_Cadena = "SELECT cgrupovta FROM TZONAVENTA WHERE C_ZONA='" + _P_Str_ZonaParaVendActual + "' AND CDELETE='0' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                    
                    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    string _Str_GrupoVta = _Ds_DataSet.Tables[0].Rows[0][0].ToString().Trim();

                    _Str_Cadena = "UPDATE TVENDEDOR SET c_grupo_vta='" + _Str_GrupoVta + "',CDATEUPD=GETDATE() WHERE CVENDEDOR='" + _P_Str_VendedorActual + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                    _Str_Cadena = "SELECT cgrupovta FROM TZONAVENTA WHERE C_ZONA='" + _P_Str_ZonaParaVenddeZona + "' AND CDELETE='0' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                    _Ds_DataSet = new DataSet();
                    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    _Str_GrupoVta = _Ds_DataSet.Tables[0].Rows[0][0].ToString().Trim();

                    _Str_Cadena = "UPDATE TVENDEDOR SET c_grupo_vta='" + _Str_GrupoVta + "',CDATEUPD=GETDATE() WHERE CVENDEDOR='" + _P_Str_VendedorDeZona + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                else if (_P_Bol_Vendedor_Renuncio)
                {
                    if (_Mtd_ValidaInactivacion(_P_Str_VendedorDeZona, Frm_Padre._Str_Comp))
                    {
                        _Str_Cadena = "UPDATE TVENDEDOR SET c_activo='0',CDATEUPD=GETDATE(),cfechainact=GETDATE() WHERE CVENDEDOR='" + _P_Str_VendedorDeZona + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }

                    //ELIMINO AMBOS VENDEDORES DE SUS RESPECTIVAS ZONAS
                    _Str_Cadena = "UPDATE TZONAVENDEDOR SET CDELETE='1',CDATEUPD=GETDATE() WHERE CVENDEDOR='" + _P_Str_VendedorDeZona + "' AND C_ZONA='" + _P_Str_ZonaParaVendActual + "' AND CDELETE='0' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                    _Str_Cadena = "UPDATE TZONAVENDEDOR SET CDELETE='1',CDATEUPD=GETDATE() WHERE CVENDEDOR='" + _P_Str_VendedorActual + "' AND C_ZONA='" + _P_Str_ZonaParaVenddeZona + "' AND CDELETE='0' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                    //INGRESO LAS ZONAS NUEVAS A LOS VENDEDORES DESPUES DEL CAMBIO
                    _Str_Cadena = "SELECT CVENDEDOR FROM TZONAVENDEDOR WHERE CVENDEDOR='" + _P_Str_VendedorActual + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND C_ZONA='" + _P_Str_ZonaParaVendActual + "'";
                    DataSet _Ds_DataSet = new DataSet();
                    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                    {
                        _Str_Cadena = "UPDATE TZONAVENDEDOR SET CDELETE='0',CDATEUPD=GETDATE() WHERE CVENDEDOR='" + _P_Str_VendedorActual + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND C_ZONA='" + _P_Str_ZonaParaVendActual + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    else
                    {
                        _Str_Cadena = "INSERT INTO TZONAVENDEDOR (ccompany,c_zona,cvendedor,cdateadd,cuseradd,cdelete)VALUES('" + Frm_Padre._Str_Comp + "','" + _P_Str_VendedorActual + "','" + _P_Str_ZonaParaVendActual + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    //MODIFICO LOS GRUPOS DE VTAS DE AMBOS VENDEDORES
                    _Str_Cadena = "SELECT cgrupovta FROM TZONAVENTA WHERE C_ZONA='" + _P_Str_ZonaParaVendActual + "' AND CDELETE='0' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                   
                    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    string _Str_GrupoVta = _Ds_DataSet.Tables[0].Rows[0][0].ToString().Trim();

                    _Str_Cadena = "UPDATE TVENDEDOR SET c_grupo_vta='" + _Str_GrupoVta + "',CDATEUPD=GETDATE() WHERE CVENDEDOR='" + _P_Str_VendedorActual + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
            }
            catch
            {
            }      
        }
        private void _Mtd_CambiarZona(bool _P_Bol_Intercambio, bool _P_Bol_Vendedor_Renuncio)
        {
            //----------------------BUSCO VENDEDOR DE LA ZONA QUE FUE ELEGIDA
            string _Str_VendedorDeNuevaZona = "";
            string _Str_Cadena = "SELECT cvendedor FROM TZONAVENDEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' and c_zona='" + _Cmb_Zona.SelectedValue.ToString().Trim() + "' and cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { _Str_VendedorDeNuevaZona = _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
            string _Str_GrupoVtaVendedor = "";
            _Str_Cadena = "SELECT c_grupo_vta FROM TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cvendedor='" + _Txt_Codigo.Text.Trim() + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Str_GrupoVtaVendedor = _Ds.Tables[0].Rows[0][0].ToString().Trim();
            _Mtd_CrearVendedores(_Txt_Codigo.Text.Trim(), _Str_VendedorDeNuevaZona, _Cmb_Zona.SelectedValue.ToString().Trim(), _Str_ZonaVendedor, _Txt_GerenteC.Tag.ToString().Trim(), _Txt_GerenteO.Tag.ToString().Trim(), _Cmb_GrupoC.SelectedValue.ToString().Trim(), _Str_GrupoVtaVendedor, _P_Bol_Intercambio, _P_Bol_Vendedor_Renuncio);
        }
        private void _Mtd_CambiarZona()
        {
            //ELIMINO EL VENDEDOR DE SU ZONA ACTUAL
            string _Str_Cadena = "UPDATE TZONAVENDEDOR SET CDELETE='1',CDATEUPD=GETDATE() WHERE CVENDEDOR='" + _Txt_Codigo.Text + "' AND CDELETE='0' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            

            //INGRESO EL VENDEDOR A SU ZONA NUEVA
            _Str_Cadena = "SELECT CVENDEDOR FROM TZONAVENDEDOR WHERE CVENDEDOR='" + _Txt_Codigo.Text + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND C_ZONA='" + _Cmb_Zona.SelectedValue.ToString().Trim() + "'";
            DataSet _Ds_DataSet = new DataSet();
            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
            {
                _Str_Cadena = "UPDATE TZONAVENDEDOR SET CDELETE='0',CDATEUPD=GETDATE() WHERE CVENDEDOR='" + _Txt_Codigo.Text + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "' AND C_ZONA='" + _Cmb_Zona.SelectedValue.ToString().Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            else
            {
                _Str_Cadena = "INSERT INTO TZONAVENDEDOR (ccompany,c_zona,cvendedor,cdateadd,cuseradd,cdelete)VALUES('" + Frm_Padre._Str_Comp + "','" + _Cmb_Zona.SelectedValue.ToString().Trim() + "','" + _Txt_Codigo.Text + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
           //MODIFICO EL GRUPO DE VTA DEL ASESOR
            _Str_Cadena = "UPDATE TVENDEDOR SET c_grupo_vta='" + _Cmb_GrupoC.SelectedValue.ToString().Trim() + "',CDATEUPD=GETDATE() WHERE CVENDEDOR='" + _Txt_Codigo.Text + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

        }
        private string _Mtd_Mensaje()
        {
            string _Str_Cadena = "";
            string _Str_Mensaje = "La operación ha sido realizada correctamente. \n ";
            //_Str_Cadena = "SELECT cname FROM TVENDEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cvendedor='" + _P_Str_Parametros[0] + "'";
            //DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //string _Str_NameVendedorActual = _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            //if (_Int_Sw_Mensaje == 1)
            //{
            //    _Str_Mensaje += "El nuevo código para el vendedor " + _Str_NameVendedorActual + " es (" + _P_Str_Parametros[0] + ")";
            //    _Str_Cadena = "SELECT cname FROM TVENDEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cvendedor='" + _P_Str_Parametros[1] + "'";
            //    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //    _Str_Mensaje += "\n El nuevo código para el vendedor " + _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper() + " es (" + _P_Str_Parametros[1] + ")";
            //}
            //else if (_Int_Sw_Mensaje == 2 | _Int_Sw_Mensaje == 5)
            //{
            //    _Str_Mensaje += "El nuevo código para el vendedor " + _Str_NameVendedorActual + " es (" + _P_Str_Parametros[0] + ")";
            //}
            //else if (_Int_Sw_Mensaje == 3)
            //{
            //    _Str_Mensaje += "El nuevo código para el vendedor " + _Str_NameVendedorActual + " es (" + _P_Str_Parametros[0] + ")";
            //    _Str_Cadena = "SELECT cname FROM TVENDEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cvendedor='" + _P_Str_Parametros[1] + "'";
            //    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //    _Str_Mensaje += "\n El código para el vendedor " + _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper() + " sigue siendo (" + _P_Str_Parametros[1] + ")";
            //}
            //else if (_Int_Sw_Mensaje == 4)
            //{
            //    _Str_Mensaje += "El código para el vendedor " + _Str_NameVendedorActual + " sigue siendo (" + _P_Str_Parametros[0] + ")";
            //    _Str_Cadena = "SELECT cname FROM TVENDEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cvendedor='" + _P_Str_Parametros[1] + "'";
            //    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //    _Str_Mensaje += "\n El nuevo código para el vendedor " + _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper() + " es (" + _P_Str_Parametros[1] + ")";
            //}
            //else if (_Int_Sw_Mensaje == 6 | _Int_Sw_Mensaje == 8)
            //{
            //    _Str_Mensaje += "El código para el vendedor " + _Str_NameVendedorActual + " sigue siendo (" + _P_Str_Parametros[0] + ")";
            //}
            //else if (_Int_Sw_Mensaje == 7)
            //{
            //    _Str_Mensaje += "El código para el vendedor " + _Str_NameVendedorActual + " sigue siendo (" + _P_Str_Parametros[0] + ")";
            //    _Str_Cadena = "SELECT cname FROM TVENDEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cvendedor='" + _P_Str_Parametros[1] + "'";
            //    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //    _Str_Mensaje += "\n El código para el vendedor " + _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper() + " sigue siendo (" + _P_Str_Parametros[1] + ")";
            //}
            return _Str_Mensaje;
        }
        string _Str_ZonaVendedor = "";
        private void _Bt_Cambiar_Click(object sender, EventArgs e)
        {
            if (!_Txt_Nombre.Enabled & _Txt_Nombre.Text.Trim().Length > 0)
            {
                if (_Rbt_Ven.Checked)
                {
                    string _Str_Cadena = "Select c_zona from TZONAVENDEDOR where cvendedor='" + _Txt_Codigo.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        //---------------------------------------
                        _Str_ZonaVendedor = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                        _Mtd_CargarGruposCambio();
                        _Str_Cadena = "SELECT TVENDEDOR.cvendedor, TVENDEDOR.cvendedor+' - '+TVENDEDOR.cname FROM TVENDEDOR INNER JOIN TVENDEDOR AS TVENDEDOR_1 ON dbo.TVENDEDOR.cvendedor = TVENDEDOR_1.cgerarea WHERE TVENDEDOR_1.ccompany='" + Frm_Padre._Str_Comp + "' and TVENDEDOR_1.cvendedor='" + _Txt_Codigo.Text.Trim() + "' AND TVENDEDOR_1.c_tipo_vend='1' AND TVENDEDOR_1.cdelete='0'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            _Txt_GerenteC.Tag = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                            _Txt_GerenteC.Text = _Ds.Tables[0].Rows[0][1].ToString().Trim();
                        }
                        _Pnl_Cambiar.Visible = true;
                        //---------------------------------------
                    }
                    else
                    {
                        if (MessageBox.Show("El vendedor no posee zonas asignadas. ¿Desea asignar alguna zona a este vendedor?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            Frm_VendedoresSinZona _Frm = new Frm_VendedoresSinZona(_Txt_Codigo.Text.Trim(), _Cmb_Grupo.SelectedValue.ToString().Trim());
                            _Frm.MdiParent = this.MdiParent;
                            _Frm.Show();
                            _Bol_Zona = true;
                        }
                    }
                }
                else
                { MessageBox.Show("Debe seleccionar un vendedor y no un gerente de área para realizar esta operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else if (!_Txt_Codigo.Enabled & _Txt_Codigo.Text.Trim().Length > 0 & _Txt_Nombre.Enabled)
            {
                MessageBox.Show("No puede realizar esta operación mientras esta editando un vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_Txt_Codigo.Enabled)
            { MessageBox.Show("Debe guardar el vendedor para realizar esta operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else if (!_Txt_Codigo.Enabled & _Txt_Codigo.Text.Trim().Length == 0)
            { MessageBox.Show("No se ha seleccionado ningún vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Bt_BuscarC_Click(object sender, EventArgs e)
        {
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(55, _Txt_GerenteC, 0, "");
            _Frm.ShowDialog();
            if (_Txt_GerenteC.Text.Trim().Length > 0)
            { _Txt_GerenteC.Text = Convert.ToString(_Txt_GerenteC.Tag) + " - " + _Txt_GerenteC.Text.Trim(); }
        }

        private void _Bt_CerrarC_Click(object sender, EventArgs e)
        {
            _Pnl_Cambiar.Visible = false;
        }

        private void _Cmb_GrupoC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_GrupoC.SelectedIndex <= 0)
            { _Cmb_Zona.DataSource = null; _Cmb_Zona.Enabled = false; }
            else
            { _Cmb_Zona.Enabled = true; _Mtd_CargarZonas(_Cmb_GrupoC.SelectedValue.ToString().Trim()); }
        }

        private void _Bt_AceptarC_Click(object sender, EventArgs e)
        {
            if (_Cmb_GrupoC.SelectedIndex > 0 & _Cmb_Zona.SelectedIndex > 0 & _Txt_GerenteC.Text.Trim().Length > 0)
            {
                if (MessageBox.Show("Esta seguro de realizar esta operación", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_Mtd_ZonaOcupada(_Cmb_Zona.SelectedValue.ToString().Trim()))
                    {
                        string _Str_Cadena = "SELECT cvendedor FROM TZONAVENDEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND c_zona='" + _Cmb_Zona.SelectedValue.ToString().Trim() + "' AND cdelete='0'";
                        DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            _Str_Cadena = "SELECT TVENDEDOR.cvendedor, TVENDEDOR.cvendedor+' - '+TVENDEDOR.cname, TVENDEDOR_1.cvendedor+' - '+TVENDEDOR_1.cname FROM TVENDEDOR INNER JOIN TVENDEDOR AS TVENDEDOR_1 ON dbo.TVENDEDOR.cvendedor = TVENDEDOR_1.cgerarea WHERE TVENDEDOR_1.ccompany='" + Frm_Padre._Str_Comp + "' and TVENDEDOR_1.cvendedor='" + _Ds.Tables[0].Rows[0][0].ToString().Trim() + "' AND TVENDEDOR_1.c_tipo_vend='1' AND TVENDEDOR_1.cdelete='0'";
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                _Txt_GerenteO.Tag = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                                _Txt_GerenteO.Text = _Ds.Tables[0].Rows[0][1].ToString().Trim();
                                _Txt_VendedorO.Text = _Ds.Tables[0].Rows[0][2].ToString().Trim().ToUpper();
                            }
                        }
                        _Lbl_ZonaO.Text = "Zona (" + _Cmb_Zona.SelectedValue.ToString().Trim() + ") Ocupada (elija opción)";
                        _Pnl_ZonaOcupada.BringToFront();
                        _Pnl_ZonaOcupada.Visible = true;
                    }
                    else
                    {
                        _Mtd_CambiarZona();
                        string _Str_Mensaje = _Mtd_Mensaje();
                        MessageBox.Show(_Str_Mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
                        { _Mtd_Actualizar_Ven(Frm_Padre._Str_Use); }
                        else
                        { _Mtd_Actualizar_Ven(); }
                        _Tb_Tab.SelectedIndex = 0;
                        _Pnl_Cambiar.Visible = false;
                    }
                }
                else
                { _Pnl_Cambiar.Visible = false; }
            }
            else
            { MessageBox.Show("Faltan datos para realizar la operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void _Pnl_Cambiar_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Cambiar.Visible)
            { 
                _Tb_Tab.Enabled = false;
                _Cmb_GrupoC.Focus(); 
            }
            else
            { _Tb_Tab.Enabled = true; }
        }

        private void _Pnl_ZonaOcupada_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_ZonaOcupada.Visible)
            {
                _Pnl_Cambiar.Enabled = false;
                _Tb_Tab.Enabled = false; 
                _Rb_Ren.Checked = false;
                _Rb_Inter.Checked = false;
            }
            else
            {
                _Pnl_Cambiar.Enabled = true;
                _Tb_Tab.Enabled = true; 
            }
        }

        private void _Bt_CerrarO_Click(object sender, EventArgs e)
        {
            _Pnl_ZonaOcupada.Visible = false;
        }

        private void _Bt_BuscarO_Click(object sender, EventArgs e)
        {
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(55, _Txt_GerenteO, 0, "");
            _Frm.ShowDialog();
            if (_Txt_GerenteO.Text.Trim().Length > 0)
            { _Txt_GerenteO.Text = Convert.ToString(_Txt_GerenteO.Tag) + " - " + _Txt_GerenteO.Text.Trim(); }
        }

        private void _Bt_AceptarO_Click(object sender, EventArgs e)
        {
            if (_Rb_Ren.Checked | _Rb_Inter.Checked)
            {
                _Mtd_CambiarZona(_Rb_Inter.Checked, _Rb_Ren.Checked);
                string _Str_Mensaje = _Mtd_Mensaje();
                MessageBox.Show(_Str_Mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
                { _Mtd_Actualizar_Ven(Frm_Padre._Str_Use); }
                else
                { _Mtd_Actualizar_Ven(); }
                _Tb_Tab.SelectedIndex = 0;
                _Pnl_Cambiar.Visible = false;
                _Pnl_ZonaOcupada.Visible = false;
            }
            else
            { MessageBox.Show("Debe seleccionar una opción", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void _Txt_Cedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Cedula_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Cedula.Text))
            {
                _Txt_Cedula.Text = "";
            }
        }

        private void _Chbox_Activo_CheckedChanged(object sender, EventArgs e)
        {
            _Bt_Zona.Enabled = _Chbox_Activo.Checked;
            _Bt_Ruta.Enabled = _Chbox_Activo.Checked;
            _Bt_Cuota.Enabled = _Chbox_Activo.Checked;
            _Bt_Cambiar.Enabled = _Chbox_Activo.Checked;
        }

        private void _Chk_Act_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Ven.Checked)
            {
                if (CLASES._Cls_Varios_Metodos._Mtd_GetUserIsGerArea(Frm_Padre._Str_Use))
                {
                    _Mtd_Actualizar_Ven(Frm_Padre._Str_Use);
                }
                else
                {
                    _Mtd_Actualizar_Ven();
                }

                _Chbox_Gerente.Checked = false; _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                this.Text = "Vendedores";
            }
            else
            {
                _Mtd_Actualizar_Ger(); _Chbox_Gerente.Checked = true; _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                this.Text = "Gerentes de Área";
            }
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
        }
    }
}