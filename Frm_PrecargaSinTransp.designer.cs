namespace T3
{
    partial class Frm_PrecargaSinTransp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PrecargaSinTransp));
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this._Ctrl_Busqueda1 = new T3.Controles._Ctrl_Busqueda();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._Rpv_Main = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Lbl_TipoPrecarga = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this._Txt_Bs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Txt_Cajas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Bt_Asignar = new System.Windows.Forms.Button();
            this._Txt_Precarga = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._Txt_Transportista = new System.Windows.Forms.TextBox();
            this._Txt_Placa = new System.Windows.Forms.TextBox();
            this._Bt_Transportista = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._Bt_Transporte = new System.Windows.Forms.Button();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Pnl_Clave = new System.Windows.Forms.Panel();
            this._Bt_AceptarClave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this._Txt_Clave = new System.Windows.Forms.TextBox();
            this._Bt_CancelarClave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this._Pnl_Rutas = new System.Windows.Forms.Panel();
            this._Dg_Rutas = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this._Bt_Aceptar_Rut = new System.Windows.Forms.Button();
            this._Lbl_Ruta = new System.Windows.Forms.Label();
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this._Pnl_Clave.SuspendLayout();
            this._Pnl_Rutas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Rutas)).BeginInit();
            this.panel4.SuspendLayout();
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
            this._Tb_Tab.Size = new System.Drawing.Size(872, 475);
            this._Tb_Tab.TabIndex = 1;
            this._Tb_Tab.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this._Tb_Tab_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._Dg_Grid);
            this.tabPage1.Controls.Add(this._Ctrl_Busqueda1);
            this.tabPage1.Controls.Add(this._Lbl_DgInfo);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(864, 450);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(3, 44);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Size = new System.Drawing.Size(858, 393);
            this._Dg_Grid.TabIndex = 1;
            this._Dg_Grid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_CellMouseEnter);
            this._Dg_Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_CellClick);
            this._Dg_Grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Fecha";
            this.Column1.HeaderText = "Fecha";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Pre-Carga";
            this.Column2.HeaderText = "Pre-Carga";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Cajas";
            this.Column3.HeaderText = "Cajas";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Unidades";
            this.Column4.HeaderText = "Unidades";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Kg";
            this.Column5.HeaderText = "Kg";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Ruta Desp.";
            this.Column6.HeaderText = "Rutas Desp.";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _Ctrl_Busqueda1
            // 
            this._Ctrl_Busqueda1.Dock = System.Windows.Forms.DockStyle.Top;
            this._Ctrl_Busqueda1.Location = new System.Drawing.Point(3, 3);
            this._Ctrl_Busqueda1.Name = "_Ctrl_Busqueda1";
            this._Ctrl_Busqueda1.Size = new System.Drawing.Size(858, 41);
            this._Ctrl_Busqueda1.TabIndex = 7;
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(3, 437);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(858, 10);
            this._Lbl_DgInfo.TabIndex = 6;
            this._Lbl_DgInfo.Text = "Use doble click";
            this._Lbl_DgInfo.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._Rpv_Main);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(864, 450);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _Rpv_Main
            // 
            this._Rpv_Main.ActiveViewIndex = -1;
            this._Rpv_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Rpv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Rpv_Main.Location = new System.Drawing.Point(3, 79);
            this._Rpv_Main.Name = "_Rpv_Main";
            this._Rpv_Main.SelectionFormula = "";
            this._Rpv_Main.ShowGroupTreeButton = false;
            this._Rpv_Main.ShowParameterPanelButton = false;
            this._Rpv_Main.Size = new System.Drawing.Size(858, 368);
            this._Rpv_Main.TabIndex = 78;
            this._Rpv_Main.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this._Rpv_Main.ViewTimeSelectionFormula = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Lbl_TipoPrecarga);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this._Txt_Bs);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._Txt_Cajas);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._Bt_Asignar);
            this.panel1.Controls.Add(this._Txt_Precarga);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this._Txt_Transportista);
            this.panel1.Controls.Add(this._Txt_Placa);
            this.panel1.Controls.Add(this._Bt_Transportista);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this._Bt_Transporte);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(858, 76);
            this.panel1.TabIndex = 77;
            // 
            // _Lbl_TipoPrecarga
            // 
            this._Lbl_TipoPrecarga.AutoSize = true;
            this._Lbl_TipoPrecarga.BackColor = System.Drawing.Color.Transparent;
            this._Lbl_TipoPrecarga.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Lbl_TipoPrecarga.ForeColor = System.Drawing.Color.Red;
            this._Lbl_TipoPrecarga.Location = new System.Drawing.Point(5, 57);
            this._Lbl_TipoPrecarga.Name = "_Lbl_TipoPrecarga";
            this._Lbl_TipoPrecarga.Size = new System.Drawing.Size(0, 13);
            this._Lbl_TipoPrecarga.TabIndex = 80;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(6, 42);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(91, 12);
            this.label19.TabIndex = 79;
            this.label19.Text = "Tipo de precarga:";
            // 
            // _Txt_Bs
            // 
            this._Txt_Bs.BackColor = System.Drawing.Color.White;
            this._Txt_Bs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Bs.Location = new System.Drawing.Point(743, 22);
            this._Txt_Bs.Name = "_Txt_Bs";
            this._Txt_Bs.ReadOnly = true;
            this._Txt_Bs.Size = new System.Drawing.Size(99, 18);
            this._Txt_Bs.TabIndex = 77;
            this._Txt_Bs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(741, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 12);
            this.label2.TabIndex = 78;
            this.label2.Text = "Bolívares:";
            // 
            // _Txt_Cajas
            // 
            this._Txt_Cajas.BackColor = System.Drawing.Color.White;
            this._Txt_Cajas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Cajas.Location = new System.Drawing.Point(672, 22);
            this._Txt_Cajas.Name = "_Txt_Cajas";
            this._Txt_Cajas.ReadOnly = true;
            this._Txt_Cajas.Size = new System.Drawing.Size(65, 18);
            this._Txt_Cajas.TabIndex = 75;
            this._Txt_Cajas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(670, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 12);
            this.label1.TabIndex = 76;
            this.label1.Text = "Cajas:";
            // 
            // _Bt_Asignar
            // 
            this._Bt_Asignar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Asignar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Bt_Asignar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Bt_Asignar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Asignar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Asignar.Image")));
            this._Bt_Asignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Asignar.Location = new System.Drawing.Point(488, 16);
            this._Bt_Asignar.Name = "_Bt_Asignar";
            this._Bt_Asignar.Size = new System.Drawing.Size(169, 24);
            this._Bt_Asignar.TabIndex = 74;
            this._Bt_Asignar.Text = "Asignar Transporte";
            this._Bt_Asignar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Asignar.UseVisualStyleBackColor = true;
            this._Bt_Asignar.Click += new System.EventHandler(this._Bt_AprobarCliente_Click);
            // 
            // _Txt_Precarga
            // 
            this._Txt_Precarga.BackColor = System.Drawing.Color.White;
            this._Txt_Precarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Precarga.Location = new System.Drawing.Point(7, 21);
            this._Txt_Precarga.Name = "_Txt_Precarga";
            this._Txt_Precarga.ReadOnly = true;
            this._Txt_Precarga.Size = new System.Drawing.Size(80, 18);
            this._Txt_Precarga.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "Nº Precarga:";
            // 
            // _Txt_Transportista
            // 
            this._Txt_Transportista.BackColor = System.Drawing.Color.White;
            this._Txt_Transportista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Transportista.Location = new System.Drawing.Point(224, 21);
            this._Txt_Transportista.Name = "_Txt_Transportista";
            this._Txt_Transportista.ReadOnly = true;
            this._Txt_Transportista.Size = new System.Drawing.Size(228, 18);
            this._Txt_Transportista.TabIndex = 11;
            // 
            // _Txt_Placa
            // 
            this._Txt_Placa.BackColor = System.Drawing.Color.White;
            this._Txt_Placa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Placa.Location = new System.Drawing.Point(107, 21);
            this._Txt_Placa.Name = "_Txt_Placa";
            this._Txt_Placa.ReadOnly = true;
            this._Txt_Placa.Size = new System.Drawing.Size(65, 18);
            this._Txt_Placa.TabIndex = 9;
            // 
            // _Bt_Transportista
            // 
            this._Bt_Transportista.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Transportista.Enabled = false;
            this._Bt_Transportista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Transportista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Transportista.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Transportista.Image")));
            this._Bt_Transportista.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Transportista.Location = new System.Drawing.Point(458, 21);
            this._Bt_Transportista.Name = "_Bt_Transportista";
            this._Bt_Transportista.Size = new System.Drawing.Size(24, 17);
            this._Bt_Transportista.TabIndex = 13;
            this._Bt_Transportista.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Transportista.UseVisualStyleBackColor = true;
            this._Bt_Transportista.Click += new System.EventHandler(this._Bt_Transportista_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(224, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "Transportista:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(105, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Placa:";
            // 
            // _Bt_Transporte
            // 
            this._Bt_Transporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Transporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Transporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Transporte.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Transporte.Image")));
            this._Bt_Transporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Transporte.Location = new System.Drawing.Point(178, 21);
            this._Bt_Transporte.Name = "_Bt_Transporte";
            this._Bt_Transporte.Size = new System.Drawing.Size(24, 17);
            this._Bt_Transporte.TabIndex = 8;
            this._Bt_Transporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Transporte.UseVisualStyleBackColor = true;
            this._Bt_Transporte.Click += new System.EventHandler(this._Bt_Transporte_Click);
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // _Pnl_Clave
            // 
            this._Pnl_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Clave.Controls.Add(this._Bt_AceptarClave);
            this._Pnl_Clave.Controls.Add(this.label8);
            this._Pnl_Clave.Controls.Add(this._Txt_Clave);
            this._Pnl_Clave.Controls.Add(this._Bt_CancelarClave);
            this._Pnl_Clave.Controls.Add(this.label9);
            this._Pnl_Clave.Location = new System.Drawing.Point(359, 194);
            this._Pnl_Clave.Name = "_Pnl_Clave";
            this._Pnl_Clave.Size = new System.Drawing.Size(154, 86);
            this._Pnl_Clave.TabIndex = 84;
            this._Pnl_Clave.Visible = false;
            this._Pnl_Clave.VisibleChanged += new System.EventHandler(this._Pnl_Clave_VisibleChanged);
            // 
            // _Bt_AceptarClave
            // 
            this._Bt_AceptarClave.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_AceptarClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_AceptarClave.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_AceptarClave.Location = new System.Drawing.Point(16, 55);
            this._Bt_AceptarClave.Name = "_Bt_AceptarClave";
            this._Bt_AceptarClave.Size = new System.Drawing.Size(62, 22);
            this._Bt_AceptarClave.TabIndex = 70;
            this._Bt_AceptarClave.Text = "Aceptar";
            this._Bt_AceptarClave.UseVisualStyleBackColor = true;
            this._Bt_AceptarClave.Click += new System.EventHandler(this._Bt_AceptarClave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 12);
            this.label8.TabIndex = 68;
            this.label8.Text = "Clave:";
            // 
            // _Txt_Clave
            // 
            this._Txt_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Clave.Location = new System.Drawing.Point(50, 31);
            this._Txt_Clave.Name = "_Txt_Clave";
            this._Txt_Clave.PasswordChar = '*';
            this._Txt_Clave.Size = new System.Drawing.Size(95, 18);
            this._Txt_Clave.TabIndex = 2;
            // 
            // _Bt_CancelarClave
            // 
            this._Bt_CancelarClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_CancelarClave.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_CancelarClave.Location = new System.Drawing.Point(79, 55);
            this._Bt_CancelarClave.Name = "_Bt_CancelarClave";
            this._Bt_CancelarClave.Size = new System.Drawing.Size(62, 22);
            this._Bt_CancelarClave.TabIndex = 1;
            this._Bt_CancelarClave.Text = "Cancelar";
            this._Bt_CancelarClave.UseVisualStyleBackColor = true;
            this._Bt_CancelarClave.Click += new System.EventHandler(this._Bt_CancelarClave_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Navy;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 18);
            this.label9.TabIndex = 0;
            this.label9.Text = "Introduzca Clave";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Pnl_Rutas
            // 
            this._Pnl_Rutas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Rutas.Controls.Add(this._Dg_Rutas);
            this._Pnl_Rutas.Controls.Add(this.panel4);
            this._Pnl_Rutas.Controls.Add(this._Lbl_Ruta);
            this._Pnl_Rutas.Location = new System.Drawing.Point(12, 128);
            this._Pnl_Rutas.Name = "_Pnl_Rutas";
            this._Pnl_Rutas.Size = new System.Drawing.Size(513, 171);
            this._Pnl_Rutas.TabIndex = 85;
            this._Pnl_Rutas.Visible = false;
            this._Pnl_Rutas.VisibleChanged += new System.EventHandler(this._Pnl_Rutas_VisibleChanged);
            // 
            // _Dg_Rutas
            // 
            this._Dg_Rutas.AllowUserToAddRows = false;
            this._Dg_Rutas.AllowUserToDeleteRows = false;
            this._Dg_Rutas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Rutas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Rutas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Rutas.Location = new System.Drawing.Point(0, 18);
            this._Dg_Rutas.Name = "_Dg_Rutas";
            this._Dg_Rutas.ReadOnly = true;
            this._Dg_Rutas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Rutas.Size = new System.Drawing.Size(511, 122);
            this._Dg_Rutas.TabIndex = 31;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this._Bt_Aceptar_Rut);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 140);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(511, 29);
            this.panel4.TabIndex = 33;
            // 
            // _Bt_Aceptar_Rut
            // 
            this._Bt_Aceptar_Rut.BackColor = System.Drawing.Color.White;
            this._Bt_Aceptar_Rut.Location = new System.Drawing.Point(454, 5);
            this._Bt_Aceptar_Rut.Name = "_Bt_Aceptar_Rut";
            this._Bt_Aceptar_Rut.Size = new System.Drawing.Size(54, 20);
            this._Bt_Aceptar_Rut.TabIndex = 32;
            this._Bt_Aceptar_Rut.Text = "Aceptar";
            this._Bt_Aceptar_Rut.UseVisualStyleBackColor = false;
            this._Bt_Aceptar_Rut.Click += new System.EventHandler(this._Bt_Aceptar_Rut_Click);
            // 
            // _Lbl_Ruta
            // 
            this._Lbl_Ruta.BackColor = System.Drawing.Color.Navy;
            this._Lbl_Ruta.Dock = System.Windows.Forms.DockStyle.Top;
            this._Lbl_Ruta.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this._Lbl_Ruta.Location = new System.Drawing.Point(0, 0);
            this._Lbl_Ruta.Name = "_Lbl_Ruta";
            this._Lbl_Ruta.Size = new System.Drawing.Size(511, 18);
            this._Lbl_Ruta.TabIndex = 0;
            this._Lbl_Ruta.Text = "Rutas de Despacho";
            this._Lbl_Ruta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_PrecargaSinTransp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 475);
            this.Controls.Add(this._Pnl_Rutas);
            this.Controls.Add(this._Pnl_Clave);
            this.Controls.Add(this._Tb_Tab);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_PrecargaSinTransp";
            this.Text = "Pre-Cargas sin transporte";
            this.Load += new System.EventHandler(this.Frm_PrecargaSinTransp_Load);
            this.Activated += new System.EventHandler(this.Frm_PrecargaSinTransp_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_PrecargaSinTransp_FormClosing);
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this._Pnl_Clave.ResumeLayout(false);
            this._Pnl_Clave.PerformLayout();
            this._Pnl_Rutas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Rutas)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.Label _Lbl_DgInfo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer _Rpv_Main;
        private System.Windows.Forms.TextBox _Txt_Transportista;
        private System.Windows.Forms.TextBox _Txt_Placa;
        private System.Windows.Forms.Button _Bt_Transportista;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button _Bt_Transporte;
        private T3.Controles._Ctrl_Busqueda _Ctrl_Busqueda1;
        private System.Windows.Forms.TextBox _Txt_Precarga;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _Bt_Asignar;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.Panel _Pnl_Clave;
        private System.Windows.Forms.Button _Bt_AceptarClave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _Txt_Clave;
        private System.Windows.Forms.Button _Bt_CancelarClave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel _Pnl_Rutas;
        private System.Windows.Forms.DataGridView _Dg_Rutas;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button _Bt_Aceptar_Rut;
        private System.Windows.Forms.Label _Lbl_Ruta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewButtonColumn Column6;
        private System.Windows.Forms.TextBox _Txt_Bs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _Txt_Cajas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _Lbl_TipoPrecarga;
        private System.Windows.Forms.Label label19;
    }
}