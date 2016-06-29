namespace T3
{
    partial class Frm_OperBancDExcep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_OperBancDExcep));
            this._Cmb_Banco = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Bt_Consultar = new System.Windows.Forms.Button();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this._Cntx_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._Tool_Eliminar = new System.Windows.Forms.ToolStripMenuItem();
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this._Txt_DesOper = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._Txt_CodOper = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._Cmb_BancoD = new System.Windows.Forms.ComboBox();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this._Cntx_Menu.SuspendLayout();
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this.SuspendLayout();
            // 
            // _Cmb_Banco
            // 
            this._Cmb_Banco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Banco.FormattingEnabled = true;
            this._Cmb_Banco.Location = new System.Drawing.Point(14, 25);
            this._Cmb_Banco.Name = "_Cmb_Banco";
            this._Cmb_Banco.Size = new System.Drawing.Size(372, 21);
            this._Cmb_Banco.TabIndex = 17;
            this._Cmb_Banco.SelectedIndexChanged += new System.EventHandler(this._Cmb_Banco_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(14, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 12);
            this.label13.TabIndex = 16;
            this.label13.Text = "Banco:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Bt_Consultar);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this._Cmb_Banco);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 58);
            this.panel1.TabIndex = 18;
            // 
            // _Bt_Consultar
            // 
            this._Bt_Consultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Consultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Consultar.Image")));
            this._Bt_Consultar.Location = new System.Drawing.Point(409, 24);
            this._Bt_Consultar.Name = "_Bt_Consultar";
            this._Bt_Consultar.Size = new System.Drawing.Size(35, 23);
            this._Bt_Consultar.TabIndex = 18;
            this._Bt_Consultar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this._Bt_Consultar.UseVisualStyleBackColor = true;
            this._Bt_Consultar.Click += new System.EventHandler(this._Bt_Consultar_Click);
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.ContextMenuStrip = this._Cntx_Menu;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(3, 61);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.Size = new System.Drawing.Size(755, 266);
            this._Dg_Grid.TabIndex = 19;
            this._Dg_Grid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_CellMouseEnter);
            this._Dg_Grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseDoubleClick);
            // 
            // _Cntx_Menu
            // 
            this._Cntx_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._Tool_Eliminar});
            this._Cntx_Menu.Name = "_Cntx_Menu";
            this._Cntx_Menu.Size = new System.Drawing.Size(118, 26);
            this._Cntx_Menu.Opening += new System.ComponentModel.CancelEventHandler(this._Cntx_Menu_Opening);
            // 
            // _Tool_Eliminar
            // 
            this._Tool_Eliminar.Name = "_Tool_Eliminar";
            this._Tool_Eliminar.Size = new System.Drawing.Size(117, 22);
            this._Tool_Eliminar.Text = "Eliminar";
            this._Tool_Eliminar.Click += new System.EventHandler(this._Tool_Eliminar_Click);
            // 
            // _Tb_Tab
            // 
            this._Tb_Tab.Controls.Add(this.tabPage1);
            this._Tb_Tab.Controls.Add(this.tabPage2);
            this._Tb_Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Tb_Tab.Location = new System.Drawing.Point(0, 0);
            this._Tb_Tab.Name = "_Tb_Tab";
            this._Tb_Tab.SelectedIndex = 0;
            this._Tb_Tab.Size = new System.Drawing.Size(769, 356);
            this._Tb_Tab.TabIndex = 18;
            this._Tb_Tab.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this._Tb_Tab_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._Lbl_DgInfo);
            this.tabPage1.Controls.Add(this._Dg_Grid);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(761, 330);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(3, 315);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(755, 12);
            this._Lbl_DgInfo.TabIndex = 20;
            this._Lbl_DgInfo.Text = "Use doble click para editar y click derecho para eliminar";
            this._Lbl_DgInfo.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this._Txt_DesOper);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this._Txt_CodOper);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this._Cmb_BancoD);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(761, 330);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "Descripción:";
            // 
            // _Txt_DesOper
            // 
            this._Txt_DesOper.Enabled = false;
            this._Txt_DesOper.Location = new System.Drawing.Point(19, 93);
            this._Txt_DesOper.MaxLength = 100;
            this._Txt_DesOper.Name = "_Txt_DesOper";
            this._Txt_DesOper.Size = new System.Drawing.Size(269, 20);
            this._Txt_DesOper.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(311, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "Código:";
            // 
            // _Txt_CodOper
            // 
            this._Txt_CodOper.Enabled = false;
            this._Txt_CodOper.Location = new System.Drawing.Point(313, 93);
            this._Txt_CodOper.MaxLength = 50;
            this._Txt_CodOper.Name = "_Txt_CodOper";
            this._Txt_CodOper.Size = new System.Drawing.Size(76, 20);
            this._Txt_CodOper.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "Tipo de operación bancaria (del banco):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "Banco:";
            // 
            // _Cmb_BancoD
            // 
            this._Cmb_BancoD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_BancoD.Enabled = false;
            this._Cmb_BancoD.FormattingEnabled = true;
            this._Cmb_BancoD.Location = new System.Drawing.Point(17, 28);
            this._Cmb_BancoD.Name = "_Cmb_BancoD";
            this._Cmb_BancoD.Size = new System.Drawing.Size(372, 21);
            this._Cmb_BancoD.TabIndex = 19;
            this._Cmb_BancoD.DropDown += new System.EventHandler(this._Cmb_BancoD_DropDown);
            this._Cmb_BancoD.SelectedIndexChanged += new System.EventHandler(this._Cmb_BancoD_SelectedIndexChanged);
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // Frm_OperBancDExcep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 356);
            this.Controls.Add(this._Tb_Tab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Frm_OperBancDExcep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración de operaciones bancarias (Excepciones)";
            this.Activated += new System.EventHandler(this.Frm_OperBancD_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_OperBancD_FormClosing);
            this.Load += new System.EventHandler(this.Frm_OperBancD_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this._Cntx_Menu.ResumeLayout(false);
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox _Cmb_Banco;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _Cmb_BancoD;
        private System.Windows.Forms.TextBox _Txt_CodOper;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _Txt_DesOper;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label _Lbl_DgInfo;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.ContextMenuStrip _Cntx_Menu;
        private System.Windows.Forms.ToolStripMenuItem _Tool_Eliminar;
        private System.Windows.Forms.Button _Bt_Consultar;

    }
}