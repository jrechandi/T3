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
    public partial class Frm_GeneracionOP : Form
    {
        string _G_Str_Proveedor;
        string _G_Str_SentenciaSQL;
        string _G_Str_ValorCeldaTem = "XXXX";
        string[] _G_Str_AvisosPagos;
        string[] _G_Str_AvisosCobros;
        double[] _G_Dbl_MontoAOP;
        string _G_Str_NombProveedor;
        DataSet _G_Ds_DataSet = new DataSet();
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        LibNumLetras.clsNumerosaLetras _obj_NumerosaLetras = new LibNumLetras.clsNumerosaLetras();
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_GeneracionOP()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor que se utiliza para cargar los datos iniciales de la orden de pago.
        /// </summary>
        /// <param name="_P_Str_AvisosPagos">Arreglo de códigos de aviso de pagos</param>
        /// <param name="_P_Str_AvisosCobros">Arreglo de códigos de aviso de cobros</param>
        /// <param name="_P_Dbl_MontoAOP">Arreglo de montos de avisos de pagos</param>
        /// <param name="_P_Str_CodProveedor">Código del proveedor</param>
        /// <param name="_P_Str_NombProveedor">Nombre del proveedor</param>
        public Frm_GeneracionOP(string[] _P_Str_AvisosPagos, string[] _P_Str_AvisosCobros, double[] _P_Dbl_MontoAOP, string _P_Str_CodProveedor, string _P_Str_NombProveedor)
        {
            _G_Str_Proveedor = _P_Str_CodProveedor;
            _G_Str_AvisosPagos = _P_Str_AvisosPagos;
            _G_Str_AvisosCobros = _P_Str_AvisosCobros;
            _G_Dbl_MontoAOP = _P_Dbl_MontoAOP;
            _G_Str_NombProveedor = _P_Str_NombProveedor;            
            InitializeComponent();
            _Mtd_CargarBancoConsulta();
            _Mtd_CargarDatos(_P_Str_AvisosPagos, _P_Str_AvisosCobros, _P_Dbl_MontoAOP, _P_Str_CodProveedor, _P_Str_NombProveedor);
        }
        /// <summary>
        /// Método que carga el combo de banco
        /// </summary>
        private void _Mtd_CargarBancoConsulta()
        {
            try
            {
                _G_Str_SentenciaSQL = "SELECT DISTINCT CBANCO,CNAME FROM VST_BANCOCUENTAS WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                _myUtilidad._Mtd_CargarCombo(_Cmb_Banco, _G_Str_SentenciaSQL);
                _myUtilidad._Mtd_CargarCombo(_Cmb_Banco, _G_Str_SentenciaSQL);
            }
            catch
            {
            }
        }
        /// <summary>
        /// Método que carga las cuentas bancarias según el banco
        /// </summary>
        /// <param name="_P_Str_Banco">Código del banco</param>
        private void _Mtd_CargarCuentaConsultas(string _P_Str_Banco)
        {
            try
            {
                _G_Str_SentenciaSQL = "SELECT cnumcuenta,cuentabanname FROM VST_BANCOCUENTAS WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CBANCO='" + _P_Str_Banco + "'";
                _myUtilidad._Mtd_CargarCombo(_Cmb_Cuenta, _G_Str_SentenciaSQL);
                if (_Cmb_Cuenta.Items.Count > 1)
                {
                    _Cmb_Cuenta.Enabled = true;
                }
                else
                {
                    _Cmb_Cuenta.Enabled = false;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// Método que carga los datos iniciales del formulario
        /// </summary>
        /// <param name="_P_Str_AvisosPagos">Arreglo de códigos de aviso de pagos</param>
        /// <param name="_P_Str_AvisosCobros">Arreglo de códigos de aviso de cobros</param>
        /// <param name="_P_Dbl_MontoAOP">Arreglo de montos de avisos de pagos</param>
        /// <param name="_P_Str_CodProveedor">Código del proveedor</param>
        /// <param name="_P_Str_NombProveedor">Nombre del proveedor</param>
        private void _Mtd_CargarDatos(string[] _P_Str_AvisosPagos,string[] _P_Str_AvisosCobros, double[] _P_Dbl_MontoAOP, string _P_Str_CodProveedor, string _P_Str_NombProveedor)
        {
            try
            {
                double _Dbl_Total = _P_Dbl_MontoAOP.Sum();
                _Lbl_MontoOrdenPago.Text = _Dbl_Total.ToString("#,##0.00");
                _Lbl_Proveedor.Text = _P_Str_NombProveedor;
                _Txt_Beneficiario.Text = _P_Str_NombProveedor;
                _Txt_Concepto.Text="PAGO INTERCOMPAÑÍA PARA PROVEEDOR SEGÚN AVISO(S) DE COBRO(S):";
                foreach(string _Str_CodAviso in _P_Str_AvisosCobros)
                {
                    if (_Str_CodAviso == _P_Str_AvisosCobros[0])
                    {
                        _Txt_Concepto.Text += _Str_CodAviso;
                    }
                    else
                    {
                        _Txt_Concepto.Text += ", "+_Str_CodAviso;
                    }
                }

            }
            catch
            {
            }
        }

        private void _Cmb_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Banco.SelectedValue != null)
            {
                if (_Cmb_Banco.SelectedIndex > 0)
                {
                     _Cmb_Cuenta.SelectedIndexChanged-=new EventHandler(_Cmb_Cuenta_SelectedIndexChanged);
                    _Mtd_CargarCuentaConsultas(_Cmb_Banco.SelectedValue.ToString());
                    _Cmb_Cuenta.SelectedIndexChanged += new EventHandler(_Cmb_Cuenta_SelectedIndexChanged);
                }
            }
        }

        private void _Cmb_Banco_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarBancoConsulta();
        }

        private void _Cmb_Cuenta_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_Banco.SelectedValue != null)
            {
                if (_Cmb_Banco.SelectedIndex > 0)
                {
                    _Mtd_CargarCuentaConsultas(_Cmb_Banco.SelectedValue.ToString());
                }
            }
        }

        private void _Cmb_Cuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Cuenta.SelectedValue != null)
            {
                if (_Cmb_Cuenta.SelectedIndex > 0)
                {
                    _Mtd_GenerarComprobante(_G_Str_AvisosPagos, _G_Str_AvisosCobros, _G_Dbl_MontoAOP, _G_Str_Proveedor, _G_Str_NombProveedor);
                }
            }
        }
        /// <summary>
        /// Método que genera el comprobante contable para la orden de pago
        /// </summary>
        /// <param name="_P_Str_AvisosPagos">Arreglo de códigos de aviso de pagos</param>
        /// <param name="_P_Str_AvisosCobros">Arreglo de códigos de aviso de cobros</param>
        /// <param name="_P_Dbl_MontoAOP">Arreglo de montos de avisos de pagos</param>
        /// <param name="_P_Str_CodProveedor">Código del proveedor</param>
        /// <param name="_P_Str_NombProveedor">Nombre del proveedor</param>
        private void _Mtd_GenerarComprobante(string[] _P_Str_AvisosPagos, string[] _P_Str_AvisosCobros, double[] _P_Dbl_MontoAOP, string _P_Str_CodProveedor, string _P_Str_NombProveedor)
        {
            double _Dbl_Monto = 0;
            _Dg_Comprobante.Rows.Clear();
            //------------

            _Dbl_Monto = Convert.ToDouble(_P_Dbl_MontoAOP.Sum());
            int _Int_Contador = 0;
            foreach (string _Str_AvisoPago in _P_Str_AvisosPagos)
            {
                _Dg_Comprobante.Rows.Add();
                _Dg_Comprobante[0, _Dg_Comprobante.RowCount - 1].Value = "XXXX";
                _G_Str_SentenciaSQL = "SELECT CONVERT(VARCHAR,cfechaemision,103) AS cfechaemision FROM TAVISOPAGM WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND ccodavisopag='" + _Str_AvisoPago + "'";
                _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
                string _Str_Fecha=_G_Ds_DataSet.Tables[0].Rows[0][0].ToString();
                _Dg_Comprobante[2, _Dg_Comprobante.RowCount - 1].Value = "PAGO INTERCOMPAÑIA S/AVISO " + _P_Str_AvisosCobros[_Int_Contador] + " " + _P_Str_NombProveedor + " " + _Str_Fecha;
                _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = _P_Dbl_MontoAOP[_Int_Contador].ToString("#,##0.00");
                _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = "";
                _Int_Contador++;
            }
            //Se obtiene la cuenta contable del código de cuenta bancaria
            _G_Str_SentenciaSQL ="SELECT ccount FROM TCUENTBANC WHERE cbanco='"+_Cmb_Banco.SelectedValue.ToString()+"' AND cnumcuenta='"+_Cmb_Cuenta.SelectedValue.ToString()+"'";
            _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
            _Dg_Comprobante.Rows.Add();
            _Dg_Comprobante[0, _Dg_Comprobante.RowCount - 1].Value = _G_Ds_DataSet.Tables[0].Rows[0][0].ToString();
            _Dg_Comprobante[2, _Dg_Comprobante.RowCount - 1].Value = _Cmb_Banco.Text.ToString() + " " + _Cmb_Cuenta.Text.ToString();
            _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = "";
            _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = _P_Dbl_MontoAOP.Sum().ToString("#,##0.00");
            if (_Dg_Comprobante.RowCount > 0)
            {
                _Dg_Comprobante.Rows.Add(new object[] { null, null, "TOTAL", _Mtd_TotalDebeHaber(3), _Mtd_TotalDebeHaber(4) });
            }
            _Mtd_HabilitarCeldaXXXX(true);
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        /// <summary>
        /// Método que habilita las celda con XXXX
        /// </summary>
        /// <param name="_P_Bol_Habilitar">Booleano para habilitar o deshabilitar</param>
        private void _Mtd_HabilitarCeldaXXXX(bool _P_Bol_Habilitar)
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells[0].Value).Trim() == "XXXX")
                { _Dg_Row.Cells[0].ReadOnly = !_P_Bol_Habilitar; }
                else
                { _Dg_Row.Cells[0].ReadOnly = true; }
            }
        }
        /// <summary>
        /// Método que devuelve la suma de las filas del debe o el haber según sea el caso
        /// </summary>
        /// <param name="_P_Int_Col_Index">Número de columna del grid</param>
        /// <returns></returns>
        private string _Mtd_TotalDebeHaber(int _P_Int_Col_Index)
        {
            double _Dbl_Total = 0;
            object _Ob_Valor = new object();
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (_Dg_Row.Cells[0].Value.ToString().Trim().Length > 0)
                    {
                        _Ob_Valor = _Dg_Row.Cells[_P_Int_Col_Index].Value;
                        if (_Ob_Valor == null)
                        { _Ob_Valor = 0; }
                        else if (_Ob_Valor.ToString().Trim().Length == 0)
                        { _Ob_Valor = 0; }
                        _Dbl_Total += Convert.ToDouble(_Ob_Valor);
                    }
                }
            }
            return _Dbl_Total.ToString("#,##0.00");
        }

        private void _Dg_Comprobante_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (_Dg_Comprobante.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    _G_Str_ValorCeldaTem = _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
            }
        }

        private void _Dg_Comprobante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 1 & !_Dg_Comprobante.Rows[e.RowIndex].Cells[0].ReadOnly)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_VstCuentas _Frm = new Frm_VstCuentas();
                    Cursor = Cursors.Default;
                    _Frm.ShowDialog();
                    if (_Frm._Str_FrmNodeSelec.Trim().Length > 0)
                    {
                        if (_Mtd_CuentaDetalle(_Frm._Str_FrmNodeSelec.Trim()))
                        {
                            if (!_Mtd_ValidarCuenta(_Frm._Str_FrmNodeSelec.Trim(), e.RowIndex))
                            { _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _Frm._Str_FrmNodeSelec.Trim(); _Dg_Comprobante.Rows[e.RowIndex].Cells[2].Value = _Dg_Comprobante.Rows[e.RowIndex].Cells[2].Value; _G_Str_ValorCeldaTem = _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim(); }
                            else
                            { MessageBox.Show("La cuenta que introdujo ya existe. Debe ingresar una cuenta diferente", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _G_Str_ValorCeldaTem; }
                        }
                        else
                        { MessageBox.Show("Debe ingresar una cuenta de detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _G_Str_ValorCeldaTem; }
                    }
                    _Frm.Dispose();
                }
            }
        }
        /// <summary>
        /// Devuelve un valor que indica si la cuenta es una cuenta de detalle
        /// </summary>
        /// <param name="_P_Str_Cuenta">Cuenta</param>
        /// <returns>Booleano si es valido o no</returns>
        private bool _Mtd_CuentaDetalle(string _P_Str_Cuenta)
        {
            string _Str_Cadena = "Select ctcount from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' AND cactivate='1' AND ccount='" + _P_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper() == "D")
                { return true; }
            }
            return false;
        }
        /// <summary>
        /// Verifica si la cuenta ya ha sido ingresada.
        /// </summary>
        /// <param name="_P_Str_Cuenta">Cuenta</param>
        /// <param name="_P_Int_RowIndex">Índice de la fila</param>
        /// <returns>Booleano si es valido o no</returns>
        private bool _Mtd_ValidarCuenta(string _P_Str_Cuenta, int _P_Int_RowIndex)
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (_Dg_Row.Cells[0].Value.ToString().Trim() == _P_Str_Cuenta & _Dg_Row.Index != _P_Int_RowIndex)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void _Dg_Comprobante_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                if (_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    if (_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim().Length == 0)
                    {
                        _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _G_Str_ValorCeldaTem;
                    }
                    else
                    {
                        if (_Mtd_CuentaDetalle(_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim()))
                        {
                            if (!_Mtd_ValidarCuenta(_Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value.ToString().Trim(), e.RowIndex))
                            { _Dg_Comprobante.Rows[e.RowIndex].Cells[2].Value = _Dg_Comprobante.Rows[e.RowIndex].Cells[2].Value; }
                            else
                            { MessageBox.Show("La cuenta que introdujo ya existe. Debe ingresar una cuenta diferente", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _G_Str_ValorCeldaTem; }
                        }
                        else
                        { MessageBox.Show("Debe ingresar una cuenta de detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _G_Str_ValorCeldaTem; }
                    }
                }
                else
                { _Dg_Comprobante.Rows[e.RowIndex].Cells[0].Value = _G_Str_ValorCeldaTem; }
            }
        }
        bool _G_Bol_Boleano = false;
        private void _Dg_Comprobante_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!_G_Bol_Boleano)
            {
                e.Control.TextChanged += new EventHandler(Control_TextChanged);
                _G_Bol_Boleano = true;
            }
        }
        void Control_TextChanged(object sender, EventArgs e)
        {
            if (_Dg_Comprobante.CurrentCell.ColumnIndex == 0)
            {
                _Mtd_MostrarToolTipsCell(((TextBox)sender).Text, ((TextBox)sender).Font);
            }
        }
        /// <summary>
        /// Muestra en un ToolTips la descripción de la cuenta que se esta introduciendo manualmente
        /// </summary>
        /// <param name="_P_Str_Cuenta">Cuenta contable</param>
        /// /// <param name="_P_Fnt_Fuente">Fuente</param>
        private void _Mtd_MostrarToolTipsCell(string _P_Str_Cuenta, Font _P_Fnt_Fuente)
        {
            if (_P_Str_Cuenta.Trim().Length > 0)
            {
                string _Str_Cadena = "Select cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _P_Str_Cuenta.Trim() + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Tlt_Tips.Show(_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(), this, (_Dg_Comprobante.Location.X + (_Dg_Comprobante.Width / 2)) - (Convert.ToInt32(CreateGraphics().MeasureString(_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(), _P_Fnt_Fuente).Width) / 2), this.Height - 50, 2000);
                }
                else
                {
                    _Tlt_Tips.Hide(this);
                }
            }
            else
            { _Tlt_Tips.Hide(this); }
        }
        /// <summary>
        /// Método que se usa para validar el formulario
        /// </summary>
        /// <returns>Devuelve true si es correcto</returns>
        private bool _Mtd_Validar()
        {
            bool _Bol_Valido = true;
            _Er_Error.Dispose();
            string _Str_Banco = "";
            string _Str_Cuenta = "";
            string _Str_Concepto = "";
            string _Str_Beneficiario = "";
            if (_Cmb_Banco.SelectedValue != null)
            {
                if (_Cmb_Banco.SelectedValue.ToString() != "nulo")
                {
                    _Str_Banco = _Cmb_Banco.SelectedValue.ToString();
                }
            }
            if (_Cmb_Cuenta.SelectedValue != null)
            {
                if (_Cmb_Cuenta.SelectedValue.ToString() != "nulo")
                {
                    _Str_Cuenta = _Cmb_Cuenta.SelectedValue.ToString();
                }
            }
            _Str_Concepto = _Txt_Concepto.Text;
            _Str_Beneficiario = _Txt_Beneficiario.Text;
            if (_Str_Concepto.Trim().Length == 0)
            {
                _Bol_Valido = false;
                _Er_Error.SetError(_Txt_Concepto, "Información Requerida!!!");
            }
            if (_Str_Beneficiario.Trim().Length == 0)
            {
                _Bol_Valido = false;
                _Er_Error.SetError(_Txt_Beneficiario, "Información Requerida!!!");
            }
            if (_Str_Cuenta.Trim().Length == 0)
            {
                _Bol_Valido = false;
                _Er_Error.SetError(_Cmb_Cuenta, "Información Requerida!!!");
            }
            if (_Str_Banco.Trim().Length == 0)
            {
                _Bol_Valido = false;
                _Er_Error.SetError(_Cmb_Banco, "Información Requerida!!!");
            }
            return _Bol_Valido;
        }
        private void _Btn_GenerarOP_Click(object sender, EventArgs e)
        {
            if (_Mtd_Validar())
            {
                if (_Mtd_VerificarCuentas())
                {
                    if (_Dg_Comprobante.Rows.Count > 0)
                    {
                        _Pnl_Clave.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Debe visualizar y completar el comprobate contable.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("El registro contable solo puede realizarse con cuentas de detalle.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        /// <summary>
        /// Verifica si todas las cuentas existen
        /// </summary>
        /// <returns>Devuelve true si es correcto</returns>
        private bool _Mtd_VerificarCuentas()
        {
            DataSet _Ds = new DataSet();
            string _Str_Cadena = "";
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells[0].Value).Trim().Length > 0)
                {
                    _Str_Cadena = "Select ctcount from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _Dg_Row.Cells[0].Value.ToString() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count == 0)
                    { return false; }
                    else if (_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper() != "D")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Método que genera el comprobante contable del aviso
        /// </summary>
        /// <returns>Retorna el id del comprobante contable</returns>
        private int _Mtd_GenerarComprobante()
        {
            _G_Str_SentenciaSQL = "SELECT ctipdocavisocobro FROM TCONFIGCXC WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'";
            string _Str_TipoDocAviso = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL).Tables[0].Rows[0][0].ToString();
            //-------------------------------------------------------
            string _Str_ProcesoCont = "P_BCO_CHQ_CIAREL";
            Clases._Cls_ProcesosCont _Cls_Proceso_Cont = new T3.Clases._Cls_ProcesosCont(_Str_ProcesoCont);
            string _Str_Cconceptocomp = _Cls_Proceso_Cont._Field_ConceptoComprobante;
            string _Str_Ctypcompro = _Cls_Proceso_Cont._Field_TipoComprobante;
            //-------------------------------------------------------
            int _Int_Comprobante = _myUtilidad._Mtd_Consecutivo_TCOMPROBANC();
            string _Str_Cadena = "INSERT INTO TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante + "','" + _Str_Ctypcompro + "','" + _Str_Cconceptocomp + "','" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Mtd_TotalDebeHaber(3))) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Mtd_TotalDebeHaber(4))) + "','0',GETDATE(),'" + Frm_Padre._Str_Use + "','1','9')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            //-------------------------------------------------------
            object _Ob_DebeD = new object();
            object _Ob_HaberD = new object();
            string _Str_DescripD = "";
            int _Int_Contador = 0;
            string _Str_Numdocu = "";
            string _Str_TipoDocumento = "";
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (_Dg_Row.Cells[0].Value.ToString().Trim().Length > 0)
                    {
                        _Int_Contador++;
                        _Ob_DebeD = _Dg_Row.Cells[3].Value;
                        if (_Ob_DebeD == null)
                        { _Ob_DebeD = 0; }
                        else if (_Ob_DebeD.ToString().Trim().Length == 0)
                        { _Ob_DebeD = 0; }
                        //---------------------------
                        _Ob_HaberD = _Dg_Row.Cells[4].Value;
                        if (_Ob_HaberD == null)
                        { _Ob_HaberD = 0; }
                        else if (_Ob_HaberD.ToString().Trim().Length == 0)
                        { _Ob_HaberD = 0; }
                        //---------------------------
                        _Str_DescripD = Convert.ToString(_Dg_Row.Cells[2].Value).Trim().ToUpper();
                        //------------------------------------------------------------------------
                        if (_Int_Contador > _G_Str_AvisosCobros.Length)
                        {
                            _Str_Numdocu = "";
                            if (_Rbt_Cheque.Checked)
                            {
                                _Str_TipoDocumento = "CHEQ";
                            }
                            else
                            {
                                _Str_TipoDocumento = "TRANSF";
                            }
                        }
                        else
                        {
                            _Str_Numdocu = _G_Str_AvisosCobros[_Int_Contador-1];
                            _Str_TipoDocumento = _Str_TipoDocAviso;
                        }

                        _Str_Cadena = "INSERT INTO TCOMPROBAND (ccompany,cidcomprob,corder,ccount,cdescrip,ctdocument,cnumdocu,cdatedocu,ctotdebe,ctothaber,cdateadd,cuseradd)";
                        _Str_Cadena += " VALUES('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante.ToString() + "','" + (_Dg_Row.Index + 1) + "','" + Convert.ToString(_Dg_Row.Cells[0].Value).Trim() + "','" + _Str_DescripD + "','" + _Str_TipoDocumento + "','" + _Str_Numdocu + "',GETDATE(),'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_DebeD)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_HaberD)) + "',GETDATE(),'" + Frm_Padre._Str_Use + "')";

                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                        //if (Convert.ToDouble(_Ob_DebeD) > 0)
                        //{
                        //    CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(), Convert.ToString(_Dg_Row.Cells[0].Value).Trim(), _Str_Proveedor, _Str_DescripD, Convert.ToString(_Txt_TipoDoc.Tag).Trim(), _Txt_Documento.Text.Trim().ToUpper(), _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value), _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_DebeD)), Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), "D");
                        //}
                        //else
                        //{
                        //    CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(), Convert.ToString(_Dg_Row.Cells[0].Value).Trim(), _Str_Proveedor, _Str_DescripD, Convert.ToString(_Txt_TipoDoc.Tag).Trim(), _Txt_Documento.Text.Trim().ToUpper(), _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value), _Cls_Formato._Mtd_fecha(_Dtp_Vencimiento.Value), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_HaberD)), Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())), "H");
                        //}
                    }
                }
            }
            return _Int_Comprobante;
        }

        private void Frm_GeneracionOP_Load(object sender, EventArgs e)
        {
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Mtd_Sorted(_Dg_Comprobante);
        }
        private void _Mtd_Sorted(DataGridView _P_Dg_Grid)
        {
            for (int _Int_i = 0; _Int_i < _P_Dg_Grid.Columns.Count; _Int_i++)
            {
                _P_Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                if (_Mtd_Validar())
                {
                    if (_Mtd_VerificarCuentas())
                    {
                        if (_Dg_Comprobante.Rows.Count > 0)
                        {
                            //Se genera el comprobante
                            int _Int_Comprobante = _Mtd_GenerarComprobante();
                            //Se inserta la orden de pago
                            string _Str_FrmFPago = "CHEQ";
                            if (_Rbt_Transferencia.Checked)
                            {
                                _Str_FrmFPago = "TRANSF";
                            }
                            _G_Str_SentenciaSQL = "Select Max(cidordpago) FROM TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                            string _Str_IdTrans = _myUtilidad._Mtd_Correlativo(_G_Str_SentenciaSQL);
                            _G_Str_SentenciaSQL = "INSERT INTO TPAGOSCXPM (cgroupcomp,ccompany,cidordpago,cproveedor,ctippago,cfpago,cfecha,cuserfirmante,cmontototal,cbanco,ccaja,cnumcuentad,ccancelado,canulado,cmontototaltext,cidcomprob,cdescpppago,cotrospago,ctipotrospago,cconcepto,cbeneficiario) VALUES('";
                            _G_Str_SentenciaSQL += Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "'," + _Str_IdTrans + ",'" + _G_Str_Proveedor.Trim() + "','PTOT','" + _Str_FrmFPago + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + Frm_Padre._Str_Use.Trim() + "'," + _Lbl_MontoOrdenPago.Text.Replace(".", "").Replace(",", ".") + "," + _Cmb_Banco.SelectedValue.ToString() + ",null,'" + _Cmb_Cuenta.SelectedValue.ToString() + "',0,0,'" + _obj_NumerosaLetras.Numero2Letra(_Lbl_MontoOrdenPago.Text.Replace(".", ""), 0, 2, "", "Céntimo", LibNumLetras.clsNumerosaLetras.eSexo.Masculino, LibNumLetras.clsNumerosaLetras.eSexo.Masculino).ToUpper() + "','" + _Int_Comprobante.ToString() + "','0','1','13','" + _Txt_Concepto.Text.Trim() + "','" + _Txt_Beneficiario.Text.Trim() + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                            foreach (string _Str_CodAviso in _G_Str_AvisosPagos)
                            {
                                _G_Str_SentenciaSQL = "UPDATE TAVISOPAGM SET cidordpago='" + _Str_IdTrans + "' WHERE ccodavisopag='" + _Str_CodAviso + "' AND CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                            }
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSQL);
                            MessageBox.Show("La operación ha sido realizada correctamente.\nSe ha creado la orden de pago número " + _Str_IdTrans.ToString() + ".", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.Yes;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Debe visualizar y completar el comprobate contable.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El registro contable solo puede realizarse con cuentas de detalle.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Btn_CancelarOP_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Pnl_Botones.Enabled = false; _Pnl_Superior.Enabled = false; _Pnl_Comprobante.Enabled = false; _Dg_Comprobante.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Pnl_Botones.Enabled = true; _Pnl_Superior.Enabled = true; _Pnl_Comprobante.Enabled = true; _Pnl_Superior.Enabled = true; _Dg_Comprobante.Enabled = true; }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }
    }
}
