namespace T3
{
    partial class Frm_FacturasPorFirmar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_FacturasPorFirmar));
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._Dg_Detalle = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this._Bt_Eliminar = new System.Windows.Forms.Button();
            this._Bt_Firmar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Txt_Fecha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this._Txt_Factura = new System.Windows.Forms.TextBox();
            this._Txt_Total = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this._Txt_Invendible = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._Txt_Impuesto = new System.Windows.Forms.TextBox();
            this._Txt_Proveedor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this._Txt_Monto = new System.Windows.Forms.TextBox();
            this._Pnl_Clave = new System.Windows.Forms.Panel();
            this._Bt_Aceptar = new System.Windows.Forms.Button();
            this._Lbl_Texto = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this._Txt_Clave = new System.Windows.Forms.TextBox();
            this._Bt_Cancelar = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this._Ctrl_Busqueda1 = new T3.Controles._Ctrl_Busqueda();
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Detalle)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this._Tb_Tab.Size = new System.Drawing.Size(783, 497);
            this._Tb_Tab.TabIndex = 6;
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
            this.tabPage1.Size = new System.Drawing.Size(775, 472);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this._Dg_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(3, 47);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.Size = new System.Drawing.Size(769, 411);
            this._Dg_Grid.TabIndex = 1;
            this._Dg_Grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseDoubleClick);
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(3, 458);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(769, 11);
            this._Lbl_DgInfo.TabIndex = 6;
            this._Lbl_DgInfo.Text = "Use doble click";
            this._Lbl_DgInfo.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._Dg_Detalle);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(775, 472);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _Dg_Detalle
            // 
            this._Dg_Detalle.AllowUserToAddRows = false;
            this._Dg_Detalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this._Dg_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Detalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Detalle.Location = new System.Drawing.Point(3, 104);
            this._Dg_Detalle.Name = "_Dg_Detalle";
            this._Dg_Detalle.ReadOnly = true;
            this._Dg_Detalle.Size = new System.Drawing.Size(769, 316);
            this._Dg_Detalle.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._Bt_Eliminar);
            this.panel2.Controls.Add(this._Bt_Firmar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 420);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(769, 49);
            this.panel2.TabIndex = 78;
            // 
            // _Bt_Eliminar
            // 
            this._Bt_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Eliminar.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold);
            this._Bt_Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Eliminar.Image")));
            this._Bt_Eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Eliminar.Location = new System.Drawing.Point(531, 6);
            this._Bt_Eliminar.Name = "_Bt_Eliminar";
            this._Bt_Eliminar.Size = new System.Drawing.Size(115, 35);
            this._Bt_Eliminar.TabIndex = 79;
            this._Bt_Eliminar.Text = "Eliminar factura";
            this._Bt_Eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Eliminar.UseVisualStyleBackColor = true;
            this._Bt_Eliminar.Click += new System.EventHandler(this._Bt_Eliminar_Click);
            // 
            // _Bt_Firmar
            // 
            this._Bt_Firmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Firmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Firmar.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Firmar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Firmar.Image")));
            this._Bt_Firmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Firmar.Location = new System.Drawing.Point(652, 6);
            this._Bt_Firmar.Name = "_Bt_Firmar";
            this._Bt_Firmar.Size = new System.Drawing.Size(115, 35);
            this._Bt_Firmar.TabIndex = 78;
            this._Bt_Firmar.Text = "Firmar factura";
            this._Bt_Firmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Firmar.UseVisualStyleBackColor = true;
            this._Bt_Firmar.Click += new System.EventHandler(this._Bt_Firmar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Txt_Fecha);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this._Txt_Factura);
            this.panel1.Controls.Add(this._Txt_Total);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this._Txt_Invendible);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this._Txt_Impuesto);
            this.panel1.Controls.Add(this._Txt_Proveedor);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this._Txt_Monto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 101);
            this.panel1.TabIndex = 77;
            // 
            // _Txt_Fecha
            // 
            this._Txt_Fecha.BackColor = System.Drawing.Color.White;
            this._Txt_Fecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Fecha.Location = new System.Drawing.Point(551, 43);
            this._Txt_Fecha.Name = "_Txt_Fecha";
            this._Txt_Fecha.ReadOnly = true;
            this._Txt_Fecha.Size = new System.Drawing.Size(73, 18);
            this._Txt_Fecha.TabIndex = 81;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(506, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 12);
            this.label1.TabIndex = 80;
            this.label1.Text = "Fecha:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(250, 71);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 12);
            this.label15.TabIndex = 79;
            this.label15.Text = "Monto Total:";
            // 
            // _Txt_Factura
            // 
            this._Txt_Factura.BackColor = System.Drawing.Color.White;
            this._Txt_Factura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Factura.Location = new System.Drawing.Point(86, 17);
            this._Txt_Factura.Name = "_Txt_Factura";
            this._Txt_Factura.ReadOnly = true;
            this._Txt_Factura.Size = new System.Drawing.Size(73, 18);
            this._Txt_Factura.TabIndex = 9;
            // 
            // _Txt_Total
            // 
            this._Txt_Total.BackColor = System.Drawing.Color.White;
            this._Txt_Total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Total.Location = new System.Drawing.Point(330, 69);
            this._Txt_Total.Name = "_Txt_Total";
            this._Txt_Total.ReadOnly = true;
            this._Txt_Total.Size = new System.Drawing.Size(140, 18);
            this._Txt_Total.TabIndex = 78;
            this._Txt_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 12);
            this.label14.TabIndex = 76;
            this.label14.Text = "Invendible:";
            // 
            // _Txt_Invendible
            // 
            this._Txt_Invendible.BackColor = System.Drawing.SystemColors.Window;
            this._Txt_Invendible.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Invendible.Location = new System.Drawing.Point(86, 69);
            this._Txt_Invendible.MaxLength = 30;
            this._Txt_Invendible.Name = "_Txt_Invendible";
            this._Txt_Invendible.ReadOnly = true;
            this._Txt_Invendible.Size = new System.Drawing.Size(141, 18);
            this._Txt_Invendible.TabIndex = 77;
            this._Txt_Invendible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Factura #:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(261, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 12);
            this.label6.TabIndex = 75;
            this.label6.Text = "Impuesto:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(185, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "Proveedor:";
            // 
            // _Txt_Impuesto
            // 
            this._Txt_Impuesto.BackColor = System.Drawing.Color.White;
            this._Txt_Impuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Impuesto.Location = new System.Drawing.Point(330, 42);
            this._Txt_Impuesto.Name = "_Txt_Impuesto";
            this._Txt_Impuesto.ReadOnly = true;
            this._Txt_Impuesto.Size = new System.Drawing.Size(140, 18);
            this._Txt_Impuesto.TabIndex = 74;
            this._Txt_Impuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _Txt_Proveedor
            // 
            this._Txt_Proveedor.BackColor = System.Drawing.Color.White;
            this._Txt_Proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Proveedor.Location = new System.Drawing.Point(251, 17);
            this._Txt_Proveedor.Name = "_Txt_Proveedor";
            this._Txt_Proveedor.ReadOnly = true;
            this._Txt_Proveedor.Size = new System.Drawing.Size(373, 18);
            this._Txt_Proveedor.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 12);
            this.label8.TabIndex = 72;
            this.label8.Text = "Monto:";
            // 
            // _Txt_Monto
            // 
            this._Txt_Monto.BackColor = System.Drawing.SystemColors.Window;
            this._Txt_Monto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Monto.Location = new System.Drawing.Point(86, 43);
            this._Txt_Monto.MaxLength = 30;
            this._Txt_Monto.Name = "_Txt_Monto";
            this._Txt_Monto.ReadOnly = true;
            this._Txt_Monto.Size = new System.Drawing.Size(141, 18);
            this._Txt_Monto.TabIndex = 73;
            this._Txt_Monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _Pnl_Clave
            // 
            this._Pnl_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Clave.Controls.Add(this._Bt_Aceptar);
            this._Pnl_Clave.Controls.Add(this._Lbl_Texto);
            this._Pnl_Clave.Controls.Add(this.label12);
            this._Pnl_Clave.Controls.Add(this._Txt_Clave);
            this._Pnl_Clave.Controls.Add(this._Bt_Cancelar);
            this._Pnl_Clave.Controls.Add(this.label13);
            this._Pnl_Clave.Location = new System.Drawing.Point(339, 198);
            this._Pnl_Clave.Name = "_Pnl_Clave";
            this._Pnl_Clave.Size = new System.Drawing.Size(168, 101);
            this._Pnl_Clave.TabIndex = 77;
            this._Pnl_Clave.Visible = false;
            this._Pnl_Clave.VisibleChanged += new System.EventHandler(this._Pnl_Clave_VisibleChanged);
            // 
            // _Bt_Aceptar
            // 
            this._Bt_Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Aceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Aceptar.Location = new System.Drawing.Point(15, 64);
            this._Bt_Aceptar.Name = "_Bt_Aceptar";
            this._Bt_Aceptar.Size = new System.Drawing.Size(66, 23);
            this._Bt_Aceptar.TabIndex = 70;
            this._Bt_Aceptar.Text = "Aceptar";
            this._Bt_Aceptar.UseVisualStyleBackColor = true;
            this._Bt_Aceptar.Click += new System.EventHandler(this._Bt_Aceptar_Click);
            // 
            // _Lbl_Texto
            // 
            this._Lbl_Texto.Dock = System.Windows.Forms.DockStyle.Top;
            this._Lbl_Texto.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_Texto.ForeColor = System.Drawing.Color.Blue;
            this._Lbl_Texto.Location = new System.Drawing.Point(0, 18);
            this._Lbl_Texto.Name = "_Lbl_Texto";
            this._Lbl_Texto.Size = new System.Drawing.Size(166, 19);
            this._Lbl_Texto.TabIndex = 69;
            this._Lbl_Texto.Text = "¿Esta seguro de firmar la factura?";
            this._Lbl_Texto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 12);
            this.label12.TabIndex = 68;
            this.label12.Text = "Clave:";
            // 
            // _Txt_Clave
            // 
            this._Txt_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Clave.Location = new System.Drawing.Point(48, 40);
            this._Txt_Clave.Name = "_Txt_Clave";
            this._Txt_Clave.PasswordChar = '*';
            this._Txt_Clave.Size = new System.Drawing.Size(88, 18);
            this._Txt_Clave.TabIndex = 2;
            // 
            // _Bt_Cancelar
            // 
            this._Bt_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Cancelar.Location = new System.Drawing.Point(83, 64);
            this._Bt_Cancelar.Name = "_Bt_Cancelar";
            this._Bt_Cancelar.Size = new System.Drawing.Size(64, 23);
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
            this.label13.Size = new System.Drawing.Size(166, 18);
            this.label13.TabIndex = 0;
            this.label13.Text = "Introduzca Clave";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Ctrl_Busqueda1
            // 
            this._Ctrl_Busqueda1.Dock = System.Windows.Forms.DockStyle.Top;
            this._Ctrl_Busqueda1.Location = new System.Drawing.Point(3, 3);
            this._Ctrl_Busqueda1.Name = "_Ctrl_Busqueda1";
            this._Ctrl_Busqueda1.Size = new System.Drawing.Size(769, 44);
            this._Ctrl_Busqueda1.TabIndex = 3;
            // 
            // Frm_FacturasPorFirmar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 497);
            this.Controls.Add(this._Pnl_Clave);
            this.Controls.Add(this._Tb_Tab);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_FacturasPorFirmar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FACTURAS DE RECEPCIÓN DE COMPRA POR FIRMAR";
            this.Load += new System.EventHandler(this.Frm_FacturasPorFirmar_Load);
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Detalle)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._Pnl_Clave.ResumeLayout(false);
            this._Pnl_Clave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private T3.Controles._Ctrl_Busqueda _Ctrl_Busqueda1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView _Dg_Detalle;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox _Txt_Total;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox _Txt_Invendible;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _Txt_Impuesto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _Txt_Monto;
        private System.Windows.Forms.TextBox _Txt_Proveedor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _Txt_Factura;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label _Lbl_DgInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox _Txt_Fecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel _Pnl_Clave;
        private System.Windows.Forms.Button _Bt_Aceptar;
        private System.Windows.Forms.Label _Lbl_Texto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox _Txt_Clave;
        private System.Windows.Forms.Button _Bt_Cancelar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button _Bt_Eliminar;
        private System.Windows.Forms.Button _Bt_Firmar;
    }
}