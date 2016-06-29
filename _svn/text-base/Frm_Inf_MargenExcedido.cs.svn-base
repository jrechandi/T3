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
    public partial class Frm_Inf_MargenExcedido : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_MargenExcedido()
        {
            InitializeComponent();
            var _Dt_Fecha = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Dtp_Desde.MaxDate = _Dt_Fecha;
            _Dtp_Desde.Value = new DateTime(_Dt_Fecha.Year, _Dt_Fecha.Month, 1);
            _Dtp_Hasta.Value = _Dt_Fecha;
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_MargenExcedido";
        }

        private void _Mtd_MostrarReporte()
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[6];
            parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
            parm[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[2] = new ReportParameter("CNOMBCOMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            parm[3] = new ReportParameter("CFECHADESDE", _Dtp_Desde.Value.ToShortDateString());
            parm[4] = new ReportParameter("CFECHAHASTA", _Dtp_Hasta.Value.ToShortDateString());
            parm[5] = new ReportParameter("CPRODUCTO", _Txt_Producto.Text.Trim());
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }

        private void Frm_Inf_MargenExcedido_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            _Mtd_MostrarReporte();
        }

        private void _Dtp_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dtp_Desde.MaxDate = _Dtp_Hasta.Value;
        }

        private void Frm_Inf_MargenExcedido_Load(object sender, EventArgs e)
        {

        }
    }
}