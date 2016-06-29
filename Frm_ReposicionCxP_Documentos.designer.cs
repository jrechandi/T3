namespace T3
{
    partial class Frm_ReposicionCxP_Documentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ReposicionCxP_Documentos));
            this.label2 = new System.Windows.Forms.Label();
            this._Cmb_Proveedor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._Txt_NumDocu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._Dtp_Emision = new System.Windows.Forms.DateTimePicker();
            this._Txt_Concepto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._Txt_BaseImponible = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._Txt_MontoExento = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._Txt_MontoTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this._Bt_Cancelar = new System.Windows.Forms.Button();
            this._Bt_Aceptar = new System.Windows.Forms.Button();
            this._Txt_Impuesto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this._Rb_ConIva = new System.Windows.Forms.RadioButton();
            this._Rb_SinIva = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this._Txt_Alicuota = new System.Windows.Forms.TextBox();
            this._Chk_NoLibComp = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this._Txt_Cuenta = new System.Windows.Forms.TextBox();
            this._Txt_NumCtrlPref = new System.Windows.Forms.TextBox();
            this._Txt_NumCtrl = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this._Cmb_TipoProv = new System.Windows.Forms.ComboBox();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Bt_EditarCuenta = new System.Windows.Forms.Button();
            this._Cmb_CategProv = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this._Bt_Alicuota = new System.Windows.Forms.Button();
            this._Chk_FactMaqFis = new System.Windows.Forms.CheckBox();
            this._Bt_BuscarProveedor = new System.Windows.Forms.Button();
            this._Chk_IvaCredNoCom = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 78;
            this.label2.Text = "Proveedor:";
            // 
            // _Cmb_Proveedor
            // 
            this._Cmb_Proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Proveedor.Enabled = false;
            this._Cmb_Proveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Proveedor.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Proveedor.FormattingEnabled = true;
            this._Cmb_Proveedor.Location = new System.Drawing.Point(19, 125);
            this._Cmb_Proveedor.Name = "_Cmb_Proveedor";
            this._Cmb_Proveedor.Size = new System.Drawing.Size(446, 20);
            this._Cmb_Proveedor.TabIndex = 77;
            this._Cmb_Proveedor.DropDown += new System.EventHandler(this._Cmb_Proveedor_DropDown);
            this._Cmb_Proveedor.SelectedIndexChanged += new System.EventHandler(this._Cmb_Proveedor_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 79;
            this.label1.Text = "N° Documento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(190, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 82;
            this.label3.Text = "N° de Control:";
            // 
            // _Txt_NumDocu
            // 
            this._Txt_NumDocu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_NumDocu.Enabled = false;
            this._Txt_NumDocu.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_NumDocu.Location = new System.Drawing.Point(19, 164);
            this._Txt_NumDocu.MaxLength = 30;
            this._Txt_NumDocu.Name = "_Txt_NumDocu";
            this._Txt_NumDocu.Size = new System.Drawing.Size(100, 18);
            this._Txt_NumDocu.TabIndex = 83;
            this._Txt_NumDocu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_NumDocu_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(360, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 84;
            this.label4.Text = "Fecha emisión:";
            // 
            // _Dtp_Emision
            // 
            this._Dtp_Emision.Enabled = false;
            this._Dtp_Emision.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Dtp_Emision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dtp_Emision.Location = new System.Drawing.Point(363, 164);
            this._Dtp_Emision.Name = "_Dtp_Emision";
            this._Dtp_Emision.Size = new System.Drawing.Size(101, 21);
            this._Dtp_Emision.TabIndex = 86;
            // 
            // _Txt_Concepto
            // 
            this._Txt_Concepto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Concepto.Enabled = false;
            this._Txt_Concepto.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Concepto.Location = new System.Drawing.Point(19, 209);
            this._Txt_Concepto.MaxLength = 100;
            this._Txt_Concepto.Multiline = true;
            this._Txt_Concepto.Name = "_Txt_Concepto";
            this._Txt_Concepto.Size = new System.Drawing.Size(446, 51);
            this._Txt_Concepto.TabIndex = 87;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 88;
            this.label5.Text = "Concepto:";
            // 
            // _Txt_BaseImponible
            // 
            this._Txt_BaseImponible.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_BaseImponible.Enabled = false;
            this._Txt_BaseImponible.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_BaseImponible.Location = new System.Drawing.Point(19, 303);
            this._Txt_BaseImponible.Name = "_Txt_BaseImponible";
            this._Txt_BaseImponible.Size = new System.Drawing.Size(126, 18);
            this._Txt_BaseImponible.TabIndex = 90;
            this._Txt_BaseImponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Txt_BaseImponible.TextChanged += new System.EventHandler(this._Txt_BaseImponible_TextChanged);
            this._Txt_BaseImponible.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_BaseImponible_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 89;
            this.label6.Text = "Base imponible:";
            // 
            // _Txt_MontoExento
            // 
            this._Txt_MontoExento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_MontoExento.Enabled = false;
            this._Txt_MontoExento.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_MontoExento.Location = new System.Drawing.Point(180, 303);
            this._Txt_MontoExento.Name = "_Txt_MontoExento";
            this._Txt_MontoExento.Size = new System.Drawing.Size(126, 18);
            this._Txt_MontoExento.TabIndex = 92;
            this._Txt_MontoExento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Txt_MontoExento.TextChanged += new System.EventHandler(this._Txt_MontoExento_TextChanged);
            this._Txt_MontoExento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_MontoExento_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(177, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 91;
            this.label7.Text = "Monto exento:";
            // 
            // _Txt_MontoTotal
            // 
            this._Txt_MontoTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_MontoTotal.Enabled = false;
            this._Txt_MontoTotal.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_MontoTotal.Location = new System.Drawing.Point(339, 303);
            this._Txt_MontoTotal.Name = "_Txt_MontoTotal";
            this._Txt_MontoTotal.ReadOnly = true;
            this._Txt_MontoTotal.Size = new System.Drawing.Size(126, 18);
            this._Txt_MontoTotal.TabIndex = 94;
            this._Txt_MontoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(336, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 93;
            this.label8.Text = "Monto total:";
            // 
            // _Bt_Cancelar
            // 
            this._Bt_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Cancelar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Cancelar.Image")));
            this._Bt_Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Cancelar.Location = new System.Drawing.Point(357, 428);
            this._Bt_Cancelar.Name = "_Bt_Cancelar";
            this._Bt_Cancelar.Size = new System.Drawing.Size(107, 32);
            this._Bt_Cancelar.TabIndex = 130;
            this._Bt_Cancelar.Text = "Cancelar..";
            this._Bt_Cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Cancelar.UseVisualStyleBackColor = true;
            this._Bt_Cancelar.Click += new System.EventHandler(this._Bt_Visulizar_Click);
            // 
            // _Bt_Aceptar
            // 
            this._Bt_Aceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Aceptar.Enabled = false;
            this._Bt_Aceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Aceptar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Aceptar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Aceptar.Image")));
            this._Bt_Aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Aceptar.Location = new System.Drawing.Point(244, 428);
            this._Bt_Aceptar.Name = "_Bt_Aceptar";
            this._Bt_Aceptar.Size = new System.Drawing.Size(107, 32);
            this._Bt_Aceptar.TabIndex = 131;
            this._Bt_Aceptar.Text = "Aceptar..";
            this._Bt_Aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Aceptar.UseVisualStyleBackColor = true;
            this._Bt_Aceptar.Click += new System.EventHandler(this._Bt_Aceptar_Click);
            // 
            // _Txt_Impuesto
            // 
            this._Txt_Impuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Impuesto.Enabled = false;
            this._Txt_Impuesto.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Impuesto.Location = new System.Drawing.Point(19, 339);
            this._Txt_Impuesto.Name = "_Txt_Impuesto";
            this._Txt_Impuesto.Size = new System.Drawing.Size(126, 18);
            this._Txt_Impuesto.TabIndex = 134;
            this._Txt_Impuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Txt_Impuesto.TextChanged += new System.EventHandler(this._Txt_Impuesto_TextChanged);
            this._Txt_Impuesto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Impuesto_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 323);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 13);
            this.label9.TabIndex = 133;
            this.label9.Text = "Monto impuesto:";
            // 
            // _Rb_ConIva
            // 
            this._Rb_ConIva.AutoSize = true;
            this._Rb_ConIva.Checked = true;
            this._Rb_ConIva.Enabled = false;
            this._Rb_ConIva.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Rb_ConIva.Location = new System.Drawing.Point(19, 266);
            this._Rb_ConIva.Name = "_Rb_ConIva";
            this._Rb_ConIva.Size = new System.Drawing.Size(76, 17);
            this._Rb_ConIva.TabIndex = 137;
            this._Rb_ConIva.TabStop = true;
            this._Rb_ConIva.Text = "Con IVA";
            this._Rb_ConIva.UseVisualStyleBackColor = true;
            this._Rb_ConIva.CheckedChanged += new System.EventHandler(this._Rb_ConIva_CheckedChanged);
            this._Rb_ConIva.EnabledChanged += new System.EventHandler(this._Rb_ConIva_EnabledChanged);
            // 
            // _Rb_SinIva
            // 
            this._Rb_SinIva.AutoSize = true;
            this._Rb_SinIva.Enabled = false;
            this._Rb_SinIva.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Rb_SinIva.Location = new System.Drawing.Point(232, 266);
            this._Rb_SinIva.Name = "_Rb_SinIva";
            this._Rb_SinIva.Size = new System.Drawing.Size(72, 17);
            this._Rb_SinIva.TabIndex = 138;
            this._Rb_SinIva.Text = "Sin IVA";
            this._Rb_SinIva.UseVisualStyleBackColor = true;
            this._Rb_SinIva.CheckedChanged += new System.EventHandler(this._Rb_SinIva_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(101, 268);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 139;
            this.label11.Text = "Alícuota:";
            // 
            // _Txt_Alicuota
            // 
            this._Txt_Alicuota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Alicuota.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Alicuota.Location = new System.Drawing.Point(163, 267);
            this._Txt_Alicuota.Name = "_Txt_Alicuota";
            this._Txt_Alicuota.ReadOnly = true;
            this._Txt_Alicuota.Size = new System.Drawing.Size(40, 18);
            this._Txt_Alicuota.TabIndex = 140;
            // 
            // _Chk_NoLibComp
            // 
            this._Chk_NoLibComp.AutoSize = true;
            this._Chk_NoLibComp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Chk_NoLibComp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Chk_NoLibComp.Location = new System.Drawing.Point(19, 9);
            this._Chk_NoLibComp.Name = "_Chk_NoLibComp";
            this._Chk_NoLibComp.Size = new System.Drawing.Size(314, 17);
            this._Chk_NoLibComp.TabIndex = 141;
            this._Chk_NoLibComp.Text = "Factura no aplicará para el libro de compras";
            this._Chk_NoLibComp.UseVisualStyleBackColor = true;
            this._Chk_NoLibComp.CheckedChanged += new System.EventHandler(this._Chk_NoLibComp_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(19, 360);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 13);
            this.label12.TabIndex = 142;
            this.label12.Text = "Cuenta contable:";
            // 
            // _Txt_Cuenta
            // 
            this._Txt_Cuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Cuenta.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Cuenta.Location = new System.Drawing.Point(19, 376);
            this._Txt_Cuenta.Multiline = true;
            this._Txt_Cuenta.Name = "_Txt_Cuenta";
            this._Txt_Cuenta.ReadOnly = true;
            this._Txt_Cuenta.Size = new System.Drawing.Size(418, 46);
            this._Txt_Cuenta.TabIndex = 143;
            // 
            // _Txt_NumCtrlPref
            // 
            this._Txt_NumCtrlPref.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_NumCtrlPref.Enabled = false;
            this._Txt_NumCtrlPref.Location = new System.Drawing.Point(193, 164);
            this._Txt_NumCtrlPref.MaxLength = 2;
            this._Txt_NumCtrlPref.Name = "_Txt_NumCtrlPref";
            this._Txt_NumCtrlPref.Size = new System.Drawing.Size(23, 18);
            this._Txt_NumCtrlPref.TabIndex = 150;
            this._Txt_NumCtrlPref.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Txt_NumCtrlPref.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_NumCtrlPref_KeyPress);
            // 
            // _Txt_NumCtrl
            // 
            this._Txt_NumCtrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_NumCtrl.Enabled = false;
            this._Txt_NumCtrl.Location = new System.Drawing.Point(225, 164);
            this._Txt_NumCtrl.MaxLength = 8;
            this._Txt_NumCtrl.Name = "_Txt_NumCtrl";
            this._Txt_NumCtrl.Size = new System.Drawing.Size(63, 18);
            this._Txt_NumCtrl.TabIndex = 149;
            this._Txt_NumCtrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Txt_NumCtrl.TextChanged += new System.EventHandler(this._Txt_NumCtrl_TextChanged);
            this._Txt_NumCtrl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_NumCtrl_KeyPress);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(217, 168);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(9, 12);
            this.label20.TabIndex = 151;
            this.label20.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(16, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 153;
            this.label10.Text = "Tipo:";
            // 
            // _Cmb_TipoProv
            // 
            this._Cmb_TipoProv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_TipoProv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_TipoProv.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_TipoProv.FormattingEnabled = true;
            this._Cmb_TipoProv.Location = new System.Drawing.Point(19, 45);
            this._Cmb_TipoProv.Name = "_Cmb_TipoProv";
            this._Cmb_TipoProv.Size = new System.Drawing.Size(117, 20);
            this._Cmb_TipoProv.TabIndex = 152;
            this._Cmb_TipoProv.SelectedIndexChanged += new System.EventHandler(this._Cmb_TipoProv_SelectedIndexChanged);
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // _Bt_EditarCuenta
            // 
            this._Bt_EditarCuenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_EditarCuenta.Enabled = false;
            this._Bt_EditarCuenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_EditarCuenta.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_EditarCuenta.Image")));
            this._Bt_EditarCuenta.Location = new System.Drawing.Point(440, 397);
            this._Bt_EditarCuenta.Name = "_Bt_EditarCuenta";
            this._Bt_EditarCuenta.Size = new System.Drawing.Size(25, 20);
            this._Bt_EditarCuenta.TabIndex = 154;
            this._Bt_EditarCuenta.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this._Bt_EditarCuenta.UseVisualStyleBackColor = true;
            this._Bt_EditarCuenta.Click += new System.EventHandler(this._Bt_EditarCuenta_Click);
            // 
            // _Cmb_CategProv
            // 
            this._Cmb_CategProv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_CategProv.Enabled = false;
            this._Cmb_CategProv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_CategProv.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_CategProv.FormattingEnabled = true;
            this._Cmb_CategProv.Location = new System.Drawing.Point(19, 86);
            this._Cmb_CategProv.Name = "_Cmb_CategProv";
            this._Cmb_CategProv.Size = new System.Drawing.Size(446, 20);
            this._Cmb_CategProv.TabIndex = 156;
            this._Cmb_CategProv.SelectedIndexChanged += new System.EventHandler(this._Cmb_CategProv_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(16, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 13);
            this.label13.TabIndex = 155;
            this.label13.Text = "Categoría:";
            // 
            // _Bt_Alicuota
            // 
            this._Bt_Alicuota.Enabled = false;
            this._Bt_Alicuota.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._Bt_Alicuota.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Alicuota.Location = new System.Drawing.Point(206, 267);
            this._Bt_Alicuota.Name = "_Bt_Alicuota";
            this._Bt_Alicuota.Size = new System.Drawing.Size(20, 18);
            this._Bt_Alicuota.TabIndex = 157;
            this._Bt_Alicuota.Text = "?";
            this._Bt_Alicuota.UseVisualStyleBackColor = true;
            this._Bt_Alicuota.Click += new System.EventHandler(this._Bt_Alicuota_Click);
            // 
            // _Chk_FactMaqFis
            // 
            this._Chk_FactMaqFis.AutoSize = true;
            this._Chk_FactMaqFis.Enabled = false;
            this._Chk_FactMaqFis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Chk_FactMaqFis.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Chk_FactMaqFis.Location = new System.Drawing.Point(193, 188);
            this._Chk_FactMaqFis.Name = "_Chk_FactMaqFis";
            this._Chk_FactMaqFis.Size = new System.Drawing.Size(131, 16);
            this._Chk_FactMaqFis.TabIndex = 158;
            this._Chk_FactMaqFis.Text = "Fac. de máquina fiscal";
            this._Chk_FactMaqFis.UseVisualStyleBackColor = true;
            this._Chk_FactMaqFis.CheckedChanged += new System.EventHandler(this._Chk_FactMaqFis_CheckedChanged);
            // 
            // _Bt_BuscarProveedor
            // 
            this._Bt_BuscarProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_BuscarProveedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_BuscarProveedor.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_BuscarProveedor.Image")));
            this._Bt_BuscarProveedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_BuscarProveedor.Location = new System.Drawing.Point(142, 46);
            this._Bt_BuscarProveedor.Name = "_Bt_BuscarProveedor";
            this._Bt_BuscarProveedor.Size = new System.Drawing.Size(125, 20);
            this._Bt_BuscarProveedor.TabIndex = 159;
            this._Bt_BuscarProveedor.Text = "Buscar proveedor";
            this._Bt_BuscarProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_BuscarProveedor.UseVisualStyleBackColor = true;
            this._Bt_BuscarProveedor.Click += new System.EventHandler(this._Bt_BuscarProveedor_Click);
            // 
            // _Chk_IvaCredNoCom
            // 
            this._Chk_IvaCredNoCom.AutoSize = true;
            this._Chk_IvaCredNoCom.Enabled = false;
            this._Chk_IvaCredNoCom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Chk_IvaCredNoCom.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Chk_IvaCredNoCom.Location = new System.Drawing.Point(151, 341);
            this._Chk_IvaCredNoCom.Name = "_Chk_IvaCredNoCom";
            this._Chk_IvaCredNoCom.Size = new System.Drawing.Size(158, 16);
            this._Chk_IvaCredNoCom.TabIndex = 160;
            this._Chk_IvaCredNoCom.Text = "IVA crédito no compensado";
            this._Chk_IvaCredNoCom.UseVisualStyleBackColor = true;
            // 
            // Frm_ReposicionCxP_Documentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 468);
            this.Controls.Add(this._Chk_IvaCredNoCom);
            this.Controls.Add(this._Bt_BuscarProveedor);
            this.Controls.Add(this._Chk_FactMaqFis);
            this.Controls.Add(this._Bt_Alicuota);
            this.Controls.Add(this._Cmb_CategProv);
            this.Controls.Add(this.label13);
            this.Controls.Add(this._Bt_EditarCuenta);
            this.Controls.Add(this.label10);
            this.Controls.Add(this._Cmb_TipoProv);
            this.Controls.Add(this._Txt_NumCtrlPref);
            this.Controls.Add(this._Txt_NumCtrl);
            this.Controls.Add(this.label20);
            this.Controls.Add(this._Txt_Cuenta);
            this.Controls.Add(this.label12);
            this.Controls.Add(this._Chk_NoLibComp);
            this.Controls.Add(this._Txt_Alicuota);
            this.Controls.Add(this.label11);
            this.Controls.Add(this._Rb_SinIva);
            this.Controls.Add(this._Rb_ConIva);
            this.Controls.Add(this._Txt_Impuesto);
            this.Controls.Add(this.label9);
            this.Controls.Add(this._Bt_Aceptar);
            this.Controls.Add(this._Bt_Cancelar);
            this.Controls.Add(this._Txt_MontoTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this._Txt_MontoExento);
            this.Controls.Add(this.label7);
            this.Controls.Add(this._Txt_BaseImponible);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._Txt_Concepto);
            this.Controls.Add(this._Dtp_Emision);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._Txt_NumDocu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._Cmb_Proveedor);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ReposicionCxP_Documentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reposiciones de CxP - Ingreso de documentos";
            this.Load += new System.EventHandler(this.Frm_ReposicionCxP_Documentos_Load);
            this.Shown += new System.EventHandler(this.Frm_ReposicionCxP_Documentos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _Cmb_Proveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _Txt_NumDocu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker _Dtp_Emision;
        private System.Windows.Forms.TextBox _Txt_Concepto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _Txt_BaseImponible;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _Txt_MontoExento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _Txt_MontoTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button _Bt_Cancelar;
        private System.Windows.Forms.Button _Bt_Aceptar;
        private System.Windows.Forms.TextBox _Txt_Impuesto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton _Rb_ConIva;
        private System.Windows.Forms.RadioButton _Rb_SinIva;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox _Txt_Alicuota;
        private System.Windows.Forms.CheckBox _Chk_NoLibComp;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox _Txt_Cuenta;
        private System.Windows.Forms.TextBox _Txt_NumCtrlPref;
        private System.Windows.Forms.TextBox _Txt_NumCtrl;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox _Cmb_TipoProv;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.Button _Bt_EditarCuenta;
        private System.Windows.Forms.ComboBox _Cmb_CategProv;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button _Bt_Alicuota;
        private System.Windows.Forms.CheckBox _Chk_FactMaqFis;
        private System.Windows.Forms.Button _Bt_BuscarProveedor;
        private System.Windows.Forms.CheckBox _Chk_IvaCredNoCom;
    }
}