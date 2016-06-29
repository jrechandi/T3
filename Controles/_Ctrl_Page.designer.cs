namespace T3.Controles
{
    partial class _Ctrl_Page
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_Ctrl_Page));
            this._Pnl_PageMain = new System.Windows.Forms.Panel();
            this._Pnl_Mensaje = new System.Windows.Forms.Panel();
            this._Lbl_de = new System.Windows.Forms.Label();
            this._Txt_Page = new System.Windows.Forms.TextBox();
            this._Pnl_Page = new System.Windows.Forms.Panel();
            this._Btn_Next = new System.Windows.Forms.Button();
            this._ImgLst_A = new System.Windows.Forms.ImageList(this.components);
            this._Btn_Antes = new System.Windows.Forms.Button();
            this._Pnl_PageMain.SuspendLayout();
            this._Pnl_Mensaje.SuspendLayout();
            this._Pnl_Page.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Pnl_PageMain
            // 
            this._Pnl_PageMain.Controls.Add(this._Pnl_Mensaje);
            this._Pnl_PageMain.Controls.Add(this._Pnl_Page);
            this._Pnl_PageMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Pnl_PageMain.Location = new System.Drawing.Point(0, 1);
            this._Pnl_PageMain.Name = "_Pnl_PageMain";
            this._Pnl_PageMain.Size = new System.Drawing.Size(364, 20);
            this._Pnl_PageMain.TabIndex = 14;
            // 
            // _Pnl_Mensaje
            // 
            this._Pnl_Mensaje.Controls.Add(this._Lbl_de);
            this._Pnl_Mensaje.Controls.Add(this._Txt_Page);
            this._Pnl_Mensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Pnl_Mensaje.Location = new System.Drawing.Point(48, 0);
            this._Pnl_Mensaje.Name = "_Pnl_Mensaje";
            this._Pnl_Mensaje.Size = new System.Drawing.Size(316, 20);
            this._Pnl_Mensaje.TabIndex = 12;
            // 
            // _Lbl_de
            // 
            this._Lbl_de.BackColor = System.Drawing.Color.White;
            this._Lbl_de.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Lbl_de.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Lbl_de.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_de.Location = new System.Drawing.Point(36, 0);
            this._Lbl_de.Name = "_Lbl_de";
            this._Lbl_de.Size = new System.Drawing.Size(280, 20);
            this._Lbl_de.TabIndex = 14;
            this._Lbl_de.Text = "de";
            this._Lbl_de.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _Txt_Page
            // 
            this._Txt_Page.BackColor = System.Drawing.Color.White;
            this._Txt_Page.Dock = System.Windows.Forms.DockStyle.Left;
            this._Txt_Page.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Page.Location = new System.Drawing.Point(0, 0);
            this._Txt_Page.Name = "_Txt_Page";
            this._Txt_Page.Size = new System.Drawing.Size(36, 20);
            this._Txt_Page.TabIndex = 12;
            this._Txt_Page.Tag = "";
            this._Txt_Page.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._Txt_Page.TextChanged += new System.EventHandler(this._Txt_Page_TextChanged);
            this._Txt_Page.Leave += new System.EventHandler(this._Txt_Page_Leave);
            this._Txt_Page.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Page_KeyPress);
            // 
            // _Pnl_Page
            // 
            this._Pnl_Page.BackColor = System.Drawing.Color.White;
            this._Pnl_Page.Controls.Add(this._Btn_Next);
            this._Pnl_Page.Controls.Add(this._Btn_Antes);
            this._Pnl_Page.Dock = System.Windows.Forms.DockStyle.Left;
            this._Pnl_Page.Location = new System.Drawing.Point(0, 0);
            this._Pnl_Page.Name = "_Pnl_Page";
            this._Pnl_Page.Size = new System.Drawing.Size(48, 20);
            this._Pnl_Page.TabIndex = 11;
            // 
            // _Btn_Next
            // 
            this._Btn_Next.BackColor = System.Drawing.SystemColors.Control;
            this._Btn_Next.Dock = System.Windows.Forms.DockStyle.Left;
            this._Btn_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Btn_Next.Image = ((System.Drawing.Image)(resources.GetObject("_Btn_Next.Image")));
            this._Btn_Next.Location = new System.Drawing.Point(24, 0);
            this._Btn_Next.Name = "_Btn_Next";
            this._Btn_Next.Size = new System.Drawing.Size(24, 20);
            this._Btn_Next.TabIndex = 1;
            this._Btn_Next.UseVisualStyleBackColor = false;
            this._Btn_Next.Click += new System.EventHandler(this._Btn_Next_Click);
            // 
            // _ImgLst_A
            // 
            this._ImgLst_A.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_ImgLst_A.ImageStream")));
            this._ImgLst_A.TransparentColor = System.Drawing.Color.Transparent;
            this._ImgLst_A.Images.SetKeyName(0, "");
            this._ImgLst_A.Images.SetKeyName(1, "");
            this._ImgLst_A.Images.SetKeyName(2, "");
            this._ImgLst_A.Images.SetKeyName(3, "");
            this._ImgLst_A.Images.SetKeyName(4, "flecha_der.ICO");
            this._ImgLst_A.Images.SetKeyName(5, "flecha_izq.ICO");
            // 
            // _Btn_Antes
            // 
            this._Btn_Antes.BackColor = System.Drawing.SystemColors.Control;
            this._Btn_Antes.Dock = System.Windows.Forms.DockStyle.Left;
            this._Btn_Antes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Btn_Antes.Image = ((System.Drawing.Image)(resources.GetObject("_Btn_Antes.Image")));
            this._Btn_Antes.Location = new System.Drawing.Point(0, 0);
            this._Btn_Antes.Name = "_Btn_Antes";
            this._Btn_Antes.Size = new System.Drawing.Size(24, 20);
            this._Btn_Antes.TabIndex = 0;
            this._Btn_Antes.UseVisualStyleBackColor = false;
            this._Btn_Antes.Click += new System.EventHandler(this._Btn_Antes_Click);
            // 
            // _Ctrl_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._Pnl_PageMain);
            this.Name = "_Ctrl_Page";
            this.Size = new System.Drawing.Size(364, 21);
            this.Load += new System.EventHandler(this._Ctrl_Page_Load);
            this.SizeChanged += new System.EventHandler(this._Ctrl_Page_SizeChanged);
            this._Pnl_PageMain.ResumeLayout(false);
            this._Pnl_Mensaje.ResumeLayout(false);
            this._Pnl_Mensaje.PerformLayout();
            this._Pnl_Page.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _Pnl_PageMain;
        private System.Windows.Forms.Panel _Pnl_Mensaje;
        private System.Windows.Forms.Label _Lbl_de;
        private System.Windows.Forms.TextBox _Txt_Page;
        private System.Windows.Forms.Panel _Pnl_Page;
        private System.Windows.Forms.Button _Btn_Next;
        private System.Windows.Forms.Button _Btn_Antes;
        private System.Windows.Forms.ImageList _ImgLst_A;
    }
}
