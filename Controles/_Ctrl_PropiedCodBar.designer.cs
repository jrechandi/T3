namespace T3
{
    partial class _Ctrl_PropiedCodBar
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
            this._Txt_Codigo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Num_Numero = new System.Windows.Forms.NumericUpDown();
            this._Lbl_Descripcion = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Num_Numero)).BeginInit();
            this.SuspendLayout();
            // 
            // _Txt_Codigo
            // 
            this._Txt_Codigo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._Txt_Codigo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Txt_Codigo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Txt_Codigo.ForeColor = System.Drawing.SystemColors.HighlightText;
            this._Txt_Codigo.Location = new System.Drawing.Point(0, 6);
            this._Txt_Codigo.Multiline = true;
            this._Txt_Codigo.Name = "_Txt_Codigo";
            this._Txt_Codigo.Size = new System.Drawing.Size(135, 20);
            this._Txt_Codigo.TabIndex = 1;
            this._Txt_Codigo.Text = "df";
            this._Txt_Codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this._Txt_Codigo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(135, 26);
            this.panel1.TabIndex = 2;
            // 
            // _Num_Numero
            // 
            this._Num_Numero.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Num_Numero.Location = new System.Drawing.Point(135, 33);
            this._Num_Numero.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._Num_Numero.Name = "_Num_Numero";
            this._Num_Numero.Size = new System.Drawing.Size(52, 20);
            this._Num_Numero.TabIndex = 3;
            this._Num_Numero.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _Lbl_Descripcion
            // 
            this._Lbl_Descripcion.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._Lbl_Descripcion.Dock = System.Windows.Forms.DockStyle.Top;
            this._Lbl_Descripcion.ForeColor = System.Drawing.SystemColors.HighlightText;
            this._Lbl_Descripcion.Location = new System.Drawing.Point(0, 0);
            this._Lbl_Descripcion.Name = "_Lbl_Descripcion";
            this._Lbl_Descripcion.Size = new System.Drawing.Size(187, 27);
            this._Lbl_Descripcion.TabIndex = 4;
            this._Lbl_Descripcion.Text = "label1";
            this._Lbl_Descripcion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // _Ctrl_PropiedCodBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this._Num_Numero);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._Lbl_Descripcion);
            this.Name = "_Ctrl_PropiedCodBar";
            this.Size = new System.Drawing.Size(187, 53);
            this.Load += new System.EventHandler(this._Ctrl_PropiedCodBar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Num_Numero)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox _Txt_Codigo;
        public System.Windows.Forms.NumericUpDown _Num_Numero;
        public System.Windows.Forms.Label _Lbl_Descripcion;

    }
}
