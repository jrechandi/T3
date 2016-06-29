using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Threading;
using Application = Microsoft.Office.Interop.Excel.Application;
using Microsoft.Office.Interop.Excel;
using T3;
using System.Globalization;
using System.Text.RegularExpressions;


namespace T3.Clases
{
    public class _Cls_RutinasInterfazBancaria
    {
        /// <summary>
        /// Indica si el archivo seleccionado tiene extension ASCII, (.TXT)
        /// </summary>
        /// <param name="_P_Str_FileName">Ruta y Nombre de Archivo</param>
        /// <returns></returns>
        public static bool _Mtd_EsAscii(string _P_Str_FileName)
        {
            var archivo = new FileInfo(_P_Str_FileName);
            return archivo.Extension.Equals(".txt");
        }
        /// <summary>
        /// Indica si el archivo seleccionado tiene extension CSV, (.CSV)
        /// </summary>
        /// <param name="_P_Str_FileName">Ruta y Nombre de Archivo</param>
        /// <returns></returns>
        public static bool _Mtd_EsCsv(string _P_Str_FileName)
        {
            var archivo = new FileInfo(_P_Str_FileName);
            return archivo.Extension.Equals(".csv");
        }
        /// <summary>
        /// Indica si el archivo seleccionado tiene extension EXCEL (.XLS o XLSX)
        /// </summary>
        /// <param name="_P_Str_FileName">Ruta y Nombre de Archivo</param>
        /// <returns></returns>
        public static bool _Mtd_EsExcel(string _P_Str_FileName)
        {
            var archivo = new FileInfo(_P_Str_FileName);
            return archivo.Extension.Equals(".xls") || archivo.Extension.Equals(".xlsx");
        }
        /// <summary>
        /// Carga el archivo (ascii o csv) segun los parametros y lo convierte en Dataset
        /// </summary>
        /// <param name="_Pr_Str_File">Ruta y Nombre de Archivo</param>
        /// <param name="_Pr_Delimitadores">Delimitadores de Campos</param>
        /// <param name="_Str_LineaInicioDatos">Linea de Inicio de Datos</param>
        /// <returns></returns>
        public static DataSet _Mtd_ObtenerDsDesdeArchivo(string _Pr_Str_File, string[] _Pr_Delimitadores, int _Str_LineaInicioDatos)
        {
            int _Int_Fila = 0;
            int _Int_Columna = 0;
            int _Int_I = 0;
            int _Int_NumeroDeFilas = 0;
            int _Int_NumeroDeColumnas = 0;
            DataSet _Ds_Nuevo = new DataSet();
            DataRow _Dr_FilaNueva;
            DataColumn _Dc_ColumnaNueva;
            System.Data.DataTable _Dt_Tabla = new System.Data.DataTable();
            string sLine = "";


            //Cursor en Espera
            //Cursor = Cursors.WaitCursor;
            //Inicializo el Lecto de Archivos
            StreamReader objReader = new StreamReader(_Pr_Str_File);

            //Si tengo que saltar las lineas, leo tantas lineas como deba saltar
            if (_Str_LineaInicioDatos > 1)
            {
                for (int _Int_Linea = 1; _Int_Linea < _Str_LineaInicioDatos; _Int_Linea++)
                {
                    sLine = objReader.ReadLine();
                }

            }
            while (sLine != null)
            {
                //Leo linea a linea desde el archivo
                sLine = objReader.ReadLine();

                //verifico que la linea leida no sea nula
                if (sLine != null)
                {
                    //Pasamos toda la linea a mayuscula
                    sLine = sLine.ToUpper();

                    //Verifico que la linea leida no este vacia
                    if (sLine.Trim().Length > 0)
                    {

                        //Separo la Linea mediante los delimitadores
                        string[] words = sLine.Split(_Pr_Delimitadores, StringSplitOptions.None);

                        //Creamos las Columnas
                        for (_Int_Columna = 0; _Int_Columna < words.Length; _Int_Columna++)
                        {
                            if (words.Length > _Int_NumeroDeColumnas)
                            {
                                if ((_Int_Columna + 1) > _Int_NumeroDeColumnas)
                                {
                                    _Dc_ColumnaNueva = new DataColumn("Columna_" + _Int_Columna);
                                    _Dt_Tabla.Columns.Add(_Dc_ColumnaNueva);
                                    _Int_NumeroDeColumnas++;
                                }
                            }
                        }

                        // Generamos cada fila y pasamos los datos del grid a la fila correspondiente
                        _Dr_FilaNueva = _Dt_Tabla.NewRow();
                        for (_Int_Columna = 0; _Int_Columna < words.Length; _Int_Columna++)
                        {
                            _Dr_FilaNueva[_Int_Columna] = words[_Int_Columna];
                        }
                        _Dt_Tabla.Rows.Add(_Dr_FilaNueva);

                    }
                }
            }
            //Guardo La Tabla en el Dataset
            _Ds_Nuevo.Tables.Add(_Dt_Tabla);
            //Ciero el archivo
            objReader.Close();
            //Cursor Normal
            //Cursor = Cursors.Default;
            //Devuelvo
            return _Ds_Nuevo;
        }
        /// <summary>
        /// Carga el Archivo de Excel y lo convierte en Dataset
        /// </summary>
        /// <param name="_P_Str_FileName">Ruta y Nombre de Archivo</param>
        /// <returns></returns>
        public static DataSet _Mtd_GetExcel(string _P_Str_FileName)
        {
            Application _Apl_Xl;
            Workbook _Wrk_Wb;
            Worksheet _Wrks_Sheet;
            Range _Rng_Rango;
            try
            {
                _Apl_Xl = new Application();
                _Wrk_Wb = _Apl_Xl.Workbooks.Open(_P_Str_FileName, Missing.Value, Missing.Value,
                                         Missing.Value, Missing.Value, Missing.Value,
                                         Missing.Value, Missing.Value, Missing.Value,
                                         Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                         true, Missing.Value);

                _Wrks_Sheet = (Worksheet)_Wrk_Wb.Sheets[1];
                var _Dtb_Tabla = new System.Data.DataTable("dtExcel");
                var _Ds_DataSet = new DataSet();
                _Ds_DataSet.Tables.Add(_Dtb_Tabla);
                DataRow _Row_Fila;

                var _Int_JValue = _Wrks_Sheet.UsedRange.Cells.Columns.Count;
                var _Int_IValue = _Wrks_Sheet.UsedRange.Cells.Rows.Count + _Wrks_Sheet.UsedRange.Row;
                for (var _Int_J = 1; _Int_J <= _Int_JValue; _Int_J++)
                {
                    _Dtb_Tabla.Columns.Add("column" + _Int_J, Type.GetType("System.String"));
                }

                for (int _Int_I = 1; _Int_I <= _Int_IValue; _Int_I++)
                {
                    _Row_Fila = _Ds_DataSet.Tables["dtExcel"].NewRow();
                    for (var _Int_J = 1; _Int_J <= _Int_JValue; _Int_J++)
                    {
                        _Rng_Rango = (Range)_Wrks_Sheet.Cells[_Int_I, _Int_J];
                        string _Str_Value = _Rng_Rango.Text.ToString(); //Original
                        _Str_Value = _Str_Value.ToUpper();
                        if (_Str_Value.Contains("#######"))
                        {
                           //Tomo la Formula
                            string _StrValor = _Rng_Rango.FormulaR1C1Local.ToString();
                            _Str_Value = _StrValor.ToUpper();
                        }
                        _Row_Fila["column" + _Int_J] = _Str_Value;
                    }
                    _Ds_DataSet.Tables["dtExcel"].Rows.Add(_Row_Fila);
                }
                _Wrks_Sheet = null;
                _Wrk_Wb.Close(false, _P_Str_FileName, Missing.Value);
                _Wrk_Wb = null;
                _Apl_Xl.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_Apl_Xl);
                _Apl_Xl = null;
                GC.Collect();
                return _Ds_DataSet;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Limpia el DataSet de datos no válidos
        /// </summary>
        /// <param name="_P_Ds_DataSet"></param>
        /// <param name="_P_Int_LineaInicioDatos"></param>
        /// <returns></returns>
        public static DataSet _Mtd_ConfigurarDataSet(DataSet _P_Ds_DataSet, int _P_Int_LineaInicioDatos, int _P_Int_ColumnaFinalDatos = 0, int _P_Int_CantColuVaciasPermi = 1)
        {
            int _Int_Fila;
            int _Int_Columna;

            // - - - - - - - - - - - - - - - - Elimino las Lineas que especifico el usuario - - - - - - - - - - - - - - - - 
            _Int_Fila = 1;
            while (_Int_Fila < _P_Int_LineaInicioDatos)
            {
                _P_Ds_DataSet.Tables[0].Rows[0].Delete();         //Remuevo la Primera Fila
                _Int_Fila++;                                    //Avanzo
            }

            //Elimino las Filas que esten totalmente en Blanco
            _Int_Fila = 0;
            while (_Int_Fila < _P_Ds_DataSet.Tables[0].Rows.Count)
            {
                bool _Bol_ConDatos = false;
                for (_Int_Columna = 0; _Int_Columna < _P_Ds_DataSet.Tables[0].Columns.Count; _Int_Columna++)
                {
                    if (!string.IsNullOrEmpty(_P_Ds_DataSet.Tables[0].Rows[_Int_Fila][_Int_Columna].ToString()))
                    {
                        _Bol_ConDatos = true;
                        break;
                    }
                }
                //Si la fila esta vacia la elimino
                if (!_Bol_ConDatos)
                {
                    _P_Ds_DataSet.Tables[0].Rows[_Int_Fila].Delete();     //Remuevo
                }
                else
                {
                    _Int_Fila++;                                //Avanzo
                }
            }

            // - - - - - - - - - - - - - - - - Elimino Las Columnas que esten totalmente en blanco - - - - - - - - - - - - - - - - 
            _Int_Columna = 0;
            while (_Int_Columna < _P_Ds_DataSet.Tables[0].Columns.Count)
            {
                bool _Bol_Convalor = false;
                //Obtengo los Valores de Toda la Columna
                for (_Int_Fila = 0; _Int_Fila < _P_Ds_DataSet.Tables[0].Rows.Count; _Int_Fila++)
                {
                    //Si hay algun valor, lo guardo y salto a la siguiente columna
                    if (!string.IsNullOrEmpty(_P_Ds_DataSet.Tables[0].Rows[_Int_Fila][_Int_Columna].ToString()))
                    {
                        _Bol_Convalor = true;
                        break;
                    }
                }
                //Si la Columna esta vacia la elimino
                if (!_Bol_Convalor)
                {
                    //Solo si se pasa el parametro
                    if (_P_Int_ColumnaFinalDatos > 0)
                    {
                        //Solo si la columna esta posterior a la ultima columna de datos
                        if (_Int_Columna > _P_Int_ColumnaFinalDatos) _P_Ds_DataSet.Tables[0].Columns.RemoveAt(_Int_Columna); //Remuevo
                    }
                    else
                    {
                        _P_Ds_DataSet.Tables[0].Columns.RemoveAt(_Int_Columna); //Remuevo
                    }
                }
                _Int_Columna++; //Avanzo
            }

            //// - - - - - - - - - - - - - - - - Detecto las Columnas que contienen datos en funcion a la primera fila - - - - - - - - - - - - - - - - 
            //List<int> _Int_ColumnasConDatos = new List<int>();
            //for (_Int_Columna = 0; _Int_Columna < _P_Ds_DataSet.Tables[0].Columns.Count; _Int_Columna++)
            //{
            //    if (!string.IsNullOrEmpty(_P_Ds_DataSet.Tables[0].Rows[0][_Int_Columna].ToString()))
            //    {
            //        _Int_ColumnasConDatos.Add(_Int_Columna);
            //    }
            //}

            // - - - - - - - - - - - - - - - - Detecto las Columnas que contienen datos (total de columnas) - - - - - - - - - - - - - - - - 
            List<int> _Int_ColumnasConDatos = new List<int>();
            for (_Int_Fila = 0; _Int_Fila < _P_Ds_DataSet.Tables[0].Rows.Count; _Int_Fila++)
            {
                for (_Int_Columna = 0; _Int_Columna < _P_Ds_DataSet.Tables[0].Columns.Count; _Int_Columna++)
                {
                    if ((_Int_ColumnasConDatos.Count - 1) < _Int_Columna)
                    {
                        _Int_ColumnasConDatos.Add(_Int_Columna);
                    }
                }
            }

            //En funcion a las columnas detectadas, comparo todas las filas y elimino las filas que no tengan datos en todas ellas
            _Int_Fila = 0;
            int _Int_IndicePrimeraColumnaPermitidaVacia = 0;
            int _Int_IndiceSegundaColumnaPermitidaVacia = 0;
            int _Int_ContadorDeColumnasVacias = 0;

            while (_Int_Fila < _P_Ds_DataSet.Tables[0].Rows.Count)
            {
                bool _Bol_BorrarFila = false;
                _Int_ContadorDeColumnasVacias = 0;

                foreach (int _Int_ColumnaArevisar in _Int_ColumnasConDatos)
                {
                    if (string.IsNullOrEmpty(_P_Ds_DataSet.Tables[0].Rows[_Int_Fila][_Int_ColumnaArevisar].ToString()))
                    {
                        //Si se pasaron de cantidad de columnas vacias
                        if (_Int_ContadorDeColumnasVacias > (_P_Int_CantColuVaciasPermi))
                        {
                            //Indico borrar
                            _Bol_BorrarFila =  true;
                            //Inicializo
                            _Int_ContadorDeColumnasVacias = 0;
                        }
                        else
                        {
                            //Cuento
                            _Int_ContadorDeColumnasVacias++;
                            //Guardo los Indices
                            if (_Int_IndicePrimeraColumnaPermitidaVacia == 0)
                            {
                                _Int_IndicePrimeraColumnaPermitidaVacia = _Int_ColumnaArevisar; //Guardo el Primer Indice
                            }
                            else if (_Int_IndiceSegundaColumnaPermitidaVacia == 0)
                            {
                                _Int_IndiceSegundaColumnaPermitidaVacia = _Int_ColumnaArevisar; //Guardo el Primer Indice
                            }
                        }
                    }
                }
                //Si se pasaron de cantidad de columnas vacias
                if (_Int_ContadorDeColumnasVacias > (_P_Int_CantColuVaciasPermi))
                {
                    //Indico borrar
                    _Bol_BorrarFila = true;
                }
                //Si hay que borrarla
                if (_Bol_BorrarFila)
                {
                    _P_Ds_DataSet.Tables[0].Rows[_Int_Fila].Delete();     //Remuevo
                }
                else
                {
                    _Int_Fila++; //Avanzo
                }
            }

            //Si tiene alguna celda la palabra saldo la elimino
            _Int_Fila = 0;
            while (_Int_Fila < _P_Ds_DataSet.Tables[0].Rows.Count)
            {
                bool _Bol_BorrarFila_SaldoInicial = false;
                bool _Bol_BorrarFila_SaldoFinal = false;
                foreach (int _Int_ColumnaArevisar in _Int_ColumnasConDatos)
                {
                    if (_P_Ds_DataSet.Tables[0].Rows[_Int_Fila][_Int_ColumnaArevisar].ToString().ToUpper().IndexOf("SALDO INICIAL", StringComparison.Ordinal) != -1)
                    {
                        //Indico borrar
                        _Bol_BorrarFila_SaldoInicial = true;
                    }
                    if (_P_Ds_DataSet.Tables[0].Rows[_Int_Fila][_Int_ColumnaArevisar].ToString().ToUpper().IndexOf("SALDO FINAL", StringComparison.Ordinal) != -1)
                    {
                        //Indico borrar
                        _Bol_BorrarFila_SaldoFinal = true;
                    }
                }
                //Si hay que borrarla
                if (_Bol_BorrarFila_SaldoInicial & _Bol_BorrarFila_SaldoFinal)
                {
                    _P_Ds_DataSet.Tables[0].Rows[_Int_Fila].Delete();     //Remuevo
                }
                else
                {
                    _Int_Fila++; //Avanzo
                }
            }

            //Limpio Los campos si viene con doble comilla
            _Int_Fila = 0;
            while (_Int_Fila < _P_Ds_DataSet.Tables[0].Rows.Count)
            {
                _Int_Columna = 0;
                while (_Int_Columna < _P_Ds_DataSet.Tables[0].Columns.Count)
                {
                    string _Str_ValorCelda = _P_Ds_DataSet.Tables[0].Rows[_Int_Fila][_Int_Columna].ToString();
                    long _Int_CantidadDeComillasDobles = _Str_ValorCelda.LongCount(Letra => Letra.ToString() == "\"");
                    if (_Int_CantidadDeComillasDobles >= 1)
                    {
                        _Str_ValorCelda = _Str_ValorCelda.Replace("\"", "");
                        _P_Ds_DataSet.Tables[0].Rows[_Int_Fila][_Int_Columna] = _Str_ValorCelda;
                    }
                    _Int_Columna++;
                }
                _Int_Fila++;
            }


            //Devuelvo
            return _P_Ds_DataSet;
        }
        /// <summary>
        /// Exporta de DataGridView a Dataset
        /// </summary>
        /// <param name="_P_Dgv_Grid"></param>
        /// <returns></returns>
        public static DataSet _Mtd_ExportarDeDataGridViewADataSet(DataGridView _P_Dgv_Grid)
        {
            try
            {
                DataSet _Ds_Nuevo = new DataSet();
                DataRow _Dr_FilaNueva;
                DataColumn _Dc_ColumnaNueva;
                System.Data.DataTable _Dt_Tabla = new System.Data.DataTable();
                int _Int_NumeroDeColumnas;

                //Creamos las Columnas
                _Int_NumeroDeColumnas = _P_Dgv_Grid.ColumnCount;
                for (int _Int_Columna = 0; _Int_Columna < _Int_NumeroDeColumnas; _Int_Columna++)
                {
                    _Dc_ColumnaNueva = new DataColumn("Columna_" + _Int_Columna);
                    _Dt_Tabla.Columns.Add(_Dc_ColumnaNueva);
                }

                // Generamos cada fila y pasamos los datos del grid a la fila correspondiente
                foreach (DataGridViewRow _FilaDataGrid in _P_Dgv_Grid.Rows)
                {
                    _Dr_FilaNueva = _Dt_Tabla.NewRow();
                    for (int _Int_I = 0; _Int_I < _Int_NumeroDeColumnas; _Int_I++)
                    {
                        _Dr_FilaNueva[_Int_I] = _FilaDataGrid.Cells[_Int_I].Value;
                    }
                    _Dt_Tabla.Rows.Add(_Dr_FilaNueva);

                }
                //Guardo
                _Ds_Nuevo.Tables.Add(_Dt_Tabla);
                return _Ds_Nuevo;
            }

            catch (Exception _ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Exporta de Dataset a DataGridView
        /// </summary>
        /// <param name="_P_Ds"></param>
        public static void _Mtd_ExportarDeDatasetADataGridView(DataSet _P_Ds, DataGridView _P_Dgr_Carga)
        {
            //Inicializo el Grid
            _P_Dgr_Carga.Rows.Clear();
            _P_Dgr_Carga.Columns.Clear();
            DataGridViewTextBoxColumn _Col;
            //Preparo las Columnas
            for (int _Int_I = 1; _Int_I <= _P_Ds.Tables[0].Columns.Count; _Int_I++)
            {
                _Col = new DataGridViewTextBoxColumn();
                _Col.Name = "_Col_" + _Int_I;
                _Col.HeaderText = "Pos.(" + _Int_I + ")";
                _P_Dgr_Carga.Columns.Add(_Col);
            }
            //Preparo las Filas
            foreach (DataRow _Row in _P_Ds.Tables[0].Rows)
            {
                _P_Dgr_Carga.Rows.Add(_Row.ItemArray);
            }
        }
        /// <summary>
        /// Obtiene el Numero Maximo de entre todas las posiciones de columnas
        /// </summary>
        /// <param name="_P_Registro"></param>
        /// <returns></returns>
        public static int _Mtd_ObtenerCantidadDeColumnasConfiguracionBancaria(DataContext.TCONFCAPBANCD _P_Registro)
        {
            int _Int_CantidadDeColumnas = 0;
            if (_P_Registro.cposconcepto > _Int_CantidadDeColumnas) { _Int_CantidadDeColumnas = Convert.ToInt32(_P_Registro.cposconcepto); }
            if (_P_Registro.cposdatemovi > _Int_CantidadDeColumnas) { _Int_CantidadDeColumnas = Convert.ToInt32(_P_Registro.cposdatemovi); }
            if (_P_Registro.cposmontomov > _Int_CantidadDeColumnas) { _Int_CantidadDeColumnas = Convert.ToInt32(_P_Registro.cposmontomov); }
            if (_P_Registro.cposmontomov1 > _Int_CantidadDeColumnas) { _Int_CantidadDeColumnas = Convert.ToInt32(_P_Registro.cposmontomov1); }
            if (_P_Registro.cposnumdocu > _Int_CantidadDeColumnas) { _Int_CantidadDeColumnas = Convert.ToInt32(_P_Registro.cposnumdocu); }
            if (_P_Registro.cposoficinabanc > _Int_CantidadDeColumnas) { _Int_CantidadDeColumnas = Convert.ToInt32(_P_Registro.cposoficinabanc); }
            if (_P_Registro.cpossaldomov > _Int_CantidadDeColumnas) { _Int_CantidadDeColumnas = Convert.ToInt32(_P_Registro.cpossaldomov); }
            if (_P_Registro.cpostipoperacio > _Int_CantidadDeColumnas) { _Int_CantidadDeColumnas = Convert.ToInt32(_P_Registro.cpostipoperacio); }
            return _Int_CantidadDeColumnas;
        }
        /// <summary>
        /// Inicializ un arreglo con los distintos tipos de formato de fecha
        /// </summary>
        /// <returns>Lista de Formatos de Fecha</returns>
        public static System.Collections.ArrayList _Mtd_InicializarArregloDeFormatosDeFecha()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            //            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("d", "0"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("dMMyyyy", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("dd/MM/yyyy", "2"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("MM/dd/yyyy", "3"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("ddMMyyyy", "4"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("MMddyyyy", "5"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("yyyy/MM/dd", "6"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("yyyy/dd/MM", "7"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("dd", "8"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("d-m-yy", "9"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("dd-mm-yyyy", "9"));
            return _myArrayList;
        }
        /// <summary>
        /// Carga el Combo de fechas
        /// </summary>
        /// <param name="_P_Cmb_Combo"></param>
        public static void _Mtd_CargarComboFormatoFechas(ComboBox _P_Cmb_Combo)
        {
            _P_Cmb_Combo.DataSource = null;
            _P_Cmb_Combo.DataSource = _Mtd_InicializarArregloDeFormatosDeFecha();
            _P_Cmb_Combo.DisplayMember = "Display";
            _P_Cmb_Combo.ValueMember = "Value";
            _P_Cmb_Combo.SelectedValue = "nulo";
            _P_Cmb_Combo.SelectedIndex = -1;
        }
        /// <summary>
        /// Convierte el Dato al Formato indicado, ademas indica si la conversion fue correcta
        /// </summary>
        /// <param name="_P_Str_Dato">Dato a convertir</param>
        /// <param name="_P_Str_Formato">Formato</param>
        /// <param name="_P_Dtm_FechaConvertida">Dato convertido</param>
        /// <param name="_P_Int_Mes">Mes</param>
        /// <param name="_P_Int_Año">Año</param>
        /// <returns>Devuelve verdadero si la conversión fue exitosa</returns>
        public static bool _Mtd_ConvertirFechaSegunFormato(string _P_Str_Dato, string _P_Str_Formato, out DateTime _P_Dtm_FechaConvertida, int _P_Int_Mes = 0, int _P_Int_Año = 0)
        {
            try
            {
                //Si el formato es de solo dia
                if ((_P_Str_Formato == "d") | (_P_Str_Formato == "dd"))
                {
                    //Valido que sea un numero entero en primer lugar
                    if (Regex.Match(_P_Str_Dato, @"^[0-9]+$").Success == true)
                    {
                        //Valido que este dentro del rango (1-31)
                        int _Int_NumeroEntero = Convert.ToInt32(_P_Str_Dato);
                        if (_Int_NumeroEntero >= 1 && _Int_NumeroEntero <= 31)
                        {
                            //Si pasamos mes y año
                            //Genero la Fecha a Convertir 
                            if (_P_Int_Mes != 0 && _P_Int_Año != 0)
                            {
                                string _Str_FechaGenerada = _Int_NumeroEntero.ToString("00") + "/" + _P_Int_Mes.ToString("00") + "/" + _P_Int_Año.ToString("0000");
                                _P_Dtm_FechaConvertida = Convert.ToDateTime(_Str_FechaGenerada);
                                return true;
                            }
                            _P_Dtm_FechaConvertida = DateTime.MaxValue; //Devuelvo la Fecha por defecto ya que no la puedo convertir sin pasar los datos de mes y año
                            return true;
                        }
                        _P_Dtm_FechaConvertida = DateTime.MaxValue; //Error Numero Fuera de Rango para dia
                        return false;
                    }
                    _P_Dtm_FechaConvertida = DateTime.MaxValue; //Error Dato no Entero
                    return false;
                }
                //Si el formato es especial propio de los bancos
                if (_P_Str_Formato == "dMMyyyy")
                {
                    //Completo la fecha segun rutina inteligente de completacion de fechas 
                    string _Str_FechaCompletada = _Mtd_RutinaInteligenteDeCompletacionDeFechas(_P_Str_Dato);
                    //Convierto de forma normal
                    DateTime _Dtm_Resultado = DateTime.Parse(_Str_FechaCompletada);
                    _P_Dtm_FechaConvertida = _Dtm_Resultado;
                    return true;

                }
                //Si el formato es especial propio de los bancos
                if (_P_Str_Formato == "d-m-yy")
                {
                    //Divido la cadena
                    var _StrPartes = _P_Str_Dato.Split('-');
                    //Completo las partes
                    _StrPartes[0] = _StrPartes[0].PadLeft(2, '0');
                    _StrPartes[1] = _StrPartes[1].PadLeft(2, '0');
                    //Genero de nuevo la fecha con las partes
                    string _Str_FechaCompletada = _StrPartes[0] + "/" + _StrPartes[1] + "/" + _StrPartes[2];
                    //Convierto de forma normal
                    DateTime _Dtm_Resultado = DateTime.Parse(_Str_FechaCompletada);
                    _P_Dtm_FechaConvertida = _Dtm_Resultado;
                    return true;

                }
                //Si el formato es especial propio de los bancos
                if (_P_Str_Formato == "dd-mm-yyyy")
                {
                    //Divido la cadena
                    var _StrPartes = _P_Str_Dato.Split('-');
                    //Completo las partes
                    _StrPartes[0] = _StrPartes[0].PadLeft(2, '0');
                    _StrPartes[1] = _StrPartes[1].PadLeft(2, '0');
                    //Genero de nuevo la fecha con las partes
                    string _Str_FechaCompletada = _StrPartes[0] + "/" + _StrPartes[1] + "/" + _StrPartes[2];
                    //Convierto de forma normal
                    DateTime _Dtm_Resultado = DateTime.Parse(_Str_FechaCompletada);
                    _P_Dtm_FechaConvertida = _Dtm_Resultado;
                    return true;

                }
                else //Otros Formatos de Fecha
                {
                    // - - - - - - - - - - - - - - - Conversiones  - - - - - - - - - -
                    DateTime _Dtm_Resultado = DateTime.ParseExact(_P_Str_Dato, _P_Str_Formato, CultureInfo.InvariantCulture);
                    _P_Dtm_FechaConvertida = _Dtm_Resultado;
                    return true;
                }
            }
            catch (Exception _Ex)
            {
                _P_Dtm_FechaConvertida = DateTime.MaxValue; //Todos los demas errores 
                return false;
            }

        }
        public static string _Mtd_RutinaInteligenteDeCompletacionDeFechas(string _P_Str_FechaIncompleta)
        {
            string _Str_FechaCompletada = "";
            string _Str_Año = "";
            string _Str_Mes = "";
            string _Str_Dia = "";

            //La fecha debe venir por lo menos con 6 digitos
            if (!(_P_Str_FechaIncompleta.Length >= 6))
            {
                return _P_Str_FechaIncompleta;
            }

            //Comienzo Obteniendo el año (ultimos 4 digitos)
            _Str_Año = _P_Str_FechaIncompleta.Substring(_P_Str_FechaIncompleta.Length - 4);
            //Remuevo el año obtenido
            _P_Str_FechaIncompleta = _P_Str_FechaIncompleta.Remove(_P_Str_FechaIncompleta.Length - 4);
            //Si los digitos que queda son 2
            if (_P_Str_FechaIncompleta.Length == 2)
            {
                //Obtengo mes
                _Str_Mes = _P_Str_FechaIncompleta.Substring(1);
                //Obtengo dia
                _Str_Dia = _P_Str_FechaIncompleta.Substring(0, 1);
            }
            else if (_P_Str_FechaIncompleta.Length > 2)
            {
                //Obtengo el mes
                _Str_Mes = _P_Str_FechaIncompleta.Substring(_P_Str_FechaIncompleta.Length - 2);
                //Remuevo el mes obtenido
                _P_Str_FechaIncompleta = _P_Str_FechaIncompleta.Remove(_P_Str_FechaIncompleta.Length - 2);
                //Obtengo el Dia
                _Str_Dia = _P_Str_FechaIncompleta;
            }

            //Genero la Fecha
            _Str_FechaCompletada = _Str_Dia.PadLeft(2, '0') + "/" + _Str_Mes.PadLeft(2, '0') + "/" + _Str_Año.PadLeft(4, '0');
            //Devuelvo
            return _Str_FechaCompletada;
        }
        /// <summary>
        /// Verifica si el dato puede convertirse a fecha segun el formato especificado
        /// </summary>
        /// <param name="_P_DatoAVerificar"></param>
        /// <param name="_P_Formato"></param>
        /// <returns></returns>
        public static bool _Mtd_EsValidoDatoYFormatoDeFecha(string _P_Str_DatoAVerificar, string _P_Str_Formato, int _P_Int_Mes = 0, int _P_Int_Año = 0)
        {
            DateTime _Dtm_FechaConvertida = new DateTime();

            if (_Mtd_ConvertirFechaSegunFormato(_P_Str_DatoAVerificar, _P_Str_Formato, out  _Dtm_FechaConvertida, _P_Int_Mes, _P_Int_Año))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool _Mtd_VerificarConversionDeDatosAFecha(DataSet _P_Ds_Original, int _P_Int_ColumnaAVerificar, string _P_Str_Formato)
        {
            bool _Bol_DatosValidos = true; //Los datos son validos hasta que se demuestre lo contrario
            var _Dt_Clon = _P_Ds_Original.Tables[0].Copy();
            foreach (DataRow _Row in _Dt_Clon.Rows)
            {
                string _Str_Valor;
                _Str_Valor = _Row[_P_Int_ColumnaAVerificar - 1].ToString();
                //Verifico si el valor no es valido
                bool _Bool_ConversionValida;
                _Mtd_FormatearFecha(_Str_Valor, _P_Str_Formato, out _Bool_ConversionValida);
                if (!_Bool_ConversionValida)
                {
                    _Bol_DatosValidos = false;
                    break;
                }
            }
            //devuelvo
            return _Bol_DatosValidos;
        }
        //public static bool _Mtd_VerificarConversionDeDatosAFecha(DataGridView _P_Dgv_Datos, int _P_Int_ColumnaAVerificar, string _P_Str_Formato)
        //{
        //    bool _Bol_DatosValidos = true; //Los datos son validos hasta que se demuestre lo contrario
        //    //Recorro las Filas de la Columna indicada
        //    for (int _Int_Fila = 0; _Int_Fila < _P_Dgv_Datos.RowCount; _Int_Fila++)
        //    {
        //        // Obtengo el valor de la celda
        //        string _Str_Valor = _P_Dgv_Datos.Rows[_Int_Fila].Cells[_P_Int_ColumnaAVerificar - 1].Value.ToString();
        //        //Verifico si el valor no es valido
        //        bool _Bool_ConversionValida;
        //        _Mtd_FormatearFecha(_Str_Valor, _P_Str_Formato, out _Bool_ConversionValida);
        //        if (!_Bool_ConversionValida)
        //        {
        //            _Bol_DatosValidos = false;
        //            break;
        //        }
        //    }
        //    //devuelvo
        //    return _Bol_DatosValidos;

        //}
        /// <summary>
        /// Formatea la Fecha segun el formato indicado y devuelve si la conversion fue correcta
        /// </summary>
        /// <param name="_P_Str_ValorOriginal"></param>
        /// <param name="_P_Str_FormatoFecha"></param>
        /// <param name="_P_Bool_ConversionCorrecta"></param>
        /// <param name="_P_Int_Mes"></param>
        /// <param name="_P_Int_Año"></param>
        /// <returns></returns>
        public static string _Mtd_FormatearFecha(string _P_Str_ValorOriginal, string _P_Str_FormatoFecha, out bool _P_Bool_ConversionCorrecta, int _P_Int_Mes = 0, int _P_Int_Año = 0)
        {
            DateTime _Dt_FechaFormateada;
            var _Str_FechaFormateada = "";

            //Completamos con cero a la izqueida si al fecha viene de tamaño muy corto
            if (_P_Str_FormatoFecha != "d-m-yy")
                if (_P_Str_ValorOriginal.Length == 7)
                    _P_Str_ValorOriginal = "0" + _P_Str_ValorOriginal;

            //Aplicamos el format
            var _Bool_ConversionCorrecta = _Mtd_ConvertirFechaSegunFormato(_P_Str_ValorOriginal, _P_Str_FormatoFecha, out _Dt_FechaFormateada, _P_Int_Mes, _P_Int_Año);
            //var _Bool_ConversionCorrecta = DateTime.TryParseExact(_P_Str_ValorOriginal, _P_Str_FormatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out _Dt_FechaFormateada);
            if (_Bool_ConversionCorrecta)
                _Str_FechaFormateada = _Dt_FechaFormateada.ToShortDateString();
            else
                _Str_FechaFormateada = _P_Str_ValorOriginal;

            _P_Bool_ConversionCorrecta = _Bool_ConversionCorrecta;
            return _Str_FechaFormateada;
        }
        /// <summary>
        /// Formatea el Numero de Documento inclusive si viene en Notacion cientifica
        /// </summary>
        /// <param name="_P_Str_ValorOriginal"></param>
        /// <returns></returns>
        public static string _Mtd_FormatearNumeroDocumento(string _P_Str_ValorOriginal)
        {
            Int64 _Int64_NumeroDocumentoFormateado = 0;
            string _Str_NumeroDocumentoFormateado = "";

            //Si not tiene una E de la nootacion cientifica devolvemos el original
            if (!_P_Str_ValorOriginal.Contains("E"))
                return _P_Str_ValorOriginal;

            //Cambiamos el separador decimal a .
            _P_Str_ValorOriginal = _P_Str_ValorOriginal.Replace(',', '.');

            //Aplicamos el format
            var _Bool_ConversionCorrecta = Int64.TryParse(_P_Str_ValorOriginal, NumberStyles.Float, CultureInfo.InvariantCulture, out _Int64_NumeroDocumentoFormateado);
            if (_Bool_ConversionCorrecta)
                _Str_NumeroDocumentoFormateado = _Int64_NumeroDocumentoFormateado.ToString();
            else
                _Str_NumeroDocumentoFormateado = _P_Str_ValorOriginal;

            return _Str_NumeroDocumentoFormateado;
        }
        /// <summary>
        /// Formatea el Monto segun el formato indicado y devuelve si la conversion fue correcta
        /// </summary>
        /// <param name="_P_Str_ValorOriginal"></param>
        /// <param name="_P_Byte_SeparadorDecimal"></param>
        /// <param name="_P_Byte_CantidadDigitosDecimal"></param>
        /// <returns></returns>
        public static string _Mtd_FormatearMonto(string _P_Str_ValorOriginal, byte _P_Byte_SeparadorDecimal, byte _P_Byte_CantidadDigitosDecimal, bool _P_Bol_ConservarSigno = false)
        {
            //Si viene el valor vacio retornamos el mismo
            if (_P_Str_ValorOriginal == "")
                return _P_Str_ValorOriginal;

            //Inicializamos
            var _Str_Valor = "";

            //Si hay que quitar los signos
            if (_P_Bol_ConservarSigno)
            {
                //Si existe el negativo
                if (_P_Str_ValorOriginal.IndexOf('-') >= 0)
                {
                    //Borramos el signo
                    _Str_Valor = _P_Str_ValorOriginal.Replace("-", "");
                    //Lo colocamos donde deberia ir correctamente
                    _Str_Valor = "-" + _Str_Valor;
                }
                else
                {
                    _Str_Valor = _P_Str_ValorOriginal;
                }
            }
            else
            {
                _Str_Valor = _P_Str_ValorOriginal.Replace("-", "");
            }

            //Si los dos parametros son cero (dejamos el original)
            if ((_P_Byte_SeparadorDecimal == 0) & (_P_Byte_CantidadDigitosDecimal == 0))
                return _P_Str_ValorOriginal;

            //Separador decimal
            if (_P_Byte_SeparadorDecimal == 2) //Separador con Punto
            {
                _Str_Valor = _Str_Valor.Replace(",", "").Replace(".", ",");
                return _Str_Valor;
            }

            //Pasamos a numerico
            var _Dc_Valor = Convert.ToDecimal(_Str_Valor);

            //Digitos donde colocar decimales
            if (_P_Byte_CantidadDigitosDecimal > 0)
            {
                if (_P_Byte_CantidadDigitosDecimal == 1)
                    _Dc_Valor = _Dc_Valor / 10;
                else
                    _Dc_Valor = _Dc_Valor / 100;
            }

            //Formateamos
            _Str_Valor = _Dc_Valor.ToString("#,##0.00");

            //devolvemos
            return _Str_Valor;
        }



    }
}
