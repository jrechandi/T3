namespace T3
{
    partial class Frm_Activar
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
            this._Pnl_Contenedor = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // _Pnl_Contenedor
            // 
            this._Pnl_Contenedor.AutoScroll = true;
            this._Pnl_Contenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Contenedor.Dock = System.Windows.Forms.DockStyle.Top;
            this._Pnl_Contenedor.Location = new System.Drawing.Point(0, 0);
            this._Pnl_Contenedor.Name = "_Pnl_Contenedor";
            this._Pnl_Contenedor.Size = new System.Drawing.Size(723, 437);
            this._Pnl_Contenedor.TabIndex = 5;
            // 
            // Frm_Activar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 437);
            this.Controls.Add(this._Pnl_Contenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Activar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Habilitación e Inhabitación de e-mails";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _Pnl_Contenedor;
    }
}