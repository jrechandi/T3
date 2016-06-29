namespace T3
{
    partial class Frm_TarjetasConteo
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
            this._Dtg_Tarjetas = new System.Windows.Forms.DataGridView();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this._Lbl_TipoTarjetas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._Dtg_Tarjetas)).BeginInit();
            this.SuspendLayout();
            // 
            // _Dtg_Tarjetas
            // 
            this._Dtg_Tarjetas.AllowUserToAddRows = false;
            this._Dtg_Tarjetas.AllowUserToDeleteRows = false;
            this._Dtg_Tarjetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dtg_Tarjetas.Location = new System.Drawing.Point(0, 26);
            this._Dtg_Tarjetas.Name = "_Dtg_Tarjetas";
            this._Dtg_Tarjetas.ReadOnly = true;
            this._Dtg_Tarjetas.Size = new System.Drawing.Size(840, 271);
            this._Dtg_Tarjetas.TabIndex = 0;
            this._Dtg_Tarjetas.MouseLeave += new System.EventHandler(this._Dtg_Tarjetas_MouseLeave);
            this._Dtg_Tarjetas.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dtg_Tarjetas_RowHeaderMouseDoubleClick);
            this._Dtg_Tarjetas.MouseEnter += new System.EventHandler(this._Dtg_Tarjetas_MouseEnter);
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(0, 297);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(840, 11);
            this._Lbl_DgInfo.TabIndex = 90;
            this._Lbl_DgInfo.Text = "Use doble click";
            this._Lbl_DgInfo.Visible = false;
            // 
            // _Lbl_TipoTarjetas
            // 
            this._Lbl_TipoTarjetas.Dock = System.Windows.Forms.DockStyle.Top;
            this._Lbl_TipoTarjetas.Location = new System.Drawing.Point(0, 0);
            this._Lbl_TipoTarjetas.Name = "_Lbl_TipoTarjetas";
            this._Lbl_TipoTarjetas.Size = new System.Drawing.Size(840, 26);
            this._Lbl_TipoTarjetas.TabIndex = 0;
            this._Lbl_TipoTarjetas.Text = "Tarjetas";
            this._Lbl_TipoTarjetas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_TarjetasConteo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 308);
            this.Controls.Add(this._Dtg_Tarjetas);
            this.Controls.Add(this._Lbl_TipoTarjetas);
            this.Controls.Add(this._Lbl_DgInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_TarjetasConteo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarjetas ";
            this.Load += new System.EventHandler(this.Frm_TarjetasConteo_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Dtg_Tarjetas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _Dtg_Tarjetas;
        private System.Windows.Forms.Label _Lbl_DgInfo;
        private System.Windows.Forms.Label _Lbl_TipoTarjetas;
    }
}