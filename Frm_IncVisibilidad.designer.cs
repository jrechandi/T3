namespace T3
{
    partial class Frm_IncVisibilidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_IncVisibilidad));
            this._Btn_Cerrar = new System.Windows.Forms.Button();
            this._Cb_Ano = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._Btn_Generar = new System.Windows.Forms.Button();
            this._Btn_Importar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._Cb_Mes = new System.Windows.Forms.ComboBox();
            this._Cb_Ejecucion = new System.Windows.Forms.ComboBox();
            this._Sfd_Generar = new System.Windows.Forms.SaveFileDialog();
            this._Ofp_Importar = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // _Btn_Cerrar
            // 
            this._Btn_Cerrar.Location = new System.Drawing.Point(598, 203);
            this._Btn_Cerrar.Name = "_Btn_Cerrar";
            this._Btn_Cerrar.Size = new System.Drawing.Size(75, 23);
            this._Btn_Cerrar.TabIndex = 0;
            this._Btn_Cerrar.Text = "Cerrar";
            this._Btn_Cerrar.UseVisualStyleBackColor = true;
            this._Btn_Cerrar.Click += new System.EventHandler(this._Btn_Cerrar_Click);
            // 
            // _Cb_Ano
            // 
            this._Cb_Ano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_Ano.FormattingEnabled = true;
            this._Cb_Ano.Location = new System.Drawing.Point(68, 28);
            this._Cb_Ano.Name = "_Cb_Ano";
            this._Cb_Ano.Size = new System.Drawing.Size(104, 21);
            this._Cb_Ano.TabIndex = 1;
            this._Cb_Ano.SelectedIndexChanged += new System.EventHandler(this._Cb_Ano_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 55);
            this.label1.TabIndex = 2;
            this.label1.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 55);
            this.label2.TabIndex = 3;
            this.label2.Text = "2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 55);
            this.label3.TabIndex = 4;
            this.label3.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(290, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Seleccione el periodo para el cual desea ingresar los datos :";
            // 
            // _Btn_Generar
            // 
            this._Btn_Generar.Location = new System.Drawing.Point(68, 77);
            this._Btn_Generar.Name = "_Btn_Generar";
            this._Btn_Generar.Size = new System.Drawing.Size(208, 55);
            this._Btn_Generar.TabIndex = 6;
            this._Btn_Generar.Text = "Generar listado vacío";
            this._Btn_Generar.UseVisualStyleBackColor = true;
            this._Btn_Generar.Click += new System.EventHandler(this._Btn_Generar_Click);
            // 
            // _Btn_Importar
            // 
            this._Btn_Importar.Location = new System.Drawing.Point(68, 145);
            this._Btn_Importar.Name = "_Btn_Importar";
            this._Btn_Importar.Size = new System.Drawing.Size(208, 55);
            this._Btn_Importar.TabIndex = 7;
            this._Btn_Importar.Text = "Importar listado lleno";
            this._Btn_Importar.UseVisualStyleBackColor = true;
            this._Btn_Importar.Click += new System.EventHandler(this._Btn_Importar_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(282, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(391, 55);
            this.label5.TabIndex = 8;
            this.label5.Text = "El sistema generará un listado de gerentes y vendedores que hayan sido incentivad" +
                "os en el periodo seleccionado. Las comisiones estarán en cero en este listado pa" +
                "ra que usted las especifique.";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(282, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(391, 55);
            this.label6.TabIndex = 9;
            this.label6.Text = "Una vez que haya llenado el listado con las comisiones correspondientes, importe " +
                "estos datos al sistema para guardarlos.";
            // 
            // _Cb_Mes
            // 
            this._Cb_Mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_Mes.FormattingEnabled = true;
            this._Cb_Mes.Location = new System.Drawing.Point(178, 28);
            this._Cb_Mes.Name = "_Cb_Mes";
            this._Cb_Mes.Size = new System.Drawing.Size(104, 21);
            this._Cb_Mes.TabIndex = 10;
            this._Cb_Mes.SelectedIndexChanged += new System.EventHandler(this._Cb_Mes_SelectedIndexChanged);
            // 
            // _Cb_Ejecucion
            // 
            this._Cb_Ejecucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_Ejecucion.FormattingEnabled = true;
            this._Cb_Ejecucion.Location = new System.Drawing.Point(288, 28);
            this._Cb_Ejecucion.Name = "_Cb_Ejecucion";
            this._Cb_Ejecucion.Size = new System.Drawing.Size(385, 21);
            this._Cb_Ejecucion.TabIndex = 11;
            // 
            // _Sfd_Generar
            // 
            this._Sfd_Generar.DefaultExt = "xls";
            this._Sfd_Generar.Filter = "Archivos de excel (*.xls)|*.xls|Todos los archivos|*.*";
            // 
            // _Ofp_Importar
            // 
            this._Ofp_Importar.Filter = "Archivos de excel (*.xls)|*.xls|Todos los archivos|*.*";
            // 
            // Frm_IncVisibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 234);
            this.Controls.Add(this._Cb_Ejecucion);
            this.Controls.Add(this._Cb_Mes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._Btn_Importar);
            this.Controls.Add(this._Btn_Generar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._Cb_Ano);
            this.Controls.Add(this._Btn_Cerrar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_IncVisibilidad";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parámetros - Incentivo Visibilidad";
            this.Load += new System.EventHandler(this.Frm_IncVisibilidad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _Btn_Cerrar;
        private System.Windows.Forms.ComboBox _Cb_Ano;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _Btn_Generar;
        private System.Windows.Forms.Button _Btn_Importar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox _Cb_Mes;
        private System.Windows.Forms.ComboBox _Cb_Ejecucion;
        private System.Windows.Forms.SaveFileDialog _Sfd_Generar;
        private System.Windows.Forms.OpenFileDialog _Ofp_Importar;
    }
}