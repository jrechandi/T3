using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_TabuladoresDespacho : Form
    {
        public Frm_TabuladoresDespacho()
        {
            InitializeComponent();
        }
        private void _Mtd_Actualizar()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Ruta");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidrutdespacho";
            _Str_Campos[1] = "cdescripcion";
            string _Str_Cadena = "SELECT TTABULADESPACHO.cidrutdespacho AS Ruta, TRUTDESPACHOM.cdescripcion AS Descripción " +
"FROM TTABULADESPACHO INNER JOIN " +
"TRUTDESPACHOM ON TTABULADESPACHO.cgroupcomp = TRUTDESPACHOM.cgroupcomp AND " +
"TTABULADESPACHO.cidrutdespacho = TRUTDESPACHOM.cidrutdespacho " +
"WHERE (TTABULADESPACHO.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') and TTABULADESPACHO.cdelete='0'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Rutas", _Tsm_Menu, _Dg_Grid,true,"");
            //___________________________________
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
        private void _Mtd_Ini_Checks(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Ini_Checks(_Ctrl);
                }
                else if (_Ctrl.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)_Ctrl).Checked = false;
                }
            }
        }
        private void _Mtd_Configurar_Checks(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Configurar_Checks(_Ctrl);
                }
                else if (_Ctrl.GetType() == typeof(CheckBox))
                {
                    _Mtd_Configurar((CheckBox)_Ctrl);
                }
            }
        }
        private void _Mtd_Configurar(CheckBox _P_ChBox_Check)
        {
            _P_ChBox_Check.CheckedChanged += new EventHandler(_P_ChBox_Check_CheckedChanged);
        }

        void _P_ChBox_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            { ((CheckBox)sender).Text = "Fijo"; }
            else
            { ((CheckBox)sender).Text = "Variable"; }
        }
        private void _Mtd_Ini_Text(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Ini_Text(_Ctrl);
                }
                else if (_Ctrl.GetType() == typeof(TextBox))
                {
                    ((TextBox)_Ctrl).Text = "";
                }
            }
        }
        private void _Mtd_Formato()
        {
            for (int _Int_i = 1; _Int_i <= 10; _Int_i++)
            {
                new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Moneda((TextBox)this.Controls.Find("_Txt_B" + _Int_i, true)[0]);
                new CLASES._Cls_Varios_Metodos(true)._Mtd_Formato_Porcentaje((TextBox)this.Controls.Find("_Txt_P" + _Int_i, true)[0]);
            }
        }
        private void _Mtd_Cargar_Ruta_Nuevo()
        {
            _Cmb_Ruta.DataSource = null;
            DataSet _Ds;
            string _Str_Cadena = "SELECT cidrutdespacho,cdescripcion FROM TRUTDESPACHOM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cdelete=0 and not exists(Select cidrutdespacho from TTABULADESPACHO where TTABULADESPACHO.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TTABULADESPACHO.cidrutdespacho=TRUTDESPACHOM.cidrutdespacho) ORDER BY cdescripcion ASC";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Cmb_Ruta.DataSource = _Ds.Tables[0];
            _Cmb_Ruta.DisplayMember = "cdescripcion";
            _Cmb_Ruta.ValueMember = "cidrutdespacho";
            _Cmb_Ruta.SelectedIndex = -1;
        }
        private void _Mtd_Cargar_Ruta_Igualar()
        {
            _Cmb_Ruta.DataSource = null;
            DataSet _Ds;
            string _Str_Cadena = "SELECT cidrutdespacho,cdescripcion FROM TRUTDESPACHOM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' ORDER BY cdescripcion ASC";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Cmb_Ruta.DataSource = _Ds.Tables[0];
            _Cmb_Ruta.DisplayMember = "cdescripcion";
            _Cmb_Ruta.ValueMember = "cidrutdespacho";
            _Cmb_Ruta.SelectedIndex = -1;
        }
        private void _Mtd_Cargar_Ruta_Copiar()
        {
            _Cmb_Ruta_Copiar.DataSource = null;
            DataSet _Ds;
            string _Str_Cadena = "SELECT cidrutdespacho,cdescripcion FROM TRUTDESPACHOM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and exists(Select cidrutdespacho from TTABULADESPACHO where TTABULADESPACHO.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and TTABULADESPACHO.cidrutdespacho=TRUTDESPACHOM.cidrutdespacho) ORDER BY cdescripcion ASC";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Cmb_Ruta_Copiar.DataSource = _Ds.Tables[0];
            _Cmb_Ruta_Copiar.DisplayMember = "cdescripcion";
            _Cmb_Ruta_Copiar.ValueMember = "cidrutdespacho";
            _Cmb_Ruta_Copiar.SelectedIndex = -1;
        }
        public void _Mtd_Cancelar()
        {
            _Mtd_Ini();
            _Mtd_Deshabilitar_Todo();
            _Tb_Tab.SelectTab(0);
        }
        public void _Mtd_Ini()
        {
            _Mtd_Ini_Checks(this);
            _Mtd_Ini_Text(this);
            _Mtd_Cargar_Ruta_Nuevo();
            _Mtd_Habilitar();
            _Cmb_Ruta.Enabled = true;
        }
        public void _Mtd_Habilitar()
        {
            _Cmb_Ruta.Enabled = false;
            _Grb_1.Enabled = true;
            _Grb_2.Enabled = true;
            _Bt_Copiar.Enabled = true;
        }
        private void _Mtd_Deshabilitar_Todo()
        {
            _Cmb_Ruta.Enabled = false;
            _Grb_1.Enabled = false;
            _Grb_2.Enabled = false;
            _Bt_Copiar.Enabled = false;
        }
        public void _Mtd_Nuevo()
        {
            _Er_Error.Dispose();
            _Mtd_Ini();
            _Tb_Tab.SelectedIndex = 1;
            _Cmb_Ruta.Focus();
        }
        private bool _Mtd_Verificar()
        {
            bool _Bol_Sw = true;
            for (int _Int_i = 1; _Int_i <= 10; _Int_i++)
            {
                if (((TextBox)this.Controls.Find("_Txt_B" + _Int_i, true)[0]).Text.Trim().Length == 0)
                { ((TextBox)this.Controls.Find("_Txt_B" + _Int_i, true)[0]).Text = "0"; }
                if (((TextBox)this.Controls.Find("_Txt_P" + _Int_i, true)[0]).Text.Trim().Length == 0)
                { ((TextBox)this.Controls.Find("_Txt_P" + _Int_i, true)[0]).Text = "0"; }
                //----------------------------------------------------------------------------------
                if (Convert.ToDouble(((TextBox)this.Controls.Find("_Txt_B" + _Int_i, true)[0]).Text) > 0 & ((TextBox)this.Controls.Find("_Txt_BDes" + _Int_i, true)[0]).Text.Trim().Length == 0)
                { _Er_Error.SetError(this.Controls.Find("_Txt_BDes" + _Int_i, true)[0], "Información requerida!!!"); _Bol_Sw = false; }
                if (Convert.ToDouble(((TextBox)this.Controls.Find("_Txt_P" + _Int_i, true)[0]).Text) > 0 & ((TextBox)this.Controls.Find("_Txt_PDes" + _Int_i, true)[0]).Text.Trim().Length == 0)
                { _Er_Error.SetError(this.Controls.Find("_Txt_PDes" + _Int_i, true)[0], "Información requerida!!!"); _Bol_Sw = false; }
            }
            return _Bol_Sw;
        }
        private string _Mtd_Insert()
        {
            string _Str_FactorB = "";
            string _Str_FactorP = "";
            string _Str_FactorBDes = "";
            string _Str_FactorPDes = "";
            string _Str_TipoB = "";
            string _Str_TipoP = "";
            //--------------------------
            string _Str_V_FactorB = "";
            string _Str_V_FactorP = "";
            string _Str_V_FactorBDes = "";
            string _Str_V_FactorPDes = "";
            string _Str_V_TipoB = "";
            string _Str_V_TipoP = "";
            for (int _Int_i = 1; _Int_i <= 10; _Int_i++)
            {
                //------------------------------------Campos----------------------------------------------
                _Str_FactorB = _Str_FactorB + "c_fact_num_" + _Int_i + ",";
                _Str_FactorP = _Str_FactorP + "c_fact_porc_" + _Int_i + ",";
                _Str_FactorBDes = _Str_FactorBDes + "c_fact_num_" + _Int_i + "_des,";
                _Str_FactorPDes = _Str_FactorPDes + "c_fact_porc_" + _Int_i + "_des,";
                _Str_TipoB = _Str_TipoB + "c_tipo_nfactor_" + _Int_i + ",";
                _Str_TipoP = _Str_TipoP + "c_tipo_pfactor_" + _Int_i + ",";
                //------------------------------------Valores---------------------------------------------
                _Str_V_FactorB = _Str_V_FactorB + "'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(((TextBox)this.Controls.Find("_Txt_B" + _Int_i, true)[0]).Text)) + "',";
                _Str_V_FactorP = _Str_V_FactorP + "'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(((TextBox)this.Controls.Find("_Txt_P" + _Int_i, true)[0]).Text)) + "',";
                _Str_V_FactorBDes = _Str_V_FactorBDes +"'"+ ((TextBox)this.Controls.Find("_Txt_BDes" + _Int_i, true)[0]).Text + "',";
                _Str_V_FactorPDes = _Str_V_FactorPDes +"'"+ ((TextBox)this.Controls.Find("_Txt_PDes" + _Int_i, true)[0]).Text + "',";
                _Str_V_TipoB = _Str_V_TipoB +"'"+ Convert.ToInt32(((CheckBox)this.Controls.Find("_Chbox_B" + _Int_i, true)[0]).Checked).ToString() + "',";
                _Str_V_TipoP = _Str_V_TipoP +"'"+ Convert.ToInt32(((CheckBox)this.Controls.Find("_Chbox_P" + _Int_i, true)[0]).Checked).ToString() + "',";
            }
            return "Insert Into TTABULADESPACHO (cgroupcomp,cidrutdespacho," + _Str_FactorB + _Str_FactorP + _Str_FactorBDes + _Str_FactorPDes + _Str_TipoB + _Str_TipoP + "cdateadd,cuseradd,cdelete) values ('" + Frm_Padre._Str_GroupComp + "','" + _Cmb_Ruta.SelectedValue + "'," + _Str_V_FactorB + _Str_V_FactorP + _Str_V_FactorBDes + _Str_V_FactorPDes + _Str_V_TipoB + _Str_V_TipoP + "'" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + Frm_Padre._Str_Use + "','0')";
        }
        private string _Mtd_Update()
        {
            string _Str_FactorB = "";
            string _Str_FactorP = "";
            string _Str_FactorBDes = "";
            string _Str_FactorPDes = "";
            string _Str_TipoB = "";
            string _Str_TipoP = "";
            for (int _Int_i = 1; _Int_i <= 10; _Int_i++)
            {
                //------------------------------------Campos con valores----------------------------------------------
                _Str_FactorB = _Str_FactorB + "c_fact_num_" + _Int_i + "='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(((TextBox)this.Controls.Find("_Txt_B" + _Int_i, true)[0]).Text)) + "',";
                _Str_FactorP = _Str_FactorP + "c_fact_porc_" + _Int_i + "='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(((TextBox)this.Controls.Find("_Txt_P" + _Int_i, true)[0]).Text)) + "',";
                _Str_FactorBDes = _Str_FactorBDes + "c_fact_num_" + _Int_i + "_des='" + ((TextBox)this.Controls.Find("_Txt_BDes" + _Int_i, true)[0]).Text + "',";
                _Str_FactorPDes = _Str_FactorPDes + "c_fact_porc_" + _Int_i + "_des='" + ((TextBox)this.Controls.Find("_Txt_PDes" + _Int_i, true)[0]).Text + "',";
                _Str_TipoB = _Str_TipoB + "c_tipo_nfactor_" + _Int_i + "='" + Convert.ToInt32(((CheckBox)this.Controls.Find("_Chbox_B" + _Int_i, true)[0]).Checked).ToString() + "',";
                _Str_TipoP = _Str_TipoP + "c_tipo_pfactor_" + _Int_i + "='" + Convert.ToInt32(((CheckBox)this.Controls.Find("_Chbox_P" + _Int_i, true)[0]).Checked).ToString() + "',";
            }
            return "Update TTABULADESPACHO Set " + _Str_FactorB + _Str_FactorP + _Str_FactorBDes + _Str_FactorPDes + _Str_TipoB + _Str_TipoP + "cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrutdespacho='" + _Cmb_Ruta.SelectedValue + "'";
        }
        private void _Mtd_Igualar(string _P_Str_Ruta)
        {
            string _Str_Cadena = "Select * from TTABULADESPACHO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrutdespacho='" + _P_Str_Ruta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                for (int _Int_i = 1; _Int_i <= 10; _Int_i++)
                {
                    if (_Ds.Tables[0].Rows[0]["c_fact_num_" + _Int_i] != System.DBNull.Value)
                    {
                        ((TextBox)this.Controls.Find("_Txt_B" + _Int_i, true)[0]).Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["c_fact_num_" + _Int_i]).ToString("#,##0.00");
                    }
                    else
                    {
                        ((TextBox)this.Controls.Find("_Txt_B" + _Int_i, true)[0]).Text = "0,00";
                    }
                    ((TextBox)this.Controls.Find("_Txt_P" + _Int_i, true)[0]).Text = _Ds.Tables[0].Rows[0]["c_fact_porc_" + _Int_i].ToString();
                    ((TextBox)this.Controls.Find("_Txt_BDes" + _Int_i, true)[0]).Text = _Ds.Tables[0].Rows[0]["c_fact_num_" + _Int_i + "_des"].ToString();
                    ((TextBox)this.Controls.Find("_Txt_PDes" + _Int_i, true)[0]).Text = _Ds.Tables[0].Rows[0]["c_fact_porc_" + _Int_i + "_des"].ToString();
                    ((CheckBox)this.Controls.Find("_Chbox_B" + _Int_i, true)[0]).Checked = Convert.ToBoolean(Convert.ToInt32(_Ds.Tables[0].Rows[0]["c_tipo_nfactor_" + _Int_i].ToString()));
                    ((CheckBox)this.Controls.Find("_Chbox_P" + _Int_i, true)[0]).Checked = Convert.ToBoolean(Convert.ToInt32(_Ds.Tables[0].Rows[0]["c_tipo_pfactor_" + _Int_i].ToString()));
                }
            }
        }
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            if (_Cmb_Ruta.SelectedIndex!=-1 & _Mtd_Verificar())
            {
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("select * from TTABULADESPACHO where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrutdespacho='" + _Cmb_Ruta.SelectedValue.ToString() + "'"))
                {
                    MessageBox.Show("El registro ya existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Mtd_Insert());
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
                if (_Cmb_Ruta.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Ruta, "Información requerida!!!"); }
                return false;
            }
        }
        public bool _Mtd_Editar()
        {
            _Er_Error.Dispose();
            if (_Cmb_Ruta.SelectedIndex != -1 & _Mtd_Verificar())
            {
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Mtd_Update());
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
                if (_Cmb_Ruta.SelectedIndex == -1) { _Er_Error.SetError(_Cmb_Ruta, "Información requerida!!!"); }
                return false;
            }
        }
        public bool _Mtd_Eliminar()
        {
            DialogResult eli = MessageBox.Show("Esta seguro de Eliminar el registro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (eli == DialogResult.Yes)
            {
                string _Str_Cadena = "Update TTABULADESPACHO Set cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrutdespacho='" + _Cmb_Ruta.SelectedValue.ToString() + "'";
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
        private void Frm_TabuladoresDespacho_Load(object sender, EventArgs e)
        {
            _Pnl_Copiar.Left = (this.Width / 2) - (_Pnl_Copiar.Width / 2);
            _Pnl_Copiar.Top = (this.Height / 2) - (_Pnl_Copiar.Height / 2);
            _Mtd_Color_Estandar(this);
            _Mtd_Configurar_Checks(this);
            _Mtd_Actualizar();
            _Mtd_Formato();
        }

        private void Frm_TabuladoresDespacho_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Txt_TpoFind.Text = "PA";
            CONTROLES._Ctrl_Buscar._Er_Control_Error = _Er_Error;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            //____________________________________________
            if (!_Txt_B1.Enabled & _Txt_B1.Text.Trim().Length > 0)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
            }
            else if (!_Cmb_Ruta.Enabled & _Cmb_Ruta.SelectedIndex != -1 & _Txt_B1.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
            }
            else if (_Cmb_Ruta.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            }
            //_____________________________________________
        }

        private void Frm_TabuladoresDespacho_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.CurrentCell != null)
            {
                Cursor = Cursors.WaitCursor;
                _Er_Error.Dispose();
                _Mtd_Deshabilitar_Todo();
                _Mtd_Cargar_Ruta_Igualar();
                _Cmb_Ruta.SelectedValue = _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex);
                _Mtd_Igualar(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0,e.RowIndex));
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                _Tb_Tab.SelectedIndex = 1;
                Cursor = Cursors.Default;
            }
        }

        private void _Pnl_Copiar_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Copiar.Visible)
            { _Tb_Tab.Enabled = false; _Mtd_Cargar_Ruta_Copiar(); _Cmb_Ruta_Copiar.Focus(); }
            else
            { _Tb_Tab.Enabled = true; }
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Copiar.Visible = false;
        }

        private void _Bt_Copiar_P_Click(object sender, EventArgs e)
        {
            if (_Cmb_Ruta_Copiar.SelectedIndex != -1)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Igualar(_Cmb_Ruta_Copiar.SelectedValue.ToString()); _Pnl_Copiar.Visible = false;
                Cursor = Cursors.Default;
            }
            else
            { MessageBox.Show("Debe seleccionar una ruta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void _Bt_Copiar_Click(object sender, EventArgs e)
        {
            if (_Cmb_Ruta.SelectedIndex != -1)
            { _Pnl_Copiar.Visible = true; }
            else
            { MessageBox.Show("Debe seleccionar una ruta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_Cmb_Ruta.Text.Trim().Length == 0 & !_Cmb_Ruta.Enabled & e.TabPageIndex != 0)
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