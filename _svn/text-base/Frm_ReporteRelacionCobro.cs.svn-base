using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
namespace T3
{
    public partial class Frm_ReporteRelacionCobro : Form
    {
        public Frm_ReporteRelacionCobro()
        {
            InitializeComponent();
        }
        public Frm_ReporteRelacionCobro(string _P_Str_cgroupcompany, string _P_Str_ccompany, string _P_Str_Cguiddesp, string _P_Str_cidrelacobro, bool _P_Bol_EsVerificacion)
        {
            InitializeComponent();
            _Mtd_GenerarReporte(_P_Str_cgroupcompany, _P_Str_ccompany, _P_Str_Cguiddesp, _P_Str_cidrelacobro, _P_Bol_EsVerificacion);
        }
        private void _Mtd_GenerarReporte(string _P_Str_cgroupcompany, string _P_Str_ccompany, string _P_Str_Cguiddesp, string _P_Str_cidrelacobro, bool _P_Bol_EsVerificacion)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string _Str_Cadena = "";
                DataSet _Ds;
                //Inicializamos el reporte
                Report.rResumenCobranza _MyReport = new Report.rResumenCobranza();
                //Cargamos los datos para el reporte principal
                //_Str_Cadena = "SELECT * FROM VST_RC_REPORTE_MAESTRA WHERE cgroupcomp='" + _P_Str_cgroupcompany + "' AND ccompany='" + _P_Str_ccompany + "' AND cidrelacobro='" + _P_Str_cidrelacobro + "' AND cguiadesp='" + _P_Str_Cguiddesp + "'";
                _Str_Cadena = "EXEC PA_RC_INGRESADAS_RESUMEN_MAESTRA '" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Cguiddesp + "', '" + _P_Str_cidrelacobro + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _MyReport.SetDataSource(_Ds.Tables[0]);
                //Recorremos y cargamos los datos para los subreportes
                for (int _I = 0; _I < _MyReport.Subreports.Count; _I++)
                {
                    if (_MyReport.Subreports[_I].Name == "CLIENTES_DOCUMENTOS")
                    {
                        //_Str_Cadena = "SELECT CONVERT(VARCHAR,[Cliente],103) AS [Cliente],[Nombre del Cliente],[Documento],[MontoRetencion],[MontoNotasDeCredito],[MontoCheques],[MontoDepositos],[MontoCobrado] FROM [VST_RC_INGRESADAS_RESUMEN_CLIENTES] WHERE cidrelacobro='" + _P_Str_cidrelacobro + "'";
                        _Str_Cadena = "EXEC PA_RC_INGRESADAS_RESUMEN_CLIENTES '" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Cguiddesp + "', '" + _P_Str_cidrelacobro + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                    }
                    else if (_MyReport.Subreports[_I].Name == "CHEQUES")
                    {
                        //_Str_Cadena = "SELECT [Nº Cheque],[Banco],[Fecha],[Monto] FROM [VST_RC_INGRESADAS_RESUMEN_CHEQUES] WHERE cidrelacobro='" + _P_Str_cidrelacobro + "'";
                        _Str_Cadena = "EXEC PA_RC_INGRESADAS_RESUMEN_CHEQUES '" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Cguiddesp + "', '" + _P_Str_cidrelacobro + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                    }
                    else if (_MyReport.Subreports[_I].Name == "DEPOSITOS")
                    {
                        //_Str_Cadena = "SELECT [Nº Depósito],[Fecha],[Banco],[Cuenta],[Monto] FROM [VST_RC_INGRESADAS_RESUMEN_DEPOSITOS] WHERE cidrelacobro='" + _P_Str_cidrelacobro + "'";
                        _Str_Cadena = "EXEC PA_RC_INGRESADAS_RESUMEN_DEPOSITOS '" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Cguiddesp + "', '" + _P_Str_cidrelacobro + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                    }
                    else if (_MyReport.Subreports[_I].Name == "RETENCIONES")
                    {
                        //_Str_Cadena = "SELECT [Cliente],[Nº],[Tipo],[Nº Comprobante],[Monto Comprobante],[Nº Control],[Fecha Comprobante]  FROM [VST_RC_INGRESADAS_RESUMEN_RETENCIONES] WHERE cidrelacobro='" + _P_Str_cidrelacobro + "'";
                        _Str_Cadena = "EXEC PA_RC_INGRESADAS_RESUMEN_RETENCIONES '" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Cguiddesp + "', '" + _P_Str_cidrelacobro + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                    }
                    else if (_MyReport.Subreports[_I].Name == "SOBRANTEFALTANTE")
                    {
                        //_Str_Cadena = "EXEC PA_RC_CALCULO_SOBRANTE_FALTANTE_GUIA '" + _P_Str_cgroupcompany + "', '0' ,'" + _P_Str_cidrelacobro + "'";
                        _Str_Cadena = "EXEC PA_RC_INGRESADAS_RESUMEN_SOBRANTEFALTANTE '" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Cguiddesp + "', '" + _P_Str_cidrelacobro + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                    }
                    else if (_MyReport.Subreports[_I].Name == "GUIASGENERADAS")
                    {
                        //_Str_Cadena = "SELECT TRELACCOBM.cidrelacobro AS [Id Relación], (RTRIM(LTRIM(TCOMPANY.ccompany)) COLLATE database_default + ' - ' + RTRIM(LTRIM(TCOMPANY.cname)) COLLATE database_default) AS [Compañia] FROM TRELACCOBM INNER JOIN TCOMPANY ON TRELACCOBM.ccompany = TCOMPANY.ccompany WHERE (TRELACCOBM.cdelete = 0) AND (TRELACCOBM.cguiacobro = '" + _G_Str_Cguiddesp + "')";
                        _Str_Cadena = "EXEC PA_RC_INGRESADAS_RESUMEN_GUIASGENERADAS '" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Cguiddesp + "', '" + _P_Str_cidrelacobro + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                    }
                }

                //Ocultamos el subreporte Guias Generadas para cuando es por Guia
                if (_P_Str_cidrelacobro != "0")
                {
                    _MyReport.ReportDefinition.Sections["DetailSection5"].SectionFormat.EnableSuppress = true;
                }

                //Cambiamos los Titulos del Reporte
                var _Txt_Titulo1 = "";
                _Str_Cadena = "SELECT cname FROM TCOMPANY WHERE ccompany = '" + _P_Str_ccompany + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_Titulo1 = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim().ToUpper();
                }

                var _Txt_Titulo2 = "";
                if (_P_Str_Cguiddesp != "0") //SI ES POR GUIA
                {
                    _Txt_Titulo1 = "";
                    if (_P_Bol_EsVerificacion)
                        _Txt_Titulo2 = "(VERIFICACION) RESUMEN DE COBRANZA DE LA GUÍA #" + _P_Str_Cguiddesp;
                    else
                        _Txt_Titulo2 = "RESUMEN DE COBRANZA DE LA GUÍA #" + _P_Str_Cguiddesp;
                }
                else  //SI ES POR RELACION
                {
                    if (_P_Bol_EsVerificacion)
                        _Txt_Titulo2 = "(VERIFICACION) RESUMEN DE COBRANZA DE LA RELACIÓN #" + _P_Str_cidrelacobro;
                    else
                        _Txt_Titulo2 = "RESUMEN DE COBRANZA DE LA RELACIÓN #" + _P_Str_cidrelacobro;
                }

                //Pasamos los valores del Titulo 1
                var _TxtTitulo1 = _MyReport.ReportDefinition.Sections["Section2"].ReportObjects["Txt_Titulo1"] as TextObject;
                _TxtTitulo1.Text = _Txt_Titulo1.ToUpper();

                //Pasamos los valores del Titulo 2
                var _TxtTitulo2 = _MyReport.ReportDefinition.Sections["Section2"].ReportObjects["Txt_Titulo2"] as TextObject;
                _TxtTitulo2.Text = _Txt_Titulo2.ToUpper();




                _MyReport.Refresh();


                _Rpv_Main.ReportSource = _MyReport;
                _Rpv_Main.RefreshReport();
                Cursor = Cursors.Default;
                //---Configuración de impresión.
                //_Frm.Close();
                GC.Collect();
            }
            catch (Exception _Ex)
            {
                MessageBox.Show(_Ex.Message);
            }
        }
    }
}
