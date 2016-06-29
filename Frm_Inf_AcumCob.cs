using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Microsoft.Reporting.WinForms;

namespace T3
{
    public partial class Frm_Inf_AcumCob : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);

        public Frm_Inf_AcumCob()
        {
            InitializeComponent();
            _Rb_SinFiltro.Checked = true;
            _Mtd_CargarVendedor();
        }

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            if (_Ctrl_ConsultaMes1._Bol_Listo)
            {
                _Mtd_Imprimir();
            }
            else
            { MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private void _Mtd_CargarVendedor()
        {
            if (_Cb_Gerente.SelectedIndex > 0)
            {
                if (_Cb_Gerente.SelectedValue != null)
                {
                    string _Str_Sql = "SELECT cvendedor,(RTRIM(cvendedor)+'-'+RTRIM(cname)) AS vendedor_descrip FROM TVENDEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0 AND c_tipo_vend='1' and cgerarea='" + _Cb_Gerente.SelectedValue.ToString() + "' ORDER BY CAST(REPLACE(CVENDEDOR,'" + Frm_Padre._Str_Comp.TrimEnd() + "_','') AS INTEGER) ASC";
                    _myUtilidad._Mtd_CargarCombo(_Cb_ZonaVendedor, _Str_Sql);
                }
                else
                {
                    string _Str_Sql = "SELECT cvendedor,(RTRIM(cvendedor)+'-'+RTRIM(cname)) AS vendedor_descrip FROM TVENDEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0 AND c_tipo_vend='1' ORDER BY CAST(REPLACE(CVENDEDOR,'" + Frm_Padre._Str_Comp.TrimEnd() + "_','') AS INTEGER) ASC";
                    _myUtilidad._Mtd_CargarCombo(_Cb_ZonaVendedor, _Str_Sql);
                }
            }
            else
            {
                string _Str_Sql = "SELECT cvendedor,(RTRIM(cvendedor)+'-'+RTRIM(cname)) AS vendedor_descrip FROM TVENDEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0 AND c_tipo_vend='1' ORDER BY CAST(REPLACE(CVENDEDOR,'" + Frm_Padre._Str_Comp.TrimEnd() + "_','') AS INTEGER) ASC";
                _myUtilidad._Mtd_CargarCombo(_Cb_ZonaVendedor, _Str_Sql);
            }
        }
        private void _Mtd_CargarGerentes()
        {
            string _Str_Sql = "SELECT cvendedor,(RTRIM(cvendedor)+'-'+RTRIM(cname)) AS vendedor_descrip FROM TVENDEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0 AND c_tipo_vend='2' ORDER BY CAST(REPLACE(CVENDEDOR,'" + Frm_Padre._Str_Comp.TrimEnd() + "_','') AS INTEGER) ASC";
            _myUtilidad._Mtd_CargarCombo(_Cb_Gerente, _Str_Sql);
        }
        
        private void _Mtd_Imprimir()
        {
            Cursor = Cursors.WaitCursor;

            DateTimePicker _Dtp_Hasta = new DateTimePicker();
            _Dtp_Hasta.Value = Convert.ToDateTime(_Ctrl_ConsultaMes1._Str_FechaFinal);
            DateTimePicker _Dtp_Desde = new DateTimePicker();
            _Dtp_Desde.Value = Convert.ToDateTime(_Ctrl_ConsultaMes1._Str_FechaInicio);
            reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[11]; 
            if (_Rbt_Acumulado.Checked) { reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_AcumuladoCobranzaResumido"; parm[0] = new ReportParameter("tiporeporte", "1"); }
            if (_Rbt_Detallado.Checked) { reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_CobranzaDetalladaVendedor"; parm[0] = new ReportParameter("tiporeporte", "2"); }
            if (_Rbt_DetalladoConDetalleDePago.Checked) { reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_CobranzaDetalladaVendedorpagos"; parm[0] = new ReportParameter("tiporeporte", "3"); }
            parm[1] = new ReportParameter("cgroupcomp", Frm_Padre._Str_GroupComp);
            parm[2] = new ReportParameter("ccompany", Frm_Padre._Str_Comp.Trim());
            parm[3] = new ReportParameter("fechai", _Cls_Formato._Mtd_fecha(_Dtp_Desde.Value));
            parm[4] = new ReportParameter("fechaf", _Cls_Formato._Mtd_fecha(_Dtp_Hasta.Value));
            parm[5] = new ReportParameter("fechaa", _Cls_Formato._Mtd_fecha(DateTime.Now));
            parm[6] = new ReportParameter("cgerente", "");
            string _Str_Filtro = "";
            if (_Cb_Gerente.SelectedIndex > 0)
            {
                if (_Cb_Gerente.SelectedValue != null)
                {
                    _Str_Filtro = " and cgerente='" + _Cb_Gerente.SelectedValue.ToString() + "'";
                    parm[6] = new ReportParameter("cgerente", _Cb_Gerente.SelectedValue.ToString());
                }
            }

            parm[7] = new ReportParameter("cvendedor", "");
            if (_Cb_ZonaVendedor.SelectedIndex > 0)
            {
                if (_Rb_Vendedor.Checked)
                {
                    if (_Cb_ZonaVendedor.SelectedValue != null)
                    {
                        _Str_Filtro += " and cvendedor='" + _Cb_ZonaVendedor.SelectedValue.ToString() + "'";
                        parm[7] = new ReportParameter("cvendedor", _Cb_ZonaVendedor.SelectedValue.ToString());
                    }
                }
            }
            string _Str_Sql = "";
            if (_Rbt_Acumulado.Checked)
            {
                string _Str_SinFiltroFin = _Str_Filtro;
                if (_Rbt_NoComisionable.Checked)
                {
                    //_Str_Filtro += " and ccomision='0'";
                    //_Str_Sql = "select * from (SELECT ccompany,sum(cmontocobrado) as cmontocobrado,[cvendedor],REPLACE(REPLACE(cnameve,cvendedor,''),' - ','') AS cnameve,[cgerente],REPLACE(REPLACE(cnamege,cgerente,''),' - ','') AS cnamege,dbo.FNC_COBROSACUMULADOSPORVENDEDOR_V2(ccompany, cvendedor, '" + DateTime.Now.ToShortDateString() + "',cgerente,'0') AS ccobrodia,dbo.FNC_CUOTACOBRANZA(ccompany,cvendedor,cgerente,'" + _Dtp_Desde.Value.ToShortDateString() + "','" + _Dtp_Hasta.Value.ToShortDateString() + "') as ccuotacobranza,'0' AS Zona FROM [VST_T3_ACUMCOBRANZAVENDEDOR] where ccompany='" + Frm_Padre._Str_Comp + "' and convert(datetime,cfecharela) between '" + _Dtp_Desde.Value.ToShortDateString() + "' and '" + _Dtp_Hasta.Value.ToShortDateString() + "' AND (c_activo='1' OR (c_activo='0' AND CONVERT(DATETIME,cfechainact)>= CONVERT(DATETIME,'" + _Dtp_Desde.Value.ToShortDateString() + "')))" + _Str_Filtro + " group by ccompany,cvendedor,cnameve,cgerente,cnamege";
                    //_Str_Sql += " UNION ";
                    //_Str_Sql += "SELECT VST_VENDEDORESGERENTE.CCOMPANY, 0 as cmontocobrado, VST_VENDEDORESGERENTE.CVENDEDOR AS CVENDEDOR,REPLACE(REPLACE(VST_VENDEDORESGERENTE.cnameve,VST_VENDEDORESGERENTE.cvendedor,''),' - ','') AS cnameve, VST_VENDEDORESGERENTE.cgerente AS cgerente,REPLACE(REPLACE(VST_VENDEDORESGERENTE.cnamege,VST_VENDEDORESGERENTE.cgerente,''),' - ','') AS cnamege,dbo.FNC_COBROSACUMULADOSPORVENDEDOR_V2(ccompany, cvendedor, '" + DateTime.Now.ToShortDateString() + "',VST_VENDEDORESGERENTE.cgerente,'0') AS ccobrodia,dbo.FNC_CUOTACOBRANZA(ccompany,cvendedor,VST_VENDEDORESGERENTE.cgerente,'" + _Dtp_Desde.Value.ToShortDateString() + "','" + _Dtp_Hasta.Value.ToShortDateString() + "') as ccuotacobranza,'0' AS Zona FROM VST_VENDEDORESGERENTE WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND NOT EXISTS(SELECT CIDRELACOBRO FROM VST_COBRANZA_VENDEDOR INNER JOIN TCAJACXC ON TCAJACXC.CCAJA=VST_COBRANZA_VENDEDOR.CCAJA AND TCAJACXC.CCOMPANY=VST_COBRANZA_VENDEDOR.CCOMPANY WHERE VST_COBRANZA_VENDEDOR.CGROUPCOMP='"+Frm_Padre._Str_GroupComp+"' AND VST_COBRANZA_VENDEDOR.CCOMPANY=VST_VENDEDORESGERENTE.CCOMPANY AND VST_COBRANZA_VENDEDOR.CVENDEDOR=VST_VENDEDORESGERENTE.CVENDEDOR AND  convert(datetime,CONVERT(VARCHAR,VST_COBRANZA_VENDEDOR.cfecharelacobro,103)) between '" + _Dtp_Desde.Value.ToShortDateString() + "' and '" + _Dtp_Hasta.Value.ToShortDateString() + "' AND VST_COBRANZA_VENDEDOR.CCAJA>0 AND TCAJACXC.CCERRADA='1') AND (c_activo='1' OR (c_activo='0' AND CONVERT(DATETIME,cfechainact)>= CONVERT(DATETIME,'" + _Dtp_Desde.Value.ToShortDateString() + "')))" + _Str_SinFiltroFin;
                    //_Str_Sql += " UNION ";
                    //_Str_Sql += "SELECT ccompany,sum(cmontocobrado) as cmontocobrado,[cvendedor],REPLACE(REPLACE(cnameve,cvendedor,''),' - ','') AS cnameve,[cgerente],REPLACE(REPLACE(cnamege,cgerente,''),' - ','') AS cnamege,dbo.FNC_COBROSACUMULADOSPORVENDEDOR_V2(ccompany, cvendedor, '" + DateTime.Now.ToShortDateString() + "',cgerente,'0') AS ccobrodia,dbo.FNC_CUOTACOBRANZA(ccompany,cvendedor,cgerente,'" + _Dtp_Desde.Value.ToShortDateString() + "','" + _Dtp_Hasta.Value.ToShortDateString() + "') as ccuotacobranza,'0' AS Zona FROM [VST_T3_ACUMCOBRANZAVENDEDOR] where ccompany='" + Frm_Padre._Str_Comp + "' and convert(datetime,cfecharela) between '" + _Dtp_Desde.Value.ToShortDateString() + "' and '" + _Dtp_Hasta.Value.ToShortDateString() + "' AND C_ACTIVO='0'" + _Str_Filtro + " group by ccompany,cvendedor,cnameve,cgerente,cnamege HAVING sum(cmontocobrado)-dbo.FNC_CHEQDEVACUMPORVEND(ccompany,cvendedor,'" + _Dtp_Desde.Value.ToShortDateString() + "','" + _Dtp_Hasta.Value.ToShortDateString() + "',cgerente)>0";
                    //_Str_Sql += " UNION ";
                    //_Str_Sql += " SELECT VST_T3_VENDEDORHISTVENZONA.ccompany,0 as cmontocobrado,VST_T3_VENDEDORHISTVENZONA.cvendedor,REPLACE(REPLACE(VST_T3_VENDEDORHISTVENZONA.cnameve,cvendedor,''),' - ','') AS cnameve,VST_T3_VENDEDORHISTVENZONA.cgerente,REPLACE(REPLACE(VST_T3_VENDEDORHISTVENZONA.cnamege,VST_T3_VENDEDORHISTVENZONA.cgerente,''),' - ','') AS cnamege,0 AS ccobrodia,dbo.FNC_CUOTACOBRANZA(ccompany,cvendedor,cgerente,'" + _Dtp_Desde.Value.ToShortDateString() + "','" + _Dtp_Hasta.Value.ToShortDateString() + "') as ccuotacobranza,'0' AS Zona FROM [VST_T3_VENDEDORHISTVENZONA] where ccompany='" + Frm_Padre._Str_Comp + "' and ((cfechaf IS NULL AND CFECHAI<'" + _Dtp_Hasta.Value.ToShortDateString() + "') OR cfechaf>'" + _Dtp_Desde.Value.ToShortDateString() + "') AND ISNULL((SELECT SUM(CMONTOCOBRADO) FROM TMOVINCOBRANZA WHERE TMOVINCOBRANZA.CVENDEDOR=[VST_T3_VENDEDORHISTVENZONA].CVENDEDOR AND TMOVINCOBRANZA.CGERAREA=[VST_T3_VENDEDORHISTVENZONA].CGERENTE AND (convert(datetime,cfecharelaCOBRO) between '" + _Dtp_Desde.Value.ToShortDateString() + "' and '" + _Dtp_Hasta.Value.ToShortDateString() + "')),0)-ISNULL(dbo.FNC_CHEQDEVACUMPORVEND(ccompany,cvendedor,'" + _Dtp_Desde.Value.ToShortDateString() + "','" + _Dtp_Hasta.Value.ToShortDateString() + "',cgerente),0)=0 AND dbo.FNC_CUOTACOBRANZA(ccompany,cvendedor,cgerente,'" + _Dtp_Desde.Value.ToShortDateString() + "','" + _Dtp_Hasta.Value.ToShortDateString() + "')>0" + _Str_SinFiltroFin + ") as vista";
                    parm[8] = new ReportParameter("ccomision", "0");
                }
                else
                {
                    //_Str_Filtro += " and ccomision='1'";
                    //_Str_Sql = "select * from (SELECT ccompany,sum(cmontocobrado)-dbo.FNC_CHEQDEVACUMPORVEND(ccompany,cvendedor,'" + _Dtp_Desde.Value.ToShortDateString() + "','" + _Dtp_Hasta.Value.ToShortDateString() + "',cgerente) as cmontocobrado,[cvendedor],REPLACE(REPLACE(cnameve,cvendedor,''),' - ','') AS cnameve,[cgerente],REPLACE(REPLACE(cnamege,cgerente,''),' - ','') AS cnamege,dbo.FNC_COBROSACUMULADOSPORVENDEDOR_V2(ccompany, cvendedor, '" + _Dtp_Hasta.Value.ToShortDateString() + "',cgerente,'1')-dbo.FNC_CHEQDEVACUMPORVEND(ccompany,cvendedor,'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortDateString() + "',cgerente) AS ccobrodia,dbo.FNC_CUOTACOBRANZA(ccompany,cvendedor,cgerente,'" + _Dtp_Desde.Value.ToShortDateString() + "','" + _Dtp_Hasta.Value.ToShortDateString() + "') as ccuotacobranza,'0' AS Zona FROM [VST_T3_ACUMCOBRANZAVENDEDOR] where ccompany='" + Frm_Padre._Str_Comp + "' and convert(datetime,cfecharela) between '" + _Dtp_Desde.Value.ToShortDateString() + "' and '" + _Dtp_Hasta.Value.ToShortDateString() + "' AND (c_activo='1' OR (c_activo='0' AND CONVERT(DATETIME,cfechainact)>= CONVERT(DATETIME,'" + _Dtp_Desde.Value.ToShortDateString() + "')))" + _Str_Filtro + " group by ccompany,cvendedor,cnameve,cgerente,cnamege";
                    //_Str_Sql += " UNION ";
                    //_Str_Sql += "SELECT VST_VENDEDORESGERENTE.CCOMPANY, 0-dbo.FNC_CHEQDEVACUMPORVEND(VST_VENDEDORESGERENTE.ccompany,VST_VENDEDORESGERENTE.cvendedor,'" + _Dtp_Desde.Value.ToShortDateString() + "','" + _Dtp_Hasta.Value.ToShortDateString() + "',VST_VENDEDORESGERENTE.cgerente) as cmontocobrado, VST_VENDEDORESGERENTE.CVENDEDOR AS CVENDEDOR,REPLACE(REPLACE(VST_VENDEDORESGERENTE.cnameve,VST_VENDEDORESGERENTE.cvendedor,''),' - ','') AS cnameve, VST_VENDEDORESGERENTE.cgerente AS cgerente,REPLACE(REPLACE(VST_VENDEDORESGERENTE.cnamege,VST_VENDEDORESGERENTE.cgerente,''),' - ','') AS cnamege,dbo.FNC_COBROSACUMULADOSPORVENDEDOR_V2(ccompany, cvendedor, '" + DateTime.Now.ToShortDateString() + "',VST_VENDEDORESGERENTE.cgerente,'1') AS ccobrodia,dbo.FNC_CUOTACOBRANZA(ccompany,cvendedor,VST_VENDEDORESGERENTE.cgerente,'" + _Dtp_Desde.Value.ToShortDateString() + "','" + _Dtp_Hasta.Value.ToShortDateString() + "') as ccuotacobranza,'0' AS Zona FROM VST_VENDEDORESGERENTE WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND NOT EXISTS(SELECT CIDRELACOBRO FROM VST_COBRANZA_VENDEDOR INNER JOIN TCAJACXC ON TCAJACXC.CCAJA=VST_COBRANZA_VENDEDOR.CCAJA AND TCAJACXC.CCOMPANY=VST_COBRANZA_VENDEDOR.CCOMPANY WHERE VST_COBRANZA_VENDEDOR.CGROUPCOMP='" + Frm_Padre._Str_GroupComp + "' and VST_COBRANZA_VENDEDOR.CCOMPANY=VST_VENDEDORESGERENTE.CCOMPANY AND VST_COBRANZA_VENDEDOR.CVENDEDOR=VST_VENDEDORESGERENTE.CVENDEDOR AND convert(datetime,CONVERT(VARCHAR,VST_COBRANZA_VENDEDOR.cfecharelacobro,103)) between '" + _Dtp_Desde.Value.ToShortDateString() + "' and '" + _Dtp_Hasta.Value.ToShortDateString() + "' AND VST_COBRANZA_VENDEDOR.CCAJA>0 AND TCAJACXC.CCERRADA='1') AND (c_activo='1' OR (c_activo='0' AND CONVERT(DATETIME,cfechainact)>= CONVERT(DATETIME,'" + _Dtp_Desde.Value.ToShortDateString() + "')))" + _Str_SinFiltroFin;
                    //_Str_Sql += " UNION ";
                    //_Str_Sql += "SELECT ccompany,sum(cmontocobrado)-dbo.FNC_CHEQDEVACUMPORVEND(ccompany,cvendedor,'" + _Dtp_Desde.Value.ToShortDateString() + "','" + _Dtp_Hasta.Value.ToShortDateString() + "',cgerente) as cmontocobrado,[cvendedor],REPLACE(REPLACE(cnameve,cvendedor,''),' - ','') AS cnameve,[cgerente],REPLACE(REPLACE(cnamege,cgerente,''),' - ','') AS cnamege,dbo.FNC_COBROSACUMULADOSPORVENDEDOR_V2(ccompany, cvendedor, '" + _Dtp_Hasta.Value.ToShortDateString() + "',cgerente,'1')-dbo.FNC_CHEQDEVACUMPORVEND(ccompany,cvendedor,'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortDateString() + "',cgerente) AS ccobrodia,dbo.FNC_CUOTACOBRANZA(ccompany,cvendedor,cgerente,'" + _Dtp_Desde.Value.ToShortDateString() + "','" + _Dtp_Hasta.Value.ToShortDateString() + "') as ccuotacobranza,'0' AS Zona FROM [VST_T3_ACUMCOBRANZAVENDEDOR] where ccompany='" + Frm_Padre._Str_Comp + "' and convert(datetime,cfecharela) between '" + _Dtp_Desde.Value.ToShortDateString() + "' and '" + _Dtp_Hasta.Value.ToShortDateString() + "' AND c_activo='0'" + _Str_Filtro + " group by ccompany,cvendedor,cnameve,cgerente,cnamege HAVING sum(cmontocobrado)-dbo.FNC_CHEQDEVACUMPORVEND(ccompany,cvendedor,'" + _Dtp_Desde.Value.ToShortDateString() + "','" + _Dtp_Hasta.Value.ToShortDateString() + "',cgerente)>0";
                    //_Str_Sql+= " UNION ";
                    //_Str_Sql += " SELECT VST_T3_VENDEDORHISTVENZONA.ccompany,0 as cmontocobrado,VST_T3_VENDEDORHISTVENZONA.cvendedor,REPLACE(REPLACE(VST_T3_VENDEDORHISTVENZONA.cnameve,cvendedor,''),' - ','') AS cnameve,VST_T3_VENDEDORHISTVENZONA.cgerente,REPLACE(REPLACE(VST_T3_VENDEDORHISTVENZONA.cnamege,VST_T3_VENDEDORHISTVENZONA.cgerente,''),' - ','') AS cnamege,0 AS ccobrodia,dbo.FNC_CUOTACOBRANZA(ccompany,cvendedor,cgerente,'" + _Dtp_Desde.Value.ToShortDateString() + "','" + _Dtp_Hasta.Value.ToShortDateString() + "') as ccuotacobranza,'0' AS Zona FROM [VST_T3_VENDEDORHISTVENZONA] where ccompany='" + Frm_Padre._Str_Comp + "' and ((cfechaf IS NULL AND CFECHAI<'" + _Dtp_Hasta.Value.ToShortDateString() + "') OR cfechaf>'" + _Dtp_Desde.Value.ToShortDateString() + "') AND ISNULL((SELECT SUM(CMONTOCOBRADO) FROM TMOVINCOBRANZA WHERE TMOVINCOBRANZA.CVENDEDOR=[VST_T3_VENDEDORHISTVENZONA].CVENDEDOR AND TMOVINCOBRANZA.CGERAREA=[VST_T3_VENDEDORHISTVENZONA].CGERENTE AND (convert(datetime,cfecharelaCOBRO) between '" + _Dtp_Desde.Value.ToShortDateString() + "' and '" + _Dtp_Hasta.Value.ToShortDateString() + "')),0)-ISNULL(dbo.FNC_CHEQDEVACUMPORVEND(ccompany,cvendedor,'" + _Dtp_Desde.Value.ToShortDateString() + "','" + _Dtp_Hasta.Value.ToShortDateString() + "',cgerente),0)=0 AND dbo.FNC_CUOTACOBRANZA(ccompany,cvendedor,cgerente,'" + _Dtp_Desde.Value.ToShortDateString() + "','" + _Dtp_Hasta.Value.ToShortDateString() + "')>0" + _Str_SinFiltroFin + ") as vista";
                    parm[8] = new ReportParameter("ccomision", "1");
                }
                //DataSet _Ds;
                //Report.rAcumCobranza _MyReport = new T3.Report.rAcumCobranza();
                //_Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);




                //if (_Ds.Tables[0].Rows.Count > 0)
                //{
                //    _MyReport.SetDataSource(_Ds.Tables[0]);

                //    Section _sec = _MyReport.ReportDefinition.Sections["Section2"];
                //    TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                //    DataSet dsResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT crif, rtrim(cname) as cname FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                //    tex1.Text = (dsResultado.Tables[0].Rows[0]["cname"].ToString() + "\r\n" + dsResultado.Tables[0].Rows[0]["crif"].ToString());

                //    TextObject tex2 = _sec.ReportObjects["txt_desde_hasta"] as TextObject;
                //    if (_Rbt_NoComisionable.Checked)
                //    {
                //        tex2.Text = " (NO COMISIONABLE) DESDE EL " + _Dtp_Desde.Value.ToShortDateString() + " AL " + _Dtp_Hasta.Value.ToShortDateString();
                //    }
                //    else
                //    {
                //        tex2.Text = " (COMISIONABLE) DESDE EL " + _Dtp_Desde.Value.ToShortDateString() + " AL " + _Dtp_Hasta.Value.ToShortDateString();
                //    }
                //    _Rpv_Main.ReportSource = _MyReport;
                //    _Rpv_Main.RefreshReport();
                //}
                //else
                //{
                //    MessageBox.Show("No se encontraron registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    _Rpv_Main.ReportSource = null;
                //}
            }
            else if (_Rbt_Detallado.Checked)
            {
               
                    if (_Rbt_NoComisionable.Checked)
                    {
                        //_Str_Filtro += " and ccomision='0'";
                        parm[8] = new ReportParameter("ccomision", "0");
                    }
                    else
                    {
                        //_Str_Filtro += " and ccomision='1'";
                        parm[8] = new ReportParameter("ccomision", "1");
                    }
                    //_Str_Sql = "SELECT [cvendedor],[cname],[ccompany],[ccliente],[c_nomb_comer],[cnumdocu],[ctipodocument],[cnombdoc],[ccerrada],[cfecharela],[ccaja],[cmontcompretiva],[cdiasdocument],[cidrelacobro],[ccancelado] FROM VST_CHQDEVCOBDETALLADA WHERE ccompany='" + Frm_Padre._Str_Comp + "' and convert(datetime,cfecharela) between '" + _Dtp_Desde.Value.ToShortDateString() + "' and '" + _Dtp_Hasta.Value.ToShortDateString() + "'" + _Str_Filtro;
                    //_Str_Sql += " UNION ";
                    //_Str_Sql += "SELECT [cvendedor],[cname],[ccompany],[ccliente],[c_nomb_comer],[cnumdocu],[ctipodocument],[cnombdoc],[ccerrada],[cfecharela],[ccaja],[cmontcompretiva],[cdiasdocument],[cidrelacobro],[ccancelado] FROM [VST_ACUM_COBDETALLADO] where ccompany='" + Frm_Padre._Str_Comp + "' and convert(datetime,cfecharela) between '" + _Dtp_Desde.Value.ToShortDateString() + "' and '" + _Dtp_Hasta.Value.ToShortDateString() + "'" + _Str_Filtro;

                    //ultimo utilizado
                    //_Str_Sql = "SELECT [cvendedor],[cname],[ccompany],[ccliente],[c_nomb_comer],[cnumdocu],[ctipodocument],[cnombdoc],[ccerrada],[cfecharela], CONVERT(varchar,[ccaja]) AS ccaja,[cmontcompretiva],[cdiasdocument],[cidrelacobro],[ccancelado],ctdocumentchqdev,cnumdocuchqdev FROM VST_CHQDEVCOBDETALLADA WHERE ccompany='" + Frm_Padre._Str_Comp + "' and convert(datetime,cfecharela) between '" + _Dtp_Desde.Value.ToShortDateString() + "' and '" + _Dtp_Hasta.Value.ToShortDateString() + "'" + _Str_Filtro;
                    //_Str_Sql += " UNION ";
                    //_Str_Sql += "SELECT [cvendedor],[cname],[ccompany],[ccliente],[c_nomb_comer],[cnumdocu],[ctipodocument],[cnombdoc],[ccerrada],[cfecharela], CONVERT(varchar,[ccaja]) AS ccaja,[cmontcompretiva],[cdiasdocument],[cidrelacobro],[ccancelado],ctdocumentchqdev,cnumdocuchqdev FROM [VST_ACUM_COBDETALLADO] where ccompany='" + Frm_Padre._Str_Comp + "' and convert(datetime,cfecharela) between '" + _Dtp_Desde.Value.ToShortDateString() + "' and '" + _Dtp_Hasta.Value.ToShortDateString() + "'" + _Str_Filtro;
                
                //DataSet _Ds;
                //Report.rCobranzaDetallada _MyReport = new T3.Report.rCobranzaDetallada();
                //_Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                //if (_Ds.Tables[0].Rows.Count > 0)
                //{
                //    _MyReport.SetDataSource(_Ds.Tables[0]);
                    
                //    Section _sec = _MyReport.ReportDefinition.Sections["Section2"];
                //    TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                //    DataSet dsResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT crif, rtrim(cname) as cname FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                //    tex1.Text = (dsResultado.Tables[0].Rows[0]["cname"].ToString() + "\r\n" + dsResultado.Tables[0].Rows[0]["crif"].ToString());

                //    TextObject tex2 = _sec.ReportObjects["txt_desde_hasta"] as TextObject;
                //    if (_Rbt_NoComisionable.Checked)
                //    {
                //        tex2.Text = " (NO COMISIONABLE) DESDE EL " + _Dtp_Desde.Value.ToShortDateString() + " AL " + _Dtp_Hasta.Value.ToShortDateString();
                //    }
                //    else
                //    {
                //        tex2.Text = " (COMISIONABLE) DESDE EL " + _Dtp_Desde.Value.ToShortDateString() + " AL " + _Dtp_Hasta.Value.ToShortDateString();
                //    }
                //    _Rpv_Main.ReportSource = _MyReport;
                //    _Rpv_Main.RefreshReport();
                //}
                //else
                //{
                //    MessageBox.Show("No se encontraron registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    _Rpv_Main.ReportSource = null;
                //}
            }
            else if (_Rbt_DetalladoConDetalleDePago.Checked) //OJO
            {

                if (_Rbt_NoComisionable.Checked)
                {
                    //_Str_Filtro += " and ccomision='0'";
                    parm[8] = new ReportParameter("ccomision", "0");
                }
                else
                {
                    //_Str_Filtro += " and ccomision='1'";
                    parm[8] = new ReportParameter("ccomision", "1");
                }

            //    _Str_Sql = "SELECT [cvendedor],[cname],[ccompany],[ccliente],[c_nomb_comer],[cnumdocu],[ctipodocument],[cnombdoc],[ccerrada],[cfecharela], CONVERT(varchar,[ccaja]) AS ccaja,[cmontcompretiva],[cdiasdocument],[cidrelacobro],[ccancelado],ctdocumentchqdev,cnumdocuchqdev, CNOMBREBANCO,CNUMEROCHEQUE,CTIPOPAGO FROM VST_CHQDEVCOBDETDETALLADA WHERE ccompany='" + Frm_Padre._Str_Comp + "' and convert(datetime,cfecharela) between '" + _Dtp_Desde.Value.ToShortDateString() + "' and '" + _Dtp_Hasta.Value.ToShortDateString() + "'" + _Str_Filtro;
            //    _Str_Sql += " UNION ";
            //    _Str_Sql += "SELECT [cvendedor],[cname],[ccompany],[ccliente],[c_nomb_comer],[cnumdocu],[ctipodocument],[cnombdoc],[ccerrada],[cfecharela], CONVERT(varchar,[ccaja]) AS ccaja,[cmontcompretiva],[cdiasdocument],[cidrelacobro],[ccancelado],ctdocumentchqdev,cnumdocuchqdev,CNOMBREBANCO,CNUMEROCHEQUE,CTIPOPAGO FROM [VST_ACUM_COBDETDETALLADO] where ccompany='" + Frm_Padre._Str_Comp + "' and convert(datetime,cfecharela) between '" + _Dtp_Desde.Value.ToShortDateString() + "' and '" + _Dtp_Hasta.Value.ToShortDateString() + "'" + _Str_Filtro;

            //    DataSet _Ds;
            //    Report.rCobranzaDetalladaConDetalleDePago _MyReport = new T3.Report.rCobranzaDetalladaConDetalleDePago();
            //    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //    if (_Ds.Tables[0].Rows.Count > 0)
            //    {
            //        _MyReport.SetDataSource(_Ds.Tables[0]);

            //        Section _sec = _MyReport.ReportDefinition.Sections["Section2"];
            //        TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
            //        DataSet dsResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT crif, rtrim(cname) as cname FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            //        tex1.Text = (dsResultado.Tables[0].Rows[0]["cname"].ToString() + "\r\n" + dsResultado.Tables[0].Rows[0]["crif"].ToString());

            //        TextObject tex2 = _sec.ReportObjects["txt_desde_hasta"] as TextObject;
            //        if (_Rbt_NoComisionable.Checked)
            //        {
            //            tex2.Text = " (NO COMISIONABLE) DESDE EL " + _Dtp_Desde.Value.ToShortDateString() + " AL " + _Dtp_Hasta.Value.ToShortDateString();
            //        }
            //        else
            //        {
            //            tex2.Text = " (COMISIONABLE) DESDE EL " + _Dtp_Desde.Value.ToShortDateString() + " AL " + _Dtp_Hasta.Value.ToShortDateString();
            //        }
            //        _Rpv_Main.ReportSource = _MyReport;
            //        _Rpv_Main.RefreshReport();
            //    }
            //    else
            //    {
            //        MessageBox.Show("No se encontraron registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        _Rpv_Main.ReportSource = null;
            //    }
            }

            parm[9] = new ReportParameter("nomb_empresa", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp.Trim()));
            parm[10] = new ReportParameter("rif", CLASES._Cls_Varios_Metodos._Mtd_RifComp(Frm_Padre._Str_Comp.Trim()));
            reportViewer1.ServerReport.SetParameters(parm);
            reportViewer1.ServerReport.Refresh();
            reportViewer1.RefreshReport();

            Cursor = Cursors.Default;
        }

        private void _Cb_ZonaVendedor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (_Rb_Vendedor.Checked)
            {
                _Mtd_CargarVendedor();
            }
            this.Cursor = Cursors.Default;
        }

        private void Frm_Inf_AcumCob_Load(object sender, EventArgs e)
        {
            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();
            this.reportViewer1.RefreshReport();
        }

        private void _Cb_Gerente_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_CargarGerentes();
            this.Cursor = Cursors.Default;
        }

        private void _Rb_Gerente_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Gerente.Checked)
            {
                _Cb_Gerente.Enabled = true;
            }
            else
            {
                _Cb_Gerente.SelectedIndex = -1;
                _Cb_Gerente.Enabled = false;
            }
        }

        private void _Rb_SinFiltro_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_SinFiltro.Checked)
            {
                _Cb_Gerente.Enabled = false;
            }
        }

        private void _Rb_Vendedor_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Vendedor.Checked)
            {
                _Cb_ZonaVendedor.Enabled = true;
            }
            else
            {
                _Cb_ZonaVendedor.SelectedIndex = -1;
                _Cb_ZonaVendedor.Enabled = false;
            }
        }

        private void _Rbt_Detallado_CheckedChanged(object sender, EventArgs e)
        {
            _Rb_SinFiltro.Checked = false;
            _Rb_SinFiltro.Enabled = false;
            _Rb_Gerente.Enabled = false;
            _Rb_Gerente.Checked = false;
        }



        private void _Rbt_Acumulado_CheckedChanged(object sender, EventArgs e)
        {
            _Rb_Gerente.Enabled = true;
            _Rb_SinFiltro.Enabled = true;
        }

        private void _Rbt_VersionOld_CheckedChanged(object sender, EventArgs e)
        {
            _Rbt_NoComisionable.Checked = false;
            _Rbt_Comisionable.Checked = false;
        }

        private void _Rbt_VersionNew_CheckedChanged(object sender, EventArgs e)
        {
            _Rbt_NoComisionable.Checked = false;
            _Rbt_Comisionable.Checked = true;
        }

        private void _Rb_SinFiltro2_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_SinFiltro2.Checked)
            {
                _Cb_ZonaVendedor.Enabled = false;
            }
        }

        private void _Rbt_DetalladoConDetalleDePago_CheckedChanged(object sender, EventArgs e)
        {
            _Rb_SinFiltro.Checked = false;
            _Rb_SinFiltro.Enabled = false;
            _Rb_Gerente.Enabled = false;
            _Rb_Gerente.Checked = false;

        }
    }
}