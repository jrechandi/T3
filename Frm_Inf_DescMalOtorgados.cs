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
    public partial class Frm_Inf_DescMalOtorgados : Form
    {
        public Frm_Inf_DescMalOtorgados()
        {
            InitializeComponent();
            reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_DescMalOtor";
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Txt_CajaDesde.Text.Trim().Length > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Busqueda();
                Cursor = Cursors.Default;
            }
            else
            { _Er_Error.SetError(_Bt_Desde, "Información requerida."); }
        }
        private void _Mtd_Busqueda()
        {
            ReportParameter[] parm = new ReportParameter[4];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CCAJAI", _Txt_CajaDesde.Text.Trim());
            parm[2] = new ReportParameter("CCAJAF", _Txt_CajaHasta.Text.Trim());
            string _Str_Cadena = "Select cname from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            parm[3] = new ReportParameter("CNOMBEMP", _Ds.Tables[0].Rows[0][0].ToString().TrimEnd());
            reportViewer1.ServerReport.SetParameters(parm);
            this.reportViewer1.ServerReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void _Bt_Desde_Click(object sender, EventArgs e)
        {
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(52, _Txt_CajaDesde, 0, "");
            _Frm.ShowDialog();
            if (_Txt_CajaDesde.Text.Trim().Length > 0)
            {
                _Txt_CajaHasta.Text = _Txt_CajaDesde.Text.Trim();
            }
        }

        private void _Bt_Hasta_Click(object sender, EventArgs e)
        {
            if (_Txt_CajaDesde.Text.Trim().Length > 0)
            {
                _Er_Error.Dispose();
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(52, _Txt_CajaHasta, 0, " AND convert(numeric(18,0),ccaja)>'" + _Txt_CajaDesde.Text.Trim() + "'");
                _Frm.ShowDialog();
            }
            else
            { _Er_Error.SetError(_Bt_Desde, "Información requerida."); }
        }

        private void Frm_Inf_DescMalOtorgados_Load(object sender, EventArgs e)
        {

        }
    }
}