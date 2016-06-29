using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace T3
{
    public partial class Frm_EgreCheqTrans : Form
    {
        string _Str_Relacion = "";
        string _Str_NumCheq = "";
        string _Str_Banco = "";
        string _Str_RelaCheq = "";
        string _Str_FrmCliente = "";
        private bool _G_Bol_EgresoMultiple = false;
        public Frm_EgreCheqTrans()
        {
            InitializeComponent();
            _Mtd_Color_Estandar(this);
            _Mtd_Cargar_Banco();
            _Mtd_Actualizar();
        }
        CLASES._Cls_Varios_Metodos _MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _My_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        private void _Mtd_Actualizar()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Nº Cheque");
            _Tsm_Menu[1] = new ToolStripMenuItem("Cliente");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "VST_EGRECHEQTRANSITO.cnumcheque";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_Cadena = "Select distinct RTRIM(c_nomb_comer) as c_nomb_comer,cname,cnumcheque, CONVERT(varchar, cfeahcaemision, 103) AS cfeahcaemision,CONVERT(varchar, cfechaadeposit, 103) AS cfechaadeposit,dbo.Fnc_Formatear(cmontocheq) as cmontocheq,cidrelacobro,ciddrelacobro_cheq,cbancocheque,ccliente from VST_EGRECHEQTRANSITO INNER JOIN TCAJACXC ON VST_EGRECHEQTRANSITO.cgroupcompany=TCAJACXC.cgroupcomp AND VST_EGRECHEQTRANSITO.ccompany=TCAJACXC.ccompany AND VST_EGRECHEQTRANSITO.ccaja=TCAJACXC.ccaja where cgroupcompany='" + Frm_Padre._Str_GroupComp + "' and VST_EGRECHEQTRANSITO.ccompany='" + Frm_Padre._Str_Comp + "' and (cegresotransito='0' or cegresotransito is null) AND TCAJACXC.ccerrada='1'";
            if (_Chk_EgreSinComp.Checked)
            { _Str_Cadena = "Select distinct RTRIM(c_nomb_comer) as c_nomb_comer,cname,VST_EGRECHEQTRANSITO.cnumcheque, CONVERT(varchar, cfeahcaemision, 103) AS cfeahcaemision,CONVERT(varchar, cfechaadeposit, 103) AS cfechaadeposit,dbo.Fnc_Formatear(VST_EGRECHEQTRANSITO.cmontocheq) as cmontocheq,VST_EGRECHEQTRANSITO.cidrelacobro,ciddrelacobro_cheq,VST_EGRECHEQTRANSITO.cbancocheque,VST_EGRECHEQTRANSITO.ccliente from VST_EGRECHEQTRANSITO INNER JOIN TCAJACXC ON VST_EGRECHEQTRANSITO.cgroupcompany=TCAJACXC.cgroupcomp AND VST_EGRECHEQTRANSITO.ccompany=TCAJACXC.ccompany AND VST_EGRECHEQTRANSITO.ccaja=TCAJACXC.ccaja INNER JOIN TEGRECHEQTRAN ON  VST_EGRECHEQTRANSITO.cgroupcompany=TEGRECHEQTRAN.cgroupcomp AND VST_EGRECHEQTRANSITO.ccompany=TEGRECHEQTRAN.ccompany AND VST_EGRECHEQTRANSITO.cnumcheque=TEGRECHEQTRAN.cnumcheque AND VST_EGRECHEQTRANSITO.ccliente=TEGRECHEQTRAN.ccliente AND VST_EGRECHEQTRANSITO.cbancocheque=TEGRECHEQTRAN.cbancocheque AND VST_EGRECHEQTRANSITO.cidrelacobro=TEGRECHEQTRAN.cidrelacobro where cgroupcompany='" + Frm_Padre._Str_GroupComp + "' and VST_EGRECHEQTRANSITO.ccompany='" + Frm_Padre._Str_Comp + "' and cegresotransito='1' AND TCAJACXC.ccerrada='1' AND (TEGRECHEQTRAN.cidcomprob=0 OR TEGRECHEQTRAN.cidcomprob IS NULL)"; }
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Egreso cheques en tránsito", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public int _Mtd_Entrada()
        {
            string _Str_Cadena = "SELECT cidegrecheqtran FROM TEGRECHEQTRAN where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY cidegrecheqtran DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString().Trim()) + 1;
            }
        }
        private void _Mtd_Color_Estandar(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Color_Estandar(_Ctrl);
                }
                if (_Ctrl.GetType() != typeof(CheckBox))
                { new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco(); }
            }
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private void _Mtd_Cargar_Banco()
        {
            string _Str_Cadena = "SELECT TBANCO.cbanco,TBANCO.cname FROM TBANCO INNER JOIN " +
            "TCUENTBANC ON TBANCO.ccompany = TCUENTBANC.ccompany AND TBANCO.cbanco = TCUENTBANC.cbanco WHERE TBANCO.ccompany='" + Frm_Padre._Str_Comp + "' and TBANCO.cdelete=0";
            _MyUtilidad._Mtd_CargarCombo(_Cmb_Banco, _Str_Cadena);
        }
        private void _Mtd_Cargar_Numero(string _P_Str_Banco)
        {
            string _Str_Cadena = "SELECT cnumcuenta,cname from TCUENTBANC where ccompany='" + Frm_Padre._Str_Comp + "' and cdelete='0' AND cbanco='" + _P_Str_Banco + "' Order by cname Asc";
            _MyUtilidad._Mtd_CargarCombo(_Cmb_Numero, _Str_Cadena);
        }
        public void _Mtd_Ini()
        {
            _Str_FrmCliente = "";
            _Txt_Banco.Text = "";
            _Txt_FechaEmision.Text = "";
            _Txt_Monto.Text = "";
            _Txt_Numero.Text = "";
            _Txt_Cliente.Text = "";
            _Txt_Cliente.Tag = "";
            _Mtd_Cargar_Banco();
        }
        public void _Mtd_Habilitar()
        {
            _Cmb_Banco.Enabled = true;
            _Cmb_Numero.Enabled = true;
            _Txt_Numero.Enabled = true;
            _Bt_Egresar.Enabled = true;
        }
        private void _Mtd_Deshabilitar_Todo()
        {
            _Cmb_Banco.Enabled = false;
            _Cmb_Numero.Enabled = false;
            _Txt_Numero.Enabled = false;
            _Bt_Egresar.Enabled = false;
            _Bt_Eliminar.Enabled = false;
        }
        private bool _Mtd_VerificarTEGRECHEQTRAN(string _P_Str_Cliente, string _P_Str_NumCheq, string _P_Str_Banco)
        {
            string _Str_Cadena = "SELECT cnumcheque FROM TEGRECHEQTRAN WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + _P_Str_Cliente + "' AND cnumcheque='" + _P_Str_NumCheq + "' AND cbancocheque='" + _P_Str_Banco + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }
        private void _Mtd_Egresar()
        {
            string _Str_Cadena = "";
            int _Int_Codigo = _Mtd_Entrada();
            if (!_Mtd_VerificarTEGRECHEQTRAN(_Str_FrmCliente, _Str_NumCheq, _Str_Banco))
            {
                _Str_Cadena = "insert into TEGRECHEQTRAN (cgroupcomp,ccompany,cidegrecheqtran,cnumdepo,cnumcheque,ccliente,cbancocheque,cfechaemision,cmontocheq,cbancodepo,cnumcuentadepo,cfechadepo,cdateadd,cuseradd,cdelete,cidcomprob,cidrelacobro) values('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Int_Codigo.ToString() + "','" + _Txt_Numero.Text.Trim() + "','" + _Str_NumCheq + "','" + _Str_FrmCliente + "','" + _Str_Banco + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Txt_FechaEmision.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Monto.Text)) + "','" + Convert.ToString(_Cmb_Banco.SelectedValue) + "','" + Convert.ToString(_Cmb_Numero.SelectedValue) + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','0','0','" + _Str_Relacion + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "Update TRELACCOBDCHEQ set cegresotransito='1' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidrelacobro='" + _Str_Relacion + "' and ciddrelacobro_cheq='" + _Str_RelaCheq + "' and cnumcheque='" + _Str_NumCheq + "' AND ccliente='" + _Str_FrmCliente + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                MessageBox.Show("La operación fue realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El cheque ya ha sido egresado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            _Mtd_Ini();
            _Mtd_Deshabilitar_Todo();
            _Mtd_Actualizar();
            _Tb_Tab.SelectedIndex = 0;
        }
        private void Frm_EgreCheqTrans_Load(object sender, EventArgs e)
        {            
            this.Dock = DockStyle.Fill;
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
        }

        private void _Cmb_Banco_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Banco();
        }

        private void _Cmb_Numero_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_Banco.SelectedIndex > 0)
            { _Mtd_Cargar_Numero(Convert.ToString(_Cmb_Banco.SelectedValue)); }
            else
            { _Cmb_Numero.DataSource = null; }
        }

        private void _Cmb_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Cmb_Numero.DataSource = null;
        }
        string _Str_IdEgreso = "";
        private void _Mtd_CargarEgresosSinComprob(string _P_Str_NumCheque,string _P_Str_Cliente,string _P_Str_BancoCheq,string _P_Str_IdRelaCobro)
        {
            string _Str_Cadena = "SELECT cidegrecheqtran,cbancodepo,cnumcuentadepo,cnumdepo FROM TEGRECHEQTRAN WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cnumcheque='" + _P_Str_NumCheque + "' AND ccliente='" + _P_Str_Cliente + "' AND cbancocheque='" + _P_Str_BancoCheq + "' AND cidrelacobro='" + _P_Str_IdRelaCobro + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_IdEgreso = _Ds.Tables[0].Rows[0]["cidegrecheqtran"].ToString().Trim();
                _Cmb_Banco.SelectedValue = _Ds.Tables[0].Rows[0]["cbancodepo"].ToString().Trim();
                _Mtd_Cargar_Numero(Convert.ToString(_Cmb_Banco.SelectedValue));
                _Cmb_Numero.SelectedValue = _Ds.Tables[0].Rows[0]["cnumcuentadepo"].ToString().Trim();
                _Txt_Numero.Text = _Ds.Tables[0].Rows[0]["cnumdepo"].ToString().Trim();
            }
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                //Paneles
                _Pnl_ChequeIndividual.Visible = true;
                _Pnl_ChequeIndividual.Height = 127;
                _Pnl_ChequesSeleccionados.Visible = false;
                _Bt_Egresar.Text = "Egresar cheque..";
                _G_Bol_EgresoMultiple = false;
                _Lbl_MontoDeposito.Visible = false;
                _Txt_MontoDeposito.Visible = false;

                Cursor = Cursors.WaitCursor;
                _Er_Error.Dispose();
                _Mtd_Ini();
                if (_Chk_EgreSinComp.Checked)
                { _Mtd_Deshabilitar_Todo(); }
                else
                { _Mtd_Habilitar(); }
                _Str_IdEgreso = "";
                string _Str_NombreCliente = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("c_nomb_comer", e.RowIndex);
                _Str_FrmCliente = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("ccliente", e.RowIndex);
                _Txt_Banco.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("cname", e.RowIndex);
                _Txt_FechaEmision.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("cfeahcaemision", e.RowIndex);
                _Txt_Monto.Text = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("cmontocheq", e.RowIndex);
                _Txt_Cliente.Text = _Str_FrmCliente + " - " + _Str_NombreCliente.TrimEnd();
                _Str_Banco = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("cbancocheque", e.RowIndex);
                _Str_NumCheq = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("cnumcheque", e.RowIndex);
                _Str_Relacion = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("cidrelacobro", e.RowIndex);
                _Str_RelaCheq = _Ctrl_Busqueda1._Mtd_RetornarStringCelda("ciddrelacobro_cheq", e.RowIndex);
                _Tb_Tab.SelectedIndex = 1;
                _Mtd_Cargar_Banco();
                _Cmb_Numero.DataSource = null;
                _Cmb_Banco.Focus();
                if (_Chk_EgreSinComp.Checked)
                {
                    _Mtd_CargarEgresosSinComprob(_Ctrl_Busqueda1._Mtd_RetornarStringCelda("cnumcheque", e.RowIndex), _Str_FrmCliente, _Ctrl_Busqueda1._Mtd_RetornarStringCelda("cbancocheque", e.RowIndex), _Str_Relacion);
                    _Bt_Eliminar.Enabled = _MyUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ELIMINAR_EGRESO");
                }
                Cursor = Cursors.Default;
            }
        }

        private void Frm_EgreCheqTrans_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        private void _Bt_Egresar_Click(object sender, EventArgs e)
        {
            ((Frm_Padre)this.MdiParent)._Frm_Contenedor._Mtd_VerificarCierreCaja();
            if (!((Frm_Padre)this.MdiParent)._Frm_Contenedor._Bol_CierreCajaActivado)
            {
                _Er_Error.Dispose();
                if (_Txt_Monto.Text.Trim().Length == 0)
                { _Txt_Monto.Text = "0"; }
                //Validacion del Monto
                var _Bol_MontoValido = !_G_Bol_EgresoMultiple || _Txt_MontoDeposito.Text.Trim().Length > 0;

                if ((_Cmb_Banco.SelectedIndex > 0 & _Cmb_Numero.SelectedIndex > 0 & _Txt_Numero.Text.Trim().Length > 0) && (_Bol_MontoValido))
                {
                    if (_G_Bol_EgresoMultiple)
                    {
                        if (!_Mtd_MontoDepositoEsValido())
                        {
                            MessageBox.Show("El Monto del Depósito no coincide con los montos de los cheques.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (!_Mtd_ExistenChequesEgresados_Multiple())
                        {
                            Cursor = Cursors.WaitCursor;
                            _Mtd_Egresar_Multiple();
                            Cursor = Cursors.Default;
                        }
                        else
                        {
                            _Mtd_Ini();
                            _Mtd_Deshabilitar_Todo();
                            _Mtd_Actualizar();
                            _Tb_Tab.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        if (!_Mtd_VerificarTEGRECHEQTRAN(_Str_FrmCliente, _Str_NumCheq, _Str_Banco))
                        {
                            Cursor = Cursors.WaitCursor;
                            _Mtd_Egresar();
                            Cursor = Cursors.Default;
                        }
                        else
                        {
                            MessageBox.Show("El cheque ya ha sido egresado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Mtd_Ini();
                            _Mtd_Deshabilitar_Todo();
                            _Mtd_Actualizar();
                            _Tb_Tab.SelectedIndex = 0;
                        }
                    }
                }
                else
                {
                    if (_Cmb_Banco.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Banco, "Información requerida!!!"); }
                    if (_Cmb_Numero.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Numero, "Información requerida!!!"); }
                    if (_Txt_Numero.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Numero, "Información requerida!!!"); }
                    if (_G_Bol_EgresoMultiple) if (_Txt_MontoDeposito.Text.Trim().Length <= 0) { _Er_Error.SetError(_Txt_MontoDeposito, "Información requerida!!!"); }
                }
            }
        }

        private bool _Mtd_MontoDepositoEsValido()
        {
            //Tomamos el Saldo y comparamos
            var _Dbl_MontoDeposito = 0.0;
            Double.TryParse(_Txt_MontoDeposito.Text, out _Dbl_MontoDeposito);

            //Calculamos el total de los cheques seleccionados
            var _Dbl_TotalChequesSeleccionados = _Dg_Grid.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Convert.ToDouble(x.Cells["cmontocheq"].Value));

            //Redondeamos
            _Dbl_MontoDeposito = Math.Round(_Dbl_MontoDeposito, 2);
            _Dbl_TotalChequesSeleccionados = Math.Round(_Dbl_TotalChequesSeleccionados, 2);

            //Verificamos
            var _Bol_Coinciden = _Dbl_MontoDeposito == _Dbl_TotalChequesSeleccionados;

            return _Bol_Coinciden;
        }

        private void _Txt_Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Numero_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Numero.Text))
            {
                _Txt_Numero.Text = "";
            }
        }
        private bool _Mtd_PrintComprob(string _Pr_Str_Comprob)
        {
            bool _Bol_R = false;
        A:
            PrintDialog _Print = new PrintDialog();
            if (_Print.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    //IMPRIMO COMPROB CONTABLE
                    REPORTESS _Frm_A = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Pr_Str_Comprob + "'", _Print, true);
                    //_Frm_A.MdiParent = this.MdiParent;
                    //_Frm_A.Show();
                    this.Cursor = Cursors.Default;
                    if (MessageBox.Show("Se imprimió correctamente el comprobante", "Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _Bol_R = true;
                        Program._MyClsCnn._mtd_conexion._Mtd_modificar("TCOMPROBANC", "clvalidado='1',cvalidate='" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "'", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Pr_Str_Comprob + "'");
                    }
                    else
                    {
                        _Bol_R = false;
                        //_Frm_A.Close();
                        _Frm_A.Dispose();
                        goto A;
                    }
                }
                catch
                {
                    _Bol_R = false;
                    MessageBox.Show("Problemas al contactar la impresora.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return _Bol_R;
        }
        private bool _Mtd_VerificarComprobanteCreado(string _P_Str_NumCheque, string _P_Str_Cliente, string _P_Str_BancoCheq, string _P_Str_IdRelaCobro)
        {
            string _Str_Cadena = "SELECT cidegrecheqtran FROM TEGRECHEQTRAN WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidegrecheqtran='" + _Str_IdEgreso + "' AND cnumcheque='" + _P_Str_NumCheque + "' AND ccliente='" + _P_Str_Cliente + "' AND cbancocheque='" + _P_Str_BancoCheq + "' AND cidrelacobro='" + _P_Str_IdRelaCobro + "' AND ISNULL(cidcomprob,0)>0";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Mtd_Eliminar(string _P_Str_NumCheque, string _P_Str_Cliente, string _P_Str_BancoCheq, string _P_Str_IdRelaCobro)
        {
            if (_Str_IdEgreso.Trim().Length > 0 & _Str_Relacion.Trim().Length > 0 & _Str_RelaCheq.Trim().Length>0 & _Str_NumCheq.Trim().Length > 0 & _Str_FrmCliente.Trim().Length > 0)
            {
                if (!_Mtd_VerificarComprobanteCreado(_Str_NumCheq, _Str_FrmCliente, _Str_Banco, _Str_Relacion))
                {
                    string _Str_Cadena = "UPDATE TRELACCOBDCHEQ set cegresotransito='0' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidrelacobro='" + _Str_Relacion + "' AND ciddrelacobro_cheq='" + _Str_RelaCheq + "' AND cnumcheque='" + _Str_NumCheq + "' AND ccliente='" + _Str_FrmCliente + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "DELETE FROM TEGRECHEQTRAN WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidegrecheqtran='" + _Str_IdEgreso + "' AND cnumcheque='" + _P_Str_NumCheque + "' AND ccliente='" + _P_Str_Cliente + "' AND cbancocheque='" + _P_Str_BancoCheq + "' AND cidrelacobro='" + _P_Str_IdRelaCobro + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                    MessageBox.Show("El egreso ha sido eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                { MessageBox.Show("Se ha creado el comprobante de este egreso por otro usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else
            { MessageBox.Show("No se puede realizar la operación. No se obtuvieron algunos datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_Cmb_Banco.Enabled & _Txt_Banco.Text.Trim().Length == 0 & e.TabPageIndex != 0)
            { e.Cancel = true; }
            else if (e.TabPageIndex == 0)
            { _Mtd_Ini(); _Mtd_Deshabilitar_Todo(); }
        }

        private void _Dg_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
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

        private void _Chk_EgreSinComp_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
            Cursor = Cursors.Default;
        }

        private void _Bt_Eliminar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = true;
        }

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_MyUtilidad._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                _Pnl_Clave.Visible = false;
                _Mtd_Eliminar(_Str_NumCheq, _Str_FrmCliente, _Str_Banco, _Str_Relacion);
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Mtd_Actualizar();
                _Tb_Tab.SelectedIndex = 0;

            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Tb_Tab.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Tb_Tab.Enabled = true; }
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (_Chk_EgreSinComp.Checked) 
                e.Cancel = true;
            else 
                e.Cancel = _Dg_Grid.SelectedRows.Count < 2;
        }

        private void _Tol_EgresoMultiple_Click(object sender, EventArgs e)
        {
            //Solo si se selecciona 2 o mas cheques
            if (_Dg_Grid.SelectedRows.Count >= 2)
            {
                //Paneles
                _Pnl_ChequeIndividual.Visible = false;
                _Pnl_ChequeIndividual.Height = 0;
                _Pnl_ChequesSeleccionados.Visible = true;
                _Bt_Egresar.Text = "Egresar cheques..";
                _G_Bol_EgresoMultiple = true;
                _Lbl_MontoDeposito.Visible = true;
                _Txt_MontoDeposito.Visible = true;
                _Txt_MontoDeposito.Text = "";

                //
                Cursor = Cursors.WaitCursor;
                _Er_Error.Dispose();
                _Mtd_Ini();
                if (_Chk_EgreSinComp.Checked)
                { _Mtd_Deshabilitar_Todo(); }
                else
                { _Mtd_Habilitar(); }
                _Str_IdEgreso = "";

                _Str_FrmCliente = "";
                _Txt_Banco.Text = "";
                _Txt_FechaEmision.Text = "";
                _Txt_Monto.Text = "";
                _Txt_Cliente.Text = "";
                _Str_Banco = "";
                _Str_NumCheq = "";
                _Str_Relacion = "";
                _Str_RelaCheq = "";
                _Tb_Tab.SelectedIndex = 1;
                _Mtd_Cargar_Banco();
                _Cmb_Numero.DataSource = null;
                _Cmb_Banco.Focus();

                //Cargamos los Cheques seleccionados para que le usuario vea si selecciono bien
                _Dg_Grid_ChequesSeleccionados.Rows.Clear();
                foreach (DataGridViewRow _RowSeleccionado in _Dg_Grid.SelectedRows)
                {
                    var _RowNuevo = (DataGridViewRow) _RowSeleccionado.Clone();
                    for (int i = 0; i < _RowSeleccionado.Cells.Count; i++)
                    {
                        _RowNuevo.Cells[i].Value = _RowSeleccionado.Cells[i].Value;
                    }
                    _Dg_Grid_ChequesSeleccionados.Rows.Add(_RowNuevo);
                }
                
                Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Para poder Egresar Multiples Cheques debe seleccionar por lo menos dos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool _Mtd_ExistenChequesEgresados_Multiple()
        {
            var _Bol_ExisteChequeEgresado = false;
            var _Str_Mensaje = "";
            var _Int_Contador = 0;

            foreach (DataGridViewRow _Row in _Dg_Grid.SelectedRows)
            {
                var _Str_FrmCliente = _Row.Cells["ccliente"].Value.ToString();
                var _Str_NumCheq = _Row.Cells["cnumcheque"].Value.ToString();
                var _Str_Banco = _Row.Cells["cbancocheque"].Value.ToString();

                string _Str_Cadena = "SELECT cnumcheque FROM TEGRECHEQTRAN WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ccliente='" + _Str_FrmCliente + "' AND cnumcheque='" + _Str_NumCheq + "' AND cbancocheque='" + _Str_Banco + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Bol_ExisteChequeEgresado = true;
                    _Int_Contador++;
                    if (_Int_Contador == 1)
                    {
                        _Str_Mensaje += _Str_NumCheq;
                    }
                    else
                    {
                        _Str_Mensaje += ", " + _Str_NumCheq;
                    }
                }
            }

            if (_Bol_ExisteChequeEgresado)
            {
                if (_Int_Contador == 1)
                {
                    MessageBox.Show("El cheque # " + _Str_Mensaje + " ya ha sido egresado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Los cheques # (" + _Str_Mensaje + ") ya han sido egresados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return false;
            }

            //Todo bien
            return false;
        }

        private void _Mtd_Egresar_Multiple()
        {
            foreach (DataGridViewRow _Row in _Dg_Grid.SelectedRows)
            {
                string _Str_Cadena = "";
                int _Int_Codigo = _Mtd_Entrada();

                _Str_FrmCliente =  _Row.Cells["ccliente"].Value.ToString();
                _Str_Banco =  _Row.Cells["cname"].Value.ToString();
                var _Str_FechaEmision =  _Row.Cells["cfeahcaemision"].Value.ToString();
                var _Str_Monto = _Row.Cells["cmontocheq"].Value.ToString();
                _Str_Banco =   _Row.Cells["cbancocheque"].Value.ToString();
                _Str_NumCheq =  _Row.Cells["cnumcheque"].Value.ToString();
                _Str_Relacion = _Row.Cells["cidrelacobro"].Value.ToString();
                _Str_RelaCheq = _Row.Cells["ciddrelacobro_cheq"].Value.ToString();

                //Válido re-verifico si existe el egreso (esto se hace para evitar la re-duplicación-de-registros inexplicables del grid)
                if (!_Mtd_VerificarTEGRECHEQTRAN(_Str_FrmCliente, _Str_NumCheq, _Str_Banco))
                {
                    _Str_Cadena = "insert into TEGRECHEQTRAN (cgroupcomp,ccompany,cidegrecheqtran,cnumdepo,cnumcheque,ccliente,cbancocheque,cfechaemision,cmontocheq,cbancodepo,cnumcuentadepo,cfechadepo,cdateadd,cuseradd,cdelete,cidcomprob,cidrelacobro) values('" + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Int_Codigo.ToString() + "','" + _Txt_Numero.Text.Trim() + "','" + _Str_NumCheq + "','" + _Str_FrmCliente + "','" + _Str_Banco + "','" + _My_Formato._Mtd_fecha(Convert.ToDateTime(_Str_FechaEmision)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Str_Monto)) + "','" + Convert.ToString(_Cmb_Banco.SelectedValue) + "','" + Convert.ToString(_Cmb_Numero.SelectedValue) + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _My_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "','0','0','" + _Str_Relacion + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Str_Cadena = "Update TRELACCOBDCHEQ set cegresotransito='1' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidrelacobro='" + _Str_Relacion + "' and ciddrelacobro_cheq='" + _Str_RelaCheq + "' and cnumcheque='" + _Str_NumCheq + "' AND ccliente='" + _Str_FrmCliente + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
            }
            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
            MessageBox.Show("La operación fue realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            _Mtd_Ini();
            _Mtd_Deshabilitar_Todo();
            _Mtd_Actualizar();
            _Tb_Tab.SelectedIndex = 0;
        }

        private void _Txt_MontoDeposito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar)) && (e.KeyChar != ',') && (e.KeyChar != '.')))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.'))
            {
                e.KeyChar = ',';
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

    }
}