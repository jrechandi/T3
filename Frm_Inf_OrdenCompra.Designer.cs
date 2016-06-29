namespace T3
{
    partial class Frm_Inf_OrdenCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Inf_OrdenCompra));
            this._LstChk_Prov = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._Dt_Desde = new System.Windows.Forms.DateTimePicker();
            this._Dt_Hasta = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this._Chk_All = new System.Windows.Forms.CheckBox();
            this._Bt_Print = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this._Lkbl_Ayer = new System.Windows.Forms.LinkLabel();
            this._Lkbl_Hoy = new System.Windows.Forms.LinkLabel();
            this._Bt_Consultar = new System.Windows.Forms.Button();
            this._Dg_Consulta = new System.Windows.Forms.DataGridView();
            this._Dg_Consulta_ColPrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._Dg_Consulta_ColOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_Consulta_ColFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_Consulta_ColProv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_Consulta_ColLlegar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._Dg_Consulta_ColNR = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._Dg_Consulta_ColPovID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Consulta)).BeginInit();
            this.SuspendLayout();
            // 
            // _LstChk_Prov
            // 
            this._LstChk_Prov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._LstChk_Prov.FormattingEnabled = true;
            this._LstChk_Prov.Location = new System.Drawing.Point(14, 24);
            this._LstChk_Prov.Name = "_LstChk_Prov";
            this._LstChk_Prov.Size = new System.Drawing.Size(292, 93);
            this._LstChk_Prov.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Proveedores:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(321, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Desde:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(323, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Hasta:";
            // 
            // _Dt_Desde
            // 
            this._Dt_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dt_Desde.Location = new System.Drawing.Point(368, 12);
            this._Dt_Desde.Name = "_Dt_Desde";
            this._Dt_Desde.Size = new System.Drawing.Size(93, 18);
            this._Dt_Desde.TabIndex = 6;
            this._Dt_Desde.ValueChanged += new System.EventHandler(this._Dt_Desde_ValueChanged);
            // 
            // _Dt_Hasta
            // 
            this._Dt_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dt_Hasta.Location = new System.Drawing.Point(368, 36);
            this._Dt_Hasta.Name = "_Dt_Hasta";
            this._Dt_Hasta.Size = new System.Drawing.Size(93, 18);
            this._Dt_Hasta.TabIndex = 7;
            this._Dt_Hasta.ValueChanged += new System.EventHandler(this._Dt_Hasta_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._Chk_All);
            this.panel2.Controls.Add(this._Bt_Print);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 421);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(482, 39);
            this.panel2.TabIndex = 4;
            // 
            // _Chk_All
            // 
            this._Chk_All.AutoSize = true;
            this._Chk_All.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Chk_All.Location = new System.Drawing.Point(339, 12);
            this._Chk_All.Name = "_Chk_All";
            this._Chk_All.Size = new System.Drawing.Size(52, 16);
            this._Chk_All.TabIndex = 9;
            this._Chk_All.Text = "Todos";
            this._Chk_All.UseVisualStyleBackColor = true;
            this._Chk_All.CheckedChanged += new System.EventHandler(this._Chk_All_CheckedChanged);
            // 
            // _Bt_Print
            // 
            this._Bt_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Print.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Print.Image")));
            this._Bt_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Print.Location = new System.Drawing.Point(400, 6);
            this._Bt_Print.Name = "_Bt_Print";
            this._Bt_Print.Size = new System.Drawing.Size(80, 26);
            this._Bt_Print.TabIndex = 8;
            this._Bt_Print.Text = "Imprimir";
            this._Bt_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Print.UseVisualStyleBackColor = true;
            this._Bt_Print.Click += new System.EventHandler(this._Bt_Print_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._Lkbl_Ayer);
            this.panel3.Controls.Add(this._Lkbl_Hoy);
            this.panel3.Controls.Add(this._Dt_Hasta);
            this.panel3.Controls.Add(this._Bt_Consultar);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this._LstChk_Prov);
            this.panel3.Controls.Add(this._Dt_Desde);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(482, 124);
            this.panel3.TabIndex = 5;
            // 
            // _Lkbl_Ayer
            // 
            this._Lkbl_Ayer.AutoSize = true;
            this._Lkbl_Ayer.Location = new System.Drawing.Point(366, 63);
            this._Lkbl_Ayer.Name = "_Lkbl_Ayer";
            this._Lkbl_Ayer.Size = new System.Drawing.Size(29, 12);
            this._Lkbl_Ayer.TabIndex = 9;
            this._Lkbl_Ayer.TabStop = true;
            this._Lkbl_Ayer.Text = "Ayer";
            this._Lkbl_Ayer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._Lkbl_Ayer_LinkClicked);
            // 
            // _Lkbl_Hoy
            // 
            this._Lkbl_Hoy.AutoSize = true;
            this._Lkbl_Hoy.Location = new System.Drawing.Point(323, 63);
            this._Lkbl_Hoy.Name = "_Lkbl_Hoy";
            this._Lkbl_Hoy.Size = new System.Drawing.Size(25, 12);
            this._Lkbl_Hoy.TabIndex = 8;
            this._Lkbl_Hoy.TabStop = true;
            this._Lkbl_Hoy.Text = "Hoy";
            this._Lkbl_Hoy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._Lkbl_Hoy_LinkClicked);
            // 
            // _Bt_Consultar
            // 
            this._Bt_Consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Consultar.Image")));
            this._Bt_Consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Consultar.Location = new System.Drawing.Point(342, 83);
            this._Bt_Consultar.Name = "_Bt_Consultar";
            this._Bt_Consultar.Size = new System.Drawing.Size(93, 34);
            this._Bt_Consultar.TabIndex = 6;
            this._Bt_Consultar.Text = "Consultar";
            this._Bt_Consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Consultar.UseVisualStyleBackColor = true;
            this._Bt_Consultar.Click += new System.EventHandler(this._Bt_Consultar_Click);
            // 
            // _Dg_Consulta
            // 
            this._Dg_Consulta.AllowUserToAddRows = false;
            this._Dg_Consulta.AllowUserToDeleteRows = false;
            this._Dg_Consulta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Consulta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._Dg_Consulta_ColPrint,
            this._Dg_Consulta_ColOC,
            this._Dg_Consulta_ColFecha,
            this._Dg_Consulta_ColProv,
            this._Dg_Consulta_ColLlegar,
            this._Dg_Consulta_ColNR,
            this._Dg_Consulta_ColPovID});
            this._Dg_Consulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Consulta.Location = new System.Drawing.Point(0, 124);
            this._Dg_Consulta.Name = "_Dg_Consulta";
            this._Dg_Consulta.ReadOnly = true;
            this._Dg_Consulta.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Consulta.Size = new System.Drawing.Size(482, 297);
            this._Dg_Consulta.TabIndex = 6;
            this._Dg_Consulta.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Consulta_CellValueChanged);
            // 
            // _Dg_Consulta_ColPrint
            // 
            this._Dg_Consulta_ColPrint.HeaderText = "Imprimir";
            this._Dg_Consulta_ColPrint.Name = "_Dg_Consulta_ColPrint";
            this._Dg_Consulta_ColPrint.ReadOnly = true;
            this._Dg_Consulta_ColPrint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._Dg_Consulta_ColPrint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _Dg_Consulta_ColOC
            // 
            this._Dg_Consulta_ColOC.HeaderText = "O.C.";
            this._Dg_Consulta_ColOC.Name = "_Dg_Consulta_ColOC";
            this._Dg_Consulta_ColOC.ReadOnly = true;
            // 
            // _Dg_Consulta_ColFecha
            // 
            this._Dg_Consulta_ColFecha.HeaderText = "Fecha";
            this._Dg_Consulta_ColFecha.Name = "_Dg_Consulta_ColFecha";
            this._Dg_Consulta_ColFecha.ReadOnly = true;
            // 
            // _Dg_Consulta_ColProv
            // 
            this._Dg_Consulta_ColProv.HeaderText = "Proveedor";
            this._Dg_Consulta_ColProv.Name = "_Dg_Consulta_ColProv";
            this._Dg_Consulta_ColProv.ReadOnly = true;
            // 
            // _Dg_Consulta_ColLlegar
            // 
            this._Dg_Consulta_ColLlegar.HeaderText = "Por llegar";
            this._Dg_Consulta_ColLlegar.Name = "_Dg_Consulta_ColLlegar";
            this._Dg_Consulta_ColLlegar.ReadOnly = true;
            this._Dg_Consulta_ColLlegar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._Dg_Consulta_ColLlegar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _Dg_Consulta_ColNR
            // 
            this._Dg_Consulta_ColNR.HeaderText = "N.R.";
            this._Dg_Consulta_ColNR.Name = "_Dg_Consulta_ColNR";
            this._Dg_Consulta_ColNR.ReadOnly = true;
            this._Dg_Consulta_ColNR.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._Dg_Consulta_ColNR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _Dg_Consulta_ColPovID
            // 
            this._Dg_Consulta_ColPovID.HeaderText = "ProvID";
            this._Dg_Consulta_ColPovID.Name = "_Dg_Consulta_ColPovID";
            this._Dg_Consulta_ColPovID.ReadOnly = true;
            this._Dg_Consulta_ColPovID.Visible = false;
            // 
            // Frm_Inf_OrdenCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 460);
            this.Controls.Add(this._Dg_Consulta);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Inf_OrdenCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe - Orden de Compra";
            this.Load += new System.EventHandler(this.Frm_Inf_OrdenCompra_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Consulta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox _LstChk_Prov;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker _Dt_Hasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker _Dt_Desde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button _Bt_Consultar;
        private System.Windows.Forms.DataGridView _Dg_Consulta;
        private System.Windows.Forms.Button _Bt_Print;
        private System.Windows.Forms.LinkLabel _Lkbl_Ayer;
        private System.Windows.Forms.LinkLabel _Lkbl_Hoy;
        private System.Windows.Forms.CheckBox _Chk_All;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _Dg_Consulta_ColPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_Consulta_ColOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_Consulta_ColFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_Consulta_ColProv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _Dg_Consulta_ColLlegar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _Dg_Consulta_ColNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_Consulta_ColPovID;
    }
}