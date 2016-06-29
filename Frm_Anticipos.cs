using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Anticipos : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_Anticipos()
        {
            InitializeComponent();
            _Mtd_CargarBanco();
        }
        string _Str_Proveedor = "";
        string _Str_OrdenPago = "";
        Frm_OrdenPago _Frm_OrdenPago;
        public Frm_Anticipos(Frm_OrdenPago _P_Frm_OrdenPago, string _P_Str_OrdenPago, string _P_Str_Proveedor)
        {
            InitializeComponent();
            _Frm_OrdenPago = _P_Frm_OrdenPago;
            _Str_Proveedor = _P_Str_Proveedor;
            _Str_OrdenPago = _P_Str_OrdenPago;
            _Mtd_CargarBanco();
            _Mtd_Actualizar_2();
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
            _Txt_ChequeTransf.Text = "";
            //_Txt_Concepto.Text = "";
            _Txt_Beneficiario.Text = "";
            _Cmb_Banco.Focus();
        }
        private void _Mtd_Actualizar()
        {
            string _Str_Cadena = "";
            if (_Str_Proveedor.Trim().Length > 0)
            { _Str_Cadena = "SELECT CASE WHEN LEN(LTRIM(RTRIM(VST_CHEQUES_EMITIDOS.cproveedor))) = 0 THEN 'SIN ID' ELSE VST_CHEQUES_EMITIDOS.cproveedor END AS [ID Proveedor], VST_CHEQUES_EMITIDOS.cbeneficiario AS Beneficiario, dbo.Fnc_Formatear(VST_CHEQUES_EMITIDOS.cmontototal) AS [Monto Pagado], VST_CHEQUES_EMITIDOS.cfpago AS [F. Pago], VST_CHEQUES_EMITIDOS.cnumcheqtransac AS Número, VST_CHEQUES_EMITIDOS.cname AS Banco, VST_CHEQUES_EMITIDOS.cnumcuentad AS Cuenta, VST_CHEQUES_EMITIDOS.cidordpago FROM VST_CHEQUES_EMITIDOS LEFT OUTER JOIN TPROVEEDOR ON VST_CHEQUES_EMITIDOS.cproveedor = TPROVEEDOR.cproveedor AND (VST_CHEQUES_EMITIDOS.ccompany = TPROVEEDOR.ccompany OR TPROVEEDOR.cglobal = '1') WHERE (VST_CHEQUES_EMITIDOS.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (VST_CHEQUES_EMITIDOS.ccompany = '" + Frm_Padre._Str_Comp + "') AND (VST_CHEQUES_EMITIDOS.cproveedor='" + _Str_Proveedor + "' OR LEN(LTRIM(RTRIM(VST_CHEQUES_EMITIDOS.cproveedor))) = 0) AND (VST_CHEQUES_EMITIDOS.cimpimiocheq = '1') AND (VST_CHEQUES_EMITIDOS.canulado = '0') AND (VST_CHEQUES_EMITIDOS.antidescontado = '0' OR VST_CHEQUES_EMITIDOS.antidescontado IS NULL) AND (VST_CHEQUES_EMITIDOS.cotrospago = '1') AND (VST_CHEQUES_EMITIDOS.ctipotrospago = '3')"; }
            else
            { _Str_Cadena = "SELECT CASE WHEN LEN(LTRIM(RTRIM(VST_CHEQUES_EMITIDOS.cproveedor))) = 0 THEN 'SIN ID' ELSE VST_CHEQUES_EMITIDOS.cproveedor END AS [ID Proveedor], VST_CHEQUES_EMITIDOS.cbeneficiario AS Beneficiario, dbo.Fnc_Formatear(VST_CHEQUES_EMITIDOS.cmontototal) AS [Monto Pagado], VST_CHEQUES_EMITIDOS.cfpago AS [F. Pago], VST_CHEQUES_EMITIDOS.cnumcheqtransac AS Número, VST_CHEQUES_EMITIDOS.cname AS Banco, VST_CHEQUES_EMITIDOS.cnumcuentad AS Cuenta, VST_CHEQUES_EMITIDOS.cidordpago FROM VST_CHEQUES_EMITIDOS LEFT OUTER JOIN TPROVEEDOR ON VST_CHEQUES_EMITIDOS.cproveedor = TPROVEEDOR.cproveedor AND (VST_CHEQUES_EMITIDOS.ccompany = TPROVEEDOR.ccompany OR TPROVEEDOR.cglobal = '1') WHERE (VST_CHEQUES_EMITIDOS.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (VST_CHEQUES_EMITIDOS.ccompany = '" + Frm_Padre._Str_Comp + "') AND (VST_CHEQUES_EMITIDOS.cimpimiocheq = '1') AND (VST_CHEQUES_EMITIDOS.canulado = '0') AND (VST_CHEQUES_EMITIDOS.antidescontado = '0' OR VST_CHEQUES_EMITIDOS.antidescontado IS NULL) AND (VST_CHEQUES_EMITIDOS.cotrospago = '1') AND (VST_CHEQUES_EMITIDOS.ctipotrospago = '3')"; }
            if (_Cmb_Banco.SelectedIndex > 0)
            { _Str_Cadena += " AND cbanco='" + Convert.ToString(_Cmb_Banco.SelectedValue).Trim() + "'"; }
            if (_Cmb_Cuenta.SelectedIndex > 0)
            { _Str_Cadena += " AND cnumcuentad='" + Convert.ToString(_Cmb_Cuenta.SelectedValue).Trim() + "'"; }
            if (_Txt_ChequeTransf.Text.Trim().Length > 0)
            { _Str_Cadena += " AND cnumcheqtransac LIKE '%" + _Txt_ChequeTransf.Text.Trim() + "%'"; }
            //if (_Txt_Concepto.Text.Trim().Length > 0)
            //{ _Str_Cadena += " AND cconcepto LIKE '%" + _Txt_Concepto.Text.Trim() + "%'"; }
            if (_Txt_Beneficiario.Text.Trim().Length > 0)
            { _Str_Cadena += " AND cbeneficiario LIKE '%" + _Txt_Beneficiario.Text.Trim() + "%'"; }
            if (_Chk_Fecha.Checked)
            { _Str_Cadena += " AND CONVERT(DATETIME,CONVERT(VARCHAR,cfechaemision,103)) BETWEEN '" + _Ctrl_ConsultaMes1._Str_FechaInicio + "' AND '" + _Ctrl_ConsultaMes1._Str_FechaFinal + "'"; }
            _Str_Cadena += " AND NOT EXISTS(SELECT cidordpago FROM TPAGOSCXPANT WHERE TPAGOSCXPANT.cgroupcomp=VST_CHEQUES_EMITIDOS.cgroupcomp AND TPAGOSCXPANT.ccompany=VST_CHEQUES_EMITIDOS.ccompany AND TPAGOSCXPANT.cidordpagoant=VST_CHEQUES_EMITIDOS.cidordpago)";
            _Str_Cadena += " ORDER BY cnumcheqtransac ASC";
            _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
            _Dg_Grid.Columns["cidordpago"].Visible = false;
            _Dg_Grid.Columns["Monto Pagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Mtd_Sorted(_Dg_Grid);
        }
        private void _Mtd_Actualizar_2()
        {
            string _Str_Cadena = "";
            if (_Str_Proveedor.Trim().Length > 0)
            { _Str_Cadena = "SELECT CASE WHEN LEN(LTRIM(RTRIM(VST_CHEQUES_EMITIDOS.cproveedor))) = 0 THEN 'SIN ID' ELSE VST_CHEQUES_EMITIDOS.cproveedor END AS [ID Proveedor], VST_CHEQUES_EMITIDOS.cbeneficiario AS Beneficiario, dbo.Fnc_Formatear(VST_CHEQUES_EMITIDOS.cmontototal) AS [Monto Pagado], VST_CHEQUES_EMITIDOS.cfpago AS [F. Pago], VST_CHEQUES_EMITIDOS.cnumcheqtransac AS Número, VST_CHEQUES_EMITIDOS.cname AS Banco, VST_CHEQUES_EMITIDOS.cnumcuentad AS Cuenta, VST_CHEQUES_EMITIDOS.cidordpago FROM VST_CHEQUES_EMITIDOS LEFT OUTER JOIN TPROVEEDOR ON VST_CHEQUES_EMITIDOS.cproveedor = TPROVEEDOR.cproveedor AND (VST_CHEQUES_EMITIDOS.ccompany = TPROVEEDOR.ccompany OR TPROVEEDOR.cglobal = '1') WHERE (VST_CHEQUES_EMITIDOS.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (VST_CHEQUES_EMITIDOS.ccompany = '" + Frm_Padre._Str_Comp + "') AND (VST_CHEQUES_EMITIDOS.cproveedor='" + _Str_Proveedor + "' OR LEN(LTRIM(RTRIM(VST_CHEQUES_EMITIDOS.cproveedor))) = 0) AND (VST_CHEQUES_EMITIDOS.cimpimiocheq = '1') AND (VST_CHEQUES_EMITIDOS.canulado = '0') AND (VST_CHEQUES_EMITIDOS.antidescontado = '0' OR VST_CHEQUES_EMITIDOS.antidescontado IS NULL) AND (VST_CHEQUES_EMITIDOS.cotrospago = '1') AND (VST_CHEQUES_EMITIDOS.ctipotrospago = '3')"; }
            else
            { _Str_Cadena = "SELECT CASE WHEN LEN(LTRIM(RTRIM(VST_CHEQUES_EMITIDOS.cproveedor))) = 0 THEN 'SIN ID' ELSE VST_CHEQUES_EMITIDOS.cproveedor END AS [ID Proveedor], VST_CHEQUES_EMITIDOS.cbeneficiario AS Beneficiario, dbo.Fnc_Formatear(VST_CHEQUES_EMITIDOS.cmontototal) AS [Monto Pagado], VST_CHEQUES_EMITIDOS.cfpago AS [F. Pago], VST_CHEQUES_EMITIDOS.cnumcheqtransac AS Número, VST_CHEQUES_EMITIDOS.cname AS Banco, VST_CHEQUES_EMITIDOS.cnumcuentad AS Cuenta, VST_CHEQUES_EMITIDOS.cidordpago FROM VST_CHEQUES_EMITIDOS LEFT OUTER JOIN TPROVEEDOR ON VST_CHEQUES_EMITIDOS.cproveedor = TPROVEEDOR.cproveedor AND (VST_CHEQUES_EMITIDOS.ccompany = TPROVEEDOR.ccompany OR TPROVEEDOR.cglobal = '1') WHERE (VST_CHEQUES_EMITIDOS.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (VST_CHEQUES_EMITIDOS.ccompany = '" + Frm_Padre._Str_Comp + "') AND (VST_CHEQUES_EMITIDOS.cimpimiocheq = '1') AND (VST_CHEQUES_EMITIDOS.canulado = '0') AND (VST_CHEQUES_EMITIDOS.antidescontado = '0' OR VST_CHEQUES_EMITIDOS.antidescontado IS NULL) AND (VST_CHEQUES_EMITIDOS.cotrospago = '1') AND (VST_CHEQUES_EMITIDOS.ctipotrospago = '3')"; }
            _Str_Cadena += " AND EXISTS(SELECT cidordpago FROM TPAGOSCXPANT WHERE TPAGOSCXPANT.cgroupcomp=VST_CHEQUES_EMITIDOS.cgroupcomp AND TPAGOSCXPANT.ccompany=VST_CHEQUES_EMITIDOS.ccompany AND TPAGOSCXPANT.cidordpagoant=VST_CHEQUES_EMITIDOS.cidordpago AND TPAGOSCXPANT.cidordpago='" + _Str_OrdenPago + "')";
            _Str_Cadena += " ORDER BY cnumcheqtransac ASC";
            _Dg_Grid_2.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
            _Dg_Grid_2.Columns["cidordpago"].Visible = false;
            _Dg_Grid_2.Columns["Monto Pagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid_2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Mtd_Sorted(_Dg_Grid_2);
        }

        private void _Chk_Fecha_CheckedChanged(object sender, EventArgs e)
        {
            _Ctrl_ConsultaMes1.Enabled = _Chk_Fecha.Checked;
        }

        private void _Txt_Cheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_ChequeTransf, e, 18, 0);
        }

        private void _Txt_Cheque_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_ChequeTransf.Text)) { _Txt_ChequeTransf.Text = ""; }
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

        private void Frm_Anticipos_Load(object sender, EventArgs e)
        {
            _Pnl_Opcionnes.Left = (this.Width / 2) - (_Pnl_Opcionnes.Width / 2);
            _Pnl_Opcionnes.Top = (this.Height / 2) - (_Pnl_Opcionnes.Height / 2);
            //--------------------------
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Ctrl_ConsultaMes1._Mtd_ConfigurarConsultaFecha();
            _Mtd_Color_Estandar(this);
        }
        private void _Mtd_Update_DetalleAnticipo()
        {
            string _Str_Cadena = "SELECT cidordpagoant FROM TPAGOSCXPANT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdenPago + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_Cadena = "UPDATE TPAGOSCXPM SET cidordpagodesc='" + _Str_OrdenPago + "',antidescontado='1' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Row[0].ToString().Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            }
        }
        private void _Mtd_Seleccionar(DataGridView _P_Dg_Grid)
        {
            foreach (DataGridViewRow _Dg_Row in _P_Dg_Grid.SelectedRows)
            {
                if (_Dg_Row.DefaultCellStyle.BackColor == Color.Red)
                { _Dg_Row.DefaultCellStyle.BackColor = Color.White; }
                else
                { _Dg_Row.DefaultCellStyle.BackColor = Color.Red; }
            }
        }
        private bool _Mtd_Seleccionados(DataGridView _P_Dg_Grid)
        {
            foreach (DataGridViewRow _Dg_Row in _P_Dg_Grid.Rows)
            {
                if (_Dg_Row.DefaultCellStyle.BackColor == Color.Red)
                { return true; }
            }
            return false;
        }
        private void _Mtd_Agregar()
        {
            string _Str_Cadena = "";
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.DefaultCellStyle.BackColor == Color.Red)
                {
                    _Str_Cadena = "INSERT INTO TPAGOSCXPANT (cgroupcomp,ccompany,cidordpago,cidordpagoant) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_OrdenPago + "','" + Convert.ToString(_Dg_Row.Cells["cidordpago"].Value).Trim() + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                }
            }
        }
        private void _Mtd_Quitar()
        {
            string _Str_Cadena = "";
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid_2.Rows)
            {
                if (_Dg_Row.DefaultCellStyle.BackColor == Color.Red)
                {
                    _Str_Cadena = "DELETE FROM TPAGOSCXPANT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpagoant='" + Convert.ToString(_Dg_Row.Cells["cidordpago"].Value).Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                }
            }
        }
        double _Dbl_G_MontoOrdenPago = 0;
        double _Dbl_G_MontoAnticipo = 0;
        private bool _Mtd_MontoVerificado()
        {
            double _Dbl_MontoOrdenPago = 0;
            double _Dbl_MontoAnticipo = 0;
            string _Str_Cadena = "SELECT ISNULL(SUM(cmontototal),0) FROM TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdenPago + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Dbl_MontoOrdenPago = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString().Trim());
            }
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.DefaultCellStyle.BackColor == Color.Red)
                {
                    _Str_Cadena = "SELECT ISNULL(SUM(cmontototal),0) FROM TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + Convert.ToString(_Dg_Row.Cells["cidordpago"].Value).Trim() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Dbl_MontoAnticipo += Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString().Trim());
                    }
                }
            }

            _Dbl_MontoAnticipo += _Mtd_Anticipo(_Str_OrdenPago);
            _Dbl_MontoOrdenPago += _Mtd_Anticipo(_Str_OrdenPago);
            _Dbl_G_MontoOrdenPago = _Dbl_MontoOrdenPago;
            _Dbl_G_MontoAnticipo = _Dbl_MontoAnticipo;
            return _Dbl_MontoAnticipo <= _Dbl_MontoOrdenPago;
        }
        private double _Mtd_Anticipo(string _P_Str_OrdenPago)
        {
            string _Str_Cadena = "SELECT ISNULL(SUM(TPAGOSCXPM.cmontototal),0) FROM TPAGOSCXPANT INNER JOIN TPAGOSCXPM ON TPAGOSCXPANT.cgroupcomp = TPAGOSCXPM.cgroupcomp AND TPAGOSCXPANT.ccompany = TPAGOSCXPM.ccompany AND TPAGOSCXPANT.cidordpagoant = TPAGOSCXPM.cidordpago WHERE (TPAGOSCXPANT.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TPAGOSCXPANT.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TPAGOSCXPANT.cidordpago = '" + _P_Str_OrdenPago + "')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString().Trim());
            }
            return 0;
        }
        private double _Mtd_AnticipoSeleccionados()
        {
            DataSet _Ds;
            string _Str_Cadena = "";
            double _Dbl_MontoAnticipo = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid_2.Rows)
            {
                if (_Dg_Row.DefaultCellStyle.BackColor == Color.Red)
                {
                    _Str_Cadena = "SELECT ISNULL(SUM(cmontototal),0) FROM TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + Convert.ToString(_Dg_Row.Cells["cidordpago"].Value).Trim() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Dbl_MontoAnticipo += Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString().Trim());
                    }
                }
            }
            return _Dbl_MontoAnticipo;
        }
        private void _CMen_OrdPago_Sel_Click(object sender, EventArgs e)
        {
            _Mtd_Seleccionar(_Dg_Grid);
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count == 0)
            { e.Cancel = true; }
        }

        private void _Bt_Guardar_Click(object sender, EventArgs e)
        {
            if (_Mtd_Seleccionados(_Dg_Grid))
            {
                if (_Mtd_MontoVerificado())
                {
                    Cursor = Cursors.WaitCursor;
                    //EN ESTRICTO ORDEN---Las lineas de código deben estar colocadas así.
                    _Mtd_Agregar();
                    string _Str_Cadena = "UPDATE TPAGOSCXPM SET cmontototal=" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_G_MontoOrdenPago - _Mtd_Anticipo(_Str_OrdenPago)) + " WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdenPago + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    _Frm_OrdenPago._Mtd_CallComprobOrdPago();
                    _Frm_OrdenPago._Mtd_GuardarComprobante();
                    _Frm_OrdenPago._Mtd_MontoOrdenPago();
                    _Mtd_Actualizar();
                    _Mtd_Actualizar_2();
                    //EN ESTRICTO ORDEN---Las lineas de código deben estar colocadas así.
                    Cursor = Cursors.Default;
                    if (_Dbl_G_MontoAnticipo == _Dbl_G_MontoOrdenPago)
                    {
                        if (MessageBox.Show("El anticipo a cubierto la orden de pago. ¿Desea cerrar la orden de pago?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _Mtd_SaldarDocumentos(_Str_OrdenPago);
                            _Mtd_Update_DetalleAnticipo();
                            _Str_Cadena = "UPDATE TPAGOSCXPM SET ccancelado='1' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdenPago + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            _Cls_VariosMetodos._Mtd_GenerarNCxDescxPPago(_Str_OrdenPago);
                            _Str_Cadena = "SELECT cidcomprob FROM TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdenPago + "'";
                            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='9' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Ds.Tables[0].Rows[0][0].ToString().Trim() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                            _Frm_OrdenPago.Close();
                            this.Close();
                        }
                    }
                }
                else
                {

                    if (MessageBox.Show("El anticipo " + _Dbl_G_MontoAnticipo.ToString("#,##0.00") + "Bs. ha sobrepasado el monto a pagar " + _Dbl_G_MontoOrdenPago.ToString("#,##0.00") + "Bs. ¿Desea procesar el anticipo?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _Pnl_Opcionnes.Visible = true;
                    }
                }
            }
            else
            { MessageBox.Show("No existen registros seleccionados para realizar la operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private void _Mtd_SaldarDocumentos(string _P_Str_OrdenPago)
        {
            string _Str_Cadena = "SELECT ctipodocument,cnumdocu FROM TPAGOSCXPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _P_Str_OrdenPago + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_Cadena = "UPDATE TFACTPPAGARM SET csaldo=0,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_Proveedor + "' AND ctipodocument='" + _Row["ctipodocument"].ToString() + "' AND cnumdocu='" + _Row["cnumdocu"].ToString() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "UPDATE TMOVCXPM SET csaldo=0,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_Proveedor + "' AND ctipodocument='" + _Row["ctipodocument"].ToString() + "' AND cnumdocu='" + _Row["cnumdocu"].ToString() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
        }
        private void _Dg_Grid_2_MouseEnter(object sender, EventArgs e)
        {
            _Lbl_DgInfo_2.Visible = true;
        }

        private void _Dg_Grid_2_MouseLeave(object sender, EventArgs e)
        {
            _Lbl_DgInfo_2.Visible = false;
        }

        private void _Cntx_Menu_2_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Grid_2.SelectedRows.Count == 0)
            { e.Cancel = true; }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _Mtd_Seleccionar(_Dg_Grid_2);
        }

        private void _Bt_Quitar_Click(object sender, EventArgs e)
        {
            if (_Mtd_Seleccionados(_Dg_Grid_2))
            {
                Cursor = Cursors.WaitCursor;
                //EN ESTRICTO ORDEN---Las lineas de código deben estar colocadas así.
                _Mtd_Quitar();
                string _Str_Cadena = "UPDATE TPAGOSCXPM SET cmontototal=cmontototal+" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Mtd_AnticipoSeleccionados()) + " WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdenPago + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Frm_OrdenPago._Mtd_CallComprobOrdPago();
                _Frm_OrdenPago._Mtd_GuardarComprobante();
                _Frm_OrdenPago._Mtd_MontoOrdenPago();
                _Mtd_Actualizar();
                _Mtd_Actualizar_2();
                //EN ESTRICTO ORDEN---Las lineas de código deben estar colocadas así.
                Cursor = Cursors.Default;
            }
            else
            { MessageBox.Show("No existen registros seleccionados para realizar la operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Pnl_Opcionnes_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Opcionnes.Visible)
            { _Tb_Tab.Enabled = false; }
            else
            { _Tb_Tab.Enabled = true; }
        }

        private string _Mtd_GenerarND(double _P_Dbl_MontoAnticipo, double _P_Dbl_MontoOrdenPago,string _P_Str_Comprobante)
        {
            string _Str_Cadena = "SELECT MAX(cidnotadebitocxp) FROM TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
            string _Str_ID_ND = _Cls_VariosMetodos._Mtd_Correlativo(_Str_Cadena);
            double _Dbl_Monto = _P_Dbl_MontoAnticipo - _P_Dbl_MontoOrdenPago;
            string _Str_Motivo = "0";
            string _Str_Descripcion = "";
            //--------------------------------------------------------------
            string _Str_TipoDocument = "";
            string _Str_NumDocu = "0";
            _Str_Cadena = "SELECT ctipdocfact FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { _Str_TipoDocument = _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
            _Str_Cadena = "SELECT cnumdocu FROM TPAGOSCXPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdenPago + "' AND ctipodocument='" + _Str_TipoDocument + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0 & _Str_TipoDocument.Trim().Length > 0)
            { _Str_NumDocu = _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
            //--------------------------------------------------------------
            _Str_Cadena = "SELECT cidmotivo,cdescripcion FROM TMOTIVO WHERE cmotexcpago='1'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Motivo = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                _Str_Descripcion = _Ds.Tables[0].Rows[0][1].ToString().Trim();
            }
            _Str_Descripcion += " FACTURA# " + _Str_NumDocu;
            _Str_Cadena = "INSERT INTO TNOTADEBITOCP (ccompany,cgroupcomp,cidnotadebitocxp,cnumcontrolnd,cproveedor,ctipodocument,cnumdocu,cfechand,cdescripcion,cmontototsi,cimpuesto,ctotaldocu,cidmotivo,cdateadd,cuseradd,cdelete,cdescontada,canulado,cactivo,cimpresa,cestatusfirma,canticipo,cfvfnotadebitop,cidcomprob) VALUES ('" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "','" + _Str_ID_ND + "','0','" + _Str_Proveedor + "','" + _Str_TipoDocument + "','" + _Str_NumDocu + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Str_Descripcion.ToUpper() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','0','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + _Str_Motivo + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','0','0','0','0','0','3','1','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _P_Str_Comprobante + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            return _Str_ID_ND;
        }
        private void _Mtd_ImprimirComprobante(string _P_Str_Comprobante)
        {
            try
            {
                PrintDialog _Print = new PrintDialog();
            _PrintComprob:
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _P_Str_Comprobante + "'", _Print, true);
                    Cursor = Cursors.Default;
                    if (MessageBox.Show("¿El comprobante se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _Frm.Close();
                        _Frm.Dispose();
                        string _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1',clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        MessageBox.Show("El comprobante ha sido actualizado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        _Frm.Close();
                        _Frm.Dispose();
                        goto _PrintComprob;
                    }
                }
                else
                {
                    MessageBox.Show("Debe actualizar el comprobante desde el notificador 'COMPROBANTES DE ANTICIPO POR IMPRIMIR'", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar imprimir.\nDebe actualizar el comprobante desde el notificador 'COMPROBANTES DE ANTICIPO POR IMPRIMIR'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void _Mtd_ImprimirNDyComprobante(string _P_Str_ND,string _P_Str_Comprobante)
        {
            try
            {
                int _Int_Sw = 0;
                REPORTESS _Frm;
                PrintDialog _Print = new PrintDialog();
            _PrintComprob:
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    if (_Int_Sw == 0 | _Int_Sw == 1)
                    {
                        Cursor = Cursors.WaitCursor;
                        _Frm = new REPORTESS(new string[] { "VST_NOTADEBITO_SINDET" }, "", "T3.Report.rNotaDebitoSDet", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidnotadebitocxp='" + _P_Str_ND + "'", _Print, true);
                        Cursor = Cursors.Default;
                        //_Frm.ShowDialog();
                        if (MessageBox.Show("¿La ND se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            _Frm.Close();
                            _Frm.Dispose();
                            _Int_Sw = 1;
                            goto _PrintComprob;
                        }
                        else
                        {
                        A:
                            string _Str_Numero = InputBox.Show("Introduzca el número de control").Text;
                            if (_Str_Numero.Trim().Length > 0)
                            {
                                string _Str_Cadena = "Select cnumcontrolnd from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cnumcontrolnd='" + _Str_Numero + "'";
                                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show("El número de control del documento ya fue registrado. Debe intentarlo nuevamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                    goto A;
                                }
                                else
                                {
                                    _Int_Sw = 0;
                                    Program._MyClsCnn._mtd_conexion._Mtd_modificar("TNOTADEBITOCP", "cnumcontrolnd='" + _Str_Numero + "',cestatusfirma='2',cimpresa='1',cactivo='1',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _P_Str_ND + "'");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Debe ingresar el número de control", "Información", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                goto A;
                            }
                        }
                    }
                    if (_Int_Sw == 0 | _Int_Sw == 2)
                    {
                        if (_Int_Sw == 0)
                        { MessageBox.Show("Se va a proceder a imprimir el comprobante contable.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); _Int_Sw = 2; goto _PrintComprob; }
                        Cursor = Cursors.WaitCursor;
                        _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _P_Str_Comprobante + "'", _Print, true);
                        Cursor = Cursors.Default;
                        if (MessageBox.Show("¿El comprobante se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            _Frm.Close();
                            _Frm.Dispose();
                            goto _PrintComprob;
                        }
                        else
                        {
                            _Frm.Close();
                            _Frm.Dispose();
                            string _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1',clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                            MessageBox.Show("El comprobante ha sido actualizado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe imprimir la ND y actualizar el comprobante desde el notificador 'COMPROBANTES DE ANTICIPO POR IMPRIMIR'", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { Cursor = Cursors.Default; MessageBox.Show("Error al intentar imprimir.\nDebe imprimir la ND y  actualizar el comprobante desde el notificador 'COMPROBANTES DE ANTICIPO POR IMPRIMIR'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Opcionnes.Visible = false;
        }
        int _Int_Sw = 0;
        private void _Bt_ND_Click(object sender, EventArgs e)
        {
            _Int_Sw = 1;
            _Pnl_Clave.BringToFront();
            _Pnl_Clave.Visible = true;
        }

        private void _Bt_Registrar_Click(object sender, EventArgs e)
        {
            _Int_Sw = 2;
            _Pnl_Clave.BringToFront();
            _Pnl_Clave.Visible = true;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Pnl_Opcionnes.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Pnl_Opcionnes.Enabled = true; }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                string _Str_Cadena = "SELECT cidcomprob FROM TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdenPago + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                string _Str_Comprobante = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                _Pnl_Clave.Visible = false;
                _Pnl_Opcionnes.Visible = false;
                _Mtd_Agregar();
                if (_Int_Sw == 1)
                { _Frm_OrdenPago._Str_ND_Anticipo = _Mtd_GenerarND(_Dbl_G_MontoAnticipo, _Dbl_G_MontoOrdenPago, _Str_Comprobante); }
                else
                { _Frm_OrdenPago._Str_ND_Anticipo = "0"; }
                _Frm_OrdenPago._Mtd_CallComprobOrdPago();
                _Frm_OrdenPago._Mtd_GuardarComprobante();
                _Str_Cadena = "UPDATE TPAGOSCXPM SET cmontototal=0 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdenPago + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Mtd_SaldarDocumentos(_Str_OrdenPago);
                _Mtd_Update_DetalleAnticipo();
                _Str_Cadena = "UPDATE TPAGOSCXPM SET ccancelado='1' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Str_OrdenPago + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Cls_VariosMetodos._Mtd_GenerarNCxDescxPPago(_Str_OrdenPago);
                if (_Int_Sw == 1)
                {
                    MessageBox.Show("La operación ha sido realizada correctamente.\nSe va a proceder a imprimir la ND y el comprobante contable", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_ImprimirNDyComprobante(_Frm_OrdenPago._Str_ND_Anticipo, _Str_Comprobante); 
                }
                else
                {
                    MessageBox.Show("La operación ha sido realizada correctamente.\nSe va a proceder a imprimir el comprobante contable", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_ImprimirComprobante(_Str_Comprobante);
                }
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                _Frm_OrdenPago.Close();
                this.Close();
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }
    }
}
