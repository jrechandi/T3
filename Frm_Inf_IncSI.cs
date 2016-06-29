// código verificado el 22/10/2012, conjunto de cambios 1734 por lordonez

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
    public partial class Frm_Inf_IncSI : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new T3.CLASES._Cls_Varios_Metodos(true);
        
        
        /// <summary>
        /// Constructor: asigna la conexion al reporte, el nombre logico, y carga el primer combobox
        /// </summary>
        public Frm_Inf_IncSI()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_IncSI";
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarMeses();
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Obtiene los años y meses que tienen reportes generados. Llena el combo _Cmb_Mes con esa información
        /// </summary>
        private void _Mtd_CargarMeses()
        {
            string _Str_Cadena = _Str_Cadena = "SELECT CONVERT(VARCHAR,cmes)+'-'+CONVERT(VARCHAR,cano),CONVERT(VARCHAR,cmes)+'-'+CONVERT(VARCHAR,cano) FROM TCALINCSI INNER JOIN TCALINCSI_REPORTEM ON TCALINCSI.cidreporte = TCALINCSI_REPORTEM.cidreporte WHERE (TCALINCSI_REPORTEM.ccompany = '" + Frm_Padre._Str_Comp + "') GROUP BY TCALINCSI_REPORTEM.cano, TCALINCSI_REPORTEM.cmes ORDER BY TCALINCSI_REPORTEM.cano DESC, TCALINCSI_REPORTEM.cmes DESC "; 
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Mes, _Str_Cadena);
        }
        
        /// <summary>
        /// Saca el mes y el año de de una cadena de texto específica. 
        /// La cadena es un value del combo de meses, que tiene la forma: mm-aaaa
        /// </summary>
        /// <param name="_P_Str_Items">Cadena de texto con el añy y el mes</param>
        /// <returns>Arreglo de string con el año y el mes</returns>
        private string[] _Mtd_ExtraerMesAno(string _P_Str_Items)
        {
            int _Int_i = _P_Str_Items.Trim().IndexOf("-");
            return new string[] { _P_Str_Items.Substring(0, _Int_i).Trim(), _P_Str_Items.Substring(_Int_i + 1).Trim() };
        }
                
        /// <summary>
        /// Obtiene la lista de los grupos incentivados para un año y mes específico, y llena el combo _Cmb_Grupo
        /// </summary>
        private void _Mtd_CargarGrupos()
        {
            string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.SelectedValue.ToString());
            string _Str_Cadena = ""; 
             
            _Str_Cadena += "               SELECT     TOP 100 PERCENT dbo.TGRUPOIV.cidgrupincentivar, dbo.TGRUPOIV.cdescripcion ";
            _Str_Cadena += "FROM         dbo.TCALINCSI INNER JOIN  ";
            _Str_Cadena += "                      dbo.TINCSIM ON dbo.TCALINCSI.cidincsim = dbo.TINCSIM.cidincsim INNER JOIN  ";
            _Str_Cadena += "                      dbo.TGRUPOIV ON dbo.TINCSIM.cidgrupincentivar = dbo.TGRUPOIV.cidgrupincentivar AND dbo.TINCSIM.ccompany = dbo.TGRUPOIV.ccompany INNER JOIN  ";
            _Str_Cadena += "                     dbo.TCALINCSI_REPORTEM ON dbo.TCALINCSI.cidreporte = dbo.TCALINCSI_REPORTEM.cidreporte AND  ";
            _Str_Cadena += "                     dbo.TINCSIM.ccompany = dbo.TCALINCSI_REPORTEM.ccompany  ";
            _Str_Cadena += "WHERE     (dbo.TCALINCSI_REPORTEM.ccompany = '" + Frm_Padre._Str_Comp + "') AND (dbo.TCALINCSI_REPORTEM.cano = '" + _Str_Valores[1] + "') AND (dbo.TCALINCSI_REPORTEM.cmes = '" + _Str_Valores[0] + "') ";
            _Str_Cadena += "GROUP BY dbo.TGRUPOIV.cidgrupincentivar, dbo.TGRUPOIV.cdescripcion  ";
            _Str_Cadena += "ORDER BY dbo.TGRUPOIV.cdescripcion";

            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Grupo, _Str_Cadena);
        }
                
        /// <summary>
        /// Obtiene la lista de usuarios (vendedores, GDAs, GVTASz) que fueorn inventivados en un mes específico, y llena el combo _Cmb_User
        /// </summary>
        private void _Mtd_CargarUsuarios()
        {
            string[] _Str_Valores = _Mtd_ExtraerMesAno(_Cmb_Mes.SelectedValue.ToString());
            string _Str_Cadena = "";

            _Str_Cadena += "SELECT     TOP 100 PERCENT dbo.TCALINCSI.cvendedor, (LTRIM(TCALINCSI.cvendedor) + ' - ' + dbo.TCALINCSI.cvendedordesc) as cvendedordesc ";
            _Str_Cadena += "FROM         dbo.TCALINCSI INNER JOIN ";
            _Str_Cadena += "dbo.TCALINCSI_REPORTEM ON dbo.TCALINCSI.cidreporte = dbo.TCALINCSI_REPORTEM.cidreporte INNER JOIN ";
            _Str_Cadena += "dbo.TINCSIM ON dbo.TCALINCSI.cidincsim = dbo.TINCSIM.cidincsim ";
            _Str_Cadena += "WHERE     (dbo.TCALINCSI_REPORTEM.ccompany = '" + Frm_Padre._Str_Comp + "') AND (dbo.TCALINCSI_REPORTEM.cano = '" + _Str_Valores[1] + "') AND (dbo.TCALINCSI_REPORTEM.cmes = '" + _Str_Valores[0] + "') AND (TINCSIM.cidgrupincentivar = '" + Convert.ToString(_Cmb_Grupo.SelectedValue).Trim() + "')";
            _Str_Cadena += "ORDER BY dbo.TCALINCSI.cvendedordesc ";
                           

            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_User, _Str_Cadena);
        }
                
        /// <summary>
        /// Pasa los parámetros especificados por el usuario y consulta el reporte
        /// </summary>
        private void _Mtd_Consultar()
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
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[6];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CANO", _Str_Valores[1]);
            parm[2] = new ReportParameter("CMES", _Str_Valores[0]);
            parm[3] = new ReportParameter("CGRUPOIV", _Str_GrupoInc);
            parm[4] = new ReportParameter("CNOMBEMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            parm[5] = new ReportParameter("CUSER", _Str_Usuario);
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }
        
        /// <summary>
        /// Maximiza el formulario!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Inf_IncSI_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Valida que esté seleccionado un mes, y carga el reporte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            // este es el nombre que se usa por omisión en el archivo excel, cuando se exporta
            _Rpt_Report.ServerReport.DisplayName = CLASES._Cls_Varios_Metodos._Mtd_NombreReportesExportacion("RPT_INC_SI");
            
            _Er_Error.Dispose();
            if (_Cmb_Mes.SelectedIndex > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Consultar();
                Cursor = Cursors.Default;
            }
            else
            {
                if (_Cmb_Mes.SelectedIndex == 0) { _Er_Error.SetError(_Cmb_Mes, "Información requerida!!!"); }
            }
        }
                
        /// <summary>
        /// actualiza el combo _Cmb_Grupo al seleccionar un mes...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Cmb_Mes_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (_Cmb_Mes.SelectedIndex > 0)
            { Cursor = Cursors.WaitCursor; _Mtd_CargarGrupos(); Cursor = Cursors.Default; _Cmb_Grupo.Enabled = true; }
            else
            { _Cmb_Grupo.DataSource = null; _Cmb_Grupo.Enabled = false; }
        }
                
        /// <summary>
        /// re-llena el combo de meses
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Cmb_Mes_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarMeses();
            Cursor = Cursors.Default;

        }
        
        /// <summary>
        /// re-llena el combo de grupos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Cmb_Grupo_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarGrupos();
            Cursor = Cursors.Default; 
        }
                
        /// <summary>
        /// llena el combo de usuarios al seleccionar un grupo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Cmb_Grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Grupo.SelectedIndex > 0)
            { Cursor = Cursors.WaitCursor; _Mtd_CargarUsuarios(); Cursor = Cursors.Default; _Cmb_User.Enabled = true; }
            else
            { _Cmb_User.DataSource = null; _Cmb_User.Enabled = false; }
        }

        /// <summary>
        /// re-llena el combo de usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Cmb_User_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarUsuarios();
            Cursor = Cursors.Default; 
        }


    }
}
