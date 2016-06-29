using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Presentacion : Form
    {
        public Frm_Presentacion()
        {
            InitializeComponent();
            //_Pbox.Image = (Image)T3.Properties.Resources.imgreportefalla;
            //_Pbox.Image = (Image)T3.Properties.Resources.Megaconcurso;
        }
        //int _Int_Sw = 1;
        private void _Bt_Siguiente_Click(object sender, EventArgs e)
        {
            //if (_Int_Sw == 1)
            //{ _Pbox.Image = (Image)T3.Properties.Resources.I2; }
            //else
            //{ this.Close(); }
            //_Int_Sw += 1;
            this.Close();
        }

        private void Frm_Presentacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (_Int_Sw != 2)
            //{ e.Cancel = true; }
        }
    }
}
