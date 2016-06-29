namespace T3
{
    partial class Frm_ConsolidadoIntercomp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ConsolidadoIntercomp));
            this._Btn_Consultar = new System.Windows.Forms.Button();
            this._Cmb_Estatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._Cmb_CompaniaRelacionadaCons = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this._Cmb_TipoConsulta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this._Txt_TotalSeleccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._Txt_TotalSaldo = new System.Windows.Forms.TextBox();
            this._Txt_TotalPagar = new System.Windows.Forms.TextBox();
            this._Txt_TotalCobrar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._Dtg_Principal = new System.Windows.Forms.DataGridView();
            this._Mnu_Contextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._Mnu_Seleccionar = new System.Windows.Forms.ToolStripMenuItem();
            this._Mnu_Deseleccionar = new System.Windows.Forms.ToolStripMenuItem();
            this._Mnu_GenerarOrdenPago = new System.Windows.Forms.ToolStripMenuItem();
            this._Mnu_RegistrarCobranza = new System.Windows.Forms.ToolStripMenuItem();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dtg_Principal)).BeginInit();
            this._Mnu_Contextual.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Btn_Consultar
            // 
            this._Btn_Consultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Btn_Consultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Btn_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("_Btn_Consultar.Image")));
            this._Btn_Consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Btn_Consultar.Location = new System.Drawing.Point(907, 30);
            this._Btn_Consultar.Name = "_Btn_Consultar";
            this._Btn_Consultar.Size = new System.Drawing.Size(109, 28);
            this._Btn_Consultar.TabIndex = 50;
            this._Btn_Consultar.Text = "Consultar";
            this._Btn_Consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Btn_Consultar.UseVisualStyleBackColor = true;
            this._Btn_Consultar.Click += new System.EventHandler(this._Btn_Consultar_Click);
            // 
            // _Cmb_Estatus
            // 
            this._Cmb_Estatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Estatus.FormattingEnabled = true;
            this._Cmb_Estatus.Location = new System.Drawing.Point(702, 33);
            this._Cmb_Estatus.Name = "_Cmb_Estatus";
            this._Cmb_Estatus.Size = new System.Drawing.Size(186, 21);
            this._Cmb_Estatus.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(700, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "Estado:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(352, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "Compañia relacionada:";
            // 
            // _Cmb_CompaniaRelacionadaCons
            // 
            this._Cmb_CompaniaRelacionadaCons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_CompaniaRelacionadaCons.FormattingEnabled = true;
            this._Cmb_CompaniaRelacionadaCons.Location = new System.Drawing.Point(354, 33);
            this._Cmb_CompaniaRelacionadaCons.Name = "_Cmb_CompaniaRelacionadaCons";
            this._Cmb_CompaniaRelacionadaCons.Size = new System.Drawing.Size(336, 21);
            this._Cmb_CompaniaRelacionadaCons.TabIndex = 0;
            this._Cmb_CompaniaRelacionadaCons.DropDown += new System.EventHandler(this._Cmb_CompaniaRelacionadaCons_DropDown);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._Cmb_TipoConsulta);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this._Btn_Consultar);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this._Cmb_Estatus);
            this.panel3.Controls.Add(this._Cmb_CompaniaRelacionadaCons);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1042, 73);
            this.panel3.TabIndex = 11;
            // 
            // _Cmb_TipoConsulta
            // 
            this._Cmb_TipoConsulta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_TipoConsulta.FormattingEnabled = true;
            this._Cmb_TipoConsulta.Location = new System.Drawing.Point(12, 33);
            this._Cmb_TipoConsulta.Name = "_Cmb_TipoConsulta";
            this._Cmb_TipoConsulta.Size = new System.Drawing.Size(336, 21);
            this._Cmb_TipoConsulta.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 52;
            this.label1.Text = "Tipo consulta:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this._Txt_TotalSeleccion);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this._Txt_TotalSaldo);
            this.panel4.Controls.Add(this._Txt_TotalPagar);
            this.panel4.Controls.Add(this._Txt_TotalCobrar);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Enabled = false;
            this.panel4.Location = new System.Drawing.Point(0, 283);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1042, 70);
            this.panel4.TabIndex = 12;
            // 
            // _Txt_TotalSeleccion
            // 
            this._Txt_TotalSeleccion.Location = new System.Drawing.Point(501, 36);
            this._Txt_TotalSeleccion.Name = "_Txt_TotalSeleccion";
            this._Txt_TotalSeleccion.Size = new System.Drawing.Size(129, 20);
            this._Txt_TotalSeleccion.TabIndex = 64;
            this._Txt_TotalSeleccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(499, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 12);
            this.label5.TabIndex = 63;
            this.label5.Text = "Saldo selección :";
            // 
            // _Txt_TotalSaldo
            // 
            this._Txt_TotalSaldo.Location = new System.Drawing.Point(345, 35);
            this._Txt_TotalSaldo.Name = "_Txt_TotalSaldo";
            this._Txt_TotalSaldo.Size = new System.Drawing.Size(129, 20);
            this._Txt_TotalSaldo.TabIndex = 62;
            this._Txt_TotalSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _Txt_TotalPagar
            // 
            this._Txt_TotalPagar.Location = new System.Drawing.Point(179, 36);
            this._Txt_TotalPagar.Name = "_Txt_TotalPagar";
            this._Txt_TotalPagar.Size = new System.Drawing.Size(129, 20);
            this._Txt_TotalPagar.TabIndex = 61;
            this._Txt_TotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _Txt_TotalCobrar
            // 
            this._Txt_TotalCobrar.Location = new System.Drawing.Point(19, 36);
            this._Txt_TotalCobrar.Name = "_Txt_TotalCobrar";
            this._Txt_TotalCobrar.Size = new System.Drawing.Size(129, 20);
            this._Txt_TotalCobrar.TabIndex = 60;
            this._Txt_TotalCobrar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(343, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 12);
            this.label4.TabIndex = 59;
            this.label4.Text = "Saldo total :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(177, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 12);
            this.label3.TabIndex = 58;
            this.label3.Text = "Total por pagar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 12);
            this.label2.TabIndex = 57;
            this.label2.Text = "Total por cobrar:";
            // 
            // _Dtg_Principal
            // 
            this._Dtg_Principal.AllowUserToAddRows = false;
            this._Dtg_Principal.AllowUserToDeleteRows = false;
            this._Dtg_Principal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dtg_Principal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dtg_Principal.ContextMenuStrip = this._Mnu_Contextual;
            this._Dtg_Principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dtg_Principal.Location = new System.Drawing.Point(0, 73);
            this._Dtg_Principal.Name = "_Dtg_Principal";
            this._Dtg_Principal.ReadOnly = true;
            this._Dtg_Principal.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dtg_Principal.Size = new System.Drawing.Size(1042, 197);
            this._Dtg_Principal.TabIndex = 32;
            this._Dtg_Principal.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dtg_Principal_CellMouseEnter);
            this._Dtg_Principal.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dtg_Principal_ColumnHeaderMouseClick);
            // 
            // _Mnu_Contextual
            // 
            this._Mnu_Contextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._Mnu_Seleccionar,
            this._Mnu_Deseleccionar,
            this._Mnu_GenerarOrdenPago,
            this._Mnu_RegistrarCobranza});
            this._Mnu_Contextual.Name = "_Cntx_Menu";
            this._Mnu_Contextual.Size = new System.Drawing.Size(205, 92);
            // 
            // _Mnu_Seleccionar
            // 
            this._Mnu_Seleccionar.Name = "_Mnu_Seleccionar";
            this._Mnu_Seleccionar.Size = new System.Drawing.Size(204, 22);
            this._Mnu_Seleccionar.Text = "Seleccionar";
            this._Mnu_Seleccionar.Click += new System.EventHandler(this._Mnu_Seleccionar_Click);
            // 
            // _Mnu_Deseleccionar
            // 
            this._Mnu_Deseleccionar.Name = "_Mnu_Deseleccionar";
            this._Mnu_Deseleccionar.Size = new System.Drawing.Size(204, 22);
            this._Mnu_Deseleccionar.Text = "Deseleccionar";
            this._Mnu_Deseleccionar.Click += new System.EventHandler(this._Mnu_Deseleccionar_Click);
            // 
            // _Mnu_GenerarOrdenPago
            // 
            this._Mnu_GenerarOrdenPago.Name = "_Mnu_GenerarOrdenPago";
            this._Mnu_GenerarOrdenPago.Size = new System.Drawing.Size(204, 22);
            this._Mnu_GenerarOrdenPago.Text = "Generar orden de pago...";
            this._Mnu_GenerarOrdenPago.Click += new System.EventHandler(this._Mnu_GenerarOrdenPago_Click);
            // 
            // _Mnu_RegistrarCobranza
            // 
            this._Mnu_RegistrarCobranza.Name = "_Mnu_RegistrarCobranza";
            this._Mnu_RegistrarCobranza.Size = new System.Drawing.Size(204, 22);
            this._Mnu_RegistrarCobranza.Text = "Registrar cobranza...";
            this._Mnu_RegistrarCobranza.Click += new System.EventHandler(this._Mnu_RegistrarCobranza_Click);
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Font = new System.Drawing.Font("Verdana", 6.75F);
            this._Lbl_DgInfo.Location = new System.Drawing.Point(0, 270);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(1042, 13);
            this._Lbl_DgInfo.TabIndex = 34;
            this._Lbl_DgInfo.Text = "Haga clic con el botón derecho para seleccionar y/o procesar documentos.";
            this._Lbl_DgInfo.Visible = false;
            // 
            // Frm_ConsolidadoIntercomp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 353);
            this.Controls.Add(this._Dtg_Principal);
            this.Controls.Add(this._Lbl_DgInfo);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_ConsolidadoIntercomp";
            this.Text = "Consolidado intercompañía";
            this.Activated += new System.EventHandler(this.Frm_ConsolidadoIntercomp_Activated);
            this.Load += new System.EventHandler(this.Frm_ConsolidadoIntercomp_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dtg_Principal)).EndInit();
            this._Mnu_Contextual.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _Btn_Consultar;
        private System.Windows.Forms.ComboBox _Cmb_Estatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox _Cmb_CompaniaRelacionadaCons;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox _Txt_TotalSaldo;
        private System.Windows.Forms.TextBox _Txt_TotalPagar;
        private System.Windows.Forms.TextBox _Txt_TotalCobrar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView _Dtg_Principal;
        private System.Windows.Forms.ComboBox _Cmb_TipoConsulta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _Txt_TotalSeleccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip _Mnu_Contextual;
        private System.Windows.Forms.ToolStripMenuItem _Mnu_Seleccionar;
        private System.Windows.Forms.ToolStripMenuItem _Mnu_Deseleccionar;
        private System.Windows.Forms.ToolStripMenuItem _Mnu_GenerarOrdenPago;
        private System.Windows.Forms.ToolStripMenuItem _Mnu_RegistrarCobranza;
        private System.Windows.Forms.Label _Lbl_DgInfo;

    }
}