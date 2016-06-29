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
    public partial class Frm_Inf_AnalisisClientes : Form
    {
        public Frm_Inf_AnalisisClientes()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_AnalisisCliente";
        }
        private string _Mtd_NombComp()
        {
            string _Str_Cadena = "Select cname from TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
            }
            return "";
        }
        private int _Mtd_TipoReporte()
        {
            if (_Rbt_SinFiltro.Checked)
            { return 1; }
            else if (_Rbt_Enrut.Checked)
            { return 2; }
            else if (_Rbt_NoEnrut.Checked)
            { return 3; }
            else if (_Rbt_Zonif.Checked)
            { return 4; }
            else
            { return 5; }
        }
        private string _Mtd_DescripReporte()
        {
            string _Str_Cadena = "Clientes";
            //------------------------------
            if (_Rbt_Activos.Checked)
            { _Str_Cadena += " activos"; }
            else
            { _Str_Cadena += " inactivos"; }
            //------------------------------
            if (_Rbt_Enrut.Checked)
            { _Str_Cadena += " enrutados"; }
            else if (_Rbt_NoEnrut.Checked)
            { _Str_Cadena += " no enrutados"; }
            else if (_Rbt_Zonif.Checked)
            { _Str_Cadena += " zonificados"; }
            else if(_Rbt_NoZonif.Checked)
            { _Str_Cadena += " no zonificados"; }
            //------------------------------
            return _Str_Cadena;
        }
        private void _Mtd_Busqueda(string _P_Str_Cliente)
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[5];
            parm[0] = new ReportParameter("CCLIENTE", _P_Str_Cliente);
            parm[1] = new ReportParameter("CACTIVO", Convert.ToInt32(_Rbt_Activos.Checked).ToString());
            parm[2] = new ReportParameter("CTIPOREPORTE", _Mtd_TipoReporte().ToString());
            parm[3] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            parm[4] = new ReportParameter("CREPORTEDESCRIP", _Mtd_DescripReporte());
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cliente = "0";
            if (Convert.ToString(_Txt_Cliente.Tag).Trim().Length > 0)
            { _Str_Cliente = Convert.ToString(_Txt_Cliente.Tag).Trim(); }
            _Mtd_Busqueda(_Str_Cliente);
            Cursor = Cursors.Default;
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(32);
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
            if (_Frm._Str_FrmResult == "1")
            {
                _Txt_Cliente.Tag = _Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString().ToUpper();
                _Txt_Cliente.Text = _Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells[1].Value.ToString().ToUpper();
            }
        }

        private void _Bt_Limpiar_Click(object sender, EventArgs e)
        {
            _Txt_Cliente.Text = "";
            _Txt_Cliente.Tag = "";
        }

        private void _Rbt_Activos_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Activos.Checked)
            {
                _Txt_Cliente.Text = "";
                _Txt_Cliente.Tag = "";
                _Txt_Cliente.Enabled = true;
                _Bt_Buscar.Enabled = true;
                _Bt_Limpiar.Enabled = true;
                _Rbt_Enrut.Enabled = true;
                _Rbt_NoEnrut.Enabled = true;
                _Rbt_Zonif.Enabled = true;
                _Rbt_NoZonif.Enabled = true;
            }
            else
            {
                _Txt_Cliente.Text = "";
                _Txt_Cliente.Tag = "";
                _Txt_Cliente.Enabled = false;
                _Bt_Buscar.Enabled = false;
                _Bt_Limpiar.Enabled = false;
                _Rbt_SinFiltro.Checked = true;
                _Rbt_Enrut.Enabled = false;
                _Rbt_NoEnrut.Enabled = false;
                _Rbt_Zonif.Enabled = false;
                _Rbt_NoZonif.Enabled = false;
            }
        }
    }
}