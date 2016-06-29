using System;
using System.Text;

namespace T3
{
	/// <summary>
	/// Descripción breve de osio.
	/// </summary>
	public class osio
	{
		public osio()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		public static string encriptar(string variable)
		{
			Byte[] varia = Encoding.UTF8.GetBytes(variable);
			string convertido;
			convertido=Convert.ToBase64String(varia);
			string convertido2;
			Byte[] varia2 = Encoding.UTF7.GetBytes(convertido);
			convertido2=Convert.ToBase64String(varia2);
			string vald = convertido2.Replace("=","SGv");
			return vald;
		}
		public static string desencriptar(string variable2)
		{
			string valor99 = variable2.Replace("SGv","=");
			Byte[] aconvertir2= Convert.FromBase64String(valor99);
			string valor78 = Encoding.UTF7.GetString(aconvertir2);
			Byte[] aconvert = Convert.FromBase64String(valor78);
			string valor4 = Encoding.UTF8.GetString(aconvert);
			return valor4;
		}
	}
}
