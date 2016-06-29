namespace T3
{
    partial class Frm_TransferMME
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_TransferMME));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this._Rbt_NoPro = new System.Windows.Forms.RadioButton();
            this._Rbt_Pro = new System.Windows.Forms.RadioButton();
            this._Ctrl_Busqueda1 = new T3.Controles._Ctrl_Busqueda();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._Bt_Procesar = new System.Windows.Forms.Button();
            this._Cmb_Salida = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Cmb_Entrada = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this._Txt_Costo = new System.Windows.Forms.TextBox();
            this._Txt_Descripcion = new System.Windows.Forms.TextBox();
            this._Cmb_Motivo = new System.Windows.Forms.ComboBox();
            this._Txt_Fecha = new System.Windows.Forms.TextBox();
            this._Txt_Numero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this._Dg_Grid2 = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Cntx_MenuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._Pnl_Clave = new System.Windows.Forms.Panel();
            this._Bt_Aceptar = new System.Windows.Forms.Button();
            this._Lbl_Descripcion = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this._Txt_Clave = new System.Windows.Forms.TextBox();
            this._Bt_Cancelar = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid2)).BeginInit();
            this._Cntx_MenuGrid.SuspendLayout();
            this._Pnl_Clave.SuspendLayout();
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
            this._Tb_Tab.Size = new System.Drawing.Size(539, 461);
            this._Tb_Tab.TabIndex = 8;
            this._Tb_Tab.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this._Tb_Tab_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._Dg_Grid);
            this.tabPage1.Controls.Add(this._Lbl_DgInfo);
            this.tabPage1.Controls.Add(this._Rbt_NoPro);
            this.tabPage1.Controls.Add(this._Rbt_Pro);
            this.tabPage1.Controls.Add(this._Ctrl_Busqueda1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(531, 436);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(3, 47);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.Size = new System.Drawing.Size(525, 375);
            this._Dg_Grid.TabIndex = 1;
            this._Dg_Grid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_CellMouseEnter);
            this._Dg_Grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseDoubleClick);
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(3, 422);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(525, 11);
            this._Lbl_DgInfo.TabIndex = 11;
            this._Lbl_DgInfo.Text = "Use doble click";
            this._Lbl_DgInfo.Visible = false;
            // 
            // _Rbt_NoPro
            // 
            this._Rbt_NoPro.AutoSize = true;
            this._Rbt_NoPro.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._Rbt_NoPro.Checked = true;
            this._Rbt_NoPro.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._Rbt_NoPro.Location = new System.Drawing.Point(256, 29);
            this._Rbt_NoPro.Name = "_Rbt_NoPro";
            this._Rbt_NoPro.Size = new System.Drawing.Size(99, 16);
            this._Rbt_NoPro.TabIndex = 10;
            this._Rbt_NoPro.TabStop = true;
            this._Rbt_NoPro.Text = "No Procesadas";
            this._Rbt_NoPro.UseVisualStyleBackColor = false;
            this._Rbt_NoPro.CheckedChanged += new System.EventHandler(this._Rbt_NoPro_CheckedChanged);
            // 
            // _Rbt_Pro
            // 
            this._Rbt_Pro.AutoSize = true;
            this._Rbt_Pro.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._Rbt_Pro.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._Rbt_Pro.Location = new System.Drawing.Point(176, 29);
            this._Rbt_Pro.Name = "_Rbt_Pro";
            this._Rbt_Pro.Size = new System.Drawing.Size(82, 16);
            this._Rbt_Pro.TabIndex = 9;
            this._Rbt_Pro.Text = "Procesadas";
            this._Rbt_Pro.UseVisualStyleBackColor = false;
            this._Rbt_Pro.CheckedChanged += new System.EventHandler(this._Rbt_Pro_CheckedChanged);
            // 
            // _Ctrl_Busqueda1
            // 
            this._Ctrl_Busqueda1.Dock = System.Windows.Forms.DockStyle.Top;
            this._Ctrl_Busqueda1.Location = new System.Drawing.Point(3, 3);
            this._Ctrl_Busqueda1.Name = "_Ctrl_Busqueda1";
            this._Ctrl_Busqueda1.Size = new System.Drawing.Size(525, 44);
            this._Ctrl_Busqueda1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._Bt_Procesar);
            this.tabPage2.Controls.Add(this._Cmb_Salida);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this._Cmb_Entrada);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this._Txt_Costo);
            this.tabPage2.Controls.Add(this._Txt_Descripcion);
            this.tabPage2.Controls.Add(this._Cmb_Motivo);
            this.tabPage2.Controls.Add(this._Txt_Fecha);
            this.tabPage2.Controls.Add(this._Txt_Numero);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this._Dg_Grid2);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(531, 436);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _Bt_Procesar
            // 
            this._Bt_Procesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Procesar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Procesar.Image")));
            this._Bt_Procesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Procesar.Location = new System.Drawing.Point(362, 406);
            this._Bt_Procesar.Name = "_Bt_Procesar";
            this._Bt_Procesar.Size = new System.Drawing.Size(160, 25);
            this._Bt_Procesar.TabIndex = 65;
            this._Bt_Procesar.Text = "Procesar transferencia";
            this._Bt_Procesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Procesar.UseVisualStyleBackColor = true;
            this._Bt_Procesar.Click += new System.EventHandler(this._Bt_Procesar_Click);
            // 
            // _Cmb_Salida
            // 
            this._Cmb_Salida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Salida.Enabled = false;
            this._Cmb_Salida.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Cmb_Salida.FormattingEnabled = true;
            this._Cmb_Salida.Location = new System.Drawing.Point(9, 52);
            this._Cmb_Salida.Name = "_Cmb_Salida";
            this._Cmb_Salida.Size = new System.Drawing.Size(516, 20);
            this._Cmb_Salida.TabIndex = 63;
            this._Cmb_Salida.DropDown += new System.EventHandler(this._Cmb_Salida_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 12);
            this.label1.TabIndex = 64;
            this.label1.Text = "Almacén de Salida";
            // 
            // _Cmb_Entrada
            // 
            this._Cmb_Entrada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Entrada.Enabled = false;
            this._Cmb_Entrada.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Cmb_Entrada.FormattingEnabled = true;
            this._Cmb_Entrada.Location = new System.Drawing.Point(9, 88);
            this._Cmb_Entrada.Name = "_Cmb_Entrada";
            this._Cmb_Entrada.Size = new System.Drawing.Size(516, 20);
            this._Cmb_Entrada.TabIndex = 61;
            this._Cmb_Entrada.DropDown += new System.EventHandler(this._Cmb_Entrada_DropDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 12);
            this.label4.TabIndex = 62;
            this.label4.Text = "Almacén de Entrada";
            // 
            // _Txt_Costo
            // 
            this._Txt_Costo.BackColor = System.Drawing.Color.White;
            this._Txt_Costo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Costo.Enabled = false;
            this._Txt_Costo.Location = new System.Drawing.Point(7, 414);
            this._Txt_Costo.Name = "_Txt_Costo";
            this._Txt_Costo.ReadOnly = true;
            this._Txt_Costo.Size = new System.Drawing.Size(122, 18);
            this._Txt_Costo.TabIndex = 47;
            this._Txt_Costo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _Txt_Descripcion
            // 
            this._Txt_Descripcion.BackColor = System.Drawing.Color.White;
            this._Txt_Descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Descripcion.Enabled = false;
            this._Txt_Descripcion.Location = new System.Drawing.Point(6, 162);
            this._Txt_Descripcion.Name = "_Txt_Descripcion";
            this._Txt_Descripcion.Size = new System.Drawing.Size(516, 18);
            this._Txt_Descripcion.TabIndex = 3;
            // 
            // _Cmb_Motivo
            // 
            this._Cmb_Motivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Motivo.Enabled = false;
            this._Cmb_Motivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Cmb_Motivo.FormattingEnabled = true;
            this._Cmb_Motivo.Location = new System.Drawing.Point(9, 16);
            this._Cmb_Motivo.Name = "_Cmb_Motivo";
            this._Cmb_Motivo.Size = new System.Drawing.Size(516, 20);
            this._Cmb_Motivo.TabIndex = 11;
            this._Cmb_Motivo.DropDown += new System.EventHandler(this._Cmb_Motivo_DropDown);
            // 
            // _Txt_Fecha
            // 
            this._Txt_Fecha.BackColor = System.Drawing.Color.White;
            this._Txt_Fecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Fecha.Enabled = false;
            this._Txt_Fecha.Location = new System.Drawing.Point(60, 127);
            this._Txt_Fecha.Name = "_Txt_Fecha";
            this._Txt_Fecha.ReadOnly = true;
            this._Txt_Fecha.Size = new System.Drawing.Size(63, 18);
            this._Txt_Fecha.TabIndex = 9;
            // 
            // _Txt_Numero
            // 
            this._Txt_Numero.BackColor = System.Drawing.Color.White;
            this._Txt_Numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Numero.Enabled = false;
            this._Txt_Numero.Location = new System.Drawing.Point(9, 127);
            this._Txt_Numero.Name = "_Txt_Numero";
            this._Txt_Numero.ReadOnly = true;
            this._Txt_Numero.Size = new System.Drawing.Size(45, 18);
            this._Txt_Numero.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 400);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 12);
            this.label2.TabIndex = 57;
            this.label2.Text = "Total Costo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 53;
            this.label6.Text = "Descripción:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(58, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 12);
            this.label8.TabIndex = 56;
            this.label8.Text = "Fecha:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 12);
            this.label9.TabIndex = 52;
            this.label9.Text = "Id:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 12);
            this.label10.TabIndex = 55;
            this.label10.Text = "Motivo:";
            // 
            // _Dg_Grid2
            // 
            this._Dg_Grid2.AllowUserToAddRows = false;
            this._Dg_Grid2.AllowUserToDeleteRows = false;
            this._Dg_Grid2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._Dg_Grid2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this._Dg_Grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column14,
            this.Column15,
            this.Column9,
            this.Column10});
            this._Dg_Grid2.ContextMenuStrip = this._Cntx_MenuGrid;
            this._Dg_Grid2.Location = new System.Drawing.Point(7, 185);
            this._Dg_Grid2.Name = "_Dg_Grid2";
            this._Dg_Grid2.Size = new System.Drawing.Size(516, 212);
            this._Dg_Grid2.TabIndex = 46;
            this._Dg_Grid2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid2_CellValueChanged);
            this._Dg_Grid2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid2_CellEndEdit);
            this._Dg_Grid2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid2_CellClick);
            this._Dg_Grid2.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this._Dg_Grid2_EditingControlShowing);
            this._Dg_Grid2.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid2_CellEnter);
            // 
            // Column8
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column8.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column8.HeaderText = "Producto";
            this.Column8.Name = "Column8";
            this.Column8.Width = 75;
            // 
            // Column14
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Column14.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column14.HeaderText = "...";
            this.Column14.Name = "Column14";
            this.Column14.Width = 20;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "Descripción";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Width = 90;
            // 
            // Column9
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Column9.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column9.HeaderText = "Cajas";
            this.Column9.MaxInputLength = 9;
            this.Column9.Name = "Column9";
            this.Column9.Width = 59;
            // 
            // Column10
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Column10.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column10.HeaderText = "Unidades";
            this.Column10.MaxInputLength = 9;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 77;
            // 
            // _Cntx_MenuGrid
            // 
            this._Cntx_MenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarToolStripMenuItem});
            this._Cntx_MenuGrid.Name = "_Cntx_Menu";
            this._Cntx_MenuGrid.Size = new System.Drawing.Size(122, 26);
            this._Cntx_MenuGrid.Opening += new System.ComponentModel.CancelEventHandler(this._Cntx_MenuGrid_Opening);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // _Pnl_Clave
            // 
            this._Pnl_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Clave.Controls.Add(this._Bt_Aceptar);
            this._Pnl_Clave.Controls.Add(this._Lbl_Descripcion);
            this._Pnl_Clave.Controls.Add(this.label12);
            this._Pnl_Clave.Controls.Add(this._Txt_Clave);
            this._Pnl_Clave.Controls.Add(this._Bt_Cancelar);
            this._Pnl_Clave.Controls.Add(this.label13);
            this._Pnl_Clave.Location = new System.Drawing.Point(204, 155);
            this._Pnl_Clave.Name = "_Pnl_Clave";
            this._Pnl_Clave.Size = new System.Drawing.Size(154, 98);
            this._Pnl_Clave.TabIndex = 79;
            this._Pnl_Clave.Visible = false;
            this._Pnl_Clave.VisibleChanged += new System.EventHandler(this._Pnl_Clave_VisibleChanged);
            // 
            // _Bt_Aceptar
            // 
            this._Bt_Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Aceptar.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Aceptar.Location = new System.Drawing.Point(10, 65);
            this._Bt_Aceptar.Name = "_Bt_Aceptar";
            this._Bt_Aceptar.Size = new System.Drawing.Size(65, 28);
            this._Bt_Aceptar.TabIndex = 70;
            this._Bt_Aceptar.Text = "Aceptar";
            this._Bt_Aceptar.UseVisualStyleBackColor = true;
            this._Bt_Aceptar.Click += new System.EventHandler(this._Bt_Aceptar_Click);
            // 
            // _Lbl_Descripcion
            // 
            this._Lbl_Descripcion.Dock = System.Windows.Forms.DockStyle.Top;
            this._Lbl_Descripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_Descripcion.ForeColor = System.Drawing.Color.Black;
            this._Lbl_Descripcion.Location = new System.Drawing.Point(0, 18);
            this._Lbl_Descripcion.Name = "_Lbl_Descripcion";
            this._Lbl_Descripcion.Size = new System.Drawing.Size(152, 23);
            this._Lbl_Descripcion.TabIndex = 69;
            this._Lbl_Descripcion.Text = "¿Esta seguro de seleccionar este Producto?";
            this._Lbl_Descripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 12);
            this.label12.TabIndex = 68;
            this.label12.Text = "Clave:";
            // 
            // _Txt_Clave
            // 
            this._Txt_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Clave.Location = new System.Drawing.Point(50, 44);
            this._Txt_Clave.Name = "_Txt_Clave";
            this._Txt_Clave.PasswordChar = '*';
            this._Txt_Clave.Size = new System.Drawing.Size(95, 18);
            this._Txt_Clave.TabIndex = 2;
            // 
            // _Bt_Cancelar
            // 
            this._Bt_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Cancelar.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Cancelar.Location = new System.Drawing.Point(81, 65);
            this._Bt_Cancelar.Name = "_Bt_Cancelar";
            this._Bt_Cancelar.Size = new System.Drawing.Size(64, 28);
            this._Bt_Cancelar.TabIndex = 1;
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
            this.label13.Size = new System.Drawing.Size(152, 18);
            this.label13.TabIndex = 0;
            this.label13.Text = "Introduzca Clave";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // Frm_TransferMME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 461);
            this.Controls.Add(this._Pnl_Clave);
            this.Controls.Add(this._Tb_Tab);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_TransferMME";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferencia de Mercancía en mal estado";
            this.Load += new System.EventHandler(this.Frm_TransferMME_Load);
            this.Activated += new System.EventHandler(this.Frm_TransferMME_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_TransferMME_FormClosing);
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid2)).EndInit();
            this._Cntx_MenuGrid.ResumeLayout(false);
            this._Pnl_Clave.ResumeLayout(false);
            this._Pnl_Clave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private T3.Controles._Ctrl_Busqueda _Ctrl_Busqueda1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox _Txt_Costo;
        private System.Windows.Forms.TextBox _Txt_Descripcion;
        private System.Windows.Forms.ComboBox _Cmb_Motivo;
        private System.Windows.Forms.TextBox _Txt_Fecha;
        private System.Windows.Forms.TextBox _Txt_Numero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView _Dg_Grid2;
        private System.Windows.Forms.Panel _Pnl_Clave;
        private System.Windows.Forms.Button _Bt_Aceptar;
        private System.Windows.Forms.Label _Lbl_Descripcion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox _Txt_Clave;
        private System.Windows.Forms.Button _Bt_Cancelar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox _Cmb_Salida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _Cmb_Entrada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.Button _Bt_Procesar;
        private System.Windows.Forms.RadioButton _Rbt_NoPro;
        private System.Windows.Forms.RadioButton _Rbt_Pro;
        private System.Windows.Forms.Label _Lbl_DgInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewButtonColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.ContextMenuStrip _Cntx_MenuGrid;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
    }
}