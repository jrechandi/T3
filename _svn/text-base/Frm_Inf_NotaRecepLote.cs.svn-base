using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Reflection;

namespace T3
{
    public partial class Frm_Inf_NotaRecepLote : Form
    {
        private string _Str_Comp = "";
        
        public Frm_Inf_NotaRecepLote()
        {
            InitializeComponent();

            _Str_Comp = Frm_Padre._Str_Comp;
            
            _Mtd_ConfigurarReporte();
        }        

        public Frm_Inf_NotaRecepLote(string _P_Str_Comp)
        {
            InitializeComponent();

            _Str_Comp = _P_Str_Comp;

            _Mtd_ConfigurarReporte();
            _Mtd_Busqueda();
        }

        public Frm_Inf_NotaRecepLote(string _Str_NR, string _P_Str_Comp)
        {
            InitializeComponent();

            _Str_Comp = _P_Str_Comp;

            _Cmb_FiltrarPor.SelectedIndex = 0;
            _Cmb_FiltrarPor.Enabled = false;
            
            _Txt_Codigo.Text = _Str_NR;
            _Txt_Codigo.Enabled = false;
            _Bt_Buscar.Enabled = false;

            panel1.Visible = false;

            _Mtd_ConfigurarReporte();
            _Mtd_Busqueda();
        }

        private void _Mtd_ConfigurarReporte()
        {
            FieldInfo fi = this._Rpt_Report.GetType().GetField("reportToolBar", BindingFlags.Instance | BindingFlags.NonPublic);
            object o;
            fi = (o = fi.GetValue(this._Rpt_Report)).GetType().GetField("printPreview", BindingFlags.Instance | BindingFlags.NonPublic);
            (fi.GetValue(o) as ToolStripButton).Owner.Items.Remove(fi.GetValue(o) as ToolStripButton);
            fi = this._Rpt_Report.GetType().GetField("m_viewMode", BindingFlags.Instance | BindingFlags.NonPublic);
            fi.SetValue(this._Rpt_Report, DisplayMode.PrintLayout);
            this._Rpt_Report.ZoomMode = ZoomMode.Percent;
        }

        private void _Mtd_Busqueda()
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + ((_Cmb_FiltrarPor.SelectedIndex == 0) ? "Rpt_NotaRecepLote" : "Rpt_NotaRecepLoteN");

           
            ReportParameter[] parm = new ReportParameter[3];
             if (_Cmb_FiltrarPor.SelectedIndex == 1)
            {
                parm = new ReportParameter[4];
             }
            parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
            parm[1] = new ReportParameter("CCOMPANY", _Str_Comp);
            parm[2] = new ReportParameter("CIDNOTRECP", _Txt_Codigo.Text.Trim());
            if (_Cmb_FiltrarPor.SelectedIndex == 1)
            {
                parm[3] = new ReportParameter("CIDPRODUCTOD", _Txt_Lote.Text.Trim());
            }
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

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();

            if ((_Cmb_FiltrarPor.SelectedIndex > -1) && (_Txt_Codigo.Text.Trim().Length > 0))
            {
                if (_Cmb_FiltrarPor.SelectedIndex == 0)
                {
                    _Mtd_Busqueda();
                }
                else if (_Cmb_FiltrarPor.SelectedIndex == 1)                
                {
                    if (_Cmb_FiltrarPor.SelectedIndex == 1 && _Txt_Lote.Text.Trim().Length > 0)
                    {
                        _Mtd_Busqueda();
                    }
                    else
                    {
                        if (_Txt_Lote.Text.Trim().Length == 0)
                            _Er_Error.SetError(_Txt_Codigo, "Información requerida!!!");
                    }
                }
            }
            else
            {
                if (_Cmb_FiltrarPor.SelectedIndex == -1)
                    _Er_Error.SetError(_Cmb_FiltrarPor, "Información requerida!!!");

                if (_Txt_Codigo.Text.Trim().Length == 0)
                    _Er_Error.SetError(_Txt_Codigo, "Información requerida!!!");
            }
        }

        private void _Txt_Lote_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Codigo.Text))
            {
                _Txt_Codigo.Text = "";
            }
        }

        private void _Txt_Lote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Cmb_FiltrarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Lbl_Lote.Visible = (_Cmb_FiltrarPor.SelectedIndex == 1) ? true : false;
            _Txt_Lote.Visible = (_Cmb_FiltrarPor.SelectedIndex == 1) ? true : false;
            _Txt_Codigo.Text = "";
            _Txt_Lote.Text = "";
            _Txt_Codigo.Focus();
        }

        private void _Txt_Lote_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}