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
    public partial class Frm_Inf_DocEnPoderVen : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);

        public Frm_Inf_DocEnPoderVen()
        {
            InitializeComponent();
            reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_DocEnPoderVen";
            _Mtd_CargarVendedores();
        }

        private void _Mtd_CargarVendedores()
        {
            string _Str_Sql = "SELECT cvendedor,RTRIM(cvendedor) + '-' + RTRIM(cname) FROM TVENDEDOR WHERE cdelete=0 AND ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY CAST(REPLACE(cvendedor,RTRIM(ccompany)+'_','') AS INTEGER)";
            _myUtilidad._Mtd_CargarCombo(_Cb_Vendedor, _Str_Sql, true);
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
            reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[6];
            string _Str_Cadena = "Select cname from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
            parm[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[2] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            parm[3] = new ReportParameter("CVENDEDOR", _Cb_Vendedor.SelectedValue.ToString());
            if (_Cb_Vendedor.SelectedIndex == 0)
            {
                parm[4] = new ReportParameter("CNAMEVENDEDOR", "nulo");
            }
            else
            {
                parm[4] = new ReportParameter("CNAMEVENDEDOR", _Cb_Vendedor.Text);
            }
            if (_Cb_Dia.SelectedIndex == 0)
            {
                parm[5] = new ReportParameter("CDIA", "nulo");
            }
            else
            {
                parm[5] = new ReportParameter("CDIA", _Cb_Dia.Text);
            }
            reportViewer1.ServerReport.SetParameters(parm);
            this.reportViewer1.ServerReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Busqueda();
            Cursor = Cursors.Default;
        }

        private void _Cb_Vendedor_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarVendedores();
        }
    }
}