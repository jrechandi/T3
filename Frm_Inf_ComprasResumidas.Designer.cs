namespace T3
{
    partial class Frm_Inf_ComprasResumidas
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Inf_ComprasResumidas));
            this._Pnl_Filtro = new System.Windows.Forms.Panel();
            this._Dt_Desde = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this._Dt_Hasta = new System.Windows.Forms.DateTimePicker();
            this._Lkbl_Hoy = new System.Windows.Forms.LinkLabel();
            this._Lkbl_Ayer = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this._Chk_All = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this._LstChk_Prov = new System.Windows.Forms.CheckedListBox();
            this._Bt_Consulta = new System.Windows.Forms.Button();
            this._Rb_Cimp = new System.Windows.Forms.RadioButton();
            this._Rb_Simp = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Pnl_Filtro.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Pnl_Filtro
            // 
            this._Pnl_Filtro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Filtro.Controls.Add(this._Dt_Desde);
            this._Pnl_Filtro.Controls.Add(this.label4);
            this._Pnl_Filtro.Controls.Add(this._Dt_Hasta);
            this._Pnl_Filtro.Controls.Add(this._Lkbl_Hoy);
            this._Pnl_Filtro.Controls.Add(this._Lkbl_Ayer);
            this._Pnl_Filtro.Controls.Add(this.label3);
            this._Pnl_Filtro.Location = new System.Drawing.Point(311, 24);
            this._Pnl_Filtro.Name = "_Pnl_Filtro";
            this._Pnl_Filtro.Size = new System.Drawing.Size(174, 74);
            this._Pnl_Filtro.TabIndex = 17;
            // 
            // _Dt_Desde
            // 
            this._Dt_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dt_Desde.Location = new System.Drawing.Point(62, 3);
            this._Dt_Desde.Name = "_Dt_Desde";
            this._Dt_Desde.Size = new System.Drawing.Size(93, 18);
            this._Dt_Desde.TabIndex = 6;
            this._Dt_Desde.ValueChanged += new System.EventHandler(this._Dt_Desde_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Hasta:";
            // 
            // _Dt_Hasta
            // 
            this._Dt_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dt_Hasta.Location = new System.Drawing.Point(62, 27);
            this._Dt_Hasta.Name = "_Dt_Hasta";
            this._Dt_Hasta.Size = new System.Drawing.Size(93, 18);
            this._Dt_Hasta.TabIndex = 7;
            this._Dt_Hasta.ValueChanged += new System.EventHandler(this._Dt_Hasta_ValueChanged);
            // 
            // _Lkbl_Hoy
            // 
            this._Lkbl_Hoy.AutoSize = true;
            this._Lkbl_Hoy.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lkbl_Hoy.Location = new System.Drawing.Point(64, 48);
            this._Lkbl_Hoy.Name = "_Lkbl_Hoy";
            this._Lkbl_Hoy.Size = new System.Drawing.Size(29, 13);
            this._Lkbl_Hoy.TabIndex = 8;
            this._Lkbl_Hoy.TabStop = true;
            this._Lkbl_Hoy.Text = "Hoy";
            this._Lkbl_Hoy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._Lkbl_Hoy_LinkClicked);
            // 
            // _Lkbl_Ayer
            // 
            this._Lkbl_Ayer.AutoSize = true;
            this._Lkbl_Ayer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lkbl_Ayer.Location = new System.Drawing.Point(107, 48);
            this._Lkbl_Ayer.Name = "_Lkbl_Ayer";
            this._Lkbl_Ayer.Size = new System.Drawing.Size(34, 13);
            this._Lkbl_Ayer.TabIndex = 9;
            this._Lkbl_Ayer.TabStop = true;
            this._Lkbl_Ayer.Text = "Ayer";
            this._Lkbl_Ayer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._Lkbl_Ayer_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Desde:";
            // 
            // _Chk_All
            // 
            this._Chk_All.AutoSize = true;
            this._Chk_All.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Chk_All.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Chk_All.Location = new System.Drawing.Point(253, 8);
            this._Chk_All.Name = "_Chk_All";
            this._Chk_All.Size = new System.Drawing.Size(52, 16);
            this._Chk_All.TabIndex = 16;
            this._Chk_All.Text = "Todos";
            this._Chk_All.UseVisualStyleBackColor = true;
            this._Chk_All.CheckedChanged += new System.EventHandler(this._Chk_All_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "Proveedores:";
            // 
            // _LstChk_Prov
            // 
            this._LstChk_Prov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._LstChk_Prov.FormattingEnabled = true;
            this._LstChk_Prov.Location = new System.Drawing.Point(13, 24);
            this._LstChk_Prov.Name = "_LstChk_Prov";
            this._LstChk_Prov.Size = new System.Drawing.Size(292, 119);
            this._LstChk_Prov.TabIndex = 13;
            // 
            // _Bt_Consulta
            // 
            this._Bt_Consulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Consulta.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Consulta.Image")));
            this._Bt_Consulta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Consulta.Location = new System.Drawing.Point(496, 52);
            this._Bt_Consulta.Name = "_Bt_Consulta";
            this._Bt_Consulta.Size = new System.Drawing.Size(93, 46);
            this._Bt_Consulta.TabIndex = 15;
            this._Bt_Consulta.Text = "Consultar";
            this._Bt_Consulta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Consulta.UseVisualStyleBackColor = true;
            this._Bt_Consulta.Click += new System.EventHandler(this._Bt_Consulta_Click);
            // 
            // _Rb_Cimp
            // 
            this._Rb_Cimp.AutoSize = true;
            this._Rb_Cimp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Rb_Cimp.Location = new System.Drawing.Point(20, 20);
            this._Rb_Cimp.Name = "_Rb_Cimp";
            this._Rb_Cimp.Size = new System.Drawing.Size(93, 16);
            this._Rb_Cimp.TabIndex = 0;
            this._Rb_Cimp.TabStop = true;
            this._Rb_Cimp.Text = "Con Impuesto";
            this._Rb_Cimp.UseVisualStyleBackColor = true;
            // 
            // _Rb_Simp
            // 
            this._Rb_Simp.AutoSize = true;
            this._Rb_Simp.Checked = true;
            this._Rb_Simp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Rb_Simp.Location = new System.Drawing.Point(20, 3);
            this._Rb_Simp.Name = "_Rb_Simp";
            this._Rb_Simp.Size = new System.Drawing.Size(89, 16);
            this._Rb_Simp.TabIndex = 1;
            this._Rb_Simp.TabStop = true;
            this._Rb_Simp.Text = "Sin Impuesto";
            this._Rb_Simp.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Rb_Simp);
            this.panel1.Controls.Add(this._Rb_Cimp);
            this.panel1.Location = new System.Drawing.Point(311, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 39);
            this.panel1.TabIndex = 18;
            // 
            // Frm_Inf_ComprasResumidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 155);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._Pnl_Filtro);
            this.Controls.Add(this._Chk_All);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._Bt_Consulta);
            this.Controls.Add(this._LstChk_Prov);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Inf_ComprasResumidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe - Compras resumidas";
            this.Load += new System.EventHandler(this.Frm_Inf_ComprasResumidas_Load);
            this._Pnl_Filtro.ResumeLayout(false);
            this._Pnl_Filtro.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _Pnl_Filtro;
        private System.Windows.Forms.DateTimePicker _Dt_Desde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker _Dt_Hasta;
        private System.Windows.Forms.LinkLabel _Lkbl_Hoy;
        private System.Windows.Forms.LinkLabel _Lkbl_Ayer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox _Chk_All;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _Bt_Consulta;
        private System.Windows.Forms.CheckedListBox _LstChk_Prov;
        private System.Windows.Forms.RadioButton _Rb_Cimp;
        private System.Windows.Forms.RadioButton _Rb_Simp;
        private System.Windows.Forms.Panel panel1;
    }
}