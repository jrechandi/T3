namespace T3
{
    partial class Frm_ImportNomina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ImportNomina));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this._Bt_Importar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.L_Debe = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.L_Haber = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.L_Saldo = new System.Windows.Forms.Label();
            this.FCont = new System.Windows.Forms.Label();
            this.ACont = new System.Windows.Forms.Label();
            this.MCont = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this._Bt_Importar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1101, 78);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(386, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "Fecha de Culminacion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(419, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Fecha de Inicio";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(507, 42);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 18);
            this.dateTimePicker2.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Location = new System.Drawing.Point(507, 18);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 18);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(730, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Pasar a otro formulario";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // _Bt_Importar
            // 
            this._Bt_Importar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Importar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Bt_Importar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Importar.Image")));
            this._Bt_Importar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Importar.Location = new System.Drawing.Point(218, 28);
            this._Bt_Importar.Name = "_Bt_Importar";
            this._Bt_Importar.Size = new System.Drawing.Size(152, 23);
            this._Bt_Importar.TabIndex = 2;
            this._Bt_Importar.Text = "Importar datos nomina";
            this._Bt_Importar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Importar.UseVisualStyleBackColor = true;
            this._Bt_Importar.Click += new System.EventHandler(this._Bt_Importar_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Controls.Add(this.MCont);
            this.panel2.Controls.Add(this.ACont);
            this.panel2.Controls.Add(this.FCont);
            this.panel2.Controls.Add(this.L_Saldo);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.L_Haber);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.L_Debe);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 450);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1101, 88);
            this.panel2.TabIndex = 1;
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._Dg_Grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this._Dg_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(0, 78);
            this._Dg_Grid.MultiSelect = false;
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.Size = new System.Drawing.Size(1101, 372);
            this._Dg_Grid.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(828, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Debe: ";
            // 
            // L_Debe
            // 
            this.L_Debe.AutoSize = true;
            this.L_Debe.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Debe.Location = new System.Drawing.Point(888, 9);
            this.L_Debe.Name = "L_Debe";
            this.L_Debe.Size = new System.Drawing.Size(18, 18);
            this.L_Debe.TabIndex = 10;
            this.L_Debe.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(822, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "Haber: ";
            // 
            // L_Haber
            // 
            this.L_Haber.AutoSize = true;
            this.L_Haber.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Haber.Location = new System.Drawing.Point(888, 35);
            this.L_Haber.Name = "L_Haber";
            this.L_Haber.Size = new System.Drawing.Size(18, 18);
            this.L_Haber.TabIndex = 12;
            this.L_Haber.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(825, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 18);
            this.label8.TabIndex = 13;
            this.label8.Text = "Saldo: ";
            // 
            // L_Saldo
            // 
            this.L_Saldo.AutoSize = true;
            this.L_Saldo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Saldo.Location = new System.Drawing.Point(888, 61);
            this.L_Saldo.Name = "L_Saldo";
            this.L_Saldo.Size = new System.Drawing.Size(18, 18);
            this.L_Saldo.TabIndex = 14;
            this.L_Saldo.Text = "0";
            // 
            // FCont
            // 
            this.FCont.AutoSize = true;
            this.FCont.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FCont.Location = new System.Drawing.Point(6, 9);
            this.FCont.Name = "FCont";
            this.FCont.Size = new System.Drawing.Size(219, 18);
            this.FCont.TabIndex = 15;
            this.FCont.Text = "Fecha de Contabilización:";
            // 
            // ACont
            // 
            this.ACont.AutoSize = true;
            this.ACont.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ACont.Location = new System.Drawing.Point(22, 35);
            this.ACont.Name = "ACont";
            this.ACont.Size = new System.Drawing.Size(203, 18);
            this.ACont.TabIndex = 16;
            this.ACont.Text = "Año de Contabilización:";
            // 
            // MCont
            // 
            this.MCont.AutoSize = true;
            this.MCont.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MCont.Location = new System.Drawing.Point(21, 61);
            this.MCont.Name = "MCont";
            this.MCont.Size = new System.Drawing.Size(204, 18);
            this.MCont.TabIndex = 17;
            this.MCont.Text = "Mes de Contabilización:";
            // 
            // Frm_ImportNomina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 538);
            this.Controls.Add(this._Dg_Grid);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ImportNomina";
            this.Text = "Comprobantes contables";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_ImportNomina_FormClosed);
            this.Load += new System.EventHandler(this.Frm_ImportNomina_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.Button _Bt_Importar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label L_Saldo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label L_Haber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label L_Debe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label MCont;
        private System.Windows.Forms.Label ACont;
        private System.Windows.Forms.Label FCont;

    }
}