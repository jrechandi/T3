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
    public partial class Frm_Inf_List_CheqTransm : Form
    {
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        string _Str_ccount = "TODOS";
        public Frm_Inf_List_CheqTransm()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_ListCheqTransm";
        }
        private void _Mtd_CargarBancoOtros()
        {
            string _Str_Sql = "SELECT TCUENTBANC.cnumcuenta, TCUENTBANC.cname FROM TCUENTBANC WHERE TCUENTBANC.ccompany='" + Frm_Padre._Str_Comp + "'";
            _Cb_Banco.SelectedIndexChanged -= new System.EventHandler(_Cb_Banco_SelectedIndexChanged);
            myUtilidad._Mtd_CargarCombo(_Cb_Banco, _Str_Sql);            
            _Cb_Banco.SelectedIndexChanged += new System.EventHandler(_Cb_Banco_SelectedIndexChanged);
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
        private void Frm_Inf_List_CheqTransm_Load(object sender, EventArgs e)
        {
            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();
            _Mtd_CargarBancoOtros();
        }

        private void _Cb_Banco_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarBancoOtros();
        }
        private void _Mtd_Busqueda()
        {
            string _Str_FechaInicial;
            string _Str_FechaFinal;
            if (_Ctrl_ConsultaMes1._Rb_Mes.Checked)
            {
                var _Int_Año = Convert.ToInt32(_Ctrl_ConsultaMes1._Cmb_Year.SelectedValue);
                var _Int_Mes = Convert.ToInt32(_Ctrl_ConsultaMes1._Cmb_Month.SelectedValue);
                _Str_FechaInicial = new DateTime(_Int_Año, _Int_Mes, 1).ToShortDateString();
                _Str_FechaFinal = new DateTime(_Int_Año, _Int_Mes, DateTime.DaysInMonth(_Int_Año, _Int_Mes)).ToShortDateString();
            }
            else
            {
                _Str_FechaInicial = _Ctrl_ConsultaMes1._Str_FechaInicio;
                _Str_FechaFinal = _Ctrl_ConsultaMes1._Str_FechaFinal;
            }
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            var parm = new ReportParameter[8];
            parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
            parm[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[2] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            parm[3] = new ReportParameter("CNUMCUENTAD", _Cb_Banco.SelectedValue.ToString());
            parm[4] = new ReportParameter("CNUMCUENTADNAME", _Cb_Banco.Text);
            parm[5] = new ReportParameter("CCOUNT", _Str_ccount);
            parm[6] = new ReportParameter("CFECHAI", _Str_FechaInicial);
            parm[7] = new ReportParameter("CFECHAF", _Str_FechaFinal);
            _Rpt_Report.ServerReport.SetParameters(parm);
            this._Rpt_Report.ServerReport.Refresh();
            this._Rpt_Report.RefreshReport(); 
        }
        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            if (_Ctrl_ConsultaMes1._Bol_Listo)
            {
                this.Cursor = Cursors.WaitCursor;
                _Mtd_Busqueda();
                this.Cursor = Cursors.Default;
            }
            else
            { MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private void _Cb_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _Str_Sql = "";
            DataSet _Ds;
            if (_Cb_Banco.SelectedIndex != 0)
            {
                _Str_Sql = "SELECT TCUENTBANC.ccount FROM TCUENTBANC WHERE TCUENTBANC.ccompany='" + Frm_Padre._Str_Comp + "' AND cnumcuenta='" + _Cb_Banco.SelectedValue.ToString().Trim() + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                _Str_ccount = _Ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                _Str_ccount = "TODOS";
            }
        }
    }
}
