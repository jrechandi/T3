using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Reflection;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace T3.Clases
{
    public class _Cls_ExcelUtilidades
    {
        public _Cls_ExcelUtilidades()
        {
            _ExcelApp = new Excel.Application();
        }
        ~_Cls_ExcelUtilidades()
        {
            //_ExcelApp.Quit();
        }
        Excel.Application _ExcelApp;
        public void _Mtd_DatasetToExcel(DataTable _Pr_Dt, string _Pr_Str_Ruta, string _Pr_Str_HojaName, DataGridViewColumnCollection _P_Dg_Col)
        {
            int _Int_Col = 0, _Int_Fil = 1;

            Excel.Workbook _wBook = _ExcelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet _ExcelHoja = (Excel.Worksheet)_wBook.ActiveSheet;
            Excel.Range _ExcelRange;
            _ExcelHoja.Name = _Pr_Str_HojaName;
            foreach (DataColumn _Dcol in _Pr_Dt.Columns)
            {
                _Int_Col++;
                _ExcelHoja.Cells[1, _Int_Col] = _P_Dg_Col[_Int_Col - 1].HeaderText;
                _ExcelRange = (Excel.Range)_ExcelHoja.Cells[1, _Int_Col];
                _ExcelRange.Font.Bold = true;
            }
            foreach (DataRow _Drow in _Pr_Dt.Rows)
            {
                _Int_Fil++;
                _Int_Col = 0;
                foreach (DataColumn _Dcol in _Pr_Dt.Columns)
                {
                    _Int_Col++;
                    _ExcelHoja.Cells[_Int_Fil, _Int_Col] = Convert.ToString(_Drow[_Dcol.ColumnName]);
                }
            }
            _ExcelHoja.Columns.AutoFit();

            string _Str_FileName = _Pr_Str_Ruta;
            if (System.IO.File.Exists(_Str_FileName))
            {
                System.IO.File.Delete(_Str_FileName);
            }

            //_wBook.SaveAs(_Str_FileName, Excel.XlFileFormat.xlCSV, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //_ExcelApp.Workbooks.Open(_Str_FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            _ExcelApp.Workbooks[1].Close(true, _Str_FileName, Missing.Value);
            _ExcelApp.Quit();
            //_ExcelApp.Visible = true;
            _ExcelApp = null;
            GC.Collect();
            System.Diagnostics.Process.Start(_Str_FileName);

            //_ExcelApp.Workbooks.Open(_Pr_Str_archivo, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            //_ExcelHoja = (Excel.Worksheet)_ExcelApp.Workbooks[1].Sheets[1];
        }
        public void _Mtd_DatasetToExcel(DataTable _Pr_Dt, string _Pr_Str_Ruta, string _Pr_Str_HojaName)
        {
            int _Int_Col = 0, _Int_Fil = 1;
            DateTime _Dte_Fecha;
            string _Str_FileName = _Pr_Str_Ruta;

            //Verifico si el archivo existe
            if (System.IO.File.Exists(_Str_FileName))
            {
                //Trato de Borralo (Si hay error es porque esta abierto)
                try
                {
                    System.IO.File.Delete(_Str_FileName);
                }
                catch (Exception Excep)
                {
                    MessageBox.Show("El archivo esta abierto, no se puede sobreescribir, Exportación cancelada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            Excel.Workbook _wBook = _ExcelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet _ExcelHoja = (Excel.Worksheet)_wBook.ActiveSheet;
            Excel.Range _ExcelRange;
            _ExcelHoja.Name = _Pr_Str_HojaName;
            foreach (DataColumn _Dcol in _Pr_Dt.Columns)
            {
                _Int_Col++;
                _ExcelHoja.Cells[1, _Int_Col] = _Dcol.Caption;
                _ExcelRange = (Excel.Range)_ExcelHoja.Cells[1, _Int_Col];
                _ExcelRange.Font.Bold = true;
            }
            foreach (DataRow _Drow in _Pr_Dt.Rows)
            {
                _Int_Fil++;
                _Int_Col = 0;
                foreach (DataColumn _Dcol in _Pr_Dt.Columns)
                {
                    _Int_Col++;

                    if (DateTime.TryParseExact(Convert.ToString(_Drow[_Dcol.ColumnName]), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault, out _Dte_Fecha))
                    {
                        _ExcelHoja.Cells[_Int_Fil, _Int_Col] =  Convert.ToDateTime(_Drow[_Dcol.ColumnName]);
                        _ExcelHoja.Cells[_Int_Fil, _Int_Col].NumberFormat = "dd/MM/yyyy";
                    }
                    else
                    {
                        _ExcelHoja.Cells[_Int_Fil, _Int_Col] = Convert.ToString(_Drow[_Dcol.ColumnName]);
                    }
                }
            }
            _ExcelHoja.Columns.AutoFit();

            //_wBook.SaveAs(_Str_FileName, Excel.XlFileFormat.xlCSV, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //_ExcelApp.Workbooks.Open(_Str_FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            _ExcelApp.Workbooks[1].Close(true, _Str_FileName, Missing.Value);
            _ExcelApp.Quit();
            //_ExcelApp.Visible = true;
            _ExcelApp = null;
            GC.Collect();
            System.Diagnostics.Process.Start(_Str_FileName);

            //_ExcelApp.Workbooks.Open(_Pr_Str_archivo, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            //_ExcelHoja = (Excel.Worksheet)_ExcelApp.Workbooks[1].Sheets[1];
        }
        public void _Mtd_DatasetToExcel_Conciliacion(DataTable _Pr_Dt, string _Pr_Str_Ruta, string _Pr_Str_HojaName)
        {
            int _Int_Col = 0, _Int_Fil = 1;
            DateTime _Dte_Fecha;
            string _Str_FileName = _Pr_Str_Ruta;

            //Verifico si el archivo existe
            if (System.IO.File.Exists(_Str_FileName))
            {
                //Trato de Borralo (Si hay error es porque esta abierto)
                try
                {
                    System.IO.File.Delete(_Str_FileName);
                }
                catch (Exception Excep)
                {
                    MessageBox.Show("El archivo esta abierto, no se puede sobreescribir, Exportación cancelada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            Excel.Workbook _wBook = _ExcelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet _ExcelHoja = (Excel.Worksheet)_wBook.ActiveSheet;
            Excel.Range _ExcelRange;
            _ExcelHoja.Name = _Pr_Str_HojaName;
            foreach (DataColumn _Dcol in _Pr_Dt.Columns)
            {
                _Int_Col++;
                _ExcelHoja.Cells[1, _Int_Col] = _Dcol.Caption;
                _ExcelRange = (Excel.Range)_ExcelHoja.Cells[1, _Int_Col];
                _ExcelRange.Font.Bold = true;
            }
            foreach (DataRow _Drow in _Pr_Dt.Rows)
            {
                _Int_Fil++;
                _Int_Col = 0;
                foreach (DataColumn _Dcol in _Pr_Dt.Columns)
                {
                    _Int_Col++;

                    if (DateTime.TryParseExact(Convert.ToString(_Drow[_Dcol.ColumnName]), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault, out _Dte_Fecha))
                    {
                        _ExcelHoja.Cells[_Int_Fil, _Int_Col] = String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(_Drow[_Dcol.ColumnName]));
                    }
                    else if (_Dcol.DataType == Type.GetType("System.Decimal"))
                    {
                        _ExcelHoja.Cells[_Int_Fil, _Int_Col] = Convert.ToDecimal(_Drow[_Dcol.ColumnName]);
                        _ExcelHoja.Cells[_Int_Fil, _Int_Col].NumberFormat = "#.##0,00";
                    }
                    else if (_Dcol.DataType == Type.GetType("System.Double"))
                    {
                        _ExcelHoja.Cells[_Int_Fil, _Int_Col] = Convert.ToDouble(_Drow[_Dcol.ColumnName]);
                        _ExcelHoja.Cells[_Int_Fil, _Int_Col].NumberFormat = "#.##0,00";
                    }
                    else if (_Dcol.DataType == Type.GetType("System.DateTime"))
                    {
                        _ExcelHoja.Cells[_Int_Fil, _Int_Col] = String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(_Drow[_Dcol.ColumnName]));
                        _ExcelHoja.Cells[_Int_Fil, _Int_Col].NumberFormat = "dd/MM/yyyy";
                    }
                    else
                    {
                        _ExcelHoja.Cells[_Int_Fil, _Int_Col] = Convert.ToString(_Drow[_Dcol.ColumnName]);
                    }
                }
            }
            _ExcelHoja.Columns.AutoFit();

            //_wBook.SaveAs(_Str_FileName, Excel.XlFileFormat.xlCSV, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //_ExcelApp.Workbooks.Open(_Str_FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            _ExcelApp.Workbooks[1].Close(true, _Str_FileName, Missing.Value);
            _ExcelApp.Quit();
            //_ExcelApp.Visible = true;
            _ExcelApp = null;
            GC.Collect();
            System.Diagnostics.Process.Start(_Str_FileName);

            //_ExcelApp.Workbooks.Open(_Pr_Str_archivo, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            //_ExcelHoja = (Excel.Worksheet)_ExcelApp.Workbooks[1].Sheets[1];
        }
        public void _Mtd_DatasetToExcel_Conciliacion(List<_Cls_ExportarExcel> _P_Datos , string _Pr_Str_Ruta)
        {
            int _Int_Col = 0, _Int_Fil = 1;
            DateTime _Dte_Fecha;
            string _Str_FileName = _Pr_Str_Ruta;

            //Verifico si el archivo existe
            if (System.IO.File.Exists(_Str_FileName))
            {
                //Trato de Borralo (Si hay error es porque esta abierto)
                try
                {
                    System.IO.File.Delete(_Str_FileName);
                }
                catch (Exception Excep)
                {
                    MessageBox.Show("El archivo esta abierto, no se puede sobreescribir, Exportación cancelada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            //Creamos el Libro
            var _wBook = _ExcelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            var _Int_HojaActual = 0;

            //Por cada Objeto en Datos
            foreach (var _oDato in _P_Datos)
            {
                //Contamos la Hoja
                _Int_HojaActual++;

                Excel.Worksheet _ExcelHoja = null;

                //si estamos en la primera hoja, tomamos la que se crea por defecto
                if (_Int_HojaActual == 1)
                    _ExcelHoja = (Excel.Worksheet)_wBook.ActiveSheet;
                else
                {
                    //Generamos una nueva hoja de excel
                    _wBook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    //Activamos la Hoja
                    _ExcelHoja = (Excel.Worksheet)_wBook.ActiveSheet;
                }

                Excel.Range _ExcelRange;

                //Nombre de la hoja
                _ExcelHoja.Name = _oDato.NombreHoja;

                //Nombres de las columnas
                _Int_Col = 0;
                foreach (DataColumn _Dcol in _oDato.Datos.Columns)
                {
                    _Int_Col++;
                    _ExcelHoja.Cells[1, _Int_Col] = _Dcol.Caption;
                    _ExcelRange = (Excel.Range)_ExcelHoja.Cells[1, _Int_Col];
                    _ExcelRange.Font.Bold = true;
                }

                //Datos
                _Int_Fil = 1;
                foreach (DataRow _Drow in _oDato.Datos.Rows)
                {
                    _Int_Fil++;
                    _Int_Col = 0;
                    foreach (DataColumn _Dcol in _oDato.Datos.Columns)
                    {
                        _Int_Col++;

                        if (DateTime.TryParseExact(Convert.ToString(_Drow[_Dcol.ColumnName]), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault, out _Dte_Fecha))
                        {
                            _ExcelHoja.Cells[_Int_Fil, _Int_Col] = String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(_Drow[_Dcol.ColumnName]));
                        }
                        else if (_Dcol.DataType == Type.GetType("System.Decimal"))
                        {
                            _ExcelHoja.Cells[_Int_Fil, _Int_Col] = Convert.ToDecimal(_Drow[_Dcol.ColumnName]);
                            _ExcelHoja.Cells[_Int_Fil, _Int_Col].NumberFormat = "#.##0,00";
                        }
                        else if (_Dcol.DataType == Type.GetType("System.Double"))
                        {
                            _ExcelHoja.Cells[_Int_Fil, _Int_Col] = Convert.ToDouble(_Drow[_Dcol.ColumnName]);
                            _ExcelHoja.Cells[_Int_Fil, _Int_Col].NumberFormat = "#.##0,00";
                        }
                        else if (_Dcol.DataType == Type.GetType("System.DateTime"))
                        {
                            _ExcelHoja.Cells[_Int_Fil, _Int_Col] = String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(_Drow[_Dcol.ColumnName]));
                            _ExcelHoja.Cells[_Int_Fil, _Int_Col].NumberFormat = "dd/MM/yyyy";
                        }
                        else
                        {
                            _ExcelHoja.Cells[_Int_Fil, _Int_Col] = Convert.ToString(_Drow[_Dcol.ColumnName]);
                        }
                    }
                }
                _ExcelHoja.Columns.AutoFit();
            }

            //Cerramos el Libro
            _ExcelApp.Workbooks[1].Close(true, _Str_FileName, Missing.Value);
            //Cerramos el Excel
            _ExcelApp.Quit();
            //Limpiamos memoria
            _ExcelApp = null;
            GC.Collect();
            System.Diagnostics.Process.Start(_Str_FileName);
        }
        public void _Mtd_DatasetToExcel_ConsultaMultiple(DataTable _Pr_Dt, string _Pr_Str_Ruta, string _Pr_Str_HojaName)
        {
            int _Int_Col = 0, _Int_Fil = 1;
            DateTime _Dte_Fecha;
            string _Str_FileName = _Pr_Str_Ruta;

            //Verifico si el archivo existe
            if (System.IO.File.Exists(_Str_FileName))
            {
                //Trato de Borralo (Si hay error es porque esta abierto)
                try
                {
                    System.IO.File.Delete(_Str_FileName);
                }
                catch (Exception Excep)
                {
                    MessageBox.Show("El archivo esta abierto, no se puede sobreescribir, Exportación cancelada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            Excel.Workbook _wBook = _ExcelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet _ExcelHoja = (Excel.Worksheet)_wBook.ActiveSheet;
            Excel.Range _ExcelRange;
            _ExcelHoja.Name = _Pr_Str_HojaName;
            foreach (DataColumn _Dcol in _Pr_Dt.Columns)
            {
                _Int_Col++;
                _ExcelHoja.Cells[1, _Int_Col] = _Dcol.Caption;
                _ExcelRange = (Excel.Range)_ExcelHoja.Cells[1, _Int_Col];
                _ExcelRange.Font.Bold = true;
            }
            foreach (DataRow _Drow in _Pr_Dt.Rows)
            {
                _Int_Fil++;
                _Int_Col = 0;
                foreach (DataColumn _Dcol in _Pr_Dt.Columns)
                {
                    _Int_Col++;

                    //SOLO FORMATEAMOS CIERTAS COLUMNAS
                    if ((_Dcol.ColumnName == "c_montotot_si") | (_Dcol.ColumnName == "c_fecha_pedido") | (_Dcol.ColumnName == "cmontotot_factura"))
                    {
                        if (DateTime.TryParseExact(Convert.ToString(_Drow[_Dcol.ColumnName]), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault, out _Dte_Fecha))
                        {
                            _ExcelHoja.Cells[_Int_Fil, _Int_Col] = String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(_Drow[_Dcol.ColumnName]));
                        }
                        else if (_Dcol.DataType == Type.GetType("System.Decimal"))
                        {
                            _ExcelHoja.Cells[_Int_Fil, _Int_Col] = Convert.ToDecimal(_Drow[_Dcol.ColumnName]);
                            _ExcelHoja.Cells[_Int_Fil, _Int_Col].NumberFormat = "#.##0,00";
                        }
                        else if (_Dcol.DataType == Type.GetType("System.Double"))
                        {
                            _ExcelHoja.Cells[_Int_Fil, _Int_Col] = Convert.ToDouble(_Drow[_Dcol.ColumnName]);
                            _ExcelHoja.Cells[_Int_Fil, _Int_Col].NumberFormat = "#.##0,00";
                        }
                        else
                        {
                            _ExcelHoja.Cells[_Int_Fil, _Int_Col] = Convert.ToString(_Drow[_Dcol.ColumnName]);
                        }
                    }
                    else
                    {
                        _ExcelHoja.Cells[_Int_Fil, _Int_Col] = Convert.ToString(_Drow[_Dcol.ColumnName]);
                    }
                }
            }
            _ExcelHoja.Columns.AutoFit();

            //_wBook.SaveAs(_Str_FileName, Excel.XlFileFormat.xlCSV, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //_ExcelApp.Workbooks.Open(_Str_FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            _ExcelApp.Workbooks[1].Close(true, _Str_FileName, Missing.Value);
            _ExcelApp.Quit();
            //_ExcelApp.Visible = true;
            _ExcelApp = null;
            GC.Collect();
            System.Diagnostics.Process.Start(_Str_FileName);

            //_ExcelApp.Workbooks.Open(_Pr_Str_archivo, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            //_ExcelHoja = (Excel.Worksheet)_ExcelApp.Workbooks[1].Sheets[1];
        }
        public void _Mtd_DatasetToExcel(DataTable[] _Pr_Dt_, string _Pr_Str_Ruta, string[] _Pr_Str_HojaName)
        {
            int _Int_Name = 0;
            Excel.Workbook _wBook = _ExcelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            foreach (DataTable _Pr_Dt in _Pr_Dt_)
            {
                int _Int_Col = 0, _Int_Fil = 1;
                Excel.Worksheet _ExcelHoja = (Excel.Worksheet)_wBook.Sheets.Add(Missing.Value, Missing.Value, 1, Missing.Value);
                _ExcelHoja = (Excel.Worksheet)_wBook.ActiveSheet;
                Excel.Range _ExcelRange;
                _ExcelHoja.Name = _Pr_Str_HojaName[_Int_Name];
                _Int_Name += 1;
                foreach (DataColumn _Dcol in _Pr_Dt.Columns)
                {
                    _Int_Col++;
                    _ExcelHoja.Cells[1, _Int_Col] = _Dcol.ColumnName;
                    _ExcelRange = (Excel.Range)_ExcelHoja.Cells[1, _Int_Col];
                    _ExcelRange.Font.Bold = true;
                }
                foreach (DataRow _Drow in _Pr_Dt.Rows)
                {
                    _Int_Fil++;
                    _Int_Col = 0;
                    foreach (DataColumn _Dcol in _Pr_Dt.Columns)
                    {
                        _Int_Col++;
                        _ExcelHoja.Cells[_Int_Fil, _Int_Col] = Convert.ToString(_Drow[_Dcol.ColumnName]);
                    }
                }
                _ExcelHoja.Columns.AutoFit();
            }
            string _Str_FileName = _Pr_Str_Ruta;
            if (System.IO.File.Exists(_Str_FileName))
            {
                System.IO.File.Delete(_Str_FileName);
            }
            //_wBook.SaveAs(_Str_FileName, Excel.XlFileFormat.xlCSV, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //_ExcelApp.Workbooks.Open(_Str_FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            _ExcelApp.Workbooks[1].Close(true, _Str_FileName, Missing.Value);
            _ExcelApp.Quit();
            //_ExcelApp.Visible = true;
            _ExcelApp = null;
            GC.Collect();
            System.Diagnostics.Process.Start(_Str_FileName);

            //_ExcelApp.Workbooks.Open(_Pr_Str_archivo, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            //_ExcelHoja = (Excel.Worksheet)_ExcelApp.Workbooks[1].Sheets[1];
        }
        public void _Mtd_DgViewToExcel(DataGridView _Pr_Dg, string _Pr_Str_Ruta, string _Pr_Str_HojaName)
        {
            int _Int_Col = 0, _Int_Fil = 1;

            Excel.Workbook _wBook = _ExcelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet _ExcelHoja = (Excel.Worksheet)_wBook.ActiveSheet;
            Excel.Range _ExcelRange;
            _ExcelHoja.Name = _Pr_Str_HojaName;
            for (int _C = 0; _C < _Pr_Dg.Columns.Count; _C++)
            {
                if (_Pr_Dg.Columns[_C].Visible)
                {
                    _Int_Col++;
                    _ExcelHoja.Cells[1, _Int_Col] = _Pr_Dg.Columns[_C].HeaderText;
                    _ExcelRange = (Excel.Range)_ExcelHoja.Cells[1, _Int_Col];
                    _ExcelRange.Font.Bold = true;
                }
            }
            foreach (DataGridViewRow _DgRow in _Pr_Dg.Rows)
            {
                _Int_Fil++;
                _Int_Col = 0;
                for (int _C = 0; _C < _Pr_Dg.Columns.Count; _C++)
                {
                    if (_Pr_Dg.Columns[_C].Visible)
                    {
                        _Int_Col++;
                        _ExcelHoja.Cells[_Int_Fil, _Int_Col] = Convert.ToString(_DgRow.Cells[_C].Value);
                    }

                }
            }
            _ExcelHoja.Columns.AutoFit();

            string _Str_FileName = _Pr_Str_Ruta;
            if (System.IO.File.Exists(_Str_FileName))
            {
                System.IO.File.Delete(_Str_FileName);
            }

            _ExcelApp.Workbooks[1].Close(true, _Str_FileName, Missing.Value);
            _ExcelApp.Quit();
            _ExcelApp = null;
            GC.Collect();
            System.Diagnostics.Process.Start(_Str_FileName);
        }
    }
}
