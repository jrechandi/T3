namespace T3
{
    partial class Frm_Inf_PreFactResProv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Inf_PreFactResProv));
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this._Txt_Pedido = new System.Windows.Forms.TextBox();
            this._Bt_LimpiarPedido = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this._Bt_Consultar = new System.Windows.Forms.Button();
            this._Ctrl_ConsultaMes1 = new T3.Controles._Ctrl_ConsultaMes();
            this._Txt_Vendedor = new System.Windows.Forms.TextBox();
            this._Bt_LimpiarVendedor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._Bt_Vendedor = new System.Windows.Forms.Button();
            this._Txt_Cliente = new System.Windows.Forms.TextBox();
            this._Bt_LimpiarCliente = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._Bt_Cliente = new System.Windows.Forms.Button();
            this._Rpt_Report = new Microsoft.Reporting.WinForms.ReportViewer();
            this._Rb_PreCargadas = new System.Windows.Forms.RadioButton();
            this._Rb_NoPreCargadas = new System.Windows.Forms.RadioButton();
            this._Rb_Todas = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Rb_Todas);
            this.panel1.Controls.Add(this._Rb_NoPreCargadas);
            this.panel1.Controls.Add(this._Rb_PreCargadas);
            this.panel1.Controls.Add(this._Txt_Pedido);
            this.panel1.Controls.Add(this._Bt_LimpiarPedido);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this._Bt_Consultar);
            this.panel1.Controls.Add(this._Ctrl_ConsultaMes1);
            this.panel1.Controls.Add(this._Txt_Vendedor);
            this.panel1.Controls.Add(this._Bt_LimpiarVendedor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._Bt_Vendedor);
            this.panel1.Controls.Add(this._Txt_Cliente);
            this.panel1.Controls.Add(this._Bt_LimpiarCliente);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._Bt_Cliente);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 155);
            this.panel1.TabIndex = 0;
            // 
            // _Txt_Pedido
            // 
            this._Txt_Pedido.BackColor = System.Drawing.SystemColors.HighlightText;
            this._Txt_Pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Pedido.Location = new System.Drawing.Point(14, 103);
            this._Txt_Pedido.Name = "_Txt_Pedido";
            this._Txt_Pedido.Size = new System.Drawing.Size(298, 20);
            this._Txt_Pedido.TabIndex = 166;
            this._Txt_Pedido.TextChanged += new System.EventHandler(this._Txt_Pedido_TextChanged);
            this._Txt_Pedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Pedido_KeyPress);
            // 
            // _Bt_LimpiarPedido
            // 
            this._Bt_LimpiarPedido.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_LimpiarPedido.Image")));
            this._Bt_LimpiarPedido.Location = new System.Drawing.Point(316, 101);
            this._Bt_LimpiarPedido.Name = "_Bt_LimpiarPedido";
            this._Bt_LimpiarPedido.Size = new System.Drawing.Size(25, 24);
            this._Bt_LimpiarPedido.TabIndex = 169;
            this._Bt_LimpiarPedido.UseVisualStyleBackColor = true;
            this._Bt_LimpiarPedido.Click += new System.EventHandler(this._Bt_LimpiarPedido_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 168;
            this.label3.Text = "Pedido:";
            // 
            // _Bt_Consultar
            // 
            this._Bt_Consultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Consultar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this._Bt_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Consultar.Image")));
            this._Bt_Consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Consultar.Location = new System.Drawing.Point(388, 71);
            this._Bt_Consultar.Name = "_Bt_Consultar";
            this._Bt_Consultar.Size = new System.Drawing.Size(118, 44);
            this._Bt_Consultar.TabIndex = 165;
            this._Bt_Consultar.Text = "Consultar";
            this._Bt_Consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Consultar.UseVisualStyleBackColor = true;
            this._Bt_Consultar.Click += new System.EventHandler(this._Bt_Consultar_Click);
            // 
            // _Ctrl_ConsultaMes1
            // 
            this._Ctrl_ConsultaMes1.Location = new System.Drawing.Point(378, 9);
            this._Ctrl_ConsultaMes1.Name = "_Ctrl_ConsultaMes1";
            this._Ctrl_ConsultaMes1.Size = new System.Drawing.Size(377, 59);
            this._Ctrl_ConsultaMes1.TabIndex = 164;
            // 
            // _Txt_Vendedor
            // 
            this._Txt_Vendedor.BackColor = System.Drawing.SystemColors.HighlightText;
            this._Txt_Vendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Vendedor.Location = new System.Drawing.Point(14, 64);
            this._Txt_Vendedor.Name = "_Txt_Vendedor";
            this._Txt_Vendedor.ReadOnly = true;
            this._Txt_Vendedor.Size = new System.Drawing.Size(298, 20);
            this._Txt_Vendedor.TabIndex = 156;
            // 
            // _Bt_LimpiarVendedor
            // 
            this._Bt_LimpiarVendedor.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_LimpiarVendedor.Image")));
            this._Bt_LimpiarVendedor.Location = new System.Drawing.Point(347, 62);
            this._Bt_LimpiarVendedor.Name = "_Bt_LimpiarVendedor";
            this._Bt_LimpiarVendedor.Size = new System.Drawing.Size(25, 24);
            this._Bt_LimpiarVendedor.TabIndex = 159;
            this._Bt_LimpiarVendedor.UseVisualStyleBackColor = true;
            this._Bt_LimpiarVendedor.Click += new System.EventHandler(this._Bt_LimpiarVendedor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 158;
            this.label1.Text = "Vendedor:";
            // 
            // _Bt_Vendedor
            // 
            this._Bt_Vendedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Vendedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Vendedor.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Vendedor.Image")));
            this._Bt_Vendedor.Location = new System.Drawing.Point(316, 62);
            this._Bt_Vendedor.Name = "_Bt_Vendedor";
            this._Bt_Vendedor.Size = new System.Drawing.Size(25, 24);
            this._Bt_Vendedor.TabIndex = 157;
            this._Bt_Vendedor.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._Bt_Vendedor.UseVisualStyleBackColor = true;
            this._Bt_Vendedor.Click += new System.EventHandler(this._Bt_Vendedor_Click);
            // 
            // _Txt_Cliente
            // 
            this._Txt_Cliente.BackColor = System.Drawing.SystemColors.HighlightText;
            this._Txt_Cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Cliente.Location = new System.Drawing.Point(14, 25);
            this._Txt_Cliente.Name = "_Txt_Cliente";
            this._Txt_Cliente.ReadOnly = true;
            this._Txt_Cliente.Size = new System.Drawing.Size(298, 20);
            this._Txt_Cliente.TabIndex = 152;
            // 
            // _Bt_LimpiarCliente
            // 
            this._Bt_LimpiarCliente.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_LimpiarCliente.Image")));
            this._Bt_LimpiarCliente.Location = new System.Drawing.Point(347, 23);
            this._Bt_LimpiarCliente.Name = "_Bt_LimpiarCliente";
            this._Bt_LimpiarCliente.Size = new System.Drawing.Size(25, 24);
            this._Bt_LimpiarCliente.TabIndex = 155;
            this._Bt_LimpiarCliente.UseVisualStyleBackColor = true;
            this._Bt_LimpiarCliente.Click += new System.EventHandler(this._Bt_LimpiarCliente_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 154;
            this.label2.Text = "Cliente:";
            // 
            // _Bt_Cliente
            // 
            this._Bt_Cliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Cliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Cliente.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Cliente.Image")));
            this._Bt_Cliente.Location = new System.Drawing.Point(316, 23);
            this._Bt_Cliente.Name = "_Bt_Cliente";
            this._Bt_Cliente.Size = new System.Drawing.Size(25, 24);
            this._Bt_Cliente.TabIndex = 153;
            this._Bt_Cliente.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._Bt_Cliente.UseVisualStyleBackColor = true;
            this._Bt_Cliente.Click += new System.EventHandler(this._Bt_Cliente_Click);
            // 
            // _Rpt_Report
            // 
            this._Rpt_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Rpt_Report.Location = new System.Drawing.Point(0, 155);
            this._Rpt_Report.Name = "_Rpt_Report";
            this._Rpt_Report.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this._Rpt_Report.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this._Rpt_Report.ShowParameterPrompts = false;
            this._Rpt_Report.Size = new System.Drawing.Size(965, 273);
            this._Rpt_Report.TabIndex = 6;
            // 
            // _Rb_PreCargadas
            // 
            this._Rb_PreCargadas.AutoSize = true;
            this._Rb_PreCargadas.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Rb_PreCargadas.Location = new System.Drawing.Point(78, 129);
            this._Rb_PreCargadas.Name = "_Rb_PreCargadas";
            this._Rb_PreCargadas.Size = new System.Drawing.Size(113, 17);
            this._Rb_PreCargadas.TabIndex = 170;
            this._Rb_PreCargadas.Text = "Pre-cargadas";
            this._Rb_PreCargadas.UseVisualStyleBackColor = true;
            // 
            // _Rb_NoPreCargadas
            // 
            this._Rb_NoPreCargadas.AutoSize = true;
            this._Rb_NoPreCargadas.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Rb_NoPreCargadas.Location = new System.Drawing.Point(191, 129);
            this._Rb_NoPreCargadas.Name = "_Rb_NoPreCargadas";
            this._Rb_NoPreCargadas.Size = new System.Drawing.Size(134, 17);
            this._Rb_NoPreCargadas.TabIndex = 171;
            this._Rb_NoPreCargadas.Text = "No pre-cargadas";
            this._Rb_NoPreCargadas.UseVisualStyleBackColor = true;
            // 
            // _Rb_Todas
            // 
            this._Rb_Todas.AutoSize = true;
            this._Rb_Todas.Checked = true;
            this._Rb_Todas.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Rb_Todas.Location = new System.Drawing.Point(14, 129);
            this._Rb_Todas.Name = "_Rb_Todas";
            this._Rb_Todas.Size = new System.Drawing.Size(64, 17);
            this._Rb_Todas.TabIndex = 172;
            this._Rb_Todas.TabStop = true;
            this._Rb_Todas.Text = "Todas";
            this._Rb_Todas.UseVisualStyleBackColor = true;
            // 
            // Frm_Inf_PreFactResProv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 428);
            this.Controls.Add(this._Rpt_Report);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Inf_PreFactResProv";
            this.Text = "Informe - Pre-Facturas Resumidas por Proveedor";
            this.Activated += new System.EventHandler(this.Frm_Inf_PreFactResProv_Activated);
            this.Load += new System.EventHandler(this.Frm_Inf_PreFactResProv_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox _Txt_Cliente;
        private System.Windows.Forms.Button _Bt_LimpiarCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _Bt_Cliente;
        private System.Windows.Forms.TextBox _Txt_Vendedor;
        private System.Windows.Forms.Button _Bt_LimpiarVendedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _Bt_Vendedor;
        private Controles._Ctrl_ConsultaMes _Ctrl_ConsultaMes1;
        private System.Windows.Forms.Button _Bt_Consultar;
        private System.Windows.Forms.TextBox _Txt_Pedido;
        private System.Windows.Forms.Button _Bt_LimpiarPedido;
        private System.Windows.Forms.Label label3;
        private Microsoft.Reporting.WinForms.ReportViewer _Rpt_Report;
        private System.Windows.Forms.RadioButton _Rb_Todas;
        private System.Windows.Forms.RadioButton _Rb_NoPreCargadas;
        private System.Windows.Forms.RadioButton _Rb_PreCargadas;
    }
}