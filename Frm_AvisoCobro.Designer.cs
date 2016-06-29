namespace T3
{
    partial class Frm_AvisoCobro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AvisoCobro));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._Pnl_Find = new System.Windows.Forms.Panel();
            this._Pnl_FechaVencimiento = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this._Dte_FechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this._Lbl_FechaVencimiento = new System.Windows.Forms.Label();
            this._Bt_Aceptar = new System.Windows.Forms.Button();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Btn_Consultar = new System.Windows.Forms.Button();
            this._Cmb_Estatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._Cmb_CompaniaRelacionadaCons = new System.Windows.Forms.ComboBox();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this._Dg_Comprobante = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this._Bt_Visulizar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this._Rpt_ContenedorAviso = new Microsoft.Reporting.WinForms.ReportViewer();
            this._Pnl_Anulacion = new System.Windows.Forms.Panel();
            this._Cmb_MotivoAnulacion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this._Txt_Monto = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._Txt_Cod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Txt_Descripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._Txt_Concepto = new System.Windows.Forms.TextBox();
            this._Cmb_CompaniaRelacionada = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Tlt_Tips = new System.Windows.Forms.ToolTip(this.components);
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this._Pnl_Find.SuspendLayout();
            this._Pnl_FechaVencimiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Comprobante)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this._Pnl_Anulacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this.SuspendLayout();
            // 
            // _Tb_Tab
            // 
            this._Tb_Tab.Controls.Add(this.tabPage1);
            this._Tb_Tab.Controls.Add(this.tabPage2);
            this._Tb_Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Tb_Tab.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Tb_Tab.Location = new System.Drawing.Point(0, 0);
            this._Tb_Tab.Name = "_Tb_Tab";
            this._Tb_Tab.SelectedIndex = 0;
            this._Tb_Tab.Size = new System.Drawing.Size(965, 612);
            this._Tb_Tab.TabIndex = 1;
            this._Tb_Tab.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this._Tb_Tab_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._Pnl_Find);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(957, 587);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _Pnl_Find
            // 
            this._Pnl_Find.Controls.Add(this._Pnl_FechaVencimiento);
            this._Pnl_Find.Controls.Add(this._Dg_Grid);
            this._Pnl_Find.Controls.Add(this.panel1);
            this._Pnl_Find.Controls.Add(this._Lbl_DgInfo);
            this._Pnl_Find.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Pnl_Find.Location = new System.Drawing.Point(3, 3);
            this._Pnl_Find.Name = "_Pnl_Find";
            this._Pnl_Find.Size = new System.Drawing.Size(951, 581);
            this._Pnl_Find.TabIndex = 2;
            // 
            // _Pnl_FechaVencimiento
            // 
            this._Pnl_FechaVencimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_FechaVencimiento.Controls.Add(this.label12);
            this._Pnl_FechaVencimiento.Controls.Add(this._Dte_FechaVencimiento);
            this._Pnl_FechaVencimiento.Controls.Add(this._Lbl_FechaVencimiento);
            this._Pnl_FechaVencimiento.Controls.Add(this._Bt_Aceptar);
            this._Pnl_FechaVencimiento.Location = new System.Drawing.Point(617, 286);
            this._Pnl_FechaVencimiento.Name = "_Pnl_FechaVencimiento";
            this._Pnl_FechaVencimiento.Size = new System.Drawing.Size(215, 72);
            this._Pnl_FechaVencimiento.TabIndex = 92;
            this._Pnl_FechaVencimiento.Visible = false;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Navy;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(213, 18);
            this.label12.TabIndex = 0;
            this.label12.Text = "Eliga la fecha de vencimiento";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Dte_FechaVencimiento
            // 
            this._Dte_FechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dte_FechaVencimiento.Location = new System.Drawing.Point(7, 42);
            this._Dte_FechaVencimiento.Name = "_Dte_FechaVencimiento";
            this._Dte_FechaVencimiento.Size = new System.Drawing.Size(116, 18);
            this._Dte_FechaVencimiento.TabIndex = 75;
            // 
            // _Lbl_FechaVencimiento
            // 
            this._Lbl_FechaVencimiento.AutoSize = true;
            this._Lbl_FechaVencimiento.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_FechaVencimiento.Location = new System.Drawing.Point(5, 27);
            this._Lbl_FechaVencimiento.Name = "_Lbl_FechaVencimiento";
            this._Lbl_FechaVencimiento.Size = new System.Drawing.Size(120, 12);
            this._Lbl_FechaVencimiento.TabIndex = 74;
            this._Lbl_FechaVencimiento.Text = "Fecha de Vencimiento:";
            // 
            // _Bt_Aceptar
            // 
            this._Bt_Aceptar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Aceptar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Aceptar.Image")));
            this._Bt_Aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Aceptar.Location = new System.Drawing.Point(128, 31);
            this._Bt_Aceptar.Name = "_Bt_Aceptar";
            this._Bt_Aceptar.Size = new System.Drawing.Size(79, 30);
            this._Bt_Aceptar.TabIndex = 73;
            this._Bt_Aceptar.Text = "Aceptar";
            this._Bt_Aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Aceptar.Click += new System.EventHandler(this._Bt_Aceptar_Click);
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Dg_Grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._Dg_Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Dg_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(0, 77);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Size = new System.Drawing.Size(951, 493);
            this._Dg_Grid.TabIndex = 1;
            this._Dg_Grid.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseClick);
            this._Dg_Grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Btn_Consultar);
            this.panel1.Controls.Add(this._Cmb_Estatus);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this._Cmb_CompaniaRelacionadaCons);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(951, 77);
            this.panel1.TabIndex = 7;
            // 
            // _Btn_Consultar
            // 
            this._Btn_Consultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Btn_Consultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Btn_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("_Btn_Consultar.Image")));
            this._Btn_Consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Btn_Consultar.Location = new System.Drawing.Point(573, 22);
            this._Btn_Consultar.Name = "_Btn_Consultar";
            this._Btn_Consultar.Size = new System.Drawing.Size(109, 28);
            this._Btn_Consultar.TabIndex = 50;
            this._Btn_Consultar.Text = "Consultar";
            this._Btn_Consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Btn_Consultar.UseVisualStyleBackColor = true;
            this._Btn_Consultar.Click += new System.EventHandler(this._Btn_Consultar_Click);
            // 
            // _Cmb_Estatus
            // 
            this._Cmb_Estatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Estatus.FormattingEnabled = true;
            this._Cmb_Estatus.Location = new System.Drawing.Point(368, 30);
            this._Cmb_Estatus.Name = "_Cmb_Estatus";
            this._Cmb_Estatus.Size = new System.Drawing.Size(186, 20);
            this._Cmb_Estatus.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(366, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "Estatus:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "Compañia Relacionada:";
            // 
            // _Cmb_CompaniaRelacionadaCons
            // 
            this._Cmb_CompaniaRelacionadaCons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_CompaniaRelacionadaCons.FormattingEnabled = true;
            this._Cmb_CompaniaRelacionadaCons.Location = new System.Drawing.Point(20, 30);
            this._Cmb_CompaniaRelacionadaCons.Name = "_Cmb_CompaniaRelacionadaCons";
            this._Cmb_CompaniaRelacionadaCons.Size = new System.Drawing.Size(336, 20);
            this._Cmb_CompaniaRelacionadaCons.TabIndex = 0;
            this._Cmb_CompaniaRelacionadaCons.DropDown += new System.EventHandler(this._Cmb_CompaniaRelacionadaCons_DropDown);
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(0, 570);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(951, 11);
            this._Lbl_DgInfo.TabIndex = 6;
            this._Lbl_DgInfo.Text = "Use doble click";
            this._Lbl_DgInfo.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(957, 587);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this._Dg_Comprobante);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 271);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(951, 313);
            this.panel4.TabIndex = 26;
            // 
            // _Dg_Comprobante
            // 
            this._Dg_Comprobante.AllowUserToAddRows = false;
            this._Dg_Comprobante.AllowUserToDeleteRows = false;
            this._Dg_Comprobante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Comprobante.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewButtonColumn2,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this._Dg_Comprobante.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Comprobante.Location = new System.Drawing.Point(0, 47);
            this._Dg_Comprobante.Name = "_Dg_Comprobante";
            this._Dg_Comprobante.Size = new System.Drawing.Size(951, 266);
            this._Dg_Comprobante.TabIndex = 134;
            this._Dg_Comprobante.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this._Dg_Comprobante_CellBeginEdit);
            this._Dg_Comprobante.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Comprobante_CellClick);
            this._Dg_Comprobante.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Comprobante_CellEndEdit);
            this._Dg_Comprobante.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this._Dg_Comprobante_EditingControlShowing);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn1.HeaderText = "Cuenta";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewButtonColumn2
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Navy;
            this.dataGridViewButtonColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewButtonColumn2.Width = 20;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Descripción";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn3.HeaderText = "Debe";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn4.HeaderText = "Haber";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._Bt_Visulizar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(951, 47);
            this.panel3.TabIndex = 135;
            // 
            // _Bt_Visulizar
            // 
            this._Bt_Visulizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Visulizar.Enabled = false;
            this._Bt_Visulizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Visulizar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Visulizar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Visulizar.Image")));
            this._Bt_Visulizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Visulizar.Location = new System.Drawing.Point(5, 6);
            this._Bt_Visulizar.Name = "_Bt_Visulizar";
            this._Bt_Visulizar.Size = new System.Drawing.Size(267, 32);
            this._Bt_Visulizar.TabIndex = 129;
            this._Bt_Visulizar.Text = "Visualizar comprobante a generar..";
            this._Bt_Visulizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Visulizar.UseVisualStyleBackColor = true;
            this._Bt_Visulizar.Click += new System.EventHandler(this._Bt_Visulizar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._Rpt_ContenedorAviso);
            this.panel2.Controls.Add(this._Pnl_Anulacion);
            this.panel2.Controls.Add(this._Txt_Monto);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this._Txt_Cod);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this._Txt_Descripcion);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this._Txt_Concepto);
            this.panel2.Controls.Add(this._Cmb_CompaniaRelacionada);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(951, 268);
            this.panel2.TabIndex = 135;
            // 
            // _Rpt_ContenedorAviso
            // 
            this._Rpt_ContenedorAviso.Location = new System.Drawing.Point(528, 11);
            this._Rpt_ContenedorAviso.Name = "_Rpt_ContenedorAviso";
            this._Rpt_ContenedorAviso.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this._Rpt_ContenedorAviso.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this._Rpt_ContenedorAviso.ShowParameterPrompts = false;
            this._Rpt_ContenedorAviso.Size = new System.Drawing.Size(313, 130);
            this._Rpt_ContenedorAviso.TabIndex = 8;
            this._Rpt_ContenedorAviso.Visible = false;
            this._Rpt_ContenedorAviso.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this._Rpt_ContenedorAviso_RenderingComplete);
            // 
            // _Pnl_Anulacion
            // 
            this._Pnl_Anulacion.Controls.Add(this._Cmb_MotivoAnulacion);
            this._Pnl_Anulacion.Controls.Add(this.label3);
            this._Pnl_Anulacion.Location = new System.Drawing.Point(14, 202);
            this._Pnl_Anulacion.Name = "_Pnl_Anulacion";
            this._Pnl_Anulacion.Size = new System.Drawing.Size(625, 48);
            this._Pnl_Anulacion.TabIndex = 46;
            this._Pnl_Anulacion.Visible = false;
            // 
            // _Cmb_MotivoAnulacion
            // 
            this._Cmb_MotivoAnulacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_MotivoAnulacion.FormattingEnabled = true;
            this._Cmb_MotivoAnulacion.Location = new System.Drawing.Point(0, 22);
            this._Cmb_MotivoAnulacion.Name = "_Cmb_MotivoAnulacion";
            this._Cmb_MotivoAnulacion.Size = new System.Drawing.Size(336, 20);
            this._Cmb_MotivoAnulacion.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-2, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "Motivo de Anulación:";
            // 
            // _Txt_Monto
            // 
            this._Txt_Monto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Monto.Location = new System.Drawing.Point(14, 178);
            this._Txt_Monto.MaxLength = 16;
            this._Txt_Monto.Name = "_Txt_Monto";
            this._Txt_Monto.Size = new System.Drawing.Size(115, 18);
            this._Txt_Monto.TabIndex = 44;
            this._Txt_Monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Txt_Monto.TextChanged += new System.EventHandler(this._Txt_Monto_TextChanged);
            this._Txt_Monto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Monto_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(12, 163);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 12);
            this.label13.TabIndex = 45;
            this.label13.Text = "Monto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id Aviso de Cobro:";
            // 
            // _Txt_Cod
            // 
            this._Txt_Cod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Cod.Enabled = false;
            this._Txt_Cod.Location = new System.Drawing.Point(12, 25);
            this._Txt_Cod.Name = "_Txt_Cod";
            this._Txt_Cod.ReadOnly = true;
            this._Txt_Cod.Size = new System.Drawing.Size(97, 18);
            this._Txt_Cod.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Descripción:";
            // 
            // _Txt_Descripcion
            // 
            this._Txt_Descripcion.BackColor = System.Drawing.Color.White;
            this._Txt_Descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Descripcion.Enabled = false;
            this._Txt_Descripcion.Location = new System.Drawing.Point(12, 96);
            this._Txt_Descripcion.MaxLength = 255;
            this._Txt_Descripcion.Multiline = true;
            this._Txt_Descripcion.Name = "_Txt_Descripcion";
            this._Txt_Descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._Txt_Descripcion.Size = new System.Drawing.Size(477, 64);
            this._Txt_Descripcion.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "Concepto:";
            // 
            // _Txt_Concepto
            // 
            this._Txt_Concepto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Concepto.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Concepto.Location = new System.Drawing.Point(12, 60);
            this._Txt_Concepto.MaxLength = 140;
            this._Txt_Concepto.Name = "_Txt_Concepto";
            this._Txt_Concepto.Size = new System.Drawing.Size(477, 18);
            this._Txt_Concepto.TabIndex = 17;
            // 
            // _Cmb_CompaniaRelacionada
            // 
            this._Cmb_CompaniaRelacionada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_CompaniaRelacionada.FormattingEnabled = true;
            this._Cmb_CompaniaRelacionada.Location = new System.Drawing.Point(153, 23);
            this._Cmb_CompaniaRelacionada.Name = "_Cmb_CompaniaRelacionada";
            this._Cmb_CompaniaRelacionada.Size = new System.Drawing.Size(336, 20);
            this._Cmb_CompaniaRelacionada.TabIndex = 15;
            this._Cmb_CompaniaRelacionada.DropDown += new System.EventHandler(this._Cmb_CompaniaRelacionada_DropDown);
            this._Cmb_CompaniaRelacionada.SelectedIndexChanged += new System.EventHandler(this._Cmb_CompaniaRelacionada_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(151, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "Compañia Relacionada:";
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // Frm_AvisoCobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 612);
            this.Controls.Add(this._Tb_Tab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_AvisoCobro";
            this.ShowInTaskbar = false;
            this.Text = "Aviso de cobro";
            this.Activated += new System.EventHandler(this.Frm_AvisoCobro_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_AvisoCobro_FormClosing);
            this.Load += new System.EventHandler(this.Frm_AvisoCobro_Load);
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this._Pnl_Find.ResumeLayout(false);
            this._Pnl_FechaVencimiento.ResumeLayout(false);
            this._Pnl_FechaVencimiento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Comprobante)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this._Pnl_Anulacion.ResumeLayout(false);
            this._Pnl_Anulacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel _Pnl_Find;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _Lbl_DgInfo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _Txt_Cod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _Cmb_Estatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox _Cmb_CompaniaRelacionadaCons;
        private System.Windows.Forms.Button _Btn_Consultar;
        private System.Windows.Forms.TextBox _Txt_Descripcion;
        private System.Windows.Forms.TextBox _Txt_Concepto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox _Cmb_CompaniaRelacionada;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button _Bt_Visulizar;
        private System.Windows.Forms.DataGridView _Dg_Comprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox _Txt_Monto;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel _Pnl_Anulacion;
        private System.Windows.Forms.ComboBox _Cmb_MotivoAnulacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.ToolTip _Tlt_Tips;
        private Microsoft.Reporting.WinForms.ReportViewer _Rpt_ContenedorAviso;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel _Pnl_FechaVencimiento;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker _Dte_FechaVencimiento;
        private System.Windows.Forms.Label _Lbl_FechaVencimiento;
        private System.Windows.Forms.Button _Bt_Aceptar;
    }
}