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
    public partial class Frm_Inf_RotInv : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_RotInv()
        {
            InitializeComponent();
            _Mtd_CargarProvee();
            _Rpt_Report.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_RotInvDet";
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

        private void _Txt_Dias_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Dias, e, 10, 0);
        }

        private void _Mtd_Busqueda()
        {
            ReportParameter[] parm = new ReportParameter[4];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CNOMBEMP", _Mtd_NombComp());
            parm[2] = new ReportParameter("CDIA", _Txt_Dias.Text);
            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                parm[3] = new ReportParameter("CPROVEEDOR", _Cmb_Proveedor.SelectedValue.ToString());
            }
            else
            {
                parm[3] = new ReportParameter("CPROVEEDOR","NULL");
            }            
            _Rpt_Report.ServerReport.SetParameters(parm);
            this._Rpt_Report.ServerReport.Refresh();
            this._Rpt_Report.RefreshReport();
        }
        private void _Mtd_CargarProvee()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor =TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1'";
            _Str_Cadena += " AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "' AND cglobal='1'";
            _Str_Cadena += " ORDER BY TPROVEEDOR.c_nomb_abreviado";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Proveedor, _Str_Cadena,true);
            Cursor = Cursors.Default;
        }
        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (MessageBox.Show("La consulta puede tardar unos minutos en ejecutarse, ¿Desea realizarla?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_Txt_Dias.Text.Trim().Length > 0)
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_Busqueda();
                    Cursor = Cursors.Default;
                }
                else
                {
                    _Er_Error.SetError(_Txt_Dias, "Información requerida.");
                }
            }
        }

        private void _Rbt_L_Det_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_L_Det.Checked)
            {
                _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_RotInvDet";
            }
            else
            {
                _Rpt_Report.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_RotInvRes";
            }
        }

        private void _Cmb_Proveedor_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarProvee();
        }
    }
}