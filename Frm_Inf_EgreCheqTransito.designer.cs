namespace T3
{
    partial class Frm_Inf_EgreCheqTransito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Inf_EgreCheqTransito));
            this.panel1 = new System.Windows.Forms.Panel();
            this._Rb_V = new System.Windows.Forms.RadioButton();
            this._Rb_F = new System.Windows.Forms.RadioButton();
            this._Bt_Consultar = new System.Windows.Forms.Button();
            this._Rpt_Report = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Rb_V);
            this.panel1.Controls.Add(this._Rb_F);
            this.panel1.Controls.Add(this._Bt_Consultar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 68);
            this.panel1.TabIndex = 5;
            // 
            // _Rb_V
            // 
            this._Rb_V.AutoSize = true;
            this._Rb_V.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Rb_V.Location = new System.Drawing.Point(12, 36);
            this._Rb_V.Name = "_Rb_V";
            this._Rb_V.Size = new System.Drawing.Size(243, 17);
            this._Rb_V.TabIndex = 50;
            this._Rb_V.Text = "Relación de cheques en tránsito por vendedor";
            this._Rb_V.UseVisualStyleBackColor = true;
            // 
            // _Rb_F
            // 
            this._Rb_F.AutoSize = true;
            this._Rb_F.Checked = true;
            this._Rb_F.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Rb_F.Location = new System.Drawing.Point(12, 8);
            this._Rb_F.Name = "_Rb_F";
            this._Rb_F.Size = new System.Drawing.Size(225, 17);
            this._Rb_F.TabIndex = 49;
            this._Rb_F.TabStop = true;
            this._Rb_F.Text = "Relación de cheques en tránsito por fecha";
            this._Rb_F.UseVisualStyleBackColor = true;
            // 
            // _Bt_Consultar
            // 
            this._Bt_Consultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Consultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Consultar.Image")));
            this._Bt_Consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Consultar.Location = new System.Drawing.Point(282, 12);
            this._Bt_Consultar.Name = "_Bt_Consultar";
            this._Bt_Consultar.Size = new System.Drawing.Size(109, 40);
            this._Bt_Consultar.TabIndex = 48;
            this._Bt_Consultar.Text = "Consultar";
            this._Bt_Consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Consultar.UseVisualStyleBackColor = true;
            this._Bt_Consultar.Click += new System.EventHandler(this._Bt_Consultar_Click);
            // 
            // _Rpt_Report
            // 
            this._Rpt_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Rpt_Report.Location = new System.Drawing.Point(0, 68);
            this._Rpt_Report.Name = "_Rpt_Report";
            this._Rpt_Report.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this._Rpt_Report.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this._Rpt_Report.ShowParameterPrompts = false;
            this._Rpt_Report.Size = new System.Drawing.Size(934, 428);
            this._Rpt_Report.TabIndex = 6;
            // 
            // Frm_Inf_EgreCheqTransito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 496);
            this.Controls.Add(this._Rpt_Report);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Inf_EgreCheqTransito";
            this.Text = "Informe - Relación de Cheques en Tránsito";
            this.Load += new System.EventHandler(this.Frm_Inf_EgreCheqTransito_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton _Rb_V;
        private System.Windows.Forms.RadioButton _Rb_F;
        private System.Windows.Forms.Button _Bt_Consultar;
        private Microsoft.Reporting.WinForms.ReportViewer _Rpt_Report;
    }
}