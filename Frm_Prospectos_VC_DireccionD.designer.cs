namespace T3
{
    partial class Frm_Prospectos_VC_DireccionD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Prospectos_VC_DireccionD));
            this.panel1 = new System.Windows.Forms.Panel();
            this._Bt_Edit = new System.Windows.Forms.Button();
            this._Bt_TabNuevo = new System.Windows.Forms.Button();
            this._lis_1 = new System.Windows.Forms.ListBox();
            this._Pnl_Direcc = new System.Windows.Forms.Panel();
            this._Bt_Cancel = new System.Windows.Forms.Button();
            this._Bt_Guardar = new System.Windows.Forms.Button();
            this._Cmb_Ciudad = new System.Windows.Forms.ComboBox();
            this._Cmb_Estado = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._Txt_DireccionDespacho = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Txt_CodigoDirecc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this._Pnl_Direcc.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Bt_Edit);
            this.panel1.Controls.Add(this._Bt_TabNuevo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 33);
            this.panel1.TabIndex = 1;
            // 
            // _Bt_Edit
            // 
            this._Bt_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Edit.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Edit.Image")));
            this._Bt_Edit.Location = new System.Drawing.Point(36, 3);
            this._Bt_Edit.Name = "_Bt_Edit";
            this._Bt_Edit.Size = new System.Drawing.Size(27, 24);
            this._Bt_Edit.TabIndex = 5;
            this._Bt_Edit.UseVisualStyleBackColor = true;
            this._Bt_Edit.Click += new System.EventHandler(this._Bt_Edit_Click);
            // 
            // _Bt_TabNuevo
            // 
            this._Bt_TabNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_TabNuevo.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_TabNuevo.Image")));
            this._Bt_TabNuevo.Location = new System.Drawing.Point(3, 3);
            this._Bt_TabNuevo.Name = "_Bt_TabNuevo";
            this._Bt_TabNuevo.Size = new System.Drawing.Size(27, 24);
            this._Bt_TabNuevo.TabIndex = 3;
            this._Bt_TabNuevo.UseVisualStyleBackColor = true;
            this._Bt_TabNuevo.Click += new System.EventHandler(this._Bt_TabNuevo_Click);
            // 
            // _lis_1
            // 
            this._lis_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lis_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lis_1.FormattingEnabled = true;
            this._lis_1.Location = new System.Drawing.Point(0, 33);
            this._lis_1.Name = "_lis_1";
            this._lis_1.Size = new System.Drawing.Size(541, 236);
            this._lis_1.TabIndex = 9;
            // 
            // _Pnl_Direcc
            // 
            this._Pnl_Direcc.BackColor = System.Drawing.SystemColors.Control;
            this._Pnl_Direcc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Direcc.Controls.Add(this._Bt_Cancel);
            this._Pnl_Direcc.Controls.Add(this._Bt_Guardar);
            this._Pnl_Direcc.Controls.Add(this._Cmb_Ciudad);
            this._Pnl_Direcc.Controls.Add(this._Cmb_Estado);
            this._Pnl_Direcc.Controls.Add(this.label4);
            this._Pnl_Direcc.Controls.Add(this.label3);
            this._Pnl_Direcc.Controls.Add(this._Txt_DireccionDespacho);
            this._Pnl_Direcc.Controls.Add(this.label2);
            this._Pnl_Direcc.Controls.Add(this._Txt_CodigoDirecc);
            this._Pnl_Direcc.Controls.Add(this.label1);
            this._Pnl_Direcc.Location = new System.Drawing.Point(40, 31);
            this._Pnl_Direcc.Name = "_Pnl_Direcc";
            this._Pnl_Direcc.Size = new System.Drawing.Size(481, 219);
            this._Pnl_Direcc.TabIndex = 10;
            this._Pnl_Direcc.Visible = false;
            this._Pnl_Direcc.VisibleChanged += new System.EventHandler(this._Pnl_Direcc_VisibleChanged);
            // 
            // _Bt_Cancel
            // 
            this._Bt_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Cancel.Image")));
            this._Bt_Cancel.Location = new System.Drawing.Point(453, -1);
            this._Bt_Cancel.Name = "_Bt_Cancel";
            this._Bt_Cancel.Size = new System.Drawing.Size(27, 28);
            this._Bt_Cancel.TabIndex = 28;
            this._Bt_Cancel.UseVisualStyleBackColor = true;
            this._Bt_Cancel.Click += new System.EventHandler(this._Bt_Cancel_Click);
            // 
            // _Bt_Guardar
            // 
            this._Bt_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Guardar.Image")));
            this._Bt_Guardar.Location = new System.Drawing.Point(-1, -1);
            this._Bt_Guardar.Name = "_Bt_Guardar";
            this._Bt_Guardar.Size = new System.Drawing.Size(27, 28);
            this._Bt_Guardar.TabIndex = 27;
            this._Bt_Guardar.UseVisualStyleBackColor = true;
            this._Bt_Guardar.Click += new System.EventHandler(this._Bt_Guardar_Click);
            // 
            // _Cmb_Ciudad
            // 
            this._Cmb_Ciudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Ciudad.Enabled = false;
            this._Cmb_Ciudad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Ciudad.FormattingEnabled = true;
            this._Cmb_Ciudad.Location = new System.Drawing.Point(15, 183);
            this._Cmb_Ciudad.Name = "_Cmb_Ciudad";
            this._Cmb_Ciudad.Size = new System.Drawing.Size(277, 21);
            this._Cmb_Ciudad.TabIndex = 7;
            // 
            // _Cmb_Estado
            // 
            this._Cmb_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Estado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Estado.FormattingEnabled = true;
            this._Cmb_Estado.Location = new System.Drawing.Point(15, 143);
            this._Cmb_Estado.Name = "_Cmb_Estado";
            this._Cmb_Estado.Size = new System.Drawing.Size(277, 21);
            this._Cmb_Estado.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ciudad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Estado:";
            // 
            // _Txt_DireccionDespacho
            // 
            this._Txt_DireccionDespacho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_DireccionDespacho.Location = new System.Drawing.Point(15, 91);
            this._Txt_DireccionDespacho.MaxLength = 255;
            this._Txt_DireccionDespacho.Multiline = true;
            this._Txt_DireccionDespacho.Name = "_Txt_DireccionDespacho";
            this._Txt_DireccionDespacho.Size = new System.Drawing.Size(439, 33);
            this._Txt_DireccionDespacho.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dirección Despacho:";
            // 
            // _Txt_CodigoDirecc
            // 
            this._Txt_CodigoDirecc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_CodigoDirecc.Enabled = false;
            this._Txt_CodigoDirecc.Location = new System.Drawing.Point(15, 52);
            this._Txt_CodigoDirecc.Name = "_Txt_CodigoDirecc";
            this._Txt_CodigoDirecc.ReadOnly = true;
            this._Txt_CodigoDirecc.Size = new System.Drawing.Size(78, 20);
            this._Txt_CodigoDirecc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // Frm_Prospectos_VC_DireccionD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 280);
            this.Controls.Add(this._Pnl_Direcc);
            this.Controls.Add(this._lis_1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Prospectos_VC_DireccionD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dirección de despacho - Clientes prospecto";
            this.panel1.ResumeLayout(false);
            this._Pnl_Direcc.ResumeLayout(false);
            this._Pnl_Direcc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _Bt_Edit;
        private System.Windows.Forms.Button _Bt_TabNuevo;
        private System.Windows.Forms.ListBox _lis_1;
        private System.Windows.Forms.Panel _Pnl_Direcc;
        private System.Windows.Forms.Button _Bt_Cancel;
        private System.Windows.Forms.Button _Bt_Guardar;
        private System.Windows.Forms.ComboBox _Cmb_Ciudad;
        private System.Windows.Forms.ComboBox _Cmb_Estado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _Txt_DireccionDespacho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _Txt_CodigoDirecc;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Panel panel1;
    }
}