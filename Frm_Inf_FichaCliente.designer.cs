namespace T3
{
    partial class Frm_Inf_FichaCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Inf_FichaCliente));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this._Lkbl_Ayer = new System.Windows.Forms.LinkLabel();
            this._Lkbl_Hoy = new System.Windows.Forms.LinkLabel();
            this._Dt_Hasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this._Dt_Desde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this._Txt_Cliente = new System.Windows.Forms.TextBox();
            this._Bt_Buscar = new System.Windows.Forms.Button();
            this._Bt_Consultar = new System.Windows.Forms.Button();
            this._Rpt_Report = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._Lkbl_Ayer);
            this.panel1.Controls.Add(this._Lkbl_Hoy);
            this.panel1.Controls.Add(this._Dt_Hasta);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this._Dt_Desde);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this._Txt_Cliente);
            this.panel1.Controls.Add(this._Bt_Buscar);
            this.panel1.Controls.Add(this._Bt_Consultar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 106);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 115;
            this.label1.Text = "Cliente:";
            // 
            // _Lkbl_Ayer
            // 
            this._Lkbl_Ayer.AutoSize = true;
            this._Lkbl_Ayer.Location = new System.Drawing.Point(158, 56);
            this._Lkbl_Ayer.Name = "_Lkbl_Ayer";
            this._Lkbl_Ayer.Size = new System.Drawing.Size(28, 13);
            this._Lkbl_Ayer.TabIndex = 114;
            this._Lkbl_Ayer.TabStop = true;
            this._Lkbl_Ayer.Text = "Ayer";
            this._Lkbl_Ayer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._Lkbl_Ayer_LinkClicked);
            // 
            // _Lkbl_Hoy
            // 
            this._Lkbl_Hoy.AutoSize = true;
            this._Lkbl_Hoy.Location = new System.Drawing.Point(158, 76);
            this._Lkbl_Hoy.Name = "_Lkbl_Hoy";
            this._Lkbl_Hoy.Size = new System.Drawing.Size(26, 13);
            this._Lkbl_Hoy.TabIndex = 113;
            this._Lkbl_Hoy.TabStop = true;
            this._Lkbl_Hoy.Text = "Hoy";
            this._Lkbl_Hoy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._Lkbl_Hoy_LinkClicked);
            // 
            // _Dt_Hasta
            // 
            this._Dt_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dt_Hasta.Location = new System.Drawing.Point(59, 75);
            this._Dt_Hasta.Name = "_Dt_Hasta";
            this._Dt_Hasta.Size = new System.Drawing.Size(93, 20);
            this._Dt_Hasta.TabIndex = 112;
            this._Dt_Hasta.ValueChanged += new System.EventHandler(this._Dt_Hasta_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 12);
            this.label4.TabIndex = 110;
            this.label4.Text = "Hasta:";
            // 
            // _Dt_Desde
            // 
            this._Dt_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dt_Desde.Location = new System.Drawing.Point(59, 51);
            this._Dt_Desde.Name = "_Dt_Desde";
            this._Dt_Desde.Size = new System.Drawing.Size(93, 20);
            this._Dt_Desde.TabIndex = 111;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 12);
            this.label3.TabIndex = 109;
            this.label3.Text = "Desde:";
            // 
            // _Txt_Cliente
            // 
            this._Txt_Cliente.BackColor = System.Drawing.SystemColors.HighlightText;
            this._Txt_Cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Cliente.Location = new System.Drawing.Point(12, 23);
            this._Txt_Cliente.Name = "_Txt_Cliente";
            this._Txt_Cliente.ReadOnly = true;
            this._Txt_Cliente.Size = new System.Drawing.Size(362, 20);
            this._Txt_Cliente.TabIndex = 107;
            // 
            // _Bt_Buscar
            // 
            this._Bt_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Buscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Buscar.Image")));
            this._Bt_Buscar.Location = new System.Drawing.Point(380, 24);
            this._Bt_Buscar.Name = "_Bt_Buscar";
            this._Bt_Buscar.Size = new System.Drawing.Size(25, 18);
            this._Bt_Buscar.TabIndex = 108;
            this._Bt_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._Bt_Buscar.UseVisualStyleBackColor = true;
            this._Bt_Buscar.Click += new System.EventHandler(this._Bt_Buscar_Click);
            // 
            // _Bt_Consultar
            // 
            this._Bt_Consultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Consultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Consultar.Image")));
            this._Bt_Consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Consultar.Location = new System.Drawing.Point(223, 53);
            this._Bt_Consultar.Name = "_Bt_Consultar";
            this._Bt_Consultar.Size = new System.Drawing.Size(151, 40);
            this._Bt_Consultar.TabIndex = 48;
            this._Bt_Consultar.Text = "Consultar";
            this._Bt_Consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Consultar.UseVisualStyleBackColor = true;
            this._Bt_Consultar.Click += new System.EventHandler(this._Bt_Consultar_Click);
            // 
            // _Rpt_Report
            // 
            this._Rpt_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Rpt_Report.Location = new System.Drawing.Point(0, 106);
            this._Rpt_Report.Name = "_Rpt_Report";
            this._Rpt_Report.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this._Rpt_Report.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this._Rpt_Report.ShowParameterPrompts = false;
            this._Rpt_Report.Size = new System.Drawing.Size(934, 390);
            this._Rpt_Report.TabIndex = 9;
            // 
            // Frm_Inf_FichaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 496);
            this.Controls.Add(this._Rpt_Report);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Inf_FichaCliente";
            this.Text = "Informe - Ficha de Cliente";
            this.Load += new System.EventHandler(this.Frm_Inf_FichaCliente_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel _Lkbl_Ayer;
        private System.Windows.Forms.LinkLabel _Lkbl_Hoy;
        private System.Windows.Forms.DateTimePicker _Dt_Hasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker _Dt_Desde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _Txt_Cliente;
        private System.Windows.Forms.Button _Bt_Buscar;
        private System.Windows.Forms.Button _Bt_Consultar;
        private Microsoft.Reporting.WinForms.ReportViewer _Rpt_Report;
    }
}