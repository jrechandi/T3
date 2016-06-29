namespace T3
{
    partial class Frm_EALCCConfig
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
            this.label3 = new System.Windows.Forms.Label();
            this._Bt_Guardar = new System.Windows.Forms.Button();
            this._Bt_Cancelar = new System.Windows.Forms.Button();
            this._Dtp_Fecha = new System.Windows.Forms.DateTimePicker();
            this._Lbl_Fecha = new System.Windows.Forms.Label();
            this._Lbl_Comentario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Navy;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Configuración - EALCC";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Bt_Guardar
            // 
            this._Bt_Guardar.BackColor = System.Drawing.SystemColors.Control;
            this._Bt_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Guardar.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Guardar.Location = new System.Drawing.Point(159, 142);
            this._Bt_Guardar.Name = "_Bt_Guardar";
            this._Bt_Guardar.Size = new System.Drawing.Size(62, 22);
            this._Bt_Guardar.TabIndex = 72;
            this._Bt_Guardar.Text = "Guardar";
            this._Bt_Guardar.UseVisualStyleBackColor = false;
            this._Bt_Guardar.Click += new System.EventHandler(this._Bt_Guardar_Click);
            // 
            // _Bt_Cancelar
            // 
            this._Bt_Cancelar.BackColor = System.Drawing.SystemColors.Control;
            this._Bt_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Cancelar.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Cancelar.Location = new System.Drawing.Point(227, 142);
            this._Bt_Cancelar.Name = "_Bt_Cancelar";
            this._Bt_Cancelar.Size = new System.Drawing.Size(62, 22);
            this._Bt_Cancelar.TabIndex = 71;
            this._Bt_Cancelar.Text = "Cancelar";
            this._Bt_Cancelar.UseVisualStyleBackColor = false;
            this._Bt_Cancelar.Click += new System.EventHandler(this._Bt_Cancelar_Click);
            // 
            // _Dtp_Fecha
            // 
            this._Dtp_Fecha.Location = new System.Drawing.Point(73, 87);
            this._Dtp_Fecha.Name = "_Dtp_Fecha";
            this._Dtp_Fecha.Size = new System.Drawing.Size(200, 20);
            this._Dtp_Fecha.TabIndex = 73;
            // 
            // _Lbl_Fecha
            // 
            this._Lbl_Fecha.AutoSize = true;
            this._Lbl_Fecha.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_Fecha.Location = new System.Drawing.Point(25, 90);
            this._Lbl_Fecha.Name = "_Lbl_Fecha";
            this._Lbl_Fecha.Size = new System.Drawing.Size(38, 12);
            this._Lbl_Fecha.TabIndex = 74;
            this._Lbl_Fecha.Text = "Fecha:";
            // 
            // _Lbl_Comentario
            // 
            this._Lbl_Comentario.Location = new System.Drawing.Point(12, 32);
            this._Lbl_Comentario.Name = "_Lbl_Comentario";
            this._Lbl_Comentario.Size = new System.Drawing.Size(277, 37);
            this._Lbl_Comentario.TabIndex = 75;
            this._Lbl_Comentario.Text = "Indique el día en que necesita que se genere el reporte y púlse Guardar.";
            // 
            // Frm_EALCCConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(304, 176);
            this.ControlBox = false;
            this.Controls.Add(this._Lbl_Comentario);
            this.Controls.Add(this._Lbl_Fecha);
            this.Controls.Add(this._Dtp_Fecha);
            this.Controls.Add(this._Bt_Guardar);
            this.Controls.Add(this._Bt_Cancelar);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_EALCCConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EALCC - Configuración";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _Bt_Guardar;
        private System.Windows.Forms.Button _Bt_Cancelar;
        private System.Windows.Forms.DateTimePicker _Dtp_Fecha;
        private System.Windows.Forms.Label _Lbl_Fecha;
        private System.Windows.Forms.Label _Lbl_Comentario;
    }
}