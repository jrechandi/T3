using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_EstatusClientesDetalleCobrosDet : Form
    {
        public Frm_EstatusClientesDetalleCobrosDet()
        {
            InitializeComponent();
        }
        public Frm_EstatusClientesDetalleCobrosDet(string _P_Str_Company, string _P_Str_IdRelaCobro, string _P_Str_Numdocu, string _P_Str_TipoDocument)
        {
            InitializeComponent();
            _Mtd_Actualizar_1(_P_Str_Company, _P_Str_IdRelaCobro, _P_Str_Numdocu, _P_Str_TipoDocument);
            _Mtd_Actualizar_2(_P_Str_Company, _P_Str_IdRelaCobro, _P_Str_Numdocu, _P_Str_TipoDocument);
        }
        private void _Mtd_Actualizar_1(string _P_Str_Company, string _P_Str_IdRelaCobro, string _P_Str_Numdocu, string _P_Str_TipoDocument)
        {
            string _Str_Cadena = "SELECT cbanco AS Banco,ndeposito AS [Nº Depósito],cmontoefectivo AS [Monto Efect.],cnumcheque AS [Nº Cheque],cfechaemision AS [Fecha Emisión],cmontocheque AS [Monto Cheq.] FROM VST_T3_RELACIONDEPOSITOSRESUMEN_2 WHERE cidrelacobro='" + _P_Str_IdRelaCobro + "' AND ccompany='" + _P_Str_Company + "' AND cnumdocu='" + _P_Str_Numdocu + "' AND ctipodocument='" + _P_Str_TipoDocument + "'";
            _Dg_Grid_1.DataSource = Program._MyClsCnn._mtd_conexion_T3WEB_Local._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
            _Dg_Grid_1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid_1.Columns["Fecha Emisión"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid_1.Columns["Monto Efect."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid_1.Columns["Monto Cheq."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void _Mtd_Actualizar_2(string _P_Str_Company, string _P_Str_IdRelaCobro, string _P_Str_Numdocu, string _P_Str_TipoDocument)
        {
            string _Str_Cadena = "SELECT cnumcheque AS Cheque,cbanco AS Banco,cfechaemision AS [Fecha Emisión],cfechadeposito AS [Fecha Depósito],cmonto AS Monto from VST_T3_RELACIONCHEQUESTRANSITORESUMEN_2 WHERE cidrelacobro='" + _P_Str_IdRelaCobro + "' AND ccompany='" + _P_Str_Company + "' AND cnumdocu='" + _P_Str_Numdocu + "' AND ctipodocument='" + _P_Str_TipoDocument + "'";
            _Dg_Grid_2.DataSource = Program._MyClsCnn._mtd_conexion_T3WEB_Local._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
            _Dg_Grid_2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid_2.Columns["Fecha Emisión"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid_2.Columns["Fecha Depósito"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid_2.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void Frm_EstatusClientesDetalleCobrosDet_Load(object sender, EventArgs e)
        {

        }
    }
}
