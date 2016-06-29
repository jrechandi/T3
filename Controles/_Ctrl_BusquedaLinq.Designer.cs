namespace T3.Controles
{
    partial class _Ctrl_BusquedaLinq
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_Ctrl_BusquedaLinq));
            this.panel1 = new System.Windows.Forms.Panel();
            this._Lb_De = new System.Windows.Forms.Label();
            this._Bt_Next = new System.Windows.Forms.Button();
            this._Bt_Antes = new System.Windows.Forms.Button();
            this._Tst_barra_mdi = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this._Tool_Items = new System.Windows.Forms.ToolStripSplitButton();
            this._Tool_Texto = new System.Windows.Forms.ToolStripComboBox();
            this._Bt_actualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.panel1.SuspendLayout();
            this._Tst_barra_mdi.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Lb_De);
            this.panel1.Controls.Add(this._Bt_Next);
            this.panel1.Controls.Add(this._Bt_Antes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 20);
            this.panel1.TabIndex = 22;
            // 
            // _Lb_De
            // 
            this._Lb_De.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._Lb_De.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Lb_De.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._Lb_De.Location = new System.Drawing.Point(48, 0);
            this._Lb_De.Name = "_Lb_De";
            this._Lb_De.Size = new System.Drawing.Size(378, 20);
            this._Lb_De.TabIndex = 20;
            this._Lb_De.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _Bt_Next
            // 
            this._Bt_Next.BackColor = System.Drawing.SystemColors.Control;
            this._Bt_Next.Dock = System.Windows.Forms.DockStyle.Left;
            this._Bt_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Next.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Next.Image")));
            this._Bt_Next.Location = new System.Drawing.Point(24, 0);
            this._Bt_Next.Name = "_Bt_Next";
            this._Bt_Next.Size = new System.Drawing.Size(24, 20);
            this._Bt_Next.TabIndex = 3;
            this._Bt_Next.UseVisualStyleBackColor = false;
            this._Bt_Next.Visible = false;
            this._Bt_Next.Click += new System.EventHandler(this._Bt_Next_Click);
            // 
            // _Bt_Antes
            // 
            this._Bt_Antes.BackColor = System.Drawing.SystemColors.Control;
            this._Bt_Antes.Dock = System.Windows.Forms.DockStyle.Left;
            this._Bt_Antes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Antes.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Antes.Image")));
            this._Bt_Antes.Location = new System.Drawing.Point(0, 0);
            this._Bt_Antes.Name = "_Bt_Antes";
            this._Bt_Antes.Size = new System.Drawing.Size(24, 20);
            this._Bt_Antes.TabIndex = 2;
            this._Bt_Antes.UseVisualStyleBackColor = false;
            this._Bt_Antes.Visible = false;
            this._Bt_Antes.Click += new System.EventHandler(this._Bt_Antes_Click);
            // 
            // _Tst_barra_mdi
            // 
            this._Tst_barra_mdi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this._Tool_Items,
            this._Tool_Texto,
            this._Bt_actualizar,
            this.toolStripLabel2});
            this._Tst_barra_mdi.Location = new System.Drawing.Point(0, 0);
            this._Tst_barra_mdi.Name = "_Tst_barra_mdi";
            this._Tst_barra_mdi.Size = new System.Drawing.Size(426, 25);
            this._Tst_barra_mdi.TabIndex = 21;
            this._Tst_barra_mdi.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 22);
            // 
            // _Tool_Items
            // 
            this._Tool_Items.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._Tool_Items.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._Tool_Items.Image = ((System.Drawing.Image)(resources.GetObject("_Tool_Items.Image")));
            this._Tool_Items.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._Tool_Items.Name = "_Tool_Items";
            this._Tool_Items.Size = new System.Drawing.Size(32, 22);
            this._Tool_Items.Text = "toolStripSplitButton1";
            this._Tool_Items.ToolTipText = "Buscar";
            // 
            // _Tool_Texto
            // 
            this._Tool_Texto.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._Tool_Texto.Name = "_Tool_Texto";
            this._Tool_Texto.Size = new System.Drawing.Size(210, 25);
            this._Tool_Texto.TextChanged += new System.EventHandler(this._Tool_Texto_TextChanged);
            // 
            // _Bt_actualizar
            // 
            this._Bt_actualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._Bt_actualizar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_actualizar.Image")));
            this._Bt_actualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._Bt_actualizar.Name = "_Bt_actualizar";
            this._Bt_actualizar.Size = new System.Drawing.Size(23, 22);
            this._Bt_actualizar.Text = "Actualizar";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel2.Text = "Texto:";
            // 
            // _Ctrl_BusquedaLinq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._Tst_barra_mdi);
            this.Name = "_Ctrl_BusquedaLinq";
            this.Size = new System.Drawing.Size(426, 45);
            this.panel1.ResumeLayout(false);
            this._Tst_barra_mdi.ResumeLayout(false);
            this._Tst_barra_mdi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _Lb_De;
        private System.Windows.Forms.Button _Bt_Next;
        private System.Windows.Forms.Button _Bt_Antes;
        public System.Windows.Forms.ToolStrip _Tst_barra_mdi;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton _Bt_actualizar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        public System.Windows.Forms.ToolStripSplitButton _Tool_Items;
        public System.Windows.Forms.ToolStripComboBox _Tool_Texto;
    }
}
