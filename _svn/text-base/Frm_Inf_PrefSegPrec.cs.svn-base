using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace T3
{
    public partial class Frm_Inf_PrefSegPrec : Form
    {
        public Frm_Inf_PrefSegPrec()
        {
            InitializeComponent();
        }

        private string _Mtd_NombComp()
        {
            string _Str_Cadena = "Select cname from dbo.TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp +
                                 "' AND cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
            }
            return "";
        }

        private void _Mtd_Busqueda()
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            FieldInfo fi = this._Rpt_Report.GetType()
                               .GetField("reportToolBar", BindingFlags.Instance | BindingFlags.NonPublic);
            object o;
            fi = (o = fi.GetValue(this._Rpt_Report)).GetType()
                                                    .GetField("printPreview",
                                                              BindingFlags.Instance | BindingFlags.NonPublic);
            (fi.GetValue(o) as ToolStripButton).Owner.Items.Remove(fi.GetValue(o) as ToolStripButton);
            fi = this._Rpt_Report.GetType().GetField("m_viewMode", BindingFlags.Instance | BindingFlags.NonPublic);
            fi.SetValue(this._Rpt_Report, DisplayMode.PrintLayout);
            this._Rpt_Report.ZoomMode = ZoomMode.Percent;
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_InfPrecarga";
            ReportParameter[] parm = new ReportParameter[3];
            parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
            parm[1] = new ReportParameter("CPRECARGA", _Txt_PreCarga.Text.Trim());
            parm[2] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }

        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any,
                                    System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        private void _Txt_PreCarga_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_PreCarga.Text))
            {
                _Txt_PreCarga.Text = "";
            }
        }

        private void _Txt_PreCarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Txt_PreCarga.Text.Trim().Length > 0)
            {
                _Mtd_Busqueda();
            }
            else
            {
                _Er_Error.SetError(_Txt_PreCarga, "Información requerida!!!");
            }
        }

        private void Frm_Inf_PrefSegPrec_Load(object sender, EventArgs e)
        {

        }

        private void _Rpt_Report_ReportError(object sender, ReportErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString());
        }
    }
}