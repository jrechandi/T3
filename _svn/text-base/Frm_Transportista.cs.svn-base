using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Transportista : Form
    {
        public Frm_Transportista()
        {
            InitializeComponent();
        }
        //bool _Bol_Tabs = false;
        public Frm_Transportista(string _Pr_Str_Placa)
        {
            InitializeComponent();
            //_Bol_Tabs = true;
            _Str_FrmPlaca = _Pr_Str_Placa;
            _Bt_Buscar.Enabled = false;
        }

        string _Str_FrmPlaca = "";

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
        private void Frm_Transportista_Load(object sender, EventArgs e)
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Cédula");
            _Tsm_Menu[1] = new ToolStripMenuItem("Transportista");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ccedula";
            _Str_Campos[1] = "cnombre";
            string _Str_Cadena = "Select ccedula as Cédula,cnombre as Transportista,cplaca+'/'+cmarca+'/'+cmodelo+'/'+ccolor+'/'+cname as Transporte,cplaca from vst_Transportista where 0=0";
            if (_Str_FrmPlaca != "")
            {
                _Str_Cadena = _Str_Cadena + " and cplaca='" + _Str_FrmPlaca + "'";
            }
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Transportistas", _Tsm_Menu, _Dg_Grid, true, "");
            //___________________________________
            _Mtd_Actualizar();
            _Mtd_Color_Estandar(this);
            _Dtp_Nacimiento.MaxDate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().AddDays(-1);
        }
        private void _Mtd_Actualizar()
        {
            string _Str_Cadena = "Select ccedula as Cédula,cnombre as Transportista,cplaca+'/'+cmarca+'/'+cmodelo+'/'+ccolor+'/'+cname as Transporte,cplaca from vst_Transportista where 0=0";
            if (_Str_FrmPlaca != "")
            {
                _Str_Cadena = _Str_Cadena + " and cplaca='" + _Str_FrmPlaca + "'";
            }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns[3].Visible = false; _Dg_Grid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        public void _Mtd_Cancelar()
        {
            _Mtd_Ini();
            _Mtd_Deshabilitar_Todo();
        }
        public void _Mtd_Ini()
        {
            _Txt_Cedula.Text = "";
            _Txt_Email.Text = "";
            _Txt_Nombre.Text = "";
            _Txt_Rif1.Text="";
            _Txt_Rif2.Text="";
            _Txt_Telefono.Text = "";
            _Txt_Transporte.Text="";
            _Txt_Placa.Text= "";
            _Chbox_Activo.Checked=false;
            _Chbox_Bancarias.Checked = false;
            _Chbox_Carnet.Checked = false;
            _Chbox_Cedula.Checked = false;
            _Chbox_Circulacion.Checked = false;
            _Chbox_Civil.Checked = false;
            _Chbox_Comerciales.Checked = false;
            _Chbox_Conducir.Checked = false;
            _Chbox_Conducta.Checked = false;
            _Chbox_Medica.Checked = false;
            _Chbox_Movistar.Checked = false;
            _Chbox_Personales.Checked = false;
            _Chbox_Propiedad.Checked = false;
            _Chbox_Propietario.Checked = false;
            _Chbox_Ptj.Checked = false;
            _Chbox_Rcv.Checked = false;
            _Chbox_Recomendacion.Checked = false;
            _Chbox_Registro.Checked = false;
            _Chbox_Rif.Checked = false;
            _Bt_Buscar.Enabled = false;
            _Bt_Rif.Enabled = false;
            _Chbox_Sanidad.Checked = false;
            _Chbox_Sanitario.Checked = false;
            _Cmb_Rif.SelectedIndex = -1;
            _Dtp_Licencia.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dtp_Sanitario.Value=CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dtp_Nacimiento.Value = new DateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Day).AddDays(-1);
            _Dtp_Rcv.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dtp_Salud.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Mtd_Habilitar();
            _Txt_Cedula.Enabled = true;
        }
        public void _Mtd_Habilitar()
        {
            _Txt_Cedula.Enabled = false;
            _Txt_Email.Enabled = true;
            _Txt_Nombre.Enabled = true;
            if (_Str_FrmPlaca.Length > 0)
            {
                _Bt_Buscar.Enabled = false;
            }
            else
            {
                _Bt_Buscar.Enabled = true;
            }
            _Bt_Rif.Enabled = true;
            _Txt_Rif1.Enabled = true;
            _Txt_Rif2.Enabled = true;
            _Txt_Telefono.Enabled = true;
            _Txt_Transporte.Enabled = true;
            _Cmb_Rif.Enabled = true;
            _Chbox_Activo.Enabled = true;
            _Chbox_Bancarias.Enabled = true;
            _Chbox_Carnet.Enabled = true;
            _Chbox_Cedula.Enabled = true;
            _Chbox_Circulacion.Enabled = true;
            _Chbox_Civil.Enabled = true;
            _Chbox_Comerciales.Enabled = true;
            _Chbox_Conducir.Enabled = true;
            _Chbox_Conducta.Enabled = true;
            _Chbox_Medica.Enabled = true;
            _Chbox_Movistar.Enabled = true;
            _Chbox_Personales.Enabled = true;
            _Chbox_Propiedad.Enabled = true;
            _Chbox_Propietario.Enabled = true;
            _Chbox_Ptj.Enabled = true;
            _Chbox_Rcv.Enabled = true;
            _Chbox_Recomendacion.Enabled = true;
            _Chbox_Registro.Enabled = true;
            _Chbox_Rif.Enabled = true;
            _Chbox_Sanidad.Enabled = true;
            _Chbox_Sanitario.Enabled = true;
            
            _Dtp_Licencia.Enabled = true;
            _Dtp_Sanitario.Enabled = true;
            _Dtp_Nacimiento.Enabled = true;
            _Dtp_Rcv.Enabled = true;
            _Dtp_Salud.Enabled = true;
            string _Str_Sql = "";
            if (_Str_FrmPlaca.Length == 0)
            {
                _Str_Sql = "SELECT cintext FROM TTRANSPORTE WHERE cplaca='" + _Txt_Placa.Text + "'";
            }
            else
            {
                _Str_Sql = "SELECT cintext FROM TTRANSPORTE WHERE cplaca='" + _Str_FrmPlaca + "'";
            }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    _Cmb_Rif.Enabled = false;
                    _Txt_Rif1.Enabled = false;
                    _Txt_Rif2.Enabled = false;
                }
                else
                {
                    _Cmb_Rif.Enabled = true;
                    _Txt_Rif1.Enabled = true;
                    _Txt_Rif2.Enabled = true;
                }
            }
        }
        private void Frm_Transportista_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Txt_TpoFind.Text = "PA";
            CONTROLES._Ctrl_Buscar._Er_Control_Error = _Er_Error;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            //if (!_Bol_Tabs)
            //{
                //____________________________________________
                if (!_Txt_Nombre.Enabled & _Txt_Nombre.Text.Trim().Length > 0)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                }
                else if (!_Txt_Cedula.Enabled & _Txt_Cedula.Text.Trim().Length > 0 & _Txt_Nombre.Enabled)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                }
                else if (_Txt_Cedula.Enabled)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                }
                //_____________________________________________
            //}
        }
        TextBox _Txt_Placa = new TextBox();
        private void Frm_Transportista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        public void _Mtd_Nuevo()
        {
            _Er_Error.Dispose();
            string _Str_Sql = "";
            _Mtd_Ini();
            _Tb_Tab.SelectedIndex = 1;
            if (_Str_FrmPlaca != "")
            {
                _Txt_Placa.Text = _Str_FrmPlaca;
                _Txt_Transporte.Text = _Mtd_GetDescripTransporte(_Str_FrmPlaca);
                
            }
            _Chbox_Activo.Checked = true;
            _Txt_Cedula.Focus();
        }

        private string _Mtd_GetDescripTransporte(string _Pr_Str_Placa)
        {
            string _Str_R = "";
            string _Str_Cadena = "SELECT TTRANSPORTE.cplaca + '/' + TTRANSPORTE.cmarca + '/' + TTRANSPORTE.cmodelo + '/' + TTRANSPORTE.ccolor + '/' + TTTRANSPORTE.cname AS Descripción " +
"FROM TTRANSPORTE INNER JOIN " +
"TTTRANSPORTE ON TTRANSPORTE.ctttransporte = TTTRANSPORTE.cttransporte " +
"WHERE     (TTRANSPORTE.cdelete = '0') and (TTRANSPORTE.cplaca = '"+_Pr_Str_Placa+"')";
            _Str_Cadena = _Str_Cadena + " and cplaca='" + _Pr_Str_Placa + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_R = _Ds.Tables[0].Rows[0][0].ToString();
            }
            return _Str_R;
        }

        private void _Mtd_Deshabilitar_Todo()
        {
            _Txt_Cedula.Enabled = false;
            _Txt_Email.Enabled = false;
            _Txt_Nombre.Enabled = false;
            _Txt_Rif1.Enabled = false;
            _Txt_Rif2.Enabled = false;
            _Txt_Telefono.Enabled = false;
            _Txt_Transporte.Enabled = false;
            _Chbox_Activo.Enabled = false;
            _Chbox_Bancarias.Enabled = false;
            _Chbox_Carnet.Enabled = false;
            _Chbox_Cedula.Enabled = false;
            _Chbox_Circulacion.Enabled = false;
            _Chbox_Civil.Enabled = false;
            _Chbox_Comerciales.Enabled = false;
            _Chbox_Conducir.Enabled = false;
            _Chbox_Conducta.Enabled = false;
            _Chbox_Medica.Enabled = false;
            _Chbox_Movistar.Enabled = false;
            _Chbox_Personales.Enabled = false;
            _Chbox_Propiedad.Enabled = false;
            _Chbox_Propietario.Enabled = false;
            _Chbox_Ptj.Enabled = false;
            _Chbox_Rcv.Enabled = false;
            _Chbox_Recomendacion.Enabled = false;
            _Chbox_Registro.Enabled = false;
            _Chbox_Rif.Enabled = false;
            _Chbox_Sanidad.Enabled = false;
            _Chbox_Sanitario.Enabled = false;
            _Cmb_Rif.Enabled = false;
            _Dtp_Licencia.Enabled = false;
            _Dtp_Sanitario.Enabled = false;
            _Dtp_Nacimiento.Enabled = false;
            _Dtp_Rcv.Enabled = false;
            _Dtp_Salud.Enabled = false;
            _Bt_Buscar.Enabled = false;
        }
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            bool _Bol_TransInt = false;
            string _Str_Sql = "";
            string _Str_Rif = "";
            if (_Str_FrmPlaca.Length == 0)
            {
                _Str_Sql = "SELECT cintext FROM TTRANSPORTE WHERE cplaca='" + _Txt_Placa.Text + "'";
            }
            else
            {
                _Str_Sql = "SELECT cintext FROM TTRANSPORTE WHERE cplaca='" + _Str_FrmPlaca + "'";
            }
            
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    _Bol_TransInt = true;
                }
                else
                {
                    _Bol_TransInt = false;
                }
            }
            if (_Bol_TransInt)
            {
                _Str_Rif = "0";   
            }
            else
            {
                if (_Cmb_Rif.SelectedIndex != -1 & _Txt_Rif1.Text.Trim().Length == 8 & _Txt_Rif2.Text.Trim().Length > 0)
                { _Str_Rif = _Cmb_Rif.SelectedItem.ToString() + "-" + _Txt_Rif1.Text.Trim() + "-" + _Txt_Rif2.Text.Trim(); }
                else
                { _Str_Rif = ""; }
            }


            if ((_Txt_Cedula.Text.Trim().Length > 0 && int.Parse(_Txt_Cedula.Text)>0) & _Txt_Nombre.Text.Trim().Length > 0 & _Str_Rif.Trim().Length > 0 & _Txt_Telefono.Text.Trim().Length > 0 & _Txt_Transporte.Text.Trim().Length > 0)
            {
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select cdelete from TTRANSPORTISTA where ccedula='" + _Txt_Cedula.Text.Trim() + "'"))
                {
                    string _Str_Cadena = "SELECT cdelete FROM TTRANSPORTISTA WHERE ccedula='" + _Txt_Cedula.Text.Trim() + "'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim() == "1")
                    {
                        if (MessageBox.Show("El transportista con cédula: " + _Txt_Cedula.Text + " fue eliminado anteriormente. ¿Desea activarlo nuevamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            _Str_Cadena = "UPDATE TTRANSPORTISTA Set cplaca='" + _Txt_Placa.Text.ToString() + "',ccedula='" + _Txt_Cedula.Text.Trim() + "',cpropietario='" + Convert.ToInt32(_Chbox_Propietario.Checked).ToString() + "',cnombre='" + _Txt_Nombre.Text.ToUpper() + "',crif='" + _Str_Rif + "',ctelefonos='" + _Txt_Telefono.Text + "',cemail='" + _Txt_Email.Text.ToUpper() + "',cdatenac='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Nacimiento.Value) + "',cdateapert='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cdc_fot_rif='" + Convert.ToInt32(_Chbox_Rif.Checked).ToString() + "',cdc_fot_rm='" + Convert.ToInt32(_Chbox_Registro.Checked).ToString() + "',cdc_fot_tipcarnet='" + Convert.ToInt32(_Chbox_Carnet.Checked).ToString() + "',cdc_fot_cedula='" + Convert.ToInt32(_Chbox_Cedula.Checked).ToString() + "',cdc_fot_titulocamion='" + Convert.ToInt32(_Chbox_Propiedad.Checked).ToString() + "',cdc_fot_carncir='" + Convert.ToInt32(_Chbox_Circulacion.Checked).ToString() + "',cdc_seg_respciv='" + Convert.ToInt32(_Chbox_Civil.Checked).ToString() + "',cdc_fot_liccondu='" + Convert.ToInt32(_Chbox_Conducir.Checked).ToString() + "',cdc_fot_cartmedi='" + Convert.ToInt32(_Chbox_Medica.Checked).ToString() + "',cdc_fot_revptj='" + Convert.ToInt32(_Chbox_Ptj.Checked).ToString() + "',cdc_fot_certsalud='" + Convert.ToInt32(_Chbox_Sanidad.Checked).ToString() + "',cdc_seg_rcv='" + Convert.ToInt32(_Chbox_Rcv.Checked).ToString() + "',cdc_carta_buecon='" + Convert.ToInt32(_Chbox_Conducta.Checked).ToString() + "',cdc_carta_recomend='" + Convert.ToInt32(_Chbox_Recomendacion.Checked).ToString() + "',cdc_refe_personales='" + Convert.ToInt32(_Chbox_Personales.Checked).ToString() + "',cdc_refe_comercia='" + Convert.ToInt32(_Chbox_Comerciales.Checked).ToString() + "',cdc_refe_bancaria='" + Convert.ToInt32(_Chbox_Bancarias.Checked).ToString() + "',cdc_tele_movistar='" + Convert.ToInt32(_Chbox_Movistar.Checked).ToString() + "',cactivate='" + Convert.ToInt32(_Chbox_Activo.Checked).ToString() + "',cdc_fec_liccondu='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Licencia.Value) + "',cdc_fec_certsalud='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Salud.Value) + "',cdc_fot_permsanit='" + Convert.ToInt32(_Chbox_Sanitario.Checked).ToString() + "',cdc_fec_permsanit='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Sanitario.Value) + "',cdc_fec_rcv='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Rcv.Value) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0' where ccedula='" + _Txt_Cedula.Text.Trim() + "' AND cdelete='1'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            MessageBox.Show("El transportista con cédula: " + _Txt_Cedula.Text + " fue activado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Mtd_Actualizar();
                            _Mtd_Ini();
                            _Mtd_Deshabilitar_Todo();
                            _Tb_Tab.SelectedIndex = 0;
                            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                            _Er_Error.Dispose();
                            return true;
                        }
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("El registro ya existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else
                {
                    string _Str_Cadena = "insert into TTRANSPORTISTA (cplaca,ccedula,cpropietario,cnombre,crif,ctelefonos,cemail,cdatenac,cdateapert,cdc_fot_rif,cdc_fot_rm,cdc_fot_tipcarnet,cdc_fot_cedula,cdc_fot_titulocamion,cdc_fot_carncir,cdc_seg_respciv,cdc_fot_liccondu,cdc_fot_cartmedi,cdc_fot_revptj,cdc_fot_certsalud,cdc_seg_rcv,cdc_carta_buecon,cdc_carta_recomend,cdc_refe_personales,cdc_refe_comercia,cdc_refe_bancaria,cdc_tele_movistar,cactivate,cdc_fec_liccondu,cdc_fec_certsalud,cdc_fot_permsanit,cdc_fec_permsanit,cdc_fec_rcv,cdateadd,cuseradd,cdelete) values('" + _Txt_Placa.Text.Trim() + "','" + _Txt_Cedula.Text.Trim() + "','" + Convert.ToInt32(_Chbox_Propietario.Checked).ToString() + "','" + _Txt_Nombre.Text.Trim().ToUpper() + "','" + _Str_Rif + "','" + _Txt_Telefono.Text.Trim() + "','" + _Txt_Email.Text.Trim().ToUpper() + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Nacimiento.Value) + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + Convert.ToInt32(_Chbox_Rif.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Registro.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Carnet.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Cedula.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Propiedad.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Circulacion.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Civil.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Conducir.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Medica.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Ptj.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Sanidad.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Rcv.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Conducta.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Recomendacion.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Personales.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Comerciales.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Bancarias.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Movistar.Checked).ToString() + "','" + Convert.ToInt32(_Chbox_Activo.Checked).ToString() + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Licencia.Value) + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Salud.Value) + "','" + Convert.ToInt32(_Chbox_Sanitario.Checked).ToString() + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Sanitario.Value) + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Rcv.Value) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    MessageBox.Show("El registro fue agregado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_Actualizar();
                    _Mtd_Ini();
                    _Mtd_Deshabilitar_Todo();
                    _Tb_Tab.SelectedIndex = 0;
                    _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    _Er_Error.Dispose();
                    return true;
                }
            }
            else
            {
                if (_Txt_Cedula.Text.Trim().Length < 1 || int.Parse(_Txt_Cedula.Text) <= 0) { _Er_Error.SetError(_Txt_Cedula, "Información requerida!!!"); }
                if (_Txt_Nombre.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Nombre, "Información requerida!!!"); }
                if (_Str_Rif.Trim().Length < 1 && !_Bol_TransInt) { _Er_Error.SetError(_Txt_Rif2, "Información requerida!!!"); }
                if (_Txt_Telefono.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Telefono, "Información requerida!!!"); }
                if (_Txt_Transporte.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Transporte, "Información requerida!!!"); }
                return false;
            }
        }
        public bool _Mtd_Editar()
        {
            _Er_Error.Dispose();
            bool _Bol_TransInt = false;
            string _Str_Rif = "";
            string _Str_Sql = "SELECT cintext FROM TTRANSPORTE WHERE cplaca='" + _Txt_Placa.Text + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    _Bol_TransInt = true;
                }
                else
                {
                    _Bol_TransInt = false;
                }
            }
            if (_Bol_TransInt)
            {
                _Str_Rif = "0";
            }
            else
            {
                if (_Cmb_Rif.SelectedIndex != -1 & _Txt_Rif1.Text.Trim().Length == 8 & _Txt_Rif2.Text.Trim().Length > 0)
                { _Str_Rif = _Cmb_Rif.SelectedItem.ToString() + "-" + _Txt_Rif1.Text.Trim() + "-" + _Txt_Rif2.Text.Trim(); }
                else
                { _Str_Rif = ""; }
            }

            if ((_Txt_Cedula.Text.Trim().Length > 0 && int.Parse(_Txt_Cedula.Text)>0) & _Txt_Nombre.Text.Trim().Length > 0 & _Str_Rif.Trim().Length > 0 & _Txt_Telefono.Text.Trim().Length > 0 & _Txt_Transporte.Text.Trim().Length > 0)
            {
                string _Str_Cadena = "UPDATE TTRANSPORTISTA Set cplaca='" + _Txt_Placa.Text.ToString() + "',ccedula='" + _Txt_Cedula.Text.Trim() + "',cpropietario='" + Convert.ToInt32(_Chbox_Propietario.Checked).ToString() + "',cnombre='" + _Txt_Nombre.Text.ToUpper() + "',crif='" + _Str_Rif + "',ctelefonos='" + _Txt_Telefono.Text + "',cemail='" + _Txt_Email.Text.ToUpper() + "',cdatenac='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Nacimiento.Value) + "',cdateapert='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cdc_fot_rif='" + Convert.ToInt32(_Chbox_Rif.Checked).ToString() + "',cdc_fot_rm='" + Convert.ToInt32(_Chbox_Registro.Checked).ToString() + "',cdc_fot_tipcarnet='" + Convert.ToInt32(_Chbox_Carnet.Checked).ToString() + "',cdc_fot_cedula='" + Convert.ToInt32(_Chbox_Cedula.Checked).ToString() + "',cdc_fot_titulocamion='" + Convert.ToInt32(_Chbox_Propiedad.Checked).ToString() + "',cdc_fot_carncir='" + Convert.ToInt32(_Chbox_Circulacion.Checked).ToString() + "',cdc_seg_respciv='" + Convert.ToInt32(_Chbox_Civil.Checked).ToString() + "',cdc_fot_liccondu='" + Convert.ToInt32(_Chbox_Conducir.Checked).ToString() + "',cdc_fot_cartmedi='" + Convert.ToInt32(_Chbox_Medica.Checked).ToString() + "',cdc_fot_revptj='" + Convert.ToInt32(_Chbox_Ptj.Checked).ToString() + "',cdc_fot_certsalud='" + Convert.ToInt32(_Chbox_Sanidad.Checked).ToString() + "',cdc_seg_rcv='" + Convert.ToInt32(_Chbox_Rcv.Checked).ToString() + "',cdc_carta_buecon='" + Convert.ToInt32(_Chbox_Conducta.Checked).ToString() + "',cdc_carta_recomend='" + Convert.ToInt32(_Chbox_Recomendacion.Checked).ToString() + "',cdc_refe_personales='" + Convert.ToInt32(_Chbox_Personales.Checked).ToString() + "',cdc_refe_comercia='" + Convert.ToInt32(_Chbox_Comerciales.Checked).ToString() + "',cdc_refe_bancaria='" + Convert.ToInt32(_Chbox_Bancarias.Checked).ToString() + "',cdc_tele_movistar='" + Convert.ToInt32(_Chbox_Movistar.Checked).ToString() + "',cactivate='" + Convert.ToInt32(_Chbox_Activo.Checked).ToString() + "',cdc_fec_liccondu='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Licencia.Value) + "',cdc_fec_certsalud='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Salud.Value) + "',cdc_fot_permsanit='" + Convert.ToInt32(_Chbox_Sanitario.Checked).ToString() + "',cdc_fec_permsanit='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Sanitario.Value) + "',cdc_fec_rcv='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_Rcv.Value) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0' where ccedula='" + _Txt_Cedula.Text.Trim() + "' AND ISNULL(cdelete,0)=0";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                MessageBox.Show("El registro fue modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Actualizar();
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
                _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Er_Error.Dispose();
                return true;
            }
            else
            {
                if (_Txt_Cedula.Text.Trim().Length < 1 || int.Parse(_Txt_Cedula.Text) <= 0) { _Er_Error.SetError(_Txt_Cedula, "Información requerida!!!"); }
                if (_Txt_Nombre.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Nombre, "Información requerida!!!"); }
                if (_Str_Rif.Trim().Length < 1 && !_Bol_TransInt) { _Er_Error.SetError(_Txt_Rif2, "Información requerida!!!"); }
                if (_Txt_Telefono.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Telefono, "Información requerida!!!"); }
                if (_Txt_Transporte.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Transporte, "Información requerida!!!"); }
                return false;
            }
        }
        public bool _Mtd_Eliminar()
        {
            DialogResult eli = MessageBox.Show("Esta seguro de Eliminar el registro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (eli == DialogResult.Yes)
            {
                string _Str_Cadena = "UPDATE TTRANSPORTISTA Set cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1',cactivate='0' where ccedula='" + _Txt_Cedula.Text.Trim() + "' AND ISNULL(cdelete,0)=0";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                MessageBox.Show("El registro fue eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Actualizar();
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
            }
            else
            {
                _Mtd_Actualizar();
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
            }
            return true;
        }

        private void _Tb_Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
        }
        private void _Txt_Rif1_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Rif1.Text))
            {
                _Txt_Rif1.Text = "";
            }
        }
        private void _Txt_PlacaMio_TextChanged(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT cintext FROM TTRANSPORTE WHERE cplaca='" + ((TextBox)sender).Text + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    _Cmb_Rif.SelectedIndex = -1;
                    _Txt_Rif1.Text = "";
                    _Txt_Rif2.Text = "";
                    _Cmb_Rif.Enabled = false;
                    _Txt_Rif1.Enabled = false;
                    _Txt_Rif2.Enabled = false;
                }
                else
                {
                    _Cmb_Rif.Enabled = true;
                    _Txt_Rif1.Enabled = true;
                    _Txt_Rif2.Enabled = true;
                }
            }
        }
        private void _Txt_Rif2_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Rif2.Text))
            {
                _Txt_Rif2.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool _Bol_TransInt = false;
            string _Str_Rif = "";
            string _Str_Sql = "SELECT cintext FROM TTRANSPORTE WHERE cplaca='" + _Str_FrmPlaca + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    _Bol_TransInt = true;
                }
                else
                {
                    _Bol_TransInt = false;
                }
            }
            if (_Bol_TransInt)
            {
                if (_Cmb_Rif.SelectedIndex != -1 & _Txt_Rif1.Text.Trim().Length == 8)
                {
                    if (_Txt_Rif2.Text.Trim().Length > 0)
                    {
                        _Str_Rif = _Cmb_Rif.SelectedItem.ToString() + "-" + _Txt_Rif1.Text.Trim() + "-" + _Txt_Rif2.Text.Trim();
                    }
                    else
                    {
                        _Str_Rif = _Cmb_Rif.SelectedItem.ToString() + "-" + _Txt_Rif1.Text.Trim();
                    }
                }
                else
                { _Str_Rif = ""; }
            }
            else
            {
                if (_Cmb_Rif.SelectedIndex != -1 & _Txt_Rif1.Text.Trim().Length == 8 & _Txt_Rif2.Text.Trim().Length > 0)
                { _Str_Rif = _Cmb_Rif.SelectedItem.ToString() + "-" + _Txt_Rif1.Text.Trim() + "-" + _Txt_Rif2.Text.Trim(); }
                else
                { _Str_Rif = ""; }
            }

            if (_Str_Rif.Trim().Length > 0)
            {
                string _Str_Url = CLASES._Cls_Varios_Metodos._Str_Servidor_Web + "/este.aspx?este=" + _Str_Rif.Replace("-", "");
                Frm_Navegador _Frm = new Frm_Navegador(_Str_Url, false);
                _Frm.MdiParent = this.MdiParent;
                _Frm.Dock = DockStyle.Fill;
                _Frm.Show();
            }
            else
            {
                MessageBox.Show("El rif que introdujo no es válido","Requerimiento",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        private bool _Mtd_VerificarTransportes()
        {
            string _Str_Cadena = "SELECT cplaca FROM TTRANSPORTE WHERE cdelete='0' AND NOT EXISTS(SELECT * FROM TTRANSPORTISTA WHERE TTRANSPORTISTA.cplaca = TTRANSPORTE.cplaca AND cactivate='1' AND TTRANSPORTISTA.cdelete='0')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }
        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            if (_Mtd_VerificarTransportes())
            {
                ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
                _Tsm_Menu[0] = new ToolStripMenuItem("Placa");
                string[] _Str_Campos = new string[1];
                _Str_Campos[0] = "cplaca";
                string _Str_Cadena = "SELECT TTRANSPORTE.cplaca AS Placa, " +
    "TTRANSPORTE.cplaca + '/' + TTRANSPORTE.cmarca + '/' + TTRANSPORTE.cmodelo + '/' + TTRANSPORTE.ccolor + '/' + TTTRANSPORTE.cname AS Descripción " +
    "FROM TTRANSPORTE INNER JOIN " +
    "TTTRANSPORTE ON TTRANSPORTE.ctttransporte = TTTRANSPORTE.cttransporte " +
    "WHERE     (TTRANSPORTE.cdelete = '0') AND NOT EXISTS(SELECT * FROM TTRANSPORTISTA WHERE TTRANSPORTISTA.cplaca = TTRANSPORTE.cplaca AND cactivate='1' AND TTRANSPORTISTA.cdelete='0')";
                _Txt_Placa.TextChanged += new EventHandler(_Txt_PlacaMio_TextChanged);
                Frm_Busqueda _Frm = new Frm_Busqueda(_Txt_Placa, _Txt_Transporte, _Str_Cadena, _Str_Campos, "Transportes", _Tsm_Menu, 0, 1);
                _Frm.MdiParent = this.MdiParent;
                _Frm.Show();
            }
            else
            {
                MessageBox.Show("No existen transportes disponibles. \n Todos los transportes tienen un trasportista asignado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Txt_Cedula_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Cedula.Text))
            {
                _Txt_Cedula.Text = "";
            }
        }

        private void _Txt_Cedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Rif1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Rif2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                Cursor = Cursors.WaitCursor;
                _Er_Error.Dispose();
                _Mtd_Deshabilitar_Todo();
                string _Str_Cadena = "Select cpropietario,cnombre,crif,ctelefonos,cemail,cdatenac,cdateapert,cdc_fot_rif,cdc_fot_rm,cdc_fot_tipcarnet,cdc_fot_cedula,cdc_fot_titulocamion,cdc_fot_carncir,cdc_seg_respciv,cdc_fot_liccondu,cdc_fot_cartmedi,cdc_fot_revptj,cdc_fot_certsalud,cdc_seg_rcv,cdc_carta_buecon,cdc_carta_recomend,cdc_refe_personales,cdc_refe_comercia,cdc_refe_bancaria,cdc_tele_movistar,cactivate,cdc_fec_liccondu,cdc_fec_certsalud,cdc_fot_permsanit,cdc_fec_permsanit,cdc_fec_rcv,cdelete from TTRANSPORTISTA where cplaca='" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString() + "' and ccedula='" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    DataRow _Row = _Ds.Tables[0].Rows[0];
                    _Txt_Placa.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    _Txt_Cedula.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    _Txt_Nombre.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    _Chbox_Propietario.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["cpropietario"].ToString()));
                    _Chbox_Activo.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["cactivate"].ToString()));
                    //__________________
                    if (_Row[2].ToString() != "0")
                    {
                        string[] _Str_Vector = _Row[2].ToString().Split(new char[] { '-' });
                        _Cmb_Rif.SelectedItem = _Str_Vector[0].ToString();
                        _Txt_Rif1.Text = _Str_Vector[1].ToString();
                        if (_Str_Vector.Length == 3)
                        {
                            _Txt_Rif2.Text = _Str_Vector[2].ToString();
                        }
                    }
                    else
                    {
                        _Txt_Rif2.Text = "";
                        _Txt_Rif1.Text = "";
                        _Cmb_Rif.SelectedIndex = -1;
                    }
                    //__________________
                    _Txt_Telefono.Text = _Row[3].ToString();
                    //____________________
                    _Txt_Transporte.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[2].Value.ToString();
                    _Txt_Email.Text = _Row["cemail"].ToString();
                    _Dtp_Nacimiento.Value = Convert.ToDateTime(_Row["cdatenac"].ToString());
                    _Dtp_Licencia.Value = Convert.ToDateTime(_Row["cdc_fec_liccondu"].ToString());
                    _Dtp_Rcv.Value = Convert.ToDateTime(_Row["cdc_fec_rcv"].ToString());
                    _Dtp_Salud.Value = Convert.ToDateTime(_Row["cdc_fec_certsalud"].ToString());
                    _Dtp_Sanitario.Value = Convert.ToDateTime(_Row["cdc_fec_permsanit"].ToString());
                }
                _Str_Cadena = "Select cdc_fot_rif,cdc_fot_rm,cdc_fot_tipcarnet,cdc_fot_cedula,cdc_fot_titulocamion,cdc_fot_carncir,cdc_seg_respciv,cdc_fot_liccondu,cdc_fot_cartmedi,cdc_fot_revptj,cdc_fot_certsalud,cdc_seg_rcv,cdc_carta_buecon,cdc_carta_recomend,cdc_refe_personales,cdc_refe_comercia,cdc_refe_bancaria,cdc_tele_movistar,cdc_fot_permsanit from TTRANSPORTISTA where cdelete='0' and cplaca='" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString() + "' and ccedula='" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    DataRow _Row = _Ds.Tables[0].Rows[0];
                    foreach (Control _Ctrl in groupBox1.Controls)
                    {
                        ((CheckBox)_Ctrl).Checked = Convert.ToBoolean(Convert.ToInt32(_Row[Convert.ToInt32(((CheckBox)_Ctrl).Tag)].ToString()));
                    }
                }
                //if (!_Bol_Tabs)
                //{
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                //}
                _Tb_Tab.SelectedIndex = 1;
                Cursor = Cursors.Default;
            }
            
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_Txt_Cedula.Text.Trim().Length == 0 & !_Txt_Cedula.Enabled & e.TabPageIndex != 0)
            { e.Cancel = true; }
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
    }
}