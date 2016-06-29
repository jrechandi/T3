using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ChequesEmit : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_ChequesEmit()
        {
            InitializeComponent();
            _Mtd_CargarBanco();
        }
        private void _Mtd_Color_Estandar(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Color_Estandar(_Ctrl);
                }
                new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco();
            }
        }
        private void _Mtd_Sorted(DataGridView _P_Dg_Grid)
        {
            for (int _Int_i = 0; _Int_i < _P_Dg_Grid.Columns.Count; _Int_i++)
            {
                _P_Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void _Mtd_CargarBanco()
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT DISTINCT LTRIM(RTRIM(TBANCO.cbanco)),TBANCO.cname FROM TBANCO INNER JOIN " +
            "TCUENTBANC ON TBANCO.ccompany = TCUENTBANC.ccompany AND TBANCO.cbanco = TCUENTBANC.cbanco WHERE TBANCO.ccompany='" + Frm_Padre._Str_Comp + "' and TBANCO.cdelete=0";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Banco, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_CargarCuentas(string _P_Str_Banco)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT cnumcuenta,cname FROM TCUENTBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cbanco='" + _P_Str_Banco + "' and cdelete=0";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Cuenta, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_Restablecer()
        {
            _Dg_Grid.DataSource = null;
            _Mtd_CargarBanco();
            _Txt_Cheque.Text = "";
            _Txt_Concepto.Text = "";
            _Txt_Beneficiario.Text = "";
            _Cmb_Banco.Focus();
        }
        private void _Mtd_Actualizar()
        {
            string _Str_Cadena = "SELECT cnumcheqtransac AS [Cheque/Transf], cfpago AS Tipo, cname AS Banco, cnumcuentad AS Cuenta, dbo.Fnc_Formatear(cmontototal) AS Monto,cconcepto AS Concepto,cbeneficiario AS Beneficiario,cidemisioncheq FROM VST_CHEQUES_EMITIDOS WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cimpimiocheq='1' AND canulado='0'";
            if (_Cmb_Banco.SelectedIndex > 0)
            { _Str_Cadena += " AND cbanco='" + Convert.ToString(_Cmb_Banco.SelectedValue).Trim() + "'"; }
            if (_Cmb_Cuenta.SelectedIndex > 0)
            { _Str_Cadena += " AND cnumcuentad='" + Convert.ToString(_Cmb_Cuenta.SelectedValue).Trim() + "'"; }
            if (_Txt_Cheque.Text.Trim().Length > 0)
            { _Str_Cadena += " AND cnumcheqtransac LIKE '%" + _Txt_Cheque.Text.Trim() + "%'"; }
            if (_Txt_Concepto.Text.Trim().Length > 0)
            { _Str_Cadena += " AND cconcepto LIKE '%" + _Txt_Concepto.Text.Trim() + "%'"; }
            if (_Txt_Beneficiario.Text.Trim().Length > 0)
            { _Str_Cadena += " AND cbeneficiario LIKE '%" + _Txt_Beneficiario.Text.Trim() + "%'"; }
            if (_Chk_Fecha.Checked)
            { _Str_Cadena += " AND CONVERT(DATETIME,CONVERT(VARCHAR,cfechaemision,103)) BETWEEN '" + _Ctrl_ConsultaMes1._Str_FechaInicio + "' AND '" + _Ctrl_ConsultaMes1._Str_FechaFinal + "'"; }
            _Str_Cadena += " ORDER BY cnumcheqtransac ASC";
            _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
            _Dg_Grid.Columns[7].Visible = false;
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void Frm_ChequesEmit_Load(object sender, EventArgs e)
        {
            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();
            _Mtd_Color_Estandar(this);
            _Mtd_Sorted(_Dg_Grid);
        }

        private void _Chk_Fecha_CheckedChanged(object sender, EventArgs e)
        {
            _Ctrl_ConsultaMes1.Enabled = _Chk_Fecha.Checked;
        }

        private void _Txt_Cheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Cheque, e, 18, 0);
        }

        private void _Txt_Cheque_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_Cheque.Text)) { _Txt_Cheque.Text = ""; }
        }

        private void _Cmb_Banco_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarBanco();
        }

        private void _Cmb_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Banco.SelectedIndex > 0)
            { _Mtd_CargarCuentas(_Cmb_Banco.SelectedValue.ToString()); _Cmb_Cuenta.Enabled = true; _Cmb_Cuenta.Focus(); }
            else
            { _Cmb_Cuenta.Enabled = false; _Cmb_Cuenta.DataSource = null; }
        }

        private void _Bt_Restablecer_Click(object sender, EventArgs e)
        {
            _Mtd_Restablecer();
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            if (!_Chk_Fecha.Checked | (_Chk_Fecha.Checked & _Ctrl_ConsultaMes1._Bol_Listo))
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Actualizar();
                Cursor = Cursors.Default;
            }
            else
            { MessageBox.Show("Debe seleccionar un año y un mes para realizar la consulta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Dg_Grid_MouseEnter(object sender, EventArgs e)
        {
            _Lbl_DgInfo.Visible = true;
        }

        private void _Dg_Grid_MouseLeave(object sender, EventArgs e)
        {
            _Lbl_DgInfo.Visible = false;
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                if (e.RowIndex != -1)
                {
                    this.Tag = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["cidemisioncheq"].Value).Trim();
                    this.Close();
                }
            }
        }
    }
}
