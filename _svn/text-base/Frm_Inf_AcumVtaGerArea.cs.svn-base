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
    public partial class Frm_Inf_AcumVtaGerArea : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Inf_AcumVtaGerArea()
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
        private void _Mtd_Busqueda()
        {
            reportViewer1.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            ReportParameter[] parm = new ReportParameter[4];
            parm[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            parm[1] = new ReportParameter("CFECHAI", _Ctrl_ConsultaMes1._Str_FechaInicio);
            parm[2] = new ReportParameter("CFECHAF", _Ctrl_ConsultaMes1._Str_FechaFinal);
            if (_Cb_Gerente.SelectedIndex > 0)
            {
                parm[3] = new ReportParameter("CGERAREA", _Cb_Gerente.SelectedValue.ToString());
            }
            else
            {
                parm[3] = new ReportParameter("CGERAREA", "NULL");
            }
            reportViewer1.ServerReport.SetParameters(parm);
            this.reportViewer1.ServerReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void _Mtd_CargarGerentes()
        {
            string _Str_Sql="";
            if (!_Ctrl_ConsultaMes1._Bol_Listo)
            {
                _Str_Sql = "SELECT cvendedor,cname from TVENDEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and c_activo='1' and c_tipo_vend='2'";
            }
            else{
                _Str_Sql = "SELECT cvendedor,cname from TVENDEDOR where (ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and c_activo='1' and c_tipo_vend='2') OR (ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and c_activo='0' and c_tipo_vend='2' AND cfechainact<'" + _Ctrl_ConsultaMes1._Str_FechaFinal+ "')";
            }

            _myUtilidad._Mtd_CargarCombo(_Cb_Gerente, _Str_Sql, true);
        }
        private void Frm_Inf_AcumVtaGerArea_Load(object sender, EventArgs e)
        {
            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();
        }

        private void _Rbt_VGer_CheckedChanged(object sender, EventArgs e)
        {
            _Mtd_CargarGerentes();
            _Cb_Gerente.Enabled = true;
            reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_AcumVtaGerArea";
        }

        private void _Rbt_V_CheckedChanged(object sender, EventArgs e)
        {
            _Mtd_CargarGerentes();
            _Cb_Gerente.Enabled = true;
            reportViewer1.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_AcumVtaGerAreaVen";
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Ctrl_ConsultaMes1._Bol_Listo)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Busqueda();
                Cursor = Cursors.Default;
                //if (_Rbt_VGer.Checked & _Cb_Gerente.SelectedIndex > 0)
                //{
                //    Cursor = Cursors.WaitCursor;
                //    _Mtd_Busqueda();
                //    Cursor = Cursors.Default;
                //}
                //if(_Rbt_V.Checked)
                //{
                //    Cursor = Cursors.WaitCursor;
                //    _Mtd_Busqueda();
                //    Cursor = Cursors.Default;
                //}
                //else if (_Rbt_VGer.Checked & _Cb_Gerente.SelectedIndex <= 0)
                //{ _Er_Error.SetError(_Cb_Gerente, "Información requerida."); }
                //else
                //{ _Mtd_Busqueda(); }
            }
            else
            { MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Cb_Cliente_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarGerentes();
        }
    }
}