using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Threading;
namespace T3
{
    public partial class Frm_Inf_CobranDetalladaCaja : Form
    {

        public DataSet _Ds_ExportarReporte;
        
        public Frm_Inf_CobranDetalladaCaja()
        {
            InitializeComponent();
        }

        private void _Bt_Caja_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(52, _Txt_Caja, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
        }
        private void _Mtd_Buscar()
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "EXEC PA_INF_COBRAN_DETALLADA_CAJA '" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "','" + _Txt_Caja.Text + "','" + _Txt_Caja.Text + "'";
            if (_Txt_Caja_2.Text.Trim().Length > 0)
            { _Str_Cadena = "EXEC PA_INF_COBRAN_DETALLADA_CAJA '" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "','" + _Txt_Caja.Text + "','" + _Txt_Caja_2.Text + "'"; }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            Report.rCajaCobDet _MyReport = new T3.Report.rCajaCobDet();
            _MyReport.SetDataSource(_Ds.Tables[0]);
            Section _sec = _MyReport.ReportDefinition.Sections["Section2"];
            FieldObject _Fiel = _sec.ReportObjects["ccaja1"] as FieldObject;
            _Fiel.Width = 0;
            TextObject tex1 = _sec.ReportObjects["cabecera"] as TextObject;
            tex1.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT rtrim(cname) FROM TCOMPANY WHERE ccompany='" + Frm_Padre._Str_Comp + "'").Tables[0].Rows[0][0].ToString();
            tex1 = _sec.ReportObjects["Text12"] as TextObject;
            tex1.Text = _Txt_Caja.Text + " a la " + _Txt_Caja.Text;
            if (_Txt_Caja_2.Text.Trim().Length > 0)
            { tex1.Text = _Txt_Caja.Text + " a la " + _Txt_Caja_2.Text; }
            _Rpv_Main.ReportSource = _MyReport;
            _Rpv_Main.RefreshReport();
        }

        private void _Mtd_ExportarReporte()
        {
            //this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "EXEC PA_INF_COBRAN_DETALLADA_CAJA_EXPORTAR '" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "','" + _Txt_Caja.Text + "','" + _Txt_Caja.Text + "'";
            if (_Txt_Caja_2.Text.Trim().Length > 0)
            { _Str_Cadena = "EXEC PA_INF_COBRAN_DETALLADA_CAJA_EXPORTAR '" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "','" + _Txt_Caja.Text + "','" + _Txt_Caja_2.Text + "'"; }


            try
            {
                _Ds_ExportarReporte = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

                if (_Sfd_1.ShowDialog() == DialogResult.OK)
                {
                    
                    Thread _Thr_Thread = new Thread(new ThreadStart(_Mtd_ExportarReporteProcesoExcel));
                    _Thr_Thread.Start();
                    while (!_Thr_Thread.IsAlive) ;
                    Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread, "Espere por favor...");
                    _Frm_Form.ShowDialog(this);
                    _Frm_Form.Dispose();
                    
                }
            }
            catch 
            { 
                //Cursor = Cursors.Default; 
                MessageBox.Show("Error al intentar exportar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
        
        }

        private void _Mtd_ExportarReporteProcesoExcel()
        {
            Clases._Cls_ExcelUtilidades _MyExcel = new T3.Clases._Cls_ExcelUtilidades();
            _MyExcel._Mtd_DatasetToExcel(_Ds_ExportarReporte.Tables[0], _Sfd_1.FileName, "COB_DET_CAJA_" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString());
            _MyExcel = null;
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            if (_Txt_Caja.Text.Trim().Length > 0)
            {
                _Er_Error.Dispose();
                Cursor = Cursors.WaitCursor;
                _Mtd_Buscar();
                Cursor = Cursors.Default;
            }
            else
            { _Er_Error.SetError(_Bt_Caja, "Información requerida!!!"); }
        }

        private void Frm_Inf_AnalisisSaldoCajaAnt_Load(object sender, EventArgs e)
        {

        }

        private void _Bt_Caja_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(52, _Txt_Caja, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
            this._Rpv_Main.ReportSource = null;
            _Txt_Caja_2.Text = _Txt_Caja.Text;
        }

        private void _Bt_Caja_2_Click(object sender, EventArgs e)
        {
            if (_Txt_Caja.Text.Trim().Length > 0)
            {
                Cursor = Cursors.WaitCursor;
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(52, _Txt_Caja_2, 0, " AND convert(numeric(18,0),ccaja)>" + _Txt_Caja.Text.Trim());
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe ingresar datos en 'Caja Desde'.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Bt_Limpiar_Click(object sender, EventArgs e)
        {
            _Txt_Caja_2.Text = "";
        }

        private void _Bt_Exportar_Click(object sender, EventArgs e)
        {
            if (_Txt_Caja.Text.Trim().Length > 0)
            {
                _Er_Error.Dispose();
                Cursor = Cursors.WaitCursor;
                _Mtd_ExportarReporte();
                Cursor = Cursors.Default;
            }
            else
            { _Er_Error.SetError(_Bt_Caja, "Información requerida!!!"); }
        }
    }
}