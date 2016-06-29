namespace T3
{
    partial class Frm_RC_Resumen
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
            this._Layout_Principal = new System.Windows.Forms.TableLayoutPanel();
            this._Layout_SobranteYBotones = new System.Windows.Forms.TableLayoutPanel();
            this._Pnl_SobranteyFaltante = new System.Windows.Forms.Panel();
            this._GrpBox_SobranteFaltante = new System.Windows.Forms.GroupBox();
            this._Dg_Grid_SobranteFaltante = new System.Windows.Forms.DataGridView();
            this._Col_Sobrante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Col_Faltante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Pnl_AprobarRechazar = new System.Windows.Forms.Panel();
            this._Btn_Imprimir = new System.Windows.Forms.Button();
            this._Btn_Rechazar = new System.Windows.Forms.Button();
            this._Btn_Aprobar = new System.Windows.Forms.Button();
            this._Pnl_GuiasGeneradas = new System.Windows.Forms.Panel();
            this._GrpBox_GuiasGeneradas = new System.Windows.Forms.GroupBox();
            this._Dg_Grid_GuiasGeneradas = new System.Windows.Forms.DataGridView();
            this.IdRelacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Compañia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Pnl_Cheques = new System.Windows.Forms.Panel();
            this._GrpBox_Cheques = new System.Windows.Forms.GroupBox();
            this._Dg_Grid_Cheques = new System.Windows.Forms.DataGridView();
            this._Pnl_Clientes = new System.Windows.Forms.Panel();
            this._GrpBox_Clientes = new System.Windows.Forms.GroupBox();
            this._Lbl_DgInfo_Guia = new System.Windows.Forms.Label();
            this._Dg_Grid_Clientes = new System.Windows.Forms.DataGridView();
            this._LayoutChequeYDeposito = new System.Windows.Forms.TableLayoutPanel();
            this._Pnl_Depositos = new System.Windows.Forms.Panel();
            this._GrpBox_Depositos = new System.Windows.Forms.GroupBox();
            this._Dg_Grid_Depositos = new System.Windows.Forms.DataGridView();
            this._Pnl_Retenciones = new System.Windows.Forms.Panel();
            this._GrpBox_Retenciones = new System.Windows.Forms.GroupBox();
            this._Dg_Grid_Retenciones = new System.Windows.Forms.DataGridView();
            this._Pnl_Clave = new System.Windows.Forms.Panel();
            this._Bt_Aceptar = new System.Windows.Forms.Button();
            this._Lbl_Titulo = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this._Txt_Clave = new System.Windows.Forms.TextBox();
            this._Bt_Cancelar = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this._Layout_Principal.SuspendLayout();
            this._Layout_SobranteYBotones.SuspendLayout();
            this._Pnl_SobranteyFaltante.SuspendLayout();
            this._GrpBox_SobranteFaltante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_SobranteFaltante)).BeginInit();
            this._Pnl_AprobarRechazar.SuspendLayout();
            this._Pnl_GuiasGeneradas.SuspendLayout();
            this._GrpBox_GuiasGeneradas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_GuiasGeneradas)).BeginInit();
            this._Pnl_Cheques.SuspendLayout();
            this._GrpBox_Cheques.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_Cheques)).BeginInit();
            this._Pnl_Clientes.SuspendLayout();
            this._GrpBox_Clientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_Clientes)).BeginInit();
            this._LayoutChequeYDeposito.SuspendLayout();
            this._Pnl_Depositos.SuspendLayout();
            this._GrpBox_Depositos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_Depositos)).BeginInit();
            this._Pnl_Retenciones.SuspendLayout();
            this._GrpBox_Retenciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_Retenciones)).BeginInit();
            this._Pnl_Clave.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Layout_Principal
            // 
            this._Layout_Principal.ColumnCount = 1;
            this._Layout_Principal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._Layout_Principal.Controls.Add(this._Layout_SobranteYBotones, 0, 4);
            this._Layout_Principal.Controls.Add(this._Pnl_Cheques, 0, 1);
            this._Layout_Principal.Controls.Add(this._Pnl_Clientes, 0, 0);
            this._Layout_Principal.Controls.Add(this._LayoutChequeYDeposito, 0, 2);
            this._Layout_Principal.Controls.Add(this._Pnl_Retenciones, 0, 3);
            this._Layout_Principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Layout_Principal.Location = new System.Drawing.Point(0, 0);
            this._Layout_Principal.Name = "_Layout_Principal";
            this._Layout_Principal.RowCount = 5;
            this._Layout_Principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._Layout_Principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._Layout_Principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._Layout_Principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._Layout_Principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this._Layout_Principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._Layout_Principal.Size = new System.Drawing.Size(1124, 589);
            this._Layout_Principal.TabIndex = 0;
            // 
            // _Layout_SobranteYBotones
            // 
            this._Layout_SobranteYBotones.ColumnCount = 3;
            this._Layout_SobranteYBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._Layout_SobranteYBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._Layout_SobranteYBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 430F));
            this._Layout_SobranteYBotones.Controls.Add(this._Pnl_SobranteyFaltante, 0, 0);
            this._Layout_SobranteYBotones.Controls.Add(this._Pnl_AprobarRechazar, 2, 0);
            this._Layout_SobranteYBotones.Controls.Add(this._Pnl_GuiasGeneradas, 1, 0);
            this._Layout_SobranteYBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Layout_SobranteYBotones.Location = new System.Drawing.Point(3, 491);
            this._Layout_SobranteYBotones.Name = "_Layout_SobranteYBotones";
            this._Layout_SobranteYBotones.RowCount = 1;
            this._Layout_SobranteYBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._Layout_SobranteYBotones.Size = new System.Drawing.Size(1118, 95);
            this._Layout_SobranteYBotones.TabIndex = 2;
            // 
            // _Pnl_SobranteyFaltante
            // 
            this._Pnl_SobranteyFaltante.Controls.Add(this._GrpBox_SobranteFaltante);
            this._Pnl_SobranteyFaltante.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Pnl_SobranteyFaltante.Location = new System.Drawing.Point(3, 3);
            this._Pnl_SobranteyFaltante.Name = "_Pnl_SobranteyFaltante";
            this._Pnl_SobranteyFaltante.Size = new System.Drawing.Size(338, 89);
            this._Pnl_SobranteyFaltante.TabIndex = 2;
            // 
            // _GrpBox_SobranteFaltante
            // 
            this._GrpBox_SobranteFaltante.Controls.Add(this._Dg_Grid_SobranteFaltante);
            this._GrpBox_SobranteFaltante.Dock = System.Windows.Forms.DockStyle.Fill;
            this._GrpBox_SobranteFaltante.Location = new System.Drawing.Point(0, 0);
            this._GrpBox_SobranteFaltante.Name = "_GrpBox_SobranteFaltante";
            this._GrpBox_SobranteFaltante.Padding = new System.Windows.Forms.Padding(8);
            this._GrpBox_SobranteFaltante.Size = new System.Drawing.Size(338, 89);
            this._GrpBox_SobranteFaltante.TabIndex = 2;
            this._GrpBox_SobranteFaltante.TabStop = false;
            this._GrpBox_SobranteFaltante.Text = "Sobrante / Faltante";
            // 
            // _Dg_Grid_SobranteFaltante
            // 
            this._Dg_Grid_SobranteFaltante.AllowUserToAddRows = false;
            this._Dg_Grid_SobranteFaltante.AllowUserToDeleteRows = false;
            this._Dg_Grid_SobranteFaltante.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._Dg_Grid_SobranteFaltante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid_SobranteFaltante.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._Col_Sobrante,
            this._Col_Faltante});
            this._Dg_Grid_SobranteFaltante.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid_SobranteFaltante.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this._Dg_Grid_SobranteFaltante.Location = new System.Drawing.Point(8, 19);
            this._Dg_Grid_SobranteFaltante.Name = "_Dg_Grid_SobranteFaltante";
            this._Dg_Grid_SobranteFaltante.RowHeadersVisible = false;
            this._Dg_Grid_SobranteFaltante.Size = new System.Drawing.Size(322, 62);
            this._Dg_Grid_SobranteFaltante.TabIndex = 1;
            // 
            // _Col_Sobrante
            // 
            this._Col_Sobrante.HeaderText = "Sobrante";
            this._Col_Sobrante.Name = "_Col_Sobrante";
            this._Col_Sobrante.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // _Col_Faltante
            // 
            this._Col_Faltante.HeaderText = "Faltante";
            this._Col_Faltante.Name = "_Col_Faltante";
            this._Col_Faltante.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // _Pnl_AprobarRechazar
            // 
            this._Pnl_AprobarRechazar.Controls.Add(this._Btn_Imprimir);
            this._Pnl_AprobarRechazar.Controls.Add(this._Btn_Rechazar);
            this._Pnl_AprobarRechazar.Controls.Add(this._Btn_Aprobar);
            this._Pnl_AprobarRechazar.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Pnl_AprobarRechazar.Location = new System.Drawing.Point(691, 3);
            this._Pnl_AprobarRechazar.Name = "_Pnl_AprobarRechazar";
            this._Pnl_AprobarRechazar.Size = new System.Drawing.Size(424, 89);
            this._Pnl_AprobarRechazar.TabIndex = 3;
            // 
            // _Btn_Imprimir
            // 
            this._Btn_Imprimir.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Btn_Imprimir.Image = global::T3.Properties.Resources.printer;
            this._Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Btn_Imprimir.Location = new System.Drawing.Point(23, 29);
            this._Btn_Imprimir.Name = "_Btn_Imprimir";
            this._Btn_Imprimir.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this._Btn_Imprimir.Size = new System.Drawing.Size(124, 34);
            this._Btn_Imprimir.TabIndex = 1;
            this._Btn_Imprimir.Text = "Imprimir";
            this._Btn_Imprimir.UseVisualStyleBackColor = true;
            this._Btn_Imprimir.Click += new System.EventHandler(this._Btn_Imprimir_Click);
            // 
            // _Btn_Rechazar
            // 
            this._Btn_Rechazar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Btn_Rechazar.Image = global::T3.Properties.Resources.cross;
            this._Btn_Rechazar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Btn_Rechazar.Location = new System.Drawing.Point(283, 29);
            this._Btn_Rechazar.Name = "_Btn_Rechazar";
            this._Btn_Rechazar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this._Btn_Rechazar.Size = new System.Drawing.Size(124, 34);
            this._Btn_Rechazar.TabIndex = 0;
            this._Btn_Rechazar.Text = "Rechazar";
            this._Btn_Rechazar.UseVisualStyleBackColor = true;
            this._Btn_Rechazar.Click += new System.EventHandler(this._Btn_Rechazar_Click);
            // 
            // _Btn_Aprobar
            // 
            this._Btn_Aprobar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Btn_Aprobar.Image = global::T3.Properties.Resources.check;
            this._Btn_Aprobar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Btn_Aprobar.Location = new System.Drawing.Point(153, 29);
            this._Btn_Aprobar.Name = "_Btn_Aprobar";
            this._Btn_Aprobar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this._Btn_Aprobar.Size = new System.Drawing.Size(124, 34);
            this._Btn_Aprobar.TabIndex = 0;
            this._Btn_Aprobar.Text = "Aprobar";
            this._Btn_Aprobar.UseVisualStyleBackColor = true;
            this._Btn_Aprobar.Click += new System.EventHandler(this._Btn_Aprobar_Click);
            // 
            // _Pnl_GuiasGeneradas
            // 
            this._Pnl_GuiasGeneradas.Controls.Add(this._GrpBox_GuiasGeneradas);
            this._Pnl_GuiasGeneradas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Pnl_GuiasGeneradas.Location = new System.Drawing.Point(347, 3);
            this._Pnl_GuiasGeneradas.Name = "_Pnl_GuiasGeneradas";
            this._Pnl_GuiasGeneradas.Size = new System.Drawing.Size(338, 89);
            this._Pnl_GuiasGeneradas.TabIndex = 4;
            // 
            // _GrpBox_GuiasGeneradas
            // 
            this._GrpBox_GuiasGeneradas.Controls.Add(this._Dg_Grid_GuiasGeneradas);
            this._GrpBox_GuiasGeneradas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._GrpBox_GuiasGeneradas.Location = new System.Drawing.Point(0, 0);
            this._GrpBox_GuiasGeneradas.Name = "_GrpBox_GuiasGeneradas";
            this._GrpBox_GuiasGeneradas.Padding = new System.Windows.Forms.Padding(8);
            this._GrpBox_GuiasGeneradas.Size = new System.Drawing.Size(338, 89);
            this._GrpBox_GuiasGeneradas.TabIndex = 3;
            this._GrpBox_GuiasGeneradas.TabStop = false;
            this._GrpBox_GuiasGeneradas.Text = "Guias Generadas";
            // 
            // _Dg_Grid_GuiasGeneradas
            // 
            this._Dg_Grid_GuiasGeneradas.AllowUserToAddRows = false;
            this._Dg_Grid_GuiasGeneradas.AllowUserToDeleteRows = false;
            this._Dg_Grid_GuiasGeneradas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._Dg_Grid_GuiasGeneradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid_GuiasGeneradas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdRelacion,
            this.Compañia});
            this._Dg_Grid_GuiasGeneradas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid_GuiasGeneradas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this._Dg_Grid_GuiasGeneradas.Location = new System.Drawing.Point(8, 19);
            this._Dg_Grid_GuiasGeneradas.Name = "_Dg_Grid_GuiasGeneradas";
            this._Dg_Grid_GuiasGeneradas.RowHeadersVisible = false;
            this._Dg_Grid_GuiasGeneradas.Size = new System.Drawing.Size(322, 62);
            this._Dg_Grid_GuiasGeneradas.TabIndex = 1;
            // 
            // IdRelacion
            // 
            this.IdRelacion.DataPropertyName = "Id Relación";
            this.IdRelacion.FillWeight = 101.5228F;
            this.IdRelacion.HeaderText = "Id Relación";
            this.IdRelacion.Name = "IdRelacion";
            // 
            // Compañia
            // 
            this.Compañia.DataPropertyName = "Compañia";
            this.Compañia.FillWeight = 98.47716F;
            this.Compañia.HeaderText = "Compañia";
            this.Compañia.Name = "Compañia";
            // 
            // _Pnl_Cheques
            // 
            this._Pnl_Cheques.Controls.Add(this._GrpBox_Cheques);
            this._Pnl_Cheques.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Pnl_Cheques.Location = new System.Drawing.Point(3, 125);
            this._Pnl_Cheques.Name = "_Pnl_Cheques";
            this._Pnl_Cheques.Size = new System.Drawing.Size(1118, 116);
            this._Pnl_Cheques.TabIndex = 0;
            // 
            // _GrpBox_Cheques
            // 
            this._GrpBox_Cheques.Controls.Add(this._Dg_Grid_Cheques);
            this._GrpBox_Cheques.Dock = System.Windows.Forms.DockStyle.Fill;
            this._GrpBox_Cheques.Location = new System.Drawing.Point(0, 0);
            this._GrpBox_Cheques.Name = "_GrpBox_Cheques";
            this._GrpBox_Cheques.Padding = new System.Windows.Forms.Padding(8);
            this._GrpBox_Cheques.Size = new System.Drawing.Size(1118, 116);
            this._GrpBox_Cheques.TabIndex = 2;
            this._GrpBox_Cheques.TabStop = false;
            this._GrpBox_Cheques.Text = "Cheques";
            // 
            // _Dg_Grid_Cheques
            // 
            this._Dg_Grid_Cheques.AllowUserToAddRows = false;
            this._Dg_Grid_Cheques.AllowUserToDeleteRows = false;
            this._Dg_Grid_Cheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid_Cheques.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid_Cheques.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this._Dg_Grid_Cheques.Location = new System.Drawing.Point(8, 19);
            this._Dg_Grid_Cheques.Name = "_Dg_Grid_Cheques";
            this._Dg_Grid_Cheques.Size = new System.Drawing.Size(1102, 89);
            this._Dg_Grid_Cheques.TabIndex = 1;
            // 
            // _Pnl_Clientes
            // 
            this._Pnl_Clientes.Controls.Add(this._GrpBox_Clientes);
            this._Pnl_Clientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Pnl_Clientes.Location = new System.Drawing.Point(3, 3);
            this._Pnl_Clientes.Name = "_Pnl_Clientes";
            this._Pnl_Clientes.Size = new System.Drawing.Size(1118, 116);
            this._Pnl_Clientes.TabIndex = 0;
            // 
            // _GrpBox_Clientes
            // 
            this._GrpBox_Clientes.Controls.Add(this._Lbl_DgInfo_Guia);
            this._GrpBox_Clientes.Controls.Add(this._Dg_Grid_Clientes);
            this._GrpBox_Clientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this._GrpBox_Clientes.Location = new System.Drawing.Point(0, 0);
            this._GrpBox_Clientes.Name = "_GrpBox_Clientes";
            this._GrpBox_Clientes.Padding = new System.Windows.Forms.Padding(8);
            this._GrpBox_Clientes.Size = new System.Drawing.Size(1118, 116);
            this._GrpBox_Clientes.TabIndex = 2;
            this._GrpBox_Clientes.TabStop = false;
            this._GrpBox_Clientes.Text = "Clientes - Documentos";
            // 
            // _Lbl_DgInfo_Guia
            // 
            this._Lbl_DgInfo_Guia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._Lbl_DgInfo_Guia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo_Guia.Location = new System.Drawing.Point(9, 93);
            this._Lbl_DgInfo_Guia.Name = "_Lbl_DgInfo_Guia";
            this._Lbl_DgInfo_Guia.Size = new System.Drawing.Size(1101, 15);
            this._Lbl_DgInfo_Guia.TabIndex = 139;
            this._Lbl_DgInfo_Guia.Text = "Use doble click para editar";
            // 
            // _Dg_Grid_Clientes
            // 
            this._Dg_Grid_Clientes.AllowUserToAddRows = false;
            this._Dg_Grid_Clientes.AllowUserToDeleteRows = false;
            this._Dg_Grid_Clientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._Dg_Grid_Clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid_Clientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this._Dg_Grid_Clientes.Location = new System.Drawing.Point(8, 22);
            this._Dg_Grid_Clientes.Name = "_Dg_Grid_Clientes";
            this._Dg_Grid_Clientes.Size = new System.Drawing.Size(1102, 68);
            this._Dg_Grid_Clientes.TabIndex = 2;
            this._Dg_Grid_Clientes.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_Clientes_RowHeaderMouseDoubleClick);
            // 
            // _LayoutChequeYDeposito
            // 
            this._LayoutChequeYDeposito.ColumnCount = 1;
            this._LayoutChequeYDeposito.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._LayoutChequeYDeposito.Controls.Add(this._Pnl_Depositos, 0, 0);
            this._LayoutChequeYDeposito.Dock = System.Windows.Forms.DockStyle.Fill;
            this._LayoutChequeYDeposito.Location = new System.Drawing.Point(3, 247);
            this._LayoutChequeYDeposito.Name = "_LayoutChequeYDeposito";
            this._LayoutChequeYDeposito.RowCount = 1;
            this._LayoutChequeYDeposito.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._LayoutChequeYDeposito.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this._LayoutChequeYDeposito.Size = new System.Drawing.Size(1118, 116);
            this._LayoutChequeYDeposito.TabIndex = 1;
            // 
            // _Pnl_Depositos
            // 
            this._Pnl_Depositos.Controls.Add(this._GrpBox_Depositos);
            this._Pnl_Depositos.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Pnl_Depositos.Location = new System.Drawing.Point(3, 3);
            this._Pnl_Depositos.Name = "_Pnl_Depositos";
            this._Pnl_Depositos.Size = new System.Drawing.Size(1112, 110);
            this._Pnl_Depositos.TabIndex = 1;
            // 
            // _GrpBox_Depositos
            // 
            this._GrpBox_Depositos.Controls.Add(this._Dg_Grid_Depositos);
            this._GrpBox_Depositos.Dock = System.Windows.Forms.DockStyle.Fill;
            this._GrpBox_Depositos.Location = new System.Drawing.Point(0, 0);
            this._GrpBox_Depositos.Name = "_GrpBox_Depositos";
            this._GrpBox_Depositos.Padding = new System.Windows.Forms.Padding(8);
            this._GrpBox_Depositos.Size = new System.Drawing.Size(1112, 110);
            this._GrpBox_Depositos.TabIndex = 2;
            this._GrpBox_Depositos.TabStop = false;
            this._GrpBox_Depositos.Text = "Depósitos";
            // 
            // _Dg_Grid_Depositos
            // 
            this._Dg_Grid_Depositos.AllowUserToAddRows = false;
            this._Dg_Grid_Depositos.AllowUserToDeleteRows = false;
            this._Dg_Grid_Depositos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid_Depositos.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid_Depositos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this._Dg_Grid_Depositos.Location = new System.Drawing.Point(8, 19);
            this._Dg_Grid_Depositos.Name = "_Dg_Grid_Depositos";
            this._Dg_Grid_Depositos.Size = new System.Drawing.Size(1096, 83);
            this._Dg_Grid_Depositos.TabIndex = 1;
            // 
            // _Pnl_Retenciones
            // 
            this._Pnl_Retenciones.Controls.Add(this._GrpBox_Retenciones);
            this._Pnl_Retenciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Pnl_Retenciones.Location = new System.Drawing.Point(3, 369);
            this._Pnl_Retenciones.Name = "_Pnl_Retenciones";
            this._Pnl_Retenciones.Size = new System.Drawing.Size(1118, 116);
            this._Pnl_Retenciones.TabIndex = 3;
            // 
            // _GrpBox_Retenciones
            // 
            this._GrpBox_Retenciones.Controls.Add(this._Dg_Grid_Retenciones);
            this._GrpBox_Retenciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this._GrpBox_Retenciones.Location = new System.Drawing.Point(0, 0);
            this._GrpBox_Retenciones.Name = "_GrpBox_Retenciones";
            this._GrpBox_Retenciones.Padding = new System.Windows.Forms.Padding(8);
            this._GrpBox_Retenciones.Size = new System.Drawing.Size(1118, 116);
            this._GrpBox_Retenciones.TabIndex = 0;
            this._GrpBox_Retenciones.TabStop = false;
            this._GrpBox_Retenciones.Text = "Retenciones";
            // 
            // _Dg_Grid_Retenciones
            // 
            this._Dg_Grid_Retenciones.AllowUserToAddRows = false;
            this._Dg_Grid_Retenciones.AllowUserToDeleteRows = false;
            this._Dg_Grid_Retenciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid_Retenciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid_Retenciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this._Dg_Grid_Retenciones.Location = new System.Drawing.Point(8, 19);
            this._Dg_Grid_Retenciones.Name = "_Dg_Grid_Retenciones";
            this._Dg_Grid_Retenciones.Size = new System.Drawing.Size(1102, 89);
            this._Dg_Grid_Retenciones.TabIndex = 2;
            // 
            // _Pnl_Clave
            // 
            this._Pnl_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Clave.Controls.Add(this._Bt_Aceptar);
            this._Pnl_Clave.Controls.Add(this._Lbl_Titulo);
            this._Pnl_Clave.Controls.Add(this.label12);
            this._Pnl_Clave.Controls.Add(this._Txt_Clave);
            this._Pnl_Clave.Controls.Add(this._Bt_Cancelar);
            this._Pnl_Clave.Controls.Add(this.label13);
            this._Pnl_Clave.Location = new System.Drawing.Point(485, 213);
            this._Pnl_Clave.Name = "_Pnl_Clave";
            this._Pnl_Clave.Size = new System.Drawing.Size(154, 100);
            this._Pnl_Clave.TabIndex = 4;
            this._Pnl_Clave.Visible = false;
            this._Pnl_Clave.VisibleChanged += new System.EventHandler(this._Pnl_Clave_VisibleChanged);
            // 
            // _Bt_Aceptar
            // 
            this._Bt_Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Aceptar.Location = new System.Drawing.Point(9, 72);
            this._Bt_Aceptar.Name = "_Bt_Aceptar";
            this._Bt_Aceptar.Size = new System.Drawing.Size(62, 20);
            this._Bt_Aceptar.TabIndex = 4;
            this._Bt_Aceptar.Text = "Aceptar";
            this._Bt_Aceptar.UseVisualStyleBackColor = true;
            this._Bt_Aceptar.Click += new System.EventHandler(this._Bt_Aceptar_Click);
            // 
            // _Lbl_Titulo
            // 
            this._Lbl_Titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this._Lbl_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_Titulo.ForeColor = System.Drawing.Color.Black;
            this._Lbl_Titulo.Location = new System.Drawing.Point(0, 19);
            this._Lbl_Titulo.Name = "_Lbl_Titulo";
            this._Lbl_Titulo.Size = new System.Drawing.Size(152, 25);
            this._Lbl_Titulo.TabIndex = 1;
            this._Lbl_Titulo.Text = "¿Esta seguro de ...?";
            this._Lbl_Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "Clave:";
            // 
            // _Txt_Clave
            // 
            this._Txt_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Clave.Location = new System.Drawing.Point(50, 48);
            this._Txt_Clave.Name = "_Txt_Clave";
            this._Txt_Clave.PasswordChar = '*';
            this._Txt_Clave.Size = new System.Drawing.Size(95, 18);
            this._Txt_Clave.TabIndex = 3;
            // 
            // _Bt_Cancelar
            // 
            this._Bt_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Cancelar.Location = new System.Drawing.Point(77, 72);
            this._Bt_Cancelar.Name = "_Bt_Cancelar";
            this._Bt_Cancelar.Size = new System.Drawing.Size(68, 20);
            this._Bt_Cancelar.TabIndex = 5;
            this._Bt_Cancelar.Text = "Cancelar";
            this._Bt_Cancelar.UseVisualStyleBackColor = true;
            this._Bt_Cancelar.Click += new System.EventHandler(this._Bt_Cancelar_Click);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Navy;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(152, 19);
            this.label13.TabIndex = 0;
            this.label13.Text = "Introduzca Clave";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_RC_Resumen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 589);
            this.Controls.Add(this._Pnl_Clave);
            this.Controls.Add(this._Layout_Principal);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Frm_RC_Resumen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cobranza de Guía de Despacho #";
            this.Load += new System.EventHandler(this.Frm_RC_Resumen_Load);
            this._Layout_Principal.ResumeLayout(false);
            this._Layout_SobranteYBotones.ResumeLayout(false);
            this._Pnl_SobranteyFaltante.ResumeLayout(false);
            this._GrpBox_SobranteFaltante.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_SobranteFaltante)).EndInit();
            this._Pnl_AprobarRechazar.ResumeLayout(false);
            this._Pnl_GuiasGeneradas.ResumeLayout(false);
            this._GrpBox_GuiasGeneradas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_GuiasGeneradas)).EndInit();
            this._Pnl_Cheques.ResumeLayout(false);
            this._GrpBox_Cheques.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_Cheques)).EndInit();
            this._Pnl_Clientes.ResumeLayout(false);
            this._GrpBox_Clientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_Clientes)).EndInit();
            this._LayoutChequeYDeposito.ResumeLayout(false);
            this._Pnl_Depositos.ResumeLayout(false);
            this._GrpBox_Depositos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_Depositos)).EndInit();
            this._Pnl_Retenciones.ResumeLayout(false);
            this._GrpBox_Retenciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_Retenciones)).EndInit();
            this._Pnl_Clave.ResumeLayout(false);
            this._Pnl_Clave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _Layout_Principal;
        private System.Windows.Forms.Panel _Pnl_Clientes;
        private System.Windows.Forms.TableLayoutPanel _LayoutChequeYDeposito;
        private System.Windows.Forms.TableLayoutPanel _Layout_SobranteYBotones;
        private System.Windows.Forms.Panel _Pnl_Depositos;
        private System.Windows.Forms.DataGridView _Dg_Grid_Depositos;
        private System.Windows.Forms.GroupBox _GrpBox_Clientes;
        private System.Windows.Forms.DataGridView _Dg_Grid_Clientes;
        private System.Windows.Forms.GroupBox _GrpBox_Depositos;
        private System.Windows.Forms.Panel _Pnl_Cheques;
        private System.Windows.Forms.GroupBox _GrpBox_Cheques;
        private System.Windows.Forms.DataGridView _Dg_Grid_Cheques;
        private System.Windows.Forms.Label _Lbl_DgInfo_Guia;
        private System.Windows.Forms.Panel _Pnl_SobranteyFaltante;
        private System.Windows.Forms.GroupBox _GrpBox_SobranteFaltante;
        private System.Windows.Forms.DataGridView _Dg_Grid_SobranteFaltante;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Col_Sobrante;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Col_Faltante;
        private System.Windows.Forms.Panel _Pnl_AprobarRechazar;
        private System.Windows.Forms.Button _Btn_Rechazar;
        private System.Windows.Forms.Button _Btn_Aprobar;
        private System.Windows.Forms.Panel _Pnl_Clave;
        private System.Windows.Forms.Button _Bt_Aceptar;
        private System.Windows.Forms.Label _Lbl_Titulo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox _Txt_Clave;
        private System.Windows.Forms.Button _Bt_Cancelar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel _Pnl_GuiasGeneradas;
        private System.Windows.Forms.GroupBox _GrpBox_GuiasGeneradas;
        private System.Windows.Forms.DataGridView _Dg_Grid_GuiasGeneradas;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdRelacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Compañia;
        private System.Windows.Forms.Button _Btn_Imprimir;
        private System.Windows.Forms.Panel _Pnl_Retenciones;
        private System.Windows.Forms.GroupBox _GrpBox_Retenciones;
        private System.Windows.Forms.DataGridView _Dg_Grid_Retenciones;
    }
}