namespace T3
{
    partial class Frm_Inf_RelacPorCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Inf_RelacPorCaja));
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this._Bt_Caja = new System.Windows.Forms.Button();
            this._Txt_Caja = new System.Windows.Forms.TextBox();
            this._Bt_Consultar = new System.Windows.Forms.Button();
            this.DataSetRpt = new T3.DataSetRpt();
            this.VST_RELACIONES_POR_CAJABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._Rpt_Report = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetRpt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VST_RELACIONES_POR_CAJABindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this._Bt_Caja);
            this.panel1.Controls.Add(this._Txt_Caja);
            this.panel1.Controls.Add(this._Bt_Consultar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(891, 44);
            this.panel1.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 12);
            this.label5.TabIndex = 124;
            this.label5.Text = "Caja:";
            // 
            // _Bt_Caja
            // 
            this._Bt_Caja.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Caja.Image")));
            this._Bt_Caja.Location = new System.Drawing.Point(173, 13);
            this._Bt_Caja.Name = "_Bt_Caja";
            this._Bt_Caja.Size = new System.Drawing.Size(26, 18);
            this._Bt_Caja.TabIndex = 66;
            this._Bt_Caja.Text = "...";
            this._Bt_Caja.UseVisualStyleBackColor = true;
            this._Bt_Caja.Click += new System.EventHandler(this._Bt_Caja_Click);
            // 
            // _Txt_Caja
            // 
            this._Txt_Caja.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._Txt_Caja.Enabled = false;
            this._Txt_Caja.Location = new System.Drawing.Point(45, 12);
            this._Txt_Caja.Name = "_Txt_Caja";
            this._Txt_Caja.ReadOnly = true;
            this._Txt_Caja.Size = new System.Drawing.Size(122, 20);
            this._Txt_Caja.TabIndex = 65;
            // 
            // _Bt_Consultar
            // 
            this._Bt_Consultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Consultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Consultar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Consultar.Image")));
            this._Bt_Consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Consultar.Location = new System.Drawing.Point(215, 7);
            this._Bt_Consultar.Name = "_Bt_Consultar";
            this._Bt_Consultar.Size = new System.Drawing.Size(117, 29);
            this._Bt_Consultar.TabIndex = 63;
            this._Bt_Consultar.Text = "Consultar";
            this._Bt_Consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Consultar.UseVisualStyleBackColor = true;
            this._Bt_Consultar.Click += new System.EventHandler(this._Bt_Consultar_Click);
            // 
            // DataSetRpt
            // 
            this.DataSetRpt.DataSetName = "DataSetRpt";
            this.DataSetRpt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VST_RELACIONES_POR_CAJABindingSource
            // 
            this.VST_RELACIONES_POR_CAJABindingSource.DataMember = "VST_RELACIONES_POR_CAJA";
            this.VST_RELACIONES_POR_CAJABindingSource.DataSource = this.DataSetRpt;
            // 
            // _Rpt_Report
            // 
            this._Rpt_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Rpt_Report.Location = new System.Drawing.Point(0, 44);
            this._Rpt_Report.Name = "_Rpt_Report";
            this._Rpt_Report.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this._Rpt_Report.Size = new System.Drawing.Size(891, 489);
            this._Rpt_Report.TabIndex = 7;
            // 
            // Frm_Inf_RelacPorCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 533);
            this.Controls.Add(this._Rpt_Report);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Inf_RelacPorCaja";
            this.Text = "Informe - Relaciones por Caja";
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetRpt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VST_RELACIONES_POR_CAJABindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button _Bt_Caja;
        private System.Windows.Forms.TextBox _Txt_Caja;
        private System.Windows.Forms.Button _Bt_Consultar;
        private System.Windows.Forms.BindingSource VST_RELACIONES_POR_CAJABindingSource;
        private DataSetRpt DataSetRpt;
        private Microsoft.Reporting.WinForms.ReportViewer _Rpt_Report;
    }
}