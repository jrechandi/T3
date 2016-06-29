namespace T3
{
    partial class Frm_IncVentas
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_IncVentas));
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this._Cntx_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._Pnl_Consulta = new System.Windows.Forms.Panel();
            this._Bt_Consultar = new System.Windows.Forms.Button();
            this.Cargo = new System.Windows.Forms.Label();
            this._Cmb_Cargo = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._Pnl_Detalle = new System.Windows.Forms.Panel();
            this._Bt_Cuota_Condicion1 = new System.Windows.Forms.Button();
            this._Bt_Cuota_Condicion3 = new System.Windows.Forms.Button();
            this._GrpB_Cond11 = new System.Windows.Forms.GroupBox();
            this._Txt_cuota_ccomision1 = new System.Windows.Forms.TextBox();
            this._Lbl_2_Cuota_Cond1 = new System.Windows.Forms.Label();
            this._Lbl_1_Cuota_Cond1 = new System.Windows.Forms.Label();
            this._Txt_cuota_ccondicion1 = new System.Windows.Forms.TextBox();
            this._Bt_Cuota_Condicion2 = new System.Windows.Forms.Button();
            this._GrpB_Cond13 = new System.Windows.Forms.GroupBox();
            this._Txt_cuota_ccomision3 = new System.Windows.Forms.TextBox();
            this._Lbl_2_Cuota_Cond3 = new System.Windows.Forms.Label();
            this._Lbl_1_Cuota_Cond3 = new System.Windows.Forms.Label();
            this._Txt_cuota_ccondicion3 = new System.Windows.Forms.TextBox();
            this._GrpB_Cond12 = new System.Windows.Forms.GroupBox();
            this._Txt_cuota_ccomision2 = new System.Windows.Forms.TextBox();
            this._Lbl_2_Cuota_Cond2 = new System.Windows.Forms.Label();
            this._Lbl_1_Cuota_Cond2 = new System.Windows.Forms.Label();
            this._Txt_cuota_ccondicion2 = new System.Windows.Forms.TextBox();
            this._Pnl_Superior = new System.Windows.Forms.Panel();
            this._Lbl_Grupo = new System.Windows.Forms.Label();
            this._Lbl_Periodo = new System.Windows.Forms.Label();
            this._Rbt_Periodo = new System.Windows.Forms.RadioButton();
            this._Rbt_Fijo = new System.Windows.Forms.RadioButton();
            this._Grb_Fechas = new System.Windows.Forms.GroupBox();
            this._Dtp_Hasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this._Lbl_5 = new System.Windows.Forms.Label();
            this._Dtp_Desde = new System.Windows.Forms.DateTimePicker();
            this._Pnl_Parametros = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this._Cmb_Grupo_D = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this._Cmb_Cargo_D = new System.Windows.Forms.ComboBox();
            this._Bt_Aceptar = new System.Windows.Forms.Button();
            this._Bt_Cancelar = new System.Windows.Forms.Button();
            this._Bt_Cerrar = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Pnl_Clave = new System.Windows.Forms.Panel();
            this._Bt_AceptarClave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this._Txt_Clave = new System.Windows.Forms.TextBox();
            this._Bt_CancelarClave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this._Cntx_Menu.SuspendLayout();
            this._Pnl_Consulta.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this._Pnl_Detalle.SuspendLayout();
            this._GrpB_Cond11.SuspendLayout();
            this._GrpB_Cond13.SuspendLayout();
            this._GrpB_Cond12.SuspendLayout();
            this._Pnl_Superior.SuspendLayout();
            this._Grb_Fechas.SuspendLayout();
            this._Pnl_Parametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this._Pnl_Clave.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Tb_Tab
            // 
            this._Tb_Tab.Controls.Add(this.tabPage1);
            this._Tb_Tab.Controls.Add(this.tabPage2);
            this._Tb_Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Tb_Tab.Font = new System.Drawing.Font("Verdana", 8.25F);
            this._Tb_Tab.Location = new System.Drawing.Point(0, 0);
            this._Tb_Tab.Name = "_Tb_Tab";
            this._Tb_Tab.SelectedIndex = 0;
            this._Tb_Tab.Size = new System.Drawing.Size(557, 428);
            this._Tb_Tab.TabIndex = 2;
            this._Tb_Tab.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this._Tb_Tab_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._Dg_Grid);
            this.tabPage1.Controls.Add(this._Pnl_Consulta);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(549, 402);
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
            this._Dg_Grid.Location = new System.Drawing.Point(3, 76);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.Size = new System.Drawing.Size(543, 323);
            this._Dg_Grid.TabIndex = 18;
            this._Dg_Grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseDoubleClick);
            // 
            // _Cntx_Menu
            // 
            this._Cntx_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarToolStripMenuItem});
            this._Cntx_Menu.Name = "_Cntx_Menu";
            this._Cntx_Menu.Size = new System.Drawing.Size(114, 26);
            this._Cntx_Menu.Opening += new System.ComponentModel.CancelEventHandler(this._Cntx_Menu_Opening);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // _Pnl_Consulta
            // 
            this._Pnl_Consulta.Controls.Add(this._Bt_Consultar);
            this._Pnl_Consulta.Controls.Add(this.Cargo);
            this._Pnl_Consulta.Controls.Add(this._Cmb_Cargo);
            this._Pnl_Consulta.Dock = System.Windows.Forms.DockStyle.Top;
            this._Pnl_Consulta.Location = new System.Drawing.Point(3, 3);
            this._Pnl_Consulta.Name = "_Pnl_Consulta";
            this._Pnl_Consulta.Size = new System.Drawing.Size(543, 73);
            this._Pnl_Consulta.TabIndex = 1;
            // 
            // _Bt_Consultar
            // 
            this._Bt_Consultar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Bt_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Consultar.Image")));
            this._Bt_Consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Consultar.Location = new System.Drawing.Point(364, 17);
            this._Bt_Consultar.Name = "_Bt_Consultar";
            this._Bt_Consultar.Size = new System.Drawing.Size(114, 40);
            this._Bt_Consultar.TabIndex = 6;
            this._Bt_Consultar.Text = "Consultar";
            this._Bt_Consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Consultar.UseVisualStyleBackColor = true;
            this._Bt_Consultar.Click += new System.EventHandler(this._Bt_Consultar_Click);
            // 
            // Cargo
            // 
            this.Cargo.AutoSize = true;
            this.Cargo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.Cargo.Location = new System.Drawing.Point(13, 11);
            this.Cargo.Name = "Cargo";
            this.Cargo.Size = new System.Drawing.Size(49, 13);
            this.Cargo.TabIndex = 8;
            this.Cargo.Text = "Cargo:";
            // 
            // _Cmb_Cargo
            // 
            this._Cmb_Cargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Cargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Cargo.Font = new System.Drawing.Font("Verdana", 6.75F);
            this._Cmb_Cargo.FormattingEnabled = true;
            this._Cmb_Cargo.Location = new System.Drawing.Point(16, 29);
            this._Cmb_Cargo.Name = "_Cmb_Cargo";
            this._Cmb_Cargo.Size = new System.Drawing.Size(327, 20);
            this._Cmb_Cargo.TabIndex = 7;
            this._Cmb_Cargo.DropDown += new System.EventHandler(this._Cmb_Cargo_DropDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._Pnl_Detalle);
            this.tabPage2.Controls.Add(this._Pnl_Superior);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(549, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _Pnl_Detalle
            // 
            this._Pnl_Detalle.Controls.Add(this._Bt_Cuota_Condicion1);
            this._Pnl_Detalle.Controls.Add(this._Bt_Cuota_Condicion3);
            this._Pnl_Detalle.Controls.Add(this._GrpB_Cond11);
            this._Pnl_Detalle.Controls.Add(this._Bt_Cuota_Condicion2);
            this._Pnl_Detalle.Controls.Add(this._GrpB_Cond13);
            this._Pnl_Detalle.Controls.Add(this._GrpB_Cond12);
            this._Pnl_Detalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Pnl_Detalle.Enabled = false;
            this._Pnl_Detalle.Location = new System.Drawing.Point(3, 107);
            this._Pnl_Detalle.Name = "_Pnl_Detalle";
            this._Pnl_Detalle.Size = new System.Drawing.Size(543, 292);
            this._Pnl_Detalle.TabIndex = 53;
            // 
            // _Bt_Cuota_Condicion1
            // 
            this._Bt_Cuota_Condicion1.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Cuota_Condicion1.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Cuota_Condicion1.Image")));
            this._Bt_Cuota_Condicion1.Location = new System.Drawing.Point(507, 10);
            this._Bt_Cuota_Condicion1.Name = "_Bt_Cuota_Condicion1";
            this._Bt_Cuota_Condicion1.Size = new System.Drawing.Size(22, 19);
            this._Bt_Cuota_Condicion1.TabIndex = 48;
            this._Bt_Cuota_Condicion1.UseVisualStyleBackColor = true;
            this._Bt_Cuota_Condicion1.Click += new System.EventHandler(this._Bt_Cuota_Condicion1_Click);
            // 
            // _Bt_Cuota_Condicion3
            // 
            this._Bt_Cuota_Condicion3.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Cuota_Condicion3.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Cuota_Condicion3.Image")));
            this._Bt_Cuota_Condicion3.Location = new System.Drawing.Point(507, 222);
            this._Bt_Cuota_Condicion3.Name = "_Bt_Cuota_Condicion3";
            this._Bt_Cuota_Condicion3.Size = new System.Drawing.Size(22, 19);
            this._Bt_Cuota_Condicion3.TabIndex = 52;
            this._Bt_Cuota_Condicion3.UseVisualStyleBackColor = true;
            this._Bt_Cuota_Condicion3.Click += new System.EventHandler(this._Bt_Cuota_Condicion3_Click);
            // 
            // _GrpB_Cond11
            // 
            this._GrpB_Cond11.Controls.Add(this._Txt_cuota_ccomision1);
            this._GrpB_Cond11.Controls.Add(this._Lbl_2_Cuota_Cond1);
            this._GrpB_Cond11.Controls.Add(this._Lbl_1_Cuota_Cond1);
            this._GrpB_Cond11.Controls.Add(this._Txt_cuota_ccondicion1);
            this._GrpB_Cond11.Enabled = false;
            this._GrpB_Cond11.Location = new System.Drawing.Point(8, 10);
            this._GrpB_Cond11.Name = "_GrpB_Cond11";
            this._GrpB_Cond11.Size = new System.Drawing.Size(512, 60);
            this._GrpB_Cond11.TabIndex = 47;
            this._GrpB_Cond11.TabStop = false;
            this._GrpB_Cond11.Text = "Condición #1";
            // 
            // _Txt_cuota_ccomision1
            // 
            this._Txt_cuota_ccomision1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_cuota_ccomision1.Location = new System.Drawing.Point(418, 25);
            this._Txt_cuota_ccomision1.MaxLength = 13;
            this._Txt_cuota_ccomision1.Name = "_Txt_cuota_ccomision1";
            this._Txt_cuota_ccomision1.Size = new System.Drawing.Size(88, 21);
            this._Txt_cuota_ccomision1.TabIndex = 47;
            this._Txt_cuota_ccomision1.TextChanged += new System.EventHandler(this._Txt_cuota_ccomision1_TextChanged);
            this._Txt_cuota_ccomision1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_cuota_ccomision1_KeyPress);
            // 
            // _Lbl_2_Cuota_Cond1
            // 
            this._Lbl_2_Cuota_Cond1.AutoSize = true;
            this._Lbl_2_Cuota_Cond1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_2_Cuota_Cond1.Location = new System.Drawing.Point(336, 28);
            this._Lbl_2_Cuota_Cond1.Name = "_Lbl_2_Cuota_Cond1";
            this._Lbl_2_Cuota_Cond1.Size = new System.Drawing.Size(76, 13);
            this._Lbl_2_Cuota_Cond1.TabIndex = 16;
            this._Lbl_2_Cuota_Cond1.Text = "BsF pagar:";
            // 
            // _Lbl_1_Cuota_Cond1
            // 
            this._Lbl_1_Cuota_Cond1.AutoSize = true;
            this._Lbl_1_Cuota_Cond1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_1_Cuota_Cond1.Location = new System.Drawing.Point(16, 28);
            this._Lbl_1_Cuota_Cond1.Name = "_Lbl_1_Cuota_Cond1";
            this._Lbl_1_Cuota_Cond1.Size = new System.Drawing.Size(106, 13);
            this._Lbl_1_Cuota_Cond1.TabIndex = 15;
            this._Lbl_1_Cuota_Cond1.Text = "Cobertura (%):";
            // 
            // _Txt_cuota_ccondicion1
            // 
            this._Txt_cuota_ccondicion1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_cuota_ccondicion1.Location = new System.Drawing.Point(126, 25);
            this._Txt_cuota_ccondicion1.MaxLength = 100;
            this._Txt_cuota_ccondicion1.Name = "_Txt_cuota_ccondicion1";
            this._Txt_cuota_ccondicion1.Size = new System.Drawing.Size(204, 21);
            this._Txt_cuota_ccondicion1.TabIndex = 14;
            // 
            // _Bt_Cuota_Condicion2
            // 
            this._Bt_Cuota_Condicion2.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Cuota_Condicion2.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Cuota_Condicion2.Image")));
            this._Bt_Cuota_Condicion2.Location = new System.Drawing.Point(507, 116);
            this._Bt_Cuota_Condicion2.Name = "_Bt_Cuota_Condicion2";
            this._Bt_Cuota_Condicion2.Size = new System.Drawing.Size(22, 19);
            this._Bt_Cuota_Condicion2.TabIndex = 50;
            this._Bt_Cuota_Condicion2.UseVisualStyleBackColor = true;
            this._Bt_Cuota_Condicion2.Click += new System.EventHandler(this._Bt_Cuota_Condicion2_Click);
            // 
            // _GrpB_Cond13
            // 
            this._GrpB_Cond13.Controls.Add(this._Txt_cuota_ccomision3);
            this._GrpB_Cond13.Controls.Add(this._Lbl_2_Cuota_Cond3);
            this._GrpB_Cond13.Controls.Add(this._Lbl_1_Cuota_Cond3);
            this._GrpB_Cond13.Controls.Add(this._Txt_cuota_ccondicion3);
            this._GrpB_Cond13.Enabled = false;
            this._GrpB_Cond13.Location = new System.Drawing.Point(8, 222);
            this._GrpB_Cond13.Name = "_GrpB_Cond13";
            this._GrpB_Cond13.Size = new System.Drawing.Size(512, 60);
            this._GrpB_Cond13.TabIndex = 51;
            this._GrpB_Cond13.TabStop = false;
            this._GrpB_Cond13.Text = "Condición #3";
            // 
            // _Txt_cuota_ccomision3
            // 
            this._Txt_cuota_ccomision3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_cuota_ccomision3.Location = new System.Drawing.Point(418, 25);
            this._Txt_cuota_ccomision3.MaxLength = 13;
            this._Txt_cuota_ccomision3.Name = "_Txt_cuota_ccomision3";
            this._Txt_cuota_ccomision3.Size = new System.Drawing.Size(88, 21);
            this._Txt_cuota_ccomision3.TabIndex = 48;
            this._Txt_cuota_ccomision3.TextChanged += new System.EventHandler(this._Txt_cuota_ccomision3_TextChanged);
            this._Txt_cuota_ccomision3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_cuota_ccomision3_KeyPress);
            // 
            // _Lbl_2_Cuota_Cond3
            // 
            this._Lbl_2_Cuota_Cond3.AutoSize = true;
            this._Lbl_2_Cuota_Cond3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_2_Cuota_Cond3.Location = new System.Drawing.Point(336, 28);
            this._Lbl_2_Cuota_Cond3.Name = "_Lbl_2_Cuota_Cond3";
            this._Lbl_2_Cuota_Cond3.Size = new System.Drawing.Size(76, 13);
            this._Lbl_2_Cuota_Cond3.TabIndex = 16;
            this._Lbl_2_Cuota_Cond3.Text = "BsF pagar:";
            // 
            // _Lbl_1_Cuota_Cond3
            // 
            this._Lbl_1_Cuota_Cond3.AutoSize = true;
            this._Lbl_1_Cuota_Cond3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_1_Cuota_Cond3.Location = new System.Drawing.Point(16, 28);
            this._Lbl_1_Cuota_Cond3.Name = "_Lbl_1_Cuota_Cond3";
            this._Lbl_1_Cuota_Cond3.Size = new System.Drawing.Size(106, 13);
            this._Lbl_1_Cuota_Cond3.TabIndex = 15;
            this._Lbl_1_Cuota_Cond3.Text = "Cobertura (%):";
            // 
            // _Txt_cuota_ccondicion3
            // 
            this._Txt_cuota_ccondicion3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_cuota_ccondicion3.Location = new System.Drawing.Point(126, 25);
            this._Txt_cuota_ccondicion3.MaxLength = 100;
            this._Txt_cuota_ccondicion3.Name = "_Txt_cuota_ccondicion3";
            this._Txt_cuota_ccondicion3.Size = new System.Drawing.Size(204, 21);
            this._Txt_cuota_ccondicion3.TabIndex = 14;
            // 
            // _GrpB_Cond12
            // 
            this._GrpB_Cond12.Controls.Add(this._Txt_cuota_ccomision2);
            this._GrpB_Cond12.Controls.Add(this._Lbl_2_Cuota_Cond2);
            this._GrpB_Cond12.Controls.Add(this._Lbl_1_Cuota_Cond2);
            this._GrpB_Cond12.Controls.Add(this._Txt_cuota_ccondicion2);
            this._GrpB_Cond12.Enabled = false;
            this._GrpB_Cond12.Location = new System.Drawing.Point(8, 116);
            this._GrpB_Cond12.Name = "_GrpB_Cond12";
            this._GrpB_Cond12.Size = new System.Drawing.Size(512, 60);
            this._GrpB_Cond12.TabIndex = 49;
            this._GrpB_Cond12.TabStop = false;
            this._GrpB_Cond12.Text = "Condición #2";
            // 
            // _Txt_cuota_ccomision2
            // 
            this._Txt_cuota_ccomision2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_cuota_ccomision2.Location = new System.Drawing.Point(418, 25);
            this._Txt_cuota_ccomision2.MaxLength = 13;
            this._Txt_cuota_ccomision2.Name = "_Txt_cuota_ccomision2";
            this._Txt_cuota_ccomision2.Size = new System.Drawing.Size(88, 21);
            this._Txt_cuota_ccomision2.TabIndex = 48;
            this._Txt_cuota_ccomision2.TextChanged += new System.EventHandler(this._Txt_cuota_ccomision2_TextChanged);
            this._Txt_cuota_ccomision2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_cuota_ccomision2_KeyPress);
            // 
            // _Lbl_2_Cuota_Cond2
            // 
            this._Lbl_2_Cuota_Cond2.AutoSize = true;
            this._Lbl_2_Cuota_Cond2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_2_Cuota_Cond2.Location = new System.Drawing.Point(336, 28);
            this._Lbl_2_Cuota_Cond2.Name = "_Lbl_2_Cuota_Cond2";
            this._Lbl_2_Cuota_Cond2.Size = new System.Drawing.Size(76, 13);
            this._Lbl_2_Cuota_Cond2.TabIndex = 16;
            this._Lbl_2_Cuota_Cond2.Text = "BsF pagar:";
            // 
            // _Lbl_1_Cuota_Cond2
            // 
            this._Lbl_1_Cuota_Cond2.AutoSize = true;
            this._Lbl_1_Cuota_Cond2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_1_Cuota_Cond2.Location = new System.Drawing.Point(16, 28);
            this._Lbl_1_Cuota_Cond2.Name = "_Lbl_1_Cuota_Cond2";
            this._Lbl_1_Cuota_Cond2.Size = new System.Drawing.Size(106, 13);
            this._Lbl_1_Cuota_Cond2.TabIndex = 15;
            this._Lbl_1_Cuota_Cond2.Text = "Cobertura (%):";
            // 
            // _Txt_cuota_ccondicion2
            // 
            this._Txt_cuota_ccondicion2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_cuota_ccondicion2.Location = new System.Drawing.Point(126, 25);
            this._Txt_cuota_ccondicion2.MaxLength = 100;
            this._Txt_cuota_ccondicion2.Name = "_Txt_cuota_ccondicion2";
            this._Txt_cuota_ccondicion2.Size = new System.Drawing.Size(204, 21);
            this._Txt_cuota_ccondicion2.TabIndex = 14;
            // 
            // _Pnl_Superior
            // 
            this._Pnl_Superior.Controls.Add(this._Lbl_Grupo);
            this._Pnl_Superior.Controls.Add(this._Lbl_Periodo);
            this._Pnl_Superior.Controls.Add(this._Rbt_Periodo);
            this._Pnl_Superior.Controls.Add(this._Rbt_Fijo);
            this._Pnl_Superior.Controls.Add(this._Grb_Fechas);
            this._Pnl_Superior.Dock = System.Windows.Forms.DockStyle.Top;
            this._Pnl_Superior.Enabled = false;
            this._Pnl_Superior.Location = new System.Drawing.Point(3, 3);
            this._Pnl_Superior.Name = "_Pnl_Superior";
            this._Pnl_Superior.Size = new System.Drawing.Size(543, 104);
            this._Pnl_Superior.TabIndex = 0;
            // 
            // _Lbl_Grupo
            // 
            this._Lbl_Grupo.AutoSize = true;
            this._Lbl_Grupo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_Grupo.Location = new System.Drawing.Point(280, 16);
            this._Lbl_Grupo.Name = "_Lbl_Grupo";
            this._Lbl_Grupo.Size = new System.Drawing.Size(81, 13);
            this._Lbl_Grupo.TabIndex = 16;
            this._Lbl_Grupo.Text = "_Lbl_Grupo";
            // 
            // _Lbl_Periodo
            // 
            this._Lbl_Periodo.AutoSize = true;
            this._Lbl_Periodo.Enabled = false;
            this._Lbl_Periodo.Location = new System.Drawing.Point(87, 14);
            this._Lbl_Periodo.Name = "_Lbl_Periodo";
            this._Lbl_Periodo.Size = new System.Drawing.Size(126, 13);
            this._Lbl_Periodo.TabIndex = 13;
            this._Lbl_Periodo.Text = "Período de ejecución";
            this._Lbl_Periodo.Click += new System.EventHandler(this._Lbl_Periodo_Click);
            // 
            // _Rbt_Periodo
            // 
            this._Rbt_Periodo.AutoSize = true;
            this._Rbt_Periodo.Enabled = false;
            this._Rbt_Periodo.Font = new System.Drawing.Font("Verdana", 8.25F);
            this._Rbt_Periodo.Location = new System.Drawing.Point(71, 14);
            this._Rbt_Periodo.Name = "_Rbt_Periodo";
            this._Rbt_Periodo.Size = new System.Drawing.Size(14, 13);
            this._Rbt_Periodo.TabIndex = 12;
            this._Rbt_Periodo.TabStop = true;
            this._Rbt_Periodo.UseVisualStyleBackColor = true;
            this._Rbt_Periodo.CheckedChanged += new System.EventHandler(this._Rbt_Periodo_CheckedChanged);
            // 
            // _Rbt_Fijo
            // 
            this._Rbt_Fijo.AutoSize = true;
            this._Rbt_Fijo.Font = new System.Drawing.Font("Verdana", 8.25F);
            this._Rbt_Fijo.Location = new System.Drawing.Point(10, 12);
            this._Rbt_Fijo.Name = "_Rbt_Fijo";
            this._Rbt_Fijo.Size = new System.Drawing.Size(45, 17);
            this._Rbt_Fijo.TabIndex = 10;
            this._Rbt_Fijo.TabStop = true;
            this._Rbt_Fijo.Text = "Fijo";
            this._Rbt_Fijo.UseVisualStyleBackColor = true;
            this._Rbt_Fijo.CheckedChanged += new System.EventHandler(this._Rbt_Fijo_CheckedChanged);
            // 
            // _Grb_Fechas
            // 
            this._Grb_Fechas.Controls.Add(this._Dtp_Hasta);
            this._Grb_Fechas.Controls.Add(this.label2);
            this._Grb_Fechas.Controls.Add(this._Lbl_5);
            this._Grb_Fechas.Controls.Add(this._Dtp_Desde);
            this._Grb_Fechas.Enabled = false;
            this._Grb_Fechas.Font = new System.Drawing.Font("Verdana", 8.25F);
            this._Grb_Fechas.Location = new System.Drawing.Point(76, 14);
            this._Grb_Fechas.Name = "_Grb_Fechas";
            this._Grb_Fechas.Size = new System.Drawing.Size(198, 81);
            this._Grb_Fechas.TabIndex = 11;
            this._Grb_Fechas.TabStop = false;
            this._Grb_Fechas.Text = "          ";
            // 
            // _Dtp_Hasta
            // 
            this._Dtp_Hasta.Font = new System.Drawing.Font("Verdana", 8.25F);
            this._Dtp_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dtp_Hasta.Location = new System.Drawing.Point(69, 44);
            this._Dtp_Hasta.Name = "_Dtp_Hasta";
            this._Dtp_Hasta.Size = new System.Drawing.Size(95, 21);
            this._Dtp_Hasta.TabIndex = 12;
            this._Dtp_Hasta.ValueChanged += new System.EventHandler(this._Dtp_Hasta_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Hasta:";
            // 
            // _Lbl_5
            // 
            this._Lbl_5.AutoSize = true;
            this._Lbl_5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_5.Location = new System.Drawing.Point(15, 20);
            this._Lbl_5.Name = "_Lbl_5";
            this._Lbl_5.Size = new System.Drawing.Size(48, 13);
            this._Lbl_5.TabIndex = 10;
            this._Lbl_5.Text = "Desde:";
            // 
            // _Dtp_Desde
            // 
            this._Dtp_Desde.Font = new System.Drawing.Font("Verdana", 8.25F);
            this._Dtp_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dtp_Desde.Location = new System.Drawing.Point(69, 17);
            this._Dtp_Desde.Name = "_Dtp_Desde";
            this._Dtp_Desde.Size = new System.Drawing.Size(95, 21);
            this._Dtp_Desde.TabIndex = 1;
            // 
            // _Pnl_Parametros
            // 
            this._Pnl_Parametros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Parametros.Controls.Add(this.label3);
            this._Pnl_Parametros.Controls.Add(this._Cmb_Grupo_D);
            this._Pnl_Parametros.Controls.Add(this.label4);
            this._Pnl_Parametros.Controls.Add(this._Cmb_Cargo_D);
            this._Pnl_Parametros.Controls.Add(this._Bt_Aceptar);
            this._Pnl_Parametros.Controls.Add(this._Bt_Cancelar);
            this._Pnl_Parametros.Controls.Add(this._Bt_Cerrar);
            this._Pnl_Parametros.Controls.Add(this.label13);
            this._Pnl_Parametros.Location = new System.Drawing.Point(191, 144);
            this._Pnl_Parametros.Name = "_Pnl_Parametros";
            this._Pnl_Parametros.Size = new System.Drawing.Size(341, 149);
            this._Pnl_Parametros.TabIndex = 152;
            this._Pnl_Parametros.Visible = false;
            this._Pnl_Parametros.VisibleChanged += new System.EventHandler(this._Pnl_Parametros_VisibleChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Grupo a incentivar:";
            // 
            // _Cmb_Grupo_D
            // 
            this._Cmb_Grupo_D.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Grupo_D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Grupo_D.Font = new System.Drawing.Font("Verdana", 6.75F);
            this._Cmb_Grupo_D.FormattingEnabled = true;
            this._Cmb_Grupo_D.Location = new System.Drawing.Point(6, 85);
            this._Cmb_Grupo_D.Name = "_Cmb_Grupo_D";
            this._Cmb_Grupo_D.Size = new System.Drawing.Size(327, 20);
            this._Cmb_Grupo_D.TabIndex = 13;
            this._Cmb_Grupo_D.SelectedIndexChanged += new System.EventHandler(this._Cmb_Grupo_D_SelectedIndexChanged);
            this._Cmb_Grupo_D.DropDown += new System.EventHandler(this._Cmb_Grupo_D_DropDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(3, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cargo:";
            // 
            // _Cmb_Cargo_D
            // 
            this._Cmb_Cargo_D.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Cargo_D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Cargo_D.Font = new System.Drawing.Font("Verdana", 6.75F);
            this._Cmb_Cargo_D.FormattingEnabled = true;
            this._Cmb_Cargo_D.Location = new System.Drawing.Point(6, 44);
            this._Cmb_Cargo_D.Name = "_Cmb_Cargo_D";
            this._Cmb_Cargo_D.Size = new System.Drawing.Size(327, 20);
            this._Cmb_Cargo_D.TabIndex = 11;
            this._Cmb_Cargo_D.SelectedIndexChanged += new System.EventHandler(this._Cmb_Cargo_D_SelectedIndexChanged);
            this._Cmb_Cargo_D.DropDown += new System.EventHandler(this._Cmb_Cargo_D_DropDown);
            // 
            // _Bt_Aceptar
            // 
            this._Bt_Aceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Aceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Aceptar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Aceptar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Aceptar.Image")));
            this._Bt_Aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Aceptar.Location = new System.Drawing.Point(115, 109);
            this._Bt_Aceptar.Name = "_Bt_Aceptar";
            this._Bt_Aceptar.Size = new System.Drawing.Size(107, 32);
            this._Bt_Aceptar.TabIndex = 3;
            this._Bt_Aceptar.Text = "Aceptar..";
            this._Bt_Aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Aceptar.UseVisualStyleBackColor = true;
            this._Bt_Aceptar.Click += new System.EventHandler(this._Bt_Aceptar_Click);
            // 
            // _Bt_Cancelar
            // 
            this._Bt_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Cancelar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Cancelar.Image")));
            this._Bt_Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Cancelar.Location = new System.Drawing.Point(228, 109);
            this._Bt_Cancelar.Name = "_Bt_Cancelar";
            this._Bt_Cancelar.Size = new System.Drawing.Size(107, 32);
            this._Bt_Cancelar.TabIndex = 4;
            this._Bt_Cancelar.Text = "Cancelar..";
            this._Bt_Cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Cancelar.UseVisualStyleBackColor = true;
            this._Bt_Cancelar.Click += new System.EventHandler(this._Bt_Cancelar_Click);
            // 
            // _Bt_Cerrar
            // 
            this._Bt_Cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Bt_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Cerrar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Cerrar.Image")));
            this._Bt_Cerrar.Location = new System.Drawing.Point(313, -1);
            this._Bt_Cerrar.Name = "_Bt_Cerrar";
            this._Bt_Cerrar.Size = new System.Drawing.Size(27, 28);
            this._Bt_Cerrar.TabIndex = 5;
            this._Bt_Cerrar.UseVisualStyleBackColor = true;
            this._Bt_Cerrar.Click += new System.EventHandler(this._Bt_Cerrar_Click);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Navy;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(339, 18);
            this.label13.TabIndex = 0;
            this.label13.Text = "Parámetros";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // _Pnl_Clave
            // 
            this._Pnl_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Clave.Controls.Add(this._Bt_AceptarClave);
            this._Pnl_Clave.Controls.Add(this.label8);
            this._Pnl_Clave.Controls.Add(this._Txt_Clave);
            this._Pnl_Clave.Controls.Add(this._Bt_CancelarClave);
            this._Pnl_Clave.Controls.Add(this.label9);
            this._Pnl_Clave.Location = new System.Drawing.Point(377, 216);
            this._Pnl_Clave.Name = "_Pnl_Clave";
            this._Pnl_Clave.Size = new System.Drawing.Size(154, 86);
            this._Pnl_Clave.TabIndex = 155;
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
            // Frm_IncVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 428);
            this.Controls.Add(this._Pnl_Clave);
            this.Controls.Add(this._Pnl_Parametros);
            this.Controls.Add(this._Tb_Tab);
            this.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_IncVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parámetros - Incentivo Volumen de Ventas";
            this.Load += new System.EventHandler(this.Frm_IncVentas_Load);
            this.Shown += new System.EventHandler(this.Frm_IncVentas_Shown);
            this.Activated += new System.EventHandler(this.Frm_IncVentas_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_IncVentas_FormClosing);
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this._Cntx_Menu.ResumeLayout(false);
            this._Pnl_Consulta.ResumeLayout(false);
            this._Pnl_Consulta.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this._Pnl_Detalle.ResumeLayout(false);
            this._GrpB_Cond11.ResumeLayout(false);
            this._GrpB_Cond11.PerformLayout();
            this._GrpB_Cond13.ResumeLayout(false);
            this._GrpB_Cond13.PerformLayout();
            this._GrpB_Cond12.ResumeLayout(false);
            this._GrpB_Cond12.PerformLayout();
            this._Pnl_Superior.ResumeLayout(false);
            this._Pnl_Superior.PerformLayout();
            this._Grb_Fechas.ResumeLayout(false);
            this._Grb_Fechas.PerformLayout();
            this._Pnl_Parametros.ResumeLayout(false);
            this._Pnl_Parametros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this._Pnl_Clave.ResumeLayout(false);
            this._Pnl_Clave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.Panel _Pnl_Consulta;
        private System.Windows.Forms.Button _Bt_Consultar;
        private System.Windows.Forms.Label Cargo;
        private System.Windows.Forms.ComboBox _Cmb_Cargo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel _Pnl_Superior;
        private System.Windows.Forms.RadioButton _Rbt_Periodo;
        private System.Windows.Forms.RadioButton _Rbt_Fijo;
        private System.Windows.Forms.GroupBox _Grb_Fechas;
        private System.Windows.Forms.DateTimePicker _Dtp_Hasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _Lbl_5;
        private System.Windows.Forms.DateTimePicker _Dtp_Desde;
        private System.Windows.Forms.Button _Bt_Cuota_Condicion3;
        private System.Windows.Forms.GroupBox _GrpB_Cond13;
        private System.Windows.Forms.TextBox _Txt_cuota_ccomision3;
        private System.Windows.Forms.Label _Lbl_2_Cuota_Cond3;
        private System.Windows.Forms.Label _Lbl_1_Cuota_Cond3;
        private System.Windows.Forms.TextBox _Txt_cuota_ccondicion3;
        private System.Windows.Forms.Button _Bt_Cuota_Condicion2;
        private System.Windows.Forms.GroupBox _GrpB_Cond12;
        private System.Windows.Forms.TextBox _Txt_cuota_ccomision2;
        private System.Windows.Forms.Label _Lbl_2_Cuota_Cond2;
        private System.Windows.Forms.Label _Lbl_1_Cuota_Cond2;
        private System.Windows.Forms.TextBox _Txt_cuota_ccondicion2;
        private System.Windows.Forms.Button _Bt_Cuota_Condicion1;
        private System.Windows.Forms.GroupBox _GrpB_Cond11;
        private System.Windows.Forms.TextBox _Txt_cuota_ccomision1;
        private System.Windows.Forms.Label _Lbl_2_Cuota_Cond1;
        private System.Windows.Forms.Label _Lbl_1_Cuota_Cond1;
        private System.Windows.Forms.TextBox _Txt_cuota_ccondicion1;
        private System.Windows.Forms.Panel _Pnl_Parametros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _Cmb_Grupo_D;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox _Cmb_Cargo_D;
        private System.Windows.Forms.Button _Bt_Aceptar;
        private System.Windows.Forms.Button _Bt_Cancelar;
        private System.Windows.Forms.Button _Bt_Cerrar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label _Lbl_Periodo;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.Panel _Pnl_Detalle;
        private System.Windows.Forms.Label _Lbl_Grupo;
        private System.Windows.Forms.Panel _Pnl_Clave;
        private System.Windows.Forms.Button _Bt_AceptarClave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _Txt_Clave;
        private System.Windows.Forms.Button _Bt_CancelarClave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ContextMenuStrip _Cntx_Menu;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;

    }
}

