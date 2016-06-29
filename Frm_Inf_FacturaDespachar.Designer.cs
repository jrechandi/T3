namespace T3
{
    partial class Frm_Inf_FacturaDespachar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Inf_FacturaDespachar));
            this.panel1 = new System.Windows.Forms.Panel();
            this._Bt_Find = new System.Windows.Forms.Button();
            this._Rb_FactImpresa = new System.Windows.Forms.RadioButton();
            this._Lkbl_Ayer = new System.Windows.Forms.LinkLabel();
            this._Lkbl_Hoy = new System.Windows.Forms.LinkLabel();
            this._Dt_Hasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this._Dt_Desde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this._Rpv_Main = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this._Rb_FactNoImpresa = new System.Windows.Forms.RadioButton();
            this._Rb_Todas = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Rb_Todas);
            this.panel1.Controls.Add(this._Bt_Find);
            this.panel1.Controls.Add(this._Rb_FactNoImpresa);
            this.panel1.Controls.Add(this._Rb_FactImpresa);
            this.panel1.Controls.Add(this._Lkbl_Ayer);
            this.panel1.Controls.Add(this._Lkbl_Hoy);
            this.panel1.Controls.Add(this._Dt_Hasta);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this._Dt_Desde);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 73);
            this.panel1.TabIndex = 0;
            // 
            // _Bt_Find
            // 
            this._Bt_Find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Find.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Find.Image")));
            this._Bt_Find.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Find.Location = new System.Drawing.Point(356, 18);
            this._Bt_Find.Name = "_Bt_Find";
            this._Bt_Find.Size = new System.Drawing.Size(117, 36);
            this._Bt_Find.TabIndex = 36;
            this._Bt_Find.Text = "Consultar";
            this._Bt_Find.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Find.UseVisualStyleBackColor = true;
            this._Bt_Find.Click += new System.EventHandler(this._Bt_Find_Click);
            // 
            // _Rb_FactImpresa
            // 
            this._Rb_FactImpresa.AutoSize = true;
            this._Rb_FactImpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Rb_FactImpresa.Location = new System.Drawing.Point(209, 30);
            this._Rb_FactImpresa.Name = "_Rb_FactImpresa";
            this._Rb_FactImpresa.Size = new System.Drawing.Size(115, 16);
            this._Rb_FactImpresa.TabIndex = 34;
            this._Rb_FactImpresa.Text = "Facturas impresas";
            this._Rb_FactImpresa.UseVisualStyleBackColor = true;
            // 
            // _Lkbl_Ayer
            // 
            this._Lkbl_Ayer.AutoSize = true;
            this._Lkbl_Ayer.Enabled = false;
            this._Lkbl_Ayer.Location = new System.Drawing.Point(158, 22);
            this._Lkbl_Ayer.Name = "_Lkbl_Ayer";
            this._Lkbl_Ayer.Size = new System.Drawing.Size(29, 12);
            this._Lkbl_Ayer.TabIndex = 33;
            this._Lkbl_Ayer.TabStop = true;
            this._Lkbl_Ayer.Text = "Ayer";
            this._Lkbl_Ayer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._Lkbl_Ayer_LinkClicked);
            // 
            // _Lkbl_Hoy
            // 
            this._Lkbl_Hoy.AutoSize = true;
            this._Lkbl_Hoy.Enabled = false;
            this._Lkbl_Hoy.Location = new System.Drawing.Point(158, 42);
            this._Lkbl_Hoy.Name = "_Lkbl_Hoy";
            this._Lkbl_Hoy.Size = new System.Drawing.Size(25, 12);
            this._Lkbl_Hoy.TabIndex = 32;
            this._Lkbl_Hoy.TabStop = true;
            this._Lkbl_Hoy.Text = "Hoy";
            this._Lkbl_Hoy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._Lkbl_Hoy_LinkClicked);
            // 
            // _Dt_Hasta
            // 
            this._Dt_Hasta.Enabled = false;
            this._Dt_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dt_Hasta.Location = new System.Drawing.Point(59, 40);
            this._Dt_Hasta.Name = "_Dt_Hasta";
            this._Dt_Hasta.Size = new System.Drawing.Size(93, 18);
            this._Dt_Hasta.TabIndex = 31;
            this._Dt_Hasta.ValueChanged += new System.EventHandler(this._Dt_Hasta_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 12);
            this.label4.TabIndex = 29;
            this.label4.Text = "Hasta:";
            // 
            // _Dt_Desde
            // 
            this._Dt_Desde.Enabled = false;
            this._Dt_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dt_Desde.Location = new System.Drawing.Point(59, 16);
            this._Dt_Desde.Name = "_Dt_Desde";
            this._Dt_Desde.Size = new System.Drawing.Size(93, 18);
            this._Dt_Desde.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "Desde:";
            // 
            // _Rpv_Main
            // 
            this._Rpv_Main.ActiveViewIndex = -1;
            this._Rpv_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Rpv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Rpv_Main.Location = new System.Drawing.Point(0, 73);
            this._Rpv_Main.Name = "_Rpv_Main";
            this._Rpv_Main.SelectionFormula = "";
            this._Rpv_Main.Size = new System.Drawing.Size(821, 428);
            this._Rpv_Main.TabIndex = 17;
            this._Rpv_Main.ViewTimeSelectionFormula = "";
            // 
            // _Rb_FactNoImpresa
            // 
            this._Rb_FactNoImpresa.AutoSize = true;
            this._Rb_FactNoImpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Rb_FactNoImpresa.Location = new System.Drawing.Point(209, 49);
            this._Rb_FactNoImpresa.Name = "_Rb_FactNoImpresa";
            this._Rb_FactNoImpresa.Size = new System.Drawing.Size(130, 16);
            this._Rb_FactNoImpresa.TabIndex = 35;
            this._Rb_FactNoImpresa.Text = "Facturas no impresas";
            this._Rb_FactNoImpresa.UseVisualStyleBackColor = true;
            // 
            // _Rb_Todas
            // 
            this._Rb_Todas.AutoSize = true;
            this._Rb_Todas.Checked = true;
            this._Rb_Todas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Rb_Todas.Location = new System.Drawing.Point(209, 11);
            this._Rb_Todas.Name = "_Rb_Todas";
            this._Rb_Todas.Size = new System.Drawing.Size(53, 16);
            this._Rb_Todas.TabIndex = 37;
            this._Rb_Todas.TabStop = true;
            this._Rb_Todas.Text = "Todas";
            this._Rb_Todas.UseVisualStyleBackColor = true;
            this._Rb_Todas.CheckedChanged += new System.EventHandler(this._Rb_Todas_CheckedChanged);
            // 
            // Frm_Inf_FacturaDespachar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 501);
            this.Controls.Add(this._Rpv_Main);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Inf_FacturaDespachar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe - Facturas por despachar";
            this.Load += new System.EventHandler(this.Frm_Inf_FacturaDespachar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel _Lkbl_Ayer;
        private System.Windows.Forms.LinkLabel _Lkbl_Hoy;
        private System.Windows.Forms.DateTimePicker _Dt_Hasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker _Dt_Desde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton _Rb_FactImpresa;
        private System.Windows.Forms.Button _Bt_Find;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer _Rpv_Main;
        private System.Windows.Forms.RadioButton _Rb_Todas;
        private System.Windows.Forms.RadioButton _Rb_FactNoImpresa;
    }
}