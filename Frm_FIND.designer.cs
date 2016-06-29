namespace T3
{
    partial class Frm_FIND
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
            this._Cb_Opt = new System.Windows.Forms.ComboBox();
            this._Txt_Valor = new System.Windows.Forms.TextBox();
            this._Bt_Ok = new System.Windows.Forms.Button();
            this._Bt_Cancel = new System.Windows.Forms.Button();
            this._Pn_FechaRango = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._Dt_Hasta = new System.Windows.Forms.DateTimePicker();
            this._Dt_Desde = new System.Windows.Forms.DateTimePicker();
            this._Pn_TextRango = new System.Windows.Forms.Panel();
            this._Txt_Hasta = new System.Windows.Forms.TextBox();
            this._Txt_Desde = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._Pn_Fecha = new System.Windows.Forms.Panel();
            this._Dt_Fecha = new System.Windows.Forms.DateTimePicker();
            this._Pn_Bool = new System.Windows.Forms.Panel();
            this._Rb_No = new System.Windows.Forms.RadioButton();
            this._Rb_Si = new System.Windows.Forms.RadioButton();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Cb_Lista = new System.Windows.Forms.ComboBox();
            this._Lb_Etiquea = new System.Windows.Forms.Label();
            this._Pn_FechaRango.SuspendLayout();
            this._Pn_TextRango.SuspendLayout();
            this._Pn_Fecha.SuspendLayout();
            this._Pn_Bool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this.SuspendLayout();
            // 
            // _Cb_Opt
            // 
            this._Cb_Opt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_Opt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cb_Opt.Location = new System.Drawing.Point(14, 28);
            this._Cb_Opt.Name = "_Cb_Opt";
            this._Cb_Opt.Size = new System.Drawing.Size(278, 24);
            this._Cb_Opt.TabIndex = 90;
            this._Cb_Opt.SelectedIndexChanged += new System.EventHandler(this._Cb_Opt_SelectedIndexChanged);
            // 
            // _Txt_Valor
            // 
            this._Txt_Valor.BackColor = System.Drawing.Color.White;
            this._Txt_Valor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Valor.Enabled = false;
            this._Txt_Valor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Valor.Location = new System.Drawing.Point(14, 55);
            this._Txt_Valor.MaxLength = 20;
            this._Txt_Valor.Name = "_Txt_Valor";
            this._Txt_Valor.Size = new System.Drawing.Size(278, 20);
            this._Txt_Valor.TabIndex = 91;
            // 
            // _Bt_Ok
            // 
            this._Bt_Ok.Location = new System.Drawing.Point(91, 117);
            this._Bt_Ok.Name = "_Bt_Ok";
            this._Bt_Ok.Size = new System.Drawing.Size(59, 23);
            this._Bt_Ok.TabIndex = 127;
            this._Bt_Ok.Text = "Aceptar";
            this._Bt_Ok.UseVisualStyleBackColor = true;
            this._Bt_Ok.Click += new System.EventHandler(this._Bt_Ok_Click);
            // 
            // _Bt_Cancel
            // 
            this._Bt_Cancel.Location = new System.Drawing.Point(156, 117);
            this._Bt_Cancel.Name = "_Bt_Cancel";
            this._Bt_Cancel.Size = new System.Drawing.Size(59, 23);
            this._Bt_Cancel.TabIndex = 126;
            this._Bt_Cancel.Text = "Cancelar";
            this._Bt_Cancel.UseVisualStyleBackColor = true;
            this._Bt_Cancel.Click += new System.EventHandler(this._Bt_Cancel_Click);
            // 
            // _Pn_FechaRango
            // 
            this._Pn_FechaRango.Controls.Add(this.label2);
            this._Pn_FechaRango.Controls.Add(this.label1);
            this._Pn_FechaRango.Controls.Add(this._Dt_Hasta);
            this._Pn_FechaRango.Controls.Add(this._Dt_Desde);
            this._Pn_FechaRango.Location = new System.Drawing.Point(22, 55);
            this._Pn_FechaRango.Name = "_Pn_FechaRango";
            this._Pn_FechaRango.Size = new System.Drawing.Size(260, 53);
            this._Pn_FechaRango.TabIndex = 128;
            this._Pn_FechaRango.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(138, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 53;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 52;
            this.label1.Text = "Desde";
            // 
            // _Dt_Hasta
            // 
            this._Dt_Hasta.Enabled = false;
            this._Dt_Hasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Dt_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dt_Hasta.Location = new System.Drawing.Point(141, 28);
            this._Dt_Hasta.Name = "_Dt_Hasta";
            this._Dt_Hasta.Size = new System.Drawing.Size(109, 22);
            this._Dt_Hasta.TabIndex = 51;
            this._Dt_Hasta.Value = new System.DateTime(2006, 5, 8, 9, 58, 28, 125);
            // 
            // _Dt_Desde
            // 
            this._Dt_Desde.Enabled = false;
            this._Dt_Desde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Dt_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dt_Desde.Location = new System.Drawing.Point(13, 28);
            this._Dt_Desde.Name = "_Dt_Desde";
            this._Dt_Desde.Size = new System.Drawing.Size(109, 22);
            this._Dt_Desde.TabIndex = 50;
            this._Dt_Desde.Value = new System.DateTime(2006, 5, 8, 9, 58, 28, 125);
            this._Dt_Desde.ValueChanged += new System.EventHandler(this._Dt_Desde_ValueChanged);
            // 
            // _Pn_TextRango
            // 
            this._Pn_TextRango.Controls.Add(this._Txt_Hasta);
            this._Pn_TextRango.Controls.Add(this._Txt_Desde);
            this._Pn_TextRango.Controls.Add(this.label3);
            this._Pn_TextRango.Controls.Add(this.label4);
            this._Pn_TextRango.Location = new System.Drawing.Point(23, 58);
            this._Pn_TextRango.Name = "_Pn_TextRango";
            this._Pn_TextRango.Size = new System.Drawing.Size(260, 53);
            this._Pn_TextRango.TabIndex = 129;
            this._Pn_TextRango.Visible = false;
            // 
            // _Txt_Hasta
            // 
            this._Txt_Hasta.BackColor = System.Drawing.Color.White;
            this._Txt_Hasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Hasta.Enabled = false;
            this._Txt_Hasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Hasta.Location = new System.Drawing.Point(134, 28);
            this._Txt_Hasta.MaxLength = 20;
            this._Txt_Hasta.Name = "_Txt_Hasta";
            this._Txt_Hasta.Size = new System.Drawing.Size(116, 20);
            this._Txt_Hasta.TabIndex = 93;
            // 
            // _Txt_Desde
            // 
            this._Txt_Desde.BackColor = System.Drawing.Color.White;
            this._Txt_Desde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Desde.Enabled = false;
            this._Txt_Desde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Desde.Location = new System.Drawing.Point(6, 28);
            this._Txt_Desde.MaxLength = 20;
            this._Txt_Desde.Name = "_Txt_Desde";
            this._Txt_Desde.Size = new System.Drawing.Size(116, 20);
            this._Txt_Desde.TabIndex = 92;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(138, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 53;
            this.label3.Text = "Hasta";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 52;
            this.label4.Text = "Desde";
            // 
            // _Pn_Fecha
            // 
            this._Pn_Fecha.Controls.Add(this._Dt_Fecha);
            this._Pn_Fecha.Location = new System.Drawing.Point(22, 58);
            this._Pn_Fecha.Name = "_Pn_Fecha";
            this._Pn_Fecha.Size = new System.Drawing.Size(137, 39);
            this._Pn_Fecha.TabIndex = 129;
            this._Pn_Fecha.Visible = false;
            // 
            // _Dt_Fecha
            // 
            this._Dt_Fecha.Enabled = false;
            this._Dt_Fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Dt_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dt_Fecha.Location = new System.Drawing.Point(13, 11);
            this._Dt_Fecha.Name = "_Dt_Fecha";
            this._Dt_Fecha.Size = new System.Drawing.Size(109, 22);
            this._Dt_Fecha.TabIndex = 50;
            this._Dt_Fecha.Value = new System.DateTime(2006, 5, 8, 9, 58, 28, 125);
            // 
            // _Pn_Bool
            // 
            this._Pn_Bool.Controls.Add(this._Rb_No);
            this._Pn_Bool.Controls.Add(this._Rb_Si);
            this._Pn_Bool.Location = new System.Drawing.Point(22, 58);
            this._Pn_Bool.Name = "_Pn_Bool";
            this._Pn_Bool.Size = new System.Drawing.Size(104, 34);
            this._Pn_Bool.TabIndex = 130;
            this._Pn_Bool.Visible = false;
            // 
            // _Rb_No
            // 
            this._Rb_No.AutoSize = true;
            this._Rb_No.Location = new System.Drawing.Point(51, 8);
            this._Rb_No.Name = "_Rb_No";
            this._Rb_No.Size = new System.Drawing.Size(41, 17);
            this._Rb_No.TabIndex = 1;
            this._Rb_No.TabStop = true;
            this._Rb_No.Text = "NO";
            this._Rb_No.UseVisualStyleBackColor = true;
            // 
            // _Rb_Si
            // 
            this._Rb_Si.AutoSize = true;
            this._Rb_Si.Location = new System.Drawing.Point(10, 8);
            this._Rb_Si.Name = "_Rb_Si";
            this._Rb_Si.Size = new System.Drawing.Size(35, 17);
            this._Rb_Si.TabIndex = 0;
            this._Rb_Si.TabStop = true;
            this._Rb_Si.Text = "SI";
            this._Rb_Si.UseVisualStyleBackColor = true;
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // _Cb_Lista
            // 
            this._Cb_Lista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_Lista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cb_Lista.Location = new System.Drawing.Point(14, 58);
            this._Cb_Lista.Name = "_Cb_Lista";
            this._Cb_Lista.Size = new System.Drawing.Size(278, 24);
            this._Cb_Lista.TabIndex = 131;
            this._Cb_Lista.Visible = false;
            // 
            // _Lb_Etiquea
            // 
            this._Lb_Etiquea.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._Lb_Etiquea.Dock = System.Windows.Forms.DockStyle.Top;
            this._Lb_Etiquea.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._Lb_Etiquea.Location = new System.Drawing.Point(0, 0);
            this._Lb_Etiquea.Name = "_Lb_Etiquea";
            this._Lb_Etiquea.Size = new System.Drawing.Size(305, 23);
            this._Lb_Etiquea.TabIndex = 132;
            this._Lb_Etiquea.Text = "Busqueda Personalizada";
            this._Lb_Etiquea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_FIND
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(305, 146);
            this.ControlBox = false;
            this.Controls.Add(this._Lb_Etiquea);
            this.Controls.Add(this._Cb_Lista);
            this.Controls.Add(this._Pn_FechaRango);
            this.Controls.Add(this._Txt_Valor);
            this.Controls.Add(this._Bt_Ok);
            this.Controls.Add(this._Bt_Cancel);
            this.Controls.Add(this._Cb_Opt);
            this.Controls.Add(this._Pn_Fecha);
            this.Controls.Add(this._Pn_Bool);
            this.Controls.Add(this._Pn_TextRango);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Frm_FIND";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda Personalizada";
            this.Load += new System.EventHandler(this.Frm_FIND_Load);
            this._Pn_FechaRango.ResumeLayout(false);
            this._Pn_TextRango.ResumeLayout(false);
            this._Pn_TextRango.PerformLayout();
            this._Pn_Fecha.ResumeLayout(false);
            this._Pn_Bool.ResumeLayout(false);
            this._Pn_Bool.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _Cb_Opt;
        private System.Windows.Forms.TextBox _Txt_Valor;
        private System.Windows.Forms.Button _Bt_Ok;
        private System.Windows.Forms.Button _Bt_Cancel;
        private System.Windows.Forms.Panel _Pn_FechaRango;
        private System.Windows.Forms.DateTimePicker _Dt_Hasta;
        private System.Windows.Forms.DateTimePicker _Dt_Desde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel _Pn_TextRango;
        private System.Windows.Forms.TextBox _Txt_Hasta;
        private System.Windows.Forms.TextBox _Txt_Desde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel _Pn_Fecha;
        private System.Windows.Forms.DateTimePicker _Dt_Fecha;
        private System.Windows.Forms.Panel _Pn_Bool;
        private System.Windows.Forms.RadioButton _Rb_No;
        private System.Windows.Forms.RadioButton _Rb_Si;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.ComboBox _Cb_Lista;
        private System.Windows.Forms.Label _Lb_Etiquea;

    }
}