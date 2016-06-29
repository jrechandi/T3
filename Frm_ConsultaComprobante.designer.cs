namespace T3
{
    partial class Frm_ConsultaComprobante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ConsultaComprobante));
            this.label1 = new System.Windows.Forms.Label();
            this._Cmb_Reporte = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this._Txt_Descripcion = new System.Windows.Forms.TextBox();
            this._Txt_Hasta = new System.Windows.Forms.TextBox();
            this._Chk_DesHas = new System.Windows.Forms.CheckBox();
            this._Lbl_Desde = new System.Windows.Forms.Label();
            this._Txt_Comprobante = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._Cmb_Mes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Cmb_TipComp = new System.Windows.Forms.ComboBox();
            this._Rpv_Main = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this._Bt_Consultar = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._Pnl_Superior = new System.Windows.Forms.Panel();
            this._Bt_Imprimir = new System.Windows.Forms.Button();
            this._Ctrl_Contex = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verTodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this._Pnl_Superior.SuspendLayout();
            this._Ctrl_Contex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Consultar por:";
            // 
            // _Cmb_Reporte
            // 
            this._Cmb_Reporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Reporte.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Cmb_Reporte.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Reporte.FormattingEnabled = true;
            this._Cmb_Reporte.Location = new System.Drawing.Point(146, 6);
            this._Cmb_Reporte.Name = "_Cmb_Reporte";
            this._Cmb_Reporte.Size = new System.Drawing.Size(356, 20);
            this._Cmb_Reporte.TabIndex = 0;
            this._Cmb_Reporte.SelectedIndexChanged += new System.EventHandler(this._Cmb_Reporte_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(75, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "Descripción:";
            // 
            // _Txt_Descripcion
            // 
            this._Txt_Descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Descripcion.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Descripcion.Location = new System.Drawing.Point(146, 108);
            this._Txt_Descripcion.Name = "_Txt_Descripcion";
            this._Txt_Descripcion.Size = new System.Drawing.Size(356, 18);
            this._Txt_Descripcion.TabIndex = 14;
            // 
            // _Txt_Hasta
            // 
            this._Txt_Hasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Hasta.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Hasta.Location = new System.Drawing.Point(304, 84);
            this._Txt_Hasta.Name = "_Txt_Hasta";
            this._Txt_Hasta.Size = new System.Drawing.Size(92, 18);
            this._Txt_Hasta.TabIndex = 12;
            this._Txt_Hasta.Visible = false;
            this._Txt_Hasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Hasta_KeyPress);
            // 
            // _Chk_DesHas
            // 
            this._Chk_DesHas.AutoSize = true;
            this._Chk_DesHas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Chk_DesHas.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Chk_DesHas.Location = new System.Drawing.Point(244, 86);
            this._Chk_DesHas.Name = "_Chk_DesHas";
            this._Chk_DesHas.Size = new System.Drawing.Size(54, 16);
            this._Chk_DesHas.TabIndex = 11;
            this._Chk_DesHas.Text = "Hasta:";
            this._Chk_DesHas.UseVisualStyleBackColor = true;
            this._Chk_DesHas.CheckedChanged += new System.EventHandler(this._Chk_DesHas_CheckedChanged);
            // 
            // _Lbl_Desde
            // 
            this._Lbl_Desde.AutoSize = true;
            this._Lbl_Desde.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_Desde.Location = new System.Drawing.Point(71, 86);
            this._Lbl_Desde.Name = "_Lbl_Desde";
            this._Lbl_Desde.Size = new System.Drawing.Size(69, 12);
            this._Lbl_Desde.TabIndex = 9;
            this._Lbl_Desde.Text = "Consecutivo:";
            // 
            // _Txt_Comprobante
            // 
            this._Txt_Comprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Comprobante.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Comprobante.Location = new System.Drawing.Point(146, 84);
            this._Txt_Comprobante.Name = "_Txt_Comprobante";
            this._Txt_Comprobante.Size = new System.Drawing.Size(92, 18);
            this._Txt_Comprobante.TabIndex = 8;
            this._Txt_Comprobante.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Comprobante_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(80, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mes y Año:";
            // 
            // _Cmb_Mes
            // 
            this._Cmb_Mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Mes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Cmb_Mes.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Mes.FormattingEnabled = true;
            this._Cmb_Mes.Location = new System.Drawing.Point(146, 58);
            this._Cmb_Mes.Name = "_Cmb_Mes";
            this._Cmb_Mes.Size = new System.Drawing.Size(120, 20);
            this._Cmb_Mes.TabIndex = 4;
            this._Cmb_Mes.DropDown += new System.EventHandler(this._Cmb_Mes_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tipo de Comprobante:";
            // 
            // _Cmb_TipComp
            // 
            this._Cmb_TipComp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_TipComp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Cmb_TipComp.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_TipComp.FormattingEnabled = true;
            this._Cmb_TipComp.Location = new System.Drawing.Point(146, 32);
            this._Cmb_TipComp.Name = "_Cmb_TipComp";
            this._Cmb_TipComp.Size = new System.Drawing.Size(189, 20);
            this._Cmb_TipComp.TabIndex = 2;
            this._Cmb_TipComp.DropDown += new System.EventHandler(this._Cmb_TipComp_DropDown);
            // 
            // _Rpv_Main
            // 
            this._Rpv_Main.ActiveViewIndex = -1;
            this._Rpv_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Rpv_Main.Cursor = System.Windows.Forms.Cursors.Default;
            this._Rpv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Rpv_Main.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Rpv_Main.Location = new System.Drawing.Point(3, 38);
            this._Rpv_Main.Name = "_Rpv_Main";
            this._Rpv_Main.SelectionFormula = "";
            this._Rpv_Main.ShowGroupTreeButton = false;
            this._Rpv_Main.Size = new System.Drawing.Size(921, 445);
            this._Rpv_Main.TabIndex = 1;
            this._Rpv_Main.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this._Rpv_Main.ViewTimeSelectionFormula = "";
            // 
            // _Tb_Tab
            // 
            this._Tb_Tab.Controls.Add(this.tabPage1);
            this._Tb_Tab.Controls.Add(this.tabPage2);
            this._Tb_Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Tb_Tab.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Tb_Tab.Location = new System.Drawing.Point(0, 0);
            this._Tb_Tab.Name = "_Tb_Tab";
            this._Tb_Tab.SelectedIndex = 0;
            this._Tb_Tab.Size = new System.Drawing.Size(935, 511);
            this._Tb_Tab.TabIndex = 2;
            this._Tb_Tab.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this._Tb_Tab_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this._Dg_Grid);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(927, 486);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(3, 137);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Size = new System.Drawing.Size(921, 346);
            this._Dg_Grid.TabIndex = 3;
            this._Dg_Grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._Bt_Consultar);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this._Cmb_Reporte);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this._Cmb_TipComp);
            this.panel2.Controls.Add(this._Cmb_Mes);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this._Txt_Descripcion);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this._Txt_Comprobante);
            this.panel2.Controls.Add(this._Chk_DesHas);
            this.panel2.Controls.Add(this._Lbl_Desde);
            this.panel2.Controls.Add(this._Txt_Hasta);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(921, 134);
            this.panel2.TabIndex = 4;
            // 
            // _Bt_Consultar
            // 
            this._Bt_Consultar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._Bt_Consultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Consultar.Image")));
            this._Bt_Consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Consultar.Location = new System.Drawing.Point(517, 89);
            this._Bt_Consultar.Name = "_Bt_Consultar";
            this._Bt_Consultar.Size = new System.Drawing.Size(125, 37);
            this._Bt_Consultar.TabIndex = 59;
            this._Bt_Consultar.Text = "Buscar";
            this._Bt_Consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Consultar.UseVisualStyleBackColor = true;
            this._Bt_Consultar.Click += new System.EventHandler(this._Bt_Consultar_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this._Rpv_Main);
            this.tabPage2.Controls.Add(this._Pnl_Superior);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(927, 486);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Reporte";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _Pnl_Superior
            // 
            this._Pnl_Superior.Controls.Add(this._Bt_Imprimir);
            this._Pnl_Superior.Dock = System.Windows.Forms.DockStyle.Top;
            this._Pnl_Superior.Location = new System.Drawing.Point(3, 3);
            this._Pnl_Superior.Name = "_Pnl_Superior";
            this._Pnl_Superior.Size = new System.Drawing.Size(921, 35);
            this._Pnl_Superior.TabIndex = 2;
            this._Pnl_Superior.Visible = false;
            // 
            // _Bt_Imprimir
            // 
            this._Bt_Imprimir.BackColor = System.Drawing.Color.Transparent;
            this._Bt_Imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Imprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Bt_Imprimir.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Imprimir.Image")));
            this._Bt_Imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Imprimir.Location = new System.Drawing.Point(5, 3);
            this._Bt_Imprimir.Name = "_Bt_Imprimir";
            this._Bt_Imprimir.Size = new System.Drawing.Size(168, 28);
            this._Bt_Imprimir.TabIndex = 19;
            this._Bt_Imprimir.Text = "Imprimir y actualizar";
            this._Bt_Imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Imprimir.UseVisualStyleBackColor = false;
            this._Bt_Imprimir.Click += new System.EventHandler(this._Bt_Imprimir_Click);
            // 
            // _Ctrl_Contex
            // 
            this._Ctrl_Contex.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verTodToolStripMenuItem});
            this._Ctrl_Contex.Name = "_Ctrl_Contex";
            this._Ctrl_Contex.Size = new System.Drawing.Size(194, 26);
            this._Ctrl_Contex.Opening += new System.ComponentModel.CancelEventHandler(this._Ctrl_Contex_Opening);
            // 
            // verTodToolStripMenuItem
            // 
            this.verTodToolStripMenuItem.Name = "verTodToolStripMenuItem";
            this.verTodToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.verTodToolStripMenuItem.Text = "Ver todos en el reporte";
            this.verTodToolStripMenuItem.Click += new System.EventHandler(this.verTodToolStripMenuItem_Click);
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // Frm_ConsultaComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 511);
            this.Controls.Add(this._Tb_Tab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ConsultaComprobante";
            this.Text = "Consulta de Comprobante ";
            this.Activated += new System.EventHandler(this.Frm_ConsultaComprobante_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ConsultaComprobante_FormClosing);
            this.Load += new System.EventHandler(this.Frm_ConsultaComprobante_Load);
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this._Pnl_Superior.ResumeLayout(false);
            this._Ctrl_Contex.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _Cmb_Reporte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _Cmb_TipComp;
        private System.Windows.Forms.TextBox _Txt_Comprobante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _Cmb_Mes;
        private System.Windows.Forms.Label _Lbl_Desde;
        private System.Windows.Forms.CheckBox _Chk_DesHas;
        private System.Windows.Forms.TextBox _Txt_Hasta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _Txt_Descripcion;
        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button _Bt_Consultar;
        private System.Windows.Forms.ContextMenuStrip _Ctrl_Contex;
        private System.Windows.Forms.ToolStripMenuItem verTodToolStripMenuItem;
        private System.Windows.Forms.Panel _Pnl_Superior;
        private System.Windows.Forms.Button _Bt_Imprimir;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer _Rpv_Main;
    }
}