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
    public partial class Frm_IC_CobranzaPago : Form
    {
        Frm_IC_Cobranza _Frm;
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");

        public Frm_IC_CobranzaPago(Frm_IC_Cobranza _P_Frm)
        {
            _Frm = _P_Frm;
            InitializeComponent();
            _Opt_Cheque.Checked =false;
            _Opt_Transferencia.Checked=false;
        }

        private void _Frm_IC_CobranzaPago_Load(object sender, EventArgs e)
        {
            _Mtd_CargarComboBancoQueEmite();
            _Mtd_CargarBancoEnQueFueDepositado();
            _Cmb_CuentaEnQueFueDepositado.Enabled = false;
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda(_Txt_Monto);
            _Dtp_FechaEmision.MaxDate = DateTime.Now;

        }
        private void _Mtd_CargarComboBancoQueEmite()
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT LTRIM(RTRIM(TBANCO.cbanco)),TBANCO.cname " +
                                 "FROM TBANCO " +
                                 "WHERE " +
                                 "TBANCO.ccompany='" + Frm_Padre._Str_Comp + "' " +
                                 "AND " +
                                 "ISNULL(TBANCO.cdelete,0)=0";
            _Str_Cadena += " ORDER BY REPLACE(TBANCO.cname,'BANCO','')";

            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_BancoQueEmite.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows.Cast<DataRow>())
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString(), _DRow[0].ToString()));
            }
            _Cmb_BancoQueEmite.DataSource = _myArrayList;
            _Cmb_BancoQueEmite.DisplayMember = "Display";
            _Cmb_BancoQueEmite.ValueMember = "Value";
            _Cmb_BancoQueEmite.SelectedValue = "nulo";
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_CargarBancoEnQueFueDepositado()
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT LTRIM(RTRIM(TBANCO.cbanco)),TBANCO.cname " +
                                 "FROM TBANCO INNER JOIN TCUENTBANC ON TBANCO.ccompany=TCUENTBANC.ccompany AND LTRIM(RTRIM(TBANCO.cbanco))=LTRIM(RTRIM(TCUENTBANC.cbanco)) AND ISNULL(TBANCO.cdelete,0)=ISNULL(TCUENTBANC.cdelete,0) " +
                                 "WHERE " +
                                 "TBANCO.ccompany='" + Frm_Padre._Str_Comp + "' " +
                                 "AND " +
                                 "ISNULL(TBANCO.cdelete,0)=0";
            _Str_Cadena += " ORDER BY REPLACE(TBANCO.cname,'BANCO','')";

            
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_BancoEnQueFueDepositado.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows.Cast<DataRow>())
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString(), _DRow[0].ToString()));
            }
            _Cmb_BancoEnQueFueDepositado.DataSource = _myArrayList;
            _Cmb_BancoEnQueFueDepositado.DisplayMember = "Display";
            _Cmb_BancoEnQueFueDepositado.ValueMember = "Value";
            _Cmb_BancoEnQueFueDepositado.SelectedValue = "nulo";
            this.Cursor = Cursors.Default;
        
        }
        private void _Cmb_BancoEnQueFueDepositado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_BancoQueEmite.SelectedIndex > 0)
            {
                _Mtd_CargarCuentas();
                _Cmb_CuentaEnQueFueDepositado.Enabled = true;
            }
        }
        private void _Mtd_CargarCuentas()
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "";
            _Str_Cadena += "SELECT ";
            _Str_Cadena += "cnumcuenta";
            _Str_Cadena += ",cname ";
            _Str_Cadena += "FROM TCUENTBANC ";
            _Str_Cadena += "WHERE ";
            _Str_Cadena += "ccompany='" + Frm_Padre._Str_Comp + "' ";
            _Str_Cadena += "and ";
            _Str_Cadena += "cbanco='" + _Cmb_BancoEnQueFueDepositado.SelectedValue.ToString() + "' ";
            _Str_Cadena += "and ISNULL(cdelete,0)=0";
            _myUtilidad._Mtd_CargarCombo(_Cmb_CuentaEnQueFueDepositado, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }



        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool _Mtd_Validar()
        {
            _Er_Error.Dispose();
            //No se ha seleccionado el tipo de documento
            if (_Opt_Cheque.Checked == false && _Opt_Transferencia.Checked == false)
            {
                _Er_Error.SetError(_Opt_Cheque, "Información Requerida!!!");
                _Er_Error.SetError(_Opt_Transferencia, "Información Requerida!!!");
                MessageBox.Show("Debe seleccionar si es cheque o transferencia.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //No se ha seleccionado el banco que emite
            if (_Cmb_BancoQueEmite.SelectedValue.ToString() == "nulo")
            {
                _Er_Error.SetError(_Cmb_BancoQueEmite, "Información Requerida!!!");
                MessageBox.Show("Debe seleccionar el banco que emite.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //No se ha seleccionado el banco en que fue depositado
            if (_Cmb_BancoEnQueFueDepositado.SelectedValue.ToString() == "nulo")
            {
                _Er_Error.SetError(_Cmb_BancoEnQueFueDepositado, "Información Requerida!!!");
                MessageBox.Show("Debe seleccionar el banco en que fue depositado.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //No se ha seleccionado la cuenta en que fue depositado
            if (_Cmb_CuentaEnQueFueDepositado.SelectedValue.ToString() == "nulo")
            {
                _Er_Error.SetError(_Cmb_CuentaEnQueFueDepositado, "Información Requerida!!!");
                MessageBox.Show("Debe seleccionar la cuenta en que fue depositado.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Fecha no valida
            if (_Dtp_FechaEmision.Value == DateTime.MinValue)
            {
                _Er_Error.SetError(_Dtp_FechaEmision, "Información Requerida!!!");
                MessageBox.Show("Debe seleccionar una fecha.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Fecha no valida (mayor que hoy)
            if (_Dtp_FechaEmision.Value > DateTime.Now)
            {
                _Er_Error.SetError(_Dtp_FechaEmision, "Información Requerida!!!");
                MessageBox.Show("Debe seleccionar una fecha no mayor que hoy.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Numero Documento
            if (_Txt_NumeroDocumento.Text.Length == 0)
            {
                _Er_Error.SetError(_Txt_NumeroDocumento, "Información Requerida!!!");
                MessageBox.Show("Debe introducir un número válido.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Monto
            if (!_Mtd_VerifContTextBoxNumeric(_Txt_Monto))
            {
                _Er_Error.SetError(_Txt_Monto, "Información Requerida!!!");
                MessageBox.Show("Debe introducir un monto válido.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Verifico que ya no este cargado el documentos
            string _TipoDocumento = "";
            if (_Opt_Cheque.Checked == true)
            { _TipoDocumento = "CHEQUE"; }
            else if (_Opt_Transferencia.Checked == true)
            { _TipoDocumento = "TRANSFERENCIA"; }
            if (_Frm._Mtd_ExisteTipoDocumentoBancoNumeroDePago(_TipoDocumento, _Cmb_BancoQueEmite.SelectedValue.ToString(), _Txt_NumeroDocumento.Text))
            {
                _Er_Error.SetError(_Cmb_BancoQueEmite, "Información Requerida!!!");
                _Er_Error.SetError(_Opt_Cheque, "Información Requerida!!!");
                _Er_Error.SetError(_Opt_Transferencia, "Información Requerida!!!");
                _Er_Error.SetError(_Txt_NumeroDocumento, "Información Requerida!!!");
                MessageBox.Show("El Documento ingresado ya existe.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Todo bien
            return true;
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

        private void _Bt_Agregar_Click(object sender, EventArgs e)
        {
            if (_Mtd_Validar())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void _Txt_Monto_Leave(object sender, EventArgs e)
        {
            if (_Txt_Monto.Text != "")
            {
                _Txt_Monto.Text = Convert.ToDouble(_Txt_Monto.Text).ToString("#,##0.00");
            }

        }

        /// <summary>
        /// Para solo permitir numeros 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Txt_NumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }



    }
}
