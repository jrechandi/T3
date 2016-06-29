using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ExportarIncSPIUser : Form
    {
        public Frm_ExportarIncSPIUser()
        {
            InitializeComponent();
        }
        public Frm_ExportarIncSPIUser(string _Str_Company,string _Str_Mes,string _Str_Ano,string _Str_TipoGeneracion)
        {
            InitializeComponent();
            _Mtd_UsuariosSinSPI(_Str_Company, _Str_Mes, _Str_Ano, _Str_TipoGeneracion);
        }
        private void _Mtd_UsuariosSinSPI(string _Str_Company, string _Str_Mes, string _Str_Ano, string _Str_TipoGeneracion)
        {
            try
            {
                string _Str_Cadena = "SELECT DISTINCT TUSER.cuser AS [USUARIO], TUSER.cname as [NOMBRE],TUSER.ccedula as [CÉDULA] FROM TCALINCTOTAL INNER JOIN TUSER ON TCALINCTOTAL.cvendedor = TUSER.cuser WHERE NOT EXISTS(SELECT CVENDEDOR FROM TCALINCTOTALEXCEP WHERE TCALINCTOTALEXCEP.CVENDEDOR COLLATE DATABASE_DEFAULT=TCALINCTOTAL.CVENDEDOR COLLATE DATABASE_DEFAULT AND TCALINCTOTALEXCEP.CCOMPANY='"+_Str_Company+"' AND TCALINCTOTALEXCEP.CYEARACCO=TCALINCTOTAL.CYEARACCO AND TCALINCTOTALEXCEP.CMONTACCO=TCALINCTOTAL.CMONTACCO AND TCALINCTOTALEXCEP.CTIPOGENERACION=TCALINCTOTAL.CTIPOGENERACION) AND (TCALINCTOTAL.cidvendedorsistnomina = '0') AND TCALINCTOTAL.cyearacco='" + _Str_Ano + "' AND TCALINCTOTAL.cmontacco='" + _Str_Mes + "' AND TCALINCTOTAL.ctipogeneracion='" + _Str_TipoGeneracion + "' AND TCALINCTOTAL.CCOMPANY='" + _Str_Company + "'";
                DataSet _Ds_DataSet = new DataSet();
                _Ds_DataSet= Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Dtg_GridUser.DataSource = _Ds_DataSet.Tables[0];
                _Dtg_GridUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch
            {
            }
        }
    }
}
