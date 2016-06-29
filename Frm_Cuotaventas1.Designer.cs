namespace T3
{
    partial class Frm_Cuotaventas1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Cuotaventas1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this._Pnl_Filtro = new System.Windows.Forms.Panel();
            this._Bt_Find = new System.Windows.Forms.Button();
            this._Cb_Proveedor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this._Cb_ZonaVta = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this._Cb_Mes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Cb_Ano = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Dg_Cuotas = new System.Windows.Forms.DataGridView();
            this._Dg_CuotasCol_Cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_CuotasCol_Grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_CuotasCol_cuotacaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_CuotasCol_cuotaclie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_CuotasCol_cuotabs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_CuotasCol_ano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_CuotasCol_Mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_CuotasCol_zvta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_CuotasCol_Prov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_CuotasCol_Subgrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Pnl_Filtro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Cuotas)).BeginInit();
            this.SuspendLayout();
            // 
            // _Pnl_Filtro
            // 
            this._Pnl_Filtro.Controls.Add(this._Bt_Find);
            this._Pnl_Filtro.Controls.Add(this._Cb_Proveedor);
            this._Pnl_Filtro.Controls.Add(this.label4);
            this._Pnl_Filtro.Controls.Add(this._Cb_ZonaVta);
            this._Pnl_Filtro.Controls.Add(this.label3);
            this._Pnl_Filtro.Controls.Add(this._Cb_Mes);
            this._Pnl_Filtro.Controls.Add(this.label2);
            this._Pnl_Filtro.Controls.Add(this._Cb_Ano);
            this._Pnl_Filtro.Controls.Add(this.label1);
            this._Pnl_Filtro.Dock = System.Windows.Forms.DockStyle.Top;
            this._Pnl_Filtro.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Pnl_Filtro.Location = new System.Drawing.Point(0, 0);
            this._Pnl_Filtro.Name = "_Pnl_Filtro";
            this._Pnl_Filtro.Size = new System.Drawing.Size(944, 63);
            this._Pnl_Filtro.TabIndex = 0;
            // 
            // _Bt_Find
            // 
            this._Bt_Find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Find.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Find.Image")));
            this._Bt_Find.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this._Bt_Find.Location = new System.Drawing.Point(782, 12);
            this._Bt_Find.Name = "_Bt_Find";
            this._Bt_Find.Size = new System.Drawing.Size(51, 40);
            this._Bt_Find.TabIndex = 15;
            this._Bt_Find.Text = "Filtrar";
            this._Bt_Find.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._Bt_Find.UseVisualStyleBackColor = true;
            this._Bt_Find.Click += new System.EventHandler(this._Bt_Find_Click);
            // 
            // _Cb_Proveedor
            // 
            this._Cb_Proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_Proveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_Proveedor.FormattingEnabled = true;
            this._Cb_Proveedor.Location = new System.Drawing.Point(498, 26);
            this._Cb_Proveedor.Name = "_Cb_Proveedor";
            this._Cb_Proveedor.Size = new System.Drawing.Size(278, 20);
            this._Cb_Proveedor.TabIndex = 13;
            this._Cb_Proveedor.SelectedIndexChanged += new System.EventHandler(this._Cb_Proveedor_SelectedIndexChanged);
            this._Cb_Proveedor.DropDown += new System.EventHandler(this._Cb_Proveedor_DropDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(496, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "Proveedor";
            // 
            // _Cb_ZonaVta
            // 
            this._Cb_ZonaVta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_ZonaVta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_ZonaVta.FormattingEnabled = true;
            this._Cb_ZonaVta.Location = new System.Drawing.Point(201, 26);
            this._Cb_ZonaVta.Name = "_Cb_ZonaVta";
            this._Cb_ZonaVta.Size = new System.Drawing.Size(288, 20);
            this._Cb_ZonaVta.TabIndex = 11;
            this._Cb_ZonaVta.SelectedIndexChanged += new System.EventHandler(this._Cb_ZonaVta_SelectedIndexChanged);
            this._Cb_ZonaVta.DropDown += new System.EventHandler(this._Cb_ZonaVta_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(199, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "Zona de ventas:";
            // 
            // _Cb_Mes
            // 
            this._Cb_Mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_Mes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_Mes.FormattingEnabled = true;
            this._Cb_Mes.Location = new System.Drawing.Point(90, 26);
            this._Cb_Mes.Name = "_Cb_Mes";
            this._Cb_Mes.Size = new System.Drawing.Size(101, 20);
            this._Cb_Mes.TabIndex = 9;
            this._Cb_Mes.SelectedIndexChanged += new System.EventHandler(this._Cb_Mes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "Mes:";
            // 
            // _Cb_Ano
            // 
            this._Cb_Ano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_Ano.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_Ano.FormattingEnabled = true;
            this._Cb_Ano.Location = new System.Drawing.Point(10, 26);
            this._Cb_Ano.Name = "_Cb_Ano";
            this._Cb_Ano.Size = new System.Drawing.Size(74, 20);
            this._Cb_Ano.TabIndex = 7;
            this._Cb_Ano.SelectedIndexChanged += new System.EventHandler(this._Cb_Ano_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "Año:";
            // 
            // _Dg_Cuotas
            // 
            this._Dg_Cuotas.AllowUserToAddRows = false;
            this._Dg_Cuotas.AllowUserToDeleteRows = false;
            this._Dg_Cuotas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Dg_Cuotas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._Dg_Cuotas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._Dg_Cuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Cuotas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._Dg_CuotasCol_Cod,
            this._Dg_CuotasCol_Grupo,
            this._Dg_CuotasCol_cuotacaja,
            this._Dg_CuotasCol_cuotaclie,
            this._Dg_CuotasCol_cuotabs,
            this._Dg_CuotasCol_ano,
            this._Dg_CuotasCol_Mes,
            this._Dg_CuotasCol_zvta,
            this._Dg_CuotasCol_Prov,
            this._Dg_CuotasCol_Subgrupo});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._Dg_Cuotas.DefaultCellStyle = dataGridViewCellStyle5;
            this._Dg_Cuotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Cuotas.Location = new System.Drawing.Point(0, 63);
            this._Dg_Cuotas.Name = "_Dg_Cuotas";
            this._Dg_Cuotas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Cuotas.Size = new System.Drawing.Size(944, 399);
            this._Dg_Cuotas.TabIndex = 2;
            this._Dg_Cuotas.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this._Dg_Cuotas_EditingControlShowing);
            // 
            // _Dg_CuotasCol_Cod
            // 
            this._Dg_CuotasCol_Cod.HeaderText = "Código";
            this._Dg_CuotasCol_Cod.Name = "_Dg_CuotasCol_Cod";
            this._Dg_CuotasCol_Cod.ReadOnly = true;
            // 
            // _Dg_CuotasCol_Grupo
            // 
            this._Dg_CuotasCol_Grupo.HeaderText = "Grupo";
            this._Dg_CuotasCol_Grupo.Name = "_Dg_CuotasCol_Grupo";
            this._Dg_CuotasCol_Grupo.ReadOnly = true;
            // 
            // _Dg_CuotasCol_cuotacaja
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this._Dg_CuotasCol_cuotacaja.DefaultCellStyle = dataGridViewCellStyle2;
            this._Dg_CuotasCol_cuotacaja.HeaderText = "C. Caja";
            this._Dg_CuotasCol_cuotacaja.MaxInputLength = 5;
            this._Dg_CuotasCol_cuotacaja.Name = "_Dg_CuotasCol_cuotacaja";
            // 
            // _Dg_CuotasCol_cuotaclie
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this._Dg_CuotasCol_cuotaclie.DefaultCellStyle = dataGridViewCellStyle3;
            this._Dg_CuotasCol_cuotaclie.HeaderText = "C. Cliente";
            this._Dg_CuotasCol_cuotaclie.MaxInputLength = 5;
            this._Dg_CuotasCol_cuotaclie.Name = "_Dg_CuotasCol_cuotaclie";
            // 
            // _Dg_CuotasCol_cuotabs
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this._Dg_CuotasCol_cuotabs.DefaultCellStyle = dataGridViewCellStyle4;
            this._Dg_CuotasCol_cuotabs.HeaderText = "C. Bolivares";
            this._Dg_CuotasCol_cuotabs.MaxInputLength = 18;
            this._Dg_CuotasCol_cuotabs.Name = "_Dg_CuotasCol_cuotabs";
            // 
            // _Dg_CuotasCol_ano
            // 
            this._Dg_CuotasCol_ano.HeaderText = "AÑO";
            this._Dg_CuotasCol_ano.Name = "_Dg_CuotasCol_ano";
            this._Dg_CuotasCol_ano.Visible = false;
            // 
            // _Dg_CuotasCol_Mes
            // 
            this._Dg_CuotasCol_Mes.HeaderText = "MES";
            this._Dg_CuotasCol_Mes.Name = "_Dg_CuotasCol_Mes";
            this._Dg_CuotasCol_Mes.Visible = false;
            // 
            // _Dg_CuotasCol_zvta
            // 
            this._Dg_CuotasCol_zvta.HeaderText = "ZONA DE VENTA";
            this._Dg_CuotasCol_zvta.Name = "_Dg_CuotasCol_zvta";
            this._Dg_CuotasCol_zvta.Visible = false;
            // 
            // _Dg_CuotasCol_Prov
            // 
            this._Dg_CuotasCol_Prov.HeaderText = "PROVEEDOR";
            this._Dg_CuotasCol_Prov.Name = "_Dg_CuotasCol_Prov";
            this._Dg_CuotasCol_Prov.Visible = false;
            // 
            // _Dg_CuotasCol_Subgrupo
            // 
            this._Dg_CuotasCol_Subgrupo.HeaderText = "GRUPO";
            this._Dg_CuotasCol_Subgrupo.Name = "_Dg_CuotasCol_Subgrupo";
            this._Dg_CuotasCol_Subgrupo.Visible = false;
            // 
            // Frm_Cuotaventas1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 462);
            this.Controls.Add(this._Dg_Cuotas);
            this.Controls.Add(this._Pnl_Filtro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Cuotaventas1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuota de ventas";
            this.Load += new System.EventHandler(this.Frm_Cuotaventas1_Load);
            this.Activated += new System.EventHandler(this.Frm_Cuotaventas1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Cuotaventas1_FormClosing);
            this._Pnl_Filtro.ResumeLayout(false);
            this._Pnl_Filtro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Cuotas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _Pnl_Filtro;
        private System.Windows.Forms.ComboBox _Cb_ZonaVta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _Cb_Mes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _Cb_Ano;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _Cb_Proveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _Bt_Find;
        private System.Windows.Forms.DataGridView _Dg_Cuotas;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_CuotasCol_Cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_CuotasCol_Grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_CuotasCol_cuotacaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_CuotasCol_cuotaclie;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_CuotasCol_cuotabs;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_CuotasCol_ano;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_CuotasCol_Mes;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_CuotasCol_zvta;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_CuotasCol_Prov;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_CuotasCol_Subgrupo;
    }
}