namespace T3
{
    partial class Frm_Inf_VentasAcumProdvend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Inf_VentasAcumProdvend));
            this.panel1 = new System.Windows.Forms.Panel();
            this._Bt_Find = new System.Windows.Forms.Button();
            this._Bt_Limpiar = new System.Windows.Forms.Button();
            this._Ctrl_ConsultaMes1 = new T3.Controles._Ctrl_ConsultaMes();
            this._Rb_Inact = new System.Windows.Forms.RadioButton();
            this._Rb_Act = new System.Windows.Forms.RadioButton();
            this._Cb_Vendedor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._Txt_Proveedor = new System.Windows.Forms.TextBox();
            this._Bt_Buscar = new System.Windows.Forms.Button();
            this._Rpt_Report = new Microsoft.Reporting.WinForms.ReportViewer();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Bt_Find);
            this.panel1.Controls.Add(this._Bt_Limpiar);
            this.panel1.Controls.Add(this._Ctrl_ConsultaMes1);
            this.panel1.Controls.Add(this._Rb_Inact);
            this.panel1.Controls.Add(this._Rb_Act);
            this.panel1.Controls.Add(this._Cb_Vendedor);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._Txt_Proveedor);
            this.panel1.Controls.Add(this._Bt_Buscar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 128);
            this.panel1.TabIndex = 7;
            // 
            // _Bt_Find
            // 
            this._Bt_Find.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Find.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this._Bt_Find.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Find.Image")));
            this._Bt_Find.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Find.Location = new System.Drawing.Point(492, 27);
            this._Bt_Find.Name = "_Bt_Find";
            this._Bt_Find.Size = new System.Drawing.Size(118, 26);
            this._Bt_Find.TabIndex = 123;
            this._Bt_Find.Text = "Consultar";
            this._Bt_Find.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Find.UseVisualStyleBackColor = true;
            this._Bt_Find.Click += new System.EventHandler(this._Bt_Consultar_Click);
            // 
            // _Bt_Limpiar
            // 
            this._Bt_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Limpiar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this._Er_Error.SetIconAlignment(this._Bt_Limpiar, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this._Bt_Limpiar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Limpiar.Image")));
            this._Bt_Limpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Limpiar.Location = new System.Drawing.Point(347, 27);
            this._Bt_Limpiar.Name = "_Bt_Limpiar";
            this._Bt_Limpiar.Size = new System.Drawing.Size(139, 26);
            this._Bt_Limpiar.TabIndex = 118;
            this._Bt_Limpiar.Text = "Limpiar filtro";
            this._Bt_Limpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Limpiar.UseVisualStyleBackColor = true;
            this._Bt_Limpiar.Click += new System.EventHandler(this._Bt_Limpiar_Click);
            // 
            // _Ctrl_ConsultaMes1
            // 
            this._Ctrl_ConsultaMes1.Location = new System.Drawing.Point(3, 3);
            this._Ctrl_ConsultaMes1.Name = "_Ctrl_ConsultaMes1";
            this._Ctrl_ConsultaMes1.Size = new System.Drawing.Size(377, 59);
            this._Ctrl_ConsultaMes1.TabIndex = 122;
            // 
            // _Rb_Inact
            // 
            this._Rb_Inact.AutoSize = true;
            this._Rb_Inact.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Rb_Inact.Location = new System.Drawing.Point(522, 70);
            this._Rb_Inact.Name = "_Rb_Inact";
            this._Rb_Inact.Size = new System.Drawing.Size(70, 16);
            this._Rb_Inact.TabIndex = 121;
            this._Rb_Inact.Text = "Inactivos";
            this._Rb_Inact.UseVisualStyleBackColor = true;
            // 
            // _Rb_Act
            // 
            this._Rb_Act.AutoSize = true;
            this._Rb_Act.Checked = true;
            this._Rb_Act.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Rb_Act.Location = new System.Drawing.Point(456, 70);
            this._Rb_Act.Name = "_Rb_Act";
            this._Rb_Act.Size = new System.Drawing.Size(61, 16);
            this._Rb_Act.TabIndex = 120;
            this._Rb_Act.TabStop = true;
            this._Rb_Act.Text = "Activos";
            this._Rb_Act.UseVisualStyleBackColor = true;
            this._Rb_Act.CheckedChanged += new System.EventHandler(this._Rb_Act_CheckedChanged);
            // 
            // _Cb_Vendedor
            // 
            this._Cb_Vendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_Vendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_Vendedor.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cb_Vendedor.FormattingEnabled = true;
            this._Cb_Vendedor.Location = new System.Drawing.Point(88, 67);
            this._Cb_Vendedor.Name = "_Cb_Vendedor";
            this._Cb_Vendedor.Size = new System.Drawing.Size(362, 20);
            this._Cb_Vendedor.TabIndex = 117;
            this._Cb_Vendedor.DropDown += new System.EventHandler(this._Cb_Vendedor_DropDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(5, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 116;
            this.label5.Text = "Vendedor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(5, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 115;
            this.label1.Text = "Proveedor:";
            // 
            // _Txt_Proveedor
            // 
            this._Txt_Proveedor.BackColor = System.Drawing.SystemColors.HighlightText;
            this._Txt_Proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Proveedor.Location = new System.Drawing.Point(88, 100);
            this._Txt_Proveedor.Name = "_Txt_Proveedor";
            this._Txt_Proveedor.ReadOnly = true;
            this._Txt_Proveedor.Size = new System.Drawing.Size(362, 20);
            this._Txt_Proveedor.TabIndex = 107;
            // 
            // _Bt_Buscar
            // 
            this._Bt_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Buscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Buscar.Image")));
            this._Bt_Buscar.Location = new System.Drawing.Point(456, 100);
            this._Bt_Buscar.Name = "_Bt_Buscar";
            this._Bt_Buscar.Size = new System.Drawing.Size(30, 20);
            this._Bt_Buscar.TabIndex = 108;
            this._Bt_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._Bt_Buscar.UseVisualStyleBackColor = true;
            this._Bt_Buscar.Click += new System.EventHandler(this._Bt_Buscar_Click);
            // 
            // _Rpt_Report
            // 
            this._Rpt_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Rpt_Report.Location = new System.Drawing.Point(0, 128);
            this._Rpt_Report.Name = "_Rpt_Report";
            this._Rpt_Report.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this._Rpt_Report.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this._Rpt_Report.ShowParameterPrompts = false;
            this._Rpt_Report.Size = new System.Drawing.Size(934, 368);
            this._Rpt_Report.TabIndex = 8;
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // Frm_Inf_VentasAcumProdvend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 496);
            this.Controls.Add(this._Rpt_Report);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Inf_VentasAcumProdvend";
            this.Text = "Informe - Ventas por Vendedor y Producto";
            this.Load += new System.EventHandler(this.Frm_Inf_VentasAcumProdvend_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox _Txt_Proveedor;
        private System.Windows.Forms.Button _Bt_Buscar;
        private Microsoft.Reporting.WinForms.ReportViewer _Rpt_Report;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _Cb_Vendedor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button _Bt_Limpiar;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.RadioButton _Rb_Inact;
        private System.Windows.Forms.RadioButton _Rb_Act;
        private T3.Controles._Ctrl_ConsultaMes _Ctrl_ConsultaMes1;
        private System.Windows.Forms.Button _Bt_Find;
    }
}