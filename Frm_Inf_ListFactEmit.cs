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
    public partial class Frm_Inf_ListFactEmit : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_ListFactEmit()
        {
            InitializeComponent();
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private void _Mtd_Buscar()
        {
            string _Str_Sql = "SELECT cgroupcomp,  TCOMPANY.crif AS ccompany, ccompanyname, ccompanynamel, cguiadesp, cprecarga, cfactura, cpfactura, cpedido, ccliente, ccliente_rif, fecha_max_fact, fecha_min_fact, ccliente_nit, ccliente_namecomerc, cvendedor, c_fecha_pedido, c_fecha_factura, cfpago, cfpago_name, c_montotot_si_bs, c_impuesto_bs, c_total, c_fact_anul, c_ped_obs, c_fact_obs, c_estatus_cob, c_obs_cob, c_impresa, c_direcc_despa, c_factdevuelta, c_entregacliente, c_dia_ruta FROM VST_REPORTE_LISTADOFACTURAS INNER JOIN TCOMPANY ON VST_REPORTE_LISTADOFACTURAS.ccompany=TCOMPANY.ccompany WHERE " + CLASES._Cls_Varios_Metodos._Mtd_SQL_Comp().Replace("ccompany", "VST_REPORTE_LISTADOFACTURAS.ccompany") + " AND cguiadesp='" + _Txt_Guia.Text + "' ORDER BY cfactura";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            Report.rFacturasEmitidas2 _My_Reporte = new T3.Report.rFacturasEmitidas2();
            _My_Reporte.SetDataSource(_Ds.Tables[0]);
            this._Rpv_Main.ReportSource = _My_Reporte;
            _Rpv_Main.RefreshReport();
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            if (_Txt_Guia.Text.Trim().Length > 0)
            {
                _Er_Error.Dispose();
                Cursor = Cursors.WaitCursor;
                _Mtd_Buscar();
                Cursor = Cursors.Default;
            }
            else
            { _Er_Error.SetError(_Txt_Guia, "Información requerida!!!"); }
        }

        private void _Txt_Guia_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Guia.Text))
            {
                _Txt_Guia.Text = "";
            }
        }

        private void _Txt_Guia_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Guia, e, 10, 0);
        }

        private void Frm_Inf_listFactEmit_Load(object sender, EventArgs e)
        {

        }
    }
}