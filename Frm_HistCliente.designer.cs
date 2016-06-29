namespace T3
{
    partial class Frm_HistCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_HistCliente));
            this._Pnl_Superior = new System.Windows.Forms.Panel();
            this._Txt_Zona = new System.Windows.Forms.TextBox();
            this._Bt_LimpiarZona = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._Bt_Zona = new System.Windows.Forms.Button();
            this._Txt_Cliente = new System.Windows.Forms.TextBox();
            this._Bt_LimpiarCliente = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this._Bt_Cliente = new System.Windows.Forms.Button();
            this._Pnl_Inferior = new System.Windows.Forms.Panel();
            this._Bt_Cambiar = new System.Windows.Forms.Button();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this._Pnl_Clave = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this._Dtp_FechaFinal = new System.Windows.Forms.DateTimePicker();
            this._Bt_AceptarClave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this._Txt_Clave = new System.Windows.Forms.TextBox();
            this._Bt_CancelarClave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this._Pnl_Superior.SuspendLayout();
            this._Pnl_Inferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this._Pnl_Clave.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Pnl_Superior
            // 
            this._Pnl_Superior.Controls.Add(this._Txt_Zona);
            this._Pnl_Superior.Controls.Add(this._Bt_LimpiarZona);
            this._Pnl_Superior.Controls.Add(this.label2);
            this._Pnl_Superior.Controls.Add(this._Bt_Zona);
            this._Pnl_Superior.Controls.Add(this._Txt_Cliente);
            this._Pnl_Superior.Controls.Add(this._Bt_LimpiarCliente);
            this._Pnl_Superior.Controls.Add(this.label3);
            this._Pnl_Superior.Controls.Add(this._Bt_Cliente);
            this._Pnl_Superior.Dock = System.Windows.Forms.DockStyle.Top;
            this._Pnl_Superior.Location = new System.Drawing.Point(0, 0);
            this._Pnl_Superior.Name = "_Pnl_Superior";
            this._Pnl_Superior.Size = new System.Drawing.Size(699, 98);
            this._Pnl_Superior.TabIndex = 0;
            // 
            // _Txt_Zona
            // 
            this._Txt_Zona.BackColor = System.Drawing.SystemColors.HighlightText;
            this._Txt_Zona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Zona.Enabled = false;
            this._Txt_Zona.Location = new System.Drawing.Point(14, 65);
            this._Txt_Zona.Name = "_Txt_Zona";
            this._Txt_Zona.ReadOnly = true;
            this._Txt_Zona.Size = new System.Drawing.Size(298, 20);
            this._Txt_Zona.TabIndex = 150;
            // 
            // _Bt_LimpiarZona
            // 
            this._Bt_LimpiarZona.Enabled = false;
            this._Bt_LimpiarZona.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_LimpiarZona.Image")));
            this._Bt_LimpiarZona.Location = new System.Drawing.Point(347, 65);
            this._Bt_LimpiarZona.Name = "_Bt_LimpiarZona";
            this._Bt_LimpiarZona.Size = new System.Drawing.Size(25, 18);
            this._Bt_LimpiarZona.TabIndex = 149;
            this._Bt_LimpiarZona.UseVisualStyleBackColor = true;
            this._Bt_LimpiarZona.Click += new System.EventHandler(this._Bt_LimpiarZona_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 151;
            this.label2.Text = "Zona:";
            // 
            // _Bt_Zona
            // 
            this._Bt_Zona.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Zona.Enabled = false;
            this._Bt_Zona.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Zona.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Zona.Image")));
            this._Bt_Zona.Location = new System.Drawing.Point(316, 65);
            this._Bt_Zona.Name = "_Bt_Zona";
            this._Bt_Zona.Size = new System.Drawing.Size(25, 18);
            this._Bt_Zona.TabIndex = 148;
            this._Bt_Zona.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._Bt_Zona.UseVisualStyleBackColor = true;
            this._Bt_Zona.Click += new System.EventHandler(this._Bt_Zona_Click);
            // 
            // _Txt_Cliente
            // 
            this._Txt_Cliente.BackColor = System.Drawing.SystemColors.HighlightText;
            this._Txt_Cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Cliente.Location = new System.Drawing.Point(14, 24);
            this._Txt_Cliente.Name = "_Txt_Cliente";
            this._Txt_Cliente.ReadOnly = true;
            this._Txt_Cliente.Size = new System.Drawing.Size(298, 20);
            this._Txt_Cliente.TabIndex = 145;
            // 
            // _Bt_LimpiarCliente
            // 
            this._Bt_LimpiarCliente.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_LimpiarCliente.Image")));
            this._Bt_LimpiarCliente.Location = new System.Drawing.Point(347, 24);
            this._Bt_LimpiarCliente.Name = "_Bt_LimpiarCliente";
            this._Bt_LimpiarCliente.Size = new System.Drawing.Size(25, 18);
            this._Bt_LimpiarCliente.TabIndex = 1;
            this._Bt_LimpiarCliente.UseVisualStyleBackColor = true;
            this._Bt_LimpiarCliente.Click += new System.EventHandler(this._Bt_LimpiarCliente_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 147;
            this.label3.Text = "Cliente:";
            // 
            // _Bt_Cliente
            // 
            this._Bt_Cliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Cliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Cliente.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Cliente.Image")));
            this._Bt_Cliente.Location = new System.Drawing.Point(316, 24);
            this._Bt_Cliente.Name = "_Bt_Cliente";
            this._Bt_Cliente.Size = new System.Drawing.Size(25, 18);
            this._Bt_Cliente.TabIndex = 0;
            this._Bt_Cliente.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._Bt_Cliente.UseVisualStyleBackColor = true;
            this._Bt_Cliente.Click += new System.EventHandler(this._Bt_Cliente_Click);
            // 
            // _Pnl_Inferior
            // 
            this._Pnl_Inferior.Controls.Add(this._Bt_Cambiar);
            this._Pnl_Inferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Pnl_Inferior.Location = new System.Drawing.Point(0, 354);
            this._Pnl_Inferior.Name = "_Pnl_Inferior";
            this._Pnl_Inferior.Size = new System.Drawing.Size(699, 35);
            this._Pnl_Inferior.TabIndex = 1;
            // 
            // _Bt_Cambiar
            // 
            this._Bt_Cambiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Bt_Cambiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Cambiar.Enabled = false;
            this._Bt_Cambiar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Cambiar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Cambiar.Image")));
            this._Bt_Cambiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Cambiar.Location = new System.Drawing.Point(3, 1);
            this._Bt_Cambiar.Name = "_Bt_Cambiar";
            this._Bt_Cambiar.Size = new System.Drawing.Size(163, 31);
            this._Bt_Cambiar.TabIndex = 0;
            this._Bt_Cambiar.Text = "Cambiar fecha final";
            this._Bt_Cambiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Cambiar.UseVisualStyleBackColor = true;
            this._Bt_Cambiar.Click += new System.EventHandler(this._Bt_Cambiar_Click);
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._Dg_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(0, 98);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Size = new System.Drawing.Size(699, 256);
            this._Dg_Grid.TabIndex = 9;
            // 
            // _Pnl_Clave
            // 
            this._Pnl_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Clave.Controls.Add(this.label1);
            this._Pnl_Clave.Controls.Add(this._Dtp_FechaFinal);
            this._Pnl_Clave.Controls.Add(this._Bt_AceptarClave);
            this._Pnl_Clave.Controls.Add(this.label8);
            this._Pnl_Clave.Controls.Add(this._Txt_Clave);
            this._Pnl_Clave.Controls.Add(this._Bt_CancelarClave);
            this._Pnl_Clave.Controls.Add(this.label9);
            this._Pnl_Clave.Location = new System.Drawing.Point(252, 151);
            this._Pnl_Clave.Name = "_Pnl_Clave";
            this._Pnl_Clave.Size = new System.Drawing.Size(186, 105);
            this._Pnl_Clave.TabIndex = 84;
            this._Pnl_Clave.Visible = false;
            this._Pnl_Clave.VisibleChanged += new System.EventHandler(this._Pnl_Clave_VisibleChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "Fecha final";
            // 
            // _Dtp_FechaFinal
            // 
            this._Dtp_FechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dtp_FechaFinal.Location = new System.Drawing.Point(79, 21);
            this._Dtp_FechaFinal.Name = "_Dtp_FechaFinal";
            this._Dtp_FechaFinal.Size = new System.Drawing.Size(97, 20);
            this._Dtp_FechaFinal.TabIndex = 0;
            this._Dtp_FechaFinal.Value = new System.DateTime(2008, 5, 28, 0, 0, 0, 0);
            // 
            // _Bt_AceptarClave
            // 
            this._Bt_AceptarClave.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_AceptarClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_AceptarClave.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_AceptarClave.Location = new System.Drawing.Point(51, 73);
            this._Bt_AceptarClave.Name = "_Bt_AceptarClave";
            this._Bt_AceptarClave.Size = new System.Drawing.Size(62, 22);
            this._Bt_AceptarClave.TabIndex = 2;
            this._Bt_AceptarClave.Text = "Aceptar";
            this._Bt_AceptarClave.UseVisualStyleBackColor = true;
            this._Bt_AceptarClave.Click += new System.EventHandler(this._Bt_AceptarClave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 68;
            this.label8.Text = "Clave:";
            // 
            // _Txt_Clave
            // 
            this._Txt_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Clave.Location = new System.Drawing.Point(79, 47);
            this._Txt_Clave.Name = "_Txt_Clave";
            this._Txt_Clave.PasswordChar = '*';
            this._Txt_Clave.Size = new System.Drawing.Size(95, 20);
            this._Txt_Clave.TabIndex = 1;
            // 
            // _Bt_CancelarClave
            // 
            this._Bt_CancelarClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_CancelarClave.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_CancelarClave.Location = new System.Drawing.Point(114, 73);
            this._Bt_CancelarClave.Name = "_Bt_CancelarClave";
            this._Bt_CancelarClave.Size = new System.Drawing.Size(62, 22);
            this._Bt_CancelarClave.TabIndex = 3;
            this._Bt_CancelarClave.Text = "Cancelar";
            this._Bt_CancelarClave.UseVisualStyleBackColor = true;
            this._Bt_CancelarClave.Click += new System.EventHandler(this._Bt_CancelarClave_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Navy;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(184, 18);
            this.label9.TabIndex = 0;
            this.label9.Text = "Introduzca Clave";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_HistCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 389);
            this.Controls.Add(this._Pnl_Clave);
            this.Controls.Add(this._Dg_Grid);
            this.Controls.Add(this._Pnl_Inferior);
            this.Controls.Add(this._Pnl_Superior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_HistCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial del Cliente";
            this.Load += new System.EventHandler(this.Frm_HistCliente_Load);
            this.Activated += new System.EventHandler(this.Frm_HistCliente_Activated);
            this._Pnl_Superior.ResumeLayout(false);
            this._Pnl_Superior.PerformLayout();
            this._Pnl_Inferior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this._Pnl_Clave.ResumeLayout(false);
            this._Pnl_Clave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _Pnl_Superior;
        private System.Windows.Forms.TextBox _Txt_Cliente;
        private System.Windows.Forms.Button _Bt_LimpiarCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _Bt_Cliente;
        private System.Windows.Forms.Panel _Pnl_Inferior;
        public System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.Button _Bt_Cambiar;
        private System.Windows.Forms.Panel _Pnl_Clave;
        private System.Windows.Forms.Button _Bt_AceptarClave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _Txt_Clave;
        private System.Windows.Forms.Button _Bt_CancelarClave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker _Dtp_FechaFinal;
        private System.Windows.Forms.TextBox _Txt_Zona;
        private System.Windows.Forms.Button _Bt_LimpiarZona;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _Bt_Zona;
    }
}