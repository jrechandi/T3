using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace T3
{
    public partial class Frm_Inf_LibroVentas : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_Inf_LibroVentas()
        {
            InitializeComponent();
            _Dt_Fecha.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_LibroVentas";
        }
        private void _Mtd_Busqueda()
        {
            ReportParameter[] parm = new ReportParameter[4];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CMES", _Dt_Fecha.Value.Month.ToString());
            parm[2] = new ReportParameter("CANO", _Dt_Fecha.Value.Year.ToString());
            string _Str_Cadena = "Select cname,crif from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            parm[3] = new ReportParameter("CNAMECOMP", _Ds.Tables[0].Rows[0][0].ToString().TrimEnd() + " RIF: " + _Ds.Tables[0].Rows[0][1].ToString().TrimEnd());
            reportViewer1.ServerReport.SetParameters(parm);
            this.reportViewer1.ServerReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Busqueda();
            Cursor = Cursors.Default;
        }
    }
}