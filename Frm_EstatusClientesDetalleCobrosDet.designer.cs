namespace T3
{
    partial class Frm_EstatusClientesDetalleCobrosDet
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
            this._Dg_Grid_1 = new System.Windows.Forms.DataGridView();
            this._Dg_Grid_2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_2)).BeginInit();
            this.SuspendLayout();
            // 
            // _Dg_Grid_1
            // 
            this._Dg_Grid_1.AllowUserToAddRows = false;
            this._Dg_Grid_1.AllowUserToDeleteRows = false;
            this._Dg_Grid_1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid_1.Dock = System.Windows.Forms.DockStyle.Top;
            this._Dg_Grid_1.Location = new System.Drawing.Point(0, 21);
            this._Dg_Grid_1.Name = "_Dg_Grid_1";
            this._Dg_Grid_1.ReadOnly = true;
            this._Dg_Grid_1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid_1.Size = new System.Drawing.Size(660, 133);
            this._Dg_Grid_1.TabIndex = 5;
            // 
            // _Dg_Grid_2
            // 
            this._Dg_Grid_2.AllowUserToAddRows = false;
            this._Dg_Grid_2.AllowUserToDeleteRows = false;
            this._Dg_Grid_2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid_2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Dg_Grid_2.Location = new System.Drawing.Point(0, 176);
            this._Dg_Grid_2.Name = "_Dg_Grid_2";
            this._Dg_Grid_2.ReadOnly = true;
            this._Dg_Grid_2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid_2.Size = new System.Drawing.Size(660, 133);
            this._Dg_Grid_2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(660, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Depósitos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(660, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Cheques en tránsito";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_EstatusClientesDetalleCobrosDet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 309);
            this.Controls.Add(this._Dg_Grid_1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._Dg_Grid_2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_EstatusClientesDetalleCobrosDet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de cobros (Detallado)";
            this.Load += new System.EventHandler(this.Frm_EstatusClientesDetalleCobrosDet_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _Dg_Grid_1;
        private System.Windows.Forms.DataGridView _Dg_Grid_2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}