namespace T3
{
    partial class Frm_ExportarIncSPIUser
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
            this._Dtg_GridUser = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._Dtg_GridUser)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Dtg_GridUser
            // 
            this._Dtg_GridUser.AllowUserToAddRows = false;
            this._Dtg_GridUser.AllowUserToDeleteRows = false;
            this._Dtg_GridUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dtg_GridUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dtg_GridUser.Location = new System.Drawing.Point(0, 32);
            this._Dtg_GridUser.Name = "_Dtg_GridUser";
            this._Dtg_GridUser.ReadOnly = true;
            this._Dtg_GridUser.Size = new System.Drawing.Size(674, 218);
            this._Dtg_GridUser.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 32);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(466, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Los siguientes usuarios no pudieron ser localizados en el sistema de nómina SPI:";
            // 
            // Frm_ExportarIncSPIUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 250);
            this.Controls.Add(this._Dtg_GridUser);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ExportarIncSPIUser";
            this.Text = "Frm_ExportarIncSPIUser";
            ((System.ComponentModel.ISupportInitialize)(this._Dtg_GridUser)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _Dtg_GridUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}