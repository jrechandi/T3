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
    public partial class Frm_Inf_RecepImprimir : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");

        public Frm_Inf_RecepImprimir()
        {
            InitializeComponent();
            reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_AcumVtaGerArea";
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

        private void _Mtd_LimpiarTodo()
        {
          _Txt_Proveedor.Text = ""; _Txt_Proveedor.Tag = "";
          _Cmb_Fac.Items.Clear();
          _Cmb_NR.DataSource = null;
        }
      

        private void _Bt_Proveedor_Click(object sender, EventArgs e)
        {
            // guarda el valor actual, antes de buscar, para comparar luego si se selecciono algo
            string _Str_ValorAnterior = _Txt_Proveedor.Tag.ToString();

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(33);
            _Frm.ShowDialog();
            if (_Frm._Str_FrmResult == "1")
            {
                _Txt_Proveedor.Text = _Frm._Dg_Grid[1, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().ToUpper();
                _Txt_Proveedor.Tag = _Frm._Dg_Grid[0, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().ToUpper();
            }

            // limpia pedido y recepcion, si es necesario
            if (_Str_ValorAnterior != _Txt_Proveedor.Tag.ToString())
            {
                _Mtd_Cargar_NR(Convert.ToString(_Txt_Proveedor.Tag), _Dt_Desde.Value);
                //_Cmb_NR.Items.Clear();
                _Cmb_Fac.Items.Clear();
            }
        }

        private void Frm_Inf_RecepImprimir_Load(object sender, EventArgs e)
        {
            _Mtd_LimpiarTodo();
        }

   
        private void _Mtd_Cargar_NR(string _P_Str_Proveedor, DateTime _P_Dtm_Desde)
        {
            string _Str_Cadena = "SELECT DISTINCT cidrecepcion, cidnotrecepc FROM TNOTARECEPC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _P_Str_Proveedor + "' AND CONVERT(DATETIME,CONVERT(VARCHAR,cfechanotrecep,103))>=CONVERT(DATETIME,'" + _Cls_Formato._Mtd_fecha(_Dt_Desde.Value) + "') AND ctiponotrecep='C' ORDER BY cidnotrecepc";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_NR, _Str_Cadena);
        }

        private void _Dt_Desde_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(_Txt_Proveedor.Tag).Trim().Length > 0)
            {
                _Mtd_Cargar_NR(Convert.ToString(_Txt_Proveedor.Tag), _Dt_Desde.Value);
            }
        }

        private void _Mtd_LlenarComboFactura(string _P_Str_cproveedor, string _P_Str_cidrecepcion)
        {
            try
            {
                string _Str_Sql;
                _Str_Sql = "SELECT cnfacturapro FROM TRECEPCIONDFM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _P_Str_cidrecepcion + "' and cproveedor='" + _P_Str_cproveedor + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                _Cmb_Fac.Items.Clear();
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Cmb_Fac.Items.Add(_Row[0].ToString());
                }
            }
            catch { }
        }

        private void _Cmb_NR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Txt_Proveedor.Text != "" && _Cmb_NR.Items.Count > 1 && _Cmb_NR.SelectedValue != null) 
                _Mtd_LlenarComboFactura(_Txt_Proveedor.Tag.ToString(), _Cmb_NR.SelectedValue.ToString());
        }

        //private void _Mtd_ImprimirRecepcionVencimiento()
        //{

        //    _Frm_Inf.MdiParent = this.MdiParent;
        //    _Frm_Inf.Dock = DockStyle.Fill;
        //    _Frm_Inf.Show();

        //}

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            if (_Mtd_ValidarParametros())
            {
                //int _P_Int_Sw = 7;
                //string _Str_CGROUPCOMP = Frm_Padre._Str_GroupComp;
                //string _Str_CFACTURA = _Cmb_Fac.Items[_Cmb_Fac.SelectedIndex].ToString();
                //string _Str_CRECEPCION = _Cmb_NR.SelectedValue.ToString();
                //string _Str_CNOMBEMP = _Mtd_NombComp();
                //string _Str_CPROVDESC = _Txt_Proveedor.Text;

                //Frm_Inf_Varios _Frm_Inf = new Frm_Inf_Varios(_P_Int_Sw, _Str_CGROUPCOMP, _Str_CFACTURA, _Str_CRECEPCION, _Str_CNOMBEMP, _Str_CPROVDESC);
                //_Mtd_ImprimirRecepcionVencimiento();
                _Mtd_MostrarReporte();
            }
        }

        private bool _Mtd_ValidarParametros()
        {
            // switch de validacion, está por omision en true, y si alguna de las validaciones se dispara, el switch se vuelve false
            bool _Boo_Valido = true;
            _Er_Error.Dispose();

            // si se selecciona el radio de mes y año, entonces tiene que seleccinar un mes y un año
            if (_Txt_Proveedor.Text.Trim() == "")
            {
                _Boo_Valido = false;
                MessageBox.Show("Seleccione un proveedor", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return _Boo_Valido;
            }

            if (_Cmb_NR.SelectedIndex < 1)
            {
                _Boo_Valido = false;
                MessageBox.Show("Seleccione una NR", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return _Boo_Valido;
            }

            if (_Cmb_Fac.SelectedIndex < 0)
            {
                _Boo_Valido = false;
                MessageBox.Show("Seleccione una factura", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return _Boo_Valido;
            }

            return _Boo_Valido;

        }

        //private void _Mtd_MostrarReporte()
        //{
        //    int _P_Int_Sw = 7;
        //    string _Str_CGROUPCOMP = Frm_Padre._Str_GroupComp;
        //    string _Str_CFACTURA = _Cmb_Fac.Items[_Cmb_Fac.SelectedIndex].ToString();
        //    string _Str_CRECEPCION = _Cmb_NR.SelectedValue.ToString();
        //    string _Str_CNOMBEMP = _Mtd_NombComp();
        //    string _Str_CPROVDESC = _Txt_Proveedor.Text;

        //    InitializeComponent();
        //    _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
        //    if (_P_Int_Sw == 7)
        //    {
        //        _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_RecepcionImprimir";
        //        _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
                
        //        ReportParameter[] parm = new ReportParameter[5];
        //        parm[0] = new ReportParameter("CGROUPCOMP", _Str_CGROUPCOMP);
        //        parm[1] = new ReportParameter("CFACTURA",   _Str_CFACTURA);
        //        parm[2] = new ReportParameter("CRECEPCION", _Str_CRECEPCION);
        //        parm[3] = new ReportParameter("CNOMBEMP",   _Str_CNOMBEMP);
        //        parm[4] = new ReportParameter("CPROVDESC",  _Str_CPROVDESC);
                
        //        _Rpt_Report.ServerReport.SetParameters(parm);
        //        _Rpt_Report.ServerReport.Refresh();
        //        _Rpt_Report.RefreshReport();

        //        //this.Text = "Recepción de mercancía";
        //    }
        //}

        private void _Mtd_MostrarReporte()
        {
            string _Str_NombreLogicoReporte = "Rpt_RecepcionImprimir";

            string _Str_CGROUPCOMP = Frm_Padre._Str_GroupComp;
            string _Str_CFACTURA = _Cmb_Fac.Items[_Cmb_Fac.SelectedIndex].ToString();
            string _Str_CRECEPCION = _Cmb_NR.SelectedValue.ToString();
            string _Str_CNOMBEMP = _Mtd_NombComp();
            string _Str_CPROVDESC = _Txt_Proveedor.Text;

            reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);

            ReportParameter[] parm = new ReportParameter[5];
            parm[0] = new ReportParameter("CGROUPCOMP", _Str_CGROUPCOMP);
            parm[1] = new ReportParameter("CFACTURA", _Str_CFACTURA);
            parm[2] = new ReportParameter("CRECEPCION", _Str_CRECEPCION);
            parm[3] = new ReportParameter("CNOMBEMP", _Str_CNOMBEMP);
            parm[4] = new ReportParameter("CPROVDESC", _Str_CPROVDESC);

            reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + _Str_NombreLogicoReporte;
            reportViewer1.ServerReport.SetParameters(parm);
            this.reportViewer1.ServerReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void _Bt_LimpiarProveedor_Click(object sender, EventArgs e)
        {
            //_Cmb_NR.Items.Clear;
            //_Cmb_Fac.Items.Clear;
            //_Txt_Proveedor.Text = "";
            //_Txt_Proveedor.Tag = "";
            _Mtd_LimpiarTodo();
        }
 
    }
}