namespace T3
{
    partial class Frm_Estratificacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Estratificacion));
            this._Dtp_FechHasta = new System.Windows.Forms.DateTimePicker();
            this._Dtp_FechDesde = new System.Windows.Forms.DateTimePicker();
            this._Lbl_Hasta = new System.Windows.Forms.Label();
            this._Lbl_Desde = new System.Windows.Forms.Label();
            this._Bt_Generar = new System.Windows.Forms.Button();
            this._Pgr_Progreso = new System.Windows.Forms.ProgressBar();
            this._Lbl_Espere = new System.Windows.Forms.Label();
            this._Bak_GroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // _Dtp_FechHasta
            // 
            this._Dtp_FechHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dtp_FechHasta.Location = new System.Drawing.Point(123, 24);
            this._Dtp_FechHasta.Name = "_Dtp_FechHasta";
            this._Dtp_FechHasta.Size = new System.Drawing.Size(95, 18);
            this._Dtp_FechHasta.TabIndex = 8;
            // 
            // _Dtp_FechDesde
            // 
            this._Dtp_FechDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dtp_FechDesde.Location = new System.Drawing.Point(23, 24);
            this._Dtp_FechDesde.Name = "_Dtp_FechDesde";
            this._Dtp_FechDesde.Size = new System.Drawing.Size(95, 18);
            this._Dtp_FechDesde.TabIndex = 7;
            this._Dtp_FechDesde.ValueChanged += new System.EventHandler(this._Dtp_FechDesde_ValueChanged);
            // 
            // _Lbl_Hasta
            // 
            this._Lbl_Hasta.AutoSize = true;
            this._Lbl_Hasta.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_Hasta.Location = new System.Drawing.Point(121, 9);
            this._Lbl_Hasta.Name = "_Lbl_Hasta";
            this._Lbl_Hasta.Size = new System.Drawing.Size(34, 12);
            this._Lbl_Hasta.TabIndex = 57;
            this._Lbl_Hasta.Text = "Hasta";
            // 
            // _Lbl_Desde
            // 
            this._Lbl_Desde.AutoSize = true;
            this._Lbl_Desde.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_Desde.Location = new System.Drawing.Point(21, 9);
            this._Lbl_Desde.Name = "_Lbl_Desde";
            this._Lbl_Desde.Size = new System.Drawing.Size(35, 12);
            this._Lbl_Desde.TabIndex = 56;
            this._Lbl_Desde.Text = "Desde";
            // 
            // _Bt_Generar
            // 
            this._Bt_Generar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Bt_Generar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Generar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Generar.Image")));
            this._Bt_Generar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Generar.Location = new System.Drawing.Point(224, 17);
            this._Bt_Generar.Name = "_Bt_Generar";
            this._Bt_Generar.Size = new System.Drawing.Size(92, 30);
            this._Bt_Generar.TabIndex = 56;
            this._Bt_Generar.Text = "Procesar";
            this._Bt_Generar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Generar.UseVisualStyleBackColor = true;
            this._Bt_Generar.Click += new System.EventHandler(this._Bt_Generar_Click);
            // 
            // _Pgr_Progreso
            // 
            this._Pgr_Progreso.Location = new System.Drawing.Point(121, 49);
            this._Pgr_Progreso.Margin = new System.Windows.Forms.Padding(4);
            this._Pgr_Progreso.Name = "_Pgr_Progreso";
            this._Pgr_Progreso.Size = new System.Drawing.Size(195, 20);
            this._Pgr_Progreso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this._Pgr_Progreso.TabIndex = 59;
            this._Pgr_Progreso.Visible = false;
            // 
            // _Lbl_Espere
            // 
            this._Lbl_Espere.AutoSize = true;
            this._Lbl_Espere.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_Espere.Location = new System.Drawing.Point(20, 51);
            this._Lbl_Espere.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._Lbl_Espere.Name = "_Lbl_Espere";
            this._Lbl_Espere.Size = new System.Drawing.Size(89, 14);
            this._Lbl_Espere.TabIndex = 60;
            this._Lbl_Espere.Text = "Espere por favor";
            this._Lbl_Espere.Visible = false;
            // 
            // _Bak_GroundWorker
            // 
            this._Bak_GroundWorker.WorkerReportsProgress = true;
            this._Bak_GroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this._Bak_GroundWorker_DoWork);
            this._Bak_GroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._Bak_GroundWorker_RunWorkerCompleted);
            // 
            // Frm_Estratificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 73);
            this.Controls.Add(this._Lbl_Espere);
            this.Controls.Add(this._Pgr_Progreso);
            this.Controls.Add(this._Dtp_FechHasta);
            this.Controls.Add(this._Dtp_FechDesde);
            this.Controls.Add(this._Lbl_Hasta);
            this.Controls.Add(this._Lbl_Desde);
            this.Controls.Add(this._Bt_Generar);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_Estratificacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estratificación";
            this.Load += new System.EventHandler(this.Frm_Estratificacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker _Dtp_FechHasta;
        private System.Windows.Forms.DateTimePicker _Dtp_FechDesde;
        private System.Windows.Forms.Label _Lbl_Hasta;
        private System.Windows.Forms.Label _Lbl_Desde;
        private System.Windows.Forms.Button _Bt_Generar;
        private System.Windows.Forms.ProgressBar _Pgr_Progreso;
        private System.Windows.Forms.Label _Lbl_Espere;
        private System.ComponentModel.BackgroundWorker _Bak_GroundWorker;
    }
}