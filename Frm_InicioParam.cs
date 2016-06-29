using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;
using System.Threading;
namespace T3
{
    public partial class Frm_InicioParam : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_InicioParam()
        {
            InitializeComponent();
            _Mtd_CargarEstoy();
            _Mtd_CargarConectarme();
            if (CLASES._Cls_Conexion._Bol_Rdp)
            {
                _Cmb_Estoy.SelectedValue = "0";
                _Cmb_Estoy.Enabled = false;
            }
        }
        private bool _Mtd_VerificarIp(string _P_Str_Ip)
        {
            try
            {
                //IPAddress _Ip_Direccion = (Dns.GetHostEntry(_P_Str_Ip)).AddressList[0];
                Ping _Ping = new Ping();
                //PingReply _Reply = _Ping.Send(new System.Net.IPAddress(_Ip_Direccion.GetAddressBytes()), 1500);
                PingReply _Reply = _Ping.Send(_P_Str_Ip, 1500);
                return _Reply.Status == IPStatus.Success;
            }
            catch { }
            return false;
        }
        private void _Mtd_CargarEstoy()
        {
            _Cls_CargarCombo _Cls_Cargar = new _Cls_CargarCombo();
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("-1", "..."));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("13", "Fuera de la red de sodica"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("0", "DENCA, CONSSA U OFICINA EXTERNA"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("9", "SODICA CCS"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("2", "SODICA MCY"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("8", "SODICA BQTO"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("10", "SODICA BNAS"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("3", "SODICA MCBO"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("4", "SODICA SCB"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("6", "SODICA BNA"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("11", "SODICA CUP"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("5", "SODICA PZO"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("12", "SODICA CLZ"));
            _Cmb_Estoy.DataSource = _Cls_Cargar._List_Lista;
            _Cmb_Estoy.ValueMember = "Value";
            _Cmb_Estoy.DisplayMember = "Display";
            _Cmb_Estoy.SelectedValue = "-1";
        }
        private void _Mtd_CargarConectarme()
        {
            _Cls_CargarCombo _Cls_Cargar = new _Cls_CargarCombo();
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("-1", "..."));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("9", "SODICA CCS"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("2", "SODICA MCY"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("8", "SODICA BQTO"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("10", "SODICA BNAS"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("3", "SODICA MCBO"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("4", "SODICA SCB"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("6", "SODICA BNA"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("11", "SODICA CUP"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("5", "SODICA PZO"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("12", "SODICA CLZ"));
            _Cmb_Conectarme.DataSource = _Cls_Cargar._List_Lista;
            _Cmb_Conectarme.ValueMember = "Value";
            _Cmb_Conectarme.DisplayMember = "Display";
            _Cmb_Conectarme.SelectedValue = "-1";
        }
        private string _Mtd_RutaBat(object _P_Ob_Conectarme)
        {
            string _Str_RutaBat = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\OpenVPN\config\";
            switch (Convert.ToInt32(_P_Ob_Conectarme))
            {
                case 4:
                    _Str_RutaBat += @"04-SCB-T3\";
                    break;
                case 9:
                    _Str_RutaBat += @"09-CCS-T3\";
                    break;
                case 2:
                    _Str_RutaBat += @"02-MCY-T3\";
                    break;
                case 5:
                    _Str_RutaBat += @"05-PZO-T3\";
                    break;
                case 8:
                    _Str_RutaBat += @"08-BQTO-T3\";
                    break;
                case 10:
                    _Str_RutaBat += @"10-BNAS-T3\";
                    break;
                case 6:
                    _Str_RutaBat += @"06-BNA-T3\";
                    break;
                case 3:
                    _Str_RutaBat += @"03-MCBO-T3\";
                    break;
                case 11:
                    _Str_RutaBat += @"11-CUP-T3\";
                    break;
                case 12:
                    _Str_RutaBat += @"12-CLZ-T3\";
                    break;
            }
            return _Str_RutaBat + "Conectar.bat";
        }
        bool _Bol_Contectado = false;
        bool _Bol_LlaveVpnExiste = true;
        private void _Mtd_Conectar(object _P_Ob_Estoy, object _P_Ob_Conectarme)
        {
            _Bol_LlaveVpnExiste = true;
            if (Convert.ToInt32(_P_Ob_Estoy) == 0)
            {
                CLASES._Cls_Conexion._Bol_ConexionRemota = true;
                CLASES._Cls_Conexion._Int_Sucursal = Convert.ToInt32(_P_Ob_Conectarme);
                _Bol_Contectado = _Mtd_VerificarIp(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex.Remove((Program._MyClsCnn._mtd_conexion._g_Str_Stringconex.IndexOf(";"))).Replace("server=", ""));
            }
            else if (_P_Ob_Estoy == _P_Ob_Conectarme)
            {
                CLASES._Cls_Conexion._Bol_ConexionRemota = false;
                CLASES._Cls_Conexion._Int_Sucursal = Convert.ToInt32(_P_Ob_Conectarme);
                _Bol_Contectado = _Mtd_VerificarIp(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex.Remove((Program._MyClsCnn._mtd_conexion._g_Str_Stringconex.IndexOf(";"))).Replace("server=", ""));
            }
            else if ((Convert.ToString(_P_Ob_Estoy).Trim() == "8" & Convert.ToString(_P_Ob_Conectarme).Trim() == "10") | (Convert.ToString(_P_Ob_Estoy).Trim() == "10" & Convert.ToString(_P_Ob_Conectarme).Trim() == "8"))
            {
                CLASES._Cls_Conexion._Bol_ConexionRemota = true;
                CLASES._Cls_Conexion._Int_Sucursal = Convert.ToInt32(_P_Ob_Conectarme);
                _Bol_Contectado = _Mtd_VerificarIp(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex.Remove((Program._MyClsCnn._mtd_conexion._g_Str_Stringconex.IndexOf(";"))).Replace("server=", ""));
            }
            else if ((Convert.ToString(_P_Ob_Estoy).Trim() == "6" & Convert.ToString(_P_Ob_Conectarme).Trim() == "11") | (Convert.ToString(_P_Ob_Estoy).Trim() == "11" & Convert.ToString(_P_Ob_Conectarme).Trim() == "6"))
            {
                CLASES._Cls_Conexion._Bol_ConexionRemota = true;
                CLASES._Cls_Conexion._Int_Sucursal = Convert.ToInt32(_P_Ob_Conectarme);
                _Bol_Contectado = _Mtd_VerificarIp(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex.Remove((Program._MyClsCnn._mtd_conexion._g_Str_Stringconex.IndexOf(";"))).Replace("server=", ""));
            }
            else
            {
                CLASES._Cls_Conexion._Bol_ConexionRemota = true;
                CLASES._Cls_Conexion._Int_Sucursal = Convert.ToInt32(_P_Ob_Conectarme);
                string _Str_Ruta = _Mtd_RutaBat(_P_Ob_Conectarme);
                if (System.IO.File.Exists(_Str_Ruta))
                {
                    System.Diagnostics.Process _SysPro = new System.Diagnostics.Process();
                    _SysPro.StartInfo.FileName = _Str_Ruta;
                    _SysPro.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    _SysPro.Start();
                    _SysPro.WaitForExit(120000);
                    _Bol_Contectado = _Mtd_VerificarIp(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex.Remove((Program._MyClsCnn._mtd_conexion._g_Str_Stringconex.IndexOf(";"))).Replace("server=", ""));
                }
                else
                { _Bol_LlaveVpnExiste = false; }
            }
            if (!_Bol_Contectado)
            {
                CLASES._Cls_Conexion._Bol_ConexionRemota = false;
                CLASES._Cls_Conexion._Int_Sucursal = 0;
            }
        }
        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _Cmb_Estoy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Conectarme.DataSource != null)
            {
                _Cmb_Conectarme.SelectedIndex = 0;
                _Cmb_Conectarme.Enabled = _Cmb_Estoy.SelectedIndex > 0;
            }
        }

        private void _Cmb_Conectarme_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Bt_Conectar.Enabled = _Cmb_Conectarme.SelectedIndex > 0;
        }
        private void _Mtd_ComprobarConexion()
        {
            int _Int_Sw = 0;
        _Lbl_Label:
            try
            {
                _Int_Sw += 1;
                Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ccompany FROM TCOMPANY");
                _Bol_Contectado = true;
            }
            catch
            {
                _Bol_Contectado = false;
            }
            if (!_Bol_Contectado & _Int_Sw == 1)
            {
                goto _Lbl_Label;
            }
        }
        private void _Bt_Conectar_Click(object sender, EventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Cerrar_T3_Popup("openvpn");
            _Cls_VariosMetodos._Mtd_Cerrar_T3_Popup("openvpn-gui-1.0.3");
            object _Ob_Estoy = _Cmb_Estoy.SelectedValue;
            object _Ob_Conectarme = _Cmb_Conectarme.SelectedValue;
            Thread _Thr_Thread = new Thread(new System.Threading.ThreadStart(delegate { _Mtd_Conectar(_Ob_Estoy, _Ob_Conectarme); }));
            _Thr_Thread.Start();
            while (!_Thr_Thread.IsAlive) ;
            Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread, "Estableciendo conexión...");
            _Frm_Form.ShowDialog(this);
            _Frm_Form.Dispose();
            if (_Bol_Contectado)
            { _Mtd_ComprobarConexion(); }
            if (_Bol_Contectado)
            {
                this.Close();
            }
            else if (!_Bol_LlaveVpnExiste)
            {
                MessageBox.Show("No se encontraron los certificados correspondientes a la sucursal seleccionada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            { MessageBox.Show("Problemas con la conexion de internet. Intente mas tarde.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void Frm_InicioParam_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Bol_Contectado)
            { this.DialogResult = DialogResult.OK; }
            else
            { this.DialogResult = DialogResult.Cancel; }
        }
    }
}
