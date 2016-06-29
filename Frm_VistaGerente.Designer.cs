namespace T3
{
    partial class Frm_VistaGerente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_VistaGerente));
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cerrarOCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._Lb_Etiquea = new System.Windows.Forms.Label();
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._Pnl_Clave = new System.Windows.Forms.Panel();
            this._Bt_Aceptar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this._Txt_Clave = new System.Windows.Forms.TextBox();
            this._Bt_Cancelar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Dg_Grid_Detalle = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this._Txt_Cajas = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._Txt_Fecha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._Txt_Monto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._Txt_Proveedor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Txt_OC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this._Pgb_Progress = new ColorProgressBar.ColorProgressBar();
            this._Lbl_Por = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this._Txt_Unidades = new System.Windows.Forms.TextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this._Pnl_Clave.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_Detalle)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid.ContextMenuStrip = this.contextMenuStrip1;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(3, 24);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Size = new System.Drawing.Size(390, 204);
            this._Dg_Grid.TabIndex = 3;
            this._Dg_Grid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_CellMouseEnter);
            this._Dg_Grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarOCToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 26);
            // 
            // cerrarOCToolStripMenuItem
            // 
            this.cerrarOCToolStripMenuItem.Name = "cerrarOCToolStripMenuItem";
            this.cerrarOCToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.cerrarOCToolStripMenuItem.Text = "Cerrar O.C.";
            this.cerrarOCToolStripMenuItem.Click += new System.EventHandler(this.cerrarOCToolStripMenuItem_Click);
            // 
            // _Lb_Etiquea
            // 
            this._Lb_Etiquea.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._Lb_Etiquea.Dock = System.Windows.Forms.DockStyle.Top;
            this._Lb_Etiquea.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._Lb_Etiquea.Location = new System.Drawing.Point(3, 3);
            this._Lb_Etiquea.Name = "_Lb_Etiquea";
            this._Lb_Etiquea.Size = new System.Drawing.Size(390, 21);
            this._Lb_Etiquea.TabIndex = 10;
            this._Lb_Etiquea.Text = "Ordenes de Compra por cerrar";
            this._Lb_Etiquea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Tb_Tab
            // 
            this._Tb_Tab.Controls.Add(this.tabPage1);
            this._Tb_Tab.Controls.Add(this.tabPage2);
            this._Tb_Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Tb_Tab.Location = new System.Drawing.Point(0, 0);
            this._Tb_Tab.Name = "_Tb_Tab";
            this._Tb_Tab.SelectedIndex = 0;
            this._Tb_Tab.Size = new System.Drawing.Size(458, 313);
            this._Tb_Tab.TabIndex = 11;
            this._Tb_Tab.SelectedIndexChanged += new System.EventHandler(this._Tb_Tab_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._Pnl_Clave);
            this.tabPage1.Controls.Add(this._Dg_Grid);
            this.tabPage1.Controls.Add(this._Lb_Etiquea);
            this.tabPage1.Controls.Add(this._Lbl_DgInfo);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(396, 242);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _Pnl_Clave
            // 
            this._Pnl_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Clave.Controls.Add(this._Bt_Aceptar);
            this._Pnl_Clave.Controls.Add(this.label8);
            this._Pnl_Clave.Controls.Add(this.label9);
            this._Pnl_Clave.Controls.Add(this._Txt_Clave);
            this._Pnl_Clave.Controls.Add(this._Bt_Cancelar);
            this._Pnl_Clave.Controls.Add(this.label10);
            this._Pnl_Clave.Location = new System.Drawing.Point(97, 78);
            this._Pnl_Clave.Name = "_Pnl_Clave";
            this._Pnl_Clave.Size = new System.Drawing.Size(195, 103);
            this._Pnl_Clave.TabIndex = 72;
            this._Pnl_Clave.Visible = false;
            this._Pnl_Clave.VisibleChanged += new System.EventHandler(this._Pnl_Clave_VisibleChanged);
            // 
            // _Bt_Aceptar
            // 
            this._Bt_Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Bt_Aceptar.Location = new System.Drawing.Point(43, 74);
            this._Bt_Aceptar.Name = "_Bt_Aceptar";
            this._Bt_Aceptar.Size = new System.Drawing.Size(60, 22);
            this._Bt_Aceptar.TabIndex = 70;
            this._Bt_Aceptar.Text = "Aceptar";
            this._Bt_Aceptar.UseVisualStyleBackColor = true;
            this._Bt_Aceptar.Click += new System.EventHandler(this._Bt_Aceptar_Click);
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(0, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(193, 30);
            this.label8.TabIndex = 69;
            this.label8.Text = "¿Esta seguro de cerrar esta orden de compra?";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 12);
            this.label9.TabIndex = 68;
            this.label9.Text = "Clave:";
            // 
            // _Txt_Clave
            // 
            this._Txt_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Clave.Location = new System.Drawing.Point(51, 50);
            this._Txt_Clave.Name = "_Txt_Clave";
            this._Txt_Clave.PasswordChar = '*';
            this._Txt_Clave.Size = new System.Drawing.Size(112, 18);
            this._Txt_Clave.TabIndex = 2;
            // 
            // _Bt_Cancelar
            // 
            this._Bt_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Bt_Cancelar.Location = new System.Drawing.Point(109, 74);
            this._Bt_Cancelar.Name = "_Bt_Cancelar";
            this._Bt_Cancelar.Size = new System.Drawing.Size(60, 22);
            this._Bt_Cancelar.TabIndex = 1;
            this._Bt_Cancelar.Text = "Cancelar";
            this._Bt_Cancelar.UseVisualStyleBackColor = true;
            this._Bt_Cancelar.Click += new System.EventHandler(this._Bt_Cancelar_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Navy;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(193, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "Introduzca Clave";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(3, 228);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(390, 11);
            this._Lbl_DgInfo.TabIndex = 73;
            this._Lbl_DgInfo.Text = "Use doble click";
            this._Lbl_DgInfo.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this._Txt_Unidades);
            this.tabPage2.Controls.Add(this._Txt_Cajas);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this._Txt_Fecha);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this._Txt_Monto);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this._Txt_Proveedor);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this._Txt_OC);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(450, 288);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Dg_Grid_Detalle);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 134);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 110);
            this.panel1.TabIndex = 17;
            // 
            // _Dg_Grid_Detalle
            // 
            this._Dg_Grid_Detalle.AllowUserToAddRows = false;
            this._Dg_Grid_Detalle.AllowUserToDeleteRows = false;
            this._Dg_Grid_Detalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid_Detalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Unidades,
            this.Column3});
            this._Dg_Grid_Detalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid_Detalle.Location = new System.Drawing.Point(0, 21);
            this._Dg_Grid_Detalle.Name = "_Dg_Grid_Detalle";
            this._Dg_Grid_Detalle.ReadOnly = true;
            this._Dg_Grid_Detalle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid_Detalle.Size = new System.Drawing.Size(444, 89);
            this._Dg_Grid_Detalle.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(444, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Facturas";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Txt_Cajas
            // 
            this._Txt_Cajas.BackColor = System.Drawing.Color.White;
            this._Txt_Cajas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Cajas.Location = new System.Drawing.Point(75, 63);
            this._Txt_Cajas.Name = "_Txt_Cajas";
            this._Txt_Cajas.ReadOnly = true;
            this._Txt_Cajas.Size = new System.Drawing.Size(83, 18);
            this._Txt_Cajas.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "Cajas:";
            // 
            // _Txt_Fecha
            // 
            this._Txt_Fecha.BackColor = System.Drawing.Color.White;
            this._Txt_Fecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Fecha.Location = new System.Drawing.Point(223, 14);
            this._Txt_Fecha.Name = "_Txt_Fecha";
            this._Txt_Fecha.ReadOnly = true;
            this._Txt_Fecha.Size = new System.Drawing.Size(83, 18);
            this._Txt_Fecha.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "Fecha:";
            // 
            // _Txt_Monto
            // 
            this._Txt_Monto.BackColor = System.Drawing.Color.White;
            this._Txt_Monto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Monto.Location = new System.Drawing.Point(75, 88);
            this._Txt_Monto.Name = "_Txt_Monto";
            this._Txt_Monto.ReadOnly = true;
            this._Txt_Monto.Size = new System.Drawing.Size(154, 18);
            this._Txt_Monto.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "Monto:";
            // 
            // _Txt_Proveedor
            // 
            this._Txt_Proveedor.BackColor = System.Drawing.Color.White;
            this._Txt_Proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Proveedor.Location = new System.Drawing.Point(75, 39);
            this._Txt_Proveedor.Name = "_Txt_Proveedor";
            this._Txt_Proveedor.ReadOnly = true;
            this._Txt_Proveedor.Size = new System.Drawing.Size(291, 18);
            this._Txt_Proveedor.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Proveedor:";
            // 
            // _Txt_OC
            // 
            this._Txt_OC.BackColor = System.Drawing.Color.White;
            this._Txt_OC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_OC.Location = new System.Drawing.Point(75, 15);
            this._Txt_OC.Name = "_Txt_OC";
            this._Txt_OC.ReadOnly = true;
            this._Txt_OC.Size = new System.Drawing.Size(83, 18);
            this._Txt_OC.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "O.C.:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this._Pgb_Progress);
            this.groupBox1.Controls.Add(this._Lbl_Por);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 244);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 41);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Efectividad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(200, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 71;
            this.label7.Text = "%";
            // 
            // _Pgb_Progress
            // 
            this._Pgb_Progress.BarColor = System.Drawing.Color.AliceBlue;
            this._Pgb_Progress.BorderColor = System.Drawing.Color.Black;
            this._Pgb_Progress.FillStyle = ColorProgressBar.ColorProgressBar.FillStyles.Dashed;
            this._Pgb_Progress.Location = new System.Drawing.Point(10, 14);
            this._Pgb_Progress.Maximum = 100;
            this._Pgb_Progress.Minimum = 0;
            this._Pgb_Progress.Name = "_Pgb_Progress";
            this._Pgb_Progress.Size = new System.Drawing.Size(162, 18);
            this._Pgb_Progress.Step = 10;
            this._Pgb_Progress.TabIndex = 65;
            this._Pgb_Progress.Value = 0;
            // 
            // _Lbl_Por
            // 
            this._Lbl_Por.AutoSize = true;
            this._Lbl_Por.Location = new System.Drawing.Point(178, 19);
            this._Lbl_Por.Name = "_Lbl_Por";
            this._Lbl_Por.Size = new System.Drawing.Size(12, 12);
            this._Lbl_Por.TabIndex = 67;
            this._Lbl_Por.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(161, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 12);
            this.label11.TabIndex = 15;
            this.label11.Text = "Unidades:";
            // 
            // _Txt_Unidades
            // 
            this._Txt_Unidades.BackColor = System.Drawing.Color.White;
            this._Txt_Unidades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Unidades.Location = new System.Drawing.Point(223, 63);
            this._Txt_Unidades.Name = "_Txt_Unidades";
            this._Txt_Unidades.ReadOnly = true;
            this._Txt_Unidades.Size = new System.Drawing.Size(83, 18);
            this._Txt_Unidades.TabIndex = 16;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Facturas";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Cajas";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Unidades
            // 
            this.Unidades.HeaderText = "Unidades";
            this.Unidades.Name = "Unidades";
            this.Unidades.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Monto";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Frm_VistaGerente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 313);
            this.Controls.Add(this._Tb_Tab);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_VistaGerente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "O.C. por Cerrar";
            this.Load += new System.EventHandler(this.Frm_VistaGerente_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this._Pnl_Clave.ResumeLayout(false);
            this._Pnl_Clave.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_Detalle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cerrarOCToolStripMenuItem;
        private System.Windows.Forms.Label _Lb_Etiquea;
        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox _Txt_Fecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _Txt_Monto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _Txt_Proveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _Txt_OC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _Txt_Cajas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView _Dg_Grid_Detalle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private ColorProgressBar.ColorProgressBar _Pgb_Progress;
        private System.Windows.Forms.Label _Lbl_Por;
        private System.Windows.Forms.Panel _Pnl_Clave;
        private System.Windows.Forms.Button _Bt_Aceptar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox _Txt_Clave;
        private System.Windows.Forms.Button _Bt_Cancelar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label _Lbl_DgInfo;
        private System.Windows.Forms.TextBox _Txt_Unidades;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}