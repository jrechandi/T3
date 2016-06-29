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
    public partial class Frm_Inf_ConsultaClientes : Form
    {
        public Frm_Inf_ConsultaClientes()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_InfConsultaClientes";
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
        private void _Mtd_Busqueda(string _P_Str_Cliente)
        {
            ReportParameter[] parm;
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            if (_Rb_Activos.Checked)
            {
                _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_InfConsultaClientes";
                parm = new ReportParameter[4];
                parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
                parm[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
                parm[2] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
                parm[3] = new ReportParameter("CCLIENTE", _P_Str_Cliente);
            }
            else if(_Rb_Inactivos.Checked)
            {
                _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_InfConsultaClientesInac";
                parm = new ReportParameter[3];
                parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
                parm[1] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
                parm[2] = new ReportParameter("CCLIENTE", _P_Str_Cliente);
            }
            else
            {
                _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_InfConsultaClientesSinZona";
                parm = new ReportParameter[4];
                parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
                parm[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
                parm[2] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
                parm[3] = new ReportParameter("CCLIENTE", _P_Str_Cliente);
            }
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }
        private void Frm_Inf_FichaCliente_Load(object sender, EventArgs e)
        {

        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cliente = "0";
            if (Convert.ToString(_Txt_Cliente.Tag).Trim().Length > 0)
            { _Str_Cliente = Convert.ToString(_Txt_Cliente.Tag).Trim(); }
            _Mtd_Busqueda(_Str_Cliente);
            Cursor = Cursors.Default;
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(32);
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
            if (_Frm._Str_FrmResult == "1")
            {
                _Txt_Cliente.Tag = _Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString().ToUpper();
                _Txt_Cliente.Text = _Frm._Dg_Grid.Rows[_Frm._Dg_Grid.CurrentCell.RowIndex].Cells[1].Value.ToString().ToUpper();
            }
        }

        private void _Bt_CerrarO_Click(object sender, EventArgs e)
        {
            _Txt_Cliente.Text = "";
            _Txt_Cliente.Tag = "";
        }

        private void _Rb_Inactivos_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Inactivos.Checked)
            {
                _Txt_Cliente.Text = "";
                _Txt_Cliente.Tag = "";
                _Txt_Cliente.Enabled = false;
                _Bt_Buscar.Enabled = false;
                _Bt_Limpiar.Enabled = false;
            }
            else
            {
                _Txt_Cliente.Enabled = true;
                _Bt_Buscar.Enabled = true;
                _Bt_Limpiar.Enabled = true;
            }
        }
    }
}