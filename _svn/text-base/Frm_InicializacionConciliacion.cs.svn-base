using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using oExcel = Microsoft.Office.Interop.Excel;
using T3.Clases;
using T3.CLASES;

namespace T3
{
    public partial class Frm_InicializacionConciliacion : Form
    {
        #region Atributos

        private _Cls_Varios_Metodos oRutinas = new _Cls_Varios_Metodos(true);

        private string gRutaArchivo;

        #endregion

        #region Métodos

        public Frm_InicializacionConciliacion()
        {
            InitializeComponent();
        }

        private void cargarLibro(string pRuta, string pFechaLimite)
        {
            if (System.IO.File.Exists(pRuta))
            {
                string sComprobante, sCompañia = "", sCuenta = "", sMonto, sMes, sAño, sSQL = "", sWHERE = "";

                string[] oComprobante = new string[4];

                List<Libro> oLista = new List<Libro>();

                oExcel.Application oAplicacion = new oExcel.Application();
                oExcel.Workbook oLibro = oAplicacion.Workbooks.Open(pRuta);
                oExcel._Worksheet oHoja = (oExcel._Worksheet) oLibro.Sheets[1];
                oExcel.Range oRango = oHoja.UsedRange.Cells;

                int iTotalFilas = oRango.Cells.Rows.Count;

                // 1. Extraemos del Excel los comprobantes a desmarcar.

                for (int iFila = 0; iFila <= iTotalFilas; iFila++)
                {
                    if ((iFila > 2) && (oRango[iFila, 1].Value != null))
                    {
                        sCompañia = oRango[iFila, 1].Value.ToString();
                        sCompañia = sCompañia.Replace(" ", "");

                        sCuenta = oRango[iFila, 2].Value.ToString();
                        sCuenta = sCuenta.Replace(" ", "");

                        sComprobante = oRango[iFila, 3].Value.ToString();
                        sComprobante = sComprobante.Replace(" ", "");
                        oComprobante = sComprobante.Split(new Char[] { '-' });

                        sMonto = oRango[iFila, 6].Value.ToString();
                        sMonto = Convert.ToDouble(sMonto).ToString("F2");
                        sMonto = sMonto.Replace("-", "");
                        sMonto = sMonto.Replace(",", ".");

                        sSQL = "select cidcomprob from TCOMPROBANC";
                        sSQL += " where (ccompany='" + sCompañia + "' and ctypcomp='" + oComprobante[0] + "' and cmontacco=" + oComprobante[1] + " and cyearacco=" + oComprobante[2] + " and cidcorrel='" + oComprobante[3] + "' and cstatus=1)";

                        DataSet oResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);

                        if (oResultado.Tables[0].Rows.Count > 0)
                        {
                            oLista.Add(new Libro
                            {
                                Compañia = sCompañia,
                                Cuenta = sCuenta,
                                Tipo = oComprobante[0],
                                Mes = oComprobante[1],
                                Año = oComprobante[2],
                                Correlativo = oComprobante[3],
                                Monto = sMonto,
                                IdComprobante = oResultado.Tables[0].Rows[0]["cidcomprob"].ToString(),
                            });
                        }
                    }
                }

                oAplicacion.Quit();
                oAplicacion = null;

                if (oLista.Count > 0)
                {
                    foreach (Libro oFila in oLista)
                    {
                        sWHERE += ((sWHERE != "") ? " or " : " where ");
                        sWHERE += "(TCOMPROBAND.cidcomprob='" + oFila.IdComprobante + "' and TCOMPROBAND.ccompany='" + oFila.Compañia + "' and ccount='" + oFila.Cuenta + "' and (TCOMPROBAND.ctotdebe=" + oFila.Monto + " or TCOMPROBAND.ctothaber=" + oFila.Monto + "))";
                    }

                    sCompañia = oLista[0].Compañia;
                    sCuenta = oLista[0].Cuenta;
                }

                // 2. Marcamos todos los comprobantes como conciliados utilizando la fecha límite.

                sSQL = "update TCOMPROBAND set cconciliado=1 from TCOMPROBAND inner join TCOMPROBANC on TCOMPROBAND.ccompany = TCOMPROBANC.ccompany and TCOMPROBAND.cidcomprob = TCOMPROBANC.cidcomprob";
                sSQL += " where TCOMPROBAND.ccompany='" + sCompañia + "' and TCOMPROBAND.ccount='" + sCuenta + "' and TCOMPROBANC.cstatus=1 and TCOMPROBAND.cconciliado=0";
                sSQL += " and TCOMPROBANC.cregdate<=convert(datetime, '" + pFechaLimite + "', 103);";

                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(sSQL);

                // 3. Desmarcamos únicamente los comprobantes de la hoja de Excel.

                if (sWHERE != "")
                {
                    sSQL = "update TCOMPROBAND set cconciliado=0" + sWHERE;
                }

                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(sSQL);
            }
        }

        private void cargarBanco(string pRuta)
        {
            if (System.IO.File.Exists(pRuta))
            {
                string sCodigo, sCompañia, sCuenta, sBanco = "", sCuentaBancaria = "", sFecha1, sFecha2, sOperacion, sDocumento, sConcepto, sSQL = "";

                double dMonto, dTotal = 0;

                string[] oComprobante = new string[4];
                
                List<Banco> oLista = new List<Banco>();

                oExcel.Application oAplicacion = new oExcel.Application();
                oExcel.Workbook oLibro = oAplicacion.Workbooks.Open(pRuta);
                oExcel._Worksheet oHoja = (oExcel._Worksheet)oLibro.Sheets[2];
                oExcel.Range oRango = oHoja.UsedRange.Cells;

                int iTotalFilas = oRango.Cells.Rows.Count;

                // 1. Extraemos del Excel los bancos.

                for (int iFila = 0; iFila <= iTotalFilas; iFila++)
                {
                    if ((iFila > 2) && (oRango[iFila, 1].Value != null))
                    {
                        sCompañia = oRango[iFila, 1].Value.ToString();
                        sCompañia = sCompañia.Replace(" ", "");

                        sCuenta = oRango[iFila, 2].Value.ToString();
                        sCuenta = sCuenta.Replace(" ", "");

                        sFecha1 = oRango[iFila, 3].Value.ToString();
                        sFecha2 = oRango[iFila, 4].Value.ToString();

                        sOperacion = oRango[iFila, 5].Value.ToString();
                        sDocumento = oRango[iFila, 6].Value.ToString();
                        sConcepto = oRango[iFila, 7].Value.ToString();

                        dMonto = (Convert.ToDouble(oRango[iFila, 8].Value.ToString()) < 0) ? (Convert.ToDouble(oRango[iFila, 8].Value.ToString()) * -1) : Convert.ToDouble(oRango[iFila, 8].Value.ToString());

                        oLista.Add(new Banco
                        {
                            Compañia = sCompañia,
                            Cuenta = sCuenta,
                            Fecha = Convert.ToDateTime(sFecha1).ToShortDateString(),
                            Documento = sDocumento.Replace("'", "").Trim(),
                            Operacion = sOperacion,
                            Concepto = sConcepto,
                            Monto = dMonto
                        });
                    }
                }

                oAplicacion.Quit();
                oAplicacion = null;

                sCompañia = oLista[0].Compañia;
                sCuenta = oLista[0].Cuenta;
                sCodigo = oRutinas._Mtd_Correlativo("select max(cdispbanc) from TDISPBANC where ccompany='" + Frm_Padre._Str_Comp + "';");

                sSQL = "select cbanco, cnumcuenta from VST_CUENTBANCCOUNT where ccompany='" + sCompañia + "' and ccount='" + sCuenta + "';";

                DataSet oResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);

                if (oResultado.Tables[0].Rows.Count > 0)
                {
                    sBanco = oResultado.Tables[0].Rows[0]["cbanco"].ToString();
                    sCuentaBancaria = oResultado.Tables[0].Rows[0]["cnumcuenta"].ToString();
                }

                foreach (Banco oFila in oLista)
                {
                    dTotal += oFila.Monto;
                }

                // 3. Insertamos los datos en la base de datos.

                sSQL = "insert into TDISPBANC (ccompany, cdispbanc, cnumcuenta, cbanco, cfechacaptura, csaldobanco, cdateadd, cuseradd, cdelete, cregistroinicial) values (";
                sSQL += "'" + Frm_Padre._Str_Comp + "', '" + sCodigo + "', '" + sCuentaBancaria + "', '" + sBanco + "', getdate(), " + dTotal.ToString().Replace(',', '.') + ", getdate(), '" + Frm_Padre._Str_Use + "', 0, 1);";

                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(sSQL);

                int iIndiceFila = 1;

                foreach (Banco oFila in oLista)
                {
                    sSQL = "insert into TDISPBAND (ccompany, cdispbanc, cdispband, cbanco, cnumcuenta, cdatemovi, cnumdocu, ctipoperacio, cconcepto, cmontomov, csaldomov, coficinabanc) values (";
                    sSQL += "'" + Frm_Padre._Str_Comp + "', " + sCodigo + ", " + iIndiceFila.ToString() + ", '" + sBanco + "', '" + sCuentaBancaria + "', convert(datetime, '" + oFila.Fecha + "', 103), '" + oFila.Documento + "', '" + oFila.Operacion + "', '" + oFila.Concepto + "', " + oFila.Monto.ToString().Replace(',', '.') + ", 0, '0119');";

                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(sSQL);

                    iIndiceFila++;
                }
            }
        }

        private bool verificarArchivo(string pRuta, string pFechaLimite)
        {
            string sComprobante, sCompañia="", sCuenta="", sCompañiaVerificar, sCuentaVerificar, sSQL;

            string[] oComprobante = new string[4];

            bool bCompañiaDiferente = true, bCuentaDiferente = true, bFechaFueraRango = true, bCompañiaSistema = true, bTieneCuenta = true;

            DataSet oResultado;

            oExcel.Application oAplicacion = new oExcel.Application();
            oExcel.Workbook oLibro = oAplicacion.Workbooks.Open(pRuta);
            
            for (int iHoja = 1; iHoja <= 2; iHoja++)
            {
                oExcel._Worksheet oHoja = (oExcel._Worksheet)oLibro.Sheets[iHoja];
                oExcel.Range oRango = oHoja.UsedRange.Cells;

                int iTotalFilas = oRango.Cells.Rows.Count;

                for (int iFila = 0; iFila <= iTotalFilas; iFila++)
                {
                    if ((iFila > 2) && (oRango[iFila, 1].Value != null))
                    {
                        // 1. Validamos que la compañia sea la misma en todas las filas del archivo de Excel.

                        sCompañia = oRango[iFila, 1].Value.ToString();
                        sCompañia = sCompañia.Replace(" ", "");

                        for (int iIndice = 0; iIndice <= iTotalFilas; iIndice++)
                        {
                            if ((iIndice > 2) && (oRango[iIndice, 1].Value != null))
                            {
                                sCompañiaVerificar = oRango[iIndice, 1].Value.ToString();
                                sCompañiaVerificar = sCompañiaVerificar.Replace(" ", "");

                                if (sCompañia != sCompañiaVerificar)
                                {
                                    MessageBox.Show
                                    (
                                        "Verifica la columna del Cod. de compañía.",
                                        "Advertencia",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error
                                    );

                                    bCompañiaDiferente = false;

                                    break;
                                }
                            }
                        }

                        // 2. Validamos que la cuenta sea la misma en todas las filas del archivo de Excel.

                        sCuenta = oRango[iFila, 2].Value.ToString();
                        sCuenta = sCuenta.Replace(" ", "");

                        for (int iIndice = 0; iIndice <= iTotalFilas; iIndice++)
                        {
                            if ((iIndice > 2) && (oRango[iIndice, 1].Value != null))
                            {
                                sCuentaVerificar = oRango[iIndice, 2].Value.ToString();
                                sCuentaVerificar = sCuentaVerificar.Replace(" ", "");

                                if (sCuenta != sCuentaVerificar)
                                {
                                    MessageBox.Show
                                    (
                                        "Verifica la columna del Nro. de cuenta.",
                                        "Advertencia",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error
                                    );

                                    bCuentaDiferente = false;

                                    break;
                                }
                            }
                        }

                        // 3. Validamos las fechas de los comprobantes en el archivo de Excel no pase el límite establecido.

                        if (iFila == 1)
                        {
                            sComprobante = oRango[iFila, 2].Value.ToString();
                            sComprobante = sComprobante.Replace(" ", "");
                            oComprobante = sComprobante.Split(new Char[] { '-' });

                            sSQL = "select cregdate from TCOMPROBANC";
                            sSQL += " where (ccompany='" + sCompañia + "' and ctypcomp='" + oComprobante[0] + "' and cmontacco=" + oComprobante[1] + " and cyearacco=" + oComprobante[2] + " and cidcorrel='" + oComprobante[3] + "' and cstatus=1)";

                            oResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);

                            if (oResultado.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow oFila in oResultado.Tables[0].Rows)
                                {
                                    if (Convert.ToDateTime(oFila["cregdate"].ToString()) > Convert.ToDateTime(pFechaLimite))
                                    {
                                        MessageBox.Show
                                        (
                                            "El comprobante " + oRango[iFila, 3].Value.ToString() + " con fecha " + oFila["cregdate"].ToString() + " supera el límite establecido " + pFechaLimite + ".",
                                            "Advertencia",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error
                                        );

                                        bFechaFueraRango = false;

                                        break;
                                    }
                                }
                            }
                        }

                        // 4. Se verifica que compañía en el archivo de Excel sea la misma del sistema.

                        if (sCompañia.Trim() != Frm_Padre._Str_Comp.Trim())
                        {
                            MessageBox.Show
                            (
                                "El código de la compañia en la hoja #" + iHoja + " del archivo es diferente al de la empresa actual.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );

                            oAplicacion.Quit();
                            oAplicacion = null;

                            return false;
                        }

                        // 5. Se verifica si la cuenta contable del Excel tiene un banco y una cuenta bancaria.

                        if (iFila == 2)
                        {
                            sSQL = "select cbanco, cnumcuenta from VST_CUENTBANCCOUNT where ccompany='" + sCompañia + "' and ccount='" + sCuenta + "';";

                            oResultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(sSQL);

                            if (oResultado.Tables[0].Rows.Count == 0)
                            {
                                MessageBox.Show
                                (
                                    "La cuenta contable de la hoja #" + iHoja + " no tiene una cuenta bancaria para la compañía '" + sCompañia + "'.",
                                    "Advertencia",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );

                                bTieneCuenta = false;

                                break;
                            }
                        }
                    }
                }
            }

            oAplicacion.Quit();
            oAplicacion = null;

            return (bCompañiaDiferente && bCuentaDiferente && bFechaFueraRango && bCompañiaSistema && bTieneCuenta) ? true : false;
        }

        #endregion

        #region Eventos

        private void btSeleccionar_Click(object sender, EventArgs e)
        {
            dlgAbrir.Filter = "Excel|*.xls;*.xlsx";
            dlgAbrir.DefaultExt = ".xls|.xlsx";
            dlgAbrir.ShowDialog();

            gRutaArchivo = dlgAbrir.FileName;

            btInicializar.Enabled = (gRutaArchivo != "") ? true : false;
        }

        private void btInicializar_Click(object sender, EventArgs e)
        {
            if (gRutaArchivo == "")
            {
                MessageBox.Show("Selecciona un archivo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            Cursor = Cursors.WaitCursor;

            if (verificarArchivo(gRutaArchivo, dpFechaFinal.Value.ToShortDateString()))
            {
                if (MessageBox.Show("¿Deseas inicializar la conciliación al " + dpFechaFinal.Value.ToShortDateString() + "?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    cargarLibro(gRutaArchivo, dpFechaFinal.Value.ToShortDateString());
                    cargarBanco(gRutaArchivo);

                    MessageBox.Show("Finalizó el proceso correctamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            Cursor = Cursors.Arrow;
        }

        #endregion

        #region Clases

        private class Libro
        {
            public string Compañia { get; set; }
            public string Cuenta { get; set; }
            public string Tipo { get; set; }
            public string Mes { get; set; }
            public string Año { get; set; }
            public string Correlativo { get; set; }
            public string Monto { get; set; }
            public string IdComprobante { get; set; }
        }

        private class Banco
        {
            public string Compañia { get; set; }
            public string Cuenta { get; set; }
            public string Fecha { get; set; }
            public string Operacion { get; set; }
            public string Documento { get; set; }
            public string Concepto { get; set; }
            public double Monto { get; set; }
        }

        #endregion
    }
}