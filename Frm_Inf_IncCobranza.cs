using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace T3
{
    public partial class Frm_Inf_IncCobranza : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new T3.CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_IncCobranza()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarMeses();
            Cursor = Cursors.Default;
        }
        private void _Mtd_CargarMeses()
        {
            string _Str_Cadena = _Str_Cadena = "SELECT CONVERT(VARCHAR,cmesventas)+'-'+CONVERT(VARCHAR,canoventas),CONVERT(VARCHAR,cmesventas)+'-'+CONVERT(VARCHAR,canoventas) FROM TCONFIGINCVTAS WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND (cejec1generado <> 0 OR cejec2generado <> 0)";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Mes, _Str_Cadena);
        }
        private string[] _Mtd_ExtraerMesAno(string _P_Str_Items)
        {
            int _Int_i = _P_Str_Items.Trim().IndexOf("-");
            return new string[] { _P_Str_Items.Substring(0, _Int_i).Trim(), _P_Str_Items.Substring(_Int_i + 1).Trim() };
        }
        private void _Mtd_Generaciones()
        {
            string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.SelectedValue.ToString());
            string _Str_Cadena = "SELECT '1','Desde '+CONVERT(VARCHAR,cperejecucion1d,103)+' hasta '+CONVERT(VARCHAR,cperejecucion1h,103) FROM TCONFIGINCVTAS WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cmesventas='" + _Str_Valores[0] + "' AND canoventas='" + _Str_Valores[1] + "'";
            _Str_Cadena += " UNION ";
            _Str_Cadena += "SELECT '2',ISNULL('Desde '+CONVERT(VARCHAR,cperejecucion2d,103)+' hasta '+CONVERT(VARCHAR,cperejecucion2h,103),'N/A') FROM TCONFIGINCVTAS WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cmesventas='" + _Str_Valores[0] + "' AND canoventas='" + _Str_Valores[1] + "'";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Generacion, _Str_Cadena);
        }
        private void _Mtd_CargarGrupos()
        {
            string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.SelectedValue.ToString());
            string _Str_Cadena = "SELECT DISTINCT TOP 100 PERCENT TGRUPOIV.cidgrupincentivar, TGRUPOIV.cdescripcion " +
                                 "FROM TGRUPOIV INNER JOIN " +
                                 "TCALINCCOB ON TGRUPOIV.cgroupcomp = TCALINCCOB.cgroupcomp AND TGRUPOIV.ccompany = TCALINCCOB.ccompany AND " +
                                 "TGRUPOIV.cidgrupincentivar = TCALINCCOB.cidgrupincentivar INNER JOIN " +
                                 "TCARGOSNOM ON TGRUPOIV.cidcargonom = TCARGOSNOM.cidcargonom " +
                                 "WHERE (TGRUPOIV.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TGRUPOIV.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TCALINCCOB.ctipogeneracion = '" + Convert.ToString(_Cmb_Generacion.SelectedValue).Trim() + "') AND (TCALINCCOB.cyearacco = '" + _Str_Valores[1] + "') AND (TCALINCCOB.cmontacco = '" + _Str_Valores[0] + "')";
            if (_Rb_Detallado.Checked)
            { _Str_Cadena += " AND TCARGOSNOM.cvendedor='1'"; }
            _Str_Cadena += " ORDER BY TGRUPOIV.cdescripcion";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Grupo, _Str_Cadena);
        }
        private void _Mtd_CargarUsuarios()
        {
            string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.SelectedValue.ToString());
            string _Str_Cadena = "SELECT DISTINCT TOP 100 PERCENT TCALINCCOB.cvendedor, TCALINCCOB.cvendedor+' - '+ TUSER.cname, TUSER.cname " +
                                 "FROM TGRUPOIV INNER JOIN " +
                                 "TCALINCCOB ON TGRUPOIV.cgroupcomp = TCALINCCOB.cgroupcomp AND TGRUPOIV.ccompany = TCALINCCOB.ccompany AND " +
                                 "TGRUPOIV.cidgrupincentivar = TCALINCCOB.cidgrupincentivar INNER JOIN " +
                                 "TUSER ON TCALINCCOB.cvendedor = TUSER.cuser " +
                                 "WHERE (TGRUPOIV.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TGRUPOIV.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TCALINCCOB.ctipogeneracion = '" + Convert.ToString(_Cmb_Generacion.SelectedValue).Trim() + "') AND (TCALINCCOB.cyearacco = '" + _Str_Valores[1] + "') AND (TCALINCCOB.cmontacco = '" + _Str_Valores[0] + "') AND (TGRUPOIV.cidgrupincentivar = '" + Convert.ToString(_Cmb_Grupo.SelectedValue).Trim() + "') " +
                                 "ORDER BY TUSER.cname";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_User, _Str_Cadena);
        }
        private void _Mtd_Busqueda()
        {
            string _Str_GrupoInc = "0";
            string _Str_Usuario = "0";
            //------------------------------
            if (_Cmb_Grupo.SelectedIndex > 0)
            { _Str_GrupoInc = Convert.ToString(_Cmb_Grupo.SelectedValue).Trim(); }
            //------------------------------
            if (_Cmb_User.SelectedIndex > 0)
            { _Str_Usuario = Convert.ToString(_Cmb_User.SelectedValue).Trim(); }
            //------------------------------
            string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.SelectedValue.ToString());
            //------------------------------
            if (_Rb_Resumido.Checked)
            { _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_IncCobranza"; }
            else
            { _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_IncCobranzaD"; }
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[8];
            parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
            parm[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[2] = new ReportParameter("CTIPOGENERACION", Convert.ToString(_Cmb_Generacion.SelectedValue).Trim());
            parm[3] = new ReportParameter("CANO", _Str_Valores[1]);
            parm[4] = new ReportParameter("CMES", _Str_Valores[0]);
            parm[5] = new ReportParameter("CIDGRUPOINC", _Str_GrupoInc);
            parm[6] = new ReportParameter("CVENDEDOR", _Str_Usuario);
            parm[7] = new ReportParameter("CNOMBEMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }
        private void Frm_Inf_IncCobranza_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            _Rpt_Report.ServerReport.DisplayName = CLASES._Cls_Varios_Metodos._Mtd_NombreReportesExportacion("RPT_INC_COBRANZA");
            _Er_Error.Dispose();
            if (_Cmb_Mes.SelectedIndex > 0 & _Cmb_Generacion.SelectedIndex > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Busqueda();
                Cursor = Cursors.Default;
            }
            else
            {
                if (_Cmb_Mes.SelectedIndex == 0) { _Er_Error.SetError(_Cmb_Mes, "Información requerida!!!"); }
                if (_Cmb_Generacion.SelectedIndex == 0) { _Er_Error.SetError(_Cmb_Generacion, "Información requerida!!!"); }
            }
        }

        private void _Cmb_Mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Mes.SelectedIndex > 0)
            { Cursor = Cursors.WaitCursor; _Mtd_Generaciones(); Cursor = Cursors.Default; _Cmb_Generacion.Enabled = true; }
            else
            { _Cmb_Generacion.DataSource = null; _Cmb_Generacion.Enabled = false; }
        }

        private void _Cmb_Mes_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarMeses();
            Cursor = Cursors.Default;

        }

        private void _Cmb_Generacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Generacion.SelectedIndex > 0)
            { Cursor = Cursors.WaitCursor; _Mtd_CargarGrupos(); Cursor = Cursors.Default; _Cmb_Grupo.Enabled = true; }
            else
            { _Cmb_Grupo.DataSource = null; _Cmb_Grupo.Enabled = false; }
        }

        private void _Cmb_Generacion_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Generaciones();
            Cursor = Cursors.Default;
        }

        private void _Cmb_Grupo_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarGrupos();
            Cursor = Cursors.Default; 
        }

        private void _Cmb_Grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Grupo.SelectedIndex > 0)
            { Cursor = Cursors.WaitCursor; _Mtd_CargarUsuarios(); Cursor = Cursors.Default; _Cmb_User.Enabled = true; }
            else
            { _Cmb_User.DataSource = null; _Cmb_User.Enabled = false; }
        }

        private void _Cmb_User_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarUsuarios();
            Cursor = Cursors.Default; 
        }

        private void _Rb_Resumido_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Resumido.Checked & _Cmb_Grupo.Enabled)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_CargarGrupos();
                Cursor = Cursors.Default;
            }
        }

        private void _Rb_Detallado_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Detallado.Checked & _Cmb_Grupo.Enabled)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_CargarGrupos();
                Cursor = Cursors.Default;
            }
        }
    }
}
