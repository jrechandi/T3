namespace T3
{
    partial class Frm_Imagen
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
            this._PBox_Imagen = new System.Windows.Forms.PictureBox();
            this._Pnl_Panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this._PBox_Imagen)).BeginInit();
            this._Pnl_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _PBox_Imagen
            // 
            this._PBox_Imagen.Location = new System.Drawing.Point(73, 78);
            this._PBox_Imagen.Name = "_PBox_Imagen";
            this._PBox_Imagen.Size = new System.Drawing.Size(294, 109);
            this._PBox_Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._PBox_Imagen.TabIndex = 1;
            this._PBox_Imagen.TabStop = false;
            // 
            // _Pnl_Panel
            // 
            this._Pnl_Panel.AutoScroll = true;
            this._Pnl_Panel.Controls.Add(this._PBox_Imagen);
            this._Pnl_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Pnl_Panel.Location = new System.Drawing.Point(0, 0);
            this._Pnl_Panel.Name = "_Pnl_Panel";
            this._Pnl_Panel.Size = new System.Drawing.Size(460, 281);
            this._Pnl_Panel.TabIndex = 2;
            // 
            // Frm_Imagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 281);
            this.Controls.Add(this._Pnl_Panel);
            this.Name = "Frm_Imagen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imágen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Imagen_Load);
            ((System.ComponentModel.ISupportInitialize)(this._PBox_Imagen)).EndInit();
            this._Pnl_Panel.ResumeLayout(false);
            this._Pnl_Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _PBox_Imagen;
        private System.Windows.Forms.Panel _Pnl_Panel;

    }
}