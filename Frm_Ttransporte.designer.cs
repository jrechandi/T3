namespace T3
{
    partial class Frm_Ttransporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Ttransporte));
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this._Ctrl_Busqueda1 = new T3.Controles._Ctrl_Busqueda();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._Rbt_Externo = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._Txt_Capacidad = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this._Txt_Alto = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this._Txt_Profundidad = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this._Txt_Ancho = new System.Windows.Forms.TextBox();
            this._Rbt_Mosanca = new System.Windows.Forms.RadioButton();
            this._Txt_Año = new System.Windows.Forms.TextBox();
            this._Txt_Color = new System.Windows.Forms.TextBox();
            this._Txt_Modelo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._Cmb_Tipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._Txt_Placa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._Txt_Marca = new System.Windows.Forms.TextBox();
            this._Bt_Transportista = new System.Windows.Forms.Button();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Tt_A = new System.Windows.Forms.ToolTip(this.components);
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
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
            this._Tb_Tab.Size = new System.Drawing.Size(369, 288);
            this._Tb_Tab.TabIndex = 3;
            this._Tb_Tab.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this._Tb_Tab_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._Dg_Grid);
            this.tabPage1.Controls.Add(this._Lbl_DgInfo);
            this.tabPage1.Controls.Add(this._Ctrl_Busqueda1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(361, 263);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Dg_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(3, 47);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Size = new System.Drawing.Size(355, 201);
            this._Dg_Grid.TabIndex = 1;
            this._Dg_Grid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_CellMouseEnter);
            this._Dg_Grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseDoubleClick);
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(3, 248);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(355, 12);
            this._Lbl_DgInfo.TabIndex = 5;
            this._Lbl_DgInfo.Text = "Use doble click";
            this._Lbl_DgInfo.Visible = false;
            // 
            // _Ctrl_Busqueda1
            // 
            this._Ctrl_Busqueda1.Dock = System.Windows.Forms.DockStyle.Top;
            this._Ctrl_Busqueda1.Location = new System.Drawing.Point(3, 3);
            this._Ctrl_Busqueda1.Name = "_Ctrl_Busqueda1";
            this._Ctrl_Busqueda1.Size = new System.Drawing.Size(355, 44);
            this._Ctrl_Busqueda1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._Rbt_Externo);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this._Rbt_Mosanca);
            this.tabPage2.Controls.Add(this._Txt_Año);
            this.tabPage2.Controls.Add(this._Txt_Color);
            this.tabPage2.Controls.Add(this._Txt_Modelo);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this._Cmb_Tipo);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this._Txt_Placa);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this._Txt_Marca);
            this.tabPage2.Controls.Add(this._Bt_Transportista);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(361, 263);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _Rbt_Externo
            // 
            this._Rbt_Externo.AutoSize = true;
            this._Rbt_Externo.Enabled = false;
            this._Rbt_Externo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Rbt_Externo.Location = new System.Drawing.Point(207, 222);
            this._Rbt_Externo.Name = "_Rbt_Externo";
            this._Rbt_Externo.Size = new System.Drawing.Size(119, 16);
            this._Rbt_Externo.TabIndex = 11;
            this._Rbt_Externo.TabStop = true;
            this._Rbt_Externo.Text = "Transporte Externo";
            this._Rbt_Externo.UseVisualStyleBackColor = true;
            this._Rbt_Externo.CheckedChanged += new System.EventHandler(this._Rbt_Externo_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this._Txt_Capacidad);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this._Txt_Alto);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this._Txt_Profundidad);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this._Txt_Ancho);
            this.groupBox1.Location = new System.Drawing.Point(210, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 167);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles de la cava";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(85, 143);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 15);
            this.label14.TabIndex = 24;
            this.label14.Text = "Kg";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "Alto:";
            // 
            // _Txt_Capacidad
            // 
            this._Txt_Capacidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Capacidad.Enabled = false;
            this._Txt_Capacidad.Location = new System.Drawing.Point(16, 140);
            this._Txt_Capacidad.MaxLength = 9;
            this._Txt_Capacidad.Name = "_Txt_Capacidad";
            this._Txt_Capacidad.Size = new System.Drawing.Size(63, 18);
            this._Txt_Capacidad.TabIndex = 9;
            this._Txt_Capacidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(85, 105);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 15);
            this.label13.TabIndex = 23;
            this.label13.Text = "Mts";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "Capacidad:";
            // 
            // _Txt_Alto
            // 
            this._Txt_Alto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Alto.Enabled = false;
            this._Txt_Alto.Location = new System.Drawing.Point(16, 33);
            this._Txt_Alto.MaxLength = 4;
            this._Txt_Alto.Name = "_Txt_Alto";
            this._Txt_Alto.Size = new System.Drawing.Size(63, 18);
            this._Txt_Alto.TabIndex = 6;
            this._Txt_Alto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(85, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 15);
            this.label12.TabIndex = 22;
            this.label12.Text = "Mts";
            // 
            // _Txt_Profundidad
            // 
            this._Txt_Profundidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Profundidad.Enabled = false;
            this._Txt_Profundidad.Location = new System.Drawing.Point(16, 103);
            this._Txt_Profundidad.MaxLength = 4;
            this._Txt_Profundidad.Name = "_Txt_Profundidad";
            this._Txt_Profundidad.Size = new System.Drawing.Size(63, 18);
            this._Txt_Profundidad.TabIndex = 8;
            this._Txt_Profundidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(85, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 15);
            this.label11.TabIndex = 21;
            this.label11.Text = "Mts";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "Ancho:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "Profundidad:";
            // 
            // _Txt_Ancho
            // 
            this._Txt_Ancho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Ancho.Enabled = false;
            this._Txt_Ancho.Location = new System.Drawing.Point(16, 65);
            this._Txt_Ancho.MaxLength = 4;
            this._Txt_Ancho.Name = "_Txt_Ancho";
            this._Txt_Ancho.Size = new System.Drawing.Size(63, 18);
            this._Txt_Ancho.TabIndex = 7;
            this._Txt_Ancho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _Rbt_Mosanca
            // 
            this._Rbt_Mosanca.AutoSize = true;
            this._Rbt_Mosanca.Enabled = false;
            this._Rbt_Mosanca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Rbt_Mosanca.Location = new System.Drawing.Point(207, 200);
            this._Rbt_Mosanca.Name = "_Rbt_Mosanca";
            this._Rbt_Mosanca.Size = new System.Drawing.Size(123, 16);
            this._Rbt_Mosanca.TabIndex = 10;
            this._Rbt_Mosanca.TabStop = true;
            this._Rbt_Mosanca.Text = "Transportes Interno";
            this._Rbt_Mosanca.UseVisualStyleBackColor = true;
            this._Rbt_Mosanca.CheckedChanged += new System.EventHandler(this._Rbt_Mosanca_CheckedChanged);
            // 
            // _Txt_Año
            // 
            this._Txt_Año.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Año.Enabled = false;
            this._Txt_Año.Location = new System.Drawing.Point(10, 210);
            this._Txt_Año.MaxLength = 4;
            this._Txt_Año.Name = "_Txt_Año";
            this._Txt_Año.Size = new System.Drawing.Size(178, 18);
            this._Txt_Año.TabIndex = 5;
            this._Txt_Año.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Txt_Año.TextChanged += new System.EventHandler(this._Txt_Año_TextChanged);
            this._Txt_Año.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Año_KeyPress);
            // 
            // _Txt_Color
            // 
            this._Txt_Color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Color.Enabled = false;
            this._Txt_Color.Location = new System.Drawing.Point(10, 135);
            this._Txt_Color.MaxLength = 30;
            this._Txt_Color.Name = "_Txt_Color";
            this._Txt_Color.Size = new System.Drawing.Size(178, 18);
            this._Txt_Color.TabIndex = 3;
            // 
            // _Txt_Modelo
            // 
            this._Txt_Modelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Modelo.Enabled = false;
            this._Txt_Modelo.Location = new System.Drawing.Point(10, 99);
            this._Txt_Modelo.MaxLength = 30;
            this._Txt_Modelo.Name = "_Txt_Modelo";
            this._Txt_Modelo.Size = new System.Drawing.Size(178, 18);
            this._Txt_Modelo.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "Año:";
            // 
            // _Cmb_Tipo
            // 
            this._Cmb_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Tipo.Enabled = false;
            this._Cmb_Tipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Tipo.FormattingEnabled = true;
            this._Cmb_Tipo.Location = new System.Drawing.Point(10, 171);
            this._Cmb_Tipo.Name = "_Cmb_Tipo";
            this._Cmb_Tipo.Size = new System.Drawing.Size(178, 20);
            this._Cmb_Tipo.TabIndex = 4;
            this._Cmb_Tipo.DropDown += new System.EventHandler(this._Cmb_Tipo_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Placa:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tipo:";
            // 
            // _Txt_Placa
            // 
            this._Txt_Placa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Placa.Enabled = false;
            this._Txt_Placa.Location = new System.Drawing.Point(10, 27);
            this._Txt_Placa.MaxLength = 20;
            this._Txt_Placa.Name = "_Txt_Placa";
            this._Txt_Placa.Size = new System.Drawing.Size(86, 18);
            this._Txt_Placa.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Color:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Marca:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Modelo:";
            // 
            // _Txt_Marca
            // 
            this._Txt_Marca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Marca.Enabled = false;
            this._Txt_Marca.Location = new System.Drawing.Point(10, 63);
            this._Txt_Marca.MaxLength = 30;
            this._Txt_Marca.Name = "_Txt_Marca";
            this._Txt_Marca.Size = new System.Drawing.Size(178, 18);
            this._Txt_Marca.TabIndex = 1;
            // 
            // _Bt_Transportista
            // 
            this._Bt_Transportista.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Transportista.FlatAppearance.BorderSize = 0;
            this._Bt_Transportista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Transportista.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Transportista.Image")));
            this._Bt_Transportista.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Transportista.Location = new System.Drawing.Point(10, 234);
            this._Bt_Transportista.Name = "_Bt_Transportista";
            this._Bt_Transportista.Size = new System.Drawing.Size(103, 25);
            this._Bt_Transportista.TabIndex = 10;
            this._Bt_Transportista.Text = "Transportista";
            this._Bt_Transportista.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Transportista.UseVisualStyleBackColor = true;
            this._Bt_Transportista.Click += new System.EventHandler(this._Bt_Transportista_Click);
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // Frm_Ttransporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 288);
            this.Controls.Add(this._Tb_Tab);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Ttransporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transporte";
            this.Load += new System.EventHandler(this.Frm_Ttransporte_Load);
            this.Activated += new System.EventHandler(this.Frm_Ttransporte_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Ttransporte_FormClosing);
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox _Txt_Marca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _Txt_Placa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox _Cmb_Tipo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _Txt_Año;
        private System.Windows.Forms.TextBox _Txt_Color;
        private System.Windows.Forms.TextBox _Txt_Modelo;
        private System.Windows.Forms.RadioButton _Rbt_Mosanca;
        private System.Windows.Forms.RadioButton _Rbt_Externo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _Txt_Capacidad;
        private System.Windows.Forms.TextBox _Txt_Profundidad;
        private System.Windows.Forms.TextBox _Txt_Ancho;
        private System.Windows.Forms.TextBox _Txt_Alto;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button _Bt_Transportista;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private T3.Controles._Ctrl_Busqueda _Ctrl_Busqueda1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip _Tt_A;
        private System.Windows.Forms.Label _Lbl_DgInfo;
    }
}