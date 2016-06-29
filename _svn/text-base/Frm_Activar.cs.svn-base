using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Activar : Form
    {
        string _G_Str_Ticket = "";
        public Frm_Activar(string _P_Str_Ticket)
        {
            InitializeComponent();
            _G_Str_Ticket = _P_Str_Ticket;
            _Mtd_AgregarItemas(_P_Str_Ticket);
        }
        private void _Mtd_AgregarItemas(string _P_Str_Ticket)
        {
            Controles._Ctrl_Activar _Ctrl_Activar;
            string _Str_Cadena = "select cuser,cnameuser,cidcargo,cemailuser,caccion,cestatus,ctiporeseteo,cclavetemp from T3TREPORTFALLAACTIVARv1 where cidfalla='" + _P_Str_Ticket + "' order by ciditem";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion2._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Ctrl_Activar = new T3.Controles._Ctrl_Activar(_Row["cuser"].ToString(), _Row["cnameuser"].ToString(), _Row["cemailuser"].ToString(), _Row["cidcargo"].ToString(), _Row["cclavetemp"].ToString(), (T3.Controles._Ctrl_Activar.EnumEstatus)Enum.Parse(typeof(T3.Controles._Ctrl_Activar.EnumEstatus), _Row["cestatus"].ToString()), (T3.Controles._Ctrl_Activar.EnumAccion)Enum.Parse(typeof(T3.Controles._Ctrl_Activar.EnumAccion), _Row["caccion"].ToString()), (T3.Controles._Ctrl_Activar.EnumTipoReseteo)Enum.Parse(typeof(T3.Controles._Ctrl_Activar.EnumTipoReseteo), _Row["ctiporeseteo"].ToString()));
                _Pnl_Contenedor.Controls.Add(_Ctrl_Activar);
                _Ctrl_Activar.Dock = DockStyle.Top;
                _Ctrl_Activar.BringToFront();
            }
        }
    }
}
