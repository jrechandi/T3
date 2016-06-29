namespace T3
{
    partial class Frm_ConsultaSolicitudes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ConsultaSolicitudes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this._Pnl_Filtros = new System.Windows.Forms.Panel();
            this._Cmb_Filtrar = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this._Cmb_TipoFalla = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this._Bt_Limpiar = new System.Windows.Forms.Button();
            this._Bt_Filtrar = new System.Windows.Forms.Button();
            this._Bt_ConsulTicket = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this._Lbl_Prio4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this._Lbl_Prio3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._Lbl_Prio2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._Lbl_Prio1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._Chk_MostrarF = new System.Windows.Forms.CheckBox();
            this._Cmb_Prioridad = new System.Windows.Forms.ComboBox();
            this._Cmb_Estado = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this._Dtp_Hasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this._Dtp_Desde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this._Cmb_Arquitecto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Cmb_Solicitante = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this.Ticket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companydescrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctipofalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asignadoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prioridad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfechahorareporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdiastrans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempoaproxfin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfechahorpausa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfechahoracerrado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Pnl_Ticket = new System.Windows.Forms.Panel();
            this._Bt_Consultar_T = new System.Windows.Forms.Button();
            this._Txt_Ticket = new System.Windows.Forms.TextBox();
            this._Bt_Cancelar_T = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Pnl_Filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this._Pnl_Ticket.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this.SuspendLayout();
            // 
            // _Pnl_Filtros
            // 
            this._Pnl_Filtros.Controls.Add(this._Cmb_Filtrar);
            this._Pnl_Filtros.Controls.Add(this.label13);
            this._Pnl_Filtros.Controls.Add(this._Cmb_TipoFalla);
            this._Pnl_Filtros.Controls.Add(this.label14);
            this._Pnl_Filtros.Controls.Add(this._Bt_Limpiar);
            this._Pnl_Filtros.Controls.Add(this._Bt_Filtrar);
            this._Pnl_Filtros.Controls.Add(this._Bt_ConsulTicket);
            this._Pnl_Filtros.Controls.Add(this.label10);
            this._Pnl_Filtros.Controls.Add(this._Lbl_Prio4);
            this._Pnl_Filtros.Controls.Add(this.label12);
            this._Pnl_Filtros.Controls.Add(this._Lbl_Prio3);
            this._Pnl_Filtros.Controls.Add(this.label8);
            this._Pnl_Filtros.Controls.Add(this._Lbl_Prio2);
            this._Pnl_Filtros.Controls.Add(this.label5);
            this._Pnl_Filtros.Controls.Add(this._Lbl_Prio1);
            this._Pnl_Filtros.Controls.Add(this.label6);
            this._Pnl_Filtros.Controls.Add(this._Chk_MostrarF);
            this._Pnl_Filtros.Controls.Add(this._Cmb_Prioridad);
            this._Pnl_Filtros.Controls.Add(this._Cmb_Estado);
            this._Pnl_Filtros.Controls.Add(this.label7);
            this._Pnl_Filtros.Controls.Add(this._Dtp_Hasta);
            this._Pnl_Filtros.Controls.Add(this.label4);
            this._Pnl_Filtros.Controls.Add(this._Dtp_Desde);
            this._Pnl_Filtros.Controls.Add(this.label3);
            this._Pnl_Filtros.Controls.Add(this._Cmb_Arquitecto);
            this._Pnl_Filtros.Controls.Add(this.label2);
            this._Pnl_Filtros.Controls.Add(this._Cmb_Solicitante);
            this._Pnl_Filtros.Controls.Add(this.label1);
            this._Pnl_Filtros.Dock = System.Windows.Forms.DockStyle.Top;
            this._Pnl_Filtros.Location = new System.Drawing.Point(0, 0);
            this._Pnl_Filtros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._Pnl_Filtros.Name = "_Pnl_Filtros";
            this._Pnl_Filtros.Size = new System.Drawing.Size(987, 169);
            this._Pnl_Filtros.TabIndex = 0;
            // 
            // _Cmb_Filtrar
            // 
            this._Cmb_Filtrar.Cursor = System.Windows.Forms.Cursors.Default;
            this._Cmb_Filtrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Filtrar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Filtrar.FormattingEnabled = true;
            this._Cmb_Filtrar.Items.AddRange(new object[] {
            "Solicitudes Pendientes",
            "Solicitudes sin Asignar",
            "Solicitudes en Pausa",
            "Solicitudes en RMA"});
            this._Cmb_Filtrar.Location = new System.Drawing.Point(12, 97);
            this._Cmb_Filtrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._Cmb_Filtrar.Name = "_Cmb_Filtrar";
            this._Cmb_Filtrar.Size = new System.Drawing.Size(212, 21);
            this._Cmb_Filtrar.TabIndex = 67;
            this._Cmb_Filtrar.SelectedIndexChanged += new System.EventHandler(this._Cmb_Filtrar_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(9, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 66;
            this.label13.Text = "Filtrar:";
            // 
            // _Cmb_TipoFalla
            // 
            this._Cmb_TipoFalla.Cursor = System.Windows.Forms.Cursors.Default;
            this._Cmb_TipoFalla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_TipoFalla.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_TipoFalla.FormattingEnabled = true;
            this._Cmb_TipoFalla.Location = new System.Drawing.Point(345, 20);
            this._Cmb_TipoFalla.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._Cmb_TipoFalla.Name = "_Cmb_TipoFalla";
            this._Cmb_TipoFalla.Size = new System.Drawing.Size(212, 21);
            this._Cmb_TipoFalla.TabIndex = 65;
            this._Cmb_TipoFalla.SelectedIndexChanged += new System.EventHandler(this._Cmb_TipoFalla_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(342, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 13);
            this.label14.TabIndex = 64;
            this.label14.Text = "Tipo de falla:";
            // 
            // _Bt_Limpiar
            // 
            this._Bt_Limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Limpiar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Limpiar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Limpiar.Image")));
            this._Bt_Limpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Limpiar.Location = new System.Drawing.Point(656, 122);
            this._Bt_Limpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._Bt_Limpiar.Name = "_Bt_Limpiar";
            this._Bt_Limpiar.Size = new System.Drawing.Size(28, 37);
            this._Bt_Limpiar.TabIndex = 63;
            this._Bt_Limpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Limpiar.UseVisualStyleBackColor = true;
            this._Bt_Limpiar.Click += new System.EventHandler(this._Bt_Limpiar_Click);
            // 
            // _Bt_Filtrar
            // 
            this._Bt_Filtrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Filtrar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Filtrar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Filtrar.Image")));
            this._Bt_Filtrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Filtrar.Location = new System.Drawing.Point(690, 122);
            this._Bt_Filtrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._Bt_Filtrar.Name = "_Bt_Filtrar";
            this._Bt_Filtrar.Size = new System.Drawing.Size(110, 37);
            this._Bt_Filtrar.TabIndex = 62;
            this._Bt_Filtrar.Text = "Filtrar";
            this._Bt_Filtrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Filtrar.UseVisualStyleBackColor = true;
            this._Bt_Filtrar.Click += new System.EventHandler(this._Bt_Filtrar_Click);
            // 
            // _Bt_ConsulTicket
            // 
            this._Bt_ConsulTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_ConsulTicket.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_ConsulTicket.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_ConsulTicket.Image")));
            this._Bt_ConsulTicket.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_ConsulTicket.Location = new System.Drawing.Point(12, 122);
            this._Bt_ConsulTicket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._Bt_ConsulTicket.Name = "_Bt_ConsulTicket";
            this._Bt_ConsulTicket.Size = new System.Drawing.Size(174, 37);
            this._Bt_ConsulTicket.TabIndex = 59;
            this._Bt_ConsulTicket.Text = "Consultar un Ticket";
            this._Bt_ConsulTicket.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_ConsulTicket.UseVisualStyleBackColor = true;
            this._Bt_ConsulTicket.Click += new System.EventHandler(this._Bt_ConsulTicket_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(677, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 13);
            this.label10.TabIndex = 52;
            this.label10.Text = "4 - Sin prioridad definida";
            // 
            // _Lbl_Prio4
            // 
            this._Lbl_Prio4.AutoSize = true;
            this._Lbl_Prio4.BackColor = System.Drawing.Color.White;
            this._Lbl_Prio4.Location = new System.Drawing.Point(656, 89);
            this._Lbl_Prio4.Name = "_Lbl_Prio4";
            this._Lbl_Prio4.Size = new System.Drawing.Size(15, 14);
            this._Lbl_Prio4.TabIndex = 51;
            this._Lbl_Prio4.Text = "  ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(677, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(181, 13);
            this.label12.TabIndex = 50;
            this.label12.Text = "3 - (Solución 12 h) (Atención 40h) 5d";
            // 
            // _Lbl_Prio3
            // 
            this._Lbl_Prio3.AutoSize = true;
            this._Lbl_Prio3.BackColor = System.Drawing.Color.White;
            this._Lbl_Prio3.Location = new System.Drawing.Point(656, 74);
            this._Lbl_Prio3.Name = "_Lbl_Prio3";
            this._Lbl_Prio3.Size = new System.Drawing.Size(15, 14);
            this._Lbl_Prio3.TabIndex = 49;
            this._Lbl_Prio3.Text = "  ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(677, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 13);
            this.label8.TabIndex = 48;
            this.label8.Text = "2 - (Solución 8 h) (Atención 20h) 2,5d";
            // 
            // _Lbl_Prio2
            // 
            this._Lbl_Prio2.AutoSize = true;
            this._Lbl_Prio2.BackColor = System.Drawing.Color.White;
            this._Lbl_Prio2.Location = new System.Drawing.Point(656, 59);
            this._Lbl_Prio2.Name = "_Lbl_Prio2";
            this._Lbl_Prio2.Size = new System.Drawing.Size(15, 14);
            this._Lbl_Prio2.TabIndex = 47;
            this._Lbl_Prio2.Text = "  ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(677, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "1 - (Solución 4 h) (Atención 12h) 1,5d";
            // 
            // _Lbl_Prio1
            // 
            this._Lbl_Prio1.AutoSize = true;
            this._Lbl_Prio1.BackColor = System.Drawing.Color.White;
            this._Lbl_Prio1.Location = new System.Drawing.Point(656, 44);
            this._Lbl_Prio1.Name = "_Lbl_Prio1";
            this._Lbl_Prio1.Size = new System.Drawing.Size(15, 14);
            this._Lbl_Prio1.TabIndex = 45;
            this._Lbl_Prio1.Text = "  ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(342, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Prioridad";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _Chk_MostrarF
            // 
            this._Chk_MostrarF.AutoSize = true;
            this._Chk_MostrarF.Checked = true;
            this._Chk_MostrarF.CheckState = System.Windows.Forms.CheckState.Checked;
            this._Chk_MostrarF.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Chk_MostrarF.Location = new System.Drawing.Point(345, 121);
            this._Chk_MostrarF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._Chk_MostrarF.Name = "_Chk_MostrarF";
            this._Chk_MostrarF.Size = new System.Drawing.Size(191, 20);
            this._Chk_MostrarF.TabIndex = 22;
            this._Chk_MostrarF.Text = "Mostrar todas las fechas";
            this._Chk_MostrarF.UseVisualStyleBackColor = true;
            this._Chk_MostrarF.CheckedChanged += new System.EventHandler(this._Chk_MostrarF_CheckedChanged);
            // 
            // _Cmb_Prioridad
            // 
            this._Cmb_Prioridad.Cursor = System.Windows.Forms.Cursors.Default;
            this._Cmb_Prioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Prioridad.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Prioridad.FormattingEnabled = true;
            this._Cmb_Prioridad.Location = new System.Drawing.Point(344, 58);
            this._Cmb_Prioridad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._Cmb_Prioridad.Name = "_Cmb_Prioridad";
            this._Cmb_Prioridad.Size = new System.Drawing.Size(306, 21);
            this._Cmb_Prioridad.TabIndex = 26;
            // 
            // _Cmb_Estado
            // 
            this._Cmb_Estado.Cursor = System.Windows.Forms.Cursors.Default;
            this._Cmb_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Estado.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Estado.FormattingEnabled = true;
            this._Cmb_Estado.Location = new System.Drawing.Point(12, 58);
            this._Cmb_Estado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._Cmb_Estado.Name = "_Cmb_Estado";
            this._Cmb_Estado.Size = new System.Drawing.Size(327, 21);
            this._Cmb_Estado.TabIndex = 24;
            this._Cmb_Estado.SelectedIndexChanged += new System.EventHandler(this._Cmb_Estado_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Estado";
            // 
            // _Dtp_Hasta
            // 
            this._Dtp_Hasta.Enabled = false;
            this._Dtp_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dtp_Hasta.Location = new System.Drawing.Point(464, 96);
            this._Dtp_Hasta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._Dtp_Hasta.Name = "_Dtp_Hasta";
            this._Dtp_Hasta.Size = new System.Drawing.Size(114, 22);
            this._Dtp_Hasta.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(460, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Fecha hasta:";
            // 
            // _Dtp_Desde
            // 
            this._Dtp_Desde.Enabled = false;
            this._Dtp_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dtp_Desde.Location = new System.Drawing.Point(342, 96);
            this._Dtp_Desde.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._Dtp_Desde.Name = "_Dtp_Desde";
            this._Dtp_Desde.Size = new System.Drawing.Size(114, 22);
            this._Dtp_Desde.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(340, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Fecha desde:";
            // 
            // _Cmb_Arquitecto
            // 
            this._Cmb_Arquitecto.Cursor = System.Windows.Forms.Cursors.Default;
            this._Cmb_Arquitecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Arquitecto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Arquitecto.FormattingEnabled = true;
            this._Cmb_Arquitecto.Location = new System.Drawing.Point(564, 20);
            this._Cmb_Arquitecto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._Cmb_Arquitecto.Name = "_Cmb_Arquitecto";
            this._Cmb_Arquitecto.Size = new System.Drawing.Size(306, 21);
            this._Cmb_Arquitecto.TabIndex = 17;
            this._Cmb_Arquitecto.DropDown += new System.EventHandler(this._Cmb_Arquitecto_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(561, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Arquitecto";
            // 
            // _Cmb_Solicitante
            // 
            this._Cmb_Solicitante.Cursor = System.Windows.Forms.Cursors.Default;
            this._Cmb_Solicitante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Solicitante.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Solicitante.FormattingEnabled = true;
            this._Cmb_Solicitante.Location = new System.Drawing.Point(12, 20);
            this._Cmb_Solicitante.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._Cmb_Solicitante.Name = "_Cmb_Solicitante";
            this._Cmb_Solicitante.Size = new System.Drawing.Size(327, 21);
            this._Cmb_Solicitante.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Solicitante";
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.AllowUserToResizeRows = false;
            this._Dg_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ticket,
            this.companydescrip,
            this.titulo,
            this.usersolicitud,
            this.ctipofalla,
            this.asignadoa,
            this.prioridad,
            this.cfechahorareporte,
            this.cdiastrans,
            this.tiempoaproxfin,
            this.cfechahorpausa,
            this.cfechahoracerrado,
            this.estado});
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(0, 169);
            this._Dg_Grid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.Size = new System.Drawing.Size(987, 325);
            this._Dg_Grid.TabIndex = 87;
            this._Dg_Grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseDoubleClick);
            // 
            // Ticket
            // 
            this.Ticket.DataPropertyName = "cticket";
            this.Ticket.HeaderText = "Ticket";
            this.Ticket.Name = "Ticket";
            this.Ticket.ReadOnly = true;
            this.Ticket.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // companydescrip
            // 
            this.companydescrip.DataPropertyName = "companydescrip";
            this.companydescrip.HeaderText = "Compañía";
            this.companydescrip.Name = "companydescrip";
            this.companydescrip.ReadOnly = true;
            // 
            // titulo
            // 
            this.titulo.DataPropertyName = "casunto";
            this.titulo.HeaderText = "Asunto";
            this.titulo.Name = "titulo";
            this.titulo.ReadOnly = true;
            // 
            // usersolicitud
            // 
            this.usersolicitud.DataPropertyName = "csolicitantename";
            this.usersolicitud.HeaderText = "Solicitante";
            this.usersolicitud.Name = "usersolicitud";
            this.usersolicitud.ReadOnly = true;
            // 
            // ctipofalla
            // 
            this.ctipofalla.DataPropertyName = "ctipofalla";
            this.ctipofalla.HeaderText = "Tipo de falla";
            this.ctipofalla.Name = "ctipofalla";
            this.ctipofalla.ReadOnly = true;
            // 
            // asignadoa
            // 
            this.asignadoa.DataPropertyName = "carquitecto";
            this.asignadoa.HeaderText = "Arquitecto";
            this.asignadoa.Name = "asignadoa";
            this.asignadoa.ReadOnly = true;
            // 
            // prioridad
            // 
            this.prioridad.DataPropertyName = "cprioridad";
            this.prioridad.HeaderText = "Prioridad";
            this.prioridad.Name = "prioridad";
            this.prioridad.ReadOnly = true;
            // 
            // cfechahorareporte
            // 
            this.cfechahorareporte.DataPropertyName = "cfechahorareporte";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cfechahorareporte.DefaultCellStyle = dataGridViewCellStyle2;
            this.cfechahorareporte.HeaderText = "Fecha";
            this.cfechahorareporte.Name = "cfechahorareporte";
            this.cfechahorareporte.ReadOnly = true;
            // 
            // cdiastrans
            // 
            this.cdiastrans.DataPropertyName = "cdiastrans";
            this.cdiastrans.HeaderText = "Días trans..";
            this.cdiastrans.Name = "cdiastrans";
            this.cdiastrans.ReadOnly = true;
            // 
            // tiempoaproxfin
            // 
            this.tiempoaproxfin.DataPropertyName = "cfinaprox";
            this.tiempoaproxfin.HeaderText = "Fin aproximado";
            this.tiempoaproxfin.Name = "tiempoaproxfin";
            this.tiempoaproxfin.ReadOnly = true;
            // 
            // cfechahorpausa
            // 
            this.cfechahorpausa.DataPropertyName = "cfechahorpausa";
            this.cfechahorpausa.HeaderText = "Pausado";
            this.cfechahorpausa.Name = "cfechahorpausa";
            this.cfechahorpausa.ReadOnly = true;
            // 
            // cfechahoracerrado
            // 
            this.cfechahoracerrado.DataPropertyName = "cfechahoracerrado";
            this.cfechahoracerrado.HeaderText = "Culminado";
            this.cfechahoracerrado.Name = "cfechahoracerrado";
            this.cfechahoracerrado.ReadOnly = true;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "cestadoname";
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            // 
            // _Pnl_Ticket
            // 
            this._Pnl_Ticket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Ticket.Controls.Add(this._Bt_Consultar_T);
            this._Pnl_Ticket.Controls.Add(this._Txt_Ticket);
            this._Pnl_Ticket.Controls.Add(this._Bt_Cancelar_T);
            this._Pnl_Ticket.Controls.Add(this.label9);
            this._Pnl_Ticket.Controls.Add(this.label11);
            this._Pnl_Ticket.Location = new System.Drawing.Point(188, 122);
            this._Pnl_Ticket.Name = "_Pnl_Ticket";
            this._Pnl_Ticket.Size = new System.Drawing.Size(201, 101);
            this._Pnl_Ticket.TabIndex = 88;
            this._Pnl_Ticket.Visible = false;
            this._Pnl_Ticket.VisibleChanged += new System.EventHandler(this._Pnl_Ticket_VisibleChanged);
            // 
            // _Bt_Consultar_T
            // 
            this._Bt_Consultar_T.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Consultar_T.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Bold);
            this._Bt_Consultar_T.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Consultar_T.Image")));
            this._Bt_Consultar_T.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Consultar_T.Location = new System.Drawing.Point(12, 60);
            this._Bt_Consultar_T.Name = "_Bt_Consultar_T";
            this._Bt_Consultar_T.Size = new System.Drawing.Size(81, 31);
            this._Bt_Consultar_T.TabIndex = 72;
            this._Bt_Consultar_T.Text = "Consultar";
            this._Bt_Consultar_T.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Consultar_T.UseVisualStyleBackColor = true;
            this._Bt_Consultar_T.Click += new System.EventHandler(this._Bt_Consultar_T_Click);
            // 
            // _Txt_Ticket
            // 
            this._Txt_Ticket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Ticket.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Txt_Ticket.Location = new System.Drawing.Point(61, 31);
            this._Txt_Ticket.MaxLength = 100;
            this._Txt_Ticket.Name = "_Txt_Ticket";
            this._Txt_Ticket.Size = new System.Drawing.Size(119, 23);
            this._Txt_Ticket.TabIndex = 2;
            this._Txt_Ticket.TextChanged += new System.EventHandler(this._Txt_Ticket_TextChanged);
            this._Txt_Ticket.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Ticket_KeyPress);
            // 
            // _Bt_Cancelar_T
            // 
            this._Bt_Cancelar_T.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Cancelar_T.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Cancelar_T.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Cancelar_T.Image")));
            this._Bt_Cancelar_T.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Cancelar_T.Location = new System.Drawing.Point(99, 60);
            this._Bt_Cancelar_T.Name = "_Bt_Cancelar_T";
            this._Bt_Cancelar_T.Size = new System.Drawing.Size(81, 31);
            this._Bt_Cancelar_T.TabIndex = 71;
            this._Bt_Cancelar_T.Text = "Cancelar";
            this._Bt_Cancelar_T.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Cancelar_T.UseVisualStyleBackColor = true;
            this._Bt_Cancelar_T.Click += new System.EventHandler(this._Bt_Cancelar_T_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 14);
            this.label9.TabIndex = 68;
            this.label9.Text = "Ticket:";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Navy;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(199, 18);
            this.label11.TabIndex = 0;
            this.label11.Text = "Introduzca Nº de Ticket";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // Frm_ConsultaSolicitudes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 494);
            this.Controls.Add(this._Pnl_Ticket);
            this.Controls.Add(this._Dg_Grid);
            this.Controls.Add(this._Pnl_Filtros);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ConsultaSolicitudes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Solicitudes - T3BUG\'S";
            this.Load += new System.EventHandler(this.Frm_ConsultaSolicitudes_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ConsultaSolicitudes_FormClosing);
            this._Pnl_Filtros.ResumeLayout(false);
            this._Pnl_Filtros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this._Pnl_Ticket.ResumeLayout(false);
            this._Pnl_Ticket.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _Pnl_Filtros;
        private System.Windows.Forms.ComboBox _Cmb_Solicitante;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _Cmb_Arquitecto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker _Dtp_Desde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker _Dtp_Hasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox _Chk_MostrarF;
        private System.Windows.Forms.ComboBox _Cmb_Prioridad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox _Cmb_Estado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label _Lbl_Prio4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label _Lbl_Prio3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label _Lbl_Prio2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label _Lbl_Prio1;
        private System.Windows.Forms.Button _Bt_Limpiar;
        private System.Windows.Forms.Button _Bt_Filtrar;
        private System.Windows.Forms.Button _Bt_ConsulTicket;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.ComboBox _Cmb_TipoFalla;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox _Cmb_Filtrar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel _Pnl_Ticket;
        private System.Windows.Forms.Button _Bt_Consultar_T;
        private System.Windows.Forms.TextBox _Txt_Ticket;
        private System.Windows.Forms.Button _Bt_Cancelar_T;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ticket;
        private System.Windows.Forms.DataGridViewTextBoxColumn companydescrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn usersolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctipofalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn asignadoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn prioridad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cfechahorareporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdiastrans;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempoaproxfin;
        private System.Windows.Forms.DataGridViewTextBoxColumn cfechahorpausa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cfechahoracerrado;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
    }
}

