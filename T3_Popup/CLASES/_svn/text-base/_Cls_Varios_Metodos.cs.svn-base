using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
namespace T3_Popup.CLASES
{
    public class _Cls_Varios_Metodos
    {
        public static string _Str_Servidor_Web = "http://desaserver/t3web/default.aspx";
        public Control[] _Ctrl_F;
        public _Cls_Varios_Metodos(Control[] _Ctrl_F_)
        {
            _Ctrl_F = _Ctrl_F_;
        }
        public _Cls_Varios_Metodos(bool _P_Bol_Boleano)
        {
            
        }
        Color _Clr_Color1 = new Color();
        public static string _Mtd_MontosSQL(double _P_Dbl_Monto)
        {
            return _P_Dbl_Monto.ToString("F2").Replace(",", ".");
        }
        public _Cls_Varios_Metodos()
        {
            int _Int_i=0;
            foreach (Control _Ctrl_ in _Ctrl_F)
            {
                if (_Ctrl_F[_Int_i].GetType() == typeof(RadioButton))
                {
                    _Clr_Color1 = _Ctrl_F[_Int_i].BackColor;
                    break;
                }
                _Int_i++;
            }
        }
        public void _Mtd_Foco()
        {
            foreach (Control _Ctrl_ in _Ctrl_F)
            {
                _Ctrl_.Leave+=new EventHandler(_Ctrl__Leave);
                _Ctrl_.Enter+=new EventHandler(_Ctrl__Enter);
            }
        }
        void _Ctrl__Leave(object sender, EventArgs e)
        {

            if (sender.GetType() == typeof(TextBox))
            {
                ((TextBox)sender).BackColor = _Clr_Color1;
            }
            if (sender.GetType() == typeof(CheckBox))
            {
                ((CheckBox)sender).BackColor = _Clr_Color1;
            }
            if (sender.GetType() == typeof(RadioButton))
            {
                ((RadioButton)sender).BackColor = _Clr_Color1;
            }
            if (sender.GetType() == typeof(ComboBox))
            {
                ((ComboBox)sender).BackColor = _Clr_Color1;
            }
            if (sender.GetType() == typeof(DateTimePicker))
            {
                ((DateTimePicker)sender).BackColor = _Clr_Color1;
            }
            if (sender.GetType() == typeof(MonthCalendar))
            {
                ((MonthCalendar)sender).BackColor = _Clr_Color1;
            }
        }
        void _Ctrl__Enter(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                ((TextBox)sender).BackColor = Color.Khaki;
            }
            if (sender.GetType() == typeof(CheckBox))
            {
                ((CheckBox)sender).BackColor = Color.Khaki;
            }
            if (sender.GetType() == typeof(RadioButton))
            {
                ((RadioButton)sender).BackColor = Color.Khaki;
            }
            if (sender.GetType() == typeof(ComboBox))
            {
                ((ComboBox)sender).BackColor = Color.Khaki;
            }
            if (sender.GetType() == typeof(DateTimePicker))
            {
                ((DateTimePicker)sender).BackColor = Color.Khaki;
            }
            if (sender.GetType() == typeof(MonthCalendar))
            {
                ((MonthCalendar)sender).BackColor = Color.Khaki;
            }
        }

        public string _Mtd_Correlativo(string _Pr_Str_Sql)
        {
            string _Str_R = "0";
            System.Data.SqlClient.SqlDataReader DR;
            DR = _Cls_Conexion._Mtd_Conexion_()._Mtd_RetornarDatareader(_Pr_Str_Sql);
            if (DR.HasRows)
            {
                while (DR.Read())
                {
                    if (DR.IsDBNull(0) == false)
                    {
                        _Str_R = Convert.ToString(Convert.ToInt32(DR.GetValue(0)) + 1);
                    }
                    else
                    {
                        _Str_R = "1";
                    }
                }
            }
            DR.Close();
            return _Str_R;
        }

        public void _Mtd_Valida_Numeros(TextBox _Pr_Txt, KeyPressEventArgs e, int _Pr_Int_Ent, int _Pr_Int_Deci)
        {
            int _Int_Pos, KeyAscii;
            string _Str_myDeci, _Str_myEntero;
            KeyAscii = Convert.ToInt32(e.KeyChar);
            switch (KeyAscii)
            {
                case 44://Asc(",")
                    if (_Pr_Int_Deci == 0)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        //if InStr(1, argControl.Text, ",", CompareMethod.Text) <> 0
                        if (_Pr_Txt.Text.IndexOf(",") != -1)
                        {
                            e.Handled = true;
                        }
                    }
                    break;
                case 8:
                    break;
                default:
                    if (KeyAscii >= 48 && KeyAscii <= 57)
                    {
                        _Int_Pos = _Pr_Txt.Text.IndexOf(",");
                        if (_Int_Pos != -1)
                        {
                            //myEntero = txt1.Text.Substring(1, (POS - 1));
                            _Str_myEntero = _Pr_Txt.Text.Substring(0, _Int_Pos);
                            _Str_myDeci = _Pr_Txt.Text.Substring(_Int_Pos + 1);
                            if (_Pr_Txt.SelectionStart <= _Str_myEntero.Length)
                            {
                                if (_Str_myEntero.Length >= _Pr_Int_Ent)
                                {
                                    e.Handled = true;
                                }
                                else
                                {
                                    if (_Int_Pos < _Pr_Txt.SelectionStart)
                                    {
                                        if (_Str_myDeci.Length >= _Pr_Int_Deci)
                                        {
                                            e.Handled = true;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (_Str_myDeci.Length >= _Pr_Int_Deci)
                                {
                                    e.Handled = true;
                                }
                            }
                        }
                        else
                        {
                            if (_Pr_Txt.Text.Length >= _Pr_Int_Ent)
                            {
                                e.Handled = true;
                            }
                        }
                    }
                    else
                    {
                        e.Handled = true;
                    }
                    break;
            }
        }

        public void _Mtd_Valida_NumerosRaya(TextBox _Pr_Txt, KeyPressEventArgs e)
        {
            int _Int_Pos, KeyAscii;
            KeyAscii = Convert.ToInt32(e.KeyChar);
            switch (KeyAscii)
            {
                case 45://Asc("-")
                    _Int_Pos = _Pr_Txt.Text.IndexOf("-");
                    if (_Int_Pos != -1)
                    {
                        if (_Pr_Txt.SelectionStart > 0)
                        {
                            try
                            {
                                if (_Pr_Txt.Text.Substring(_Pr_Txt.SelectionStart - 1, 1) == _Pr_Txt.Text.Substring(_Int_Pos, 1))
                                {
                                    e.Handled = true;
                                }
                                else
                                {
                                    if (_Pr_Txt.Text.Substring(_Pr_Txt.SelectionStart - 1, 1) == "-")
                                    {
                                        if (_Pr_Txt.Text.Substring(_Pr_Txt.SelectionStart, 1) == _Pr_Txt.Text.Substring(_Int_Pos, 1))
                                        {
                                            e.Handled = true;
                                        }
                                    }
                                }
                            }
                            catch { e.Handled = true; }
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                    break;
                case 40://Asc("(")
                    _Int_Pos = _Pr_Txt.Text.IndexOf("(");
                    if (_Int_Pos != -1)
                    {
                        if (_Pr_Txt.SelectionStart > 0)
                        {
                            try
                            {
                                if (_Pr_Txt.Text.Substring(_Pr_Txt.SelectionStart - 1, 1) == _Pr_Txt.Text.Substring(_Int_Pos, 1))
                                {
                                    e.Handled = true;
                                }
                                else
                                {
                                    if (_Pr_Txt.Text.Substring(_Pr_Txt.SelectionStart - 1, 1) == "(")
                                    {
                                        if (_Pr_Txt.Text.Substring(_Pr_Txt.SelectionStart, 1) == _Pr_Txt.Text.Substring(_Int_Pos, 1))
                                        {
                                            e.Handled = true;
                                        }
                                    }
                                }
                            }
                            catch { e.Handled = true; }
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                    break;
                case 41://Asc(")")
                    _Int_Pos = _Pr_Txt.Text.IndexOf(")");
                    if (_Int_Pos != -1)
                    {
                        if (_Pr_Txt.SelectionStart > 0)
                        {
                            try
                            {
                                if (_Pr_Txt.Text.Substring(_Pr_Txt.SelectionStart - 1, 1) == _Pr_Txt.Text.Substring(_Int_Pos, 1))
                                {
                                    e.Handled = true;
                                }
                                else
                                {
                                    if (_Pr_Txt.Text.Substring(_Pr_Txt.SelectionStart - 1, 1) == ")")
                                    {
                                        if (_Pr_Txt.Text.Substring(_Pr_Txt.SelectionStart, 1) == _Pr_Txt.Text.Substring(_Int_Pos, 1))
                                        {
                                            e.Handled = true;
                                        }
                                    }
                                }
                            }
                            catch { e.Handled = true; }
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                    break;
                case 8:
                    break;
                case 32://espacio
                    break;
                default:
                    if (!(KeyAscii >= 48 && KeyAscii <= 57))
                    {
                        e.Handled = true;
                    }
                    break;
            }
        }

        public void _Mtd_ValidaMail(TextBox _Pr_Txt, KeyPressEventArgs e)
        {
            int KeyAscii;
            string _Str_Mail_Ch;
            char[] _Chr_DelimiterChars = { ' ', '!', '#', '$', '%', '^', '&', '*', '(', ')', '-', '"', '+', '|', '{', '}', '[', ']', ':', '>', '<', '?', '/', '=', '\\' };
            string[] _Str_TextoResult;
            _Str_Mail_Ch = e.KeyChar.ToString();
            if (_Str_Mail_Ch == "@")
            {
                if (_Pr_Txt.Text.IndexOf("@") >= 1)
                {
                    e.Handled = true;
                }
            }
            if (e.Handled == false)
            {
                for (int y = 0; y <= _Chr_DelimiterChars.GetUpperBound(0); y++)
                {
                    if (_Str_Mail_Ch.Contains(_Chr_DelimiterChars[y].ToString()))
                    {
                        e.Handled = true;
                        break;
                    }
                }
            }

        }
      public static void _Mtd_EjecutarSP(string nombreSP, SqlParameter[] parametroSP)
        {
            System.Data.SqlClient.SqlConnection cone = new System.Data.SqlClient.SqlConnection(CLASES._Cls_Conexion._Mtd_Conexion_()._g_Str_Stringconex);
            cone.Open();
            System.Data.SqlClient.SqlCommand oMySqlCommand = new SqlCommand(nombreSP, cone);
            //System.Data.MySqlClient.MySqlCommand oMySqlCommand = new MySqlCommand(sentencia_sql,cone);
            //SqlDataReader j = new SqlDataReader();
            //SqlCommandBuilder d =
            new SqlCommandBuilder();
            oMySqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parametrossp = new SqlParameter[parametroSP.Length];
            for (int i = 0; i < parametroSP.Length; i++)
            {
                parametrossp[i] = parametroSP[i];
                oMySqlCommand.Parameters.Add(parametrossp[i]);
            }
            oMySqlCommand.ExecuteNonQuery();
            //omy ExecuteNonQuery(conn.Connection, CommandType.StoredProcedure,"insertar", paramsToStore);
            cone.Close();            
        }
        public int _Mtd_ValidaMail(string email)
        {
            int t_valid;
            int t_totallen;
            int t_counter = 0;
            int t_atpos = 1;
            int i = 1;
            int t_pointpos = 1;
            string mail_ch;
            char[] delimiterChars = { ' ', '!', '#', '$', '%', '^', '&', '*', '(', ')', '-', '"', '+', '|', '{', '}', '[', ']', ':', '>', '<', '?', '/', '=', '\\' };
            string[] textoResult;
            t_totallen = email.Length;
            t_counter = t_totallen;
            i = 1;
            t_valid = 1;
            // Validamos la longitud del correo, no puede ser vacío   
            if (email.Length == 0)
            {
                t_valid = 0;
            }
            else
            {//--------------------------------------   
                //Valida que no contenga caracteres inválidos en un correo
                t_counter = t_totallen;
                while (t_counter > 0)
                {
                    mail_ch = email.Substring(i, 1);
                    i = i + 1;
                    t_counter = t_counter - 1;
                    textoResult = mail_ch.Split(delimiterChars);
                    if (textoResult.Length > 0)
                    {
                        t_valid = 0;
                        break;
                    }
                }
                //---------------------------------------
                //Valida que no tenga mas de un @
                t_atpos = email.IndexOf("@", 1, 2);
                if (t_atpos > 1)
                {
                    t_valid = 0;
                }
                //---------------------------------------
                //--Valida que contenga solo un @
                t_atpos = email.IndexOf("@", 1);
                if ((t_atpos == 0) || (t_atpos == 1))
                {
                    t_valid = 0;
                }
                //---------------------------------------
                //Validamos que tenga por lo menos un punto (.)
                t_pointpos = email.IndexOf(".", 1);
                if ((t_pointpos == 0) || (t_pointpos == 1))
                {
                    t_valid = 0;
                }
            }
            return t_valid;
        }
        public void _Mtd_CargarCombo(ComboBox _Pr_Cb, string _Str_Sql)
        {
            DataSet _Ds;
            DataRow _Row;
            _Pr_Cb.DataSource = null;
            _Ds = CLASES._Cls_Conexion._Mtd_Conexion_()._Mtd_RetornarDataset(_Str_Sql);
            _Row = _Ds.Tables[0].NewRow();
            _Row[1] = "...";
            _Row[0] = "nulo";
            _Ds.Tables[0].Rows.Add(_Row);
            _Pr_Cb.DataSource = _Ds.Tables[0];
            _Pr_Cb.DisplayMember = _Ds.Tables[0].Columns[1].ColumnName;
            _Pr_Cb.ValueMember = _Ds.Tables[0].Columns[0].ColumnName;
            _Pr_Cb.SelectedValue = "nulo";
        }
        public static Array _Mtd_ArrayRedim(Array _Pr_orgArray, Int32 _Pr_Int_Tamaño)
        {
            Type t = _Pr_orgArray.GetType().GetElementType();
            Array _nArray = Array.CreateInstance(t, _Pr_Int_Tamaño);
            Array.Copy(_Pr_orgArray, 0, _nArray, 0, Math.Min(_Pr_orgArray.Length, _Pr_Int_Tamaño));
            return _nArray;
        }
        //__________________________________________________________________________

        public string _Mtd_ObtenerMes(int _Pr_Int_Mes)
        {
            string _Str_R = "";
            switch (_Pr_Int_Mes)
            {
                case 1:
                    _Str_R = "ENERO";
                    break;
                case 2:
                    _Str_R = "FEBRERO";
                    break;
                case 3:
                    _Str_R = "MARZO";
                    break;
                case 4:
                    _Str_R = "ABRIL";
                    break;
                case 5:
                    _Str_R = "MAYO";
                    break;
                case 6:
                    _Str_R = "JUNIO";
                    break;
                case 7:
                    _Str_R = "JULIO";
                    break;
                case 8:
                    _Str_R = "AGOSTO";
                    break;
                case 9:
                    _Str_R = "SEPTIEMBRE";
                    break;
                case 10:
                    _Str_R = "OCTUBRE";
                    break;
                case 11:
                    _Str_R = "NOVIEMBRE";
                    break;
                case 12:
                    _Str_R = "DICIEMBRE";
                    break;
                default:
                    _Str_R = "MES NO VALIDO";
                    break;
            }
            return _Str_R;
        }


        public string _Mtd_ObtenerUsuarioFirma(string _Pr_Str_UsuId)
        {
            string _Str_R = "";
            DataSet _Ds_A = CLASES._Cls_Conexion._Mtd_Conexion_()._Mtd_RetornarDataset("SELECT cfirmante FROM TUSER WHERE cuser='" + _Pr_Str_UsuId + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_R = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]);
            }
            return _Str_R;
        }

        public bool _Mtd_UsuarioProceso(string _Pr_Str_Usu, string _Pr_Str_UsuProceso)
        {
            bool _Bol_R = false;
            string _Str_Sql = "";
            _Str_Sql = "SELECT cprocesofirma FROM TPROCEFIRMAD WHERE cuser='" + _Pr_Str_Usu + "'";
            DataSet _Ds_A = CLASES._Cls_Conexion._Mtd_Conexion_()._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds_A.Tables[0].Rows)
            {
                if (Convert.ToString(_DRow[0]) == _Pr_Str_UsuProceso)
                {
                    _Bol_R = true;
                    break;
                }
            }
            return _Bol_R;
        }

        public string _Mtd_ObtenerUsuarioName(string _Pr_Str_UsuiD)
        {
            string _Str_R = "";
            DataSet _Ds_A = CLASES._Cls_Conexion._Mtd_Conexion_()._Mtd_RetornarDataset("SELECT cname FROM TUSER WHERE cuser='" + _Pr_Str_UsuiD + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_R = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]);
            }
            return _Str_R;
        }
    }

}
