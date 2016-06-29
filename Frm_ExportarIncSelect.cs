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
    public partial class Frm_ExportarIncSelect : Form
    {
        public Frm_ExportarIncSelect()
        {
            InitializeComponent();
        }
        public Frm_ExportarIncSelect(string _Str_Company, string _Str_Mes, string _Str_Ano, string _Str_TipoGeneracion)
        {
            InitializeComponent();
            _Mtd_UsuariosSPI(_Str_Company, _Str_Mes, _Str_Ano, _Str_TipoGeneracion);
        }
        string _Str_Company_;
        string _Str_Mes_;
        string _Str_Ano_;
        string _Str_TipoGeneracion_;
        private void _Mtd_UsuariosSPI(string _Str_Company, string _Str_Mes, string _Str_Ano, string _Str_TipoGeneracion)
        {
            try
            {
                _Str_Company_ = _Str_Company;
                _Str_Mes_ = _Str_Mes;
                _Str_Ano_ = _Str_Ano;
                _Str_TipoGeneracion_ = _Str_TipoGeneracion;
                string _Str_Cadena = "SELECT DISTINCT TUSER.cuser AS [USUARIO], TUSER.cname as [NOMBRE],TUSER.ccedula as [CÉDULA],1 AS cgenerarinc FROM TCALINCTOTAL INNER JOIN TUSER ON TCALINCTOTAL.cvendedor = TUSER.cuser WHERE TCALINCTOTAL.cyearacco='" + _Str_Ano + "' AND TCALINCTOTAL.cmontacco='" + _Str_Mes + "' AND TCALINCTOTAL.ctipogeneracion='" + _Str_TipoGeneracion + "' AND TCALINCTOTAL.CCOMPANY='" + _Str_Company + "'";
                DataSet _Ds_DataSet = new DataSet();
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Dtg_GridUser.DataSource = _Ds_DataSet.Tables[0];
                _Dtg_GridUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                foreach(DataGridViewColumn _Dtg_Columna in _Dtg_GridUser.Columns)
                {
                    _Dtg_Columna.ReadOnly=true;
                }
                _Dtg_GridUser.Columns[3].ReadOnly = false;
            }
            catch
            {
            }
        }
        public bool _Bol_Seleccionado;
        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            try
            {
                
                foreach (DataGridViewRow _Dg_Row in _Dtg_GridUser.Rows)
                {
                    string _Str_Seleccionado = "0";
                    _Str_Seleccionado = _Dg_Row.Cells[3].Value.ToString();
                    string _Str_Vendedor = "0";
                    _Str_Vendedor = _Dg_Row.Cells[0].Value.ToString();
                    if (_Str_Seleccionado == "0")
                    {
                        string _Str_Cadena = "DELETE FROM TCALINCTOTALEXCEP WHERE CCOMPANY='" + _Str_Company_ + "' AND CVENDEDOR='" + _Str_Vendedor + "' AND CYEARACCO='" + _Str_Ano_ + "' AND CMONTACCO='" + _Str_Mes_ + "' AND CTIPOGENERACION='"+_Str_TipoGeneracion_+"'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "INSERT INTO TCALINCTOTALEXCEP(CCOMPANY,CVENDEDOR,CYEARACCO,CMONTACCO,CTIPOGENERACION) VALUES('" + _Str_Company_ + "','" + _Str_Vendedor + "','" + _Str_Ano_ + "','" + _Str_Mes_ + "','" + _Str_TipoGeneracion_ + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                    else
                    {
                        string _Str_Cadena = "DELETE FROM TCALINCTOTALEXCEP WHERE CCOMPANY='" + _Str_Company_ + "' AND CVENDEDOR='" + _Str_Vendedor + "' AND CYEARACCO='" + _Str_Ano_ + "' AND CMONTACCO='" + _Str_Mes_ + "' AND CTIPOGENERACION='" + _Str_TipoGeneracion_ + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Bol_Seleccionado = true;
                    }
                }
                if (_Bol_Seleccionado)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar al menos un usuario para que se realice la generación de los incentivos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
            }
        }
    }
}
