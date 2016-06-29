namespace T3
{
    partial class Frm_Inf_CostoUtilProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Inf_CostoUtilProducto));
            this.panel1 = new System.Windows.Forms.Panel();
            this._Bt_Find = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this._Cb_MarcaFind = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Cb_ProveedorFind = new System.Windows.Forms.ComboBox();
            this._Cb_GrupoFind = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this._Cb_SubGrupoFind = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Rpv_Main = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Bt_Find);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this._Cb_MarcaFind);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._Cb_ProveedorFind);
            this.panel1.Controls.Add(this._Cb_GrupoFind);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this._Cb_SubGrupoFind);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 124);
            this.panel1.TabIndex = 0;
            // 
            // _Bt_Find
            // 
            this._Bt_Find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Find.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Find.Image")));
            this._Bt_Find.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Find.Location = new System.Drawing.Point(388, 76);
            this._Bt_Find.Name = "_Bt_Find";
            this._Bt_Find.Size = new System.Drawing.Size(104, 36);
            this._Bt_Find.TabIndex = 34;
            this._Bt_Find.Text = "Consultar";
            this._Bt_Find.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Find.UseVisualStyleBackColor = true;
            this._Bt_Find.Click += new System.EventHandler(this._Bt_Find_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 12);
            this.label8.TabIndex = 25;
            this.label8.Text = "Proveedor:";
            // 
            // _Cb_MarcaFind
            // 
            this._Cb_MarcaFind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_MarcaFind.Enabled = false;
            this._Cb_MarcaFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_MarcaFind.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cb_MarcaFind.FormattingEnabled = true;
            this._Cb_MarcaFind.Location = new System.Drawing.Point(89, 92);
            this._Cb_MarcaFind.Name = "_Cb_MarcaFind";
            this._Cb_MarcaFind.Size = new System.Drawing.Size(284, 20);
            this._Cb_MarcaFind.TabIndex = 32;
            this._Cb_MarcaFind.DropDown += new System.EventHandler(this._Cb_MarcaFind_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 12);
            this.label2.TabIndex = 29;
            this.label2.Text = "Sub-Grupo:";
            // 
            // _Cb_ProveedorFind
            // 
            this._Cb_ProveedorFind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_ProveedorFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_ProveedorFind.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cb_ProveedorFind.FormattingEnabled = true;
            this._Cb_ProveedorFind.Location = new System.Drawing.Point(89, 12);
            this._Cb_ProveedorFind.Name = "_Cb_ProveedorFind";
            this._Cb_ProveedorFind.Size = new System.Drawing.Size(284, 20);
            this._Cb_ProveedorFind.TabIndex = 26;
            this._Cb_ProveedorFind.SelectedIndexChanged += new System.EventHandler(this._Cb_ProveedorFind_SelectedIndexChanged);
            this._Cb_ProveedorFind.DropDown += new System.EventHandler(this._Cb_ProveedorFind_DropDown);
            // 
            // _Cb_GrupoFind
            // 
            this._Cb_GrupoFind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_GrupoFind.Enabled = false;
            this._Cb_GrupoFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_GrupoFind.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cb_GrupoFind.FormattingEnabled = true;
            this._Cb_GrupoFind.Location = new System.Drawing.Point(89, 38);
            this._Cb_GrupoFind.Name = "_Cb_GrupoFind";
            this._Cb_GrupoFind.Size = new System.Drawing.Size(284, 20);
            this._Cb_GrupoFind.TabIndex = 28;
            this._Cb_GrupoFind.SelectedIndexChanged += new System.EventHandler(this._Cb_GrupoFind_SelectedIndexChanged);
            this._Cb_GrupoFind.DropDown += new System.EventHandler(this._Cb_GrupoFind_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "Marca:";
            // 
            // _Cb_SubGrupoFind
            // 
            this._Cb_SubGrupoFind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_SubGrupoFind.Enabled = false;
            this._Cb_SubGrupoFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_SubGrupoFind.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cb_SubGrupoFind.FormattingEnabled = true;
            this._Cb_SubGrupoFind.Location = new System.Drawing.Point(89, 64);
            this._Cb_SubGrupoFind.Name = "_Cb_SubGrupoFind";
            this._Cb_SubGrupoFind.Size = new System.Drawing.Size(284, 20);
            this._Cb_SubGrupoFind.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "Grupo:";
            // 
            // _Rpv_Main
            // 
            this._Rpv_Main.ActiveViewIndex = -1;
            this._Rpv_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Rpv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Rpv_Main.Location = new System.Drawing.Point(0, 124);
            this._Rpv_Main.Name = "_Rpv_Main";
            this._Rpv_Main.SelectionFormula = "";
            this._Rpv_Main.ShowParameterPanelButton = false;
            this._Rpv_Main.Size = new System.Drawing.Size(781, 379);
            this._Rpv_Main.TabIndex = 18;
            this._Rpv_Main.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this._Rpv_Main.ViewTimeSelectionFormula = "";
            // 
            // Frm_Inf_CostoUtilProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 503);
            this.Controls.Add(this._Rpv_Main);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Inf_CostoUtilProducto";
            this.Text = "Informe - Costo y Utilidad por Producto";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _Bt_Find;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox _Cb_MarcaFind;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _Cb_ProveedorFind;
        private System.Windows.Forms.ComboBox _Cb_GrupoFind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _Cb_SubGrupoFind;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer _Rpv_Main;
    }
}