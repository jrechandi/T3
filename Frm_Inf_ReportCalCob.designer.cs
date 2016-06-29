namespace T3
{
    partial class Frm_Inf_ReportCalCob
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
            this._Rpt_Report = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // _Rpt_Report
            // 
            this._Rpt_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Rpt_Report.Location = new System.Drawing.Point(0, 0);
            this._Rpt_Report.Name = "_Rpt_Report";
            this._Rpt_Report.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this._Rpt_Report.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this._Rpt_Report.ShowParameterPrompts = false;
            this._Rpt_Report.Size = new System.Drawing.Size(787, 447);
            this._Rpt_Report.TabIndex = 7;
            // 
            // Frm_Inf_ReportCalCob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 447);
            this.Controls.Add(this._Rpt_Report);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Inf_ReportCalCob";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculo cuota cobranza";
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer _Rpt_Report;
    }
}