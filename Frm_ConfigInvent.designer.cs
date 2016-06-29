namespace T3
{
    partial class Frm_ConfigInvent
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
            this._Cb_TpoMovFactVta = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this._Cb_TpoMovCpr = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this._Cb_TpoMovNotRec = new System.Windows.Forms.ComboBox();
            this._Cb_TpoMovSalAjust = new System.Windows.Forms.ComboBox();
            this._Cb_TpoMovEntAjust = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._Cb_TpoMovAnulFact = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this._Cb_TpoMovDevolCpr = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this._Cb_TpoMovDevolVta = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._Txt_Meses = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this._Cb_MotvEntAjust = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this._Cb_MotvSalAjust = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Cb_TpoMovFactVta
            // 
            this._Cb_TpoMovFactVta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoMovFactVta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoMovFactVta.FormattingEnabled = true;
            this._Cb_TpoMovFactVta.Location = new System.Drawing.Point(35, 188);
            this._Cb_TpoMovFactVta.Name = "_Cb_TpoMovFactVta";
            this._Cb_TpoMovFactVta.Size = new System.Drawing.Size(298, 20);
            this._Cb_TpoMovFactVta.TabIndex = 90;
            this._Cb_TpoMovFactVta.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoMovFactVta_SelectedIndexChanged);
            this._Cb_TpoMovFactVta.DropDown += new System.EventHandler(this._Cb_TpoMovFactVta_DropDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(34, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 12);
            this.label6.TabIndex = 89;
            this.label6.Text = "Facturacion de ventas:";
            // 
            // _Cb_TpoMovCpr
            // 
            this._Cb_TpoMovCpr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoMovCpr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoMovCpr.FormattingEnabled = true;
            this._Cb_TpoMovCpr.Location = new System.Drawing.Point(35, 150);
            this._Cb_TpoMovCpr.Name = "_Cb_TpoMovCpr";
            this._Cb_TpoMovCpr.Size = new System.Drawing.Size(298, 20);
            this._Cb_TpoMovCpr.TabIndex = 88;
            this._Cb_TpoMovCpr.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoMovCpr_SelectedIndexChanged);
            this._Cb_TpoMovCpr.DropDown += new System.EventHandler(this._Cb_TpoMovCpr_DropDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 12);
            this.label5.TabIndex = 87;
            this.label5.Text = "Compras:";
            // 
            // _Cb_TpoMovNotRec
            // 
            this._Cb_TpoMovNotRec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoMovNotRec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoMovNotRec.FormattingEnabled = true;
            this._Cb_TpoMovNotRec.Location = new System.Drawing.Point(35, 112);
            this._Cb_TpoMovNotRec.Name = "_Cb_TpoMovNotRec";
            this._Cb_TpoMovNotRec.Size = new System.Drawing.Size(298, 20);
            this._Cb_TpoMovNotRec.TabIndex = 84;
            this._Cb_TpoMovNotRec.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoMovNotRec_SelectedIndexChanged);
            this._Cb_TpoMovNotRec.DropDown += new System.EventHandler(this._Cb_TpoMovNotRec_DropDown);
            // 
            // _Cb_TpoMovSalAjust
            // 
            this._Cb_TpoMovSalAjust.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoMovSalAjust.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoMovSalAjust.FormattingEnabled = true;
            this._Cb_TpoMovSalAjust.Location = new System.Drawing.Point(35, 74);
            this._Cb_TpoMovSalAjust.Name = "_Cb_TpoMovSalAjust";
            this._Cb_TpoMovSalAjust.Size = new System.Drawing.Size(298, 20);
            this._Cb_TpoMovSalAjust.TabIndex = 83;
            this._Cb_TpoMovSalAjust.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoMovSalAjust_SelectedIndexChanged);
            this._Cb_TpoMovSalAjust.DropDown += new System.EventHandler(this._Cb_TpoMovSalAjust_DropDown);
            // 
            // _Cb_TpoMovEntAjust
            // 
            this._Cb_TpoMovEntAjust.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoMovEntAjust.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoMovEntAjust.FormattingEnabled = true;
            this._Cb_TpoMovEntAjust.Location = new System.Drawing.Point(35, 36);
            this._Cb_TpoMovEntAjust.Name = "_Cb_TpoMovEntAjust";
            this._Cb_TpoMovEntAjust.Size = new System.Drawing.Size(298, 20);
            this._Cb_TpoMovEntAjust.TabIndex = 82;
            this._Cb_TpoMovEntAjust.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoMovEntAjust_SelectedIndexChanged);
            this._Cb_TpoMovEntAjust.DropDown += new System.EventHandler(this._Cb_TpoMovEntAjust_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 69;
            this.label1.Text = "Entrada por ajustes:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 71;
            this.label4.Text = "NR:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 12);
            this.label2.TabIndex = 70;
            this.label2.Text = "Salida por ajustes:";
            // 
            // _Er_Error
            // 
            this._Er_Error.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._Er_Error.ContainerControl = this;
            // 
            // _Tb_Tab
            // 
            this._Tb_Tab.Controls.Add(this.tabPage1);
            this._Tb_Tab.Controls.Add(this.tabPage3);
            this._Tb_Tab.Controls.Add(this.tabPage2);
            this._Tb_Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Tb_Tab.Location = new System.Drawing.Point(0, 0);
            this._Tb_Tab.Name = "_Tb_Tab";
            this._Tb_Tab.SelectedIndex = 0;
            this._Tb_Tab.Size = new System.Drawing.Size(379, 371);
            this._Tb_Tab.TabIndex = 93;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._Cb_TpoMovAnulFact);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this._Cb_TpoMovDevolCpr);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this._Cb_TpoMovDevolVta);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this._Cb_TpoMovFactVta);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this._Cb_TpoMovEntAjust);
            this.tabPage1.Controls.Add(this._Cb_TpoMovCpr);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this._Cb_TpoMovSalAjust);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this._Cb_TpoMovNotRec);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(371, 346);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tipo de movimiento";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _Cb_TpoMovAnulFact
            // 
            this._Cb_TpoMovAnulFact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoMovAnulFact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoMovAnulFact.FormattingEnabled = true;
            this._Cb_TpoMovAnulFact.Location = new System.Drawing.Point(36, 306);
            this._Cb_TpoMovAnulFact.Name = "_Cb_TpoMovAnulFact";
            this._Cb_TpoMovAnulFact.Size = new System.Drawing.Size(298, 20);
            this._Cb_TpoMovAnulFact.TabIndex = 96;
            this._Cb_TpoMovAnulFact.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoMovAnulFact_SelectedIndexChanged);
            this._Cb_TpoMovAnulFact.DropDown += new System.EventHandler(this._Cb_TpoMovAnulFact_DropDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(35, 291);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 12);
            this.label9.TabIndex = 95;
            this.label9.Text = "Anulación de factura:";
            // 
            // _Cb_TpoMovDevolCpr
            // 
            this._Cb_TpoMovDevolCpr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoMovDevolCpr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoMovDevolCpr.FormattingEnabled = true;
            this._Cb_TpoMovDevolCpr.Location = new System.Drawing.Point(35, 265);
            this._Cb_TpoMovDevolCpr.Name = "_Cb_TpoMovDevolCpr";
            this._Cb_TpoMovDevolCpr.Size = new System.Drawing.Size(298, 20);
            this._Cb_TpoMovDevolCpr.TabIndex = 94;
            this._Cb_TpoMovDevolCpr.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoMovDevolCpr_SelectedIndexChanged);
            this._Cb_TpoMovDevolCpr.DropDown += new System.EventHandler(this._Cb_TpoMovDevolCpr_DropDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 12);
            this.label7.TabIndex = 93;
            this.label7.Text = "Devolución en compra:";
            // 
            // _Cb_TpoMovDevolVta
            // 
            this._Cb_TpoMovDevolVta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoMovDevolVta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoMovDevolVta.FormattingEnabled = true;
            this._Cb_TpoMovDevolVta.Location = new System.Drawing.Point(35, 226);
            this._Cb_TpoMovDevolVta.Name = "_Cb_TpoMovDevolVta";
            this._Cb_TpoMovDevolVta.Size = new System.Drawing.Size(298, 20);
            this._Cb_TpoMovDevolVta.TabIndex = 92;
            this._Cb_TpoMovDevolVta.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoMovDevolVta_SelectedIndexChanged);
            this._Cb_TpoMovDevolVta.DropDown += new System.EventHandler(this._Cb_TpoMovDevolVta_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 12);
            this.label3.TabIndex = 91;
            this.label3.Text = "Devolución en venta:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._Txt_Meses);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(371, 346);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Otros";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _Txt_Meses
            // 
            this._Txt_Meses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Meses.Location = new System.Drawing.Point(132, 25);
            this._Txt_Meses.MaxLength = 30;
            this._Txt_Meses.Name = "_Txt_Meses";
            this._Txt_Meses.Size = new System.Drawing.Size(88, 18);
            this._Txt_Meses.TabIndex = 82;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 12);
            this.label8.TabIndex = 69;
            this.label8.Text = "Meses a consultar:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this._Cb_MotvEntAjust);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this._Cb_MotvSalAjust);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(371, 346);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Motivos";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(32, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 12);
            this.label10.TabIndex = 84;
            this.label10.Text = "Entrada por ajustes:";
            // 
            // _Cb_MotvEntAjust
            // 
            this._Cb_MotvEntAjust.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_MotvEntAjust.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_MotvEntAjust.FormattingEnabled = true;
            this._Cb_MotvEntAjust.Location = new System.Drawing.Point(34, 36);
            this._Cb_MotvEntAjust.Name = "_Cb_MotvEntAjust";
            this._Cb_MotvEntAjust.Size = new System.Drawing.Size(298, 20);
            this._Cb_MotvEntAjust.TabIndex = 86;
            this._Cb_MotvEntAjust.SelectedIndexChanged += new System.EventHandler(this._Cb_MotvEntAjust_SelectedIndexChanged);
            this._Cb_MotvEntAjust.DropDown += new System.EventHandler(this._Cb_MotvEntAjust_DropDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(32, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 12);
            this.label11.TabIndex = 85;
            this.label11.Text = "Salida por ajustes:";
            // 
            // _Cb_MotvSalAjust
            // 
            this._Cb_MotvSalAjust.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_MotvSalAjust.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_MotvSalAjust.FormattingEnabled = true;
            this._Cb_MotvSalAjust.Location = new System.Drawing.Point(34, 74);
            this._Cb_MotvSalAjust.Name = "_Cb_MotvSalAjust";
            this._Cb_MotvSalAjust.Size = new System.Drawing.Size(298, 20);
            this._Cb_MotvSalAjust.TabIndex = 87;
            this._Cb_MotvSalAjust.SelectedIndexChanged += new System.EventHandler(this._Cb_MotvSalAjust_SelectedIndexChanged);
            this._Cb_MotvSalAjust.DropDown += new System.EventHandler(this._Cb_MotvSalAjust_DropDown);
            // 
            // Frm_ConfigInvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 371);
            this.Controls.Add(this._Tb_Tab);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ConfigInvent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parámetros T3 - Inventario";
            this.Activated += new System.EventHandler(this.Frm_ConfigInvent_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ConfigInvent_FormClosing);
            this.Load += new System.EventHandler(this.Frm_ConfigInvent_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox _Cb_TpoMovFactVta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox _Cb_TpoMovCpr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox _Cb_TpoMovNotRec;
        private System.Windows.Forms.ComboBox _Cb_TpoMovSalAjust;
        private System.Windows.Forms.ComboBox _Cb_TpoMovEntAjust;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox _Txt_Meses;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox _Cb_TpoMovDevolVta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _Cb_TpoMovDevolCpr;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox _Cb_TpoMovAnulFact;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox _Cb_MotvEntAjust;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox _Cb_MotvSalAjust;

    }
}