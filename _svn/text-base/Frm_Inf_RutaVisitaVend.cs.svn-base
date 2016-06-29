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
    public partial class Frm_Inf_RutaVisitaVend : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_RutaVisitaVend()
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_InfRutaVisitaVend";
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
        private void _Mtd_CargarVendedores()
        {
            // cambio No. 8768762837628 sugerido por eylin nava: que no aparezcan vendedores inactivos
            //string _Str_Sql = "SELECT cvendedor,RTRIM(cvendedor) + '-' + RTRIM(cname) FROM TVENDEDOR WHERE cdelete=0 AND c_tipo_vend='1' AND ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY CONVERT(NUMERIC(18,0),REPLACE(REPLACE(CVENDEDOR,'_',''),RTRIM(CCOMPANY),''))";
            string _Str_Sql = "SELECT cvendedor,RTRIM(cvendedor) + '-' + RTRIM(cname) FROM TVENDEDOR WHERE cdelete=0 AND c_tipo_vend='1' AND c_activo = '1' AND ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY CONVERT(NUMERIC(18,0),REPLACE(REPLACE(CVENDEDOR,'_',''),RTRIM(CCOMPANY),''))";
            _myUtilidad._Mtd_CargarCombo(_Cb_Vendedor, _Str_Sql);
        }
        private void _Mtd_CargarDias()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cb_Dia.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("LUNES", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("MARTES", "2"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("MIÉRCOLES", "3"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("JUEVES", "4"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("VIRNES", "5"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("SÁBADO", "6"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("DOMINGO", "7"));
            _Cb_Dia.DataSource = _myArrayList;
            _Cb_Dia.DisplayMember = "Display";
            _Cb_Dia.ValueMember = "Value";
            _Cb_Dia.SelectedValue = "nulo";
            _Cb_Dia.DataSource = _myArrayList;
            _Cb_Dia.SelectedIndex = 0;
        }
        private void _Mtd_Busqueda(string _P_Str_Vendedor, string _P_Str_Dia)
        {
            ReportParameter[] parm = new ReportParameter[6];
            parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
            parm[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[2] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            parm[3] = new ReportParameter("CVENDEDOR", _P_Str_Vendedor);
            parm[4] = new ReportParameter("CCLIENTE", "0");
            parm[5] = new ReportParameter("CDIA", _P_Str_Dia);            
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }

        private void _Cb_Vendedor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_CargarVendedores();
            this.Cursor = Cursors.Default;
        }


        private void _Cb_Dia_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_CargarDias();
            this.Cursor = Cursors.Default;
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Vendedor = "";
            string _Str_Dia = "";
            //-------------------------------------------
            if (_Cb_Vendedor.SelectedIndex == -1)
            { _Str_Vendedor = "0"; }
            else if (_Cb_Vendedor.SelectedIndex == 0)
            { _Str_Vendedor = "0"; }
            else
            { _Str_Vendedor = _Cb_Vendedor.SelectedValue.ToString(); }
            //--------
            if (_Cb_Dia.SelectedIndex == -1)
            { _Str_Dia = "0"; }
            else if (_Cb_Dia.SelectedIndex == 0)
            { _Str_Dia = "0"; }
            else
            { _Str_Dia = _Cb_Dia.SelectedValue.ToString(); }
            //-------------------------------------------
            _Mtd_Busqueda(_Str_Vendedor, _Str_Dia);
            this.Cursor = Cursors.Default;
        }

        private void _Bt_Limpiar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_CargarVendedores();
            _Mtd_CargarDias();
            this.Cursor = Cursors.Default;
        }

        private void Frm_Inf_RutaVisitaVend_Load(object sender, EventArgs e)
        {

        }
    }
}