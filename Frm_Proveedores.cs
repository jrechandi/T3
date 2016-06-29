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
    public partial class Frm_Proveedores : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        bool _Bol_Bol = false;
        string _G_Str_cglobal = "";
        public Frm_Proveedores()
        {
            InitializeComponent();
            _Bol_Bol = true;
            _Mtd_Actualizar(3);
            //_Mtd_Color_Estandar(_Tb_Tab);
            _Mtd_Cargar_Bancos();
            _Mtd_Cargar_Cmb_Contribuyente();
            _Mtd_Cargar_Cmb_Grupo();
            _Mtd_Cargar_Cmb_TipPro();
            _Mtd_CargarPlanAhorro();
        }
        public Frm_Proveedores(bool _Bol_Tabs)
        {
            InitializeComponent();
            _Rbt_Materia.Visible = false;
            _Dg_Grid.ContextMenuStrip = contextMenuStrip1;
            this.Name = "Proveedoress";
            _Mtd_Actualizar_Tabs(3);
            //_Mtd_Color_Estandar(_Tb_Tab);
            //_Mtd_Desactivar_CheckdePanels(_Grb_Visitas);
            //_Mtd_Desactivar_CheckdePanels(_Grb_Despacho);
            _Mtd_Cargar_Bancos();
            _Mtd_Cargar_Cmb_Contribuyente();
            _Mtd_Cargar_Cmb_Grupo();
            _Mtd_Cargar_Cmb_TipPro();
            _Mtd_CargarPlanAhorro();
        }
        private void _Mtd_Color_Estandar(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Color_Estandar(_Ctrl);
                }
                if (_Ctrl.Name != "_Rbt_Todos" & _Ctrl.Name != "_Rbt_Materia" & _Ctrl.Name != "_Rbt_Servicio" & _Ctrl.Name != "_Rbt_Otros")
                {
                    new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco();
                }
            }
        }
        public void _Mtd_Cargar_Cmb_TipPro()
        {
            _Cmb_TipPro.DataSource = null;
            _Cmb_TipPro.DisplayMember = "descripcion";
            _Cmb_TipPro.ValueMember = "clave";
            _Cmb_TipPro.DataSource = _Mtd_Comb_Tipo().Tables[0];
            _Cmb_TipPro.SelectedValue = "nulo";
        }
        public void _Mtd_Cargar_Cmb_Categ(string _P_Str_Tipo)
        {
            _Cmb_Categ.DataSource = null;
            DataSet _Ds;
            DataRow _Row;
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select ccatproveedor,cnombre from TCATPROVEEDOR where cdelete='0' and cglobal='" + _P_Str_Tipo + "'");
            _Row = _Ds.Tables[0].NewRow();
            _Row["cnombre"] = "...";
            _Row["ccatproveedor"] = "0";
            _Ds.Tables[0].Rows.Add(_Row);
            _Cmb_Categ.DataSource = _Ds.Tables[0];
            _Cmb_Categ.DisplayMember = "cnombre";
            _Cmb_Categ.ValueMember = "ccatproveedor";
            _Cmb_Categ.SelectedValue = "0";
        }
        private void _Mtd_Cargar_Cmb_Contribuyente()
        {
            _Cmb_Contribuyente.DataSource = null;
            DataSet _Ds;
            DataRow _Row;
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select ccontribuyente,cname from TCONTRIBUYENTE where cdelete='0'");
            _Row = _Ds.Tables[0].NewRow();
            _Row["cname"] = "...";
            _Row["ccontribuyente"] = "0";
            _Ds.Tables[0].Rows.Add(_Row);
            _Cmb_Contribuyente.DataSource = _Ds.Tables[0];
            _Cmb_Contribuyente.DisplayMember = "cname";
            _Cmb_Contribuyente.ValueMember = "ccontribuyente";
            _Cmb_Contribuyente.SelectedValue = "0";
        }
        private void _Mtd_Cargar_Cmb_Grupo()
        {
            _Cmb_Grupo.DataSource = null;
            DataSet _Ds;
            DataRow _Row;
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cgrupovta,cname from TGRUPOVTAM where cdelete='0'");
            _Row = _Ds.Tables[0].NewRow();
            _Row["cname"] = "...";
            _Row["cgrupovta"] = "0";
            _Ds.Tables[0].Rows.Add(_Row);
            _Cmb_Grupo.DataSource = _Ds.Tables[0];
            _Cmb_Grupo.DisplayMember = "cname";
            _Cmb_Grupo.ValueMember = "cgrupovta";
            _Cmb_Grupo.SelectedValue = "0";
        }
        private void _Mtd_Cargar_Bancos()
        {
            _Cmb_Banco1.DataSource = null;
            _Cmb_Banco2.DataSource = null;
            _Cmb_Banco3.DataSource = null;
            DataSet _Ds;
            DataRow _Row;
                //--------------------------------------
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cbanco,cname from TBANCO where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "'");
            _Row = _Ds.Tables[0].NewRow();
            _Row["cname"] = "...";
            _Row["cbanco"] = "0";
            _Ds.Tables[0].Rows.Add(_Row);
            _Cmb_Banco1.DataSource = _Ds.Tables[0];
            _Cmb_Banco1.DisplayMember = "cname";
            _Cmb_Banco1.ValueMember = "cbanco";
            _Cmb_Banco1.SelectedValue = "0";
            //---------------------------------------
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cbanco,cname from TBANCO where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "'");
            _Row = _Ds.Tables[0].NewRow();
            _Row["cname"] = "...";
            _Row["cbanco"] = "0";
            _Ds.Tables[0].Rows.Add(_Row);
            _Cmb_Banco2.DataSource = _Ds.Tables[0];
            _Cmb_Banco2.DisplayMember = "cname";
            _Cmb_Banco2.ValueMember = "cbanco";
            _Cmb_Banco2.SelectedValue = "0";
            //---------------------------------------
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cbanco,cname from TBANCO where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "'");
            _Row = _Ds.Tables[0].NewRow();
            _Row["cname"] = "...";
            _Row["cbanco"] = "0";
            _Ds.Tables[0].Rows.Add(_Row);
            _Cmb_Banco3.DataSource = _Ds.Tables[0];
            _Cmb_Banco3.DisplayMember = "cname";
            _Cmb_Banco3.ValueMember = "cbanco";
            _Cmb_Banco3.SelectedValue = "0";
        }
        private DataSet _Mtd_Comb_Tipo()
        {
            DataSet _Ds_ = new DataSet();
            _Ds_.Tables.Add("Tabla");
            _Ds_.Tables[0].Columns.Add("clave");
            _Ds_.Tables[0].Columns.Add("descripcion");
            DataRow _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["clave"] = "0";
            _DRow_["descripcion"] = "Servicio";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["clave"] = "1";
            _DRow_["descripcion"] = "Materia Prima";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["clave"] = "2";
            _DRow_["descripcion"] = "Otros";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            _DRow_ = _Ds_.Tables[0].NewRow();
            _DRow_["clave"] = "nulo";
            _DRow_["descripcion"] = "...";
            _Ds_.Tables[0].Rows.Add(_DRow_);
            return _Ds_;
        }
        private void _Mtd_CargarPlanAhorro()
        {
            Cursor = Cursors.WaitCursor;
            _Cmb_PlanAhorro.DataSource = null;
            string _Str_Cadena = "select cidplanahorro,CONVERT(VARCHAR,cporcentaje)+'%' AS cporcentaje from TPLANAHORROTRANS where ccompany='" + Frm_Padre._Str_Comp + "' and isnull(cdelete,0)=0 ORDER BY cporcentaje";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            DataRow _Row = _Ds.Tables[0].NewRow();
            _Row["cporcentaje"] = "...";
            _Row["cidplanahorro"] = 0;
            List<DataRow> lista = _Ds.Tables[0].Rows.Cast<DataRow>().ToList();
            lista.Insert(0, _Row);
            var datos = from campos in lista select new { cidplanahorro = campos["cidplanahorro"], cporcentaje = campos["cporcentaje"] };
            _Cmb_PlanAhorro.DataSource = datos.ToList();
            _Cmb_PlanAhorro.DisplayMember = "cporcentaje";
            _Cmb_PlanAhorro.ValueMember = "cidplanahorro";
            _Cmb_PlanAhorro.SelectedValue = 0;
            Cursor = Cursors.Default;
        }
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
        private void Frm_Proveedores2_Load(object sender, EventArgs e)
        {
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            if (!CLASES._Cls_Varios_Metodos._Mtd_EstaActivoRetencionesPatente())
            {
                _Tb_Tab.TabPages[4].Hide();
                _Txt_RUC.Enabled = false;
                _Txt_Patente.Enabled = false;
                _Mtd_HabilitarPatentePorcentaje(false);   
            }            
        }
        private void _Mtd_Actualizar(int _P_Int_I)
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Rif");
            _Tsm_Menu[2] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "TPROVEEDOR.cproveedor";
            _Str_Campos[1] = "TPROVEEDOR.c_rif";
            _Str_Campos[2] = "TPROVEEDOR.c_nomb_comer";
            string _Str_Cadena = "";
            if (_P_Int_I == 3)
            {
                _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor as Código,c_rif as Rif,c_nomb_comer as Descripción,CASE cglobal WHEN 0 THEN 'Servicio' ELSE CASE cglobal WHEN 1 THEN 'Materia Prima' ELSE 'Otros' END END as Tipo FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND ((cglobal='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "') OR (cglobal<>'1' AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "'))";
            }
            else if (_P_Int_I == 1)
            {
                _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor as Código,c_rif as Rif,c_nomb_comer as Descripción,CASE cglobal WHEN 0 THEN 'Servicio' ELSE CASE cglobal WHEN 1 THEN 'Materia Prima' ELSE 'Otros' END END as Tipo FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND ((cglobal='1' AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "'))";

            }
            else
            {
                _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor as Código,c_rif as Rif,c_nomb_comer as Descripción,CASE cglobal WHEN 0 THEN 'Servicio' ELSE CASE cglobal WHEN 1 THEN 'Materia Prima' ELSE 'Otros' END END as Tipo FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND ((cglobal='" + _P_Int_I.ToString() + "' AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "'))";
            }
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "", _Tsm_Menu, _Dg_Grid, true, "", "Descripción");
            //_Str_Cadena = "Select cproveedor as Código,c_rif as Rif,c_nomb_abreviado as Descripción,CASE cglobal WHEN 0 THEN 'Servicio' ELSE CASE cglobal WHEN 1 THEN 'Materia Prima' ELSE 'Otros' END END as Tipo from TPROVEEDOR where (cdelete='0' and casignado='1' and ccompany='" + Frm_Padre._Str_Comp + "') or (cglobal='" + _P_Int_I.ToString() + "' and cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "')";

        }
        private void _Mtd_Actualizar_Tabs(int _P_Int_I)
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Rif");
            _Tsm_Menu[2] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "TPROVEEDOR.cproveedor";
            _Str_Campos[1] = "TPROVEEDOR.c_rif";
            _Str_Campos[2] = "TPROVEEDOR.c_nomb_abreviado";
            string _Str_Cadena = "";
            if (_P_Int_I == 3)
            {
                _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor as Código,c_rif as Rif,c_nomb_abreviado as Descripción,CASE cglobal WHEN 0 THEN 'Servicio' ELSE 'Otros' END as Tipo FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND ((cglobal<>'1' AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "'))";
            }
            else
            {
                _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor as Código,c_rif as Rif,c_nomb_abreviado as Descripción,CASE cglobal WHEN 0 THEN 'Servicio' ELSE 'Otros' END as Tipo FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND ((cglobal='" + _P_Int_I.ToString() + "' AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "'))";
            }
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "", _Tsm_Menu, _Dg_Grid, true, "", "Descripción");
            //if (_Dg_Grid.Rows.Count == 0)
            //{
            //    this.Close();
            //}
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
            _Mtd_Deshabilitar_Todo();
        }
        public void _Mtd_Ini()
        {
            _Cmb_Rif1.SelectedIndex = -1;
            _Mtd_Inicializar_Controles(_Tb_Tab);
            _Mtd_Cargar_Bancos();
            _Mtd_Cargar_Cmb_Contribuyente();
            _Mtd_Cargar_Cmb_Grupo();
            _Mtd_Cargar_Cmb_TipPro();
            _Mtd_CargarPlanAhorro();
            _Mtd_Habilitar();
            _G_Str_cglobal = "";
            _Txt_Codigo.Enabled = true;
            _Cmb_Categ.Enabled = true;
            _Cmb_TipPro.Enabled = true;
            _Txt_Count.Text = "";
            _Txt_Count.Tag = "";
            _Mtd_BotonesMenu();
        }
        public void _Mtd_Habilitar()
        {
            if (_G_Str_cglobal == "1")
            {
                _Bt_Count.Enabled = false;
            }
            else
            {
                _Bt_Count.Enabled = true;
            }
            _Rbt_0.Enabled = true;
            _Rbt_75.Enabled = true;
            _Rbt_100.Enabled = true;
            _Tb_Tab.SelectedIndex = 3;
            groupBox10.Enabled = true;
            _Lbl_PlanAhorro.Enabled = true;
            _Cmb_PlanAhorro.Enabled = true;
            if (CLASES._Cls_Varios_Metodos._Mtd_EstaActivoRetencionesPatente())
            {
                if (_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1")
                {
                    if (_Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_MODIF_PATPROV"))
                    {
                        _Txt_Patente.Enabled = true;
                        _Mtd_HabilitarPatentePorcentaje(true);
                        _Txt_RUC.Enabled = true;
                        _Chk_RetencionMunicipal.Enabled = true;
                    }
                    else
                    {
                        _Txt_Patente.Enabled = false;
                        _Mtd_HabilitarPatentePorcentaje(false);
                        _Txt_RUC.Enabled = false;
                        _Chk_RetencionMunicipal.Enabled = false;
                    }
                }
                else
                {
                    _Txt_Patente.Enabled = false;
                    _Mtd_HabilitarPatentePorcentaje(false);
                    _Txt_RUC.Enabled = false;
                    _Chk_RetencionMunicipal.Enabled = false;
                }
            }
            else
            {
                _Txt_Patente.Enabled = false;
                _Mtd_HabilitarPatentePorcentaje(false);
                _Txt_RUC.Enabled = false;
                _Chk_RetencionMunicipal.Enabled = false;
            }
        }
        public void _Mtd_Nuevo()
        {
            //_Er_Error.Dispose();
            //_Mtd_Ini();
            //_Tb_Tab.SelectedIndex = 1;
            //_Cmb_TipPro.Focus();
        }
        private void _Mtd_Deshabilitar_Todo()
        {
            _Mtd_Habilitar_0_Deshabilitar_Controles(_Tb_Tab, false);
            _Num_Compra.Enabled = false;
            _Num_Invendible.Enabled = false;
            _Num_Mal.Enabled = false;
            _Mtd_HabilitarPatentePorcentaje(false);
            _Txt_RUC.Enabled = false;
            _Txt_Patente.Enabled = false;
            _Txt_CodActEconomica.Enabled = false;
        }
        private void _Mtd_Inicializar_Controles(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                { _Mtd_Inicializar_Controles(_Ctrl); }
                else
                {
                    if (_Ctrl.GetType() == typeof(TextBox))
                    { ((TextBox)_Ctrl).Text = ""; }
                    //else if (_Ctrl.GetType() == typeof(ComboBox))
                    //{ ((ComboBox)_Ctrl).SelectedValue = "0"; }
                    else if (_Ctrl.GetType() == typeof(CheckBox))
                    { ((CheckBox)_Ctrl).Checked = false; }
                    else if (_Ctrl.GetType()== typeof(NumericUpDown))
                    { ((NumericUpDown)_Ctrl).Value = 0; }
                    else if (_Ctrl.GetType() == typeof(RadioButton))
                    { ((RadioButton)_Ctrl).Checked = false; }
                }
            }
        }
        private void _Mtd_Habilitar_0_Deshabilitar_Controles(Control _P_Ctrl_Control,bool _P_Bol_Boleano)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.GetType() != typeof(T3.Controles._Ctrl_Busqueda) & _Ctrl.GetType() != typeof(DataGridView))
                {
                    if (_Ctrl.Controls.Count > 0)
                    { _Mtd_Habilitar_0_Deshabilitar_Controles(_Ctrl, _P_Bol_Boleano); }
                    else
                    {
                        if ( _Ctrl.Name != "_Rbt_Todos" & _Ctrl.Name != "_Rbt_Materia" & _Ctrl.Name != "_Rbt_Servicio" & _Ctrl.Name != "_Rbt_Otros")
                        {
                            _Ctrl.Enabled = _P_Bol_Boleano;
                        }
                    }
                }
            }
        }
        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Codigo");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "ccliente";
            _Str_Campos[1] = "c_nomb_comer";
            string _Str_Cadena = "Select ccliente as Código,c_nomb_comer as Descripción from TCLIENTE where cdelete='0' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
            Frm_Busqueda _Frm = new Frm_Busqueda(_Txt_Cod_Cliente, _Txt_Des_Cliente, _Str_Cadena, _Str_Campos, "Clientes", _Tsm_Menu, 0, 1);
            _Frm.MdiParent = this.MdiParent;
            _Frm.Show();
        }

        private void _Cmb_TipPro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_TipPro.DataSource != null)
            {
                if (_Cmb_TipPro.SelectedValue.ToString().Trim() == "1" | _Cmb_TipPro.SelectedValue.ToString().Trim() == "nulo")
                { _Cmb_TipPro.SelectedValue = "nulo"; _Cmb_Categ.DataSource = null; }
                else
                {
                    _Mtd_Cargar_Cmb_Categ(_Cmb_TipPro.SelectedValue.ToString());
                }
            }
        }
        private void Frm_Proveedores2_Activated(object sender, EventArgs e)
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

            if (!_Txt_NombComercial.Enabled & _Txt_NombComercial.Text.Trim().Length > 0)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
            }
            else if (!_Txt_Codigo.Enabled & _Txt_Codigo.Text.Trim().Length > 0 & _Txt_NombComercial.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
            }
            else if (_Txt_Codigo.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            }
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
            ////_____________________________________________
            //CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            //CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            //CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            //CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        string _Str_V_Lunes = "", _Str_V_Martes = "", _Str_V_Miercoles, _Str_V_Jueves = "", _Str_V_Viernes = "", _Str_V_Sabado = "";
        string _Str_D_Lunes = "", _Str_D_Martes = "", _Str_D_Miercoles, _Str_D_Jueves = "", _Str_D_Viernes = "", _Str_D_Sabado = "";
        private void _Mtd_Configurar_Checks()
        {
            if (_Chbox_V_Lunes.Checked)
            { _Str_V_Lunes = "LUNES, 7 AM A 6 PM"; }
            if (_Chbox_V_Martes.Checked)
            { _Str_V_Martes = "MARTES, 7 AM A 6 PM"; }
            if (_Chbox_V_Miercoles.Checked)
            { _Str_V_Miercoles = "MIERCOLES, 7 AM A 6 PM"; }
            if (_Chbox_V_Jueves.Checked)
            { _Str_V_Jueves = "JUEVES, 7 AM A 6 PM"; }
            if (_Chbox_V_Viernes.Checked)
            { _Str_V_Viernes = "VIERNES, 7 AM A 6 PM"; }
            if (_Chbox_V_Sabado.Checked)
            { _Str_V_Sabado = "SÁBADO, 7 AM A 6 PM"; }
            //-----------------------------------------
            if (_Chbox_D_Lunes.Checked)
            { _Str_D_Lunes = "LUNES, 7 AM A 6 PM"; }
            if (_Chbox_D_Martes.Checked)
            { _Str_D_Martes = "MARTES, 7 AM A 6 PM"; }
            if (_Chbox_D_Miercoles.Checked)
            { _Str_D_Miercoles = "MIERCOLES, 7 AM A 6 PM"; }
            if (_Chbox_D_Jueves.Checked)
            { _Str_D_Jueves = "JUEVES, 7 AM A 6 PM"; }
            if (_Chbox_D_Viernes.Checked)
            { _Str_D_Viernes = "VIERNES, 7 AM A 6 PM"; }
            if (_Chbox_D_Sabado.Checked)
            { _Str_D_Sabado = "SÁBADO, 7 AM A 6 PM"; }
        }
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            int _Int_Por_Iva = 3;
            if (_Rbt_0.Checked)
            { _Int_Por_Iva = 1; }
            else if (_Rbt_75.Checked)
            { _Int_Por_Iva = 75; }
            else if (_Rbt_100.Checked)
            { _Int_Por_Iva = 100; }
            if (_Txt_Dias_Credito.Text.Trim().Length == 0)
            { _Txt_Dias_Credito.Text = "0"; }
            if (_Txt_Dias_Despacho.Text.Trim().Length == 0)
            { _Txt_Dias_Despacho.Text = "0"; }
            if (_Txt_Limite.Text.Trim().Length == 0)
            { _Txt_Limite.Text = "0"; }
            if (_Txt_D_Pronto.Text.Trim().Length == 0)
            { _Txt_D_Pronto.Text = "0"; }
            if (_Txt_Cod_Cliente.Text.Trim().Length == 0)
            { _Txt_Cod_Cliente.Text = "0"; }
            if (_Cmb_Banco1.SelectedIndex == -1 & _Cmb_Banco1.DataSource != null)
            { _Cmb_Banco1.SelectedValue = "0"; }
            if (_Cmb_Banco2.SelectedIndex == -1 & _Cmb_Banco2.DataSource != null)
            { _Cmb_Banco2.SelectedValue = "0"; }
            if (_Cmb_Banco3.SelectedIndex == -1 & _Cmb_Banco3.DataSource != null)
            { _Cmb_Banco3.SelectedValue = "0"; }
            if (_Cmb_Categ.SelectedIndex == -1 & _Cmb_Categ.DataSource != null)
            { _Cmb_Categ.SelectedValue = "0"; }
            if (_Cmb_Contribuyente.SelectedIndex == -1 & _Cmb_Contribuyente.DataSource != null)
            { _Cmb_Contribuyente.SelectedValue = "0"; }
            if (_Cmb_Grupo.SelectedIndex == -1 & _Cmb_Grupo.DataSource != null)
            { _Cmb_Grupo.SelectedValue = "0"; }
            if (_Cmb_TipPro.SelectedIndex == -1 & _Cmb_TipPro.DataSource != null)
            { _Cmb_TipPro.SelectedValue = "nulo"; }
            if (_Cmb_TipPro.SelectedValue.ToString().Trim() == "0" & _Cmb_Categ.DataSource!=null)
            {
                if (_Cmb_Categ.SelectedValue.ToString() != "0")
                {
                    _Mtd_Entrada("S", _Cmb_Categ.SelectedValue.ToString().Trim());
                }
            }
            else if (_Cmb_TipPro.SelectedValue.ToString().Trim() == "2" & _Cmb_Categ.DataSource!=null)
            {
                if (_Cmb_Categ.SelectedValue.ToString() != "0")
                {
                    _Mtd_Entrada("O", _Cmb_Categ.SelectedValue.ToString().Trim());
                }
            }
            string _Str_Rif="";
            if (_Cmb_Rif1.SelectedIndex != -1 & _Txt_Rif2.Text.Trim().Length > 0 & _Txt_Rif3.Text.Trim().Length > 0)
            { _Str_Rif = _Cmb_Rif1.SelectedItem.ToString().Trim() + "-" + _Txt_Rif2.Text.Trim() + "-" + _Txt_Rif3.Text.Trim(); }
            else
            { _Str_Rif = ""; }
            _Mtd_Configurar_Checks();

            //-------------------------------------------------------------------------
            string _Str_Categoria = "Si";
            if (_Cmb_Categ.DataSource == null)
            {
                _Str_Categoria = "No";
            }
            bool _Bol_ValidoPatente = true;
            string _Str_RetienePatente = "0";
            if (CLASES._Cls_Varios_Metodos._Mtd_EstaActivoRetencionesPatente())
            {
                if (_Chk_RetencionMunicipal.Checked)
                {
                    if (_Txt_RetencionPat.Value > 0)
                    {
                        _Bol_ValidoPatente = true;
                        _Str_RetienePatente = "1";
                    }
                    else
                    {
                        _Bol_ValidoPatente = false;
                        _Str_RetienePatente = "0";
                        _Er_Error.SetError(_Txt_RetencionPat, "Información requerida!!!"); 
                    }
                }
            }
            if (_Cmb_TipPro.SelectedValue.ToString().Trim() == "0")
            {
                if (_Bol_ValidoPatente & _Int_Por_Iva != 3 & _Cmb_TipPro.SelectedValue.ToString().Trim() != "nulo" & _Str_Categoria != "No" & _Txt_NombComercial.Text.Trim().Length > 0 & _Txt_Nomb_Abreviado.Text.Trim().Length > 0 & _Txt_NombFiscal.Text.Trim().Length > 0 & _Txt_Dir_Comercial.Text.Trim().Length > 0 & _Txt_Dir_Fiscal.Text.Trim().Length > 0 & _Txt_Telefono.Text.Trim().Length > 0 & _Txt_Inf_Cont1.Text.Trim().Length > 0 & _Txt_Dias_Credito.Text.Trim().Length > 0 & _Txt_Limite.Text.Trim().Length > 0 & _Txt_Count.Text.Trim().Length > 0 & _Cmb_Contribuyente.SelectedValue.ToString().Trim() != "0" & _Str_Rif.Trim().Length > 0 & (_Chbox_V_Lunes.Checked | _Chbox_V_Martes.Checked | _Chbox_V_Miercoles.Checked | _Chbox_V_Jueves.Checked | _Chbox_V_Viernes.Checked | _Chbox_V_Sabado.Checked) & (_Chbox_D_Lunes.Checked | _Chbox_D_Martes.Checked | _Chbox_D_Miercoles.Checked | _Chbox_D_Jueves.Checked | _Chbox_D_Viernes.Checked | _Chbox_D_Sabado.Checked))
                {
                    
                    if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("Select * from TPROVEEDOR where cproveedor='" + _Txt_Codigo.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "'"))
                    {
                        MessageBox.Show("El registro ya existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else
                    {
                        string _Str_Cadena = "insert into TPROVEEDOR (ccompany,cproveedor,c_rif,c_nit,c_nomb_comer,c_nomb_fiscal,c_nomb_abreviado,c_direcc_comer,c_direcc_fiscal,c_telefono,c_fax,c_email,c_www,c_inf_replegal,c_info_cont_1,c_info_cont_2,c_info_cont_3,c_banco_1,c_banco_2,c_banco_3,c_cuenta_1,c_cuenta_2,c_cuenta_3,c_lun_visita,c_mar_visita,c_mie_visita,c_jue_visita,c_vie_visita,c_sab_visita,c_lun_despa,c_mar_despa,c_mie_despa,c_juev_despa,c_vie_despa,c_sab_despa,cglobal,c_activo,c_fech_inicio,c_dia_credito,c_limt_credit,c_des_ppago,ctcount,c_notas,ccliente,cgrupovta,c_tip_contribuy,ccatproveedor,cporcinvendible,cporincvolcomp,cpjuridica,cdomiciliada,cdiasdespa,cdateadd,cuseradd,cdelete,cporcenreteniva,cpordevmalestado,cidplanahorro,cporcenretpat,cnumpatente,cretienepatente,cnumruc) values('" + Frm_Padre._Str_Comp + "','" + _Txt_Codigo.Text.Trim() + "','" + _Str_Rif + "','" + _Txt_Nit.Text.Trim() + "','" + _Txt_NombComercial.Text.Trim() + "','" + _Txt_NombFiscal.Text.Trim() + "','" + _Txt_NombFiscal.Text.Trim() + "','" + _Txt_Dir_Comercial.Text.Trim() + "','" + _Txt_Dir_Fiscal.Text.Trim() + "','" + _Txt_Telefono.Text.Trim() + "','" + _Txt_Fax.Text.Trim() + "','" + _Txt_Email.Text.Trim() + "','" + _Txt_Url.Text.Trim() + "','" + _Txt_Representante.Text.Trim().ToUpper() + "','" + _Txt_Inf_Cont1.Text.Trim().ToUpper() + "','" + _Txt_Inf_Cont2.Text.Trim().ToUpper() + "','" + _Txt_Inf_Cont3.Text.Trim().ToUpper() + "','" + _Cmb_Banco1.SelectedValue.ToString() + "','" + _Cmb_Banco2.SelectedValue.ToString() + "','" + _Cmb_Banco3.SelectedValue.ToString() + "','" + _Txt_Cuenta1.Text.Trim() + "','" + _Txt_Cuenta2.Text.Trim() + "','" + _Txt_Cuenta3.Text.Trim() + "','" + _Str_V_Lunes + "','" + _Str_V_Martes + "','" + _Str_V_Miercoles + "','" + _Str_V_Jueves + "','" + _Str_V_Viernes + "','" + _Str_V_Sabado + "','" + _Str_D_Lunes + "','" + _Str_D_Martes + "','" + _Str_D_Miercoles + "','" + _Str_D_Jueves + "','" + _Str_D_Viernes + "','" + _Str_D_Sabado + "','" + _Cmb_TipPro.SelectedValue.ToString() + "','" + Convert.ToInt32(_Chbox_Activo.Checked).ToString() + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_FecIni.Value) + "','" + _Txt_Dias_Credito.Text.Trim() + "','" + _Txt_Limite.Text.Trim() + "','" + _Txt_D_Pronto.Text.Trim() + "','" + _Txt_Count.Tag.ToString().Trim() + "','" + _Txt_Notas.Text.Trim().ToUpper() + "','" + _Txt_Cod_Cliente.Text.Trim() + "','" + _Cmb_Grupo.SelectedValue.ToString() + "','" + _Cmb_Contribuyente.SelectedValue.ToString() + "','" + _Cmb_Categ.SelectedValue.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Num_Invendible.Value.ToString())) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Num_Compra.Value.ToString())) + "','" + Convert.ToInt32(_Rb_P_Juridica.Checked).ToString() + "','" + Convert.ToInt32(_Rb_Domiciliado.Checked).ToString() + "','" + _Txt_Dias_Despacho.Text.Trim() + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + _Int_Por_Iva.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Num_Mal.Value.ToString())) + "','" + Convert.ToString(_Cmb_PlanAhorro.SelectedValue).Trim() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_RetencionPat.Value.ToString())) + "','" + _Txt_Patente.Text + "','" + _Str_RetienePatente + "','" + _Txt_RUC.Text + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        MessageBox.Show("El registro fue agregado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (!_Bol_Bol)
                        {
                            _Mtd_Actualizar_Tabs(_Int_Acualizar);
                        }
                        else
                        {
                            _Mtd_Actualizar(_Int_Acualizar);
                        }
                        _Mtd_Ini();
                        _Mtd_Deshabilitar_Todo();
                        _Tb_Tab.SelectedIndex = 0;
                        _Er_Error.Dispose();
                        return true;
                    }
                }
                else
                {
                    if (_Cmb_TipPro.SelectedValue.ToString() == "nulo") { _Er_Error.SetError(_Cmb_TipPro, "Información requerida!!!"); }
                    if (_Cmb_Categ.DataSource != null) 
                    {
                        if (_Cmb_Categ.SelectedValue.ToString() == "0")
                        {
                            _Er_Error.SetError(_Cmb_Categ, "Información requerida!!!");
                        }
                    }
                    if (_Txt_NombComercial.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_NombComercial, "Información requerida!!!"); }
                    if (_Txt_Nomb_Abreviado.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Nomb_Abreviado, "Información requerida!!!"); }
                    if (_Txt_NombFiscal.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_NombFiscal, "Información requerida!!!"); }
                    if (_Txt_Dir_Comercial.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Dir_Comercial, "Información requerida!!!"); }
                    if (_Txt_Dir_Fiscal.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Dir_Fiscal, "Información requerida!!!"); }
                    if (_Txt_Telefono.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Telefono, "Información requerida!!!"); }
                    if (_Txt_Inf_Cont1.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Inf_Cont1, "Información requerida!!!"); }
                    if (_Txt_Dias_Credito.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Dias_Credito, "Información requerida!!!"); }
                    if (_Txt_Limite.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Limite, "Información requerida!!!"); }
                    if (_Txt_Count.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Count, "Información requerida!!!"); }
                    if (_Cmb_Contribuyente.SelectedValue.ToString() == "0") { _Er_Error.SetError(_Cmb_Contribuyente, "Información requerida!!!"); }
                    if (_Str_Rif.Trim().Length < 1) { _Er_Error.SetError(_Txt_Rif3, "Información requerida!!!"); }
                    if (!(_Chbox_V_Lunes.Checked | _Chbox_V_Martes.Checked | _Chbox_V_Miercoles.Checked | _Chbox_V_Jueves.Checked | _Chbox_V_Viernes.Checked | _Chbox_V_Sabado.Checked)) { _Er_Error.SetError(_Chbox_V_Sabado, "Información requerida!!!"); }
                    if (!(_Chbox_D_Lunes.Checked | _Chbox_D_Martes.Checked | _Chbox_D_Miercoles.Checked | _Chbox_D_Jueves.Checked | _Chbox_D_Viernes.Checked | _Chbox_D_Sabado.Checked)) { _Er_Error.SetError(_Chbox_D_Sabado, "Información requerida!!!"); }
                    if (_Int_Por_Iva == 3) { _Er_Error.SetError(_Rbt_75, "Información requerida!!!"); _Er_Error.SetError(_Rbt_100, "Información requerida!!!"); _Er_Error.SetError(_Rbt_0, "Información requerida!!!"); }
                    //--------------------------------------------------------
                    if (_Txt_NombComercial.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_Nomb_Abreviado.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_NombFiscal.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_Dir_Comercial.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_Dir_Fiscal.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_Telefono.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_Inf_Cont1.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 2; }
                    else if (_Txt_Dias_Credito.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 3; }
                    else if (_Txt_Limite.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 3; }
                    else if (_Txt_Count.Text.Trim().Length == 0) { _Tb_Tab.SelectedIndex = 3; }
                    else if (_Cmb_Contribuyente.SelectedValue.ToString() == "0") { _Tb_Tab.SelectedIndex = 3; }
                    else if (_Str_Rif.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (!(_Chbox_V_Lunes.Checked | _Chbox_V_Martes.Checked | _Chbox_V_Miercoles.Checked | _Chbox_V_Jueves.Checked | _Chbox_V_Viernes.Checked | _Chbox_V_Sabado.Checked)) { _Tb_Tab.SelectedIndex = 2; }
                    else if (!(_Chbox_D_Lunes.Checked | _Chbox_D_Martes.Checked | _Chbox_D_Miercoles.Checked | _Chbox_D_Jueves.Checked | _Chbox_D_Viernes.Checked | _Chbox_D_Sabado.Checked)) { _Tb_Tab.SelectedIndex = 2; }
                    else if (_Cmb_TipPro.SelectedValue.ToString() == "nulo") { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Cmb_Categ.DataSource != null)
                    {
                        if (_Cmb_Categ.SelectedValue.ToString() == "0")
                        {
                            _Tb_Tab.SelectedIndex = 1;
                        }
                    }
                    else if (_Int_Por_Iva == 3) { _Tb_Tab.SelectedIndex = 3; }
                    return false;
                }
            }
            else
            {
                if (_Bol_ValidoPatente & _Int_Por_Iva != 3 & _Cmb_TipPro.SelectedValue.ToString().Trim() != "nulo" & _Str_Categoria != "No" & _Txt_NombComercial.Text.Trim().Length > 0 & _Txt_Nomb_Abreviado.Text.Trim().Length > 0 & _Txt_NombFiscal.Text.Trim().Length > 0 & _Txt_Dir_Comercial.Text.Trim().Length > 0 & _Txt_Dir_Fiscal.Text.Trim().Length > 0 & _Txt_Telefono.Text.Trim().Length > 0 & _Txt_Inf_Cont1.Text.Trim().Length > 0 & _Txt_Dias_Credito.Text.Trim().Length > 0 & _Txt_Limite.Text.Trim().Length > 0 & _Cmb_Contribuyente.SelectedValue.ToString().Trim() != "0" & _Str_Rif.Trim().Length > 0 & (_Chbox_V_Lunes.Checked | _Chbox_V_Martes.Checked | _Chbox_V_Miercoles.Checked | _Chbox_V_Jueves.Checked | _Chbox_V_Viernes.Checked | _Chbox_V_Sabado.Checked) & (_Chbox_D_Lunes.Checked | _Chbox_D_Martes.Checked | _Chbox_D_Miercoles.Checked | _Chbox_D_Jueves.Checked | _Chbox_D_Viernes.Checked | _Chbox_D_Sabado.Checked))
                {
                    if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("Select * from TPROVEEDOR where cproveedor='" + _Txt_Codigo.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "'"))
                    {
                        MessageBox.Show("El registro ya existe", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else
                    {
                        string _Str_Cadena = "insert into TPROVEEDOR (ccompany,cproveedor,c_rif,c_nit,c_nomb_comer,c_nomb_fiscal,c_nomb_abreviado,c_direcc_comer,c_direcc_fiscal,c_telefono,c_fax,c_email,c_www,c_inf_replegal,c_info_cont_1,c_info_cont_2,c_info_cont_3,c_banco_1,c_banco_2,c_banco_3,c_cuenta_1,c_cuenta_2,c_cuenta_3,c_lun_visita,c_mar_visita,c_mie_visita,c_jue_visita,c_vie_visita,c_sab_visita,c_lun_despa,c_mar_despa,c_mie_despa,c_juev_despa,c_vie_despa,c_sab_despa,cglobal,c_activo,c_fech_inicio,c_dia_credito,c_limt_credit,c_des_ppago,ctcount,c_notas,ccliente,cgrupovta,c_tip_contribuy,ccatproveedor,cporcinvendible,cporincvolcomp,cpjuridica,cdomiciliada,cdiasdespa,cdateadd,cuseradd,cdelete,cporcenreteniva,cpordevmalestado,cporcenretpat,cnumpatente,cretienepatente,cnumruc) values('" + Frm_Padre._Str_Comp + "','" + _Txt_Codigo.Text.Trim() + "','" + _Str_Rif + "','" + _Txt_Nit.Text.Trim() + "','" + _Txt_NombComercial.Text.Trim() + "','" + _Txt_NombFiscal.Text.Trim() + "','" + _Txt_NombFiscal.Text.Trim() + "','" + _Txt_Dir_Comercial.Text.Trim() + "','" + _Txt_Dir_Fiscal.Text.Trim() + "','" + _Txt_Telefono.Text.Trim() + "','" + _Txt_Fax.Text.Trim() + "','" + _Txt_Email.Text.Trim() + "','" + _Txt_Url.Text.Trim() + "','" + _Txt_Representante.Text.Trim().ToUpper() + "','" + _Txt_Inf_Cont1.Text.Trim().ToUpper() + "','" + _Txt_Inf_Cont2.Text.Trim().ToUpper() + "','" + _Txt_Inf_Cont3.Text.Trim().ToUpper() + "','" + _Cmb_Banco1.SelectedValue.ToString() + "','" + _Cmb_Banco2.SelectedValue.ToString() + "','" + _Cmb_Banco3.SelectedValue.ToString() + "','" + _Txt_Cuenta1.Text.Trim() + "','" + _Txt_Cuenta2.Text.Trim() + "','" + _Txt_Cuenta3.Text.Trim() + "','" + _Str_V_Lunes + "','" + _Str_V_Martes + "','" + _Str_V_Miercoles + "','" + _Str_V_Jueves + "','" + _Str_V_Viernes + "','" + _Str_V_Sabado + "','" + _Str_D_Lunes + "','" + _Str_D_Martes + "','" + _Str_D_Miercoles + "','" + _Str_D_Jueves + "','" + _Str_D_Viernes + "','" + _Str_D_Sabado + "','" + _Cmb_TipPro.SelectedValue.ToString() + "','" + Convert.ToInt32(_Chbox_Activo.Checked).ToString() + "','" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_FecIni.Value) + "','" + _Txt_Dias_Credito.Text.Trim() + "','" + _Txt_Limite.Text.Trim() + "','" + _Txt_D_Pronto.Text.Trim() + "','" + _Txt_Count.Tag.ToString().Trim() + "','" + _Txt_Notas.Text.Trim().ToUpper() + "','" + _Txt_Cod_Cliente.Text.Trim() + "','" + _Cmb_Grupo.SelectedValue.ToString() + "','" + _Cmb_Contribuyente.SelectedValue.ToString() + "','" + _Cmb_Categ.SelectedValue.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Num_Invendible.Value.ToString())) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Num_Compra.Value.ToString())) + "','" + Convert.ToInt32(_Rb_P_Juridica.Checked).ToString() + "','" + Convert.ToInt32(_Rb_Domiciliado.Checked).ToString() + "','" + _Txt_Dias_Despacho.Text.Trim() + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0','" + _Int_Por_Iva.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Num_Mal.Value.ToString())) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_RetencionPat.Value.ToString())) + "','" + _Txt_Patente.Text + "','" + _Str_RetienePatente + "','" + _Txt_RUC.Text + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        MessageBox.Show("El registro fue agregado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (!_Bol_Bol)
                        {
                            _Mtd_Actualizar_Tabs(_Int_Acualizar);
                        }
                        else
                        {
                            _Mtd_Actualizar(_Int_Acualizar);
                        }
                        _Mtd_Ini();
                        _Mtd_Deshabilitar_Todo();
                        _Tb_Tab.SelectedIndex = 0;
                        _Er_Error.Dispose();
                        return true;
                    }
                }
                else
                {
                    if (_Cmb_TipPro.SelectedValue.ToString() == "nulo") { _Er_Error.SetError(_Cmb_TipPro, "Información requerida!!!"); }
                    if (_Cmb_Categ.DataSource != null)
                    {
                        if (_Cmb_Categ.SelectedValue.ToString() == "0")
                        {
                            _Er_Error.SetError(_Cmb_Categ, "Información requerida!!!");
                        }
                    } 
                    if (_Txt_NombComercial.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_NombComercial, "Información requerida!!!"); }
                    if (_Txt_Nomb_Abreviado.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Nomb_Abreviado, "Información requerida!!!"); }
                    if (_Txt_NombFiscal.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_NombFiscal, "Información requerida!!!"); }
                    if (_Txt_Dir_Comercial.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Dir_Comercial, "Información requerida!!!"); }
                    if (_Txt_Dir_Fiscal.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Dir_Fiscal, "Información requerida!!!"); }
                    if (_Txt_Telefono.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Telefono, "Información requerida!!!"); }
                    if (_Txt_Inf_Cont1.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Inf_Cont1, "Información requerida!!!"); }
                    if (_Txt_Dias_Credito.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Dias_Credito, "Información requerida!!!"); }
                    if (_Txt_Limite.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Limite, "Información requerida!!!"); }
                    if (_Cmb_Contribuyente.SelectedValue.ToString() == "0") { _Er_Error.SetError(_Cmb_Contribuyente, "Información requerida!!!"); }
                    if (_Str_Rif.Trim().Length < 1) { _Er_Error.SetError(_Txt_Rif3, "Información requerida!!!"); }
                    if (!(_Chbox_V_Lunes.Checked | _Chbox_V_Martes.Checked | _Chbox_V_Miercoles.Checked | _Chbox_V_Jueves.Checked | _Chbox_V_Viernes.Checked | _Chbox_V_Sabado.Checked)) { _Er_Error.SetError(_Chbox_V_Sabado, "Información requerida!!!"); }
                    if (!(_Chbox_D_Lunes.Checked | _Chbox_D_Martes.Checked | _Chbox_D_Miercoles.Checked | _Chbox_D_Jueves.Checked | _Chbox_D_Viernes.Checked | _Chbox_D_Sabado.Checked)) { _Er_Error.SetError(_Chbox_D_Sabado, "Información requerida!!!"); }
                    if (_Int_Por_Iva == 3) { _Er_Error.SetError(_Rbt_75, "Información requerida!!!"); _Er_Error.SetError(_Rbt_100, "Información requerida!!!"); _Er_Error.SetError(_Rbt_0, "Información requerida!!!");  }
                    //--------------------------------------------------------
                    if (_Txt_NombComercial.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_Nomb_Abreviado.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_NombFiscal.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_Dir_Comercial.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_Dir_Fiscal.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_Telefono.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_Inf_Cont1.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 2; }
                    else if (_Txt_Dias_Credito.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 3; }
                    else if (_Txt_Limite.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 3; }
                    else if (_Cmb_Contribuyente.SelectedValue.ToString() == "0") { _Tb_Tab.SelectedIndex = 3; }
                    else if (_Str_Rif.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (!(_Chbox_V_Lunes.Checked | _Chbox_V_Martes.Checked | _Chbox_V_Miercoles.Checked | _Chbox_V_Jueves.Checked | _Chbox_V_Viernes.Checked | _Chbox_V_Sabado.Checked)) { _Tb_Tab.SelectedIndex = 2; }
                    else if (!(_Chbox_D_Lunes.Checked | _Chbox_D_Martes.Checked | _Chbox_D_Miercoles.Checked | _Chbox_D_Jueves.Checked | _Chbox_D_Viernes.Checked | _Chbox_D_Sabado.Checked)) { _Tb_Tab.SelectedIndex = 2; }
                    else if (_Cmb_TipPro.SelectedValue.ToString() == "nulo") { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Cmb_Categ.DataSource != null)
                    {
                        if (_Cmb_Categ.SelectedValue.ToString() == "0")
                        {
                            _Tb_Tab.SelectedIndex = 1;
                        }
                    }
                    else if (_Int_Por_Iva == 3) { _Tb_Tab.SelectedIndex = 3; }
                    return false;
                }
            }
        }
        public bool _Mtd_Editar()
        {
            _Er_Error.Dispose();
            int _Int_Por_Iva = 3;
            if (_Rbt_0.Checked)
            { _Int_Por_Iva = 1; }
            else if (_Rbt_75.Checked)
            { _Int_Por_Iva = 75; }
            else if (_Rbt_100.Checked)
            { _Int_Por_Iva = 100; }
            if (_Cmb_Banco1.SelectedIndex == -1 & _Cmb_Banco1.DataSource != null)
            { _Cmb_Banco1.SelectedValue = "0"; }
            if (_Cmb_Banco2.SelectedIndex == -1 & _Cmb_Banco2.DataSource != null)
            { _Cmb_Banco2.SelectedValue = "0"; }
            if (_Cmb_Banco3.SelectedIndex == -1 & _Cmb_Banco3.DataSource != null)
            { _Cmb_Banco3.SelectedValue = "0"; }
            if (_Cmb_Categ.SelectedIndex == -1 & _Cmb_Categ.DataSource != null)
            { _Cmb_Categ.SelectedValue = "0"; }
            if (_Cmb_Contribuyente.SelectedIndex == -1 & _Cmb_Contribuyente.DataSource != null)
            { _Cmb_Contribuyente.SelectedValue = "0"; }
            if (_Cmb_Grupo.SelectedIndex == -1 & _Cmb_Grupo.DataSource != null)
            { _Cmb_Grupo.SelectedValue = "0"; }
            if (_Cmb_TipPro.SelectedIndex == -1 & _Cmb_TipPro.DataSource != null)
            { _Cmb_TipPro.SelectedValue = "nulo"; }
            //if (_Cmb_TipPro.SelectedValue.ToString().Trim() == "0")
            //{ _Mtd_Entrada("S", _Cmb_Categ.SelectedValue.ToString().Trim()); }
            //else if (_Cmb_TipPro.SelectedValue.ToString().Trim() == "2")
            //{ _Mtd_Entrada("O", _Cmb_Categ.SelectedValue.ToString().Trim()); }
            string _Str_Rif = "";
            if (_Cmb_Rif1.SelectedIndex != -1 & _Txt_Rif2.Text.Trim().Length > 0 & _Txt_Rif3.Text.Trim().Length > 0)
            { _Str_Rif = _Cmb_Rif1.SelectedItem.ToString().Trim() + "-" + _Txt_Rif2.Text.Trim() + "-" + _Txt_Rif3.Text.Trim(); }
            else
            { _Str_Rif = ""; }
            _Mtd_Configurar_Checks();
            bool _Bol_ValidoPatente = true;
            string _Str_RetienePatente = "0";
            if (CLASES._Cls_Varios_Metodos._Mtd_EstaActivoRetencionesPatente())
            {
                if (_Chk_RetencionMunicipal.Checked)
                {
                    if (_Txt_RetencionPat.Value > 0)
                    {
                        _Bol_ValidoPatente = true;
                        _Str_RetienePatente = "1";
                    }
                    else
                    {
                        _Bol_ValidoPatente = false;
                        _Str_RetienePatente = "0";
                        _Er_Error.SetError(_Txt_RetencionPat, "Información requerida!!!");
                    }
                }
            }
            if (_Bol_ValidoPatente)
            {
                //-------------------------------------------------------------------------
                if (_Cmb_TipPro.SelectedValue.ToString().Trim() == "0")
                {
                    if (_Int_Por_Iva != 3)
                    {

                        string _Str_Cadena = "UPDATE TPROVEEDOR Set ccodactividadecono='"+_Txt_CodActEconomica.Text+"',cnumpatente='" + _Txt_Patente.Text + "',cnumruc='" + _Txt_RUC.Text + "',cporcenretpat='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_RetencionPat.Value.ToString())) + "',cretienepatente='" + _Str_RetienePatente + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',cporcenreteniva='" + _Int_Por_Iva.ToString() + "',ctcount='" + _Txt_Count.Tag.ToString().Trim() + "',cidplanahorro='" + Convert.ToString(_Cmb_PlanAhorro.SelectedValue).Trim() + "' where cproveedor='" + _Txt_Codigo.Text.Trim() + "'";
                        if (_G_Str_cglobal != "1")
                        {
                            _Str_Cadena = _Str_Cadena + " and ccompany='" + Frm_Padre._Str_Comp + "'";
                        }
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        MessageBox.Show("El registro fue modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (!_Bol_Bol)
                        {
                            _Mtd_Actualizar_Tabs(_Int_Acualizar);
                        }
                        else
                        {
                            _Mtd_Actualizar(_Int_Acualizar);
                        }
                        _Mtd_Ini();
                        _Mtd_Deshabilitar_Todo();
                        _Tb_Tab.SelectedIndex = 0;
                        _Er_Error.Dispose();
                        return true;
                    }
                    else
                    {
                        if (_Int_Por_Iva == 3) { _Er_Error.SetError(_Rbt_75, "Información requerida!!!"); _Er_Error.SetError(_Rbt_100, "Información requerida!!!"); _Er_Error.SetError(_Rbt_0, "Información requerida!!!"); }
                        //--------------------------------------------------------
                        else if (_Int_Por_Iva == 3) { _Tb_Tab.SelectedIndex = 3; }
                        return false;
                    }

                }
                else
                {
                    if (_Int_Por_Iva != 3)
                    {

                        string _Str_Cadena = "UPDATE TPROVEEDOR Set ccodactividadecono='" + _Txt_CodActEconomica.Text + "',cnumpatente='" + _Txt_Patente.Text + "',cnumruc='" + _Txt_RUC.Text + "',cporcenretpat='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_RetencionPat.Value.ToString())) + "',cretienepatente='" + _Str_RetienePatente + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',cporcenreteniva='" + _Int_Por_Iva.ToString() + "' where cproveedor='" + _Txt_Codigo.Text.Trim() + "'";
                        if (_G_Str_cglobal != "1")
                        {
                            _Str_Cadena = _Str_Cadena + " and ccompany='" + Frm_Padre._Str_Comp + "'";
                        }

                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        MessageBox.Show("El registro fue modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (!_Bol_Bol)
                        {
                            _Mtd_Actualizar_Tabs(_Int_Acualizar);
                        }
                        else
                        {
                            _Mtd_Actualizar(_Int_Acualizar);
                        }
                        _Mtd_Ini();
                        _Mtd_Deshabilitar_Todo();
                        _Tb_Tab.SelectedIndex = 0;
                        _Er_Error.Dispose();
                        return true;
                    }
                    else
                    {
                        if (_Int_Por_Iva == 3) { _Er_Error.SetError(_Rbt_75, "Información requerida!!!"); _Er_Error.SetError(_Rbt_100, "Información requerida!!!"); _Er_Error.SetError(_Rbt_0, "Información requerida!!!"); }
                        //--------------------------------------------------------
                        else if (_Int_Por_Iva == 3) { _Tb_Tab.SelectedIndex = 3; }
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
        public bool _Mtd_Editar_Antiguo()
        {
            _Er_Error.Dispose();
            int _Int_Por_Iva = 3;
            if (_Rbt_0.Checked)
            { _Int_Por_Iva = 1; }
            else if (_Rbt_75.Checked)
            { _Int_Por_Iva = 75; }
            else if (_Rbt_100.Checked)
            { _Int_Por_Iva = 100; }
            if (_Cmb_Banco1.SelectedIndex == -1 & _Cmb_Banco1.DataSource != null)
            { _Cmb_Banco1.SelectedValue = "0"; }
            if (_Cmb_Banco2.SelectedIndex == -1 & _Cmb_Banco2.DataSource != null)
            { _Cmb_Banco2.SelectedValue = "0"; }
            if (_Cmb_Banco3.SelectedIndex == -1 & _Cmb_Banco3.DataSource != null)
            { _Cmb_Banco3.SelectedValue = "0"; }
            if (_Cmb_Categ.SelectedIndex == -1 & _Cmb_Categ.DataSource != null)
            { _Cmb_Categ.SelectedValue = "0"; }
            if (_Cmb_Contribuyente.SelectedIndex == -1 & _Cmb_Contribuyente.DataSource != null)
            { _Cmb_Contribuyente.SelectedValue = "0"; }
            if (_Cmb_Grupo.SelectedIndex == -1 & _Cmb_Grupo.DataSource != null)
            { _Cmb_Grupo.SelectedValue = "0"; }
            if (_Cmb_TipPro.SelectedIndex == -1 & _Cmb_TipPro.DataSource != null)
            { _Cmb_TipPro.SelectedValue = "nulo"; }
            //if (_Cmb_TipPro.SelectedValue.ToString().Trim() == "0")
            //{ _Mtd_Entrada("S", _Cmb_Categ.SelectedValue.ToString().Trim()); }
            //else if (_Cmb_TipPro.SelectedValue.ToString().Trim() == "2")
            //{ _Mtd_Entrada("O", _Cmb_Categ.SelectedValue.ToString().Trim()); }
            string _Str_Rif = "";
            if (_Cmb_Rif1.SelectedIndex != -1 & _Txt_Rif2.Text.Trim().Length > 0 & _Txt_Rif3.Text.Trim().Length > 0)
            { _Str_Rif = _Cmb_Rif1.SelectedItem.ToString().Trim() + "-" + _Txt_Rif2.Text.Trim() + "-" + _Txt_Rif3.Text.Trim(); }
            else
            { _Str_Rif = ""; }
            _Mtd_Configurar_Checks();
            //-------------------------------------------------------------------------
            if (_Cmb_TipPro.SelectedValue.ToString().Trim() == "0")
            {
                if (_Int_Por_Iva != 3 & _Cmb_TipPro.SelectedValue.ToString().Trim() != "nulo" & _Cmb_Categ.SelectedValue.ToString().Trim() != "0" & _Txt_NombComercial.Text.Trim().Length > 0 & _Txt_Nomb_Abreviado.Text.Trim().Length > 0 & _Txt_NombFiscal.Text.Trim().Length > 0 & _Txt_Dir_Comercial.Text.Trim().Length > 0 & _Txt_Dir_Fiscal.Text.Trim().Length > 0 & _Txt_Telefono.Text.Trim().Length > 0 & _Txt_Inf_Cont1.Text.Trim().Length > 0 & _Txt_Dias_Credito.Text.Trim().Length > 0 & _Txt_Limite.Text.Trim().Length > 0 & _Txt_Count.Text.Trim().Length>0 & _Cmb_Contribuyente.SelectedValue.ToString().Trim() != "0" & _Str_Rif.Trim().Length > 0 & (_Chbox_V_Lunes.Checked | _Chbox_V_Martes.Checked | _Chbox_V_Miercoles.Checked | _Chbox_V_Jueves.Checked | _Chbox_V_Viernes.Checked | _Chbox_V_Sabado.Checked) & (_Chbox_D_Lunes.Checked | _Chbox_D_Martes.Checked | _Chbox_D_Miercoles.Checked | _Chbox_D_Jueves.Checked | _Chbox_D_Viernes.Checked | _Chbox_D_Sabado.Checked))
                {
                    string _Str_Cadena = "UPDATE TPROVEEDOR Set ccompany='" + Frm_Padre._Str_Comp + "',cproveedor='" + _Txt_Codigo.Text.Trim() + "',c_rif='" + _Str_Rif + "',c_nit='" + _Txt_Nit.Text.Trim() + "',c_nomb_comer='" + _Txt_NombComercial.Text.Trim().ToUpper() + "',c_nomb_fiscal='" + _Txt_NombFiscal.Text.Trim().ToUpper() + "',c_nomb_abreviado='" + _Txt_Nomb_Abreviado.Text.Trim().ToUpper() + "',c_direcc_comer='" + _Txt_Dir_Comercial.Text.Trim().ToUpper() + "',c_direcc_fiscal='" + _Txt_Dir_Fiscal.Text.Trim().ToUpper() + "',c_telefono='" + _Txt_Telefono.Text.Trim() + "',c_fax='" + _Txt_Fax.Text.Trim() + "',c_email='" + _Txt_Email.Text.Trim() + "',c_www='" + _Txt_Url.Text.Trim() + "',c_inf_replegal='" + _Txt_Representante.Text.Trim().ToUpper() + "',c_info_cont_1='" + _Txt_Inf_Cont1.Text.Trim().ToUpper() + "',c_info_cont_2='" + _Txt_Inf_Cont2.Text.Trim().ToUpper() + "',c_info_cont_3='" + _Txt_Inf_Cont3.Text.Trim().ToUpper() + "',c_banco_1='" + _Cmb_Banco1.SelectedValue.ToString() + "',c_banco_2='" + _Cmb_Banco2.SelectedValue.ToString() + "',c_banco_3='" + _Cmb_Banco3.SelectedValue.ToString() + "',c_cuenta_1='" + _Txt_Cuenta1.Text.Trim() + "',c_cuenta_2='" + _Txt_Cuenta2.Text.Trim() + "',c_cuenta_3='" + _Txt_Cuenta3.Text.Trim() + "',c_lun_visita='" + _Str_V_Lunes + "',c_mar_visita='" + _Str_V_Martes + "',c_mie_visita='" + _Str_V_Miercoles + "',c_jue_visita='" + _Str_V_Jueves + "',c_vie_visita='" + _Str_V_Viernes + "',c_sab_visita='" + _Str_V_Sabado + "',c_lun_despa='" + _Str_D_Lunes + "',c_mar_despa='" + _Str_D_Martes + "',c_mie_despa='" + _Str_D_Miercoles + "',c_juev_despa='" + _Str_D_Jueves + "',c_vie_despa='" + _Str_D_Viernes + "',c_sab_despa='" + _Str_D_Sabado + "',cglobal='" + _Cmb_TipPro.SelectedValue.ToString() + "',c_activo='" + Convert.ToInt32(_Chbox_Activo.Checked).ToString() + "',c_fech_inicio='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_FecIni.Value) + "',c_dia_credito='" + _Txt_Dias_Credito.Text.Trim() + "',c_limt_credit='" + _Txt_Limite.Text.Trim() + "',c_des_ppago='" + _Txt_D_Pronto.Text.Trim() + "',ctcount='" + _Txt_Count.Tag.ToString().Trim() + "',c_notas='" + _Txt_Notas.Text.Trim().ToUpper() + "',ccliente='" + _Txt_Cod_Cliente.Text.Trim() + "',cgrupovta='" + _Cmb_Grupo.SelectedValue.ToString() + "',c_tip_contribuy='" + _Cmb_Contribuyente.SelectedValue.ToString() + "',ccatproveedor='" + _Cmb_Categ.SelectedValue.ToString() + "',cporcinvendible='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Num_Invendible.Value.ToString())) + "',cpordevmalestado='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Num_Mal.Value.ToString())) + "',cporincvolcomp='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Num_Compra.Value.ToString())) + "',cpjuridica='" + Convert.ToInt32(_Rb_P_Juridica.Checked).ToString() + "',cdomiciliada='" + Convert.ToInt32(_Rb_Domiciliado.Checked).ToString() + "',cdiasdespa='" + _Txt_Dias_Despacho.Text.Trim() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',cporcenreteniva='" + _Int_Por_Iva.ToString() + "' where cproveedor='" + _Txt_Codigo.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    MessageBox.Show("El registro fue modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (!_Bol_Bol)
                    {
                        _Mtd_Actualizar_Tabs(_Int_Acualizar);
                    }
                    else
                    {
                        _Mtd_Actualizar(_Int_Acualizar);
                    }
                    _Mtd_Ini();
                    _Mtd_Deshabilitar_Todo();
                    _Tb_Tab.SelectedIndex = 0;
                    _Er_Error.Dispose();
                    return true;
                }
                else
                {
                    if (_Cmb_TipPro.SelectedValue.ToString() == "nulo") { _Er_Error.SetError(_Cmb_TipPro, "Información requerida!!!"); }
                    if (_Cmb_Categ.SelectedValue.ToString() == "0") { _Er_Error.SetError(_Cmb_Categ, "Información requerida!!!"); }
                    if (_Txt_NombComercial.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_NombComercial, "Información requerida!!!"); }
                    if (_Txt_Nomb_Abreviado.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Nomb_Abreviado, "Información requerida!!!"); }
                    if (_Txt_NombFiscal.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_NombFiscal, "Información requerida!!!"); }
                    if (_Txt_Dir_Comercial.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Dir_Comercial, "Información requerida!!!"); }
                    if (_Txt_Dir_Fiscal.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Dir_Fiscal, "Información requerida!!!"); }
                    if (_Txt_Telefono.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Telefono, "Información requerida!!!"); }
                    if (_Txt_Inf_Cont1.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Inf_Cont1, "Información requerida!!!"); }
                    if (_Txt_Dias_Credito.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Dias_Credito, "Información requerida!!!"); }
                    if (_Txt_Limite.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Limite, "Información requerida!!!"); }
                    if (_Txt_Count.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Count, "Información requerida!!!"); }
                    if (_Cmb_Contribuyente.SelectedValue.ToString() == "0") { _Er_Error.SetError(_Cmb_Contribuyente, "Información requerida!!!"); }
                    if (_Str_Rif.Trim().Length < 1) { _Er_Error.SetError(_Txt_Rif3, "Información requerida!!!"); }
                    if (!(_Chbox_V_Lunes.Checked | _Chbox_V_Martes.Checked | _Chbox_V_Miercoles.Checked | _Chbox_V_Jueves.Checked | _Chbox_V_Viernes.Checked | _Chbox_V_Sabado.Checked)) { _Er_Error.SetError(_Chbox_V_Sabado, "Información requerida!!!"); }
                    if (!(_Chbox_D_Lunes.Checked | _Chbox_D_Martes.Checked | _Chbox_D_Miercoles.Checked | _Chbox_D_Jueves.Checked | _Chbox_D_Viernes.Checked | _Chbox_D_Sabado.Checked)) { _Er_Error.SetError(_Chbox_D_Sabado, "Información requerida!!!"); }
                    if (_Int_Por_Iva == 3) { _Er_Error.SetError(_Rbt_75, "Información requerida!!!"); _Er_Error.SetError(_Rbt_100, "Información requerida!!!"); _Er_Error.SetError(_Rbt_0, "Información requerida!!!"); }
                    //--------------------------------------------------------
                    if (_Txt_NombComercial.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_Nomb_Abreviado.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_NombFiscal.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_Dir_Comercial.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_Dir_Fiscal.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_Telefono.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_Inf_Cont1.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 2; }
                    else if (_Txt_Dias_Credito.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 3; }
                    else if (_Txt_Limite.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 3; }
                    else if (_Txt_Count.Text.Trim().Length == 0) { _Tb_Tab.SelectedIndex = 3; }
                    else if (_Cmb_Contribuyente.SelectedValue.ToString() == "0") { _Tb_Tab.SelectedIndex = 3; }
                    else if (_Str_Rif.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (!(_Chbox_V_Lunes.Checked | _Chbox_V_Martes.Checked | _Chbox_V_Miercoles.Checked | _Chbox_V_Jueves.Checked | _Chbox_V_Viernes.Checked | _Chbox_V_Sabado.Checked)) { _Tb_Tab.SelectedIndex = 2; }
                    else if (!(_Chbox_D_Lunes.Checked | _Chbox_D_Martes.Checked | _Chbox_D_Miercoles.Checked | _Chbox_D_Jueves.Checked | _Chbox_D_Viernes.Checked | _Chbox_D_Sabado.Checked)) { _Tb_Tab.SelectedIndex = 2; }
                    else if (_Int_Por_Iva == 3) { _Tb_Tab.SelectedIndex = 3; }
                    return false;
                }

            }
            else
            {
                if (_Int_Por_Iva != 3 & _Cmb_TipPro.SelectedValue.ToString().Trim() != "nulo" & _Cmb_Categ.SelectedValue.ToString().Trim() != "0" & _Txt_NombComercial.Text.Trim().Length > 0 & _Txt_Nomb_Abreviado.Text.Trim().Length > 0 & _Txt_NombFiscal.Text.Trim().Length > 0 & _Txt_Dir_Comercial.Text.Trim().Length > 0 & _Txt_Dir_Fiscal.Text.Trim().Length > 0 & _Txt_Telefono.Text.Trim().Length > 0 & _Txt_Inf_Cont1.Text.Trim().Length > 0 & _Txt_Dias_Credito.Text.Trim().Length > 0 & _Txt_Limite.Text.Trim().Length > 0 & _Cmb_Contribuyente.SelectedValue.ToString().Trim() != "0" & _Str_Rif.Trim().Length > 0 & (_Chbox_V_Lunes.Checked | _Chbox_V_Martes.Checked | _Chbox_V_Miercoles.Checked | _Chbox_V_Jueves.Checked | _Chbox_V_Viernes.Checked | _Chbox_V_Sabado.Checked) & (_Chbox_D_Lunes.Checked | _Chbox_D_Martes.Checked | _Chbox_D_Miercoles.Checked | _Chbox_D_Jueves.Checked | _Chbox_D_Viernes.Checked | _Chbox_D_Sabado.Checked))
                {
                    string _Str_Cadena = "UPDATE TPROVEEDOR Set ccompany='" + Frm_Padre._Str_Comp + "',cproveedor='" + _Txt_Codigo.Text.Trim() + "',c_rif='" + _Str_Rif + "',c_nit='" + _Txt_Nit.Text.Trim() + "',c_nomb_comer='" + _Txt_NombComercial.Text.Trim().ToUpper() + "',c_nomb_fiscal='" + _Txt_NombFiscal.Text.Trim().ToUpper() + "',c_nomb_abreviado='" + _Txt_Nomb_Abreviado.Text.Trim().ToUpper() + "',c_direcc_comer='" + _Txt_Dir_Comercial.Text.Trim().ToUpper() + "',c_direcc_fiscal='" + _Txt_Dir_Fiscal.Text.Trim().ToUpper() + "',c_telefono='" + _Txt_Telefono.Text.Trim() + "',c_fax='" + _Txt_Fax.Text.Trim() + "',c_email='" + _Txt_Email.Text.Trim() + "',c_www='" + _Txt_Url.Text.Trim() + "',c_inf_replegal='" + _Txt_Representante.Text.Trim().ToUpper() + "',c_info_cont_1='" + _Txt_Inf_Cont1.Text.Trim().ToUpper() + "',c_info_cont_2='" + _Txt_Inf_Cont2.Text.Trim().ToUpper() + "',c_info_cont_3='" + _Txt_Inf_Cont3.Text.Trim().ToUpper() + "',c_banco_1='" + _Cmb_Banco1.SelectedValue.ToString() + "',c_banco_2='" + _Cmb_Banco2.SelectedValue.ToString() + "',c_banco_3='" + _Cmb_Banco3.SelectedValue.ToString() + "',c_cuenta_1='" + _Txt_Cuenta1.Text.Trim() + "',c_cuenta_2='" + _Txt_Cuenta2.Text.Trim() + "',c_cuenta_3='" + _Txt_Cuenta3.Text.Trim() + "',c_lun_visita='" + _Str_V_Lunes + "',c_mar_visita='" + _Str_V_Martes + "',c_mie_visita='" + _Str_V_Miercoles + "',c_jue_visita='" + _Str_V_Jueves + "',c_vie_visita='" + _Str_V_Viernes + "',c_sab_visita='" + _Str_V_Sabado + "',c_lun_despa='" + _Str_D_Lunes + "',c_mar_despa='" + _Str_D_Martes + "',c_mie_despa='" + _Str_D_Miercoles + "',c_juev_despa='" + _Str_D_Jueves + "',c_vie_despa='" + _Str_D_Viernes + "',c_sab_despa='" + _Str_D_Sabado + "',cglobal='" + _Cmb_TipPro.SelectedValue.ToString() + "',c_activo='" + Convert.ToInt32(_Chbox_Activo.Checked).ToString() + "',c_fech_inicio='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(_Dtp_FecIni.Value) + "',c_dia_credito='" + _Txt_Dias_Credito.Text.Trim() + "',c_limt_credit='" + _Txt_Limite.Text.Trim() + "',c_des_ppago='" + _Txt_D_Pronto.Text.Trim() + "',ctcount='" + _Txt_Count.Tag.ToString().Trim() + "',c_notas='" + _Txt_Notas.Text.Trim().ToUpper() + "',ccliente='" + _Txt_Cod_Cliente.Text.Trim() + "',cgrupovta='" + _Cmb_Grupo.SelectedValue.ToString() + "',c_tip_contribuy='" + _Cmb_Contribuyente.SelectedValue.ToString() + "',ccatproveedor='" + _Cmb_Categ.SelectedValue.ToString() + "',cporcinvendible='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Num_Invendible.Value.ToString())) + "',cpordevmalestado='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Num_Mal.Value.ToString())) + "',cporincvolcomp='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Num_Compra.Value.ToString())) + "',cpjuridica='" + Convert.ToInt32(_Rb_P_Juridica.Checked).ToString() + "',cdomiciliada='" + Convert.ToInt32(_Rb_Domiciliado.Checked).ToString() + "',cdiasdespa='" + _Txt_Dias_Despacho.Text.Trim() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete='0',cporcenreteniva='" + _Int_Por_Iva.ToString() + "' where cproveedor='" + _Txt_Codigo.Text.Trim() + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    MessageBox.Show("El registro fue modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (!_Bol_Bol)
                    {
                        _Mtd_Actualizar_Tabs(_Int_Acualizar);
                    }
                    else
                    {
                        _Mtd_Actualizar(_Int_Acualizar);
                    }
                    _Mtd_Ini();
                    _Mtd_Deshabilitar_Todo();
                    _Tb_Tab.SelectedIndex = 0;
                    _Er_Error.Dispose();
                    return true;
                }
                else
                {
                    if (_Cmb_TipPro.SelectedValue.ToString() == "nulo") { _Er_Error.SetError(_Cmb_TipPro, "Información requerida!!!"); }
                    if (_Cmb_Categ.SelectedValue.ToString() == "0") { _Er_Error.SetError(_Cmb_Categ, "Información requerida!!!"); }
                    if (_Txt_NombComercial.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_NombComercial, "Información requerida!!!"); }
                    if (_Txt_Nomb_Abreviado.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Nomb_Abreviado, "Información requerida!!!"); }
                    if (_Txt_NombFiscal.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_NombFiscal, "Información requerida!!!"); }
                    if (_Txt_Dir_Comercial.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Dir_Comercial, "Información requerida!!!"); }
                    if (_Txt_Dir_Fiscal.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Dir_Fiscal, "Información requerida!!!"); }
                    if (_Txt_Telefono.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Telefono, "Información requerida!!!"); }
                    if (_Txt_Inf_Cont1.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Inf_Cont1, "Información requerida!!!"); }
                    if (_Txt_Dias_Credito.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Dias_Credito, "Información requerida!!!"); }
                    if (_Txt_Limite.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Limite, "Información requerida!!!"); }
                    if (_Cmb_Contribuyente.SelectedValue.ToString() == "0") { _Er_Error.SetError(_Cmb_Contribuyente, "Información requerida!!!"); }
                    if (_Str_Rif.Trim().Length < 1) { _Er_Error.SetError(_Txt_Rif3, "Información requerida!!!"); }
                    if (!(_Chbox_V_Lunes.Checked | _Chbox_V_Martes.Checked | _Chbox_V_Miercoles.Checked | _Chbox_V_Jueves.Checked | _Chbox_V_Viernes.Checked | _Chbox_V_Sabado.Checked)) { _Er_Error.SetError(_Chbox_V_Sabado, "Información requerida!!!"); }
                    if (!(_Chbox_D_Lunes.Checked | _Chbox_D_Martes.Checked | _Chbox_D_Miercoles.Checked | _Chbox_D_Jueves.Checked | _Chbox_D_Viernes.Checked | _Chbox_D_Sabado.Checked)) { _Er_Error.SetError(_Chbox_D_Sabado, "Información requerida!!!"); }
                    if (_Int_Por_Iva == 3) { _Er_Error.SetError(_Rbt_75, "Información requerida!!!"); _Er_Error.SetError(_Rbt_100, "Información requerida!!!"); _Er_Error.SetError(_Rbt_0, "Información requerida!!!"); }
                    //--------------------------------------------------------
                    if (_Txt_NombComercial.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_Nomb_Abreviado.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_NombFiscal.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_Dir_Comercial.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_Dir_Fiscal.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_Telefono.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (_Txt_Inf_Cont1.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 2; }
                    else if (_Txt_Dias_Credito.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 3; }
                    else if (_Txt_Limite.Text.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 3; }
                    else if (_Cmb_Contribuyente.SelectedValue.ToString() == "0") { _Tb_Tab.SelectedIndex = 3; }
                    else if (_Str_Rif.Trim().Length < 1) { _Tb_Tab.SelectedIndex = 1; }
                    else if (!(_Chbox_V_Lunes.Checked | _Chbox_V_Martes.Checked | _Chbox_V_Miercoles.Checked | _Chbox_V_Jueves.Checked | _Chbox_V_Viernes.Checked | _Chbox_V_Sabado.Checked)) { _Tb_Tab.SelectedIndex = 2; }
                    else if (!(_Chbox_D_Lunes.Checked | _Chbox_D_Martes.Checked | _Chbox_D_Miercoles.Checked | _Chbox_D_Jueves.Checked | _Chbox_D_Viernes.Checked | _Chbox_D_Sabado.Checked)) { _Tb_Tab.SelectedIndex = 2; }
                    else if (_Int_Por_Iva == 3) { _Tb_Tab.SelectedIndex = 3; }
                    return false;
                }
            }
        }
        public bool _Mtd_Eliminar()
        {
            DialogResult eli = MessageBox.Show("Esta seguro de Eliminar el registro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (eli == DialogResult.Yes)
            {
                string _Str_Cadena = "UPDATE TPROVEEDOR Set cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' where cproveedor='" + _Txt_Codigo.Text.Trim() + "' and ccompany='"+Frm_Padre._Str_Comp+"'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                MessageBox.Show("El registro fue eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!_Bol_Bol)
                {
                    _Mtd_Actualizar_Tabs(_Int_Acualizar);
                }
                else
                {
                    _Mtd_Actualizar(_Int_Acualizar);
                }
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
            }
            else
            {
                if (!_Bol_Bol)
                {
                    _Mtd_Actualizar_Tabs(_Int_Acualizar);
                }
                else
                {
                    _Mtd_Actualizar(_Int_Acualizar);
                }
                _Mtd_Ini();
                _Mtd_Deshabilitar_Todo();
                _Tb_Tab.SelectedIndex = 0;
            }
            return true;
        }
        private void Frm_Proveedores2_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        public void _Mtd_Entrada(string _P_Str_Letra, string _P_Str_Categ)
        {
            string f = "";
            try
            {
                string _cadena = "SELECT cproveedor FROM TPROVEEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor LIKE ('%" + _P_Str_Letra + "%') ORDER BY cproveedor  DESC ";
                DataSet Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cproveedor FROM TPROVEEDOR where ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor LIKE ('%" + _P_Str_Letra + "%') ORDER BY cproveedor  DESC ");
                int _Int_Indice = 0;
                int _Int_Valor = 0;
                int _Int_SWS = 0;
                foreach (DataRow _Row in Ds.Tables[0].Rows)
                {
                    _Int_Indice = _Row[0].ToString().IndexOf(_P_Str_Letra);
                    if (_Int_SWS == 0)
                    {
                        _Int_Valor = Convert.ToInt32(_Row[0].ToString().Substring(_Int_Indice + 1));
                        _Int_SWS = 1;
                    }
                    if (Convert.ToInt32(_Row[0].ToString().Substring(_Int_Indice + 1)) > _Int_Valor)
                    {
                        _Int_Valor = Convert.ToInt32(_Row[0].ToString().Substring(_Int_Indice + 1));
                    }
                }
                _Int_Valor++;
                _Txt_Codigo.Text = _P_Str_Categ + _P_Str_Letra + Convert.ToString(_Int_Valor);
            }
            catch
            {
                _Txt_Codigo.Text = _P_Str_Categ + _P_Str_Letra + "1";
            }
        }
        private void _Mtd_HabilitarPatentePorcentaje(bool _Bol_Habilitado)
        {
            foreach (Control _Ctr_Control in _Txt_RetencionPat.Controls)
            {
                _Ctr_Control.Enabled = _Bol_Habilitado;
            }
        }
        private void _Mtd_Dg_Grid_RowHeaderMouseDoubleClick()
        {
            if (_Dg_Grid.Rows.Count > 0)
            {
                DataSet _DsA;
                _Er_Error.Dispose();
                _Mtd_Inicializar_Controles(_Tb_Tab);
                _Mtd_Deshabilitar_Todo();
                _Mtd_CargarPlanAhorro();                
                _Rbt_0.Checked = false;
                _Rbt_75.Checked = false;
                _Rbt_100.Checked = false;
                _Chbox_Nota.Checked = false;
                string _Str_Cadena = "Select cproveedor,c_rif,c_nit,c_nomb_comer,c_nomb_fiscal,c_nomb_abreviado," +
"c_direcc_comer,c_direcc_fiscal,c_telefono,c_fax,c_email,c_www,c_inf_replegal," +
"c_info_cont_1,c_info_cont_2,c_info_cont_3,ISNULL(c_banco_1,0) AS c_banco_1,ISNULL(c_banco_2,0) AS c_banco_2,ISNULL(c_banco_3,0) AS c_banco_3,c_cuenta_1," +
"c_cuenta_2,c_cuenta_3,c_lun_visita,c_mar_visita,c_mie_visita,c_jue_visita,c_vie_visita," +
"c_sab_visita,c_lun_despa,c_mar_despa,c_mie_despa,c_juev_despa,c_vie_despa,c_sab_despa," +
"cglobal,c_activo,c_fech_inicio,c_dia_credito,c_limt_credit,c_des_ppago,ctcount,cauxiliar," +
"c_notas,ccliente,ISNULL(cgrupovta,0) AS cgrupovta,ISNULL(c_tip_contribuy,0) AS c_tip_contribuy,ISNULL(ccatproveedor,0) AS ccatproveedor,cporcinvendible,cpordevmalestado,cporincvolcomp," +
"cpjuridica,cdomiciliada,cdiasdespa,cporcenreteniva,cnotarecojo,cporcmalsodica,ISNULL(cidplanahorro,0) AS cidplanahorro,cporcenretpat,cnumpatente,cretienepatente,cnumruc,ccodactividadecono from TPROVEEDOR where cproveedor='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, _Dg_Grid.CurrentCell.RowIndex) + "' and c_rif='" + _Ctrl_Busqueda1._Mtd_RetornarStringCelda(1, _Dg_Grid.CurrentCell.RowIndex) + "' AND (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal='1')";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                string _Str_Cglobal = "";
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    DataRow _Row = _Ds.Tables[0].Rows[0];
                    if (_Row["cporcenreteniva"].ToString().Trim() == "1")
                    { _Rbt_0.Checked = true; }
                    else if (_Row["cporcenreteniva"].ToString().Trim() == "75")
                    { _Rbt_75.Checked = true; }
                    else if (_Row["cporcenreteniva"].ToString().Trim() == "100")
                    { _Rbt_100.Checked = true; }
                    _Cmb_PlanAhorro.SelectedValue = _Row["cidplanahorro"];
                    _Str_Cglobal = _Row["cglobal"].ToString().Trim();
                    _G_Str_cglobal = _Str_Cglobal;
                    _Txt_Codigo.Text = _Row["cproveedor"].ToString().Trim();
                    //---Rif--------------
                    string[] _Str_Rif = _Row["c_rif"].ToString().Trim().Split(new char[] { '-' });
                    _Cmb_Rif1.SelectedItem = _Str_Rif[0].ToString();
                    _Txt_Rif2.Text = _Str_Rif[1].ToString();
                    _Txt_Rif3.Text = _Str_Rif[2].ToString();
                    //---Rif--------------
                    _Txt_Nit.Text = _Row["c_nit"].ToString().Trim();
                    _Txt_NombComercial.Text = _Row["c_nomb_comer"].ToString().Trim();
                    _Txt_NombFiscal.Text = _Row["c_nomb_fiscal"].ToString().Trim();
                    _Txt_Nomb_Abreviado.Text = _Row["c_nomb_abreviado"].ToString().Trim();
                    _Txt_Dir_Comercial.Text = _Row["c_direcc_comer"].ToString().Trim();
                    _Txt_Dir_Fiscal.Text = _Row["c_direcc_fiscal"].ToString().Trim();
                    _Txt_Telefono.Text = _Row["c_telefono"].ToString().Trim();
                    _Txt_Fax.Text = _Row["c_fax"].ToString().Trim();
                    _Txt_Url.Text = _Row["c_www"].ToString().Trim();
                    _Txt_Representante.Text = _Row["c_inf_replegal"].ToString().Trim();
                    _Txt_Inf_Cont1.Text = _Row["c_info_cont_1"].ToString().Trim();
                    _Txt_Inf_Cont2.Text = _Row["c_info_cont_2"].ToString().Trim();
                    _Txt_Inf_Cont3.Text = _Row["c_info_cont_3"].ToString().Trim();
                    if (_Cmb_Banco1.DataSource != null)
                    { _Cmb_Banco1.SelectedValue = _Row["c_banco_1"].ToString().Trim(); }
                    if (_Cmb_Banco2.DataSource != null)
                    { _Cmb_Banco2.SelectedValue = _Row["c_banco_2"].ToString().Trim(); }
                    if (_Cmb_Banco3.DataSource != null)
                    { _Cmb_Banco3.SelectedValue = _Row["c_banco_3"].ToString().Trim(); }
                    _Txt_Cuenta1.Text = _Row["c_cuenta_1"].ToString().Trim();
                    _Txt_Cuenta2.Text = _Row["c_cuenta_2"].ToString().Trim();
                    _Txt_Cuenta3.Text = _Row["c_cuenta_3"].ToString().Trim();
                    if (_Row["c_lun_visita"].ToString().Trim().Length > 1) { _Chbox_V_Lunes.Checked = true; } else { _Chbox_V_Lunes.Checked = false; }
                    if (_Row["c_mar_visita"].ToString().Trim().Length > 1) { _Chbox_V_Martes.Checked = true; } else { _Chbox_V_Martes.Checked = false; }
                    if (_Row["c_mie_visita"].ToString().Trim().Length > 1) { _Chbox_V_Miercoles.Checked = true; } else { _Chbox_V_Miercoles.Checked = false; }
                    if (_Row["c_jue_visita"].ToString().Trim().Length > 1) { _Chbox_V_Jueves.Checked = true; } else { _Chbox_V_Jueves.Checked = false; }
                    if (_Row["c_vie_visita"].ToString().Trim().Length > 1) { _Chbox_V_Viernes.Checked = true; } else { _Chbox_V_Viernes.Checked = false; }
                    if (_Row["c_sab_visita"].ToString().Trim().Length > 1) { _Chbox_V_Sabado.Checked = true; } else { _Chbox_V_Sabado.Checked = false; }
                    //------------------
                    if (_Row["c_lun_despa"].ToString().Trim().Length > 1) { _Chbox_D_Lunes.Checked = true; } else { _Chbox_D_Lunes.Checked = false; }
                    if (_Row["c_mar_despa"].ToString().Trim().Length > 1) { _Chbox_D_Martes.Checked = true; } else { _Chbox_D_Martes.Checked = false; }
                    if (_Row["c_mie_despa"].ToString().Trim().Length > 1) { _Chbox_D_Miercoles.Checked = true; } else { _Chbox_D_Miercoles.Checked = false; }
                    if (_Row["c_juev_despa"].ToString().Trim().Length > 1) { _Chbox_D_Jueves.Checked = true; } else { _Chbox_D_Jueves.Checked = false; }
                    if (_Row["c_vie_despa"].ToString().Trim().Length > 1) { _Chbox_D_Viernes.Checked = true; } else { _Chbox_D_Viernes.Checked = false; }
                    if (_Row["c_sab_despa"].ToString().Trim().Length > 1) { _Chbox_D_Sabado.Checked = true; } else { _Chbox_D_Sabado.Checked = false; }
                    if (_Cmb_TipPro.DataSource != null)
                    {
                        if (_G_Str_cglobal == "1")
                        {
                            _Cmb_TipPro.SelectedIndexChanged -= new EventHandler(_Cmb_TipPro_SelectedIndexChanged);
                            _Cmb_TipPro.SelectedValue = _Row["cglobal"].ToString().Trim();
                            _Cmb_TipPro.SelectedIndexChanged += new EventHandler(_Cmb_TipPro_SelectedIndexChanged);
                            _Cmb_Categ.DataSource = null;
                        }
                        else
                        {
                            _Cmb_TipPro.SelectedValue = _Row["cglobal"].ToString().Trim();
                        }
                    }
                    _Chbox_Activo.Checked = Convert.ToBoolean(Convert.ToInt32(_Row["c_activo"].ToString().Trim()));
                    if (_Row["c_fech_inicio"] != System.DBNull.Value)
                    { _Dtp_FecIni.Value = Convert.ToDateTime(_Row["c_fech_inicio"].ToString().Trim()); }
                    _Txt_Dias_Credito.Text = _Row["c_dia_credito"].ToString().Trim();
                    _Txt_Limite.Text = _Row["c_limt_credit"].ToString().Trim();
                    _Txt_D_Pronto.Text = _Row["c_des_ppago"].ToString().Trim();
                    _Txt_Count.Tag = _Row["ctcount"].ToString().Trim();
                    _Str_Cadena = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Row["ctcount"].ToString().Trim() + "'";
                    _DsA = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_DsA.Tables[0].Rows.Count > 0)
                    {
                        _Txt_Count.Text = _Txt_Count.Tag.ToString() + ":" + _DsA.Tables[0].Rows[0]["cname"].ToString().Trim();
                    }
                    _Txt_Notas.Text = _Row["c_notas"].ToString().Trim();
                    _Txt_Cod_Cliente.Text = _Row["ccliente"].ToString().ToString().Trim();
                    if (_Txt_Cod_Cliente.Text.Trim().Length > 0)
                    {
                        _Str_Cadena = "Select c_nomb_comer from TCLIENTE where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccliente='" + _Txt_Cod_Cliente.Text.Trim() + "'";
                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                        { _Txt_Des_Cliente.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim(); }
                    }
                    if (_Cmb_Grupo.DataSource != null)
                    { _Cmb_Grupo.SelectedValue = _Row["cgrupovta"].ToString().Trim(); }
                    if (_Cmb_Contribuyente.DataSource != null)
                    { _Cmb_Contribuyente.SelectedValue = _Row["c_tip_contribuy"].ToString().Trim(); }
                    if (_Cmb_Categ.DataSource != null)
                    { _Cmb_Categ.SelectedValue = _Row["ccatproveedor"].ToString().Trim(); }
                    if (_Row["cporcinvendible"] != System.DBNull.Value)
                    { _Num_Invendible.Value = Convert.ToDecimal(_Row["cporcinvendible"].ToString().Trim()); }
                    if (_Row["cpordevmalestado"] != System.DBNull.Value)
                    { _Num_Mal.Value = Convert.ToDecimal(_Row["cpordevmalestado"].ToString().Trim()); }
                    if (_Row["cporincvolcomp"] != System.DBNull.Value)
                    { _Num_Compra.Value = Convert.ToDecimal(_Row["cporincvolcomp"].ToString().Trim()); }
                    if (_Row["cporcmalsodica"] != System.DBNull.Value)
                    { _Num_Sodica.Value = Convert.ToDecimal(_Row["cporcmalsodica"].ToString().Trim()); }
                    
                    if (_Row["cpjuridica"].ToString().Trim() == "1")
                    { _Rb_P_Juridica.Checked = true; }
                    else
                    { _Rb_P_Natural.Checked = true; }
                    if (_Row["cdomiciliada"].ToString().Trim() == "1")
                    { _Rb_Domiciliado.Checked = true; }
                    else
                    { _Rb_NoResidente.Checked = true; }
                    _Txt_Dias_Despacho.Text = _Row["cdiasdespa"].ToString().Trim();
                    if (_Row["cnotarecojo"].ToString().Trim() == "1")
                    { _Chbox_Nota.Checked = true; }
                    else
                    { _Chbox_Nota.Checked = false; }
                    if (_Row["cretienepatente"].ToString().Trim() == "1")
                    {
                        if (CLASES._Cls_Varios_Metodos._Mtd_EstaActivoRetencionesPatente())
                        {
                            _Chk_RetencionMunicipal.Checked = true;
                            _Txt_Patente.Text = _Row["cnumpatente"].ToString().Trim();
                            _Txt_RetencionPat.Text = _Row["cporcenretpat"].ToString().Trim();
                            _Txt_RUC.Text = _Row["cnumruc"].ToString().Trim();
                            _Txt_CodActEconomica.Text = _Row["ccodactividadecono"].ToString().Trim();
                        }
                    }
                    else
                    {
                        _Txt_Patente.Text = "";
                        _Txt_RetencionPat.Text = "";
                        _Txt_RUC.Text = "";
                        _Txt_CodActEconomica.Text = "";
                        _Chk_RetencionMunicipal.Checked = false;
                        _Mtd_HabilitarPatentePorcentaje(false);
                        _Txt_Patente.Enabled = false;
                        _Txt_RUC.Enabled = false;
                    }
                }
                //if (_Bol_Bol)
                //{
                //    if (_Str_Cglobal != "1")
                //    {
                //        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                //        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                //        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                //    }
                //    else
                //    {
                //        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                //        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                //        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                //    }
                //}
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                _Tb_Tab.SelectTab(1);
            }
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _Mtd_Dg_Grid_RowHeaderMouseDoubleClick();
        }

        private void _Bt_Rif_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                string _Str_Rif = _Cmb_Rif1.SelectedItem.ToString().Trim() + "-" + _Txt_Rif2.Text.Trim() + "-" + _Txt_Rif3.Text.Trim();
                string _Str_Url = CLASES._Cls_Varios_Metodos._Str_Servidor_Web + "/este.aspx?este=" + _Str_Rif.Replace("-", "");
                Frm_Navegador _Frm = new Frm_Navegador(_Str_Url, false);
                _Frm.MdiParent = this.MdiParent;
                _Frm.Dock = DockStyle.Fill;
                _Frm.Show();
            }
            catch { }
            Cursor = Cursors.Default;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Tb_Tab.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus();}
            else
            { _Tb_Tab.Enabled = true; }
        }
        public static Byte[] _Mtd_ConvertStringToByteArray(String s)
        {
            return (new UnicodeEncoding()).GetBytes(s);
        }
        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            byte[] hash = _Mtd_ConvertStringToByteArray(_Txt_Clave.Text);
            byte[] valorhash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(hash);
            string cod = BitConverter.ToString(valorhash);
            cod = cod.Replace("-", "");
            Cursor = Cursors.WaitCursor;
            try
            {

                string _Str_Cadena = "SELECT   cpassw  FROM TUSER WHERE cuser= '" + Frm_Padre._Str_Use.ToString() + "' and cpassw= '" + cod.ToString() + "'";
                System.Data.DataSet Ds22 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (Ds22.Tables[0].Rows.Count > 0)
                {
                    int _Int_Por_Iva = 3;
                    if (_Rbt_0.Checked)
                    { _Int_Por_Iva = 1; }
                    else if (_Rbt_75.Checked)
                    { _Int_Por_Iva = 75; }
                    else if (_Rbt_100.Checked)
                    { _Int_Por_Iva = 100; }
                    _Str_Cadena = "Update TPROVEEDOR Set ccompany='" + Frm_Padre._Str_Comp + "',cporcenreteniva='"+_Int_Por_Iva.ToString()+"',casignado='1' where cproveedor='" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString() + "' and c_rif='" + _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[1].Value.ToString() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                    MessageBox.Show("La operación ha sido realizada correctamente","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    _Rbt_0.Enabled = false;
                    _Rbt_75.Enabled = false;
                    _Rbt_100.Enabled = false;
                    if (!_Bol_Bol)
                    {
                        _Mtd_Actualizar_Tabs(_Int_Acualizar);
                    }
                    else
                    {
                        _Mtd_Actualizar(_Int_Acualizar);
                    }
                    _Pnl_Clave.Visible = false;
                }
                else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
            }
            catch { }
            Cursor = Cursors.Default;
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void aceptarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_Rbt_0.Checked & !_Rbt_75.Checked & !_Rbt_100.Checked)
            {
                MessageBox.Show("Debe considerar la condición fiscal del cliente!!","Información",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                _Mtd_Dg_Grid_RowHeaderMouseDoubleClick();
                _Mtd_Habilitar();
                _Tb_Tab.SelectedIndex = 3;

            }
            else
            { _Pnl_Clave.Visible = true; }
        }
        int _Int_Acualizar = 3;
        private void _Rbt_Todos_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Todos.Checked)
            {
                _Int_Acualizar = 3;
                if (!_Bol_Bol)
                {
                    _Mtd_Actualizar_Tabs(_Int_Acualizar);
                }
                else
                {
                    _Mtd_Actualizar(_Int_Acualizar);
                }
            }
        }

        private void _Rbt_Materia_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Materia.Checked)
            {
                _Int_Acualizar = 1;
                if (!_Bol_Bol)
                {
                    _Mtd_Actualizar_Tabs(_Int_Acualizar);
                }
                else
                {
                    _Mtd_Actualizar(_Int_Acualizar);
                }
            }
        }

        private void _Rbt_Servicio_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Servicio.Checked)
            {
                _Int_Acualizar = 0;
                if (!_Bol_Bol)
                {
                    _Mtd_Actualizar_Tabs(_Int_Acualizar);
                }
                else
                {
                    _Mtd_Actualizar(_Int_Acualizar);
                }
            }
        }

        private void _Rbt_Otros_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Otros.Checked)
            {
                _Int_Acualizar = 2;
                if (!_Bol_Bol)
                {
                    _Mtd_Actualizar_Tabs(_Int_Acualizar);
                }
                else
                {
                    _Mtd_Actualizar(_Int_Acualizar);
                }
            }
        }

        private void _Rbt_0_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_0.Checked)
            {
                _Rbt_75.Checked = false;
                _Rbt_100.Checked = false;
            }
        }

        private void _Rbt_75_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_75.Checked)
            { _Rbt_0.Checked = false; }
        }

        private void _Rbt_100_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_100.Checked)
            { _Rbt_0.Checked = false; }
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

        private void _Bt_Count_Click(object sender, EventArgs e)
        {
            string _Str_CodCuenta = "", _Str_Sql = "";
            DataSet _Ds;
            Frm_VstCuentas _Frm_Vista = new Frm_VstCuentas();
            _Frm_Vista.ShowDialog();
            _Str_CodCuenta = _Frm_Vista._Str_FrmNodeSelec;
            if (_Str_CodCuenta.Length>0)
            {
                _Str_Sql = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_CodCuenta + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_Count.Text = _Str_CodCuenta + ":" + _Ds.Tables[0].Rows[0]["cname"].ToString().Trim();
                }
                _Txt_Count.Tag = _Str_CodCuenta;
                
            }
            _Frm_Vista.Dispose();
        }
        public void _Mtd_BotonesMenu()
        {
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
        }


        private void _Chk_RetencionMunicipal_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chk_RetencionMunicipal.Checked)
            {
                _Mtd_HabilitarPatentePorcentaje(true);   
                _Txt_Patente.Enabled = true;
                _Txt_RUC.Enabled = true;
                _Txt_CodActEconomica.Enabled = true;
            }
            else
            {
                _Txt_RUC.Text = "";
                _Txt_Patente.Text = "";
                _Txt_RetencionPat.Value = 0;
                _Mtd_HabilitarPatentePorcentaje(false);   
                _Txt_Patente.Enabled = false;
                _Txt_CodActEconomica.Enabled = false;
                _Txt_RUC.Enabled = false;
            }
        }
    }
}