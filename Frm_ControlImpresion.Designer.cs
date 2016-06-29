namespace T3
{
    partial class Frm_ControlImpresion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ControlImpresion));
            this.label2 = new System.Windows.Forms.Label();
            this._Pnl_Mensaje = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Bt_ImpriLuego = new System.Windows.Forms.Button();
            this._Bt_ComproISLR = new System.Windows.Forms.Button();
            this._Bt_NR_Devolucion = new System.Windows.Forms.Button();
            this._Bt_ND_Proveedores = new System.Windows.Forms.Button();
            this._Bt_NC_Proveedor = new System.Windows.Forms.Button();
            this._Bt_ND_Cliente = new System.Windows.Forms.Button();
            this._Bt_NC_Cliente = new System.Windows.Forms.Button();
            this._Pnl_Botones = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this._Bt_Comprobantes = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this._Bt_ComproIVA = new System.Windows.Forms.Button();
            this._Pnl_Mensaje.SuspendLayout();
            this.panel1.SuspendLayout();
            this._Pnl_Botones.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(529, 38);
            this.label2.TabIndex = 5;
            this.label2.Text = "Documentos por imprimir !!!";
            // 
            // _Pnl_Mensaje
            // 
            this._Pnl_Mensaje.BackColor = System.Drawing.Color.Khaki;
            this._Pnl_Mensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Mensaje.Controls.Add(this.panel1);
            this._Pnl_Mensaje.Controls.Add(this.label2);
            this._Pnl_Mensaje.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Pnl_Mensaje.Location = new System.Drawing.Point(0, 561);
            this._Pnl_Mensaje.Name = "_Pnl_Mensaje";
            this._Pnl_Mensaje.Size = new System.Drawing.Size(1111, 84);
            this._Pnl_Mensaje.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Bt_ImpriLuego);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(665, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 82);
            this.panel1.TabIndex = 6;
            // 
            // _Bt_ImpriLuego
            // 
            this._Bt_ImpriLuego.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_ImpriLuego.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_ImpriLuego.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_ImpriLuego.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_ImpriLuego.Image")));
            this._Bt_ImpriLuego.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_ImpriLuego.Location = new System.Drawing.Point(3, 5);
            this._Bt_ImpriLuego.Name = "_Bt_ImpriLuego";
            this._Bt_ImpriLuego.Size = new System.Drawing.Size(297, 72);
            this._Bt_ImpriLuego.TabIndex = 18;
            this._Bt_ImpriLuego.Text = "Imprimir luego..";
            this._Bt_ImpriLuego.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_ImpriLuego.UseVisualStyleBackColor = true;
            this._Bt_ImpriLuego.Click += new System.EventHandler(this._Bt_ImpriLuego_Click);
            // 
            // _Bt_ComproISLR
            // 
            this._Bt_ComproISLR.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_ComproISLR.Enabled = false;
            this._Bt_ComproISLR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_ComproISLR.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_ComproISLR.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_ComproISLR.Image")));
            this._Bt_ComproISLR.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this._Bt_ComproISLR.Location = new System.Drawing.Point(300, 276);
            this._Bt_ComproISLR.Name = "_Bt_ComproISLR";
            this._Bt_ComproISLR.Size = new System.Drawing.Size(278, 129);
            this._Bt_ComproISLR.TabIndex = 17;
            this._Bt_ComproISLR.Text = "Ret. ISLR";
            this._Bt_ComproISLR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_ComproISLR.UseVisualStyleBackColor = true;
            this._Bt_ComproISLR.Click += new System.EventHandler(this._Bt_ComproISLR_Click);
            // 
            // _Bt_NR_Devolucion
            // 
            this._Bt_NR_Devolucion.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_NR_Devolucion.Enabled = false;
            this._Bt_NR_Devolucion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_NR_Devolucion.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_NR_Devolucion.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_NR_Devolucion.Image")));
            this._Bt_NR_Devolucion.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this._Bt_NR_Devolucion.Location = new System.Drawing.Point(16, 276);
            this._Bt_NR_Devolucion.Name = "_Bt_NR_Devolucion";
            this._Bt_NR_Devolucion.Size = new System.Drawing.Size(278, 129);
            this._Bt_NR_Devolucion.TabIndex = 15;
            this._Bt_NR_Devolucion.Text = "NR por Devol.";
            this._Bt_NR_Devolucion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_NR_Devolucion.UseVisualStyleBackColor = true;
            this._Bt_NR_Devolucion.Click += new System.EventHandler(this._Bt_NR_Devolucion_Click);
            // 
            // _Bt_ND_Proveedores
            // 
            this._Bt_ND_Proveedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_ND_Proveedores.Enabled = false;
            this._Bt_ND_Proveedores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_ND_Proveedores.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_ND_Proveedores.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_ND_Proveedores.Image")));
            this._Bt_ND_Proveedores.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this._Bt_ND_Proveedores.Location = new System.Drawing.Point(300, 141);
            this._Bt_ND_Proveedores.Name = "_Bt_ND_Proveedores";
            this._Bt_ND_Proveedores.Size = new System.Drawing.Size(278, 129);
            this._Bt_ND_Proveedores.TabIndex = 14;
            this._Bt_ND_Proveedores.Text = "ND Proveedores";
            this._Bt_ND_Proveedores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_ND_Proveedores.UseVisualStyleBackColor = true;
            this._Bt_ND_Proveedores.Click += new System.EventHandler(this._Bt_ND_Proveedores_Click);
            // 
            // _Bt_NC_Proveedor
            // 
            this._Bt_NC_Proveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_NC_Proveedor.Enabled = false;
            this._Bt_NC_Proveedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_NC_Proveedor.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_NC_Proveedor.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_NC_Proveedor.Image")));
            this._Bt_NC_Proveedor.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this._Bt_NC_Proveedor.Location = new System.Drawing.Point(300, 6);
            this._Bt_NC_Proveedor.Name = "_Bt_NC_Proveedor";
            this._Bt_NC_Proveedor.Size = new System.Drawing.Size(278, 129);
            this._Bt_NC_Proveedor.TabIndex = 13;
            this._Bt_NC_Proveedor.Text = "NC Proveedores";
            this._Bt_NC_Proveedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_NC_Proveedor.UseVisualStyleBackColor = true;
            this._Bt_NC_Proveedor.Click += new System.EventHandler(this._Bt_NC_Proveedor_Click);
            // 
            // _Bt_ND_Cliente
            // 
            this._Bt_ND_Cliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_ND_Cliente.Enabled = false;
            this._Bt_ND_Cliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_ND_Cliente.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_ND_Cliente.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_ND_Cliente.Image")));
            this._Bt_ND_Cliente.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this._Bt_ND_Cliente.Location = new System.Drawing.Point(16, 141);
            this._Bt_ND_Cliente.Name = "_Bt_ND_Cliente";
            this._Bt_ND_Cliente.Size = new System.Drawing.Size(278, 129);
            this._Bt_ND_Cliente.TabIndex = 12;
            this._Bt_ND_Cliente.Text = "ND Clientes";
            this._Bt_ND_Cliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_ND_Cliente.UseVisualStyleBackColor = true;
            this._Bt_ND_Cliente.Click += new System.EventHandler(this._Bt_ND_Cliente_Click);
            // 
            // _Bt_NC_Cliente
            // 
            this._Bt_NC_Cliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_NC_Cliente.Enabled = false;
            this._Bt_NC_Cliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_NC_Cliente.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_NC_Cliente.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_NC_Cliente.Image")));
            this._Bt_NC_Cliente.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this._Bt_NC_Cliente.Location = new System.Drawing.Point(16, 6);
            this._Bt_NC_Cliente.Name = "_Bt_NC_Cliente";
            this._Bt_NC_Cliente.Size = new System.Drawing.Size(278, 129);
            this._Bt_NC_Cliente.TabIndex = 0;
            this._Bt_NC_Cliente.Text = "NC Clientes";
            this._Bt_NC_Cliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_NC_Cliente.UseVisualStyleBackColor = true;
            this._Bt_NC_Cliente.Click += new System.EventHandler(this._Bt_NC_Cliente_Click);
            // 
            // _Pnl_Botones
            // 
            this._Pnl_Botones.Controls.Add(this.panel4);
            this._Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Top;
            this._Pnl_Botones.Location = new System.Drawing.Point(0, 0);
            this._Pnl_Botones.Name = "_Pnl_Botones";
            this._Pnl_Botones.Size = new System.Drawing.Size(1111, 190);
            this._Pnl_Botones.TabIndex = 19;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 190);
            this.panel4.TabIndex = 20;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 178);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._Bt_ComproIVA);
            this.panel2.Controls.Add(this._Bt_Comprobantes);
            this.panel2.Controls.Add(this._Bt_NC_Cliente);
            this.panel2.Controls.Add(this._Bt_NR_Devolucion);
            this.panel2.Controls.Add(this._Bt_ND_Cliente);
            this.panel2.Controls.Add(this._Bt_ND_Proveedores);
            this.panel2.Controls.Add(this._Bt_NC_Proveedor);
            this.panel2.Controls.Add(this._Bt_ComproISLR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(242, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(869, 371);
            this.panel2.TabIndex = 20;
            // 
            // _Bt_Comprobantes
            // 
            this._Bt_Comprobantes.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Comprobantes.Enabled = false;
            this._Bt_Comprobantes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Comprobantes.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Comprobantes.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Comprobantes.Image")));
            this._Bt_Comprobantes.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this._Bt_Comprobantes.Location = new System.Drawing.Point(584, 141);
            this._Bt_Comprobantes.Name = "_Bt_Comprobantes";
            this._Bt_Comprobantes.Size = new System.Drawing.Size(278, 129);
            this._Bt_Comprobantes.TabIndex = 18;
            this._Bt_Comprobantes.Text = "Comprobantes";
            this._Bt_Comprobantes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Comprobantes.UseVisualStyleBackColor = true;
            this._Bt_Comprobantes.Click += new System.EventHandler(this._Bt_Comprobantes_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 190);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(242, 371);
            this.panel3.TabIndex = 21;
            // 
            // _Bt_ComproIVA
            // 
            this._Bt_ComproIVA.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_ComproIVA.Enabled = false;
            this._Bt_ComproIVA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_ComproIVA.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_ComproIVA.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_ComproIVA.Image")));
            this._Bt_ComproIVA.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this._Bt_ComproIVA.Location = new System.Drawing.Point(588, 6);
            this._Bt_ComproIVA.Name = "_Bt_ComproIVA";
            this._Bt_ComproIVA.Size = new System.Drawing.Size(278, 129);
            this._Bt_ComproIVA.TabIndex = 19;
            this._Bt_ComproIVA.Text = "Ret. IVA";
            this._Bt_ComproIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_ComproIVA.UseVisualStyleBackColor = true;
            this._Bt_ComproIVA.Click += new System.EventHandler(this._Bt_ComproIVA_Click);
            // 
            // Frm_ControlImpresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 645);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this._Pnl_Mensaje);
            this.Controls.Add(this._Pnl_Botones);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ControlImpresion";
            this.Opacity = 0.95D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de impresión";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Frm_ControlImpresion_Load);
            this._Pnl_Mensaje.ResumeLayout(false);
            this._Pnl_Mensaje.PerformLayout();
            this.panel1.ResumeLayout(false);
            this._Pnl_Botones.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _Bt_NC_Cliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel _Pnl_Mensaje;
        private System.Windows.Forms.Button _Bt_ND_Cliente;
        private System.Windows.Forms.Button _Bt_NC_Proveedor;
        private System.Windows.Forms.Button _Bt_ND_Proveedores;
        private System.Windows.Forms.Button _Bt_NR_Devolucion;
        private System.Windows.Forms.Button _Bt_ComproISLR;
        private System.Windows.Forms.Button _Bt_ImpriLuego;
        private System.Windows.Forms.Panel _Pnl_Botones;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button _Bt_Comprobantes;
        private System.Windows.Forms.Button _Bt_ComproIVA;

    }
}