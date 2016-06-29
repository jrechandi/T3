namespace T3
{
    partial class Frm_ConsolidaObligaciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ConsolidaObligaciones));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this._Dg_Calendario = new System.Windows.Forms.DataGridView();
            this._Grb_B = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._Bt_Find = new System.Windows.Forms.Button();
            this._Cmb_Proveedor = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this._Cmb_CategProv = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this._Cmb_TipoProv = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this._Pgb_A = new System.Windows.Forms.ProgressBar();
            this._Bt_Export = new System.Windows.Forms.Button();
            this._Sfd_1 = new System.Windows.Forms.SaveFileDialog();
            this._Fbd_A = new System.Windows.Forms.FolderBrowserDialog();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this._Dg_CalendarioCol_ProveId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_CalendarioCol_Prove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_CalendarioCol_NC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_CalendarioCol_ND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_CalendarioCol_Ret = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_CalendarioCol_Cheques = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_CalendarioCol_Vencidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Calendario)).BeginInit();
            this._Grb_B.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Dg_Calendario
            // 
            this._Dg_Calendario.AllowUserToAddRows = false;
            this._Dg_Calendario.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._Dg_Calendario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._Dg_Calendario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Calendario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._Dg_CalendarioCol_ProveId,
            this._Dg_CalendarioCol_Prove,
            this._Dg_CalendarioCol_NC,
            this._Dg_CalendarioCol_ND,
            this._Dg_CalendarioCol_Ret,
            this._Dg_CalendarioCol_Cheques,
            this._Dg_CalendarioCol_Vencidos});
            this._Dg_Calendario.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Calendario.Location = new System.Drawing.Point(0, 117);
            this._Dg_Calendario.Name = "_Dg_Calendario";
            this._Dg_Calendario.ReadOnly = true;
            this._Dg_Calendario.Size = new System.Drawing.Size(981, 328);
            this._Dg_Calendario.TabIndex = 0;
            this._Dg_Calendario.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Calendario_CellMouseEnter);
            this._Dg_Calendario.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Calendario_RowHeaderMouseDoubleClick);
            // 
            // _Grb_B
            // 
            this._Grb_B.Controls.Add(this.groupBox3);
            this._Grb_B.Controls.Add(this._Pgb_A);
            this._Grb_B.Controls.Add(this._Bt_Export);
            this._Grb_B.Dock = System.Windows.Forms.DockStyle.Top;
            this._Grb_B.Location = new System.Drawing.Point(0, 0);
            this._Grb_B.Name = "_Grb_B";
            this._Grb_B.Size = new System.Drawing.Size(981, 117);
            this._Grb_B.TabIndex = 2;
            this._Grb_B.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._Bt_Find);
            this.groupBox3.Controls.Add(this._Cmb_Proveedor);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this._Cmb_CategProv);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this._Cmb_TipoProv);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(6, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(743, 61);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Proveedor";
            // 
            // _Bt_Find
            // 
            this._Bt_Find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Find.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Find.Image")));
            this._Bt_Find.Location = new System.Drawing.Point(662, 6);
            this._Bt_Find.Name = "_Bt_Find";
            this._Bt_Find.Size = new System.Drawing.Size(64, 47);
            this._Bt_Find.TabIndex = 13;
            this._Bt_Find.UseVisualStyleBackColor = true;
            this._Bt_Find.Click += new System.EventHandler(this._Bt_Find_Click);
            // 
            // _Cmb_Proveedor
            // 
            this._Cmb_Proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Proveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Proveedor.FormattingEnabled = true;
            this._Cmb_Proveedor.Location = new System.Drawing.Point(380, 33);
            this._Cmb_Proveedor.Name = "_Cmb_Proveedor";
            this._Cmb_Proveedor.Size = new System.Drawing.Size(276, 20);
            this._Cmb_Proveedor.TabIndex = 11;
            this._Cmb_Proveedor.SelectedIndexChanged += new System.EventHandler(this._Cmb_Proveedor_SelectedIndexChanged);
            this._Cmb_Proveedor.DropDown += new System.EventHandler(this._Cmb_Proveedor_DropDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(378, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 12);
            this.label15.TabIndex = 10;
            this.label15.Text = "Proveedor:";
            // 
            // _Cmb_CategProv
            // 
            this._Cmb_CategProv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_CategProv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_CategProv.FormattingEnabled = true;
            this._Cmb_CategProv.Location = new System.Drawing.Point(152, 33);
            this._Cmb_CategProv.Name = "_Cmb_CategProv";
            this._Cmb_CategProv.Size = new System.Drawing.Size(222, 20);
            this._Cmb_CategProv.TabIndex = 7;
            this._Cmb_CategProv.SelectedIndexChanged += new System.EventHandler(this._Cmb_CategProv_SelectedIndexChanged);
            this._Cmb_CategProv.DropDown += new System.EventHandler(this._Cmb_CategProv_DropDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(150, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "Categoría:";
            // 
            // _Cmb_TipoProv
            // 
            this._Cmb_TipoProv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_TipoProv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_TipoProv.FormattingEnabled = true;
            this._Cmb_TipoProv.Location = new System.Drawing.Point(9, 33);
            this._Cmb_TipoProv.Name = "_Cmb_TipoProv";
            this._Cmb_TipoProv.Size = new System.Drawing.Size(137, 20);
            this._Cmb_TipoProv.TabIndex = 5;
            this._Cmb_TipoProv.SelectedIndexChanged += new System.EventHandler(this._Cmb_TipoProv_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "Tipo:";
            // 
            // _Pgb_A
            // 
            this._Pgb_A.ForeColor = System.Drawing.SystemColors.Desktop;
            this._Pgb_A.Location = new System.Drawing.Point(112, 78);
            this._Pgb_A.Name = "_Pgb_A";
            this._Pgb_A.Size = new System.Drawing.Size(294, 27);
            this._Pgb_A.Step = 1;
            this._Pgb_A.TabIndex = 1;
            // 
            // _Bt_Export
            // 
            this._Bt_Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Export.Location = new System.Drawing.Point(8, 78);
            this._Bt_Export.Name = "_Bt_Export";
            this._Bt_Export.Size = new System.Drawing.Size(98, 27);
            this._Bt_Export.TabIndex = 0;
            this._Bt_Export.Text = "Exportar a Excel";
            this._Bt_Export.UseVisualStyleBackColor = true;
            this._Bt_Export.Click += new System.EventHandler(this._Bt_Export_Click);
            // 
            // _Sfd_1
            // 
            this._Sfd_1.Filter = "xls files (*.xls)|*.xls";
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(0, 445);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(981, 12);
            this._Lbl_DgInfo.TabIndex = 6;
            this._Lbl_DgInfo.Text = "Use doble click";
            this._Lbl_DgInfo.Visible = false;
            // 
            // _Dg_CalendarioCol_ProveId
            // 
            this._Dg_CalendarioCol_ProveId.HeaderText = "Proveedor Id";
            this._Dg_CalendarioCol_ProveId.Name = "_Dg_CalendarioCol_ProveId";
            this._Dg_CalendarioCol_ProveId.ReadOnly = true;
            this._Dg_CalendarioCol_ProveId.Visible = false;
            // 
            // _Dg_CalendarioCol_Prove
            // 
            this._Dg_CalendarioCol_Prove.HeaderText = "Proveedores";
            this._Dg_CalendarioCol_Prove.Name = "_Dg_CalendarioCol_Prove";
            this._Dg_CalendarioCol_Prove.ReadOnly = true;
            // 
            // _Dg_CalendarioCol_NC
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this._Dg_CalendarioCol_NC.DefaultCellStyle = dataGridViewCellStyle2;
            this._Dg_CalendarioCol_NC.HeaderText = "N.C.";
            this._Dg_CalendarioCol_NC.Name = "_Dg_CalendarioCol_NC";
            this._Dg_CalendarioCol_NC.ReadOnly = true;
            // 
            // _Dg_CalendarioCol_ND
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this._Dg_CalendarioCol_ND.DefaultCellStyle = dataGridViewCellStyle3;
            this._Dg_CalendarioCol_ND.HeaderText = "N.D.";
            this._Dg_CalendarioCol_ND.Name = "_Dg_CalendarioCol_ND";
            this._Dg_CalendarioCol_ND.ReadOnly = true;
            // 
            // _Dg_CalendarioCol_Ret
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this._Dg_CalendarioCol_Ret.DefaultCellStyle = dataGridViewCellStyle4;
            this._Dg_CalendarioCol_Ret.HeaderText = "Retenciones";
            this._Dg_CalendarioCol_Ret.Name = "_Dg_CalendarioCol_Ret";
            this._Dg_CalendarioCol_Ret.ReadOnly = true;
            // 
            // _Dg_CalendarioCol_Cheques
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this._Dg_CalendarioCol_Cheques.DefaultCellStyle = dataGridViewCellStyle5;
            this._Dg_CalendarioCol_Cheques.HeaderText = "Cheques";
            this._Dg_CalendarioCol_Cheques.Name = "_Dg_CalendarioCol_Cheques";
            this._Dg_CalendarioCol_Cheques.ReadOnly = true;
            // 
            // _Dg_CalendarioCol_Vencidos
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this._Dg_CalendarioCol_Vencidos.DefaultCellStyle = dataGridViewCellStyle6;
            this._Dg_CalendarioCol_Vencidos.HeaderText = "Vencidos";
            this._Dg_CalendarioCol_Vencidos.Name = "_Dg_CalendarioCol_Vencidos";
            this._Dg_CalendarioCol_Vencidos.ReadOnly = true;
            // 
            // Frm_ConsolidaObligaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 457);
            this.Controls.Add(this._Dg_Calendario);
            this.Controls.Add(this._Lbl_DgInfo);
            this.Controls.Add(this._Grb_B);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ConsolidaObligaciones";
            this.Text = "Obligaciones por pagar";
            this.Load += new System.EventHandler(this.Frm_ConsolidaObligaciones_Load);
            this.Activated += new System.EventHandler(this.Frm_ConsolidaObligaciones_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ConsolidaObligaciones_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Calendario)).EndInit();
            this._Grb_B.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _Dg_Calendario;
        private System.Windows.Forms.GroupBox _Grb_B;
        private System.Windows.Forms.Button _Bt_Export;
        private System.Windows.Forms.SaveFileDialog _Sfd_1;
        private System.Windows.Forms.FolderBrowserDialog _Fbd_A;
        private System.Windows.Forms.ProgressBar _Pgb_A;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox _Cmb_Proveedor;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox _Cmb_CategProv;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox _Cmb_TipoProv;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button _Bt_Find;
        private System.Windows.Forms.Label _Lbl_DgInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_CalendarioCol_ProveId;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_CalendarioCol_Prove;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_CalendarioCol_NC;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_CalendarioCol_ND;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_CalendarioCol_Ret;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_CalendarioCol_Cheques;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_CalendarioCol_Vencidos;
    }
}