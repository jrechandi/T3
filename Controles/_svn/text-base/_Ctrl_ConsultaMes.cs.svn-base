using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace T3.Controles
{
    public partial class _Ctrl_ConsultaMes : UserControl
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public _Ctrl_ConsultaMes()
        {
            InitializeComponent();
            try
            {
                _Dtp_Desde.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
                _Dtp_Desde.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
                _Dtp_Hasta.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            }
            catch 
            {
            }
        }
        public string _Str_FechaInicio
        {
            get
            {
                if (_Rb_Mes.Checked)
                {
                    if (_Cmb_Year.SelectedIndex > 0 & _Cmb_Month.SelectedIndex > 0)
                    { return _Cls_Formato._Mtd_fecha(_Mtd_FechaIni(Convert.ToInt32(_Cmb_Year.SelectedValue), Convert.ToInt32(_Cmb_Month.SelectedValue))); }
                    else
                    { return ""; }
                }
                else
                {
                    return _Cls_Formato._Mtd_fecha(_Dtp_Desde.Value);
                }
            }
        }
        public string _Str_FechaFinal
        {
            get
            {
                if (_Rb_Mes.Checked)
                {
                    if (_Cmb_Year.SelectedIndex > 0 & _Cmb_Month.SelectedIndex > 0)
                    { return _Cls_Formato._Mtd_fecha(_Mtd_FechaFin(Convert.ToInt32(_Cmb_Year.SelectedValue), Convert.ToInt32(_Cmb_Month.SelectedValue))); }
                    else
                    { return ""; }
                }
                else
                {
                    return _Cls_Formato._Mtd_fecha(_Dtp_Hasta.Value);
                }
            }
        }
        /// <summary>
        /// Devuelve un valor que indica si el control retornará una fecha válida
        /// </summary>
        public bool _Bol_Listo
        {
            get
            {
                if (_Rb_Mes.Checked)
                {
                    if (_Cmb_Year.SelectedIndex > 0 & _Cmb_Month.SelectedIndex > 0)
                    { return true; }
                    else
                    { return false; }
                }
                else
                {
                    return true;
                }
            }
        }
        /// <summary>
        /// Configura los controles de acuerdo a la opción elegida.
        /// En el formulario en el cual se use el control se debe invocar este método
        /// una sola vez para inicializarlo. (En un constructor o en el evento Load)
        /// </summary>
        public void _Mtd_ConfigurarConsultaFecha()
        {
            if (_Rb_Mes.Checked)
            {
                //_Mtd_Year();
                _Lbl_Desde.Visible = false; _Dtp_Desde.Visible = false; _Lbl_Hasta.Visible = false; _Dtp_Hasta.Visible = false;
                _Lbl_Year.Visible = true; _Cmb_Year.Visible = true; _Lbl_Month.Visible = true; _Cmb_Month.Visible = true;
            }
            else
            {
                _Lbl_Year.Visible = false; _Cmb_Year.Visible = false; _Lbl_Month.Visible = false; _Cmb_Month.Visible = false;
                _Lbl_Desde.Visible = true; _Dtp_Desde.Visible = true; _Lbl_Hasta.Visible = true; _Dtp_Hasta.Visible = true;
            }
        }
        public void _Mtd_Year()
        {
            string _Str_Cadena = "SELECT DISTINCT cyearacco,cyearacco FROM TCALENDCONT WHERE cyearacco<=YEAR(GETDATE()) ORDER BY cyearacco DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            { _Str_Cadena = "SELECT YEAR(GETDATE()),YEAR(GETDATE())"; }
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Year, _Str_Cadena);
        }
        private void _Mtd_Month(int _P_Int_Year)
        {
            string _Str_Cadena = "SELECT DISTINCT cmontacco,CASE WHEN cmontacco=1 THEN 'ENERO' WHEN cmontacco=2 THEN 'FEBRERO' WHEN cmontacco=3 THEN 'MARZO' WHEN cmontacco=4 THEN 'ABRIL' WHEN cmontacco=5 THEN 'MAYO' WHEN cmontacco=6 THEN 'JUNIO' WHEN cmontacco=7 THEN 'JULIO' WHEN cmontacco=8 THEN 'AGOSTO' WHEN cmontacco=9 THEN 'SEPTIEMBRE' WHEN cmontacco=10 THEN 'OCTUBRE' WHEN cmontacco=11 THEN 'NOVIEMBRE' WHEN cmontacco=12 THEN 'DICIEMBRE' END FROM TCALENDCONT WHERE cyearacco='" + _P_Int_Year + "' AND ((cyearacco=YEAR(GETDATE()) AND cmontacco<=MONTH(GETDATE())) OR (cyearacco<>YEAR(GETDATE()))) ORDER BY cmontacco DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            { _Str_Cadena = "SELECT MONTH(GETDATE()),CASE WHEN MONTH(GETDATE())=1 THEN 'ENERO' WHEN MONTH(GETDATE())=2 THEN 'FEBRERO' WHEN MONTH(GETDATE())=3 THEN 'MARZO' WHEN MONTH(GETDATE())=4 THEN 'ABRIL' WHEN MONTH(GETDATE())=5 THEN 'MAYO' WHEN MONTH(GETDATE())=6 THEN 'JUNIO' WHEN MONTH(GETDATE())=7 THEN 'JULIO' WHEN MONTH(GETDATE())=8 THEN 'AGOSTO' WHEN MONTH(GETDATE())=9 THEN 'SEPTIEMBRE' WHEN MONTH(GETDATE())=10 THEN 'OCTUBRE' WHEN MONTH(GETDATE())=11 THEN 'NOVIEMBRE' WHEN MONTH(GETDATE())=12 THEN 'DICIEMBRE' END"; }
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Month, _Str_Cadena);
        }
        private DateTime _Mtd_FechaIni(int _P_Int_Year, int _P_Int_Month)
        {
            string _Str_Cadena = "SELECT TOP 1 CONVERT(VARCHAR,cdiafecha_reg,103) FROM TCALENDCONT WHERE cyearacco='" + _P_Int_Year + "' AND cmontacco='" + _P_Int_Month + "' AND cdelete='0' ORDER BY CONVERT(DATETIME,cdiafecha_reg) ASC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                { return Convert.ToDateTime(_Ds.Tables[0].Rows[0][0].ToString()); }
            }
            return new DateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Year, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Month, 1);
        }
        private DateTime _Mtd_FechaFin(int _P_Int_Year, int _P_Int_Month)
        {
            string _Str_Cadena = "SELECT TOP 1 CONVERT(VARCHAR,cdiafecha_reg,103) FROM TCALENDCONT WHERE cyearacco='" + _P_Int_Year + "' AND cmontacco='" + _P_Int_Month + "' AND cdelete='0' ORDER BY CONVERT(DATETIME,cdiafecha_reg) DESC";//AND cdiafecha_reg<=GETDATE() 
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                { return Convert.ToDateTime(_Ds.Tables[0].Rows[0][0].ToString()); }
            }
            DateTime _Dtm_Temp = new DateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Year, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().AddMonths(1).Month, 1);
            return _Dtm_Temp.AddDays(-1);
        }
        private void _Rb_Mes_CheckedChanged(object sender, EventArgs e)
        {
            _Mtd_ConfigurarConsultaFecha();
        }

        private void _Dtp_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dtp_Desde.MaxDate = _Dtp_Hasta.Value;
        }

        private void _Cmb_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Year.SelectedIndex > 0)
            { _Mtd_Month(Convert.ToInt32(_Cmb_Year.SelectedValue)); }
            else
            { _Cmb_Month.DataSource = null; }
        }

        private void _Cmb_Year_DropDown(object sender, EventArgs e)
        {
            _Mtd_Year();
        }

        private void _Cmb_Month_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_Year.SelectedIndex > 0)
            { _Mtd_Month(Convert.ToInt32(_Cmb_Year.SelectedValue)); }
            else
            { _Cmb_Month.DataSource = null; }
        }

        private void _Ctrl_ConsultaMes_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
