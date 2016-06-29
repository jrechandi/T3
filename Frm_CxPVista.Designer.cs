namespace T3
{
    partial class Frm_CxPVista
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this._Dg_Grid_Rp = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_Grid_RpCol_diasvenc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_Grid_RpCol_tpodoc_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._CMen_OrdPago = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._CMen_OrdPago_Sel = new System.Windows.Forms.ToolStripMenuItem();
            this._Pnl_A = new System.Windows.Forms.Panel();
            this._Bt_Cancel = new System.Windows.Forms.Button();
            this._Bt_Ok = new System.Windows.Forms.Button();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_Rp)).BeginInit();
            this._CMen_OrdPago.SuspendLayout();
            this._Pnl_A.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Dg_Grid_Rp
            // 
            this._Dg_Grid_Rp.AllowUserToAddRows = false;
            this._Dg_Grid_Rp.AllowUserToDeleteRows = false;
            this._Dg_Grid_Rp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid_Rp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column7,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this._Dg_Grid_RpCol_diasvenc,
            this._Dg_Grid_RpCol_tpodoc_id,
            this.Column24,
            this.Column25,
            this.Column26,
            this.Column9});
            this._Dg_Grid_Rp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid_Rp.Location = new System.Drawing.Point(0, 0);
            this._Dg_Grid_Rp.Name = "_Dg_Grid_Rp";
            this._Dg_Grid_Rp.ReadOnly = true;
            this._Dg_Grid_Rp.Size = new System.Drawing.Size(771, 340);
            this._Dg_Grid_Rp.TabIndex = 13;
            this._Dg_Grid_Rp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_Rp_CellClick);
            this._Dg_Grid_Rp.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_Rp_RowHeaderMouseClick);
            this._Dg_Grid_Rp.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_Rp_CellMouseEnter);
            this._Dg_Grid_Rp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_Rp_CellContentClick);
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Id";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // Column7
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column7.HeaderText = "Proveedor";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Emisión";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Vencimiento";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "Documento";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Tipo";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Column5.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column5.HeaderText = "Monto";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Column6.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column6.HeaderText = "Saldo";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "PROV_ID";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Visible = false;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "FLAG_COLOR";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Visible = false;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "Vencidos";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "ctotalimp";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Visible = false;
            // 
            // _Dg_Grid_RpCol_diasvenc
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this._Dg_Grid_RpCol_diasvenc.DefaultCellStyle = dataGridViewCellStyle5;
            this._Dg_Grid_RpCol_diasvenc.HeaderText = "Por vencer";
            this._Dg_Grid_RpCol_diasvenc.Name = "_Dg_Grid_RpCol_diasvenc";
            this._Dg_Grid_RpCol_diasvenc.ReadOnly = true;
            this._Dg_Grid_RpCol_diasvenc.ToolTipText = "Dias por vencer";
            // 
            // _Dg_Grid_RpCol_tpodoc_id
            // 
            this._Dg_Grid_RpCol_tpodoc_id.HeaderText = "TpoDoc";
            this._Dg_Grid_RpCol_tpodoc_id.Name = "_Dg_Grid_RpCol_tpodoc_id";
            this._Dg_Grid_RpCol_tpodoc_id.ReadOnly = true;
            this._Dg_Grid_RpCol_tpodoc_id.Visible = false;
            // 
            // Column24
            // 
            this.Column24.HeaderText = "Factura Afec.";
            this.Column24.Name = "Column24";
            this.Column24.ReadOnly = true;
            // 
            // Column25
            // 
            this.Column25.HeaderText = "NRecepcion";
            this.Column25.Name = "Column25";
            this.Column25.ReadOnly = true;
            this.Column25.Visible = false;
            // 
            // Column26
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column26.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column26.HeaderText = "Retencion";
            this.Column26.Name = "Column26";
            this.Column26.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Marcado";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // _CMen_OrdPago
            // 
            this._CMen_OrdPago.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._CMen_OrdPago_Sel});
            this._CMen_OrdPago.Name = "_CMen_OrdPago";
            this._CMen_OrdPago.Size = new System.Drawing.Size(140, 26);
            this._CMen_OrdPago.Opening += new System.ComponentModel.CancelEventHandler(this._CMen_OrdPago_Opening);
            // 
            // _CMen_OrdPago_Sel
            // 
            this._CMen_OrdPago_Sel.Name = "_CMen_OrdPago_Sel";
            this._CMen_OrdPago_Sel.Size = new System.Drawing.Size(139, 22);
            this._CMen_OrdPago_Sel.Text = "Seleccionar";
            this._CMen_OrdPago_Sel.Click += new System.EventHandler(this._CMen_OrdPago_Sel_Click);
            // 
            // _Pnl_A
            // 
            this._Pnl_A.Controls.Add(this._Bt_Cancel);
            this._Pnl_A.Controls.Add(this._Bt_Ok);
            this._Pnl_A.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Pnl_A.Location = new System.Drawing.Point(0, 351);
            this._Pnl_A.Name = "_Pnl_A";
            this._Pnl_A.Size = new System.Drawing.Size(771, 44);
            this._Pnl_A.TabIndex = 15;
            this._Pnl_A.Paint += new System.Windows.Forms.PaintEventHandler(this._Pnl_A_Paint);
            // 
            // _Bt_Cancel
            // 
            this._Bt_Cancel.Location = new System.Drawing.Point(393, 12);
            this._Bt_Cancel.Name = "_Bt_Cancel";
            this._Bt_Cancel.Size = new System.Drawing.Size(75, 21);
            this._Bt_Cancel.TabIndex = 1;
            this._Bt_Cancel.Text = "Cancelar";
            this._Bt_Cancel.UseVisualStyleBackColor = true;
            this._Bt_Cancel.Click += new System.EventHandler(this._Bt_Cancel_Click);
            // 
            // _Bt_Ok
            // 
            this._Bt_Ok.Location = new System.Drawing.Point(312, 12);
            this._Bt_Ok.Name = "_Bt_Ok";
            this._Bt_Ok.Size = new System.Drawing.Size(75, 21);
            this._Bt_Ok.TabIndex = 0;
            this._Bt_Ok.Text = "Aceptar";
            this._Bt_Ok.UseVisualStyleBackColor = true;
            this._Bt_Ok.Click += new System.EventHandler(this._Bt_Ok_Click);
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(0, 340);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(771, 11);
            this._Lbl_DgInfo.TabIndex = 16;
            this._Lbl_DgInfo.Text = "Use botón derecho";
            this._Lbl_DgInfo.Visible = false;
            // 
            // Frm_CxPVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 395);
            this.Controls.Add(this._Dg_Grid_Rp);
            this.Controls.Add(this._Lbl_DgInfo);
            this.Controls.Add(this._Pnl_A);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_CxPVista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas por Pagar";
            this.Load += new System.EventHandler(this.Frm_CxPVista_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_Rp)).EndInit();
            this._CMen_OrdPago.ResumeLayout(false);
            this._Pnl_A.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip _CMen_OrdPago;
        private System.Windows.Forms.ToolStripMenuItem _CMen_OrdPago_Sel;
        private System.Windows.Forms.Panel _Pnl_A;
        private System.Windows.Forms.Button _Bt_Cancel;
        private System.Windows.Forms.Button _Bt_Ok;
        public System.Windows.Forms.DataGridView _Dg_Grid_Rp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_Grid_RpCol_diasvenc;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_Grid_RpCol_tpodoc_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column25;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column26;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Label _Lbl_DgInfo;
    }
}