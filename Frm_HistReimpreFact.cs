using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_HistReimpreFact : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_HistReimpreFact()
        {
            InitializeComponent();
            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
        }
        private void _Mtd_Busqueda()
        {
            string _Str_Sql = "SELECT TREIMPREFACT.cidreimprefact AS ID, CONVERT(VARCHAR, TREIMPREFACT.cfechahora, 103) AS Fecha, " +
            "TREIMPREFACT.cfactura AS Factura, TUSER.cname AS Usuario FROM TREIMPREFACT INNER JOIN TUSER ON TREIMPREFACT.cusuario = TUSER.cuser " +
            "WHERE (TREIMPREFACT.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TREIMPREFACT.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TUSER.cdelete = '0') AND (convert(datetime,convert(varchar(255),cfechahora,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dt_Desde.Value) + "' AND '" + _Cls_Formato._Mtd_fecha(_Dt_Hasta.Value) + "')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _Dg_Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (_Dg_Grid.RowCount == 0)
            { MessageBox.Show("No existen reipresiones de facturas en el periodo selecionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private void Frm_HistReimpreFact_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void _Dt_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dt_Desde.MaxDate = _Dt_Hasta.Value;
        }

        private void _Lkbl_Ayer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())).AddDays(-1);
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())).AddDays(-1);
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())).AddDays(-1);
        }

        private void _Lkbl_Hoy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_Busqueda();
            this.Cursor = Cursors.Default;
        }
    }
}