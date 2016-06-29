namespace T3
{
    partial class Frm_InicializacionConciliacion
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
            this.dpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.btSeleccionar = new System.Windows.Forms.Button();
            this.btInicializar = new System.Windows.Forms.Button();
            this.dlgAbrir = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // dpFechaFinal
            // 
            this.dpFechaFinal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaFinal.Location = new System.Drawing.Point(111, 21);
            this.dpFechaFinal.Name = "dpFechaFinal";
            this.dpFechaFinal.Size = new System.Drawing.Size(99, 21);
            this.dpFechaFinal.TabIndex = 0;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(20, 25);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(83, 13);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha final:";
            // 
            // btSeleccionar
            // 
            this.btSeleccionar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSeleccionar.Location = new System.Drawing.Point(19, 66);
            this.btSeleccionar.Name = "btSeleccionar";
            this.btSeleccionar.Size = new System.Drawing.Size(194, 31);
            this.btSeleccionar.TabIndex = 2;
            this.btSeleccionar.Text = "Seleccionar Excel";
            this.btSeleccionar.UseVisualStyleBackColor = true;
            this.btSeleccionar.Click += new System.EventHandler(this.btSeleccionar_Click);
            // 
            // btInicializar
            // 
            this.btInicializar.Enabled = false;
            this.btInicializar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInicializar.Location = new System.Drawing.Point(19, 113);
            this.btInicializar.Name = "btInicializar";
            this.btInicializar.Size = new System.Drawing.Size(194, 31);
            this.btInicializar.TabIndex = 3;
            this.btInicializar.Text = "Pulsa aquí para cargar";
            this.btInicializar.UseVisualStyleBackColor = true;
            this.btInicializar.Click += new System.EventHandler(this.btInicializar_Click);
            // 
            // Frm_InicializacionConciliacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 159);
            this.Controls.Add(this.btInicializar);
            this.Controls.Add(this.btSeleccionar);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dpFechaFinal);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_InicializacionConciliacion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conciliación";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dpFechaFinal;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Button btSeleccionar;
        private System.Windows.Forms.Button btInicializar;
        private System.Windows.Forms.OpenFileDialog dlgAbrir;
    }
}