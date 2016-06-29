using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
namespace T3
{
    public partial class Frm_Inf_CheqDev : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_CheqDev()
        {
            InitializeComponent();
            _Rb_SinFiltro.Checked = true;
        }
        private void _Mtd_CargarClientes()
        {
            string _Str_Sql = "SELECT ccliente,CONVERT(VARCHAR,ccliente) + '-' + RTRIM(c_nomb_comer) FROM TCLIENTE WHERE cdelete=0 AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
            _myUtilidad._Mtd_CargarCombo(_Cb_Cliente, _Str_Sql);
        }
        private void _Mtd_CargarVendedores()
        {
            string _Str_Sql = "SELECT cvendedor,RTRIM(cvendedor) + '-' + RTRIM(cname) FROM TVENDEDOR WHERE cdelete=0 AND ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY CONVERT(NUMERIC(18,0),REPLACE(REPLACE(CVENDEDOR,'_',''),RTRIM(CCOMPANY),''))";
            _myUtilidad._Mtd_CargarCombo(_Cb_Vendedor, _Str_Sql);
        }
        private void _Mtd_Busqueda()
        {
            string _Str_Sql = "SELECT * FROM VST_INF_CHEQDEV WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cactivo=1 AND cdelete=0 AND csaldofactura>0";
            if (_Rb_Cliente.Checked && _Cb_Cliente.SelectedIndex > 0)
            {
                _Str_Sql = _Str_Sql + " AND ccliente='" + _Cb_Cliente.SelectedValue.ToString() + "'";
            }
            if (_Rb_Vendedor.Checked && _Cb_Vendedor.SelectedIndex > 0)
            {
                _Str_Sql = _Str_Sql + " AND cvendedor='" + _Cb_Vendedor.SelectedValue.ToString() + "'";
            }
            //_Str_Sql = _Str_Sql + " AND convert(datetime,convert(varchar(255),cfechaemision,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dt_Desde.Value) + "' AND '" + _Cls_Formato._Mtd_fecha(_Dt_Hasta.Value) + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                Report.rInfCheqDev _My_Reporte = new T3.Report.rInfCheqDev();
                _My_Reporte.SetDataSource(_Ds.Tables[0]);

                Section _sec = _My_Reporte.ReportDefinition.Sections["Section2"];
                TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                //TextObject tex2 = _sec.ReportObjects["txt_desde_hasta"] as TextObject;
                //tex2.Text = "DESDE " + _Cls_Formato._Mtd_fecha(_Dt_Desde.Value.Date) + " AL " + _Cls_Formato._Mtd_fecha(_Dt_Hasta.Value.Date);
                TextObject tex3 = _sec.ReportObjects["txt_titulo"] as TextObject;
                tex3.Text = "RELACIÓN DE CHEQUES DEVUELTOS";
                this._Rpv_Main.ReportSource = _My_Reporte;
                _Rpv_Main.RefreshReport();
            }
            else
            {
                this._Rpv_Main.ReportSource = null;
                MessageBox.Show("No existen Cheques Devueltos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Frm_Inf_CheqDev_Load(object sender, EventArgs e)
        {

        }

        private void _Rb_Cliente_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Cliente.Checked)
            {
                _Cb_Cliente.Enabled = true;
            }
            else
            {
                _Cb_Cliente.SelectedIndex = -1;
                _Cb_Cliente.Enabled = false;
            }
        }

        private void _Rb_Vendedor_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Vendedor.Checked)
            {
                _Cb_Vendedor.Enabled = true;
            }
            else
            {
                _Cb_Vendedor.SelectedIndex = -1;
                _Cb_Vendedor.Enabled = false;
            }
        }

        private void _Rb_SinFiltro_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_SinFiltro.Checked)
            {
                _Cb_Cliente.Enabled = false;
                _Cb_Vendedor.Enabled = false;
            }
        }

        private void _Cb_Cliente_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_CargarClientes();
            this.Cursor = Cursors.Default;
        }

        private void _Cb_Vendedor_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_CargarVendedores();
            this.Cursor = Cursors.Default;
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_Busqueda();
            this.Cursor = Cursors.Default;
        }
    }
}