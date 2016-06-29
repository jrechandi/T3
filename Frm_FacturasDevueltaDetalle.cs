using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_FacturasDevueltaDetalle : Form
    {
        public Frm_FacturasDevueltaDetalle()
        {
            InitializeComponent();
        }
        public Frm_FacturasDevueltaDetalle(string _P_Str_Factura, string _P_Str_Compania)
        {
            InitializeComponent();
            _Mtd_MostrarFactura(_P_Str_Factura, _P_Str_Compania);
        }
        string _Str_SentenciaSQL;
        DataSet _Ds_DataSet = new DataSet();

        private void _Mtd_MostrarFactura(string _P_Str_Factura, string _P_Str_Compania)
        {
            try
            {
                _Str_SentenciaSQL = "SELECT * FROM VST_FACTURASDEVDETALLE WHERE CFACTURA='"+_P_Str_Factura+"' AND CCOMPANY='"+_P_Str_Compania+"'";
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                foreach (DataRow _Dtw_Item in _Ds_DataSet.Tables[0].Rows)
                {
                    _Txt_Cliente.Text = _Dtw_Item["ccliente"].ToString().TrimEnd();
                    _Txt_Vendedor.Text = _Dtw_Item["cvendedor"].ToString().TrimEnd();
                    _Txt_DireccionD.Text = _Dtw_Item["c_direcc_descrip"].ToString().TrimEnd();
                    _Txt_Factura.Text = _P_Str_Factura;
                    _Txt_Prefactura.Text = _Dtw_Item["cpfactura"].ToString().TrimEnd();
                    _Txt_Pedido.Text = _Dtw_Item["cpedido"].ToString().TrimEnd(); 
                }
                _Str_SentenciaSQL = "select cguiadesp,cfechasalida,cconcepto,c_obervapordevol from VST_FACTURADEVREPETIDAS where cfactura='" + _P_Str_Factura + "' and ccompany='" + _P_Str_Compania + "' order by cguiadesp asc";
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                _Dg_Grid.DataSource = _Ds_DataSet.Tables[0].DefaultView;
                _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch
            {
            }
        }

        private void Frm_FacturasDevueltaDetalle_Load(object sender, EventArgs e)
        {
            //this.MdiParent = this.MdiParent;
            //this.Dock = DockStyle.Fill;
        }
    }
}