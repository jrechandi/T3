using System;
//using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient;

namespace T3
{
	/// <summary>
	/// Descripción breve de cGrupo.
	/// Talba afectada TGROUP
	/// </summary>
	public class cGrupo
	{
		#region Campos_Privados
		//objetos externos
		cDatosMySQL oDatos = new cDatosMySQL();
		//
		string cgroup;
		string cname;
		string cdepartment;
		DateTime cdateadd;
		string cuseradd;
		DateTime cdateupd;
		string cuserupd;
		#endregion
		#region Propiedades_Publicas
		public string Grupo
		{	
			get{return cgroup;}
			set
			{
				if (value.Length>10|value.Length<1)
				{
					System.Exception erre = new Exception("Valor fuera del rango");
					throw erre;
				}
				else
				{
					cgroup=value;
				}
			}
		}
		public string Name
		{
			get{return cname;}
			set
			{
				if (value.Length>30|value.Length<1)
				{
					System.Exception erre = new Exception("Valor fuera del rango");
					throw erre;
				}
				else
				{
					cname=value;
				}
			}
		}
		public string Department
		{
			get{return cdepartment;}
			set
			{
				if (value.Length>10|value.Length<1)
				{
					System.Exception erre = new Exception("Valor fuera del rango");
					throw erre;
				}
				else
				{
					cdepartment=value;
				}
			}
		}
		public DateTime Dateadd
		{
			get{return cdateadd;}
			set{cdateadd=value;}
		}
		public string Useradd
		{
			get{return cuseradd;}
			set{cuseradd=value;}
		}
		public DateTime Dateudp
		{
			get{return cdateupd;}
			set{cdateupd=value;}
		}
		public string Userudp
		{
			get{return cuserupd;}
			set{cuserupd=value;}
		}
		#endregion
		#region Constructores
		public cGrupo()
		{
			
		}
		#endregion
		#region Metodos_Publicos
		cDatosMySQL sql = new cDatosMySQL();
		public System.Data.DataSet data()
		{
			string query="select * from TGROUP";
			//string query="select * from pruebas";
			return sql.RegresarDS(query);
		}
		public int agregar()
		{
			string usuario = "001c";
			cuseradd=usuario;
			cuserupd=usuario;
			
			string Sql = "INSERT INTO TGROUP (cgroup, cname, cdepartment, cdateadd, cuseradd, cdateupd, cuserupd) Values ('" + this.cgroup + "','"+ this.cname +"','" + this.cdepartment + "','" + cGene.CFecha_ptodb(System.DateTime.Now) + "','" + cuseradd + "','" + cGene.CFecha_ptodb(System.DateTime.Now) + "','" + cuserupd + "')";
			return sql.Ejecutar(Sql);
		}
		public int modificar()
		{
			string usuario = "001c";
			cuseradd=usuario;
			cuserupd=usuario;

			string Sql ="Update TGROUP set cname = '" + cname + "' ,cdepartment = '" + cdepartment + "',cdateupd = '" + cGene.CFecha_ptodb(System.DateTime.Now) + "',cuserupd = '" + cuserupd + "' where cgroup='" + cgroup + "'";
			return sql.Ejecutar(Sql);
		}
		public int eliminar()
		{
			string Sql = "DELETE FROM TGROUP WHERE (cgroup =" + cgroup + ")";
			return sql.Ejecutar(Sql);
		}
		/// <summary>
		/// Verifica la clave de un grupo
		/// Si el grupo existe carga los datos en las propiedades de la clase
		/// </summary>
		/// <param name="Usuario"></param>
		/// <param name="Clave"></param>
		/// <returns></returns>
		public bool Verificar_Grupo(string cgroup)
		{
			string str= "select * from TGROUP where	cgroup="+cgroup;
			MySqlDataReader mDR = sql.RegresarDR(str);
			if (mDR.Read())
			{
				mDR.Close();
				//mDR.Dispose();
				return true;
			}
			else
			{
				mDR.Close();
				//mDR.Dispose();
				return false;
			}
		}
		/// <summary>
		/// Regresa un objeto _DataSet_ 
		/// esta sobrecarga necesita una sentencia de seleccion
		/// </summary>
		/// <param name="str_seleccion"></param>
		/// <returns></returns>
		public System.Data.DataSet RegresarDS(string str_seleccion)
		{
			System.Data.DataSet ds= oDatos.RegresarDS(str_seleccion);
			return ds;
		}
		/// <summary>
		/// Regresa un objeto _DataSet_ con todos los usuarios 
		/// </summary>
		/// <returns></returns>
		public System.Data.DataSet RegresarDS()
		{
			System.Data.DataSet ds= oDatos.RegresarDS("select * from TGROUP");
			return ds;
		}
		public MySqlDataReader Busqueda(string cgroup)
		{
			return oDatos.RegresarDR("select * from TGROUP where cgroup = '"+cgroup+"'");
		}
		#endregion
	}
}
