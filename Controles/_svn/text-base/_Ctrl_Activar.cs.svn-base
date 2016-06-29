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
    public partial class _Ctrl_Activar : UserControl
    {
        readonly CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public _Ctrl_Activar()
        {
            InitializeComponent();
        }
        public _Ctrl_Activar(string _P_Str_Usuario, string _P_Str_Nombre, string _P_Str_Email, string _P_Str_Cargo, string _P_Str_ClaveTemporal, EnumEstatus _P_Enum_Estatus, EnumAccion _P_Enum_Accion, EnumTipoReseteo _P_Enum_TipoReseteo)
        {
            InitializeComponent();
            _Mtd_CargarTipoReseteo();
            Usuario = _P_Str_Usuario;
            Nombre = _P_Str_Nombre;
            Cargo = _P_Str_Cargo;
            Estatus = _P_Enum_Estatus;
            Accion = _P_Enum_Accion;
            TipoReseteo = _P_Enum_TipoReseteo;
            Email = _P_Str_Email;
            ClaveTemporal = _P_Str_ClaveTemporal;
        }
        public enum EnumAccion
        {
            H, I, R, N
        };
        public enum EnumEstatus
        {
            N, P, H
        };
        public enum EnumTipoReseteo
        {
            Resetear = 0, Usuario = 1, Email = 2
        };
        public string Usuario
        {
            get { return _Txt_Usuario.Text; }
            set { _Txt_Usuario.Text = value; }
        }
        public string Nombre
        {
            get { return _Lbl_NombreUsuario.Text; }
            set { _Lbl_NombreUsuario.Text = value; }
        }
        public string Email
        {
            get { return _Txt_Email.Text; }
            set { _Txt_Email.Text = value; }
        }
        public string ClaveTemporal
        {
            get { return _Txt_ClaveTemporal.Text; }
            set { _Txt_ClaveTemporal.Text = value; }
        }
        public string Cargo
        {
            get { return Convert.ToString(_Lbl_CargoUsuario.Tag); }
            set { _Lbl_CargoUsuario.Tag = value; _Lbl_CargoUsuario.Text = _Mtd_ObtenerCargo(value); }
        }
        EnumEstatus _Enum_Estatus;
        public EnumEstatus Estatus
        {
            get
            {
                return _Enum_Estatus;
            }
            set
            {
                switch (value)
                {
                    case EnumEstatus.N:
                        _Lbl_Estatus.Text = "No definido";
                        _Lbl_Estatus.ForeColor = Color.Black;
                        break;
                    case EnumEstatus.P:
                        _Lbl_Estatus.Text = "Pendiente";
                        _Lbl_Estatus.ForeColor = Color.FromArgb(192, 0, 0);
                        break;
                    default:
                        _Lbl_Estatus.Text = "Hecho";
                        _Lbl_Estatus.ForeColor = Color.Green;
                        break;
                }
                _Enum_Estatus = value;
            }
        }
        EnumAccion _Enum_Accion;
        public EnumAccion Accion
        {
            get 
            {
                return _Enum_Accion;
            }
            set 
            {
                switch (value)
                {
                    case EnumAccion.H:
                        _Rbt_Habilitar.Checked = true;
                        break;
                    case EnumAccion.I:
                        _Rbt_Inhabilitar.Checked = true;
                        break;
                    case EnumAccion.R:
                        _Rbt_Resetear.Checked = true;
                        break;
                    default:
                        _Rbt_Habilitar.Checked = false;
                        _Rbt_Inhabilitar.Checked = false;
                        _Rbt_Resetear.Checked = false;
                        break;
                }
                _Enum_Accion = value; 
            }
        }
        EnumTipoReseteo _Enum_TipoReseteo;
        public EnumTipoReseteo TipoReseteo
        {
            get 
            {
                return _Enum_TipoReseteo;
            }
            set 
            {
                _Cmb_Resetear.SelectedValue = Convert.ToString((int)value);
                _Enum_TipoReseteo = value; 
            }
        }
        bool _Bol_InformacionCompleta;
        public Boolean InformacionCompleta
        {
            get
            {
                return _Bol_InformacionCompleta;
            }
        }
        private void _Mtd_CargarTipoReseteo()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_Resetear.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "0"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Usuario", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("E-mail", "2"));
            _Cmb_Resetear.DataSource = _myArrayList;
            _Cmb_Resetear.DisplayMember = "Display";
            _Cmb_Resetear.ValueMember = "Value";
            _Cmb_Resetear.SelectedValue = "nulo";
            _Cmb_Resetear.DataSource = _myArrayList;
            _Cmb_Resetear.SelectedIndex = 0;
        }
        private string _Mtd_ObtenerCargo(string _P_Str_Cargo)
        {
            string _Str_Cadena = "select cdescripcion from T3TCARGOSNOM where cidcargonom='" + _P_Str_Cargo + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion2._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
            }
            return "";
        }

        private void _Rbt_Inhabilitar_CheckedChanged(object sender, EventArgs e)
        {
            _Enum_Accion = EnumAccion.I;
            _Txt_Email.Enabled = true;
            _Txt_Email.ReadOnly = true;
        }

        private void _Rbt_Resetear_CheckedChanged(object sender, EventArgs e)
        {
            _Enum_Accion = EnumAccion.R;
            _Mtd_CargarTipoReseteo();
        }

        private void _Cmb_Resetear_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(_Cmb_Resetear.SelectedValue).Trim() == Convert.ToString((int)EnumTipoReseteo.Usuario))
            { _Lbl_ClaveTemporal.Visible = true; _Txt_ClaveTemporal.Visible = true; }
            else if (Convert.ToString(_Cmb_Resetear.SelectedValue).Trim() == Convert.ToString((int)EnumTipoReseteo.Email))
            { _Txt_Email.Enabled = true; _Lbl_ClaveTemporal.Visible = true; _Txt_ClaveTemporal.Visible = true; }
        }

        private void _Rbt_Habilitar_CheckedChanged(object sender, EventArgs e)
        {
            _Enum_Accion = EnumAccion.H;
            if (_Rbt_Habilitar.Checked)
            { _Txt_Email.Enabled = true; _Lbl_ClaveTemporal.Visible = true; _Txt_ClaveTemporal.Visible = true; }
            else
            { _Txt_Email.Enabled = true; }
        }

        private void _Cmb_Resetear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(_Cmb_Resetear.SelectedValue).Trim() == "0")
            { _Enum_TipoReseteo = EnumTipoReseteo.Resetear; }
            else if (Convert.ToString(_Cmb_Resetear.SelectedValue).Trim() == "1")
            { _Enum_TipoReseteo = EnumTipoReseteo.Usuario; }
            else
            { _Enum_TipoReseteo = EnumTipoReseteo.Email; }
        }
    }
}