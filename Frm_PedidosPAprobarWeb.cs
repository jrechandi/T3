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
    public partial class Frm_PedidosPAprobarWeb : Form
    {
        public Frm_PedidosPAprobarWeb()
        {
            InitializeComponent();
        }

        private void _Mtd_CargarGrid()
        {
            try
            {
                string _Str_SQL = "exec [PA_PEDIDOSPORAPROBARNOTIFICADORT3] '" + Frm_Padre._Str_Comp + "'";
                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexionSQL2012._Mtd_RetornarDataset(_Str_SQL);
                _Dg_Grid.AutoGenerateColumns = false;
                this._Dg_Grid.DataSource = _Ds_DataSet.Tables[0];
                _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch
            {
            }
        }

        private void Frm_PedidosPAprobarWeb_Load(object sender, EventArgs e)
        {
            _Mtd_CargarGrid(); 
        }
    }
}
