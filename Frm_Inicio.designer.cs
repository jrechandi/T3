namespace T3
{
    partial class Frm_Inicio
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Inicio));
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Grb_IniAux = new System.Windows.Forms.GroupBox();
            this._Bt_Cancelar = new System.Windows.Forms.Button();
            this._Bt_OkA = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._Txt_PwdUsuNew = new System.Windows.Forms.TextBox();
            this._Txt_PwdUsuNewA = new System.Windows.Forms.TextBox();
            this._Lbl_Version = new System.Windows.Forms.Label();
            this._Txt_Clave = new System.Windows.Forms.TextBox();
            this._Bt_Ok = new System.Windows.Forms.Button();
            this._Bt_Salir = new System.Windows.Forms.Button();
            this._Txt_User = new System.Windows.Forms.TextBox();
            this._Cmb_Companies = new System.Windows.Forms.ComboBox();
            this._Bt_Desconectar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this._Grb_IniAux.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // _Grb_IniAux
            // 
            this._Grb_IniAux.Controls.Add(this._Bt_Cancelar);
            this._Grb_IniAux.Controls.Add(this._Bt_OkA);
            this._Grb_IniAux.Controls.Add(this.label5);
            this._Grb_IniAux.Controls.Add(this.label4);
            this._Grb_IniAux.Controls.Add(this._Txt_PwdUsuNew);
            this._Grb_IniAux.Controls.Add(this._Txt_PwdUsuNewA);
            this._Grb_IniAux.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Grb_IniAux.ForeColor = System.Drawing.Color.Black;
            this._Grb_IniAux.Location = new System.Drawing.Point(46, 205);
            this._Grb_IniAux.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._Grb_IniAux.Name = "_Grb_IniAux";
            this._Grb_IniAux.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._Grb_IniAux.Size = new System.Drawing.Size(296, 70);
            this._Grb_IniAux.TabIndex = 31;
            this._Grb_IniAux.TabStop = false;
            this._Grb_IniAux.Text = "Usuario Nuevo";
            // 
            // _Bt_Cancelar
            // 
            this._Bt_Cancelar.BackColor = System.Drawing.Color.LightGray;
            this._Bt_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Bt_Cancelar.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Cancelar.ForeColor = System.Drawing.Color.Black;
            this._Bt_Cancelar.Location = new System.Drawing.Point(218, 37);
            this._Bt_Cancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._Bt_Cancelar.Name = "_Bt_Cancelar";
            this._Bt_Cancelar.Size = new System.Drawing.Size(59, 25);
            this._Bt_Cancelar.TabIndex = 6;
            this._Bt_Cancelar.Text = "Cancelar";
            this._Bt_Cancelar.UseVisualStyleBackColor = false;
            this._Bt_Cancelar.Click += new System.EventHandler(this._Bt_SalirA_Click);
            // 
            // _Bt_OkA
            // 
            this._Bt_OkA.BackColor = System.Drawing.Color.LightGray;
            this._Bt_OkA.Enabled = false;
            this._Bt_OkA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Bt_OkA.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_OkA.ForeColor = System.Drawing.Color.Black;
            this._Bt_OkA.Location = new System.Drawing.Point(219, 10);
            this._Bt_OkA.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._Bt_OkA.Name = "_Bt_OkA";
            this._Bt_OkA.Size = new System.Drawing.Size(58, 25);
            this._Bt_OkA.TabIndex = 5;
            this._Bt_OkA.Text = "Aceptar";
            this._Bt_OkA.UseVisualStyleBackColor = false;
            this._Bt_OkA.Click += new System.EventHandler(this._Bt_OkA_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(9, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Clave Nueva:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(7, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Repetir Clave:";
            // 
            // _Txt_PwdUsuNew
            // 
            this._Txt_PwdUsuNew.BackColor = System.Drawing.Color.White;
            this._Txt_PwdUsuNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_PwdUsuNew.Location = new System.Drawing.Point(87, 17);
            this._Txt_PwdUsuNew.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._Txt_PwdUsuNew.MaxLength = 10;
            this._Txt_PwdUsuNew.Name = "_Txt_PwdUsuNew";
            this._Txt_PwdUsuNew.PasswordChar = '.';
            this._Txt_PwdUsuNew.Size = new System.Drawing.Size(124, 18);
            this._Txt_PwdUsuNew.TabIndex = 3;
            this._Txt_PwdUsuNew.UseSystemPasswordChar = true;
            this._Txt_PwdUsuNew.TextChanged += new System.EventHandler(this._Txt_PwdUsuNew_TextChanged);
            this._Txt_PwdUsuNew.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_PwdUsuNew_KeyPress);
            // 
            // _Txt_PwdUsuNewA
            // 
            this._Txt_PwdUsuNewA.BackColor = System.Drawing.Color.White;
            this._Txt_PwdUsuNewA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_PwdUsuNewA.Enabled = false;
            this._Txt_PwdUsuNewA.Location = new System.Drawing.Point(86, 41);
            this._Txt_PwdUsuNewA.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._Txt_PwdUsuNewA.MaxLength = 10;
            this._Txt_PwdUsuNewA.Name = "_Txt_PwdUsuNewA";
            this._Txt_PwdUsuNewA.PasswordChar = '.';
            this._Txt_PwdUsuNewA.Size = new System.Drawing.Size(124, 18);
            this._Txt_PwdUsuNewA.TabIndex = 4;
            this._Txt_PwdUsuNewA.UseSystemPasswordChar = true;
            this._Txt_PwdUsuNewA.TextChanged += new System.EventHandler(this._Txt_PwdUsuNewA_TextChanged);
            this._Txt_PwdUsuNewA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_PwdUsuNewA_KeyPress);
            // 
            // _Lbl_Version
            // 
            this._Lbl_Version.AutoSize = true;
            this._Lbl_Version.BackColor = System.Drawing.Color.Transparent;
            this._Lbl_Version.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_Version.ForeColor = System.Drawing.Color.White;
            this._Lbl_Version.Location = new System.Drawing.Point(129, 171);
            this._Lbl_Version.Name = "_Lbl_Version";
            this._Lbl_Version.Size = new System.Drawing.Size(0, 16);
            this._Lbl_Version.TabIndex = 35;
            // 
            // _Txt_Clave
            // 
            this._Txt_Clave.BackColor = System.Drawing.Color.White;
            this._Txt_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Clave.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Clave.Location = new System.Drawing.Point(205, 137);
            this._Txt_Clave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._Txt_Clave.MaxLength = 20;
            this._Txt_Clave.Name = "_Txt_Clave";
            this._Txt_Clave.PasswordChar = '?';
            this._Txt_Clave.Size = new System.Drawing.Size(157, 21);
            this._Txt_Clave.TabIndex = 2;
            this._Txt_Clave.UseSystemPasswordChar = true;
            this._Txt_Clave.TextChanged += new System.EventHandler(this._Txt_Clave_TextChanged);
            this._Txt_Clave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Clave_KeyPress);
            // 
            // _Bt_Ok
            // 
            this._Bt_Ok.BackColor = System.Drawing.Color.White;
            this._Bt_Ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Ok.Enabled = false;
            this._Bt_Ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Ok.Location = new System.Drawing.Point(225, 167);
            this._Bt_Ok.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._Bt_Ok.Name = "_Bt_Ok";
            this._Bt_Ok.Size = new System.Drawing.Size(63, 25);
            this._Bt_Ok.TabIndex = 3;
            this._Bt_Ok.Text = "Aceptar";
            this._Bt_Ok.UseVisualStyleBackColor = false;
            this._Bt_Ok.Click += new System.EventHandler(this._Bt_Ok_Click);
            // 
            // _Bt_Salir
            // 
            this._Bt_Salir.BackColor = System.Drawing.Color.White;
            this._Bt_Salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Salir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Salir.Location = new System.Drawing.Point(296, 167);
            this._Bt_Salir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._Bt_Salir.Name = "_Bt_Salir";
            this._Bt_Salir.Size = new System.Drawing.Size(63, 25);
            this._Bt_Salir.TabIndex = 4;
            this._Bt_Salir.Text = "Salir";
            this._Bt_Salir.UseVisualStyleBackColor = false;
            this._Bt_Salir.Click += new System.EventHandler(this._Bt_Salir_Click);
            // 
            // _Txt_User
            // 
            this._Txt_User.BackColor = System.Drawing.Color.White;
            this._Txt_User.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_User.Enabled = false;
            this._Txt_User.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_User.Location = new System.Drawing.Point(205, 92);
            this._Txt_User.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._Txt_User.MaxLength = 20;
            this._Txt_User.Name = "_Txt_User";
            this._Txt_User.Size = new System.Drawing.Size(157, 21);
            this._Txt_User.TabIndex = 1;
            this._Txt_User.TextChanged += new System.EventHandler(this._Txt_User_TextChanged);
            this._Txt_User.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_User_KeyPress);
            // 
            // _Cmb_Companies
            // 
            this._Cmb_Companies.BackColor = System.Drawing.Color.White;
            this._Cmb_Companies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Companies.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Cmb_Companies.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Companies.FormattingEnabled = true;
            this._Cmb_Companies.Location = new System.Drawing.Point(99, 39);
            this._Cmb_Companies.Name = "_Cmb_Companies";
            this._Cmb_Companies.Size = new System.Drawing.Size(271, 21);
            this._Cmb_Companies.TabIndex = 0;
            this._Cmb_Companies.SelectedIndexChanged += new System.EventHandler(this._LBox_Companies_SelectedIndexChanged);
            this._Cmb_Companies.DropDownClosed += new System.EventHandler(this._Cmb_Companies_DropDownClosed);
            this._Cmb_Companies.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Cmb_Companies_KeyPress);
            // 
            // _Bt_Desconectar
            // 
            this._Bt_Desconectar.BackColor = System.Drawing.Color.White;
            this._Bt_Desconectar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Desconectar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Desconectar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Bt_Desconectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Desconectar.ForeColor = System.Drawing.Color.Black;
            this._Bt_Desconectar.Image = global::T3.Properties.Resources.disconnect;
            this._Bt_Desconectar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Desconectar.Location = new System.Drawing.Point(280, 3);
            this._Bt_Desconectar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._Bt_Desconectar.Name = "_Bt_Desconectar";
            this._Bt_Desconectar.Size = new System.Drawing.Size(101, 25);
            this._Bt_Desconectar.TabIndex = 36;
            this._Bt_Desconectar.Text = "Desconectar";
            this._Bt_Desconectar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Desconectar.UseVisualStyleBackColor = false;
            this._Bt_Desconectar.Visible = false;
            this._Bt_Desconectar.Click += new System.EventHandler(this._Bt_Desconectar_Click);
            // 
            // Frm_Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::T3.Properties.Resources.t3login_original;
            this.ClientSize = new System.Drawing.Size(385, 204);
            this.ControlBox = false;
            this.Controls.Add(this._Bt_Desconectar);
            this.Controls.Add(this._Bt_Salir);
            this.Controls.Add(this._Lbl_Version);
            this.Controls.Add(this._Bt_Ok);
            this.Controls.Add(this._Cmb_Companies);
            this.Controls.Add(this._Grb_IniAux);
            this.Controls.Add(this._Txt_Clave);
            this.Controls.Add(this._Txt_User);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema T3";
            this.Activated += new System.EventHandler(this.Frm_Inicio_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Inicio_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Inicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this._Grb_IniAux.ResumeLayout(false);
            this._Grb_IniAux.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.GroupBox _Grb_IniAux;
        public System.Windows.Forms.TextBox _Txt_PwdUsuNewA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox _Txt_PwdUsuNew;
        private System.Windows.Forms.Button _Bt_Cancelar;
        private System.Windows.Forms.Button _Bt_OkA;
        public System.Windows.Forms.Label _Lbl_Version;
        private System.Windows.Forms.Button _Bt_Salir;
        private System.Windows.Forms.Button _Bt_Ok;
        private System.Windows.Forms.ComboBox _Cmb_Companies;
        public System.Windows.Forms.TextBox _Txt_Clave;
        public System.Windows.Forms.TextBox _Txt_User;
        private System.Windows.Forms.Button _Bt_Desconectar;
    }
}