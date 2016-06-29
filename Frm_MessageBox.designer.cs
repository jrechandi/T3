namespace T3
{
    partial class Frm_MessageBox
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
            this._Lbl_Mensaje = new System.Windows.Forms.Label();
            this._Bt_Aceptar = new System.Windows.Forms.Button();
            this._Bt_Cancelar = new System.Windows.Forms.Button();
            this._PBox_Icono = new System.Windows.Forms.PictureBox();
            this._Pnl_Inferior = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this._PBox_Icono)).BeginInit();
            this._Pnl_Inferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Lbl_Mensaje
            // 
            this._Lbl_Mensaje.AutoSize = true;
            this._Lbl_Mensaje.Location = new System.Drawing.Point(67, 22);
            this._Lbl_Mensaje.Name = "_Lbl_Mensaje";
            this._Lbl_Mensaje.Size = new System.Drawing.Size(35, 13);
            this._Lbl_Mensaje.TabIndex = 0;
            this._Lbl_Mensaje.Text = "label1";
            // 
            // _Bt_Aceptar
            // 
            this._Bt_Aceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Bt_Aceptar.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this._Bt_Aceptar.Location = new System.Drawing.Point(32, 4);
            this._Bt_Aceptar.Name = "_Bt_Aceptar";
            this._Bt_Aceptar.Size = new System.Drawing.Size(75, 23);
            this._Bt_Aceptar.TabIndex = 2;
            this._Bt_Aceptar.Text = "Aceptar";
            this._Bt_Aceptar.UseVisualStyleBackColor = false;
            this._Bt_Aceptar.Click += new System.EventHandler(this._Bt_Aceptar_Click);
            // 
            // _Bt_Cancelar
            // 
            this._Bt_Cancelar.Location = new System.Drawing.Point(113, 4);
            this._Bt_Cancelar.Name = "_Bt_Cancelar";
            this._Bt_Cancelar.Size = new System.Drawing.Size(75, 23);
            this._Bt_Cancelar.TabIndex = 1;
            this._Bt_Cancelar.Text = "Cancelar";
            this._Bt_Cancelar.UseVisualStyleBackColor = true;
            this._Bt_Cancelar.Click += new System.EventHandler(this._Bt_Cancelar_Click);
            // 
            // _PBox_Icono
            // 
            this._PBox_Icono.Location = new System.Drawing.Point(12, 12);
            this._PBox_Icono.Name = "_PBox_Icono";
            this._PBox_Icono.Size = new System.Drawing.Size(40, 40);
            this._PBox_Icono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._PBox_Icono.TabIndex = 3;
            this._PBox_Icono.TabStop = false;
            // 
            // _Pnl_Inferior
            // 
            this._Pnl_Inferior.Controls.Add(this._Bt_Aceptar);
            this._Pnl_Inferior.Controls.Add(this._Bt_Cancelar);
            this._Pnl_Inferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Pnl_Inferior.Location = new System.Drawing.Point(0, 75);
            this._Pnl_Inferior.Name = "_Pnl_Inferior";
            this._Pnl_Inferior.Size = new System.Drawing.Size(224, 30);
            this._Pnl_Inferior.TabIndex = 0;
            // 
            // Frm_MessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 105);
            this.Controls.Add(this._Pnl_Inferior);
            this.Controls.Add(this._PBox_Icono);
            this.Controls.Add(this._Lbl_Mensaje);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_MessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_MessageBox";
            ((System.ComponentModel.ISupportInitialize)(this._PBox_Icono)).EndInit();
            this._Pnl_Inferior.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _Lbl_Mensaje;
        private System.Windows.Forms.Button _Bt_Aceptar;
        private System.Windows.Forms.Button _Bt_Cancelar;
        private System.Windows.Forms.PictureBox _PBox_Icono;
        private System.Windows.Forms.Panel _Pnl_Inferior;
    }
}