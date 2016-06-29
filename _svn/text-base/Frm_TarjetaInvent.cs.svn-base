using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_TarjetaInvent : Form
    {
        public Frm_TarjetaInvent()
        {
            InitializeComponent();

        }
        public Frm_TarjetaInvent(string _P_Str_Tarjeta,string _P_Str_Producto,string _P_Str_Descripcion,string _P_Str_Presentacion)
        {
            InitializeComponent();
            _Txt_Tarjeta.Text = _P_Str_Tarjeta;
            _Txt_Codigo.Text = _P_Str_Producto;
            _Txt_Descripcion.Text = _P_Str_Descripcion.ToUpper();
            _Txt_Presentacion.Text = _P_Str_Presentacion;
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
        private void Frm_TarjetaInvent_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
        }
    }
}