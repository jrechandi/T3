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
    public partial class Frm_Inf_RelaFactCobro : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_RelaFactCobro()
        {
            InitializeComponent();
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private void _Mtd_Buscar()
        {
            string _Str_Sql = "SELECT TCOMPANY.cname AS ccompany, cguiadesp, cfactura, ccliente, c_nomb_comer, c_montotot_si_bs, c_impuesto_bs, c_estatus, c_fechaentrega, total, cliqguidespacho, cfacturasrelacobro, ruta, cvendedor, CedulaTransportista, NombreTransportista FROM VST_GUIADESPAFACTALCOBRO INNER JOIN TCOMPANY ON VST_GUIADESPAFACTALCOBRO.ccompany=TCOMPANY.ccompany WHERE " + CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp().Replace("ccompany", "VST_GUIADESPAFACTALCOBRO.ccompany") + " AND cguiadesp='" + _Txt_Guia.Text + "' ORDER BY cfactura";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                Report.rGuiaFacturaAlCobro2 _My_Reporte = new T3.Report.rGuiaFacturaAlCobro2();
                _My_Reporte.SetDataSource(_Ds.Tables[0]);
                //----------------------------
                _Str_Sql = "SELECT TCOMPANY.cname AS ccompany, cguiadesp, cfactura, ccliente, c_nomb_comer, c_montotot_si_bs, c_impuesto_bs, c_estatus, c_fechaentrega, total, cliqguidespacho, cfacturasrelacobro, ruta, cvendedor, CedulaTransportista, NombreTransportista FROM VST_GUIADESPAFACTALCOBRO2 INNER JOIN TCOMPANY ON VST_GUIADESPAFACTALCOBRO2.ccompany=TCOMPANY.ccompany WHERE " + CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp().Replace("ccompany", "VST_GUIADESPAFACTALCOBRO2.ccompany") + " AND cguiadesp='" + _Txt_Guia.Text + "' ORDER BY cfactura";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                { _My_Reporte.Subreports[0].SetDataSource(_Ds.Tables[0]); }
                else
                { _My_Reporte.Section4.SectionFormat.EnableSuppress = true; }
                //----------------------------
                _Rpv_Main.ReportSource = _My_Reporte;
            }
            else
            {
                _Str_Sql = "SELECT TCOMPANY.cname AS ccompany, cguiadesp, cfactura, ccliente, c_nomb_comer, c_montotot_si_bs, c_impuesto_bs, c_estatus, c_fechaentrega, total, cliqguidespacho, cfacturasrelacobro, ruta, cvendedor, CedulaTransportista, NombreTransportista FROM VST_GUIADESPAFACTALCOBRO2 INNER JOIN TCOMPANY ON VST_GUIADESPAFACTALCOBRO2.ccompany=TCOMPANY.ccompany WHERE " + CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp().Replace("ccompany", "VST_GUIADESPAFACTALCOBRO2.ccompany") + " AND cguiadesp='" + _Txt_Guia.Text + "' ORDER BY cfactura";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    Report.rGuiaFacturaAlCobro2Sub _My_Reporte = new T3.Report.rGuiaFacturaAlCobro2Sub();
                    _My_Reporte.SetDataSource(_Ds.Tables[0]);
                    _Rpv_Main.ReportSource = _My_Reporte;
                }
                else
                {
                    _Rpv_Main.ReportSource = null;
                    MessageBox.Show("No se obtuvieron registros", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            _Rpv_Main.RefreshReport();
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            if (_Txt_Guia.Text.Trim().Length > 0)
            {
                _Er_Error.Dispose();
                Cursor = Cursors.WaitCursor;
                _Mtd_Buscar();
                Cursor = Cursors.Default;
            }
            else
            { _Er_Error.SetError(_Txt_Guia, "Información requerida!!!"); }
        }

        private void _Txt_Guia_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Guia.Text))
            {
                _Txt_Guia.Text = "";
            }
        }

        private void _Txt_Guia_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Guia, e, 10, 0);
        }
    }
}