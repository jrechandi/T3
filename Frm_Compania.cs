using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace T3
{
    public partial class Frm_Compania : Form
    {
        string _Str_MyProceso = "";
        public Frm_Compania()
        {
            InitializeComponent();
            _Mtd_Color_Estandar(_Tb_Tab);
            _Mtd_Actualizar();
            _Mtd_Cargar_Cmb_Contribuyente();
            _Mtd_Cargar_Cmb_Pais();
            _Mtd_Cargar_Cmb_AlmacenPre();
            _Mtd_Cargar_Cmb_AlmacenMal();
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
        private void _Mtd_Actualizar()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ccompany";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "Select ccompany as Código,cname as Descripción from TCOMPANY where cdelete='0'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Compañías", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_Cargar_Cmb_Contribuyente()
        {
            _Cmb_Contribuyente.DataSource = null;
            DataSet _Ds;
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select ccontribuyente,cname from TCONTRIBUYENTE where cdelete='0'");
            _Cmb_Contribuyente.DataSource = _Ds.Tables[0];
            _Cmb_Contribuyente.DisplayMember = "cname";
            _Cmb_Contribuyente.ValueMember = "ccontribuyente";
            _Cmb_Contribuyente.SelectedIndex = -1;
        }
        private void _Mtd_Cargar_Cmb_Pais()
        {
            _Cmb_Pais.DataSource = null;
            DataSet _Ds;
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select ccountry,cname from TCOUNTRY where cdelete='0'");
            _Cmb_Pais.DataSource = _Ds.Tables[0];
            _Cmb_Pais.DisplayMember = "cname";
            _Cmb_Pais.ValueMember = "ccountry";
            _Cmb_Pais.SelectedIndex = -1;
        }
        private void _Mtd_Cargar_Cmb_AlmacenPre()
        {
            _Cmb_AlmacenPre.DataSource = null;
            DataSet _Ds;
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select calmacen,cname from TALMACEN where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "'");
            _Cmb_AlmacenPre.DataSource = _Ds.Tables[0];
            _Cmb_AlmacenPre.DisplayMember = "cname";
            _Cmb_AlmacenPre.ValueMember = "calmacen";
            _Cmb_AlmacenPre.SelectedIndex = -1;
        }
        private void _Mtd_Cargar_Cmb_AlmacenMal()
        {
            _Cmb_AlmacenMal.DataSource = null;
            DataSet _Ds;
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select calmacen,cname from TALMACEN where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "'");
            _Cmb_AlmacenMal.DataSource = _Ds.Tables[0];
            _Cmb_AlmacenMal.DisplayMember = "cname";
            _Cmb_AlmacenMal.ValueMember = "calmacen";
            _Cmb_AlmacenMal.SelectedIndex = -1;
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        public void _Mtd_Cancelar()
        {
            _Mtd_Ini();
            _Mtd_Deshabilitar_Todo();
            _Mtd_BotonesMenu();
        }
        public void _Mtd_Ini()
        {
            _Pbox_Imagen.Image = null;
            _Txt_Codigo.Text = "";
            _Txt_Direccion.Text = "";
            _Txt_Direccion_L.Text = "";
            _Txt_Email.Text="";
            _Txt_Fax1.Text = "";
            _Txt_Fax2.Text = "";
            _Txt_Nombre.Text = "";
            _Txt_Nombre_L.Text = "";
            _Txt_Postal.Text = "";
            _Txt_Dominio.Text = "";
            _Txt_Telefono1.Text = "";
            _Txt_Telefono2.Text = "";
            _Txt_Url.Text = "";
            _Txt_Rif2.Text = "";
            _Txt_Rif3.Text = "";
            _Cmb_Rif1.SelectedIndex = -1;
            _Txt_Nit.Text = "";

            _Dtp_FIniEjeCont.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dtp_FEndEjeCont.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dtp_FIniCont.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Txt_CountActivo.Text = "";
            _Txt_CountActivo.Tag = "";
            _Txt_CountPasivo.Text = "";
            _Txt_CountPasivo.Tag = "";
            _Txt_CountCapital.Text = "";
            _Txt_CountCapital.Tag = "";
            _Txt_CountUtilAcum.Text = "";
            _Txt_CountUtilAcum.Tag = "";
            _Txt_CountPerdiAcum.Text = "";
            _Txt_CountPerdiAcum.Tag = "";
            _Txt_CountUtilEjer.Text = "";
            _Txt_CountUtilEjer.Tag = "";
            _Txt_CountPerdiEjer.Text = "";
            _Txt_CountPerdiEjer.Tag = "";
            _Mtd_Cargar_Cmb_Contribuyente();
            _Mtd_Cargar_Cmb_Pais();
            _Mtd_Cargar_Cmb_AlmacenPre();
            _Mtd_Cargar_Cmb_AlmacenMal();
            _Mtd_Habilitar();
            _Txt_Codigo.Enabled = true;
            _Str_MyProceso = "";
        }
        public void _Mtd_Habilitar()
        {
            //_Txt_Codigo.Enabled = false;
            //_Txt_Direccion.Enabled = true;
            //_Txt_Direccion_L.Enabled = true;
            //_Txt_Dominio.Enabled = true;
            //_Txt_Email.Enabled = true;
            //_Txt_Fax1.Enabled = true;
            //_Txt_Fax2.Enabled = true;
            //_Txt_Nombre.Enabled = true;
            //_Txt_Nombre_L.Enabled = true;
            //_Txt_Postal.Enabled = true;
            //_Txt_Telefono1.Enabled = true;
            //_Txt_Telefono2.Enabled = true;
            //_Txt_Url.Enabled = true;
            //_Txt_Nit.Enabled = true;
            //_Cmb_Contribuyente.Enabled = true;
            //_Cmb_Pais.Enabled = true;
            _Bt_Buscar.Enabled = true;
            //_Txt_Rif2.Enabled = true;
            //_Txt_Rif3.Enabled = true;
            //_Cmb_Rif1.Enabled = true;
            //_Cmb_AlmacenPre.Enabled = true;
            //_Cmb_AlmacenMal.Enabled = true;

            _Dtp_FIniEjeCont.Enabled = true;
            _Dtp_FEndEjeCont.Enabled = true;
            _Dtp_FIniCont.Enabled = true;
            _Bt_CountActivo.Enabled = true;
            _Bt_CountPasivo.Enabled = true;
            _Bt_CountCapital.Enabled = true;
            _Bt_CountUtilAcum.Enabled = true;
            _Bt_CountPerdiAcum.Enabled = true;
            _Bt_CountUtilEjer.Enabled = true;
            _Bt_CountPerdiEjer.Enabled = true;
            _Str_MyProceso = "M";
        }
        private void _Mtd_Deshabilitar_Todo()
        {
            _Txt_Codigo.Enabled = false;
            _Txt_Direccion.Enabled = false;
            _Txt_Direccion_L.Enabled = false;
            _Txt_Dominio.Enabled = false;
            _Txt_Email.Enabled = false;
            _Txt_Fax1.Enabled = false;
            _Txt_Fax2.Enabled = false;
            _Txt_Nombre.Enabled = false;
            _Txt_Nombre_L.Enabled = false;
            _Txt_Postal.Enabled = false;
            _Txt_Telefono1.Enabled = false;
            _Txt_Telefono2.Enabled = false;
            _Txt_Url.Enabled = false;
            _Txt_Nit.Enabled = false;
            _Cmb_Contribuyente.Enabled = false;
            _Cmb_Pais.Enabled = false;
            _Bt_Buscar.Enabled = false;
            _Txt_Rif2.Enabled = false;
            _Txt_Rif3.Enabled = false;
            _Cmb_Rif1.Enabled = false;
            _Cmb_AlmacenPre.Enabled = false;
            _Cmb_AlmacenMal.Enabled = false;
            _Dtp_FIniEjeCont.Enabled = false;
            _Dtp_FEndEjeCont.Enabled = false;
            _Dtp_FIniCont.Enabled = false;
            _Bt_CountActivo.Enabled = false;
            _Bt_CountPasivo.Enabled = false;
            _Bt_CountCapital.Enabled = false;
            _Bt_CountUtilAcum.Enabled = false;
            _Bt_CountPerdiAcum.Enabled = false;
            _Bt_CountUtilEjer.Enabled = false;
            _Bt_CountPerdiEjer.Enabled = false;
            _Txt_CountActivo.ReadOnly = true;
            _Txt_CountCapital.ReadOnly = true;
            _Txt_CountPasivo.ReadOnly = true;
            _Txt_CountPerdiAcum.ReadOnly = true;
            _Txt_CountPerdiEjer.ReadOnly = true;
            _Txt_CountUtilAcum.ReadOnly = true;
            _Txt_CountUtilEjer.ReadOnly = true;
        }
        public void _Mtd_Nuevo()
        {
            _Er_Error.Dispose();
            _Mtd_Ini();
            _Tb_Tab.SelectedIndex = 2;
            _Txt_Codigo.Focus();
            _Str_MyProceso = "A";
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
                string _Str_Cadena = "ccompany='" + _Txt_Codigo.Text.Trim().ToUpper() + "'";
                cmdInsert = new SqlCommand("UPDATE TCOMPANY Set clogo=@clogo where " + _Str_Cadena, con);
                dbParamInsert = new SqlParameter("@clogo", SqlDbType.VarBinary, _By_.Length, ParameterDirection.Input, false, 0, 0, "clogo", DataRowVersion.Current, _By_);
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
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            if (_Txt_Telefono2.Text.Trim().Length == 0)
            { _Txt_Telefono2.Text = "0"; }
            string _Str_Rif = "";
            if (_Cmb_Rif1.SelectedIndex != -1 & _Txt_Rif2.Text.Trim().Length > 0 & _Txt_Rif3.Text.Trim().Length > 0)
            { _Str_Rif = _Cmb_Rif1.SelectedItem.ToString().Trim() + "-" + _Txt_Rif2.Text.Trim() + "-" + _Txt_Rif3.Text.Trim(); }
            else
            { _Str_Rif = ""; }
            bool _Bol_Dominio = _Mtd_Validar_Dominio(_Txt_Dominio.Text.Trim());
            if (_Txt_Codigo.Text.Trim().Length > 0 & _Txt_Nombre.Text.Trim().Length > 0 & _Txt_Nombre_L.Text.Trim().Length > 0 & _Txt_Direccion.Text.Trim().Length > 0 & _Txt_Direccion_L.Text.Trim().Length > 0 & _Txt_Email.Text.Trim().Length > 0 & _Txt_Telefono1.Text.Trim().Length > 0 & _Txt_Fax1.Text.Trim().Length > 0 & _Str_Rif.Trim().Length > 0 & _Txt_Nit.Text.Trim().Length > 0 & _Cmb_Pais.SelectedIndex != -1 & _Cmb_Contribuyente.SelectedIndex != -1 & _Txt_Postal.Text.Trim().Length > 0 & _Bol_Dominio)
            {
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TCOMPANY where ccompany='" + _Txt_Codigo.Text.Trim() + "'"))
                {
                    MessageBox.Show("El registro ya existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    _Txt_Dominio.Text = _Mtd_Quitar_Signos(_Txt_Dominio.Text.Trim());
                    string _Str_Cadena = "insert into TCOMPANY (ccompany,cname,cnamel,caddress,caddressl,cphone1,cphone2,cfax1,cfax2,cemail,cwww,ccodepost,ccountry,crif,cnit,ctip_contribuy,cdateadd,cuseradd,cdelete,cpasswserver,cdominioemail,calmacenpre,calmacenmme) values('" + _Txt_Codigo.Text.Trim().ToUpper() + "','" + _Txt_Nombre.Text.Trim().ToUpper() + "','" + _Txt_Nombre_L.Text.Trim().ToUpper() + "','" + _Txt_Direccion.Text.Trim().ToUpper() + "','" + _Txt_Direccion_L.Text.Trim().ToUpper() + "','" + _Txt_Telefono1.Text.Trim().ToUpper() + "','" + _Txt_Telefono2.Text.Trim().ToUpper() + "','" + _Txt_Fax1.Text.Trim().ToUpper() + "','" + _Txt_Fax2.Text.Trim().ToUpper() + "','" + _Txt_Email.Text.Trim() + "','" + _Txt_Url.Text.Trim() + "','" + _Txt_Postal.Text.Trim().ToUpper() + "','" + _Cmb_Pais.SelectedValue.ToString().Trim() + "','" + _Str_Rif.Trim().ToUpper() + "','" + _Txt_Nit.Text.Trim().ToUpper() + "','" + _Cmb_Contribuyente.SelectedValue.ToString().Trim() + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + _Txt_Dominio.Text.Trim() + "','"+_Cmb_AlmacenPre.SelectedValue+"','"+_Cmb_AlmacenMal.SelectedValue+"')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Mtd_Guardar_Imagen();
                    MessageBox.Show("El registro fue agregado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_Actualizar();
                    _Mtd_Ini();
                    _Mtd_Deshabilitar_Todo();
                    _Tb_Tab.SelectedIndex = 0;
                    _Er_Error.Dispose();
                    return true;
                }
            }
            else
            {
                if (_Txt_Codigo.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Codigo, "Información requerida!!!"); }
                if (_Txt_Nombre.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Nombre, "Información requerida!!!"); }
                if (_Txt_Nombre_L.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Nombre_L, "Información requerida!!!"); }
                if (_Txt_Direccion.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Direccion, "Información requerida!!!"); }
                if (_Txt_Direccion_L.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Direccion_L, "Información requerida!!!"); }
                if (_Txt_Email.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Email, "Información requerida!!!"); }
                if (_Txt_Telefono1.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Telefono1, "Información requerida!!!"); }
                if (_Txt_Fax1.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Fax1, "Información requerida!!!"); }
                if (_Str_Rif.Trim().Length == 0) { _Er_Error.SetError(_Bt_Rif, "Información requerida!!!"); }
                if (_Txt_Nit.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Nit, "Información requerida!!!"); }
                if (_Cmb_Pais.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Pais, "Información requerida!!!"); }
                if (_Cmb_Contribuyente.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Contribuyente, "Información requerida!!!"); }
                if (_Txt_Postal.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Postal, "Información requerida!!!"); }
                if (!_Bol_Dominio) { _Er_Error.SetError(_Txt_Dominio, "Información requerida!!!"); }
                return false;
            }
        }
        public bool _Mtd_Editar()
        {
            _Er_Error.Dispose();
            string _Str_Cadena = "UPDATE TCOMPANY Set cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0' where ccompany='" + _Txt_Codigo.Text.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Mtd_Guardar_Imagen();
            _Str_Cadena = "";
            if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("SELECT ccompany FROM TCONFIGCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "'"))
            {
                _Str_Cadena = "UPDATE TCONFIGCONT SET cbegexe='" + _Dtp_FIniEjeCont.Value.ToShortDateString() + "',cfinishexe='" + _Dtp_FEndEjeCont.Value.ToShortDateString() + "',cbegacco='" + _Dtp_FIniCont.Value.ToShortDateString() + "',ccuentaactivo='" + _Txt_CountActivo.Tag.ToString() + "',ccuantapasivo='" + _Txt_CountPasivo.Tag.ToString() + "',ccuentacapital='" + _Txt_CountCapital.Tag.ToString() + "',ccuentautilacu='" + _Txt_CountUtilAcum.Tag.ToString() + "',ccuentaperdiacu='" + _Txt_CountPerdiAcum.Tag.ToString() + "',ccuentautilejerc='" + _Txt_CountUtilEjer.Tag.ToString() + "',ccuentaperdiejerc='" + _Txt_CountPerdiEjer.Tag.ToString() + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "'";   
            }
            else
            {
                _Str_Cadena = "INSERT INTO TCONFIGCONT (ccompany,cbegexe,cfinishexe,cbegacco,ccuentaactivo,ccuantapasivo,ccuentacapital,ccuentautilacu,ccuentaperdiacu,ccuentautilejerc,ccuentaperdiejerc,cdateadd,cuseradd,cdelete) VALUES ('";
                _Str_Cadena = _Str_Cadena + Frm_Padre._Str_Comp + "','" + _Dtp_FIniEjeCont.Value.ToShortDateString() + "','" + _Dtp_FEndEjeCont.Value.ToShortDateString() + "','" + _Dtp_FIniCont.Value.ToShortDateString() + "','" + _Txt_CountActivo.Tag.ToString() + "','" + _Txt_CountPasivo.Tag.ToString() + "','" + _Txt_CountCapital.Tag.ToString() + "','" + _Txt_CountUtilAcum.Tag.ToString() + "','" + _Txt_CountPerdiAcum.Tag.ToString() + "','" + _Txt_CountUtilEjer.Tag.ToString() + "','" + _Txt_CountPerdiEjer.Tag.ToString() + "',GETDATE(),'" + Frm_Padre._Str_Use + "',0)";
            }
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            MessageBox.Show("El registro fue modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _Mtd_Actualizar();
            _Mtd_Ini();
            _Mtd_Deshabilitar_Todo();
            _Tb_Tab.SelectedIndex = 0;
            _Er_Error.Dispose();
            return true;
        }
        public bool _Mtd_Eliminar()
        {
            DialogResult eli = MessageBox.Show("Esta seguro de Eliminar el registro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (eli == DialogResult.Yes)
            {
                string _Str_Cadena = "UPDATE TCOMPANY Set cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' where ccompany='" + _Txt_Codigo.Text.Trim().ToUpper() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                MessageBox.Show("El registro fue eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Actualizar();
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
            }
            else
            {
                _Mtd_Actualizar();
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
            }
            return true;
        }
        private void Frm_Compañia_Load(object sender, EventArgs e)
        {
        }

        private void _Cmb_Pais_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Cmb_Pais();
        }

        private void _Cmb_Contribuyente_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Cmb_Contribuyente();
        }
        public void _Mtd_BotonesMenu()
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            if (_Str_MyProceso == "A")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
            }
            if (_Str_MyProceso == "M")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
            }
            if (_Str_MyProceso == "")
            {
                if (_Dtp_FIniEjeCont.Enabled & _Txt_Codigo.Text.Trim().Length>0)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                }
                else if (_Txt_Codigo.Text.Trim().Length > 0)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                }
                else
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                }
            }

        }
        private void Frm_Compañia_Activated(object sender, EventArgs e)
        {
            //CONTROLES._Ctrl_Buscar._Txt_TpoFind.Text = "PA";
            //CONTROLES._Ctrl_Buscar._Er_Control_Error = _Er_Error;
            //CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            //CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            //CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            //CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            //CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            //CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            _Mtd_BotonesMenu();
        }

        private void Frm_Compañia_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Er_Error.Dispose();
                _Mtd_Deshabilitar_Todo();
                _Pbox_Imagen.Image = null;
                string _Str_Cadena = "Select * from TCOMPANY where ccompany='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex) + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    DataRow _Row=_Ds.Tables[0].Rows[0];
                    _Txt_Codigo.Text=_Row["ccompany"].ToString().Trim();
                    _Txt_Direccion.Text = _Row["caddress"].ToString().Trim();
                    _Txt_Direccion_L.Text = _Row["caddressl"].ToString().Trim();
                    _Txt_Email.Text = _Row["cemail"].ToString().Trim();
                    _Txt_Fax1.Text = _Row["cfax1"].ToString().Trim();
                    _Txt_Fax2.Text = _Row["cfax2"].ToString().Trim();
                    _Txt_Nombre.Text = _Row["cname"].ToString().Trim();
                    _Txt_Nombre_L.Text = _Row["cnamel"].ToString().Trim();
                    _Txt_Postal.Text = _Row["ccodepost"].ToString().Trim();
                    _Txt_Telefono1.Text = _Row["cphone1"].ToString().Trim();
                    _Txt_Telefono2.Text = _Row["cphone2"].ToString().Trim();
                    _Txt_Url.Text = _Row["cwww"].ToString().Trim();
                    _Txt_Nit.Text = _Row["cnit"].ToString().Trim();
                    _Txt_Dominio.Text = _Row["cdominioemail"].ToString().Trim();
                    _Cmb_Contribuyente.SelectedValue = _Row["ctip_contribuy"].ToString().Trim();
                    _Cmb_Pais.SelectedValue = _Row["ccountry"].ToString().Trim();
                    string[] _Str_Rif = _Row["crif"].ToString().Trim().Split(new char[] { '-' });
                    _Cmb_Rif1.SelectedItem = _Str_Rif[0].ToString();
                    _Txt_Rif2.Text = _Str_Rif[1].ToString();
                    _Txt_Rif3.Text = _Str_Rif[2].ToString();
                    _Cmb_AlmacenPre.SelectedValue = _Row["calmacenpre"].ToString();
                    _Cmb_AlmacenMal.SelectedValue = _Row["calmacenmme"].ToString();
                    DataSet _Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT * FROM TCONFIGCONT WHERE ccompany='" + _Txt_Codigo.Text + "'");
                    if (_Ds_B.Tables[0].Rows.Count > 0)
                    {
                        DataRow _RowA = _Ds_B.Tables[0].Rows[0];
                        if (Convert.ToString(_RowA["cbegexe"]).Length != 0)
                        {
                            _Dtp_FIniEjeCont.Value = Convert.ToDateTime(_RowA["cbegexe"]);
                        }
                        if (Convert.ToString(_RowA["cfinishexe"]).Length != 0)
                        {
                            _Dtp_FEndEjeCont.Value = Convert.ToDateTime(_RowA["cfinishexe"]);
                        }
                        if (Convert.ToString(_RowA["cbegacco"]).Length != 0)
                        {
                            _Dtp_FIniCont.Value = Convert.ToDateTime(_RowA["cbegacco"]);
                        }
                        DataSet _Ds_A;
                        _Txt_CountActivo.Tag = Convert.ToString(_RowA["ccuentaactivo"]).Trim();
                        _Str_Cadena = "SELECT cname FROM TCOUNT WHERE ccompany='" + _Txt_Codigo.Text + "' AND ccount='";
                        if (Convert.ToString(_RowA["ccuentaactivo"]).Trim().Length > 0)
                        {
                            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena + Convert.ToString(_RowA["ccuentaactivo"]).Trim() + "'");
                            if (_Ds_A.Tables[0].Rows.Count > 0)
                            {
                                _Txt_CountActivo.Text = _Txt_CountActivo.Tag.ToString() + " - " + _Ds_A.Tables[0].Rows[0]["cname"].ToString();
                            }
                            else
                            {
                                _Txt_CountActivo.Text = _Txt_CountActivo.Tag.ToString() + " - Cuenta sin descripción";
                            }
                        }
                        else
                        {
                            _Txt_CountActivo.Tag = "";
                            _Txt_CountActivo.Text = "";
                        }
                        _Txt_CountPasivo.Tag = Convert.ToString(_RowA["ccuantapasivo"]).Trim();
                        if (Convert.ToString(_RowA["ccuantapasivo"]).Trim().Length > 0)
                        {
                            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena + Convert.ToString(_RowA["ccuantapasivo"]).Trim() + "'");
                            if (_Ds_A.Tables[0].Rows.Count > 0)
                            {
                                _Txt_CountPasivo.Text = _Txt_CountPasivo.Tag.ToString() + " - " + _Ds_A.Tables[0].Rows[0]["cname"].ToString();
                            }
                            else
                            {
                                _Txt_CountPasivo.Text = _Txt_CountPasivo.Tag.ToString() + " - Cuenta sin descripción";
                            }
                        }
                        else
                        {
                            _Txt_CountPasivo.Text = "";
                            _Txt_CountPasivo.Tag = "";
                        }
                        _Txt_CountCapital.Tag = Convert.ToString(_RowA["ccuentacapital"]).Trim();
                        if (Convert.ToString(_RowA["ccuentacapital"]).Trim().Length > 0)
                        {
                            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena + Convert.ToString(_RowA["ccuentacapital"]).Trim() + "'");
                            if (_Ds_A.Tables[0].Rows.Count > 0)
                            {
                                _Txt_CountCapital.Text = _Txt_CountCapital.Tag.ToString() + " - " + _Ds_A.Tables[0].Rows[0]["cname"].ToString();
                            }
                            else
                            {
                                _Txt_CountCapital.Text = _Txt_CountCapital.Tag.ToString() + " - Cuenta sin descripción";
                            }
                        }
                        else
                        {
                            _Txt_CountCapital.Text = "";
                            _Txt_CountCapital.Tag = "";
                        }
                        _Txt_CountUtilAcum.Tag = Convert.ToString(_RowA["ccuentautilacu"]).Trim();
                        if (Convert.ToString(_RowA["ccuentautilacu"]).Trim().Length > 0)
                        {
                            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena + Convert.ToString(_RowA["ccuentautilacu"]).Trim() + "'");
                            if (_Ds_A.Tables[0].Rows.Count > 0)
                            {
                                _Txt_CountUtilAcum.Text = _Txt_CountUtilAcum.Tag.ToString() + " - " + _Ds_A.Tables[0].Rows[0]["cname"].ToString();
                            }
                            else
                            {
                                _Txt_CountUtilAcum.Text = _Txt_CountUtilAcum.Tag.ToString() + " - Cuenta sin descripción";
                            }
                        }
                        else
                        {
                            _Txt_CountUtilAcum.Text = "";
                            _Txt_CountUtilAcum.Tag = "";
                        }
                        _Txt_CountPerdiAcum.Tag = Convert.ToString(_RowA["ccuentaperdiacu"]).Trim();
                        if (Convert.ToString(_RowA["ccuentaperdiacu"]).Trim().Length > 0)
                        {
                            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena + Convert.ToString(_RowA["ccuentaperdiacu"]).Trim() + "'");
                            if (_Ds_A.Tables[0].Rows.Count > 0)
                            {
                                _Txt_CountPerdiAcum.Text = _Txt_CountPerdiAcum.Tag.ToString() + " - " + _Ds_A.Tables[0].Rows[0]["cname"].ToString();
                            }
                            else
                            {
                                _Txt_CountPerdiAcum.Text = _Txt_CountPerdiAcum.Tag.ToString() + " - Cuenta sin descripción";
                            }
                        }
                        else
                        {
                            _Txt_CountPerdiAcum.Text = "";
                            _Txt_CountPerdiAcum.Tag = "";
                        }
                        _Txt_CountUtilEjer.Tag = Convert.ToString(_RowA["ccuentautilejerc"]).Trim();
                        if (Convert.ToString(_RowA["ccuentautilejerc"]).Trim().Length > 0)
                        {
                            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena + Convert.ToString(_RowA["ccuentautilejerc"]).Trim() + "'");
                            if (_Ds_A.Tables[0].Rows.Count > 0)
                            {
                                _Txt_CountUtilEjer.Text = _Txt_CountUtilEjer.Tag.ToString() + " - " + _Ds_A.Tables[0].Rows[0]["cname"].ToString();
                            }
                            else
                            {
                                _Txt_CountUtilEjer.Text = _Txt_CountUtilEjer.Tag.ToString() + " - Cuenta sin descripción";
                            }
                        }
                        else
                        {
                            _Txt_CountUtilEjer.Text = "";
                            _Txt_CountUtilEjer.Tag = "";
                        }
                        _Txt_CountPerdiEjer.Tag = Convert.ToString(_RowA["ccuentaperdiejerc"]).Trim();
                        if (Convert.ToString(_RowA["ccuentaperdiejerc"]).Trim().Length > 0)
                        {
                            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena + Convert.ToString(_RowA["ccuentaperdiejerc"]).Trim() + "'");
                            if (_Ds_A.Tables[0].Rows.Count > 0)
                            {
                                _Txt_CountPerdiEjer.Text = _Txt_CountPerdiEjer.Tag.ToString() + " - " + _Ds_A.Tables[0].Rows[0]["cname"].ToString();
                            }
                            else
                            {
                                _Txt_CountPerdiEjer.Text = _Txt_CountPerdiEjer.Tag.ToString() + " - Cuenta sin descripción";
                            }
                        }
                        else
                        {
                            _Txt_CountPerdiEjer.Text = "";
                            _Txt_CountPerdiEjer.Tag = "";
                        }
                    }
                    else
                    {
                        _Txt_CountActivo.Tag = "";
                        _Txt_CountActivo.Text = "";
                        _Txt_CountPasivo.Text = "";
                        _Txt_CountPasivo.Tag = "";
                        _Txt_CountCapital.Text = "";
                        _Txt_CountCapital.Tag = "";
                        _Txt_CountUtilAcum.Text = "";
                        _Txt_CountUtilAcum.Tag = "";
                        _Txt_CountPerdiAcum.Text = "";
                        _Txt_CountPerdiAcum.Tag = "";
                        _Txt_CountUtilEjer.Text = "";
                        _Txt_CountUtilEjer.Tag = "";
                        _Txt_CountPerdiEjer.Text = "";
                        _Txt_CountPerdiEjer.Tag = "";
                    }
                    
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        try
                        { _Pbox_Imagen.Image = _Mtd_convertirByteparaImage(((byte[])_Row["clogo"])); }
                        catch { }
                    }

                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                    _Tb_Tab.SelectedIndex = 1;
                }
                Cursor = Cursors.Default;
            }
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog _Opf = new OpenFileDialog();
                _Opf.ShowDialog();
                _Pbox_Imagen.Image = Image.FromFile(_Opf.FileName);
            }
            catch { }
        }

        private void _Txt_Telefono1_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Telefono1.Text))
            {
                _Txt_Telefono1.Text = "";
            }
        }

        private void _Txt_Telefono2_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Telefono2.Text))
            {
                _Txt_Telefono2.Text = "";
            }
        }

        private void _Txt_Fax1_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Fax1.Text))
            {
                _Txt_Fax1.Text = "";
            }
        }

        private void _Txt_Fax2_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Fax2.Text))
            {
                _Txt_Fax2.Text = "";
            }
        }

        private void _Txt_Rif2_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Rif2.Text))
            {
                _Txt_Rif2.Text = "";
            }
        }

        private void _Txt_Rif3_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Rif3.Text))
            {
                _Txt_Rif3.Text = "";
            }
        }

        private void _Txt_Rif2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Rif3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Nit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Nit_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Nit.Text))
            {
                _Txt_Nit.Text = "";
            }
        }

        private void _Txt_Telefono1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Telefono2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Fax1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Fax2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Bt_Rif_Click(object sender, EventArgs e)
        {
            try
            {
                string _Str_Rif = _Cmb_Rif1.SelectedItem.ToString().Trim() + "-" + _Txt_Rif2.Text.Trim() + "-" + _Txt_Rif3.Text.Trim();
                string _Str_Url = CLASES._Cls_Varios_Metodos._Str_Servidor_Web + "/este.aspx?este=" + _Str_Rif.Replace("-", "");
                Frm_Navegador _Frm = new Frm_Navegador(_Str_Url, false);
                _Frm.MdiParent = this.MdiParent;
                _Frm.Dock = DockStyle.Fill;
                _Frm.Show();
            }
            catch { }
        }

        private void _Bt_Buscar_EnabledChanged(object sender, EventArgs e)
        {
            _Bt_Rif.Enabled = _Bt_Buscar.Enabled;
        }
        private bool _Mtd_Validar_Dominio(string _P_Str_Dominio)
        {
            try
            {
                string[] _Str_Split = _P_Str_Dominio.Split(new char[] { '.' });
                if (_P_Str_Dominio.IndexOf("@") != -1)
                {
                    MessageBox.Show("No debe introducir el símbolo '@'","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }
                else if (_Str_Split.Length == 2 & _P_Str_Dominio.Trim().Length>2)
                { return true; }
                else
                {
                    MessageBox.Show("El dominio que introdujo no es correcto. Por favor Verifique.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; 
                }
            }
            catch { return false; }
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

        private void _Cmb_AlmacenPre_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Cmb_AlmacenPre();
        }

        private void _Cmb_AlmacenMal_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Cmb_AlmacenMal();
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
                if (!_Txt_Nombre.Enabled & _Txt_Codigo.Text.Trim().Length == 0)
                {
                    e.Cancel = true;
                }
            }
        }

        private void _Bt_CountActivo_Click(object sender, EventArgs e)
        {
            DataSet _Ds;
            string _Str_CodCuenta = "", _Str_Sql = "";
            Frm_VstCuentas _Frm_Vista = new Frm_VstCuentas();
            _Frm_Vista.ShowDialog();
            _Str_CodCuenta = _Frm_Vista._Str_FrmNodeSelec;
            if (_Str_CodCuenta != "")
            {
                _Txt_CountActivo.Tag = _Str_CodCuenta;
                _Str_Sql = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_CodCuenta + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_CountActivo.Text = _Str_CodCuenta + " - " + Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                }
            }
            _Frm_Vista.Dispose();
        }

        private void _Bt_CountPasivo_Click(object sender, EventArgs e)
        {
            DataSet _Ds;
            string _Str_CodCuenta = "", _Str_Sql = "";
            Frm_VstCuentas _Frm_Vista = new Frm_VstCuentas();
            _Frm_Vista.ShowDialog();
            _Str_CodCuenta = _Frm_Vista._Str_FrmNodeSelec;
            if (_Str_CodCuenta != "")
            {
                _Txt_CountPasivo.Tag = _Str_CodCuenta;
                _Str_Sql = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_CodCuenta + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_CountPasivo.Text = _Str_CodCuenta + " - " + Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                }
            }
            _Frm_Vista.Dispose();
        }

        private void _Bt_CountCapital_Click(object sender, EventArgs e)
        {
            DataSet _Ds;
            string _Str_CodCuenta = "", _Str_Sql = "";
            Frm_VstCuentas _Frm_Vista = new Frm_VstCuentas();
            _Frm_Vista.ShowDialog();
            _Str_CodCuenta = _Frm_Vista._Str_FrmNodeSelec;
            if (_Str_CodCuenta != "")
            {
                _Txt_CountCapital.Tag = _Str_CodCuenta;
                _Str_Sql = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_CodCuenta + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_CountCapital.Text = _Str_CodCuenta + " - " + Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                }
            }
            _Frm_Vista.Dispose();
        }

        private void _Bt_CountUtilAcum_Click(object sender, EventArgs e)
        {
            DataSet _Ds;
            string _Str_CodCuenta = "", _Str_Sql = "";
            Frm_VstCuentas _Frm_Vista = new Frm_VstCuentas();
            _Frm_Vista.ShowDialog();
            _Str_CodCuenta = _Frm_Vista._Str_FrmNodeSelec;
            if (_Str_CodCuenta != "")
            {
                _Txt_CountUtilAcum.Tag = _Str_CodCuenta;
                _Str_Sql = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_CodCuenta + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_CountUtilAcum.Text = _Str_CodCuenta + " - " + Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                }
            }
            _Frm_Vista.Dispose();
        }

        private void _Bt_CountPerdiAcum_Click(object sender, EventArgs e)
        {
            DataSet _Ds;
            string _Str_CodCuenta = "", _Str_Sql = "";
            Frm_VstCuentas _Frm_Vista = new Frm_VstCuentas();
            _Frm_Vista.ShowDialog();
            _Str_CodCuenta = _Frm_Vista._Str_FrmNodeSelec;
            if (_Str_CodCuenta != "")
            {
                _Txt_CountPerdiAcum.Tag = _Str_CodCuenta;
                _Str_Sql = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_CodCuenta + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_CountPerdiAcum.Text = _Str_CodCuenta + " - " + Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                }
            }
            _Frm_Vista.Dispose();
        }

        private void _Bt_CountUtilEjer_Click(object sender, EventArgs e)
        {
            DataSet _Ds;
            string _Str_CodCuenta = "", _Str_Sql = "";
            Frm_VstCuentas _Frm_Vista = new Frm_VstCuentas();
            _Frm_Vista.ShowDialog();
            _Str_CodCuenta = _Frm_Vista._Str_FrmNodeSelec;
            if (_Str_CodCuenta != "")
            {
                _Txt_CountUtilEjer.Tag = _Str_CodCuenta;
                _Str_Sql = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_CodCuenta + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_CountUtilEjer.Text = _Str_CodCuenta + " - " + Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                }
            }
            _Frm_Vista.Dispose();
        }

        private void _Bt_CountPerdiEjer_Click(object sender, EventArgs e)
        {
            DataSet _Ds;
            string _Str_CodCuenta = "", _Str_Sql = "";
            Frm_VstCuentas _Frm_Vista = new Frm_VstCuentas();
            _Frm_Vista.ShowDialog();
            _Str_CodCuenta = _Frm_Vista._Str_FrmNodeSelec;
            if (_Str_CodCuenta != "")
            {
                _Txt_CountPerdiEjer.Tag = _Str_CodCuenta;
                _Str_Sql = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_CodCuenta + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_CountPerdiEjer.Text = _Str_CodCuenta + " - " + Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                }
            }
            _Frm_Vista.Dispose();
        }
    }
}