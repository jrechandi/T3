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
    public partial class Frm_Inf_FacturasAnul : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_FacturasAnul()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_FacturasAnuladas";
        }
        private void _Mtd_CargarClientes()
        {
            string _Str_Sql = "SELECT ccliente,CONVERT(VARCHAR,ccliente) + '-' + RTRIM(c_nomb_comer) FROM TCLIENTE WHERE cdelete=0 AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
            _myUtilidad._Mtd_CargarCombo(_Cb_Cliente, _Str_Sql);
        }
        private void _Mtd_CargarVendedores()
        {
            string _Str_Sql = "SELECT cvendedor,RTRIM(cvendedor) + '-' + RTRIM(cname) FROM TVENDEDOR WHERE cdelete=0 AND ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY CONVERT(NUMERIC(18,0),REPLACE(REPLACE(CVENDEDOR,'_',''),RTRIM(CCOMPANY),''))";
            _myUtilidad._Mtd_CargarCombo(_Cb_Vendedor, _Str_Sql);
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
        private void _Mtd_Busqueda(string _P_Str_Vendedor, string _P_Str_Cliente, string _P_Str_Motivo)
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[7];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CVENDEDOR", _P_Str_Vendedor);
            parm[2] = new ReportParameter("CCLIENTE", _P_Str_Cliente);
            parm[3] = new ReportParameter("CFECHAI", _Ctrl_ConsultaMes1._Str_FechaInicio);
            parm[4] = new ReportParameter("CFECHAF", _Ctrl_ConsultaMes1._Str_FechaFinal);
            parm[5] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            parm[6] = new ReportParameter("CMOTIVO", _P_Str_Motivo);
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }

        private void Frm_Inf_FacturasAnul_Load(object sender, EventArgs e)
        {
            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();
        }

        private void _Rb_Cliente_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Cliente.Checked)
            {
                _Cb_Cliente.Enabled = true;
            }
            else
            {
                _Cb_Cliente.SelectedIndex = -1;
                _Cb_Cliente.Enabled = false;
            }
        }

        private void _Rb_Vendedor_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Vendedor.Checked)
            {
                _Cb_Vendedor.Enabled = true;
            }
            else
            {
                _Cb_Vendedor.SelectedIndex = -1;
                _Cb_Vendedor.Enabled = false;
            }
        }

        private void _Rb_SinFiltro_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_SinFiltro.Checked)
            {
                _Cb_Cliente.SelectedIndex = -1;
                _Cb_Vendedor.SelectedIndex = -1;
                _Cb_Cliente.Enabled = false;
                _Cb_Vendedor.Enabled = false;
            }
        }

        private void _Cb_Cliente_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_CargarClientes();
            this.Cursor = Cursors.Default;
        }

        private void _Cb_Vendedor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_CargarVendedores();
            this.Cursor = Cursors.Default;
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            if (_Ctrl_ConsultaMes1._Bol_Listo)
            {
                this.Cursor = Cursors.WaitCursor;
                _Er_Error.Dispose();
                string _Str_Vendedor = "";
                string _Str_Cliente = "";
                string _Str_Motivo = "";
                //-------------------------------------------
                if (_Cb_Vendedor.SelectedIndex == -1)
                { _Str_Vendedor = " "; }
                else if (_Cb_Vendedor.SelectedIndex == 0)
                { _Str_Vendedor = " "; }
                else
                { _Str_Vendedor = _Cb_Vendedor.SelectedValue.ToString(); }
                if (_Cb_Cliente.SelectedIndex == -1)
                { _Str_Cliente = "0"; }
                else if (_Cb_Cliente.SelectedIndex == 0)
                { _Str_Cliente = "0"; }
                else
                { _Str_Cliente = _Cb_Cliente.SelectedValue.ToString(); }

                if (_Rb_Motivo.Checked)
                {
                  if (_Cb_Motivo.SelectedIndex > 0)
                    _Str_Motivo = _Cb_Motivo.SelectedValue.ToString();
                  else
                    _Str_Motivo = "";
                }
                  
                //-------------------------------------------
                if (_Rb_SinFiltro.Checked)
                { _Mtd_Busqueda(_Str_Vendedor, _Str_Cliente, _Str_Motivo); }
                else
                {
                  if (_Cb_Cliente.SelectedIndex > 0 | _Cb_Vendedor.SelectedIndex > 0 | _Cb_Motivo.SelectedIndex > 0)
                    {
                      _Mtd_Busqueda(_Str_Vendedor, _Str_Cliente, _Str_Motivo);
                    }
                    else
                    {
                        if (_Rb_Cliente.Checked) { _Er_Error.SetError(_Cb_Cliente, "Información requerida."); }
                        if (_Rb_Vendedor.Checked) { _Er_Error.SetError(_Cb_Vendedor, "Información requerida."); }
                        if (_Rb_Motivo.Checked) { _Er_Error.SetError(_Cb_Motivo, "Información requerida."); }
                    }
                }
                this.Cursor = Cursors.Default;
            }
            else
            { MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Rb_Motivo_CheckedChanged(object sender, EventArgs e)
        {
          if (_Rb_Motivo.Checked)
          {
            _Cb_Motivo.Enabled = true;
          }
          else
          {
            _Cb_Motivo.SelectedIndex = -1;
            _Cb_Motivo.Enabled = false;
          }
        }

        private void _Cb_Motivo_DropDown(object sender, EventArgs e)
        {
          this.Cursor = Cursors.WaitCursor;
          _Mtd_CargarMotivos();
          this.Cursor = Cursors.Default;
        }

        private void _Mtd_CargarMotivos()
        {
          string _Str_Sql = "SELECT RTRIM(cidmotivo) as cidmotivo,RTRIM(cidmotivo) + ' - ' + RTRIM(cdescripcion) AS cdescripcion FROM TMOTIVO where cmotianulfact='1' ORDER BY CAST(RTRIM(cidmotivo) AS NUMERIC) ASC";
          _myUtilidad._Mtd_CargarCombo(_Cb_Motivo, _Str_Sql);
        }
    }
}