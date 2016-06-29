namespace T3
{
    partial class Frm_Solicitud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Solicitud));
            this._Cmb_Solicitante = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Chk_Rma = new System.Windows.Forms.CheckBox();
            this._Txt_DetalleFalla = new System.Windows.Forms.TextBox();
            this._Bt_VerCapPantalla = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._Txt_Asunto = new System.Windows.Forms.TextBox();
            this._Cmb_TipoFalla = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this._Dtp_FechaHora = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this._Txt_Nota = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this._Tbp_1 = new System.Windows.Forms.TabPage();
            this._Tbp_2 = new System.Windows.Forms.TabPage();
            this._Dg_Tranf = new System.Windows.Forms.DataGridView();
            this.cuserde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuserpara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfechahortransferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this._Bt_Salir = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this._Txt_MotivoPausa = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this._Txt_FechaHoraPausa = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this._Txt_FinAprox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this._Txt_FechaHoraAtendido = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this._Cmb_Prioridad = new System.Windows.Forms.ComboBox();
            this._Cmb_Estado = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this._Cmb_Arquitecto = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Bt_Activar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this._Tb_Tab.SuspendLayout();
            this._Tbp_1.SuspendLayout();
            this._Tbp_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Tranf)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this.SuspendLayout();
            // 
            // _Cmb_Solicitante
            // 
            this._Cmb_Solicitante.Cursor = System.Windows.Forms.Cursors.Default;
            this._Cmb_Solicitante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Solicitante.Enabled = false;
            this._Cmb_Solicitante.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Solicitante.FormattingEnabled = true;
            this._Cmb_Solicitante.Location = new System.Drawing.Point(12, 24);
            this._Cmb_Solicitante.Name = "_Cmb_Solicitante";
            this._Cmb_Solicitante.Size = new System.Drawing.Size(329, 21);
            this._Cmb_Solicitante.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Solicitante:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Chk_Rma);
            this.panel1.Controls.Add(this._Txt_DetalleFalla);
            this.panel1.Controls.Add(this._Bt_VerCapPantalla);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this._Txt_Asunto);
            this.panel1.Controls.Add(this._Cmb_TipoFalla);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this._Dtp_FechaHora);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._Cmb_Solicitante);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 352);
            this.panel1.TabIndex = 0;
            // 
            // _Chk_Rma
            // 
            this._Chk_Rma.AutoSize = true;
            this._Chk_Rma.Enabled = false;
            this._Chk_Rma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Chk_Rma.Location = new System.Drawing.Point(10, 316);
            this._Chk_Rma.Name = "_Chk_Rma";
            this._Chk_Rma.Size = new System.Drawing.Size(106, 17);
            this._Chk_Rma.TabIndex = 40;
            this._Chk_Rma.Text = "Solicitud RMA";
            this._Chk_Rma.UseVisualStyleBackColor = true;
            // 
            // _Txt_DetalleFalla
            // 
            this._Txt_DetalleFalla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_DetalleFalla.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._Txt_DetalleFalla.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_DetalleFalla.Location = new System.Drawing.Point(12, 144);
            this._Txt_DetalleFalla.Multiline = true;
            this._Txt_DetalleFalla.Name = "_Txt_DetalleFalla";
            this._Txt_DetalleFalla.ReadOnly = true;
            this._Txt_DetalleFalla.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._Txt_DetalleFalla.Size = new System.Drawing.Size(460, 166);
            this._Txt_DetalleFalla.TabIndex = 6;
            // 
            // _Bt_VerCapPantalla
            // 
            this._Bt_VerCapPantalla.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_VerCapPantalla.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_VerCapPantalla.Image")));
            this._Bt_VerCapPantalla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_VerCapPantalla.Location = new System.Drawing.Point(352, 316);
            this._Bt_VerCapPantalla.Name = "_Bt_VerCapPantalla";
            this._Bt_VerCapPantalla.Size = new System.Drawing.Size(120, 30);
            this._Bt_VerCapPantalla.TabIndex = 31;
            this._Bt_VerCapPantalla.Text = "Ver imagen..";
            this._Bt_VerCapPantalla.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_VerCapPantalla.UseVisualStyleBackColor = true;
            this._Bt_VerCapPantalla.Click += new System.EventHandler(this._Bt_VerCapPantalla_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Detalle:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Asunto:";
            // 
            // _Txt_Asunto
            // 
            this._Txt_Asunto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Asunto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._Txt_Asunto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Asunto.Location = new System.Drawing.Point(12, 104);
            this._Txt_Asunto.MaxLength = 140;
            this._Txt_Asunto.Name = "_Txt_Asunto";
            this._Txt_Asunto.ReadOnly = true;
            this._Txt_Asunto.Size = new System.Drawing.Size(460, 21);
            this._Txt_Asunto.TabIndex = 5;
            // 
            // _Cmb_TipoFalla
            // 
            this._Cmb_TipoFalla.Cursor = System.Windows.Forms.Cursors.Default;
            this._Cmb_TipoFalla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_TipoFalla.Enabled = false;
            this._Cmb_TipoFalla.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_TipoFalla.FormattingEnabled = true;
            this._Cmb_TipoFalla.Location = new System.Drawing.Point(12, 64);
            this._Cmb_TipoFalla.Name = "_Cmb_TipoFalla";
            this._Cmb_TipoFalla.Size = new System.Drawing.Size(384, 21);
            this._Cmb_TipoFalla.TabIndex = 3;
            this._Cmb_TipoFalla.SelectedIndexChanged += new System.EventHandler(this._Cmb_TipoFalla_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Tipo de falla:";
            // 
            // _Dtp_FechaHora
            // 
            this._Dtp_FechaHora.CustomFormat = "dd/MM/yyyy hh:mm tt";
            this._Dtp_FechaHora.Enabled = false;
            this._Dtp_FechaHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._Dtp_FechaHora.Location = new System.Drawing.Point(350, 24);
            this._Dtp_FechaHora.Name = "_Dtp_FechaHora";
            this._Dtp_FechaHora.Size = new System.Drawing.Size(144, 20);
            this._Dtp_FechaHora.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(347, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Fecha y hora";
            // 
            // _Txt_Nota
            // 
            this._Txt_Nota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Nota.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._Txt_Nota.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Nota.Location = new System.Drawing.Point(6, 8);
            this._Txt_Nota.Multiline = true;
            this._Txt_Nota.Name = "_Txt_Nota";
            this._Txt_Nota.ReadOnly = true;
            this._Txt_Nota.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._Txt_Nota.Size = new System.Drawing.Size(802, 84);
            this._Txt_Nota.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(82, 435);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Arquitecto";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._Tb_Tab);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 352);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(840, 168);
            this.panel2.TabIndex = 24;
            // 
            // _Tb_Tab
            // 
            this._Tb_Tab.Controls.Add(this._Tbp_1);
            this._Tb_Tab.Controls.Add(this._Tbp_2);
            this._Tb_Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Tb_Tab.Location = new System.Drawing.Point(0, 0);
            this._Tb_Tab.Name = "_Tb_Tab";
            this._Tb_Tab.SelectedIndex = 0;
            this._Tb_Tab.Size = new System.Drawing.Size(840, 131);
            this._Tb_Tab.TabIndex = 1;
            // 
            // _Tbp_1
            // 
            this._Tbp_1.Controls.Add(this._Txt_Nota);
            this._Tbp_1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Tbp_1.Location = new System.Drawing.Point(4, 22);
            this._Tbp_1.Name = "_Tbp_1";
            this._Tbp_1.Padding = new System.Windows.Forms.Padding(3);
            this._Tbp_1.Size = new System.Drawing.Size(832, 105);
            this._Tbp_1.TabIndex = 0;
            this._Tbp_1.Text = "Notas";
            this._Tbp_1.UseVisualStyleBackColor = true;
            // 
            // _Tbp_2
            // 
            this._Tbp_2.Controls.Add(this._Dg_Tranf);
            this._Tbp_2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Tbp_2.Location = new System.Drawing.Point(4, 22);
            this._Tbp_2.Name = "_Tbp_2";
            this._Tbp_2.Padding = new System.Windows.Forms.Padding(3);
            this._Tbp_2.Size = new System.Drawing.Size(832, 105);
            this._Tbp_2.TabIndex = 1;
            this._Tbp_2.Text = "Transferencias";
            this._Tbp_2.UseVisualStyleBackColor = true;
            // 
            // _Dg_Tranf
            // 
            this._Dg_Tranf.AllowUserToAddRows = false;
            this._Dg_Tranf.AllowUserToDeleteRows = false;
            this._Dg_Tranf.AllowUserToResizeRows = false;
            this._Dg_Tranf.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._Dg_Tranf.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cuserde,
            this.cuserpara,
            this.cfechahortransferencia});
            this._Dg_Tranf.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Tranf.Location = new System.Drawing.Point(3, 3);
            this._Dg_Tranf.Name = "_Dg_Tranf";
            this._Dg_Tranf.ReadOnly = true;
            this._Dg_Tranf.Size = new System.Drawing.Size(826, 99);
            this._Dg_Tranf.TabIndex = 0;
            // 
            // cuserde
            // 
            this.cuserde.DataPropertyName = "cuserde";
            this.cuserde.HeaderText = "Transferido por";
            this.cuserde.Name = "cuserde";
            this.cuserde.ReadOnly = true;
            this.cuserde.Width = 120;
            // 
            // cuserpara
            // 
            this.cuserpara.DataPropertyName = "cuserpara";
            this.cuserpara.HeaderText = "Para";
            this.cuserpara.Name = "cuserpara";
            this.cuserpara.ReadOnly = true;
            this.cuserpara.Width = 58;
            // 
            // cfechahortransferencia
            // 
            this.cfechahortransferencia.DataPropertyName = "cfechahortransferencia";
            this.cfechahortransferencia.HeaderText = "Fecha Hora Transferencia";
            this.cfechahortransferencia.Name = "cfechahortransferencia";
            this.cfechahortransferencia.ReadOnly = true;
            this.cfechahortransferencia.Width = 178;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel4.Controls.Add(this._Bt_Activar);
            this.panel4.Controls.Add(this._Bt_Salir);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 131);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(840, 37);
            this.panel4.TabIndex = 0;
            // 
            // _Bt_Salir
            // 
            this._Bt_Salir.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Salir.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Salir.Image")));
            this._Bt_Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Salir.Location = new System.Drawing.Point(755, 3);
            this._Bt_Salir.Name = "_Bt_Salir";
            this._Bt_Salir.Size = new System.Drawing.Size(81, 30);
            this._Bt_Salir.TabIndex = 4;
            this._Bt_Salir.Text = "Salir";
            this._Bt_Salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Salir.UseVisualStyleBackColor = true;
            this._Bt_Salir.Click += new System.EventHandler(this._Bt_Salir_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this._Txt_MotivoPausa);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this._Txt_FechaHoraPausa);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this._Txt_FinAprox);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this._Txt_FechaHoraAtendido);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this._Cmb_Prioridad);
            this.panel3.Controls.Add(this._Cmb_Estado);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this._Cmb_Arquitecto);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(500, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(340, 352);
            this.panel3.TabIndex = 1;
            // 
            // pictureBox3
            // 
            this.pictureBox3.ErrorImage = null;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(204, 223);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(19, 21);
            this.pictureBox3.TabIndex = 38;
            this.pictureBox3.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 247);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "Motivo de la pausa:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _Txt_MotivoPausa
            // 
            this._Txt_MotivoPausa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_MotivoPausa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._Txt_MotivoPausa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_MotivoPausa.Location = new System.Drawing.Point(9, 263);
            this._Txt_MotivoPausa.MaxLength = 255;
            this._Txt_MotivoPausa.Multiline = true;
            this._Txt_MotivoPausa.Name = "_Txt_MotivoPausa";
            this._Txt_MotivoPausa.ReadOnly = true;
            this._Txt_MotivoPausa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._Txt_MotivoPausa.Size = new System.Drawing.Size(306, 83);
            this._Txt_MotivoPausa.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 207);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(175, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Fecha y hora de la pausa:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _Txt_FechaHoraPausa
            // 
            this._Txt_FechaHoraPausa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_FechaHoraPausa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._Txt_FechaHoraPausa.Enabled = false;
            this._Txt_FechaHoraPausa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_FechaHoraPausa.Location = new System.Drawing.Point(9, 223);
            this._Txt_FechaHoraPausa.Name = "_Txt_FechaHoraPausa";
            this._Txt_FechaHoraPausa.Size = new System.Drawing.Size(189, 21);
            this._Txt_FechaHoraPausa.TabIndex = 35;
            // 
            // pictureBox2
            // 
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(204, 183);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(19, 21);
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 167);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "Fin aproximado:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _Txt_FinAprox
            // 
            this._Txt_FinAprox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_FinAprox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._Txt_FinAprox.Enabled = false;
            this._Txt_FinAprox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_FinAprox.Location = new System.Drawing.Point(9, 183);
            this._Txt_FinAprox.Name = "_Txt_FinAprox";
            this._Txt_FinAprox.Size = new System.Drawing.Size(189, 21);
            this._Txt_FinAprox.TabIndex = 32;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(204, 143);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Se atendió desde:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _Txt_FechaHoraAtendido
            // 
            this._Txt_FechaHoraAtendido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_FechaHoraAtendido.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._Txt_FechaHoraAtendido.Enabled = false;
            this._Txt_FechaHoraAtendido.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_FechaHoraAtendido.Location = new System.Drawing.Point(9, 143);
            this._Txt_FechaHoraAtendido.Name = "_Txt_FechaHoraAtendido";
            this._Txt_FechaHoraAtendido.Size = new System.Drawing.Size(189, 21);
            this._Txt_FechaHoraAtendido.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Prioridad:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _Cmb_Prioridad
            // 
            this._Cmb_Prioridad.Cursor = System.Windows.Forms.Cursors.Default;
            this._Cmb_Prioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Prioridad.Enabled = false;
            this._Cmb_Prioridad.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Prioridad.FormattingEnabled = true;
            this._Cmb_Prioridad.Location = new System.Drawing.Point(9, 103);
            this._Cmb_Prioridad.Name = "_Cmb_Prioridad";
            this._Cmb_Prioridad.Size = new System.Drawing.Size(306, 21);
            this._Cmb_Prioridad.TabIndex = 2;
            // 
            // _Cmb_Estado
            // 
            this._Cmb_Estado.Cursor = System.Windows.Forms.Cursors.Default;
            this._Cmb_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Estado.Enabled = false;
            this._Cmb_Estado.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Estado.FormattingEnabled = true;
            this._Cmb_Estado.Location = new System.Drawing.Point(9, 65);
            this._Cmb_Estado.Name = "_Cmb_Estado";
            this._Cmb_Estado.Size = new System.Drawing.Size(254, 21);
            this._Cmb_Estado.TabIndex = 1;
            this._Cmb_Estado.SelectedIndexChanged += new System.EventHandler(this._Cmb_Estado_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Estado:";
            // 
            // _Cmb_Arquitecto
            // 
            this._Cmb_Arquitecto.Cursor = System.Windows.Forms.Cursors.Default;
            this._Cmb_Arquitecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Arquitecto.Enabled = false;
            this._Cmb_Arquitecto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Arquitecto.FormattingEnabled = true;
            this._Cmb_Arquitecto.Location = new System.Drawing.Point(9, 25);
            this._Cmb_Arquitecto.Name = "_Cmb_Arquitecto";
            this._Cmb_Arquitecto.Size = new System.Drawing.Size(306, 21);
            this._Cmb_Arquitecto.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Arquitecto:";
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // _Bt_Activar
            // 
            this._Bt_Activar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Activar.Enabled = false;
            this._Bt_Activar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Activar.Font = new System.Drawing.Font("Verdana", 8.25F);
            this._Bt_Activar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Activar.Image")));
            this._Bt_Activar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Activar.Location = new System.Drawing.Point(566, 3);
            this._Bt_Activar.Name = "_Bt_Activar";
            this._Bt_Activar.Size = new System.Drawing.Size(183, 30);
            this._Bt_Activar.TabIndex = 94;
            this._Bt_Activar.Text = "Ver estatus..";
            this._Bt_Activar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Activar.UseVisualStyleBackColor = true;
            this._Bt_Activar.Click += new System.EventHandler(this._Bt_Activar_Click);
            // 
            // Frm_Solicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 520);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Solicitud";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitud";
            this.Load += new System.EventHandler(this.Frm_Solicitud_Load);
            this.Shown += new System.EventHandler(this.Frm_Solicitud_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this._Tb_Tab.ResumeLayout(false);
            this._Tbp_1.ResumeLayout(false);
            this._Tbp_1.PerformLayout();
            this._Tbp_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Tranf)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _Cmb_Solicitante;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _Cmb_TipoFalla;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _Txt_Asunto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _Txt_Nota;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox _Cmb_Arquitecto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox _Cmb_Estado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox _Cmb_Prioridad;
        private System.Windows.Forms.DateTimePicker _Dtp_FechaHora;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox _Txt_FechaHoraAtendido;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox _Txt_FinAprox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox _Txt_FechaHoraPausa;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox _Txt_MotivoPausa;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button _Bt_VerCapPantalla;
        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage _Tbp_1;
        private System.Windows.Forms.TabPage _Tbp_2;
        private System.Windows.Forms.TextBox _Txt_DetalleFalla;
        private System.Windows.Forms.DataGridView _Dg_Tranf;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button _Bt_Salir;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuserde;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuserpara;
        private System.Windows.Forms.DataGridViewTextBoxColumn cfechahortransferencia;
        private System.Windows.Forms.CheckBox _Chk_Rma;
        private System.Windows.Forms.Button _Bt_Activar;
    }
}