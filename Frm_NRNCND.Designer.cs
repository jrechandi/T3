namespace T3
{
    partial class Frm_NRNCND
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_NRNCND));
            this._Tst_barra_mdi = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.clavePrincipalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descripciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this._Bt_actualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this._Lb_Etiquea = new System.Windows.Forms.Label();
            this._Dg_Datagrid = new System.Windows.Forms.DataGridView();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this._Tst_barra_mdi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // _Tst_barra_mdi
            // 
            this._Tst_barra_mdi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSplitButton1,
            this.toolStripComboBox1,
            this._Bt_actualizar,
            this.toolStripLabel2});
            this._Tst_barra_mdi.Location = new System.Drawing.Point(0, 0);
            this._Tst_barra_mdi.Name = "_Tst_barra_mdi";
            this._Tst_barra_mdi.Size = new System.Drawing.Size(541, 25);
            this._Tst_barra_mdi.TabIndex = 7;
            this._Tst_barra_mdi.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clavePrincipalToolStripMenuItem,
            this.descripciónToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            this.toolStripSplitButton1.ToolTipText = "Buscar";
            // 
            // clavePrincipalToolStripMenuItem
            // 
            this.clavePrincipalToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clavePrincipalToolStripMenuItem.Image")));
            this.clavePrincipalToolStripMenuItem.Name = "clavePrincipalToolStripMenuItem";
            this.clavePrincipalToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.clavePrincipalToolStripMenuItem.Text = "Clave principal";
            // 
            // descripciónToolStripMenuItem
            // 
            this.descripciónToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("descripciónToolStripMenuItem.Image")));
            this.descripciónToolStripMenuItem.Name = "descripciónToolStripMenuItem";
            this.descripciónToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.descripciónToolStripMenuItem.Text = "Descripción";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(210, 25);
            this.toolStripComboBox1.TextChanged += new System.EventHandler(this.toolStripComboBox1_TextChanged);
            // 
            // _Bt_actualizar
            // 
            this._Bt_actualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._Bt_actualizar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_actualizar.Image")));
            this._Bt_actualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._Bt_actualizar.Name = "_Bt_actualizar";
            this._Bt_actualizar.Size = new System.Drawing.Size(23, 22);
            this._Bt_actualizar.Text = "Actualizar";
            this._Bt_actualizar.Click += new System.EventHandler(this._Bt_actualizar_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel2.Text = "Texto:";
            // 
            // _Lb_Etiquea
            // 
            this._Lb_Etiquea.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._Lb_Etiquea.Dock = System.Windows.Forms.DockStyle.Top;
            this._Lb_Etiquea.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._Lb_Etiquea.Location = new System.Drawing.Point(0, 25);
            this._Lb_Etiquea.Name = "_Lb_Etiquea";
            this._Lb_Etiquea.Size = new System.Drawing.Size(541, 23);
            this._Lb_Etiquea.TabIndex = 9;
            this._Lb_Etiquea.Text = "Texto";
            this._Lb_Etiquea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Dg_Datagrid
            // 
            this._Dg_Datagrid.AllowUserToAddRows = false;
            this._Dg_Datagrid.AllowUserToDeleteRows = false;
            this._Dg_Datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._Dg_Datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Datagrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Datagrid.Location = new System.Drawing.Point(0, 48);
            this._Dg_Datagrid.Name = "_Dg_Datagrid";
            this._Dg_Datagrid.ReadOnly = true;
            this._Dg_Datagrid.Size = new System.Drawing.Size(541, 242);
            this._Dg_Datagrid.TabIndex = 10;
            this._Dg_Datagrid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Datagrid_CellMouseEnter);
            this._Dg_Datagrid.DoubleClick += new System.EventHandler(this._Dg_Datagrid_DoubleClick);
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(0, 290);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(541, 12);
            this._Lbl_DgInfo.TabIndex = 11;
            this._Lbl_DgInfo.Text = "Use doble click";
            this._Lbl_DgInfo.Visible = false;
            // 
            // Frm_NRNCND
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 302);
            this.Controls.Add(this._Dg_Datagrid);
            this.Controls.Add(this._Lbl_DgInfo);
            this.Controls.Add(this._Lb_Etiquea);
            this.Controls.Add(this._Tst_barra_mdi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_NRNCND";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda";
            this.Activated += new System.EventHandler(this.Frm_NRNCND_Activated);
            this.Load += new System.EventHandler(this.Frm_NRNCND_Load);
            this._Tst_barra_mdi.ResumeLayout(false);
            this._Tst_barra_mdi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Datagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip _Tst_barra_mdi;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem clavePrincipalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descripciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripButton _Bt_actualizar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.Label _Lb_Etiquea;
        private System.Windows.Forms.DataGridView _Dg_Datagrid;
        private System.Windows.Forms.Label _Lbl_DgInfo;
    }
}