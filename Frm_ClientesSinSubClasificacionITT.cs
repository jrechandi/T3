using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ClientesSinSubClasificacionITT : Form
    {
        string _G_Str_SentenciaSQL;
        DataSet _G_Ds_DataSet;
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_ClientesSinSubClasificacionITT()
        {
            InitializeComponent();
        }

        private void _Btn_Consultar_Click(object sender, EventArgs e)
        {
            _Mtd_Consulta();
        }
        private void _Mtd_Consulta()
        {
            Cursor = Cursors.WaitCursor;
            if (_Rbt_PorCodigoCliente.Checked)
            {
                if (_Txt_CodCliente.Text.Length > 0)
                {
                    _G_Str_SentenciaSQL = "SELECT TCLIENTE.CCLIENTE as [Cód. Cliente],TCLIENTE.c_nomb_comer AS [Descripción],TCLIENTE.C_ESTABLE,TTESTABLECIM.cname FROM TCLIENTE INNER JOIN TTESTABLECIM ON TCLIENTE.c_estable = TTESTABLECIM.ctestablecim WHERE TCLIENTE.CGROUPCOMP='" + Frm_Padre._Str_GroupComp + "' AND TCLIENTE.CCLIENTE LIKE '%" + _Txt_CodCliente.Text + "%'";
                }
                else
                {
                    MessageBox.Show("Ingrese el código del cliente por favor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _G_Str_SentenciaSQL = "";
                }
            }
            else
            {
                _G_Str_SentenciaSQL = "SELECT DISTINCT TCLIENTE.CCLIENTE as [Cód. Cliente],TCLIENTE.c_nomb_comer AS [Descripción],TCLIENTE.C_ESTABLE,TTESTABLECIM.cname FROM TMOVINVENTAS INNER JOIN TCLIENTE ON TMOVINVENTAS.ccliente = TCLIENTE.ccliente INNER JOIN TGROUPCOMPANYD ON TCLIENTE.cgroupcomp = TGROUPCOMPANYD.cgroupcomp AND TMOVINVENTAS.ccompany = TGROUPCOMPANYD.ccompany INNER JOIN TTESTABLECIM ON TCLIENTE.c_estable = TTESTABLECIM.ctestablecim WHERE TMOVINVENTAS.CCOMPANY='" + Frm_Padre._Str_Comp + "' AND TMOVINVENTAS.CDATEMOV BETWEEN '" + _Dtp_FechaDesde.Value.ToString("dd/MM/yyyy") + "' AND '" + _Dtp_FechaHasta.Value.ToString("dd/MM/yyyy") + "' AND TMOVINVENTAS.CPRODUCTO LIKE '01%' AND NOT EXISTS(SELECT CCLIENTE FROM TCLIENTECUSTOMERSEGITT WHERE CCLIENTE=TMOVINVENTAS.CCLIENTE)";
                _G_Str_SentenciaSQL += " UNION ";
                _G_Str_SentenciaSQL += "SELECT DISTINCT TCLIENTE.CCLIENTE as [Cód. Cliente],TCLIENTE.c_nomb_comer AS [Descripción],TCLIENTE.C_ESTABLE,TTESTABLECIM.cname FROM TMOVINVENTAS INNER JOIN TCLIENTE ON TMOVINVENTAS.ccliente = TCLIENTE.ccliente INNER JOIN TCLIENTECUSTOMERSEGITT ON TCLIENTECUSTOMERSEGITT.CCLIENTE=TCLIENTE.CCLIENTE AND TCLIENTECUSTOMERSEGITT.CGROUPCOMP=TCLIENTE.CGROUPCOMP INNER JOIN TGROUPCOMPANYD ON TCLIENTE.cgroupcomp = TGROUPCOMPANYD.cgroupcomp AND TMOVINVENTAS.ccompany = TGROUPCOMPANYD.ccompany INNER JOIN TTESTABLECIM ON TCLIENTE.c_estable = TTESTABLECIM.ctestablecim WHERE TMOVINVENTAS.CCOMPANY='" + Frm_Padre._Str_Comp + "' AND TMOVINVENTAS.CDATEMOV BETWEEN '" + _Dtp_FechaDesde.Value.ToString("dd/MM/yyyy") + "' AND '" + _Dtp_FechaHasta.Value.ToString("dd/MM/yyyy") + "' AND TMOVINVENTAS.CPRODUCTO LIKE '01%' AND NOT EXISTS(SELECT caccounttype FROM TITTCUSTOMERSEGMENT WHERE (caccounttype = TCLIENTECUSTOMERSEGITT.caccounttype) AND (ccustomersegment = TCLIENTECUSTOMERSEGITT.ccustomersegment))";
                _G_Str_SentenciaSQL += " UNION ";
                _G_Str_SentenciaSQL += "SELECT DISTINCT CCLIENTE as [Cód. Cliente],c_nomb_comer AS [Descripción],C_ESTABLE,cname FROM VST_T3_CLIENTESITTNOCHAIN WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CDATEMOV BETWEEN '" + _Dtp_FechaDesde.Value.ToString("dd/MM/yyyy") + "' AND '" + _Dtp_FechaHasta.Value.ToString("dd/MM/yyyy") + "'";
            }
            if (_G_Str_SentenciaSQL.Length > 0)
            {
                _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
                _Dg_Grid.DataSource = _G_Ds_DataSet.Tables[0];
                _Dg_Grid.Columns["C_ESTABLE"].Visible = false;
                _Dg_Grid.Columns["cname"].Visible = false;
                _Dg_Grid.Columns["Descripción"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;                
            }
            Cursor = Cursors.Default;
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.Rows.Count > 0)
            {                
                Frm_SubClasificacionColgate _Frm_Form = new Frm_SubClasificacionColgate(_Dg_Grid.Rows[e.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[e.RowIndex].Cells[2].Value.ToString(), _Dg_Grid.Rows[e.RowIndex].Cells[3].Value.ToString(), _Dg_Grid.Rows[e.RowIndex].Cells[1].Value.ToString());
                _Frm_Form.StartPosition = FormStartPosition.CenterScreen;
                _Frm_Form.ShowDialog();
                _Mtd_Consulta();
            }
        }

        private void _Dtp_FechaDesde_ValueChanged(object sender, EventArgs e)
        {
            _Dtp_FechaHasta.MinDate = _Dtp_FechaDesde.Value;
        }

        private void _Dtp_FechaHasta_ValueChanged(object sender, EventArgs e)
        {
            _Dtp_FechaDesde.MaxDate = _Dtp_FechaHasta.Value;
        }

        private void _Rbt_PorFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_PorFecha.Checked)
            {
                _Pnl_PorCliente.Visible = false;
                _Pnl_PorFecha.Visible = true;
                _Txt_CodCliente.Text = "";
            }
        }

        private void _Rbt_PorCodigoCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_PorCodigoCliente.Checked)
            {
                _Pnl_PorCliente.Visible = true;
                _Pnl_PorFecha.Visible = false;
                _Txt_CodCliente.Text = "";
            }
        }

        private void _Txt_CodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            _myUtilidad._Mtd_Valida_Numeros(_Txt_CodCliente, e, 15, 2);
        }

        private void _Txt_CodCliente_TextChanged(object sender, EventArgs e)
        {
            if (!_myUtilidad._Mtd_IsNumeric(_Txt_CodCliente.Text)) { _Txt_CodCliente.Text = ""; }
        }
    }
}
