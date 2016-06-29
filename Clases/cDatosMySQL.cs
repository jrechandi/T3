using System;
using System.Data;
//using System.Data.MySqlClient;
using MySql.Data.MySqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace T3
{
	/// <summary>
	/// Clase para implementar CRUD de datos con My SQL
	/// Por: NP13
	/// </summary>
	public class cDatosMySQL//:T3.gDatos
	{
		#region Declaraciones
		MySqlConnection cone = new MySqlConnection();
		string cadena_conexion;
		string servidor;
		string usuario;
		string clave;
		string basedatos;
		#endregion
		#region Propiedades
		public string Servidor
		{
			get{return servidor;}
			set{servidor=value;}
		}
		public string Usuario
		{
			get{return usuario;}
			set{usuario=value;}
		}
		public string Clave
		{
			get{return clave;}
			set{clave=value;}
		}
		public string BaseDatos
		{
			get{return basedatos;}
			set{basedatos=value;}
		}
		#endregion
		#region Acciones
		public string CadenaConexion()
		{
			string cadena="";
			try
			{
				string linea;
				string	archEmp="cadena.txt";

				using (StreamReader sr = new StreamReader(archEmp,System.Text.Encoding.ASCII)) 
				
				{
					while ((linea = sr.ReadLine()) != null) 
					{
						if (linea.Length>0)
						{
							cadena=linea.ToString();
						}
					}
					sr.Close();
				}
				return cadena;
			}
			catch
			{
				//MessageBox.Show("Ocurrio un error en la conexión. Intente mas tarde.");
				return cadena;
			}
		}
		/// <summary>
		/// Establece la conexion con la base de datos esta sobrecarga no recibe parametros
		/// arma la cadena de conexion a partir de las propiedades servidor, usuario,clave y basedatos de la clase
		/// estos valores deben estar asignados antede de llamar ha este metodo 
		/// </summary>
		/// <param name="el_ConnectionString"></param>
		/// <returns></returns>
		public bool Conectar()
		{
			//borra estas cuatro lineas, esto debe ser llenado en el cliente de la clase
			cadena_conexion=CadenaConexion();
//			servidor="192.168.0.1";
//			usuario="ut3";
//			clave="ct3";
//			basedatos="T3";
			//
			try
			{
//				cadena_conexion="Host="+servidor+"; UserName="+usuario+"; Password="+clave+"; Database="+basedatos+";";
				cone.ConnectionString=cadena_conexion;
				cone.Open();
				return true;
			}
			catch 
			{
				return false;
			}
		}
		public string Conectar(int i)
		{
			//borra estas cuatro lineas, esto debe ser llenado en el cliente de la clase
			cadena_conexion=CadenaConexion();			
//			servidor="192.168.0.1";
//			usuario="ut3";
//			clave="ct3";
//			basedatos="T3";
			//
			try
			{
//				cadena_conexion="Host="+servidor+"; UserName="+usuario+"; Password="+clave+"; Database="+basedatos+";";
				cone.ConnectionString=cadena_conexion;
				cone.Open();
				return cadena_conexion;
			}
			catch 
			{
				return cadena_conexion;
			}
		}
		/// <summary>
		/// Establece la conexion con la base de datos esta sobrecarga recibe la 
		/// cadena de conexion ejemplo:
		/// "Host=begeta; UserName=nplanchart; Password=sa; Database=T3;"
		/// 		/// </summary>
		/// <param name="el_ConnectionString"></param>
		/// <returns></returns>
		public bool Conectar(string el_ConnectionString)
		{
			try
			{
				cone.ConnectionString=el_ConnectionString;
				cone.Open();
				return true;
			}
			catch 
			{
				return false;
			}
		}
		/// <summary>
		/// Recibe una selentencia SQL de seleccion ejemplo "Select * Form T301"
		/// y Regresa un objeto _MySqlDataReader_
		/// -El manejo de errores queda por parte del cliente de la clase.
		/// </summary>
		/// <returns></returns>
		public MySqlDataReader RegresarDR (string Str_de_Seleccion)
		{
			if (cone.State.ToString()!="Open"){bool x = this.Conectar();}
			MySqlCommand cmd = new MySqlCommand(Str_de_Seleccion,cone);
			MySqlDataReader oDataReader = cmd.ExecuteReader();
			return oDataReader;
		}
		/// <summary>
		/// Recibe una selentencia SQL de seleccion. ejemplo: "Select * Form T301"
		/// y Regresa un objeto _DataSet_
		/// -El manejo de errores queda por parte del cliente de la clase.
		/// </summary>
		/// <param name="Str_de_Seleccion"></param>
		/// <returns></returns>
		public System.Data.DataSet RegresarDS (string Str_de_Seleccion)
		{
			if (cone.State.ToString()!="Open"){bool x = this.Conectar();}

			MySqlDataAdapter oDA = new MySqlDataAdapter();
			MySqlCommand ocmd = new MySqlCommand(Str_de_Seleccion,cone);
			System.Data.DataSet oDataset = new DataSet();
			oDA.SelectCommand= ocmd;
			oDA.Fill(oDataset);
			return oDataset;
		}

		/// <summary>
		/// Recibe un sentencia de actualizacion y la ejecuta en la Base de Datos. ejemplos:
		/// INSERT INTO tclientes (codcli, nombre, codsuc) VALUES ('1', 'Cliente 1', 'a3')
		/// UPDATE tclientes Set nombre='new name' WHERE (codcli ='1')
		/// DELETE FROM tclientes WHERE (codcli ='1')
		/// y retorna el numero de filas afectadas.
		/// -El manejo de errores queda por parte del cliente de la clase.
		/// </summary>
		/// <param name="sentencia_sql"></param>
		/// <returns></returns>
		public int Ejecutar(string sentencia_sql)
		{
			if (cone.State.ToString()!="Open"){bool x = this.Conectar();}
			MySqlCommand oMySqlCommand = new MySqlCommand(sentencia_sql,cone);
			int nu = oMySqlCommand.ExecuteNonQuery();
			return nu;
		}	
		#endregion	
		#region contructores
		public cDatosMySQL()
		{
			cadena_conexion="Host=maracayup; UserName=roberth; Password=m25102; Database=t3;";
			if (cone.State.ToString()!="Open"){bool x = this.Conectar("s");}
		}
		public cDatosMySQL(string string_conexion)
		{
			if (cone.State.ToString()!="Open"){bool x = this.Conectar(string_conexion);}
		}
		#endregion	
	}
}
