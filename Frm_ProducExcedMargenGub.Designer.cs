namespace T3
{
    partial class Frm_ProducExcedMargenGub
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ProducExcedMargenGub));
            this._Pnl_Clave = new System.Windows.Forms.Panel();
            this._Txt_Clave = new System.Windows.Forms.TextBox();
            this._Bt_AceptarClave = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this._Bt_CancelarClave = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Bt_Guardar = new System.Windows.Forms.Button();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this._Dt_columna_cfecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dt_columna_cpedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dt_columna_ccliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dt_columna_desccliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dt_columna_cproducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dt_columna_descproducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dt_columna_cprecioventamaximo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dt_columna_ccajaspedidas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dt_columna_cunidadespedidas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dt_columna_cprecioventa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dt_columna_ccostoneto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dt_columna_cmargen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dt_columna_cvistonotificador = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clogid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Pnl_Clave.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _Pnl_Clave
            // 
            this._Pnl_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Clave.Controls.Add(this._Txt_Clave);
            this._Pnl_Clave.Controls.Add(this._Bt_AceptarClave);
            this._Pnl_Clave.Controls.Add(this.label11);
            this._Pnl_Clave.Controls.Add(this._Bt_CancelarClave);
            this._Pnl_Clave.Controls.Add(this.label16);
            this._Pnl_Clave.Location = new System.Drawing.Point(298, 126);
            this._Pnl_Clave.Name = "_Pnl_Clave";
            this._Pnl_Clave.Size = new System.Drawing.Size(160, 86);
            this._Pnl_Clave.TabIndex = 166;
            this._Pnl_Clave.Visible = false;
            this._Pnl_Clave.VisibleChanged += new System.EventHandler(this._Pnl_Clave_VisibleChanged);
            // 
            // _Txt_Clave
            // 
            this._Txt_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Clave.Location = new System.Drawing.Point(50, 31);
            this._Txt_Clave.Name = "_Txt_Clave";
            this._Txt_Clave.PasswordChar = '*';
            this._Txt_Clave.Size = new System.Drawing.Size(95, 20);
            this._Txt_Clave.TabIndex = 2;
            // 
            // _Bt_AceptarClave
            // 
            this._Bt_AceptarClave.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_AceptarClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_AceptarClave.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_AceptarClave.Location = new System.Drawing.Point(20, 55);
            this._Bt_AceptarClave.Name = "_Bt_AceptarClave";
            this._Bt_AceptarClave.Size = new System.Drawing.Size(62, 22);
            this._Bt_AceptarClave.TabIndex = 70;
            this._Bt_AceptarClave.Text = "Aceptar";
            this._Bt_AceptarClave.UseVisualStyleBackColor = true;
            this._Bt_AceptarClave.Click += new System.EventHandler(this._Bt_AceptarClave_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 68;
            this.label11.Text = "Clave:";
            // 
            // _Bt_CancelarClave
            // 
            this._Bt_CancelarClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_CancelarClave.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_CancelarClave.Location = new System.Drawing.Point(83, 55);
            this._Bt_CancelarClave.Name = "_Bt_CancelarClave";
            this._Bt_CancelarClave.Size = new System.Drawing.Size(62, 22);
            this._Bt_CancelarClave.TabIndex = 1;
            this._Bt_CancelarClave.Text = "Cancelar";
            this._Bt_CancelarClave.UseVisualStyleBackColor = true;
            this._Bt_CancelarClave.Click += new System.EventHandler(this._Bt_CancelarClave_Click);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Navy;
            this.label16.Dock = System.Windows.Forms.DockStyle.Top;
            this.label16.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(158, 18);
            this.label16.TabIndex = 0;
            this.label16.Text = "Introduzca Clave";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Bt_Guardar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 326);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1056, 50);
            this.panel1.TabIndex = 164;
            // 
            // _Bt_Guardar
            // 
            this._Bt_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Guardar.Dock = System.Windows.Forms.DockStyle.Right;
            this._Bt_Guardar.FlatAppearance.BorderSize = 0;
            this._Bt_Guardar.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Guardar.Image")));
            this._Bt_Guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Guardar.Location = new System.Drawing.Point(890, 0);
            this._Bt_Guardar.Name = "_Bt_Guardar";
            this._Bt_Guardar.Size = new System.Drawing.Size(166, 50);
            this._Bt_Guardar.TabIndex = 9;
            this._Bt_Guardar.Text = "Marcar como visto";
            this._Bt_Guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Guardar.UseVisualStyleBackColor = true;
            this._Bt_Guardar.Click += new System.EventHandler(this._Bt_Guardar_Click);
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._Dt_columna_cfecha,
            this._Dt_columna_cpedido,
            this._Dt_columna_ccliente,
            this._Dt_columna_desccliente,
            this._Dt_columna_cproducto,
            this._Dt_columna_descproducto,
            this._Dt_columna_cprecioventamaximo,
            this._Dt_columna_ccajaspedidas,
            this._Dt_columna_cunidadespedidas,
            this._Dt_columna_cprecioventa,
            this._Dt_columna_ccostoneto,
            this._Dt_columna_cmargen,
            this._Dt_columna_cvistonotificador,
            this.clogid});
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(0, 0);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.Size = new System.Drawing.Size(1056, 376);
            this._Dg_Grid.TabIndex = 165;
            this._Dg_Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_CellClick);
            // 
            // _Dt_columna_cfecha
            // 
            this._Dt_columna_cfecha.DataPropertyName = "cfecha";
            this._Dt_columna_cfecha.HeaderText = "Fecha";
            this._Dt_columna_cfecha.Name = "_Dt_columna_cfecha";
            this._Dt_columna_cfecha.ReadOnly = true;
            this._Dt_columna_cfecha.Width = 62;
            // 
            // _Dt_columna_cpedido
            // 
            this._Dt_columna_cpedido.DataPropertyName = "cpedido";
            this._Dt_columna_cpedido.HeaderText = "Pedido";
            this._Dt_columna_cpedido.Name = "_Dt_columna_cpedido";
            this._Dt_columna_cpedido.ReadOnly = true;
            this._Dt_columna_cpedido.Width = 90;
            // 
            // _Dt_columna_ccliente
            // 
            this._Dt_columna_ccliente.DataPropertyName = "ccliente";
            this._Dt_columna_ccliente.HeaderText = "Cód. Cliente";
            this._Dt_columna_ccliente.Name = "_Dt_columna_ccliente";
            this._Dt_columna_ccliente.ReadOnly = true;
            this._Dt_columna_ccliente.Width = 89;
            // 
            // _Dt_columna_desccliente
            // 
            this._Dt_columna_desccliente.DataPropertyName = "desccliente";
            this._Dt_columna_desccliente.HeaderText = "Cliente";
            this._Dt_columna_desccliente.Name = "_Dt_columna_desccliente";
            this._Dt_columna_desccliente.ReadOnly = true;
            this._Dt_columna_desccliente.Width = 64;
            // 
            // _Dt_columna_cproducto
            // 
            this._Dt_columna_cproducto.DataPropertyName = "cproducto";
            this._Dt_columna_cproducto.HeaderText = "Cód. Producto";
            this._Dt_columna_cproducto.Name = "_Dt_columna_cproducto";
            this._Dt_columna_cproducto.ReadOnly = true;
            // 
            // _Dt_columna_descproducto
            // 
            this._Dt_columna_descproducto.DataPropertyName = "descproducto";
            this._Dt_columna_descproducto.HeaderText = "Producto";
            this._Dt_columna_descproducto.Name = "_Dt_columna_descproducto";
            this._Dt_columna_descproducto.ReadOnly = true;
            this._Dt_columna_descproducto.Width = 80;
            // 
            // _Dt_columna_cprecioventamaximo
            // 
            this._Dt_columna_cprecioventamaximo.DataPropertyName = "cprecioventamaximo";
            this._Dt_columna_cprecioventamaximo.HeaderText = "PVJusto";
            this._Dt_columna_cprecioventamaximo.Name = "_Dt_columna_cprecioventamaximo";
            this._Dt_columna_cprecioventamaximo.ReadOnly = true;
            // 
            // _Dt_columna_ccajaspedidas
            // 
            this._Dt_columna_ccajaspedidas.DataPropertyName = "ccajaspedidas";
            this._Dt_columna_ccajaspedidas.HeaderText = "Cajas";
            this._Dt_columna_ccajaspedidas.Name = "_Dt_columna_ccajaspedidas";
            this._Dt_columna_ccajaspedidas.ReadOnly = true;
            this._Dt_columna_ccajaspedidas.Width = 58;
            // 
            // _Dt_columna_cunidadespedidas
            // 
            this._Dt_columna_cunidadespedidas.DataPropertyName = "cunidadespedidas";
            this._Dt_columna_cunidadespedidas.HeaderText = "Unidades";
            this._Dt_columna_cunidadespedidas.Name = "_Dt_columna_cunidadespedidas";
            this._Dt_columna_cunidadespedidas.ReadOnly = true;
            this._Dt_columna_cunidadespedidas.Width = 77;
            // 
            // _Dt_columna_cprecioventa
            // 
            this._Dt_columna_cprecioventa.DataPropertyName = "cprecioventa";
            this._Dt_columna_cprecioventa.HeaderText = "Precio Venta";
            this._Dt_columna_cprecioventa.Name = "_Dt_columna_cprecioventa";
            this._Dt_columna_cprecioventa.ReadOnly = true;
            this._Dt_columna_cprecioventa.Width = 93;
            // 
            // _Dt_columna_ccostoneto
            // 
            this._Dt_columna_ccostoneto.DataPropertyName = "ccostoneto";
            this._Dt_columna_ccostoneto.HeaderText = "Costo Neto";
            this._Dt_columna_ccostoneto.Name = "_Dt_columna_ccostoneto";
            this._Dt_columna_ccostoneto.ReadOnly = true;
            this._Dt_columna_ccostoneto.Width = 85;
            // 
            // _Dt_columna_cmargen
            // 
            this._Dt_columna_cmargen.DataPropertyName = "cmargen";
            this._Dt_columna_cmargen.HeaderText = "Margen";
            this._Dt_columna_cmargen.Name = "_Dt_columna_cmargen";
            this._Dt_columna_cmargen.ReadOnly = true;
            this._Dt_columna_cmargen.Width = 68;
            // 
            // _Dt_columna_cvistonotificador
            // 
            this._Dt_columna_cvistonotificador.DataPropertyName = "cvistonotificador";
            this._Dt_columna_cvistonotificador.HeaderText = "Marcar como Visto";
            this._Dt_columna_cvistonotificador.Name = "_Dt_columna_cvistonotificador";
            this._Dt_columna_cvistonotificador.ReadOnly = true;
            this._Dt_columna_cvistonotificador.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._Dt_columna_cvistonotificador.Width = 101;
            // 
            // clogid
            // 
            this.clogid.DataPropertyName = "clogid";
            this.clogid.HeaderText = "clogid";
            this.clogid.Name = "clogid";
            this.clogid.ReadOnly = true;
            this.clogid.Visible = false;
            // 
            // Frm_ProducExcedMargenGub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 376);
            this.Controls.Add(this._Pnl_Clave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._Dg_Grid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ProducExcedMargenGub";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos que exceden margen gubernamental";
            this.Activated += new System.EventHandler(this.Frm_ProducExcedMargenGub_Activated);
            this.Load += new System.EventHandler(this.Frm_ProducExcedMargenGub_Load);
            this._Pnl_Clave.ResumeLayout(false);
            this._Pnl_Clave.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _Pnl_Clave;
        private System.Windows.Forms.TextBox _Txt_Clave;
        private System.Windows.Forms.Button _Bt_AceptarClave;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button _Bt_CancelarClave;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _Bt_Guardar;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dt_columna_cfecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dt_columna_cpedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dt_columna_ccliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dt_columna_desccliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dt_columna_cproducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dt_columna_descproducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dt_columna_cprecioventamaximo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dt_columna_ccajaspedidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dt_columna_cunidadespedidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dt_columna_cprecioventa;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dt_columna_ccostoneto;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dt_columna_cmargen;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _Dt_columna_cvistonotificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn clogid;
    }
}