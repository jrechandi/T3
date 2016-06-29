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
    public partial class Frm_Inf_RelacPorCaja : Form
    {
        public Frm_Inf_RelacPorCaja()
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

        private void _Mtd_Buscar()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "Select * from VST_RELACIONES_POR_CAJA where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and ccaja='" + _Txt_Caja.Text.Trim() + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //----------------------
            ReportParameter[] _Param = new ReportParameter[2];
            _Param[0] = new ReportParameter("CNOMBEMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            _Param[1] = new ReportParameter("CCAJA", _Txt_Caja.Text.Trim());
            _Rpt_Report.Reset();
            _Rpt_Report.LocalReport.ReportEmbeddedResource = "T3.ReportServLocal.Rpt_Inf_RelacPorCaja.rdlc";
            _Rpt_Report.LocalReport.SetParameters(_Param);
            _Rpt_Report.LocalReport.DataSources.Add(new ReportDataSource("DataSetRpt_VST_RELACIONES_POR_CAJA", _Ds.Tables[0]));
            _Rpt_Report.LocalReport.Refresh();
            _Rpt_Report.RefreshReport();
            Cursor = Cursors.Default;
        }
    }
}