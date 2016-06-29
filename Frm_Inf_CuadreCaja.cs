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
    public partial class Frm_Inf_CuadreCaja : Form
    {
        public Frm_Inf_CuadreCaja()
        {
            InitializeComponent();
        }

        private void _Bt_Caja_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(52, _Txt_Caja, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
        }
        private double _Mtd_ObtenerSobrante()
        {
            string _Str_Cadena = "EXEC PA_CAJ_OBTENERSOBRANTE '" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "','" + _Txt_Caja.Text + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
        }
        private void _Mtd_CargarReporteCaja()
        {
            double _Dbl_CheqDevSaldoAnt = 0, _Dbl_CheqTSaldoAnt = 0, _Dbl_CheqDevIng = 0, _Dbl_CheqTIng = 0;
            double _Dbl_CheqTEgre = 0, _Dbl_CheqDevEgre = 0, _Dbl_TotalCheqDev = 0, _Dbl_TotalCheqT = 0;
            double _Dbl_Sobrante = _Mtd_ObtenerSobrante();
            string _Str_Sql = "";
            DataSet _Ds;
            Report.rCajaCxCPrueba _MyReport = new T3.Report.rCajaCxCPrueba();
            _Str_Sql = "SELECT * FROM VST_CAJACXC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _MyReport.SetDataSource(_Ds.Tables[0]);
            double _Dbl_CajTotIng = 0;
            for (int _I = 0; _I < _MyReport.Subreports.Count; _I++)
            {
                if (_MyReport.Subreports[_I].Name == "rCajaCxCtotalCobradoSdevcheq.rpt")
                {
                    _Str_Sql = "SELECT * FROM VST_RELCOB_TOTALCOBRADO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND caprobado=1";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                }
                else if (_MyReport.Subreports[_I].Name == "rCajaCxCtotalCheqDev.rpt")
                {
                    _Str_Sql = "SELECT * FROM VST_CHEQDEVUELT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja_cierre='" + _Txt_Caja.Text + "' AND caprobado=1";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                }
                else if (_MyReport.Subreports[_I].Name == "rCajaCxCTotalIngreso.rpt")
                {
                    //_Str_Sql = "SELECT TOP 1 *," + _Mtd_ObtenerSobrante().ToString().Replace(",", ".") + " as sobrante,DBO.[FNC_RELCOB_INGRESO](cgroupcomp,ccompany,ccaja) AS sum_cmontocancel FROM VST_CAJA_TOTALINGRESO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND caprobado=1";
                    _Str_Sql = "SELECT TOP 1 *," + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Sobrante) + " as sobrante," + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_CajTotIng) + " AS sum_cmontocancel FROM VST_CAJA_TOTALINGRESO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND caprobado=1";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                }
                else if (_MyReport.Subreports[_I].Name == "rCajaCxCDepositos.rpt")
                {
                    _Str_Sql = "SELECT * FROM VST_RELCOB_DEP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND caprobado=1";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                }
                else if (_MyReport.Subreports[_I].Name == "rCajaCxCCheqTransito.rpt")
                {
                    //_Str_Sql = "SELECT * FROM VST_CAJA_DEP_CHEQ_EGRESO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND caprobado=1 AND (ccaja IS NULL OR ccaja='0')";
                    _Str_Sql = "SELECT cbancodepo,cbancodepo_name,cnumdepo,SUM(cmontocheq) AS cmontocheq FROM VST_CAJA_DEP_CHEQ_EGRESO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND caprobado=1 AND ccaja='" + _Txt_Caja.Text + "' GROUP BY cbancodepo,cbancodepo_name,cnumdepo";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                }
                else if (_MyReport.Subreports[_I].Name == "rCajaCxCTotEgreso.rpt")
                {
                    //_Str_Sql = "SELECT * FROM VST_RELCOB_TOTEGRESO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND caprobado=1";
                    _Str_Sql = "EXEC PA_CAJ_RELCOB_TOTEGRESO_CAJA_ANT '" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "','" + _Txt_Caja.Text + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                }
                else if (_MyReport.Subreports[_I].Name == "rCajaCxCSaldoActual.rpt")
                {
                    //_Str_Sql = "SELECT CAST(dbo.FNC_RELCOB_INGRESO(" + Frm_Padre._Str_GroupComp + ",'" + Frm_Padre._Str_Comp + "','" + _Txt_Caja.Text + "') AS NUMERIC(18,2)) AS ingresos, CAST(dbo.FNC_RELCOB_EGRESO(" + Frm_Padre._Str_GroupComp + ",'" + Frm_Padre._Str_Comp + "','" + _Txt_Caja.Text + "','" + _Txt_Caja.Text + "') AS NUMERIC(18,2)) as egresos,CAST(dbo.FNC_RELCOB_SALDO(" + Frm_Padre._Str_GroupComp + ",'" + Frm_Padre._Str_Comp + "','" + _Txt_Caja.Text + "','" + _Txt_Caja.Text + "') AS NUMERIC(18,2)) as saldo," + _Mtd_ObtenerSobrante().ToString().Replace(",",".") + " AS sobrante";
                    _Str_Sql = "EXEC PA_CAJ_OBTEN_ING_EGR_SAL_CAJA_ANT '" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "','" + _Txt_Caja.Text + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Sobrante) + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                        { _Dbl_CajTotIng = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]); }
                    }
                    _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                }
                else if (_MyReport.Subreports[_I].Name == "rCajaCxCSobranteFaltante.rpt")
                {
                    _Str_Sql = "SELECT cidrelacobro,c_sobrante_faltante FROM VST_SOBRANTE_FALTANTE WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND c_sobrante_faltante<>0";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                }
            }

            TextObject tex1 = _MyReport.ReportDefinition.Sections["DetailSection7"].ReportObjects["Txt_CheqDevSaldoAnt"] as TextObject;
            //_Str_Sql = "SELECT SUM(cmontodeefectivo) FROM VST_RELCOB_CHEQDEV_PROCESADOS WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja<>'" + _Txt_Caja.Text + "'";
            _Str_Sql = "SELECT ccheqdev_saldoant FROM TCAJACXC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim().Length > 0)
                {
                    _Dbl_CheqDevSaldoAnt = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                    //_Dbl_CheqDevSaldoAnt = _Mtd_CheqDev_Ingresados() - _Dbl_CheqDevSaldoAnt;
                    tex1.Text = _Dbl_CheqDevSaldoAnt.ToString("#,##0.00");
                }
                else
                {
                    //_Dbl_CheqDevSaldoAnt = _Mtd_CheqDev_Ingresados();
                    tex1.Text = _Dbl_CheqDevSaldoAnt.ToString("#,##0.00");
                }
            }
            else
            {
                //_Dbl_CheqDevSaldoAnt = _Mtd_CheqDev_Ingresados();
                tex1.Text = _Dbl_CheqDevSaldoAnt.ToString("#,##0.00");
            }

            tex1 = _MyReport.ReportDefinition.Sections["DetailSection7"].ReportObjects["Txt_CheqTSaldoAnt"] as TextObject;
            //_Str_Sql = "SELECT SUM(cmontocheq) FROM VST_RELCOB_CHEQTRANS WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja<>'" + _Txt_Caja.Text + "'";
            _Str_Sql = "SELECT ccheqtrans_saldoant FROM TCAJACXC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim().Length > 0)
                {
                    _Dbl_CheqTSaldoAnt = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                    tex1.Text = _Dbl_CheqTSaldoAnt.ToString("#,##0.00");
                }
                else
                {
                    _Dbl_CheqTSaldoAnt = 0;
                    tex1.Text = "0,00";
                }
            }
            else
            {
                _Dbl_CheqTSaldoAnt = 0;
                tex1.Text = "0,00";
            }

            tex1 = _MyReport.ReportDefinition.Sections["DetailSection7"].ReportObjects["Txt_CheqDevIng"] as TextObject;
            _Str_Sql = "SELECT SUM(cmontocheq) FROM VST_CHEQDEVUELT WHERE ccaja_cierre='" + _Txt_Caja.Text + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo=1";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim().Length > 0)
                {
                    _Dbl_CheqDevIng = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                    tex1.Text = _Dbl_CheqDevIng.ToString("#,##0.00");
                }
                else
                {
                    _Dbl_CheqDevIng = 0;
                    tex1.Text = "0,00";
                }
            }
            else
            {
                _Dbl_CheqDevIng = 0;
                tex1.Text = "0,00";
            }

            tex1 = _MyReport.ReportDefinition.Sections["DetailSection7"].ReportObjects["Txt_CheqTIng"] as TextObject;
            _Str_Sql = "SELECT SUM(cmontocheq) FROM VST_RELCOB_CHEQTRANS WHERE ccaja='" + _Txt_Caja.Text.Trim() + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'";// AND (cegresotransito is null or cegresotransito=0)";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim().Length > 0)
                {
                    _Dbl_CheqTIng = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                    tex1.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]).ToString("#,##0.00");
                }
                else
                {
                    _Dbl_CheqTIng = 0;
                    tex1.Text = "0,00";
                }
            }
            else
            {
                _Dbl_CheqTIng = 0;
                tex1.Text = "0,00";
            }

            tex1 = _MyReport.ReportDefinition.Sections["DetailSection7"].ReportObjects["Txt_CheqTEgre"] as TextObject;
            _Str_Sql = "SELECT SUM(cmontocheq) FROM TEGRECHEQTRAN WHERE cdelete=0 AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim().Length > 0)
                {
                    _Dbl_CheqTEgre = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                    tex1.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]).ToString("#,##0.00");
                }
                else
                {
                    _Dbl_CheqTEgre = 0;
                    tex1.Text = "0,00";
                }
            }
            else
            {
                _Dbl_CheqTEgre = 0;
                tex1.Text = "0,00";
            }

            tex1 = _MyReport.ReportDefinition.Sections["DetailSection7"].ReportObjects["Txt_CheqDevEgre"] as TextObject;
            _Str_Sql = "SELECT SUM(sum_cmontodeefectivo) FROM VST_RELCOB_CHEQUESDEVUELTOS WHERE ccaja='" + _Txt_Caja.Text.Trim() + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND NOT EXISTS (SELECT * FROM TCHEQDEVUELT WHERE VST_RELCOB_CHEQUESDEVUELTOS.cgroupcomp=TCHEQDEVUELT.cgroupcomp AND VST_RELCOB_CHEQUESDEVUELTOS.ccompany=TCHEQDEVUELT.ccompany AND VST_RELCOB_CHEQUESDEVUELTOS.cnumdocu=TCHEQDEVUELT.cnumcheque AND VST_RELCOB_CHEQUESDEVUELTOS.ccliente=TCHEQDEVUELT.ccliente AND VST_RELCOB_CHEQUESDEVUELTOS.cbancocheque=TCHEQDEVUELT.cbancocheque AND TCHEQDEVUELT.cactivo=0)";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim().Length > 0)
                {
                    _Dbl_CheqDevEgre = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                    tex1.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]).ToString("#,##0.00");
                }
                else
                {
                    _Dbl_CheqDevEgre = 0;
                    tex1.Text = "0,00";
                }
            }
            else
            {
                _Dbl_CheqDevEgre = 0;
                tex1.Text = "0,00";
            }

            _Dbl_TotalCheqDev = _Dbl_CheqDevIng - _Dbl_CheqDevEgre + _Dbl_CheqDevSaldoAnt;
            _Dbl_TotalCheqT = _Dbl_CheqTSaldoAnt - _Dbl_CheqTEgre + _Dbl_CheqTIng;
            tex1 = _MyReport.ReportDefinition.Sections["DetailSection7"].ReportObjects["Txt_TotalCheqDev"] as TextObject;
            tex1.Text = _Dbl_TotalCheqDev.ToString("#,##0.00");
            tex1 = _MyReport.ReportDefinition.Sections["DetailSection7"].ReportObjects["Txt_TotalCheqT"] as TextObject;
            tex1.Text = _Dbl_TotalCheqT.ToString("#,##0.00");

            //tex1 = _MyReport.ReportDefinition.Sections["DetailSection8"].ReportObjects["Txt_Sobrante"] as TextObject;
            //tex1.Text = _Dbl_Sobrante.ToString("#,##0.00");

            _MyReport.Refresh();
            _Rpv_Main.ReportSource = _MyReport;
            _Rpv_Main.RefreshReport();

        }
        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            if (_Txt_Caja.Text.Trim().Length > 0)
            {
                _Er_Error.Dispose();
                Cursor = Cursors.WaitCursor;
                _Mtd_CargarReporteCaja();
                Cursor = Cursors.Default;
            }
            else
            { _Er_Error.SetError(_Bt_Caja, "Información requerida!!!"); }
        }
    }
}