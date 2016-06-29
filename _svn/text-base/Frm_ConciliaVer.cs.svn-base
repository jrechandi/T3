using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConciliaVer : Form
    {
        public Frm_ConciliaVer()
        {
            InitializeComponent();
        }

        private void Frm_ConciliaVer_Load(object sender, EventArgs e)
        {
            _Mtd_CargarGrid();
        }

        private void _Mtd_CargarGrid()
        {
            object[] _Str_RowNew = new object[9];
            string _Str_Sql = "SELECT cconciliacion,cadetecon,cbanco,cbanconame,cnumcuenta,cnumcuentaname,csaldosegl,cdesde,chasta FROM VST_CONCILIACONC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_Consulta.Rows.Clear();
            foreach (DataRow _DataR in _Ds.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_Consulta.Rows.Add(_Str_RowNew);
                if (Convert.ToString(_Dg_Consulta[1, _Dg_Consulta.RowCount - 1].Value) != "")
                {
                    _Dg_Consulta[1, _Dg_Consulta.RowCount - 1].Value = Convert.ToDateTime(_Dg_Consulta[1, _Dg_Consulta.RowCount - 1].Value).ToShortDateString();
                }
                if (Convert.ToString(_Dg_Consulta[7, _Dg_Consulta.RowCount - 1].Value) != "")
                {
                    _Dg_Consulta[7, _Dg_Consulta.RowCount - 1].Value = Convert.ToDateTime(_Dg_Consulta[7, _Dg_Consulta.RowCount - 1].Value).ToShortDateString();
                }
                if (Convert.ToString(_Dg_Consulta[8, _Dg_Consulta.RowCount - 1].Value) != "")
                {
                    _Dg_Consulta[8, _Dg_Consulta.RowCount - 1].Value = Convert.ToDateTime(_Dg_Consulta[8, _Dg_Consulta.RowCount - 1].Value).ToShortDateString();
                }
                if (Convert.ToString(_Dg_Consulta[6, _Dg_Consulta.RowCount - 1].Value) != "")
                {
                    _Dg_Consulta[6, _Dg_Consulta.RowCount - 1].Value = Convert.ToDouble(_Dg_Consulta[6, _Dg_Consulta.RowCount - 1].Value).ToString("#,##0.00");
                }
            }
            _Dg_Consulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}