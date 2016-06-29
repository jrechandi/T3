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
    public partial class Frm_PedidosAutCredito : Form
    {
        public Frm_PedidosAutCredito()
        {
            InitializeComponent();
            _Mtd_CargarPedidosAutorizados();
        }
        string _Str_SentenciaSQL;
        private void _Mtd_CargarPedidosAutorizados()
        {
            try
            {
                _Str_SentenciaSQL = "SELECT ccompany as [Compañia], cpedido as [Pedido], c_fecha_pedido as [Fecha Pedido], c_montotot_si as [Monto S/Imp], c_impuesto as [Impuesto], ccliente as [Cód. Cliente], c_nomb_comer as [Descrip. Cliente], cuseraprobcredito as [Autorizado por] FROM VST_T3_PEDIDOSAUTORIZADOSPORPREFACTURAR";
                DataSet _Ds_DataSet = new DataSet();
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                _Dg_Grid.DataSource = _Ds_DataSet.Tables[0];
                _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch
            {
            }
        }
    }
}
