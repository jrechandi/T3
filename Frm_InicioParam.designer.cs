namespace T3
{
    partial class Frm_InicioParam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_InicioParam));
            this._Cmb_Estoy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Cmb_Conectarme = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Bt_Cancelar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this._Bt_Conectar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Cmb_Estoy
            // 
            this._Cmb_Estoy.BackColor = System.Drawing.Color.Gainsboro;
            this._Cmb_Estoy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Estoy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Cmb_Estoy.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Estoy.FormattingEnabled = true;
            this._Cmb_Estoy.Location = new System.Drawing.Point(14, 44);
            this._Cmb_Estoy.Name = "_Cmb_Estoy";
            this._Cmb_Estoy.Size = new System.Drawing.Size(307, 21);
            this._Cmb_Estoy.TabIndex = 12;
            this._Cmb_Estoy.SelectedIndexChanged += new System.EventHandler(this._Cmb_Estoy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "Estoy en:";
            // 
            // _Cmb_Conectarme
            // 
            this._Cmb_Conectarme.BackColor = System.Drawing.Color.Gainsboro;
            this._Cmb_Conectarme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Conectarme.Enabled = false;
            this._Cmb_Conectarme.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Cmb_Conectarme.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Conectarme.FormattingEnabled = true;
            this._Cmb_Conectarme.Location = new System.Drawing.Point(14, 83);
            this._Cmb_Conectarme.Name = "_Cmb_Conectarme";
            this._Cmb_Conectarme.Size = new System.Drawing.Size(307, 21);
            this._Cmb_Conectarme.TabIndex = 14;
            this._Cmb_Conectarme.SelectedIndexChanged += new System.EventHandler(this._Cmb_Conectarme_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 14);
            this.label2.TabIndex = 15;
            this.label2.Text = "Conectarme a:";
            // 
            // _Bt_Cancelar
            // 
            this._Bt_Cancelar.BackColor = System.Drawing.Color.White;
            this._Bt_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Cancelar.Location = new System.Drawing.Point(251, 110);
            this._Bt_Cancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._Bt_Cancelar.Name = "_Bt_Cancelar";
            this._Bt_Cancelar.Size = new System.Drawing.Size(70, 25);
            this._Bt_Cancelar.TabIndex = 17;
            this._Bt_Cancelar.Text = "Cancelar";
            this._Bt_Cancelar.UseVisualStyleBackColor = false;
            this._Bt_Cancelar.Click += new System.EventHandler(this._Bt_Cancelar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this._Bt_Cancelar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._Bt_Conectar);
            this.panel1.Controls.Add(this._Cmb_Estoy);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._Cmb_Conectarme);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 146);
            this.panel1.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Navy;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(328, 18);
            this.label13.TabIndex = 2;
            this.label13.Text = "Parámetros de acceso";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Bt_Conectar
            // 
            this._Bt_Conectar.BackColor = System.Drawing.Color.White;
            this._Bt_Conectar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Conectar.Enabled = false;
            this._Bt_Conectar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Conectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Conectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Conectar.Image = global::T3.Properties.Resources.connect;
            this._Bt_Conectar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Conectar.Location = new System.Drawing.Point(155, 110);
            this._Bt_Conectar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._Bt_Conectar.Name = "_Bt_Conectar";
            this._Bt_Conectar.Size = new System.Drawing.Size(88, 25);
            this._Bt_Conectar.TabIndex = 16;
            this._Bt_Conectar.Text = "Conectar";
            this._Bt_Conectar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Conectar.UseVisualStyleBackColor = false;
            this._Bt_Conectar.Click += new System.EventHandler(this._Bt_Conectar_Click);
            // 
            // Frm_InicioParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 146);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_InicioParam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parámetros de acceso";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_InicioParam_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox _Cmb_Estoy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _Cmb_Conectarme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _Bt_Cancelar;
        private System.Windows.Forms.Button _Bt_Conectar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;

    }
}