namespace T3
{
    partial class Frm_ConfigPrinterFact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ConfigPrinterFact));
            this.label1 = new System.Windows.Forms.Label();
            this._Cb_Printers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Cb_TpoFontPaper = new System.Windows.Forms.ComboBox();
            this._Cb_SizePaper = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Impresoras:";
            // 
            // _Cb_Printers
            // 
            this._Cb_Printers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_Printers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_Printers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cb_Printers.FormattingEnabled = true;
            this._Cb_Printers.Location = new System.Drawing.Point(10, 18);
            this._Cb_Printers.Name = "_Cb_Printers";
            this._Cb_Printers.Size = new System.Drawing.Size(300, 21);
            this._Cb_Printers.TabIndex = 3;
            this._Cb_Printers.SelectedIndexChanged += new System.EventHandler(this._Cb_Printers_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tipo de fuente de papel:";
            // 
            // _Cb_TpoFontPaper
            // 
            this._Cb_TpoFontPaper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoFontPaper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoFontPaper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cb_TpoFontPaper.FormattingEnabled = true;
            this._Cb_TpoFontPaper.Location = new System.Drawing.Point(10, 57);
            this._Cb_TpoFontPaper.Name = "_Cb_TpoFontPaper";
            this._Cb_TpoFontPaper.Size = new System.Drawing.Size(300, 21);
            this._Cb_TpoFontPaper.TabIndex = 5;
            this._Cb_TpoFontPaper.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoFontPaper_SelectedIndexChanged);
            // 
            // _Cb_SizePaper
            // 
            this._Cb_SizePaper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_SizePaper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_SizePaper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cb_SizePaper.FormattingEnabled = true;
            this._Cb_SizePaper.Location = new System.Drawing.Point(10, 96);
            this._Cb_SizePaper.Name = "_Cb_SizePaper";
            this._Cb_SizePaper.Size = new System.Drawing.Size(300, 21);
            this._Cb_SizePaper.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tamaño del papel:";
            // 
            // _Er_Error
            // 
            this._Er_Error.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._Er_Error.ContainerControl = this;
            // 
            // _Tb_Tab
            // 
            this._Tb_Tab.Controls.Add(this.tabPage1);
            this._Tb_Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Tb_Tab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Tb_Tab.Location = new System.Drawing.Point(0, 0);
            this._Tb_Tab.Name = "_Tb_Tab";
            this._Tb_Tab.SelectedIndex = 0;
            this._Tb_Tab.Size = new System.Drawing.Size(329, 158);
            this._Tb_Tab.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this._Cb_SizePaper);
            this.tabPage1.Controls.Add(this._Cb_Printers);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this._Cb_TpoFontPaper);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(321, 132);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Información";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Frm_ConfigPrinterFact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 158);
            this.Controls.Add(this._Tb_Tab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ConfigPrinterFact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración de impreora (Facturación)";
            this.Load += new System.EventHandler(this.Frm_ConfigPrinterFact_Load);
            this.Activated += new System.EventHandler(this.Frm_ConfigPrinterFact_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ConfigPrinterFact_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _Cb_Printers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _Cb_TpoFontPaper;
        private System.Windows.Forms.ComboBox _Cb_SizePaper;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;

    }
}