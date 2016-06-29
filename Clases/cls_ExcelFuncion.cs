using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace T3.CLASES
{
   
    public class cls_ExcelFuncion
    {

        Excel.Application oXL;


        Excel._Workbook oWB;
        Excel._Worksheet oSheet;
        Excel.Range oRng;

        public cls_ExcelFuncion()
        {

            oXL = new Excel.Application();
        }

        ~cls_ExcelFuncion()
        {
           // oXL.Quit();
            oXL = null;
        }

        public void _Mtd_Cerrar()
        {
            //_oWB.SaveCopyAs(_P_Str_FileName);
            oXL.Workbooks.Close();
            oXL.Quit();
            oXL = null;
        }

        public string _Mtd_UsarFuncion(string _Pr_Str_Cad)
        {
            string _Str_R = "";
            string _Str_P = "";
            try
            {
                //Excel.WorksheetFunction oFuncion;
                if (oXL == null)
                {
                    oXL = new Excel.Application();
                }
                //CarlosAg.ExcelXmlWriter.Workbook oWB_;
                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));

                //CarlosAg.ExcelXmlWriter.WorksheetCell oCell_;
                //oCell_.Formula = "=2+2";
                //_Str_R = oCell_.Data.Text;

                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                //oSheet.Cells[1, 1] = _Pr_Str_Cad;
                oRng = (Excel.Range)oSheet.Cells[1, 1];
                oRng.FormulaR1C1Local = _Pr_Str_Cad;
                _Str_P = Convert.ToString(oRng.Text);
                oRng = null;
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Expresión no válida para el Cálculo.","Cuidado",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                _Str_P = "ERROR";
            }
            oSheet = null;
            oWB.Close(false, false, Missing.Value);
            oWB = null;
            return _Str_P;
        }

    }
}
