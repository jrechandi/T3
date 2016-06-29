using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace T3
{
    public partial class Frm_Inf_PreIndCheques : Form
    {
        private CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        string _G_Str_SentenciaSQL;
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        /// <summary>
        /// Método que se usa para cargar el combo de bancos
        /// </summary>
        /// <param name="_P_Cmb_Combo">Combobox del banco</param>
        private void _Mtd_CargarBancos(ComboBox _P_Cmb_Combo)
        {
            try
            {
                _G_Str_SentenciaSQL = "SELECT DISTINCT RTRIM(CBANCO) AS CBANCO,CNAME FROM VST_BANCOCUENTAS WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CBANCO='1'";
                _myUtilidad._Mtd_CargarCombo(_Cmb_Banco, _G_Str_SentenciaSQL);
                if (_Cmb_Banco.Items.Count > 1)
                {
                    _P_Cmb_Combo.SelectedValue = "1";
                    _P_Cmb_Combo.Enabled = false;
                    _Mtd_CargarCuentas(_Cmb_Cuenta, "1");
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// Método que se usa para cargar las cuentas bancarias según un código de banco
        /// </summary>
        /// <param name="_P_Cmb_Combo">Combobox de la cuenta bancaria</param>
        /// <param name="_P_Str_Banco">Código del banco</param>
        private void _Mtd_CargarCuentas(ComboBox _P_Cmb_Combo, string _P_Str_Banco)
        {
            try
            {
                _G_Str_SentenciaSQL = "SELECT cnumcuenta,cuentabanname FROM VST_BANCOCUENTAS WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CBANCO='" + _P_Str_Banco + "'";
                _myUtilidad._Mtd_CargarCombo(_P_Cmb_Combo, _G_Str_SentenciaSQL);
                if (_P_Cmb_Combo.Items.Count > 1)
                {
                    _P_Cmb_Combo.Enabled = true;
                }
                else
                {
                    _P_Cmb_Combo.Enabled = false;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// Método que se usa para llenar el combo de reportes
        /// </summary>
        /// <param name="_P_Cmb_Combo">Combobox del reporte</param>
        /// <param name="_P_Str_Banco">Código del banco</param>
        /// <param name="_P_Str_Cuenta">Código de la cuenta</param>
        private void _Mtd_CargarReportes(ComboBox _P_Cmb_Combo, string _P_Str_Banco, string _P_Str_Cuenta)
        {
            _G_Str_SentenciaSQL = "SELECT  cidreporte,CASE WHEN cnumcheqinicial=0 THEN ('REPORTE N° ' + CAST(cidreporte AS VARCHAR) + '  DEL ' + CONVERT(VARCHAR,cfechainicial,103) + ' AL ' + CONVERT(VARCHAR,cfechafinal,103)) ELSE ('REPORTE N° ' + CAST(cidreporte AS VARCHAR) + '  DESDE ' + CONVERT(VARCHAR,cnumcheqinicial) + ' HASTA ' + CONVERT(VARCHAR,cnumcheqfinal)) END  AS cdescripcion";
            _G_Str_SentenciaSQL += " FROM TPINDICHEQM";
            _G_Str_SentenciaSQL += " WHERE cbanco = '" + _P_Str_Banco + "'";
            _G_Str_SentenciaSQL += " AND cnumcuentad = '" + _P_Str_Cuenta + "' ORDER BY cidreporte DESC;";

            _myUtilidad._Mtd_CargarCombo(_P_Cmb_Combo, _G_Str_SentenciaSQL);
        }

        public Frm_Inf_PreIndCheques()
        {
            InitializeComponent();

            this._Mtd_CargarBancos(this._Cmb_Banco);
            _Rpt_VisorReportes.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_VisorReportes.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_InfPreIndicacionCheques";
            //this._Mtd_CargarReportes(this._Cmb_Cuenta, this._Cmb_Banco.Items[this._Cmb_Banco.SelectedIndex].ToString(), this._Cmb_Cuenta.Items[this._Cmb_Cuenta.SelectedIndex].ToString());
        }

        private void _Cmb_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Banco.SelectedValue != null)
            {
                if (_Cmb_Banco.SelectedIndex > 0)
                {
                    this._Mtd_CargarCuentas(this._Cmb_Cuenta, this._Cmb_Banco.Text);
                }
            }
        }

        private void _Btn_VerReporte_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (_Cmb_Banco.SelectedValue != null && _Cmb_Cuenta.SelectedIndex != null && _Cmb_Reporte.SelectedIndex != null)
                {
                    if (_Cmb_Banco.SelectedIndex > 0 && _Cmb_Cuenta.SelectedIndex > 0 && _Cmb_Reporte.SelectedIndex > 0)
                    {
                        _Rpt_VisorReportes.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
                        ReportParameter[] parm = new ReportParameter[3];
                        parm[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
                        parm[0] = new ReportParameter("CNOMBEMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
                        parm[2] = new ReportParameter("CIDREPORTE", _Cmb_Reporte.SelectedValue.ToString());
                        _Rpt_VisorReportes.ServerReport.SetParameters(parm);
                        _Rpt_VisorReportes.ServerReport.Refresh();
                        _Rpt_VisorReportes.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("Disculpe, debe seleccionar un banco, una cuenta bancaria y un reporte para realizar la consulta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch
            {
            }
            Cursor = Cursors.Default;
        }

        private void _Cmb_Banco_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarBancos(_Cmb_Banco);
        }

        private void _Cmb_Cuenta_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_Banco.SelectedValue != null)
            {
                if (_Cmb_Banco.SelectedIndex > 0)
                {
                    _Mtd_CargarCuentas(_Cmb_Cuenta, _Cmb_Banco.SelectedValue.ToString());
                }
            }
        }

        private void _Cmb_Cuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Banco.SelectedValue != null)
            {
                if (_Cmb_Banco.SelectedIndex > 0)
                {
                    if (_Cmb_Cuenta.SelectedValue != null)
                    {
                        if (_Cmb_Cuenta.SelectedIndex > 0)
                        {
                            _Mtd_CargarReportes(_Cmb_Reporte, _Cmb_Banco.SelectedValue.ToString(), _Cmb_Cuenta.SelectedValue.ToString());
                        }
                    }
                }
            }
        }

        private void _Cmb_Reporte_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_Banco.SelectedValue != null)
            {
                if (_Cmb_Banco.SelectedIndex > 0)
                {
                    if (_Cmb_Cuenta.SelectedValue != null)
                    {
                        if (_Cmb_Cuenta.SelectedIndex > 0)
                        {
                            _Mtd_CargarReportes(_Cmb_Reporte, _Cmb_Banco.SelectedValue.ToString(), _Cmb_Cuenta.SelectedValue.ToString());
                        }
                    }
                }
            }
        }
    }
}
