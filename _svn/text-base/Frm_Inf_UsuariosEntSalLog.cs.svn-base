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
    public partial class Frm_Inf_UsuariosEntSalLog : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_Inf_UsuariosEntSalLog()
        {
            InitializeComponent();
            DateTime _Dt_Fecha = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dtp_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(_Dt_Fecha));
            _Dtp_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(_Dt_Fecha));
            _Dtp_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(_Dt_Fecha));
        }

        private void _Bt_Consultar_Clasif_Click(object sender, EventArgs e)
        {
            _Mtd_Consultar();
        }
        private void _Mtd_Consultar()
        {
            _Rpt_ReportUsers.Reset();
            string _Str_Where = "";
            string _Str_SQL = "SELECT * FROM VST_USERONLINELOG WHERE 1=1";
            if (_Chk_FiltrarFecha.Checked)
            {
                _Str_Where += " AND CONVERT(DATETIME,CONVERT(VARCHAR,CFECHAENTRADA,103)) BETWEEN '" + _Dtp_Desde.Value.ToString("dd/MM/yyyy") + "' AND '" + _Dtp_Hasta.Value.ToString("dd/MM/yyyy") + "'";
            }
            if (_Chk_VerConectados.Checked)
            {
                _Str_Where += " AND MINUTOS ='CONECTADO'";
            }
            _Str_Where+=" AND (CUSER LIKE '%"+_Txt_Usuario.Text.Trim()+"%' OR CNAME LIKE '%"+_Txt_Usuario.Text.Trim()+"%')";
            _Str_Where += " AND (CIP LIKE '%" + _Txt_Ip.Text.Trim() + "%')";
            DataSet _Ds_DataSet = new DataSet();
            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL + _Str_Where);
            Cursor = Cursors.WaitCursor;
            _Rpt_ReportUsers.LocalReport.ReportEmbeddedResource = "T3.ReportServLocal.Rpt_HistorialUsuarios.rdlc";
            _Rpt_ReportUsers.LocalReport.DataSources.Add(new ReportDataSource("DataSetRpt_VST_USERONLINELOG", _Ds_DataSet.Tables[0]));
            _Rpt_ReportUsers.LocalReport.Refresh();
            _Rpt_ReportUsers.RefreshReport();
            Cursor = Cursors.Default;
        }
        private void _Dtp_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dtp_Desde.MaxDate = _Dtp_Hasta.Value;
        }

        private void _Chk_FiltrarFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chk_FiltrarFecha.Checked)
            {
                _Dtp_Desde.Enabled = true;
                _Dtp_Hasta.Enabled = true;
            }
            else
            {
                _Dtp_Desde.Enabled = false;
                _Dtp_Hasta.Enabled = false;
            }
        }
    }
}
