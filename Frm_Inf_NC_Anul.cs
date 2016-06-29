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
    public partial class Frm_Inf_NC_Anul : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_NC_Anul()
        {
            InitializeComponent();
            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
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
            string _Str_Sql = "SELECT * FROM VST_NOTACREDITOANUL WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'";
            if (_Rb_Cliente.Checked && _Cb_Cliente.SelectedIndex > 0)
            {
                _Str_Sql = _Str_Sql + " AND ccliente='" + _Cb_Cliente.SelectedValue.ToString() + "'";
            }
            if (_Rb_Vendedor.Checked && _Cb_Vendedor.SelectedIndex > 0)
            {
                _Str_Sql = _Str_Sql + " AND cvendedor='" + _Cb_Vendedor.SelectedValue.ToString() + "'";
            }
            if (_Rb_Motivo.Checked && _Cb_Motivo.SelectedIndex > 0)
            {
              _Str_Sql = _Str_Sql + " AND Codcidmotivo='" + _Cb_Motivo.SelectedValue.ToString() + "'";
            }
            _Str_Sql = _Str_Sql + " AND convert(datetime,convert(varchar(255),cfechaanul,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dt_Desde.Value) + "' AND '" + _Cls_Formato._Mtd_fecha(_Dt_Hasta.Value) + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                Report.rInfNotaCredAnul _My_Reporte = new T3.Report.rInfNotaCredAnul();
                _My_Reporte.SetDataSource(_Ds.Tables[0]);

                Section _sec = _My_Reporte.ReportDefinition.Sections["Section2"];
                TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
                tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
                TextObject tex2 = _sec.ReportObjects["txt_desde_hasta"] as TextObject;
                tex2.Text = "DESDE " + _Cls_Formato._Mtd_fecha(_Dt_Desde.Value.Date) + " AL " + _Cls_Formato._Mtd_fecha(_Dt_Hasta.Value.Date);
                TextObject tex3 = _sec.ReportObjects["txt_titulo"] as TextObject;
                tex3.Text = "NOTAS DE CRÉDITO ANULADAS";
                this._Rpv_Main.ReportSource = _My_Reporte;
                _Rpv_Main.RefreshReport();
            }
            else
            {
                this._Rpv_Main.ReportSource = null;
                MessageBox.Show("No existen Notas de Crédito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Frm_NC_Anul_Load(object sender, EventArgs e)
        {

        }

        private void _Dt_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dt_Desde.MaxDate = _Dt_Hasta.Value;
        }

        private void _Lkbl_Ayer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())).AddDays(-1);
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())).AddDays(-1);
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())).AddDays(-1);
        }

        private void _Lkbl_Hoy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
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

        private void _Rb_Motivo_CheckedChanged(object sender, EventArgs e)
        {
          if (_Rb_Motivo.Checked)
          {
            _Cb_Motivo.Enabled = true;
          }
          else
          {
            _Cb_Motivo.SelectedIndex = -1;
            _Cb_Motivo.Enabled = false;
          }
        }

        private void _Cb_Motivo_DropDown(object sender, EventArgs e)
        {
          this.Cursor = Cursors.WaitCursor;
          _Mtd_CargarMotivos();
          this.Cursor = Cursors.Default;
        }

        private void _Mtd_CargarMotivos()
        {
          string _Str_Sql = "SELECT RTRIM(cidmotivo) as cidmotivo,RTRIM(cidmotivo) + ' - ' + RTRIM(cdescripcion) AS cdescripcion FROM TMOTIVO where cmotianulnccxc='1' ORDER BY CAST(RTRIM(cidmotivo) AS NUMERIC) ASC";
          _myUtilidad._Mtd_CargarCombo(_Cb_Motivo, _Str_Sql);
        }

    }
}