using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_EstatusBackOrderDetalle : Form
    {
        public Frm_EstatusBackOrderDetalle(string _P_Str_Pedido,string _P_Str_Cod_Cliente,string _P_Str_DesCliente,string _P_Str_CodVendedor,string _P_Str_DesVendedor,double _P_Dbl_Cajas,double _P_Dbl_Unidades,string _P_Str_Fecha)
        {
            InitializeComponent();
            _Txt_Cajas.Text = _P_Dbl_Cajas.ToString();
            _Txt_Cliente.Text = _P_Str_DesCliente;
            _Txt_Fecha.Text = _P_Str_Fecha;
            _Txt_Pedido.Text = _P_Str_Pedido;
            _Txt_Unidades.Text = _P_Dbl_Unidades.ToString();
            _Txt_Vendedor.Text = _P_Str_DesVendedor;
            string _Str_Cadena = "SELECT dbo.TBACKORDER.cproducto AS Producto, "+
    "CASE WHEN cunidad2 = 0 THEN Rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END AS Descripción, "+
    "dbo.TBACKORDER.cempaques AS Cajas, "+
                      "dbo.TBACKORDER.cunidades AS Unidades "+
    "FROM dbo.TPRODUCTO INNER JOIN "+
                      "dbo.TBACKORDER ON dbo.TPRODUCTO.cproducto = dbo.TBACKORDER.cproducto INNER JOIN "+
                      "dbo.TMARCASM ON dbo.TPRODUCTO.cmarca = dbo.TMARCASM.cmarca " +
"WHERE (TBACKORDER.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TBACKORDER.cpedido = '" + _P_Str_Pedido + "') AND (TBACKORDER.cactivo=1)";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public Frm_EstatusBackOrderDetalle(string _P_Str_Pedido)
        {
            InitializeComponent();
            string _Str_Cadena = "SELECT * FROM VST_T3_BACKORDERDETAIL WHERE CPEDIDO='"+_P_Str_Pedido+"' AND CCOMPANY='"+Frm_Padre._Str_Comp+"'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Dtw_Item in _Ds.Tables[0].Rows)
            {
                _Txt_Cajas.Text = _Dtw_Item["cempaques"].ToString();
                _Txt_Cliente.Text = _Dtw_Item["c_nomb_comer"].ToString();
                _Txt_Fecha.Text = _Dtw_Item["c_fecha_pedido"].ToString();
                _Txt_Pedido.Text = _Dtw_Item["cpedido"].ToString();
                _Txt_Unidades.Text = _Dtw_Item["cunidades"].ToString();
                _Txt_Vendedor.Text = _Dtw_Item["cname"].ToString();
            }
            _Str_Cadena = "SELECT dbo.TBACKORDER.cproducto AS Producto, " +
    "CASE WHEN cunidad2 = 0 THEN Rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END AS Descripción, " +
    "dbo.TBACKORDER.cempaques AS Cajas, " +
                      "dbo.TBACKORDER.cunidades AS Unidades " +
    "FROM dbo.TPRODUCTO INNER JOIN " +
                      "dbo.TBACKORDER ON dbo.TPRODUCTO.cproducto = dbo.TBACKORDER.cproducto INNER JOIN " +
                      "dbo.TMARCASM ON dbo.TPRODUCTO.cmarca = dbo.TMARCASM.cmarca " +
"WHERE (TBACKORDER.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TBACKORDER.cpedido = '" + _P_Str_Pedido + "') ";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void Frm_EstatusBackOrderDetalle_Load(object sender, EventArgs e)
        {

        }
    }
}