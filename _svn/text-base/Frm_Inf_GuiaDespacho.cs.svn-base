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
    public partial class Frm_Inf_GuiaDespacho : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_GuiaDespacho()
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
            string _Str_Sql = "SELECT * FROM VST_REPORTEGUIDESPACHO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cguiadesp='" + _Txt_Guia.Text + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            Report.rGuiaDespacho _My_Reporte = new T3.Report.rGuiaDespacho();
            //----------------------------
            string _Str_Cadena = "Select cprecarga from tguiadespachom where cguiadesp='" + _Txt_Guia.Text + "'";
            DataSet _Ds_Guia = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds_Guia.Tables[0].Rows.Count > 0)
            {
                if (_Mtd_RequiereGuiaSada(_Ds_Guia.Tables[0].Rows[0][0].ToString()))
                {
                    Section _sec = _My_Reporte.ReportDefinition.Sections["Section3"];
                    TextObject _Txt_RequiereGuiaSada = _sec.ReportObjects["Txt_RequiereGuiaSada"] as TextObject;
                    _Txt_RequiereGuiaSada.Text = "***REQUIERE GUÍA SADA***";
                }
            }
            //----------------------------
            _My_Reporte.SetDataSource(_Ds.Tables[0]);
            this._Rpv_Main.ReportSource = _My_Reporte;
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

        private void Frm_Inf_GuiaDespacho_Load(object sender, EventArgs e)
        {

        }

        private bool _Mtd_RequiereGuiaSada(string _P_Str_Precarga)
        {
            var _Bol_RequiereGuiaSada = false;
            string _Str_Cadena = "SELECT DISTINCT TPREFACTURAM.ccompany " +
                              "FROM TPRECARGAM INNER JOIN " +
                              "TPRECARGADPF ON TPRECARGAM.cgroupcomp = TPRECARGADPF.cgroupcomp AND " +
                              "TPRECARGAM.cprecarga = TPRECARGADPF.cprecarga INNER JOIN " +
                              "TPREFACTURAM ON dbo.TPRECARGADPF.cpfactura = TPREFACTURAM.cpfactura " +
                              "WHERE TPRECARGAM.cprecarga='" + _P_Str_Precarga + "'";
            DataSet _Ds_Comp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds_Comp.Tables[0].Rows)
            {
                double _Dbl_Toneladas = 0;
                _Str_Cadena = "SELECT ISNULL(SUM(CONVERT(NUMERIC(18,3),CONVERT(NUMERIC(18,2),CONVERT(NUMERIC(18,2),(TPREFACTURAD.cempaques*(TPRODUCTO.ccontenidoma1/TPRODUCTO.ccontenidoma2))+TPREFACTURAD.cunidades)*CONVERT(NUMERIC(18,2),cpesounid1))/1000000)),0) AS Toneladas " +
                      "FROM TPREFACTURAM INNER JOIN " +
                      "TPREFACTURAD ON TPREFACTURAM.ccompany = TPREFACTURAD.ccompany AND " +
                      "TPREFACTURAM.cpfactura = TPREFACTURAD.cpfactura INNER JOIN " +
                      "TPRECARGADPF ON TPREFACTURAM.cpfactura = TPRECARGADPF.cpfactura INNER JOIN " +
                      "TPRODUCTO ON TPRODUCTO.cproducto = TPREFACTURAD.cproducto INNER JOIN " +
                      "TSICARUBROSD ON TSICARUBROSD.cproducto=TPREFACTURAD.cproducto INNER JOIN " +
                      "TSICARUBROSM ON TSICARUBROSD.ccodigorubro=TSICARUBROSM.ccodigorubro AND " +
                      "TSICARUBROSD.cdelete=TSICARUBROSM.cdelete " +
                      "WHERE (TPRECARGADPF.cgroupcomp='" + Frm_Padre._Str_GroupComp + "') AND (TPRECARGADPF.cprecarga='" + _P_Str_Precarga + "') AND (TPREFACTURAM.ccompany='" + _Row[0].ToString() + "') AND (TSICARUBROSM.cdelete=0)";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                { _Dbl_Toneladas = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]); }
                if (_Dbl_Toneladas > 0)
                {
                    _Bol_RequiereGuiaSada = true;
                }
            }
            return _Bol_RequiereGuiaSada;
        }
    }
}