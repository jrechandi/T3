using System;
using System.Data.SqlClient;
using System.Data;

namespace T3_Popup.CLASES
{
	/// <summary>
	/// Descripción breve de Class1.
	/// </summary>
	public class _Cls_Conexion
	{
		public _Cls_Conexion()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		private clslibraryconssa._Cls_claseconexion Prueba__;
		public clslibraryconssa._Cls_claseconexion _mtd_conexion
		{
			get
			{
				Prueba__=_Mtd_Conexion_();
				return Prueba__;
			}
			set
			{

			}
		}
        private clslibraryconssa._Cls_claseconexion Prueba__2;
        public clslibraryconssa._Cls_claseconexion _mtd_conexion2
        {
            get
            {
                Prueba__2 = _Mtd_Conexion_2();
                return Prueba__2;
            }
            set
            {

            }
        }
		clslibraryconssa._Cls_claseconexion prueba= new clslibraryconssa._Cls_claseconexion();
		public static clslibraryconssa._Cls_claseconexion _Mtd_Conexion_()
		{
			clslibraryconssa._Cls_claseconexion prueba1= new clslibraryconssa._Cls_claseconexion();			
			try
			{
                prueba1._g_Str_Stringconex = "server=DESASERVER; user id=devn; password=conssa01; initial catalog=T3TEST";
                //prueba1._g_Str_Stringconex = "server=LOCALSERVER; user id=devn; password=conssa01; initial catalog=T3TEST";
                //prueba1._g_Str_Stringconex = "server=CONDORSYS.NO-IP.BIZ,1478; user id=devn; password=conssa01; initial catalog=T3TEST";
				//prueba1._Mtd_conexion;
				return prueba1;
			}
			catch
			{
				return null;
			}
		}
  
        public static clslibraryconssa._Cls_claseconexion _Mtd_Conexion_2()
        {
            clslibraryconssa._Cls_claseconexion prueba2 = new clslibraryconssa._Cls_claseconexion();
            try
            {

                prueba2._g_Str_Stringconex = "server=DESASERVER; user id=sqluser%t3.com.ve; password=1478769; initial catalog=T3WEB_TEST";
                //prueba2._g_Str_stringconex = "server=CONDORSYS.NO-IP.BIZ; user id=sqluser%t3.com.ve; password=1478769; initial catalog=T3WEB_TEST";
                //prueba1._Mtd_conexion;
                return prueba2;
            }
            catch
            {
                return null;
            }
        }
	}
}
