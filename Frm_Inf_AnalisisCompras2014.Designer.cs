namespace T3
{
    partial class Frm_Inf_NotaRecepcionDetallado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Inf_NotaRecepcionDetallado));
            this._Rpt_VisorReportes = new Microsoft.Reporting.WinForms.ReportViewer();
            this._Ctrl_Multifiltro = new T3.Controles._Ctrl_Multifiltro2014();
            this._Pnl_Pie = new System.Windows.Forms.Panel();
            this._Bt_Generar = new System.Windows.Forms.Button();
            this._Pnl_Barra = new System.Windows.Forms.Panel();
            this._Img_Logo = new System.Windows.Forms.PictureBox();
            this._Btn_FiltrarPor = new System.Windows.Forms.Button();
            this._Pnl_Pie.SuspendLayout();
            this._Pnl_Barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Img_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // _Rpt_VisorReportes
            // 
            this._Rpt_VisorReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Rpt_VisorReportes.DocumentMapCollapsed = true;
            this._Rpt_VisorReportes.Location = new System.Drawing.Point(0, 39);
            this._Rpt_VisorReportes.Name = "_Rpt_VisorReportes";
            this._Rpt_VisorReportes.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this._Rpt_VisorReportes.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this._Rpt_VisorReportes.ShowParameterPrompts = false;
            this._Rpt_VisorReportes.Size = new System.Drawing.Size(1087, 408);
            this._Rpt_VisorReportes.TabIndex = 168;
            // 
            // _Ctrl_Multifiltro
            // 
            this._Ctrl_Multifiltro.BackColor = System.Drawing.Color.Transparent;
            this._Ctrl_Multifiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Ctrl_Multifiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Ctrl_Multifiltro.Location = new System.Drawing.Point(196, 78);
            this._Ctrl_Multifiltro.Name = "_Ctrl_Multifiltro";
            this._Ctrl_Multifiltro.Size = new System.Drawing.Size(698, 343);
            this._Ctrl_Multifiltro.TabIndex = 170;
            this._Ctrl_Multifiltro.Visible = false;
            this._Ctrl_Multifiltro.FiltroSeleccionado += new T3.Controles.DelegadoDespuesSeleccionar(this._Ctrl_Multifiltro_FiltroSeleccionado);
            this._Ctrl_Multifiltro.BotonConsultarClick += new T3.Controles.DelegadoEjecutada(this._Ctrl_Multifiltro_BotonConsultarClick);
            this._Ctrl_Multifiltro.Validando += new T3.Controles.DelegadoValidar(this._Ctrl_Multifiltro_Validando);
            this._Ctrl_Multifiltro.Cerrando += new T3.Controles.DelegadoCerrar(this._Ctrl_Multifiltro_Cerrando);
            // 
            // _Pnl_Pie
            // 
            this._Pnl_Pie.Controls.Add(this._Bt_Generar);
            this._Pnl_Pie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Pnl_Pie.Location = new System.Drawing.Point(0, 447);
            this._Pnl_Pie.Name = "_Pnl_Pie";
            this._Pnl_Pie.Size = new System.Drawing.Size(1087, 42);
            this._Pnl_Pie.TabIndex = 171;
            // 
            // _Bt_Generar
            // 
            this._Bt_Generar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Generar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Bt_Generar.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Generar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Generar.Image")));
            this._Bt_Generar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Generar.Location = new System.Drawing.Point(803, 9);
            this._Bt_Generar.Name = "_Bt_Generar";
            this._Bt_Generar.Size = new System.Drawing.Size(274, 26);
            this._Bt_Generar.TabIndex = 173;
            this._Bt_Generar.Text = "      Solicitar P. O. C. (Pre-Orden de Compra)";
            this._Bt_Generar.UseVisualStyleBackColor = true;
            // 
            // _Pnl_Barra
            // 
            this._Pnl_Barra.BackColor = System.Drawing.SystemColors.Control;
            this._Pnl_Barra.Controls.Add(this._Img_Logo);
            this._Pnl_Barra.Controls.Add(this._Btn_FiltrarPor);
            this._Pnl_Barra.Dock = System.Windows.Forms.DockStyle.Top;
            this._Pnl_Barra.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Pnl_Barra.Location = new System.Drawing.Point(0, 0);
            this._Pnl_Barra.Name = "_Pnl_Barra";
            this._Pnl_Barra.Size = new System.Drawing.Size(1087, 39);
            this._Pnl_Barra.TabIndex = 174;
            // 
            // _Img_Logo
            // 
            this._Img_Logo.Image = ((System.Drawing.Image)(resources.GetObject("_Img_Logo.Image")));
            this._Img_Logo.Location = new System.Drawing.Point(1044, 5);
            this._Img_Logo.Name = "_Img_Logo";
            this._Img_Logo.Size = new System.Drawing.Size(32, 29);
            this._Img_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._Img_Logo.TabIndex = 171;
            this._Img_Logo.TabStop = false;
            // 
            // _Btn_FiltrarPor
            // 
            this._Btn_FiltrarPor.FlatAppearance.BorderSize = 0;
            this._Btn_FiltrarPor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Btn_FiltrarPor.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Btn_FiltrarPor.Image = global::T3.Properties.Resources.filter;
            this._Btn_FiltrarPor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Btn_FiltrarPor.Location = new System.Drawing.Point(7, 7);
            this._Btn_FiltrarPor.Name = "_Btn_FiltrarPor";
            this._Btn_FiltrarPor.Size = new System.Drawing.Size(93, 25);
            this._Btn_FiltrarPor.TabIndex = 0;
            this._Btn_FiltrarPor.Text = "     Filtrar por";
            this._Btn_FiltrarPor.UseVisualStyleBackColor = true;
            this._Btn_FiltrarPor.Click += new System.EventHandler(this._Btn_FiltrarPor_Click);
            // 
            // Frm_Inf_NotaRecepcionDetallado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 489);
            this.Controls.Add(this._Ctrl_Multifiltro);
            this.Controls.Add(this._Rpt_VisorReportes);
            this.Controls.Add(this._Pnl_Barra);
            this.Controls.Add(this._Pnl_Pie);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Inf_NotaRecepcionDetallado";
            this.Text = "Informe - Análisis de compra actual";
            this.Resize += new System.EventHandler(this.Frm_ConsultaMultipleCompras_Resize);
            this._Pnl_Pie.ResumeLayout(false);
            this._Pnl_Barra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Img_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer _Rpt_VisorReportes;
        private Controles._Ctrl_Multifiltro2014 _Ctrl_Multifiltro;
        private System.Windows.Forms.Panel _Pnl_Pie;
        private System.Windows.Forms.Button _Bt_Generar;
        private System.Windows.Forms.Panel _Pnl_Barra;
        private System.Windows.Forms.PictureBox _Img_Logo;
        private System.Windows.Forms.Button _Btn_FiltrarPor;
    }
}