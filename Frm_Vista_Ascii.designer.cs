namespace T3
{
    partial class Frm_Vista_Ascii
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this._Dg_Grid2 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this._Bt_Aceptar = new System.Windows.Forms.Button();
            this._Bt_Cancelar = new System.Windows.Forms.Button();
            this._Pnl_Clave = new System.Windows.Forms.Panel();
            this._Bt_Aceptar_Clave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this._Txt_Clave = new System.Windows.Forms.TextBox();
            this._Cancelar_Clave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._Bt_Aceptar2 = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadesped = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidaddescar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diferund = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid2)).BeginInit();
            this._Pnl_Clave.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Dg_Grid2
            // 
            this._Dg_Grid2.AllowUserToAddRows = false;
            this._Dg_Grid2.AllowUserToDeleteRows = false;
            this._Dg_Grid2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this._Dg_Grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.unidadesped,
            this.Column4,
            this.unidaddescar,
            this.Column5,
            this.diferund});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._Dg_Grid2.DefaultCellStyle = dataGridViewCellStyle7;
            this._Dg_Grid2.Dock = System.Windows.Forms.DockStyle.Top;
            this._Dg_Grid2.Location = new System.Drawing.Point(0, 20);
            this._Dg_Grid2.Name = "_Dg_Grid2";
            this._Dg_Grid2.ReadOnly = true;
            this._Dg_Grid2.Size = new System.Drawing.Size(877, 141);
            this._Dg_Grid2.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Navy;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(877, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Coincidencia fallida en los siguientes productos";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Bt_Aceptar
            // 
            this._Bt_Aceptar.Location = new System.Drawing.Point(219, 167);
            this._Bt_Aceptar.Name = "_Bt_Aceptar";
            this._Bt_Aceptar.Size = new System.Drawing.Size(157, 26);
            this._Bt_Aceptar.TabIndex = 14;
            this._Bt_Aceptar.Text = "Aceptar cantidad pedida";
            this._Bt_Aceptar.UseVisualStyleBackColor = true;
            this._Bt_Aceptar.Visible = false;
            this._Bt_Aceptar.Click += new System.EventHandler(this._Bt_Aceptar_Click);
            // 
            // _Bt_Cancelar
            // 
            this._Bt_Cancelar.Location = new System.Drawing.Point(516, 167);
            this._Bt_Cancelar.Name = "_Bt_Cancelar";
            this._Bt_Cancelar.Size = new System.Drawing.Size(86, 26);
            this._Bt_Cancelar.TabIndex = 15;
            this._Bt_Cancelar.Text = "Cancelar";
            this._Bt_Cancelar.UseVisualStyleBackColor = true;
            this._Bt_Cancelar.Click += new System.EventHandler(this._Bt_Cancelar_Click);
            // 
            // _Pnl_Clave
            // 
            this._Pnl_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Clave.Controls.Add(this._Bt_Aceptar_Clave);
            this._Pnl_Clave.Controls.Add(this.label3);
            this._Pnl_Clave.Controls.Add(this._Txt_Clave);
            this._Pnl_Clave.Controls.Add(this._Cancelar_Clave);
            this._Pnl_Clave.Controls.Add(this.label1);
            this._Pnl_Clave.Location = new System.Drawing.Point(373, 66);
            this._Pnl_Clave.Name = "_Pnl_Clave";
            this._Pnl_Clave.Size = new System.Drawing.Size(194, 81);
            this._Pnl_Clave.TabIndex = 72;
            this._Pnl_Clave.Visible = false;
            this._Pnl_Clave.VisibleChanged += new System.EventHandler(this._Pnl_Clave_VisibleChanged);
            // 
            // _Bt_Aceptar_Clave
            // 
            this._Bt_Aceptar_Clave.Location = new System.Drawing.Point(73, 52);
            this._Bt_Aceptar_Clave.Name = "_Bt_Aceptar_Clave";
            this._Bt_Aceptar_Clave.Size = new System.Drawing.Size(59, 20);
            this._Bt_Aceptar_Clave.TabIndex = 70;
            this._Bt_Aceptar_Clave.Text = "Aceptar";
            this._Bt_Aceptar_Clave.UseVisualStyleBackColor = true;
            this._Bt_Aceptar_Clave.Click += new System.EventHandler(this._Bt_Aceptar_Clave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 68;
            this.label3.Text = "Clave:";
            // 
            // _Txt_Clave
            // 
            this._Txt_Clave.Location = new System.Drawing.Point(51, 26);
            this._Txt_Clave.Name = "_Txt_Clave";
            this._Txt_Clave.PasswordChar = '*';
            this._Txt_Clave.Size = new System.Drawing.Size(139, 20);
            this._Txt_Clave.TabIndex = 2;
            // 
            // _Cancelar_Clave
            // 
            this._Cancelar_Clave.Location = new System.Drawing.Point(131, 52);
            this._Cancelar_Clave.Name = "_Cancelar_Clave";
            this._Cancelar_Clave.Size = new System.Drawing.Size(59, 20);
            this._Cancelar_Clave.TabIndex = 1;
            this._Cancelar_Clave.Text = "Cancelar";
            this._Cancelar_Clave.UseVisualStyleBackColor = true;
            this._Cancelar_Clave.Click += new System.EventHandler(this._Cancelar_Clave_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Introduzca Clave";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Bt_Aceptar2
            // 
            this._Bt_Aceptar2.Location = new System.Drawing.Point(424, 167);
            this._Bt_Aceptar2.Name = "_Bt_Aceptar2";
            this._Bt_Aceptar2.Size = new System.Drawing.Size(86, 26);
            this._Bt_Aceptar2.TabIndex = 73;
            this._Bt_Aceptar2.Text = "Aceptar";
            this._Bt_Aceptar2.UseVisualStyleBackColor = true;
            this._Bt_Aceptar2.Click += new System.EventHandler(this._Bt_Aceptar2_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Producto";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 75;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Descripción";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 88;
            // 
            // Column3
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column3.HeaderText = "Cajas Pedidas";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 99;
            // 
            // unidadesped
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.unidadesped.DefaultCellStyle = dataGridViewCellStyle2;
            this.unidadesped.HeaderText = "Unidades Pedidas";
            this.unidadesped.Name = "unidadesped";
            this.unidadesped.ReadOnly = true;
            this.unidadesped.Width = 108;
            // 
            // Column4
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column4.HeaderText = "Cajas Descargadas";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 114;
            // 
            // unidaddescar
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.unidaddescar.DefaultCellStyle = dataGridViewCellStyle4;
            this.unidaddescar.HeaderText = "Unidades Descargadas";
            this.unidaddescar.Name = "unidaddescar";
            this.unidaddescar.ReadOnly = true;
            this.unidaddescar.Width = 131;
            // 
            // Column5
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column5.HeaderText = "Diferencia Cajas";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // diferund
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.diferund.DefaultCellStyle = dataGridViewCellStyle6;
            this.diferund.HeaderText = "Diferencia Unidades";
            this.diferund.Name = "diferund";
            this.diferund.ReadOnly = true;
            this.diferund.Width = 117;
            // 
            // Frm_Vista_Ascii
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 197);
            this.Controls.Add(this._Bt_Aceptar2);
            this.Controls.Add(this._Pnl_Clave);
            this.Controls.Add(this._Bt_Cancelar);
            this.Controls.Add(this._Bt_Aceptar);
            this.Controls.Add(this._Dg_Grid2);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_Vista_Ascii";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Descarga";
            this.Load += new System.EventHandler(this.Frm_Vista_Ascii_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid2)).EndInit();
            this._Pnl_Clave.ResumeLayout(false);
            this._Pnl_Clave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _Dg_Grid2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _Bt_Aceptar;
        private System.Windows.Forms.Button _Bt_Cancelar;
        private System.Windows.Forms.Panel _Pnl_Clave;
        private System.Windows.Forms.Button _Bt_Aceptar_Clave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _Txt_Clave;
        private System.Windows.Forms.Button _Cancelar_Clave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _Bt_Aceptar2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadesped;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidaddescar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn diferund;
    }
}