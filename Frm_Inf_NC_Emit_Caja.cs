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
    public partial class Frm_Inf_NC_Emit_Caja : Form
    {
        public Frm_Inf_NC_Emit_Caja()
        {
            InitializeComponent();
        }
        private void _Mtd_Buscar()
        {
            string _Str_Sql = "SELECT * FROM VST_NOTACREDITOEMIT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cimpresa='1' AND ccaja='" + _Txt_Caja.Text + "'";
            if (_Txt_Caja_2.Text.Trim().Length > 0)
            {
                _Str_Sql = "SELECT * FROM VST_NOTACREDITOEMIT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cimpresa='1' AND ccaja BETWEEN " + _Txt_Caja.Text + " AND " + _Txt_Caja_2.Text + " ORDER BY convert(numeric(18,0),ccaja)";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    Report.rInfNotaCredEmit2 _My_Reporte = new T3.Report.rInfNotaCredEmit2();
                    _My_Reporte.SetDataSource(_Ds.Tables[0]);
                    Section _sec = _My_Reporte.ReportDefinition.Sections["Section2"];
                    TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                    tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                    TextObject tex2 = _sec.ReportObjects["txt_desde_hasta"] as TextObject;
                    tex2.Text = " Desde la Caja N#: " + _Txt_Caja.Text + " a la Caja N#: " + _Txt_Caja_2.Text; 
                    TextObject tex3 = _sec.ReportObjects["txt_titulo"] as TextObject;
                    tex3.Text = "NOTAS DE CRÉDITO EMITIDAS";
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
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    Report.rInfNotaCredEmit _My_Reporte = new T3.Report.rInfNotaCredEmit();
                    _My_Reporte.SetDataSource(_Ds.Tables[0]);
                    Section _sec = _My_Reporte.ReportDefinition.Sections["Section2"];
                    TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                    tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                    TextObject tex2 = _sec.ReportObjects["txt_desde_hasta"] as TextObject;
                    tex2.Text = "Caja N#: " + _Txt_Caja.Text;
                    TextObject tex3 = _sec.ReportObjects["txt_titulo"] as TextObject;
                    tex3.Text = "NOTAS DE CRÉDITO EMITIDAS";
                    this._Rpv_Main.ReportSource = _My_Reporte;
                    _Rpv_Main.RefreshReport();
                }
                else
                {
                    this._Rpv_Main.ReportSource = null;
                    MessageBox.Show("No existen Notas de Crédito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (_Txt_Caja.Text.Trim().Length > 0)
            {
                _Er_Error.Dispose();
                Cursor = Cursors.WaitCursor;
                _Mtd_Buscar();
                Cursor = Cursors.Default;
            }
            else
            { _Er_Error.SetError(_Bt_Caja, "Información requerida!!!"); }
        }

        private void Frm_Inf_NC_Emit_Caja_Load(object sender, EventArgs e)
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
    }
}