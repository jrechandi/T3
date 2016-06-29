using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Imagen : Form
    {
        public Frm_Imagen()
        {
            InitializeComponent();
        }
        public Frm_Imagen(Image _P_Img_Imagen)
        {
            InitializeComponent();
            _PBox_Imagen.Image = _P_Img_Imagen;
        }
        private void Frm_Imagen_Load(object sender, EventArgs e)
        {
            _PBox_Imagen.Left = (_Pnl_Panel.Width / 2) - (_PBox_Imagen.Width / 2);
            _PBox_Imagen.Top = (_Pnl_Panel.Height / 2) - (_PBox_Imagen.Height / 2);
        }
    }
}
