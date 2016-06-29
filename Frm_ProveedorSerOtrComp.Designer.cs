namespace T3
{
    partial class Frm_ProveedorSerOtrComp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ProveedorSerOtrComp));
            this._Pnl_ProveeScomp = new System.Windows.Forms.Panel();
            this._Lst_ProveeScomp = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Bt_BuscarProvSinComp = new System.Windows.Forms.Button();
            this._Txt_ProvSinComp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this._Rb_Otros = new System.Windows.Forms.RadioButton();
            this._Rb_Servicio = new System.Windows.Forms.RadioButton();
            this._Pnl_Selec = new System.Windows.Forms.Panel();
            this._Bt_Agregar = new System.Windows.Forms.Button();
            this._Bt_Actualizar = new System.Windows.Forms.Button();
            this._Bt_Eliminar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._Lst_ProveeRel = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this._Bt_BuscarProvRelComp = new System.Windows.Forms.Button();
            this._Txt_ProvRelComp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._Bt_BuscarRifSinComp = new System.Windows.Forms.Button();
            this._Txt_RifSinComp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._Bt_BuscarRifRelComp = new System.Windows.Forms.Button();
            this._Txt_RifRelComp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._Pnl_ProveeScomp.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this._Pnl_Selec.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Pnl_ProveeScomp
            // 
            this._Pnl_ProveeScomp.Controls.Add(this._Lst_ProveeScomp);
            this._Pnl_ProveeScomp.Controls.Add(this.label1);
            this._Pnl_ProveeScomp.Controls.Add(this.panel1);
            this._Pnl_ProveeScomp.Controls.Add(this.panel2);
            this._Pnl_ProveeScomp.Dock = System.Windows.Forms.DockStyle.Left;
            this._Pnl_ProveeScomp.Location = new System.Drawing.Point(0, 0);
            this._Pnl_ProveeScomp.Name = "_Pnl_ProveeScomp";
            this._Pnl_ProveeScomp.Size = new System.Drawing.Size(497, 567);
            this._Pnl_ProveeScomp.TabIndex = 0;
            // 
            // _Lst_ProveeScomp
            // 
            this._Lst_ProveeScomp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Lst_ProveeScomp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Lst_ProveeScomp.FormattingEnabled = true;
            this._Lst_ProveeScomp.ItemHeight = 12;
            this._Lst_ProveeScomp.Location = new System.Drawing.Point(0, 139);
            this._Lst_ProveeScomp.Name = "_Lst_ProveeScomp";
            this._Lst_ProveeScomp.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this._Lst_ProveeScomp.Size = new System.Drawing.Size(497, 428);
            this._Lst_ProveeScomp.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(497, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Proveedores sin compañía";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Bt_BuscarRifSinComp);
            this.panel1.Controls.Add(this._Txt_RifSinComp);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this._Bt_BuscarProvSinComp);
            this.panel1.Controls.Add(this._Txt_ProvSinComp);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 83);
            this.panel1.TabIndex = 7;
            // 
            // _Bt_BuscarProvSinComp
            // 
            this._Bt_BuscarProvSinComp.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_BuscarProvSinComp.Font = new System.Drawing.Font("Verdana", 6.75F);
            this._Bt_BuscarProvSinComp.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_BuscarProvSinComp.Image")));
            this._Bt_BuscarProvSinComp.Location = new System.Drawing.Point(336, 19);
            this._Bt_BuscarProvSinComp.Name = "_Bt_BuscarProvSinComp";
            this._Bt_BuscarProvSinComp.Size = new System.Drawing.Size(30, 21);
            this._Bt_BuscarProvSinComp.TabIndex = 45;
            this._Bt_BuscarProvSinComp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_BuscarProvSinComp.UseVisualStyleBackColor = true;
            this._Bt_BuscarProvSinComp.Click += new System.EventHandler(this._Bt_BuscarProvSinComp_Click);
            // 
            // _Txt_ProvSinComp
            // 
            this._Txt_ProvSinComp.Location = new System.Drawing.Point(12, 21);
            this._Txt_ProvSinComp.Name = "_Txt_ProvSinComp";
            this._Txt_ProvSinComp.Size = new System.Drawing.Size(318, 18);
            this._Txt_ProvSinComp.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Buscar por descripción:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._Rb_Otros);
            this.panel2.Controls.Add(this._Rb_Servicio);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(497, 36);
            this.panel2.TabIndex = 0;
            // 
            // _Rb_Otros
            // 
            this._Rb_Otros.AutoSize = true;
            this._Rb_Otros.Location = new System.Drawing.Point(97, 10);
            this._Rb_Otros.Name = "_Rb_Otros";
            this._Rb_Otros.Size = new System.Drawing.Size(52, 16);
            this._Rb_Otros.TabIndex = 2;
            this._Rb_Otros.TabStop = true;
            this._Rb_Otros.Text = "Otros";
            this._Rb_Otros.UseVisualStyleBackColor = true;
            this._Rb_Otros.CheckedChanged += new System.EventHandler(this._Rb_Otros_CheckedChanged);
            // 
            // _Rb_Servicio
            // 
            this._Rb_Servicio.AutoSize = true;
            this._Rb_Servicio.Checked = true;
            this._Rb_Servicio.Location = new System.Drawing.Point(12, 10);
            this._Rb_Servicio.Name = "_Rb_Servicio";
            this._Rb_Servicio.Size = new System.Drawing.Size(64, 16);
            this._Rb_Servicio.TabIndex = 1;
            this._Rb_Servicio.TabStop = true;
            this._Rb_Servicio.Text = "Servicio";
            this._Rb_Servicio.UseVisualStyleBackColor = true;
            this._Rb_Servicio.CheckedChanged += new System.EventHandler(this._Rb_Servicio_CheckedChanged);
            // 
            // _Pnl_Selec
            // 
            this._Pnl_Selec.Controls.Add(this._Bt_Agregar);
            this._Pnl_Selec.Controls.Add(this._Bt_Actualizar);
            this._Pnl_Selec.Controls.Add(this._Bt_Eliminar);
            this._Pnl_Selec.Dock = System.Windows.Forms.DockStyle.Left;
            this._Pnl_Selec.Location = new System.Drawing.Point(497, 0);
            this._Pnl_Selec.Name = "_Pnl_Selec";
            this._Pnl_Selec.Size = new System.Drawing.Size(93, 567);
            this._Pnl_Selec.TabIndex = 1;
            // 
            // _Bt_Agregar
            // 
            this._Bt_Agregar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Agregar.Image")));
            this._Bt_Agregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Agregar.Location = new System.Drawing.Point(6, 137);
            this._Bt_Agregar.Name = "_Bt_Agregar";
            this._Bt_Agregar.Size = new System.Drawing.Size(80, 23);
            this._Bt_Agregar.TabIndex = 10;
            this._Bt_Agregar.Text = "Agregar";
            this._Bt_Agregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Agregar.Click += new System.EventHandler(this._Bt_Agregar_Click);
            // 
            // _Bt_Actualizar
            // 
            this._Bt_Actualizar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Actualizar.Image")));
            this._Bt_Actualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Actualizar.Location = new System.Drawing.Point(6, 222);
            this._Bt_Actualizar.Name = "_Bt_Actualizar";
            this._Bt_Actualizar.Size = new System.Drawing.Size(80, 23);
            this._Bt_Actualizar.TabIndex = 12;
            this._Bt_Actualizar.Text = "Actualizar";
            this._Bt_Actualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Actualizar.Click += new System.EventHandler(this._Bt_Actualizar_Click);
            // 
            // _Bt_Eliminar
            // 
            this._Bt_Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Eliminar.Image")));
            this._Bt_Eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Eliminar.Location = new System.Drawing.Point(6, 178);
            this._Bt_Eliminar.Name = "_Bt_Eliminar";
            this._Bt_Eliminar.Size = new System.Drawing.Size(80, 23);
            this._Bt_Eliminar.TabIndex = 11;
            this._Bt_Eliminar.Text = "Eliminar";
            this._Bt_Eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Eliminar.Click += new System.EventHandler(this._Bt_Eliminar_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(590, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(426, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Proveedores relacionados";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Lst_ProveeRel
            // 
            this._Lst_ProveeRel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Lst_ProveeRel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Lst_ProveeRel.FormattingEnabled = true;
            this._Lst_ProveeRel.ItemHeight = 12;
            this._Lst_ProveeRel.Location = new System.Drawing.Point(590, 103);
            this._Lst_ProveeRel.Name = "_Lst_ProveeRel";
            this._Lst_ProveeRel.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this._Lst_ProveeRel.Size = new System.Drawing.Size(426, 464);
            this._Lst_ProveeRel.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._Bt_BuscarRifRelComp);
            this.panel3.Controls.Add(this._Txt_RifRelComp);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this._Bt_BuscarProvRelComp);
            this.panel3.Controls.Add(this._Txt_ProvRelComp);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(590, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(426, 83);
            this.panel3.TabIndex = 8;
            // 
            // _Bt_BuscarProvRelComp
            // 
            this._Bt_BuscarProvRelComp.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_BuscarProvRelComp.Font = new System.Drawing.Font("Verdana", 6.75F);
            this._Bt_BuscarProvRelComp.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_BuscarProvRelComp.Image")));
            this._Bt_BuscarProvRelComp.Location = new System.Drawing.Point(336, 19);
            this._Bt_BuscarProvRelComp.Name = "_Bt_BuscarProvRelComp";
            this._Bt_BuscarProvRelComp.Size = new System.Drawing.Size(30, 21);
            this._Bt_BuscarProvRelComp.TabIndex = 46;
            this._Bt_BuscarProvRelComp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_BuscarProvRelComp.UseVisualStyleBackColor = true;
            this._Bt_BuscarProvRelComp.Click += new System.EventHandler(this._Bt_BuscarProvRelComp_Click);
            // 
            // _Txt_ProvRelComp
            // 
            this._Txt_ProvRelComp.Location = new System.Drawing.Point(12, 21);
            this._Txt_ProvRelComp.Name = "_Txt_ProvRelComp";
            this._Txt_ProvRelComp.Size = new System.Drawing.Size(318, 18);
            this._Txt_ProvRelComp.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "Buscar por descripción:";
            // 
            // _Bt_BuscarRifSinComp
            // 
            this._Bt_BuscarRifSinComp.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_BuscarRifSinComp.Font = new System.Drawing.Font("Verdana", 6.75F);
            this._Bt_BuscarRifSinComp.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_BuscarRifSinComp.Image")));
            this._Bt_BuscarRifSinComp.Location = new System.Drawing.Point(336, 55);
            this._Bt_BuscarRifSinComp.Name = "_Bt_BuscarRifSinComp";
            this._Bt_BuscarRifSinComp.Size = new System.Drawing.Size(30, 21);
            this._Bt_BuscarRifSinComp.TabIndex = 48;
            this._Bt_BuscarRifSinComp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_BuscarRifSinComp.UseVisualStyleBackColor = true;
            this._Bt_BuscarRifSinComp.Click += new System.EventHandler(this._Bt_BuscarRifSinComp_Click);
            // 
            // _Txt_RifSinComp
            // 
            this._Txt_RifSinComp.Location = new System.Drawing.Point(12, 57);
            this._Txt_RifSinComp.Name = "_Txt_RifSinComp";
            this._Txt_RifSinComp.Size = new System.Drawing.Size(318, 18);
            this._Txt_RifSinComp.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 12);
            this.label5.TabIndex = 46;
            this.label5.Text = "Buscar por rif:";
            // 
            // _Bt_BuscarRifRelComp
            // 
            this._Bt_BuscarRifRelComp.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_BuscarRifRelComp.Font = new System.Drawing.Font("Verdana", 6.75F);
            this._Bt_BuscarRifRelComp.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_BuscarRifRelComp.Image")));
            this._Bt_BuscarRifRelComp.Location = new System.Drawing.Point(336, 55);
            this._Bt_BuscarRifRelComp.Name = "_Bt_BuscarRifRelComp";
            this._Bt_BuscarRifRelComp.Size = new System.Drawing.Size(30, 21);
            this._Bt_BuscarRifRelComp.TabIndex = 49;
            this._Bt_BuscarRifRelComp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_BuscarRifRelComp.UseVisualStyleBackColor = true;
            this._Bt_BuscarRifRelComp.Click += new System.EventHandler(this._Bt_BuscarRifRelComp_Click);
            // 
            // _Txt_RifRelComp
            // 
            this._Txt_RifRelComp.Location = new System.Drawing.Point(12, 57);
            this._Txt_RifRelComp.Name = "_Txt_RifRelComp";
            this._Txt_RifRelComp.Size = new System.Drawing.Size(318, 18);
            this._Txt_RifRelComp.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 12);
            this.label6.TabIndex = 47;
            this.label6.Text = "Buscar por rif:";
            // 
            // Frm_ProveedorSerOtrComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 567);
            this.Controls.Add(this._Lst_ProveeRel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this._Pnl_Selec);
            this.Controls.Add(this._Pnl_ProveeScomp);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ProveedorSerOtrComp";
            this.Text = "Asignar proveedores (Servicio - Otros)";
            this.Activated += new System.EventHandler(this.Frm_ProveedorSerOtrComp_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ProveedorSerOtrComp_FormClosing);
            this.Load += new System.EventHandler(this.Frm_ProveedorSerOtrComp_Load);
            this._Pnl_ProveeScomp.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this._Pnl_Selec.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _Pnl_ProveeScomp;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton _Rb_Otros;
        private System.Windows.Forms.RadioButton _Rb_Servicio;
        private System.Windows.Forms.Panel _Pnl_Selec;
        private System.Windows.Forms.Button _Bt_Agregar;
        private System.Windows.Forms.Button _Bt_Actualizar;
        private System.Windows.Forms.Button _Bt_Eliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox _Lst_ProveeScomp;
        private System.Windows.Forms.ListBox _Lst_ProveeRel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox _Txt_ProvSinComp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox _Txt_ProvRelComp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _Bt_BuscarProvSinComp;
        private System.Windows.Forms.Button _Bt_BuscarProvRelComp;
        private System.Windows.Forms.Button _Bt_BuscarRifSinComp;
        private System.Windows.Forms.TextBox _Txt_RifSinComp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button _Bt_BuscarRifRelComp;
        private System.Windows.Forms.TextBox _Txt_RifRelComp;
        private System.Windows.Forms.Label label6;
    }
}