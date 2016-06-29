namespace T3
{
    partial class Frm_Uniticket
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Uniticket));
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this.ccedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfecha_egreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Cntx_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._mnu_IngresoReportado = new System.Windows.Forms.ToolStripMenuItem();
            this._mnu_IngresoNoReportado = new System.Windows.Forms.ToolStripMenuItem();
            this._mnu_EgresoReportado = new System.Windows.Forms.ToolStripMenuItem();
            this._mnu_EgresoNoReportado = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._mnu_GenerarReporte = new System.Windows.Forms.ToolStripMenuItem();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this._Cmb_Filtro = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Ctrl_Busqueda1 = new T3.Controles._Ctrl_Busqueda();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this._Cntx_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ccedula,
            this.Column4,
            this.Column1,
            this.Column5,
            this.cfecha_egreso,
            this.Column7,
            this.Column8});
            this._Dg_Grid.ContextMenuStrip = this._Cntx_Menu;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(0, 41);
            this._Dg_Grid.MultiSelect = false;
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Size = new System.Drawing.Size(1016, 324);
            this._Dg_Grid.TabIndex = 3;
            this._Dg_Grid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_CellMouseEnter);
            // 
            // ccedula
            // 
            this.ccedula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ccedula.DataPropertyName = "ccedula";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ccedula.DefaultCellStyle = dataGridViewCellStyle1;
            this.ccedula.HeaderText = "Cédula";
            this.ccedula.Name = "ccedula";
            this.ccedula.ReadOnly = true;
            this.ccedula.Width = 64;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "cnombre";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "Nombre";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ccargo";
            this.Column1.HeaderText = "Cargo";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.DataPropertyName = "cfecha_ingreso";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column5.HeaderText = "Fecha ingreso";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 90;
            // 
            // cfecha_egreso
            // 
            this.cfecha_egreso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cfecha_egreso.DataPropertyName = "cfecha_egreso";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cfecha_egreso.DefaultCellStyle = dataGridViewCellStyle4;
            this.cfecha_egreso.HeaderText = "Fecha egreso";
            this.cfecha_egreso.Name = "cfecha_egreso";
            this.cfecha_egreso.ReadOnly = true;
            this.cfecha_egreso.Width = 88;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.DataPropertyName = "cingreso_reportado";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column7.HeaderText = "Ingreso reportado";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 105;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column8.DataPropertyName = "cegreso_reportado";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column8.HeaderText = "Egreso reportado";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 103;
            // 
            // _Cntx_Menu
            // 
            this._Cntx_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mnu_IngresoReportado,
            this._mnu_IngresoNoReportado,
            this._mnu_EgresoReportado,
            this._mnu_EgresoNoReportado,
            this.toolStripSeparator1,
            this._mnu_GenerarReporte});
            this._Cntx_Menu.Name = "_Cntx_Menu";
            this._Cntx_Menu.Size = new System.Drawing.Size(291, 120);
            // 
            // _mnu_IngresoReportado
            // 
            this._mnu_IngresoReportado.Name = "_mnu_IngresoReportado";
            this._mnu_IngresoReportado.Size = new System.Drawing.Size(290, 22);
            this._mnu_IngresoReportado.Text = "Marcar como INGRESO REPORTADO...";
            this._mnu_IngresoReportado.Click += new System.EventHandler(this._mnu_IngresoReportado_Click);
            // 
            // _mnu_IngresoNoReportado
            // 
            this._mnu_IngresoNoReportado.Name = "_mnu_IngresoNoReportado";
            this._mnu_IngresoNoReportado.Size = new System.Drawing.Size(290, 22);
            this._mnu_IngresoNoReportado.Text = "Marcar como INGRESO NO REPORTADO...";
            this._mnu_IngresoNoReportado.Click += new System.EventHandler(this._mnu_IngresoNoReportado_Click);
            // 
            // _mnu_EgresoReportado
            // 
            this._mnu_EgresoReportado.Name = "_mnu_EgresoReportado";
            this._mnu_EgresoReportado.Size = new System.Drawing.Size(290, 22);
            this._mnu_EgresoReportado.Text = "Marcar como EGRESO REPORTADO...";
            this._mnu_EgresoReportado.Click += new System.EventHandler(this._mnu_EgresoReportado_Click);
            // 
            // _mnu_EgresoNoReportado
            // 
            this._mnu_EgresoNoReportado.Name = "_mnu_EgresoNoReportado";
            this._mnu_EgresoNoReportado.Size = new System.Drawing.Size(290, 22);
            this._mnu_EgresoNoReportado.Text = "Marcar como EGRESO NO REPORTADO...";
            this._mnu_EgresoNoReportado.Click += new System.EventHandler(this._mnu_EgresoNoReportado_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(287, 6);
            // 
            // _mnu_GenerarReporte
            // 
            this._mnu_GenerarReporte.Name = "_mnu_GenerarReporte";
            this._mnu_GenerarReporte.Size = new System.Drawing.Size(290, 22);
            this._mnu_GenerarReporte.Text = "Generar reporte...";
            this._mnu_GenerarReporte.Click += new System.EventHandler(this._mnu_GenerarReporte_Click);
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(0, 355);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(1016, 10);
            this._Lbl_DgInfo.TabIndex = 7;
            this._Lbl_DgInfo.Text = "Haga clic con el botón derecho del ratón";
            this._Lbl_DgInfo.Visible = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Archivosde Excel|*.xls|Todos los archivos|*.*";
            // 
            // _Cmb_Filtro
            // 
            this._Cmb_Filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Filtro.FormattingEnabled = true;
            this._Cmb_Filtro.Items.AddRange(new object[] {
            "Todos",
            "Pendientes (ingresos y egresos no reportados)",
            "Sólo ingresos no reportados",
            "Sólo egresos no reportados"});
            this._Cmb_Filtro.Location = new System.Drawing.Point(380, 2);
            this._Cmb_Filtro.Name = "_Cmb_Filtro";
            this._Cmb_Filtro.Size = new System.Drawing.Size(225, 21);
            this._Cmb_Filtro.TabIndex = 8;
            this._Cmb_Filtro.SelectedIndexChanged += new System.EventHandler(this._Cmb_Filtro_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Filtro :";
            // 
            // _Ctrl_Busqueda1
            // 
            this._Ctrl_Busqueda1.Dock = System.Windows.Forms.DockStyle.Top;
            this._Ctrl_Busqueda1.Location = new System.Drawing.Point(0, 0);
            this._Ctrl_Busqueda1.Name = "_Ctrl_Busqueda1";
            this._Ctrl_Busqueda1.Size = new System.Drawing.Size(1016, 41);
            this._Ctrl_Busqueda1.TabIndex = 2;
            // 
            // Frm_Uniticket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 365);
            this.Controls.Add(this._Lbl_DgInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._Cmb_Filtro);
            this.Controls.Add(this._Dg_Grid);
            this.Controls.Add(this._Ctrl_Busqueda1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Frm_Uniticket";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generación de reporte UNITICKET";
            this.Load += new System.EventHandler(this.Frm_Uniticket_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this._Cntx_Menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _Dg_Grid;
        private T3.Controles._Ctrl_Busqueda _Ctrl_Busqueda1;
        private System.Windows.Forms.Label _Lbl_DgInfo;
        private System.Windows.Forms.ContextMenuStrip _Cntx_Menu;
        private System.Windows.Forms.ToolStripMenuItem _mnu_IngresoReportado;
        private System.Windows.Forms.ToolStripMenuItem _mnu_IngresoNoReportado;
        private System.Windows.Forms.ToolStripMenuItem _mnu_EgresoReportado;
        private System.Windows.Forms.ToolStripMenuItem _mnu_EgresoNoReportado;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem _mnu_GenerarReporte;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn cfecha_egreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.ComboBox _Cmb_Filtro;
        private System.Windows.Forms.Label label1;

    }
}