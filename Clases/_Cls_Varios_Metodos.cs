using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Security.Cryptography;
using System.Net;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Data.Linq.SqlClient;
using System.IO;

namespace T3.CLASES
{
    public class _Cls_Varios_Metodos
    {
        public const string _Str_G_CuentaContProv = "PRV.X";
        public const string _Str_G_CuentaContBanco = "BNC.X";
        const string _Str_G_CuentaContBancoName = "PARAMETRO DE CUENTA DE BANCO";
        const string _Str_G_CuentaContProvName = "PARAMETRO DE CUENTA DE PROVEEDOR";
        public static string _Str_Servidor_Web = "";
        public static string _Str_Servidor_Web_2 = "";
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
        public static string _Mtd_MontosSQL(decimal _P_Dbl_Monto)
        {
            return _P_Dbl_Monto.ToString("F2").Replace(",", ".");
        }
        public static string _Mtd_MontosSQL_Float(double _P_Dbl_Monto)
        {
            return _P_Dbl_Monto.ToString().Replace(",", ".");
        }
        public static double _Mtd_MontoNumeric2(double _P_Dbl_Monto)
        {
            string _Str_Cadena = "DECLARE @NUMERO NUMERIC(18,2) SET @NUMERO=" + _P_Dbl_Monto.ToString().Replace(',', '.') + " SELECT @NUMERO";
            return Convert.ToDouble(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString());
        }
        public static bool _Mtd_DebitoBancarioCuentaBancaria()
        {
            bool _Bol_DebitoBancarioHabilitado = false;
            //Programación de comprobante contable según debito bancario
            DataSet _Ds_DebitoBancario = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cdebitobancario,cporcentdebitobancario FROM TCONFIGCONSSA");
            if (_Ds_DebitoBancario.Tables[0].Rows.Count > 0)
            {
                if (_Ds_DebitoBancario.Tables[0].Rows[0]["cdebitobancario"].ToString() == "1")
                {
                    _Bol_DebitoBancarioHabilitado = true;
                }
            }
            return _Bol_DebitoBancarioHabilitado;
            //
        }
        public static double _Mtd_MontoTruncado(double _P_Dbl_Monto, int _Int_Decimal)
        {
            string _Str_Cadena = "SELECT ROUND(" + _P_Dbl_Monto.ToString().Replace(',', '.') + "," + _Int_Decimal + ",1)";
            return Convert.ToDouble(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString());
        }
        public static bool _Mtd_VerificarCnn()
        {
            bool _Bol_R = false;
            try
            {
                Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT TOP 1 cuser FROM TUSER");
                _Bol_R = true;
            }
            catch 
            {
                MessageBox.Show("Problemas al conectarse a la Base de Datos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _Bol_R = false;
            }
            return _Bol_R;
        }
        public static bool _Mtd_VerificarCnn(Frm_Padre _Pr_Frm)
        {
            bool _Bol_R = false;
            try
            {
                Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT TOP 1 cuser FROM TUSER");
                _Pr_Frm.statusBar1.Panels[0].Text = "Listo";
                _Pr_Frm._Frm_Contenedor._Pnl_Contenedor.Enabled = true;
                _Pr_Frm._Frm_Contenedor._Pnl_ContenedorF.Enabled = true;
                _Bol_R = true;
            }
            catch
            {
                _Pr_Frm.statusBar1.Panels[0].Text = "Problemas en la Conexión.";
                _Pr_Frm._Frm_Contenedor._Pnl_Contenedor.Enabled = false;
                _Pr_Frm._Frm_Contenedor._Pnl_ContenedorF.Enabled = false;
                MessageBox.Show("Problemas al conectarse a la Base de Datos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _Bol_R = false;
            }
            return _Bol_R;
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
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Pr_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                {
                    _Str_R = Convert.ToString(Convert.ToInt32(_Ds.Tables[0].Rows[0][0]) + 1);
                }
                else
                { _Str_R = "1"; }
            }
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

        public void _Mtd_Valida_NumerosConSigno(TextBox _Pr_Txt, KeyPressEventArgs e, int _Pr_Int_Ent, int _Pr_Int_Deci)
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
                case 45: //Asc("-")
                        if (_Pr_Txt.Text.IndexOf("-") != -1)
                        {
                            e.Handled = true;
                        }
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

        public void _Mtd_Valida_Numeros(TextBox _Pr_Txt, KeyPressEventArgs e, int _Pr_Int_Ent, int _Pr_Int_Deci,double _Pr_Dbl_MontoHasta)
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
                        else if (_Pr_Txt.Text.Trim().Length == 0)
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
                                    else if (_Pr_Txt.Text.Trim().Length > 0)
                                    {
                                        if (Convert.ToDouble(_Pr_Txt.Text.Insert(_Pr_Txt.SelectionStart, e.KeyChar.ToString())) > _Pr_Dbl_MontoHasta & _Pr_Txt.SelectionLength != _Pr_Txt.Text.Length)
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
                                else if (_Pr_Txt.Text.Trim().Length > 0)
                                {
                                    if (Convert.ToDouble(_Pr_Txt.Text.Insert(_Pr_Txt.SelectionStart, e.KeyChar.ToString())) > _Pr_Dbl_MontoHasta & _Pr_Txt.SelectionLength != _Pr_Txt.Text.Length)
                                    {
                                        e.Handled = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (_Pr_Txt.Text.Length >= _Pr_Int_Ent)
                            {
                                e.Handled = true;
                            }
                            else
                            {
                                if (_Pr_Txt.Text.Trim().Length > 0)
                                {
                                    if (Convert.ToDouble(_Pr_Txt.Text.Insert(_Pr_Txt.SelectionStart, e.KeyChar.ToString())) > _Pr_Dbl_MontoHasta & _Pr_Txt.SelectionLength != _Pr_Txt.Text.Length)
                                    {
                                        e.Handled = true;
                                    }
                                }
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
        public bool _Mtd_VerificarNDImpresa(string _Pr_Str_ND, string _Pr_Str_ProvId)
        {
            bool _Bol_SwND = false;
            string _Str_Sql = "SELECT cimpresa FROM TNOTADEBITOCP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp='" + _Pr_Str_ND + "' AND cdelete=0 and cimpresa=1";
            DataSet _Ds_Z = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Z.Tables[0].Rows.Count > 0)
            {
                _Bol_SwND = true;
            }
            return _Bol_SwND;
        }
        /// <summary>
        /// VERIFICA SI EL NUMERO DE LA CUENTA CONTABLE ES DE UN BANCO
        /// </summary>
        /// <param name="_Pr_Str_Banco">ID DEL BANCO</param>
        /// <param name="_Pr_Str_Cuenta">ID DE LA CUENTA</param>
        /// <param name="_Pr_Str_Count">CUENTA CONTABLE A VERIFICAR</param>
        /// <returns></returns>
        public bool _Mtd_CuentaContableIsBanco(string _Pr_Str_Banco, string _Pr_Str_Cuenta, string _Pr_Str_Count)
        {
            bool _Bol_R = false;
            string _Str_Sql = "select ccount from TCUENTBANC where ccompany='" + Frm_Padre._Str_Comp + "' and cbanco='" + _Pr_Str_Banco + "' and cnumcuenta='" + _Pr_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) == _Pr_Str_Count)
                {
                    _Bol_R = true;
                }
            }
            return _Bol_R;
        }
        public string _Mtd_ObtenerElISLR(string _Pr_Str_Formula, string _Pr_Str_BaseImpo)
        {
            string _Str_R = "";
            CLASES.cls_ExcelFuncion ExcelFuncion = new CLASES.cls_ExcelFuncion();
            string _Str_Sql = "";
            string _Str_Formula = "";

            char[] words = new char[0];
            string[] words_var = new string[0];
            string[] words_const = new string[0];
            string _Str_VarMontoPagar = "";
            string _Str_VarImp = "";
            string _Str_VarIB = "";
            string _Str_Asus = "";
            string _Str_Bsus = "";
            double _Dbl_Sustarendo = 0;
            int _Int_C = 0;
            int _Int_Ini = 0;

            _Str_Formula = _Pr_Str_Formula;
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cvarislrmpagar,cvarislrimp,cvarislrib,cvarislrbi,csustraendoa,csustraendob from TCONFIGCXP where ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_VarMontoPagar = Convert.ToString(_Ds.Tables[0].Rows[0]["cvarislrbi"]);
                _Str_VarImp = Convert.ToString(_Ds.Tables[0].Rows[0]["cvarislrimp"]);
                _Str_VarIB = Convert.ToString(_Ds.Tables[0].Rows[0]["cvarislrib"]);
                _Str_Asus = Convert.ToString(_Ds.Tables[0].Rows[0]["csustraendoa"]);
                _Str_Bsus = Convert.ToString(_Ds.Tables[0].Rows[0]["csustraendob"]);
            }


            string _Str_Cad = "";
            //las variables
            words = _Pr_Str_Formula.ToCharArray();
            foreach (char s in words)
            {
                if (s.ToString() == "{")
                {
                    _Int_Ini = _Int_C;
                }
                if (s.ToString() == "}")
                {
                    _Str_Cad = _Pr_Str_Formula.Substring(_Int_Ini, (_Int_C - _Int_Ini) + 1);
                    if (_Str_Cad.Replace("{", "").Replace("}", "") == _Str_VarMontoPagar)
                    {
                        _Str_Formula = _Str_Formula.Replace(_Str_Cad, _Pr_Str_BaseImpo.Replace(".", ""));
                    }
                    if (_Str_Cad.Replace("{", "").Replace("}", "") == _Str_VarIB)
                    {
                        _Str_Formula = _Str_Formula.Replace(_Str_Cad, _Pr_Str_BaseImpo.Replace(".", ""));
                    }

                }
                _Int_C++;
            }
            _Int_C = 0;
            foreach (char s in words)
            {
                if (s.ToString() == "[")
                {
                    _Int_Ini = _Int_C;
                }
                if (s.ToString() == "]")
                {
                    _Str_Cad = _Pr_Str_Formula.Substring(_Int_Ini, (_Int_C - _Int_Ini) + 1);
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cidentif,cconst_valor from TCONST where cidentif='" + _Str_Cad.Replace("[", "").Replace("]", "") + "'");
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_Formula = _Str_Formula.Replace(_Str_Cad, Convert.ToString(_Ds.Tables[0].Rows[0]["cconst_valor"]));
                    }
                    if (_Str_Cad.Replace("[", "").Replace("]", "") == _Str_Asus || _Str_Cad.Replace("[", "").Replace("]", "") == _Str_Bsus)
                    {
                        _Dbl_Sustarendo = _Dbl_Sustarendo + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cconst_valor"]);
                    }

                }
                _Int_C++;
            }

            try
            { _Str_R = ExcelFuncion._Mtd_UsarFuncion(_Str_Formula); }
            catch
            { _Str_R = "0"; }
            ExcelFuncion._Mtd_Cerrar();
            ExcelFuncion = null;
            //utilizo excel para interpretar la formula
            return _Str_R;

        }
      public static void _Mtd_EjecutarSP(string nombreSP, SqlParameter[] parametroSP)
        {
            System.Data.SqlClient.SqlConnection cone = new System.Data.SqlClient.SqlConnection(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            cone.Open();
            System.Data.SqlClient.SqlCommand oMySqlCommand = new SqlCommand(nombreSP, cone);
            oMySqlCommand.CommandTimeout = 3600;
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
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Pr_Cb.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString(), _DRow[0].ToString()));
            }
            _Pr_Cb.DataSource = _myArrayList;
            _Pr_Cb.DisplayMember = "Display";
            _Pr_Cb.ValueMember = "Value";
            _Pr_Cb.SelectedValue = "nulo";
        }
        public void _Mtd_CargarCombo(ComboBox _Pr_Cb, string _Str_Sql,bool _Bol_Todos)
        {
            DataSet _Ds;
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Pr_Cb.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Todos", "nulo"));
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString(), _DRow[0].ToString()));
            }
            _Pr_Cb.DataSource = _myArrayList;
            _Pr_Cb.DisplayMember = "Display";
            _Pr_Cb.ValueMember = "Value";
            _Pr_Cb.SelectedValue = "nulo";
        }
        public void _Mtd_CargarComboWeb(ComboBox _Pr_Cb, string _Str_Sql)
        {
            DataSet _Ds;
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Pr_Cb.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _Ds = Program._MyClsCnn._mtd_conexion2._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString(), _DRow[0].ToString()));
            }
            _Pr_Cb.DataSource = _myArrayList;
            _Pr_Cb.DisplayMember = "Display";
            _Pr_Cb.ValueMember = "Value";
            _Pr_Cb.SelectedValue = "nulo";
        }
        public void _Mtd_CargarComboWebLocal(ComboBox _Pr_Cb, string _Str_Sql)
        {
            DataSet _Ds;
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Pr_Cb.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _Ds = Program._MyClsCnn._mtd_conexion4._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString(), _DRow[0].ToString()));
            }
            _Pr_Cb.DataSource = _myArrayList;
            _Pr_Cb.DisplayMember = "Display";
            _Pr_Cb.ValueMember = "Value";
            _Pr_Cb.SelectedValue = "nulo";
        }
        public void _Mtd_CargarCheckList(CheckedListBox _Pr_Lista, string _Pr_Str_Sql)
        {
            DataSet _Ds;
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            
            _Pr_Lista.DataSource = null;
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Pr_Str_Sql);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString(), _DRow[0].ToString()));
            }
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Pr_Lista.DataSource = _myArrayList;
                _Pr_Lista.DisplayMember = "Display";
                _Pr_Lista.ValueMember = "Value";
                _Pr_Lista.SelectedIndex = 0;
            }
        }
        public static Array _Mtd_ArrayRedim(Array _Pr_orgArray, Int32 _Pr_Int_Tamaño)
        {
            Type t = _Pr_orgArray.GetType().GetElementType();
            Array _nArray = Array.CreateInstance(t, _Pr_Int_Tamaño);
            Array.Copy(_Pr_orgArray, 0, _nArray, 0, Math.Min(_Pr_orgArray.Length, _Pr_Int_Tamaño));
            return _nArray;
        }
        public int _Mtd_Consecutivo_TCOMPROBANC()
        {
            try
            {
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cidcomprob FROM TCOMPROBANC where ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY cidcomprob  DESC ");
                object[] _Obj_f = new object[20];
                _Obj_f = _Ds.Tables[0].Rows[0].ItemArray;
                return Convert.ToInt32(_Obj_f[0].ToString()) + 1;
            }
            catch
            {
                return 1;
            }
        }
        public int _Mtd_Consecutivo_TCOMPROBANC(string _P_Str_Comp)
        {
            try
            {
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cidcomprob FROM TCOMPROBANC where ccompany='" + _P_Str_Comp + "' ORDER BY cidcomprob  DESC ");
                object[] _Obj_f = new object[20];
                _Obj_f = _Ds.Tables[0].Rows[0].ItemArray;
                return Convert.ToInt32(_Obj_f[0].ToString()) + 1;
            }
            catch
            {
                return 1;
            }
        }
        public int _Mtd_Consecutivo_TCOMPROBAND(string _P_Str_cidcomprob)
        {
            try
            {
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT corder FROM TCOMPROBAND where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _P_Str_cidcomprob + "' ORDER BY corder  DESC ");
                object[] _Obj_f = new object[20];
                _Obj_f = _Ds.Tables[0].Rows[0].ItemArray;
                return Convert.ToInt32(_Obj_f[0].ToString()) + 1;
            }
            catch
            {
                return 1;
            }
        }
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");

        public string _Mtd_CrearComprobanteAnulacion(string _P_Str_Comprobante)
        {
            int _Int_Comprobante = _Mtd_Consecutivo_TCOMPROBANC();
            string _Str_Cadena = "INSERT INTO TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) SELECT ccompany,'" + _Int_Comprobante + "',ctypcomp,cname + ' (ANULACION)' as cname,'" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year + "','" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',ctotdebe,ctothaber,cbalance,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','0','0' FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "INSERT INTO TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,ctothaber,cdateadd,cuseradd,cdescrip) SELECT TCOMPROBAND.ccompany,'" + _Int_Comprobante + "',corder,CASE WHEN TCOUNTINAC.ccountactiva IS NULL THEN TCOMPROBAND.ccount ELSE TCOUNTINAC.ccountactiva END,ctdocument,cnumdocu,cdatedocu,ctothaber,ctotdebe,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',CASE WHEN TCOUNTINAC.ccountactiva IS NULL THEN LTRIM(RTRIM(TCOMPROBAND.cdescrip)) ELSE REPLACE(TCOMPROBAND.cdescrip COLLATE DATABASE_DEFAULT, LTRIM(RTRIM(TCOUNT.cname)),LTRIM(RTRIM(TCOUNT_1.cname))) END + ' ANULACIÓN' " +
                "FROM TCOUNT AS TCOUNT_1 INNER JOIN " +
                "TCOUNTINAC ON TCOUNT_1.ccompany = TCOUNTINAC.ccompany AND TCOUNT_1.ccount = TCOUNTINAC.ccountactiva RIGHT OUTER JOIN " +
                "TCOMPROBAND INNER JOIN " +
                "TCOUNT ON TCOMPROBAND.ccompany = TCOUNT.ccompany AND TCOMPROBAND.ccount = TCOUNT.ccount ON  " +
                "TCOUNTINAC.ccompany = TCOMPROBAND.ccompany AND TCOUNTINAC.ccountinactiva = TCOMPROBAND.ccount WHERE TCOMPROBAND.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBAND.cidcomprob='" + _P_Str_Comprobante + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            return _Int_Comprobante.ToString();
        }

        public bool _Mtd_CuentasInactivas(string _P_Str_Comprobante)
        {
            string _Str_Cadena = "SELECT DISTINCT TCOMPROBAND.ccount FROM TCOMPROBAND INNER JOIN TCOUNT ON TCOMPROBAND.ccompany = TCOUNT.ccompany AND TCOMPROBAND.ccount = TCOUNT.ccount WHERE TCOMPROBAND.ccompany = '" + Frm_Padre._Str_Comp + "' AND TCOMPROBAND.cidcomprob='" + _P_Str_Comprobante + "' AND TCOUNT.cactivate = 0 AND NOT EXISTS(SELECT ccountinactiva FROM TCOUNTINAC WHERE TCOUNTINAC.ccompany=TCOUNT.ccompany AND TCOUNTINAC.ccountinactiva=TCOUNT.ccount)";
            _Str_Cadena += " UNION SELECT DISTINCT TCOMPROBAND.ccount FROM TCOMPROBAND INNER JOIN TCOUNTINAC ON TCOMPROBAND.ccompany = TCOUNTINAC.ccompany AND TCOMPROBAND.ccount = TCOUNTINAC.ccountinactiva WHERE TCOMPROBAND.ccompany = '" + Frm_Padre._Str_Comp + "' AND TCOMPROBAND.cidcomprob='" + _P_Str_Comprobante + "' AND ccountactiva IS NULL";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Cadena = "INSERT INTO TCOUNTINAC (ccompany,ccountinactiva) SELECT DISTINCT TCOUNT.ccompany,TCOUNT.ccount FROM TCOMPROBAND INNER JOIN TCOUNT ON TCOMPROBAND.ccompany = TCOUNT.ccompany AND TCOMPROBAND.ccount = TCOUNT.ccount WHERE TCOMPROBAND.ccompany = '" + Frm_Padre._Str_Comp + "' AND TCOMPROBAND.cidcomprob='" + _P_Str_Comprobante + "' AND TCOUNT.cactivate = 0 AND NOT EXISTS(SELECT ccountinactiva FROM TCOUNTINAC WHERE TCOUNTINAC.ccompany=TCOUNT.ccompany AND TCOUNTINAC.ccountinactiva=TCOUNT.ccount)";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                return true;
            }
            return false;
        }

        private string _Mtd_TipoDocumentNC_ND(bool _Bol_NC)
        {
            string _Str_Cadena = "SELECT ctipodocnc,ctipodocnd FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Bol_NC)
                { return _Ds.Tables[0].Rows[0]["ctipodocnc"].ToString().Trim(); }
                else
                { return _Ds.Tables[0].Rows[0]["ctipodocnd"].ToString().Trim(); }
            }
            return "0";
        }
        public string _Mtd_FechaVencCheqDev(string _P_Str_Cliente,string _P_Str_NumCheq)
        {
            string _Str_Cadena = "SELECT TSALDOCLIENTED.cfelimitcobro FROM TSALDOCLIENTED INNER JOIN TCONFIGCXC ON TSALDOCLIENTED.ccompany = TCONFIGCXC.ccompany AND TSALDOCLIENTED.ctipodocument = TCONFIGCXC.ctipdoccheqdev WHERE (TSALDOCLIENTED.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TSALDOCLIENTED.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TSALDOCLIENTED.ccliente = '" + _P_Str_Cliente + "') AND (TSALDOCLIENTED.cnumdocu = '" + _P_Str_NumCheq + "')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                { return _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0][0].ToString().Trim())); }
            }
            return "null";
        }
        public string _Mtd_TipoDocumentFACT_CXP(string _P_Str_Campo)
        {
            string _Str_Cadena = "SELECT " + _P_Str_Campo + " FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "0";
        }
        public string _Mtd_TipoDocument_CXC(string _P_Str_Campo)
        {
            string _Str_Cadena = "SELECT " + _P_Str_Campo + " FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "0";
        }
        public string _Mtd_TipoDocument_CXC(string _P_Str_Campo,string _P_Str_Comp)
        {
            string _Str_Cadena = "SELECT " + _P_Str_Campo + " FROM TCONFIGCXC WHERE ccompany='" + _P_Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "0";
        }
        public string _Mtd_TipoDocument_INV(string _P_Str_Campo)
        {
            string _Str_Cadena = "SELECT " + _P_Str_Campo + " FROM TCONFINVENT WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "0";
        }
        public string _Mtd_GenerarCadenaConexionExcel(string _Pr_Str_nombreArchivo)
        {
            string _Str_cadena = "Provider=Microsoft.Jet.OLEDB.4.0;"
                + "Data Source=" + _Pr_Str_nombreArchivo + ";"
                + "Extended Properties=Excel 8.0";
            return _Str_cadena;
        }
        public int _Mtd_Proceso_P_COMPRA(string _P_Str_cidnotrecepc, string _P_Str_cidrecepcion, string _P_Str_Proveedor, string _P_Str_Factura)
        {
            double _Dbl_PorcRetiene = 0; //gianqui
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            string _Str_CuentaCont = "", _Str_CuentaContName = "";
            string _Str_ProvNombre = "";//gianqui
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cnumdocu = "";
            string _Str_cfechadocu = "";
            string _Str_cmontosi = "";
            string _Str_cmontoimp = "";
            string _Str_Descfinan = "";
            string _Str_MontoTotal = "";
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            string _Str_FechaVenc = "";//gianqui
            string _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_COMPRA");
            string _Str_Cadena = "";
            DataSet _Ds; ;
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;

            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cporcenreteniva,c_nomb_abreviado from TPROVEEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _P_Str_Proveedor + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Dbl_PorcRetiene = 0;
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    _Dbl_PorcRetiene = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                }
                _Str_ProvNombre = Convert.ToString(_Ds.Tables[0].Rows[0][1]);
            }

            ////
            _Str_Cadena = "Select cnfacturapro,cdatefactura,csubtotal,ctotalimp,cdatevencimiento,ISNULL(cdescfinanmonto,0) AS cdescfinanmonto,ctotfactura from TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_cidrecepcion + "' and cproveedor='" + _P_Str_Proveedor + "' and cnfacturapro='" + _P_Str_Factura + "'";
            ////
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_cnumdocu = _Ds.Tables[0].Rows[0]["cnfacturapro"].ToString();
                _Str_cfechadocu = _Ds.Tables[0].Rows[0]["cdatefactura"].ToString();
                _Str_cmontosi = _Ds.Tables[0].Rows[0]["csubtotal"].ToString();
                _Str_cmontoimp = _Ds.Tables[0].Rows[0]["ctotalimp"].ToString();
                _Str_FechaVenc = _Ds.Tables[0].Rows[0]["cdatevencimiento"].ToString();
                _Str_Descfinan = _Ds.Tables[0].Rows[0]["cdescfinanmonto"].ToString();
                _Str_MontoTotal = _Ds.Tables[0].Rows[0]["ctotfactura"].ToString();
            }
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());
            //-----------------------
            _Str_Cadena = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','0','0','0','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
            //-----------------------
            _Str_Cadena = "Select ccount,ctipodocumento,cnaturaleza,cideprocesod from TPROCESOSCONTD where cidproceso='P_COMPRA'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            string _Str_Sql = "";
            bool _Bol_Boleano = false;
            DataSet _Datset = new DataSet();
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                string _Str_Descrip = "";
                //--------------------------------
                if (_Row["ccount"].ToString() == _Str_G_CuentaContProv)
                {
                    _Str_Sql = "SELECT * FROM VST_PROVECOUNT WHERE cglobal=1 AND cproveedor='" + _P_Str_Proveedor + "'";
                    _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Datset.Tables[0].Rows.Count > 0)
                    {
                        _Str_CuentaCont = Convert.ToString(_Datset.Tables[0].Rows[0]["ctcount"]).Trim();
                        _Str_CuentaContName = Convert.ToString(_Datset.Tables[0].Rows[0]["cname"]).Trim().ToUpper();
                    }
                }
                else
                {
                    _Str_CuentaCont = _Row["ccount"].ToString().Trim();
                    _Str_Sql = "Select cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _Str_CuentaCont + "'";
                    _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Datset.Tables[0].Rows.Count > 0)
                    {
                        _Str_CuentaContName = Convert.ToString(_Datset.Tables[0].Rows[0]["cname"]).Trim().ToUpper();
                    }
                }
                _Str_Cadena = "Select c_nomb_abreviado from TPROVEEDOR where (cglobal='1' OR ccompany='" + Frm_Padre._Str_Comp + "') AND cproveedor='" + _P_Str_Proveedor + "'";
                string _Str_Nom_Proveeodor = "";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                { _Str_Nom_Proveeodor = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim().ToUpper(); }
                _Str_Descrip = _Str_CuentaContName + " " + _Str_Nom_Proveeodor + " " + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + " S/F # " + _Str_cnumdocu;
                
                //--------------------------------
                string _Str_DebeoHaber = "";
                if (_Row["cideprocesod"].ToString() == "1")
                {
                    _Str_DebeoHaber = _Str_cmontosi;
                }
                else if (_Row["cideprocesod"].ToString() == "2")
                {
                    _Str_DebeoHaber = _Str_cmontoimp;
                }
                else if (_Row["cideprocesod"].ToString() == "3")
                {
                    _Str_DebeoHaber = _Str_MontoTotal;
                }
                else if (_Row["cideprocesod"].ToString() == "4")
                {
                    _Str_DebeoHaber = _Str_Descfinan;
                }
                double _Dbl_Monto = 0;
                double.TryParse(_Str_DebeoHaber, out _Dbl_Monto);
                if (_Dbl_Monto > 0)
                {
                    string _Str_corder = Convert.ToString(_Mtd_Consecutivo_TCOMPROBAND(_Str_cidcomprob));
                    if (_Row["cnaturaleza"].ToString() == "D")
                    {
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CuentaCont + "','" + _Mtd_TipoDocumentFACT_CXP("ctipdocfact") + "','" + _Str_cnumdocu + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip.Replace("'", "''") + "')";
                        _Dbl_Debe = _Dbl_Debe + Convert.ToDouble(_Str_DebeoHaber);
                    }
                    else
                    {
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CuentaCont + "','" + _Mtd_TipoDocumentFACT_CXP("ctipdocfact") + "','" + _Str_cnumdocu + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip.Replace("'", "''") + "')";
                        _Dbl_Haber = _Dbl_Haber + Convert.ToDouble(_Str_DebeoHaber);
                    }
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_CuentaCont, _P_Str_Proveedor, _Str_Descrip.Replace("'", "''"), _Mtd_TipoDocumentFACT_CXP("ctipdocfact"), _Str_cnumdocu, _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)), _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaVenc)), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)), _Str_cmontacco, _Str_cyearacco, _Row["cnaturaleza"].ToString().Trim().ToUpper());
                    _Bol_Boleano = true;
                }
            }
            if (_Bol_Boleano)
            {
                double _Dbl_cbalanceo = 0;
                if (_Dbl_Debe > _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Debe - _Dbl_Haber; }
                else if (_Dbl_Debe < _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Haber - _Dbl_Debe; }
                _Str_Sql = "UPDATE TCOMPROBANC SET ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "',cbalance='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                //_Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            }
            return Convert.ToInt32(_Str_cidcomprob);
        }
        //__________________________________________________________________________
        public int _Mtd_Proceso_P_COMPRA_INVEND(string _P_Str_cidnotrecepc, string _P_Str_cidrecepcion, double _P_Dbl_MontoInvendible, string _P_Str_Proveedor, string _P_Str_Factura)
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            string _Str_CountCont = "", _Str_CountContName="";
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cnumdocu = "";
            string _Str_cfechadocu = "";
            string _Str_cmontosi = "";
            string _Str_Descfinan = "";
            string _Str_MontoTotal = "";
            string _Str_cmontoimp = "";
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            string _Str_cidcomprobret = "";//gianqui
            string _Str_ProvNombre = "";//gianqui
            string _Str_FechaVenc = "";//gianqui
            string _Str_comprobdetid = "";//gianqui
            string _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_COMPRA_INVEND");
            string _Str_Cadena = "";
            DataSet _Ds;
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            //_Str_Cadena = "Select cnumdocu,cfechadocu,cmontosi,cmontoimp from TNOTARECEPC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotrecepc='" + _P_Str_cidnotrecepc + "' and cidrecepcion='" + _P_Str_cidrecepcion + "'";
            _Str_Cadena = "Select cnfacturapro,cdatefactura,csubtotal,ctotalimp,cdatevencimiento,ISNULL(cdescfinanmonto,0) AS cdescfinanmonto,ctotfactura from TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _P_Str_cidrecepcion + "' and cproveedor='" + _P_Str_Proveedor + "' and cnfacturapro='" + _P_Str_Factura + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_cnumdocu = _Ds.Tables[0].Rows[0]["cnfacturapro"].ToString();
                _Str_cfechadocu = _Ds.Tables[0].Rows[0]["cdatefactura"].ToString();
                _Str_cmontosi = _Ds.Tables[0].Rows[0]["csubtotal"].ToString();
                _Str_cmontoimp = _Ds.Tables[0].Rows[0]["ctotalimp"].ToString();
                _Str_FechaVenc = _Ds.Tables[0].Rows[0]["cdatevencimiento"].ToString();
                _Str_Descfinan = _Ds.Tables[0].Rows[0]["cdescfinanmonto"].ToString();
                _Str_MontoTotal = _Ds.Tables[0].Rows[0]["ctotfactura"].ToString();
            }

            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cporcenreteniva,c_nomb_abreviado from TPROVEEDOR where (ccompany='" + Frm_Padre._Str_Comp + "' or cglobal=1) and cproveedor='" + _P_Str_Proveedor + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_ProvNombre = Convert.ToString(_Ds.Tables[0].Rows[0][1]);
            }

            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());
            //-----------------------
            _Str_Cadena = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','0','0','0','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
            //-----------------------
            _Str_Cadena = "Select ccount,ctipodocumento,cnaturaleza,cideprocesod from TPROCESOSCONTD where cidproceso='P_COMPRA_INVEND'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            string _Str_Sql = "";
            bool _Bol_Boleano = false;
            DataSet _Datset = new DataSet();
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                string _Str_Descrip = "";
                //--------------------------------
                if (_Row["ccount"].ToString() == _Str_G_CuentaContProv)
                {
                    _Str_Sql = "SELECT ctcount FROM TPROVEEDOR WHERE cglobal=1 AND cproveedor='" + _P_Str_Proveedor + "'";
                    _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Datset.Tables[0].Rows.Count > 0)
                    {
                        _Str_CountCont = Convert.ToString(_Datset.Tables[0].Rows[0]["ctcount"]).Trim();
                    }
                }
                else
                {
                    _Str_CountCont = Convert.ToString(_Row["ccount"]).Trim();
                }
                _Str_Sql = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_CountCont + "'";
                _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Datset.Tables[0].Rows.Count > 0)
                {
                    _Str_CountContName = Convert.ToString(_Datset.Tables[0].Rows[0]["cname"]).Trim().ToUpper();
                }

                _Str_Cadena = "Select c_nomb_abreviado from TPROVEEDOR where (cglobal='1' OR ccompany='" + Frm_Padre._Str_Comp + "') AND cproveedor='" + _P_Str_Proveedor + "'";
                string _Str_Nom_Proveeodor = "";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                { _Str_Nom_Proveeodor = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim().ToUpper(); }
                _Str_Descrip = _Str_CountContName + " " + _Str_Nom_Proveeodor + " " + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + " S/F # " + _Str_cnumdocu;
                //--------------------------------
                string _Str_DebeoHaber = "";
                if (_Row["cideprocesod"].ToString() == "1")
                {
                    _Str_DebeoHaber = _Str_cmontosi;
                }
                else if (_Row["cideprocesod"].ToString() == "2")
                {
                    _Str_DebeoHaber = _Str_cmontoimp;
                }
                else if (_Row["cideprocesod"].ToString() == "3")
                {
                    _Str_DebeoHaber = _P_Dbl_MontoInvendible.ToString();
                }
                else if (_Row["cideprocesod"].ToString() == "4")
                {
                    _Str_DebeoHaber = _Str_MontoTotal;
                }
                else if (_Row["cideprocesod"].ToString() == "5")
                {
                    _Str_DebeoHaber = _Str_Descfinan;
                }
                double _Dbl_Monto = 0;
                double.TryParse(_Str_DebeoHaber, out _Dbl_Monto);
                if (_Dbl_Monto > 0)
                {
                    string _Str_corder = Convert.ToString(_Mtd_Consecutivo_TCOMPROBAND(_Str_cidcomprob));
                    if (_Row["cnaturaleza"].ToString() == "D")
                    {
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentFACT_CXP("ctipdocfact") + "','" + _Str_cnumdocu + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip.Replace("'", "''") + "')";
                        _Dbl_Debe = _Dbl_Debe + Convert.ToDouble(_Str_DebeoHaber);
                    }
                    else
                    {
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentFACT_CXP("ctipdocfact") + "','" + _Str_cnumdocu + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip.Replace("'", "''") + "')";
                        _Dbl_Haber = _Dbl_Haber + Convert.ToDouble(_Str_DebeoHaber);
                    }
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_CountCont, _P_Str_Proveedor, _Str_Descrip.Replace("'", "''"), _Mtd_TipoDocumentFACT_CXP("ctipdocfact"), _Str_cnumdocu, _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)), _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaVenc)), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)), _Str_cmontacco, _Str_cyearacco, _Row["cnaturaleza"].ToString().Trim().ToUpper());
                }
                
                _Bol_Boleano = true;
            }
            if (_Bol_Boleano)
            {
                double _Dbl_cbalanceo = 0;
                if (_Dbl_Debe > _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Debe - _Dbl_Haber; }
                else if (_Dbl_Debe < _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Haber - _Dbl_Debe; }
                _Str_Sql = "UPDATE TCOMPROBANC SET ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "',cbalance='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                //_Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            }
            return Convert.ToInt32(_Str_cidcomprob);
        }
        public int _Mtd_Proceso_P_CXP_ND_DESCPPP(string _P_Str_cidnotadebitocxp, string _P_Str_cproveedor)
        {

            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            double _Dbl_MontoTotal = 0;
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cnumdocu = "";
            string _Str_cporcinvendible = "";
            string _Str_cfechadocu = "";
            string _Str_cmontosi = "";
            string _Str_cmontoimp = "";
            string _Str_Nr = "";
            string _Str_cyearacco = "", _Str_cmontacco = "";
            string _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXP_ND_DCTOPP");
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            string _Str_Cadena = "";
            DataSet _Ds;
            _Str_Cadena = "Select cidnotadebitocxp,cfechand,cmontototsi,cimpuesto,cporcinvendible,cnumdocu,cidnotrecepc,ctotaldocu from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _P_Str_cproveedor + "' and cidnotadebitocxp='" + _P_Str_cidnotadebitocxp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_cnumdocu = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString();
                _Str_cfechadocu = _Ds.Tables[0].Rows[0][1].ToString();
                _Str_cmontosi = _Ds.Tables[0].Rows[0][2].ToString();
                _Str_cmontoimp = _Ds.Tables[0].Rows[0][3].ToString();
                _Str_cporcinvendible = _Ds.Tables[0].Rows[0][4].ToString();
                _Str_Nr = Convert.ToString(_Ds.Tables[0].Rows[0]["cidnotrecepc"]).Trim();
                _Dbl_MontoTotal = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
            }
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());
            string _Str_NombProveedor = "";
            _Str_Cadena = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal='1') AND cproveedor='" + _P_Str_cproveedor + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_NombProveedor = _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            string _Str_Sql = "";
            bool _Bol_Boleano = false;
            string _Str_DebeoHaber = "", _Str_corder = "", _Str_Descrip = "";
            string _Str_CountCont = "", _Str_CountContName = "";
            DataSet _Datset;
            //-----------------------
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','0','0','0','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
            //-----------------------
            _Str_Cadena = "Select ccount,ctipodocumento,cnaturaleza,cideprocesod from TPROCESOSCONTD where cidproceso='P_CXP_ND_DCTOPP'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_DebeoHaber = "";
                _Str_corder = "";

                if (_Row["cideprocesod"].ToString() == "1")
                {
                    _Str_DebeoHaber = _Dbl_MontoTotal.ToString();
                }
                else if (_Row["cideprocesod"].ToString() == "2")
                {
                    _Str_DebeoHaber = _Str_cmontosi;
                }
                else if (_Row["cideprocesod"].ToString() == "3")
                {
                    _Str_DebeoHaber = _Str_cmontoimp;
                }
                _Str_CountCont = _Row["ccount"].ToString();
                if (_Str_DebeoHaber != "")
                {
                    if (Convert.ToDouble(_Str_DebeoHaber) > 0)
                    {
                        if (_Str_CountCont != "")
                        {
                            _Str_Sql = "SELECT cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _Str_CountCont + "'";
                            _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Datset.Tables[0].Rows.Count > 0)
                            {
                                _Str_CountContName = _Datset.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
                            }
                            _Str_Descrip = _Str_CountContName + " " + _Str_NombProveedor + " SEGÚN ND # " + _P_Str_cidnotadebitocxp + " POR DSCTO P/P  S/F# " + _Str_cnumdocu;
                        }
                        else
                        {
                            _Str_Descrip = "PROVEEDOR SIN CUENTA CONTABLE." + " " + _Str_NombProveedor + " SEGÚN ND # " + _P_Str_cidnotadebitocxp + " POR DSCTO P/P  S/F# " + _Str_cnumdocu;
                        }

                        _Str_corder = Convert.ToString(_Mtd_Consecutivo_TCOMPROBAND(_Str_cidcomprob));
                        if (_Row["cnaturaleza"].ToString() == "D")
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(false) + "','" + _P_Str_cidnotadebitocxp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                            _Dbl_Debe = _Dbl_Debe + Convert.ToDouble(_Str_DebeoHaber);
                        }
                        else
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(false) + "','" + _P_Str_cidnotadebitocxp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                            _Dbl_Haber = _Dbl_Haber + Convert.ToDouble(_Str_DebeoHaber);
                        }
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_CountCont, _P_Str_cproveedor, _Str_Descrip, _Mtd_TipoDocumentNC_ND(false), _P_Str_cidnotadebitocxp, _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)), _Str_cmontacco, _Str_cyearacco, _Row["cnaturaleza"].ToString().Trim().ToUpper());
                    }
                }
                _Bol_Boleano = true;
            }
            if (_Bol_Boleano)
            {
                double _Dbl_cbalanceo = 0;
                if (_Dbl_Debe > _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Debe - _Dbl_Haber; }
                else if (_Dbl_Debe < _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Haber - _Dbl_Debe; }
                _Str_Sql = "UPDATE TCOMPROBANC SET ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "',cbalance='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "',cstatus='1' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            return Convert.ToInt32(_Str_cidcomprob);
        }
        public double _Mtd_ObtenerMontoNCxFact(string _Pr_Str_ProvId, string _Pr_Str_TpoDoc, string _Pr_Str_NumDoc)
        {
            string _Str_Sql = "";
            double _Dbl_Monto = 0;
            _Str_Sql = "select sum(ctotaldocu) from TNOTACREDICP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _Pr_Str_ProvId + "' and ctipodocument='" + _Pr_Str_TpoDoc + "' and cnumdocu='" + _Pr_Str_NumDoc + "' and cdelete=0 and canulado=0 and cimpresa=1";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                {
                    _Dbl_Monto = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                }
            }
            return _Dbl_Monto;
        }

        public double _Mtd_ObtenerMontoNDxFact(string _Pr_Str_ProvId, string _Pr_Str_TpoDoc, string _Pr_Str_NumDoc)
        {
            string _Str_Sql = "";
            double _Dbl_Monto = 0;
            _Str_Sql = "select sum(ctotaldocu) from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _Pr_Str_ProvId + "' and ctipodocument='" + _Pr_Str_TpoDoc + "' and cnumdocu='" + _Pr_Str_NumDoc + "' and cdelete=0 and canulado=0 and cimpresa=1";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                {
                    _Dbl_Monto = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                }
            }
            return _Dbl_Monto;
        }

        public double _Mtd_ObtenerMontoRETIVAxFact(string _Pr_Str_ProvId, string _Pr_Str_NumDoc)
        {
            string _Str_Sql = "";
            double _Dbl_Monto = 0;
            _Str_Sql = "select sum(cretenido) from TCOMPROBANRETC where ccompany='" + Frm_Padre._Str_Comp + "' and cnumdocumafec='" + _Pr_Str_NumDoc + "' and cimpreso=1 and canulado=0 and cproveedor='" + _Pr_Str_ProvId + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                {
                    _Dbl_Monto = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                }
            }
            return _Dbl_Monto;
        }

        public double _Mtd_ObtenerMontoRETISLRxFact(string _Pr_Str_ProvId, string _Pr_Str_NumDoc)
        {
            string _Str_Sql = "";
            double _Dbl_Monto = 0;
            _Str_Sql = "select sum(ctotretenido) from TCOMPROBANISLRC where ccompany='" + Frm_Padre._Str_Comp + "' and cnumdocumafec='" + _Pr_Str_NumDoc + "' and cimpreso=1 and canulado=0 and cproveedor='" + _Pr_Str_ProvId + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                {
                    _Dbl_Monto = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                }
            }
            return _Dbl_Monto;
        }
        public int _Mtd_Proceso_P_COMP_DEVOLUCION(string _P_Str_cidnotadebitocxp, string _P_Str_cproveedor)
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            string _Str_CountCont = "";
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cnumdocu = "";
            string _Str_cfechadocu = "";
            string _Str_cmontosi = "";
            string _Str_cmontoimp = "";
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            string _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXP_ND_DEVOLUCION");
            string _Str_Cadena = "";
            DataSet _Ds;
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;

            _Str_Cadena = "Select cidnotadebitocxp,cfechand,cmontototsi,cimpuesto from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _P_Str_cproveedor + "' and cidnotadebitocxp='" + _P_Str_cidnotadebitocxp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_cnumdocu = _Ds.Tables[0].Rows[0][0].ToString();
                _Str_cfechadocu = _Ds.Tables[0].Rows[0][1].ToString();
                _Str_cmontosi = _Ds.Tables[0].Rows[0][2].ToString();
                _Str_cmontoimp = _Ds.Tables[0].Rows[0][3].ToString();
            }
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());
            //-----------------------
            _Str_Cadena = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','0','0','0','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
            //-----------------------
            _Str_Cadena = "Select ccount,ctipodocumento,cnaturaleza,cideprocesod from TPROCESOSCONTD where cidproceso='P_CXP_ND_DEVOLUCION'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            string _Str_Sql = "";
            bool _Bol_Boleano = false;
            DataSet _Datset = new DataSet();
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                string _Str_Descrip = "";
                _Str_CountCont = _Row["ccount"].ToString().Trim();
                if (_Str_CountCont.Length > 0)
                {
                    _Str_Sql = "Select cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _Row["ccount"].ToString() + "'";
                    _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Datset.Tables[0].Rows.Count > 0)
                    {
                        _Str_Descrip = _Datset.Tables[0].Rows[0]["cname"].ToString().Trim().ToUpper();
                    }
                }
                else
                {
                    _Str_Descrip = "CUENTA NO REGISTRADA.";
                }
                //--------------------------------
                string _Str_DebeoHaber = "";
                if (_Row["cideprocesod"].ToString() == "1")
                {
                    _Str_DebeoHaber = Convert.ToString(Convert.ToDouble(_Str_cmontosi) + Convert.ToDouble(_Str_cmontoimp));
                }
                else if (_Row["cideprocesod"].ToString() == "2")
                {
                    _Str_DebeoHaber = _Str_cmontosi;
                }
                else if (_Row["cideprocesod"].ToString() == "3")
                {
                    _Str_DebeoHaber = _Str_cmontoimp;
                }

                string _Str_corder = Convert.ToString(_Mtd_Consecutivo_TCOMPROBAND(_Str_cidcomprob));
                if (_Row["cnaturaleza"].ToString() == "D")
                {
                    _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(false) + "','" + _P_Str_cidnotadebitocxp + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                    _Dbl_Debe = _Dbl_Debe + Convert.ToDouble(_Str_DebeoHaber);
                }
                else
                {
                    _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(false) + "','" + _P_Str_cidnotadebitocxp + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                    _Dbl_Haber = _Dbl_Haber + Convert.ToDouble(_Str_DebeoHaber);
                }
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_CountCont, _P_Str_cproveedor, _Str_Descrip, _Mtd_TipoDocumentNC_ND(false), _P_Str_cidnotadebitocxp, _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)), _Str_cmontacco, _Str_cyearacco, _Row["cnaturaleza"].ToString().Trim().ToUpper());
                _Bol_Boleano = true;
            }
            if (_Bol_Boleano)
            {
                double _Dbl_cbalanceo = 0;
                if (_Dbl_Debe > _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Debe - _Dbl_Haber; }
                else if (_Dbl_Debe < _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Haber - _Dbl_Debe; }
                _Str_Sql = "UPDATE TCOMPROBANC SET ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "',cbalance='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                //_Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            } return Convert.ToInt32(_Str_cidcomprob);
        }
        //____________________________________________________________________________________
        //__________________________________________________________________________
        public int _Mtd_Proceso_P_CXP_NC_SOBRANTE(string _P_Str_cidnotacreditocxp, string _P_Str_cproveedor)
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            double _Dbl_MontoTotal = 0;
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cnumdocu = "";
            string _Str_cporcinvendible = "";
            string _Str_cfechadocu = "";
            string _Str_cmontosi = "";
            string _Str_cmontoimp = "";
            string _Str_cyearacco = "", _Str_cmontacco = "";
            string _Str_Nr = "";
            string _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            decimal _Dcm_cdescfinanmonto = 0;
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXP_NC_SOBRANTE");
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            string _Str_Cadena = "";
            DataSet _Ds;
            _Str_Cadena = "Select cidnotacreditocxp,cfechanc,ISNULL(cmontototsi,0)+ISNULL(cbaseexcenta,0) AS cmontototsi,cimpuesto,cporcinvendible,cnumdocu,cidnotrecepc,ctotaldocu,cdescfinanmonto from TNOTACREDICP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _P_Str_cproveedor + "' and cidnotacreditocxp='" + _P_Str_cidnotacreditocxp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_cnumdocu = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString();
                _Str_cfechadocu = _Ds.Tables[0].Rows[0][1].ToString();
                _Str_cmontosi = _Ds.Tables[0].Rows[0][2].ToString();
                _Str_cmontoimp = _Ds.Tables[0].Rows[0][3].ToString();
                _Str_cporcinvendible = _Ds.Tables[0].Rows[0][4].ToString();
                _Str_Nr = Convert.ToString(_Ds.Tables[0].Rows[0]["cidnotrecepc"]).Trim();
                _Dbl_MontoTotal = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                if (_Ds.Tables[0].Rows[0]["cdescfinanmonto"].ToString() != "")
                    _Dcm_cdescfinanmonto = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cdescfinanmonto"]);
            }
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());
            string _Str_Sql = "";
            bool _Bol_Boleano = false;
            string _Str_DebeoHaber = "", _Str_corder = "", _Str_Descrip = "";
            string _Str_CountCont = "", _Str_CountContName = "";
            DataSet _Datset;
            //-----------------------
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','0','0','0','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
            //-----------------------
            _Str_Cadena = "Select ccount,ctipodocumento,cnaturaleza,cideprocesod from TPROCESOSCONTD where cidproceso='P_CXP_NC_SOBRANTE'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_DebeoHaber = "";
                _Str_corder = "";
                if (_Row["cideprocesod"].ToString() == "1")
                {
                    _Str_DebeoHaber = _Str_cmontosi;
                }
                else if (_Row["cideprocesod"].ToString() == "2")
                {
                    _Str_DebeoHaber = _Str_cmontoimp;
                }
                else if (_Row["cideprocesod"].ToString() == "3")
                {
                    _Str_DebeoHaber = _Str_cporcinvendible;
                }
                else if (_Row["cideprocesod"].ToString() == "4")
                {
                    _Str_DebeoHaber = _Dbl_MontoTotal.ToString();
                }
                else if (_Row["cideprocesod"].ToString() == "5")
                {
                    _Str_DebeoHaber = _Dcm_cdescfinanmonto.ToString();
                }
                _Str_CountCont = _Row["ccount"].ToString();

                if (_Str_DebeoHaber != "")
                {
                    if (Convert.ToDouble(_Str_DebeoHaber) > 0)
                    {
                        if (_Str_CountCont != "")
                        {
                            _Str_Sql = "SELECT cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _Str_CountCont + "'";
                            _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Datset.Tables[0].Rows.Count > 0)
                            {
                                _Str_CountContName = _Datset.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
                            }
                            _Str_Descrip = _Str_CountContName + " SEGÚN NC # " + _P_Str_cidnotacreditocxp + " POR SOBRANTE, DE LA FACTURA # " + _Str_cnumdocu + ", SEGÚN NR # " + _Str_Nr;
                        }
                        else
                        {
                            _Str_Descrip = "PROVEEDOR SIN CUENTA CONTABLE. SEGÚN NC # " + _P_Str_cidnotacreditocxp + " POR SOBRANTE, DE LA FACTURA # " + _Str_cnumdocu + ", SEGÚN NR # " + _Str_Nr;
                        }

                        _Str_corder = Convert.ToString(_Mtd_Consecutivo_TCOMPROBAND(_Str_cidcomprob));
                        if (_Row["cnaturaleza"].ToString() == "D")
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(true) + "','" + _P_Str_cidnotacreditocxp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                            _Dbl_Debe = _Dbl_Debe + Convert.ToDouble(_Str_DebeoHaber);
                        }
                        else
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(true) + "','" + _P_Str_cidnotacreditocxp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                            _Dbl_Haber = _Dbl_Haber + Convert.ToDouble(_Str_DebeoHaber);
                        }
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_CountCont, _P_Str_cproveedor, _Str_Descrip, _Mtd_TipoDocumentNC_ND(true), _P_Str_cidnotacreditocxp, _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)), _Str_cmontacco, _Str_cyearacco, _Row["cnaturaleza"].ToString().Trim().ToUpper());
                    }
                }
                _Bol_Boleano = true;
            }
            if (_Bol_Boleano)
            {
                double _Dbl_cbalanceo = 0;
                if (_Dbl_Debe > _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Debe - _Dbl_Haber; }
                else if (_Dbl_Debe < _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Haber - _Dbl_Debe; }
                _Str_Sql = "UPDATE TCOMPROBANC SET ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "',cbalance='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                //_Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            }
            return Convert.ToInt32(_Str_cidcomprob);
        }
        //____________________________________________________________________________________
        public int _Mtd_Proceso_P_CXP_NC_DIFPRECIO(string _P_Str_cidnotacreditocxp, string _P_Str_cproveedor)
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            double _Dbl_MontoTotal = 0;
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cnumdocu = "";
            string _Str_cporcinvendible = "";
            string _Str_cfechadocu = "";
            string _Str_cmontosi = "";
            string _Str_cmontoimp = "";
            decimal _Dcm_cdescfinanmonto = 0;
            string _Str_Nr = "";
            string _Str_cyearacco = "", _Str_cmontacco = "";
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXP_NC_DIFPRECIO");
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            string _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            string _Str_Cadena = "";
            DataSet _Ds;
            _Str_Cadena = "Select cidnotacreditocxp,cfechanc,ISNULL(cmontototsi,0)+ISNULL(cbaseexcenta,0) AS cmontototsi,cimpuesto,cporcinvendible,cnumdocu,cidnotrecepc,ctotaldocu,cdescfinanmonto from TNOTACREDICP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _P_Str_cproveedor + "' and cidnotacreditocxp='" + _P_Str_cidnotacreditocxp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_cnumdocu = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString();
                _Str_cfechadocu = _Ds.Tables[0].Rows[0][1].ToString();
                _Str_cmontosi = _Ds.Tables[0].Rows[0][2].ToString();
                _Str_cmontoimp = _Ds.Tables[0].Rows[0][3].ToString();
                _Str_cporcinvendible = _Ds.Tables[0].Rows[0][4].ToString();
                _Str_Nr = Convert.ToString(_Ds.Tables[0].Rows[0]["cidnotrecepc"]).Trim();
                _Dbl_MontoTotal = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                if (_Ds.Tables[0].Rows[0]["cdescfinanmonto"].ToString() != "")
                    _Dcm_cdescfinanmonto = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cdescfinanmonto"]);
            }
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());
            
            string _Str_Sql = "";
            bool _Bol_Boleano = false;
            string _Str_DebeoHaber = "", _Str_corder = "", _Str_Descrip = "";
            string _Str_CountCont = "", _Str_CountContName = "";
            DataSet _Datset;
            //-----------------------
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','0','0','0','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
            //-----------------------
            _Str_Cadena = "Select ccount,ctipodocumento,cnaturaleza,cideprocesod from TPROCESOSCONTD where cidproceso='P_CXP_NC_DIFPRECIO'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_DebeoHaber = "";
                _Str_corder = "";
                if (_Row["cideprocesod"].ToString() == "1")
                {
                    _Str_DebeoHaber = _Str_cmontosi;

                }
                else if (_Row["cideprocesod"].ToString() == "2")
                {
                    _Str_DebeoHaber = _Str_cporcinvendible;
                    
                }
                else if (_Row["cideprocesod"].ToString() == "3")
                {
                    _Str_DebeoHaber = _Str_cmontoimp;
                    
                }
                else if (_Row["cideprocesod"].ToString() == "4")
                {
                    _Str_DebeoHaber = _Dbl_MontoTotal.ToString();
                }
                else if (_Row["cideprocesod"].ToString() == "5")
                {
                    _Str_DebeoHaber = _Dcm_cdescfinanmonto.ToString();
                }
                _Str_CountCont = _Row["ccount"].ToString();

                if (_Str_DebeoHaber != "")
                {
                    if (Convert.ToDouble(_Str_DebeoHaber) > 0)
                    {
                        if (_Str_CountCont != "")
                        {
                            _Str_Sql = "SELECT cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _Str_CountCont + "'";
                            _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Datset.Tables[0].Rows.Count > 0)
                            {
                                _Str_CountContName = _Datset.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
                            }
                            _Str_Descrip = _Str_CountContName + " SEGÚN NC # " + _P_Str_cidnotacreditocxp + " POR DIFERENCIA DE PRECIO, DE LA FACTURA # " + _Str_cnumdocu + ", SEGÚN NR # " + _Str_Nr;
                        }
                        else
                        {
                            _Str_Descrip = "PROVEEDOR SIN CUENTA CONTABLE. SEGÚN NC # " + _P_Str_cidnotacreditocxp + " POR DIFERENCIA DE PRECIO, DE LA FACTURA # " + _Str_cnumdocu + ", SEGÚN NR # " + _Str_Nr;
                        }

                        _Str_corder = Convert.ToString(_Mtd_Consecutivo_TCOMPROBAND(_Str_cidcomprob));
                        if (_Row["cnaturaleza"].ToString() == "D")
                        {
                            _Dbl_Debe = _Dbl_Debe + Convert.ToDouble(_Str_DebeoHaber);
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(true) + "','" + _P_Str_cidnotacreditocxp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                        }
                        else
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(true) + "','" + _P_Str_cidnotacreditocxp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                            _Dbl_Haber = _Dbl_Haber + Convert.ToDouble(_Str_DebeoHaber);
                        }
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_CountCont, _P_Str_cproveedor, _Str_Descrip, _Mtd_TipoDocumentNC_ND(true), _P_Str_cidnotacreditocxp, _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)), _Str_cmontacco, _Str_cyearacco, _Row["cnaturaleza"].ToString().Trim().ToUpper());
                    }
                }
                
                _Bol_Boleano = true;
            }
            if (_Bol_Boleano)
            {
                double _Dbl_cbalanceo = 0;
                if (_Dbl_Debe > _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Debe - _Dbl_Haber; }
                else if (_Dbl_Debe < _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Haber - _Dbl_Debe; }
                _Str_Sql = "UPDATE TCOMPROBANC SET ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "',cbalance='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                //_Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            }
            return Convert.ToInt32(_Str_cidcomprob);
        }
        private bool _Mtd_CuentaExistente(string _P_Str_Cuenta)
        {
            string _Str_Cadena = "Select ctcount from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _P_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            { return false; }
            return true;
        }
        public int _Mtd_Proceso_P_CXP_NC_MANUAL(string _P_Str_cidnotacreditocxp, string _P_Str_cproveedor, string _P_Str_Proceso, string _P_Str_Descripcion, string _P_Str_CuentaOtros)
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            double _Dbl_MontoTotal = 0;
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cnumdocu = "";
            string _Str_cporcinvendible = "";
            string _Str_cfechadocu = "";
            string _Str_cmontosi = "";
            string _Str_cmontoimp = "";
            decimal _Dcm_cdescfinanmonto = 0;
            string _Str_Nr = "";
            string _Str_cyearacco = "", _Str_cmontacco = "";
            string _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont(_P_Str_Proceso.Trim());
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            string _Str_NombProveedor = "";
            string _Str_Cadena = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal='1') AND cproveedor='" + _P_Str_cproveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_NombProveedor = _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            _Str_Cadena = "Select cidnotacreditocxp,cfechanc,ISNULL(cmontototsi,0)+ISNULL(cbaseexcenta,0) AS cmontototsi,cimpuesto,cporcinvendible,cnumdocu,cidnotrecepc,ctotaldocu,cdescfinanmonto  FROM TNOTACREDICP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _P_Str_cproveedor + "' and cidnotacreditocxp='" + _P_Str_cidnotacreditocxp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_cnumdocu = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString();
                _Str_cfechadocu = _Ds.Tables[0].Rows[0][1].ToString();
                _Str_cmontosi = _Ds.Tables[0].Rows[0][2].ToString();
                _Str_cmontoimp = _Ds.Tables[0].Rows[0][3].ToString();
                _Str_cporcinvendible = _Ds.Tables[0].Rows[0][4].ToString();
                if (_Str_cporcinvendible.Trim().Length == 0)
                { _Str_cporcinvendible = "0"; }
                _Str_Nr = Convert.ToString(_Ds.Tables[0].Rows[0]["cidnotrecepc"]).Trim();
                _Dbl_MontoTotal = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                if (_Ds.Tables[0].Rows[0]["cdescfinanmonto"].ToString() != "")
                    _Dcm_cdescfinanmonto = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cdescfinanmonto"]);
            }
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());

            string _Str_Sql = "";
            bool _Bol_Boleano = false;
            string _Str_DebeoHaber = "", _Str_corder = "", _Str_Descrip = "";
            string _Str_CountCont = "", _Str_CountContName = "";
            DataSet _Datset;
            //-----------------------
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','0','0','0','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
            //-----------------------
            _Str_Cadena = "Select ccount,ctipodocumento,cnaturaleza,cideprocesod from TPROCESOSCONTD where cidproceso='" + _P_Str_Proceso.Trim() + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_DebeoHaber = "";
                _Str_corder = "";
                if (_Row["cideprocesod"].ToString() == "1")
                {
                    _Str_DebeoHaber = _Str_cmontosi;
                }
                else if (_Row["cideprocesod"].ToString() == "2")
                {
                    _Str_DebeoHaber = _Str_cmontoimp;
                }
                else if (_Row["cideprocesod"].ToString() == "3")
                {
                    _Str_DebeoHaber = Convert.ToString(_Dbl_MontoTotal);
                }
                else if (_Row["cideprocesod"].ToString() == "4")
                {
                    _Str_DebeoHaber = _Str_cporcinvendible;
                }
                else if (_Row["cideprocesod"].ToString() == "5")
                {
                    _Str_DebeoHaber = _Dcm_cdescfinanmonto.ToString();
                }
                if (_Mtd_CuentaExistente(_Row["ccount"].ToString()))
                { _Str_CountCont = _Row["ccount"].ToString(); }
                else
                { _Str_CountCont = _P_Str_CuentaOtros; }
                if (_Str_DebeoHaber != "")
                {
                    if (Convert.ToDouble(_Str_DebeoHaber) > 0)
                    {
                        if (_Str_CountCont != "")
                        {
                            _Str_Sql = "SELECT cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _Str_CountCont + "'";
                            _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Datset.Tables[0].Rows.Count > 0)
                            { _Str_CountContName = _Datset.Tables[0].Rows[0][0].ToString().Trim().ToUpper(); }
                            _Str_Descrip = _Str_CountContName + " " + _Str_NombProveedor + " SEGÚN NC # " + _P_Str_cidnotacreditocxp + " POR " + _P_Str_Descripcion.ToUpper() + ", DE LA FACTURA # " + _Str_cnumdocu;
                        }
                        else
                        {
                            _Str_Descrip = "PROVEEDOR SIN CUENTA CONTABLE. " + _Str_NombProveedor + " SEGÚN NC # " + _P_Str_cidnotacreditocxp + " POR " + _P_Str_Descripcion.ToUpper() + ", DE LA FACTURA # " + _Str_cnumdocu;
                        }

                        _Str_corder = Convert.ToString(_Mtd_Consecutivo_TCOMPROBAND(_Str_cidcomprob));
                        if (_Row["cnaturaleza"].ToString() == "D")
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(true) + "','" + _P_Str_cidnotacreditocxp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                            _Dbl_Debe = _Dbl_Debe + Convert.ToDouble(_Str_DebeoHaber);
                        }
                        else
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(true) + "','" + _P_Str_cidnotacreditocxp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                            _Dbl_Haber = _Dbl_Haber + Convert.ToDouble(_Str_DebeoHaber);
                        }
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_CountCont, _P_Str_cproveedor, _Str_Descrip, _Mtd_TipoDocumentNC_ND(true), _P_Str_cidnotacreditocxp, _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)), _Str_cmontacco, _Str_cyearacco, _Row["cnaturaleza"].ToString().Trim().ToUpper());
                    }
                }
                _Bol_Boleano = true;
            }
            if (_Bol_Boleano)
            {
                double _Dbl_cbalanceo = 0;
                if (_Dbl_Debe > _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Debe - _Dbl_Haber; }
                else if (_Dbl_Debe < _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Haber - _Dbl_Debe; }
                _Str_Sql = "UPDATE TCOMPROBANC SET ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "',cbalance='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                //_Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            }
            return Convert.ToInt32(_Str_cidcomprob);
        }
        //__________________________________________________________________________
        public int _Mtd_Proceso_P_CXP_NC_MANUAL(string _P_Str_cidnotacreditocxp, string _P_Str_cproveedor, string _P_Str_Proceso, string _P_Str_Descripcion, int _P_Int_Comprobant, string _P_Str_CuentaOtros)
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            double _Dbl_MontoTotal = 0;
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cnumdocu = "";
            string _Str_cporcinvendible = "";
            string _Str_cfechadocu = "";
            string _Str_cmontosi = "";
            string _Str_cmontoimp = "";
            decimal _Dcm_cdescfinanmonto = 0;
            string _Str_Nr = "";
            string _Str_cyearacco = "", _Str_cmontacco = "";
            string _Str_cidcomprob = _P_Int_Comprobant.ToString();
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont(_P_Str_Proceso.Trim());
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            string _Str_NombProveedor = "";
            string _Str_Cadena = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal='1') AND cproveedor='" + _P_Str_cproveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_NombProveedor = _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            _Str_Cadena = "Select cidnotacreditocxp,cfechanc,ISNULL(cmontototsi,0)+ISNULL(cbaseexcenta,0) AS cmontototsi,cimpuesto,cporcinvendible,cnumdocu,cidnotrecepc,ctotaldocu,cdescfinanmonto FROM TNOTACREDICP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _P_Str_cproveedor + "' and cidnotacreditocxp='" + _P_Str_cidnotacreditocxp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_cnumdocu = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString();
                _Str_cfechadocu = _Ds.Tables[0].Rows[0][1].ToString();
                _Str_cmontosi = _Ds.Tables[0].Rows[0][2].ToString();
                _Str_cmontoimp = _Ds.Tables[0].Rows[0][3].ToString();
                _Str_cporcinvendible = _Ds.Tables[0].Rows[0][4].ToString();
                if (_Str_cporcinvendible.Trim().Length == 0)
                { _Str_cporcinvendible = "0"; }
                _Str_Nr = Convert.ToString(_Ds.Tables[0].Rows[0]["cidnotrecepc"]).Trim();
                _Dbl_MontoTotal = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                if (_Ds.Tables[0].Rows[0]["cdescfinanmonto"].ToString() != "")
                    _Dcm_cdescfinanmonto = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cdescfinanmonto"]);
            }
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());

            string _Str_Sql = "";
            bool _Bol_Boleano = false;
            string _Str_DebeoHaber = "", _Str_corder = "", _Str_Descrip = "";
            string _Str_CountCont = "", _Str_CountContName = "";
            DataSet _Datset;
            _Str_Cadena = "DELETE FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "DELETE FROM TCOMPROBANDD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "DELETE FROM TMOVAUXILIARCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "Select ccount,ctipodocumento,cnaturaleza,cideprocesod from TPROCESOSCONTD where cidproceso='" + _P_Str_Proceso.Trim() + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_DebeoHaber = "";
                _Str_corder = "";
                if (_Row["cideprocesod"].ToString() == "1")
                {
                    _Str_DebeoHaber = _Str_cmontosi;
                }
                else if (_Row["cideprocesod"].ToString() == "2")
                {
                    _Str_DebeoHaber = _Str_cmontoimp;
                }
                else if (_Row["cideprocesod"].ToString() == "3")
                {
                    _Str_DebeoHaber = Convert.ToString(_Dbl_MontoTotal);
                }
                else if (_Row["cideprocesod"].ToString() == "4")
                {
                    _Str_DebeoHaber = _Str_cporcinvendible;
                }
                else if (_Row["cideprocesod"].ToString() == "5")
                {
                    _Str_DebeoHaber = _Dcm_cdescfinanmonto.ToString();
                }
                if (_Mtd_CuentaExistente(_Row["ccount"].ToString()))
                { _Str_CountCont = _Row["ccount"].ToString(); }
                else
                { _Str_CountCont = _P_Str_CuentaOtros; }
                if (_Str_DebeoHaber != "")
                {
                    if (Convert.ToDouble(_Str_DebeoHaber) > 0)
                    {
                        if (_Str_CountCont != "")
                        {
                            _Str_Sql = "SELECT cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _Str_CountCont + "'";
                            _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Datset.Tables[0].Rows.Count > 0)
                            {
                                _Str_CountContName = _Datset.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
                            }
                            _Str_Descrip = _Str_CountContName + " " + _Str_NombProveedor + " SEGÚN NC # " + _P_Str_cidnotacreditocxp + " POR " + _P_Str_Descripcion.ToUpper() + ", DE LA FACTURA # " + _Str_cnumdocu;
                        }
                        else
                        {
                            _Str_Descrip = "PROVEEDOR SIN CUENTA CONTABLE. " + _Str_NombProveedor + " SEGÚN NC # " + _P_Str_cidnotacreditocxp + " POR " + _P_Str_Descripcion.ToUpper() + ", DE LA FACTURA # " + _Str_cnumdocu;
                        }

                        _Str_corder = Convert.ToString(_Mtd_Consecutivo_TCOMPROBAND(_Str_cidcomprob));
                        if (_Row["cnaturaleza"].ToString() == "D")
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(true) + "','" + _P_Str_cidnotacreditocxp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                            _Dbl_Debe = _Dbl_Debe + Convert.ToDouble(_Str_DebeoHaber);
                        }
                        else
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(true) + "','" + _P_Str_cidnotacreditocxp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                            _Dbl_Haber = _Dbl_Haber + Convert.ToDouble(_Str_DebeoHaber);
                        }
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_CountCont, _P_Str_cproveedor, _Str_Descrip, _Mtd_TipoDocumentNC_ND(true), _P_Str_cidnotacreditocxp, _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)), _Str_cmontacco, _Str_cyearacco, _Row["cnaturaleza"].ToString().Trim().ToUpper());
                    }
                }
                _Bol_Boleano = true;
            }
            if (_Bol_Boleano)
            {
                double _Dbl_cbalanceo = 0;
                if (_Dbl_Debe > _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Debe - _Dbl_Haber; }
                else if (_Dbl_Debe < _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Haber - _Dbl_Debe; }
                _Str_Sql = "UPDATE TCOMPROBANC SET ctypcomp='" + _Str_ctypcompro + "',cname='" + _Str_cconceptocomp.ToUpper() + "',cyearacco='" + _Str_cyearacco + "',cmontacco='" + _Str_cmontacco + "',cregdate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "',cbalance='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "',cdateadd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuseradd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            return Convert.ToInt32(_Str_cidcomprob);
        }
        //__________________________________________________________________________
        public int _Mtd_Proceso_P_CXP_ND_MANUAL(string _P_Str_cidnotadebitocxp, string _P_Str_cproveedor,string _P_Str_Proceso,string _P_Str_Descripcion,string _P_Str_CuentaOtros)
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            double _Dbl_MontoTotal = 0;
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cnumdocu = "";
            string _Str_cporcinvendible = "";
            string _Str_cfechadocu = "";
            string _Str_cmontosi = "";
            string _Str_cmontoimp = "";
            decimal _Dcm_cdescfinanmonto = 0;
            string _Str_Nr = "";
            string _Str_cyearacco = "", _Str_cmontacco = "";
            string _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont(_P_Str_Proceso.Trim());
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            string _Str_NombProveedor = "";
            string _Str_Cadena = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal='1') AND cproveedor='" + _P_Str_cproveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_NombProveedor = _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            _Str_Cadena = "Select cidnotadebitocxp,cfechand,ISNULL(cmontototsi,0)+ISNULL(cbaseexcenta,0) AS cmontototsi,cimpuesto,cporcinvendible,cnumdocu,cidnotrecepc,ctotaldocu,cdescfinanmonto FROM TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _P_Str_cproveedor + "' and cidnotadebitocxp='" + _P_Str_cidnotadebitocxp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_cnumdocu = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString();
                _Str_cfechadocu = _Ds.Tables[0].Rows[0][1].ToString();
                _Str_cmontosi = _Ds.Tables[0].Rows[0][2].ToString();
                _Str_cmontoimp = _Ds.Tables[0].Rows[0][3].ToString();
                _Str_cporcinvendible = _Ds.Tables[0].Rows[0][4].ToString();
                if (_Str_cporcinvendible.Trim().Length == 0)
                { _Str_cporcinvendible = "0"; }
                _Str_Nr = Convert.ToString(_Ds.Tables[0].Rows[0]["cidnotrecepc"]).Trim();
                _Dbl_MontoTotal = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                if (_Ds.Tables[0].Rows[0]["cdescfinanmonto"].ToString() != "")
                    _Dcm_cdescfinanmonto = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cdescfinanmonto"]);
            }
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());

            string _Str_Sql = "";
            bool _Bol_Boleano = false;
            string _Str_DebeoHaber = "", _Str_corder = "", _Str_Descrip = "";
            string _Str_CountCont = "", _Str_CountContName = "";
            DataSet _Datset;
            //-----------------------
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','0','0','0','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
            //-----------------------
            _Str_Cadena = "Select ccount,ctipodocumento,cnaturaleza,cideprocesod from TPROCESOSCONTD where cidproceso='" + _P_Str_Proceso.Trim() + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_DebeoHaber = "";
                _Str_corder = "";
                if (_Row["cideprocesod"].ToString() == "1")
                {
                    _Str_DebeoHaber = Convert.ToString(_Dbl_MontoTotal);
                }
                else if (_Row["cideprocesod"].ToString() == "2")
                {
                    _Str_DebeoHaber = _Str_cmontosi;
                }
                else if (_Row["cideprocesod"].ToString() == "3")
                {
                    _Str_DebeoHaber = _Str_cmontoimp;
                }
                else if (_Row["cideprocesod"].ToString() == "4")
                {
                    _Str_DebeoHaber = _Str_cporcinvendible;
                }
                else if (_Row["cideprocesod"].ToString() == "5")
                {
                    _Str_DebeoHaber = _Dcm_cdescfinanmonto.ToString();
                }
                if (_Mtd_CuentaExistente(_Row["ccount"].ToString()))
                { _Str_CountCont = _Row["ccount"].ToString(); }
                else
                { _Str_CountCont = _P_Str_CuentaOtros; }
                if (_Str_DebeoHaber != "")
                {
                    if (Convert.ToDouble(_Str_DebeoHaber) > 0)
                    {
                        if (_Str_CountCont != "")
                        {
                            _Str_Sql = "SELECT cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _Str_CountCont + "'";
                            _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Datset.Tables[0].Rows.Count > 0)
                            { _Str_CountContName = _Datset.Tables[0].Rows[0][0].ToString().Trim().ToUpper(); }
                            _Str_Descrip = _Str_CountContName + " " + _Str_NombProveedor + " SEGÚN ND # " + _P_Str_cidnotadebitocxp + " POR " + _P_Str_Descripcion.ToUpper() + ", DE LA FACTURA # " + _Str_cnumdocu;
                        }
                        else
                        {
                            _Str_Descrip = "PROVEEDOR SIN CUENTA CONTABLE. " + _Str_NombProveedor + " SEGÚN ND # " + _P_Str_cidnotadebitocxp + " POR " + _P_Str_Descripcion.ToUpper() + ", DE LA FACTURA # " + _Str_cnumdocu;
                        }

                        _Str_corder = Convert.ToString(_Mtd_Consecutivo_TCOMPROBAND(_Str_cidcomprob));
                        if (_Row["cnaturaleza"].ToString() == "D")
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(false) + "','" + _P_Str_cidnotadebitocxp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                            _Dbl_Debe = _Dbl_Debe + Convert.ToDouble(_Str_DebeoHaber);
                        }
                        else
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(false) + "','" + _P_Str_cidnotadebitocxp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                            _Dbl_Haber = _Dbl_Haber + Convert.ToDouble(_Str_DebeoHaber);
                        }
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_CountCont, _P_Str_cproveedor, _Str_Descrip, _Mtd_TipoDocumentNC_ND(false), _P_Str_cidnotadebitocxp, _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)), _Str_cmontacco, _Str_cyearacco, _Row["cnaturaleza"].ToString().Trim().ToUpper());
                    }
                }
                _Bol_Boleano = true;
            }
            if (_Bol_Boleano)
            {
                double _Dbl_cbalanceo = 0;
                if (_Dbl_Debe > _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Debe - _Dbl_Haber; }
                else if (_Dbl_Debe < _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Haber - _Dbl_Debe; }
                _Str_Sql = "UPDATE TCOMPROBANC SET ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "',cbalance='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                //_Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            }
            return Convert.ToInt32(_Str_cidcomprob);
        }
        //__________________________________________________________________________
        public int _Mtd_Proceso_P_CXP_ND_MANUAL(string _P_Str_cidnotadebitocxp, string _P_Str_cproveedor, string _P_Str_Proceso, string _P_Str_Descripcion, int _P_Int_Comprobant,string _P_Str_CuentaOtros)
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            double _Dbl_MontoTotal = 0;
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cnumdocu = "";
            string _Str_cporcinvendible = "";
            string _Str_cfechadocu = "";
            string _Str_cmontosi = "";
            string _Str_cmontoimp = "";
            decimal _Dcm_cdescfinanmonto = 0;
            string _Str_Nr = "";
            string _Str_cyearacco = "", _Str_cmontacco = "";
            string _Str_cidcomprob = _P_Int_Comprobant.ToString();
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont(_P_Str_Proceso.Trim());
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            string _Str_NombProveedor = "";
            string _Str_Cadena = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal='1') AND cproveedor='" + _P_Str_cproveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_NombProveedor = _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            _Str_Cadena = "Select cidnotadebitocxp,cfechand,ISNULL(cmontototsi,0)+ISNULL(cbaseexcenta,0) AS cmontototsi,cimpuesto,cporcinvendible,cnumdocu,cidnotrecepc,ctotaldocu,cdescfinanmonto FROM TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _P_Str_cproveedor + "' and cidnotadebitocxp='" + _P_Str_cidnotadebitocxp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_cnumdocu = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString();
                _Str_cfechadocu = _Ds.Tables[0].Rows[0][1].ToString();
                _Str_cmontosi = _Ds.Tables[0].Rows[0][2].ToString();
                _Str_cmontoimp = _Ds.Tables[0].Rows[0][3].ToString();
                _Str_cporcinvendible = _Ds.Tables[0].Rows[0][4].ToString();
                if (_Str_cporcinvendible.Trim().Length == 0)
                { _Str_cporcinvendible = "0"; }
                _Str_Nr = Convert.ToString(_Ds.Tables[0].Rows[0]["cidnotrecepc"]).Trim();
                _Dbl_MontoTotal = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                if (_Ds.Tables[0].Rows[0]["cdescfinanmonto"].ToString() != "")
                    _Dcm_cdescfinanmonto = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cdescfinanmonto"]);
            }
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());

            string _Str_Sql = "";
            bool _Bol_Boleano = false;
            string _Str_DebeoHaber = "", _Str_corder = "", _Str_Descrip = "";
            string _Str_CountCont = "", _Str_CountContName = "";
            DataSet _Datset;
            _Str_Cadena = "DELETE FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "DELETE FROM TCOMPROBANDD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "DELETE FROM TMOVAUXILIARCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "Select ccount,ctipodocumento,cnaturaleza,cideprocesod from TPROCESOSCONTD where cidproceso='" + _P_Str_Proceso.Trim() + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_DebeoHaber = "";
                _Str_corder = "";
                if (_Row["cideprocesod"].ToString() == "1")
                {
                    _Str_DebeoHaber = Convert.ToString(_Dbl_MontoTotal);
                }
                else if (_Row["cideprocesod"].ToString() == "2")
                {
                    _Str_DebeoHaber = _Str_cmontosi;
                }
                else if (_Row["cideprocesod"].ToString() == "3")
                {
                    _Str_DebeoHaber = _Str_cmontoimp;
                }
                else if (_Row["cideprocesod"].ToString() == "4")
                {
                    _Str_DebeoHaber = _Str_cporcinvendible;
                }
                else if (_Row["cideprocesod"].ToString() == "5")
                {
                    _Str_DebeoHaber = _Dcm_cdescfinanmonto.ToString();
                }
                if (_Mtd_CuentaExistente(_Row["ccount"].ToString()))
                { _Str_CountCont = _Row["ccount"].ToString(); }
                else
                { _Str_CountCont = _P_Str_CuentaOtros; }
                if (_Str_DebeoHaber != "")
                {
                    if (Convert.ToDouble(_Str_DebeoHaber) > 0)
                    {
                        if (_Str_CountCont != "")
                        {
                            _Str_Sql = "SELECT cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _Str_CountCont + "'";
                            _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Datset.Tables[0].Rows.Count > 0)
                            {
                                _Str_CountContName = _Datset.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
                            }
                            _Str_Descrip = _Str_CountContName + " " + _Str_NombProveedor + " SEGÚN ND # " + _P_Str_cidnotadebitocxp + " POR " + _P_Str_Descripcion.ToUpper() + ", DE LA FACTURA # " + _Str_cnumdocu;
                        }
                        else
                        {
                            _Str_Descrip = "PROVEEDOR SIN CUENTA CONTABLE. " + _Str_NombProveedor + " SEGÚN ND # " + _P_Str_cidnotadebitocxp + " POR " + _P_Str_Descripcion.ToUpper() + ", DE LA FACTURA # " + _Str_cnumdocu;
                        }

                        _Str_corder = Convert.ToString(_Mtd_Consecutivo_TCOMPROBAND(_Str_cidcomprob));
                        if (_Row["cnaturaleza"].ToString() == "D")
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(false) + "','" + _P_Str_cidnotadebitocxp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                            _Dbl_Debe = _Dbl_Debe + Convert.ToDouble(_Str_DebeoHaber);
                        }
                        else
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(false) + "','" + _P_Str_cidnotadebitocxp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                            _Dbl_Haber = _Dbl_Haber + Convert.ToDouble(_Str_DebeoHaber);
                        }
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_CountCont, _P_Str_cproveedor, _Str_Descrip, _Mtd_TipoDocumentNC_ND(false), _P_Str_cidnotadebitocxp, _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)), _Str_cmontacco, _Str_cyearacco, _Row["cnaturaleza"].ToString().Trim().ToUpper());
                    }
                }
                _Bol_Boleano = true;
            }
            if (_Bol_Boleano)
            {
                double _Dbl_cbalanceo = 0;
                if (_Dbl_Debe > _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Debe - _Dbl_Haber; }
                else if (_Dbl_Debe < _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Haber - _Dbl_Debe; }
                _Str_Sql = "UPDATE TCOMPROBANC SET ctypcomp='" + _Str_ctypcompro + "',cname='" + _Str_cconceptocomp.ToUpper() + "',cyearacco='" + _Str_cyearacco + "',cmontacco='" + _Str_cmontacco + "',cregdate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "',cbalance='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "',cdateadd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuseradd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            return Convert.ToInt32(_Str_cidcomprob);
        }
        //__________________________________________________________________________
        public int _Mtd_Proceso_P_CXP_ND_DIFPRECIO(string _P_Str_cidnotadebitocxp, string _P_Str_cproveedor)
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            double _Dbl_MontoTotal = 0;
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cnumdocu = "";
            string _Str_cporcinvendible = "";
            string _Str_cfechadocu = "";
            string _Str_cmontosi = "";
            string _Str_cmontoimp = "";
            decimal _Dcm_cdescfinanmonto = 0;
            string _Str_Nr = "";
            string _Str_cyearacco = "", _Str_cmontacco = "";
            string _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXP_ND_DIFPRECIO");
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            string _Str_Cadena = "";
            DataSet _Ds;
            _Str_Cadena = "Select cidnotadebitocxp,cfechand,ISNULL(cmontototsi,0)+ISNULL(cbaseexcenta,0) AS cmontototsi,cimpuesto,cporcinvendible,cnumdocu,cidnotrecepc,ctotaldocu,cdescfinanmonto FROM TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _P_Str_cproveedor + "' and cidnotadebitocxp='" + _P_Str_cidnotadebitocxp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_cnumdocu = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString();
                _Str_cfechadocu = _Ds.Tables[0].Rows[0][1].ToString();
                _Str_cmontosi = _Ds.Tables[0].Rows[0][2].ToString();
                _Str_cmontoimp = _Ds.Tables[0].Rows[0][3].ToString();
                _Str_cporcinvendible = _Ds.Tables[0].Rows[0][4].ToString();
                _Str_Nr = Convert.ToString(_Ds.Tables[0].Rows[0]["cidnotrecepc"]).Trim();
                _Dbl_MontoTotal = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                if (_Ds.Tables[0].Rows[0]["cdescfinanmonto"].ToString() != "")
                    _Dcm_cdescfinanmonto = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cdescfinanmonto"]);
            }
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());
            
            string _Str_Sql = "";
            bool _Bol_Boleano = false;
            string _Str_DebeoHaber = "", _Str_corder = "", _Str_Descrip = "";
            string _Str_CountCont = "", _Str_CountContName = "";
            DataSet _Datset;
            //-----------------------
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','0','0','0','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
            //-----------------------
            _Str_Cadena = "Select ccount,ctipodocumento,cnaturaleza,cideprocesod from TPROCESOSCONTD where cidproceso='P_CXP_ND_DIFPRECIO'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_DebeoHaber = "";
                _Str_corder = "";
                if (_Row["cideprocesod"].ToString() == "1")
                {
                    _Str_DebeoHaber = _Dbl_MontoTotal.ToString();
                }
                else if (_Row["cideprocesod"].ToString() == "2")
                {
                    _Str_DebeoHaber = _Str_cmontosi;
                }
                else if (_Row["cideprocesod"].ToString() == "3")
                {
                    _Str_DebeoHaber = _Str_cmontoimp;
                }
                else if (_Row["cideprocesod"].ToString() == "4")
                {
                    _Str_DebeoHaber = _Str_cporcinvendible;
                }
                else if (_Row["cideprocesod"].ToString() == "5")
                {
                    _Str_DebeoHaber = _Dcm_cdescfinanmonto.ToString();
                }
                _Str_CountCont = _Row["ccount"].ToString();
                if (_Str_DebeoHaber != "")
                {
                    if (Convert.ToDouble(_Str_DebeoHaber) > 0)
                    {
                        if (_Str_CountCont != "")
                        {
                            _Str_Sql = "SELECT cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _Str_CountCont + "'";
                            _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Datset.Tables[0].Rows.Count > 0)
                            {
                                _Str_CountContName = _Datset.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
                            }
                            _Str_Descrip = _Str_CountContName + " SEGÚN ND # " + _P_Str_cidnotadebitocxp + " POR DIFERENCIA DE PRECIO, DE LA FACTURA # " + _Str_cnumdocu + ", SEGÚN NR # " + _Str_Nr;
                        }
                        else
                        {
                            _Str_Descrip = "PROVEEDOR SIN CUENTA CONTABLE. SEGÚN ND # " + _P_Str_cidnotadebitocxp + " POR DIFERENCIA DE PRECIO, DE LA FACTURA # " + _Str_cnumdocu + ", SEGÚN NR # " + _Str_Nr;
                        }

                        _Str_corder = Convert.ToString(_Mtd_Consecutivo_TCOMPROBAND(_Str_cidcomprob));
                        if (_Row["cnaturaleza"].ToString() == "D")
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(false) + "','" + _P_Str_cidnotadebitocxp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                            _Dbl_Debe = _Dbl_Debe + Convert.ToDouble(_Str_DebeoHaber);
                        }
                        else
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(false) + "','" + _P_Str_cidnotadebitocxp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                            _Dbl_Haber = _Dbl_Haber + Convert.ToDouble(_Str_DebeoHaber);
                        }
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_CountCont, _P_Str_cproveedor, _Str_Descrip, _Mtd_TipoDocumentNC_ND(false), _P_Str_cidnotadebitocxp, _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)), _Str_cmontacco, _Str_cyearacco, _Row["cnaturaleza"].ToString().Trim().ToUpper());
                    }
                }
                _Bol_Boleano = true;
            }
            if (_Bol_Boleano)
            {
                double _Dbl_cbalanceo = 0;
                if (_Dbl_Debe > _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Debe - _Dbl_Haber; }
                else if (_Dbl_Debe < _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Haber - _Dbl_Debe; }
                _Str_Sql = "UPDATE TCOMPROBANC SET ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "',cbalance='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                //_Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            }
            return Convert.ToInt32(_Str_cidcomprob);
        }
        //__________________________________________________________________________
        public int _Mtd_Proceso_P_CXP_ND_FALTANTE(string _P_Str_cidnotadebitocxp, string _P_Str_cproveedor)
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            double _Dbl_MontoTotal = 0;
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cnumdocu = "";
            string _Str_cporcinvendible = "";
            string _Str_cfechadocu = "";
            string _Str_cmontosi = "";
            string _Str_cmontoimp = "";
            string _Str_Nr = "";
            string _Str_cyearacco = "", _Str_cmontacco = "";
            string _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            decimal _Dcm_cdescfinanmonto = 0;
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXP_ND_FALTANTE");
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            string _Str_Cadena = "";
            DataSet _Ds;
            _Str_Cadena = "Select cidnotadebitocxp,cfechand,ISNULL(cmontototsi,0)+ISNULL(cbaseexcenta,0) AS cmontototsi,cimpuesto,cporcinvendible,cnumdocu,cidnotrecepc,ctotaldocu,cdescfinanmonto from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _P_Str_cproveedor + "' and cidnotadebitocxp='" + _P_Str_cidnotadebitocxp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_cnumdocu = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString();
                _Str_cfechadocu = _Ds.Tables[0].Rows[0][1].ToString();
                _Str_cmontosi = _Ds.Tables[0].Rows[0][2].ToString();
                _Str_cmontoimp = _Ds.Tables[0].Rows[0][3].ToString();
                _Str_cporcinvendible = _Ds.Tables[0].Rows[0][4].ToString();
                _Str_Nr = Convert.ToString(_Ds.Tables[0].Rows[0]["cidnotrecepc"]).Trim();
                _Dbl_MontoTotal = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                if (_Ds.Tables[0].Rows[0]["cdescfinanmonto"].ToString() != "")
                    _Dcm_cdescfinanmonto = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cdescfinanmonto"]);
            }
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());

            string _Str_Sql = "";
            bool _Bol_Boleano = false;
            string _Str_DebeoHaber = "", _Str_corder = "", _Str_Descrip = "";
            string _Str_CountCont = "", _Str_CountContName = "";
            DataSet _Datset;
            //-----------------------
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','0','0','0','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
            //-----------------------
            _Str_Cadena = "Select ccount,ctipodocumento,cnaturaleza,cideprocesod from TPROCESOSCONTD where cidproceso='P_CXP_ND_FALTANTE'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_DebeoHaber = "";
                _Str_corder = "";

                if (_Row["cideprocesod"].ToString() == "1")
                {
                    _Str_DebeoHaber = _Dbl_MontoTotal.ToString();
                }
                else if (_Row["cideprocesod"].ToString() == "2")
                {
                    _Str_DebeoHaber = _Str_cmontosi;
                }
                else if (_Row["cideprocesod"].ToString() == "3")
                {
                    _Str_DebeoHaber = _Str_cmontoimp;
                }
                else if (_Row["cideprocesod"].ToString() == "4")
                {
                    _Str_DebeoHaber = _Str_cporcinvendible;
                }
                else if (_Row["cideprocesod"].ToString() == "5")
                {
                    _Str_DebeoHaber = _Dcm_cdescfinanmonto.ToString();
                }
                _Str_CountCont = _Row["ccount"].ToString();

                if (_Str_DebeoHaber != "")
                {
                    if (Convert.ToDouble(_Str_DebeoHaber) > 0)
                    {
                        if (_Str_CountCont != "")
                        {
                            _Str_Sql = "SELECT cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _Str_CountCont + "'";
                            _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Datset.Tables[0].Rows.Count > 0)
                            {
                                _Str_CountContName = _Datset.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
                            }
                            _Str_Descrip = _Str_CountContName + " SEGÚN ND # " + _P_Str_cidnotadebitocxp + " POR FALTANTE, DE LA FACTURA # " + _Str_cnumdocu + ", SEGÚN NR # " + _Str_Nr;
                        }
                        else
                        {
                            _Str_Descrip = "PROVEEDOR SIN CUENTA CONTABLE. SEGÚN ND # " + _P_Str_cidnotadebitocxp + " POR FALTANTE, DE LA FACTURA # " + _Str_cnumdocu + ", SEGÚN NR # " + _Str_Nr;
                        }

                        _Str_corder = Convert.ToString(_Mtd_Consecutivo_TCOMPROBAND(_Str_cidcomprob));
                        if (_Row["cnaturaleza"].ToString() == "D")
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(false) + "','" + _P_Str_cidnotadebitocxp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                            _Dbl_Debe = _Dbl_Debe + Convert.ToDouble(_Str_DebeoHaber);
                        }
                        else
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(false) + "','" + _P_Str_cidnotadebitocxp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                            _Dbl_Haber = _Dbl_Haber + Convert.ToDouble(_Str_DebeoHaber);
                        }
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_CountCont, _P_Str_cproveedor, _Str_Descrip, _Mtd_TipoDocumentNC_ND(false), _P_Str_cidnotadebitocxp, _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)), _Str_cmontacco, _Str_cyearacco, _Row["cnaturaleza"].ToString().Trim().ToUpper());
                    }
                }
                _Bol_Boleano = true;
            }
            if (_Bol_Boleano)
            {
                double _Dbl_cbalanceo = 0;
                if (_Dbl_Debe > _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Debe - _Dbl_Haber; }
                else if (_Dbl_Debe < _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Haber - _Dbl_Debe; }
                _Str_Sql = "UPDATE TCOMPROBANC SET ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "',cbalance='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                //_Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            }
            return Convert.ToInt32(_Str_cidcomprob);
        }
        //__________________________________________________________________________
        //__________________________________________________________________________
        public int _Mtd_Proceso_P_CXP_NC_SOBRANTE_A(string _P_Str_cidnotacreditocxp, string _P_Str_cproveedor)
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            double _Dbl_MontoTotal = 0;
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cnumdocu = "";
            string _Str_cporcinvendible = "";
            string _Str_cfechadocu = "";
            string _Str_cfechadocuVenc = "";
            string _Str_cmontosi = "";
            string _Str_cmontoimp = "";
            string _Str_cyearacco = "", _Str_cmontacco = "";
            string _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXP_NC_SOBRANTE_A");
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            string _Str_Cadena = "";
            DataSet _Ds;
            _Str_Cadena = "Select cidnotacreditocxp,cfechanc,cmontototsi,cimpuesto,cporcinvendible,ctotaldocu,cfvfnotacredp from TNOTACREDICP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _P_Str_cproveedor + "' and cidnotacreditocxp='" + _P_Str_cidnotacreditocxp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_cnumdocu = _Ds.Tables[0].Rows[0][0].ToString();
                _Str_cfechadocu = _Ds.Tables[0].Rows[0][1].ToString();
                _Str_cmontosi = _Ds.Tables[0].Rows[0][2].ToString();
                _Str_cmontoimp = _Ds.Tables[0].Rows[0][3].ToString();
                _Str_cporcinvendible = _Ds.Tables[0].Rows[0][4].ToString();
                _Dbl_MontoTotal = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                _Str_cfechadocuVenc = _Ds.Tables[0].Rows[0]["cfvfnotacredp"].ToString();
            }
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());
            string _Str_Sql = "";
            bool _Bol_Boleano = false;
            string _Str_DebeoHaber = "", _Str_corder = "", _Str_Descrip = "";
            string _Str_CountCont = "", _Str_CountContName = "";
            DataSet _Datset;
            string _Str_Nr = "";            
            _Str_Sql = "Select cidnotrecepc from TNOTACREDICP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotacreditocxp='" + _P_Str_cidnotacreditocxp + "' and cproveedor='" + _P_Str_cproveedor + "'";
            _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Datset.Tables[0].Rows.Count > 0)
            { _Str_Nr = _Datset.Tables[0].Rows[0][0].ToString(); }
            //-----------------------
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','0','0','0','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
            //-----------------------
            _Str_Cadena = "Select ccount,ctipodocumento,cnaturaleza,cideprocesod from TPROCESOSCONTD where cidproceso='P_CXP_NC_SOBRANTE_A'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_DebeoHaber = "";
                _Str_corder = "";
                _Str_CountCont = _Row["ccount"].ToString();
                if (_Str_CountCont != "")
                {
                    _Str_Sql = "SELECT cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _Str_CountCont + "'";
                    _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Datset.Tables[0].Rows.Count > 0)
                    {
                        _Str_CountContName = _Datset.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
                    }
                    _Str_Descrip = _Str_CountContName + " SEGÚN NC # " + _P_Str_cidnotacreditocxp + " POR SOBRANTE, DE LA FACTURA # " + _Str_cnumdocu + ", SEGÚN NR # " + _Str_Nr + " ANULACION";
                }
                else
                {
                    _Str_Descrip = "PROVEEDOR SIN CUENTA CONTABLE. SEGÚN NC # " + _P_Str_cidnotacreditocxp + " POR SOBRANTE, DE LA FACTURA # " + _Str_cnumdocu + ", SEGÚN NR # " + _Str_Nr + " ANULACION";
                }

                if (_Row["cideprocesod"].ToString() == "1")
                {
                    _Str_DebeoHaber = _Str_cmontosi;
                }
                else if (_Row["cideprocesod"].ToString() == "2")
                {
                    _Str_DebeoHaber = _Str_cmontoimp;
                }
                else if (_Row["cideprocesod"].ToString() == "3")
                {
                    _Str_DebeoHaber = _Str_cporcinvendible;
                }
                else if (_Row["cideprocesod"].ToString() == "4")
                {
                    _Str_DebeoHaber = _Dbl_MontoTotal.ToString();
                }
                if (_Str_DebeoHaber != "")
                {
                    if (Convert.ToDouble(_Str_DebeoHaber) > 0)
                    {
                        _Str_corder = Convert.ToString(_Mtd_Consecutivo_TCOMPROBAND(_Str_cidcomprob));
                        if (_Row["cnaturaleza"].ToString() == "D")
                        {
                            _Dbl_Debe = _Dbl_Debe + Convert.ToDouble(_Str_DebeoHaber);
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(true) + "','" + _P_Str_cidnotacreditocxp + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                        }
                        else
                        {
                            _Dbl_Haber = _Dbl_Haber + Convert.ToDouble(_Str_DebeoHaber);
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(true) + "','" + _P_Str_cidnotacreditocxp + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                        }
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_CountCont, _P_Str_cproveedor, _Str_Descrip, _Mtd_TipoDocumentNC_ND(true), _P_Str_cidnotacreditocxp, _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)), _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocuVenc)), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)), _Str_cmontacco, _Str_cyearacco, _Row["cnaturaleza"].ToString().Trim().ToUpper());
                    }
                }
                _Bol_Boleano = true;
            }
            if (_Bol_Boleano)
            {
                double _Dbl_cbalanceo = 0;
                if (_Dbl_Debe > _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Debe - _Dbl_Haber; }
                else if (_Dbl_Debe < _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Haber - _Dbl_Debe; }
                _Str_Sql = "UPDATE TCOMPROBANC SET ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "',cbalance='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                //_Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            }
            return Convert.ToInt32(_Str_cidcomprob);
        }
        //____________________________________________________________________________________
        public int _Mtd_Proceso_P_CXP_NC_DIFPRECIO_A(string _P_Str_cidnotacreditocxp, string _P_Str_cproveedor)
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            double _Dbl_MontoTotal = 0;
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cnumdocu = "";
            string _Str_cporcinvendible = "";
            string _Str_cfechadocu = "";
            string _Str_cfechadocuVenc = "";
            string _Str_cmontosi = "";
            string _Str_cmontoimp = "";
            string _Str_cyearacco = "", _Str_cmontacco = "";
            string _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXP_NC_DIFPRECIO_A");
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            string _Str_Cadena = "";
            DataSet _Ds;
            _Str_Cadena = "Select cidnotacreditocxp,cfechanc,cmontototsi,cimpuesto,cporcinvendible,ctotaldocu,cfvfnotacredp from TNOTACREDICP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _P_Str_cproveedor + "' and cidnotacreditocxp='" + _P_Str_cidnotacreditocxp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_cnumdocu = _Ds.Tables[0].Rows[0][0].ToString();
                _Str_cfechadocu = _Ds.Tables[0].Rows[0][1].ToString();
                _Str_cmontosi = _Ds.Tables[0].Rows[0][2].ToString();
                _Str_cmontoimp = _Ds.Tables[0].Rows[0][3].ToString();
                _Str_cporcinvendible = _Ds.Tables[0].Rows[0][4].ToString();
                _Dbl_MontoTotal = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                _Str_cfechadocuVenc = _Ds.Tables[0].Rows[0]["cfvfnotacredp"].ToString();
            }
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());
            string _Str_Sql = "";
            bool _Bol_Boleano = false;
            string _Str_Nr = "";
            string _Str_DebeoHaber = "", _Str_corder = "", _Str_Descrip = "";
            string _Str_CountCont = "", _Str_CountContName = "";
            DataSet _Datset;
            _Str_Sql = "Select cidnotrecepc from TNOTACREDICP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotacreditocxp='" + _P_Str_cidnotacreditocxp + "' and cproveedor='" + _P_Str_cproveedor + "'";
            _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Datset.Tables[0].Rows.Count > 0)
            { _Str_Nr = _Datset.Tables[0].Rows[0][0].ToString(); }
            //-----------------------
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','0','0','0','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
            //-----------------------
            _Str_Cadena = "Select ccount,ctipodocumento,cnaturaleza,cideprocesod from TPROCESOSCONTD where cidproceso='P_CXP_NC_DIFPRECIO_A'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_DebeoHaber = "";
                _Str_corder = "";
                _Str_CountCont = _Row["ccount"].ToString();
                if (_Row["cideprocesod"].ToString() == "1")
                {
                    _Str_DebeoHaber = _Str_cmontosi;
                }
                if (_Row["cideprocesod"].ToString() == "2")
                {
                    _Str_DebeoHaber = _Str_cporcinvendible;
                }
                if (_Row["cideprocesod"].ToString() == "3")
                {
                    _Str_DebeoHaber = _Str_cmontoimp;
                }
                if (_Row["cideprocesod"].ToString() == "4")
                {
                    _Str_DebeoHaber = _Dbl_MontoTotal.ToString();
                }

                if (_Str_CountCont != "")
                {
                    _Str_Sql = "SELECT cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _Str_CountCont + "'";
                    _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Datset.Tables[0].Rows.Count > 0)
                    {
                        _Str_CountContName = _Datset.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
                    }
                    _Str_Descrip = _Str_CountContName + " SEGÚN NC # " + _P_Str_cidnotacreditocxp + " POR DIFERENCIA DE PRECIO, DE LA FACTURA # " + _Str_cnumdocu + ", SEGÚN NR # " + _Str_Nr + " ANULACION";
                }
                else
                {
                    _Str_Descrip = "PROVEEDOR SIN CUENTA CONTABLE. SEGÚN NC # " + _P_Str_cidnotacreditocxp + " POR DIFERENCIA DE PRECIO, DE LA FACTURA # " + _Str_cnumdocu + ", SEGÚN NR # " + _Str_Nr + "ANULACION";
                }


                if (_Str_DebeoHaber != "")
                {
                    if (Convert.ToDouble(_Str_DebeoHaber) > 0)
                    {
                        _Str_corder = Convert.ToString(_Mtd_Consecutivo_TCOMPROBAND(_Str_cidcomprob));
                        if (_Row["cnaturaleza"].ToString() == "D")
                        {
                            _Dbl_Debe = _Dbl_Debe + Convert.ToDouble(_Str_DebeoHaber);
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(true) + "','" + _P_Str_cidnotacreditocxp + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                        }
                        else
                        {
                            _Dbl_Haber = _Dbl_Haber + Convert.ToDouble(_Str_DebeoHaber);
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(true) + "','" + _P_Str_cidnotacreditocxp + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                        }
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_CountCont, _P_Str_cproveedor, _Str_Descrip, _Mtd_TipoDocumentNC_ND(true), _P_Str_cidnotacreditocxp, _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)), _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocuVenc)), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)), _Str_cmontacco, _Str_cyearacco, _Row["cnaturaleza"].ToString().Trim().ToUpper());
                    }
                }
                
                _Bol_Boleano = true;
            }
            if (_Bol_Boleano)
            {
                double _Dbl_cbalanceo = 0;
                if (_Dbl_Debe > _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Debe - _Dbl_Haber; }
                else if (_Dbl_Debe < _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Haber - _Dbl_Debe; }
                _Str_Sql = "UPDATE TCOMPROBANC SET ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "',cbalance='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                //_Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            }
            return Convert.ToInt32(_Str_cidcomprob);
        }
        //__________________________________________________________________________
        public int _Mtd_Proceso_P_CXP_ND_DIFPRECIO_A(string _P_Str_cidnotadebitocxp, string _P_Str_cproveedor)
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            double _Dbl_MontoTotal = 0;
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cnumdocu = "";
            string _Str_cporcinvendible = "";
            string _Str_cfechadocu = "";
            string _Str_cfechadocuVenc = "";
            string _Str_cmontosi = "";
            string _Str_cmontoimp = "";
            string _Str_cyearacco = "", _Str_cmontacco = "";
            string _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXP_ND_DIFPRECIO_A");
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            string _Str_Cadena = "";
            DataSet _Ds;
            _Str_Cadena = "Select cidnotadebitocxp,cfechand,cmontototsi,cimpuesto,cporcinvendible,ctotaldocu,cfvfnotadebitop from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _P_Str_cproveedor + "' and cidnotadebitocxp='" + _P_Str_cidnotadebitocxp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_cnumdocu = _Ds.Tables[0].Rows[0][0].ToString();
                _Str_cfechadocu = _Ds.Tables[0].Rows[0][1].ToString();
                _Str_cmontosi = _Ds.Tables[0].Rows[0][2].ToString();
                _Str_cmontoimp = _Ds.Tables[0].Rows[0][3].ToString();
                _Str_cporcinvendible = _Ds.Tables[0].Rows[0][4].ToString();
                _Dbl_MontoTotal = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                _Str_cfechadocuVenc = _Ds.Tables[0].Rows[0]["cfvfnotadebitop"].ToString();
            }
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());
            string _Str_Sql = "";
            bool _Bol_Boleano = false;
            string _Str_DebeoHaber = "", _Str_corder = "", _Str_Descrip = "";
            string _Str_CountCont = "", _Str_CountContName = "";
            DataSet _Datset;
            string _Str_Nr = "";
            _Str_Sql = "Select cidnotrecepc from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _P_Str_cidnotadebitocxp + "' and cproveedor='" + _P_Str_cproveedor + "'";
            _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Datset.Tables[0].Rows.Count > 0)
            { _Str_Nr = _Datset.Tables[0].Rows[0][0].ToString(); }
            //-----------------------
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','0','0','0','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
            //-----------------------
            _Str_Cadena = "Select ccount,ctipodocumento,cnaturaleza,cideprocesod from TPROCESOSCONTD where cidproceso='P_CXP_ND_DIFPRECIO_A'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_DebeoHaber = "";
                _Str_corder = "";
                _Str_CountCont = _Row["ccount"].ToString().Trim();
                if (_Row["cideprocesod"].ToString() == "1")
                {
                    _Str_DebeoHaber = _Dbl_MontoTotal.ToString();
                }
                else if (_Row["cideprocesod"].ToString() == "2")
                {
                    _Str_DebeoHaber =_Str_cmontosi;
                }
                else if (_Row["cideprocesod"].ToString() == "3")
                {
                    _Str_DebeoHaber = _Str_cmontoimp;
                }
                else if (_Row["cideprocesod"].ToString() == "4")
                {
                    _Str_DebeoHaber = _Str_cporcinvendible;
                }

                if (_Str_CountCont != "")
                {
                    _Str_Sql = "SELECT cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _Str_CountCont + "'";
                    _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Datset.Tables[0].Rows.Count > 0)
                    {
                        _Str_CountContName = _Datset.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
                    }
                    _Str_Descrip = _Str_CountContName + " SEGÚN ND # " + _P_Str_cidnotadebitocxp + " POR DIFERENCIA DE PRECIO, DE LA FACTURA # " + _Str_cnumdocu + ", SEGÚN NR # " + _Str_Nr + " ANULACION";
                }
                else
                {
                    _Str_Descrip = "PROVEEDOR SIN CUENTA CONTABLE. SEGÚN ND # " + _P_Str_cidnotadebitocxp + " POR DIFERENCIA DE PRECIO, DE LA FACTURA # " + _Str_cnumdocu + ", SEGÚN NR # " + _Str_Nr + " ANULACION";
                }

                if (_Str_DebeoHaber != "")
                {
                    if (Convert.ToDouble(_Str_DebeoHaber) > 0)
                    {
                        _Str_corder = Convert.ToString(_Mtd_Consecutivo_TCOMPROBAND(_Str_cidcomprob));
                        if (_Row["cnaturaleza"].ToString() == "D")
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(false) + "','" + _P_Str_cidnotadebitocxp + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                            _Dbl_Debe = _Dbl_Debe + Convert.ToDouble(_Str_DebeoHaber);
                        }
                        else
                        {
                            _Dbl_Haber = _Dbl_Haber + Convert.ToDouble(_Str_DebeoHaber);
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(false) + "','" + _P_Str_cidnotadebitocxp + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                        }
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_CountCont, _P_Str_cproveedor, _Str_Descrip, _Mtd_TipoDocumentNC_ND(false), _P_Str_cidnotadebitocxp, _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)), _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocuVenc)), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)), _Str_cmontacco, _Str_cyearacco, _Row["cnaturaleza"].ToString().Trim().ToUpper());
                    }
                }
                _Bol_Boleano = true;
            }
            if (_Bol_Boleano)
            {
                double _Dbl_cbalanceo = 0;
                if (_Dbl_Debe > _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Debe - _Dbl_Haber; }
                else if (_Dbl_Debe < _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Haber - _Dbl_Debe; }
                _Str_Sql = "UPDATE TCOMPROBANC SET ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "',cbalance='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                //_Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            }
            return Convert.ToInt32(_Str_cidcomprob);
        }

        public int _Mtd_Proceso_P_CXP_NC_DESCPPP(string _P_Str_cidnotacreditocxp, string _P_Str_cproveedor)
        {//DEVUELVO EL COMPROBANTE CONTABLE QUE SE GENERA EN ESTE PROCESO
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cnumdocu = "";
            string _Str_cfechadocu = "";
            string _Str_cmontosi = "";
            string _Str_cmontoimp = "";
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            string _Str_CountProvee = "", _Str_CountPoveeName="";
            string _Str_Count = "";
            string _Str_Sql = "";
            string _Str_Descrip = "";
            string _Str_DescripAux = "";
            string _Str_corder = "";
            string _Str_total = "";
            string _Str_DebeoHaber = "";
            string _Str_NumFact = "";
            string _Str_Fact = "";
            string _Str_NC = "";
            bool _Bol_Boleano = false;

            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipdocfact,ctipodocnc from TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Fact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]);
                _Str_NC = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocnc"]);
            }

            string _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXP_ND_DCTOPP");
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;

            string _Str_Cadena = "";
            
            _Str_Cadena = "Select cidnotacreditocxp,cfechanc,cmontototsi,cimpuesto,cnumdocu from TNOTACREDICP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _P_Str_cproveedor + "' and cidnotacreditocxp='" + _P_Str_cidnotacreditocxp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_cnumdocu = _Ds.Tables[0].Rows[0][0].ToString();
                _Str_cfechadocu = _Ds.Tables[0].Rows[0][1].ToString();
                _Str_cmontosi = _Ds.Tables[0].Rows[0][2].ToString();
                _Str_cmontoimp = Convert.ToString(_Ds.Tables[0].Rows[0][3]);
                _Str_NumFact = _Ds.Tables[0].Rows[0][4].ToString();
            }
            _Str_DescripAux = " NC " + _P_Str_cidnotacreditocxp + " DSCTO P/P S/F #" + _Str_NumFact;
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());

            _Str_corder = Convert.ToString(_Mtd_Consecutivo_TCOMPROBAND(_Str_cidcomprob));
            _Str_total = Convert.ToString(Convert.ToDouble(_Str_cmontosi) + Convert.ToDouble(_Str_cmontoimp));

            _Str_Cadena = "Select ccount,ctipodocumento,cnaturaleza,cideprocesod,ccountname from VST_PROCESOSCONTD where cidproceso='P_CXP_ND_DCTOPP' and (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL)";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_Count = _Row["ccount"].ToString();
                //--------------------------------
                _Str_Descrip = _Row["ccountname"].ToString() + _Str_DescripAux;
                //--------------------------------
                _Str_DebeoHaber = "";
                if (_Row["cideprocesod"].ToString() == "1")
                {
                    _Str_DebeoHaber = _Str_total;
                }
                else if (_Row["cideprocesod"].ToString() == "2")
                {
                    _Str_DebeoHaber = _Str_cmontosi;
                }
                else if (_Row["cideprocesod"].ToString() == "3")
                {
                    _Str_DebeoHaber = _Str_cmontoimp;
                }

                _Str_corder = Convert.ToString(_Mtd_Consecutivo_TCOMPROBAND(_Str_cidcomprob));
                _Str_Sql = "";
                if (_Row["cnaturaleza"].ToString() == "D")
                {
                    if (_Str_DebeoHaber != "0" && _Str_DebeoHaber != "")
                    {
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_Count + "','" + _Row["ctipodocumento"].ToString() + "','" + _Str_cnumdocu + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                        _Dbl_Debe = _Dbl_Debe + Convert.ToDouble(_Str_DebeoHaber);
                    }

                }
                else
                {
                    if (_Str_DebeoHaber != "0" && _Str_DebeoHaber != "")
                    {
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_Count + "','" + _Row["ctipodocumento"].ToString() + "','" + _Str_cnumdocu + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                        _Dbl_Haber = _Dbl_Haber + Convert.ToDouble(_Str_DebeoHaber);
                    }
                }
                if (_Str_Sql != "")
                {
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
                _Bol_Boleano = true;
            }
            if (_Bol_Boleano)
            {
                double _Dbl_cbalanceo = 0;
                if (_Dbl_Debe > _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Debe - _Dbl_Haber; }
                else if (_Dbl_Debe < _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Haber - _Dbl_Debe; }
                _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            return Convert.ToInt32(_Str_cidcomprob);
        }
        public double _Mtd_ObtenerMontoAsociadoPago(string _Pr_Str_OPId, string _Pr_Str_ProvId, string _Pr_Str_NumDoc)
        {
            string _Str_DocFact = "";
            string _Str_DocISLR = "";
            string _Str_DocIVA = "";
            string _Str_DocND = "";
            string _Str_DocNC = "";
            string _Str_Sql = "";
            double _Dbl_MontoND = 0;
            double _Dbl_MontoNC = 0;
            double _Dbl_MontoRETIVA = 0;
            double _Dbl_MontoRETISLR = 0;
            double _Dbl_MontoDesc = 0;
            double _Dbl_MR = 0;
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipdocretislr,ctipdocretiva,ctipodocnd,ctipodocnc,ctipdocfact from TCONFIGCXP where ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_DocISLR = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocretislr"]);
                _Str_DocIVA = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocretiva"]);
                _Str_DocFact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]);
                _Str_DocND = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocnd"]);
                _Str_DocNC = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocnc"]);
            }
            _Str_Sql = "select cmontocancelar,ctipodocument from TPAGOSCXPD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Pr_Str_OPId + "' AND ctipodocument<>'" + _Str_DocFact + "' and cnumdocu='" + _Pr_Str_NumDoc + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                if (Convert.ToString(_DRow["ctipodocument"]) == _Str_DocNC)
                {
                    _Dbl_MontoNC = _Dbl_MontoNC + Convert.ToDouble(_DRow["cmontocancelar"]);
                }
                if (Convert.ToString(_DRow["ctipodocument"]) == _Str_DocND)
                {
                    _Dbl_MontoND = _Dbl_MontoND + Convert.ToDouble(_DRow["cmontocancelar"]);
                }
                if (Convert.ToString(_DRow["ctipodocument"]) == _Str_DocIVA)
                {
                    _Dbl_MontoRETIVA = _Dbl_MontoRETIVA + Convert.ToDouble(_DRow["cmontocancelar"]);
                }
                if (Convert.ToString(_DRow["ctipodocument"]) == _Str_DocISLR)
                {
                    _Dbl_MontoRETISLR = _Dbl_MontoRETISLR + Convert.ToDouble(_DRow["cmontocancelar"]);
                }
            }
            _Str_Sql = "select cncppp from TPAGOSCXPD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Pr_Str_OPId + "' AND ctipodocument='" + _Str_DocFact + "' and cnumdocu='" + _Pr_Str_NumDoc + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                {
                    _Dbl_MontoDesc = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                }

            }
            //_Dbl_MontoND - _Dbl_MontoNC - _Dbl_MontoRETISLR - _Dbl_MontoRETIVA;
            _Dbl_MR = _Dbl_MontoND - _Dbl_MontoNC - _Dbl_MontoRETIVA - _Dbl_MontoRETISLR - _Dbl_MontoDesc;
            return _Dbl_MR;
        }


        public string _Mtd_ObtenerFechaLimite(string _Pr_Str_Fecha)
        {
            DateTime _Dt_Fecha;
            int _Int_I = 0;
            int _Int_MyDiaAux = 0;
            int _Int_MyDia = 0;
            int _Int_MyMes = 0;
            int _Int_MyAno = 0;
            //_Int_MyDiaUltMes = Convert.ToDateTime(_Pr_Str_Fecha);
            _Int_MyAno = Convert.ToDateTime(_Pr_Str_Fecha).Year;
            _Int_MyMes = Convert.ToDateTime(_Pr_Str_Fecha).Month;
            _Int_MyDia = Convert.ToDateTime(_Pr_Str_Fecha).Day;
            if (_Int_MyDia <= 15)
            {
                _Dt_Fecha = new DateTime(_Int_MyAno, _Int_MyMes, 15);
            }
            else
            {
                _Dt_Fecha = new DateTime(_Int_MyAno, _Int_MyMes, _Int_MyDia);
                do
                {
                    _Dt_Fecha = _Dt_Fecha.AddDays(1);
                }
                while (_Dt_Fecha.Day >= _Int_MyDia);
                _Dt_Fecha = _Dt_Fecha.AddDays(-1);
                _Int_MyDiaAux = _Dt_Fecha.Day;
                _Dt_Fecha = new DateTime(_Int_MyAno, _Int_MyMes, _Int_MyDiaAux);
            }
            return _Dt_Fecha.ToShortDateString();
        }

        
        //__________________________________________________________________________
        public int _Mtd_Proceso_P_CXP_ND_FALTANTE_A(string _P_Str_cidnotadebitocxp, string _P_Str_cproveedor)
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            double _Dbl_MontoTotal = 0;
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cnumdocu = "";
            string _Str_cporcinvendible = "";
            string _Str_cfechadocu = "";
            string _Str_cfechadocuVenc = "";
            string _Str_cmontosi = "";
            string _Str_cmontoimp = "";
            string _Str_cyearacco = "", _Str_cmontacco = "";
            string _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXP_ND_FALTANTE_A");
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            string _Str_Cadena = "";
            DataSet _Ds;
            _Str_Cadena = "Select cidnotadebitocxp,cfechand,cmontototsi,cimpuesto,cporcinvendible,ctotaldocu,cfvfnotadebitop from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _P_Str_cproveedor + "' and cidnotadebitocxp='" + _P_Str_cidnotadebitocxp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_cnumdocu = _Ds.Tables[0].Rows[0][0].ToString();
                _Str_cfechadocu = _Ds.Tables[0].Rows[0][1].ToString();
                _Str_cmontosi = _Ds.Tables[0].Rows[0][2].ToString();
                _Str_cmontoimp = _Ds.Tables[0].Rows[0][3].ToString();
                _Str_cporcinvendible = _Ds.Tables[0].Rows[0][4].ToString();
                _Dbl_MontoTotal = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                _Str_cfechadocuVenc = _Ds.Tables[0].Rows[0]["cfvfnotadebitop"].ToString();
            }
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());
            string _Str_Nr = "";
            string _Str_Sql = "";
            bool _Bol_Boleano = false;
            string _Str_DebeoHaber = "", _Str_corder = "", _Str_Descrip = "";
            string _Str_CountCont = "", _Str_CountContName = "";
            DataSet _Datset;
            _Str_Sql = "Select cidnotrecepc,cfechand from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _P_Str_cidnotadebitocxp + "' and cproveedor='" + _P_Str_cproveedor + "'";
            _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Datset.Tables[0].Rows.Count > 0)
            { _Str_Nr = _Datset.Tables[0].Rows[0][0].ToString(); }
            //-----------------------
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','0','0','0','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
            //-----------------------
            _Str_Cadena = "Select ccount,ctipodocumento,cnaturaleza,cideprocesod from TPROCESOSCONTD where cidproceso='P_CXP_ND_FALTANTE_A'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_DebeoHaber = "";
                _Str_corder = "";
                _Str_CountCont = _Row["ccount"].ToString();
                if (_Str_CountCont != "")
                {
                    _Str_Sql = "SELECT cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _Str_CountCont + "'";
                    _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Datset.Tables[0].Rows.Count > 0)
                    {
                        _Str_CountContName = _Datset.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
                    }
                    _Str_Descrip = _Str_CountContName + " SEGÚN ND # " + _P_Str_cidnotadebitocxp + " POR FALTANTE, DE LA FACTURA # " + _Str_cnumdocu + ", SEGÚN NR # " + _Str_Nr + " ANULACION";
                }
                else
                {
                    _Str_Descrip = "PROVEEDOR SIN CUENTA CONTABLE. SEGÚN ND # " + _P_Str_cidnotadebitocxp + " POR FALTANTE, DE LA FACTURA # " + _Str_cnumdocu + ", SEGÚN NR # " + _Str_Nr + " ANULACION";
                }
                if (_Row["cideprocesod"].ToString() == "1")
                {
                    _Str_DebeoHaber = _Dbl_MontoTotal.ToString();
                }
                if (_Row["cideprocesod"].ToString() == "2")
                {
                    _Str_DebeoHaber = _Str_cmontosi;
                }
                if (_Row["cideprocesod"].ToString() == "3")
                {
                    _Str_DebeoHaber = _Str_cmontoimp;
                }
                if (_Row["cideprocesod"].ToString() == "4")
                {
                    _Str_DebeoHaber = _Str_cporcinvendible;
                }
                
                if (_Str_DebeoHaber != "")
                {
                    if (Convert.ToDouble(_Str_DebeoHaber) > 0)
                    {
                        _Str_corder = Convert.ToString(_Mtd_Consecutivo_TCOMPROBAND(_Str_cidcomprob));
                        if (_Row["cnaturaleza"].ToString() == "D")
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(false) + "','" + _P_Str_cidnotadebitocxp + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                            _Dbl_Debe = _Dbl_Debe + Convert.ToDouble(_Str_DebeoHaber);
                        }
                        else
                        {
                            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Mtd_TipoDocumentNC_ND(false) + "','" + _P_Str_cidnotadebitocxp + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                            _Dbl_Haber = _Dbl_Haber + Convert.ToDouble(_Str_DebeoHaber);
                        }
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_CountCont, _P_Str_cproveedor, _Str_Descrip, _Mtd_TipoDocumentNC_ND(false), _P_Str_cidnotadebitocxp, _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)), _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocuVenc)), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_DebeoHaber)), _Str_cmontacco, _Str_cyearacco, _Row["cnaturaleza"].ToString().Trim().ToUpper());
                    }
                }
                _Bol_Boleano = true;
            }
            if (_Bol_Boleano)
            {
                double _Dbl_cbalanceo = 0;
                if (_Dbl_Debe > _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Debe - _Dbl_Haber; }
                else if (_Dbl_Debe < _Dbl_Haber)
                { _Dbl_cbalanceo = _Dbl_Haber - _Dbl_Debe; }
                _Str_Sql = "UPDATE TCOMPROBANC SET ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "',cbalance='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                //_Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp.ToUpper() + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
            }
            return Convert.ToInt32(_Str_cidcomprob);
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
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cfirmante FROM TUSER WHERE cuser='" + _Pr_Str_UsuId + "'");
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
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
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
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cname FROM TUSER WHERE cuser='" + _Pr_Str_UsuiD + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_R = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]);
            }
            return _Str_R;
        }

        public void _Mtd_Proceso_P_COMPRA_GRID(string _P_Str_cidnotrecepc, string _P_Str_cidrecepcion, DataGridView _P_Dg_Grid, string _Str_cnumdocu, string _Str_cfechadocu, string _Str_cmontosi, string _Str_cmontoimp)
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            string _Str_Cadena = "", _Str_Sql = "", _Str_CuentaCont="";
            DataSet _Ds;
            _Str_Cadena = "Select ccount,cauxiliar,ctipodocumento,cnaturaleza,cideprocesod from TPROCESOSCONTD where cidproceso='P_COMPRA'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //bool _Bol_Boleano = false;
            DataSet _Datset = new DataSet();
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                string _Str_Descrip = "";
                //--------------------------------
                if (_Row["ccount"].ToString() == _Str_G_CuentaContProv)
                {
                    //_Str_Sql = "SELECT * FROM VST_PROVECOUNT WHERE cglobal=1 AND cproveedor='" + _P_Str_Proveedor + "'";
                    _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Datset.Tables[0].Rows.Count > 0)
                    {
                        _Str_CuentaCont = Convert.ToString(_Datset.Tables[0].Rows[0]["ctcount"]);
                        _Str_Descrip = Convert.ToString(_Datset.Tables[0].Rows[0]["cname"]).Trim();
                    }
                }
                else
                {
                    _Str_CuentaCont = _Row["ccount"].ToString();
                    _Str_Sql = "Select cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _Str_CuentaCont + "'";
                    _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Datset.Tables[0].Rows.Count > 0)
                    {
                        _Str_Descrip = Convert.ToString(_Datset.Tables[0].Rows[0][0]).Trim();
                    }
                }
                //--------------------------------
                string _Str_DebeoHaber = "";
                if (_Row[4].ToString() == "1")
                {
                    _Str_DebeoHaber = _Str_cmontosi;
                }
                if (_Row[4].ToString() == "2")
                {
                    _Str_DebeoHaber = _Str_cmontoimp;
                }
                if (_Row[4].ToString() == "3")
                {
                    _Str_DebeoHaber = Convert.ToString(Convert.ToDouble(_Str_cmontosi) + Convert.ToDouble(_Str_cmontoimp));
                }
                //DataSet _Ds_G = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                //string _Str_corder = Convert.ToString(_Mtd_Consecutivo_TCOMPROBAND(_Str_cidcomprob));
                if (_Row[3].ToString() == "D")
                {
                    _P_Dg_Grid.Rows.Add();
                    _P_Dg_Grid[0, _P_Dg_Grid.RowCount - 1].Value = _Str_CuentaCont;
                    //cargo el name de document
                    _P_Dg_Grid[2, _P_Dg_Grid.RowCount - 1].Value = _Str_Descrip; //Convert.ToString(_Datset.Tables[0].Rows[0][0])
                    _P_Dg_Grid[3, _P_Dg_Grid.RowCount - 1].Value = Convert.ToDouble(_Str_DebeoHaber).ToString("#,###0.00");// _Str_DebeoHaber.Replace(".", "").Replace(",", ".");
                    _P_Dg_Grid[4, _P_Dg_Grid.RowCount - 1].Value = "0";
                    _Dbl_Debe = _Dbl_Debe + Convert.ToDouble(_Str_DebeoHaber);
                }
                else
                {
                    _P_Dg_Grid.Rows.Add();
                    _P_Dg_Grid[0, _P_Dg_Grid.RowCount - 1].Value = _Str_CuentaCont;
                    _P_Dg_Grid[2, _P_Dg_Grid.RowCount - 1].Value = _Str_Descrip; //Convert.ToString(_Datset.Tables[0].Rows[0][0])
                    _P_Dg_Grid[3, _P_Dg_Grid.RowCount - 1].Value = "0";
                    _P_Dg_Grid[4, _P_Dg_Grid.RowCount - 1].Value = Convert.ToDouble(_Str_DebeoHaber).ToString("#,###0.00"); //_Str_DebeoHaber.Replace(".", "").Replace(",", ".");
                    _Dbl_Haber = _Dbl_Haber + Convert.ToDouble(_Str_DebeoHaber);
                }
                _P_Dg_Grid.AllowUserToAddRows = false;
            }
        }

        public bool _Mtd_GridViewtoExcelFormatoNumerico(DataGridView _P_Dg_A, string _P_Str_FileName)
        {
            bool _Bl_R = false;
            Int64 _Int_Index = 0;
            Int64 _Int_F = 0;
            int _Int_C = 0;

            Excel.Application _ExcelApp = new Excel.Application();
            Excel.Range _ExcelRange;
            Excel.Worksheet _ExcelHoja;
            //Excel.WorkbookClass _ExcelBook;
            try
            {
                _ExcelApp.Application.Workbooks.Add(true);
                // Excel.Range _ExcelRange;

                // _ExcelBook = _ExcelApp.Workbooks.Add();
                //_ExcelHoja = _ExcelBook.Worksheets(1);


                //GUARDO ENCABEZADO
                _ExcelHoja = (Excel.Worksheet)_ExcelApp.Worksheets[1];
                foreach (DataGridViewColumn _Dg_Col in _P_Dg_A.Columns)
                {
                    if (_Int_Index != 0)
                    {
                        _ExcelApp.Cells[2, _Int_Index] = _Dg_Col.HeaderText;
                        _ExcelRange = (Excel.Range)_ExcelHoja.Cells[2, _Int_Index];
                        //_ExcelRange.AutoFit();
                        _ExcelRange.Font.Bold = true;
                    }
                    _Int_Index++;
                    //_ExcelRange = _ExcelApp.Cells[1, _Int_Index];
                    //_ExcelRange.Font.Bold = true;
                }
                DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cname FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'");

                _ExcelApp.Cells[1, 1] = "Compañía:";
                _ExcelApp.Cells[1, 2] = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]).ToUpper();
                _ExcelApp.Cells[1, 3] = "Fecha:";
                _ExcelApp.Cells[1, 4] = DateTime.Now.ToShortDateString();
                //_ExcelRange  =  _ExcelHoja.Cells[   .Range("A3:D" & (i - 1).ToString)
                //CARGO LOS DATOS
                _Int_F = 1;
                foreach (DataGridViewRow _Dg_Row in _P_Dg_A.Rows)
                {
                    _Int_F++;
                    _Int_C = 0;
                    foreach (DataGridViewColumn _Dg_Col in _P_Dg_A.Columns)
                    {
                        if (_Int_C != 0)
                        {
                            double _dbl_Monto = 0;
                            if (double.TryParse(Convert.ToString(_Dg_Row.Cells[_Int_C].Value), out _dbl_Monto))
                            {
                                _ExcelApp.Cells[_Int_F + 1, _Int_C] = _dbl_Monto;
                                ((Excel.Range)_ExcelApp.Cells[_Int_F + 1, _Int_C]).NumberFormat = "#,##0.00";
                            }
                            else
                            {
                                _ExcelApp.Cells[_Int_F + 1, _Int_C] = Convert.ToString(_Dg_Row.Cells[_Int_C].Value);
                            }
                            _ExcelRange = (Excel.Range)_ExcelHoja.Cells[_Int_F + 1, _Int_C];
                            if (_Int_F == _P_Dg_A.RowCount)
                            {
                                _ExcelRange.Font.Bold = true;
                            }
                            //_ExcelRange.Select();
                            //_ExcelRange.Columns.AutoFit();
                            //_ExcelApp.Columns.AutoFit();
                        }
                        _Int_C++;
                    }
                }
                _ExcelApp.Columns.AutoFit();
                //_ExcelRange = _ExcelHoja.get_Range("1", "50");
                //_ExcelRange.Select();
                //_ExcelRange = _ExcelHoja.get_Range("A1","C5");
                //_ExcelRange.Columns.AutoFit();
                //_ExcelApp.Save(_P_Str_FileName);
                foreach (Excel.Workbook _oWB in _ExcelApp.Application.Workbooks)
                {
                    _oWB.SaveCopyAs(_P_Str_FileName);
                    _oWB.Close(false, false, Missing.Value);

                }

                //_ExcelApp.Application.Workbooks.Close();
                _ExcelApp.Quit();
                _ExcelApp = null;
                _Bl_R = true;
            }
            catch (Exception _Ex)
            {
                foreach (Excel.Workbook _oWB in _ExcelApp.Application.Workbooks)
                {
                    _oWB.Close(false, false, Missing.Value);
                }
                _ExcelApp.Quit();
                _ExcelApp = null;
                _Bl_R = false;
                throw new Exception(_Ex.Message);
            }
            return _Bl_R;
        }

        public bool _Mtd_GridViewtoExcel(DataGridView _P_Dg_A, string _P_Str_FileName)
        {
            bool _Bl_R = false;
            Int64 _Int_Index = 0;
            Int64 _Int_F = 0;
            int _Int_C = 0;

            Excel.Application _ExcelApp = new Excel.Application();
            Excel.Range _ExcelRange;
            Excel.Worksheet _ExcelHoja;
            //Excel.WorkbookClass _ExcelBook;
            try
            {
                _ExcelApp.Application.Workbooks.Add(true);
                // Excel.Range _ExcelRange;

                // _ExcelBook = _ExcelApp.Workbooks.Add();
                //_ExcelHoja = _ExcelBook.Worksheets(1);


                //GUARDO ENCABEZADO
                _ExcelHoja = (Excel.Worksheet)_ExcelApp.Worksheets[1];
                foreach (DataGridViewColumn _Dg_Col in _P_Dg_A.Columns)
                {
                    if (_Int_Index != 0)
                    {
                        _ExcelApp.Cells[2, _Int_Index] = _Dg_Col.HeaderText;
                        _ExcelRange = (Excel.Range)_ExcelHoja.Cells[2, _Int_Index];
                        //_ExcelRange.AutoFit();
                        _ExcelRange.Font.Bold = true;
                    }
                    _Int_Index++;
                    //_ExcelRange = _ExcelApp.Cells[1, _Int_Index];
                    //_ExcelRange.Font.Bold = true;
                }
                DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cname FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'");

                _ExcelApp.Cells[1, 1] = "Compañía:";
                _ExcelApp.Cells[1, 2] = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]).ToUpper();
                _ExcelApp.Cells[1, 3] = "Fecha:";
                _ExcelApp.Cells[1, 4] = DateTime.Now.ToShortDateString();
                //_ExcelRange  =  _ExcelHoja.Cells[   .Range("A3:D" & (i - 1).ToString)
                //CARGO LOS DATOS
                _Int_F = 1;
                foreach (DataGridViewRow _Dg_Row in _P_Dg_A.Rows)
                {
                    _Int_F++;
                    _Int_C = 0;
                    foreach (DataGridViewColumn _Dg_Col in _P_Dg_A.Columns)
                    {
                        if (_Int_C != 0)
                        {
                            _ExcelApp.Cells[_Int_F + 1, _Int_C] = Convert.ToString(_Dg_Row.Cells[_Int_C].Value);
                            _ExcelRange = (Excel.Range)_ExcelHoja.Cells[_Int_F + 1, _Int_C];
                            if (_Int_F == _P_Dg_A.RowCount)
                            {
                                _ExcelRange.Font.Bold = true;
                            }
                            //_ExcelRange.Select();
                            //_ExcelRange.Columns.AutoFit();
                            //_ExcelApp.Columns.AutoFit();
                        }
                        _Int_C++;
                    }
                }
                _ExcelApp.Columns.AutoFit();
                //_ExcelRange = _ExcelHoja.get_Range("1", "50");
                //_ExcelRange.Select();
                //_ExcelRange = _ExcelHoja.get_Range("A1","C5");
                //_ExcelRange.Columns.AutoFit();
                //_ExcelApp.Save(_P_Str_FileName);
                foreach (Excel.Workbook _oWB in _ExcelApp.Application.Workbooks)
                {
                    _oWB.SaveCopyAs(_P_Str_FileName);
                    _oWB.Close(false, false, Missing.Value);

                }

                //_ExcelApp.Application.Workbooks.Close();
                _ExcelApp.Quit();
                _ExcelApp = null;
                _Bl_R = true;
            }
            catch (Exception _Ex)
            {
                foreach (Excel.Workbook _oWB in _ExcelApp.Application.Workbooks)
                {
                    _oWB.Close(false, false, Missing.Value);
                }
                _ExcelApp.Quit();
                _ExcelApp = null;
                _Bl_R = false;
                throw new Exception(_Ex.Message);
            }
            return _Bl_R;
        }

        public void _Mtd_CerrarFormHijo(Frm_Padre _Pr_Frm_Padre, string _Pr_Str_FormHijoName)
        {
            try
            {
                foreach (Form _Frm_Hijo in _Pr_Frm_Padre.MdiChildren)
                {
                    if (_Frm_Hijo.Name == _Pr_Str_FormHijoName)
                    {
                        _Frm_Hijo.Close();
                    }
                }
            }
            catch { }
        }

        public bool _Mtd_CompaniaRetieneImp(string _Pr_Str_Comp)
        {
            bool _Bl_R = false;
            string _Str_Sql = "";
            _Str_Sql = "SELECT TCONTRIBUYENTE.cretieneimp FROM TCOMPANY INNER JOIN " +
            "TCONTRIBUYENTE ON TCOMPANY.ctip_contribuy COLLATE DATABASE_DEFAULT = TCONTRIBUYENTE.ccontribuyente WHERE TCOMPANY.ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) == "1")
                { _Bl_R = true; }
                else
                { _Bl_R = false; }
            }
            else
            { _Bl_R = false; }
            return _Bl_R;
        }
        public void _Mtd_Inyeccion_Sql(Control _P_Ctrl_Control)
        {            
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Inyeccion_Sql(_Ctrl);
                }
                else if (_Ctrl.GetType() == typeof(TextBox) | _Ctrl.GetType().ToString().Trim() == "System.Windows.Forms.ToolStripComboBox+ToolStripComboBoxControl")
                {
                    _Ctrl.KeyPress += new KeyPressEventHandler(_Cls_Varios_Metodos_KeyPress);
                    _Ctrl.TextChanged += new EventHandler(_Cls_Varios_Metodos_TextChanged);
                }
            }
        }
        public void _Mtd_Inyeccion_Sql(Control _P_Ctrl_Control,bool _Bol_Guion)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Inyeccion_Sql(_Ctrl, true);
                }
                else if (_Ctrl.GetType() == typeof(TextBox) | _Ctrl.GetType().ToString().Trim() == "System.Windows.Forms.ToolStripComboBox+ToolStripComboBoxControl")
                {
                    _Ctrl.KeyPress += new KeyPressEventHandler(_Cls_Varios_Metodos_KeyPress_2);
                    _Ctrl.TextChanged += new EventHandler(_Cls_Varios_Metodos_TextChanged_2);
                }
            }
        }
        public void _Mtd_CargarLista(ListBox _Pr_Lst, string _Pr_Str_Sql)
        {
            DataSet _Ds;
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Pr_Lst.DataSource = null;
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Pr_Str_Sql);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString(), _DRow[0].ToString()));
            }
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Pr_Lst.DataSource = _myArrayList;
                _Pr_Lst.DisplayMember = "Display";
                _Pr_Lst.ValueMember = "Value";
            }
        }
        void _Cls_Varios_Metodos_TextChanged(object sender, EventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
            //if()
            if (_Mtd_Analizar_Texto(((Control)sender).Text))
            { ((Control)sender).Text = ""; }
        }

        void _Cls_Varios_Metodos_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
            if (e.KeyChar.ToString() == "'" | e.KeyChar.ToString() == "*" | e.KeyChar.ToString() == "-" | e.KeyChar.ToString() == "=" | e.KeyChar.ToString() == "%")
            {
                e.Handled = true;
            }
        }
        void _Cls_Varios_Metodos_TextChanged_2(object sender, EventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
            //if()
            if (_Mtd_Analizar_Texto(((Control)sender).Text,true))
            { ((Control)sender).Text = ""; }
        }

        void _Cls_Varios_Metodos_KeyPress_2(object sender, KeyPressEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
            if (e.KeyChar.ToString() == "'" | e.KeyChar.ToString() == "*" | e.KeyChar.ToString() == "=" | e.KeyChar.ToString() == "%")
            {
                e.Handled = true;
            }
        }
        public bool _Mtd_Analizar_Texto(string _P_Str_Text)
        {
            bool _Bol_Boleano = false;
            int _Int_i = _P_Str_Text.Trim().IndexOf("-");
            if (_Int_i != -1)
            { _Bol_Boleano = true; }
            _Int_i = _P_Str_Text.Trim().IndexOf("*");
            if (_Int_i != -1)
            { _Bol_Boleano = true; }
            _Int_i = _P_Str_Text.Trim().IndexOf("'");
            if (_Int_i != -1)
            { _Bol_Boleano = true; }
            _Int_i = _P_Str_Text.Trim().IndexOf("=");
            if (_Int_i != -1)
            { _Bol_Boleano = true; }
            _Int_i = _P_Str_Text.Trim().IndexOf("%");
            if (_Int_i != -1)
            { _Bol_Boleano = true; }
            return _Bol_Boleano;
        }
        public bool _Mtd_Analizar_Texto(string _P_Str_Text,bool _Bol_Guion)
        {
            bool _Bol_Boleano = false;
            int _Int_i = _P_Str_Text.Trim().IndexOf("*");
            if (_Int_i != -1)
            { _Bol_Boleano = true; }
            _Int_i = _P_Str_Text.Trim().IndexOf("'");
            if (_Int_i != -1)
            { _Bol_Boleano = true; }
            _Int_i = _P_Str_Text.Trim().IndexOf("=");
            if (_Int_i != -1)
            { _Bol_Boleano = true; }
            _Int_i = _P_Str_Text.Trim().IndexOf("%");
            if (_Int_i != -1)
            { _Bol_Boleano = true; }
            return _Bol_Boleano;
        }
        public double _Mtd_ObtenerAbonoOrdPago(string _Pr_Str_NumDoc, string _Pr_Str_TpoDoc, string _Pr_Str_ProvId)
        {
            string _Str_Sql = "";
            double _Dbl_R = 0;
            _Str_Sql = "select sum(cmontocancelar) from VST_PAGOS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _Pr_Str_ProvId + "' and cnumdocu='" + _Pr_Str_NumDoc + "' and ctipodocument='" + _Pr_Str_TpoDoc + "' and canulado=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                { _Dbl_R = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]); }
            }
            return _Dbl_R;
        }

        public double _Mtd_ObtenerRestanteOrdPago(string _Pr_Str_NumDoc, string _Pr_Str_TpoDoc, string _Pr_Str_ProvId)
        {
            double _Dbl_Abono = 0;
            double _Dbl_Total = 0;
            _Dbl_Abono = _Mtd_ObtenerAbonoOrdPago(_Pr_Str_NumDoc, _Pr_Str_TpoDoc, _Pr_Str_ProvId);
            string _Str_Sql = "select ctotal-ISNULL(cmontoplanahorro,0) from TFACTPPAGARM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _Pr_Str_ProvId + "' and cnumdocu='" + _Pr_Str_NumDoc + "' and ctipodocument='" + _Pr_Str_TpoDoc + "' and canulado=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                double.TryParse(Convert.ToString(_Ds.Tables[0].Rows[0][0]), out _Dbl_Total);
            }
            return _Dbl_Total - _Dbl_Abono;
        }
        public void _Mtd_Cerrar_T3_Popup(string _P_Str_Proceso)
        {
            try
            {
                System.Diagnostics.Process[] _System = System.Diagnostics.Process.GetProcessesByName(_P_Str_Proceso);
                if (_System.Length > 0)
                {
                    if (!_System[0].HasExited)
                    {
                        _System[0].Kill();
                        _System[0].Close();
                    }
                }
            }
            catch { }
        }
        public string _Mtd_GetGlobalProveedorporId(string _Pr_Str_ProvId)
        {
            string _Str_R = "";
            string _Str_Sql = "";
            _Str_Sql = "SELECT cglobal FROM TPROVEEDOR WHERE (cglobal='1' OR ccompany='" + Frm_Padre._Str_Comp + "') AND cproveedor='" + _Pr_Str_ProvId + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count == 1)
            { _Str_R = Convert.ToString(_Ds.Tables[0].Rows[0][0]); }
            else if (_Ds.Tables[0].Rows.Count > 1)
            {
                _Str_Sql = _Str_Sql + " and ccompany='" + Frm_Padre._Str_Comp + "'";
                DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    _Str_R = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]);
                }
            }
            return _Str_R;
        }
        public bool _Mtd_ObtenerStsImpresoRETIVAxFact(string _Pr_Str_ProvId, string _Pr_Str_NumDoc, string _P_Str_TipoDocument)
        {
            if (_P_Str_TipoDocument.Trim().Length == 0 || _P_Str_TipoDocument == _Mtd_TipoDocumentFACT_CXP("ctipdocfact") || _P_Str_TipoDocument == _Mtd_TipoDocumentFACT_CXP("ctipodocndp"))
            {
                string _Str_Sql = "";
                bool _Bol_R = false;
                _Str_Sql = "select COUNT(*) from TCOMPROBANRETC where ccompany='" + Frm_Padre._Str_Comp + "' and cnumdocumafec='" + _Pr_Str_NumDoc + "' and cimpreso=0 and canulado=0 and cproveedor='" + _Pr_Str_ProvId + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                    {
                        if (Convert.ToInt32(_Ds.Tables[0].Rows[0][0]) > 0)
                        {
                            _Bol_R = true; //EXISTEN RETENCIONES DE IVA POR IMPRIMIR
                        }
                    }
                }
                return _Bol_R;
            }
            return false;
        }

        public bool _Mtd_ObtenerStsImpresoRETISLRxFact(string _Pr_Str_ProvId, string _Pr_Str_NumDoc, string _P_Str_TipoDocument)
        {
            if (_P_Str_TipoDocument.Trim().Length>0 || _P_Str_TipoDocument == _Mtd_TipoDocumentFACT_CXP("ctipdocfact") || _P_Str_TipoDocument == _Mtd_TipoDocumentFACT_CXP("ctipodocndp"))
            {
                string _Str_Sql = "";
                bool _Bol_R = false;
                _Str_Sql = "select COUNT(*) from TCOMPROBANISLRC where ccompany='" + Frm_Padre._Str_Comp + "' and cnumdocumafec='" + _Pr_Str_NumDoc + "' and cimpreso=0 and canulado=0 and cproveedor='" + _Pr_Str_ProvId + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                    {
                        if (Convert.ToInt32(_Ds.Tables[0].Rows[0][0]) > 0)
                        {
                            _Bol_R = true; //EXISTEN RETENCIONES DE ISLR POR IMPRIMIR
                        }
                    }
                }
                return _Bol_R;
            }
            return false;
        }
        public bool _Mtd_ObtenerStsImpresoRETPatentexFact(string _Pr_Str_ProvId, string _Pr_Str_NumDoc, string _P_Str_TipoDocument)
        {
            if (_P_Str_TipoDocument.Trim().Length > 0 || _P_Str_TipoDocument == _Mtd_TipoDocumentFACT_CXP("ctipdocfact") || _P_Str_TipoDocument == _Mtd_TipoDocumentFACT_CXP("ctipodocndp"))
            {
                string _Str_Sql = "";
                bool _Bol_R = false;
                _Str_Sql = "select COUNT(*) from TCOMPROBANRETPAT where ccompany='" + Frm_Padre._Str_Comp + "' and cnumdocumafec='" + _Pr_Str_NumDoc + "' and cimpreso=0 and canulado=0 and cproveedor='" + _Pr_Str_ProvId + "' and caprobado=1";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                    {
                        if (Convert.ToInt32(_Ds.Tables[0].Rows[0][0]) > 0)
                        {
                            _Bol_R = true; //EXISTEN RETENCIONES DE ISLR POR IMPRIMIR
                        }
                    }
                }
                return _Bol_R;
            }
            return false;
        }
        public void _Mtd_Formato_Porcentaje(TextBox _P_Txt_TextboxP)
        {
            _P_Txt_TextboxP.KeyPress += new KeyPressEventHandler(_P_Txt_TextboxP_KeyPress);
            _P_Txt_TextboxP.TextChanged += new EventHandler(_P_Txt_TextboxP_TextChanged);
            _P_Txt_TextboxP.Leave += new EventHandler(_P_Txt_TextboxP_Leave);
        }

        void _P_Txt_TextboxP_Leave(object sender, EventArgs e)
        {
            try
            {
                if (((TextBox)sender).Text.IndexOf(",") == ((TextBox)sender).Text.Length - 1)
                { ((TextBox)sender).Text = ((TextBox)sender).Text.Substring(0, ((TextBox)sender).Text.Length - 1); }
            }
            catch { }
        }

        void _P_Txt_TextboxP_TextChanged(object sender, EventArgs e)
        {
            string _Str_Cadena = "";
            try
            {
                if (((TextBox)sender).Text.IndexOf(",") == 3)
                { ((TextBox)sender).Text = ((TextBox)sender).Text.Substring(0, ((TextBox)sender).Text.Length - 1); ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length; }
                _Str_Cadena = CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(((TextBox)sender).Text.Trim()));
                if (!_Mtd_IsNumeric(_Str_Cadena))
                {
                    ((TextBox)sender).Text = "";
                }
                else if (((TextBox)sender).Text.Trim().Length > 0)
                {
                    if (Convert.ToDouble(((TextBox)sender).Text) > 100)
                    { ((TextBox)sender).Text = "100"; ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length; }
                }
            }
            catch { ((TextBox)sender).Text = ""; }
        }

        void _P_Txt_TextboxP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)
            {
                e.Handled = true;
            }
        }
        public void _Mtd_Formato_Moneda(TextBox _P_Txt_Textbox)
        {
            _P_Txt_Textbox.KeyPress += new KeyPressEventHandler(_P_Txt_Textbox_KeyPress);
            _P_Txt_Textbox.Leave += new EventHandler(_P_Txt_Textbox_Leave);
            _P_Txt_Textbox.TextChanged += new EventHandler(_P_Txt_Textbox_TextChanged);
        }

        void _P_Txt_Textbox_TextChanged(object sender, EventArgs e)
        {
            string _Str_Cadena = "";
            try
            {
                _Str_Cadena = CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(((TextBox)sender).Text.Trim()));
                if (!_Mtd_IsNumeric(_Str_Cadena))
                {
                    ((TextBox)sender).Text = "";
                }
            }
            catch { ((TextBox)sender).Text = ""; }
        }
        
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        
        void _P_Txt_Textbox_Leave(object sender, EventArgs e)
        {
            try
            {
                string _Str_Cadena = "Select dbo.Fnc_Formatear(" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(((TextBox)sender).Text.Trim())) + ")";
                ((TextBox)sender).Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString();
            }
            catch { }
        }

        void _P_Txt_Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)
            {
                e.Handled = true;
            }
            else if ((((TextBox)sender).Text.Trim().Length > 10 & ((TextBox)sender).Text.Trim().IndexOf(",") == -1 & ((TextBox)sender).Text.Trim().IndexOf(".") == -1) && e.KeyChar != 8)
            { e.Handled = true; }
        }
        public static void _Mtd_EnviarEmail(string _P_Str_Proceso, string[] _P_Str_ParamReplace, string[] _P_Str_ParamNew)
        {
            string _Str_Asunto = "";
            string _Str_Cuerpo = "";
            string _Str_Cadena = "Select casunto,ccuerpo from TWFEMAILPROC INNER JOIN TWFEMAILPROCD ON TWFEMAILPROC.cidprocesos=TWFEMAILPROCD.cidprocesos where TWFEMAILPROC.cidprocesos='" + _P_Str_Proceso + "' AND TWFEMAILPROCD.ccompany='" + Frm_Padre._Str_Comp + "'";
            string _Str_Para = "";
            string _Str_Copia = "";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Asunto = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                _Str_Cuerpo = _Ds.Tables[0].Rows[0][1].ToString().Trim();
                _Str_Cadena = "Select cemailpara1,cemailpara2,cemailpara3,cemailpara4,cemailpara5 from TWFEMAILPROCD where cidprocesos='" + _P_Str_Proceso + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    DataRow _Row = _Ds.Tables[0].Rows[0];
                    bool _Bol_Sw = false;
                    foreach (DataColumn _Col in _Ds.Tables[0].Columns)
                    {
                        if (_Row[_Col].ToString().Trim().Length > 0)
                        {
                            if (_Bol_Sw)
                            { _Str_Para = _Str_Para + ","; }
                            _Str_Para = _Str_Para + _Row[_Col].ToString().Trim().ToUpper();
                            _Bol_Sw = true;
                        }
                    }
                }
                _Str_Cadena = "Select cemailcco1,cemailcco2,cemailcco3,cemailcco4,cemailcco5 from TWFEMAILPROCD where cidprocesos='" + _P_Str_Proceso + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    DataRow _Row = _Ds.Tables[0].Rows[0];
                    bool _Bol_Sw = false;
                    foreach (DataColumn _Col in _Ds.Tables[0].Columns)
                    {
                        if (_Row[_Col].ToString().Trim().Length > 0)
                        {
                            if (_Bol_Sw)
                            { _Str_Copia = _Str_Copia + ","; }
                            _Str_Copia = _Str_Copia + _Row[_Col].ToString().Trim().ToUpper();
                            _Bol_Sw = true;
                        }
                    }
                }
                int _Int_Index = 0;
                foreach (string _Str in _P_Str_ParamReplace)
                {
                    _Str_Asunto = _Str_Asunto.Replace(_Str, _P_Str_ParamNew[_Int_Index]);
                    _Str_Cuerpo = _Str_Cuerpo.Replace(_Str, _P_Str_ParamNew[_Int_Index]);
                    _Int_Index++;
                }
                _Str_Cadena = "Insert into TEMAIL (cproceso,cfecha,cemailpara,cemailcco,casunto,ccuepoms)values('" + _P_Str_Proceso + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + _Str_Para + "','" + _Str_Copia + "','" + _Str_Asunto + "','" + _Str_Cuerpo.Replace("'", "''") + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }

        }
        /// <summary>
        /// Metodo de convierte un matriz de bytes en un archivo especificando el nombre
        /// </summary>
        /// <param name="_by_p_">Matriz de bytes del archivo</param>
        /// <param name="_Pr_Str_FilePath">Path completo del archivo</param>
        public void _Mtd_ConvertByteToFile(byte[] _by_p_, string _Pr_Str_FilePath)
        {
            if (System.IO.File.Exists(_Pr_Str_FilePath))
            {
                System.IO.File.SetAttributes(_Pr_Str_FilePath, System.IO.FileAttributes.Normal);

                //System.IO.File.Delete(_Pr_Str_FilePath);
            }
            System.IO.FileStream _MyFile = new System.IO.FileStream(_Pr_Str_FilePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            System.IO.BinaryWriter _writer = new System.IO.BinaryWriter(_MyFile);
            _writer.Write(_by_p_);
            _writer.Close();
            _MyFile.Close();
        }

        /// <summary>
        /// GENERA EL COMPROBANTE CONTABLE PARA LA EMISION DE NOTA DE DEBITO POR CUENTAS POR COBRAR
        /// </summary>
        /// <param name="_Pr_Str_ND"></param>
        /// <returns></returns>
        public string _Mtd_Proceso_P_CXC_ND(string _Pr_Str_ND, string _P_Str_Proceso)
        {
            clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
            string _Str_Sql = "";
            string _Str_cidcomprob = "";
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            string _Str_FechaEmi = "";
            string _Str_NumDoc = "";
            double _Dbl_MontoTot = 0;
            double _Dbl_MontoSimp = 0;
            double _Dbl_MontoImp = 0;
            double _Dbl_Monto = 0;
            string _Str_ccount = "";
            string _Str_ctdocument = "";
            string _Str_cdescrip = "";
            string _Str_cdescripS = "";
            int _Int_corder = 0;
            string _Str_ClienteND = "";
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont(_P_Str_Proceso);
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            DataSet _Ds;
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());

            _Str_Sql = "SELECT cmontototsi + ISNULL(cexento,0) as cmontototsi, cimpuesto, ctotaldocu, cfecha, cnumdocu, ccliente FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocc='" + _Pr_Str_ND + "' AND cdelete=0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototsi"]) != "")
                { _Dbl_MontoSimp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototsi"]); }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cimpuesto"]) != "")
                { _Dbl_MontoImp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]); }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctotaldocu"]) != "")
                { _Dbl_MontoTot = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]); }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cfecha"]) != "")
                {
                    _Str_FechaEmi = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfecha"]).ToShortDateString();
                }
                _Str_NumDoc = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumdocu"]);
                _Str_ClienteND = Convert.ToString(_Ds.Tables[0].Rows[0]["ccliente"]);
            }
            _Str_cdescripS = " ND EMIT " + _Str_FechaEmi + " DESDE " + _Str_NumDoc + " HASTA " + _Str_NumDoc;
            //GUARDO LA CABECERA
            _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) values ('";
            _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTot) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTot) + "',0,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0,'0')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
            //GUARDO EL DETALLE
            _Str_Sql = "select * from VST_PROCESOSCONTD where cidproceso='" + _P_Str_Proceso + "' and (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL) order by cideprocesod";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Int_corder++;
                _Str_ccount = Convert.ToString(_Drow["ccount"]);
                _Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
                _Str_cdescrip = Convert.ToString(_Drow["ccountname"]);

                if (Convert.ToString(_Drow["cideprocesod"])=="1")
                {//CUENTAS POR COBRAR (DEBE)
                    _Dbl_Monto = _Dbl_MontoTot;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "2")
                {//VENTAS (HABER)
                    _Dbl_Monto = _Dbl_MontoSimp;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "3")
                {//IVA (HABER)
                    _Dbl_Monto = _Dbl_MontoImp;
                }
                _Str_cdescrip = _Str_cdescrip + _Str_cdescripS;
                if (_Dbl_Monto > 0)
                {
                    if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                    {
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                    }
                    else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                    {
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
                    }
                    _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Str_NumDoc + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_ccount, _Str_ClienteND, _Str_cdescrip, _Mtd_TipoDocument_CXC("ctipdocnotdeb"), _Pr_Str_ND, _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), _Str_cmontacco, _Str_cyearacco, Convert.ToString(_Drow["cnaturaleza"]).Trim().ToUpper());
                }
            }
            _Str_Sql = "UPDATE TCOMPROBANC SET cstatus='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_cidcomprob + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            return _Str_cidcomprob;
        }
        public string _Mtd_Proceso_P_CXC_ND(string _Pr_Str_NDmin, string _Pr_Str_NDmax, double _Pr_Dbl_MontoSimp, double _Pr_Dbl_MontoImp, double _Pr_Dbl_MontoTotal)
        {
            clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
            string _Str_Sql = "";
            string _Str_cidcomprob = "";
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            string _Str_FechaEmi = "";
            string _Str_NumDoc = "";
            double _Dbl_Monto = 0;
            string _Str_ccount = "";
            string _Str_ctdocument = "";
            string _Str_cdescrip = "";
            string _Str_cdescripS = "";
            int _Int_corder = 0;

            DataSet _Ds;
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXC_ND");
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());

            _Str_FechaEmi = _Mtd_SQLGetDate().ToShortDateString();
            _Str_cdescripS = " ND EMIT " + _Str_FechaEmi + " DESDE " + _Pr_Str_NDmin + " HASTA " + _Pr_Str_NDmax;
            //GUARDO LA CABECERA
            _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) values ('";
            _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Pr_Dbl_MontoTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Pr_Dbl_MontoTotal) + "',0,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0,'0')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            //GUARDO EL DETALLE

            _Str_Sql = "select * from VST_PROCESOSCONTD where cidproceso='P_CXC_ND' and (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL) order by cideprocesod";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Int_corder++;
                _Str_ccount = Convert.ToString(_Drow["ccount"]);
                _Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
                _Str_cdescrip = Convert.ToString(_Drow["ccountname"]);

                if (Convert.ToString(_Drow["cideprocesod"]) == "1")
                {//CUENTAS POR COBRAR (DEBE)
                    _Dbl_Monto = _Pr_Dbl_MontoTotal;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "2")
                {//VENTAS (HABER)
                    _Dbl_Monto = _Pr_Dbl_MontoSimp;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "3")
                {//IVA (HABER)
                    _Dbl_Monto = _Pr_Dbl_MontoImp;
                }
                _Str_cdescrip = _Str_cdescrip + _Str_cdescripS;
                if (_Dbl_Monto > 0)
                {
                    if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                    {
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                    }
                    else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                    {
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
                    }
                    _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Str_NumDoc + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
            }
            return _Str_cidcomprob;
        }
        /// <summary>
        /// GENERA EL COMPROBANTE CONTABLE PARA LA ANULACION DE LA NOTA DE DEBITO POR CUENTAS POR COBRAR
        /// </summary>
        /// <param name="_Pr_Str_ND"></param>
        /// <returns></returns>
        public string _Mtd_Proceso_P_CXC_ND_A(string _Pr_Str_ND, string _P_Str_Proceso)
        {
            clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
            string _Str_Sql = "";
            string _Str_cidcomprob = "";
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            //string _Str_FactFirst = "";
            //string _Str_FactLast = "";
            string _Str_FechaEmi = "";
            string _Str_NumDoc = "";
            double _Dbl_MontoTot = 0;
            double _Dbl_MontoSimp = 0;
            double _Dbl_MontoImp = 0;
            double _Dbl_Monto = 0;
            string _Str_ccount = "";
            string _Str_ctdocument = "";
            string _Str_cdescrip = "";
            string _Str_cdescripS = "";
            int _Int_corder = 0;
            string _Str_ClienteND = "";
            string _Str_FechaVenc = "";
            DataSet _Ds;
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont(_P_Str_Proceso);
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());
            _Str_Sql = "SELECT cmontototsi + ISNULL(cexento,0) as cmontototsi, cimpuesto, ctotaldocu, cfecha, cnumdocu, ccliente, cfvfnotadebitop FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocc='" + _Pr_Str_ND + "' AND cdelete=0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototsi"]) != "")
                { _Dbl_MontoSimp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototsi"]); }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cimpuesto"]) != "")
                { _Dbl_MontoImp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]); }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctotaldocu"]) != "")
                { _Dbl_MontoTot = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]); }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cfecha"]) != "")
                {
                    _Str_FechaEmi = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfecha"]).ToShortDateString();
                }
                _Str_NumDoc = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumdocu"]);
                _Str_ClienteND = Convert.ToString(_Ds.Tables[0].Rows[0]["ccliente"]);
                _Str_FechaVenc = Convert.ToString(_Ds.Tables[0].Rows[0]["cfvfnotadebitop"]);
            }
            _Str_cdescripS = " ND ANUL " + DateTime.Now.ToShortDateString() + " # " + _Pr_Str_ND;
            //GUARDO LA CABECERA
            _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) values ('";
            _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTot) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTot) + "',0,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0,'0')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
            //GUARDO EL DETALLE

            _Str_Sql = "select * from VST_PROCESOSCONTD where cidproceso='" + _P_Str_Proceso + "' and (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL) order by cideprocesod";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Int_corder++;
                _Str_ccount = Convert.ToString(_Drow["ccount"]);
                _Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
                _Str_cdescrip = Convert.ToString(_Drow["ccountname"]);

                if (Convert.ToString(_Drow["cideprocesod"]) == "1")
                {//CUENTAS POR COBRAR (HABER)
                    _Dbl_Monto = _Dbl_MontoSimp;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "2")
                {//VENTAS (DEBE)
                    _Dbl_Monto = _Dbl_MontoImp;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "3")
                {//IVA (DEBE)
                    _Dbl_Monto = _Dbl_MontoTot;
                }
                _Str_cdescrip = _Str_cdescrip + _Str_cdescripS + " ANULACIÓN";
                if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                {
                    _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                }
                else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                {
                    _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
                }
                _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Str_NumDoc + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_ccount, _Str_ClienteND, _Str_cdescrip, _Mtd_TipoDocument_CXC("ctipdocnotdeb"), _Pr_Str_ND, _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)), _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaVenc)), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), _Str_cmontacco, _Str_cyearacco, Convert.ToString(_Drow["cnaturaleza"]).Trim().ToUpper());
            }
            _Str_Sql = "UPDATE TCOMPROBANC SET cstatus='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_cidcomprob + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            return _Str_cidcomprob;
        }
        /// <summary>
        /// GENERA EL COMPROBANTE CONTABLE PARA LA EMISION DE NOTA DE CREDITO POR CUENTAS POR COBRAR
        /// </summary>
        /// <param name="_Pr_Str_NC"></param>
        /// <returns></returns>
        public string _Mtd_Proceso_P_CXC_NC(string _Pr_Str_NC, string _P_Str_Proceso)
        {
            clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
            string _Str_Sql = "";
            string _Str_cidcomprob = "";
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            string _Str_FechaEmi = "";
            string _Str_NumDoc = "";
            double _Dbl_MontoTot = 0;
            double _Dbl_MontoSimp = 0;
            double _Dbl_MontoImp = 0;
            double _Dbl_MontoDesc = 0;
            double _Dbl_Monto = 0;
            string _Str_ccount = "";
            string _Str_ctdocument = "";
            string _Str_cdescrip = "";
            string _Str_cdescripS = "";
            int _Int_corder = 0;
            string _Str_ClienteNC = "";
            DataSet _Ds;
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont(_P_Str_Proceso);
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());
            _Str_Sql = "SELECT SUM(cmontosimp + ISNULL(cbasexcenta,0)) AS cmontototsi,SUM(cimpuesto) AS cimpuesto,SUM(cmontototal) AS ctotaldocu,SUM(ISNULL(cmontosimpdpp,0)) AS cmontosimpdpp,SUM(ISNULL(cimpuestodpp,0)) AS cimpuestodpp,SUM(ISNULL(cbasexcentadpp,0)) AS cbasexcentadpp,SUM(ISNULL(cmontototaldpp,0)) AS cmontototaldpp FROM TNOTACREDICCD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _Pr_Str_NC + "' GROUP BY cidnotcredicc";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototsi"]).Length > 0)
                {
                    _Dbl_MontoSimp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototsi"]) + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontosimpdpp"]) + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cbasexcentadpp"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cimpuesto"]).Length > 0)
                {
                    _Dbl_MontoImp =  Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctotaldocu"]).Length > 0)
                {
                    _Dbl_MontoTot =  Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototaldpp"]).Length > 0)
                {
                    _Dbl_MontoDesc = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontosimpdpp"]) + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cbasexcentadpp"]);
                }
                _Str_Sql = "SELECT cfecha, cnumdocu, ccliente FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _Pr_Str_NC + "' AND cdelete=0";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["cfecha"]) != "")
                    {
                        _Str_FechaEmi = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfecha"]).ToShortDateString();
                    }
                    _Str_NumDoc = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumdocu"]);
                    _Str_ClienteNC = Convert.ToString(_Ds.Tables[0].Rows[0]["ccliente"]);
                }
            }
            else
            {
                _Str_Sql = "SELECT cmontototsi + ISNULL(cexento,0) as cmontototsi, cimpuesto, ctotaldocu, cfecha, cnumdocu, ccliente FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _Pr_Str_NC + "' AND cdelete=0";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototsi"]) != "")
                    { _Dbl_MontoSimp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototsi"]); }
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["cimpuesto"]) != "")
                    { _Dbl_MontoImp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]); }
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctotaldocu"]) != "")
                    { _Dbl_MontoTot = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]); }
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["cfecha"]) != "")
                    {
                        _Str_FechaEmi = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfecha"]).ToShortDateString();
                    }
                    _Str_NumDoc = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumdocu"]);
                    _Str_ClienteNC = Convert.ToString(_Ds.Tables[0].Rows[0]["ccliente"]);
                }
            }
            _Str_cdescripS = " NC EMIT " + _Str_FechaEmi + " DESDE " + _Pr_Str_NC + " HASTA " + _Pr_Str_NC;
            //GUARDO LA CABECERA
            _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) values ('";
            _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _My_Formato._Mtd_fecha(_Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTot + _Dbl_MontoDesc) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTot + _Dbl_MontoDesc) + "',0,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0,'0')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
            //GUARDO EL DETALLE
            _Str_Sql = "select * from VST_PROCESOSCONTD where cidproceso='" + _P_Str_Proceso + "' AND (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL) order by cideprocesod";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Int_corder++;
                _Str_ccount = Convert.ToString(_Drow["ccount"]);
                _Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
                _Str_cdescrip = Convert.ToString(_Drow["ccountname"]);

                if (Convert.ToString(_Drow["cideprocesod"]) == "1")
                {
                    _Dbl_Monto = _Dbl_MontoSimp;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "2")
                {
                    _Dbl_Monto = _Dbl_MontoImp;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "3")
                {
                    _Dbl_Monto = _Dbl_MontoTot;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "4")
                {
                    _Dbl_Monto = _Dbl_MontoDesc;
                }
                _Str_cdescrip = _Str_cdescrip + _Str_cdescripS;
                if (_Dbl_Monto > 0)
                {
                    if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                    {
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                    }
                    else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                    {
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
                    }
                    _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Str_NumDoc + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_ccount, _Str_ClienteNC, _Str_cdescrip, _Mtd_TipoDocument_CXC("ctipdocnotcred"), _Pr_Str_NC, _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), _Str_cmontacco, _Str_cyearacco, Convert.ToString(_Drow["cnaturaleza"]).Trim().ToUpper());
                }
            }
            _Str_Sql = "UPDATE TCOMPROBANC SET cstatus='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_cidcomprob + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            return _Str_cidcomprob;
        }
        public string _Mtd_Proceso_P_CXC_NC(string _Pr_Str_NCmin, string _Pr_Str_NCmax, double _Pr_Dbl_MontoSimp, double _Pr_Dbl_MontoImp, double _Pr_Dbl_MontoTotal, double _Pr_Dbl_MontoDesc)
        {
            clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
            string _Str_Sql = "";
            string _Str_cidcomprob = "";
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            string _Str_FechaEmi = "";
            string _Str_NumDoc = "";
            double _Dbl_Monto = 0;
            string _Str_ccount = "";
            string _Str_ctdocument = "";
            string _Str_cdescrip = "";
            string _Str_cdescripS = "";
            int _Int_corder = 0;

            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXC_NC");
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;

            DataSet _Ds;
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());

            _Str_FechaEmi = _Mtd_SQLGetDate().ToShortDateString();
            _Str_cdescripS = " NC EMIT " + _Str_FechaEmi + " DESDE " + _Pr_Str_NCmin + " HASTA " + _Pr_Str_NCmax;
            //GUARDO LA CABECERA
            _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) values ('";
            _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _My_Formato._Mtd_fecha(_Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Pr_Dbl_MontoTotal + _Pr_Dbl_MontoDesc) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Pr_Dbl_MontoTotal + _Pr_Dbl_MontoDesc) + "',0,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0,'0')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            //GUARDO EL DETALLE
            _Str_Sql = "select * from VST_PROCESOSCONTD where cidproceso='P_CXC_NC' AND (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL) order by cideprocesod";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Int_corder++;
                _Str_ccount = Convert.ToString(_Drow["ccount"]);
                _Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
                _Str_cdescrip = Convert.ToString(_Drow["ccountname"]);

                if (Convert.ToString(_Drow["cideprocesod"]) == "1")
                {
                    _Dbl_Monto = _Pr_Dbl_MontoSimp;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "2")
                {
                    _Dbl_Monto = _Pr_Dbl_MontoImp;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "3")
                {
                    _Dbl_Monto = _Pr_Dbl_MontoTotal;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "4")
                {
                    _Dbl_Monto = _Pr_Dbl_MontoDesc;
                }
                _Str_cdescrip = _Str_cdescrip + _Str_cdescripS;
                if (_Dbl_Monto > 0)
                {
                    if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                    {
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                    }
                    else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                    {
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
                    }
                    _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Str_NumDoc + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
            }
            return _Str_cidcomprob;
        }
        private double _Mtd_RetornarMontosNC(string _P_Str_NC, int _Int_Monto)
        {
            string _Str_Cadena = "SELECT SUM(cmontosimp + ISNULL(cbasexcenta,0)) AS cmontototsi,SUM(cimpuesto) AS cimpuesto,SUM(cmontototal) AS ctotaldocu,SUM(ISNULL(cmontosimpdpp,0)) AS cmontosimpdpp,SUM(ISNULL(cimpuestodpp,0)) AS cimpuestodpp,SUM(ISNULL(cbasexcentadpp,0)) AS cbasexcentadpp,SUM(ISNULL(cmontototaldpp,0)) AS cmontototaldpp FROM TNOTACREDICCD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _P_Str_NC + "' GROUP BY cidnotcredicc";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Int_Monto == 1)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototsi"]).Length > 0)
                    { return Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototsi"]) + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontosimpdpp"]) + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cbasexcentadpp"]); }
                }
                else if (_Int_Monto == 2)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["cimpuesto"]).Length > 0)
                    { return Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]); }
                }
                else if (_Int_Monto == 3)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctotaldocu"]).Length > 0)
                    { return Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]); }
                }
                else if (_Int_Monto == 4)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototaldpp"]).Length > 0)
                    { return Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontosimpdpp"]) + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cbasexcentadpp"]); }
                }
            }
            else
            {
                _Str_Cadena = "SELECT cmontototsi + ISNULL(cexento,0) as cmontototsi,cimpuesto,ctotaldocu FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _P_Str_NC + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Int_Monto == 1)
                {
                    if (_Ds.Tables[0].Rows[0]["cmontototsi"].ToString().Trim().Length > 0)
                    { return Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototsi"].ToString()); }
                }
                else if (_Int_Monto == 2)
                {
                    if (_Ds.Tables[0].Rows[0]["cimpuesto"].ToString().Trim().Length > 0)
                    { return Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"].ToString()); }
                }
                else if (_Int_Monto == 3)
                {
                    if (_Ds.Tables[0].Rows[0]["ctotaldocu"].ToString().Trim().Length > 0)
                    { return Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"].ToString()); }
                }
            }
            return 0;
        }
        public string _Mtd_Proceso_P_CXC_NC_A(string[] _P_Str_NC, double _Pr_Dbl_MontoSimp, double _Pr_Dbl_MontoImp, double _Pr_Dbl_MontoTotal, string _P_Str_ProcesoCont, double _Pr_Dbl_MontoDesc)
        {
            clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
            string _Str_Sql = "";
            string _Str_cidcomprob = "";
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            string _Str_FechaEmi = "";
            string _Str_NumDoc = "";
            double _Dbl_Monto = 0;
            string _Str_ccount = "";
            string _Str_ctdocument = "";
            string _Str_cdescrip = "";
            int _Int_corder = 0;
            string _Str_FechaNC = "";
            string _Str_FechaVencNC = "";
            string _Str_TipoDocNC = "";
            string _Str_ClienteNC = "";
            DataSet _Ds_NC;
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont(_P_Str_ProcesoCont);
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            DataSet _Ds;
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());

            _Str_FechaEmi = _Mtd_SQLGetDate().ToShortDateString();
            //GUARDO LA CABECERA
            _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) values ('";
            _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _My_Formato._Mtd_fecha(_Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Pr_Dbl_MontoTotal + _Pr_Dbl_MontoDesc) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Pr_Dbl_MontoTotal + _Pr_Dbl_MontoDesc) + "',0,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0,'0')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
            //GUARDO EL DETALLE
            _Str_Sql = "select * from VST_PROCESOSCONTD where cidproceso='" + _P_Str_ProcesoCont + "' AND (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL) order by cideprocesod";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Str_ccount = Convert.ToString(_Drow["ccount"]);
                _Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
                if (Convert.ToString(_Drow["cideprocesod"]) == "1")
                {
                    foreach (string _Str_NC in _P_Str_NC)
                    {
                        //-------------------------
                        _Str_Sql = "SELECT TNOTACREDICC.cfecha, TNOTACREDICC.cfvfnotcredcc, TCONFIGCXC.ctipdocnotcred, TNOTACREDICC.ccliente FROM TNOTACREDICC INNER JOIN TCONFIGCXC ON TNOTACREDICC.ccompany = TCONFIGCXC.ccompany WHERE TNOTACREDICC.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TNOTACREDICC.ccompany='" + Frm_Padre._Str_Comp + "' AND TNOTACREDICC.cidnotcredicc='" + _Str_NC + "'";
                        _Ds_NC = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds_NC.Tables[0].Rows.Count > 0)
                        {
                            _Str_FechaNC = _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds_NC.Tables[0].Rows[0]["cfecha"].ToString().Trim()));
                            _Str_FechaVencNC = _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds_NC.Tables[0].Rows[0]["cfvfnotcredcc"].ToString().Trim()));
                            _Str_TipoDocNC = _Ds_NC.Tables[0].Rows[0]["ctipdocnotcred"].ToString().Trim();
                            _Str_ClienteNC = _Ds_NC.Tables[0].Rows[0]["ccliente"].ToString().Trim();
                        }
                        //-------------------------
                        _Int_corder++;
                        _Str_cdescrip = Convert.ToString(_Drow["ccountname"]) + " NC ANUL " + _Str_FechaEmi + " S/NC " + _Str_NC + " ANULACIÓN";
                        _Dbl_Monto = _Mtd_RetornarMontosNC(_Str_NC, 1);
                        if (_Dbl_Monto > 0)
                        {
                            if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                            {
                                _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                            }
                            else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                            {
                                _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
                            }
                            _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Str_NumDoc + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_ccount, _Str_ClienteNC, _Str_cdescrip, _Str_TipoDocNC, _Str_NC, _Str_FechaNC, _Str_FechaVencNC, CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), _Str_cmontacco, _Str_cyearacco, Convert.ToString(_Drow["cnaturaleza"]).Trim().ToUpper());
                        }
                    }
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "2")
                {
                    foreach (string _Str_NC in _P_Str_NC)
                    {
                        //-------------------------
                        _Str_Sql = "SELECT TNOTACREDICC.cfecha, TNOTACREDICC.cfvfnotcredcc, TCONFIGCXC.ctipdocnotcred, TNOTACREDICC.ccliente FROM TNOTACREDICC INNER JOIN TCONFIGCXC ON TNOTACREDICC.ccompany = TCONFIGCXC.ccompany WHERE TNOTACREDICC.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TNOTACREDICC.ccompany='" + Frm_Padre._Str_Comp + "' AND TNOTACREDICC.cidnotcredicc='" + _Str_NC + "'";
                        _Ds_NC = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds_NC.Tables[0].Rows.Count > 0)
                        {
                            _Str_FechaNC = _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds_NC.Tables[0].Rows[0]["cfecha"].ToString().Trim()));
                            _Str_FechaVencNC = _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds_NC.Tables[0].Rows[0]["cfvfnotcredcc"].ToString().Trim()));
                            _Str_TipoDocNC = _Ds_NC.Tables[0].Rows[0]["ctipdocnotcred"].ToString().Trim();
                            _Str_ClienteNC = _Ds_NC.Tables[0].Rows[0]["ccliente"].ToString().Trim();
                        }
                        //-------------------------
                        _Int_corder++;
                        _Str_cdescrip = Convert.ToString(_Drow["ccountname"]) + " NC ANUL " + _Str_FechaEmi + " S/NC " + _Str_NC;
                        _Dbl_Monto = _Mtd_RetornarMontosNC(_Str_NC, 2);
                        if (_Dbl_Monto > 0)
                        {
                            if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                            {
                                _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                            }
                            else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                            {
                                _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
                            }
                            _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Str_NumDoc + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_ccount, _Str_ClienteNC, _Str_cdescrip, _Str_TipoDocNC, _Str_NC, _Str_FechaNC, _Str_FechaVencNC, CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), _Str_cmontacco, _Str_cyearacco, Convert.ToString(_Drow["cnaturaleza"]).Trim().ToUpper());
                        }
                    }
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "3")
                {
                    foreach (string _Str_NC in _P_Str_NC)
                    {
                        //-------------------------
                        _Str_Sql = "SELECT TNOTACREDICC.cfecha, TNOTACREDICC.cfvfnotcredcc, TCONFIGCXC.ctipdocnotcred, TNOTACREDICC.ccliente FROM TNOTACREDICC INNER JOIN TCONFIGCXC ON TNOTACREDICC.ccompany = TCONFIGCXC.ccompany WHERE TNOTACREDICC.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TNOTACREDICC.ccompany='" + Frm_Padre._Str_Comp + "' AND TNOTACREDICC.cidnotcredicc='" + _Str_NC + "'";
                        _Ds_NC = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds_NC.Tables[0].Rows.Count > 0)
                        {
                            _Str_FechaNC = _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds_NC.Tables[0].Rows[0]["cfecha"].ToString().Trim()));
                            _Str_FechaVencNC = _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds_NC.Tables[0].Rows[0]["cfvfnotcredcc"].ToString().Trim()));
                            _Str_TipoDocNC = _Ds_NC.Tables[0].Rows[0]["ctipdocnotcred"].ToString().Trim();
                            _Str_ClienteNC = _Ds_NC.Tables[0].Rows[0]["ccliente"].ToString().Trim();
                        }
                        //-------------------------
                        _Int_corder++;
                        _Str_cdescrip = Convert.ToString(_Drow["ccountname"]) + " NC ANUL " + _Str_FechaEmi + " S/NC " + _Str_NC;
                        _Dbl_Monto = _Mtd_RetornarMontosNC(_Str_NC, 3);
                        if (_Dbl_Monto > 0)
                        {
                            if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                            {
                                _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                            }
                            else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                            {
                                _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
                            }
                            _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Str_NumDoc + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_ccount, _Str_ClienteNC, _Str_cdescrip, _Str_TipoDocNC, _Str_NC, _Str_FechaNC, _Str_FechaVencNC, CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), _Str_cmontacco, _Str_cyearacco, Convert.ToString(_Drow["cnaturaleza"]).Trim().ToUpper());
                        }
                    }
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "4")
                {
                    foreach (string _Str_NC in _P_Str_NC)
                    {
                        //-------------------------
                        _Str_Sql = "SELECT TNOTACREDICC.cfecha, TNOTACREDICC.cfvfnotcredcc, TCONFIGCXC.ctipdocnotcred, TNOTACREDICC.ccliente FROM TNOTACREDICC INNER JOIN TCONFIGCXC ON TNOTACREDICC.ccompany = TCONFIGCXC.ccompany WHERE TNOTACREDICC.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TNOTACREDICC.ccompany='" + Frm_Padre._Str_Comp + "' AND TNOTACREDICC.cidnotcredicc='" + _Str_NC + "'";
                        _Ds_NC = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds_NC.Tables[0].Rows.Count > 0)
                        {
                            _Str_FechaNC = _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds_NC.Tables[0].Rows[0]["cfecha"].ToString().Trim()));
                            _Str_FechaVencNC = _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds_NC.Tables[0].Rows[0]["cfvfnotcredcc"].ToString().Trim()));
                            _Str_TipoDocNC = _Ds_NC.Tables[0].Rows[0]["ctipdocnotcred"].ToString().Trim();
                            _Str_ClienteNC = _Ds_NC.Tables[0].Rows[0]["ccliente"].ToString().Trim();
                        }
                        //-------------------------
                        _Int_corder++;
                        _Str_cdescrip = Convert.ToString(_Drow["ccountname"]) + " NC ANUL " + _Str_FechaEmi + " S/NC " + _Str_NC;
                        _Dbl_Monto = _Mtd_RetornarMontosNC(_Str_NC, 4);
                        if (_Dbl_Monto > 0)
                        {
                            if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                            {
                                _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                            }
                            else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                            {
                                _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
                            }
                            _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Str_NumDoc + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_ccount, _Str_ClienteNC, _Str_cdescrip, _Str_TipoDocNC, _Str_NC, _Str_FechaNC, _Str_FechaVencNC, CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), _Str_cmontacco, _Str_cyearacco, Convert.ToString(_Drow["cnaturaleza"]).Trim().ToUpper());
                        }
                    }
                }
            }
            _Str_Sql = "UPDATE TCOMPROBANC SET cstatus='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_cidcomprob + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            return _Str_cidcomprob;
        }
        /// <summary>
        /// GENERA EL COMPROBANTE CONTABLE PARA LA ANULACION DE LA NOTA DE CREDITO POR CUENTAS POR COBRAR
        /// </summary>
        /// <param name="_Pr_Str_NC"></param>
        /// <returns></returns>
        public string _Mtd_Proceso_P_CXC_NC_A(string _Pr_Str_NC, string _P_Str_Proceso)
        {
            clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
            string _Str_Sql = "";
            string _Str_cidcomprob = "";
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            //string _Str_FactFirst = "";
            //string _Str_FactLast = "";
            string _Str_FechaEmi = "";
            string _Str_NumDoc = "";
            double _Dbl_MontoTot = 0;
            double _Dbl_MontoSimp = 0;
            double _Dbl_MontoImp = 0;
            double _Dbl_MontoDesc = 0;
            double _Dbl_Monto = 0;
            string _Str_ccount = "";
            string _Str_ctdocument = "";
            string _Str_cdescrip = "";
            string _Str_cdescripS = "";
            int _Int_corder = 0;
            string _Str_ClienteNC = "";
            string _Str_FechaVenc = "";
            DataSet _Ds;
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont(_P_Str_Proceso);
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());
            //-----------------------------------------------------------------------------------------------
            _Str_Sql = "SELECT SUM(cmontosimp + ISNULL(cbasexcenta,0)) AS cmontototsi,SUM(cimpuesto) AS cimpuesto,SUM(cmontototal) AS ctotaldocu,SUM(ISNULL(cmontosimpdpp,0)) AS cmontosimpdpp,SUM(ISNULL(cimpuestodpp,0)) AS cimpuestodpp,SUM(ISNULL(cbasexcentadpp,0)) AS cbasexcentadpp,SUM(ISNULL(cmontototaldpp,0)) AS cmontototaldpp FROM TNOTACREDICCD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _Pr_Str_NC + "' GROUP BY cidnotcredicc";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototsi"]).Length > 0)
                {
                    _Dbl_MontoSimp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototsi"]) + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontosimpdpp"]) + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cbasexcentadpp"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cimpuesto"]).Length > 0)
                {
                    _Dbl_MontoImp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctotaldocu"]).Length > 0)
                {
                    _Dbl_MontoTot = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototaldpp"]).Length > 0)
                {
                    _Dbl_MontoDesc = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontosimpdpp"]) + Convert.ToDouble(_Ds.Tables[0].Rows[0]["cbasexcentadpp"]);
                }
                _Str_Sql = "SELECT cfecha, cnumdocu, ccliente, cfvfnotcredcc FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _Pr_Str_NC + "' AND cdelete=0";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["cfecha"]) != "")
                    {
                        _Str_FechaEmi = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfecha"]).ToShortDateString();
                    }
                    _Str_NumDoc = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumdocu"]);
                    _Str_ClienteNC = Convert.ToString(_Ds.Tables[0].Rows[0]["ccliente"]);
                    _Str_FechaVenc = Convert.ToString(_Ds.Tables[0].Rows[0]["cfvfnotcredcc"]);
                }
            }
            else
            {
                _Str_Sql = "SELECT cmontototsi + ISNULL(cexento,0) as cmontototsi, cimpuesto, ctotaldocu, cfecha, cnumdocu, ccliente, cfvfnotcredcc FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotcredicc='" + _Pr_Str_NC + "' AND cdelete=0";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototsi"]) != "")
                    { _Dbl_MontoSimp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototsi"]); }
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["cimpuesto"]) != "")
                    { _Dbl_MontoImp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]); }
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctotaldocu"]) != "")
                    { _Dbl_MontoTot = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]); }
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["cfecha"]) != "")
                    {
                        _Str_FechaEmi = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfecha"]).ToShortDateString();
                    }
                    _Str_NumDoc = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumdocu"]);
                    _Str_ClienteNC = Convert.ToString(_Ds.Tables[0].Rows[0]["ccliente"]);
                    _Str_FechaVenc = Convert.ToString(_Ds.Tables[0].Rows[0]["cfvfnotcredcc"]);
                }
            }
            _Str_cdescripS = " NC ANUL " + DateTime.Now.ToShortDateString() + " # " + _Pr_Str_NC;
            //GUARDO LA CABECERA
            _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) values ('";
            _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTot + _Dbl_MontoDesc) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTot + _Dbl_MontoDesc) + "',0,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0,'0')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
            //GUARDO EL DETALLE

            _Str_Sql = "select * from VST_PROCESOSCONTD where cidproceso='" + _P_Str_Proceso + "' and (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL) order by cideprocesod";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Int_corder++;
                _Str_ccount = Convert.ToString(_Drow["ccount"]);
                _Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
                _Str_cdescrip = Convert.ToString(_Drow["ccountname"]);

                if (Convert.ToString(_Drow["cideprocesod"]) == "1")
                {
                    _Dbl_Monto = _Dbl_MontoSimp;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "2")
                {
                    _Dbl_Monto = _Dbl_MontoImp;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "3")
                {
                    _Dbl_Monto = _Dbl_MontoTot;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "4")
                {
                    _Dbl_Monto = _Dbl_MontoDesc;
                }
                _Str_cdescrip = _Str_cdescrip + _Str_cdescripS + " ANULACIÓN";
                if (_Dbl_Monto > 0)
                {
                    if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                    {
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                    }
                    else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                    {
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
                    }
                    _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Str_NumDoc + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_ccount, _Str_ClienteNC, _Str_cdescrip, _Mtd_TipoDocument_CXC("ctipdocnotcred"), _Pr_Str_NC, _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)), _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaVenc)), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), _Str_cmontacco, _Str_cyearacco, Convert.ToString(_Drow["cnaturaleza"]).Trim().ToUpper());
                }
            }
            _Str_Sql = "UPDATE TCOMPROBANC SET cstatus='1' where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Str_cidcomprob + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            return _Str_cidcomprob;
        }

        public bool _Mtd_VerificarClaveUsuario(string _Pr_Str_Clave)
        {
            bool _Bol_R = false;
            string _Str_Sql = "";
            byte[] hash = _Mtd_ConvertString_A_ByteArray(_Pr_Str_Clave);
            byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
            string cod = BitConverter.ToString(valorhash);
            cod = cod.Replace("-", "");
            try
            {

                _Str_Sql = "SELECT  cpassw  FROM TUSER WHERE cuser= '" + Frm_Padre._Str_Use.ToString() + "' and cpassw= '" + cod.ToString() + "'";
                System.Data.DataSet Ds22 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (Ds22.Tables[0].Rows.Count > 0)
                {
                    _Bol_R = true;
                }
                else
                {
                    _Bol_R = false;
                }

            }
            catch
            { _Bol_R = false; }
            return _Bol_R;
        }
        public static Byte[] _Mtd_ConvertString_A_ByteArray(String _Pr_Str_Valor)
        {
            return (new UnicodeEncoding()).GetBytes(_Pr_Str_Valor);
        }
        public string _Mtd_Proceso_P_CXC_CHEQDEV(string _Pr_Str_TpoDoc, string _Pr_Str_NumDoc, string _Pr_Str_BancoId, string _Pr_Str_RelCobId, string _Pr_Str_NumCheque, string _Pr_Str_CheqEmision, double _Pr_Dbl_MontoCheq, string _Pr_Str_NumCuentaDeposito)
        {
            clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
            string _Str_Sql = "";
            string _Str_TpoDocCheqDev = "";
            string _Str_TpoDocND = "";
            string _Str_cidcomprob = "";
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            string _Str_FechaEmi = "";
            string _Str_NumDoc = "";
            string _Str_CountBancoCta = "";
            string _Str_CountBancoCtaName = "";
            string _Str_BancoName = "";
            double _Dbl_Monto = 0;
            string _Str_ccount = "";
            string _Str_ctdocument = "";
            string _Str_cdescrip = "";
            int _Int_corder = 0;

            DataSet _Ds;
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXC_CHEQDEV");
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());

            _Str_Sql = "SELECT ctipdoccheqdev,ctipdocnotdeb FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TpoDocCheqDev = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdoccheqdev"]);
                _Str_TpoDocND = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocnotdeb"]);
            }

            _Str_Sql = "SELECT * FROM VST_CUENTBANCCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Pr_Str_BancoId + "' AND cnumcuenta='" + _Pr_Str_NumCuentaDeposito + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_CountBancoCta = Convert.ToString(_Ds.Tables[0].Rows[0]["ccount"]);
                _Str_CountBancoCtaName = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumcuenta_name"]);
            }
            _Str_Sql = "SELECT cname FROM TBANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Pr_Str_BancoId + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_BancoName = Convert.ToString(_Ds.Tables[0].Rows[0]["cname"]);
            }

            //GUARDO LA CABECERA
            _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) values ('";
            _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _My_Formato._Mtd_fecha(_Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Pr_Dbl_MontoCheq) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Pr_Dbl_MontoCheq) + "',0,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0,'1')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            //GUARDO EL DETALLE

            _Str_Sql = "select * from VST_PROCESOSCONTD where cidproceso='P_CXC_CHEQDEV' and (ccompany='" + Frm_Padre._Str_Comp + "' or ccompany is null) order by cideprocesod";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Int_corder++;
                _Str_ccount = Convert.ToString(_Drow["ccount"]);
                _Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
                _Str_cdescrip = Convert.ToString(_Drow["ccountname"]) + ". INGRESO SEGUN CHEQUE " + _Pr_Str_NumCheque;

                if (Convert.ToString(_Drow["cideprocesod"]) == "1")
                {//CHEQUE DEVUELTO (DEBE)
                    _Dbl_Monto = _Pr_Dbl_MontoCheq;
                    _Str_FechaEmi = _Pr_Str_CheqEmision;
                    _Str_NumDoc = _Pr_Str_NumCheque;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "2")
                {
                    _Str_ccount = _Str_CountBancoCta;
                    _Str_NumDoc = _Pr_Str_NumCheque;
                    _Dbl_Monto = _Pr_Dbl_MontoCheq;
                    _Str_FechaEmi = _Pr_Str_CheqEmision;
                    _Str_cdescrip = _Str_CountBancoCtaName + " SEGUN CHEQUE " + _Pr_Str_NumCheque;
                }

                if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                {
                    _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                }
                else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                {
                    _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
                }
                _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Str_NumDoc + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            return _Str_cidcomprob;
        }

        public string _Mtd_Proceso_P_CXC_CHEQDEV(string[] _P_Str_IDEmisionCheq, string[] _P_Str_NumCheq, string[] _P_Str_Cliente)
        {
            clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
            string _Str_Sql = "";
            string _Str_TpoDocCheqDev = "";
            string _Str_cidcomprob = "";
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            string _Str_FechaEmi = "";
            string _Str_NumDoc = "";
            double _Dbl_Monto = 0;
            double _Dbl_MontoTotal_D = 0;
            double _Dbl_MontoTotal_H = 0;
            string _Str_ccount = "";
            string _Str_ctdocument = "";
            string _Str_cdescrip = "";
            int _Int_corder = 0;
            string _Str_Cadena = "";
            string _Str_TipoCheqDev = _Mtd_TipoDocument_CXC("ctipdoccheqdev");
            string _Str_Cliente = "";
            DataSet _Ds;
            DataSet _Ds_Temp;
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXC_CHEQDEV");
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());
            _Str_Sql = "SELECT ctipdoccheqdev FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0) { _Str_TpoDocCheqDev = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdoccheqdev"]); }
            //GUARDO LA CABECERA
            _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) values ('";
            _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _My_Formato._Mtd_fecha(_Mtd_SQLGetDate()) + "','0','0',0,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0,'0')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
            //GUARDO EL DETALLE
            _Str_Sql = "select * from VST_PROCESOSCONTD where cidproceso='P_CXC_CHEQDEV' and (ccompany='" + Frm_Padre._Str_Comp + "' or ccompany is null) order by cideprocesod";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
                if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                {
                    for (int _Int_Index = 0; _Int_Index <= _P_Str_IDEmisionCheq.Length - 1; _Int_Index++)
                    {
                        _Str_Cadena = "SELECT cmontocheq,cfechaemision,cnumcheque,cnumcuentadepo,cbancochequedev,ccliente FROM TCHEQDEVUELT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidcheqdevuelt='" + _P_Str_IDEmisionCheq[_Int_Index] + "' AND cnumcheque='" + _P_Str_NumCheq[_Int_Index] + "' AND ccliente='" + _P_Str_Cliente[_Int_Index] + "'";
                        _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds_Temp.Tables[0].Rows.Count > 0)
                        {
                            _Str_NumDoc = _Ds_Temp.Tables[0].Rows[0]["cnumcheque"].ToString();
                            _Dbl_Monto = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0]["cmontocheq"].ToString());
                            _Str_FechaEmi = _Ds_Temp.Tables[0].Rows[0]["cfechaemision"].ToString();
                            _Str_Cliente = _Ds_Temp.Tables[0].Rows[0]["ccliente"].ToString();
                            _Str_ccount = "";
                            _Str_cdescrip = "";
                            if (Convert.ToString(_Drow["cideprocesod"]) == "1")
                            {
                                _Str_ccount = Convert.ToString(_Drow["ccount"]);
                                _Str_cdescrip = Convert.ToString(_Drow["ccountname"]) + ". INGRESO SEGUN CHEQUE " + _Str_NumDoc;
                            }
                            else if (Convert.ToString(_Drow["cideprocesod"]) == "2")
                            {
                                _Str_Cadena = "SELECT ccount,cnumcuenta_name FROM VST_CUENTBANCCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Ds_Temp.Tables[0].Rows[0]["cbancochequedev"].ToString().Trim() + "' AND cnumcuenta='" + _Ds_Temp.Tables[0].Rows[0]["cnumcuentadepo"].ToString().Trim() + "'";
                                _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                                if (_Ds_Temp.Tables[0].Rows.Count > 0)
                                {
                                    _Str_ccount = Convert.ToString(_Ds_Temp.Tables[0].Rows[0]["ccount"]);
                                    //_Str_cdescrip = Convert.ToString(_Ds_Temp.Tables[0].Rows[0]["cnumcuenta_name"]) + " SEGUN CHEQUE " + _Str_NumDoc;
                                    _Str_cdescrip = "SEGUN CHEQUE " + _Str_NumDoc;
                                }
                            }
                            _Dbl_MontoTotal_D += _Dbl_Monto;
                            _Int_corder++;
                            _Str_Sql = "INSERT INTO TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_TipoCheqDev + "','" + _Str_NumDoc + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_ccount, _Str_Cliente, _Str_cdescrip, _Str_TipoCheqDev, _Str_NumDoc, _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)), _Mtd_FechaVencCheqDev(_Str_Cliente, _Str_NumDoc), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), _Str_cmontacco, _Str_cyearacco, "D");
                        }
                    }

                }
                else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                {
                    for (int _Int_Index = 0; _Int_Index <= _P_Str_IDEmisionCheq.Length - 1; _Int_Index++)
                    {
                        _Str_Cadena = "SELECT cmontocheq,cfechaemision,cnumcheque,cnumcuentadepo,cbancochequedev,ccliente FROM TCHEQDEVUELT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidcheqdevuelt='" + _P_Str_IDEmisionCheq[_Int_Index] + "' AND cnumcheque='" + _P_Str_NumCheq[_Int_Index] + "' AND ccliente='" + _P_Str_Cliente[_Int_Index] + "'";
                        _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds_Temp.Tables[0].Rows.Count > 0)
                        {
                            _Str_NumDoc = _Ds_Temp.Tables[0].Rows[0]["cnumcheque"].ToString();
                            _Dbl_Monto = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0]["cmontocheq"].ToString());
                            _Str_FechaEmi = _Ds_Temp.Tables[0].Rows[0]["cfechaemision"].ToString();
                            _Str_Cliente = _Ds_Temp.Tables[0].Rows[0]["ccliente"].ToString();
                            _Str_ccount = "";
                            _Str_cdescrip = "";
                            if (Convert.ToString(_Drow["cideprocesod"]) == "1")
                            {
                                _Str_ccount = Convert.ToString(_Drow["ccount"]);
                                _Str_cdescrip = Convert.ToString(_Drow["ccountname"]) + ". INGRESO SEGUN CHEQUE " + _Str_NumDoc;
                            }
                            else if (Convert.ToString(_Drow["cideprocesod"]) == "2")
                            {
                                _Str_Cadena = "SELECT ccount,cnumcuenta_name FROM VST_CUENTBANCCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Ds_Temp.Tables[0].Rows[0]["cbancochequedev"].ToString().Trim() + "' AND cnumcuenta='" + _Ds_Temp.Tables[0].Rows[0]["cnumcuentadepo"].ToString().Trim() + "'";
                                _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                                if (_Ds_Temp.Tables[0].Rows.Count > 0)
                                {
                                    _Str_ccount = Convert.ToString(_Ds_Temp.Tables[0].Rows[0]["ccount"]);
                                    _Str_cdescrip = Convert.ToString(_Ds_Temp.Tables[0].Rows[0]["cnumcuenta_name"]) + " SEGUN CHEQUE " + _Str_NumDoc;
                                }
                            }
                            _Dbl_MontoTotal_H += _Dbl_Monto;
                            _Int_corder++;
                            _Str_Sql = "INSERT INTO TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_TipoCheqDev + "','" + _Str_NumDoc + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_ccount, _Str_Cliente, _Str_cdescrip, _Str_TipoCheqDev, _Str_NumDoc, _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)), _Mtd_FechaVencCheqDev(_Str_Cliente, _Str_NumDoc), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), _Str_cmontacco, _Str_cyearacco, "H");
                        }
                    }
                }
            }
            _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1',ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal_D) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal_H) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            return _Str_cidcomprob;
        }

        public string _Mtd_Proceso_P_CXC_CHQTRACHQDEV(string[] _P_Str_IDCheq, string[] _P_Str_NumCheq, string[] _P_Str_Cliente)
        {
            clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");

            string _Str_Sql = "";
            string _Str_TpoDocCheqDev = "";
            string _Str_cidcomprob = "";
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            string _Str_FechaEmi = "";
            string _Str_NumDoc = "";

            double _Dbl_Monto = 0;
            double _Dbl_MontoTotal_D = 0;
            double _Dbl_MontoTotal_H = 0;

            string _Str_ccount = "";
            string _Str_ctdocument = "";
            string _Str_cdescrip = "";

            int _Int_corder = 0;

            string _Str_Cadena = "";
            string _Str_TipoCheqDev = _Mtd_TipoDocument_CXC("ctipdoccheqdev");
            string _Str_Cliente = "";

            DataSet _Ds;
            DataSet _Ds_Temp;

            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXC_CHQTRACHQDEV");

            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());

            _Str_Sql = "SELECT ctipdoccheqdev FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";

            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);

            if (_Ds.Tables[0].Rows.Count > 0) { _Str_TpoDocCheqDev = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdoccheqdev"]); }

            //GUARDO LA CABECERA

            _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());

            _Str_Sql = "insert into TCOMPROBANC (ccompany, cidcomprob, ctypcomp, cname, cyearacco, cmontacco, cregdate, ctotdebe, ctothaber, cbalance, cdateadd, cuseradd, clvalidado, cstatus) values ('";
            _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "', '" + _Str_cidcomprob + "', '" + _Str_ctypcompro + "', '" + _Str_cconceptocomp + "', '" + _Str_cyearacco + "', '" + _Str_cmontacco + "', '" + _My_Formato._Mtd_fecha(_Mtd_SQLGetDate()) + "', '0', '0', 0,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "', '" + Frm_Padre._Str_Use + "', 0, '0');";

            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);

            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);

            //GUARDO EL DETALLE

            _Str_Sql = "select * from VST_PROCESOSCONTD where cidproceso='P_CXC_CHQTRACHQDEV' and (ccompany='" + Frm_Padre._Str_Comp + "' or ccompany is null) order by cideprocesod";

            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);

            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);

                if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                {
                    for (int _Int_Index = 0; _Int_Index <= _P_Str_IDCheq.Length - 1; _Int_Index++)
                    {
                        _Str_Cadena = "SELECT cmontocheq, cfechaemision, cnumcheque, cnumcuentadepo, cbancodepo, ccliente FROM TEGRECHEQTRAN WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidegrecheqtran=" + _P_Str_IDCheq[_Int_Index] + " AND cnumcheque='" + _P_Str_NumCheq[_Int_Index] + "' AND ccliente=" + _P_Str_Cliente[_Int_Index] + " and (isnull(TEGRECHEQTRAN.cidcomprob, 0)=0);";

                        _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

                        if (_Ds_Temp.Tables[0].Rows.Count > 0)
                        {
                            _Str_NumDoc = _Ds_Temp.Tables[0].Rows[0]["cnumcheque"].ToString();

                            _Dbl_Monto = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0]["cmontocheq"].ToString());

                            _Str_FechaEmi = _Ds_Temp.Tables[0].Rows[0]["cfechaemision"].ToString();
                            _Str_Cliente = _Ds_Temp.Tables[0].Rows[0]["ccliente"].ToString();
                            _Str_ccount = "";
                            _Str_cdescrip = "";

                            if (Convert.ToString(_Drow["cideprocesod"]) == "1")
                            {
                                _Str_ccount = Convert.ToString(_Drow["ccount"]);
                                _Str_cdescrip = Convert.ToString(_Drow["ccountname"]) + ". INGRESO SEGUN CHEQUE " + _Str_NumDoc;
                            }
                            else if (Convert.ToString(_Drow["cideprocesod"]) == "2")
                            {
                                _Str_Cadena = "SELECT ccount, cnumcuenta_name FROM VST_CUENTBANCCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Ds_Temp.Tables[0].Rows[0]["cbancochequedev"].ToString().Trim() + "' AND cnumcuenta='" + _Ds_Temp.Tables[0].Rows[0]["cnumcuentadepo"].ToString().Trim() + "'";
                                
                                _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

                                if (_Ds_Temp.Tables[0].Rows.Count > 0)
                                {
                                    _Str_ccount = Convert.ToString(_Ds_Temp.Tables[0].Rows[0]["ccount"]);
                                    _Str_cdescrip = Convert.ToString(_Ds_Temp.Tables[0].Rows[0]["cnumcuenta_name"]) + " SEGUN CHEQUE " + _Str_NumDoc;
                                }
                            }

                            _Dbl_MontoTotal_D += _Dbl_Monto;

                            _Int_corder++;

                            _Str_Sql = "INSERT INTO TCOMPROBAND (ccompany, cidcomprob, corder, ccount, ctdocument, cnumdocu, cdatedocu, ctotdebe, cdateadd, cuseradd, cdescrip) VALUES ('" + Frm_Padre._Str_Comp + "', '" + _Str_cidcomprob + "', '" + _Int_corder.ToString() + "', '" + _Str_ccount + "', '" + _Str_TipoCheqDev + "', '" + _Str_NumDoc + "', '" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "', '" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "', '" + Frm_Padre._Str_Use + "', '" + _Str_cdescrip + "')";

                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);

                            CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_ccount, _Str_Cliente, _Str_cdescrip, _Str_TipoCheqDev, _Str_NumDoc, _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)), _Mtd_FechaVencCheqDev(_Str_Cliente, _Str_NumDoc), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), _Str_cmontacco, _Str_cyearacco, "D");
                        }
                    }
                }
                else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                {
                    for (int _Int_Index = 0; _Int_Index <= _P_Str_IDCheq.Length - 1; _Int_Index++)
                    {
                        _Str_Cadena = "SELECT cmontocheq, cfechaemision, cnumcheque, cnumcuentadepo, cbancodepo, ccliente FROM TEGRECHEQTRAN WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidegrecheqtran=" + _P_Str_IDCheq[_Int_Index] + " AND cnumcheque='" + _P_Str_NumCheq[_Int_Index] + "' AND ccliente=" + _P_Str_Cliente[_Int_Index] + " and (isnull(TEGRECHEQTRAN.cidcomprob, 0)=0);";

                        _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

                        if (_Ds_Temp.Tables[0].Rows.Count > 0)
                        {
                            _Str_NumDoc = _Ds_Temp.Tables[0].Rows[0]["cnumcheque"].ToString();

                            _Dbl_Monto = Convert.ToDouble(_Ds_Temp.Tables[0].Rows[0]["cmontocheq"].ToString());

                            _Str_FechaEmi = _Ds_Temp.Tables[0].Rows[0]["cfechaemision"].ToString();
                            _Str_Cliente = _Ds_Temp.Tables[0].Rows[0]["ccliente"].ToString();
                            _Str_ccount = "";
                            _Str_cdescrip = "";

                            if (Convert.ToString(_Drow["cideprocesod"]) == "1")
                            {
                                _Str_ccount = Convert.ToString(_Drow["ccount"]);
                                _Str_cdescrip = Convert.ToString(_Drow["ccountname"]) + ". INGRESO SEGUN CHEQUE " + _Str_NumDoc;
                            }
                            else if (Convert.ToString(_Drow["cideprocesod"]) == "2")
                            {
                                _Str_Cadena = "SELECT ccount, cnumcuenta_name FROM VST_CUENTBANCCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Ds_Temp.Tables[0].Rows[0]["cbancochequedev"].ToString().Trim() + "' AND cnumcuenta='" + _Ds_Temp.Tables[0].Rows[0]["cnumcuentadepo"].ToString().Trim() + "'";

                                _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

                                if (_Ds_Temp.Tables[0].Rows.Count > 0)
                                {
                                    _Str_ccount = Convert.ToString(_Ds_Temp.Tables[0].Rows[0]["ccount"]);
                                    _Str_cdescrip = Convert.ToString(_Ds_Temp.Tables[0].Rows[0]["cnumcuenta_name"]) + " SEGUN CHEQUE " + _Str_NumDoc;
                                }
                            }

                            _Dbl_MontoTotal_H += _Dbl_Monto;

                            _Int_corder++;

                            _Str_Sql = "INSERT INTO TCOMPROBAND (ccompany, cidcomprob ,corder, ccount, ctdocument, cnumdocu, cdatedocu, ctothaber, cdateadd, cuseradd, cdescrip) VALUES ('" + Frm_Padre._Str_Comp + "', '" + _Str_cidcomprob + "', '" + _Int_corder.ToString() + "', '" + _Str_ccount + "', '" + _Str_TipoCheqDev + "', '" + _Str_NumDoc + "', '" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)) + "', '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "', '" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "', '" + Frm_Padre._Str_Use + "', '" + _Str_cdescrip + "')";

                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);

                            CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_ccount, _Str_Cliente, _Str_cdescrip, _Str_TipoCheqDev, _Str_NumDoc, _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)), _Mtd_FechaVencCheqDev(_Str_Cliente, _Str_NumDoc), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), _Str_cmontacco, _Str_cyearacco, "H");
                        }
                    }
                }
            }

            _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1', ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal_D) + "', ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal_H) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob=" + _Str_cidcomprob + ";";

            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

            return _Str_cidcomprob;
        }

        public string _Mtd_Proceso_P_CXC_ND(string _Pr_Str_ND,int _Pr_Int_CheqDev)
        {
            clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
            string _Str_Sql = "";
            string _Str_cidcomprob = "";
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            string _Str_Doc_TpoDoc = "";
            //string _Str_FactFirst = "";
            //string _Str_FactLast = "";
            string _Str_FechaEmi = "";
            string _Str_NumDoc = "";
            double _Dbl_MontoTot = 0;
            double _Dbl_MontoSimp = 0;
            double _Dbl_MontoImp = 0;
            double _Dbl_Monto = 0;
            string _Str_ccount = "";
            string _Str_ctdocument = "";
            string _Str_cdescrip = "";
            string _Str_cdescripS = "";
            int _Int_corder = 0;
            DataSet _Ds_A;
            DataSet _Ds;
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXC_ND");
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());

            _Str_Sql = "SELECT cmontototsi + ISNULL(cexento,0) as cmontototsi, cimpuesto, ctotaldocu, cfecha, cnumdocu, ctipodocument FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocc='" + _Pr_Str_ND + "' AND cdelete=0";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmontototsi"]) != "")
                { _Dbl_MontoSimp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototsi"]); }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cimpuesto"]) != "")
                { _Dbl_MontoImp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]); }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctotaldocu"]) != "")
                { _Dbl_MontoTot = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]); }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cfecha"]) != "")
                {
                    _Str_FechaEmi = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfecha"]).ToShortDateString();
                }
                _Str_NumDoc = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumdocu"]);
                _Str_Doc_TpoDoc = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocument"]);
            }
            _Str_cdescripS = " ND EMIT " + _Str_FechaEmi + " SEGUN " + _Str_Doc_TpoDoc + " Nº" + _Str_NumDoc;
            //GUARDO LA CABECERA
            _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) values ('";
            _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _My_Formato._Mtd_fecha(_Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTot) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTot) + "',0,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0,'1')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            //GUARDO EL DETALLE

            _Str_Sql = "select * from VST_PROCESOSCONTD where cidproceso='P_CXC_ND' and (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL) order by cideprocesod";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Int_corder++;
                _Str_ccount = Convert.ToString(_Drow["ccount"]);

                _Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
                _Str_cdescrip = Convert.ToString(_Drow["ccountname"]);

                if (Convert.ToString(_Drow["cideprocesod"]) == "1")
                {//CUENTAS POR COBRAR (DEBE)
                    _Dbl_Monto = _Dbl_MontoTot;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "2")
                {//VENTAS (HABER)
                    _Str_Sql = "SELECT ctipdoccheqdev FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    {
                        _Str_ctdocument = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdoccheqdev"]);
                    }
                    _Dbl_Monto = _Dbl_MontoSimp;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "3")
                {//IVA (HABER)
                    _Dbl_Monto = _Dbl_MontoImp;
                }
                if (_Dbl_Monto != 0)
                {
                    _Str_cdescrip = _Str_cdescrip + _Str_cdescripS;
                    if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                    {
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                    }
                    else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                    {
                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
                    }
                    _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Str_NumDoc + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmi)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
            }
            return _Str_cidcomprob;
        }

        public string _Mtd_Proceso_P_CXC_EGRECHEQ(string _Pr_Str_BancoId, string _Pr_Str_BankCuenta, string _Pr_Str_RelCobroId, string _Pr_Str_NumCheque, string _Pr_Str_Monto, string _Pr_Str_FechaEmision, string _Pr_Str_NumDep)
        {
            clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
            string _Str_Sql = "";
            double _Dbl_Monto = 0;
            string _Str_cidcomprob = "";
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            string _Str_BancoCtaName = "";
            string _Str_CountBancoCta = "";
            string _Str_ccount = "";
            string _Str_ctdocument = "";
            string _Str_cnumdocu = "";
            string _Str_cdescrip = "";
            string _Str_TpoDocDeposito = "";
            string _Str_NumDeposito = "";
            string _Str_Caja = "";
            string _Str_Fecha = "";
            string _Str_BancoName = "";
            int _Int_corder = 0;

            DataSet _Ds;
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXC_EGRECHEQ");
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());

            _Str_Sql = "SELECT ctipdocumentdep,ctipdoccheq FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TpoDocDeposito = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocumentdep"]);
            }

            _Str_Sql = "SELECT cname FROM TCUENTBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Pr_Str_BancoId + "' AND cnumcuenta='" + _Pr_Str_BankCuenta + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_BancoCtaName = Convert.ToString(_Ds.Tables[0].Rows[0]["cname"]).Trim();
            }
            _Str_Sql = "SELECT cname FROM TBANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Pr_Str_BancoId + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_BancoName = Convert.ToString(_Ds.Tables[0].Rows[0]["cname"]).Trim();
            }

            _Str_Sql = "SELECT ccount FROM VST_CUENTBANCCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Pr_Str_BancoId + "' AND cnumcuenta='" + _Pr_Str_BankCuenta + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_CountBancoCta = Convert.ToString(_Ds.Tables[0].Rows[0]["ccount"]).Trim();
            }
            _Str_Sql = "SELECT ccaja FROM TRELACCOBM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidrelacobro='" + _Pr_Str_RelCobroId + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Caja = Convert.ToString(_Ds.Tables[0].Rows[0]["ccaja"]).Trim();
            }
            //GUARDO LA CABECERA
            _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) values ('";
            _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _My_Formato._Mtd_fecha(_Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Pr_Str_Monto)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Pr_Str_Monto)) + "',0,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0,'1')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            //GUARDO EL DETALLE

            _Str_Sql = "select * from VST_PROCESOSCONTD where cidproceso='P_CXC_EGRECHEQ' and (ccompany='" + Frm_Padre._Str_Comp + "' or ccompany is null) order by cideprocesod";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Int_corder++;
                
                if (Convert.ToString(_Drow["cideprocesod"]) == "1")
                {//GUARDO LA CUENTA DEL BANCO (DEBE)
                    _Str_ccount = _Str_CountBancoCta;
                    _Str_ctdocument = _Str_TpoDocDeposito;
                    _Str_cnumdocu = _Pr_Str_NumDep;
                    _Str_Fecha = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString();
                    _Str_cdescrip = _Str_BancoName + " CTA. " + _Pr_Str_BankCuenta + " DEPOSITO " + _Str_NumDeposito + " SEGUN CAJA " + _Str_Caja;
                    _Dbl_Monto = Convert.ToDouble(_Pr_Str_Monto);
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "2")
                {//(HABER)
                    _Str_ccount = Convert.ToString(_Drow["ccount"]);
                    _Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
                    _Str_cnumdocu = _Pr_Str_NumCheque;
                    _Str_Fecha = _Pr_Str_FechaEmision;
                    _Str_cdescrip = Convert.ToString(_Drow["ccountname"]) + ". EGRESO SEGUN CAJA " + _Str_Caja;
                    _Dbl_Monto = Convert.ToDouble(_Pr_Str_Monto);
                }

                if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                {
                    _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                }
                else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                {
                    _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
                }
                _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Str_cnumdocu + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_Fecha)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Dbl_Monto)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            return _Str_cidcomprob;
        }

        public string _Mtd_Proceso_P_CXC_FACTANUL(string _Pr_Str_Fact)
        {
            clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
            string _Str_cidcomprob = "";
            string _Str_cconceptocomp = "";
            string _Str_ctypcompro = "";
            string _Str_cyearacco = "";
            string _Str_cmontacco = "";
            string _Str_ccount = "";
            string _Str_ctdocument = "";
            string _Str_cdescrip = "";
            string _Str_FechaFact = "";
            double _Dbl_MontoSimp = 0;
            double _Dbl_MontoImp = 0;
            double _Dbl_MontoTotal = 0;
            double _Dbl_Monto = 0;
            int _Int_corder = 0;
            string _Str_Sql = "";

            DataSet _Ds;
            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXC_FACTANUL");
            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());

            _Str_Sql = "SELECT c_montotot_si_bs,c_impuesto_bs,(c_montotot_si_bs+c_impuesto_bs) AS total,c_fecha_factura FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cfactura='" + _Pr_Str_Fact + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_montotot_si_bs"]) != "")
                {
                    _Dbl_MontoSimp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["c_montotot_si_bs"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_impuesto_bs"]) != "")
                {
                    _Dbl_MontoImp = Convert.ToDouble(_Ds.Tables[0].Rows[0]["c_impuesto_bs"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["total"]) != "")
                {
                    _Dbl_MontoTotal = Convert.ToDouble(_Ds.Tables[0].Rows[0]["total"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_fecha_factura"]) != "")
                {
                    _Str_FechaFact = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["c_fecha_factura"]).ToShortDateString();
                }

            }

            //GUARDO LA CABECERA
            _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) values ('";
            _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _My_Formato._Mtd_fecha(_Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoTotal) + "',0,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0,'1')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            //GUARDO EL DETALLE

            _Str_Sql = "select * from VST_PROCESOSCONTD where cidproceso='P_CXC_FACTANUL' AND (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL) order by cideprocesod";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Int_corder++;
                _Str_ccount = Convert.ToString(_Drow["ccount"]);
                _Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
                _Str_cdescrip = Convert.ToString(_Drow["ccountname"]) + ".\nANUL.FACT " + _Str_FechaFact + " DESDE " + _Pr_Str_Fact + " HASTA " + _Pr_Str_Fact;
                if (Convert.ToString(_Drow["cideprocesod"]) == "1")
                {
                    _Dbl_Monto = _Dbl_MontoSimp;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "2")
                {
                    _Dbl_Monto = _Dbl_MontoImp;
                }
                else if (Convert.ToString(_Drow["cideprocesod"]) == "3")
                {
                    _Dbl_Monto = _Dbl_MontoTotal;
                }
                else
                { _Dbl_Monto = 0; }
                if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
                {
                    _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
                }
                else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
                {
                    _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
                }
                _Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Pr_Str_Fact + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaFact)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            return _Str_cidcomprob;
        }
        //SIN USO ESTE METODO........SIN USO ESTE METODO........SIN USO ESTE METODO..........SIN USO ESTE METODO.......SIN USO ESTE METODO
        //public string _Mtd_Proceso_P_CXC_FACTANUL(string _Pr_Str_FactDesde, string _Pr_Str_FactHasta, double _Pr_Dbl_MontoSimp, double _Pr_Dbl_MontoImp, double _Pr_Dbl_MontoTotal)
        //{
        //    clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        //    string _Str_cidcomprob = "";
        //    string _Str_cconceptocomp = "";
        //    string _Str_ctypcompro = "";
        //    string _Str_cyearacco = "";
        //    string _Str_cmontacco = "";
        //    string _Str_ccount = "";
        //    string _Str_ctdocument = "";
        //    string _Str_cdescrip = "";
        //    string _Str_FechaFact = "";
        //    double _Dbl_Monto = 0;
        //    int _Int_corder = 0;
        //    string _Str_Sql = "";

        //    DataSet _Ds;
        //    Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXC_FACTANUL");
        //    _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
        //    _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
        //    _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
        //    _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());
        //    _Str_FechaFact = _My_Formato._Mtd_fecha(_Mtd_SQLGetDate());

        //    //GUARDO LA CABECERA
        //    _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
        //    _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) values ('";
        //    _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _My_Formato._Mtd_fecha(_Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Pr_Dbl_MontoTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Pr_Dbl_MontoTotal) + "',0,GETDATE(),'" + Frm_Padre._Str_Use + "',0,'1')";
        //    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
        //    //GUARDO EL DETALLE

        //    _Str_Sql = "select * from VST_PROCESOSCONTD where cidproceso='P_CXC_FACTANUL' AND (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL) order by cideprocesod";
        //    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
        //    foreach (DataRow _Drow in _Ds.Tables[0].Rows)
        //    {
        //        _Int_corder++;
        //        _Str_ccount = Convert.ToString(_Drow["ccount"]);
        //        _Str_ctdocument = Convert.ToString(_Drow["ctipodocumento"]);
        //        _Str_cdescrip = Convert.ToString(_Drow["ccountname"]) + ".\nANUL.FACT " + _Str_FechaFact + " DESDE " + _Pr_Str_FactDesde + " HASTA " + _Pr_Str_FactHasta;
        //        if (Convert.ToString(_Drow["cideprocesod"]) == "1")
        //        {
        //            _Dbl_Monto = _Pr_Dbl_MontoSimp;
        //        }
        //        else if (Convert.ToString(_Drow["cideprocesod"]) == "2")
        //        {
        //            _Dbl_Monto = _Pr_Dbl_MontoImp;
        //        }
        //        else if (Convert.ToString(_Drow["cideprocesod"]) == "3")
        //        {
        //            _Dbl_Monto = _Pr_Dbl_MontoTotal;
        //        }
        //        else
        //        { _Dbl_Monto = 0; }
        //        if (Convert.ToString(_Drow["cnaturaleza"]) == "D")
        //        {
        //            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip)";
        //        }
        //        else if (Convert.ToString(_Drow["cnaturaleza"]) == "H")
        //        {
        //            _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip)";
        //        }
        //        //ESTABA COMENTADO
        //        //_Str_Sql = _Str_Sql + " VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Int_corder.ToString() + "','" + _Str_ccount + "','" + _Str_ctdocument + "','" + _Pr_Str_Fact + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaFact)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + _Str_cdescrip + "')";
        //        //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
        //    }
        //    return _Str_cidcomprob;
        //}
        public double _Mtd_GetPorcSobregiroUsuario(string _Pr_Str_Usu)
        {
            double _Dbl_PorcSobreGiro = 0;
            string _Str_Sql = "SELECT caprobasobregiro FROM TLIMITCREDITOP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cuser='" + _Pr_Str_Usu + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim() != "")
                {
                    _Dbl_PorcSobreGiro = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                }
            }
            return _Dbl_PorcSobreGiro;
        }
        public void _Mtd_CargarMesesCombo(ComboBox _Pr_Cb)
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Pr_Cb.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("ENERO", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("FEBRERO", "2"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("MARZO", "3"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("ABRIL", "4"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("MAYO", "5"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("JUNIO", "6"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("JULIO", "7"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("AGOSTO", "8"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("SEPTIEMBRE", "9"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("OCTUBRE", "10"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("NOVIEMBRE", "11"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("DICIEMBRE", "12"));
            _Pr_Cb.DataSource = _myArrayList;
            _Pr_Cb.DisplayMember = "Display";
            _Pr_Cb.ValueMember = "Value";
            _Pr_Cb.SelectedValue = "nulo";
        }
        public double _Mtd_ProductoUndManejo2(string _Pr_Str_IdProd)
        {
            double _Dbl_R = 0;
            double _Dbl_ccontenidoma1 = 0, _Dbl_ccontenidoma2 = 0;
            string _Str_Sql = "SELECT cproducto, cunidadma1, ccontenidoma1, cunidad2, cunidadma2, ccontenidoma2 FROM TPRODUCTO WHERE cunidad2 = '1' AND cproducto='" + _Pr_Str_IdProd + "'";
            if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
            {
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccontenidoma1"]).Length > 0)
                    {
                        _Dbl_ccontenidoma1 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma1"]);
                    }
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccontenidoma2"]).Length > 0)
                    {
                        _Dbl_ccontenidoma2 = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma2"]);
                    }
                    _Dbl_R = _Dbl_ccontenidoma1 / _Dbl_ccontenidoma2;
                }
            }
            else
            {
                _Dbl_R = -1;
            }
            return _Dbl_R;
        }
        public decimal _Mtd_ProductoUndManejo2Dec(string _Pr_Str_IdProd)
        {
            decimal _Dec_R = 0;
            decimal _Dec_ccontenidoma1 = 0, _Dec_ccontenidoma2 = 0;
            string _Str_Sql = "SELECT cproducto, cunidadma1, ccontenidoma1, cunidad2, cunidadma2, ccontenidoma2 FROM TPRODUCTO WHERE cunidad2 = '1' AND cproducto='" + _Pr_Str_IdProd + "'";
            if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
            {
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccontenidoma1"]).Length > 0)
                    {
                        _Dec_ccontenidoma1 = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["ccontenidoma1"]);
                    }
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccontenidoma2"]).Length > 0)
                    {
                        _Dec_ccontenidoma2 = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["ccontenidoma2"]);
                    }
                    _Dec_R = _Dec_ccontenidoma1 / _Dec_ccontenidoma2;
                }
            }
            else
            {
                _Dec_R = -1;
            }
            return _Dec_R;
        }
        public static DataSet _Mtd_CrearDsT3Config()
        {
            DataSet _Ds_Gconfig = new DataSet();
            DataTable _Dt_Gconfig = _Ds_Gconfig.Tables.Add("table");
            _Dt_Gconfig.Columns.Add("compdefault", typeof(string));
            return _Ds_Gconfig;
        }
        public static DataSet _Mtd_CargarXMLT3Config()
        {
            DataSet _Ds = new DataSet();
            _Ds.ReadXml(Application.StartupPath.ToString() + @"\T3.con");
            return _Ds;
        }
        public static DataSet _Mtd_DsT3Config()
        {
            DataSet _Ds = new DataSet();
            if (System.IO.File.Exists(Application.StartupPath.ToString() + @"\T3.con"))
            {
                _Ds = _Mtd_CargarXMLT3Config();
            }
            return _Ds;
        }
        public static void _Mtd_T3ConfigGuardar(string _Pr_Str_CodCompanyDefault)
        {
            DataSet _Ds = _Mtd_CrearDsT3Config();
            DataRow _Drow_New = _Ds.Tables["table"].NewRow();
            _Drow_New["compdefault"] = _Pr_Str_CodCompanyDefault;
            _Ds.Tables["table"].Rows.Add(_Drow_New);
            _Ds.WriteXml(Application.StartupPath.ToString() + @"\T3.con");
        }
        public static bool _Mtd_GetUserIsGerArea(string _Pr_Str_User)
        {
            bool _Bol_R = false;
            string _Str_Vendedor = "";
            string _Str_Sql = "SELECT cvendedor FROM TUSER WHERE cuser='" + _Pr_Str_User + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Vendedor = Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim();
            }
            _Str_Sql = "SELECT c_tipo_vend FROM TVENDEDOR WHERE cvendedor='" + _Str_Vendedor + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_tipo_vend"]).Trim() == "2")
                {
                    _Bol_R = true;
                }
            }
            return _Bol_R;
        }
        public static DateTime _Mtd_SQLGetDate()
        {
            string _Str_R = "";
            string _Str_Sql = "SELECT cdiafecha_reg FROM TCALENDCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0 and convert(varchar,cdiafecha_cal,103)=convert(varchar,GETDATE(),103)";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_R = Convert.ToString(_Ds.Tables[0].Rows[0]["cdiafecha_reg"]);
            }
            else
            {
                _Str_Sql = "SELECT GETDATE()";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                _Str_R = _Ds.Tables[0].Rows[0][0].ToString();
            }
            return Convert.ToDateTime(_Str_R);
        }
        public static DateTime _Mtd_SQLGetDate(string _P_Str_Comp)
        {
            string _Str_R = "";
            string _Str_Sql = "SELECT cdiafecha_reg FROM TCALENDCONT WHERE ccompany='" + _P_Str_Comp + "' AND cdelete=0 and convert(varchar,cdiafecha_cal,103)=convert(varchar,GETDATE(),103)";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_R = Convert.ToString(_Ds.Tables[0].Rows[0]["cdiafecha_reg"]);
            }
            else
            {
                _Str_Sql = "SELECT GETDATE()";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                _Str_R = _Ds.Tables[0].Rows[0][0].ToString();
            }
            return Convert.ToDateTime(_Str_R);
        }
        public static DateTime _Mtd_SQLGetDateServ()
        {
            string _Str_Sql = "SELECT GETDATE()";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            return Convert.ToDateTime(_Ds.Tables[0].Rows[0][0]);
        }
        public static string _Mtd_ConvertUnidSobrante(string _Str_Producto, int _Int_Unidades)
        {
            string _Str_Unit = "0";
            try
            {
                string _Str_SQL = "select dbo.Fnc_ConvertUndSobrante('" + _Str_Producto + "'," + _Int_Unidades + ") as ctotalund";
                DataSet _Ds_DataSet = new DataSet();
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Str_Unit = _Ds_DataSet.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    _Str_Unit = "0";
                }
            }
            catch
            {
            }
            return _Str_Unit;
        }
        public static string _Mtd_ConvertUnidCajas(string _Str_Producto, int _Int_Cajas, int _Int_Unidades)
        {
            string _Str_Unit = "0";
            try
            {
                string _Str_SQL = "select dbo.Fnc_ConvertUndCajas('" + _Str_Producto + "'," + _Int_Cajas + "," + _Int_Unidades + ") as ctotalund";
                DataSet _Ds_DataSet = new DataSet();
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Str_Unit = _Ds_DataSet.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    _Str_Unit = "0";
                }
            }
            catch
            {
            }
            return _Str_Unit;
        }
        public static string _Mtd_ConvertCajasUnid(string _Str_Producto, int _Int_Cajas, int _Int_Unidades)
        {
            string _Str_Unit = "0";
            try
            {
                string _Str_SQL = "select dbo.Fnc_ConvertCajasUnd('" + _Str_Producto + "'," + _Int_Unidades + "," + _Int_Cajas + ") as ctotalund";
                DataSet _Ds_DataSet = new DataSet();
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Str_Unit = _Ds_DataSet.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    _Str_Unit = "0";
                }
            }
            catch
            {
            }
            return _Str_Unit;
        }
        public static DataSet _Mtd_ConsultasSP(string nombreSP, SqlParameter[] parametroSP)
        {
            System.Data.SqlClient.SqlConnection cone = new System.Data.SqlClient.SqlConnection(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            DataSet Ds = new DataSet();
            System.Data.SqlClient.SqlCommand oMySqlCommand = new SqlCommand(nombreSP, cone);
            oMySqlCommand.CommandTimeout = 300;
            oMySqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parametrossp = new SqlParameter[parametroSP.Length];
            for (int i = 0; i < parametroSP.Length; i++)
            {
                parametrossp[i] = parametroSP[i];
                oMySqlCommand.Parameters.Add(parametrossp[i]);
            }
            System.Data.SqlClient.SqlDataAdapter Dt = new SqlDataAdapter();
            Dt = new SqlDataAdapter(oMySqlCommand);
            cone.Close();
            Dt.Fill(Ds);
            return Ds;
        }
        public void _Mtd_CargarCombo(ComboBox _Pr_Cb, DataSet _P_Ds_DataSet, string _P_Str_Text, string _P_Str_Value)
        {
            DataSet _Ds = new DataSet();
            _Ds = _P_Ds_DataSet;
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Pr_Cb.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            //_Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                if (_DRow[_P_Str_Text].ToString().TrimEnd() != "" && _DRow[_P_Str_Value].ToString().TrimEnd() != "")
                {
                    _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[_P_Str_Text].ToString(), _DRow[_P_Str_Value].ToString()));
                }
            }
            _Pr_Cb.DataSource = _myArrayList;
            _Pr_Cb.DisplayMember = "Display";
            _Pr_Cb.ValueMember = "Value";
            _Pr_Cb.SelectedValue = "nulo";
        }
        public static string _Mtd_EjecutarSP(string nombreSP, SqlParameter[] parametroSP, String _Str_OutPut)
        {
            System.Data.SqlClient.SqlConnection cone = new System.Data.SqlClient.SqlConnection(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            cone.Open();
            System.Data.SqlClient.SqlCommand oMySqlCommand = new SqlCommand(nombreSP, cone);
            oMySqlCommand.CommandTimeout = 3600;
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
            SqlParameter _SQL_Resp = new SqlParameter(_Str_OutPut, SqlDbType.Real, 18);
            _SQL_Resp.Direction = ParameterDirection.Output;
            oMySqlCommand.Parameters.Add(_SQL_Resp);
            oMySqlCommand.ExecuteNonQuery();
            //omy ExecuteNonQuery(conn.Connection, CommandType.StoredProcedure,"insertar", paramsToStore);
            cone.Close();
            return _SQL_Resp.Value.ToString();
        }
        public bool _Mtd_VerificarClaveUsuarioFirma(string _Pr_Str_Clave, string _P_Str_Proceso)
        {
            bool _Bol_R = false;
            string _Str_Sql = "";
            byte[] hash = _Mtd_ConvertString_A_ByteArray(_Pr_Str_Clave);
            byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
            string cod = BitConverter.ToString(valorhash);
            cod = cod.Replace("-", "");
            try
            {
                _Str_Sql = "SELECT  TUSER.cpassw FROM TUSER inner join TPROCEFIRMAD on TUSER.cuser=TPROCEFIRMAD.cuser WHERE TUSER.cpassw= '" + cod.ToString() + "' and TPROCEFIRMAD.cprocesofirma='" + _P_Str_Proceso + "'";
                System.Data.DataSet Ds22 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (Ds22.Tables[0].Rows.Count > 0)
                {
                    _Bol_R = true;
                }
                else
                {
                    _Bol_R = false;
                }
            }
            catch
            { _Bol_R = false; }
            return _Bol_R;
        }
        public void _Mtd_CargarCheckList(CheckedListBox _Pr_Lista, DataTable _Pr_Dt)
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Pr_Lista.DataSource = null;
            foreach (DataRow _DRow in _Pr_Dt.Rows)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString(), _DRow[0].ToString()));
            }
            if (_Pr_Dt.Rows.Count > 0)
            {
                _Pr_Lista.DataSource = _myArrayList;
                _Pr_Lista.DisplayMember = "Display";
                _Pr_Lista.ValueMember = "Value";
                _Pr_Lista.SelectedIndex = 0;
            }
        }
        DataGridView _Dg_Grig_Temp = new DataGridView();
        public void _Mtd_CrearEventSort(DataGridView _P_Dg_Grig)
        {
            _Dg_Grig_Temp = _P_Dg_Grig;
            _Dg_Grig_Temp.Sorted += new EventHandler(_Dg_Grig_Temp_Sorted);
        }
        public string _Mtd_RetornarStringCelda(int _Int_Columna, int _Int_Fila)
        {
            if (_Dta_View_ == null)
            {
                return _Dg_Grig_Temp.Rows[_Int_Fila].Cells[_Int_Columna].Value.ToString().Trim();
            }
            else
            {
                return _Dta_View_[_Int_Fila].Row[_Int_Columna].ToString().Trim();
            }
        }
        public string _Mtd_RetornarStringCelda(string _Str_Columna, int _Int_Fila)
        {
            if (_Dta_View_ == null)
            {
                return _Dg_Grig_Temp.Rows[_Int_Fila].Cells[_Str_Columna].Value.ToString().Trim();
            }
            else
            {
                return _Dta_View_[_Int_Fila].Row[_Str_Columna].ToString().Trim();
            }
        }
        public DataView _Dta_View_;
        void _Dg_Grig_Temp_Sorted(object sender, EventArgs e)
        {
            string _Str_Sort = ((DataGridView)sender).SortOrder.ToString();
            if (_Str_Sort == "Ascending")
            {
                _Str_Sort = "Asc";
            }
            else
            {
                _Str_Sort = "desc";
            }
            string _Str_Campo = ((DataGridView)sender).SortedColumn.DataPropertyName.ToString();
            DataTable _Dta_Table = new DataTable();
            _Dta_Table = (DataTable)((DataGridView)sender).DataSource;
            _Dta_View_ = _Dta_Table.DefaultView;
            _Dta_View_.Sort = _Str_Campo + " " + _Str_Sort;
        }
        public static bool _Mtd_Conteo_Iniciado()
        {
            string _Str_Comps = _Mtd_SQL_Comp();
            string _Str_Cadena = "SELECT ciniciado FROM TINVFISICOM WHERE " + _Str_Comps + " AND ciniciado='1'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }
        public static bool _Mtd_Conteo_Iniciado(string _P_Str_Comp)
        {
            string _Str_Comps = _Mtd_SQL_Comp();
            string _Str_Cadena = "SELECT ciniciado FROM TINVFISICOM WHERE ccompany='" + _P_Str_Comp + "' AND ciniciado='1'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }
        public static bool _Mtd_Facturacion()
        {
            string _Str_Cadena = "SELECT ccompany FROM TGROUPCOMPANYD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Str_Cadena = "";
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_Cadena = "SELECT cdiafecha_cal FROM TCALENDCONT WHERE ccompany='" + _Row[0].ToString().Trim() + "' AND CONVERT(DATETIME,CONVERT(VARCHAR,cdiafecha_cal,103))=CONVERT(DATETIME,CONVERT(VARCHAR,GETDATE(),103)) AND cdelete='0' AND ((cmesubicado>0 AND cmesubicado=cmontacco) OR cprorroga='1')";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
                { return false; }
            }
            return true;
        }
        public static bool _Mtd_BloquearFacturacionPorCierre()
        {
            //Solo si esta habilitado la bandera en la base de datos
            if (!_Mtd_BloqueoImpresionCierreVentas())
                return false;
                
            //Obtengo el Cierre de Ventas
            var dtUltimaFechaVentas = Convert.ToDateTime(Frm_Padre._Mtd_UltimaFechaVentas());

            //Obtengo los dias de prorroga posterioR al cierre de ventas
            string _Str_Sql =
                "SELECT cdiafecha_cal, cprorroga, cmontacco, cmesubicado FROM TCALENDCONT WHERE cdiafecha_cal > CONVERT(datetime,'" +
                dtUltimaFechaVentas.ToShortDateString() + "') AND ccompany = '" + Frm_Padre._Str_Comp +
                "' AND (cprorroga = '1') and (cmontacco>0 and cmontacco = " + dtUltimaFechaVentas.Month +
                ") ORDER BY cdiafecha_cal";
            DataSet _Ds_DiasProrroga = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);

            //Si no hay dias de prorroga no bloqueo
            if (_Ds_DiasProrroga.Tables[0].Rows.Count == 0)
                return false;

            //Fecha actual
            var dtFechaActual = DateTime.Now.Date;
            var dtHoraActual = DateTime.Now.TimeOfDay;

            var intPosicion = 0;

            //Verificamos si la fecha actual es uno de los dias de prorroga
            foreach (DataRow _Row in _Ds_DiasProrroga.Tables[0].Rows)
            {
                //Cuento la Posicion
                intPosicion++;

                //Verifico si el dia actual esta dentro de los de prorroga
                if (dtFechaActual.Date == Convert.ToDateTime(_Row["cdiafecha_cal"]).Date)
                {
                    //en función a la posición permito o no permito
                   if (intPosicion == 1)
                   {
                       //Verifico la Hora
                       return dtHoraActual >= new TimeSpan(12,0,0); //Se bloquea a partir de las 12pm
                   }
                   //Bloqueamos por defecto los otros dias de prorroga
                   return true;
                }
            }

            //Sino por defecto permitimos facturar
            return false;
        }
        public static bool _Mtd_BloquearAnulacionPrefacturasSegunCierreVentas()
        {
            //Solo si esta habilitado la bandera en la base de datos
            if (!_Mtd_BloqueoAnulacionPrefactura())
                return false;

            //Obtengo el Cierre de Ventas
            var dtUltimaFechaVentas = Convert.ToDateTime(Frm_Padre._Mtd_UltimaFechaVentas()).Date;
            //Fecha actual
            var dtFechaActual = DateTime.Now.Date;
            var dtHoraActual = DateTime.Now.TimeOfDay;
            var bolEsDiaVenta = false;

            //Verificamos si hoy es dia de venta
            var _Str_Sql = "SELECT cdiafecha_cal, cprorroga, cmontacco, cmesubicado FROM TCALENDCONT WHERE cdiafecha_cal = CONVERT(datetime,'" + dtFechaActual.ToShortDateString() + "') AND ccompany = '" + Frm_Padre._Str_Comp + "' AND cmontacco>0 ";
            var _Ds_DiaVenta = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_DiaVenta.Tables[0].Rows.Count > 0)
                bolEsDiaVenta= _Ds_DiaVenta.Tables[0].Rows[0]["cmesubicado"].ToString() != "0";

            //Si es dia de venta
            if (bolEsDiaVenta)
            {
                //Si estamos en el cierre
                if (dtFechaActual == dtUltimaFechaVentas)
                {
                    //Si estamos en la hora correcta
                    return dtHoraActual >= new TimeSpan(11, 0, 0); //Se bloquea a partir de las 11am
                }
            }
            else
            {
                //Bloqueamos
                return true;
            }

            //Sino por defecto permitimos eliminar
            return false;
        }
        public static bool _Mtd_BloqueoImpresionCierreVentas()
        {
            var _Bool_Retornar = false;

            try
            {
                string _Str_Sql = "SELECT cbloqueoimpresioncierreventas FROM TCONFIGCONSSA WHERE cbloqueoimpresioncierreventas = 1";
                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Bool_Retornar = true;
                }
            }
            catch
            {
                _Bool_Retornar = false;
            }
            return _Bool_Retornar;
        }
        public static bool _Mtd_BloqueoAnulacionPrefactura()
        {
            var _Bool_Retornar = false;

            try
            {
                string _Str_Sql = "SELECT cbloqueoanulacionprefacturacierreventas FROM TCONFIGCONSSA WHERE cbloqueoanulacionprefacturacierreventas = 1";
                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Bool_Retornar = true;
                }
            }
            catch
            {
                _Bool_Retornar = false;
            }
            return _Bool_Retornar;
        }

        private void _Mtd_EjecutarBackupBD_CAJ()
        {
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia("EXEC PA_BACKUP_DATABASE 'CAJ'");
            //Program._MyClsCnn._mtd_conexion4._Mtd_EjecutarSentencia("EXEC PA_BACKUP_DATABASE 'CAJ'");
        }
        private void _Mtd_EjecutarBackupBD_INV()
        {
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia("EXEC PA_BACKUP_DATABASE 'INV'");
            //Program._MyClsCnn._mtd_conexion4._Mtd_EjecutarSentencia("EXEC PA_BACKUP_DATABASE 'INV'");
        }
        private void _Mtd_EjecutarBackupBD_CONT()
        {
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia("EXEC PA_BACKUP_DATABASE 'CONT'");
            //Program._MyClsCnn._mtd_conexion4._Mtd_EjecutarSentencia("EXEC PA_BACKUP_DATABASE 'CONT'");
        }
        public void _Mtd_IniciarBackupBD(Form _P_Frm,string _P_Str_SwProceso)
        {
            Thread _Thr_Thread;
            if (_P_Str_SwProceso == "CAJ")
            { _Thr_Thread = new Thread(new ThreadStart(_Mtd_EjecutarBackupBD_CAJ)); }
            else if (_P_Str_SwProceso == "INV")
            { _Thr_Thread = new Thread(new ThreadStart(_Mtd_EjecutarBackupBD_INV)); }
            else// Si se desea agregar otra selectiva se debe colocar  'if (_P_Str_DesProceso == "CONT")' en esta linea y la ultima selectiva debe estar sin la condicion, es decir, solo el 'ELSE' como esta esta actualmente.
            { _Thr_Thread = new Thread(new ThreadStart(_Mtd_EjecutarBackupBD_CONT)); }
            _Thr_Thread.Start();
            while (!_Thr_Thread.IsAlive) ;
            Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread, "Espere por favor, Creando respaldo...");
            //_Frm_Form.MdiParent = _P_Frm.MdiParent;
            _Frm_Form.ShowDialog(_P_Frm);
            _Frm_Form.Dispose();
        }
        public static string _Mtd_OptenerDireccWiki(string _P_Str_Company,string _P_Str_FormName)
        {
            string _Str_Direccion = "";
            string _Str_Cadena = "SELECT c_direccion_Wiki FROM TCOMPANY WHERE ccompany='" + _P_Str_Company + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
            {
                _Str_Direccion = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                _Str_Cadena = "SELECT cidwiki FROM TWIKI WHERE cidformt3='" + _P_Str_FormName + "' AND ctipo='0'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                    {
                        return _Str_Direccion + _Ds.Tables[0].Rows[0][0].ToString().Trim();
                    }
                }
                return _Str_Direccion;
            }
            return "";
        }
        public static void _Mtd_Help(Form _P_Frm_Padre)
       {
           _P_Frm_Padre.KeyUp += new KeyEventHandler(_P_Frm_Padre_KeyUp);
       }

       static void _P_Frm_Padre_KeyUp(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.F1)
           {
               try
               {
                   System.Diagnostics.Process _System_Proceso = System.Diagnostics.Process.Start(_Mtd_OptenerDireccWiki(Frm_Padre._Str_Comp, ((Frm_Padre)sender).ActiveControl.Name));
               }
               catch { }
           }
       }
       public static void _Mtd_EjecutarSP(string nombreSP, SqlParameter[] parametroSP, SqlConnection cone)
       {
           if (cone.State != ConnectionState.Open)
           {
               cone.Open();
           }
           System.Data.SqlClient.SqlCommand oMySqlCommand = new SqlCommand(nombreSP, cone);
           oMySqlCommand.CommandTimeout = 3600;
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
       public void _Mtd_GenerarNCxDescxPPago(string _P_Str_OrdenPago)
       {
           string _Str_Sql = "";
           string _Str_NDId = "";
           string _Str_DescripcionOriginal = "";
           string _Str_Fact = "";
           string _Str_ND = "";
           string _Str_ProvId = "";
           string _Str_MontoDesc = "";
           string _Str_Motivo = "";
           double _Dbl_MontoImp = 0;
           double _Dbl_Tasa = 0;
           double _Dbl_MontoSI = 0;
           int _Int_Comprob = 0;
           DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipdocfact,cpercent,cmotivodescppp,ctipodocnd from VST_CONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
           if (_Ds.Tables[0].Rows.Count > 0)
           {
               _Str_ND = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocnd"]);
               _Str_Fact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]);
               if (Convert.ToString(_Ds.Tables[0].Rows[0]["cpercent"]) != "")
               {
                   _Dbl_Tasa = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cpercent"]);
               }
               _Str_Motivo = Convert.ToString(_Ds.Tables[0].Rows[0]["cmotivodescppp"]);
           }

           _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cproveedor,cdescpppago FROM TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _P_Str_OrdenPago + "'");
           if (_Ds.Tables[0].Rows.Count > 0)
           {
               _Str_ProvId = Convert.ToString(_Ds.Tables[0].Rows[0]["cproveedor"]);
           }
           _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cmotivoconcepto FROM VST_CONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
           if (_Ds.Tables[0].Rows.Count > 0)
           {
               _Str_DescripcionOriginal = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
           }
           _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT * FROM TPAGOSCXPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _P_Str_OrdenPago + "'");
           foreach (DataRow _DRow in _Ds.Tables[0].Rows)
           {
               if (Convert.ToString(_DRow["cidescuentoppp"]) != "" && Convert.ToString(_DRow["cidescuentoppp"]) != "0")
               {
                   _Str_MontoDesc = Convert.ToString(_DRow["cmontoddpp"]);
                   _Str_MontoDesc = Math.Round(Convert.ToDouble(_Str_MontoDesc), 2).ToString();
                   _Dbl_MontoSI = Convert.ToDouble(_Str_MontoDesc) / ((_Dbl_Tasa + 100) / 100);
                   _Dbl_MontoSI = Math.Round(Convert.ToDouble(_Dbl_MontoSI), 2);
                   _Dbl_MontoImp = Convert.ToDouble(_Str_MontoDesc) - _Dbl_MontoSI;
                   _Dbl_MontoImp = Math.Round(_Dbl_MontoImp, 2);

                   //Detalle de la Factura
                   var _L_Str_Cnumdocu = Convert.ToString(_DRow["cnumdocu"]);
                   var _L_Str_Cproveedor = _Str_ProvId;
                   var _L_Str_Cgroupcomp = Frm_Padre._Str_GroupComp;
                   var _L_Str_Ccompany = Frm_Padre._Str_Comp;
                   var _G_Str_DetalleFactura = _Mtd_ObtenerDatosFacturaCxP(_L_Str_Cnumdocu, _L_Str_Cproveedor, _L_Str_Cgroupcomp, _L_Str_Ccompany);
                   var _DescripcionCompleta = _Str_DescripcionOriginal + _G_Str_DetalleFactura;
                   var _Str_Descripcion = _DescripcionCompleta.Length > 255 ? _DescripcionCompleta.Substring(0, 255) : _DescripcionCompleta;
                   
                   _Str_Sql = "Select Max(cidnotadebitocxp) FROM TNOTADEBITOCP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'";
                   _Str_NDId = _Mtd_Correlativo(_Str_Sql);
                   _Str_Sql = "insert into TNOTADEBITOCP (cgroupcomp,ccompany,cidnotadebitocxp,cproveedor,cfechand,cdescripcion,cmontototsi,cimpuesto,cdateadd,cuseradd,cdelete,ctipodocument,cnumdocu,cporcinvendible,ctotaldocu,cidmotivo,calicuota,cbasegrabada) values" + "('" +
                   Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_NDId + "','" + _Str_ProvId + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Str_Descripcion.Trim().ToUpper() + "','" + _Dbl_MontoSI.ToString().Replace(",", ".") + "','" + _Dbl_MontoImp.ToString().Replace(",", ".") + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + _Str_Fact + "','" + Convert.ToString(_DRow["cnumdocu"]) + "',0,'" + _Str_MontoDesc.Replace(",", ".") + "'," + _Str_Motivo + "," + _Dbl_Tasa.ToString().Replace(",", ".") + "," + _Dbl_MontoSI.ToString().Replace(",", ".") + ")";
                   Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                   _Str_Sql = "UPDATE TPAGOSCXPD SET cncppp=" + _Str_NDId + " WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _P_Str_OrdenPago + "' AND ctipodocument='" + Convert.ToString(_DRow["ctipodocument"]) + "' AND cnumdocu='" + Convert.ToString(_DRow["cnumdocu"]) + "' AND cproveedor='" + _Str_ProvId + "'";
                   Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                   //GENERO EL COMPROBANTE CONTABLE CONTABLE
                   _Int_Comprob = _Mtd_Proceso_P_CXP_ND_DESCPPP(_Str_NDId, _Str_ProvId);
                   _Str_Sql = "UPDATE TNOTADEBITOCP SET cidcomprob=" + _Int_Comprob.ToString() + ",cdescontada='1',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Str_NDId + "'";
                   Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                   _Str_Sql = "UPDATE TFACTPPAGARM SET cordenpaghecha=1, csaldo=0,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_ProvId + "' AND ctipodocument='" + _Str_ND + "' AND cnumdocu='" + _Str_NDId + "'";
                   Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                   _Str_Sql = "UPDATE TMOVCXPM SET csaldo=0,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_ProvId + "' AND ctipodocument='" + _Str_ND + "' AND cnumdocu='" + _Str_NDId + "'";
                   Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
               }
           }

       }
       public void _Mtd_InsertarAuxiliarFACT(string _P_Str_PreCarga, string _P_Str_Comprobante, string _P_Str_Comp, string _P_Str_ProcesoCont)
       {
           CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(_P_Str_Comp, _P_Str_Comprobante);
           string _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate(_P_Str_Comp).ToShortDateString(), _P_Str_Comp);
           string _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate(_P_Str_Comp).ToShortDateString(), _P_Str_Comp);
           string _Str_TipoFact = _Mtd_TipoDocument_CXC("ctipdocfact", _P_Str_Comp);
           double _Dbl_Monto = 0;
           string _Str_Cadena = "SELECT TFACTURAM.cfactura, TFACTURAM.c_fecha_factura, SUM(ISNULL(TFACTURAD.c_monto_si_bs,0)+ISNULL(TFACTURAD.cdescppmonto,0)) AS c_montotot_si, SUM(ISNULL(TFACTURAD.c_impuesto_bs,0)) AS c_impuesto,SUM(ISNULL(TFACTURAD.cdescppmonto,0)) AS c_desc_dpp,SUM(ISNULL(TFACTURAD.c_monto_si_bs,0) + ISNULL(TFACTURAD.c_impuesto_bs,0)) AS c_montotot, TFACTURAM.ccliente FROM TFACTURAM INNER JOIN TFACTURAD ON TFACTURAM.cgroupcomp=TFACTURAD.cgroupcomp AND TFACTURAM.ccompany=TFACTURAD.ccompany AND TFACTURAM.cfactura=TFACTURAD.cfactura WHERE (TFACTURAM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TFACTURAM.ccompany = '" + _P_Str_Comp + "') AND (TFACTURAM.cprecarga = '" + _P_Str_PreCarga + "') AND (TFACTURAM.cdelete <> 1) AND (TFACTURAM.c_factdevuelta = '0') GROUP BY TFACTURAM.cfactura,TFACTURAM.c_fecha_factura,TFACTURAM.ccliente ORDER BY TFACTURAM.cfactura";
           DataSet _Ds_Fact = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
           _Str_Cadena = "SELECT ccount,ccountname,cnaturaleza,cideprocesod FROM VST_PROCESOSCONTD WHERE cidproceso='" + _P_Str_ProcesoCont + "' AND ccompany='" + _P_Str_Comp + "' ORDER BY cideprocesod";
           DataSet _Ds_Count = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
           foreach (DataRow _Row_Count in _Ds_Count.Tables[0].Rows)
           {
               foreach (DataRow _Row_Fact in _Ds_Fact.Tables[0].Rows)
               {
                   _Str_Cadena = _Row_Count["ccountname"].ToString().Trim() + " FACT. # " + _Row_Fact["cfactura"].ToString().Trim();
                   if (_Row_Count["cideprocesod"].ToString().Trim() == "1")
                   { _Dbl_Monto = Convert.ToDouble(_Row_Fact["c_montotot"]); }
                   else if (_Row_Count["cideprocesod"].ToString().Trim() == "2")
                   { _Dbl_Monto = Convert.ToDouble(_Row_Fact["c_montotot_si"]); }
                   else if (_Row_Count["cideprocesod"].ToString().Trim() == "3")
                   { _Dbl_Monto = Convert.ToDouble(_Row_Fact["c_impuesto"]); }
                   else
                   { _Dbl_Monto = Convert.ToDouble(_Row_Fact["c_desc_dpp"]); }
                   if (_Dbl_Monto > 0)
                   {
                       CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_P_Str_Comprobante, _Row_Count["ccount"].ToString().Trim(), _Row_Fact["ccliente"].ToString().Trim(), _Str_Cadena, _Str_TipoFact, _Row_Fact["cfactura"].ToString().Trim(), _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Row_Fact["c_fecha_factura"])), "null", CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), _Str_cmontacco, _Str_cyearacco, _Row_Count["cnaturaleza"].ToString().Trim().ToUpper(), true, _P_Str_Comp);
                   }
               }
           }
       }
       public void _Mtd_InsertarAuxiliarNC(string _P_Str_NC_Desde, string _P_Str_NC_Hasta, string _P_Str_Comprobante, string _P_Str_Proceso)
       {
           CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _P_Str_Comprobante);
           string _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString());
           string _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString());
           double _Dbl_Monto = 0;
           string _Str_Cadena = "SELECT TNOTACREDICC.cidnotcredicc, TNOTACREDICC.cfecha, TNOTACREDICC.cfvfnotcredcc, TCONFIGCXC.ctipdocnotcred, (ISNULL(TNOTACREDICC.cmontototsi, 0) + ISNULL(TNOTACREDICC.cexento, 0)) AS cmontototsi, ISNULL(TNOTACREDICC.cimpuesto, 0) AS cimpuesto, ISNULL(TNOTACREDICC.ctotaldocu, 0) AS ctotaldocu, TNOTACREDICC.ccliente FROM TNOTACREDICC INNER JOIN TCONFIGCXC ON TNOTACREDICC.ccompany = TCONFIGCXC.ccompany WHERE (TNOTACREDICC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTACREDICC.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTACREDICC.cidnotcredicc BETWEEN '" + _P_Str_NC_Desde + "' AND '" + _P_Str_NC_Hasta + "') AND (TNOTACREDICC.cidcomprob='" + _P_Str_Comprobante + "') AND NOT EXISTS(SELECT cidnotcredicc FROM TNOTACREDICCD WHERE TNOTACREDICCD.cgroupcomp=TNOTACREDICC.cgroupcomp AND TNOTACREDICCD.ccompany=TNOTACREDICC.ccompany AND TNOTACREDICCD.cidnotcredicc=TNOTACREDICC.cidnotcredicc) ORDER BY TNOTACREDICC.cidnotcredicc";
           DataSet _Ds_NC = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
           if (_Ds_NC.Tables[0].Rows.Count > 0)
           {
               _Str_Cadena = "SELECT ccount,ccountname,cnaturaleza,cideprocesod FROM VST_PROCESOSCONTD WHERE cidproceso='" + _P_Str_Proceso + "' AND (ccompany='" + Frm_Padre._Str_Comp + "'  OR ccompany IS NULL) ORDER BY cideprocesod";
               DataSet _Ds_Count = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
               foreach (DataRow _Row_Count in _Ds_Count.Tables[0].Rows)
               {
                   foreach (DataRow _Row_NC in _Ds_NC.Tables[0].Rows)
                   {
                       _Str_Cadena = _Row_Count["ccountname"].ToString().Trim() + " NC EMIT # " + _Row_NC["cidnotcredicc"].ToString().Trim();
                       if (_Row_Count["cideprocesod"].ToString().Trim() == "1")
                       { _Dbl_Monto = Convert.ToDouble(_Row_NC["cmontototsi"]); }
                       else if (_Row_Count["cideprocesod"].ToString().Trim() == "2")
                       { _Dbl_Monto = Convert.ToDouble(_Row_NC["cimpuesto"]); }
                       else
                       { _Dbl_Monto = Convert.ToDouble(_Row_NC["ctotaldocu"]); }
                       if (_Dbl_Monto > 0)
                       {
                           CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_P_Str_Comprobante, _Row_Count["ccount"].ToString().Trim(), _Row_NC["ccliente"].ToString().Trim(), _Str_Cadena, _Row_NC["ctipdocnotcred"].ToString().Trim(), _Row_NC["cidnotcredicc"].ToString().Trim(), _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Row_NC["cfecha"])), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), _Str_cmontacco, _Str_cyearacco, _Row_Count["cnaturaleza"].ToString().Trim().ToUpper());
                       }
                   }
               }
           }
           _Str_Cadena = "SELECT TNOTACREDICC.cidnotcredicc, TNOTACREDICC.cfecha, TNOTACREDICC.cfvfnotcredcc, TCONFIGCXC.ctipdocnotcred, SUM(TNOTACREDICCD.cmontosimp + ISNULL(TNOTACREDICCD.cbasexcenta,0)) AS cmontototsi,SUM(TNOTACREDICCD.cimpuesto) AS cimpuesto,SUM(TNOTACREDICCD.cmontototal) AS ctotaldocu,SUM(ISNULL(TNOTACREDICCD.cmontosimpdpp,0)) AS cmontosimpdpp,SUM(ISNULL(TNOTACREDICCD.cimpuestodpp,0)) AS cimpuestodpp,SUM(ISNULL(TNOTACREDICCD.cbasexcentadpp,0)) AS cbasexcentadpp,SUM(ISNULL(TNOTACREDICCD.cmontototaldpp,0)) AS cmontototaldpp, TNOTACREDICC.ccliente FROM TNOTACREDICC INNER JOIN TNOTACREDICCD ON TNOTACREDICC.cgroupcomp=TNOTACREDICCD.cgroupcomp AND TNOTACREDICC.ccompany=TNOTACREDICCD.ccompany AND TNOTACREDICC.cidnotcredicc=TNOTACREDICCD.cidnotcredicc INNER JOIN TCONFIGCXC ON TNOTACREDICC.ccompany = TCONFIGCXC.ccompany WHERE (TNOTACREDICC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTACREDICC.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTACREDICC.cidnotcredicc BETWEEN '" + _P_Str_NC_Desde + "' AND '" + _P_Str_NC_Hasta + "') AND (TNOTACREDICC.cidcomprob='" + _P_Str_Comprobante + "') GROUP BY TNOTACREDICC.cidnotcredicc,TNOTACREDICC.cfecha,TNOTACREDICC.cfvfnotcredcc,TNOTACREDICC.ccliente,TCONFIGCXC.ctipdocnotcred ORDER BY TNOTACREDICC.cidnotcredicc";
           _Ds_NC = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
           if (_Ds_NC.Tables[0].Rows.Count > 0)
           {
               _Str_Cadena = "SELECT ccount,ccountname,cnaturaleza,cideprocesod FROM VST_PROCESOSCONTD WHERE cidproceso='" + _P_Str_Proceso + "' AND (ccompany='" + Frm_Padre._Str_Comp + "'  OR ccompany IS NULL) ORDER BY cideprocesod";
               DataSet _Ds_Count = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
               foreach (DataRow _Row_Count in _Ds_Count.Tables[0].Rows)
               {
                   foreach (DataRow _Row_NC in _Ds_NC.Tables[0].Rows)
                   {
                       _Str_Cadena = _Row_Count["ccountname"].ToString().Trim() + " NC EMIT # " + _Row_NC["cidnotcredicc"].ToString().Trim();
                       if (_Row_Count["cideprocesod"].ToString().Trim() == "1")
                       { _Dbl_Monto = Convert.ToDouble(_Row_NC["cmontototsi"]) + Convert.ToDouble(_Row_NC["cmontosimpdpp"]) + Convert.ToDouble(_Row_NC["cbasexcentadpp"]); }
                       else if (_Row_Count["cideprocesod"].ToString().Trim() == "2")
                       { _Dbl_Monto = Convert.ToDouble(_Row_NC["cimpuesto"]); }
                       else if (_Row_Count["cideprocesod"].ToString().Trim() == "3")
                       { _Dbl_Monto = Convert.ToDouble(_Row_NC["ctotaldocu"]); }
                       else
                       { _Dbl_Monto = Convert.ToDouble(_Row_NC["cmontosimpdpp"]) + Convert.ToDouble(_Row_NC["cbasexcentadpp"]); }
                       if (_Dbl_Monto > 0)
                       {
                           CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_P_Str_Comprobante, _Row_Count["ccount"].ToString().Trim(), _Row_NC["ccliente"].ToString().Trim(), _Str_Cadena, _Row_NC["ctipdocnotcred"].ToString().Trim(), _Row_NC["cidnotcredicc"].ToString().Trim(), _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Row_NC["cfecha"])), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), _Str_cmontacco, _Str_cyearacco, _Row_Count["cnaturaleza"].ToString().Trim().ToUpper());
                       }
                   }
               }
           }
       }
       public void _Mtd_InsertarAuxiliarND(string _P_Str_ND_Desde, string _P_Str_ND_Hasta, string _P_Str_Comprobante, string _P_Str_Proceso)
       {
           CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _P_Str_Comprobante);
           string _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString());
           string _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString());
           double _Dbl_Monto = 0;
           string _Str_Cadena = "SELECT TNOTADEBICC.cidnotadebitocc, TNOTADEBICC.cfecha, TNOTADEBICC.cfvfnotadebitop, TCONFIGCXC.ctipdocnotdeb, (ISNULL(TNOTADEBICC.cmontototsi, 0) + ISNULL(TNOTADEBICC.cexento, 0)) AS cmontototsi, ISNULL(TNOTADEBICC.cimpuesto, 0) AS cimpuesto, ISNULL(TNOTADEBICC.ctotaldocu, 0) AS ctotaldocu, TNOTADEBICC.ccliente FROM TNOTADEBICC INNER JOIN TCONFIGCXC ON TNOTADEBICC.ccompany = TCONFIGCXC.ccompany WHERE (TNOTADEBICC.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TNOTADEBICC.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TNOTADEBICC.cidnotadebitocc BETWEEN '" + _P_Str_ND_Desde + "' AND '" + _P_Str_ND_Hasta + "') AND (TNOTADEBICC.cidcomprob='" + _P_Str_Comprobante + "')  ORDER BY TNOTADEBICC.cidnotadebitocc";
           DataSet _Ds_ND = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
           _Str_Cadena = "SELECT ccount,ccountname,cnaturaleza,cideprocesod FROM VST_PROCESOSCONTD WHERE cidproceso='" + _P_Str_Proceso + "' AND (ccompany='" + Frm_Padre._Str_Comp + "'  OR ccompany IS NULL) ORDER BY cideprocesod";
           DataSet _Ds_Count = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
           foreach (DataRow _Row_Count in _Ds_Count.Tables[0].Rows)
           {
               foreach (DataRow _Row_ND in _Ds_ND.Tables[0].Rows)
               {
                   _Str_Cadena = _Row_Count["ccountname"].ToString().Trim() + " ND EMIT # " + _Row_ND["cidnotadebitocc"].ToString().Trim();
                   if (_Row_Count["cideprocesod"].ToString().Trim() == "1")
                   { _Dbl_Monto = Convert.ToDouble(_Row_ND["ctotaldocu"]); }
                   else if (_Row_Count["cideprocesod"].ToString().Trim() == "2")
                   { _Dbl_Monto = Convert.ToDouble(_Row_ND["cmontototsi"]); }
                   else
                   { _Dbl_Monto = Convert.ToDouble(_Row_ND["cimpuesto"]); }
                   CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_P_Str_Comprobante, _Row_Count["ccount"].ToString().Trim(), _Row_ND["ccliente"].ToString().Trim(), _Str_Cadena, _Row_ND["ctipdocnotdeb"].ToString().Trim(), _Row_ND["cidnotadebitocc"].ToString().Trim(), _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Row_ND["cfecha"])), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto), _Str_cmontacco, _Str_cyearacco, _Row_Count["cnaturaleza"].ToString().Trim().ToUpper());
               }
           }
       }
       public static string _Mtd_ObtenerTipoAuxiliar(string _P_Str_Cuenta, string _P_Str_TipoDocument)
       {
           string _Str_Cadena = "SELECT TOP 1 cidtipoauxiliar FROM TTIPAUXILIARCONTD WHERE ctcount='" + _P_Str_Cuenta + "' AND ctdocument='" + _P_Str_TipoDocument + "'";
           DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
           if (_Ds.Tables[0].Rows.Count > 0)
           {
               return _Ds.Tables[0].Rows[0][0].ToString().Trim();
           }
           return "0";
       }

       public static void _Mtd_EliminarAuxiliarCont(string _P_Str_Comp, string _P_Str_IdComprob)
       {
           try
           {
               string _Str_Cadena = "Delete from TCOMPROBANDD where ccompany='" + _P_Str_Comp + "' and cidcomprob='" + _P_Str_IdComprob + "'";
               Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
               _Str_Cadena = "Delete from TMOVAUXILIARCONT where ccompany='" + _P_Str_Comp + "' and cidcomprob='" + _P_Str_IdComprob + "'";
               Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
           }
           catch { }
       }

       public static void _Mtd_InsertAuxiliarCont(string _P_Str_Comprobante, string _P_Str_Cuenta, string _P_Str_Id_Auxiliar, string _P_Str_Descripcion, string _P_Str_TipoDocument, string _P_Str_Documento, string _P_Str_FechaEmision, string _P_Str_FechaVencimiento, string _P_Str_Monto, string _P_Str_MonthCont, string _P_Str_YearCont,string _P_Str_DebeHaber)
       {
           _P_Str_Descripcion = _P_Str_Descripcion.Replace("'", "''");
           string _Str_Cadena = "SELECT cauxiliary,cclasificauxiliar FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _P_Str_Cuenta + "' AND cauxiliary='1'";
           DataSet _Ds=Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
           if (_Ds.Tables[0].Rows.Count > 0)
           {
               if (_P_Str_FechaEmision.Trim() != "null") { _P_Str_FechaEmision = "'" + _P_Str_FechaEmision + "'"; }
               if (_P_Str_FechaVencimiento.Trim() != "null") { _P_Str_FechaVencimiento = "'" + _P_Str_FechaVencimiento + "'"; }
               string _Str_TipoAuxiliar = _Mtd_ObtenerTipoAuxiliar(_P_Str_Cuenta, _P_Str_TipoDocument);
               string _Str_Clasificacion = "0";
               if (_Ds.Tables[0].Rows[0]["cclasificauxiliar"].ToString().Trim().Length > 0)
               { _Str_Clasificacion = _Ds.Tables[0].Rows[0]["cclasificauxiliar"].ToString().Trim(); }
               if (_P_Str_DebeHaber.Trim() == "D")
               { _Str_Cadena = "INSERT INTO TCOMPROBANDD (ccompany,cidcomprob,ccount,cidtipoauxiliar,cidauxiliarcont,cdescrip,ctdocument,cnumdocu,cfechaemision,cfechavencimiento,cdebe,chaber,cmontacco,cyearacco,cstatus,cclasificauxiliar) VALUES ('" + Frm_Padre._Str_Comp + "','" + _P_Str_Comprobante + "','" + _P_Str_Cuenta + "','" + _Str_TipoAuxiliar + "','" + _P_Str_Id_Auxiliar + "','" + _P_Str_Descripcion + "','" + _P_Str_TipoDocument + "','" + _P_Str_Documento + "'," + _P_Str_FechaEmision + "," + _P_Str_FechaVencimiento + ",'" + _P_Str_Monto + "','0','" + _P_Str_MonthCont + "','" + _P_Str_YearCont + "','0','" + _Str_Clasificacion + "')"; }
               else
               { _Str_Cadena = "INSERT INTO TCOMPROBANDD (ccompany,cidcomprob,ccount,cidtipoauxiliar,cidauxiliarcont,cdescrip,ctdocument,cnumdocu,cfechaemision,cfechavencimiento,cdebe,chaber,cmontacco,cyearacco,cstatus,cclasificauxiliar) VALUES ('" + Frm_Padre._Str_Comp + "','" + _P_Str_Comprobante + "','" + _P_Str_Cuenta + "','" + _Str_TipoAuxiliar + "','" + _P_Str_Id_Auxiliar + "','" + _P_Str_Descripcion + "','" + _P_Str_TipoDocument + "','" + _P_Str_Documento + "'," + _P_Str_FechaEmision + "," + _P_Str_FechaVencimiento + ",'0','" + _P_Str_Monto + "','" + _P_Str_MonthCont + "','" + _P_Str_YearCont + "','0','" + _Str_Clasificacion + "')"; }
               Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
           }
       }
       public static void _Mtd_InsertAuxiliarCont(string _P_Str_Comprobante, string _P_Str_Cuenta, string _P_Str_Id_Auxiliar, string _P_Str_Descripcion, string _P_Str_TipoDocument, string _P_Str_Documento, string _P_Str_FechaEmision, string _P_Str_FechaVencimiento, string _P_Str_Monto, string _P_Str_MonthCont, string _P_Str_YearCont, string _P_Str_DebeHaber, bool _P_Bol_VariasComp, string _P_Str_Comp)
       {
           string _Str_Cadena = "SELECT cauxiliary,cclasificauxiliar FROM TCOUNT WHERE ccompany='" + _P_Str_Comp + "' AND ccount='" + _P_Str_Cuenta + "' AND cauxiliary='1'";
           DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
           if (_Ds.Tables[0].Rows.Count > 0)
           {
               if (_P_Str_FechaEmision.Trim() != "null") { _P_Str_FechaEmision = "'" + _P_Str_FechaEmision + "'"; }
               if (_P_Str_FechaVencimiento.Trim() != "null") { _P_Str_FechaVencimiento = "'" + _P_Str_FechaVencimiento + "'"; }
               string _Str_TipoAuxiliar = _Mtd_ObtenerTipoAuxiliar(_P_Str_Cuenta, _P_Str_TipoDocument);
               string _Str_Clasificacion = "0";
               if (_Ds.Tables[0].Rows[0]["cclasificauxiliar"].ToString().Trim().Length > 0)
               { _Str_Clasificacion = _Ds.Tables[0].Rows[0]["cclasificauxiliar"].ToString().Trim(); }
               if (_P_Str_DebeHaber.Trim() == "D")
               { _Str_Cadena = "INSERT INTO TCOMPROBANDD (ccompany,cidcomprob,ccount,cidtipoauxiliar,cidauxiliarcont,cdescrip,ctdocument,cnumdocu,cfechaemision,cfechavencimiento,cdebe,chaber,cmontacco,cyearacco,cstatus,cclasificauxiliar) VALUES ('" + _P_Str_Comp + "','" + _P_Str_Comprobante + "','" + _P_Str_Cuenta + "','" + _Str_TipoAuxiliar + "','" + _P_Str_Id_Auxiliar + "','" + _P_Str_Descripcion + "','" + _P_Str_TipoDocument + "','" + _P_Str_Documento + "'," + _P_Str_FechaEmision + "," + _P_Str_FechaVencimiento + ",'" + _P_Str_Monto + "','0','" + _P_Str_MonthCont + "','" + _P_Str_YearCont + "','0','" + _Str_Clasificacion + "')"; }
               else
               { _Str_Cadena = "INSERT INTO TCOMPROBANDD (ccompany,cidcomprob,ccount,cidtipoauxiliar,cidauxiliarcont,cdescrip,ctdocument,cnumdocu,cfechaemision,cfechavencimiento,cdebe,chaber,cmontacco,cyearacco,cstatus,cclasificauxiliar) VALUES ('" + _P_Str_Comp + "','" + _P_Str_Comprobante + "','" + _P_Str_Cuenta + "','" + _Str_TipoAuxiliar + "','" + _P_Str_Id_Auxiliar + "','" + _P_Str_Descripcion + "','" + _P_Str_TipoDocument + "','" + _P_Str_Documento + "'," + _P_Str_FechaEmision + "," + _P_Str_FechaVencimiento + ",'0','" + _P_Str_Monto + "','" + _P_Str_MonthCont + "','" + _P_Str_YearCont + "','0','" + _Str_Clasificacion + "')"; }
               Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
           }
       }
       public static void _Mtd_InsertAuxiliarCont(string _P_Str_Comprobante, string _P_Str_Cuenta, string _P_Str_Id_Auxiliar, string _P_Str_Descripcion, string _P_Str_TipoDocument, string _P_Str_Documento, string _P_Str_FechaEmision, string _P_Str_FechaVencimiento, string _P_Str_Monto, string _P_Str_MonthCont, string _P_Str_YearCont, string _P_Str_DebeHaber,string _P_Str_Order)
       {
           string _Str_Cadena = "SELECT cauxiliary,cclasificauxiliar FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _P_Str_Cuenta + "' AND cauxiliary='1'";
           DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
           if (_Ds.Tables[0].Rows.Count > 0)
           {
               if (_P_Str_FechaEmision.Trim() != "null") { _P_Str_FechaEmision = "'" + _P_Str_FechaEmision + "'"; }
               if (_P_Str_FechaVencimiento.Trim() != "null") { _P_Str_FechaVencimiento = "'" + _P_Str_FechaVencimiento + "'"; }
               string _Str_TipoAuxiliar = _Mtd_ObtenerTipoAuxiliar(_P_Str_Cuenta, _P_Str_TipoDocument);
               string _Str_Clasificacion = "0";
               if (_Ds.Tables[0].Rows[0]["cclasificauxiliar"].ToString().Trim().Length > 0)
               { _Str_Clasificacion = _Ds.Tables[0].Rows[0]["cclasificauxiliar"].ToString().Trim(); }
               if (_P_Str_DebeHaber.Trim() == "D")
               { _Str_Cadena = "INSERT INTO TCOMPROBANDD (ccompany,cidcomprob,ccount,cidtipoauxiliar,cidauxiliarcont,cdescrip,ctdocument,cnumdocu,cfechaemision,cfechavencimiento,cdebe,chaber,cmontacco,cyearacco,cstatus,corder,cclasificauxiliar) VALUES ('" + Frm_Padre._Str_Comp + "','" + _P_Str_Comprobante + "','" + _P_Str_Cuenta + "','" + _Str_TipoAuxiliar + "','" + _P_Str_Id_Auxiliar + "','" + _P_Str_Descripcion + "','" + _P_Str_TipoDocument + "','" + _P_Str_Documento + "'," + _P_Str_FechaEmision + "," + _P_Str_FechaVencimiento + ",'" + _P_Str_Monto + "','0','" + _P_Str_MonthCont + "','" + _P_Str_YearCont + "','0','" + _P_Str_Order + "','" + _Str_Clasificacion + "')"; }
               else
               { _Str_Cadena = "INSERT INTO TCOMPROBANDD (ccompany,cidcomprob,ccount,cidtipoauxiliar,cidauxiliarcont,cdescrip,ctdocument,cnumdocu,cfechaemision,cfechavencimiento,cdebe,chaber,cmontacco,cyearacco,cstatus,corder,cclasificauxiliar) VALUES ('" + Frm_Padre._Str_Comp + "','" + _P_Str_Comprobante + "','" + _P_Str_Cuenta + "','" + _Str_TipoAuxiliar + "','" + _P_Str_Id_Auxiliar + "','" + _P_Str_Descripcion + "','" + _P_Str_TipoDocument + "','" + _P_Str_Documento + "'," + _P_Str_FechaEmision + "," + _P_Str_FechaVencimiento + ",'0','" + _P_Str_Monto + "','" + _P_Str_MonthCont + "','" + _P_Str_YearCont + "','0','" + _P_Str_Order + "','" + _Str_Clasificacion + "')"; }
               Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
           }
       }
       public static string _Mtd_SQL_Comp()
       {
           //return _P_Str_TABLA + " INNER JOIN TGROUPCOMPANYD ON TGROUPCOMPANYD.ccompany=" + _P_Str_TABLA + ".ccompany  WHERE TGROUPCOMPANYD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
           string _Str_Cadena = "SELECT ccompany FROM TGROUPCOMPANYD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
           DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
           _Str_Cadena = "";
           foreach (DataRow _Row in _Ds.Tables[0].Rows)
           {
               if (_Str_Cadena.Trim().Length == 0)
               { _Str_Cadena = "(ccompany='" + _Row[0].ToString().Trim() + "'"; }
               else
               { _Str_Cadena += " OR ccompany='" + _Row[0].ToString().Trim() + "'"; }
           }
           return _Str_Cadena + ")";
       }
       public static string _Mtd_NombComp(string _P_Str_Comp)
       {
           string _Str_Cadena = "Select cname from TCOMPANY WHERE ccompany='" + _P_Str_Comp + "' AND cdelete='0'";
           DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
           if (_Ds.Tables[0].Rows.Count > 0)
           {
               return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
           }
           return "";
       }
       public static string _Mtd_RifComp(string _P_Str_Comp)
       {
           string _Str_Cadena = "Select crif from TCOMPANY WHERE ccompany='" + _P_Str_Comp + "' AND cdelete='0'";
           DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
           if (_Ds.Tables[0].Rows.Count > 0)
           {
               return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
           }
           return "";
       }
       public static string _Mtd_PrefComp(string _P_Str_Comp)
       {
           string _Str_Cadena = "Select cabreviado from TCOMPANY WHERE ccompany='" + _P_Str_Comp + "' AND cdelete='0'";
           DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
           if (_Ds.Tables[0].Rows.Count > 0)
           {
               return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
           }
           return "";
       }
       public static string _Mtd_ObtenerPrefijoCorrel(string _P_Str_Comp)
       {
           string _Str_Cadena = "SELECT cprefijocorrel FROM TCOMPANY WHERE ccompany='" + _P_Str_Comp + "'";
           DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
           if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
           { return _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
           return "";
       }
       public string _Mtd_NombAbrevProveedor(string _P_Str_Proveedor, string _P_Str_Comp)
       {
           string _Str_Cadena = "SELECT c_nomb_abreviado FROM TPROVEEDOR WHERE cproveedor='" + _P_Str_Proveedor + "' AND (ccompany='" + _P_Str_Comp + "' OR cglobal='1')";
           DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
           if (_Ds.Tables[0].Rows.Count > 0)
           { return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(); }
           return "";
       }
       public void _Mtd_Proceso_GenerarComprobRetencion(string _Pr_Str_ProvId, string _Pr_Str_TpoDoc, string _Pr_Str_NDoc, string _Pr_Str_NRecepcion)
       {
           string _Str_CompanyRetenExterna = CLASES._Cls_Varios_Metodos._Mtd_CompanyRetenExterna();
           string _Str_Cadena = "";
           string _Str_TipoDocRetIVA = "";
           string _Str_ProvRetIVA = "";
           string _Str_ProvRetIVA_Categoria = "";
           string _Str_ProvRetIVA_Tipo = "";
           string _Str_Prov_Categoria = "";
           string _Str_Prov_Tipo = "";
           string _Str_NombProveedor = _Mtd_NombAbrevProveedor(_Pr_Str_ProvId, Frm_Padre._Str_Comp);
           DataSet _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctipdocretiva,cprovretiva FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
           if (_Ds_Temp.Tables[0].Rows.Count > 0)
           {
               _Str_TipoDocRetIVA = Convert.ToString(_Ds_Temp.Tables[0].Rows[0]["ctipdocretiva"]);
               _Str_ProvRetIVA = Convert.ToString(_Ds_Temp.Tables[0].Rows[0]["cprovretiva"]);
               _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ccatproveedor,cglobal FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) AND cproveedor='" + _Str_ProvRetIVA + "'");
               if (_Ds_Temp.Tables[0].Rows.Count > 0)
               {
                   _Str_ProvRetIVA_Categoria = Convert.ToString(_Ds_Temp.Tables[0].Rows[0]["ccatproveedor"]);
                   _Str_ProvRetIVA_Tipo = Convert.ToString(_Ds_Temp.Tables[0].Rows[0]["cglobal"]);
               }
               _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ccatproveedor,cglobal FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) AND cproveedor='" + _Pr_Str_ProvId + "'");
               if (_Ds_Temp.Tables[0].Rows.Count > 0)
               {
                   _Str_Prov_Categoria = Convert.ToString(_Ds_Temp.Tables[0].Rows[0]["ccatproveedor"]);
                   _Str_Prov_Tipo = Convert.ToString(_Ds_Temp.Tables[0].Rows[0]["cglobal"]);
               }
           }
           string _Str_cidcomprobret = "";
           _Str_cidcomprobret = _Mtd_Correlativo("SELECT MAX(cidcomprobret) FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
           //--------RETENCIÓN EXTERNA
           if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
           {
               _Str_cidcomprobret = _Mtd_CorrelativoExterno("SELECT MAX(cidcomprobret) FROM TCOMPROBANRETC WHERE ccompany='" + _Str_CompanyRetenExterna + "'");
           }
           //--------
           string _Str_Sql = ""; string _Str_ProvNombre = "";
           double _Dbl_PorcRetiene = 0;
           double _Dbl_Retiene = 0;
           string _Str_calicuotaporc = "";
           string _Str_FactPDetId = "";
           string _Str_CXPId = "";
           //DATOS DE LA FACTURA
           string _Str_cfechadocu = "";
           double _Dbl_cmontosi = 0;
           double _Dbl_cmontoimp = 0;
           double _Dbl_totDoc = 0;
           double _Dbl_MontoExcento = 0;
           string _Str_FechaVenc = "";
           string _Str_DocCtrl = "";
           //VARIABLES PARA EL COMPROBANTE CONTABLE
           string _Str_cconceptocomp = "";
           string _Str_ctypcompro = "";
           string _Str_cyearacco = "";
           string _Str_cmontacco = "";
           string _Str_cidcomprob = "";
           string _Str_Descrip = "";
           string _Str_corder = "";
           string _Str_cnumdocu = "";
           string _Str_cidcomprobretId = "", _Str_CountCont = "", _Str_CountContName = "";
           //PARA LA RETENCION
           string _Str_ctipotransacc = "";
           DataSet _Datset;
           //GENERO EL COMPROBANTE CONTABLE
           Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_CXP_COMP_RETENCION");
           DataSet _Ds;
           _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
           _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
           _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cporcenreteniva,c_nomb_abreviado from TPROVEEDOR where (ccompany='" + Frm_Padre._Str_Comp + "' or cglobal=1) and cproveedor='" + _Pr_Str_ProvId + "'");
           if (_Ds.Tables[0].Rows.Count > 0)
           {
               _Dbl_PorcRetiene = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
               _Str_ProvNombre = Convert.ToString(_Ds.Tables[0].Rows[0][1]);
           }
           _Str_Sql = "Select cnfacturapro,cdateemifactura,ctotmontsimp-ISNULL(cbaseexcenta,0) AS ctotmontsimp,ctotalimp,cdatevencimiento,cnumdocuctrl,ctotfactura,ISNULL(cbaseexcenta,0) AS cbaseexcenta from TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Pr_Str_NRecepcion + "' and cproveedor='" + _Pr_Str_ProvId + "' and cnfacturapro='" + _Pr_Str_NDoc + "'";
           _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
           if (_Ds.Tables[0].Rows.Count > 0)
           {
               _Str_cnumdocu = _Ds.Tables[0].Rows[0][0].ToString();
               _Str_cfechadocu = Convert.ToDateTime(_Ds.Tables[0].Rows[0][1]).ToShortDateString();
               _Dbl_cmontosi = Convert.ToDouble(_Ds.Tables[0].Rows[0][2]);
               _Dbl_cmontoimp = Convert.ToDouble(_Ds.Tables[0].Rows[0][3]);
               _Dbl_totDoc = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotfactura"]);
               _Str_FechaVenc = Convert.ToDateTime(_Ds.Tables[0].Rows[0][4]).ToShortDateString();
               _Str_DocCtrl = Convert.ToString(_Ds.Tables[0].Rows[0][5]);
               _Dbl_MontoExcento = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cbaseexcenta"].ToString().Trim());
           }
           _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Mtd_SQLGetDate().ToShortDateString());
           _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Mtd_SQLGetDate().ToShortDateString());
           //ENCABEZADO DEL COMPROBANTE
           if (_Dbl_PorcRetiene > 1)
           {
               _Dbl_Retiene = (_Dbl_PorcRetiene * _Dbl_cmontoimp) / 100;
           }
           else
           { _Dbl_Retiene = 0; }
           _Str_cidcomprob = Convert.ToString(_Mtd_Consecutivo_TCOMPROBANC());
           _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) values ('";
           _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retiene) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retiene) + "',0,'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',0,'0')";
           Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
           CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);
           //DETALLE DEL COMPROBANTE
           //CUENTA DE LA CUENTA POR PAGAR
           _Str_Sql = "Select ccount,ctipodocumento,cnaturaleza,cideprocesod from TPROCESOSCONTD where cidproceso='P_CXP_COMP_RETENCION' ORDER BY cideprocesod";
           _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
           foreach (DataRow _DRow in _Ds.Tables[0].Rows)
           {
               _Str_CountCont = Convert.ToString(_DRow["ccount"]).Trim();
               if (_DRow["cideprocesod"].ToString() == "1")
               {
                   _Str_CountContName = "RETENCIONES DE IMPUESTO.";
               }
               else if (_DRow["cideprocesod"].ToString() == "2")
               {
                   _Str_Sql = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_CountCont + "'";
                   _Datset = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                   if (_Datset.Tables[0].Rows.Count > 0)
                   {
                       _Str_CountContName = Convert.ToString(_Datset.Tables[0].Rows[0]["cname"]).Trim().ToUpper();
                   }
               }
               _Str_Descrip = _Str_CountContName + " COMPROBANTE DE RETENCION # " + _Str_cidcomprobret + " S/F# " + _Pr_Str_NDoc + " " + _Str_NombProveedor + " VEC:" + _Str_FechaVenc;
               _Str_corder = Convert.ToString(_Mtd_Consecutivo_TCOMPROBAND(_Str_cidcomprob));
               if (_DRow["cnaturaleza"].ToString() == "D")
               {
                   //_Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Pr_Str_TpoDoc + "','" + _Pr_Str_NDoc + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retiene) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                   _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Str_TipoDocRetIVA + "','" + _Str_cidcomprobret + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retiene) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip.Replace("'", "''") + "')";
                   Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
               }
               else if (_DRow["cnaturaleza"].ToString() == "H")
               {
                   //_Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Pr_Str_TpoDoc + "','" + _Pr_Str_NDoc + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retiene) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip + "')";
                   _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctothaber,cdateadd,cuseradd,cdescrip) values" + "('" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + _Str_CountCont + "','" + _Str_TipoDocRetIVA + "','" + _Str_cidcomprobret + "','" + _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retiene) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Str_Descrip.Replace("'", "''") + "')";
                   Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
               }
               CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, _Str_CountCont, _Pr_Str_ProvId, _Str_Descrip.Replace("'", "''"), _Str_TipoDocRetIVA, _Str_cidcomprobret, _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_cfechadocu)), _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaVenc)), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retiene), _Str_cmontacco, _Str_cyearacco, _DRow["cnaturaleza"].ToString().Trim().ToUpper());
           }

           //AHORA GENERO LA RETENCION
           _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cpercent FROM TTAX WHERE ctax=(SELECT ctipimpuesto FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "')");
           _Str_calicuotaporc = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
           _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctdocumentgov FROM TDOCUMENT WHERE ctdocument='" + _Pr_Str_TpoDoc + "'");
           if (_Ds.Tables[0].Rows.Count > 0)
           { _Str_ctipotransacc = Convert.ToString(_Ds.Tables[0].Rows[0][0]); }
           //_Str_cidcomprobret = _Mtd_Correlativo("SELECT MAX(cidcomprobret) FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
           //GUARDO LA CABECERA DE LA RETENCION
           _Str_Sql = "INSERT INTO TCOMPROBANRETC (ccompany,cidcomprobret,cidcomprob,cproveedor,cfechaemiret,cnumdocumafec,ctotcaomp_iva,ctotmontexcento,cimpuesto,cretenido,canulado,cimpreso,cascii,ctotcaomp_siva,cfechavencret,cdateadd,cuseradd) VALUES('" +
           Frm_Padre._Str_Comp + "'," + _Str_cidcomprobret + "," + _Str_cidcomprob + ",'" + _Pr_Str_ProvId + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Pr_Str_NDoc + "','" + _Dbl_totDoc.ToString().Replace(",", ".") + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoExcento) + "'," + _Dbl_cmontoimp.ToString().Replace(",", ".") + "," + _Dbl_Retiene.ToString().Replace(",", ".") + ",0,0,0," + _Dbl_cmontosi.ToString().Replace(",", ".") + ",'" + _Mtd_ObtenerFechaLimite(_Str_FechaVenc) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
           Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
           //--------RETENCIÓN EXTERNA
           if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
           {
               _Str_Sql = "INSERT INTO TCOMPROBANRETC (ccompany,cidcomprobret,cidcomprob,cproveedor,cfechaemiret,cnumdocumafec,ctotcaomp_iva,ctotmontexcento,cimpuesto,cretenido,canulado,cimpreso,cascii,ctotcaomp_siva,cfechavencret,cagregacomp,cdateadd,cuseradd) VALUES('" +
               _Str_CompanyRetenExterna + "'," + _Str_cidcomprobret + "," + _Str_cidcomprob + ",'" + _Pr_Str_ProvId + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Pr_Str_NDoc + "','" + _Dbl_totDoc.ToString().Replace(",", ".") + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoExcento) + "'," + _Dbl_cmontoimp.ToString().Replace(",", ".") + "," + _Dbl_Retiene.ToString().Replace(",", ".") + ",0,1,0," + _Dbl_cmontosi.ToString().Replace(",", ".") + ",'" + _Mtd_ObtenerFechaLimite(_Str_FechaVenc) + "','" + Frm_Padre._Str_Comp + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
               Program._MyClsCnn._Mtd_ConexionExterna._Mtd_EjecutarSentencia(_Str_Sql);
           }
           //--------
           //GUARDO EL DETALLE DE LA RETENCION
           _Str_cidcomprobretId = _Mtd_Correlativo("SELECT MAX(ciddetalleret) FROM TCOMPROBANRETD WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobret='" + _Str_cidcomprobret + "' and cproveedor='" + _Pr_Str_ProvId + "'");
           //--------RETENCIÓN EXTERNA
           if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
           {
               _Str_cidcomprobretId = _Mtd_CorrelativoExterno("SELECT MAX(ciddetalleret) FROM TCOMPROBANRETD WHERE ccompany='" + _Str_CompanyRetenExterna + "' and cidcomprobret='" + _Str_cidcomprobret + "' and cproveedor='" + _Pr_Str_ProvId + "'");
           }
           //--------
           _Str_Sql = "INSERT INTO TCOMPROBANRETD (ccompany,cidcomprobret,ciddetalleret,cproveedor,ctdocument,cnumdocu,cfechadocu,cnumcontrolfact,ctipotransacc,ctotcaomp_iva,cbaseimponible,calicuotaporc,cimpuesto,cretenido,cdateadd,cuseradd,ctotmontexcento) VALUES('" +
           Frm_Padre._Str_Comp + "'," + _Str_cidcomprobret + "," + _Str_cidcomprobretId + ",'" + _Pr_Str_ProvId + "','" + _Pr_Str_TpoDoc + "','" + _Pr_Str_NDoc + "','" + _Str_cfechadocu + "','" + _Str_DocCtrl + "','" + _Str_ctipotransacc + "'," + _Dbl_totDoc.ToString().Replace(",", ".") + "," + _Dbl_cmontosi.ToString().Replace(",", ".") + ",'" + _Str_calicuotaporc + "'," + _Dbl_cmontoimp.ToString().Replace(",", ".") + "," + _Dbl_Retiene.ToString().Replace(",", ".") + ",'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Dbl_MontoExcento.ToString().Replace(",", ".") + "')";
           Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
           //--------RETENCIÓN EXTERNA
           if (CLASES._Cls_Varios_Metodos._Mtd_RetencionExterna())
           {
               _Str_Sql = "INSERT INTO TCOMPROBANRETD (ccompany,cidcomprobret,ciddetalleret,cproveedor,ctdocument,cnumdocu,cfechadocu,cnumcontrolfact,ctipotransacc,ctotcaomp_iva,cbaseimponible,calicuotaporc,cimpuesto,cretenido,cdateadd,cuseradd,ctotmontexcento) VALUES('" +
               _Str_CompanyRetenExterna + "'," + _Str_cidcomprobret + "," + _Str_cidcomprobretId + ",'" + _Pr_Str_ProvId + "','" + _Pr_Str_TpoDoc + "','" + _Pr_Str_NDoc + "','" + _Str_cfechadocu + "','" + _Str_DocCtrl + "','" + _Str_ctipotransacc + "'," + _Dbl_totDoc.ToString().Replace(",", ".") + "," + _Dbl_cmontosi.ToString().Replace(",", ".") + ",'" + _Str_calicuotaporc + "'," + _Dbl_cmontoimp.ToString().Replace(",", ".") + "," + _Dbl_Retiene.ToString().Replace(",", ".") + ",'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','" + _Dbl_MontoExcento.ToString().Replace(",", ".") + "')";
               Program._MyClsCnn._Mtd_ConexionExterna._Mtd_EjecutarSentencia(_Str_Sql);
           }
           //--------
           _Str_Sql = "UPDATE TCOMPROBANC SET cidcomprobret='" + _Str_cidcomprobret + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_cidcomprob + "'";
           Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
           //------------------------------------------------------------------
           //CUENTA POR PAGAR DEL PROVEEDOR QUE ES AGENTE DEL IVA
           string _Str_ID_Factura_CxP_RETEN = _Mtd_Correlativo("SELECT MAX(cidfactxp) FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'");
           _Str_Cadena = "INSERT INTO TFACTPPAGARM (cgroupcomp,ccompany,cidfactxp,cproveedor,ctipodocument,cnumdocu,cidnotrecepc,cglobal,ccatproveedor,cfechaemision,cfechavencimiento,ctotalimp,ctotalsimp,canulado,cactivo,cmontoinvendible,cfechanotrecep,csaldo,cnumdocuctrl,ctotmontexcento,ctotal,ctotalislr,cidcomprob,cdateadd,cuseradd) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ID_Factura_CxP_RETEN + "','" + _Str_ProvRetIVA + "','" + _Str_TipoDocRetIVA + "','" + _Str_cidcomprobret + "','0','" + _Str_ProvRetIVA_Tipo + "','" + _Str_ProvRetIVA_Categoria + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Mtd_ObtenerFechaLimite(_Str_FechaVenc) + "','0','0','0','1','0',null,'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retiene) + "','0','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoExcento) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retiene) + "','0','" + _Str_cidcomprob + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
           Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
           _Str_Cadena = "INSERT INTO TMOVCXPM (cgroupcomp,ccompany,cproveedor,ctipodocument,cnumdocu,cfechaemision,cfechavencimiento,ctotalimp,ctotalsimp,canulado,cactivo,csaldo,ctotalislr,cidcomprob,ctotal,cdateadd,cuseradd) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ProvRetIVA + "','" + _Str_TipoDocRetIVA + "','" + _Str_cidcomprobret + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Mtd_ObtenerFechaLimite(_Str_FechaVenc) + "','0','0','0','1','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Dbl_Retiene)) + "','0','" + _Str_cidcomprob + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retiene) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
           Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
           //---------------------------
           //CUENTA POR PAGAR DEL PROVEEDOR QUE SE LE DESCUENTA
           string _Str_ID_Factura_CxP_RETEN_Prov = _Mtd_Correlativo("SELECT MAX(cidfactxp) FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'");
           _Str_Cadena = "INSERT INTO TFACTPPAGARM (cgroupcomp,ccompany,cidfactxp,cproveedor,ctipodocument,cnumdocu,cidnotrecepc,cglobal,ccatproveedor,cfechaemision,cfechavencimiento,ctotalimp,ctotalsimp,canulado,cactivo,cmontoinvendible,cfechanotrecep,csaldo,cnumdocuctrl,ctotmontexcento,ctotal,ctotalislr,cidcomprob,cdateadd,cuseradd) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ID_Factura_CxP_RETEN_Prov + "','" + _Pr_Str_ProvId + "','" + _Str_TipoDocRetIVA + "','" + _Str_cidcomprobret + "','0','" + _Str_Prov_Tipo + "','" + _Str_Prov_Categoria + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Mtd_ObtenerFechaLimite(_Str_FechaVenc) + "','0','0','0','1','0',null,'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retiene * -1) + "','0','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoExcento) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retiene * -1) + "','0','" + _Str_cidcomprob + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
           Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
           _Str_Cadena = "INSERT INTO TMOVCXPM (cgroupcomp,ccompany,cproveedor,ctipodocument,cnumdocu,cfechaemision,cfechavencimiento,ctotalimp,ctotalsimp,canulado,cactivo,csaldo,ctotalislr,cidcomprob,ctotal,cdateadd,cuseradd) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Pr_Str_ProvId + "','" + _Str_TipoDocRetIVA + "','" + _Str_cidcomprobret + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Mtd_ObtenerFechaLimite(_Str_FechaVenc) + "','0','0','0','1','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retiene * -1) + "','0','" + _Str_cidcomprob + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Retiene * -1) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
           Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
           //-----------------------------------------------------------------
           //ACTUALIZO EL COMPROBANTE DE RETENCION EN LA CUENTA POR PAGAR
           _Str_Sql = "UPDATE TFACTPPAGARM set cidcomprobret='" + _Str_cidcomprobret + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _Pr_Str_ProvId + "' and ctipodocument='" + _Pr_Str_TpoDoc + "' and cnumdocu='" + _Pr_Str_NDoc + "'";
           //if (_Mtd_GetGlobalProveedorporId(_Pr_Str_ProvId) == "1")
           //{ _Str_Sql = _Str_Sql + " and cidnotrecepc='" + _Pr_Str_NRecepcion + "'"; }
           Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
           //OBTENGO EL ID DE CXP
           _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cidfactxp FROM TFACTPPAGARM WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _Pr_Str_ProvId + "' and ctipodocument='" + _Pr_Str_TpoDoc + "' and cnumdocu='" + _Pr_Str_NDoc + "'");
           if (_Ds.Tables[0].Rows.Count > 0)
           { _Str_CXPId = Convert.ToString(_Ds.Tables[0].Rows[0][0]); }
           //GUARDO EL IMPUESTO EN EL DETALLE DE DE IMP DE CXP
           _Str_FactPDetId = _Mtd_Correlativo("SELECT MAX(ciddetafactxp) FROM TFACTPPAGARIMPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cidfactxp=" + _Str_CXPId);
           _Str_Sql = "insert into TFACTPPAGARIMPD (cgroupcomp,ccompany,cidfactxp,ciddetafactxp,cimpuesto,cmontosimp,cmontoimp,cmontototal,cmontoexcento) VALUES('" +
           Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "'," + _Str_CXPId + "," + _Str_FactPDetId + "," + _Str_calicuotaporc.Replace(",", ".") + "," + _Dbl_cmontosi.ToString().Replace(",", ".") + "," + _Dbl_cmontoimp.ToString().Replace(",", ".") + ",'" + _Dbl_totDoc.ToString().Replace(",", ".") + "','" + _Dbl_MontoExcento.ToString().Replace(",", ".") + "')";
           Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
       }
       public static bool _Mtd_VerificarConexionExterna()
       {
           try
           {
               string _Str_Cadena = "SELECT cbloqexcretenc FROM TCONFIGCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(cbloqexcretenc,0)='0'";
               if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)//Aqui verifico si no es necesario la conexión externa
               { return true; }
               else
               {
                   _Str_Cadena = "SELECT ccompany FROM TCOMPANY WHERE ccompany='" + _Mtd_CompanyRetenExterna() + "'";//Aqui consulto la tabla TCOMPANY de la compañía externa para ver si hay conexión
                   return Program._MyClsCnn._Mtd_ConexionExterna._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
               }
           }
           catch { }
           return false;
       }
       public static bool _Mtd_VerificarConexionExternaVerif()
       {
           try
           {
               string _Str_Cadena = "SELECT ccompany FROM TCOMPANY WHERE ccompany='" + _Mtd_CompanyRetenExterna() + "'";//Aqui consulto la tabla TCOMPANY de la compañía externa para ver si hay conexión
               return Program._MyClsCnn._Mtd_ConexionExternaVerif._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
           }
           catch { }
           return false;
       }
       public static bool _Mtd_RetencionExterna()
       {
           string _Str_Cadena = "SELECT cbloqexcretenc FROM TCONFIGCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(cbloqexcretenc,0)='1'";
           return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
       }
       public string _Mtd_CorrelativoExterno(string _Pr_Str_Sql)
       {
           string _Str_R = "0";
           DataSet _Ds = Program._MyClsCnn._Mtd_ConexionExterna._Mtd_RetornarDataset(_Pr_Str_Sql);
           if (_Ds.Tables[0].Rows.Count > 0)
           {
               if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
               {
                   _Str_R = Convert.ToString(Convert.ToInt32(_Ds.Tables[0].Rows[0][0]) + 1);
               }
               else
               { _Str_R = "1"; }
           }
           return _Str_R;
       }
       public static string _Mtd_CompanyRetenExterna()
       {
           string _Str_Cadena = "SELECT ccompretenciones FROM TCONFIGCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
           DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
           if (_Ds.Tables[0].Rows.Count > 0)
           {
               return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
           }
           return "";
       }
       public string _Mtd_ObtenerIP()
       {
           // version antigua
           //return Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString().Trim();

           string _Str_Host = System.Net.Dns.GetHostName();
           string _Str_IP = "";

           for (int i = 0; i <= System.Net.Dns.GetHostEntry(_Str_Host).AddressList.Length - 1; i++)
           {
               _Str_IP = System.Net.Dns.GetHostEntry(_Str_Host).AddressList[i].ToString();

               // primero evalua si existe un IP estandar de la red SODICA
               if (_Str_IP.IndexOf("192.168.0.") != -1) return _Str_IP; // denca
               if (_Str_IP.IndexOf("192.168.1.") != -1) return _Str_IP; // conssa
               if (_Str_IP.IndexOf("192.168.2.") != -1) return _Str_IP; // mcy
               if (_Str_IP.IndexOf("192.168.3.") != -1) return _Str_IP; // mcbo
               if (_Str_IP.IndexOf("192.168.4.") != -1) return _Str_IP; // scb
               if (_Str_IP.IndexOf("192.168.5.") != -1) return _Str_IP; // pzo
               if (_Str_IP.IndexOf("192.168.6.") != -1) return _Str_IP; // bna
               if (_Str_IP.IndexOf("192.168.7.") != -1) return _Str_IP; // val
               if (_Str_IP.IndexOf("192.168.8.") != -1) return _Str_IP; // bqto
               if (_Str_IP.IndexOf("192.168.9.") != -1) return _Str_IP; // ccs
               if (_Str_IP.IndexOf("192.168.10.") != -1) return _Str_IP; // bnas

               if (_Str_IP.IndexOf("192.168.11.") != -1) return _Str_IP; // ¿futuro?
               if (_Str_IP.IndexOf("192.168.12.") != -1) return _Str_IP; // ¿futuro?
               if (_Str_IP.IndexOf("192.168.13.") != -1) return _Str_IP; // ¿futuro?
               if (_Str_IP.IndexOf("192.168.14.") != -1) return _Str_IP; // ¿futuro?
               if (_Str_IP.IndexOf("192.168.15.") != -1) return _Str_IP; // ¿futuro?
           }

           // si no encuentra un IP estándar, entonces devuelve el primero que no sea IPV6
           for (int i = 0; i <= System.Net.Dns.GetHostEntry(_Str_Host).AddressList.Length - 1; i++)
           {
               if (System.Net.Dns.GetHostEntry(_Str_Host).AddressList[i].IsIPv6LinkLocal == false)
               {
                   _Str_IP = System.Net.Dns.GetHostEntry(_Str_Host).AddressList[i].ToString();
               }
           }

           return _Str_IP;
       }

       public static string _Mtd_NombreReportesExportacion(string _Str_CadenaBase)
       {
           DateTime _DT_FechaHoraServidor = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();

           string _Str_Ano = _DT_FechaHoraServidor.Year.ToString();
           string _Str_Mes = _DT_FechaHoraServidor.Month.ToString("00");
           string _Str_Dia = _DT_FechaHoraServidor.Day.ToString("00");
           string _Str_Horas = _DT_FechaHoraServidor.Hour.ToString("00");
           string _Str_Minutos = _DT_FechaHoraServidor.Minute.ToString("00");

           return _Str_CadenaBase + "_" + Frm_Padre._Str_Comp.Trim() + "_" + _Str_Ano + "-" + _Str_Mes + "-" + _Str_Dia + "_" + _Str_Horas + "_" + _Str_Minutos; ;
           //return _Str_CadenaBase + "_" + Frm_Padre._Str_Comp.Trim() + "_" + String.Format("{0:u}", _DT_FechaHoraServidor);
       }

        /// <summary>
        /// Retorna un valor que indica si un proveedor es de intercompañías.
        /// </summary>
        /// <param name="_P_Str_Proveedor">Código del provedor</param>
        /// <returns>Verdadero o falso.</returns>
        public static bool _Mtd_EsProveedorIC(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "select cproveedor from TICRELAPROCLI where cproveedor='" + _P_Str_Proveedor +
                                 "' and isnull(cdelete,0)=0";
            return Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Cadena);
        }

        /// <summary>
        /// Retorna un valor que indica si un cliente es de intercompañías.
        /// </summary>
        /// <param name="_P_Str_Cliente">Código del cliente</param>
        /// <returns>Verdadero o falso.</returns>
        public static bool _Mtd_EsClienteIC(string _P_Str_Cliente)
        {
            string _Str_Cadena = "select ccliente from TICRELAPROCLI where ccliente='" + _P_Str_Cliente +
                                 "' and isnull(cdelete,0)=0";
            return Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Cadena);
        }
        public static string RemoverCaracteresEspeciales(string pCadena)
        {
            string[] replacement =
                {
                    "a", "a", "a", "a", "a", "a", "c", "e", "e", "e", "e", "i", "i", "i", "i", "n", "o",
                    "o", "o", "o", "o", "u", "u", "u", "u", "y", "y"
                };
            string[] accents =
                {
                    "à", "á", "â", "ã", "ä", "å", "ç", "é", "è", "ê", "ë", "ì", "í", "î", "ï", "ñ", "ò", 
                    "ó", "ô", "ö", "õ", "ù", "ú", "û", "ü", "ý", "ÿ"
                };
            for (var i = 0; i < accents.Length; i++)
            {
                pCadena = pCadena.ToLower().Replace(accents[i], replacement[i]);
            }
            return pCadena.ToUpper();
        }

        /// <summary>Retorna verdadero si el precio proporcionado correspondo con los ultimos pmvps vigentes o con el ppm vigenete segun el caso.</summary>
        /// <param name="_P_Str_cproducto">Código del producto.</param>
        /// <param name="_P_Dec_Precio">Pmv a verificar.</param>
        /// <param name="_P_Bool_ExistePmv">Devuelve si existen registros del pmv.</param>
        /// <returns>Corresponde  el PMV.</returns>
        public Boolean _Mtd_VerificarPMV(string _P_Str_cproducto, decimal _P_Dec_Precio, out Boolean _P_Bool_ExistePmv)
        {
            var _Str_SQL = "";
            int _Int_cregpmv = 0;
            int _Int_cpreciomanejado = 0;

            //Consulto el Producto para ver que tipo de precio maneja
            _Str_SQL = "SELECT cregpmv from TPRODUCTO WHERE cproducto = '" + _P_Str_cproducto + "'";
            var _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                //Regpmv
                _Int_cregpmv = Convert.ToInt32(_Ds_A.Tables[0].Rows[0]["cregpmv"]);

                //En funcion al pmv manejado
                switch (_Int_cregpmv)
                {
                    case 1: //PMV
                        _Int_cpreciomanejado = 3;
                        break;
                    case 2: // PPM
                        _Int_cpreciomanejado = 4;
                        break;
                }

                //Solo si maneja PMV
                if (_Int_cregpmv > 0)
                {
                    //Cargamos la cantidad maxima de pvjustos permitidos
                    var _Int_CantidadMaximaPVJustosPermitidos = _Mtd_ObtenerCantidadMaximaDePVJustosPermitidos();

                    //Cargo todos los PMVs
                    _Str_SQL = "SELECT * FROM THISTORICOPMV  WHERE cproducto = '" + _P_Str_cproducto + "' AND cpreciomanejado = " + _Int_cpreciomanejado + " ORDER BY cfechainicio DESC";
                    var _Ds_Precios = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                    if (_Ds_Precios.Tables[0].Rows.Count > 0)
                    {
                        var oPrecios = new List<decimal>();
                        var oIdPrecioVigente = 0;

                        //Recorro los precios para identificar el registro vigente
                        foreach (DataRow _DRow in _Ds_Precios.Tables[0].Rows)
                        {
                            var dtFechaInicio = Convert.ToDateTime(_DRow["cfechainicio"]).Date;
                            var dtFechaFinal = _DRow["cfechafinal"].ToString() == ""
                                                   ? DateTime.Now.Date
                                                   : Convert.ToDateTime(_DRow["cfechafinal"]).Date;
                            var dtFechaActual = DateTime.Now.Date;
                            var idVigente = Convert.ToInt32(_DRow["cidhistorico"]);

                            //Verifico si el el registro es el vigente
                            if (dtFechaActual >= dtFechaInicio && dtFechaActual <= dtFechaFinal)
                                oIdPrecioVigente = idVigente;
                        }

                        //Si hay registro vigente, obtengo el mismo y el siguiente inmediato
                        if (oIdPrecioVigente > 0)
                        {
                            //Recorro los precios para obtenerlows
                            foreach (DataRow _DRow in _Ds_Precios.Tables[0].Rows)
                            {
                                var cIdhistorico = Convert.ToInt32(_DRow["cidhistorico"]);
                                var dcPrecio = _Int_cpreciomanejado == 3 ? Convert.ToDecimal(_DRow["cpmvp"]) : Convert.ToDecimal(_DRow["cppm"]);
                                //Si es el vigente tomo el precio
                                if (cIdhistorico == oIdPrecioVigente)
                                    oPrecios.Add(dcPrecio);
                                //Verifico si existe y es distinto del vigente lo tomo
                                if ((oPrecios.Count >= 1) && (cIdhistorico != oIdPrecioVigente) && (oPrecios.Count < _Int_CantidadMaximaPVJustosPermitidos))
                                    oPrecios.Add(dcPrecio);
                            }
                        }
                        //Verifico si el precio proporcionado es alguno de los obtenidos
                        if (oPrecios.Contains(_P_Dec_Precio))
                        {
                            _P_Bool_ExistePmv = true;
                            return true;
                        }
                        _P_Bool_ExistePmv = true;
                        return false;
                    }
                    _P_Bool_ExistePmv = false;
                    return false;
                }
            }
            //Si no hay producto
            _P_Bool_ExistePmv = false;
            return false;
        }


        /// <summary>Retorna el costo bruto del producto y pvjusto indicado.</summary>
        /// <param name="_P_Str_cproducto">Código del producto.</param>
        /// <param name="_P_Dec_Precio">Pvjusto a verificar.</param>
        /// <returns>Corresponde al Costo Bruto.</returns>
        public decimal _Mtd_ObtenerCostoBrutoSegunProductoPvJusto(string _P_Str_cproducto, decimal _P_Dec_Precio)
        {
            var _Str_SQL = "";
            int _Int_cregpmv = 0;
            int _Int_cpreciomanejado = 0;
            decimal _Dcm_CostoBrutoResultado = 0;

            //Consulto el Producto para ver que tipo de precio maneja
            _Str_SQL = "SELECT cregpmv from TPRODUCTO WHERE cproducto = '" + _P_Str_cproducto + "'";
            var _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                //Regpmv
                _Int_cregpmv = Convert.ToInt32(_Ds_A.Tables[0].Rows[0]["cregpmv"]);

                //En funcion al pmv manejado
                switch (_Int_cregpmv)
                {
                    case 1: //PMV
                        _Int_cpreciomanejado = 3;
                        break;
                    case 2: // PPM
                        _Int_cpreciomanejado = 4;
                        break;
                }

                //Solo si maneja PMV
                if (_Int_cregpmv > 0)
                {
                    //Cargo los registros
                    _Str_SQL = "SELECT isnull(ccostobruto_u1,-1) AS ccostobruto_u1 FROM THISTORICOPMV  WHERE cproducto = '" + _P_Str_cproducto + "' AND cpreciomanejado = " + _Int_cpreciomanejado + " AND " + (_Int_cpreciomanejado == 3 ? "cpmvp" : "cppm") + " = " + _P_Dec_Precio.ToString().Replace(',', '.') + " ORDER BY cfechainicio DESC";
                    var _Ds_Precios = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                    if (_Ds_Precios.Tables[0].Rows.Count > 0)
                    {
                        //Tomamos el primero    
                        var _Dcm_CostoBruto = Convert.ToDecimal(_Ds_Precios.Tables[0].Rows[0]["ccostobruto_u1"]);

                        //Si viene -1 es que no existe el precio
                        if (_Dcm_CostoBruto == -1)
                        {
                            //Lo tomamos de la maestra del producto
                            _Str_SQL = "select isnull(ccostobruto_u1,-1) AS ccostobruto_u1 from VST_PRODUCTOS where cproducto = '" + _P_Str_cproducto + "' ";
                            var _Ds_Maestra = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                            if (_Ds_Maestra.Tables[0].Rows.Count > 0)
                            {
                                _Dcm_CostoBrutoResultado = Convert.ToDecimal(_Ds_Maestra.Tables[0].Rows[0]["ccostobruto_u1"]);
                            }
                        }
                        else //Lo tomamos del historico
                        {
                            _Dcm_CostoBrutoResultado = _Dcm_CostoBruto;
                        }

                    }
                }
                else //Sino esta regulado lo obtenermos de la maestra
                {
                    //Lo tomamos de la maestra del producto
                    _Str_SQL = "select isnull(ccostobruto_u1,-1) AS ccostobruto_u1 from VST_PRODUCTOS where cproducto = '" + _P_Str_cproducto + "' ";
                    var _Ds_Maestra = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                    if (_Ds_Maestra.Tables[0].Rows.Count > 0)
                    {
                        _Dcm_CostoBrutoResultado = Convert.ToDecimal(_Ds_Maestra.Tables[0].Rows[0]["ccostobruto_u1"]);
                    }
                }
            }
            //devolvemos
            return _Dcm_CostoBrutoResultado;
        }

        /// <summary>
        /// Indica si el producto es con regulacion flexible
        /// </summary>
        /// <param name="_P_Str_cproducto"></param>
        /// <returns></returns>
        public Boolean _Mtd_ProductoEsConRegulacionFlexible(string _P_Str_cproducto)
        {
            var _Str_Sql = "Select cproducto from TPRODUCTOCONREGULACIONFLEXIBLE where cproducto='" + _P_Str_cproducto + "' and cdelete = 0";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        public double _Mtd_MontoPorcentajeDescuentoFinanciero(string _P_Str_cgroupcomp, string _P_Str_cproveedor,
                                                              string _P_Str_cnfacturapro)
        {
            if (_P_Str_cnfacturapro != "")
            {
                double dblResultado = 0;
                var _Str_Sql = "Select cdescfinanporc from TRECEPCIONDFM where cgroupcomp='" + _P_Str_cgroupcomp +
                                  "' and cproveedor = '" + _P_Str_cproveedor + "' and cnfacturapro='" +
                                  _P_Str_cnfacturapro +
                                  "'";
                var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                    if (_Ds.Tables[0].Rows[0]["cdescfinanporc"].ToString() != "")
                        dblResultado = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cdescfinanporc"]);
                return dblResultado;
            }
            return 0;
        }
        public static string _Mtd_ObtenerDatosFacturaCxP(string _P_Str_cnumdocu, string _P_Str_cproveedor, string _P_Str_cgroupcomp, string _P_Str_ccompany, bool _P_Bool_EsRecepcion = false, String _P_Str_cidnotrecepc = "")
        {
            //Inicializamos
            var _Str_Resultado = "";
            //Consultamos
            string _Str_Sql = "SELECT ctipdocfact FROM TCONFIGCXP WHERE ccompany='" + _P_Str_ccompany + "'";
            string _Str_TpoDocFact = "";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TpoDocFact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]).Trim();
            }
            if (!_P_Bool_EsRecepcion)
               _Str_Sql = "SELECT cnumdocu AS Factura, cfechaemision as Fecha, ctotal as Monto,calicuota FROM TFACTPPAGARM WHERE cgroupcomp='" + _P_Str_cgroupcomp + "' AND cproveedor='" + _P_Str_cproveedor + "' AND ccompany='" + _P_Str_ccompany + "' AND ctipodocument='" + _Str_TpoDocFact + "' AND cactivo=1 AND canulado=0 AND cnumdocu='" + _P_Str_cnumdocu + "' ORDER BY cnumdocu ASC";
            else
                _Str_Sql = "SELECT cnfacturapro AS Factura, cdatefactura as Fecha, ctotfactura as Monto,calicuota  FROM TRECEPCIONDFM WHERE cgroupcomp='" + _P_Str_cgroupcomp + "' AND cproveedor='" + _P_Str_cproveedor + "' AND cnfacturapro='" + _P_Str_cnumdocu + "' AND cidrecepcion='" + _P_Str_cidnotrecepc + "' ORDER BY cnfacturapro ASC";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                //Obtenemos los datos de la factura
                var _Dt_fecha = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["Fecha"].ToString());
                var _Dec_monto = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["Monto"].ToString());
                //GenEramos la cadena
                _Str_Resultado = " FACTURA# " + _P_Str_cnumdocu + " FEC: " + _Dt_fecha.ToShortDateString() + " MONTO: " + _Dec_monto.ToString("#,###0.00");
            }
            return _Str_Resultado;
        }

        public static string _Mtd_ObtenerDatosFacturaCxC(string _P_Str_cfactura, string _P_Str_cgroupcomp, string _P_Str_ccompany)
        {
            //Inicializamos
            var _Str_Resultado = "";
            //Consultamos
            string _Str_Sql = "SELECT ctipdocfact FROM TCONFIGCXC WHERE ccompany='" + _P_Str_ccompany + "'";
            string _Str_TpoDocFact = "";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TpoDocFact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]).Trim();
            }
            _Str_Sql = "SELECT cfactura AS Factura, c_fecha_factura as Fecha, c_montotot_si_bs as MontoSinImpuesto, c_impuesto_bs as MontoImpuesto, (c_montotot_si_bs + c_impuesto_bs) AS Monto ,calicuota FROM TFACTURAM WHERE cgroupcomp='" + _P_Str_cgroupcomp + "' AND ccompany='" + _P_Str_ccompany + "' AND c_impresa=1 AND c_fact_anul=0 AND cfactura='" + _P_Str_cfactura + "' ORDER BY cfactura ASC";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                //Obtenemos los datos de la factura
                var _Dt_fecha = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["Fecha"].ToString());
                var _Dec_monto = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["Monto"].ToString());
                //GenEramos la cadena
                _Str_Resultado = " FACTURA# " + _P_Str_cfactura + " FEC: " + _Dt_fecha.ToShortDateString() + " MONTO: " + _Dec_monto.ToString("#,###0.00");
            }
            return _Str_Resultado;
        }

        public static string _Mtd_ObtenerDatosChequeDevueltoCxC(string _P_Str_cnumdocu, string _P_Str_cgroupcomp, string _P_Str_ccompany, string _P_Str_Cliente)
        {
            //Inicializamos
            var _Str_Resultado = "";
            //Consultamos
            string _Str_Sql = "SELECT ctipdocfact FROM TCONFIGCXC WHERE ccompany='" + _P_Str_ccompany + "'";
            string _Str_TpoDocFact = "";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TpoDocFact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]).Trim();
            }
            //_Str_Sql = "SELECT cfactura AS Factura, c_fecha_factura as Fecha, c_montotot_si_bs as MontoSinImpuesto, c_impuesto_bs as MontoImpuesto, (c_montotot_si_bs + c_impuesto_bs) AS Monto ,calicuota FROM TFACTURAM WHERE cgroupcomp='" + _P_Str_cgroupcomp + "' AND ccompany='" + _P_Str_ccompany + "' AND c_impresa=1 AND c_fact_anul=0 AND cfactura='" + _P_Str_cfactura + "' ORDER BY cfactura ASC";
            _Str_Sql = "SELECT cnumcheque AS NumeroDocumento, cfechaemision as Fecha, cmontocheq AS Monto FROM TCHEQDEVUELT WHERE CCLIENTE='" + _P_Str_Cliente + "' AND CNUMCHEQUE='" + _P_Str_cnumdocu + "' AND CCOMPANY='" + _P_Str_ccompany + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                //Obtenemos los datos de la factura
                var _Dt_fecha = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["Fecha"].ToString());
                var _Dec_monto = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["Monto"].ToString());
                //GenEramos la cadena
                _Str_Resultado = " CHQDEV# " + _P_Str_cnumdocu + " FEC: " + _Dt_fecha.ToShortDateString() + " MONTO: " + _Dec_monto.ToString("#,###0.00");
            }
            return _Str_Resultado;
        }

        public static string _Mtd_ObtenerDatosNotaDebitoCxC(string _P_Str_cnumdocu, string _P_Str_cgroupcomp, string _P_Str_ccompany, string _P_Str_Cliente)
        {
            //Inicializamos
            var _Str_Resultado = "";
            //Consultamos
            string _Str_Sql = "SELECT ctipdocfact FROM TCONFIGCXC WHERE ccompany='" + _P_Str_ccompany + "'";
            string _Str_TpoDocFact = "";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TpoDocFact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]).Trim();
            }
            _Str_Sql = "SELECT cidnotadebitocc AS NumeroDocumento, cfecha AS Fecha, ctotaldocu AS Monto FROM TNOTADEBICC WHERE CCLIENTE='" + _P_Str_Cliente + "' AND CIDNOTADEBITOCC='" + _P_Str_cnumdocu + "' AND CCOMPANY='" + _P_Str_ccompany + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                //Obtenemos los datos de la factura
                var _Dt_fecha = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["Fecha"].ToString());
                var _Dec_monto = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["Monto"].ToString());
                //GenEramos la cadena
                _Str_Resultado = " N/D# " + _P_Str_cnumdocu + " FEC: " + _Dt_fecha.ToShortDateString() + " MONTO: " + _Dec_monto.ToString("#,###0.00");
            }
            return _Str_Resultado;
        }

        public static bool _Mtd_EstaActivoReintegros()
        {
            var _Bool_Retornar = false;

            try
            {
                string _Str_Sql = "SELECT cactivarreintegros FROM TCONFIGCONSSA WHERE cactivarreintegros = 1";
                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Bool_Retornar = true;
                }
            }
            catch
            {
                _Bool_Retornar = false;
            }
            return _Bool_Retornar;
        }
        public static bool _Mtd_EstaActivoRetencionesPatente()
        {
            var _Bool_Retornar = false;

            try
            {
                string _Str_Sql = "SELECT cretienepatente FROM TCOMPANY WHERE CCOMPANY = '" + Frm_Padre._Str_Comp + "' and cretienepatente='1'";
                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Bool_Retornar = true;
                }
            }
            catch
            {
                _Bool_Retornar = false;
            }
            return _Bool_Retornar;
        }
        public static int _Mtd_ObtenerCantidadMaximaDePVJustosPermitidos()
        {
            var _int_Cantidad = 2;
            try
            {
                var _Str_Sql = "SELECT isnull(cpvjustomaxcant,0) as cpvjustomaxcant FROM TCONFIGCONSSA ";
                var _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _int_Cantidad = Convert.ToInt32(_Ds_DataSet.Tables[0].Rows[0][0]);
                }
            }
            catch
            {
            }
            return _int_Cantidad;
        }

        public static decimal _Mtd_ObtenerPermitidoMontoUT()
        {
            Program._Dat_Tablas =
              new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            //---------------------
            int _Int_UnidadesTributarias = (int)(from Campos in Program._Dat_Tablas.TCONFIGCXP
                                                 where Campos.ccompany == Frm_Padre._Str_Comp
                                                 select new { Campos.cfactormaxfacrepos }).Single().cfactormaxfacrepos;
            //---------------------
            decimal _Dcm_UT = (decimal)(from Campos in Program._Dat_Tablas.TUNITRIBUT
                                        where Campos.cunitrib == "UT"
                                        select new { Campos.cvalor }).Single().cvalor;
            //---------------------
            decimal _Dcm_Monto = _Int_UnidadesTributarias * _Dcm_UT;
            //---------------------
            return _Dcm_Monto;
        }







        //nuevo agregar nomina
        public static DataSet dataset = new DataSet();
        public static DataSet dataset2 = new DataSet();

        //public static List<Nomina_T_Csv> Nomina_R = new List<Nomina_T_Csv>();
        //public class Nomina_T_Csv
        //{
        //    public string COMPANIA { set; get; }
        //    public string FICHATRABAJADOR { set; get; }
        //    public string CUENTACONTABLE { set; get; }
        //    public string DESCRIPCIONPROCESO { set; get; }
        //    public string FECHACONTABILIZACION { set; get; }
        //    public int ANOCONTABILIZACION { set; get; }
        //    public int MESCONTABLE { set; get; }
        //    public string MONTODEBE { set; get; }
        //    public string MONTOHABER { set; get; }
        //}
             
        //public void Nomina_List(string fileName)
        //{
        //    Nomina_R.Clear();
        //    StreamReader sr = new StreamReader(fileName);
        //    string delimiter = ",";
        //    dataset.Tables.Add();
        //    string allData = sr.ReadToEnd();
        //    string[] rows = allData.Split("\r".ToCharArray());
        //    rows.Take(1).Single().Split(delimiter.ToCharArray()).ToList().ForEach(x => dataset.Tables[0].Columns.Add());
        //    rows.ToList().ForEach(r =>
        //    {
        //        var a = r.Split(delimiter.ToCharArray()).Select(x => x.Replace('"', ' ').Trim()).ToList();
        //        if (a.Count() > 1)
        //        {
        //            Nomina_R.Add(new Nomina_T_Csv
        //            {
        //                COMPANIA = a[0],
        //                FICHATRABAJADOR = a[1],
        //                CUENTACONTABLE = a[2],
        //                DESCRIPCIONPROCESO = a[3],
        //                FECHACONTABILIZACION = a[4],
        //                ANOCONTABILIZACION = Convert.ToInt32(a[5]),
        //                MESCONTABLE = Convert.ToInt32(a[6]),
        //                MONTODEBE = a[7],
        //                MONTOHABER = a[8]
        //            });
        //        }
        //    });

        //    string _Str_Cadena = "";
        //    Nomina_R.ForEach(x => _Str_Cadena += "INSERT INTO TNOMINACONTABILIDAD VALUES (GETDATE(), '" +
        //          x.COMPANIA + "', '" +
        //          x.FICHATRABAJADOR + "', '" +
        //          x.CUENTACONTABLE + "', '" +
        //          x.DESCRIPCIONPROCESO + "', CONVERT(datetime, '" +
        //          x.FECHACONTABILIZACION + "',103), " +
        //          x.ANOCONTABILIZACION + ", " +
        //          x.MESCONTABLE + ", " +
        //          x.MONTODEBE + ", " +
        //          x.MONTOHABER + ",0) ");
        //        //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        //}

        public void Nomina_CSV()
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Seleccione el archivo generado por infocent";
            fDialog.Filter = "Archivos Txt|*.txt";
            fDialog.InitialDirectory = @"C:\Users\" + Environment.UserName.ToString() + @"\Downloads";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = System.IO.Path.GetFileName(fDialog.FileName);
                string path = Path.GetDirectoryName(fDialog.FileName);
                grid(path + "\\" + fileName);
            }
        }
        
        public void grid(string fileName)
        {
            dataset2.Clear();
            dataset2.Tables.Clear();
            string delimiter = ",";
            StreamReader sr = new StreamReader(fileName);

            dataset2.Tables.Add();
            dataset2.Tables[0].Columns.Add("COMPANIA");//0
            dataset2.Tables[0].Columns.Add("FICHATRABAJADOR");//1
            dataset2.Tables[0].Columns.Add("CUENTACONTABLE");//2
            dataset2.Tables[0].Columns.Add("DESCRIPCIONPROCESO");//3
            dataset2.Tables[0].Columns.Add("FECHACONTABILIZACION");//4
            dataset2.Tables[0].Columns.Add("ANOCONTABILIZACION");//5
            dataset2.Tables[0].Columns.Add("MESCONTABLE");//6
            dataset2.Tables[0].Columns.Add("MONTODEBE");//7
            dataset2.Tables[0].Columns.Add("MONTOHABER");//8

            string allData = sr.ReadToEnd();
            string[] rows = allData.Split("\r".ToCharArray());

            rows.ToList().ForEach(r => dataset2.Tables[0].Rows.Add(r.Split(delimiter.ToCharArray()).Select(x => x.Replace('"', ' ').Trim()).ToArray()));
        }

        public string cficha(string cficha)
        {
            if (cficha.Length > 1){
                return (" - "+cficha);
            }else{return null;}
        }

        //nuevo agregar nomina

    }
}
