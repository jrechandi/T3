namespace T3
{
    partial class _Ctrl_Tabs
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_Ctrl_Tabs));
            this._Lnk_Descripcion = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _Lnk_Descripcion
            // 
            this._Lnk_Descripcion.BackColor = System.Drawing.Color.Transparent;
            this._Lnk_Descripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Lnk_Descripcion.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lnk_Descripcion.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this._Lnk_Descripcion.LinkColor = System.Drawing.Color.Black;
            this._Lnk_Descripcion.Location = new System.Drawing.Point(23, 0);
            this._Lnk_Descripcion.Name = "_Lnk_Descripcion";
            this._Lnk_Descripcion.Size = new System.Drawing.Size(185, 17);
            this._Lnk_Descripcion.TabIndex = 0;
            this._Lnk_Descripcion.TabStop = true;
            this._Lnk_Descripcion.Text = "linkLabel1";
            this._Lnk_Descripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Lnk_Descripcion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._Lnk_Descripcion_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 17);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 14);
            this.panel1.TabIndex = 1;
            // 
            // _Ctrl_Tabs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this._Lnk_Descripcion);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "_Ctrl_Tabs";
            this.Size = new System.Drawing.Size(208, 31);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel _Lnk_Descripcion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;


    }
}
