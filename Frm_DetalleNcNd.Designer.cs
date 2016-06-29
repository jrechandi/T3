namespace T3
{
    partial class Frm_DetalleNcNd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_DetalleNcNd));
            this._Lb_Etiquea = new System.Windows.Forms.Label();
            this._Dg_Datagrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // _Lb_Etiquea
            // 
            this._Lb_Etiquea.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._Lb_Etiquea.Dock = System.Windows.Forms.DockStyle.Top;
            this._Lb_Etiquea.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._Lb_Etiquea.Location = new System.Drawing.Point(0, 0);
            this._Lb_Etiquea.Name = "_Lb_Etiquea";
            this._Lb_Etiquea.Size = new System.Drawing.Size(729, 21);
            this._Lb_Etiquea.TabIndex = 9;
            this._Lb_Etiquea.Text = "Detalle";
            this._Lb_Etiquea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Dg_Datagrid
            // 
            this._Dg_Datagrid.AllowUserToAddRows = false;
            this._Dg_Datagrid.AllowUserToDeleteRows = false;
            this._Dg_Datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._Dg_Datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Datagrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Datagrid.Location = new System.Drawing.Point(0, 21);
            this._Dg_Datagrid.Name = "_Dg_Datagrid";
            this._Dg_Datagrid.ReadOnly = true;
            this._Dg_Datagrid.Size = new System.Drawing.Size(729, 172);
            this._Dg_Datagrid.TabIndex = 10;
            this._Dg_Datagrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Datagrid_CellContentClick);
            // 
            // Frm_DetalleNcNd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 193);
            this.Controls.Add(this._Dg_Datagrid);
            this.Controls.Add(this._Lb_Etiquea);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_DetalleNcNd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Frm_OCporcerrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Datagrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _Lb_Etiquea;
        private System.Windows.Forms.DataGridView _Dg_Datagrid;

    }
}