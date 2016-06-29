using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
namespace T3
{
    public partial class Frm_Inf_NC_Aplic_Caja : Form
    {
        public Frm_Inf_NC_Aplic_Caja()
        {
            InitializeComponent();
        }
        private int _Mtd_CajaPorCerrar()
        {
            string _Str_Cadena = "SELECT ccaja FROM TCAJACXC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccerrada='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString().Trim());
            }
            return 0;
        }
        private void _Mtd_Buscar()
        {
            string _Str_Sql = "SELECT * FROM VST_CAJA_NC_APLICADAS_RPT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "'";
            if (_Txt_Caja_2.Text.Trim().Length > 0)
            {
                _Str_Sql = "SELECT * FROM VST_CAJA_NC_APLICADAS_RPT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND convert(numeric(18,0),ccaja) BETWEEN " + _Txt_Caja.Text + " AND " + _Txt_Caja_2.Text + " ORDER BY convert(numeric(18,0),ccaja)";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    Report.rCajaNC2 _My_Reporte = new T3.Report.rCajaNC2();
                    _My_Reporte.SetDataSource(_Ds.Tables[0]);
                    Section _sec = _My_Reporte.ReportDefinition.Sections["Section2"];
                    TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                    tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                    this._Rpv_Main.ReportSource = _My_Reporte;
                    _Rpv_Main.RefreshReport();
                }
                else
                {
                    this._Rpv_Main.ReportSource = null;
                    MessageBox.Show("No existen Notas de Crédito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                int _Int_CajaPorCerrar = _Mtd_CajaPorCerrar();
                if (!_Chk_PorAplicar.Checked | (_Chk_PorAplicar.Checked & _Int_CajaPorCerrar > 0))
                {
                    if (_Chk_PorAplicar.Checked)
                    { _Str_Sql = "SELECT * FROM VST_CAJA_NC_APLICADAS_RPT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Int_CajaPorCerrar + "'"; }
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        Report.rCajaNC _My_Reporte = new T3.Report.rCajaNC();
                        _My_Reporte.SetDataSource(_Ds.Tables[0]);
                        Section _sec = _My_Reporte.ReportDefinition.Sections["Section2"];
                        TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                        tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                        if (_Chk_PorAplicar.Checked)
                        {
                            tex1 = _sec.ReportObjects["Text11"] as TextObject;
                            tex1.Text = "NOTAS DE CRÉDITO POR APLICAR EN LA CAJA";
                        }
                        this._Rpv_Main.ReportSource = _My_Reporte;
                        _Rpv_Main.RefreshReport();
                    }
                    else
                    {
                        this._Rpv_Main.ReportSource = null;
                        MessageBox.Show("No existen Notas de Crédito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No existe una caja por cerrar", "información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void _Bt_Caja_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(52, _Txt_Caja, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
            this._Rpv_Main.ReportSource = null;
            _Txt_Caja_2.Text = "";
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            if (_Txt_Caja.Text.Trim().Length > 0 | _Chk_PorAplicar.Checked)
            {
                _Er_Error.Dispose();
                Cursor = Cursors.WaitCursor;
                _Mtd_Buscar();
                Cursor = Cursors.Default;
            }
            else
            { _Er_Error.SetError(_Bt_Caja, "Información requerida!!!"); }
        }

        private void Frm_Inf_NC_Aplic_Caja_Load(object sender, EventArgs e)
        {

        }

        private void _Bt_Caja_2_Click(object sender, EventArgs e)
        {
            if (_Txt_Caja.Text.Trim().Length > 0)
            {
                Cursor = Cursors.WaitCursor;
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(52, _Txt_Caja_2, 0, " AND convert(numeric(18,0),ccaja)>" + _Txt_Caja.Text.Trim());
                Cursor = Cursors.Default;
                _Frm.ShowDialog(); 
            }
            else
            {
                MessageBox.Show("Debe ingresar datos en 'Caja Desde'.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Bt_Limpiar_Click(object sender, EventArgs e)
        {
            _Txt_Caja_2.Text = "";
        }

        private void _Chk_PorAplicar_CheckedChanged(object sender, EventArgs e)
        {
            this._Rpv_Main.ReportSource = null;
            if (_Chk_PorAplicar.Checked)
            {
                _Txt_Caja.Text = "";
                _Txt_Caja_2.Text = "";
                _Bt_Caja.Enabled = false;
                _Bt_Caja_2.Enabled = false;
                _Bt_Limpiar.Enabled = false;
            }
            else
            {
                _Bt_Caja.Enabled = true;
                _Bt_Caja_2.Enabled = true;
                _Bt_Limpiar.Enabled = true;
            }
        }
        private void _Mtd_Exportar()
        {
            string _Str_Sql = "SELECT cvendedor AS Vendedor,cidrelacobro AS Relación,ccliente AS Cliente,CONVERT(NUMERIC,nc,18) AS NC,nc_ctotaldocu AS Monto,cnumdocu AS Factura FROM VST_CAJA_NC_APLICADAS_RPT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "'";
            if (_Txt_Caja_2.Text.Trim().Length > 0)
            {
                _Str_Sql = "SELECT cvendedor AS Vendedor,cidrelacobro AS Relación,ccliente AS Cliente,CONVERT(NUMERIC,nc,18) AS NC,nc_ctotaldocu AS Monto,cnumdocu AS Factura FROM VST_CAJA_NC_APLICADAS_RPT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND convert(numeric(18,0),ccaja) BETWEEN " + _Txt_Caja.Text + " AND " + _Txt_Caja_2.Text + " ORDER BY convert(numeric(18,0),ccaja)";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Sfd_1.ShowDialog() == DialogResult.OK)
                    {
                        Clases._Cls_ExcelUtilidades _MyExcel = new T3.Clases._Cls_ExcelUtilidades();
                        _MyExcel._Mtd_DatasetToExcel(_Ds.Tables[0], _Sfd_1.FileName, "NCAPLI_CAJ_" + _Txt_Caja.Text.Trim() + "_" + _Txt_Caja_2.Text.Trim());
                        _MyExcel = null;
                    }
                }
                else
                {
                    MessageBox.Show("No existen Notas de Crédito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                int _Int_CajaPorCerrar = _Mtd_CajaPorCerrar();
                if (!_Chk_PorAplicar.Checked | (_Chk_PorAplicar.Checked & _Int_CajaPorCerrar > 0))
                {
                    if (_Chk_PorAplicar.Checked)
                    { _Str_Sql = "SELECT cvendedor AS Vendedor,cidrelacobro AS Relación,ccliente AS Cliente,CONVERT(NUMERIC,nc,18) AS NC,nc_ctotaldocu AS Monto,cnumdocu AS Factura FROM VST_CAJA_NC_APLICADAS_RPT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Int_CajaPorCerrar + "'"; }
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Sfd_1.ShowDialog() == DialogResult.OK)
                        {
                            Clases._Cls_ExcelUtilidades _MyExcel = new T3.Clases._Cls_ExcelUtilidades();
                            if (_Chk_PorAplicar.Checked)
                            { _MyExcel._Mtd_DatasetToExcel(_Ds.Tables[0], _Sfd_1.FileName, "NCPORAPLI_CAJ"); }
                            else
                            { _MyExcel._Mtd_DatasetToExcel(_Ds.Tables[0], _Sfd_1.FileName, "NCAPLI_CAJ_" + _Txt_Caja.Text.Trim()); }
                            _MyExcel = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existen Notas de Crédito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No existe una caja por cerrar", "información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void _Bt_Exportar_Click(object sender, EventArgs e)
        {
            if (_Txt_Caja.Text.Trim().Length > 0 | _Chk_PorAplicar.Checked)
            {
                _Er_Error.Dispose();
                Cursor = Cursors.WaitCursor;
                _Mtd_Exportar();
                Cursor = Cursors.Default;
            }
            else
            { _Er_Error.SetError(_Bt_Caja, "Información requerida!!!"); }
        }
    }
}