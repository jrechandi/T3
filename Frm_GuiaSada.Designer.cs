namespace T3
{
    partial class Frm_GuiaSada
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
            this._Lbl_CompSada = new System.Windows.Forms.Label();
            this._Btn_Aceptar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this._Txt_GuiaSada = new System.Windows.Forms.TextBox();
            this._Btn_Cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _Lbl_CompSada
            // 
            this._Lbl_CompSada.BackColor = System.Drawing.SystemColors.Control;
            this._Lbl_CompSada.Dock = System.Windows.Forms.DockStyle.Top;
            this._Lbl_CompSada.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Lbl_CompSada.Location = new System.Drawing.Point(0, 0);
            this._Lbl_CompSada.Name = "_Lbl_CompSada";
            this._Lbl_CompSada.Size = new System.Drawing.Size(258, 34);
            this._Lbl_CompSada.TabIndex = 72;
            this._Lbl_CompSada.Text = "Compañía";
            this._Lbl_CompSada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Btn_Aceptar
            // 
            this._Btn_Aceptar.Enabled = false;
            this._Btn_Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Btn_Aceptar.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Btn_Aceptar.Location = new System.Drawing.Point(125, 68);
            this._Btn_Aceptar.Name = "_Btn_Aceptar";
            this._Btn_Aceptar.Size = new System.Drawing.Size(57, 22);
            this._Btn_Aceptar.TabIndex = 76;
            this._Btn_Aceptar.Text = "Aceptar";
            this._Btn_Aceptar.UseVisualStyleBackColor = true;
            this._Btn_Aceptar.Click += new System.EventHandler(this._Btn_Aceptar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 75;
            this.label9.Text = "Guía SADA:";
            // 
            // _Txt_GuiaSada
            // 
            this._Txt_GuiaSada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_GuiaSada.Location = new System.Drawing.Point(85, 42);
            this._Txt_GuiaSada.MaxLength = 20;
            this._Txt_GuiaSada.Name = "_Txt_GuiaSada";
            this._Txt_GuiaSada.Size = new System.Drawing.Size(160, 20);
            this._Txt_GuiaSada.TabIndex = 74;
            this._Txt_GuiaSada.TextChanged += new System.EventHandler(this._Txt_GuiaSada_TextChanged);
            // 
            // _Btn_Cancelar
            // 
            this._Btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Btn_Cancelar.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Btn_Cancelar.Location = new System.Drawing.Point(188, 68);
            this._Btn_Cancelar.Name = "_Btn_Cancelar";
            this._Btn_Cancelar.Size = new System.Drawing.Size(57, 22);
            this._Btn_Cancelar.TabIndex = 73;
            this._Btn_Cancelar.Text = "Cancelar";
            this._Btn_Cancelar.UseVisualStyleBackColor = true;
            this._Btn_Cancelar.Click += new System.EventHandler(this._Btn_Cancelar_Click);
            // 
            // Frm_GuiaSada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 97);
            this.Controls.Add(this._Btn_Aceptar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this._Txt_GuiaSada);
            this.Controls.Add(this._Btn_Cancelar);
            this.Controls.Add(this._Lbl_CompSada);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_GuiaSada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_GuiaSada";
            this.Load += new System.EventHandler(this.Frm_GuiaSada_Load);
            this.Shown += new System.EventHandler(this.Frm_GuiaSada_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _Lbl_CompSada;
        private System.Windows.Forms.Button _Btn_Aceptar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button _Btn_Cancelar;
        public System.Windows.Forms.TextBox _Txt_GuiaSada;
    }
}