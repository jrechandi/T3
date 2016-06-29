using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Linq;
namespace T3
{
    public partial class Frm_OrdenPago : Form
    {
        bool _Bol_Otros = false;
        DataTable _G_Dt_NdSelec = new DataTable();
        DataTable _G_Dt_NcSelec = new DataTable();
        bool _Bol_MenuPadre = false;
        public Frm_OrdenPago()
        {
            InitializeComponent();
            //_Bol_MenuPadre = true;
            _Mtd_Dt_NDSelec();
            _Mtd_Dt_NCSelec();
            string _Str_Aux = "";
            _Str_Aux = _Str_InForm;
            if (_Str_InForm == "")
            { _Mtd_Ini(); }
            _Str_InForm = _Str_Aux;
            _Mtd_CargarTpoProveFind();
            _Mtd_CargarProvee();
            //----------OTROS--------------
            _Er_Error.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
            _Mtd_CargarBancoOtros();
            _Mtd_CargarTipoPago();
            //_Dg_Find.Columns.Clear();
            //----------OTROS--------------
            _Mtd_BotonesMenu();
        }
        public Frm_OrdenPago(bool _P_Bol_Otros)
        {
            InitializeComponent();
            _Bol_Otros = true;
            _Bol_MenuPadre = true;
            _Mtd_Dt_NDSelec();
            _Mtd_Dt_NCSelec();
            string _Str_Aux = "";
            _Str_Aux = _Str_InForm;
            if (_Str_InForm == "")
            { _Mtd_Ini(); }
            _Str_InForm = _Str_Aux;
            _Mtd_CargarTpoProveFind();
            _Mtd_CargarProvee();
            //----------OTROS--------------
            _Er_Error.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
            _Mtd_CargarBancoOtros();
            _Mtd_CargarTipoPago();
            _Dg_Find.Columns.Clear();
            //----------OTROS--------------
            _Mtd_BotonesMenu();
        }
        //-------------------------------------JUAN-----------------------------------------------------------------
        CLASES._Cls_Varios_Metodos _Cls_Variosmetodos = new CLASES._Cls_Varios_Metodos(true);
        bool _Bol_Sw_ComboProveedor = false;
        DataGridViewCell _Dg_Cel;
        private void _Mtd_BuscarDatosUsuario()
        {
            string _Str_Cadena = "SELECT cname,cposition FROM TUSER WHERE cuser='" + Frm_Padre._Str_Use + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_UserNameOtros.Text = _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
                _Txt_UserCargoOtros.Text = _Ds.Tables[0].Rows[0][1].ToString().ToUpper();
            }
        }
        private void _Mtd_Activated()
        {
            if (_Cls_Variosmetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ORDEN_PAGO") & !_Pnl_Clave_Otros.Visible)
            {
                CONTROLES._Ctrl_Buscar._Bl_Especial = true;
                CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
                CONTROLES._Ctrl_Buscar._frm_Formulario = this;
                if (_Txt_OrdenPago.Text.Trim().Length > 0 & !_Txt_OrdenPago.Enabled)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = !_Mtd_OrdenReposicion(Convert.ToInt32(_Txt_OrdenPago.Text));
                }
                else if (!_Txt_OrdenPago.Enabled & _Txt_OrdenPago.Text.Trim().Length > 0 & _Cb_Banco.Enabled)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                }
                else if (_Txt_OrdenPago.Enabled)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                }
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            }
            else
            {
                CONTROLES._Ctrl_Buscar._Bl_Especial = false;
                CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
            }
        }
        private void _Mtd_CargarBancoOtros()
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT DISTINCT RTRIM(TBANCO.cbanco),TBANCO.cname FROM TBANCO INNER JOIN " +
            "TCUENTBANC ON TBANCO.ccompany = TCUENTBANC.ccompany AND TBANCO.cbanco = TCUENTBANC.cbanco WHERE TBANCO.ccompany='" + Frm_Padre._Str_Comp + "' and TBANCO.cdelete=0";
            myUtilidad._Mtd_CargarCombo(_Cb_Banco_Otros, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_CargarCtaBancoOtros(string _P_Str_Banco)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT RTRIM(cnumcuenta),cname FROM TCUENTBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cbanco='" + _P_Str_Banco + "' and cdelete=0";
            myUtilidad._Mtd_CargarCombo(_Cb_Cuenta_Otros, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_CargarTipoPago()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cb_TpoPagoOtros.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("ANTICIPO DE VIÁTICOS", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("PRÉSTAMO A EMPLEADOS", "2"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("ANTICIPO A PROVEEDORES", "3"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("PAGO TRIBUTARIO Y CONTRIBUCIONES", "4"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("PAGO DE GUARDERÍA", "5"));
            //_myArrayList.Add(new T3.Clases._Cls_ArrayList("REPOSICIÓN DE GASTOS", "6"));
            //_myArrayList.Add(new T3.Clases._Cls_ArrayList("REPOSICIÓN DE CAJA CHICA", "7"));
            //_myArrayList.Add(new T3.Clases._Cls_ArrayList("Anticipo de proveedores", "8")); Error
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("PAGOS VARIOS DE NÓMINA", "9"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("TRANSFERENCIAS", "10"));
            //_myArrayList.Add(new T3.Clases._Cls_ArrayList("BENEFICIOS Y ATENCIÓN AL PERSONAL", "11"));
            //_myArrayList.Add(new T3.Clases._Cls_ArrayList("CANCELACIÓN DE FLETES", "12"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("REPOSICIÓN DE CHEQUE DEVUELTO", "13"));
            _Cb_TpoPagoOtros.DataSource = _myArrayList;
            _Cb_TpoPagoOtros.DisplayMember = "Display";
            _Cb_TpoPagoOtros.ValueMember = "Value";
            _Cb_TpoPagoOtros.SelectedValue = "nulo";
            _Cb_TpoPagoOtros.DataSource = _myArrayList;
            _Cb_TpoPagoOtros.SelectedIndex = 0;
        }
        private void _Mtd_CargarComboGrid(DataGridViewComboBoxColumn _P_Cmd_ComboboxColumn)
        {
            string _Str_Cadena = "Select ctdocument,cname from TDOCUMENT";
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _P_Cmd_ComboboxColumn.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString(), _DRow[0].ToString()));
            }
            _P_Cmd_ComboboxColumn.DataSource = _myArrayList;
            _P_Cmd_ComboboxColumn.DisplayMember = "Display";
            _P_Cmd_ComboboxColumn.ValueMember = "Value";
        }
        private string _Mtd_BuscarCuenta(object _P_Ob_Banco, object _P_Ob_Cuenta)
        {
            string _Str_Cadena = "SELECT ccount FROM TCUENTBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cbanco='" + _P_Ob_Banco + "' and cnumcuenta='" + _P_Ob_Cuenta + "' and cdelete=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    return _Ds.Tables[0].Rows[0][0].ToString();
                }
            }
            MessageBox.Show("No se obtuvo la cuenta contable", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return "";
        }
        public void _Mtd_Actualizar()
        {
            string _Str_Cadena = "";
            //-----------
            if (_Rb_Todos.Checked)
            { _Str_Cadena = "Select CONVERT(varchar, cfecha, 103) AS Fecha,cidordpago as [O.P],cfpagonombre as Pago,ctippagonombre as Tipo,c_nomb_abreviado as Proveedor,dbo.Fnc_Formatear(cmontototal) as Monto,cproveedor,cuserfirname as Autorizado,cotrospago,cbeneficiario from VST_PAGOSCXPM WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " and ccompany='" + Frm_Padre._Str_Comp + "' AND canulado=0 and ccancelado=0 AND cidemisioncheq=0 AND cidemisioncaja=0"; }
            else if (_Rb_Regular.Checked)
            { _Str_Cadena = "Select CONVERT(varchar, cfecha, 103) AS Fecha,cidordpago as [O.P],cfpagonombre as Pago,ctippagonombre as Tipo,c_nomb_abreviado as Proveedor,dbo.Fnc_Formatear(cmontototal) as Monto,cproveedor,cuserfirname as Autorizado,cotrospago,cbeneficiario from VST_PAGOSCXPM WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " and ccompany='" + Frm_Padre._Str_Comp + "' AND canulado=0 and ccancelado=0 AND cidemisioncheq=0 AND cidemisioncaja=0 AND cotrospago='0'"; }
            else
            { _Str_Cadena = "Select CONVERT(varchar, cfecha, 103) AS Fecha,cidordpago as [O.P],cfpagonombre as Pago,ctippagonombre as Tipo,c_nomb_abreviado as Proveedor,dbo.Fnc_Formatear(cmontototal) as Monto,cproveedor,cuserfirname as Autorizado,cotrospago,cbeneficiario from VST_PAGOSCXPM WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " and ccompany='" + Frm_Padre._Str_Comp + "' AND canulado=0 and ccancelado=0 AND cidemisioncheq=0 AND cidemisioncaja=0 AND cotrospago='1'"; }
            //-----------
            if (_Cb_ProveedorFind.SelectedIndex > 0)
            { _Str_Cadena = _Str_Cadena + " AND cproveedor='" + _Cb_ProveedorFind.SelectedValue.ToString() + "'"; }
            if (_Cb_TpoProveFind.SelectedIndex > 0)
            { _Str_Cadena = _Str_Cadena + " AND cglobal=" + _Cb_TpoProveFind.SelectedValue.ToString(); }
            if (_Cb_CatProveFind.SelectedIndex > 0)
            {
                _Str_Cadena = _Str_Cadena + " AND ccatproveedor='" + _Cb_CatProveFind.SelectedValue.ToString() + "'";
            }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Find.DataSource = _Ds.Tables[0];
            _Dg_Find.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Find.Columns[6].Visible = false;
            _Dg_Find.Columns[8].Visible = false;
            _Dg_Find.Columns[9].Visible = false;
            _Dg_Find.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_IniOtros()
        {
            _Txt_OrdenPago.Text = "";
            _Txt_FechaOP.Text = "";
            _Txt_Debe.Text = "";
            _Txt_Haber.Text = "";
            _Txt_Saldo.Text = "";
            _Txt_MontoPagar.Text = "";
            _Txt_Beneficiario.Text = "";
            _Txt_Rif.Text = "";
            _Txt_Beneficiario.Tag = "";
            _Txt_Concepto.Text = "";
            _Rb_Pag.Checked = true;
            _Grb_TipoOtros.Enabled = false;
            _Grb_FormaPagoOtros.Enabled = false;
            _Txt_Beneficiario.Enabled = false;
            _Txt_Rif.Enabled = false;
            _Pnl_TipoRifCed.Enabled = false;
            _Txt_Concepto.Enabled = false;
            _Mtd_CargarComboGrid((DataGridViewComboBoxColumn)_Dg_Grid.Columns["Tipo"]);
            _Mtd_CargarBancoOtros();
            _Dg_Grid.Rows.Clear();
        }
        private void _Mtd_DeshabilitarTodo()
        {
            _Mtd_IniOtros();
            _Txt_OrdenPago.Enabled = false;
            _Cb_Banco_Otros.Enabled = false;
        }
        /// <summary>
        /// Muestra en un ToolTips la descripción de la cuenta que se esta introduciendo manualmente
        /// </summary>
        /// <param name="_P_Str_Cuenta"></param>
        private void _Mtd_MostrarToolTipsCell(string _P_Str_Cuenta,Font _P_Fnt_Fuente)
        {
            if (_P_Str_Cuenta.Trim().Length > 0)
            {
                string _Str_Cadena = "Select cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _P_Str_Cuenta.Trim() + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Tlt_Tips.Show(_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(), this, (_Dg_Grid.Location.X + (_Dg_Grid.Width / 2)) - (Convert.ToInt32(CreateGraphics().MeasureString(_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(), _P_Fnt_Fuente).Width) / 2), _Pnl_Inferior.Location.Y + 50, 2000);
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
        /// Verifica el campo cwdocu de la tabla TCOUNT esta en 1
        /// </summary>
        /// <param name="_P_Str_Cuenta">Cuenta</param>
        /// <returns></returns>
        private bool _Mtd_Cwdocu(string _P_Str_Cuenta)
        {
            if (_P_Str_Cuenta.Trim().Length > 0)
            {
                string _Str_Cadena = "Select cwdocu from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" + _P_Str_Cuenta + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Devuelve la cuenta de la fila si la hay
        /// </summary>
        /// <returns></returns>
        private string _Mtd_Cuenta(int _P_Int_RowIndex)
        {
            if (_Dg_Grid.Rows[_P_Int_RowIndex].Cells["Cuenta"].Value != null)
            {
                if (_Dg_Grid.Rows[_P_Int_RowIndex].Cells["Cuenta"].Value.ToString().Trim().Length > 0)
                {
                    return _Dg_Grid.Rows[_P_Int_RowIndex].Cells["Cuenta"].Value.ToString().Trim();
                }
            }
            return "";
        }
        /// <summary>
        /// Devuelve un valor que indica si la cuenta es una cuenta de detalle
        /// </summary>
        /// <param name="_P_Str_Cuenta">Cuenta</param>
        /// <returns></returns>
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
        /// Determina si el foco se debe mover al Debe
        /// </summary>
        /// <returns></returns>
        private bool _Mtd_Debe()
        {
            if (_Dg_Grid.CurrentCell.RowIndex > 0)
            {
                object _Ob_DebeD = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex - 1].Cells["Debe"].Value;
                if (_Ob_DebeD == null)
                { _Ob_DebeD = 0; }
                else if (_Ob_DebeD.ToString().Trim().Length == 0)
                { _Ob_DebeD = 0; }
                //-----------
                if (Convert.ToDouble(_Ob_DebeD) > 0)
                {
                    return false;
                }
            }
            return true;
        }
        private void _Mtd_CalcularDebeoHaber()
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            object _Ob_DebeD = new object();
            object _Ob_HaberD = new object();
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                _Ob_DebeD = _Dg_Row.Cells["Debe"].Value;
                if (_Ob_DebeD == null)
                { _Ob_DebeD = 0; }
                else if (_Ob_DebeD.ToString().Trim().Length == 0)
                { _Ob_DebeD = 0; }
                //---------------------------
                _Ob_HaberD = _Dg_Row.Cells["Haber"].Value;
                if (_Ob_HaberD == null)
                { _Ob_HaberD = 0; }
                else if (_Ob_HaberD.ToString().Trim().Length == 0)
                { _Ob_HaberD = 0; }
                _Dbl_Debe += Convert.ToDouble(_Ob_DebeD);
                _Dbl_Haber += Convert.ToDouble(_Ob_HaberD);
            }
            if (_Dbl_Debe > _Dbl_Haber)
            { _Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Haber"].Value = _Dbl_Debe - _Dbl_Haber; }
            else if (_Dbl_Haber > _Dbl_Debe)
            { _Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Debe"].Value = _Dbl_Haber - _Dbl_Debe; }
        }
        private void _Mtd_CalcularTotales()
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            object _Ob_DebeD = new object();
            object _Ob_HaberD = new object();
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Cells["Cuenta"].Value != null)
                {
                    if (_Dg_Row.Cells["Cuenta"].Value.ToString().Trim().Length > 0)
                    {
                        _Ob_DebeD = _Dg_Row.Cells["Debe"].Value;
                        if (_Ob_DebeD == null)
                        { _Ob_DebeD = 0; }
                        else if (_Ob_DebeD.ToString().Trim().Length == 0)
                        { _Ob_DebeD = 0; }
                        //---------------------------
                        _Ob_HaberD = _Dg_Row.Cells["Haber"].Value;
                        if (_Ob_HaberD == null)
                        { _Ob_HaberD = 0; }
                        else if (_Ob_HaberD.ToString().Trim().Length == 0)
                        { _Ob_HaberD = 0; }
                        _Dbl_Debe += Convert.ToDouble(_Ob_DebeD);
                        _Dbl_Haber += Convert.ToDouble(_Ob_HaberD);
                    }
                }
            }
            _Txt_Debe.Text = _Dbl_Debe.ToString("#,##0.00");
            _Txt_Debe.Tag = _Dbl_Debe;//Para guardar
            _Txt_Haber.Text = _Dbl_Haber.ToString("#,##0.00");
            _Txt_Haber.Tag = _Dbl_Haber;//Para guardar
            _Txt_Saldo.Text = Convert.ToDouble(_Dbl_Debe - _Dbl_Haber).ToString("#,##0.00");
            _Txt_Saldo.Tag = Convert.ToDouble(_Dbl_Debe - _Dbl_Haber);//Para guardar
        }
        private bool _Mtd_Auxiliar(string _P_Str_Cuenta)
        {
            //Cuando este lista la interface de Empleados y los Bancos ir modificando el filtro de cclasificauxiliar
            if (_P_Str_Cuenta.Trim().Length > 0)
            {
                string _Str_Cadena = "SELECT ccount FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _P_Str_Cuenta + "' AND cauxiliary='1' AND (cclasificauxiliar='1' OR cclasificauxiliar='2' OR cclasificauxiliar='3' OR cclasificauxiliar='4')";
                return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
            }
            return false;
        }
        private bool _Mtd_MarcarAuxiliar(int _P_Int_RowIndex)
        {
            if (_Mtd_Auxiliar(_Mtd_Cuenta(_P_Int_RowIndex)))
            {
                if (Convert.ToString(_Dg_Grid.Rows[_P_Int_RowIndex].Cells["cidauxiliarcont"].Value).Trim().Length == 0 | Convert.ToString(_Dg_Grid.Rows[_P_Int_RowIndex].Cells["cidauxiliarcont"].Value).Trim() == "0") { return true; }
                else if (_Dg_Grid.Rows[_P_Int_RowIndex].Cells["Tipo"].Value == null) { return true; }
                else if (_Dg_Grid.Rows[_P_Int_RowIndex].Cells["Tipo"].Value.ToString().Trim() == "nulo") { return true; }
                else if (_Dg_Grid.Rows[_P_Int_RowIndex].Cells["Documento"].Value == null) { return true; }
                else if (_Dg_Grid.Rows[_P_Int_RowIndex].Cells["Documento"].Value.ToString().Trim().Length == 0) { return true; }
            }
            return false;
        }
        private void _Mtd_ValidarFila()
        {
            if (_Dg_Grid.RowCount > 0)
            {
                object _Ob_DebeD = new object();
                object _Ob_HaberD = new object();
                if (_Txt_MontoPagar.Text.Trim().Length == 0)
                { _Txt_MontoPagar.Text = "0"; }
                if (Convert.ToDouble(_Txt_MontoPagar.Text) > 0 & !_Dg_Grid.ReadOnly)
                {
                    string _Str_Campos = "";
                    if (Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Cuenta"].Value).Trim().Length == 0)
                    {
                        _Str_Campos = _Str_Campos + "Cuenta, ";
                    }
                    //----------------
                    if (Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Descripcion"].Value).Trim().Length == 0)
                    {
                        _Str_Campos = _Str_Campos + "Descripción del Movimiento, ";
                    }
                    //----------------
                    if (_Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Grid.CurrentCell.RowIndex)))
                    {
                        if (Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cidauxiliarcont"].Value).Trim().Length == 0 | Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cidauxiliarcont"].Value).Trim() == "0")
                        {
                            _Str_Campos = _Str_Campos + "Id Auxiliar, ";
                        }
                        if (Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Tipo"].Value).Trim().Length == 0)
                        {
                            _Str_Campos = _Str_Campos + "Tipo de Documento, ";
                        }
                        else if (Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Tipo"].Value).Trim() == "nulo")
                        {
                            _Str_Campos = _Str_Campos + "Tipo de Documento, ";
                        }
                        //-------
                        if (Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Documento"].Value).Trim().Length == 0)
                        {
                            _Str_Campos = _Str_Campos + "Documento, ";
                        }
                    }
                    if (_Str_Campos.Length > 0)
                    {
                        _Lbl_DgInformacion.Visible = false;
                        _Str_Campos = _Str_Campos.Remove(_Str_Campos.Length - 2);
                        _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.Khaki;
                        MessageBox.Show("Debe introducir los siguientes datos: " + _Str_Campos, "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (_Dg_Grid.CurrentCell.RowIndex == _Dg_Grid.RowCount - 1)
                        {
                            _Dg_Grid.Rows.Add();
                            if (_Bol_DebitoBancarioHabilitado)
                            {
                                _Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Descripcion"].Value = _Dg_Grid.Rows[0].Cells["Descripcion"].Value;
                            }
                            else
                            {
                                _Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Descripcion"].Value = _Dg_Grid.Rows[_Dg_Grid.RowCount - 2].Cells["Descripcion"].Value;                                
                            }
                            _Mtd_CalcularDebeoHaber();
                            _Lbl_DgInformacion.Visible = !_Mtd_VerificarDocExistente(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex]);
                        }
                    }
                    _Mtd_CalcularTotales();
                }
            }
        }
        private bool _Mtd_VerificarFormulario()
        {
            _Dg_Grid.EndEdit();
            bool _Bol_Cuenta = false;
            bool _Bol_FilaValidada = false;
            if (_Dg_Grid.RowCount > 0)
            {
                object _Ob_DebeD = new object();
                object _Ob_HaberD = new object();
                if (_Txt_MontoPagar.Text.Trim().Length == 0)
                { _Txt_MontoPagar.Text = "0"; }
                if (Convert.ToDouble(_Txt_MontoPagar.Text) > 0 & !_Txt_MontoPagar.ReadOnly)
                {
                    //-----------------------------------------Esto es para que valide la ultima fila en _Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Grid.CurrentCell.RowIndex))
                    _Dg_Cel = _Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["BotonCuenta"];
                    try
                    {
                        _Dg_Grid.CurrentCell = _Dg_Cel;
                    }
                    catch { }
                    //-----------------------------------------
                    if (_Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Cuenta"].Value == null) { _Bol_Cuenta = true; }
                    else if (_Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Cuenta"].Value.ToString().Trim().Length == 0) { _Bol_Cuenta = true; }
                    else
                    {
                        //----------------
                        if (_Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Descripcion"].Value == null) { return false; }
                        else if (_Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Descripcion"].Value.ToString().Trim().Length == 0) { return false; }
                        //----------------
                        if (_Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Grid.CurrentCell.RowIndex)))
                        {
                            if (Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["cidauxiliarcont"].Value).Trim().Length == 0 | Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["cidauxiliarcont"].Value).Trim() == "0") { return false; }
                            else if (_Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Tipo"].Value == null) { return false; }
                            else if (_Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Tipo"].Value.ToString().Trim() == "nulo") { return false; }
                            else if (_Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Documento"].Value == null) { return false; }
                            else if (_Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells["Documento"].Value.ToString().Trim().Length == 0) { return false; }
                        }
                        _Bol_FilaValidada = true;
                    }
                    if ((_Bol_Cuenta & _Dg_Grid.RowCount > 1) | _Bol_FilaValidada)//Esto es para saber si la ultima fila se debe tomar en cuenta
                    { return true; }
                    else
                    { return false; }
                }
                else
                { return false; }
            }
            return false;
        }
        //private bool _Mtd_VerificarDocExistentes()
        //{
        //    string _Str_TipoDocFACT_CxC = _Cls_Variosmetodos._Mtd_TipoDocument_CXC("ctipdocfact");
        //    string _Str_TipoDocNC_CxC = _Cls_Variosmetodos._Mtd_TipoDocument_CXC("ctipdocnotcred");
        //    string _Str_TipoDocND_CxC = _Cls_Variosmetodos._Mtd_TipoDocument_CXC("ctipdocnotdeb");
        //    //-------------------------
        //    string _Str_TipoDocFACT_CxP = _Cls_Variosmetodos._Mtd_TipoDocumentFACT_CXP("ctipdocfact");
        //    string _Str_TipoDocNC_CxP = _Cls_Variosmetodos._Mtd_TipoDocumentFACT_CXP("ctipodocnc");
        //    string _Str_TipoDocND_CxP = _Cls_Variosmetodos._Mtd_TipoDocumentFACT_CXP("ctipodocnd");
        //    string _Str_TipoDocRETIVA = _Cls_Variosmetodos._Mtd_TipoDocumentFACT_CXP("ctipdocretiva");
        //    string _Str_TipoDocRETISLR = _Cls_Variosmetodos._Mtd_TipoDocumentFACT_CXP("ctipdocretislr");
        //    //-------------------------
        //    DataSet _Ds;
        //    string _Str_Cadena = "";
        //    bool _Bol_Return = true;
        //    bool _Bol_ColorKhaki = false;
        //    foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
        //    {
        //        if (_Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Row.Index)))
        //        {
        //            _Str_Cadena = "SELECT cclasificauxiliar FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Mtd_Cuenta(_Dg_Row.Index) + "'";
        //            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
        //            if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1")
        //            {
        //                if (Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim().ToUpper() == _Str_TipoDocFACT_CxC.ToUpper())
        //                {
        //                    if (_Cls_Variosmetodos._Mtd_IsNumeric(Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim()))
        //                    {
        //                        _Str_Cadena = "SELECT cfactura FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim() + "' AND cfactura='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
        //                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
        //                        { _Bol_ColorKhaki = true; }
        //                    }
        //                    else
        //                    { _Bol_ColorKhaki = true; }
        //                }
        //                else if (Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim().ToUpper() == _Str_TipoDocNC_CxC.ToUpper())
        //                {
        //                    if (_Cls_Variosmetodos._Mtd_IsNumeric(Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim()))
        //                    {
        //                        _Str_Cadena = "SELECT cidnotcredicc FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim() + "' AND cidnotcredicc='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
        //                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
        //                        { _Bol_ColorKhaki = true; }
        //                    }
        //                    else
        //                    { _Bol_ColorKhaki = true; }
        //                }
        //                else if (Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim().ToUpper() == _Str_TipoDocND_CxC.ToUpper())
        //                {
        //                    if (_Cls_Variosmetodos._Mtd_IsNumeric(Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim()))
        //                    {
        //                        _Str_Cadena = "SELECT cidnotadebitocc FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim() + "' AND cidnotadebitocc='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
        //                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
        //                        { _Bol_ColorKhaki = true; }
        //                    }
        //                    else
        //                    { _Bol_ColorKhaki = true; }
        //                }
        //            }
        //            else if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "2" | _Ds.Tables[0].Rows[0][0].ToString().Trim() == "3" | _Ds.Tables[0].Rows[0][0].ToString().Trim() == "4")
        //            {
        //                _Str_Cadena = "SELECT cnumdocu FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim() + "' AND ctipodocument='" + Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim() + "' AND cnumdocu='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
        //                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
        //                { _Bol_ColorKhaki = true; }
        //            }
        //            //-----------------
        //            if (_Bol_ColorKhaki) { _Dg_Row.DefaultCellStyle.BackColor = Color.Khaki; }
        //            else { _Dg_Row.DefaultCellStyle.BackColor = Color.White; }
        //            //-----------------
        //            if (_Bol_ColorKhaki) { _Bol_Return = false; }
        //        }
        //    }
        //    return _Bol_Return;
        //}
        private bool _Mtd_VerificarDocExistente(DataGridViewRow _Dg_Row)
        {
            string _Str_TipoDocFACT_CxC = _Cls_Variosmetodos._Mtd_TipoDocument_CXC("ctipdocfact");
            string _Str_TipoDocNC_CxC = _Cls_Variosmetodos._Mtd_TipoDocument_CXC("ctipdocnotcred");
            string _Str_TipoDocND_CxC = _Cls_Variosmetodos._Mtd_TipoDocument_CXC("ctipdocnotdeb");
            //-------------------------
            string _Str_TipoDocFACT_CxP = _Cls_Variosmetodos._Mtd_TipoDocumentFACT_CXP("ctipdocfact");
            string _Str_TipoDocNC_CxP = _Cls_Variosmetodos._Mtd_TipoDocumentFACT_CXP("ctipodocnc");
            string _Str_TipoDocND_CxP = _Cls_Variosmetodos._Mtd_TipoDocumentFACT_CXP("ctipodocnd");
            string _Str_TipoDocRETIVA = _Cls_Variosmetodos._Mtd_TipoDocumentFACT_CXP("ctipdocretiva");
            string _Str_TipoDocRETISLR = _Cls_Variosmetodos._Mtd_TipoDocumentFACT_CXP("ctipdocretislr");
            //-------------------------
            DataSet _Ds;
            string _Str_Cadena = "";
            bool _Bol_Return = true;
            bool _Bol_ColorKhaki = false;
            if (_Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Row.Index)))
            {
                _Str_Cadena = "SELECT cclasificauxiliar FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Mtd_Cuenta(_Dg_Row.Index) + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1")
                {
                    if (Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim().ToUpper() == _Str_TipoDocFACT_CxC.ToUpper())
                    {
                        if (_Cls_Variosmetodos._Mtd_IsNumeric(Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim()))
                        {
                            _Str_Cadena = "SELECT cfactura FROM TFACTURAM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim() + "' AND cfactura='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
                            { _Bol_ColorKhaki = true; }
                        }
                        else
                        { _Bol_ColorKhaki = true; }
                    }
                    else if (Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim().ToUpper() == _Str_TipoDocNC_CxC.ToUpper())
                    {
                        if (_Cls_Variosmetodos._Mtd_IsNumeric(Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim()))
                        {
                            _Str_Cadena = "SELECT cidnotcredicc FROM TNOTACREDICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim() + "' AND cidnotcredicc='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
                            { _Bol_ColorKhaki = true; }
                        }
                        else
                        { _Bol_ColorKhaki = true; }
                    }
                    else if (Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim().ToUpper() == _Str_TipoDocND_CxC.ToUpper())
                    {
                        if (_Cls_Variosmetodos._Mtd_IsNumeric(Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim()))
                        {
                            _Str_Cadena = "SELECT cidnotadebitocc FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim() + "' AND cidnotadebitocc='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
                            { _Bol_ColorKhaki = true; }
                        }
                        else
                        { _Bol_ColorKhaki = true; }
                    }
                    //-------------
                    if (_Bol_ColorKhaki)
                    {
                        _Str_Cadena = "SELECT cnumdocu FROM TDOCVARIOS WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ctipoentidad='0' AND centidad='" + Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim() + "' AND ctipodocument='" + Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim() + "' AND cnumdocu='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                        { _Bol_ColorKhaki = false; }
                    }
                    //-------------
                }
                else if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "2" | _Ds.Tables[0].Rows[0][0].ToString().Trim() == "3" | _Ds.Tables[0].Rows[0][0].ToString().Trim() == "4")
                {
                    _Str_Cadena = "SELECT cnumdocu FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim() + "' AND ctipodocument='" + Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim() + "' AND cnumdocu='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
                    { _Bol_ColorKhaki = true; }
                    //-------------
                    if (_Bol_ColorKhaki)
                    {
                        _Str_Cadena = "SELECT cnumdocu FROM TDOCVARIOS WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ctipoentidad='1' AND centidad='" + Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim() + "' AND ctipodocument='" + Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim() + "' AND cnumdocu='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                        { _Bol_ColorKhaki = false; }
                    }
                    //-------------
                }
                else if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "5")
                {
                    _Str_Cadena = "SELECT cnumdocu FROM TDOCVARIOS WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ctipoentidad='2' AND centidad='" + Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim() + "' AND ctipodocument='" + Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim() + "' AND cnumdocu='" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
                    { _Bol_ColorKhaki = true; }
                }
                //-----------------
                if (_Bol_ColorKhaki) { _Dg_Row.DefaultCellStyle.BackColor = Color.Khaki; }
                else { _Dg_Row.DefaultCellStyle.BackColor = Color.White; }
                //-----------------
                if (_Bol_ColorKhaki) { _Bol_Return = false; }
            }
            return _Bol_Return;
        }
        private bool _Mtd_VerificarDocExistentes()
        {
            bool _Bol_Return = true;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (!_Mtd_VerificarDocExistente(_Dg_Row))
                { _Bol_Return = false; }
            }
            _Lbl_DgInformacion.Visible = !_Bol_Return;
            return _Bol_Return;
        }
        private bool _Mtd_VerificarIdAuxTipDocNumDocNull()
        {
            bool _Bol_Return = false;
            bool _Bol_ColorKhaki = false;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                _Bol_ColorKhaki = false;
                if (_Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Row.Index)))
                {
                    if (Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim().Length == 0 | Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim() == "0") { _Bol_ColorKhaki = true; }
                    else if (_Dg_Row.Cells["Tipo"].Value == null) { _Bol_ColorKhaki = true; }
                    else if (_Dg_Row.Cells["Tipo"].Value.ToString().Trim() == "nulo") { _Bol_ColorKhaki = true; }
                    else if (_Dg_Row.Cells["Documento"].Value == null) { _Bol_ColorKhaki = true; }
                    else if (_Dg_Row.Cells["Documento"].Value.ToString().Trim().Length == 0) { _Bol_ColorKhaki = true; }
                    //-----------------
                    if (_Bol_ColorKhaki) { _Dg_Row.DefaultCellStyle.BackColor = Color.Khaki; }
                    else { _Dg_Row.DefaultCellStyle.BackColor = Color.White; }
                    //-----------------
                    if (_Bol_ColorKhaki) { _Bol_Return = true; }
                }
            }
            return _Bol_Return;
        }
        public int _Mtd_ActualizarComprobanteOtros()
        {
            string _Str_DesComp = "";
            string _Str_TipComp = "";
            string _Str_ProcesoCont = _Mtd_ProcesoCont(Convert.ToString(_Txt_Beneficiario.Tag).Trim());
            string _Str_Cadena = "";
            DataSet _Ds;
            Clases._Cls_ProcesosCont _Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont(_Str_ProcesoCont);
            _Str_DesComp = _Cls_ProcesosCont._Field_ConceptoComprobante;
            _Str_TipComp = _Cls_ProcesosCont._Field_TipoComprobante;
            int _Int_Comprobante = 0;
            //-----------------------
            string _Str_MesCont = Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            string _Str_AnoCont = Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            //-----------------------
            if (_Txt_OrdenPago.Text.Trim().Length == 0)
            {
                _Int_Comprobante = _Cls_Variosmetodos._Mtd_Consecutivo_TCOMPROBANC();
                _Str_Cadena = "INSERT INTO TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,clvalidado,cdateadd,cuseradd,csistema)VALUES('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante + "','" + _Str_TipComp + "','" + _Str_DesComp + "','" + _Str_AnoCont + "','" + _Str_MesCont + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Debe.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Haber.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Saldo.Text)) + "','0','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','0')";
            }
            else
            {
                _Str_Cadena = "SELECT cidcomprob FROM TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Txt_OrdenPago.Text + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Int_Comprobante = Convert.ToInt32(_Ds.Tables[0].Rows[0][0]);
                    _Str_Cadena = "DELETE FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Int_Comprobante + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "DELETE FROM TCOMPROBANDD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Int_Comprobante + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "DELETE FROM TMOVAUXILIARCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Int_Comprobante + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "UPDATE TCOMPROBANC SET ctypcomp='" + _Str_TipComp + "',cname='" + _Str_DesComp + "',cyearacco='" + Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "',cmontacco='" + Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())) + "',cregdate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Debe.Text)) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Haber.Text)) + "',cbalance='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Saldo.Text)) + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Int_Comprobante + "'";
                }
            }
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            //-----------------------
            string _Str_ID_Auxiliar = "";
            string _Str_Tipo = "";
            string _Str_Documento = "";
            object _Ob_DebeD = new object();
            object _Ob_HaberD = new object();
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                if (_Dg_Row.Cells["Cuenta"].Value != null)
                {
                    if (_Dg_Row.Cells["Cuenta"].Value.ToString().Trim().Length > 0)
                    {
                        //------------------------------------------------------------------------
                        if (_Dg_Row.Cells["Tipo"].Value == null) { _Str_Tipo = "0"; }
                        else if (_Dg_Row.Cells["Tipo"].Value.ToString().Trim() == "nulo") { _Str_Tipo = "0"; }
                        else { _Str_Tipo = _Dg_Row.Cells["Tipo"].Value.ToString().Trim(); }
                        //-----------
                        if (_Dg_Row.Cells["Documento"].Value == null) { _Str_Documento = "0"; }
                        else if (_Dg_Row.Cells["Documento"].Value.ToString().Trim() == "nulo") { _Str_Documento = "0"; }
                        else { _Str_Documento = _Dg_Row.Cells["Documento"].Value.ToString().Trim(); }
                        //------------------------------------------------------------------------
                        _Ob_DebeD = _Dg_Row.Cells["Debe"].Value;
                        if (_Ob_DebeD == null)
                        { _Ob_DebeD = 0; }
                        else if (_Ob_DebeD.ToString().Trim().Length == 0)
                        { _Ob_DebeD = 0; }
                        //---------------------------
                        _Ob_HaberD = _Dg_Row.Cells["Haber"].Value;
                        if (_Ob_HaberD == null)
                        { _Ob_HaberD = 0; }
                        else if (_Ob_HaberD.ToString().Trim().Length == 0)
                        { _Ob_HaberD = 0; }
                        //------------------------------------------------------------------------
                        _Str_ID_Auxiliar = "";
                        if (Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim().Length > 0)
                        { _Str_ID_Auxiliar = Convert.ToString(_Dg_Row.Cells["cidauxiliarcont"].Value).Trim(); }
                        //------------------------------------------------------------------------
                        _Str_Cadena = "INSERT INTO TCOMPROBAND (ccompany,cidcomprob,corder,ccount,cdescrip,ctdocument,cnumdocu,ctotdebe,ctothaber,cdateadd,cuseradd)VALUES('" + Frm_Padre._Str_Comp + "','" + _Int_Comprobante + "','" + (_Dg_Row.Index + 1) + "','" + Convert.ToString(_Dg_Row.Cells["Cuenta"].Value).Trim() + "','" + Convert.ToString(_Dg_Row.Cells["Descripcion"].Value).Trim().ToUpper().Replace("'", "''") + "','" + Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim() + "','" + Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_DebeD)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_HaberD)) + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        if (Convert.ToDouble(_Ob_DebeD) > 0)
                        { CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(), Convert.ToString(_Dg_Row.Cells["Cuenta"].Value).Trim(), _Str_ID_Auxiliar, Convert.ToString(_Dg_Row.Cells["Descripcion"].Value).Trim().ToString().ToUpper(), Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim(), Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim(), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_DebeD)), _Str_MesCont, _Str_AnoCont, "D", Convert.ToString(_Dg_Row.Index + 1)); }
                        else if (Convert.ToDouble(_Ob_HaberD) > 0)
                        { CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(), Convert.ToString(_Dg_Row.Cells["Cuenta"].Value).Trim(), _Str_ID_Auxiliar, Convert.ToString(_Dg_Row.Cells["Descripcion"].Value).Trim().ToString().ToUpper(), Convert.ToString(_Dg_Row.Cells["Tipo"].Value).Trim(), Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim(), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()), CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_HaberD)), _Str_MesCont, _Str_AnoCont, "H", Convert.ToString(_Dg_Row.Index + 1)); }
                    }
                }
            }
            return _Int_Comprobante;
        }
        private void _Mtd_ActualizarPagosOtros(int _P_Int_Comprobante)
        {
            string _Str_TipoP = "";
            string _Str_Cadena = "";
            string _Str_Id_Pagos = "";
            if (_Rb_Abo.Checked)
            { _Str_TipoP = "ABO"; }
            else
            { _Str_TipoP = "PTOT"; }
            if (_Txt_OrdenPago.Text.Trim().Length == 0)
            {
                _Str_Cadena = "Select Max(cidordpago) FROM TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                _Str_Id_Pagos = _Cls_Variosmetodos._Mtd_Correlativo(_Str_Cadena);
                _Str_Cadena = "INSERT INTO TPAGOSCXPM (cgroupcomp,ccompany,cidordpago,cproveedor,ctipotrospago,ctippago,cfpago,cfecha,cuserfirmante,cmontototal,cbanco,cnumcuentad,cidcomprob,cbeneficiario,cconcepto,cotrospago,crif) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_Id_Pagos + "','" + _Txt_Beneficiario.Tag + "','" + _Cb_TpoPagoOtros.SelectedValue + "','" + _Str_TipoP + "','" + (_Rb_ChequeO.Checked ? "CHEQ" : "TRANSF") + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + Frm_Padre._Str_Use + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_MontoPagar.Text)) + "','" + _Cb_Banco_Otros.SelectedValue + "','" + _Cb_Cuenta_Otros.SelectedValue + "','" + _P_Int_Comprobante + "','" + _Txt_Beneficiario.Text.ToUpper() + "','" + _Txt_Concepto.Text.ToUpper() + "','1','" + _Txt_Rif.Text + "')";
            }
            else
            {
                _Str_Cadena = "UPDATE TPAGOSCXPM SET crif='" + _Txt_Rif.Text + "',cproveedor='" + _Txt_Beneficiario.Tag + "',ctipotrospago='" + _Cb_TpoPagoOtros.SelectedValue + "',ctippago='" + _Str_TipoP + "',cfpago='" + (_Rb_ChequeO.Checked ? "CHEQ" : "TRANSF") + "',cfecha='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cuserfirmante='" + Frm_Padre._Str_Use + "',cmontototal='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_MontoPagar.Text)) + "',cbanco='" + _Cb_Banco_Otros.SelectedValue + "',cnumcuentad='" + _Cb_Cuenta_Otros.SelectedValue + "',cidcomprob='" + _P_Int_Comprobante + "',cbeneficiario='" + _Txt_Beneficiario.Text.ToUpper() + "',cconcepto='" + _Txt_Concepto.Text.ToUpper() + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Txt_OrdenPago.Text + "'";
            }
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }

        private void _Mtd_CargarFormularioOtros(object _P_Ob_Id_Pago)
        {
            //---------------------------
            _Mtd_CargarComboGrid((DataGridViewComboBoxColumn)_Dg_Grid.Columns["Tipo"]);
            _Dg_Grid.Rows.Clear();
            _Dg_Grid.ReadOnly = true; _Dg_Grid.Columns["cidauxiliarcont"].ReadOnly = true;
            //---------------------------
            string _Str_Comprobante = "";
            string _Str_Cadena = " SELECT crif,cproveedor,ctipotrospago,ctippago,cfpago,cfecha,cmontototal,cbanco,cnumcuentad,cidcomprob,cbeneficiario,cconcepto FROM TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _P_Ob_Id_Pago + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_OrdenPago.Text = _P_Ob_Id_Pago.ToString();
                _Txt_FechaOP.Text = _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfecha"]));
                _Cb_Banco_Otros.SelectedValue = _Ds.Tables[0].Rows[0]["cbanco"].ToString().Trim();
                _Cb_Cuenta_Otros.SelectedIndexChanged -= new EventHandler(_Cb_Cuenta_Otros_SelectedIndexChanged);
                _Cb_Cuenta_Otros.SelectedValue = _Ds.Tables[0].Rows[0]["cnumcuentad"].ToString().Trim();
                _Cb_Cuenta_Otros.SelectedIndexChanged += new EventHandler(_Cb_Cuenta_Otros_SelectedIndexChanged);
                _Cb_TpoPagoOtros.SelectedValue = _Ds.Tables[0].Rows[0]["ctipotrospago"].ToString().Trim();
                if (_Ds.Tables[0].Rows[0]["ctippago"].ToString().Trim().ToUpper() == "ABO")
                { _Rb_Abo.Checked = true; }
                else
                { _Rb_Pag.Checked = true; }
                if (_Ds.Tables[0].Rows[0]["cfpago"].ToString().Trim().ToUpper() == "CHEQ")
                { _Rb_ChequeO.Checked = true; }
                else
                { _Rb_TransfO.Checked = true; }
                _Txt_Beneficiario.Text = _Ds.Tables[0].Rows[0]["cbeneficiario"].ToString();
                _Txt_Beneficiario.Tag = _Ds.Tables[0].Rows[0]["cproveedor"];
                if (_Ds.Tables[0].Rows[0]["cproveedor"].ToString().Trim().Length > 0 && _Ds.Tables[0].Rows[0]["crif"].ToString().Trim().Length==0)
                {
                    _Mtd_BuscarRifProveedor(_Ds.Tables[0].Rows[0]["cproveedor"].ToString().Trim());
                }
                else
                {
                    if (_Ds.Tables[0].Rows[0]["crif"].ToString().Split('-').Count() > 2)
                    {
                        _Rbt_Rif.Checked = true;
                    }
                    else
                    {
                        _Rbt_Cedula.Checked = true;
                    }
                    _Txt_Rif.Text = _Ds.Tables[0].Rows[0]["crif"].ToString();
                }
                _Txt_Concepto.Text = _Ds.Tables[0].Rows[0]["cconcepto"].ToString();
                if (_Ds.Tables[0].Rows[0]["cmontototal"] != System.DBNull.Value)
                { _Txt_MontoPagar.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototal"]).ToString("#,##0.00"); }
                _Str_Comprobante = _Ds.Tables[0].Rows[0]["cidcomprob"].ToString();
            }
            if (_Str_Comprobante.Trim().Length > 0)
            {
                _Str_Cadena = "SELECT ctotdebe,ctothaber,cbalance FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Comprobante + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0]["ctotdebe"] != System.DBNull.Value)
                    { _Txt_Debe.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotdebe"]).ToString("#,##0.00"); }
                    if (_Ds.Tables[0].Rows[0]["ctothaber"] != System.DBNull.Value)
                    { _Txt_Haber.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctothaber"]).ToString("#,##0.00"); }
                    if (_Ds.Tables[0].Rows[0]["cbalance"] != System.DBNull.Value)
                    { _Txt_Saldo.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cbalance"]).ToString("#,##0.00"); }
                    _Str_Cadena = "SELECT TCOMPROBAND.ccount, TCOMPROBAND.cdescrip, TCOMPROBAND.ctdocument, TCOMPROBAND.cnumdocu, TCOMPROBAND.ctotdebe, TCOMPROBAND.ctothaber, TCOMPROBANDD.cidauxiliarcont FROM TCOMPROBAND LEFT OUTER JOIN TCOMPROBANDD ON TCOMPROBAND.corder = TCOMPROBANDD.corder AND TCOMPROBAND.cidcomprob = TCOMPROBANDD.cidcomprob AND TCOMPROBAND.ccompany = TCOMPROBANDD.ccompany AND TCOMPROBAND.ccount = TCOMPROBANDD.ccount AND TCOMPROBANDD.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBANDD.cidcomprob='" + _Str_Comprobante + "' WHERE TCOMPROBAND.ccompany='" + Frm_Padre._Str_Comp + "' AND TCOMPROBAND.cidcomprob='" + _Str_Comprobante + "' ORDER BY TCOMPROBAND.corder";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    string _Str_DebeD = "";
                    string _Str_HaberD = "";
                    foreach (DataRow _Row in _Ds.Tables[0].Rows)
                    {
                        _Str_DebeD = ""; if (_Row["ctotdebe"] != System.DBNull.Value) { if (Convert.ToDouble(_Row["ctotdebe"]) > 0) { _Str_DebeD = _Row["ctotdebe"].ToString(); } }
                        _Str_HaberD = ""; if (_Row["ctothaber"] != System.DBNull.Value) { if (Convert.ToDouble(_Row["ctothaber"]) > 0) { _Str_HaberD = _Row["ctothaber"].ToString(); } }
                        _Dg_Grid.Rows.Add(new object[] { _Row["ccount"], ' ', _Row["cdescrip"], _Row["cidauxiliarcont"], ' ', _Row["ctdocument"], _Row["cnumdocu"], _Str_DebeD, _Str_HaberD });
                    }
                }
            }
            //-----------------------------
            _Cb_Banco_Otros.Enabled = false;
            _Cb_Cuenta_Otros.Enabled = false;
            _Cb_TpoPagoOtros.Enabled = false;
            _Bt_Beneficiario.Enabled = false;            
            _Bt_Edit_1.Enabled = false;
            _Bt_Edit_2.Enabled = false;
            _Bt_Edit_3.Enabled = false;
            _Txt_Beneficiario.Enabled = false;
            _Txt_Concepto.Enabled = false;
            _Txt_MontoPagar.Enabled = false;
            if (_Dg_Grid.RowCount > 0)
            {
                _Dg_Cel = _Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells[1];
                _Dg_Grid.CurrentCell = _Dg_Cel;
            }
            //-----------------------------
        }
        //-------------------------------------JUAN-----------------------------------------------------------------
        public Frm_OrdenPago(string _Pr_Str_Val)
        {
            InitializeComponent();
            _Mtd_Ini();
            _Str_InForm = _Pr_Str_Val;
            _Mtd_Dt_NDSelec();
            _Mtd_Dt_NCSelec();
            string _Str_Aux = "";
            _Str_Aux = _Str_InForm;
            if (_Str_InForm == "")
            { _Mtd_Ini(); }
            _Str_InForm = _Str_Aux;
            _Mtd_CargarBancoOtros();
            _Mtd_CargarTipoPago();
            _Mtd_CargarTpoProveFind();
            _Mtd_CargarProvee();
            _Mtd_BotonesMenu();
        }

        public Frm_OrdenPago(string _Pr_Str_Val, DataGridViewRowCollection _Pr_DgRow)
        {
            InitializeComponent();
            _Mtd_Nuevo();
            _Str_InForm = _Pr_Str_Val;
            string _Str_Fact = "";
            string _Str_NC = "";
            string _Str_ND = "";
            string _Str_Ret = "";
            string _Str_RetISLR ="";
            string _Str_ProvRETIVA = "";
            string _Str_ProvRETISLR = "";
            string _Str_ProvRETPATENTE = "";
            string _Str_RetPatente = "";
            string _Str_CxPId = "";
            string _Str_NDP = "";
            string _Str_NCP = "";
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipodocnd,ctipodocnc,ctipdocfact,ctipdocretiva,ctipdocretislr,cprovretislr,cprovretiva,ctipodocndp,ctipodocncp,ctipodocretpat,cprovretpat from TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_Fact = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocfact"]);
                _Str_NC = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnc"]);
                _Str_ND = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnd"]);
                _Str_Ret = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocretiva"]);
                _Str_RetISLR = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocretislr"]);
                _Str_ProvRETIVA = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cprovretiva"]);
                _Str_ProvRETISLR = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cprovretislr"]);
                _Str_NDP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocndp"]);
                _Str_NCP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocncp"]);
                _Str_RetPatente = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocretpat"]);
                _Str_ProvRETPATENTE = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cprovretpat"]);
            }
            
            //CARGO EL PROVEEDOR
            foreach (DataGridViewRow _DgRow in _Pr_DgRow)
            {
                if (_DgRow.DefaultCellStyle.BackColor.Name == Color.Red.Name)
                {
                    _Txt_Prov.Tag = Convert.ToString(_DgRow.Cells["cproveedor"].Value);
                    _Txt_Prov.Text = Convert.ToString(_DgRow.Cells["Proveedor"].Value).Trim();
                    break;
                }
            }

            foreach (DataGridViewRow _DgRow in _Pr_DgRow)
            {
                //if (_DgRow.DefaultCellStyle.BackColor == Color.Red && Convert.ToString(_DgRow.Cells[9].Value)!="1")
                if (_DgRow.DefaultCellStyle.BackColor.Name == Color.Red.Name)
                {
                    //primero meto las facturas
                    if (Convert.ToString(_DgRow.Cells["ctipodocument"].Value).Trim() == _Str_Fact.Trim() | Convert.ToString(_DgRow.Cells["ctipodocument"].Value).Trim() == _Str_NDP.Trim() | Convert.ToString(_DgRow.Cells["ctipodocument"].Value).Trim() == _Str_NCP.Trim())
                    {
                        _Dg_OrdPagoDet.Rows.Add();
                        _Dg_OrdPagoDet[0, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Emisión"].Value;
                        _Dg_OrdPagoDet[1, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Vencimiento"].Value;
                        _Dg_OrdPagoDet[2, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Documento"].Value;
                        _Dg_OrdPagoDet[3, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Tipo"].Value;
                        _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Monto"].Value;
                        _Dg_OrdPagoDet[5, _Dg_OrdPagoDet.RowCount - 1].Value = "0";
                        _Dg_OrdPagoDet[6, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["cidfactxp"].Value;
                        _Dg_OrdPagoDet[7, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["ctotalimp"].Value;
                        _Dg_OrdPagoDet[8, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["ctipodocument"].Value;
                        _Dg_OrdPagoDet[11, _Dg_OrdPagoDet.RowCount - 1].Value = "1";
                        _Str_FrmNRecepcion = Convert.ToString(_DgRow.Cells["cidnotrecepc"].Value);
                    }
                }
            }

            //meto las notas de credito
            foreach (DataGridViewRow _DgRow in _Pr_DgRow)
            {
                if (_DgRow.DefaultCellStyle.BackColor.Name == Color.Red.Name)
                {
                    if (Convert.ToString(_DgRow.Cells["ctipodocument"].Value).Trim() == _Str_NC.Trim())
                    {
                        _Dg_OrdPagoDet.Rows.Add();
                        _Dg_OrdPagoDet[0, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Emisión"].Value;
                        _Dg_OrdPagoDet[1, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Vencimiento"].Value;
                        _Dg_OrdPagoDet[2, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Documento"].Value;
                        _Dg_OrdPagoDet[3, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Tipo"].Value;
                        _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Monto"].Value;
                        _Dg_OrdPagoDet[5, _Dg_OrdPagoDet.RowCount - 1].Value = "0";
                        _Dg_OrdPagoDet[6, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["cidfactxp"].Value;
                        _Dg_OrdPagoDet[7, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["ctotalimp"].Value;
                        _Dg_OrdPagoDet[8, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["ctipodocument"].Value;
                        _Dg_OrdPagoDet[11, _Dg_OrdPagoDet.RowCount - 1].Value = "1";
                    }
                }
            }

            //meto las notas de debito
            foreach (DataGridViewRow _DgRow in _Pr_DgRow)
            {
                if (_DgRow.DefaultCellStyle.BackColor.Name == Color.Red.Name)
                {
                    if (Convert.ToString(_DgRow.Cells["ctipodocument"].Value).Trim() == _Str_ND.Trim())
                    {
                        _Dg_OrdPagoDet.Rows.Add();
                        _Dg_OrdPagoDet[0, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Emisión"].Value;
                        _Dg_OrdPagoDet[1, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Vencimiento"].Value;
                        _Dg_OrdPagoDet[2, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Documento"].Value;
                        _Dg_OrdPagoDet[3, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Tipo"].Value;
                        _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Monto"].Value;
                        _Dg_OrdPagoDet[5, _Dg_OrdPagoDet.RowCount - 1].Value = "0";
                        _Dg_OrdPagoDet[6, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["cidfactxp"].Value;
                        _Dg_OrdPagoDet[7, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["ctotalimp"].Value;
                        _Dg_OrdPagoDet[8, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["ctipodocument"].Value;
                        _Dg_OrdPagoDet[11, _Dg_OrdPagoDet.RowCount - 1].Value = "1";
                    }
                }
            }

            //EXAMINO FACTURA POR FACTURA LAS ND Y NC ASOCIADAS A LA FACT QUE ESTEN EN LA RETENCION DE IVA
            foreach (DataGridViewRow _DgRow in _Pr_DgRow)
            {
                if (_DgRow.DefaultCellStyle.BackColor.Name == Color.Red.Name)
                {
                    if (Convert.ToString(_DgRow.Cells["ctipodocument"].Value).Trim() == _Str_Fact.Trim() | Convert.ToString(_DgRow.Cells["ctipodocument"].Value).Trim() == _Str_NDP.Trim())
                    {
                        _Str_CxPId = Convert.ToString(_DgRow.Cells["cidfactxp"].Value);
                        _Mtd_AnexarNDyNC(_Str_CxPId);
                    }
                }
            }
            
            //meto las retenciones DE IVA---
            foreach (DataGridViewRow _DgRow in _Pr_DgRow)
            {
                if (Convert.ToString(_DgRow.Cells["ctipodocument"].Value).Trim() == _Str_Ret.Trim())
                {
                    if (_DgRow.DefaultCellStyle.BackColor.Name == Color.Red.Name)
                    {
                        _Dg_OrdPagoDet.Rows.Add();
                        _Dg_OrdPagoDet[0, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Emisión"].Value;
                        _Dg_OrdPagoDet[1, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Vencimiento"].Value;
                        _Dg_OrdPagoDet[2, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Documento"].Value;
                        _Dg_OrdPagoDet[3, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Tipo"].Value;
                        if (Convert.ToString(_DgRow.Cells["cproveedor"].Value) == _Str_ProvRETIVA)
                        {
                            if (_Mtd_TipoDocumentAfecReteIva(Convert.ToString(_DgRow.Cells["Documento"].Value)) == _Str_NCP)
                            { _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["Monto"].Value); }
                            else
                            { _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["Monto"].Value).Replace("-", ""); }
                        }
                        else
                        {
                            _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Monto"].Value;
                        }
                        
                        _Dg_OrdPagoDet[5, _Dg_OrdPagoDet.RowCount - 1].Value = "0";
                        _Dg_OrdPagoDet[6, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["cidfactxp"].Value;
                        _Dg_OrdPagoDet[7, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["ctotalimp"].Value;
                        _Dg_OrdPagoDet[8, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["ctipodocument"].Value;
                        _Dg_OrdPagoDet[11, _Dg_OrdPagoDet.RowCount - 1].Value = "1";
                    }
                    
                }
            }

            foreach (DataGridViewRow _DgRow in _Pr_DgRow)
            {
                if (_DgRow.DefaultCellStyle.BackColor.Name == Color.Red.Name)
                {
                    if (Convert.ToString(_DgRow.Cells["ctipodocument"].Value).Trim() == _Str_Fact.Trim() | Convert.ToString(_DgRow.Cells["ctipodocument"].Value).Trim() == _Str_NDP.Trim() | Convert.ToString(_DgRow.Cells["ctipodocument"].Value).Trim() == _Str_NCP.Trim())
                    {
                        _Str_CxPId = Convert.ToString(_DgRow.Cells["cidfactxp"].Value);
                        _Mtd_AnexarRetenciones(_Str_CxPId);
                    }
                }
            }
            
            //INGRESO LAS RETENCIONES DE ISLR ASOCIADAS A LA FACTURA
            foreach (DataGridViewRow _DgRow in _Pr_DgRow)
            {
                if (Convert.ToString(_DgRow.Cells["ctipodocument"].Value).Trim() == _Str_RetISLR.Trim())
                {
                    if (_DgRow.DefaultCellStyle.BackColor.Name == Color.Red.Name)
                    {
                        _Dg_OrdPagoDet.Rows.Add();
                        _Dg_OrdPagoDet[0, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Emisión"].Value;
                        _Dg_OrdPagoDet[1, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Vencimiento"].Value;
                        _Dg_OrdPagoDet[2, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Documento"].Value;
                        _Dg_OrdPagoDet[3, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Tipo"].Value;
                        if (Convert.ToString(_DgRow.Cells["cproveedor"].Value) == _Str_ProvRETISLR)
                        {
                            _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["Monto"].Value).Replace("-", "");
                        }
                        else
                        {
                            if (Convert.ToString(_DgRow.Cells["Monto"].Value).Substring(0, 1) == "-")
                            { _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Monto"].Value; }
                            else
                            { _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = "-" + Convert.ToString(_DgRow.Cells["Monto"].Value); }

                            //_Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells[6].Value;
                        }
                        _Dg_OrdPagoDet[5, _Dg_OrdPagoDet.RowCount - 1].Value = "0";
                        _Dg_OrdPagoDet[6, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["cidfactxp"].Value;
                        _Dg_OrdPagoDet[7, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["ctotalimp"].Value;
                        _Dg_OrdPagoDet[8, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["ctipodocument"].Value;
                        _Dg_OrdPagoDet[11, _Dg_OrdPagoDet.RowCount - 1].Value = "1";
                    }
                }
            }
           
            foreach (DataGridViewRow _DgRow in _Pr_DgRow)
            {
                if (_DgRow.DefaultCellStyle.BackColor.Name == Color.Red.Name)
                {
                    if (Convert.ToString(_DgRow.Cells["ctipodocument"].Value).Trim() == _Str_Fact.Trim() | Convert.ToString(_DgRow.Cells["ctipodocument"].Value).Trim() == _Str_NDP.Trim())
                    {
                        _Str_CxPId = Convert.ToString(_DgRow.Cells["cidfactxp"].Value);
                        _Mtd_AnexarRetencionISLR(_Str_CxPId);
                    }
                }
            }
            //INGRESO LAS RETENCIONES DE PATENTE ASOCIADAS A LA FACTURA
            foreach (DataGridViewRow _DgRow in _Pr_DgRow)
            {
                if (Convert.ToString(_DgRow.Cells["ctipodocument"].Value).Trim() == _Str_RetPatente.Trim())
                {
                    if (_DgRow.DefaultCellStyle.BackColor.Name == Color.Red.Name)
                    {
                        _Dg_OrdPagoDet.Rows.Add();
                        _Dg_OrdPagoDet[0, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Emisión"].Value;
                        _Dg_OrdPagoDet[1, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Vencimiento"].Value;
                        _Dg_OrdPagoDet[2, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Documento"].Value;
                        _Dg_OrdPagoDet[3, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Tipo"].Value;
                        if (Convert.ToString(_DgRow.Cells["cproveedor"].Value) == _Str_ProvRETPATENTE)
                        {
                            _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["Monto"].Value).Replace("-", "");
                        }
                        else
                        {
                            if (Convert.ToString(_DgRow.Cells["Monto"].Value).Substring(0, 1) == "-")
                            { _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Monto"].Value; }
                            else
                            { _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = "-" + Convert.ToString(_DgRow.Cells["Monto"].Value); }

                            //_Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells[6].Value;
                        }
                        _Dg_OrdPagoDet[5, _Dg_OrdPagoDet.RowCount - 1].Value = "0";
                        _Dg_OrdPagoDet[6, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["cidfactxp"].Value;
                        _Dg_OrdPagoDet[7, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["ctotalimp"].Value;
                        _Dg_OrdPagoDet[8, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["ctipodocument"].Value;
                        _Dg_OrdPagoDet[11, _Dg_OrdPagoDet.RowCount - 1].Value = "1";
                    }
                }
            }

            foreach (DataGridViewRow _DgRow in _Pr_DgRow)
            {
                if (_DgRow.DefaultCellStyle.BackColor.Name == Color.Red.Name)
                {
                    if (Convert.ToString(_DgRow.Cells["ctipodocument"].Value).Trim() == _Str_Fact.Trim() | Convert.ToString(_DgRow.Cells["ctipodocument"].Value).Trim() == _Str_NDP.Trim())
                    {
                        _Str_CxPId = Convert.ToString(_DgRow.Cells["cidfactxp"].Value);
                        _Mtd_AnexarRetencionPatente(_Str_CxPId);
                    }
                }
            }
            //meto los avisos de cobro cxc
            //foreach (DataGridViewRow _DgRow in _Pr_DgRow)
            //{
            //    if (_DgRow.DefaultCellStyle.BackColor.Name == Color.Red.Name)
            //    {
            //        if (Convert.ToString(_DgRow.Cells["ctipodocument"].Value).Trim() == _Str_NC.Trim())
            //        {
            //            _Dg_OrdPagoDet.Rows.Add();
            //            _Dg_OrdPagoDet[0, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Emisión"].Value;
            //            _Dg_OrdPagoDet[1, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Vencimiento"].Value;
            //            _Dg_OrdPagoDet[2, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Documento"].Value;
            //            _Dg_OrdPagoDet[3, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Tipo"].Value;
            //            _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["Monto"].Value;
            //            _Dg_OrdPagoDet[5, _Dg_OrdPagoDet.RowCount - 1].Value = "0";
            //            _Dg_OrdPagoDet[6, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["cidfactxp"].Value;
            //            _Dg_OrdPagoDet[7, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["ctotalimp"].Value;
            //            _Dg_OrdPagoDet[8, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells["ctipodocument"].Value;
            //            _Dg_OrdPagoDet[11, _Dg_OrdPagoDet.RowCount - 1].Value = "1";
            //        }
            //    }
            //}


            _Dg_OrdPagoDet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Mtd_UsuarioSts(Frm_Padre._Str_Use);
            _Txt_Usu.Text = _Str_UsuarioName;
            _Txt_Cargo.Text = _Str_UsuarioCargo;
            _Mtd_Dt_NDSelec();
            _Mtd_Dt_NCSelec();
            string _Str_Aux = "";
            _Str_Aux = _Str_InForm;
            if (_Str_InForm == "")
            { _Mtd_Ini(); }
            _Str_InForm = _Str_Aux;
            _Mtd_CargarTpoProveFind();
            _Mtd_CargarProvee();
            _Mtd_BotonesMenu();
            _Tb_Tab.SelectedIndex = 1;
        }

        public Frm_OrdenPago(string _Pr_Str_Val, string _Pr_Str_Idfactxp, string _Pr_Str_Retencion, string _Pr_Str_NRecepcion)
        {
            InitializeComponent();
            string _Str_Sql = "";
            _Mtd_Nuevo();
            _Str_InForm = _Pr_Str_Val;
            string _Str_Fact = "";
            string _Str_NDP = "";
            double _Dbl_SubTot = 0;
            double _Dbl_Total = 0;
            double _Dbl_MontoSI = 0;
            double _Dbl_MontoExento = 0;
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipodocnd,ctipodocnc,ctipdocfact,ctipodocndp from TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_Fact = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocfact"]);
                _Str_NDP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocndp"]);
            }
            _Str_Sql = "Select c_nomb_abreviado,CONVERT(varchar, cfechaemision, 103) as cfechaemision,CONVERT(varchar, cfechavencimiento, 103) as cfechavencimiento,cnumdocu,cname,ctotalsimp,csaldo,cproveedor,ctotalimp,ctipodocument,ctotmontexcento,ctotal from VST_FACTPPAGARM WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " and ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _Pr_Str_Idfactxp + "'";
            DataSet _Ds_C = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_C.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds_C.Tables[0].Rows[0]["ctotalsimp"])!="")
                {
                    _Dbl_MontoSI = Convert.ToDouble(_Ds_C.Tables[0].Rows[0]["ctotalsimp"]);
                }
                if (Convert.ToString(_Ds_C.Tables[0].Rows[0]["ctotmontexcento"]) != "")
                {
                    _Dbl_MontoExento = Convert.ToDouble(_Ds_C.Tables[0].Rows[0]["ctotmontexcento"]);
                }
                if (Convert.ToString(_Ds_C.Tables[0].Rows[0]["ctotmontexcento"]) != "")
                {
                    _Dbl_Total = Convert.ToDouble(_Ds_C.Tables[0].Rows[0]["ctotal"]);
                }

                _Dbl_SubTot = _Dbl_MontoSI + _Dbl_MontoExento;
                _Txt_Prov.Tag = Convert.ToString(_Ds_C.Tables[0].Rows[0]["cproveedor"]);
                _Txt_Prov.Text = Convert.ToString(_Ds_C.Tables[0].Rows[0][0]).Trim();
                _Dg_OrdPagoDet.Rows.Add();
                _Dg_OrdPagoDet[0, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToString(_Ds_C.Tables[0].Rows[0]["cfechaemision"]);//EMISION
                _Dg_OrdPagoDet[1, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToString(_Ds_C.Tables[0].Rows[0]["cfechavencimiento"]);//VENCIMIENTO
                _Dg_OrdPagoDet[2, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToString(_Ds_C.Tables[0].Rows[0]["cnumdocu"]);//DOCUMENTO
                _Dg_OrdPagoDet[3, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToString(_Ds_C.Tables[0].Rows[0]["cname"]);//TIPO
                _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = _Dbl_Total.ToString("#,##0.00");//MONTO
                //_Dg_OrdPagoDet[5, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToString(_Ds_C.Tables[0].Rows[0]["csaldo"]);//SALDO
                _Dg_OrdPagoDet[6, _Dg_OrdPagoDet.RowCount - 1].Value = _Pr_Str_Idfactxp;
                _Dg_OrdPagoDet[7, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToDouble(_Ds_C.Tables[0].Rows[0]["ctotalimp"]).ToString("#,##0.00") ;//MONTO IMPUESTO
                _Dg_OrdPagoDet[8, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToString(_Ds_C.Tables[0].Rows[0]["ctipodocument"]);//Tipo de Doc (Id)
                _Dg_OrdPagoDet[11, _Dg_OrdPagoDet.RowCount - 1].Value = "1";
                _Str_FrmNRecepcion = _Pr_Str_NRecepcion;
                _Mtd_AnexarNDyNC(_Pr_Str_Idfactxp);
                _Mtd_AnexarRetenciones(_Pr_Str_Idfactxp);
                _Mtd_AnexarRetencionISLR(_Pr_Str_Idfactxp);
            }
            _Mtd_UsuarioSts(Frm_Padre._Str_Use);
            _Dg_OrdPagoDet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Txt_Usu.Text = _Str_UsuarioName;
            _Txt_Cargo.Text = _Str_UsuarioCargo;
            _Mtd_Dt_NDSelec();
            _Mtd_Dt_NCSelec();
            string _Str_Aux = "";
            _Str_Aux = _Str_InForm;
            if (_Str_InForm == "")
            { _Mtd_Ini(); }
            _Str_InForm = _Str_Aux;
            _Mtd_CargarTpoProveFind();
            _Mtd_CargarProvee();
            _Mtd_BotonesMenu();
            _Tb_Tab.SelectedIndex = 1;
        }

        bool _Bol_Sw = false;
        bool _Bol_FGridPago = false;

        string _Str_SwClave = "";
        string _Str_UsuarioFirma = "";
        string _Str_UsuarioCargo = "";
        string _Str_UsuarioName = "";
        public string _Str_InForm = "";
        int _Int_SwProvTpo = 0;
        int _Int_SwProvCarga = 0;
        int _Int_FrmTotComprobSw = 0;
        Control[] _Ctrl_Controles = new Control[7];
        string _Str_MyProceso = "";
        string _Str_DocCancelado = "";
        string _Str_Form_cidcomprob = "";
        string _Str_FrmTpoPago = "";
        string _Str_FrmFPago = "";
        string _Str_FrmNRecepcion = "";
        string _Str_FrmIdDescPPPago = "";
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        LibNumLetras.clsNumerosaLetras _obj_NumerosaLetras = new LibNumLetras.clsNumerosaLetras();

        TextBox _Txt_ColMCancelar;//PARA LA VALIDACION EN EL GRID DE DETALLE DE ORDEN DE PAGO

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
        private void _Mtd_Evento_Activated()
        {
            if (_Bol_Otros)
            {
                _Mtd_Activated();
            }
            else
            {
                CONTROLES._Ctrl_Buscar._frm_Formulario = this;
                CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
                //-------------------------------------------------------
                CONTROLES._Ctrl_Buscar._Er_Control_Error = _Er_Error;
                CONTROLES._Ctrl_Buscar._Bl_Especial = true;
                CONTROLES._Ctrl_Buscar._Txt_BotonCtrl.Text = "";
                CONTROLES._Ctrl_Buscar._txt_text.Text = "";
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";

                if (_Str_MyProceso == "M")
                {
                    CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                }
                else
                {
                    CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
                    //if (_Str_MyProceso == "A")
                    //{ _Rb_Abono.Focus(); }
                }
                _Mtd_BotonesMenu();
                if (!string.IsNullOrEmpty(_Txt_Transaccion.Text) && _Mtd_OrdenIntercompañia(Convert.ToInt32(_Txt_Transaccion.Text)))
                {
                    _Bt_Anticipos.Enabled = false;
                    _Bt_Cerrar.Enabled = false;
                    _Bt_AddDoc.Enabled = false;
                    _Bt_Comprobante.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                }
            }
        }
        private void Frm_OrdenPago_Activated(object sender, EventArgs e)
        {
            _Mtd_Evento_Activated();
        }

        private string _Mtd_TipoDocumentAfecReteIva(string _P_Str_Retencion)
        {
            string _Str_Cadena = "SELECT ctdocument FROM TCOMPROBANRETD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _P_Str_Retencion + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows[0][0].ToString().Trim();
        }

        private void _Mtd_CargarTpoProveFind()
        {
            _Cb_TpoProveFind.SelectedIndexChanged -= new System.EventHandler(_Cb_TpoProveFind_SelectedIndexChanged);
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cb_TpoProveFind.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("SERVICIO", "0"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("MATERIA PRIMA", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("OTROS", "2"));
            _Cb_TpoProveFind.DataSource = _myArrayList;
            _Cb_TpoProveFind.DisplayMember = "Display";
            _Cb_TpoProveFind.ValueMember = "Value";
            _Cb_TpoProveFind.SelectedValue = "nulo";
            _Cb_TpoProveFind.DataSource = _myArrayList;
            _Cb_TpoProveFind.SelectedIndex = 0;
            _Cb_TpoProveFind.SelectedIndexChanged += new System.EventHandler(_Cb_TpoProveFind_SelectedIndexChanged);
        }

        private void Frm_OrdenPago_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Pnl_Clave_Otros.Left = (this.Width / 2) - (_Pnl_Clave_Otros.Width / 2);
            _Pnl_Clave_Otros.Top = (this.Height / 2) - (_Pnl_Clave_Otros.Height / 2);
            //--------------
            _Pnl_Clave_Cerrar.Left = (this.Width / 2) - (_Pnl_Clave_Cerrar.Width / 2);
            _Pnl_Clave_Cerrar.Top = (this.Height / 2) - (_Pnl_Clave_Cerrar.Height / 2);
            _Mtd_Color_Estandar(this);
            _Mtd_Sorted(_Dg_OrdPagoDet);
            _Mtd_Sorted(_Dg_Comprobante);
            _Mtd_Sorted(_Dg_Grid);
            _Mtd_BuscarDatosUsuario();
            _Mtd_Actualizar();
            new CLASES._Cls_Varios_Metodos(true)._Mtd_Inyeccion_Sql(this, true);
        }
        private void _Mtd_Sorted(DataGridView _Dg_My)
        {
            for (int _Int_i = 0; _Int_i < _Dg_My.Columns.Count; _Int_i++)
            {
                _Dg_My.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void _Mtd_CargarBancos()
        {
            string _Str_Sql = "SELECT DISTINCT TBANCO.cbanco,TBANCO.cname FROM TBANCO INNER JOIN " +
"TCUENTBANC ON TBANCO.ccompany = TCUENTBANC.ccompany AND TBANCO.cbanco = TCUENTBANC.cbanco WHERE TBANCO.ccompany='" + Frm_Padre._Str_Comp + "' and TBANCO.cdelete=0";
            _Cb_Banco.SelectedIndexChanged -= new System.EventHandler(_Cb_Banco_SelectedIndexChanged);
            myUtilidad._Mtd_CargarCombo(_Cb_Banco, _Str_Sql);
            _Cb_Banco.SelectedIndexChanged += new System.EventHandler(_Cb_Banco_SelectedIndexChanged);
            _Cb_Cuenta.DataSource = null;
        }

        private void _Mtd_CargarCtaBanco(string _Pr_Str_Banco)
        {
            string _Str_Sql = "";
            _Str_Sql = "SELECT cnumcuenta,cname FROM TCUENTBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cbanco='" + _Pr_Str_Banco + "' and cdelete=0";
            _Cb_Cuenta.SelectedIndexChanged -= new System.EventHandler(_Cb_Cuenta_SelectedIndexChanged);
            myUtilidad._Mtd_CargarCombo(_Cb_Cuenta, _Str_Sql);
            _Cb_Cuenta.SelectedIndexChanged += new System.EventHandler(_Cb_Cuenta_SelectedIndexChanged);
        }

        private void _Mtd_CargarCajas()
        {
            string _Str_Sql = "";
            DataSet _Ds_A;
            _Cb_Caja.DataSource = null;
            _Str_Sql = "SELECT ccaja,cname FROM TCAJAS WHERE (ccompany='" + Frm_Padre._Str_Comp + "') AND ((cvendedor IS NULL) or (cvendedor=''))";
            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Cb_Caja.DataSource = _Ds_A.Tables[0];
            _Cb_Caja.DisplayMember = _Ds_A.Tables[0].Columns[1].ColumnName;
            _Cb_Caja.ValueMember = _Ds_A.Tables[0].Columns[0].ColumnName;
            _Cb_Caja.SelectedIndex = -1;
        }


        public void _Mtd_Cancelar()
        {
            _Mtd_Ini();
        }

        public void _Mtd_Ini()
        {
            _G_Dt_NcSelec.Clear();
            _G_Dt_NdSelec.Clear();
            _Str_MyProceso = "";
            _Str_FrmIdDescPPPago = "";
            _Bol_FGridPago = false;
            _Str_Form_cidcomprob = "";
            _Txt_Transaccion.Text = "";
            _Txt_Fecha.Text = "";
            _Str_FrmFPago = "";
            _Str_FrmTpoPago = "";
            _Pnl_Clave.Parent = this;
            _Pnl_Clave.BringToFront();
            if (_Cb_TpoProveFind.DataSource != null)
            { _Cb_TpoProveFind.SelectedIndex = 0; }

            if (_Cb_CatProveFind.DataSource != null)
            {
                _Cb_CatProveFind.SelectedIndex = 0;
            }

            if (_Cb_ProveedorFind.DataSource != null)
            {
                _Cb_ProveedorFind.SelectedIndex = 0;
            }
            _Rb_Abono.Checked = false;
            _Rb_PagoTot.Checked = false;
            _Rb_Cheque.Checked = false;
            _Rb_Efectivo.Checked = false;
            _Rb_TCredito.Checked = false;
            _Rb_Transferencia.Checked = false;
            _Str_FrmNRecepcion = "";
            if (_Cb_Cuenta.DataSource != null)
            { _Cb_Banco.SelectedIndex = 0; }
            
            _Cb_Caja.SelectedValue = "nulo";

            if (_Cb_Cuenta.DataSource != null)
            { _Cb_Cuenta.SelectedIndex = 0; }
            
            _Txt_Prov.Text = "";
            _Dg_OrdPagoDet.Rows.Clear();
            _Dg_OrdPagoDet.ReadOnly = true;
            _Mtd_CargarBancos();
            _Mtd_CargarCajas();
            _Pnl_Clave.Visible = false;
            _Cb_Caja.Visible = false;
            _Cb_Banco.Visible = false;
            _Cb_Cuenta.Visible = false;
            _Lb_Cuenta.Visible = false;
            _Lb_CajaBanco.Text = "Caja/Banco";
            _Dg_Comprobante.ReadOnly = true;
            _Bt_Comprobante.Enabled = false;
            _Dg_Comprobante.ContextMenuStrip = null;
            _Dg_Comprobante.Rows.Clear();
            _Mtd_UsuarioSts(Frm_Padre._Str_Use);
            if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_CHEQUE_SOL"))
            {
                _Bt_Pagar.Visible = true; _Bt_Pagar.Enabled = false;
                _Bt_Cerrar.Visible = true; _Bt_Cerrar.Enabled = false;
                _Bt_Anticipos.Enabled = false;
            }
            else
            {
                _Bt_Anticipos.Enabled = false;
                _Bt_Cerrar.Visible = false; _Bt_Cerrar.Enabled = false; 
            }
            _Txt_Usu.Text = "";
            _Txt_Cargo.Text = "";
            _Txt_Total.Text = "";
            _Str_InForm = "";
            _Str_SwClave = "";
            _Str_FrmTpoPago = "";
            _Pnl_DescPPago.Visible = false;
            _Mtd_BotonesMenu();
            _Mtd_Bloquear(false);
            _Str_ND_Anticipo = "0";
            //_Bt_Anticipos.Enabled = false;
        }

        private void _Mtd_Bloquear(bool _Pr_Bol_A)
        {
            _Txt_Transaccion.Enabled = false;
            _Txt_Fecha.Enabled = false;
            _Grb_Tipo.Enabled = _Pr_Bol_A;
            _Grb_FPago.Enabled = _Pr_Bol_A;
            _Cb_Banco.Enabled = _Pr_Bol_A;
            _Cb_Caja.Enabled = _Pr_Bol_A;
            _Cb_Cuenta.Enabled = _Pr_Bol_A;
            _Bt_AddDoc.Enabled = false;
            _Txt_Prov.Enabled = false;
            _Txt_Total.Enabled = false;
            _LstVDesc.Enabled = false;
            _Txt_MontoDesc.Enabled = false;
            //_Bt_Anticipos.Enabled = false;
        }

        public void _Mtd_BotonesMenu()
        {
            if (!_Bol_Otros & !_Bol_MenuPadre)
            {
                try
                {
                    CONTROLES._Ctrl_Buscar._Bl_Especial = true;
                    if (_Str_MyProceso == "A")
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                    }
                    if (_Str_MyProceso == "M")
                    {
                        if (_Str_DocCancelado == "1")
                        {
                            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                        }
                        else if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_CHEQUE_FIRMA"))
                        {
                            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                            if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CXP_DEL_ORDPAG"))
                            {
                                //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                            }
                            else
                            {
                                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                            }
                        }
                        else
                        {
                            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                            //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                            //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                            if (_Str_DocCancelado != "1")
                            {
                                if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CXP_DEL_ORDPAG"))
                                {
                                    //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                                }
                                else
                                {
                                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                                }
                                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                            }
                            else
                            {
                                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                            }
                        }
                        if (_Bt_AddDoc.Enabled)
                        { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true; }
                    }
                    if (_Str_MyProceso == "")
                    {
                        if (_Txt_Transaccion.Text != "")
                        {
                            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;

                            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                            if (_Str_DocCancelado == "1")
                            { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false; }
                            else
                            {
                                //if (_Str_DocCancelado != "1")
                                //{
                                if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CXP_DEL_ORDPAG"))
                                {
                                    //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                                }
                                else
                                {
                                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                                }
                                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                                //}
                                //else
                                //{
                                //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                                //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                                //}
                            }
                        }
                        else
                        {
                            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                        }
                    }
                    if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_CHEQUE_SOL"))
                    {
                        if ((_Rb_Cheque.Checked | _Rb_Transferencia.Checked) & !_Grb_FPago.Enabled)
                        {
                            _Bt_Pagar.Visible = true; _Bt_Pagar.Enabled = true;
                            _Bt_Anticipos.Enabled = true;
                            if (_Mtd_CerrarOrden(_Txt_Transaccion.Text.Trim()))
                            {
                                _Bt_Cerrar.Enabled = true;
                                _Bt_Pagar.Enabled = false;
                            }
                        }
                    }
                }
                catch
                { }
            }
            else
            {
                if (!_Bol_Otros)
                {
                    CONTROLES._Ctrl_Buscar._Bl_Especial = false;
                    CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
                    CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
                    CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
                }
            }
        }
        private string _Mtd_NombreComerProv(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE cproveedor='" + _P_Str_Proveedor + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().ToUpper();
        }
        private void _Mtd_CargarData(string _Pr_Str_Id)
        {
            string _Str_Sql = "";
            _Str_Sql = "SELECT * FROM VST_PAGOSCXPM WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago=" + _Pr_Str_Id;
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                _Txt_Transaccion.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cidordpago"]);
                _Txt_Fecha.Text = Convert.ToDateTime(_Ds_Data.Tables[0].Rows[0]["cfecha"]).ToShortDateString();
                if (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ctippago"])=="ABO")
                { _Rb_Abono.Checked = true; }
                else if (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ctippago"]) == "PTOT")
                { _Rb_PagoTot.Checked = true; }
                _Str_FrmTpoPago = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ctippago"]);
                if (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cfpago"]) == "EFECT")
                { _Rb_Efectivo.Checked = true; _Cb_Banco.Visible = true; _Lb_CajaBanco.Text = "Caja"; _Lb_Cuenta.Visible = false; _Cb_Banco.Visible = false; _Cb_Cuenta.Visible = false; }
                else if (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cfpago"]) == "CHEQ")
                { _Rb_Cheque.Checked = true; _Cb_Banco.Visible = true; _Cb_Cuenta.Visible = true; _Lb_CajaBanco.Text = "Banco"; _Lb_Cuenta.Visible = true; }
                else if (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cfpago"]) == "TRANSF")
                { _Rb_Transferencia.Checked = true; _Cb_Banco.Visible = true; _Cb_Cuenta.Visible = true; _Lb_CajaBanco.Text = "Banco"; _Lb_Cuenta.Visible = true; }
                else if (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cfpago"]) == "TARJC")
                { _Rb_TCredito.Checked = true; _Cb_Banco.Visible = true; _Cb_Cuenta.Visible = true; _Lb_CajaBanco.Text = "Banco"; _Lb_Cuenta.Visible = true; }

                _Cb_Banco.SelectedValue = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cbanco"]);
                _Mtd_CargarCtaBanco(Convert.ToString(_Cb_Banco.SelectedValue));
                _Cb_Cuenta.SelectedValue = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cnumcuentad"]);
                _Cb_Caja.SelectedValue = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ccaja"]);
                _Txt_Prov.Tag = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cproveedor"]);
                _Txt_Prov.Text = _Mtd_NombreComerProv(Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cproveedor"]));// Convert.ToString(_Ds_Data.Tables[0].Rows[0]["c_nomb_abreviado"]);
                _Str_DocCancelado = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ccancelado"]);
                _Str_Form_cidcomprob = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cidcomprob"]);
                _Txt_Usu.Tag = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cuserfirmante"]);
                _Txt_Usu.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cuserfirname"]);
                _Txt_Cargo.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cposition"]);
                _Txt_Total.Text = Convert.ToDouble(_Ds_Data.Tables[0].Rows[0]["cmontototal"]).ToString("#,##0.00");
                
                _Mtd_CargarDetalle(_Pr_Str_Id);
                //--------------Juan
                _Mtd_CargarComprobante(_Str_Form_cidcomprob);
                //--------------Juan
            }
        }

        public void _Mtd_CargarComprobante(string _Pr_Str_Id)
        {
            string _Str_Sql = "";
            //CARGO LOS DEBES
            _Str_Sql = "SELECT corder,ccount,cdescrip,ISNULL(ctotdebe,0) AS ctotdebe,ISNULL(ctothaber,0) AS ctothaber,ctdocument,cnumdocu FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Pr_Str_Id + "' ORDER BY corder";
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds_A.Tables[0].Rows)
            {
                _Dg_Comprobante.Rows.Add();
                _Dg_Comprobante[0, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DRow["corder"]);
                _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DRow["ccount"]);
                _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DRow["cdescrip"]);
                if (Convert.ToDouble(_DRow["ctotdebe"].ToString()) > 0)
                { _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = Convert.ToDouble(_DRow["ctotdebe"]).ToString("#,##0.00"); }
                else
                { _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = Convert.ToDouble(_DRow["ctothaber"]).ToString("#,##0.00"); }
                _Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(Convert.ToString(_DRow["ctdocument"]));
                _Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(Convert.ToString(_DRow["cnumdocu"]));
            }
            _Mtd_FilaTotal();
            _Dg_Comprobante.ReadOnly = true;
            foreach (DataGridViewRow _DgRow in _Dg_Comprobante.Rows)
            {
                for (int _Int_I = 0; _Int_I < _Dg_Comprobante.ColumnCount; _Int_I++)
                {
                    if (_Int_I == 2)
                    { _DgRow.Cells[_Int_I].Style.BackColor = Color.Navy; }
                    else
                    { _DgRow.Cells[_Int_I].Style.BackColor = Color.Tan; }
                }
            }
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Grb_Contable.Visible = true;
        }

        private void _Mtd_CargarDetalle(string _Pr_Str_Id)
        {
            double _Dbl_MontoDescppp = 0;
            object[] _Str_RowNew = new object[11];
            string _Str_Cadena = "Select CONVERT(varchar, cfechaemision, 103) as cfechaemision,CONVERT(varchar, cfechavencimiento, 103) as cfechavencimiento,cnumdocu,ctipodocumentname,cmontodocushow,cmontocancelarshow,cidfactxp,cmontoimpshow,ctipodocument,cmontoddpp,cidescuentoppp from VST_PAGOSCXPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago=" + _Pr_Str_Id + " ORDER BY ctipodocument,cfechaemision";
            if (_Mtd_OrdenIntercompañia(int.Parse(_Pr_Str_Id)))
                _Str_Cadena = "Select CONVERT(varchar, cfechaemision, 103) as cfechaemision,CONVERT(varchar, cfechavencimiento, 103) as cfechavencimiento,cnumdocu,ctipodocumentname,cmontodocushow,cmontodocushow as cmontocancelarshow, 0 as cidfactxp, 0 as cmontoimpshow, ctipodocument as ctipodocument, 0 as cmontoddpp, 0 as cidescuentoppp from VST_PAGOS_INTER_D WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago=" + _Pr_Str_Id + " ORDER BY ctipodocument,cfechaemision";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_OrdPagoDet.Rows.Clear();
            _G_Dt_NcSelec.Clear();
            _G_Dt_NdSelec.Clear();
            foreach (DataRow _DataR in _Ds_Data.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_OrdPagoDet.Rows.Add(_Str_RowNew);
                _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount-1].Value = Convert.ToDouble(_Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount-1].Value).ToString("#,##0.00");
                _Dg_OrdPagoDet[5, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToDouble(_Dg_OrdPagoDet[5, _Dg_OrdPagoDet.RowCount - 1].Value).ToString("#,##0.00");
                if (Convert.ToString(_Dg_OrdPagoDet[9, _Dg_OrdPagoDet.RowCount - 1].Value) != "")
                {
                    _Dbl_MontoDescppp = Convert.ToDouble(_Dg_OrdPagoDet[9, _Dg_OrdPagoDet.RowCount - 1].Value);
                }
                if (_Dbl_MontoDescppp != 0)
                {
                    _Dg_OrdPagoDet[9, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToDouble(_Dg_OrdPagoDet[9, _Dg_OrdPagoDet.RowCount - 1].Value).ToString("#,##0.00");
                }
                else
                { _Dg_OrdPagoDet[9, _Dg_OrdPagoDet.RowCount - 1].Value = ""; }
            }
            _Dg_OrdPagoDet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            
        }
        private string[] _Mtd_FechaDocumento(string _P_Str_TipoDocument,string _P_Str_Documento,string _P_Str_Proveedor)
        {
            string _Str_Cadena = "";
            DataSet _Ds = new DataSet();
            if (_P_Str_Documento.Trim().Length > 0 & _P_Str_TipoDocument.Trim().Length > 0)
            {
                try
                {
                    _Str_Cadena = "SELECT ctipdocfact,ctipodocndp,ctipodocnc,ctipodocnd FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_P_Str_TipoDocument.Trim().ToUpper() == _Ds.Tables[0].Rows[0]["ctipdocfact"].ToString().Trim().ToUpper() | _P_Str_TipoDocument.Trim().ToUpper() == _Ds.Tables[0].Rows[0]["ctipodocndp"].ToString().Trim().ToUpper())
                    {
                        _Str_Cadena = "SELECT cfechaemision,cfechavencimiento FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _P_Str_Proveedor + "' AND ctipodocument='" + _P_Str_TipoDocument + "' AND cnumdocu='" + _P_Str_Documento + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            return new string[] { _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0][0].ToString())), _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0][1].ToString())) };
                        }
                    }
                    else if (_P_Str_TipoDocument.Trim().ToUpper() == _Ds.Tables[0].Rows[0]["ctipodocnc"].ToString().Trim().ToUpper())
                    {
                        _Str_Cadena = "SELECT cfechanc,cfvfnotacredp FROM TNOTACREDICP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotacreditocxp='" + _P_Str_Documento + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            return new string[] { _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0][0].ToString())), _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0][1].ToString())) };
                        }
                    }
                    else if (_P_Str_TipoDocument.Trim().ToUpper() == _Ds.Tables[0].Rows[0]["ctipodocnd"].ToString().Trim().ToUpper())
                    {
                        _Str_Cadena = "SELECT cfechand,cfvfnotadebitop FROM TNOTADEBITOCP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp='" + _P_Str_Documento + "'";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            return new string[] { _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0][0].ToString())), _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0][1].ToString())) };
                        }
                    }
                }
                catch { }
            }
            return new string[] { _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()), _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) };
        }
        public void _Mtd_Habilitar()
        {
            if (_Bol_Otros)
            {
                _Txt_OrdenPago.Enabled = true;
                _Cb_Banco_Otros.Enabled = true;
                _Cb_Cuenta_Otros.Enabled = true;
                _Cb_TpoPagoOtros.Enabled = true;
                if (_Cb_TpoPagoOtros.SelectedIndex == 3 | _Cb_TpoPagoOtros.SelectedIndex == 4 | _Cb_TpoPagoOtros.SelectedIndex == 11)
                {
                    _Bt_Beneficiario.Enabled = true;
                }
                _Bt_BuscarBeneficiario2.Enabled = !_Bt_Beneficiario.Enabled;
                _Bt_BuscarBeneficiario2.Visible = !_Bt_Beneficiario.Enabled;
                // comentado por #failzor
                //_Bt_Edit_3.Enabled = !_Bt_Beneficiario.Enabled;

                _Bt_Edit_1.Enabled = true;
                _Bt_Edit_2.Enabled = true;
                _Bt_Edit_3.Enabled = true;

                _Txt_MontoPagar.Enabled = true;
                _Grb_TipoOtros.Enabled = true;
                _Grb_FormaPagoOtros.Enabled = true;
                _Dg_Grid.ReadOnly = false;
                _Dg_Grid.Columns["cidauxiliarcont"].ReadOnly = true;
                _Dg_Grid.Rows[0].Cells["Cuenta"].ReadOnly = true;
                _Dg_Grid.Rows[0].Cells["Haber"].ReadOnly = true;
                if (_Txt_Beneficiario.Text.Trim().Length > 0 & _Txt_Concepto.Text.Trim().Length > 0)
                { _Txt_MontoPagar.ReadOnly = false; }
                else
                { _Txt_MontoPagar.ReadOnly = true; }
                _Bt_Pagar_Otros.Enabled = false;
                if (_Bt_BuscarBeneficiario2.Enabled)
                {
                    _Txt_Rif.Enabled = false;
                    _Bt_Edit_1.Enabled = false;
                    _Bt_Edit_3.Enabled = false;
                }
            }
            else
            {
                _Mtd_Bloquear(true);
                _Tb_Tab.SelectTab(1);
                _Bt_Comprobante.Enabled = false;
                _Dg_Comprobante.ContextMenuStrip = null;
                if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_PROCESA_PAGO"))
                {
                    _Bt_AddDoc.Enabled = true;
                }
                else
                { _Bt_AddDoc.Enabled = false; }
                _Bt_Pagar.Enabled = false;
                _Bt_Anticipos.Enabled = false;
                _Mtd_DgOrdPagDetHabilitar();
                _Str_MyProceso = "M";
                //_Bt_Anticipos.Enabled = true;
                _Bt_Cerrar.Enabled = false;
            }
        }
        private bool _Mtd_VerificarComprobRetenISLRAnulado(string _P_Str_ComprobRetISLR)
        {
            string _Str_Cadena = "SELECT cidcomprobislr FROM TCOMPROBANISLRC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobislr='" + _P_Str_ComprobRetISLR + "' AND canulado = 1";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_VerificarComprobRetenIVAAnulado(string _P_Str_ComprobRetCOMP)
        {
            string _Str_Cadena = "SELECT cidcomprobret FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _P_Str_ComprobRetCOMP + "' AND canulado = 1";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_VerificarComprobRetenAnulados()
        {
            string _Str_Cadena = "SELECT ctipdocretislr,ctipdocretiva FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_TipoDocISLR = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocretislr"]);
                string _Str_TipoDocRetIVA = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocretiva"]);
                foreach (DataGridViewRow _Dg_Row in _Dg_OrdPagoDet.Rows)
                {
                    if (Convert.ToString(_Dg_Row.Cells[8].Value).Trim().ToUpper() == _Str_TipoDocISLR.Trim().ToUpper())
                    {
                        if (_Mtd_VerificarComprobRetenISLRAnulado(Convert.ToString(_Dg_Row.Cells[2].Value).Trim()))
                        { return true; }
                    }
                    else if (Convert.ToString(_Dg_Row.Cells[8].Value).Trim().ToUpper() == _Str_TipoDocRetIVA.Trim().ToUpper())
                    {
                        if (_Mtd_VerificarComprobRetenIVAAnulado(Convert.ToString(_Dg_Row.Cells[2].Value).Trim()))
                        { return true; }
                    }
                }
            }
            return false;
        }
        public bool _Mtd_Guardar()
        {
            if (_Bol_Otros)
            {
                _Er_Error.Dispose();                
                _Dg_Grid.EndEdit();
                if (_Txt_Debe.Text.Trim().Length == 0)
                { _Txt_Debe.Text = "0"; }
                if (_Txt_Haber.Text.Trim().Length == 0)
                { _Txt_Haber.Text = "0"; }
                if (_Txt_Saldo.Text.Trim().Length == 0)//_Txt_MontoPagar.Text
                { _Txt_Saldo.Text = "0"; }
                if (_Txt_MontoPagar.Text.Trim().Length == 0)
                { _Txt_MontoPagar.Text = "0"; }
                bool _Bol_VerificarIdAuxTipDocNumDocNull = _Mtd_VerificarIdAuxTipDocNumDocNull();
                bool _Bol_RegexRif = true;
                System.Text.RegularExpressions.Regex RegexValidation = null;
                if (_Rbt_Rif.Checked)
                {
                    RegexValidation = new System.Text.RegularExpressions.Regex(@"(J|V|P|E|G)\-[0-9]{8}\-[0-9]{1}");
                }
                else
                {
                    RegexValidation = new System.Text.RegularExpressions.Regex(@"(V|E)\-[0-9]{8}");
                }
                _Txt_Rif.Text = _Txt_Rif.Text.ToUpper();
                if (!RegexValidation.IsMatch(_Txt_Rif.Text))
                {
                    _Bol_RegexRif = false;
                }
                
                if (_Bol_RegexRif&&_Mtd_VerificarFormulario() & !_Bol_VerificarIdAuxTipDocNumDocNull)
                {
                    if (_Mtd_VerificarDocExistentes())
                    {
                        _Mtd_CalcularTotales();
                        if (Convert.ToDouble(_Txt_Debe.Text) > 0 & Convert.ToDouble(_Txt_Haber.Text) > 0 & Convert.ToDouble(_Txt_Saldo.Text) == 0)
                        {
                            if (_Rb_ChequeO.Checked || _Rb_TransfO.Checked)
                            {
                                _Pnl_Clave_Otros.Visible = true;
                                return false;
                            }
                            else
                            {
                                MessageBox.Show("Debe elegir la forma de pago", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        { MessageBox.Show("El comprobante esta descuadrado", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    }
                    else
                    { MessageBox.Show("Los documentos marcados no existen en la base de datos del sistema. Verifique que la\ninformación en auxiliar, tipo de documento y documento sea correcta para cada\nregistro marcado.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return false; }
                }
                else
                {
                    if (!_Bol_RegexRif)
                    {
                        _Er_Error.SetError(_Txt_Rif, "Por favor verifique que el valor introducido en la cédula o rif sea correcto");
                    }
                    if (_Cb_Banco_Otros.SelectedIndex <= 0) { _Er_Error.SetError(_Cb_Banco_Otros, "Información requerida!!!"); }
                    if (_Cb_Cuenta_Otros.SelectedIndex <= 0) { _Er_Error.SetError(_Cb_Cuenta_Otros, "Información requerida!!!"); }
                    if (_Cb_TpoPagoOtros.SelectedIndex <= 0) { _Er_Error.SetError(_Cb_TpoPagoOtros, "Información requerida!!!"); }
                    if (_Txt_Beneficiario.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_Edit_1, "Información requerida!!!"); }
                    if (_Txt_Concepto.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_Edit_2, "Información requerida!!!"); }
                    if (Convert.ToDouble(_Txt_MontoPagar.Text) == 0) { _Txt_MontoPagar.Text = ""; _Er_Error.SetError(_Txt_MontoPagar, "Información requerida!!!"); }
                    if (_Bol_VerificarIdAuxTipDocNumDocNull)
                    { MessageBox.Show("Verifique que en los registros marcados esten identificados el auxiliar, tipo de documento y documento", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    else
                    {
                        _Mtd_ValidarFila();
                        if (_Dg_Grid.RowCount > 0)
                        { _Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Selected = true; }
                    }
                }
                return false;
            }
            else
            {
                bool _Bol_Val = false;
                bool _Bol_R = false;
                string _Str_Banco = "";
                string _Str_Caja = "";
                string _Str_Cuenta = "";
                string _Str_Sql = "";
                string _Str_IdTrans = "";
                string _Str_cconceptocomp = "";
                string _Str_ctypcompro = "";
                string _Str_cyearacco = "";
                string _Str_cmontacco = "";
                string _Str_cidcomprob = "";
                string _Str_corder = "";
                string _Str_TpoDoc = "null";

                string _Str_Fact = "";
                string _Str_ND = "";
                string _Str_NC = "";
                string _Str_NDP = "";
                string _Str_DescPPPId = "";

                double _Dbl_MontoDesc = 0;
                double _Dbl_MontoDescAcum = 0;
                double _Dbl_Debe = 0;
                double _Dbl_Haber = 0;
                double _Dbl_cbalanceo = 0;
                double _Dbl_ValorAuxDoc = 0;
                double _Dbl_ValorAuxSaldo = 0;
                double _Dbl_MontoFactC = 0;
                double _Dbl_MontoFact = 0;
                if (_Str_MyProceso == "A")
                {
                    int[] _Int_VecCol = new int[1];
                    _Int_VecCol[0] = 5;
                    if (!_Rb_Abono.Checked && !_Rb_PagoTot.Checked)
                    {
                        MessageBox.Show("Seleccione Un Tipo de Pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _Bol_Val = true;
                    }
                    else if (!_Rb_Cheque.Checked && !_Rb_Efectivo.Checked && !_Rb_Transferencia.Checked && !_Rb_TCredito.Checked)
                    {
                        MessageBox.Show("Seleccione Una Forma de Pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _Bol_Val = true;
                    }
                    else if (_Rb_Efectivo.Checked)
                    {
                        if (_Cb_Caja.SelectedIndex == -1)
                        {
                            _Er_Error.SetError(_Cb_Caja, "Seleccione Una Caja.");
                            _Bol_Val = true;
                        }
                    }
                    else if (!_Rb_Cheque.Checked && !_Rb_Efectivo.Checked && !_Rb_Transferencia.Checked && !_Rb_TCredito.Checked)
                    {
                        if (_Cb_Banco.SelectedIndex <= 0)
                        {
                            _Er_Error.SetError(_Cb_Banco, "Seleccione Un Banco.");
                            _Bol_Val = true;
                        }
                        if (_Cb_Cuenta.SelectedIndex <= 0)
                        {
                            _Er_Error.SetError(_Cb_Cuenta, "Seleccione Una Cuenta.");
                            _Bol_Val = true;
                        }
                    }
                    else if (_Dg_OrdPagoDet.RowCount == 0)
                    {
                        MessageBox.Show("Ingrese Datos en el Detalle.", "Validación");
                        _Bol_Val = true;
                    }
                    else if (_Mtd_ValidarGridCont(_Dg_OrdPagoDet, _Int_VecCol))
                    {
                        MessageBox.Show("Faltan datos por Ingresar en el Grid ", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _Bol_Val = true;
                    }
                    else if (_Mtd_VerificarSaldo())
                    {
                        MessageBox.Show("El Saldo del Comprobante no es Correcto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _Bol_Val = true;
                    }
                    else if (_Dg_Comprobante.RowCount == 0)
                    {
                        MessageBox.Show("Debe de Generar el Comprobante.", "Validación");
                        _Bol_Val = true;
                    }
                    else if (_Mtd_VerificarComprobRetenAnulados())
                    {
                        MessageBox.Show("Uno o más comprobantes de retención han sido anulados. Cierre el formulario\ny vuelva a realizar la operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Bol_Val = true; 
                    }
                    else
                    {
                        foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
                        {
                            if (_Dg_Row.Visible)
                            {
                                if (Convert.ToString(_Dg_Row.Cells[4].Value).Trim() == "")
                                { _Dbl_ValorAuxDoc = 0; }
                                else
                                { _Dbl_ValorAuxDoc = Convert.ToDouble(_Dg_Row.Cells[4].Value); }

                                if (Convert.ToString(_Dg_Row.Cells[5].Value).Trim() == "")
                                { _Dbl_ValorAuxSaldo = 0; }
                                else
                                { _Dbl_ValorAuxSaldo = Convert.ToDouble(_Dg_Row.Cells[5].Value); }
                                if (_Dbl_ValorAuxDoc == 0 && _Dbl_ValorAuxSaldo == 0)
                                {
                                    MessageBox.Show("El Debe y el Haber de la Cuenta " + Convert.ToString(_Dg_Row.Cells[3].Value) + " no debe de ser Cero (0) o Vacio.", "Validación");
                                    _Bol_Val = true;
                                }
                            }
                        }
                    }
                    if (!_Bol_Val)
                    {
                        //VERIFICO EL STATUS DEL USUARIO
                        if (myUtilidad._Mtd_UsuarioProceso(Convert.ToString(_Txt_Usu.Tag), "F_ORDEN_PAGO") == false)
                        {
                            MessageBox.Show("El Usuario no tiene permiso para ejecutar este proceso.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            _Bol_Val = true;
                        }
                        else
                        {
                            //PIDO LA CLAVE DE USUARIO
                            _Str_SwClave = "G";
                            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
                            _Lbl_TituloClave.Text = "Guardar Orden de Pago";
                            _Pnl_Clave.Visible = true;
                            _Tb_Tab.Enabled = false;
                            //_Pnl_Clave.BringToFront();
                            if (_Txt_Clave.Text != "")
                            {
                                //VERIFICO LA CLAVE
                                _Str_Sql = "SELECT cpassw FROM TUSER WHERE cuser='" + Convert.ToString(_Txt_Usu.Tag) + "'";
                                DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds_A.Tables[0].Rows.Count > 0)
                                {
                                    byte[] hash = ConvertStringToByteArray(_Txt_Clave.Text);
                                    byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
                                    string _Str_cod = BitConverter.ToString(valorhash);
                                    _Str_cod = _Str_cod.Replace("-", "");
                                    if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) != _Str_cod)
                                    {
                                        MessageBox.Show("La contraseña es Incorrecta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        _Bol_Val = true;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se consiguieron datos para la verificación del Usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    _Bol_Val = true;
                                }
                            }
                            else
                            { _Bol_Val = true; _Txt_Pwd.Focus(); }
                        }
                    }

                    if (!_Bol_Val)
                    {
                        if (_Rb_Efectivo.Checked)
                        {
                            _Str_Caja = "'" + Convert.ToString(_Cb_Caja.SelectedValue) + "'";
                            _Str_Banco = "null";
                            _Str_Cuenta = "null";
                        }
                        else if (_Str_FrmFPago != "")
                        {
                            _Str_Caja = "null";
                            _Str_Banco = "'" + Convert.ToString(_Cb_Banco.SelectedValue) + "'";
                            _Str_Cuenta = "'" + Convert.ToString(_Cb_Cuenta.SelectedValue) + "'";
                        }
                        try
                        {
                            //GUARDO LOS DATOS DE COMPROBANTE
                            string _Str_ProcesoCont = _Mtd_ProcesoCont(Convert.ToString(_Txt_Prov.Tag).Trim());
                            Clases._Cls_ProcesosCont _My_Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont(_Str_ProcesoCont);
                            _Str_cconceptocomp = _My_Cls_ProcesosCont._Field_ConceptoComprobante;
                            _Str_ctypcompro = _My_Cls_ProcesosCont._Field_TipoComprobante;
                            _Str_cyearacco = Clases._Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString());
                            _Str_cmontacco = Clases._Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString());
                            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
                            {
                                if (_Dg_Row.Visible)
                                {
                                    if (Convert.ToString(_Dg_Row.Cells[0].Value).Trim() != "T")
                                    {
                                        if (Convert.ToString(_Dg_Row.Cells[4].Value).Trim() == "")
                                        { _Dbl_ValorAuxDoc = 0; }
                                        else
                                        { _Dbl_ValorAuxDoc = Convert.ToDouble(_Dg_Row.Cells[4].Value); }

                                        if (Convert.ToString(_Dg_Row.Cells[5].Value).Trim() == "")
                                        { _Dbl_ValorAuxSaldo = 0; }
                                        else
                                        { _Dbl_ValorAuxSaldo = Convert.ToDouble(_Dg_Row.Cells[5].Value); }

                                        if (_Dbl_ValorAuxDoc != 0)
                                        {
                                            _Dbl_Debe = _Dbl_Debe + Convert.ToDouble(_Dg_Row.Cells[4].Value);
                                        }
                                        if (_Dbl_ValorAuxSaldo != 0)
                                        {
                                            _Dbl_Haber = _Dbl_Haber + Convert.ToDouble(_Dg_Row.Cells[5].Value);
                                        }
                                    }
                                }
                            }
                            if (_Dbl_Debe > _Dbl_Haber)
                            { _Dbl_cbalanceo = Math.Round(_Dbl_Debe, 2) - Math.Round(_Dbl_Haber, 2); }
                            else if (_Dbl_Debe < _Dbl_Haber)
                            { _Dbl_cbalanceo = Math.Round(_Dbl_Haber, 2) - Math.Round(_Dbl_Debe, 2); }

                            //_Dbl_cbalanceo = _Mtd_ObetenerBalanceo();
                            _Str_cidcomprob = myUtilidad._Mtd_Consecutivo_TCOMPROBANC().ToString();
                            _Str_Sql = "insert into TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado) values ('";
                            _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_ctypcompro + "','" + _Str_cconceptocomp + "','" + _Str_cyearacco + "','" + _Str_cmontacco + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_cbalanceo) + "',GETDATE(),'" + Frm_Padre._Str_Use + "',0)";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_cidcomprob);

                            _Str_Sql = "Select Max(cidordpago) FROM TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                            _Str_IdTrans = myUtilidad._Mtd_Correlativo(_Str_Sql);


                            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctdocumentopordenp FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                            if (_Ds_A.Tables[0].Rows.Count > 0)
                            {
                                _Str_TpoDoc = "'" + Convert.ToString(_Ds_A.Tables[0].Rows[0][0]).Trim() + "'";
                            }
                            string[] _Str_FechaDocument = new string[2];
                            //GUARDO COMPROBANTE DETALLE
                            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
                            {
                                if (_Dg_Row.Visible)
                                {
                                    if (Convert.ToString(_Dg_Row.Cells[0].Value).Trim() != "T")
                                    {
                                        if (Convert.ToString(_Dg_Row.Cells[4].Value).Trim() == "")
                                        { _Dbl_ValorAuxDoc = 0; }
                                        else
                                        { _Dbl_ValorAuxDoc = Convert.ToDouble(_Dg_Row.Cells[4].Value); }

                                        if (Convert.ToString(_Dg_Row.Cells[5].Value).Trim() == "")
                                        { _Dbl_ValorAuxSaldo = 0; }
                                        else
                                        { _Dbl_ValorAuxSaldo = Convert.ToDouble(_Dg_Row.Cells[5].Value); }
                                        _Str_FechaDocument = _Mtd_FechaDocumento(Convert.ToString(_Dg_Row.Cells["_Col_Tipo_Doc"].Value).Trim(), Convert.ToString(_Dg_Row.Cells["_Col_Documento"].Value).Trim(), Convert.ToString(_Txt_Prov.Tag).Trim());
                                        _Str_corder = Convert.ToString(myUtilidad._Mtd_Consecutivo_TCOMPROBAND(_Str_cidcomprob));
                                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,ctothaber,cdateadd,cuseradd,cdescrip) values ('";
                                        _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "','" + Convert.ToString(_Dg_Row.Cells[1].Value).Trim() + "','" + Convert.ToString(_Dg_Row.Cells["_Col_Tipo_Doc"].Value).Trim() + "','" + Convert.ToString(_Dg_Row.Cells["_Col_Documento"].Value).Trim() + "','" + _Str_FechaDocument[0] + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ValorAuxDoc) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ValorAuxSaldo) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + Convert.ToString(_Dg_Row.Cells[3].Value).Trim().ToUpper().Replace("'","''") + "')";
                                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                        if (_Dbl_ValorAuxDoc > 0)
                                        { CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, Convert.ToString(_Dg_Row.Cells[1].Value).Trim(), Convert.ToString(_Txt_Prov.Tag).Trim(), Convert.ToString(_Dg_Row.Cells[3].Value).Trim().ToUpper(), Convert.ToString(_Dg_Row.Cells["_Col_Tipo_Doc"].Value).Trim(), Convert.ToString(_Dg_Row.Cells["_Col_Documento"].Value).Trim(), _Str_FechaDocument[0], _Str_FechaDocument[1], CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ValorAuxDoc), _Str_cmontacco, _Str_cyearacco, "D"); }//Aux
                                        else
                                        { CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_cidcomprob, Convert.ToString(_Dg_Row.Cells[1].Value).Trim(), Convert.ToString(_Txt_Prov.Tag).Trim(), Convert.ToString(_Dg_Row.Cells[3].Value).Trim().ToUpper(), Convert.ToString(_Dg_Row.Cells["_Col_Tipo_Doc"].Value).Trim(), Convert.ToString(_Dg_Row.Cells["_Col_Documento"].Value).Trim(), _Str_FechaDocument[0], _Str_FechaDocument[1], CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_ValorAuxSaldo), _Str_cmontacco, _Str_cyearacco, "H"); }//Aux
                                    }
                                }
                            }
                            //MessageBox.Show("Se generó el Comprobante # " + _Str_cidcomprob);
                            //**************************************************************************************************


                            //ME TRAIGO LOS TIPOS DE DOCUMENTOS
                            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipodocnd,ctipodocnc,ctipdocfact,ctipodocndp from TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                            if (_Ds_A.Tables[0].Rows.Count > 0)
                            {
                                _Str_Fact = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocfact"]);
                                _Str_ND = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnd"]);
                                _Str_NC = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnc"]);
                                _Str_NDP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocndp"]);
                            }

                            //GUARDO EL DETALLE DE LA ORDEN DE PAGO
                            foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
                            {

                                if (Convert.ToString(_DgRow.Cells[10].Value).Trim() != "")
                                {
                                    _Str_DescPPPId = "'" + Convert.ToString(_DgRow.Cells[10].Value) + "'";
                                }
                                else
                                { _Str_DescPPPId = "null"; }

                                if (Convert.ToString(_DgRow.Cells[9].Value).Trim() != "")
                                {
                                    _Dbl_MontoDesc = Convert.ToDouble(_DgRow.Cells[9].Value);
                                }
                                else
                                { _Dbl_MontoDesc = 0; }

                                _Dbl_MontoDescAcum = _Dbl_MontoDescAcum + _Dbl_MontoDesc;
                                _Str_Sql = "INSERT INTO TPAGOSCXPD (cgroupcomp,ccompany,cidordpago,cproveedor,cnumdocu,ctipodocument,cfechaemision,cfechavencimiento,cmontodocu,cmontocancelar,cmontoimp,cidescuentoppp,cmontoddpp) VALUES('";
                                _Str_Sql = _Str_Sql + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "'," + _Str_IdTrans + ",'" + Convert.ToString(_Txt_Prov.Tag).Trim() + "','" + Convert.ToString(_DgRow.Cells[2].Value).Trim() + "','" + Convert.ToString(_DgRow.Cells[8].Value) + "','" + Convert.ToString(_DgRow.Cells[0].Value).Trim() + "','" + Convert.ToString(_DgRow.Cells[1].Value).Trim() + "'," + Convert.ToString(_DgRow.Cells[4].Value).Replace(".", "").Replace(",", ".").Replace("-", "") + "," + Convert.ToString(_DgRow.Cells[5].Value).Replace(".", "").Replace(",", ".").Replace("-", "") + "," + Convert.ToString(_DgRow.Cells[7].Value).Replace(".", "").Replace(",", ".").Replace("-", "") + "," + _Str_DescPPPId + "," + _Dbl_MontoDesc.ToString().Replace(",", ".") + ")";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                if (_Str_ND.Trim() == Convert.ToString(_DgRow.Cells[8].Value).Trim())
                                {
                                    //DESCUENTO LAS ND ASOCIADAS A LA ORDEN DE PAGO
                                    _Str_Sql = "UPDATE TNOTADEBITOCP SET cdescontada=1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp='" + _DgRow.Cells[2].Value.ToString() + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                }

                                //MARCO LAS RELACIONES DE PAGO DEL PROVEEDOR
                                _Str_Sql = "UPDATE TFACTPPAGARM SET cordenpaghecha='0',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "'";
                                if (_Str_Fact == Convert.ToString(_DgRow.Cells[8].Value) | _Str_NDP == Convert.ToString(_DgRow.Cells[8].Value))
                                {
                                    _Str_Sql = _Str_Sql + " and cidfactxp='" + Convert.ToString(_DgRow.Cells[6].Value) + "'";
                                }
                                else
                                {
                                    //_Str_Sql = _Str_Sql + " and ctipodocument='" + Convert.ToString(_DgRow.Cells[8].Value) + "' AND cnumdocu='" + Convert.ToString(_DgRow.Cells[2].Value) + "' and cidnotrecepc='" + _Str_FrmNRecepcion + "'";
                                    _Str_Sql = _Str_Sql + " and ctipodocument='" + Convert.ToString(_DgRow.Cells[8].Value) + "' AND cnumdocu='" + Convert.ToString(_DgRow.Cells[2].Value) + "'";
                                }
                                //verifico los abonos de las facturas
                                if (_Str_Fact == Convert.ToString(_DgRow.Cells[8].Value) | _Str_NDP == Convert.ToString(_DgRow.Cells[8].Value))
                                {
                                    if (Convert.ToString(_DgRow.Cells[5].Value) != "")
                                    {
                                        _Dbl_MontoFactC = Convert.ToDouble(_DgRow.Cells[5].Value) + myUtilidad._Mtd_ObtenerAbonoOrdPago(_DgRow.Cells[2].Value.ToString(), _DgRow.Cells[8].Value.ToString(), _Txt_Prov.Tag.ToString());
                                    }
                                    else
                                    { _Dbl_MontoFactC = 0; }

                                    if (Convert.ToString(_DgRow.Cells[4].Value) != "")
                                    {
                                        _Dbl_MontoFact = Convert.ToDouble(_DgRow.Cells[4].Value);
                                    }
                                    else
                                    { _Dbl_MontoFact = 0; }

                                    if (_Rb_PagoTot.Checked)
                                    {
                                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    }
                                    else
                                    {
                                        if (_Dbl_MontoFact == _Dbl_MontoFactC)
                                        {//PAGO TOTAL
                                            if (_Dbl_MontoFact != 0)
                                            {
                                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                            }
                                        }
                                    }

                                }
                                else
                                { Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql); }

                            }
                            //GUARDO LA CABECERA DE LA ORDEN DE PAGO
                            string _Str_Rif = _Mtd_BuscarRifDelProveedor(_Txt_Prov.Tag.ToString());
                            _Str_Sql = "INSERT INTO TPAGOSCXPM (cgroupcomp,ccompany,cidordpago,cproveedor,ctippago,cfpago,cfecha,cuserfirmante,cmontototal,cbanco,ccaja,cnumcuentad,ccancelado,canulado,cmontototaltext,cidcomprob,cdescpppago,crif) VALUES('";
                            _Str_Sql = _Str_Sql + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "'," + _Str_IdTrans + ",'" + Convert.ToString(_Txt_Prov.Tag).Trim() + "','" + _Str_FrmTpoPago + "','" + _Str_FrmFPago + "','" + _Txt_Fecha.Text.Trim() + "','" + Convert.ToString(_Txt_Usu.Tag).Trim() + "'," + _Txt_Total.Text.Replace(".", "").Replace(",", ".") + "," + _Str_Banco + "," + _Str_Caja + "," + _Str_Cuenta + ",0,0,'" + _obj_NumerosaLetras.Numero2Letra(_Txt_Total.Text.Replace(".", ""), 0, 2, "", "Céntimo", LibNumLetras.clsNumerosaLetras.eSexo.Masculino, LibNumLetras.clsNumerosaLetras.eSexo.Masculino).ToUpper() + "','" + _Str_cidcomprob + "'," + _Dbl_MontoDescAcum.ToString().Replace(",", ".") + ",";
                            _Str_Sql +="'" + _Str_Rif + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            _Txt_Transaccion.Text = _Str_IdTrans;
                            _Pnl_Clave.Visible = false;
                            _Str_MyProceso = "";
                            _Mtd_Bloquear(false);
                            MessageBox.Show("Se guardó correctamente la Orden de Pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            foreach (DataGridViewRow _DgRow in _Dg_Comprobante.Rows)
                            {
                                for (int _Int_I = 0; _Int_I < _Dg_Comprobante.ColumnCount; _Int_I++)
                                {
                                    if (_Int_I == 2)
                                    { _DgRow.Cells[_Int_I].Style.BackColor = Color.Navy; }
                                    else
                                    { _DgRow.Cells[_Int_I].Style.BackColor = Color.Tan; }
                                }
                            }
                            _Grb_Contable.Visible = true;
                            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                            _Bt_Comprobante.Enabled = false;
                            _Mtd_CargarComprobante(_Str_cidcomprob);
                            if ((Frm_Padre)this.MdiParent != null)
                            {
                                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                            }
                            _Bol_R = true;

                        }
                        catch
                        { _Bol_R = false; }
                    }
                }
                _Mtd_Actualizar();
                if (_Bol_R)
                { this.Close(); }
                return _Bol_R;
            }
        }

        public bool _Mtd_Editar()
        {
            if (_Bol_Otros)
            {
                
                return _Mtd_Guardar();
            }
            else
            {
                bool _Bol_Val = false;
                bool _Bol_R = false;
                string _Str_Banco = "";
                string _Str_TpoDoc = "null";
                string _Str_Caja = "";
                string _Str_Cuenta = "";
                string _Str_Sql = "";
                string _Str_corder = "";
                string _Str_Fact = "", _Str_ND = "";
                string _Str_NDP = "";
                string _Str_DescPPPId = "";

                double _Dbl_Debe = 0;
                double _Dbl_Haber = 0;
                double _Dbl_MontoDescAcum = 0;
                double _Dbl_MontoDesc = 0;
                double _Dbl_DebeTot = 0;
                double _Dbl_HaberTot = 0;
                double _Dbl_Balance = 0;
                double _Dbl_MontoDoc = 0;
                double _Dbl_MontoCancelar = 0;
                double _Dbl_MontoImp = 0;

                if (_Str_MyProceso == "M")
                {
                    if (_Str_FrmTpoPago == "")
                    {
                        MessageBox.Show("Seleccione Un Tipo de Pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _Bol_Val = true;
                    }
                    if (_Str_FrmFPago == "")
                    {
                        MessageBox.Show("Seleccione Una Forma de Pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _Bol_Val = true;
                    }
                    if (_Rb_Efectivo.Checked)
                    {
                        if (Convert.ToString(_Cb_Caja.SelectedValue) == "nulo")
                        {
                            _Er_Error.SetError(_Cb_Caja, "Seleccione Una Caja.");
                            _Bol_Val = true;
                        }
                    }
                    //else if (_Str_FrmFPago == "")
                    //{
                    if (_Cb_Banco.SelectedIndex <= 0)
                    {
                        _Er_Error.SetError(_Cb_Banco, "Seleccione Un Banco.");
                        _Bol_Val = true;
                    }
                    if (_Cb_Cuenta.SelectedIndex <= 0)
                    {
                        _Er_Error.SetError(_Cb_Cuenta, "Seleccione Una Cuenta.");
                        _Bol_Val = true;
                    }
                    //}
                    if (_Dg_OrdPagoDet.RowCount == 0)
                    {
                        MessageBox.Show("Ingrese Datos en el Detalle.", "Validación");
                        _Bol_Val = true;
                    }
                    if (_Dg_Comprobante.RowCount == 0)
                    {
                        MessageBox.Show("Genere el Comprobante contable.", "Validación");
                        _Bol_Val = true;
                    }
                    if (_Mtd_VerificarSaldo())
                    {
                        MessageBox.Show("El Saldo del Comprobante no es Correcto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _Bol_Val = true;
                    }
                    if (!_Bol_Val)
                    {
                        if (_Bt_Pagar.Enabled)
                        {
                            //VERIFICO EL STATUS DEL USUARIO
                            if (myUtilidad._Mtd_UsuarioProceso(Convert.ToString(_Txt_Usu.Tag), "F_ORDEN_PAGO") == false)
                            {
                                MessageBox.Show("El Usuario no tiene permiso para ejecutar este proceso.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                _Bol_Val = true;
                            }
                            else
                            {
                                //PIDO LA CLAVE DE USUARIO
                                _Lbl_TituloClave.Text = "Guardar Orden de Pago";
                                _Pnl_Clave.Visible = true;
                                _Tb_Tab.Enabled = false;
                                if (_Txt_Clave.Text != "")
                                {
                                    //VERIFICO LA CLAVE
                                    _Str_Sql = "SELECT cpassw FROM TUSER WHERE cuser='" + Convert.ToString(_Txt_Usu.Tag) + "'";
                                    DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                    if (_Ds_A.Tables[0].Rows.Count > 0)
                                    {
                                        byte[] hash = ConvertStringToByteArray(_Txt_Clave.Text);
                                        byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
                                        string _Str_cod = BitConverter.ToString(valorhash);
                                        _Str_cod = _Str_cod.Replace("-", "");
                                        if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) != _Str_cod)
                                        {
                                            MessageBox.Show("La contraseña es Incorrecta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            _Bol_Val = true;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se consiguieron datos para la verificación del Usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        _Bol_Val = true;
                                    }
                                }
                                else
                                { _Bol_Val = true; _Txt_Pwd.Focus(); }
                            }
                        }
                    }

                    if (!_Bol_Val)
                    {
                        if (_Rb_Efectivo.Checked)
                        {
                            _Str_Caja = "'" + Convert.ToString(_Cb_Caja.SelectedValue) + "'";
                            _Str_Banco = "null";
                            _Str_Cuenta = "null";
                        }
                        else if (_Str_FrmFPago != "")
                        {
                            _Str_Caja = "null";
                            _Str_Banco = "'" + Convert.ToString(_Cb_Banco.SelectedValue) + "'";
                            _Str_Cuenta = "'" + Convert.ToString(_Cb_Cuenta.SelectedValue) + "'";
                        }

                        //ME TRAIGO LOS TIPOS DE DOCUMENTOS
                        DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipdocfact,ctipodocnd,ctipodocndp from TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                        if (_Ds_A.Tables[0].Rows.Count > 0)
                        {
                            _Str_Fact = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocfact"]);
                            _Str_ND = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnd"]);
                            _Str_NDP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocndp"]);
                        }

                        try
                        {
                            //GUARDO ORDEN DE PAGO

                            //GUARDO EL DETALLE
                            foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
                            {
                                if (Convert.ToDouble(_DgRow.Cells[4].Value) < 0)
                                { _Dbl_MontoDoc = Convert.ToDouble(_DgRow.Cells[4].Value) * (-1); }
                                else
                                { _Dbl_MontoDoc = Convert.ToDouble(_DgRow.Cells[4].Value); }
                                if (Convert.ToDouble(_DgRow.Cells[5].Value) < 0)
                                { _Dbl_MontoCancelar = Convert.ToDouble(_DgRow.Cells[5].Value) * (-1); }
                                else
                                { _Dbl_MontoCancelar = Convert.ToDouble(_DgRow.Cells[5].Value); }
                                if (Convert.ToDouble(_DgRow.Cells[7].Value) < 0)
                                { _Dbl_MontoImp = Convert.ToDouble(_DgRow.Cells[7].Value) * (-1); }
                                else
                                { _Dbl_MontoImp = Convert.ToDouble(_DgRow.Cells[7].Value); }

                                if (Convert.ToString(_DgRow.Cells[10].Value).Trim() != "")
                                { _Str_DescPPPId = "'" + Convert.ToString(_DgRow.Cells[10].Value) + "'"; }
                                else
                                { _Str_DescPPPId = "null"; }

                                if (Convert.ToString(_DgRow.Cells[9].Value).Trim() != "")
                                { _Dbl_MontoDesc = Convert.ToDouble(_DgRow.Cells[9].Value); }
                                else
                                { _Dbl_MontoDesc = 0; }

                                _Dbl_MontoDescAcum = _Dbl_MontoDescAcum + _Dbl_MontoDesc;
                                _Str_Sql = "SELECT * FROM TPAGOSCXPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago=" + _Txt_Transaccion.Text + " AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' AND cnumdocu='" + Convert.ToString(_DgRow.Cells[2].Value) + "' AND ctipodocument='" + _Mtd_ObtenerIdTpoDoc(Convert.ToString(_DgRow.Cells[3].Value)) + "'";
                                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds_A.Tables[0].Rows.Count > 0)
                                {
                                    _Str_Sql = "UPDATE TPAGOSCXPD set cfechaemision='" + Convert.ToString(_DgRow.Cells[0].Value) + "',cfechavencimiento='" + Convert.ToString(_DgRow.Cells[1].Value) + "',cmontodocu=" + _Dbl_MontoDoc.ToString().Replace(",", ".").Replace("-", "") + ",cmontocancelar=" + _Dbl_MontoCancelar.ToString().Replace(",", ".").Replace("-", "") + ",cmontoimp=" + _Dbl_MontoImp.ToString().Replace(",", ".").Replace("-", "") + ",cmontoddpp=" + _Dbl_MontoDesc.ToString().Replace(",", ".") + ",cidescuentoppp=" + _Str_DescPPPId;
                                    _Str_Sql = _Str_Sql + " WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago=" + _Txt_Transaccion.Text + " AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' AND cnumdocu='" + Convert.ToString(_DgRow.Cells[2].Value) + "' AND ctipodocument='" + _Mtd_ObtenerIdTpoDoc(Convert.ToString(_DgRow.Cells[3].Value)) + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                }
                                else
                                {
                                    _Str_Sql = "INSERT INTO TPAGOSCXPD (cgroupcomp,ccompany,cidordpago,cproveedor,cnumdocu,ctipodocument,cfechaemision,cfechavencimiento,cmontodocu,cmontocancelar,cmontoimp,cidescuentoppp,cmontoddpp) VALUES('";
                                    _Str_Sql = _Str_Sql + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "'," + _Txt_Transaccion.Text + ",'" + Convert.ToString(_Txt_Prov.Tag).Trim() + "','" + Convert.ToString(_DgRow.Cells[2].Value).Trim() + "','" + Convert.ToString(_DgRow.Cells[8].Value) + "','" + Convert.ToString(_DgRow.Cells[0].Value).Trim() + "','" + Convert.ToString(_DgRow.Cells[1].Value).Trim() + "'," + Convert.ToString(_DgRow.Cells[4].Value).Replace(".", "").Replace(",", ".").Replace("-", "") + "," + Convert.ToString(_DgRow.Cells[5].Value).Replace(".", "").Replace(",", ".").Replace("-", "") + "," + Convert.ToString(_DgRow.Cells[7].Value).Replace(".", "").Replace(",", ".").Replace("-", "") + "," + _Str_DescPPPId + "," + _Dbl_MontoDesc.ToString().Replace(",", ".") + ")";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                }
                                if (_Str_ND.Trim() == Convert.ToString(_DgRow.Cells[8].Value).Trim())
                                {
                                    //DESCUENTO LAS ND ASOCIADAS A LA ORDEN DE PAGO
                                    _Str_Sql = "UPDATE TNOTADEBITOCP SET cdescontada=1,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp='" + _DgRow.Cells[2].Value.ToString() + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                }

                                //MARCO LAS RELACIONES DE PAGO DEL PROVEEDOR
                                _Str_Sql = "UPDATE TFACTPPAGARM SET cordenpaghecha='0',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "'";
                                _Str_Sql = _Str_Sql + " and ctipodocument='" + Convert.ToString(_DgRow.Cells[8].Value) + "' AND cnumdocu='" + Convert.ToString(_DgRow.Cells[2].Value) + "'";
                                if (_Rb_PagoTot.Checked)
                                {
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                }
                                else if (_Rb_Abono.Checked)
                                {
                                    //verifico los abonos de las facturas
                                    if (_Str_Fact == Convert.ToString(_DgRow.Cells[8].Value) | _Str_NDP == Convert.ToString(_DgRow.Cells[8].Value))
                                    {
                                        if (myUtilidad._Mtd_ObtenerRestanteOrdPago(Convert.ToString(_DgRow.Cells[2].Value), Convert.ToString(_DgRow.Cells[8].Value), Convert.ToString(_Txt_Prov.Tag)) == 0)
                                        {
                                            //_Str_Sql = _Str_Sql + " and ctipodocument='" + Convert.ToString(_DgRow.Cells[8].Value) + "' AND cnumdocu='" + Convert.ToString(_DgRow.Cells[2].Value) + "'";
                                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                        }
                                        else
                                        {
                                            _Str_Sql = "UPDATE TFACTPPAGARM SET cordenpaghecha=0,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "'";
                                            _Str_Sql = _Str_Sql + " and ctipodocument='" + Convert.ToString(_DgRow.Cells[8].Value) + "' AND cnumdocu='" + Convert.ToString(_DgRow.Cells[2].Value) + "'";
                                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                        }
                                    }
                                    else
                                    { Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql); }
                                }

                            }
                            bool _Bol_SwDelDocu = false;
                            _Str_Sql = "SELECT * FROM TPAGOSCXPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cidordpago='" + _Txt_Transaccion.Text + "' AND cproveedor='" + _Txt_Prov.Tag.ToString() + "'";
                            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            foreach (DataRow _Drow in _Ds_A.Tables[0].Rows)
                            {
                                _Bol_SwDelDocu = false;
                                foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
                                {
                                    if (_Drow["ctipodocument"].ToString() == _DgRow.Cells[8].Value.ToString() && _Drow["cnumdocu"].ToString() == _DgRow.Cells[2].Value.ToString())
                                    {
                                        _Bol_SwDelDocu = true;
                                        break;
                                    }

                                }
                                if (!_Bol_SwDelDocu)
                                {
                                    _Str_Sql = "DELETE FROM TPAGOSCXPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cidordpago='" + _Txt_Transaccion.Text + "' AND cproveedor='" + _Txt_Prov.Tag.ToString() + "' AND ctipodocument='" + _Drow["ctipodocument"].ToString() + "' AND cnumdocu='" + _Drow["cnumdocu"].ToString() + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    _Str_Sql = "UPDATE TFACTPPAGARM SET cordenpaghecha=0,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Txt_Prov.Tag.ToString() + "' AND ctipodocument='" + _Drow["ctipodocument"].ToString() + "' AND cnumdocu='" + _Drow["cnumdocu"].ToString() + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    if (_Str_ND.Trim() == Convert.ToString(_Drow["ctipodocument"]).Trim())
                                    {
                                        //DESCUENTO LAS ND ASOCIADAS A LA ORDEN DE PAGO
                                        _Str_Sql = "UPDATE TNOTADEBITOCP SET cdescontada=0,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp='" + Convert.ToString(_Drow["cnumdocu"]) + "'";
                                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    }
                                }
                            }
                            string _Str_RifProveedor = _Mtd_BuscarRifDelProveedor(_Txt_Prov.Tag.ToString());
                            _Str_Sql = "UPDATE TPAGOSCXPM SET crif='" + _Str_RifProveedor + "',ctippago='" + _Str_FrmTpoPago + "',cfpago='" + _Str_FrmFPago + "',cbanco=" + _Str_Banco + ",ccaja=" + _Str_Caja + ",cnumcuentad=" + _Str_Cuenta + ",cmontototal=" + _Txt_Total.Text.Replace(".", "").Replace(",", ".") + ",cdescpppago=" + _Dbl_MontoDesc.ToString().Replace(",", ".") + ",cmontototaltext='" + _obj_NumerosaLetras.Numero2Letra(_Txt_Total.Text.Replace(".", ""), 0, 2, "", "Céntimo", LibNumLetras.clsNumerosaLetras.eSexo.Masculino, LibNumLetras.clsNumerosaLetras.eSexo.Masculino).ToUpper() + "'";
                            _Str_Sql = _Str_Sql + " WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago=" + _Txt_Transaccion.Text;
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);

                            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctdocumentopordenp FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                            if (_Ds_A.Tables[0].Rows.Count > 0)
                            {
                                _Str_TpoDoc = "'" + Convert.ToString(_Ds_A.Tables[0].Rows[0][0]).Trim() + "'";
                            }
                            string[] _Str_FechaDocument = new string[2];
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia("DELETE FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Form_cidcomprob + "'");
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia("DELETE FROM TCOMPROBANDD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Form_cidcomprob + "'");
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia("DELETE FROM TMOVAUXILIARCONT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Form_cidcomprob + "'");
                            //MODIFICO EL COMPROBANTE
                            foreach (DataGridViewRow _DgRow in _Dg_Comprobante.Rows)
                            {

                                if (Convert.ToString(_DgRow.Cells[0].Value).Trim() != "T")
                                {
                                    if (Convert.ToString(_DgRow.Cells[4].Value).Trim() == "")
                                    { _Dbl_Debe = 0; }
                                    else
                                    { _Dbl_Debe = Convert.ToDouble(_DgRow.Cells[4].Value); }

                                    if (Convert.ToString(_DgRow.Cells[5].Value).Trim() == "")
                                    { _Dbl_Haber = 0; }
                                    else
                                    { _Dbl_Haber = Convert.ToDouble(_DgRow.Cells[5].Value); }
                                    _Str_FechaDocument = _Mtd_FechaDocumento(Convert.ToString(_DgRow.Cells["_Col_Tipo_Doc"].Value).Trim(), Convert.ToString(_DgRow.Cells["_Col_Documento"].Value).Trim(), Convert.ToString(_Txt_Prov.Tag).Trim());
                                    _Str_corder = Convert.ToString(myUtilidad._Mtd_Consecutivo_TCOMPROBAND(_Str_Form_cidcomprob));
                                    _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,ctothaber,cdateadd,cuseradd,cdescrip) values ('";
                                    _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_Form_cidcomprob + "','" + _Str_corder + "','" + Convert.ToString(_DgRow.Cells[1].Value).Trim() + "','" + Convert.ToString(_DgRow.Cells["_Col_Tipo_Doc"].Value).Trim() + "','" + Convert.ToString(_DgRow.Cells["_Col_Documento"].Value).Trim() + "','" + _Str_FechaDocument[0] + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + Convert.ToString(_DgRow.Cells[3].Value).Trim().ToUpper().Replace("'", "''") + "')";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    if (_Dbl_Debe > 0)
                                    { CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_Form_cidcomprob, Convert.ToString(_DgRow.Cells[1].Value).Trim(), Convert.ToString(_Txt_Prov.Tag).Trim(), Convert.ToString(_DgRow.Cells[3].Value).Trim().ToUpper(), Convert.ToString(_DgRow.Cells["_Col_Tipo_Doc"].Value).Trim(), Convert.ToString(_DgRow.Cells["_Col_Documento"].Value).Trim(), _Str_FechaDocument[0], _Str_FechaDocument[1], CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe), Clases._Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()), Clases._Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()), "D"); }//Aux
                                    else
                                    { CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_Form_cidcomprob, Convert.ToString(_DgRow.Cells[1].Value).Trim(), Convert.ToString(_Txt_Prov.Tag).Trim(), Convert.ToString(_DgRow.Cells[3].Value).Trim().ToUpper(), Convert.ToString(_DgRow.Cells["_Col_Tipo_Doc"].Value).Trim(), Convert.ToString(_DgRow.Cells["_Col_Documento"].Value).Trim(), _Str_FechaDocument[0], _Str_FechaDocument[1], CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber), Clases._Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()), Clases._Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()), "H"); }//Aux
                                    _Dbl_DebeTot = _Dbl_DebeTot + _Dbl_Debe;
                                    _Dbl_HaberTot = _Dbl_HaberTot + _Dbl_Haber;
                                }
                            }
                            _Dbl_Balance = Math.Round(_Dbl_DebeTot, 2) - Math.Round(_Dbl_HaberTot, 2);
                            _Str_Sql = "UPDATE TCOMPROBANC SET ctotdebe=" + _Dbl_DebeTot.ToString().Replace(",", ".") + ",ctothaber=" + _Dbl_HaberTot.ToString().Replace(",", ".") + ",cbalance=" + _Dbl_Balance.ToString().Replace(",", ".") + " where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob=" + _Str_Form_cidcomprob;
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            MessageBox.Show("Transacción guardada satisfactoriamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Str_MyProceso = "";
                            if ((Frm_Padre)this.MdiParent != null)
                            {
                                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                            }
                            _Bol_R = true;
                        }
                        catch
                        { _Bol_R = false; }

                        _Mtd_Bloquear(false);
                        _Grb_Contable.Visible = true;
                        _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        _Bt_Comprobante.Enabled = false;
                        _Pnl_Clave.Visible = false;
                        _Mtd_Actualizar();
                    }

                }

                return _Bol_R;
            }
        }

        public bool _Mtd_Eliminar()
        {
            bool _Bol_R = false;
            string _Str_Sql = "";
            string _Str_ND = "";
            if (_Str_DocCancelado == "0")
            {
                if (MessageBox.Show("Está seguro de Anular esta Orden de Pago?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipdocfact,ctipodocnd from TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    {
                        _Str_ND = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnd"]);
                    }
                    //GUARDO EL DETALLE
                    foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
                    {
                        //DESMARCO LAS RELACIONES DE PAGO DEL PROVEEDOR
                        _Str_Sql = "UPDATE TFACTPPAGARM SET cordenpaghecha=0,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'";
                        _Str_Sql = _Str_Sql + " and cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' and ctipodocument='" + _DgRow.Cells[8].Value.ToString() + "' AND cnumdocu='" + Convert.ToString(_DgRow.Cells[2].Value) + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        if (_Str_ND.Trim() == Convert.ToString(_DgRow.Cells[8].Value).Trim())
                        {
                            //DESCUENTO LAS ND ASOCIADAS A LA ORDEN DE PAGO
                            _Str_Sql = "UPDATE TNOTADEBITOCP SET cdescontada=0,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp='" + Convert.ToString(_DgRow.Cells[2].Value) + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        }
                    }
                    _Str_Sql = "UPDATE TPAGOSCXPM SET canulado=1 WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago=" + _Txt_Transaccion.Text;
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    _Str_Sql = "UPDATE TCOMPROBANC SET cstatus=9,clvalidado=0 WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Form_cidcomprob + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    MessageBox.Show("Transacción Anulada Correctamente.");
                    _Mtd_Ini();
                    _Mtd_Actualizar();
                    if ((Frm_Padre)this.MdiParent != null)
                    {
                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                    }
                    _Tb_Tab.SelectedIndex = 0;
                    _Bol_R = true;
                }
            }
            else if (_Str_DocCancelado == "1")
            { MessageBox.Show("No se puede Anular una Orden de Pago Cancelada","Validación",MessageBoxButtons.OK,MessageBoxIcon.Information); }
            return _Bol_R;
        }

        private void _Mtd_CargarUsoCargo()
        {
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ");
        }

        public void _Mtd_Nuevo()
        {
            if (_Bol_Otros)
            {
                _Tb_Tab.SelectedIndex = 2;
                _Mtd_IniOtros();
                _Txt_FechaOP.Text = new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate());
                _Cb_Banco_Otros.Enabled = true;
                _Txt_OrdenPago.Enabled = true;
                _Grb_TipoOtros.Enabled = true;
                _Grb_FormaPagoOtros.Enabled = true;
                _Bt_Pagar_Otros.Visible = false;
                _Cb_Banco_Otros.Focus();
            }
            else
            {
                _Mtd_Ini();
                _Txt_Transaccion.Text = "";
                _Pnl_DescPPago.Visible = false;
                _Txt_Fecha.Text = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString();
                _Mtd_Bloquear(true);
                _Dg_OrdPagoDet.Rows.Clear();
                _G_Dt_NcSelec.Clear();
                _G_Dt_NdSelec.Clear();
                _Dg_OrdPagoDet.Enabled = false;
                _Tb_Tab.SelectTab(1);
                _Txt_Usu.Tag = Frm_Padre._Str_Use;
                _Txt_Usu.Text = _Str_UsuarioName;
                _Txt_Cargo.Text = _Str_UsuarioCargo;
                _Grb_FPago.Enabled = false;
                _Grb_Banco.Enabled = false;
                _Str_MyProceso = "A";
                if (_Bt_Pagar.Visible)
                { _Bt_Pagar.Enabled = false; _Bt_Cerrar.Enabled = false; _Bt_Anticipos.Enabled = false; }
                if (_Str_InForm == "")
                {
                    _Mtd_BotonesMenu();
                }
            }
        }
        
        private void _Cb_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                if (_Cb_Banco.SelectedIndex > 0)
                {//CARGO LAS CUENTAS
                    _Dg_Comprobante.Rows.Clear();
                    //_Mtd_CargarCtaBanco(Convert.ToString(_Cb_Banco.SelectedValue));
                }
                else
                { _Dg_Comprobante.Rows.Clear(); _Bt_Comprobante.Enabled = false; }
                _Mtd_CargarCtaBanco(Convert.ToString(_Cb_Banco.SelectedValue));
                _Mtd_DesbloqDgOPAdd();
            }
        }

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
        }

        private void _Mtd_CargarCatProve(string _P_Str_Tipo)
        {
            myUtilidad._Mtd_CargarCombo(_Cb_CatProveFind, "Select ccatproveedor,cnombre from TCATPROVEEDOR where cdelete='0' and cglobal='" + _P_Str_Tipo + "'");
        }

        private void _Cb_TpoProveFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cb_TpoProveFind.SelectedIndex > 0)
            {
                if (!_Bol_Sw_ComboProveedor)
                { _Mtd_CargarCatProve(_Cb_TpoProveFind.SelectedValue.ToString()); }
            }
            else
            {
                _Cb_CatProveFind.DataSource = null;
                _Mtd_CargarProvee();
                _Cb_ProveedorFind.SelectedIndex = 0;
            }
        }

        private void _Mtd_CargarProvee()
        {
            string _Str_Sql = "";
            _Str_Sql = "SELECT cproveedor,c_nomb_abreviado FROM TPROVEEDOR WHERE cdelete=0";
            if (Convert.ToString(_Cb_TpoProveFind.SelectedValue) == "1")
            {
                _Str_Sql = _Str_Sql + " and cglobal=" + _Cb_TpoProveFind.SelectedValue.ToString();
                if (_Cb_CatProveFind.SelectedIndex > 0)
                { _Str_Sql = _Str_Sql + " and ccatproveedor='" + _Cb_CatProveFind.SelectedValue.ToString() + "'"; }
            }
            else if (_Cb_TpoProveFind.SelectedIndex > 0)
            {
                _Str_Sql = _Str_Sql + " and ccompany='" + Frm_Padre._Str_Comp + "' and cglobal=" + _Cb_TpoProveFind.SelectedValue.ToString();
                if (_Cb_CatProveFind.SelectedIndex > 0)
                { _Str_Sql = _Str_Sql + " and ccatproveedor='" + _Cb_CatProveFind.SelectedValue.ToString() + "'"; }
            }
            else
            { _Str_Sql = _Str_Sql + " and (ccompany='" + Frm_Padre._Str_Comp + "' or cglobal=1)"; }
            //_Str_Sql = _Str_Sql + " ORDER BY c_nomb_abreviado";

            //Union PQseada para que salgan los proveedores no activos
            _Str_Sql += " UNION ";
            _Str_Sql += " SELECT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado ";
            _Str_Sql += " FROM TPROVEEDOR INNER JOIN ";
            _Str_Sql += " TPROVEEDORHISTORICO ON TPROVEEDOR.cproveedor = TPROVEEDORHISTORICO.cproveedor AND TPROVEEDOR.c_rif = TPROVEEDORHISTORICO.c_rif ";
            _Str_Sql += " WHERE ";
            _Str_Sql += " TPROVEEDORHISTORICO.ccompany='" + Frm_Padre._Str_Comp + "' ";
            _Str_Sql += " ORDER BY TPROVEEDOR.c_nomb_abreviado";

            _Int_SwProvCarga = 1;
            myUtilidad._Mtd_CargarCombo(_Cb_ProveedorFind, _Str_Sql);
            _Int_SwProvCarga = 0;

        }

        private void _Mtd_UsuarioSts(string _Str_UserId)
        {
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cname,cposition,cfirmante FROM TUSER WHERE cuser='" + _Str_UserId + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_UsuarioName = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]);
                _Str_UsuarioFirma = Convert.ToString(_Ds_A.Tables[0].Rows[0][2]);
                _Str_UsuarioCargo = Convert.ToString(_Ds_A.Tables[0].Rows[0][1]);  
            }
            else
            { _Str_UsuarioFirma = ""; _Str_UsuarioCargo = ""; _Str_UsuarioName = ""; }
        }

        private void _Cb_CatProveFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_Bol_Sw_ComboProveedor)
            { _Mtd_CargarProvee(); }
        }

        private void _Cb_ProveedorFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Bol_Sw_ComboProveedor = true;
            if (_Cb_ProveedorFind.SelectedIndex > 0)
            {
               string _Str_Cadena = "Select cglobal,ccatproveedor from TPROVEEDOR WHERE cdelete=0 " +
                                    "AND (ccompany='" + Frm_Padre._Str_Comp + "' or cglobal=1) AND cproveedor='" + _Cb_ProveedorFind.SelectedValue.ToString() + "'";
               DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
               if (_Ds.Tables[0].Rows.Count > 0)
               {
                   if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                   {
                       _Cb_TpoProveFind.SelectedValue = _Ds.Tables[0].Rows[0][0].ToString();
                       _Mtd_CargarCatProve(_Ds.Tables[0].Rows[0][0].ToString());
                   }
                   if (_Ds.Tables[0].Rows[0][1] != System.DBNull.Value)
                   { _Cb_CatProveFind.SelectedValue = _Ds.Tables[0].Rows[0][1].ToString(); }
               }
               _Bol_Sw_ComboProveedor = false;
            }
            else
            {
                if (_Cb_TpoProveFind.SelectedIndex <= 0)
                {
                    _Cb_CatProveFind.DataSource = null;
                }
            }
        }

        private void Frm_OrdenPago_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Bol_Otros)
            {
                CONTROLES._Ctrl_Buscar._txt_text.Text = "";
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
            }
            else
            {
                if (_Bol_Sw == false)
                {
                    CONTROLES._Ctrl_Buscar._txt_text.Text = "";
                    CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
                }
            }
        }

        private void _Dg_Find_DoubleClick(object sender, EventArgs e)
        {
            
        }
        private string _Mtd_ObtenerIdTpoDoc(string _Pr_Str_TpoDoc)
        {
            string _Str_R = "";
            string _Str_Sql = "";
            _Str_Sql = "SELECT ctdocument FROM TDOCUMENT WHERE cname='" + _Pr_Str_TpoDoc + "'";
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_A.Tables[0].Rows.Count>0)
            {
                _Str_R = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]);
            }
            return _Str_R;
        }
       
        public static Byte[] ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }

        private bool _Mtd_MensajesError(DataGridView _myDg, int _P_Int_Row, int _P_Int_Col)
        {
            try
            {
                if (_P_Int_Col == 5)
                {
                    if (Convert.ToString(_myDg.Rows[_P_Int_Row].Cells[_P_Int_Col].Value) != "")
                    {
                        if (!_Mtd_IsNumeric(_myDg.Rows[_P_Int_Row].Cells[_P_Int_Col].Value))
                        {
                            MessageBox.Show("No debe Introducir valores alfanuméricos");
                            _myDg.Rows[_P_Int_Row].Cells[_P_Int_Col].Value = 0;
                            return true;
                        }
                        else if (_myDg.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().Trim().IndexOf(",") == 0)
                        {
                            MessageBox.Show("No debe Introducir comas (,)");
                            _myDg.Rows[_P_Int_Row].Cells[_P_Int_Col].Value = 0;
                            return true;
                        }
                        else if (_myDg.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().Trim().IndexOf(",") == _myDg.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().Trim().Length - 1)
                        {
                            _myDg.Rows[_P_Int_Row].Cells[_P_Int_Col].Value = _myDg.Rows[_P_Int_Row].Cells[_P_Int_Col].Value + "0";
                        }
                    }
                }

            }
            catch { return true; }
            return false;
        }

        private bool _Mtd_ValidarGridCont(DataGridView _Pr_Dg, int[] _Pr_Int_Col)
        {
            int _Int_Filas;
            if (_Pr_Dg.AllowUserToAddRows)
            { _Int_Filas = _Pr_Dg.RowCount - 1; }
            else
            { _Int_Filas = _Pr_Dg.RowCount; }
            for (int f = 0; f < _Int_Filas; f++)
            {
                for (int i = 0; i < _Pr_Int_Col.Length; i++)
                {
                    if (Convert.ToString(_Pr_Dg[_Pr_Int_Col[i], f].Value) == "" || Convert.ToString(_Pr_Dg[_Pr_Int_Col[i], f].Value) == "...")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            if (Convert.ToString(Expression).Contains(","))
            { isNum = Double.TryParse(Convert.ToString(Expression).Replace(".", "").Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum); }
            else
            { isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum); }
            return isNum;
        }
        private double _Mtd_MontoEditando(string _P_Str_OrdenPago, string _P_Str_Documento, string _P_Str_TipoDocumento)
        {
            if (_P_Str_OrdenPago.Trim().Length > 0)
            {
                string _Str_Cadena = "SELECT ISNULL(SUM(cmontocancelar),0) FROM TPAGOSCXPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _P_Str_OrdenPago + "' AND cnumdocu='" + _P_Str_Documento + "' AND ctipodocument='" + _P_Str_TipoDocumento + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    return Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString());
                }
            }
            return 0;
        }
        private void _Dg_OrdPagoDet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            double _Dbl_Acum = 0;
            double _Dbl_MontoDoc = 0;
            bool _Bol_SwM = false;
            bool _Bol_SwM1 = false;
            if (_Str_MyProceso != "" && !_Bol_FGridPago)
            {
                if (e.ColumnIndex == _Dg_OrdPagoDet.Columns["_Dg_OrdPagoDet_Col_Check"].Index)
                {
                    if (Convert.ToString(_Dg_OrdPagoDet[e.ColumnIndex, e.RowIndex].Value) == "1")
                    {
                        if (_Mtd_HayDupliFactForDescPPPago())
                        {
                            MessageBox.Show("Ya hay una Factura seleccionada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            _Dg_OrdPagoDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_OrdPagoDet_CellValueChanged);
                            _Dg_OrdPagoDet[e.ColumnIndex, e.RowIndex].Value = "0";
                            _Dg_OrdPagoDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_OrdPagoDet_CellValueChanged);
                        }
                    }
                }
                else
                {
                    if (_Mtd_MensajesError(_Dg_OrdPagoDet, e.RowIndex, e.ColumnIndex) == false)
                    {
                        if (Convert.ToDouble(_Dg_OrdPagoDet[5, e.RowIndex].Value) != 0)
                        {
                            if (Convert.ToString(_Dg_OrdPagoDet[4, e.RowIndex].Value) != "" && Convert.ToString(_Dg_OrdPagoDet[4, e.RowIndex].Value) != "0")
                            {
                                _Er_Error.SetError(_Txt_Total, "");
                                if (_Str_MyProceso == "A")
                                {
                                    _Dbl_MontoDoc = myUtilidad._Mtd_ObtenerRestanteOrdPago(Convert.ToString(_Dg_OrdPagoDet[2, e.RowIndex].Value), Convert.ToString(_Dg_OrdPagoDet[8, e.RowIndex].Value), Convert.ToString(_Txt_Prov.Tag));
                                }
                                else
                                {
                                    _Dbl_MontoDoc = myUtilidad._Mtd_ObtenerRestanteOrdPago(Convert.ToString(_Dg_OrdPagoDet[2, e.RowIndex].Value), Convert.ToString(_Dg_OrdPagoDet[8, e.RowIndex].Value), Convert.ToString(_Txt_Prov.Tag));
                                    //_Dbl_MontoDoc = Convert.ToDouble(_Dg_OrdPagoDet[4, e.RowIndex].Value);
                                }
                                //ME TRAIGO EL SALDO

                                if (Convert.ToDouble(Convert.ToString(_Dg_OrdPagoDet[4, e.RowIndex].Value).Replace(".", "")) < 0)
                                { _Dbl_MontoDoc = _Dbl_MontoDoc * (-1); }

                                if (_Dbl_MontoDoc < 0)
                                {
                                    if (_Dbl_MontoDoc > Convert.ToDouble(_Dg_OrdPagoDet[5, e.RowIndex].Value))
                                    {
                                        _Er_Error.SetError(_Txt_Total, "La Cantidad a Cancelar no debe ser mayor al Monto a Cancelar");
                                        //MessageBox.Show("La Cantidad a Cancelar no debe ser mayor al Monto a Cancelar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        _Dg_OrdPagoDet[5, e.RowIndex].Value = "0";
                                        _Bol_SwM = true;
                                    }
                                }
                                else
                                {
                                    _Dbl_MontoDoc += _Mtd_MontoEditando(_Txt_Transaccion.Text.Trim(), Convert.ToString(_Dg_OrdPagoDet[2, e.RowIndex].Value), Convert.ToString(_Dg_OrdPagoDet[8, e.RowIndex].Value));
                                    if (Math.Round(_Dbl_MontoDoc, 2) < Convert.ToDouble(_Dg_OrdPagoDet[5, e.RowIndex].Value))
                                    {
                                        MessageBox.Show("La Cantidad a Cancelar no debe ser mayor a " + _Dbl_MontoDoc.ToString("#,##0.00"), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        //_Er_Error.SetError(_Txt_Total, "La Cantidad a Cancelar no debe ser mayor a " + _Dbl_MontoDoc.ToString("#,##0.00"));
                                        //MessageBox.Show("La Cantidad a Cancelar no debe ser mayor al Monto a Cancelar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        _Dg_OrdPagoDet[5, e.RowIndex].Value = _Dbl_MontoDoc.ToString("#,##0.00");
                                        _Bol_SwM = true;
                                    }
                                }
                                if (!_Bol_SwM)
                                {
                                    _Dg_OrdPagoDet[5, e.RowIndex].Value = Convert.ToDouble(_Dg_OrdPagoDet[5, e.RowIndex].Value).ToString("#,##0.00");
                                    foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
                                    {
                                        if (Convert.ToString(_DgRow.Cells[5].Value) != "")
                                        {
                                            _Dbl_Acum = _Dbl_Acum + Convert.ToDouble(_DgRow.Cells[5].Value);
                                            if (Convert.ToString(_DgRow.Cells[5].Value) != "")
                                            {
                                                if (Convert.ToString(_DgRow.Cells[9].Value) != "")
                                                {
                                                    _Dbl_Acum = _Dbl_Acum - Convert.ToDouble(_DgRow.Cells[9].Value);
                                                }

                                            }
                                        }
                                        else
                                        { _Bol_SwM1 = true; }

                                    }
                                    if (!_Bol_SwM1)
                                    {
                                        if (_Dbl_Acum <= 0)
                                        {
                                            _Er_Error.SetError(_Txt_Total, "La Cantidad a Cancelar no debe ser mayor al Monto a Cancelar, tiene que ser un monto superior a 0 (cero).");
                                            //MessageBox.Show("La cantidad total a pagar no es válida, tiene que ser un monto superior a 0 (cero).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                                        }
                                    }
                                    _Txt_Total.Text = _Dbl_Acum.ToString("#,##0.00");
                                }

                            }
                        }
                    }
                    if (!_Mtd_MostrarComprob("1"))
                    {
                        _Mtd_CallComprobOrdPago();
                    }
                }
            }
        }

        private void _Bt_Pagar_Click(object sender, EventArgs e)
        {
            //_Str_SwClave = "C";
            //_Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            //_Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            //_Lbl_TituloClave.Text = "Procesar pago";
            //_Pnl_Clave.Visible = true;
            string _Str_MyComprob = "";
            string _Str_Sql = "";
            string _Str_TpoPago = "";
            string _Str_FPago = "";
            if (_Rb_Transferencia.Checked || _Rb_Cheque.Checked)
            {
                _Bol_Sw = true;
                _Mtd_TIPOYDOCU();
                string _Str_Cadena = "UPDATE TFACTPPAGARM SET cordenpaghecha='1',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "'";
                Frm_EmisionCheque _Frm_EmisionCheque = new Frm_EmisionCheque("1", _Str_Cadena, _Str_Tipo, _Str_Docu, this);
                _Frm_EmisionCheque.MdiParent = this.MdiParent;
                _Frm_EmisionCheque.Dock = DockStyle.Fill;
                _Frm_EmisionCheque.Show();
                _Frm_EmisionCheque._Mtd_Nuevo();
                _Frm_EmisionCheque._Txt_OrdPagoId.Text = _Txt_Transaccion.Text;
                _Frm_EmisionCheque._Dt_Fecha.MinDate = Convert.ToDateTime(_Txt_Fecha.Text);
                _Frm_EmisionCheque._Dt_Fecha.Value = Convert.ToDateTime(_Txt_Fecha.Text);
                _Frm_EmisionCheque._Cb_Banco.SelectedValue = _Cb_Banco.SelectedValue;
                _Frm_EmisionCheque._Cb_Cuenta.SelectedValue = _Cb_Cuenta.SelectedValue;
                if (_Rb_Abono.Checked)
                { _Str_TpoPago = "ABO"; }
                else if (_Rb_PagoTot.Checked)
                { _Str_TpoPago = "PTOT"; }
                if (_Rb_Cheque.Checked)
                { _Str_FPago = "CHEQ"; }
                else if (_Rb_Efectivo.Checked)
                { _Str_FPago = "EFECT"; }
                else if (_Rb_Transferencia.Checked)
                { _Str_FPago = "TRANSF"; }
                else if (_Rb_TCredito.Checked)
                { _Str_FPago = "TARJC"; }
                _Frm_EmisionCheque._Txt_RifCedula.Text = _Mtd_BuscarRifDelProveedor(Convert.ToString(_Txt_Prov.Tag));
                _Frm_EmisionCheque._Cb_TpoPago.SelectedValue = _Str_TpoPago;
                _Frm_EmisionCheque._Cb_FormaPago.SelectedValue = _Str_FPago;
                _Frm_EmisionCheque._Txt_Persona.Tag = Convert.ToString(_Txt_Prov.Tag);
                DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT c_nomb_fiscal FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "'");
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    _Frm_EmisionCheque._Txt_Persona.Text = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]);
                }
                _Str_Sql = "SELECT cidcomprob FROM TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' AND cidordpago='" + _Txt_Transaccion.Text + "'";
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    _Str_MyComprob = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]);
                }
                string _Str_Monto = _Txt_Total.Text;// Convert.ToDouble(Convert.ToDouble(_Txt_Total.Text) - _Mtd_Anticipo(_Txt_Transaccion.Text.Trim())).ToString("#,##0.00");
                _Frm_EmisionCheque._Txt_ComprobId.Text = _Str_MyComprob;
                _Frm_EmisionCheque._Mtd_CargarComprobante(_Str_MyComprob);
                _Frm_EmisionCheque._Txt_Monto.Text = _Str_Monto;
                _Frm_EmisionCheque._Txt_CantDescrip.Text = _obj_NumerosaLetras.Numero2Letra(_Str_Monto.Replace(".", ""), 0, 2, "", "Céntimo", LibNumLetras.clsNumerosaLetras.eSexo.Masculino, LibNumLetras.clsNumerosaLetras.eSexo.Masculino).ToUpper();
                _Frm_EmisionCheque._Cb_Banco.Enabled = false;
                _Frm_EmisionCheque._Cb_Cuenta.Enabled = false;
                _Frm_EmisionCheque._Cb_TpoPago.Enabled = false;
                _Frm_EmisionCheque._Cb_FormaPago.Enabled = false;
                _Frm_EmisionCheque._Txt_FirmaSol.Tag = Frm_Padre._Str_Use;
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cname from TUSER where cuser='" + Frm_Padre._Str_Use + "'");
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    _Frm_EmisionCheque._Txt_FirmaSol.Text = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]);
                }
                _Frm_EmisionCheque._Txt_Concepto.Focus();
                this.Close();
            }
        }

        private void _Cb_ProveedorFind_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarProvee();
        }

        private void _Cb_Caja_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarCajas();
        }

        private void _Cb_Cuenta_DropDown(object sender, EventArgs e)
        {
            if (_Cb_Banco.SelectedIndex > 0)
            {//CARGO LAS CUENTAS
                _Mtd_CargarCtaBanco(Convert.ToString(_Cb_Banco.SelectedValue));
            }
        }

        private void _Cb_Cuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                if (_Cb_Cuenta.SelectedIndex > 0)
                {
                    _Dg_Comprobante.Rows.Clear();
                    if (_Cb_Banco.SelectedIndex > 0)
                    {
                        _Bt_Comprobante.Enabled = true;
                    }
                    else
                    { _Bt_Comprobante.Enabled = false; }
                }
                else
                { _Dg_Comprobante.Rows.Clear(); _Bt_Comprobante.Enabled = false; }
                _Mtd_DesbloqDgOPAdd();
            }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Str_SwClave == "G")
            {
                if (_Pnl_Clave.Visible)
                {

                    _Mtd_Bloquear(false);
                    _Txt_Clave.Text = "";
                }
                else
                {
                    _Lbl_TituloClave.Text = "...";
                }
            }
            _Txt_Clave.Focus();
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
            _Txt_Clave.Text = "";
            _Str_SwClave = "";
            _Tb_Tab.Enabled = true;
            //_Mtd_Bloquear(false);
        }

        private void _Bt_Ok_Click(object sender, EventArgs e)
        {
            if (_Txt_Clave.Text.Trim() != "")
            {
                Cursor = Cursors.WaitCursor;
                if (_Str_MyProceso == "M")
                { _Mtd_Editar(); }
                if (_Str_SwClave == "G")//VALIDACION AL GUARDAR
                { _Mtd_Guardar(); }
                if (_Str_SwClave == "C")//VALIDACION AL PROCESAR PAGO
                {
                    if (_Txt_Clave.Text.Trim() != "")
                    {
                      //
                    }
                    else
                    {
                        MessageBox.Show("Ingrese la contraseña para poder procesar el pago", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                { }
                Cursor = Cursors.Default;
            }
            _Tb_Tab.Enabled = true;
        }

        private void _Bt_EditComprob_Click(object sender, EventArgs e)
        {

        }

        private void _Mtd_DgComprobanteCol()
        {
            _Dg_Comprobante.Columns[0].ReadOnly = true;
            _Dg_Comprobante.Columns[1].ReadOnly = true;
            _Dg_Comprobante.Columns[2].ReadOnly = false;
            _Dg_Comprobante.Columns[3].ReadOnly = true;
            _Dg_Comprobante.Columns[4].ReadOnly = false;
            _Dg_Comprobante.Columns[5].ReadOnly = false;
        }

        private void _Bt_Comprobante_Click(object sender, EventArgs e)
        {
            if (!_Mtd_MostrarComprob("1"))
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_CallComprobOrdPago();
                Cursor = Cursors.Default;
            }
        }

        public void _Mtd_CallComprobOrdPago()
        {
            _Int_FrmTotComprobSw = 1;
            _Dg_Comprobante.ReadOnly = true;
            _Dg_Comprobante.AllowUserToAddRows = false;
            _Dg_Comprobante.Rows.Clear();
            _Mtd_GenerarComprobOrdPago();
            _Mtd_FilaTotal();
            foreach (DataGridViewRow _DgRow in _Dg_Comprobante.Rows)
            {
                for (int _Int_I = 0; _Int_I < _Dg_Comprobante.ColumnCount; _Int_I++)
                {
                    if (_Int_I == 2)
                    { _DgRow.Cells[_Int_I].Style.BackColor = Color.Navy; }
                    else
                    { _DgRow.Cells[_Int_I].Style.BackColor = Color.Tan; }
                }
            }
            _Mtd_TotalizarComprobante();
            _Grb_Contable.Visible = true;
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void _Mtd_TotalizarComprobante()
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            foreach (DataGridViewRow _DgRow in _Dg_Comprobante.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[4].Value) != "")
                {
                    _Dbl_Debe = _Dbl_Debe + Convert.ToDouble(_DgRow.Cells[4].Value);
                }
                if (Convert.ToString(_DgRow.Cells[5].Value) != "")
                {
                    _Dbl_Haber = _Dbl_Haber + Convert.ToDouble(_DgRow.Cells[5].Value);
                }
            }
        }
        string[] _Str_Tipo=new string[0];
        string[] _Str_Docu = new string[0];
        private void _Mtd_TIPOYDOCU()
        {
            _Str_Tipo = new string[0];
            _Str_Docu = new string[0];
            foreach (DataGridViewRow _Dg_Row in _Dg_OrdPagoDet.Rows)
            {
                _Str_Tipo = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Tipo, _Str_Tipo.Length + 1);
                _Str_Tipo[_Str_Tipo.Length - 1] = _Dg_Row.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value.ToString();
                //----------------------------------------------
                _Str_Docu = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Docu, _Str_Docu.Length + 1);
                _Str_Docu[_Str_Docu.Length - 1] = _Dg_Row.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value.ToString();
            }
        }
        private bool _Mtd_AgregarISLRoIVA(string _P_Str_TipoDocument,string _P_Str_Documento)
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_OrdPagoDet.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value).Trim().ToUpper() == _P_Str_TipoDocument.Trim().ToUpper() & Convert.ToString(_Dg_Row.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value).Trim() == _P_Str_Documento.Trim().ToUpper())
                {
                    return true;
                }
            }
            return false;
        }
        private double _Mtd_MontoCompleto(string _P_Str_OrdenPago)
        {
            double _Dbl_MontoOrdenPago = 0;
            string _Str_Cadena = "SELECT ISNULL(SUM(cmontototal),0) FROM TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _P_Str_OrdenPago + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Dbl_MontoOrdenPago = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString().Trim());
            }
            return _Dbl_MontoOrdenPago += _Mtd_Anticipo(_P_Str_OrdenPago);
        }
        private string _Mtd_ProcesoCont(string _P_Str_Proveedor)
        {
            string _Str_Global = "";
            string _Str_CatProvv = "";
            string _Str_ServicioP = "";
            string _Str_CompaP = "";
            string _Str_AccionP = "";
            string _Str_CompaC = "";
            string _Str_AccionC = "";
            string _Str_ProvRETIVA = "";
            string _Str_ProvRETISLR = "";
            string _Str_Cadena = "SELECT cglobal,ccatproveedor FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) AND cproveedor='" + _P_Str_Proveedor + "'";
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_Global = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cglobal"]);
                _Str_CatProvv = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ccatproveedor"]);
            }
            _Str_Cadena = "SELECT cprovretiva,cprovretislr,cprocecontserv,cprocecontciarel,cprocecontaccio,ccatproveciarel,ccatproveaccio FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_ProvRETIVA = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cprovretiva"]);
                _Str_ProvRETISLR = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cprovretislr"]);
                //-------------------
                _Str_ServicioP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cprocecontserv"]);
                _Str_CompaP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cprocecontciarel"]);
                _Str_AccionP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cprocecontaccio"]);
                _Str_CompaC = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ccatproveciarel"]);
                _Str_AccionC = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ccatproveaccio"]);
            }
            if (_P_Str_Proveedor == _Str_ProvRETIVA)
            {
                return "P_BCO_CHQ_PROV_IVA";
            }
            else if (_P_Str_Proveedor == _Str_ProvRETISLR)
            {
                return "P_BCO_CHQ_PROV_ISLR";
            }
            else
            {
                if (_Str_Global.Trim() == "0")
                {
                    return _Str_ServicioP;
                }
                else if (_Str_Global.Trim() == "1")
                {
                    return "P_BCO_CHQ_PROVEE";
                }
                else if (_Str_Global.Trim() == "2" & _Str_CatProvv.Trim().ToUpper() == _Str_CompaC.Trim().ToUpper())
                {
                    return _Str_CompaP;
                }
                else if (_Str_Global.Trim() == "2" & _Str_CatProvv.Trim().ToUpper() == _Str_AccionC.Trim().ToUpper())
                {
                    return _Str_AccionP;
                }
                else
                {
                    return _Str_ServicioP;
                }
            }
        }
        private void _Mtd_GenerarComprobOrdPago()
        {//ARMA EL COMPROBANTE DE ORDEN DE PAGO************************************
            string _Str_Sql = "";
            string _Str_Global = "";
            string _Str_CatProvv = "";
            string _Str_Nrecep = "";
            string _Str_DocFact = "";
            string _Str_DocND = "";
            string _Str_DocNC = "";
            string _Str_DocNDP = "";
            string _Str_DocNCP = "";
            string _Str_DocRet = "";
            string _Str_DocRetISLR = "";
            string _Str_DocRetPatente = "";
            string _Str_CountProveedor = "", _Str_CountProveedorDescrip="";
            string _Str_CountBanco = "", _Str_CountBancoDescrip="";
            string _Str_ProvRETIVA = "";
            string _Str_ProvRETISLR = "";
            string _Str_ProvRETPATENTE = "";
            string _Str_CountIVA = "";
            string _Str_CountISLR = "";
            string _Str_CountPatente = "";
            //---------------------------------
            string _Str_ServicioP = "";
            string _Str_CompaP = "";
            string _Str_AccionP = "";
            string _Str_CompaC = "";
            string _Str_AccionC = "";
            //---------------------------------
            string _Str_NFact = "";
            string _Str_DescripRetencion = "";
            string _Str_DescripRetISRL = "";
            string _Str_DescripDesc = "";
            string _Str_DescripRetPatente="";
            string[] _Str_VecRetencion = new string[0];
            string[] _Str_VecRetISRL = new string[0];
            string[] _Str_VecRetPatente = new string[0];
            double _Dbl_monto_banco = 0;
            double _Dbl_MontoTot = 0;
            double _Dbl_MontoRet = 0;
            double _Dbl_MontoAux = 0;
            double _Dbl_MontoRetISRL = 0;
            double _Dbl_MontoRetPatente = 0;
            double _Dbl_MontoDesc = 0;

            //Programación de comprobante contable según debito bancario
            bool _Bol_DebitoBancario = false;
            double _Dbl_monto_debitoBancario = 0;
            string _Str_CuentaContableDebitoBancario = "";
            double _Dbl_PorcentajeDebitoBancario=0;
            bool _Bol_ProveedorExentoDebitoBancario = false;
            string _Str_ProcesoContableDebitoBancario = "CXP_DEBITOBANC";
            DataSet _Ds_DebitoBancario = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cdebitobancario,cporcentdebitobancario FROM TCONFIGCONSSA");
            if (_Ds_DebitoBancario.Tables[0].Rows.Count > 0)
            {
                if (_Ds_DebitoBancario.Tables[0].Rows[0]["cdebitobancario"].ToString() == "1")
                {
                    _Bol_DebitoBancario = true;
                }               
                if (_Ds_DebitoBancario.Tables[0].Rows[0]["cporcentdebitobancario"].ToString() != "")
                {
                    _Dbl_PorcentajeDebitoBancario=Convert.ToDouble(_Ds_DebitoBancario.Tables[0].Rows[0]["cporcentdebitobancario"].ToString());
                }               
            }
            //


//            double _Dbl_monto_ctxpagar = 0;
            _Dbl_monto_banco = _Mtd_CalcularTotalPago();// _Mtd_MontoCompleto(_Txt_Transaccion.Text.Trim());
            DataSet _Ds;
            _Dg_Comprobante.Rows.Clear();
            DataSet _Ds_B;
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cglobal,ccatproveedor,CEXENTODEBITOBANCARIO FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_Global = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cglobal"]);
                _Str_CatProvv = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ccatproveedor"]);
                if (_Ds_A.Tables[0].Rows[0]["CEXENTODEBITOBANCARIO"].ToString() != "")
                {
                    if (_Ds_A.Tables[0].Rows[0]["CEXENTODEBITOBANCARIO"].ToString() == "1")
                    {
                        _Bol_ProveedorExentoDebitoBancario = true;
                    }
                }
            }
            if (_Bol_ProveedorExentoDebitoBancario)
            {
                _Bol_DebitoBancario = false;
            }
            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctipdocfact,ctipodocnc,ctipodocnd,ctipdocretiva,ctipdocretislr,cprovretiva,cprovretislr,cprocecontserv,cprocecontciarel,cprocecontaccio,ccatproveciarel,ccatproveaccio,ctipodocndp,ccountreteniva,ccountretenislr,ctipodocncp, ctipodocretpat,ccountretenpatente,cprovretpat FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_DocFact = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocfact"]);
                _Str_DocNC = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnc"]);
                _Str_DocND = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnd"]);
                _Str_DocNDP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocndp"]);
                _Str_DocNCP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocncp"]);
                _Str_DocRet = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocretiva"]);
                _Str_DocRetISLR = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocretislr"]);
                _Str_ProvRETIVA = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cprovretiva"]);
                _Str_ProvRETISLR = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cprovretislr"]);
                //-------------------
                _Str_ServicioP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cprocecontserv"]);
                _Str_CompaP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cprocecontciarel"]);
                _Str_AccionP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cprocecontaccio"]);
                _Str_CompaC = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ccatproveciarel"]);
                _Str_AccionC = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ccatproveaccio"]);
                //-------------------
                _Str_CountIVA = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ccountreteniva"]);
                _Str_CountISLR = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ccountretenislr"]);
                _Str_DocRetPatente = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocretpat"]);
                _Str_CountPatente = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ccountretenpatente"]);
                _Str_ProvRETPATENTE = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cprovretpat"]);
            }
            //-----------------------------------------------------------------------
            string _Str_PROCESOCONTABLE = "";
            if (Convert.ToString(_Txt_Prov.Tag).Trim() == _Str_ProvRETIVA)
            {
                _Str_PROCESOCONTABLE = "P_BCO_CHQ_PROV_IVA";
            }
            else if (Convert.ToString(_Txt_Prov.Tag).Trim() == _Str_ProvRETISLR)
            {
                _Str_PROCESOCONTABLE = "P_BCO_CHQ_PROV_ISLR";
            }
            else if (Convert.ToString(_Txt_Prov.Tag).Trim() == _Str_ProvRETPATENTE)
            {
                _Str_PROCESOCONTABLE = "P_BCO_CHQ_PROV_RPAT";
            }
            else
            {
                if (_Str_Global.Trim() == "0")
                {
                    _Str_PROCESOCONTABLE = _Str_ServicioP;
                }
                else if (_Str_Global.Trim() == "1")
                {
                    _Str_PROCESOCONTABLE = "P_BCO_CHQ_PROVEE";
                }
                else if (_Str_Global.Trim() == "2" & _Str_CatProvv.Trim().ToUpper() == _Str_CompaC.Trim().ToUpper())
                {
                    _Str_PROCESOCONTABLE = _Str_CompaP;
                }
                else if (_Str_Global.Trim() == "2" & _Str_CatProvv.Trim().ToUpper() == _Str_AccionC.Trim().ToUpper())
                {
                    _Str_PROCESOCONTABLE = _Str_AccionP;
                }
                else
                {
                    _Str_PROCESOCONTABLE = _Str_ServicioP;
                }
            }
            //-----------------------------------------------------------------------
            _Str_Sql = "Select ccount,ctipodocumento,cnaturaleza,cideprocesod,ccountname from VST_PROCESOSCONTD where cidproceso='" + _Str_PROCESOCONTABLE + "' and (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL)";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                
                //--------------------------------
                if (_Row["cideprocesod"].ToString() == "1")
                {
                    _Str_CountProveedor = _Row["ccount"].ToString().Trim();
                    _Str_CountProveedorDescrip = _Row["ccountname"].ToString().Trim();
                }
                else if (_Row["cideprocesod"].ToString() == "2")
                {
                    if (_Row["ccount"].ToString() == CLASES._Cls_Varios_Metodos._Str_G_CuentaContBanco)
                    {
                        _Str_Sql = "SELECT ccount,cname FROM VST_CUENTBANCCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cnumcuenta='" + Convert.ToString(_Cb_Cuenta.SelectedValue) + "' AND cbanco='" + Convert.ToString(_Cb_Banco.SelectedValue) + "'";
                        _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds_A.Tables[0].Rows.Count > 0)
                        {
                            _Str_CountBanco = _Ds_A.Tables[0].Rows[0]["ccount"].ToString().Trim();
                            _Str_CountBancoDescrip = _Ds_A.Tables[0].Rows[0]["cname"].ToString().Trim();
                        }
                    }
                }
            }
            //VEO SI SE TRATA DE UN PROVEEDOR DE RETIVA, ISLR O PATENTE
            if (Convert.ToString(_Txt_Prov.Tag).Trim() == _Str_ProvRETIVA.Trim() || Convert.ToString(_Txt_Prov.Tag).Trim() == _Str_ProvRETISLR.Trim() || Convert.ToString(_Txt_Prov.Tag).Trim() == _Str_ProvRETPATENTE.Trim())
            {
                foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
                {
                    _Dg_Comprobante.Rows.Add();
                    if (Convert.ToString(_DgRow.Cells[8].Value).Trim() == _Str_DocRet.Trim())
                    { _Str_CountProveedor = _Str_CountIVA; }
                    else if (Convert.ToString(_DgRow.Cells[8].Value).Trim() == _Str_DocRetISLR.Trim())
                    { _Str_CountProveedor = _Str_CountISLR; }
                    else
                    {
                        _Str_CountProveedor = _Str_CountPatente;
                    }
                    _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = _Str_CountProveedor;
                    _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = _Txt_Prov.Text + " CANCELACION " + Convert.ToString(_DgRow.Cells[3].Value) + " Nº" + Convert.ToString(_DgRow.Cells[2].Value) + " VEC:" + Convert.ToString(_DgRow.Cells[1].Value);
                    _Dbl_MontoTot = Convert.ToDouble(_DgRow.Cells[5].Value);
                    if (Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value).Trim() == _Str_DocRet.Trim() && _Mtd_TipoDocumentAfecReteIva(Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value)) == _Str_DocNCP)
                    {
                        _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = "";
                        _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = _Dbl_MontoTot.ToString("#,##0.00").Replace("-", "");
                    }
                    else
                    {
                        _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = _Dbl_MontoTot.ToString("#,##0.00");
                        _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = "";
                    }
                    _Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value);
                    _Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value);
                }
            }
            else
            {
                foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
                {//VALIDO LAS FACTURAS
                    _Str_Sql = "SELECT cidnotrecepc from VST_FACTPPAGARM WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " and ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + Convert.ToString(_DgRow.Cells[6].Value) + "'";
                    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    { _Str_Nrecep = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]); }
                    //_Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_Ds.Tables[0].Rows[0]["ctcountname"].ToString());
                    if (_Str_Global == "1")
                    {
                        if ((Convert.ToString(_DgRow.Cells[8].Value) == _Str_DocFact) | (Convert.ToString(_DgRow.Cells[8].Value) == _Str_DocNDP))
                        {
                            _Dg_Comprobante.Rows.Add();
                            _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = _Str_CountProveedor;
                            if (_Str_Nrecep.Trim().Length > 0 & _Str_Nrecep.Trim() != "0")
                            {
                                if ((Convert.ToString(_DgRow.Cells[8].Value) == _Str_DocFact))
                                { _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = _Txt_Prov.Text + " S/NR:" + _Str_Nrecep + " CANCELACION FACTURA S/F:" + Convert.ToString(_DgRow.Cells[2].Value) + " VEC:" + Convert.ToString(_DgRow.Cells[1].Value); }
                                else
                                { _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = _Txt_Prov.Text + " S/NR:" + _Str_Nrecep + " CANCELACION NOTA DÉBITO S/ND:" + Convert.ToString(_DgRow.Cells[2].Value) + " VEC:" + Convert.ToString(_DgRow.Cells[1].Value); }
                            }
                            else
                            {
                                if ((Convert.ToString(_DgRow.Cells[8].Value) == _Str_DocFact))
                                { _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = _Txt_Prov.Text + " CANCELACION FACTURA S/F:" + Convert.ToString(_DgRow.Cells[2].Value) + " VEC:" + Convert.ToString(_DgRow.Cells[1].Value); }
                                else
                                { _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = _Txt_Prov.Text + " CANCELACION NOTA DÉBITO S/ND:" + Convert.ToString(_DgRow.Cells[2].Value) + " VEC:" + Convert.ToString(_DgRow.Cells[1].Value); }
                            }
                            _Dbl_MontoTot = Convert.ToDouble(_DgRow.Cells[5].Value);
                            _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = _Dbl_MontoTot.ToString("#,##0.00");
                            _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = "";
                            //busco las retenciones asociadas al documento
                            _Str_Sql = "select cidcomprobret from TFACTPPAGARM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' and (ctipodocument='" + _Str_DocFact + "' OR ctipodocument='" + _Str_DocNDP + "') and cnumdocu='" + Convert.ToString(_DgRow.Cells[2].Value) + "'";
                            _Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds_B.Tables[0].Rows.Count > 0)
                            {
                                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cordenpaghecha FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' AND ctipodocument='" + _Str_DocRet + "' AND cnumdocu='" + Convert.ToString(_Ds_B.Tables[0].Rows[0][0]) + "'");
                                if (_Ds_A.Tables[0].Rows.Count > 0)
                                {
                                    //if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) == "0")
                                    //{
                                    if (_Mtd_AgregarISLRoIVA(_Str_DocRet, Convert.ToString(_Ds_B.Tables[0].Rows[0][0])))
                                    {
                                        _Str_VecRetencion = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_VecRetencion, _Str_VecRetencion.Length + 1);
                                        _Str_VecRetencion[_Str_VecRetencion.Length - 1] = Convert.ToString(_Ds_B.Tables[0].Rows[0][0]);
                                    }
                                    //}
                                }
                            }
                            //CARGO EN EL VECTOR LOS COMPROBANTES DE RETENCION DEL ISRL POR FACTURA
                            _Str_Sql = "select cidcomprobislr from TFACTPPAGARM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' and (ctipodocument='" + _Str_DocFact + "' OR ctipodocument='" + _Str_DocNDP + "') and cnumdocu='" + Convert.ToString(_DgRow.Cells[2].Value) + "'";
                            _Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds_B.Tables[0].Rows.Count > 0)
                            {
                                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cordenpaghecha FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' AND ctipodocument='" + _Str_DocRetISLR + "' AND cnumdocu='" + Convert.ToString(_Ds_B.Tables[0].Rows[0][0]) + "'");
                                if (_Ds_A.Tables[0].Rows.Count > 0)
                                {
                                    //if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) == "0" & myUtilidad._Mtd_ObtenerAbonoOrdPago(Convert.ToString(_Ds_B.Tables[0].Rows[0][0]), _Str_DocRet, Convert.ToString(_Txt_Prov.Tag)) == 0)
                                    //{
                                    if (_Mtd_AgregarISLRoIVA(_Str_DocRetISLR, Convert.ToString(_Ds_B.Tables[0].Rows[0][0])))
                                    {
                                        _Str_VecRetISRL = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_VecRetISRL, _Str_VecRetISRL.Length + 1);
                                        _Str_VecRetISRL[_Str_VecRetISRL.Length - 1] = Convert.ToString(_Ds_B.Tables[0].Rows[0][0]);
                                    }
                                    //}
                                }
                            }
                            //CARGO EN EL VECTOR LOS COMPROBANTES DE RETENCION DEL PATENTE POR FACTURA
                            _Str_Sql = "select cidcomprobretpat from TFACTPPAGARM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' and (ctipodocument='" + _Str_DocFact + "' OR ctipodocument='" + _Str_DocNDP + "') and cnumdocu='" + Convert.ToString(_DgRow.Cells[2].Value) + "'";
                            _Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds_B.Tables[0].Rows.Count > 0)
                            {
                                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cordenpaghecha FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' AND ctipodocument='" + _Str_DocRetPatente + "' AND cnumdocu='" + Convert.ToString(_Ds_B.Tables[0].Rows[0][0]) + "'");
                                if (_Ds_A.Tables[0].Rows.Count > 0)
                                {
                                    //if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) == "0" & myUtilidad._Mtd_ObtenerAbonoOrdPago(Convert.ToString(_Ds_B.Tables[0].Rows[0][0]), _Str_DocRet, Convert.ToString(_Txt_Prov.Tag)) == 0)
                                    //{
                                    if (_Mtd_AgregarISLRoIVA(_Str_DocRetPatente, Convert.ToString(_Ds_B.Tables[0].Rows[0][0])))
                                    {
                                        _Str_VecRetPatente = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_VecRetPatente, _Str_VecRetPatente.Length + 1);
                                        _Str_VecRetPatente[_Str_VecRetPatente.Length - 1] = Convert.ToString(_Ds_B.Tables[0].Rows[0][0]);
                                    }
                                    //}
                                }
                            }
                            _Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value);
                            _Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value);
                        }
                        else if ((Convert.ToString(_DgRow.Cells[8].Value) == _Str_DocRet) | (Convert.ToString(_DgRow.Cells[8].Value) == _Str_DocRetISLR) | (Convert.ToString(_DgRow.Cells[8].Value) == _Str_DocRetPatente))
                        {
                            if (Convert.ToString(_DgRow.Cells[8].Value) == _Str_DocRet)
                            {
                                if (Array.IndexOf(_Str_VecRetencion, Convert.ToString(_DgRow.Cells[2].Value).Trim()) < 0)
                                {
                                    _Str_VecRetencion = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_VecRetencion, _Str_VecRetencion.Length + 1);
                                    _Str_VecRetencion[_Str_VecRetencion.Length - 1] = Convert.ToString(_DgRow.Cells[2].Value).Trim();
                                    //_Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value);
                                    //_Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value);
                                }
                            }
                            else if (Convert.ToString(_DgRow.Cells[8].Value) == _Str_DocRetISLR)
                            {
                                if (Array.IndexOf(_Str_VecRetISRL, Convert.ToString(_DgRow.Cells[2].Value).Trim()) < 0)
                                {
                                    _Str_VecRetISRL = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_VecRetISRL, _Str_VecRetISRL.Length + 1);
                                    _Str_VecRetISRL[_Str_VecRetISRL.Length - 1] = Convert.ToString(_DgRow.Cells[2].Value).Trim();
                                    //_Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value);
                                    //_Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value);
                                }
                            }
                            else
                            {
                                if (Array.IndexOf(_Str_VecRetPatente, Convert.ToString(_DgRow.Cells[2].Value).Trim()) < 0)
                                {
                                    _Str_VecRetPatente = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_VecRetPatente, _Str_VecRetPatente.Length + 1);
                                    _Str_VecRetPatente[_Str_VecRetPatente.Length - 1] = Convert.ToString(_DgRow.Cells[2].Value).Trim();
                                    //_Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value);
                                    //_Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value);
                                }
                            }
                        }
                    }
                    else
                    {
                        if ((Convert.ToString(_DgRow.Cells[8].Value) == _Str_DocFact) | (Convert.ToString(_DgRow.Cells[8].Value) == _Str_DocNDP))
                        {
                            _Dg_Comprobante.Rows.Add();
                            _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = _Str_CountProveedor;
                            if ((Convert.ToString(_DgRow.Cells[8].Value) == _Str_DocFact))
                            { _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = _Txt_Prov.Text + " CANCELACION FACTURA S/F:" + Convert.ToString(_DgRow.Cells[2].Value) + " VEC:" + Convert.ToString(_DgRow.Cells[1].Value); }
                            else
                            { _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = _Txt_Prov.Text + " CANCELACION NOTA DÉBITO S/ND:" + Convert.ToString(_DgRow.Cells[2].Value) + " VEC:" + Convert.ToString(_DgRow.Cells[1].Value); }
                            _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = Convert.ToDouble(_DgRow.Cells[5].Value).ToString("#,##0.00");
                            _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = "";
                            //busco las retenciones asociadas al documento
                            _Str_Sql = "select cidcomprobret from TFACTPPAGARM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND  ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' and (ctipodocument='" + _Str_DocFact + "' OR ctipodocument='" + _Str_DocNDP + "') and cnumdocu='" + Convert.ToString(_DgRow.Cells[2].Value) + "'";
                            _Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds_B.Tables[0].Rows.Count > 0)
                            {
                                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cordenpaghecha FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' AND ctipodocument='" + _Str_DocRet + "' AND cnumdocu='" + Convert.ToString(_Ds_B.Tables[0].Rows[0][0]) + "'");
                                if (_Ds_A.Tables[0].Rows.Count > 0)
                                {
                                    //if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) == "0")
                                    //{
                                    if (_Mtd_AgregarISLRoIVA(_Str_DocRet, Convert.ToString(_Ds_B.Tables[0].Rows[0][0])))
                                    {
                                        _Str_VecRetencion = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_VecRetencion, _Str_VecRetencion.Length + 1);
                                        _Str_VecRetencion[_Str_VecRetencion.Length - 1] = Convert.ToString(_Ds_B.Tables[0].Rows[0][0]);
                                    }
                                    //}
                                }
                            }
                            //CARGO EN EL VECTOR LOS COMPROBANTES DE RETENCION DEL ISRL POR FACTURA
                            _Str_Sql = "select cidcomprobislr from TFACTPPAGARM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND  ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' and (ctipodocument='" + _Str_DocFact + "' OR ctipodocument='" + _Str_DocNDP + "') and cnumdocu='" + Convert.ToString(_DgRow.Cells[2].Value) + "'";
                            _Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds_B.Tables[0].Rows.Count > 0)
                            {
                                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cordenpaghecha FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' AND ctipodocument='" + _Str_DocRetISLR + "' AND cnumdocu='" + Convert.ToString(_Ds_B.Tables[0].Rows[0][0]) + "'");
                                if (_Ds_A.Tables[0].Rows.Count > 0)
                                {
                                    //if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) == "0" & myUtilidad._Mtd_ObtenerAbonoOrdPago(Convert.ToString(_Ds_B.Tables[0].Rows[0][0]), _Str_DocRetISLR, Convert.ToString(_Txt_Prov.Tag)) == 0)
                                    //{
                                    if (_Mtd_AgregarISLRoIVA(_Str_DocRetISLR, Convert.ToString(_Ds_B.Tables[0].Rows[0][0])))
                                    {
                                        _Str_VecRetISRL = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_VecRetISRL, _Str_VecRetISRL.Length + 1);
                                        _Str_VecRetISRL[_Str_VecRetISRL.Length - 1] = Convert.ToString(_Ds_B.Tables[0].Rows[0][0]);
                                    }
                                    //}
                                }
                            }
                            //CARGO EN EL VECTOR LOS COMPROBANTES DE RETENCION DE PATENTE POR FACTURA
                            _Str_Sql = "select cidcomprobretpat from TFACTPPAGARM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND  ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' and (ctipodocument='" + _Str_DocFact + "' OR ctipodocument='" + _Str_DocNDP + "') and cnumdocu='" + Convert.ToString(_DgRow.Cells[2].Value) + "'";
                            _Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds_B.Tables[0].Rows.Count > 0)
                            {
                                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cordenpaghecha FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' AND ctipodocument='" + _Str_DocRetPatente+ "' AND cnumdocu='" + Convert.ToString(_Ds_B.Tables[0].Rows[0][0]) + "'");
                                if (_Ds_A.Tables[0].Rows.Count > 0)
                                {
                                    //if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) == "0" & myUtilidad._Mtd_ObtenerAbonoOrdPago(Convert.ToString(_Ds_B.Tables[0].Rows[0][0]), _Str_DocRetISLR, Convert.ToString(_Txt_Prov.Tag)) == 0)
                                    //{
                                    if (_Mtd_AgregarISLRoIVA(_Str_DocRetPatente, Convert.ToString(_Ds_B.Tables[0].Rows[0][0])))
                                    {
                                        _Str_VecRetPatente = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_VecRetPatente, _Str_VecRetPatente.Length + 1);
                                        _Str_VecRetPatente[_Str_VecRetPatente.Length - 1] = Convert.ToString(_Ds_B.Tables[0].Rows[0][0]);
                                    }
                                    //}
                                }
                            }
                            _Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value);
                            _Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value);
                        }
                        else if ((Convert.ToString(_DgRow.Cells[8].Value) == _Str_DocRet) | (Convert.ToString(_DgRow.Cells[8].Value) == _Str_DocRetISLR) | (Convert.ToString(_DgRow.Cells[8].Value) == _Str_DocRetPatente))
                        {
                            if (Convert.ToString(_DgRow.Cells[8].Value) == _Str_DocRet)
                            {
                                if (Array.IndexOf(_Str_VecRetencion, Convert.ToString(_DgRow.Cells[2].Value).Trim()) < 0)
                                {
                                    _Str_VecRetencion = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_VecRetencion, _Str_VecRetencion.Length + 1);
                                    _Str_VecRetencion[_Str_VecRetencion.Length - 1] = Convert.ToString(_DgRow.Cells[2].Value).Trim();
                                    //_Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value);
                                    //_Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value);
                                }
                            }
                            else if (Convert.ToString(_DgRow.Cells[8].Value) == _Str_DocRetISLR)
                            {
                                if (Array.IndexOf(_Str_VecRetISRL, Convert.ToString(_DgRow.Cells[2].Value).Trim()) < 0)
                                {
                                    _Str_VecRetISRL = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_VecRetISRL, _Str_VecRetISRL.Length + 1);
                                    _Str_VecRetISRL[_Str_VecRetISRL.Length - 1] = Convert.ToString(_DgRow.Cells[2].Value).Trim();
                                    //_Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value);
                                    //_Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value);
                                }
                            }
                            else
                            {
                                if (Array.IndexOf(_Str_VecRetPatente, Convert.ToString(_DgRow.Cells[2].Value).Trim()) < 0)
                                {
                                    _Str_VecRetPatente = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_VecRetPatente, _Str_VecRetPatente.Length + 1);
                                    _Str_VecRetPatente[_Str_VecRetPatente.Length - 1] = Convert.ToString(_DgRow.Cells[2].Value).Trim();
                                    //_Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value);
                                    //_Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value);
                                }
                            }
                        }
                    }
                }

                foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
                {//VALIDO LAS NC
                    if (_Str_Global != "")
                    {
                        if (Convert.ToString(_DgRow.Cells[8].Value) == _Str_DocNC)
                        {
                            _Dg_Comprobante.Rows.Add();
                            _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = _Str_CountProveedor;
                            _Str_Sql = "SELECT cnumdocu FROM TNOTACREDICP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotacreditocxp='" + Convert.ToString(_DgRow.Cells[2].Value) + "' AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' AND (ctipodocument='" + _Str_DocFact + "' OR ctipodocument='" + _Str_DocNDP + "')";
                            _Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds_B.Tables[0].Rows.Count > 0)
                            {
                                _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = _Txt_Prov.Text + " S/NC:" + Convert.ToString(_DgRow.Cells[2].Value) + " " + _Txt_Prov.Text + " S/F:" + _Ds_B.Tables[0].Rows[0][0].ToString() + " VEC:" + Convert.ToString(_DgRow.Cells[1].Value);
                            }
                            else
                            {
                                _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = _Txt_Prov.Text + " S/NC:" + Convert.ToString(_DgRow.Cells[2].Value) + " " + _Txt_Prov.Text + " S/F:SINFACTURA RELACIONADA. VEC:" + Convert.ToString(_DgRow.Cells[1].Value);
                            }
                            _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = _DgRow.Cells[5].Value;
                            _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = "";
                            _Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value);
                            _Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value);
                        }
                    }
                }

                foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
                {//VALIDO LAS ND
                    if (_Str_Global != "")
                    {
                        if (Convert.ToString(_DgRow.Cells[8].Value) == _Str_DocND)
                        {
                            _Dg_Comprobante.Rows.Add();
                            _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = _Str_CountProveedor;
                            _Str_Sql = "SELECT cnumdocu FROM TNOTADEBITOCP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp='" + Convert.ToString(_DgRow.Cells[2].Value) + "' AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' AND (ctipodocument='" + _Str_DocFact + "' OR ctipodocument='" + _Str_DocNDP + "')";
                            //_Ds_B.Tables.Clear();
                            _Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds_B.Tables[0].Rows.Count > 0)
                            {
                                _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = _Txt_Prov.Text + " S/ND:" + Convert.ToString(_DgRow.Cells[2].Value) + " " + _Txt_Prov.Text + " S/F:" + _Ds_B.Tables[0].Rows[0][0].ToString() + " VEC:" + Convert.ToString(_DgRow.Cells[1].Value);
                            }
                            else
                            {
                                _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = _Txt_Prov.Text + " S/ND:" + Convert.ToString(_DgRow.Cells[2].Value) + " " + _Txt_Prov.Text + " S/F:SINFACTURA RELACIONADA. FECHA:" + Convert.ToString(_DgRow.Cells[0].Value);
                            }
                            _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = "";
                            _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells[5].Value).Replace("-", "");
                            _Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value);
                            _Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value);
                        }
                    }
                }

                foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
                {//VALIDO LAS NCP
                    if (_Str_Global != "")
                    {
                        if (Convert.ToString(_DgRow.Cells[8].Value) == _Str_DocNCP)
                        {
                            _Dg_Comprobante.Rows.Add();
                            _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = _Str_CountProveedor;
                            _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = _Txt_Prov.Text + " CANCELACION NOTA CRÉDITO S/NC:" + Convert.ToString(_DgRow.Cells[2].Value) + " VEC:" + Convert.ToString(_DgRow.Cells[1].Value);
                            _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = "";
                            _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells[5].Value).Replace("-", "");
                            _Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value);
                            _Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value);
                        }
                    }
                }

                //OBTENGO LA RETENCION DEL IVA
                foreach (string _Str_Val in _Str_VecRetencion)
                {
                    _Str_DescripRetencion = "";
                    _Dbl_MontoRet = 0;
                    if (_Str_Val != "" && _Str_Val != "0")
                    {
                        _Str_Sql = "select ISNULL(cretenido,0) from TCOMPROBANRETC where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobret=" + _Str_Val + " and cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' and canulado=0";
                        _Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds_B.Tables[0].Rows.Count > 0)
                        {
                            _Dbl_MontoRet = Convert.ToDouble(_Ds_B.Tables[0].Rows[0][0]);
                            //BUSCO LA FACTURA RELACIONADA
                            _Str_Sql = "select dbo.FNC_GET_NDNC_FACT('" + Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "','" + _Str_DocRet + "','" + _Str_Val + "','" + Convert.ToString(_Txt_Prov.Tag) + "','0')";
                            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds_A.Tables[0].Rows.Count > 0)
                            { _Str_NFact = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]); }
                            else
                            { _Str_NFact = "????"; }
                            if (_Mtd_NDP_RETN(_Str_Val))
                            { _Str_DescripRetencion = "COMPROBANTE DE RETENCION IVA # " + _Str_Val + " ND " + _Str_NFact + "."; }
                            else if (_Mtd_NCP_RETN(_Str_Val))
                            { _Str_DescripRetencion = "COMPROBANTE DE RETENCION IVA # " + _Str_Val + " NC " + _Str_NFact + "."; }
                            else
                            { _Str_DescripRetencion = "COMPROBANTE DE RETENCION IVA # " + _Str_Val + " FACT " + _Str_NFact + "."; }
                            if (_Dbl_MontoRet != 0)
                            {
                                _Dg_Comprobante.Rows.Add();
                                _Dg_Comprobante[0, _Dg_Comprobante.RowCount - 1].Value = "";
                                _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = _Str_CountProveedor;
                                _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = "RETENCIONES DE IMPUESTO POR ENTERAR. SEGUN " + _Str_DescripRetencion + " DE " + _Txt_Prov.Text.Trim().ToUpper();
                                if (_Mtd_NCP_RETN(_Str_Val))
                                { _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = _Dbl_MontoRet.ToString("#,##0.00"); }
                                else
                                { _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = _Dbl_MontoRet.ToString("#,##0.00"); }
                                _Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = _Str_DocRet;
                                _Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = _Str_Val;
                                //if (_Mtd_NDP_ISLR(_Str_Val))
                                //{ _Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = _Str_DocNDP; }
                                //else
                                //{ _Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = _Str_DocFact; }
                                //_Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = _Str_NFact;
                            }
                        }
                    }
                }

                //OBTENGO LA RETENCION DEL ISRL
                foreach (string _Str_Val in _Str_VecRetISRL)
                {
                    _Str_DescripRetISRL = "";
                    _Dbl_MontoRetISRL = 0;
                    if (_Str_Val != "" && _Str_Val != "0")
                    {
                        _Str_Sql = "select ISNULL(ctotretenido,0) from TCOMPROBANISLRC where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobislr=" + _Str_Val;
                        _Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds_B.Tables[0].Rows.Count > 0)
                        {
                            _Dbl_MontoRetISRL = Convert.ToDouble(_Ds_B.Tables[0].Rows[0][0]);
                            //BUSCO LA FACTURA RELACIONADA
                            _Str_Sql = "select cnumdocu from TFACTPPAGARM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobislr=" + _Str_Val + " and (ctipodocument='" + _Str_DocFact + "' OR ctipodocument='" + _Str_DocNDP + "') AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "'";
                            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds_A.Tables[0].Rows.Count > 0)
                            { _Str_NFact = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]); }
                            else
                            { _Str_NFact = "????"; }
                            if (_Mtd_NDP_ISLR(_Str_Val))
                            { _Str_DescripRetISRL = "COMPROBANTE DE RETENCION ISLR # " + _Str_Val + " ND " + _Str_NFact + "."; }
                            else
                            { _Str_DescripRetISRL = "COMPROBANTE DE RETENCION ISLR # " + _Str_Val + " FACT " + _Str_NFact + "."; }
                            if (_Dbl_MontoRetISRL != 0)
                            {
                                _Dg_Comprobante.Rows.Add();
                                _Dg_Comprobante[0, _Dg_Comprobante.RowCount - 1].Value = "";
                                _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = _Str_CountProveedor;
                                _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = "RETENCIONES DE ISLR POR ENTERAR. SEGUN " + _Str_DescripRetISRL + " DE " + _Txt_Prov.Text.Trim().ToUpper();
                                _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = _Dbl_MontoRetISRL.ToString("#,##0.00");
                                _Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = _Str_DocRetISLR;
                                _Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = _Str_Val;
                                //if (_Mtd_NDP_ISLR(_Str_Val))
                                //{ _Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = _Str_DocNDP; }
                                //else
                                //{ _Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = _Str_DocFact; }
                                //_Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = _Str_NFact;
                            }
                        }
                    }
                }
                
                //OBTENGO LA RETENCION DE PATENTE
                foreach (string _Str_Val in _Str_VecRetPatente)
                {
                    _Str_DescripRetPatente = "";
                    _Dbl_MontoRetPatente = 0;
                    if (_Str_Val != "" && _Str_Val != "0")
                    {
                        _Str_Sql = "select ISNULL(cretenido,0) from TCOMPROBANRETPAT where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobret=" + _Str_Val;
                        _Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds_B.Tables[0].Rows.Count > 0)
                        {
                            _Dbl_MontoRetPatente = Convert.ToDouble(_Ds_B.Tables[0].Rows[0][0]);
                            //BUSCO LA FACTURA RELACIONADA
                            _Str_Sql = "select cnumdocu from TFACTPPAGARM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobretpat=" + _Str_Val + " and (ctipodocument='" + _Str_DocFact + "' OR ctipodocument='" + _Str_DocNDP + "') AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "'";
                            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds_A.Tables[0].Rows.Count > 0)
                            { _Str_NFact = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]); }
                            else
                            { _Str_NFact = "????"; }
                            if (_Mtd_NDP_RETPATENTE(_Str_Val))
                            { _Str_DescripRetPatente = "COMPROBANTE DE RETENCION DE PATENTE # " + _Str_Val + " ND " + _Str_NFact + "."; }
                            else
                            { _Str_DescripRetPatente = "COMPROBANTE DE RETENCION DE PATENTE # " + _Str_Val + " FACT " + _Str_NFact + "."; }
                            if (_Dbl_MontoRetPatente != 0)
                            {
                                _Dg_Comprobante.Rows.Add();
                                _Dg_Comprobante[0, _Dg_Comprobante.RowCount - 1].Value = "";
                                _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = _Str_CountProveedor;
                                _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = "RETENCIONES DE PATENTE POR ENTERAR. SEGUN " + _Str_DescripRetISRL + " DE " + _Txt_Prov.Text.Trim().ToUpper();
                                _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = _Dbl_MontoRetPatente.ToString("#,##0.00");
                                _Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = _Str_DocRetPatente;
                                _Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = _Str_Val;
                                //if (_Mtd_NDP_ISLR(_Str_Val))
                                //{ _Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = _Str_DocNDP; }
                                //else
                                //{ _Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = _Str_DocFact; }
                                //_Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = _Str_NFact;
                            }
                        }
                    }
                }
                foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
                {
                    if (Convert.ToString(_DgRow.Cells[9].Value).Trim() != "" && (Convert.ToString(_DgRow.Cells[8].Value).Trim() == _Str_DocFact | Convert.ToString(_DgRow.Cells[8].Value).Trim() == _Str_DocNDP))
                    {
                        _Dbl_MontoDesc = _Dbl_MontoDesc + Convert.ToDouble(_DgRow.Cells[9].Value);
                    }
                }
            }
            _Mtd_Fila_Anticipo(_Txt_Prov.Text.Trim().ToUpper(), _Str_CountProveedor);
            double _Dbl_Anticipo = _Mtd_Anticipo(_Txt_Transaccion.Text.Trim());
            if (_Dbl_Anticipo > _Dbl_monto_banco & Convert.ToInt32(_Str_ND_Anticipo) > 0)
            { _Mtd_Fila_ND_Anticipo(_Txt_Prov.Text.Trim().ToUpper(), _Str_CountProveedor, _Dbl_Anticipo - _Dbl_monto_banco, _Str_ND_Anticipo); }
            else if (_Dbl_Anticipo > _Dbl_monto_banco & Convert.ToInt32(_Str_ND_Anticipo) == 0)
            { _Mtd_Fila_SobFal_Anticipo(_Txt_Prov.Text.Trim().ToUpper(), _Dbl_Anticipo - _Dbl_monto_banco); }
            else
            {
                if (_Str_CountBanco.Length > 0)
                {
                    _Dg_Comprobante.Rows.Add();
                    _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = _Str_CountBanco;
                    //_Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_Ds.Tables[0].Rows[0]["cname"].ToString().ToUpper()) + ". S/CHEQUE:" + _Txt_Transaccion.Text;
                    _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = _Str_CountBancoDescrip.ToUpper() + ".";
                    _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = "";
                    _Dbl_MontoAux = _Dbl_monto_banco;
                    if (_Dbl_Anticipo > 0)
                    {
                        _Dbl_MontoAux -= _Dbl_Anticipo;
                    }
                    _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = _Dbl_MontoAux.ToString("#,##0.00");
                    if (_Rb_Cheque.Checked)
                    { _Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = "CHEQ"; }
                    else if (_Rb_Transferencia.Checked)
                    { _Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = "TRANSF"; }
                    if (_Bol_DebitoBancario)
                    {
                        if (_Dbl_MontoAux > 0)
                        {
                            //Agrego la cuenta contable de gastos por debito bancario                            
                            _Ds_DebitoBancario=null;
                            _Str_Sql = "select TPROCESOSCONTD.ccount,TPROCESOSCONTD.cnaturaleza from TPROCESOSCONTD where TPROCESOSCONTD.cidproceso='" + _Str_ProcesoContableDebitoBancario + "'";
                            _Ds_DebitoBancario = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            double _Dbl_MontoDebito = 0;
                            string _Str_CuentaContableDebitoBancarioComp = "";
                            string _Str_CuentaContableDebitoBancarioDescr = "";
                            _Dbl_MontoDebito = _Dbl_MontoAux * _Dbl_PorcentajeDebitoBancario / 100;
                            foreach(DataRow _Dtw_Row in _Ds_DebitoBancario.Tables[0].Rows)
                            {
                                _Dg_Comprobante.Rows.Add();
                                if (_Dtw_Row["ccount"].ToString() == CLASES._Cls_Varios_Metodos._Str_G_CuentaContBanco)
                                {
                                    _Str_Sql = "SELECT ccount,cname FROM VST_CUENTBANCCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cnumcuenta='" + Convert.ToString(_Cb_Cuenta.SelectedValue) + "' AND cbanco='" + Convert.ToString(_Cb_Banco.SelectedValue) + "'";
                                    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                    if (_Ds_A.Tables[0].Rows.Count > 0)
                                    {
                                        _Str_CuentaContableDebitoBancarioComp = _Ds_A.Tables[0].Rows[0]["ccount"].ToString().Trim();
                                        _Str_CuentaContableDebitoBancarioDescr = "CARGO IGTF.<REPLACEIGTFBANCO>" + _Ds_A.Tables[0].Rows[0]["cname"].ToString().Trim() + ".";
                                    }
                                }
                                else
                                {
                                    _Str_Sql = "SELECT cname FROM tcount WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Dtw_Row["ccount"].ToString().Trim() + "'";
                                    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                    if (_Ds_A.Tables[0].Rows.Count > 0)
                                    {
                                        _Str_CuentaContableDebitoBancarioComp = _Dtw_Row["ccount"].ToString().Trim();
                                        _Str_CuentaContableDebitoBancarioDescr = "CARGO IGTF.<REPLACEIGTF>";
                                    }
                                }

                                _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = _Str_CuentaContableDebitoBancarioComp;
                                _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = _Str_CuentaContableDebitoBancarioDescr;                                
                                if (_Dtw_Row["cnaturaleza"].ToString() == "D")
                                {
                                    _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = _Dbl_MontoDebito.ToString("#,##0.00");
                                    _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = "";
                                }
                                else
                                {                                    
                                    _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = _Dbl_MontoDebito.ToString("#,##0.00");
                                    _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = "";
                                }
                            }
                            
                        }
                    }
                }
            }

            foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[9].Value).Trim() != "" && (Convert.ToString(_DgRow.Cells[8].Value).Trim() == _Str_DocFact | Convert.ToString(_DgRow.Cells[8].Value).Trim() == _Str_DocNDP))
                {
                    if (Convert.ToDouble(_DgRow.Cells[9].Value) != 0)
                    {
                        if (Convert.ToString(_DgRow.Cells[8].Value).Trim() == _Str_DocFact)
                        { _Str_DescripDesc = " DESCPPPAGO S/F:" + Convert.ToString(_DgRow.Cells[2].Value) + ". VEC:" + Convert.ToString(_DgRow.Cells[1].Value); }
                        else
                        { _Str_DescripDesc = " DESCPPPAGO S/ND:" + Convert.ToString(_DgRow.Cells[2].Value) + ". VEC:" + Convert.ToString(_DgRow.Cells[1].Value); }
                        _Dg_Comprobante.Rows.Add();
                        _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = _Str_CountProveedor;//_Str_DescripDescCount
                        _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = _Txt_Prov.Text + _Str_DescripDesc;
                        _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = "";
                        _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells[9].Value);
                        _Dg_Comprobante["_Col_Tipo_Doc", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value);
                        _Dg_Comprobante["_Col_Documento", _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value);
                    }
                }
            }
        }
        private string _Mtd_ValorCampoNC_ND(string _P_Str_Documento, string _P_Str_Campo, bool _P_Bol_NC)
        {
            string _Str_Cadena = "";
            if (_P_Bol_NC)
            { _Str_Cadena = "SELECT " + _P_Str_Campo + " FROM TNOTACREDICP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotacreditocxp='" + _P_Str_Documento + "'"; }
            else
            { _Str_Cadena = "SELECT " + _P_Str_Campo + " FROM TNOTADEBITOCP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp='" + _P_Str_Documento + "'"; }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                {
                    return _Ds.Tables[0].Rows[0][0].ToString().Trim();
                }
            }
            return "0";
        }
        private bool _Mtd_NDP_ISLR(string _P_Str_DocIslr)
        {
            if (_P_Str_DocIslr.Trim().Length > 0 & _P_Str_DocIslr.Trim() != "0")
            {
                string _Str_Cadena = "SELECT ctipodocument FROM TFACTPPAGARM INNER JOIN TCONFIGCXP ON TFACTPPAGARM.ccompany=TCONFIGCXP.ccompany AND TFACTPPAGARM.ctipodocument=TCONFIGCXP.ctipodocndp WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TFACTPPAGARM.ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobislr='" + _P_Str_DocIslr + "'";
                return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
            }
            return false;
        }
        private bool _Mtd_NDP_RETPATENTE(string _P_Str_DocRetPat)
        {
            if (_P_Str_DocRetPat.Trim().Length > 0 & _P_Str_DocRetPat.Trim() != "0")
            {
                string _Str_Cadena = "SELECT ctipodocument FROM TFACTPPAGARM INNER JOIN TCONFIGCXP ON TFACTPPAGARM.ccompany=TCONFIGCXP.ccompany AND TFACTPPAGARM.ctipodocument=TCONFIGCXP.ctipodocndp WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TFACTPPAGARM.ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobretpat='" + _P_Str_DocRetPat + "'";
                return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
            }
            return false;
        }
        private bool _Mtd_NDP_RETN(string _P_Str_DocRet)
        {
            if (_P_Str_DocRet.Trim().Length > 0 & _P_Str_DocRet.Trim() != "0")
            {
                string _Str_Cadena = "SELECT ctipodocument FROM TFACTPPAGARM INNER JOIN TCONFIGCXP ON TFACTPPAGARM.ccompany=TCONFIGCXP.ccompany AND TFACTPPAGARM.ctipodocument=TCONFIGCXP.ctipodocndp WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TFACTPPAGARM.ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _P_Str_DocRet + "'";
                return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
            }
            return false;
        }
        private bool _Mtd_NCP_RETN(string _P_Str_DocRet)
        {
            if (_P_Str_DocRet.Trim().Length > 0 & _P_Str_DocRet.Trim() != "0")
            {
                string _Str_Cadena = "SELECT ctipodocument FROM TFACTPPAGARM INNER JOIN TCONFIGCXP ON TFACTPPAGARM.ccompany=TCONFIGCXP.ccompany AND TFACTPPAGARM.ctipodocument=TCONFIGCXP.ctipodocncp WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TFACTPPAGARM.ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprobret='" + _P_Str_DocRet + "'";
                return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
            }
            return false;
        }
        private void abajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Dg_Comprobante.Rows.Insert(_Dg_Comprobante.CurrentCell.RowIndex, 1);
            _Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex - 1].Cells[5].ReadOnly = true;
            _Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex - 1].Cells[2].ReadOnly = false;
            _Dg_Comprobante.ClearSelection();
        }

        private void arribaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Dg_Comprobante.Rows.Insert(_Dg_Comprobante.CurrentCell.RowIndex + 1, 1);
            _Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex + 1].Cells[5].ReadOnly = true;
            _Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex + 1].Cells[2].ReadOnly = false;
            _Dg_Comprobante.ClearSelection(); 
        }

        private void _CMen_A_Del_Click(object sender, EventArgs e)
        {
            //_Dg_Comprobante.Rows.RemoveAt(_Dg_Comprobante.CurrentCell.RowIndex);
            _Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Visible = false;
        }

        private void _Dg_Comprobante_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Str_MyProceso != "" && _Dg_Comprobante.ReadOnly == false)
            {
                _Dg_Comprobante.ContextMenuStrip = _CMen_A;
            }
        }

        private bool _Mtd_VerificarSaldo()
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            double _Dbl_DebeA = 0;
            double _Dbl_HaberA = 0;
            //double _Dbl_MonSi = 0;
            //double _Dbl_Imp = 0;
            double _Dbl_Total = 0;
            bool _Bol_R = false;
            if (_Txt_Total.Text.Trim().Length == 0) { _Txt_Total.Text = "0"; }
            _Dbl_Total = Convert.ToDouble(_Txt_Total.Text.Replace(".", ""));
            if (_Dbl_Total <= 0)
            { _Bol_R = true; }
            else
            {
                foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
                {
                    if (Convert.ToString(_Dg_Row.Cells[4].Value) == "" || Convert.ToString(_Dg_Row.Cells[4].Value) == "0")
                    { _Dbl_Debe = 0; }
                    else
                    { _Dbl_Debe = Convert.ToDouble(_Dg_Row.Cells[4].Value); }
                    if (Convert.ToString(_Dg_Row.Cells[5].Value) == "" || Convert.ToString(_Dg_Row.Cells[5].Value) == "0")
                    { _Dbl_Haber = 0; }
                    else
                    { _Dbl_Haber = Convert.ToDouble(_Dg_Row.Cells[5].Value); }
                    _Dbl_DebeA = _Dbl_DebeA + _Dbl_Debe;
                    _Dbl_HaberA = _Dbl_HaberA + _Dbl_Haber;
                }
                if (CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado(_Dbl_HaberA, 2) == CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado(_Dbl_DebeA, 2))
                {
                    _Bol_R = false;
                }
                else
                { _Bol_R = true; }
            }
            return _Bol_R;
        }

        private void _Dg_Comprobante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1)
            {
                _Dg_Comprobante.ContextMenuStrip = null;
            }
            if (_Str_MyProceso != "")
            {
                if (e.ColumnIndex == 2 && _Dg_Comprobante[e.ColumnIndex, e.RowIndex].ReadOnly == false)//El boton de Buscar
                {
                    Frm_ProcesosVista Frm_ProcesosVista1 = new Frm_ProcesosVista();
                    Frm_ProcesosVista1.ShowDialog();
                    if (Frm_ProcesosVista1._Str_R != "")
                    {
                        if (_Mtd_ValidarGridDetaAdd(Frm_ProcesosVista1._Str_R) == false)
                        {
                            _Dg_Comprobante[1, e.RowIndex].Value = Frm_ProcesosVista1._Str_R;
                            _Dg_Comprobante[3, e.RowIndex].Value = Frm_ProcesosVista1._Dg_A[2, Frm_ProcesosVista1._Dg_A.CurrentCell.RowIndex].Value.ToString();
                            _Dg_Comprobante[4, e.RowIndex].Value = "0";
                            _Dg_Comprobante[5, e.RowIndex].Value = "0";
                        }
                    }
                }
            }
        }

        private void _Dg_Comprobante_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _Dg_Comprobante.ContextMenuStrip = null;
        }

        private void _Dg_Comprobante_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void _Dg_Comprobante_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                _Mtd_MensajesErrorComprob(e.RowIndex, e.ColumnIndex);
                //_Mtd_TotalizarComprobante();
                if (_Int_FrmTotComprobSw == 0)
                { _Mtd_FilaTotal(); }
            }
        }

        private bool _Mtd_MensajesErrorComprob(int _P_Int_Row, int _P_Int_Col)
        {
            try
            {
                if (_P_Int_Col == 5 || _P_Int_Col == 4)
                {
                    if (Convert.ToString(_Dg_Comprobante.Rows[_P_Int_Row].Cells[_P_Int_Col].Value) != "")
                    {
                        if (!_Mtd_IsNumeric(_Dg_Comprobante.Rows[_P_Int_Row].Cells[_P_Int_Col].Value))
                        {
                            MessageBox.Show("No debe Introducir valores alfanuméricos");
                            _Dg_Comprobante.Rows[_P_Int_Row].Cells[_P_Int_Col].Value = 0;
                            return true;
                        }
                        else if (_Dg_Comprobante.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().Trim().IndexOf(",") == 0)
                        {
                            MessageBox.Show("No debe Introducir comas (,)");
                            _Dg_Comprobante.Rows[_P_Int_Row].Cells[_P_Int_Col].Value = 0;
                            return true;
                        }
                        else if (_Dg_Comprobante.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().Trim().IndexOf(",") == _Dg_Comprobante.Rows[_P_Int_Row].Cells[_P_Int_Col].Value.ToString().Trim().Length - 1)
                        {
                            _Dg_Comprobante.Rows[_P_Int_Row].Cells[_P_Int_Col].Value = _Dg_Comprobante.Rows[_P_Int_Row].Cells[_P_Int_Col].Value + "0";
                        }
                    }
                }
            }
            catch { return true; }
            return false;
        }

        private bool _Mtd_ValidarGridDetaAdd(string _Pr_Str_Val)
        {
            int i = 0;
            bool _Bol_R;
            _Bol_R = false;
            for (i = 0; i < (_Dg_Comprobante.Rows.Count - 1); i++)
            {
                if (Convert.ToString(_Dg_Comprobante[0, i].Value) == _Pr_Str_Val)
                {
                    MessageBox.Show("La Cuenta ya fue Ingresada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _Bol_R = true;
                    break;
                }
            }
            return _Bol_R;
        }

        private bool _Mtd_MostrarComprob(string _Pr_Str_Proceso)
        {
            bool _Bol = false;
            switch (_Pr_Str_Proceso)
            {
                case "1"://COMPROBANTE DE TRANSACCION BANCARIA

                    if (_Str_FrmTpoPago=="")
                    { _Bol = true; }
                    if (_Str_FrmFPago=="")
                    { _Bol = true; }

                    if (_Rb_Cheque.Checked || _Rb_Transferencia.Checked)
                    {
                        if (_Cb_Banco.SelectedIndex <= 0)
                        { _Bol = true; }
                        if (_Cb_Cuenta.SelectedIndex <= 0)
                        { _Bol = true; }
                        if (_Txt_Prov.Text == "")
                        { _Bol = true; }

                        int[] _Int_VecCol = new int[1];
                        _Int_VecCol[0] = 5;
                        if (_Mtd_ValidarGridCont(_Dg_OrdPagoDet, _Int_VecCol))
                        {
                            MessageBox.Show("Faltan datos por Ingresar en el Grid de Documentos a Cancelar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            _Bol = true;
                        }

                    }
        
                    break;
                default:

                    _Bol = true;
                    break;
            }

            return _Bol;
        }

        /// <summary>
        /// Retorna un valor que indica si la orden de pago es de intercompañía.
        /// </summary>
        /// <param name="_P_Int_OrdenPago">Id de la orden de pago.</param>
        /// <returns>Verdadero o falso.</returns>
        private bool _Mtd_OrdenIntercompañia(int _P_Int_OrdenPago)
        {
            string _Str_Cadena = "select TPAGOSCXPM.cproveedor from TPAGOSCXPM INNER JOIN TICRELAPROCLI on TPAGOSCXPM.cproveedor=TICRELAPROCLI.cproveedor where TPAGOSCXPM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidordpago='" + _P_Int_OrdenPago + "' AND isnull(TICRELAPROCLI.cdelete,0)=0";
            return Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Cadena);
        }
        private bool _Mtd_OrdenReposicion(int _P_Int_OrdenPago)
        {
            return (from Campos in Program._Dat_Tablas.TREPOSICIONESM
                    where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidordpago == _P_Int_OrdenPago
                    select Campos).Count() > 0;
        }
        private string _Mtd_FormaPagoReposicion(int _P_Int_OrdenPago)
        {
            return (from Campos in Program._Dat_Tablas.TPAGOSCXPM
                    where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidordpago == _P_Int_OrdenPago
                    select Campos.cfpago).Single();
        }
        private void _Dg_Find_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Find.CurrentCell != null)
            {
                if (_Dg_Find.Rows[e.RowIndex].Cells["cotrospago"].Value != null)
                { _Bol_Otros = Convert.ToBoolean(_Dg_Find.Rows[e.RowIndex].Cells["cotrospago"].Value); }

                if (_Bol_Otros)
                {

                    _Mtd_CargarFormularioOtros(_Dg_Find.Rows[e.RowIndex].Cells[1].Value.ToString());
                    if (_Cls_Variosmetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_CHEQUE_SOL"))
                    { _Bt_Pagar_Otros.Visible = true; _Bt_Pagar_Otros.Enabled = true; }
                    _Tb_Tab.SelectedIndex = 2;
                }
                else
                {
                    Cursor = Cursors.WaitCursor;
                    _Str_MyProceso = "";
                    _Mtd_Ini();
                    _Mtd_CargarData(Convert.ToString(_Dg_Find[1, _Dg_Find.CurrentCell.RowIndex].Value));
                    _Mtd_BotonesMenu();
                    Cursor = Cursors.Default;
                    _Tb_Tab.SelectedIndex = 1;
                }
                _Mtd_Evento_Activated();
                if (_Bol_Otros)
                {
                    //-----------------------------------
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = !_Mtd_OrdenReposicion(Convert.ToInt32(_Txt_OrdenPago.Text));
                    //((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                    //-----------------------------------
                }
            }
        }

        private void _Rb_Abono_CheckedChanged(object sender, EventArgs e)
        {
            string _Str_Fact = "";
            string _Str_NDP = "";
            string _Str_NC = "";
            string _Str_ND = "";
            string _Str_Ret = "";
            double _Dbl_MontoDoc = 0;
            double _Dbl_MontoOriginal = 0;
            int _Int_NPagos = 0;
            if (_Str_MyProceso != "")
            {
                if (_Rb_Abono.Checked)
                {
                    DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipodocnd,ctipodocnc,ctipdocfact,ctipdocretiva,ctipodocndp from TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    {
                        _Str_Fact = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocfact"]);
                        _Str_NDP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocndp"]);
                        _Str_NC = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnc"]);
                        _Str_ND = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnd"]);
                        _Str_Ret = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocretiva"]);
                    }

                    _Str_FrmTpoPago = "ABO";
                    _Grb_FPago.Enabled = true;
                    _Dg_Comprobante.Rows.Clear();
                    _Bol_FGridPago = false;
                    _Dg_OrdPagoDet.ReadOnly = false;
                    foreach (DataGridViewColumn _DgCol in _Dg_OrdPagoDet.Columns)
                    {
                        _DgCol.ReadOnly = true;
                    }
                    foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
                    {
                        if (Convert.ToString(_DgRow.Cells[8].Value).Trim() != _Str_Fact.Trim() & Convert.ToString(_DgRow.Cells[8].Value).Trim() != _Str_NDP.Trim())
                        { _DgRow.Cells[5].Value = _DgRow.Cells[4].Value; }
                        else
                        {
                            _Dbl_MontoDoc = myUtilidad._Mtd_ObtenerRestanteOrdPago(Convert.ToString(_DgRow.Cells[2].Value), Convert.ToString(_DgRow.Cells[8].Value), Convert.ToString(_Txt_Prov.Tag)) + _Mtd_MontoEditando(_Txt_Transaccion.Text.Trim(), Convert.ToString(_DgRow.Cells[2].Value), Convert.ToString(_DgRow.Cells[8].Value));
                            if (Convert.ToDouble(_DgRow.Cells[4].Value.ToString().Replace(".", "")) < 0)
                            {
                                if (_Dbl_MontoDoc.ToString().Substring(0, 1) != "-")
                                {
                                    _DgRow.Cells[5].Value = "-" + _Dbl_MontoDoc.ToString("#,##0.00");
                                }
                                else
                                {
                                    _DgRow.Cells[5].Value = _Dbl_MontoDoc.ToString("#,##0.00");
                                }
                            }
                            else
                            {
                                _DgRow.Cells[5].Value = _Dbl_MontoDoc.ToString("#,##0.00");
                            }
                            _DgRow.Cells[5].ReadOnly = false;
                        }
                    }
                    _Bol_FGridPago = false;
                    _Mtd_DesbloqDgOPAdd();
                    if (_Str_MyProceso == "M")
                    { _Bt_Comprobante.Enabled = true; }
                }
            }
            
        }

        private void _Rb_PagoTot_CheckedChanged(object sender, EventArgs e)
        {
            double _Dbl_Acum = 0;
            double _Dbl_Total = 0;
            double _Dbl_MontoDoc = 0;
            string _Str_Fact = "";
            string _Str_NDP = "";
            string _Str_TpoPago = "";
            DataSet _Ds_A;
            if (_Str_MyProceso != "")
            {
                if (_Rb_PagoTot.Checked)
                {
                    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipdocfact,ctipodocndp from TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    {
                        _Str_Fact = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocfact"]);
                        _Str_NDP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocndp"]);
                    }
                    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctippago FROM TPAGOSCXPM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidordpago='" + _Txt_Transaccion.Text + "'");
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    {
                        _Str_TpoPago = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]);
                    }
                    _Str_FrmTpoPago = "PTOT";
                    _Dg_Comprobante.Rows.Clear();
                    _Grb_FPago.Enabled = true;
                    _Bol_FGridPago = true;
                    _Dg_OrdPagoDet.Columns[5].ReadOnly = true;
                    foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
                    {
                        if (Convert.ToString(_DgRow.Cells[8].Value).Trim() != _Str_Fact.Trim() & Convert.ToString(_DgRow.Cells[8].Value).Trim() != _Str_NDP.Trim())
                        { _DgRow.Cells[5].Value = _DgRow.Cells[4].Value; }
                        else
                        {
                            _Dbl_MontoDoc = myUtilidad._Mtd_ObtenerRestanteOrdPago(Convert.ToString(_DgRow.Cells[2].Value), Convert.ToString(_DgRow.Cells[8].Value), Convert.ToString(_Txt_Prov.Tag)) + _Mtd_MontoEditando(_Txt_Transaccion.Text.Trim(), Convert.ToString(_DgRow.Cells[2].Value), Convert.ToString(_DgRow.Cells[8].Value));
                            if (Convert.ToDouble(_DgRow.Cells[4].Value.ToString().Replace(".", "")) < 0)
                            {
                                if (_Dbl_MontoDoc.ToString().Substring(0, 1) != "-")
                                {
                                    _DgRow.Cells[5].Value = "-" + _Dbl_MontoDoc.ToString("#,##0.00");
                                }
                                else
                                {
                                    _DgRow.Cells[5].Value = _Dbl_MontoDoc.ToString("#,##0.00");
                                }
                            }
                            else
                            {
                                _DgRow.Cells[5].Value = _Dbl_MontoDoc.ToString("#,##0.00");
                            }
                        }
                        _Dbl_Acum = _Dbl_Acum + Convert.ToDouble(_DgRow.Cells[5].Value);
                    }
                    _Dbl_Total = _Dbl_Acum;
                    _Txt_Total.Text = _Dbl_Total.ToString("#,##0.00");
                    _Bol_FGridPago = false;
                    _Dg_OrdPagoDet.ReadOnly = false;
                    foreach (DataGridViewColumn _DgCol in _Dg_OrdPagoDet.Columns)
                    {
                        _DgCol.ReadOnly = true;
                    }
                    _Mtd_DesbloqDgOPAdd();
                    if (_Str_MyProceso == "M")
                    { _Bt_Comprobante.Enabled = true; }
                }
            }
        }

        private void _Rb_Efectivo_CheckedChanged(object sender, EventArgs e)
        {
            
                if (_Rb_Efectivo.Checked)
                {
                    if (_Str_MyProceso != "")
                    {
                        _Dg_Comprobante.Rows.Clear();
                        _Grb_Banco.Enabled = true;
                        _Lb_CajaBanco.Text = "Caja";
                        _Cb_Banco.Visible = false;
                        _Cb_Caja.Visible = true;
                        _Lb_Cuenta.Visible = false;
                        _Cb_Cuenta.Visible = false;
                        //_Bt_DispBanco.Visible = false;
                        _Mtd_CargarCajas();
                        _Bt_Comprobante.Enabled = false;
                    }
                    _Mtd_DesbloqDgOPAdd();
                    _Str_FrmFPago = "EFECT";
                }
            
        }

        private void _Rb_Cheque_CheckedChanged(object sender, EventArgs e)
        {
            
            if (_Rb_Cheque.Checked)
            {
                if (_Str_MyProceso != "")
                {
                    _Dg_Comprobante.Rows.Clear();
                    _Grb_Banco.Enabled = true;
                    _Lb_CajaBanco.Text = "Banco";
                    _Cb_Banco.Visible = true;
                    _Cb_Caja.Visible = false;
                    _Lb_Cuenta.Visible = true;
                    _Cb_Cuenta.Visible = true;
                    _Mtd_CargarBancos();
                    _Cb_Cuenta.DataSource = null;
                    _Bt_Comprobante.Enabled = false;
                }
                _Str_FrmFPago = "CHEQ";
                _Mtd_DesbloqDgOPAdd();
            }
            
        }

        private void _Rb_Transferencia_CheckedChanged(object sender, EventArgs e)
        {
            
                if (_Rb_Transferencia.Checked)
                {
                    if (_Str_MyProceso != "")
                    {_Dg_Comprobante.Rows.Clear();
                    _Grb_Banco.Enabled = true;
                    _Lb_CajaBanco.Text = "Banco";
                    _Cb_Banco.Visible = true;
                    _Cb_Caja.Visible = false;
                    _Lb_Cuenta.Visible = true;
                    _Cb_Cuenta.Visible = true;
                    //_Bt_DispBanco.Visible = true;
                    _Mtd_CargarBancos();
                    }
                    _Str_FrmFPago = "TRANSF";
                    _Mtd_DesbloqDgOPAdd();
                }
            
        }

        private void _Rb_TCredito_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_TCredito.Checked)
            {
                if (_Str_MyProceso != "")
                {
                    _Dg_Comprobante.Rows.Clear();
                    _Grb_Banco.Enabled = true;
                    _Lb_CajaBanco.Text = "Banco";
                    _Cb_Banco.Visible = true;
                    _Cb_Caja.Visible = false;
                    _Lb_Cuenta.Visible = true;
                    _Cb_Cuenta.Visible = true;
                    //_Bt_DispBanco.Visible = true;
                    _Mtd_CargarBancos();
                }
                _Str_FrmFPago = "TARJC";
                _Mtd_DesbloqDgOPAdd();
            }
        }
        private void _Mtd_AnexarRetenciones(string _Pr_Str_Idfactxp)
        {
            string _Str_Fact = "";
            string _Str_NDP = "";
            string _Str_NCP = "";
            string _Str_Ret = "";
            string _Str_RETname = "";
            string _Str_NumRetencion = "";
            string _Str_TipoDocument = "";
            string _Str_Documento = "";
            DataSet _Ds;
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from VST_CONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_Fact = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocfact"]);
                _Str_NDP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocndp"]);
                _Str_NCP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocncp"]);
                _Str_Ret = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocretiva"]);
                _Str_RETname = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocretivaname"]);
            }
            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cidcomprobret,ctipodocument,cnumdocu FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp=" + _Pr_Str_Idfactxp);
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_NumRetencion = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cidcomprobret"]);
                _Str_TipoDocument = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocument"]);
                _Str_Documento = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cnumdocu"]);
            }


            //foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
            //{
                //if (Convert.ToString(_DgRow.Cells[8].Value) == _Str_Fact | Convert.ToString(_DgRow.Cells[8].Value) == _Str_NDP | Convert.ToString(_DgRow.Cells[8].Value) == _Str_NCP)
                //{
                    if (!_Mtd_VerificarDocGrid(_Str_Ret, _Str_NumRetencion))
                    {
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cordenpaghecha from TFACTPPAGARM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and ctipodocument='" + _Str_Ret + "' and cnumdocu='" + _Str_NumRetencion + "' and cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' and canulado = '0'");
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "1" & myUtilidad._Mtd_ObtenerAbonoOrdPago(_Str_NumRetencion, _Str_Ret, Convert.ToString(_Txt_Prov.Tag)) == 0)
                            {
                                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT * from VST_COMPROBANRETC where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobret=" + _Str_NumRetencion + " and cnumdocumafec='" + _Str_Documento + "' AND cimpreso=1 and cretenido<>0");
                                if (_Ds_A.Tables[0].Rows.Count > 0)
                                {
                                    _Dg_OrdPagoDet.Rows.Add();
                                    _Dg_OrdPagoDet[0, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToDateTime(_Ds_A.Tables[0].Rows[0]["cfechaemiret"]).ToShortDateString();
                                    _Dg_OrdPagoDet[1, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToDateTime(_Ds_A.Tables[0].Rows[0]["cfechaemiret"]).ToShortDateString();
                                    _Dg_OrdPagoDet[2, _Dg_OrdPagoDet.RowCount - 1].Value = _Str_NumRetencion;
                                    _Dg_OrdPagoDet[3, _Dg_OrdPagoDet.RowCount - 1].Value = _Str_RETname;
                                    if (_Str_TipoDocument == _Str_NCP)
                                    { _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToDouble(_Ds_A.Tables[0].Rows[0]["cretenido"]).ToString("#,##0.00"); }
                                    else
                                    { _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = "-" + Convert.ToDouble(_Ds_A.Tables[0].Rows[0]["cretenido"]).ToString("#,##0.00"); }
                                    //_Dg_OrdPagoDet[5, _Dg_OrdPagoDet.RowCount - 1].Value = "-" + Convert.ToDouble(_DRow["ctotaldocu"]).ToString("#,##0.00");
                                    _Dg_OrdPagoDet[6, _Dg_OrdPagoDet.RowCount - 1].Value = _Pr_Str_Idfactxp;
                                    _Dg_OrdPagoDet[7, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToDouble(_Ds_A.Tables[0].Rows[0]["cimpuesto"]).ToString("#,##0.00");
                                    _Dg_OrdPagoDet[8, _Dg_OrdPagoDet.RowCount - 1].Value = _Str_Ret;
                                    _Dg_OrdPagoDet[11, _Dg_OrdPagoDet.RowCount - 1].Value = "1";
                                }
                            }
                        }
                        
                    }
                //}
            //}
        }

        private void _Mtd_AnexarRetencionISLR(string _Pr_Str_Idfactxp)
        {
            string _Str_Fact = "";
            string _Str_NDP = "";
            string _Str_Ret = "";
            string _Str_RETname = "";
            string _Str_Sql = "";
            string _Str_NumRetencion = "";
            DataSet _Ds;
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from VST_CONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_Fact = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocfact"]);
                _Str_NDP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocndp"]);
                _Str_Ret = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocretislr"]);
                _Str_RETname = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocretislrname"]);
            }
            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cidcomprobislr FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _Pr_Str_Idfactxp + "'");//And not exists
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_NumRetencion = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]);
            }


            foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[8].Value) == _Str_Fact | Convert.ToString(_DgRow.Cells[8].Value) == _Str_NDP)
                {
                    if (!_Mtd_VerificarDocGrid(_Str_Ret, _Str_NumRetencion))
                    {
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cordenpaghecha from TFACTPPAGARM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and ctipodocument='" + _Str_Ret + "' and cnumdocu='" + _Str_NumRetencion + "' and cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "'");
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "1" & myUtilidad._Mtd_ObtenerAbonoOrdPago(_Str_NumRetencion, _Str_Ret, Convert.ToString(_Txt_Prov.Tag)) == 0)
                            {
                                _Str_Sql = "SELECT * from VST_COMPROBANISLRC where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobislr=" + _Str_NumRetencion + " and cnumdocumafec='" + _DgRow.Cells[2].Value + "' AND cimpreso=1 and ctotretenido<>0";
                                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds_A.Tables[0].Rows.Count > 0)
                                {
                                    _Dg_OrdPagoDet.Rows.Add();
                                    _Dg_OrdPagoDet[0, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToDateTime(_Ds_A.Tables[0].Rows[0]["cfechaemiislr"]).ToShortDateString();
                                    _Dg_OrdPagoDet[1, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToDateTime(_Ds_A.Tables[0].Rows[0]["cfechaemiislr"]).ToShortDateString();
                                    _Dg_OrdPagoDet[2, _Dg_OrdPagoDet.RowCount - 1].Value = _Str_NumRetencion;
                                    _Dg_OrdPagoDet[3, _Dg_OrdPagoDet.RowCount - 1].Value = _Str_RETname;
                                    _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = "-" + Convert.ToDouble(_Ds_A.Tables[0].Rows[0]["ctotretenido"]).ToString("#,##0.00");
                                    //_Dg_OrdPagoDet[5, _Dg_OrdPagoDet.RowCount - 1].Value = "-" + Convert.ToDouble(_DRow["ctotaldocu"]).ToString("#,##0.00");
                                    _Dg_OrdPagoDet[6, _Dg_OrdPagoDet.RowCount - 1].Value = _Pr_Str_Idfactxp;
                                    _Dg_OrdPagoDet[7, _Dg_OrdPagoDet.RowCount - 1].Value = "0";
                                    _Dg_OrdPagoDet[8, _Dg_OrdPagoDet.RowCount - 1].Value = _Str_Ret;
                                    _Dg_OrdPagoDet[11, _Dg_OrdPagoDet.RowCount - 1].Value = "1";
                                }
                            }
                        }
                    }
                }
            }
        }
        private void _Mtd_AnexarRetencionPatente(string _Pr_Str_Idfactxp)
        {
            string _Str_Fact = "";
            string _Str_NDP = "";
            string _Str_Ret = "";
            string _Str_RETname = "";
            string _Str_Sql = "";
            string _Str_NumRetencion = "";
            DataSet _Ds;
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from VST_CONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_Fact = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocfact"]);
                _Str_NDP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocndp"]);
                _Str_Ret = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocretpat"]);
                _Str_RETname = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocretpatname"]);
            }
            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cidcomprobretpat FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp='" + _Pr_Str_Idfactxp + "'");//And not exists
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_NumRetencion = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]);
            }


            foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[8].Value) == _Str_Fact | Convert.ToString(_DgRow.Cells[8].Value) == _Str_NDP)
                {
                    if (!_Mtd_VerificarDocGrid(_Str_Ret, _Str_NumRetencion))
                    {
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cordenpaghecha from TFACTPPAGARM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and ctipodocument='" + _Str_Ret + "' and cnumdocu='" + _Str_NumRetencion + "' and cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "'");
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "1" & myUtilidad._Mtd_ObtenerAbonoOrdPago(_Str_NumRetencion, _Str_Ret, Convert.ToString(_Txt_Prov.Tag)) == 0)
                            {
                                _Str_Sql = "SELECT * from VST_COMPROBANRETPATENTE where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobret=" + _Str_NumRetencion + " and cnumdocumafec='" + _DgRow.Cells[2].Value + "' AND cimpreso=1 and cretenido<>0";
                                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds_A.Tables[0].Rows.Count > 0)
                                {
                                    _Dg_OrdPagoDet.Rows.Add();
                                    _Dg_OrdPagoDet[0, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToDateTime(_Ds_A.Tables[0].Rows[0]["cfechaemiret"]).ToShortDateString();
                                    _Dg_OrdPagoDet[1, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToDateTime(_Ds_A.Tables[0].Rows[0]["cfechaemiret"]).ToShortDateString();
                                    _Dg_OrdPagoDet[2, _Dg_OrdPagoDet.RowCount - 1].Value = _Str_NumRetencion;
                                    _Dg_OrdPagoDet[3, _Dg_OrdPagoDet.RowCount - 1].Value = _Str_RETname;
                                    _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = "-" + Convert.ToDouble(_Ds_A.Tables[0].Rows[0]["cretenido"]).ToString("#,##0.00");
                                    //_Dg_OrdPagoDet[5, _Dg_OrdPagoDet.RowCount - 1].Value = "-" + Convert.ToDouble(_DRow["ctotaldocu"]).ToString("#,##0.00");
                                    _Dg_OrdPagoDet[6, _Dg_OrdPagoDet.RowCount - 1].Value = _Pr_Str_Idfactxp;
                                    _Dg_OrdPagoDet[7, _Dg_OrdPagoDet.RowCount - 1].Value = "0";
                                    _Dg_OrdPagoDet[8, _Dg_OrdPagoDet.RowCount - 1].Value = _Str_Ret;
                                    _Dg_OrdPagoDet[11, _Dg_OrdPagoDet.RowCount - 1].Value = "1";
                                }
                            }
                        }
                    }
                }
            }
        }
        
        private void _Mtd_AnexarNDyNC(string _Pr_Str_Idfactxp)
        {
            string _Str_Fact = "";
            string _Str_ND = "";
            string _Str_NC = "";
            string _Str_NDP = "";
            string _Str_Ret = "";
            string _Str_NDname = "";
            string _Str_NCname = "";
            string _Str_Sql = "";
            string _Str_NumRetencion = "";
            DataSet _Ds;
            DataSet _Ds_B;
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from VST_CONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_Fact = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocfact"]);
                _Str_NDP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocndp"]);
                _Str_ND = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnd"]);
                _Str_NDname = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocndname"]);
                _Str_NC = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnc"]);
                _Str_NCname = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocncname"]);
                _Str_Ret = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocretiva"]);
            }

            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cidcomprobret FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidfactxp=" + _Pr_Str_Idfactxp);
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_NumRetencion = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]);
            }

            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from TCOMPROBANRETD where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprobret='" + _Str_NumRetencion + "'");
            foreach (DataRow _DRow in _Ds_A.Tables[0].Rows)
            {
                if (_Str_NC.Trim() == Convert.ToString(_DRow["ctdocument"]).Trim())
                {
                    _Str_Sql = "select * from TNOTACREDICP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' and cidnotacreditocxp='" + Convert.ToString(_DRow["cnumdocu"]) + "' and canulado=0 and cidcomprob<>0 and cactivo=1 and cimpresa=1";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        //Verifico que la Nota de Credito no halla sido utilizada
                        _Str_Sql = "select cordenpaghecha from TFACTPPAGARM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' and ctipodocument='" + _Str_NC + "' and cnumdocu='" + _Ds.Tables[0].Rows[0]["cidnotacreditocxp"].ToString() + "'";
                        _Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds_B.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToString(_Ds_B.Tables[0].Rows[0][0]) != "1")
                            {
                                if (!_Mtd_VerificarDocGrid(_Str_NC, _Ds.Tables[0].Rows[0]["cidnotacreditocxp"].ToString()))
                                {
                                    _Dg_OrdPagoDet.Rows.Add();
                                    _Dg_OrdPagoDet[0, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechanc"]).ToShortDateString();
                                    _Dg_OrdPagoDet[1, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfvfnotacredp"]).ToShortDateString();
                                    _Dg_OrdPagoDet[2, _Dg_OrdPagoDet.RowCount - 1].Value = _Ds.Tables[0].Rows[0]["cidnotacreditocxp"].ToString();
                                    _Dg_OrdPagoDet[3, _Dg_OrdPagoDet.RowCount - 1].Value = _Str_NCname;
                                    _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]).ToString("#,##0.00");
                                    //_Dg_OrdPagoDet[5, _Dg_OrdPagoDet.RowCount - 1].Value = "-" + Convert.ToDouble(_DRow["ctotaldocu"]).ToString("#,##0.00");
                                    _Dg_OrdPagoDet[6, _Dg_OrdPagoDet.RowCount - 1].Value = _Pr_Str_Idfactxp;
                                    _Dg_OrdPagoDet[7, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]).ToString("#,##0.00");
                                    _Dg_OrdPagoDet[8, _Dg_OrdPagoDet.RowCount - 1].Value = _Str_NC;
                                    _Dg_OrdPagoDet[11, _Dg_OrdPagoDet.RowCount - 1].Value = "1";
                                }
                            }
                        }
                    }
                }

                if (_Str_ND.Trim() == Convert.ToString(_DRow["ctdocument"]).Trim())
                {
                    _Str_Sql = "select * from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' and cidnotadebitocxp='" + Convert.ToString(_DRow["cnumdocu"]) + "' and canulado=0 and cidcomprob<>0 and cactivo=1 and cimpresa=1";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        //Verifico que la Nota de Debito no halla sido utilizada
                        _Str_Sql = "select cordenpaghecha from TFACTPPAGARM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' and ctipodocument='" + _Str_ND + "' and cnumdocu='" + _Ds.Tables[0].Rows[0]["cidnotadebitocxp"].ToString() + "'";
                        _Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds_B.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToString(_Ds_B.Tables[0].Rows[0][0]) != "1")
                            {
                                if (!_Mtd_VerificarDocGrid(_Str_ND, _Ds.Tables[0].Rows[0]["cidnotadebitocxp"].ToString()))
                                {
                                    _Dg_OrdPagoDet.Rows.Add();
                                    _Dg_OrdPagoDet[0, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechand"]).ToShortDateString();
                                    _Dg_OrdPagoDet[1, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfvfnotadebitop"]).ToShortDateString();
                                    _Dg_OrdPagoDet[2, _Dg_OrdPagoDet.RowCount - 1].Value = _Ds.Tables[0].Rows[0]["cidnotadebitocxp"].ToString();
                                    _Dg_OrdPagoDet[3, _Dg_OrdPagoDet.RowCount - 1].Value = _Str_NDname;
                                    _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = "-" + Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]).ToString("#,##0.00");
                                    //_Dg_OrdPagoDet[5, _Dg_OrdPagoDet.RowCount - 1].Value = "-" + Convert.ToDouble(_DRow["ctotaldocu"]).ToString("#,##0.00");
                                    _Dg_OrdPagoDet[6, _Dg_OrdPagoDet.RowCount - 1].Value = _Pr_Str_Idfactxp;
                                    _Dg_OrdPagoDet[7, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]).ToString("#,##0.00");
                                    _Dg_OrdPagoDet[8, _Dg_OrdPagoDet.RowCount - 1].Value = _Str_ND;
                                    _Dg_OrdPagoDet[11, _Dg_OrdPagoDet.RowCount - 1].Value = "1";
                                }
                            }
                        }
                    }
                }

            }
        }

        private bool _Mtd_VerificarDocGrid(string _Pr_Str_TpoDoc, string _Pr_Str_NumDoc)
        {
            foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[2].Value) == _Pr_Str_NumDoc && Convert.ToString(_DgRow.Cells[8].Value) == _Pr_Str_TpoDoc)
                {
                    return true;
                }
            }
            return false;
        }

        private void _Txt_Total_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Txt_Total, "");
            if (_Txt_Total.Text != "" && _Str_MyProceso != "")
            {
                //_Bt_AddDoc.Enabled = true;
                if (_Rb_Efectivo.Checked || _Rb_Cheque.Checked || _Rb_Transferencia.Checked || _Rb_TCredito.Checked)
                {
                    if (!_Rb_Efectivo.Checked)
                    {
                        if ((_Cb_Banco.SelectedIndex > 0) && (_Cb_Cuenta.SelectedIndex > 0))
                        { _Bt_Comprobante.Enabled = true; }
                    }
                    else
                    {
                        if (_Cb_Caja.SelectedIndex > -1 && Convert.ToString(_Cb_Caja.SelectedValue) != "nulo")
                        { _Bt_Comprobante.Enabled = true; }
                    }
                    
                }
            }
            else
            { _Bt_Comprobante.Enabled = false; _Bt_AddDoc.Enabled = false; }
        }

        private void _Mtd_FilaTotal()
        {
            _Int_FrmTotComprobSw = 1;
            if (_Dg_Comprobante.RowCount > 0)
            {
                if (Convert.ToString(_Dg_Comprobante[0, _Dg_Comprobante.RowCount - 1].Value) != "T")
                {
                    _Dg_Comprobante.Rows.Add();
                }
                try
                {
                    _Dg_Comprobante[0, _Dg_Comprobante.RowCount - 1].Value = "T";
                    _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = "";
                    _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = "TOTAL";
                    _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = _Mtd_TotalDebe().ToString("#,##0.00");
                    _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = _Mtd_TotalHaber().ToString("#,##0.00");
                    _Int_FrmTotComprobSw = 0;
                }
                catch
                { _Int_FrmTotComprobSw = 0; }
            }
            _Int_FrmTotComprobSw = 0; 
        }
        private bool _Mtd_CerrarOrden(string _P_Str_OrdenPago)
        {
            double _Dbl_MontoOrdenPago = 0;
            string _Str_Cadena = "SELECT ISNULL(SUM(cmontototal),0) FROM TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _P_Str_OrdenPago + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Dbl_MontoOrdenPago = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString().Trim());
            }
            return _Mtd_Anticipo(_P_Str_OrdenPago) == _Mtd_CalcularTotalPago();
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
        private void _Mtd_Fila_Anticipo(string _P_Str_Proveedor, string _P_Str_CountProveedor)
        {
            double _Dbl_Anticipo = _Mtd_Anticipo(_Txt_Transaccion.Text.Trim());
            if (_Dg_Comprobante.RowCount > 0 & _Dbl_Anticipo > 0)
            {
                _Dg_Comprobante.Rows.Add();
                _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = _P_Str_CountProveedor;
                _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = _P_Str_Proveedor + ". ANTICIPOS O.P # " + _Txt_Transaccion.Text.Trim();
                _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = "";
                _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = _Dbl_Anticipo.ToString("#,##0.00");
            }
        }
        public string _Str_ND_Anticipo = "0";
        private void _Mtd_Fila_ND_Anticipo(string _P_Str_Proveedor, string _P_Str_CountProveedor,double _P_Dbl_MontoND,string _P_Str_ND)
        {
            if (_Dg_Comprobante.RowCount > 0)
            {
                _Dg_Comprobante.Rows.Add();
                _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = _P_Str_CountProveedor;
                _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = _P_Str_Proveedor + ". S/ND # " + _P_Str_ND + ". ANTICIPOS O.P # " + _Txt_Transaccion.Text.Trim();
                _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = _P_Dbl_MontoND.ToString("#,##0.00");
                _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = "";
            }
        }

        private void _Mtd_Fila_SobFal_Anticipo(string _P_Str_Proveedor, double _P_Dbl_MontoSobrante)
        {
            if (_Dg_Comprobante.RowCount > 0)
            {
                string _Str_Count = "";
                string _Str_DescripCount = "";
                string _Str_Cadena = "SELECT ccountsobfalcaj FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                { _Str_Count = _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
                if (_Str_Count.Trim().Length > 0)
                {
                    _Str_Cadena = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_Count + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    { _Str_DescripCount = _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
                    _Dg_Comprobante.Rows.Add();
                    _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = _Str_Count.Trim();
                    _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = _P_Str_Proveedor + ". " + _Str_DescripCount + ". ANTICIPOS O.P # " + _Txt_Transaccion.Text.Trim();
                    _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = _P_Dbl_MontoSobrante.ToString("#,##0.00");
                    _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = "";
                }
            }
        }
        private double _Mtd_TotalDebe()
        {
            double _Dbl_TotDebe = 0;
            double _Dbl_Val = 0;
            foreach (DataGridViewRow _DgRow in _Dg_Comprobante.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[0].Value) != "T")
                {
                    if (Convert.ToString(_DgRow.Cells[4].Value) != "")
                    { _Dbl_Val = Convert.ToDouble(_DgRow.Cells[4].Value); }
                    else
                    { _Dbl_Val = 0; }
                    _Dbl_TotDebe = _Dbl_TotDebe + _Dbl_Val;
                }
            }
            return _Dbl_TotDebe;
        }
        private double _Mtd_TotalHaber()
        {
            double _Dbl_Tot = 0;
            double _Dbl_Val = 0;
            foreach (DataGridViewRow _DgRow in _Dg_Comprobante.Rows)
            {
                if (Convert.ToString(_DgRow.Cells[0].Value) != "T")
                {
                    if (Convert.ToString(_DgRow.Cells[5].Value) != "")
                    { _Dbl_Val = Convert.ToDouble(_DgRow.Cells[5].Value); }
                    else
                    { _Dbl_Val = 0; }
                    _Dbl_Tot = _Dbl_Tot + _Dbl_Val;
                }
            }
            return _Dbl_Tot;
        }

        private void _Pnl_DescPPago_VisibleChanged(object sender, EventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                if (_Pnl_DescPPago.Visible)
                {
                    if (_LstVDesc.Items.Count == 0)
                    {
                        MessageBox.Show("No tienen Porcentajes de Descuentos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void _Mtd_CargarPorcDesc(string _Pr_Str_IdDescPPPago)
        {
            //Para el listview
            string _Str_Sql = "";
            if (_Pr_Str_IdDescPPPago == "")
            {
                _Str_Sql = "SELECT cidescuentoppp,cdiasaplides,cporcdes FROM VST_DESCXPRONTOPAGO where (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) and cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' AND cdelete<>1";
            }
            else
            {
                _Str_Sql = "SELECT cidescuentoppp,cdiasaplides,cporcdes FROM VST_DESCXPRONTOPAGO where (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) and cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' and cidescuentoppp='" + _Pr_Str_IdDescPPPago + "'";
            }

            _LstVDesc.Items.Clear();
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds_A.Tables[0].Rows)
            {
                _LstVDesc.Items.Add(Convert.ToString(_DRow["cdiasaplides"]));
                _LstVDesc.Items[_LstVDesc.Items.Count - 1].Tag = Convert.ToString(_DRow["cidescuentoppp"]);
                _LstVDesc.Items[_LstVDesc.Items.Count - 1].SubItems.Add(Convert.ToString(_DRow["cporcdes"]));
            }
        }

        private void _CMen_B_Desc_CheckedChanged(object sender, EventArgs e)
        {
            //if (_Str_MyProceso != "" && !_Bol_FrmCheckDpppSw)
            if (_Str_MyProceso != "")
            {
                if (_CMen_B_Desc.Checked)
                {
                    _Mtd_CargarPorcDesc(_Str_FrmIdDescPPPago);

                    _LstVDesc.Enabled = true;
                    _Txt_MontoDesc.Text = "";
                    _Dg_OrdPagoDet.Enabled = false;
                    _Pnl_DescPPago.Visible = true;
                    _LstVDesc.Focus();
                }
                else
                {
                    string _Str_NumFact = "";
                    string _Str_Fact = "", _Str_NDP = "", _Str_ND = "", _Str_NC = "";
                    DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from VST_CONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    {
                        _Str_Fact = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocfact"]);
                        _Str_NDP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocndp"]);
                        _Str_ND = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnd"]);
                        _Str_NC = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnc"]);
                    }
                    _Str_NumFact = _Dg_OrdPagoDet["_Dg_OrdPagoDet_Col_NumDoc", _Dg_OrdPagoDet.CurrentCell.RowIndex].Value.ToString();
                    _Dg_OrdPagoDet["_Dg_OrdPagoDet_Col_Check", _Dg_OrdPagoDet.CurrentCell.RowIndex].ReadOnly = false;
                    foreach (DataRow _Drow in _G_Dt_NcSelec.Rows)
                    {
                        if (_Drow["cfact"].ToString() == _Str_NumFact)
                        {
                            foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
                            {
                                if (_DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value.ToString() == _Str_NC)
                                {
                                    if (_DgRow.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value.ToString() == _Drow["cnc"].ToString())
                                    {
                                        _DgRow.Cells["_Dg_OrdPagoDet_Col_Check"].ReadOnly = false;
                                        _DgRow.Cells[9].Value = "";
                                        _DgRow.Cells[10].Value = "";
                                    }

                                }
                            }

                        }
                    }
                    foreach (DataRow _Drow in _G_Dt_NdSelec.Rows)
                    {
                        if (_Drow["cfact"].ToString() == _Str_NumFact)
                        {
                            foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
                            {
                                if (_DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value.ToString() == _Str_ND)
                                {
                                    if (_DgRow.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value.ToString() == _Drow["cnd"].ToString())
                                    {
                                        _DgRow.Cells["_Dg_OrdPagoDet_Col_Check"].ReadOnly = false;
                                        _DgRow.Cells[9].Value = "";
                                        _DgRow.Cells[10].Value = "";
                                    }

                                }
                            }

                        }
                    }
                   
                    _Mtd_ActualizaDtDescPPPago();
                    _Pnl_DescPPago.Visible = false;
                    _Dg_OrdPagoDet.Enabled = true;
                    _Dg_OrdPagoDet[9, _Dg_OrdPagoDet.CurrentCell.RowIndex].Value = "";
                    _Dg_OrdPagoDet[10, _Dg_OrdPagoDet.CurrentCell.RowIndex].Value = "";
                    _Mtd_CallComprobOrdPago();
                }
            }
        }
        private void _Mtd_ActualizaDtDescPPPago()
        {
            string _Str_NumFact = _Dg_OrdPagoDet["_Dg_OrdPagoDet_Col_NumDoc", _Dg_OrdPagoDet.CurrentCell.RowIndex].Value.ToString();
            int _I = 0;
            while (_G_Dt_NcSelec.Rows.Count > _I)
            {
                if (Convert.ToString(_G_Dt_NcSelec.Rows[_I]["cfact"]) == _Str_NumFact)
                {
                    _G_Dt_NcSelec.Rows.RemoveAt(_I);
                }
                _I++;
            }

            _I = 0;
            while (_G_Dt_NdSelec.Rows.Count > _I)
            {
                if (Convert.ToString(_G_Dt_NdSelec.Rows[_I]["cfact"]) == _Str_NumFact)
                {
                    _G_Dt_NdSelec.Rows.RemoveAt(_I);
                }
                _I++;
            }
            
        }
        private void _Bt_DescOk_Click(object sender, EventArgs e)
        {
            string _Str_Fact = "";
            string _Str_NDP = "";
            string _Str_ND = "";
            string _Str_NC = "";
            string _Str_Cod = "";
            string _Str_NumFact = "";
            _Dg_OrdPagoDet.Enabled = true;
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from VST_CONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_Fact = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocfact"]);
                _Str_NDP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocndp"]);
                _Str_ND = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnd"]);
                _Str_NC = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnc"]);
            }
            _Dg_OrdPagoDet[9, _Dg_OrdPagoDet.CurrentCell.RowIndex].Value = _Txt_MontoDesc.Text;
            foreach (ListViewItem _mItem in _LstVDesc.CheckedItems)
            {
                _Str_Cod = Convert.ToString(_mItem.Tag);
            }
            _Dg_OrdPagoDet[10, _Dg_OrdPagoDet.CurrentCell.RowIndex].Value = _Str_Cod;
            _Dg_OrdPagoDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_OrdPagoDet_CellValueChanged);
            foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
            {
                if (Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_Check"].Value) == "1")
                {
                    if (_DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value.ToString() == _Str_Fact | _DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value.ToString() == _Str_NDP)
                    {
                        _Str_NumFact = _DgRow.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value.ToString();
                        //break;
                    }
                    _DgRow.Cells[10].Value = _Str_Cod;
                }
            }
            foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
            {
                if (Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_Check"].Value) == "1")
                {
                    _DgRow.Cells["_Dg_OrdPagoDet_Col_Check"].ReadOnly = true;
                    if (_DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value.ToString() == _Str_ND)
                    {
                        object[] _MyObj = new object[] { _DgRow.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value.ToString(), _Str_NumFact };
                        _G_Dt_NdSelec.Rows.Add(_MyObj);
                    }
                    if (_DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value.ToString() == _Str_NC)
                    {
                        object[] _MyObj = new object[] { _DgRow.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value.ToString(), _Str_NumFact };
                        _G_Dt_NcSelec.Rows.Add(_MyObj);
                    }
                }
                _DgRow.Cells["_Dg_OrdPagoDet_Col_Check"].Value = "0";
            }
            _Dg_OrdPagoDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_OrdPagoDet_CellValueChanged);
            _Pnl_DescPPago.Visible = false;
        }

        private void _Bt_DescCancel_Click(object sender, EventArgs e)
        {
            _Dg_OrdPagoDet.Enabled = true;
            _Dg_OrdPagoDet[9, _Dg_OrdPagoDet.CurrentCell.RowIndex].Value = "";
            _Dg_OrdPagoDet[10, _Dg_OrdPagoDet.CurrentCell.RowIndex].Value = "";
            _Pnl_DescPPago.Visible = false;
        }

        private void _CMen_B_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void _Dg_OrdPagoDet_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
            if (e.Control is TextBox)
            {
                _Txt_ColMCancelar = e.Control as TextBox;
                _Txt_ColMCancelar.KeyPress += new KeyPressEventHandler(_Txt_ColMCancelar_KeyPress);
            }
            
        }

        private void _Txt_ColMCancelar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_Dg_OrdPagoDet.CurrentCell.ColumnIndex == 5)
            { myUtilidad._Mtd_Valida_Numeros(_Txt_ColMCancelar, e, 15, 2); }
        }

        private void _CMen_B_Desc_DropDownClosed(object sender, EventArgs e)
        {
            _CMen_B_Desc.Checked = false;
        }

        private void _Mtd_DesbloqDgOPAdd()
        {
            if (_Str_MyProceso == "A")
            {
                if ((_Rb_Abono.Checked || _Rb_PagoTot.Checked) && (_Rb_Efectivo.Checked || _Rb_Cheque.Checked || _Rb_Transferencia.Checked || _Rb_TCredito.Checked))
                {
                    if (_Rb_Cheque.Checked || _Rb_Transferencia.Checked || _Rb_TCredito.Checked)
                    {
                        if (_Cb_Banco.SelectedIndex > 0 && _Cb_Cuenta.SelectedIndex > 0)
                        {
                            _Dg_OrdPagoDet.Enabled = true;
                            _Dg_OrdPagoDet.Columns["_Dg_OrdPagoDet_Col_Check"].ReadOnly = false;
                        }
                        else
                        { _Dg_OrdPagoDet.Enabled = false; }
                    }
                    else if (_Rb_Efectivo.Checked)
                    {
                        if (_Cb_Caja.SelectedIndex > -1)
                        {
                            _Dg_OrdPagoDet.Enabled = true;
                            _Dg_OrdPagoDet.Columns["_Dg_OrdPagoDet_Col_Check"].ReadOnly = false;
                        }
                        else
                        { _Dg_OrdPagoDet.Enabled = false; }
                    }
                    else
                    { _Dg_OrdPagoDet.Enabled = false; }
                }
                else
                {
                    _Dg_OrdPagoDet.Enabled = false;
                }
            }
            
        }

        private double _Mtd_CalcularDescPPPago(string _Pr_Str_DescPPPagoID)
        {
            double _Dbl_AcumND = 0;
            double _Dbl_AcumNC = 0;
            double _Dbl_PorcDesc = 0;
            double _Dbl_MontoFact = 0;
            double _Dbl_Desc = 0;
            double _Dbl_Monto = 0;
            string _Str_Fact = "";
            string _Str_NDP = "";
            string _Str_RetIVA = "";
            string _Str_RetISLR = "";
            string _Str_NC = "", _Str_ND = "";
            string _Str_NumFact = "";
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from VST_CONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_Fact = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocfact"]);
                _Str_NDP = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocndp"]);
                _Str_RetISLR = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocretislr"]);
                _Str_RetIVA = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipdocretiva"]);
                _Str_ND = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnd"]);
                _Str_NC = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ctipodocnc"]);
            }
            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cporcdes from TDESCPRONTOPAGP where cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' and cidescuentoppp=" + _Pr_Str_DescPPPagoID);
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) != "")
                {
                    _Dbl_PorcDesc = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]);
                }
            }
            foreach (DataGridViewRow _DgRowFact in _Dg_OrdPagoDet.Rows)
            {
                if (Convert.ToString(_DgRowFact.Cells["_Dg_OrdPagoDet_Col_Check"].Value)=="1")
                {
                    if (_DgRowFact.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value.ToString().Trim() == _Str_Fact.Trim() | _DgRowFact.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value.ToString().Trim() == _Str_NDP.Trim())
                    {
                        _Str_NumFact = _DgRowFact.Cells["_Dg_OrdPagoDet_Col_NumDoc"].Value.ToString();
                        _Dbl_MontoFact = Convert.ToDouble(_Dg_OrdPagoDet[4, _Dg_OrdPagoDet.CurrentCell.RowIndex].Value); //TOMO EL MONTO DEL DOCUMENTO
                        foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
                        {
                            //if (Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_Check"].Value) == "1")
                            //{
                                if (Convert.ToString(_DgRow.Cells[8].Value) == _Str_NC)
                                {
                                    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctotaldocu,cnumdocu from TNOTACREDICP where ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotacreditocxp=" + Convert.ToString(_DgRow.Cells[2].Value));
                                    if (_Ds_A.Tables[0].Rows.Count > 0)
                                    {
                                        if (Convert.ToString(_Ds_A.Tables[0].Rows[0]["cnumdocu"]) == _Str_NumFact)
                                        {
                                            _Dbl_AcumNC = _Dbl_AcumNC + Convert.ToDouble(_Ds_A.Tables[0].Rows[0]["ctotaldocu"]);
                                        }
                                    }
                                }
                                if (Convert.ToString(_DgRow.Cells[8].Value) == _Str_ND)
                                {
                                    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctotaldocu,cnumdocu from TNOTADEBITOCP where ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp=" + Convert.ToString(_DgRow.Cells[2].Value));
                                    if (_Ds_A.Tables[0].Rows.Count > 0)
                                    {
                                        if (Convert.ToString(_Ds_A.Tables[0].Rows[0]["cnumdocu"]) == _Str_NumFact)
                                        {
                                            _Dbl_AcumND = _Dbl_AcumND + Convert.ToDouble(_Ds_A.Tables[0].Rows[0]["ctotaldocu"]);
                                        }
                                    }
                                }
                            //}
                        }
                    }
                }
            }
            _Dbl_Monto = _Dbl_MontoFact + _Dbl_AcumNC - _Dbl_AcumND;
            _Dbl_Desc = (_Dbl_Monto * _Dbl_PorcDesc) / 100;
            return _Dbl_Desc;
        }

        private void _LstVDesc_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                if (e.Item.Checked)
                {
                    _Txt_MontoDesc.Text = _Mtd_CalcularDescPPPago(Convert.ToString(e.Item.Tag)).ToString("#,##0.00");
                }
            }
        }

        private void _LstVDesc_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                if (_LstVDesc.CheckedItems.Count >= 1)
                {
                    e.NewValue = CheckState.Unchecked;
                }
            }
            
        }

        private void _LstVDesc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _Bt_AddDoc_Click(object sender, EventArgs e)
        {
            double _Dbl_Monto =0;
            if (_Txt_Total.Text != "")
            {
                _Dbl_Monto = Convert.ToDouble(_Txt_Total.Text);
            }
            Frm_CxPVista _Frm = new Frm_CxPVista(Convert.ToString(_Txt_Prov.Tag), _Dg_OrdPagoDet.Rows, _Dbl_Monto);
            _Frm.ShowDialog();
            if (_Frm._Bol_FrmResult)
            {
                string _Str_Sql = "", _Str_TpoDocFact = "", _Str_TpoDocNDP = "", _Str_TpoDocND = "", _Str_TpoDocNC = "";
                _Str_Sql = "SELECT ctipodocnd,ctipodocnc,ctipdocfact,ctipodocndp FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_TpoDocFact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]);
                    _Str_TpoDocNDP = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocndp"]);
                    _Str_TpoDocND = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocnd"]);
                    _Str_TpoDocNC = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocnc"]);
                }
                foreach (DataGridViewRow _DgRow in _Frm._Dg_Grid_Rp.Rows)
                {
                    if (Convert.ToString(_DgRow.Cells[17].Value) == "1")
                    {
                        _Dg_OrdPagoDet.Rows.Add();
                        _Dg_OrdPagoDet.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_OrdPagoDet_CellValueChanged);
                        _Dg_OrdPagoDet[0, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells[2].Value;
                        _Dg_OrdPagoDet[1, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells[3].Value;
                        _Dg_OrdPagoDet[2, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells[4].Value;
                        _Dg_OrdPagoDet[3, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells[5].Value;
                        _Dg_OrdPagoDet[4, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells[6].Value;
                        _Dg_OrdPagoDet[6, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells[0].Value;
                        _Dg_OrdPagoDet[7, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells[11].Value;
                        _Dg_OrdPagoDet[8, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells[13].Value;
                        if (_Rb_PagoTot.Checked)
                        {
                            if (_DgRow.Cells[13].Value.ToString() != _Str_TpoDocFact & _DgRow.Cells[13].Value.ToString() != _Str_TpoDocNDP)
                            { _Dg_OrdPagoDet[5, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells[6].Value; }
                            else
                            {
                                double _Dbl_MontoAbonado = myUtilidad._Mtd_ObtenerRestanteOrdPago(Convert.ToString(_Dg_OrdPagoDet[2, _Dg_OrdPagoDet.RowCount - 1].Value), Convert.ToString(_Dg_OrdPagoDet[8, _Dg_OrdPagoDet.RowCount - 1].Value), Convert.ToString(_Txt_Prov.Tag));
                                //_Dg_OrdPagoDet[5, _Dg_OrdPagoDet.RowCount - 1].Value = Convert.ToDouble(Convert.ToDouble(_DgRow.Cells[6].Value) - ;
                                _Dg_OrdPagoDet[5, _Dg_OrdPagoDet.RowCount - 1].Value = _Dbl_MontoAbonado.ToString("#,##0.00");
                            }
                        }
                        else
                        {
                            if (_DgRow.Cells[13].Value.ToString() != _Str_TpoDocFact & _DgRow.Cells[13].Value.ToString() != _Str_TpoDocNDP)
                            {
                                _Dg_OrdPagoDet[5, _Dg_OrdPagoDet.RowCount - 1].Value = _DgRow.Cells[6].Value;
                            }
                            else
                            {
                                _Dg_OrdPagoDet[5, _Dg_OrdPagoDet.RowCount - 1].Value = "0";
                            }
                        }
                        _Dg_OrdPagoDet.CellValueChanged += new DataGridViewCellEventHandler(_Dg_OrdPagoDet_CellValueChanged);
                    }
                }
                _Mtd_DgOrdPagDetHabilitar();
                _Txt_Total.Text = Convert.ToDouble(_Mtd_CalcularTotalPago() - _Mtd_Anticipo(_Txt_Transaccion.Text.Trim())).ToString("#,##0.00");
                Cursor = Cursors.WaitCursor;
                _Mtd_CallComprobOrdPago();
                Cursor = Cursors.Default;
            }
            _Frm.Dispose();
            _Frm = null;
        }

        private double _Mtd_CalcularTotalPago()
        {
            double _Dbl_Saldo = 0;
            double _Dbl_DescPPP = 0;
            double _Dbl_Monto = 0;
            double _Dbl_Acum = 0;
            foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
            {
                _Dbl_DescPPP = 0;
                
                if (Convert.ToString(_DgRow.Cells[5].Value) != "")
                {
                    _Dbl_Saldo = Convert.ToDouble(_DgRow.Cells[5].Value);
                }
                if (Convert.ToString(_DgRow.Cells[9].Value) != "")
                {
                    _Dbl_DescPPP = Convert.ToDouble(_DgRow.Cells[9].Value);
                }
                _Dbl_Monto = _Dbl_Saldo - _Dbl_DescPPP;
                _Dbl_Acum = _Dbl_Acum + _Dbl_Monto;
            }
            return _Dbl_Acum;
        }


        private void _CMen_B_DelFila_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(_Dg_OrdPagoDet[10, _Dg_OrdPagoDet.CurrentCell.RowIndex].Value).Trim().Length == 0)
            {
                this.Cursor = Cursors.WaitCursor;
                _Dg_OrdPagoDet.RowsRemoved -= new DataGridViewRowsRemovedEventHandler(_Dg_OrdPagoDet_RowsRemoved);
                _Dg_OrdPagoDet.Rows.RemoveAt(_Dg_OrdPagoDet.CurrentCell.RowIndex);
                _Dg_OrdPagoDet.RowsRemoved += new DataGridViewRowsRemovedEventHandler(_Dg_OrdPagoDet_RowsRemoved);
                _Txt_Total.Text = _Mtd_CalcularTotalPago().ToString("#,##0.00");
                _Mtd_CallComprobOrdPago();
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Este documento esta asociado a un descuento por pronto pago. Debe deshacer la operación.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Dg_Find_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgInfo.Visible = true;
            }
            else
            {
                _Lbl_DgInfo.Visible = false;
            }
        }

        private void _Dg_OrdPagoDet_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                if (e.ColumnIndex == -1 && e.RowIndex > -1)
                {
                    _Lbl_DgOrdPagoDetInfo.Visible = true;
                }
                else
                {
                    _Lbl_DgOrdPagoDetInfo.Visible = false;
                }
            }
        }

        private void _Cb_Caja_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                if (_Cb_Caja.SelectedIndex < 1)
                {
                    _Bt_Comprobante.Enabled = false;
                }
            }
        }

        private void _Dg_OrdPagoDet_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (_Str_MyProceso.Length > 0)
            {
                if (_Dg_OrdPagoDet.RowCount > 0)
                {
                    _Mtd_CallComprobOrdPago(); 
                    _Bt_Comprobante.Enabled = true;
                    _Txt_Total.Text= _Mtd_CalcularTotalPago().ToString("#,##0.00");
                }
                else
                {
                    _Bt_Comprobante.Enabled = false;
                }
            }
        }

        private void _Mtd_DgOrdPagDetHabilitar()
        {
            string _Str_Sql = "", _Str_TpoDocFact = "", _Str_TpoDocNDP = "";
            _Str_Sql = "SELECT ctipdocfact,ctipodocndp FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TpoDocFact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]);
                _Str_TpoDocNDP = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocndp"]);
            }
            _Dg_OrdPagoDet.ReadOnly = false;
            foreach (DataGridViewColumn _DgCol in _Dg_OrdPagoDet.Columns)
            {
                _DgCol.ReadOnly = true;
                
            }
            foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
            {
                if (_DgRow.Cells[8].Value.ToString() == _Str_TpoDocFact | _DgRow.Cells[8].Value.ToString() == _Str_TpoDocNDP)
                {
                    if (_Rb_Abono.Checked)
                    {
                        _DgRow.Cells[5].ReadOnly = false;
                    }
                }
                if (Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_MontoDescPPP"].Value).Trim().Length==0)
                {
                    _DgRow.Cells["_Dg_OrdPagoDet_Col_Check"].ReadOnly = false;
                }
            }
        }

        private void _Cb_CatProveFind_DropDown(object sender, EventArgs e)
        {            
            this.Cursor = Cursors.WaitCursor;
            if (_Cb_TpoProveFind.SelectedIndex > 0)
            {
                _Mtd_CargarCatProve(_Cb_TpoProveFind.SelectedValue.ToString());
            }
            this.Cursor = Cursors.Default;
        }

        private void _Cb_Banco_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT DISTINCT TBANCO.cbanco,TBANCO.cname FROM TBANCO INNER JOIN " +
"TCUENTBANC ON TBANCO.ccompany = TCUENTBANC.ccompany AND TBANCO.cbanco = TCUENTBANC.cbanco WHERE TBANCO.ccompany='" + Frm_Padre._Str_Comp + "' and TBANCO.cdelete=0";
            myUtilidad._Mtd_CargarCombo(_Cb_Banco, _Str_Sql);
            this.Cursor = Cursors.Default;
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_Bol_Otros)
            {
                if (e.TabPageIndex == 1)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                if (e.TabPageIndex == 1)
                {
                    if (!_Cb_Banco.Enabled & _Cb_Banco.SelectedIndex < 1)
                    {
                        e.Cancel = true;
                    }
                }
                else if (e.TabPageIndex == 2)
                {
                    e.Cancel = true;
                }
            }
        }

        private void _CMen_B_Opening(object sender, CancelEventArgs e)
        {
            if (CLASES._Cls_Varios_Metodos._Mtd_EsProveedorIC(Convert.ToString(_Txt_Prov.Tag)))
            {
                e.Cancel = true;
                return;
            }
            string _Str_Fact = "";
            string _Str_NDP = "";
            double _Dbl_MontoDesc = 0;
            double _Dbl_MontoCancelar = 0;
            bool _Bol_Aux = false;
            _Dg_OrdPagoDet.EndEdit();
            if (_Dg_OrdPagoDet.SelectedRows.Count > 0)
            {
                _CMen_B_Desc.Enabled = ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled;//Linea nueva
                if (_Str_MyProceso.Length > 0)
                {
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipdocfact,ctipodocndp from TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_Fact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]);
                        _Str_NDP = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocndp"]);
                    }
                    if (Convert.ToString(_Dg_OrdPagoDet[8, _Dg_OrdPagoDet.CurrentCell.RowIndex].Value) == _Str_Fact | Convert.ToString(_Dg_OrdPagoDet[8, _Dg_OrdPagoDet.CurrentCell.RowIndex].Value) == _Str_NDP)
                    {
                        if (Convert.ToString(_Dg_OrdPagoDet["_Dg_OrdPagoDet_Col_Check", _Dg_OrdPagoDet.CurrentCell.RowIndex].Value) == "1" || Convert.ToString(_Dg_OrdPagoDet[9, _Dg_OrdPagoDet.CurrentCell.RowIndex].Value).Length>0)
                        {
                            //_Dbl_MontoRestante = myUtilidad._Mtd_ObtenerRestanteOrdPago(Convert.ToString(_Dg_OrdPagoDet[2, e.RowIndex].Value),Convert.ToString(_Dg_OrdPagoDet[3, e.RowIndex].Value),Convert.ToString(_Txt_Prov.Tag));
                            //BUSCO EL TOTAL DE DECUENTO POR PRONTO PAGO
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select sum(cmontoddpp) from VST_PAGOS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' and cnumdocu='" + Convert.ToString(_Dg_OrdPagoDet[2, _Dg_OrdPagoDet.CurrentCell.RowIndex].Value) + "' and ctipodocument='" + Convert.ToString(_Dg_OrdPagoDet[8, _Dg_OrdPagoDet.CurrentCell.RowIndex].Value) + "' and canulado=0");
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                                {
                                    _Dbl_MontoDesc = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                                }
                            }
                            if (Convert.ToString(_Dg_OrdPagoDet[5, _Dg_OrdPagoDet.CurrentCell.RowIndex].Value).Trim() != "")
                            {
                                _Dbl_MontoCancelar = Convert.ToDouble(_Dg_OrdPagoDet[5, _Dg_OrdPagoDet.CurrentCell.RowIndex].Value);
                            }
                            if (_Dbl_MontoCancelar != 0)
                            {
                                //if (_Str_MyProceso == "M")
                                //{
                                //VERIFICO SI ESTA ORDEN DE PAGO TIENE DESCUENTO
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cmontoddpp,cidescuentoppp from VST_PAGOS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "' and cnumdocu='" + Convert.ToString(_Dg_OrdPagoDet[2, _Dg_OrdPagoDet.CurrentCell.RowIndex].Value) + "' and ctipodocument='" + Convert.ToString(_Dg_OrdPagoDet[8, _Dg_OrdPagoDet.CurrentCell.RowIndex].Value) + "' AND canulado=0");
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) != "")
                                    {
                                        _Str_FrmIdDescPPPago = Convert.ToString(_Ds.Tables[0].Rows[0]["cidescuentoppp"]);
                                        //_Dbl_MontoDescID = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontoddpp"]);
                                        _Bol_Aux = true;
                                    }
                                    else
                                    {
                                        _Bol_Aux = false;
                                        _Str_FrmIdDescPPPago = "";
                                    }
                                    //_Bol_Aux = true;
                                }
                                else
                                {
                                    _Bol_Aux = true;

                                }
                                if (_Bol_Aux)
                                {
                                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cidescuentoppp FROM VST_DESCXPRONTOPAGO where (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) and cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "'");
                                    if (_Ds.Tables[0].Rows.Count > 0)
                                    {
                                        if (Convert.ToString(_Dg_OrdPagoDet[5, _Dg_OrdPagoDet.CurrentCell.RowIndex].Value) != "")
                                        {
                                            //_Bol_FrmCheckDpppSw = true;
                                            _CMen_B_Desc.CheckedChanged -= new EventHandler(_CMen_B_Desc_CheckedChanged);
                                            if (Convert.ToString(_Dg_OrdPagoDet[9, _Dg_OrdPagoDet.CurrentCell.RowIndex].Value) != "")
                                            { _CMen_B_Desc.Checked = true; }
                                            else
                                            { _CMen_B_Desc.Checked = false; }
                                            _CMen_B_Desc.Visible = true;
                                            _CMen_B_Desc.Enabled = true;
                                            //_Bol_FrmCheckDpppSw = false;
                                            _CMen_B_Desc.CheckedChanged += new EventHandler(_CMen_B_Desc_CheckedChanged);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No tiene Descuentos por Pronto Pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        e.Cancel = true;
                                    }
                                }
                                //else
                                //{ MessageBox.Show("Esta Factura ya tiene asociada un Descuento por pronto pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            }
                            else
                            {
                                MessageBox.Show("Ingrese el Monto a Cancelar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                e.Cancel = true;
                            }
                        }
                        else
                        {
                            _CMen_B_Desc.Enabled = false;
                        }
                        
                    }
                    else
                    {
                        _CMen_B_Desc.Enabled = false;
                    }
                    //Rutina para mostrar la opcion de eliminar la fila
                    if (Convert.ToString(_Dg_OrdPagoDet[11, _Dg_OrdPagoDet.CurrentCell.RowIndex].Value) != "1")
                    {
                        _CMen_B_DelFila.Visible = true;
                    }
                    else
                    {
                        _CMen_B_DelFila.Visible = false;
                        //if (!_CMen_B_Desc.Visible)
                        //{
                        //    e.Cancel = true;
                        //}
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
            _CMen_B_DelFila.Enabled = !((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled;
        }

        private bool _Mtd_AplicaDescPPPago()
        {
            bool _Bol_SwHayDescPPPago = false;
            string _Str_Sql = "SELECT * FROM VST_DESCXPRONTOPAGO WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1) and cproveedor='" + _Txt_Prov.Tag.ToString() + "' AND cdelete=0";
            _Bol_SwHayDescPPPago = Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql);
            if (_Bol_SwHayDescPPPago)
            {
 
            }
            return _Bol_SwHayDescPPPago;
        }
        private bool _Mtd_HayDupliFactForDescPPPago()
        {
            bool _Bol_R = false;
            int _Int_Num = 0;
            string _Str_Fact = "";
            string _Str_NDP = "";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select ctipdocfact,ctipodocndp from TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Fact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]);
                _Str_NDP = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocndp"]);
            }
            foreach (DataGridViewRow _DgRow in _Dg_OrdPagoDet.Rows)
            {
                if (Convert.ToString(_DgRow.Cells["_Dg_OrdPagoDet_Col_Check"].Value)=="1")
                {
                    if (_DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value.ToString().Trim() == _Str_Fact.Trim() | _DgRow.Cells["_Dg_OrdPagoDet_Col_TpoDocId"].Value.ToString().Trim() == _Str_NDP.Trim())
                    {
                        _Int_Num++;
                    }
                }
                if (_Int_Num > 1)
                {
                    break;
                }
            }
            if (_Int_Num > 1)
            {
                _Bol_R = true;
            }
            return _Bol_R;
        }
        private void _Txt_Prov_TextChanged(object sender, EventArgs e)
        {
            if (_Txt_Prov.Text.Trim().Length > 0)
            {
                if (_Mtd_AplicaDescPPPago())
                {
                    _Dg_OrdPagoDet.Columns["_Dg_OrdPagoDet_Col_Check"].Visible = true;
                }
                else
                {
                    _Dg_OrdPagoDet.Columns["_Dg_OrdPagoDet_Col_Check"].Visible = false;
                }
            }
            else
            {
                _Dg_OrdPagoDet.Columns["_Dg_OrdPagoDet_Col_Check"].Visible = false;
            }
        }
        private void _Mtd_Dt_NDSelec()
        {
            DataColumn _DtCol = new DataColumn("cnd", Type.GetType("System.String"));
            DataColumn _DtColA = new DataColumn("cfact", Type.GetType("System.String"));
            _G_Dt_NdSelec.Columns.Add(_DtCol);
            _G_Dt_NdSelec.Columns.Add(_DtColA);
        }
        private void _Mtd_Dt_NCSelec()
        {
            DataColumn _DtCol = new DataColumn("cnc", Type.GetType("System.String"));
            DataColumn _DtColA = new DataColumn("cfact", Type.GetType("System.String"));
            _G_Dt_NcSelec.Columns.Add(_DtCol);
            _G_Dt_NcSelec.Columns.Add(_DtColA);
        }

        private void _Bt_Beneficiario_Click(object sender, EventArgs e)
        {
            string _Str_Cadena = " AND cglobal='2' AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "'";
            if (_Cb_TpoPagoOtros.SelectedIndex == 3)
            { _Str_Cadena = " AND ((cglobal='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "') OR (cglobal<>'1' AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "'))"; }
            else if (_Cb_TpoPagoOtros.SelectedIndex == 11)
            { _Str_Cadena = " AND cglobal='0' AND ccatproveedor='7' AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "'"; }
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(50, _Txt_Beneficiario, 0, _Str_Cadena);            
            _Frm.ShowDialog();
            if (_Txt_Beneficiario.Tag.ToString().Trim().Length > 0)
            {
                _Mtd_BuscarRifProveedor(_Txt_Beneficiario.Tag.ToString());
            }
            if (_Bol_DebitoBancarioHabilitado)
            {
                string _Str_SQL = "SELECT CEXENTODEBITOBANCARIO FROM TPROVEEDOR WHERE CPROVEEDOR='" + _Txt_Beneficiario.Tag.ToString() + "'";
                string _Str_ExentoDebitoBancario = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL).Tables[0].Rows[0]["CEXENTODEBITOBANCARIO"].ToString();
                if (_Str_ExentoDebitoBancario != "")
                {
                    if (_Str_ExentoDebitoBancario == "1")
                    {
                        _Bol_DebitoBancarioHabilitado = false;
                        _Dg_Grid.Rows.RemoveAt(2);
                        _Dg_Grid.Rows.RemoveAt(1);
                    }
                }
            }
        }
        /// <summary>
        /// Método que sirve para buscar el rif del proveedor
        /// </summary>
        /// <param name="_Str_Proveedor">Código del proveedor</param>
        private void _Mtd_BuscarRifProveedor(string _Str_Proveedor)
        {
            string _Str_Cadena = "SELECT TOP 1 C_RIF FROM TPROVEEDOR WHERE CPROVEEDOR='"+_Str_Proveedor+"'";
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Split('-').Count() > 2)
            {
                _Rbt_Rif.Checked = true;
            }
            else
            {
                _Rbt_Cedula.Checked = true;
            }
            _Txt_Rif.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString();
        }
        /// <summary>
        /// Método que sirve para buscar el rif del proveedor
        /// </summary>
        /// <param name="_Str_Proveedor">Código del proveedor</param>
        private string _Mtd_BuscarRifDelProveedor(string _Str_Proveedor)
        {
            string _Str_Cadena = "SELECT TOP 1 C_RIF FROM TPROVEEDOR WHERE CPROVEEDOR='" + _Str_Proveedor + "'";            
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString();
        }
        private void _Cb_Banco_Otros_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarBancoOtros();
        }

        private void _Cb_Banco_Otros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cb_Banco_Otros.SelectedIndex > 0)
            { _Mtd_CargarCtaBancoOtros(_Cb_Banco_Otros.SelectedValue.ToString()); _Cb_Cuenta_Otros.Enabled = true; _Cb_Cuenta_Otros.Focus(); _Er_Error.Dispose(); }
            else
            { _Cb_Cuenta_Otros.Enabled = false; _Cb_Cuenta_Otros.DataSource = null; }
        }

        private void _Txt_MontoPagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            myUtilidad._Mtd_Valida_Numeros(_Txt_MontoPagar, e, 10, 2);
            if (e.KeyChar == (char)13)
            {
                if (_Txt_MontoPagar.Text.Trim().Length > 0)
                {
                    if (Convert.ToDouble(_Txt_MontoPagar.Text) > 0)
                    { _Dg_Grid.Focus(); }
                }
            }
        }

        private void _Dg_Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value != null)
                {
                    _Str_Temp_Cuenta = _Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value.ToString();
                }
            }
            else if (e.ColumnIndex == 2)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Descripcion"].Value != null)
                {
                    _Str_Temp_Descripcion = _Dg_Grid.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
                }
            }
            else if (e.ColumnIndex == 3)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["cidauxiliarcont"].Value != null)
                {
                    _Str_Temp_Auxiliar = _Dg_Grid.Rows[e.RowIndex].Cells["cidauxiliarcont"].Value.ToString();
                }
            }
            else if (e.ColumnIndex == 5)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Tipo"].Value != null)
                {
                    _Str_Temp_Tipo = _Dg_Grid.Rows[e.RowIndex].Cells["Tipo"].Value.ToString();
                }
            }
            else if (e.ColumnIndex == 6)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Documento"].Value != null)
                {
                    _Str_Temp_Documento = _Dg_Grid.Rows[e.RowIndex].Cells["Documento"].Value.ToString();
                }
            }
        }

        private void _Dg_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!_Dg_Grid.ReadOnly & e.RowIndex > 0)
            {
                if (e.ColumnIndex == 1)
                {
                    TextBox _Txt_Temp = new TextBox();
                    Cursor = Cursors.WaitCursor;
                    Frm_Busqueda2 _Frm = new Frm_Busqueda2(45, _Txt_Temp, 0, "");
                    Cursor = Cursors.Default;
                    _Frm.ShowDialog();
                    if (_Txt_Temp.Text.Trim().Length > 0)
                    {
                        _Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value = _Txt_Temp.Text.Trim();
                        _Dg_Grid.Rows[e.RowIndex].Cells["cidauxiliarcont"].Value = null;
                        _Dg_Grid.Rows[e.RowIndex].Cells["Tipo"].Value = null;
                        _Dg_Grid.Rows[e.RowIndex].Cells["Documento"].Value = null;
                        if (_Mtd_MarcarAuxiliar(e.RowIndex))
                        { _Dg_Grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Khaki; }
                        else
                        { _Dg_Grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White; }
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    Cursor = Cursors.WaitCursor;
                    Frm_ComprobanteContableAux _Frm = new Frm_ComprobanteContableAux(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Cuenta"].Value).Trim(), Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cidauxiliarcont"].Value).Trim());
                    Cursor = Cursors.Default;
                    _Frm.ShowDialog();
                    if (Convert.ToString(_Frm._Txt_ID_Auxiliar.Tag).Trim() != "0" & Convert.ToString(_Frm._Txt_ID_Auxiliar.Tag).Trim().Length > 0)
                    {
                        _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cidauxiliarcont"].Value = Convert.ToString(_Frm._Txt_ID_Auxiliar.Tag).Trim();
                    }
                }
            }
        }

        private void _Dg_Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 & !_Dg_Grid.ReadOnly & e.RowIndex != 0)
            {
                TextBox _Txt_Temp = new TextBox();
                Cursor = Cursors.WaitCursor;
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(45, _Txt_Temp, 0, "");
                Cursor = Cursors.Default;
                _Frm.ShowDialog();
                if (_Txt_Temp.Text.Trim().Length > 0)
                {
                    _Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value = _Txt_Temp.Text.Trim();
                    _Dg_Grid.Rows[e.RowIndex].Cells["cidauxiliarcont"].Value = null;
                    _Dg_Grid.Rows[e.RowIndex].Cells["Tipo"].Value = null;
                    _Dg_Grid.Rows[e.RowIndex].Cells["Documento"].Value = null;
                    if (_Mtd_MarcarAuxiliar(e.RowIndex))
                    { _Dg_Grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Khaki; }
                    else
                    { _Dg_Grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White; }
                }
            }
        }
        string _Str_Temp_Cuenta = "";
        string _Str_Temp_Descripcion = "";
        string _Str_Temp_Auxiliar = "";
        string _Str_Temp_Tipo = "";
        string _Str_Temp_Documento = "";
        private void _Dg_Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value != null)
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value.ToString().Trim().Length == 0)
                    {
                        _Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value = _Str_Temp_Cuenta;
                    }
                    else
                    {
                        if (!_Mtd_CuentaDetalle(_Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value.ToString().Trim()))
                        {
                            MessageBox.Show("Debe ingresar una cuenta de detalle", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value = _Str_Temp_Cuenta;
                        }
                        else
                        {
                            _Dg_Grid.Rows[e.RowIndex].Cells["cidauxiliarcont"].Value = null;
                            _Dg_Grid.Rows[e.RowIndex].Cells["Tipo"].Value = null;
                            _Dg_Grid.Rows[e.RowIndex].Cells["Documento"].Value = null;
                            if (_Mtd_MarcarAuxiliar(e.RowIndex))
                            { _Dg_Grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Khaki; }
                            else
                            { _Dg_Grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White; }
                        }
                    }
                }
                else
                { _Dg_Grid.Rows[e.RowIndex].Cells["Cuenta"].Value = _Str_Temp_Cuenta; }
            }
            else if (e.ColumnIndex == 2)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Descripcion"].Value != null)
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString().Trim().Length == 0)
                    {
                        _Dg_Grid.Rows[e.RowIndex].Cells["Descripcion"].Value = _Str_Temp_Descripcion;
                    }
                }
                else
                { _Dg_Grid.Rows[e.RowIndex].Cells["Descripcion"].Value = _Str_Temp_Descripcion; }
                //-------------------------------------------------------------------------------
            }
            else if (e.ColumnIndex == 3)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["cidauxiliarcont"].Value != null)
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells["cidauxiliarcont"].Value.ToString().Trim().Length == 0 & _Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Grid.CurrentCell.RowIndex)))
                    {
                        _Dg_Grid.Rows[e.RowIndex].Cells["cidauxiliarcont"].Value = _Str_Temp_Auxiliar;
                    }
                }
                else
                {
                    if (_Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Grid.CurrentCell.RowIndex))) { _Dg_Grid.Rows[e.RowIndex].Cells["cidauxiliarcont"].Value = _Str_Temp_Auxiliar; }
                }
                //-------------------------------------------------------------------------------
            }
            else if (e.ColumnIndex == 5)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Tipo"].Value != null)
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells["Tipo"].Value.ToString().Trim() == "nulo" & _Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Grid.CurrentCell.RowIndex)))
                    {
                        _Dg_Grid.Rows[e.RowIndex].Cells["Tipo"].Value = _Str_Temp_Tipo;
                    }
                }
                else
                {
                    if (_Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Grid.CurrentCell.RowIndex))) { _Dg_Grid.Rows[e.RowIndex].Cells["Tipo"].Value = _Str_Temp_Tipo; }
                }
            }
            else if (e.ColumnIndex == 6)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Documento"].Value != null)
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells["Documento"].Value.ToString().Trim().Length == 0 & _Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Grid.CurrentCell.RowIndex)))
                    {
                        _Dg_Grid.Rows[e.RowIndex].Cells["Documento"].Value = _Str_Temp_Documento;
                    }
                }
                else
                {
                    if (_Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Grid.CurrentCell.RowIndex))) { _Dg_Grid.Rows[e.RowIndex].Cells["Documento"].Value = _Str_Temp_Documento; }
                }
            }
            else if (e.ColumnIndex == 7)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Debe"].Value != null)
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells["Debe"].Value.ToString().Trim().Length > 0)
                    {
                        _Dg_Grid.Rows[e.RowIndex].Cells["Haber"].Value = null;
                    }
                }
                _Mtd_CalcularTotales();
            }
            else if (e.ColumnIndex == 8)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells["Haber"].Value != null)
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells["Haber"].Value.ToString().Trim().Length > 0)
                    {
                        _Dg_Grid.Rows[e.RowIndex].Cells["Debe"].Value = null;
                    }
                }
                _Mtd_CalcularTotales();
            }
            _Bol_Boleano = false;
        }

        private void _Dg_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        bool _Bol_Boleano = false;
        private void _Dg_Grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!_Bol_Boleano)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
                e.Control.TextChanged += new EventHandler(Control_TextChanged);
                _Bol_Boleano = true;
            }
        }

        void Control_TextChanged(object sender, EventArgs e)
        {
            if (_Dg_Grid.CurrentCell.ColumnIndex == 0)
            {
                _Mtd_MostrarToolTipsCell(((TextBox)sender).Text, ((TextBox)sender).Font);
            }
        }
        void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "'" | e.KeyChar.ToString() == "*" | e.KeyChar.ToString() == "=" | e.KeyChar.ToString() == "%")
            {
                e.Handled = true;
            }
            if (_Dg_Grid.CurrentCell.ColumnIndex == 7 | _Dg_Grid.CurrentCell.ColumnIndex == 8)
            {
                _Cls_Variosmetodos._Mtd_Valida_Numeros((TextBox)sender, e, 15, 2);
            }
        }
        private void _Dg_Grid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                _Mtd_ValidarFila();
            }
        }

        private void _Bt_Edit_1_Click(object sender, EventArgs e)
        {
            if (_Txt_Beneficiario.Enabled)
            { _Txt_Beneficiario.Enabled = false; }
            else
            { _Txt_Beneficiario.Enabled = true; _Txt_Beneficiario.Focus(); _Txt_Beneficiario.SelectionStart = _Txt_Beneficiario.Text.Length; }
        }

        private void _Bt_Edit_2_Click(object sender, EventArgs e)
        {
            if (_Txt_Concepto.Enabled)
            { _Txt_Concepto.Enabled = false; }
            else
            { _Txt_Concepto.Enabled = true; _Txt_Concepto.Focus(); _Txt_Concepto.SelectionStart = _Txt_Concepto.Text.Length; }
        }

        private void _Cb_TpoPagoOtros_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Bt_Beneficiario.Enabled = (_Cb_TpoPagoOtros.SelectedIndex == 4 | _Cb_TpoPagoOtros.SelectedIndex == 3 | _Cb_TpoPagoOtros.SelectedIndex == 11);
            _Bt_BuscarBeneficiario2.Enabled = !_Bt_Beneficiario.Enabled;
            _Bt_BuscarBeneficiario2.Visible=!_Bt_Beneficiario.Enabled;
            
            //comentado por #failzor
            //_Bt_Edit_3.Enabled = !_Bt_Beneficiario.Enabled;
            
            _Txt_Beneficiario.Text = "";
            _Txt_Rif.Text = "";
            _Txt_Beneficiario.Tag = "";
            _Txt_Concepto.Text = "";
            if (_Cb_TpoPagoOtros.SelectedIndex > 0)
            {
                _Bt_Edit_1.Enabled = true; _Bt_Edit_2.Enabled = true; _Bt_Edit_3.Enabled = true; _Txt_MontoPagar.Enabled = true; _Txt_MontoPagar.Text = ""; _Er_Error.Dispose();
                if (_Dg_Grid.CurrentCell != null)
                {
                    _Dg_Grid.Rows[0].Cells["Descripcion"].Value = _Cb_TpoPagoOtros.Text.ToUpper() + " " + _Txt_Beneficiario.Text.ToUpper();
                }
            }
            else
            {
                _Bt_Edit_1.Enabled = false; _Bt_Edit_2.Enabled = false; _Bt_Edit_3.Enabled = false; _Txt_MontoPagar.Enabled = false; _Txt_MontoPagar.Text = "";
                if (_Dg_Grid.CurrentCell != null)
                {
                    _Dg_Grid.Rows[0].Cells["Descripcion"].Value = "";
                }
            }
            if (_Bt_BuscarBeneficiario2.Enabled)
            {
                _Txt_Rif.Enabled = false;
                _Bt_Edit_1.Enabled = false;  
                _Bt_Edit_3.Enabled = false;                
            }
        }
        bool _Bol_DebitoBancarioHabilitado = false;
        double _Dbl_PorcentajeDebitoBancarioHabilitado = 0;
        string _Str_ProcesoContableDebitoBancarioHabilitado = "CXP_DEBITOBANC";
        private void _Mtd_DebitoBancarioCuentaBancaria()
        {
            //Programación de comprobante contable según debito bancario
            DataSet _Ds_DebitoBancario = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cdebitobancario,cporcentdebitobancario FROM TCONFIGCONSSA");
            if (_Ds_DebitoBancario.Tables[0].Rows.Count > 0)
            {
                if (_Ds_DebitoBancario.Tables[0].Rows[0]["cdebitobancario"].ToString() == "1")
                {
                    _Bol_DebitoBancarioHabilitado = true;
                }
                if (_Ds_DebitoBancario.Tables[0].Rows[0]["cporcentdebitobancario"].ToString() != "")
                {
                    _Dbl_PorcentajeDebitoBancarioHabilitado = Convert.ToDouble(_Ds_DebitoBancario.Tables[0].Rows[0]["cporcentdebitobancario"].ToString());
                }
            }
            //
        }
        private void _Cb_Cuenta_Otros_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_DebitoBancarioCuentaBancaria();
            if (_Cb_Cuenta_Otros.DataSource != null)
            {
                if (_Cb_Cuenta_Otros.SelectedIndex > 0)
                {
                    _Dg_Grid.Rows.Clear();
                    _Dg_Grid.Rows.Add();
                    _Dg_Grid.ReadOnly = true;
                    _Dg_Grid.Columns["cidauxiliarcont"].ReadOnly = true;
                    _Dg_Grid.Rows[0].Cells["Cuenta"].Value = _Mtd_BuscarCuenta(_Cb_Banco_Otros.SelectedValue, _Cb_Cuenta_Otros.SelectedValue);
                    if (_Bol_DebitoBancarioHabilitado)
                    {

                        string _Str_Sql = "select TPROCESOSCONTD.ccount,TPROCESOSCONTD.cnaturaleza from TPROCESOSCONTD where TPROCESOSCONTD.cidproceso='" + _Str_ProcesoContableDebitoBancarioHabilitado + "'";
                        DataSet _Ds_DebitoBancario = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        string _Str_CuentaContableDebitoBancarioComp = "";
                        string _Str_CuentaContableDebitoBancarioDescr = "";
                        foreach (DataRow _Dtw_Row in _Ds_DebitoBancario.Tables[0].Rows)
                        {
                            _Dg_Grid.Rows.Add();
                            if (_Dtw_Row["ccount"].ToString() == CLASES._Cls_Varios_Metodos._Str_G_CuentaContBanco)
                            {
                                string _Str_CuentaContableBanco = _Mtd_BuscarCuenta(_Cb_Banco_Otros.SelectedValue, _Cb_Cuenta_Otros.SelectedValue);
                                _Str_Sql = "SELECT cname FROM tcount WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_CuentaContableBanco + "'";
                                DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds_A.Tables[0].Rows.Count > 0)
                                {
                                    _Dg_Grid.Rows[2].Cells["Cuenta"].Value = _Mtd_BuscarCuenta(_Cb_Banco_Otros.SelectedValue, _Cb_Cuenta_Otros.SelectedValue);
                                    _Str_CuentaContableDebitoBancarioDescr = "CARGO IGTF.<REPLACEIGTFBANCO>" + _Ds_A.Tables[0].Rows[0]["cname"].ToString().Trim() + ".";
                                    _Dg_Grid.Rows[2].Cells["Descripcion"].Value = _Str_CuentaContableDebitoBancarioDescr;
                                }
                            }
                            else
                            {
                                _Str_Sql = "SELECT cname FROM tcount WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Dtw_Row["ccount"].ToString().Trim() + "'";
                                DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                if (_Ds_A.Tables[0].Rows.Count > 0)
                                {
                                    _Str_CuentaContableDebitoBancarioComp = _Dtw_Row["ccount"].ToString().Trim();
                                    _Str_CuentaContableDebitoBancarioDescr = "CARGO IGTF.<REPLACEIGTF>";
                                    _Dg_Grid.Rows[1].Cells["Cuenta"].Value = _Str_CuentaContableDebitoBancarioComp;
                                    _Dg_Grid.Rows[1].Cells["Descripcion"].Value = _Str_CuentaContableDebitoBancarioDescr;
                                }
                            }
                        }

                    }
                    _Cb_TpoPagoOtros.Enabled = true;
                    _Cb_TpoPagoOtros.Focus();
                    _Er_Error.Dispose();
                }
                else
                {
                    _Dg_Grid.Rows.Clear();
                    _Cb_TpoPagoOtros.SelectedIndex = 0;
                    _Cb_TpoPagoOtros.Enabled = false;
                }
            }
            else
            {
                _Dg_Grid.Rows.Clear();
                _Cb_TpoPagoOtros.SelectedIndex = 0;
                _Cb_TpoPagoOtros.Enabled = false;
            }
        }

        private void _Txt_Beneficiario_TextChanged(object sender, EventArgs e)
        {
            _Txt_Concepto.Text = Convert.ToString(_Cb_TpoPagoOtros.Text + " " + _Txt_Beneficiario.Text).ToUpper();
            if (_Dg_Grid.CurrentCell != null) { _Dg_Grid.Rows[0].Cells["Descripcion"].Value = _Cb_TpoPagoOtros.Text.ToUpper() + " " + _Txt_Beneficiario.Text.ToUpper(); }
            _Er_Error.Dispose();
            if (_Txt_Beneficiario.Text.Trim().Length == 0)
            { _Txt_MontoPagar.Text = ""; }
        }

        private void _Dg_Grid_Enter(object sender, EventArgs e)
        {
            if (_Txt_MontoPagar.Text.Trim().Length == 0)
            { _Txt_MontoPagar.Text = "0"; }
            if (Convert.ToDouble(_Txt_MontoPagar.Text) > 0 & _Txt_MontoPagar.Enabled)
            {
                _Dg_Grid.ReadOnly = false;
                _Dg_Grid.Columns["cidauxiliarcont"].ReadOnly = true;
                _Dg_Grid.Rows[0].Cells["Cuenta"].ReadOnly = true;
                _Dg_Grid.Rows[0].Cells["Haber"].ReadOnly = true;
                if (_Bol_DebitoBancarioHabilitado)
                {
                    _Dg_Grid.Rows[1].Cells["Cuenta"].ReadOnly = true;
                    _Dg_Grid.Rows[1].Cells["Haber"].ReadOnly = true;
                    _Dg_Grid.Rows[1].Cells["Debe"].ReadOnly = true;
                    _Dg_Grid.Rows[2].Cells["Cuenta"].ReadOnly = true;
                    _Dg_Grid.Rows[2].Cells["Haber"].ReadOnly = true;
                    _Dg_Grid.Rows[2].Cells["Debe"].ReadOnly = true;
                }
            }
            else
            { _Dg_Grid.ReadOnly = true; _Dg_Grid.Columns["cidauxiliarcont"].ReadOnly = true; }
        }

        private void _Txt_MontoPagar_Enter(object sender, EventArgs e)
        {
            if (_Txt_Beneficiario.Text.Trim().Length > 0 & _Txt_Concepto.Text.Trim().Length > 0)
            { _Txt_MontoPagar.ReadOnly = false; }
            else
            { _Txt_MontoPagar.ReadOnly = true; }
        }

        private void _Txt_Concepto_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Txt_Concepto.Text.Trim().Length == 0)
            { _Txt_MontoPagar.Text = ""; }
        }

        private void _Txt_MontoPagar_TextChanged(object sender, EventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                _Dg_Grid.Rows[0].Cells["Haber"].Value = _Txt_MontoPagar.Text;
                if (_Bol_DebitoBancarioHabilitado)
                {
                    if (_Txt_MontoPagar.Text != "")
                    {
                        if (Convert.ToDouble(_Txt_MontoPagar.Text) > 0)
                        {
                            double _Dbl_MontoDebitoBancario = 0;
                            _Dbl_MontoDebitoBancario = Convert.ToDouble(_Txt_MontoPagar.Text) * _Dbl_PorcentajeDebitoBancarioHabilitado / 100;
                            _Dg_Grid.Rows[1].Cells["Debe"].Value = _Dbl_MontoDebitoBancario;
                            _Dg_Grid.Rows[2].Cells["Haber"].Value = _Dbl_MontoDebitoBancario;
                        }
                        else
                        {
                            _Dg_Grid.Rows[1].Cells["Debe"].Value = "0";
                            _Dg_Grid.Rows[2].Cells["Haber"].Value = "0";
                        }
                    }
                }
            }
        }
        private bool _Mtd_NoProcesada(string _P_Str_OrdenPago)
        {
            string _Str_Cadena = "SELECT cidordpago FROM TPAGOSCXPM WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _P_Str_OrdenPago + "' AND canulado=0 and ccancelado=0 AND cidemisioncheq=0";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Bt_Pagar_Otros_Click(object sender, EventArgs e)
        {
            if (_Mtd_NoProcesada(_Txt_OrdenPago.Text.Trim()))
            {
                string _Str_MyComprob = "";
                string _Str_TpoPago = "";
                Frm_EmisionCheque _Frm_EmisionCheque = new Frm_EmisionCheque("1", _Txt_Concepto.Text, this);
                _Frm_EmisionCheque.MdiParent = this.MdiParent;
                _Frm_EmisionCheque.Dock = DockStyle.Fill;
                _Frm_EmisionCheque.Show();
                _Frm_EmisionCheque._Mtd_Nuevo();
                _Frm_EmisionCheque._Txt_OrdPagoId.Text = _Txt_OrdenPago.Text;
                _Frm_EmisionCheque._Txt_RifCedula.Text = _Txt_Rif.Text;
                _Frm_EmisionCheque._Dt_Fecha.MinDate = Convert.ToDateTime(_Txt_FechaOP.Text);
                _Frm_EmisionCheque._Dt_Fecha.Value = Convert.ToDateTime(_Txt_FechaOP.Text);
                _Frm_EmisionCheque._Cb_Banco.SelectedValue = _Cb_Banco_Otros.SelectedValue;
                _Frm_EmisionCheque._Cb_Cuenta.SelectedValue = _Cb_Cuenta_Otros.SelectedValue;
                if (_Rb_Abo.Checked)
                { _Str_TpoPago = "ABO"; }
                else
                { _Str_TpoPago = "PTOT"; }
                _Frm_EmisionCheque._Cb_TpoPago.SelectedValue = _Str_TpoPago;
                if (_Mtd_OrdenReposicion(Convert.ToInt32(_Txt_OrdenPago.Text)))
                { _Frm_EmisionCheque._Cb_FormaPago.SelectedValue = _Mtd_FormaPagoReposicion(Convert.ToInt32(_Txt_OrdenPago.Text)); }
                else
                { _Frm_EmisionCheque._Cb_FormaPago.SelectedValue = _Rb_ChequeO.Checked ? "CHEQ" : "TRANSF"; }
                string _Str_Cadena = "";
                DataSet _Ds;
                if (_Cb_TpoPagoOtros.SelectedIndex == 4)
                { _Frm_EmisionCheque._Txt_Persona.Tag = Convert.ToString(_Txt_Beneficiario.Tag); }
                else
                { _Frm_EmisionCheque._Txt_Persona.Tag = 0; }
                _Frm_EmisionCheque._Txt_Persona.Text = _Txt_Beneficiario.Text.ToUpper();
                _Str_Cadena = "SELECT cidcomprob FROM TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Txt_OrdenPago.Text + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_MyComprob = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                }
                _Frm_EmisionCheque._Txt_ComprobId.Text = _Str_MyComprob;
                _Frm_EmisionCheque._Mtd_CargarComprobante(_Str_MyComprob);
                _Frm_EmisionCheque._Txt_Monto.Text = _Txt_MontoPagar.Text;
                _Frm_EmisionCheque._Txt_CantDescrip.Text = _obj_NumerosaLetras.Numero2Letra(_Txt_MontoPagar.Text.Replace(".", ""), 0, 2, "", "Céntimo", LibNumLetras.clsNumerosaLetras.eSexo.Masculino, LibNumLetras.clsNumerosaLetras.eSexo.Masculino).ToUpper();
                _Frm_EmisionCheque._Cb_Banco.Enabled = false;
                _Frm_EmisionCheque._Cb_Cuenta.Enabled = false;
                _Frm_EmisionCheque._Cb_TpoPago.Enabled = false;
                _Frm_EmisionCheque._Cb_FormaPago.Enabled = false;
                _Frm_EmisionCheque._Txt_FirmaSol.Tag = Frm_Padre._Str_Use;
                _Str_Cadena = "SELECT cname FROM TUSER WHERE cuser='" + Frm_Padre._Str_Use + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Frm_EmisionCheque._Txt_FirmaSol.Text = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                }
                _Frm_EmisionCheque._Txt_Concepto.Focus();
                //--------------
                _Mtd_DeshabilitarTodo();
                _Mtd_Actualizar();
                _Tb_Tab.SelectedIndex = 0;
                this.Close();
            }
            else
            {
                MessageBox.Show("Esta orden de pago ya fué procesada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                _Mtd_DeshabilitarTodo();
                _Mtd_Actualizar();
                _Tb_Tab.SelectedIndex = 0;
            }
            //--------------
        }

        private void _Pnl_Clave_Otros_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave_Otros.Visible)
            {
                _Tb_Tab.Enabled = false;
                _Txt_Clave_Otros.Text = "";
                _Txt_Clave_Otros.Focus();
                //--------------------------
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                //--------------------------
            }
            else
            {
                _Tb_Tab.Enabled = true;
                _Mtd_Activated();
            }
        }

        private void _Bt_Aceptar_Otros_Click(object sender, EventArgs e)
        {
            if (_Cls_Variosmetodos._Mtd_VerificarClaveUsuario(_Txt_Clave_Otros.Text.Trim()))
            {
                int _Int_Comprobante = _Mtd_ActualizarComprobanteOtros();
                _Mtd_ActualizarPagosOtros(_Int_Comprobante);
                _Pnl_Clave_Otros.Visible = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                MessageBox.Show("La operación ha sido realizadad correctamente. Comprobante: " + _Mtd_RetornarID_Correl(_Int_Comprobante.ToString()), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_DeshabilitarTodo();
                _Mtd_Actualizar();
                _Tb_Tab.SelectedIndex = 0;
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }

        }
        private string _Mtd_RetornarID_Correl(string _P_Str_Comprobante)
        {
            string _Str_Cadena = "SELECT cidcorrel FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "0";
        }
        private void _Bt_Cancelar_Otros_Click(object sender, EventArgs e)
        {
            _Pnl_Clave_Otros.Visible = false;
        }

        private void _Rb_Todos_CheckedChanged(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
        }

        private void _Rb_Regular_CheckedChanged(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
        }

        private void _Rb_Otros_CheckedChanged(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
        }

        private void _Rb_Abo_CheckedChanged(object sender, EventArgs e)
        {
            if (_Txt_MontoPagar.Text.Trim().Length > 0)
            {
                if (Convert.ToDouble(_Txt_MontoPagar.Text) > 0)
                { _Dg_Grid.Focus(); }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                _Dg_Grid.Rows.RemoveAt(_Dg_Grid.CurrentCell.RowIndex);
                if (_Dg_Grid.RowCount == 0)
                {
                    _Dg_Grid.Rows.Add();
                }
                _Mtd_CalcularTotales();
            }
        }

        private void _Ctrl_Contex_Opening(object sender, CancelEventArgs e)
        {
            if (!((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled | _Dg_Grid.CurrentCell.RowIndex <= 2)
            { e.Cancel = true; }
            else
            { _Tool_Crear.Enabled = _Mtd_Auxiliar(_Mtd_Cuenta(_Dg_Grid.CurrentCell.RowIndex)); }
        }

        public void _Mtd_GuardarComprobante()
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            double _Dbl_DebeTot = 0;
            double _Dbl_HaberTot = 0;
            double _Dbl_Balance = 0;
            string _Str_corder = "";
            string _Str_Sql = "";
            string[] _Str_FechaDocument = new string[2];
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia("DELETE FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Form_cidcomprob + "'");
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Str_Form_cidcomprob);
            //MODIFICO EL COMPROBANTE
            foreach (DataGridViewRow _DgRow in _Dg_Comprobante.Rows)
            {

                if (Convert.ToString(_DgRow.Cells[0].Value).Trim() != "T")
                {
                    if (Convert.ToString(_DgRow.Cells[4].Value).Trim() == "")
                    { _Dbl_Debe = 0; }
                    else
                    { _Dbl_Debe = Convert.ToDouble(_DgRow.Cells[4].Value); }

                    if (Convert.ToString(_DgRow.Cells[5].Value).Trim() == "")
                    { _Dbl_Haber = 0; }
                    else
                    { _Dbl_Haber = Convert.ToDouble(_DgRow.Cells[5].Value); }
                    _Str_FechaDocument = _Mtd_FechaDocumento(Convert.ToString(_DgRow.Cells["_Col_Tipo_Doc"].Value).Trim(), Convert.ToString(_DgRow.Cells["_Col_Documento"].Value).Trim(), Convert.ToString(_Txt_Prov.Tag).Trim());
                    _Str_corder = Convert.ToString(myUtilidad._Mtd_Consecutivo_TCOMPROBAND(_Str_Form_cidcomprob));
                    _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,ctothaber,cdateadd,cuseradd,cdescrip) values ('";
                    _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_Form_cidcomprob + "','" + _Str_corder + "','" + Convert.ToString(_DgRow.Cells[1].Value).Trim() + "','" + Convert.ToString(_DgRow.Cells["_Col_Tipo_Doc"].Value).Trim() + "','" + Convert.ToString(_DgRow.Cells["_Col_Documento"].Value).Trim() + "','" + _Str_FechaDocument[0] + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + Convert.ToString(_DgRow.Cells[3].Value).Trim().ToUpper().Replace("'", "''") + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    if (_DgRow.Cells["_Col_Documento"].Value != null)
                    {
                        if (_Dbl_Debe > 0)
                        { CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_Form_cidcomprob, Convert.ToString(_DgRow.Cells[1].Value).Trim(), Convert.ToString(_Txt_Prov.Tag).Trim(), Convert.ToString(_DgRow.Cells[3].Value).Trim().ToUpper(), Convert.ToString(_DgRow.Cells["_Col_Tipo_Doc"].Value).Trim(), Convert.ToString(_DgRow.Cells["_Col_Documento"].Value).Trim(), _Str_FechaDocument[0], _Str_FechaDocument[1], CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe), Clases._Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()), Clases._Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()), "D"); }//Aux
                        else
                        { CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Str_Form_cidcomprob, Convert.ToString(_DgRow.Cells[1].Value).Trim(), Convert.ToString(_Txt_Prov.Tag).Trim(), Convert.ToString(_DgRow.Cells[3].Value).Trim().ToUpper(), Convert.ToString(_DgRow.Cells["_Col_Tipo_Doc"].Value).Trim(), Convert.ToString(_DgRow.Cells["_Col_Documento"].Value).Trim(), _Str_FechaDocument[0], _Str_FechaDocument[1], CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber), Clases._Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()), Clases._Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()), "H"); }//Aux
                    }
                    _Dbl_DebeTot = _Dbl_DebeTot + _Dbl_Debe;
                    _Dbl_HaberTot = _Dbl_HaberTot + _Dbl_Haber;
                }
            }
            //Insertar auxiliares de los anticipos
            string _Str_Cadena = "INSERT INTO TCOMPROBANDD (ccompany,cidcomprob,ccount,cidtipoauxiliar,cidauxiliarcont,cdescrip,ctdocument,cnumdocu,cfechaemision,cfechavencimiento,cdebe,chaber,cmontacco,cyearacco,cstatus,cclasificauxiliar) SELECT TCOMPROBANDD.ccompany,'" + _Str_Form_cidcomprob + "',TCOMPROBANDD.ccount,TCOMPROBANDD.cidtipoauxiliar,TCOMPROBANDD.cidauxiliarcont,RTRIM(TCOMPROBANDD.cdescrip),TCOMPROBANDD.ctdocument,TCOMPROBANDD.cnumdocu,TCOMPROBANDD.cfechaemision,TCOMPROBANDD.cfechavencimiento,TCOMPROBANDD.chaber,TCOMPROBANDD.cdebe,'" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Month + "','" + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Year + "','0',TCOMPROBANDD.cclasificauxiliar FROM TPAGOSCXPANT INNER JOIN " +
                      "TPAGOSCXPM ON TPAGOSCXPANT.cgroupcomp = TPAGOSCXPM.cgroupcomp AND TPAGOSCXPANT.ccompany = TPAGOSCXPM.ccompany AND  " +
                      "TPAGOSCXPANT.cidordpagoant = TPAGOSCXPM.cidordpago INNER JOIN " +
                      "TCOMPROBANDD ON TPAGOSCXPM.ccompany = TCOMPROBANDD.ccompany AND " +
                      "TPAGOSCXPM.cidcomprob = TCOMPROBANDD.cidcomprob " +
                      "WHERE TPAGOSCXPANT.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TPAGOSCXPANT.ccompany='" + Frm_Padre._Str_Comp + "' AND TPAGOSCXPANT.cidordpago = '" + _Txt_Transaccion.Text.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            //------------------------------------
            _Dbl_Balance = Math.Round(_Dbl_DebeTot, 2) - Math.Round(_Dbl_HaberTot, 2);
            _Str_Sql = "UPDATE TCOMPROBANC SET ctotdebe=" + _Dbl_DebeTot.ToString().Replace(",", ".") + ",ctothaber=" + _Dbl_HaberTot.ToString().Replace(",", ".") + ",cbalance=" + _Dbl_Balance.ToString().Replace(",", ".") + " where ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob=" + _Str_Form_cidcomprob;
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
        }
        public void _Mtd_MontoOrdenPago()
        {
            string _Str_Cadena = "SELECT ISNULL(SUM(cmontototal),0) FROM TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Txt_Transaccion.Text.Trim() + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Total.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString().Trim()).ToString("#,##0.00");
            }
        }
        private void _Bt_Anticipos_Click(object sender, EventArgs e)
        {
            string _Str_Cadena = "";
            if (Convert.ToString(_Txt_Prov.Tag).Trim().Length > 0)
            { _Str_Cadena = "SELECT VST_CHEQUES_EMITIDOS.cidordpago FROM VST_CHEQUES_EMITIDOS LEFT OUTER JOIN TPROVEEDOR ON VST_CHEQUES_EMITIDOS.cproveedor = TPROVEEDOR.cproveedor AND (VST_CHEQUES_EMITIDOS.ccompany = TPROVEEDOR.ccompany OR TPROVEEDOR.cglobal = '1') WHERE (VST_CHEQUES_EMITIDOS.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (VST_CHEQUES_EMITIDOS.ccompany = '" + Frm_Padre._Str_Comp + "') AND (VST_CHEQUES_EMITIDOS.cproveedor='" + Convert.ToString(_Txt_Prov.Tag).Trim() + "' OR LEN(LTRIM(RTRIM(VST_CHEQUES_EMITIDOS.cproveedor))) = 0) AND (VST_CHEQUES_EMITIDOS.cimpimiocheq = '1') AND (VST_CHEQUES_EMITIDOS.canulado = '0') AND (VST_CHEQUES_EMITIDOS.antidescontado = '0' OR VST_CHEQUES_EMITIDOS.antidescontado IS NULL) AND (VST_CHEQUES_EMITIDOS.cotrospago = '1') AND (VST_CHEQUES_EMITIDOS.ctipotrospago = '3')"; }
            else
            { _Str_Cadena = "SELECT VST_CHEQUES_EMITIDOS.cidordpago FROM VST_CHEQUES_EMITIDOS LEFT OUTER JOIN TPROVEEDOR ON VST_CHEQUES_EMITIDOS.cproveedor = TPROVEEDOR.cproveedor AND (VST_CHEQUES_EMITIDOS.ccompany = TPROVEEDOR.ccompany OR TPROVEEDOR.cglobal = '1') WHERE (VST_CHEQUES_EMITIDOS.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (VST_CHEQUES_EMITIDOS.ccompany = '" + Frm_Padre._Str_Comp + "') AND (VST_CHEQUES_EMITIDOS.cimpimiocheq = '1') AND (VST_CHEQUES_EMITIDOS.canulado = '0') AND (VST_CHEQUES_EMITIDOS.antidescontado = '0' OR VST_CHEQUES_EMITIDOS.antidescontado IS NULL) AND (VST_CHEQUES_EMITIDOS.cotrospago = '1') AND (VST_CHEQUES_EMITIDOS.ctipotrospago = '3')"; }
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
            {
                Frm_Anticipos _Frm = new Frm_Anticipos(this, _Txt_Transaccion.Text.Trim(), Convert.ToString(_Txt_Prov.Tag).Trim());
                _Frm.ShowDialog(this);
                if (_Mtd_CerrarOrden(_Txt_Transaccion.Text.Trim()))
                {
                    _Bt_Cerrar.Enabled = true;
                    _Bt_Pagar.Enabled = false;
                }
                else
                {
                    _Bt_Cerrar.Enabled = false;
                    _Bt_Pagar.Enabled = _Cls_Variosmetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_Variosmetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_CHEQUE_SOL");
                }
            }
            else
            { MessageBox.Show("No existen anticipos para la orden de pago seleccionada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Bt_Cerrar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave_Cerrar.Visible = true;
        }

        private void _Pnl_Clave_Cerrar_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave_Cerrar.Visible)
            { _Tb_Tab.Enabled = false; _Txt_Clave_Cierre.Text = ""; _Txt_Clave_Cierre.Focus(); ((Frm_Padre)Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_editar2.Enabled = false; }
            else
            { _Tb_Tab.Enabled = true; ((Frm_Padre)Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_editar2.Enabled = true; }
        }

        private void _Bt_CancelarCerrar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave_Cerrar.Visible = false;
        }
        private void _Mtd_SaldarDocumentos(string _P_Str_OrdenPago)
        {
            string _Str_Cadena = "SELECT ctipodocument,cnumdocu FROM TPAGOSCXPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _P_Str_OrdenPago + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_Cadena = "UPDATE TFACTPPAGARM SET csaldo=0,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag).Trim() + "' AND ctipodocument='" + _Row["ctipodocument"].ToString() + "' AND cnumdocu='" + _Row["cnumdocu"].ToString() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "UPDATE TMOVCXPM SET csaldo=0 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag).Trim() + "' AND ctipodocument='" + _Row["ctipodocument"].ToString() + "' AND cnumdocu='" + _Row["cnumdocu"].ToString() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
        }
        private void _Mtd_Update_DetalleAnticipo()
        {
            string _Str_Cadena = "SELECT cidordpagoant FROM TPAGOSCXPANT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Txt_Transaccion.Text.Trim() + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_Cadena = "UPDATE TPAGOSCXPM SET cidordpagodesc='" + _Txt_Transaccion.Text.Trim() + "',antidescontado='1' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Row[0].ToString().Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            }
        }
        private void _Bt_AceptarCerrar_Click(object sender, EventArgs e)
        {
            if (_Cls_Variosmetodos._Mtd_VerificarClaveUsuario(_Txt_Clave_Cierre.Text.Trim()))
            {
                _Pnl_Clave_Cerrar.Visible = false;
                _Mtd_SaldarDocumentos(_Txt_Transaccion.Text.Trim());
                _Mtd_Update_DetalleAnticipo();
                string _Str_Cadena = "UPDATE TPAGOSCXPM SET ccancelado='1' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Txt_Transaccion.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                myUtilidad._Mtd_GenerarNCxDescxPPago(_Txt_Transaccion.Text.Trim());
                _Str_Cadena = "SELECT cidcomprob FROM TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Txt_Transaccion.Text.Trim() + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='9' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Ds.Tables[0].Rows[0][0].ToString().Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                this.Close();
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave_Cierre.Focus(); _Txt_Clave_Cierre.Select(0, _Txt_Clave_Cierre.Text.Length); }
        }

        private void _Dg_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_Dg_Info2.Visible = true;
            }
            else
            {
                _Lbl_Dg_Info2.Visible = false;
            }
        }

        private void _Dg_Grid_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (_Dg_Grid.CurrentCell.RowIndex != -1)
                {
                    _Mtd_MostrarToolTipsCell(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["Cuenta"].Value).Trim(), _Txt_Clave.Font);
                }
            }
            catch { }
        }

        private void _Bt_Edit_3_Click(object sender, EventArgs e)
        {
            if (_Txt_Rif.Enabled)
            { _Txt_Rif.Enabled = false; _Pnl_TipoRifCed.Enabled = false; }
            else
            { _Txt_Rif.Enabled = true; _Pnl_TipoRifCed.Enabled = true; _Txt_Rif.Focus(); }
        }

        private void _Rbt_Cedula_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Cedula.Checked)
            {
                _Txt_Rif.Mask = "L-00000000";
            }
        }

        private void _Rbt_Rif_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Rif.Checked)
            {
                _Txt_Rif.Mask = "L-00000000-0";
            }
        }

        private void _Bt_BuscarBeneficiario2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            bool _Bol_TodosBeneficiarios = false;

            if(_Cb_TpoPagoOtros.SelectedValue.ToString()=="13")
            {
                _Bol_TodosBeneficiarios = true;
            }

            Frm_BeneficiarioBusqueda _Frm = new Frm_BeneficiarioBusqueda(_Txt_Rif, _Txt_Beneficiario, _Rbt_Rif, _Rbt_Cedula, _Bol_TodosBeneficiarios);

            _Txt_Beneficiario.Enabled = false;
            _Txt_Rif.Enabled = false;
            _Bt_Edit_3.Enabled = false;
            _Bt_Edit_1.Enabled = false;
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
        }
        private int _Mtd_TipoEntidad(DataGridViewRow _Dg_Row)
        {
            string _Str_Cadena = "SELECT cclasificauxiliar FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Mtd_Cuenta(_Dg_Row.Index) + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "1")
            {
                return 0;
            }
            else if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "2" | _Ds.Tables[0].Rows[0][0].ToString().Trim() == "3" | _Ds.Tables[0].Rows[0][0].ToString().Trim() == "4")
            {
                return 1;
            }
            else if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == "5")
            {
                return 2;
            }
            return -1;
        }
        private void _Tool_Crear_Click(object sender, EventArgs e)
        {
            int _Int_TipoEntidad = _Mtd_TipoEntidad(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex]);
            Frm_ComprobanteContableDocVar _Frm = new Frm_ComprobanteContableDocVar(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex], _Int_TipoEntidad);
            _Frm.ShowDialog();
        }
    }
}
