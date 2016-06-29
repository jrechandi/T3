using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace T3
{
    public partial class Frm_UsuarioAdmin : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        string _Str_MyProceso = "";
        public Frm_UsuarioAdmin()
        {
            InitializeComponent();
            _Mtd_Preparar();
        }
        public Frm_UsuarioAdmin(string _P_Str_Cod_Vend)
        {
            InitializeComponent();
            _Mtd_Preparar();
            _Txt_Usuario.Text = _P_Str_Cod_Vend;
            string _Str_Cadena = "Select cuser,cname,cposition,cemail,cphone1,cphone2,cpassw,cexpire,sexo,cadmin,c_soporte,cvendedor,ccproveedor,cnotas,cgroup,cfirmante,cimg,ccedula,cloginrestricexep from TUSER where cuser='" + _P_Str_Cod_Vend + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                _Txt_Usuario.Text = _Row["cuser"].ToString();
                _Txt_Nombre.Text = _Row["cname"].ToString();
                _Txt_Cedula.Text = _Row["ccedula"].ToString();
                _Cmb_Cargos.SelectedValue = _Row["cposition"].ToString();
                _Txt_Vendedor.Text = _Row["cvendedor"].ToString();
                _Txt_Telefono2.Text = _Row["cphone2"].ToString();
                _Txt_Telefono1.Text = _Row["cphone1"].ToString();
                _Txt_Email.Text = _Row["cemail"].ToString();
                if (_Row["cexpire"] != System.DBNull.Value)
                {
                    _Dtp_Expiracion.Value = Convert.ToDateTime(_Row["cexpire"].ToString());
                }
                _Cmb_Sex.SelectedValue = _Row["sexo"].ToString();
                if (_Row["cadmin"] != System.DBNull.Value)
                { _Chbox_Admin.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["cadmin"].ToString())); }
                if (_Row["c_soporte"] != System.DBNull.Value)
                { _Chbox_Sopor.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["c_soporte"].ToString())); }
                _Txt_Proveedor.Text = _Row["ccproveedor"].ToString();
                _Txt_Nota.Text = _Row["cnotas"].ToString();
                _Cmb_Grupo.SelectedValue = _Row["cgroup"].ToString();
                if (_Row["cfirmante"] != System.DBNull.Value)
                { _Chbox_Firmante.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["cfirmante"].ToString())); }
                if (_Row["cloginrestricexep"] != System.DBNull.Value)
                { _Chbox_Excepcion.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["cloginrestricexep"].ToString())); }
                try
                { _Pbox_Imagen.Image = _Mtd_convertirByteparaImage(((byte[])_Row["cimg"])); }
                catch { }
                _Mtd_DeListaLista();
                _Mtd_Cargar_Chlists();
            }
            _Tb_Tab.SelectedIndex = 1;
        }
        ListBox _Lst_Lista = new ListBox();
        string[] _Str_Comp;
        private void _Mtd_DeListaLista()
        {
            //---------------------------
            _Lis1.Items.Clear();
            _lis2.Items.Clear();
            _Lst_Lista.Items.Clear();
            int _Int_i = 0;
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT TCOMPANY.cname " +
"FROM TUSERCOMP INNER JOIN " +
"TCOMPANY ON TUSERCOMP.ccompany = TCOMPANY.ccompany " +
"WHERE TUSERCOMP.cuser = '" + _Txt_Usuario.Text + "'");
            foreach (DataRow _Row in _Ds_Data.Tables[0].Rows)
            {
                _lis2.Items.Add(_Row["cname"].ToString());
            }
            _Int_i = _Ds_Data.Tables[0].Rows.Count;
            _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select ccompany,cname from TCOMPANY where cdelete='0'");
            foreach (DataRow _Row in _Ds_Data.Tables[0].Rows)
            {
                bool _Bl_Exist = false;
                foreach (object _Ob in _lis2.Items)
                {
                    if (_Ob.ToString() == _Row["cname"].ToString())
                    { _Bl_Exist = true; }
                }
                if (!_Bl_Exist)
                {
                    _Lis1.Items.Add(_Row["cname"].ToString());
                }

            }
            //----------------------------------------
            _Int_i = _Int_i + _Ds_Data.Tables[0].Rows.Count;
            _Str_Comp = new string[_Int_i];
            _Int_i = 0;
            //-------------------------------------------------------------------------
            _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select ccompany,cname from TCOMPANY where cdelete='0'");
            foreach (DataRow _Row in _Ds_Data.Tables[0].Rows)
            {
                _Lst_Lista.Items.Add(_Row["cname"].ToString());
                _Str_Comp[_Int_i] = _Row["ccompany"].ToString();
                _Int_i++;
            }
            _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT TCOMPANY.ccompany,TCOMPANY.cname " +
"FROM TUSERCOMP INNER JOIN " +
"TCOMPANY ON TUSERCOMP.ccompany = TCOMPANY.ccompany " +
"WHERE TUSERCOMP.cuser = '" + _Txt_Usuario.Text + "'");
            foreach (DataRow _Row in _Ds_Data.Tables[0].Rows)
            {
                _Lst_Lista.Items.Add(_Row["cname"].ToString());
                _Str_Comp[_Int_i] = _Row["ccompany"].ToString();
                _Int_i++;
            }
            if (_Lis1.Items.Count > 0 | _lis2.Items.Count > 0)
            {
                _Bt_Add.Enabled = true;
                _Bt_Rem.Enabled = true;

            }
            //----------------------------------------
        }
        private void _Mtd_GuardarCompaÒia()
        {
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia("Delete from TUSERCOMP where cuser='" + _Txt_Usuario.Text + "' and cdelete='0'");
            int _Int_i = 0;
            foreach (object _Ob_ in _lis2.Items)
            {
                _Int_i = 0;
                foreach (object _Ob2_ in _Lst_Lista.Items)
                {
                    if (_Ob_.ToString() == _Ob2_.ToString())
                    {
                        break;
                    }
                    _Int_i++;
                }
                _Lst_Lista.SelectedIndex = _Int_i;
                Program._MyClsCnn._mtd_conexion._Mtd_Insertar("TUSERCOMP", "cuser,ccompany,cdateadd,cuseradd,cdelete", "'" + _Txt_Usuario.Text.Trim().ToUpper() + "','" + _Str_Comp[_Lst_Lista.SelectedIndex].ToString() + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0'");
            }
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
                string _Str_Cadena = "cuser='" + _Txt_Usuario.Text + "' and cdelete='0'";
                cmdInsert = new SqlCommand("UPDATE TUSER Set cimg=@cimg where " + _Str_Cadena, con);
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
            System.IO.MemoryStream _ms = new System.IO.MemoryStream(_by_imageBuffer);
            Image _img_h = Image.FromStream(_ms);
            return _img_h;
        }
        private void _Mtd_Cargar_Chlists()
        {
            _Clis1.Items.Clear();
            string _Str_Cadena = "Select cprocesofirma,cdescripcion from TPROCEFIRMAM where not exists(Select cprocesofirma from TPROCEFIRMAD where TPROCEFIRMAM.cprocesofirma=TPROCEFIRMAD.cprocesofirma AND cuser='" + _Txt_Usuario.Text.Trim() + "') ORDER BY cdescripcion";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Clis1.Items.Add(_Row[1].ToString().Trim().ToUpper() + "-------(" + _Row[0].ToString().Trim() + ")");
            }
            _Clis2.Items.Clear();
            _Str_Cadena = "SELECT TPROCEFIRMAD.cprocesofirma, TPROCEFIRMAM.cdescripcion " +
"FROM TPROCEFIRMAD INNER JOIN " +
"TPROCEFIRMAM ON TPROCEFIRMAD.cprocesofirma = TPROCEFIRMAM.cprocesofirma where TPROCEFIRMAD.cuser='" + _Txt_Usuario.Text.Trim() + "' ORDER BY TPROCEFIRMAM.cdescripcion";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Clis2.Items.Add(_Row[1].ToString().Trim().ToUpper() + "-------(" + _Row[0].ToString().Trim() + ")");
            }
        }
        private void _Mtd_Refrescar_Chlists()
        {
            _Clis1.Items.Clear();
            _Clis2.Items.Clear();
            string _Str_Cadena = "Select cprocesofirma,cdescripcion from TPROCEFIRMAM";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Clis1.Items.Add(_Row[1].ToString().Trim() + "-(" + _Row[0].ToString().Trim() + ")");
            }
        }
        private string _Mtd_Extraer_Codigo(string _P_Str_Items)
        {
            int _Int_i = _P_Str_Items.Trim().IndexOf("(");
            return _P_Str_Items.Substring(_Int_i + 1).Trim().Remove((_P_Str_Items.Length - _Int_i - 2));
        }
        public void _Mtd_Cargar()
        {
            _Cmb_Grupo.DataSource = null;
            DataSet _Ds;
                //--------------------------------------
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cgroup,cname from TGROUP where cdelete='0' ORDER BY cname ASC");
            _Cmb_Grupo.DataSource = _Ds.Tables[0];
            _Cmb_Grupo.DisplayMember = "cname";
            _Cmb_Grupo.ValueMember = "cgroup";
            _Cmb_Grupo.SelectedIndex = -1;
            //----------------------------------
            _Cmb_Sex.DataSource = null;
            _Cmb_Sex.DataSource = _Mtd_Comb_Sex().Tables[0];
            _Cmb_Sex.DisplayMember = "descripcion";
            _Cmb_Sex.ValueMember = "clave";
            _Cmb_Sex.SelectedIndex = -1;
        }
        private void _Mtd_cargar_Grupo()
        {
            _Cmb_Grupo.DataSource = null;
            DataSet _Ds;
            //--------------------------------------
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cgroup,cname from TGROUP where cdelete='0' ORDER BY cname ASC");
            _Cmb_Grupo.DataSource = _Ds.Tables[0];
            _Cmb_Grupo.DisplayMember = "cname";
            _Cmb_Grupo.ValueMember = "cgroup";
            _Cmb_Grupo.SelectedIndex = -1;
        }
        public DataSet _Mtd_Comb_Sex()
        {
           DataSet _Ds_=new DataSet();
           _Ds_.Tables.Add("Tabla");
            _Ds_.Tables[0].Columns.Add("clave");
            _Ds_.Tables[0].Columns.Add("descripcion");
            DataRow _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["clave"] = "0";
            _DRow_["descripcion"] = "Masculino";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["clave"] = "1";
            _DRow_["descripcion"] = "Femenino";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            return _Ds_;

        }
        private void _Mtd_CargarCargos()
        {
            string _Str_Sql = "SELECT cidcargonom,UPPER(cdescripcion) FROM TCARGOSNOM WHERE cdelete='0' ORDER BY cdescripcion";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Cargos, _Str_Sql);
        }
        private void _Mtd_Color_Estandar(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Color_Estandar(_Ctrl);
                }
                new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco();
            }
        }
        private void _Mtd_Preparar()
        {
            webCamCapture1.CaptureHeight = _Pbox_Imagen.Height;
            webCamCapture1.CaptureWidth = _Pbox_Imagen.Width;
            _Mtd_Actualizar();
            _Mtd_Cargar();
            _Mtd_CargarCargos();
            _Mtd_DeListaLista();
            _Mtd_Refrescar_Chlists();
            _Mtd_Color_Estandar(this);
        }

        private void _Mtd_Actualizar()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Usuario");
            _Tsm_Menu[1] = new ToolStripMenuItem("Nombre");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cuser";
            _Str_Campos[1] = "cname";
            
            string _Str_Cadena = "select cuser as Usuario, cname as Nombre from VST_USERCOMP where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and clocked = '" + Convert.ToInt32(!_Chk_UsuarioActivo.Checked).ToString() + "'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Usuarios", _Tsm_Menu, _Dg_Grid, true, "");
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void webCamCapture1_ImageCaptured(object source, WebCam_Capture.WebcamEventArgs e)
        {
            _Pbox_Imagen.Image = e.WebCamImage;
        }
        private void _Bt_Add_Click(object sender, EventArgs e)
        {
            if (_Lis1.Items.Count > 0)
            {
                if (_Lis1.SelectedIndex >= 0)
                {
                    _lis2.Items.Add(_Lis1.SelectedItem);
                    _Lis1.Items.Remove(_Lis1.SelectedItem);
                }
            }
        }

        private void _Bt_Rem_Click(object sender, EventArgs e)
        {
            if (_lis2.Items.Count > 0)
            {
                if (_lis2.SelectedIndex >= 0)
                {
                    _Lis1.Items.Add(_lis2.SelectedItem);
                    _lis2.Items.Remove(_lis2.SelectedItem);
                }
            }
        }
        private void _Bt_Guar_Comp_Click(object sender, EventArgs e)
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

        private void _Bt_Guar_Click(object sender, EventArgs e)
        {
            _Mtd_Guardar_Imagen();
        }

        private void _Bt_Agre_Click(object sender, EventArgs e)
        {
            if (_Txt_Usuario.Text.Trim().Length > 0)
            {
                Cursor = Cursors.WaitCursor;
                string _Str_Cadena = "Select * from TUSER where cuser='" + _Txt_Usuario.Text + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                DataSet _Ds2 = new DataSet();
                if (_Ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Debe guardar el usuario pararealizar esta operaciÛn", "InformaciÛn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (object _Ob in _Clis1.CheckedItems)
                    {
                        string _Str_Clave = _Mtd_Extraer_Codigo(_Ob.ToString());
                        _Str_Cadena = "Select * from TPROCEFIRMAD where cprocesofirma='" + _Str_Clave + "' and cuser='" + _Txt_Usuario.Text.Trim() + "'";
                        _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds2.Tables[0].Rows.Count == 0)
                        {
                            _Str_Cadena = "insert into TPROCEFIRMAD (cprocesofirma,cuser) values('" + _Str_Clave + "','" + _Txt_Usuario.Text.Trim() + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                    _Mtd_Cargar_Chlists();
                }
                Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Faltan datos para relizar esta operaciÛn pararealizar esta operaciÛn", "InformaciÛn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Bt_Quit_Click(object sender, EventArgs e)
        {
            if (_Txt_Usuario.Text.Trim().Length > 0)
            {
                Cursor = Cursors.WaitCursor;
                string _Str_Cadena = "Select * from TUSER where cuser='" + _Txt_Usuario.Text + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                DataSet _Ds2 = new DataSet();
                if (_Ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Debe guardar el usuario pararealizar esta operaciÛn", "InformaciÛn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (object _Ob in _Clis2.CheckedItems)
                    {
                        string _Str_Clave = _Mtd_Extraer_Codigo(_Ob.ToString());
                        _Str_Cadena = "Delete from TPROCEFIRMAD where cprocesofirma='" + _Str_Clave + "' and cuser='" + _Txt_Usuario.Text.Trim() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    _Mtd_Cargar_Chlists();
                }
                Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Faltan datos para relizar esta operaciÛn pararealizar esta operaciÛn", "InformaciÛn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void _Mtd_Ini()
        {
            _Txt_Email.Text = "";
            _Txt_Nombre.Text = "";
            _Txt_Cedula.Text = "";
            _Txt_Nota.Text = "";
            _Txt_Proveedor.Text = "";
            _Txt_Telefono1.Text = "";
            _Txt_Telefono2.Text = "";
            _Txt_Usuario.Text = "";
            _Txt_Vendedor.Text = "";
            _Txt_Apellido.Text = "";
            this.Text = "AdministraciÛn de usuarios";
            _Lis1.Items.Clear();
            _lis2.Items.Clear();
            _Dtp_Expiracion.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Chbox_Admin.Checked = false;
            _Chbox_Sopor.Checked = false;
            _Chbox_Firmante.Checked = false;
            _Chbox_Excepcion.Checked = false;
            _Chbox_T3Web.Checked = false;
            _Pbox_Imagen.Image = null;
            _Mtd_Cargar();
            _Mtd_CargarCargos();
            _Mtd_DeListaLista();
            _Mtd_Refrescar_Chlists();
            _Mtd_Habilitar();
            _Txt_Usuario.Enabled = true;
            _Str_MyProceso = "";
        }
        public void _Mtd_Habilitar()
        {
            _Txt_Usuario.Enabled = false;
            _Txt_Email.Enabled = true;
            _Txt_Nombre.Enabled = true;
            _Txt_Cedula.Enabled = true;
            _Txt_Nota.Enabled = true;
            _Txt_Proveedor.Enabled = true;
            _Txt_Apellido.Enabled = true;
            _Txt_Telefono1.Enabled = true;
            _Txt_Telefono2.Enabled = true;
            _Txt_Vendedor.Enabled = true;
            if (_Chbox_Admin.Checked)
            {
                _Txt_Email.ReadOnly = false;
            }
            else
            {
                _Txt_Email.ReadOnly = true;
            }
            _Bt_Add.Enabled = true;
            _Bt_Rem.Enabled = true;
            _Bt_Ini.Enabled = true;
            _Bt_Det.Enabled = true;
            _Bt_Quit.Enabled = true;
            _Bt_Agre.Enabled = true;
            _Lis1.Enabled = true;
            _lis2.Enabled = true;
            _Clis1.Enabled = true;
            _Clis2.Enabled = true;
            _Cmb_Cargos.Enabled = true;
            _Cmb_Grupo.Enabled = true;
            _Cmb_Sex.Enabled = true;
            _Dtp_Expiracion.Enabled = true;
            _Chbox_Firmante.Enabled = true;
            _Chbox_Excepcion.Enabled = true;
            _Chbox_Sopor.Enabled = true;
            _Chbox_Admin.Enabled = true;
            _Chbox_T3Web.Enabled = true;
            _Str_MyProceso = "M";
        }
        private void _Mtd_Deshabilitar_Todo()
        {
            _Txt_Usuario.Enabled = false;
            _Txt_Email.Enabled = false;
            _Txt_Nombre.Enabled = false;
            _Txt_Cedula.Enabled = false;
            _Txt_Nota.Enabled = false;
            _Txt_Proveedor.Enabled = false;
            _Bt_Ini.Enabled = false;
            _Bt_Det.Enabled = false;
            _Txt_Apellido.Enabled = false;
            _Txt_Telefono1.Enabled = false;
            _Txt_Telefono2.Enabled = false;
            _Txt_Vendedor.Enabled = false;
            _Bt_Add.Enabled = false;
            _Bt_Rem.Enabled = false;
            _Lis1.Enabled = false;
            _lis2.Enabled = false;
            _Bt_Quit.Enabled = false;
            _Bt_Agre.Enabled = false;
            _Clis1.Enabled = false;
            _Clis2.Enabled = false;
            _Cmb_Cargos.Enabled = false;
            _Cmb_Grupo.Enabled = false;
            _Cmb_Sex.Enabled = false;
            _Dtp_Expiracion.Enabled = false;
            _Chbox_Firmante.Enabled = false;
            _Chbox_Excepcion.Enabled = false;
            _Chbox_Sopor.Enabled = false;
            _Chbox_Admin.Enabled = false;
            _Chbox_T3Web.Enabled = false;
        }
        public void _Mtd_Nuevo()
        {
            _Er_Error.Dispose();
            _Mtd_Ini();
            _Txt_Usuario.Focus();
            _Txt_Usuario.MaxLength = 15;
            _Str_MyProceso = "N";
            _Tb_Tab.SelectedIndex = 1;
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private void webCamCapture1_ImageCaptured_1(object source, WebCam_Capture.WebcamEventArgs e)
        {
            _Pbox_Imagen.Image = e.WebCamImage;
        }

        private void Frm_UsuarioAdmin_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Txt_TpoFind.Text = "PA";
            CONTROLES._Ctrl_Buscar._Er_Control_Error = _Er_Error;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            //____________________________________________
            if (!_Txt_Nombre.Enabled & _Txt_Nombre.Text.Trim().Length > 0)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
            }
            else if (!_Txt_Usuario.Enabled & _Txt_Usuario.Text.Trim().Length > 0 & _Txt_Nombre.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
            }
            else if (_Txt_Usuario.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            }
            //_____________________________________________
        }

        private void Frm_UsuarioAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            webCamCapture1.Stop();
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        private int _Mtd_RetornarCargo(string _P_Str_Cargo)
        {
            string _Str_Cadena = "SELECT cvendedor,cgerarea FROM TCARGOSNOM WHERE cidcargonom='" + _P_Str_Cargo + "' AND (cvendedor='1' OR cgerarea='1')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0]["cvendedor"].ToString().Trim() == "1")
                { return 1; }
                else if (_Ds.Tables[0].Rows[0]["cgerarea"].ToString().Trim() == "1")
                { return 2; }
            }
            return 0;
        }
        public bool _Mtd_Guardar()
        {
            string _Str_Abreviado = "";
            _Er_Error.Dispose();
            if (_Txt_Usuario.Text.Trim().Length > 0 & _Txt_Nombre.Text.Trim().Length > 0 & _Cmb_Cargos.SelectedIndex > 0 & _Txt_Telefono1.Text.Trim().Length > 0 & _Cmb_Sex.SelectedIndex != -1 & _lis2.Items.Count > 0 & _Txt_Apellido.Text.Trim().Length > 0 & _Cmb_Grupo.SelectedIndex != -1 & _Txt_Cedula.Text.Trim().Length > 0)
            {
                int _Int_Cargo = _Mtd_RetornarCargo(Convert.ToString(_Cmb_Cargos.SelectedValue).Trim());
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TUSER where cuser='" + _Txt_Usuario.Text.Trim() + "'"))
                {
                    MessageBox.Show("El registro ya existe", "InformaciÛn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TVENDEDOR where ccedula='" + _Txt_Cedula.Text.Trim() + "' AND c_activo='1' AND c_tipo_vend='" + _Int_Cargo + "'"))
                {
                    MessageBox.Show("Ya existe un usuario con la cÈdula: " + _Txt_Cedula.Text.Trim() + ". Coloque una diferente.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
                else
                {
                    int _Int_I = 0;
                    string _Str_Cadena = "", _Str_UserId = "";
                    string _Str_Nombre = _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper();
                    if (!_Chbox_Admin.Checked)
                    {
                        _Txt_Email.Text = _Mtd_Crear_Correo(_Txt_Nombre.Text.Trim().ToUpper(), _Txt_Apellido.Text.Trim().ToUpper());
                    }
                    else if (_Txt_Email.Text.Trim().Length == 0)
                    {
                        _Er_Error.SetError(_Txt_Email, "InformaciÛn requerida");
                        return false;
                    }
                    if (_Txt_Email.Text.Trim().Length > 0)
                    {
                        _Str_Cadena = "SELECT cabreviado FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                        DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            _Str_Abreviado = Convert.ToString(_Ds.Tables[0].Rows[0]["cabreviado"]).Trim().ToUpper();
                        }
                        _Str_UserId = _Txt_Usuario.Text + _Str_Abreviado;
                        for (; ; )
                        {
                            _Int_I++;
                            if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("SELECT cname FROM TUSER WHERE cuser='" + _Str_UserId + "'"))
                            {
                                _Str_UserId = _Txt_Usuario.Text + _Int_I.ToString() + _Str_Abreviado;
                            }
                            else
                            {
                                break;
                            }
                        }
                        _Txt_Usuario.Text = _Str_UserId;

                        // clave provisional
                        string _Str_PasswordProvisional = _Mtd_ClaveProvisonalAzar();
                        string _Str_PasswordProvisionalEncriptado = _Mtd_ConvertToHash(_Str_PasswordProvisional);

                        _Str_Cadena = "insert into TUSER (cuser,cname,cposition,cemail,cphone1,cphone2,cpassw,cexpire,sexo,cadmin,c_soporte,cvendedor,ccproveedor,cnotas,cfirmante,cdateadd,cuseradd,cdelete,cgroup,cuserweb,c_reseteo_clave,ccedula,cloginrestricexep) values('" + _Txt_Usuario.Text.Trim().ToUpper() + "','" + _Str_Nombre + "','" + _Cmb_Cargos.SelectedValue.ToString().Trim() + "','" + _Txt_Email.Text.Trim().ToUpper() + "','" + _Txt_Telefono1.Text.Trim() + "','" + _Txt_Telefono2.Text.Trim() + "','" + _Str_PasswordProvisionalEncriptado + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Expiracion.Value) + "','" + _Cmb_Sex.SelectedValue.ToString().Trim() + "','" + Convert.ToInt32(_Chbox_Admin.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Sopor.Checked).ToString() + "','" + _Txt_Vendedor.Text.Trim() + "','" + _Txt_Proveedor.Text.Trim() + "','" + _Txt_Nota.Text.Trim().ToUpper() + "','" + Convert.ToInt32(_Chbox_Firmante.Checked).ToString() + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + _Cmb_Grupo.SelectedValue + "'," + Convert.ToInt32(_Chbox_T3Web.Checked).ToString() + ",1,'" + _Txt_Cedula.Text.Trim() + "','" + Convert.ToInt32(_Chbox_Excepcion.Checked).ToString() + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Mtd_Guardar_Imagen();
                        _Mtd_GuardarCompaÒia();
                        MessageBox.Show("El registro fue agregado correctamente. El usuario creado fue: " + _Txt_Usuario.Text + "\n\nLa clave provisional del usuario es: " + _Str_PasswordProvisional + "\n\nDebe hacerle llegar esta clave al usuario para que pueda acceder al sistema.", "InformaciÛn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Mtd_Actualizar();
                        _Mtd_Ini();
                        _Mtd_Deshabilitar_Todo();
                        _Tb_Tab.SelectedIndex = 0;
                        _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        _Er_Error.Dispose();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error en la conexiÛn a internet para la creaciÛn del correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            else
            {
                if (_Txt_Usuario.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Usuario, "InformaciÛn requerida!!!"); }
                if (_Txt_Nombre.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Nombre, "InformaciÛn requerida!!!"); }
                if (_Txt_Cedula.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Cedula, "InformaciÛn requerida!!!"); }
                if (_Txt_Apellido.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Apellido, "InformaciÛn requerida!!!"); }
                if (_Txt_Telefono1.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Telefono1, "InformaciÛn requerida!!!"); }
                if (_Cmb_Cargos.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Cargos, "InformaciÛn requerida!!!"); }
                //if (_Txt_Email.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Email, "IformaciÛn requerida!!!"); }
                if (_Cmb_Sex.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Sex, "InformaciÛn requerida!!!"); }
                if (_Cmb_Grupo.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Grupo, "InformaciÛn requerida!!!"); }
                if (_lis2.Items.Count == 0)
                { MessageBox.Show("Debe asignar compaÒias al usuario", "InformaciÛn", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                return false;
            }
        }
        public bool _Mtd_Editar()
        {
            _Er_Error.Dispose();
            if (_Txt_Usuario.Text.Trim().Length > 0 & _Txt_Nombre.Text.Trim().Length > 0 & _Cmb_Cargos.SelectedIndex > 0 & _Txt_Telefono1.Text.Trim().Length > 0 & _Cmb_Sex.SelectedIndex != -1 & _lis2.Items.Count > 0 & _Txt_Apellido.Text.Trim().Length > 0 & _Cmb_Grupo.SelectedIndex != -1 & _Txt_Cedula.Text.Trim().Length > 0)
            {
                int _Int_Cargo = _Mtd_RetornarCargo(Convert.ToString(_Cmb_Cargos.SelectedValue).Trim());
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TVENDEDOR where ccedula='" + _Txt_Cedula.Text.Trim() + "' AND c_activo='1' AND c_tipo_vend='" + _Int_Cargo + "'"))
                {
                    MessageBox.Show("Ya existe un usuario con la cÈdula: " + _Txt_Cedula.Text.Trim() + ". Coloque una diferente.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                    if (_Str_Nombre_G != _Str_Nombre_G_D | _Str_Apellido_G != _Str_Apellido_G_D)
                    {
                        if (_Mtd_Eliminar_Correo(_Txt_Email.Text.Trim()) & _Mtd_Crear_Correo(_Txt_Nombre.Text.Trim().ToUpper(), _Txt_Apellido.Text.Trim().ToUpper()).Trim().Length > 0)
                        {
                            _Str_Nombre_G = _Txt_Nombre.Text.Trim().ToUpper();
                            _Str_Apellido_G = _Txt_Apellido.Text.Trim().ToUpper();
                            string _Str_Nombre = _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper();
                            string _Str_Cadena = "UPDATE TUSER Set cname='" + _Str_Nombre + "',cuser='" + _Txt_Usuario.Text.Trim().ToUpper() + "',cposition='" + _Cmb_Cargos.SelectedValue.ToString().Trim() + "',cemail='" + _Txt_Email.Text.Trim().ToUpper() + "',cphone1='" + _Txt_Telefono1.Text.Trim() + "',cphone2='" + _Txt_Telefono2.Text.Trim() + "',cexpire='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Expiracion.Value) + "',sexo='" + _Cmb_Sex.SelectedValue.ToString().Trim() + "',cadmin='" + Convert.ToInt32(_Chbox_Admin.Checked).ToString() + "',c_soporte='" + Convert.ToInt32(_Chbox_Sopor.Checked).ToString() + "',cvendedor='" + _Txt_Vendedor.Text.Trim().ToUpper() + "',ccproveedor='" + _Txt_Proveedor.Text.Trim().ToUpper() + "',cnotas='" + _Txt_Nota.Text.Trim().ToUpper() + "',cfirmante='" + Convert.ToInt32(_Chbox_Firmante.Checked).ToString() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',cgroup='" + _Cmb_Grupo.SelectedValue + "',cuserweb=" + Convert.ToInt32(_Chbox_T3Web.Checked).ToString() + ",ccedula='" + _Txt_Cedula.Text.Trim() + "',cloginrestricexep='" + Convert.ToInt32(_Chbox_Excepcion.Checked).ToString() + "' where cuser='" + _Txt_Usuario.Text.Trim() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            _Str_Cadena = "UPDATE TVENDEDOR Set ccedula='" + _Txt_Cedula.Text.Trim() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' where cvendedor='" + _Txt_Usuario.Text.Trim() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            _Mtd_Guardar_Imagen();
                            _Mtd_GuardarCompaÒia();
                            MessageBox.Show("El registro fue modificado correctamente", "InformaciÛn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Mtd_Actualizar();
                            _Mtd_Ini();
                            _Mtd_Deshabilitar_Todo();
                            _Tb_Tab.SelectedIndex = 0;
                            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                            _Er_Error.Dispose();
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Error en la conexiÛn a internet para actualizar el correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        string _Str_Nombre = _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper();
                        string _Str_Cadena = "UPDATE TUSER Set cname='" + _Str_Nombre + "',cuser='" + _Txt_Usuario.Text.Trim().ToUpper() + "',cposition='" + _Cmb_Cargos.SelectedValue.ToString().Trim() + "',cemail='" + _Txt_Email.Text.Trim().ToUpper() + "',cphone1='" + _Txt_Telefono1.Text.Trim() + "',cphone2='" + _Txt_Telefono2.Text.Trim() + "',cexpire='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Expiracion.Value) + "',sexo='" + _Cmb_Sex.SelectedValue.ToString().Trim() + "',cadmin='" + Convert.ToInt32(_Chbox_Admin.Checked).ToString() + "',c_soporte='" + Convert.ToInt32(_Chbox_Sopor.Checked).ToString() + "',cvendedor='" + _Txt_Vendedor.Text.Trim().ToUpper() + "',ccproveedor='" + _Txt_Proveedor.Text.Trim().ToUpper() + "',cnotas='" + _Txt_Nota.Text.Trim().ToUpper() + "',cfirmante='" + Convert.ToInt32(_Chbox_Firmante.Checked).ToString() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',cgroup='" + _Cmb_Grupo.SelectedValue + "',cuserweb=" + Convert.ToInt32(_Chbox_T3Web.Checked).ToString() + ",ccedula='" + _Txt_Cedula.Text.Trim() + "',cloginrestricexep='" + Convert.ToInt32(_Chbox_Excepcion.Checked).ToString() + "' where cuser='" + _Txt_Usuario.Text.Trim() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "UPDATE TVENDEDOR Set ccedula='" + _Txt_Cedula.Text.Trim() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' where cvendedor='" + _Txt_Usuario.Text.Trim() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Mtd_Guardar_Imagen();
                        _Mtd_GuardarCompaÒia();
                        MessageBox.Show("El registro fue modificado correctamente", "InformaciÛn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Mtd_Actualizar();
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
                if (_Txt_Usuario.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Usuario, "InformaciÛn requerida!!!"); }
                if (_Txt_Nombre.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Nombre, "InformaciÛn requerida!!!"); }
                if (_Txt_Cedula.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Cedula, "InformaciÛn requerida!!!"); }
                if (_Txt_Apellido.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Apellido, "InformaciÛn requerida!!!"); }
                if (_Txt_Telefono1.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Telefono1, "InformaciÛn requerida!!!"); }
                if (_Cmb_Cargos.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Cargos, "InformaciÛn requerida!!!"); }
                //if (_Txt_Email.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Email, "IformaciÛn requerida!!!"); }
                if (_Cmb_Sex.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Sex, "InformaciÛn requerida!!!"); }
                if (_Cmb_Grupo.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Grupo, "InformaciÛn requerida!!!"); }
                if (_lis2.Items.Count == 0)
                { MessageBox.Show("Debe asignar compaÒias al usuario", "InformaciÛn", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                return false;
            }
        }
        public bool _Mtd_Eliminar()
        {
            if (_Txt_Usuario.Text.Trim().ToUpper() != "SISTEMA")
            {
                DialogResult eli = MessageBox.Show("Esta seguro de Eliminar el registro?", "InformaciÛn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (eli == DialogResult.Yes)
                {
                    if (_Mtd_Eliminar_CorreoOnly(_Txt_Email.Text.Trim()))
                    {
                        string _Str_Cadena = "UPDATE TUSER Set cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' where cuser='" + _Txt_Usuario.Text.Trim() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        MessageBox.Show("El registro fue eliminado correctamente", "InformaciÛn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Mtd_Actualizar();
                        _Mtd_Ini();
                        _Mtd_Deshabilitar_Todo();
                        _Tb_Tab.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Error en la conexiÛn a internet para inactivar el correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    _Mtd_Actualizar();
                    _Mtd_Ini();
                    _Mtd_Deshabilitar_Todo();
                    _Tb_Tab.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("No se puede elminar este usuario.", "ValidaciÛn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return true;
        }
        string _Str_Nombre_G = "";
        string _Str_Apellido_G = "";

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            webCamCapture1.Stop();
            if (_Dg_Grid.Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Er_Error.Dispose();
                _Mtd_Deshabilitar_Todo();
                _Pbox_Imagen.Image = null;
                string _Str_Cadena = "Select cuser,cname,cposition,cemail,cphone1,cphone2,cpassw,cexpire,sexo,cadmin,c_soporte,cvendedor,ccproveedor,cnotas,cgroup,cfirmante,cimg,cuserweb,ccedula,cloginrestricexep from TUSER where cuser='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex).Trim() + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_Usuario.MaxLength = 20;
                    DataRow _Row = _Ds.Tables[0].Rows[0];
                    _Txt_Usuario.Text = _Row["cuser"].ToString();
                    this.Text = "AdministraciÛn de usuarios - " + _Row["cuser"].ToString();
                    string[] _Str_Split = _Row["cname"].ToString().Trim().Split(new char[] { ',' });
                    _Txt_Nombre.Text = _Str_Split[0].ToString().Trim();
                    if (_Str_Split.GetLength(0) > 1)
                    {
                        _Txt_Apellido.Text = _Str_Split[1].ToString().Trim();
                    }
                    else
                    {
                        _Txt_Apellido.Text = "";
                    }
                    ////////////////////
                    _Str_Nombre_G = _Txt_Nombre.Text.Trim().ToUpper() + " ";
                    _Str_Nombre_G = _Str_Nombre_G.Substring(0, _Str_Nombre_G.IndexOf(" "));
                    _Str_Apellido_G = _Txt_Apellido.Text.Trim().ToUpper() + " ";
                    _Str_Apellido_G = _Str_Apellido_G.Substring(0, _Str_Apellido_G.IndexOf(" "));
                    ////////////////////
                    _Txt_Cedula.Text = _Row["ccedula"].ToString();
                    _Cmb_Cargos.SelectedValue = _Row["cposition"].ToString().Trim();
                    _Txt_Vendedor.Text = _Row["cvendedor"].ToString();
                    _Txt_Telefono2.Text = _Row["cphone2"].ToString();
                    _Txt_Telefono1.Text = _Row["cphone1"].ToString();
                    _Txt_Email.Text = _Row["cemail"].ToString();
                    if (_Row["cexpire"] != System.DBNull.Value)
                    {
                        _Dtp_Expiracion.Value = Convert.ToDateTime(_Row["cexpire"].ToString());
                    }
                    _Cmb_Sex.SelectedValue = _Row["sexo"].ToString();
                    if (_Row["cadmin"] != System.DBNull.Value)
                    { _Chbox_Admin.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["cadmin"].ToString())); }
                    if (_Row["c_soporte"] != System.DBNull.Value)
                    { _Chbox_Sopor.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["c_soporte"].ToString())); }
                    if (_Row["cuserweb"] != System.DBNull.Value)
                    { _Chbox_T3Web.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["cuserweb"].ToString())); }
                    
                    _Txt_Proveedor.Text = _Row["ccproveedor"].ToString();
                    _Txt_Nota.Text = _Row["cnotas"].ToString();
                    _Cmb_Grupo.SelectedValue = _Row["cgroup"].ToString();
                    if (_Row["cfirmante"] != System.DBNull.Value)
                    { _Chbox_Firmante.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["cfirmante"].ToString())); }
                    if (_Row["cloginrestricexep"] != System.DBNull.Value)
                    { _Chbox_Excepcion.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["cloginrestricexep"].ToString())); }
                    try
                    { _Pbox_Imagen.Image = _Mtd_convertirByteparaImage(((byte[])_Row["cimg"])); }
                    catch { }
                    _Mtd_DeListaLista();
                    _Mtd_Cargar_Chlists();
                    
                }
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                _Tb_Tab.SelectedIndex = 1;
                Cursor = Cursors.Default;
            }
        }

        private void _Tb_Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (_Tb_Tab.SelectedIndex == 2)
            //{
            //    if (!_Chbox_Firmante.Checked)
            //    { _Tb_Tab.SelectedIndex = 1; }
            //}
        }
        private string _Mtd_Crear_Correo(string _P_Str_Nombre, string _P_Str_Apellido)
        {
            try
            {
                if (!_Chbox_Admin.Checked || _Str_MyProceso=="N")
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
                    string _Str_Email = _P_Str_Nombre.Substring(0, 1).ToUpper().Trim() + _P_Str_Apellido.ToUpper().Trim();
                    bool _bol_Existe = true;
                    int _Int_I = 1;
                    string _Str_Cadena = "Select cdominioemail,cabreviado from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_Email = _Str_Email + "." + _Ds.Tables[0].Rows[0][1].ToString().Trim().ToUpper() + "@" + _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
                        while (_bol_Existe)
                        {
                            if (!_Cls._Mtd_ValidarEmailUser(_Str_Email, Frm_Padre._Str_Comp, _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper()))
                            {
                                _Str_Email = _P_Str_Nombre.Trim().Substring(0, 1).ToUpper() + _P_Str_Apellido.ToUpper().Trim() + _Int_I.ToString().Trim() + "." + _Ds.Tables[0].Rows[0][1].ToString().Trim().ToUpper() + "@" + _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
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
                else
                {
                    return _Txt_Email.Text;
                }
                
            }
            catch { return ""; }
        }
        //private string _Mtd_Crear_CorreoAdmin(string _P_Str_Mail)
        //{
        //    try
        //    {
        //        _Cls_EmailValidate.Ser_EmailValidate _Cls = new T3._Cls_EmailValidate.Ser_EmailValidate();
        //        string _Str_Email = _P_Str_Mail;
        //        while (_bol_Existe)
        //        {
                    
        //            if (!_Cls._Mtd_ValidarEmailUser(_Str_Email, Frm_Padre._Str_Comp, _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper()))
        //            {
        //                _Str_Email = _P_Str_Nombre.ToUpper().Trim() + _P_Str_Apellido.ToUpper().Trim() + _Int_I.ToString().Trim() + "@" + _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
        //            }
        //            else
        //            { _bol_Existe = false; }
        //            _Int_I++;
        //        }


        //        if (!_Chbox_Admin.Checked || _Str_MyProceso == "N")
        //        {
        //            _Cls_EmailValidate.Ser_EmailValidate _Cls = new T3._Cls_EmailValidate.Ser_EmailValidate();
        //            //----------------
        //            _P_Str_Nombre = _P_Str_Nombre.Trim() + " ";
        //            _P_Str_Nombre = _P_Str_Nombre.Substring(0, _P_Str_Nombre.IndexOf(" "));
        //            _P_Str_Apellido = _P_Str_Apellido.Trim() + " ";
        //            _P_Str_Apellido = _P_Str_Apellido.Substring(0, _P_Str_Apellido.IndexOf(" "));
        //            //----------------
        //            _P_Str_Nombre = _Mtd_Quitar_Signos(_P_Str_Nombre);
        //            _P_Str_Apellido = _Mtd_Quitar_Signos(_P_Str_Apellido);
        //            string _Str_Email = _P_Str_Nombre.Substring(0, 1).ToUpper().Trim() + _P_Str_Apellido.ToUpper().Trim();
        //            bool _bol_Existe = true;
        //            int _Int_I = 1;
        //            string _Str_Cadena = "Select cdominioemail,cabreviado from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'";
        //            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
        //            if (_Ds.Tables[0].Rows.Count > 0)
        //            {
        //                _Str_Email = _Str_Email + "." + _Ds.Tables[0].Rows[0][1].ToString().Trim().ToUpper() + "@" + _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
        //                while (_bol_Existe)
        //                {
        //                    if (!_Cls._Mtd_ValidarEmailUser(_Str_Email, Frm_Padre._Str_Comp, _Txt_Nombre.Text.Trim().ToUpper() + "," + _Txt_Apellido.Text.Trim().ToUpper()))
        //                    {
        //                        _Str_Email = _P_Str_Nombre.ToUpper().Trim() + _P_Str_Apellido.ToUpper().Trim() + _Int_I.ToString().Trim() + "@" + _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
        //                    }
        //                    else
        //                    { _bol_Existe = false; }
        //                    _Int_I++;
        //                }
        //                _Mtd_Agregar_Correo(false, _Str_Email.ToUpper());
        //                _Txt_Email.Text = _Str_Email.ToUpper();
        //                return _Str_Email.ToUpper();
        //            }
        //            else
        //            {
        //                return "";
        //            }
        //        }
        //        else
        //        {
        //            return _Txt_Email.Text;
        //        }

        //    }
        //    catch { return ""; }
        //}
        private bool _Mtd_Eliminar_CorreoOnly(string _P_Str_Email)
        {
            bool _Bol_Sw = false;
            try
            {
                _Cls_EmailValidate.Ser_EmailValidate _Cls = new T3._Cls_EmailValidate.Ser_EmailValidate();
                _Cls.Url = CLASES._Cls_Conexion._G_Str_Url_Services;
                _Cls._Mtd_BorrarEmail(_P_Str_Email);
                _Bol_Sw = true;
            }
            catch { }
            return _Bol_Sw;
        }
        private bool _Mtd_Eliminar_Correo(string _P_Str_Email)
        {
            bool _Bol_Sw = false;
            try
            {
                if (!_Chbox_Admin.Checked)
                {
                    _Cls_EmailValidate.Ser_EmailValidate _Cls = new T3._Cls_EmailValidate.Ser_EmailValidate();
                    _Cls.Url = CLASES._Cls_Conexion._G_Str_Url_Services;
                    if ((_Cls._Mtd_BorrarEmail(_P_Str_Email)))
                    {
                        _Mtd_Agregar_Correo(true, _P_Str_Email.ToUpper());
                        _Bol_Sw = true;
                    }
                    else
                    {
                        _Bol_Sw = false;
                    }
                }
                else
                {
                    _Bol_Sw = true;
                }
            }
            catch { _Bol_Sw = false; }
            return _Bol_Sw;
        }
        private string _Mtd_Quitar_Signos(string _P_Str_Cadena)
        {
            string _Str_Consignos = "·‡‰ÈËÎÌÏÔÛÚˆ˙˘uÒ¡¿ƒ…»ÀÕÃœ”“÷⁄Ÿ‹—Á«";
            string _Str_Sinsignos = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUNcC";
            for (int _Int_I = 0; _Int_I < _Str_Sinsignos.Length; _Int_I++)
            {
                string _Str_I = _Str_Consignos.Substring(_Int_I, 1);
                string _Str_J = _Str_Sinsignos.Substring(_Int_I, 1);
                _P_Str_Cadena = _P_Str_Cadena.Replace(_Str_I, _Str_J);
            }
            return _P_Str_Cadena;
        }
        private void _Mtd_Agregar_Correo(bool _P_Bol_Eliminar, string _P_Str_Correo)
        {
            string _Str_Cadena = "Select ccreaemail1,ccreaemail2,ccreaemail3,ccreaemail4,ccreaemail5 from TCONFIGVENT where ccompany='" + Frm_Padre._Str_Comp + "'";
            string _Str_Cemailpara = "";
            string _Str_Casunto = "";
            string _Str_Ccuerpoms = "";
            if (_P_Bol_Eliminar)
            {
                _Str_Casunto = "ELIMINACI”N DE CORREO";
                _Str_Ccuerpoms = "<font face=\"verdana\" size=\"2\"> T3, LA EMPRESA " + Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cname from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString().Trim().ToUpper() + ", SOLICITA LA ELIMINACI”N DEL CORREO " + _P_Str_Correo.ToUpper().Trim() + " PARA EL USUARIO " + _Txt_Nombre.Text.Trim().ToUpper() + " " + _Txt_Apellido.Text.Trim().ToUpper() + "</font>";
            }
            else
            {
                _Str_Casunto = "CREACI”N DE CORREO";
                _Str_Ccuerpoms = "<font face=\"verdana\" size=\"2\"> T3, LA EMPRESA " + Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cname from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString().Trim().ToUpper() + ", SOLICITA LA CREACI”N DEL CORREO " + _P_Str_Correo.ToUpper().Trim() + " PARA EL USUARIO " + _Txt_Nombre.Text.Trim().ToUpper() + " " + _Txt_Apellido.Text.Trim().ToUpper() + "</font>";
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

        private void _Cmb_Grupo_DropDown(object sender, EventArgs e)
        {
            _Mtd_cargar_Grupo();
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

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex != 0)
            {
                if (_Txt_Usuario.Text.Length == 0 & _Str_MyProceso.Length == 0)
                {
                    e.Cancel = true;
                }
            }
            if (e.TabPageIndex == 2)
            {
                if (!_Chbox_Firmante.Checked)
                { e.Cancel = true; }
            }
        }

        private void _Txt_Email_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Txt_Email, "");
        }

        private void _Chbox_Admin_CheckedChanged(object sender, EventArgs e)
        {
            if (_Str_MyProceso.Length > 0)
            {
                if (_Chbox_Admin.Checked)
                {
                    _Txt_Email.ReadOnly = false;
                }
                else
                {
                    _Txt_Email.ReadOnly = true;
                }
            }
        }

        private void _Cmb_Cargos_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarCargos();
        }

        // genera cuatro digitos al azar (0-9) y los une...
        private string _Mtd_ClaveProvisonalAzar()
        {
            Random random = new Random();

            int _Int_Digito1 = random.Next(0, 9);
            int _Int_Digito2 = random.Next(0, 9);
            int _Int_Digito3 = random.Next(0, 9);
            int _Int_Digito4 = random.Next(0, 9);

            return _Int_Digito1.ToString() + _Int_Digito2.ToString() + _Int_Digito3.ToString() + _Int_Digito4.ToString();
        }

        private string _Mtd_ConvertToHash(string _Str_Cadena)
        {
            byte[] hash = ConvertStringToByteArray(_Str_Cadena);
            byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
            string _Str_cod = BitConverter.ToString(valorhash);
            return _Str_cod.Replace("-", "");
        }

        public static Byte[] ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
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

        private void _Chk_UsuarioActivo_CheckedChanged(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
        }
    }
}