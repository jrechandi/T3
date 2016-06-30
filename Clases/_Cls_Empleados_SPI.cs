using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using System.Data.OracleClient;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Threading;
using Oracle.ManagedDataAccess.Client; // ODP.NET Oracle managed provider
using Oracle.ManagedDataAccess.Types; 

namespace T3.CLASES
{
    public class _Cls_Empleados_SPI
    {
        string _Str_Oracle_IP_Servidor = "172.16.1.31";
        string _Str_Oracle_Puerto_Servidor = "1521";
        string _Str_Oracle_Servicio = "SPI";
        string _Str_Oracle_Login = "infocent";
        string _Str_Oracle_Password = "infocent";

        private DataSet _Mtd_ConsultarOracle(string _Str_SQL)
        {
            DataSet _Ds_Dataset = new DataSet();

            string _Str_OracleConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + _Str_Oracle_IP_Servidor + ")(PORT=" + _Str_Oracle_Puerto_Servidor + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + _Str_Oracle_Servicio + ")));User Id=" + _Str_Oracle_Login + ";Password=" + _Str_Oracle_Password + ";";
            using (OracleConnection _OCN_OracleConnection = new OracleConnection(_Str_OracleConnectionString))
            {
                OracleCommand _OCM_OracleCommand = new OracleCommand(_Str_SQL);
                _OCM_OracleCommand.Connection = _OCN_OracleConnection;
                try
                {
                    _OCN_OracleConnection.Open();
                    OracleDataAdapter _ODA_OracleDataAdapter = new OracleDataAdapter(_OCM_OracleCommand);
                    _ODA_OracleDataAdapter.Fill(_Ds_Dataset);
                    _OCN_OracleConnection.Close();
                }
                catch (Exception ex)
                {
                    _Ds_Dataset = null;
                    MessageBox.Show(ex.Message);
                }
            }

            return _Ds_Dataset;
        }

        public bool _Mtd_ActualizarTablaEmpleadosSPI(bool _Bol_MostrarMensajeExito, bool _Bol_MostrarMensajesError, bool _Bol_UtilizarRetrasoEnConexionAServidorSPI)
        {
            // este procedimiento devuelve true si se ejecuta el proceso de actualizacion sin problemas, y falso si se detiene por algun error controlado
           
            bool _Bol_Retornar = true;
            
            // valida que esté instalado el cliente oracle
            if (_Mtd_ClienteOracleEstaInstalado())
            {
                bool _Bol_ConsultarServidorSPI;

                if (!_Mtd_SeEstaProcesandoActualmente())
                {
                    if (_Bol_UtilizarRetrasoEnConexionAServidorSPI)
                    {
                        if (_Mtd_ConexionAServidorSPIEstaPermitidaAEstaHora())
                        {
                            _Bol_ConsultarServidorSPI = true;
                        }
                        else
                        {
                            _Bol_ConsultarServidorSPI = false;
                        }
                    }
                    else
                    {

                        _Bol_ConsultarServidorSPI = true;
                    }
                }
                else
                {
                    _Bol_ConsultarServidorSPI = false;
                }

                if (CLASES._Cls_Conexion._Bol_UsuarioRemoto)
                {
                    if (_Bol_ConsultarServidorSPI)
                    {
                        DialogResult _DR_DialogResult = MessageBox.Show("Se procederá a realizar la actualizacion de los datos sobre empleados. Este proceso puede tardar varios minutos.\n\r¿Desea realizarlo en este momento?", "Actualización", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (_DR_DialogResult == DialogResult.Yes)
                        {
                            _Bol_ConsultarServidorSPI = true;
                        }
                        else
                        {
                            _Bol_ConsultarServidorSPI = false;
                        }
                    }
                }

                if (_Bol_ConsultarServidorSPI)
                {

                    Thread _Thr_Thread = new Thread(new ThreadStart(delegate { _Bol_Retornar = _Mtd_ActualizarTablaEmpleadosSPI_Waitform(_Bol_MostrarMensajeExito, _Bol_MostrarMensajesError); }));
                    _Thr_Thread.Start();
                    while (!_Thr_Thread.IsAlive) ;
                    Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread, "Actualizando datos de empleados, espere...");
                    //_Frm_Form.ShowDialog(this);
                    _Frm_Form.ShowDialog();
                    _Frm_Form.Dispose();
                }
                else
                {
                    //if (_Bol_MostrarMensajesError) MessageBox.Show("Lo sentimos, no es posible consultar el servidor SPI a esta hora por limitaciones de tráfico de red.\n\rPor favor contacte al desarrollador.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _Bol_Retornar = false;
                }
            }
            else
            {
                if (_Bol_MostrarMensajesError) MessageBox.Show("Lo sentimos, no se encuentra instalado un componente requerido para utilizar esta función.\n\rPor favor contacte al desarrollador.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _Bol_Retornar = false;
            }

            return _Bol_Retornar;
        }

        private string _Mtd_SQLWhereCompaniasParaSPI()
        {
            string _Str_Retornar = "";
                    
            _Str_Retornar += " WHERE ";
            string _Str_SQL = "SELECT ccompany from TCOMPANY";

            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            
            int _Int_CantidadDeRegistros = _Ds.Tables[0].Rows.Count;

            if (_Int_CantidadDeRegistros > 0)
            {
                string _Str_ccompany = "";
            

                for (int i = 0; i <= _Int_CantidadDeRegistros - 1; i++)
                {
                    _Str_ccompany = _Ds.Tables[0].Rows[i]["ccompany"].ToString().Trim();
                    _Str_Retornar += "(NMT001_EMPRE.CIACON = '" + _Str_ccompany + "') ";
                    if ((_Int_CantidadDeRegistros > 1) && (i < (_Int_CantidadDeRegistros - 1))) _Str_Retornar += " OR ";
                }
            }
            //borrar
            _Str_Retornar = " WHERE (NMT001_EMPRE.CIACON = 'S07') ";
            return _Str_Retornar;
        }

        private bool _Mtd_ActualizarTablaEmpleadosSPI_ActualizarCedulaUsuario(string _Str_ccompany, string _Str_cuser, string _Str_ccedula)
        {
            // Si el usuario ya existe, verifica la cédula. Si la cédula está diferente que en TEMPLEADOS_SPI, entonces la actualiza. Sino, ignora el registro.
            bool _Bol_Retornar = false;

            string _Str_SQL = "select ccedula from TEMPLEADOS_SPI where ccompany = '" + _Str_ccompany + "' and cuser = '" + _Str_cuser + "'";

            if (_Str_ccedula == "") _Str_ccedula = "0";

            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count != 0)
            {
                string _Str_ccedula_guardada = "";
                for (int i = 0; i <= _Ds.Tables[0].Rows.Count - 1; i++)
                {
                    _Str_ccedula_guardada = _Ds.Tables[0].Rows[i]["ccedula"].ToString().Trim(); ;

                    if (_Str_ccedula != _Str_ccedula_guardada)
                    {
                        string _Str_SQL_ActualizarCedula = "UPDATE TEMPLEADOS_SPI SET ccedula = '" + _Str_ccedula + "' WHERE ccompany = '" + _Str_ccompany + "' and cuser = '" + _Str_cuser + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL_ActualizarCedula);
                        _Bol_Retornar = true;
                    }
                }
            }

            return _Bol_Retornar;
        }

        private bool _Mtd_ActualizarTablaEmpleadosSPI_InsertarUsuario_cuser(string _Str_ccompany, string _Str_cuser, string _Str_ccedula)
        {
            bool _Bol_Retornar = false;

            // Si el usuario no existe, entonces lo inserta. Versión con CUSER

            if (_Str_ccedula == "") _Str_ccedula = "0";
            string _Str_SQL = "select cuser from TEMPLEADOS_SPI where ccompany = '" + _Str_ccompany + "' and cuser = '" + _Str_cuser + "'";

            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                string _Str_SQL_Insertar = "INSERT INTO TEMPLEADOS_SPI (ccompany, cuser, ccedula) VALUES ('" + _Str_ccompany + "', '" + _Str_cuser + "','" + _Str_ccedula + "');";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL_Insertar);
                _Bol_Retornar = true;
            }

            return _Bol_Retornar;
        }

        private bool _Mtd_ActualizarTablaEmpleadosSPI_ActualizarIdSPIUsuario(string _Str_ccompany, string _Str_ccedula, string _Str_cid_spi)
        {
            // Usa la cédula para obtener el codigo spi, y lo actualiza
            bool _Bol_Retornar = false;

            string _Str_SQL = "select cid_spi from TEMPLEADOS_SPI where ccompany = '" + _Str_ccompany + "' and ccedula = '" + _Str_ccedula.Replace("V-","").Replace("E-","") + "'";

            if (_Str_cid_spi == "") _Str_cid_spi = "0";

            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count != 0)
            {
                string _Str_cid_spi_guardado = "";
                for (int i = 0; i <= _Ds.Tables[0].Rows.Count - 1; i++)
                {
                    _Str_cid_spi_guardado = _Ds.Tables[0].Rows[i]["cid_spi"].ToString().Trim(); ;

                    if (_Str_cid_spi != _Str_cid_spi_guardado)
                    {
                        string _Str_SQL_ActualizarIdSPI = "UPDATE TEMPLEADOS_SPI SET cid_spi = '" + _Str_cid_spi + "' WHERE ccompany = '" + _Str_ccompany + "' and ccedula = '" + _Str_ccedula.Replace("V-", "").Replace("E-", "") + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL_ActualizarIdSPI);
                        _Bol_Retornar = true;
                    }
                }
            }

            return _Bol_Retornar;
        }

        private bool _Mtd_ActualizarTablaEmpleadosSPI_InsertarUsuario_cid_spi(string _Str_ccompany, string _Str_ccedula, string _Str_cid_spi)
        {
            bool _Bol_Retornar = false;

            // Si el usuario no existe, entonces lo inserta. Versión con C_ID_SPI

            if (_Str_ccedula == "") _Str_ccedula = "0";
            string _Str_SQL = "select cid_spi from TEMPLEADOS_SPI where ccompany = '" + _Str_ccompany + "' and ccedula = '" + _Str_ccedula.Replace("V-", "").Replace("E-", "") + "'";

            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                string _Str_SQL_Insertar = "INSERT INTO TEMPLEADOS_SPI (ccompany, cid_spi, ccedula) VALUES ('" + _Str_ccompany + "', '" + _Str_cid_spi + "','" + _Str_ccedula.Replace("V-", "").Replace("E-", "") + "');";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL_Insertar);
                _Bol_Retornar = true;
            }

            return _Bol_Retornar;
        }

        private bool _Mtd_ActualizarTablaEmpleadosSPI_ActualizarFechasUsuario(string _Str_ccompany, string _Str_cid_spi, string _Str_cfecha_ingreso, string _Str_cfecha_egreso)
        {
            bool _Bol_Retornar = false;
            string _Str_SQL = "";
            DataSet _Ds;

            // ===========================================================================================================================================================
            // Si la fecha de ingreso está vacia, entonces la actualiza. Sino, la ignora.
            string _Str_cfecha_ingreso_guardada = "";

            _Str_SQL = "select ISNULL(CONVERT(VARCHAR,cfecha_ingreso,103),'') as cfecha_ingreso from TEMPLEADOS_SPI where ccompany = '" + _Str_ccompany + "' and cid_spi = '" + _Str_cid_spi + "'";

            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i <= _Ds.Tables[0].Rows.Count - 1; i++)
                {
                    _Str_cfecha_ingreso_guardada = _Ds.Tables[0].Rows[i]["cfecha_ingreso"].ToString().Trim(); ;
                }
            }
            
            // si la fecha de ingreso cambió, entonces, la actualiza...
            if (_Str_cfecha_ingreso_guardada != _Str_cfecha_ingreso)
            {
                string _Str_SQL_Actualizar = "";

                if (_Str_cfecha_ingreso == "") // para el caso retorcido en el que la fecha venga vacia, es decir, que la hayan borrado en el SPI
                {
                    _Str_SQL_Actualizar = "UPDATE TEMPLEADOS_SPI SET cfecha_ingreso = null WHERE ccompany = '" + _Str_ccompany + "' and cid_spi = '" + _Str_cid_spi + "'";
                }
                else
                {
                    _Str_SQL_Actualizar = "UPDATE TEMPLEADOS_SPI SET cfecha_ingreso = '" + _Str_cfecha_ingreso + "' WHERE ccompany = '" + _Str_ccompany + "' and cid_spi = '" + _Str_cid_spi + "'";
                }
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL_Actualizar);
                _Bol_Retornar = true;
            }
            // ===========================================================================================================================================================


            // ===========================================================================================================================================================
            // Si la fecha de egreso está vacia, entonces la actualiza. Sino, la ignora.
            string _Str_cfecha_egreso_guardada = "";

            _Str_SQL = "select ISNULL(CONVERT(VARCHAR,cfecha_egreso,103),'') as cfecha_egreso from TEMPLEADOS_SPI where ccompany = '" + _Str_ccompany + "' and cid_spi = '" + _Str_cid_spi + "'";

            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i <= _Ds.Tables[0].Rows.Count - 1; i++)
                {
                    _Str_cfecha_egreso_guardada = _Ds.Tables[0].Rows[i]["cfecha_egreso"].ToString().Trim(); ;
                }
            }

            // si la fecha de ingreso cambió, entonces, la actualiza...
            if (_Str_cfecha_egreso_guardada != _Str_cfecha_egreso)
            {
                string _Str_SQL_Actualizar = "";

                if (_Str_cfecha_egreso == "") // para el caso retorcido en el que la fecha venga vacia, es decir, que la hayan borrado en el SPI
                {
                    _Str_SQL_Actualizar = "UPDATE TEMPLEADOS_SPI SET cfecha_egreso = null WHERE ccompany = '" + _Str_ccompany + "' and cid_spi = '" + _Str_cid_spi + "'";
                }
                else
                {
                    _Str_SQL_Actualizar = "UPDATE TEMPLEADOS_SPI SET cfecha_egreso = '" + _Str_cfecha_egreso + "' WHERE ccompany = '" + _Str_ccompany + "' and cid_spi = '" + _Str_cid_spi + "'";
                }
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL_Actualizar);
                _Bol_Retornar = true;
            }
            // ===========================================================================================================================================================

            return _Bol_Retornar;
        }

        private bool _Mtd_ActualizarTablaEmpleadosSPI_CedulaExisteParaAlgunUsuario(string _Str_ccompany, string _Str_ccedula)
        {
            bool _Bol_Retornar = false;

            // si la cedula existe, y cuser no está en blanco, significa que ya fue asignada a algun usuario
            string _Str_SQL = "select cid_spi from TEMPLEADOS_SPI where ccompany = '" + _Str_ccompany + "' and ccedula = '" + _Str_ccedula.Replace("V-", "").Replace("E-", "") + "' AND cuser != ''";

            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count != 0)
            {
                _Bol_Retornar = true;
            }

            return _Bol_Retornar;
        }

        private bool _Mtd_ClienteOracleEstaInstalado()
        {
            bool _Bol_Retornar = true;

            //if (!File.Exists("C://CONSSA//T3//Debug//oci.dll")) _Bol_Retornar = false;
            //if (!File.Exists("C://CONSSA//T3//Debug//oraociicus11.dll")) _Bol_Retornar = false;
            //if (!File.Exists("C://CONSSA//T3//Debug//orannzsbb11.dll")) _Bol_Retornar = false;

            return _Bol_Retornar;
        }

        private bool _Mtd_Ping(string _P_Str_Ip)
        {
            try
            {
                Ping _Ping = new Ping();
                PingReply _Reply = _Ping.Send(_P_Str_Ip, 1500);
                return _Reply.Status == IPStatus.Success;
            }
            catch { }
            return false;
        }


        private bool _Mtd_ConexionAServidorSPIEstaPermitidaAEstaHora()
        {

            // retraso en minutos... puesto a 14 horas en la primera versión
            int _Int_RetrasoEnMinutos = 60 * 0;

            string _Str_cfec_ult_act_spi = "";
            string _Str_Ahora = "";

            DateTime _DT_cfec_ult_act_spi;
            DateTime _DT_Ahora;

            string _Str_SQL = "SELECT cfec_ult_act_spi FROM tconfigconssa";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i <= _Ds.Tables[0].Rows.Count - 1; i++)
                {
                    _Str_cfec_ult_act_spi = _Ds.Tables[0].Rows[i]["cfec_ult_act_spi"].ToString().Trim();
                }

                _DT_cfec_ult_act_spi = Convert.ToDateTime(_Str_cfec_ult_act_spi);
            }
            else
            {
                _DT_cfec_ult_act_spi = DateTime.Now;
            
            }


            _Str_SQL = "SELECT GETDATE() as cahora";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i <= _Ds.Tables[0].Rows.Count - 1; i++)
                {
                    _Str_Ahora = _Ds.Tables[0].Rows[i]["cahora"].ToString().Trim();
                }

                _DT_Ahora = Convert.ToDateTime(_Str_Ahora);
            }
            else
            {
                _DT_Ahora = DateTime.Now;
            }

            TimeSpan span = _DT_Ahora.Subtract(_DT_cfec_ult_act_spi);

            // convierte la diferencia a minutos

            int _Int_DiferenciaEnMinutos = span.Minutes + (span.Hours * 60) + (span.Days * 60 * 24);

            if (_Int_DiferenciaEnMinutos > _Int_RetrasoEnMinutos)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool _Mtd_SeEstaProcesandoActualmente()
        {

            bool _Bol_Retornar;

            string _Str_SQL = "SELECT cprocesando_spi FROM tconfigconssa";
            string _Str_Procesando = "";

            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i <= _Ds.Tables[0].Rows.Count - 1; i++)
                {
                    _Str_Procesando = _Ds.Tables[0].Rows[i]["cprocesando_spi"].ToString().Trim();
                }
            }

            if (_Str_Procesando == "0") _Bol_Retornar = false; else _Bol_Retornar = true;

            // -----------------

            if (_Bol_Retornar) // en caso de que esté marcado como 'procesando', se hace un chequeo para veririfcar que no fue una salida abrupta del sistema
            {
                // verifica si hay *OTROS* usuarios conectados que tengan el notificador de reporte uniticket

                _Str_SQL = "SELECT TUSERONLINE.cuser FROM TTABS INNER JOIN TUSER ON dbo.TTABS.cgroup = dbo.TUSER.cgroup INNER JOIN TUSERONLINE ON dbo.TUSER.cuser = dbo.TUSERONLINE.cuser WHERE (TTABS.ctabs = 108) AND (RTRIM(UPPER(TUSERONLINE.cuser)) <> '" + Frm_Padre._Str_Use.ToUpper().Trim() + "')";

                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (_Ds.Tables[0].Rows.Count == 0)
                {
                    
                    // 7 marca como que se terminó de procesar
                    _Str_SQL = "UPDATE TCONFIGCONSSA SET cprocesando_spi = 0";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                    _Bol_Retornar = false;
                }
            }
            
            return _Bol_Retornar;
        }

        private bool _Mtd_ActualizarTablaEmpleadosSPI_Waitform(bool _Bol_MostrarMensajeExito, bool _Bol_MostrarMensajesError)
        {
            bool _Bol_Retornar = true;

            // valida que exista conexion con el servidor de SPI
            if (_Mtd_Ping(_Str_Oracle_IP_Servidor))
            {
                string _Str_SQL = "";

                // 0 marca como que se está procesando, para evitar problemas con el notificador que se actualiza muy rápido
                _Str_SQL = "UPDATE TCONFIGCONSSA SET cprocesando_spi = 1";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                // este método llena y actualiza la Tabla 

                int _Int_ContadorActualizaciones = 0;
                int _Int_ContadorInserciones = 0;



                // 1 recorre TUSER (agrega todos los usuarios de T3, y verifica que sus cedulas no hayan cambiado)
                _Str_SQL = "SELECT TUSERCOMP.ccompany as ccompany, TUSER.cuser as cuser, TUSER.ccedula as ccedula FROM TUSER INNER JOIN TUSERCOMP ON TUSER.cuser = TUSERCOMP.cuser WHERE tuser.cdelete <> 1 AND tusercomp.cdelete <> 1";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (_Ds.Tables[0].Rows.Count != 0)
                {
                    string _Str_ccompany = "";
                    string _Str_cuser = "";
                    string _Str_ccedula = "";

                    for (int i = 0; i <= _Ds.Tables[0].Rows.Count - 1; i++)
                    {
                        _Str_ccompany = _Ds.Tables[0].Rows[i]["ccompany"].ToString().Trim();
                        _Str_cuser = _Ds.Tables[0].Rows[i]["cuser"].ToString().Trim();
                        _Str_ccedula = _Ds.Tables[0].Rows[i]["ccedula"].ToString().Trim();

                        // 1.1 Si el usuario ya existe, verifica la cédula. Si la cédula está diferente que en TEMPLEADOS_SPI, entonces la actualiza. Sino, ignora el registro.
                        if (_Mtd_ActualizarTablaEmpleadosSPI_ActualizarCedulaUsuario(_Str_ccompany, _Str_cuser, _Str_ccedula)) _Int_ContadorActualizaciones++;

                        // 1.2 Si el usuario no existe, entonces lo inserta.
                        if (_Mtd_ActualizarTablaEmpleadosSPI_InsertarUsuario_cuser(_Str_ccompany, _Str_cuser, _Str_ccedula)) _Int_ContadorInserciones++; ;

                    }
                }

                // 2 recorre tablas en SPI (agrega los demás empleados que no son usuarios de t3) 
                DataSet _Ds_Oracle = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                _Str_SQL = "";

                // Consulta original: se comentó porque empezó a dar un error con la descripcion del cargo, asi que se eliminó eso de la consulta, y ahora siempre viene vacio
                //_Str_SQL += "SELECT ";
                //_Str_SQL += "EO_PERSONA.ID as cid_spi,  ";
                //_Str_SQL += "EO_PERSONA.NUM_IDEN as ccedula,  ";
                //_Str_SQL += "NMT001_EMPRE.CIACON as ccompany, ";
                //_Str_SQL += "NMM001_LABORAL.FECING as cfecha_ingreso,  ";
                //_Str_SQL += "NMM001_LABORAL.FECRET as cfecha_egreso, ";
                //_Str_SQL += "EO_PERSONA.NOMBRE1 as cnombre1,  ";
                //_Str_SQL += "EO_PERSONA.NOMBRE2 as cnombre2,  ";
                //_Str_SQL += "EO_PERSONA.APELLIDO1 as capellido1 ,  ";
                //_Str_SQL += "EO_PERSONA.APELLIDO2 as capellido2 ,  ";
                //_Str_SQL += "EO_PERSONA.EDO_CIVIL as cestado_civil,  ";
                //_Str_SQL += "EO_PERSONA.CIUDAD_NA as cciudad_na,  ";
                //_Str_SQL += "EO_PERSONA.FECHA_NA as cfecha_na,  ";
                //_Str_SQL += "EO_PERSONA.DIRECCION as cdireccion_empleado,  ";
                //_Str_SQL += "EO_PERSONA.CIUDAD as cciudad_empleado,  ";
                //_Str_SQL += "ESTADO1.NOMBRE as cestado_empleado,  ";
                //_Str_SQL += "EO_PERSONA.CELULAR as ctlf_celular,  ";
                //_Str_SQL += "EO_PERSONA.TELEFONO1 as ctlf_habitacion,  ";
                //_Str_SQL += "EO_PERSONA.E_MAIL1 as cemail,  ";
                //_Str_SQL += "EO_EMPRESA.NOMBRE as cnombre_empresa,  ";
                //_Str_SQL += "EO_EMPRESA.DIRECCION as cdireccion_empresa,  ";
                //_Str_SQL += "EO_EMPRESA.CIUDAD as cciudad_empresa,  ";
                //_Str_SQL += "EO_EMPRESA.TELEFONO1 as ctlf_empresa,  ";
                //_Str_SQL += "ESTADO2.NOMBRE as cestado_empresa,  ";
                //_Str_SQL += "NMM001_EMPLEADO.FICHA as cficha,  ";
                //_Str_SQL += "EO_CARGO.NOMBRE as ccargo ";
                //_Str_SQL += "FROM EO_PERSONA  ";
                //_Str_SQL += "INNER JOIN NMM001_LABORAL ON EO_PERSONA.ID = NMM001_LABORAL.ID_PERSONA  ";
                //_Str_SQL += "INNER JOIN NMT001_EMPRE ON NMM001_LABORAL.CIA_CODCIA = NMT001_EMPRE.CODCIA ";
                //_Str_SQL += "LEFT JOIN SPI_ENTIDAD_FEDERAL ESTADO1 ON (EO_PERSONA.ID_PAIS = ESTADO1.CODIGO_PAIS) AND (EO_PERSONA.ID_ENTFE = ESTADO1.CODIGO) ";
                //_Str_SQL += "LEFT JOIN EO_EMPRESA ON NMT001_EMPRE.CODCIA = EO_EMPRESA.ID ";
                //_Str_SQL += "LEFT JOIN SPI_ENTIDAD_FEDERAL ESTADO2 ON (EO_EMPRESA.ID_PAIS = ESTADO2.CODIGO_PAIS) AND (EO_EMPRESA.ID_ENTFE = ESTADO2.CODIGO) ";
                //_Str_SQL += "LEFT JOIN (SELECT * FROM NMM001_EMPLEADO WHERE NMM001_EMPLEADO.FECHA_FIN IS NULL) NMM001_EMPLEADO ON (NMM001_LABORAL.CIA_CODCIA = NMM001_EMPLEADO.CIA_CODCIA) AND (NMM001_LABORAL.FICHA = NMM001_EMPLEADO.FICHA) ";
                //_Str_SQL += "LEFT JOIN EO_CARGO ON (NMM001_EMPLEADO.CIA_CODCIA = EO_CARGO.ID_EMPRESA) AND (NMM001_EMPLEADO.ID_PUESTO = EO_CARGO.ID) ";
                //_Str_SQL += _Mtd_SQLWhereCompaniasParaSPI();
                //_Str_SQL += "ORDER BY NMT001_EMPRE.CIACON, EO_PERSONA.ID ";

                _Str_SQL += "SELECT ";
                _Str_SQL += "EO_PERSONA.ID as cid_spi,  ";
                _Str_SQL += "EO_PERSONA.NUM_IDEN as ccedula,  ";
                _Str_SQL += "NMT001_EMPRE.CIACON as ccompany, ";
                _Str_SQL += "NMM001_LABORAL.FECING as cfecha_ingreso,  ";
                _Str_SQL += "NMM001_LABORAL.FECRET as cfecha_egreso, ";
                _Str_SQL += "EO_PERSONA.NOMBRE1 as cnombre1,  ";
                _Str_SQL += "EO_PERSONA.NOMBRE2 as cnombre2,  ";
                _Str_SQL += "EO_PERSONA.APELLIDO1 as capellido1 ,  ";
                _Str_SQL += "EO_PERSONA.APELLIDO2 as capellido2 ,  ";
                _Str_SQL += "EO_PERSONA.EDO_CIVIL as cestado_civil,  ";
                _Str_SQL += "EO_PERSONA.CIUDAD_NA as cciudad_na,  ";
                _Str_SQL += "EO_PERSONA.FECHA_NA as cfecha_na,  ";
                _Str_SQL += "EO_PERSONA.DIRECCION as cdireccion_empleado,  ";
                _Str_SQL += "EO_PERSONA.CIUDAD as cciudad_empleado,  ";
                _Str_SQL += "ESTADO1.NOMBRE as cestado_empleado,  ";
                _Str_SQL += "EO_PERSONA.CELULAR as ctlf_celular,  ";
                _Str_SQL += "EO_PERSONA.TELEFONO1 as ctlf_habitacion,  ";
                _Str_SQL += "EO_PERSONA.E_MAIL1 as cemail,  ";
                _Str_SQL += "EO_EMPRESA.NOMBRE as cnombre_empresa,  ";
                _Str_SQL += "EO_EMPRESA.DIRECCION as cdireccion_empresa,  ";
                _Str_SQL += "EO_EMPRESA.CIUDAD as cciudad_empresa,  ";
                _Str_SQL += "EO_EMPRESA.TELEFONO1 as ctlf_empresa,  ";
                _Str_SQL += "ESTADO2.NOMBRE as cestado_empresa,  ";
                _Str_SQL += "TA_RELACION_LABORAL.FICHA as cficha,  ";
                _Str_SQL += "'' as ccargo ";
                _Str_SQL += "FROM EO_PERSONA  ";
                _Str_SQL += "INNER JOIN NMM001_LABORAL ON EO_PERSONA.ID = NMM001_LABORAL.ID_PERSONA  ";
                _Str_SQL += "INNER JOIN NMT001_EMPRE ON NMM001_LABORAL.CIA_CODCIA = NMT001_EMPRE.CODCIA ";
                _Str_SQL += "LEFT JOIN SPI_ENTIDAD_FEDERAL ESTADO1 ON (EO_PERSONA.ID_PAIS = ESTADO1.CODIGO_PAIS) AND (EO_PERSONA.ID_ENTFE = ESTADO1.CODIGO) ";
                _Str_SQL += "LEFT JOIN EO_EMPRESA ON NMT001_EMPRE.CODCIA = EO_EMPRESA.ID ";
                _Str_SQL += "LEFT JOIN SPI_ENTIDAD_FEDERAL ESTADO2 ON (EO_EMPRESA.ID_PAIS = ESTADO2.CODIGO_PAIS) AND (EO_EMPRESA.ID_ENTFE = ESTADO2.CODIGO) ";
                _Str_SQL += "LEFT JOIN (SELECT * FROM NMM001_EMPLEADO WHERE NMM001_EMPLEADO.FECHA_FIN IS NULL) NMM001_EMPLEADO ON (NMM001_LABORAL.CIA_CODCIA = NMM001_EMPLEADO.CIA_CODCIA) AND (NMM001_LABORAL.FICHA = NMM001_EMPLEADO.FICHA) ";
                _Str_SQL += "INNER JOIN TA_RELACION_LABORAL on (EO_PERSONA.ID=TA_RELACION_LABORAL.ID_PERSONA AND TA_RELACION_LABORAL.FICHA = NMM001_LABORAL.FICHA)";
                _Str_SQL += _Mtd_SQLWhereCompaniasParaSPI();
                _Str_SQL += "ORDER BY NMT001_EMPRE.CIACON, EO_PERSONA.ID ";
                _Ds_Oracle = _Mtd_ConsultarOracle(_Str_SQL);
          
                if (_Ds_Oracle != null)
                {
                    if (_Ds_Oracle.Tables[0].Rows.Count != 0)
                    {
                        string _Str_ccompany = "";
                        string _Str_ccedula = "";
                        string _Str_cid_spi = "";

                        for (int i = 0; i <= _Ds_Oracle.Tables[0].Rows.Count - 1; i++)
                        {
                            _Str_ccompany = _Ds_Oracle.Tables[0].Rows[i]["ccompany"].ToString().Trim();
                            _Str_ccedula = _Ds_Oracle.Tables[0].Rows[i]["ccedula"].ToString().Trim();
                            _Str_cid_spi = _Ds_Oracle.Tables[0].Rows[i]["cid_spi"].ToString().Trim();

                            // 2.1 Usa la cédula para obtener el codigo spi, y lo actualiza
                            if (_Mtd_ActualizarTablaEmpleadosSPI_ActualizarIdSPIUsuario(_Str_ccompany, _Str_ccedula, _Str_cid_spi)) _Int_ContadorActualizaciones++;

                            // 2.2 Inserta todos los empleados que no son usuarios de T3
                            if (_Mtd_ActualizarTablaEmpleadosSPI_InsertarUsuario_cid_spi(_Str_ccompany, _Str_ccedula, _Str_cid_spi)) _Int_ContadorInserciones++; ;

                        }
                    }
                }

                // 3 recorre TEMPLEADOS_SPI (verifica los 'duplicados actualizados', registros que antes eran 'cedulas desconocidas', pero que ahora no (debido a una actualizacion de una cedula))
                // 3.1 recorre TEMPLEADOS_SPI where cuser = '' (en blanco!)
                _Str_SQL = "select ccompany, ccedula, cingreso_reportado, cegreso_reportado from TEMPLEADOS_SPI where cuser = ''";

                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (_Ds.Tables[0].Rows.Count != 0)
                {
                    string _Str_ccompany = "";
                    string _Str_ccedula = "";
                    string _Str_cingreso_reportado = "";
                    string _Str_cegreso_reportado = "";

                    for (int i = 0; i <= _Ds.Tables[0].Rows.Count - 1; i++)
                    {
                        _Str_ccompany = _Ds.Tables[0].Rows[i]["ccompany"].ToString().Trim();
                        _Str_ccedula = _Ds.Tables[0].Rows[i]["ccedula"].ToString().Trim();
                        _Str_cingreso_reportado = _Ds.Tables[0].Rows[i]["cingreso_reportado"].ToString().Trim();
                        _Str_cegreso_reportado = _Ds.Tables[0].Rows[i]["cegreso_reportado"].ToString().Trim();


                        // 3.2 si la cédula se repite, entonces es un registro duplicado de una cédula actualizada, y se elimina 
                        if (_Mtd_ActualizarTablaEmpleadosSPI_CedulaExisteParaAlgunUsuario(_Str_ccompany, _Str_ccedula))
                        {
                            // ojo, este caso no ha ocurrido: se pretende habilitar las sgtes lineas de codigo si llega a ocurrir
                            // antes de eliminar, copia los datos sobre 'ingreso' y 'egreso' reportado, para efectos de funcionamiento correcto de reporte uniticket
                            //string _Str_SQL_ActualizarIngresoEgreso = "UPDATE TEMPLEADOS_SPI SET cingreso_reportado = '" + _Str_cingreso_reportado + "', cegreso_reportado = '" + _Str_cegreso_reportado + "' WHERE ccompany = '" + _Str_ccompany + "' AND ccedula = '" + _Str_ccedula + "' and cuser = ''";
                            //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL_ActualizarIngresoEgreso);

                            // estoy medio dormido al momento de nombrar la siguiente variable
                            string _Str_SQL_EliminarUsuarioDuplicadoPorActualizacionDeCedula = "DELETE FROM TEMPLEADOS_SPI WHERE ccompany = '" + _Str_ccompany + "' AND ccedula = '" + _Str_ccedula + "' and cuser = ''";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL_EliminarUsuarioDuplicadoPorActualizacionDeCedula);
                        }
                    }
                }

                // 4 recorre una vez mas la tabla SPI, actualizando fechas de ingreso y egreso del personal

                // ojo, utiliza el mismo dataset ya consultado, no se vuelve a conectar

                if (_Ds_Oracle != null)
                {
                    if (_Ds_Oracle.Tables[0].Rows.Count != 0)
                    {
                        string _Str_ccompany = "";
                        string _Str_cid_spi = "";
                        string _Str_cfecha_ingreso = "";
                        string _Str_cfecha_egreso = "";

                        for (int i = 0; i <= _Ds_Oracle.Tables[0].Rows.Count - 1; i++)
                        {
                            _Str_ccompany = _Ds_Oracle.Tables[0].Rows[i]["ccompany"].ToString().Trim();
                            _Str_cid_spi = _Ds_Oracle.Tables[0].Rows[i]["cid_spi"].ToString().Trim();
                            _Str_cfecha_ingreso = _Ds_Oracle.Tables[0].Rows[i]["cfecha_ingreso"].ToString().Trim();
                            _Str_cfecha_egreso = _Ds_Oracle.Tables[0].Rows[i]["cfecha_egreso"].ToString().Trim();

                            if (_Str_cfecha_ingreso != "") _Str_cfecha_ingreso = (Convert.ToDateTime(_Str_cfecha_ingreso)).ToShortDateString();
                            if (_Str_cfecha_egreso != "") _Str_cfecha_egreso = (Convert.ToDateTime(_Str_cfecha_egreso)).ToShortDateString();

                            if (_Mtd_ActualizarTablaEmpleadosSPI_ActualizarFechasUsuario(_Str_ccompany, _Str_cid_spi, _Str_cfecha_ingreso, _Str_cfecha_egreso)) _Int_ContadorActualizaciones++;
                        }
                    }
                }

                // 5 recorre una vez mas la tabla SPI, actualizando demás datos para el reporte de uniticket

                // ojo, utiliza el mismo dataset ya consultado, no se vuelve a conectar
                if (_Ds_Oracle != null)
                {
                    if (_Ds_Oracle.Tables[0].Rows.Count != 0)
                    {
                        string _Str_ccompany = "";
                        string _Str_cid_spi = "";

                        string _Str_cnombre1 = "";
                        string _Str_cnombre2 = "";
                        string _Str_capellido1 = "";
                        string _Str_capellido2 = "";
                        string _Str_cestado_civil = "";
                        string _Str_cciudad_na = "";
                        string _Str_cfecha_na = "";
                        string _Str_cdireccion_empleado = "";
                        string _Str_cciudad_empleado = "";
                        string _Str_cestado_empleado = "";
                        string _Str_ctlf_celular = "";
                        string _Str_ctlf_habitacion = "";
                        string _Str_cemail = "";
                        string _Str_cnombre_empresa = "";
                        string _Str_cdireccion_empresa = "";
                        string _Str_cciudad_empresa = "";
                        string _Str_ctlf_empresa = "";
                        string _Str_cestado_empresa = "";
                        string _Str_cficha = "";
                        string _Str_ccargo = "";

                        for (int i = 0; i <= _Ds_Oracle.Tables[0].Rows.Count - 1; i++)
                        {
                            _Str_ccompany = _Ds_Oracle.Tables[0].Rows[i]["ccompany"].ToString().Trim();
                            _Str_cid_spi = _Ds_Oracle.Tables[0].Rows[i]["cid_spi"].ToString().Trim();
                            _Str_cnombre1 = _Ds_Oracle.Tables[0].Rows[i]["cnombre1"].ToString().Trim();
                            _Str_cnombre2 = _Ds_Oracle.Tables[0].Rows[i]["cnombre2"].ToString().Trim();
                            _Str_capellido1 = _Ds_Oracle.Tables[0].Rows[i]["capellido1"].ToString().Trim();
                            _Str_capellido2 = _Ds_Oracle.Tables[0].Rows[i]["capellido2"].ToString().Trim();
                            _Str_cestado_civil = _Ds_Oracle.Tables[0].Rows[i]["cestado_civil"].ToString().Trim();
                            _Str_cciudad_na = _Ds_Oracle.Tables[0].Rows[i]["cciudad_na"].ToString().Trim();

                            _Str_cfecha_na = _Ds_Oracle.Tables[0].Rows[i]["cfecha_na"].ToString().Trim();
                            if (_Str_cfecha_na != "") _Str_cfecha_na = (Convert.ToDateTime(_Str_cfecha_na)).ToShortDateString();

                            _Str_cdireccion_empleado = _Ds_Oracle.Tables[0].Rows[i]["cdireccion_empleado"].ToString().Trim();
                            _Str_cciudad_empleado = _Ds_Oracle.Tables[0].Rows[i]["cciudad_empleado"].ToString().Trim();
                            _Str_cestado_empleado = _Ds_Oracle.Tables[0].Rows[i]["cestado_empleado"].ToString().Trim();
                            _Str_ctlf_celular = _Ds_Oracle.Tables[0].Rows[i]["ctlf_celular"].ToString().Trim();
                            _Str_ctlf_habitacion = _Ds_Oracle.Tables[0].Rows[i]["ctlf_habitacion"].ToString().Trim();
                            _Str_cemail = _Ds_Oracle.Tables[0].Rows[i]["cemail"].ToString().Trim();
                            _Str_cnombre_empresa = _Ds_Oracle.Tables[0].Rows[i]["cnombre_empresa"].ToString().Trim();
                            _Str_cdireccion_empresa = _Ds_Oracle.Tables[0].Rows[i]["cdireccion_empresa"].ToString().Trim();
                            _Str_cciudad_empresa = _Ds_Oracle.Tables[0].Rows[i]["cciudad_empresa"].ToString().Trim();
                            _Str_ctlf_empresa = _Ds_Oracle.Tables[0].Rows[i]["ctlf_empresa"].ToString().Trim();
                            _Str_cestado_empresa = _Ds_Oracle.Tables[0].Rows[i]["cestado_empresa"].ToString().Trim();
                            _Str_cficha = _Ds_Oracle.Tables[0].Rows[i]["cficha"].ToString().Trim();
                            _Str_ccargo = _Ds_Oracle.Tables[0].Rows[i]["ccargo"].ToString().Trim();

                            _Str_SQL = "";
                            _Str_SQL += "UPDATE TEMPLEADOS_SPI ";
                            _Str_SQL += "SET ";
                            _Str_SQL += "cnombre1 = '" + _Str_cnombre1 + "',";
                            _Str_SQL += "cnombre2 = '" + _Str_cnombre2 + "',";
                            _Str_SQL += "capellido1 = '" + _Str_capellido1 + "',";
                            _Str_SQL += "capellido2 = '" + _Str_capellido2 + "',";
                            _Str_SQL += "cestado_civil = '" + _Str_cestado_civil + "',";
                            _Str_SQL += "cciudad_na = '" + _Str_cciudad_na + "',";
                            _Str_SQL += "cfecha_na = CONVERT(DATETIME,'" + _Str_cfecha_na + "',103),";
                            _Str_SQL += "cdireccion_empleado = '" + _Str_cdireccion_empleado + "',";
                            _Str_SQL += "cciudad_empleado = '" + _Str_cciudad_empleado + "',";
                            _Str_SQL += "cestado_empleado = '" + _Str_cestado_empleado + "',";
                            _Str_SQL += "ctlf_celular = '" + _Str_ctlf_celular + "',";
                            _Str_SQL += "ctlf_habitacion = '" + _Str_ctlf_habitacion + "',";
                            _Str_SQL += "cemail = '" + _Str_cemail + "',";
                            _Str_SQL += "cnombre_empresa = '" + _Str_cnombre_empresa + "',";
                            _Str_SQL += "cdireccion_empresa = '" + _Str_cdireccion_empresa + "',";
                            _Str_SQL += "cciudad_empresa = '" + _Str_cciudad_empresa + "',";
                            _Str_SQL += "ctlf_empresa = '" + _Str_ctlf_empresa + "',";
                            _Str_SQL += "cestado_empresa = '" + _Str_cestado_empresa + "',";
                            _Str_SQL += "cficha = '" + _Str_cficha + "',";
                            _Str_SQL += "ccargo = '" + _Str_ccargo + "' ";
                            _Str_SQL += "WHERE ccompany = '" + _Str_ccompany + "' AND cid_spi = '" + _Str_cid_spi + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                        }
                    }
                }

                // 6 guarda la fecha y hora en que se hizo la actualizacion
                _Str_SQL = "UPDATE TCONFIGCONSSA SET cfec_ult_act_spi = GETDATE()";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                // 7 marca como que se terminó de procesar
                _Str_SQL = "UPDATE TCONFIGCONSSA SET cprocesando_spi = 0";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                if (_Bol_MostrarMensajeExito) MessageBox.Show("Los datos sobre empleados SPI han sido actualizados satisfactoriamente.\n\rSe modificaron " + _Int_ContadorActualizaciones.ToString() + " registros ya existentes, y se agregaron " + _Int_ContadorInserciones.ToString() + " nuevos registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (_Bol_MostrarMensajesError) MessageBox.Show("Lo sentimos, no hay conexión con el servidor SPI (IP " + _Str_Oracle_IP_Servidor + ").\n\rPor favor contacte al desarrollador.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _Bol_Retornar = false;
            }

            return _Bol_Retornar;
        }


    } // clase
} // formulario
