using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Reflection;

namespace T3
{
    public partial class Frm_Inf_Varios : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMedodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_Varios()
        {
            InitializeComponent();
        }
        public Frm_Inf_Varios(int _P_Int_Sw, string _Str_String_1, string _Str_String_2)
        {
            InitializeComponent();
            if (_P_Int_Sw == 3)
            {
                _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_FacturaComp";
                _Mtd_Busqueda_3(_Str_String_1, _Str_String_2);
                this.Text = "Informe - Vista previa de la factura";
            }
            else if (_P_Int_Sw == 9)
            {
                FieldInfo fi = this._Rpt_Report.GetType().GetField("reportToolBar", BindingFlags.Instance | BindingFlags.NonPublic);
                object o;
                fi = (o = fi.GetValue(this._Rpt_Report)).GetType().GetField("printPreview", BindingFlags.Instance | BindingFlags.NonPublic);
                (fi.GetValue(o) as ToolStripButton).Owner.Items.Remove(fi.GetValue(o) as ToolStripButton);
                fi = this._Rpt_Report.GetType().GetField("m_viewMode", BindingFlags.Instance | BindingFlags.NonPublic);
                fi.SetValue(this._Rpt_Report, DisplayMode.PrintLayout);
                this._Rpt_Report.ZoomMode = ZoomMode.Percent;
                _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Tarjetas";
                _Mtd_Busqueda_9(_Str_String_1, _Str_String_2);
                this.Text = "Tarjetas de Inventario";
            }
        }
        public Frm_Inf_Varios(int _P_Int_Sw, string _P_Str_Codigo)
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            if (_P_Int_Sw == 1)
            {
                FieldInfo fi = this._Rpt_Report.GetType().GetField("reportToolBar", BindingFlags.Instance | BindingFlags.NonPublic);
                object o;
                fi = (o = fi.GetValue(this._Rpt_Report)).GetType().GetField("printPreview", BindingFlags.Instance | BindingFlags.NonPublic);
                (fi.GetValue(o) as ToolStripButton).Owner.Items.Remove(fi.GetValue(o) as ToolStripButton);
                fi = this._Rpt_Report.GetType().GetField("m_viewMode", BindingFlags.Instance | BindingFlags.NonPublic);
                fi.SetValue(this._Rpt_Report, DisplayMode.PrintLayout);
                this._Rpt_Report.ZoomMode = ZoomMode.Percent;
                _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_InfPrecarga";
                _Mtd_Busqueda_1(_P_Str_Codigo);
                this.Text = "Informe - Pre-Facturas";
            }
            else if (_P_Int_Sw == 2)
            {
                FieldInfo fi = this._Rpt_Report.GetType().GetField("reportToolBar", BindingFlags.Instance | BindingFlags.NonPublic);
                object o;
                fi = (o = fi.GetValue(this._Rpt_Report)).GetType().GetField("printPreview", BindingFlags.Instance | BindingFlags.NonPublic);
                (fi.GetValue(o) as ToolStripButton).Owner.Items.Remove(fi.GetValue(o) as ToolStripButton);
                fi = this._Rpt_Report.GetType().GetField("m_viewMode", BindingFlags.Instance | BindingFlags.NonPublic);
                fi.SetValue(this._Rpt_Report, DisplayMode.PrintLayout);
                this._Rpt_Report.ZoomMode = ZoomMode.Percent;
                _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_GuiaConDevol";
                _Mtd_Busqueda_2(_P_Str_Codigo);
                this.Text = "Informe - Devoluciones en la Guía";
            }
            else if (_P_Int_Sw == 10)
            {
                FieldInfo fi = this._Rpt_Report.GetType().GetField("reportToolBar", BindingFlags.Instance | BindingFlags.NonPublic);
                object o;
                fi = (o = fi.GetValue(this._Rpt_Report)).GetType().GetField("printPreview", BindingFlags.Instance | BindingFlags.NonPublic);
                (fi.GetValue(o) as ToolStripButton).Owner.Items.Remove(fi.GetValue(o) as ToolStripButton);
                fi = this._Rpt_Report.GetType().GetField("m_viewMode", BindingFlags.Instance | BindingFlags.NonPublic);
                fi.SetValue(this._Rpt_Report, DisplayMode.PrintLayout);
                this._Rpt_Report.ZoomMode = ZoomMode.Percent;
                _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_ClientesAtendidosPorDirecto";
                _Mtd_Busqueda_10();
                this.Text = "Informe - Clientes atendido por directo";
            }
            else if (_P_Int_Sw == 11)
            {
                FieldInfo fi = this._Rpt_Report.GetType().GetField("reportToolBar", BindingFlags.Instance | BindingFlags.NonPublic);
                object o;
                fi = (o = fi.GetValue(this._Rpt_Report)).GetType().GetField("printPreview", BindingFlags.Instance | BindingFlags.NonPublic);
                (fi.GetValue(o) as ToolStripButton).Owner.Items.Remove(fi.GetValue(o) as ToolStripButton);
                fi = this._Rpt_Report.GetType().GetField("m_viewMode", BindingFlags.Instance | BindingFlags.NonPublic);
                fi.SetValue(this._Rpt_Report, DisplayMode.PrintLayout);
                this._Rpt_Report.ZoomMode = ZoomMode.Percent;
                _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_ListadoProductosRotacionDias";
                _Mtd_Busqueda_11(_P_Str_Codigo);
                this.Text = "Informe - Rotación a más de 180 días";
            }
        }
        public Frm_Inf_Varios(int _P_Int_Sw, string _P_Str_Codigo, string _P_Str_Desde, string _P_Str_Hasta)
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            if (_P_Int_Sw == 4)
            {
                _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_ArchivoIVA";
                _Mtd_Busqueda_4(_P_Str_Codigo, _P_Str_Desde, _P_Str_Hasta);
                this.Text = "Informe - Declaración IVA";
            }
            else if (_P_Int_Sw == 5)
            {
                _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_ArchivoISLR";
                _Mtd_Busqueda_5(_P_Str_Codigo, _P_Str_Desde, _P_Str_Hasta);
                this.Text = "Informe - Declaración ISLR";
            }

            if (_P_Int_Sw == 8)
            {
                FieldInfo fi = this._Rpt_Report.GetType().GetField("reportToolBar", BindingFlags.Instance | BindingFlags.NonPublic);
                object o;
                fi = (o = fi.GetValue(this._Rpt_Report)).GetType().GetField("printPreview", BindingFlags.Instance | BindingFlags.NonPublic);
                (fi.GetValue(o) as ToolStripButton).Owner.Items.Remove(fi.GetValue(o) as ToolStripButton);
                fi = this._Rpt_Report.GetType().GetField("m_viewMode", BindingFlags.Instance | BindingFlags.NonPublic);
                fi.SetValue(this._Rpt_Report, DisplayMode.PrintLayout);
                this._Rpt_Report.ZoomMode = ZoomMode.Percent;

                _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_PedidosPorFacturar";
                _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);

                ReportParameter[] parm = new ReportParameter[3];
                parm[0] = new ReportParameter("CGROUPCOMP", _P_Str_Codigo); // los parametros del metodo tienen mal los nombres, deberian ser algo como string 1, string 2, string 3 ya que es una rutina generica
                parm[1] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
                parm[2] = new ReportParameter("CFECHA", _P_Str_Hasta);

                _Rpt_Report.ServerReport.SetParameters(parm);
                _Rpt_Report.ServerReport.Refresh();
                _Rpt_Report.RefreshReport();

                this.Text = "Pedidos por facturar";
            }
        }

        public Frm_Inf_Varios(int _P_Int_Sw, string _P_Str_CCOMPANY, string _P_Str_CNOMBEEMP, string _P_Str_CPREOC, string _P_Str_CPROVEEDOR, string _P_Str_CPROVDESC, string _P_Str_CFECHA)
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            if (_P_Int_Sw == 6)
            {
                FieldInfo fi = this._Rpt_Report.GetType().GetField("reportToolBar", BindingFlags.Instance | BindingFlags.NonPublic);
                object o;
                fi = (o = fi.GetValue(this._Rpt_Report)).GetType().GetField("printPreview", BindingFlags.Instance | BindingFlags.NonPublic);
                (fi.GetValue(o) as ToolStripButton).Owner.Items.Remove(fi.GetValue(o) as ToolStripButton);
                fi = this._Rpt_Report.GetType().GetField("m_viewMode", BindingFlags.Instance | BindingFlags.NonPublic);
                fi.SetValue(this._Rpt_Report, DisplayMode.PrintLayout);
                this._Rpt_Report.ZoomMode = ZoomMode.Percent;
                
                _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_PreOrden";
                _Mtd_Busqueda_6(_P_Str_CCOMPANY, _P_Str_CNOMBEEMP, _P_Str_CPREOC, _P_Str_CPROVEEDOR, _P_Str_CPROVDESC, _P_Str_CFECHA);
                this.Text = "Informe - Pre orden de compra";
            }
        }
        public Frm_Inf_Varios(int _P_Int_Sw, string _Str_CGROUPCOMP, string _Str_CFACTURA, string _Str_CRECEPCION, string _Str_CNOMBEMP, string _Str_CPROVDESC)
        {
            InitializeComponent();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            if (_P_Int_Sw == 7)
            {
                FieldInfo fi = this._Rpt_Report.GetType().GetField("reportToolBar", BindingFlags.Instance | BindingFlags.NonPublic);
                object o;
                fi = (o = fi.GetValue(this._Rpt_Report)).GetType().GetField("printPreview", BindingFlags.Instance | BindingFlags.NonPublic);
                (fi.GetValue(o) as ToolStripButton).Owner.Items.Remove(fi.GetValue(o) as ToolStripButton);
                fi = this._Rpt_Report.GetType().GetField("m_viewMode", BindingFlags.Instance | BindingFlags.NonPublic);
                fi.SetValue(this._Rpt_Report, DisplayMode.PrintLayout);
                this._Rpt_Report.ZoomMode = ZoomMode.Percent;

                _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_RecepcionImprimir";
                _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);

                ReportParameter[] parm = new ReportParameter[5];
                parm[0] = new ReportParameter("CGROUPCOMP", _Str_CGROUPCOMP);
                parm[1] = new ReportParameter("CFACTURA", _Str_CFACTURA);
                parm[2] = new ReportParameter("CRECEPCION", _Str_CRECEPCION);
                parm[3] = new ReportParameter("CNOMBEMP", _Str_CNOMBEMP);
                parm[4] = new ReportParameter("CPROVDESC", _Str_CPROVDESC);

                _Rpt_Report.ServerReport.SetParameters(parm);
                _Rpt_Report.ServerReport.Refresh();
                _Rpt_Report.RefreshReport();

                this.Text = "Recepción de mercancía";
            }
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
        private void _Mtd_Busqueda_1(string _P_Str_Precarga)
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[3];
            parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
            parm[1] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            parm[2] = new ReportParameter("CPRECARGA", _P_Str_Precarga);
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }
        private void _Mtd_Busqueda_2(string _P_Str_Guia)
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[3];
            parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
            parm[1] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            parm[2] = new ReportParameter("CGUIA", _P_Str_Guia);
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }

        private void _Mtd_Busqueda_3(string _P_Str_Factura,string _P_Str_Proveedor)
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[4];
            parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
            parm[1] = new ReportParameter("CFACTURA", _P_Str_Factura);
            parm[2] = new ReportParameter("CPROVEEDOR", _P_Str_Proveedor);
            parm[3] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }
        private void _Mtd_Busqueda_4(string _P_Str_Archivo, string _P_Str_Desde, string _P_Str_Hasta)
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[6];
            parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
            parm[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[2] = new ReportParameter("CIDARCHIVO", _P_Str_Archivo);
            parm[3] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            parm[4] = new ReportParameter("CFECHADESDE", _P_Str_Desde);
            parm[5] = new ReportParameter("CFECHAHASTA", _P_Str_Hasta);
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }
        private void _Mtd_Busqueda_5(string _P_Str_Archivo, string _P_Str_Desde, string _P_Str_Hasta)
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[6];
            parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
            parm[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[2] = new ReportParameter("CIDARCHIVO", _P_Str_Archivo);
            parm[3] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            parm[4] = new ReportParameter("CFECHADESDE", _P_Str_Desde);
            parm[5] = new ReportParameter("CFECHAHASTA", _P_Str_Hasta);
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }

        private void _Mtd_Busqueda_6(string _P_Str_CCOMPANY, string _P_Str_CNOMBEEMP, string _P_Str_CPREOC, string _P_Str_CPROVEEDOR, string _P_Str_CPROVDESC, string _P_Str_CFECHA)
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[6];
            parm[0] = new ReportParameter("CCOMPANY", _P_Str_CCOMPANY);
            parm[1] = new ReportParameter("CNOMBEMP", _P_Str_CNOMBEEMP);
            parm[2] = new ReportParameter("CPREOC", _P_Str_CPREOC);
            parm[3] = new ReportParameter("CPROVEEDOR", _P_Str_CPROVEEDOR);
            parm[4] = new ReportParameter("CPROVDESC", _P_Str_CPROVDESC);
            parm[5] = new ReportParameter("CFECHA", _P_Str_CFECHA);
          
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }
        private void _Mtd_Busqueda_9(string _P_Str_Desde, string _P_Str_Hasta)
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[3];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CDESDE", _P_Str_Desde);
            parm[2] = new ReportParameter("CHASTA", _P_Str_Hasta);
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }

        private void _Mtd_Busqueda_10()
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[2];
            parm[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp);
            parm[1] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }
        private void _Mtd_Busqueda_11(string _P_Str_Company)
        {
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[3];
            parm[0] = new ReportParameter("CNOMCOMP", _Mtd_NombComp());
            parm[1] = new ReportParameter("CDIAS", "180");
            parm[2] = new ReportParameter("CCOMPANY", _P_Str_Company);
            _Rpt_Report.ServerReport.SetParameters(parm);
            _Rpt_Report.ServerReport.Refresh();
            _Rpt_Report.RefreshReport();
        }
        private void Frm_Inf_Varios_Load(object sender, EventArgs e)
        {

        }
    }
}