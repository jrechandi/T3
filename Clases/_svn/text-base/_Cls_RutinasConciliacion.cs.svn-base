using System;
using System.Data;
using System.Windows.Forms;

namespace T3.Clases
{
    public class _Cls_RutinasConciliacion
    {
        public  enum _TipoRegistro
        {
            NoAplica = 0,
            Nuevo = 1,
            Original = 2,
            Reverso = 3,
            Diferencia = 4,
        }
        public enum _TipoDetalle
        {
            Banco = 0,
            Libro = 1,
            MayorAnalitico = 2
        }
        public enum _TipoDetalleConsulta
        {
            Conciliados = 0,
            NoConciliados = 1,
            AjustesConComprobante = 2,
            AjustesSinComprobante = 3,
        }
        public  enum _TipoEstadoDeCuenta
        {
            Conciliacion = 0,
            Disponibilidad
        }

        public static string _Str_Coletilla_Reverso = "_REV";

        /// <summary>
        /// Indica si es posible obtener un saldo inicial para el banco en la concilicación y la captura, toma en cuenta si existe un saldo inicia o una conciliacion ya realizada
        /// </summary>
        /// <param name="pcnumcuenta"></param>
        /// <returns></returns>
        public static bool _Mtd_EsValidoSaldoInicialBanco(string pcbanco, string pcnumcuenta)
        {
            //Consulto las conciliaciones activas para la cuenta seleccionada
            string _Str_IdConciliacion = "";
            string _G_Str_SentenciaSQL = "SELECT MAX(cidconciliacion) as cidconciliacion FROM TCONCILIACION WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CBANCO='" + pcbanco + "' AND CNUMCUENTA='" + pcnumcuenta + "' AND cfinalizado=1 AND cdelete=0 ";
            DataSet _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
            foreach (DataRow _Dtw_Item in _G_Ds_DataSet.Tables[0].Rows)
            {
                _Str_IdConciliacion = _Dtw_Item["cidconciliacion"].ToString();
            }
            if (_Str_IdConciliacion.Length > 0)
            {
                _G_Str_SentenciaSQL = "SELECT csaldosegunbanco FROM TCONCILIACION WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND cidconciliacion='" + _Str_IdConciliacion + "'";
                _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
                if (_G_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    return true; //Salgo porque se encontro una conciliacion de la cual se tomara el saldo inicial de banco
                }
            }

            //Sino lo obtengo de la tabla de configuracion de saldos iniciales
            DataSet _Ds;
            string _Str_Sql = "SELECT cidconciliacionsaldoinicial,csaldoinicial FROM TCONCILIACIONSALDOINICIAL WHERE ccompany = '" + Frm_Padre._Str_Comp + "' AND cbanco = '" + pcbanco + "' AND cnumcuenta = '" + pcnumcuenta + "' AND cdelete = 0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //Si hay datos
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return true; //Salgo porque se encontro una configuracion de saldo inicial
            }

            //Si llegamos aqui es fail! no hay de donde tomar el saldo inicial
            return false;
        }

        /// <summary>
        /// Obtiene el saldo inicial del banco y cuenta 
        /// </summary>
        /// <param name="pcbanco"></param>
        /// <param name="pcnumcuenta"></param>
        /// <returns></returns>
        public static decimal _Mtd_ObtenerSaldoInicialBanco(string pcbanco, string pcnumcuenta)
        {
            decimal _decSaldo = 0;

            //Trato de Obtener el Saldo Inicial de la Ultima Conciliacion
            string _Str_IdConciliacion = "";
            string _G_Str_SentenciaSQL = "SELECT MAX(cidconciliacion) as cidconciliacion FROM TCONCILIACION WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CBANCO='" + pcbanco + "' AND CNUMCUENTA='" + pcnumcuenta + "' AND cfinalizado=1 AND cdelete=0 ";
            DataSet _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
            foreach (DataRow _Dtw_Item in _G_Ds_DataSet.Tables[0].Rows)
            {
                _Str_IdConciliacion = _Dtw_Item["cidconciliacion"].ToString();
            }
            if (_Str_IdConciliacion.Length > 0)
            {
                _G_Str_SentenciaSQL = "SELECT csaldosegunbanco FROM TCONCILIACION WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND cidconciliacion='" + _Str_IdConciliacion + "'";
                _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
                if (_G_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    //Salgo porque se encontro una conciliacion
                    _decSaldo = Convert.ToDecimal(_G_Ds_DataSet.Tables[0].Rows[0]["csaldosegunbanco"]);
                    return _decSaldo;
                }
            }

            //Sino lo obtengo de la tabla de configuracion de saldos iniciales
            DataSet _Ds;
            string _Str_Sql = "SELECT cidconciliacionsaldoinicial,csaldoinicial FROM TCONCILIACIONSALDOINICIAL WHERE ccompany = '" + Frm_Padre._Str_Comp + "' AND cbanco = '" + pcbanco + "' AND cnumcuenta = '" + pcnumcuenta + "' AND cdelete = 0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //Si hay datos
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _decSaldo = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["csaldoinicial"]);
            }
            return _decSaldo;
        }

        /// <summary>
        /// Obtener el monto de la ultima captura del banco y cuenta
        /// </summary>
        /// <param name="pcbanco"></param>
        /// <param name="pcnumcuenta"></param>
        /// <returns></returns>
        public static decimal _Mtd_ObtenerSaldoFinalCapturaBanco(string pcbanco, string pcnumcuenta, _TipoEstadoDeCuenta pTipoEstadoDeCuenta)
        {
            decimal _decSaldo = 0;
            DataSet _Ds;
            var _Str_TablaMaestra = pTipoEstadoDeCuenta == _TipoEstadoDeCuenta.Conciliacion ? "TDISPBANC" : "TEDOCUENTADISPM";
            string _Str_Sql = "SELECT csaldobanco FROM " + _Str_TablaMaestra + " WHERE ccompany = '" + Frm_Padre._Str_Comp + "' AND cbanco = '" + pcbanco + "' AND cnumcuenta = '" + pcnumcuenta + "' AND cdelete = 0 AND cconciliado = 0 and cregistroinicial = 0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //Si hay datos
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _decSaldo = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["csaldobanco"]);
            }
            return _decSaldo;
        }

        /// <summary>
        /// Indica si ya existe un registro inicial para el banco y cuenta proporcionados
        /// </summary>
        /// <param name="pcbanco"></param>
        /// <param name="pcnumcuenta"></param>
        /// <returns></returns>
        public static bool _Mtd_ExisteRegistroInicial(string pcbanco, string pcnumcuenta, _TipoEstadoDeCuenta pTipoEstadoDeCuenta)
        {
            DataSet _Ds;
            var _Str_TablaMaestra = pTipoEstadoDeCuenta == _TipoEstadoDeCuenta.Conciliacion ? "TDISPBANC" : "TEDOCUENTADISPM";
            string _Str_Sql = "SELECT cregistroinicial FROM " + _Str_TablaMaestra + " WHERE cregistroinicial = 1 AND  ccompany = '" + Frm_Padre._Str_Comp + "' AND cbanco = '" + pcbanco + "' AND cnumcuenta = '" + pcnumcuenta + "' AND cdelete = 0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //Si hay datos
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Indica si ya existe una conciliacion registrada para el banco y cuenta proporcionados
        /// </summary>
        /// <param name="pcbanco"></param>
        /// <param name="pcnumcuenta"></param>
        /// <returns></returns>
        public static bool _Mtd_ExisteConciliacionRegistrada(string pcbanco, string pcnumcuenta)
        {
            DataSet _Ds;
            string _Str_Sql = "SELECT cidconciliacion FROM TCONCILIACION WHERE ccompany = '" + Frm_Padre._Str_Comp + "' AND cbanco = '" + pcbanco + "' AND cnumcuenta = '" + pcnumcuenta + "' AND cdelete = 0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //Si hay datos
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Indica si existe una estado de cuenta por conciliar para el banco y cuenta proprocionados
        /// </summary>
        /// <param name="pcbanco"></param>
        /// <param name="pcnumcuenta"></param>
        /// <returns></returns>
        public static bool _Mtd_ExisteEstadoDeCuentaPorConciliar(string pcbanco, string pcnumcuenta, _TipoEstadoDeCuenta pTipoEstadoDeCuenta)
        {
            DataSet _Ds;
            var _Str_TablaMaestra = pTipoEstadoDeCuenta == _TipoEstadoDeCuenta.Conciliacion ? "TDISPBANC" : "TEDOCUENTADISPM";
            string _Str_Sql = "SELECT cdispbanc FROM " + _Str_TablaMaestra + " WHERE cregistroinicial=0 AND  ccompany = '" + Frm_Padre._Str_Comp + "' AND cbanco = '" + pcbanco + "' AND cnumcuenta = '" + pcnumcuenta + "' AND cconciliado=0 AND cdelete=0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //Si hay datos
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Agrega una registro a la tabla de marcaje de registros de anulacion de cheque
        /// </summary>
        /// <param name="_P_Str_ccompany"></param>
        /// <param name="_P_Int_cbanco"></param>
        /// <param name="_P_Str_cnumcuenta"></param>
        /// <param name="_P_Int_cidcomprob"></param>
        /// <param name="_P_Dat_cfecha"></param>
        /// <param name="_P_Str_cnumdocu"></param>
        public static void _Mtd_AgregarRegistroParaMarcajeChequesAnulados(string _P_Str_ccompany, string _P_Int_cbanco, string _P_Str_cnumcuenta, string _P_Int_cidcomprob, DateTime _P_Dat_cfecha, string _P_Str_cnumdocu)
        {
            var _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
            var _Str_Cadena = "INSERT INTO TANULACIOCHEQUECONCILIACION (ccompany,cbanco,cnumcuenta,cidcomprob,cfecha,cmarcado,cnumdocu) " + "VALUES " +
                              "('" + _P_Str_ccompany + "','" + _P_Int_cbanco + "','" + _P_Str_cnumcuenta + "','" + _P_Int_cidcomprob + "','" + _Cls_Formato._Mtd_fecha(_P_Dat_cfecha) + "','0','" + _P_Str_cnumdocu + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }

        /// <summary>
        /// Marca como Conciliados los Registros que correspondan (Anulacion de Cheques)
        /// </summary>
        /// <param name="_P_Str_cbanco"></param>
        /// <param name="_P_Str_cnumcuenta"></param>
        /// <param name="_P_Dat_FechaHasta"></param>
        public static void _Mtd_MarcarRegistrosAnulacionCheques(string _P_Str_ccompany, string _P_Str_cbanco, string _P_Str_cnumcuenta, DateTime _P_Dat_FechaHasta)
        {
            var _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
            var _Str_ccount = "";
            //Obtenemos el ccount
            var _Str_SentenciaSQL = "SELECT ccount FROM TCUENTBANC WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND cnumcuenta='" + _P_Str_cnumcuenta + "' AND CBANCO='" + _P_Str_cbanco + "' and cdelete='0'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            foreach (DataRow _Dtw_Fila in _Ds.Tables[0].Rows)
            {
                _Str_ccount = _Dtw_Fila["ccount"].ToString().Trim();
            }
            //Obtenemos los registros a anula desde la tabla de anulacion
            _Str_SentenciaSQL = "SELECT * FROM TANULACIOCHEQUECONCILIACION WHERE ccompany='" + _P_Str_ccompany + "' AND cbanco='" + _P_Str_cbanco + "' AND cnumcuenta='" + _P_Str_cnumcuenta + "' AND cfecha <= '" + _Cls_Formato._Mtd_fecha(_P_Dat_FechaHasta) + "' AND cmarcado='0'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);

            //Solo aplica si se obtiene los dos registros
            if (_Ds.Tables[0].Rows.Count == 2)
            {
                foreach (DataRow _Dtw_Item in _Ds.Tables[0].Rows)
                {
                    //Marcamos el registro del libro
                    string _Str_IdComprob = _Dtw_Item["cidcomprob"].ToString();
                    _Str_SentenciaSQL = "UPDATE TCOMPROBAND SET cconciliado='1' WHERE ccompany='" + _P_Str_ccompany + "' AND cidcomprob='" + _Str_IdComprob + "' AND ccount='" + _Str_ccount +
                                        "' AND ((ctotdebe > 0) OR (ctothaber > 0))";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                    //Marcamos el detalle de la tabla como actualizado
                    string _Str_ctanulacionchequeconciliacionid = _Dtw_Item["ctanulacionchequeconciliacionid"].ToString();
                    _Str_SentenciaSQL = "UPDATE TANULACIOCHEQUECONCILIACION SET cmarcado='1' WHERE ctanulacionchequeconciliacionid='" + _Str_ctanulacionchequeconciliacionid + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);

                    //CARGAMOS SU CONTRAPARTE (OSEA EL REGISTRO DE ANULACION)
                    var _Str_cnumdocu = _Dtw_Item["cnumdocu"].ToString();
                    _Str_SentenciaSQL = "SELECT * FROM TANULACIOCHEQUECONCILIACION WHERE ccompany='" + _P_Str_ccompany + "' AND cbanco='" + _P_Str_cbanco + "' AND cnumcuenta='" + _P_Str_cnumcuenta + "' AND ctanulacionchequeconciliacionid <> '" + _Str_ctanulacionchequeconciliacionid + "' AND cnumdocu = '" + _Str_cnumdocu + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                    foreach (DataRow _Dtw_Item2 in _Ds.Tables[0].Rows)
                    {
                        //Marcamos el registro del libro
                        _Str_IdComprob = _Dtw_Item2["cidcomprob"].ToString();
                        _Str_SentenciaSQL = "UPDATE TCOMPROBAND SET cconciliado='1' WHERE ccompany='" + _P_Str_ccompany + "' AND cidcomprob='" + _Str_IdComprob + "' AND ccount='" + _Str_ccount +
                                            "' AND ((ctotdebe > 0) OR (ctothaber > 0))";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                        //Marcamos el detalle de la tabla como actualizado
                        _Str_ctanulacionchequeconciliacionid = _Dtw_Item2["ctanulacionchequeconciliacionid"].ToString();
                        _Str_SentenciaSQL = "UPDATE TANULACIOCHEQUECONCILIACION SET cmarcado='1' WHERE ctanulacionchequeconciliacionid='" + _Str_ctanulacionchequeconciliacionid + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                    }
                }
            }
        }

        public static void _Mtd_ObtenerSaldosEstadoDeCuentaDisponibilidad(string pcbanco, string pcnumcuenta, out double _P_Dbl_SaldoInicial, out double _P_Dbl_SaldoFinal, out double _P_Dbl_MontoBloqueado, out double _P_Dbl_SaldoReal, out double _P_Dbl_MontoDisponible)
        {
            double _Dbl_SaldoInicialBancoConsulta = 0;
            double _Dbl_SaldoFinalBancoConsulta = 0;
            double _Dbl_MontoBloqueadoFinalConsulta = 0;
            double _Dbl_MontoDisponibleFinalConsulta = 0;
            double _Dbl_MontoSaldoRealFinalConsulta = 0;

            var _Str_Sql = "SELECT csaldobancoinicial, csaldobanco, cmontodiferido, cmontodisponible FROM TEDOCUENTADISPM WHERE ccompany = '" + Frm_Padre._Str_Comp + "' AND cbanco = '" + pcbanco + "' AND cnumcuenta = '" + pcnumcuenta + "' AND cdelete = 0 AND cconciliado = 0 and cregistroinicial = 0";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //Si hay datos
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Dbl_SaldoInicialBancoConsulta = Convert.ToDouble(_Ds.Tables[0].Rows[0]["csaldobancoinicial"]);
                _Dbl_SaldoFinalBancoConsulta = Convert.ToDouble(_Ds.Tables[0].Rows[0]["csaldobanco"]);
                _Dbl_MontoBloqueadoFinalConsulta = _Ds.Tables[0].Rows[0]["cmontodiferido"].ToString() == "" ? 0 : Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontodiferido"]);
                _Dbl_MontoDisponibleFinalConsulta = _Ds.Tables[0].Rows[0]["cmontodisponible"].ToString() == "" ? 0 : Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontodisponible"]);
                _Dbl_MontoSaldoRealFinalConsulta = _Dbl_SaldoFinalBancoConsulta + _Dbl_MontoBloqueadoFinalConsulta;
            }
            //Devolvemos
            _P_Dbl_SaldoInicial = _Dbl_SaldoInicialBancoConsulta;
            _P_Dbl_SaldoFinal = _Dbl_SaldoFinalBancoConsulta;
            _P_Dbl_MontoBloqueado = _Dbl_MontoBloqueadoFinalConsulta;
            _P_Dbl_MontoDisponible = _Dbl_MontoDisponibleFinalConsulta;
            _P_Dbl_SaldoReal = _Dbl_MontoSaldoRealFinalConsulta;
        }

    }
}
