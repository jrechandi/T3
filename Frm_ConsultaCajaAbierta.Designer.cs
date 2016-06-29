namespace T3
{
    partial class Frm_ConsultaCajaAbierta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ConsultaCajaAbierta));
            this._Pnl_InfGen = new System.Windows.Forms.Panel();
            this._Txt_Fecha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Txt_Caja = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Pnl_Inferior = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this._Bt_CobDetallada = new System.Windows.Forms.Button();
            this._Btn_CajaCerrar = new System.Windows.Forms.Button();
            this._Pnl_Clave = new System.Windows.Forms.Panel();
            this._Bt_Aceptar_Clave = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this._Txt_Clave = new System.Windows.Forms.TextBox();
            this._Bt_Cancelar_Clave = new System.Windows.Forms.Button();
            this._Lbl_TituloClave = new System.Windows.Forms.Label();
            this._CRptV_A = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this._Pnl_Pregunta = new System.Windows.Forms.Panel();
            this._Rb_Ver = new System.Windows.Forms.RadioButton();
            this._Rb_Cerrar = new System.Windows.Forms.RadioButton();
            this._Bt_AceptarP = new System.Windows.Forms.Button();
            this._Bt_Salir = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this._Pnl_InfGen.SuspendLayout();
            this._Pnl_Inferior.SuspendLayout();
            this.panel3.SuspendLayout();
            this._Pnl_Clave.SuspendLayout();
            this._Pnl_Pregunta.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Pnl_InfGen
            // 
            this._Pnl_InfGen.Controls.Add(this._Txt_Fecha);
            this._Pnl_InfGen.Controls.Add(this.label2);
            this._Pnl_InfGen.Controls.Add(this._Txt_Caja);
            this._Pnl_InfGen.Controls.Add(this.label1);
            this._Pnl_InfGen.Dock = System.Windows.Forms.DockStyle.Top;
            this._Pnl_InfGen.Location = new System.Drawing.Point(0, 0);
            this._Pnl_InfGen.Name = "_Pnl_InfGen";
            this._Pnl_InfGen.Size = new System.Drawing.Size(719, 49);
            this._Pnl_InfGen.TabIndex = 0;
            // 
            // _Txt_Fecha
            // 
            this._Txt_Fecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Fecha.Location = new System.Drawing.Point(86, 24);
            this._Txt_Fecha.Name = "_Txt_Fecha";
            this._Txt_Fecha.Size = new System.Drawing.Size(83, 18);
            this._Txt_Fecha.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha:";
            // 
            // _Txt_Caja
            // 
            this._Txt_Caja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Caja.Location = new System.Drawing.Point(14, 24);
            this._Txt_Caja.Name = "_Txt_Caja";
            this._Txt_Caja.Size = new System.Drawing.Size(66, 18);
            this._Txt_Caja.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Caja #:";
            // 
            // _Pnl_Inferior
            // 
            this._Pnl_Inferior.Controls.Add(this.panel3);
            this._Pnl_Inferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Pnl_Inferior.Location = new System.Drawing.Point(0, 480);
            this._Pnl_Inferior.Name = "_Pnl_Inferior";
            this._Pnl_Inferior.Size = new System.Drawing.Size(719, 40);
            this._Pnl_Inferior.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._Bt_CobDetallada);
            this.panel3.Controls.Add(this._Btn_CajaCerrar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(470, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(249, 40);
            this.panel3.TabIndex = 0;
            // 
            // _Bt_CobDetallada
            // 
            this._Bt_CobDetallada.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_CobDetallada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_CobDetallada.Location = new System.Drawing.Point(14, 3);
            this._Bt_CobDetallada.Name = "_Bt_CobDetallada";
            this._Bt_CobDetallada.Size = new System.Drawing.Size(136, 33);
            this._Bt_CobDetallada.TabIndex = 3;
            this._Bt_CobDetallada.Text = "Ver Cobranza Detallada";
            this._Bt_CobDetallada.UseVisualStyleBackColor = true;
            this._Bt_CobDetallada.Click += new System.EventHandler(this._Bt_CobDetallada_Click);
            // 
            // _Btn_CajaCerrar
            // 
            this._Btn_CajaCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Btn_CajaCerrar.Enabled = false;
            this._Btn_CajaCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Btn_CajaCerrar.Location = new System.Drawing.Point(156, 3);
            this._Btn_CajaCerrar.Name = "_Btn_CajaCerrar";
            this._Btn_CajaCerrar.Size = new System.Drawing.Size(82, 33);
            this._Btn_CajaCerrar.TabIndex = 2;
            this._Btn_CajaCerrar.Text = "Cerrar caja";
            this._Btn_CajaCerrar.UseVisualStyleBackColor = true;
            this._Btn_CajaCerrar.Click += new System.EventHandler(this._Btn_CajaCerrar_Click);
            // 
            // _Pnl_Clave
            // 
            this._Pnl_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Clave.Controls.Add(this._Bt_Aceptar_Clave);
            this._Pnl_Clave.Controls.Add(this.label21);
            this._Pnl_Clave.Controls.Add(this._Txt_Clave);
            this._Pnl_Clave.Controls.Add(this._Bt_Cancelar_Clave);
            this._Pnl_Clave.Controls.Add(this._Lbl_TituloClave);
            this._Pnl_Clave.Location = new System.Drawing.Point(286, 216);
            this._Pnl_Clave.Name = "_Pnl_Clave";
            this._Pnl_Clave.Size = new System.Drawing.Size(154, 88);
            this._Pnl_Clave.TabIndex = 83;
            this._Pnl_Clave.Visible = false;
            this._Pnl_Clave.VisibleChanged += new System.EventHandler(this._Pnl_Clave_VisibleChanged);
            // 
            // _Bt_Aceptar_Clave
            // 
            this._Bt_Aceptar_Clave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Aceptar_Clave.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Aceptar_Clave.Location = new System.Drawing.Point(21, 60);
            this._Bt_Aceptar_Clave.Name = "_Bt_Aceptar_Clave";
            this._Bt_Aceptar_Clave.Size = new System.Drawing.Size(54, 20);
            this._Bt_Aceptar_Clave.TabIndex = 70;
            this._Bt_Aceptar_Clave.Text = "Aceptar";
            this._Bt_Aceptar_Clave.UseVisualStyleBackColor = true;
            this._Bt_Aceptar_Clave.Click += new System.EventHandler(this._Bt_Aceptar_Clave_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 37);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(38, 12);
            this.label21.TabIndex = 68;
            this.label21.Text = "Clave:";
            // 
            // _Txt_Clave
            // 
            this._Txt_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Clave.Location = new System.Drawing.Point(50, 34);
            this._Txt_Clave.Name = "_Txt_Clave";
            this._Txt_Clave.PasswordChar = '*';
            this._Txt_Clave.Size = new System.Drawing.Size(95, 18);
            this._Txt_Clave.TabIndex = 2;
            // 
            // _Bt_Cancelar_Clave
            // 
            this._Bt_Cancelar_Clave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Cancelar_Clave.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Cancelar_Clave.Location = new System.Drawing.Point(79, 60);
            this._Bt_Cancelar_Clave.Name = "_Bt_Cancelar_Clave";
            this._Bt_Cancelar_Clave.Size = new System.Drawing.Size(54, 20);
            this._Bt_Cancelar_Clave.TabIndex = 1;
            this._Bt_Cancelar_Clave.Text = "Cancelar";
            this._Bt_Cancelar_Clave.UseVisualStyleBackColor = true;
            this._Bt_Cancelar_Clave.Click += new System.EventHandler(this._Bt_Cancelar_Clave_Click);
            // 
            // _Lbl_TituloClave
            // 
            this._Lbl_TituloClave.BackColor = System.Drawing.Color.Navy;
            this._Lbl_TituloClave.Dock = System.Windows.Forms.DockStyle.Top;
            this._Lbl_TituloClave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._Lbl_TituloClave.Location = new System.Drawing.Point(0, 0);
            this._Lbl_TituloClave.Name = "_Lbl_TituloClave";
            this._Lbl_TituloClave.Size = new System.Drawing.Size(152, 19);
            this._Lbl_TituloClave.TabIndex = 0;
            this._Lbl_TituloClave.Text = "Introduzca Clave";
            this._Lbl_TituloClave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _CRptV_A
            // 
            this._CRptV_A.ActiveViewIndex = -1;
            this._CRptV_A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._CRptV_A.Dock = System.Windows.Forms.DockStyle.Fill;
            this._CRptV_A.Location = new System.Drawing.Point(0, 49);
            this._CRptV_A.Name = "_CRptV_A";
            this._CRptV_A.SelectionFormula = "";
            this._CRptV_A.Size = new System.Drawing.Size(719, 431);
            this._CRptV_A.TabIndex = 84;
            this._CRptV_A.ViewTimeSelectionFormula = "";
            // 
            // _Pnl_Pregunta
            // 
            this._Pnl_Pregunta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Pregunta.Controls.Add(this._Rb_Ver);
            this._Pnl_Pregunta.Controls.Add(this._Rb_Cerrar);
            this._Pnl_Pregunta.Controls.Add(this._Bt_AceptarP);
            this._Pnl_Pregunta.Controls.Add(this._Bt_Salir);
            this._Pnl_Pregunta.Controls.Add(this.label4);
            this._Pnl_Pregunta.Location = new System.Drawing.Point(286, 216);
            this._Pnl_Pregunta.Name = "_Pnl_Pregunta";
            this._Pnl_Pregunta.Size = new System.Drawing.Size(154, 88);
            this._Pnl_Pregunta.TabIndex = 85;
            this._Pnl_Pregunta.Visible = false;
            this._Pnl_Pregunta.VisibleChanged += new System.EventHandler(this._Pnl_Pregunta_VisibleChanged);
            // 
            // _Rb_Ver
            // 
            this._Rb_Ver.AutoSize = true;
            this._Rb_Ver.Location = new System.Drawing.Point(9, 38);
            this._Rb_Ver.Name = "_Rb_Ver";
            this._Rb_Ver.Size = new System.Drawing.Size(115, 16);
            this._Rb_Ver.TabIndex = 72;
            this._Rb_Ver.TabStop = true;
            this._Rb_Ver.Text = "Visualizar Reporte";
            this._Rb_Ver.UseVisualStyleBackColor = true;
            this._Rb_Ver.CheckedChanged += new System.EventHandler(this._Rb_Ver_CheckedChanged);
            // 
            // _Rb_Cerrar
            // 
            this._Rb_Cerrar.AutoSize = true;
            this._Rb_Cerrar.Location = new System.Drawing.Point(9, 22);
            this._Rb_Cerrar.Name = "_Rb_Cerrar";
            this._Rb_Cerrar.Size = new System.Drawing.Size(81, 16);
            this._Rb_Cerrar.TabIndex = 71;
            this._Rb_Cerrar.TabStop = true;
            this._Rb_Cerrar.Text = "Cerrar Caja";
            this._Rb_Cerrar.UseVisualStyleBackColor = true;
            this._Rb_Cerrar.CheckedChanged += new System.EventHandler(this._Rb_Cerrar_CheckedChanged);
            // 
            // _Bt_AceptarP
            // 
            this._Bt_AceptarP.Enabled = false;
            this._Bt_AceptarP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_AceptarP.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_AceptarP.Location = new System.Drawing.Point(21, 60);
            this._Bt_AceptarP.Name = "_Bt_AceptarP";
            this._Bt_AceptarP.Size = new System.Drawing.Size(54, 20);
            this._Bt_AceptarP.TabIndex = 70;
            this._Bt_AceptarP.Text = "Aceptar";
            this._Bt_AceptarP.UseVisualStyleBackColor = true;
            this._Bt_AceptarP.Click += new System.EventHandler(this._Bt_AceptarP_Click);
            // 
            // _Bt_Salir
            // 
            this._Bt_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Salir.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Salir.Location = new System.Drawing.Point(79, 60);
            this._Bt_Salir.Name = "_Bt_Salir";
            this._Bt_Salir.Size = new System.Drawing.Size(54, 20);
            this._Bt_Salir.TabIndex = 1;
            this._Bt_Salir.Text = "Salir";
            this._Bt_Salir.UseVisualStyleBackColor = true;
            this._Bt_Salir.Click += new System.EventHandler(this._Bt_Salir_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Navy;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "¿Que desea hacer?";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_ConsultaCajaAbierta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 520);
            this.Controls.Add(this._Pnl_Pregunta);
            this.Controls.Add(this._Pnl_Clave);
            this.Controls.Add(this._CRptV_A);
            this.Controls.Add(this._Pnl_Inferior);
            this.Controls.Add(this._Pnl_InfGen);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ConsultaCajaAbierta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caja Abierta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ConsultaCajaAbierta_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_ConsultaCajaAbierta_FormClosed);
            this.Load += new System.EventHandler(this.Frm_ConsultaCajaAbierta_Load);
            this._Pnl_InfGen.ResumeLayout(false);
            this._Pnl_InfGen.PerformLayout();
            this._Pnl_Inferior.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this._Pnl_Clave.ResumeLayout(false);
            this._Pnl_Clave.PerformLayout();
            this._Pnl_Pregunta.ResumeLayout(false);
            this._Pnl_Pregunta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _Pnl_InfGen;
        private System.Windows.Forms.TextBox _Txt_Fecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _Txt_Caja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel _Pnl_Inferior;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button _Btn_CajaCerrar;
        private System.Windows.Forms.Panel _Pnl_Clave;
        private System.Windows.Forms.Button _Bt_Aceptar_Clave;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox _Txt_Clave;
        private System.Windows.Forms.Button _Bt_Cancelar_Clave;
        private System.Windows.Forms.Label _Lbl_TituloClave;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer _CRptV_A;
        private System.Windows.Forms.Button _Bt_CobDetallada;
        private System.Windows.Forms.Panel _Pnl_Pregunta;
        private System.Windows.Forms.Button _Bt_AceptarP;
        private System.Windows.Forms.Button _Bt_Salir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton _Rb_Ver;
        private System.Windows.Forms.RadioButton _Rb_Cerrar;
    }
}