namespace T3
{
    partial class Frm_AjusteSalida
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AjusteSalida));
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this._Ctrl_Busqueda1 = new T3.Controles._Ctrl_Busqueda();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._Dg_Grid2 = new System.Windows.Forms.DataGridView();
            this.cproducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cidlote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cprecioventamax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdescrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccajas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cunid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIDPRODUCTOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Pnl_Descripcion = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this._Txt_Descripcion = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this._Bt_Imprimir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._Txt_Costo = new System.Windows.Forms.TextBox();
            this._Txt_Impuesto = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Grb_Firma = new System.Windows.Forms.GroupBox();
            this._Bt_EliminarAprobador2 = new System.Windows.Forms.Button();
            this._Bt_EliminarAprobador1 = new System.Windows.Forms.Button();
            this._Txt_FirmaAprobador2 = new System.Windows.Forms.TextBox();
            this._Txt_FirmaAprobador1 = new System.Windows.Forms.TextBox();
            this._Bt_FirmaAprobador2 = new System.Windows.Forms.Button();
            this._Bt_FirmaAprobador1 = new System.Windows.Forms.Button();
            this.lblAprobador2 = new System.Windows.Forms.Label();
            this.lblAprobador1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._Txt_NotaEntrega = new System.Windows.Forms.TextBox();
            this._Txt_Numero = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._Txt_Fecha = new System.Windows.Forms.TextBox();
            this._Cmb_Motivo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Pnl_Clave = new System.Windows.Forms.Panel();
            this._Bt_Aceptar = new System.Windows.Forms.Button();
            this._Lbl_Titulo = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this._Txt_Clave = new System.Windows.Forms.TextBox();
            this._Bt_Cancelar = new System.Windows.Forms.Button();
            this._Lbl_TituloClave = new System.Windows.Forms.Label();
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid2)).BeginInit();
            this._Pnl_Descripcion.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this._Grb_Firma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this._Pnl_Clave.SuspendLayout();
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
            this._Tb_Tab.Size = new System.Drawing.Size(598, 508);
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
            this.tabPage1.Size = new System.Drawing.Size(590, 483);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Dg_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(3, 47);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Size = new System.Drawing.Size(584, 421);
            this._Dg_Grid.TabIndex = 1;
            this._Dg_Grid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_CellMouseEnter);
            this._Dg_Grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseDoubleClick);
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(3, 468);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(584, 12);
            this._Lbl_DgInfo.TabIndex = 2;
            this._Lbl_DgInfo.Text = "Use doble click";
            this._Lbl_DgInfo.Visible = false;
            // 
            // _Ctrl_Busqueda1
            // 
            this._Ctrl_Busqueda1.Dock = System.Windows.Forms.DockStyle.Top;
            this._Ctrl_Busqueda1.Location = new System.Drawing.Point(3, 3);
            this._Ctrl_Busqueda1.Name = "_Ctrl_Busqueda1";
            this._Ctrl_Busqueda1.Size = new System.Drawing.Size(584, 44);
            this._Ctrl_Busqueda1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._Dg_Grid2);
            this.tabPage2.Controls.Add(this._Pnl_Descripcion);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(590, 483);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _Dg_Grid2
            // 
            this._Dg_Grid2.AllowUserToAddRows = false;
            this._Dg_Grid2.AllowUserToDeleteRows = false;
            this._Dg_Grid2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._Dg_Grid2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this._Dg_Grid2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cproducto,
            this.Column14,
            this.cidlote,
            this.cprecioventamax,
            this.cdescrip,
            this.ccajas,
            this.cunid,
            this.CIDPRODUCTOD});
            this._Dg_Grid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid2.Location = new System.Drawing.Point(3, 149);
            this._Dg_Grid2.Name = "_Dg_Grid2";
            this._Dg_Grid2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid2.Size = new System.Drawing.Size(584, 233);
            this._Dg_Grid2.TabIndex = 4;
            this._Dg_Grid2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid2_CellClick);
            this._Dg_Grid2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid2_CellEndEdit);
            this._Dg_Grid2.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid2_CellEnter);
            this._Dg_Grid2.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this._Dg_Grid2_EditingControlShowing);
            this._Dg_Grid2.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this._Dg_Grid2_RowsRemoved);
            this._Dg_Grid2.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this._Dg_Grid2_UserDeletingRow);
            // 
            // cproducto
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cproducto.DefaultCellStyle = dataGridViewCellStyle5;
            this.cproducto.HeaderText = "Producto";
            this.cproducto.Name = "cproducto";
            this.cproducto.ReadOnly = true;
            this.cproducto.Width = 74;
            // 
            // Column14
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Column14.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column14.HeaderText = "...";
            this.Column14.Name = "Column14";
            this.Column14.Width = 19;
            // 
            // cidlote
            // 
            this.cidlote.HeaderText = "Lote";
            this.cidlote.Name = "cidlote";
            this.cidlote.ReadOnly = true;
            this.cidlote.Width = 51;
            // 
            // cprecioventamax
            // 
            this.cprecioventamax.HeaderText = "PMV";
            this.cprecioventamax.Name = "cprecioventamax";
            this.cprecioventamax.ReadOnly = true;
            this.cprecioventamax.Width = 53;
            // 
            // cdescrip
            // 
            this.cdescrip.HeaderText = "Descripción";
            this.cdescrip.Name = "cdescrip";
            this.cdescrip.ReadOnly = true;
            this.cdescrip.Width = 89;
            // 
            // ccajas
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ccajas.DefaultCellStyle = dataGridViewCellStyle7;
            this.ccajas.HeaderText = "Cajas";
            this.ccajas.MaxInputLength = 9;
            this.ccajas.Name = "ccajas";
            this.ccajas.Width = 58;
            // 
            // cunid
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cunid.DefaultCellStyle = dataGridViewCellStyle8;
            this.cunid.HeaderText = "Unidades";
            this.cunid.MaxInputLength = 9;
            this.cunid.Name = "cunid";
            this.cunid.Width = 76;
            // 
            // CIDPRODUCTOD
            // 
            this.CIDPRODUCTOD.HeaderText = "CIDPRODUCTOD";
            this.CIDPRODUCTOD.Name = "CIDPRODUCTOD";
            this.CIDPRODUCTOD.ReadOnly = true;
            this.CIDPRODUCTOD.Visible = false;
            this.CIDPRODUCTOD.Width = 122;
            // 
            // _Pnl_Descripcion
            // 
            this._Pnl_Descripcion.Controls.Add(this.label6);
            this._Pnl_Descripcion.Controls.Add(this._Txt_Descripcion);
            this._Pnl_Descripcion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Pnl_Descripcion.Location = new System.Drawing.Point(3, 382);
            this._Pnl_Descripcion.Name = "_Pnl_Descripcion";
            this._Pnl_Descripcion.Size = new System.Drawing.Size(584, 53);
            this._Pnl_Descripcion.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "Descripción:";
            // 
            // _Txt_Descripcion
            // 
            this._Txt_Descripcion.BackColor = System.Drawing.Color.White;
            this._Txt_Descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Descripcion.Enabled = false;
            this._Txt_Descripcion.Location = new System.Drawing.Point(16, 24);
            this._Txt_Descripcion.Name = "_Txt_Descripcion";
            this._Txt_Descripcion.Size = new System.Drawing.Size(548, 18);
            this._Txt_Descripcion.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this._Txt_Costo);
            this.panel2.Controls.Add(this._Txt_Impuesto);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 435);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(584, 45);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._Bt_Imprimir);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(274, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(310, 45);
            this.panel3.TabIndex = 4;
            // 
            // _Bt_Imprimir
            // 
            this._Bt_Imprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Imprimir.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Imprimir.Image")));
            this._Bt_Imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Imprimir.Location = new System.Drawing.Point(162, 5);
            this._Bt_Imprimir.Name = "_Bt_Imprimir";
            this._Bt_Imprimir.Size = new System.Drawing.Size(143, 35);
            this._Bt_Imprimir.TabIndex = 1;
            this._Bt_Imprimir.Text = "Imprimir";
            this._Bt_Imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Imprimir.UseVisualStyleBackColor = true;
            this._Bt_Imprimir.Visible = false;
            this._Bt_Imprimir.Click += new System.EventHandler(this._Bt_Imprimir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Costo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(144, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Impuesto:";
            // 
            // _Txt_Costo
            // 
            this._Txt_Costo.BackColor = System.Drawing.Color.White;
            this._Txt_Costo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Costo.Enabled = false;
            this._Txt_Costo.Location = new System.Drawing.Point(16, 21);
            this._Txt_Costo.Name = "_Txt_Costo";
            this._Txt_Costo.ReadOnly = true;
            this._Txt_Costo.Size = new System.Drawing.Size(122, 18);
            this._Txt_Costo.TabIndex = 1;
            this._Txt_Costo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _Txt_Impuesto
            // 
            this._Txt_Impuesto.BackColor = System.Drawing.Color.White;
            this._Txt_Impuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Impuesto.Enabled = false;
            this._Txt_Impuesto.Location = new System.Drawing.Point(146, 21);
            this._Txt_Impuesto.Name = "_Txt_Impuesto";
            this._Txt_Impuesto.ReadOnly = true;
            this._Txt_Impuesto.Size = new System.Drawing.Size(122, 18);
            this._Txt_Impuesto.TabIndex = 3;
            this._Txt_Impuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Grb_Firma);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this._Txt_NotaEntrega);
            this.panel1.Controls.Add(this._Txt_Numero);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this._Txt_Fecha);
            this.panel1.Controls.Add(this._Cmb_Motivo);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 146);
            this.panel1.TabIndex = 3;
            // 
            // _Grb_Firma
            // 
            this._Grb_Firma.Controls.Add(this._Bt_EliminarAprobador2);
            this._Grb_Firma.Controls.Add(this._Bt_EliminarAprobador1);
            this._Grb_Firma.Controls.Add(this._Txt_FirmaAprobador2);
            this._Grb_Firma.Controls.Add(this._Txt_FirmaAprobador1);
            this._Grb_Firma.Controls.Add(this._Bt_FirmaAprobador2);
            this._Grb_Firma.Controls.Add(this._Bt_FirmaAprobador1);
            this._Grb_Firma.Controls.Add(this.lblAprobador2);
            this._Grb_Firma.Controls.Add(this.lblAprobador1);
            this._Grb_Firma.Location = new System.Drawing.Point(331, 7);
            this._Grb_Firma.Name = "_Grb_Firma";
            this._Grb_Firma.Size = new System.Drawing.Size(248, 101);
            this._Grb_Firma.TabIndex = 23;
            this._Grb_Firma.TabStop = false;
            this._Grb_Firma.Text = "Firmas";
            // 
            // _Bt_EliminarAprobador2
            // 
            this._Bt_EliminarAprobador2.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_EliminarAprobador2.Image")));
            this._Bt_EliminarAprobador2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this._Bt_EliminarAprobador2.Location = new System.Drawing.Point(206, 63);
            this._Bt_EliminarAprobador2.Name = "_Bt_EliminarAprobador2";
            this._Bt_EliminarAprobador2.Size = new System.Drawing.Size(27, 24);
            this._Bt_EliminarAprobador2.TabIndex = 32;
            this._Bt_EliminarAprobador2.UseVisualStyleBackColor = true;
            this._Bt_EliminarAprobador2.Click += new System.EventHandler(this._Bt_EliminarAprobador2_Click);
            // 
            // _Bt_EliminarAprobador1
            // 
            this._Bt_EliminarAprobador1.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_EliminarAprobador1.Image")));
            this._Bt_EliminarAprobador1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this._Bt_EliminarAprobador1.Location = new System.Drawing.Point(206, 31);
            this._Bt_EliminarAprobador1.Name = "_Bt_EliminarAprobador1";
            this._Bt_EliminarAprobador1.Size = new System.Drawing.Size(27, 24);
            this._Bt_EliminarAprobador1.TabIndex = 31;
            this._Bt_EliminarAprobador1.UseVisualStyleBackColor = true;
            this._Bt_EliminarAprobador1.Click += new System.EventHandler(this._Bt_EliminarAprobador1_Click);
            // 
            // _Txt_FirmaAprobador2
            // 
            this._Txt_FirmaAprobador2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_FirmaAprobador2.Location = new System.Drawing.Point(47, 69);
            this._Txt_FirmaAprobador2.Name = "_Txt_FirmaAprobador2";
            this._Txt_FirmaAprobador2.ReadOnly = true;
            this._Txt_FirmaAprobador2.Size = new System.Drawing.Size(154, 18);
            this._Txt_FirmaAprobador2.TabIndex = 23;
            // 
            // _Txt_FirmaAprobador1
            // 
            this._Txt_FirmaAprobador1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_FirmaAprobador1.Location = new System.Drawing.Point(46, 36);
            this._Txt_FirmaAprobador1.Name = "_Txt_FirmaAprobador1";
            this._Txt_FirmaAprobador1.ReadOnly = true;
            this._Txt_FirmaAprobador1.Size = new System.Drawing.Size(154, 18);
            this._Txt_FirmaAprobador1.TabIndex = 0;
            // 
            // _Bt_FirmaAprobador2
            // 
            this._Bt_FirmaAprobador2.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_FirmaAprobador2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_FirmaAprobador2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_FirmaAprobador2.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_FirmaAprobador2.Image")));
            this._Bt_FirmaAprobador2.Location = new System.Drawing.Point(8, 59);
            this._Bt_FirmaAprobador2.Name = "_Bt_FirmaAprobador2";
            this._Bt_FirmaAprobador2.Size = new System.Drawing.Size(33, 28);
            this._Bt_FirmaAprobador2.TabIndex = 28;
            this._Bt_FirmaAprobador2.UseVisualStyleBackColor = true;
            this._Bt_FirmaAprobador2.EnabledChanged += new System.EventHandler(this._Bt_FirmaAprobador2_EnabledChanged);
            this._Bt_FirmaAprobador2.Click += new System.EventHandler(this._Bt_FirmaAprobador2_Click);
            // 
            // _Bt_FirmaAprobador1
            // 
            this._Bt_FirmaAprobador1.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_FirmaAprobador1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_FirmaAprobador1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_FirmaAprobador1.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_FirmaAprobador1.Image")));
            this._Bt_FirmaAprobador1.Location = new System.Drawing.Point(8, 27);
            this._Bt_FirmaAprobador1.Name = "_Bt_FirmaAprobador1";
            this._Bt_FirmaAprobador1.Size = new System.Drawing.Size(33, 28);
            this._Bt_FirmaAprobador1.TabIndex = 27;
            this._Bt_FirmaAprobador1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_FirmaAprobador1.UseVisualStyleBackColor = true;
            this._Bt_FirmaAprobador1.EnabledChanged += new System.EventHandler(this._Bt_FirmaAprobador1_EnabledChanged);
            this._Bt_FirmaAprobador1.Click += new System.EventHandler(this._Bt_FirmaAprobador1_Click);
            // 
            // lblAprobador2
            // 
            this.lblAprobador2.AutoSize = true;
            this.lblAprobador2.Location = new System.Drawing.Point(46, 54);
            this.lblAprobador2.Name = "lblAprobador2";
            this.lblAprobador2.Size = new System.Drawing.Size(67, 12);
            this.lblAprobador2.TabIndex = 24;
            this.lblAprobador2.Text = "Aprobador 2";
            // 
            // lblAprobador1
            // 
            this.lblAprobador1.AutoSize = true;
            this.lblAprobador1.Location = new System.Drawing.Point(45, 21);
            this.lblAprobador1.Name = "lblAprobador1";
            this.lblAprobador1.Size = new System.Drawing.Size(67, 12);
            this.lblAprobador1.TabIndex = 22;
            this.lblAprobador1.Text = "Aprobador 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nº Nota Entrega:";
            // 
            // _Txt_NotaEntrega
            // 
            this._Txt_NotaEntrega.BackColor = System.Drawing.Color.White;
            this._Txt_NotaEntrega.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_NotaEntrega.Enabled = false;
            this._Txt_NotaEntrega.Location = new System.Drawing.Point(16, 65);
            this._Txt_NotaEntrega.MaxLength = 9;
            this._Txt_NotaEntrega.Name = "_Txt_NotaEntrega";
            this._Txt_NotaEntrega.Size = new System.Drawing.Size(72, 18);
            this._Txt_NotaEntrega.TabIndex = 7;
            this._Txt_NotaEntrega.TextChanged += new System.EventHandler(this._Txt_NotaEntrega_TextChanged);
            this._Txt_NotaEntrega.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_NotaEntrega_KeyPress);
            // 
            // _Txt_Numero
            // 
            this._Txt_Numero.BackColor = System.Drawing.Color.White;
            this._Txt_Numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Numero.Enabled = false;
            this._Txt_Numero.Location = new System.Drawing.Point(16, 20);
            this._Txt_Numero.Name = "_Txt_Numero";
            this._Txt_Numero.ReadOnly = true;
            this._Txt_Numero.Size = new System.Drawing.Size(45, 18);
            this._Txt_Numero.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "Id:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(65, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "Fecha:";
            // 
            // _Txt_Fecha
            // 
            this._Txt_Fecha.BackColor = System.Drawing.Color.White;
            this._Txt_Fecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Fecha.Enabled = false;
            this._Txt_Fecha.Location = new System.Drawing.Point(68, 20);
            this._Txt_Fecha.Name = "_Txt_Fecha";
            this._Txt_Fecha.ReadOnly = true;
            this._Txt_Fecha.Size = new System.Drawing.Size(108, 18);
            this._Txt_Fecha.TabIndex = 0;
            // 
            // _Cmb_Motivo
            // 
            this._Cmb_Motivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Motivo.Enabled = false;
            this._Cmb_Motivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Cmb_Motivo.FormattingEnabled = true;
            this._Cmb_Motivo.Location = new System.Drawing.Point(16, 111);
            this._Cmb_Motivo.Name = "_Cmb_Motivo";
            this._Cmb_Motivo.Size = new System.Drawing.Size(548, 20);
            this._Cmb_Motivo.TabIndex = 2;
            this._Cmb_Motivo.DropDown += new System.EventHandler(this._Cmb_Motivo_DropDown);
            this._Cmb_Motivo.SelectedIndexChanged += new System.EventHandler(this._Cmb_Motivo_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "Motivo:";
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // _Pnl_Clave
            // 
            this._Pnl_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Clave.Controls.Add(this._Bt_Aceptar);
            this._Pnl_Clave.Controls.Add(this._Lbl_Titulo);
            this._Pnl_Clave.Controls.Add(this.label12);
            this._Pnl_Clave.Controls.Add(this._Txt_Clave);
            this._Pnl_Clave.Controls.Add(this._Bt_Cancelar);
            this._Pnl_Clave.Controls.Add(this._Lbl_TituloClave);
            this._Pnl_Clave.Location = new System.Drawing.Point(222, 204);
            this._Pnl_Clave.Name = "_Pnl_Clave";
            this._Pnl_Clave.Size = new System.Drawing.Size(154, 100);
            this._Pnl_Clave.TabIndex = 3;
            this._Pnl_Clave.Visible = false;
            this._Pnl_Clave.VisibleChanged += new System.EventHandler(this._Pnl_Clave_VisibleChanged);
            // 
            // _Bt_Aceptar
            // 
            this._Bt_Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Aceptar.Location = new System.Drawing.Point(9, 72);
            this._Bt_Aceptar.Name = "_Bt_Aceptar";
            this._Bt_Aceptar.Size = new System.Drawing.Size(62, 20);
            this._Bt_Aceptar.TabIndex = 4;
            this._Bt_Aceptar.Text = "Aceptar";
            this._Bt_Aceptar.UseVisualStyleBackColor = true;
            this._Bt_Aceptar.Click += new System.EventHandler(this._Bt_Aceptar_Click);
            // 
            // _Lbl_Titulo
            // 
            this._Lbl_Titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this._Lbl_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_Titulo.ForeColor = System.Drawing.Color.Black;
            this._Lbl_Titulo.Location = new System.Drawing.Point(0, 19);
            this._Lbl_Titulo.Name = "_Lbl_Titulo";
            this._Lbl_Titulo.Size = new System.Drawing.Size(152, 25);
            this._Lbl_Titulo.TabIndex = 1;
            this._Lbl_Titulo.Text = "¿Esta seguro de aprobar el ajuste?";
            this._Lbl_Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "Clave:";
            // 
            // _Txt_Clave
            // 
            this._Txt_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Clave.Location = new System.Drawing.Point(50, 48);
            this._Txt_Clave.Name = "_Txt_Clave";
            this._Txt_Clave.PasswordChar = '*';
            this._Txt_Clave.Size = new System.Drawing.Size(95, 18);
            this._Txt_Clave.TabIndex = 3;
            // 
            // _Bt_Cancelar
            // 
            this._Bt_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Cancelar.Location = new System.Drawing.Point(77, 72);
            this._Bt_Cancelar.Name = "_Bt_Cancelar";
            this._Bt_Cancelar.Size = new System.Drawing.Size(68, 20);
            this._Bt_Cancelar.TabIndex = 5;
            this._Bt_Cancelar.Text = "Cancelar";
            this._Bt_Cancelar.UseVisualStyleBackColor = true;
            this._Bt_Cancelar.Click += new System.EventHandler(this._Bt_Cancelar_Click);
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
            // Frm_AjusteSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 508);
            this.Controls.Add(this._Pnl_Clave);
            this.Controls.Add(this._Tb_Tab);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AjusteSalida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajuste de Salida";
            this.Activated += new System.EventHandler(this.Frm_AjusteSalida_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_AjusteSalida_FormClosing);
            this.Load += new System.EventHandler(this.Frm_AjusteSalida_Load);
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid2)).EndInit();
            this._Pnl_Descripcion.ResumeLayout(false);
            this._Pnl_Descripcion.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._Grb_Firma.ResumeLayout(false);
            this._Grb_Firma.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this._Pnl_Clave.ResumeLayout(false);
            this._Pnl_Clave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private T3.Controles._Ctrl_Busqueda _Ctrl_Busqueda1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView _Dg_Grid2;
        private System.Windows.Forms.TextBox _Txt_Impuesto;
        private System.Windows.Forms.TextBox _Txt_Costo;
        private System.Windows.Forms.TextBox _Txt_Fecha;
        private System.Windows.Forms.TextBox _Txt_Descripcion;
        private System.Windows.Forms.TextBox _Txt_Numero;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.ComboBox _Cmb_Motivo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _Lbl_DgInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel _Pnl_Descripcion;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button _Bt_Imprimir;
        private System.Windows.Forms.Panel _Pnl_Clave;
        private System.Windows.Forms.Button _Bt_Aceptar;
        private System.Windows.Forms.Label _Lbl_Titulo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox _Txt_Clave;
        private System.Windows.Forms.Button _Bt_Cancelar;
        private System.Windows.Forms.Label _Lbl_TituloClave;
        private System.Windows.Forms.DataGridViewTextBoxColumn cproducto;
        private System.Windows.Forms.DataGridViewButtonColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn cidlote;
        private System.Windows.Forms.DataGridViewTextBoxColumn cprecioventamax;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdescrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccajas;
        private System.Windows.Forms.DataGridViewTextBoxColumn cunid;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIDPRODUCTOD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _Txt_NotaEntrega;
        private System.Windows.Forms.GroupBox _Grb_Firma;
        private System.Windows.Forms.Button _Bt_EliminarAprobador2;
        private System.Windows.Forms.Button _Bt_EliminarAprobador1;
        public System.Windows.Forms.TextBox _Txt_FirmaAprobador2;
        public System.Windows.Forms.TextBox _Txt_FirmaAprobador1;
        private System.Windows.Forms.Button _Bt_FirmaAprobador2;
        private System.Windows.Forms.Button _Bt_FirmaAprobador1;
        private System.Windows.Forms.Label lblAprobador2;
        private System.Windows.Forms.Label lblAprobador1;
    }
}