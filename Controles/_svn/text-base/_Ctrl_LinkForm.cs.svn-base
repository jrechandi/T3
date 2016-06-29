using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class _Ctrl_LinkForm : UserControl
    {
        ToolStripItem _Tol_Menu;
        public string _Descripcion
        {
            get
            {
                return _Lnk_Descripcion.Text;
            }
            set
            {
                _Lnk_Descripcion.Text = value;
            }
        }
        public ToolStripItem _Menu
        {
            get
            {
                return _Tol_Menu;
            }
            set
            {
                _Tol_Menu = value;
            }
        }
        public _Ctrl_LinkForm()
        {
            InitializeComponent();
        }

        private void _Lnk_Descripcion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CLASES._Cls_Varios_Metodos._Mtd_VerificarCnn())
            {
                _Tol_Menu.PerformClick();
            }
            else
            {
                this.Parent.Enabled = false;
            }
        }
    }
}
