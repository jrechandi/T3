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
    public partial class Frm_Inf_RelaDespacho : Form
    {
        public Frm_Inf_RelaDespacho()
        {
            InitializeComponent();
            _Txt_Ruta.Tag = "0";
            _Txt_Transportista.Tag = "0";
            _Txt_Cliente.Tag = "0";
            _Txt_Guia.Tag = "0";
            _Txt_Placa.Tag = "0";
            reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_RelaDespaResumido";
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
            ReportParameter[] parm;
            if (_Rb_Detallado.Checked)
            { parm = new ReportParameter[10]; }
            else
            { parm = new ReportParameter[9]; }

            parm[0] = new ReportParameter("CNOMBCOMP", _Mtd_NombComp());
            parm[1] = new ReportParameter("CLIQUIDADA", Convert.ToInt32(_Chk_Liq.Checked).ToString());
            parm[2] = new ReportParameter("CFECHAINI", _Ctrl_ConsultaMes1._Str_FechaInicio);
            parm[3] = new ReportParameter("CFECHAFIN", _Ctrl_ConsultaMes1._Str_FechaFinal);
            parm[4] = new ReportParameter("CIDRUTDESPACHO", Convert.ToString(_Txt_Ruta.Tag).Trim());
            parm[5] = new ReportParameter("CCEDULA", Convert.ToString(_Txt_Transportista.Tag).Trim());
            parm[6] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);

            if (_Rb_Detallado.Checked)
            {
                parm[7] = new ReportParameter("CCLIENTE", Convert.ToString(_Txt_Cliente.Tag).Trim());
                parm[8] = new ReportParameter("CGUIA", Convert.ToString(_Txt_Guia.Tag).Trim());
                parm[9] = new ReportParameter("CPLACA", Convert.ToString(_Txt_Placa.Tag).Trim());
            }
            else
            {
                parm[7] = new ReportParameter("CGUIA", Convert.ToString(_Txt_Guia.Tag).Trim());
                parm[8] = new ReportParameter("CPLACA", Convert.ToString(_Txt_Placa.Tag).Trim());
            }

            reportViewer1.ServerReport.SetParameters(parm);
            this.reportViewer1.ServerReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Ctrl_ConsultaMes1._Bol_Listo)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Busqueda();
                Cursor = Cursors.Default;
            }
            else
            { MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Bt_Ruta_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(65, _Txt_Ruta, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();

        }

        private void _Bt_Transportista_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(66, _Txt_Transportista, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
        }

        private void _Bt_Cliente_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(64, _Txt_Cliente, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
        }

        private void _Bt_Limpiar_R_Click(object sender, EventArgs e)
        {
            _Txt_Ruta.Tag = "0"; _Txt_Ruta.Text = "";
        }

        private void _Bt_Limpiar_T_Click(object sender, EventArgs e)
        {
            _Txt_Transportista.Tag = "0"; _Txt_Transportista.Text = "";
        }

        private void _Bt_Limpiar_C_Click(object sender, EventArgs e)
        {
            _Txt_Cliente.Tag = "0"; _Txt_Cliente.Text = "";
        }

        private void _Rb_Resumido_CheckedChanged(object sender, EventArgs e)
        {
            reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_RelaDespaResumido";
            _Txt_Cliente.Tag = "0"; _Txt_Cliente.Text = ""; _Bt_Cliente.Enabled = false; _Bt_Limpiar_C.Enabled = false;
        }

        private void _Rb_Detallado_CheckedChanged(object sender, EventArgs e)
        {
            reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_RelaDespaDetallado";
            _Txt_Cliente.Tag = "0"; _Txt_Cliente.Text = ""; _Bt_Cliente.Enabled = true; _Bt_Limpiar_C.Enabled = true;
        }

        private void Frm_Inf_RelaDespacho_Load(object sender, EventArgs e)
        {
            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();
        }

        private void _Bt_Guia_Click(object sender, EventArgs e)
        {
            string _Str_ValorAnterior = _Txt_Guia.Tag.ToString();

            string _Str_Parametro = " AND (cliqguidespacho = 0) ";
            if (_Chk_Liq.Checked) _Str_Parametro = " AND (cliqguidespacho = 1) ";
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(71, _Txt_Guia, 0, _Str_Parametro);
            Cursor = Cursors.Default;
            _Frm.ShowDialog();

            if (_Str_ValorAnterior != _Txt_Guia.Tag.ToString())
            {
                string Str_Temporal = _Mtd_PlacaSegunGuia(_Txt_Guia.Tag.ToString());
                _Txt_Placa.Tag = Str_Temporal;
                _Txt_Placa.Text = Str_Temporal;
            }
        }

        private void _Chk_Liq_CheckedChanged(object sender, EventArgs e)
        {
            _Txt_Guia.Text = ""; _Txt_Guia.Tag = "0";
        }

        private string _Mtd_PlacaSegunGuia(string _Str_CodigoGuia)
        {
            string _Str_SQL = "";

            _Str_SQL += "SELECT cplaca" + " ";
            _Str_SQL += "FROM TGUIADESPACHOM" + " ";
            _Str_SQL += "WHERE cgroupcomp = " + Frm_Padre._Str_GroupComp + " AND cguiadesp = " + _Str_CodigoGuia + " ";

            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count != 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }

        private void _Bt_Placa_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Parametro = "";
            if (_Txt_Guia.Tag.ToString() != "0") _Str_Parametro = " AND cguiadesp = " + _Txt_Guia.Tag.ToString();
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(72, _Txt_Placa, 0, _Str_Parametro);
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
        }

        private void _Bt_Limpiar_G_Click(object sender, EventArgs e)
        {
            _Txt_Guia.Text = ""; _Txt_Guia.Tag = "0";
        }

        private void _Bt_Limpiar_P_Click(object sender, EventArgs e)
        {
            _Txt_Placa.Text = ""; _Txt_Placa.Tag = "0";
        }
    }
}