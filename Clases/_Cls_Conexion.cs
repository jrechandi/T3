// 17/10/2012
using System;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.IO;
namespace T3.CLASES
{
	/// <summary>
	/// Descripción breve de Class1.
	/// </summary> 
	public class _Cls_Conexion
	{
        public static int _Int_Sucursal = 0;
        public static bool _Bol_UsuarioRemoto = false;
        public static bool _Bol_ConexionRemota = false;
        public _Cls_Conexion()
        {
            _Int_Sucursal = _Mtd_ObtenerSucursal();
        }
        public static string _G_Str_VersionT3;
        public static string _G_Str_Url_Services;
        public static string _G_Str_Url_RelacionesCobranzaLocal = "";
        public static bool _Bol_Rdp = false;
        public static int _Int_RemotoId = 0;
      
        /// <summary>
        /// obtiene el INT de la sucursal que está configurado en la máquina
        /// el archivo debe estar en: C:\CONSSA\T3\T3_Sucursal.xml
        /// </summary>
        /// <returns></returns>
        ////para solo desarrollo
        //private int _Mtd_ObtenerSucursal()
        //{
        //    _Bol_UsuarioRemoto = false;
        //    _Bol_Rdp = false;
        //    return 97;
        //}
        private int _Mtd_ObtenerSucursal()
        {

            _G_Str_VersionT3 = CLASES._Cls_VersionActual._G_Str_VersionT3;
            if (File.Exists("C://CONSSA//T3//T3_Sucursal.xml"))
            {
                DataSet _Ds = new DataSet();
                _Ds.ReadXml("C://CONSSA//T3//T3_Sucursal.xml");
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(_Ds.Tables[0].Rows[0]["c_remoto"]) == 2 || Convert.ToInt32(_Ds.Tables[0].Rows[0]["c_remoto"]) == 3)
                    {
                        _Bol_UsuarioRemoto = true;
                        _Bol_Rdp = true;
                        _Int_RemotoId = Convert.ToInt32(_Ds.Tables[0].Rows[0]["c_remoto"]);
                    }
                    else
                    {
                        _Bol_UsuarioRemoto = Convert.ToBoolean(Convert.ToInt32(_Ds.Tables[0].Rows[0]["c_remoto"]));
                    }
                    return Convert.ToInt32(_Ds.Tables[0].Rows[0]["c_sucursal"].ToString().Trim());
                }
            }
            return 0;
        }


        private clslibraryconssa._Cls_claseconexion _MyCnnLocal = new clslibraryconssa._Cls_claseconexion();
        public static string _Str_ReportServerUrl = "";
        
        public static string _Str_ReportPath = "/Reportes_t3/";

        /// <summary>
        /// conexión a sqlserver sucursal (cliente t3win -> bd t3win)
        /// </summary>
        public clslibraryconssa._Cls_claseconexion _mtd_conexion
        {            
            get
            {
                clslibraryconssa._Cls_claseconexion _MyCnnLocal = new clslibraryconssa._Cls_claseconexion();
                if (_Bol_ConexionRemota)
                {
                    #region remoto
                    
                    #region productivo
                    if (_Int_Sucursal == 2)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.2.5; user id=devn; password=cronssat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.2.5/ReportServer$SQL_2005";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://www.t3.web.ve/t3web/";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web_2 = "http://www.t3.web.ve/t3web_2/";
                        _G_Str_Url_Services = "http://172.16.1.2/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.2.5/t3web/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 3)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.3.5; user id=devn; password=cronssat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.3.5/ReportServer$SQL_2005";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://www.t3.web.ve/t3web/";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web_2 = "http://www.t3.web.ve/t3web_2/";
                        _G_Str_Url_Services = "http://172.16.1.2/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.3.5/t3web/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 4)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.4.5; user id=devn; password=cronssat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.4.5/ReportServer$SQL_2005";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://www.t3.web.ve/t3web/";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web_2 = "http://www.t3.web.ve/t3web_2/";
                        _G_Str_Url_Services = "http://172.16.1.2/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.4.5/t3web/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 5)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.5.5; user id=devn; password=cronssat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.5.5/ReportServer$SQL_2005";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://www.t3.web.ve/t3web/";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web_2 = "http://www.t3.web.ve/t3web_2/";
                        _G_Str_Url_Services = "http://172.16.1.2/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.5.5/t3web/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 6)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.6.5; user id=devn; password=cronssat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.6.5/ReportServer$SQL_2005";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://www.t3.web.ve/t3web/";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web_2 = "http://www.t3.web.ve/t3web_2/";
                        _G_Str_Url_Services = "http://172.16.1.2/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.6.5/t3web/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 8)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.8.5; user id=devn; password=cronssat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.8.5/ReportServer$SQL_2005";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://www.t3.web.ve/t3web/";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web_2 = "http://www.t3.web.ve/t3web_2/";
                        _G_Str_Url_Services = "http://172.16.1.2/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.8.5/t3web/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 9)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.9.5; user id=devn; password=cronssat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.9.5/ReportServer$SQL_2005";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://www.t3.web.ve/t3web/";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web_2 = "http://www.t3.web.ve/t3web_2/";
                        _G_Str_Url_Services = "http://172.16.1.2/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.9.5/t3web/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 10)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.10.5; user id=devn; password=cronssat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.10.5/ReportServer$SQL_2005";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://www.t3.web.ve/t3web/";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web_2 = "http://www.t3.web.ve/t3web_2/";
                        _G_Str_Url_Services = "http://172.16.1.2/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.10.5/t3web/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 11)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.11.5; user id=devn; password=cronssat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.11.5/ReportServer$SQL_2005";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://www.t3.web.ve/t3web/";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web_2 = "http://www.t3.web.ve/t3web_2/";
                        _G_Str_Url_Services = "http://172.16.1.2/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.11.5/t3web/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 12)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.12.5; user id=devn; password=cronssat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.12.5/ReportServer$SQL_2005";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://www.t3.web.ve/t3web/";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web_2 = "http://www.t3.web.ve/t3web_2/";
                        _G_Str_Url_Services = "http://172.16.1.2/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.12.5/t3web/cobranza/mrelacionaprob.aspx";
                    }
                    #endregion
                    
                    #region desarrollo
                    else if (_Int_Sucursal == 1)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.1.9; user id=devn; password=sistemat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.1.9/ReportServer";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://192.168.1.9/t3web/";
                        _G_Str_Url_Services = "http://192.168.1.9/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.1.9/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 97)
                    {
                        _MyCnnLocal._g_Str_Stringconex = @"server=192.168.1.9; user id=devn; password=sistemat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.1.9/ReportServer";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://192.168.1.9/t3web/";
                        _G_Str_Url_Services = "http://192.168.1.9/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.1.9/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 98)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.1.9; user id=devn; password=sistemat300**; initial catalog=T3_EB";
                        _Str_ReportServerUrl = @"http://192.168.1.9/ReportServer";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://192.168.1.9/t3web/";
                        _G_Str_Url_Services = "http://192.168.1.9/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.1.9/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 99)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.1.9; user id=devn; password=sistemat300**; initial catalog=T3_DG";
                        _Str_ReportServerUrl = @"http://192.168.1.9/ReportServer";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://192.168.1.9/t3web/";
                        _G_Str_Url_Services = "http://192.168.1.9/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.1.9/cobranza/mrelacionaprob.aspx";
                    }
                    #endregion
                    
                    #endregion
                }
                else
                {
                    #region local

                    #region productivo
                    if (_Int_Sucursal == 2)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.2.5; user id=devn; password=cronssat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.2.5/ReportServer$SQL_2005";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://www.t3.web.ve/t3web/";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web_2 = "http://www.t3.web.ve/t3web_2/";
                        _G_Str_Url_Services = "http://172.16.1.2/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.2.5/t3web/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 3)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.3.5; user id=devn; password=cronssat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.3.5/ReportServer$SQL_2005";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://172.16.1.2/t3web/";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web_2 = "http://172.16.1.2/t3web_2/";
                        _G_Str_Url_Services = "http://172.16.1.2/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.3.5/t3web/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 3)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.3.5; user id=devn; password=cronssat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.3.5/ReportServer$SQL_2005";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://172.16.1.2/t3web/";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web_2 = "http://172.16.1.2/t3web_2/";
                        _G_Str_Url_Services = "http://172.16.1.2/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.3.5/t3web/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 4)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.4.5; user id=devn; password=cronssat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.4.5/ReportServer$SQL_2005";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://172.16.1.2/t3web/";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web_2 = "http://172.16.1.2/t3web_2/";
                        _G_Str_Url_Services = "http://172.16.1.2/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.4.5/t3web/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 5)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.5.5; user id=devn; password=cronssat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.5.5/ReportServer$SQL_2005";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://172.16.1.2/t3web/";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web_2 = "http://172.16.1.2/t3web_2/";
                        _G_Str_Url_Services = "http://172.16.1.2/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.5.5/t3web/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 6)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.6.5; user id=devn; password=cronssat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.6.5/ReportServer$SQL_2005";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://172.16.1.2/t3web/";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web_2 = "http://172.16.1.2/t3web_2/";
                        _G_Str_Url_Services = "http://172.16.1.2/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.6.5/t3web/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 8)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.8.5; user id=devn; password=cronssat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.8.5/ReportServer$SQL_2005";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://172.16.1.2/t3web/";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web_2 = "http://172.16.1.2/t3web_2/";
                        _G_Str_Url_Services = "http://172.16.1.2/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.8.5/t3web/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 9)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.9.5; user id=devn; password=cronssat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.9.5/ReportServer$SQL_2005";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://172.16.1.2/t3web/";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web_2 = "http://172.16.1.2/t3web_2/";
                        _G_Str_Url_Services = "http://172.16.1.2/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.9.5/t3web/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 10)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.10.5; user id=devn; password=cronssat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.10.5/ReportServer$SQL_2005";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://172.16.1.2/t3web/";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web_2 = "http://172.16.1.2/t3web_2/";
                        _G_Str_Url_Services = "http://172.16.1.2/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.10.5/t3web/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 11)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.11.5; user id=devn; password=cronssat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.11.5/ReportServer$SQL_2005";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://172.16.1.2/t3web/";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web_2 = "http://172.16.1.2/t3web_2/";
                        _G_Str_Url_Services = "http://172.16.1.2/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.11.5/t3web/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 12)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.12.5; user id=devn; password=cronssat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.12.5/ReportServer$SQL_2005";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://172.16.1.2/t3web/";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web_2 = "http://172.16.1.2/t3web_2/";
                        _G_Str_Url_Services = "http://172.16.1.2/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.12.5/t3web/cobranza/mrelacionaprob.aspx";
                    }

                    #endregion

                    #region desarrollo
                    else if (_Int_Sucursal == 1)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.1.9; user id=devn; password=sistemat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.1.9/ReportServer";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://192.168.1.9/t3web/";
                        _G_Str_Url_Services = "http://192.168.1.9/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.1.9/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 97)
                    {
                        _MyCnnLocal._g_Str_Stringconex = @"server=192.168.1.9; user id=devn; password=sistemat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.1.9/ReportServer";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://192.168.1.9/t3web/";
                        _G_Str_Url_Services = "http://192.168.1.9/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.1.9/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 977)
                    {
                        _MyCnnLocal._g_Str_Stringconex = @"server=192.168.1.9\t3sucursal; user id=devn; password=sistemat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.1.9/ReportServer";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://192.168.1.9/t3web/";
                        _G_Str_Url_Services = "http://192.168.1.9/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.1.9/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 9777)
                    {
                        _MyCnnLocal._g_Str_Stringconex = @"server=192.168.1.9\implantacion; user id=devn; password=sistemat300**; initial catalog=T3";
                        _Str_ReportServerUrl = @"http://192.168.1.9/ReportServer";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://192.168.1.9/t3web/";
                        _G_Str_Url_Services = "http://192.168.1.9/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.1.9/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 98)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.1.9; user id=devn; password=sistemat300**; initial catalog=T3_EB";
                        _Str_ReportServerUrl = @"http://192.168.1.9/ReportServer";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://192.168.1.9/t3web/";
                        _G_Str_Url_Services = "http://192.168.1.9/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.1.9/cobranza/mrelacionaprob.aspx";
                    }
                    else if (_Int_Sucursal == 99)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.1.9; user id=devn; password=sistemat300**; initial catalog=T3_DG";
                        _Str_ReportServerUrl = @"http://192.168.1.9/ReportServer";
                        CLASES._Cls_Varios_Metodos._Str_Servidor_Web = "http://192.168.1.9/t3web/";
                        _G_Str_Url_Services = "http://192.168.1.9/t3web/Ser_EmailValidate.asmx";
                        _G_Str_Url_RelacionesCobranzaLocal = "http://192.168.1.9/cobranza/mrelacionaprob.aspx";
                    }
                    #endregion
                    
                    #endregion
                }
                return _MyCnnLocal;
            }
            set
            {
            }
        }

        /// <summary>
        /// conexión a sqlserver conssa (cliente t3win -> bd t3web)
        /// </summary>
        public clslibraryconssa._Cls_claseconexion _mtd_conexion2
        {
            get
            {
                clslibraryconssa._Cls_claseconexion _MyCnnWeb = new clslibraryconssa._Cls_claseconexion();

                #region local y remoto

                #region productivo
                if (_Int_Sucursal == 2)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=172.16.1.3; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";

                }
                else if (_Int_Sucursal == 3)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=172.16.1.3; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";

                }
                else if (_Int_Sucursal == 4)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=172.16.1.3; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";

                }
                else if (_Int_Sucursal == 5)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=172.16.1.3; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";

                }
                else if (_Int_Sucursal == 6)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=172.16.1.3; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    
                }
                else if (_Int_Sucursal == 8)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=172.16.1.3; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";

                }
                else if (_Int_Sucursal == 9)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=172.16.1.3; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    
                }
                else if (_Int_Sucursal == 10)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=172.16.1.3; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                }
                else if (_Int_Sucursal == 11)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=172.16.1.3; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                }
                else if (_Int_Sucursal == 12)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=172.16.1.3; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                }
                #endregion

                #region desarrollo
                else if (_Int_Sucursal == 1)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=192.168.1.9; user id=dbuserweb; password=sistemat300**; initial catalog=T3WEB";
                }
                else if (_Int_Sucursal == 97)
                {
                    _MyCnnWeb._g_Str_Stringconex = @"server=192.168.1.9; user id=dbuserweb; password=sistemat300**; initial catalog=T3WEB";
                }
                else if (_Int_Sucursal == 98)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=192.168.1.9; user id=dbuserweb; password=sistemat300**; initial catalog=T3WEB_EB";
                }
                else if (_Int_Sucursal == 99)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=192.168.1.9; user id=dbuserweb; password=sistemat300**; initial catalog=T3WEB_DG";
                }
                #endregion

                #endregion

                return _MyCnnWeb;
            }
            set
            {
            }
        }
        
        /// <summary>
        /// conexión a sqlserver sucursal para ejecucion de dts (cliente t3win -> bd t3win)
        /// </summary>
        public clslibraryconssa._Cls_claseconexion _mtd_conexion3
        {
            get
            {
                clslibraryconssa._Cls_claseconexion _MyCnnDTS = new clslibraryconssa._Cls_claseconexion();
                if (_Bol_ConexionRemota)
                {
                    #region remoto

                    #region productivo
                    if (_Int_Sucursal == 2)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.2.5; user id=dbuserdts; password=cronssat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 3)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.3.5; user id=dbuserdts; password=cronssat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 4)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.4.5; user id=dbuserdts; password=cronssat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 5)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.5.5; user id=dbuserdts; password=cronssat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 6)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.6.5; user id=dbuserdts; password=cronssat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 8)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.8.5; user id=dbuserdts; password=cronssat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 9)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.9.5; user id=dbuserdts; password=cronssat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 10)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.10.5; user id=dbuserdts; password=cronssat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 11)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.11.5; user id=dbuserdts; password=cronssat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 12)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.12.5; user id=dbuserdts; password=cronssat300**; initial catalog=T3";
                    }
                    #endregion

                    #region desarrollo
                    else if (_Int_Sucursal == 1)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.1.9; user id=dbuserdts; password=sistemat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 97)
                    {
                        _MyCnnDTS._g_Str_Stringconex = @"server=192.168.1.9; user id=dbuserdts; password=sistemat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 98)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.1.9; user id=dbuserdts; password=sistemat300**; initial catalog=T3_EB";
                    }
                    else if (_Int_Sucursal == 99)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.1.9; user id=dbuserdts; password=sistemat300**; initial catalog=T3_DG";
                    }
                    #endregion

                    #endregion
                }
                else
                {
                    #region local

                    #region productivo
                    if (_Int_Sucursal == 2)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.2.5; user id=dbuserdts; password=cronssat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 3)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.3.5; user id=dbuserdts; password=cronssat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 4)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.4.5; user id=dbuserdts; password=cronssat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 5)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.5.5; user id=dbuserdts; password=cronssat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 6)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.6.5; user id=dbuserdts; password=cronssat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 8)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.8.5; user id=dbuserdts; password=cronssat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 9)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.9.5; user id=dbuserdts; password=cronssat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 10)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.10.5; user id=dbuserdts; password=cronssat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 11)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.11.5; user id=dbuserdts; password=cronssat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 12)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.12.5; user id=dbuserdts; password=cronssat300**; initial catalog=T3";
                    }
                    #endregion
                    
                    #region desarrollo
                    if (_Int_Sucursal == 1)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.1.9; user id=dbuserdts; password=sistemat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 97)
                    {
                        _MyCnnDTS._g_Str_Stringconex = @"server=192.168.1.9; user id=dbuserdts; password=sistemat300**; initial catalog=T3";
                    }
                    else if (_Int_Sucursal == 98)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.1.9; user id=dbuserdts; password=sistemat300**; initial catalog=T3_EB";
                    }
                    else if (_Int_Sucursal == 99)
                    {
                        _MyCnnDTS._g_Str_Stringconex = "server=192.168.1.9; user id=dbuserdts; password=sistemat300**; initial catalog=T3_DG";
                    }
                    #endregion

                    #endregion
                }
                return _MyCnnDTS;
            }
            set
            {
            }
        }

        /// <summary>
        /// conexión a sqlserver sucursal para creacion de respaldos (cliente t3win -> bd t3win)
        /// </summary>
        public clslibraryconssa._Cls_claseconexion _mtd_conexion4
        {
            get
            {
                clslibraryconssa._Cls_claseconexion _MyCnnWeb = new clslibraryconssa._Cls_claseconexion();
                if (_Bol_ConexionRemota)
                {
                    #region remoto

                    #region productivo
                    if (_Int_Sucursal == 2)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.2.5; user id=dbreport; password=cronssat300**; initial catalog=T3WEB";

                    }
                    else if (_Int_Sucursal == 3)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.3.5; user id=dbreport; password=cronssat300**; initial catalog=T3WEB";

                    }
                    else if (_Int_Sucursal == 4)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.4.5; user id=dbreport; password=cronssat300**; initial catalog=T3WEB";

                    }
                    else if (_Int_Sucursal == 5)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.5.5; user id=dbreport; password=cronssat300**; initial catalog=T3WEB";

                    }
                    else if (_Int_Sucursal == 6)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.6.5; user id=dbreport; password=cronssat300**; initial catalog=T3WEB";

                    }
                    else if (_Int_Sucursal == 8)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.8.5; user id=dbreport; password=cronssat300**; initial catalog=T3WEB";

                    }
                    else if (_Int_Sucursal == 9)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.9.5; user id=dbreport; password=cronssat300**; initial catalog=T3WEB";

                    }
                    else if (_Int_Sucursal == 10)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.10.5; user id=dbreport; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 11)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.11.5; user id=dbreport; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 12)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.12.5; user id=dbreport; password=cronssat300**; initial catalog=T3WEB";
                    }
                    #endregion

                    #region desarrollo
                    else if (_Int_Sucursal == 1)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.1.9; user id=dbreport; password=sistemat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 97)
                    {
                        _MyCnnWeb._g_Str_Stringconex = @"server=192.168.1.9; user id=dbreport; password=sistemat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 98)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.1.9; user id=dbreport; password=sistemat300**; initial catalog=T3WEB_EB";
                    }
                    else if (_Int_Sucursal == 99)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.1.9; user id=dbreport; password=sistemat300**; initial catalog=T3WEB_DG";
                    }
                    #endregion

                    #endregion
                }
                else
                {
                    #region local

                    #region productivo
                    if (_Int_Sucursal == 2)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.2.5; user id=dbreport; password=cronssat300**; initial catalog=T3WEB";

                    }
                    else if (_Int_Sucursal == 3)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.3.5; user id=dbreport; password=cronssat300**; initial catalog=T3WEB";

                    }
                    else if (_Int_Sucursal == 4)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.4.5; user id=dbreport; password=cronssat300**; initial catalog=T3WEB";

                    }
                    else if (_Int_Sucursal == 5)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.5.5; user id=dbreport; password=cronssat300**; initial catalog=T3WEB";

                    }
                    else if (_Int_Sucursal == 6)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.6.5; user id=dbreport; password=cronssat300**; initial catalog=T3WEB";

                    }
                    else if (_Int_Sucursal == 8)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.8.5; user id=dbreport; password=cronssat300**; initial catalog=T3WEB";

                    }
                    else if (_Int_Sucursal == 9)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.9.5; user id=dbreport; password=cronssat300**; initial catalog=T3WEB";

                    }
                    else if (_Int_Sucursal == 10)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.10.5; user id=dbreport; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 11)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.11.5; user id=dbreport; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 12)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.12.5; user id=dbreport; password=cronssat300**; initial catalog=T3WEB";
                    }
                    #endregion

                    #region desarrollo
                    else if (_Int_Sucursal == 1)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.1.9; user id=dbreport; password=sistemat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 97)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.1.9; user id=dbreport; password=sistemat300**; initial catalog=T3WEB_IMPLANTACION";
                    } 
                    else if (_Int_Sucursal == 98)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.1.9; user id=dbreport; password=sistemat300**; initial catalog=T3WEB_EB";
                    }
                    else if (_Int_Sucursal == 99)
                    {
                        _MyCnnWeb._g_Str_Stringconex = "server=192.168.1.9; user id=dbreport; password=sistemat300**; initial catalog=T3WEB_DG";
                    }
                    #endregion

                    #endregion
                }
                return _MyCnnWeb;
            }
            set
            {
            }
        }

        /// <summary>
        /// conexión a sqlserver sucursal (cliente t3win -> bd t3win (local) )
        /// </summary>
        public clslibraryconssa._Cls_claseconexion _mtd_conexion_T3WEB_Local
        {
            get
            {
                clslibraryconssa._Cls_claseconexion _MyCnnLocal = new clslibraryconssa._Cls_claseconexion();
                if (_Bol_ConexionRemota)
                {
                    #region remoto

                    #region productivo
                    if (_Int_Sucursal == 2)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.2.5; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 3)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.3.5; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 4)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.4.5; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 5)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.5.5; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 6)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.6.5; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 8)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.8.5; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 9)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.9.5; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 10)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.10.5; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 11)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.11.5; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 12)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.12.5; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    }
                    #endregion

                    #region desarrollo
                    else if (_Int_Sucursal == 1)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.1.9; user id=dbuserweb; password=sistemat300**; initial catalog=T3WEB_CUP";
                    }
                    else if (_Int_Sucursal == 97)
                    {
                        _MyCnnLocal._g_Str_Stringconex = @"server=192.168.1.9; user id=dbuserweb; password=sistemat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 98)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.1.9; user id=dbuserweb; password=sistemat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 99)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.1.9; user id=dbuserweb; password=sistemat300**; initial catalog=T3WEB";
                    }
                    #endregion

                    #endregion
                }
                else
                {
                    #region local

                    #region productivo
                    if (_Int_Sucursal == 2)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.2.5; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 3)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.3.5; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 3)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.3.5; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 4)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.4.5; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 5)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.5.5; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 6)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.6.5; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 8)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.8.5; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 9)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.9.5; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 10)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.10.5; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 11)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.11.5; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 12)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.12.5; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB";
                    }

                    #endregion

                    #region desarrollo
                    else if (_Int_Sucursal == 1)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.1.9; user id=dbuserweb; password=sistemat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 97)
                    {
                        _MyCnnLocal._g_Str_Stringconex = @"server=192.168.1.9\t3sucursal; user id=dbuserweb; password=sistemat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 977)
                    {
                        _MyCnnLocal._g_Str_Stringconex = @"server=192.168.1.9\t3sucursal; user id=dbuserweb; password=sistemat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 9777)
                    {
                        _MyCnnLocal._g_Str_Stringconex = @"server=192.168.1.9\implantacion; user id=dbuserweb; password=sistemat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 98)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.1.9; user id=dbuserweb; password=sistemat300**; initial catalog=T3WEB";
                    }
                    else if (_Int_Sucursal == 99)
                    {
                        _MyCnnLocal._g_Str_Stringconex = "server=192.168.1.9; user id=dbuserweb; password=sistemat300**; initial catalog=T3WEB";
                    }
                    #endregion

                    #endregion
                }
                return _MyCnnLocal;
            }
            set
            {
            }
        }

        /// <summary>
        /// conexión a sqlserver sucursal para ejecucion de dts (cliente t3win -> bd t3web (2012)
        /// </summary>
        public clslibraryconssa._Cls_claseconexion _mtd_conexionSQL2012
        {
            get
            {
                clslibraryconssa._Cls_claseconexion _MyCnnWeb = new clslibraryconssa._Cls_claseconexion();

                #region local y remoto

                #region productivo
                if (_Int_Sucursal == 2)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=172.16.1.7; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB2012";

                }
                else if (_Int_Sucursal == 3)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=172.16.1.7; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB2012";

                }
                else if (_Int_Sucursal == 4)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=172.16.1.7; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB2012";

                }
                else if (_Int_Sucursal == 5)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=172.16.1.7; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB2012";

                }
                else if (_Int_Sucursal == 6)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=172.16.1.7; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB2012";

                }
                else if (_Int_Sucursal == 8)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=172.16.1.7; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB2012";

                }
                else if (_Int_Sucursal == 9)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=172.16.1.7; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB2012";

                }
                else if (_Int_Sucursal == 10)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=172.16.1.7; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB2012";
                }
                else if (_Int_Sucursal == 11)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=172.16.1.7; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB2012";
                }
                else if (_Int_Sucursal == 12)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=172.16.1.7; user id=dbuserweb; password=cronssat300**; initial catalog=T3WEB2012";
                }
                #endregion

                #region desarrollo
                else if (_Int_Sucursal == 1)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=192.168.1.9; user id=dbuserweb; password=sistemat300**; initial catalog=T3WEB";
                }
                else if (_Int_Sucursal == 97)
                {
                    _MyCnnWeb._g_Str_Stringconex = @"server=192.168.1.9; user id=dbuserweb; password=sistemat300**; initial catalog=t3web";
                }
                else if (_Int_Sucursal == 98)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=192.168.1.9; user id=dbuserweb; password=sistemat300**; initial catalog=T3WEB_EB";
                }
                else if (_Int_Sucursal == 99)
                {
                    _MyCnnWeb._g_Str_Stringconex = "server=192.168.1.9; user id=dbuserweb; password=sistemat300**; initial catalog=T3WEB_DG";
                }
                #endregion

                #endregion

                return _MyCnnWeb;
            }
            set
            {
            }
        }

        /// <summary>
        /// conexión a sucursales morochas
        /// </summary>
        public clslibraryconssa._Cls_claseconexion _Mtd_ConexionExterna
        {
            get
            {
                clslibraryconssa._Cls_claseconexion _MyCnnLocal = new clslibraryconssa._Cls_claseconexion();
                string _Str_Cadena = "SELECT cipretenciones,cipretencioneslocal FROM TCONFIGCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _MyCnnLocal._g_Str_Stringconex = "server=" + _Ds.Tables[0].Rows[0]["cipretenciones"].ToString().Trim() + "; user id=devn; password=cronssat300**; initial catalog=T3";
                if (!_Cls_Varios_Metodos._Mtd_VerificarConexionExternaVerif())
                {
                    _MyCnnLocal._g_Str_Stringconex = "server=" + _Ds.Tables[0].Rows[0]["cipretencioneslocal"].ToString().Trim() + "; user id=devn; password=cronssat300**; initial catalog=T3";
                }
                return _MyCnnLocal;
            }
        }

        /// <summary>
        /// Para probar cual será la ip correcta en donde se crearán las retenciones
        /// </summary>
        public clslibraryconssa._Cls_claseconexion _Mtd_ConexionExternaVerif 
        {
            get
            {
                clslibraryconssa._Cls_claseconexion _MyCnnLocal = new clslibraryconssa._Cls_claseconexion();
                string _Str_Cadena = "SELECT cipretenciones FROM TCONFIGCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _MyCnnLocal._g_Str_Stringconex = "server=" + _Ds.Tables[0].Rows[0][0].ToString().Trim() + "; user id=devn; password=cronssat300**; initial catalog=T3";
                return _MyCnnLocal;
            }
        }

	}
}

