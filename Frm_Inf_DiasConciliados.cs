using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace T3
{
    public partial class Frm_Inf_DiasConciliados : Form
    {
        private readonly CLASES._Cls_Varios_Metodos _G_myUtilidad = new CLASES._Cls_Varios_Metodos(true);

        public Frm_Inf_DiasConciliados()
        {
            InitializeComponent();
            reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_DiasConciliados";
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
            var _Str_cbanco = "";
            var _Str_cnumcuenta = "";
            var _Str_cestatusconciliados = "";

            if (_Cmb_Banco.SelectedValue != null) 
                _Str_cbanco = _Cmb_Banco.SelectedValue.ToString() == "" ? "nulo" : _Cmb_Banco.SelectedValue.ToString();
            else 
                _Str_cbanco = "nulo";
            if (_Cmb_NumeroDeCuenta.SelectedValue != null)
                _Str_cnumcuenta = _Cmb_NumeroDeCuenta.SelectedValue.ToString() == "" ? "nulo" : _Cmb_NumeroDeCuenta.SelectedValue.ToString();
            else
                _Str_cnumcuenta = "nulo";

            if (_Rbt_TodosLosDias.Checked)
            {
                _Str_cestatusconciliados = "T";
            }
            else if (_Rbt_SoloDiasConciliados.Checked)
            {
                _Str_cestatusconciliados = "C";
            }
            else if (_Rbt_SoloDiasNoConciliados.Checked)
            {
                _Str_cestatusconciliados = "N";
            }

            reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            var parm = new ReportParameter[7];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            parm[2] = new ReportParameter("CFECHAI", _Ctrl_ConsultaMes1._Str_FechaInicio);
            parm[3] = new ReportParameter("CFECHAF", _Ctrl_ConsultaMes1._Str_FechaFinal);
            parm[4] = new ReportParameter("CBANCO", _Str_cbanco);
            parm[5] = new ReportParameter("CNUMCUENTA", _Str_cnumcuenta);
            parm[6] = new ReportParameter("CESTATUSCONCILIADOS", _Str_cestatusconciliados);
            reportViewer1.ServerReport.SetParameters(parm);
            reportViewer1.ServerReport.Refresh();
            reportViewer1.RefreshReport();
        }
        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            if (!_Ctrl_ConsultaMes1._Bol_Listo)
            {
                MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!_Rbt_TodosLosDias.Checked & !_Rbt_SoloDiasConciliados.Checked & !_Rbt_SoloDiasNoConciliados.Checked)
            {
                MessageBox.Show("Debe seleccionar un estatus", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Mostramos el reporte
            Cursor = Cursors.WaitCursor;
            _Mtd_Busqueda();
            Cursor = Cursors.Default;

        }

        private void Frm_Inf_AcumCobDia_Load(object sender, EventArgs e)
        {
            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();
        }



        private void _Mtd_CargarBancoConsulta()
        {
            try
            {
                var _Str_SQL = "SELECT DISTINCT CBANCO,CNAME FROM VST_BANCOCUENTAS WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                _Mtd_CargarComboLimpiandoCampos(_Cmb_Banco, _Str_SQL);
            }
            catch
            {
            }
        }
        private void _Mtd_CargarCuentaConsultas(string _P_Str_Banco)
        {
            try
            {
                var _Str_SQL = "SELECT cnumcuenta,cuentabanname FROM VST_BANCOCUENTAS WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CBANCO='" + _P_Str_Banco + "'";
                _G_myUtilidad._Mtd_CargarCombo(_Cmb_NumeroDeCuenta, _Str_SQL);
                if (_Cmb_NumeroDeCuenta.Items.Count > 1)
                {
                    _Cmb_NumeroDeCuenta.Enabled = true;
                }
                else
                {
                    _Cmb_NumeroDeCuenta.Enabled = false;
                }
            }
            catch
            {
            }
        }
        private void _Mtd_CargarComboLimpiandoCampos(ComboBox _Pr_Cb, string _Str_Sql)
        {
            DataSet _Ds;
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Pr_Cb.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString(), _DRow[0].ToString().Trim()));
            }
            _Pr_Cb.DataSource = _myArrayList;
            _Pr_Cb.DisplayMember = "Display";
            _Pr_Cb.ValueMember = "Value";
            _Pr_Cb.SelectedValue = "nulo";
        }

        private void _Cmb_Banco_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarBancoConsulta();
        }

        private void _Cmb_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Banco.SelectedValue != null)
            {
                if (_Cmb_Banco.SelectedIndex > 0)
                {
                    _Chk_Banco.CheckedChanged -= new EventHandler(_Chk_Banco_CheckedChanged);
                    _Chk_Banco.Checked = true;
                    _Chk_Banco.CheckedChanged += new EventHandler(_Chk_Banco_CheckedChanged);
                    _Mtd_CargarCuentaConsultas(_Cmb_Banco.SelectedValue.ToString());
                }
                else
                {
                    _Cmb_NumeroDeCuenta.DataSource = null;
                    _Cmb_NumeroDeCuenta.Refresh();
                }
            }
            else
            {
                _Cmb_NumeroDeCuenta.DataSource = null;
                _Cmb_NumeroDeCuenta.Refresh();
                _Chk_NumeroDeCuenta.Checked = false;
            }
        }

        private void _Cmb_NumeroDeCuenta_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_Banco.SelectedValue != null)
            {
                if (_Cmb_Banco.SelectedIndex > 0)
                {
                    _Chk_NumeroDeCuenta.CheckedChanged -= new EventHandler(_Chk_NumeroDeCuenta_CheckedChanged);
                    _Chk_NumeroDeCuenta.Checked = true;
                    _Chk_NumeroDeCuenta.CheckedChanged += new EventHandler(_Chk_NumeroDeCuenta_CheckedChanged);
                    _Mtd_CargarCuentaConsultas(_Cmb_Banco.SelectedValue.ToString());
                }
            }
        }

        private void _Cmb_NumeroDeCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _Chk_Banco_CheckedChanged(object sender, EventArgs e)
        {
            if (!_Chk_Banco.Checked)
            {
                _Cmb_Banco.SelectedIndex = -1;
            }
        }

        private void _Chk_NumeroDeCuenta_CheckedChanged(object sender, EventArgs e)
        {
            if (!_Chk_NumeroDeCuenta.Checked)
            {
                _Cmb_NumeroDeCuenta.SelectedIndex = -1;
            }
        }


     }
}
