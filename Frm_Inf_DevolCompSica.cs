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
    public partial class Frm_Inf_DevolCompSica : Form
    {
        public Frm_Inf_DevolCompSica()
        {
            InitializeComponent();
            _Str_Comp = Frm_Padre._Str_Comp;
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_DevolCompSica";
        }
        string _Str_Comp = "";
        public Frm_Inf_DevolCompSica(string _P_Str_NR, string _P_Str_Comp)
        {
            InitializeComponent();
            _Txt_NR.Text = _P_Str_NR;
            _Str_Comp = _P_Str_Comp;
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_DevolCompSica";
            _Mtd_Busqueda();
        }
        private string _Mtd_NombComp()
        {
            string _Str_Cadena = "Select cname from TCOMPANY WHERE ccompany='" + _Str_Comp + "' AND cdelete='0'";
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
            ReportParameter[] parm = new ReportParameter[4];
            parm[0] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            parm[1] = new ReportParameter("CCOMPANY", _Str_Comp);
            parm[2] = new ReportParameter("CTIPOREPORTE", Convert.ToInt32(_Rbt_Res.Checked).ToString());
            parm[3] = new ReportParameter("CIDNOTRECEPC", _Txt_NR.Text.Trim());
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        private void _Txt_PreCarga_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_NR.Text))
            {
                _Txt_NR.Text = "";
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
            if (_Txt_NR.Text.Trim().Length > 0)
            {
                _Mtd_Busqueda();
            }
            else
            {
                _Er_Error.SetError(_Txt_NR, "Información requerida!!!");
            }
        }

        private void Frm_Inf_DevolCompSica_Load(object sender, EventArgs e)
        {

        }
    }
}