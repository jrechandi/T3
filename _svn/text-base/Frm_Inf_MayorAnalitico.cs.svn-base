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
    public partial class Frm_Inf_MayorAnalitico : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_Inf_MayorAnalitico()
        {
            InitializeComponent();
            DateTime _Dt_Fecha = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            DateTime _Dt_Fecha_2 = Convert.ToDateTime("01/" + _Dt_Fecha.Month.ToString() + "/" + _Dt_Fecha.Year.ToString());
            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(_Dt_Fecha_2));
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(_Dt_Fecha_2));
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(_Dt_Fecha_2));
            reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_MayorAnalitico";
        }
        private void _Mtd_Busqueda()
        {
            try
            {
                reportViewer1.Reset();
                reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
                reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_MayorAnalitico";
                ReportParameter[] parm = new ReportParameter[8];
                parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
                parm[1] = new ReportParameter("CCUENTAI", _Txt_CuentaDesde.Text.Trim());
                parm[2] = new ReportParameter("CCUENTAF", _Txt_CuentaHasta.Text.Trim());
                parm[3] = new ReportParameter("CMESI", _Dt_Desde.Value.Month.ToString());
                parm[4] = new ReportParameter("CMESF", _Dt_Hasta.Value.Month.ToString());
                parm[5] = new ReportParameter("CANOI", _Dt_Desde.Value.Year.ToString());
                parm[6] = new ReportParameter("CANOF", _Dt_Hasta.Value.Year.ToString());
                parm[7] = new ReportParameter("CNOMEMP", _Mtd_NombComp());
                reportViewer1.ServerReport.SetParameters(parm);
                this.reportViewer1.ServerReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
            catch
            {
                try
                {
                    reportViewer1.Reset();
                    reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
                    reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_MayorAnalitico";
                    ReportParameter[] parm = new ReportParameter[8];
                    parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
                    parm[1] = new ReportParameter("CCUENTAI", _Txt_CuentaDesde.Text.Trim());
                    parm[2] = new ReportParameter("CCUENTAF", _Txt_CuentaHasta.Text.Trim());
                    parm[3] = new ReportParameter("CMESI", _Dt_Desde.Value.Month.ToString());
                    parm[4] = new ReportParameter("CMESF", _Dt_Hasta.Value.Month.ToString());
                    parm[5] = new ReportParameter("CANOI", _Dt_Desde.Value.Year.ToString());
                    parm[6] = new ReportParameter("CANOF", _Dt_Hasta.Value.Year.ToString());
                    parm[7] = new ReportParameter("CNOMEMP", _Mtd_NombComp());
                    reportViewer1.ServerReport.SetParameters(parm);
                    this.reportViewer1.ServerReport.Refresh();
                    this.reportViewer1.RefreshReport();
                }
                catch
                {
                    try
                    {
                        reportViewer1.Reset();
                        reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
                        reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_MayorAnalitico";
                        ReportParameter[] parm = new ReportParameter[8];
                        parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
                        parm[1] = new ReportParameter("CCUENTAI", _Txt_CuentaDesde.Text.Trim());
                        parm[2] = new ReportParameter("CCUENTAF", _Txt_CuentaHasta.Text.Trim());
                        parm[3] = new ReportParameter("CMESI", _Dt_Desde.Value.Month.ToString());
                        parm[4] = new ReportParameter("CMESF", _Dt_Hasta.Value.Month.ToString());
                        parm[5] = new ReportParameter("CANOI", _Dt_Desde.Value.Year.ToString());
                        parm[6] = new ReportParameter("CANOF", _Dt_Hasta.Value.Year.ToString());
                        parm[7] = new ReportParameter("CNOMEMP", _Mtd_NombComp());
                        reportViewer1.ServerReport.SetParameters(parm);
                        this.reportViewer1.ServerReport.Refresh();
                        this.reportViewer1.RefreshReport();
                    }
                    catch (Exception _Err)
                    {
                        MessageBox.Show("Ha ocurrido un error de tipo: " + _Err.ToString() + ", por favor enviar un control de fallas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
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
        private void Frm_Inf_MayorAnalitico_Load(object sender, EventArgs e)
        {

        }

        private void _Dt_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dt_Desde.MaxDate = _Dt_Hasta.Value;
        }

        private void _Bt_Desde_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(74, _Txt_CuentaDesde, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
            if (_Txt_CuentaDesde.Text.Trim().Length > 0)
            {
                _Txt_CuentaHasta.Text = _Txt_CuentaDesde.Text.Trim();
            }
        }

        private void _Bt_Hasta_Click(object sender, EventArgs e)
        {
            if (_Txt_CuentaDesde.Text.Trim().Length > 0)
            {
                _Er_Error.Dispose();
                Cursor = Cursors.WaitCursor;
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(74, _Txt_CuentaHasta, 0, " AND ccount>'" + _Txt_CuentaDesde.Text.Trim() + "'");
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
            }
            else
            { _Er_Error.SetError(_Bt_Desde, "Información requerida."); }
        }
        private bool _Mtd_CuentaDetalle(string _P_Str_Count)
        {
            string _Str_Cadena = "SELECT ccount FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _P_Str_Count + "' AND ctcount='D'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();

            if (_Txt_CuentaDesde.Text.Trim().Length > 0 & _Txt_CuentaHasta.Text.Trim().Length > 0)
            {
                if (_Mtd_CuentaDetalle(_Txt_CuentaDesde.Text.Trim()) & _Mtd_CuentaDetalle(_Txt_CuentaHasta.Text.Trim()))
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_Busqueda();
                    Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Una de las cuentas que introdujo no es válida o no es una cuenta de detalle", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (_Txt_CuentaDesde.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_Desde, "Información requerida."); }
                if (_Txt_CuentaHasta.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_Hasta, "Información requerida."); }
            }
        }

        private void _Dt_Desde_ValueChanged(object sender, EventArgs e)
        {
            try
            {
            }
            catch
            {

            }
        }
    }
}