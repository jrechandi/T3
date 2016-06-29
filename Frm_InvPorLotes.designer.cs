namespace T3
{
    partial class Frm_InvPorLotes
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_InvPorLotes));
            this.panel1 = new System.Windows.Forms.Panel();
            this._Txt_Recepcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._Cmb_Estado = new System.Windows.Forms.ComboBox();
            this._Bt_Find = new System.Windows.Forms.Button();
            this._Txt_Producto = new System.Windows.Forms.TextBox();
            this._Chbox_Subgrupos = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Chbox_Grupos = new System.Windows.Forms.CheckBox();
            this._Chbox_Proveedores = new System.Windows.Forms.CheckBox();
            this._Cmb_Proveedor = new System.Windows.Forms.ComboBox();
            this._Cmb_Grupo = new System.Windows.Forms.ComboBox();
            this._Cmb_Subgrupo = new System.Windows.Forms.ComboBox();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Rpt_Report = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Txt_Recepcion);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._Cmb_Estado);
            this.panel1.Controls.Add(this._Bt_Find);
            this.panel1.Controls.Add(this._Txt_Producto);
            this.panel1.Controls.Add(this._Chbox_Subgrupos);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._Chbox_Grupos);
            this.panel1.Controls.Add(this._Chbox_Proveedores);
            this.panel1.Controls.Add(this._Cmb_Proveedor);
            this.panel1.Controls.Add(this._Cmb_Grupo);
            this.panel1.Controls.Add(this._Cmb_Subgrupo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 171);
            this.panel1.TabIndex = 0;
            // 
            // _Txt_Recepcion
            // 
            this._Txt_Recepcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Recepcion.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Recepcion.Location = new System.Drawing.Point(160, 130);
            this._Txt_Recepcion.Name = "_Txt_Recepcion";
            this._Txt_Recepcion.Size = new System.Drawing.Size(100, 18);
            this._Txt_Recepcion.TabIndex = 103;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 12);
            this.label3.TabIndex = 101;
            this.label3.Text = "N. R.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 12);
            this.label2.TabIndex = 100;
            this.label2.Text = "Estado:";
            // 
            // _Cmb_Estado
            // 
            this._Cmb_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Estado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Cmb_Estado.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Estado.FormattingEnabled = true;
            this._Cmb_Estado.Items.AddRange(new object[] {
            "No Autorizado",
            "Autorizado",
            "Todos"});
            this._Cmb_Estado.Location = new System.Drawing.Point(160, 104);
            this._Cmb_Estado.Name = "_Cmb_Estado";
            this._Cmb_Estado.Size = new System.Drawing.Size(304, 20);
            this._Cmb_Estado.TabIndex = 99;
            // 
            // _Bt_Find
            // 
            this._Bt_Find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Find.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Find.Image")));
            this._Bt_Find.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Find.Location = new System.Drawing.Point(500, 115);
            this._Bt_Find.Name = "_Bt_Find";
            this._Bt_Find.Size = new System.Drawing.Size(104, 33);
            this._Bt_Find.TabIndex = 98;
            this._Bt_Find.Text = "Consultar";
            this._Bt_Find.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Find.UseVisualStyleBackColor = true;
            this._Bt_Find.Click += new System.EventHandler(this._Bt_Find_Click);
            // 
            // _Txt_Producto
            // 
            this._Txt_Producto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Producto.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Producto.Location = new System.Drawing.Point(160, 7);
            this._Txt_Producto.Name = "_Txt_Producto";
            this._Txt_Producto.Size = new System.Drawing.Size(100, 18);
            this._Txt_Producto.TabIndex = 86;
            // 
            // _Chbox_Subgrupos
            // 
            this._Chbox_Subgrupos.AutoSize = true;
            this._Chbox_Subgrupos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Chbox_Subgrupos.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Chbox_Subgrupos.Location = new System.Drawing.Point(12, 79);
            this._Chbox_Subgrupos.Name = "_Chbox_Subgrupos";
            this._Chbox_Subgrupos.Size = new System.Drawing.Size(68, 16);
            this._Chbox_Subgrupos.TabIndex = 95;
            this._Chbox_Subgrupos.Text = "Subgrupo";
            this._Chbox_Subgrupos.UseVisualStyleBackColor = true;
            this._Chbox_Subgrupos.CheckedChanged += new System.EventHandler(this._Chbox_Subgrupos_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 12);
            this.label1.TabIndex = 85;
            this.label1.Text = "Código Producto:";
            // 
            // _Chbox_Grupos
            // 
            this._Chbox_Grupos.AutoSize = true;
            this._Chbox_Grupos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Chbox_Grupos.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Chbox_Grupos.Location = new System.Drawing.Point(12, 53);
            this._Chbox_Grupos.Name = "_Chbox_Grupos";
            this._Chbox_Grupos.Size = new System.Drawing.Size(51, 16);
            this._Chbox_Grupos.TabIndex = 94;
            this._Chbox_Grupos.Text = "Grupo";
            this._Chbox_Grupos.UseVisualStyleBackColor = true;
            this._Chbox_Grupos.CheckedChanged += new System.EventHandler(this._Chbox_Grupos_CheckedChanged);
            // 
            // _Chbox_Proveedores
            // 
            this._Chbox_Proveedores.AutoSize = true;
            this._Chbox_Proveedores.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Chbox_Proveedores.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Chbox_Proveedores.Location = new System.Drawing.Point(12, 29);
            this._Chbox_Proveedores.Name = "_Chbox_Proveedores";
            this._Chbox_Proveedores.Size = new System.Drawing.Size(73, 16);
            this._Chbox_Proveedores.TabIndex = 93;
            this._Chbox_Proveedores.Text = "Proveedor";
            this._Chbox_Proveedores.UseVisualStyleBackColor = true;
            this._Chbox_Proveedores.CheckedChanged += new System.EventHandler(this._Chbox_Proveedores_CheckedChanged);
            // 
            // _Cmb_Proveedor
            // 
            this._Cmb_Proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Proveedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Cmb_Proveedor.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Proveedor.FormattingEnabled = true;
            this._Cmb_Proveedor.Location = new System.Drawing.Point(160, 28);
            this._Cmb_Proveedor.Name = "_Cmb_Proveedor";
            this._Cmb_Proveedor.Size = new System.Drawing.Size(304, 20);
            this._Cmb_Proveedor.TabIndex = 88;
            this._Cmb_Proveedor.DropDown += new System.EventHandler(this._Cmb_Proveedor_DropDown);
            this._Cmb_Proveedor.SelectedIndexChanged += new System.EventHandler(this._Cmb_Proveedor_SelectedIndexChanged);
            // 
            // _Cmb_Grupo
            // 
            this._Cmb_Grupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Grupo.Enabled = false;
            this._Cmb_Grupo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Cmb_Grupo.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Grupo.FormattingEnabled = true;
            this._Cmb_Grupo.Location = new System.Drawing.Point(160, 52);
            this._Cmb_Grupo.Name = "_Cmb_Grupo";
            this._Cmb_Grupo.Size = new System.Drawing.Size(304, 20);
            this._Cmb_Grupo.TabIndex = 89;
            this._Cmb_Grupo.DropDown += new System.EventHandler(this._Cmb_Grupo_DropDown);
            this._Cmb_Grupo.SelectedIndexChanged += new System.EventHandler(this._Cmb_Grupo_SelectedIndexChanged);
            // 
            // _Cmb_Subgrupo
            // 
            this._Cmb_Subgrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Subgrupo.Enabled = false;
            this._Cmb_Subgrupo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Cmb_Subgrupo.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Subgrupo.FormattingEnabled = true;
            this._Cmb_Subgrupo.Location = new System.Drawing.Point(160, 78);
            this._Cmb_Subgrupo.Name = "_Cmb_Subgrupo";
            this._Cmb_Subgrupo.Size = new System.Drawing.Size(304, 20);
            this._Cmb_Subgrupo.TabIndex = 90;
            this._Cmb_Subgrupo.DropDown += new System.EventHandler(this._Cmb_Subgrupo_DropDown);
            this._Cmb_Subgrupo.SelectedIndexChanged += new System.EventHandler(this._Cmb_Subgrupo_SelectedIndexChanged);
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // _Rpt_Report
            // 
            this._Rpt_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Rpt_Report.Location = new System.Drawing.Point(0, 171);
            this._Rpt_Report.Name = "_Rpt_Report";
            this._Rpt_Report.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this._Rpt_Report.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this._Rpt_Report.ShowParameterPrompts = false;
            this._Rpt_Report.Size = new System.Drawing.Size(904, 390);
            this._Rpt_Report.TabIndex = 10;
            // 
            // Frm_InvPorLotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 561);
            this.Controls.Add(this._Rpt_Report);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_InvPorLotes";
            this.Text = "Consulta de inventario por Lotes";
            this.Load += new System.EventHandler(this.Frm_Inf_ListadPrecio_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _Bt_Find;
        private System.Windows.Forms.TextBox _Txt_Producto;
        private System.Windows.Forms.CheckBox _Chbox_Subgrupos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox _Chbox_Grupos;
        private System.Windows.Forms.CheckBox _Chbox_Proveedores;
        private System.Windows.Forms.ComboBox _Cmb_Proveedor;
        private System.Windows.Forms.ComboBox _Cmb_Grupo;
        private System.Windows.Forms.ComboBox _Cmb_Subgrupo;
        private System.Windows.Forms.ComboBox _Cmb_Estado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _Txt_Recepcion;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private Microsoft.Reporting.WinForms.ReportViewer _Rpt_Report;
    }
}