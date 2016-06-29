using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace T3
{
    public partial class Frm_UsuarioAdminReseteo : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_Varios_Metodos = new CLASES._Cls_Varios_Metodos(true);
        public bool _Bol_UsuarioTieneAccesoAlFormulario;

        public Frm_UsuarioAdminReseteo()
        {
            InitializeComponent();
        }

        private void Frm_UsuarioAdminReseteo_Load(object sender, EventArgs e)
        {
            _Bol_UsuarioTieneAccesoAlFormulario = _Cls_Varios_Metodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_Varios_Metodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_USUARIO_ADMIN_RESETEO");
            _Mtd_LlenarListboxUsuarios();

            _Btn_Habilitar.Enabled = false;
            _Btn_Deshabilitar.Enabled = false;
            _Btn_Resetear.Enabled = false;
        }

        private void _Mtd_LlenarListboxUsuarios()
        {
            _Lb_Usuarios.Items.Clear();

            _Btn_Habilitar.Enabled = false;
            _Btn_Deshabilitar.Enabled = false;
            _Btn_Resetear.Enabled = false;

            if (_Bol_UsuarioTieneAccesoAlFormulario)
            {
                string _Str_SQL = "";

                _Str_SQL += "SELECT TUSER.cuser, TUSER.cuser + ' - ' + TUSER.cname as cname" + " ";
                _Str_SQL += "FROM TUSER INNER JOIN TUSERCOMP ON TUSER.cuser = TUSERCOMP.cuser" + " ";

                if (Frm_Padre._Str_Use.ToUpper() == "SISTEMA") // si se loguea el usuario 'sistema', tiene acceso a resetear su clave propia
                    _Str_SQL += "WHERE TUSER.cdelete = 0 AND TUSERCOMP.ccompany = '" + Frm_Padre._Str_Comp + "' ";
                else
                    _Str_SQL += "WHERE TUSER.cdelete = 0 AND TUSER.cuser <> 'SISTEMA' AND TUSERCOMP.ccompany = '" + Frm_Padre._Str_Comp + "' ";

                _Str_SQL += "ORDER BY dbo._FNC_ORDENAR_VENDEDORES(TUSER.cuser)";

                try
                {
                    DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                    if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                    {
                        _Lb_Usuarios.DataSource = _Ds_DataSet.Tables[0];
                        _Lb_Usuarios.DisplayMember = "cname";
                        _Lb_Usuarios.ValueMember = "cuser";
                    }
                    else
                    {
                        MessageBox.Show("No hay usuarios para administrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Ha ocurrido un error. Por favor contacte al desarrollador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                _Lb_Usuarios.SelectedIndex = -1;
            }
        }

        private void _Lb_Usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_HabilitarDeshabilitarBotones();
        }

        private void _Mtd_HabilitarDeshabilitarBotones()
        {
            if (_Lb_Usuarios.SelectedIndex != -1)
            {
                string _Str_LoginSeleccionado = _Lb_Usuarios.SelectedValue.ToString();

                _Btn_Habilitar.Enabled = false;
                _Btn_Deshabilitar.Enabled = false;
                _Btn_Resetear.Enabled = true;

                if (_Mtd_UsuarioNoEstaBloqueado(_Str_LoginSeleccionado)) _Btn_Deshabilitar.Enabled = true; else _Btn_Habilitar.Enabled = true;
            }
        }

        private bool _Mtd_UsuarioNoEstaBloqueado(string _Str_Login)
        {
            try
            {
                string _Str_SQL = "SELECT cuser FROM TUSER WHERE cuser = '" + _Str_Login + "' AND clocked = 0";
                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0) return true; else return false;
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error. Por favor contacte al desarrollador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        protected void _Btn_Habilitar_Click(object sender, EventArgs e)
        {
            string _Str_LoginSeleccionado = _Lb_Usuarios.SelectedValue.ToString();
            _Mtd_HabilitarUsuario(_Str_LoginSeleccionado);
        }

        protected void _Btn_Deshabilitar_Click(object sender, EventArgs e)
        {
            string _Str_LoginSeleccionado = _Lb_Usuarios.SelectedValue.ToString();
            _Mtd_DeshabilitarUsuario(_Str_LoginSeleccionado);
        }

        protected void _Btn_Resetear_Click(object sender, EventArgs e)
        {
            string _Str_LoginSeleccionado = _Lb_Usuarios.SelectedValue.ToString();
            _Mtd_ResetearClaveUsuario(_Str_LoginSeleccionado);
        }

        private void _Mtd_DeshabilitarUsuario(string _Str_LoginSeleccionado)
        {
            try
            {
                string _Str_SQL = "";
                _Str_SQL += "UPDATE TUSER" + " ";
                _Str_SQL += "SET clocked = 1, cuserupd = '" + Frm_Padre._Str_Use + "', cdateupd = GETDATE()" + " ";
                _Str_SQL += "WHERE cuser = '" + _Str_LoginSeleccionado + "'";

                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                _Mtd_HabilitarDeshabilitarBotones();
                MessageBox.Show("Se ha deshabilitado el acceso al usuario satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error. Por favor contacte al desarrollador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _Mtd_HabilitarUsuario(string _Str_LoginSeleccionado)
        {
            try
            {
                string _Str_SQL = "";
                _Str_SQL += "UPDATE TUSER" + " ";
                _Str_SQL += "SET clocked = 0, cuserupd = '" + Frm_Padre._Str_Use + "', cdateupd = GETDATE()" + " ";
                _Str_SQL += "WHERE cuser = '" + _Str_LoginSeleccionado + "'";

                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                _Mtd_HabilitarDeshabilitarBotones();
                MessageBox.Show("Se ha habilitado el acceso al usuario satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error. Por favor contacte al desarrollador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _Mtd_ResetearClaveUsuario(string _Str_LoginSeleccionado)
        {
            string _Str_PasswordProvisional = _Mtd_ClaveProvisonalAzar();
            string _Str_PasswordProvisionalEncriptado = _Mtd_ConvertToHash(_Str_PasswordProvisional);

            try
            {
                string _Str_SQL = "";
                _Str_SQL += "UPDATE TUSER" + " ";
                _Str_SQL += "SET cpassw = '" + _Str_PasswordProvisionalEncriptado + "', c_reseteo_clave = 1, cuserupd = '" + Frm_Padre._Str_Use + "', cdateupd = GETDATE()" + " ";
                _Str_SQL += "WHERE cuser = '" + _Str_LoginSeleccionado + "'";

                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                MessageBox.Show("La clave del usuario ha sido reseteada satisfactoriamente.\n\nLa nueva clave provisional del usuario es: " + _Str_PasswordProvisional + "\n\nDebe hacerle llegar esta clave al usuario para que pueda acceder al sistema.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error. Por favor contacte al desarrollador.");
            }
        }

        // general cuatro digitos al azar (0-9) y los une...
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

        private void Frm_UsuarioAdminReseteo_Shown(object sender, EventArgs e)
        {

            if (!_Bol_UsuarioTieneAccesoAlFormulario)
            {
                MessageBox.Show("Su usuario no tiene permisos para entrar en este módulo", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
        }

    }
}
