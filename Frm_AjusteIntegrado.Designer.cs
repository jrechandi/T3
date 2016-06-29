namespace T3
{
    partial class Frm_AjusteIntegrado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AjusteIntegrado));
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Chk_Anulados = new System.Windows.Forms.CheckBox();
            this._Bt_Consultar = new System.Windows.Forms.Button();
            this._Dtp_Hasta = new System.Windows.Forms.DateTimePicker();
            this._Dtp_Desde = new System.Windows.Forms.DateTimePicker();
            this._Lbl_Desde = new System.Windows.Forms.Label();
            this._Lbl_Hasta = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._Dg_Detalle = new System.Windows.Forms.DataGridView();
            this._Col_ProductoSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Col_LoteSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Col_PmvSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Col_Cajas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Col_Unidades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Col_ProductoEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Col_LoteEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Col_PmvEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Lbl_DgInfoComp = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this._Txt_TotalCostoEntrada = new System.Windows.Forms.TextBox();
            this._Txt_TotalImpuestoEntrada = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._Txt_TotalCostoSalida = new System.Windows.Forms.TextBox();
            this._Txt_TotalImpuestoSalida = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this._Bt_Imprimir = new System.Windows.Forms.Button();
            this._Txt_Observacion = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._Txt_NotaEntrega = new System.Windows.Forms.TextBox();
            this._Grb_Firma = new System.Windows.Forms.GroupBox();
            this._Bt_EliminarAprobador2 = new System.Windows.Forms.Button();
            this._Bt_EliminarAprobador1 = new System.Windows.Forms.Button();
            this._Txt_FirmaAprobador2 = new System.Windows.Forms.TextBox();
            this._Txt_FirmaAprobador1 = new System.Windows.Forms.TextBox();
            this._Bt_FirmaAprobador2 = new System.Windows.Forms.Button();
            this._Bt_FirmaAprobador1 = new System.Windows.Forms.Button();
            this.lblAprobador2 = new System.Windows.Forms.Label();
            this.lblAprobador1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._Cmb_Proveedor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this._Cmb_Motivo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this._Txt_AjusteSalida = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Txt_AjusteEntrada = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this._Txt_NotaRecepcion = new System.Windows.Forms.TextBox();
            this._Lbl_Retencion = new System.Windows.Forms.Label();
            this._Bt_Agregar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._Dtp_Fecha = new System.Windows.Forms.DateTimePicker();
            this._Txt_AjusteIntegrado = new System.Windows.Forms.TextBox();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Cntx_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._Mnu_Editar = new System.Windows.Forms.ToolStripMenuItem();
            this._Mnu_Eliminar = new System.Windows.Forms.ToolStripMenuItem();
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Detalle)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this._Grb_Firma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this._Cntx_Menu.SuspendLayout();
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
            this._Tb_Tab.Size = new System.Drawing.Size(882, 534);
            this._Tb_Tab.TabIndex = 19;
            this._Tb_Tab.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this._Tb_Tab_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._Dg_Grid);
            this.tabPage1.Controls.Add(this._Lbl_DgInfo);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(874, 509);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(3, 82);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.Size = new System.Drawing.Size(868, 413);
            this._Dg_Grid.TabIndex = 17;
            this._Dg_Grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseDoubleClick);
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(3, 495);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(868, 11);
            this._Lbl_DgInfo.TabIndex = 135;
            this._Lbl_DgInfo.Text = "Use: Doble click para ver - Click derecho para anular";
            this._Lbl_DgInfo.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Chk_Anulados);
            this.panel1.Controls.Add(this._Bt_Consultar);
            this.panel1.Controls.Add(this._Dtp_Hasta);
            this.panel1.Controls.Add(this._Dtp_Desde);
            this.panel1.Controls.Add(this._Lbl_Desde);
            this.panel1.Controls.Add(this._Lbl_Hasta);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(868, 79);
            this.panel1.TabIndex = 0;
            // 
            // _Chk_Anulados
            // 
            this._Chk_Anulados.AutoSize = true;
            this._Chk_Anulados.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Chk_Anulados.Location = new System.Drawing.Point(11, 46);
            this._Chk_Anulados.Name = "_Chk_Anulados";
            this._Chk_Anulados.Size = new System.Drawing.Size(130, 17);
            this._Chk_Anulados.TabIndex = 50;
            this._Chk_Anulados.Text = "Filtrar anulados";
            this._Chk_Anulados.UseVisualStyleBackColor = true;
            // 
            // _Bt_Consultar
            // 
            this._Bt_Consultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Consultar.Image")));
            this._Bt_Consultar.Location = new System.Drawing.Point(208, 37);
            this._Bt_Consultar.Name = "_Bt_Consultar";
            this._Bt_Consultar.Size = new System.Drawing.Size(91, 34);
            this._Bt_Consultar.TabIndex = 47;
            this._Bt_Consultar.UseVisualStyleBackColor = true;
            this._Bt_Consultar.Click += new System.EventHandler(this._Bt_Consultar_Click);
            // 
            // _Dtp_Hasta
            // 
            this._Dtp_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dtp_Hasta.Location = new System.Drawing.Point(202, 13);
            this._Dtp_Hasta.Name = "_Dtp_Hasta";
            this._Dtp_Hasta.Size = new System.Drawing.Size(97, 18);
            this._Dtp_Hasta.TabIndex = 43;
            this._Dtp_Hasta.Value = new System.DateTime(2008, 5, 28, 0, 0, 0, 0);
            this._Dtp_Hasta.ValueChanged += new System.EventHandler(this._Dtp_Hasta_ValueChanged);
            // 
            // _Dtp_Desde
            // 
            this._Dtp_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dtp_Desde.Location = new System.Drawing.Point(56, 13);
            this._Dtp_Desde.Name = "_Dtp_Desde";
            this._Dtp_Desde.Size = new System.Drawing.Size(97, 18);
            this._Dtp_Desde.TabIndex = 44;
            this._Dtp_Desde.Value = new System.DateTime(2008, 5, 28, 0, 0, 0, 0);
            // 
            // _Lbl_Desde
            // 
            this._Lbl_Desde.AutoSize = true;
            this._Lbl_Desde.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Lbl_Desde.Location = new System.Drawing.Point(8, 16);
            this._Lbl_Desde.Name = "_Lbl_Desde";
            this._Lbl_Desde.Size = new System.Drawing.Size(51, 13);
            this._Lbl_Desde.TabIndex = 45;
            this._Lbl_Desde.Text = "Desde:";
            // 
            // _Lbl_Hasta
            // 
            this._Lbl_Hasta.AutoSize = true;
            this._Lbl_Hasta.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Lbl_Hasta.Location = new System.Drawing.Point(157, 16);
            this._Lbl_Hasta.Name = "_Lbl_Hasta";
            this._Lbl_Hasta.Size = new System.Drawing.Size(48, 13);
            this._Lbl_Hasta.TabIndex = 46;
            this._Lbl_Hasta.Text = "Hasta:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._Dg_Detalle);
            this.tabPage2.Controls.Add(this._Lbl_DgInfoComp);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(874, 509);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _Dg_Detalle
            // 
            this._Dg_Detalle.AllowUserToAddRows = false;
            this._Dg_Detalle.AllowUserToDeleteRows = false;
            this._Dg_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Detalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._Col_ProductoSalida,
            this._Col_LoteSalida,
            this._Col_PmvSalida,
            this._Col_Cajas,
            this._Col_Unidades,
            this._Col_ProductoEntrada,
            this._Col_LoteEntrada,
            this._Col_PmvEntrada});
            this._Dg_Detalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Detalle.Location = new System.Drawing.Point(3, 328);
            this._Dg_Detalle.Name = "_Dg_Detalle";
            this._Dg_Detalle.ReadOnly = true;
            this._Dg_Detalle.Size = new System.Drawing.Size(868, 77);
            this._Dg_Detalle.TabIndex = 133;
            // 
            // _Col_ProductoSalida
            // 
            this._Col_ProductoSalida.HeaderText = "ProductoSalida";
            this._Col_ProductoSalida.Name = "_Col_ProductoSalida";
            this._Col_ProductoSalida.ReadOnly = true;
            // 
            // _Col_LoteSalida
            // 
            this._Col_LoteSalida.HeaderText = "LoteSalida";
            this._Col_LoteSalida.Name = "_Col_LoteSalida";
            this._Col_LoteSalida.ReadOnly = true;
            // 
            // _Col_PmvSalida
            // 
            this._Col_PmvSalida.HeaderText = "PmvSalida";
            this._Col_PmvSalida.Name = "_Col_PmvSalida";
            this._Col_PmvSalida.ReadOnly = true;
            // 
            // _Col_Cajas
            // 
            this._Col_Cajas.HeaderText = "Cajas";
            this._Col_Cajas.Name = "_Col_Cajas";
            this._Col_Cajas.ReadOnly = true;
            // 
            // _Col_Unidades
            // 
            this._Col_Unidades.HeaderText = "Unidades";
            this._Col_Unidades.Name = "_Col_Unidades";
            this._Col_Unidades.ReadOnly = true;
            // 
            // _Col_ProductoEntrada
            // 
            this._Col_ProductoEntrada.HeaderText = "ProductoEntrada";
            this._Col_ProductoEntrada.Name = "_Col_ProductoEntrada";
            this._Col_ProductoEntrada.ReadOnly = true;
            // 
            // _Col_LoteEntrada
            // 
            this._Col_LoteEntrada.HeaderText = "LoteEntrada";
            this._Col_LoteEntrada.Name = "_Col_LoteEntrada";
            this._Col_LoteEntrada.ReadOnly = true;
            // 
            // _Col_PmvEntrada
            // 
            this._Col_PmvEntrada.HeaderText = "PmvEntrada";
            this._Col_PmvEntrada.Name = "_Col_PmvEntrada";
            this._Col_PmvEntrada.ReadOnly = true;
            // 
            // _Lbl_DgInfoComp
            // 
            this._Lbl_DgInfoComp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfoComp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfoComp.Location = new System.Drawing.Point(3, 405);
            this._Lbl_DgInfoComp.Name = "_Lbl_DgInfoComp";
            this._Lbl_DgInfoComp.Size = new System.Drawing.Size(868, 11);
            this._Lbl_DgInfoComp.TabIndex = 134;
            this._Lbl_DgInfoComp.Text = "Use click derecho para editar o eliminar";
            this._Lbl_DgInfoComp.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 416);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(868, 90);
            this.panel3.TabIndex = 135;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this._Txt_TotalCostoEntrada);
            this.groupBox2.Controls.Add(this._Txt_TotalImpuestoEntrada);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(274, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 67);
            this.groupBox2.TabIndex = 92;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Entrada";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(50, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 87;
            this.label10.Text = "Total Costo:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(137, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 13);
            this.label11.TabIndex = 89;
            this.label11.Text = "Total Impuesto:";
            // 
            // _Txt_TotalCostoEntrada
            // 
            this._Txt_TotalCostoEntrada.BackColor = System.Drawing.Color.White;
            this._Txt_TotalCostoEntrada.Enabled = false;
            this._Txt_TotalCostoEntrada.Location = new System.Drawing.Point(27, 33);
            this._Txt_TotalCostoEntrada.MaxLength = 14;
            this._Txt_TotalCostoEntrada.Name = "_Txt_TotalCostoEntrada";
            this._Txt_TotalCostoEntrada.ReadOnly = true;
            this._Txt_TotalCostoEntrada.Size = new System.Drawing.Size(102, 21);
            this._Txt_TotalCostoEntrada.TabIndex = 88;
            this._Txt_TotalCostoEntrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _Txt_TotalImpuestoEntrada
            // 
            this._Txt_TotalImpuestoEntrada.BackColor = System.Drawing.Color.White;
            this._Txt_TotalImpuestoEntrada.Enabled = false;
            this._Txt_TotalImpuestoEntrada.Location = new System.Drawing.Point(140, 33);
            this._Txt_TotalImpuestoEntrada.MaxLength = 14;
            this._Txt_TotalImpuestoEntrada.Name = "_Txt_TotalImpuestoEntrada";
            this._Txt_TotalImpuestoEntrada.ReadOnly = true;
            this._Txt_TotalImpuestoEntrada.Size = new System.Drawing.Size(102, 21);
            this._Txt_TotalImpuestoEntrada.TabIndex = 90;
            this._Txt_TotalImpuestoEntrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this._Txt_TotalCostoSalida);
            this.groupBox1.Controls.Add(this._Txt_TotalImpuestoSalida);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(11, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 67);
            this.groupBox1.TabIndex = 91;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Salida";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(50, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 87;
            this.label9.Text = "Total Costo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(137, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 89;
            this.label7.Text = "Total Impuesto:";
            // 
            // _Txt_TotalCostoSalida
            // 
            this._Txt_TotalCostoSalida.BackColor = System.Drawing.Color.White;
            this._Txt_TotalCostoSalida.Enabled = false;
            this._Txt_TotalCostoSalida.Location = new System.Drawing.Point(27, 33);
            this._Txt_TotalCostoSalida.MaxLength = 14;
            this._Txt_TotalCostoSalida.Name = "_Txt_TotalCostoSalida";
            this._Txt_TotalCostoSalida.ReadOnly = true;
            this._Txt_TotalCostoSalida.Size = new System.Drawing.Size(102, 21);
            this._Txt_TotalCostoSalida.TabIndex = 88;
            this._Txt_TotalCostoSalida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _Txt_TotalImpuestoSalida
            // 
            this._Txt_TotalImpuestoSalida.BackColor = System.Drawing.Color.White;
            this._Txt_TotalImpuestoSalida.Enabled = false;
            this._Txt_TotalImpuestoSalida.Location = new System.Drawing.Point(140, 33);
            this._Txt_TotalImpuestoSalida.MaxLength = 14;
            this._Txt_TotalImpuestoSalida.Name = "_Txt_TotalImpuestoSalida";
            this._Txt_TotalImpuestoSalida.ReadOnly = true;
            this._Txt_TotalImpuestoSalida.Size = new System.Drawing.Size(102, 21);
            this._Txt_TotalImpuestoSalida.TabIndex = 90;
            this._Txt_TotalImpuestoSalida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._Bt_Imprimir);
            this.panel2.Controls.Add(this._Txt_Observacion);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this._Txt_NotaEntrega);
            this.panel2.Controls.Add(this._Grb_Firma);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this._Cmb_Proveedor);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this._Cmb_Motivo);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this._Txt_AjusteSalida);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this._Txt_AjusteEntrada);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this._Txt_NotaRecepcion);
            this.panel2.Controls.Add(this._Lbl_Retencion);
            this.panel2.Controls.Add(this._Bt_Agregar);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this._Dtp_Fecha);
            this.panel2.Controls.Add(this._Txt_AjusteIntegrado);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(868, 325);
            this.panel2.TabIndex = 64;
            // 
            // _Bt_Imprimir
            // 
            this._Bt_Imprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Bt_Imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Imprimir.Enabled = false;
            this._Bt_Imprimir.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this._Bt_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Imprimir.Image")));
            this._Bt_Imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Imprimir.Location = new System.Drawing.Point(704, 119);
            this._Bt_Imprimir.Name = "_Bt_Imprimir";
            this._Bt_Imprimir.Size = new System.Drawing.Size(159, 34);
            this._Bt_Imprimir.TabIndex = 108;
            this._Bt_Imprimir.Text = "Imprimir ajustes";
            this._Bt_Imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Imprimir.UseVisualStyleBackColor = true;
            this._Bt_Imprimir.Click += new System.EventHandler(this._Bt_Imprimir_Click);
            // 
            // _Txt_Observacion
            // 
            this._Txt_Observacion.BackColor = System.Drawing.Color.White;
            this._Txt_Observacion.Enabled = false;
            this._Txt_Observacion.Location = new System.Drawing.Point(11, 262);
            this._Txt_Observacion.MaxLength = 255;
            this._Txt_Observacion.Name = "_Txt_Observacion";
            this._Txt_Observacion.Size = new System.Drawing.Size(337, 18);
            this._Txt_Observacion.TabIndex = 95;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(8, 246);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 94;
            this.label12.Text = "Observacion:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(8, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 92;
            this.label6.Text = "Nota de entrega:";
            // 
            // _Txt_NotaEntrega
            // 
            this._Txt_NotaEntrega.BackColor = System.Drawing.Color.White;
            this._Txt_NotaEntrega.Enabled = false;
            this._Txt_NotaEntrega.Location = new System.Drawing.Point(11, 225);
            this._Txt_NotaEntrega.MaxLength = 14;
            this._Txt_NotaEntrega.Name = "_Txt_NotaEntrega";
            this._Txt_NotaEntrega.Size = new System.Drawing.Size(126, 18);
            this._Txt_NotaEntrega.TabIndex = 93;
            this._Txt_NotaEntrega.TextChanged += new System.EventHandler(this._Txt_NotaEntrega_TextChanged);
            this._Txt_NotaEntrega.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_NotaEntrega_KeyPress);
            // 
            // _Grb_Firma
            // 
            this._Grb_Firma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Grb_Firma.Controls.Add(this._Bt_EliminarAprobador2);
            this._Grb_Firma.Controls.Add(this._Bt_EliminarAprobador1);
            this._Grb_Firma.Controls.Add(this._Txt_FirmaAprobador2);
            this._Grb_Firma.Controls.Add(this._Txt_FirmaAprobador1);
            this._Grb_Firma.Controls.Add(this._Bt_FirmaAprobador2);
            this._Grb_Firma.Controls.Add(this._Bt_FirmaAprobador1);
            this._Grb_Firma.Controls.Add(this.lblAprobador2);
            this._Grb_Firma.Controls.Add(this.lblAprobador1);
            this._Grb_Firma.Location = new System.Drawing.Point(615, 3);
            this._Grb_Firma.Name = "_Grb_Firma";
            this._Grb_Firma.Size = new System.Drawing.Size(248, 101);
            this._Grb_Firma.TabIndex = 91;
            this._Grb_Firma.TabStop = false;
            this._Grb_Firma.Text = "Firmas";
            // 
            // _Bt_EliminarAprobador2
            // 
            this._Bt_EliminarAprobador2.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_EliminarAprobador2.Enabled = false;
            this._Bt_EliminarAprobador2.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_EliminarAprobador2.Image")));
            this._Bt_EliminarAprobador2.Location = new System.Drawing.Point(199, 65);
            this._Bt_EliminarAprobador2.Name = "_Bt_EliminarAprobador2";
            this._Bt_EliminarAprobador2.Size = new System.Drawing.Size(27, 24);
            this._Bt_EliminarAprobador2.TabIndex = 32;
            this._Bt_EliminarAprobador2.UseVisualStyleBackColor = true;
            this._Bt_EliminarAprobador2.Click += new System.EventHandler(this._Bt_EliminarAprobador2_Click);
            // 
            // _Bt_EliminarAprobador1
            // 
            this._Bt_EliminarAprobador1.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_EliminarAprobador1.Enabled = false;
            this._Bt_EliminarAprobador1.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_EliminarAprobador1.Image")));
            this._Bt_EliminarAprobador1.Location = new System.Drawing.Point(199, 27);
            this._Bt_EliminarAprobador1.Name = "_Bt_EliminarAprobador1";
            this._Bt_EliminarAprobador1.Size = new System.Drawing.Size(27, 24);
            this._Bt_EliminarAprobador1.TabIndex = 31;
            this._Bt_EliminarAprobador1.UseVisualStyleBackColor = true;
            this._Bt_EliminarAprobador1.Click += new System.EventHandler(this._Bt_EliminarAprobador1_Click);
            // 
            // _Txt_FirmaAprobador2
            // 
            this._Txt_FirmaAprobador2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_FirmaAprobador2.Location = new System.Drawing.Point(40, 68);
            this._Txt_FirmaAprobador2.Name = "_Txt_FirmaAprobador2";
            this._Txt_FirmaAprobador2.ReadOnly = true;
            this._Txt_FirmaAprobador2.Size = new System.Drawing.Size(153, 18);
            this._Txt_FirmaAprobador2.TabIndex = 23;
            // 
            // _Txt_FirmaAprobador1
            // 
            this._Txt_FirmaAprobador1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_FirmaAprobador1.Location = new System.Drawing.Point(39, 30);
            this._Txt_FirmaAprobador1.Name = "_Txt_FirmaAprobador1";
            this._Txt_FirmaAprobador1.ReadOnly = true;
            this._Txt_FirmaAprobador1.Size = new System.Drawing.Size(154, 18);
            this._Txt_FirmaAprobador1.TabIndex = 0;
            // 
            // _Bt_FirmaAprobador2
            // 
            this._Bt_FirmaAprobador2.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_FirmaAprobador2.Enabled = false;
            this._Bt_FirmaAprobador2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_FirmaAprobador2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_FirmaAprobador2.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_FirmaAprobador2.Image")));
            this._Bt_FirmaAprobador2.Location = new System.Drawing.Point(8, 65);
            this._Bt_FirmaAprobador2.Name = "_Bt_FirmaAprobador2";
            this._Bt_FirmaAprobador2.Size = new System.Drawing.Size(27, 24);
            this._Bt_FirmaAprobador2.TabIndex = 28;
            this._Bt_FirmaAprobador2.UseVisualStyleBackColor = true;
            this._Bt_FirmaAprobador2.Click += new System.EventHandler(this._Bt_FirmaAprobador2_Click);
            // 
            // _Bt_FirmaAprobador1
            // 
            this._Bt_FirmaAprobador1.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_FirmaAprobador1.Enabled = false;
            this._Bt_FirmaAprobador1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_FirmaAprobador1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_FirmaAprobador1.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_FirmaAprobador1.Image")));
            this._Bt_FirmaAprobador1.Location = new System.Drawing.Point(8, 27);
            this._Bt_FirmaAprobador1.Name = "_Bt_FirmaAprobador1";
            this._Bt_FirmaAprobador1.Size = new System.Drawing.Size(27, 24);
            this._Bt_FirmaAprobador1.TabIndex = 27;
            this._Bt_FirmaAprobador1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_FirmaAprobador1.UseVisualStyleBackColor = true;
            this._Bt_FirmaAprobador1.Click += new System.EventHandler(this._Bt_FirmaAprobador1_Click);
            // 
            // lblAprobador2
            // 
            this.lblAprobador2.AutoSize = true;
            this.lblAprobador2.Location = new System.Drawing.Point(39, 53);
            this.lblAprobador2.Name = "lblAprobador2";
            this.lblAprobador2.Size = new System.Drawing.Size(67, 12);
            this.lblAprobador2.TabIndex = 24;
            this.lblAprobador2.Text = "Aprobador 2";
            // 
            // lblAprobador1
            // 
            this.lblAprobador1.AutoSize = true;
            this.lblAprobador1.Location = new System.Drawing.Point(38, 15);
            this.lblAprobador1.Name = "lblAprobador1";
            this.lblAprobador1.Size = new System.Drawing.Size(67, 12);
            this.lblAprobador1.TabIndex = 22;
            this.lblAprobador1.Text = "Aprobador 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(8, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 90;
            this.label4.Text = "Proveedor:";
            // 
            // _Cmb_Proveedor
            // 
            this._Cmb_Proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Proveedor.Enabled = false;
            this._Cmb_Proveedor.FormattingEnabled = true;
            this._Cmb_Proveedor.Location = new System.Drawing.Point(11, 147);
            this._Cmb_Proveedor.Name = "_Cmb_Proveedor";
            this._Cmb_Proveedor.Size = new System.Drawing.Size(337, 20);
            this._Cmb_Proveedor.TabIndex = 89;
            this._Cmb_Proveedor.SelectedIndexChanged += new System.EventHandler(this._Cmb_Proveedor_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(8, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 88;
            this.label5.Text = "Motivo:";
            // 
            // _Cmb_Motivo
            // 
            this._Cmb_Motivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Motivo.Enabled = false;
            this._Cmb_Motivo.FormattingEnabled = true;
            this._Cmb_Motivo.Location = new System.Drawing.Point(11, 107);
            this._Cmb_Motivo.Name = "_Cmb_Motivo";
            this._Cmb_Motivo.Size = new System.Drawing.Size(337, 20);
            this._Cmb_Motivo.TabIndex = 87;
            this._Cmb_Motivo.SelectedIndexChanged += new System.EventHandler(this._Cmb_Motivo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(114, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = "Ajuste de Sal.:";
            // 
            // _Txt_AjusteSalida
            // 
            this._Txt_AjusteSalida.BackColor = System.Drawing.Color.White;
            this._Txt_AjusteSalida.Enabled = false;
            this._Txt_AjusteSalida.Location = new System.Drawing.Point(117, 32);
            this._Txt_AjusteSalida.MaxLength = 14;
            this._Txt_AjusteSalida.Name = "_Txt_AjusteSalida";
            this._Txt_AjusteSalida.ReadOnly = true;
            this._Txt_AjusteSalida.Size = new System.Drawing.Size(100, 18);
            this._Txt_AjusteSalida.TabIndex = 86;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(220, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 83;
            this.label1.Text = "Ajuste de Ent.:";
            // 
            // _Txt_AjusteEntrada
            // 
            this._Txt_AjusteEntrada.BackColor = System.Drawing.Color.White;
            this._Txt_AjusteEntrada.Enabled = false;
            this._Txt_AjusteEntrada.Location = new System.Drawing.Point(223, 32);
            this._Txt_AjusteEntrada.MaxLength = 14;
            this._Txt_AjusteEntrada.Name = "_Txt_AjusteEntrada";
            this._Txt_AjusteEntrada.ReadOnly = true;
            this._Txt_AjusteEntrada.Size = new System.Drawing.Size(100, 18);
            this._Txt_AjusteEntrada.TabIndex = 84;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(8, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 13);
            this.label8.TabIndex = 64;
            this.label8.Text = "Nota de recepción:";
            // 
            // _Txt_NotaRecepcion
            // 
            this._Txt_NotaRecepcion.BackColor = System.Drawing.Color.White;
            this._Txt_NotaRecepcion.Enabled = false;
            this._Txt_NotaRecepcion.Location = new System.Drawing.Point(11, 188);
            this._Txt_NotaRecepcion.MaxLength = 14;
            this._Txt_NotaRecepcion.Name = "_Txt_NotaRecepcion";
            this._Txt_NotaRecepcion.Size = new System.Drawing.Size(126, 18);
            this._Txt_NotaRecepcion.TabIndex = 65;
            this._Txt_NotaRecepcion.TextChanged += new System.EventHandler(this._Txt_NotaRecepcion_TextChanged);
            this._Txt_NotaRecepcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_NotaRecepcion_KeyPress);
            // 
            // _Lbl_Retencion
            // 
            this._Lbl_Retencion.AutoSize = true;
            this._Lbl_Retencion.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Lbl_Retencion.Location = new System.Drawing.Point(8, 16);
            this._Lbl_Retencion.Name = "_Lbl_Retencion";
            this._Lbl_Retencion.Size = new System.Drawing.Size(103, 13);
            this._Lbl_Retencion.TabIndex = 50;
            this._Lbl_Retencion.Text = "Id integración:";
            // 
            // _Bt_Agregar
            // 
            this._Bt_Agregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Agregar.Enabled = false;
            this._Bt_Agregar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Agregar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Agregar.Image")));
            this._Bt_Agregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Agregar.Location = new System.Drawing.Point(11, 292);
            this._Bt_Agregar.Name = "_Bt_Agregar";
            this._Bt_Agregar.Size = new System.Drawing.Size(148, 27);
            this._Bt_Agregar.TabIndex = 63;
            this._Bt_Agregar.Text = "Agregar producto";
            this._Bt_Agregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Agregar.UseVisualStyleBackColor = true;
            this._Bt_Agregar.Click += new System.EventHandler(this._Bt_Agregar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(8, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Fecha:";
            // 
            // _Dtp_Fecha
            // 
            this._Dtp_Fecha.Enabled = false;
            this._Dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dtp_Fecha.Location = new System.Drawing.Point(11, 69);
            this._Dtp_Fecha.Name = "_Dtp_Fecha";
            this._Dtp_Fecha.Size = new System.Drawing.Size(100, 18);
            this._Dtp_Fecha.TabIndex = 46;
            this._Dtp_Fecha.Value = new System.DateTime(2008, 5, 28, 0, 0, 0, 0);
            // 
            // _Txt_AjusteIntegrado
            // 
            this._Txt_AjusteIntegrado.BackColor = System.Drawing.Color.White;
            this._Txt_AjusteIntegrado.Enabled = false;
            this._Txt_AjusteIntegrado.Location = new System.Drawing.Point(11, 32);
            this._Txt_AjusteIntegrado.MaxLength = 14;
            this._Txt_AjusteIntegrado.Name = "_Txt_AjusteIntegrado";
            this._Txt_AjusteIntegrado.ReadOnly = true;
            this._Txt_AjusteIntegrado.Size = new System.Drawing.Size(100, 18);
            this._Txt_AjusteIntegrado.TabIndex = 51;
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // _Cntx_Menu
            // 
            this._Cntx_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._Mnu_Editar,
            this._Mnu_Eliminar});
            this._Cntx_Menu.Name = "_Cntx_Menu";
            this._Cntx_Menu.Size = new System.Drawing.Size(118, 48);
            this._Cntx_Menu.Opening += new System.ComponentModel.CancelEventHandler(this._Cntx_Menu_Opening);
            // 
            // _Mnu_Editar
            // 
            this._Mnu_Editar.Name = "_Mnu_Editar";
            this._Mnu_Editar.Size = new System.Drawing.Size(117, 22);
            this._Mnu_Editar.Text = "Editar";
            this._Mnu_Editar.Click += new System.EventHandler(this._Mnu_Editar_Click);
            // 
            // _Mnu_Eliminar
            // 
            this._Mnu_Eliminar.Name = "_Mnu_Eliminar";
            this._Mnu_Eliminar.Size = new System.Drawing.Size(117, 22);
            this._Mnu_Eliminar.Text = "Eliminar";
            this._Mnu_Eliminar.Click += new System.EventHandler(this._Mnu_Eliminar_Click);
            // 
            // Frm_AjusteIntegrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 534);
            this.Controls.Add(this._Tb_Tab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AjusteIntegrado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajuste Integrado";
            this.Activated += new System.EventHandler(this.Frm_AjusteIntegrado_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_AjusteIntegrado_FormClosing);
            this.Load += new System.EventHandler(this.Frm_AjusteIntegrado_Load);
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Detalle)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this._Grb_Firma.ResumeLayout(false);
            this._Grb_Firma.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this._Cntx_Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.Label _Lbl_DgInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox _Chk_Anulados;
        private System.Windows.Forms.Button _Bt_Consultar;
        public System.Windows.Forms.DateTimePicker _Dtp_Hasta;
        public System.Windows.Forms.DateTimePicker _Dtp_Desde;
        private System.Windows.Forms.Label _Lbl_Desde;
        private System.Windows.Forms.Label _Lbl_Hasta;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView _Dg_Detalle;
        private System.Windows.Forms.Label _Lbl_DgInfoComp;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _Txt_NotaRecepcion;
        private System.Windows.Forms.Label _Lbl_Retencion;
        private System.Windows.Forms.Button _Bt_Agregar;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker _Dtp_Fecha;
        private System.Windows.Forms.TextBox _Txt_AjusteIntegrado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox _Cmb_Motivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _Txt_AjusteSalida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _Txt_AjusteEntrada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox _Cmb_Proveedor;
        private System.Windows.Forms.GroupBox _Grb_Firma;
        private System.Windows.Forms.Button _Bt_EliminarAprobador2;
        private System.Windows.Forms.Button _Bt_EliminarAprobador1;
        public System.Windows.Forms.TextBox _Txt_FirmaAprobador2;
        public System.Windows.Forms.TextBox _Txt_FirmaAprobador1;
        private System.Windows.Forms.Button _Bt_FirmaAprobador2;
        private System.Windows.Forms.Button _Bt_FirmaAprobador1;
        private System.Windows.Forms.Label lblAprobador2;
        private System.Windows.Forms.Label lblAprobador1;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _Txt_NotaEntrega;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _Txt_TotalImpuestoSalida;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox _Txt_TotalCostoSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Col_ProductoSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Col_LoteSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Col_PmvSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Col_Cajas;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Col_Unidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Col_ProductoEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Col_LoteEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Col_PmvEntrada;
        private System.Windows.Forms.ContextMenuStrip _Cntx_Menu;
        private System.Windows.Forms.ToolStripMenuItem _Mnu_Editar;
        private System.Windows.Forms.ToolStripMenuItem _Mnu_Eliminar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox _Txt_TotalCostoEntrada;
        private System.Windows.Forms.TextBox _Txt_TotalImpuestoEntrada;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox _Txt_Observacion;
        private System.Windows.Forms.Button _Bt_Imprimir;

    }
}