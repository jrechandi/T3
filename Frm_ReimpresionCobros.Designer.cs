namespace T3
{
    partial class Frm_ReimpresionCobros
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ReimpresionCobros));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this._Bt_Caja = new System.Windows.Forms.Button();
            this._Txt_Caja = new System.Windows.Forms.TextBox();
            this._Bt_Consultar = new System.Windows.Forms.Button();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this._Bt_Caja);
            this.panel1.Controls.Add(this._Txt_Caja);
            this.panel1.Controls.Add(this._Bt_Consultar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(713, 44);
            this.panel1.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 12);
            this.label5.TabIndex = 124;
            this.label5.Text = "Caja:";
            // 
            // _Bt_Caja
            // 
            this._Bt_Caja.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Caja.Image")));
            this._Bt_Caja.Location = new System.Drawing.Point(173, 13);
            this._Bt_Caja.Name = "_Bt_Caja";
            this._Bt_Caja.Size = new System.Drawing.Size(26, 18);
            this._Bt_Caja.TabIndex = 66;
            this._Bt_Caja.Text = "...";
            this._Bt_Caja.UseVisualStyleBackColor = true;
            this._Bt_Caja.Click += new System.EventHandler(this._Bt_Caja_Click);
            // 
            // _Txt_Caja
            // 
            this._Txt_Caja.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._Txt_Caja.Enabled = false;
            this._Txt_Caja.Location = new System.Drawing.Point(45, 12);
            this._Txt_Caja.Name = "_Txt_Caja";
            this._Txt_Caja.ReadOnly = true;
            this._Txt_Caja.Size = new System.Drawing.Size(122, 20);
            this._Txt_Caja.TabIndex = 65;
            // 
            // _Bt_Consultar
            // 
            this._Bt_Consultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Consultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Consultar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Consultar.Image")));
            this._Bt_Consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Consultar.Location = new System.Drawing.Point(215, 7);
            this._Bt_Consultar.Name = "_Bt_Consultar";
            this._Bt_Consultar.Size = new System.Drawing.Size(117, 29);
            this._Bt_Consultar.TabIndex = 63;
            this._Bt_Consultar.Text = "Consultar";
            this._Bt_Consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Consultar.UseVisualStyleBackColor = true;
            this._Bt_Consultar.Click += new System.EventHandler(this._Bt_Consultar_Click);
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Dg_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(0, 44);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Size = new System.Drawing.Size(713, 309);
            this._Dg_Grid.TabIndex = 9;
            this._Dg_Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_CellClick);
            // 
            // Frm_ReimpresionCobros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 353);
            this.Controls.Add(this._Dg_Grid);
            this.Controls.Add(this.panel1);
            this.Name = "Frm_ReimpresionCobros";
            this.Text = "Consulta de relaciones de cobranza";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button _Bt_Caja;
        private System.Windows.Forms.TextBox _Txt_Caja;
        private System.Windows.Forms.Button _Bt_Consultar;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.DataGridView _Dg_Grid;
    }
}