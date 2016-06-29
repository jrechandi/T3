using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using System.Threading;

namespace T3
{
    public partial class Frm_Navegador : Form
    {
        private readonly bool _G_Bol_EsCobranzaLocal;

        string _Str_Url = "";
        public Frm_Navegador(string _P_Str_Url,bool _P_Bol_Maximizado)
        {
            _Str_Url = _P_Str_Url;
            InitializeComponent();
            _G_Bol_EsCobranzaLocal = false;
            if (_P_Bol_Maximizado)
            {
                //this.WindowState = FormWindowState.Maximized;
            }
        }
        public Frm_Navegador(string _P_Str_Url, bool _P_Bol_Maximizado, bool _P_Bol_EsCobranzaLocal = true)
        {
            _Str_Url = _P_Str_Url;
            InitializeComponent();
            _G_Bol_EsCobranzaLocal = true;
            if (_P_Bol_Maximizado)
            {
                //this.WindowState = FormWindowState.Maximized;
            }
        }
        private void Frm_Navegador_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            webBrowser1.Visible = false;
            webBrowserCobranza.Visible = false;
            if (_G_Bol_EsCobranzaLocal)
            {
                webBrowserCobranza.Navigate(_Str_Url);
                webBrowserCobranza.Visible = true;
            }
            else
            {
                webBrowser1.Navigate(_Str_Url);
                webBrowser1.Visible = true;
            }
        }

        private void _Bt_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Navegador_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
        }

        private void webBrowserCobranza_Closing()
        {
            this.Close();
        }
    }
}