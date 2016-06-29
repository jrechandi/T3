using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.OleDb;

namespace T3
{
    public partial class Frm_IncVisibilidad : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        //private Excel.ApplicationClass _ExcelApp;

        public Frm_IncVisibilidad()
        {
            InitializeComponent();
        }

        private void Frm_IncVisibilidad_Load(object sender, EventArgs e)
        {
            _Mtd_LlenarComboAno(Frm_Padre._Str_Comp);
        }
        
        private void _Btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _Mtd_LlenarComboAno(string _Str_CodigoCompania)
        {
            _Cb_Ano.Items.Clear();
            
            //string _Str_Sql = "SELECT cyearacco, cmontacco, cfecejecucion1, ISNULL(cfecejecucion2,''), cperejecucion1d, ISNULL(cperejecucion2d,''), ISNULL(cperejecucion2h,''), cperejecucion1h FROM TCONFIGINCVTAS WHERE (ccompany = '" + _Str_CodigoCompania + "') ORDER BY cyearacco DESC, cmontacco DESC, cfecejecucion1 DESC, cfecejecucion2 DESC";
            string _Str_Sql = "SELECT DISTINCT canoventas FROM TCONFIGINCVTAS WHERE (ccompany = '" + _Str_CodigoCompania + "') ORDER BY canoventas DESC";

            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if ( _Ds_Data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _Row in _Ds_Data.Tables[0].Rows)
                {
                    _Cb_Ano.Items.Add(Convert.ToString(_Row["canoventas"]));
                }
            }

            if (_Cb_Ano.Items.Count > 0)
            {
                _Cb_Ano.SelectedIndex = 0;

                _Mtd_LlenarComboMes(_Str_CodigoCompania, _Cb_Ano.SelectedItem.ToString());
            }
        }

        private void _Mtd_LlenarComboMes(string _Str_CodigoCompania, string _Str_Ano)
        {
            _Cb_Mes.Items.Clear();

            string _Str_Sql = "SELECT DISTINCT cmesventas FROM TCONFIGINCVTAS WHERE (ccompany = '" + _Str_CodigoCompania + "') and canoventas = '" + _Str_Ano + "' ORDER BY cmesventas DESC";

            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _Row in _Ds_Data.Tables[0].Rows)
                {
                    _Cb_Mes.Items.Add(Convert.ToString(_Row["cmesventas"]));
                }
            }

            _Cb_Mes.SelectedIndex = 0;

            _Mtd_LlenarComboEjecucion(_Str_CodigoCompania, _Str_Ano, _Cb_Mes.SelectedItem.ToString());
        }

        private void _Mtd_LlenarComboEjecucion(string _Str_CodigoCompania, string _Str_AnoVentas, string _Str_MesVentas)
        {
            string _Str_Cadena = "";
            _Cb_Ejecucion.Items.Clear();

            string _Str_Sql = "SELECT CONVERT(VARCHAR,cfecejecucion1,103) as cfecejecucion1, CONVERT(VARCHAR,cfecejecucion2,103) as cfecejecucion2, CONVERT(VARCHAR,cperejecucion1d,103) as cperejecucion1d, CONVERT(VARCHAR,cperejecucion1h,103) as cperejecucion1h, CONVERT(VARCHAR,cperejecucion2d,103) as cperejecucion2d, CONVERT(VARCHAR,cperejecucion2h,103) as cperejecucion2h FROM TCONFIGINCVTAS WHERE (ccompany = '" + _Str_CodigoCompania + "') and canoventas = '" + _Str_AnoVentas + "' and cmesventas = '" + _Str_MesVentas + "' ORDER BY cmontacco DESC";

            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {     
                foreach (DataRow _Row in _Ds_Data.Tables[0].Rows)
                {
                    //_Str_Cadena = "1: Ejecucion " + Convert.ToString(_Row["cfecejecucion1"]) + ", calculo desde " + Convert.ToString(_Row["cperejecucion1d"]) + " hasta " + Convert.ToString(_Row["cperejecucion1h"]);
                    _Str_Cadena = "1: Desde " + Convert.ToString(_Row["cperejecucion1d"]) + ", hasta " + Convert.ToString(_Row["cperejecucion1h"]);
                    _Cb_Ejecucion.Items.Add(_Str_Cadena);

                    if (Convert.ToString(_Row["cfecejecucion2"]) != "")
                    {
                        //_Str_Cadena = "2: Ejecucion " + Convert.ToString(_Row["cfecejecucion2"]) + ", calculo desde " + Convert.ToString(_Row["cperejecucion2d"]) + " hasta " + Convert.ToString(_Row["cperejecucion2h"]);
                        _Str_Cadena = "2: Desde " + Convert.ToString(_Row["cperejecucion2d"]) + ", hasta " + Convert.ToString(_Row["cperejecucion2h"]);
                        _Cb_Ejecucion.Items.Add(_Str_Cadena);
                    }
                }
            }

            _Cb_Ejecucion.SelectedIndex = 0;

        }

        private void _Cb_Ano_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_LlenarComboMes(Frm_Padre._Str_Comp, _Cb_Ano.SelectedItem.ToString());
        }

        private void _Cb_Mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_LlenarComboEjecucion(Frm_Padre._Str_Comp, _Cb_Ano.SelectedItem.ToString(), _Cb_Mes.SelectedItem.ToString());
        }

        private void _Btn_Generar_Click(object sender, EventArgs e)
        {
            // comprueba que existan ejecuciones programadas
            if (_Cb_Ejecucion.Items.Count > 0)
            {
                try
                {
                    _Sfd_Generar.FileName = CLASES._Cls_Varios_Metodos._Mtd_NombreReportesExportacion("INC_VISIBILIDAD") + ".xls"; ;

                    if (_Sfd_Generar.ShowDialog() == DialogResult.OK)
                    {
                        Thread _Thr_Thread = new Thread(new ThreadStart(_Mtd_GenerarListado));
                        _Thr_Thread.Start();
                        while (!_Thr_Thread.IsAlive) ;
                        Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread, "Espere por favor...");
                        _Frm_Form.ShowDialog(this);
                        _Frm_Form.Dispose();
                    }
                }
                catch { Cursor = Cursors.Default; MessageBox.Show("Lo sentimos, ha ocurrido un error generando el listado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            {
                MessageBox.Show("Lo sentimos, no existen incentivos programados para esta compañia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void _Mtd_GenerarListado()
        {
            string _Str_CodigoCompania = Frm_Padre._Str_Comp;

            string _Str_Sql = "select Grupo, Usuario, Nombre, 0 as Comision from VST_INC_VIS_LISTADO_INCENTIVADOS where ccompany = '" + _Str_CodigoCompania + "'";

            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                Clases._Cls_ExcelUtilidades _Cls_ExcelUtilidades = new T3.Clases._Cls_ExcelUtilidades();
                _Cls_ExcelUtilidades._Mtd_DatasetToExcel(_Ds_Data.Tables[0], _Sfd_Generar.FileName, "LISTADO");
                _Cls_ExcelUtilidades = null;
            }
        
        }

        private void _Btn_Importar_Click(object sender, EventArgs e)
        {
             // comprueba que existan ejecuciones programadas
            if (_Cb_Ejecucion.Items.Count > 0)
            {
                bool _Bol_Ejecutar;

                // estos campos son iguales para todo el periodo/ejecucion
                string _Str_ccompany = Frm_Padre._Str_Comp;

                string _Str_canoventas = _Cb_Ano.SelectedItem.ToString();
                string _Str_cmesventas = _Cb_Mes.SelectedItem.ToString();

                string _Str_cyearacco = _Mtd_ObtenerAnoEjecucionSegunAnoMesVentas(_Str_ccompany, _Str_canoventas, _Str_cmesventas);
                string _Str_cmontacco = _Mtd_ObtenerMesEjecucionSegunAnoMesVentas(_Str_ccompany, _Str_canoventas, _Str_cmesventas);

                string _Str_ctipogeneracion = Convert.ToString(_Cb_Ejecucion.SelectedItem)[0].ToString(); // solo el primer caracter del string, que siempre es '1' o '2'


                if (_Mtd_ExistenRegistrosPrevios(_Str_ccompany, _Str_cyearacco, _Str_cmontacco, _Str_ctipogeneracion))
                {
                    if (MessageBox.Show("Ya existen registros para el periodo seleccionado. ¿Desea reemplazarlos?", "Reemplazar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        _Bol_Ejecutar = true;
                    }
                    else
                    {
                        _Bol_Ejecutar = false;
                    }
                }
                else
                {
                    _Bol_Ejecutar = true;
                }

                if (_Bol_Ejecutar)
                {
                    if (_Ofp_Importar.ShowDialog() == DialogResult.OK)
                    {
                        ExcelReader _ER_ExcelReader = new ExcelReader(_Ofp_Importar.FileName);

                        DataTable _Dt_Importar = _ER_ExcelReader.GetExcelData();

                        if (_Dt_Importar != null) // si el archivo excel es válido
                        {
                            if (_Mtd_ValidarListadoImportado(_Dt_Importar))
                            {

                                // estos campos son iguales para todo el periodo/ejecucion
                                string _Str_cgroupcomp = Frm_Padre._Str_GroupComp;
                                string _Str_cdateadd = "GETDATE()";
                                string _Str_cuseradd = Frm_Padre._Str_Use;

                                // estos campos varian de registro en registro
                                string _Str_cidgrupincentivar = "";
                                string _Str_cvendedor = "";
                                string _Str_ccomisionapag = "";


                                string _Str_CodigoCompania = _Str_ccompany;
                                string _Str_Sql = "select cidgrupincentivar, Grupo, Usuario, Nombre from VST_INC_VIS_LISTADO_INCENTIVADOS where ccompany = '" + _Str_CodigoCompania + "'";

                                int _Int_ContadorInserciones = 0;

                                DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds_Data.Tables[0].Rows.Count > 0)
                                {

                                    _Mtd_EliminarRegistrosPrevios(_Str_ccompany, _Str_cyearacco, _Str_cmontacco, _Str_ctipogeneracion);
                                    foreach (DataRow _Row in _Ds_Data.Tables[0].Rows)
                                    {
                                        _Str_cidgrupincentivar = Convert.ToString(_Row["cidgrupincentivar"]);
                                        _Str_cvendedor = Convert.ToString(_Row["Usuario"]);
                                        _Str_ccomisionapag = _Mtd_ObtenerComisionUsuario(_Dt_Importar, _Str_cvendedor);

                                        // si el usuario tiene comision mayor a cero, se inserta, sino, se ignora
                                        if (Convert.ToDouble(_Str_ccomisionapag) > 0)
                                        {
                                            _Int_ContadorInserciones++;
                                            _Mtd_InsertarRegistroFinalVisibilidad(_Str_cidgrupincentivar, _Str_cgroupcomp, _Str_ccompany, _Str_cvendedor, _Str_cyearacco, _Str_cmontacco, _Str_ccomisionapag, _Str_cdateadd, _Str_cuseradd, _Str_ctipogeneracion);
                                        }
                                    }
                                }

                                if (_Int_ContadorInserciones > 0)
                                {
                                    MessageBox.Show("Se han importado los datos satisfactoriamente. Se incluyeron " + _Int_ContadorInserciones.ToString() + " registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //MessageBox.Show("¿Desea ver el reporte de incentivo visibilidad para este periodo?", "Reporte", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                }
                                else
                                {
                                    MessageBox.Show("Se ha completado el proceso, pero no se importó ningún dato. ¿Está seguro de que seleccionó el listado correcto para esta compañia?. Verifique.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }

                            }
                        }

                        _Dt_Importar = null;
                        _ER_ExcelReader = null;

                    } // end-if
                } // end-el-otro-if

            }
            else
            {
                MessageBox.Show("Lo sentimos, no existen incentivos programados para esta compañia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
                    
            

        }

        private string _Mtd_ObtenerComisionUsuario(DataTable _Dt_DataTable, string _Str_CodigoUsuario)
        {
            string expression;
            expression = "Usuario = '" + _Str_CodigoUsuario + "'";
            DataRow[] foundRows;

            // Use the Select method to find all rows matching the filter.
            foundRows = _Dt_DataTable.Select(expression);

            if (foundRows.Length > 0)
            {
                return CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(foundRows[0]["Comision"]));
            }
            else
            {
                return "0";
            }
        }

        private bool _Mtd_ValidarListadoImportado(DataTable _Dt_DataTable)
        {
            double _Dbl_Monto;
            bool _Bol_Retornar = true;
            for (int _Int_I = 0; _Int_I <= _Dt_DataTable.Rows.Count - 1; _Int_I++)
            {

                try
                {
                    _Dbl_Monto = Convert.ToDouble(_Dt_DataTable.Rows[_Int_I]["Comision"]);
                }
                catch(InvalidCastException ex)
                {
                    MessageBox.Show("Disculpe, hay montos inválidos en el listado. Por favor verifique antes de seguir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _Bol_Retornar = false;
                    break;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Disculpe, archivo excel que está importando no contiene un listado válido. Por favor verifique antes de seguir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _Bol_Retornar = false;
                    break;
                }

            }

            return _Bol_Retornar;
        }


        private void _Mtd_InsertarRegistroFinalVisibilidad(string _Str_cidgrupincentivar, string _Str_cgroupcomp, string _Str_ccompany, string _Str_cvendedor, string _Str_cyearacco, string _Str_cmontacco, string _Str_ccomisionapag, string _Str_cdateadd, string _Str_cuseradd, string _Str_ctipogeneracion)
        {
            string _Str_Sql = "";
            _Str_Sql += "INSERT INTO TCALINCVIS";
            _Str_Sql += "(";
            _Str_Sql += "	cidgrupincentivar,";
            _Str_Sql += "	cgroupcomp,";
            _Str_Sql += "	ccompany,";
            _Str_Sql += "	cvendedor,";
            _Str_Sql += "	cyearacco,";
            _Str_Sql += "	cmontacco,";
            _Str_Sql += "	ccomisionapag,";
            _Str_Sql += "	cdateadd,";
            _Str_Sql += "	cuseradd,";
            _Str_Sql += "	ctipogeneracion";
            _Str_Sql += ")";
            _Str_Sql += "VALUES ";
            _Str_Sql += "(";
            _Str_Sql += "	'" + _Str_cidgrupincentivar + "',";
            _Str_Sql += "	'" + _Str_cgroupcomp + "',";
            _Str_Sql += "	'" + _Str_ccompany + "',";
            _Str_Sql += "	'" + _Str_cvendedor + "',";
            _Str_Sql += "	'" + _Str_cyearacco + "',";
            _Str_Sql += "	'" + _Str_cmontacco + "',";
            _Str_Sql += "	'" + _Str_ccomisionapag + "',";
            _Str_Sql += "	" + _Str_cdateadd + ",";
            _Str_Sql += "	'" + _Str_cuseradd + "',";
            _Str_Sql += "	'" + _Str_ctipogeneracion + "'";
            _Str_Sql += ");";

            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
        
        }

        public class ExcelReader
        {

            string OledbConnectionString = string.Empty;
            private OleDbConnection objConn = null;


            public ExcelReader(string ExcelFilePath)
            {
                OledbConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ExcelFilePath + ";Extended Properties=\"EXCEL 12.0 XML;HDR=YES;IMEX=1\";Persist Security Info=True;Jet OLEDB:Database Password=admin";

                //OledbConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ExcelFilePath + ";Extended Properties=Excel 8.0;";
                objConn = new OleDbConnection(OledbConnectionString);
            }

            public DataTable GetExcelData()
            {
                try
                {

                    if (objConn.State == ConnectionState.Closed)
                    {
                        objConn.Open();
                    }
                    else
                        objConn.Open();

                    OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [LISTADO$]", objConn);

                    OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();

                    objAdapter1.SelectCommand = objCmdSelect;

                    DataSet objDataset1 = new DataSet();

                    objAdapter1.Fill(objDataset1);

                    objConn.Close();

                    return objDataset1.Tables[0];

                }
                catch (Exception ex)
                {
                    objConn.Close();
                    //throw ex;
                    MessageBox.Show("Disculpe, archivo excel que está importando no contiene un listado válido. Por favor verifique antes de seguir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        private bool _Mtd_ExistenRegistrosPrevios(string _Str_CodigoCompania, string _Str_Ano, string _Str_Mes, string _Str_TipoGeneracion)
        {

            string _Str_Sql = "select cidcalinvis from TCALINCVIS where CCOMPANY = '" + _Str_CodigoCompania + "' AND cyearacco = '" + _Str_Ano + "' AND cmontacco = ' " + _Str_Mes + "' AND ctipogeneracion = '" + _Str_TipoGeneracion + "'";

            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void _Mtd_EliminarRegistrosPrevios(string _Str_CodigoCompania, string _Str_Ano, string _Str_Mes, string _Str_TipoGeneracion)
        {
            string _Str_Sql = "DELETE from TCALINCVIS where CCOMPANY = '" + _Str_CodigoCompania + "' AND cyearacco = '" + _Str_Ano + "' AND cmontacco = ' " + _Str_Mes + "' AND ctipogeneracion = '" + _Str_TipoGeneracion + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
        }

        private string _Mtd_ObtenerAnoEjecucionSegunAnoMesVentas(string _Str_CodigoCompania, string _Str_AnoVentas, string _Str_MesVentas)
        {
            string _Str_Sql = "SELECT cyearacco FROM TCONFIGINCVTAS WHERE ccompany = '" + _Str_CodigoCompania + "' and canoventas = '" + _Str_AnoVentas + "' and cmesventas = '" + _Str_MesVentas + "'";
            string _Str_Retornar = "";

            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _Row in _Ds_Data.Tables[0].Rows)
                {
                    _Str_Retornar = Convert.ToString(_Row["cyearacco"]);
                }
            }

            return _Str_Retornar;
        }

        private string _Mtd_ObtenerMesEjecucionSegunAnoMesVentas(string _Str_CodigoCompania, string _Str_AnoVentas, string _Str_MesVentas)
        {
            string _Str_Sql = "SELECT cmontacco FROM TCONFIGINCVTAS WHERE ccompany = '" + _Str_CodigoCompania + "' and canoventas = '" + _Str_AnoVentas + "' and cmesventas = '" + _Str_MesVentas + "'";
            string _Str_Retornar = "";

            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _Row in _Ds_Data.Tables[0].Rows)
                {
                    _Str_Retornar = Convert.ToString(_Row["cmontacco"]);
                }
            }

            return _Str_Retornar;
        }

    } // formulario
} // namespace
