namespace T3
{
    partial class Frm_CuentaBanca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_CuentaBanca));
            this._Txt_Fax = new System.Windows.Forms.TextBox();
            this._Cmb_Banco = new System.Windows.Forms.ComboBox();
            this._Txt_Telefono = new System.Windows.Forms.TextBox();
            this._Txt_Ejecutivo = new System.Windows.Forms.TextBox();
            this._Txt_Cuenta = new System.Windows.Forms.TextBox();
            this._Txt_Gerente = new System.Windows.Forms.TextBox();
            this._Txt_Descripcion = new System.Windows.Forms.TextBox();
            this._Txt_Sucursal = new System.Windows.Forms.TextBox();
            this._Chbox_Activo = new System.Windows.Forms.CheckBox();
            this._Txt_Numero = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this._Txt_Total = new System.Windows.Forms.TextBox();
            this._Dtp_Apertura = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this._Txt_Inicial = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this._Txt_Conciliacion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this._Txt_Fecha = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Pnl_Datos = new System.Windows.Forms.Panel();
            this._Bt_Cuenta = new System.Windows.Forms.Button();
            this._Txt_CtaContable = new System.Windows.Forms.TextBox();
            this._Tool_Tip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this._Pnl_Datos.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Txt_Fax
            // 
            this._Txt_Fax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Fax.Enabled = false;
            this._Txt_Fax.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Fax.Location = new System.Drawing.Point(11, 251);
            this._Txt_Fax.Name = "_Txt_Fax";
            this._Txt_Fax.Size = new System.Drawing.Size(236, 18);
            this._Txt_Fax.TabIndex = 15;
            this._Txt_Fax.TextChanged += new System.EventHandler(this._Txt_Fax_TextChanged);
            this._Txt_Fax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Fax_KeyPress);
            // 
            // _Cmb_Banco
            // 
            this._Cmb_Banco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Banco.Enabled = false;
            this._Cmb_Banco.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Cmb_Banco.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Banco.FormattingEnabled = true;
            this._Cmb_Banco.Location = new System.Drawing.Point(11, 22);
            this._Cmb_Banco.Name = "_Cmb_Banco";
            this._Cmb_Banco.Size = new System.Drawing.Size(236, 20);
            this._Cmb_Banco.TabIndex = 1;
            this._Cmb_Banco.DropDown += new System.EventHandler(this._Cmb_Banco_DropDown);
            this._Cmb_Banco.SelectedIndexChanged += new System.EventHandler(this._Cmb_Banco_SelectedIndexChanged);
            // 
            // _Txt_Telefono
            // 
            this._Txt_Telefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Telefono.Enabled = false;
            this._Txt_Telefono.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Telefono.Location = new System.Drawing.Point(11, 218);
            this._Txt_Telefono.Name = "_Txt_Telefono";
            this._Txt_Telefono.Size = new System.Drawing.Size(236, 18);
            this._Txt_Telefono.TabIndex = 13;
            this._Txt_Telefono.TextChanged += new System.EventHandler(this._Txt_Telefono_TextChanged);
            this._Txt_Telefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Telefono_KeyPress);
            // 
            // _Txt_Ejecutivo
            // 
            this._Txt_Ejecutivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Ejecutivo.Enabled = false;
            this._Txt_Ejecutivo.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Ejecutivo.Location = new System.Drawing.Point(11, 186);
            this._Txt_Ejecutivo.MaxLength = 255;
            this._Txt_Ejecutivo.Name = "_Txt_Ejecutivo";
            this._Txt_Ejecutivo.Size = new System.Drawing.Size(236, 18);
            this._Txt_Ejecutivo.TabIndex = 11;
            // 
            // _Txt_Cuenta
            // 
            this._Txt_Cuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Cuenta.Enabled = false;
            this._Txt_Cuenta.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Cuenta.Location = new System.Drawing.Point(11, 58);
            this._Txt_Cuenta.MaxLength = 30;
            this._Txt_Cuenta.Name = "_Txt_Cuenta";
            this._Txt_Cuenta.Size = new System.Drawing.Size(236, 18);
            this._Txt_Cuenta.TabIndex = 3;
            this._Txt_Cuenta.TextChanged += new System.EventHandler(this._Txt_Cuenta_TextChanged);
            this._Txt_Cuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Cuenta_KeyPress);
            this._Txt_Cuenta.Validating += new System.ComponentModel.CancelEventHandler(this._Txt_Cuenta_Validating);
            // 
            // _Txt_Gerente
            // 
            this._Txt_Gerente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Gerente.Enabled = false;
            this._Txt_Gerente.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Gerente.Location = new System.Drawing.Point(11, 152);
            this._Txt_Gerente.MaxLength = 255;
            this._Txt_Gerente.Name = "_Txt_Gerente";
            this._Txt_Gerente.Size = new System.Drawing.Size(236, 18);
            this._Txt_Gerente.TabIndex = 9;
            this._Txt_Gerente.TextChanged += new System.EventHandler(this._Txt_Gerente_TextChanged);
            // 
            // _Txt_Descripcion
            // 
            this._Txt_Descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Descripcion.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Descripcion.Location = new System.Drawing.Point(11, 90);
            this._Txt_Descripcion.Name = "_Txt_Descripcion";
            this._Txt_Descripcion.ReadOnly = true;
            this._Txt_Descripcion.Size = new System.Drawing.Size(236, 18);
            this._Txt_Descripcion.TabIndex = 5;
            // 
            // _Txt_Sucursal
            // 
            this._Txt_Sucursal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Sucursal.Enabled = false;
            this._Txt_Sucursal.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Sucursal.Location = new System.Drawing.Point(11, 119);
            this._Txt_Sucursal.MaxLength = 30;
            this._Txt_Sucursal.Name = "_Txt_Sucursal";
            this._Txt_Sucursal.Size = new System.Drawing.Size(236, 18);
            this._Txt_Sucursal.TabIndex = 7;
            this._Txt_Sucursal.TextChanged += new System.EventHandler(this._Txt_Sucursal_TextChanged);
            // 
            // _Chbox_Activo
            // 
            this._Chbox_Activo.AutoSize = true;
            this._Chbox_Activo.Checked = true;
            this._Chbox_Activo.CheckState = System.Windows.Forms.CheckState.Checked;
            this._Chbox_Activo.Enabled = false;
            this._Chbox_Activo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Chbox_Activo.Location = new System.Drawing.Point(265, 217);
            this._Chbox_Activo.Name = "_Chbox_Activo";
            this._Chbox_Activo.Size = new System.Drawing.Size(54, 16);
            this._Chbox_Activo.TabIndex = 30;
            this._Chbox_Activo.Text = "Activo";
            this._Chbox_Activo.UseVisualStyleBackColor = true;
            // 
            // _Txt_Numero
            // 
            this._Txt_Numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Numero.Enabled = false;
            this._Txt_Numero.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Numero.Location = new System.Drawing.Point(264, 158);
            this._Txt_Numero.Name = "_Txt_Numero";
            this._Txt_Numero.Size = new System.Drawing.Size(121, 18);
            this._Txt_Numero.TabIndex = 27;
            this._Txt_Numero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Numero_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(263, 177);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 12);
            this.label14.TabIndex = 28;
            this.label14.Text = "Apertura";
            // 
            // _Txt_Total
            // 
            this._Txt_Total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Total.Enabled = false;
            this._Txt_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Total.Location = new System.Drawing.Point(264, 125);
            this._Txt_Total.Name = "_Txt_Total";
            this._Txt_Total.Size = new System.Drawing.Size(129, 18);
            this._Txt_Total.TabIndex = 25;
            this._Txt_Total.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Total_KeyPress);
            // 
            // _Dtp_Apertura
            // 
            this._Dtp_Apertura.Enabled = false;
            this._Dtp_Apertura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dtp_Apertura.Location = new System.Drawing.Point(264, 191);
            this._Dtp_Apertura.MaxDate = new System.DateTime(2019, 12, 31, 0, 0, 0, 0);
            this._Dtp_Apertura.Name = "_Dtp_Apertura";
            this._Dtp_Apertura.Size = new System.Drawing.Size(96, 18);
            this._Dtp_Apertura.TabIndex = 29;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(262, 144);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 12);
            this.label17.TabIndex = 26;
            this.label17.Text = "Próximo # de cheque";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(262, 111);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 12);
            this.label13.TabIndex = 24;
            this.label13.Text = "S. Total";
            // 
            // _Txt_Inicial
            // 
            this._Txt_Inicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Inicial.Enabled = false;
            this._Txt_Inicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Inicial.Location = new System.Drawing.Point(264, 91);
            this._Txt_Inicial.Name = "_Txt_Inicial";
            this._Txt_Inicial.Size = new System.Drawing.Size(129, 18);
            this._Txt_Inicial.TabIndex = 23;
            this._Txt_Inicial.TextChanged += new System.EventHandler(this._Txt_Inicial_TextChanged);
            this._Txt_Inicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Inicial_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 275);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "C. Contable";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(262, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 12);
            this.label12.TabIndex = 22;
            this.label12.Text = "S. Inicial";
            // 
            // _Txt_Conciliacion
            // 
            this._Txt_Conciliacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Conciliacion.Enabled = false;
            this._Txt_Conciliacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Conciliacion.Location = new System.Drawing.Point(264, 58);
            this._Txt_Conciliacion.Name = "_Txt_Conciliacion";
            this._Txt_Conciliacion.Size = new System.Drawing.Size(129, 18);
            this._Txt_Conciliacion.TabIndex = 21;
            this._Txt_Conciliacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Conciliacion_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "Fax";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(262, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "S. Conciliación";
            // 
            // _Txt_Fecha
            // 
            this._Txt_Fecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Fecha.Enabled = false;
            this._Txt_Fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Fecha.Location = new System.Drawing.Point(264, 22);
            this._Txt_Fecha.Name = "_Txt_Fecha";
            this._Txt_Fecha.Size = new System.Drawing.Size(82, 18);
            this._Txt_Fecha.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(262, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "F. Conciliación";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "Telefono:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Banco:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ejecutivo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Número de cuenta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Gerente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descripción:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sucursal:";
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // _Pnl_Datos
            // 
            this._Pnl_Datos.Controls.Add(this._Bt_Cuenta);
            this._Pnl_Datos.Controls.Add(this._Txt_CtaContable);
            this._Pnl_Datos.Controls.Add(this._Dtp_Apertura);
            this._Pnl_Datos.Controls.Add(this._Txt_Numero);
            this._Pnl_Datos.Controls.Add(this._Txt_Total);
            this._Pnl_Datos.Controls.Add(this._Txt_Inicial);
            this._Pnl_Datos.Controls.Add(this._Txt_Conciliacion);
            this._Pnl_Datos.Controls.Add(this._Txt_Fecha);
            this._Pnl_Datos.Controls.Add(this._Txt_Fax);
            this._Pnl_Datos.Controls.Add(this._Txt_Telefono);
            this._Pnl_Datos.Controls.Add(this._Txt_Ejecutivo);
            this._Pnl_Datos.Controls.Add(this._Txt_Gerente);
            this._Pnl_Datos.Controls.Add(this._Txt_Sucursal);
            this._Pnl_Datos.Controls.Add(this._Txt_Cuenta);
            this._Pnl_Datos.Controls.Add(this._Txt_Descripcion);
            this._Pnl_Datos.Controls.Add(this.label1);
            this._Pnl_Datos.Controls.Add(this.label13);
            this._Pnl_Datos.Controls.Add(this.label9);
            this._Pnl_Datos.Controls.Add(this._Cmb_Banco);
            this._Pnl_Datos.Controls.Add(this.label17);
            this._Pnl_Datos.Controls.Add(this.label4);
            this._Pnl_Datos.Controls.Add(this.label12);
            this._Pnl_Datos.Controls.Add(this.label3);
            this._Pnl_Datos.Controls.Add(this.label5);
            this._Pnl_Datos.Controls.Add(this.label8);
            this._Pnl_Datos.Controls.Add(this.label14);
            this._Pnl_Datos.Controls.Add(this.label2);
            this._Pnl_Datos.Controls.Add(this.label11);
            this._Pnl_Datos.Controls.Add(this.label6);
            this._Pnl_Datos.Controls.Add(this._Chbox_Activo);
            this._Pnl_Datos.Controls.Add(this.label7);
            this._Pnl_Datos.Controls.Add(this.label10);
            this._Pnl_Datos.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Pnl_Datos.Location = new System.Drawing.Point(0, 0);
            this._Pnl_Datos.Name = "_Pnl_Datos";
            this._Pnl_Datos.Size = new System.Drawing.Size(399, 321);
            this._Pnl_Datos.TabIndex = 0;
            // 
            // _Bt_Cuenta
            // 
            this._Bt_Cuenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Cuenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Cuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Cuenta.Image = global::T3.Properties.Resources.magnifier;
            this._Bt_Cuenta.Location = new System.Drawing.Point(358, 289);
            this._Bt_Cuenta.Margin = new System.Windows.Forms.Padding(2);
            this._Bt_Cuenta.Name = "_Bt_Cuenta";
            this._Bt_Cuenta.Size = new System.Drawing.Size(28, 20);
            this._Bt_Cuenta.TabIndex = 32;
            this._Bt_Cuenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Tool_Tip.SetToolTip(this._Bt_Cuenta, "Seleccionar cuenta...");
            this._Bt_Cuenta.UseVisualStyleBackColor = true;
            this._Bt_Cuenta.Click += new System.EventHandler(this._Bt_Cuenta_Click);
            // 
            // _Txt_CtaContable
            // 
            this._Txt_CtaContable.BackColor = System.Drawing.Color.White;
            this._Txt_CtaContable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_CtaContable.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_CtaContable.Location = new System.Drawing.Point(11, 290);
            this._Txt_CtaContable.Name = "_Txt_CtaContable";
            this._Txt_CtaContable.ReadOnly = true;
            this._Txt_CtaContable.Size = new System.Drawing.Size(342, 18);
            this._Txt_CtaContable.TabIndex = 31;
            // 
            // Frm_CuentaBanca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 321);
            this.Controls.Add(this._Pnl_Datos);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_CuentaBanca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas bancarias";
            this.Activated += new System.EventHandler(this.Frm_CuentaBanca_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_CuentaBanca_FormClosing);
            this.Load += new System.EventHandler(this.Frm_CuentaBanca_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this._Pnl_Datos.ResumeLayout(false);
            this._Pnl_Datos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox _Txt_Descripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _Txt_Cuenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _Cmb_Banco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _Txt_Sucursal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox _Chbox_Activo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _Txt_Fax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _Txt_Telefono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _Txt_Ejecutivo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _Txt_Gerente;
        private System.Windows.Forms.TextBox _Txt_Fecha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox _Txt_Total;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox _Txt_Inicial;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox _Txt_Conciliacion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox _Txt_Numero;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker _Dtp_Apertura;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.Panel _Pnl_Datos;
        private System.Windows.Forms.TextBox _Txt_CtaContable;
        private System.Windows.Forms.Button _Bt_Cuenta;
        private System.Windows.Forms.ToolTip _Tool_Tip;
    }
}