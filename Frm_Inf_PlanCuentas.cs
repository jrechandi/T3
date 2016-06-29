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
    public partial class Frm_Inf_PlanCuentas : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_Inf_PlanCuentas()
        {
            InitializeComponent();
            reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_PlanCuentas";
        }
        private void _Mtd_Busqueda()
        {
            string _Str_Count = _Txt_Cuenta.Text.Trim();
            string _Str_Descrip = _Txt_Descripcion.Text.Trim();
            if (_Str_Count.Trim().Length == 0)
            { _Str_Count = "0"; }
            if (_Str_Descrip.Trim().Length == 0)
            { _Str_Descrip = "0"; }
            reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[4];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CNOMBEMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            parm[2] = new ReportParameter("CCOUNT", _Str_Count);
            parm[3] = new ReportParameter("CDESCRIP", _Str_Descrip);
            reportViewer1.ServerReport.SetParameters(parm);
            this.reportViewer1.ServerReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void Frm_Inf_PlanCuentas_Load(object sender, EventArgs e)
        {

        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Busqueda();
            Cursor = Cursors.Default;
        }
    }
}