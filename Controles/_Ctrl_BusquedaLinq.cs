using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T3.Controles
{
    public partial class _Ctrl_BusquedaLinq : UserControl
    {
        public _Ctrl_BusquedaLinq()
        {
            InitializeComponent();
        }
        public void _Mtd_Tool_Menu(string _P_Str_Item)
        {
            ToolStripMenuItem _Tool_Menu = new ToolStripMenuItem();
            _Tool_Menu.Name = _P_Str_Item;
            _Tool_Menu.Text = _P_Str_Item;
            _Tool_Items.DropDownItems.Add(_Tool_Menu);
            _Tool_Items.DropDownItems[_P_Str_Item].Click += new EventHandler(_Mtd_Tool_Menu_Click);
            _Tool_Items.Tag = _Tool_Items.DropDownItems[0].Name;
        }
        void _Mtd_Tool_Menu_Click(object sender, EventArgs e)
        {
            _Tool_Items.Tag = ((ToolStripMenuItem)sender).Name;
        }
        //--------------------------------------
        /// <summary>
        /// Método que actualiza los registros
        /// </summary>
        /// <param name="_P_Frm_Formulario">Formulario que contiene el método</param>
        /// <param name="_P_Str_Metodo">Nombre del método</param>
        public void _Mtd_Tool_Metodo(Form _P_Frm_Formulario, string _P_Str_Metodo)
        {
            _Frm_Formulario = _P_Frm_Formulario;
            _Tool_Texto.Tag = _P_Str_Metodo;
        }
        private void _Mtd_InvocarMetodo()
        {
            _Frm_Formulario.GetType().GetMethod(_Tool_Texto.Tag.ToString()).Invoke(_Frm_Formulario, null);
        }
        Form _Frm_Formulario;
        private void _Tool_Texto_TextChanged(object sender, EventArgs e)
        {
            _Mtd_InvocarMetodo();
        }
        public int _Int_Desde = 0;
        public int _Int_Hasta = 0;
        private void _Bt_Antes_Click(object sender, EventArgs e)
        {
            if (_Int_Desde >= 2)
            { _Int_Desde -= 2; }
            _Mtd_InvocarMetodo();
        }

        private void _Bt_Next_Click(object sender, EventArgs e)
        {
            if (_Int_Desde < _Int_Hasta)
            { _Int_Desde += 2; }
            _Mtd_InvocarMetodo();
        }
    }
}
