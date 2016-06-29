using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_EstatusClientesDetalleCobros : Form
    {
        string _Str_FrmClienteId = "";
        string _Str_Comps = "";
        public Frm_EstatusClientesDetalleCobros(string _Pr_Str_ClienteId)
        {
            InitializeComponent();
            _Str_Comps = CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp();
            _Str_FrmClienteId = _Pr_Str_ClienteId;
            string _Str_Sql = "SELECT RTRIM(c_nomb_comer) FROM TCLIENTE WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _Str_FrmClienteId + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                this.Text = this.Text + "  " + _Str_FrmClienteId + "-" + _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
        }
        private void _Mtd_CargarConsulta()
        {
            double _Dbl_TotalSaldo = 0;
            object[] _Str_RowNew = new object[9];
            string _Str_Sql = "SELECT ctpodocdescrip,cnumdocu,ctpocanceldescrip,csaldofactura,cmontodeefectivo,cvendedor,cidrelacobro,ccompany,ctipodocument FROM VST_RELCOBRANZA_CLIENTESCONPEDIDOSBLOQUEADOS WHERE " + _Str_Comps + " AND cgroupcompany='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _Str_FrmClienteId + "' AND caprobado=1 AND caprobadocredito=0 AND crelalista=1";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion_T3WEB_Local._Mtd_RetornarDataset(_Str_Sql);
            _Dg_Grid.Rows.Clear();
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                Array.Copy(_Drow.ItemArray, _Str_RowNew, _Drow.ItemArray.Length);
                _Dg_Grid.Rows.Add(_Str_RowNew);
                _Dg_Grid[3, _Dg_Grid.RowCount - 1].Value = Convert.ToDouble(_Dg_Grid[3, _Dg_Grid.RowCount - 1].Value).ToString("#,##0.00");
                _Dg_Grid[4, _Dg_Grid.RowCount - 1].Value = Convert.ToDouble(_Dg_Grid[4, _Dg_Grid.RowCount - 1].Value).ToString("#,##0.00");
                _Dbl_TotalSaldo += Convert.ToDouble(_Drow["csaldofactura"].ToString());
            }
            _Str_Sql = "SELECT ctpodocdescrip,cnumdocu,ctpocanceldescrip,csaldofactura,cmontodeefectivo,cvendedor,cidrelacobro,ccompany,ctipodocument FROM VST_RELCOBRANZA_CAJ WHERE " + _Str_Comps + " AND cgroupcompany='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _Str_FrmClienteId + "' AND ccerrada='0'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                Array.Copy(_Drow.ItemArray, _Str_RowNew, _Drow.ItemArray.Length);
                _Dg_Grid.Rows.Add(_Str_RowNew);
                _Dg_Grid[3, _Dg_Grid.RowCount - 1].Value = Convert.ToDouble(_Dg_Grid[3, _Dg_Grid.RowCount - 1].Value).ToString("#,##0.00");
                _Dg_Grid[4, _Dg_Grid.RowCount - 1].Value = Convert.ToDouble(_Dg_Grid[4, _Dg_Grid.RowCount - 1].Value).ToString("#,##0.00");
                _Dbl_TotalSaldo += Convert.ToDouble(_Drow["csaldofactura"].ToString());
            }
            //_Str_Sql = "SELECT ctpodocdescrip,cnumdocu,ctpocanceldescrip,csaldofactura,cmontocancel,cvendedor,cidrelacobro FROM VST_RELCOBMyD_CAJA WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcompany='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _Str_FrmClienteId + "' AND caprobado=1 AND crelalista=1 AND TRELACCOBMcdelete=0 AND TRELACCOBDcdelete=0";
            //_Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            //{
            //    Array.Copy(_Drow.ItemArray, _Str_RowNew, _Drow.ItemArray.Length);
            //    _Dg_Grid.Rows.Add(_Str_RowNew);
            //    _Dg_Grid[3, _Dg_Grid.RowCount - 1].Value = Convert.ToDouble(_Dg_Grid[3, _Dg_Grid.RowCount - 1].Value).ToString("#,##0.00");
            //    _Dg_Grid[4, _Dg_Grid.RowCount - 1].Value = Convert.ToDouble(_Dg_Grid[4, _Dg_Grid.RowCount - 1].Value).ToString("#,##0.00");
            //}
            _Dg_Grid.Columns["ccompany"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Txt_TotalSaldo.Text = _Dbl_TotalSaldo.ToString("#,##0.00");
            _Txt_RelCobs.Text = _Mtd_ExtraerIdRelCob();
            _Txt_Vendedor.Text = _Mtd_ExtraerVendedores();
        }
        private string _Mtd_ExtraerVendedores()
        {
            string _Str_R = "", _Str_Vendedor="";
            foreach (DataGridViewRow _DgRow in _Dg_Grid.Rows)
            {
                if (_Str_Vendedor.IndexOf(_DgRow.Cells[5].Value.ToString())<0)
                {
                    _Str_Vendedor = _Str_Vendedor + _DgRow.Cells[5].Value.ToString() + ",";
                }
            }
            if (_Str_Vendedor.Length > 0)
            {
                _Str_Vendedor = _Str_Vendedor.Substring(0, _Str_Vendedor.Length - 1);
            }
            _Str_R = _Str_Vendedor;
            return _Str_R;
        }
        private string _Mtd_ExtraerIdRelCob()
        {
            string _Str_R = "", _Str_IdRelCob="";
            foreach (DataGridViewRow _DgRow in _Dg_Grid.Rows)
            {
                if (_Str_IdRelCob.IndexOf(_DgRow.Cells[6].Value.ToString()) < 0)
                {
                    _Str_IdRelCob = _Str_IdRelCob + _DgRow.Cells[6].Value.ToString() + ",";
                }
            }
            if (_Str_IdRelCob.Length > 0)
            {
                _Str_IdRelCob = _Str_IdRelCob.Substring(0, _Str_IdRelCob.Length - 1);
            }
            _Str_R = _Str_IdRelCob;
            return _Str_R;
        }

        private void Frm_EstatusClientesDetalleCobros_Load(object sender, EventArgs e)
        {
            _Mtd_CargarConsulta();
        }

        private void _Bt_Actualizar_Click(object sender, EventArgs e)
        {
            _Mtd_CargarConsulta();
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count == 1)
            {
                Cursor = Cursors.WaitCursor;
                Frm_EstatusClientesDetalleCobrosDet _Frm = new Frm_EstatusClientesDetalleCobrosDet(Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["ccompany"].Value).Trim(), Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["_Dg_GridCol_RelCobId"].Value).Trim(), Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["_Dg_GridCol_Ndoc"].Value).Trim(), Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["ctipodocument"].Value).Trim());
                Cursor = Cursors.Default;
                _Frm.ShowDialog(this);
            }
        }
    }
}