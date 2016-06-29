namespace T3
{
    partial class Frm_ComprobAjusInv
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._Dg_Comprobante = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this._Txt_Descripcion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this._Txt_Monto = new System.Windows.Forms.TextBox();
            this._Lbl_Ajuste = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._Dtp_Fecha = new System.Windows.Forms.DateTimePicker();
            this._Txt_Ajuste = new System.Windows.Forms.TextBox();
            this._Pnl_Clave = new System.Windows.Forms.Panel();
            this._Txt_Clave = new System.Windows.Forms.TextBox();
            this._Bt_AceptarClave = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this._Bt_CancelarClave = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.Cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vacio = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Haber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Comprobante)).BeginInit();
            this.panel2.SuspendLayout();
            this._Pnl_Clave.SuspendLayout();
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
            this._Tb_Tab.Size = new System.Drawing.Size(772, 424);
            this._Tb_Tab.TabIndex = 19;
            this._Tb_Tab.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this._Tb_Tab_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._Dg_Grid);
            this.tabPage1.Controls.Add(this._Lbl_DgInfo);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(764, 399);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(3, 3);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.Size = new System.Drawing.Size(758, 382);
            this._Dg_Grid.TabIndex = 17;
            this._Dg_Grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseDoubleClick);
            this._Dg_Grid.MouseEnter += new System.EventHandler(this._Dg_Grid_MouseEnter);
            this._Dg_Grid.MouseLeave += new System.EventHandler(this._Dg_Grid_MouseLeave);
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(3, 385);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(758, 11);
            this._Lbl_DgInfo.TabIndex = 135;
            this._Lbl_DgInfo.Text = "Use doble click";
            this._Lbl_DgInfo.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._Dg_Comprobante);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(764, 399);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _Dg_Comprobante
            // 
            this._Dg_Comprobante.AllowUserToAddRows = false;
            this._Dg_Comprobante.AllowUserToDeleteRows = false;
            this._Dg_Comprobante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Comprobante.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cuenta,
            this.Vacio,
            this.Descripcion,
            this.Debe,
            this.Haber});
            this._Dg_Comprobante.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Comprobante.Location = new System.Drawing.Point(3, 180);
            this._Dg_Comprobante.MultiSelect = false;
            this._Dg_Comprobante.Name = "_Dg_Comprobante";
            this._Dg_Comprobante.Size = new System.Drawing.Size(758, 216);
            this._Dg_Comprobante.TabIndex = 133;
            this._Dg_Comprobante.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this._Dg_Comprobante_CellBeginEdit);
            this._Dg_Comprobante.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Comprobante_CellClick);
            this._Dg_Comprobante.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Comprobante_CellEndEdit);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this._Txt_Descripcion);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this._Txt_Monto);
            this.panel2.Controls.Add(this._Lbl_Ajuste);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this._Dtp_Fecha);
            this.panel2.Controls.Add(this._Txt_Ajuste);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(758, 177);
            this.panel2.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(8, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "Descripción:";
            // 
            // _Txt_Descripcion
            // 
            this._Txt_Descripcion.BackColor = System.Drawing.Color.White;
            this._Txt_Descripcion.Location = new System.Drawing.Point(11, 106);
            this._Txt_Descripcion.Name = "_Txt_Descripcion";
            this._Txt_Descripcion.ReadOnly = true;
            this._Txt_Descripcion.Size = new System.Drawing.Size(498, 18);
            this._Txt_Descripcion.TabIndex = 66;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(8, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 64;
            this.label8.Text = "Monto:";
            // 
            // _Txt_Monto
            // 
            this._Txt_Monto.BackColor = System.Drawing.Color.White;
            this._Txt_Monto.Location = new System.Drawing.Point(11, 143);
            this._Txt_Monto.MaxLength = 14;
            this._Txt_Monto.Name = "_Txt_Monto";
            this._Txt_Monto.ReadOnly = true;
            this._Txt_Monto.Size = new System.Drawing.Size(129, 18);
            this._Txt_Monto.TabIndex = 65;
            // 
            // _Lbl_Ajuste
            // 
            this._Lbl_Ajuste.AutoSize = true;
            this._Lbl_Ajuste.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Lbl_Ajuste.Location = new System.Drawing.Point(8, 16);
            this._Lbl_Ajuste.Name = "_Lbl_Ajuste";
            this._Lbl_Ajuste.Size = new System.Drawing.Size(53, 13);
            this._Lbl_Ajuste.TabIndex = 50;
            this._Lbl_Ajuste.Text = "Ajuste:";
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
            this._Dtp_Fecha.Size = new System.Drawing.Size(97, 18);
            this._Dtp_Fecha.TabIndex = 46;
            this._Dtp_Fecha.Value = new System.DateTime(2008, 5, 28, 0, 0, 0, 0);
            // 
            // _Txt_Ajuste
            // 
            this._Txt_Ajuste.BackColor = System.Drawing.Color.White;
            this._Txt_Ajuste.Location = new System.Drawing.Point(11, 32);
            this._Txt_Ajuste.MaxLength = 14;
            this._Txt_Ajuste.Name = "_Txt_Ajuste";
            this._Txt_Ajuste.ReadOnly = true;
            this._Txt_Ajuste.Size = new System.Drawing.Size(129, 18);
            this._Txt_Ajuste.TabIndex = 51;
            // 
            // _Pnl_Clave
            // 
            this._Pnl_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Clave.Controls.Add(this._Txt_Clave);
            this._Pnl_Clave.Controls.Add(this._Bt_AceptarClave);
            this._Pnl_Clave.Controls.Add(this.label11);
            this._Pnl_Clave.Controls.Add(this._Bt_CancelarClave);
            this._Pnl_Clave.Controls.Add(this.label16);
            this._Pnl_Clave.Location = new System.Drawing.Point(306, 169);
            this._Pnl_Clave.Name = "_Pnl_Clave";
            this._Pnl_Clave.Size = new System.Drawing.Size(160, 86);
            this._Pnl_Clave.TabIndex = 163;
            this._Pnl_Clave.Visible = false;
            this._Pnl_Clave.VisibleChanged += new System.EventHandler(this._Pnl_Clave_VisibleChanged);
            // 
            // _Txt_Clave
            // 
            this._Txt_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Clave.Location = new System.Drawing.Point(50, 31);
            this._Txt_Clave.Name = "_Txt_Clave";
            this._Txt_Clave.PasswordChar = '*';
            this._Txt_Clave.Size = new System.Drawing.Size(95, 20);
            this._Txt_Clave.TabIndex = 2;
            // 
            // _Bt_AceptarClave
            // 
            this._Bt_AceptarClave.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_AceptarClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_AceptarClave.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_AceptarClave.Location = new System.Drawing.Point(20, 55);
            this._Bt_AceptarClave.Name = "_Bt_AceptarClave";
            this._Bt_AceptarClave.Size = new System.Drawing.Size(62, 22);
            this._Bt_AceptarClave.TabIndex = 70;
            this._Bt_AceptarClave.Text = "Aceptar";
            this._Bt_AceptarClave.UseVisualStyleBackColor = true;
            this._Bt_AceptarClave.Click += new System.EventHandler(this._Bt_AceptarClave_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 68;
            this.label11.Text = "Clave:";
            // 
            // _Bt_CancelarClave
            // 
            this._Bt_CancelarClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_CancelarClave.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_CancelarClave.Location = new System.Drawing.Point(83, 55);
            this._Bt_CancelarClave.Name = "_Bt_CancelarClave";
            this._Bt_CancelarClave.Size = new System.Drawing.Size(62, 22);
            this._Bt_CancelarClave.TabIndex = 1;
            this._Bt_CancelarClave.Text = "Cancelar";
            this._Bt_CancelarClave.UseVisualStyleBackColor = true;
            this._Bt_CancelarClave.Click += new System.EventHandler(this._Bt_CancelarClave_Click);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Navy;
            this.label16.Dock = System.Windows.Forms.DockStyle.Top;
            this.label16.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(158, 18);
            this.label16.TabIndex = 0;
            this.label16.Text = "Introduzca Clave";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cuenta
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cuenta.DefaultCellStyle = dataGridViewCellStyle1;
            this.Cuenta.HeaderText = "Cuenta";
            this.Cuenta.Name = "Cuenta";
            // 
            // Vacio
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Navy;
            this.Vacio.DefaultCellStyle = dataGridViewCellStyle2;
            this.Vacio.HeaderText = "";
            this.Vacio.Name = "Vacio";
            this.Vacio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Vacio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Vacio.Width = 20;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Debe
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Debe.DefaultCellStyle = dataGridViewCellStyle3;
            this.Debe.HeaderText = "Debe";
            this.Debe.Name = "Debe";
            this.Debe.ReadOnly = true;
            // 
            // Haber
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Haber.DefaultCellStyle = dataGridViewCellStyle4;
            this.Haber.HeaderText = "Haber";
            this.Haber.Name = "Haber";
            this.Haber.ReadOnly = true;
            // 
            // Frm_ComprobAjusInv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 424);
            this.Controls.Add(this._Pnl_Clave);
            this.Controls.Add(this._Tb_Tab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ComprobAjusInv";
            this.Text = "Frm_ComprobAjusInv";
            this.Activated += new System.EventHandler(this.Frm_ComprobAjusInv_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ComprobAjusInv_FormClosing);
            this.Load += new System.EventHandler(this.Frm_ComprobAjusInv_Load);
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Comprobante)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this._Pnl_Clave.ResumeLayout(false);
            this._Pnl_Clave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.Label _Lbl_DgInfo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView _Dg_Comprobante;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _Txt_Monto;
        private System.Windows.Forms.Label _Lbl_Ajuste;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker _Dtp_Fecha;
        private System.Windows.Forms.TextBox _Txt_Ajuste;
        private System.Windows.Forms.Panel _Pnl_Clave;
        private System.Windows.Forms.TextBox _Txt_Clave;
        private System.Windows.Forms.Button _Bt_AceptarClave;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button _Bt_CancelarClave;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _Txt_Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuenta;
        private System.Windows.Forms.DataGridViewButtonColumn Vacio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Haber;
    }
}