namespace T3
{
    partial class Frm_RC_CobrosContraCamion
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
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this._Tb_Tab_Guia = new System.Windows.Forms.TabPage();
            this._Layout_Guia = new System.Windows.Forms.TableLayoutPanel();
            this._Lbl_DgInfo_Guia = new System.Windows.Forms.Label();
            this._Pnl_Grid_Guia = new System.Windows.Forms.Panel();
            this._Dg_Grid_Guia = new System.Windows.Forms.DataGridView();
            this._Tb_Tab_Clientes = new System.Windows.Forms.TabPage();
            this._Layout_Clientes = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this._Dg_Grid_Clientes = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this._Btn_MarcarGuiaCobrada = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this._Lbl_DgInfo_Clientes = new System.Windows.Forms.Label();
            this._Tb_Tab.SuspendLayout();
            this._Tb_Tab_Guia.SuspendLayout();
            this._Layout_Guia.SuspendLayout();
            this._Pnl_Grid_Guia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_Guia)).BeginInit();
            this._Tb_Tab_Clientes.SuspendLayout();
            this._Layout_Clientes.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_Clientes)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Tb_Tab
            // 
            this._Tb_Tab.Controls.Add(this._Tb_Tab_Guia);
            this._Tb_Tab.Controls.Add(this._Tb_Tab_Clientes);
            this._Tb_Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Tb_Tab.Location = new System.Drawing.Point(0, 0);
            this._Tb_Tab.Name = "_Tb_Tab";
            this._Tb_Tab.SelectedIndex = 0;
            this._Tb_Tab.Size = new System.Drawing.Size(772, 354);
            this._Tb_Tab.TabIndex = 0;
            this._Tb_Tab.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this._Tb_Tab_Selecting);
            // 
            // _Tb_Tab_Guia
            // 
            this._Tb_Tab_Guia.Controls.Add(this._Layout_Guia);
            this._Tb_Tab_Guia.Location = new System.Drawing.Point(4, 21);
            this._Tb_Tab_Guia.Name = "_Tb_Tab_Guia";
            this._Tb_Tab_Guia.Padding = new System.Windows.Forms.Padding(3);
            this._Tb_Tab_Guia.Size = new System.Drawing.Size(764, 329);
            this._Tb_Tab_Guia.TabIndex = 0;
            this._Tb_Tab_Guia.Text = "Guía";
            this._Tb_Tab_Guia.UseVisualStyleBackColor = true;
            // 
            // _Layout_Guia
            // 
            this._Layout_Guia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._Layout_Guia.ColumnCount = 1;
            this._Layout_Guia.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._Layout_Guia.Controls.Add(this._Lbl_DgInfo_Guia, 0, 1);
            this._Layout_Guia.Controls.Add(this._Pnl_Grid_Guia, 0, 0);
            this._Layout_Guia.Location = new System.Drawing.Point(3, 3);
            this._Layout_Guia.Name = "_Layout_Guia";
            this._Layout_Guia.RowCount = 2;
            this._Layout_Guia.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._Layout_Guia.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this._Layout_Guia.Size = new System.Drawing.Size(758, 325);
            this._Layout_Guia.TabIndex = 0;
            // 
            // _Lbl_DgInfo_Guia
            // 
            this._Lbl_DgInfo_Guia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo_Guia.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Lbl_DgInfo_Guia.Location = new System.Drawing.Point(3, 308);
            this._Lbl_DgInfo_Guia.Name = "_Lbl_DgInfo_Guia";
            this._Lbl_DgInfo_Guia.Size = new System.Drawing.Size(752, 17);
            this._Lbl_DgInfo_Guia.TabIndex = 138;
            this._Lbl_DgInfo_Guia.Text = "Use doble click";
            // 
            // _Pnl_Grid_Guia
            // 
            this._Pnl_Grid_Guia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._Pnl_Grid_Guia.Controls.Add(this._Dg_Grid_Guia);
            this._Pnl_Grid_Guia.Location = new System.Drawing.Point(3, 3);
            this._Pnl_Grid_Guia.Name = "_Pnl_Grid_Guia";
            this._Pnl_Grid_Guia.Size = new System.Drawing.Size(752, 302);
            this._Pnl_Grid_Guia.TabIndex = 0;
            // 
            // _Dg_Grid_Guia
            // 
            this._Dg_Grid_Guia.AllowUserToAddRows = false;
            this._Dg_Grid_Guia.AllowUserToDeleteRows = false;
            this._Dg_Grid_Guia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._Dg_Grid_Guia.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this._Dg_Grid_Guia.Location = new System.Drawing.Point(0, 0);
            this._Dg_Grid_Guia.MultiSelect = false;
            this._Dg_Grid_Guia.Name = "_Dg_Grid_Guia";
            this._Dg_Grid_Guia.ReadOnly = true;
            this._Dg_Grid_Guia.Size = new System.Drawing.Size(752, 302);
            this._Dg_Grid_Guia.TabIndex = 136;
            this._Dg_Grid_Guia.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_Guia_RowHeaderMouseDoubleClick);
            // 
            // _Tb_Tab_Clientes
            // 
            this._Tb_Tab_Clientes.Controls.Add(this._Layout_Clientes);
            this._Tb_Tab_Clientes.Location = new System.Drawing.Point(4, 21);
            this._Tb_Tab_Clientes.Name = "_Tb_Tab_Clientes";
            this._Tb_Tab_Clientes.Padding = new System.Windows.Forms.Padding(3);
            this._Tb_Tab_Clientes.Size = new System.Drawing.Size(764, 329);
            this._Tb_Tab_Clientes.TabIndex = 1;
            this._Tb_Tab_Clientes.Text = "Clientes";
            this._Tb_Tab_Clientes.UseVisualStyleBackColor = true;
            // 
            // _Layout_Clientes
            // 
            this._Layout_Clientes.ColumnCount = 1;
            this._Layout_Clientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._Layout_Clientes.Controls.Add(this.panel2, 0, 0);
            this._Layout_Clientes.Controls.Add(this.panel3, 0, 2);
            this._Layout_Clientes.Controls.Add(this.panel4, 0, 1);
            this._Layout_Clientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Layout_Clientes.Location = new System.Drawing.Point(3, 3);
            this._Layout_Clientes.Name = "_Layout_Clientes";
            this._Layout_Clientes.RowCount = 3;
            this._Layout_Clientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._Layout_Clientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this._Layout_Clientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this._Layout_Clientes.Size = new System.Drawing.Size(758, 323);
            this._Layout_Clientes.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this._Dg_Grid_Clientes);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(752, 267);
            this.panel2.TabIndex = 0;
            // 
            // _Dg_Grid_Clientes
            // 
            this._Dg_Grid_Clientes.AllowUserToAddRows = false;
            this._Dg_Grid_Clientes.AllowUserToDeleteRows = false;
            this._Dg_Grid_Clientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid_Clientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this._Dg_Grid_Clientes.Location = new System.Drawing.Point(0, 0);
            this._Dg_Grid_Clientes.MultiSelect = false;
            this._Dg_Grid_Clientes.Name = "_Dg_Grid_Clientes";
            this._Dg_Grid_Clientes.ReadOnly = true;
            this._Dg_Grid_Clientes.Size = new System.Drawing.Size(752, 267);
            this._Dg_Grid_Clientes.TabIndex = 138;
            this._Dg_Grid_Clientes.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_Clientes_RowHeaderMouseDoubleClick);
            this._Dg_Grid_Clientes.Sorted += new System.EventHandler(this._Dg_Grid_Clientes_Sorted);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._Btn_MarcarGuiaCobrada);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 293);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(752, 27);
            this.panel3.TabIndex = 1;
            // 
            // _Btn_MarcarGuiaCobrada
            // 
            this._Btn_MarcarGuiaCobrada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._Btn_MarcarGuiaCobrada.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Btn_MarcarGuiaCobrada.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Btn_MarcarGuiaCobrada.Image = global::T3.Properties.Resources.check;
            this._Btn_MarcarGuiaCobrada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Btn_MarcarGuiaCobrada.Location = new System.Drawing.Point(561, -1);
            this._Btn_MarcarGuiaCobrada.Name = "_Btn_MarcarGuiaCobrada";
            this._Btn_MarcarGuiaCobrada.Size = new System.Drawing.Size(188, 26);
            this._Btn_MarcarGuiaCobrada.TabIndex = 51;
            this._Btn_MarcarGuiaCobrada.Text = "Generar Relación de Cobranza";
            this._Btn_MarcarGuiaCobrada.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Btn_MarcarGuiaCobrada.UseVisualStyleBackColor = true;
            this._Btn_MarcarGuiaCobrada.Click += new System.EventHandler(this._Btn_MarcarGuiaCobrada_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this._Lbl_DgInfo_Clientes);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 276);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(752, 11);
            this.panel4.TabIndex = 2;
            // 
            // _Lbl_DgInfo_Clientes
            // 
            this._Lbl_DgInfo_Clientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo_Clientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Lbl_DgInfo_Clientes.Location = new System.Drawing.Point(0, 0);
            this._Lbl_DgInfo_Clientes.Name = "_Lbl_DgInfo_Clientes";
            this._Lbl_DgInfo_Clientes.Size = new System.Drawing.Size(752, 11);
            this._Lbl_DgInfo_Clientes.TabIndex = 140;
            this._Lbl_DgInfo_Clientes.Text = "Use doble click";
            // 
            // Frm_RC_CobrosContraCamion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 354);
            this.Controls.Add(this._Tb_Tab);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Frm_RC_CobrosContraCamion";
            this.Text = "Cobros contra Camión";
            this.Load += new System.EventHandler(this.Frm_CobrosContraCamion_Load);
            this._Tb_Tab.ResumeLayout(false);
            this._Tb_Tab_Guia.ResumeLayout(false);
            this._Layout_Guia.ResumeLayout(false);
            this._Pnl_Grid_Guia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_Guia)).EndInit();
            this._Tb_Tab_Clientes.ResumeLayout(false);
            this._Layout_Clientes.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_Clientes)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage _Tb_Tab_Guia;
        private System.Windows.Forms.TabPage _Tb_Tab_Clientes;
        private System.Windows.Forms.TableLayoutPanel _Layout_Guia;
        private System.Windows.Forms.Panel _Pnl_Grid_Guia;
        private System.Windows.Forms.DataGridView _Dg_Grid_Guia;
        private System.Windows.Forms.TableLayoutPanel _Layout_Clientes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView _Dg_Grid_Clientes;
        private System.Windows.Forms.Label _Lbl_DgInfo_Guia;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label _Lbl_DgInfo_Clientes;
        private System.Windows.Forms.Button _Btn_MarcarGuiaCobrada;
    }
}