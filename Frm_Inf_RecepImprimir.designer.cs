namespace T3
{
    partial class Frm_Inf_RecepImprimir
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Inf_RecepImprimir));
            this.panel1 = new System.Windows.Forms.Panel();
            this._Cmb_Fac = new System.Windows.Forms.ComboBox();
            this._Dt_Desde = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this._Cmb_NR = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this._Txt_Proveedor = new System.Windows.Forms.TextBox();
            this._Bt_LimpiarProveedor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this._Bt_Proveedor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._Bt_Consultar = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Cmb_Fac);
            this.panel1.Controls.Add(this._Dt_Desde);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this._Cmb_NR);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this._Txt_Proveedor);
            this.panel1.Controls.Add(this._Bt_LimpiarProveedor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this._Bt_Proveedor);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._Bt_Consultar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(887, 142);
            this.panel1.TabIndex = 6;
            // 
            // _Cmb_Fac
            // 
            this._Cmb_Fac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Fac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Fac.FormattingEnabled = true;
            this._Cmb_Fac.Location = new System.Drawing.Point(7, 105);
            this._Cmb_Fac.Name = "_Cmb_Fac";
            this._Cmb_Fac.Size = new System.Drawing.Size(212, 21);
            this._Cmb_Fac.TabIndex = 150;
            // 
            // _Dt_Desde
            // 
            this._Dt_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dt_Desde.Location = new System.Drawing.Point(126, 61);
            this._Dt_Desde.Name = "_Dt_Desde";
            this._Dt_Desde.Size = new System.Drawing.Size(93, 20);
            this._Dt_Desde.TabIndex = 147;
            this._Dt_Desde.ValueChanged += new System.EventHandler(this._Dt_Desde_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(123, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 148;
            this.label4.Text = "Desde :";
            // 
            // _Cmb_NR
            // 
            this._Cmb_NR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_NR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Cmb_NR.FormattingEnabled = true;
            this._Cmb_NR.Location = new System.Drawing.Point(7, 61);
            this._Cmb_NR.Name = "_Cmb_NR";
            this._Cmb_NR.Size = new System.Drawing.Size(100, 21);
            this._Cmb_NR.TabIndex = 146;
            this._Cmb_NR.SelectedIndexChanged += new System.EventHandler(this._Cmb_NR_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 145;
            this.label5.Text = " N.R. # :";
            // 
            // _Txt_Proveedor
            // 
            this._Txt_Proveedor.BackColor = System.Drawing.SystemColors.HighlightText;
            this._Txt_Proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Proveedor.Location = new System.Drawing.Point(6, 20);
            this._Txt_Proveedor.Name = "_Txt_Proveedor";
            this._Txt_Proveedor.ReadOnly = true;
            this._Txt_Proveedor.Size = new System.Drawing.Size(149, 20);
            this._Txt_Proveedor.TabIndex = 141;
            // 
            // _Bt_LimpiarProveedor
            // 
            this._Bt_LimpiarProveedor.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_LimpiarProveedor.Image")));
            this._Bt_LimpiarProveedor.Location = new System.Drawing.Point(194, 21);
            this._Bt_LimpiarProveedor.Name = "_Bt_LimpiarProveedor";
            this._Bt_LimpiarProveedor.Size = new System.Drawing.Size(25, 18);
            this._Bt_LimpiarProveedor.TabIndex = 144;
            this._Bt_LimpiarProveedor.UseVisualStyleBackColor = true;
            this._Bt_LimpiarProveedor.Click += new System.EventHandler(this._Bt_LimpiarProveedor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 143;
            this.label3.Text = "Proveedor :";
            // 
            // _Bt_Proveedor
            // 
            this._Bt_Proveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Proveedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Proveedor.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Proveedor.Image")));
            this._Bt_Proveedor.Location = new System.Drawing.Point(161, 21);
            this._Bt_Proveedor.Name = "_Bt_Proveedor";
            this._Bt_Proveedor.Size = new System.Drawing.Size(25, 18);
            this._Bt_Proveedor.TabIndex = 142;
            this._Bt_Proveedor.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._Bt_Proveedor.UseVisualStyleBackColor = true;
            this._Bt_Proveedor.Click += new System.EventHandler(this._Bt_Proveedor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 139;
            this.label2.Text = "Factura :";
            // 
            // _Bt_Consultar
            // 
            this._Bt_Consultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Consultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Consultar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this._Bt_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Consultar.Image")));
            this._Bt_Consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Consultar.Location = new System.Drawing.Point(272, 45);
            this._Bt_Consultar.Name = "_Bt_Consultar";
            this._Bt_Consultar.Size = new System.Drawing.Size(122, 41);
            this._Bt_Consultar.TabIndex = 48;
            this._Bt_Consultar.Text = "Consultar";
            this._Bt_Consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Consultar.UseVisualStyleBackColor = true;
            this._Bt_Consultar.Click += new System.EventHandler(this._Bt_Consultar_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 142);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.reportViewer1.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this.reportViewer1.ShowParameterPrompts = false;
            this.reportViewer1.Size = new System.Drawing.Size(887, 251);
            this.reportViewer1.TabIndex = 7;
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // Frm_Inf_RecepImprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 393);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "Frm_Inf_RecepImprimir";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recepción de mercancía con fecha de vencimiento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Inf_RecepImprimir_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox _Txt_Proveedor;
        private System.Windows.Forms.Button _Bt_LimpiarProveedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _Bt_Proveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _Bt_Consultar;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.DateTimePicker _Dt_Desde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox _Cmb_NR;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox _Cmb_Fac;
    }
}