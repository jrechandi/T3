namespace T3
{
    partial class Frm_Inf_Gestion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Inf_Gestion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this._Cmb_Day = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Cmb_Month = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this._Cmb_Year = new System.Windows.Forms.ComboBox();
            this._Bt_Consultar2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this._Bt_Consultar = new System.Windows.Forms.Button();
            this._Rpt_Report = new Microsoft.Reporting.WinForms.ReportViewer();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this._Cmb_Day);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._Cmb_Month);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this._Cmb_Year);
            this.panel1.Controls.Add(this._Bt_Consultar2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this._Bt_Consultar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1055, 51);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(446, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Dia:";
            // 
            // _Cmb_Day
            // 
            this._Cmb_Day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Day.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Day.FormattingEnabled = true;
            this._Cmb_Day.Location = new System.Drawing.Point(449, 21);
            this._Cmb_Day.Name = "_Cmb_Day";
            this._Cmb_Day.Size = new System.Drawing.Size(74, 21);
            this._Cmb_Day.TabIndex = 59;
            this._Cmb_Day.DropDown += new System.EventHandler(this._Cmb_Day_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(320, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Mes:";
            // 
            // _Cmb_Month
            // 
            this._Cmb_Month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Month.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Month.FormattingEnabled = true;
            this._Cmb_Month.Location = new System.Drawing.Point(323, 21);
            this._Cmb_Month.Name = "_Cmb_Month";
            this._Cmb_Month.Size = new System.Drawing.Size(118, 21);
            this._Cmb_Month.TabIndex = 57;
            this._Cmb_Month.SelectedIndexChanged += new System.EventHandler(this._Cmb_Month_SelectedIndexChanged);
            this._Cmb_Month.DropDown += new System.EventHandler(this._Cmb_Month_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(239, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Año:";
            // 
            // _Cmb_Year
            // 
            this._Cmb_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Year.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Year.FormattingEnabled = true;
            this._Cmb_Year.Location = new System.Drawing.Point(242, 21);
            this._Cmb_Year.Name = "_Cmb_Year";
            this._Cmb_Year.Size = new System.Drawing.Size(74, 21);
            this._Cmb_Year.TabIndex = 55;
            this._Cmb_Year.SelectedIndexChanged += new System.EventHandler(this._Cmb_Year_SelectedIndexChanged);
            this._Cmb_Year.DropDown += new System.EventHandler(this._Cmb_Year_DropDown);
            // 
            // _Bt_Consultar2
            // 
            this._Bt_Consultar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Consultar2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Consultar2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Consultar2.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Consultar2.Image")));
            this._Bt_Consultar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Consultar2.Location = new System.Drawing.Point(531, 11);
            this._Bt_Consultar2.Name = "_Bt_Consultar2";
            this._Bt_Consultar2.Size = new System.Drawing.Size(102, 31);
            this._Bt_Consultar2.TabIndex = 54;
            this._Bt_Consultar2.Text = "Consultar";
            this._Bt_Consultar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Consultar2.UseVisualStyleBackColor = true;
            this._Bt_Consultar2.Click += new System.EventHandler(this._Bt_Consultar2_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(223, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(4, 52);
            this.panel2.TabIndex = 51;
            // 
            // _Bt_Consultar
            // 
            this._Bt_Consultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Consultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Consultar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Consultar.Image")));
            this._Bt_Consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Consultar.Location = new System.Drawing.Point(12, 11);
            this._Bt_Consultar.Name = "_Bt_Consultar";
            this._Bt_Consultar.Size = new System.Drawing.Size(195, 31);
            this._Bt_Consultar.TabIndex = 48;
            this._Bt_Consultar.Text = "Consultar reporte actual";
            this._Bt_Consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Consultar.UseVisualStyleBackColor = true;
            this._Bt_Consultar.Click += new System.EventHandler(this._Bt_Consultar_Click);
            // 
            // _Rpt_Report
            // 
            this._Rpt_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Rpt_Report.Location = new System.Drawing.Point(0, 51);
            this._Rpt_Report.Name = "_Rpt_Report";
            this._Rpt_Report.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this._Rpt_Report.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this._Rpt_Report.ShowParameterPrompts = false;
            this._Rpt_Report.Size = new System.Drawing.Size(1055, 510);
            this._Rpt_Report.TabIndex = 6;
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // Frm_Inf_Gestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 561);
            this.Controls.Add(this._Rpt_Report);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Inf_Gestion";
            this.Text = "Informe de Gestion";
            this.Load += new System.EventHandler(this.Frm_Inf_Gestion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _Bt_Consultar;
        private Microsoft.Reporting.WinForms.ReportViewer _Rpt_Report;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button _Bt_Consultar2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox _Cmb_Day;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _Cmb_Month;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _Cmb_Year;
    }
}