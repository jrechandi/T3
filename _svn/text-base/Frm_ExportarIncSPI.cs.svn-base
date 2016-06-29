using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ExportarIncSPI : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new T3.CLASES._Cls_Varios_Metodos(true);
        public Frm_ExportarIncSPI()
        {
            InitializeComponent();
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarMeses();
            Cursor = Cursors.Default;
        }
        private void _Mtd_CargarMeses()
        {
            string _Str_Cadena = _Str_Cadena = "SELECT CONVERT(VARCHAR,cmesventas)+'-'+CONVERT(VARCHAR,canoventas),CONVERT(VARCHAR,cmesventas)+'-'+CONVERT(VARCHAR,canoventas) FROM TCONFIGINCVTAS WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Mes, _Str_Cadena);
        }
        private string[] _Mtd_ExtraerMesAno(string _P_Str_Items)
        {
            int _Int_i = _P_Str_Items.Trim().IndexOf("-");
            return new string[] { _P_Str_Items.Substring(0, _Int_i).Trim(), _P_Str_Items.Substring(_Int_i + 1).Trim() };
        }
        private void _Mtd_Generaciones()
        {
            string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.SelectedValue.ToString());
            string _Str_Cadena = "SELECT '1','Desde '+CONVERT(VARCHAR,cperejecucion1d,103)+' hasta '+CONVERT(VARCHAR,cperejecucion1h,103) FROM TCONFIGINCVTAS WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cmesventas='" + _Str_Valores[0] + "' AND canoventas='" + _Str_Valores[1] + "'";
            _Str_Cadena += " UNION ";
            _Str_Cadena += "SELECT '2','Desde '+CONVERT(VARCHAR,cperejecucion2d,103)+' hasta '+CONVERT(VARCHAR,cperejecucion2h,103) FROM TCONFIGINCVTAS WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cmesventas='" + _Str_Valores[0] + "' AND canoventas='" + _Str_Valores[1] + "'";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Generacion, _Str_Cadena);
        }

        private void _Cmb_Mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Mes.SelectedIndex > 0)
            { Cursor = Cursors.WaitCursor; _Mtd_Generaciones(); Cursor = Cursors.Default; _Cmb_Generacion.Enabled = true; }
            else
            { _Cmb_Generacion.DataSource = null; _Cmb_Generacion.Enabled = false; }
        }

        private void _Cmb_Mes_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarMeses();
            Cursor = Cursors.Default;
        }

        private void _Cmb_Generacion_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Generaciones();
            Cursor = Cursors.Default;
        }
        private void _Mtd_IndicaExportado()
        {
            try
            {
                string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.SelectedValue.ToString());
                string _Str_CompanySPI = "";
                string _Str_Cadena = "SELECT CCODSPI FROM TCOMPANY WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                DataSet _Ds_DataSet = new DataSet();
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                foreach (DataRow _Dtw_Row in _Ds_DataSet.Tables[0].Rows)
                {
                    _Str_CompanySPI = _Dtw_Row["CCODSPI"].ToString().TrimEnd();
                }
                _Str_Cadena = "SELECT DISTINCT CEXPORTADO FROM TCALINCEXPORTSPI WHERE CCOMPANY='" + _Str_CompanySPI + "' AND ctipogeneracion='" + Convert.ToString(_Cmb_Generacion.SelectedValue).Trim() + "' AND cyearacco='" + _Str_Valores[1] + "' AND cmontacco='" + _Str_Valores[0] + "'";
                _Ds_DataSet = new DataSet();
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                int _Int_Exportado = 0;
                foreach (DataRow _Dtw_Row in _Ds_DataSet.Tables[0].Rows)
                {
                    _Int_Exportado = Convert.ToInt32(_Dtw_Row["CEXPORTADO"].ToString().TrimEnd());
                }
                if (_Int_Exportado == 1)
                {
                    _Chk_Exportado.Checked = true;
                }
                else
                {
                    _Chk_Exportado.Checked = false;
                }
            }
            catch
            {
            }
        }
        private void _Mtd_Consultar()
        {
            try
            {
                string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.SelectedValue.ToString());
                string _Str_CompanySPI = "";
                string _Str_Cadena = "SELECT CCODSPI FROM TCOMPANY WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                DataSet _Ds_DataSet = new DataSet();
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                foreach (DataRow _Dtw_Row in _Ds_DataSet.Tables[0].Rows)
                {
                    _Str_CompanySPI = _Dtw_Row["CCODSPI"].ToString().TrimEnd();
                }
                _Str_Cadena = "SELECT CONVERT(VARCHAR,cfechamovsueldant,103) AS cfecha,* FROM TCALINCEXPORTSPI WHERE CCOMPANY='" + _Str_CompanySPI + "' AND ctipogeneracion='" + Convert.ToString(_Cmb_Generacion.SelectedValue).Trim() + "' AND cyearacco='" + _Str_Valores[1] + "' AND cmontacco='" + _Str_Valores[0] + "'";
                _Ds_DataSet = new DataSet();
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                string[] _Str_Lineas = new string[_Ds_DataSet.Tables[0].Rows.Count];
                int _Int_Cont=0;
                foreach (DataRow _Dtw_Row in _Ds_DataSet.Tables[0].Rows)
                {
                    string _Str_Linea = _Mtd_Completar(_Dtw_Row["ccompany"].ToString(), 2, true,true,false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cspi"].ToString().Trim(), 0, false, false, false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cidvendedorsistnomina"].ToString(), 10, false, true, false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cconceptospi"].ToString(), 4, true, true, false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["ccantmov"].ToString(), 7, true, false, false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cmontomov"].ToString(), 14, true, true, false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cdiaesquema"].ToString(), 1, false, true, false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["ccalcsueldoant"].ToString(), 1, true, true, false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["ctiposueldant"].ToString(), 1, true, true, false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cfecha"].ToString(), 8, false, true, false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cfichavendsupl"].ToString(), 10, true, true, false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["ctabuladorsup"].ToString(), 4, true, true, false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cvalorsust"].ToString(), 13, true, true, false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cfactorsust"].ToString(), 13, true, true, false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cnosumarizar"].ToString(), 1, true, true, false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["ccontamov"].ToString(), 1, true, true, false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cdepartamentoalt"].ToString(), 10, true, true, false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cnumcontable"].ToString(), 36, true, true, false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cnumordentrab"].ToString(), 10, true, true, false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["ccodopercont"].ToString(), 6, true, true, false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cmovprocesado"].ToString(), 1, false, true, false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cnumsecmov"].ToString(), 5, true, true, false);
                    _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cobservaciones"].ToString(), 50, false,false, true);
                    _Str_Lineas[_Int_Cont] = _Str_Linea;
                    _Int_Cont++;
                }
                //this._Txt_Exportacion.Lines = _Str_Lineas;
                if (_Str_Lineas.Length > 0)
                {
                    //_Str_Cadena = "UPDATE TCALINCEXPORTSPI SET CEXPORTADO='1' WHERE CCOMPANY='" + _Str_CompanySPI + "' AND ctipogeneracion='" + Convert.ToString(_Cmb_Generacion.SelectedValue).Trim() + "' AND cyearacco='" + _Str_Valores[1] + "' AND cmontacco='" + _Str_Valores[0] + "'";
                }
            }
            catch
            {
            }
        }
        private string _Mtd_Completar(string _P_Str_Campo, int _Int_Cantidad, bool _Bol_Num, bool _Bol_Compl, bool _Bol_Derecha)
        {
            _P_Str_Campo = _P_Str_Campo.Trim();
            string _Str_Adicional = "";
            if (_Bol_Compl)
            {
                if (_Bol_Num)
                {
                    if (_P_Str_Campo.IndexOf(',') > -1)
                    {
                        int _Int_Pos = _P_Str_Campo.IndexOf(',');
                        _Str_Adicional = _P_Str_Campo.Substring(_Int_Pos, _P_Str_Campo.Length - _Int_Pos);
                        _P_Str_Campo = _P_Str_Campo.Replace(_Str_Adicional, "");
                    }
                    while (_P_Str_Campo.Length < _Int_Cantidad)
                    {
                        if (_Bol_Derecha)
                        {
                            _P_Str_Campo = _P_Str_Campo + "0";
                        }
                        else
                        {
                            _P_Str_Campo = "0" + _P_Str_Campo;
                        }
                    }
                }
                else
                {
                    while (_P_Str_Campo.Length < _Int_Cantidad)
                    {
                        if (_Bol_Derecha)
                        {
                            _P_Str_Campo = _P_Str_Campo + " ";
                        }
                        else
                        {
                            _P_Str_Campo = " " + _P_Str_Campo;
                        }
                    }
                }
            }
            else
            {
                if (_Bol_Num)
                {
                    _P_Str_Campo=_P_Str_Campo.Replace(",", ".");
                }
            }
            return "\"" + _P_Str_Campo + _Str_Adicional.Replace(",", ".") + "\"";
        }
        private void _Mtd_Exportar()
        {
            bool _Bol_Continuar;
            _Bol_Continuar = true; //Se coloco continuar porque ya se actualizo la tabla de empleados al cargar el formulario
            
            //// actualiza la tabla Empleados SPI
            //CLASES._Cls_Empleados_SPI _Cls_Empleados_SPI = new CLASES._Cls_Empleados_SPI();

            //if (_Cls_Empleados_SPI._Mtd_ActualizarTablaEmpleadosSPI(true,true,false))
            //{
            //    _Bol_Continuar = true;
            //}
            //else
            //{
            //    DialogResult _DR_DialogResult = MessageBox.Show("No se ha podido completar el proceso de actualización de datos de empleados en el sistema SPI.\n\r¿Desea continuar con la exportación a pesar de ello?","Exportación",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            //    if (_DR_DialogResult == DialogResult.Yes) _Bol_Continuar = true; else _Bol_Continuar = false;
            //}

            if (_Bol_Continuar)
            {
                // continua la exportación
                try
                {
                    //bool _Bol_Valido = true;
                    if (_Mtd_Generar())
                    {
                        string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.SelectedValue.ToString());
                        string _Str_CompanySPI = "";
                        string _Str_Cadena = "SELECT CCODSPI FROM TCOMPANY WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                        DataSet _Ds_DataSet = new DataSet();
                        _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        foreach (DataRow _Dtw_Row in _Ds_DataSet.Tables[0].Rows)
                        {
                            _Str_CompanySPI = _Dtw_Row["CCODSPI"].ToString().TrimEnd();
                        }
                        _Str_Cadena = "SELECT CONVERT(VARCHAR,cfechamovsueldant,103) AS cfecha,* FROM TCALINCEXPORTSPI WHERE CCOMPANY='" + _Str_CompanySPI + "' AND ctipogeneracion='" + Convert.ToString(_Cmb_Generacion.SelectedValue).Trim() + "' AND cyearacco='" + _Str_Valores[1] + "' AND cmontacco='" + _Str_Valores[0] + "'";
                        _Ds_DataSet = new DataSet();
                        _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

                        if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                        {
                            string[] _Str_Lineas = new string[_Ds_DataSet.Tables[0].Rows.Count];
                            int _Int_Cont = 0;
                            foreach (DataRow _Dtw_Row in _Ds_DataSet.Tables[0].Rows)
                            {
                                string _Str_Linea = _Mtd_Completar(_Dtw_Row["ccompany"].ToString(), 2, true, true, false);
                                _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cspi"].ToString().Trim(), 0, false, false, false);
                                _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cidvendedorsistnomina"].ToString(), 10, false, true, false);
                                _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cconceptospi"].ToString(), 4, true, true, false);
                                _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["ccantmov"].ToString(), 7, true, false, false);
                                _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cmontomov"].ToString(), 14, true, true, false);
                                _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cdiaesquema"].ToString(), 1, false, true, false);
                                _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["ccalcsueldoant"].ToString(), 1, true, true, false);
                                _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["ctiposueldant"].ToString(), 1, true, true, false);
                                _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cfecha"].ToString(), 8, false, true, false);
                                _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cfichavendsupl"].ToString(), 10, true, true, false);
                                _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["ctabuladorsup"].ToString(), 4, true, true, false);
                                _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cvalorsust"].ToString(), 13, true, true, false);
                                _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cfactorsust"].ToString(), 13, true, true, false);
                                _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cnosumarizar"].ToString(), 1, true, true, false);
                                _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["ccontamov"].ToString(), 1, true, true, false);
                                _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cdepartamentoalt"].ToString(), 10, true, true, false);
                                _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cnumcontable"].ToString(), 36, true, true, false);
                                _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cnumordentrab"].ToString(), 10, true, true, false);
                                _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["ccodopercont"].ToString(), 6, true, true, false);
                                _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cmovprocesado"].ToString(), 1, false, true, false);
                                _Str_Linea += "," + _Mtd_Completar(_Dtw_Row["cnumsecmov"].ToString(), 5, true, true, false);
                                _Str_Linea += "," + _Mtd_Completar("", 50, false, false, false);
                                _Str_Lineas[_Int_Cont] = _Str_Linea;
                                _Int_Cont++;
                            }
                            //this._Txt_Exportacion.Lines = _Str_Lineas;
                            if (_Str_Lineas.Length > 0)
                            {
                                string _Str_DestinoPath = "";
                                string _Str_File = "ExternoSPI.txt";
                                if (_Fol_Browser.ShowDialog() == DialogResult.OK)
                                {
                                    _Str_DestinoPath = _Fol_Browser.SelectedPath;
                                }
                                string _Str_FinalFile = System.IO.Path.Combine(_Str_DestinoPath, _Str_File);
                                System.IO.File.WriteAllLines(_Str_FinalFile, _Str_Lineas);
                                _Str_Cadena = "UPDATE TCALINCEXPORTSPI SET CEXPORTADO='1' WHERE CCOMPANY='" + _Str_CompanySPI + "' AND ctipogeneracion='" + Convert.ToString(_Cmb_Generacion.SelectedValue).Trim() + "' AND cyearacco='" + _Str_Valores[1] + "' AND cmontacco='" + _Str_Valores[0] + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                MessageBox.Show("El archivo fue exportado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _Chk_Exportado.Checked = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lo sentimos, no existen datos para exportar en este periodo para esta compañia.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch
                {
                }
            }
        }
        private void _Cmb_Generacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Generacion.SelectedIndex > 0)
            { _Btn_Exportar.Enabled = true; Cursor = Cursors.WaitCursor; _Mtd_IndicaExportado(); Cursor = Cursors.Default; }
            else
            { _Btn_Exportar.Enabled = false; _Chk_Exportado.Checked = false; }
        }

        private void _Btn_Consultar_Click(object sender, EventArgs e)
        {
            //_Er_Error.Dispose();
            //if (_Cmb_Mes.SelectedIndex > 0 & _Cmb_Generacion.SelectedIndex > 0)
            //{
            //    Cursor = Cursors.WaitCursor;
            //    _Mtd_Consultar();
            //    Cursor = Cursors.Default;
            //}
            //else
            //{
            //    if (_Cmb_Mes.SelectedIndex == 0) { _Er_Error.SetError(_Cmb_Mes, "Información requerida!!!"); }
            //    if (_Cmb_Generacion.SelectedIndex == 0) { _Er_Error.SetError(_Cmb_Generacion, "Información requerida!!!"); }
            //}
        }
        private bool _Mtd_Generar()
        {
            try
            {
                //Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("EXEC PA_T3_EXPORTAR_T3_SPI 
                string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.SelectedValue.ToString());
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = new SqlParameter("@CCOMPANY", SqlDbType.VarChar);
                paramsToStore[0].Value = Frm_Padre._Str_Comp;
                paramsToStore[1] = new SqlParameter("@CMES", SqlDbType.Int);
                paramsToStore[1].Value = _Str_Valores[0];
                paramsToStore[2] = new SqlParameter("@CANO", SqlDbType.Int);
                paramsToStore[2].Value = _Str_Valores[1];
                paramsToStore[3] = new SqlParameter("@CTIPOGENERACION", SqlDbType.TinyInt);
                paramsToStore[3].Value = Convert.ToString(_Cmb_Generacion.SelectedValue).Trim();
                CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("PA_T3_EXPORTAR_T3_SPI", paramsToStore);
                return true;
            }
            catch(Exception ou)
            {
                string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.SelectedValue.ToString());
                MessageBox.Show(ou.Message.TrimEnd(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Frm_ExportarIncSPIUser _Frm_User = new Frm_ExportarIncSPIUser(Frm_Padre._Str_Comp, _Str_Valores[0], _Str_Valores[1],Convert.ToString(_Cmb_Generacion.SelectedValue).Trim());
                _Frm_User.ShowDialog();
                return false;
            }
        }
        private bool _Mtd_ConsultarExport()
        {
            bool _Bol_Seguir = false;
            try
            {
                string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.SelectedValue.ToString());
                Frm_ExportarIncSelect _Frm_Exp = new Frm_ExportarIncSelect(Frm_Padre._Str_Comp, _Str_Valores[0], _Str_Valores[1], Convert.ToString(_Cmb_Generacion.SelectedValue).Trim());
                _Frm_Exp.ShowDialog();
                _Bol_Seguir = _Frm_Exp._Bol_Seleccionado;
            }
            catch (Exception ou)
            {

            }
            return _Bol_Seguir;
        }
        private void _Btn_Exportar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Cmb_Mes.SelectedIndex > 0 & _Cmb_Generacion.SelectedIndex > 0)
            {
                Cursor = Cursors.WaitCursor;
                if (_Mtd_ConsultarExport())
                {
                    _Mtd_Exportar();
                }
                Cursor = Cursors.Default;
            }
            else
            {
                if (_Cmb_Mes.SelectedIndex == 0) { _Er_Error.SetError(_Cmb_Mes, "Información requerida!!!"); }
                if (_Cmb_Generacion.SelectedIndex == 0) { _Er_Error.SetError(_Cmb_Generacion, "Información requerida!!!"); }
            }
        }

        private void Frm_ExportarIncSPI_Load(object sender, EventArgs e)
        {
            //this.Dock = DockStyle.Fill;
            CLASES._Cls_Empleados_SPI _Cls_Empleados_SPI = new CLASES._Cls_Empleados_SPI();
            _Cls_Empleados_SPI._Mtd_ActualizarTablaEmpleadosSPI(true, true, true);
        }
    }
}
