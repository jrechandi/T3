namespace T3
{
    partial class Frm_ProcesosContables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ProcesosContables));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this._Dg_GridCol_CodProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_GridCol_Descrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_GridCol_TpoComprob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Pnl_FindOpc = new System.Windows.Forms.Panel();
            this._Bt_Find = new System.Windows.Forms.Button();
            this._Txt_FindCodigo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._Lbl_Titulo = new System.Windows.Forms.Label();
            this._Cmb_FindTpoComprob = new System.Windows.Forms.ComboBox();
            this._Chk_FindSistema = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._Pnl_DgCuentas = new System.Windows.Forms.Panel();
            this._Dg_GridDeta = new System.Windows.Forms.DataGridView();
            this._Dg_GridDetaColCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_GridDetaColCtaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_GridDetaColF = new System.Windows.Forms.DataGridViewButtonColumn();
            this._Dg_GridDetaColCtaAux = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this._Dg_GridDetaColCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_GridDetaNatu = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this._Lbl_DgCuentasInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Txt_cidproceso = new System.Windows.Forms.TextBox();
            this._Chk_Sistema = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._Cb_ctypcompro = new System.Windows.Forms.ComboBox();
            this._Txt_cdescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._Txt_cconceptocomp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._CMen_A = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._CMen_A_Del = new System.Windows.Forms.ToolStripMenuItem();
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this._Pnl_FindOpc.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this._Pnl_DgCuentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_GridDeta)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this._CMen_A.SuspendLayout();
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
            this._Tb_Tab.Size = new System.Drawing.Size(720, 460);
            this._Tb_Tab.TabIndex = 0;
            this._Tb_Tab.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this._Tb_Tab_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._Dg_Grid);
            this.tabPage1.Controls.Add(this._Pnl_FindOpc);
            this.tabPage1.Controls.Add(this._Lbl_DgInfo);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(712, 435);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._Dg_GridCol_CodProceso,
            this._Dg_GridCol_Descrip,
            this._Dg_GridCol_TpoComprob});
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(3, 75);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.Size = new System.Drawing.Size(706, 346);
            this._Dg_Grid.TabIndex = 0;
            this._Dg_Grid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_CellMouseEnter);
            this._Dg_Grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseDoubleClick);
            // 
            // _Dg_GridCol_CodProceso
            // 
            this._Dg_GridCol_CodProceso.HeaderText = "Código";
            this._Dg_GridCol_CodProceso.Name = "_Dg_GridCol_CodProceso";
            this._Dg_GridCol_CodProceso.ReadOnly = true;
            // 
            // _Dg_GridCol_Descrip
            // 
            this._Dg_GridCol_Descrip.HeaderText = "Descripción";
            this._Dg_GridCol_Descrip.Name = "_Dg_GridCol_Descrip";
            this._Dg_GridCol_Descrip.ReadOnly = true;
            // 
            // _Dg_GridCol_TpoComprob
            // 
            this._Dg_GridCol_TpoComprob.HeaderText = "T. Comprobante";
            this._Dg_GridCol_TpoComprob.Name = "_Dg_GridCol_TpoComprob";
            this._Dg_GridCol_TpoComprob.ReadOnly = true;
            // 
            // _Pnl_FindOpc
            // 
            this._Pnl_FindOpc.Controls.Add(this._Bt_Find);
            this._Pnl_FindOpc.Controls.Add(this._Txt_FindCodigo);
            this._Pnl_FindOpc.Controls.Add(this.label6);
            this._Pnl_FindOpc.Controls.Add(this._Lbl_Titulo);
            this._Pnl_FindOpc.Controls.Add(this._Cmb_FindTpoComprob);
            this._Pnl_FindOpc.Controls.Add(this._Chk_FindSistema);
            this._Pnl_FindOpc.Controls.Add(this.label5);
            this._Pnl_FindOpc.Dock = System.Windows.Forms.DockStyle.Top;
            this._Pnl_FindOpc.Location = new System.Drawing.Point(3, 3);
            this._Pnl_FindOpc.Name = "_Pnl_FindOpc";
            this._Pnl_FindOpc.Size = new System.Drawing.Size(706, 72);
            this._Pnl_FindOpc.TabIndex = 7;
            // 
            // _Bt_Find
            // 
            this._Bt_Find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Find.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Find.Image")));
            this._Bt_Find.Location = new System.Drawing.Point(568, 20);
            this._Bt_Find.Name = "_Bt_Find";
            this._Bt_Find.Size = new System.Drawing.Size(60, 47);
            this._Bt_Find.TabIndex = 6;
            this._Bt_Find.UseVisualStyleBackColor = true;
            this._Bt_Find.Click += new System.EventHandler(this._Bt_Find_Click);
            // 
            // _Txt_FindCodigo
            // 
            this._Txt_FindCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_FindCodigo.Location = new System.Drawing.Point(36, 42);
            this._Txt_FindCodigo.MaxLength = 50;
            this._Txt_FindCodigo.Name = "_Txt_FindCodigo";
            this._Txt_FindCodigo.Size = new System.Drawing.Size(170, 18);
            this._Txt_FindCodigo.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Código";
            // 
            // _Lbl_Titulo
            // 
            this._Lbl_Titulo.BackColor = System.Drawing.Color.Navy;
            this._Lbl_Titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this._Lbl_Titulo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_Titulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._Lbl_Titulo.Location = new System.Drawing.Point(0, 0);
            this._Lbl_Titulo.Name = "_Lbl_Titulo";
            this._Lbl_Titulo.Size = new System.Drawing.Size(706, 18);
            this._Lbl_Titulo.TabIndex = 0;
            this._Lbl_Titulo.Text = "Opciones de búsqueda";
            this._Lbl_Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Cmb_FindTpoComprob
            // 
            this._Cmb_FindTpoComprob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_FindTpoComprob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_FindTpoComprob.FormattingEnabled = true;
            this._Cmb_FindTpoComprob.Location = new System.Drawing.Point(222, 41);
            this._Cmb_FindTpoComprob.Name = "_Cmb_FindTpoComprob";
            this._Cmb_FindTpoComprob.Size = new System.Drawing.Size(212, 20);
            this._Cmb_FindTpoComprob.TabIndex = 4;
            // 
            // _Chk_FindSistema
            // 
            this._Chk_FindSistema.AutoSize = true;
            this._Chk_FindSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Chk_FindSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Chk_FindSistema.Location = new System.Drawing.Point(460, 42);
            this._Chk_FindSistema.Name = "_Chk_FindSistema";
            this._Chk_FindSistema.Size = new System.Drawing.Size(88, 17);
            this._Chk_FindSistema.TabIndex = 5;
            this._Chk_FindSistema.Text = "Del sistema";
            this._Chk_FindSistema.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(219, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tipo de Comprobante";
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(3, 421);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(706, 11);
            this._Lbl_DgInfo.TabIndex = 1;
            this._Lbl_DgInfo.Text = "Use doble click";
            this._Lbl_DgInfo.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._Pnl_DgCuentas);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(712, 435);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Carga";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _Pnl_DgCuentas
            // 
            this._Pnl_DgCuentas.Controls.Add(this._Dg_GridDeta);
            this._Pnl_DgCuentas.Controls.Add(this._Lbl_DgCuentasInfo);
            this._Pnl_DgCuentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Pnl_DgCuentas.Location = new System.Drawing.Point(3, 134);
            this._Pnl_DgCuentas.Name = "_Pnl_DgCuentas";
            this._Pnl_DgCuentas.Size = new System.Drawing.Size(706, 298);
            this._Pnl_DgCuentas.TabIndex = 9;
            // 
            // _Dg_GridDeta
            // 
            this._Dg_GridDeta.AllowUserToDeleteRows = false;
            this._Dg_GridDeta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_GridDeta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._Dg_GridDetaColCor,
            this._Dg_GridDetaColCtaId,
            this._Dg_GridDetaColF,
            this._Dg_GridDetaColCtaAux,
            this._Dg_GridDetaColCuenta,
            this._Dg_GridDetaNatu});
            this._Dg_GridDeta.ContextMenuStrip = this._CMen_A;
            this._Dg_GridDeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_GridDeta.Location = new System.Drawing.Point(0, 0);
            this._Dg_GridDeta.Name = "_Dg_GridDeta";
            this._Dg_GridDeta.Size = new System.Drawing.Size(706, 287);
            this._Dg_GridDeta.TabIndex = 0;
            this._Dg_GridDeta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_GridDeta_CellClick);
            this._Dg_GridDeta.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_GridDeta_CellMouseEnter);
            this._Dg_GridDeta.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_GridDeta_CellEndEdit);
            this._Dg_GridDeta.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this._Dg_GridDeta_DataError);
            // 
            // _Dg_GridDetaColCor
            // 
            this._Dg_GridDetaColCor.HeaderText = "Correlativo";
            this._Dg_GridDetaColCor.Name = "_Dg_GridDetaColCor";
            this._Dg_GridDetaColCor.Visible = false;
            // 
            // _Dg_GridDetaColCtaId
            // 
            this._Dg_GridDetaColCtaId.HeaderText = "Cod. Cuenta";
            this._Dg_GridDetaColCtaId.Name = "_Dg_GridDetaColCtaId";
            this._Dg_GridDetaColCtaId.ReadOnly = true;
            // 
            // _Dg_GridDetaColF
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Navy;
            this._Dg_GridDetaColF.DefaultCellStyle = dataGridViewCellStyle4;
            this._Dg_GridDetaColF.HeaderText = "";
            this._Dg_GridDetaColF.Name = "_Dg_GridDetaColF";
            this._Dg_GridDetaColF.Width = 20;
            // 
            // _Dg_GridDetaColCtaAux
            // 
            this._Dg_GridDetaColCtaAux.HeaderText = "Variable";
            this._Dg_GridDetaColCtaAux.Name = "_Dg_GridDetaColCtaAux";
            this._Dg_GridDetaColCtaAux.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._Dg_GridDetaColCtaAux.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _Dg_GridDetaColCuenta
            // 
            this._Dg_GridDetaColCuenta.HeaderText = "Cuenta";
            this._Dg_GridDetaColCuenta.Name = "_Dg_GridDetaColCuenta";
            this._Dg_GridDetaColCuenta.ReadOnly = true;
            // 
            // _Dg_GridDetaNatu
            // 
            this._Dg_GridDetaNatu.HeaderText = "Naturaleza";
            this._Dg_GridDetaNatu.Items.AddRange(new object[] {
            "...",
            "DEBE",
            "HABER"});
            this._Dg_GridDetaNatu.Name = "_Dg_GridDetaNatu";
            this._Dg_GridDetaNatu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // _Lbl_DgCuentasInfo
            // 
            this._Lbl_DgCuentasInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgCuentasInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgCuentasInfo.Location = new System.Drawing.Point(0, 287);
            this._Lbl_DgCuentasInfo.Name = "_Lbl_DgCuentasInfo";
            this._Lbl_DgCuentasInfo.Size = new System.Drawing.Size(706, 11);
            this._Lbl_DgCuentasInfo.TabIndex = 9;
            this._Lbl_DgCuentasInfo.Text = "Use botón derecho";
            this._Lbl_DgCuentasInfo.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Txt_cidproceso);
            this.panel1.Controls.Add(this._Chk_Sistema);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._Cb_ctypcompro);
            this.panel1.Controls.Add(this._Txt_cdescripcion);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this._Txt_cconceptocomp);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(706, 131);
            this.panel1.TabIndex = 10;
            // 
            // _Txt_cidproceso
            // 
            this._Txt_cidproceso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_cidproceso.Location = new System.Drawing.Point(111, 16);
            this._Txt_cidproceso.MaxLength = 20;
            this._Txt_cidproceso.Name = "_Txt_cidproceso";
            this._Txt_cidproceso.Size = new System.Drawing.Size(278, 18);
            this._Txt_cidproceso.TabIndex = 1;
            this._Txt_cidproceso.TextChanged += new System.EventHandler(this._Txt_cidproceso_TextChanged);
            // 
            // _Chk_Sistema
            // 
            this._Chk_Sistema.AutoSize = true;
            this._Chk_Sistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Chk_Sistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Chk_Sistema.Location = new System.Drawing.Point(495, 89);
            this._Chk_Sistema.Name = "_Chk_Sistema";
            this._Chk_Sistema.Size = new System.Drawing.Size(88, 17);
            this._Chk_Sistema.TabIndex = 8;
            this._Chk_Sistema.Text = "Del sistema";
            this._Chk_Sistema.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proceso #:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripción:";
            // 
            // _Cb_ctypcompro
            // 
            this._Cb_ctypcompro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_ctypcompro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_ctypcompro.FormattingEnabled = true;
            this._Cb_ctypcompro.Location = new System.Drawing.Point(111, 88);
            this._Cb_ctypcompro.Name = "_Cb_ctypcompro";
            this._Cb_ctypcompro.Size = new System.Drawing.Size(173, 20);
            this._Cb_ctypcompro.TabIndex = 7;
            this._Cb_ctypcompro.SelectedIndexChanged += new System.EventHandler(this._Cb_ctypcompro_SelectedIndexChanged);
            // 
            // _Txt_cdescripcion
            // 
            this._Txt_cdescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_cdescripcion.Location = new System.Drawing.Point(111, 40);
            this._Txt_cdescripcion.MaxLength = 100;
            this._Txt_cdescripcion.Name = "_Txt_cdescripcion";
            this._Txt_cdescripcion.Size = new System.Drawing.Size(472, 18);
            this._Txt_cdescripcion.TabIndex = 3;
            this._Txt_cdescripcion.EnabledChanged += new System.EventHandler(this._Txt_cdescripcion_EnabledChanged);
            this._Txt_cdescripcion.TextChanged += new System.EventHandler(this._Txt_cdescripcion_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "T. Comprobante:";
            // 
            // _Txt_cconceptocomp
            // 
            this._Txt_cconceptocomp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_cconceptocomp.Location = new System.Drawing.Point(111, 64);
            this._Txt_cconceptocomp.MaxLength = 50;
            this._Txt_cconceptocomp.Name = "_Txt_cconceptocomp";
            this._Txt_cconceptocomp.Size = new System.Drawing.Size(472, 18);
            this._Txt_cconceptocomp.TabIndex = 5;
            this._Txt_cconceptocomp.TextChanged += new System.EventHandler(this._Txt_cconceptocomp_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Concepto:";
            // 
            // _Er_Error
            // 
            this._Er_Error.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._Er_Error.ContainerControl = this;
            // 
            // _CMen_A
            // 
            this._CMen_A.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._CMen_A_Del});
            this._CMen_A.Name = "contextMenuStrip1";
            this._CMen_A.Size = new System.Drawing.Size(122, 26);
            this._CMen_A.Opening += new System.ComponentModel.CancelEventHandler(this._CMen_A_Opening);
            // 
            // _CMen_A_Del
            // 
            this._CMen_A_Del.Name = "_CMen_A_Del";
            this._CMen_A_Del.Size = new System.Drawing.Size(121, 22);
            this._CMen_A_Del.Text = "Eliminar";
            this._CMen_A_Del.Click += new System.EventHandler(this._CMen_A_Del_Click);
            // 
            // Frm_ProcesosContables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 460);
            this.Controls.Add(this._Tb_Tab);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ProcesosContables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procesos contables";
            this.Activated += new System.EventHandler(this.Frm_ProcesosContables_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ProcesosContables_FormClosing);
            this.Load += new System.EventHandler(this.Frm_ProcesosContables_Load);
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this._Pnl_FindOpc.ResumeLayout(false);
            this._Pnl_FindOpc.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this._Pnl_DgCuentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_GridDeta)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this._CMen_A.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.TextBox _Txt_cdescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _Txt_cidproceso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _Cb_ctypcompro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _Txt_cconceptocomp;
        private System.Windows.Forms.DataGridView _Dg_GridDeta;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.ContextMenuStrip _CMen_A;
        private System.Windows.Forms.ToolStripMenuItem _CMen_A_Del;
        private System.Windows.Forms.Label _Lbl_DgInfo;
        private System.Windows.Forms.Panel _Pnl_DgCuentas;
        private System.Windows.Forms.Label _Lbl_DgCuentasInfo;
        private System.Windows.Forms.Panel _Pnl_FindOpc;
        private System.Windows.Forms.ComboBox _Cmb_FindTpoComprob;
        private System.Windows.Forms.CheckBox _Chk_FindSistema;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label _Lbl_Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_GridCol_CodProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_GridCol_Descrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_GridCol_TpoComprob;
        private System.Windows.Forms.TextBox _Txt_FindCodigo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button _Bt_Find;
        private System.Windows.Forms.CheckBox _Chk_Sistema;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_GridDetaColCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_GridDetaColCtaId;
        private System.Windows.Forms.DataGridViewButtonColumn _Dg_GridDetaColF;
        private System.Windows.Forms.DataGridViewComboBoxColumn _Dg_GridDetaColCtaAux;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_GridDetaColCuenta;
        private System.Windows.Forms.DataGridViewComboBoxColumn _Dg_GridDetaNatu;
    }
}