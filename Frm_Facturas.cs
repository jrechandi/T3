using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Facturas : Form
    {
        public Frm_Facturas()
        {
            InitializeComponent();
        }
        int _Int_Invisible = 0;
        string _Str_Cadena = "";
        public Frm_Facturas(int _P_Int_Invisibles,string _P_Str_Cadena)
        {
            InitializeComponent();
            _Int_Invisible = _P_Int_Invisibles;
            _Str_Cadena = _P_Str_Cadena;
        }
        private void Frm_Facturas_Load(object sender, EventArgs e)
        {
            DataSet _Ds = CLASES._Cls_Conexion._Mtd_Conexion_()._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            for (int _Int_i = 0; _Int_Invisible <= _Ds.Tables[0].Columns.Count; _Int_i++)
            {
                if (_Int_i >= _Int_Invisible)
                {
                    _Dg_Grid.Columns[_Int_i].Visible = false;
                }
            }
        }
    }
}