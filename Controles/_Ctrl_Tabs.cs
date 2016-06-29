using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class _Ctrl_Tabs : UserControl
    {
        object[] _Ob_Parametros;
        Form _Frm_MdiParent;
        string _Str_Formulario;
        public _Ctrl_Tabs()
        {
            InitializeComponent();
        }
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
        public Color _Color
        {
            get
            {
                return _Lnk_Descripcion.LinkColor;
            }
            set
            {
                _Lnk_Descripcion.LinkColor = value;
            }
        }
        public string _Formulario
        {
            get
            {
                return _Str_Formulario;
            }
            set
            {
                _Str_Formulario = value;
            }
        }

        public object[] _Parametros
        {
            get
            {
                return _Ob_Parametros;
            }
            set
            {
                _Ob_Parametros = value;
            }
        }
        public Form _FormularioMdi
        {
            get
            {
                return _Frm_MdiParent;
            }
            set
            {
                _Frm_MdiParent = value;
            }
        }
        private void _Lnk_Descripcion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CLASES._Cls_Varios_Metodos._Mtd_VerificarCnn())
            {
                ((Frm_Padre)_Frm_MdiParent.FindForm())._Pnl_Espera.Visible = true;
                Form _Frm = (Form)Activator.CreateInstance(Type.GetType(_Str_Formulario), _Ob_Parametros);
                _Frm.MdiParent = _Frm_MdiParent;
                _Frm.Show();
                ((Frm_Padre)_Frm_MdiParent.FindForm())._Pnl_Espera.Visible = false;
            }
            else
            {
                this.Parent.Enabled = false;
            }
        }
    }
}
