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
    public partial class Frm_Inf_HistCliente : Form
    {
        public Frm_Inf_HistCliente()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
        }
        public Frm_Inf_HistCliente(string _P_Str_CodCliente, string _P_Str_DesCliente)
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Txt_Cliente.Tag = _P_Str_CodCliente;
            _Txt_Cliente.Text = _P_Str_DesCliente;
        }
        private void _Mtd_Busqueda()
        {
            if (_Rb_Fac.Checked)
            { _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_HistoricoClienteFact"; }
            else if(_Rb_Cheq.Checked)
            { _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_HistoricoClienteChqDev"; }
            else if (_Rb_ND.Checked)
            { _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_HistoricoClienteND"; }
            else
            { _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_HistoricoClienteNC"; }
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[4];
            parm[0] = new ReportParameter("CGRUPOCOMP", Frm_Padre._Str_GroupComp);
            parm[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[2] = new ReportParameter("CNOMBCOMP", _Mtd_NombComp());
            parm[3] = new ReportParameter("CCLIENTE", _Txt_Cliente.Tag.ToString());
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
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
        private void Frm_Inf_HistCliente_Load(object sender, EventArgs e)
        {

        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            if (_Txt_Cliente.Text.Trim().Length > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Busqueda();
                Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(32);
            _Frm.ShowDialog();
            if (_Frm._Str_FrmResult == "1")
            {
                _Txt_Cliente.Tag = _Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString().ToUpper();
                _Txt_Cliente.Text = _Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells[1].Value.ToString().ToUpper();
            }
        }
    }
}