namespace T3
{
    partial class Frm_IncVarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_IncVarios));
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this._Pnl_Consulta_1 = new System.Windows.Forms.Panel();
            this._Bt_Consultar = new System.Windows.Forms.Button();
            this._Lbl_Cargo = new System.Windows.Forms.Label();
            this._Cmb_Cargo = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._Pnl_Detalle_2 = new System.Windows.Forms.Panel();
            this._GrpB_Activacion = new System.Windows.Forms.GroupBox();
            this._Bt_Activacion = new System.Windows.Forms.Button();
            this._Lbl_Comision_Activacion = new System.Windows.Forms.Label();
            this._Txt_ccondicion_activacion = new System.Windows.Forms.TextBox();
            this._Lbl_Condicion_Activacion = new System.Windows.Forms.Label();
            this._Txt_ccomisionpag_activacion = new System.Windows.Forms.TextBox();
            this._GrpB_Efectividad = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Bt_Efectividad = new System.Windows.Forms.Button();
            this._Txt_cmontominvisefec = new System.Windows.Forms.TextBox();
            this._Lbl_Comision_Efectividad = new System.Windows.Forms.Label();
            this._Txt_ccondicion_efectividad = new System.Windows.Forms.TextBox();
            this._Lbl_Condicion_Efectividad = new System.Windows.Forms.Label();
            this._Txt_ccomisionpag_efectividad = new System.Windows.Forms.TextBox();
            this._GrpB_Devolucion = new System.Windows.Forms.GroupBox();
            this._Bt_Devolucion = new System.Windows.Forms.Button();
            this._Lbl_Comision_Devolucion = new System.Windows.Forms.Label();
            this._Txt_ccondicion_devolucion = new System.Windows.Forms.TextBox();
            this._Lbl_Condicion_Devolucion = new System.Windows.Forms.Label();
            this._Txt_ccomisionpag_devolucion = new System.Windows.Forms.TextBox();
            this._Pnl_Detalle_1 = new System.Windows.Forms.Panel();
            this._Lbl_CargoD = new System.Windows.Forms.Label();
            this._Cmb_Cargo_D = new System.Windows.Forms.ComboBox();
            this._Lbl_Ginc = new System.Windows.Forms.Label();
            this._Cmb_Grupo_D = new System.Windows.Forms.ComboBox();
            this._Lbl_Id = new System.Windows.Forms.Label();
            this._Txt_cidincvarios = new System.Windows.Forms.TextBox();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Cntx_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._Pnl_Clave = new System.Windows.Forms.Panel();
            this._Bt_AceptarClave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this._Txt_Clave = new System.Windows.Forms.TextBox();
            this._Bt_CancelarClave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this._Pnl_Consulta_1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this._Pnl_Detalle_2.SuspendLayout();
            this._GrpB_Activacion.SuspendLayout();
            this._GrpB_Efectividad.SuspendLayout();
            this._GrpB_Devolucion.SuspendLayout();
            this._Pnl_Detalle_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this._Cntx_Menu.SuspendLayout();
            this._Pnl_Clave.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Tb_Tab
            // 
            this._Tb_Tab.Controls.Add(this.tabPage1);
            this._Tb_Tab.Controls.Add(this.tabPage2);
            this._Tb_Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Tb_Tab.Location = new System.Drawing.Point(0, 0);
            this._Tb_Tab.Name = "_Tb_Tab";
            this._Tb_Tab.SelectedIndex = 0;
            this._Tb_Tab.Size = new System.Drawing.Size(575, 441);
            this._Tb_Tab.TabIndex = 2;
            this._Tb_Tab.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this._Tb_Tab_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._Dg_Grid);
            this.tabPage1.Controls.Add(this._Pnl_Consulta_1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(567, 415);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.ContextMenuStrip = this._Cntx_Menu;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(3, 74);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.Size = new System.Drawing.Size(561, 338);
            this._Dg_Grid.TabIndex = 20;
            this._Dg_Grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseDoubleClick);
            // 
            // _Pnl_Consulta_1
            // 
            this._Pnl_Consulta_1.Controls.Add(this._Bt_Consultar);
            this._Pnl_Consulta_1.Controls.Add(this._Lbl_Cargo);
            this._Pnl_Consulta_1.Controls.Add(this._Cmb_Cargo);
            this._Pnl_Consulta_1.Dock = System.Windows.Forms.DockStyle.Top;
            this._Pnl_Consulta_1.Location = new System.Drawing.Point(3, 3);
            this._Pnl_Consulta_1.Name = "_Pnl_Consulta_1";
            this._Pnl_Consulta_1.Size = new System.Drawing.Size(561, 71);
            this._Pnl_Consulta_1.TabIndex = 1;
            // 
            // _Bt_Consultar
            // 
            this._Bt_Consultar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Bt_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Consultar.Image")));
            this._Bt_Consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Consultar.Location = new System.Drawing.Point(408, 18);
            this._Bt_Consultar.Name = "_Bt_Consultar";
            this._Bt_Consultar.Size = new System.Drawing.Size(118, 43);
            this._Bt_Consultar.TabIndex = 10;
            this._Bt_Consultar.Text = "Consultar";
            this._Bt_Consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Consultar.UseVisualStyleBackColor = true;
            this._Bt_Consultar.Click += new System.EventHandler(this._Bt_Consultar_Click);
            // 
            // _Lbl_Cargo
            // 
            this._Lbl_Cargo.AutoSize = true;
            this._Lbl_Cargo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Lbl_Cargo.Location = new System.Drawing.Point(13, 11);
            this._Lbl_Cargo.Name = "_Lbl_Cargo";
            this._Lbl_Cargo.Size = new System.Drawing.Size(49, 13);
            this._Lbl_Cargo.TabIndex = 11;
            this._Lbl_Cargo.Text = "Cargo:";
            // 
            // _Cmb_Cargo
            // 
            this._Cmb_Cargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Cargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Cargo.Font = new System.Drawing.Font("Verdana", 6.75F);
            this._Cmb_Cargo.FormattingEnabled = true;
            this._Cmb_Cargo.Location = new System.Drawing.Point(16, 29);
            this._Cmb_Cargo.Name = "_Cmb_Cargo";
            this._Cmb_Cargo.Size = new System.Drawing.Size(374, 20);
            this._Cmb_Cargo.TabIndex = 9;
            this._Cmb_Cargo.DropDown += new System.EventHandler(this._Cmb_Cargo_DropDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._Pnl_Detalle_2);
            this.tabPage2.Controls.Add(this._Pnl_Detalle_1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(567, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _Pnl_Detalle_2
            // 
            this._Pnl_Detalle_2.Controls.Add(this._GrpB_Activacion);
            this._Pnl_Detalle_2.Controls.Add(this._GrpB_Efectividad);
            this._Pnl_Detalle_2.Controls.Add(this._GrpB_Devolucion);
            this._Pnl_Detalle_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Pnl_Detalle_2.Enabled = false;
            this._Pnl_Detalle_2.Location = new System.Drawing.Point(3, 151);
            this._Pnl_Detalle_2.Name = "_Pnl_Detalle_2";
            this._Pnl_Detalle_2.Size = new System.Drawing.Size(561, 261);
            this._Pnl_Detalle_2.TabIndex = 68;
            // 
            // _GrpB_Activacion
            // 
            this._GrpB_Activacion.Controls.Add(this._Bt_Activacion);
            this._GrpB_Activacion.Controls.Add(this._Lbl_Comision_Activacion);
            this._GrpB_Activacion.Controls.Add(this._Txt_ccondicion_activacion);
            this._GrpB_Activacion.Controls.Add(this._Lbl_Condicion_Activacion);
            this._GrpB_Activacion.Controls.Add(this._Txt_ccomisionpag_activacion);
            this._GrpB_Activacion.Dock = System.Windows.Forms.DockStyle.Top;
            this._GrpB_Activacion.Location = new System.Drawing.Point(0, 176);
            this._GrpB_Activacion.Name = "_GrpB_Activacion";
            this._GrpB_Activacion.Size = new System.Drawing.Size(561, 82);
            this._GrpB_Activacion.TabIndex = 0;
            this._GrpB_Activacion.TabStop = false;
            this._GrpB_Activacion.Text = "Incentivo por Activación";
            // 
            // _Bt_Activacion
            // 
            this._Bt_Activacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Bt_Activacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Activacion.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Activacion.Image")));
            this._Bt_Activacion.Location = new System.Drawing.Point(519, 32);
            this._Bt_Activacion.Name = "_Bt_Activacion";
            this._Bt_Activacion.Size = new System.Drawing.Size(32, 30);
            this._Bt_Activacion.TabIndex = 64;
            this._Bt_Activacion.UseVisualStyleBackColor = true;
            this._Bt_Activacion.Click += new System.EventHandler(this._Bt_Activacion_Click);
            // 
            // _Lbl_Comision_Activacion
            // 
            this._Lbl_Comision_Activacion.AutoSize = true;
            this._Lbl_Comision_Activacion.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Lbl_Comision_Activacion.Location = new System.Drawing.Point(292, 21);
            this._Lbl_Comision_Activacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._Lbl_Comision_Activacion.Name = "_Lbl_Comision_Activacion";
            this._Lbl_Comision_Activacion.Size = new System.Drawing.Size(105, 13);
            this._Lbl_Comision_Activacion.TabIndex = 63;
            this._Lbl_Comision_Activacion.Text = "Comisión (BsF)";
            // 
            // _Txt_ccondicion_activacion
            // 
            this._Txt_ccondicion_activacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_ccondicion_activacion.Enabled = false;
            this._Txt_ccondicion_activacion.Font = new System.Drawing.Font("Verdana", 8.25F);
            this._Txt_ccondicion_activacion.Location = new System.Drawing.Point(20, 39);
            this._Txt_ccondicion_activacion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._Txt_ccondicion_activacion.MaxLength = 100;
            this._Txt_ccondicion_activacion.Name = "_Txt_ccondicion_activacion";
            this._Txt_ccondicion_activacion.Size = new System.Drawing.Size(266, 21);
            this._Txt_ccondicion_activacion.TabIndex = 61;
            // 
            // _Lbl_Condicion_Activacion
            // 
            this._Lbl_Condicion_Activacion.AutoSize = true;
            this._Lbl_Condicion_Activacion.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Lbl_Condicion_Activacion.Location = new System.Drawing.Point(18, 21);
            this._Lbl_Condicion_Activacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._Lbl_Condicion_Activacion.Name = "_Lbl_Condicion_Activacion";
            this._Lbl_Condicion_Activacion.Size = new System.Drawing.Size(74, 13);
            this._Lbl_Condicion_Activacion.TabIndex = 60;
            this._Lbl_Condicion_Activacion.Text = "Condición:";
            // 
            // _Txt_ccomisionpag_activacion
            // 
            this._Txt_ccomisionpag_activacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_ccomisionpag_activacion.Enabled = false;
            this._Txt_ccomisionpag_activacion.Font = new System.Drawing.Font("Verdana", 8.25F);
            this._Txt_ccomisionpag_activacion.Location = new System.Drawing.Point(292, 39);
            this._Txt_ccomisionpag_activacion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._Txt_ccomisionpag_activacion.MaxLength = 13;
            this._Txt_ccomisionpag_activacion.Name = "_Txt_ccomisionpag_activacion";
            this._Txt_ccomisionpag_activacion.Size = new System.Drawing.Size(143, 21);
            this._Txt_ccomisionpag_activacion.TabIndex = 59;
            this._Txt_ccomisionpag_activacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Txt_ccomisionpag_activacion.TextChanged += new System.EventHandler(this._Txt_ccomisionpag_activacion_TextChanged);
            this._Txt_ccomisionpag_activacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_ccomisionpag_activacion_KeyPress);
            // 
            // _GrpB_Efectividad
            // 
            this._GrpB_Efectividad.Controls.Add(this.label1);
            this._GrpB_Efectividad.Controls.Add(this._Bt_Efectividad);
            this._GrpB_Efectividad.Controls.Add(this._Txt_cmontominvisefec);
            this._GrpB_Efectividad.Controls.Add(this._Lbl_Comision_Efectividad);
            this._GrpB_Efectividad.Controls.Add(this._Txt_ccondicion_efectividad);
            this._GrpB_Efectividad.Controls.Add(this._Lbl_Condicion_Efectividad);
            this._GrpB_Efectividad.Controls.Add(this._Txt_ccomisionpag_efectividad);
            this._GrpB_Efectividad.Dock = System.Windows.Forms.DockStyle.Top;
            this._GrpB_Efectividad.Location = new System.Drawing.Point(0, 82);
            this._GrpB_Efectividad.Name = "_GrpB_Efectividad";
            this._GrpB_Efectividad.Size = new System.Drawing.Size(561, 94);
            this._GrpB_Efectividad.TabIndex = 0;
            this._GrpB_Efectividad.TabStop = false;
            this._GrpB_Efectividad.Text = "Incentivo por Efectividad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(91, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "Visita efectiva (Mínimo BsF):";
            // 
            // _Bt_Efectividad
            // 
            this._Bt_Efectividad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Bt_Efectividad.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Efectividad.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Efectividad.Image")));
            this._Bt_Efectividad.Location = new System.Drawing.Point(519, 32);
            this._Bt_Efectividad.Name = "_Bt_Efectividad";
            this._Bt_Efectividad.Size = new System.Drawing.Size(32, 30);
            this._Bt_Efectividad.TabIndex = 64;
            this._Bt_Efectividad.UseVisualStyleBackColor = true;
            this._Bt_Efectividad.Click += new System.EventHandler(this._Bt_Efectividad_Click);
            // 
            // _Txt_cmontominvisefec
            // 
            this._Txt_cmontominvisefec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_cmontominvisefec.Enabled = false;
            this._Txt_cmontominvisefec.Font = new System.Drawing.Font("Verdana", 8.25F);
            this._Txt_cmontominvisefec.Location = new System.Drawing.Point(292, 66);
            this._Txt_cmontominvisefec.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._Txt_cmontominvisefec.MaxLength = 13;
            this._Txt_cmontominvisefec.Name = "_Txt_cmontominvisefec";
            this._Txt_cmontominvisefec.Size = new System.Drawing.Size(143, 21);
            this._Txt_cmontominvisefec.TabIndex = 64;
            this._Txt_cmontominvisefec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Txt_cmontominvisefec.TextChanged += new System.EventHandler(this._Txt_cmontominvisefec_TextChanged);
            this._Txt_cmontominvisefec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_cmontominvisefec_KeyPress);
            // 
            // _Lbl_Comision_Efectividad
            // 
            this._Lbl_Comision_Efectividad.AutoSize = true;
            this._Lbl_Comision_Efectividad.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Lbl_Comision_Efectividad.Location = new System.Drawing.Point(292, 21);
            this._Lbl_Comision_Efectividad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._Lbl_Comision_Efectividad.Name = "_Lbl_Comision_Efectividad";
            this._Lbl_Comision_Efectividad.Size = new System.Drawing.Size(105, 13);
            this._Lbl_Comision_Efectividad.TabIndex = 63;
            this._Lbl_Comision_Efectividad.Text = "Comisión (BsF)";
            // 
            // _Txt_ccondicion_efectividad
            // 
            this._Txt_ccondicion_efectividad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_ccondicion_efectividad.Enabled = false;
            this._Txt_ccondicion_efectividad.Font = new System.Drawing.Font("Verdana", 8.25F);
            this._Txt_ccondicion_efectividad.Location = new System.Drawing.Point(20, 39);
            this._Txt_ccondicion_efectividad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._Txt_ccondicion_efectividad.MaxLength = 100;
            this._Txt_ccondicion_efectividad.Name = "_Txt_ccondicion_efectividad";
            this._Txt_ccondicion_efectividad.Size = new System.Drawing.Size(266, 21);
            this._Txt_ccondicion_efectividad.TabIndex = 61;
            // 
            // _Lbl_Condicion_Efectividad
            // 
            this._Lbl_Condicion_Efectividad.AutoSize = true;
            this._Lbl_Condicion_Efectividad.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Lbl_Condicion_Efectividad.Location = new System.Drawing.Point(18, 21);
            this._Lbl_Condicion_Efectividad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._Lbl_Condicion_Efectividad.Name = "_Lbl_Condicion_Efectividad";
            this._Lbl_Condicion_Efectividad.Size = new System.Drawing.Size(74, 13);
            this._Lbl_Condicion_Efectividad.TabIndex = 60;
            this._Lbl_Condicion_Efectividad.Text = "Condición:";
            // 
            // _Txt_ccomisionpag_efectividad
            // 
            this._Txt_ccomisionpag_efectividad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_ccomisionpag_efectividad.Enabled = false;
            this._Txt_ccomisionpag_efectividad.Font = new System.Drawing.Font("Verdana", 8.25F);
            this._Txt_ccomisionpag_efectividad.Location = new System.Drawing.Point(292, 39);
            this._Txt_ccomisionpag_efectividad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._Txt_ccomisionpag_efectividad.MaxLength = 13;
            this._Txt_ccomisionpag_efectividad.Name = "_Txt_ccomisionpag_efectividad";
            this._Txt_ccomisionpag_efectividad.Size = new System.Drawing.Size(143, 21);
            this._Txt_ccomisionpag_efectividad.TabIndex = 59;
            this._Txt_ccomisionpag_efectividad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Txt_ccomisionpag_efectividad.TextChanged += new System.EventHandler(this._Txt_ccomisionpag_efectividad_TextChanged);
            this._Txt_ccomisionpag_efectividad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_ccomisionpag_efectividad_KeyPress);
            // 
            // _GrpB_Devolucion
            // 
            this._GrpB_Devolucion.Controls.Add(this._Bt_Devolucion);
            this._GrpB_Devolucion.Controls.Add(this._Lbl_Comision_Devolucion);
            this._GrpB_Devolucion.Controls.Add(this._Txt_ccondicion_devolucion);
            this._GrpB_Devolucion.Controls.Add(this._Lbl_Condicion_Devolucion);
            this._GrpB_Devolucion.Controls.Add(this._Txt_ccomisionpag_devolucion);
            this._GrpB_Devolucion.Dock = System.Windows.Forms.DockStyle.Top;
            this._GrpB_Devolucion.Location = new System.Drawing.Point(0, 0);
            this._GrpB_Devolucion.Name = "_GrpB_Devolucion";
            this._GrpB_Devolucion.Size = new System.Drawing.Size(561, 82);
            this._GrpB_Devolucion.TabIndex = 0;
            this._GrpB_Devolucion.TabStop = false;
            this._GrpB_Devolucion.Text = "Incentivo por Devolución";
            // 
            // _Bt_Devolucion
            // 
            this._Bt_Devolucion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Bt_Devolucion.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Devolucion.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Devolucion.Image")));
            this._Bt_Devolucion.Location = new System.Drawing.Point(519, 32);
            this._Bt_Devolucion.Name = "_Bt_Devolucion";
            this._Bt_Devolucion.Size = new System.Drawing.Size(32, 30);
            this._Bt_Devolucion.TabIndex = 65;
            this._Bt_Devolucion.UseVisualStyleBackColor = true;
            this._Bt_Devolucion.Click += new System.EventHandler(this._Bt_Devolucion_Click);
            // 
            // _Lbl_Comision_Devolucion
            // 
            this._Lbl_Comision_Devolucion.AutoSize = true;
            this._Lbl_Comision_Devolucion.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Lbl_Comision_Devolucion.Location = new System.Drawing.Point(292, 21);
            this._Lbl_Comision_Devolucion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._Lbl_Comision_Devolucion.Name = "_Lbl_Comision_Devolucion";
            this._Lbl_Comision_Devolucion.Size = new System.Drawing.Size(105, 13);
            this._Lbl_Comision_Devolucion.TabIndex = 63;
            this._Lbl_Comision_Devolucion.Text = "Comisión (BsF)";
            // 
            // _Txt_ccondicion_devolucion
            // 
            this._Txt_ccondicion_devolucion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_ccondicion_devolucion.Enabled = false;
            this._Txt_ccondicion_devolucion.Font = new System.Drawing.Font("Verdana", 8.25F);
            this._Txt_ccondicion_devolucion.Location = new System.Drawing.Point(20, 39);
            this._Txt_ccondicion_devolucion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._Txt_ccondicion_devolucion.MaxLength = 100;
            this._Txt_ccondicion_devolucion.Name = "_Txt_ccondicion_devolucion";
            this._Txt_ccondicion_devolucion.Size = new System.Drawing.Size(266, 21);
            this._Txt_ccondicion_devolucion.TabIndex = 61;
            // 
            // _Lbl_Condicion_Devolucion
            // 
            this._Lbl_Condicion_Devolucion.AutoSize = true;
            this._Lbl_Condicion_Devolucion.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Lbl_Condicion_Devolucion.Location = new System.Drawing.Point(18, 21);
            this._Lbl_Condicion_Devolucion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._Lbl_Condicion_Devolucion.Name = "_Lbl_Condicion_Devolucion";
            this._Lbl_Condicion_Devolucion.Size = new System.Drawing.Size(74, 13);
            this._Lbl_Condicion_Devolucion.TabIndex = 60;
            this._Lbl_Condicion_Devolucion.Text = "Condición:";
            // 
            // _Txt_ccomisionpag_devolucion
            // 
            this._Txt_ccomisionpag_devolucion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_ccomisionpag_devolucion.Enabled = false;
            this._Txt_ccomisionpag_devolucion.Font = new System.Drawing.Font("Verdana", 8.25F);
            this._Txt_ccomisionpag_devolucion.Location = new System.Drawing.Point(292, 39);
            this._Txt_ccomisionpag_devolucion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._Txt_ccomisionpag_devolucion.MaxLength = 13;
            this._Txt_ccomisionpag_devolucion.Name = "_Txt_ccomisionpag_devolucion";
            this._Txt_ccomisionpag_devolucion.Size = new System.Drawing.Size(143, 21);
            this._Txt_ccomisionpag_devolucion.TabIndex = 59;
            this._Txt_ccomisionpag_devolucion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Txt_ccomisionpag_devolucion.TextChanged += new System.EventHandler(this._Txt_ccomisionpag_devolucion_TextChanged);
            this._Txt_ccomisionpag_devolucion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_ccomisionpag_devolucion_KeyPress);
            // 
            // _Pnl_Detalle_1
            // 
            this._Pnl_Detalle_1.Controls.Add(this._Lbl_CargoD);
            this._Pnl_Detalle_1.Controls.Add(this._Cmb_Cargo_D);
            this._Pnl_Detalle_1.Controls.Add(this._Lbl_Ginc);
            this._Pnl_Detalle_1.Controls.Add(this._Cmb_Grupo_D);
            this._Pnl_Detalle_1.Controls.Add(this._Lbl_Id);
            this._Pnl_Detalle_1.Controls.Add(this._Txt_cidincvarios);
            this._Pnl_Detalle_1.Dock = System.Windows.Forms.DockStyle.Top;
            this._Pnl_Detalle_1.Location = new System.Drawing.Point(3, 3);
            this._Pnl_Detalle_1.Name = "_Pnl_Detalle_1";
            this._Pnl_Detalle_1.Size = new System.Drawing.Size(561, 148);
            this._Pnl_Detalle_1.TabIndex = 64;
            // 
            // _Lbl_CargoD
            // 
            this._Lbl_CargoD.AutoSize = true;
            this._Lbl_CargoD.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Lbl_CargoD.Location = new System.Drawing.Point(14, 50);
            this._Lbl_CargoD.Name = "_Lbl_CargoD";
            this._Lbl_CargoD.Size = new System.Drawing.Size(49, 13);
            this._Lbl_CargoD.TabIndex = 63;
            this._Lbl_CargoD.Text = "Cargo:";
            // 
            // _Cmb_Cargo_D
            // 
            this._Cmb_Cargo_D.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Cargo_D.Enabled = false;
            this._Cmb_Cargo_D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Cargo_D.Font = new System.Drawing.Font("Verdana", 6.75F);
            this._Cmb_Cargo_D.FormattingEnabled = true;
            this._Cmb_Cargo_D.Location = new System.Drawing.Point(17, 69);
            this._Cmb_Cargo_D.Name = "_Cmb_Cargo_D";
            this._Cmb_Cargo_D.Size = new System.Drawing.Size(374, 20);
            this._Cmb_Cargo_D.TabIndex = 59;
            this._Cmb_Cargo_D.SelectedIndexChanged += new System.EventHandler(this._Cmb_Cargo_D_SelectedIndexChanged);
            this._Cmb_Cargo_D.DropDown += new System.EventHandler(this._Cmb_Cargo_D_DropDown);
            // 
            // _Lbl_Ginc
            // 
            this._Lbl_Ginc.AutoSize = true;
            this._Lbl_Ginc.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Lbl_Ginc.Location = new System.Drawing.Point(14, 95);
            this._Lbl_Ginc.Name = "_Lbl_Ginc";
            this._Lbl_Ginc.Size = new System.Drawing.Size(132, 13);
            this._Lbl_Ginc.TabIndex = 62;
            this._Lbl_Ginc.Text = "Grupo a incentivar:";
            // 
            // _Cmb_Grupo_D
            // 
            this._Cmb_Grupo_D.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Grupo_D.Enabled = false;
            this._Cmb_Grupo_D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Grupo_D.Font = new System.Drawing.Font("Verdana", 6.75F);
            this._Cmb_Grupo_D.FormattingEnabled = true;
            this._Cmb_Grupo_D.Location = new System.Drawing.Point(17, 114);
            this._Cmb_Grupo_D.Name = "_Cmb_Grupo_D";
            this._Cmb_Grupo_D.Size = new System.Drawing.Size(374, 20);
            this._Cmb_Grupo_D.TabIndex = 60;
            this._Cmb_Grupo_D.SelectedIndexChanged += new System.EventHandler(this._Cmb_Grupo_D_SelectedIndexChanged);
            this._Cmb_Grupo_D.DropDown += new System.EventHandler(this._Cmb_Grupo_D_DropDown);
            // 
            // _Lbl_Id
            // 
            this._Lbl_Id.AutoSize = true;
            this._Lbl_Id.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Lbl_Id.Location = new System.Drawing.Point(14, 10);
            this._Lbl_Id.Name = "_Lbl_Id";
            this._Lbl_Id.Size = new System.Drawing.Size(25, 13);
            this._Lbl_Id.TabIndex = 61;
            this._Lbl_Id.Text = "Id:";
            // 
            // _Txt_cidincvarios
            // 
            this._Txt_cidincvarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_cidincvarios.Enabled = false;
            this._Txt_cidincvarios.Font = new System.Drawing.Font("Verdana", 8.25F);
            this._Txt_cidincvarios.Location = new System.Drawing.Point(17, 26);
            this._Txt_cidincvarios.Name = "_Txt_cidincvarios";
            this._Txt_cidincvarios.Size = new System.Drawing.Size(48, 21);
            this._Txt_cidincvarios.TabIndex = 58;
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // _Cntx_Menu
            // 
            this._Cntx_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarToolStripMenuItem});
            this._Cntx_Menu.Name = "_Cntx_Menu";
            this._Cntx_Menu.Size = new System.Drawing.Size(122, 26);
            this._Cntx_Menu.Opening += new System.ComponentModel.CancelEventHandler(this._Cntx_Menu_Opening);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // _Pnl_Clave
            // 
            this._Pnl_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Clave.Controls.Add(this._Bt_AceptarClave);
            this._Pnl_Clave.Controls.Add(this.label8);
            this._Pnl_Clave.Controls.Add(this._Txt_Clave);
            this._Pnl_Clave.Controls.Add(this._Bt_CancelarClave);
            this._Pnl_Clave.Controls.Add(this.label9);
            this._Pnl_Clave.Location = new System.Drawing.Point(411, 102);
            this._Pnl_Clave.Name = "_Pnl_Clave";
            this._Pnl_Clave.Size = new System.Drawing.Size(154, 86);
            this._Pnl_Clave.TabIndex = 156;
            this._Pnl_Clave.Visible = false;
            this._Pnl_Clave.VisibleChanged += new System.EventHandler(this._Pnl_Clave_VisibleChanged);
            // 
            // _Bt_AceptarClave
            // 
            this._Bt_AceptarClave.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_AceptarClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_AceptarClave.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_AceptarClave.Location = new System.Drawing.Point(22, 55);
            this._Bt_AceptarClave.Name = "_Bt_AceptarClave";
            this._Bt_AceptarClave.Size = new System.Drawing.Size(62, 22);
            this._Bt_AceptarClave.TabIndex = 70;
            this._Bt_AceptarClave.Text = "Aceptar";
            this._Bt_AceptarClave.UseVisualStyleBackColor = true;
            this._Bt_AceptarClave.Click += new System.EventHandler(this._Bt_AceptarClave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 68;
            this.label8.Text = "Clave:";
            // 
            // _Txt_Clave
            // 
            this._Txt_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Clave.Location = new System.Drawing.Point(52, 31);
            this._Txt_Clave.Name = "_Txt_Clave";
            this._Txt_Clave.PasswordChar = '*';
            this._Txt_Clave.Size = new System.Drawing.Size(95, 21);
            this._Txt_Clave.TabIndex = 2;
            // 
            // _Bt_CancelarClave
            // 
            this._Bt_CancelarClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_CancelarClave.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_CancelarClave.Location = new System.Drawing.Point(85, 55);
            this._Bt_CancelarClave.Name = "_Bt_CancelarClave";
            this._Bt_CancelarClave.Size = new System.Drawing.Size(62, 22);
            this._Bt_CancelarClave.TabIndex = 1;
            this._Bt_CancelarClave.Text = "Cancelar";
            this._Bt_CancelarClave.UseVisualStyleBackColor = true;
            this._Bt_CancelarClave.Click += new System.EventHandler(this._Bt_CancelarClave_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Navy;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 18);
            this.label9.TabIndex = 0;
            this.label9.Text = "Introduzca Clave";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_IncVarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 441);
            this.Controls.Add(this._Pnl_Clave);
            this.Controls.Add(this._Tb_Tab);
            this.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_IncVarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parámetros - Incentivos Varios";
            this.Load += new System.EventHandler(this.Frm_IncVarios_Load);
            this.Shown += new System.EventHandler(this.Frm_IncVarios_Shown);
            this.Activated += new System.EventHandler(this.Frm_IncVarios_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_IncVarios_FormClosing);
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this._Pnl_Consulta_1.ResumeLayout(false);
            this._Pnl_Consulta_1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this._Pnl_Detalle_2.ResumeLayout(false);
            this._GrpB_Activacion.ResumeLayout(false);
            this._GrpB_Activacion.PerformLayout();
            this._GrpB_Efectividad.ResumeLayout(false);
            this._GrpB_Efectividad.PerformLayout();
            this._GrpB_Devolucion.ResumeLayout(false);
            this._GrpB_Devolucion.PerformLayout();
            this._Pnl_Detalle_1.ResumeLayout(false);
            this._Pnl_Detalle_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this._Cntx_Menu.ResumeLayout(false);
            this._Pnl_Clave.ResumeLayout(false);
            this._Pnl_Clave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel _Pnl_Consulta_1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel _Pnl_Detalle_1;
        private System.Windows.Forms.GroupBox _GrpB_Devolucion;
        private System.Windows.Forms.TextBox _Txt_ccomisionpag_devolucion;
        private System.Windows.Forms.Label _Lbl_Condicion_Devolucion;
        private System.Windows.Forms.TextBox _Txt_ccondicion_devolucion;
        private System.Windows.Forms.Label _Lbl_Comision_Devolucion;
        private System.Windows.Forms.GroupBox _GrpB_Efectividad;
        private System.Windows.Forms.Label _Lbl_Comision_Efectividad;
        private System.Windows.Forms.Button _Bt_Efectividad;
        private System.Windows.Forms.TextBox _Txt_ccondicion_efectividad;
        private System.Windows.Forms.Label _Lbl_Condicion_Efectividad;
        private System.Windows.Forms.TextBox _Txt_ccomisionpag_efectividad;
        private System.Windows.Forms.Label _Lbl_CargoD;
        private System.Windows.Forms.ComboBox _Cmb_Cargo_D;
        private System.Windows.Forms.Label _Lbl_Ginc;
        private System.Windows.Forms.ComboBox _Cmb_Grupo_D;
        private System.Windows.Forms.Label _Lbl_Id;
        private System.Windows.Forms.TextBox _Txt_cidincvarios;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.Button _Bt_Consultar;
        private System.Windows.Forms.Label _Lbl_Cargo;
        private System.Windows.Forms.ComboBox _Cmb_Cargo;
        private System.Windows.Forms.Button _Bt_Devolucion;
        private System.Windows.Forms.Panel _Pnl_Detalle_2;
        private System.Windows.Forms.GroupBox _GrpB_Activacion;
        private System.Windows.Forms.Button _Bt_Activacion;
        private System.Windows.Forms.Label _Lbl_Comision_Activacion;
        private System.Windows.Forms.TextBox _Txt_ccondicion_activacion;
        private System.Windows.Forms.Label _Lbl_Condicion_Activacion;
        private System.Windows.Forms.TextBox _Txt_ccomisionpag_activacion;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _Txt_cmontominvisefec;
        private System.Windows.Forms.ContextMenuStrip _Cntx_Menu;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.Panel _Pnl_Clave;
        private System.Windows.Forms.Button _Bt_AceptarClave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _Txt_Clave;
        private System.Windows.Forms.Button _Bt_CancelarClave;
        private System.Windows.Forms.Label label9;
    }
}