namespace T3
{
    partial class Frm_RutaDespacho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_RutaDespacho));
            this.label1 = new System.Windows.Forms.Label();
            this._Txt_Ruta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Txt_Descripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._Txt_Km = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Grb_Arriba = new System.Windows.Forms.GroupBox();
            this._Bt_Agregar = new System.Windows.Forms.Button();
            this._Cmb_Ciudad = new System.Windows.Forms.ComboBox();
            this._Cmb_Estado = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this._Bt_Eliminar = new System.Windows.Forms.Button();
            this._Bt_Bajar = new System.Windows.Forms.Button();
            this._Bt_Subir = new System.Windows.Forms.Button();
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this._Dg_Detalle = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Pnl_Derecho = new System.Windows.Forms.Panel();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Ctrl_Busqueda1 = new T3.Controles._Ctrl_Busqueda();
            this.panel1.SuspendLayout();
            this._Grb_Arriba.SuspendLayout();
            this._Tb_Tab.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Detalle)).BeginInit();
            this._Pnl_Derecho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ruta:";
            // 
            // _Txt_Ruta
            // 
            this._Txt_Ruta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Ruta.Enabled = false;
            this._Txt_Ruta.Location = new System.Drawing.Point(21, 24);
            this._Txt_Ruta.Name = "_Txt_Ruta";
            this._Txt_Ruta.ReadOnly = true;
            this._Txt_Ruta.Size = new System.Drawing.Size(68, 18);
            this._Txt_Ruta.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(95, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripción:";
            // 
            // _Txt_Descripcion
            // 
            this._Txt_Descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Descripcion.Enabled = false;
            this._Txt_Descripcion.Location = new System.Drawing.Point(97, 24);
            this._Txt_Descripcion.Name = "_Txt_Descripcion";
            this._Txt_Descripcion.Size = new System.Drawing.Size(306, 18);
            this._Txt_Descripcion.TabIndex = 3;
            this.toolTip1.SetToolTip(this._Txt_Descripcion, "Descripción de la Ruta de Despacho..");
            this._Txt_Descripcion.TextChanged += new System.EventHandler(this._Txt_Descripcion_TextChanged);
            this._Txt_Descripcion.Leave += new System.EventHandler(this._Txt_Descripcion_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(422, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Km. aprox.";
            // 
            // _Txt_Km
            // 
            this._Txt_Km.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Km.Enabled = false;
            this._Txt_Km.Location = new System.Drawing.Point(424, 24);
            this._Txt_Km.Name = "_Txt_Km";
            this._Txt_Km.Size = new System.Drawing.Size(68, 18);
            this._Txt_Km.TabIndex = 5;
            this._Txt_Km.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this._Txt_Km, "Kilomtros a recorrer..");
            this._Txt_Km.TextChanged += new System.EventHandler(this._Txt_Km_TextChanged);
            this._Txt_Km.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Km_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._Txt_Km);
            this.panel1.Controls.Add(this._Txt_Ruta);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._Txt_Descripcion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 53);
            this.panel1.TabIndex = 6;
            // 
            // _Grb_Arriba
            // 
            this._Grb_Arriba.Controls.Add(this._Bt_Agregar);
            this._Grb_Arriba.Controls.Add(this._Cmb_Ciudad);
            this._Grb_Arriba.Controls.Add(this._Cmb_Estado);
            this._Grb_Arriba.Controls.Add(this.label5);
            this._Grb_Arriba.Controls.Add(this.label4);
            this._Grb_Arriba.Dock = System.Windows.Forms.DockStyle.Top;
            this._Grb_Arriba.Enabled = false;
            this._Grb_Arriba.Location = new System.Drawing.Point(3, 56);
            this._Grb_Arriba.Name = "_Grb_Arriba";
            this._Grb_Arriba.Size = new System.Drawing.Size(516, 58);
            this._Grb_Arriba.TabIndex = 0;
            this._Grb_Arriba.TabStop = false;
            // 
            // _Bt_Agregar
            // 
            this._Bt_Agregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Agregar.FlatAppearance.BorderSize = 0;
            this._Bt_Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Agregar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Agregar.Image")));
            this._Bt_Agregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Agregar.Location = new System.Drawing.Point(435, 27);
            this._Bt_Agregar.Name = "_Bt_Agregar";
            this._Bt_Agregar.Size = new System.Drawing.Size(69, 23);
            this._Bt_Agregar.TabIndex = 1;
            this._Bt_Agregar.Text = "Agregar";
            this._Bt_Agregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this._Bt_Agregar, "Agregar poblado..");
            this._Bt_Agregar.UseVisualStyleBackColor = true;
            this._Bt_Agregar.Click += new System.EventHandler(this._Bt_Agregar_Click);
            // 
            // _Cmb_Ciudad
            // 
            this._Cmb_Ciudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Ciudad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Ciudad.FormattingEnabled = true;
            this._Cmb_Ciudad.Location = new System.Drawing.Point(221, 29);
            this._Cmb_Ciudad.Name = "_Cmb_Ciudad";
            this._Cmb_Ciudad.Size = new System.Drawing.Size(194, 20);
            this._Cmb_Ciudad.TabIndex = 7;
            this.toolTip1.SetToolTip(this._Cmb_Ciudad, "Elija la Ciudad..");
            this._Cmb_Ciudad.DropDown += new System.EventHandler(this._Cmb_Ciudad_DropDown);
            // 
            // _Cmb_Estado
            // 
            this._Cmb_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Estado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Estado.FormattingEnabled = true;
            this._Cmb_Estado.Location = new System.Drawing.Point(8, 29);
            this._Cmb_Estado.Name = "_Cmb_Estado";
            this._Cmb_Estado.Size = new System.Drawing.Size(194, 20);
            this._Cmb_Estado.TabIndex = 1;
            this.toolTip1.SetToolTip(this._Cmb_Estado, "Elija el Estado..");
            this._Cmb_Estado.SelectedIndexChanged += new System.EventHandler(this._Cmb_Estado_SelectedIndexChanged);
            this._Cmb_Estado.DropDown += new System.EventHandler(this._Cmb_Estado_DropDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(219, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ciudad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Estado:";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.IsBalloon = true;
            // 
            // _Bt_Eliminar
            // 
            this._Bt_Eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Eliminar.FlatAppearance.BorderSize = 0;
            this._Bt_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Eliminar.Image")));
            this._Bt_Eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Eliminar.Location = new System.Drawing.Point(5, 6);
            this._Bt_Eliminar.Name = "_Bt_Eliminar";
            this._Bt_Eliminar.Size = new System.Drawing.Size(27, 23);
            this._Bt_Eliminar.TabIndex = 11;
            this._Bt_Eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this._Bt_Eliminar, "Eliminar poblado..");
            this._Bt_Eliminar.UseVisualStyleBackColor = true;
            this._Bt_Eliminar.Click += new System.EventHandler(this._Bt_Eliminar_Click);
            // 
            // _Bt_Bajar
            // 
            this._Bt_Bajar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Bajar.FlatAppearance.BorderSize = 0;
            this._Bt_Bajar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Bajar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Bajar.Image")));
            this._Bt_Bajar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Bajar.Location = new System.Drawing.Point(5, 163);
            this._Bt_Bajar.Name = "_Bt_Bajar";
            this._Bt_Bajar.Size = new System.Drawing.Size(27, 23);
            this._Bt_Bajar.TabIndex = 10;
            this._Bt_Bajar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this._Bt_Bajar, "Bajar..");
            this._Bt_Bajar.UseVisualStyleBackColor = true;
            this._Bt_Bajar.Click += new System.EventHandler(this._Bt_Bajar_Click);
            // 
            // _Bt_Subir
            // 
            this._Bt_Subir.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Subir.FlatAppearance.BorderSize = 0;
            this._Bt_Subir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Subir.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Subir.Image")));
            this._Bt_Subir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Subir.Location = new System.Drawing.Point(5, 134);
            this._Bt_Subir.Name = "_Bt_Subir";
            this._Bt_Subir.Size = new System.Drawing.Size(27, 23);
            this._Bt_Subir.TabIndex = 9;
            this._Bt_Subir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this._Bt_Subir, "Subir..");
            this._Bt_Subir.UseVisualStyleBackColor = true;
            this._Bt_Subir.Click += new System.EventHandler(this._Bt_Subir_Click);
            // 
            // _Tb_Tab
            // 
            this._Tb_Tab.Controls.Add(this.tabPage2);
            this._Tb_Tab.Controls.Add(this.tabPage3);
            this._Tb_Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Tb_Tab.Location = new System.Drawing.Point(0, 0);
            this._Tb_Tab.Name = "_Tb_Tab";
            this._Tb_Tab.SelectedIndex = 0;
            this._Tb_Tab.Size = new System.Drawing.Size(530, 510);
            this._Tb_Tab.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._Dg_Grid);
            this.tabPage2.Controls.Add(this._Lbl_DgInfo);
            this.tabPage2.Controls.Add(this._Ctrl_Busqueda1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(522, 485);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Consulta";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Dg_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(3, 44);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Size = new System.Drawing.Size(516, 426);
            this._Dg_Grid.TabIndex = 0;
            this._Dg_Grid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_CellMouseEnter);
            this._Dg_Grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseDoubleClick);
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(3, 470);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(516, 12);
            this._Lbl_DgInfo.TabIndex = 6;
            this._Lbl_DgInfo.Text = "Use doble click";
            this._Lbl_DgInfo.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Controls.Add(this._Grb_Arriba);
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(522, 485);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Detalle";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._Dg_Detalle);
            this.panel3.Controls.Add(this._Pnl_Derecho);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 114);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(516, 368);
            this.panel3.TabIndex = 7;
            // 
            // _Dg_Detalle
            // 
            this._Dg_Detalle.AllowUserToAddRows = false;
            this._Dg_Detalle.AllowUserToDeleteRows = false;
            this._Dg_Detalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Dg_Detalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Detalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5,
            this.Estado,
            this.Ciudad});
            this._Dg_Detalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Detalle.Location = new System.Drawing.Point(0, 0);
            this._Dg_Detalle.MultiSelect = false;
            this._Dg_Detalle.Name = "_Dg_Detalle";
            this._Dg_Detalle.ReadOnly = true;
            this._Dg_Detalle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Detalle.Size = new System.Drawing.Size(479, 368);
            this._Dg_Detalle.TabIndex = 5;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Estado";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Ciudad";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Prioridad";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Column1";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Visible = false;
            // 
            // Ciudad
            // 
            this.Ciudad.HeaderText = "Column1";
            this.Ciudad.Name = "Ciudad";
            this.Ciudad.ReadOnly = true;
            this.Ciudad.Visible = false;
            // 
            // _Pnl_Derecho
            // 
            this._Pnl_Derecho.Controls.Add(this._Bt_Eliminar);
            this._Pnl_Derecho.Controls.Add(this._Bt_Bajar);
            this._Pnl_Derecho.Controls.Add(this._Bt_Subir);
            this._Pnl_Derecho.Dock = System.Windows.Forms.DockStyle.Right;
            this._Pnl_Derecho.Enabled = false;
            this._Pnl_Derecho.Location = new System.Drawing.Point(479, 0);
            this._Pnl_Derecho.Name = "_Pnl_Derecho";
            this._Pnl_Derecho.Size = new System.Drawing.Size(37, 368);
            this._Pnl_Derecho.TabIndex = 6;
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // _Ctrl_Busqueda1
            // 
            this._Ctrl_Busqueda1.Dock = System.Windows.Forms.DockStyle.Top;
            this._Ctrl_Busqueda1.Location = new System.Drawing.Point(3, 3);
            this._Ctrl_Busqueda1.Name = "_Ctrl_Busqueda1";
            this._Ctrl_Busqueda1.Size = new System.Drawing.Size(516, 41);
            this._Ctrl_Busqueda1.TabIndex = 3;
            // 
            // Frm_RutaDespacho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(530, 510);
            this.Controls.Add(this._Tb_Tab);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_RutaDespacho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ruta de despacho";
            this.toolTip1.SetToolTip(this, "Ruta de despacho..");
            this.Load += new System.EventHandler(this.Frm_RutaDespacho_Load);
            this.Activated += new System.EventHandler(this.Frm_RutaDespacho_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_RutaDespacho_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._Grb_Arriba.ResumeLayout(false);
            this._Grb_Arriba.PerformLayout();
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Detalle)).EndInit();
            this._Pnl_Derecho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _Txt_Ruta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _Txt_Descripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _Txt_Km;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox _Grb_Arriba;
        private System.Windows.Forms.ComboBox _Cmb_Ciudad;
        private System.Windows.Forms.ComboBox _Cmb_Estado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _Bt_Agregar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView _Dg_Detalle;
        private System.Windows.Forms.Panel _Pnl_Derecho;
        private System.Windows.Forms.Button _Bt_Eliminar;
        private System.Windows.Forms.Button _Bt_Bajar;
        private System.Windows.Forms.Button _Bt_Subir;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private T3.Controles._Ctrl_Busqueda _Ctrl_Busqueda1;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ciudad;
        private System.Windows.Forms.Label _Lbl_DgInfo;
    }
}