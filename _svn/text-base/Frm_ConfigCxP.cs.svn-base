using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConfigCxP : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        string _Str_MyProceso = "";
        public Frm_ConfigCxP()
        {
            InitializeComponent();
        }
        public void _Mtd_BotonesMenu()
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            if (_Str_MyProceso == "M")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            if (_Str_MyProceso == "")
            {
                if (_Cb_Factura.Enabled)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                }
                else
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                }
            }
        }
        private void _Mtd_CargarTpoDoc()
        {
            string _Str_Sql = "SELECT rtrim(ctdocument),cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_Factura, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_RetIVA, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_NC, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_RetISLR, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_ND, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_Cheque, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_OP, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TransBanco, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_NDP, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_NCP, _Str_Sql);
        }
        private void _Mtd_CargarDatosTpoDoc()
        {
            string _Str_Sql = "SELECT * FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]).Trim() != "")
                {
                    _Cb_Factura.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]).Trim();
                }
                else
                {
                    _Cb_Factura.SelectedIndex = 0;
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocretiva"]).Trim() != "")
                {
                    _Cb_RetIVA.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocretiva"]).Trim();
                }
                else
                {
                    _Cb_RetIVA.SelectedIndex = 0;
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocnc"]).Trim() != "")
                {
                    _Cb_NC.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocnc"]).Trim();
                }
                else
                {
                    _Cb_NC.SelectedIndex = 0;
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocretislr"]).Trim() != "")
                {
                    _Cb_RetISLR.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocretislr"]).Trim();
                }
                else
                {
                    _Cb_RetISLR.SelectedIndex = 0;
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocnd"]).Trim() != "")
                {
                    _Cb_ND.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocnd"]).Trim();
                }
                else
                {
                    _Cb_ND.SelectedIndex = 0;
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctdocumentopcheq"]).Trim() != "")
                {
                    _Cb_Cheque.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctdocumentopcheq"]).Trim();
                }
                else
                {
                    _Cb_Cheque.SelectedIndex = 0;
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctdocumentopordenp"]).Trim() != "")
                {
                    _Cb_OP.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctdocumentopordenp"]).Trim();
                }
                else
                {
                    _Cb_OP.SelectedIndex = 0;
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctdocumentoptransf"]).Trim() != "")
                {
                    _Cb_TransBanco.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctdocumentoptransf"]).Trim();
                }
                else
                {
                    _Cb_TransBanco.SelectedIndex = 0;
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocndp"]).Trim() != "")
                {
                    _Cb_NDP.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocndp"]).Trim();
                }
                else
                {
                    _Cb_NDP.SelectedIndex = 0;
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocncp"]).Trim() != "")
                {
                    _Cb_NCP.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocncp"]).Trim();
                }
                else
                {
                    _Cb_NCP.SelectedIndex = 0;
                }
            }
        }
        private void _Mtd_CargarProveedores()
        {
            string _Str_Sql = "SELECT RTRIM(cproveedor),(cproveedor+'-'+c_nomb_fiscal) AS name FROM TPROVEEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cglobal<>1 AND cdelete=0 ORDER BY cproveedor";
            _myUtilidad._Mtd_CargarCombo(_Cb_ProvRetIVA, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_ProvRetISLR, _Str_Sql);
        }
        private void _Mtd_CargarCategorias()
        {
            string _Str_Sql = "Select ccatproveedor,UPPER(cnombre) AS cnombre from TCATPROVEEDOR where cdelete='0' AND cglobal='2' ORDER BY cnombre";
            _myUtilidad._Mtd_CargarCombo(_Cb_CatCRela, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_CatAcci, _Str_Sql);
        }
        private void _Mtd_CargarDatosProveedores()
        {
            string _Str_Sql = "SELECT * FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cprovretiva"]).Trim() != "")
                {
                    _Cb_ProvRetIVA.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cprovretiva"]).Trim();
                }
                else
                {
                    _Cb_ProvRetIVA.SelectedIndex = 0;
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cprovretislr"]).Trim() != "")
                {
                    _Cb_ProvRetISLR.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cprovretislr"]).Trim();
                }
                else
                {
                    _Cb_ProvRetISLR.SelectedIndex = 0;
                }
            }
        }
        private void _Mtd_CargarFormulacion()
        {
            string _Str_Sql = "SELECT * FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_ISLRib.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cvarislrib"]).Trim();
                _Txt_ISLRin.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cvarislrin"]).Trim();
                _Txt_ISLRmontopagar.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cvarislrmpagar"]).Trim();
                _Txt_ISLRimp.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cvarislrimp"]).Trim();
                _Txt_ISLRbaseimponible.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cvarislrbi"]).Trim();
                _Txt_ISLRsusA.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["csustraendoa"]).Trim();
                _Txt_ISLRsusB.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["csustraendob"]).Trim();
            }
        }
        private void _Mtd_CargarOtros()
        {
            string _Str_Sql = "SELECT rtrim(cidmotivo),cdescripcion FROM TMOTIVO WHERE cdelete=0 ORDER BY cdescripcion";
            _myUtilidad._Mtd_CargarCombo(_Cb_MotDPPPago, _Str_Sql);
            _Str_Sql = "SELECT rtrim(ctax),(rtrim(cname) + ' : ' + CONVERT(VARCHAR,cpercent)) FROM TTAX WHERE cdelete=0";
            _myUtilidad._Mtd_CargarCombo(_Cb_TasaImp, _Str_Sql);
            _Txt_ChequeCiudad.Text = "";
        }
        private string _Mtd_DescripcionProcesos(string _P_Str_Proceso)
        {
            string _Str_Cadena = "SELECT cdescripcion  FROM TPROCESOSCONT WHERE cidproceso='" + _P_Str_Proceso + "' AND cdelete='0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            { return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper(); }
            return "";
        }
        private void _Mtd_CargarDatosOtros()
        {
            string _Str_Sql = "SELECT * FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmotivodescppp"]).Trim() != "")
                {
                    _Cb_MotDPPPago.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cmotivodescppp"]).Trim();
                }
                else
                {
                    _Cb_MotDPPPago.SelectedIndex = 0;
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipimpuesto"]).Trim() != "")
                {
                    _Cb_TasaImp.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipimpuesto"]).Trim();
                }
                else
                {
                    _Cb_TasaImp.SelectedIndex = 0;
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccatproveciarel"]).Trim() != "")
                {
                    _Cb_CatCRela.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ccatproveciarel"]).Trim();
                }
                else
                {
                    _Cb_CatCRela.SelectedIndex = 0;
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccatproveaccio"]).Trim() != "")
                {
                    _Cb_CatAcci.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ccatproveaccio"]).Trim();
                }
                else
                {
                    _Cb_CatAcci.SelectedIndex = 0;
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cprocecontserv"]).Trim() != "")
                {
                    _Txt_CompServ.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["cprocecontserv"]).Trim();
                    _Txt_CompServ.Text = _Mtd_DescripcionProcesos(Convert.ToString(_Ds.Tables[0].Rows[0]["cprocecontserv"]).Trim());
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cprocecontciarel"]).Trim() != "")
                {
                    _Txt_CompCRela.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["cprocecontciarel"]).Trim();
                    _Txt_CompCRela.Text = _Mtd_DescripcionProcesos(Convert.ToString(_Ds.Tables[0].Rows[0]["cprocecontciarel"]).Trim());
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cprocecontaccio"]).Trim() != "")
                {
                    _Txt_CompAcci.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["cprocecontaccio"]).Trim();
                    _Txt_CompAcci.Text = _Mtd_DescripcionProcesos(Convert.ToString(_Ds.Tables[0].Rows[0]["cprocecontaccio"]).Trim());
                }
                _Txt_ChequeCiudad.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cciudadcheque"]).Trim();
            }
        }
        private void _Mtd_Bloquear(bool _Pr_Bol_A)
        {
            for (int _I = 0; _I < _Tb_Tab.TabPages.Count; _I++)
            {
                foreach (Control _Ctrl in _Tb_Tab.TabPages[_I].Controls)
                {
                    if (!(_Ctrl is Label))
                    {
                        _Ctrl.Enabled = _Pr_Bol_A;
                    }
                }
            }
        }
        private bool _Mtd_ValidaSave()
        {
            bool _Bol_Sw = true;
            _Er_Error.Dispose();
            for (int _I = 0; _I < _Tb_Tab.TabPages.Count; _I++)
            {
                foreach (Control _Ctrl in _Tb_Tab.TabPages[_I].Controls)
                {
                    if (_Ctrl is TextBox)
                    {
                        if (_Ctrl.Text.Trim() == "")
                        {
                            _Er_Error.SetError(_Ctrl, "Información requerida");
                            _Bol_Sw = false;
                        }
                    }
                    else if (_Ctrl is ComboBox)
                    {
                        if (((ComboBox)_Ctrl).SelectedIndex < 1)
                        {
                            _Er_Error.SetError(_Ctrl, "Información requerida");
                            _Bol_Sw = false;
                        }
                    }
                }
            }
            return _Bol_Sw;
        }
        public void _Mtd_Habilitar()
        {
            _Mtd_Bloquear(true);
            _Str_MyProceso = "M";
        }
        public bool _Mtd_Editar()
        {
            bool _Bol_R = false;
            string _Str_Sql = "";
            if (_Mtd_ValidaSave())
            {
                _Str_Sql = "SELECT * FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
                {
                    _Str_Sql = "UPDATE TCONFIGCXP SET ctipodocnd='" + _Cb_ND.SelectedValue.ToString() + "',ctipodocnc='" + _Cb_NC.SelectedValue.ToString() + "',ctipdocfact='" + _Cb_Factura.SelectedValue.ToString() + "',ctipdocretiva='" + _Cb_RetIVA.SelectedValue.ToString() + "',ctipdocretislr='" + _Cb_RetISLR.SelectedValue.ToString() + "',cprovretislr='" + _Cb_ProvRetISLR.SelectedValue.ToString() + "',cprovretiva='" + _Cb_ProvRetIVA.SelectedValue.ToString() + "',ctipimpuesto='" + _Cb_TasaImp.SelectedValue.ToString() + "',cciudadcheque='" + _Txt_ChequeCiudad.Text.Trim().ToUpper() + "',ctdocumentopcheq='" + _Cb_Cheque.SelectedValue.ToString() + "',ctdocumentoptransf='" + _Cb_TransBanco.SelectedValue.ToString() + "',ctdocumentopordenp='" + _Cb_OP.SelectedValue.ToString() + "',cvarislrib='" + _Txt_ISLRib.Text.Trim().ToUpper() + "',cvarislrin='" + _Txt_ISLRin.Text.Trim().ToUpper() + "',cvarislrmpagar='" + _Txt_ISLRmontopagar.Text.Trim().ToUpper() + "',cvarislrimp='" + _Txt_ISLRimp.Text.Trim().ToUpper() + "',cvarislrbi='" + _Txt_ISLRbaseimponible.Text.Trim().ToUpper() + "',csustraendoa='" + _Txt_ISLRsusA.Text.Trim().ToUpper() + "',csustraendob='" + _Txt_ISLRsusB.Text.Trim().ToUpper() + "',cmotivodescppp='" + _Cb_MotDPPPago.SelectedValue.ToString() + "',ctipodocndp='" + _Cb_NDP.SelectedValue.ToString() + "',ctipodocncp='" + _Cb_NCP.SelectedValue.ToString() + "',cprocecontserv='" + Convert.ToString(_Txt_CompServ.Tag).Trim() + "',cprocecontciarel='" + Convert.ToString(_Txt_CompCRela.Tag).Trim() + "',cprocecontaccio='" + Convert.ToString(_Txt_CompAcci.Tag).Trim() + "',ccatproveciarel='" + _Cb_CatCRela.SelectedValue.ToString() + "',ccatproveaccio='" + _Cb_CatAcci.SelectedValue.ToString() + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
                else
                {
                    _Str_Sql = "INSERT INTO TCONFIGCXP (ctipodocnd,ctipodocnc,ctipdocfact,ctipdocretiva,ctipdocretislr,cprovretislr,cprovretiva,ctipimpuesto,cciudadcheque,ctdocumentopcheq,ctdocumentoptransf,ctdocumentopordenp,cvarislrib,cvarislrin,cvarislrmpagar,cvarislrimp,cvarislrbi,csustraendoa,csustraendob,cmotivodescppp,ccompany,ctipodocndp,ctipodocncp,cprocecontserv,cprocecontciarel,cprocecontaccio,ccatproveciarel,ccatproveaccio)";
                    _Str_Sql = _Str_Sql + " VALUES('" + _Cb_ND.SelectedValue.ToString() + "','" + _Cb_NC.SelectedValue.ToString() + "','" + _Cb_Factura.SelectedValue.ToString() + "','" + _Cb_RetIVA.SelectedValue.ToString() + "','" + _Cb_RetISLR.SelectedValue.ToString() + "','" + _Cb_ProvRetISLR.SelectedValue.ToString() + "','" + _Cb_ProvRetIVA.SelectedValue.ToString() + "','" + _Cb_TasaImp.SelectedValue.ToString() + "','" + _Txt_ChequeCiudad.Text.Trim().ToUpper() + "','" + _Cb_Cheque.SelectedValue.ToString() + "','" + _Cb_TransBanco.SelectedValue.ToString() + "','" + _Cb_OP.SelectedValue.ToString() + "','" + _Txt_ISLRib.Text.Trim().ToUpper() + "','" + _Txt_ISLRin.Text.Trim().ToUpper() + "','" + _Txt_ISLRmontopagar.Text.Trim().ToUpper() + "','" + _Txt_ISLRimp.Text.Trim().ToUpper() + "','" + _Txt_ISLRbaseimponible.Text.Trim().ToUpper() + "','" + _Txt_ISLRsusA.Text.Trim().ToUpper() + "','" + _Txt_ISLRsusB.Text.Trim().ToUpper() + "','" + _Cb_MotDPPPago.SelectedValue.ToString() + "','" + Frm_Padre._Str_Comp + "','" + _Cb_NDP.SelectedValue.ToString() + "','" + _Cb_NCP.SelectedValue.ToString() + "','" + Convert.ToString(_Txt_CompServ.Tag).Trim() + "','" + Convert.ToString(_Txt_CompCRela.Tag).Trim() + "','" + Convert.ToString(_Txt_CompAcci.Tag).Trim() + "','" + _Cb_CatCRela.SelectedValue.ToString() + "','" + _Cb_CatAcci.SelectedValue.ToString() + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
                _Bol_R = true;
                MessageBox.Show("Transacción guardada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Bloquear(false);
                _Tb_Tab.SelectTab(0);
                _Str_MyProceso = "";
                _Er_Error.Dispose();
            }
            else
            {
                MessageBox.Show("Faltan datos requeridos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return _Bol_R;
        }
        public void _Mtd_Ini()
        {
            _Er_Error.Dispose();
            _Mtd_CargarFormulacion();
            _Mtd_CargarOtros();
            _Mtd_CargarProveedores();
            _Mtd_CargarCategorias();
            _Mtd_CargarTpoDoc();
            _Mtd_Bloquear(false);
        }
        private void _Mtd_CargarData()
        {
            _Mtd_CargarDatosTpoDoc();
            _Mtd_CargarDatosProveedores();
            _Mtd_CargarFormulacion();
            _Mtd_CargarDatosOtros();
        }
        private void Frm_ConfigCxP_Load(object sender, EventArgs e)
        {//string _Str_Sql = "SELECT RTRIM(cidproceso),RTRIM(cidproceso+'-'+cdescripcion) AS name FROM TPROCESOSCONT WHERE cdelete=0 ORDER BY cidproceso";
            _Mtd_Color_Estandar(this);
            _Mtd_Ini();
            _Mtd_CargarData();
        }

        private void Frm_ConfigCxP_Activated(object sender, EventArgs e)
        {
            _Mtd_BotonesMenu();
        }

        private void Frm_ConfigCxP_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
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

        private void _Cb_ProvRetIVA_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT RTRIM(cproveedor),(cproveedor+'-'+c_nomb_fiscal) AS name FROM TPROVEEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cglobal<>1 AND cdelete=0 ORDER BY cproveedor";
            _myUtilidad._Mtd_CargarCombo(_Cb_ProvRetIVA, _Str_Sql);
        }

        private void _Cb_ProvRetISLR_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT RTRIM(cproveedor),(cproveedor+'-'+c_nomb_fiscal) AS name FROM TPROVEEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cglobal<>1 AND cdelete=0 ORDER BY cproveedor";
            _myUtilidad._Mtd_CargarCombo(_Cb_ProvRetISLR, _Str_Sql);
        }

        private void _Cb_Factura_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT rtrim(ctdocument),cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_Factura, _Str_Sql);
        }

        private void _Cb_OP_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT rtrim(ctdocument),cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_OP, _Str_Sql);
        }

        private void _Cb_NC_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT rtrim(ctdocument),cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_NC, _Str_Sql);
        }

        private void _Cb_ND_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT rtrim(ctdocument),cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_ND, _Str_Sql);
        }

        private void _Cb_TransBanco_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT rtrim(ctdocument),cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TransBanco, _Str_Sql);
        }

        private void _Cb_Cheque_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT rtrim(ctdocument),cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_Cheque, _Str_Sql);
        }

        private void _Cb_RetISLR_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT rtrim(ctdocument),cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_RetISLR, _Str_Sql);
        }

        private void _Cb_RetIVA_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT rtrim(ctdocument),cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_RetIVA, _Str_Sql);
        }

        private void _Cb_MotDPPPago_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT rtrim(cidmotivo),cdescripcion FROM TMOTIVO WHERE cdelete=0 ORDER BY cdescripcion";
            _myUtilidad._Mtd_CargarCombo(_Cb_MotDPPPago, _Str_Sql);
        }

        private void _Cb_TasaImp_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT rtrim(ctax),(rtrim(cname) + ' : ' + CONVERT(VARCHAR,cpercent)) FROM TTAX WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TasaImp, _Str_Sql);
        }

        private void _Cb_NDP_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT rtrim(ctdocument),cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_NDP, _Str_Sql);
        }

        private void _Cb_NCP_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT rtrim(ctdocument),cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_NCP, _Str_Sql);
        }

        private void _Bt_CompServ_Click(object sender, EventArgs e)
        {
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(54, _Txt_CompServ, 0, "");
            _Frm.ShowDialog();
        }

        private void _Bt_CompCRela_Click(object sender, EventArgs e)
        {
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(54, _Txt_CompCRela, 0, "");
            _Frm.ShowDialog();
        }

        private void _Bt_CompAcci_Click(object sender, EventArgs e)
        {
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(54, _Txt_CompAcci, 0, "");
            _Frm.ShowDialog();
        }

        private void _Cb_CatCRela_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "Select ccatproveedor,UPPER(cnombre) AS cnombre from TCATPROVEEDOR where cdelete='0' AND cglobal='2' ORDER BY cnombre";
            _myUtilidad._Mtd_CargarCombo(_Cb_CatCRela, _Str_Sql);
        }

        private void _Cb_CatAcci_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "Select ccatproveedor,UPPER(cnombre) AS cnombre from TCATPROVEEDOR where cdelete='0' AND cglobal='2' ORDER BY cnombre";
            _myUtilidad._Mtd_CargarCombo(_Cb_CatAcci, _Str_Sql);
        }
    }
}