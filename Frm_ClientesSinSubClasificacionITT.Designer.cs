namespace T3
{
    partial class Frm_ClientesSinSubClasificacionITT
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this._Dtp_FechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this._Dtp_FechaDesde = new System.Windows.Forms.DateTimePicker();
            this._Btn_Consultar = new System.Windows.Forms.Button();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this._Rbt_PorFecha = new System.Windows.Forms.RadioButton();
            this._Rbt_PorCodigoCliente = new System.Windows.Forms.RadioButton();
            this._Pnl_PorFecha = new System.Windows.Forms.Panel();
            this._Pnl_PorCliente = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this._Txt_CodCliente = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this._Pnl_PorFecha.SuspendLayout();
            this._Pnl_PorCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Pnl_PorCliente);
            this.panel1.Controls.Add(this._Pnl_PorFecha);
            this.panel1.Controls.Add(this._Rbt_PorCodigoCliente);
            this.panel1.Controls.Add(this._Rbt_PorFecha);
            this.panel1.Controls.Add(this._Btn_Consultar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 73);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Hasta:";
            // 
            // _Dtp_FechaHasta
            // 
            this._Dtp_FechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dtp_FechaHasta.Location = new System.Drawing.Point(189, 5);
            this._Dtp_FechaHasta.Name = "_Dtp_FechaHasta";
            this._Dtp_FechaHasta.Size = new System.Drawing.Size(89, 20);
            this._Dtp_FechaHasta.TabIndex = 8;
            this._Dtp_FechaHasta.ValueChanged += new System.EventHandler(this._Dtp_FechaHasta_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Desde:";
            // 
            // _Dtp_FechaDesde
            // 
            this._Dtp_FechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dtp_FechaDesde.Location = new System.Drawing.Point(50, 5);
            this._Dtp_FechaDesde.Name = "_Dtp_FechaDesde";
            this._Dtp_FechaDesde.Size = new System.Drawing.Size(89, 20);
            this._Dtp_FechaDesde.TabIndex = 6;
            this._Dtp_FechaDesde.ValueChanged += new System.EventHandler(this._Dtp_FechaDesde_ValueChanged);
            // 
            // _Btn_Consultar
            // 
            this._Btn_Consultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Btn_Consultar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Btn_Consultar.Image = global::T3.Properties.Resources.magnifier;
            this._Btn_Consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Btn_Consultar.Location = new System.Drawing.Point(371, 34);
            this._Btn_Consultar.Name = "_Btn_Consultar";
            this._Btn_Consultar.Size = new System.Drawing.Size(118, 30);
            this._Btn_Consultar.TabIndex = 5;
            this._Btn_Consultar.Text = "Consultar..";
            this._Btn_Consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Btn_Consultar.UseVisualStyleBackColor = true;
            this._Btn_Consultar.Click += new System.EventHandler(this._Btn_Consultar_Click);
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(0, 73);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Size = new System.Drawing.Size(684, 265);
            this._Dg_Grid.TabIndex = 34;
            this._Dg_Grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseDoubleClick);
            // 
            // _Rbt_PorFecha
            // 
            this._Rbt_PorFecha.AutoSize = true;
            this._Rbt_PorFecha.Checked = true;
            this._Rbt_PorFecha.Location = new System.Drawing.Point(12, 10);
            this._Rbt_PorFecha.Name = "_Rbt_PorFecha";
            this._Rbt_PorFecha.Size = new System.Drawing.Size(125, 17);
            this._Rbt_PorFecha.TabIndex = 10;
            this._Rbt_PorFecha.TabStop = true;
            this._Rbt_PorFecha.Text = "Búsqueda Por Fecha";
            this._Rbt_PorFecha.UseVisualStyleBackColor = true;
            this._Rbt_PorFecha.CheckedChanged += new System.EventHandler(this._Rbt_PorFecha_CheckedChanged);
            // 
            // _Rbt_PorCodigoCliente
            // 
            this._Rbt_PorCodigoCliente.AutoSize = true;
            this._Rbt_PorCodigoCliente.Location = new System.Drawing.Point(159, 10);
            this._Rbt_PorCodigoCliente.Name = "_Rbt_PorCodigoCliente";
            this._Rbt_PorCodigoCliente.Size = new System.Drawing.Size(176, 17);
            this._Rbt_PorCodigoCliente.TabIndex = 11;
            this._Rbt_PorCodigoCliente.TabStop = true;
            this._Rbt_PorCodigoCliente.Text = "Búsqueda Por código de cliente";
            this._Rbt_PorCodigoCliente.UseVisualStyleBackColor = true;
            this._Rbt_PorCodigoCliente.CheckedChanged += new System.EventHandler(this._Rbt_PorCodigoCliente_CheckedChanged);
            // 
            // _Pnl_PorFecha
            // 
            this._Pnl_PorFecha.Controls.Add(this.label3);
            this._Pnl_PorFecha.Controls.Add(this._Dtp_FechaDesde);
            this._Pnl_PorFecha.Controls.Add(this._Dtp_FechaHasta);
            this._Pnl_PorFecha.Controls.Add(this.label4);
            this._Pnl_PorFecha.Location = new System.Drawing.Point(12, 33);
            this._Pnl_PorFecha.Name = "_Pnl_PorFecha";
            this._Pnl_PorFecha.Size = new System.Drawing.Size(288, 30);
            this._Pnl_PorFecha.TabIndex = 12;
            // 
            // _Pnl_PorCliente
            // 
            this._Pnl_PorCliente.Controls.Add(this._Txt_CodCliente);
            this._Pnl_PorCliente.Controls.Add(this.label1);
            this._Pnl_PorCliente.Location = new System.Drawing.Point(160, 34);
            this._Pnl_PorCliente.Name = "_Pnl_PorCliente";
            this._Pnl_PorCliente.Size = new System.Drawing.Size(205, 26);
            this._Pnl_PorCliente.TabIndex = 13;
            this._Pnl_PorCliente.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Código Cliente:";
            // 
            // _Txt_CodCliente
            // 
            this._Txt_CodCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_CodCliente.Location = new System.Drawing.Point(85, 3);
            this._Txt_CodCliente.Name = "_Txt_CodCliente";
            this._Txt_CodCliente.Size = new System.Drawing.Size(100, 20);
            this._Txt_CodCliente.TabIndex = 9;
            this._Txt_CodCliente.TextChanged += new System.EventHandler(this._Txt_CodCliente_TextChanged);
            this._Txt_CodCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_CodCliente_KeyPress);
            // 
            // Frm_ClientesSinSubClasificacionITT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 338);
            this.Controls.Add(this._Dg_Grid);
            this.Controls.Add(this.panel1);
            this.Name = "Frm_ClientesSinSubClasificacionITT";
            this.Text = "Frm_ClientesSinSubClasificacionITT";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this._Pnl_PorFecha.ResumeLayout(false);
            this._Pnl_PorFecha.PerformLayout();
            this._Pnl_PorCliente.ResumeLayout(false);
            this._Pnl_PorCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _Btn_Consultar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker _Dtp_FechaHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker _Dtp_FechaDesde;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.Panel _Pnl_PorCliente;
        private System.Windows.Forms.TextBox _Txt_CodCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel _Pnl_PorFecha;
        private System.Windows.Forms.RadioButton _Rbt_PorCodigoCliente;
        private System.Windows.Forms.RadioButton _Rbt_PorFecha;
    }
}