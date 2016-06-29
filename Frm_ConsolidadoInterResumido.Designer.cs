namespace T3
{
    partial class Frm_ConsolidadoInterResumido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ConsolidadoInterResumido));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTotales = new System.Windows.Forms.Panel();
            this.txtTotalMayor = new System.Windows.Forms.TextBox();
            this.txtTotalMenor = new System.Windows.Forms.TextBox();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.lblTotalCobrar = new System.Windows.Forms.Label();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.cmbCompaniaRelacionada = new System.Windows.Forms.ComboBox();
            this.lblCompañiaRelacionada = new System.Windows.Forms.Label();
            this.dtgConsolidado = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMenor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMayor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.pnlTotales.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsolidado)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTotales
            // 
            this.pnlTotales.Controls.Add(this.txtSaldo);
            this.pnlTotales.Controls.Add(this.lblSaldo);
            this.pnlTotales.Controls.Add(this.txtTotalMayor);
            this.pnlTotales.Controls.Add(this.txtTotalMenor);
            this.pnlTotales.Controls.Add(this.lblTotalPagar);
            this.pnlTotales.Controls.Add(this.lblTotalCobrar);
            this.pnlTotales.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotales.Location = new System.Drawing.Point(0, 282);
            this.pnlTotales.Name = "pnlTotales";
            this.pnlTotales.Size = new System.Drawing.Size(1024, 70);
            this.pnlTotales.TabIndex = 60;
            // 
            // txtTotalMayor
            // 
            this.txtTotalMayor.Location = new System.Drawing.Point(179, 36);
            this.txtTotalMayor.Name = "txtTotalMayor";
            this.txtTotalMayor.ReadOnly = true;
            this.txtTotalMayor.Size = new System.Drawing.Size(129, 20);
            this.txtTotalMayor.TabIndex = 61;
            this.txtTotalMayor.Text = "0";
            this.txtTotalMayor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalMenor
            // 
            this.txtTotalMenor.Location = new System.Drawing.Point(19, 36);
            this.txtTotalMenor.Name = "txtTotalMenor";
            this.txtTotalMenor.ReadOnly = true;
            this.txtTotalMenor.Size = new System.Drawing.Size(129, 20);
            this.txtTotalMenor.TabIndex = 60;
            this.txtTotalMenor.Text = "0";
            this.txtTotalMenor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.AutoSize = true;
            this.lblTotalPagar.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagar.Location = new System.Drawing.Point(177, 21);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(111, 12);
            this.lblTotalPagar.TabIndex = 58;
            this.lblTotalPagar.Text = "Total más de 30 días:";
            // 
            // lblTotalCobrar
            // 
            this.lblTotalCobrar.AutoSize = true;
            this.lblTotalCobrar.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCobrar.Location = new System.Drawing.Point(17, 21);
            this.lblTotalCobrar.Name = "lblTotalCobrar";
            this.lblTotalCobrar.Size = new System.Drawing.Size(82, 12);
            this.lblTotalCobrar.TabIndex = 57;
            this.lblTotalCobrar.Text = "Total a 30 días:";
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Controls.Add(this.btnConsultar);
            this.pnlFiltros.Controls.Add(this.cmbCompaniaRelacionada);
            this.pnlFiltros.Controls.Add(this.lblCompañiaRelacionada);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1024, 59);
            this.pnlFiltros.TabIndex = 61;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.Location = new System.Drawing.Point(356, 21);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(109, 28);
            this.btnConsultar.TabIndex = 64;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // cmbCompaniaRelacionada
            // 
            this.cmbCompaniaRelacionada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompaniaRelacionada.FormattingEnabled = true;
            this.cmbCompaniaRelacionada.Location = new System.Drawing.Point(12, 26);
            this.cmbCompaniaRelacionada.Name = "cmbCompaniaRelacionada";
            this.cmbCompaniaRelacionada.Size = new System.Drawing.Size(330, 21);
            this.cmbCompaniaRelacionada.TabIndex = 60;
            // 
            // lblCompañiaRelacionada
            // 
            this.lblCompañiaRelacionada.AutoSize = true;
            this.lblCompañiaRelacionada.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompañiaRelacionada.Location = new System.Drawing.Point(11, 11);
            this.lblCompañiaRelacionada.Name = "lblCompañiaRelacionada";
            this.lblCompañiaRelacionada.Size = new System.Drawing.Size(117, 12);
            this.lblCompañiaRelacionada.TabIndex = 61;
            this.lblCompañiaRelacionada.Text = "Compañia relacionada:";
            // 
            // dtgConsolidado
            // 
            this.dtgConsolidado.AllowUserToAddRows = false;
            this.dtgConsolidado.AllowUserToDeleteRows = false;
            this.dtgConsolidado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dtgConsolidado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConsolidado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colProveedor,
            this.colMenor,
            this.colMayor});
            this.dtgConsolidado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgConsolidado.Location = new System.Drawing.Point(0, 59);
            this.dtgConsolidado.Name = "dtgConsolidado";
            this.dtgConsolidado.ReadOnly = true;
            this.dtgConsolidado.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dtgConsolidado.Size = new System.Drawing.Size(1024, 223);
            this.dtgConsolidado.TabIndex = 62;
            this.dtgConsolidado.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgConsolidado_RowHeaderMouseDoubleClick);
            // 
            // colCodigo
            // 
            this.colCodigo.DataPropertyName = "cproveedor";
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            this.colCodigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Visible = false;
            // 
            // colProveedor
            // 
            this.colProveedor.DataPropertyName = "c_nomb_comer";
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            this.colProveedor.DefaultCellStyle = dataGridViewCellStyle2;
            this.colProveedor.HeaderText = "Proveedor";
            this.colProveedor.Name = "colProveedor";
            this.colProveedor.ReadOnly = true;
            // 
            // colMenor
            // 
            this.colMenor.DataPropertyName = "cmonto1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            this.colMenor.DefaultCellStyle = dataGridViewCellStyle3;
            this.colMenor.HeaderText = "A 30 días";
            this.colMenor.Name = "colMenor";
            this.colMenor.ReadOnly = true;
            // 
            // colMayor
            // 
            this.colMayor.DataPropertyName = "cmonto2";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(3);
            this.colMayor.DefaultCellStyle = dataGridViewCellStyle4;
            this.colMayor.HeaderText = "Más 30 días";
            this.colMayor.Name = "colMayor";
            this.colMayor.ReadOnly = true;
            // 
            // txtSaldo
            // 
            this.txtSaldo.Location = new System.Drawing.Point(331, 36);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(129, 20);
            this.txtSaldo.TabIndex = 63;
            this.txtSaldo.Text = "0";
            this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(330, 21);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(36, 12);
            this.lblSaldo.TabIndex = 62;
            this.lblSaldo.Text = "Saldo:";
            // 
            // Frm_ConsolidadoInterResumido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 352);
            this.Controls.Add(this.dtgConsolidado);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlTotales);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_ConsolidadoInterResumido";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen - Consolidado Intercompañía";
            this.pnlTotales.ResumeLayout(false);
            this.pnlTotales.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsolidado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTotales;
        private System.Windows.Forms.TextBox txtTotalMayor;
        private System.Windows.Forms.TextBox txtTotalMenor;
        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.Label lblTotalCobrar;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.ComboBox cmbCompaniaRelacionada;
        private System.Windows.Forms.Label lblCompañiaRelacionada;
        private System.Windows.Forms.DataGridView dtgConsolidado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMenor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMayor;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label lblSaldo;
    }
}