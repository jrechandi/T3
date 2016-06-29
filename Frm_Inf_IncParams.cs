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
    public partial class Frm_Inf_IncParams : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new T3.CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_IncParams()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarMeses();
            Cursor = Cursors.Default;
        }
        private void _Mtd_CargarMeses()
        {
            string _Str_Cadena;
            DataSet _Ds;
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            
            if (_Rb_SurtidoIdeal.Checked)
            {
                _Str_Cadena = "SELECT TOP 100 PERCENT CONVERT(VARCHAR, dbo.TCONFIGINCVTASCUARTOS.cmescalendario) + ' - ' + CONVERT(VARCHAR, dbo.TINCSID.cano) AS cmesano,";
                _Str_Cadena += " dbo.TINCSID.cano, dbo.TINCSID.ccuarto";
                _Str_Cadena += " FROM dbo.TINCSID INNER JOIN";
                _Str_Cadena += " dbo.TCONFIGINCVTASCUARTOS ON dbo.TINCSID.ccuarto = dbo.TCONFIGINCVTASCUARTOS.ccuarto";
                _Str_Cadena += " GROUP BY CONVERT(VARCHAR, dbo.TCONFIGINCVTASCUARTOS.cmescalendario) + ' - ' + CONVERT(VARCHAR, dbo.TINCSID.cano), dbo.TINCSID.cano,";
                _Str_Cadena += " dbo.TCONFIGINCVTASCUARTOS.cmescalendario, dbo.TINCSID.ccuarto";
                _Str_Cadena += " ORDER BY dbo.TINCSID.cano DESC, dbo.TCONFIGINCVTASCUARTOS.cmescalendario DESC;";

                _Cmb_Mes.DataSource = null;
                
                _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));

                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                
                foreach (DataRow _DRow in _Ds.Tables[0].Rows)
                {
                    _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[0].ToString(), _DRow[2].ToString()));
                }

                _Cmb_Mes.DataSource = _myArrayList;
                _Cmb_Mes.DisplayMember = "Display";
                _Cmb_Mes.ValueMember = "Value";
                _Cmb_Mes.SelectedValue = "nulo";
            }
            else
            {
                _Str_Cadena = "SELECT CONVERT(VARCHAR,cmesventas)+'-'+CONVERT(VARCHAR,canoventas),CONVERT(VARCHAR,cmesventas)+'-'+CONVERT(VARCHAR,canoventas) FROM TCONFIGINCVTAS WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Mes, _Str_Cadena);
            }
        }
        private string[] _Mtd_ExtraerMesAno(string _P_Str_Items)
        {
            int _Int_i = _P_Str_Items.Trim().IndexOf("-");
            return new string[] { _P_Str_Items.Substring(0, _Int_i).Trim(), _P_Str_Items.Substring(_Int_i + 1).Trim() };
        }
        private void _Mtd_CargarGrupos()
        {
            bool _Bol_Valido = true;
            string _Str_Cadena = "";
            DataSet _Ds;
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();

            if (_Rb_Ventas.Checked)
            {
                _Str_Cadena = "SELECT DISTINCT TOP 100 PERCENT TGRUPOIV.cidgrupincentivar, TGRUPOIV.cdescripcion " +
                                 "FROM TGRUPOIV INNER JOIN " +
                                 "TINCVTAS ON TGRUPOIV.cgroupcomp = TINCVTAS.cgroupcomp AND TGRUPOIV.ccompany = TINCVTAS.ccompany AND " +
                                 "TGRUPOIV.cidgrupincentivar = TINCVTAS.cidgrupincentivar" +
                " WHERE (TGRUPOIV.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TGRUPOIV.ccompany = '" + Frm_Padre._Str_Comp + "') ORDER BY TGRUPOIV.cdescripcion";
            }
            if (_Rb_Cobranza.Checked)
            {
                _Str_Cadena = "SELECT DISTINCT TOP 100 PERCENT TGRUPOIV.cidgrupincentivar, TGRUPOIV.cdescripcion " +
                                 "FROM TGRUPOIV INNER JOIN " +
                                 "TINCCOB ON TGRUPOIV.cgroupcomp = TINCCOB.cgroupcomp AND TGRUPOIV.ccompany = TINCCOB.ccompany AND " +
                                 "TGRUPOIV.cidgrupincentivar = TINCCOB.cidgrupincentivar" +
                " WHERE (TGRUPOIV.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TGRUPOIV.ccompany = '" + Frm_Padre._Str_Comp + "') ORDER BY TGRUPOIV.cdescripcion";
            }
            if (_Rb_Varios.Checked)
            {
                _Str_Cadena = "SELECT DISTINCT TOP 100 PERCENT TGRUPOIV.cidgrupincentivar, TGRUPOIV.cdescripcion " +
                                 "FROM TGRUPOIV INNER JOIN " +
                                 "TINCVARIOS ON TGRUPOIV.cgroupcomp = TINCVARIOS.cgroupcomp AND TGRUPOIV.ccompany = TINCVARIOS.ccompany AND " +
                                 "TGRUPOIV.cidgrupincentivar = TINCVARIOS.cidgrupincentivar " +
                " WHERE (TGRUPOIV.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TGRUPOIV.ccompany = '" + Frm_Padre._Str_Comp + "') ORDER BY TGRUPOIV.cdescripcion";
            }
            if (_Rb_Distribucion.Checked)
            {
                _Er_Error.Dispose();
                if (_Cmb_Mes.SelectedIndex == 0)
                {
                    _Er_Error.SetError(_Cmb_Mes, "Información requerida!!!");
                    _Bol_Valido = false;
                }
                else
                {
                    string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.SelectedValue.ToString());
                    _Str_Cadena = "SELECT DISTINCT TOP 100 PERCENT TGRUPOIV.cidgrupincentivar, TGRUPOIV.cdescripcion " +
                                         "FROM TGRUPOIV INNER JOIN " +
                                         "TINCDISTRIBU ON TGRUPOIV.cgroupcomp = TINCDISTRIBU.cgroupcomp AND TGRUPOIV.ccompany = TINCDISTRIBU.ccompany AND " +
                                         "TGRUPOIV.cidgrupincentivar = TINCDISTRIBU.cidgrupincentivar INNER JOIN TINCDISTRIBUD ON TINCDISTRIBUD.cgroupcomp=TINCDISTRIBU.cgroupcomp AND TINCDISTRIBUD.ccompany=TINCDISTRIBU.ccompany AND TINCDISTRIBUD.cidincdistribu=TINCDISTRIBU.cidincdistribu" +
                        " WHERE TINCDISTRIBUD.CMES='" + _Str_Valores[0] + "' AND TINCDISTRIBUD.CANO='" + _Str_Valores[1] + "' AND (TGRUPOIV.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TGRUPOIV.ccompany = '" + Frm_Padre._Str_Comp + "') ORDER BY TGRUPOIV.cdescripcion";
                }
            }
            if (_Rb_MarcaFoco.Checked)
            {
                _Er_Error.Dispose();
                if (_Cmb_Mes.SelectedIndex == 0)
                {
                    _Er_Error.SetError(_Cmb_Mes, "Información requerida!!!");
                    _Bol_Valido = false;
                }
                else
                {
                    string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.SelectedValue.ToString());
                    _Str_Cadena = "SELECT DISTINCT TOP 100 PERCENT TGRUPOIV.cidgrupincentivar, TGRUPOIV.cdescripcion " +
                                         "FROM TGRUPOIV INNER JOIN " +
                                         "TINCMARCAFOCO ON TGRUPOIV.cgroupcomp = TINCMARCAFOCO.cgroupcomp AND TGRUPOIV.ccompany = TINCMARCAFOCO.ccompany AND " +
                                         "TGRUPOIV.cidgrupincentivar = TINCMARCAFOCO.cidgrupincentivar INNER JOIN TINCMARCAFOCOD ON TINCMARCAFOCOD.cgroupcomp=TINCMARCAFOCO.cgroupcomp AND TINCMARCAFOCOD.ccompany=TINCMARCAFOCO.ccompany AND TINCMARCAFOCOD.cidincmarcafoco=TINCMARCAFOCO.cidincmarcafoco" +
                        " WHERE TINCMARCAFOCOD.CMES='" + _Str_Valores[0] + "' AND TINCMARCAFOCOD.CANO='" + _Str_Valores[1] + "' AND (TGRUPOIV.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TGRUPOIV.ccompany = '" + Frm_Padre._Str_Comp + "') ORDER BY TGRUPOIV.cdescripcion";
                }
            }

            if (_Rb_SurtidoIdeal.Checked)
            {
                _Er_Error.Dispose();

                if (_Cmb_Mes.SelectedIndex == 0)
                {
                    _Er_Error.SetError(_Cmb_Mes, "Información requerida!!!");
                    _Bol_Valido = false;
                }
                else
                {
                    string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.Text);

                    _Str_Cadena = "SELECT dbo.TINCSID.cano, dbo.TINCSID.ccuarto, dbo.TGRUPOIV.cidgrupincentivar, dbo.TGRUPOIV.cdescripcion";
                    _Str_Cadena += " FROM dbo.TGRUPOIV INNER JOIN";
                    _Str_Cadena += " dbo.TINCSIM ON dbo.TGRUPOIV.cidgrupincentivar = dbo.TINCSIM.cidgrupincentivar";
                    _Str_Cadena += " AND dbo.TGRUPOIV.ccompany = dbo.TINCSIM.ccompany INNER JOIN";
                    _Str_Cadena += " dbo.TINCSID ON dbo.TINCSIM.cidincsim = dbo.TINCSID.cidincsim";
                    _Str_Cadena += " WHERE ccuarto = " + _Cmb_Mes.SelectedValue;
                    _Str_Cadena += " AND cano = " + _Str_Valores[1];
                    _Str_Cadena += " GROUP BY dbo.TINCSID.cano, dbo.TINCSID.ccuarto, dbo.TGRUPOIV.cidgrupincentivar, dbo.TGRUPOIV.cdescripcion;";

                    _Cmb_Grupo.DataSource = null;

                    _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));

                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

                    foreach (DataRow _DRow in _Ds.Tables[0].Rows)
                    {
                        _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[3].ToString(), _DRow[2].ToString()));
                    }

                    _Cmb_Grupo.DataSource = _myArrayList;
                    _Cmb_Grupo.DisplayMember = "Display";
                    _Cmb_Grupo.ValueMember = "Value";
                    _Cmb_Grupo.SelectedValue = "nulo";

                    return;
                }
            }

            if (_Bol_Valido)
            {
                _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Grupo, _Str_Cadena);
            }
        }

        private void _Cmb_Grupo_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarGrupos();
            Cursor = Cursors.Default; 
        }

        private void _Cmb_Mes_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarMeses();
            Cursor = Cursors.Default; 
        }

        private void _Rb_Distribucion_CheckedChanged(object sender, EventArgs e)
        {
            _Cmb_Grupo.DataSource = null;
            if (_Rb_Distribucion.Checked)
            {
                label1.Enabled = true;
                _Cmb_Mes.Enabled = true;
                _Cmb_Mes.SelectedIndex = 0;
            }
            else
            {
                label1.Enabled = false;
                _Cmb_Mes.Enabled = false;
                _Cmb_Mes.SelectedIndex = 0;
            }
        }

        private void _Rb_MarcaFoco_CheckedChanged(object sender, EventArgs e)
        {
            _Cmb_Grupo.DataSource = null;
            if (_Rb_MarcaFoco.Checked)
            {
                label1.Enabled = true;
                _Cmb_Mes.Enabled = true;
                _Cmb_Mes.SelectedIndex = 0;
            }
            else
            {
                label1.Enabled = false;
                _Cmb_Mes.Enabled = false;
                _Cmb_Mes.SelectedIndex = 0;
            }
        }

        private void _Rb_Ventas_CheckedChanged(object sender, EventArgs e)
        {
            _Cmb_Grupo.DataSource = null;
            label1.Enabled = false;
            _Cmb_Mes.Enabled = false;
            _Cmb_Mes.SelectedIndex = 0;
        }

        private void _Rb_Cobranza_CheckedChanged(object sender, EventArgs e)
        {
            _Cmb_Grupo.DataSource = null;
            label1.Enabled = false;
            _Cmb_Mes.Enabled = false;
            _Cmb_Mes.SelectedIndex = 0;
        }

        private void _Rb_Varios_CheckedChanged(object sender, EventArgs e)
        {
            _Cmb_Grupo.DataSource = null;
            label1.Enabled = false;
            _Cmb_Mes.Enabled = false;
            _Cmb_Mes.SelectedIndex = 0;
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            _Rpt_Report.ServerReport.DisplayName = CLASES._Cls_Varios_Metodos._Mtd_NombreReportesExportacion("RPT_INC_PARAMETROS");
            
            _Er_Error.Dispose();
            bool _Bol_Valido = true;
            if (_Rb_MarcaFoco.Checked)
            {
                if(_Cmb_Mes.SelectedIndex == 0)
                {
                    _Er_Error.SetError(_Cmb_Mes, "Información requerida!!!");
                    _Bol_Valido = false;
                }
            }
            if (_Rb_Distribucion.Checked)
            {
                if (_Cmb_Mes.SelectedIndex == 0)
                {
                    _Er_Error.SetError(_Cmb_Mes, "Información requerida!!!");
                    _Bol_Valido = false;
                }
            }
            if (_Rb_SurtidoIdeal.Checked)
            {
                if (_Cmb_Mes.SelectedIndex == 0)
                {
                    _Er_Error.SetError(_Cmb_Mes, "Información requerida!!!");
                    _Bol_Valido = false;
                }
            }
            if (_Bol_Valido)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Busqueda();
                Cursor = Cursors.Default;
            }
            else
            {
            }
        }
        private void _Mtd_Busqueda()
        {
            string _Str_GrupoInc = "0";
            string _Str_Usuario = "0";
            //------------------------------
            if (_Cmb_Grupo.SelectedIndex > 0)
            { _Str_GrupoInc = Convert.ToString(_Cmb_Grupo.SelectedValue).Trim(); }
            //------------------------------
           
            //------------------------------
            if (_Rb_Ventas.Checked)
            { _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_IncVentasParams"; }
            else if (_Rb_Cobranza.Checked)
            { _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_IncCobParams"; }
            else if(_Rb_Varios.Checked)
            { _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_IncVariosParams"; }
            else if (_Rb_Distribucion.Checked)
            { _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_IncDisParams"; }
            else if (_Rb_SurtidoIdeal.Checked)
            { _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_IncSurtIdeal"; }
            else
            { _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_IncMFParams"; }

            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = null;
            if (_Rb_Ventas.Checked || _Rb_Cobranza.Checked || _Rb_Varios.Checked)
            {
                parm = new ReportParameter[4];
                parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
                parm[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
                parm[2] = new ReportParameter("CIDGRUPOINC", _Str_GrupoInc);
                parm[3] = new ReportParameter("CNOMBEMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            }
            else if (_Rb_Distribucion.Checked)
            {
                string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.SelectedValue.ToString());
                parm = new ReportParameter[6];
                parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
                parm[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
                parm[2] = new ReportParameter("CIDGRUPOINC", _Str_GrupoInc);
                parm[3] = new ReportParameter("CNOMBEMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
                parm[4] = new ReportParameter("CANO", _Str_Valores[1]);
                parm[5] = new ReportParameter("CMES", _Str_Valores[0]);

            }
            else if (_Rb_SurtidoIdeal.Checked)
            {
                string _Str_Grupo = "";

                if (_Cmb_Grupo.Text != "...")
                {
                    _Str_Grupo = Convert.ToString(_Cmb_Grupo.SelectedValue).Trim();
                }

                parm = new ReportParameter[5];
                parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
                parm[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
                parm[2] = new ReportParameter("CNOMBEMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
                parm[3] = new ReportParameter("CCUARTO", Convert.ToString(_Cmb_Mes.SelectedValue).Trim());
                parm[4] = new ReportParameter("CIDGRUPOINC", _Str_Grupo.Trim());
            }
            else
            {
                string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.SelectedValue.ToString());
                parm = new ReportParameter[6];
                parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
                parm[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
                parm[2] = new ReportParameter("CIDGRUPOINC", _Str_GrupoInc);
                parm[3] = new ReportParameter("CNOMBEMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
                parm[4] = new ReportParameter("CANO", _Str_Valores[1]);
                parm[5] = new ReportParameter("CMES", _Str_Valores[0]);
            }
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }

        private void Frm_Inf_IncParams_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void _Rb_SurtidoIdeal_CheckedChanged(object sender, EventArgs e)
        {
            _Cmb_Grupo.DataSource = null;

            if (_Rb_SurtidoIdeal.Checked)
            {
                label1.Enabled = true;
                _Cmb_Mes.Enabled = true;
                _Cmb_Mes.SelectedIndex = 0;
            }
            else
            {
                label1.Enabled = false;
                _Cmb_Mes.Enabled = false;
                _Cmb_Mes.SelectedIndex = 0;
            }
        }
    }
}
