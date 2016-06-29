namespace T3
{
    partial class Frm_ClientesSinZona
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ClientesSinZona));
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this._Ctrl_Busqueda1 = new T3.Controles._Ctrl_Busqueda();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._Dg_Zonas = new System.Windows.Forms.DataGridView();
            this.label46 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Bt_Direcc = new System.Windows.Forms.Button();
            this._Txt_Ciudad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Txt_Estado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Txt_Direcc_Fiscal = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this._Txt_Rif = new System.Windows.Forms.TextBox();
            this._Txt_Cliente = new System.Windows.Forms.TextBox();
            this._Txt_Denominacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._Lbl_Codigo = new System.Windows.Forms.Label();
            this._Pnl_Direcc = new System.Windows.Forms.Panel();
            this._Bt_Cerrar = new System.Windows.Forms.Button();
            this._Txt_Descrip = new System.Windows.Forms.TextBox();
            this._Txt_Pnl_Estado = new System.Windows.Forms.TextBox();
            this._Txt_Pnl_Ciudad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._Cmb_Direcc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Zonas)).BeginInit();
            this.panel1.SuspendLayout();
            this._Pnl_Direcc.SuspendLayout();
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
            this._Tb_Tab.Size = new System.Drawing.Size(447, 427);
            this._Tb_Tab.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._Dg_Grid);
            this.tabPage1.Controls.Add(this._Lbl_DgInfo);
            this.tabPage1.Controls.Add(this._Ctrl_Busqueda1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(439, 401);
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
            this._Dg_Grid.Location = new System.Drawing.Point(3, 51);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.Size = new System.Drawing.Size(433, 335);
            this._Dg_Grid.TabIndex = 1;
            this._Dg_Grid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_CellMouseEnter);
            this._Dg_Grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseDoubleClick);
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(3, 386);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(433, 12);
            this._Lbl_DgInfo.TabIndex = 6;
            this._Lbl_DgInfo.Text = "Use doble click";
            this._Lbl_DgInfo.Visible = false;
            // 
            // _Ctrl_Busqueda1
            // 
            this._Ctrl_Busqueda1.Dock = System.Windows.Forms.DockStyle.Top;
            this._Ctrl_Busqueda1.Location = new System.Drawing.Point(3, 3);
            this._Ctrl_Busqueda1.Name = "_Ctrl_Busqueda1";
            this._Ctrl_Busqueda1.Size = new System.Drawing.Size(433, 48);
            this._Ctrl_Busqueda1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._Dg_Zonas);
            this.tabPage2.Controls.Add(this.label46);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(439, 401);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _Dg_Zonas
            // 
            this._Dg_Zonas.AllowUserToAddRows = false;
            this._Dg_Zonas.AllowUserToDeleteRows = false;
            this._Dg_Zonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Zonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Zonas.Location = new System.Drawing.Point(3, 212);
            this._Dg_Zonas.Name = "_Dg_Zonas";
            this._Dg_Zonas.ReadOnly = true;
            this._Dg_Zonas.Size = new System.Drawing.Size(433, 186);
            this._Dg_Zonas.TabIndex = 2;
            this._Dg_Zonas.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Zonas_RowHeaderMouseDoubleClick);
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.Color.Navy;
            this.label46.Dock = System.Windows.Forms.DockStyle.Top;
            this.label46.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label46.Location = new System.Drawing.Point(3, 193);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(433, 19);
            this.label46.TabIndex = 1;
            this.label46.Text = "Zonas Relacionadas";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this._Bt_Direcc);
            this.panel1.Controls.Add(this._Txt_Ciudad);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._Txt_Estado);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._Txt_Direcc_Fiscal);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this._Txt_Rif);
            this.panel1.Controls.Add(this._Txt_Cliente);
            this.panel1.Controls.Add(this._Txt_Denominacion);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this._Lbl_Codigo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 190);
            this.panel1.TabIndex = 0;
            // 
            // _Bt_Direcc
            // 
            this._Bt_Direcc.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Direcc.Enabled = false;
            this._Bt_Direcc.Location = new System.Drawing.Point(7, 159);
            this._Bt_Direcc.Name = "_Bt_Direcc";
            this._Bt_Direcc.Size = new System.Drawing.Size(144, 22);
            this._Bt_Direcc.TabIndex = 21;
            this._Bt_Direcc.Text = "Direcciones de Despacho";
            this._Bt_Direcc.UseVisualStyleBackColor = true;
            this._Bt_Direcc.Click += new System.EventHandler(this._Bt_Direcc_Click);
            // 
            // _Txt_Ciudad
            // 
            this._Txt_Ciudad.BackColor = System.Drawing.SystemColors.Window;
            this._Txt_Ciudad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Ciudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Ciudad.Location = new System.Drawing.Point(192, 135);
            this._Txt_Ciudad.Name = "_Txt_Ciudad";
            this._Txt_Ciudad.ReadOnly = true;
            this._Txt_Ciudad.Size = new System.Drawing.Size(179, 18);
            this._Txt_Ciudad.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Ciudad:";
            // 
            // _Txt_Estado
            // 
            this._Txt_Estado.BackColor = System.Drawing.SystemColors.Window;
            this._Txt_Estado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Estado.Location = new System.Drawing.Point(7, 135);
            this._Txt_Estado.Name = "_Txt_Estado";
            this._Txt_Estado.ReadOnly = true;
            this._Txt_Estado.Size = new System.Drawing.Size(179, 18);
            this._Txt_Estado.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Estado:";
            // 
            // _Txt_Direcc_Fiscal
            // 
            this._Txt_Direcc_Fiscal.BackColor = System.Drawing.SystemColors.Window;
            this._Txt_Direcc_Fiscal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Direcc_Fiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Direcc_Fiscal.Location = new System.Drawing.Point(7, 98);
            this._Txt_Direcc_Fiscal.Name = "_Txt_Direcc_Fiscal";
            this._Txt_Direcc_Fiscal.ReadOnly = true;
            this._Txt_Direcc_Fiscal.Size = new System.Drawing.Size(364, 18);
            this._Txt_Direcc_Fiscal.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Dirección fiscal";
            // 
            // _Txt_Rif
            // 
            this._Txt_Rif.BackColor = System.Drawing.SystemColors.Window;
            this._Txt_Rif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Rif.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Rif.Location = new System.Drawing.Point(109, 24);
            this._Txt_Rif.Name = "_Txt_Rif";
            this._Txt_Rif.ReadOnly = true;
            this._Txt_Rif.Size = new System.Drawing.Size(103, 18);
            this._Txt_Rif.TabIndex = 10;
            // 
            // _Txt_Cliente
            // 
            this._Txt_Cliente.BackColor = System.Drawing.SystemColors.Window;
            this._Txt_Cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Cliente.Location = new System.Drawing.Point(7, 24);
            this._Txt_Cliente.Name = "_Txt_Cliente";
            this._Txt_Cliente.ReadOnly = true;
            this._Txt_Cliente.Size = new System.Drawing.Size(51, 18);
            this._Txt_Cliente.TabIndex = 9;
            // 
            // _Txt_Denominacion
            // 
            this._Txt_Denominacion.BackColor = System.Drawing.SystemColors.Window;
            this._Txt_Denominacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Denominacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Denominacion.Location = new System.Drawing.Point(7, 61);
            this._Txt_Denominacion.Name = "_Txt_Denominacion";
            this._Txt_Denominacion.ReadOnly = true;
            this._Txt_Denominacion.Size = new System.Drawing.Size(277, 18);
            this._Txt_Denominacion.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(106, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Rif:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(220, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Denominación comercial: (Nombre comercial)";
            // 
            // _Lbl_Codigo
            // 
            this._Lbl_Codigo.AutoSize = true;
            this._Lbl_Codigo.Location = new System.Drawing.Point(4, 8);
            this._Lbl_Codigo.Name = "_Lbl_Codigo";
            this._Lbl_Codigo.Size = new System.Drawing.Size(43, 13);
            this._Lbl_Codigo.TabIndex = 12;
            this._Lbl_Codigo.Text = "Código:";
            // 
            // _Pnl_Direcc
            // 
            this._Pnl_Direcc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Direcc.Controls.Add(this._Bt_Cerrar);
            this._Pnl_Direcc.Controls.Add(this._Txt_Descrip);
            this._Pnl_Direcc.Controls.Add(this._Txt_Pnl_Estado);
            this._Pnl_Direcc.Controls.Add(this._Txt_Pnl_Ciudad);
            this._Pnl_Direcc.Controls.Add(this.label7);
            this._Pnl_Direcc.Controls.Add(this.label8);
            this._Pnl_Direcc.Controls.Add(this._Cmb_Direcc);
            this._Pnl_Direcc.Controls.Add(this.label4);
            this._Pnl_Direcc.Controls.Add(this.label3);
            this._Pnl_Direcc.Location = new System.Drawing.Point(62, 33);
            this._Pnl_Direcc.Name = "_Pnl_Direcc";
            this._Pnl_Direcc.Size = new System.Drawing.Size(269, 195);
            this._Pnl_Direcc.TabIndex = 83;
            this._Pnl_Direcc.Visible = false;
            this._Pnl_Direcc.VisibleChanged += new System.EventHandler(this._Pnl_Clave_VisibleChanged);
            // 
            // _Bt_Cerrar
            // 
            this._Bt_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Cerrar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Cerrar.Image")));
            this._Bt_Cerrar.Location = new System.Drawing.Point(241, -1);
            this._Bt_Cerrar.Name = "_Bt_Cerrar";
            this._Bt_Cerrar.Size = new System.Drawing.Size(27, 28);
            this._Bt_Cerrar.TabIndex = 29;
            this._Bt_Cerrar.UseVisualStyleBackColor = true;
            this._Bt_Cerrar.Click += new System.EventHandler(this._Bt_Cerrar_Click);
            // 
            // _Txt_Descrip
            // 
            this._Txt_Descrip.BackColor = System.Drawing.SystemColors.Window;
            this._Txt_Descrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Descrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Descrip.Location = new System.Drawing.Point(6, 68);
            this._Txt_Descrip.Multiline = true;
            this._Txt_Descrip.Name = "_Txt_Descrip";
            this._Txt_Descrip.ReadOnly = true;
            this._Txt_Descrip.Size = new System.Drawing.Size(252, 41);
            this._Txt_Descrip.TabIndex = 25;
            // 
            // _Txt_Pnl_Estado
            // 
            this._Txt_Pnl_Estado.BackColor = System.Drawing.SystemColors.Window;
            this._Txt_Pnl_Estado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Pnl_Estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Pnl_Estado.Location = new System.Drawing.Point(6, 128);
            this._Txt_Pnl_Estado.Name = "_Txt_Pnl_Estado";
            this._Txt_Pnl_Estado.ReadOnly = true;
            this._Txt_Pnl_Estado.Size = new System.Drawing.Size(179, 18);
            this._Txt_Pnl_Estado.TabIndex = 21;
            // 
            // _Txt_Pnl_Ciudad
            // 
            this._Txt_Pnl_Ciudad.BackColor = System.Drawing.SystemColors.Window;
            this._Txt_Pnl_Ciudad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Pnl_Ciudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Pnl_Ciudad.Location = new System.Drawing.Point(6, 165);
            this._Txt_Pnl_Ciudad.Name = "_Txt_Pnl_Ciudad";
            this._Txt_Pnl_Ciudad.ReadOnly = true;
            this._Txt_Pnl_Ciudad.Size = new System.Drawing.Size(179, 18);
            this._Txt_Pnl_Ciudad.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Ciudad:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Estado:";
            // 
            // _Cmb_Direcc
            // 
            this._Cmb_Direcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Direcc.FormattingEnabled = true;
            this._Cmb_Direcc.Location = new System.Drawing.Point(6, 41);
            this._Cmb_Direcc.Name = "_Cmb_Direcc";
            this._Cmb_Direcc.Size = new System.Drawing.Size(252, 21);
            this._Cmb_Direcc.TabIndex = 2;
            this._Cmb_Direcc.SelectedIndexChanged += new System.EventHandler(this._Cmb_Direcc_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Direccion de Despacho";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Navy;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Direcciones de Despacho";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_ClientesSinZona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 427);
            this.Controls.Add(this._Pnl_Direcc);
            this.Controls.Add(this._Tb_Tab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ClientesSinZona";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes sin Zona";
            this.Activated += new System.EventHandler(this.Frm_ClientesSinZona_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ClientesSinZona_FormClosing);
            this.Load += new System.EventHandler(this.Frm_ClientesSinZona_Load);
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Zonas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._Pnl_Direcc.ResumeLayout(false);
            this._Pnl_Direcc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private T3.Controles._Ctrl_Busqueda _Ctrl_Busqueda1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox _Txt_Rif;
        private System.Windows.Forms.TextBox _Txt_Cliente;
        private System.Windows.Forms.TextBox _Txt_Denominacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label _Lbl_Codigo;
        private System.Windows.Forms.TextBox _Txt_Direcc_Fiscal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView _Dg_Zonas;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label _Lbl_DgInfo;
        private System.Windows.Forms.TextBox _Txt_Estado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _Txt_Ciudad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _Bt_Direcc;
        private System.Windows.Forms.Panel _Pnl_Direcc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox _Cmb_Direcc;
        private System.Windows.Forms.TextBox _Txt_Pnl_Estado;
        private System.Windows.Forms.TextBox _Txt_Pnl_Ciudad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _Txt_Descrip;
        private System.Windows.Forms.Button _Bt_Cerrar;
    }
}