using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using CrystalDecisions.CrystalReports.Engine;
namespace T3
{
    public partial class Frm_Inf_AcumVenta : Form
    {
        public Frm_Inf_AcumVenta()
        {
            InitializeComponent();
            reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_AcumuladoVentas";
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
        private void _Mtd_BusquedaNueva()
        {
            reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[9];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CANO", "0");
            parm[2] = new ReportParameter("CMES", "0");
            parm[3] = new ReportParameter("CVENDEDORB", "NULL");
            parm[4] = new ReportParameter("CGERAREAB", "NULL");
            parm[5] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            parm[6] = new ReportParameter("CFECHAINIBUS", _Ctrl_ConsultaMes1._Str_FechaInicio);
            parm[7] = new ReportParameter("CFECHAFINBUS", _Ctrl_ConsultaMes1._Str_FechaFinal);
            parm[8] = new ReportParameter("BSFVISIBLE", "1");
            reportViewer1.ServerReport.SetParameters(parm);
            this.reportViewer1.ServerReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
        private void Frm_Inf_AcumVenta_Load(object sender, EventArgs e)
        {
            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();
        }

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            if (_Ctrl_ConsultaMes1._Bol_Listo)
            {
                this.Cursor = Cursors.WaitCursor;
                _Mtd_BusquedaNueva();
                this.Cursor = Cursors.Default;
            }
            else
            { MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
    }
}