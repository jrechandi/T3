namespace T3
{
    partial class Frm_ReporteRelacionCobro
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
            this._Rpv_Main = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // _Rpv_Main
            // 
            this._Rpv_Main.ActiveViewIndex = -1;
            this._Rpv_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Rpv_Main.Cursor = System.Windows.Forms.Cursors.Default;
            this._Rpv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Rpv_Main.Location = new System.Drawing.Point(0, 0);
            this._Rpv_Main.Name = "_Rpv_Main";
            this._Rpv_Main.SelectionFormula = "";
            this._Rpv_Main.ShowParameterPanelButton = false;
            this._Rpv_Main.Size = new System.Drawing.Size(896, 438);
            this._Rpv_Main.TabIndex = 23;
            this._Rpv_Main.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this._Rpv_Main.ViewTimeSelectionFormula = "";
            // 
            // Frm_ReporteRelacionCobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 438);
            this.Controls.Add(this._Rpv_Main);
            this.Name = "Frm_ReporteRelacionCobro";
            this.Text = "Frm_ReporteRelacionCobro";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer _Rpv_Main;
    }
}