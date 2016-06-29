namespace T3
{
    partial class Frm_IngCheqDevuelto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_IngCheqDevuelto));
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this.c_nomb_comer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnumcheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfechaemision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmontocheq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cidnotadebitocc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cidcheqdevuelt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this._Ctrl_Busqueda1 = new T3.Controles._Ctrl_Busqueda();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._Pnl_ND_Desc = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this._Rbt_Porcent3 = new System.Windows.Forms.RadioButton();
            this._Rbt_Porcent1 = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this._Lbx_DescuentoPP = new System.Windows.Forms.ListBox();
            this._Pnl_VariosDocument = new System.Windows.Forms.Panel();
            this._Lbx_Documents = new System.Windows.Forms.ListBox();
            this._Pnl_SoloDocumento = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._Txt_Tipo = new System.Windows.Forms.TextBox();
            this._Txt_Documento = new System.Windows.Forms.TextBox();
            this._Txt_Banco = new System.Windows.Forms.TextBox();
            this._Chk_NDDesc = new System.Windows.Forms.CheckBox();
            this._Txt_Ob = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this._Txt_NotaDebBanc = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this._Txt_Vendedor = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this._Txt_Cliente = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this._Bt_NotaDeb = new System.Windows.Forms.Button();
            this._Txt_NotaDeb = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this._Txt_FechaDevolucion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Bt_Buscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._Txt_Id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Txt_NumeroCheq = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this._Cmb_BancoDev = new System.Windows.Forms.ComboBox();
            this._Cmb_Motivo = new System.Windows.Forms.ComboBox();
            this._Txt_Monto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._Txt_FechaEmision = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this.tabPage2.SuspendLayout();
            this._Pnl_ND_Desc.SuspendLayout();
            this._Pnl_VariosDocument.SuspendLayout();
            this._Pnl_SoloDocumento.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this.SuspendLayout();
            // 
            // _Tb_Tab
            // 
            this._Tb_Tab.Controls.Add(this.tabPage1);
            this._Tb_Tab.Controls.Add(this.tabPage2);
            this._Tb_Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Tb_Tab.Location = new System.Drawing.Point(0, 0);
            this._Tb_Tab.Name = "_Tb_Tab";
            this._Tb_Tab.SelectedIndex = 0;
            this._Tb_Tab.Size = new System.Drawing.Size(735, 576);
            this._Tb_Tab.TabIndex = 0;
            this._Tb_Tab.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this._Tb_Tab_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._Dg_Grid);
            this.tabPage1.Controls.Add(this._Lbl_DgInfo);
            this.tabPage1.Controls.Add(this._Ctrl_Busqueda1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(727, 551);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_nomb_comer,
            this.cname,
            this.cnumcheque,
            this.cfechaemision,
            this.cmontocheq,
            this.cdescripcion,
            this.Dias,
            this.cidnotadebitocc,
            this.cidcheqdevuelt,
            this.ccliente});
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(3, 44);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Size = new System.Drawing.Size(721, 492);
            this._Dg_Grid.TabIndex = 1;
            this._Dg_Grid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_CellMouseEnter);
            this._Dg_Grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseDoubleClick);
            // 
            // c_nomb_comer
            // 
            this.c_nomb_comer.DataPropertyName = "c_nomb_comer";
            this.c_nomb_comer.HeaderText = "Cliente";
            this.c_nomb_comer.Name = "c_nomb_comer";
            this.c_nomb_comer.ReadOnly = true;
            // 
            // cname
            // 
            this.cname.DataPropertyName = "cname";
            this.cname.HeaderText = "Banco";
            this.cname.Name = "cname";
            this.cname.ReadOnly = true;
            // 
            // cnumcheque
            // 
            this.cnumcheque.DataPropertyName = "cnumcheque";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cnumcheque.DefaultCellStyle = dataGridViewCellStyle1;
            this.cnumcheque.HeaderText = "Nº Cheque";
            this.cnumcheque.Name = "cnumcheque";
            this.cnumcheque.ReadOnly = true;
            // 
            // cfechaemision
            // 
            this.cfechaemision.DataPropertyName = "cfechaemision";
            this.cfechaemision.HeaderText = "Fecha E.";
            this.cfechaemision.Name = "cfechaemision";
            this.cfechaemision.ReadOnly = true;
            // 
            // cmontocheq
            // 
            this.cmontocheq.DataPropertyName = "cmontocheq";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cmontocheq.DefaultCellStyle = dataGridViewCellStyle2;
            this.cmontocheq.HeaderText = "Monto";
            this.cmontocheq.Name = "cmontocheq";
            this.cmontocheq.ReadOnly = true;
            // 
            // cdescripcion
            // 
            this.cdescripcion.DataPropertyName = "cdescripcion";
            this.cdescripcion.HeaderText = "Motivo";
            this.cdescripcion.Name = "cdescripcion";
            this.cdescripcion.ReadOnly = true;
            // 
            // Dias
            // 
            this.Dias.DataPropertyName = "Dias";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Dias.DefaultCellStyle = dataGridViewCellStyle3;
            this.Dias.HeaderText = "Días T.";
            this.Dias.Name = "Dias";
            this.Dias.ReadOnly = true;
            // 
            // cidnotadebitocc
            // 
            this.cidnotadebitocc.DataPropertyName = "cidnotadebitocc";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cidnotadebitocc.DefaultCellStyle = dataGridViewCellStyle4;
            this.cidnotadebitocc.HeaderText = "ND";
            this.cidnotadebitocc.Name = "cidnotadebitocc";
            this.cidnotadebitocc.ReadOnly = true;
            // 
            // cidcheqdevuelt
            // 
            this.cidcheqdevuelt.DataPropertyName = "cidcheqdevuelt";
            this.cidcheqdevuelt.HeaderText = "cidcheqdevuelt";
            this.cidcheqdevuelt.Name = "cidcheqdevuelt";
            this.cidcheqdevuelt.ReadOnly = true;
            this.cidcheqdevuelt.Visible = false;
            // 
            // ccliente
            // 
            this.ccliente.DataPropertyName = "ccliente";
            this.ccliente.HeaderText = "ccliente";
            this.ccliente.Name = "ccliente";
            this.ccliente.ReadOnly = true;
            this.ccliente.Visible = false;
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(3, 536);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(721, 12);
            this._Lbl_DgInfo.TabIndex = 6;
            this._Lbl_DgInfo.Text = "Use doble click";
            this._Lbl_DgInfo.Visible = false;
            // 
            // _Ctrl_Busqueda1
            // 
            this._Ctrl_Busqueda1.Dock = System.Windows.Forms.DockStyle.Top;
            this._Ctrl_Busqueda1.Location = new System.Drawing.Point(3, 3);
            this._Ctrl_Busqueda1.Name = "_Ctrl_Busqueda1";
            this._Ctrl_Busqueda1.Size = new System.Drawing.Size(721, 41);
            this._Ctrl_Busqueda1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._Pnl_ND_Desc);
            this.tabPage2.Controls.Add(this._Pnl_VariosDocument);
            this.tabPage2.Controls.Add(this._Pnl_SoloDocumento);
            this.tabPage2.Controls.Add(this._Txt_Banco);
            this.tabPage2.Controls.Add(this._Chk_NDDesc);
            this.tabPage2.Controls.Add(this._Txt_Ob);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this._Txt_NotaDebBanc);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this._Txt_Vendedor);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this._Txt_Cliente);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this._Bt_NotaDeb);
            this.tabPage2.Controls.Add(this._Txt_NotaDeb);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this._Txt_FechaDevolucion);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this._Cmb_Motivo);
            this.tabPage2.Controls.Add(this._Txt_Monto);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this._Txt_FechaEmision);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(727, 551);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _Pnl_ND_Desc
            // 
            this._Pnl_ND_Desc.Controls.Add(this.label17);
            this._Pnl_ND_Desc.Controls.Add(this._Rbt_Porcent3);
            this._Pnl_ND_Desc.Controls.Add(this._Rbt_Porcent1);
            this._Pnl_ND_Desc.Controls.Add(this.label16);
            this._Pnl_ND_Desc.Controls.Add(this._Lbx_DescuentoPP);
            this._Pnl_ND_Desc.Location = new System.Drawing.Point(3, 477);
            this._Pnl_ND_Desc.Name = "_Pnl_ND_Desc";
            this._Pnl_ND_Desc.Size = new System.Drawing.Size(667, 68);
            this._Pnl_ND_Desc.TabIndex = 32;
            this._Pnl_ND_Desc.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(338, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(124, 12);
            this.label17.TabIndex = 25;
            this.label17.Text = "Descuento pronto pago:";
            // 
            // _Rbt_Porcent3
            // 
            this._Rbt_Porcent3.AutoSize = true;
            this._Rbt_Porcent3.Location = new System.Drawing.Point(521, 6);
            this._Rbt_Porcent3.Name = "_Rbt_Porcent3";
            this._Rbt_Porcent3.Size = new System.Drawing.Size(44, 16);
            this._Rbt_Porcent3.TabIndex = 24;
            this._Rbt_Porcent3.Text = "3 %";
            this._Rbt_Porcent3.UseVisualStyleBackColor = true;
            // 
            // _Rbt_Porcent1
            // 
            this._Rbt_Porcent1.AutoSize = true;
            this._Rbt_Porcent1.Checked = true;
            this._Rbt_Porcent1.Location = new System.Drawing.Point(471, 6);
            this._Rbt_Porcent1.Name = "_Rbt_Porcent1";
            this._Rbt_Porcent1.Size = new System.Drawing.Size(44, 16);
            this._Rbt_Porcent1.TabIndex = 23;
            this._Rbt_Porcent1.TabStop = true;
            this._Rbt_Porcent1.Text = "1 %";
            this._Rbt_Porcent1.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(5, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(124, 12);
            this.label16.TabIndex = 22;
            this.label16.Text = "Descuento pronto pago:";
            // 
            // _Lbx_DescuentoPP
            // 
            this._Lbx_DescuentoPP.BackColor = System.Drawing.SystemColors.Control;
            this._Lbx_DescuentoPP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Lbx_DescuentoPP.FormattingEnabled = true;
            this._Lbx_DescuentoPP.ItemHeight = 12;
            this._Lbx_DescuentoPP.Location = new System.Drawing.Point(7, 25);
            this._Lbx_DescuentoPP.Name = "_Lbx_DescuentoPP";
            this._Lbx_DescuentoPP.Size = new System.Drawing.Size(325, 38);
            this._Lbx_DescuentoPP.TabIndex = 0;
            // 
            // _Pnl_VariosDocument
            // 
            this._Pnl_VariosDocument.Controls.Add(this._Lbx_Documents);
            this._Pnl_VariosDocument.Location = new System.Drawing.Point(334, 237);
            this._Pnl_VariosDocument.Name = "_Pnl_VariosDocument";
            this._Pnl_VariosDocument.Size = new System.Drawing.Size(358, 74);
            this._Pnl_VariosDocument.TabIndex = 31;
            this._Pnl_VariosDocument.Visible = false;
            // 
            // _Lbx_Documents
            // 
            this._Lbx_Documents.BackColor = System.Drawing.SystemColors.Control;
            this._Lbx_Documents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Lbx_Documents.FormattingEnabled = true;
            this._Lbx_Documents.ItemHeight = 12;
            this._Lbx_Documents.Location = new System.Drawing.Point(11, 30);
            this._Lbx_Documents.Name = "_Lbx_Documents";
            this._Lbx_Documents.Size = new System.Drawing.Size(325, 38);
            this._Lbx_Documents.TabIndex = 0;
            // 
            // _Pnl_SoloDocumento
            // 
            this._Pnl_SoloDocumento.Controls.Add(this.label7);
            this._Pnl_SoloDocumento.Controls.Add(this.label6);
            this._Pnl_SoloDocumento.Controls.Add(this._Txt_Tipo);
            this._Pnl_SoloDocumento.Controls.Add(this._Txt_Documento);
            this._Pnl_SoloDocumento.Location = new System.Drawing.Point(341, 237);
            this._Pnl_SoloDocumento.Name = "_Pnl_SoloDocumento";
            this._Pnl_SoloDocumento.Size = new System.Drawing.Size(331, 59);
            this._Pnl_SoloDocumento.TabIndex = 30;
            this._Pnl_SoloDocumento.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(171, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "Nº Documento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tipo:";
            // 
            // _Txt_Tipo
            // 
            this._Txt_Tipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Tipo.Location = new System.Drawing.Point(2, 30);
            this._Txt_Tipo.Name = "_Txt_Tipo";
            this._Txt_Tipo.ReadOnly = true;
            this._Txt_Tipo.Size = new System.Drawing.Size(148, 18);
            this._Txt_Tipo.TabIndex = 10;
            // 
            // _Txt_Documento
            // 
            this._Txt_Documento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Documento.Location = new System.Drawing.Point(173, 30);
            this._Txt_Documento.Name = "_Txt_Documento";
            this._Txt_Documento.ReadOnly = true;
            this._Txt_Documento.Size = new System.Drawing.Size(143, 18);
            this._Txt_Documento.TabIndex = 12;
            this._Txt_Documento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _Txt_Banco
            // 
            this._Txt_Banco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Banco.Location = new System.Drawing.Point(134, 363);
            this._Txt_Banco.Name = "_Txt_Banco";
            this._Txt_Banco.ReadOnly = true;
            this._Txt_Banco.Size = new System.Drawing.Size(538, 18);
            this._Txt_Banco.TabIndex = 29;
            // 
            // _Chk_NDDesc
            // 
            this._Chk_NDDesc.AutoSize = true;
            this._Chk_NDDesc.Enabled = false;
            this._Chk_NDDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Chk_NDDesc.Location = new System.Drawing.Point(9, 452);
            this._Chk_NDDesc.Name = "_Chk_NDDesc";
            this._Chk_NDDesc.Size = new System.Drawing.Size(212, 16);
            this._Chk_NDDesc.TabIndex = 26;
            this._Chk_NDDesc.Text = "Generar ND por descuento financiero?";
            this._Chk_NDDesc.UseVisualStyleBackColor = true;
            this._Chk_NDDesc.CheckedChanged += new System.EventHandler(this._Chk_NDDesc_CheckedChanged);
            // 
            // _Txt_Ob
            // 
            this._Txt_Ob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Ob.Enabled = false;
            this._Txt_Ob.Location = new System.Drawing.Point(9, 412);
            this._Txt_Ob.MaxLength = 250;
            this._Txt_Ob.Name = "_Txt_Ob";
            this._Txt_Ob.Size = new System.Drawing.Size(661, 18);
            this._Txt_Ob.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(134, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Banco";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(7, 397);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 12);
            this.label15.TabIndex = 19;
            this.label15.Text = "Observación";
            // 
            // _Txt_NotaDebBanc
            // 
            this._Txt_NotaDebBanc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_NotaDebBanc.Enabled = false;
            this._Txt_NotaDebBanc.Location = new System.Drawing.Point(223, 453);
            this._Txt_NotaDebBanc.MaxLength = 50;
            this._Txt_NotaDebBanc.Name = "_Txt_NotaDebBanc";
            this._Txt_NotaDebBanc.Size = new System.Drawing.Size(119, 18);
            this._Txt_NotaDebBanc.TabIndex = 22;
            this._Txt_NotaDebBanc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Txt_NotaDebBanc.TextChanged += new System.EventHandler(this._Txt_NotaDebBanc_TextChanged);
            this._Txt_NotaDebBanc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_NotaDebBanc_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(221, 438);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 12);
            this.label14.TabIndex = 21;
            this.label14.Text = "ND del banco";
            // 
            // _Txt_Vendedor
            // 
            this._Txt_Vendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Vendedor.Location = new System.Drawing.Point(11, 217);
            this._Txt_Vendedor.Name = "_Txt_Vendedor";
            this._Txt_Vendedor.ReadOnly = true;
            this._Txt_Vendedor.Size = new System.Drawing.Size(661, 18);
            this._Txt_Vendedor.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(9, 202);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 12);
            this.label13.TabIndex = 3;
            this.label13.Text = "Vendedor:";
            // 
            // _Txt_Cliente
            // 
            this._Txt_Cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Cliente.Location = new System.Drawing.Point(10, 166);
            this._Txt_Cliente.Name = "_Txt_Cliente";
            this._Txt_Cliente.ReadOnly = true;
            this._Txt_Cliente.Size = new System.Drawing.Size(661, 18);
            this._Txt_Cliente.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 151);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "Cliente:";
            // 
            // _Bt_NotaDeb
            // 
            this._Bt_NotaDeb.Enabled = false;
            this._Bt_NotaDeb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_NotaDeb.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_NotaDeb.Image")));
            this._Bt_NotaDeb.Location = new System.Drawing.Point(469, 451);
            this._Bt_NotaDeb.Name = "_Bt_NotaDeb";
            this._Bt_NotaDeb.Size = new System.Drawing.Size(25, 20);
            this._Bt_NotaDeb.TabIndex = 25;
            this._Bt_NotaDeb.UseVisualStyleBackColor = true;
            this._Bt_NotaDeb.Click += new System.EventHandler(this._Bt_NotaDeb_Click);
            // 
            // _Txt_NotaDeb
            // 
            this._Txt_NotaDeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_NotaDeb.Location = new System.Drawing.Point(357, 453);
            this._Txt_NotaDeb.Name = "_Txt_NotaDeb";
            this._Txt_NotaDeb.ReadOnly = true;
            this._Txt_NotaDeb.Size = new System.Drawing.Size(106, 18);
            this._Txt_NotaDeb.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(355, 438);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 12);
            this.label11.TabIndex = 23;
            this.label11.Text = "ND:";
            // 
            // _Txt_FechaDevolucion
            // 
            this._Txt_FechaDevolucion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_FechaDevolucion.Location = new System.Drawing.Point(9, 363);
            this._Txt_FechaDevolucion.Name = "_Txt_FechaDevolucion";
            this._Txt_FechaDevolucion.ReadOnly = true;
            this._Txt_FechaDevolucion.Size = new System.Drawing.Size(119, 18);
            this._Txt_FechaDevolucion.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 348);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "Fecha devolución:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 299);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "Motivo:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this._Bt_Buscar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._Txt_Id);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._Txt_NumeroCheq);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this._Cmb_BancoDev);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(721, 131);
            this.panel1.TabIndex = 0;
            // 
            // _Bt_Buscar
            // 
            this._Bt_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Buscar.Image")));
            this._Bt_Buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Buscar.Location = new System.Drawing.Point(9, 85);
            this._Bt_Buscar.Name = "_Bt_Buscar";
            this._Bt_Buscar.Size = new System.Drawing.Size(145, 31);
            this._Bt_Buscar.TabIndex = 6;
            this._Bt_Buscar.Text = "Buscar cheque!!";
            this._Bt_Buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Buscar.UseVisualStyleBackColor = true;
            this._Bt_Buscar.Click += new System.EventHandler(this._Bt_Buscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id:";
            // 
            // _Txt_Id
            // 
            this._Txt_Id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Id.Enabled = false;
            this._Txt_Id.Location = new System.Drawing.Point(7, 17);
            this._Txt_Id.Name = "_Txt_Id";
            this._Txt_Id.ReadOnly = true;
            this._Txt_Id.Size = new System.Drawing.Size(72, 18);
            this._Txt_Id.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(165, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nº Cheque:";
            // 
            // _Txt_NumeroCheq
            // 
            this._Txt_NumeroCheq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_NumeroCheq.Enabled = false;
            this._Txt_NumeroCheq.Location = new System.Drawing.Point(167, 98);
            this._Txt_NumeroCheq.Name = "_Txt_NumeroCheq";
            this._Txt_NumeroCheq.Size = new System.Drawing.Size(120, 18);
            this._Txt_NumeroCheq.TabIndex = 5;
            this._Txt_NumeroCheq.TextChanged += new System.EventHandler(this._Txt_NumeroCheq_TextChanged);
            this._Txt_NumeroCheq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_NumeroCheq_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "Banco que devuelve:";
            // 
            // _Cmb_BancoDev
            // 
            this._Cmb_BancoDev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_BancoDev.Enabled = false;
            this._Cmb_BancoDev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_BancoDev.FormattingEnabled = true;
            this._Cmb_BancoDev.Location = new System.Drawing.Point(8, 53);
            this._Cmb_BancoDev.Name = "_Cmb_BancoDev";
            this._Cmb_BancoDev.Size = new System.Drawing.Size(386, 20);
            this._Cmb_BancoDev.TabIndex = 18;
            this._Cmb_BancoDev.DropDown += new System.EventHandler(this._Cmb_BancoDev_DropDown);
            this._Cmb_BancoDev.SelectedIndexChanged += new System.EventHandler(this._Cmb_BancoDev_SelectedIndexChanged);
            // 
            // _Cmb_Motivo
            // 
            this._Cmb_Motivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Motivo.Enabled = false;
            this._Cmb_Motivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Motivo.FormattingEnabled = true;
            this._Cmb_Motivo.Location = new System.Drawing.Point(9, 314);
            this._Cmb_Motivo.Name = "_Cmb_Motivo";
            this._Cmb_Motivo.Size = new System.Drawing.Size(661, 20);
            this._Cmb_Motivo.TabIndex = 14;
            this._Cmb_Motivo.DropDown += new System.EventHandler(this._Cmb_Motivo_DropDown);
            this._Cmb_Motivo.SelectedIndexChanged += new System.EventHandler(this._Cmb_Motivo_SelectedIndexChanged);
            // 
            // _Txt_Monto
            // 
            this._Txt_Monto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Monto.Location = new System.Drawing.Point(170, 267);
            this._Txt_Monto.Name = "_Txt_Monto";
            this._Txt_Monto.ReadOnly = true;
            this._Txt_Monto.Size = new System.Drawing.Size(158, 18);
            this._Txt_Monto.TabIndex = 8;
            this._Txt_Monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(168, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "Monto:";
            // 
            // _Txt_FechaEmision
            // 
            this._Txt_FechaEmision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_FechaEmision.Location = new System.Drawing.Point(10, 267);
            this._Txt_FechaEmision.Name = "_Txt_FechaEmision";
            this._Txt_FechaEmision.ReadOnly = true;
            this._Txt_FechaEmision.Size = new System.Drawing.Size(137, 18);
            this._Txt_FechaEmision.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fecha emisión:";
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // Frm_IngCheqDevuelto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 576);
            this.Controls.Add(this._Tb_Tab);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_IngCheqDevuelto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso de cheques devueltos";
            this.Activated += new System.EventHandler(this.Frm_IngCheqDevuelto_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_IngCheqDevuelto_FormClosing);
            this.Load += new System.EventHandler(this.Frm_IngCheqDevuelto_Load);
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this._Pnl_ND_Desc.ResumeLayout(false);
            this._Pnl_ND_Desc.PerformLayout();
            this._Pnl_VariosDocument.ResumeLayout(false);
            this._Pnl_SoloDocumento.ResumeLayout(false);
            this._Pnl_SoloDocumento.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private T3.Controles._Ctrl_Busqueda _Ctrl_Busqueda1;
        private System.Windows.Forms.TextBox _Txt_Id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _Txt_NumeroCheq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _Bt_Buscar;
        private System.Windows.Forms.TextBox _Txt_FechaEmision;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _Txt_Monto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox _Cmb_Motivo;
        private System.Windows.Forms.TextBox _Txt_Documento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _Txt_Tipo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox _Txt_FechaDevolucion;
        private System.Windows.Forms.ComboBox _Cmb_BancoDev;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button _Bt_NotaDeb;
        private System.Windows.Forms.TextBox _Txt_NotaDeb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox _Txt_Vendedor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox _Txt_Cliente;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_nomb_comer;
        private System.Windows.Forms.DataGridViewTextBoxColumn cname;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnumcheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn cfechaemision;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmontocheq;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dias;
        private System.Windows.Forms.DataGridViewTextBoxColumn cidnotadebitocc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cidcheqdevuelt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccliente;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.TextBox _Txt_NotaDebBanc;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox _Txt_Ob;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label _Lbl_DgInfo;
        private System.Windows.Forms.CheckBox _Chk_NDDesc;
        private System.Windows.Forms.TextBox _Txt_Banco;
        private System.Windows.Forms.Panel _Pnl_SoloDocumento;
        private System.Windows.Forms.Panel _Pnl_VariosDocument;
        private System.Windows.Forms.ListBox _Lbx_Documents;
        private System.Windows.Forms.Panel _Pnl_ND_Desc;
        private System.Windows.Forms.RadioButton _Rbt_Porcent1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ListBox _Lbx_DescuentoPP;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RadioButton _Rbt_Porcent3;
    }
}