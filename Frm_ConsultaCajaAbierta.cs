using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Net;
using System.Threading;
namespace T3
{
    public partial class Frm_ConsultaCajaAbierta : Form
    {
        bool _G_Bol_SwCierreCaja = false;
        bool _G_Bol_SwCheDevuelto = false;
        bool _G_Bol_SwCheTransito = false;
        double _G_Dbl_TotalCheqDev = 0;
        double _G_Dbl_TotalCheqT = 0;
        public Frm_ConsultaCajaAbierta(string _Pr_Str_Caja, string _Pr_Str_Fecha)
        {
            InitializeComponent();
            _Txt_Caja.Text = _Pr_Str_Caja;
            _Txt_Fecha.Text = _Pr_Str_Fecha;
        }
        CLASES._Cls_Varios_Metodos _MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        Report.rCajaCxCPrueba _MyReport;
        private void _Mtd_CargarReporteCaja()
        {
            double _Dbl_CheqDevSaldoAnt = 0, _Dbl_CheqTSaldoAnt = 0, _Dbl_CheqDevIng = 0, _Dbl_CheqTIng = 0;
            double _Dbl_CheqTEgre = 0, _Dbl_CheqDevEgre = 0, _Dbl_TotalCheqDev = 0, _Dbl_TotalCheqT = 0;
            string _Str_Sql = "";
            DataSet _Ds;
            _MyReport = new T3.Report.rCajaCxCPrueba();
            _Str_Sql = "SELECT * FROM VST_CAJACXC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _MyReport.SetDataSource(_Ds.Tables[0]);
            double _Dbl_CajTotIng = 0;
            for (int _I = 0; _I < _MyReport.Subreports.Count;_I++)
            {
                if (_MyReport.Subreports[_I].Name == "rCajaCxCtotalCobradoSdevcheq.rpt")
                {
                    _Str_Sql = "SELECT * FROM VST_RELCOB_TOTALCOBRADO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND caprobado=1";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                }
                else if (_MyReport.Subreports[_I].Name == "rCajaCxCtotalCheqDev.rpt")
                {
                    _Str_Sql = "SELECT * FROM VST_CHEQDEVUELT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja_cierre IS NULL AND caprobado=1";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                }
                else if (_MyReport.Subreports[_I].Name == "rCajaCxCTotalIngreso.rpt")
                {
                    //_Str_Sql = "SELECT TOP 1 *," + _Mtd_ObtenerSobrante().ToString().Replace(",", ".") + " as sobrante,DBO.[FNC_RELCOB_INGRESO](cgroupcomp,ccompany,ccaja) AS sum_cmontocancel FROM VST_CAJA_TOTALINGRESO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND caprobado=1";
                    _Str_Sql = "SELECT TOP 1 *," + _Mtd_ObtenerSobrante().ToString().Replace(",", ".") + " as sobrante," + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_CajTotIng) + " AS sum_cmontocancel FROM VST_CAJA_TOTALINGRESO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND caprobado=1";
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
                    _Str_Sql = "SELECT cbancodepo,cbancodepo_name,cnumdepo,SUM(cmontocheq) AS cmontocheq FROM VST_CAJA_DEP_CHEQ_EGRESO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND caprobado=1 AND ccaja is null GROUP BY cbancodepo,cbancodepo_name,cnumdepo";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                }
                else if (_MyReport.Subreports[_I].Name == "rCajaCxCTotEgreso.rpt")
                {
                    //_Str_Sql = "SELECT * FROM VST_RELCOB_TOTEGRESO WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND caprobado=1";
                    _Str_Sql = "EXEC PA_CAJ_RELCOB_TOTEGRESO '" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "','" + _Txt_Caja.Text + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                }
                else if (_MyReport.Subreports[_I].Name == "rCajaCxCSaldoActual.rpt")
                {
                    //_Str_Sql = "SELECT CAST(dbo.FNC_RELCOB_INGRESO(" + Frm_Padre._Str_GroupComp + ",'" + Frm_Padre._Str_Comp + "','" + _Txt_Caja.Text + "') AS NUMERIC(18,2)) AS ingresos, CAST(dbo.FNC_RELCOB_EGRESO(" + Frm_Padre._Str_GroupComp + ",'" + Frm_Padre._Str_Comp + "','" + _Txt_Caja.Text + "','" + _Txt_Caja.Text + "') AS NUMERIC(18,2)) as egresos,CAST(dbo.FNC_RELCOB_SALDO(" + Frm_Padre._Str_GroupComp + ",'" + Frm_Padre._Str_Comp + "','" + _Txt_Caja.Text + "','" + _Txt_Caja.Text + "') AS NUMERIC(18,2)) as saldo," + _Mtd_ObtenerSobrante().ToString().Replace(",",".") + " AS sobrante";
                    _Str_Sql = "EXEC PA_CAJ_OBTEN_ING_EGR_SAL '" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "','" + _Txt_Caja.Text + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Mtd_ObtenerSobrante()) + "'";
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
            _Str_Sql = "SELECT SUM(cmontocheq) FROM VST_CHEQDEVUELT WHERE ccaja_cierre IS NULL AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo=1";
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
            _Str_Sql = "SELECT SUM(cmontocheq) FROM VST_RELCOB_CHEQTRANS WHERE ccaja='" + _Txt_Caja.Text.Trim() + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND (cegresotransito is null or cegresotransito=0)";
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
            _Str_Sql = "SELECT SUM(cmontocheq) FROM TEGRECHEQTRAN WHERE cdelete=0 AND cimpreso=0 AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja IS NULL";
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

            _Dbl_TotalCheqDev = _Dbl_CheqDevIng - _Dbl_CheqDevEgre  + _Dbl_CheqDevSaldoAnt;
            _Dbl_TotalCheqT = _Dbl_CheqTSaldoAnt - _Dbl_CheqTEgre + _Dbl_CheqTIng;
            _G_Dbl_TotalCheqDev = _Dbl_TotalCheqDev;
            _G_Dbl_TotalCheqT = _Dbl_TotalCheqT;
            double _Dbl_TotalCheques = _Dbl_TotalCheqDev + _Dbl_TotalCheqT;
            if (Math.Round(_Dbl_TotalCheques,2) == _Mtd_GetSaldoActual())
            {
                _G_Bol_SwCierreCaja = true;
            }
            else
            {
                _G_Bol_SwCierreCaja = false;
            }
            //-------------------------------------
            _Str_Sql = "SELECT cvalidacioncaja FROM TCONFIGCONSSA WHERE cvalidacioncaja=1";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Sql = "SELECT ISNULL(SUM(cheq_devueltos),0) AS cheq_devueltos,ISNULL(SUM(cheq_postergados),0) AS cheq_postergados FROM VST_SALDOS_ALLDOCS_DEMO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0' AND cactivo=1 AND csaldofactura<>0";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    double _Dbl_CheqDevuelto = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cheq_devueltos"]);
                    double _Dbl_CheqTransito = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cheq_postergados"]);
                    _G_Bol_SwCheDevuelto = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(_Dbl_CheqDevuelto) == CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(_Dbl_CheqDevSaldoAnt + _Dbl_CheqDevIng);
                    _G_Bol_SwCheTransito = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(_Dbl_CheqTransito) == CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(_Dbl_TotalCheqT);
                }
            }
            else
            {
                _G_Bol_SwCheDevuelto = true;
                _G_Bol_SwCheTransito = true;
            }
            //-------------------------------------
            tex1 = _MyReport.ReportDefinition.Sections["DetailSection7"].ReportObjects["Txt_TotalCheqDev"] as TextObject;
            tex1.Text = _Dbl_TotalCheqDev.ToString("#,##0.00");
            tex1 = _MyReport.ReportDefinition.Sections["DetailSection7"].ReportObjects["Txt_TotalCheqT"] as TextObject;
            tex1.Text = _Dbl_TotalCheqT.ToString("#,##0.00");
            //-------------------------------------
            _MyReport.Refresh();
            _CRptV_A.ReportSource = _MyReport;
            _CRptV_A.RefreshReport();
            
        }
        private string[] _Mtd_FechaVencDoc(string _P_Str_Documento, string _P_Str_TipoDocument)
        {
            string _Str_Cadena = "";
            DataSet _Ds = new DataSet();
            if (_P_Str_Documento.Trim().Length > 0 & _P_Str_TipoDocument.Trim().Length > 0)
            {
                _Str_Cadena = "SELECT ctipdocfact,ctipdocnotdeb,ctipdoccheqdev FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_P_Str_TipoDocument.Trim().ToUpper() == _Ds.Tables[0].Rows[0]["ctipdocfact"].ToString().Trim().ToUpper())
                {
                    _Str_Cadena = "SELECT cfechafact,cfelimitcobro FROM TSALDOCLIENTED WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ctipodocument='" + _P_Str_TipoDocument + "' AND cnumdocu='" + _P_Str_Documento + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0 & _Ds.Tables[0].Rows[0][1].ToString().Trim().Length > 0)
                        {
                            return new string[] { _My_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0][0].ToString())), _My_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0][1].ToString())) };
                        }
                    }
                }
                else if (_P_Str_TipoDocument.Trim().ToUpper() == _Ds.Tables[0].Rows[0]["ctipdocnotdeb"].ToString().Trim().ToUpper())
                {
                    _Str_Cadena = "SELECT cfecha,cfvfnotadebitop FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocc='" + _P_Str_Documento + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0 & _Ds.Tables[0].Rows[0][1].ToString().Trim().Length > 0)
                        {
                            return new string[] { _My_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0][0].ToString())), _My_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0][1].ToString())) };
                        }
                    }
                }
                else if (_P_Str_TipoDocument.Trim().ToUpper() == _Ds.Tables[0].Rows[0]["ctipdoccheqdev"].ToString().Trim().ToUpper())
                {
                    _Str_Cadena = "SELECT TCHEQDEVUELT.cfechaemision, TSALDOCLIENTED.cfelimitcobro FROM TSALDOCLIENTED INNER JOIN TCHEQDEVUELT ON TSALDOCLIENTED.cgroupcomp = TCHEQDEVUELT.cgroupcomp AND TSALDOCLIENTED.ccompany = TCHEQDEVUELT.ccompany AND TSALDOCLIENTED.cnumdocu = TCHEQDEVUELT.cnumcheque AND TSALDOCLIENTED.ccliente = TCHEQDEVUELT.ccliente WHERE (TSALDOCLIENTED.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TSALDOCLIENTED.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TSALDOCLIENTED.ctipodocument = '" + _P_Str_TipoDocument + "') AND (TSALDOCLIENTED.cnumdocu = '" + _P_Str_Documento + "')";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0 & _Ds.Tables[0].Rows[0][1].ToString().Trim().Length > 0)
                        {
                            return new string[] { _My_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0][0].ToString())), _My_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0][1].ToString())) };
                        }
                    }
                }
            }
            return new string[] { "null", "null" };
        }
        private void _Mtd_IngCheqTrans_Auxiliar(string _P_Str_Comprobante, string _P_Str_Cuenta, string _P_Str_CountName, string _P_Str_TipoDocument, string _P_Str_Caja, string _P_Str_Month, string _P_Str_Year)
        {
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _P_Str_Comprobante);
            string _Str_Cadena = "SELECT ccliente,cnumcheque,cfeahcaemision,cmontocheq AS Monto FROM VST_ING_CHEQTRANS_AUX_TOTAL WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _P_Str_Caja + "' AND cdelete=0 AND caprobado=1 and (cegresotransito=0 OR cegresotransito IS NULL)";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_Cadena = _P_Str_CountName + ". CHEQUE # " + _Row["cnumcheque"].ToString().Trim() + ". INGRESOS SEGUN CAJA " + _P_Str_Caja;
                CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_P_Str_Comprobante, _P_Str_Cuenta, _Row["ccliente"].ToString().Trim(), _Str_Cadena, _P_Str_TipoDocument, _Row["cnumcheque"].ToString().Trim(), _My_Formato._Mtd_fecha(Convert.ToDateTime(_Row["cfeahcaemision"].ToString().Trim())), "null", CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Row["Monto"].ToString().Trim())), _P_Str_Month, _P_Str_Year, "D");
            }
        }
        private void _Mtd_EgreCheqDev_Auxiliar(string _P_Str_Comprobante, string _P_Str_Cuenta, string _P_Str_CountName, string _P_Str_Caja, string _P_Str_Month, string _P_Str_Year)
        {
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _P_Str_Comprobante);
            string _Str_Cadena = "SELECT ccliente,cnumdocu,cfechaemision,cmontodeefectivo,ctipodocument FROM VST_EGRE_CHEQDEV_AUX WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _P_Str_Caja + "' AND NOT EXISTS (SELECT * FROM TCHEQDEVUELT WHERE VST_EGRE_CHEQDEV_AUX.cgroupcomp=TCHEQDEVUELT.cgroupcomp AND VST_EGRE_CHEQDEV_AUX.ccompany=TCHEQDEVUELT.ccompany AND VST_EGRE_CHEQDEV_AUX.cnumdocu=TCHEQDEVUELT.cnumcheque AND VST_EGRE_CHEQDEV_AUX.ccliente=TCHEQDEVUELT.ccliente AND VST_EGRE_CHEQDEV_AUX.cbancocheque=TCHEQDEVUELT.cbancocheque AND TCHEQDEVUELT.cactivo=0)";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_Cadena = _P_Str_CountName + ". CHEQUE # " + _Row["cnumdocu"].ToString().Trim() + ". EGRESOS SEGUN CAJA " + _P_Str_Caja;
                CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_P_Str_Comprobante, _P_Str_Cuenta, _Row["ccliente"].ToString().Trim(), _Str_Cadena, _Row["ctipodocument"].ToString().Trim(), _Row["cnumdocu"].ToString().Trim(), _My_Formato._Mtd_fecha(Convert.ToDateTime(_Row["cfechaemision"].ToString().Trim())), "null", CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Row["cmontodeefectivo"].ToString().Trim())), _P_Str_Month, _P_Str_Year, "H");
            }
        }
        private bool _Mtd_ExisteTipDocCount(string _P_Str_Cuenta, string _P_Str_TipoDocument)
        {
            string _Str_Cadena = "SELECT TOP 1 cidtipoauxiliar FROM TTIPAUXILIARCONTD WHERE ctcount='" + _P_Str_Cuenta + "' AND ctdocument='" + _P_Str_TipoDocument + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Mtd_CxC_Auxiliar(string _P_Str_Comprobante, string _P_Str_Cuenta, string _P_Str_CountNameCxC, string _P_Str_CountNameIng, string _P_Str_Caja, string _P_Str_Month, string _P_Str_Year)
        {
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _P_Str_Comprobante);
            string[] _P_Str_Fecha = new string[2];
            string _Str_TipoFact = _MyUtilidad._Mtd_TipoDocument_CXC("ctipdocfact");
            string _Str_TipoND = _MyUtilidad._Mtd_TipoDocument_CXC("ctipdocnotdeb");
            string _Str_TipoCheqDev = _MyUtilidad._Mtd_TipoDocument_CXC("ctipdoccheqdev");
            string _Str_Cadena = "SELECT ccliente,cnumcheque,cnumdocu,ctipodocument,SUM(cmontodeefectivo) AS Monto FROM VST_ING_CHEQTRANS_AUX WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _P_Str_Caja + "' AND cdelete=0 AND caprobado=1 and (cegresotransito=0 OR cegresotransito IS NULL) AND (ctipodocument='" + _Str_TipoFact + "' OR ctipodocument='" + _Str_TipoND + "' OR ctipodocument='" + _Str_TipoCheqDev + "') GROUP BY ccliente,cnumcheque,cnumdocu,ctipodocument";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                if (_Mtd_ExisteTipDocCount(_P_Str_Cuenta, _Row["ctipodocument"].ToString().Trim()))
                {
                    _Str_Cadena = _P_Str_CountNameCxC + " SEGUN CAJA " + _P_Str_Caja + ". " + _P_Str_CountNameIng + " INGRESOS CHEQUE # " + _Row["cnumcheque"].ToString().Trim() + ". " + _Row["ctipodocument"].ToString().Trim() + " # " + _Row["cnumdocu"].ToString().Trim();
                    _P_Str_Fecha = _Mtd_FechaVencDoc(_Row["cnumdocu"].ToString().Trim(), _Row["ctipodocument"].ToString().Trim());
                    CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_P_Str_Comprobante, _P_Str_Cuenta, _Row["ccliente"].ToString().Trim(), _Str_Cadena, _Row["ctipodocument"].ToString().Trim(), _Row["cnumdocu"].ToString().Trim(), _P_Str_Fecha[0], _P_Str_Fecha[1], CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Row["Monto"].ToString().Trim())), _P_Str_Month, _P_Str_Year, "H");
                }
            }
            _Str_Cadena = "SELECT ccliente,cnumdocu,ctipodocument,SUM(cmontodeefectivo) AS Monto FROM VST_ING_DEPOSITOS_AUX WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _P_Str_Caja + "' AND cdelete=0 AND caprobado=1 AND (ctipodocument='" + _Str_TipoFact + "' OR ctipodocument='" + _Str_TipoND + "' OR ctipodocument='" + _Str_TipoCheqDev + "') GROUP BY ccliente,cnumdocu,ctipodocument";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                if (_Mtd_ExisteTipDocCount(_P_Str_Cuenta, _Row["ctipodocument"].ToString().Trim()))
                {
                    _Str_Cadena = _P_Str_CountNameCxC + " SEGUN CAJA " + _P_Str_Caja + ". " + _Row["ctipodocument"].ToString().Trim() + " # " + _Row["cnumdocu"].ToString().Trim();
                    _P_Str_Fecha = _Mtd_FechaVencDoc(_Row["cnumdocu"].ToString().Trim(), _Row["ctipodocument"].ToString().Trim());
                    CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_P_Str_Comprobante, _P_Str_Cuenta, _Row["ccliente"].ToString().Trim(), _Str_Cadena, _Row["ctipodocument"].ToString().Trim(), _Row["cnumdocu"].ToString().Trim(), _P_Str_Fecha[0], _P_Str_Fecha[1], CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Row["Monto"].ToString().Trim())), _P_Str_Month, _P_Str_Year, "H");
                }
            }
        }
        private bool _Mtd_ComprobanteValido(string _P_Str_Comprobante, string _P_Str_ctypcomp, string _P_Str_cyearacco, string P_Str_cmontacco)
        {
            string _Str_Cadena = "SELECT ctypcomp,cyearacco,cmontacco FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "' AND ctypcomp='" + _P_Str_ctypcomp + "' AND cyearacco='" + _P_Str_cyearacco + "' AND cmontacco='" + P_Str_cmontacco + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private string _Mtd_CrearCompropCont(string _P_Str_Caja)
        {
            string _Str_cidcomprob = "";
            int _Int_corder = 0;
            string _Str_DocFact = "";
            string _Str_DocND = "";
            string _Str_DocNC = "";
            string _Str_DocRelCob = "";
            string _Str_FechaDoc = "";
            string _Str_CadAux = "";
            string _Str_DescripCount = "";
            string _Str_ccount = "";
            string _Str_ctipdoccheq = "";
            string _Str_ctipdocumentdep = "";
            string _Str_ccuentacheqtransito = "";
            string _Str_ccuentacheqtransitoName = "";
            string _Str_ccuentacheqdia = "";
            string _Str_ccuentacheqdiaName = "";
            string _Str_ccuentacheqdevuelto = "";
            string _Str_ccuentacheqdevueltoName = "";
            string _Str_ccuentadescuentos = "";
            string _Str_ccuentadescuentosName = "";
            string _Str_ccuentaivareten = "";
            string _Str_ccuentaiva = "";
            string _Str_ccuentaivaName = "";
            string _Str_ccuentaivaretenName = "";
            string _Str_ccuentacxc = "";
            string _Str_ccuentacxcName = "";
            string _Str_ccuentasobranfaltcaj = "";
            string _Str_ccuentasobranfaltcajname = "";
            string _Str_BancoId = "";
            string _Str_BancoName = "";
            string _Str_BancoCuenta = "";
            string _Str_Deposito = "";
            double _Dbl_Monto = 0;
            double _Dbl_Sobrante = 0, _Dbl_MontoEgreCheqDev = 0;
            double _Dbl_MontoTotal = 0;
            double _Dbl_MontoCxC = 0;
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            string _Str_ctypcompro = "";
            string _Str_cconceptocomp = "";
            string _Str_TpoDocCaja = "";
            string _Str_CheqDev = "";
            string _Str_Sql = "";
            DataSet _Ds;

            _Str_Sql = "SELECT * FROM VST_CONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TpoDocCaja = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdoccaja"]);
                _Str_ctipdoccheq = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdoccheq"]);
                _Str_ctipdocumentdep = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocumentdep"]);
                _Str_ccuentacheqtransito = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqtransito"]);
                _Str_ccuentacheqtransitoName = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqtransitoname"]);
                _Str_ccuentacheqdia = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqdia"]);
                _Str_ccuentacheqdiaName = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqdianame"]);
                _Str_ccuentacheqdevuelto = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqdevuelto"]);
                _Str_ccuentacheqdevueltoName = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqdevueltoname"]);
                _Str_ccuentadescuentos = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentadescuentos"]);
                _Str_ccuentadescuentosName = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentadescuentosname"]);
                _Str_ccuentaivareten = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentaivareten"]);
                _Str_ccuentaivaretenName = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentaivaretenname"]);
                _Str_DocFact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]);
                _Str_DocNC = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocnotcred"]);
                _Str_DocND = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocnotdeb"]);
                _Str_CheqDev = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdoccheqdev"]);
                _Str_ccuentaiva = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentaiva"]);
                _Str_ccuentaivaName = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentaivaname"]);
                _Str_DocRelCob = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocrelcob"]);
                _Str_ccuentacxc = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacxc"]);
                _Str_ccuentacxcName = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacxcname"]);
                _Str_ctypcompro = Convert.ToString(_Ds.Tables[0].Rows[0]["ctypcompro"]);
                _Str_cconceptocomp = Convert.ToString(_Ds.Tables[0].Rows[0]["cconceptocomp"]);
                _Str_ccuentasobranfaltcaj = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentasobranfaltcaj"]);
                _Str_ccuentasobranfaltcajname = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentasobranfaltcajname"]);
            }
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString());
            //-----------------------
            bool _Bol_ComprobanteValido = false;
            _Str_Sql = "SELECT cidcomprob FROM TCAJACXC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _P_Str_Caja + "' AND ISNULL(cidcomprob,0)>0";
            DataSet _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Temp.Tables[0].Rows.Count > 0)
            {
                _Str_cidcomprob = _Ds_Temp.Tables[0].Rows[0][0].ToString().Trim();
                _Bol_ComprobanteValido = _Mtd_ComprobanteValido(_Str_cidcomprob, _Str_ctypcompro, _Str_cyearacco, _Str_cmontacco);
            }
            if (_Bol_ComprobanteValido)
            {
                _Str_Sql = "UPDATE TCOMPROBANC SET cdateadd='" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuseradd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
                _Str_Sql = "DELETE FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Str_Sql = "DELETE FROM TCOMPROBANDD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Str_Sql = "DELETE FROM TMOVAUXILIARCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            else
            {
                _Str_cidcomprob = Convert.ToString(_MyUtilidad._Mtd_Consecutivo_TCOMPROBANC());
                _Str_Sql = "INSERT INTO TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','0','0','0','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','0','9')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Str_Sql = "UPDATE TCAJACXC SET cidcomprob='" + _Str_cidcomprob + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            //-----------------------
            //AGREGO LOS DEPOSITOS
            _Str_CadAux = "";
            _Str_Sql = "SELECT * FROM VST_RELACCOBDDEPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _P_Str_Caja + "' AND caprobado=1";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _Int_corder++;
                _Str_FechaDoc = Convert.ToDateTime(_DRow["cfechadepo"]).ToShortDateString();
                _Str_BancoId = Convert.ToString(_DRow["cbancodepo"]);
                _Str_BancoCuenta = Convert.ToString(_DRow["cnumcuentadepo"]);
                _Str_BancoName = Convert.ToString(_DRow["cbanconame"]).Trim().ToUpper();
                _Str_Deposito = Convert.ToString(_DRow["cnumdepo"]);
                _Str_ccount = Convert.ToString(_DRow["ccount"]);
                _Str_DescripCount = Convert.ToString(_DRow["ccountname"]);
                //_Str_CadAux = _Str_BancoName + " CTA." + _Str_BancoCuenta + "DEPOSITO #" + _Str_Deposito + " SEGUN CAJA " + _P_Str_Caja;
                _Str_CadAux = "DEPOSITO " + _Str_Deposito + " SEGUN CAJA " + _P_Str_Caja;
                if (Convert.ToString(_DRow["cmontodepo"]) != "")
                {
                    _Dbl_Monto = Convert.ToDouble(_DRow["cmontodepo"]);
                }
                else
                {
                    _Dbl_Monto = 0;
                }
                _Dbl_MontoTotal = _Dbl_MontoTotal + _Dbl_Monto;
                _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctipdoccheq + "','" + _Str_Deposito + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaDoc)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + Frm_Padre._Str_Use + "','" + _Str_CadAux + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }

            //INGRESO CHEQUES EN TRANSITO
            _Str_Sql = "SELECT SUM(cmontocheq) FROM VST_RELACCOBDCHEQ WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _P_Str_Caja + "' AND cdelete=0 AND caprobado=1 and (cegresotransito=0 OR cegresotransito IS NULL)";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Length > 0)
                {
                    _Dbl_Monto = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                    if (_Dbl_Monto > 0)
                    {
                        _Int_corder++;
                        _Dbl_MontoTotal = _Dbl_MontoTotal + _Dbl_Monto;
                        _Str_CadAux = _Str_ccuentacheqtransitoName + " INGRESOS SEGUN CAJA " + _P_Str_Caja;
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                        _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccuentacheqtransito + "','" + _Str_TpoDocCaja + "','" + _P_Str_Caja + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Txt_Fecha.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + Frm_Padre._Str_Use + "','" + _Str_CadAux + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        _Mtd_IngCheqTrans_Auxiliar(_Str_cidcomprob, _Str_ccuentacheqtransito, _Str_ccuentacheqtransitoName, _Str_ctipdoccheq, _P_Str_Caja, _Str_cmontacco, _Str_cyearacco);
                    }
                }
                else
                {
                    _Dbl_Monto = 0;
                }
            }
            else
            {
                _Dbl_Monto = 0;
            }
            //EGRESO DE CHEQUES DEVUELTOS
            _Str_Sql = "SELECT SUM(sum_cmontodeefectivo) FROM VST_RELCOB_CHEQUESDEVUELTOS WHERE ccaja='" + _Txt_Caja.Text.Trim() + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND NOT EXISTS (SELECT * FROM TCHEQDEVUELT WHERE VST_RELCOB_CHEQUESDEVUELTOS.cgroupcomp=TCHEQDEVUELT.cgroupcomp AND VST_RELCOB_CHEQUESDEVUELTOS.ccompany=TCHEQDEVUELT.ccompany AND VST_RELCOB_CHEQUESDEVUELTOS.cnumdocu=TCHEQDEVUELT.cnumcheque AND VST_RELCOB_CHEQUESDEVUELTOS.ccliente=TCHEQDEVUELT.ccliente AND VST_RELCOB_CHEQUESDEVUELTOS.cbancocheque=TCHEQDEVUELT.cbancocheque AND TCHEQDEVUELT.cactivo=0)";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim().Length > 0)
                {
                    _Dbl_Monto = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                    _Dbl_MontoEgreCheqDev = _Dbl_Monto;
                    if (_Dbl_Monto > 0)
                    {
                        _Int_corder++;
                        _Str_CadAux = _Str_ccuentacheqdevueltoName + " EGRESOS SEGUN CAJA " + _P_Str_Caja;
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
                        _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccuentacheqdevuelto + "','" + _Str_TpoDocCaja + "','" + _P_Str_Caja + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Txt_Fecha.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + Frm_Padre._Str_Use + "','" + _Str_CadAux + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        _Mtd_EgreCheqDev_Auxiliar(_Str_cidcomprob, _Str_ccuentacheqdevuelto, _Str_ccuentacheqdevueltoName, _P_Str_Caja, _Str_cmontacco, _Str_cyearacco);
                    }
                }
            }
            //IVA DEBITO PAGADO POR ANTICIPADO
            _Str_Sql = "SELECT SUM(cmontcompretiva) FROM VST_CAJA_DET_RPT WHERE ccaja='" + _P_Str_Caja + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcompany='" + Frm_Padre._Str_GroupComp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim().Length > 0)
                {
                    _Dbl_Monto = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                    if (_Dbl_Monto > 0)
                    {
                        _Int_corder++;
                        _Dbl_MontoTotal = _Dbl_MontoTotal + _Dbl_Monto;
                        _Str_CadAux = _Str_ccuentaivaretenName + " INGRESOS SEGUN CAJA " + _P_Str_Caja;
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                        _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccuentaivareten + "','" + _Str_TpoDocCaja + "','" + _P_Str_Caja + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Txt_Fecha.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + Frm_Padre._Str_Use + "','" + _Str_CadAux + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    }
                }
            }
            #region Comentados
            //DESCUENTOS POR PRONTO PAGO
            //_Dbl_Monto = 0;
            //_Str_Sql = "SELECT SUM(cdesctopp) FROM VST_RELACCOBMyD WHERE cgroupcompany='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _P_Str_Caja + "' AND TRELACCOBMcdelete=0 AND caprobado=1 AND TRELACCOBDcdelete=0";
            //_Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //if (_Ds.Tables[0].Rows.Count > 0)
            //{
            //    _Dbl_DescPPPago = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
            //}
            //_Dbl_Monto = 0;
            //_Str_Sql = "SELECT cdescto1,cdescto2,cdescto3,cdescto4 FROM VST_RELACCOBMyD WHERE cgroupcompany='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _P_Str_Caja + "' AND TRELACCOBMcdelete=0 AND caprobado=1 AND TRELACCOBDcdelete=0";
            //_Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            //{
            //    for (int _I = 1; _I < 5; _I++)
            //    {
            //        if (Convert.ToString(_Drow["cdescto" + _I.ToString()]) != "")
            //        {
            //            _Dbl_Monto = _Dbl_Monto + Convert.ToDouble(_Drow["cdescto" + _I.ToString()]);
            //        }
            //    }
            //}
            //_Dbl_DescVentas = _Dbl_Monto + _Dbl_DescPPPago;
            //if (_Dbl_DescVentas != 0)
            //{
            //    _Dbl_MontoTotal = _Dbl_MontoTotal + _Dbl_DescVentas;
            //    _Str_CadAux = _Str_ccuentadescuentosName + " SEGUN CAJA " + _P_Str_Caja;
            //    _Int_corder++;
            //    _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
            //    _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccuentadescuentos + "','" + _Str_TpoDocCaja + "','" + _P_Str_Caja + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Txt_Fecha.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_DescVentas) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + _Str_CadAux + "')";
            //    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            //}
            //_Dbl_DescPPPago = 0;
            //CALCULO EL TOTAL DE IVA
            //_Str_Sql = "SELECT cdesctopp,cdescto1,cdescto2,cnotacred1,cnotacred2,cnotacred3,cnotacred4,cnotacred5,cnotacred6,cnotacred7,cnotacred8,cnotacred9,cnotacred10,sum_cmontodeefectivo,csaldofactura,csaldofacturasi FROM VST_RELACCOBMyD WHERE cgroupcompany='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _P_Str_Caja + "' AND TRELACCOBMcdelete=0 AND caprobado=1 AND TRELACCOBDcdelete=0";
            //_Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            //{
            //    _Dbl_DescPPPago = 0;
            //    _Dbl_SaldoCimp = 0;
            //    _Dbl_SaldoSimp = 0;
            //    _Dbl_MontoCObrado = 0;
            //    _Dbl_Desc1 = 0;
            //    _Dbl_Desc2 = 0;
            //    _Str_NC1 = ""; _Str_NC2 = ""; _Str_NC3 = ""; _Str_NC4 = ""; _Str_NC5 = ""; _Str_NC6 = ""; _Str_NC7 = ""; _Str_NC8 = ""; _Str_NC9 = ""; _Str_NC10 = "";
            //    _Dbl_NC1 = 0; _Dbl_NC2 = 0; _Dbl_NC3 = 0; _Dbl_NC4 = 0; _Dbl_NC5 = 0; _Dbl_NC6 = 0; _Dbl_NC7 = 0; _Dbl_NC8 = 0; _Dbl_NC9 = 0; _Dbl_NC10 = 0;
            //    if (Convert.ToString(_DRow["sum_cmontodeefectivo"]).Length > 0)
            //    {
            //        _Dbl_MontoCObrado = Convert.ToDouble(_DRow["sum_cmontodeefectivo"]);
            //    }
            //    if (Convert.ToString(_DRow["csaldofactura"]).Length > 0)
            //    {
            //        _Dbl_SaldoCimp = Convert.ToDouble(_DRow["csaldofactura"]);
            //    }
            //    if (Convert.ToString(_DRow["csaldofacturasi"]).Length > 0)
            //    {
            //        _Dbl_SaldoSimp = Convert.ToDouble(_DRow["csaldofacturasi"]);
            //    }
            //    if (Convert.ToString(_DRow["cdesctopp"]).Length > 0)
            //    {
            //        _Dbl_DescPPPago = Convert.ToDouble(_DRow["cdesctopp"]);
            //    }
            //    if (Convert.ToString(_DRow["cdescto1"]).Length > 0)
            //    {
            //        _Dbl_Desc1 = Convert.ToDouble(_DRow["cdescto1"]);
            //    }
            //    if (Convert.ToString(_DRow["cdescto2"]).Length > 0)
            //    {
            //        _Dbl_Desc2 = Convert.ToDouble(_DRow["cdescto2"]);
            //    }
            //    _Str_NC1 = Convert.ToString(_DRow["cnotacred1"]);
            //    _Str_NC2 = Convert.ToString(_DRow["cnotacred2"]);
            //    _Str_NC3 = Convert.ToString(_DRow["cnotacred3"]);
            //    _Str_NC4 = Convert.ToString(_DRow["cnotacred4"]);
            //    _Str_NC5 = Convert.ToString(_DRow["cnotacred5"]);
            //    _Str_NC6 = Convert.ToString(_DRow["cnotacred6"]);
            //    _Str_NC7 = Convert.ToString(_DRow["cnotacred7"]);
            //    _Str_NC8 = Convert.ToString(_DRow["cnotacred8"]);
            //    _Str_NC9 = Convert.ToString(_DRow["cnotacred9"]);
            //    _Str_NC10 = Convert.ToString(_DRow["cnotacred10"]);
            //    _Str_Sql = "SELECT ctotaldocu FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc=" + _Str_NC1;
            //    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //    if (_Ds_A.Tables[0].Rows.Count > 0)
            //    {
            //        if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]).Length > 0)
            //        {
            //            _Dbl_NC1 = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
            //        }
            //    }
            //    _Str_Sql = "SELECT ctotaldocu FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc=" + _Str_NC2;
            //    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //    if (_Ds_A.Tables[0].Rows.Count > 0)
            //    {
            //        if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]).Length > 0)
            //        {
            //            _Dbl_NC2 = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
            //        }
            //    }
            //    _Str_Sql = "SELECT ctotaldocu FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc=" + _Str_NC3;
            //    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //    if (_Ds_A.Tables[0].Rows.Count > 0)
            //    {
            //        if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]).Length > 0)
            //        {
            //            _Dbl_NC3 = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
            //        }
            //    }
            //    _Str_Sql = "SELECT ctotaldocu FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc=" + _Str_NC4;
            //    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //    if (_Ds_A.Tables[0].Rows.Count > 0)
            //    {
            //        if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]).Length > 0)
            //        {
            //            _Dbl_NC4 = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
            //        }
            //    }
            //    _Str_Sql = "SELECT ctotaldocu FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc=" + _Str_NC5;
            //    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //    if (_Ds_A.Tables[0].Rows.Count > 0)
            //    {
            //        if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]).Length > 0)
            //        {
            //            _Dbl_NC5 = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
            //        }
            //    }
            //    _Str_Sql = "SELECT ctotaldocu FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc=" + _Str_NC6;
            //    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //    if (_Ds_A.Tables[0].Rows.Count > 0)
            //    {
            //        if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]).Length > 0)
            //        {
            //            _Dbl_NC6 = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
            //        }
            //    }
            //    _Str_Sql = "SELECT ctotaldocu FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc=" + _Str_NC7;
            //    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //    if (_Ds_A.Tables[0].Rows.Count > 0)
            //    {
            //        if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]).Length > 0)
            //        {
            //            _Dbl_NC7 = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
            //        }
            //    }
            //    _Str_Sql = "SELECT ctotaldocu FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc=" + _Str_NC8;
            //    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //    if (_Ds_A.Tables[0].Rows.Count > 0)
            //    {
            //        if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]).Length > 0)
            //        {
            //            _Dbl_NC8 = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
            //        }
            //    }
            //    _Str_Sql = "SELECT ctotaldocu FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc=" + _Str_NC9;
            //    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //    if (_Ds_A.Tables[0].Rows.Count > 0)
            //    {
            //        if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]).Length > 0)
            //        {
            //            _Dbl_NC9 = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
            //        }
            //    }
            //    _Str_Sql = "SELECT ctotaldocu FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc=" + _Str_NC10;
            //    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //    if (_Ds_A.Tables[0].Rows.Count > 0)
            //    {
            //        if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]).Length > 0)
            //        {
            //            _Dbl_NC10 = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
            //        }
            //    }
            //    _Dbl_MontoTotCob = _Dbl_MontoCObrado + _Dbl_Desc1 + _Dbl_Desc2 + _Dbl_DescPPPago + _Dbl_NC1 + _Dbl_NC2 + _Dbl_NC3 + _Dbl_NC4 + _Dbl_NC5 + _Dbl_NC6 + _Dbl_NC7 + _Dbl_NC8 + _Dbl_NC9 + _Dbl_NC10;
            //    _Dbl_Porc = (_Dbl_MontoTotCob / _Dbl_SaldoCimp) * 100;
            //    _Dbl_MontoTotCobSimp = (_Dbl_SaldoSimp * _Dbl_Porc) / 100;
            //    _Dbl_IVA = _Dbl_MontoTotCob - _Dbl_MontoTotCobSimp;
            //}
            //if (_Dbl_IVA != 0)
            //{
            //    _Dbl_MontoTotal = _Dbl_MontoTotal + _Dbl_IVA;
            //    _Int_corder++;
            //    _Str_CadAux = _Str_ccuentaivaName + " SEGUN CAJA " + _P_Str_Caja;
            //    _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
            //    _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccuentaiva + "','" + _Str_TpoDocCaja + "','" + _P_Str_Caja + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Txt_Fecha.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_IVA) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + _Str_CadAux + "')";
            //    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            //} 
            #endregion
            //SOBRANTE O FALTANTE EN CAJA
            _Dbl_Sobrante = _Mtd_ObtenerSobrante();
            if (_Dbl_Sobrante != 0)
            {
                //--------------------------
                _Str_Sql = "select cidrelacobro from TRELACCOBM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and ccaja='" + _P_Str_Caja + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    double _Dbl_Sobrante_Det = _Mtd_DeterminarSobrante(_Row[0].ToString());
                    if (_Dbl_Sobrante_Det != 0)
                    {
                        _Int_corder++;
                        _Str_CadAux = _Str_ccuentasobranfaltcajname + " SEGUN CAJA " + _P_Str_Caja + " RELACIÓN " + _Row[0].ToString();
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu," + (_Dbl_Sobrante_Det > 0 ? "ctothaber" : "ctotdebe") + ",cdateadd,cuseradd,cdescrip)";
                        _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccuentasobranfaltcaj + "','" + _Str_TpoDocCaja + "','" + _P_Str_Caja + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Txt_Fecha.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Sobrante_Det > 0 ? _Dbl_Sobrante_Det : _Dbl_Sobrante_Det * -1) + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + Frm_Padre._Str_Use + "','" + _Str_CadAux + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    }
                }
                //--------------------------
                if (_Dbl_Sobrante < 0)
                {
                    _Dbl_MontoTotal += (_Dbl_Sobrante) * -1;
                }
            }
            //CUENTA X COBRAR A CLIENTES
            _Int_corder++;
            _Dbl_MontoCxC = _Dbl_MontoTotal - (_Dbl_Sobrante < 0 ? 0 : _Dbl_Sobrante) - _Dbl_MontoEgreCheqDev;            
            _Str_CadAux = _Str_ccuentacxcName + " SEGUN CAJA " + _P_Str_Caja;
            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
            _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccuentacxc + "','" + _Str_TpoDocCaja + "','" + _P_Str_Caja + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Txt_Fecha.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoCxC) + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + Frm_Padre._Str_Use + "','" + _Str_CadAux + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            _Mtd_CxC_Auxiliar(_Str_cidcomprob, _Str_ccuentacxc, _Str_ccuentacxcName, _Str_ccuentacheqtransitoName, _P_Str_Caja, _Str_cmontacco, _Str_cyearacco);
            //------------------------
            _Str_Sql = "UPDATE TCOMPROBANC SET ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal) + "',cbalance='0' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            //------------------------
            //_Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) values ('";
            //_Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal) + "',0,'" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + Frm_Padre._Str_Use + "',0,'1')";
            return _Str_cidcomprob;
        }
        private bool _Mtd_ImprimirComprobante(string _Pr_Str_ComprobId)
        {
            bool _Bol_R = false;
             
            string _Str_Sql = "";
            A:
            PrintDialog _Print = new PrintDialog();
            if (_Print.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Pr_Str_ComprobId + "'", _Print, true);
                Cursor = Cursors.Default;
                if (MessageBox.Show("Se imprimió correctamente?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    _Str_Sql = "UPDATE TCOMPROBANC SET cstatus='1',clvalidado='1',cvalidate='" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Pr_Str_ComprobId + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    try
                    {
                        _Mtd_SaldarDocumentos();
                        _Bol_R = true;
                    }
                    catch (Exception _Ex)
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("Problemas al Saldar los documentos. " + _Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _Bol_R = false;
                    }
                    Cursor = Cursors.Default;
                }
                else
                {
                    goto A;
                }
            }
            return _Bol_R;
        }
        private void _Mtd_SaldarDocumentos()
        {
            System.Data.SqlClient.SqlParameter[] paramsToStore = new System.Data.SqlClient.SqlParameter[4];
            paramsToStore[0] = new System.Data.SqlClient.SqlParameter("@groupcompany", SqlDbType.Int);
            paramsToStore[0].Value = Frm_Padre._Str_GroupComp;
            paramsToStore[1] = new System.Data.SqlClient.SqlParameter("@company", SqlDbType.VarChar);
            paramsToStore[1].Value = Frm_Padre._Str_Comp;
            paramsToStore[2] = new System.Data.SqlClient.SqlParameter("@caja", SqlDbType.VarChar);
            paramsToStore[2].Value = _Txt_Caja.Text;
            paramsToStore[3] = new System.Data.SqlClient.SqlParameter("@user", SqlDbType.VarChar);
            paramsToStore[3].Value = Frm_Padre._Str_Use.Trim();
            CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("SP_SALDARDOCUMENTOS_CAJA", paramsToStore);
        }
        private void _Mtd_Generar_NC_Descpppago()
        {
            System.Data.SqlClient.SqlParameter[] paramsToStore = new System.Data.SqlClient.SqlParameter[4];
            paramsToStore[0] = new System.Data.SqlClient.SqlParameter("@groupcompany", SqlDbType.Int);
            paramsToStore[0].Value = Frm_Padre._Str_GroupComp;
            paramsToStore[1] = new System.Data.SqlClient.SqlParameter("@company", SqlDbType.VarChar);
            paramsToStore[1].Value = Frm_Padre._Str_Comp;
            paramsToStore[2] = new System.Data.SqlClient.SqlParameter("@caja", SqlDbType.VarChar);
            paramsToStore[2].Value = _Txt_Caja.Text;
            paramsToStore[3] = new System.Data.SqlClient.SqlParameter("@user", SqlDbType.VarChar);
            paramsToStore[3].Value = Frm_Padre._Str_Use.Trim();
            CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("SP_NC_DESCPPPAGO_CAJA", paramsToStore);
        }
        private void _Mtd_Generar_NC_OtroDesc()
        {
            System.Data.SqlClient.SqlParameter[] paramsToStore = new System.Data.SqlClient.SqlParameter[4];
            paramsToStore[0] = new System.Data.SqlClient.SqlParameter("@groupcompany", SqlDbType.Int);
            paramsToStore[0].Value = Frm_Padre._Str_GroupComp;
            paramsToStore[1] = new System.Data.SqlClient.SqlParameter("@company", SqlDbType.VarChar);
            paramsToStore[1].Value = Frm_Padre._Str_Comp;
            paramsToStore[2] = new System.Data.SqlClient.SqlParameter("@caja", SqlDbType.VarChar);
            paramsToStore[2].Value = _Txt_Caja.Text;
            paramsToStore[3] = new System.Data.SqlClient.SqlParameter("@user", SqlDbType.VarChar);
            paramsToStore[3].Value = Frm_Padre._Str_Use.Trim();
            CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("SP_NC_OTROSDESC_CAJA", paramsToStore);
        }
        private bool _Mtd_VerificarNCporImpr()
        {
            string _Str_Cadena = "SELECT ((Select count(*) from TNOTACREDICC where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cimpresa='0' and cactivo='0' AND cestatusfirma=2 AND (cidnotrecepc=0 or cidnotrecepc is null)) + " +
"(Select count(*) from TNOTACREDICC INNER JOIN TNOTARECEPC ON TNOTACREDICC.ccompany=TNOTARECEPC.ccompany AND TNOTACREDICC.cgroupcomp=TNOTARECEPC.cgroupcomp AND TNOTACREDICC.cidnotrecepc=TNOTARECEPC.cidnotrecepc where TNOTACREDICC.cdelete='0' and TNOTACREDICC.ccompany='" + Frm_Padre._Str_Comp + "' and TNOTACREDICC.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TNOTACREDICC.cimpresa='0' and TNOTACREDICC.cactivo='0' and TNOTARECEPC.cimpreso=1))";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    if (Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString()) > 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void _Btn_CajaCerrar_Click(object sender, EventArgs e)
        {
            //if (_Mtd_VerificarNCporImpr())
            //{
                if (_G_Bol_SwCierreCaja)
                {
                    if (!_G_Bol_SwCheDevuelto)
                    {
                        MessageBox.Show("No se puede cerrar la caja porque el total de cheques devueltos no cuadra con el análisis del saldo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (!_G_Bol_SwCheTransito)
                    {
                        MessageBox.Show("No se puede cerrar la caja porque el total de cheques en tránsito no cuadra con el análisis del saldo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    var _Bol_Cerrar = false;
                    double _Dbl_Sobrante = _Mtd_ObtenerSobrante();
                    if (_Dbl_Sobrante == 0)
                    { _Bol_Cerrar = true; }
                    else if (_Dbl_Sobrante > 0 && new Frm_MessageBox("Existe un sobrante de " + _Dbl_Sobrante.ToString("#,##0.00") + " Bs. ¿Esta seguro de continuar?", "Advertencia: Sobrante de " + _Dbl_Sobrante.ToString("#,##0.00") + " Bs", SystemIcons.Warning, 5).ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                        _Bol_Cerrar = true;
                    else if (_Dbl_Sobrante < 0 && new Frm_MessageBox("Existe un faltante de " + _Dbl_Sobrante.ToString("#,##0.00") + " Bs. ¿Esta seguro de continuar?", "Advertencia: Faltante de " + _Dbl_Sobrante.ToString("#,##0.00") + " Bs", SystemIcons.Warning, 5).ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                        _Bol_Cerrar = true;
                    if (_Bol_Cerrar)
                    {
                        _Pnl_Clave.Parent = this;
                        _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                        _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
                        _Pnl_Clave.BringToFront();
                        _Pnl_Clave.Visible = true;
                        _Txt_Clave.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("No se puede cerrar la caja porque no cuadra.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            //}
            //else
            //{
            //    MessageBox.Show("No se puede cerrar la caja porque hay notas de crédito pendientes por imprimir", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Close();
            //}
        }
        private void _Mtd_HistoricoSaldoCaja()
        {
            try
            {
                string _Str_SentenciaSQL = "INSERT INTO TSALDOCARTERAHISTORICOCAJA ([cgroupcomp],[ccompany],[CCAJA],[cfechacierre],[ccliente],[c_rif],[c_nit],[c_nomb_comer],[ctipodocument],[cnumdocu],[cfechafact],[cfechaentrega],[cfpago],[cfpago_name],[cdias],[cfelimitcobro],[cmontofactci],[cmontofactsi],[csaldofactura],[csaldofacturasi],[cdiasvencfact],[cdescppago],[cactivo],[cdelete],[cvendedor],[tipodoc_complet],[por_vencer],[hasta15],[hasta30],[hasta45],[hastamas45],[por_vencer_si],[hasta15_si],[hasta30_si],[hasta45_si],[hastamas45_si],[dias_vence],[ccodlimite],[ccodlimite_descrip],[climtedesde],[climtehasta],[vendedor_name],[vendedor_descrip],[fact_entregadas_ci],[fact_entregadas_si],[fact_porentregar_ci],[fact_porentregar_si],[fact_total_ci],[fact_total_si],[nd_ci],[nd_si],[cheq_devueltos],[cheq_postergados],[nc_ci],[nc_si])";
                _Str_SentenciaSQL += " SELECT [cgroupcomp],[ccompany],'" + _Txt_Caja.Text.Trim() + "',GETDATE(),[ccliente],[c_rif],[c_nit],[c_nomb_comer],[ctipodocument],[cnumdocu],[cfechafact],[cfechaentrega],[cfpago],[cfpago_name],[cdias],[cfelimitcobro],[cmontofactci],[cmontofactsi],[csaldofactura],[csaldofacturasi],[cdiasvencfact],[cdescppago],[cactivo],[cdelete],[cvendedor],[tipodoc_complet],[por_vencer],[hasta15],[hasta30],[hasta45],[hastamas45],[por_vencer_si],[hasta15_si],[hasta30_si],[hasta45_si],[hastamas45_si],[dias_vence],[ccodlimite],[ccodlimite_descrip],[climtedesde],[climtehasta],[vendedor_name],[vendedor_descrip],[fact_entregadas_ci],[fact_entregadas_si],[fact_porentregar_ci],[fact_porentregar_si],[fact_total_ci],[fact_total_si],[nd_ci],[nd_si],[cheq_devueltos],[cheq_postergados],[nc_ci],[nc_si] FROM VST_SALDOS_ALLDOCS_DEMO";
                _Str_SentenciaSQL += " WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
            }
            catch
            {
            }
        }
        private void _Bt_Aceptar_Clave_Click(object sender, EventArgs e)
        {
            if (_Txt_Clave.Text.Trim() != "")
            {
                if (_MyUtilidad._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
                {
                    bool _Bol_ConRelaciones = true;
                    string _Str_Sql = "SELECT * FROM TRELACCOBM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND caprobado=1 AND cdelete=0";
                    _Bol_ConRelaciones = Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql);
                    _Pnl_Clave.Visible = false;
                    _Bt_CobDetallada.Enabled = false;
                    _Btn_CajaCerrar.Enabled = false;
                    Cursor = Cursors.WaitCursor;
                    _Str_Sql = "SELECT CAST(dbo.FNC_RELCOB_INGRESO(" + Frm_Padre._Str_GroupComp + ",'" + Frm_Padre._Str_Comp + "','" + _Txt_Caja.Text + "') AS NUMERIC(18,2)) AS ingresos, CAST(dbo.FNC_RELCOB_EGRESO(" + Frm_Padre._Str_GroupComp + ",'" + Frm_Padre._Str_Comp + "','" + _Txt_Caja.Text + "','" + _Txt_Caja.Text + "') AS NUMERIC(18,2)) as egresos,CAST(dbo.FNC_RELCOB_SALDO(" + Frm_Padre._Str_GroupComp + ",'" + Frm_Padre._Str_Comp + "','" + _Txt_Caja.Text + "','" + _Txt_Caja.Text + "') AS NUMERIC(18,2)) as saldo";
                    DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    Cursor = Cursors.Default;
                    double _Dbl_Saldo = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][2]);
                    double _Dbl_Ingreso = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
                    double _Dbl_Egreso = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][1]);
                    double _Dbl_Sobrante = _Mtd_ObtenerSobrante();
                    _Dbl_Saldo = _Dbl_Saldo + _Dbl_Sobrante;
                    string _Str_Comprob = "";
                    if (_Bol_ConRelaciones)
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            _Str_Comprob = _Mtd_CrearCompropCont(_Txt_Caja.Text.Trim());
                            Cursor = Cursors.Default;
                        }
                        catch (Exception _Ex)
                        {
                            MessageBox.Show("Problemas al crear el comprobante contable. " + _Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (_Str_Comprob.Length > 0)
                            {
                                _Str_Sql = "DELETE FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Comprob + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                _Str_Sql = "DELETE FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Comprob + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                _Str_Sql = "DELETE FROM TCOMPROBANDD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Comprob + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                _Str_Sql = "DELETE FROM TMOVAUXILIARCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Comprob + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            }
                            _Str_Comprob = "";
                            _Bt_CobDetallada.Enabled = true;
                            _Btn_CajaCerrar.Enabled = true;
                        }
                    if (!_Bol_ConRelaciones || _Str_Comprob.Length > 0)
                    {
                        try
                        {
                            _MyUtilidad._Mtd_IniciarBackupBD(this, "CAJ");
                        }
                        catch { MessageBox.Show("Error al intentar crear el respaldo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        if (!_Bol_ConRelaciones || _Mtd_ImprimirComprobante(_Str_Comprob))
                        {
                            Cursor = Cursors.WaitCursor;
                            //----------
                            _Str_Sql = "SELECT cnumcheque,ccliente,cbancocheque FROM VST_TEGRECHEQGTRAN_RELCOB WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccaja IS NULL AND cimpreso=0";
                            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
                            {
                                _Str_Sql = "UPDATE TEGRECHEQTRAN SET ccaja='" + _Txt_Caja.Text + "',cimpreso=1 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cnumcheque='" + _Drow["cnumcheque"].ToString() + "' AND ccliente='" + _Drow["ccliente"].ToString() + "' AND cbancocheque='" + _Drow["cbancocheque"].ToString() + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            }
                            //----------

                            //INSERTAR RETENCIONES CXC

                            _Str_Sql = "EXEC PA_T3_INSERTAR_RETENCIONES '" + _Txt_Caja.Text + "','" + Frm_Padre._Str_Comp + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);

                            //--------------

                            _Str_Sql = "UPDATE TCAJACXC SET ccerrada=1,csaldoactual=" + _Dbl_Saldo.ToString().Replace(",", ".") + ",cingresos=" + _Dbl_Ingreso.ToString().Replace(",", ".") + ",cegresos=" + _Dbl_Egreso.ToString().Replace(",", ".") + ",csobrante=" + _Dbl_Sobrante.ToString().Replace(",", ".") + ",ccheqdev_saldoact=" + _G_Dbl_TotalCheqDev.ToString().Replace(",", ".") + ",ccheqtrans_saldoact=" + _G_Dbl_TotalCheqT.ToString().Replace(",", ".") + ",cfechacierre='" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',choracierre=GETDATE(),cusercierre='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text.Trim() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            _Str_Sql = "UPDATE TCHEQDEVUELT SET ccaja='" + _Txt_Caja.Text.Trim() + "',cuserupd='" + Frm_Padre._Str_Use + "',cdateupd='" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cactivo=1 and cdelete=0 and ccaja is null";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            //----------
                            Cursor = Cursors.Default;
                            try
                            {
                                Cursor = Cursors.WaitCursor;
                                _Mtd_Generar_NC_Descpppago();
                                Cursor = Cursors.Default;
                            }
                            catch
                            {
                                MessageBox.Show("Problemas al crear las NC por Descuentos por pronto pago", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            try
                            {
                                Cursor = Cursors.WaitCursor;
                                _Mtd_Generar_NC_OtroDesc();
                                Cursor = Cursors.Default;
                            }
                            catch
                            {
                                MessageBox.Show("Problemas al crear las NC por Otros descuentos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            //------------------------
                            Thread _Thr_Thread = new Thread(new ThreadStart(_Mtd_EjecutarMovCobran));
                            _Thr_Thread.Start();
                            while (!_Thr_Thread.IsAlive) ;
                            Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread, "Espere por favor...");
                            _Frm_Form.ShowDialog(this);
                            _Frm_Form.Dispose();
                            //------------------------
                            Cursor = Cursors.WaitCursor;
                            _Str_Sql = "UPDATE TCAJACXC SET ccerrando='0',cipcierre='" + _Mtd_ObtenerIP() + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text.Trim() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);

                            _Mtd_HistoricoSaldoCaja();

                            Cursor = Cursors.Default;
                            //------------------------
                            if ((Frm_Padre)this.MdiParent != null)
                            {
                                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                            }
                            MessageBox.Show("Se cerró la caja correctamente. A continuación se van a imprimir los reportes asociados a esta caja.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PrintDialog _Print = new PrintDialog();
                            REPORTESS _Frm;
                            //------------------------
                            try
                            {
                                Cursor = Cursors.WaitCursor;
                                _Str_Sql = "SELECT ccaja FROM VST_TEGRECHEQTRAN WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' and cdelete=0";
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                Cursor = Cursors.Default;
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show("Se va a proceder a imprimir el reporte de egreso de cheques en tránsito. Coloque el tipo de papel para este documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _Lbl_Prin:
                                    if (_Print.ShowDialog() == DialogResult.OK)
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        _Frm = new REPORTESS(new string[] { "VST_TEGRECHEQTRAN" }, "", "T3.Report.rEgreCheqTrans", "Section1", "cabecera", "rif", "nit", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' and cdelete=0", _Print, true);
                                        Cursor = Cursors.Default;
                                        if (MessageBox.Show("Se imprimió correctamente el reporte de egreso de cheques en tránsito?", "Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                        {
                                            GC.Collect();
                                            goto _Lbl_Prin;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Puede imprimirlo desde 'Informes - Caja' en el menú 'Ctas por Cobrar'.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            catch (Exception _Ex)
                            {
                                Cursor = Cursors.Default;
                                MessageBox.Show("Problemas al imprimir el reporte de egreso de cheques en tránsito.\nPuede imprimirlo desde 'Informes - Caja' en el menú 'Ctas por Cobrar'.\n" + _Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            //------------------------
                            try
                            {
                                Cursor = Cursors.WaitCursor;
                                _Str_Sql = "SELECT ccaja FROM VST_CAJA_INGCHEQTRANS WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' and (cegresotransito=0 OR cegresotransito IS NULL) AND caprobado=1";
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                Cursor = Cursors.Default;
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show("Se va a imprimir el reporte de ingresos de cheques en tránsito. Coloque el tipo de papel para este documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _Lbl_Prin:
                                    if (_Print.ShowDialog() == DialogResult.OK)
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        _Frm = new REPORTESS(new string[] { "VST_CAJA_INGCHEQTRANS" }, "", "T3.Report.rCajaIngCheqT", "Section1", "cabecera", "rif", "nit", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' and (cegresotransito=0 OR cegresotransito IS NULL) AND caprobado=1", _Print, true);
                                        Cursor = Cursors.Default;
                                        if (MessageBox.Show("Se imprimió correctamente el reporte de ingresos de cheques en tránsito?", "Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                        {
                                            GC.Collect();
                                            goto _Lbl_Prin;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Puede imprimirlo desde 'Informes - Caja' en el menú 'Ctas por Cobrar'.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            catch (Exception _Ex)
                            {
                                Cursor = Cursors.Default;
                                MessageBox.Show("Problemas al imprimir el reporte de ingresos de cheques en tránsito.\nPuede imprimirlo desde 'Informes - Caja' en el menú 'Ctas por Cobrar'.\n" + _Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            //------------------------
                            try
                            {
                                Cursor = Cursors.WaitCursor;
                                string _Str_TipoFact = _MyUtilidad._Mtd_TipoDocument_CXC("ctipdocfact");
                                string _Str_TipoNd = _MyUtilidad._Mtd_TipoDocument_CXC("ctipdocnotdeb");
                                _Str_Sql = "SELECT ccaja FROM VST_INF_RETENCIONIVA WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND (ctipodocument='" + _Str_TipoFact + "' OR  ctipodocument='" + _Str_TipoNd + "')";
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                Cursor = Cursors.Default;
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show("Se va a imprimir el listado retenciones de iva. Coloque el tipo de papel para este documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _Lbl_Prin:
                                    if (_Print.ShowDialog() == DialogResult.OK)
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        _Frm = new REPORTESS(new string[] { "VST_INF_RETENCIONIVA" }, "", "T3.Report.rInfRetencionIva", "Section1", "cabecera", "rif", "nit", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND (ctipodocument='" + _Str_TipoFact + "' OR  ctipodocument='" + _Str_TipoNd + "')", _Print, true);
                                        Cursor = Cursors.Default;
                                        if (MessageBox.Show("Se imprimió correctamente el listado retenciones de iva?", "Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                        {
                                            GC.Collect();
                                            goto _Lbl_Prin;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Puede imprimirlo desde 'Informes - Caja' en el menú 'Ctas por Cobrar'.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            catch (Exception _Ex)
                            {
                                Cursor = Cursors.Default;
                                MessageBox.Show("Problemas al imprimir el listado retenciones de iva.\nPuede imprimirlo desde 'Informes - Caja' en el menú 'Ctas por Cobrar'.\n" + _Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            //------------------------
                            try
                            {
                                Cursor = Cursors.WaitCursor;
                                _Str_Sql = "SELECT ccaja FROM VST_CAJA_NC_APLICADAS_RPT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "'";
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                Cursor = Cursors.Default;
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show("Se va a imprimir el reporte de N.C. aplicadas en la caja.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _Lbl_Prin:
                                    if (_Print.ShowDialog() == DialogResult.OK)
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        _Frm = new REPORTESS(new string[] { "VST_CAJA_NC_APLICADAS_RPT" }, "", "T3.Report.rCajaNC", "Section1", "cabecera", "rif", "nit", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "'", _Print, true);
                                        Cursor = Cursors.Default;
                                        if (MessageBox.Show("Se imprimió correctamente el reporte de N.C. aplicadas en la caja.?", "Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                        {
                                            GC.Collect();
                                            goto _Lbl_Prin;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Puede imprimirlo desde 'Informes - Caja' en el menú 'Ctas por Cobrar'.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            catch (Exception _Ex)
                            {
                                Cursor = Cursors.Default;
                                MessageBox.Show("Problemas al imprimir el reporte de N.C. aplicadas en la caja.\nPuede imprimirlo desde 'Informes - Caja' en el menú 'Ctas por Cobrar'.\n" + _Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            //------------------------
                            Cursor = Cursors.WaitCursor;
                            _Str_Sql = "SELECT cidnotcredicc FROM TNOTACREDICC WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany = '" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND cimpresa = '0' AND cactivo = '0' AND cestatusfirma=3 AND cdescuenpp=1";
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            Cursor = Cursors.Default;
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show("Se va a proceder a imprimir las N.C. generadas por el cierre de la Caja.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Cursor = Cursors.WaitCursor;
                                Frm_ImpresionLote _Frm_Imp = new Frm_ImpresionLote(8, _Txt_Caja.Text);
                                Cursor = Cursors.Default;
                                _Frm_Imp.MdiParent = this.MdiParent;
                                _Frm_Imp.Dock = DockStyle.Fill;
                                _Frm_Imp.Show();
                            }
                            //------------------------
                            _Bol_CajaCerrada = true;
                            this.Close();
                        }
                        else
                        {
                            _Bt_CobDetallada.Enabled = true;
                            _Btn_CajaCerrar.Enabled = true;
                        }
                    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("La caja no puede ser cerrada sin tener relaciones de cobranzas.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    _Pnl_Clave.Visible = false;
                    //}

                }
                else
                {
                    MessageBox.Show("Clave incorrecta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _Txt_Clave.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Ingrese su clave.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool _Mtd_VerificarRelaciones()
        {
            try
            {
                string _Str_RelPorDescargar = "";
                string _Str_RelDescargadas = "";
                string _Str_Cadena = "SELECT COUNT(cgroupcomp) FROM TRELACCOBM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND  ccaja='" + _Txt_Caja.Text.Trim() + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                    {
                        _Str_RelPorDescargar = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                    }
                }
                _Str_Cadena = "SELECT COUNT(cgroupcomp) FROM T3TRELACCOBM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text.Trim() + "' OR (cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and crelalista='1' and caprobado='1' and ccaja is null)";
                _Ds = Program._MyClsCnn._mtd_conexionSQL2012._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                    {
                        _Str_RelDescargadas = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                    }
                }
                //if (_Str_RelPorDescargar.Trim().Length == "0") { _Str_RelPorDescargar = "0"; }
                //if (_Str_RelDescargada.Trim().Length == "0") { _Str_RelDescargada = "0"; }
                return _Str_RelPorDescargar.Trim() == _Str_RelDescargadas.Trim();
            }
            catch
            {
                MessageBox.Show("Error en la conexion. No se puede completar el proceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool _Mtd_VerificarRelaciones(bool _P_Bol_Detalle)
        {
            try
            {
                int _Int_Relaciones_Win = 0;
                int _Int_Relaciones_Web = 0;
                string _Str_Cadena = "PA_VERIF_DETAL_RELC '" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Txt_Caja.Text.Trim() + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                    {
                        _Int_Relaciones_Win = Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString().Trim());
                    }
                }
                _Str_Cadena = "PA_VERIF_DETAL_RELC '" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Txt_Caja.Text.Trim() + "'";
                _Ds = Program._MyClsCnn._mtd_conexionSQL2012._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                    {
                        _Int_Relaciones_Web = Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString().Trim());
                    }
                }
                return _Int_Relaciones_Win == _Int_Relaciones_Web;
            }
            catch
            {
                MessageBox.Show("Error en la conexion. No se puede completar el proceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void Frm_ConsultaCajaAbierta_Load(object sender, EventArgs e)
        {
            _Txt_Caja.Enabled = false;
            _Txt_Fecha.Enabled = false;
            this.Dock = DockStyle.Fill;
            _Pnl_Pregunta.Left = (this.Width / 2) - (_Pnl_Pregunta.Width / 2);
            _Pnl_Pregunta.Top = (this.Height / 2) - (_Pnl_Pregunta.Height / 2);
            _Pnl_Pregunta.Visible = true;
        }

        private void _Bt_Cancelar_Clave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Pnl_InfGen.Enabled = false; _Pnl_Inferior.Enabled = false; _CRptV_A.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Pnl_InfGen.Enabled = true; _Pnl_Inferior.Enabled = true; _CRptV_A.Enabled = true; }
        }

        private double _Mtd_ObtenerTotalCheqTransitoDoc()
        {
            double _Dbl_R = 0;
            DataSet _Ds_A;
            string _Str_Sql = "SELECT cidrelacobro FROM TRELACCOBM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND cdelete=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Str_Sql = "SELECT SUM(cmontodeefectivo) FROM TRELACCOBDD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrelacobro='" + _Drow[0].ToString() + "' AND ctipocancelado=2";
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) != "")
                    {
                        _Dbl_R = _Dbl_R + Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
                    }
                }
            }
            return _Dbl_R;
        }
        private double _Mtd_ObtenerTotalDepositosDoc()
        {
            double _Dbl_R = 0;
            DataSet _Ds_A;
            string _Str_Sql = "SELECT cidrelacobro FROM TRELACCOBM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND cdelete=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Str_Sql = "SELECT SUM(cmontodeefectivo) FROM TRELACCOBDD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrelacobro='" + _Drow[0].ToString() + "' AND ctipocancelado=1";
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) != "")
                    {
                        _Dbl_R = _Dbl_R + Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
                    }
                }
            }
            return _Dbl_R;
        }
        private double _Mtd_ObtenerTotalTransfBancariaDoc()
        {
            double _Dbl_R = 0;
            DataSet _Ds_A;
            string _Str_Sql = "SELECT cidrelacobro FROM TRELACCOBM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND cdelete=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Str_Sql = "SELECT SUM(cmontodeefectivo) FROM TRELACCOBDD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrelacobro='" + _Drow[0].ToString() + "' AND ctipocancelado=4";
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) != "")
                    {
                        _Dbl_R = _Dbl_R + Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
                    }
                }
            }
            return _Dbl_R;
        }
        private double _Mtd_ObtenerTotalCreditCardDoc()
        {
            double _Dbl_R = 0;
            DataSet _Ds_A;
            string _Str_Sql = "SELECT cidrelacobro FROM TRELACCOBM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND cdelete=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Str_Sql = "SELECT SUM(cmontodeefectivo) FROM TRELACCOBDD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrelacobro='" + _Drow[0].ToString() + "' AND ctipocancelado=3";
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) != "")
                    {
                        _Dbl_R = _Dbl_R + Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
                    }
                }
            }
            return _Dbl_R;
        }
        private double _Mtd_ObtenerTotalDoc()
        {
            double _Dbl_Monto = 0;
            _Dbl_Monto = _Mtd_ObtenerTotalCheqTransitoDoc() + _Mtd_ObtenerTotalDepositosDoc() + _Mtd_ObtenerTotalTransfBancariaDoc() + _Mtd_ObtenerTotalCreditCardDoc();
            return _Dbl_Monto;
        }
        private double _Mtd_ObtenerTotalCheqTransitoCob()
        {
            double _Dbl_R = 0;
            DataSet _Ds_A;
            string _Str_Sql = "SELECT cidrelacobro FROM TRELACCOBM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND cdelete=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Str_Sql = "SELECT SUM(cmontocheq) FROM TRELACCOBDCHEQ WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrelacobro='" + _Drow[0].ToString() + "' AND cdelete=0";
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) != "")
                    {
                        _Dbl_R = _Dbl_R + Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
                    }
                }
            }
            return _Dbl_R;
        }
        private double _Mtd_ObtenerTotalDepositosCob()
        {
            double _Dbl_R = 0;
            DataSet _Ds_A;
            string _Str_Sql = "SELECT cidrelacobro FROM TRELACCOBM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND cdelete=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Str_Sql = "SELECT SUM(cmontodepo) FROM TRELACCOBDDEPM WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrelacobro='" + _Drow[0].ToString() + "' AND cdelete=0";
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) != "")
                    {
                        _Dbl_R = _Dbl_R + Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
                    }
                }
            }
            return _Dbl_R;
        }
        private double _Mtd_ObtenerTotalTransfBancariaCob()
        {
            double _Dbl_R = 0;
            DataSet _Ds_A;
            string _Str_Sql = "SELECT cidrelacobro FROM TRELACCOBM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND cdelete=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Str_Sql = "SELECT SUM(cmontotransacc) FROM TRELACCOBDTB WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcompany='" + Frm_Padre._Str_GroupComp + "' AND cidrelacobro='" + _Drow[0].ToString() + "' AND cdelete=0";
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) != "")
                    {
                        _Dbl_R = _Dbl_R + Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
                    }
                }
            }
            return _Dbl_R;
        }
        private double _Mtd_ObtenerTotalCreditCardCob()
        {
            double _Dbl_R = 0;
            DataSet _Ds_A;
            string _Str_Sql = "SELECT cidrelacobro FROM TRELACCOBM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text + "' AND cdelete=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Str_Sql = "SELECT SUM(cmontocancel) FROM TRELACCOBDTC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcompany='" + Frm_Padre._Str_GroupComp + "' AND cidrelacobro='" + _Drow[0].ToString() + "' AND cdelete=0";
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) != "")
                    {
                        _Dbl_R = _Dbl_R + Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
                    }
                }
            }
            return _Dbl_R;
        }
        private double _Mtd_ObtenerTotalCob()
        {
            double _Dbl_Monto = 0;
            _Dbl_Monto = _Mtd_ObtenerTotalCheqTransitoCob() + _Mtd_ObtenerTotalDepositosCob() + _Mtd_ObtenerTotalTransfBancariaCob() + _Mtd_ObtenerTotalCreditCardCob();
            return _Dbl_Monto;
        }
        double _Dbl_ObtenerSobrante = 0;
        private void _Mtd_DeterminarSobrante()
        {
            string _Str_Cadena = "EXEC PA_CAJ_OBTENERSOBRANTE '" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "','" + _Txt_Caja.Text + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dbl_ObtenerSobrante = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
        }
        private double _Mtd_DeterminarSobrante(string _P_Str_IdRelaCobro)
        {
            string _Str_Cadena = "EXEC PA_CAJ_OBTENERSOBRANTE_DET '" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "','" + _Txt_Caja.Text + "','" + _P_Str_IdRelaCobro + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
        }
        private double _Mtd_ObtenerSobrante()
        {
            //double _Dbl_MontoTotalDoc = _Mtd_ObtenerTotalDoc();//MONTO RELACIONADO(COBRADO)
            //double _Dbl_MontoTotalCob = _Mtd_ObtenerTotalCob();//MONTO DE LOS DOCUMENTOS
            //double _Dbl_Monto = 0;
            //_Dbl_Monto = _Dbl_MontoTotalCob - _Dbl_MontoTotalDoc;
            double _Dbl_Monto = _Dbl_ObtenerSobrante;
            return _Dbl_Monto;
        }
        private void _Mtd_EjecutarMovCobran()
        {
            string _Str_Cadena = "EXEC PA_MOVIMIENTOCOBRANZA '" + Frm_Padre._Str_Comp + "','" + _Txt_Caja.Text + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private void _Bt_CobDetallada_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //string _Str_Sql = "ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcompany='" + Frm_Padre._Str_GroupComp + "' AND ccaja=" + _Txt_Caja.Text + " ORDER BY cidrelacobro";
            string _Str_Sql = _Str_Sql = "EXEC PA_CAJ_COBRAN_DETALLADA '" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "','" + _Txt_Caja.Text + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            REPORTESS _Frm = new REPORTESS("T3.Report.rCajaCobDet", _Ds.Tables[0], "Section2", "cabecera", "rif", "nit");
            //REPORTESS _Frm = new REPORTESS(new string[] { "VST_CAJA_DET_RPT" }, _Ds.Tables[0], "T3.Report.rCajaCobDet", "Section2", "cabecera", "rif", "nit", _Str_Sql);
            _Frm.MdiParent = this.MdiParent;
            _Frm.Show();
            this.Cursor = Cursors.Default;
        }
        bool _Bol_CajaCerrada = false;
        private void Frm_ConsultaCajaAbierta_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (_Rb_Cerrar.Checked & _MyReport != null)
            //{
            //    if (!_Bol_CajaCerrada)
            //    {
            //        string _Str_Cadena = "UPDATE TCAJACXC SET ccerrando='0',cipcierre=null WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text.Trim() + "'";
            //        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            //    }
            //}
            //if (_MyReport != null)
            //{
            //    _MyReport.Close();
            //    _MyReport.Dispose();
            //    _MyReport = null;
            //}
        }

        private double _Mtd_CheqDev_Ingresados()
        {
            double _Dbl_R = 0;
            string _Str_CheqDev = "";
            string _Str_DocFact = "";
            string _Str_Sql = "SELECT * FROM VST_CONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_CheqDev = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdoccheqdev"]);
                _Str_DocFact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]);
            }
            _Str_Sql = "SELECT SUM(cmontocheq) FROM dbo.TCHEQDEVUELT where not ccaja is null and ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cactivo=1 and cdelete=0";
            //_Str_Sql = "SELECT SUM(dbo.TRELACCOBD.cmontocancel) " +
            //"FROM dbo.TRELACCOBM INNER JOIN " +
            //"dbo.TRELACCOBD ON dbo.TRELACCOBM.ccompany = dbo.TRELACCOBD.ccompany AND " +
            //"dbo.TRELACCOBM.cgroupcomp = dbo.TRELACCOBD.cgroupcompany AND dbo.TRELACCOBM.cidrelacobro = dbo.TRELACCOBD.cidrelacobro " +
            //"WHERE (dbo.TRELACCOBM.ccaja = '0') AND  dbo.TRELACCOBD.ctipodocument='" + _Str_DocFact + "' and dbo.TRELACCOBM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TRELACCOBM.ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Length > 0)
                {
                    _Dbl_R = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                }
                else
                {
                    _Dbl_R = 0;
                }
                
            }
            return _Dbl_R;
        }
        private double _Mtd_ObtenerFaltanteReal()
        {
            string _Str_Cadena = "SELECT ISNULL(SUM(TTRCDOCUMENTO.cmontosaldo),0) FROM TRELACCOBM INNER JOIN " +
                        "TTRCDOCUMENTO ON TRELACCOBM.ccompany = TTRCDOCUMENTO.ccompany AND " +
                        "TRELACCOBM.cidrelacobro = TTRCDOCUMENTO.cidrelacion " +
                        "WHERE TRELACCOBM.ccompany='" + Frm_Padre._Str_Comp + "' AND TRELACCOBM.ccaja = '" + _Txt_Caja.Text + "'";
            DataSet _Ds=Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
            }
            return 0;
        }
        private double _Mtd_GetSaldoActual()
        {
            double _Dbl_Saldo = 0;
            double _Dbl_Sobrante = _Mtd_ObtenerSobrante();
            string _Str_Sql = "SELECT CAST(dbo.FNC_RELCOB_SALDO(" + Frm_Padre._Str_GroupComp + ",'" + Frm_Padre._Str_Comp + "','" + _Txt_Caja.Text + "','" + _Txt_Caja.Text + "') AS NUMERIC(18,2)) as saldo";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim().Length > 0)
                {
                    _Dbl_Saldo = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                }
            }
            _Dbl_Saldo = _Dbl_Saldo + _Dbl_Sobrante;
            _Dbl_Saldo = Math.Round(_Dbl_Saldo, 2);
            return _Dbl_Saldo;
        }
        
        private void _Pnl_Pregunta_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Pregunta.Visible)
            { _Pnl_InfGen.Enabled = false; _Pnl_Inferior.Enabled = false; _CRptV_A.Enabled = false; }
            else
            { _Pnl_InfGen.Enabled = true; _Pnl_Inferior.Enabled = true; _CRptV_A.Enabled = true; }
        }

        private void _Bt_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _Mtd_CerrarForms()
        {
            foreach (Form _Frm_Hijo in this.MdiParent.MdiChildren)
            {
                if (_Frm_Hijo.Name == "Frm_Navegador" | _Frm_Hijo.Name == "Frm_IngCheqDevuelto" | _Frm_Hijo.Name == "Frm_EgreCheqTrans")
                { _Frm_Hijo.Close(); }
            }
        }
        private string _Mtd_ObtenerIP()
        {
            //return Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString().Trim();
            string _Str_Host = System.Net.Dns.GetHostName();
            string _Str_IP = "";

            for (int i = 0; i <= System.Net.Dns.GetHostEntry(_Str_Host).AddressList.Length - 1; i++)
            {
                _Str_IP = System.Net.Dns.GetHostEntry(_Str_Host).AddressList[i].ToString();

                // primero evalua si existe un IP estandar de la red SODICA
                if (_Str_IP.IndexOf("192.168.0.") != -1) return _Str_IP; // denca
                if (_Str_IP.IndexOf("192.168.1.") != -1) return _Str_IP; // conssa
                if (_Str_IP.IndexOf("192.168.2.") != -1) return _Str_IP; // mcy
                if (_Str_IP.IndexOf("192.168.3.") != -1) return _Str_IP; // mcbo
                if (_Str_IP.IndexOf("192.168.4.") != -1) return _Str_IP; // scb
                if (_Str_IP.IndexOf("192.168.5.") != -1) return _Str_IP; // pzo
                if (_Str_IP.IndexOf("192.168.6.") != -1) return _Str_IP; // bna
                if (_Str_IP.IndexOf("192.168.7.") != -1) return _Str_IP; // val
                if (_Str_IP.IndexOf("192.168.8.") != -1) return _Str_IP; // bqto
                if (_Str_IP.IndexOf("192.168.9.") != -1) return _Str_IP; // ccs
                if (_Str_IP.IndexOf("192.168.10.") != -1) return _Str_IP; // bnas

                if (_Str_IP.IndexOf("192.168.11.") != -1) return _Str_IP; // ¿futuro?
                if (_Str_IP.IndexOf("192.168.12.") != -1) return _Str_IP; // ¿futuro?
                if (_Str_IP.IndexOf("192.168.13.") != -1) return _Str_IP; // ¿futuro?
                if (_Str_IP.IndexOf("192.168.14.") != -1) return _Str_IP; // ¿futuro?
                if (_Str_IP.IndexOf("192.168.15.") != -1) return _Str_IP; // ¿futuro?
            }

            // si no encuentra un IP estándar, entonces devuelve el primero que no sea IPV6
            for (int i = 0; i <= System.Net.Dns.GetHostEntry(_Str_Host).AddressList.Length - 1; i++)
            {
                if (System.Net.Dns.GetHostEntry(_Str_Host).AddressList[i].IsIPv6LinkLocal == false)
                {
                    _Str_IP = System.Net.Dns.GetHostEntry(_Str_Host).AddressList[i].ToString();
                }
            }

            return _Str_IP;
        }

        private bool _Mtd_VerificarCerrandoCaja()
        {
            string _Str_cadena = "SELECT ccerrando FROM TCAJACXC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccerrada='0' AND ccerrando='1' AND cipcierre<>'" + _Mtd_ObtenerIP() + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_EgresosSinComprobante()
        {
            string _Str_Cadena = "SELECT cidegrecheqtran FROM TEGRECHEQTRAN WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND (cidcomprob='0' OR (cidcomprob>0 AND EXISTS(SELECT cidcomprob FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob=TEGRECHEQTRAN.cidcomprob AND clvalidado='0')))";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Bt_AceptarP_Click(object sender, EventArgs e)
        {
            if (_Rb_Cerrar.Checked)
            {
                if (MessageBox.Show("¿Esta seguro de cerrar la caja " + _Txt_Caja.Text.Trim() + " ?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_Mtd_VerificarCerrandoCaja())
                    {
                        MessageBox.Show("La caja " + _Txt_Caja.Text.Trim() + " se esta cerrando en otro equipo.\nOtro usuario esta realizando el proceso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Rb_Cerrar.Checked = false;
                        this.Close();
                    }
                    else
                    {
                        if (!_Mtd_EgresosSinComprobante())
                        {
                            string _Str_Cadena = "UPDATE TCAJACXC SET ccerrando='1',cipcierre='" + _Mtd_ObtenerIP() + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text.Trim() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            _Pnl_Pregunta.Visible = false;
                            _Mtd_CerrarForms();
                            _Btn_CajaCerrar.Enabled = true;
                            try
                            {
                                Cursor = Cursors.WaitCursor;
                                _Mtd_DeterminarSobrante();
                                _Mtd_CargarReporteCaja();
                                Cursor = Cursors.Default;
                            }
                            catch (Exception _Ex)
                            {
                                MessageBox.Show("Problemas al cargar la información.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Existen egresos de cheque sin comprobante. Debe generar los comprobantes para cerrar la caja.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            _Rb_Cerrar.Checked = false;
                            this.Close();
                        }
                    }
                }
                else
                { _Rb_Cerrar.Checked = false; }
            }
            else
            {
                try
                {
                    _Pnl_Pregunta.Visible = false;
                    Cursor = Cursors.WaitCursor;
                    _Mtd_DeterminarSobrante();
                    _Mtd_CargarReporteCaja();
                    Cursor = Cursors.Default;
                }
                catch (Exception _Ex)
                {
                    MessageBox.Show("Problemas al cargar la información.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void _Rb_Cerrar_CheckedChanged(object sender, EventArgs e)
        {
            _Bt_AceptarP.Enabled = true;
        }

        private void _Rb_Ver_CheckedChanged(object sender, EventArgs e)
        {
            _Bt_AceptarP.Enabled = true;
        }

        private void Frm_ConsultaCajaAbierta_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_Rb_Cerrar.Checked & _MyReport != null)
            {
                if (!_Bol_CajaCerrada)
                {
                    string _Str_Cadena = "UPDATE TCAJACXC SET ccerrando='0',cipcierre=null WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccaja='" + _Txt_Caja.Text.Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
            }
            if (_MyReport != null)
            {
                _MyReport.Close();
                _MyReport.Dispose();
                _MyReport = null;
            }
        }
        
    }
}