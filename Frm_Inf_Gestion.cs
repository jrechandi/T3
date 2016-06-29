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
    public partial class Frm_Inf_Gestion : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMedodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_Gestion()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_InfGestion";
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
        private void _Mtd_Busqueda()
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[5];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            parm[2] = new ReportParameter("CMONTH", "0");
            parm[3] = new ReportParameter("CYEAR", "0");
            parm[4] = new ReportParameter("CDAY", "0");
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }
        private void _Mtd_Busqueda2()
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[5];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            parm[2] = new ReportParameter("CYEAR", Convert.ToString(_Cmb_Year.SelectedValue).ToString());
            parm[3] = new ReportParameter("CMONTH", Convert.ToString(_Cmb_Month.SelectedValue).ToString());
            if (_Cmb_Day.SelectedIndex > 0)
            { parm[4] = new ReportParameter("CDAY", Convert.ToString(_Cmb_Day.SelectedValue).ToString()); }
            else
            { parm[4] = new ReportParameter("CDAY", "0"); }
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }
        private void _Mtd_Actualizar()
        {
            string _Str_Cadena = "EXEC PA_INF_GESTION '" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private void _Mtd_Year()
        {
            string _Str_Cadena = "SELECT DISTINCT YEAR(cfecha),YEAR(cfecha) FROM TINFGESTION WHERE ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY YEAR(cfecha) DESC";
            _Cls_VariosMedodos._Mtd_CargarCombo(_Cmb_Year, _Str_Cadena);
        }
        private void _Mtd_Month(int _P_Int_Year)
        {
            if (_P_Int_Year == 0) { _P_Int_Year = 0; }
            string _Str_Cadena = "SELECT DISTINCT MONTH(cfecha),CASE WHEN MONTH(cfecha)=1 THEN 'ENERO' WHEN MONTH(cfecha)=2 THEN 'FEBRERO' WHEN MONTH(cfecha)=3 THEN 'MARZO' WHEN MONTH(cfecha)=4 THEN 'ABRIL' WHEN MONTH(cfecha)=5 THEN 'MAYO' WHEN MONTH(cfecha)=6 THEN 'JUNIO' WHEN MONTH(cfecha)=7 THEN 'JULIO' WHEN MONTH(cfecha)=8 THEN 'AGOSTO' WHEN MONTH(cfecha)=9 THEN 'SEPTIEMBRE' WHEN MONTH(cfecha)=10 THEN 'OCTUBRE' WHEN MONTH(cfecha)=11 THEN 'NOVIEMBRE' WHEN MONTH(cfecha)=12 THEN 'DICIEMBRE' END FROM TINFGESTION WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND YEAR(cfecha)='" + _P_Int_Year + "' ORDER BY MONTH(cfecha) DESC";
            _Cls_VariosMedodos._Mtd_CargarCombo(_Cmb_Month, _Str_Cadena);
        }
        private void _Mtd_Day(int _P_Int_Year, int _P_Int_Month)
        {
            if (_P_Int_Month == 0) { _P_Int_Month = 0; }
            string _Str_Cadena = "SELECT DISTINCT DAY(cfecha),DAY(cfecha) FROM TINFGESTION WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND YEAR(cfecha)='" + _P_Int_Year + "' AND MONTH(cfecha)='" + _P_Int_Month + "' ORDER BY DAY(cfecha) DESC";
            _Cls_VariosMedodos._Mtd_CargarCombo(_Cmb_Day, _Str_Cadena);
        }
        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar(); _Mtd_Busqueda();
            this.Cursor = Cursors.Default;
        }
        private void Frm_Inf_Gestion_Load(object sender, EventArgs e)
        {

        }

        private void _Cmb_Year_DropDown(object sender, EventArgs e)
        {
            _Mtd_Year();
        }

        private void _Cmb_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Year.SelectedIndex > 0)
            { _Mtd_Month(Convert.ToInt32(_Cmb_Year.SelectedValue)); }
            else
            { _Cmb_Month.SelectedIndex = -1; }
        }

        private void _Cmb_Month_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Month.SelectedIndex > 0)
            { _Mtd_Day(Convert.ToInt32(_Cmb_Year.SelectedValue), Convert.ToInt32(_Cmb_Month.SelectedValue)); }
            else
            { _Cmb_Day.SelectedIndex = -1; }
        }

        private void _Bt_Consultar2_Click(object sender, EventArgs e)
        {
            if (_Cmb_Year.SelectedIndex > 0 & _Cmb_Month.SelectedIndex > 0)
            {
                this.Cursor = Cursors.WaitCursor; 
                _Mtd_Busqueda2(); 
                this.Cursor = Cursors.Default; 
            }
            else
            { MessageBox.Show("Debe seleccionar al menos un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Cmb_Month_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_Year.SelectedIndex > 0)
            { _Mtd_Month(Convert.ToInt32(_Cmb_Year.SelectedValue)); }
        }

        private void _Cmb_Day_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_Month.SelectedIndex > 0)
            { _Mtd_Day(Convert.ToInt32(_Cmb_Year.SelectedValue), Convert.ToInt32(_Cmb_Month.SelectedValue)); }
        }
    }
}