using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace T3
{
    public partial class Frm_Inf_BalanceGeneral : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_BalanceGeneral()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "RPT_BALANCEGRALDET";
        }
        private string _Mtd_NombComp()
        {
            string _Str_Cadena = "Select cname from dbo.TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
            }
            return "";
        }
        private void _Mtd_CargarMeses()
        {
            string _Str_Sql = "SELECT DISTINCT CONVERT(DATETIME,'01'+'/'+CONVERT(VARCHAR,cmontacco)+'/'+CONVERT(VARCHAR,cyearacco)) AS EEE,CONVERT(VARCHAR,cmontacco)+'-'+CONVERT(VARCHAR,cyearacco) AS CVALOR FROM TMESCONTABLE WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND ccerrado='1' ORDER BY EEE DESC ";
            //DataSet _Ds_DataSet = new DataSet();
            //string _Str_Sql = "SELECT cmontacco,CONVERT(VARCHAR,cmontacco)+'-'+CONVERT(VARCHAR,cyearacco) FROM TMESCONTABLE where ccompany='" + Frm_Padre._Str_Comp + "' AND ccerrado='1'";
            _myUtilidad._Mtd_CargarCombo(_Cb_Mes, _Str_Sql);
        }
        private string[] _Mtd_ExtraerMesAno(string _P_Str_Items)
        {
            int _Int_i = _P_Str_Items.Trim().IndexOf("-");
            return new string[] { _P_Str_Items.Substring(0, _Int_i).Trim(), _P_Str_Items.Substring(_Int_i + 1).Trim() };
        }
        private string _Mtd_NomMes(int _P_Int_Mes)
        {
            switch (_P_Int_Mes)
            {
                case 1:
                    return "ENERO";
                case 2:
                    return "FEBRERO";
                case 3:
                    return "MARZO";
                case 4:
                    return "ABRIL";
                case 5:
                    return "MAYO";
                case 6:
                    return "JUNIO";
                case 7:
                    return "JULIO";
                case 8:
                    return "AGOSTO";
                case 9:
                    return "SEPTIEMBRE";
                case 10:
                    return "OCTUBRE";
                case 11:
                    return "NOVIEMBRE";
                case 12:
                    return "DICIEMBRE";
            }
            return "";
        }
        private string _Mtd_MesPreB()
        {
            //string _Str_Sql = "SELECT TOP 1 CONVERT(VARCHAR,cmontacco)+'-'+CONVERT(VARCHAR,cyearacco) as Fecha FROM TMESCONTABLE where ccerrado='0' AND (convert(datetime,'1/'+ convert(varchar,cmontacco)+'/'+convert(varchar,cyearacco))>(SELECT TOP 1 convert(datetime,'1/'+ convert(varchar,cmontacco)+'/'+convert(varchar,cyearacco)) as Fecha FROM TMESCONTABLE WHERE ccerrado='1')) ORDER BY Fecha ASC";
            string _Str_Sql = "SELECT TOP 1 CONVERT(VARCHAR,cmontacco)+'-'+CONVERT(VARCHAR,cyearacco),(convert(datetime,'1/'+ convert(varchar,cmontacco)+'/'+convert(varchar,cyearacco))) as Fecha FROM TMESCONTABLE where ccompany='" + Frm_Padre._Str_Comp + "' AND ccerrado='0' AND (convert(datetime,'1/'+ convert(varchar,cmontacco)+'/'+convert(varchar,cyearacco))>(SELECT TOP 1 convert(datetime,'1/'+ convert(varchar,cmontacco)+'/'+convert(varchar,cyearacco)) as Fecha FROM TMESCONTABLE WHERE ccerrado='1')) ORDER BY Fecha ASC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    return _Ds.Tables[0].Rows[0][0].ToString().Trim();
                }
            }
            else
            {
                _Str_Sql = "SELECT TOP 1 CONVERT(VARCHAR,cmontacco)+'-'+CONVERT(VARCHAR,cyearacco),(convert(datetime,'1/'+ convert(varchar,cmontacco)+'/'+convert(varchar,cyearacco))) as Fecha FROM TMESCONTABLE where ccompany='" + Frm_Padre._Str_Comp + "' AND ccerrado='0' ORDER BY Fecha ASC";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        return _Ds.Tables[0].Rows[0][0].ToString().Trim();
                    }
                }
            }
            return "";
        }
        private void _Mtd_Busqueda()
        {
            string _Str_Tipo="1";
            if(_Rbt_Subtotales.Checked)
            {
                _Str_Tipo="2";
            }
            if(_Rbt_Totales.Checked)
            {
                _Str_Tipo="3";
            }
            ReportParameter[] parm = new ReportParameter[6];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            string[] _Str_MesAno = new string[2];
            if (_Rbt_Balance.Checked)
            { _Str_MesAno = _Mtd_ExtraerMesAno(_Cb_Mes.Text.Trim()); }
            else
            { _Str_MesAno = _Mtd_ExtraerMesAno(_Mtd_MesPreB().Trim()); }
            parm[1] = new ReportParameter("CMES", _Str_MesAno[0]);
            parm[2] = new ReportParameter("CANO", _Str_MesAno[1]);
            parm[3] = new ReportParameter("CMESNAME", _Mtd_NomMes(Convert.ToInt32(_Str_MesAno[0])));
            parm[4] = new ReportParameter("CNOMEMP", _Mtd_NombComp());
            parm[5] = new ReportParameter("CTIPOREPORT", _Str_Tipo);
            if (_Str_MesAno[0].Trim().Length == 0)
            {
                MessageBox.Show("Error. No se obtuvo el mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _Rpt_Report.ServerReport.SetParameters(parm);
                _Rpt_Report.ServerReport.Refresh();
                _Rpt_Report.RefreshReport();
            }
        }
        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {

        }

        private void _Rbt_Balance_CheckedChanged(object sender, EventArgs e)
        {
            _Mtd_CargarMeses();
            _Cb_Mes.Enabled = true;
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "RPT_BALANCEGRALDET";
        }

        private void _Rbt_PreBalance_CheckedChanged(object sender, EventArgs e)
        {
            _Cb_Mes.SelectedIndex = -1;
            _Cb_Mes.Enabled = false;
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "RPT_PREBALANCEGRALDET";
        }

        private void Frm_Inf_BalanceGeneral_Load(object sender, EventArgs e)
        {

        }

        private void _Bt_Consultar_Click_1(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            Cursor = Cursors.WaitCursor;
            if (_Rbt_Balance.Checked & _Cb_Mes.SelectedIndex > 0)
            { _Mtd_Busqueda(); }
            else if (_Rbt_Balance.Checked & _Cb_Mes.SelectedIndex <= 0)
            { _Er_Error.SetError(_Cb_Mes, "Información requerida."); }
            else
            { _Mtd_Busqueda(); }
            Cursor = Cursors.Default;
        }

        private void _Cb_Mes_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarMeses();
        }
    }
}