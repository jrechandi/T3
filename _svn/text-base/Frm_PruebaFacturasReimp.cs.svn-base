using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_PruebaFacturasReimp : Form
    {
        public Frm_PruebaFacturasReimp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDialog _My_PrintDialogo = new PrintDialog();
            if (_My_PrintDialogo.ShowDialog() == DialogResult.OK)
            {
                _Mtd_ImprimirFacturas(new string[] { textBox1.Text }, _My_PrintDialogo);
            }
        }
        private void _Mtd_ImprimirFacturas(string[] _P_Str_Facturas_, PrintDialog _Print)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Sql = "";
            DataSet _Ds_DataSet = new DataSet();
            DataTable _Dta_Tabla = new DataTable("Relacion");
            DataColumn _Dta_Columna;
            DataRow _Dta_Fila;
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.String");
            _Dta_Columna.ColumnName = "ccompany";
            _Dta_Columna.ReadOnly = true;
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.String");
            _Dta_Columna.ColumnName = "cfactura";
            _Dta_Columna.ReadOnly = true;
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.String");
            _Dta_Columna.ColumnName = "ccliente";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.String");
            _Dta_Columna.ColumnName = "c_rif";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.String");
            _Dta_Columna.ColumnName = "c_nomb_comer";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.String");
            _Dta_Columna.ColumnName = "cproducto";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "cempaques";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "cunidades";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "cdesc1";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "cdesc2";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "c_monto_si_bs";
            _Dta_Columna.ReadOnly = true;
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "c_impuesto_bs";
            _Dta_Columna.ReadOnly = true;
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "c_impuesto_fact";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.String");
            _Dta_Columna.ColumnName = "cname";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.String");
            _Dta_Columna.ColumnName = "c_razsocial_1";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.String");
            _Dta_Columna.ColumnName = "c_direcc_fiscal";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.String");
            _Dta_Columna.ColumnName = "c_telefono";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.String");
            _Dta_Columna.ColumnName = "nombredirecc";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.String");
            _Dta_Columna.ColumnName = "c_fecha_factura";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "cdias";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "cporcdes";
            _Dta_Columna.ReadOnly = true;
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "c_montotot_si_bs";
            _Dta_Columna.ReadOnly = true;
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "cimpuestofact";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "ctotalfact";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "ctotalcondesc";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "cdescuentofact";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "cimpdesc";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.String");
            _Dta_Columna.ColumnName = "cvendedor";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.String");
            _Dta_Columna.ColumnName = "produc_descrip";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.String");
            _Dta_Columna.ColumnName = "produc_descrip_2";
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.Double");
            _Dta_Columna.ColumnName = "ccostoneto_u1_bs";
            _Dta_Columna.ReadOnly = true;
            _Dta_Tabla.Columns.Add(_Dta_Columna);
            _Dta_Columna = new DataColumn();
            _Dta_Columna.DataType = System.Type.GetType("System.String");
            _Dta_Columna.ColumnName = "cpedido";
            _Dta_Columna.ReadOnly = true;
            _Dta_Tabla.Columns.Add(_Dta_Columna);

            foreach (string _Str_String in _P_Str_Facturas_)
            {
                _Str_Sql = "SELECT * FROM [VST_FACTURAEMISION] where ccompany='S01' and cfactura ='" + _Str_String + "'";
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                foreach (DataRow _Dtw_Item in _Ds_DataSet.Tables[0].Rows)
                {
                    _Dta_Tabla.Rows.Add(new object[] { _Dtw_Item[0].ToString().TrimEnd(), _Dtw_Item[1].ToString().TrimEnd(), _Dtw_Item[2].ToString().TrimEnd(), _Dtw_Item[3].ToString().TrimEnd(), _Dtw_Item[4].ToString().TrimEnd(), _Dtw_Item[5].ToString().TrimEnd(), _Dtw_Item[6].ToString().TrimEnd(), _Dtw_Item[7].ToString().TrimEnd(), _Dtw_Item[8].ToString().TrimEnd(), _Dtw_Item[9].ToString().TrimEnd(), _Dtw_Item[10].ToString().TrimEnd(), _Dtw_Item[11].ToString().TrimEnd(), _Dtw_Item[12].ToString().TrimEnd(), _Dtw_Item[13].ToString().TrimEnd(), _Dtw_Item[14].ToString().TrimEnd(), _Dtw_Item[15].ToString().TrimEnd(), _Dtw_Item[16].ToString().TrimEnd(), _Dtw_Item[17].ToString().TrimEnd(), _Dtw_Item[18].ToString().TrimEnd(), _Dtw_Item[19].ToString().TrimEnd(), _Dtw_Item[20].ToString().TrimEnd(), _Dtw_Item[21].ToString().TrimEnd(), _Dtw_Item[22].ToString().TrimEnd(), _Dtw_Item[23].ToString().TrimEnd(), _Dtw_Item[24].ToString().TrimEnd(), _Dtw_Item[25].ToString().TrimEnd(), _Dtw_Item[26].ToString().TrimEnd(), _Dtw_Item[27].ToString().TrimEnd(), _Dtw_Item[28].ToString().TrimEnd(), _Dtw_Item[29].ToString().TrimEnd(), _Dtw_Item[30].ToString().TrimEnd(), _Dtw_Item[31].ToString().TrimEnd() });
                }
            }
            if (_Dta_Tabla.Rows.Count > 0)
            {
                //PQC MCY (Impresora sin margen arriba) -- Ignacio - 19-06-2013 --
                if (T3.CLASES._Cls_Conexion._Int_Sucursal == 2)
                {
                    REPORTESS _Frm_Reporte = new REPORTESS("T3.Report.rFacturaEmisionMCY", _Dta_Tabla, _Print, true, "Section2", "", "", "");
                }
                else
                {
                    REPORTESS _Frm_Reporte = new REPORTESS("T3.Report.rFacturaEmision", _Dta_Tabla, _Print, true, "Section2", "", "", "");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar al menos una factura para continuar");
            }
            Cursor = Cursors.Default;
        }
    }
}