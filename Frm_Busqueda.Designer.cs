namespace T3
{
    partial class Frm_Busqueda
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Busqueda));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this._Tst_barra_mdi = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.clavePrincipalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descripciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this._Bt_actualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.servisioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materiaPrimaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._Dg_Datagrid = new System.Windows.Forms.DataGridView();
            this._Lb_Etiquea = new System.Windows.Forms.Label();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this._Ctrl_Contex1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._Ctrl_Contex1_MItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._Ctrl_Contex2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._Tst_barra_mdi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Datagrid)).BeginInit();
            this._Ctrl_Contex1.SuspendLayout();
            this._Ctrl_Contex2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Tst_barra_mdi
            // 
            this._Tst_barra_mdi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSplitButton1,
            this.toolStripComboBox1,
            this._Bt_actualizar,
            this.toolStripLabel2,
            this.toolStripSplitButton2});
            this._Tst_barra_mdi.Location = new System.Drawing.Point(0, 0);
            this._Tst_barra_mdi.Name = "_Tst_barra_mdi";
            this._Tst_barra_mdi.Size = new System.Drawing.Size(586, 25);
            this._Tst_barra_mdi.TabIndex = 6;
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
            this.clavePrincipalToolStripMenuItem.Click += new System.EventHandler(this.clavePrincipalToolStripMenuItem_Click);
            // 
            // descripciónToolStripMenuItem
            // 
            this.descripciónToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("descripciónToolStripMenuItem.Image")));
            this.descripciónToolStripMenuItem.Name = "descripciónToolStripMenuItem";
            this.descripciónToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.descripciónToolStripMenuItem.Text = "Descripción";
            this.descripciónToolStripMenuItem.Click += new System.EventHandler(this.descripciónToolStripMenuItem_Click);
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
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.servisioToolStripMenuItem,
            this.materiaPrimaToolStripMenuItem,
            this.otrosToolStripMenuItem});
            this.toolStripSplitButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton2.Image")));
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton2.Text = "toolStripSplitButton2";
            // 
            // servisioToolStripMenuItem
            // 
            this.servisioToolStripMenuItem.Name = "servisioToolStripMenuItem";
            this.servisioToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.servisioToolStripMenuItem.Text = "Servicio";
            this.servisioToolStripMenuItem.Click += new System.EventHandler(this.servisioToolStripMenuItem_Click);
            // 
            // materiaPrimaToolStripMenuItem
            // 
            this.materiaPrimaToolStripMenuItem.Name = "materiaPrimaToolStripMenuItem";
            this.materiaPrimaToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.materiaPrimaToolStripMenuItem.Text = "Materia Prima";
            this.materiaPrimaToolStripMenuItem.Click += new System.EventHandler(this.materiaPrimaToolStripMenuItem_Click);
            // 
            // otrosToolStripMenuItem
            // 
            this.otrosToolStripMenuItem.Name = "otrosToolStripMenuItem";
            this.otrosToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.otrosToolStripMenuItem.Text = "Otros";
            this.otrosToolStripMenuItem.Click += new System.EventHandler(this.otrosToolStripMenuItem_Click);
            // 
            // _Dg_Datagrid
            // 
            this._Dg_Datagrid.AllowUserToAddRows = false;
            this._Dg_Datagrid.AllowUserToDeleteRows = false;
            this._Dg_Datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._Dg_Datagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._Dg_Datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Datagrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Datagrid.Location = new System.Drawing.Point(0, 48);
            this._Dg_Datagrid.Name = "_Dg_Datagrid";
            this._Dg_Datagrid.ReadOnly = true;
            this._Dg_Datagrid.Size = new System.Drawing.Size(586, 253);
            this._Dg_Datagrid.TabIndex = 7;
            this._Dg_Datagrid.DoubleClick += new System.EventHandler(this._Dg_Datagrid_DoubleClick);
            this._Dg_Datagrid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Datagrid_CellMouseEnter);
            this._Dg_Datagrid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Datagrid_RowHeaderMouseDoubleClick);
            this._Dg_Datagrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Datagrid_CellContentClick);
            // 
            // _Lb_Etiquea
            // 
            this._Lb_Etiquea.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._Lb_Etiquea.Dock = System.Windows.Forms.DockStyle.Top;
            this._Lb_Etiquea.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._Lb_Etiquea.Location = new System.Drawing.Point(0, 25);
            this._Lb_Etiquea.Name = "_Lb_Etiquea";
            this._Lb_Etiquea.Size = new System.Drawing.Size(586, 23);
            this._Lb_Etiquea.TabIndex = 8;
            this._Lb_Etiquea.Text = "Texto";
            this._Lb_Etiquea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(0, 301);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(586, 12);
            this._Lbl_DgInfo.TabIndex = 9;
            this._Lbl_DgInfo.Text = "Use doble click";
            this._Lbl_DgInfo.Visible = false;
            // 
            // _Ctrl_Contex1
            // 
            this._Ctrl_Contex1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._Ctrl_Contex1_MItem1});
            this._Ctrl_Contex1.Name = "_Ctrl_Contex";
            this._Ctrl_Contex1.Size = new System.Drawing.Size(125, 26);
            // 
            // _Ctrl_Contex1_MItem1
            // 
            this._Ctrl_Contex1_MItem1.Name = "_Ctrl_Contex1_MItem1";
            this._Ctrl_Contex1_MItem1.Size = new System.Drawing.Size(124, 22);
            this._Ctrl_Contex1_MItem1.Text = "Enviar a";
            this._Ctrl_Contex1_MItem1.Click += new System.EventHandler(this._Ctrl_Contex1_MItem1_Click);
            // 
            // _Ctrl_Contex2
            // 
            this._Ctrl_Contex2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this._Ctrl_Contex2.Name = "_Ctrl_Contex";
            this._Ctrl_Contex2.Size = new System.Drawing.Size(139, 26);
            this._Ctrl_Contex2.Opening += new System.ComponentModel.CancelEventHandler(this._Ctrl_Contex2_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuItem1.Text = "Cerrar O.C";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Frm_Busqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 313);
            this.Controls.Add(this._Dg_Datagrid);
            this.Controls.Add(this._Lbl_DgInfo);
            this.Controls.Add(this._Lb_Etiquea);
            this.Controls.Add(this._Tst_barra_mdi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Busqueda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda";
            this.Load += new System.EventHandler(this.Frm_Busqueda_Load);
            this.Activated += new System.EventHandler(this.Frm_Busqueda_Activated);
            this._Tst_barra_mdi.ResumeLayout(false);
            this._Tst_barra_mdi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Datagrid)).EndInit();
            this._Ctrl_Contex1.ResumeLayout(false);
            this._Ctrl_Contex2.ResumeLayout(false);
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
        private System.Windows.Forms.Label _Lb_Etiquea;
        private System.Windows.Forms.ToolStripButton _Bt_actualizar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem servisioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materiaPrimaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otrosToolStripMenuItem;
        public System.Windows.Forms.DataGridView _Dg_Datagrid;
        private System.Windows.Forms.Label _Lbl_DgInfo;
        private System.Windows.Forms.ContextMenuStrip _Ctrl_Contex1;
        private System.Windows.Forms.ToolStripMenuItem _Ctrl_Contex1_MItem1;
        private System.Windows.Forms.ContextMenuStrip _Ctrl_Contex2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;

    }
}