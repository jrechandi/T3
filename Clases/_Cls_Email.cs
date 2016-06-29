using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data.SqlClient;
using System.Net;
namespace T3
{
    class _Cls_Email
    {
        public static bool _Mtd_Email(string _P_Str_Body_, string _P_Str_To_, System.Web.Mail.MailFormat _P_Str_Formato_, string _P_Str_subje_)
        {
            try
            {
                if (UrlIsValid("www.conssa.com"))
                {
                    System.Net.Mail.MailMessage _Mail_Email_ = new System.Net.Mail.MailMessage("soporte@t3.com.ve", _P_Str_To_);
                    _Mail_Email_.Subject = _P_Str_subje_.TrimEnd();
                    _Mail_Email_.Body = _P_Str_Body_.TrimEnd();
                    //_Mail_Email_.Body
                    //System.Web.Mail.SmtpMail.SmtpServer="http://200.74.224.21";
                    //System.Web.Mail.SmtpMail.SmtpServer="200.74.224.21";
                    //System.Web.Mail.SmtpMail.SmtpServer="192.168.1.94";
                    //System.Web.Mail.SmtpMail.SmtpServer = "200.74.224.21";
                    _Mail_Email_.IsBodyHtml = true;
                    _Mail_Email_.Priority = System.Net.Mail.MailPriority.High;
                    System.Net.Mail.SmtpClient d = new System.Net.Mail.SmtpClient("mail.cantv.net");
                    d.Send(_Mail_Email_);
                    //_Mtd_Actualizar(_P_Str_Clave, _P_Str_Tabla, _P_Str_Conexion);
                    _Mail_Email_.Dispose();
                    return true;

                }
                else
                { return false; }
              //  d.SendCompleted += new System.Net.Mail.SendCompletedEventHandler(d_SendCompleted);
            }
            catch (Exception ou)
            {
                string error = ou.Message.ToString();
                return false;
            }
        }
        private static void _Mtd_Actualizar(string _P_Str_Clave, string _P_Str_Tabla, string _P_Str_Conexion)
        {
            SqlCommand _Sql_Comm_cmdInsert = null;
            SqlConnection _Sql_Con = new SqlConnection(_P_Str_Conexion);
            _Sql_Comm_cmdInsert = new SqlCommand("UPDATE " + _P_Str_Tabla + " Set cenviado='1' where cidemail='" + _P_Str_Clave + "'", _Sql_Con);
            _Sql_Comm_cmdInsert.Connection = _Sql_Con;
            _Sql_Con.Open();
            _Sql_Comm_cmdInsert.ExecuteNonQuery();
            _Sql_Con.Close();
        }
        public static bool UrlIsValid(string Host)
        {

            HttpWebRequest oRequest = null;

            HttpWebResponse oResponse = null;

            try
            {

                oRequest = (HttpWebRequest)WebRequest.Create(BuildUrl(Host));

                oResponse = (HttpWebResponse)oRequest.GetResponse();

                return true;

            }

            catch (Exception e)
            {

                try
                {

                    oRequest = (HttpWebRequest)WebRequest.Create(BuildUrl(Host) + "\\");

                    oResponse = (HttpWebResponse)oRequest.GetResponse();

                    return true;

                }

                catch (Exception e1)
                {

                    return false;

                }

            }

        }
        public static string BuildUrl(string Url)
        {

            if (Url.StartsWith("http://"))

                return Url;

            return Url.Insert(0, "http://");

        }



    }
}
