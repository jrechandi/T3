using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_MessageBox : Form
    {
        public Frm_MessageBox()
        {
            InitializeComponent();
        }
        int _Int_Sw = 0;
        public Frm_MessageBox(string _P_Str_Texto, string _P_Str_Titulo, Icon _P_Int_Icono, int _P_Int_Sw)
        {
            InitializeComponent();
            _Int_Sw = _P_Int_Sw;
            int _Int_Width_Lbl = _Lbl_Mensaje.Width;
            _Lbl_Mensaje.Text = _P_Str_Texto;
            this.Text = _P_Str_Titulo;
            _PBox_Icono.Image = (Image)_P_Int_Icono.ToBitmap();
            if (_P_Int_Sw == 1)
            { this.Width = 300; }
            else if (_P_Int_Sw == 2)
            { this.Width = 500; }
            else if (_P_Int_Sw == 3)
            { this.Width = 340; _Lbl_Mensaje.Font = new Font(new FontFamily("Arial"), 9, FontStyle.Bold); }
            else if (_P_Int_Sw == 4)
            { this.Width = 580; _Lbl_Mensaje.Font = new Font(new FontFamily("Arial"), 9, FontStyle.Bold); _Bt_Aceptar.Text = "Sí"; _Bt_Cancelar.Text = "No"; }
            else if (_P_Int_Sw == 5)
            { this.Width = 430; _Lbl_Mensaje.Font = new Font(new FontFamily("Arial"), 9, FontStyle.Bold); _Bt_Aceptar.Text = "Sí"; _Bt_Cancelar.Text = "No"; }
            else if (_P_Int_Sw == 6)
            { this.Width = 460; _Lbl_Mensaje.Font = new Font(new FontFamily("Arial"), 9, FontStyle.Bold); _Bt_Aceptar.Text = "Sí"; _Bt_Cancelar.Text = "No"; }
            _Mtd_Conf_Pnl_Inferior();
        }
        private void _Mtd_Conf_Pnl_Inferior()
        {
            int _Int_Global = _Bt_Aceptar.Width + _Bt_Cancelar.Width + 4;
            _Bt_Aceptar.Left = (_Pnl_Inferior.Width / 2) - (_Int_Global / 2);
            _Bt_Cancelar.Left = ((_Pnl_Inferior.Width / 2) - (_Int_Global / 2)) + _Bt_Aceptar.Width + 4;
        }
        bool _Bol_Sw = false;
        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (_Bol_Sw)
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            _Bol_Sw = true;
            _Bt_Aceptar.BackColor = _Bt_Cancelar.BackColor;
            _Bt_Aceptar.ForeColor = _Bt_Cancelar.ForeColor;
            if (_Int_Sw == 1)
            {
                int _Int_Width_Lbl = _Lbl_Mensaje.Width;
                _Lbl_Mensaje.Text = "Recuerde que al inactivar el vendedor no podra activarlo nuevamente.\n¿Desea continuar?";
                this.Width = 440;
                _Mtd_Conf_Pnl_Inferior();
                this.Left = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2);
                this.Top = (Screen.PrimaryScreen.WorkingArea.Height / 2) - (this.Height / 2);
            }
            else if (_Int_Sw == 2)
            {
                int _Int_Width_Lbl = _Lbl_Mensaje.Width;
                _Lbl_Mensaje.Text = "Recuerde que esta cambiando el costo neto de un producto.\n¿Desea continuar?";
                this.Width = 440;
                _Mtd_Conf_Pnl_Inferior();
                this.Left = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2);
                this.Top = (Screen.PrimaryScreen.WorkingArea.Height / 2) - (this.Height / 2);
            }
            else if (_Int_Sw == 3)
            {
                //Vacio. no es necesario código
            }
            else if (_Int_Sw == 4 || _Int_Sw == 5)
            {
                int _Int_Width_Lbl = _Lbl_Mensaje.Width;
                _Lbl_Mensaje.Text = "¿Está realmente seguro de continuar?";
                this.Width = 310;
                _Mtd_Conf_Pnl_Inferior();
                this.Left = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2);
                this.Top = (Screen.PrimaryScreen.WorkingArea.Height / 2) - (this.Height / 2);
            }
            else if (_Int_Sw == 6)
            {
                //Vacio. no es necesario código
            }
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
