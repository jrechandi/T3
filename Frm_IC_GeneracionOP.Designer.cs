namespace T3
{
    partial class Frm_IC_GeneracionOP
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this._Gru_Proveedor = new System.Windows.Forms.GroupBox();
            this._Lbl_Proveedor = new System.Windows.Forms.Label();
            this._Lbl_MontoTotal = new System.Windows.Forms.Label();
            this._Lbl_TituloMontoTotal = new System.Windows.Forms.Label();
            this._Lbl_TituloFormaPago = new System.Windows.Forms.Label();
            this._Chk_Cheque = new System.Windows.Forms.RadioButton();
            this._Chk_Transferencia = new System.Windows.Forms.RadioButton();
            this._Lbl_Banco = new System.Windows.Forms.Label();
            this._Lbl_Cuenta = new System.Windows.Forms.Label();
            this._Cmb_Banco = new System.Windows.Forms.ComboBox();
            this._Cmb_Cuenta = new System.Windows.Forms.ComboBox();
            this._Gru_Documento = new System.Windows.Forms.GroupBox();
            this._Btn_Agregar = new System.Windows.Forms.Button();
            this._Dtg_Documentos = new System.Windows.Forms.DataGridView();
            this._Mnu_Opciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._Mnu_Eliminar = new System.Windows.Forms.ToolStripMenuItem();
            this._Gru_VistaPrevia = new System.Windows.Forms.GroupBox();
            this._Btn_Visualizar = new System.Windows.Forms.Button();
            this._Dtg_Comprobante = new System.Windows.Forms.DataGridView();
            this._Btn_Generar = new System.Windows.Forms.Button();
            this._Btn_Cancelar = new System.Windows.Forms.Button();
            this._Gru_Proveedor.SuspendLayout();
            this._Gru_Documento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dtg_Documentos)).BeginInit();
            this._Mnu_Opciones.SuspendLayout();
            this._Gru_VistaPrevia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dtg_Comprobante)).BeginInit();
            this.SuspendLayout();
            // 
            // _Gru_Proveedor
            // 
            this._Gru_Proveedor.Controls.Add(this._Lbl_Proveedor);
            this._Gru_Proveedor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Gru_Proveedor.Location = new System.Drawing.Point(10, 12);
            this._Gru_Proveedor.Name = "_Gru_Proveedor";
            this._Gru_Proveedor.Size = new System.Drawing.Size(427, 57);
            this._Gru_Proveedor.TabIndex = 0;
            this._Gru_Proveedor.TabStop = false;
            this._Gru_Proveedor.Text = "Proveedor";
            // 
            // _Lbl_Proveedor
            // 
            this._Lbl_Proveedor.AutoSize = true;
            this._Lbl_Proveedor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_Proveedor.Location = new System.Drawing.Point(19, 24);
            this._Lbl_Proveedor.Name = "_Lbl_Proveedor";
            this._Lbl_Proveedor.Size = new System.Drawing.Size(130, 15);
            this._Lbl_Proveedor.TabIndex = 3;
            this._Lbl_Proveedor.Text = "Nombre del proveedor";
            // 
            // _Lbl_MontoTotal
            // 
            this._Lbl_MontoTotal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_MontoTotal.Location = new System.Drawing.Point(270, 98);
            this._Lbl_MontoTotal.Name = "_Lbl_MontoTotal";
            this._Lbl_MontoTotal.Size = new System.Drawing.Size(167, 17);
            this._Lbl_MontoTotal.TabIndex = 1;
            this._Lbl_MontoTotal.Text = "Bsf. 0";
            this._Lbl_MontoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _Lbl_TituloMontoTotal
            // 
            this._Lbl_TituloMontoTotal.AutoSize = true;
            this._Lbl_TituloMontoTotal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_TituloMontoTotal.Location = new System.Drawing.Point(22, 74);
            this._Lbl_TituloMontoTotal.Name = "_Lbl_TituloMontoTotal";
            this._Lbl_TituloMontoTotal.Size = new System.Drawing.Size(157, 15);
            this._Lbl_TituloMontoTotal.TabIndex = 2;
            this._Lbl_TituloMontoTotal.Text = "Monto total orden de pago:";
            // 
            // _Lbl_TituloFormaPago
            // 
            this._Lbl_TituloFormaPago.AutoSize = true;
            this._Lbl_TituloFormaPago.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_TituloFormaPago.Location = new System.Drawing.Point(490, 74);
            this._Lbl_TituloFormaPago.Name = "_Lbl_TituloFormaPago";
            this._Lbl_TituloFormaPago.Size = new System.Drawing.Size(94, 15);
            this._Lbl_TituloFormaPago.TabIndex = 3;
            this._Lbl_TituloFormaPago.Text = "Forma de pago:";
            // 
            // _Chk_Cheque
            // 
            this._Chk_Cheque.AutoSize = true;
            this._Chk_Cheque.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Chk_Cheque.Location = new System.Drawing.Point(493, 97);
            this._Chk_Cheque.Name = "_Chk_Cheque";
            this._Chk_Cheque.Size = new System.Drawing.Size(69, 19);
            this._Chk_Cheque.TabIndex = 4;
            this._Chk_Cheque.TabStop = true;
            this._Chk_Cheque.Text = "Cheque";
            this._Chk_Cheque.UseVisualStyleBackColor = true;
            // 
            // _Chk_Transferencia
            // 
            this._Chk_Transferencia.AutoSize = true;
            this._Chk_Transferencia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Chk_Transferencia.Location = new System.Drawing.Point(600, 97);
            this._Chk_Transferencia.Name = "_Chk_Transferencia";
            this._Chk_Transferencia.Size = new System.Drawing.Size(101, 19);
            this._Chk_Transferencia.TabIndex = 5;
            this._Chk_Transferencia.TabStop = true;
            this._Chk_Transferencia.Text = "Transferencia";
            this._Chk_Transferencia.UseVisualStyleBackColor = true;
            // 
            // _Lbl_Banco
            // 
            this._Lbl_Banco.AutoSize = true;
            this._Lbl_Banco.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_Banco.Location = new System.Drawing.Point(756, 12);
            this._Lbl_Banco.Name = "_Lbl_Banco";
            this._Lbl_Banco.Size = new System.Drawing.Size(46, 15);
            this._Lbl_Banco.TabIndex = 6;
            this._Lbl_Banco.Text = "Banco:";
            // 
            // _Lbl_Cuenta
            // 
            this._Lbl_Cuenta.AutoSize = true;
            this._Lbl_Cuenta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_Cuenta.Location = new System.Drawing.Point(757, 74);
            this._Lbl_Cuenta.Name = "_Lbl_Cuenta";
            this._Lbl_Cuenta.Size = new System.Drawing.Size(50, 15);
            this._Lbl_Cuenta.TabIndex = 7;
            this._Lbl_Cuenta.Text = "Cuenta:";
            // 
            // _Cmb_Banco
            // 
            this._Cmb_Banco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Banco.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Banco.FormattingEnabled = true;
            this._Cmb_Banco.Location = new System.Drawing.Point(759, 34);
            this._Cmb_Banco.Name = "_Cmb_Banco";
            this._Cmb_Banco.Size = new System.Drawing.Size(259, 23);
            this._Cmb_Banco.TabIndex = 8;
            this._Cmb_Banco.SelectedIndexChanged += new System.EventHandler(this._Cmb_Banco_SelectedIndexChanged);
            // 
            // _Cmb_Cuenta
            // 
            this._Cmb_Cuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Cuenta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Cuenta.FormattingEnabled = true;
            this._Cmb_Cuenta.Location = new System.Drawing.Point(758, 96);
            this._Cmb_Cuenta.Name = "_Cmb_Cuenta";
            this._Cmb_Cuenta.Size = new System.Drawing.Size(259, 23);
            this._Cmb_Cuenta.TabIndex = 9;
            this._Cmb_Cuenta.SelectedIndexChanged += new System.EventHandler(this._Cmb_Cuenta_SelectedIndexChanged);
            // 
            // _Gru_Documento
            // 
            this._Gru_Documento.Controls.Add(this._Btn_Agregar);
            this._Gru_Documento.Controls.Add(this._Dtg_Documentos);
            this._Gru_Documento.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Gru_Documento.Location = new System.Drawing.Point(7, 131);
            this._Gru_Documento.Name = "_Gru_Documento";
            this._Gru_Documento.Size = new System.Drawing.Size(1026, 222);
            this._Gru_Documento.TabIndex = 10;
            this._Gru_Documento.TabStop = false;
            this._Gru_Documento.Text = "Documentos a cancelar";
            // 
            // _Btn_Agregar
            // 
            this._Btn_Agregar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Btn_Agregar.Image = global::T3.Properties.Resources.plus;
            this._Btn_Agregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Btn_Agregar.Location = new System.Drawing.Point(772, 18);
            this._Btn_Agregar.Name = "_Btn_Agregar";
            this._Btn_Agregar.Size = new System.Drawing.Size(238, 30);
            this._Btn_Agregar.TabIndex = 1;
            this._Btn_Agregar.Text = "Agregar documento";
            this._Btn_Agregar.UseVisualStyleBackColor = true;
            this._Btn_Agregar.Click += new System.EventHandler(this._Btn_Agregar_Click);
            // 
            // _Dtg_Documentos
            // 
            this._Dtg_Documentos.AllowUserToAddRows = false;
            this._Dtg_Documentos.AllowUserToDeleteRows = false;
            this._Dtg_Documentos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._Dtg_Documentos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._Dtg_Documentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dtg_Documentos.ContextMenuStrip = this._Mnu_Opciones;
            this._Dtg_Documentos.Location = new System.Drawing.Point(13, 54);
            this._Dtg_Documentos.MultiSelect = false;
            this._Dtg_Documentos.Name = "_Dtg_Documentos";
            this._Dtg_Documentos.ReadOnly = true;
            this._Dtg_Documentos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Dtg_Documentos.Size = new System.Drawing.Size(997, 154);
            this._Dtg_Documentos.TabIndex = 0;
            // 
            // _Mnu_Opciones
            // 
            this._Mnu_Opciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._Mnu_Eliminar});
            this._Mnu_Opciones.Name = "_Mnu_Eliminar";
            this._Mnu_Opciones.Size = new System.Drawing.Size(192, 26);
            this._Mnu_Opciones.Text = "Opciones";
            this._Mnu_Opciones.Click += new System.EventHandler(this._Mnu_Eliminar_Click);
            // 
            // _Mnu_Eliminar
            // 
            this._Mnu_Eliminar.Name = "_Mnu_Eliminar";
            this._Mnu_Eliminar.Size = new System.Drawing.Size(191, 22);
            this._Mnu_Eliminar.Text = "Eliminar documento...";
            // 
            // _Gru_VistaPrevia
            // 
            this._Gru_VistaPrevia.Controls.Add(this._Btn_Visualizar);
            this._Gru_VistaPrevia.Controls.Add(this._Dtg_Comprobante);
            this._Gru_VistaPrevia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Gru_VistaPrevia.Location = new System.Drawing.Point(7, 367);
            this._Gru_VistaPrevia.Name = "_Gru_VistaPrevia";
            this._Gru_VistaPrevia.Size = new System.Drawing.Size(1026, 222);
            this._Gru_VistaPrevia.TabIndex = 11;
            this._Gru_VistaPrevia.TabStop = false;
            this._Gru_VistaPrevia.Text = "Vista previa del comprobante contable";
            // 
            // _Btn_Visualizar
            // 
            this._Btn_Visualizar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Btn_Visualizar.Image = global::T3.Properties.Resources.magnifier;
            this._Btn_Visualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Btn_Visualizar.Location = new System.Drawing.Point(772, 17);
            this._Btn_Visualizar.Name = "_Btn_Visualizar";
            this._Btn_Visualizar.Size = new System.Drawing.Size(239, 30);
            this._Btn_Visualizar.TabIndex = 1;
            this._Btn_Visualizar.Text = "Visualizar comprobante";
            this._Btn_Visualizar.UseVisualStyleBackColor = true;
            this._Btn_Visualizar.Click += new System.EventHandler(this._Btn_Visualizar_Click);
            // 
            // _Dtg_Comprobante
            // 
            this._Dtg_Comprobante.AllowUserToAddRows = false;
            this._Dtg_Comprobante.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._Dtg_Comprobante.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._Dtg_Comprobante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dtg_Comprobante.Location = new System.Drawing.Point(13, 53);
            this._Dtg_Comprobante.Name = "_Dtg_Comprobante";
            this._Dtg_Comprobante.ReadOnly = true;
            this._Dtg_Comprobante.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Dtg_Comprobante.Size = new System.Drawing.Size(998, 154);
            this._Dtg_Comprobante.TabIndex = 0;
            // 
            // _Btn_Generar
            // 
            this._Btn_Generar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Btn_Generar.Image = global::T3.Properties.Resources.check;
            this._Btn_Generar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Btn_Generar.Location = new System.Drawing.Point(632, 596);
            this._Btn_Generar.Name = "_Btn_Generar";
            this._Btn_Generar.Size = new System.Drawing.Size(192, 40);
            this._Btn_Generar.TabIndex = 12;
            this._Btn_Generar.Text = "Generar orden de pago";
            this._Btn_Generar.UseVisualStyleBackColor = true;
            this._Btn_Generar.Click += new System.EventHandler(this._Btn_Generar_Click);
            // 
            // _Btn_Cancelar
            // 
            this._Btn_Cancelar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Btn_Cancelar.Image = global::T3.Properties.Resources.cross_icon;
            this._Btn_Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Btn_Cancelar.Location = new System.Drawing.Point(830, 596);
            this._Btn_Cancelar.Name = "_Btn_Cancelar";
            this._Btn_Cancelar.Size = new System.Drawing.Size(196, 40);
            this._Btn_Cancelar.TabIndex = 13;
            this._Btn_Cancelar.Text = "Cancelar";
            this._Btn_Cancelar.UseVisualStyleBackColor = true;
            this._Btn_Cancelar.Click += new System.EventHandler(this._Btn_Cancelar_Click);
            // 
            // Frm_IC_GeneracionOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 642);
            this.Controls.Add(this._Btn_Cancelar);
            this.Controls.Add(this._Btn_Generar);
            this.Controls.Add(this._Gru_VistaPrevia);
            this.Controls.Add(this._Gru_Documento);
            this.Controls.Add(this._Cmb_Cuenta);
            this.Controls.Add(this._Cmb_Banco);
            this.Controls.Add(this._Lbl_Cuenta);
            this.Controls.Add(this._Lbl_Banco);
            this.Controls.Add(this._Chk_Transferencia);
            this.Controls.Add(this._Chk_Cheque);
            this.Controls.Add(this._Lbl_TituloFormaPago);
            this.Controls.Add(this._Lbl_TituloMontoTotal);
            this.Controls.Add(this._Lbl_MontoTotal);
            this.Controls.Add(this._Gru_Proveedor);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_IC_GeneracionOP";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generación de orden de pago intercompañía";
            this.Load += new System.EventHandler(this.Frm_GeneracionOPIC_Load);
            this._Gru_Proveedor.ResumeLayout(false);
            this._Gru_Proveedor.PerformLayout();
            this._Gru_Documento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dtg_Documentos)).EndInit();
            this._Mnu_Opciones.ResumeLayout(false);
            this._Gru_VistaPrevia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dtg_Comprobante)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _Gru_Proveedor;
        private System.Windows.Forms.Label _Lbl_MontoTotal;
        private System.Windows.Forms.Label _Lbl_TituloMontoTotal;
        private System.Windows.Forms.Label _Lbl_Proveedor;
        private System.Windows.Forms.Label _Lbl_TituloFormaPago;
        private System.Windows.Forms.RadioButton _Chk_Cheque;
        private System.Windows.Forms.RadioButton _Chk_Transferencia;
        private System.Windows.Forms.Label _Lbl_Banco;
        private System.Windows.Forms.Label _Lbl_Cuenta;
        private System.Windows.Forms.ComboBox _Cmb_Banco;
        private System.Windows.Forms.ComboBox _Cmb_Cuenta;
        private System.Windows.Forms.GroupBox _Gru_Documento;
        private System.Windows.Forms.DataGridView _Dtg_Documentos;
        private System.Windows.Forms.Button _Btn_Agregar;
        private System.Windows.Forms.GroupBox _Gru_VistaPrevia;
        private System.Windows.Forms.Button _Btn_Visualizar;
        private System.Windows.Forms.DataGridView _Dtg_Comprobante;
        private System.Windows.Forms.Button _Btn_Generar;
        private System.Windows.Forms.Button _Btn_Cancelar;
        private System.Windows.Forms.ContextMenuStrip _Mnu_Opciones;
        private System.Windows.Forms.ToolStripMenuItem _Mnu_Eliminar;
    }
}