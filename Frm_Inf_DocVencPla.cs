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
    public partial class Frm_Inf_DocVencPla : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_DocVencPla()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_DocuVenciPla";
            _Mtd_CargarGerentes();
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
        private void _Mtd_CargarGerentes()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT cvendedor,cname from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and c_activo='1' and c_tipo_vend='2'";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Gerente, _Str_Cadena, true);
            Cursor = Cursors.Default;
        }
        private void _Mtd_Busqueda()
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            if (_Rb_Normal.Checked)
            { _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_DocuVenciPla"; }
            else
            { _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_DocuVenciPla2"; }
            string _Str_Gerente = "0";
            if (_Cmb_Gerente.SelectedIndex > 0)
            { _Str_Gerente = Convert.ToString(_Cmb_Gerente.SelectedValue).Trim(); }
            ReportParameter[] parm = new ReportParameter[5];
            parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
            parm[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[2] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            parm[3] = new ReportParameter("CDIAS", _Txt_Dias.Text.ToString());
            parm[4] = new ReportParameter("CGERAREA", _Str_Gerente);
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }
        private void Frm_Inf_DocVencPla_Load(object sender, EventArgs e)
        {

        }

        private void _Txt_Dias_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Dias, e, 10, 0);
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Txt_Dias.Text.Trim().Length > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Busqueda();
                Cursor = Cursors.Default;
            }
            else
            { _Er_Error.SetError(_Txt_Dias, "Información requerida."); }
        }

        private void _Cmb_Gerente_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarGerentes();
        }
    }
}