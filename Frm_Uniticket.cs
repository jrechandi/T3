using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel; 
using System.IO;
using System.Diagnostics;

namespace T3
{
    public partial class Frm_Uniticket : Form
    {
        public Frm_Uniticket()
        {
            InitializeComponent();
        }
        
        private void Frm_Uniticket_Load(object sender, EventArgs e)
        {
            CLASES._Cls_Empleados_SPI _Cls_Empleados_SPI = new CLASES._Cls_Empleados_SPI();
            _Cls_Empleados_SPI._Mtd_ActualizarTablaEmpleadosSPI(true, true, true);

            _Cmb_Filtro.SelectedIndex = 1;

            _Mtd_LlenarGridPrincipal();
        }

        private void _Mtd_LlenarGridPrincipal()
        {

            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Cédula");
            _Tsm_Menu[1] = new ToolStripMenuItem("Nombre");
            _Tsm_Menu[2] = new ToolStripMenuItem("Cargo");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "ccedula";
            _Str_Campos[1] = "cnombre";
            _Str_Campos[2] = "ccargo";

            string _Str_Sql = "SELECT ccedula, cnombre, ccargo, cfecha_ingreso, cfecha_egreso, cingreso_reportado, cegreso_reportado FROM VST_EMPLEADOS_SPI_UNITICKET ";

            if (_Cmb_Filtro.SelectedIndex == 0) _Str_Sql += " WHERE ccompany = '" + Frm_Padre._Str_Comp + "'";
            if (_Cmb_Filtro.SelectedIndex == 1) _Str_Sql += " WHERE ((cingreso_reportado = 'NO') OR (cegreso_reportado = 'NO' AND cfecha_egreso <> '')) AND ccompany = '" + Frm_Padre._Str_Comp + "'";
            if (_Cmb_Filtro.SelectedIndex == 2) _Str_Sql += " WHERE cingreso_reportado = 'NO' AND ccompany = '" + Frm_Padre._Str_Comp + "'";
            if (_Cmb_Filtro.SelectedIndex == 3) _Str_Sql += " WHERE cegreso_reportado = 'NO' AND cfecha_egreso <> '' AND ccompany = '" + Frm_Padre._Str_Comp + "'";

            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Sql, _Str_Campos, "EMPLEADOS", _Tsm_Menu, _Dg_Grid, true, "");
            //_Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }

        private void _mnu_IngresoReportado_Click(object sender, EventArgs e)
        {
            string _Str_ccedula = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["ccedula"].Value.ToString().Trim();
            string _Str_SQL = "UPDATE TEMPLEADOS_SPI SET cingreso_reportado = '1' WHERE ccedula = '" + _Str_ccedula + "' and ccompany = '" + Frm_Padre._Str_Comp + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
            MessageBox.Show("Se ha modificado el registro satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _Mtd_LlenarGridPrincipal();
        }

        private void _mnu_IngresoNoReportado_Click(object sender, EventArgs e)
        {
            string _Str_ccedula = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["ccedula"].Value.ToString().Trim();
            string _Str_SQL = "UPDATE TEMPLEADOS_SPI SET cingreso_reportado = '0' WHERE ccedula = '" + _Str_ccedula + "' and ccompany = '" + Frm_Padre._Str_Comp +"'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
            MessageBox.Show("Se ha modificado el registro satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _Mtd_LlenarGridPrincipal();

        }

        private void _mnu_EgresoReportado_Click(object sender, EventArgs e)
        {
            string _Str_ccedula = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["ccedula"].Value.ToString().Trim();
            string _Str_cfecha_egreso = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cfecha_egreso"].Value.ToString().Trim();

            if (_Str_cfecha_egreso != "")
            {
                string _Str_SQL = "UPDATE TEMPLEADOS_SPI SET cegreso_reportado = '1' WHERE ccedula = '" + _Str_ccedula + "' and ccompany = '" + Frm_Padre._Str_Comp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                MessageBox.Show("Se ha modificado el registro satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_LlenarGridPrincipal();
            }
            else
            {
                MessageBox.Show("No puede marcar este empleado como EGRESO REPORTADO porque aún no tiene FECHA DE EGRESO. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void _mnu_EgresoNoReportado_Click(object sender, EventArgs e)
        {
            string _Str_ccedula = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["ccedula"].Value.ToString().Trim();
                string _Str_SQL = "UPDATE TEMPLEADOS_SPI SET cegreso_reportado = '0' WHERE ccedula = '" + _Str_ccedula + "' and ccompany = '" + Frm_Padre._Str_Comp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                MessageBox.Show("Se ha modificado el registro satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_LlenarGridPrincipal();
        }

        private void _mnu_GenerarReporte_Click(object sender, EventArgs e)
        {
            _Mtd_GenerarReporte();
        }

        private void _Mtd_GenerarReporte()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_RutaPlantilla = "C:\\CONSSA\\T3\\DEBUG\\plantillas\\uniticket.xls";

            if (File.Exists(_Str_RutaPlantilla))
            {
                string _Str_SQL = "";
                // 1. crear los recordset
                _Str_SQL = "SELECT * FROM VST_EMPLEADOS_SPI_UNITICKET WHERE cingreso_reportado = 'NO' AND ccompany = '" + Frm_Padre._Str_Comp + "'";
                DataSet _DS_IngresosPendientes = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                _Str_SQL = "SELECT * FROM VST_EMPLEADOS_SPI_UNITICKET WHERE cfecha_egreso <> '' AND cegreso_reportado = 'NO' AND ccompany = '" + Frm_Padre._Str_Comp + "'";
                DataSet _DS_EgresosPendientes = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);


                // -----------------------------------------------------------------------------------
                
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(_Str_RutaPlantilla, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


                // modifica - inicio ====================================================================================

                int _Int_PrimeraLinea = 8;
                int _Int_LineaActual = _Int_PrimeraLinea;

                string _Str_ccedula = "";
                string _Str_cnombre1 = "";
                string _Str_cnombre2 = "";
                string _Str_capellido1 = "";
                string _Str_capellido2 = "";
                string _Str_cestado_civil = "";
                string _Str_cprofesion = "";
                string _Str_cciudad_na = "";
                string _Str_cfecha_na = "";
                string _Str_cdireccion_empleado = "";
                string _Str_cciudad_empleado = "";
                string _Str_cestado_empleado = "";
                string _Str_ctlf_celular = "";
                string _Str_ctlf_habitacion = "";
                string _Str_cemail = "";
                string _Str_cnombre_empresa = "";
                string _Str_ccargo = "";
                string _Str_csalario = "";
                string _Str_cdireccion_empresa = "";
                string _Str_cciudad_empresa = "";
                string _Str_ctlf_empresa = "";
                string _Str_cestado_empresa = "";
                string _Str_creferencia = "";
                string _Str_cmotivo = "";

                xlWorkSheet.Cells[7, 3] = _Mtd_NombComp();
                
                if (_DS_IngresosPendientes.Tables[0].Rows.Count > 0)
                {
                    _Int_LineaActual++;
                    xlWorkSheet.Cells[_Int_LineaActual, 1] = "APERTURA";

                    _Int_LineaActual++;
                    _Int_LineaActual++;

                    xlWorkSheet.Cells[_Int_LineaActual, 1] = "CANTIDAD";
                    xlWorkSheet.Cells[_Int_LineaActual, 2] = "CEDULA DE IDENTIDAD";
                    xlWorkSheet.Cells[_Int_LineaActual, 3] = "1ER NOMBRE";
                    xlWorkSheet.Cells[_Int_LineaActual, 4] = "2DO NOMBRE";
                    xlWorkSheet.Cells[_Int_LineaActual, 5] = "1ER APELLIDO";
                    xlWorkSheet.Cells[_Int_LineaActual, 6] = "2DO APELLIDO";
                    xlWorkSheet.Cells[_Int_LineaActual, 7] = "ESTADO CIVIL";
                    xlWorkSheet.Cells[_Int_LineaActual, 8] = "PROFESION";
                    xlWorkSheet.Cells[_Int_LineaActual, 9] = "LUGAR NACIMIENTO";
                    xlWorkSheet.Cells[_Int_LineaActual, 10] = "FECHA NACIMIENTO";
                    xlWorkSheet.Cells[_Int_LineaActual, 11] = "DIRECCION DE HABITACIÓN";
                    xlWorkSheet.Cells[_Int_LineaActual, 12] = "CIUDAD";
                    xlWorkSheet.Cells[_Int_LineaActual, 13] = "ESTADO";
                    xlWorkSheet.Cells[_Int_LineaActual, 14] = "TELÉFONO PERSONAL";
                    xlWorkSheet.Cells[_Int_LineaActual, 15] = "CELULAR";
                    xlWorkSheet.Cells[_Int_LineaActual, 16] = "EMAIL";
                    xlWorkSheet.Cells[_Int_LineaActual, 17] = "NOMBRE DE LA EMPRESA";
                    xlWorkSheet.Cells[_Int_LineaActual, 18] = "CARGO";
                    xlWorkSheet.Cells[_Int_LineaActual, 19] = "SALARIO";
                    xlWorkSheet.Cells[_Int_LineaActual, 20] = "DIRECCION DE LA EMPRESA";
                    xlWorkSheet.Cells[_Int_LineaActual, 21] = "CIUDAD DE LA EMPRESA";
                    xlWorkSheet.Cells[_Int_LineaActual, 22] = "ESTADO DE LA EMPRESA";
                    xlWorkSheet.Cells[_Int_LineaActual, 23] = "TELÉFONO DE LA EMPRESA";
                    xlWorkSheet.Cells[_Int_LineaActual, 24] = "REFERENCIA EN LA EMPRESA";
                    xlWorkSheet.Cells[_Int_LineaActual, 25] = "MOTIVOS";

                    _Int_LineaActual++;
                    int _Int_ContadorIngresosPendientes = 0;

                    for (int i = 0; i <= _DS_IngresosPendientes.Tables[0].Rows.Count - 1; i++)
                    {
                        _Int_ContadorIngresosPendientes++;

                        _Str_ccedula = _DS_IngresosPendientes.Tables[0].Rows[i]["ccedula"].ToString().Trim();
                        _Str_cnombre1 = _DS_IngresosPendientes.Tables[0].Rows[i]["cnombre1"].ToString().Trim();
                        _Str_cnombre2 = _DS_IngresosPendientes.Tables[0].Rows[i]["cnombre2"].ToString().Trim();
                        _Str_capellido1 = _DS_IngresosPendientes.Tables[0].Rows[i]["capellido1"].ToString().Trim();
                        _Str_capellido2 = _DS_IngresosPendientes.Tables[0].Rows[i]["capellido2"].ToString().Trim();
                        _Str_cestado_civil = _DS_IngresosPendientes.Tables[0].Rows[i]["cestado_civil"].ToString().Trim();
                        _Str_cprofesion = "";
                        _Str_cciudad_na = _DS_IngresosPendientes.Tables[0].Rows[i]["cciudad_na"].ToString().Trim();
                        _Str_cfecha_na = _DS_IngresosPendientes.Tables[0].Rows[i]["cfecha_na"].ToString().Trim();
                        _Str_cdireccion_empleado = _DS_IngresosPendientes.Tables[0].Rows[i]["cdireccion_empleado"].ToString().Trim();
                        _Str_cciudad_empleado = _DS_IngresosPendientes.Tables[0].Rows[i]["cciudad_empleado"].ToString().Trim();
                        _Str_cestado_empleado = _DS_IngresosPendientes.Tables[0].Rows[i]["cestado_empleado"].ToString().Trim();
                        _Str_ctlf_celular = _DS_IngresosPendientes.Tables[0].Rows[i]["ctlf_celular"].ToString().Trim();
                        _Str_ctlf_habitacion = _DS_IngresosPendientes.Tables[0].Rows[i]["ctlf_habitacion"].ToString().Trim();
                        _Str_cemail = _DS_IngresosPendientes.Tables[0].Rows[i]["cemail"].ToString().Trim();
                        _Str_cnombre_empresa = _DS_IngresosPendientes.Tables[0].Rows[i]["cnombre_empresa"].ToString().Trim();
                        _Str_ccargo = _DS_IngresosPendientes.Tables[0].Rows[i]["ccargo"].ToString().Trim();
                        _Str_csalario = "";
                        _Str_cdireccion_empresa = _DS_IngresosPendientes.Tables[0].Rows[i]["cdireccion_empresa"].ToString().Trim();
                        _Str_cciudad_empresa = _DS_IngresosPendientes.Tables[0].Rows[i]["cciudad_empresa"].ToString().Trim();
                        _Str_cestado_empresa = _DS_IngresosPendientes.Tables[0].Rows[i]["cestado_empresa"].ToString().Trim();
                        _Str_ctlf_empresa = _DS_IngresosPendientes.Tables[0].Rows[i]["ctlf_empresa"].ToString().Trim();
                        _Str_creferencia = "";
                        _Str_cmotivo = "APERTURAS DE CUENTAS";

                        xlWorkSheet.Cells[_Int_LineaActual, 1] = _Int_ContadorIngresosPendientes.ToString();
                        xlWorkSheet.Cells[_Int_LineaActual, 2] = _Str_ccedula;
                        xlWorkSheet.Cells[_Int_LineaActual, 3] = _Str_cnombre1;
                        xlWorkSheet.Cells[_Int_LineaActual, 4] = _Str_cnombre2;
                        xlWorkSheet.Cells[_Int_LineaActual, 5] = _Str_capellido1;
                        xlWorkSheet.Cells[_Int_LineaActual, 6] = _Str_capellido2;
                        xlWorkSheet.Cells[_Int_LineaActual, 7] = _Str_cestado_civil;
                        xlWorkSheet.Cells[_Int_LineaActual, 8] = _Str_cprofesion;
                        xlWorkSheet.Cells[_Int_LineaActual, 9] = _Str_cciudad_na;
                        xlWorkSheet.Cells[_Int_LineaActual, 10] = _Str_cfecha_na;
                        xlWorkSheet.Cells[_Int_LineaActual, 11] = _Str_cdireccion_empleado;
                        xlWorkSheet.Cells[_Int_LineaActual, 12] = _Str_cciudad_empleado;
                        xlWorkSheet.Cells[_Int_LineaActual, 13] = _Str_cestado_empleado;
                        xlWorkSheet.Cells[_Int_LineaActual, 14] = _Str_ctlf_celular;
                        xlWorkSheet.Cells[_Int_LineaActual, 15] = _Str_ctlf_habitacion;
                        xlWorkSheet.Cells[_Int_LineaActual, 16] = _Str_cemail;
                        xlWorkSheet.Cells[_Int_LineaActual, 17] = _Str_cnombre_empresa;
                        xlWorkSheet.Cells[_Int_LineaActual, 18] = _Str_ccargo;
                        xlWorkSheet.Cells[_Int_LineaActual, 19] = _Str_csalario;
                        xlWorkSheet.Cells[_Int_LineaActual, 20] = _Str_cdireccion_empresa;
                        xlWorkSheet.Cells[_Int_LineaActual, 21] = _Str_cciudad_empresa;
                        xlWorkSheet.Cells[_Int_LineaActual, 22] = _Str_cestado_empresa;
                        xlWorkSheet.Cells[_Int_LineaActual, 23] = _Str_ctlf_empresa;
                        xlWorkSheet.Cells[_Int_LineaActual, 24] = _Str_creferencia;
                        xlWorkSheet.Cells[_Int_LineaActual, 25] = _Str_cmotivo;

                        _Int_LineaActual++;
                    }

                }
                
                // egresos ==================================================================================================
                
                if (_DS_EgresosPendientes.Tables[0].Rows.Count > 0)
                {
                    _Int_LineaActual++;
                    xlWorkSheet.Cells[_Int_LineaActual, 1] = "INACTIVAR";

                    _Int_LineaActual++;
                    _Int_LineaActual++;

                    xlWorkSheet.Cells[_Int_LineaActual, 1] = "CANTIDAD";
                    xlWorkSheet.Cells[_Int_LineaActual, 2] = "CEDULA DE IDENTIDAD";
                    xlWorkSheet.Cells[_Int_LineaActual, 3] = "1ER NOMBRE";
                    xlWorkSheet.Cells[_Int_LineaActual, 4] = "2DO NOMBRE";
                    xlWorkSheet.Cells[_Int_LineaActual, 5] = "1ER APELLIDO";
                    xlWorkSheet.Cells[_Int_LineaActual, 6] = "2DO APELLIDO";
                    xlWorkSheet.Cells[_Int_LineaActual, 7] = "ESTADO CIVIL";
                    xlWorkSheet.Cells[_Int_LineaActual, 8] = "PROFESION";
                    xlWorkSheet.Cells[_Int_LineaActual, 9] = "LUGAR NACIMIENTO";
                    xlWorkSheet.Cells[_Int_LineaActual, 10] = "FECHA NACIMIENTO";
                    xlWorkSheet.Cells[_Int_LineaActual, 11] = "DIRECCION DE HABITACIÓN";
                    xlWorkSheet.Cells[_Int_LineaActual, 12] = "CIUDAD";
                    xlWorkSheet.Cells[_Int_LineaActual, 13] = "ESTADO";
                    xlWorkSheet.Cells[_Int_LineaActual, 14] = "TELÉFONO PERSONAL";
                    xlWorkSheet.Cells[_Int_LineaActual, 15] = "CELULAR";
                    xlWorkSheet.Cells[_Int_LineaActual, 16] = "EMAIL";
                    xlWorkSheet.Cells[_Int_LineaActual, 17] = "NOMBRE DE LA EMPRESA";
                    xlWorkSheet.Cells[_Int_LineaActual, 18] = "CARGO";
                    xlWorkSheet.Cells[_Int_LineaActual, 19] = "SALARIO";
                    xlWorkSheet.Cells[_Int_LineaActual, 20] = "DIRECCION DE LA EMPRESA";
                    xlWorkSheet.Cells[_Int_LineaActual, 21] = "CIUDAD DE LA EMPRESA";
                    xlWorkSheet.Cells[_Int_LineaActual, 22] = "ESTADO DE LA EMPRESA";
                    xlWorkSheet.Cells[_Int_LineaActual, 23] = "TELÉFONO DE LA EMPRESA";
                    xlWorkSheet.Cells[_Int_LineaActual, 24] = "REFERENCIA EN LA EMPRESA";
                    xlWorkSheet.Cells[_Int_LineaActual, 25] = "MOTIVOS";

                    _Int_LineaActual++;
                    int _Int_ContadorEgresosPendientes = 0;

                    for (int i = 0; i <= _DS_EgresosPendientes.Tables[0].Rows.Count - 1; i++)
                    {
                        _Int_ContadorEgresosPendientes++;

                        _Str_ccedula = _DS_EgresosPendientes.Tables[0].Rows[i]["ccedula"].ToString().Trim();
                        _Str_cnombre1 = _DS_EgresosPendientes.Tables[0].Rows[i]["cnombre1"].ToString().Trim();
                        _Str_cnombre2 = _DS_EgresosPendientes.Tables[0].Rows[i]["cnombre2"].ToString().Trim();
                        _Str_capellido1 = _DS_EgresosPendientes.Tables[0].Rows[i]["capellido1"].ToString().Trim();
                        _Str_capellido2 = _DS_EgresosPendientes.Tables[0].Rows[i]["capellido2"].ToString().Trim();
                        _Str_cestado_civil = _DS_EgresosPendientes.Tables[0].Rows[i]["cestado_civil"].ToString().Trim();
                        _Str_cprofesion = "";
                        _Str_cciudad_na = _DS_EgresosPendientes.Tables[0].Rows[i]["cciudad_na"].ToString().Trim();
                        _Str_cfecha_na = _DS_EgresosPendientes.Tables[0].Rows[i]["cfecha_na"].ToString().Trim();
                        _Str_cdireccion_empleado = _DS_EgresosPendientes.Tables[0].Rows[i]["cdireccion_empleado"].ToString().Trim();
                        _Str_cciudad_empleado = _DS_EgresosPendientes.Tables[0].Rows[i]["cciudad_empleado"].ToString().Trim();
                        _Str_cestado_empleado = _DS_EgresosPendientes.Tables[0].Rows[i]["cestado_empleado"].ToString().Trim();
                        _Str_ctlf_celular = _DS_EgresosPendientes.Tables[0].Rows[i]["ctlf_celular"].ToString().Trim();
                        _Str_ctlf_habitacion = _DS_EgresosPendientes.Tables[0].Rows[i]["ctlf_habitacion"].ToString().Trim();
                        _Str_cemail = _DS_EgresosPendientes.Tables[0].Rows[i]["cemail"].ToString().Trim();
                        _Str_cnombre_empresa = _DS_EgresosPendientes.Tables[0].Rows[i]["cnombre_empresa"].ToString().Trim();
                        _Str_ccargo = _DS_EgresosPendientes.Tables[0].Rows[i]["ccargo"].ToString().Trim();
                        _Str_csalario = "";
                        _Str_cdireccion_empresa = _DS_EgresosPendientes.Tables[0].Rows[i]["cdireccion_empresa"].ToString().Trim();
                        _Str_cciudad_empresa = _DS_EgresosPendientes.Tables[0].Rows[i]["cciudad_empresa"].ToString().Trim();
                        _Str_cestado_empresa = _DS_EgresosPendientes.Tables[0].Rows[i]["cestado_empresa"].ToString().Trim();
                        _Str_ctlf_empresa = _DS_EgresosPendientes.Tables[0].Rows[i]["ctlf_empresa"].ToString().Trim();
                        _Str_creferencia = "";
                        _Str_cmotivo = "INACTIVAR CUENTA";

                        xlWorkSheet.Cells[_Int_LineaActual, 1] = _Int_ContadorEgresosPendientes.ToString();
                        xlWorkSheet.Cells[_Int_LineaActual, 2] = _Str_ccedula;
                        xlWorkSheet.Cells[_Int_LineaActual, 3] = _Str_cnombre1;
                        xlWorkSheet.Cells[_Int_LineaActual, 4] = _Str_cnombre2;
                        xlWorkSheet.Cells[_Int_LineaActual, 5] = _Str_capellido1;
                        xlWorkSheet.Cells[_Int_LineaActual, 6] = _Str_capellido2;
                        xlWorkSheet.Cells[_Int_LineaActual, 7] = _Str_cestado_civil;
                        xlWorkSheet.Cells[_Int_LineaActual, 8] = _Str_cprofesion;
                        xlWorkSheet.Cells[_Int_LineaActual, 9] = _Str_cciudad_na;
                        xlWorkSheet.Cells[_Int_LineaActual, 10] = _Str_cfecha_na;
                        xlWorkSheet.Cells[_Int_LineaActual, 11] = _Str_cdireccion_empleado;
                        xlWorkSheet.Cells[_Int_LineaActual, 12] = _Str_cciudad_empleado;
                        xlWorkSheet.Cells[_Int_LineaActual, 13] = _Str_cestado_empleado;
                        xlWorkSheet.Cells[_Int_LineaActual, 14] = _Str_ctlf_celular;
                        xlWorkSheet.Cells[_Int_LineaActual, 15] = _Str_ctlf_habitacion;
                        xlWorkSheet.Cells[_Int_LineaActual, 16] = _Str_cemail;
                        xlWorkSheet.Cells[_Int_LineaActual, 17] = _Str_cnombre_empresa;
                        xlWorkSheet.Cells[_Int_LineaActual, 18] = _Str_ccargo;
                        xlWorkSheet.Cells[_Int_LineaActual, 19] = _Str_csalario;
                        xlWorkSheet.Cells[_Int_LineaActual, 20] = _Str_cdireccion_empresa;
                        xlWorkSheet.Cells[_Int_LineaActual, 21] = _Str_cciudad_empresa;
                        xlWorkSheet.Cells[_Int_LineaActual, 22] = _Str_cestado_empresa;
                        xlWorkSheet.Cells[_Int_LineaActual, 23] = _Str_ctlf_empresa;
                        xlWorkSheet.Cells[_Int_LineaActual, 24] = _Str_creferencia;
                        xlWorkSheet.Cells[_Int_LineaActual, 25] = _Str_cmotivo;

                        _Int_LineaActual++;
                    }
                }


                // modifica - fin ====================================================================================

                Cursor = Cursors.Default;

                string _Str_NombreOmision = CLASES._Cls_Varios_Metodos._Mtd_NombreReportesExportacion("UNITICKET_" + Frm_Padre._Str_Comp.Trim());
                saveFileDialog1.FileName = _Str_NombreOmision;

                bool _Bol_ReporteGenerado = false;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    xlWorkBook.SaveAs(saveFileDialog1.FileName, misValue, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlNoChange, misValue, misValue, misValue, misValue, misValue);
                    _Bol_ReporteGenerado = true;

                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();
                }


                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                FindAndKillProcess("EXCEL");

                if (_Bol_ReporteGenerado)
                {
                    // marca los registros como reportados
                    _Str_SQL = "UPDATE TEMPLEADOS_SPI SET cingreso_reportado = '1' WHERE ccompany = '" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                    _Str_SQL = "UPDATE TEMPLEADOS_SPI SET cegreso_reportado = '1' WHERE ISNULL(cfecha_egreso,'') <> '' AND ccompany = '" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                    _Mtd_LlenarGridPrincipal();
                    
                    System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                }
            }
            else
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Lo sentimos, no se encuentra la plantilla de UNITICKET. Por favor contacte al desarrollador.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private string _Mtd_NombComp()
        {
            string _Str_Cadena = "Select cname from dbo.TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
            }
            return "";
        }

        public bool FindAndKillProcess(string name)
        {
            //here we're going to get a list of all running processes on
            //the computer
            foreach (Process clsProcess in Process.GetProcesses())
            {
                //now we're going to see if any of the running processes
                //match the currently running processes by using the StartsWith Method,
                //this prevents us from incluing the .EXE for the process we're looking for.
                //. Be sure to not
                //add the .exe to the name you provide, i.e: NOTEPAD,
                //not NOTEPAD.EXE or false is always returned even if
                //notepad is running
                if (clsProcess.ProcessName.StartsWith(name))
                {
                    //since we found the proccess we now need to use the
                    //Kill Method to kill the process. Remember, if you have
                    //the process running more than once, say IE open 4
                    //times the loop thr way it is now will close all 4,
                    //if you want it to just close the first one it finds
                    //then add a return; after the Kill
                    clsProcess.Kill();
                    //process killed, return true
                    return true;
                }
            }
            //process not found, return false
            return false;
        }

        private void _Cmb_Filtro_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_LlenarGridPrincipal();
        }

        private void _Dg_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgInfo.Visible = true;
            }
            else
            {
                _Lbl_DgInfo.Visible = false;
            }
        }

    }
}
