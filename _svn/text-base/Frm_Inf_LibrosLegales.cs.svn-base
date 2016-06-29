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
    public partial class Frm_Inf_LibrosLegales : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new T3.CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_LibrosLegales()
        {
            InitializeComponent();
            _Mtd_CargarMeses();
            _Rpt_LibrosLegales.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_LibrosLegales.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_MayorAnaliticoLL";
        }

        private string _Mtd_ObtenerRifEmpresa()
        {
            string _Str_Cadena = "Select crif from dbo.TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0'";
            
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
            }

            return "";
        }

        private void _Pnl_LibroDiario_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_LibroDiario.Visible)
            {
                _Pnl_LibroMayor.Visible = false;
                _Rbt_MayorAnaliticoLlegal.Checked = false;
                _Rpt_LibrosLegales.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_LibroDiarioLL";
            }
        }

        private void _Pnl_LibroMayor_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_LibroMayor.Visible)
            {
                _Pnl_LibroDiario.Visible = false;
                _Rbt_LibroDiario.Checked = false;
                _Rpt_LibrosLegales.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_MayorAnaliticoLL";
            }
        }
        
        private void _Txt_Comprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Comprobante, e, 10, 0);
        }

        private void _Txt_Hasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Hasta, e, 10, 0);
        }
        private void _Mtd_LibroDiario()
        {
            _Rpt_LibrosLegales.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_LibroDiarioLL";
            string _Str_IDComprobIni="0";
            string _Str_IDComprobFin="0";
            if (_Txt_Comprobante.Text != "")
            {
                _Str_IDComprobIni = _Txt_Comprobante.Text;
            }
            if (_Txt_Hasta.Text != "")
            {
                _Str_IDComprobFin = _Txt_Comprobante.Text;
            }
            if (_Str_IDComprobIni == "0")
            {
                if (_Str_IDComprobFin != "0")
                {
                    _Str_IDComprobFin = "0";
                }
            }
            if (_Str_IDComprobFin == "0")
            {
                if (_Str_IDComprobIni != "0")
                {
                    _Str_IDComprobIni = "0";                    
                }
            }
            string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.SelectedValue.ToString());
            ReportParameter[] parm = new ReportParameter[7];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CNOMBCOMP", _Mtd_NombComp());
            parm[2] = new ReportParameter("CYEARACCO", _Str_Valores[1]);
            parm[3] = new ReportParameter("CMONTACCO", _Str_Valores[0]);
            parm[4] = new ReportParameter("CIDCOMPROBINI", _Str_IDComprobIni);
            parm[5] = new ReportParameter("CIDCOMPROBFIN", _Str_IDComprobFin);
            parm[6] = new ReportParameter("CRIF", _Mtd_ObtenerRifEmpresa());
            _Rpt_LibrosLegales.ServerReport.SetParameters(parm);
            this._Rpt_LibrosLegales.ServerReport.Refresh();
            this._Rpt_LibrosLegales.RefreshReport();
        }
        private void _Mtd_LibroDiarioSM()
        {
            _Rpt_LibrosLegales.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_LibroDiarioLLSM";
            string _Str_IDComprobIni = "0";
            string _Str_IDComprobFin = "0";
            if (_Txt_Comprobante.Text != "")
            {
                _Str_IDComprobIni = _Txt_Comprobante.Text;
            }
            if (_Txt_Hasta.Text != "")
            {
                _Str_IDComprobFin = _Txt_Comprobante.Text;
            }
            if (_Str_IDComprobIni == "0")
            {
                if (_Str_IDComprobFin != "0")
                {
                    _Str_IDComprobFin = "0";
                }
            }
            if (_Str_IDComprobFin == "0")
            {
                if (_Str_IDComprobIni != "0")
                {
                    _Str_IDComprobIni = "0";
                }
            }
            string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.SelectedValue.ToString());
            ReportParameter[] parm = new ReportParameter[7];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CNOMBCOMP", _Mtd_NombComp());
            parm[2] = new ReportParameter("CYEARACCO", _Str_Valores[1]);
            parm[3] = new ReportParameter("CMONTACCO", _Str_Valores[0]);
            parm[4] = new ReportParameter("CIDCOMPROBINI", _Str_IDComprobIni);
            parm[5] = new ReportParameter("CIDCOMPROBFIN", _Str_IDComprobFin);
            parm[6] = new ReportParameter("CRIF", _Mtd_ObtenerRifEmpresa());
            _Rpt_LibrosLegales.ServerReport.SetParameters(parm);
            this._Rpt_LibrosLegales.ServerReport.Refresh();
            this._Rpt_LibrosLegales.RefreshReport();
        }
        private void _Mtd_LibroMayor()
        {
            _Rpt_LibrosLegales.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_MayorAnaliticoLL";
            string _Str_CuentaI = "0";
            string _Str_CuentaF = "0";
            if (_Txt_CuentaDesde.Text != "")
            {
                _Str_CuentaI = _Txt_CuentaDesde.Text;
            }
            if (_Txt_CuentaHasta.Text != "")
            {
                _Str_CuentaF = _Txt_CuentaHasta.Text;
            }
            string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.SelectedValue.ToString());
            ReportParameter[] parm = new ReportParameter[9];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CCUENTAI", _Str_CuentaI);
            parm[2] = new ReportParameter("CCUENTAF", _Str_CuentaF);
            parm[3] = new ReportParameter("CMESI", _Str_Valores[0]);
            parm[4] = new ReportParameter("CMESF", _Str_Valores[0]);
            parm[5] = new ReportParameter("CANOI", _Str_Valores[1]);
            parm[6] = new ReportParameter("CANOF", _Str_Valores[1]);
            parm[7] = new ReportParameter("CNOMBCOMP", _Mtd_NombComp());
            parm[8] = new ReportParameter("CRIF", _Mtd_ObtenerRifEmpresa());
            _Rpt_LibrosLegales.ServerReport.SetParameters(parm);
            this._Rpt_LibrosLegales.ServerReport.Refresh();
            this._Rpt_LibrosLegales.RefreshReport();
        }
        private void _Mtd_LibroMayorSM()
        {
            _Rpt_LibrosLegales.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_MayorAnaliticoLLSM";
            string _Str_CuentaI = "0";
            string _Str_CuentaF = "0";
            if (_Txt_CuentaDesde.Text != "")
            {
                _Str_CuentaI = _Txt_CuentaDesde.Text;
            }
            if (_Txt_CuentaHasta.Text != "")
            {
                _Str_CuentaF = _Txt_CuentaHasta.Text;
            }
            string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.SelectedValue.ToString());
            ReportParameter[] parm = new ReportParameter[9];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CCUENTAI", _Str_CuentaI);
            parm[2] = new ReportParameter("CCUENTAF", _Str_CuentaF);
            parm[3] = new ReportParameter("CMESI", _Str_Valores[0]);
            parm[4] = new ReportParameter("CMESF", _Str_Valores[0]);
            parm[5] = new ReportParameter("CANOI", _Str_Valores[1]);
            parm[6] = new ReportParameter("CANOF", _Str_Valores[1]);
            parm[7] = new ReportParameter("CNOMBCOMP", _Mtd_NombComp());
            parm[8] = new ReportParameter("CRIF", _Mtd_ObtenerRifEmpresa());
            _Rpt_LibrosLegales.ServerReport.SetParameters(parm);
            this._Rpt_LibrosLegales.ServerReport.Refresh();
            this._Rpt_LibrosLegales.RefreshReport();
        }
        private string[] _Mtd_ExtraerMesAno(string _P_Str_Items)
        {
            int _Int_i = _P_Str_Items.Trim().IndexOf("-");
            return new string[] { _P_Str_Items.Substring(0, _Int_i).Trim(), _P_Str_Items.Substring(_Int_i + 1).Trim() };
        }
        private void _Rbt_MayorAnaliticoLlegal_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_MayorAnaliticoLlegal.Checked)
            {
                _Pnl_LibroMayor.Visible = true;
                _Txt_CuentaDesde.Text = "";
                _Txt_CuentaHasta.Text = "";
                _Pnl_LibroDiario.Visible = false;
                _Rbt_LibroDiario.Checked = false;
                _Rpt_LibrosLegales.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_MayorAnaliticoLL";
            }
        }

        private void _Rbt_LibroDiario_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_LibroDiario.Checked)
            {
                _Pnl_LibroDiario.Visible = true;
                _Txt_Comprobante.Text = "";
                _Txt_Hasta.Text = "";
                _Txt_Descripcion.Text = "";
                _Txt_Hasta.Visible = false;
                _Pnl_LibroMayor.Visible = false;
                _Rbt_MayorAnaliticoLlegal.Checked = false;
                _Rpt_LibrosLegales.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_LibroDiarioLL";
            }
        }

        private void _Chk_DesHas_CheckedChanged(object sender, EventArgs e)
        {
            _Txt_Hasta.Text = "";
            if (_Chk_DesHas.Checked)
            {
                _Txt_Hasta.Visible = true;
            }
            else
            {
                _Txt_Hasta.Visible = false;
            }
        }

        private void Frm_Inf_LibrosLegales_Load(object sender, EventArgs e)
        {
            _Rbt_MayorAnaliticoLlegal.Checked = false;
            _Rbt_LibroDiario.Checked = false;
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
        private void _Mtd_CargarMeses()
        {
            string _Str_Cadena = "";
            _Str_Cadena = "SELECT CONVERT(VARCHAR,cmontacco)+'-'+CONVERT(VARCHAR,cyearacco),CONVERT(VARCHAR,cmontacco)+'-'+CONVERT(VARCHAR,cyearacco) FROM TMESCONTABLE WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            _Str_Cadena += " AND ccerrado='1' ORDER BY cyearacco DESC, cmontacco DESC"; 
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Mes, _Str_Cadena);
        }
        private void _Btn_ConsultarLMayor_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (Convert.ToString(_Cmb_Mes.SelectedValue).Trim() == "nulo")
            {
                _Er_Error.SetError(_Cmb_Mes, "Información Requerida!!!");
                MessageBox.Show("Debe seleccionar un mes contable para la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(_Txt_CuentaDesde.Text))
                _Er_Error.SetError(_Bt_Desde, "Información Requerida!!!");
            if (string.IsNullOrEmpty(_Txt_CuentaHasta.Text))
                _Er_Error.SetError(_Bt_Hasta, "Información Requerida!!!");
            if (string.IsNullOrEmpty(_Txt_CuentaDesde.Text) || string.IsNullOrEmpty(_Txt_CuentaHasta.Text))
                return;
            _Mtd_LibroMayor();
        }

        private void _Btn_ConsultarLDiario_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            bool _Bol_Valido = true;
            if (_Chk_DesHas.Checked)
            {
                if (_Txt_Comprobante.Text == "" || _Txt_Hasta.Text == "")
                {
                    _Bol_Valido = false;
                    if (_Txt_Comprobante.Text == "")
                    {
                        _Er_Error.SetError(_Txt_Comprobante, "Información requerida.");
                    }
                    if (_Txt_Hasta.Text == "")
                    {
                        _Er_Error.SetError(_Txt_Comprobante, "Información requerida.");
                    }
                    MessageBox.Show("Debe introducir un rango de comprobantes para la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int _Int_Ini = 0;
                    int _Int_Fin = 0;
                    if (_Int_Fin < _Int_Ini)
                    {
                        _Bol_Valido = false;
                        MessageBox.Show("Debe introducir un rango valido de comprobantes para la consulta de menor a mayor", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            if (_Bol_Valido)
            {
                _Er_Error.Dispose();
                if (Convert.ToString(_Cmb_Mes.SelectedValue).Trim() == "nulo")
                {
                    _Er_Error.SetError(_Cmb_Mes, "Información Requerida!!!");
                    MessageBox.Show("Debe seleccionar un mes contable para la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _Mtd_LibroDiario();
                }
            }
        }

        private void _Bt_Desde_Click(object sender, EventArgs e)
        {
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(74, _Txt_CuentaDesde, 0, "");
            _Frm.ShowDialog();
            if (_Txt_CuentaDesde.Text.Trim().Length > 0)
            {
                _Txt_CuentaHasta.Text = _Txt_CuentaDesde.Text.Trim();
            }
        }

        private void _Bt_Hasta_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Txt_CuentaDesde.Text.Trim().Length > 0)
            {
                _Er_Error.Dispose();
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(74, _Txt_CuentaHasta, 0, " AND ccount>'" + _Txt_CuentaDesde.Text.Trim() + "'");
                _Frm.ShowDialog();
            }
            else
            { _Er_Error.SetError(_Bt_Desde, "Información requerida."); }
        }

        private void _Rpt_LibrosLegales_ReportRefresh(object sender, CancelEventArgs e)
        {
            if (_Rbt_LibroDiario.Checked)
            {
                _Mtd_LibroDiario();
            }
            else if (_Rbt_MayorAnaliticoLlegal.Checked)
            {
                _Mtd_LibroMayor();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (Convert.ToString(_Cmb_Mes.SelectedValue).Trim() == "nulo")
            {
                _Er_Error.SetError(_Cmb_Mes, "Información Requerida!!!");
                MessageBox.Show("Debe seleccionar un mes contable para la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _Mtd_LibroMayorSM();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            bool _Bol_Valido = true;
            if (_Chk_DesHas.Checked)
            {
                if (_Txt_Comprobante.Text == "" || _Txt_Hasta.Text == "")
                {
                    _Bol_Valido = false;
                    if (_Txt_Comprobante.Text == "")
                    {
                        _Er_Error.SetError(_Txt_Comprobante, "Información requerida.");
                    }
                    if (_Txt_Hasta.Text == "")
                    {
                        _Er_Error.SetError(_Txt_Comprobante, "Información requerida.");
                    }
                    MessageBox.Show("Debe introducir un rango de comprobantes para la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int _Int_Ini = 0;
                    int _Int_Fin = 0;
                    if (_Int_Fin < _Int_Ini)
                    {
                        _Bol_Valido = false;
                        MessageBox.Show("Debe introducir un rango valido de comprobantes para la consulta de menor a mayor", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            if (_Bol_Valido)
            {
                _Er_Error.Dispose();
                if (Convert.ToString(_Cmb_Mes.SelectedValue).Trim() == "nulo")
                {
                    _Er_Error.SetError(_Cmb_Mes, "Información Requerida!!!");
                    MessageBox.Show("Debe seleccionar un mes contable para la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _Mtd_LibroDiarioSM();
                }
            }
        }
    }
}
