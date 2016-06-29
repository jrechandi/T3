namespace T3
{
    partial class Frm_Inf_MovInvAjuste
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Inf_MovInvAjuste));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._Txt_Desde = new System.Windows.Forms.TextBox();
            this._Txt_Hasta = new System.Windows.Forms.TextBox();
            this._Bt_Limpiar_H = new System.Windows.Forms.Button();
            this._Bt_Desde = new System.Windows.Forms.Button();
            this._Bt_Hasta = new System.Windows.Forms.Button();
            this._Bt_Limpiar_D = new System.Windows.Forms.Button();
            this._Bt_Find = new System.Windows.Forms.Button();
            this._Ctrl_ConsultaMes1 = new T3.Controles._Ctrl_ConsultaMes();
            this._Bt_Limpiar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._Txt_Proveedor = new System.Windows.Forms.TextBox();
            this._Bt_Buscar = new System.Windows.Forms.Button();
            this._Rpt_Report = new Microsoft.Reporting.WinForms.ReportViewer();
            this._Chk_MME = new System.Windows.Forms.CheckBox();
            this._Chk_MMS = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Chk_MMS);
            this.panel1.Controls.Add(this._Chk_MME);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this._Bt_Find);
            this.panel1.Controls.Add(this._Ctrl_ConsultaMes1);
            this.panel1.Controls.Add(this._Bt_Limpiar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._Txt_Proveedor);
            this.panel1.Controls.Add(this._Bt_Buscar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 166);
            this.panel1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._Txt_Desde);
            this.groupBox1.Controls.Add(this._Txt_Hasta);
            this.groupBox1.Controls.Add(this._Bt_Limpiar_H);
            this.groupBox1.Controls.Add(this._Bt_Desde);
            this.groupBox1.Controls.Add(this._Bt_Hasta);
            this.groupBox1.Controls.Add(this._Bt_Limpiar_D);
            this.groupBox1.Location = new System.Drawing.Point(15, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 54);
            this.groupBox1.TabIndex = 129;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Producto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 127;
            this.label2.Text = "Desde:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(247, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 128;
            this.label3.Text = "Hasta:";
            // 
            // _Txt_Desde
            // 
            this._Txt_Desde.BackColor = System.Drawing.Color.White;
            this._Txt_Desde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Desde.Location = new System.Drawing.Point(63, 20);
            this._Txt_Desde.Name = "_Txt_Desde";
            this._Txt_Desde.ReadOnly = true;
            this._Txt_Desde.Size = new System.Drawing.Size(100, 20);
            this._Txt_Desde.TabIndex = 121;
            // 
            // _Txt_Hasta
            // 
            this._Txt_Hasta.BackColor = System.Drawing.Color.White;
            this._Txt_Hasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Hasta.Location = new System.Drawing.Point(301, 19);
            this._Txt_Hasta.Name = "_Txt_Hasta";
            this._Txt_Hasta.ReadOnly = true;
            this._Txt_Hasta.Size = new System.Drawing.Size(100, 20);
            this._Txt_Hasta.TabIndex = 122;
            // 
            // _Bt_Limpiar_H
            // 
            this._Bt_Limpiar_H.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Limpiar_H.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Limpiar_H.Image")));
            this._Bt_Limpiar_H.Location = new System.Drawing.Point(438, 20);
            this._Bt_Limpiar_H.Name = "_Bt_Limpiar_H";
            this._Bt_Limpiar_H.Size = new System.Drawing.Size(25, 18);
            this._Bt_Limpiar_H.TabIndex = 126;
            this._Bt_Limpiar_H.UseVisualStyleBackColor = true;
            this._Bt_Limpiar_H.Click += new System.EventHandler(this._Bt_Limpiar_H_Click);
            // 
            // _Bt_Desde
            // 
            this._Bt_Desde.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Desde.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Desde.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Desde.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Desde.Image")));
            this._Bt_Desde.Location = new System.Drawing.Point(169, 21);
            this._Bt_Desde.Name = "_Bt_Desde";
            this._Bt_Desde.Size = new System.Drawing.Size(25, 18);
            this._Bt_Desde.TabIndex = 123;
            this._Bt_Desde.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._Bt_Desde.UseVisualStyleBackColor = true;
            this._Bt_Desde.Click += new System.EventHandler(this._Bt_Desde_Click);
            // 
            // _Bt_Hasta
            // 
            this._Bt_Hasta.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Hasta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Hasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Hasta.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Hasta.Image")));
            this._Bt_Hasta.Location = new System.Drawing.Point(407, 20);
            this._Bt_Hasta.Name = "_Bt_Hasta";
            this._Bt_Hasta.Size = new System.Drawing.Size(25, 18);
            this._Bt_Hasta.TabIndex = 125;
            this._Bt_Hasta.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._Bt_Hasta.UseVisualStyleBackColor = true;
            this._Bt_Hasta.Click += new System.EventHandler(this._Bt_Hasta_Click);
            // 
            // _Bt_Limpiar_D
            // 
            this._Bt_Limpiar_D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Limpiar_D.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Limpiar_D.Image")));
            this._Bt_Limpiar_D.Location = new System.Drawing.Point(200, 21);
            this._Bt_Limpiar_D.Name = "_Bt_Limpiar_D";
            this._Bt_Limpiar_D.Size = new System.Drawing.Size(25, 18);
            this._Bt_Limpiar_D.TabIndex = 124;
            this._Bt_Limpiar_D.UseVisualStyleBackColor = true;
            this._Bt_Limpiar_D.Click += new System.EventHandler(this._Bt_Limpiar_D_Click);
            // 
            // _Bt_Find
            // 
            this._Bt_Find.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Find.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this._Bt_Find.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Find.Image")));
            this._Bt_Find.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Find.Location = new System.Drawing.Point(386, 12);
            this._Bt_Find.Name = "_Bt_Find";
            this._Bt_Find.Size = new System.Drawing.Size(118, 49);
            this._Bt_Find.TabIndex = 120;
            this._Bt_Find.Text = "Consultar";
            this._Bt_Find.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Find.UseVisualStyleBackColor = true;
            this._Bt_Find.Click += new System.EventHandler(this._Bt_Find_Click);
            // 
            // _Ctrl_ConsultaMes1
            // 
            this._Ctrl_ConsultaMes1.Location = new System.Drawing.Point(3, 3);
            this._Ctrl_ConsultaMes1.Name = "_Ctrl_ConsultaMes1";
            this._Ctrl_ConsultaMes1.Size = new System.Drawing.Size(377, 59);
            this._Ctrl_ConsultaMes1.TabIndex = 119;
            // 
            // _Bt_Limpiar
            // 
            this._Bt_Limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Limpiar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Limpiar.Image")));
            this._Bt_Limpiar.Location = new System.Drawing.Point(453, 81);
            this._Bt_Limpiar.Name = "_Bt_Limpiar";
            this._Bt_Limpiar.Size = new System.Drawing.Size(25, 18);
            this._Bt_Limpiar.TabIndex = 118;
            this._Bt_Limpiar.UseVisualStyleBackColor = true;
            this._Bt_Limpiar.Click += new System.EventHandler(this._Bt_Limpiar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 115;
            this.label1.Text = "Proveedor:";
            // 
            // _Txt_Proveedor
            // 
            this._Txt_Proveedor.BackColor = System.Drawing.SystemColors.HighlightText;
            this._Txt_Proveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Proveedor.Location = new System.Drawing.Point(14, 80);
            this._Txt_Proveedor.Name = "_Txt_Proveedor";
            this._Txt_Proveedor.ReadOnly = true;
            this._Txt_Proveedor.Size = new System.Drawing.Size(402, 20);
            this._Txt_Proveedor.TabIndex = 107;
            // 
            // _Bt_Buscar
            // 
            this._Bt_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Buscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Buscar.Image")));
            this._Bt_Buscar.Location = new System.Drawing.Point(422, 81);
            this._Bt_Buscar.Name = "_Bt_Buscar";
            this._Bt_Buscar.Size = new System.Drawing.Size(25, 18);
            this._Bt_Buscar.TabIndex = 108;
            this._Bt_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._Bt_Buscar.UseVisualStyleBackColor = true;
            this._Bt_Buscar.Click += new System.EventHandler(this._Bt_Buscar_Click);
            // 
            // _Rpt_Report
            // 
            this._Rpt_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Rpt_Report.Location = new System.Drawing.Point(0, 166);
            this._Rpt_Report.Name = "_Rpt_Report";
            this._Rpt_Report.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this._Rpt_Report.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this._Rpt_Report.ShowParameterPrompts = false;
            this._Rpt_Report.Size = new System.Drawing.Size(934, 330);
            this._Rpt_Report.TabIndex = 9;
            // 
            // _Chk_MME
            // 
            this._Chk_MME.AutoSize = true;
            this._Chk_MME.Location = new System.Drawing.Point(562, 18);
            this._Chk_MME.Name = "_Chk_MME";
            this._Chk_MME.Size = new System.Drawing.Size(253, 17);
            this._Chk_MME.TabIndex = 130;
            this._Chk_MME.Text = "Ajuste de entrada por mercancía en mal estado.";
            this._Chk_MME.UseVisualStyleBackColor = true;
            // 
            // _Chk_MMS
            // 
            this._Chk_MMS.AutoSize = true;
            this._Chk_MMS.Location = new System.Drawing.Point(562, 43);
            this._Chk_MMS.Name = "_Chk_MMS";
            this._Chk_MMS.Size = new System.Drawing.Size(244, 17);
            this._Chk_MMS.TabIndex = 131;
            this._Chk_MMS.Text = "Ajuste de salida por mercancía en mal estado.";
            this._Chk_MMS.UseVisualStyleBackColor = true;
            // 
            // Frm_Inf_MovInvAjuste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 496);
            this.Controls.Add(this._Rpt_Report);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Inf_MovInvAjuste";
            this.Text = "Informe - Movimiento de Inventario";
            this.Load += new System.EventHandler(this.Frm_Inf_MovInvAjuste_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _Bt_Limpiar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _Txt_Proveedor;
        private System.Windows.Forms.Button _Bt_Buscar;
        private Microsoft.Reporting.WinForms.ReportViewer _Rpt_Report;
        private T3.Controles._Ctrl_ConsultaMes _Ctrl_ConsultaMes1;
        private System.Windows.Forms.Button _Bt_Find;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _Txt_Desde;
        private System.Windows.Forms.TextBox _Txt_Hasta;
        private System.Windows.Forms.Button _Bt_Limpiar_H;
        private System.Windows.Forms.Button _Bt_Desde;
        private System.Windows.Forms.Button _Bt_Hasta;
        private System.Windows.Forms.Button _Bt_Limpiar_D;
        private System.Windows.Forms.CheckBox _Chk_MME;
        private System.Windows.Forms.CheckBox _Chk_MMS;
    }
}