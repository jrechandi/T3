namespace T3
{
    partial class Frm_Inf_ConsultaClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Inf_ConsultaClientes));
            this.panel1 = new System.Windows.Forms.Panel();
            this._Rb_SinZona = new System.Windows.Forms.RadioButton();
            this._Rb_Inactivos = new System.Windows.Forms.RadioButton();
            this._Rb_Activos = new System.Windows.Forms.RadioButton();
            this._Bt_Limpiar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._Txt_Cliente = new System.Windows.Forms.TextBox();
            this._Bt_Buscar = new System.Windows.Forms.Button();
            this._Bt_Consultar = new System.Windows.Forms.Button();
            this._Rpt_Report = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Rb_SinZona);
            this.panel1.Controls.Add(this._Rb_Inactivos);
            this.panel1.Controls.Add(this._Rb_Activos);
            this.panel1.Controls.Add(this._Bt_Limpiar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._Txt_Cliente);
            this.panel1.Controls.Add(this._Bt_Buscar);
            this.panel1.Controls.Add(this._Bt_Consultar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 117);
            this.panel1.TabIndex = 8;
            // 
            // _Rb_SinZona
            // 
            this._Rb_SinZona.AutoSize = true;
            this._Rb_SinZona.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Rb_SinZona.Location = new System.Drawing.Point(12, 94);
            this._Rb_SinZona.Name = "_Rb_SinZona";
            this._Rb_SinZona.Size = new System.Drawing.Size(320, 17);
            this._Rb_SinZona.TabIndex = 119;
            this._Rb_SinZona.Text = "Sin zona, sin ruta, con zona sin vendedor asignado.";
            this._Rb_SinZona.UseVisualStyleBackColor = true;
            // 
            // _Rb_Inactivos
            // 
            this._Rb_Inactivos.AutoSize = true;
            this._Rb_Inactivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Rb_Inactivos.Location = new System.Drawing.Point(12, 71);
            this._Rb_Inactivos.Name = "_Rb_Inactivos";
            this._Rb_Inactivos.Size = new System.Drawing.Size(77, 17);
            this._Rb_Inactivos.TabIndex = 118;
            this._Rb_Inactivos.Text = "Inactivos";
            this._Rb_Inactivos.UseVisualStyleBackColor = true;
            this._Rb_Inactivos.CheckedChanged += new System.EventHandler(this._Rb_Inactivos_CheckedChanged);
            // 
            // _Rb_Activos
            // 
            this._Rb_Activos.AutoSize = true;
            this._Rb_Activos.Checked = true;
            this._Rb_Activos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Rb_Activos.Location = new System.Drawing.Point(12, 48);
            this._Rb_Activos.Name = "_Rb_Activos";
            this._Rb_Activos.Size = new System.Drawing.Size(67, 17);
            this._Rb_Activos.TabIndex = 117;
            this._Rb_Activos.TabStop = true;
            this._Rb_Activos.Text = "Activos";
            this._Rb_Activos.UseVisualStyleBackColor = true;
            // 
            // _Bt_Limpiar
            // 
            this._Bt_Limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Limpiar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Limpiar.Image")));
            this._Bt_Limpiar.Location = new System.Drawing.Point(411, 24);
            this._Bt_Limpiar.Name = "_Bt_Limpiar";
            this._Bt_Limpiar.Size = new System.Drawing.Size(25, 18);
            this._Bt_Limpiar.TabIndex = 116;
            this._Bt_Limpiar.UseVisualStyleBackColor = true;
            this._Bt_Limpiar.Click += new System.EventHandler(this._Bt_CerrarO_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 115;
            this.label1.Text = "Cliente:";
            // 
            // _Txt_Cliente
            // 
            this._Txt_Cliente.BackColor = System.Drawing.SystemColors.HighlightText;
            this._Txt_Cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Cliente.Location = new System.Drawing.Point(12, 23);
            this._Txt_Cliente.Name = "_Txt_Cliente";
            this._Txt_Cliente.ReadOnly = true;
            this._Txt_Cliente.Size = new System.Drawing.Size(362, 20);
            this._Txt_Cliente.TabIndex = 107;
            // 
            // _Bt_Buscar
            // 
            this._Bt_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Buscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Buscar.Image")));
            this._Bt_Buscar.Location = new System.Drawing.Point(380, 24);
            this._Bt_Buscar.Name = "_Bt_Buscar";
            this._Bt_Buscar.Size = new System.Drawing.Size(25, 18);
            this._Bt_Buscar.TabIndex = 108;
            this._Bt_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._Bt_Buscar.UseVisualStyleBackColor = true;
            this._Bt_Buscar.Click += new System.EventHandler(this._Bt_Buscar_Click);
            // 
            // _Bt_Consultar
            // 
            this._Bt_Consultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Consultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Consultar.Image")));
            this._Bt_Consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Consultar.Location = new System.Drawing.Point(452, 10);
            this._Bt_Consultar.Name = "_Bt_Consultar";
            this._Bt_Consultar.Size = new System.Drawing.Size(151, 40);
            this._Bt_Consultar.TabIndex = 48;
            this._Bt_Consultar.Text = "Consultar";
            this._Bt_Consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Consultar.UseVisualStyleBackColor = true;
            this._Bt_Consultar.Click += new System.EventHandler(this._Bt_Consultar_Click);
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
            this._Rpt_Report.TabIndex = 9;
            // 
            // Frm_Inf_ConsultaClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 496);
            this.Controls.Add(this._Rpt_Report);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Inf_ConsultaClientes";
            this.Text = "Informe - Consulta de Clientes";
            this.Load += new System.EventHandler(this.Frm_Inf_FichaCliente_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _Txt_Cliente;
        private System.Windows.Forms.Button _Bt_Buscar;
        private System.Windows.Forms.Button _Bt_Consultar;
        private Microsoft.Reporting.WinForms.ReportViewer _Rpt_Report;
        private System.Windows.Forms.Button _Bt_Limpiar;
        private System.Windows.Forms.RadioButton _Rb_Inactivos;
        private System.Windows.Forms.RadioButton _Rb_Activos;
        private System.Windows.Forms.RadioButton _Rb_SinZona;
    }
}