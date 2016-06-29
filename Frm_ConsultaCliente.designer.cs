namespace T3
{
    partial class Frm_ConsultaCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ConsultaCliente));
            this._LstChkClientes = new System.Windows.Forms.CheckedListBox();
            this._Bt_Aceptar = new System.Windows.Forms.Button();
            this._Bt_Cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _LstChkClientes
            // 
            this._LstChkClientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._LstChkClientes.FormattingEnabled = true;
            this._LstChkClientes.Location = new System.Drawing.Point(26, 13);
            this._LstChkClientes.Name = "_LstChkClientes";
            this._LstChkClientes.Size = new System.Drawing.Size(472, 317);
            this._LstChkClientes.TabIndex = 4;
            this._LstChkClientes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this._LstChkClientes_ItemCheck);
            // 
            // _Bt_Aceptar
            // 
            this._Bt_Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Bt_Aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Aceptar.Location = new System.Drawing.Point(182, 346);
            this._Bt_Aceptar.Name = "_Bt_Aceptar";
            this._Bt_Aceptar.Size = new System.Drawing.Size(78, 22);
            this._Bt_Aceptar.TabIndex = 68;
            this._Bt_Aceptar.Text = "Aceptar";
            this._Bt_Aceptar.UseVisualStyleBackColor = true;
            this._Bt_Aceptar.Click += new System.EventHandler(this._Bt_Aceptar_Click);
            // 
            // _Bt_Cancelar
            // 
            this._Bt_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Bt_Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Cancelar.Location = new System.Drawing.Point(266, 346);
            this._Bt_Cancelar.Name = "_Bt_Cancelar";
            this._Bt_Cancelar.Size = new System.Drawing.Size(78, 22);
            this._Bt_Cancelar.TabIndex = 69;
            this._Bt_Cancelar.Text = "Cancelar";
            this._Bt_Cancelar.UseVisualStyleBackColor = true;
            this._Bt_Cancelar.Click += new System.EventHandler(this._Bt_Cancelar_Click);
            // 
            // Frm_ConsultaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 380);
            this.Controls.Add(this._Bt_Cancelar);
            this.Controls.Add(this._Bt_Aceptar);
            this.Controls.Add(this._LstChkClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ConsultaCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de clientes";
            this.Load += new System.EventHandler(this.Frm_ConsultaCliente_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox _LstChkClientes;
        private System.Windows.Forms.Button _Bt_Aceptar;
        private System.Windows.Forms.Button _Bt_Cancelar;
    }
}