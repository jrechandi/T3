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
    public partial class Frm_Inf_FacturaDespachar : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_FacturaDespachar()
        {
            InitializeComponent();
        }

        private void _Lkbl_Hoy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Dt_Desde.MaxDate =Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
        }

        private void _Lkbl_Ayer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Dt_Desde.MaxDate =Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().AddDays(-1)));
            _Dt_Desde.Value =Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().AddDays(-1)));
            _Dt_Hasta.Value =Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().AddDays(-1)));
        }

        private void _Dt_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dt_Desde.MaxDate = _Dt_Hasta.Value;
        }

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "", _Str_Filtro = " cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND c_fact_anul='0' AND cpfactura>0 AND (cimprimeguiadesp=0 or (cliqguidespacho=0 OR cliqguidespacho IS NULL))";
            if (_Rb_FactImpresa.Checked)
            {
                _Str_Filtro = _Str_Filtro + " AND c_impresa=1";
            }
            else if (_Rb_FactNoImpresa.Checked)
            {
                _Str_Filtro = _Str_Filtro + " AND c_impresa=0";
            }
            if (!_Rb_Todas.Checked)
            { _Str_Filtro = _Str_Filtro + " AND convert(datetime,convert(varchar(255),c_fecha_factura,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dt_Desde.Value) + "' AND '" + _Cls_Formato._Mtd_fecha(_Dt_Hasta.Value) + "'"; }
            _Str_Sql = "SELECT * FROM VST_FACTURAM WHERE" + _Str_Filtro;
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                Report.rFactura _My_Reporte = new T3.Report.rFactura();
                _My_Reporte.SetDataSource(_Ds.Tables[0]);

                Section _sec = _My_Reporte.ReportDefinition.Sections["Section2"];
                TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();

                TextObject tex2 = _sec.ReportObjects["Txt_Rango"] as TextObject;
                if (_Rb_Todas.Checked)
                { tex2.Text = "TODAS"; }
                else
                { tex2.Text = "Del: " + _Cls_Formato._Mtd_fecha(_Dt_Desde.Value.Date) + " al " + _Cls_Formato._Mtd_fecha(_Dt_Hasta.Value.Date); }
                this._Rpv_Main.ReportSource = _My_Reporte;
                _Rpv_Main.RefreshReport();
            }
            else
            {
                this._Rpv_Main.ReportSource = null;
                MessageBox.Show("No existen Facturas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Cursor = Cursors.Default;
        }

        private void Frm_Inf_FacturaDespachar_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Dt_Desde.MaxDate =Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
        }

        private void _Rb_Todas_CheckedChanged(object sender, EventArgs e)
        {
            _Dt_Desde.Enabled = !_Rb_Todas.Checked;
            _Dt_Hasta.Enabled = !_Rb_Todas.Checked;
            _Lkbl_Ayer.Enabled = !_Rb_Todas.Checked;
            _Lkbl_Hoy.Enabled = !_Rb_Todas.Checked;
        }
    }
}