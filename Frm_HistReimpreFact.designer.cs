namespace T3
{
    partial class Frm_HistReimpreFact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_HistReimpreFact));
            this.panel1 = new System.Windows.Forms.Panel();
            this._Dt_Hasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this._Dt_Desde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this._Bt_Consultar = new System.Windows.Forms.Button();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this._Lkbl_Ayer = new System.Windows.Forms.LinkLabel();
            this._Lkbl_Hoy = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Lkbl_Ayer);
            this.panel1.Controls.Add(this._Lkbl_Hoy);
            this.panel1.Controls.Add(this._Bt_Consultar);
            this.panel1.Controls.Add(this._Dt_Hasta);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this._Dt_Desde);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1139, 46);
            this.panel1.TabIndex = 5;
            // 
            // _Dt_Hasta
            // 
            this._Dt_Hasta.CustomFormat = "";
            this._Dt_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dt_Hasta.Location = new System.Drawing.Point(207, 14);
            this._Dt_Hasta.Name = "_Dt_Hasta";
            this._Dt_Hasta.Size = new System.Drawing.Size(92, 20);
            this._Dt_Hasta.TabIndex = 45;
            this._Dt_Hasta.ValueChanged += new System.EventHandler(this._Dt_Hasta_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(162, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 12);
            this.label4.TabIndex = 43;
            this.label4.Text = "Hasta:";
            // 
            // _Dt_Desde
            // 
            this._Dt_Desde.CustomFormat = "";
            this._Dt_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dt_Desde.Location = new System.Drawing.Point(50, 14);
            this._Dt_Desde.Name = "_Dt_Desde";
            this._Dt_Desde.Size = new System.Drawing.Size(93, 20);
            this._Dt_Desde.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 12);
            this.label3.TabIndex = 42;
            this.label3.Text = "Desde:";
            // 
            // _Bt_Consultar
            // 
            this._Bt_Consultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Consultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Consultar.Image")));
            this._Bt_Consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Consultar.Location = new System.Drawing.Point(371, 8);
            this._Bt_Consultar.Name = "_Bt_Consultar";
            this._Bt_Consultar.Size = new System.Drawing.Size(109, 30);
            this._Bt_Consultar.TabIndex = 48;
            this._Bt_Consultar.Text = "Consultar";
            this._Bt_Consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Consultar.UseVisualStyleBackColor = true;
            this._Bt_Consultar.Click += new System.EventHandler(this._Bt_Consultar_Click);
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(0, 46);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.Size = new System.Drawing.Size(1139, 443);
            this._Dg_Grid.TabIndex = 6;
            // 
            // _Lkbl_Ayer
            // 
            this._Lkbl_Ayer.AutoSize = true;
            this._Lkbl_Ayer.Location = new System.Drawing.Point(305, 18);
            this._Lkbl_Ayer.Name = "_Lkbl_Ayer";
            this._Lkbl_Ayer.Size = new System.Drawing.Size(28, 13);
            this._Lkbl_Ayer.TabIndex = 50;
            this._Lkbl_Ayer.TabStop = true;
            this._Lkbl_Ayer.Text = "Ayer";
            this._Lkbl_Ayer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._Lkbl_Ayer_LinkClicked);
            // 
            // _Lkbl_Hoy
            // 
            this._Lkbl_Hoy.AutoSize = true;
            this._Lkbl_Hoy.Location = new System.Drawing.Point(339, 18);
            this._Lkbl_Hoy.Name = "_Lkbl_Hoy";
            this._Lkbl_Hoy.Size = new System.Drawing.Size(26, 13);
            this._Lkbl_Hoy.TabIndex = 49;
            this._Lkbl_Hoy.TabStop = true;
            this._Lkbl_Hoy.Text = "Hoy";
            this._Lkbl_Hoy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._Lkbl_Hoy_LinkClicked);
            // 
            // Frm_HistReimpreFact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 489);
            this.Controls.Add(this._Dg_Grid);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_HistReimpreFact";
            this.Text = "Historial de Facturas Reimpresas";
            this.Load += new System.EventHandler(this.Frm_HistReimpreFact_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _Bt_Consultar;
        private System.Windows.Forms.DateTimePicker _Dt_Hasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker _Dt_Desde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.LinkLabel _Lkbl_Ayer;
        private System.Windows.Forms.LinkLabel _Lkbl_Hoy;
    }
}