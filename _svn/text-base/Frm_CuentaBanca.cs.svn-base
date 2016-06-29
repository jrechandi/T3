using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_CuentaBanca : Form
    {
        private TextBox _Txt_CodCtaContable = new TextBox();

        /// <summary>
        /// Actualiza el TextBox de cuenta contable.
        /// </summary>
        /// <param name="_P_Str_Cta">Código de la cuenta.</param>
        private void _Mtd_ActualizarCuentaContable(string _P_Str_Cta)
        {
            string _Str_SQL;

            _Str_SQL = "SELECT ccount, cname + '-' + ccount as cname";
            _Str_SQL += " FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            _Str_SQL += " AND cdelete = '0'";
            _Str_SQL += " AND ctcount = 'D'";
            _Str_SQL += " AND ccount = '" + _P_Str_Cta + "'";

            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (_Ds.Tables.Count > 0)
            {
                _Txt_CtaContable.Text = _Ds.Tables[0].Rows[0]["cname"].ToString();
            }
        }

        public Frm_CuentaBanca()
        {
            InitializeComponent();
        }
        Form _Frm_Banco;
        public Frm_CuentaBanca(string _Pr_Str_Banco, string _Pr_Str_Cuenta,Frm_Banco _P_Frm_Banco)
        {
            InitializeComponent();
            _Str_FrmBancoId = _Pr_Str_Banco;
            _Str_FrmCuenta = _Pr_Str_Cuenta;
            _Frm_Banco = _P_Frm_Banco;
        }

        string _Str_FrmBancoId = "";
        string _Str_FrmCuenta = "";
        string _Str_MyProceso = "";
        public bool _Bol_FrmSwBlock = false;
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);

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

        private void _Mtd_CargarData(string _Pr_Str_Banco, string _Pr_Str_Cuenta)
        {
            _Cmb_Banco.SelectedValue = _Pr_Str_Banco;
            string _Str_Cadena = "Select cnumcuenta,cname,cdate,cbanco,csucur,cphone1,cphone2,cinfocont1,cinfocont2,ccount,csaldoactuconci,csaldoini,csaldoactual,cactivo,cproxnumcheq,cfechaconci from TCUENTBANC where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' and cbanco='" + _Pr_Str_Banco + "'";
            if (_Pr_Str_Cuenta != "")
            {
                _Str_Cadena = _Str_Cadena +  "and cnumcuenta='" + _Pr_Str_Cuenta + "'";
            }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                if (_Row["cbanco"] != System.DBNull.Value)
                { _Cmb_Banco.SelectedValue = _Row["cbanco"].ToString().Trim(); }
                _Txt_Cuenta.Text = _Row["cnumcuenta"].ToString().Trim();
                _Txt_Descripcion.Text = _Row["cname"].ToString().Trim().ToUpper();
                _Txt_Gerente.Text = _Row["cinfocont1"].ToString().Trim().ToUpper();
                _Txt_Sucursal.Text = _Row["csucur"].ToString().Trim().ToUpper();
                _Txt_Ejecutivo.Text = _Row["cinfocont2"].ToString().Trim().ToUpper();
                _Txt_Total.Text = _Row["csaldoactual"].ToString().Trim().ToUpper();
                _Txt_Telefono.Text = _Row["cphone1"].ToString().Trim().ToUpper();
                _Txt_Fax.Text = _Row["cphone2"].ToString().Trim().ToUpper();
                _Txt_Inicial.Text = _Row["csaldoini"].ToString().Trim().ToUpper();
                _Txt_Fecha.Text = _Row["cfechaconci"].ToString().Trim().ToUpper();
                _Txt_Numero.Text = _Row["cproxnumcheq"].ToString().Trim().ToUpper();
                _Txt_Conciliacion.Text = _Row["csaldoactuconci"].ToString().Trim().ToUpper();
                if (_Row["cactivo"] != System.DBNull.Value)
                { _Chbox_Activo.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["cactivo"].ToString().Trim())); }
                
                if (_Row["ccount"] != System.DBNull.Value)
                {
                    _Txt_CodCtaContable.Text = _Row["ccount"].ToString().Trim();
                    _Mtd_ActualizarCuentaContable(_Txt_CodCtaContable.Text.Trim());
                }
            }
        }

        private void Frm_CuentaBanca_Load(object sender, EventArgs e)
        {
            _Mtd_Ini();
            if (_Str_FrmCuenta != "")
            {
                _Mtd_CargarData(_Str_FrmBancoId, _Str_FrmCuenta);
            }
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            _Mtd_Color_Estandar(this);
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        public void _Mtd_Ini()
        {
            _Str_MyProceso = "";
            if (_Cmb_Banco.DataSource != null)
            { _Cmb_Banco.SelectedIndex = 0; }
            _Txt_Cuenta.Text = "";
            _Txt_Gerente.Text = "";
            _Txt_Sucursal.Text = "";
            _Txt_Ejecutivo.Text = "";
            _Txt_Total.Text = "";
            _Txt_Telefono.Text = "";
            _Txt_Inicial.Text = "";
            _Txt_Fecha.Text = "";
            _Txt_Numero.Text = "";
            _Txt_Fax.Text = "";
            _Txt_Conciliacion.Text = "";
            _Dtp_Apertura.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Chbox_Activo.Checked = true;
            _Txt_CodCtaContable.Text = "";
            _Txt_CtaContable.Text = "";
            _Mtd_Cargar_Banco();
            //_Mtd_Cargar_Cuenta();
            _Txt_Descripcion.Text = "";
            _Mtd_Deshabilitar_Todo();
            _Er_Error.Dispose();
            //_Txt_Cuenta.Enabled = true;
            //_Txt_Inicial.Enabled = true;
            //_Dtp_Apertura.Enabled = true;
        }
        public void _Mtd_Habilitar()
        {
            _Cmb_Banco.Enabled = false;
            _Txt_Cuenta.Enabled = false;
            _Dtp_Apertura.Enabled = false;
            _Txt_Inicial.Enabled = false;
            _Txt_Gerente.Enabled = true;
            _Txt_Sucursal.Enabled = true;
            _Txt_Ejecutivo.Enabled = true;
            _Txt_Total.Enabled = false;
            _Txt_Fax.Enabled = true;
            _Txt_Telefono.Enabled = true;
            _Txt_Numero.Enabled = false;
            _Txt_Conciliacion.Enabled = false;
            _Chbox_Activo.Enabled = true;
            _Str_MyProceso = "M";
            _Bt_Cuenta.Enabled = true;
        }
        private void _Mtd_Deshabilitar_Todo()
        {
            _Cmb_Banco.Enabled = false;
            _Txt_Cuenta.Enabled = false;
            _Txt_Descripcion.ReadOnly = true;
            _Txt_Gerente.Enabled = false;
            _Txt_Sucursal.Enabled = false;
            _Txt_Ejecutivo.Enabled = false;
            _Txt_Total.Enabled = false;
            _Txt_Telefono.Enabled = false;
            _Txt_Inicial.Enabled = false;
            _Txt_Fecha.Enabled = false;
            _Txt_Fax.Enabled = false;
            _Txt_Numero.Enabled = false;
            _Txt_Conciliacion.Enabled = false;
            _Chbox_Activo.Enabled = false;
            _Dtp_Apertura.Enabled = false;
            _Bt_Cuenta.Enabled = false;
        }
        private void _Mtd_Cargar_Banco()
        {
           //_Cmb_Banco.DataSource = null;
           // DataSet _Ds;
           // DataRow _Row;
           // //--------------------------------------
           // _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cbanco,cname FROM TBANCO where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0'");
           // _Row = _Ds.Tables[0].NewRow();
           // _Row["cname"] = "...";
           // _Row["cbanco"] = "0";
           // _Ds.Tables[0].Rows.Add(_Row);
           // _Cmb_Banco.DataSource = _Ds.Tables[0];
           // _Cmb_Banco.DisplayMember = "cname";
           // _Cmb_Banco.ValueMember = "cbanco";
           // _Cmb_Banco.SelectedValue = "0";

            myUtilidad._Mtd_CargarCombo(_Cmb_Banco, "SELECT LTRIM(RTRIM(CONVERT(VARCHAR,cbanco))),cname FROM TBANCO where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0'");
        }

        //private void _Mtd_Cargar_Cuenta()
        //{
            //_Cmb_Contable.DataSource = null;
            //DataSet _Ds;
            //DataRow _Row;
            ////--------------------------------------
            //_Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ccount,cname+'-'+ccount as cname FROM TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0'  ORDER BY cname ASC");
            //_Row = _Ds.Tables[0].NewRow();
            //_Row["cname"] = "...";
            //_Row["ccount"] = "0";
            //_Ds.Tables[0].Rows.Add(_Row);
            //_Cmb_Contable.DataSource = _Ds.Tables[0];
            //_Cmb_Contable.DisplayMember = "cname";
            //_Cmb_Contable.ValueMember = "ccount";
            //_Cmb_Contable.SelectedValue = "0";
            //myUtilidad._Mtd_CargarCombo(_Cmb_Contable, "SELECT ccount,cname+'-'+ccount as cname FROM TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' AND ctcount='D' ORDER BY cname ASC");
        //}

        public void _Mtd_Nuevo()
        {
            _Er_Error.Dispose();
            _Mtd_Ini();
            _Mtd_Habilitar();
            _Dtp_Apertura.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Txt_Cuenta.Enabled = true;
            _Chbox_Activo.Enabled = true;
            _Dtp_Apertura.Enabled = true;
            _Txt_Inicial.Enabled = true;
            _Txt_Numero.Enabled = true;
            _Str_MyProceso = "A";
            _Cmb_Banco.SelectedValue = _Str_FrmBancoId.Trim();
            _Txt_Cuenta.Focus();
        }

        private void _Cmb_Banco_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Banco();
        }

        private void Frm_CuentaBanca_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Txt_TpoFind.Text = "PA";
            CONTROLES._Ctrl_Buscar._Er_Control_Error = _Er_Error;
            //CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            //____________________________________________
            //if (!_Txt_Telefono.Enabled & _Txt_Telefono.Text.Trim().Length > 0)
            //{
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
            //}
            //else if (!_Txt_Cuenta.Enabled & _Txt_Cuenta.Text.Trim().Length > 0 & _Txt_Telefono.Enabled)
            //{
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            //    CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
            //}
            //else if (_Txt_Cuenta.Enabled)
            //{
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            //    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            //}
            _Mtd_BotonesMenu();
            //_____________________________________________
        }

        private void Frm_CuentaBanca_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
            ((Frm_Banco)_Frm_Banco)._Mtd_ActivarBotones(true);
        }
        public bool _Mtd_Guardar()
        {
            if (_Cmb_Banco.SelectedIndex > 0 & _Txt_Cuenta.Text.Trim().Length > 0 & _Txt_Descripcion.Text.Trim().Length > 0 & _Txt_Sucursal.Text.Trim().Length > 0 & _Txt_Gerente.Text.Trim().Length > 0 & _Txt_Ejecutivo.Text.Trim().Length > 0 & _Txt_Telefono.Text.Trim().Length > 0 & _Txt_Inicial.Text.Trim().Length > 0 & _Txt_Numero.Text.Trim().Length > 0 & _Txt_CodCtaContable.Text != "")
            {
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TCUENTBANC where cnumcuenta='" + _Txt_Cuenta.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "'"))
                {
                    MessageBox.Show("El registro ya existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    string _Str_Cadena = "insert into TCUENTBANC (ccompany,cnumcuenta,cname,cdate,cbanco,csucur,cphone1,cphone2,cinfocont1,cinfocont2,ccount,csaldoactuconci,csaldoini,csaldoactual,cactivo,cproxnumcheq,cdateadd,cuseradd,cdelete) values('" + Frm_Padre._Str_Comp + "','" + _Txt_Cuenta.Text.Trim() + "','" + _Txt_Descripcion.Text.Trim().ToUpper() + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Apertura.Value) + "','" + _Cmb_Banco.SelectedValue.ToString() + "','" + _Txt_Sucursal.Text.Trim().ToUpper() + "','" + _Txt_Telefono.Text.Trim() + "','" + _Txt_Fax.Text.Trim() + "','" + _Txt_Gerente.Text.Trim().ToUpper() + "','" + _Txt_Ejecutivo.Text.Trim().ToUpper() + "','" + _Txt_CodCtaContable.Text.Trim().ToUpper() + "','" + _Txt_Conciliacion.Text.Trim() + "','" + _Txt_Inicial.Text.Trim() + "','" + _Txt_Total.Text.Trim() + "','" + Convert.ToInt32(_Chbox_Activo.Checked).ToString() + "','" + _Txt_Numero.Text.Trim() + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    MessageBox.Show("El registro fue agregado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ((Frm_Banco)_Frm_Banco)._Mtd_CargarCuentas();
                    _Mtd_Ini();
                    _Mtd_Deshabilitar_Todo();
                    _Er_Error.Dispose();
                    
                    Close();

                    return true;
                }
            }
            else
            {
                if (_Cmb_Banco.SelectedIndex<=0) { _Er_Error.SetError(_Cmb_Banco, "Información requerida!!!"); }
                if (_Txt_CodCtaContable.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_CodCtaContable, "Información requerida!!!"); }
                if (_Txt_Cuenta.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Cuenta, "Información requerida!!!"); }
                if (_Txt_Descripcion.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Descripcion, "Información requerida!!!"); }
                if (_Txt_Sucursal.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Sucursal, "Información requerida!!!"); }
                if (_Txt_Gerente.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Gerente, "Información requerida!!!"); }
                if (_Txt_Ejecutivo.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Ejecutivo, "Información requerida!!!"); }
                if (_Txt_Telefono.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Telefono, "Información requerida!!!"); }
                if (_Txt_Inicial.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Inicial, "Información requerida!!!"); }
                if (_Txt_Numero.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Numero, "Información requerida!!!"); }
                return false;
            }
        }
        public bool _Mtd_Editar()
        {
            if (_Cmb_Banco.SelectedIndex > 0 & _Txt_Cuenta.Text.Trim().Length > 0 & _Txt_Descripcion.Text.Trim().Length > 0 & _Txt_Sucursal.Text.Trim().Length > 0 & _Txt_Gerente.Text.Trim().Length > 0 & _Txt_Ejecutivo.Text.Trim().Length > 0 & _Txt_Telefono.Text.Trim().Length > 0 & _Txt_Inicial.Text.Trim().Length > 0 & _Txt_Numero.Text.Trim().Length > 0 & _Txt_CodCtaContable.Text != "")
            {
                string _Str_Cadena = "UPDATE TCUENTBANC Set cnumcuenta='" + _Txt_Cuenta.Text.Trim() + "', cname='" + _Txt_Descripcion.Text.Trim().ToUpper() + "',cbanco='" + _Cmb_Banco.SelectedValue.ToString() + "',csucur='" + _Txt_Sucursal.Text.Trim().ToUpper() + "',cphone1='" + _Txt_Telefono.Text.Trim() + "',cphone2='" + _Txt_Fax.Text.Trim() + "',cinfocont1='" + _Txt_Gerente.Text.Trim().ToUpper() + "',cinfocont2='" + _Txt_Ejecutivo.Text.Trim().ToUpper() + "',ccount='" + _Txt_CodCtaContable.Text + "',csaldoactuconci='" + _Txt_Conciliacion.Text.Trim() + "',csaldoactual='" + _Txt_Total.Text.Trim() + "',cactivo='" + Convert.ToInt32(_Chbox_Activo.Checked).ToString() + "',cproxnumcheq='" + _Txt_Numero.Text.Trim() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0' where cnumcuenta='" + _Txt_Cuenta.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                MessageBox.Show("El registro fue modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((Frm_Banco)_Frm_Banco)._Mtd_CargarCuentas();
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Er_Error.Dispose();

                Close();

                return true;
            }
            else
            {
                if (_Cmb_Banco.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Banco, "Información requerida!!!"); }
                if (_Txt_CodCtaContable.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_CodCtaContable, "Información requerida!!!"); }
                if (_Txt_Cuenta.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Cuenta, "Información requerida!!!"); }
                if (_Txt_Descripcion.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Descripcion, "Información requerida!!!"); }
                if (_Txt_Sucursal.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Sucursal, "Información requerida!!!"); }
                if (_Txt_Gerente.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Gerente, "Información requerida!!!"); }
                if (_Txt_Ejecutivo.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Ejecutivo, "Información requerida!!!"); }
                if (_Txt_Telefono.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Telefono, "Información requerida!!!"); }
                if (_Txt_Inicial.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Inicial, "Información requerida!!!"); }
                if (_Txt_Numero.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Numero, "Información requerida!!!"); }
                return false;
            }
        }
        public bool _Mtd_Eliminar()
        {
            DialogResult eli = MessageBox.Show("Esta seguro de Eliminar el registro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (eli == DialogResult.Yes)
            {
                string _Str_Cadena = "UPDATE TCUENTBANC Set cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' where cnumcuenta='" + _Txt_Cuenta.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                MessageBox.Show("El registro fue eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((Frm_Banco)_Frm_Banco)._Mtd_CargarCuentas();
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
            }
            else
            {
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
            }
            return true;
        }
        
        private void _Txt_Cuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Conciliacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Inicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Total_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Cuenta_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Txt_Cuenta, "");
            if (!_Mtd_IsNumeric(_Txt_Cuenta.Text))
            {
                _Txt_Cuenta.Text = "";
            }
            if (_Cmb_Banco.SelectedIndex > 0)
            {
                if (_Cmb_Banco.SelectedIndex > 0)
                {
                    string _Str_Cadena = "Select cname from TBANCO where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' and cbanco='" + _Cmb_Banco.SelectedValue.ToString() + "'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    {
                        _Txt_Descripcion.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim() + " Nº:" + _Txt_Cuenta.Text.Trim();
                    }
                }
                
            }
        }

        private void _Txt_Telefono_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Telefono.Text))
            {
                _Txt_Telefono.Text = "";
            }
        }

        private void _Txt_Fax_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Fax.Text))
            {
                _Txt_Fax.Text = "";
            }
        }

        private void _Txt_Telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Fax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Cmb_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Banco.SelectedIndex > 0)
            {
                string _Str_Cadena = "Select cname from TBANCO where ccompany='"+Frm_Padre._Str_Comp+"' and cdelete='0' and cbanco='"+_Cmb_Banco.SelectedValue.ToString()+"'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                {
                    _Txt_Descripcion.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim() + " Nº:" + _Txt_Cuenta.Text.Trim();
                }
            }
        }

        private void _Txt_Cuenta_Validating(object sender, CancelEventArgs e)
        {
            string _Str_Sql = "";
            if (_Cmb_Banco.SelectedIndex > 0)
            {
                if (_Txt_Cuenta.Text != "")
                {
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cdelete from TCUENTBANC where ccompany='" + Frm_Padre._Str_Comp + "' and cbanco='" + _Cmb_Banco.SelectedValue.ToString() + "' and cnumcuenta='" + _Txt_Cuenta.Text + "'");
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(_Ds.Tables[0].Rows[0][0]) == "0")
                        {
                            _Er_Error.SetError(_Txt_Cuenta, "Ya existe este Nº de Cuenta.");
                            e.Cancel = true;
                        }
                        else
                        {
                            if (MessageBox.Show("La cuenta está Inactiva. Desea activarla?", "Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                _Str_Sql = "UPDATE TCUENTBANC Set cdelete='0' where cnumcuenta='" + _Txt_Cuenta.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                _Mtd_CargarData(_Cmb_Banco.SelectedValue.ToString(), _Txt_Cuenta.Text.Trim());
                                _Mtd_Deshabilitar_Todo();
                                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                            }
                        }
                    }
                }
            }
        }

        public void _Mtd_BotonesMenu()
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            if (_Bol_FrmSwBlock)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            }
            else
            {
                if (_Str_MyProceso == "A")
                {
                    CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                    //CONTROLES._Ctrl_Buscar._Txt_BotonCtrl.Text = "NT,MF,GT,EF,AF,CT"; 
                }
                if (_Str_MyProceso == "M")
                {
                    CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                }
                if (_Str_MyProceso == "")
                {
                    if (_Txt_Cuenta.Text.Trim() != "")
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                    }
                    else
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                    }
                }
            }
            
        }

        private void _Txt_Gerente_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Txt_Gerente, "");
        }

        private void _Txt_Sucursal_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Txt_Sucursal, "");
        }

        private void _Txt_Inicial_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Txt_Inicial, "");
        }

        private void _Bt_Cuenta_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(93, _Txt_CodCtaContable, 0, " AND cdelete='0' AND ctcount='D'");
            
            Cursor = Cursors.Default;

            _Frm.ShowDialog(this);

            if (_Txt_CodCtaContable.Text != "")
            {
                _Mtd_ActualizarCuentaContable(_Txt_CodCtaContable.Text.Trim());
            }
        }
    }
}