using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace T3
{
    public partial class Frm_Clientes_VC_1 : Form
    {
        string _Str_Sw = "";
        string _Str_Notas = "";
        string _Str_fecha = "";
        bool _Bol_Tabs = false;
        CLASES._Cls_Varios_Metodos _G_MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        string _G_Str_MyProceso = "";
        public Frm_Clientes_VC_1()
        {
            InitializeComponent();
            _Dtp_Fecha_Registro.MaxDate = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
            _Mtd_Actualizar();
        }
        public Frm_Clientes_VC_1(string _Pr_Str_IdCliente)
        {
            InitializeComponent();
            _Dtp_Fecha_Registro.MaxDate = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
            _Mtd_Actualizar();
            _Mtd_Cargar_Clasificacion();
            _Mtd_Ini();
            _Mtd_CargarData(_Pr_Str_IdCliente);
        }
        public Frm_Clientes_VC_1(bool _P_Bol_Tab)
        {
            InitializeComponent();
            this.Text += " (SIN LÍMITE DE CRÉDITO)";
            _Bol_Tabs = true;
            _Mtd_Actualizar();
        }
        private void _Mtd_Actualizar()
        {
            string _Str_FindSql = "Select top ?sel c_rif,ccliente, RTRIM(ccliente_nombcomer) AS ccliente_nombcomer,RTRIM(c_direcc_fiscal) as c_direcc_fiscal,RTRIM(c_estado_name) as c_estado_name,RTRIM(c_ciudad_name) as c_ciudad_name,convert(varchar, c_fech_inicio,103) AS c_fech_inicio,c_limt_credit_f,c_cheq_dev_f,c_fact_venc_f,CFECHA,CONVERT(VARCHAR,c_fecha_inactivo,103) + '  ' +CONVERT(VARCHAR,c_fecha_inactivo,108) AS CFECHAIN, cname_canal  FROM VST_CLIENTE WHERE NOT ccliente IN (select top ?omi ccliente from VST_CLIENTE WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (cdelete=0) AND (c_activo='1') ORDER BY ccliente) AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cdelete=0 AND c_activo='" + Convert.ToInt32(_Rbt_Act.Checked) + "'";
            if (_Bol_Tabs)
            { _Str_FindSql += " AND c_limt_credit='0'"; }
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Rif");
            _Tsm_Menu[2] = new ToolStripMenuItem("Cliente");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "ccliente";
            _Str_Campos[1] = "c_rif";
            _Str_Campos[2] = "ccliente_nombcomer";
            if (_Bol_Tabs)
            { _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_Campos, "Clientes", _Tsm_Menu, _Dg_Consulta, "TCLIENTE", "WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND cdelete=0 AND c_activo='" + Convert.ToInt32(_Rbt_Act.Checked) + "' AND c_limt_credit='0'", 100, "ORDER BY ccliente"); }
            else
            { _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_Campos, "Clientes", _Tsm_Menu, _Dg_Consulta, "TCLIENTE", "WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND cdelete=0 AND c_activo='" + Convert.ToInt32(_Rbt_Act.Checked) + "'", 100, "ORDER BY ccliente"); }
            if (_Rbt_Act.Checked)
            {
                _Dg_Consulta.Columns[11].Visible = false;
            }
            else
            {
                _Dg_Consulta.Columns[11].Visible = true;
            }
            _Dg_Consulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________            
        }
        private void _Mtd_Bloquear(bool _Pr_Bol_A)
        {
            _Mtd_Bloquear_DatosMain(_Pr_Bol_A);
            _Mtd_Bloquear_Tab_Detalle(_Tb_Detalle.TabPages[0], _Pr_Bol_A);
            _Mtd_Bloquear_Tab_Detalle(_Tb_Detalle.TabPages[1], _Pr_Bol_A);
            _Mtd_Bloquear_Tab_Detalle(_Tb_Detalle.TabPages[2], _Pr_Bol_A);
            _Mtd_Bloquear_Tab_Detalle(_Tb_Detalle.TabPages[3], _Pr_Bol_A);
        }
        public void _Mtd_Ini()
        {
            _Mtd_Ini_DatosMain();
            _Mtd_Ini_Tab_Detalle(_Tb_Detalle.TabPages[0]);
            _Mtd_Ini_Tab_Detalle(_Tb_Detalle.TabPages[1]);
            _Mtd_Ini_Tab_Detalle(_Tb_Detalle.TabPages[2]);
            _Mtd_Ini_Tab_Detalle(_Tb_Detalle.TabPages[3]);
            _Mtd_Bloquear(false);
            _Mtd_Cargar_Contribuyente();
            _Mtd_Cargar_Estado();
            _Mtd_Cargar_PtoCardinal();
            _Mtd_Cargar_Canal();
            _Mtd_Cargar_Forma_Pago();
            _Mtd_Cargar_Bancos();
            _Mtd_Cargar_LimiteCredito();
            _Mtd_Cargar_TipoEmpresa();
            _Mtd_Cargar_Estatus();
            _G_Str_MyProceso = "";
        }
        public void _Mtd_Cancelar()
        {
            _Mtd_Bloquear(false);
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
        }
        private void _Mtd_Ini_DatosMain()
        {
            foreach (Control _Ctrl in _Pnl_Cabecera.Controls)
            {
                if (!(_Ctrl is Label))
                {
                    if (!(_Ctrl is ComboBox) && !(_Ctrl is Button) && !(_Ctrl is CheckBox))
                    {
                        _Ctrl.Text = "";
                    }
                    else if (_Ctrl is ComboBox)
                    {
                        if (((ComboBox)_Ctrl).DataSource != null)
                        {
                            ((ComboBox)_Ctrl).SelectedIndex = 0;
                        }
                        else
                        {
                            ((ComboBox)_Ctrl).SelectedIndex = -1;
                        }
                    }
                    else if (_Ctrl is CheckBox)
                    {
                        ((CheckBox)_Ctrl).Checked = false;
                    }
                    else if (_Ctrl is RadioButton)
                    {
                        ((RadioButton)_Ctrl).Checked = false;
                    }
                }
            }
        }
        private void _Mtd_Ini_Tab_Detalle(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Ini_Tab_Detalle(_Ctrl);
                }
                if (!(_Ctrl is Label))
                {
                    if (!(_Ctrl is ComboBox) && !(_Ctrl is Button) && !(_Ctrl is CheckBox))
                    {
                        _Ctrl.Text = "";
                    }
                    else if (_Ctrl is ComboBox)
                    {
                        if (((ComboBox)_Ctrl).DataSource != null)
                        {
                            ((ComboBox)_Ctrl).SelectedIndex = 0;
                        }
                        else
                        {
                            ((ComboBox)_Ctrl).SelectedIndex = -1;
                        }
                    }
                    else if (_Ctrl is CheckBox)
                    {
                        ((CheckBox)_Ctrl).Checked = false;
                    }
                    else if (_Ctrl is RadioButton)
                    {
                        ((RadioButton)_Ctrl).Checked = false;
                    }
                }
            }
        }
        private void _Mtd_Bloquear_Tab_Detalle(Control _P_Ctrl_Control, bool _P_Bl_Val)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Bloquear_Tab_Detalle(_Ctrl, _P_Bl_Val);
                }
                if (!(_Ctrl is Label))
                {
                    _Ctrl.Enabled = _P_Bl_Val;
                }
            }
        }
        private void _Mtd_Bloquear_Group(Control _P_Ctrl_Control, bool _P_Bl_Val)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Bloquear_Group(_Ctrl, _P_Bl_Val);
                }
                if (!(_Ctrl is Label))
                {
                    _Ctrl.Enabled = _P_Bl_Val;
                }
            }
        }
        private void _Mtd_Bloquear_DatosMain(bool _P_Bl_Val)
        {
            foreach (Control _Ctrl in _Pnl_Cabecera.Controls)
            {
                if (!(_Ctrl is Label))
                {
                    _Ctrl.Enabled = _P_Bl_Val;
                }   
            }
        }
        private void _Mtd_Cargar_Clasificacion()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_Clasificacion.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("INDEPENDIENTE", "I"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("CASA MATRIZ", "C"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("SUCURSAL", "S"));
            _Cmb_Clasificacion.DataSource = _myArrayList;
            _Cmb_Clasificacion.DisplayMember = "Display";
            _Cmb_Clasificacion.ValueMember = "Value";
            _Cmb_Clasificacion.SelectedValue = "nulo";
        }
        private void _Mtd_ZonasVentas()
        {
            if (_Txt_Cod.Text != "")
            {
                string _Str_SentenciaSQL = "select c_zona,cname from VST_ZONAPCLIENTECONSULT where ccliente='" + _Txt_Cod.Text + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                DataSet _Ds_DataSet = new DataSet();
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                _Lst_Zona.DataSource = _Ds_DataSet.Tables[0].DefaultView;
                _Lst_Zona.ValueMember = "c_zona";
                _Lst_Zona.DisplayMember = "cname";
            }
        }
        private void _Mtd_Cargar_Contribuyente()
        {
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_TipoContribuyente, "Select RTRIM(ccontribuyente),RTRIM(cname) from TCONTRIBUYENTE where cdelete='0' ORDER BY cname ASC");
        }
        private void _Mtd_Cargar_Estado()
        {
            _Cmb_Estado.SelectedIndexChanged -= new EventHandler(_Cmb_Estado_SelectedIndexChanged);
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_Estado, "Select RTRIM(cestate),cname from TESTATE where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' ORDER BY cname ASC");
            _Cmb_Estado.SelectedIndexChanged += new EventHandler(_Cmb_Estado_SelectedIndexChanged);
        }
        private void _Mtd_Cargar_Ciudad(string _P_Str_Estado)
        {
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_Ciudad, "Select RTRIM(ccity),cname from TCITY where cdelete='0' and cestate='" + _P_Str_Estado + "' ORDER BY cname ASC");
        }
        private void _Mtd_Cargar_Municipio(string _P_Str_Estado)
        {
            _Cmb_Municipio.SelectedIndexChanged -= new EventHandler(_Cmb_Municipio_SelectedIndexChanged);
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_Municipio, "Select RTRIM(cmunicipio),cname from TMUNICIPIO where cdelete='0' and cestate='" + _P_Str_Estado + "' ORDER BY cname ASC");
            _Cmb_Municipio.SelectedIndexChanged += new EventHandler(_Cmb_Municipio_SelectedIndexChanged);
        }
        private void _Mtd_Cargar_Parroquia(string _P_Str_Municipio, string _P_Str_Estado)
        {
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_Parroquia, "Select RTRIM(cparroquia),cname from TPARROQUIA where cdelete='0' and cmunicipio='" + _P_Str_Municipio + "' and cestate='"+_Cmb_Estado.SelectedValue+"' ORDER BY cname ASC");
        }
        private void _Mtd_Cargar_PtoCardinal()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_PuntoCardinal.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("NORTE", "N"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("SUR", "S"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("ESTE", "E"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("OESTE", "O"));
            _Cmb_PuntoCardinal.DataSource = _myArrayList;
            _Cmb_PuntoCardinal.DisplayMember = "Display";
            _Cmb_PuntoCardinal.ValueMember = "Value";
            _Cmb_PuntoCardinal.SelectedValue = "nulo";
        }
        private void _Mtd_Cargar_Estatus()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_Estatus.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("ACTIVO", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("INACTIVO", "0"));
            _Cmb_Estatus.DataSource = _myArrayList;
            _Cmb_Estatus.DisplayMember = "Display";
            _Cmb_Estatus.ValueMember = "Value";
            _Cmb_Estatus.SelectedValue = "nulo";
        }
        private void _Mtd_Cargar_Canal()
        {
            _Cmb_TipoCanal.SelectedIndexChanged-=new EventHandler(_Cmb_TipoCanal_SelectedIndexChanged);
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_TipoCanal, "Select rtrim(ccanal),cname from TTCANAL where cdelete='0' ORDER BY cname ASC");
            _Cmb_TipoCanal.SelectedIndexChanged += new EventHandler(_Cmb_TipoCanal_SelectedIndexChanged);
        }
        private void _Mtd_Cargar_Establecimiento(string _P_Str_Canal)
        {
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_Establecimiento, "Select RTRIM(ctestablecim),rtrim(cname) as cname from TTESTABLECIM where cdelete='0' and ccanal='" + _P_Str_Canal + "' ORDER BY cname ASC");
        }
        private void _Mtd_Cargar_Forma_Pago()
        {
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_FormaPago, "Select RTRIM(cfpago),cname from TFPAGO where cdelete='0' ORDER BY cname ASC");
        }
        private void _Mtd_Cargar_Bancos()
        {
            string _Str_Sql = "Select rtrim(cbanco) as cbanco,cname from TBANCO where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "'";
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_Banco_1, _Str_Sql);
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_Banco_2, _Str_Sql);
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_Banco_3, _Str_Sql);
        }
        private void _Mtd_Cargar_LimiteCredito()
        {
            string _Str_Sql = "SELECT RTRIM(TLIMITCREDITO.ccodlimite), TLIMITCREDITO.cdescripcion " +
                              "FROM TLIMITCREDITO " +                              
                              "WHERE (TLIMITCREDITO.cdelete = '0') " +
                              "ORDER BY TLIMITCREDITO.climtedesde";
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_LimiteCredito, _Str_Sql);
        }
        private void _Mtd_Cargar_TipoEmpresa()
        {
            string _Str_Sql = "Select rtrim(c_tipemp),cname from TTEMPRESA WHERE cdelete=0 ORDER BY cname ASC";
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_TipoEmpresa, _Str_Sql);
        }
        private void _Mtd_Cargar_Promedio_Compra()
        {
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_PromedioCompras, "Select RTRIM(c_idpromediocomp),c_descripcion from TPROMCOMP where cdelete='0' ORDER BY c_descripcion ASC");
        }
        private void _Mtd_Cargar_Compra()
        {
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_CompraLinea, "Select RTRIM(clinea),cdescripcion from TLINEAVTAM ORDER BY cdescripcion");
        }
        private void Frm_Clientes_VC_1_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            if (_Txt_Cod.Text.Trim().Length == 0)
            {
                _Mtd_Cargar_Clasificacion();
                _Mtd_Ini();
            }
                   
        }

        private void _Mtd_CargarSaldo(string _Pr_Str_Id)
        {
            string _Str_SentenciaSQL="SELECT SUM(csaldofactura) AS SALDO FROM TSALDOCLIENTED WHERE CCLIENTE='"+_Pr_Str_Id+"' AND CGROUPCOMP='"+Frm_Padre._Str_GroupComp+"' AND CACTIVO='1'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0]["SALDO"].ToString() != "")
                {
                    this._Txt_SaldoFecha.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["SALDO"].ToString()).ToString("#,##0.00");
                }
                else
                {
                    this._Txt_SaldoFecha.Text = "0";
                }
            }
            else
            {
                this._Txt_SaldoFecha.Text = "0";
            }
            _Str_SentenciaSQL = "SELECT SUM(csaldofactura) AS SALDO FROM TSALDOCLIENTED WHERE CCLIENTE='" + _Pr_Str_Id + "' AND CGROUPCOMP='" + Frm_Padre._Str_GroupComp + "' AND cdiasvencfact<0 AND CACTIVO='1' OR CCLIENTE='" + _Pr_Str_Id + "' AND CGROUPCOMP='" + Frm_Padre._Str_GroupComp + "' AND cdiasvencfact=0 AND CACTIVO='1'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0]["SALDO"].ToString() != "")
                {
                    this._Txt_SaldoVencer.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["SALDO"].ToString()).ToString("#,##0.00");
                }
                else
                {
                    this._Txt_SaldoVencer.Text = "0";
                }
            }
            else
            {
                this._Txt_SaldoVencer.Text = "0";
            }
            _Str_SentenciaSQL = "SELECT  TSALDOCLIENTED.ccliente FROM TSALDOCLIENTED INNER JOIN TCONFIGCXC ON TSALDOCLIENTED.ccompany = TCONFIGCXC.ccompany AND TSALDOCLIENTED.ctipodocument = TCONFIGCXC.ctipdoccheqdev WHERE TSALDOCLIENTED.CCLIENTE='" + _Pr_Str_Id + "' AND TSALDOCLIENTED.CGROUPCOMP='" + Frm_Padre._Str_GroupComp + "' AND TSALDOCLIENTED.CACTIVO='1'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                this._Chbox_ChequeDevuelto.Checked = true;
            }
            else
            {
                this._Chbox_ChequeDevuelto.Checked = false;
            }
            _Str_SentenciaSQL = "SELECT TSALDOCLIENTED.ccliente FROM TSALDOCLIENTED INNER JOIN TCONFIGCXC ON TSALDOCLIENTED.ccompany = TCONFIGCXC.ccompany AND TSALDOCLIENTED.ctipodocument = TCONFIGCXC.ctipdoccheqdev WHERE TSALDOCLIENTED.CCLIENTE='" + _Pr_Str_Id + "' AND TSALDOCLIENTED.CGROUPCOMP='" + Frm_Padre._Str_GroupComp + "' AND DATEPART(yyyy, TSALDOCLIENTED.cfechaentrega) = '"+DateTime.Now.Year.ToString()+"'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                this._Chbox_ChequeDevueltoAno.Checked = true;
                _Txt_ChequeDevueltoAno.Text = _Ds.Tables[0].Rows.Count.ToString();
            }
            else
            {
                this._Chbox_ChequeDevueltoAno.Checked = false;
                _Txt_ChequeDevueltoAno.Text = "0";
            }
        }
        private void _Mtd_CargarDirecciones(string _P_Str_Cliente)
        {
            string _Str_SentenciaSQL = "select c_direcc_despa,rtrim(c_direcc_descrip) from TDDESPACHOC where ccliente='" + _P_Str_Cliente + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cdelete='0' order by c_direcc_despa";
            DataSet _DS_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            if (_DS_DataSet.Tables[0].Rows.Count > 0)
            {
                _G_MyUtilidad._Mtd_CargarCombo(_Cmb_DireccionDespacho, _Str_SentenciaSQL);
                if (_DS_DataSet.Tables[0].Rows.Count == 1)
                {
                    _Cmb_DireccionDespacho.SelectedIndex = 1;
                }
                else
                {
                    _Cmb_DireccionDespacho.DataSource=null;
                    _Cmb_DireccionDespacho.Items.Add("CLIENTE CON VARIAS DIRECCIONES DE DESPACHO");
                    _Cmb_DireccionDespacho.SelectedIndex = 0;
                }
            }
            else
            {
                _Cmb_DireccionDespacho.Items.Clear();
                _Cmb_DireccionDespacho.Items.Add("CLIENTE NO CONTIENE DIRECCIONES DE DESPACHO");
                _Cmb_DireccionDespacho.SelectedIndex = 0;
            }
        }
        private void _Mtd_CargarData(string _Pr_Str_Id)
        {
            _Cmb_Clasificacion.SelectedIndexChanged-=new EventHandler(_Cmb_Clasificacion_SelectedIndexChanged);
            _Er_Error.Dispose();
            _Mtd_Ini_DatosMain();
            _Mtd_Bloquear(false);
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente=" + _Pr_Str_Id + "");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Cod.Text = _Pr_Str_Id;
                _Txt_Rif.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_rif"]).Trim();
                if (_Ds.Tables[0].Rows[0]["c_fech_inicio"].ToString() != "")
                {
                    _Txt_Fecha.Text = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["c_fech_inicio"]).ToShortDateString();
                }
                _Txt_NombreComercial.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_nomb_comer"]).Trim().ToUpper();
                _Txt_RazonSocialEmpresa.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_razsocial_1"]).Trim().ToUpper();
                _Txt_RazonSocialAccionista.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_razsocial_2"]).Trim().ToUpper();
                _Txt_DireccionFiscal.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_direcc_fiscal"]).Trim().ToUpper();
                _Txt_CodSunagro.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ccodsunagro"]).Trim().ToUpper();
                _Txt_Telefono.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_telefono"]).Trim().ToUpper();
                _Txt_Email.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_email"]).Trim().ToUpper();
                _Txt_Www.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_www"]).Trim().ToUpper();
                _Txt_Sector.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_sector"]).Trim().ToUpper();
                _Txt_Urbanizacion.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_urbanizacion"]).Trim().ToUpper();
                _Txt_Carretera.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_carretera"]).Trim().ToUpper();
                _Txt_Avenida.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_avenida"]).Trim().ToUpper();
                _Txt_Calle.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_calle"]).Trim().ToUpper();
                _Txt_Carrera.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_carrera"]).Trim().ToUpper();
                _Txt_Esquina.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_esquina"]).Trim().ToUpper();
                _Txt_Piso.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_piso"]).Trim().ToUpper();
                _Txt_Edificio.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_edificio"]).Trim().ToUpper();
                _Txt_Local.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_local"]).Trim().ToUpper();
                _Txt_Referencia.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_preferencia"]).Trim().ToUpper();
                _Cmb_Clasificacion.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["c_clasifica"]).Trim().ToUpper();
                _Cmb_TipoContribuyente.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["c_tip_contribuy"]).Trim().ToUpper();
                _Txt_Fax.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_fax"]).Trim().ToUpper();
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_pcardinal"]).Trim().ToUpper() != "0")
                {
                    _Cmb_PuntoCardinal.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["c_pcardinal"]).Trim().ToUpper();
                }
                _Cmb_Estado.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["c_estado"]).Trim().ToUpper();
                _Cmb_Ciudad.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["c_ciudad"]).Trim().ToUpper();
                _Cmb_Municipio.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["c_municipio"]).Trim().ToUpper();
                _Cmb_Parroquia.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["c_parroquia"]).Trim().ToUpper();
                _Txt_Contacto_1.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_info_cont_1"]).Trim().ToUpper();
                _Txt_Contacto_2.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_info_cont_2"]).Trim().ToUpper();
                _Txt_Contacto_3.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_info_cont_3"]).Trim().ToUpper();
                string _Str_SQL = "SELECT CCANAL FROM TTESTABLECIM WHERE ctestablecim='" + Convert.ToString(_Ds.Tables[0].Rows[0]["c_estable"]).Trim().ToUpper() + "'";
                DataSet _Ds_Data = new DataSet();
                _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                foreach (DataRow _Dtw_Item in _Ds_Data.Tables[0].Rows)
                {
                    try
                    {
                        _Cmb_TipoCanal.SelectedValue = Convert.ToString(_Dtw_Item["ccanal"]).Trim().ToUpper();
                    }
                    catch
                    {
                    }
                }                   
                _Cmb_Establecimiento.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["c_estable"]).Trim().ToUpper();
                if(_Ds.Tables[0].Rows[0]["c_casa_matriz"].ToString().Trim().ToUpper()!="0" && _Ds.Tables[0].Rows[0]["c_casa_matriz"].ToString().Trim().ToUpper()!="")
                {
                    this._Txt_CasaMatriz.Text = _Ds.Tables[0].Rows[0]["c_casa_matriz"].ToString().Trim().ToUpper();
                }                
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cbackorder"]).Trim().ToUpper() == "1")
                {
                    _Chbox_BackOrder.Checked = true;
                }
                else
                {
                    _Chbox_BackOrder.Checked = false;
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_atendidodirecto"]).Trim().ToUpper() == "1")
                {
                    _Chbox_AtendidoDirecto.Checked = true;
                }
                else
                {
                    _Chbox_AtendidoDirecto.Checked = false;
                }
                _Cmb_Banco_1.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["c_banco_neg"]).Trim().ToUpper();
                _Cmb_Banco_2.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["c_banco_per"]).Trim().ToUpper();
                _Cmb_Banco_3.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["c_banco_soc"]).Trim().ToUpper();
                _Txt_CuentaBanc1.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_cuenta_neg"]).Trim().ToUpper();
                _Txt_CuentaBanc2.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_cuenta_per"]).Trim().ToUpper();
                _Txt_CuentaBanc3.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_cuenta_soc"]).Trim().ToUpper();
                _Txt_NumAccionistas.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_numacciones"]).Trim().ToUpper();
                _Txt_RepLegal.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_inf_replegal"]).Trim().ToUpper();
                _Cmb_Estatus.SelectedIndexChanged-=new EventHandler(_Cmb_Estatus_SelectedIndexChanged);
                _Cmb_Estatus.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["c_activo"]).Trim().ToUpper();
                _Cmb_Estatus.SelectedIndexChanged += new EventHandler(_Cmb_Estatus_SelectedIndexChanged);
                _Str_Sw = Convert.ToString(_Ds.Tables[0].Rows[0]["c_activo"]).Trim().ToUpper();
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_activo"]).Trim().ToUpper() == "1")
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_fecha_reactivacion"]).Trim() != System.DBNull.Value.ToString())
                    {
                        _Lbl_FechaActInact.Visible = true;
                        _Lbl_FechaActInact.Text = "Fecha de Reactivación:";
                        _Txt_FechaActInact.Visible = true;
                        _Lbl_NotaActInact.Visible = true;
                        _Lbl_NotaActInact.Text = "Nota de Reactivación:";
                        _Txt_NotaActInact.Visible = true;                        
                        _Txt_FechaActInact.Text = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["c_fecha_reactivacion"]).ToShortDateString();
                        _Txt_NotaActInact.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_notasreactivacion"]).Trim().ToUpper();
                        _Str_Notas = _Txt_NotaActInact.Text;
                        _Str_fecha = _Txt_FechaActInact.Text.Trim();
                    }
                    else
                    {
                        _Lbl_FechaActInact.Visible = false;
                        _Txt_FechaActInact.Visible = false;
                        _Lbl_NotaActInact.Visible = false;
                        _Txt_NotaActInact.Visible = false;
                    }
                }
                else
                {
                    _Lbl_FechaActInact.Visible = true;
                    _Lbl_FechaActInact.Text = "Fecha de Inactivación:";
                    _Txt_FechaActInact.Visible = true;                    
                    _Lbl_NotaActInact.Visible = true;
                    _Lbl_NotaActInact.Text = "Nota de Inactivación:";
                    _Txt_NotaActInact.Visible = true;
                    _Txt_FechaActInact.Text = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["c_fecha_inactivo"]).ToShortDateString();
                    _Txt_NotaActInact.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_notasinactivo"]).Trim().ToUpper();
                    _Str_Notas = _Txt_NotaActInact.Text;
                    _Str_fecha = _Txt_FechaActInact.Text.Trim();
                }
                
                _Cmb_FormaPago.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cfpago"]).Trim().ToUpper();
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_balancegen"]).Trim().ToUpper() == "1")
                {
                    _Chbox_BalanceGeneral.Checked = true;
                }
                else
                {
                    _Chbox_BalanceGeneral.Checked = false;
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_estganyper"]).Trim().ToUpper() == "1")
                {
                    _Chbox_EstadoGananciasPerdidas.Checked = true;
                }
                else
                {
                    _Chbox_EstadoGananciasPerdidas.Checked = false;
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_regmercantil"]).Trim().ToUpper() == "1")
                {
                    _Chbox_RegistroMercantil.Checked = true;
                }
                else
                {
                    _Chbox_RegistroMercantil.Checked = false;
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_riffoto"]).Trim().ToUpper() == "1")
                {
                    _Chbox_Rif.Checked = true;
                }
                else
                {
                    _Chbox_Rif.Checked = false;
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_cedfoto"]).Trim().ToUpper() == "1")
                {
                    _Chbox_Ci.Checked = true;
                }
                else
                {
                    _Chbox_Ci.Checked = false;
                }
                _Cmb_LimiteCredito.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["c_limt_credit"]).Trim().ToUpper();
                _Txt_CapitalSocialPag.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_capitalsolpag"]).Trim().ToUpper();
                _Txt_CapitalSocial.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_capitalsolreg"]).Trim().ToUpper();
                _Mtd_RiesgoCliente(_Txt_Cod.Text);
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cfechregmer"]).Trim() != "")
                {
                    _Dtp_Fecha_Registro.Value = Convert.ToDateTime(Convert.ToString(_Ds.Tables[0].Rows[0]["cfechregmer"]).Trim());
                }
                else
                {
                    _Dtp_Fecha_Registro.Value = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_listanegra"]).Trim().ToUpper() == "1")
                {
                    cb_lista_negra.Checked = true;
                }
                else 
                {
                    cb_lista_negra.Checked = false;
                }
                _Mtd_ZonasVentas();
                _Mtd_BotonesMenu();
                _Mtd_CargarSaldo(_Pr_Str_Id);
                _Mtd_CargarDirecciones(_Pr_Str_Id);
                _Tb_Tab.SelectedIndex = 1;
                _Tb_Detalle.SelectedIndex = 0;
                _Bt_HistorialCliente.Enabled = true;
                _Bt_BloqueoManualCliente.Enabled = _G_MyUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _G_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_BLOQUEO_MANUAL_CLIENTE"); ;
            }
            _Cmb_Clasificacion.SelectedIndexChanged += new EventHandler(_Cmb_Clasificacion_SelectedIndexChanged);
        }
        

        private void _Bt_Seniat_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                string _Str_Rif = _Txt_Rif.Text.Replace("-","");
                string _Str_Url = CLASES._Cls_Varios_Metodos._Str_Servidor_Web + "/este.aspx?este=" + _Str_Rif.Replace("-", "");
                Frm_Navegador _Frm = new Frm_Navegador(_Str_Url, false);
                //_Frm.MdiParent = this.MdiParent;
                //_Frm.Dock = DockStyle.Fill;
                _Frm.ShowDialog();
            }
            catch { }
            Cursor = Cursors.Default;
        }
        private void _Mtd_RiesgoCliente(string _P_Str_Cliente)
        {
            try
            {
                string _Str_Cadena = "Select ctipoempresa,dbo.Fnc_Formatear(cmontoasegurado) as cmontoasegurado,cpoliza,clocal,cdeposito,csucursales,clinea from TRIESGOS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cclientep='" + _P_Str_Cliente + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    DataRow _Row = _Ds.Tables[0].Rows[0];
                    _Cmb_TipoEmpresa.SelectedValue = _Row["ctipoempresa"].ToString();
                    _Txt_MontoAsegurado.Text = _Row["cmontoasegurado"].ToString().ToUpper().Trim();
                    _Chbox_PoseePolizaSeguro.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["cpoliza"].ToString()));
                    _Chbox_PoseeLocalPropio.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["clocal"].ToString()));
                    _Chbox_PoseeDepositoMercancia.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["cdeposito"].ToString()));
                    _Chbox_TieneSucursalesAgentes.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["csucursales"].ToString()));
                    _Cmb_CompraLinea.SelectedValue = _Row["clinea"].ToString();
                    _Cmb_PromedioCompras.SelectedValue = _Row["cpromediocompra"].ToString();
                }
            }
            catch {}
        }
        private void _Bt_NombreComercial_Click(object sender, EventArgs e)
        {
            _Txt_NombreComercial.Enabled = true;
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_Tb_Tab.SelectedIndex == 1)
            {
                if (_Txt_Cod.Text.TrimEnd() == "")
                {
                    e.Cancel = true;
                }
            }
            else
            {
                _Mtd_Ini();
                _Mtd_BotonesMenu();
            }
        }

        private void _Dg_Consulta_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarData(_Ctrl_Busqueda1._Mtd_RetornarStringCelda("ccliente", e.RowIndex));
            Cursor = Cursors.Default;
        }

        private void _Cmb_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Estado.SelectedValue != null)
            {
                _Mtd_Cargar_Ciudad(_Cmb_Estado.SelectedValue.ToString());
                _Mtd_Cargar_Municipio(_Cmb_Estado.SelectedValue.ToString());
            }
        }

        private void _Cmb_Municipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Municipio.SelectedValue != null && _Cmb_Estado.SelectedValue != null)
            {
                _Mtd_Cargar_Parroquia(_Cmb_Municipio.SelectedValue.ToString(), _Cmb_Estado.SelectedValue.ToString());
            }
        }

        private void _Bt_Direccion_Click(object sender, EventArgs e)
        {
            _Mtd_Bloquear_Tab_Detalle(_Tb_Detalle.TabPages[0], true);
        }

        private void _Cmb_Estado_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Estado();
        }

        private void _Cmb_Ciudad_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_Estado.SelectedValue != null)
            {
                _Mtd_Cargar_Ciudad(_Cmb_Estado.SelectedValue.ToString());
            }
        }

        private void _Cmb_Municipio_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_Estado.SelectedValue != null)
            {
                _Mtd_Cargar_Municipio(_Cmb_Estado.SelectedValue.ToString());
            }
        }

        private void _Cmb_Parroquia_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_Estado.SelectedValue != null && _Cmb_Municipio.SelectedValue!=null)
            {
                _Mtd_Cargar_Parroquia(_Cmb_Municipio.SelectedValue.ToString(),_Cmb_Estado.SelectedValue.ToString());
            }
        }

        private void _Bt_RazonSocialEmpresa_Click(object sender, EventArgs e)
        {
            _Txt_RazonSocialEmpresa.Enabled = true;
        }

        private void _Bt_RazonSocialAccionista_Click(object sender, EventArgs e)
        {
            _Txt_RazonSocialAccionista.Enabled = true;
        }

        private void _Bt_DireccionFiscal_Click(object sender, EventArgs e)
        {
            _Txt_DireccionFiscal.Enabled = true;
        }

        private void _Bt_CodSunagro_Click(object sender, EventArgs e)
        {
            _Txt_CodSunagro.Enabled = true;
        }

        private void _Bt_TipoContribuyente_Click(object sender, EventArgs e)
        {
            _Cmb_TipoContribuyente.Enabled = true;
        }

        private void _Bt_Clasificacion_Click(object sender, EventArgs e)
        {
            _Cmb_Clasificacion.Enabled = true;
        }

        private void _Bt_Telefono_Click(object sender, EventArgs e)
        {
            _Txt_Telefono.Enabled = true;
        }

        private void _Bt_Fax_Click(object sender, EventArgs e)
        {
            _Txt_Fax.Enabled = true;
        }

        private void _Bt_Email_Click(object sender, EventArgs e)
        {
            _Txt_Email.Enabled = true;
        }

        private void _Bt_Www_Click(object sender, EventArgs e)
        {
            _Txt_Www.Enabled = true;
        }

        private void _Bt_DireccionDespacho_Click(object sender, EventArgs e)
        {
            Frm_Clientes_VC_DireccionD _Frm_Form = new Frm_Clientes_VC_DireccionD(_Txt_Cod.Text);
            _Frm_Form.ShowDialog();
            _Mtd_CargarDirecciones(_Txt_Cod.Text);
        }

        private void _Bt_Contactos_Click(object sender, EventArgs e)
        {
            _Mtd_Bloquear_Group(groupBox2, true); groupBox2.Enabled = true; 
        }

        private void _Bt_Establecimiento_Click(object sender, EventArgs e)
        {
            _Cmb_Establecimiento.Enabled = true;

            // deshabilitado el 30/07/2012 hasta que se haga implantación final
            _Btn_SubClasificacion.Enabled = true;
        }

        private void _Bt_TipoCanal_Click(object sender, EventArgs e)
        {
            _Cmb_TipoCanal.Enabled = true;
        }

        private void _Bt_BackOrder_Click(object sender, EventArgs e)
        {
            //_Chbox_BackOrder.Enabled = true;
        }

        private void _Bt_AtendidoDirecto_Click(object sender, EventArgs e)
        {
            _Chbox_AtendidoDirecto.Enabled = true;
        }

        private void _Bt_DocumentacionCliente_Click(object sender, EventArgs e)
        {
            _Mtd_Bloquear_Group(groupBox3, true); groupBox3.Enabled = true;
        }

        private void _Bt_Estatus_Click(object sender, EventArgs e)
        {
            _Cmb_Estatus.Enabled = true;
        }

        private void _Bt_CuentaBanc1_Click(object sender, EventArgs e)
        {
            _Cmb_Banco_1.Enabled = true;
            _Txt_CuentaBanc1.Enabled = true;
        }

        private void _Bt_CuentaBanc2_Click(object sender, EventArgs e)
        {
            _Cmb_Banco_2.Enabled = true;
            _Txt_CuentaBanc2.Enabled = true;
        }

        private void _Bt_CuentaBanc3_Click(object sender, EventArgs e)
        {
            _Cmb_Banco_3.Enabled = true;
            _Txt_CuentaBanc3.Enabled = true;
        }

        private void _Cmb_TipoCanal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_TipoCanal.SelectedValue != null)
            {
                _Mtd_Cargar_Establecimiento(_Cmb_TipoCanal.SelectedValue.ToString());
            }
        }

        private void _Bt_ZonaVentas_Click(object sender, EventArgs e)
        {
            Frm_ZonaporCliente _Frm = new Frm_ZonaporCliente();
            if (!_Mtd_AbiertoOno(_Frm,(Frm_Padre)this.MdiParent))
            { 
                //_Frm.MdiParent = (Frm_Padre)this.MdiParent; _Frm.Dock = DockStyle.Fill; _Frm.Show();
                _Frm.ShowDialog();
            }
            else
            { _Frm.Dispose(); }
            _Mtd_ZonasVentas();
        }
        private bool _Mtd_ValidarSave()
        {
            int _Int_Tab = 0;
            _Er_Error.Dispose();
            bool _Bol_Valido = true;
            foreach (Control _Ctrl in _Pnl_Cabecera.Controls)
            {
                if (_Ctrl is TextBox)
                {
                    if (((TextBox)_Ctrl).Text.TrimEnd().TrimStart() == "")
                    {
                        string _Str_ControlId = ((TextBox)_Ctrl).Name;
                        if (_Str_ControlId != _Txt_Fax.Name && _Str_ControlId != _Txt_Email.Name && _Str_ControlId != _Txt_Www.Name)
                        {
                            if (_Str_ControlId == _Txt_CasaMatriz.Name)
                            {
                                if (_Cmb_Clasificacion.SelectedValue.ToString() == "S")
                                {
                                    _Er_Error.SetError(_Ctrl, "Información requerida!!!");
                                    _Bol_Valido = false;
                                }
                                else
                                {
                                }
                            }
                            else
                            {
                                _Er_Error.SetError(_Ctrl, "Información requerida!!!");
                                _Bol_Valido = false;
                            }
                        }
                    }
                }
                else if (_Ctrl is ComboBox)
                {
                    if (((ComboBox)_Ctrl).SelectedIndex == -1 || ((ComboBox)_Ctrl).SelectedIndex == 0)
                    {
                        string _Str_ControlId = ((ComboBox)_Ctrl).Name;
                        if (_Str_ControlId != _Cmb_DireccionDespacho.Name)
                        {
                            _Er_Error.SetError(_Ctrl, "Información requerida!!!");
                            _Bol_Valido = false;
                        }
                    }
                }
            }
            if (_Cmb_LimiteCredito.SelectedIndex == -1 || _Cmb_LimiteCredito.SelectedIndex == 0)
            {
                _Int_Tab = 3;
                _Er_Error.SetError(_Cmb_LimiteCredito, "Información requerida!!!");
                _Bol_Valido = false;
            }
            if (_Cmb_TipoEmpresa.SelectedIndex == -1 || _Cmb_TipoEmpresa.SelectedIndex == 0)
            {
                _Int_Tab = 3;
                _Er_Error.SetError(_Cmb_TipoEmpresa, "Información requerida!!!");
                _Bol_Valido = false;
            }
            if (_Cmb_Estatus.SelectedIndex == -1 || _Cmb_Estatus.SelectedIndex == 0)
            {
                _Int_Tab = 2;
                _Er_Error.SetError(_Cmb_Estatus, "Información requerida!!!");
                _Bol_Valido = false;
            }
            if (_Txt_NotaActInact.Text.TrimEnd().TrimStart() == "")
            {
                _Int_Tab = 2;
                _Er_Error.SetError(_Txt_NotaActInact, "¡¡¡Información requerida!!!");
                _Bol_Valido = false;
            }
            if (_Txt_RepLegal.Text.TrimEnd().TrimStart() == "")
            {
                _Int_Tab = 2;
                _Er_Error.SetError(_Txt_RepLegal, "Información requerida!!!");
                _Bol_Valido = false;
            }           
            if (_Cmb_TipoCanal.SelectedIndex == -1 || _Cmb_TipoCanal.SelectedIndex == 0)
            {
                _Int_Tab = 1;
                _Er_Error.SetError(_Cmb_TipoCanal, "Información requerida!!!");
                _Bol_Valido = false;
            }
            if (_Cmb_Establecimiento.SelectedIndex == -1 || _Cmb_Establecimiento.SelectedIndex == 0)
            {
                _Int_Tab = 1;
                _Er_Error.SetError(_Cmb_Establecimiento, "Información requerida!!!");
                _Bol_Valido = false;
            }
            if (_Lst_Zona.Items.Count==0)
            {
                _Int_Tab = 1;
                _Er_Error.SetError(groupBox1, "Información requerida!!!");
                _Bol_Valido = false;
            }
            if (_Cmb_DireccionDespacho.Items.Count == 1)
            {
                if (_Cmb_DireccionDespacho.Items[0].ToString() == "CLIENTE NO CONTIENE DIRECCIONES DE DESPACHO" || _Cmb_DireccionDespacho.SelectedValue!=null)
                {
                    _Er_Error.SetError(groupBox1, "Información requerida!!!");
                    _Bol_Valido = false;
                }
            }
            foreach (Control _Ctrl in tabPage3.Controls)
            {
                if (_Ctrl is TextBox)
                {
                    if (((TextBox)_Ctrl).Text.TrimEnd().TrimStart() == "")
                    {
                        string _Str_ControlId = ((TextBox)_Ctrl).Name;
                        if (_Str_ControlId != _Txt_Esquina.Name && _Str_ControlId != _Txt_Piso.Name && _Str_ControlId != _Txt_Urbanizacion.Name && _Str_ControlId != _Txt_Carretera.Name && _Str_ControlId != _Txt_Carrera.Name && _Str_ControlId != _Txt_Edificio.Name && _Str_ControlId != _Txt_Transversal.Name && _Str_ControlId != _Txt_Calle.Name)
                        {
                            _Er_Error.SetError(_Ctrl, "Información requerida!!!");
                            _Bol_Valido = false;
                            _Int_Tab = 0;
                        }
                    }
                }
                else if (_Ctrl is ComboBox)
                {
                    if (((ComboBox)_Ctrl).SelectedIndex == -1 || ((ComboBox)_Ctrl).SelectedIndex == 0)
                    {
                        string _Str_ControlId = ((ComboBox)_Ctrl).Name;
                        if (_Str_ControlId != _Cmb_PuntoCardinal.Name)
                        {
                            _Er_Error.SetError(_Ctrl, "Información requerida!!!");
                            _Bol_Valido = false;
                            _Int_Tab = 0;
                        }
                    }
                }
            }
            if (!_Bol_Valido)
            {
                MessageBox.Show("Existen campos requeridos sin ingresar", "Requerido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _Tb_Detalle.SelectedIndex = _Int_Tab;
            }

            return _Bol_Valido;
        }
        private bool _Mtd_ValidarSave2()
        {
            int _Int_Tab = 0;
            _Er_Error.Dispose();
            bool _Bol_Valido = true;
            foreach (Control _Ctrl in _Pnl_Cabecera.Controls)
            {
                if (_Ctrl is TextBox)
                {
                    if (((TextBox)_Ctrl).Text.TrimEnd().TrimStart() == "")
                    {
                        string _Str_ControlId = ((TextBox)_Ctrl).Name;
                        if (_Str_ControlId != _Txt_Fax.Name && _Str_ControlId != _Txt_Email.Name && _Str_ControlId != _Txt_Www.Name  && _Str_ControlId != _Txt_CodSunagro.Name)
                        {
                            if (_Str_ControlId == _Txt_CasaMatriz.Name)
                            {
                                if (_Cmb_Clasificacion.SelectedValue.ToString() == "S")
                                {
                                    _Er_Error.SetError(_Ctrl, "Información requerida!!!");
                                    _Bol_Valido = false;
                                }
                                else
                                {
                                }
                            }
                            else
                            {
                                _Er_Error.SetError(_Ctrl, "Información requerida!!!");
                                _Bol_Valido = false;
                            }
                        }
                    }
                }
                else if (_Ctrl is ComboBox)
                {
                    if (((ComboBox)_Ctrl).SelectedIndex == -1 || ((ComboBox)_Ctrl).SelectedIndex == 0)
                    {
                        string _Str_ControlId = ((ComboBox)_Ctrl).Name;
                        if (_Str_ControlId != _Cmb_DireccionDespacho.Name)
                        {
                            _Er_Error.SetError(_Ctrl, "¡¡¡Información requerida!!!");
                            _Bol_Valido = false;
                        }
                    }
                }
            }
            
            if (_Cmb_DireccionDespacho.Items.Count == 1)
            {
                if (_Cmb_DireccionDespacho.Items[0].ToString() == "CLIENTE NO CONTIENE DIRECCIONES DE DESPACHO" || _Cmb_DireccionDespacho.SelectedValue != null)
                {
                    _Er_Error.SetError(_Bt_DireccionDespacho, "¡¡¡Información requerida!!!");
                    _Bol_Valido = false;
                }
            }

            if (_Cmb_TipoCanal.SelectedIndex == -1 || _Cmb_TipoCanal.SelectedIndex == 0)
            {
                _Int_Tab = 1;
                _Er_Error.SetError(_Cmb_TipoCanal, "¡¡¡Información requerida!!!");
                _Bol_Valido = false;
            }
            if (_Cmb_Establecimiento.SelectedIndex == -1 || _Cmb_Establecimiento.SelectedIndex == 0)
            {
                _Int_Tab = 1;
                _Er_Error.SetError(_Cmb_Establecimiento, "¡¡¡Información requerida!!!");
                _Bol_Valido = false;
            }
            if (_Cmb_Estatus.SelectedIndex == -1 || _Cmb_Estatus.SelectedIndex == 0)
            {
                _Int_Tab = 2;
                _Er_Error.SetError(_Cmb_Estatus, "¡¡¡Información requerida!!!");
                _Bol_Valido = false;
            }
            else
            {
                if (_Str_Sw != _Cmb_Estatus.SelectedValue.ToString())
                {
                    if (_Txt_NotaActInact.Text.TrimEnd().TrimStart() == "")
                    {
                        _Int_Tab = 2;
                        _Er_Error.SetError(_Txt_NotaActInact, "¡¡¡Información requerida!!!");
                        _Bol_Valido = false;
                    }
                }
            }
            if (_Cmb_LimiteCredito.SelectedIndex <= 0)
            {
                _Int_Tab = 3;
                _Er_Error.SetError(_Cmb_LimiteCredito, "¡¡¡Información requerida!!!");
                _Bol_Valido = false;
            }
            foreach (Control _Ctrl in tabPage3.Controls)
            {
                if (_Ctrl is TextBox)
                {
                    if (((TextBox)_Ctrl).Text.TrimEnd().TrimStart() == "")
                    {
                        string _Str_ControlId = ((TextBox)_Ctrl).Name;
                        if (_Str_ControlId != _Txt_Esquina.Name && _Str_ControlId != _Txt_Piso.Name && _Str_ControlId != _Txt_Urbanizacion.Name && _Str_ControlId != _Txt_Carretera.Name && _Str_ControlId != _Txt_Carrera.Name && _Str_ControlId != _Txt_Edificio.Name && _Str_ControlId != _Txt_Transversal.Name && _Str_ControlId != _Txt_Calle.Name)
                        {
                            _Er_Error.SetError(_Ctrl, "Información requerida!!!");
                            _Bol_Valido = false;
                            _Int_Tab = 0;
                        }
                    }
                }
                else if (_Ctrl is ComboBox)
                {
                    if (((ComboBox)_Ctrl).SelectedIndex == -1 || ((ComboBox)_Ctrl).SelectedIndex == 0)
                    {
                        string _Str_ControlId = ((ComboBox)_Ctrl).Name;
                        if (_Str_ControlId != _Cmb_PuntoCardinal.Name)
                        {
                            _Er_Error.SetError(_Ctrl, "Información requerida!!!");
                            _Bol_Valido = false;
                            _Int_Tab = 0;
                        }
                    }
                }
            }
            if (!_Bol_Valido)
            {
                MessageBox.Show("Existen campos requeridos sin ingresar", "Requerido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _Tb_Detalle.SelectedIndex = _Int_Tab;
            }
            return _Bol_Valido;
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
        private void _Bt_LimiteCredito_Click(object sender, EventArgs e)
        {
            _Cmb_LimiteCredito.Enabled = true;
        }

        private void _Bt_TipoEmpresa_Click(object sender, EventArgs e)
        {
            _Cmb_TipoEmpresa.Enabled = true;
        }

        private void _Btn_CapSocialPag_Click(object sender, EventArgs e)
        {
            _Txt_CapitalSocialPag.Enabled = true;
        }

        private void _Bt_CapitalSocial_Click(object sender, EventArgs e)
        {
            _Txt_CapitalSocial.Enabled = true;
        }

        private void _Bt_MontoAsegurado_Click(object sender, EventArgs e)
        {
            _Txt_MontoAsegurado.Enabled = true;
        }
        public bool _Mtd_Editar()
        {
            if (_Mtd_ValidarSave2())
            {
                _Pnl_Clave.Visible = true;
                ((Frm_Padre)Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            }
            return false;
        }
        private void _Mtd_Guardar()
        {
            try
            {
                string _Str_SQL = "SELECT TLIMITCREDITO.ccodlimite FROM TCLIENTE INNER JOIN TLIMITCREDITO ON " +
                    " TLIMITCREDITO.ccodlimite=TCLIENTE.C_LIMT_CREDIT" +
                    " WHERE TCLIENTE.CCLIENTE='" + _Txt_Cod.Text + "' AND TCLIENTE.CGROUPCOMP='" + Frm_Padre._Str_GroupComp + "'";
                DataSet _Ds_DataSet = new DataSet();
                bool _Bol_ValidoLimiteCredito=true;
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                   string _Str_LimiteCredito="";
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Str_LimiteCredito = _Ds_DataSet.Tables[0].Rows[0]["ccodlimite"].ToString();
                    string _Str_LimiteSeleccionado = _Cmb_LimiteCredito.SelectedValue.ToString();
                    if (_Str_LimiteCredito != _Str_LimiteSeleccionado)
                    {
                        _Str_SQL = "SELECT RTRIM(TLIMITCREDITO.ccodlimite) " +
    " FROM TLIMITCREDITO INNER JOIN VST_LIMTECREDITO ON TLIMITCREDITO.climtehasta <= VST_LIMTECREDITO.climtehasta" +
     " WHERE (TLIMITCREDITO.cdelete = '0') AND (VST_LIMTECREDITO.cdelete = '0') AND (VST_LIMTECREDITO.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "')" +
      "AND (VST_LIMTECREDITO.cuser = '" + Frm_Padre._Str_Use + "') and TLIMITCREDITO.ccodlimite='"+_Str_LimiteSeleccionado+"'";
                        _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                        _Bol_ValidoLimiteCredito = _Ds_DataSet.Tables[0].Rows.Count != 0;                        
                    }
                }

                if (_Bol_ValidoLimiteCredito)
                {
                    SqlParameter[] paramsToStore = new SqlParameter[78];
                    paramsToStore[0] = new SqlParameter("@cgroupcomp", SqlDbType.Int);
                    paramsToStore[0].Value = Frm_Padre._Str_GroupComp;
                    paramsToStore[1] = new SqlParameter("@ccliente", SqlDbType.Real);
                    paramsToStore[1].Value = _Txt_Cod.Text;
                    paramsToStore[2] = new SqlParameter("@c_rif", SqlDbType.VarChar);
                    paramsToStore[2].Size = 20;
                    paramsToStore[2].Value = _Txt_Rif.Text;
                    paramsToStore[3] = new SqlParameter("@c_nomb_comer", SqlDbType.VarChar);
                    paramsToStore[3].Size = 100;
                    paramsToStore[3].Value = _Txt_NombreComercial.Text.ToUpper();
                    paramsToStore[4] = new SqlParameter("@c_razsocial_1", SqlDbType.VarChar);
                    paramsToStore[4].Size = 100;
                    paramsToStore[4].Value = _Txt_RazonSocialEmpresa.Text.ToUpper();
                    paramsToStore[5] = new SqlParameter("@c_razsocial_2", SqlDbType.VarChar);
                    paramsToStore[5].Size = 100;
                    paramsToStore[5].Value = _Txt_RazonSocialAccionista.Text.ToUpper(); ;
                    paramsToStore[6] = new SqlParameter("@c_direcc_fiscal", SqlDbType.VarChar);
                    paramsToStore[6].Size = 255;
                    paramsToStore[6].Value = _Txt_DireccionFiscal.Text.ToUpper(); ;
                    paramsToStore[7] = new SqlParameter("@c_telefono", SqlDbType.VarChar);
                    paramsToStore[7].Size = 100;
                    paramsToStore[7].Value = _Txt_Telefono.Text;
                    paramsToStore[8] = new SqlParameter("@c_fax", SqlDbType.VarChar);
                    paramsToStore[8].Size = 100;
                    paramsToStore[8].Value = _Txt_Fax.Text;
                    paramsToStore[9] = new SqlParameter("@c_email", SqlDbType.VarChar);
                    paramsToStore[9].Size = 100;
                    paramsToStore[9].Value = _Txt_Email.Text.ToUpper();
                    paramsToStore[10] = new SqlParameter("@c_www", SqlDbType.VarChar);
                    paramsToStore[10].Size = 100;
                    paramsToStore[10].Value = _Txt_Www.Text.ToUpper();
                    paramsToStore[11] = new SqlParameter("@c_inf_replegal", SqlDbType.VarChar);
                    paramsToStore[11].Size = 255;
                    paramsToStore[11].Value = _Txt_RepLegal.Text.ToUpper();
                    paramsToStore[12] = new SqlParameter("@c_tip_contribuy", SqlDbType.VarChar);
                    paramsToStore[12].Size = 10;
                    paramsToStore[12].Value = _Cmb_TipoContribuyente.SelectedValue.ToString();
                    paramsToStore[13] = new SqlParameter("@c_limt_credit", SqlDbType.VarChar);
                    paramsToStore[13].Size = 50;
                    
                    paramsToStore[77] = new SqlParameter("@ccodsunagro", SqlDbType.VarChar);
                    paramsToStore[77].Size = 30;
                    paramsToStore[77].Value = _Txt_CodSunagro.Text.ToUpper(); ;
                    
                    if (_Cmb_LimiteCredito.SelectedValue == null)
                    {
                        paramsToStore[14].Value = "0";
                    }
                    else
                    {
                        paramsToStore[13].Value = _Cmb_LimiteCredito.SelectedValue.ToString();
                    }
                    paramsToStore[14] = new SqlParameter("@c_vie_despa", SqlDbType.VarChar);
                    paramsToStore[14].Size = 50;
                    paramsToStore[14].Value = "";
                    paramsToStore[15] = new SqlParameter("@c_activo", SqlDbType.TinyInt);
                    paramsToStore[15].Value = _Cmb_Estatus.SelectedValue.ToString();
                    paramsToStore[16] = new SqlParameter("@c_clasifica", SqlDbType.VarChar);
                    paramsToStore[16].Size = 10;
                    paramsToStore[16].Value = _Cmb_Clasificacion.SelectedValue.ToString();
                    paramsToStore[17] = new SqlParameter("@c_casa_matriz", SqlDbType.VarChar);
                    paramsToStore[17].Size = 10;
                    paramsToStore[17].Value = _Txt_CasaMatriz.Text;
                    paramsToStore[18] = new SqlParameter("@cfpago", SqlDbType.VarChar);
                    paramsToStore[18].Size = 10;
                    if (_Cmb_FormaPago.SelectedValue != null)
                    {
                        paramsToStore[18].Value = _Cmb_FormaPago.SelectedValue.ToString();
                    }
                    else
                    {
                        paramsToStore[18].Value = "0";
                    }
                    paramsToStore[19] = new SqlParameter("@c_info_cont_1", SqlDbType.VarChar);
                    paramsToStore[19].Size = 255;
                    paramsToStore[19].Value = _Txt_Contacto_1.Text.ToUpper();
                    paramsToStore[20] = new SqlParameter("@c_info_cont_2", SqlDbType.VarChar);
                    paramsToStore[20].Size = 255;
                    paramsToStore[20].Value = _Txt_Contacto_2.Text.ToUpper();
                    paramsToStore[21] = new SqlParameter("@c_info_cont_3", SqlDbType.VarChar);
                    paramsToStore[21].Size = 255;
                    paramsToStore[21].Value = _Txt_Contacto_3.Text.ToUpper();
                    paramsToStore[22] = new SqlParameter("@c_banco_neg", SqlDbType.VarChar);
                    paramsToStore[22].Size = 10;
                    if (_Cmb_Banco_1.SelectedValue != null)
                    {
                        paramsToStore[22].Value = _Cmb_Banco_1.SelectedValue.ToString();
                    }
                    else
                    {
                        paramsToStore[22].Value = "0";
                    }
                    paramsToStore[23] = new SqlParameter("@c_banco_per", SqlDbType.VarChar);
                    paramsToStore[23].Size = 10;
                    if (_Cmb_Banco_2.SelectedValue != null)
                    {
                        paramsToStore[23].Value = _Cmb_Banco_2.SelectedValue.ToString();
                    }
                    else
                    {
                        paramsToStore[23].Value = "0";
                    }
                    paramsToStore[24] = new SqlParameter("@c_banco_soc", SqlDbType.VarChar);
                    paramsToStore[24].Size = 10;
                    if (_Cmb_Banco_3.SelectedValue != null)
                    {
                        paramsToStore[24].Value = _Cmb_Banco_3.SelectedValue.ToString();
                    }
                    else
                    {
                        paramsToStore[24].Value = "0";
                    }
                    paramsToStore[25] = new SqlParameter("@c_cuenta_neg", SqlDbType.VarChar);
                    paramsToStore[25].Size = 30;
                    paramsToStore[25].Value = _Txt_CuentaBanc1.Text;
                    paramsToStore[26] = new SqlParameter("@c_cuenta_per", SqlDbType.VarChar);
                    paramsToStore[26].Size = 30;
                    paramsToStore[26].Value = _Txt_CuentaBanc2.Text;
                    paramsToStore[27] = new SqlParameter("@c_cuenta_soc", SqlDbType.VarChar);
                    paramsToStore[27].Size = 30;
                    paramsToStore[27].Value = _Txt_CuentaBanc3.Text;
                    paramsToStore[28] = new SqlParameter("@c_especial", SqlDbType.TinyInt);
                    paramsToStore[28].Value = "0";
                    paramsToStore[29] = new SqlParameter("@c_refcomercial1", SqlDbType.VarChar);
                    paramsToStore[29].Size = 255;
                    paramsToStore[29].Value = "0";
                    paramsToStore[30] = new SqlParameter("@c_refcomercial2", SqlDbType.VarChar);
                    paramsToStore[30].Size = 255;
                    paramsToStore[30].Value = "0";
                    paramsToStore[31] = new SqlParameter("@c_refcomercial3", SqlDbType.VarChar);
                    paramsToStore[31].Size = 255;
                    paramsToStore[31].Value = "0";
                    paramsToStore[32] = new SqlParameter("@c_localstatus", SqlDbType.VarChar);
                    paramsToStore[32].Size = 255;
                    if (_Chbox_PoseeLocalPropio.Checked)
                    {
                        paramsToStore[32].Value = "1";
                    }
                    else
                    {
                        paramsToStore[32].Value = "0";
                    }
                    paramsToStore[33] = new SqlParameter("@c_seguro", SqlDbType.TinyInt);
                    if (_Chbox_PoseePolizaSeguro.Checked)
                    {
                        paramsToStore[33].Value = "1";
                    }
                    else
                    {
                        paramsToStore[33].Value = "0";
                    }
                    paramsToStore[33].Value = "0";
                    paramsToStore[34] = new SqlParameter("@c_promcompra", SqlDbType.Real);
                    if (_Cmb_PromedioCompras.SelectedValue != null)
                    {
                        paramsToStore[34].Value = _Cmb_PromedioCompras.SelectedValue.ToString();
                    }
                    else
                    {
                        paramsToStore[34].Value = "0";
                    }
                    paramsToStore[35] = new SqlParameter("@c_comprelacio", SqlDbType.Int);
                    paramsToStore[35].Value = "0";
                    paramsToStore[36] = new SqlParameter("@c_balancegen", SqlDbType.TinyInt);
                    paramsToStore[36].Value = Convert.ToInt32(_Chbox_BalanceGeneral.Checked);
                    paramsToStore[37] = new SqlParameter("@c_estganyper", SqlDbType.TinyInt);
                    paramsToStore[37].Value = Convert.ToInt32(_Chbox_EstadoGananciasPerdidas.Checked);
                    paramsToStore[38] = new SqlParameter("@c_otrosef", SqlDbType.TinyInt);
                    paramsToStore[38].Value = "0";
                    paramsToStore[39] = new SqlParameter("@c_regmercantil", SqlDbType.TinyInt);
                    paramsToStore[39].Value = Convert.ToInt32(_Chbox_RegistroMercantil.Checked);
                    paramsToStore[40] = new SqlParameter("@c_riffoto", SqlDbType.TinyInt);
                    paramsToStore[40].Value = Convert.ToInt32(_Chbox_Rif.Checked);
                    paramsToStore[41] = new SqlParameter("@c_nitfoto", SqlDbType.TinyInt);
                    paramsToStore[41].Value = "0";
                    paramsToStore[42] = new SqlParameter("@c_cedfoto", SqlDbType.TinyInt);
                    paramsToStore[42].Value = Convert.ToInt32(_Chbox_Ci.Checked); ;
                    paramsToStore[43] = new SqlParameter("@c_estable", SqlDbType.VarChar);
                    paramsToStore[43].Size = 10;
                    if (_Cmb_Establecimiento.SelectedValue != null)
                    {
                        paramsToStore[43].Value = _Cmb_Establecimiento.SelectedValue.ToString();
                    }
                    else
                    {
                        paramsToStore[43].Value = "0";
                    }
                    paramsToStore[44] = new SqlParameter("@c_canal", SqlDbType.VarChar);
                    paramsToStore[44].Size = 10;
                    if (_Cmb_TipoCanal.SelectedValue != null)
                    {
                        paramsToStore[44].Value = _Cmb_TipoCanal.SelectedValue.ToString();
                    }
                    else
                    {
                        paramsToStore[44].Value = "0";
                    }
                    paramsToStore[45] = new SqlParameter("@cdateupd", SqlDbType.DateTime);
                    paramsToStore[45].Value = DateTime.Now.ToString("dd/MM/yyyy");
                    paramsToStore[46] = new SqlParameter("@cuserupd", SqlDbType.VarChar);
                    paramsToStore[46].Size = 50;
                    paramsToStore[46].Value = Frm_Padre._Str_Use;
                    paramsToStore[47] = new SqlParameter("@c_municipio", SqlDbType.VarChar);
                    paramsToStore[47].Size = 50;
                    paramsToStore[47].Value = _Cmb_Municipio.SelectedValue;
                    paramsToStore[48] = new SqlParameter("@c_parroquia", SqlDbType.VarChar);
                    paramsToStore[48].Size = 50;
                    paramsToStore[48].Value = _Cmb_Parroquia.SelectedValue;
                    paramsToStore[49] = new SqlParameter("@c_sector", SqlDbType.VarChar);
                    paramsToStore[49].Size = 30;
                    paramsToStore[49].Value = _Txt_Sector.Text.ToUpper();
                    paramsToStore[50] = new SqlParameter("@c_urbanizacion", SqlDbType.VarChar);
                    paramsToStore[50].Size = 30;
                    paramsToStore[50].Value = _Txt_Urbanizacion.Text.ToUpper();
                    paramsToStore[51] = new SqlParameter("@c_carretera", SqlDbType.VarChar);
                    paramsToStore[51].Size = 30;
                    paramsToStore[51].Value = _Txt_Carretera.Text.ToUpper();
                    paramsToStore[52] = new SqlParameter("@c_avenida", SqlDbType.VarChar);
                    paramsToStore[52].Size = 30;
                    paramsToStore[52].Value = _Txt_Avenida.Text.ToUpper();
                    paramsToStore[53] = new SqlParameter("@c_calle", SqlDbType.VarChar);
                    paramsToStore[53].Size = 30;
                    paramsToStore[53].Value = _Txt_Calle.Text.ToUpper();
                    paramsToStore[54] = new SqlParameter("@c_carrera", SqlDbType.VarChar);
                    paramsToStore[54].Size = 30;
                    paramsToStore[54].Value = _Txt_Carrera.Text.ToUpper();
                    paramsToStore[55] = new SqlParameter("@c_transversal", SqlDbType.VarChar);
                    paramsToStore[55].Size = 30;
                    paramsToStore[55].Value = _Txt_Transversal.Text.ToUpper();
                    paramsToStore[56] = new SqlParameter("@c_esquina", SqlDbType.VarChar);
                    paramsToStore[56].Size = 30;
                    paramsToStore[56].Value = _Txt_Esquina.Text.ToUpper();
                    paramsToStore[57] = new SqlParameter("@c_piso", SqlDbType.VarChar);
                    paramsToStore[57].Size = 30;
                    paramsToStore[57].Value = _Txt_Piso.Text.ToUpper();
                    paramsToStore[58] = new SqlParameter("@c_edificio", SqlDbType.VarChar);
                    paramsToStore[58].Size = 30;
                    paramsToStore[58].Value = _Txt_Edificio.Text.ToUpper();
                    paramsToStore[59] = new SqlParameter("@c_local", SqlDbType.VarChar);
                    paramsToStore[59].Size = 30;
                    paramsToStore[59].Value = _Txt_Local.Text.ToUpper();
                    paramsToStore[60] = new SqlParameter("@c_preferencia", SqlDbType.VarChar);
                    paramsToStore[60].Size = 50;
                    paramsToStore[60].Value = _Txt_Referencia.Text.ToUpper();
                    paramsToStore[61] = new SqlParameter("@c_pcardinal", SqlDbType.VarChar);
                    paramsToStore[61].Size = 1;
                    if (_Cmb_PuntoCardinal.SelectedValue != null)
                    {
                        paramsToStore[61].Value = _Cmb_PuntoCardinal.SelectedValue.ToString();
                    }
                    else
                    {
                        paramsToStore[61].Value = "0";
                    }
                    paramsToStore[62] = new SqlParameter("@c_estado", SqlDbType.VarChar);
                    paramsToStore[62].Size = 50;
                    paramsToStore[62].Value = _Cmb_Estado.SelectedValue.ToString();
                    paramsToStore[63] = new SqlParameter("@c_ciudad", SqlDbType.VarChar);
                    paramsToStore[63].Size = 50;
                    paramsToStore[63].Value = _Cmb_Ciudad.SelectedValue.ToString();
                    paramsToStore[64] = new SqlParameter("@c_bloquin", SqlDbType.VarChar);
                    paramsToStore[64].Size = 10;
                    paramsToStore[64].Value = "0";
                    paramsToStore[65] = new SqlParameter("@c_constitulegal", SqlDbType.TinyInt);
                    paramsToStore[65].Value = "0";
                    paramsToStore[66] = new SqlParameter("@c_numacciones", SqlDbType.Real);
                    if (_Txt_NumAccionistas.Text != "")
                    {
                        paramsToStore[66].Value = _Txt_NumAccionistas.Text;
                    }
                    else
                    {
                        paramsToStore[66].Value = "0";
                    }

                    paramsToStore[67] = new SqlParameter("@c_capitalsolreg", SqlDbType.Real);
                    if (_Txt_CapitalSocial.Text != "")
                    {
                        paramsToStore[67].Value = _Txt_CapitalSocial.Text;
                    }
                    else
                    {
                        paramsToStore[67].Value = "0";
                    }
                    paramsToStore[68] = new SqlParameter("@c_capitalsolpag", SqlDbType.Real);
                    if (_Txt_CapitalSocialPag.Text != "")
                    {
                        paramsToStore[68].Value = _Txt_CapitalSocialPag.Text;
                    }
                    else
                    {
                        paramsToStore[68].Value = "0";
                    }
                    paramsToStore[69] = new SqlParameter("@c_atendidodirecto", SqlDbType.TinyInt);
                    paramsToStore[69].Value = Convert.ToInt32(_Chbox_AtendidoDirecto.Checked);
                    paramsToStore[70] = new SqlParameter("@cbackorder", SqlDbType.TinyInt);
                    paramsToStore[70].Value = Convert.ToInt32(false);//_Chbox_BackOrder.Checked);
                    paramsToStore[71] = new SqlParameter("@cfechregmer", SqlDbType.DateTime);
                    paramsToStore[71].Value = _Dtp_Fecha_Registro.Value.ToString("dd/MM/yyyy");

                    if (this._Cmb_Estatus.SelectedValue.ToString() == "1")
                    {

                        paramsToStore[72] = new SqlParameter("@c_fecha_reactivacion", SqlDbType.DateTime);
                        if (this._Txt_FechaActInact.Text != "")
                        {
                            paramsToStore[72].Value = this._Txt_FechaActInact.Text.ToString().TrimEnd();
                        }
                        else
                        {
                            paramsToStore[72].Value = System.DBNull.Value;
                        }
                        paramsToStore[73] = new SqlParameter("@c_notasreactivacion", SqlDbType.VarChar);
                        paramsToStore[73].Size = 255;
                        paramsToStore[73].Value = this._Txt_NotaActInact.Text.TrimEnd();

                        paramsToStore[74] = new SqlParameter("@c_fecha_inactivo", SqlDbType.DateTime);
                        paramsToStore[74].Value = System.DBNull.Value;
                        paramsToStore[75] = new SqlParameter("@c_notasinactivo", SqlDbType.VarChar);
                        paramsToStore[75].Size = 255;
                        paramsToStore[75].Value = "";
                    }
                    else
                    {
                        paramsToStore[72] = new SqlParameter("@c_fecha_reactivacion", SqlDbType.DateTime);
                        paramsToStore[72].Value = System.DBNull.Value;
                        paramsToStore[73] = new SqlParameter("@c_notasreactivacion", SqlDbType.VarChar);
                        paramsToStore[73].Size = 255;
                        paramsToStore[73].Value = "";

                        paramsToStore[74] = new SqlParameter("@c_fecha_inactivo", SqlDbType.DateTime);
                        paramsToStore[74].Value = this._Txt_FechaActInact.Text.ToString().TrimEnd();
                        paramsToStore[75] = new SqlParameter("@c_notasinactivo", SqlDbType.VarChar);
                        paramsToStore[75].Size = 255;
                        paramsToStore[75].Value = this._Txt_NotaActInact.Text.TrimEnd();
                    }

                    paramsToStore[76] = new SqlParameter("@c_listanegra", SqlDbType.TinyInt);
                    paramsToStore[76].Value = Convert.ToInt32(cb_lista_negra.Checked);

                    CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("SP_MODIFICARCLIENTET3", paramsToStore);
                    MessageBox.Show("Se realizaron los cambios correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Tb_Tab.SelectedIndex = 0;
                    _Str_fecha = "";
                    _Str_Notas = "";
                    _Mtd_Actualizar();
                }
                else
                {
                    MessageBox.Show("El límite de crédito seleccionado es mayor al máximo autorizado a su perfil de usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                }
            }
            catch {}
            finally {}
        }

        private bool _Mtd_ContributyenteEspecial(string _P_Str_ClienteId)
        {
            var _Str_Cadena = "SELECT c_tip_contribuy FROM TCLIENTE WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _P_Str_ClienteId + "' AND c_tip_contribuy='2'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        public void _Mtd_Habilitar()
        {
            _Btn_CasaMatriz.Enabled = false;
            if (_G_MyUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _G_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_INF_FISCAL_CLIENT"))
            {            
                _Bt_CodSunagro.Enabled = true;
                _Bt_DireccionFiscal.Enabled = true;
                _Bt_Email.Enabled = true;
                _Bt_Fax.Enabled = true;
                _Bt_NombreComercial.Enabled = true;
                _Bt_Telefono.Enabled = true;
                _Bt_Www.Enabled = true;
                _Bt_Clasificacion.Enabled = true;
                if (_Cmb_Clasificacion.SelectedValue.ToString() == "S")
                {
                    _Btn_CasaMatriz.Enabled = true;
                }
                else
                {
                    _Btn_CasaMatriz.Enabled = false;
                }
                _Bt_Seniat.Enabled = true; 
                _Bt_RazonSocialAccionista.Enabled = true;
                _Bt_RazonSocialEmpresa.Enabled = true;
            }
            if (_G_MyUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && 
                (_G_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EDIT_TIPO_CONTRIBUYENTE2") ||
                (_G_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EDIT_TIPO_CONTRIBUYENTE") && !_Mtd_ContributyenteEspecial(_Txt_Cod.Text.Trim()))))
            {
                _Bt_TipoContribuyente.Enabled = true;
            }
            if (_G_MyUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _G_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_DIR_DESPA_CLIENT"))
            {
                _Bt_DireccionDespacho.Enabled = true;
            }
            if (_G_MyUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _G_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_DIR_COMER_CLIENT"))
            {
                _Bt_Direccion.Enabled = true;
            }
            if (_G_MyUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _G_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_INF_VTAS_CLIENT"))
            {
                _Bt_TipoCanal.Enabled = true;
                _Bt_Establecimiento.Enabled = true;
                _Bt_AtendidoDirecto.Enabled = true;
                //_Bt_BackOrder.Enabled = true;
                _Bt_ZonaVentas.Enabled = true;
                _Bt_Contactos.Enabled = true;
                _Bt_Atendido.Enabled = true;
            }
            if (_G_MyUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _G_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_INF_COBRA_CLIENT"))
            {
                _Bt_DocumentacionCliente.Enabled = true;
                _Bt_Estatus.Enabled = true;
                _Bt_CuentaBanc1.Enabled = true;
                _Bt_CuentaBanc2.Enabled = true;
                _Bt_CuentaBanc3.Enabled = true;
                _Bt_HistorialCliente.Enabled = true;
                _Bt_DocumentosPendientes.Enabled = true;
                _Btn_lista_negra.Enabled = true;
            }
            if (_G_MyUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _G_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EVA_RIESGO_CLIENT"))
            {
                _Bt_LimiteCredito.Enabled = _G_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EDIT_LIMIT_CREDIT");
                _Bt_TipoEmpresa.Enabled = true;
                _Btn_CapSocialPag.Enabled = true;
                _Bt_CapitalSocial.Enabled = true;
                _Bt_MontoAsegurado.Enabled = true;
                _Bt_PoseePolizaSeguro.Enabled = true;
                _Bt_PoseeLocalPropio.Enabled = true;
                _Bt_PoseeDepositoMercancia.Enabled = true;
                _Bt_TieneSucursalesAgentes.Enabled = true;
                _Bt_Actualizar.Enabled = true;
                _Bt_FechaRegistroMercantil.Enabled = true;
                _Bt_PromedioCompras.Enabled = true;
                _Bt_AprobarCliente.Enabled = true;
                _Bt_RechazarCliente.Enabled = true;
                _Bt_ReferenciasComerciales.Enabled = true;
            }
            _Bt_DireccionDespacho.Enabled = true; 
            _Bt_CodSunagro.Enabled = true;
            _G_Str_MyProceso = "M";
        }
        private void _Bt_PoseePolizaSeguro_Click(object sender, EventArgs e)
        {
            _Chbox_PoseePolizaSeguro.Enabled = true;
        }

        private void _Bt_PoseeLocalPropio_Click(object sender, EventArgs e)
        {
            _Chbox_PoseeLocalPropio.Enabled = true;
        }

        private void _Bt_PoseeDepositoMercancia_Click(object sender, EventArgs e)
        {
            _Chbox_PoseeDepositoMercancia.Enabled = true;
        }

        private void _Bt_TieneSucursalesAgentes_Click(object sender, EventArgs e)
        {
            _Chbox_TieneSucursalesAgentes.Enabled = true;
        }

        private void _Bt_PromedioCompras_Click(object sender, EventArgs e)
        {
            _Cmb_PromedioCompras.Enabled = true;
        }

        private void _Bt_CompraLinea_Click(object sender, EventArgs e)
        {
            _Cmb_CompraLinea.Enabled = true;
        }

        private void _Bt_ReferenciasComerciales_Click(object sender, EventArgs e)
        {
            _Mtd_Bloquear_Group(groupBox5, true); groupBox5.Enabled = true;
        }

        private void _Bt_Actualizar_Click(object sender, EventArgs e)
        {
            _Mtd_CargarSaldo(_Txt_Cod.Text);
        }

        private void _Cmb_TipoContribuyente_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Contribuyente();
        }

        private void _Cmb_Clasificacion_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Clasificacion();
        }

        private void _Cmb_TipoCanal_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Canal();
        }

        private void _Cmb_Establecimiento_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_TipoCanal.SelectedValue != null)
            {
                _Mtd_Cargar_Establecimiento(_Cmb_TipoCanal.SelectedValue.ToString());
            }
        }

        private void _Bt_HistorialCliente_Click(object sender, EventArgs e)
        {
            Frm_Inf_HistCliente _frm = new Frm_Inf_HistCliente(this._Txt_Cod.Text.Trim(), _Txt_NombreComercial.Text.Trim());
            _frm.MdiParent = this.MdiParent;
            _frm.Dock = DockStyle.Fill;
            _frm.Show();
        }
        
        private void _Bt_DocumentosPendientes_Click(object sender, EventArgs e)
        {
            //Frm_EstatusClientesDetalle _FRM_FORM=new Frm_EstatusClientesDetalle(
        }

        public void _Mtd_BotonesMenu()
        {
            if (this.MdiParent != null)
            {
                CONTROLES._Ctrl_Buscar._frm_Formulario = this;
                CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
                CONTROLES._Ctrl_Buscar._Bl_Especial = true;
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                if (_G_Str_MyProceso == "M")
                {
                    CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = !_Pnl_Clave.Visible;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                }
                if (_G_Str_MyProceso == "")
                {
                    if (_Txt_Cod.Text.Trim().Length > 0)
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    }
                    else
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    }
                }
            }
        }

        private void Frm_Clientes_VC_1_Activated(object sender, EventArgs e)
        {
            if (this.MdiParent != null)
            {
                _Mtd_BotonesMenu();
            }
            else
            {
                CONTROLES._Ctrl_Buscar._txt_text.Text = "";
                CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
            }
            _Mtd_ZonasVentas();
        }

        private void Frm_Clientes_VC_1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Txt_CuentaBanc1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_CuentaBanc2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_CuentaBanc3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_NumAccionistas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_CapitalSocialPag_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_CapitalSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_MontoAsegurado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_CapitalSocialPag_Leave(object sender, EventArgs e)
        {
            try
            {
                string _Str_Cadena = "Select dbo.Fnc_Formatear(" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_CapitalSocialPag.Text.Trim())) + ")";
                _Txt_CapitalSocialPag.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString();
            }
            catch { }
        }

        private void _Txt_CapitalSocial_Leave(object sender, EventArgs e)
        {
            try
            {
                string _Str_Cadena = "Select dbo.Fnc_Formatear(" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_CapitalSocial.Text.Trim())) + ")";
                _Txt_CapitalSocial.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString();
            }
            catch { }
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private void _Txt_CapitalSocial_TextChanged(object sender, EventArgs e)
        {
            string _Str_Cadena = "";
            try
            {
                _Str_Cadena = CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_CapitalSocial.Text.Trim()));
                if (!_Mtd_IsNumeric(_Str_Cadena))
                {
                    _Txt_CapitalSocial.Text = "";
                }
            }
            catch { _Txt_CapitalSocial.Text = ""; }
            if (_Txt_CapitalSocial.Text.Trim().Length > 11 & _Txt_CapitalSocial.Text.Trim().IndexOf(",") == -1 & _Txt_CapitalSocial.Text.Trim().IndexOf(".") == -1)
            { _Txt_CapitalSocial.Text = _Txt_CapitalSocial.Text.Trim().Substring(0, _Txt_CapitalSocial.Text.Trim().Length - 1); _Txt_CapitalSocial.Select(0, _Txt_CapitalSocial.Text.Length); }
        }

        private void _Txt_CapitalSocialPag_TextChanged(object sender, EventArgs e)
        {
            string _Str_Cadena = "";
            try
            {
                _Str_Cadena = CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_CapitalSocialPag.Text.Trim()));
                if (!_Mtd_IsNumeric(_Str_Cadena))
                {
                    _Txt_CapitalSocialPag.Text = "";
                }
            }
            catch { _Txt_CapitalSocialPag.Text = ""; }
            if (_Txt_CapitalSocialPag.Text.Trim().Length > 11 & _Txt_CapitalSocialPag.Text.Trim().IndexOf(",") == -1 & _Txt_CapitalSocialPag.Text.Trim().IndexOf(".") == -1)
            { _Txt_CapitalSocialPag.Text = _Txt_CapitalSocialPag.Text.Trim().Substring(0, _Txt_CapitalSocialPag.Text.Trim().Length - 1); _Txt_CapitalSocialPag.Select(0, _Txt_CapitalSocialPag.Text.Length); }
        }

        private void _Txt_MontoAsegurado_TextChanged(object sender, EventArgs e)
        {
            string _Str_Cadena = "";
            try
            {
                _Str_Cadena = CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_MontoAsegurado.Text.Trim()));
                if (!_Mtd_IsNumeric(_Str_Cadena))
                {
                    _Txt_MontoAsegurado.Text = "";
                }
            }
            catch { _Txt_MontoAsegurado.Text = ""; }
            if (_Txt_MontoAsegurado.Text.Trim().Length > 11 & _Txt_MontoAsegurado.Text.Trim().IndexOf(",") == -1 & _Txt_MontoAsegurado.Text.Trim().IndexOf(".") == -1)
            { _Txt_MontoAsegurado.Text = _Txt_MontoAsegurado.Text.Trim().Substring(0, _Txt_MontoAsegurado.Text.Trim().Length - 1); _Txt_MontoAsegurado.Select(0, _Txt_MontoAsegurado.Text.Length); }
        }

        private void _Txt_MontoAsegurado_Leave(object sender, EventArgs e)
        {
            try
            {
                string _Str_Cadena = "Select dbo.Fnc_Formatear(" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_MontoAsegurado.Text.Trim())) + ")";
                _Txt_MontoAsegurado.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString();
            }
            catch { }
        }

        private void _Cmb_TipoEmpresa_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_TipoEmpresa();
        }

        private void _Cmb_LimiteCredito_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_LimiteCredito();
        }

        private void _Bt_FechaRegistroMercantil_Click(object sender, EventArgs e)
        {
            _Dtp_Fecha_Registro.Enabled = true;
        }

        private void _Cmb_Clasificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Clasificacion.SelectedValue != null)
            {
                if (_Cmb_Clasificacion.SelectedValue.ToString().TrimEnd() == "S")
                {
                    this._Btn_CasaMatriz.Enabled = true;
                }
                else
                {
                    this._Btn_CasaMatriz.Enabled = false;
                    _Txt_CasaMatriz.Text = "";
                }
            }
            else
            {
                this._Btn_CasaMatriz.Enabled = false;
                _Txt_CasaMatriz.Text = "";
            }
        }

        private void _Btn_CasaMatriz_Click(object sender, EventArgs e)
        {
            Frm_Busqueda2 _Frm_Form = new Frm_Busqueda2(42,_Txt_CasaMatriz,0,"");
            _Frm_Form.ShowDialog();
            if (_Frm_Form._Str_FrmResult == "1")
            {
                this._Txt_CasaMatriz.Text = _Frm_Form._Dg_Grid[0, _Frm_Form._Dg_Grid.CurrentCell.RowIndex].Value.ToString().TrimEnd();
            }
        }

        private void _Rbt_Act_CheckedChanged(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
        }
        private bool _Mtd_VerificarCliente()
        {
            bool _Bol_Valido = true;
            try
            {
                string _Str_Cadena = "SELECT CSALDOFACTURA FROM TSALDOCLIENTED WHERE CCLIENTE='" + _Txt_Cod.Text + "' AND cgroupcomp='"+Frm_Padre._Str_GroupComp+"' AND CSALDOFACTURA>0";
                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Bol_Valido = false;
                }
                if (_Bol_Valido)
                {
                    _Str_Cadena = "SELECT cidnotcredicc FROM TNOTACREDICC WHERE cimpresa='1' and cdescontada='0' and ccliente='" + _Txt_Cod.Text + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND canulado='0'";
                    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                    {
                        _Bol_Valido = false;
                    }
                }
            }
            catch
            {
            }
            return _Bol_Valido;
        }
        private void _Cmb_Estatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool _Bol_Valido = true;
            if (_Cmb_Estatus.SelectedValue != null)
            {
                switch (_Cmb_Estatus.SelectedValue.ToString())
                {
                    case "0":
                        _Bol_Valido = _Mtd_VerificarCliente();
                        if (_Bol_Valido)
                        {
                            _Lbl_NotaActInact.Text = "Nota de Inactivación";
                            _Lbl_FechaActInact.Text = "Fecha de Inactivación";
                            _Lbl_FechaActInact.Enabled = true;
                            _Lbl_NotaActInact.Enabled = true;
                        }
                        break;
                    case "1":
                        _Lbl_NotaActInact.Text = "Nota de Reactivación";
                        _Lbl_FechaActInact.Text = "Fecha de Reactivación";
                        _Lbl_FechaActInact.Enabled = true;
                        _Lbl_NotaActInact.Enabled = true;
                        break;
                    default:
                        break;
                }

                if (_Cmb_Estatus.SelectedValue.ToString().TrimEnd() != "...")
                {                    
                    if (_Str_Sw != _Cmb_Estatus.SelectedValue.ToString())
                    {
                        if (_Str_Sw == "1" && !_Bol_Valido)
                        {
                            _Txt_NotaActInact.Text = _Str_Notas;
                            _Lbl_FechaActInact.Enabled = false;
                            //_Txt_FechaActInact.Enabled = false;
                            _Txt_FechaActInact.Text = _Str_fecha;
                            _Lbl_NotaActInact.Enabled = false;
                            _Txt_NotaActInact.Enabled = false;
                            _Txt_NotaActInact.Text = _Str_Notas;
                            _Cmb_Estatus.SelectedIndexChanged += new EventHandler(_Cmb_Estatus_SelectedIndexChanged);
                            _Cmb_Estatus.SelectedValue=_Str_Sw;
                            _Cmb_Estatus.SelectedIndexChanged -= new EventHandler(_Cmb_Estatus_SelectedIndexChanged);
                            MessageBox.Show("Disculpe el cliente no puede ser inactivado por poseer documentos pendientes", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (_Cmb_Estatus.SelectedValue.ToString() == "nulo")
                            {
                                _Txt_NotaActInact.Text = _Str_Notas;
                                _Lbl_FechaActInact.Enabled = false;
                                //_Txt_FechaActInact.Enabled = false;
                                _Txt_FechaActInact.Text = _Str_fecha;
                                _Lbl_NotaActInact.Enabled = false;
                                _Txt_NotaActInact.Enabled = false;
                                _Txt_NotaActInact.Text = _Str_Notas;
                            }
                            else
                            {
                                _Lbl_FechaActInact.Visible = true;
                                _Txt_FechaActInact.Visible = true;
                                _Lbl_NotaActInact.Visible = true;
                                _Txt_NotaActInact.Visible = true;

                                _Txt_FechaActInact.Text = _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ());
                                _Txt_NotaActInact.Text = "";
                                //_Txt_FechaActInact.Enabled = true;
                                _Txt_NotaActInact.Enabled = true;
                                _Txt_NotaActInact.Focus();
                            }
                        }
                    }
                    else
                    {
                        _Txt_NotaActInact.Text = _Str_Notas;
                        _Lbl_FechaActInact.Enabled = false;
                        //_Txt_FechaActInact.Enabled = false;
                        _Txt_FechaActInact.Text = _Str_fecha;
                        _Lbl_NotaActInact.Enabled = false;
                        _Txt_NotaActInact.Enabled = false;
                        _Txt_NotaActInact.Text = _Str_Notas;
                    }                    
                }
                else
                {
                    _Lbl_FechaActInact.Visible = false;
                    _Txt_FechaActInact.Visible = false;
                    _Lbl_NotaActInact.Visible = false;
                    _Txt_NotaActInact.Visible = false;
                }
            }
        }

        private void _Txt_NotaActInact_Validating(object sender, CancelEventArgs e)
        {
            if (this._Txt_NotaActInact.Text == "")
            {
                _Txt_NotaActInact.SelectionStart = 0;
                _Txt_NotaActInact.SelectionLength = _Txt_NotaActInact.Text.Length;
                _Er_Error.SetError(_Txt_NotaActInact, "El campo se encuentra vacío");
                //e.Cancel = true;
            }
        }

        private void _Btn_lista_negra_Click(object sender, EventArgs e)
        {
            cb_lista_negra.Enabled = true;
        }

        private void _Bt_BloqueoManualClienteCancelar_Click(object sender, EventArgs e)
        {
          _Pnl_BloqueoManualCliente.Visible = false;
        }

        private void _Bt_BloqueoManualClienteAceptar_Click(object sender, EventArgs e)
        {
          //Cursor = Cursors.WaitCursor;
          byte[] hash = _Mtd_ConvertStringToByteArray(_Txt_BloqueoManualClienteClave.Text);
          byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
          string cod = BitConverter.ToString(valorhash);
          cod = cod.Replace("-", "");
          try
          {
            //Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT cpassw  FROM TUSER WHERE cuser= '" + Frm_Padre._Str_Use.ToString() + "' and cpassw= '" + cod.ToString() + "'";
            System.Data.DataSet Ds22 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (Ds22.Tables[0].Rows.Count > 0)
            {
              if (_Txt_BloqueoManualClienteRazon.Text.Trim() != "")
              {
                _Str_Cadena = "Update TCLIENTE set c_bloqueo_manual = 1, c_bloqueo_manual_usuario = '" + Frm_Padre._Str_Use.ToString() + "', c_bloqueo_manual_fecha = GETDATE(), c_motivo_bloqueo_manual = '" + _Txt_BloqueoManualClienteRazon.Text.ToUpper() + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccliente='" + _Txt_Cod.Text + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                MessageBox.Show("El cliente ha sido bloqueado satisfactoriamente.", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Pnl_BloqueoManualCliente.Visible = false;
              }
              else
              {
                MessageBox.Show("La razón de bloqueo no puede estar en blanco. Verifique.", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              }
            }
            else
            {
              MessageBox.Show(this, "Clave incorrecta. Verifique.", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              _Txt_BloqueoManualClienteRazon.Focus();
              _Txt_BloqueoManualClienteRazon.Select(0, _Txt_BloqueoManualClienteRazon.Text.Length);
            }
          }
          catch (Exception _Ex)
          {
            MessageBox.Show("ERROR:" + _Ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          }
          //Cursor = Cursors.Default;
        }
        
        private static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
          return (new UnicodeEncoding()).GetBytes(s);
        }

        private void _Bt_BloqueoManualCliente_Click(object sender, EventArgs e)
        {
          if (!_Mtd_ClienteTieneBloqueoManual(Frm_Padre._Str_GroupComp, _Txt_Cod.Text))
          {
            _Txt_BloqueoManualClienteRazon.Text = "";
            _Txt_BloqueoManualClienteClave.Text = "";
            _Pnl_BloqueoManualCliente.Visible = true;
            _Txt_BloqueoManualClienteRazon.Focus();
          }
          else
          {
            MessageBox.Show(this, "No se puede realizar el proceso porque ese cliente ya se encuentra bloqueado. Verifique.", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
        }

        private bool _Mtd_ClienteTieneBloqueoManual(string _Str_CodGrupoEmpresa, string _Str_CodCliente)
        {
          bool _Boo_Retornar = false;
          string _Str_SQL = "SELECT ISNULL(c_bloqueo_manual,0) as c_bloqueo_manual FROM TCLIENTE WHERE cgroupcomp='" + _Str_CodGrupoEmpresa + "' AND ccliente='" + _Str_CodCliente + "'";
          System.Data.DataSet Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
          if (Ds.Tables[0].Rows.Count > 0) _Boo_Retornar = Convert.ToBoolean(Ds.Tables[0].Rows[0]["c_bloqueo_manual"]);
          return _Boo_Retornar;
        }

        private void _Pnl_BloqueoManualCliente_VisibleChanged(object sender, EventArgs e)
        {
          if (_Pnl_BloqueoManualCliente.Visible)
          {  _Tb_Tab.Enabled = false; _Tb_Detalle.Enabled = false; }
          else
          {  _Tb_Tab.Enabled = true; _Tb_Detalle.Enabled = true; }
        }

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_G_MyUtilidad._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                _Pnl_Clave.Visible = false;
                Cursor = Cursors.WaitCursor;
                _Mtd_Guardar();
                Cursor = Cursors.Default;
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
            ((Frm_Padre)Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {  _Tb_Tab.Enabled = false; _Tb_Detalle.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            {  _Tb_Tab.Enabled = true; _Tb_Detalle.Enabled = true; }
        }

        private void _Bt_Atendido_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_AtenDirecto _Frm = new Frm_AtenDirecto(_Txt_Cod.Text);
            Cursor = Cursors.Default;
            _Frm.ShowDialog(this);
        }

        private void _Btn_SubClasificacion_Click(object sender, EventArgs e)
        {
            Frm_SubClasificacionColgate _Frm_Form = new Frm_SubClasificacionColgate(_Txt_Cod.Text, _Cmb_Establecimiento.SelectedValue.ToString(), _Cmb_Establecimiento.Text, _Txt_NombreComercial.Text);
            _Frm_Form.StartPosition = FormStartPosition.CenterScreen;
            _Frm_Form.ShowDialog();
        }
    }
}