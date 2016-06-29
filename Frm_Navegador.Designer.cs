namespace T3
{
    partial class Frm_Navegador
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.webBrowserCobranza = new T3.Clases._Cls_ExtensionWebBrowser();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1028, 512);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Visible = false;
            // 
            // webBrowserCobranza
            // 
            this.webBrowserCobranza.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserCobranza.Location = new System.Drawing.Point(0, 0);
            this.webBrowserCobranza.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserCobranza.Name = "webBrowserCobranza";
            this.webBrowserCobranza.Size = new System.Drawing.Size(1028, 512);
            this.webBrowserCobranza.TabIndex = 0;
            this.webBrowserCobranza.Visible = false;
            this.webBrowserCobranza.Closing += new T3.Clases._Cls_ExtensionWebBrowser.ClosingEventHandler(this.webBrowserCobranza_Closing);
            // 
            // Frm_Navegador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 512);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.webBrowserCobranza);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Navegador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Navegador";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Navegador_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Navegador_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private T3.Clases._Cls_ExtensionWebBrowser webBrowserCobranza;
    }
}