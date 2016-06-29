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
    public partial class Frm_Inf_EgreCheqTransito : Form
    {
        public Frm_Inf_EgreCheqTransito()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
        }
        private void _Mtd_Busqueda()
        {
            if (_Rb_F.Checked)
            { _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_EgreCheqTransito"; }
            else
            { _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_EgreCheqTransitoV"; }
            ReportParameter[] parm = new ReportParameter[1];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }
        private void Frm_Inf_EgreCheqTransito_Load(object sender, EventArgs e)
        {

        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Busqueda();
            Cursor = Cursors.Default;
        }
    }
}