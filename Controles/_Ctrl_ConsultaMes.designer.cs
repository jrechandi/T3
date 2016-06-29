namespace T3.Controles
{
    partial class _Ctrl_ConsultaMes
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this._Cmb_Year = new System.Windows.Forms.ComboBox();
            this._Rb_Rango = new System.Windows.Forms.RadioButton();
            this._Lbl_Year = new System.Windows.Forms.Label();
            this._Rb_Mes = new System.Windows.Forms.RadioButton();
            this._Cmb_Month = new System.Windows.Forms.ComboBox();
            this._Lbl_Month = new System.Windows.Forms.Label();
            this._Dtp_Hasta = new System.Windows.Forms.DateTimePicker();
            this._Dtp_Desde = new System.Windows.Forms.DateTimePicker();
            this._Lbl_Desde = new System.Windows.Forms.Label();
            this._Lbl_Hasta = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._Cmb_Year);
            this.panel2.Controls.Add(this._Rb_Rango);
            this.panel2.Controls.Add(this._Lbl_Year);
            this.panel2.Controls.Add(this._Rb_Mes);
            this.panel2.Controls.Add(this._Cmb_Month);
            this.panel2.Controls.Add(this._Lbl_Month);
            this.panel2.Controls.Add(this._Dtp_Hasta);
            this.panel2.Controls.Add(this._Dtp_Desde);
            this.panel2.Controls.Add(this._Lbl_Desde);
            this.panel2.Controls.Add(this._Lbl_Hasta);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(373, 55);
            this.panel2.TabIndex = 69;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // _Cmb_Year
            // 
            this._Cmb_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Year.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Year.FormattingEnabled = true;
            this._Cmb_Year.Location = new System.Drawing.Point(42, 26);
            this._Cmb_Year.Name = "_Cmb_Year";
            this._Cmb_Year.Size = new System.Drawing.Size(74, 21);
            this._Cmb_Year.TabIndex = 59;
            this._Cmb_Year.SelectedIndexChanged += new System.EventHandler(this._Cmb_Year_SelectedIndexChanged);
            this._Cmb_Year.DropDown += new System.EventHandler(this._Cmb_Year_DropDown);
            // 
            // _Rb_Rango
            // 
            this._Rb_Rango.AutoSize = true;
            this._Rb_Rango.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Rb_Rango.Location = new System.Drawing.Point(150, 3);
            this._Rb_Rango.Name = "_Rb_Rango";
            this._Rb_Rango.Size = new System.Drawing.Size(216, 17);
            this._Rb_Rango.TabIndex = 65;
            this._Rb_Rango.Text = "Consulta por rango de fechas";
            this._Rb_Rango.UseVisualStyleBackColor = true;
            // 
            // _Lbl_Year
            // 
            this._Lbl_Year.AutoSize = true;
            this._Lbl_Year.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Lbl_Year.Location = new System.Drawing.Point(7, 29);
            this._Lbl_Year.Name = "_Lbl_Year";
            this._Lbl_Year.Size = new System.Drawing.Size(36, 13);
            this._Lbl_Year.TabIndex = 60;
            this._Lbl_Year.Text = "Año:";
            // 
            // _Rb_Mes
            // 
            this._Rb_Mes.AutoSize = true;
            this._Rb_Mes.Checked = true;
            this._Rb_Mes.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Rb_Mes.Location = new System.Drawing.Point(6, 3);
            this._Rb_Mes.Name = "_Rb_Mes";
            this._Rb_Mes.Size = new System.Drawing.Size(138, 17);
            this._Rb_Mes.TabIndex = 64;
            this._Rb_Mes.TabStop = true;
            this._Rb_Mes.Text = "Consulta por mes";
            this._Rb_Mes.UseVisualStyleBackColor = true;
            this._Rb_Mes.CheckedChanged += new System.EventHandler(this._Rb_Mes_CheckedChanged);
            // 
            // _Cmb_Month
            // 
            this._Cmb_Month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Month.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Month.FormattingEnabled = true;
            this._Cmb_Month.Location = new System.Drawing.Point(165, 26);
            this._Cmb_Month.Name = "_Cmb_Month";
            this._Cmb_Month.Size = new System.Drawing.Size(132, 21);
            this._Cmb_Month.TabIndex = 61;
            this._Cmb_Month.DropDown += new System.EventHandler(this._Cmb_Month_DropDown);
            // 
            // _Lbl_Month
            // 
            this._Lbl_Month.AutoSize = true;
            this._Lbl_Month.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Lbl_Month.Location = new System.Drawing.Point(131, 29);
            this._Lbl_Month.Name = "_Lbl_Month";
            this._Lbl_Month.Size = new System.Drawing.Size(36, 13);
            this._Lbl_Month.TabIndex = 62;
            this._Lbl_Month.Text = "Mes:";
            // 
            // _Dtp_Hasta
            // 
            this._Dtp_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dtp_Hasta.Location = new System.Drawing.Point(201, 26);
            this._Dtp_Hasta.Name = "_Dtp_Hasta";
            this._Dtp_Hasta.Size = new System.Drawing.Size(97, 20);
            this._Dtp_Hasta.TabIndex = 1;
            this._Dtp_Hasta.Value = new System.DateTime(2008, 5, 28, 0, 0, 0, 0);
            this._Dtp_Hasta.Visible = false;
            this._Dtp_Hasta.ValueChanged += new System.EventHandler(this._Dtp_Hasta_ValueChanged);
            // 
            // _Dtp_Desde
            // 
            this._Dtp_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dtp_Desde.Location = new System.Drawing.Point(55, 26);
            this._Dtp_Desde.Name = "_Dtp_Desde";
            this._Dtp_Desde.Size = new System.Drawing.Size(97, 20);
            this._Dtp_Desde.TabIndex = 2;
            this._Dtp_Desde.Value = new System.DateTime(2008, 5, 28, 0, 0, 0, 0);
            this._Dtp_Desde.Visible = false;
            // 
            // _Lbl_Desde
            // 
            this._Lbl_Desde.AutoSize = true;
            this._Lbl_Desde.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Lbl_Desde.Location = new System.Drawing.Point(7, 29);
            this._Lbl_Desde.Name = "_Lbl_Desde";
            this._Lbl_Desde.Size = new System.Drawing.Size(51, 13);
            this._Lbl_Desde.TabIndex = 39;
            this._Lbl_Desde.Text = "Desde:";
            this._Lbl_Desde.Visible = false;
            // 
            // _Lbl_Hasta
            // 
            this._Lbl_Hasta.AutoSize = true;
            this._Lbl_Hasta.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Lbl_Hasta.Location = new System.Drawing.Point(156, 29);
            this._Lbl_Hasta.Name = "_Lbl_Hasta";
            this._Lbl_Hasta.Size = new System.Drawing.Size(48, 13);
            this._Lbl_Hasta.TabIndex = 42;
            this._Lbl_Hasta.Text = "Hasta:";
            this._Lbl_Hasta.Visible = false;
            // 
            // _Ctrl_ConsultaMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "_Ctrl_ConsultaMes";
            this.Size = new System.Drawing.Size(377, 59);
            this.Load += new System.EventHandler(this._Ctrl_ConsultaMes_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label _Lbl_Year;
        private System.Windows.Forms.Label _Lbl_Month;
        private System.Windows.Forms.Label _Lbl_Hasta;
        private System.Windows.Forms.Label _Lbl_Desde;
        public System.Windows.Forms.ComboBox _Cmb_Year;
        public System.Windows.Forms.ComboBox _Cmb_Month;
        public System.Windows.Forms.RadioButton _Rb_Rango;
        public System.Windows.Forms.RadioButton _Rb_Mes;
        public System.Windows.Forms.DateTimePicker _Dtp_Hasta;
        public System.Windows.Forms.DateTimePicker _Dtp_Desde;
    }
}
