using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace T3
{
    public partial class Frm_Clientes_VC : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        bool _Bol_Ventas = false; //Variable que indicará si se esta trabajando el fomulario en el perfil de ventas o en el perfil de cobro
        /// <summary>
        /// Constructor para el perfil de ventas.
        /// </summary>
        public Frm_Clientes_VC()
        {
            InitializeComponent();
            _Mtd_Ini();
            _Mtd_Preparar_Controles();
            _Mtd_Actualizar(); _Bol_Cliente = true; _Lbl_Codigo.Text = "Cliente:"; _Lbl_Codigo_Arriba.Text = "Cliente:";
            _Bol_Ventas = true;
        }
        /// <summary>
        /// Contructor llamado para visualizar un cliente específico seleccionado desde el formulario llamador.
        /// </summary>
        /// <param name="_P_Str_Cliente">Cliente</param>
        /// <param name="_P_Str_Rif">Rif</param>
        public Frm_Clientes_VC(string _P_Str_Cliente,string _P_Str_Rif)
        {
            InitializeComponent();
            _Mtd_Ini();
            _Mtd_Actualizar(); _Bol_Cliente = true; _Lbl_Codigo.Text = "Cliente:"; _Lbl_Codigo_Arriba.Text = "Cliente:";
            _Mtd_Preparar_Controles();
            _Mtd_Cargar_Cliente(_P_Str_Cliente, _P_Str_Rif);
            _Mtd_Cargar_Calendario(_P_Str_Cliente, _P_Str_Rif);
            _Mtd_Cargar_Contactos(_P_Str_Cliente, _P_Str_Rif);
            //_Mtd_Cargar_Encuesta(_P_Str_Cliente, _Pnl_Encuesta);
            _Mtd_Cargar_Direccion(_P_Str_Cliente, _P_Str_Rif);
            _Mtd_Cargar_Promedio_Referencia(_P_Str_Cliente);
            _Mtd_Cargar_Promedio_Compras(_P_Str_Cliente, _P_Str_Rif);
            _Mtd_Cargar_Datos_Generales(_P_Str_Cliente, _P_Str_Rif);
            _Mtd_Cargar_Clientes_Concurrentes(_P_Str_Cliente, _P_Str_Rif);
            _Mtd_Cargar_Fecha_Registro(_P_Str_Cliente, _P_Str_Rif);
            _Mtd_Cargar_Inf_Cobranza(_P_Str_Cliente, _P_Str_Rif);
            _Mtd_Evaluar_Riesgo(_P_Str_Cliente, _P_Str_Rif, true);
            _Mtd_Cargar_Activacion(_P_Str_Cliente, _P_Str_Rif);
            _Bol_Rb_Activo = _Rb_Activo.Checked;
            _Bol_Rb_InActivo = _Rb_Inactivo.Checked;
            _Tb_Tab.SelectedIndex = 1;
        }
        private void _Mtd_Manejar_Tab(TabControl _P_Tb_Tab,int _P_Int_Tab)
        {
            _P_Tb_Tab.SelectedIndexChanged += new EventHandler(_P_Tb_Tab_SelectedIndexChanged);
        }

        void _P_Tb_Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((TabControl)sender).SelectedIndex == 3)
            {
                //tabPage3.Hide();
            }
        }
        bool _Bol_Cliente = new bool();//Variable que indicará si se esta trabajando con un cliente o con un prospecto
        public Frm_Clientes_VC(bool _P_Bol_Cliente)
        {
            InitializeComponent();
            _Mtd_Ini();
            _Mtd_Preparar_Controles();
            if (_P_Bol_Cliente)
            { _Mtd_Actualizar(); _Bol_Cliente = true; _Lbl_Codigo.Text = "Cliente:"; _Lbl_Codigo_Arriba.Text = "Cliente:"; }
            else
            { _Mtd_Actualizar_Prospecto(); _Bol_Cliente = false; _Lbl_Codigo.Text = "Prospecto:"; _Lbl_Codigo_Arriba.Text = "Prospecto:"; _Rb_PorActivar.Checked = true; this.Text = "Evaluación de cliente prospecto"; }
        }
        /// <summary>
        /// Devuelve un valor que indica si el parametro es un valor numérico.
        /// </summary>
        /// <param name="Expression">Valor al que se le aplicara la evaluación</param>
        /// <returns></returns>
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        /// <summary>
        /// Actualiza los registros de la consula. Muestra solo los clientes.
        /// </summary>
        private void _Mtd_Actualizar()
        {
            string _Str_FindSql = "Select top ?sel ccliente AS Código, RTRIM(ccliente_nombcomer) AS Cliente, c_estatus_cob_descrip AS Estatus, c_rif, c_clientesigesod AS [Cod.Sigeco] FROM VST_CLIENTE WHERE NOT ccliente IN (select top ?omi ccliente from VST_CLIENTE WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "')) and cdelete=0";
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Cliente");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ccliente";
            _Str_Campos[1] = "ccliente_nombcomer";
//            string _Str_Cadena = "SELECT ccliente AS Código, RTRIM(ccliente_nombcomer) AS Cliente, c_estatus_cob_descrip AS Estatus, c_rif, c_clientesigesod AS [Cod.Sigeco] " +
//"FROM VST_CLIENTE " +
//"WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "')";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_Campos, "Clientes", _Tsm_Menu, _Dg_Grid, "VST_CLIENTE", "WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND cdelete=0", 100, "ORDER BY ccliente");
            //_Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Clientes", _Tsm_Menu, _Dg_Grid, "VST_CLIENTE", "WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "')",100);
            //DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //_Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________            
        }
        /// <summary>
        /// Actualiza los registros de la consula. Muestra solo los prospectos.
        /// </summary>
        private void _Mtd_Actualizar_Prospecto()
        {
            string _Str_FindSql = "Select top ?sel cclientep AS Prospecto, c_rif as Rif, RTRIM(ccliente_nombcomer) AS Descripción, c_rif, c_clientsigesod AS [Cod.Sigeco] FROM VST_PROSPECTO WHERE NOT cclientep IN (select top ?omi cclientep from VST_PROSPECTO WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "')) and cdelete=0";
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Prospecto");
            _Tsm_Menu[1] = new ToolStripMenuItem("Rif");
            _Tsm_Menu[2] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "cclientep";
            _Str_Campos[1] = "c_rif";
            _Str_Campos[2] = "ccliente_nombcomer";
            //string _Str_Cadena = "Select cclientep as Prospecto,c_rif as Rif,c_nomb_comer as Descripción,c_rif,TPROSPECTO.c_clientsigesod AS [Cod.Sigeco] from TPROSPECTO  where c_solicitud='1' and cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_Campos, "Prospectos", _Tsm_Menu, _Dg_Grid, "VST_PROSPECTO", "WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND cdelete=0", 100, "ORDER BY cclientep");
            //DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //_Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns[3].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________            
        }
        private void Frm_Clientes_VC_Load(object sender, EventArgs e)
        {
            _Bt_Guardar.Enabled = false;
            _Bt_Editar.Enabled = false;
            _Bt_GuardarCob.Enabled = false;
            _Bt_EditarCob.Enabled = false;
            _Bt_Guardar_Riesgo.Enabled = false;
            _Bt_Editar_Riesgo.EnabledChanged -= new EventHandler(_Bt_Editar_Riesgo_EnabledChanged);
            _Bt_Editar_Riesgo.Enabled = false;
            _Bt_Editar_Riesgo.EnabledChanged += new EventHandler(_Bt_Editar_Riesgo_EnabledChanged);
        }
        /// <summary>
        /// Prepara los controles para la utilización de los mismos.
        /// </summary>
        private void _Mtd_Preparar_Controles()
        {
            //-------------Posicionar y ajustar Paneles
            _Pnl_Contactos.Location = new Point(129, 170);
            _Pnl_Contactos.Size = new Size(349, 218);
            _Pnl_Direccion.Location = new Point(129, 170);
            _Pnl_Direccion.Size = new Size(349, 255);
            _Pnl_Calendarios.Location = new Point(129, 170);
            _Pnl_Calendarios.Size = new Size(349, 182);
            _Pnl_Referencia.Location = new Point(170, 170);
            _Pnl_Referencia.Size = new Size(282, 233);
            _Pnl_Clave.Location = new Point(205, 238);
            //_Pnl_Clave.Size = new Size(195, 111);
            //-------------Posicionar y ajustar Paneles
            _Mtd_Cargar_Canal();
            _Mtd_Cargar_Limite();
            _Mtd_Cargar_Estado();
            _Mtd_Cargar_Referencia();
            _Mtd_Cargar_Dias();
            _Mtd_Cargar_TipoPgo();
            _Mtd_Cargar_Compra();
            _Mtd_Cargar_Tipo_Empresa();
            _Mtd_Cargar_Bancos();
            _Mtd_Cargar_Forma_Pago();
            _Mtd_Cargar_Contribuyente();
            _Mtd_Cargar_Promedio_Compra();
            _Mtd_Enabled_Controles(_Pnl_Direccion, false);
            _Dtp_Antiguedad.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().AddDays(1);
            _Dtp_Fecha_Registro.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().AddDays(1);
            _Dtp_Fecha.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dtp_Fecha_Inicio.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dtp_Fecha_Registro.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Mtd_Desactivar_CheckdePanels(_Pnl_Calendarios);
            //_Mtd_Desactivar_CheckdePanels(_Grb_Documentos);
            _Mtd_Desactivar_Checks(_Chbox_Cheques1);
            _Mtd_Desactivar_Checks(_Chbox_Cheques2);
            _Mtd_Desactivar_Checks(_Chbox_Mas_Promedio);
            _Mtd_Color_Estandar(_Tb_Tab);
        }
        /// <summary>
        /// Carga elcombo de Zona según el cliente seleccionado.
        /// </summary>
        /// <param name="_Str_Codigo">Cliente</param>
        private void _Mtd_Cargar_Zona(string _Str_Codigo)
        {
            string _Str_Cadena = "SELECT TZONACLIENTE.c_zona, (TZONACLIENTE.c_zona + ':' + rtrim(TZONAVENTA.cname)) as  cname " +
"FROM TZONACLIENTE INNER JOIN " +
"TZONAVENTA ON TZONACLIENTE.c_zona = TZONAVENTA.c_zona AND TZONACLIENTE.ccompany = TZONAVENTA.ccompany AND " +
"TZONACLIENTE.cdelete = TZONAVENTA.cdelete " +
"WHERE (TZONACLIENTE.ccliente = '" + _Str_Codigo + "') AND (TZONACLIENTE.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TZONAVENTA.cdelete = 0)";
            _Lst_Zona.DataSource = null;
            DataSet _Ds;
            //--------------------------------------
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Lst_Zona.DataSource = _Ds.Tables[0];
            _Lst_Zona.DisplayMember = "cname";
            _Lst_Zona.ValueMember = "c_zona";
        }
        /// <summary>
        /// Carga el combo de Límite de Crédito
        /// </summary>
        private void _Mtd_Cargar_Limite()
        {
            string _Str_Cadena = "Select ccodlimite,cdescripcion from TLIMITCREDITO where cdelete='0'";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Limite_Credito, _Str_Cadena);
        }
        /// <summary>
        /// Carga el combo de Tipo de empresa.
        /// </summary>
        private void _Mtd_Cargar_Tipo_Empresa()
        {
            string _Str_Cadena = "Select c_tipemp,cname from TTEMPRESA WHERE cdelete=0 ORDER BY cname ASC";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Tipo_Empresa, _Str_Cadena);
        }
        /// <summary>
        /// Carga el combo de compra a la linea
        /// </summary>
        private void _Mtd_Cargar_Compra()
        {
            _myUtilidad._Mtd_CargarCombo(_Cmb_Compra, "Select clinea,cdescripcion from TLINEAVTAM");
        }
        bool _Bol_Rb_Activo = false;
        bool _Bol_Rb_InActivo = false;
        string _Str_Limine = "";
        /// <summary>
        /// Inicializa los controles del formulario.
        /// </summary>
        private void _Mtd_Ini()
        {
            _Bt_Aprobar.Enabled = false; 
            _Bt_Rechazar.Enabled = false;
            _Bt_Editar_Riesgo.Enabled = true;
            _Bt_Editar.Enabled = true;
            _Bt_EditarCob.Enabled = true;
            _Bt_Guardar.Enabled = false;
            _Bt_GuardarCob.Enabled = false;
            _Bt_Guardar_Riesgo.Enabled = false;
            _Bt_Aprobar.Enabled = false;
            _Bt_Rechazar.Enabled = false;
            _Cmb_Establecimient.Enabled = false;
            _Cmb_Canal.Enabled = false;
            _Cmb_Compra.Enabled = false;
            _Cmb_Promedio_Compra.Enabled = false;
            _Grb_Compras.Enabled = false;
            _Grb_General.Enabled = false;
            _Grb_Referencias.Enabled = false;
            _Chbox_Atendido.Enabled = false;
            _Txt_Atendido.Enabled = false;
            _Chbox_Atendido.Checked = false;
            _Grb_Activacion.Enabled = false;
            _Grb_Banco.Enabled = false;
            _Grb_Documentos.Enabled = false;
            _Chbox_Back.Checked = false;
            _Chbox_Back.Enabled = false;
            _Chbox_Cheques2.Checked = false;
            _Chbox_Cheques1.Checked = false;
            _Chbox_Mas_Promedio.Checked = false;
            _Chbox_Poliza.Checked = false;
            _Chbox_Local.Checked = false;
            _Chbox_Deposito.Checked = false;
            _Chbox_Sucursales.Checked = false;
            _Chbox_Balance.Checked = false;
            _Chbox_Estado.Checked = false;
            _Chbox_Registro.Checked = false;
            _Chbox_Rif.Checked = false;
            _Chbox_Nit.Checked = false;
            _Chbox_CI.Checked = false;
            _Chbox_Otros.Checked = false;
            _Cmb_Contribuyente.Enabled = false;
            _Dtp_Fecha_Inicio.Enabled = false;
            _Rb_Activo.Checked = false;
            _Rb_PorActivar.Checked = false;
            _Rb_Inactivo.Checked = false;
            _Bt_Calendario.Enabled = false;
            _Bt_Informacion.Enabled = false;
            _Bt_Encuesta.Enabled = false;
            if (_Cmb_Canal.DataSource != null)
            {
                _Cmb_Canal.SelectedIndex = 0;
            }
            else
            {
                _Cmb_Canal.SelectedIndex = -1;
            }
            
            _Cmb_Clasificacion.SelectedIndex = 0;
            _Cmb_Cardinal.SelectedIndex = 0;
            _Pgb_Barra.Value = 0;
            _Lbl_Riesgo.Text = "Riesgo";
            _Cmb_Visita.SelectedIndex = 0;
            if (_Cmb_Compra.DataSource != null)
            {
                _Cmb_Compra.SelectedIndex = 0;
            }
            else
            {
                _Cmb_Compra.SelectedIndex = -1;
            }
            if (_Cmb_Limite_Credito.DataSource != null)
            {
                _Cmb_Limite_Credito.SelectedIndex = 0;
            }
            else
            {
                _Cmb_Limite_Credito.SelectedIndex = -1;
            }
            if (_Cmb_Tipo_Empresa.DataSource != null)
            {
                _Cmb_Tipo_Empresa.SelectedIndex = 0;
            }
            else
            {
                _Cmb_Tipo_Empresa.SelectedIndex = -1;
            }
            if (_Cmb_Estado.DataSource != null)
            {
                _Cmb_Estado.SelectedIndex = 0;
            }
            else
            {
                _Cmb_Estado.SelectedIndex = -1;
            }
            if (_Cmb_Municipio.DataSource != null)
            {
                _Cmb_Municipio.SelectedIndex = 0;
            }
            else
            {
                _Cmb_Municipio.SelectedIndex = -1;
            }
            if (_Cmb_Parroquia.DataSource != null)
            {
                _Cmb_Parroquia.SelectedIndex = 0;
            }
            else
            {
                _Cmb_Parroquia.SelectedIndex = -1;
            }
            if (_Cmb_Banco1.DataSource != null)
            {
                _Cmb_Banco1.SelectedIndex = 0;
            }
            else
            {
                _Cmb_Banco1.SelectedIndex = -1;
            }
            if (_Cmb_Banco2.DataSource != null)
            {
                _Cmb_Banco2.SelectedIndex = 0;
            }
            else
            {
                _Cmb_Banco2.SelectedIndex = -1;
            }
            if (_Cmb_Banco3.DataSource != null)
            {
                _Cmb_Banco3.SelectedIndex = 0;
            }
            else
            {
                _Cmb_Banco3.SelectedIndex = -1;
            }
            if (_Cmb_Fpago.DataSource != null)
            {
                _Cmb_Fpago.SelectedIndex = 0;
            }
            else
            {
                _Cmb_Fpago.SelectedIndex = -1;
            }
            if (_Cmb_Contribuyente.DataSource != null)
            {
                _Cmb_Contribuyente.SelectedIndex = 0;
            }
            else
            {
                _Cmb_Contribuyente.SelectedIndex = -1;
            }
            if (_Cmb_Promedio_Compra.DataSource != null)
            {
                _Cmb_Promedio_Compra.SelectedIndex = 0;
            }
            else
            {
                _Cmb_Promedio_Compra.SelectedIndex = -1;
            }
            if (_Cmb_Ciudad.DataSource != null)
            {
                _Cmb_Ciudad.SelectedIndex = 0;
            }
            else
            {
                _Cmb_Ciudad.SelectedIndex = -1;
            }
            if (_Cmb_Establecimient.DataSource != null)
            {
                _Cmb_Establecimient.SelectedIndex = 0;
            }
            else
            {
                _Cmb_Establecimient.SelectedIndex = -1;
            }
            _Txt_Capital_Pagado.Text = "";
            _Txt_Banco1.Text = "";
            _Txt_Banco2.Text = "";
            _Str_Limine = "";
            _Txt_Banco3.Text = "";
            _Txt_Capital_Registrado.Text = "";
            _Txt_AccionistaN_Datos.Text = "";
            _Txt_Representante_Datos.Text = "";
            _Txt_Nota.Text = "";
            _Txt_Monto.Text = "";
            _Txt_Notas_Cobranza.Text = "";
            _Dtp_Fecha.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dtp_Fecha_Inicio.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dtp_Fecha_Registro.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Lst_Zona.DataSource = null;
            _Txt_Saldopor_Vencer.Text = "";
            _Txt_Saldoala_Fecha.Text = "";
            _Txt_Referencia_Promedio.Text = "";
            _Txt_Cheques_Promedio.Text = "";
            _Txt_Antiguedad_Pomedio.Text = "";
            _Txt_ChequesDev_Cuantos.Text = "";
            _Txt_Chequesala_Fecha.Text = "";
            _Txt_Accionista.Text = "";
            _Txt_Atendido.Text = "";
            _Txt_Casa.Text = "";
            _Txt_Cliente.Text = "";
            _Txt_Cliente_Arriba.Text = "";
            _Txt_Denominacion.Text = "";
            _Txt_Des_Cliente_Arriba.Text="";
            _Txt_Direcc_Fiscal.Text = "";
            _Txt_Email.Text = "";
            _Txt_Fax.Text = "";
            _Txt_Nombre_Empresa.Text = "";
            _Txt_Rif.Text = "";
            _Txt_Rif_Cliente_Arriba.Text = "";
            _Txt_Telefono.Text = "";
            _Txt_Url.Text = "";
            _Txt_Contacto1.Text = "";
            _Txt_Contacto2.Text = "";
            _Txt_Contacto3.Text = "";
            _Txt_Sector.Text = "";
            _Txt_Carretera.Text = "";
            _Txt_Calle.Text = "";
            _Txt_Transversal.Text = "";
            _Txt_Piso.Text = "";
            _Txt_Local.Text = "";
            _Txt_Urbanizacion.Text = "";
            _Txt_Avenida.Text = "";
            _Txt_Carrera.Text = "";
            _Txt_Esquina.Text = "";
            _Txt_Edificio.Text = "";
            _Txt_Referencia.Text = "";
            _Txt_Referencia1.Text = "";
            _Txt_Referencia2.Text = "";
            _Txt_Referencia3.Text = "";
            _Int_AprobaroRechazar = 0;
            _Mtd_Ini_Checks(_Pnl_Calendarios);
            //_Mtd_Ini_Checks(_Pnl_Encuesta);

        }
        private void _Mtd_HabilitarRiesgo(bool _Pr_Bol_Val)
        {
            for (int _I = 0; _I < _Tb_Tab.TabPages.Count; _I++)
            {
                if (_I == 3)
                {
                    foreach (Control _MyCtrl in _Tb_Tab.TabPages[_I].Controls)
                    {
                        if (_MyCtrl.Controls.Count > 0)
                        {
 
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Desactiva los CheckBox del formulario
        /// </summary>
        /// <param name="_P_Ctrl_Control">Control que contiene los CheckBox</param>
        private void _Mtd_Desactivar_CheckdePanels(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Desactivar_CheckdePanels(_Ctrl);
                }
                if (_Ctrl.GetType() == typeof(CheckBox))
                {
                    if (Convert.ToInt32(((CheckBox)_Ctrl).Tag) < 72)
                    {
                       _Mtd_Desactivar_Checks(((CheckBox)_Ctrl));
                    }
                }
            }
        }
        /// <summary>
        /// Inicializa los CheckBox del formulario
        /// </summary>
        /// <param name="_P_Ctrl_Control">Control que contiene los CheckBox</param>
        private void _Mtd_Ini_Checks(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Ini_Checks(_Ctrl);
                }
                if (_Ctrl.GetType() == typeof(CheckBox))
                {
                    if (Convert.ToInt32(((CheckBox)_Ctrl).Tag) < 72)
                    {
                        ((CheckBox)_Ctrl).Checked = false;
                    }
                }
            }
        }
        /// <summary>
        /// Habilita o Deshabilita los controles del formulario.
        /// </summary>
        /// <param name="_P_Ctrl_Control">Control que contiene los controles</param>
        /// <param name="_P_Bol_Boleano">Coloque true para habilitar, de lo contrario coloque false</param>
        private void _Mtd_Enabled_Controles(Control _P_Ctrl_Control,bool _P_Bol_Boleano)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Enabled_Controles(_Ctrl,_P_Bol_Boleano);
                }
                if (_Ctrl.GetType() != typeof(System.Windows.Forms.Button))
                {
                    _Ctrl.Enabled = _P_Bol_Boleano;
                }
            }
        }
        /// <summary>
        /// Establece el efecto de color estandar para controles de la aplicación
        /// </summary>
        /// <param name="_P_Ctrl_Control">Control al que s le aplicara el efecto</param>
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
        /// <summary>
        /// Mustra los registros en los controles según el prospecto seleccionado
        /// </summary>
        /// <param name="_P_Str_Codigo">Prospecto</param>
        /// <param name="_P_Str_Rif">Rif</param>
        private void _Mtd_Cargar_Cliente_Prospesto(string _P_Str_Codigo, string _P_Str_Rif)
        {
            string _Str_Cadena = "Select TPROSPECTO.cclientep,TPROSPECTO.c_nomb_comer,TPROSPECTO.c_razsocial_1,TPROSPECTO.c_razsocial_2,TPROSPECTO.c_direcc_fiscal,TPROSPECTO.c_telefono,TPROSPECTO.c_fax,TPROSPECTO.c_email,TPROSPECTO.c_www,TPROSPECTO.c_clasifica,TPROSPECTO.c_casa_matriz,TPROSPECTO.c_atendidodirecto,TPROSPECTO.c_nombredirecto,TTESTABLECIM.ccanal AS c_canal,TPROSPECTO.c_estable,TPROSPECTO.cbackorder,TPROSPECTO.c_tip_contribuy from TPROSPECTO INNER JOIN TTESTABLECIM ON TPROSPECTO.c_estable=TTESTABLECIM.ctestablecim where TPROSPECTO.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TPROSPECTO.cclientep='" + _P_Str_Codigo + "' and TPROSPECTO.c_rif='" + _P_Str_Rif + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                _Txt_Cliente_Arriba.Text = _P_Str_Codigo.ToUpper().Trim().Trim();
                _Txt_Des_Cliente_Arriba.Text = _Row["c_nomb_comer"].ToString().ToUpper().Trim();
                _Txt_Rif_Cliente_Arriba.Text = _P_Str_Rif.ToUpper().Trim();
                _Txt_Cliente.Text = _P_Str_Codigo.ToUpper().Trim();
                _Txt_Rif.Text = _P_Str_Rif.ToUpper().Trim();
                _Txt_Denominacion.Text = _Row["c_nomb_comer"].ToString().ToUpper().Trim();
                _Txt_Telefono.Text = _Row["c_telefono"].ToString().ToUpper().Trim();
                _Txt_Fax.Text = _Row["c_fax"].ToString().ToUpper().Trim();
                _Txt_Url.Text = _Row["c_www"].ToString().ToUpper().Trim();
                _Txt_Email.Text = _Row["c_email"].ToString().ToUpper().Trim();
                _Txt_Nombre_Empresa.Text = _Row["c_razsocial_1"].ToString().ToUpper().Trim();
                _Txt_Accionista.Text = _Row["c_razsocial_2"].ToString().ToUpper().Trim();
                _Txt_Direcc_Fiscal.Text = _Row["c_direcc_fiscal"].ToString().ToUpper().Trim();
                _Cmb_Canal.SelectedValue = _Row["c_canal"].ToString().ToUpper().Trim();
                if (_Cmb_Establecimient.DataSource != null)
                { _Cmb_Establecimient.SelectedValue = _Row["c_estable"].ToString(); }
                if (_Row["c_atendidodirecto"].ToString().Trim().Length > 0)
                {_Chbox_Atendido.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["c_atendidodirecto"].ToString()));}
                _Txt_Atendido.Text = _Row["c_nombredirecto"].ToString();
                if (_Row["cbackorder"].ToString().Trim().Length > 0)
                {_Chbox_Back.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["cbackorder"].ToString()));}
                if (_Row["c_clasifica"].ToString().Trim().ToUpper().Trim() == "I")
                { _Cmb_Clasificacion.SelectedIndex = 1; }
                else if (_Row["c_clasifica"].ToString().Trim().ToUpper().Trim() == "C")
                { _Cmb_Clasificacion.SelectedIndex = 2; }
                else if (_Row["c_clasifica"].ToString().Trim().ToUpper().Trim() == "S")
                { _Cmb_Clasificacion.SelectedIndex = 3; }
                else
                { _Cmb_Clasificacion.SelectedIndex = 0; }
                if (_Cmb_Contribuyente.DataSource != null)
                { _Cmb_Contribuyente.SelectedValue = _Row["c_tip_contribuy"].ToString(); }
                if (_Row["c_casa_matriz"] != null)
                {
                    if (_Row["c_casa_matriz"].ToString().Trim().Length > 0)
                    {
                        _Str_Cadena = "Select ccliente,c_nomb_comer from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _Row["c_casa_matriz"].ToString() + "'";
                        DataSet _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds2.Tables[0].Rows.Count > 0)
                        { _Txt_Casa.Text = _Ds2.Tables[0].Rows[0][0].ToString().ToUpper().Trim() + "-" + _Ds2.Tables[0].Rows[0][1].ToString().ToUpper().Trim(); }
                    }
                }
            }
        }
        /// <summary>
        /// Mustra los registros en los controles según el cliente seleccionado
        /// </summary>
        /// <param name="_P_Str_Codigo">cliente</param>
        /// <param name="_P_Str_Rif">Rif</param>
        private void _Mtd_Cargar_Cliente(string _P_Str_Codigo,string _P_Str_Rif)
        {
            string _Str_Cadena = "Select TCLIENTE.ccliente,TCLIENTE.c_nomb_comer,TCLIENTE.c_razsocial_1,TCLIENTE.c_razsocial_2,TCLIENTE.c_direcc_fiscal,TCLIENTE.c_direcc_despa,TCLIENTE.c_telefono,TCLIENTE.c_fax,TCLIENTE.c_email,TCLIENTE.c_www,CONVERT(varchar,TCLIENTE.c_fech_inicio, 3) AS c_fech_inicio,TCLIENTE.c_clasifica,TCLIENTE.c_casa_matriz,TCLIENTE.c_atendidodirecto,TCLIENTE.c_nombredirecto,TTESTABLECIM.CCANAL AS c_canal,TCLIENTE.c_estable,TCLIENTE.cbackorder,TCLIENTE.c_tip_contribuy from TCLIENTE INNER JOIN TTESTABLECIM ON TCLIENTE.c_estable=TTESTABLECIM.ctestablecim where TCLIENTE.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TCLIENTE.ccliente='" + _P_Str_Codigo + "' and TCLIENTE.c_rif='" + _P_Str_Rif + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row=_Ds.Tables[0].Rows[0];
                _Txt_Cliente_Arriba.Text = _P_Str_Codigo.ToUpper().Trim();
                _Txt_Des_Cliente_Arriba.Text = _Row["c_nomb_comer"].ToString().ToUpper().Trim();
                _Txt_Rif_Cliente_Arriba.Text = _P_Str_Rif.ToUpper().Trim();
                _Txt_Cliente.Text = _P_Str_Codigo.ToUpper().Trim();
                _Txt_Rif.Text = _P_Str_Rif.ToUpper().Trim();
                _Txt_Denominacion.Text = _Row["c_nomb_comer"].ToString().ToUpper().Trim();
                if (Convert.ToString(_Row["c_fech_inicio"]).Length>0)
                { _Dtp_Fecha_Inicio.Value = Convert.ToDateTime(_Row["c_fech_inicio"]); }
                _Txt_Telefono.Text = _Row["c_telefono"].ToString().ToUpper().Trim();
                _Txt_Fax.Text = _Row["c_fax"].ToString().ToUpper().Trim();
                _Txt_Url.Text = _Row["c_www"].ToString().ToUpper().Trim();
                _Txt_Email.Text = _Row["c_email"].ToString().ToUpper().Trim();
                _Txt_Nombre_Empresa.Text = _Row["c_razsocial_1"].ToString().ToUpper().Trim();
                _Txt_Accionista.Text = _Row["c_razsocial_2"].ToString().ToUpper().Trim();
                _Txt_Direcc_Fiscal.Text = _Row["c_direcc_fiscal"].ToString().ToUpper().Trim();
                _Cmb_Canal.SelectedValue = _Row["c_canal"].ToString().ToUpper().Trim();
                if (_Cmb_Establecimient.DataSource != null)
                { _Cmb_Establecimient.SelectedValue = _Row["c_estable"].ToString().Trim(); }
                if (_Row["c_atendidodirecto"].ToString().Trim().Length > 0)
                {_Chbox_Atendido.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["c_atendidodirecto"].ToString()));}
                _Txt_Atendido.Text = _Row["c_nombredirecto"].ToString();
                if (_Row["cbackorder"].ToString().Trim().Length > 0)
                { _Chbox_Back.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["cbackorder"].ToString())); }
                if (_Row["c_clasifica"].ToString().Trim().ToUpper().Trim() == "I")
                { _Cmb_Clasificacion.SelectedIndex = 1; }
                else if (_Row["c_clasifica"].ToString().Trim().ToUpper().Trim() == "C")
                { _Cmb_Clasificacion.SelectedIndex = 2; }
                else if (_Row["c_clasifica"].ToString().Trim().ToUpper().Trim() == "S")
                { _Cmb_Clasificacion.SelectedIndex = 3; }
                else
                { _Cmb_Clasificacion.SelectedIndex = 0; }
                if (_Cmb_Contribuyente.DataSource != null)
                { _Cmb_Contribuyente.SelectedValue = _Row["c_tip_contribuy"].ToString(); }
                if (_Row["c_casa_matriz"]!=null)
                {
                    if (_Row["c_casa_matriz"].ToString().Trim().Length > 0)
                    {
                        _Str_Cadena = "Select ccliente,c_nomb_comer from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _Row["c_casa_matriz"].ToString() + "'";
                        DataSet _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds2.Tables[0].Rows.Count > 0)
                        { _Txt_Casa.Text = _Ds2.Tables[0].Rows[0][0].ToString().ToUpper().Trim() + "-" + _Ds2.Tables[0].Rows[0][1].ToString().ToUpper().Trim(); }
                    }
                }
                _Mtd_Cargar_Zona(_P_Str_Codigo);
            }
        }
        /// <summary>
        /// Muestra los registros en los controles según el cliente seleccionado.
        /// </summary>
        /// <param name="_P_Str_Codigo">Cliente</param>
        /// <param name="_P_Str_Rif">Rif</param>
        private void _Mtd_Cargar_Calendario(string _P_Str_Codigo, string _P_Str_Rif)
        {
            string _Str_Cadena = "Select c_lun_visita,c_mar_visita,c_mie_visita,c_jue_visita,c_vie_visita,c_sab_visita,c_lun_despa,c_mar_despa,c_mie_despa,c_jue_despa,c_vie_despa,c_sab_despa,c_fechainical,c_tipvisita from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row=_Ds.Tables[0].Rows[0];
                if (_Row["c_lun_visita"].ToString().Trim().Length > 1)
                { _Chbox_Vilu.Checked = true; }
                if (_Row["c_mar_visita"].ToString().Trim().Length > 1)
                { _Chbox_ViMa.Checked = true; }
                if (_Row["c_mie_visita"].ToString().Trim().Length > 1)
                { _Chbox_ViMi.Checked = true; }
                if (_Row["c_jue_visita"].ToString().Trim().Length > 1)
                { _Chbox_ViJu.Checked = true; }
                if (_Row["c_vie_visita"].ToString().Trim().Length > 1)
                { _Chbox_ViVi.Checked = true; }
                if (_Row["c_sab_visita"].ToString().Trim().Length > 1)
                { _Chbox_ViSa.Checked = true; }
                //_____________________________________________
                if (_Row["c_lun_despa"].ToString().Trim().Length > 1)
                { _Chbox_DeLu.Checked = true; }
                if (_Row["c_mar_despa"].ToString().Trim().Length > 1)
                { _Chbox_DeMa.Checked = true; }
                if (_Row["c_mie_despa"].ToString().Trim().Length > 1)
                { _Chbox_DeMi.Checked = true; }
                if (_Row["c_jue_despa"].ToString().Trim().Length > 1)
                { _Chbox_DeJu.Checked = true; }
                if (_Row["c_vie_despa"].ToString().Trim().Length > 1)
                { _Chbox_DeVi.Checked = true; }
                if (_Row["c_sab_despa"].ToString().Trim().Length > 1)
                { _Chbox_DeSa.Checked = true; }
                //_____________________________________________
                if (_Row["c_fechainical"] != System.DBNull.Value)
                {
                    _Dtp_Fecha.Value = Convert.ToDateTime(_Row["c_fechainical"].ToString());
                }
                if (_Row["c_tipvisita"].ToString().Trim() == "1")
                { _Cmb_Visita.SelectedIndex = 1; }
                else if (_Row["c_tipvisita"].ToString().Trim() == "2")
                { _Cmb_Visita.SelectedIndex = 2; }
                else if (_Row["c_tipvisita"].ToString().Trim() == "3")
                { _Cmb_Visita.SelectedIndex = 3; }
            }
        }
        /// <summary>
        /// Muestra los registros en los controles según el prospecto seleccionado.
        /// </summary>
        /// <param name="_P_Str_Codigo">Prospecto</param>
        /// <param name="_P_Str_Rif">Rif</param>
        private void _Mtd_Cargar_Calendario_Prospecto(string _P_Str_Codigo, string _P_Str_Rif)
        {
            string _Str_Cadena = "Select c_lun_visita,c_mar_visita,c_mie_visita,c_jue_visita,c_vie_visita,c_sab_visita,c_lun_despa,c_mar_despa,c_mie_despa,c_jue_despa,c_vie_despa,c_sab_despa,c_fechainicial,c_tipvisita from TPROSPECTO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cclientep='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                if (_Row["c_lun_visita"].ToString().Trim().Length > 1)
                { _Chbox_Vilu.Checked = true; }
                if (_Row["c_mar_visita"].ToString().Trim().Length > 1)
                { _Chbox_ViMa.Checked = true; }
                if (_Row["c_mie_visita"].ToString().Trim().Length > 1)
                { _Chbox_ViMi.Checked = true; }
                if (_Row["c_jue_visita"].ToString().Trim().Length > 1)
                { _Chbox_ViJu.Checked = true; }
                if (_Row["c_vie_visita"].ToString().Trim().Length > 1)
                { _Chbox_ViVi.Checked = true; }
                if (_Row["c_sab_visita"].ToString().Trim().Length > 1)
                { _Chbox_ViSa.Checked = true; }
                //_____________________________________________
                if (_Row["c_lun_despa"].ToString().Trim().Length > 1)
                { _Chbox_DeLu.Checked = true; }
                if (_Row["c_mar_despa"].ToString().Trim().Length > 1)
                { _Chbox_DeMa.Checked = true; }
                if (_Row["c_mie_despa"].ToString().Trim().Length > 1)
                { _Chbox_DeMi.Checked = true; }
                if (_Row["c_jue_despa"].ToString().Trim().Length > 1)
                { _Chbox_DeJu.Checked = true; }
                if (_Row["c_vie_despa"].ToString().Trim().Length > 1)
                { _Chbox_DeVi.Checked = true; }
                if (_Row["c_sab_despa"].ToString().Trim().Length > 1)
                { _Chbox_DeSa.Checked = true; }
                //_____________________________________________
                if (_Row["c_fechainicial"] != System.DBNull.Value)
                {
                    _Dtp_Fecha.Value = Convert.ToDateTime(_Row["c_fechainicial"].ToString());
                }
                if (_Row["c_tipvisita"].ToString().Trim() == "1")
                { _Cmb_Visita.SelectedIndex = 0; }
                else if (_Row["c_tipvisita"].ToString().Trim() == "2")
                { _Cmb_Visita.SelectedIndex = 1; }
                else if (_Row["c_tipvisita"].ToString().Trim() == "3")
                { _Cmb_Visita.SelectedIndex = 2; }
            }
        }
        /// <summary>
        /// Muestra los registros en los controles según el cliente seleccionado.
        /// </summary>
        /// <param name="_P_Str_Codigo">Cliente</param>
        /// <param name="_P_Str_Rif">Rif</param>
        private void _Mtd_Cargar_Contactos(string _P_Str_Codigo, string _P_Str_Rif)
        {
            string _Str_Cadena = "Select c_info_cont_1,c_info_cont_2,c_info_cont_3 from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                _Txt_Contacto1.Text = _Row["c_info_cont_1"].ToString().ToUpper().Trim();
                _Txt_Contacto2.Text = _Row["c_info_cont_2"].ToString().ToUpper().Trim();
                _Txt_Contacto3.Text = _Row["c_info_cont_3"].ToString().ToUpper().Trim();
            }
        }
        /// <summary>
        /// Muestra los registros en los controles según el cliente seleccionado.
        /// </summary>
        /// <param name="_P_Str_Codigo">Cliente</param>
        /// <param name="_P_Str_Rif">Rif</param>
        private void _Mtd_Cargar_Activacion(string _P_Str_Codigo, string _P_Str_Rif)
        {
            string _Str_Cadena = "Select c_activo,c_notasinactivo,c_notasreactivacion from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                if (_Row[0].ToString().Trim() == "0")
                { _Rb_Inactivo.Checked = true; }
                else if (_Row[0].ToString().Trim() == "1")
                { _Rb_Activo.Checked = true; }
                if (_Rb_Activo.Checked)
                { _Txt_Nota.Text = _Row["c_notasreactivacion"].ToString().ToUpper().Trim(); }
                else if (_Rb_Inactivo.Checked)
                { _Txt_Nota.Text = _Row["c_notasinactivo"].ToString().ToUpper().Trim(); }
            }
        }
        /// <summary>
        /// Muestra los registros en los controles según el prospecto seleccionado.
        /// </summary>
        /// <param name="_P_Str_Codigo">Prospecto</param>
        /// <param name="_P_Str_Rif">Rif</param>
        private void _Mtd_Cargar_Contactos_Prospecto(string _P_Str_Codigo, string _P_Str_Rif)
        {
            string _Str_Cadena = "Select c_info_cont_1,c_info_cont_2,c_info_cont_3 from TPROSPECTO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cclientep='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                _Txt_Contacto1.Text = _Row["c_info_cont_1"].ToString().ToUpper().Trim();
                _Txt_Contacto2.Text = _Row["c_info_cont_2"].ToString().ToUpper().Trim();
                _Txt_Contacto3.Text = _Row["c_info_cont_3"].ToString().ToUpper().Trim();
            }
        }
        /// <summary>
        /// Carga los combos de banco.
        /// </summary>
        private void _Mtd_Cargar_Bancos()
        {
            string _Str_Sql = "Select rtrim(cbanco) as cbanco,cname from TBANCO where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "'";
            _myUtilidad._Mtd_CargarCombo(_Cmb_Banco1, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cmb_Banco2, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cmb_Banco3, _Str_Sql);
        }
        /// <summary>
        /// Muestra los registros en los controles según el cliente seleccionado.
        /// </summary>
        /// <param name="_P_Str_Codigo">Cliente</param>
        /// <param name="_P_Str_Rif">Rif</param>
        private void _Mtd_Cargar_Inf_Cobranza(string _P_Str_Codigo, string _P_Str_Rif)
        {
            string _Str_Cadena = "Select c_banco_neg,c_banco_per,c_banco_soc,c_cuenta_neg,c_cuenta_per,c_cuenta_soc,c_numacciones,c_razsocial_2,c_capitalsolpag,c_capitalsolreg,c_inf_replegal,cfpago,c_notasreactivacion,c_balancegen,c_estganyper,c_regmercantil,c_riffoto,c_nitfoto,c_cedfoto,c_otrosef from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                _Cmb_Banco1.SelectedValue = _Row["c_banco_neg"].ToString().ToUpper().Trim();
                _Cmb_Banco2.SelectedValue = _Row["c_banco_per"].ToString().ToUpper().Trim();
                _Cmb_Banco3.SelectedValue = _Row["c_banco_soc"].ToString().ToUpper().Trim();
                _Txt_Banco1.Text = _Row["c_cuenta_neg"].ToString().ToUpper().Trim();
                _Txt_Banco2.Text = _Row["c_cuenta_per"].ToString().ToUpper().Trim();
                _Txt_Banco3.Text = _Row["c_cuenta_soc"].ToString().ToUpper().Trim();
                _Txt_AccionistaN_Datos.Text = _Row["c_numacciones"].ToString().ToUpper().Trim();
                _Txt_Representante_Datos.Text = _Row["c_inf_replegal"].ToString().ToUpper().Trim();
                _Cmb_Fpago.SelectedValue = _Row["cfpago"].ToString();
                _Txt_Nota.Text = _Row["c_notasreactivacion"].ToString().ToUpper().Trim();
                if (_Row["c_balancegen"] != System.DBNull.Value)
                { _Chbox_Balance.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["c_balancegen"].ToString())); }
                if (_Row["c_estganyper"] != System.DBNull.Value)
                { _Chbox_Estado.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["c_estganyper"].ToString())); }
                if (_Row["c_regmercantil"] != System.DBNull.Value)
                { _Chbox_Registro.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["c_regmercantil"].ToString())); }
                if (_Row["c_riffoto"] != System.DBNull.Value)
                { _Chbox_Rif.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["c_riffoto"].ToString())); }
                if (_Row["c_nitfoto"] != System.DBNull.Value)
                { _Chbox_Nit.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["c_nitfoto"].ToString())); }
                if (_Row["c_cedfoto"] != System.DBNull.Value)
                { _Chbox_CI.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["c_cedfoto"].ToString())); }
                if (_Row["c_otrosef"] != System.DBNull.Value)
                { _Chbox_Otros.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["c_otrosef"].ToString())); }
            }
        }
        /// <summary>
        /// Muestra los registros en los controles según el prospecto seleccionado.
        /// </summary>
        /// <param name="_P_Str_Codigo">Prospecto</param>
        /// <param name="_P_Str_Rif">Rif</param>
        private void _Mtd_Cargar_Inf_Cobranza_Prospecto(string _P_Str_Codigo, string _P_Str_Rif)
        {
            string _Str_Cadena = "Select c_banco_neg,c_banco_per,c_banco_soc,c_cuenta_neg,c_cuenta_per,c_cuenta_soc,c_numacciones,c_razsocial_2,c_capitalsolpag,c_capitalsolreg,c_inf_replegal,cfpago,c_balancegen,c_estganyper,c_regmercantil,c_riffoto,c_nitfoto,c_cedfoto,c_otrosef from TPROSPECTO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cclientep='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                _Cmb_Banco1.SelectedValue = _Row["c_banco_neg"].ToString().ToUpper().Trim();
                _Cmb_Banco2.SelectedValue = _Row["c_banco_per"].ToString().ToUpper().Trim();
                _Cmb_Banco3.SelectedValue = _Row["c_banco_soc"].ToString().ToUpper().Trim();
                _Txt_Banco1.Text = _Row["c_cuenta_neg"].ToString().ToUpper().Trim();
                _Txt_Banco2.Text = _Row["c_cuenta_per"].ToString().ToUpper().Trim();
                _Txt_Banco3.Text = _Row["c_cuenta_soc"].ToString().ToUpper().Trim();
                _Txt_AccionistaN_Datos.Text = _Row["c_numacciones"].ToString().ToUpper().Trim();
                _Txt_Representante_Datos.Text = _Row["c_inf_replegal"].ToString().ToUpper().Trim();
                _Cmb_Fpago.SelectedValue = _Row["cfpago"].ToString();
                if (_Row["c_balancegen"] != System.DBNull.Value)
                {_Chbox_Balance.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["c_balancegen"].ToString()));}
                if (_Row["c_estganyper"] != System.DBNull.Value)
                { _Chbox_Estado.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["c_estganyper"].ToString())); }
                if (_Row["c_regmercantil"] != System.DBNull.Value)
                { _Chbox_Registro.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["c_regmercantil"].ToString())); }
                if (_Row["c_riffoto"] != System.DBNull.Value)
                { _Chbox_Rif.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["c_riffoto"].ToString())); }
                if (_Row["c_nitfoto"] != System.DBNull.Value)
                { _Chbox_Nit.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["c_nitfoto"].ToString())); }
                if (_Row["c_cedfoto"] != System.DBNull.Value)
                { _Chbox_CI.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["c_cedfoto"].ToString())); }
                if (_Row["c_otrosef"] != System.DBNull.Value)
                { _Chbox_Otros.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["c_otrosef"].ToString())); }
            }
        }
        /// <summary>
        /// Muestra los registros en los controles según el cliente seleccionado.
        /// </summary>
        /// <param name="_P_Str_Codigo">Cliente</param>
        /// <param name="_P_Str_Rif">Rif</param>
        private void _Mtd_Cargar_Referencias(string _P_Str_Codigo, string _P_Str_Rif)
        {
            string _Str_Cadena = "Select c_refcomercial1,c_refcomercial2,c_refcomercial3 from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                _Txt_Referencia1.Text = _Row["c_refcomercial1"].ToString().ToUpper().Trim();
                _Txt_Referencia2.Text = _Row["c_refcomercial2"].ToString().ToUpper().Trim();
                _Txt_Referencia3.Text = _Row["c_refcomercial3"].ToString().ToUpper().Trim();
            }
        }
        /// <summary>
        /// Muestra los registros en los controles según el prospecto seleccionado.
        /// </summary>
        /// <param name="_P_Str_Codigo">Prospecto</param>
        /// <param name="_P_Str_Rif">Rif</param>
        private void _Mtd_Cargar_Referencias_Prospecto(string _P_Str_Codigo, string _P_Str_Rif)
        {
            string _Str_Cadena = "Select c_refcomercial1,c_refcomercial2,c_refcomercial3 from TPROSPECTO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cclientep='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                _Txt_Referencia1.Text = _Row["c_refcomercial1"].ToString().ToUpper().Trim();
                _Txt_Referencia2.Text = _Row["c_refcomercial2"].ToString().ToUpper().Trim();
                _Txt_Referencia3.Text = _Row["c_refcomercial3"].ToString().ToUpper().Trim();
            }
        }
        /// <summary>
        /// Muestra los registros en los controles según el cliente seleccionado.
        /// </summary>
        /// <param name="_P_Str_Codigo">cliente</param>
        /// <param name="_P_Str_Rif">Rif</param>
        private void _Mtd_Cargar_Datos_Generales(string _P_Str_Codigo, string _P_Str_Rif)
        {
            string _Str_Cadena = "Select c_limt_credit,dbo.Fnc_Formatear(c_capitalsolpag) as c_capitalsolpag,dbo.Fnc_Formatear(c_capitalsolreg) as c_capitalsolreg,c_notascob from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                if (_Row["c_limt_credit"] != System.DBNull.Value)
                { _Cmb_Limite_Credito.SelectedValue = _Row["c_limt_credit"].ToString(); }
                _Txt_Capital_Pagado.Text = _Row["c_capitalsolpag"].ToString().ToUpper().Trim();
                _Txt_Capital_Registrado.Text = _Row["c_capitalsolreg"].ToString().ToUpper().Trim();
                _Txt_Notas_Cobranza.Text = _Row["c_notascob"].ToString().ToUpper().Trim();
            }
            _Str_Cadena = "Select ctipoempresa,dbo.Fnc_Formatear(cmontoasegurado) as cmontoasegurado,cpoliza,clocal,cdeposito,csucursales,clinea from TRIESGOS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                _Cmb_Tipo_Empresa.SelectedValue =_Row["ctipoempresa"].ToString();
                _Txt_Monto.Text = _Row["cmontoasegurado"].ToString();
                _Chbox_Poliza.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["cpoliza"].ToString()));
                _Chbox_Local.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["clocal"].ToString()));
                _Chbox_Deposito.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["cdeposito"].ToString()));
                _Chbox_Sucursales.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["csucursales"].ToString()));
                _Cmb_Compra.SelectedValue = _Row["clinea"].ToString();
            }
        }
        /// <summary>
        /// Muestra los registros en los controles según el prospecto seleccionado.
        /// </summary>
        /// <param name="_P_Str_Codigo">Prospecto</param>
        /// <param name="_P_Str_Rif">Rif</param>
        private void _Mtd_Cargar_Datos_Generales_Prospecto(string _P_Str_Codigo, string _P_Str_Rif)
        {
            string _Str_Cadena = "Select c_limt_credit,dbo.Fnc_Formatear(c_capitalsolpag) as c_capitalsolpag,dbo.Fnc_Formatear(c_capitalsolreg) as c_capitalsolreg,c_notascob from TPROSPECTO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cclientep='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                if (_Row["c_limt_credit"] != System.DBNull.Value)
                { _Cmb_Limite_Credito.SelectedValue = _Row["c_limt_credit"].ToString(); }
                if (_Cmb_Limite_Credito.SelectedIndex > 0)
                {
                    _Str_Limine = _Cmb_Limite_Credito.SelectedValue.ToString().Trim();
                }
                else
                {
                    _Str_Limine = "0";
                }
                _Txt_Capital_Pagado.Text = _Row["c_capitalsolpag"].ToString().ToUpper().Trim();
                _Txt_Capital_Registrado.Text = _Row["c_capitalsolreg"].ToString().ToUpper().Trim();
                _Txt_Notas_Cobranza.Text = _Row["c_notascob"].ToString().ToUpper().Trim();
            }
            _Str_Cadena = "Select ctipoempresa,dbo.Fnc_Formatear(cmontoasegurado) as cmontoasegurado,cpoliza,clocal,cdeposito,csucursales,clinea from TRIESGOS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cclientep='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                _Cmb_Tipo_Empresa.SelectedValue = _Row["ctipoempresa"].ToString();
                _Txt_Monto.Text = _Row["cmontoasegurado"].ToString().ToUpper().Trim();
                _Chbox_Poliza.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["cpoliza"].ToString()));
                _Chbox_Local.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["clocal"].ToString()));
                _Chbox_Deposito.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["cdeposito"].ToString()));
                _Chbox_Sucursales.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["csucursales"].ToString()));
                _Cmb_Compra.SelectedValue = _Row["clinea"].ToString();
            }
        }
        /// <summary>
        /// Muestra los registros en los controles según el cliente seleccionado.
        /// </summary>
        /// <param name="_P_Str_Codigo">Cliente</param>
        /// <param name="_P_Str_Rif">Rif</param>
        private void _Mtd_Cargar_Promedio_Compras(string _P_Str_Codigo, string _P_Str_Rif)
        {
            string _Str_Cadena = "Select cpromediocompra from TRIESGOS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                if (_Row[0] != System.DBNull.Value)
                { _Cmb_Promedio_Compra.SelectedValue = _Row[0].ToString(); }
            }
        }
        /// <summary>
        /// Muestra los registros en los controles según el prospecto seleccionado.
        /// </summary>
        /// <param name="_P_Str_Codigo">Prospecto</param>
        /// <param name="_P_Str_Rif">Rif</param>
        private void _Mtd_Cargar_Promedio_Compras_Prospecto(string _P_Str_Codigo, string _P_Str_Rif)
        {
            string _Str_Cadena = "Select cpromediocompra from TRIESGOS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cclientep='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                if (_Row[0] != System.DBNull.Value)
                { _Cmb_Promedio_Compra.SelectedValue = _Row[0].ToString(); }
            }
        }
        /// <summary>
        /// Muestra los registros en los controles según el cliente seleccionado.
        /// </summary>
        /// <param name="_P_Str_Codigo">Cliente</param>
        /// <param name="_P_Str_Rif">Rif</param>
        private void _Mtd_Cargar_Clientes_Concurrentes(string _P_Str_Codigo, string _P_Str_Rif)
        {
            string _Str_Cadena = "Select c_cheq_dev_f,c_cheqdevuel from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                if (_Row["c_cheq_dev_f"].ToString() == "1")
                { _Chbox_Cheques2.Checked = true; }
                _Txt_ChequesDev_Cuantos.Text = _Row["c_cheqdevuel"].ToString().ToUpper().Trim();
            }
            _Str_Cadena = "Select csaldopendi,csaldovencer from TSALDOCLIENTEM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='"+Frm_Padre._Str_Comp+"' and ccliente='" + _P_Str_Codigo + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                if (_Row["csaldopendi"] != System.DBNull.Value)
                {
                    _Txt_Saldoala_Fecha.Text = Convert.ToDouble(_Row["csaldopendi"]).ToString("#,##0.00");
                }
                else
                {
                    _Txt_Saldoala_Fecha.Text = "0,00";
                }
                if (_Row["csaldovencer"] != System.DBNull.Value)
                {
                    _Txt_Saldopor_Vencer.Text = Convert.ToDouble(_Row["csaldovencer"]).ToString("#,##0.00");
                }
                else
                {
                    _Txt_Saldopor_Vencer.Text = "0,00";
                }
            }
            _Str_Cadena = "Select cactivo from TCHEQDEVUELT where ccompany='" + Frm_Padre._Str_Comp + "' and ccliente='" + _P_Str_Codigo + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString() == "1")
                { _Txt_Chequesala_Fecha.Text = "Sí"; }
                else
                { _Txt_Chequesala_Fecha.Text = "No"; }
            }
            else
            { _Txt_Chequesala_Fecha.Text = "No"; }
        }
        /// <summary>
        /// Muestra los registros en los controles según el cliente seleccionado.
        /// </summary>
        /// <param name="_P_Str_Codigo">Cliente</param>
        /// <param name="_P_Str_Rif">Rif</param>
        private void _Mtd_Cargar_Direccion(string _P_Str_Codigo, string _P_Str_Rif)
        {
            string _Str_Cadena = "Select c_estado,c_ciudad,c_municipio,c_parroquia,c_sector,c_carretera,c_calle,c_transversal,c_piso,c_local,c_pcardinal,c_urbanizacion,c_avenida,c_carrera,c_esquina,c_edificio,c_preferencia from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                _Cmb_Estado.SelectedValue = _Row["c_estado"].ToString().Trim();
                if (_Cmb_Ciudad.DataSource != null)
                {_Cmb_Ciudad.SelectedValue = _Row["c_ciudad"].ToString().Trim();}
                if (_Cmb_Municipio.DataSource != null)
                {_Cmb_Municipio.SelectedValue = _Row["c_municipio"].ToString().Trim();}
                if (_Cmb_Parroquia.DataSource != null)
                { _Cmb_Parroquia.SelectedValue = _Row["c_parroquia"].ToString().Trim(); }
                _Txt_Sector.Text = _Row["c_sector"].ToString().ToUpper().Trim();
                _Txt_Carretera.Text = _Row["c_carretera"].ToString().ToUpper().Trim();
                _Txt_Calle.Text = _Row["c_calle"].ToString().ToUpper().Trim();
                _Txt_Transversal.Text = _Row["c_transversal"].ToString().ToUpper().Trim();
                _Txt_Piso.Text = _Row["c_piso"].ToString().ToUpper().Trim();
                _Txt_Local.Text = _Row["c_local"].ToString().ToUpper().Trim();
                if (_Row["c_pcardinal"].ToString().Trim().ToUpper().Trim() == "N")
                { _Cmb_Cardinal.SelectedIndex = 1; }
                else if (_Row["c_pcardinal"].ToString().Trim().ToUpper().Trim() == "S")
                { _Cmb_Cardinal.SelectedIndex = 2; }
                else if (_Row["c_pcardinal"].ToString().Trim().ToUpper().Trim() == "E")
                { _Cmb_Cardinal.SelectedIndex = 3; }
                else if (_Row["c_pcardinal"].ToString().Trim().ToUpper().Trim() == "O")
                { _Cmb_Cardinal.SelectedIndex = 4; }
                else
                {
                    _Cmb_Cardinal.SelectedIndex = 0;
                }
                _Txt_Urbanizacion.Text = _Row["c_urbanizacion"].ToString().ToUpper().Trim();
                _Txt_Avenida.Text = _Row["c_avenida"].ToString().ToUpper().Trim();
                _Txt_Carrera.Text = _Row["c_carrera"].ToString().ToUpper().Trim();
                _Txt_Esquina.Text = _Row["c_esquina"].ToString().ToUpper().Trim();
                _Txt_Edificio.Text = _Row["c_edificio"].ToString().ToUpper().Trim();
                _Txt_Referencia.Text = _Row["c_preferencia"].ToString().ToUpper().Trim();
            }
        }
        /// <summary>
        /// Muestra los registros en los controles según el prospecto seleccionado.
        /// </summary>
        /// <param name="_P_Str_Codigo">Prospecto</param>
        /// <param name="_P_Str_Rif">Rif</param>
        private void _Mtd_Cargar_Direccion_Prospecto(string _P_Str_Codigo, string _P_Str_Rif)
        {
            string _Str_Cadena = "Select c_estado,c_ciudad,c_municipio,c_parroquia,c_sector,c_carretera,c_calle,c_transversal,c_piso,c_local,c_pcardinal,c_urbanizacion,c_avenida,c_carrera,c_esquina,c_edificio,c_preferencia from TPROSPECTO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cclientep='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                _Cmb_Estado.SelectedValue = _Row["c_estado"].ToString().Trim();
                if (_Cmb_Ciudad.DataSource != null)
                { _Cmb_Ciudad.SelectedValue = _Row["c_ciudad"].ToString().Trim(); }
                if (_Cmb_Municipio.DataSource != null)
                { _Cmb_Municipio.SelectedValue = _Row["c_municipio"].ToString().Trim(); }
                if (_Cmb_Parroquia.DataSource != null)
                { _Cmb_Parroquia.SelectedValue = _Row["c_parroquia"].ToString().Trim(); }
                _Txt_Sector.Text = _Row["c_sector"].ToString().ToUpper().Trim();
                _Txt_Carretera.Text = _Row["c_carretera"].ToString().ToUpper().Trim();
                _Txt_Calle.Text = _Row["c_calle"].ToString().ToUpper().Trim();
                _Txt_Transversal.Text = _Row["c_transversal"].ToString().ToUpper().Trim();
                _Txt_Piso.Text = _Row["c_piso"].ToString().ToUpper().Trim();
                _Txt_Local.Text = _Row["c_local"].ToString().ToUpper().Trim();
                if (_Row["c_pcardinal"].ToString().Trim().ToUpper().Trim() == "N")
                { _Cmb_Cardinal.SelectedIndex = 1; }
                else if (_Row["c_pcardinal"].ToString().Trim().ToUpper().Trim() == "S")
                { _Cmb_Cardinal.SelectedIndex = 2; }
                else if (_Row["c_pcardinal"].ToString().Trim().ToUpper().Trim() == "E")
                { _Cmb_Cardinal.SelectedIndex = 3; }
                else if (_Row["c_pcardinal"].ToString().Trim().ToUpper().Trim() == "O")
                { _Cmb_Cardinal.SelectedIndex = 4; }
                else
                {
                    _Cmb_Cardinal.SelectedIndex = 0;
                }
                _Txt_Urbanizacion.Text = _Row["c_urbanizacion"].ToString().ToUpper().Trim();
                _Txt_Avenida.Text = _Row["c_avenida"].ToString().ToUpper().Trim();
                _Txt_Carrera.Text = _Row["c_carrera"].ToString().ToUpper().Trim();
                _Txt_Esquina.Text = _Row["c_esquina"].ToString().ToUpper().Trim();
                _Txt_Edificio.Text = _Row["c_edificio"].ToString().ToUpper().Trim();
                _Txt_Referencia.Text = _Row["c_preferencia"].ToString().ToUpper().Trim();
            }
        }
        /// <summary>
        /// Carga el combo de tipo de canal
        /// </summary>
        private void _Mtd_Cargar_Canal()
        {
            _myUtilidad._Mtd_CargarCombo(_Cmb_Canal, "Select rtrim(ccanal),cname from TTCANAL where cdelete='0' ORDER BY cname ASC");
        }
        /// <summary>
        /// Carga el combo de forma de pago
        /// </summary>
        private void _Mtd_Cargar_Forma_Pago()
        {
            _myUtilidad._Mtd_CargarCombo(_Cmb_Fpago, "Select RTRIM(cfpago),cname from TFPAGO where cdelete='0' ORDER BY cname ASC");
        }
        /// <summary>
        /// Carga el combo de Estado
        /// </summary>
        private void _Mtd_Cargar_Estado()
        {
            _myUtilidad._Mtd_CargarCombo(_Cmb_Estado, "Select RTRIM(cestate),cname from TESTATE where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' ORDER BY cname ASC");
        }
        /// <summary>
        /// Carga el combo de Ciudad según el estado
        /// </summary>
        /// <param name="_P_Str_Estado">Estado</param>
        private void _Mtd_Cargar_Ciudad(string _P_Str_Estado)
        {
            _myUtilidad._Mtd_CargarCombo(_Cmb_Ciudad, "Select RTRIM(ccity),cname from TCITY where cdelete='0' and cestate='" + _P_Str_Estado + "' ORDER BY cname ASC");
        }
        /// <summary>
        /// Carga el combo de Municipio según el estado
        /// </summary>
        /// <param name="_P_Str_Estado">Estado</param>
        private void _Mtd_Cargar_Municipio(string _P_Str_Estado)
        {
            _myUtilidad._Mtd_CargarCombo(_Cmb_Municipio, "Select RTRIM(cmunicipio),cname from TMUNICIPIO where cdelete='0' and cestate='" + _P_Str_Estado + "' ORDER BY cname ASC");
        }
        /// <summary>
        /// Carga el combo de parroquia según el municipio
        /// </summary>
        /// <param name="_P_Str_Municipio">Municipio</param>
        private void _Mtd_Cargar_Parroquia(string _P_Str_Municipio)
        {
            _myUtilidad._Mtd_CargarCombo(_Cmb_Parroquia, "Select RTRIM(cparroquia),cname from TPARROQUIA where cdelete='0' and cmunicipio='" + _P_Str_Municipio + "' ORDER BY cname ASC");
        }
        /// <summary>
        /// Cargar el combode Estableciminto según el tipo de canal
        /// </summary>
        /// <param name="_P_Str_Canal">Tipo de Canal</param>
        private void _Mtd_Cargar_Establecimiento(string _P_Str_Canal)
        {
            _myUtilidad._Mtd_CargarCombo(_Cmb_Establecimient, "Select RTRIM(ctestablecim),rtrim(cname) as cname from TTESTABLECIM where cdelete='0' and ccanal='" + _P_Str_Canal + "' ORDER BY cname ASC");
        }
        /// <summary>
        /// Carga el combo de Promedio de Compra
        /// </summary>
        private void _Mtd_Cargar_Promedio_Compra()
        {
            _myUtilidad._Mtd_CargarCombo(_Cmb_Promedio_Compra, "Select RTRIM(c_idpromediocomp),c_descripcion from TPROMCOMP where cdelete='0'");
        }
        private void _Cmb_Canal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Canal.DataSource != null)
            {
                _Mtd_Cargar_Establecimiento(Convert.ToString(_Cmb_Canal.SelectedValue));
            }
        }

        private void _Bt_Direccion_Click(object sender, EventArgs e)
        {
            if (_Txt_Cliente.Text.Trim().Length > 0)
            {
                _Pnl_Direccion.Visible = true;
            }
            else
            { MessageBox.Show("Es necesario seleccionar un cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Bt_Calendario_Click(object sender, EventArgs e)
        {
            if (_Txt_Cliente.Text.Trim().Length > 0)
            {_Pnl_Calendarios.Visible = true;}
            else
            { MessageBox.Show("Es necesario seleccionar un cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Pnl_Calendarios_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Calendarios.Visible)
            {
                _Tb_Tab.Enabled = false;
                _Txt_Cliente_Arriba.Enabled = false;
                _Txt_Des_Cliente_Arriba.Enabled = false;
                _Txt_Rif_Cliente_Arriba.Enabled = false;
            }
            else
            {
                _Tb_Tab.Enabled = true;
                _Txt_Cliente_Arriba.Enabled = true;
                _Txt_Des_Cliente_Arriba.Enabled = true;
                _Txt_Rif_Cliente_Arriba.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Pnl_Calendarios.Visible = false;
        }

        private void _Bt_Aceptar_Cont_Click(object sender, EventArgs e)
        {
            _Pnl_Contactos.Visible = false;
        }

        private void _Pnl_Contactos_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Contactos.Visible)
            {
                _Tb_Tab.Enabled = false;
                _Txt_Cliente_Arriba.Enabled = false;
                _Txt_Des_Cliente_Arriba.Enabled = false;
                _Txt_Rif_Cliente_Arriba.Enabled = false;
            }
            else
            {
                _Tb_Tab.Enabled = true;
                _Txt_Cliente_Arriba.Enabled = true;
                _Txt_Des_Cliente_Arriba.Enabled = true;
                _Txt_Rif_Cliente_Arriba.Enabled = true;
            }
        }
        private void _Mtd_Desactivar_Checks(CheckBox _P_Chbox_Check)
        {
            _P_Chbox_Check.Click += new EventHandler(_P_Chbox_Check_Click);
        }

        void _P_Chbox_Check_Click(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            { ((CheckBox)sender).Checked = false; }
            else { ((CheckBox)sender).Checked = true; }
        }
        private void _Bt_Informacion_Click(object sender, EventArgs e)
        {
            if (_Txt_Cliente.Text.Trim().Length > 0)
            { _Pnl_Contactos.Visible = true; }
            else
            { MessageBox.Show("Es necesario seleccionar un cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Bt_Encuesta_Click(object sender, EventArgs e)
        {
            if (_Txt_Cliente.Text.Trim().Length > 0)
            {
                Frm_Encuesta _Frm = new Frm_Encuesta(_Txt_Cliente.Text.Trim(), _Bol_Cliente);
                _Frm.ShowDialog();
            }
            else
            {MessageBox.Show("Es necesario seleccionar un cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);}
        }

        private void _Bt_Cerrar_Click(object sender, EventArgs e)
        {
            //_Pnl_Encuesta.Visible = false;
        }

        private void _Bt_Editar_Click(object sender, EventArgs e)
        {
            _Bt_Despacho.Enabled = true;
            _Bt_Direccion.Enabled = true;
            _Bt_Calendario.Enabled = true;
            _Bt_Informacion.Enabled = true;
            _Bt_Encuesta.Enabled = true;
            _Cmb_Establecimient.Enabled = true;
            _Cmb_Canal.Enabled = true;
            _Cmb_Contribuyente.Enabled = true;
            _Chbox_Atendido.Enabled = true;
            _Txt_Atendido.Enabled = true;
            _Dtp_Fecha_Inicio.Enabled = true;
            _Chbox_Back.Enabled = true;
            _Bt_Editar.Enabled = false;
            _Bt_Guardar.Enabled = true;
        }

        private void _Bt_Guardar_Click(object sender, EventArgs e)
        {
            string _Str_Canal = "null", _Str_Estable = "null", _Str_Contribuye = "null";
            Cursor = Cursors.WaitCursor;
            if (_Cmb_Canal.SelectedIndex > 0)
            {
                _Str_Canal = "'" + _Cmb_Canal.SelectedValue.ToString() + "'";
            }
            if (_Cmb_Establecimient.SelectedIndex > 0)
            {
                _Str_Estable = "'" + _Cmb_Establecimient.SelectedValue.ToString() + "'";
            }
            if (_Cmb_Contribuyente.SelectedIndex > 0)
            {
                _Str_Contribuye = "'"+ _Cmb_Contribuyente.SelectedValue.ToString()+"'";
            }
            string _Str_Cadena = "";
            if (_Bol_Cliente)
            { _Str_Cadena = "Update TCLIENTE Set c_tip_contribuy=" + _Str_Contribuye + ",cbackorder='" + Convert.ToInt32(_Chbox_Back.Checked).ToString() + "',c_atendidodirecto='" + Convert.ToInt32(_Chbox_Atendido.Checked).ToString() + "',c_nombredirecto='" + _Txt_Atendido.Text.Trim().ToUpper().Trim() + "',c_estable=" + _Str_Estable + ",c_canal=" + _Str_Canal + ",cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',c_fech_inicio='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Fecha_Inicio.Value) + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'"; }
            else
            { _Str_Cadena = "Update TPROSPECTO Set c_tip_contribuy=" + _Str_Contribuye + ",cbackorder='" + Convert.ToInt32(_Chbox_Back.Checked).ToString() + "',c_atendidodirecto='" + Convert.ToInt32(_Chbox_Atendido.Checked).ToString() + "',c_nombredirecto='" + _Txt_Atendido.Text.Trim().ToUpper().Trim() + "',c_estable=" + _Str_Estable + ",c_canal=" + _Str_Canal + ",cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cclientep='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'"; }
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Bt_Despacho.Enabled = false;
            _Bt_Direccion.Enabled = false;
            _Bt_Calendario.Enabled = false;
            _Bt_Informacion.Enabled = false;
            _Bt_Encuesta.Enabled = false;
            _Cmb_Establecimient.Enabled = false;
            _Cmb_Canal.Enabled = false;
            _Cmb_Contribuyente.Enabled = false;
            _Chbox_Atendido.Enabled = false;
            _Txt_Atendido.Enabled = false;
            _Chbox_Back.Enabled = false;
            _Dtp_Fecha_Inicio.Enabled = false;
            _Bt_Editar.Enabled = true;
            _Bt_Guardar.Enabled = false;
            Cursor = Cursors.Default;
            MessageBox.Show("Los registros fueron actualizados correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void _Bt_Despacho_Click(object sender, EventArgs e)
        {
            if (_Txt_Cliente.Text.Trim().Length > 0)
            {
                ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
                _Tsm_Menu[0] = new ToolStripMenuItem("Dirección");
                string[] _Str_Campos = new string[1];
                _Str_Campos[0] = "c_direcc_descrip";
                string _Str_Cadena = "";
                if (_Bol_Cliente)
                { _Str_Cadena = "Select RTRIM(c_direcc_descrip) as Dirección from TDDESPACHOC where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _Txt_Cliente.Text.Trim() + "'"; }
                else
                { _Str_Cadena = "Select RTRIM(c_direcc_descrip) as Dirección from TDDESPACHOP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _Txt_Cliente.Text.Trim() + "'"; }
                Frm_Busqueda _Frm = new Frm_Busqueda(_Str_Cadena, _Str_Campos, "Direcciones de Despacho", _Tsm_Menu, true);
                _Frm.ShowDialog();
            }
            else
            { MessageBox.Show("Es necesario seleccionar un cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Bt_Aceptar_direc_Click(object sender, EventArgs e)
        {
            string _Str_parroquia = "null", _Str_estado = "null", _Str_ciudad = "null", _Str_municipio="null";
            if (_Cmb_Estado.SelectedIndex > 0)
            {
                _Str_estado = "'" + _Cmb_Estado.SelectedValue.ToString() + "'";
            }
            if (_Cmb_Ciudad.SelectedIndex > 0)
            {
                _Str_ciudad = "'" + _Cmb_Ciudad.SelectedValue.ToString() + "'";
            }
            if (_Cmb_Municipio.SelectedIndex > 0)
            {
                _Str_municipio = "'" + _Cmb_Municipio.SelectedValue.ToString() + "'";
            }
            if (_Cmb_Parroquia.SelectedIndex > 0)
            { _Str_parroquia = "'" + _Cmb_Parroquia.SelectedValue.ToString() + "'"; }
            string _Str_Punto_Cardinal = "";
            if ( _Cmb_Cardinal.SelectedIndex == 1)
            { _Str_Punto_Cardinal="N";}
            else if ( _Cmb_Cardinal.SelectedIndex == 2)
            { _Str_Punto_Cardinal = "S"; }
            else if (_Cmb_Cardinal.SelectedIndex == 3)
            { _Str_Punto_Cardinal = "E"; }
            else if (_Cmb_Cardinal.SelectedIndex == 4)
            { _Str_Punto_Cardinal = "O"; }

            string _Str_Cadena = "";
            if (_Bol_Cliente)
            { _Str_Cadena = "Update TCLIENTE Set cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',c_estado=" + _Str_estado + ",c_ciudad=" + _Str_ciudad + ",c_municipio=" + _Str_municipio + ",c_parroquia=" + _Str_parroquia + ",c_sector='" + _Txt_Sector.Text.Trim().ToUpper().Trim() + "',c_carretera='" + _Txt_Carretera.Text.Trim().ToUpper().Trim() + "',c_calle='" + _Txt_Calle.Text.Trim().ToUpper().Trim() + "',c_transversal='" + _Txt_Transversal.Text.Trim().ToUpper().Trim() + "',c_piso='" + _Txt_Piso.Text.Trim().ToUpper().Trim() + "',c_local='" + _Txt_Local.Text.Trim().ToUpper().Trim() + "',c_pcardinal='" + _Str_Punto_Cardinal + "',c_urbanizacion='" + _Txt_Urbanizacion.Text.Trim().ToUpper().Trim() + "',c_avenida='" + _Txt_Avenida.Text.Trim().ToUpper().Trim() + "',c_carrera='" + _Txt_Carrera.Text.Trim().ToUpper().Trim() + "',c_esquina='" + _Txt_Esquina.Text.Trim().ToUpper().Trim() + "',c_preferencia='" + _Txt_Referencia.Text.Trim().ToUpper().Trim() + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'"; }
            else
            { _Str_Cadena = "Update TPROSPECTO Set cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',c_estado=" + _Str_estado + ",c_ciudad=" + _Str_ciudad + ",c_municipio=" + _Str_municipio + ",c_parroquia=" + _Str_parroquia + ",c_sector='" + _Txt_Sector.Text.Trim().ToUpper().Trim() + "',c_carretera='" + _Txt_Carretera.Text.Trim().ToUpper().Trim() + "',c_calle='" + _Txt_Calle.Text.Trim().ToUpper().Trim() + "',c_transversal='" + _Txt_Transversal.Text.Trim().ToUpper().Trim() + "',c_piso='" + _Txt_Piso.Text.Trim().ToUpper().Trim() + "',c_local='" + _Txt_Local.Text.Trim().ToUpper().Trim() + "',c_pcardinal='" + _Str_Punto_Cardinal + "',c_urbanizacion='" + _Txt_Urbanizacion.Text.Trim().ToUpper().Trim() + "',c_avenida='" + _Txt_Avenida.Text.Trim().ToUpper().Trim() + "',c_carrera='" + _Txt_Carrera.Text.Trim().ToUpper().Trim() + "',c_esquina='" + _Txt_Esquina.Text.Trim().ToUpper().Trim() + "',c_preferencia='" + _Txt_Referencia.Text.Trim().ToUpper().Trim() + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cclientep='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'"; }
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            MessageBox.Show("Los registros fueron actualizados correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _Pnl_Direccion.Visible = false;
        }

        private void _Pnl_Direccion_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Direccion.Visible)
            {
                _Tb_Tab.Enabled = false;
                _Txt_Cliente_Arriba.Enabled = false;
                _Txt_Des_Cliente_Arriba.Enabled = false;
                _Txt_Rif_Cliente_Arriba.Enabled = false;
                _Bt_Aceptar_direc.Enabled = false;
                _Bt_Editar_Direccion.Enabled = true;
                _Mtd_Enabled_Controles(_Pnl_Direccion, false);
            }
            else
            {
                _Tb_Tab.Enabled = true;
                _Txt_Cliente_Arriba.Enabled = true;
                _Txt_Des_Cliente_Arriba.Enabled = true;
                _Txt_Rif_Cliente_Arriba.Enabled = true;
            }
        }

        private void Frm_Clientes_VC_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;//Configura los controles del padre en el modo de: Deshabilitado
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Chbox_Atendido2_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Atendido2.Checked)
            { _Chbox_Atendido.Checked = true; }
            else
            { _Chbox_Atendido.Checked = false; }
        }

        private void _Chbox_Atendido_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chbox_Atendido.Checked)
            { _Chbox_Atendido2.Checked = true; }
            else
            { _Chbox_Atendido2.Checked = false; }
        }

        private void _Rb_Activo_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Activo.Checked)
            { _Lbl_Nota.Text = "Nota de reactivación"; _Txt_Nota.Enabled = true; }
        }

        private void _Rb_PorActivar_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_PorActivar.Checked)
            { _Lbl_Nota.Text = "Nota"; _Txt_Nota.Enabled = false; }
        }

        private void _Rb_Inactivo_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Inactivo.Checked)
            { _Lbl_Nota.Text = "Nota de inactivación"; _Txt_Nota.Enabled = true; }
        }
        /// <summary>
        /// Calcula los años según una determinada fecha.
        /// </summary>
        /// <param name="_P_Dtp_fecha">Fecha</param>
        /// <returns>Retorna un valor de tipo int</returns>
        private int _Mtd_CalcularAños(DateTime _P_Dtp_fecha)
        {
            DateTime _Dtp_FechaActual = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            int ano = _Dtp_FechaActual.Year - _P_Dtp_fecha.Year;

            if (new DateTime(_Dtp_FechaActual.Year, _P_Dtp_fecha.Month, _P_Dtp_fecha.Day) > _Dtp_FechaActual)
            {
                ano--;
            }
            return ano;
        } 
        private void _Bt_Aceptar_Referencia_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            switch (_Int_Referencia)
            {
                case 0:
                    MessageBox.Show("No se selecciono ninguna referencia", "Informción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 1:
                    if (_Txt_Referencia1.Text.Trim().Length > 0 & ((_Chbox_ChequesDev.Checked & (_Num_Chueques.Value>0 | _Chbox_Mas.Checked)) | (!_Chbox_ChequesDev.Checked)))
                    {
                        _Mtd_Actualizar_Referencias(1);
                        //_Mtd_Inicializar_Pnl_Ref();
                        //_Pnl_Referencia.Visible = false;
                    }
                    else
                    {
                        if(_Txt_Referencia1.Text.Trim().Length==0){ _Er_Error.SetError(_Lbl_Ref1, "Información requerida!!!"); }
                        if (_Chbox_ChequesDev.Checked & _Num_Chueques.Value == 0 & !_Chbox_Mas.Checked) { _Er_Error.SetError(_Num_Chueques, "Información requerida!!!"); }
                    }
                    break;
                case 2:
                    if (_Txt_Referencia2.Text.Trim().Length > 0 & ((_Chbox_ChequesDev.Checked & (_Num_Chueques.Value > 0 | _Chbox_Mas.Checked)) | (!_Chbox_ChequesDev.Checked)))
                    {
                        _Mtd_Actualizar_Referencias(2);
                        //_Mtd_Inicializar_Pnl_Ref();
                        //_Pnl_Referencia.Visible = false;
                    }
                    else
                    {
                        if (_Txt_Referencia2.Text.Trim().Length == 0) { _Er_Error.SetError(_Lbl_Ref2, "Información requerida!!!"); }
                        if (_Chbox_ChequesDev.Checked & _Num_Chueques.Value == 0 & !_Chbox_Mas.Checked) { _Er_Error.SetError(_Num_Chueques, "Información requerida!!!"); }
                    }
                    break;
                case 3:
                    if (_Txt_Referencia3.Text.Trim().Length > 0 & ((_Chbox_ChequesDev.Checked & (_Num_Chueques.Value > 0 | _Chbox_Mas.Checked)) | (!_Chbox_ChequesDev.Checked)))
                    {
                        _Mtd_Actualizar_Referencias(3);
                        //_Mtd_Inicializar_Pnl_Ref();
                        //_Pnl_Referencia.Visible = false;
                    }
                    else
                    {
                        if (_Txt_Referencia3.Text.Trim().Length == 0) { _Er_Error.SetError(_Lbl_Ref3, "Información requerida!!!"); }
                        if (_Chbox_ChequesDev.Checked & _Num_Chueques.Value == 0 & !_Chbox_Mas.Checked) { _Er_Error.SetError(_Num_Chueques, "Información requerida!!!"); }
                    }
                    break;
            }
        }
        /// <summary>
        /// Edita y actualiza la referencia del cliente ó prospecto.
        /// </summary>
        /// <param name="_P_Int_Referencia">Código de la referencia</param>
        private void _Mtd_Actualizar_Referencias(int _P_Int_Referencia)
        {
            string _Str_DiaCredito = "0";
            string _Str_TipoPago = "0";            
            if(_Txt_Credito.Text.Trim().Length==0)
            {
                _Txt_Credito.Text = "0";
            }
            if (_Cmb_Referencia.SelectedIndex == -1)
            { _Cmb_Referencia.SelectedIndex = 0; }
            if (_Cmb_Dias.SelectedIndex == -1)
            { _Cmb_Dias.SelectedIndex = 0; }
            if (_Cmb_TipoPago.SelectedIndex == -1)
            { _Cmb_TipoPago.SelectedIndex = 0; }
            int _Int_ccheques = 0;
            if (_Cmb_Dias.SelectedIndex != 0)
            {
                _Str_DiaCredito = _Cmb_Dias.SelectedValue.ToString() ;
            }
            if (_Cmb_TipoPago.SelectedIndex != 0)
            {
                _Str_TipoPago = _Cmb_Dias.SelectedValue.ToString();
            }
            if (_Chbox_ChequesDev.Checked)
            {
                if (_Chbox_Mas.Checked)
                { _Int_ccheques = 11; }
                else
                { _Int_ccheques = Convert.ToInt32(_Num_Chueques.Value); }
            }
            if (_Bol_Cliente)
            {
                string _Str_Cadena = "Select * from TREFCOMER where ccliente='" + _Txt_Cliente.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "' and creferenciaco='" + _P_Int_Referencia.ToString() + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                {
                    _Str_Cadena = "Update TREFCOMER Set crefpro='" + _Cmb_Referencia.SelectedValue.ToString() + "',ccredipro='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Credito.Text.Trim())) + "',cantigu='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Antiguedad.Value) + "',cdiascredi='" + _Str_DiaCredito + "',ccheques='" + _Int_ccheques.ToString() + "',cfpago='" +_Str_TipoPago + "' where ccompany='" + Frm_Padre._Str_Comp + "' and ccliente='" + _Txt_Cliente.Text.Trim() + "' and creferenciaco='" + _P_Int_Referencia.ToString() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                else
                {
                    _Str_Cadena = "insert into TREFCOMER (ccliente,ccompany,creferenciaco,crefpro,ccredipro,cantigu,ccheques,cdiascredi,cfpago) values('" + _Txt_Cliente.Text.Trim().ToUpper().Trim() + "','" + Frm_Padre._Str_Comp + "','" + _P_Int_Referencia.ToString() + "','" + _Cmb_Referencia.SelectedValue.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Credito.Text.Trim())) + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Antiguedad.Value) + "','" + _Int_ccheques.ToString() + "','" + _Str_DiaCredito + "','" + _Str_TipoPago + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                if (_P_Int_Referencia == 1)
                { _Str_Cadena = "Update TCLIENTE Set c_refcomercial1='" + _Txt_Referencia1.Text.Trim().ToUpper().Trim() + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'"; }
                else if (_P_Int_Referencia == 2)
                { _Str_Cadena = "Update TCLIENTE Set c_refcomercial2='" + _Txt_Referencia2.Text.Trim().ToUpper().Trim() + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'"; }
                else if (_P_Int_Referencia == 3)
                { _Str_Cadena = "Update TCLIENTE Set c_refcomercial3='" + _Txt_Referencia3.Text.Trim().ToUpper().Trim() + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'"; }
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Mtd_Cargar_Promedio_Referencia(_Txt_Cliente.Text.Trim());
            }
            else
            {
                string _Str_Cadena = "Select * from TREFCOMER where cclientep='" + _Txt_Cliente.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "' and creferenciaco='" + _P_Int_Referencia.ToString() + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                {
                    _Str_Cadena = "Update TREFCOMER Set crefpro='" + _Cmb_Referencia.SelectedValue.ToString() + "',ccredipro='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Credito.Text.Trim())) + "',cantigu='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Antiguedad.Value) + "',cdiascredi='" +_Str_DiaCredito + "',ccheques='" + _Int_ccheques.ToString() + "',cfpago='" + _Str_TipoPago + "' where ccompany='" + Frm_Padre._Str_Comp + "' and cclientep='" + _Txt_Cliente.Text.Trim() + "' and creferenciaco='" + _P_Int_Referencia.ToString() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                else
                {
                    _Str_Cadena = "insert into TREFCOMER (cclientep,ccompany,creferenciaco,crefpro,ccredipro,cantigu,ccheques,cdiascredi,cfpago) values('" + _Txt_Cliente.Text.Trim().ToUpper().Trim() + "','" + Frm_Padre._Str_Comp + "','" + _P_Int_Referencia.ToString() + "','" + _Cmb_Referencia.SelectedValue.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Credito.Text.Trim())) + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Antiguedad.Value) + "','" + _Int_ccheques.ToString() + "','" + _Str_DiaCredito + "','" + _Str_TipoPago + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                if (_P_Int_Referencia == 1)
                { _Str_Cadena = "Update TPROSPECTO Set c_refcomercial1='" + _Txt_Referencia1.Text.Trim().ToUpper().Trim() + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cclientep='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'"; }
                else if (_P_Int_Referencia == 2)
                { _Str_Cadena = "Update TPROSPECTO Set c_refcomercial2='" + _Txt_Referencia2.Text.Trim().ToUpper().Trim() + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cclientep='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'"; }
                else if (_P_Int_Referencia == 3)
                { _Str_Cadena = "Update TPROSPECTO Set c_refcomercial3='" + _Txt_Referencia3.Text.Trim().ToUpper().Trim() + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cclientep='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'"; }
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Mtd_Cargar_Promedio_Referencia_Prospecto(_Txt_Cliente.Text.Trim());
            }
            _Mtd_Evaluar_Riesgo(_Txt_Cliente.Text.Trim(), _Txt_Rif.Text.Trim(),_Bol_Cliente);
            MessageBox.Show("El registro fue acualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Muestra los registros en los controles según el cliente seleccionado.
        /// </summary>
        /// <param name="_P_Str_Codigo">Cliente</param>
        /// <param name="_P_Str_Rif">Rif</param>
        private void _Mtd_Cargar_Fecha_Registro(string _P_Str_Codigo, string _P_Str_Rif)
        {
            string _Str_Cadena = "Select cfechregmer from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
           DataSet _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds2.Tables[0].Rows.Count > 0)
            {
                if (_Ds2.Tables[0].Rows[0][0] != System.DBNull.Value)
                { _Dtp_Fecha_Registro.Value = Convert.ToDateTime(_Ds2.Tables[0].Rows[0][0].ToString());}
            }
        }
        /// <summary>
        /// Muestra los registros en los controles según el prospecto seleccionado.
        /// </summary>
        /// <param name="_P_Str_Codigo">Prospecto</param>
        /// <param name="_P_Str_Rif">Rif</param>
        private void _Mtd_Cargar_Fecha_Registro_Prospecto(string _P_Str_Codigo, string _P_Str_Rif)
        {
            string _Str_Cadena = "Select cfechregmer from TPROSPECTO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cclientep='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
            DataSet _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds2.Tables[0].Rows.Count > 0)
            {
                if (_Ds2.Tables[0].Rows[0][0] != System.DBNull.Value)
                { _Dtp_Fecha_Registro.Value = Convert.ToDateTime(_Ds2.Tables[0].Rows[0][0].ToString()); }
            }
        }
        /// <summary>
        /// Muestra los registros en los controles según el cliente seleccionado.
        /// </summary>
        /// <param name="_P_Str_Cliente">cliente</param>
        private void _Mtd_Cargar_Promedio_Referencia(string _P_Str_Cliente)//PENDIENTE POR HACER
        {
            _Txt_Referencia_Promedio.Text = "";
            _Txt_Credito_Promedio.Text = "";
            _Txt_Dias_Promedio.Text = "";
            _Txt_TipoPago_Promedio.Text = "";
            _Txt_Cheques_Promedio.Text = "";
            _Chbox_Mas_Promedio.Checked = false;
            _Chbox_Cheques1.Checked = false;
            string _Str_Cadena = "Select crefpro,ccredipro,cantigu,ccheques,cdiascredi,cfpago from TREFCOMER where ccompany='" + Frm_Padre._Str_Comp + "' and ccliente='" + _P_Str_Cliente + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            DataSet _Ds2 = new DataSet();
            double _Int_crefpro = 0;
            double _Int_ccredipro = 0;
            double _Int_cantigu = 0;
            double _Int_ccheques = 0;
            double _Int_cdiascredi = 0;
            double _Int_cfpago = 0;
            double _Int_Años = 0;
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Str_Cadena = "Select cvalor from TREFERENCIAS where c_idreferencia='" + _Row["crefpro"].ToString() + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds2.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                        {
                            _Int_crefpro = _Int_crefpro + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString());
                        }
                    }
                    //_______________________________________
                    _Str_Cadena = "Select cvalor from TCREDESTRI where creditoedesde<='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Row["ccredipro"].ToString())) + "' and creditoehasta>='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Row["ccredipro"].ToString())) + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds2.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                        {
                            _Int_ccredipro = _Int_ccredipro + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString());
                        }
                    }
                    //_______________________________________
                    if (_Row["cantigu"] != System.DBNull.Value)
                    {
                        _Int_Años = _Int_Años + _Mtd_CalcularAños(Convert.ToDateTime(_Row["cantigu"].ToString()));
                    }
                    _Str_Cadena = "Select ccondiciondesde,canosdesde,ccondicionhasta,canoshasta,cvalor from TANTIGUEDAD where cdelete='0'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    foreach (DataRow _Row2 in _Ds2.Tables[0].Rows)
                    {
                        string _Str_Sql = "";
                        if (_Row2[0].ToString().Trim().Length > 0 & _Row2[1].ToString().Trim() != "0" & _Row2[2].ToString().Trim().Length == 0 & _Row2[3].ToString().Trim() == "0")
                        {
                            _Str_Sql = "Select * from TANTIGUEDAD where " + _Mtd_CalcularAños(Convert.ToDateTime(_Row["cantigu"].ToString())).ToString() + _Row2["ccondiciondesde"].ToString() +"canosdesde";
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 0)
                            {
                                _Int_cantigu = _Int_cantigu + Convert.ToInt32(_Row2["cvalor"].ToString());       
                            }
                        }
                        else if (_Row2[0].ToString().Trim().Length == 0 & _Row2[1].ToString().Trim() == "0" & _Row2[2].ToString().Trim().Length > 0 & _Row2[3].ToString().Trim() != "0")
                        {
                            _Str_Sql = "Select * from TANTIGUEDAD where " + _Mtd_CalcularAños(Convert.ToDateTime(_Row["cantigu"].ToString())).ToString() + _Row2["ccondicionhasta"].ToString() +"canoshasta";
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 0)
                            {
                                _Int_cantigu = _Int_cantigu + Convert.ToInt32(_Row2["cvalor"].ToString());
                            }
  
                        }
                        else if (_Row2[0].ToString().Trim().Length > 0 & _Row2[1].ToString().Trim() != "0" & _Row2[2].ToString().Trim().Length > 0 & _Row2[3].ToString().Trim() != "0")
                        {
                            _Str_Sql = "Select * from TANTIGUEDAD where " + _Mtd_CalcularAños(Convert.ToDateTime(_Row["cantigu"].ToString())).ToString() + _Row2["ccondicionhasta"].ToString() +"canoshasta and " + _Mtd_CalcularAños(Convert.ToDateTime(_Row["cantigu"].ToString())).ToString() + _Row2["ccondiciondesde"].ToString() +"canosdesde";
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 0)
                            {
                                _Int_cantigu = _Int_cantigu + Convert.ToInt32(_Row2["cvalor"].ToString());
                            }

                        }
                    }
                    //_______________________________________
                    if (_Row["ccheques"] != System.DBNull.Value)
                    { _Int_ccheques = _Int_ccheques + Convert.ToInt32(_Row["ccheques"].ToString()); }
                    //_______________________________________
                    _Str_Cadena = "Select cvalor from TDIACREDIT where cdiacredit='" + _Row["cdiascredi"].ToString() + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds2.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                        {
                            _Int_cdiascredi = _Int_cdiascredi + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString());
                        }
                    }
                    //_______________________________________
                    _Str_Cadena = "Select cvalor from TTIPOPAGO where ctipopag='" + _Row["cfpago"].ToString() + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds2.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                        {
                            _Int_cfpago = _Int_cfpago + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString());
                        }
                    }
                }
                _Int_crefpro = _Int_crefpro/_Ds.Tables[0].Rows.Count;
                _Int_ccredipro = _Int_ccredipro / _Ds.Tables[0].Rows.Count;
                _Int_cantigu = _Int_cantigu / _Ds.Tables[0].Rows.Count;
                _Int_ccheques = _Int_ccheques / _Ds.Tables[0].Rows.Count;
                _Int_cdiascredi = _Int_cdiascredi / _Ds.Tables[0].Rows.Count;
                _Int_cfpago = _Int_cfpago / _Ds.Tables[0].Rows.Count;
                _Int_Años = _Int_Años / _Ds.Tables[0].Rows.Count;
                _Int_crefpro = Math.Round(_Int_crefpro);
                _Int_ccredipro = Math.Round(_Int_ccredipro);
                _Int_cantigu = Math.Round(_Int_cantigu);
                _Int_ccheques = Math.Round(_Int_ccheques);
                _Int_cdiascredi = Math.Round(_Int_cdiascredi);
                _Int_cfpago = Math.Round(_Int_cfpago);
                _Int_Años = Math.Round(_Int_Años);
                //-------------------------------------------------------------------
                _Txt_Antiguedad_Pomedio.Text = _Int_Años.ToString();
                _Str_Cadena = "Select c_descripción from TREFERENCIAS where cvalor='" + _Int_crefpro.ToString() + "'";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    _Txt_Referencia_Promedio.Text = _Ds2.Tables[0].Rows[0][0].ToString();
                }
                _Str_Cadena = "Select cdescripcion from TCREDESTRI where cvalor='"+_Int_ccredipro.ToString()+"'";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    _Txt_Credito_Promedio.Text = _Ds2.Tables[0].Rows[0][0].ToString();
                }
                _Str_Cadena = "Select cdescripcion from TDIACREDIT where cvalor='" + _Int_cdiascredi.ToString() + "'";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    _Txt_Dias_Promedio.Text = _Ds2.Tables[0].Rows[0][0].ToString();
                }
                _Str_Cadena = "Select cdescripcion from TTIPOPAGO where cvalor='" + _Int_cfpago.ToString() + "'";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    _Txt_TipoPago_Promedio.Text = _Ds2.Tables[0].Rows[0][0].ToString();
                }
                //_______________________________________
                if (_Int_ccheques > 0 & _Int_ccheques <= 10)
                { _Txt_Cheques_Promedio.Text = _Int_ccheques.ToString(); _Chbox_Cheques1.Checked = true; }
                else if (_Int_ccheques == 11)
                { _Chbox_Mas_Promedio.Checked = true; _Chbox_Cheques1.Checked = true; }
                //_______________________________________
            }
        }
        /// <summary>
        /// Muestra los registros en los controles según el prospecto seleccionado.
        /// </summary>
        /// <param name="_P_Str_Cliente">Prospecto</param>
        private void _Mtd_Cargar_Promedio_Referencia_Prospecto(string _P_Str_Cliente)
        {
            _Txt_Referencia_Promedio.Text = "";
            _Txt_Credito_Promedio.Text = "";
            _Txt_Dias_Promedio.Text = "";
            _Txt_TipoPago_Promedio.Text = "";
            _Txt_Cheques_Promedio.Text = "";
            _Chbox_Mas_Promedio.Checked = false;
            _Chbox_Cheques1.Checked = false;
            string _Str_Cadena = "Select crefpro,ccredipro,cantigu,ccheques,cdiascredi,cfpago from TREFCOMER where ccompany='" + Frm_Padre._Str_Comp + "' and cclientep='" + _P_Str_Cliente + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            DataSet _Ds2 = new DataSet();
            double _Int_crefpro = 0;
            double _Int_ccredipro = 0;
            double _Int_cantigu = 0;
            double _Int_ccheques = 0;
            double _Int_cdiascredi = 0;
            double _Int_cfpago = 0;
            double _Int_Años = 0;
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Str_Cadena = "Select cvalor from TREFERENCIAS where c_idreferencia='" + _Row["crefpro"].ToString() + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds2.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                        {
                            _Int_crefpro = _Int_crefpro + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString());
                        }
                    }
                    //_______________________________________
                    _Str_Cadena = "Select cvalor from TCREDESTRI where creditoedesde<='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Row["ccredipro"].ToString())) + "' and creditoehasta>='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Row["ccredipro"].ToString())) + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds2.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                        {
                            _Int_ccredipro = _Int_ccredipro + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString());
                        }
                    }
                    //_______________________________________
                    if (_Row["cantigu"] != System.DBNull.Value)
                    {
                        _Int_Años = _Int_Años + _Mtd_CalcularAños(Convert.ToDateTime(_Row["cantigu"].ToString()));
                    }
                    _Str_Cadena = "Select ccondiciondesde,canosdesde,ccondicionhasta,canoshasta,cvalor from TANTIGUEDAD where cdelete='0'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    foreach (DataRow _Row2 in _Ds2.Tables[0].Rows)
                    {
                        string _Str_Sql = "";
                        if (_Row2[0].ToString().Trim().Length > 0 & _Row2[1].ToString().Trim() != "0" & _Row2[2].ToString().Trim().Length == 0 & _Row2[3].ToString().Trim() == "0")
                        {
                            _Str_Sql = "Select * from TANTIGUEDAD where " + _Mtd_CalcularAños(Convert.ToDateTime(_Row["cantigu"].ToString())).ToString() + _Row2["ccondiciondesde"].ToString() + "canosdesde";
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 0)
                            {
                                _Int_cantigu = _Int_cantigu + Convert.ToInt32(_Row2["cvalor"].ToString());
                            }
                        }
                        else if (_Row2[0].ToString().Trim().Length == 0 & _Row2[1].ToString().Trim() == "0" & _Row2[2].ToString().Trim().Length > 0 & _Row2[3].ToString().Trim() != "0")
                        {
                            _Str_Sql = "Select * from TANTIGUEDAD where " + _Mtd_CalcularAños(Convert.ToDateTime(_Row["cantigu"].ToString())).ToString() + _Row2["ccondicionhasta"].ToString() + "canoshasta";
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 0)
                            {
                                _Int_cantigu = _Int_cantigu + Convert.ToInt32(_Row2["cvalor"].ToString());
                            }

                        }
                        else if (_Row2[0].ToString().Trim().Length > 0 & _Row2[1].ToString().Trim() != "0" & _Row2[2].ToString().Trim().Length > 0 & _Row2[3].ToString().Trim() != "0")
                        {
                            _Str_Sql = "Select * from TANTIGUEDAD where " + _Mtd_CalcularAños(Convert.ToDateTime(_Row["cantigu"].ToString())).ToString() + _Row2["ccondicionhasta"].ToString() + "canoshasta and " + _Mtd_CalcularAños(Convert.ToDateTime(_Row["cantigu"].ToString())).ToString() + _Row2["ccondiciondesde"].ToString() + "canosdesde";
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 0)
                            {
                                _Int_cantigu = _Int_cantigu + Convert.ToInt32(_Row2["cvalor"].ToString());
                            }

                        }
                    }
                    //_______________________________________
                    if (_Row["ccheques"] != System.DBNull.Value)
                    { _Int_ccheques = _Int_ccheques + Convert.ToInt32(_Row["ccheques"].ToString()); }
                    //_______________________________________
                    _Str_Cadena = "Select cvalor from TDIACREDIT where cdiacredit='" + _Row["cdiascredi"].ToString() + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds2.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                        {
                            _Int_cdiascredi = _Int_cdiascredi + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString());
                        }
                    }
                    //_______________________________________
                    _Str_Cadena = "Select cvalor from TTIPOPAGO where ctipopag='" + _Row["cfpago"].ToString() + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds2.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                        {
                            _Int_cfpago = _Int_cfpago + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString());
                        }
                    }
                }
                _Int_crefpro = _Int_crefpro / _Ds.Tables[0].Rows.Count;
                _Int_ccredipro = _Int_ccredipro / _Ds.Tables[0].Rows.Count;
                _Int_cantigu = _Int_cantigu / _Ds.Tables[0].Rows.Count;
                _Int_ccheques = _Int_ccheques / _Ds.Tables[0].Rows.Count;
                _Int_cdiascredi = _Int_cdiascredi / _Ds.Tables[0].Rows.Count;
                _Int_cfpago = _Int_cfpago / _Ds.Tables[0].Rows.Count;
                _Int_Años = _Int_Años / _Ds.Tables[0].Rows.Count;
                _Int_crefpro = Math.Round(_Int_crefpro);
                _Int_ccredipro = Math.Round(_Int_ccredipro);
                _Int_cantigu = Math.Round(_Int_cantigu);
                _Int_ccheques = Math.Round(_Int_ccheques);
                _Int_cdiascredi = Math.Round(_Int_cdiascredi);
                _Int_cfpago = Math.Round(_Int_cfpago);
                _Int_Años = Math.Round(_Int_Años);
                //-------------------------------------------------------------------
                _Txt_Antiguedad_Pomedio.Text = _Int_Años.ToString();
                _Str_Cadena = "Select c_descripción from TREFERENCIAS where cvalor='" + _Int_crefpro.ToString() + "'";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    _Txt_Referencia_Promedio.Text = _Ds2.Tables[0].Rows[0][0].ToString();
                }
                _Str_Cadena = "Select cdescripcion from TCREDESTRI where cvalor='" + _Int_ccredipro.ToString() + "'";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    _Txt_Credito_Promedio.Text = _Ds2.Tables[0].Rows[0][0].ToString();
                }
                _Str_Cadena = "Select cdescripcion from TDIACREDIT where cvalor='" + _Int_cdiascredi.ToString() + "'";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    _Txt_Dias_Promedio.Text = _Ds2.Tables[0].Rows[0][0].ToString();
                }
                _Str_Cadena = "Select cdescripcion from TTIPOPAGO where cvalor='" + _Int_cfpago.ToString() + "'";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    _Txt_TipoPago_Promedio.Text = _Ds2.Tables[0].Rows[0][0].ToString();
                }
                //_______________________________________
                if (_Int_ccheques > 0 & _Int_ccheques <= 10)
                { _Txt_Cheques_Promedio.Text = _Int_ccheques.ToString(); _Chbox_Cheques1.Checked = true; }
                else if (_Int_ccheques == 11)
                { _Chbox_Mas_Promedio.Checked = true; _Chbox_Cheques1.Checked = true; }
                //_______________________________________
            }
        }
        private void _Bt_Referencia_Click(object sender, EventArgs e)
        {
            if (_Txt_Cliente.Text.Trim().Length > 0)
            {
                if (_Bol_Cliente)
                { _Mtd_Cargar_Referencias(_Txt_Cliente.Text.Trim(), _Txt_Rif.Text.Trim()); }
                else
                { _Mtd_Cargar_Referencias_Prospecto(_Txt_Cliente.Text.Trim(), _Txt_Rif.Text.Trim()); }
                _Mtd_Inicializar_Pnl_Ref();
                _Int_Referencia = 1;
                _Mtd_Igualar_Referencia(1);
                _Pnl_Ref1.BackColor = Color.Khaki;
                _Pnl_Ref2.BackColor = this.BackColor;
                _Pnl_Ref3.BackColor = this.BackColor;
                _Txt_Referencia1.Enabled = true;
                _Txt_Referencia2.Enabled = false;
                _Txt_Referencia3.Enabled = false;
                _Pnl_Referencia.Visible = true; 
            }
            else
            { MessageBox.Show("Es necesario seleccionar un cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Pnl_Referencia_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Referencia.Visible)
            {
                _Tb_Tab.Enabled = false;
                _Txt_Cliente_Arriba.Enabled = false;
                _Txt_Des_Cliente_Arriba.Enabled = false;
                _Txt_Rif_Cliente_Arriba.Enabled = false;
            }
            else
            {
                _Tb_Tab.Enabled = true;
                _Txt_Cliente_Arriba.Enabled = true;
                _Txt_Des_Cliente_Arriba.Enabled = true;
                _Txt_Rif_Cliente_Arriba.Enabled = true;
            }
        }
        /// <summary>
        /// Inicializa erl panel de referecias
        /// </summary>
        private void _Mtd_Inicializar_Pnl_Ref()
        {
            _Er_Error.Dispose();
            _Pnl_Ref.Enabled = true;
            _Cmb_Referencia.SelectedIndex = 0;
            _Txt_Credito.Text = "";
            _Cmb_Dias.SelectedIndex = 0;
            _Cmb_TipoPago.SelectedIndex = 0;
            _Dtp_Antiguedad.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Num_Chueques.Value = 0;
            _Txt_Años.Text = "";
            _Chbox_ChequesDev.Checked = false;
            _Chbox_Mas.Checked = false;
            //_Int_Referencia = 0;
            _Cmb_Referencia.Focus();
        }
        /// <summary>
        /// carga el combo de Referencia
        /// </summary>
        private void _Mtd_Cargar_Referencia()
        {
            _myUtilidad._Mtd_CargarCombo(_Cmb_Referencia, "Select c_idreferencia,c_descripción from TREFERENCIAS where cdelete='0'");
        }
        /// <summary>
        /// Carga el combo de dias de Crédito
        /// </summary>
        private void _Mtd_Cargar_Dias()
        {
            _myUtilidad._Mtd_CargarCombo(_Cmb_Dias, "Select cdiacredit,cdescripcion from TDIACREDIT where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "'");
        }
        /// <summary>
        /// Carga el combo de contribuyente
        /// </summary>
        private void _Mtd_Cargar_Contribuyente()
        {
            _myUtilidad._Mtd_CargarCombo(_Cmb_Contribuyente, "Select ccontribuyente,cname from TCONTRIBUYENTE where cdelete='0' ORDER BY cname ASC");
        }
        /// <summary>
        /// Carga el combo de tipo de pago
        /// </summary>
        private void _Mtd_Cargar_TipoPgo()
        {
            _myUtilidad._Mtd_CargarCombo(_Cmb_TipoPago, "Select ctipopag,cdescripcion from TTIPOPAGO where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "' ORDER BY cdescripcion ASC");
        }
        /// <summary>
        /// Carga los datos de la referencia según el numero de referencia
        /// </summary>
        /// <param name="_P_Int_Referencia">Numero de refencia</param>
        private void _Mtd_Igualar_Referencia(int _P_Int_Referencia)
        {
            string _Str_Cadena = "";
            if (_Bol_Cliente)
            { _Str_Cadena = "Select crefpro,dbo.Fnc_Formatear(ccredipro) as ccredipro,cantigu,ccheques,cdiascredi,cfpago FROM TREFCOMER where ccliente='" + _Txt_Cliente.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "' and creferenciaco='" + _P_Int_Referencia.ToString() + "'"; }
            else
            { _Str_Cadena = "Select crefpro,dbo.Fnc_Formatear(ccredipro) as ccredipro,cantigu,ccheques,cdiascredi,cfpago FROM TREFCOMER where cclientep='" + _Txt_Cliente.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "' and creferenciaco='" + _P_Int_Referencia.ToString() + "'"; }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                DataRow _Row = _Ds.Tables[0].Rows[0];
                _Cmb_Referencia.SelectedValue =_Row["crefpro"].ToString();
                _Txt_Credito.Text = _Row["ccredipro"].ToString();
                if (_Row["cantigu"] != System.DBNull.Value)
                { _Dtp_Antiguedad.Value = Convert.ToDateTime(_Row["cantigu"].ToString()); }
                _Cmb_Dias.SelectedValue = _Row["cdiascredi"].ToString();
                if (Convert.ToInt32(_Row["ccheques"].ToString()) > 0 & Convert.ToInt32(_Row["ccheques"].ToString()) <= 10)
                { _Chbox_ChequesDev.Checked = true; _Num_Chueques.Value = Convert.ToDecimal(_Row["ccheques"].ToString()); }
                else if (Convert.ToInt32(_Row["ccheques"].ToString()) == 11)
                { _Chbox_ChequesDev.Checked = true; _Chbox_Mas.Checked = true; }
                else
                { _Chbox_ChequesDev.Checked = false; }
                _Cmb_TipoPago.SelectedValue = _Row["cfpago"].ToString(); 
            }
        }
        private void _Bt_Cancelar_Referencia_Click(object sender, EventArgs e)
        {
            _Pnl_Referencia.Visible = false;
        }
        private void _Chbox_ChequesDev_CheckedChanged(object sender, EventArgs e)
        {
            if (!_Chbox_ChequesDev.Checked)
            {
                _Chbox_Mas.Checked = false;
                _Num_Chueques.Value = 0;
            }
        }

        private void _Num_Chueques_ValueChanged(object sender, EventArgs e)
        {
            if (!_Chbox_ChequesDev.Checked)
            { _Num_Chueques.Value = 0; }
            else
            {
                if(_Num_Chueques.Value!=0)
                _Chbox_Mas.Checked = false; 
            }
        }

        private void _Chbox_Mas_CheckedChanged(object sender, EventArgs e)
        {
            if (!_Chbox_ChequesDev.Checked)
            { _Chbox_Mas.Checked = false; }
            else
            {
                if (_Chbox_Mas.Checked)
                {
                    _Num_Chueques.Value = 0;
                }
            }
        }

        private void _Dtp_Antiguedad_ValueChanged(object sender, EventArgs e)
        {
            if (_Mtd_CalcularAños(_Dtp_Antiguedad.Value) == -1)
            { _Dtp_Antiguedad.Value.AddDays(-1); }
            else
            { _Txt_Años.Text = _Mtd_CalcularAños(_Dtp_Antiguedad.Value).ToString(); }
        }

        private void _Dtp_Fecha_Registro_ValueChanged(object sender, EventArgs e)
        {
            if (_Mtd_CalcularAños(_Dtp_Fecha_Registro.Value) == -1)
            { _Dtp_Fecha_Registro.Value.AddDays(-1); }
            else
            { _Txt_Años_Registro.Text = _Mtd_CalcularAños(_Dtp_Fecha_Registro.Value).ToString(); }
        }
        /// <summary>
        /// Guara la información de Riesgo según el cliente o prospecto seleccionado.
        /// </summary>
        /// <param name="_P_Str_Codigo">Código</param>
        /// <param name="_P_Str_Rif">Rif</param>
        private void _Mtd_Guardar_Riesgo(string _P_Str_Codigo, string _P_Str_Rif)
        {
            string _Str_Compra = "0", _Str_LimitCredit= "'0'", _Str_TpoEmpresa = "0", _Str_PromCompra="0";
            if (_Cmb_Limite_Credito.SelectedIndex > 0)
            { _Str_LimitCredit = "'" + _Cmb_Limite_Credito.SelectedValue.ToString() + "'"; }
            if (_Cmb_Tipo_Empresa.SelectedIndex > 0)
            {
                _Str_TpoEmpresa = _Cmb_Tipo_Empresa.SelectedValue.ToString();
            }
            if (_Cmb_Compra.SelectedIndex > 0)
            {
                _Str_Compra = _Cmb_Compra.SelectedValue.ToString();
            }
            //--------------------TCLIENTE-----------------------
            if (_Txt_Capital_Pagado.Text.Trim().Length == 0)
            { _Txt_Capital_Pagado.Text = "0"; }
            if (_Txt_Capital_Registrado.Text.Trim().Length == 0)
            { _Txt_Capital_Registrado.Text = "0"; }
            string _Str_Cadena = "";
            if (_Bol_Cliente)
            {
                if (new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Fecha_Registro.Value) == new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()))
                { _Str_Cadena = "Update TCLIENTE Set c_atendidodirecto='" + Convert.ToInt32(_Chbox_Atendido2.Checked).ToString() + "',c_limt_credit=" + _Str_LimitCredit + ",c_capitalsolpag='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Capital_Pagado.Text.Trim())) + "',c_capitalsolreg='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Capital_Registrado.Text.Trim())) + "',c_notascob='" + _Txt_Notas_Cobranza.Text.Trim() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'"; }
                else
                { _Str_Cadena = "Update TCLIENTE Set c_atendidodirecto='" + Convert.ToInt32(_Chbox_Atendido2.Checked).ToString() + "',c_limt_credit=" + _Str_LimitCredit + ",c_capitalsolpag='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Capital_Pagado.Text.Trim())) + "',c_capitalsolreg='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Capital_Registrado.Text.Trim())) + "',c_notascob='" + _Txt_Notas_Cobranza.Text.Trim() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',cfechregmer='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Fecha_Registro.Value) + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'"; }
            }
            else
            {
                if (new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Fecha_Registro.Value) == new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()))
                { _Str_Cadena = "Update TPROSPECTO Set c_atendidodirecto='" + Convert.ToInt32(_Chbox_Atendido2.Checked).ToString() + "',c_limt_credit=" + _Str_LimitCredit + ",c_capitalsolpag='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Capital_Pagado.Text.Trim())) + "',c_capitalsolreg='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Capital_Registrado.Text.Trim())) + "',c_notascob='" + _Txt_Notas_Cobranza.Text.Trim() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cclientep='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'"; }
                else
                { _Str_Cadena = "Update TPROSPECTO Set c_atendidodirecto='" + Convert.ToInt32(_Chbox_Atendido2.Checked).ToString() + "',c_limt_credit=" + _Str_LimitCredit + ",c_capitalsolpag='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Capital_Pagado.Text.Trim())) + "',c_capitalsolreg='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Capital_Registrado.Text.Trim())) + "',c_notascob='" + _Txt_Notas_Cobranza.Text.Trim() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',cfechregmer='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Fecha_Registro.Value) + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cclientep='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'"; }
            }
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            //---------------------------------------------------
            //--------------------TRIESGOS-----------------------
            if (_Txt_Monto.Text.Trim().Length == 0)
            { _Txt_Monto.Text = "0"; }
            if (_Cmb_Promedio_Compra.SelectedIndex > 0)
            {
                _Str_PromCompra = _Cmb_Promedio_Compra.SelectedValue.ToString();
            }
            if (_Bol_Cliente)
            {
                _Str_Cadena = "Select * from TRIESGOS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_Cadena = "Update TRIESGOS Set ctipoempresa=" + _Str_TpoEmpresa + ",csucursales='" + Convert.ToInt32(_Chbox_Sucursales.Checked).ToString() + "',cpoliza='" + Convert.ToInt32(_Chbox_Poliza.Checked).ToString() + "',clocal='" + Convert.ToInt32(_Chbox_Local.Checked).ToString() + "',cdeposito='" + Convert.ToInt32(_Chbox_Deposito.Checked).ToString() + "',cpromediocompra=" + _Str_PromCompra + ",cmontoasegurado='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Monto.Text.Trim())) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',clinea=" + _Str_Compra + " where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                else
                {
                    _Str_Cadena = "insert into TRIESGOS (cgroupcomp,ccliente,c_rif,ctipoempresa,csucursales,cpoliza,clocal,cdeposito,cpromediocompra,cmontoasegurado,cdateadd,cuseradd,cdelete,clinea) values('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Codigo + "','" + _P_Str_Rif + "'," + _Str_TpoEmpresa + ",'" + Convert.ToInt32(_Chbox_Sucursales.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Poliza.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Local.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Deposito.Checked).ToString() + "'," + _Str_PromCompra + ",'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Monto.Text.Trim())) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0'," + _Str_Compra + ")";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
            }
            else
            {
                _Str_Cadena = "Select * from TRIESGOS where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cclientep='" + _P_Str_Codigo + "' and c_rif='" + _P_Str_Rif + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_Cadena = "Update TRIESGOS Set ctipoempresa=" + _Str_TpoEmpresa + ",csucursales='" + Convert.ToInt32(_Chbox_Sucursales.Checked).ToString() + "',cpoliza='" + Convert.ToInt32(_Chbox_Poliza.Checked).ToString() + "',clocal='" + Convert.ToInt32(_Chbox_Local.Checked).ToString() + "',cdeposito='" + Convert.ToInt32(_Chbox_Deposito.Checked).ToString() + "',cpromediocompra=" + _Str_PromCompra + ",cmontoasegurado='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Monto.Text.Trim())) + "',cdateupd=GETDATE()";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
                else
                {
                    _Str_Cadena = "insert into TRIESGOS (cgroupcomp,cclientep,c_rif,ctipoempresa,csucursales,cpoliza,clocal,cdeposito,cpromediocompra,cmontoasegurado,cdateadd,cuseradd,cdelete,clinea) values('" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Codigo + "','" + _P_Str_Rif + "'," + _Str_TpoEmpresa + ",'" + Convert.ToInt32(_Chbox_Sucursales.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Poliza.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Local.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Deposito.Checked).ToString() + "'," + _Str_PromCompra + ",'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Monto.Text.Trim())) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0'," + _Str_Compra + ")";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
            }
            //---------------------------------------------------
        }
        /// <summary>
        /// Evalua el Riesgo según el cliente o prospecto seleccionado.
        /// </summary>
        /// <param name="_P_Str_Codigo">Código</param>
        /// <param name="_P_Str_Rif">Rif</param>
        /// <param name="_P_Bol_Cliente">Coloque true si es un cliente de lo contrario coloque false</param>
        private void _Mtd_Evaluar_Riesgo(string _P_Str_Codigo, string _P_Str_Rif,bool _P_Bol_Cliente)
        {
            string _Str_Compra = "0", _Str_TpoEmpresa = "0", _Str_PromCompra = "0";
            string _Str_Cadena = "";
            if (_Cmb_Compra.SelectedIndex >0)
            { _Str_Compra = _Cmb_Compra.SelectedValue.ToString(); }
            if (_Cmb_Tipo_Empresa.SelectedIndex > 0)
            { _Str_TpoEmpresa = _Cmb_Tipo_Empresa.SelectedValue.ToString(); }
            if (_Cmb_Promedio_Compra.SelectedIndex > 0)
            { _Str_PromCompra = _Cmb_Promedio_Compra.SelectedValue.ToString(); }
            if (_P_Bol_Cliente)
            { _Str_Cadena = "Select crefpro,ccredipro,cantigu,ccheques,cdiascredi,cfpago from TREFCOMER where ccompany='" + Frm_Padre._Str_Comp + "' and ccliente='" + _P_Str_Codigo + "'"; }
            else
            { _Str_Cadena = "Select crefpro,ccredipro,cantigu,ccheques,cdiascredi,cfpago from TREFCOMER where ccompany='" + Frm_Padre._Str_Comp + "' and cclientep='" + _P_Str_Codigo + "'"; }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            DataSet _Ds2 = new DataSet();
            int _Int_Riesgo = 0;
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Str_Cadena = "Select cvalor from TREFERENCIAS where c_idreferencia='" + _Row["crefpro"].ToString() + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds2.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                        {
                            _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString());
                        }
                    }
                    //_______________________________________
                    _Str_Cadena = "Select cvalor from TCREDESTRI where creditoedesde<='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Row["ccredipro"].ToString())) + "' and creditoehasta>='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Row["ccredipro"].ToString())) + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds2.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                        {
                            _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString());
                        }
                    }
                    //_______________________________________
                    _Str_Cadena = "Select ccondiciondesde,canosdesde,ccondicionhasta,canoshasta,cvalor from TANTIGUEDAD where cdelete='0'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    foreach (DataRow _Row2 in _Ds2.Tables[0].Rows)
                    {
                        string _Str_Sql = "";
                        if (_Row2[0].ToString().Trim().Length > 0 & _Row2[1].ToString().Trim() != "0" & _Row2[2].ToString().Trim().Length == 0 & _Row2[3].ToString().Trim() == "0")
                        {
                            _Str_Sql = "Select * from TANTIGUEDAD where " + _Mtd_CalcularAños(Convert.ToDateTime(_Row["cantigu"].ToString())).ToString() + _Row2["ccondiciondesde"].ToString() + "canosdesde";
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 0)
                            {
                                _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Row2["cvalor"].ToString());
                            }
                        }
                        else if (_Row2[0].ToString().Trim() == "0" & _Row2[1].ToString().Trim() == "0" & _Row2[2].ToString().Trim().Length > 0 & _Row2[3].ToString().Trim() != "0")
                        {
                            _Str_Sql = "Select * from TANTIGUEDAD where " + _Mtd_CalcularAños(Convert.ToDateTime(_Row["cantigu"].ToString())).ToString() + _Row2["ccondicionhasta"].ToString() + "canoshasta";
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 0)
                            {
                                _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Row2["cvalor"].ToString());
                            }

                        }
                        else if (_Row2[0].ToString().Trim().Length > 0 & _Row2[1].ToString().Trim() != "0" & _Row2[2].ToString().Trim().Length > 0 & _Row2[3].ToString().Trim()!= "0")
                        {
                            _Str_Sql = "Select * from TANTIGUEDAD where " + _Mtd_CalcularAños(Convert.ToDateTime(_Row["cantigu"].ToString())).ToString() + _Row2["ccondicionhasta"].ToString() + "canoshasta and " + _Mtd_CalcularAños(Convert.ToDateTime(_Row["cantigu"].ToString())).ToString() + _Row2["ccondiciondesde"].ToString() + "canosdesde";
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 0)
                            {
                                _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Row2["cvalor"].ToString());
                            }

                        }
                    }
                    //_______________________________________
                    //if (_Row["ccheques"] != System.DBNull.Value)
                    //{ _Int_ccheques = _Int_ccheques + Convert.ToInt32(_Row["ccheques"].ToString()); }
                    //_______________________________________
                    _Str_Cadena = "Select cvalor from TDIACREDIT where cdiacredit='" + _Row["cdiascredi"].ToString() + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds2.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                        {
                            _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString());
                        }
                    }
                    //_______________________________________
                    _Str_Cadena = "Select cvalor from TTIPOPAGO where ctipopag='" + _Row["cfpago"].ToString() + "'";
                    _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds2.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds2.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                        {
                            _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString());
                        }
                    }
                }
                _Int_Riesgo = _Int_Riesgo / _Ds.Tables[0].Rows.Count;
                //-------------------------------------------------------------------
                _Str_Cadena = "Select cvalor from TTEMPRESA where c_tipemp=" + _Str_TpoEmpresa;
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString());
                }
                //-------------------------------------------------------------------
                _Str_Cadena = "Select ctienesucursal,cnotienesucursal from TCONFIGRIESGO";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    if (_Chbox_Sucursales.Checked)
                    { _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString()); }
                    else
                    { _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][1].ToString()); }
                }
                //-------------------------------------------------------------------
                _Str_Cadena = "Select cposeepoliza,cnoposeepoliza from TCONFIGRIESGO";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    if (_Chbox_Poliza.Checked)
                    { _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString()); }
                    else
                    { _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][1].ToString()); }
                }
                //-------------------------------------------------------------------
                _Str_Cadena = "Select ctienelocal,cnotienelocal from TCONFIGRIESGO";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    if (_Chbox_Local.Checked)
                    { _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString()); }
                    else
                    { _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][1].ToString()); }
                }
                //-------------------------------------------------------------------
                _Str_Cadena = "Select cposeedepositom,cnoposeedepositom from TCONFIGRIESGO";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    if (_Chbox_Deposito.Checked)
                    { _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString()); }
                    else
                    { _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][1].ToString()); }
                }
                //-------------------------------------------------------------------
                _Str_Cadena = "Select catendidodirecto,cnoatendidodirecto from TCONFIGRIESGO";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    if (_Chbox_Atendido2.Checked)
                    { _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString()); }
                    else
                    { _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][1].ToString()); }
                }
                //-------------------------------------------------------------------
                _Str_Cadena = "Select cchequedevueltos,cnochequedevueltos from TCONFIGRIESGO";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    if (_Chbox_Cheques2.Checked)
                    { _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString()); }
                    else
                    { _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][1].ToString()); }
                }
                //-------------------------------------------------------------------
                _Str_Cadena = "Select cchequedevueltosfecha,cnochequedevueltosdecha from TCONFIGRIESGO";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    if (_Txt_Chequesala_Fecha.Text.Trim()=="Sí")
                    { _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString()); }
                    else
                    { _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][1].ToString()); }
                }
                //-------------------------------------
                _Str_Cadena = "Select cvalor from TPROMCOMP where c_idpromediocomp=" + _Str_PromCompra;
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString());
                }
                //-------------------------------------
                _Str_Cadena = "Select cvalor from TLINEAVTAM where clinea=" + _Str_Compra;
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString());
                }
                _Str_Cadena = "Select csaldovencido,csaldoporvencer from TCONFIGRIESGO";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    if (_Txt_Saldoala_Fecha.Text.Trim().Length == 0)
                    { _Txt_Saldoala_Fecha.Text = "0"; }
                    if (_Txt_Saldopor_Vencer.Text.Trim().Length == 0)
                    { _Txt_Saldopor_Vencer.Text = "0"; }
                    if ((Convert.ToDouble(_Txt_Saldoala_Fecha.Text.Trim()) > 0 & Convert.ToDouble(_Txt_Saldopor_Vencer.Text.Trim()) > 0) | Convert.ToDouble(_Txt_Saldoala_Fecha.Text.Trim()) > 0)
                    {_Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][0].ToString());}
                    else if (Convert.ToDouble(_Txt_Saldopor_Vencer.Text.Trim()) > 0)
                    { _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Ds2.Tables[0].Rows[0][1].ToString()); }
                }
                //_______________________________________
                _Str_Cadena = "Select ccondiciondesde,canosdesde,ccondicionhasta,canoshasta,cvalor from TFECHAREGISTRO where cdelete='0'";
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                foreach (DataRow _Row2 in _Ds2.Tables[0].Rows)
                {
                    string _Str_Sql = "";
                    if (_Row2[0].ToString().Trim().Length > 0 & _Row2[1].ToString().Trim() != "0" & _Row2[2].ToString().Trim().Length == 0 & _Row2[3].ToString().Trim() == "0")
                    {
                        _Str_Sql = "Select * from TFECHAREGISTRO where " + _Mtd_CalcularAños(_Dtp_Fecha_Registro.Value).ToString() + _Row2["ccondiciondesde"].ToString() + "canosdesde";
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 0)
                        {
                            _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Row2["cvalor"].ToString());
                        }
                    }
                    else if (_Row2[0].ToString().Trim().Length == 0 & _Row2[1].ToString().Trim() == "0" & _Row2[2].ToString().Trim().Length > 0 & _Row2[3].ToString().Trim() != "0")
                    {
                        _Str_Sql = "Select * from TFECHAREGISTRO where " + _Mtd_CalcularAños(_Dtp_Fecha_Registro.Value).ToString() + _Row2["ccondicionhasta"].ToString() + "canoshasta";
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 0)
                        {
                            _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Row2["cvalor"].ToString());
                        }

                    }
                    else if (_Row2[0].ToString().Trim().Length > 0 & _Row2[1].ToString().Trim() != "0" & _Row2[2].ToString().Trim().Length > 0 & _Row2[3].ToString().Trim() != "0")
                    {
                        _Str_Sql = "Select * from TFECHAREGISTRO where " + _Mtd_CalcularAños(_Dtp_Fecha_Registro.Value).ToString() + _Row2["ccondicionhasta"].ToString() + "canoshasta and " + _Mtd_CalcularAños(_Dtp_Fecha_Registro.Value).ToString() + _Row2["ccondiciondesde"].ToString() + "canosdesde";
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 0)
                        {
                            _Int_Riesgo = _Int_Riesgo + Convert.ToInt32(_Row2["cvalor"].ToString());
                        }

                    }
                }
                if (_Txt_Cheques_Promedio.Text.Trim().Length == 0)
                { _Txt_Cheques_Promedio.Text = "0"; }
                if (_Txt_ChequesDev_Cuantos.Text.Trim().Length == 0)
                { _Txt_ChequesDev_Cuantos.Text = "0"; }
                if (_Txt_ChequesDev_Cuantos.Text.Trim().Length > 0)
                {
                    int _Int_Cantidad = Convert.ToInt32(_Txt_ChequesDev_Cuantos.Text.Trim()) + Convert.ToInt32(_Txt_Cheques_Promedio.Text.Trim());
                    if (_Int_Cantidad > 10 | _Chbox_Mas_Promedio.Checked)
                    { _Int_Riesgo = _Int_Riesgo - 10; }
                    else
                    {
                        _Int_Riesgo = Convert.ToInt32(Convert.ToDouble(_Int_Riesgo) - (Convert.ToDouble(_Int_Cantidad) * 0.5));
                    }
                }
                _Str_Cadena = "Select cdescripcion,criesgo from TTRIESGO where cdelete='0' and cdesde<='" + _Int_Riesgo.ToString() + "' and chasta>='" + _Int_Riesgo.ToString() + "'";
                textBox1.Text = _Int_Riesgo.ToString();
                _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    _Lbl_Riesgo.Text=_Ds2.Tables[0].Rows[0][0].ToString();
                    if (_Ds2.Tables[0].Rows[0][1] != System.DBNull.Value)
                    {
                        if (Convert.ToInt32(_Ds2.Tables[0].Rows[0][1].ToString()) > 3)
                        {
                            _Pgb_Barra.Value = 3;
                            _Pgb_Barra.BarColor = Color.Red;
                        }
                        else
                        {
                            if (Convert.ToInt32(_Ds2.Tables[0].Rows[0][1].ToString()) == 1)
                            { _Pgb_Barra.BarColor = Color.AliceBlue; }
                            else if (Convert.ToInt32(_Ds2.Tables[0].Rows[0][1].ToString()) == 2)
                            { _Pgb_Barra.BarColor = Color.Yellow; }
                            else if (Convert.ToInt32(_Ds2.Tables[0].Rows[0][1].ToString()) == 3)
                            { _Pgb_Barra.BarColor = Color.Red; }
                            _Pgb_Barra.Value =Convert.ToInt32(_Ds2.Tables[0].Rows[0][1].ToString()); 
                        }
                    }
                }
            }
        }
        private void _Bt_Guardar_Riesgo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (_Txt_Cliente.Text.Trim().Length > 0)
            {
                string _Str_Cadena = "";
                if (_Bol_Cliente)
                { _Str_Cadena = "Select * from TREFCOMER where ccliente='" + _Txt_Cliente.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "'"; }
                else
                { _Str_Cadena = "Select * from TREFCOMER where cclientep='" + _Txt_Cliente.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "'"; }
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
                { MessageBox.Show("Es necesario agregar las referencias comerciales para guardar la evaluación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else
                {                    
                    _Mtd_Guardar_Riesgo(_Txt_Cliente.Text.Trim(), _Txt_Rif.Text.Trim()); _Mtd_Evaluar_Riesgo(_Txt_Cliente.Text.Trim(), _Txt_Rif.Text.Trim(), _Bol_Cliente); MessageBox.Show("La información ha sido actualizada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); _Bt_Guardar_Riesgo.Enabled = false; _Bt_Editar_Riesgo.Enabled = true;
                }
            }
            else
            { MessageBox.Show("Es necesario seleccionar un cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            Cursor = Cursors.Default;
        }

        private void _Cmb_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Estado.SelectedIndex>0)
            {
                _Mtd_Cargar_Ciudad(_Cmb_Estado.SelectedValue.ToString());
                _Mtd_Cargar_Municipio(_Cmb_Estado.SelectedValue.ToString());
            }
        }

        private void _Bt_Editar_Riesgo_Click(object sender, EventArgs e)
        {
            if (_Txt_Cliente.Text.Trim().Length > 0)
            { _Bt_Guardar_Riesgo.Enabled = true; _Bt_Editar_Riesgo.Enabled = false; }
            else
            { MessageBox.Show("Es necesario seleccionar un cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void _Bt_Editar_Riesgo_EnabledChanged(object sender, EventArgs e)
        {
            if (!_Bt_Editar_Riesgo.Enabled)
            {
                _Cmb_Compra.Enabled = true;
                _Cmb_Promedio_Compra.Enabled = true;
                _Grb_Compras.Enabled = true;
                _Grb_General.Enabled = true;
                _Grb_Referencias.Enabled = true;
                if (new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Fecha_Registro.Value) == new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()))
                { _Dtp_Fecha_Registro.Enabled = true; }
                else
                { _Dtp_Fecha_Registro.Enabled = false; }
            }
            else
            {
                _Cmb_Compra.Enabled = false;
                _Cmb_Promedio_Compra.Enabled = false;
                _Grb_Compras.Enabled = false;
                _Grb_General.Enabled =false;
                _Grb_Referencias.Enabled = false;
                _Dtp_Fecha_Registro.Enabled = false;
            }
        }

        private void _Bt_Riesgo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (_Txt_Cliente.Text.Trim().Length > 0)
            {
                string _Str_Cadena = "";
                if (_Bol_Cliente)
                { _Str_Cadena = "Select * from TREFCOMER where ccliente='" + _Txt_Cliente.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "'"; }
                else
                { _Str_Cadena = "Select * from TREFCOMER where cclientep='" + _Txt_Cliente.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "'"; }
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
                { MessageBox.Show("Es necesario agregar las referencias comerciales para guardar la evaluación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else
                {
                    _Mtd_Guardar_Riesgo(_Txt_Cliente.Text.Trim(), _Txt_Rif.Text.Trim()); _Mtd_Evaluar_Riesgo(_Txt_Cliente.Text.Trim(), _Txt_Rif.Text.Trim(), _Bol_Cliente); MessageBox.Show("La evaluación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
            }
            else
            { MessageBox.Show("Es necesario seleccionar un cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            Cursor = Cursors.Default;
        }

        private void _Cmb_Municipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Municipio.SelectedIndex > 0)
            {
                _Mtd_Cargar_Parroquia(_Cmb_Municipio.SelectedValue.ToString());
            }
        }

        private void _Bt_EditarCob_Click(object sender, EventArgs e)
        {
            if (_Bol_Cliente)
            { _Grb_Activacion.Enabled = true; }
            _Grb_Banco.Enabled = true;
            _Grb_Documentos.Enabled = true;
            _Bt_EditarCob.Enabled = false;  
            _Bt_GuardarCob.Enabled = true;
        }

        private void _Bt_GuardarCob_Click(object sender, EventArgs e)
        {
            string _Str_BancoNeg = "null", _Str_BancoPers="null", _Str_BancoSoc = "null", _Str_FPago= "null";
            Cursor = Cursors.WaitCursor;
            if (_Cmb_Banco1.SelectedIndex > 0)
            {
                _Str_BancoNeg = "'" + _Cmb_Banco1.SelectedValue.ToString() + "'";
            }
            if (_Cmb_Banco2.SelectedIndex > 0)
            {
                _Str_BancoPers = "'" + _Cmb_Banco2.SelectedValue.ToString() + "'";
            }
            if (_Cmb_Banco3.SelectedIndex > 0)
            {
                _Str_BancoSoc = "'"+_Cmb_Banco3.SelectedValue.ToString()+"'";
            }
            if (_Cmb_Fpago.SelectedIndex > 0)
            {
                _Str_FPago = "'" + _Cmb_Fpago.SelectedValue.ToString() + "'";
            }
            if (_Txt_AccionistaN_Datos.Text.Trim().Length == 0)
            { _Txt_AccionistaN_Datos.Text = "0"; }
            string _Str_Cadena = "";
            _Er_Error.Dispose();
            if (!_Bol_Cliente)
            {
                if (((_Cmb_Banco1.SelectedIndex>0 & _Txt_Banco1.Text.Trim().Length > 0) | (_Cmb_Banco2.SelectedIndex>0 & _Txt_Banco2.Text.Trim().Length > 0) | (_Cmb_Banco3.SelectedIndex>0 & _Txt_Banco3.Text.Trim().Length > 0)) & _Txt_AccionistaN_Datos.Text.Trim().Length > 0 & _Txt_Representante_Datos.Text.Trim().Length > 0 & _Cmb_Fpago.SelectedIndex>0)
                {
                    _Str_Cadena = "Update TPROSPECTO Set c_banco_neg=" + _Str_BancoNeg + ",c_banco_per=" + _Str_BancoPers + ",cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',c_banco_soc=" + _Str_BancoSoc + ",c_cuenta_neg='" + _Txt_Banco1.Text.Trim() + "',c_cuenta_per='" + _Txt_Banco2.Text.Trim() + "',c_cuenta_soc='" + _Txt_Banco3.Text.Trim() + "',c_numacciones='" + _Txt_AccionistaN_Datos.Text.Trim() + "',c_inf_replegal='" + _Txt_Representante_Datos.Text.Trim().ToUpper().Trim() + "',cfpago=" + _Str_FPago + ",c_balancegen='" + Convert.ToInt32(_Chbox_Balance.Checked).ToString() + "',c_estganyper='" + Convert.ToInt32(_Chbox_Estado.Checked).ToString() + "',c_regmercantil='" + Convert.ToInt32(_Chbox_Registro.Checked).ToString() + "',c_riffoto='" + Convert.ToInt32(_Chbox_Rif.Checked).ToString() + "',c_nitfoto='" + Convert.ToInt32(_Chbox_Nit.Checked).ToString() + "',c_cedfoto='" + Convert.ToInt32(_Chbox_CI.Checked).ToString() + "',c_otrosef='" + Convert.ToInt32(_Chbox_Otros.Checked).ToString() + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cclientep='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    //_Mtd_Ini();
                    MessageBox.Show("Los registros fueron actualizados correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Grb_Activacion.Enabled = false;
                    _Grb_Banco.Enabled = false;
                    _Grb_Documentos.Enabled = false;
                    _Bt_EditarCob.Enabled = true;
                    _Bt_GuardarCob.Enabled = false;
                }
                else
                {
                    if ((_Cmb_Banco1.SelectedIndex < 1 | _Txt_Banco1.Text.Trim().Length == 0) & (_Cmb_Banco2.SelectedIndex < 1 | _Txt_Banco2.Text.Trim().Length == 0) & (_Cmb_Banco3.SelectedIndex < 1 | _Txt_Banco3.Text.Trim().Length == 0))
                    {
                        if (_Cmb_Banco1.SelectedIndex < 1 | _Txt_Banco1.Text.Trim().Length == 0)
                        { _Er_Error.SetError(_Lbl_Neg, "Se necesita la información de uno de los bancos!!!"); }
                        if (_Cmb_Banco2.SelectedIndex < 1 | _Txt_Banco2.Text.Trim().Length == 0)
                        { _Er_Error.SetError(_Lbl_Per, "Se necesita la información de uno de los bancos!!!"); }
                        if (_Cmb_Banco3.SelectedIndex < 1 | _Txt_Banco3.Text.Trim().Length == 0)
                        { _Er_Error.SetError(_Lbl_Soc, "Se necesita la información de uno de los bancos!!!"); }
                    }
                    if (_Cmb_Fpago.SelectedIndex < 1)
                    { _Er_Error.SetError(_Cmb_Fpago, "Información requerida!!!"); }
                    if (_Txt_Representante_Datos.Text.Trim().Length == 0)
                    { _Er_Error.SetError(_Txt_Representante_Datos, "Información requerida!!!"); }
                    if (_Txt_AccionistaN_Datos.Text.Trim().Length == 0)
                    { _Er_Error.SetError(_Txt_AccionistaN_Datos, "Información requerida!!!"); }
                }
            }
            else
            {
                if ((_Bol_Rb_Activo != _Rb_Activo.Checked & _Rb_Activo.Checked & _Txt_Nota.Text.Trim().Length > 0) | (_Bol_Rb_InActivo != _Rb_Inactivo.Checked & _Rb_Inactivo.Checked & _Txt_Nota.Text.Trim().Length > 0))
                {
                    if (_Rb_Activo.Checked)
                    { _Str_Cadena = "Update TCLIENTE Set c_banco_neg=" + _Str_BancoNeg + ",c_banco_per=" + _Str_BancoPers + ",cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',c_banco_soc=" + _Str_BancoSoc + ",c_cuenta_neg='" + _Txt_Banco1.Text.Trim() + "',c_cuenta_per='" + _Txt_Banco2.Text.Trim() + "',c_cuenta_soc='" + _Txt_Banco3.Text.Trim() + "',c_numacciones='" + _Txt_AccionistaN_Datos.Text.Trim() + "',c_inf_replegal='" + _Txt_Representante_Datos.Text.Trim().ToUpper().Trim() + "',cfpago=" + _Str_FPago + ",c_balancegen='" + Convert.ToInt32(_Chbox_Balance.Checked).ToString() + "',c_estganyper='" + Convert.ToInt32(_Chbox_Estado.Checked).ToString() + "',c_regmercantil='" + Convert.ToInt32(_Chbox_Registro.Checked).ToString() + "',c_riffoto='" + Convert.ToInt32(_Chbox_Rif.Checked).ToString() + "',c_nitfoto='" + Convert.ToInt32(_Chbox_Nit.Checked).ToString() + "',c_cedfoto='" + Convert.ToInt32(_Chbox_CI.Checked).ToString() + "',c_otrosef='" + Convert.ToInt32(_Chbox_Otros.Checked).ToString() + "',c_activo='1',c_notasreactivacion='" + _Txt_Nota.Text.Trim().ToUpper().Trim() + "',c_fecha_reactivacion='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'"; }
                    else if (_Rb_Inactivo.Checked)
                    { _Str_Cadena = "Update TCLIENTE Set c_banco_neg=" + _Str_BancoNeg + ",c_banco_per=" + _Str_BancoPers + ",cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',c_banco_soc=" + _Str_BancoSoc + ",c_cuenta_neg='" + _Txt_Banco1.Text.Trim() + "',c_cuenta_per='" + _Txt_Banco2.Text.Trim() + "',c_cuenta_soc='" + _Txt_Banco3.Text.Trim() + "',c_numacciones='" + _Txt_AccionistaN_Datos.Text.Trim() + "',c_inf_replegal='" + _Txt_Representante_Datos.Text.Trim().ToUpper().Trim() + "',cfpago=" + _Str_FPago + ",c_balancegen='" + Convert.ToInt32(_Chbox_Balance.Checked).ToString() + "',c_estganyper='" + Convert.ToInt32(_Chbox_Estado.Checked).ToString() + "',c_regmercantil='" + Convert.ToInt32(_Chbox_Registro.Checked).ToString() + "',c_riffoto='" + Convert.ToInt32(_Chbox_Rif.Checked).ToString() + "',c_nitfoto='" + Convert.ToInt32(_Chbox_Nit.Checked).ToString() + "',c_cedfoto='" + Convert.ToInt32(_Chbox_CI.Checked).ToString() + "',c_otrosef='" + Convert.ToInt32(_Chbox_Otros.Checked).ToString() + "',c_activo='0',c_notasinactivo='" + _Txt_Nota.Text.Trim().ToUpper().Trim() + "',c_fecha_inactivo='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'"; }
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    //_Mtd_Ini();
                    MessageBox.Show("Los registros fueron actualizados correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Bol_Rb_Activo = _Rb_Activo.Checked;
                    _Bol_Rb_InActivo = _Rb_Inactivo.Checked;
                    _Grb_Activacion.Enabled = false;
                    _Grb_Banco.Enabled = false;
                    _Grb_Documentos.Enabled = false;
                    _Bt_EditarCob.Enabled = true;
                    _Bt_GuardarCob.Enabled = false;
                }
                else if ((_Bol_Rb_Activo != _Rb_Activo.Checked & _Rb_Activo.Checked & _Txt_Nota.Text.Trim().Length == 0) | (_Bol_Rb_InActivo != _Rb_Inactivo.Checked & _Rb_Inactivo.Checked & _Txt_Nota.Text.Trim().Length == 0))
                {
                    if (_Rb_Activo.Checked)
                    { MessageBox.Show("Debe agregar la nota para la reactivación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else if (_Rb_Inactivo.Checked)
                    { MessageBox.Show("Debe agregar la nota para la inactivación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
                else if (_Bol_Rb_Activo == _Rb_Activo.Checked & _Bol_Rb_InActivo == _Rb_Inactivo.Checked)
                {
                    _Str_Cadena = "Update TCLIENTE Set c_banco_neg=" + _Str_BancoNeg + ",c_banco_per=" + _Str_BancoPers + ",cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',c_banco_soc=" + _Str_BancoSoc + ",c_cuenta_neg='" + _Txt_Banco1.Text.Trim() + "',c_cuenta_per='" + _Txt_Banco2.Text.Trim() + "',c_cuenta_soc='" + _Txt_Banco3.Text.Trim() + "',c_numacciones='" + _Txt_AccionistaN_Datos.Text.Trim() + "',c_inf_replegal='" + _Txt_Representante_Datos.Text.Trim().ToUpper().Trim() + "',cfpago=" + _Str_FPago + ",c_notasreactivacion='" + _Txt_Nota.Text.Trim().ToUpper().Trim() + "',c_balancegen='" + Convert.ToInt32(_Chbox_Balance.Checked).ToString() + "',c_estganyper='" + Convert.ToInt32(_Chbox_Estado.Checked).ToString() + "',c_regmercantil='" + Convert.ToInt32(_Chbox_Registro.Checked).ToString() + "',c_riffoto='" + Convert.ToInt32(_Chbox_Rif.Checked).ToString() + "',c_nitfoto='" + Convert.ToInt32(_Chbox_Nit.Checked).ToString() + "',c_cedfoto='" + Convert.ToInt32(_Chbox_CI.Checked).ToString() + "',c_otrosef='" + Convert.ToInt32(_Chbox_Otros.Checked).ToString() + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    //_Mtd_Ini();
                    MessageBox.Show("Los registros fueron actualizados correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Grb_Activacion.Enabled = false;
                    _Grb_Banco.Enabled = false;
                    _Grb_Documentos.Enabled = false;
                    _Bt_EditarCob.Enabled = true;
                    _Bt_GuardarCob.Enabled = false;
                }
            }
            Cursor = Cursors.Default;
        }

        private void _Bt_Salir_Click(object sender, EventArgs e)
        {
            _Pnl_Direccion.Visible = false;
        }
        int _Int_AprobaroRechazar = 0;
        string _Str_Usuario= "";
        private void _Bt_Aprobar_Click(object sender, EventArgs e)
        {
            if (_Txt_Cliente.Text.Trim().Length > 0)
            {
                if (_Cmb_Limite_Credito.SelectedIndex == -1)
                { _Cmb_Limite_Credito.SelectedIndex = 0; }
                if (_Txt_AccionistaN_Datos.Text.Trim().Length == 0)
                { _Txt_AccionistaN_Datos.Text = "0"; }
                string _Str_Cadena = _Str_Cadena = "Select * from TRIESGOS where cclientep='" + _Txt_Cliente.Text.Trim() + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'"; 
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
                { MessageBox.Show("Es necesario realizar la evaluación de riesgo antes de aprobar al cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else
                {
                    if (((_Cmb_Banco1.SelectedIndex > 0 & _Txt_Banco1.Text.Trim().Length > 0) | (_Cmb_Banco2.SelectedIndex > 0 & _Txt_Banco2.Text.Trim().Length > 0) | (_Cmb_Banco3.SelectedIndex > 0 & _Txt_Banco3.Text.Trim().Length > 0)) & _Txt_AccionistaN_Datos.Text.Trim().Length > 0 & _Txt_Representante_Datos.Text.Trim().Length > 0 & _Cmb_Fpago.SelectedIndex > 0)
                    {
                        //if (_Str_Limine != _Cmb_Limite_Credito.SelectedValue.ToString().Trim())
                        //{
                        //    _Str_Cadena = "SELECT  TUSER.cuser,TUSER.cname " +
                        //    "FROM TLIMITCREDITOP INNER JOIN " +
                        //    "TUSER ON TLIMITCREDITOP.cuser = TUSER.cuser AND TLIMITCREDITOP.cdelete = TUSER.cdelete " +
                        //    "WHERE TLIMITCREDITOP.cdelete = '0' AND TLIMITCREDITOP.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' and TLIMITCREDITOP.ccodlimite='" + _Cmb_Limite_Credito.SelectedValue.ToString() + "' AND TLIMITCREDITOP.cuser='" + Frm_Padre._Str_Use + "' and TLIMITCREDITOP.ccompany='" + Frm_Padre._Str_Comp + "'";
                        //    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        //    if (_Ds.Tables[0].Rows.Count > 0)
                        //    {
                        //        _Pnl_Clave.Size = new Size(195, 111);
                        //        _Lbl_Motivo.Visible = false;
                        //        _Txt_Motivo.Visible = false;
                        //        _Str_Usuario = Frm_Padre._Str_Use;
                        //        _Int_AprobaroRechazar = 1; _Lbl_Clave.Text = "¿Esta seguro de aprobar el prospecto?"; _Pnl_Clave.Visible = true;

                        //    }
                        //    else
                        //    {
                        //        _Str_Cadena = "Select cuser from TLIMITCREDITOP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and ccodlimite='" + _Cmb_Limite_Credito.SelectedValue.ToString() + "'";
                        //        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        //        if (_Ds.Tables[0].Rows.Count > 0)
                        //        {
                        //            _Pnl_Clave.Size = new Size(195, 111);
                        //            _Lbl_Motivo.Visible = false;
                        //            _Txt_Motivo.Visible = false;
                        //            _Str_Usuario = _Ds.Tables[0].Rows[0][0].ToString();
                        //            _Int_AprobaroRechazar = 1; _Lbl_Clave.Text = "Ingrese el código del usuario " + _Ds.Tables[0].Rows[0][0].ToString(); _Pnl_Clave.Visible = true;
                        //        }
                        //        else
                        //        { MessageBox.Show("No existe usuario asignado para aprobar este límite de crédito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                        //    }
                        //}
                        //else
                        //{
                        //    _Pnl_Clave.Size = new Size(195, 111);
                        //    _Lbl_Motivo.Visible = false;
                        //    _Txt_Motivo.Visible = false;
                        //    _Str_Usuario = Frm_Padre._Str_Use;
                        //    _Int_AprobaroRechazar = 1; _Lbl_Clave.Text = "¿Esta seguro de aprobar el prospecto?"; _Pnl_Clave.Visible = true;

                        //}
                        if (_Cmb_Limite_Credito.SelectedIndex > 0)
                        {
                            _Str_Cadena = "SELECT  TUSER.cuser,TUSER.cname " +
                                                   "FROM TLIMITCREDITOP INNER JOIN " +
                                                   "TUSER ON TLIMITCREDITOP.cuser = TUSER.cuser AND TLIMITCREDITOP.cdelete = TUSER.cdelete " +
                                                   "WHERE TLIMITCREDITOP.cdelete = '0' AND TLIMITCREDITOP.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' and TLIMITCREDITOP.ccodlimite='" + _Cmb_Limite_Credito.SelectedValue.ToString() + "' AND TLIMITCREDITOP.cuser='" + Frm_Padre._Str_Use + "' and TLIMITCREDITOP.ccompany='" + Frm_Padre._Str_Comp + "'";
                            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                _Pnl_Clave.Parent = this;
                                _Pnl_Clave.Size = new Size(195, 111);
                                _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                                _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
                                _Lbl_Motivo.Visible = false;
                                _Txt_Motivo.Visible = false;
                                _Str_Usuario = Frm_Padre._Str_Use;
                                _Int_AprobaroRechazar = 1; _Lbl_Clave.Text = "¿Esta seguro de aprobar el prospecto?"; _Pnl_Clave.Visible = true;
                            }
                            else
                            {
                                _Str_Cadena = "Select cuser from TLIMITCREDITOP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and ccodlimite='" + _Cmb_Limite_Credito.SelectedValue.ToString() + "'";
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                                if (_Ds.Tables[0].Rows.Count > 0)
                                {
                                    _Pnl_Clave.Parent = this;
                                    _Pnl_Clave.Size = new Size(195, 111);
                                    _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                                    _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
                                    _Lbl_Motivo.Visible = false;
                                    _Txt_Motivo.Visible = false;
                                    _Str_Usuario = _Ds.Tables[0].Rows[0][0].ToString();
                                    _Int_AprobaroRechazar = 1; _Lbl_Clave.Text = "Ingrese el código del usuario " + _Ds.Tables[0].Rows[0][0].ToString(); _Pnl_Clave.Visible = true;
                                }
                                else
                                { MessageBox.Show("No existe usuario asignado para aprobar este límite de crédito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                            }
                        }
                        else
                        {
                            _Pnl_Clave.Parent = this;
                            _Pnl_Clave.Size = new Size(195, 111);
                            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
                            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
                            _Lbl_Motivo.Visible = false;
                            _Txt_Motivo.Visible = false;
                            _Str_Usuario = Frm_Padre._Str_Use;
                            _Int_AprobaroRechazar = 1; _Lbl_Clave.Text = "¿Esta seguro de aprobar el prospecto que no se le ha asignado ningún límite de crédito?"; _Pnl_Clave.Visible = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Es necesario agregar la información de cobranza antes de aprobar al cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Tb_Tab.SelectedIndex = 2;
                    }
                }
            }
            else
            { MessageBox.Show("Es necesario seleccionar un cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        /// <summary>
        /// Aprueba un Prospecto.
        /// </summary>
        private void _Mtd_Aprobar()
        {
            string _Str_CamposUpdate = "";
            string _Str_Codigo_Cliente = "";
            string _Str_Cadena = "Select MAX(ccliente)+1 from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
            int _Int_Cliente = new int();
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0] != System.DBNull.Value)
            { _Int_Cliente = Convert.ToInt32(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString()); }
            else
            { _Int_Cliente = 1; }
            _Str_Codigo_Cliente = _Int_Cliente.ToString();
            _Str_Cadena = "select c_rif,c_nomb_comer,c_razsocial_1,c_razsocial_2,c_direcc_fiscal,c_telefono,c_fax,c_email,c_www,c_clasifica,c_casa_matriz,c_atendidodirecto,c_nombredirecto,c_canal,c_estable,cbackorder,c_lun_visita,c_mar_visita,c_mie_visita,c_jue_visita,c_vie_visita,c_sab_visita,c_lun_despa,c_mar_despa,c_mie_despa,c_jue_despa,c_vie_despa,c_sab_despa,c_fechainicial,c_tipvisita,c_info_cont_1,c_info_cont_2,c_info_cont_3,c_estado,c_ciudad,c_municipio,c_parroquia,c_sector,c_carretera,c_calle,c_transversal,c_piso,c_local,c_pcardinal,c_urbanizacion,c_avenida,c_carrera,c_esquina,c_edificio,c_preferencia,c_limt_credit,c_capitalsolpag,c_capitalsolreg,c_notascob,cfechregmer,c_banco_neg,c_banco_per,c_banco_soc,c_cuenta_neg,c_cuenta_per,c_cuenta_soc,c_numacciones,c_inf_replegal,cfpago,c_balancegen,c_estganyper,c_regmercantil,c_riffoto,c_nitfoto,c_cedfoto,c_otrosef from TPROSPECTO where cclientep='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
            DataRow _Row;
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
            {
                _Str_CamposUpdate = "";
                _Row = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0];
                foreach (DataColumn _Col in Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Columns)
                {
                    if (_Row[_Col.ToString()].ToString().Trim().Length == 0)
                    {
                        if (_Col.DataType != typeof(System.DateTime))
                        {
                            _Str_CamposUpdate = _Str_CamposUpdate + _Col.ToString() + "='0',";

                            //_Str_Cadena = "Update TPROSPECTO set " + _Col.ToString() + "='0' where cclientep='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                            //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                    }
                }
                if (_Str_CamposUpdate.Length > 0)
                {
                    _Str_CamposUpdate = _Str_CamposUpdate.Substring(0, _Str_CamposUpdate.Length - 1);
                    _Str_Cadena = "Update TPROSPECTO set " + _Str_CamposUpdate + " where cclientep='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Row["c_rif"].ToString().Trim() + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                }
            }
            string _Str_Sql = "select * from TPROSPECTO where cclientep='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and c_aprobado='1'";
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count == 0)
            {
                _Str_Cadena = "Insert into TCLIENTE (cgroupcomp,ccliente,c_rif,c_nomb_comer,c_razsocial_1,c_razsocial_2,c_direcc_fiscal,c_telefono,c_fax,c_email,c_www,c_clasifica,c_casa_matriz,c_atendidodirecto,c_nombredirecto,c_canal,c_estable,cbackorder,c_lun_visita,c_mar_visita,c_mie_visita,c_jue_visita,c_vie_visita,c_sab_visita,c_lun_despa,c_mar_despa,c_mie_despa,c_jue_despa,c_vie_despa,c_sab_despa,c_fechainical,c_tipvisita,c_info_cont_1,c_info_cont_2,c_info_cont_3,c_estado,c_ciudad,c_municipio,c_parroquia,c_sector,c_carretera,c_calle,c_transversal,c_piso,c_local,c_pcardinal,c_urbanizacion,c_avenida,c_carrera,c_esquina,c_edificio,c_preferencia,c_limt_credit,c_capitalsolpag,c_capitalsolreg,c_notascob,cfechregmer,c_banco_neg,c_banco_per,c_banco_soc,c_cuenta_neg,c_cuenta_per,c_cuenta_soc,c_numacciones,c_inf_replegal,cfpago,c_balancegen,c_estganyper,c_regmercantil,c_riffoto,c_nitfoto,c_cedfoto,c_otrosef,c_tip_contribuy,cclientep) select cgroupcomp,'" + _Int_Cliente.ToString() + "',c_rif,c_nomb_comer,c_razsocial_1,c_razsocial_2,c_direcc_fiscal,c_telefono,c_fax,c_email,c_www,c_clasifica,c_casa_matriz,c_atendidodirecto,c_nombredirecto,c_canal,c_estable,cbackorder,c_lun_visita,c_mar_visita,c_mie_visita,c_jue_visita,c_vie_visita,c_sab_visita,c_lun_despa,c_mar_despa,c_mie_despa,c_jue_despa,c_vie_despa,c_sab_despa,c_fechainicial,c_tipvisita,c_info_cont_1,c_info_cont_2,c_info_cont_3,c_estado,c_ciudad,c_municipio,c_parroquia,c_sector,c_carretera,c_calle,c_transversal,c_piso,c_local,c_pcardinal,c_urbanizacion,c_avenida,c_carrera,c_esquina,c_edificio,c_preferencia,c_limt_credit,c_capitalsolpag,c_capitalsolreg,c_notascob,cfechregmer,c_banco_neg,c_banco_per,c_banco_soc,c_cuenta_neg,c_cuenta_per,c_cuenta_soc,c_numacciones,c_inf_replegal,cfpago,c_balancegen,c_estganyper,c_regmercantil,c_riffoto,c_nitfoto,c_cedfoto,c_otrosef,c_tip_contribuy,cclientep from TPROSPECTO where cclientep='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                //_Str_Cadena = "Insert into TCLIENTE (c_lun_visita,c_mar_visita,c_mie_visita,c_jue_visita,c_vie_visita,c_sab_visita,c_lun_despa,c_mar_despa,c_mie_despa,c_jue_despa,c_vie_despa,c_sab_despa,c_fechainicial,c_tipvisita) select c_lun_visita,c_mar_visita,c_mie_visita,c_jue_visita,c_vie_visita,c_sab_visita,c_lun_despa,c_mar_despa,c_mie_despa,c_jue_despa,c_vie_despa,c_sab_despa,c_fechainicial,c_tipvisita from TPROSPECTO where cclientep='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'";
                //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                //_Str_Cadena = "Insert into TCLIENTE (c_info_cont_1,c_info_cont_2,c_info_cont_3) select c_info_cont_1,c_info_cont_2,c_info_cont_3 from TPROSPECTO where cclientep='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'";
                //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                //_Str_Cadena = "Insert into TCLIENTE (c_estado,c_ciudad,c_municipio,c_parroquia,c_sector,c_carretera,c_calle,c_transversal,c_piso,c_local,c_pcardinal,c_urbanizacion,c_avenida,c_carrera,c_esquina,c_edificio,c_preferencia) select c_estado,c_ciudad,c_municipio,c_parroquia,c_sector,c_carretera,c_calle,c_transversal,c_piso,c_local,c_pcardinal,c_urbanizacion,c_avenida,c_carrera,c_esquina,c_edificio,c_preferencia from TPROSPECTO where cclientep='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'";
                //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                //_Str_Cadena = "Insert into TCLIENTE (c_limt_credit,c_capitalsolpag,c_capitalsolreg,c_notascob,cfechregmer) select c_limt_credit,c_capitalsolpag,c_capitalsolreg,c_notascob,cfechregmer from TPROSPECTO where cclientep='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'";
                //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                //_Str_Cadena = "Insert into TCLIENTE (c_banco_neg,c_banco_per,c_banco_soc,c_cuenta_neg,c_cuenta_per,c_cuenta_soc,c_numacciones,c_razsocial_2,c_capitalsolpag,c_capitalsolreg,c_inf_replegal,cfpago,c_balancegen,c_estganyper,c_regmercantil,c_riffoto,c_nitfoto,c_cedfoto,c_otrosef) select c_banco_neg,c_banco_per,c_banco_soc,c_cuenta_neg,c_cuenta_per,c_cuenta_soc,c_numacciones,c_razsocial_2,c_capitalsolpag,c_capitalsolreg,c_inf_replegal,cfpago,c_balancegen,c_estganyper,c_regmercantil,c_riffoto,c_nitfoto,c_cedfoto,c_otrosef from TPROSPECTO where cclientep='" + _Txt_Cliente.Text.Trim() + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'";
                //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "Update TPROSPECTO set c_solicitud='0',c_aprobado='1' where cclientep='" + _Txt_Cliente.Text.Trim() + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "Update TREFCOMER set ccliente='" + _Int_Cliente.ToString() + "' where cclientep='" + _Txt_Cliente.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "Update TRIESGOS set ccliente='" + _Int_Cliente.ToString() + "' where cclientep='" + _Txt_Cliente.Text.Trim() + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "Update TENCUESTA set ccliente='" + _Int_Cliente.ToString() + "' where cclientep='" + _Txt_Cliente.Text.Trim() + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "Insert into TDDESPACHOC (cgroupcomp,ccliente,c_direcc_despa,c_direcc_descrip) Select cgroupcomp,'" + _Int_Cliente.ToString() + "',c_direcc_despa,c_direcc_descrip from TDDESPACHOP where ccliente='" + _Txt_Cliente.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "UPDATE TATENDIRECTO SET ccliente='" + _Int_Cliente.ToString() + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cclientep='" + _Txt_Cliente.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                MessageBox.Show("El cliente ha sido aprobado con el código " + _Str_Codigo_Cliente, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El cliente ha sido aprobado por otro usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Rechaza un Prospecto
        /// </summary>
        private void _Mtd_Rechazar()
        {
            string _Str_Cadena = "Update TPROSPECTO set c_rechazo='1' , c_solicitud='0' where cclientep='" + _Txt_Cliente.Text.Trim() + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private void _Bt_Rechazar_Click(object sender, EventArgs e)
        {
            if (_Txt_Cliente.Text.Trim().Length > 0)
            {
                string _Str_Cadena = _Str_Cadena = "Select * from TRIESGOS where cclientep='" + _Txt_Cliente.Text.Trim() + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and c_rif='" + _Txt_Rif.Text.Trim() + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0)
                { MessageBox.Show("Es necesario realizar la evaluación de riesgo antes de rechazar al cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else
                {
                    _Pnl_Clave.Size = new Size(217,166);
                    _Txt_Motivo.Visible = true;
                    _Lbl_Motivo.Visible = true;
                    _Txt_Motivo.Text = "";
                    _Str_Usuario = Frm_Padre._Str_Use;
                    _Int_AprobaroRechazar = 2; _Lbl_Clave.Text = "¿Esta seguro de rechazar el cliente?"; _Pnl_Clave.Visible = true; 
                }
            }
            else
            { MessageBox.Show("Es necesario seleccionar un cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }

        private void _Bt_Aceptar_Clave_Click(object sender, EventArgs e)
        {
            _Mtd_Aceptar_Clave(_Str_Usuario);
        }
    
        private void _Mtd_Aceptar_Clave(string _Str_User)
        {
            byte[] hash = _Mtd_ConvertStringToByteArray(_Txt_Clave2.Text);
            byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
            string cod = BitConverter.ToString(valorhash);
            cod = cod.Replace("-", "");
            try
            {

                string _Str_Cadena = "SELECT   cpassw  FROM TUSER WHERE cuser= '" + _Str_User + "' and cpassw= '" + cod.ToString() + "'";
                System.Data.DataSet Ds22 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (Ds22.Tables[0].Rows.Count > 0)
                {
                    if (_Int_AprobaroRechazar == 1)
                    {
                        _Mtd_Aprobar();
                        _Mtd_Actualizar_Prospecto();
                        _Pnl_Clave.Visible = false;
                        _Txt_Clave2.Text = "";
                        _Int_AprobaroRechazar = 0;
                        _Mtd_Ini();
                        _Tb_Tab.SelectedIndex = 0;
                    }
                    else if (_Int_AprobaroRechazar == 2)
                    {
                        if (_Txt_Motivo.Text.Trim().Length > 0)
                        {
                            _Mtd_Rechazar();
                            MessageBox.Show("El Prospecto ha sido rechazado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Mtd_Actualizar_Prospecto();
                            _Pnl_Clave.Visible = false;
                            _Txt_Clave2.Text = "";
                            _Int_AprobaroRechazar = 0;
                            _Mtd_Ini();
                            _Tb_Tab.SelectedIndex = 0;
                        }
                        else
                        {
                            MessageBox.Show("Debe agregar el motivo del rechazo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave2.Focus(); _Txt_Clave2.Select(0, _Txt_Clave2.Text.Length); }
            }
            catch { }
        }
        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Tb_Tab.Enabled = false;
                _Txt_Cliente_Arriba.Enabled = false;
                _Txt_Des_Cliente_Arriba.Enabled = false;
                _Txt_Rif_Cliente_Arriba.Enabled = false;
                _Txt_Clave2.Focus();
            }
            else
            {
                _Tb_Tab.Enabled = true;
                _Txt_Cliente_Arriba.Enabled = true;
                _Txt_Des_Cliente_Arriba.Enabled = true;
                _Txt_Rif_Cliente_Arriba.Enabled = true;
            }
        }

        private void _Bt_Cancelar_Clave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
            _Txt_Clave2.Text = "";
            _Int_AprobaroRechazar = 0;
        }
        int _Int_Referencia = 1;
        private void _Bt_Anterior_Click(object sender, EventArgs e)
        {
            if (_Int_Referencia > 1)
            {
                _Mtd_Inicializar_Pnl_Ref();
                _Int_Referencia -= 1;
                _Mtd_Igualar_Referencia(_Int_Referencia);
                if (_Int_Referencia == 1)
                {
                    _Pnl_Ref1.BackColor = Color.Khaki;
                    _Pnl_Ref2.BackColor = this.BackColor;
                    _Pnl_Ref3.BackColor = this.BackColor;
                    _Txt_Referencia1.Enabled = true;
                    _Txt_Referencia2.Enabled = false;
                    _Txt_Referencia3.Enabled = false;
                }
                else if (_Int_Referencia == 2)
                {
                    _Pnl_Ref1.BackColor = this.BackColor;
                    _Pnl_Ref2.BackColor = Color.Khaki;
                    _Pnl_Ref3.BackColor = this.BackColor;
                    _Txt_Referencia1.Enabled = false;
                    _Txt_Referencia2.Enabled = true;
                    _Txt_Referencia3.Enabled = false;
                }
            }
        }

        private void _Bt_Siguiente_Click(object sender, EventArgs e)
        {
            if (_Int_Referencia < 3)
            {
                _Mtd_Inicializar_Pnl_Ref();
                _Int_Referencia += 1;
                _Mtd_Igualar_Referencia(_Int_Referencia);
                if (_Int_Referencia == 2)
                {
                    _Pnl_Ref1.BackColor = this.BackColor;
                    _Pnl_Ref2.BackColor = Color.Khaki;
                    _Pnl_Ref3.BackColor = this.BackColor;
                    _Txt_Referencia1.Enabled = false;
                    _Txt_Referencia2.Enabled = true;
                    _Txt_Referencia3.Enabled = false;
                }
                else if (_Int_Referencia == 3)
                {
                    _Pnl_Ref1.BackColor = this.BackColor;
                    _Pnl_Ref2.BackColor = this.BackColor;
                    _Pnl_Ref3.BackColor = Color.Khaki;
                    _Txt_Referencia1.Enabled = false;
                    _Txt_Referencia2.Enabled = false;
                    _Txt_Referencia3.Enabled = true;
                }
            }
        }

        private void _Txt_Banco1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Banco2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Banco3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_AccionistaN_Datos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Monto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Capital_Pagado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Capital_Registrado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Banco1_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Banco1.Text))
            {
                _Txt_Banco1.Text = "";
            }
        }

        private void _Txt_Banco2_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Banco2.Text))
            {
                _Txt_Banco2.Text = "";
            }
        }

        private void _Txt_Banco3_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Banco3.Text))
            {
                _Txt_Banco3.Text = "";
            }
        }

        private void _Txt_AccionistaN_Datos_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_AccionistaN_Datos.Text))
            {
                _Txt_AccionistaN_Datos.Text = "";
            }
        }

        private void _Txt_Monto_TextChanged(object sender, EventArgs e)
        {
            string _Str_Cadena = "";
            try
            { 
                _Str_Cadena = CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Monto.Text.Trim()));
                if (!_Mtd_IsNumeric(_Str_Cadena))
                {
                    _Txt_Monto.Text = "";
                }
            }
            catch { _Txt_Monto.Text = ""; }
            if (_Txt_Monto.Text.Trim().Length > 11 & _Txt_Monto.Text.Trim().IndexOf(",") == -1 & _Txt_Monto.Text.Trim().IndexOf(".") == -1)
            { _Txt_Monto.Text = _Txt_Monto.Text.Trim().Substring(0, _Txt_Monto.Text.Trim().Length - 1); _Txt_Monto.Select(0, _Txt_Monto.Text.Length); }
        }

        private void _Txt_Capital_Pagado_TextChanged(object sender, EventArgs e)
        {
            string _Str_Cadena = "";
            try
            {
                _Str_Cadena = CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Capital_Pagado.Text.Trim()));
                if (!_Mtd_IsNumeric(_Str_Cadena))
                {
                    _Txt_Capital_Pagado.Text = "";
                }
            }
            catch { _Txt_Capital_Pagado.Text = ""; }
            if (_Txt_Capital_Pagado.Text.Trim().Length > 11 & _Txt_Capital_Pagado.Text.Trim().IndexOf(",") == -1 & _Txt_Capital_Pagado.Text.Trim().IndexOf(".") == -1)
            { _Txt_Capital_Pagado.Text = _Txt_Capital_Pagado.Text.Trim().Substring(0, _Txt_Capital_Pagado.Text.Trim().Length - 1); _Txt_Capital_Pagado.Select(0, _Txt_Capital_Pagado.Text.Length); }

        }

        private void _Txt_Capital_Registrado_TextChanged(object sender, EventArgs e)
        {
            string _Str_Cadena = "";
            try
            {
                _Str_Cadena = CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Capital_Registrado.Text.Trim()));
                if (!_Mtd_IsNumeric(_Str_Cadena))
                {
                    _Txt_Capital_Registrado.Text = "";
                }
            }
            catch { _Txt_Capital_Registrado.Text = ""; }
            if (_Txt_Capital_Registrado.Text.Trim().Length > 11 & _Txt_Capital_Registrado.Text.Trim().IndexOf(",") == -1 & _Txt_Capital_Registrado.Text.Trim().IndexOf(".") == -1)
            { _Txt_Capital_Registrado.Text = _Txt_Capital_Registrado.Text.Trim().Substring(0, _Txt_Capital_Registrado.Text.Trim().Length - 1); _Txt_Capital_Registrado.Select(0, _Txt_Capital_Registrado.Text.Length); }

        }

        private void _Bt_Editar_Direccion_Click(object sender, EventArgs e)
        {
            _Bt_Aceptar_direc.Enabled = true;
            _Bt_Editar_Direccion.Enabled = false;
            _Mtd_Enabled_Controles(_Pnl_Direccion, true);
        }
        private void _Txt_Credito_TextChanged(object sender, EventArgs e)
        {
            string _Str_Cadena = "";
            try
            {
                _Str_Cadena = CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Credito.Text.Trim()));
                if (!_Mtd_IsNumeric(_Str_Cadena))
                {
                    _Txt_Credito.Text = "";
                }
            }
            catch { _Txt_Credito.Text = ""; }
            if (_Txt_Credito.Text.Trim().Length > 11 & _Txt_Credito.Text.Trim().IndexOf(",") == -1 & _Txt_Credito.Text.Trim().IndexOf(".") == -1)
            { _Txt_Credito.Text = _Txt_Credito.Text.Trim().Substring(0, _Txt_Credito.Text.Trim().Length - 1); _Txt_Credito.Select(0, _Txt_Credito.Text.Length); }

        }

        private void _Txt_Credito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Clave2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                _Bt_Aceptar_Clave.Focus();
            }
        }

        private void _Bt_Aceptar_Clave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                _Mtd_Aceptar_Clave(_Str_Usuario);
            }
        }

        private void _Txt_Monto_Leave(object sender, EventArgs e)
        {
            try 
            {
                string _Str_Cadena = "Select dbo.Fnc_Formatear("+CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Monto.Text.Trim()))+")";
                _Txt_Monto.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString();
            }
            catch { }
        }

        private void _Txt_Capital_Pagado_Leave(object sender, EventArgs e)
        {
            try
            {
                string _Str_Cadena = "Select dbo.Fnc_Formatear(" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Capital_Pagado.Text.Trim())) + ")";
                _Txt_Capital_Pagado.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString();
            }
            catch { }
        }

        private void _Txt_Capital_Registrado_Leave(object sender, EventArgs e)
        {
            try
            {
                string _Str_Cadena = "Select dbo.Fnc_Formatear(" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Capital_Registrado.Text.Trim())) + ")";
                _Txt_Capital_Registrado.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString();
            }
            catch { }
        }

        private void _Txt_Credito_Leave(object sender, EventArgs e)
        {
            try
            {
                string _Str_Cadena = "Select dbo.Fnc_Formatear(" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Credito.Text.Trim())) + ")";
                _Txt_Credito.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString();
            }
            catch { }
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

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Muestra los registros en los controles
            _Mtd_Ini();
            if (_Dg_Grid.Rows.Count > 0)
            {
                if (_Bol_Cliente)
                {
                    _Mtd_Cargar_Cliente(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString());
                    _Mtd_Cargar_Calendario(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString());
                    _Mtd_Cargar_Contactos(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString());
                    //_Mtd_Cargar_Encuesta(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Pnl_Encuesta);
                    _Mtd_Cargar_Direccion(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString());
                    _Mtd_Cargar_Promedio_Referencia(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    _Mtd_Cargar_Promedio_Compras(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString());
                    _Mtd_Cargar_Datos_Generales(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString());
                    _Mtd_Cargar_Clientes_Concurrentes(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString());
                    _Mtd_Cargar_Fecha_Registro(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString());
                    _Mtd_Cargar_Inf_Cobranza(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString());
                    if (!_Bol_Ventas)//Esta condición es para que no se realice la evaluación si es el usuario de ventas el que esta entrando. Esto es porque cuando se remueve el tabpage3 los combos parecen perder la data.
                    { _Mtd_Evaluar_Riesgo(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString(), true); }
                    _Mtd_Cargar_Activacion(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString());
                    _Bol_Rb_Activo = _Rb_Activo.Checked;
                    _Bol_Rb_InActivo = _Rb_Inactivo.Checked;
                }
                else
                {
                    _Mtd_Cargar_Cliente_Prospesto(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString());
                    _Mtd_Cargar_Calendario_Prospecto(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString());
                    _Mtd_Cargar_Contactos_Prospecto(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString());
                    //_Mtd_Cargar_Encuesta_Prospecto(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Pnl_Encuesta);
                    _Mtd_Cargar_Direccion_Prospecto(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString());
                    _Mtd_Cargar_Promedio_Referencia_Prospecto(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    _Mtd_Cargar_Promedio_Compras_Prospecto(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString());
                    _Mtd_Cargar_Datos_Generales_Prospecto(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString());
                    _Mtd_Cargar_Fecha_Registro_Prospecto(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString());
                    _Mtd_Cargar_Inf_Cobranza_Prospecto(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString());
                    _Mtd_Evaluar_Riesgo(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString(), _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString(), false);
                    _Bt_Aprobar.Enabled = true; _Bt_Rechazar.Enabled = true;
                    _Rb_PorActivar.Checked = true;
                }
                _Tb_Tab.SelectedIndex = 1;
            }
        }

    }
}