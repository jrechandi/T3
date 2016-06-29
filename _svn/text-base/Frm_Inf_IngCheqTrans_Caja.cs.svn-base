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
    public partial class Frm_Inf_IngCheqTrans_Caja : Form
    {
        public Frm_Inf_IngCheqTrans_Caja()
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
            string _Str_Sql = "SELECT * FROM VST_CAJA_INGCHEQTRANS WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' and (cegresotransito=0 OR cegresotransito IS NULL) AND caprobado=1";
            int _Int_CajaPorCerrar = _Mtd_CajaPorCerrar();
            if (!_Chk_ProximaCaja.Checked | (_Chk_ProximaCaja.Checked & _Int_CajaPorCerrar > 0))
            {
                if (_Chk_ProximaCaja.Checked)
                { _Str_Sql = "SELECT * FROM VST_CAJA_INGCHEQTRANS WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Int_CajaPorCerrar + "' and (cegresotransito=0 OR cegresotransito IS NULL) AND caprobado=1"; }
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    Report.rCajaIngCheqT _My_Reporte = new T3.Report.rCajaIngCheqT();
                    _My_Reporte.SetDataSource(_Ds.Tables[0]);
                    Section _sec = _My_Reporte.ReportDefinition.Sections["Section2"];
                    TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                    tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                    if (_Chk_ProximaCaja.Checked)
                    {
                        TextObject tex3 = _sec.ReportObjects["Text2"] as TextObject;
                        tex3.Text = "INGRESO CHEQUES EN TRANSITO DE LA CAJA (NO CERRADA)";
                    }
                    this._Rpv_Main.ReportSource = _My_Reporte;
                    _Rpv_Main.RefreshReport();
                }
                else
                {
                    this._Rpv_Main.ReportSource = null;
                    MessageBox.Show("No existen cheques en tránsito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No existe una caja por cerrar", "información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Bt_Caja_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(52, _Txt_Caja, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
            this._Rpv_Main.ReportSource = null;
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            if (_Txt_Caja.Text.Trim().Length > 0 | _Chk_ProximaCaja.Checked)
            {
                _Er_Error.Dispose();
                Cursor = Cursors.WaitCursor;
                _Mtd_Buscar();
                Cursor = Cursors.Default;
            }
            else
            { _Er_Error.SetError(_Bt_Caja, "Información requerida!!!"); }
        }

        private void Frm_Inf_IngCheqTrans_Caja_Load(object sender, EventArgs e)
        {

        }

        private void _Chk_ProximaCaja_CheckedChanged(object sender, EventArgs e)
        {
            this._Rpv_Main.ReportSource = null;
            if (_Chk_ProximaCaja.Checked)
            {
                _Txt_Caja.Text = "";
                _Bt_Caja.Enabled = false;
            }
            else
            {
                _Bt_Caja.Enabled = true;
            }
        }
    }
}