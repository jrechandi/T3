namespace T3
{
    partial class Frm_Inf_OrdenPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Inf_OrdenPago));
            this.panel1 = new System.Windows.Forms.Panel();
            this._Cmb_Proveedor = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this._Cmb_CategProv = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this._Cmb_TipoProv = new System.Windows.Forms.ComboBox();
            this._Bt_Find = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this._Rpt_Report = new Microsoft.Reporting.WinForms.ReportViewer();
            this._Rb_Can = new System.Windows.Forms.RadioButton();
            this._Rb_Pen = new System.Windows.Forms.RadioButton();
            this._Ctrl_ConsultaMes1 = new T3.Controles._Ctrl_ConsultaMes();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Ctrl_ConsultaMes1);
            this.panel1.Controls.Add(this._Rb_Can);
            this.panel1.Controls.Add(this._Cmb_Proveedor);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this._Cmb_CategProv);
            this.panel1.Controls.Add(this._Rb_Pen);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this._Cmb_TipoProv);
            this.panel1.Controls.Add(this._Bt_Find);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 117);
            this.panel1.TabIndex = 7;
            // 
            // _Cmb_Proveedor
            // 
            this._Cmb_Proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Proveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Proveedor.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Proveedor.FormattingEnabled = true;
            this._Cmb_Proveedor.Location = new System.Drawing.Point(368, 31);
            this._Cmb_Proveedor.Name = "_Cmb_Proveedor";
            this._Cmb_Proveedor.Size = new System.Drawing.Size(247, 20);
            this._Cmb_Proveedor.TabIndex = 35;
            this._Cmb_Proveedor.DropDown += new System.EventHandler(this._Cmb_Proveedor_DropDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(366, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "Proveedor:";
            // 
            // _Cmb_CategProv
            // 
            this._Cmb_CategProv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_CategProv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_CategProv.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_CategProv.FormattingEnabled = true;
            this._Cmb_CategProv.Location = new System.Drawing.Point(158, 31);
            this._Cmb_CategProv.Name = "_Cmb_CategProv";
            this._Cmb_CategProv.Size = new System.Drawing.Size(202, 20);
            this._Cmb_CategProv.TabIndex = 33;
            this._Cmb_CategProv.SelectedIndexChanged += new System.EventHandler(this._Cmb_CategProv_SelectedIndexChanged);
            this._Cmb_CategProv.DropDown += new System.EventHandler(this._Cmb_CategProv_DropDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(156, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Categoría:";
            // 
            // _Cmb_TipoProv
            // 
            this._Cmb_TipoProv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_TipoProv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_TipoProv.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_TipoProv.FormattingEnabled = true;
            this._Cmb_TipoProv.Location = new System.Drawing.Point(14, 31);
            this._Cmb_TipoProv.Name = "_Cmb_TipoProv";
            this._Cmb_TipoProv.Size = new System.Drawing.Size(138, 20);
            this._Cmb_TipoProv.TabIndex = 31;
            this._Cmb_TipoProv.SelectedIndexChanged += new System.EventHandler(this._Cmb_TipoProv_SelectedIndexChanged);
            // 
            // _Bt_Find
            // 
            this._Bt_Find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Find.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Find.Image")));
            this._Bt_Find.Location = new System.Drawing.Point(555, 57);
            this._Bt_Find.Name = "_Bt_Find";
            this._Bt_Find.Size = new System.Drawing.Size(60, 51);
            this._Bt_Find.TabIndex = 25;
            this._Bt_Find.UseVisualStyleBackColor = true;
            this._Bt_Find.Click += new System.EventHandler(this._Bt_Find_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Tipo:";
            // 
            // _Rpt_Report
            // 
            this._Rpt_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Rpt_Report.Location = new System.Drawing.Point(0, 117);
            this._Rpt_Report.Name = "_Rpt_Report";
            this._Rpt_Report.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this._Rpt_Report.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this._Rpt_Report.ShowParameterPrompts = false;
            this._Rpt_Report.Size = new System.Drawing.Size(934, 379);
            this._Rpt_Report.TabIndex = 8;
            // 
            // _Rb_Can
            // 
            this._Rb_Can.AutoSize = true;
            this._Rb_Can.Checked = true;
            this._Rb_Can.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Rb_Can.Location = new System.Drawing.Point(407, 65);
            this._Rb_Can.Name = "_Rb_Can";
            this._Rb_Can.Size = new System.Drawing.Size(99, 17);
            this._Rb_Can.TabIndex = 29;
            this._Rb_Can.TabStop = true;
            this._Rb_Can.Text = "Canceladas";
            this._Rb_Can.UseVisualStyleBackColor = true;
            // 
            // _Rb_Pen
            // 
            this._Rb_Pen.AutoSize = true;
            this._Rb_Pen.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Rb_Pen.Location = new System.Drawing.Point(407, 87);
            this._Rb_Pen.Name = "_Rb_Pen";
            this._Rb_Pen.Size = new System.Drawing.Size(97, 17);
            this._Rb_Pen.TabIndex = 26;
            this._Rb_Pen.Text = "Pendientes";
            this._Rb_Pen.UseVisualStyleBackColor = true;
            // 
            // _Ctrl_ConsultaMes1
            // 
            this._Ctrl_ConsultaMes1.Location = new System.Drawing.Point(3, 57);
            this._Ctrl_ConsultaMes1.Name = "_Ctrl_ConsultaMes1";
            this._Ctrl_ConsultaMes1.Size = new System.Drawing.Size(377, 59);
            this._Ctrl_ConsultaMes1.TabIndex = 36;
            // 
            // Frm_Inf_OrdenPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 496);
            this.Controls.Add(this._Rpt_Report);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Inf_OrdenPago";
            this.Text = "Informes - Orden de Pago";
            this.Load += new System.EventHandler(this.Frm_Inf_OrdenPago_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer _Rpt_Report;
        private System.Windows.Forms.ComboBox _Cmb_Proveedor;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox _Cmb_CategProv;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox _Cmb_TipoProv;
        private System.Windows.Forms.Button _Bt_Find;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton _Rb_Can;
        private System.Windows.Forms.RadioButton _Rb_Pen;
        private T3.Controles._Ctrl_ConsultaMes _Ctrl_ConsultaMes1;
    }
}