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
    public partial class Frm_Inf_RelaCheqRecu : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_RelaCheqRecu()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_RelacionCheqRecup";
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
            ReportParameter[] parm = new ReportParameter[5];
            parm[0] = new ReportParameter("CGRUPOCOMP", Frm_Padre._Str_GroupComp);
            parm[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[2] = new ReportParameter("CNOMBCOMP", _Mtd_NombComp());
            parm[3] = new ReportParameter("CCAJAI", _Txt_CajaDesde.Text.ToString());
            parm[4] = new ReportParameter("CCAJAF", _Txt_CajaHasta.Text.ToString());
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }

        private void Frm_Inf_RelaCheqRecu_Load(object sender, EventArgs e)
        {

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

    }
}