namespace T3
{
    partial class Frm_Inf_AnalisisSaldo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Inf_AnalisisSaldo));
            this.panel1 = new System.Windows.Forms.Panel();
            this._Bt_Exportar = new System.Windows.Forms.Button();
            this._Bt_Caja = new System.Windows.Forms.Button();
            this._Txt_Caja = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._Rbt_Cierres = new System.Windows.Forms.RadioButton();
            this._Rbt_Actual = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._Rb_SinFiltro = new System.Windows.Forms.RadioButton();
            this._Cb_EscalaCredito = new System.Windows.Forms.ComboBox();
            this._Rb_EscalaCredito = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._Cb_TpoDoc = new System.Windows.Forms.ComboBox();
            this._Rb_TpoDoc = new System.Windows.Forms.RadioButton();
            this._Bt_Find = new System.Windows.Forms.Button();
            this._Chk_Imp = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._Cb_ZonaVendedor = new System.Windows.Forms.ComboBox();
            this._Rb_Cliente = new System.Windows.Forms.RadioButton();
            this._Rb_Vendedor = new System.Windows.Forms.RadioButton();
            this._Rpv_Main = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Sfd_1 = new System.Windows.Forms.SaveFileDialog();
            this._Rbt_CierreMes = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this._Cb_MesAnoCierre = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Cb_MesAnoCierre);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this._Rbt_CierreMes);
            this.panel1.Controls.Add(this._Bt_Exportar);
            this.panel1.Controls.Add(this._Bt_Caja);
            this.panel1.Controls.Add(this._Txt_Caja);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this._Rbt_Cierres);
            this.panel1.Controls.Add(this._Rbt_Actual);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this._Bt_Find);
            this.panel1.Controls.Add(this._Chk_Imp);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 211);
            this.panel1.TabIndex = 0;
            // 
            // _Bt_Exportar
            // 
            this._Bt_Exportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Exportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Exportar.Image = global::T3.Properties.Resources.excel1;
            this._Bt_Exportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Exportar.Location = new System.Drawing.Point(692, 157);
            this._Bt_Exportar.Name = "_Bt_Exportar";
            this._Bt_Exportar.Size = new System.Drawing.Size(104, 33);
            this._Bt_Exportar.TabIndex = 83;
            this._Bt_Exportar.Text = "Exportar";
            this._Bt_Exportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Exportar.UseVisualStyleBackColor = true;
            this._Bt_Exportar.Click += new System.EventHandler(this._Bt_Exportar_Click);
            // 
            // _Bt_Caja
            // 
            this._Bt_Caja.Enabled = false;
            this._Bt_Caja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Caja.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Caja.Image")));
            this._Bt_Caja.Location = new System.Drawing.Point(356, 26);
            this._Bt_Caja.Name = "_Bt_Caja";
            this._Bt_Caja.Size = new System.Drawing.Size(26, 18);
            this._Bt_Caja.TabIndex = 59;
            this._Bt_Caja.Text = "...";
            this._Bt_Caja.UseVisualStyleBackColor = true;
            this._Bt_Caja.Click += new System.EventHandler(this._Bt_Caja_Click);
            // 
            // _Txt_Caja
            // 
            this._Txt_Caja.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._Txt_Caja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Caja.Enabled = false;
            this._Txt_Caja.Location = new System.Drawing.Point(228, 26);
            this._Txt_Caja.Name = "_Txt_Caja";
            this._Txt_Caja.ReadOnly = true;
            this._Txt_Caja.Size = new System.Drawing.Size(122, 18);
            this._Txt_Caja.TabIndex = 58;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(195, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 12);
            this.label5.TabIndex = 57;
            this.label5.Text = "Caja:";
            // 
            // _Rbt_Cierres
            // 
            this._Rbt_Cierres.AutoSize = true;
            this._Rbt_Cierres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Rbt_Cierres.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Rbt_Cierres.Location = new System.Drawing.Point(12, 27);
            this._Rbt_Cierres.Name = "_Rbt_Cierres";
            this._Rbt_Cierres.Size = new System.Drawing.Size(164, 16);
            this._Rbt_Cierres.TabIndex = 52;
            this._Rbt_Cierres.Text = "Reporte por cajas anteriores";
            this._Rbt_Cierres.UseVisualStyleBackColor = true;
            this._Rbt_Cierres.CheckedChanged += new System.EventHandler(this._Rbt_Cierres_CheckedChanged);
            // 
            // _Rbt_Actual
            // 
            this._Rbt_Actual.AutoSize = true;
            this._Rbt_Actual.Checked = true;
            this._Rbt_Actual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Rbt_Actual.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Rbt_Actual.Location = new System.Drawing.Point(12, 5);
            this._Rbt_Actual.Name = "_Rbt_Actual";
            this._Rbt_Actual.Size = new System.Drawing.Size(96, 16);
            this._Rbt_Actual.TabIndex = 51;
            this._Rbt_Actual.TabStop = true;
            this._Rbt_Actual.Text = "Reporte actual";
            this._Rbt_Actual.UseVisualStyleBackColor = true;
            this._Rbt_Actual.CheckedChanged += new System.EventHandler(this._Rbt_Actual_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._Rb_SinFiltro);
            this.groupBox2.Controls.Add(this._Cb_EscalaCredito);
            this.groupBox2.Controls.Add(this._Rb_EscalaCredito);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this._Cb_TpoDoc);
            this.groupBox2.Controls.Add(this._Rb_TpoDoc);
            this.groupBox2.Location = new System.Drawing.Point(12, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 117);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtrado";
            // 
            // _Rb_SinFiltro
            // 
            this._Rb_SinFiltro.AutoSize = true;
            this._Rb_SinFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Rb_SinFiltro.Location = new System.Drawing.Point(16, 15);
            this._Rb_SinFiltro.Name = "_Rb_SinFiltro";
            this._Rb_SinFiltro.Size = new System.Drawing.Size(68, 16);
            this._Rb_SinFiltro.TabIndex = 38;
            this._Rb_SinFiltro.TabStop = true;
            this._Rb_SinFiltro.Text = "Sin filtrar";
            this._Rb_SinFiltro.UseVisualStyleBackColor = true;
            this._Rb_SinFiltro.CheckedChanged += new System.EventHandler(this._Rb_SinFiltro_CheckedChanged);
            // 
            // _Cb_EscalaCredito
            // 
            this._Cb_EscalaCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_EscalaCredito.Enabled = false;
            this._Cb_EscalaCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_EscalaCredito.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cb_EscalaCredito.FormattingEnabled = true;
            this._Cb_EscalaCredito.Location = new System.Drawing.Point(35, 52);
            this._Cb_EscalaCredito.Name = "_Cb_EscalaCredito";
            this._Cb_EscalaCredito.Size = new System.Drawing.Size(293, 20);
            this._Cb_EscalaCredito.TabIndex = 31;
            this._Cb_EscalaCredito.DropDown += new System.EventHandler(this._Cb_EscalaCredito_DropDown);
            // 
            // _Rb_EscalaCredito
            // 
            this._Rb_EscalaCredito.AutoSize = true;
            this._Rb_EscalaCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Rb_EscalaCredito.Location = new System.Drawing.Point(16, 54);
            this._Rb_EscalaCredito.Name = "_Rb_EscalaCredito";
            this._Rb_EscalaCredito.Size = new System.Drawing.Size(13, 12);
            this._Rb_EscalaCredito.TabIndex = 29;
            this._Rb_EscalaCredito.TabStop = true;
            this._Rb_EscalaCredito.UseVisualStyleBackColor = true;
            this._Rb_EscalaCredito.CheckedChanged += new System.EventHandler(this._Rb_EscalaCredito_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "Por escala de crédito:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "Por tipo de documento";
            // 
            // _Cb_TpoDoc
            // 
            this._Cb_TpoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoDoc.Enabled = false;
            this._Cb_TpoDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoDoc.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cb_TpoDoc.FormattingEnabled = true;
            this._Cb_TpoDoc.Location = new System.Drawing.Point(34, 90);
            this._Cb_TpoDoc.Name = "_Cb_TpoDoc";
            this._Cb_TpoDoc.Size = new System.Drawing.Size(294, 20);
            this._Cb_TpoDoc.TabIndex = 34;
            this._Cb_TpoDoc.DropDown += new System.EventHandler(this._Cb_TpoDoc_DropDown);
            // 
            // _Rb_TpoDoc
            // 
            this._Rb_TpoDoc.AutoSize = true;
            this._Rb_TpoDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Rb_TpoDoc.Location = new System.Drawing.Point(15, 93);
            this._Rb_TpoDoc.Name = "_Rb_TpoDoc";
            this._Rb_TpoDoc.Size = new System.Drawing.Size(13, 12);
            this._Rb_TpoDoc.TabIndex = 32;
            this._Rb_TpoDoc.TabStop = true;
            this._Rb_TpoDoc.UseVisualStyleBackColor = true;
            this._Rb_TpoDoc.CheckedChanged += new System.EventHandler(this._Rb_TpoDoc_CheckedChanged);
            // 
            // _Bt_Find
            // 
            this._Bt_Find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Find.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Find.Image")));
            this._Bt_Find.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Find.Location = new System.Drawing.Point(582, 157);
            this._Bt_Find.Name = "_Bt_Find";
            this._Bt_Find.Size = new System.Drawing.Size(104, 33);
            this._Bt_Find.TabIndex = 36;
            this._Bt_Find.Text = "Consultar";
            this._Bt_Find.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Find.UseVisualStyleBackColor = true;
            this._Bt_Find.Click += new System.EventHandler(this._Bt_Find_Click);
            // 
            // _Chk_Imp
            // 
            this._Chk_Imp.AutoSize = true;
            this._Chk_Imp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Chk_Imp.Location = new System.Drawing.Point(430, 163);
            this._Chk_Imp.Name = "_Chk_Imp";
            this._Chk_Imp.Size = new System.Drawing.Size(90, 16);
            this._Chk_Imp.TabIndex = 37;
            this._Chk_Imp.Text = "Con impuesto";
            this._Chk_Imp.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._Cb_ZonaVendedor);
            this.groupBox1.Controls.Add(this._Rb_Cliente);
            this.groupBox1.Controls.Add(this._Rb_Vendedor);
            this.groupBox1.Location = new System.Drawing.Point(362, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 62);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vendedor";
            // 
            // _Cb_ZonaVendedor
            // 
            this._Cb_ZonaVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_ZonaVendedor.Enabled = false;
            this._Cb_ZonaVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_ZonaVendedor.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cb_ZonaVendedor.FormattingEnabled = true;
            this._Cb_ZonaVendedor.Location = new System.Drawing.Point(13, 36);
            this._Cb_ZonaVendedor.Name = "_Cb_ZonaVendedor";
            this._Cb_ZonaVendedor.Size = new System.Drawing.Size(305, 20);
            this._Cb_ZonaVendedor.TabIndex = 26;
            this._Cb_ZonaVendedor.DropDown += new System.EventHandler(this._Cb_ZonaVendedor_DropDown);
            // 
            // _Rb_Cliente
            // 
            this._Rb_Cliente.AutoSize = true;
            this._Rb_Cliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Rb_Cliente.Location = new System.Drawing.Point(89, 17);
            this._Rb_Cliente.Name = "_Rb_Cliente";
            this._Rb_Cliente.Size = new System.Drawing.Size(58, 16);
            this._Rb_Cliente.TabIndex = 27;
            this._Rb_Cliente.TabStop = true;
            this._Rb_Cliente.Text = "Cliente";
            this._Rb_Cliente.UseVisualStyleBackColor = true;
            // 
            // _Rb_Vendedor
            // 
            this._Rb_Vendedor.AutoSize = true;
            this._Rb_Vendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Rb_Vendedor.Location = new System.Drawing.Point(13, 17);
            this._Rb_Vendedor.Name = "_Rb_Vendedor";
            this._Rb_Vendedor.Size = new System.Drawing.Size(70, 16);
            this._Rb_Vendedor.TabIndex = 0;
            this._Rb_Vendedor.TabStop = true;
            this._Rb_Vendedor.Text = "Vendedor";
            this._Rb_Vendedor.UseVisualStyleBackColor = true;
            this._Rb_Vendedor.CheckedChanged += new System.EventHandler(this._Rb_Vendedor_CheckedChanged);
            // 
            // _Rpv_Main
            // 
            this._Rpv_Main.ActiveViewIndex = -1;
            this._Rpv_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Rpv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Rpv_Main.Location = new System.Drawing.Point(0, 211);
            this._Rpv_Main.Name = "_Rpv_Main";
            this._Rpv_Main.SelectionFormula = "";
            this._Rpv_Main.ShowGroupTreeButton = false;
            this._Rpv_Main.ShowParameterPanelButton = false;
            this._Rpv_Main.Size = new System.Drawing.Size(843, 250);
            this._Rpv_Main.TabIndex = 19;
            this._Rpv_Main.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this._Rpv_Main.ViewTimeSelectionFormula = "";
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // _Sfd_1
            // 
            this._Sfd_1.Filter = "xls files (*.xls)|*.xls";
            // 
            // _Rbt_CierreMes
            // 
            this._Rbt_CierreMes.AutoSize = true;
            this._Rbt_CierreMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Rbt_CierreMes.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Rbt_CierreMes.Location = new System.Drawing.Point(12, 49);
            this._Rbt_CierreMes.Name = "_Rbt_CierreMes";
            this._Rbt_CierreMes.Size = new System.Drawing.Size(143, 16);
            this._Rbt_CierreMes.TabIndex = 84;
            this._Rbt_CierreMes.Text = "Reporte al cierre de mes";
            this._Rbt_CierreMes.UseVisualStyleBackColor = true;
            this._Rbt_CierreMes.CheckedChanged += new System.EventHandler(this._Rbt_CierreMes_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(173, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 12);
            this.label3.TabIndex = 85;
            this.label3.Text = "Mes/Año:";
            // 
            // _Cb_MesAnoCierre
            // 
            this._Cb_MesAnoCierre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_MesAnoCierre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_MesAnoCierre.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cb_MesAnoCierre.FormattingEnabled = true;
            this._Cb_MesAnoCierre.Location = new System.Drawing.Point(228, 48);
            this._Cb_MesAnoCierre.Name = "_Cb_MesAnoCierre";
            this._Cb_MesAnoCierre.Size = new System.Drawing.Size(188, 20);
            this._Cb_MesAnoCierre.TabIndex = 86;
            this._Cb_MesAnoCierre.DropDown += new System.EventHandler(this._Cb_MesAnoCierre_DropDown);
            // 
            // Frm_Inf_AnalisisSaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 461);
            this.Controls.Add(this._Rpv_Main);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Inf_AnalisisSaldo";
            this.Text = "Informe - Análisis de Saldo";
            this.Load += new System.EventHandler(this.Frm_Inf_AnalisisSaldo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton _Rb_Vendedor;
        private System.Windows.Forms.ComboBox _Cb_ZonaVendedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton _Rb_EscalaCredito;
        private System.Windows.Forms.ComboBox _Cb_EscalaCredito;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton _Rb_TpoDoc;
        private System.Windows.Forms.ComboBox _Cb_TpoDoc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox _Chk_Imp;
        private System.Windows.Forms.Button _Bt_Find;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton _Rb_SinFiltro;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer _Rpv_Main;
        private System.Windows.Forms.RadioButton _Rb_Cliente;
        private System.Windows.Forms.RadioButton _Rbt_Cierres;
        private System.Windows.Forms.RadioButton _Rbt_Actual;
        private System.Windows.Forms.Button _Bt_Caja;
        private System.Windows.Forms.TextBox _Txt_Caja;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.SaveFileDialog _Sfd_1;
        private System.Windows.Forms.Button _Bt_Exportar;
        private System.Windows.Forms.RadioButton _Rbt_CierreMes;
        private System.Windows.Forms.ComboBox _Cb_MesAnoCierre;
        private System.Windows.Forms.Label label3;
    }
}