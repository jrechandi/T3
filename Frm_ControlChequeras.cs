using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ControlChequeras : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_ControlChequeras()
        {
            InitializeComponent();
            _Mtd_Actualizar();
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
 
        private void _Mtd_Actualizar()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT TCHEQUERAM.cidchequera AS Chequera, CONVERT(VARCHAR,TCHEQUERAM.fechachequera,103) AS Fecha, TBANCO.cname AS Banco, RTRIM(TCHEQUERAM.cnumcuentad) AS [Nº Cuenta],TCHEQUERAM.cnumcheqdesde AS [Cheq. Desde],TCHEQUERAM.cnumcheqhasta AS [Cheq. Hasta],(SELECT COUNT(cnumcheque) FROM TCHEQUERAD WHERE TCHEQUERAD.cgroupcomp=TCHEQUERAM.cgroupcomp AND TCHEQUERAD.ccompany=TCHEQUERAM.ccompany AND TCHEQUERAD.cidchequera=TCHEQUERAM.cidchequera AND (cimpreso='1' OR canulado='1')) AS [Cheq. Usados],(SELECT COUNT(cnumcheque) FROM TCHEQUERAD WHERE TCHEQUERAD.cgroupcomp=TCHEQUERAM.cgroupcomp AND TCHEQUERAD.ccompany=TCHEQUERAM.ccompany AND TCHEQUERAD.cidchequera=TCHEQUERAM.cidchequera AND cimpreso='0' AND canulado='0') AS [Cheq. Disponibles],CASE WHEN cactiva='1' THEN 'Sí' ELSE 'No' END AS Activada FROM TCHEQUERAM INNER JOIN TBANCO ON TCHEQUERAM.ccompany = TBANCO.ccompany AND TCHEQUERAM.cbanco = TBANCO.cbanco WHERE TCHEQUERAM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TCHEQUERAM.ccompany='" + Frm_Padre._Str_Comp + "'";
            if (_Rb_Act.Checked)//Activos
            { _Str_Cadena += " AND EXISTS(SELECT cidchequera FROM TCHEQUERAD WHERE TCHEQUERAD.cgroupcomp=TCHEQUERAM.cgroupcomp AND TCHEQUERAD.ccompany=TCHEQUERAM.ccompany AND TCHEQUERAD.cidchequera=TCHEQUERAM.cidchequera AND cimpreso='0' AND canulado='0')"; }
            else if (_Rb_Fin.Checked)//Finalizados
            { _Str_Cadena += " AND NOT EXISTS(SELECT cidchequera FROM TCHEQUERAD WHERE TCHEQUERAD.cgroupcomp=TCHEQUERAM.cgroupcomp AND TCHEQUERAD.ccompany=TCHEQUERAM.ccompany AND TCHEQUERAD.cidchequera=TCHEQUERAM.cidchequera AND cimpreso='0' AND canulado='0') AND canulado='0'"; }
            else //Anulados
            { _Str_Cadena += " AND canulado='1'"; }
            _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
            _Dg_Grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }
        private void _Mtd_ActualizarDetalle(string _P_Str_IDChequera)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT cnumcheque as [Nº Cheque], CASE WHEN cimpreso='1' THEN 'Sí' ELSE 'No' END AS Impreso, CASE WHEN canulado='1' THEN 'Sí' ELSE 'No' END AS Anulado,CONVERT(VARCHAR,cfechanulado,103) AS [Fecha Anul.], cobservacionanul AS Motivo FROM TCHEQUERAD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidchequera='" + _P_Str_IDChequera + "'";
            _Dg_Detalle.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
            _Dg_Detalle.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Detalle.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Detalle.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }
        private bool _Mtd_VerifContTextBoxNumeric(TextBox _P_Txt_TextBox)
        {
            if (_P_Txt_TextBox.Text.Trim().Length > 0)
            {
                if (Convert.ToDouble(_P_Txt_TextBox.Text) > 0)
                { return true; }
            }
            return false;
        }
        private void _Mtd_Ini()
        {
            _Int_Sw = 0;
            _Chk_Activ.Enabled = false;
            _Chk_Activ.Checked = false;
            _Chk_Activ.Text = "Activar";
            _Er_Error.Dispose();
            _Dg_Detalle.DataSource = null;
            _Mtd_CargarBanco();
            _Txt_Chequera.Text = "";
            _Cmb_Banco.Enabled = false;
            _Txt_Observacion.Text = "";
            _Txt_Observacion.Enabled = false;
            _Lbl_Anulacion.Enabled = false;
            _Bt_Anular.Enabled = false;
        }
        public void _Mtd_Nuevo()
        {
            _Pnl_Clave.Visible = false;
            _Mtd_Ini();
            _Cmb_Banco.Enabled = true;
            _Tb_Tab.SelectedIndex = 1;
            _Cmb_Banco.Focus();
        }
        private bool _Mtd_VeriricarDesde(string _P_Str_Banco, string _P_Str_CheqDesde, string _P_Str_CheqHasta, string _P_Str_NumCuenta)
        {
            string _Str_Cadena = "SELECT TCHEQUERAD.cnumcheque FROM TCHEQUERAM INNER JOIN TCHEQUERAD ON TCHEQUERAM.cgroupcomp = TCHEQUERAD.cgroupcomp AND TCHEQUERAM.ccompany = TCHEQUERAD.ccompany AND TCHEQUERAM.cidchequera = TCHEQUERAD.cidchequera WHERE (TCHEQUERAM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TCHEQUERAM.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TCHEQUERAM.cbanco='" + _P_Str_Banco + "') AND (TCHEQUERAM.cnumcuentad='" + _P_Str_NumCuenta + "') AND (TCHEQUERAD.cnumcheque BETWEEN '" + _P_Str_CheqDesde + "' AND '" + _P_Str_CheqHasta + "')";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private string _Mtd_CantidadCheques(string _P_Str_CheqDesde, string _P_Str_CheqHasta)
        {
            return Convert.ToString((Convert.ToInt32(_P_Str_CheqHasta) - Convert.ToInt32(_P_Str_CheqDesde)) + 1);
        }
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            if (_Cmb_Banco.SelectedIndex > 0 & _Cmb_Cuenta.SelectedIndex > 0 & _Mtd_VerifContTextBoxNumeric(_Txt_Desde) & _Mtd_VerifContTextBoxNumeric(_Txt_Hasta))
            {
                if (Convert.ToInt32(_Txt_Hasta.Text) > Convert.ToInt32(_Txt_Desde.Text))
                {
                    bool _Bol_CheqDesde = _Mtd_VeriricarDesde(Convert.ToString(_Cmb_Banco.SelectedValue).Trim(), _Txt_Desde.Text, _Txt_Hasta.Text, Convert.ToString(_Cmb_Cuenta.SelectedValue).Trim());
                    if (!_Bol_CheqDesde)
                    {
                        if (MessageBox.Show("¿Está seguro de agregar " + _Mtd_CantidadCheques(_Txt_Desde.Text, _Txt_Hasta.Text) + " cheques para esta chequera?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            _Int_Sw = 1;
                            _Pnl_Clave.Visible = true;
                            return true;
                        }
                    }
                    else
                    { MessageBox.Show("El rango que introdujo contiene números de chques que ya han sido creados.\nPor favor verifique...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
                else
                { MessageBox.Show("El valor 'Chequera hasta' debe ser mayor al valor 'Chequera desde'.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else
            {
                if (_Cmb_Banco.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Banco, "Información requerida!!!"); }
                if (_Cmb_Cuenta.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Cuenta, "Información requerida!!!"); }
                if (!_Mtd_VerifContTextBoxNumeric(_Txt_Desde)) { _Er_Error.SetError(_Txt_Desde, "Información requerida!!!"); }
                if (!_Mtd_VerifContTextBoxNumeric(_Txt_Hasta)) { _Er_Error.SetError(_Txt_Hasta, "Información requerida!!!"); }
            }
            return false;
        }
        private void _Mtd_GuardarChequera()
        {
            bool _Bol_Predeterminada = _Mtd_Predeterminada(Convert.ToString(_Cmb_Banco.SelectedValue).Trim()) & _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CHEQUERAS");//SOLO GERENTE
            string _Str_Cadena = "SELECT MAX(cidchequera) FROM TCHEQUERAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'";
            string _Str_ID_Chequera = _Cls_VariosMetodos._Mtd_Correlativo(_Str_Cadena);
            _Str_Cadena = "INSERT INTO TCHEQUERAM (cgroupcomp,ccompany,cidchequera,fechachequera,cbanco,cnumcuentad,cnumcheqdesde,cnumcheqhasta,cactiva) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ID_Chequera + "',GETDATE(),'" + Convert.ToString(_Cmb_Banco.SelectedValue).Trim() + "','" + Convert.ToString(_Cmb_Cuenta.SelectedValue).Trim() + "','" + _Txt_Desde.Text.Trim() + "','" + _Txt_Hasta.Text.Trim() + "','" + Convert.ToInt32(_Bol_Predeterminada) + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            for (int _Int_I = Convert.ToInt32(_Txt_Desde.Text); _Int_I <= Convert.ToInt32(_Txt_Hasta.Text); _Int_I++)
            {
                _Str_Cadena = "INSERT INTO TCHEQUERAD (cgroupcomp,ccompany,cidchequera,cnumcheque) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_ID_Chequera + "','" + _Int_I + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            if (_Bol_Predeterminada)
            { MessageBox.Show("La chequera ha sido activada predeterminadamente para el banco seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private bool _Mtd_Predeterminada(string _P_Str_Banco)
        {
            string _Str_Cadena = "SELECT cbanco FROM TCHEQUERAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _P_Str_Banco + "' AND canulado='0'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0;
        }
        private void _Mtd_AnularChequera(string _P_Str_IDChequera,string _P_Str_Observacion)
        {
            string _Str_Cadena = "UPDATE TCHEQUERAD SET canulado='1',cfechanulado=GETDATE(),cuseranulado='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidchequera='" + _P_Str_IDChequera + "' AND (cimpreso='0' OR cimpreso IS NULL) AND (canulado='0' OR canulado IS NULL)";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "UPDATE TCHEQUERAM SET canulado='1',cfechanulado=GETDATE(),cuseranulado='" + Frm_Padre._Str_Use + "',cobservacionanul='" + _P_Str_Observacion + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidchequera='" + _P_Str_IDChequera + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private void _Mtd_AnularCheques(string _P_Str_IDChequera, string _P_Str_Observacion)
        {
            string _Str_Cadena = "";
            foreach (DataGridViewRow _Dg_Row in _Dg_Detalle.SelectedRows)
            {
                _Str_Cadena = "UPDATE TCHEQUERAD SET canulado='1',cfechanulado=GETDATE(),cuseranulado='" + Frm_Padre._Str_Use + "',cobservacionanul='" + _P_Str_Observacion + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidchequera='" + _P_Str_IDChequera + "' AND cnumcheque='" + Convert.ToString(_Dg_Row.Cells[0].Value).Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Dg_Row.Cells[2].Value = "Sí";
            }
        }
        private bool _Mtd_SoloActivos()
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Detalle.SelectedRows)
            {
                if (Convert.ToString(_Dg_Row.Cells[1].Value).Trim() != "No" | Convert.ToString(_Dg_Row.Cells[2].Value).Trim() != "No")
                { return false; }
            }
            return true;
        }
        private void _Mtd_ActivarChequera(string _P_Str_Banco, string _P_Str_IDChequera, string _P_Str_NumCuenta)
        {
            string _Str_Cadena = "UPDATE TCHEQUERAM SET cactiva='0' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _P_Str_Banco + "' AND cnumcuentad='" + _P_Str_NumCuenta + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "UPDATE TCHEQUERAM SET cactiva='1' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _P_Str_Banco + "' AND cidchequera='" + _P_Str_IDChequera + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }

        private bool _Mtd_ChequeraTerminada(string _P_Str_Banco, string _P_Str_NumCuenta)
        {
            string _Str_Cadena = "SELECT TCHEQUERAD.cnumcheque FROM TCHEQUERAM INNER JOIN TCHEQUERAD ON TCHEQUERAM.cgroupcomp = TCHEQUERAD.cgroupcomp AND TCHEQUERAM.ccompany = TCHEQUERAD.ccompany AND TCHEQUERAM.cidchequera = TCHEQUERAD.cidchequera WHERE (TCHEQUERAM.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (TCHEQUERAM.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TCHEQUERAM.cbanco='" + _P_Str_Banco + "') AND (TCHEQUERAM.cnumcuentad='" + _P_Str_NumCuenta + "') AND (TCHEQUERAD.cimpreso='0' OR TCHEQUERAD.cimpreso IS NULL) AND (TCHEQUERAD.canulado='0' OR TCHEQUERAD.canulado IS NULL) AND (TCHEQUERAM.cactiva='1')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count == 0;
        }

        private void Frm_ControlChequeras_Load(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CHEQUERAS"))//SOLO GERENTE
            { _Dg_Detalle.ContextMenuStrip = _Cntx_Menu; }
            _Mtd_Color_Estandar(this);
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Mtd_Sorted(_Dg_Grid);
            _Mtd_Sorted(_Dg_Detalle);
        }

        private void _Txt_Desde_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_Desde.Text)) { _Txt_Desde.Text = ""; }
        }

        private void _Txt_Hasta_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_Hasta.Text)) { _Txt_Hasta.Text = ""; }
        }

        private void _Txt_Desde_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Desde, e, 18, 0);
        }

        private void _Txt_Hasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Hasta, e, 18, 0);
        }

        private void _Cmb_Banco_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarBanco();
        }

        private void _Cmb_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Banco.SelectedIndex > 0)
            { _Mtd_CargarCuentas(_Cmb_Banco.SelectedValue.ToString()); _Cmb_Cuenta.Enabled = true; _Cmb_Cuenta.Focus(); _Er_Error.Dispose(); }
            else
            { _Cmb_Cuenta.Enabled = false; _Cmb_Cuenta.DataSource = null; }
        }

        private void _Cmb_Cuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Cuenta.SelectedIndex > 0)
            {
                _Txt_Desde.Text = ""; _Txt_Desde.Enabled = true;
                _Txt_Hasta.Text = ""; _Txt_Hasta.Enabled = true;
                _Txt_Desde.Focus();
            }
            else
            {
                _Txt_Desde.Text = ""; _Txt_Desde.Enabled = false;
                _Txt_Hasta.Text = ""; _Txt_Hasta.Enabled = false;
            }
        }

        private void _Rb_Act_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Act.Checked)
            { _Mtd_Actualizar(); }
        }

        private void _Rb_Fin_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Fin.Checked)
            { _Mtd_Actualizar(); }
        }

        private void _Rb_Anul_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Anul.Checked)
            { _Mtd_Actualizar(); }
        }
        int _Int_Sw = 0;
        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                _Pnl_Clave.Visible = false;
                if (_Int_Sw == 1)
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_GuardarChequera();
                    Cursor = Cursors.Default;
                }
                else if (_Int_Sw == 2)
                {
                    _Cls_InputBoxResult _Cls_Imp_Observacion = _Cls_InputBox.Show("Introduzca la observación de la anulación", "Observación");
                    if (_Cls_Imp_Observacion.ReturnCode == DialogResult.OK)
                    {
                        if (_Cls_Imp_Observacion.Text.Trim().Length > 0 & _Cls_Imp_Observacion.Text.Trim().Length <= 100)
                        {
                            Cursor = Cursors.WaitCursor;
                            _Mtd_AnularChequera(_Txt_Chequera.Text.Trim(), _Cls_Imp_Observacion.Text.Trim().ToUpper());
                            Cursor = Cursors.Default;
                        }
                        else
                        {
                            if (_Cls_Imp_Observacion.Text.Trim().Length == 0)
                            { MessageBox.Show("Para anular una chequera es necesario colocar la observación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            else
                            { MessageBox.Show("El número de caracteres de la observación no debe ser mayor a 100 dígitos", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            return;
                        }
                    }
                    else
                    { return; }
                }
                else if (_Int_Sw == 3)
                {
                    _Mtd_ActivarChequera(Convert.ToString(_Cmb_Banco.SelectedValue).Trim(), _Txt_Chequera.Text.Trim(), Convert.ToString(_Cmb_Cuenta.SelectedValue).Trim());
                }
                ((Frm_Padre)Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                _Mtd_Ini();
                _Mtd_Actualizar();
                _Tb_Tab.SelectedIndex = 0;
                MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void Frm_ControlChequeras_Activated(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & (_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CHEQUERAS") | _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CHEQUERAS_CARGA")))//SECRETARIA Y GERENTE
            {
                CONTROLES._Ctrl_Buscar._Bl_Especial = true;
                CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
                CONTROLES._Ctrl_Buscar._frm_Formulario = this;
                if (_Cmb_Banco.Enabled)
                { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = !_Pnl_Clave.Visible; }
                else
                { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false; }
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            else
            {
                CONTROLES._Ctrl_Buscar._Bl_Especial = false;
                CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
            }
        }

        private void Frm_ControlChequeras_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Pnl_Principal.Enabled = false; _Dg_Detalle.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Pnl_Principal.Enabled = true; _Dg_Detalle.Enabled = true; }
        }

        private void _Bt_Anular_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de anular la chequera seleccionada?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _Int_Sw = 2;
                _Pnl_Clave.Visible = true;
            }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
            if (_Int_Sw == 1)
            { ((Frm_Padre)Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_guardar2.Enabled = true; }
            else if (_Int_Sw == 3)
            { _Chk_Activ.Checked = false; }
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 0)
            { _Mtd_Ini(); _Mtd_Actualizar(); ((Frm_Padre)Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_guardar2.Enabled = false; }
            else if (!_Cmb_Banco.Enabled & _Cmb_Banco.SelectedIndex <= 0 & e.TabPageIndex == 1)
            { e.Cancel = true; }
        }
        private void _Mtd_CargarInformacion(string _P_Str_IDChequera)
        {
            string _Str_Cadena = "SELECT cbanco,cnumcuentad,cnumcheqdesde,cnumcheqhasta,canulado,cobservacionanul,cactiva FROM TCHEQUERAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidchequera='" + _P_Str_IDChequera + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Cmb_Banco.SelectedValue = _Ds.Tables[0].Rows[0]["cbanco"].ToString().Trim();
                _Cmb_Cuenta.SelectedValue = _Ds.Tables[0].Rows[0]["cnumcuentad"].ToString().Trim();
                _Txt_Desde.Text = _Ds.Tables[0].Rows[0]["cnumcheqdesde"].ToString().Trim();
                _Txt_Hasta.Text = _Ds.Tables[0].Rows[0]["cnumcheqhasta"].ToString().Trim();
                if (_Ds.Tables[0].Rows[0]["canulado"].ToString().Trim() == "1")
                { _Bt_Anular.Enabled = false; _Lbl_Anulacion.Enabled = true; _Txt_Observacion.Enabled = true; _Txt_Observacion.Text = _Ds.Tables[0].Rows[0]["cobservacionanul"].ToString().Trim(); }
                else
                { _Bt_Anular.Enabled = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CHEQUERAS"); }//SOLO GERENTE
                if (_Ds.Tables[0].Rows[0]["cactiva"].ToString().Trim() == "1")
                { _Chk_Activ.Checked = true; _Chk_Activ.Text = "Activada"; }
                else
                { _Chk_Activ.Enabled = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CHEQUERAS"); }//SOLO GERENTE
            }
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                if (e.RowIndex != -1)
                {
                    _Mtd_Ini();
                    _Txt_Chequera.Text = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells[0].Value);
                    _Mtd_CargarInformacion(Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells[0].Value));
                    _Mtd_ActualizarDetalle(Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells[0].Value));
                    _Cmb_Cuenta.Enabled = false;
                    _Txt_Desde.Enabled = false;
                    _Txt_Hasta.Enabled = false;
                    _Tb_Tab.SelectedIndex = 1;
                }
            }
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Detalle.SelectedRows.Count == 0)
            { e.Cancel = true; }
        }

        private void anularChequeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Mtd_SoloActivos())
            {
                if (MessageBox.Show("¿Esta seguro de anular el cheque seleccionado?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _Cls_InputBoxResult _Cls_Imp_Observacion = _Cls_InputBox.Show("Introduzca la observación de la anulación", "Observación");
                    if (_Cls_Imp_Observacion.ReturnCode == DialogResult.OK)
                    {
                        if (_Cls_Imp_Observacion.Text.Trim().Length > 0 & _Cls_Imp_Observacion.Text.Trim().Length <= 100)
                        {
                            Cursor = Cursors.WaitCursor;
                            _Mtd_AnularCheques(_Txt_Chequera.Text.Trim(), _Cls_Imp_Observacion.Text.ToString().Trim());
                            _Dg_Detalle.ClearSelection();
                            MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cursor = Cursors.Default;
                        }
                        else
                        {
                            if (_Cls_Imp_Observacion.Text.Trim().Length == 0)
                            { MessageBox.Show("Para anular un cheque es necesario colocar la observación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            else
                            { MessageBox.Show("El número de caracteres de la observación no debe ser mayor a 100 dígitos", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        }
                    }
                }
            }
            else
            { MessageBox.Show("Solo se pueden anular cheques activos", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Dg_Grid_MouseEnter(object sender, EventArgs e)
        {
            _Lbl_DgInfo.Visible = true;
        }

        private void _Dg_Grid_MouseLeave(object sender, EventArgs e)
        {
            _Lbl_DgInfo.Visible = false;
        }

        private void _Dg_Detalle_MouseEnter(object sender, EventArgs e)
        {
            _Lbl_DgInfo2.Visible = true;
        }

        private void _Dg_Detalle_MouseLeave(object sender, EventArgs e)
        {
            _Lbl_DgInfo2.Visible = false;
        }

        private void _Chk_Activ_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chk_Activ.Enabled & _Chk_Activ.Checked)
            {
                if (!_Mtd_ChequeraTerminada(Convert.ToString(_Cmb_Banco.SelectedValue).Trim(), Convert.ToString(_Cmb_Cuenta.SelectedValue).Trim()))
                {
                    MessageBox.Show("No se puede realizar la operación. La chequera activa tiene cheques disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Chk_Activ.Checked = false;
                    return;
                }
                if (MessageBox.Show("¿Esta seguro de activar la chequera seleccionada?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    _Chk_Activ.Checked = false;
                    return;
                }
                _Int_Sw = 3;
                _Pnl_Clave.Visible = true;
            }
        }
    }
}
