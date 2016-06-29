namespace T3
{
    partial class Frm_VstCuentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_VstCuentas));
            this._Tv_Main = new System.Windows.Forms.TreeView();
            this._Bt_Ok = new System.Windows.Forms.Button();
            this._Bt_Cancel = new System.Windows.Forms.Button();
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this._TbP_Cuentas = new System.Windows.Forms.TabPage();
            this._TbP_Parametro = new System.Windows.Forms.TabPage();
            this._Rb_Banco = new System.Windows.Forms.RadioButton();
            this._Rb_Prov = new System.Windows.Forms.RadioButton();
            this._Tb_Tab.SuspendLayout();
            this._TbP_Cuentas.SuspendLayout();
            this._TbP_Parametro.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Tv_Main
            // 
            this._Tv_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Tv_Main.CheckBoxes = true;
            this._Tv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Tv_Main.Location = new System.Drawing.Point(3, 3);
            this._Tv_Main.Name = "_Tv_Main";
            this._Tv_Main.Size = new System.Drawing.Size(585, 348);
            this._Tv_Main.TabIndex = 0;
            this._Tv_Main.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this._Tv_Main_AfterCheck);
            this._Tv_Main.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this._Tv_Main_BeforeCheck);
            // 
            // _Bt_Ok
            // 
            this._Bt_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Ok.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Ok.Image")));
            this._Bt_Ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Ok.Location = new System.Drawing.Point(0, 385);
            this._Bt_Ok.Name = "_Bt_Ok";
            this._Bt_Ok.Size = new System.Drawing.Size(68, 31);
            this._Bt_Ok.TabIndex = 1;
            this._Bt_Ok.Text = "Aceptar";
            this._Bt_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Ok.UseVisualStyleBackColor = true;
            this._Bt_Ok.Click += new System.EventHandler(this._Bt_Ok_Click);
            // 
            // _Bt_Cancel
            // 
            this._Bt_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Cancel.Image")));
            this._Bt_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Cancel.Location = new System.Drawing.Point(74, 385);
            this._Bt_Cancel.Name = "_Bt_Cancel";
            this._Bt_Cancel.Size = new System.Drawing.Size(73, 31);
            this._Bt_Cancel.TabIndex = 2;
            this._Bt_Cancel.Text = "Cancelar";
            this._Bt_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Cancel.UseVisualStyleBackColor = true;
            this._Bt_Cancel.Click += new System.EventHandler(this._Bt_Cancel_Click);
            // 
            // _Tb_Tab
            // 
            this._Tb_Tab.Controls.Add(this._TbP_Cuentas);
            this._Tb_Tab.Controls.Add(this._TbP_Parametro);
            this._Tb_Tab.Dock = System.Windows.Forms.DockStyle.Top;
            this._Tb_Tab.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Tb_Tab.Location = new System.Drawing.Point(0, 0);
            this._Tb_Tab.Name = "_Tb_Tab";
            this._Tb_Tab.SelectedIndex = 0;
            this._Tb_Tab.Size = new System.Drawing.Size(599, 379);
            this._Tb_Tab.TabIndex = 0;
            // 
            // _TbP_Cuentas
            // 
            this._TbP_Cuentas.Controls.Add(this._Tv_Main);
            this._TbP_Cuentas.Location = new System.Drawing.Point(4, 21);
            this._TbP_Cuentas.Name = "_TbP_Cuentas";
            this._TbP_Cuentas.Padding = new System.Windows.Forms.Padding(3);
            this._TbP_Cuentas.Size = new System.Drawing.Size(591, 354);
            this._TbP_Cuentas.TabIndex = 0;
            this._TbP_Cuentas.Text = "Maestro de Cuentas";
            this._TbP_Cuentas.UseVisualStyleBackColor = true;
            // 
            // _TbP_Parametro
            // 
            this._TbP_Parametro.Controls.Add(this._Rb_Banco);
            this._TbP_Parametro.Controls.Add(this._Rb_Prov);
            this._TbP_Parametro.Location = new System.Drawing.Point(4, 22);
            this._TbP_Parametro.Name = "_TbP_Parametro";
            this._TbP_Parametro.Padding = new System.Windows.Forms.Padding(3);
            this._TbP_Parametro.Size = new System.Drawing.Size(591, 353);
            this._TbP_Parametro.TabIndex = 1;
            this._TbP_Parametro.Text = "Parámetros";
            this._TbP_Parametro.UseVisualStyleBackColor = true;
            // 
            // _Rb_Banco
            // 
            this._Rb_Banco.AutoSize = true;
            this._Rb_Banco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Rb_Banco.Location = new System.Drawing.Point(322, 41);
            this._Rb_Banco.Name = "_Rb_Banco";
            this._Rb_Banco.Size = new System.Drawing.Size(110, 16);
            this._Rb_Banco.TabIndex = 1;
            this._Rb_Banco.TabStop = true;
            this._Rb_Banco.Text = "General de Banco";
            this._Rb_Banco.UseVisualStyleBackColor = true;
            this._Rb_Banco.CheckedChanged += new System.EventHandler(this._Rb_Banco_CheckedChanged);
            // 
            // _Rb_Prov
            // 
            this._Rb_Prov.AutoSize = true;
            this._Rb_Prov.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Rb_Prov.Location = new System.Drawing.Point(111, 41);
            this._Rb_Prov.Name = "_Rb_Prov";
            this._Rb_Prov.Size = new System.Drawing.Size(130, 16);
            this._Rb_Prov.TabIndex = 0;
            this._Rb_Prov.TabStop = true;
            this._Rb_Prov.Text = "General de Proveedor";
            this._Rb_Prov.UseVisualStyleBackColor = true;
            this._Rb_Prov.CheckedChanged += new System.EventHandler(this._Rb_Prov_CheckedChanged);
            // 
            // Frm_VstCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 418);
            this.Controls.Add(this._Tb_Tab);
            this.Controls.Add(this._Bt_Cancel);
            this.Controls.Add(this._Bt_Ok);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_VstCuentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maestro de Cuentas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_VstCuentas_FormClosing);
            this.Load += new System.EventHandler(this.Frm_VstCuentas_Load);
            this._Tb_Tab.ResumeLayout(false);
            this._TbP_Cuentas.ResumeLayout(false);
            this._TbP_Parametro.ResumeLayout(false);
            this._TbP_Parametro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView _Tv_Main;
        private System.Windows.Forms.Button _Bt_Ok;
        private System.Windows.Forms.Button _Bt_Cancel;
        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage _TbP_Cuentas;
        private System.Windows.Forms.TabPage _TbP_Parametro;
        private System.Windows.Forms.RadioButton _Rb_Banco;
        private System.Windows.Forms.RadioButton _Rb_Prov;
    }
}