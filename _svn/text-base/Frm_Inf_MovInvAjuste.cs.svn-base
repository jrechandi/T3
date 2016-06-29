using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace T3
{
    public partial class Frm_Inf_MovInvAjuste : Form
    {
        public Frm_Inf_MovInvAjuste()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_MovInvAjustes";
        }
        private string _Mtd_NombComp()
        {
            string _Str_Cadena = "Select cname from dbo.TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
            }
            return "";
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(33);
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
            if (_Frm._Str_FrmResult == "1")
            {
                _Txt_Proveedor.Tag = _Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString().ToUpper();
                _Txt_Proveedor.Text = _Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells[1].Value.ToString().ToUpper();
                _Txt_Desde.Text = "";
                _Txt_Hasta.Text = "";
            }
        }

        private void _Bt_Limpiar_Click(object sender, EventArgs e)
        {
            _Txt_Proveedor.Tag = "";
            _Txt_Proveedor.Text = "";
        }
        private void _Mtd_Busqueda(string _P_Str_Proveedor, string _P_Str_ProdDesde, string _P_Str_ProdHasta)
        {
            ReportParameter[] parm = new ReportParameter[9];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CNOMBCOMP", _Mtd_NombComp());
            parm[2] = new ReportParameter("CPRODUCTOI", _P_Str_ProdDesde);
            parm[3] = new ReportParameter("CPRODUCTOF", _P_Str_ProdHasta);
            parm[4] = new ReportParameter("CPROVEEDOR", _P_Str_Proveedor);
            parm[5] = new ReportParameter("CFECHAI", _Ctrl_ConsultaMes1._Str_FechaInicio);
            parm[6] = new ReportParameter("CFECHAF", _Ctrl_ConsultaMes1._Str_FechaFinal);
            parm[7] = new ReportParameter("CMME", _Chk_MME.Checked ? "1" : "0");
            parm[8] = new ReportParameter("CMMS", _Chk_MMS.Checked ? "1" : "0");
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }

        private void Frm_Inf_MovInvAjuste_Load(object sender, EventArgs e)
        {
            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();
        }

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            if (_Ctrl_ConsultaMes1._Bol_Listo)
            {
                string _Str_Proveedor = "nulo";
                string _Str_ProdDesde = "nulo";
                string _Str_ProdHasta = "nulo";
                if (Convert.ToString(_Txt_Proveedor.Tag).Trim().Length>0)
                { _Str_Proveedor = Convert.ToString(_Txt_Proveedor.Tag).Trim(); }
                if (_Txt_Desde.Text.Trim().Length > 0)
                { _Str_ProdDesde = _Txt_Desde.Text.Trim(); }
                if (_Txt_Hasta.Text.Trim().Length > 0)
                { _Str_ProdHasta = _Txt_Hasta.Text.Trim(); }
                Cursor = Cursors.WaitCursor;
                _Mtd_Busqueda(_Str_Proveedor, _Str_ProdDesde, _Str_ProdHasta);
                Cursor = Cursors.Default;
            }
            else
            { MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Bt_Desde_Click(object sender, EventArgs e)
        {
            if (_Txt_Proveedor.Text.Trim().Length > 0)
            {
                string _Str_Desde = _Txt_Desde.Text;
                Cursor = Cursors.WaitCursor;
                Frm_BusquedaAvanzada2 _Frm = new Frm_BusquedaAvanzada2(_Txt_Desde, new TextBox(), "", Convert.ToString(_Txt_Proveedor.Tag).Trim());
                Cursor = Cursors.Default;
                _Frm.ShowDialog(this);
                if (_Txt_Desde.Text.Trim() != _Str_Desde.Trim())
                {
                    _Txt_Hasta.Text = "";
                }
            }
            else
            { MessageBox.Show("Debe elegir un proveedor para seleccionar esta opción"); }
        }

        private void _Bt_Hasta_Click(object sender, EventArgs e)
        {
            if (_Txt_Desde.Text.Trim().Length > 0)
            {
                Cursor = Cursors.WaitCursor;
                Frm_BusquedaAvanzada2 _Frm = new Frm_BusquedaAvanzada2(_Txt_Hasta, new TextBox(), " AND cproducto>'" + _Txt_Desde.Text.Trim() + "'", Convert.ToString(_Txt_Proveedor.Tag).Trim());
                Cursor = Cursors.Default;
                _Frm.ShowDialog(this);
            }
            else
            { MessageBox.Show("Debe seleccionar ingresar datos en el cuadro de texto 'Desde' para seleccionar esta opción", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Bt_Limpiar_D_Click(object sender, EventArgs e)
        {
            _Txt_Desde.Text = "";
            _Txt_Hasta.Text = "";
        }

        private void _Bt_Limpiar_H_Click(object sender, EventArgs e)
        {
            _Txt_Hasta.Text = "";
        }
    }
}
