namespace T3
{
    partial class Frm_ConfigBanco
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
            this.panel3 = new System.Windows.Forms.Panel();
            this._Cb_TpoOperND = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this._Cb_TpoOperDep = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Cb_TpoDocDep = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Cb_TpoOperEmiCheq = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._Cb_TpoOperND);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this._Cb_TpoOperDep);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this._Cb_TpoDocDep);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this._Cb_TpoOperEmiCheq);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(498, 125);
            this.panel3.TabIndex = 0;
            // 
            // _Cb_TpoOperND
            // 
            this._Cb_TpoOperND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoOperND.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoOperND.FormattingEnabled = true;
            this._Cb_TpoOperND.Location = new System.Drawing.Point(217, 62);
            this._Cb_TpoOperND.Name = "_Cb_TpoOperND";
            this._Cb_TpoOperND.Size = new System.Drawing.Size(258, 20);
            this._Cb_TpoOperND.TabIndex = 2;
            this._Cb_TpoOperND.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoOperND_SelectedIndexChanged);
            this._Cb_TpoOperND.DropDown += new System.EventHandler(this._Cb_TpoOperND_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tipo de operación para nota de debito:";
            // 
            // _Cb_TpoOperDep
            // 
            this._Cb_TpoOperDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoOperDep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoOperDep.FormattingEnabled = true;
            this._Cb_TpoOperDep.Location = new System.Drawing.Point(217, 37);
            this._Cb_TpoOperDep.Name = "_Cb_TpoOperDep";
            this._Cb_TpoOperDep.Size = new System.Drawing.Size(258, 20);
            this._Cb_TpoOperDep.TabIndex = 1;
            this._Cb_TpoOperDep.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoOperDep_SelectedIndexChanged);
            this._Cb_TpoOperDep.DropDown += new System.EventHandler(this._Cb_TpoOperDep_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tipo de operación Deposito:";
            // 
            // _Cb_TpoDocDep
            // 
            this._Cb_TpoDocDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoDocDep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoDocDep.FormattingEnabled = true;
            this._Cb_TpoDocDep.Location = new System.Drawing.Point(217, 12);
            this._Cb_TpoDocDep.Name = "_Cb_TpoDocDep";
            this._Cb_TpoDocDep.Size = new System.Drawing.Size(258, 20);
            this._Cb_TpoDocDep.TabIndex = 0;
            this._Cb_TpoDocDep.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoDocDep_SelectedIndexChanged);
            this._Cb_TpoDocDep.DropDown += new System.EventHandler(this._Cb_TpoDocDep_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tipo de documento Deposito:";
            // 
            // _Cb_TpoOperEmiCheq
            // 
            this._Cb_TpoOperEmiCheq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoOperEmiCheq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoOperEmiCheq.FormattingEnabled = true;
            this._Cb_TpoOperEmiCheq.Location = new System.Drawing.Point(278, 87);
            this._Cb_TpoOperEmiCheq.Name = "_Cb_TpoOperEmiCheq";
            this._Cb_TpoOperEmiCheq.Size = new System.Drawing.Size(197, 20);
            this._Cb_TpoOperEmiCheq.TabIndex = 3;
            this._Cb_TpoOperEmiCheq.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoOperEmiCheq_SelectedIndexChanged);
            this._Cb_TpoOperEmiCheq.DropDown += new System.EventHandler(this._Cb_TpoOperEmiCheq_DropDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(254, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "Tipo de operación bancaria por emisión de cheque:";
            // 
            // _Er_Error
            // 
            this._Er_Error.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._Er_Error.ContainerControl = this;
            // 
            // Frm_ConfigBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 125);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ConfigBanco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración de banco";
            this.Activated += new System.EventHandler(this.Frm_ConfigBanco_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ConfigBanco_FormClosing);
            this.Load += new System.EventHandler(this.Frm_ConfigBanco_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox _Cb_TpoOperEmiCheq;
        private System.Windows.Forms.ComboBox _Cb_TpoOperND;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _Cb_TpoOperDep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _Cb_TpoDocDep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider _Er_Error;
    }
}