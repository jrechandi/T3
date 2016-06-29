using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
namespace T3
{
    /// <summary>
    /// Descripción breve de REPORTESS.
    /// </summary>
    public class REPORTESS : System.Windows.Forms.Form
    {
        public string _Str_FrmErrorPrint = "";
        SqlConnection ju = new SqlConnection();
        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private DataSet2 dataSet21;
        private PrintDialog printDialog1;
        string[] tab2;
        ReportClass w;

        public REPORTESS()
        {

        }

        public REPORTESS(string _P_Str_Reporte, DataTable _P_DT, PrintDialog _P_PriN, bool _P_Bol_SINO, string secc, string cab, string rif, string nit)
        {

            InitializeComponent();
            crystalReportViewer1.ResetText();
            //CrystalDecisions.Shared.ResponseContext _MyResponse = new CrystalDecisions.Shared.ResponseContext();

            //Report.rPrecargac _MyReport; _MyReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,System.Web.HttpResponse, true, "");

            DataSet _Ds = new DataSet();
            try
            {
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'");
            }
            catch { }
            SqlConnection con = new SqlConnection(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            w = (ReportClass)Activator.CreateInstance(Type.GetType(_P_Str_Reporte));

            w.SetDataSource(_P_DT);
            //w.PrintOptions.PrinterName = _P_PriN.PrinterSettings.PrinterName;
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex1 = sec.ReportObjects["cabecera"] as TextObject;
                tex1.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex2 = sec.ReportObjects["Direccion"] as TextObject;
                tex2.Text = _Ds.Tables[0].Rows[0]["caddress"].ToString().Trim();
                TextObject text3 = sec.ReportObjects["Telefonos"] as TextObject;
                text3.Text = _Ds.Tables[0].Rows[0]["cphone1"].ToString().Trim() + " / " + _Ds.Tables[0].Rows[0]["cphone2"].ToString().Trim();
                TextObject text4 = sec.ReportObjects["Email"] as TextObject;
                text4.Text = _Ds.Tables[0].Rows[0]["cemail"].ToString().Trim();
                TextObject text5 = sec.ReportObjects["rif"] as TextObject;
                text5.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
                //---------------------------------
            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex6 = sec.ReportObjects["cabecera2"] as TextObject;
                tex6.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex7 = sec.ReportObjects["cabecera3"] as TextObject;
                tex7.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject text8 = sec.ReportObjects["rif"] as TextObject;
                text8.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
                TextObject text9 = sec.ReportObjects["rif2"] as TextObject;
                text9.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
                TextObject text10 = sec.ReportObjects["rif3"] as TextObject;
                text10.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex11 = sec.ReportObjects["cabecera"] as TextObject;
                tex11.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex12 = sec.ReportObjects["rif"] as TextObject;
                tex12.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
            }
            catch { }
            w.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;


            crystalReportViewer1.ReportSource = w;

            if (_P_Bol_SINO)
            {
                var _PageSettings = new System.Drawing.Printing.PageSettings();
                _PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
                if (_P_Str_Reporte == "T3.Report.rPagoISRL" || _P_Str_Reporte == "T3.Report.rCajaCobDet" || _P_Str_Reporte == "T3.Report.rComprobRetencion" || _P_Str_Reporte == "T3.Report.rFactComparada2" || _P_Str_Reporte == "T3.Report.rInventValor" || _P_Str_Reporte == "T3.Report.rTarjetas")
                {
                    _PageSettings.Landscape = true;
                }
                else
                {
                    _PageSettings.Landscape = false;
                }
                var _PrtSettings = new System.Drawing.Printing.PrinterSettings { PrinterName = _P_PriN.PrinterSettings.PrinterName, Copies = _P_PriN.PrinterSettings.Copies, Collate = _P_PriN.PrinterSettings.Collate };
                try
                {
                    w.PrintToPrinter(_PrtSettings, _PageSettings, false);
                }
                catch (Exception _Ex)
                {
                    throw new Exception("Error al conectarse con la impresora" + _Ex.Message);
                }
            }
        }
        public REPORTESS(string _P_Str_Reporte, DataTable _P_DT, PrintDialog _P_PriN, bool _P_Bol_SINO, string secc, string cab, string rif, string nit, string _P_Str_Comp)
        {

            InitializeComponent();
            crystalReportViewer1.ResetText();
            //CrystalDecisions.Shared.ResponseContext _MyResponse = new CrystalDecisions.Shared.ResponseContext();

            //Report.rPrecargac _MyReport; _MyReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,System.Web.HttpResponse, true, "");

            DataSet _Ds = new DataSet();
            try
            {
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from TCOMPANY where ccompany='" + _P_Str_Comp + "'");
            }
            catch { }
            SqlConnection con = new SqlConnection(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            w = (ReportClass)Activator.CreateInstance(Type.GetType(_P_Str_Reporte));

            w.SetDataSource(_P_DT);
            //w.PrintOptions.PrinterName = _P_PriN.PrinterSettings.PrinterName;
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex1 = sec.ReportObjects["cabecera"] as TextObject;
                tex1.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex2 = sec.ReportObjects["Direccion"] as TextObject;
                tex2.Text = _Ds.Tables[0].Rows[0]["caddress"].ToString().Trim();
                TextObject text3 = sec.ReportObjects["Telefonos"] as TextObject;
                text3.Text = _Ds.Tables[0].Rows[0]["cphone1"].ToString().Trim() + " / " + _Ds.Tables[0].Rows[0]["cphone2"].ToString().Trim();
                TextObject text4 = sec.ReportObjects["Email"] as TextObject;
                text4.Text = _Ds.Tables[0].Rows[0]["cemail"].ToString().Trim();
                TextObject text5 = sec.ReportObjects["rif"] as TextObject;
                text5.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
                //---------------------------------
            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex6 = sec.ReportObjects["cabecera2"] as TextObject;
                tex6.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex7 = sec.ReportObjects["cabecera3"] as TextObject;
                tex7.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject text8 = sec.ReportObjects["rif"] as TextObject;
                text8.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
                TextObject text9 = sec.ReportObjects["rif2"] as TextObject;
                text9.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
                TextObject text10 = sec.ReportObjects["rif3"] as TextObject;
                text10.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex11 = sec.ReportObjects["cabecera"] as TextObject;
                tex11.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex12 = sec.ReportObjects["rif"] as TextObject;
                tex12.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
            }
            catch { }

            crystalReportViewer1.ReportSource = w;

            if (_P_Bol_SINO)
            {
                var _PageSettings = new System.Drawing.Printing.PageSettings();
                _PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
                if (_P_Str_Reporte == "T3.Report.rPagoISRL" || _P_Str_Reporte == "T3.Report.rCajaCobDet" || _P_Str_Reporte == "T3.Report.rComprobRetencion" || _P_Str_Reporte == "T3.Report.rFactComparada2" || _P_Str_Reporte == "T3.Report.rInventValor" || _P_Str_Reporte == "T3.Report.rTarjetas")
                {
                    _PageSettings.Landscape = true;
                }
                else
                {
                    _PageSettings.Landscape = false;
                }
                var _PrtSettings = new System.Drawing.Printing.PrinterSettings { PrinterName = _P_PriN.PrinterSettings.PrinterName, Copies = _P_PriN.PrinterSettings.Copies, Collate = _P_PriN.PrinterSettings.Collate };
                try
                {
                    w.PrintToPrinter(_PrtSettings, _PageSettings, false);
                }
                catch (Exception _Ex)
                {
                    throw new Exception("Error al conectarse con la impresora" + _Ex.Message);
                }
            }
        }
        public REPORTESS(string _P_Str_Reporte, DataTable _P_DT, string secc, string cab, string rif, string nit)
        {

            InitializeComponent();
            crystalReportViewer1.ResetText();
            DataSet _Ds = new DataSet();
            try
            {
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'");
            }
            catch { }
            SqlConnection con = new SqlConnection(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            w = (ReportClass)Activator.CreateInstance(Type.GetType(_P_Str_Reporte));

            w.SetDataSource(_P_DT);
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex1 = sec.ReportObjects["cabecera"] as TextObject;
                tex1.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex2 = sec.ReportObjects["Direccion"] as TextObject;
                tex2.Text = _Ds.Tables[0].Rows[0]["caddress"].ToString().Trim();
                TextObject text3 = sec.ReportObjects["Telefonos"] as TextObject;
                text3.Text = _Ds.Tables[0].Rows[0]["cphone1"].ToString().Trim() + " / " + _Ds.Tables[0].Rows[0]["cphone2"].ToString().Trim();
                TextObject text4 = sec.ReportObjects["Email"] as TextObject;
                text4.Text = _Ds.Tables[0].Rows[0]["cemail"].ToString().Trim();
                TextObject text5 = sec.ReportObjects["rif"] as TextObject;
                text5.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
                //---------------------------------
            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex6 = sec.ReportObjects["cabecera2"] as TextObject;
                tex6.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex7 = sec.ReportObjects["cabecera3"] as TextObject;
                tex7.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject text8 = sec.ReportObjects["rif"] as TextObject;
                text8.Text = _Ds.Tables[0].Rows[0]["crif"].ToString().Trim();
                TextObject text9 = sec.ReportObjects["rif2"] as TextObject;
                text9.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
                TextObject text10 = sec.ReportObjects["rif3"] as TextObject;
                text10.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex11 = sec.ReportObjects["cabecera"] as TextObject;
                tex11.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex12 = sec.ReportObjects["rif"] as TextObject;
                tex12.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
            }
            catch { }
            w.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
            if (_P_Str_Reporte == "T3.Report.rPagoISRL" || _P_Str_Reporte == "T3.Report.rCajaCobDet" || _P_Str_Reporte == "T3.Report.rComprobRetencion" || _P_Str_Reporte == "T3.Report.rFactComparada2" || _P_Str_Reporte == "T3.Report.rInventValor" || _P_Str_Reporte == "T3.Report.rTarjetas")
            {
                w.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            }
            else
            {
                w.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            }
            crystalReportViewer1.ReportSource = w;

        }
        public REPORTESS(ReportDocument _P_Rpt_Reporte, DataTable _P_DT, PrintDialog _P_PriN, string _Pr_Str_Seccion)
        {
            InitializeComponent();
            crystalReportViewer1.ResetText();
            Section sec = _P_Rpt_Reporte.ReportDefinition.Sections[_Pr_Str_Seccion];
            TextObject tex1 = sec.ReportObjects["Txt_MontoNum"] as TextObject;
            tex1.Text = _P_DT.Rows[0]["cmontonum"].ToString();

            TextObject tex2 = sec.ReportObjects["Txt_Persona"] as TextObject;
            tex2.Text = _P_DT.Rows[0]["cpersona"].ToString();

            TextObject text3 = sec.ReportObjects["Txt_MontoDescrip"] as TextObject;
            text3.Text = _P_DT.Rows[0]["cmontodescrip"].ToString();

            TextObject text4 = sec.ReportObjects["Txt_MontoDescrip1"] as TextObject;
            text4.Text = _P_DT.Rows[0]["cmontodescrip1"].ToString();

            _Mtd_RedimMontoTxt(_P_DT.Rows[0]["cmontodescrip"].ToString() + _P_DT.Rows[0]["cmontodescrip1"].ToString(), text3, text4);

            TextObject text5 = sec.ReportObjects["Txt_Fecha"] as TextObject;
            text5.Text = _P_DT.Rows[0]["cfecha1"].ToString();

            TextObject text6 = sec.ReportObjects["Txt_Fecha1"] as TextObject;
            text6.Text = _P_DT.Rows[0]["cfecha2"].ToString();

            TextObject text7 = sec.ReportObjects["Caduca"] as TextObject;
            text7.Text = _P_DT.Rows[0]["ccaduca"].ToString();

            _P_Rpt_Reporte.SetDataSource(_P_DT);
            _P_Rpt_Reporte.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
            _P_Rpt_Reporte.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            crystalReportViewer1.ReportSource = _P_Rpt_Reporte;
            try
            {
                crystalReportViewer1.PrintReport();
            }
            catch (Exception _Ex)
            {
                throw new Exception("Error al conectarse con la impresora" + _Ex.Message);
            }
        }
        public REPORTESS(string _P_Str_Reporte, DataTable _P_DT, PrintDialog _P_PriN, string _Pr_Str_Seccion)
        {
            InitializeComponent();
            w = (ReportClass)Activator.CreateInstance(Type.GetType(_P_Str_Reporte));
            crystalReportViewer1.ResetText();
            Section sec = w.ReportDefinition.Sections[_Pr_Str_Seccion];
            TextObject tex1 = sec.ReportObjects["Txt_MontoNum"] as TextObject;
            tex1.Text = _P_DT.Rows[0]["cmontonum"].ToString();

            TextObject tex2 = sec.ReportObjects["Txt_Persona"] as TextObject;
            tex2.Text = _P_DT.Rows[0]["cpersona"].ToString();

            TextObject text3 = sec.ReportObjects["Txt_MontoDescrip"] as TextObject;
            text3.Text = _P_DT.Rows[0]["cmontodescrip"].ToString();

            TextObject text4 = sec.ReportObjects["Txt_MontoDescrip1"] as TextObject;
            text4.Text = _P_DT.Rows[0]["cmontodescrip1"].ToString();

            _Mtd_RedimMontoTxt(_P_DT.Rows[0]["cmontodescrip"].ToString() + _P_DT.Rows[0]["cmontodescrip1"].ToString(), text3, text4);

            TextObject text5 = sec.ReportObjects["Txt_Fecha"] as TextObject;
            text5.Text = _P_DT.Rows[0]["cfecha1"].ToString();

            TextObject text6 = sec.ReportObjects["Txt_Fecha1"] as TextObject;
            text6.Text = _P_DT.Rows[0]["cfecha2"].ToString();

            w.SetDataSource(_P_DT);
            w.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
            if (_P_Str_Reporte == "T3.Report.rPagoISRL" || _P_Str_Reporte == "T3.Report.rCajaCobDet" || _P_Str_Reporte == "T3.Report.rComprobRetencion" || _P_Str_Reporte == "T3.Report.rFactComparada2" || _P_Str_Reporte == "T3.Report.rInventValor" || _P_Str_Reporte == "T3.Report.rTarjetas")
            {
                w.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            }
            else
            {
                w.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            }
            crystalReportViewer1.ReportSource = w;
            try
            {
                crystalReportViewer1.PrintReport();
            }
            catch (Exception _Ex)
            {
                throw new Exception("Error al conectarse con la impresora" + _Ex.Message);
            }
        }

        private void _Mtd_RedimMontoTxt(string _Pr_Str_Monto, TextObject _Pr_TextA, TextObject _Pr_TextB)
        {
            string _Str_Texto = "";
            string _Str_TextoR = "";
            int _Int_C = 0;
            Graphics f = this.CreateGraphics();
            Font myFuente = new Font(_Pr_TextA.Font.FontFamily.Name, 8);

            string[] _Str_Cad;
            char[] delimiterChars = { ' ' };
            _Str_Cad = _Pr_Str_Monto.Split(delimiterChars);
            foreach (string _Str_A in _Str_Cad)
            {
                _Str_Texto = _Str_Texto + _Str_A + " ";
                if (f.MeasureString(_Str_Texto, myFuente).Width <= _Pr_TextA.Width)
                {
                    _Pr_TextA.Text = _Str_Texto;
                }
                else
                {
                    if (_Str_TextoR == "")
                    {
                        _Str_TextoR = _Str_Cad[_Int_C];
                    }
                    else
                    {
                        _Str_TextoR = _Str_TextoR + _Str_A + " ";
                    }
                    _Pr_TextB.Text = _Str_TextoR;
                }
                _Int_C++;
            }

        }

        //public REPORTESS(string[] tab, string formula, string _P_Str_Reporte, string secc, string cab, string rif, string nit)
        //{ }
        public REPORTESS(string[] tab, string formula, string _P_Str_Reporte, string secc, string cab, string rif, string nit, string _P_Str_Where, PrintDialog _P_PriN, bool _P_Bol_SINO)
        {
            //			tab2=tab;
            //
            // Necesario para admitir el Diseñador de Windows Forms
            //
            InitializeComponent();
            crystalReportViewer1.ResetText();
            string da = Program._MyClsCnn._mtd_conexion._g_Str_Stringconex;
            DataSet _Ds = new DataSet();
            try
            {
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'");
            }
            catch { }
            SqlConnection con = new SqlConnection(da);
            //			ju=con;
            //			rellenar();
            if (formula.Trim().Length > 0)
            {
                crystalReportViewer1.SelectionFormula = formula;
            }

            string[] a = new string[tab.Length + 3];
            SqlDataAdapter[] adap = new SqlDataAdapter[tab.Length];
            for (int i = 0; i <= tab.Length - 1; i++)
            {
                a[i] = "select * from " + tab[i].ToString() + " where " + _P_Str_Where;
                adap[i] = new SqlDataAdapter(a[i].ToString(), con);
                adap[i].Fill(dataSet21, tab[i]);

            }
            w = (ReportClass)Activator.CreateInstance(Type.GetType(_P_Str_Reporte));
            w.SetDataSource(dataSet21);
            /////////////////////////
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex1 = sec.ReportObjects["Txt_Rango"] as TextObject;
                tex1.Text = cab;

            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex1 = sec.ReportObjects["cabecera"] as TextObject;
                tex1.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex2 = sec.ReportObjects["Direccion"] as TextObject;
                tex2.Text = _Ds.Tables[0].Rows[0]["caddress"].ToString().Trim();
                TextObject text3 = sec.ReportObjects["Telefonos"] as TextObject;
                text3.Text = _Ds.Tables[0].Rows[0]["cphone1"].ToString().Trim() + " / " + _Ds.Tables[0].Rows[0]["cphone2"].ToString().Trim();
                TextObject text4 = sec.ReportObjects["Email"] as TextObject;
                text4.Text = _Ds.Tables[0].Rows[0]["cemail"].ToString().Trim();
                TextObject text5 = sec.ReportObjects["rif"] as TextObject;
                text5.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex6 = sec.ReportObjects["cabecera2"] as TextObject;
                tex6.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex7 = sec.ReportObjects["cabecera3"] as TextObject;
                tex7.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject text8 = sec.ReportObjects["rif"] as TextObject;
                text8.Text = _Ds.Tables[0].Rows[0]["crif"].ToString().Trim();
                TextObject text9 = sec.ReportObjects["rif2"] as TextObject;
                text9.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
                TextObject text10 = sec.ReportObjects["rif3"] as TextObject;
                text10.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex11 = sec.ReportObjects["cabecera"] as TextObject;
                tex11.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex12 = sec.ReportObjects["rif"] as TextObject;
                tex12.Text = _Ds.Tables[0].Rows[0]["crif"].ToString().Trim();
            }
            catch { }
            if (_P_Str_Reporte == "T3.Report.rTarjetas")
            {
                w.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)System.Drawing.Printing.PaperKind.LetterRotated;
                w.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            }
            else
            { w.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter; }
            crystalReportViewer1.ReportSource = w;

            if (_P_Bol_SINO)
            {
                var _PageSettings = new System.Drawing.Printing.PageSettings();
                _PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
                if (_P_Str_Reporte == "T3.Report.rPagoISRL" || _P_Str_Reporte == "T3.Report.rCajaCobDet" || _P_Str_Reporte == "T3.Report.rComprobRetencion" || _P_Str_Reporte == "T3.Report.rFactComparada2" || _P_Str_Reporte == "T3.Report.rInventValor" || _P_Str_Reporte == "T3.Report.rTarjetas")
                {
                    _PageSettings.Landscape = true;
                }
                else
                {
                    _PageSettings.Landscape = false;
                }
                var _PrtSettings = new System.Drawing.Printing.PrinterSettings { PrinterName = _P_PriN.PrinterSettings.PrinterName, Copies = _P_PriN.PrinterSettings.Copies, Collate = _P_PriN.PrinterSettings.Collate };
                try
                {
                    w.PrintToPrinter(_PrtSettings, _PageSettings, false);
                }
                catch (Exception _Ex)
                {
                    throw new Exception("Error al conectarse con la impresora" + _Ex.Message);
                }
            }
        }
        public REPORTESS(string[] tab, string[] tabName, string formula, string _P_Str_Reporte, string secc, string cab, string rif, string nit, string _P_Str_Where, PrintDialog _P_PriN, bool _P_Bol_SINO)
        {
            //			tab2=tab;
            //
            // Necesario para admitir el Diseñador de Windows Forms
            //
            InitializeComponent();
            crystalReportViewer1.ResetText();
            string da = Program._MyClsCnn._mtd_conexion._g_Str_Stringconex;
            DataSet _Ds = new DataSet();
            try
            {
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'");
            }
            catch { }
            SqlConnection con = new SqlConnection(da);
            //			ju=con;
            //			rellenar();
            if (formula.Trim().Length > 0)
            {
                crystalReportViewer1.SelectionFormula = formula;
            }

            string[] a = new string[tab.Length + 3];
            SqlDataAdapter[] adap = new SqlDataAdapter[tab.Length];
            for (int i = 0; i <= tab.Length - 1; i++)
            {
                a[i] = "select * from " + tab[i].ToString() + " where " + _P_Str_Where;
                adap[i] = new SqlDataAdapter(a[i].ToString(), con);
                adap[i].Fill(dataSet21, tabName[i]);

            }
            w = (ReportClass)Activator.CreateInstance(Type.GetType(_P_Str_Reporte));
            w.SetDataSource(dataSet21);
            /////////////////////////
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex1 = sec.ReportObjects["Txt_Rango"] as TextObject;
                tex1.Text = cab;

            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex1 = sec.ReportObjects["cabecera"] as TextObject;
                tex1.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex2 = sec.ReportObjects["Direccion"] as TextObject;
                tex2.Text = _Ds.Tables[0].Rows[0]["caddress"].ToString().Trim();
                TextObject text3 = sec.ReportObjects["Telefonos"] as TextObject;
                text3.Text = _Ds.Tables[0].Rows[0]["cphone1"].ToString().Trim() + " / " + _Ds.Tables[0].Rows[0]["cphone2"].ToString().Trim();
                TextObject text4 = sec.ReportObjects["Email"] as TextObject;
                text4.Text = _Ds.Tables[0].Rows[0]["cemail"].ToString().Trim();
                TextObject text5 = sec.ReportObjects["rif"] as TextObject;
                text5.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex6 = sec.ReportObjects["cabecera2"] as TextObject;
                tex6.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex7 = sec.ReportObjects["cabecera3"] as TextObject;
                tex7.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject text8 = sec.ReportObjects["rif"] as TextObject;
                text8.Text = _Ds.Tables[0].Rows[0]["crif"].ToString().Trim();
                TextObject text9 = sec.ReportObjects["rif2"] as TextObject;
                text9.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
                TextObject text10 = sec.ReportObjects["rif3"] as TextObject;
                text10.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex11 = sec.ReportObjects["cabecera"] as TextObject;
                tex11.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex12 = sec.ReportObjects["rif"] as TextObject;
                tex12.Text = _Ds.Tables[0].Rows[0]["crif"].ToString().Trim();
            }
            catch { }
            if (_P_Str_Reporte == "T3.Report.rTarjetas")
            {
                w.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)System.Drawing.Printing.PaperKind.LetterRotated;
                w.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            }
            else
            { w.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter; }

            crystalReportViewer1.ReportSource = w;

            if (_P_Bol_SINO)
            {
                var _PageSettings = new System.Drawing.Printing.PageSettings();
                _PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
                if (_P_Str_Reporte == "T3.Report.rPagoISRL" || _P_Str_Reporte == "T3.Report.rCajaCobDet" || _P_Str_Reporte == "T3.Report.rComprobRetencion" || _P_Str_Reporte == "T3.Report.rFactComparada2" || _P_Str_Reporte == "T3.Report.rInventValor" || _P_Str_Reporte == "T3.Report.rTarjetas")
                {
                    _PageSettings.Landscape = true;
                }
                else
                {
                    _PageSettings.Landscape = false;
                }
                var _PrtSettings = new System.Drawing.Printing.PrinterSettings { PrinterName = _P_PriN.PrinterSettings.PrinterName, Copies = _P_PriN.PrinterSettings.Copies, Collate = _P_PriN.PrinterSettings.Collate };
                try
                {
                    w.PrintToPrinter(_PrtSettings, _PageSettings, false);
                }
                catch (Exception _Ex)
                {
                    throw new Exception("Error al conectarse con la impresora" + _Ex.Message);
                }
            }
        }
        public REPORTESS(string[] tab, string formula, string _P_Str_Reporte, string secc, string cab, string rif, string nit, string _P_Str_Where, PrintDialog _P_PriN, bool _P_Bol_SINO, string _P_Str_Comp)
        {
            //			tab2=tab;
            //
            // Necesario para admitir el Diseñador de Windows Forms
            //
            InitializeComponent();
            crystalReportViewer1.ResetText();
            string da = Program._MyClsCnn._mtd_conexion._g_Str_Stringconex;
            DataSet _Ds = new DataSet();
            try
            {
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from TCOMPANY where ccompany='" + _P_Str_Comp + "'");
            }
            catch { }
            SqlConnection con = new SqlConnection(da);
            //			ju=con;
            //			rellenar();
            if (formula.Trim().Length > 0)
            {
                crystalReportViewer1.SelectionFormula = formula;
            }

            string[] a = new string[tab.Length + 3];
            SqlDataAdapter[] adap = new SqlDataAdapter[tab.Length];
            for (int i = 0; i <= tab.Length - 1; i++)
            {
                a[i] = "select * from " + tab[i].ToString() + " where " + _P_Str_Where;
                adap[i] = new SqlDataAdapter(a[i].ToString(), con);
                adap[i].Fill(dataSet21, tab[i]);

            }
            w = (ReportClass)Activator.CreateInstance(Type.GetType(_P_Str_Reporte));
            w.SetDataSource(dataSet21);
            /////////////////////////
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex1 = sec.ReportObjects["Txt_Rango"] as TextObject;
                tex1.Text = cab;

            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex1 = sec.ReportObjects["cabecera"] as TextObject;
                tex1.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex2 = sec.ReportObjects["Direccion"] as TextObject;
                tex2.Text = _Ds.Tables[0].Rows[0]["caddress"].ToString().Trim();
                TextObject text3 = sec.ReportObjects["Telefonos"] as TextObject;
                text3.Text = _Ds.Tables[0].Rows[0]["cphone1"].ToString().Trim() + " / " + _Ds.Tables[0].Rows[0]["cphone2"].ToString().Trim();
                TextObject text4 = sec.ReportObjects["Email"] as TextObject;
                text4.Text = _Ds.Tables[0].Rows[0]["cemail"].ToString().Trim();
                TextObject text5 = sec.ReportObjects["rif"] as TextObject;
                text5.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex6 = sec.ReportObjects["cabecera2"] as TextObject;
                tex6.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex7 = sec.ReportObjects["cabecera3"] as TextObject;
                tex7.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject text8 = sec.ReportObjects["rif"] as TextObject;
                text8.Text = _Ds.Tables[0].Rows[0]["crif"].ToString().Trim();
                TextObject text9 = sec.ReportObjects["rif2"] as TextObject;
                text9.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
                TextObject text10 = sec.ReportObjects["rif3"] as TextObject;
                text10.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex11 = sec.ReportObjects["cabecera"] as TextObject;
                tex11.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex12 = sec.ReportObjects["rif"] as TextObject;
                tex12.Text = _Ds.Tables[0].Rows[0]["crif"].ToString().Trim();
            }
            catch { }
            if (_P_Str_Reporte == "T3.Report.rTarjetas")
            {
                w.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)System.Drawing.Printing.PaperKind.LetterRotated;
                w.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            }
            else
            { w.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter; }

            crystalReportViewer1.ReportSource = w;

            if (_P_Bol_SINO)
            {
                var _PageSettings = new System.Drawing.Printing.PageSettings();
                _PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
                if (_P_Str_Reporte == "T3.Report.rPagoISRL" || _P_Str_Reporte == "T3.Report.rCajaCobDet" || _P_Str_Reporte == "T3.Report.rComprobRetencion" || _P_Str_Reporte == "T3.Report.rFactComparada2" || _P_Str_Reporte == "T3.Report.rInventValor" || _P_Str_Reporte == "T3.Report.rTarjetas")
                {
                    _PageSettings.Landscape = true;
                }
                else
                {
                    _PageSettings.Landscape = false;
                }
                var _PrtSettings = new System.Drawing.Printing.PrinterSettings { PrinterName = _P_PriN.PrinterSettings.PrinterName, Copies = _P_PriN.PrinterSettings.Copies, Collate = _P_PriN.PrinterSettings.Collate };
                try
                {
                    w.PrintToPrinter(_PrtSettings, _PageSettings, false);
                }
                catch (Exception _Ex)
                {
                    throw new Exception("Error al conectarse con la impresora" + _Ex.Message);
                }
            }
        }
        public REPORTESS(string[] tab, string formula, string _P_Str_Reporte, string secc, string cab, string rif, string nit, string _P_Str_Where)
        {
            InitializeComponent();
            crystalReportViewer1.ResetText();
            string da = Program._MyClsCnn._mtd_conexion._g_Str_Stringconex;
            DataSet _Ds = new DataSet();
            try
            {
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'");
            }
            catch { }
            SqlConnection con = new SqlConnection(da);
            //			ju=con;
            //			rellenar();
            if (formula.Trim().Length > 0)
            {
                crystalReportViewer1.SelectionFormula = formula;
            }

            string[] a = new string[tab.Length + 3];
            SqlDataAdapter[] adap = new SqlDataAdapter[tab.Length];
            for (int i = 0; i <= tab.Length - 1; i++)
            {
                a[i] = "select * from " + tab[i].ToString() + " where " + _P_Str_Where;
                adap[i] = new SqlDataAdapter(a[i].ToString(), con);
                adap[i].Fill(dataSet21, tab[i]);

            }
            w = (ReportClass)Activator.CreateInstance(Type.GetType(_P_Str_Reporte));
            w.SetDataSource(dataSet21);
            /////////////////////////
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex1 = sec.ReportObjects["cabecera"] as TextObject;
                tex1.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex2 = sec.ReportObjects["Direccion"] as TextObject;
                tex2.Text = _Ds.Tables[0].Rows[0]["caddress"].ToString().Trim();
                TextObject text3 = sec.ReportObjects["Telefonos"] as TextObject;
                text3.Text = _Ds.Tables[0].Rows[0]["cphone1"].ToString().Trim() + " / " + _Ds.Tables[0].Rows[0]["cphone2"].ToString().Trim();
                TextObject text4 = sec.ReportObjects["Email"] as TextObject;
                text4.Text = _Ds.Tables[0].Rows[0]["cemail"].ToString().Trim();
                TextObject text5 = sec.ReportObjects["rif"] as TextObject;
                text5.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
                //---------------------------------
            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex6 = sec.ReportObjects["cabecera2"] as TextObject;
                tex6.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex7 = sec.ReportObjects["cabecera3"] as TextObject;
                tex7.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject text8 = sec.ReportObjects["rif"] as TextObject;
                text8.Text = _Ds.Tables[0].Rows[0]["crif"].ToString().Trim();
                TextObject text9 = sec.ReportObjects["rif2"] as TextObject;
                text9.Text = _Ds.Tables[0].Rows[0]["crif"].ToString().Trim();
                TextObject text10 = sec.ReportObjects["rif3"] as TextObject;
                text10.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex11 = sec.ReportObjects["cabecera"] as TextObject;
                tex11.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex12 = sec.ReportObjects["rif"] as TextObject;
                tex12.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex1 = sec.ReportObjects["Txt_Rango"] as TextObject;
                tex1.Text = cab;
            }
            catch { }
            w.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
            if (_P_Str_Reporte == "T3.Report.rPagoISRL" || _P_Str_Reporte == "T3.Report.rCajaCobDet" || _P_Str_Reporte == "T3.Report.rComprobRetencion" || _P_Str_Reporte == "T3.Report.rFactComparada2" || _P_Str_Reporte == "T3.Report.rInventValor" || _P_Str_Reporte == "T3.Report.rTarjetas" || _P_Str_Reporte == "T3.Report.rComparativo")
            {
                w.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            }
            else
            {
                w.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            }
            crystalReportViewer1.ReportSource = w;

        }

        public REPORTESS(string[] tab, string formula, string _P_Str_Reporte, string secc, string cab, string rif, string nit, string _P_Str_CostoFijo, string _Pr_Str_CostoVar, string _P_Str_Costo, string _P_Str_Where, PrintDialog _P_PriN, bool _P_Bol_SINO)
        {
            //ESPECIAL PARA EL REPORTE DE GUIA DE DESPACHO
            InitializeComponent();
            crystalReportViewer1.ResetText();
            string da = Program._MyClsCnn._mtd_conexion._g_Str_Stringconex;
            DataSet _Ds = new DataSet();
            try
            {
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'");
            }
            catch { }
            SqlConnection con = new SqlConnection(da);
            //			ju=con;
            //			rellenar();
            if (formula.Trim().Length > 0)
            {
                crystalReportViewer1.SelectionFormula = formula;
            }

            string[] a = new string[tab.Length + 3];
            SqlDataAdapter[] adap = new SqlDataAdapter[tab.Length];
            for (int i = 0; i <= tab.Length - 1; i++)
            {
                a[i] = "select * from " + tab[i].ToString() + " where " + _P_Str_Where;
                adap[i] = new SqlDataAdapter(a[i].ToString(), con);
                adap[i].Fill(dataSet21, tab[i]);

            }
            w = (ReportClass)Activator.CreateInstance(Type.GetType(_P_Str_Reporte));
            w.SetDataSource(dataSet21);
            /////////////////////////
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex1 = sec.ReportObjects["cabecera"] as TextObject;
                tex1.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex2 = sec.ReportObjects["Direccion"] as TextObject;
                tex2.Text = _Ds.Tables[0].Rows[0]["caddress"].ToString().Trim();
                TextObject text3 = sec.ReportObjects["Telefonos"] as TextObject;
                text3.Text = _Ds.Tables[0].Rows[0]["cphone1"].ToString().Trim() + " / " + _Ds.Tables[0].Rows[0]["cphone2"].ToString().Trim();
                TextObject text4 = sec.ReportObjects["Email"] as TextObject;
                text4.Text = _Ds.Tables[0].Rows[0]["cemail"].ToString();
                TextObject text5 = sec.ReportObjects["rif"] as TextObject;
                text5.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex6 = sec.ReportObjects["cabecera2"] as TextObject;
                tex6.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex7 = sec.ReportObjects["cabecera3"] as TextObject;
                tex7.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject text8 = sec.ReportObjects["rif"] as TextObject;
                text8.Text = _Ds.Tables[0].Rows[0]["crif"].ToString().Trim();
                TextObject text9 = sec.ReportObjects["rif2"] as TextObject;
                text9.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
                TextObject text10 = sec.ReportObjects["rif3"] as TextObject;
                text10.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex11 = sec.ReportObjects["cabecera"] as TextObject;
                tex11.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex12 = sec.ReportObjects["rif"] as TextObject;
                tex12.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
            }
            catch { }
            try
            {
                Section sec1 = w.ReportDefinition.Sections["Section4"];
                TextObject tex6 = sec1.ReportObjects["Txt_costovariable"] as TextObject;
                tex6.Text = _Pr_Str_CostoVar;
                TextObject tex7 = sec1.ReportObjects["Txt_CostoFijo"] as TextObject;
                tex7.Text = _P_Str_CostoFijo;
                TextObject tex8 = sec1.ReportObjects["Txt_CostoDespacho"] as TextObject;
                tex8.Text = _P_Str_Costo;
            }
            catch
            { }
            crystalReportViewer1.ReportSource = w;
            if (_P_Bol_SINO)
            {
                var _PageSettings = new System.Drawing.Printing.PageSettings();
                _PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
                if (_P_Str_Reporte == "T3.Report.rPagoISRL" || _P_Str_Reporte == "T3.Report.rCajaCobDet" || _P_Str_Reporte == "T3.Report.rComprobRetencion" || _P_Str_Reporte == "T3.Report.rFactComparada2" || _P_Str_Reporte == "T3.Report.rInventValor" || _P_Str_Reporte == "T3.Report.rTarjetas")
                {
                    _PageSettings.Landscape = true;
                }
                else
                {
                    _PageSettings.Landscape = false;
                }
                var _PrtSettings = new System.Drawing.Printing.PrinterSettings { PrinterName = _P_PriN.PrinterSettings.PrinterName, Copies = _P_PriN.PrinterSettings.Copies, Collate = _P_PriN.PrinterSettings.Collate };
                try
                {
                    w.PrintToPrinter(_PrtSettings, _PageSettings, false);
                }
                catch (Exception _Ex)
                {
                    throw new Exception("Error al conectarse con la impresora" + _Ex.Message);
                }
            }
        }

        public REPORTESS(string[] tab, string[] tabName, string formula, string _P_Str_Reporte, string secc, string cab, string rif, string nit, string _P_Str_Where, PrintDialog _P_PriN, bool _P_Bol_SINO, bool _Bol_RequiereGuiaSada)
        {
            //			tab2=tab;
            //
            // Necesario para admitir el Diseñador de Windows Forms
            //
            InitializeComponent();
            crystalReportViewer1.ResetText();
            string da = Program._MyClsCnn._mtd_conexion._g_Str_Stringconex;
            DataSet _Ds = new DataSet();
            try
            {
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'");
            }
            catch { }
            SqlConnection con = new SqlConnection(da);
            //			ju=con;
            //			rellenar();
            if (formula.Trim().Length > 0)
            {
                crystalReportViewer1.SelectionFormula = formula;
            }

            string[] a = new string[tab.Length + 3];
            SqlDataAdapter[] adap = new SqlDataAdapter[tab.Length];
            for (int i = 0; i <= tab.Length - 1; i++)
            {
                a[i] = "select * from " + tab[i].ToString() + " where " + _P_Str_Where;
                adap[i] = new SqlDataAdapter(a[i].ToString(), con);
                adap[i].Fill(dataSet21, tabName[i]);

            }
            w = (ReportClass)Activator.CreateInstance(Type.GetType(_P_Str_Reporte));
            w.SetDataSource(dataSet21);
            /////////////////////////
            if (_Bol_RequiereGuiaSada)
            {
                Section sec = w.ReportDefinition.Sections["Section3"];
                TextObject _Txt_RequiereGuiaSada = sec.ReportObjects["Txt_RequiereGuiaSada"] as TextObject;
                _Txt_RequiereGuiaSada.Text = "***REQUIERE GUÍA SADA***";
            }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex1 = sec.ReportObjects["Txt_Rango"] as TextObject;
                tex1.Text = cab;

            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex1 = sec.ReportObjects["cabecera"] as TextObject;
                tex1.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex2 = sec.ReportObjects["Direccion"] as TextObject;
                tex2.Text = _Ds.Tables[0].Rows[0]["caddress"].ToString().Trim();
                TextObject text3 = sec.ReportObjects["Telefonos"] as TextObject;
                text3.Text = _Ds.Tables[0].Rows[0]["cphone1"].ToString().Trim() + " / " + _Ds.Tables[0].Rows[0]["cphone2"].ToString().Trim();
                TextObject text4 = sec.ReportObjects["Email"] as TextObject;
                text4.Text = _Ds.Tables[0].Rows[0]["cemail"].ToString().Trim();
                TextObject text5 = sec.ReportObjects["rif"] as TextObject;
                text5.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex6 = sec.ReportObjects["cabecera2"] as TextObject;
                tex6.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex7 = sec.ReportObjects["cabecera3"] as TextObject;
                tex7.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject text8 = sec.ReportObjects["rif"] as TextObject;
                text8.Text = _Ds.Tables[0].Rows[0]["crif"].ToString().Trim();
                TextObject text9 = sec.ReportObjects["rif2"] as TextObject;
                text9.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
                TextObject text10 = sec.ReportObjects["rif3"] as TextObject;
                text10.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex11 = sec.ReportObjects["cabecera"] as TextObject;
                tex11.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex12 = sec.ReportObjects["rif"] as TextObject;
                tex12.Text = _Ds.Tables[0].Rows[0]["crif"].ToString().Trim();
            }
            catch { }
            w.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
            crystalReportViewer1.ReportSource = w;
            if (_P_Bol_SINO)
            {
                var _PageSettings = new System.Drawing.Printing.PageSettings();
                _PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
                _PageSettings.Landscape = false;
                var _PrtSettings = new System.Drawing.Printing.PrinterSettings { PrinterName = _P_PriN.PrinterSettings.PrinterName, Copies = _P_PriN.PrinterSettings.Copies, Collate = _P_PriN.PrinterSettings.Collate };
                try
                {
                    w.PrintToPrinter(_PrtSettings, _PageSettings, false);
                }
                catch (Exception _Ex)
                {
                    throw new Exception("Error al conectarse con la impresora" + _Ex.Message);
                }
            }
        }

        public REPORTESS(string[] tab, string formula, string _P_Str_Reporte, string secc, string cab, string rif, string nit, string _P_Str_Where, PrintDialog _P_PriN, bool _P_Bol_SINO, bool _Bol_RequiereGuiaSada)
        {
            //			tab2=tab;
            //
            // Necesario para admitir el Diseñador de Windows Forms
            //
            InitializeComponent();
            crystalReportViewer1.ResetText();
            string da = Program._MyClsCnn._mtd_conexion._g_Str_Stringconex;
            DataSet _Ds = new DataSet();
            try
            {
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'");
            }
            catch { }
            SqlConnection con = new SqlConnection(da);
            //			ju=con;
            //			rellenar();
            if (formula.Trim().Length > 0)
            {
                crystalReportViewer1.SelectionFormula = formula;
            }

            string[] a = new string[tab.Length + 3];
            SqlDataAdapter[] adap = new SqlDataAdapter[tab.Length];
            for (int i = 0; i <= tab.Length - 1; i++)
            {
                a[i] = "select * from " + tab[i].ToString() + " where " + _P_Str_Where;
                adap[i] = new SqlDataAdapter(a[i].ToString(), con);
                adap[i].Fill(dataSet21, tab[i]);

            }
            w = (ReportClass)Activator.CreateInstance(Type.GetType(_P_Str_Reporte));
            w.SetDataSource(dataSet21);
            /////////////////////////
            if (_Bol_RequiereGuiaSada)
            {
                Section sec = w.ReportDefinition.Sections["Section3"];
                TextObject _Txt_RequiereGuiaSada = sec.ReportObjects["Txt_RequiereGuiaSada"] as TextObject;
                _Txt_RequiereGuiaSada.Text = "***REQUIERE GUÍA SADA***";
            }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex1 = sec.ReportObjects["Txt_Rango"] as TextObject;
                tex1.Text = cab;

            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex1 = sec.ReportObjects["cabecera"] as TextObject;
                tex1.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex2 = sec.ReportObjects["Direccion"] as TextObject;
                tex2.Text = _Ds.Tables[0].Rows[0]["caddress"].ToString().Trim();
                TextObject text3 = sec.ReportObjects["Telefonos"] as TextObject;
                text3.Text = _Ds.Tables[0].Rows[0]["cphone1"].ToString().Trim() + " / " + _Ds.Tables[0].Rows[0]["cphone2"].ToString().Trim();
                TextObject text4 = sec.ReportObjects["Email"] as TextObject;
                text4.Text = _Ds.Tables[0].Rows[0]["cemail"].ToString().Trim();
                TextObject text5 = sec.ReportObjects["rif"] as TextObject;
                text5.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex6 = sec.ReportObjects["cabecera2"] as TextObject;
                tex6.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex7 = sec.ReportObjects["cabecera3"] as TextObject;
                tex7.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject text8 = sec.ReportObjects["rif"] as TextObject;
                text8.Text = _Ds.Tables[0].Rows[0]["crif"].ToString().Trim();
                TextObject text9 = sec.ReportObjects["rif2"] as TextObject;
                text9.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
                TextObject text10 = sec.ReportObjects["rif3"] as TextObject;
                text10.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
            }
            catch { }
            try
            {
                Section sec = w.ReportDefinition.Sections[secc];
                TextObject tex11 = sec.ReportObjects["cabecera"] as TextObject;
                tex11.Text = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                TextObject tex12 = sec.ReportObjects["rif"] as TextObject;
                tex12.Text = _Ds.Tables[0].Rows[0]["crif"].ToString().Trim();
            }
            catch { }
            w.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
            crystalReportViewer1.ReportSource = w;

            if (_P_Bol_SINO)
            {
                var _PageSettings = new System.Drawing.Printing.PageSettings();
                _PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
                _PageSettings.Landscape = false;
                var _PrtSettings = new System.Drawing.Printing.PrinterSettings { PrinterName = _P_PriN.PrinterSettings.PrinterName, Copies = _P_PriN.PrinterSettings.Copies, Collate = _P_PriN.PrinterSettings.Collate };
                try
                {
                    w.PrintToPrinter(_PrtSettings, _PageSettings, false);
                }
                catch (Exception _Ex)
                {
                    throw new Exception("Error al conectarse con la impresora" + _Ex.Message);
                }
            }
        }
        //
        // TODO: agregar código de constructor después de llamar a InitializeComponent
        //


        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms
        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REPORTESS));
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.dataSet21 = new T3.DataSet2();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet21)).BeginInit();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(920, 493);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            this.crystalReportViewer1.Error += new CrystalDecisions.Windows.Forms.ExceptionEventHandler(this.crystalReportViewer1_Error);
            // 
            // dataSet21
            // 
            this.dataSet21.DataSetName = "DataSet2";
            this.dataSet21.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // REPORTESS
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(920, 493);
            this.Controls.Add(this.crystalReportViewer1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "REPORTESS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.REPORTESS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet21)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private void crystalReportViewer1_Error(object source, CrystalDecisions.Windows.Forms.ExceptionEventArgs e)
        {
            _Str_FrmErrorPrint = e.Exception.Message;
        }

 

        public void Dispose()
        {
            crystalReportViewer1.Dispose();
            w.Close();
            w.Dispose();
            w = null;
            GC.Collect();
            GC.SuppressFinalize(this);
        }

        private void REPORTESS_Load(object sender, EventArgs e)
        {

        }
    }
}
