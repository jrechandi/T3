namespace T3
{
    partial class Frm_VistaArchivo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Grb_LineaInicioDatos = new System.Windows.Forms.GroupBox();
            this._Txt_LineaInicioDatos = new System.Windows.Forms.TextBox();
            this._Grb_CaracteresSeparadores = new System.Windows.Forms.GroupBox();
            this._Rb_Otro = new System.Windows.Forms.RadioButton();
            this._Rb_Espacio = new System.Windows.Forms.RadioButton();
            this._Rb_PuntoYComa = new System.Windows.Forms.RadioButton();
            this._Rb_Coma = new System.Windows.Forms.RadioButton();
            this._Rb_Tabulacion = new System.Windows.Forms.RadioButton();
            this._Txt_Otro = new System.Windows.Forms.TextBox();
            this._Grb_TpoDeSeparacion = new System.Windows.Forms.GroupBox();
            this._Rb_PorUsuario = new System.Windows.Forms.RadioButton();
            this._Rb_Caracteres = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this._Txt_Archivo = new System.Windows.Forms.TextBox();
            this._RTxt_Vista = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this._Bt_Cancelar = new System.Windows.Forms.Button();
            this._Bt_Aceptar = new System.Windows.Forms.Button();
            this._Bt_Ini = new System.Windows.Forms.Button();
            this._Dg_Carga = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this._Grb_LineaInicioDatos.SuspendLayout();
            this._Grb_CaracteresSeparadores.SuspendLayout();
            this._Grb_TpoDeSeparacion.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Carga)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Grb_LineaInicioDatos);
            this.panel1.Controls.Add(this._Grb_CaracteresSeparadores);
            this.panel1.Controls.Add(this._Grb_TpoDeSeparacion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._Txt_Archivo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(693, 117);
            this.panel1.TabIndex = 0;
            // 
            // _Grb_LineaInicioDatos
            // 
            this._Grb_LineaInicioDatos.Controls.Add(this._Txt_LineaInicioDatos);
            this._Grb_LineaInicioDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Grb_LineaInicioDatos.Location = new System.Drawing.Point(492, 40);
            this._Grb_LineaInicioDatos.Name = "_Grb_LineaInicioDatos";
            this._Grb_LineaInicioDatos.Size = new System.Drawing.Size(189, 71);
            this._Grb_LineaInicioDatos.TabIndex = 21;
            this._Grb_LineaInicioDatos.TabStop = false;
            this._Grb_LineaInicioDatos.Text = "Línea Inicio de Datos";
            // 
            // _Txt_LineaInicioDatos
            // 
            this._Txt_LineaInicioDatos.Location = new System.Drawing.Point(15, 20);
            this._Txt_LineaInicioDatos.Name = "_Txt_LineaInicioDatos";
            this._Txt_LineaInicioDatos.Size = new System.Drawing.Size(113, 20);
            this._Txt_LineaInicioDatos.TabIndex = 6;
            this._Txt_LineaInicioDatos.TextChanged += new System.EventHandler(this._Txt_LineaInicioDatos_TextChanged);
            this._Txt_LineaInicioDatos.Enter += new System.EventHandler(this._Txt_LineaInicioDatos_Enter);
            this._Txt_LineaInicioDatos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_LineaInicioDatos_KeyPress);
            // 
            // _Grb_CaracteresSeparadores
            // 
            this._Grb_CaracteresSeparadores.Controls.Add(this._Rb_Otro);
            this._Grb_CaracteresSeparadores.Controls.Add(this._Rb_Espacio);
            this._Grb_CaracteresSeparadores.Controls.Add(this._Rb_PuntoYComa);
            this._Grb_CaracteresSeparadores.Controls.Add(this._Rb_Coma);
            this._Grb_CaracteresSeparadores.Controls.Add(this._Rb_Tabulacion);
            this._Grb_CaracteresSeparadores.Controls.Add(this._Txt_Otro);
            this._Grb_CaracteresSeparadores.Enabled = false;
            this._Grb_CaracteresSeparadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Grb_CaracteresSeparadores.Location = new System.Drawing.Point(210, 40);
            this._Grb_CaracteresSeparadores.Name = "_Grb_CaracteresSeparadores";
            this._Grb_CaracteresSeparadores.Size = new System.Drawing.Size(273, 71);
            this._Grb_CaracteresSeparadores.TabIndex = 20;
            this._Grb_CaracteresSeparadores.TabStop = false;
            this._Grb_CaracteresSeparadores.Text = "Caracteres Separadores";
            // 
            // _Rb_Otro
            // 
            this._Rb_Otro.AutoSize = true;
            this._Rb_Otro.Location = new System.Drawing.Point(208, 19);
            this._Rb_Otro.Name = "_Rb_Otro";
            this._Rb_Otro.Size = new System.Drawing.Size(49, 17);
            this._Rb_Otro.TabIndex = 10;
            this._Rb_Otro.TabStop = true;
            this._Rb_Otro.Text = "Otro";
            this._Rb_Otro.UseVisualStyleBackColor = true;
            this._Rb_Otro.CheckedChanged += new System.EventHandler(this._Rb_Otro_CheckedChanged);
            // 
            // _Rb_Espacio
            // 
            this._Rb_Espacio.AutoSize = true;
            this._Rb_Espacio.Location = new System.Drawing.Point(100, 42);
            this._Rb_Espacio.Name = "_Rb_Espacio";
            this._Rb_Espacio.Size = new System.Drawing.Size(70, 17);
            this._Rb_Espacio.TabIndex = 9;
            this._Rb_Espacio.TabStop = true;
            this._Rb_Espacio.Text = "Espacio";
            this._Rb_Espacio.UseVisualStyleBackColor = true;
            this._Rb_Espacio.CheckedChanged += new System.EventHandler(this._Rb_Espacio_CheckedChanged);
            // 
            // _Rb_PuntoYComa
            // 
            this._Rb_PuntoYComa.AutoSize = true;
            this._Rb_PuntoYComa.Location = new System.Drawing.Point(100, 19);
            this._Rb_PuntoYComa.Name = "_Rb_PuntoYComa";
            this._Rb_PuntoYComa.Size = new System.Drawing.Size(102, 17);
            this._Rb_PuntoYComa.TabIndex = 8;
            this._Rb_PuntoYComa.TabStop = true;
            this._Rb_PuntoYComa.Text = "Punto y coma";
            this._Rb_PuntoYComa.UseVisualStyleBackColor = true;
            this._Rb_PuntoYComa.CheckedChanged += new System.EventHandler(this._Rb_Punto_CheckedChanged);
            // 
            // _Rb_Coma
            // 
            this._Rb_Coma.AutoSize = true;
            this._Rb_Coma.Location = new System.Drawing.Point(6, 42);
            this._Rb_Coma.Name = "_Rb_Coma";
            this._Rb_Coma.Size = new System.Drawing.Size(56, 17);
            this._Rb_Coma.TabIndex = 7;
            this._Rb_Coma.TabStop = true;
            this._Rb_Coma.Text = "Coma";
            this._Rb_Coma.UseVisualStyleBackColor = true;
            this._Rb_Coma.CheckedChanged += new System.EventHandler(this._Rb_Coma_CheckedChanged);
            // 
            // _Rb_Tabulacion
            // 
            this._Rb_Tabulacion.AutoSize = true;
            this._Rb_Tabulacion.Location = new System.Drawing.Point(6, 19);
            this._Rb_Tabulacion.Name = "_Rb_Tabulacion";
            this._Rb_Tabulacion.Size = new System.Drawing.Size(88, 17);
            this._Rb_Tabulacion.TabIndex = 6;
            this._Rb_Tabulacion.TabStop = true;
            this._Rb_Tabulacion.Text = "Tabulación";
            this._Rb_Tabulacion.UseVisualStyleBackColor = true;
            this._Rb_Tabulacion.CheckedChanged += new System.EventHandler(this._Rb_Tabulacion_CheckedChanged);
            // 
            // _Txt_Otro
            // 
            this._Txt_Otro.Enabled = false;
            this._Txt_Otro.Location = new System.Drawing.Point(208, 39);
            this._Txt_Otro.Name = "_Txt_Otro";
            this._Txt_Otro.Size = new System.Drawing.Size(50, 20);
            this._Txt_Otro.TabIndex = 5;
            this._Txt_Otro.TextChanged += new System.EventHandler(this._Txt_Otro_TextChanged);
            // 
            // _Grb_TpoDeSeparacion
            // 
            this._Grb_TpoDeSeparacion.Controls.Add(this._Rb_PorUsuario);
            this._Grb_TpoDeSeparacion.Controls.Add(this._Rb_Caracteres);
            this._Grb_TpoDeSeparacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Grb_TpoDeSeparacion.Location = new System.Drawing.Point(3, 41);
            this._Grb_TpoDeSeparacion.Name = "_Grb_TpoDeSeparacion";
            this._Grb_TpoDeSeparacion.Size = new System.Drawing.Size(201, 71);
            this._Grb_TpoDeSeparacion.TabIndex = 19;
            this._Grb_TpoDeSeparacion.TabStop = false;
            this._Grb_TpoDeSeparacion.Text = "Tipo de Separación";
            // 
            // _Rb_PorUsuario
            // 
            this._Rb_PorUsuario.AutoSize = true;
            this._Rb_PorUsuario.Enabled = false;
            this._Rb_PorUsuario.Location = new System.Drawing.Point(17, 42);
            this._Rb_PorUsuario.Name = "_Rb_PorUsuario";
            this._Rb_PorUsuario.Size = new System.Drawing.Size(167, 17);
            this._Rb_PorUsuario.TabIndex = 1;
            this._Rb_PorUsuario.TabStop = true;
            this._Rb_PorUsuario.Text = "Delimitado por el Usuario";
            this._Rb_PorUsuario.UseVisualStyleBackColor = true;
            this._Rb_PorUsuario.CheckedChanged += new System.EventHandler(this._Rb_Usuario_CheckedChanged);
            // 
            // _Rb_Caracteres
            // 
            this._Rb_Caracteres.AutoSize = true;
            this._Rb_Caracteres.Location = new System.Drawing.Point(17, 19);
            this._Rb_Caracteres.Name = "_Rb_Caracteres";
            this._Rb_Caracteres.Size = new System.Drawing.Size(170, 17);
            this._Rb_Caracteres.TabIndex = 0;
            this._Rb_Caracteres.TabStop = true;
            this._Rb_Caracteres.Text = "Delimitado por caracteres";
            this._Rb_Caracteres.UseVisualStyleBackColor = true;
            this._Rb_Caracteres.CheckedChanged += new System.EventHandler(this._Rb_Caracteres_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Archivo:";
            // 
            // _Txt_Archivo
            // 
            this._Txt_Archivo.Location = new System.Drawing.Point(72, 6);
            this._Txt_Archivo.Name = "_Txt_Archivo";
            this._Txt_Archivo.ReadOnly = true;
            this._Txt_Archivo.Size = new System.Drawing.Size(638, 20);
            this._Txt_Archivo.TabIndex = 17;
            // 
            // _RTxt_Vista
            // 
            this._RTxt_Vista.BackColor = System.Drawing.SystemColors.Window;
            this._RTxt_Vista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._RTxt_Vista.Cursor = System.Windows.Forms.Cursors.Default;
            this._RTxt_Vista.Dock = System.Windows.Forms.DockStyle.Top;
            this._RTxt_Vista.Enabled = false;
            this._RTxt_Vista.Location = new System.Drawing.Point(0, 117);
            this._RTxt_Vista.Name = "_RTxt_Vista";
            this._RTxt_Vista.ReadOnly = true;
            this._RTxt_Vista.Size = new System.Drawing.Size(693, 10);
            this._RTxt_Vista.TabIndex = 12;
            this._RTxt_Vista.Text = "";
            this._RTxt_Vista.MouseClick += new System.Windows.Forms.MouseEventHandler(this._RTxt_Vista_MouseClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._Bt_Cancelar);
            this.panel2.Controls.Add(this._Bt_Aceptar);
            this.panel2.Controls.Add(this._Bt_Ini);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 466);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(693, 32);
            this.panel2.TabIndex = 13;
            // 
            // _Bt_Cancelar
            // 
            this._Bt_Cancelar.Location = new System.Drawing.Point(615, 3);
            this._Bt_Cancelar.Name = "_Bt_Cancelar";
            this._Bt_Cancelar.Size = new System.Drawing.Size(75, 23);
            this._Bt_Cancelar.TabIndex = 23;
            this._Bt_Cancelar.Text = "Cancelar";
            this._Bt_Cancelar.UseVisualStyleBackColor = true;
            this._Bt_Cancelar.Click += new System.EventHandler(this._Bt_Cancelar_Click);
            // 
            // _Bt_Aceptar
            // 
            this._Bt_Aceptar.Enabled = false;
            this._Bt_Aceptar.Location = new System.Drawing.Point(534, 3);
            this._Bt_Aceptar.Name = "_Bt_Aceptar";
            this._Bt_Aceptar.Size = new System.Drawing.Size(75, 23);
            this._Bt_Aceptar.TabIndex = 22;
            this._Bt_Aceptar.Text = "Aceptar";
            this._Bt_Aceptar.UseVisualStyleBackColor = true;
            this._Bt_Aceptar.Click += new System.EventHandler(this._Bt_Aceptar_Click);
            // 
            // _Bt_Ini
            // 
            this._Bt_Ini.Location = new System.Drawing.Point(453, 3);
            this._Bt_Ini.Name = "_Bt_Ini";
            this._Bt_Ini.Size = new System.Drawing.Size(75, 23);
            this._Bt_Ini.TabIndex = 21;
            this._Bt_Ini.Text = "Inicializar";
            this._Bt_Ini.UseVisualStyleBackColor = true;
            this._Bt_Ini.Click += new System.EventHandler(this._Bt_Ini_Click);
            // 
            // _Dg_Carga
            // 
            this._Dg_Carga.AllowUserToAddRows = false;
            this._Dg_Carga.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._Dg_Carga.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._Dg_Carga.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Carga.Location = new System.Drawing.Point(0, 137);
            this._Dg_Carga.Name = "_Dg_Carga";
            this._Dg_Carga.ReadOnly = true;
            this._Dg_Carga.Size = new System.Drawing.Size(693, 329);
            this._Dg_Carga.TabIndex = 14;
            this._Dg_Carga.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this._Dg_Carga_ColumnAdded);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 127);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(693, 10);
            this.panel3.TabIndex = 15;
            // 
            // Frm_VistaArchivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 498);
            this.Controls.Add(this._Dg_Carga);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this._RTxt_Vista);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_VistaArchivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_VistaArchivo";
            this.Load += new System.EventHandler(this.Frm_VistaArchivo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._Grb_LineaInicioDatos.ResumeLayout(false);
            this._Grb_LineaInicioDatos.PerformLayout();
            this._Grb_CaracteresSeparadores.ResumeLayout(false);
            this._Grb_CaracteresSeparadores.PerformLayout();
            this._Grb_TpoDeSeparacion.ResumeLayout(false);
            this._Grb_TpoDeSeparacion.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Carga)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _Txt_Archivo;
        private System.Windows.Forms.GroupBox _Grb_TpoDeSeparacion;
        public System.Windows.Forms.RadioButton _Rb_PorUsuario;
        public System.Windows.Forms.RadioButton _Rb_Caracteres;
        private System.Windows.Forms.GroupBox _Grb_CaracteresSeparadores;
        public System.Windows.Forms.TextBox _Txt_Otro;
        private System.Windows.Forms.RichTextBox _RTxt_Vista;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView _Dg_Carga;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.RadioButton _Rb_Tabulacion;
        public System.Windows.Forms.RadioButton _Rb_Coma;
        public System.Windows.Forms.RadioButton _Rb_Espacio;
        public System.Windows.Forms.RadioButton _Rb_PuntoYComa;
        public System.Windows.Forms.RadioButton _Rb_Otro;
        private System.Windows.Forms.Button _Bt_Cancelar;
        private System.Windows.Forms.Button _Bt_Aceptar;
        private System.Windows.Forms.Button _Bt_Ini;
        private System.Windows.Forms.GroupBox _Grb_LineaInicioDatos;
        public System.Windows.Forms.TextBox _Txt_LineaInicioDatos;
    }
}