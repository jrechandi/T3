using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Prospectos : Form
    {
        public Frm_Prospectos()
        {
            InitializeComponent();
            _Mtd_Actualizar();
            _Mtd_Ini();
        }
        public void _Mtd_Ini()
        {
            _Mtd_Ini_DatosMain();
            _Mtd_Ini_Tab_Detalle(_Tb_Detalle.TabPages[0]);
            _Mtd_Ini_Tab_Detalle(_Tb_Detalle.TabPages[1]);
            _Mtd_Bloquear(false);
            _Mtd_Cargar_Contribuyente();
            _Mtd_Cargar_Estado();
            _Mtd_Cargar_PtoCardinal();
            _Mtd_Cargar_Canal();
            _Mtd_Cargar_Clasificacion();
            _Mtd_Cargar_LimiteCredito();
            _G_Str_MyProceso = "";
        }
        CLASES._Cls_Varios_Metodos _G_MyUtilidad = new T3.CLASES._Cls_Varios_Metodos(true);
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
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_Parroquia, "Select RTRIM(cparroquia),cname from TPARROQUIA where cdelete='0' and cmunicipio='" + _P_Str_Municipio + "' and cestate='" + _Cmb_Estado.SelectedValue + "' ORDER BY cname ASC");
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
        private void _Mtd_Cargar_Canal()
        {
            _Cmb_TipoCanal.SelectedIndexChanged -= new EventHandler(_Cmb_TipoCanal_SelectedIndexChanged);
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_TipoCanal, "Select rtrim(ccanal),cname from TTCANAL where cdelete='0' ORDER BY cname ASC");
            _Cmb_TipoCanal.SelectedIndexChanged += new EventHandler(_Cmb_TipoCanal_SelectedIndexChanged);
        }
        private void _Mtd_Cargar_Establecimiento(string _P_Str_Canal)
        {
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_Establecimiento, "Select RTRIM(ctestablecim),rtrim(cname) as cname from TTESTABLECIM where cdelete='0' and ccanal='" + _P_Str_Canal + "' ORDER BY cname ASC");
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
        private void _Mtd_Actualizar()
        {
            //string _Str_FindSql = "Select top ?sel c_rif,cclientep, RTRIM(ccliente_nombcomer) AS ccliente_nombcomer,RTRIM(c_direcc_fiscal) as c_direcc_fiscal,RTRIM(c_estado_name) as c_estado_name,RTRIM(c_ciudad_name) as c_ciudad_name, cfecha FROM VST_PROSPECTOCONSULT WHERE NOT cclientep IN (select top ?omi cclientep from VST_PROSPECTOCONSULT WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "')) AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cdelete=0";
            string _Str_FindSql = "Select top ?sel c_rif,cclientep, RTRIM(ccliente_nombcomer) AS ccliente_nombcomer,RTRIM(c_direcc_fiscal) as c_direcc_fiscal,RTRIM(c_estado_name) as c_estado_name,RTRIM(c_ciudad_name) as c_ciudad_name, cfecha, cuser + ' - ' + cname as c_ingresado_por FROM VST_PROSPECTOCONSULT WHERE NOT cclientep IN (select top ?omi cclientep from VST_PROSPECTOCONSULT WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "')) AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cdelete=0";
            if (_Rb_Pend.Checked)
            { _Str_FindSql += " AND c_solicitud = '1' AND ISNULL(c_rechazo,0)='0'"; }
            else
            { _Str_FindSql += " AND c_solicitud = '0' AND ISNULL(c_rechazo,0)='1'"; }
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Rif");
            _Tsm_Menu[1] = new ToolStripMenuItem("Código");
            _Tsm_Menu[2] = new ToolStripMenuItem("Cliente");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "c_rif";
            _Str_Campos[1] = "cclientep";
            _Str_Campos[2] = "ccliente_nombcomer";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_Campos, "Clientes Prospectos", _Tsm_Menu, _Dg_Consulta, "TPROSPECTO", "WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND cdelete=0 and c_solicitud='1'", 100, "ORDER BY cclientep");
            //_Dg_Grid.Columns[3].Visible = false;
            _Dg_Consulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //___________________________________            
        }

        private void _Dg_Consulta_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
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
        private void _Mtd_Bloquear(bool _Pr_Bol_A)
        {
            _Mtd_Bloquear_DatosMain(_Pr_Bol_A);
            _Mtd_Bloquear_Tab_Detalle(_Tb_Detalle.TabPages[0], _Pr_Bol_A);
            _Mtd_Bloquear_Tab_Detalle(_Tb_Detalle.TabPages[1], _Pr_Bol_A);
            _Mtd_Bloquear_Tab_Detalle(_Tb_Detalle.TabPages[2], _Pr_Bol_A);
        }
        string _G_Str_MyProceso = "";
        public void _Mtd_BotonesMenu()
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
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = !_Pnl_Clave.Visible;
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
        private void _Mtd_CargarDirecciones(string _P_Str_Cliente)
        {
            string _Str_SentenciaSQL = "select c_direcc_despa,rtrim(c_direcc_descrip) from TDDESPACHOP where ccliente='" + _P_Str_Cliente + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' order by c_direcc_despa";
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
                    _Cmb_DireccionDespacho.DataSource = null;
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
            _Er_Error.Dispose();
            _Mtd_Ini_DatosMain();
            _Mtd_Bloquear(false);
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from TPROSPECTO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cclientep='" + _Pr_Str_Id + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Cod.Text = _Pr_Str_Id;
                _Txt_Rif.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_rif"]).Trim();
                if (_Ds.Tables[0].Rows[0]["c_fechainicial"].ToString() != "")
                {
                    _Txt_Fecha.Text = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["c_fechainicial"]).ToShortDateString();
                }
                _Txt_NombreComercial.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_nomb_comer"]).Trim().ToUpper();
                _Txt_RazonSocialEmpresa.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_razsocial_1"]).Trim().ToUpper();
                _Txt_RazonSocialAccionista.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_razsocial_2"]).Trim().ToUpper();
                _Txt_DireccionFiscal.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_direcc_fiscal"]).Trim().ToUpper();
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
                _Txt_CodSunagro.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ccodsunagro"]).Trim().ToUpper();
                
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
                _Cmb_LimiteCredito.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["c_limt_credit"]).Trim().ToUpper();
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
                _Txt_RepLegal.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_inf_replegal"]).Trim().ToUpper();
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_clientsigesod"]).Trim().ToUpper() != "")
                {
                    _Txt_CodSigeco.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_clientsigesod"]).Trim().ToUpper();
                }
                else
                {
                    _Txt_CodSigeco.Text = "0";
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["c_clientsigemog"]).Trim().ToUpper() != "")
                {
                    _Txt_CodMogosa.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["c_clientsigemog"]).Trim().ToUpper();
                }
                else
                {
                    _Txt_CodMogosa.Text = "0";
                }
                _Mtd_BotonesMenu();
                _Mtd_CargarDirecciones(_Pr_Str_Id);
                _Tb_Tab.SelectedIndex = 1;
                _Tb_Detalle.SelectedIndex = 0;
                _Bt_AprobarCliente.Enabled = _Rb_Pend.Checked;
                _Bt_RechazarCliente.Enabled = _Rb_Pend.Checked;
            }
        }
        public void _Mtd_Cancelar()
        {
            _Mtd_Bloquear(false);
            _Pnl_Clave.Visible = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
        }
        private void _Bt_Seniat_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                string _Str_Rif = _Txt_Rif.Text.Replace("-", "");
                string _Str_Url = CLASES._Cls_Varios_Metodos._Str_Servidor_Web + "/este.aspx?este=" + _Str_Rif.Replace("-", "");
                Frm_Navegador _Frm = new Frm_Navegador(_Str_Url, false);
                //_Frm.MdiParent = this.MdiParent;
                //_Frm.Dock = DockStyle.Fill;
                _Frm.ShowDialog();
            }
            catch { }
            Cursor = Cursors.Default;
        }

        private void _Bt_DireccionDespa_Click(object sender, EventArgs e)
        {
            Frm_Prospectos_VC_DireccionD _Frm_Form = new Frm_Prospectos_VC_DireccionD(_Txt_Cod.Text);
            _Frm_Form.ShowDialog();
            _Mtd_CargarDirecciones(_Txt_Cod.Text);
        }

        private void _Cmb_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Estado.SelectedValue != null)
            {
                _Mtd_Cargar_Ciudad(_Cmb_Estado.SelectedValue.ToString());
                _Mtd_Cargar_Municipio(_Cmb_Estado.SelectedValue.ToString());
            }
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

        private void _Cmb_Municipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Municipio.SelectedValue != null && _Cmb_Estado.SelectedValue != null)
            {
                _Mtd_Cargar_Parroquia(_Cmb_Municipio.SelectedValue.ToString(), _Cmb_Estado.SelectedValue.ToString());
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
            if (_Cmb_Estado.SelectedValue != null && _Cmb_Municipio.SelectedValue != null)
            {
                _Mtd_Cargar_Parroquia(_Cmb_Municipio.SelectedValue.ToString(), _Cmb_Estado.SelectedValue.ToString());
            }
        }

        private void _Cmb_PuntoCardinal_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_PtoCardinal();
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
        private void _Cmb_Clasificacion_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Clasificacion();
        }

        private void _Cmb_TipoContribuyente_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Contribuyente();
        }

        private void _Cmb_TipoCanal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_TipoCanal.SelectedValue != null)
            {
                _Mtd_Cargar_Establecimiento(_Cmb_TipoCanal.SelectedValue.ToString());
            }
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
        public void _Mtd_Habilitar()
        {
            _Mtd_Bloquear(true);
            _Cmb_DireccionDespacho.Enabled = false;
            _Cmb_LimiteCredito.Enabled = _G_MyUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _G_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_EDIT_LIMIT_CREDIT");
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            _Txt_Rif.Enabled = false;
            _Txt_Cod.Enabled = false;
            _Txt_Fecha.Enabled = false;
            _G_Str_MyProceso = "M";
        }
        private void Frm_Prospectos_Activated(object sender, EventArgs e)
        {
            _Mtd_BotonesMenu();
        }

        private void Frm_Prospectos_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Bt_RechazarCliente_Click(object sender, EventArgs e)
        {
            if (!(_G_MyUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _G_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_APROB_PROSPECTO")))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta operación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("¿Está seguro de rechazar el cliente seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                _Int_Sw = 2;
                _Pnl_Clave.Visible = true;
                ((Frm_Padre)Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            }
        }
        private void _Mtd_CrearCliente(string _Pr_Str_GroupComp, string _Str_Cliente)
        {
            DataRow _Row;
            DataSet _Ds;
            string _Str_Cadena = "";
            int _Int_Cliente = 0;
            string _Str_Sql = "select * from TPROSPECTO where cgroupcomp='" + _Pr_Str_GroupComp + "' and c_aprobado IS NULL and cdelete='0' and cclientep='" + _Str_Cliente + "' OR c_aprobado='0' AND cdelete=0 and cclientep='" + _Str_Cliente + "' and cgroupcomp='" + _Pr_Str_GroupComp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _Drow in _Ds.Tables[0].Rows)
            {
                _Str_Cadena = "Select MAX(ccliente)+1 from TCLIENTE where cgroupcomp='" + _Pr_Str_GroupComp + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0] != System.DBNull.Value)
                { _Int_Cliente = Convert.ToInt32(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString()); }
                else
                { _Int_Cliente = 1; }

                _Str_Cadena = "Insert into TCLIENTE (cgroupcomp,ccliente,c_rif,c_nit,c_nomb_comer,c_razsocial_1,c_razsocial_2,c_direcc_fiscal,c_telefono,c_fax,c_email,c_www,c_clasifica,c_casa_matriz,c_atendidodirecto,c_nombredirecto,c_canal,c_estable,cbackorder,c_lun_visita,c_mar_visita,c_mie_visita,c_jue_visita,c_vie_visita,c_sab_visita,c_lun_despa,c_mar_despa,c_mie_despa,c_jue_despa,c_vie_despa,c_sab_despa,c_fechainical,c_tipvisita,c_info_cont_1,c_info_cont_2,c_info_cont_3,c_estado,c_ciudad,c_municipio,c_parroquia,c_sector,c_carretera,c_calle,c_transversal,c_piso,c_local,c_pcardinal,c_urbanizacion,c_avenida,c_carrera,c_esquina,c_edificio,c_preferencia,c_limt_credit,c_capitalsolpag,c_capitalsolreg,c_notascob,cfechregmer,c_banco_neg,c_banco_per,c_banco_soc,c_cuenta_neg,c_cuenta_per,c_cuenta_soc,c_numacciones,c_inf_replegal,cfpago,c_balancegen,c_estganyper,c_regmercantil,c_riffoto,c_nitfoto,c_cedfoto,c_otrosef,c_tip_contribuy,cclientep,c_clientesigesod,c_clientesigemog,c_fech_inicio,cdateadd) select cgroupcomp,'" + _Int_Cliente.ToString() + "',c_rif,c_nit,c_nomb_comer,c_razsocial_1,c_razsocial_2,c_direcc_fiscal,c_telefono,c_fax,c_email,c_www,c_clasifica,c_casa_matriz,c_atendidodirecto,c_nombredirecto,c_canal,c_estable,cbackorder,c_lun_visita,c_mar_visita,c_mie_visita,c_jue_visita,c_vie_visita,c_sab_visita,c_lun_despa,c_mar_despa,c_mie_despa,c_jue_despa,c_vie_despa,c_sab_despa,getdate(),c_tipvisita,c_info_cont_1,c_info_cont_2,c_info_cont_3,c_estado,c_ciudad,c_municipio,c_parroquia,c_sector,c_carretera,c_calle,c_transversal,c_piso,c_local,c_pcardinal,c_urbanizacion,c_avenida,c_carrera,c_esquina,c_edificio,c_preferencia,'" + _Cmb_LimiteCredito.SelectedValue.ToString() + "',c_capitalsolpag,c_capitalsolreg,c_notascob,cfechregmer,c_banco_neg,c_banco_per,c_banco_soc,c_cuenta_neg,c_cuenta_per,c_cuenta_soc,c_numacciones,c_inf_replegal,cfpago,c_balancegen,c_estganyper,c_regmercantil,c_riffoto,c_nitfoto,c_cedfoto,c_otrosef,c_tip_contribuy,cclientep,c_clientsigesod,c_clientsigemog,getdate(),getdate() from TPROSPECTO where cclientep='" + _Drow["cclientep"].ToString().Trim() + "' and c_rif='" + _Drow["c_rif"].ToString().Trim() + "' and cgroupcomp='" + _Pr_Str_GroupComp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "Update TPROSPECTO set c_solicitud='0',c_aprobado='1',C_RECHAZO='0' where cclientep='" + _Drow["cclientep"].ToString().Trim() + "' and cgroupcomp='" + _Pr_Str_GroupComp + "' and c_rif='" + _Drow["c_rif"].ToString().Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "INSERT INTO TDDESPACHOC (cgroupcomp,ccliente,c_direcc_despa,c_direcc_descrip,c_estado,c_ciudad,cdateadd) Select cgroupcomp,'" + _Int_Cliente.ToString() + "',c_direcc_despa,c_direcc_descrip,c_estado,c_ciudad,getdate() from TDDESPACHOP where ccliente='" + _Drow["cclientep"].ToString().Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "Update TENCUESTA set ccliente='" + _Int_Cliente.ToString() + "' where cclientep='" + _Drow["cclientep"].ToString().Trim() + "' and cgroupcomp='" + _Pr_Str_GroupComp + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "UPDATE TATENDIRECTO SET ccliente='" + _Int_Cliente.ToString() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + _Pr_Str_GroupComp + "' AND cclientep='" + _Drow["cclientep"].ToString().Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                MessageBox.Show("El cliente fue aprobado correctamente con el código " + _Int_Cliente.ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void _Bt_AprobarCliente_Click(object sender, EventArgs e)
        {
            if (!(_G_MyUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _G_MyUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_APROB_PROSPECTO")))
            {
                MessageBox.Show("Su usuario no tiene permisos para realizar esta operación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (_Mtd_ValidarSave())
            {
                if (MessageBox.Show("¿Está seguro de aprobar el cliente seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    _Int_Sw = 1;
                    _Pnl_Clave.Visible = true;
                    ((Frm_Padre)Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                }
            }
        }
        public bool _Mtd_Editar()
        {
            bool _Bol_Guardar = true;
            try
            {
                Cursor = Cursors.WaitCursor;
                if (_Mtd_ValidarSave())
                {
                    _Mtd_GuardarProspecto(true);
                }
                else
                {
                    _Bol_Guardar = false;
                }
                Cursor = Cursors.Default;
            }
            catch
            {
                _Bol_Guardar = false;
            }
            return _Bol_Guardar;
        }

        private bool _Mtd_ValidarSave()
        {
            int _Int_Tab = 0;
            _Er_Error.Dispose();
            bool _Bol_Valido = true;
            foreach (Control _Ctrl in tabPage5.Controls)
            {
                if (_Ctrl is TextBox)
                {
                    if (((TextBox)_Ctrl).Text.TrimEnd().TrimStart() == "")
                    {
                        string _Str_ControlId = ((TextBox)_Ctrl).Name;
                        if (_Str_ControlId != _Txt_RepLegal.Name && _Str_ControlId != _Txt_CodMogosa.Name && _Str_ControlId != _Txt_CodSigeco.Name)
                        {
                            _Er_Error.SetError(_Ctrl, "Información requerida!!!");
                            _Bol_Valido = false;
                            _Int_Tab = 2;
                        }
                    }
                }                
            }
            foreach (Control _Ctrl in _Pnl_Cabecera.Controls)
            {
                if (_Ctrl is TextBox)
                {
                    if (((TextBox)_Ctrl).Text.TrimEnd().TrimStart() == "")
                    {
                        string _Str_ControlId = ((TextBox)_Ctrl).Name;
                        if (_Str_ControlId != _Txt_Fax.Name && _Str_ControlId != _Txt_Email.Name && _Str_ControlId != _Txt_Www.Name && _Str_ControlId != _Txt_CodSunagro.Name)
                        {
                            _Er_Error.SetError(_Ctrl, "Información requerida!!!");
                            _Bol_Valido = false;
                        }
                    }
                }
                else if (_Ctrl is ComboBox)
                {
                    if (((ComboBox)_Ctrl).SelectedIndex <= 0)
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

            if (_Cmb_DireccionDespacho.Items.Count == 1)
            {
                if (_Cmb_DireccionDespacho.Items[0].ToString() == "CLIENTE NO CONTIENE DIRECCIONES DE DESPACHO" || _Cmb_DireccionDespacho.SelectedValue != null)
                {
                    _Er_Error.SetError(_Cmb_DireccionDespacho, "Información requerida!!!");
                    _Bol_Valido = false;
                }
            }

            if (_Cmb_Parroquia.SelectedIndex <= 0)
            {
                _Int_Tab = 40;
                _Er_Error.SetError(_Cmb_Parroquia, "Información requerida!!!");
                _Bol_Valido = false;
            }

            if (_Cmb_LimiteCredito.SelectedIndex <= 0)
            {
                _Int_Tab = 2;
                _Er_Error.SetError(_Cmb_LimiteCredito, "Información requerida!!!");
                _Bol_Valido = false;
            }
            if (_Cmb_Establecimiento.SelectedIndex <= 0)
            {
                _Int_Tab = 1;
                _Er_Error.SetError(_Cmb_Establecimiento, "Información requerida!!!");
                _Bol_Valido = false;
            }
            if (_Cmb_TipoCanal.SelectedIndex == -1 || _Cmb_TipoCanal.SelectedIndex == 0)
            {
                _Int_Tab = 1;
                _Er_Error.SetError(_Cmb_TipoCanal, "Información requerida!!!");
                _Bol_Valido = false;
            }
            if (!_Bol_Valido)
            {
                MessageBox.Show("Existen campos requeridos sin ingresar", "Requerido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _Tb_Detalle.SelectedIndex = _Int_Tab;
            }
            return _Bol_Valido;
        }
        private void _Mtd_Cargar_LimiteCredito()
        {
            string _Str_Sql = "SELECT RTRIM(TLIMITCREDITO.ccodlimite), TLIMITCREDITO.cdescripcion " +
                              "FROM TLIMITCREDITO INNER JOIN " +
                              "VST_LIMTECREDITO ON TLIMITCREDITO.climtehasta <= VST_LIMTECREDITO.climtehasta " +
                              "WHERE (TLIMITCREDITO.cdelete = '0') AND (VST_LIMTECREDITO.cdelete = '0') AND (VST_LIMTECREDITO.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') AND (VST_LIMTECREDITO.cuser = '" + Frm_Padre._Str_Use + "') " +
                              "ORDER BY TLIMITCREDITO.climtedesde";
            _G_MyUtilidad._Mtd_CargarCombo(_Cmb_LimiteCredito, _Str_Sql);
        }
        private void _Mtd_GuardarProspecto(bool _Bol_Mensaje)
        {
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[44];
                paramsToStore[0] = new SqlParameter("@cgroupcomp", SqlDbType.VarChar);
                paramsToStore[0].Size = 10;
                paramsToStore[0].Value = Frm_Padre._Str_GroupComp;
                paramsToStore[1] = new SqlParameter("@cclientep", SqlDbType.Real);
                paramsToStore[1].Value = _Txt_Cod.Text;
                paramsToStore[2] = new SqlParameter("@c_rif", SqlDbType.VarChar);
                paramsToStore[2].Size = 20;
                paramsToStore[2].Value = _Txt_Rif.Text;
                paramsToStore[3] = new SqlParameter("@c_nomb_comer", SqlDbType.VarChar);
                paramsToStore[3].Size = 100;
                paramsToStore[3].Value = _Txt_NombreComercial.Text.TrimEnd();
                paramsToStore[4] = new SqlParameter("@c_razsocial_1", SqlDbType.VarChar);
                paramsToStore[4].Size = 100;
                paramsToStore[4].Value = _Txt_RazonSocialEmpresa.Text;
                paramsToStore[5] = new SqlParameter("@c_razsocial_2", SqlDbType.VarChar);
                paramsToStore[5].Size = 100;
                paramsToStore[5].Value = _Txt_RazonSocialAccionista.Text;
                paramsToStore[6] = new SqlParameter("@c_direcc_fiscal", SqlDbType.VarChar);
                paramsToStore[6].Size = 255;
                paramsToStore[6].Value = _Txt_DireccionFiscal.Text.TrimEnd();
                paramsToStore[7] = new SqlParameter("@c_telefono", SqlDbType.VarChar);
                paramsToStore[7].Size = 100;
                paramsToStore[7].Value = _Txt_Telefono.Text;
                paramsToStore[8] = new SqlParameter("@c_fax", SqlDbType.VarChar);
                paramsToStore[8].Size = 100;
                paramsToStore[8].Value = _Txt_Fax.Text;
                paramsToStore[9] = new SqlParameter("@c_email", SqlDbType.VarChar);
                paramsToStore[9].Size = 100;
                paramsToStore[9].Value = _Txt_Email.Text;
                paramsToStore[10] = new SqlParameter("@c_www", SqlDbType.VarChar);
                paramsToStore[10].Size = 100;
                paramsToStore[10].Value = _Txt_Www.Text;
                paramsToStore[11] = new SqlParameter("@c_inf_replegal", SqlDbType.VarChar);
                paramsToStore[11].Size = 255;
                paramsToStore[11].Value = _Txt_RepLegal.Text.TrimEnd();
                
                paramsToStore[43] = new SqlParameter("@ccodsunagro", SqlDbType.VarChar);
                paramsToStore[43].Size = 30;
                paramsToStore[43].Value = _Txt_CodSunagro.Text.TrimEnd();

                paramsToStore[12] = new SqlParameter("@c_tip_contribuy", SqlDbType.VarChar);
                paramsToStore[12].Size = 10;
                if (_Cmb_TipoContribuyente.SelectedValue != null)
                {
                    paramsToStore[12].Value = _Cmb_TipoContribuyente.SelectedValue.ToString();
                }

                paramsToStore[13] = new SqlParameter("@c_clasifica", SqlDbType.VarChar);
                paramsToStore[13].Size = 10;
                if (_Cmb_Clasificacion.SelectedValue != null)
                {
                    paramsToStore[13].Value = _Cmb_Clasificacion.SelectedValue.ToString();
                }
                paramsToStore[14] = new SqlParameter("@c_info_cont_1", SqlDbType.VarChar);
                paramsToStore[14].Size = 255;
                paramsToStore[14].Value = _Txt_Contacto_1.Text;
                paramsToStore[15] = new SqlParameter("@c_info_cont_2", SqlDbType.VarChar);
                paramsToStore[15].Size = 255;
                paramsToStore[15].Value = _Txt_Contacto_2.Text;
                paramsToStore[16] = new SqlParameter("@c_info_cont_3", SqlDbType.VarChar);
                paramsToStore[16].Size = 255;
                paramsToStore[16].Value = _Txt_Contacto_3.Text;
                paramsToStore[17] = new SqlParameter("@c_estable", SqlDbType.VarChar);
                paramsToStore[17].Size = 10;
                if (_Cmb_Establecimiento.SelectedValue != null)
                {
                    paramsToStore[17].Value = _Cmb_Establecimiento.SelectedValue.ToString();
                }
                paramsToStore[18] = new SqlParameter("@c_canal", SqlDbType.VarChar);
                paramsToStore[18].Size = 10;
                if (_Cmb_TipoCanal.SelectedValue != null)
                {
                    paramsToStore[18].Value = _Cmb_TipoCanal.SelectedValue.ToString();
                }
                paramsToStore[19] = new SqlParameter("@cdelete", SqlDbType.TinyInt);
                paramsToStore[19].Value = "0";
                paramsToStore[20] = new SqlParameter("@cuserupd", SqlDbType.VarChar);
                paramsToStore[20].Size = 20;
                paramsToStore[20].Value = Frm_Padre._Str_Use;
                paramsToStore[21] = new SqlParameter("@c_municipio", SqlDbType.VarChar);
                paramsToStore[21].Size = 10;
                if (_Cmb_Municipio.SelectedValue != null)
                {
                    paramsToStore[21].Value = _Cmb_Municipio.SelectedValue.ToString();
                }
                paramsToStore[22] = new SqlParameter("@c_parroquia", SqlDbType.VarChar);
                paramsToStore[22].Size = 10;
                if (_Cmb_Parroquia.SelectedValue != null)
                {
                    paramsToStore[22].Value = _Cmb_Parroquia.SelectedValue.ToString();
                }
                paramsToStore[23] = new SqlParameter("@c_sector", SqlDbType.VarChar);
                paramsToStore[23].Size = 30;
                paramsToStore[23].Value = _Txt_Sector.Text;
                paramsToStore[24] = new SqlParameter("@c_urbanizacion", SqlDbType.VarChar);
                paramsToStore[24].Size = 30;
                paramsToStore[24].Value = _Txt_Urbanizacion.Text;
                paramsToStore[25] = new SqlParameter("@c_carretera", SqlDbType.VarChar);
                paramsToStore[25].Size = 30;
                paramsToStore[25].Value = _Txt_Carretera.Text;
                paramsToStore[26] = new SqlParameter("@c_avenida", SqlDbType.VarChar);
                paramsToStore[26].Size = 30;
                paramsToStore[26].Value = _Txt_Avenida.Text;
                paramsToStore[27] = new SqlParameter("@c_calle", SqlDbType.VarChar);
                paramsToStore[27].Size = 30;
                paramsToStore[27].Value = _Txt_Calle.Text;
                paramsToStore[28] = new SqlParameter("@c_carrera", SqlDbType.VarChar);
                paramsToStore[28].Size = 30;
                paramsToStore[28].Value = _Txt_Carrera.Text;
                paramsToStore[29] = new SqlParameter("@c_transversal", SqlDbType.VarChar);
                paramsToStore[29].Size = 30;
                paramsToStore[29].Value = _Txt_Transversal.Text;
                paramsToStore[30] = new SqlParameter("@c_esquina", SqlDbType.VarChar);
                paramsToStore[30].Size = 30;
                paramsToStore[30].Value = _Txt_Esquina.Text;
                paramsToStore[31] = new SqlParameter("@c_piso", SqlDbType.VarChar);
                paramsToStore[31].Size = 30;
                paramsToStore[31].Value = _Txt_Piso.Text;
                paramsToStore[32] = new SqlParameter("@c_edificio", SqlDbType.VarChar);
                paramsToStore[32].Size = 30;
                paramsToStore[32].Value = _Txt_Edificio.Text;
                paramsToStore[33] = new SqlParameter("@c_local", SqlDbType.VarChar);
                paramsToStore[33].Size = 30;
                paramsToStore[33].Value = _Txt_Local.Text;
                paramsToStore[34] = new SqlParameter("@c_preferencia", SqlDbType.VarChar);
                paramsToStore[34].Size = 50;
                paramsToStore[34].Value = _Txt_Referencia.Text;
                paramsToStore[35] = new SqlParameter("@c_pcardinal", SqlDbType.NVarChar);
                paramsToStore[35].Size = 2;
                if (_Cmb_PuntoCardinal.SelectedValue != null)
                {
                    paramsToStore[35].Value = _Cmb_PuntoCardinal.SelectedValue.ToString();
                }
                else
                {
                    paramsToStore[35].Value = "";
                }
                paramsToStore[36] = new SqlParameter("@c_estado", SqlDbType.VarChar);
                paramsToStore[36].Size = 10;
                if (_Cmb_Estado.SelectedValue != null)
                {
                    paramsToStore[36].Value = _Cmb_Estado.SelectedValue.ToString();
                }
                else
                {
                    paramsToStore[36].Value = "0";
                }
                paramsToStore[37] = new SqlParameter("@c_ciudad", SqlDbType.VarChar);
                paramsToStore[37].Size = 10;
                if (_Cmb_Ciudad.SelectedValue != null)
                {
                    paramsToStore[37].Value = _Cmb_Ciudad.SelectedValue.ToString();
                }
                paramsToStore[38] = new SqlParameter("@c_clientsigesod", SqlDbType.VarChar);
                paramsToStore[38].Size = 10;
                if (_Txt_CodSigeco.Text == "")
                {
                    _Txt_CodSigeco.Text = "0";
                }
                paramsToStore[38].Value = _Txt_CodSigeco.Text;
                paramsToStore[39] = new SqlParameter("@c_clientsigemog", SqlDbType.VarChar);
                paramsToStore[39].Size = 10;
                if (_Txt_CodMogosa.Text == "")
                {
                    _Txt_CodMogosa.Text = "0";
                }
                paramsToStore[39].Value = _Txt_CodMogosa.Text;
                paramsToStore[40] = new SqlParameter("@c_atendidodirecto", SqlDbType.TinyInt);
                paramsToStore[40].Value = Convert.ToInt32(_Chbox_AtendidoDirecto.Checked);
                paramsToStore[41] = new SqlParameter("@cbackorder", SqlDbType.TinyInt);
                paramsToStore[41].Value = Convert.ToInt32(_Chbox_BackOrder.Checked);
                paramsToStore[42] = new SqlParameter("@c_limt_credit", SqlDbType.VarChar);
                paramsToStore[42].Value = Convert.ToString(_Cmb_LimiteCredito.SelectedValue).Trim();
                CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("sp_Updatetprospecto", paramsToStore);
                if (_Bol_Mensaje)
                {
                    MessageBox.Show("Se realizaron los cambios correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Tb_Tab.SelectedIndex = 0;
                }
            }
            catch
            { }
        }

        private void _Txt_CodSigeco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_CodMogosa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Cmb_LimiteCredito_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_LimiteCredito();
        }

        private void Frm_Prospectos_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
        }

        private void _Dg_Consulta_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (_Dg_Consulta[0, e.RowIndex].Value != null)
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_CargarData(_Dg_Consulta.Rows[_Dg_Consulta.CurrentCell.RowIndex].Cells["Column2"].Value.ToString());
                    Cursor = Cursors.Default;
                }
            }
            catch
            {
            }
        }
        private void _Mtd_DevolverProspecto(string _P_Str_Prospecto)
        {
            string _Str_Cadena = "UPDATE TPROSPECTO SET c_solicitud='1',c_rechazo='0' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cclientep='" + _P_Str_Prospecto + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
        }
        private void _Rb_Pend_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
            Cursor = Cursors.Default;
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (_Rb_Pend.Checked | _Dg_Consulta.SelectedRows.Count == 0)
            { e.Cancel = true; }
        }

        private void devolverAPendientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Dg_Consulta.CurrentCell != null)
            {
                _Mtd_DevolverProspecto(_Dg_Consulta.Rows[_Dg_Consulta.CurrentCell.RowIndex].Cells["Column2"].Value.ToString());
                Cursor = Cursors.WaitCursor;
                _Mtd_Actualizar();
                Cursor = Cursors.Default;
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error en la operación. Seleccione el registro e intente nuevamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Tb_Tab.Enabled = false; _Tb_Detalle.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Tb_Tab.Enabled = true; _Tb_Detalle.Enabled = true; }
        }
        int _Int_Sw = 0;
        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_G_MyUtilidad._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                _Pnl_Clave.Visible = false;
                Cursor = Cursors.WaitCursor;
                if (_Int_Sw == 1)
                {
                    Cursor = Cursors.WaitCursor;
                    _Mtd_GuardarProspecto(false);
                    _Mtd_CrearCliente(Frm_Padre._Str_GroupComp, _Txt_Cod.Text);
                    Cursor = Cursors.Default;
                }
                else
                {
                    string _Str_SQL = "UPDATE TPROSPECTO SET c_solicitud='0',c_rechazo='1' WHERE cclientep='" + _Txt_Cod.Text + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                    MessageBox.Show("La operación ha sido realizada correctamente. Cliente rechazado.", "información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                _Mtd_Actualizar();
                _Tb_Tab.SelectedIndex = 0;
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                Cursor = Cursors.Default;
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
            _Mtd_BotonesMenu();
        }
    }
}
