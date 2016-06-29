namespace T3
{
    partial class Frm_FactorCuotaCob
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_FactorCuotaCob));
            this._Txt_Factor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Pnl_FactorCuota = new System.Windows.Forms.Panel();
            this._Bt_Cancel = new System.Windows.Forms.Button();
            this._Bt_Ok = new System.Windows.Forms.Button();
            this._Lbl_Cab = new System.Windows.Forms.Label();
            this._Lst_Zona = new System.Windows.Forms.ListBox();
            this._Pnl_FactorCuota.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Txt_Factor
            // 
            this._Txt_Factor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Factor.Location = new System.Drawing.Point(13, 29);
            this._Txt_Factor.MaxLength = 30;
            this._Txt_Factor.Name = "_Txt_Factor";
            this._Txt_Factor.Size = new System.Drawing.Size(176, 18);
            this._Txt_Factor.TabIndex = 1;
            this._Txt_Factor.Leave += new System.EventHandler(this._Txt_Factor_Leave);
            this._Txt_Factor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Factor_KeyPress);
            this._Txt_Factor.Enter += new System.EventHandler(this._Txt_Factor_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Zona de Venta:";
            // 
            // _Pnl_FactorCuota
            // 
            this._Pnl_FactorCuota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_FactorCuota.Controls.Add(this._Bt_Cancel);
            this._Pnl_FactorCuota.Controls.Add(this._Bt_Ok);
            this._Pnl_FactorCuota.Controls.Add(this._Lbl_Cab);
            this._Pnl_FactorCuota.Controls.Add(this._Txt_Factor);
            this._Pnl_FactorCuota.Location = new System.Drawing.Point(287, 23);
            this._Pnl_FactorCuota.Name = "_Pnl_FactorCuota";
            this._Pnl_FactorCuota.Size = new System.Drawing.Size(200, 87);
            this._Pnl_FactorCuota.TabIndex = 2;
            this._Pnl_FactorCuota.Visible = false;
            // 
            // _Bt_Cancel
            // 
            this._Bt_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Cancel.Location = new System.Drawing.Point(105, 53);
            this._Bt_Cancel.Name = "_Bt_Cancel";
            this._Bt_Cancel.Size = new System.Drawing.Size(75, 21);
            this._Bt_Cancel.TabIndex = 3;
            this._Bt_Cancel.Text = "Cancelar";
            this._Bt_Cancel.UseVisualStyleBackColor = true;
            this._Bt_Cancel.Click += new System.EventHandler(this._Bt_Cancel_Click);
            // 
            // _Bt_Ok
            // 
            this._Bt_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Ok.Location = new System.Drawing.Point(24, 53);
            this._Bt_Ok.Name = "_Bt_Ok";
            this._Bt_Ok.Size = new System.Drawing.Size(75, 21);
            this._Bt_Ok.TabIndex = 2;
            this._Bt_Ok.Text = "Aceptar";
            this._Bt_Ok.UseVisualStyleBackColor = true;
            this._Bt_Ok.Click += new System.EventHandler(this._Bt_Ok_Click);
            // 
            // _Lbl_Cab
            // 
            this._Lbl_Cab.BackColor = System.Drawing.Color.Navy;
            this._Lbl_Cab.Dock = System.Windows.Forms.DockStyle.Top;
            this._Lbl_Cab.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._Lbl_Cab.Location = new System.Drawing.Point(0, 0);
            this._Lbl_Cab.Name = "_Lbl_Cab";
            this._Lbl_Cab.Size = new System.Drawing.Size(198, 18);
            this._Lbl_Cab.TabIndex = 0;
            this._Lbl_Cab.Text = "Factor de Cuota";
            this._Lbl_Cab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Lst_Zona
            // 
            this._Lst_Zona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Lst_Zona.FormattingEnabled = true;
            this._Lst_Zona.ItemHeight = 12;
            this._Lst_Zona.Location = new System.Drawing.Point(12, 22);
            this._Lst_Zona.Name = "_Lst_Zona";
            this._Lst_Zona.Size = new System.Drawing.Size(269, 182);
            this._Lst_Zona.TabIndex = 1;
            this._Lst_Zona.SelectedIndexChanged += new System.EventHandler(this._Lst_Zona_SelectedIndexChanged);
            // 
            // Frm_FactorCuotaCob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 214);
            this.Controls.Add(this._Lst_Zona);
            this.Controls.Add(this._Pnl_FactorCuota);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_FactorCuotaCob";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factor de cálculo en la cuota de cobranza";
            this.Load += new System.EventHandler(this.Frm_FactorCuotaCob_Load);
            this.Activated += new System.EventHandler(this.Frm_FactorCuotaCob_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_FactorCuotaCob_FormClosing);
            this._Pnl_FactorCuota.ResumeLayout(false);
            this._Pnl_FactorCuota.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _Txt_Factor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel _Pnl_FactorCuota;
        private System.Windows.Forms.Button _Bt_Ok;
        private System.Windows.Forms.Label _Lbl_Cab;
        private System.Windows.Forms.Button _Bt_Cancel;
        private System.Windows.Forms.ListBox _Lst_Zona;
    }
}