namespace T3
{
    partial class Frm_Clave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Clave));
            this.label1 = new System.Windows.Forms.Label();
            this._Txt_Clave = new System.Windows.Forms.TextBox();
            this._Bt_Aceptar = new System.Windows.Forms.Button();
            this._Bt_Cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clave:";
            // 
            // _Txt_Clave
            // 
            this._Txt_Clave.Location = new System.Drawing.Point(48, 6);
            this._Txt_Clave.MaxLength = 20;
            this._Txt_Clave.Name = "_Txt_Clave";
            this._Txt_Clave.PasswordChar = '*';
            this._Txt_Clave.Size = new System.Drawing.Size(177, 20);
            this._Txt_Clave.TabIndex = 1;
            this._Txt_Clave.TextChanged += new System.EventHandler(this._Txt_Clave_TextChanged);
            // 
            // _Bt_Aceptar
            // 
            this._Bt_Aceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Aceptar.Enabled = false;
            this._Bt_Aceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Aceptar.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Aceptar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Aceptar.Image")));
            this._Bt_Aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Aceptar.Location = new System.Drawing.Point(49, 32);
            this._Bt_Aceptar.Name = "_Bt_Aceptar";
            this._Bt_Aceptar.Size = new System.Drawing.Size(85, 23);
            this._Bt_Aceptar.TabIndex = 135;
            this._Bt_Aceptar.Text = "Aceptar..";
            this._Bt_Aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Aceptar.UseVisualStyleBackColor = true;
            this._Bt_Aceptar.Click += new System.EventHandler(this._Bt_Aceptar_Click);
            // 
            // _Bt_Cancelar
            // 
            this._Bt_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Cancelar.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Cancelar.Image")));
            this._Bt_Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Cancelar.Location = new System.Drawing.Point(140, 32);
            this._Bt_Cancelar.Name = "_Bt_Cancelar";
            this._Bt_Cancelar.Size = new System.Drawing.Size(85, 23);
            this._Bt_Cancelar.TabIndex = 134;
            this._Bt_Cancelar.Text = "Cancelar..";
            this._Bt_Cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Cancelar.UseVisualStyleBackColor = true;
            this._Bt_Cancelar.Click += new System.EventHandler(this._Bt_Cancelar_Click);
            // 
            // Frm_Clave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 59);
            this.Controls.Add(this._Bt_Aceptar);
            this.Controls.Add(this._Bt_Cancelar);
            this.Controls.Add(this._Txt_Clave);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm_Clave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Introduzca clave";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _Txt_Clave;
        private System.Windows.Forms.Button _Bt_Aceptar;
        private System.Windows.Forms.Button _Bt_Cancelar;
    }
}