using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_VistaPrevia : Form
    {
        string _Str_Sql = "";
        public Frm_VistaPrevia(string _P_str_Sql, string _P_Str_Nom_Proveedor, string _P_Str_Factura, string _P_Str_Inv, string _P_Str_Total_Sin_Imp,string _P_Str_Descuento, string _P_Str_SubTotal, string _P_Str_Impuesto, string _P_Str_Total,string _P_Str_Fecha)
        {
            InitializeComponent();
            _Txt_Descuento.Text = _P_Str_Descuento;
            _Txt_Impuesto.Text = _P_Str_Impuesto;
            _Txt_Inven.Text = _P_Str_Inv;
            //_Txt_OC.Text = _P_Str_OC;
            _Txt_Proveedor.Text=_P_Str_Nom_Proveedor;
            _Txt_SubTotal.Text = _P_Str_SubTotal;
            _Txt_Total.Text = _P_Str_Total;
            _Txt_TotalSinImp.Text = _P_Str_Total_Sin_Imp;
            _Txt_Fac.Text = _P_Str_Factura;
            _Txt_Fecha.Text = _P_Str_Fecha;
            _Str_Sql = _P_str_Sql;
        }

        private void Frm_VistaPrevia_Load(object sender, EventArgs e)
        {
            _Pnl_Panel.Left = (this.Width / 2) - (_Pnl_Panel.Width / 2);
            _Pnl_Panel.Top = (this.Height / 2) - (_Pnl_Panel.Height / 2);
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_Grid3.DataSource = _Ds.Tables[0];
            _Dg_Grid3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid3.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid3.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid3.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid3.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid3.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid3.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void _Pnl_Panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}