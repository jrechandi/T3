using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Linq;
namespace T3
{
    public partial class Frm_EmisionCheque : Form
    {
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        bool _Bol_DesdeOrdenPago = false;
        public Frm_EmisionCheque()
        {
            InitializeComponent();
            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
        }
        //_Str_Sql = "UPDATE TFACTPPAGARM SET cordenpaghecha='0' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + Convert.ToString(_Txt_Prov.Tag) + "'";
        public Frm_EmisionCheque(string _Pr_Str_Val)
        {
            InitializeComponent();
            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Str_InForm = _Pr_Str_Val;
        }

        string _Str_Concepto = "";
        Frm_OrdenPago _Frm_OrdenPagoConstructor;
        public Frm_EmisionCheque(string _Pr_Str_Val, string _P_Str_Concepto, Frm_OrdenPago _P_Frm_OrdenPago)
        {
            InitializeComponent();
            _Frm_OrdenPagoConstructor = _P_Frm_OrdenPago;
            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Str_InForm = _Pr_Str_Val;
            _Str_Concepto = _P_Str_Concepto;
        }
        string _Str_TipoTabs = "";
        public Frm_EmisionCheque(string _Pr_Str_Val, string _P_Str_TipoTabs)
        {
            InitializeComponent();
            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Str_InForm = _Pr_Str_Val;
            _Str_TipoTabs = _P_Str_TipoTabs;
        }
        string _Str_UPDATE_TFACTPPAGARM = "";
        string[] _Str_UPDATE_TIPO;
        string[] _Str_UPDATE_DOCU;
        public Frm_EmisionCheque(string _Pr_Str_Val, string _P_Str_Cadena, string[] _P_Str_Tipo, string[] _P_Str_Docu, Frm_OrdenPago _P_Frm_OrdenPago)
        {
            InitializeComponent();
            _Frm_OrdenPagoConstructor = _P_Frm_OrdenPago;
            _Dt_Desde.MaxDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Desde.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_Hasta.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Str_InForm = _Pr_Str_Val;
            _Str_UPDATE_TFACTPPAGARM = _P_Str_Cadena;
            _Str_UPDATE_TIPO = _P_Str_Tipo;
            _Str_UPDATE_DOCU = _P_Str_Docu;
        }
        private void _Mtd_UPDATE()
        {
            int _Int_I = 0;
            string _Str_Cadena = "";
            foreach (string _Str in _Str_UPDATE_TIPO)
            {
                _Str_Cadena = _Str_UPDATE_TFACTPPAGARM + " AND ctipodocument='" + _Str + "' AND cnumdocu='" + _Str_UPDATE_DOCU[_Int_I] + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Int_I++;
            }
        }
        int _Int_SwProvTpo = 0;
        int _Int_SwProvCarga = 0;
        int _Int_FrmTotComprobSw = 0;
        string _Str_cidcomprob = "";
        string _Str_UsuarioFirma = "";
        string _Str_UsuarioCargo = "";
        string _Str_UsuarioName = "";
        string _Str_Usuario = "";
        string _Str_FirmaSolicitante = "";
        string _Str_FirmaContable = "";
        string _Str_FirmaAprobador = "";
        string _Str_TpoUsu = "";
        public string _Str_InForm = "";//PARA SABER SI EL FORMULARIO SE LLAMO DESDE UNO QUE NO SEA EL PADRE
        string _Str_MyProceso = "";
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        Control[] _Ctrl_Controles = new Control[13];
        TextBox _Txt_ColDoH;//PARA LA VALIDACION EN EL GRID DE DETALLE DE ORDEN DE PAGO

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

        private void Frm_EmisionCheque_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Mtd_Ini();
            _Mtd_CargarTpoProveFind();
            _Mtd_Sorted(_Dg_Find);
            _Mtd_Sorted(_Dg_Comprobante);
            _Mtd_CargarProvee();
            if (_Cb_TpoProveFind.DataSource != null)
            { _Cb_TpoProveFind.SelectedIndex = 0; }
            if (_Cb_ProveedorFind.DataSource != null)
            { _Cb_ProveedorFind.SelectedIndex = 0; }

            _Mtd_CargarBusqueda();
        }

        private void Frm_EmisionCheque_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            //CONTROLES._Ctrl_Buscar._Ctrl_Controles = _Ctrl_Controles;
            CONTROLES._Ctrl_Buscar._Er_Control_Error = _Er_Error;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._Txt_BotonCtrl.Text = "";
            if (_Str_MyProceso == "M")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
            }
            else
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
                if (_Str_MyProceso == "A")
                { _Cb_TpoPago.Focus(); }
            }

            _Mtd_Color_Estandar(this);
            _Mtd_BotonesMenu();
        }

        public void _Mtd_BotonesMenu()
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
        }

        public void _Mtd_Cancelar()
        {
            _Mtd_Ini();
        }

        public void _Mtd_Ini()
        {
            _Str_MyProceso = "";
            _Txt_EmisionId.Text = "";
            _Txt_OrdPagoId.Text = "";
            //_Pnl_Clave.Parent = this;
            //_Pnl_Clave.BringToFront();
            //_Pnl_Comprobante.Parent = this;
            //_Pnl_Comprobante.BringToFront();
            if (_Cb_TpoProveFind.DataSource != null)
            { _Cb_TpoProveFind.SelectedIndex = 0; }
            if (_Cb_CatProveFind.DataSource != null)
            { _Cb_CatProveFind.SelectedIndex = 0; }
            if (_Cb_ProveedorFind.DataSource != null)
            { _Cb_ProveedorFind.SelectedIndex = 0; }

            _Cb_TpoPago.SelectedIndex = -1;
            _Cb_FormaPago.SelectedIndex = -1;
            _Cb_Banco.SelectedIndex = -1;
            _Cb_Cuenta.SelectedIndex = -1;
            _Txt_Doc.Text = "";
            _Txt_Concepto.Text = "";
            _Txt_RifCedula.Text = "";
            _Txt_Monto.Text = "";
            _Dt_ChequeEmi.MinDate = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
            _Dt_ChequeEmi.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));

            _Txt_FirmaSol.Text = "";
            _Txt_FirmaCont.Text = "";
            _Txt_FirmaAprob.Text = "";
            _Str_FirmaSolicitante = "";
            _Str_FirmaAprobador = "";
            _Str_FirmaContable = "";
            _Str_TpoUsu = "";
            _Str_cidcomprob = "";
            _Dg_Comprobante.ContextMenuStrip = null;
            _Dg_Comprobante.ReadOnly = false;
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            _Dg_Comprobante.AutoResizeColumns();
            _Bt_EditarComprob.Enabled = false;
            //_Dg_Comprobante.Rows.Clear();
            while (_Dg_Comprobante.Rows.Count > 0)
            {
                _Dg_Comprobante.Rows.RemoveAt(0);
            }
            _Dg_Comprobante.ReadOnly = true;
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Comprobante.AutoResizeColumns();
            _Mtd_GridColor(_Dg_Comprobante);
            _Pnl_Clave.Visible = false;
            _Mtd_CargarBancos();
            _Mtd_CargarFormaPago();
            _Mtd_CargarTpoPago();
            _Mtd_UsuarioSts(Frm_Padre._Str_Use);
            _Mtd_BotonesMenu();
            _Mtd_Bloquear(false);
        }

        private void _Mtd_Bloquear(bool _Pr_Bol_A)
        {
            _Txt_EmisionId.Enabled = false;
            _Txt_OrdPagoId.Enabled = false;
            _Bt_ChequeVer.Enabled = false;//false**************************
            _Bt_FirmaSol.Enabled = false;
            _Bt_FirmaCont.Enabled = false;
            _Bt_FirmaAprob.Enabled = false;
            _Dg_Comprobante.ReadOnly = true;
            _Mtd_GridColor(_Dg_Comprobante);
            if (_Str_InForm == "")
            {
                _Bt_OrdPagoGo.Enabled = _Pr_Bol_A;
            }
            else
            { _Bt_OrdPagoGo.Enabled = false; }


            _Cb_TpoPago.Enabled = false;
            _Cb_FormaPago.Enabled = false;
            _Cb_Banco.Enabled = _Pr_Bol_A;
            _Cb_Cuenta.Enabled = _Pr_Bol_A;
            _Txt_Concepto.Enabled = _Pr_Bol_A;
            _Txt_Persona.Enabled = false;
            _Dt_Fecha.Enabled = false;
            _Dt_ChequeEmi.Enabled = _Pr_Bol_A;
            _Txt_CantDescrip.Enabled = false;
            _Txt_Monto.Enabled = false;
            _Txt_FirmaSol.Enabled = false;
            _Txt_FirmaCont.Enabled = false;
            _Txt_FirmaAprob.Enabled = false;
            _Txt_Doc.Enabled = false;
        }

        public bool _Mtd_Editar()
        {
            string _Str_Sql = "";
            string _Str_corder = "";
            string _Str_ctdocument = "";
            string _Str_cnumdocu = "";
            string _Str_cdatedocu = "";
            string _Str_DescripAdd = "";
            double _Dbl_TotDebe = 0;
            double _Dbl_TotHaber = 0;
            bool _Bol_Val = false;
            bool _Bol_R = false;
            if (_Str_MyProceso == "M")
            {
                if (_Mtd_VerificarSaldo())
                {
                    MessageBox.Show("Los Totales de Debe y Haber no coinciden o El total a Pagar no es igual al saldo del comprobante.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Bol_Val = true;
                }
            }

            if (!_Bol_Val)
            {
                try
                {
                    DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctdocumentopcheq,ctdocumentoptransf FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(_Cb_FormaPago.SelectedValue) == "CHEQ")
                        {
                            _Str_ctdocument = "'" + Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) + "'";
                            _Str_cnumdocu = "'" + _Txt_Doc.Text + "'";
                        }
                        else if (Convert.ToString(_Cb_FormaPago.SelectedValue) == "TRANSF")
                        {
                            _Str_ctdocument = "'" + Convert.ToString(_Ds_A.Tables[0].Rows[0][1]).Trim() + "'";
                            _Str_cnumdocu = "'" + _Txt_EmisionId.Text.Trim() + "'";
                        }
                    }
                    else
                    { _Str_ctdocument = "null"; }
                    //ACTUALIZO EL COMPROBANTE
                    if (Convert.ToString(_Cb_FormaPago.SelectedValue) == "CHEQ")
                    { _Str_DescripAdd = " S/CHEQUE # " + _Txt_Doc.Text; }
                    else if (Convert.ToString(_Cb_FormaPago.SelectedValue) == "TRANSF")
                    { _Str_DescripAdd = " S/TRANSACCION # " + _Txt_Doc.Text; }

                    foreach (DataGridViewRow _DgRow in _Dg_Comprobante.Rows)
                    {
                        if (_DgRow.Visible)
                        {
                            if (Convert.ToString(_DgRow.Cells[0].Value) != "T")
                            {
                                if (Convert.ToString(_DgRow.Cells[0].Value) == "")
                                {//AGREGO UN REGISTRO
                                    _Str_corder = Convert.ToString(myUtilidad._Mtd_Consecutivo_TCOMPROBAND(_Txt_ComprobId.Text));
                                    _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,ctothaber,cdateadd,cuseradd,cdescrip) values ('";
                                    if (myUtilidad._Mtd_CuentaContableIsBanco(Convert.ToString(_Cb_Banco.SelectedValue), Convert.ToString(_Cb_Cuenta.SelectedValue), Convert.ToString(_DgRow.Cells[1].Value)))
                                    {
                                        _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Txt_ComprobId.Text.Trim() + "','" + _Str_corder + "','" + Convert.ToString(_DgRow.Cells[1].Value).Trim() + "','" + _Str_ctdocument + "','" + _Str_cnumdocu + "','" + _Str_cdatedocu + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[4].Value)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[5].Value)) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + Convert.ToString(_DgRow.Cells[3].Value).Trim().ToUpper().Replace("'", "''") + "')";
                                    }
                                    else
                                    {
                                        _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Txt_ComprobId.Text.Trim() + "','" + _Str_corder + "','" + Convert.ToString(_DgRow.Cells[1].Value).Trim() + "','" + _Str_ctdocument + "','" + _Str_cnumdocu + "','" + _Str_cdatedocu + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[4].Value)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[5].Value)) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + Convert.ToString(_DgRow.Cells[3].Value).Trim().ToUpper().Replace("'", "''") + "')";
                                    }
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                }
                                else
                                {//MODIFICO EL REGISTRO

                                    if (myUtilidad._Mtd_CuentaContableIsBanco(Convert.ToString(_Cb_Banco.SelectedValue), Convert.ToString(_Cb_Cuenta.SelectedValue), Convert.ToString(_DgRow.Cells[1].Value)))
                                    {
                                        _Str_Sql = "UPDATE TCOMPROBAND SET ccount='" + Convert.ToString(_DgRow.Cells[1].Value) + "',ctdocument=" + _Str_ctdocument + ",cnumdocu=" + _Str_cnumdocu + ",cdatedocu='" + _Dt_Fecha.Value.ToShortDateString() + "',ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[4].Value)) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[5].Value)) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdescrip='" + Convert.ToString(_DgRow.Cells[3].Value).Trim().ToUpper().Replace("'", "''") + "'"; //_Str_DescripAdd + ". " + _Txt_Concepto.Text + "'
                                    }
                                    else
                                    { _Str_Sql = "UPDATE TCOMPROBAND SET ccount='" + Convert.ToString(_DgRow.Cells[1].Value) + "',ctdocument=" + _Str_ctdocument + ",cnumdocu=" + _Str_cnumdocu + ",cdatedocu='" + _Dt_Fecha.Value.ToShortDateString() + "',ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[4].Value)) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[5].Value)) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdescrip='" + Convert.ToString(_DgRow.Cells[3].Value).Trim().ToUpper().Replace("'", "''") + "'"; }

                                    _Str_Sql = _Str_Sql + " WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Txt_ComprobId.Text.Trim() + "' AND corder='" + Convert.ToString(_DgRow.Cells[0].Value).Trim() + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                }
                                if (Convert.ToString(_DgRow.Cells[4].Value).Trim() != "")
                                {
                                    _Dbl_TotDebe = _Dbl_TotDebe + Convert.ToDouble(_DgRow.Cells[4].Value);
                                }
                                if (Convert.ToString(_DgRow.Cells[5].Value).Trim() != "")
                                {
                                    _Dbl_TotHaber = _Dbl_TotHaber + Convert.ToDouble(_DgRow.Cells[5].Value);
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToString(_DgRow.Cells[0].Value) != "")
                            {
                                _Str_Sql = "DELETE FROM TCOMPROBAND";
                                _Str_Sql = _Str_Sql + " WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Txt_ComprobId.Text + "' AND corder='" + Convert.ToString(_DgRow.Cells[0].Value) + "'";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            }
                        }
                    }
                    //MODIFICO LOS TOTALES DE DEBE Y HABER Y ACTIVO EL FLAG
                    _Str_Sql = "UPDATE TCOMPROBANC SET clvalidado=1,ctotdebe=" + _Dbl_TotDebe.ToString().Replace(",", ".") + ",ctothaber=" + _Dbl_TotHaber.ToString().Replace(",", ".");
                    _Str_Sql = _Str_Sql + " WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Txt_ComprobId.Text + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    _Str_Sql = "UPDATE TEMICHEQTRANSM SET cfechaemision='" + _Dt_ChequeEmi.Value.ToShortDateString() + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Txt_OrdPagoId.Text + "' AND cidemisioncheq='" + _Txt_EmisionId.Text + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    _Dg_Comprobante.ReadOnly = true;
                    _Mtd_GridColor(_Dg_Comprobante);
                    _Mtd_Bloquear(false);
                    _Dt_ChequeEmi.Enabled = false;
                    _Dt_Fecha.Enabled = false;
                    _Str_MyProceso = "";
                    _Mtd_BotonesMenu();
                    _Mtd_CargarBusqueda();
                    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cusersolicitante,cuserfirmante1,cuseraprobador FROM TEMICHEQTRANSM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidemisioncheq='" + _Txt_EmisionId.Text + "'");
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    {
                        _Txt_FirmaSol.Text = myUtilidad._Mtd_ObtenerUsuarioName(Convert.ToString(_Ds_A.Tables[0].Rows[0]["cusersolicitante"])); _Txt_FirmaSol.Tag = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cusersolicitante"]);
                        _Txt_FirmaCont.Text = myUtilidad._Mtd_ObtenerUsuarioName(Convert.ToString(_Ds_A.Tables[0].Rows[0]["cuserfirmante1"])); _Txt_FirmaCont.Tag = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cuserfirmante1"]);
                        _Txt_FirmaAprob.Text = myUtilidad._Mtd_ObtenerUsuarioName(Convert.ToString(_Ds_A.Tables[0].Rows[0]["cuseraprobador"])); _Txt_FirmaAprob.Tag = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cuseraprobador"]);
                    }
                    MessageBox.Show("Transacción guardada satisfactoriamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Bol_R = true;
                    this.Close();
                }
                catch
                { _Bol_R = false; }

            }
            return _Bol_R;
        }

        public void _Mtd_Nuevo()
        {
            _Mtd_Ini();
            _Mtd_Bloquear(true);
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            _Dg_Comprobante.AutoResizeColumns();
            _Dg_Comprobante.Rows.Clear();
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Comprobante.AutoResizeColumns();
            _Tb_Tab.Selecting -= _Tb_Tab_Selecting;
            _Tb_Tab.SelectTab(1);
            _Tb_Tab.Selecting += _Tb_Tab_Selecting;
            _Cb_TpoPago.Focus();
            _Bt_FirmaSol.Enabled = true;
            _Str_MyProceso = "A";
            _Mtd_BotonesMenu();
        }
        public bool _Mtd_Guardar()
        {
            string _Str_NunCheque = "";
            string _Str_TpoDoc = "";
            string _Str_NumDoc = "";
            string _Str_OrdId = "";
            string _Str_Sql = "";
            string _Str_corder = "";
            string _Str_ctdocument = "";
            string _Str_cnumdocu = "";
            string _Str_DescripAdd = "";
            double _Dbl_TotDebe = 0;
            double _Dbl_TotHaber = 0;
            bool _Bol_Val = false;
            bool _Bol_R = false;
            if (_Str_MyProceso == "A")
            {
                if (_Txt_OrdPagoId.Text.Trim() == "")
                {
                    _Er_Error.SetError(_Txt_OrdPagoId, "Se necesita la Orden de Pago.");
                    _Bol_Val = true;
                }
                if (_Cb_TpoPago.SelectedIndex == -1)
                {
                    _Er_Error.SetError(_Cb_TpoPago, "Seleccione Un Tipo de Pago.");
                    _Bol_Val = true;
                }
                if (_Cb_FormaPago.SelectedIndex == -1)
                {
                    _Er_Error.SetError(_Cb_FormaPago, "Seleccione Una Forma de Pago.");
                    _Bol_Val = true;
                }
                if (_Cb_Banco.SelectedIndex == -1)
                {
                    _Er_Error.SetError(_Cb_Banco, "Seleccione Un Banco.");
                    _Bol_Val = true;
                }
                if (_Cb_Cuenta.SelectedIndex == -1)
                {
                    _Er_Error.SetError(_Cb_Cuenta, "Seleccione Una Cuenta.");
                    _Bol_Val = true;
                }
                if (_Txt_Concepto.Text.Trim() == "")
                {
                    _Er_Error.SetError(_Txt_Concepto, "Ingrese el Concepto.");
                    _Bol_Val = true;
                }

                if (_Mtd_VerificarSaldo())
                {
                    MessageBox.Show("Los Totales de Debe y Haber no coinciden o El total a Pagar no es igual al saldo del comprobante.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Bol_Val = true;
                }

                if (_Str_FirmaSolicitante == "")
                { MessageBox.Show("Se necesita la Firma del Solicitante.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Bol_Val = true; }


                //NUMERO DE CHEQUE
                if (Convert.ToString(_Cb_FormaPago.SelectedValue) == "CHEQ")
                {
                    if (_Cb_Cuenta.SelectedIndex != -1)
                    {
                        _Str_Sql = "Select cproxnumcheq FROM TCUENTBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cnumcuenta='" + _Cb_Cuenta.SelectedValue.ToString() + "'";
                        _Str_NunCheque = myUtilidad._Mtd_Correlativo(_Str_Sql);
                        _Txt_Doc.Text = _Str_NunCheque;
                    }
                }
                else
                {
                    _Str_NunCheque = _Txt_Doc.Text;

                }

                //if (Convert.ToString(_Cb_FormaPago.SelectedValue) == "TRANSF")
                //{
                //    //VALIDO NO ESTE LA TRANSFERENCIA
                //    DataSet _Ds_B = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT count(*) FROM VST_EMICHEQTRANSM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and cnumcheqtransac='" + _Str_NunCheque + "' AND cfpago='TRANSF'");

                //    if (Convert.ToInt16(_Ds_B.Tables[0].Rows[0][0]) > 1)
                //    {
                //        _Er_Error.SetError(_Txt_Doc, "La Transferencia ya fue registrada.");
                //        _Bol_Val = true;
                //    }
                //}


                if (!_Bol_Val)
                {
                    //GUARDO LOS DATOS
                    try
                    {
                        //ID DE EMISION
                        //-------------------------JUAN
                        if (_Str_UPDATE_TFACTPPAGARM.Trim().Length > 0)
                        {
                            _Mtd_UPDATE();
                            //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_UPDATE_TFACTPPAGARM);
                        }
                        //-------------------------JUAN

                        //-------------------------IGNACIO 12-03-2015
                        // -- Si ya existe la emision del pago para la orden de pago, salimos
                        _Str_Sql = "SELECT cidemisioncheq FROM TEMICHEQTRANSM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Txt_OrdPagoId.Text.Trim() + "'";
                        DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds_Data.Tables[0].Rows.Count > 0)
                        {
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                            MessageBox.Show("Información, otro usuario ya realizó la emisión de la orden de pago.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        //-------------------------IGNACIO 12-03-2015

                        _Str_Sql = "Select Max(cidemisioncheq) FROM TEMICHEQTRANSM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                        _Str_OrdId = myUtilidad._Mtd_Correlativo(_Str_Sql);
                        _Str_Sql = "INSERT INTO TEMICHEQTRANSM (cgroupcomp,ccompany,cidordpago,cidemisioncheq,cbanco,cnumcuentad,cnumcheqtransac,cusersolicitante,cfusersolicitante,cconcepto,cfechaemision,cidcomprob,cpagarse) VALUES('" +
                        Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Txt_OrdPagoId.Text.Trim() + "','" + _Str_OrdId + "','" +
                        Convert.ToString(_Cb_Banco.SelectedValue).Trim() + "','" + Convert.ToString(_Cb_Cuenta.SelectedValue).Trim() + "','0','" + Frm_Padre._Str_Use + "',1,'" + _Txt_Concepto.Text.Trim().ToUpper() + "','" + _Dt_ChequeEmi.Value.ToShortDateString() + "','" + _Txt_ComprobId.Text.Trim() + "','" + _Txt_Persona.Text.Trim().Replace("'","''") + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        if (Convert.ToString(_Cb_FormaPago.SelectedValue) == "CHEQ" || Convert.ToString(_Cb_FormaPago.SelectedValue) == "TRANSF")
                        {
                            //if (Convert.ToString(_Cb_FormaPago.SelectedValue) == "CHEQ")
                            //{
                            //    _Str_Sql = "UPDATE TCUENTBANC SET cproxnumcheq='" + _Str_NunCheque + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cnumcuenta='" + _Cb_Cuenta.SelectedValue.ToString() + "'";
                            //    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            //}
                            _Str_Sql = "UPDATE TPAGOSCXPM SET cidemisioncheq='" + _Str_OrdId + "',ccancelado=1,cmontototaltext='" + _Txt_CantDescrip.Text.ToUpper() + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Txt_OrdPagoId.Text + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            try
                            {
                                _Frm_OrdenPagoConstructor._Mtd_Actualizar();
                            }
                            catch { }
                        }

                        DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctdocumentopcheq,ctdocumentoptransf FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                        if (_Ds_A.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToString(_Cb_FormaPago.SelectedValue) == "CHEQ")
                            {
                                _Str_ctdocument = "'" + Convert.ToString(_Ds_A.Tables[0].Rows[0][0]).Trim().ToUpper() + "'";
                                _Str_cnumdocu = "'" + _Str_NunCheque + "'";
                            }
                            else if (Convert.ToString(_Cb_FormaPago.SelectedValue) == "TRANSF")
                            {
                                _Str_ctdocument = "'" + Convert.ToString(_Ds_A.Tables[0].Rows[0][1]).Trim().ToUpper() + "'";
                                _Str_cnumdocu = "'" + _Str_OrdId + "'";
                            }
                        }
                        else
                        { _Str_ctdocument = "null"; }
                        //ACTUALIZO EL COMPROBANTE

                        if (Convert.ToString(_Cb_FormaPago.SelectedValue) == "CHEQ")
                        { _Str_DescripAdd = " S/CHEQUE # " + _Str_NunCheque; }
                        else if (Convert.ToString(_Cb_FormaPago.SelectedValue) == "TRANSF")
                        { _Str_DescripAdd = " S/TRANSACCION # " + _Str_NunCheque; }
                        DataSet _Ds_Temp;
                        string _Str_Descripcuent = "";
                        bool _Bol_DescripCuentBancConf = false;
                        foreach (DataGridViewRow _DgRow in _Dg_Comprobante.Rows)
                        {
                            if (_DgRow.Visible)
                            {
                                if (Convert.ToString(_DgRow.Cells[0].Value) != "T")
                                {
                                    if (Convert.ToString(_DgRow.Cells[0].Value) == "")
                                    {//AGREGO UN REGISTRO
                                        _Str_corder = Convert.ToString(myUtilidad._Mtd_Consecutivo_TCOMPROBAND(_Txt_ComprobId.Text));
                                        _Str_Sql = "insert into TCOMPROBAND (ccompany,cidcomprob,corder,ccount,ctdocument,cnumdocu,cdatedocu,ctotdebe,ctothaber,cdateadd,cuseradd,cdescrip) values ('";
                                        if (myUtilidad._Mtd_CuentaContableIsBanco(Convert.ToString(_Cb_Banco.SelectedValue), Convert.ToString(_Cb_Cuenta.SelectedValue), Convert.ToString(_DgRow.Cells[1].Value)))
                                        {
                                            _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Txt_ComprobId.Text.Trim() + "','" + _Str_corder + "','" + Convert.ToString(_DgRow.Cells[1].Value).Trim() + "'," + _Str_ctdocument + "," + _Str_cnumdocu + ",'" + _Dt_Fecha.Value.ToShortDateString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[4].Value)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[5].Value)) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + Convert.ToString(_DgRow.Cells[3].Value).Trim().ToUpper().Replace("'", "''") + _Str_DescripAdd.Replace("'", "''") + ". " + _Txt_Concepto.Text.Replace("'", "''") + "')";
                                        }
                                        else
                                        {
                                            _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Txt_ComprobId.Text.Trim() + "','" + _Str_corder + "','" + Convert.ToString(_DgRow.Cells[1].Value).Trim() + "'," + _Str_ctdocument + "," + _Str_cnumdocu + ",'" + _Dt_Fecha.Value.ToShortDateString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[4].Value)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[5].Value)) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','" + Convert.ToString(_DgRow.Cells[3].Value).Trim().ToUpper().Replace("'", "''") + "')";
                                        }
                                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    }
                                    else
                                    {//MODIFICO EL REGISTRO
                                        //VERIFICO SI LA CUENTA ES DEL BANCO
                                        /////////////////////////////////
                                        if (myUtilidad._Mtd_CuentaContableIsBanco(Convert.ToString(_Cb_Banco.SelectedValue), Convert.ToString(_Cb_Cuenta.SelectedValue), Convert.ToString(_DgRow.Cells[1].Value)) && CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[5].Value)) == CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Monto.Text)) && !_Bol_DescripCuentBancConf)
                                        {
                                            _Bol_DescripCuentBancConf = true;
                                            _Str_Descripcuent = "SELECT cname from TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + Convert.ToString(_DgRow.Cells[1].Value).Trim() + "'";
                                            _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Descripcuent);
                                            if (_Ds_Temp.Tables[0].Rows.Count > 0)
                                            { _Str_Descripcuent = _Ds_Temp.Tables[0].Rows[0][0].ToString().ToUpper() + " "; }
                                            _Str_Sql = "UPDATE TCOMPROBAND SET ccount='" + Convert.ToString(_DgRow.Cells[1].Value).Trim() + "',ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[4].Value)) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[5].Value)) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdescrip='" + _Str_Descripcuent.Replace("'", "''") + "<REPLACE>" + ". '";
                                            //_Str_Sql = "UPDATE TCOMPROBAND SET ccount='" + Convert.ToString(_DgRow.Cells[1].Value).Trim() + "',ctdocument=" + _Str_ctdocument + ",cnumdocu=" + _Str_cnumdocu + ",cdatedocu='" + _Dt_Fecha.Value.ToShortDateString() + "',ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[4].Value)) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[5].Value)) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdescrip='" + _Str_Descripcuent + "<REPLACE>" + ". " + _Txt_Concepto.Text + "'";
                                            //_Str_Sql = "UPDATE TCOMPROBAND SET ccount='" + Convert.ToString(_DgRow.Cells[1].Value).Trim() + "',ctdocument=" + _Str_ctdocument + ",cnumdocu=" + _Str_cnumdocu + ",cdatedocu='" + _Dt_Fecha.Value.ToShortDateString() + "',ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[4].Value)) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[5].Value)) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdescrip='" + Convert.ToString(_DgRow.Cells[3].Value).Trim().ToUpper() + _Str_DescripAdd + ". " + _Txt_Concepto.Text + "'";
                                        }
                                        else
                                        {
                                            _Str_Descripcuent = "SELECT cname from TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + Convert.ToString(_DgRow.Cells[1].Value).Trim() + "'";
                                            _Ds_Temp = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Descripcuent);
                                            if (_Ds_Temp.Tables[0].Rows.Count > 0)
                                            { _Str_Descripcuent = _Ds_Temp.Tables[0].Rows[0][0].ToString().ToUpper() + " "; }
                                            if (_Txt_OrdPagoId.Text.Trim().Length > 0)
                                            {
                                                if (_Mtd_OrdenReposicion(Convert.ToInt32(_Txt_OrdPagoId.Text)))
                                                { _Str_Descripcuent = ""; }
                                            }
                                            if (Convert.ToString(_DgRow.Cells[3].Value).Trim().ToUpper().IndexOf("<REPLACEIGTFBANCO>") != -1)
                                            {
                                                _Str_Sql = "UPDATE TCOMPROBAND SET ccount='" + Convert.ToString(_DgRow.Cells[1].Value).Trim() + "',ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[4].Value)) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[5].Value)) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdescrip='" + _Str_Descripcuent.Replace("'","''") + "<REPLACE>" + ". '";
                                            }
                                            else if(Convert.ToString(_DgRow.Cells[3].Value).Trim().ToUpper().IndexOf("<REPLACEIGTF>") != -1)
                                            {
                                                _Str_Sql = "UPDATE TCOMPROBAND SET ccount='" + Convert.ToString(_DgRow.Cells[1].Value).Trim() + "',ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[4].Value)) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[5].Value)) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdescrip='" + _Str_Descripcuent.Replace("'", "''") + "<REPLACEIGTF>" + ". '";
                                            }
                                            else
                                            {
                                                _Str_Sql = "UPDATE TCOMPROBAND SET ccount='" + Convert.ToString(_DgRow.Cells[1].Value).Trim() + "',ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[4].Value)) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[5].Value)) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdescrip='" + _Str_Descripcuent.Replace("'", "''") + Convert.ToString(_DgRow.Cells[3].Value).Trim().ToUpper().Replace("'", "''") + "'";
                                            }
                                            //_Str_Sql = "UPDATE TCOMPROBAND SET ccount='" + Convert.ToString(_DgRow.Cells[1].Value).Trim() + "',ctdocument=" + _Str_ctdocument + ",cnumdocu=" + _Str_cnumdocu + ",cdatedocu='" + _Dt_Fecha.Value.ToShortDateString() + "',ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[4].Value)) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[5].Value)) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdescrip='" + _Str_Descripcuent + Convert.ToString(_DgRow.Cells[3].Value).Trim().ToUpper() + "'";
                                            //_Str_Sql = "UPDATE TCOMPROBAND SET ccount='" + Convert.ToString(_DgRow.Cells[1].Value).Trim() + "',ctdocument=" + _Str_ctdocument + ",cnumdocu=" + _Str_cnumdocu + ",cdatedocu='" + _Dt_Fecha.Value.ToShortDateString() + "',ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[4].Value)) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_DgRow.Cells[5].Value)) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdescrip='" + Convert.ToString(_DgRow.Cells[3].Value).Trim().ToUpper() + "'"; 
                                        }
                                        _Str_Sql = _Str_Sql + " WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Txt_ComprobId.Text + "' AND corder='" + Convert.ToString(_DgRow.Cells[0].Value) + "'";
                                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                    }
                                    if (Convert.ToString(_DgRow.Cells[4].Value).Trim() != "")
                                    {
                                        _Dbl_TotDebe = _Dbl_TotDebe + Convert.ToDouble(_DgRow.Cells[4].Value);
                                    }
                                    if (Convert.ToString(_DgRow.Cells[5].Value).Trim() != "")
                                    {
                                        _Dbl_TotHaber = _Dbl_TotHaber + Convert.ToDouble(_DgRow.Cells[5].Value);
                                    }
                                }
                            }
                            else
                            {
                                if (Convert.ToString(_DgRow.Cells[0].Value) != "")
                                {
                                    _Str_Sql = "DELETE FROM TCOMPROBAND";
                                    _Str_Sql = _Str_Sql + " WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Txt_ComprobId.Text + "' AND corder='" + Convert.ToString(_DgRow.Cells[0].Value) + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                                }
                            }
                        }
                        //MODIFICO LOS TOTALES DE DEBE Y HABER Y ACTIVO EL FLAG
                        _Str_Sql = "UPDATE TCOMPROBANC SET ctotdebe=" + _Dbl_TotDebe.ToString().Replace(",", ".") + ",ctothaber=" + _Dbl_TotHaber.ToString().Replace(",", ".");
                        _Str_Sql = _Str_Sql + " WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Txt_ComprobId.Text + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        _Txt_EmisionId.Text = _Str_OrdId;
                        _Txt_Doc.Text = _Str_NunCheque;
                        _Mtd_Bloquear(false);
                        _Dt_ChequeEmi.Enabled = false;
                        _Dt_Fecha.Enabled = false;
                        _Str_MyProceso = "";
                        _Mtd_BotonesMenu();
                        _Mtd_CargarBusqueda();
                        _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cusersolicitante,cuserfirmante1,cuseraprobador FROM TEMICHEQTRANSM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidemisioncheq='" + _Txt_EmisionId.Text + "'");
                        if (_Ds_A.Tables[0].Rows.Count > 0)
                        {
                            _Txt_FirmaSol.Text = myUtilidad._Mtd_ObtenerUsuarioName(Convert.ToString(_Ds_A.Tables[0].Rows[0]["cusersolicitante"])); _Txt_FirmaSol.Tag = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cusersolicitante"]);
                            _Txt_FirmaCont.Text = myUtilidad._Mtd_ObtenerUsuarioName(Convert.ToString(_Ds_A.Tables[0].Rows[0]["cuserfirmante1"])); _Txt_FirmaCont.Tag = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cuserfirmante1"]);
                            _Txt_FirmaAprob.Text = myUtilidad._Mtd_ObtenerUsuarioName(Convert.ToString(_Ds_A.Tables[0].Rows[0]["cuseraprobador"])); _Txt_FirmaAprob.Tag = Convert.ToString(_Ds_A.Tables[0].Rows[0]["cuseraprobador"]);
                        }
                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                        MessageBox.Show("Transacción guardada satisfactoriamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        _Bol_R = true;
                    }
                    catch
                    { _Bol_R = false; }
                }
            }
            return _Bol_R;
        }

        private void _Cb_FormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _Str_SQL, _Str_Cor;
            if (_Str_MyProceso != "")
            {
                if (Convert.ToString(_Cb_FormaPago.SelectedValue) == "CHEQ")
                {
                    if (_Cb_Cuenta.SelectedIndex != -1)
                    {
                        _Lb_Doc.Text = "Nº de Cheque:";
                        //_Str_SQL = "Select cproxnumcheq FROM TCUENTBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cnumcuenta='" + _Cb_Cuenta.SelectedValue.ToString() + "'";
                        //_Str_Cor = myUtilidad._Mtd_Correlativo(_Str_SQL);
                        //_Txt_Doc.Text = _Str_Cor;
                        _Txt_Doc.Enabled = false;
                    }
                }
                else if (Convert.ToString(_Cb_FormaPago.SelectedValue) == "TRANSF")
                { _Lb_Doc.Text = "Nº de Trans:"; _Txt_Doc.Enabled = false; _Txt_Doc.Text = ""; }
                else
                { _Txt_Doc.Text = ""; _Lb_Doc.Text = "Documento:"; }
            }
        }

        private void _Mtd_CargarBancos()
        {
            string _Str_Sql = "";
            DataSet _Ds_A;
            _Cb_Banco.DataSource = null;
            _Str_Sql = "SELECT cbanco,cname FROM TBANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Cb_Banco.DataSource = _Ds_A.Tables[0];
            _Cb_Banco.DisplayMember = _Ds_A.Tables[0].Columns[1].ColumnName;
            _Cb_Banco.ValueMember = _Ds_A.Tables[0].Columns[0].ColumnName;
            _Cb_Banco.SelectedIndex = -1;
        }

        private void _Mtd_CargarFormaPago()
        {
            DataSet _Ds_ = new DataSet();
            _Ds_.Tables.Add("Tabla");
            _Ds_.Tables[0].Columns.Add("clave");
            _Ds_.Tables[0].Columns.Add("descripcion");
            DataRow _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["clave"] = "CHEQ";
            _DRow_["descripcion"] = "Cheque";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["clave"] = "TRANSF";
            _DRow_["descripcion"] = "Transferencia";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            _Cb_FormaPago.DisplayMember = "descripcion";
            _Cb_FormaPago.ValueMember = "clave";
            _Cb_FormaPago.DataSource = _Ds_.Tables[0];
            _Cb_FormaPago.SelectedIndex = -1;
        }

        private void _Mtd_CargarTpoPago()
        {
            DataSet _Ds_ = new DataSet();
            _Ds_.Tables.Add("Tabla");
            _Ds_.Tables[0].Columns.Add("clave");
            _Ds_.Tables[0].Columns.Add("descripcion");
            DataRow _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["clave"] = "ABO";
            _DRow_["descripcion"] = "Abono";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["clave"] = "PTOT";
            _DRow_["descripcion"] = "Pago Total";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            _Cb_TpoPago.DisplayMember = "descripcion";
            _Cb_TpoPago.ValueMember = "clave";
            _Cb_TpoPago.DataSource = _Ds_.Tables[0];
            _Cb_TpoPago.SelectedIndex = -1;
        }

        private void _Mtd_UsuarioSts(string _Str_UserId)
        {
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cname,cposition,cfirmante FROM TUSER WHERE cuser='" + _Str_UserId + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                _Str_Usuario = _Str_UserId;
                _Str_UsuarioName = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]);
                _Str_UsuarioFirma = Convert.ToString(_Ds_A.Tables[0].Rows[0][2]);
                _Str_UsuarioCargo = Convert.ToString(_Ds_A.Tables[0].Rows[0][1]);
            }
            else
            { _Str_UsuarioFirma = ""; _Str_UsuarioCargo = ""; _Str_UsuarioName = ""; }
        }

        private void _Mtd_CargarCtaBanco(string _Pr_Str_Banco)
        {
            string _Str_Sql = "";
            DataSet _Ds_A;
            _Cb_Cuenta.DataSource = null;
            _Str_Sql = "SELECT cnumcuenta,cname FROM TCUENTBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cbanco='" + _Pr_Str_Banco + "'";
            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Cb_Cuenta.DataSource = _Ds_A.Tables[0];
            _Cb_Cuenta.DisplayMember = _Ds_A.Tables[0].Columns[1].ColumnName;
            _Cb_Cuenta.ValueMember = _Ds_A.Tables[0].Columns[0].ColumnName;
            _Cb_Cuenta.SelectedIndex = -1;
        }

        private void _Cb_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cb_Banco.SelectedIndex != -1)
            {//CARGO LAS CUENTAS
                _Mtd_CargarCtaBanco(Convert.ToString(_Cb_Banco.SelectedValue));
            }
        }

        public void _Mtd_CargarBusqueda()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Sql = "";
            _Str_Sql = "SELECT cidemisioncheq,cconcepto,c_nomb_abreviado,dbo.Fnc_Formatear(cmontototal) AS cmontototal, cproveedor,cimpimiocheqdescrip,centregadodescrip,cpagarse,cidordpago,cbanconame FROM VST_EMICHEQTRANSM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND canulado='0'";
            if (_Cb_ProveedorFind.SelectedIndex > 0)
            { _Str_Sql = _Str_Sql + " AND cproveedor='" + Convert.ToString(_Cb_ProveedorFind.SelectedValue) + "'"; }
            if (_Cb_TpoProveFind.SelectedIndex > 0)
            { _Str_Sql = _Str_Sql + " AND cglobal=" + Convert.ToString(_Cb_TpoProveFind.SelectedValue); }
            if (_Cb_CatProveFind.SelectedIndex > 0)
            {
                _Str_Sql = _Str_Sql + " AND ccatproveedor='" + Convert.ToString(_Cb_CatProveFind.SelectedValue) + "'";
            }
            if (_Str_InForm == "")
            {
                _Str_Sql = _Str_Sql + " AND centregado='" + Convert.ToInt32(_Rb_Entregados.Checked) + "'";
            }
            else if (_Str_InForm == "1" || _Str_InForm == "2")
            { _Str_Sql = _Str_Sql + " AND cimpimiocheq=0"; }
            else if (_Str_InForm == "3")
            {
                _Str_Sql = _Str_Sql + " AND centregado='" + Convert.ToInt32(_Rb_Entregados.Checked) + "' AND cimpimiocheq=1";
            }

            if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1")
            {
                //if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_CHEQUE_SOL"))
                //{
                //    _Str_Sql = _Str_Sql + " AND ((cfuserfirmante1=0 AND cfuseraprobador=0) OR (cfusersolicitante=1))";// AND cusersolicitante='" + Frm_Padre._Str_Use + "'))";
                //}
                //else 
                if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_CHEQUE_CONT") & _Str_TipoTabs == "F_CONT")
                {
                    if (_Str_InForm != "2")
                    {
                        _Str_Sql = _Str_Sql + " AND ((cfusersolicitante=1 AND cfuserfirmante1=0) OR (cfuserfirmante1=1 AND cuserfirmante1='" + Frm_Padre._Str_Use + "'))";
                    }
                    else
                    {
                        _Str_Sql = _Str_Sql + " AND (cfusersolicitante=1 AND cfuserfirmante1=0)";
                    }
                }
                else if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_CHEQUE_FIRMA") & _Str_TipoTabs == "F_APROB")
                {
                    if (_Str_InForm != "2")
                    {
                        _Str_Sql = _Str_Sql + " AND ((cfusersolicitante=1 AND cfuserfirmante1=1 AND cfuseraprobador=0) OR (cfuseraprobador=1 AND cuseraprobador='" + Frm_Padre._Str_Use + "'))";
                    }
                    else
                    {
                        _Str_Sql = _Str_Sql + " AND (cfusersolicitante=1 AND cfuserfirmante1=1 AND cfuseraprobador=0)";
                    }
                }
                else if (_Str_TipoTabs.Trim().Length == 0)
                {
                    if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_CHEQUE_IMP"))
                    { _Str_Sql = _Str_Sql + " AND (cfusersolicitante=1 AND cfuserfirmante1=1 AND cfuseraprobador=1 AND cfpago='CHEQ')"; }
                    else if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_TRANSF_IMP"))
                    { _Str_Sql = _Str_Sql + " AND (cfusersolicitante=1 AND cfuserfirmante1=1 AND cfuseraprobador=1 AND cfpago='TRANSF')"; }
                    else if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_CHEQUE_IMP") & myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_TRANSF_IMP"))
                    { _Str_Sql = _Str_Sql + " AND (cfusersolicitante=1 AND cfuserfirmante1=1 AND cfuseraprobador=1)"; }
                    if (_Rb_PorEntregar.Checked)
                    { _Str_Sql = _Str_Sql.Replace("TRANSF", "CHEQ"); }
                }
                else
                {
                    if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_CHEQUE_IMP") | myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_TRANSF_IMP"))
                    { _Str_Sql = _Str_Sql + " AND (cfusersolicitante=1 AND cfuserfirmante1=1 AND cfuseraprobador=1 AND cfpago='" + _Str_TipoTabs + "')"; }
                }

            }
            if (_Rb_Entregados.Checked)
            {
                _Str_Sql = _Str_Sql + " AND (CONVERT(DATETIME,CONVERT(VARCHAR,cfechaemision,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dt_Desde.Value) + "' AND '" + _Cls_Formato._Mtd_fecha(_Dt_Hasta.Value) + "')";
            }
            _Str_Sql = _Str_Sql + " ORDER BY cidemisioncheq";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            object[] _Str_RowNew = new object[_Ds_Data.Tables[0].Columns.Count];
            _Dg_Find.Rows.Clear();
            foreach (DataRow _DataR in _Ds_Data.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_Find.Rows.Add(_Str_RowNew);
            }
            _Dg_Find.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Find.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _Dg_Find.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Find.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Cursor = Cursors.Default;
        }
        private void _Mtd_CargarRifCedula(string _Str_IdOrdenPago, string _Str_Compania)
        {
            _Txt_RifCedula.Text = "";
            string _Str_SQL = "SELECT CRIF FROM TPAGOSCXPM WHERE cidordpago='" + _Str_IdOrdenPago + "' AND CCOMPANY='" + _Str_Compania + "'";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                _Txt_RifCedula.Text = _Ds_Data.Tables[0].Rows[0]["CRIF"].ToString();
            }
        }
        System.Data.SqlClient.SqlDataAdapter _MyDa;
        private DataSet _Mtd_GetDataSet(string _Pr_Str_Sql)
        {
            DataSet _Ds = new DataSet();
            _MyDa = new SqlDataAdapter(_Pr_Str_Sql, Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            _MyDa.Fill(_Ds);
            //_MyDa.Dispose();
            //_MyDa = null;
            return _Ds;
        }
        private void _Mtd_CargarData(string _Pr_Str_Id, string _Pr_Str_IdOP)
        {
            bool _Sw_DatosCargados = false;

            //El metodo se mantendra consultando la vista hasta que obtenga un registro con los campos no vacios.
            while (!_Sw_DatosCargados)
            {
                string _Str_Sql = "";
                _Str_Sql = "SELECT * FROM VST_EMICHEQTRANSM WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidemisioncheq='" + _Pr_Str_Id + "' AND cidordpago='" + _Pr_Str_IdOP + "'";
                // Eliminamos el uso de la DLL del terror....
                // DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                DataSet _Ds_Data = _Mtd_GetDataSet(_Str_Sql); //Usamos la conexión directa recomendada por Juan
                if (_Ds_Data.Tables[0].Rows.Count > 0)
                {
                    _Txt_EmisionId.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cidemisioncheq"]);
                    _Txt_OrdPagoId.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cidordpago"]);
                    _Cb_TpoPago.SelectedValue = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ctippago"]);
                    _Cb_FormaPago.SelectedValue = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cfpago"]);
                    _Cb_Banco.SelectedValue = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cbanco"]);
                    _Mtd_CargarCtaBanco(Convert.ToString(_Cb_Banco.SelectedValue));
                    _Cb_Cuenta.SelectedValue = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cnumcuentad"]);
                    _Txt_Doc.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cnumcheqtransac"]);
                    _Txt_Monto.Text = Convert.ToDouble(_Ds_Data.Tables[0].Rows[0]["cmontototal"]).ToString("#,##0.00");
                    _Txt_CantDescrip.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cmontototaltext"]);
                    if (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["c_nomb_fiscal"]).Trim().Length == 0)
                    {
                        _Txt_Persona.Tag = 0;
                    }
                    else
                    {
                        _Txt_Persona.Tag = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cproveedor"]);
                    }
                    _Txt_Persona.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cpagarse"]);
                    _Dt_Fecha.Value = Convert.ToDateTime(_Ds_Data.Tables[0].Rows[0]["cfecha"]);
                    _Dt_ChequeEmi.MinDate = Convert.ToDateTime(_Ds_Data.Tables[0].Rows[0]["cfechaemision"]);
                    _Dt_ChequeEmi.Value = Convert.ToDateTime(_Ds_Data.Tables[0].Rows[0]["cfechaemision"]);
                    _Txt_Concepto.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cconcepto"]);
                    _Mtd_CargarRifCedula(_Txt_OrdPagoId.Text, Frm_Padre._Str_Comp);
                    _Txt_FirmaSol.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cusersolicitantename"]);
                    _Txt_FirmaSol.Tag = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cusersolicitante"]);
                    _Str_FirmaSolicitante = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cfusersolicitante"]);
                    if (_Str_FirmaSolicitante == "1")
                    {
                        _Bt_FirmaSol.Enabled = false;
                    }
                    else if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_CHEQUE_SOL"))
                    {
                        _Bt_FirmaSol.Enabled = true;
                    }
                    else
                    {
                        _Bt_FirmaSol.Enabled = false;
                    }

                    _Txt_FirmaCont.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cuserfirmante1name"]);
                    _Txt_FirmaCont.Tag = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cuserfirmante1"]);
                    _Str_FirmaContable = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cfuserfirmante1"]);
                    if (_Str_FirmaContable == "1")
                    {
                        _Bt_FirmaCont.Enabled = false;
                    }
                    else if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_CHEQUE_CONT") && _Str_TipoTabs == "F_CONT")
                    {
                        _Bt_FirmaCont.Enabled = true;
                    }
                    else
                    {
                        _Bt_FirmaCont.Enabled = false;
                    }
                    _Txt_FirmaAprob.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cuseraprobadorname"]);
                    _Txt_FirmaAprob.Tag = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cuseraprobador"]);
                    _Str_FirmaAprobador = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cfuseraprobador"]);
                    if (_Str_FirmaAprobador == "1")
                    {
                        _Bt_FirmaAprob.Enabled = false;
                        _Bt_EliminarApr.Enabled = myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1"
                            && myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_ANUL_CHEQ_SOLO_SISTEMA")
                            && Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cimpimiocheq"]).Trim()=="0"
                            && Convert.ToString(_Ds_Data.Tables[0].Rows[0]["canulado"]).Trim() == "0";
                    }
                    else if (myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_CHEQUE_FIRMA") && _Str_TipoTabs == "F_APROB")
                    {
                        _Bt_FirmaAprob.Enabled = true;
                    }
                    else
                    {
                        _Bt_FirmaAprob.Enabled = false;
                    }
                    _Txt_ComprobId.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cidcomprob"]);
                    _Mtd_CargarComprobante(_Txt_ComprobId.Text);
                }

                //Verifico si se cargaron datos
                if (
                       (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cidemisioncheq"]).Length > 0)
                    && (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cidordpago"]).Length > 0)
                    && (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ctippago"]).Length > 0)
                    && (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cfpago"]).Length > 0)
                    && (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cbanco"]).Length > 0)
                    && (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cnumcheqtransac"]).Length  > 0)
                    )
                {
                    _Sw_DatosCargados = true;
                }


            }
        }

        public void _Mtd_Habilitar()
        {
            _Mtd_Bloquear(true);
            _Cb_TpoPago.Enabled = false;
            _Cb_FormaPago.Enabled = false;
            _Cb_Banco.Enabled = false;
            _Cb_Cuenta.Enabled = false;
            _Txt_Concepto.Enabled = false;
            _Txt_Persona.Enabled = false;
            _Bt_OrdPagoGo.Enabled = false;
            if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_CHEQUE_CONT") && _Txt_FirmaCont.Text.Trim() == "")
            { _Bt_EditarComprob.Enabled = true; }
            else
            { _Bt_EditarComprob.Enabled = false; }
            _Tb_Tab.SelectTab(1);
            _Str_MyProceso = "M";
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

        private void _Mtd_CargarProvee()
        {
            string _Str_Sql = "";
            _Str_Sql = "SELECT DISTINCT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_abreviado FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1'";
            if (Convert.ToString(_Cb_TpoProveFind.SelectedValue) == "1")
            {
                _Str_Sql = _Str_Sql + " AND (cglobal='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "')";
                if (_Cb_CatProveFind.SelectedIndex > 0)
                { _Str_Sql = _Str_Sql + " AND TPROVEEDOR.ccatproveedor='" + _Cb_CatProveFind.SelectedValue.ToString() + "'"; }
            }
            else if (_Cb_TpoProveFind.SelectedIndex > 0)
            {
                _Str_Sql = _Str_Sql + " AND (cglobal='" + _Cb_TpoProveFind.SelectedValue.ToString() + "' AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "')";
                if (_Cb_CatProveFind.SelectedIndex > 0 && _Cb_CatProveFind != null)
                { _Str_Sql = _Str_Sql + " and TPROVEEDOR.ccatproveedor='" + _Cb_CatProveFind.SelectedValue.ToString() + "'"; }
            }
            else
            { _Str_Sql = _Str_Sql + " AND ((cglobal='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "') OR (cglobal<>'1' AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "'))"; }
            //_Str_Sql = _Str_Sql + " ORDER BY TPROVEEDOR.c_nomb_abreviado";

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

        private void _Mtd_CargarCatProve(string _P_Str_Tipo)
        {
            myUtilidad._Mtd_CargarCombo(_Cb_CatProveFind, "Select ccatproveedor,cnombre from TCATPROVEEDOR where cdelete='0' and cglobal='" + _P_Str_Tipo + "'");
        }

        private void _Mtd_Sorted(DataGridView _Dg_My)
        {
            for (int _Int_i = 0; _Int_i < _Dg_My.Columns.Count; _Int_i++)
            {
                _Dg_My.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void _Bt_Find_Click(object sender, EventArgs e)
        {
            _Mtd_CargarBusqueda();
        }

        private void _Cb_TpoProveFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Int_SwProvTpo == 0)
            {
                if (_Cb_TpoProveFind.SelectedIndex > 0)
                {
                    _Mtd_CargarCatProve(_Cb_TpoProveFind.SelectedValue.ToString());
                }
                else
                {
                    _Cb_CatProveFind.DataSource = null;
                    _Mtd_CargarProvee();
                    _Cb_ProveedorFind.SelectedIndex = 0;
                }
            }
        }

        private void _Cb_CatProveFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Int_SwProvTpo == 0)
            {
                if (_Cb_CatProveFind.SelectedIndex > 0)
                {
                    _Mtd_CargarProvee();
                }
                else
                {
                    _Mtd_CargarProvee();
                    _Cb_ProveedorFind.SelectedIndex = 0;
                }
            }
        }

        private void _Cb_ProveedorFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _Str_Sql = "";
            if (_Int_SwProvCarga == 0)
            {
                if (_Cb_ProveedorFind.SelectedIndex > 0)
                {
                    _Str_Sql = "Select cglobal,ccatproveedor from TPROVEEDOR WHERE cdelete=0" +
                           " AND (ccompany='" + Frm_Padre._Str_Comp + "' or cglobal=1) AND cproveedor='" + Convert.ToString(_Cb_ProveedorFind.SelectedValue) + "'";
                    DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    {//CARGO EL TIPO Y CATEGORIA EN LOS COMBOS
                        _Int_SwProvTpo = 1;
                        _Cb_TpoProveFind.SelectedValue = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]);
                        _Mtd_CargarCatProve(Convert.ToString(_Cb_TpoProveFind.SelectedValue));
                        _Cb_CatProveFind.SelectedValue = Convert.ToString(_Ds_A.Tables[0].Rows[0][1]);
                        _Int_SwProvTpo = 0;
                    }
                }
                else
                {
                    if (_Cb_TpoProveFind.SelectedIndex <= 0)
                    {
                        _Cb_CatProveFind.DataSource = null;
                    }
                }
            }
        }

        private void _Dg_Find_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                if (_Dg_Find.RowCount >= 0)
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_Ini();
                    _Mtd_CargarData(Convert.ToString(_Dg_Find["cidemisioncheq", e.RowIndex].Value),
                                    Convert.ToString(_Dg_Find["cidordpago", e.RowIndex].Value));
                    _Mtd_BotonesMenu();
                    if (Convert.ToString(_Cb_FormaPago.SelectedValue) == "CHEQ" |
                        Convert.ToString(_Cb_FormaPago.SelectedValue) == "TRANSF")
                    {
                        _Bt_ChequeVer.Enabled = true;
                    }
                    else
                    {
                        _Bt_ChequeVer.Enabled = false;
                    }
                    if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_CHEQUE_CONT") &&
                        _Txt_FirmaCont.Text.Trim() == "")
                    {
                        _Bt_EditarComprob.Enabled = true;
                    }
                    else
                    {
                        _Bt_EditarComprob.Enabled = false;
                    }
                    _Tb_Tab.SelectedIndex = 1;
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception _Ex)
            {
                MessageBox.Show("Por favor no cierre esta ventana hasta que envíe un control de fallas, gracias.\n" + _Ex,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void _Bt_FirmaSol_Click(object sender, EventArgs e)
        {
            if (_Str_MyProceso == "A")
            {
                if (_Pnl_Clave.Visible)
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_Guardar();
                    Cursor = Cursors.Default;
                }
                else
                {
                    _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                    _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
                    _Lbl_TituloClave.Text = "Firma del Solicitante";
                    _Pnl_Clave.Visible = true;
                    _Str_TpoUsu = "S";
                }
            }
        }

        private void _Bt_FirmaCont_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Pnl_Clave.BringToFront();
            _Lbl_TituloClave.Text = "Firma del Contador";
            _Pnl_Clave.Visible = true;
            _Str_TpoUsu = "C";
        }
        private int _Mtd_RetornarTipoProveedor(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT ISNULL(cglobal,0) FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' or cglobal=1) AND cproveedor='" + _P_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString().Trim());
            }
            return -1;
        }
        private bool _Mtd_VerificarLimiteOrdenPago()
        {
            double _Dbl_Monto = 0;
            string _Str_Cadena = "SELECT cmontototal,cotrospago,cproveedor FROM TPAGOSCXPM WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Txt_OrdPagoId.Text + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0]["cmontototal"].ToString().Trim().Length > 0)
                {
                    _Dbl_Monto = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototal"]);
                    if (_Ds.Tables[0].Rows[0]["cotrospago"].ToString().Trim() == "1")
                    {
                        if (_Mtd_RetornarTipoProveedor(_Ds.Tables[0].Rows[0]["cproveedor"].ToString().Trim()) == -1)
                        { _Str_Cadena = "SELECT cmontlimited,cmontlimiteh FROM TPAGOSCXPP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cusuariop='" + Frm_Padre._Str_Use + "' AND ctipoproveedor='2' AND '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "'<=cmontlimiteh"; }
                        else
                        { _Str_Cadena = "SELECT cmontlimited,cmontlimiteh FROM TPAGOSCXPP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cusuariop='" + Frm_Padre._Str_Use + "' AND ctipoproveedor=(SELECT cglobal FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' or cglobal=1) AND cproveedor='" + _Ds.Tables[0].Rows[0]["cproveedor"].ToString().Trim() + "') AND '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "'<=cmontlimiteh"; }
                    }
                    else
                    { _Str_Cadena = "SELECT cmontlimited,cmontlimiteh FROM TPAGOSCXPP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cusuariop='" + Frm_Padre._Str_Use + "' AND ctipoproveedor=(SELECT cglobal FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' or cglobal=1) AND cproveedor='" + _Ds.Tables[0].Rows[0]["cproveedor"].ToString().Trim() + "') AND '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "'<=cmontlimiteh"; }
                    return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
                }
            }
            return false;
        }
        private void _Bt_FirmaAprob_Click(object sender, EventArgs e)
        {
            if (_Mtd_VerificarLimiteOrdenPago())
            {
                _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
                _Pnl_Clave.BringToFront();
                _Lbl_TituloClave.Text = "Firma del Aprobador";
                _Pnl_Clave.Visible = true;
                _Str_TpoUsu = "A";
            }
            else
            { MessageBox.Show("No es posible realizar la operación. El monto está fuera de sus límites de pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Mtd_Firmar(string _Pr_Str_Opt)
        {
            string _Str_Sql = "";
            //cargo el formulario de clave
            if (_Txt_Clave.Text != "")
            {
                byte[] hash = _Mtd_ConvertStringToByteArray(_Txt_Clave.Text);
                byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
                string cod = BitConverter.ToString(valorhash);
                cod = cod.Replace("-", "");
                _Str_Sql = "SELECT cpassw FROM TUSER WHERE cuser= '" + Frm_Padre._Str_Use + "' and cpassw='" + cod + "'";
                DataSet _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                switch (_Pr_Str_Opt)
                {
                    case "S"://SOLICITANTE
                        if (_Ds2.Tables[0].Rows.Count > 0)
                        {//COINCIDE
                            _Str_FirmaSolicitante = "1";
                            _Pnl_Clave.Visible = false;
                            _Mtd_Guardar();
                        }
                        else
                        {
                            MessageBox.Show("Contraseña Incorrecta del Solicitante.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            _Str_FirmaSolicitante = "";
                        }
                        break;
                    case "C"://CONTADOR
                        if (_Ds2.Tables[0].Rows.Count > 0)
                        {//COINCIDE
                            _Str_FirmaContable = "1";
                            _Pnl_Clave.Visible = false;
                            //GUARDO LA FIRMA
                            _Str_Sql = "UPDATE TEMICHEQTRANSM SET cfuserfirmante1=1, cuserfirmante1='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Txt_OrdPagoId.Text + "' AND cidemisioncheq='" + _Txt_EmisionId.Text + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            _Txt_FirmaCont.Text = myUtilidad._Mtd_ObtenerUsuarioName(Frm_Padre._Str_Use); _Txt_FirmaCont.Tag = Frm_Padre._Str_Use;
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                            //GENERO LAS NOTAS DE CREDITO
                            //_Mtd_GenerarNCxDescxPPago();
                            //_Bt_FirmaCont.Enabled = false;
                            //this.Close();
                            _Mtd_CargarBusqueda();
                            _Tb_Tab.SelectedIndex = 0;
                        }
                        else
                        {
                            MessageBox.Show("Contraseña Incorrecta del Contador.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            _Str_FirmaContable = "";
                        }
                        break;
                    case "A"://APROBADOR
                        if (_Ds2.Tables[0].Rows.Count > 0)
                        {//COINCIDE
                            _Str_FirmaAprobador = "1";
                            _Pnl_Clave.Visible = false;
                            //GUARDO LA FIRMA
                            _Str_Sql = "UPDATE TEMICHEQTRANSM SET cfuseraprobador=1, cuseraprobador='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Txt_OrdPagoId.Text + "' AND cidemisioncheq='" + _Txt_EmisionId.Text + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                            _Txt_FirmaAprob.Text = myUtilidad._Mtd_ObtenerUsuarioName(Frm_Padre._Str_Use); _Txt_FirmaAprob.Tag = Frm_Padre._Str_Use;
                            //_Bt_FirmaAprob.Enabled = false;
                            //this.Close();
                            _Mtd_CargarBusqueda();
                            _Tb_Tab.SelectedIndex = 0;
                        }
                        else
                        {
                            MessageBox.Show("Contraseña Incorrecta del Aprobador.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            _Str_FirmaAprobador = "";
                        }
                        break;
                    default:
                        _Str_FirmaAprobador = "";
                        _Str_FirmaContable = "";
                        _Str_FirmaSolicitante = "";
                        _Pnl_Clave.Visible = false;
                        break;
                }
            }
        }

        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }

        private void _Bt_OrdPagoGo_Click(object sender, EventArgs e)
        {
            Frm_OrdenPago _Frm_OrdenPago = new Frm_OrdenPago();
            _Frm_OrdenPago.MdiParent = this.MdiParent;
            //_Frm_OrdenPago._Int_Block = 1;
            _Frm_OrdenPago.Show();
        }

        private void Frm_EmisionCheque_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
            myUtilidad._Mtd_CerrarFormHijo((Frm_Padre)this.MdiParent, "Frm_ChequeVer");
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            _Txt_Clave.Text = "";
            if (_Pnl_Clave.Visible)
            {
                _Tb_Tab.Enabled = false;
                _Txt_Clave.Focus();
            }
            else
            { _Tb_Tab.Enabled = true; _Lbl_TituloClave.Text = "..."; }
        }

        private void _Bt_Ok_Click(object sender, EventArgs e)
        {
            if (_Str_TpoUsu != "")
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Firmar(_Str_TpoUsu);
                Cursor = Cursors.Default;
                _Pnl_Clave.Visible = false;
                //if (Convert.ToString(_Cb_FormaPago.SelectedValue) != "TRANSF")
                //{
                //    if (!_Pnl_ComprobClave.Visible)
                //    { this.Close(); }
                //}
            }
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Bt_ChequeVer_Click(object sender, EventArgs e)
        {

            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT * FROM TEMICHEQTRANSM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidordpago='" + _Txt_OrdPagoId.Text + "' AND cimpimiocheq=0");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                string _Str_Ciudad = "";
                Frm_ChequeVer _Frm_ChequeVer = new Frm_ChequeVer(this);
                if (!_Mtd_AbiertoOno(_Frm_ChequeVer, (Frm_Padre)this.MdiParent))
                {
                    //_Frm_ChequeVer.MdiParent = this.MdiParent;
                    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cciudadcheque FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    {
                        _Str_Ciudad = Convert.ToString(_Ds_A.Tables[0].Rows[0][0]).ToUpper();
                    }
                    _Frm_ChequeVer._Txt_FechaA.Text = _Str_Ciudad + ", " + CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Day.ToString() + " DE " + myUtilidad._Mtd_ObtenerMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Month);
                    _Frm_ChequeVer._Txt_FechaB.Text = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Year.ToString();
                    _Frm_ChequeVer._Txt_Monto.Text = "**" + _Txt_Monto.Text + "**";
                    _Frm_ChequeVer._Txt_Persona.Text = _Txt_Persona.Text;
                    //_Frm_ChequeVer._Txt_NumDoc.Text = _Txt_Doc.Text;
                    if (Convert.ToString(_Cb_FormaPago.SelectedValue) == "CHEQ")
                    { _Frm_ChequeVer._Lbl_CheqTransf.Text = "CHEQUE"; _Frm_ChequeVer._Str_FormaPago = "CHEQ"; }
                    else if (Convert.ToString(_Cb_FormaPago.SelectedValue) == "TRANSF")
                    { _Frm_ChequeVer._Lbl_CheqTransf.Text = "TRANSFERENCIA"; _Frm_ChequeVer._Str_FormaPago = "TRANSF"; }
                    _Frm_ChequeVer._Mtd_RedimMontoTxt(_Txt_CantDescrip.Text);
                    _Frm_ChequeVer._Str_CheqTrans = _Txt_EmisionId.Text;
                    _Frm_ChequeVer._Str_OrdPago = _Txt_OrdPagoId.Text;
                    _Frm_ChequeVer._Str_NumCuenta = _Cb_Cuenta.SelectedValue.ToString();
                    _Frm_ChequeVer.Text = "CHEQUE-" + _Cb_Banco.Text.ToUpper().Trim();
                    _Frm_ChequeVer._Str_Banco = Convert.ToString(_Cb_Banco.SelectedValue).Trim();
                    _Frm_ChequeVer.ShowDialog();
                }
            }
            else
            { MessageBox.Show("El Cheque ya fue Impreso.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Bt_EditarComprob_Click(object sender, EventArgs e)
        {
            _Mtd_Habilitar();
            _Dg_Comprobante.ReadOnly = false;
            _Mtd_GridColor(_Dg_Comprobante);
            _Mtd_DgComprobanteCol();
            _Dg_Comprobante.Columns[3].ReadOnly = true;
            _Dg_Comprobante.Rows[_Dg_Comprobante.RowCount - 1].ReadOnly = true;
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Comprobante.AutoResizeColumns();
            //CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
            _Mtd_BotonesMenu();
        }

        private void _Mtd_DgComprobanteCol()
        {


            _Dg_Comprobante.Columns[0].ReadOnly = true;
            _Dg_Comprobante.Columns[1].ReadOnly = true;
            _Dg_Comprobante.Columns[2].ReadOnly = false;
            _Dg_Comprobante.Columns[3].ReadOnly = true;
            _Dg_Comprobante.Columns[4].ReadOnly = true;
            _Dg_Comprobante.Columns[5].ReadOnly = true;
        }

        private void abajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            _Dg_Comprobante.AutoResizeColumns();
            _Dg_Comprobante.Rows.Insert(_Dg_Comprobante.CurrentCell.RowIndex, 1);
            _Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex - 1].Cells[4].ReadOnly = true;
            _Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex - 1].Cells[5].ReadOnly = false;
            _Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex - 1].Cells[1].ReadOnly = false;
            _Dg_Comprobante.ClearSelection();
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Comprobante.AutoResizeColumns();
        }

        private void arribaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            _Dg_Comprobante.AutoResizeColumns();
            _Dg_Comprobante.Rows.Insert(_Dg_Comprobante.CurrentCell.RowIndex + 1, 1);
            _Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex + 1].Cells[4].ReadOnly = true;
            _Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex - 1].Cells[5].ReadOnly = false;
            _Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex + 1].Cells[1].ReadOnly = false;
            _Dg_Comprobante.ClearSelection();
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Comprobante.AutoResizeColumns();
        }

        private void _CMen_A_Del_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(_Dg_Comprobante[6, _Dg_Comprobante.CurrentCell.RowIndex].Value) != "1")
            {
                _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                _Dg_Comprobante.AutoResizeColumns();
                _Dg_Comprobante.Rows.RemoveAt(_Dg_Comprobante.CurrentCell.RowIndex);
                _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Dg_Comprobante.AutoResizeColumns();
            }
            else
            { _Dg_Comprobante.Rows[_Dg_Comprobante.CurrentCell.RowIndex].Visible = false; }

        }

        private void _Dg_Comprobante_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Str_MyProceso != "" && _Dg_Comprobante.ReadOnly == false)
            {
                _Dg_Comprobante.ContextMenuStrip = _CMen_A;
                if (Convert.ToString(_Dg_Comprobante[6, e.RowIndex].Value) != "1" && e.RowIndex != _Dg_Comprobante.RowCount - 1)
                { _CMen_A_Del.Visible = true; }
                else
                { _CMen_A_Del.Visible = false; }
            }
        }

        private void _Dg_Comprobante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1)
            {
                _Dg_Comprobante.ContextMenuStrip = null;
            }
            if (_Str_MyProceso != "")
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 2 && _Dg_Comprobante[e.ColumnIndex, e.RowIndex].ReadOnly == false) //El boton de Buscar
                    {
                        string _Str_CodCuenta = "", _Str_Sql = "";
                        //string _Str_Auxiliar = "", _Str_CuentaName = "";
                        Frm_VstCuentas Frm_ProcesosVista1 = new Frm_VstCuentas();
                        Frm_ProcesosVista1.ShowDialog();
                        _Str_CodCuenta = Frm_ProcesosVista1._Str_FrmNodeSelec;
                        if (_Str_CodCuenta != "")
                        {
                            if (_Mtd_ValidarGridDetaAdd(_Str_CodCuenta) == false)
                            {
                                _Dg_Comprobante.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_Comprobante_CellValueChanged);
                                if (Convert.ToString(_Dg_Comprobante[1, e.RowIndex].Value).Trim() == "")
                                {
                                    _Dg_Comprobante[4, e.RowIndex].Value = "0";
                                    _Dg_Comprobante[4, e.RowIndex].ReadOnly = false;
                                    _Dg_Comprobante[5, e.RowIndex].Value = "0";
                                    _Dg_Comprobante[5, e.RowIndex].ReadOnly = false;
                                }
                                _Dg_Comprobante[0, e.RowIndex].Value = "";
                                _Dg_Comprobante[1, e.RowIndex].Value = _Str_CodCuenta;
                                _Str_Sql = "SELECT cauxiliar,cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_CodCuenta + "'";
                                //DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                                //_Str_Auxiliar = Convert.ToString(_Ds.Tables[0].Rows[0]["cauxiliar"]).Trim();
                                //_Str_CuentaName = Convert.ToString(_Ds.Tables[0].Rows[0]["cname"]).Trim().ToUpper();
                                //_Dg_Comprobante[3, e.RowIndex].Value = _Str_CuentaName;
                                _Dg_Comprobante.CellValueChanged += new DataGridViewCellEventHandler(_Dg_Comprobante_CellValueChanged);
                            }
                        }
                    }
                }
            }
        }

        private bool _Mtd_VerificarSaldo()
        {
            double _Dbl_Debe = 0;
            double _Dbl_Haber = 0;
            double _Dbl_DebeA = 0;
            double _Dbl_HaberA = 0;
            bool _Bol_R = false;
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (_Dg_Row.Visible)
                {
                    if (Convert.ToString(_Dg_Row.Cells[4].Value).Trim() == "" || Convert.ToString(_Dg_Row.Cells[4].Value).Trim() == "0")
                    {
                        _Dbl_Debe = 0;
                    }
                    else
                    { _Dbl_Debe = Convert.ToDouble(_Dg_Row.Cells[4].Value); }
                    if (Convert.ToString(_Dg_Row.Cells[5].Value).Trim() == "" || Convert.ToString(_Dg_Row.Cells[5].Value).Trim() == "0")
                    { _Dbl_Haber = 0; }
                    else
                    { _Dbl_Haber = Convert.ToDouble(_Dg_Row.Cells[5].Value); }

                    //if (_Dbl_Debe == 0 && _Dbl_Haber == 0)
                    //{
                    //    return true;
                    //}
                    _Dbl_DebeA = _Dbl_DebeA + _Dbl_Debe;
                    _Dbl_HaberA = _Dbl_HaberA + _Dbl_Haber;
                }
            }
            if (CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado(_Dbl_HaberA, 2) == CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado(_Dbl_DebeA, 2))
            {
                _Bol_R = false;
            }
            else
            { _Bol_R = true; }
            return _Bol_R;
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

        private void _Dg_Comprobante_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _Dg_Comprobante.ContextMenuStrip = null;
        }

        private void _Dg_Comprobante_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Dg_Comprobante.AutoResizeColumns();
            }
        }

        private void _Dg_Comprobante_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_Str_MyProceso != "")
            {
                _Mtd_MensajesError(_Dg_Comprobante, e.RowIndex, e.ColumnIndex);
                if (_Int_FrmTotComprobSw == 0)
                {
                    _Mtd_FilaTotal();
                    if (e.ColumnIndex == 4)
                    {
                        if (Convert.ToString(_Dg_Comprobante[5, e.RowIndex].Value) != "")
                        {
                            if (Convert.ToString(_Dg_Comprobante[4, e.RowIndex].Value) != "")
                            {
                                MessageBox.Show("No puede ingresar un valor en esta celda. El Debe ya tiene valor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _Dg_Comprobante[4, e.RowIndex].Value = "";
                            }
                        }
                    }
                    if (e.ColumnIndex == 5)
                    {
                        if (Convert.ToString(_Dg_Comprobante[4, e.RowIndex].Value) != "")
                        {
                            if (Convert.ToString(_Dg_Comprobante[5, e.RowIndex].Value) != "")
                            {
                                MessageBox.Show("No puede ingresar un valor en esta celda. El Haber ya tiene valor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _Dg_Comprobante[5, e.RowIndex].Value = "";
                            }

                        }
                    }
                }

            }
        }

        private bool _Mtd_MensajesError(DataGridView _myDg, int _P_Int_Row, int _P_Int_Col)
        {
            try
            {
                if (_P_Int_Col == 4 || _P_Int_Col == 5)
                {
                    if (Convert.ToString(_myDg.Rows[_P_Int_Row].Cells[_P_Int_Col].Value) != "")
                    {
                        if (!_Mtd_IsNumeric(Convert.ToDouble(_myDg.Rows[_P_Int_Row].Cells[_P_Int_Col].Value).ToString("####0.00")))
                        {
                            MessageBox.Show("No debe Introducir valores alfanuméricos");
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
            catch
            {
                MessageBox.Show("Valor No Válido.");
                _myDg.Rows[_P_Int_Row].Cells[_P_Int_Col].Value = "";
                return true;
            }
            return false;
        }

        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        private void _Txt_Concepto_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Txt_Concepto, "");
        }

        public void _Mtd_CargarComprobante(string _Pr_Str_Id)
        {
            double _Dbl_Retenido = 0;
            string _Str_Sql = "";
            //CARGO LOS DEBES
            _Int_FrmTotComprobSw = 1;
            _Str_Sql = "SELECT * FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Pr_Str_Id + "' and (ctothaber IS NULL or ctothaber=0)";
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds_A.Tables[0].Rows)
            {
                _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                _Dg_Comprobante.AutoResizeColumns();
                _Dg_Comprobante.Rows.Add();
                _Dg_Comprobante[0, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DRow["corder"]);
                _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DRow["ccount"]);
                _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DRow["cdescrip"]);
                _Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = Convert.ToDouble(_DRow["ctotdebe"]).ToString("#,##0.00");
                _Dg_Comprobante[6, _Dg_Comprobante.RowCount - 1].Value = "1";                
                _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Dg_Comprobante.AutoResizeColumns();
            }
            //Cargo el concepto de la maestra de comprobante
            _Str_Sql = "SELECT cname FROM TCOMPROBANc WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Pr_Str_Id + "'";
            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds_A.Tables[0].Rows)
            {
                _Txt_Concepto.Text = Convert.ToString(_DRow["cname"]); 
            }

            //CARGO el haber
            _Str_Sql = "SELECT * FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Pr_Str_Id + "' and (ctotdebe IS NULL or ctotdebe=0)";
            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds_A.Tables[0].Rows)
            {
                _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                _Dg_Comprobante.AutoResizeColumns();
                _Dg_Comprobante.Rows.Add();
                _Dg_Comprobante[0, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DRow["corder"]);
                _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DRow["ccount"]);
                _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_DRow["cdescrip"]);
                _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = Convert.ToDouble(_DRow["ctothaber"]).ToString("#,##0.00");
                _Dg_Comprobante[6, _Dg_Comprobante.RowCount - 1].Value = "1";
                _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Dg_Comprobante.AutoResizeColumns();
            }
            //BUSCO LA CANTIDAD A RETENER
            _Str_Sql = "SELECT cretenido FROM TCOMPROBANRETC WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Txt_ComprobId.Text + "' AND cproveedor='" + Convert.ToString(_Txt_Persona.Tag) + "'";
            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {//hay RETENCION
                if (Convert.ToString(_Ds_A.Tables[0].Rows[0][0]) != "")
                { _Dbl_Retenido = Convert.ToDouble(_Ds_A.Tables[0].Rows[0][0]); }
            }
            //BUSCO LA BUENTA DEL PROVEEDOR
            _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ccount FROM VST_CUENTBANCCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + Convert.ToString(_Cb_Banco.SelectedValue) + "' AND cnumcuenta='" + Convert.ToString(_Cb_Cuenta.SelectedValue) + "'");
            if (_Ds_A.Tables[0].Rows.Count > 0)
            {
                foreach (DataGridViewRow _DgRow in _Dg_Comprobante.Rows)
                {
                    if (Convert.ToString(_DgRow.Cells[1].Value) == Convert.ToString(_Ds_A.Tables[0].Rows[0][0]))
                    {
                        _DgRow.Cells[5].Value = Convert.ToDouble(_DgRow.Cells[5].Value) - _Dbl_Retenido;
                        _DgRow.Cells[5].Value = Convert.ToDouble(_DgRow.Cells[5].Value).ToString("#,##0.00");
                    }
                }
            }
            //agrego la cuenta DE LA RETENCION
            if (_Dbl_Retenido != 0)
            {
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT * FROM VST_PROCESOSCONTD WHERE cidproceso='P_CTASPAGAR' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cideprocesod=1");
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    _Dg_Comprobante.AutoResizeColumns();
                    _Dg_Comprobante.Rows.Add();
                    _Dg_Comprobante[0, _Dg_Comprobante.RowCount - 1].Value = "";
                    _Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ccount"]);
                    _Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = Convert.ToString(_Ds_A.Tables[0].Rows[0]["ccountname"]);
                    _Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = _Dbl_Retenido.ToString("#,##0.00");
                    _Dg_Comprobante[6, _Dg_Comprobante.RowCount - 1].Value = "1";
                    _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    _Dg_Comprobante.AutoResizeColumns();
                }
            }
            _Mtd_FilaTotal();
            _Int_FrmTotComprobSw = 0;
            _Dg_Comprobante.ReadOnly = true;
            _Mtd_GridColor(_Dg_Comprobante);
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Comprobante.AutoResizeColumns();
            _Bt_EditarComprob.Enabled = false;
        }

        private void _Mtd_GridColor(DataGridView _Pr_Dg)
        {
            if (_Pr_Dg.ReadOnly)
            {
                foreach (DataGridViewRow _DgRow in _Pr_Dg.Rows)
                {
                    for (int _Int_I = 0; _Int_I < _Pr_Dg.ColumnCount; _Int_I++)
                    {
                        if (_Int_I == 2)
                        { _DgRow.Cells[_Int_I].Style.BackColor = Color.Navy; }
                        else
                        { _DgRow.Cells[_Int_I].Style.BackColor = Color.Tan; }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow _DgRow in _Pr_Dg.Rows)
                {
                    for (int _Int_I = 0; _Int_I < _Pr_Dg.ColumnCount; _Int_I++)
                    {
                        if (_Int_I == 2)
                        { _DgRow.Cells[_Int_I].Style.BackColor = Color.Navy; }
                        else
                        { _DgRow.Cells[_Int_I].Style.BackColor = Color.White; }
                    }
                }
            }
        }

        private void _Mtd_ImprimirComprobante(string _Pr_Str_Id)
        {
            PrintDialog _Print = new PrintDialog();
            if (_Print.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                //____________________________________________________________
                REPORTESS _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Pr_Str_Id + "'", _Print, true);
                _Frm.Show();
                Cursor = Cursors.Default;
            }
        }

        private void _Dg_Comprobante_ReadOnlyChanged(object sender, EventArgs e)
        {

        }

        private void _Bt_ComprobOk_Click(object sender, EventArgs e)
        {
            string _Str_Sql = "";
            byte[] hash = _Mtd_ConvertStringToByteArray(_Txt_ComproPwd.Text);
            byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
            string cod = BitConverter.ToString(valorhash);
            cod = cod.Replace("-", "");
            try
            {
                string _Str_Cadena = "SELECT cpassw FROM TUSER WHERE cuser= '" + Frm_Padre._Str_Use + "' and cpassw= '" + cod.ToString() + "'";
                System.Data.DataSet Ds22 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (Ds22.Tables[0].Rows.Count > 0)
                {
                    _Mtd_ImprimirComprobante(_Txt_ComprobId.Text);
                    _Str_Sql = "UPDATE TCOMPROBANC SET clvalidado=1,cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob=" + _Txt_ComprobId.Text;
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    this.Close();
                }
                else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_ComproPwd.Focus(); _Txt_ComproPwd.Select(0, _Txt_ComproPwd.Text.Length); }
            }
            catch (Exception _Ex)
            {
                MessageBox.Show(_Ex.Message);
                Cursor = Cursors.Default;
            }
        }

        private void _Bt_ComprobCancel_Click(object sender, EventArgs e)
        {
            _Pnl_ComprobClave.Visible = false;
        }

        private void _Pnl_ComprobClave_VisibleChanged(object sender, EventArgs e)
        {
            _Txt_ComproPwd.Text = "";
            if (_Pnl_ComprobClave.Visible)
            {
                _Tb_Tab.Enabled = false;
                _Txt_ComproPwd.Focus();
            }
            else
            {
                _Tb_Tab.Enabled = true;
            }
        }

        private bool _Mtd_AbiertoOno(Form _Frm_Formulario, Frm_Padre _Pr_Frm_Padre)
        {
            foreach (Form _Frm_Hijo in _Pr_Frm_Padre.MdiChildren)
            {
                if (_Frm_Hijo.Name == _Frm_Formulario.Name)
                {
                    _Frm_Hijo.Activate();
                    return true;
                }
            }
            return false;
        }

        private void _Mtd_FilaTotal()
        {
            _Int_FrmTotComprobSw = 1;
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

        private void _Dg_Comprobante_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox)
            {
                _Txt_ColDoH = e.Control as TextBox;
                _Txt_ColDoH.KeyPress += new KeyPressEventHandler(_Txt_ColDoH_KeyPress);
            }
        }

        private void _Txt_ColDoH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_Dg_Comprobante.CurrentCell.ColumnIndex == 5)
            { myUtilidad._Mtd_Valida_Numeros(_Txt_ColDoH, e, 15, 2); }
        }

        private void _Bt_FirmaSol_EnabledChanged(object sender, EventArgs e)
        {
            if (_Bt_FirmaSol.Enabled)
            {
                _Bt_FirmaSol.BackColor = Color.Yellow;
            }
            else
            { _Bt_FirmaSol.BackColor = Color.FromKnownColor(KnownColor.Control); }
            _Bt_EliminarSol.Enabled = _Bt_FirmaSol.Enabled;
        }

        private void _Bt_FirmaCont_EnabledChanged(object sender, EventArgs e)
        {
            if (_Bt_FirmaCont.Enabled)
            {
                _Bt_FirmaCont.BackColor = Color.Yellow;
            }
            else
            { _Bt_FirmaCont.BackColor = Color.FromKnownColor(KnownColor.Control); }
            _Bt_EliminarCon.Enabled = _Bt_FirmaCont.Enabled;
        }

        private void _Bt_FirmaAprob_EnabledChanged(object sender, EventArgs e)
        {
            if (_Bt_FirmaAprob.Enabled)
            {
                _Bt_FirmaAprob.BackColor = Color.Yellow;
            }
            else
            { _Bt_FirmaAprob.BackColor = Color.FromKnownColor(KnownColor.Control); }
            _Bt_EliminarApr.Enabled = _Bt_FirmaAprob.Enabled;
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

        private void _Dg_Comprobante_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EMISION_CHEQUE_CONT"))
            {
                if (_Str_MyProceso != "")
                {
                    if (e.ColumnIndex == -1 && e.RowIndex > -1)
                    {
                        _Lbl_DgComprobInfo.Visible = true;
                    }
                    else
                    {
                        _Lbl_DgComprobInfo.Visible = false;
                    }
                }
            }
        }

        private void _Cb_CatProveFind_DropDown(object sender, EventArgs e)
        {
            if (_Cb_TpoProveFind.SelectedIndex > 0)
            {
                _Mtd_CargarCatProve(_Cb_TpoProveFind.SelectedValue.ToString());
            }
        }
        private void _Mtd_Delete_DetalleAnticipo(string _P_Str_OrdenPago)
        {
            string _Str_Cadena = "DELETE FROM TPAGOSCXPANT WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _P_Str_OrdenPago + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
        }
        private bool _Mtd_OrdenReposicion(int _P_Int_OrdenPago)
        {
            Program._Dat_Tablas =
new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            return (from Campos in Program._Dat_Tablas.TREPOSICIONESM
                    where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidordpago == _P_Int_OrdenPago
                    select Campos).Count() > 0;
        }
        private void _Mtd_EliminarPago()
        {
            string _Str_TipoDocND_CxP = myUtilidad._Mtd_TipoDocumentFACT_CXP("ctipodocnd");
            string _Str_Comprobante = "";
            string _Str_Cadena = "UPDATE TPAGOSCXPM SET canulado=1 WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Txt_OrdPagoId.Text + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Mtd_Delete_DetalleAnticipo(_Txt_OrdPagoId.Text);
            //---------------------------------------DETALLE
            _Str_Cadena = "SELECT cproveedor,ctipodocument,cnumdocu FROM TPAGOSCXPD WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Txt_OrdPagoId.Text + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Str_Cadena = "UPDATE TFACTPPAGARM SET cordenpaghecha='0',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Row["cproveedor"].ToString().Trim() + "' AND ctipodocument='" + _Row["ctipodocument"].ToString().Trim() + "' AND cnumdocu='" + _Row["cnumdocu"].ToString().Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                if (_Str_TipoDocND_CxP.Trim() == _Row["ctipodocument"].ToString().Trim())
                {
                    _Str_Cadena = "UPDATE TNOTADEBITOCP SET cdescontada=0,cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp='" + _Row["cnumdocu"].ToString().Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
            }
            //---------------------------------------
            _Str_Cadena = "SELECT cidcomprob FROM TPAGOSCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Txt_OrdPagoId.Text + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Comprobante = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
            }
            _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus=9,clvalidado=0 WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Str_Comprobante + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            if (_Txt_EmisionId.Text.Trim().Length > 0)
            {
                _Str_Cadena = "UPDATE TEMICHEQTRANSM SET canulado=1 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidordpago='" + _Txt_OrdPagoId.Text + "' AND cidemisioncheq='" + _Txt_EmisionId.Text + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            if (_Mtd_OrdenReposicion(Convert.ToInt32(_Txt_OrdPagoId.Text)))
            {
                Program._Dat_Tablas =
new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
                //----------------------------------
                DataContext.TREPOSICIONESM _T_TREPOSICIONESM = Program._Dat_Tablas.TREPOSICIONESM.Single(Campos => Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidordpago == Convert.ToInt32(_Txt_OrdPagoId.Text));
                _T_TREPOSICIONESM.cyearacco = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year;
                _T_TREPOSICIONESM.cmontacco = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month;
                _T_TREPOSICIONESM.cidordpago = 0;
                _T_TREPOSICIONESM.cbanco = "";
                _T_TREPOSICIONESM.cfpago = "";
                _T_TREPOSICIONESM.cnumcuenta = "";
                _T_TREPOSICIONESM.cordenpaghecha = 0;
                _T_TREPOSICIONESM.cestatusfirma = 0;
                _T_TREPOSICIONESM.cestatusreposicion = 0;
                _T_TREPOSICIONESM.cdateupd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
                _T_TREPOSICIONESM.cuserupd = Frm_Padre._Str_Use;
                //----------------------------------
                Program._Dat_Tablas.SubmitChanges();
            }
            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
        }
        private void _Bt_EliminarSol_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de eliminar la orden de pago", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _Mtd_EliminarPago();
                MessageBox.Show("La orden fue eliminada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void _Bt_EliminarCon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de eliminar la orden de pago", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _Mtd_EliminarPago();
                MessageBox.Show("La orden fue eliminada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_CargarBusqueda();
                _Tb_Tab.SelectedIndex = 0;
            }
        }

        private void _Bt_EliminarApr_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de eliminar la orden de pago", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _Mtd_EliminarPago();
                MessageBox.Show("La orden fue eliminada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_CargarBusqueda();
                _Tb_Tab.SelectedIndex = 0;
            }
        }

        private void _Dt_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dt_Desde.MaxDate = _Dt_Hasta.Value;
        }

        private void _Rb_PorEntregar_CheckedChanged(object sender, EventArgs e)
        {
            _Dg_Find.Rows.Clear();
            _Lbl_Desde.Enabled = !_Rb_PorEntregar.Checked; _Dt_Desde.Enabled = !_Rb_PorEntregar.Checked; _Lbl_Hasta.Enabled = !_Rb_PorEntregar.Checked; _Dt_Hasta.Enabled = !_Rb_PorEntregar.Checked;
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_Frm_OrdenPagoConstructor != null & e.TabPageIndex == 0)
            { e.Cancel = true; }
            else if (e.TabPageIndex == 1 && _Txt_EmisionId.Text.Trim().Length == 0)
            {
                e.Cancel = true;
            }
            else if (e.TabPageIndex == 0)
            {
                _Mtd_Ini();
            }
        }
    }
}