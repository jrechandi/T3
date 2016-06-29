namespace T3
{
    partial class Frm_AprobAnulFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AprobAnulFactura));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this._Tool_Principal = new System.Windows.Forms.ToolStrip();
            this._Tool_Actualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._Tool_Quitar = new System.Windows.Forms.ToolStripButton();
            this._Tool_Seleccionar = new System.Windows.Forms.ToolStripButton();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this._Cntx_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rechazarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._Pnl_Inferior = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this._Bt_Aprobar = new System.Windows.Forms.Button();
            this._Pnl_Clave = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this._Bt_AceptarClave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this._Txt_Clave = new System.Windows.Forms.TextBox();
            this._Bt_CancelarClave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._Pnl_Rechazar = new System.Windows.Forms.Panel();
            this._Cmb_Motivo = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this._Bt_Aceptar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this._Txt_ClaveR = new System.Windows.Forms.TextBox();
            this._Bt_Cancelar = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this._Dg_GridCol_Print = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._Dg_GridCol_factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_GridCol_VendedorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_GridCol_ClienteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_GridCol_Empaques = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_GridCol_Unidades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_GridCol_Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_GridCol_Motivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_GridCol_cmotianulfact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_GridCol_ccliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_GridCol_cfacturanu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_GridCol_montosimp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_GridCol_montoimp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_GridCol_cpfactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Dg_GridCol_cidcomprobanul = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Tool_Principal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this._Cntx_Menu.SuspendLayout();
            this._Pnl_Inferior.SuspendLayout();
            this.panel2.SuspendLayout();
            this._Pnl_Clave.SuspendLayout();
            this._Pnl_Rechazar.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Tool_Principal
            // 
            this._Tool_Principal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._Tool_Actualizar,
            this.toolStripSeparator3,
            this.toolStripSeparator5,
            this.toolStripSeparator1,
            this._Tool_Quitar,
            this._Tool_Seleccionar});
            this._Tool_Principal.Location = new System.Drawing.Point(0, 0);
            this._Tool_Principal.Name = "_Tool_Principal";
            this._Tool_Principal.Size = new System.Drawing.Size(960, 25);
            this._Tool_Principal.TabIndex = 7;
            this._Tool_Principal.Text = "toolStrip1";
            // 
            // _Tool_Actualizar
            // 
            this._Tool_Actualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._Tool_Actualizar.Image = ((System.Drawing.Image)(resources.GetObject("_Tool_Actualizar.Image")));
            this._Tool_Actualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._Tool_Actualizar.Name = "_Tool_Actualizar";
            this._Tool_Actualizar.Size = new System.Drawing.Size(23, 22);
            this._Tool_Actualizar.Text = "Mostrar todos los pedidos";
            this._Tool_Actualizar.ToolTipText = "Actualizar..";
            this._Tool_Actualizar.Click += new System.EventHandler(this._Tool_Actualizar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _Tool_Quitar
            // 
            this._Tool_Quitar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._Tool_Quitar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._Tool_Quitar.ForeColor = System.Drawing.Color.Navy;
            this._Tool_Quitar.Image = ((System.Drawing.Image)(resources.GetObject("_Tool_Quitar.Image")));
            this._Tool_Quitar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._Tool_Quitar.Name = "_Tool_Quitar";
            this._Tool_Quitar.Size = new System.Drawing.Size(87, 22);
            this._Tool_Quitar.Text = "Quitar selección";
            this._Tool_Quitar.Click += new System.EventHandler(this._Tool_Quitar_Click);
            // 
            // _Tool_Seleccionar
            // 
            this._Tool_Seleccionar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._Tool_Seleccionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._Tool_Seleccionar.ForeColor = System.Drawing.Color.Navy;
            this._Tool_Seleccionar.Image = ((System.Drawing.Image)(resources.GetObject("_Tool_Seleccionar.Image")));
            this._Tool_Seleccionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._Tool_Seleccionar.Name = "_Tool_Seleccionar";
            this._Tool_Seleccionar.Size = new System.Drawing.Size(95, 22);
            this._Tool_Seleccionar.Text = "Seleccionar todos";
            this._Tool_Seleccionar.Click += new System.EventHandler(this._Tool_Seleccionar_Click);
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Dg_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._Dg_GridCol_Print,
            this._Dg_GridCol_factura,
            this._Dg_GridCol_VendedorName,
            this._Dg_GridCol_ClienteName,
            this._Dg_GridCol_Empaques,
            this._Dg_GridCol_Unidades,
            this._Dg_GridCol_Monto,
            this._Dg_GridCol_Motivo,
            this._Dg_GridCol_cmotianulfact,
            this._Dg_GridCol_ccliente,
            this._Dg_GridCol_cfacturanu,
            this._Dg_GridCol_montosimp,
            this._Dg_GridCol_montoimp,
            this._Dg_GridCol_cpfactura,
            this._Dg_GridCol_cidcomprobanul});
            this._Dg_Grid.ContextMenuStrip = this._Cntx_Menu;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(0, 25);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Size = new System.Drawing.Size(960, 374);
            this._Dg_Grid.TabIndex = 8;
            // 
            // _Cntx_Menu
            // 
            this._Cntx_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rechazarToolStripMenuItem});
            this._Cntx_Menu.Name = "_Cntx_Menu";
            this._Cntx_Menu.Size = new System.Drawing.Size(131, 26);
            this._Cntx_Menu.Opening += new System.ComponentModel.CancelEventHandler(this._Cntx_Menu_Opening);
            // 
            // rechazarToolStripMenuItem
            // 
            this.rechazarToolStripMenuItem.Name = "rechazarToolStripMenuItem";
            this.rechazarToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.rechazarToolStripMenuItem.Text = "Rechazar";
            this.rechazarToolStripMenuItem.Click += new System.EventHandler(this.rechazarToolStripMenuItem_Click);
            // 
            // _Pnl_Inferior
            // 
            this._Pnl_Inferior.Controls.Add(this.panel2);
            this._Pnl_Inferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Pnl_Inferior.Location = new System.Drawing.Point(0, 399);
            this._Pnl_Inferior.Name = "_Pnl_Inferior";
            this._Pnl_Inferior.Size = new System.Drawing.Size(960, 35);
            this._Pnl_Inferior.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._Bt_Aprobar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(856, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(104, 35);
            this.panel2.TabIndex = 82;
            // 
            // _Bt_Aprobar
            // 
            this._Bt_Aprobar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Aprobar.Enabled = false;
            this._Bt_Aprobar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Aprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Aprobar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Aprobar.Image")));
            this._Bt_Aprobar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Aprobar.Location = new System.Drawing.Point(3, 4);
            this._Bt_Aprobar.Name = "_Bt_Aprobar";
            this._Bt_Aprobar.Size = new System.Drawing.Size(96, 28);
            this._Bt_Aprobar.TabIndex = 81;
            this._Bt_Aprobar.Text = "Aprobar";
            this._Bt_Aprobar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Aprobar.UseVisualStyleBackColor = true;
            this._Bt_Aprobar.Click += new System.EventHandler(this._Bt_Aprobar_Click);
            // 
            // _Pnl_Clave
            // 
            this._Pnl_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Clave.Controls.Add(this.label1);
            this._Pnl_Clave.Controls.Add(this._Bt_AceptarClave);
            this._Pnl_Clave.Controls.Add(this.label7);
            this._Pnl_Clave.Controls.Add(this._Txt_Clave);
            this._Pnl_Clave.Controls.Add(this._Bt_CancelarClave);
            this._Pnl_Clave.Controls.Add(this.label2);
            this._Pnl_Clave.Location = new System.Drawing.Point(403, 168);
            this._Pnl_Clave.Name = "_Pnl_Clave";
            this._Pnl_Clave.Size = new System.Drawing.Size(154, 102);
            this._Pnl_Clave.TabIndex = 83;
            this._Pnl_Clave.Visible = false;
            this._Pnl_Clave.VisibleChanged += new System.EventHandler(this._Pnl_Clave_VisibleChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 12);
            this.label1.TabIndex = 71;
            this.label1.Text = "Anulación de Facturas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Bt_AceptarClave
            // 
            this._Bt_AceptarClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_AceptarClave.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_AceptarClave.Location = new System.Drawing.Point(13, 66);
            this._Bt_AceptarClave.Name = "_Bt_AceptarClave";
            this._Bt_AceptarClave.Size = new System.Drawing.Size(62, 25);
            this._Bt_AceptarClave.TabIndex = 70;
            this._Bt_AceptarClave.Text = "Aceptar";
            this._Bt_AceptarClave.UseVisualStyleBackColor = true;
            this._Bt_AceptarClave.Click += new System.EventHandler(this._Bt_AceptarClave_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 12);
            this.label7.TabIndex = 68;
            this.label7.Text = "Clave:";
            // 
            // _Txt_Clave
            // 
            this._Txt_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Clave.Location = new System.Drawing.Point(54, 42);
            this._Txt_Clave.Name = "_Txt_Clave";
            this._Txt_Clave.PasswordChar = '*';
            this._Txt_Clave.Size = new System.Drawing.Size(95, 18);
            this._Txt_Clave.TabIndex = 2;
            // 
            // _Bt_CancelarClave
            // 
            this._Bt_CancelarClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_CancelarClave.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_CancelarClave.Location = new System.Drawing.Point(81, 66);
            this._Bt_CancelarClave.Name = "_Bt_CancelarClave";
            this._Bt_CancelarClave.Size = new System.Drawing.Size(62, 25);
            this._Bt_CancelarClave.TabIndex = 1;
            this._Bt_CancelarClave.Text = "Cancelar";
            this._Bt_CancelarClave.UseVisualStyleBackColor = true;
            this._Bt_CancelarClave.Click += new System.EventHandler(this._Bt_CancelarClave_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Navy;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Introduzca Clave";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Pnl_Rechazar
            // 
            this._Pnl_Rechazar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Rechazar.Controls.Add(this._Cmb_Motivo);
            this._Pnl_Rechazar.Controls.Add(this.label17);
            this._Pnl_Rechazar.Controls.Add(this._Bt_Aceptar);
            this._Pnl_Rechazar.Controls.Add(this.label12);
            this._Pnl_Rechazar.Controls.Add(this.label13);
            this._Pnl_Rechazar.Controls.Add(this._Txt_ClaveR);
            this._Pnl_Rechazar.Controls.Add(this._Bt_Cancelar);
            this._Pnl_Rechazar.Controls.Add(this.label16);
            this._Pnl_Rechazar.Location = new System.Drawing.Point(281, 273);
            this._Pnl_Rechazar.Name = "_Pnl_Rechazar";
            this._Pnl_Rechazar.Size = new System.Drawing.Size(399, 112);
            this._Pnl_Rechazar.TabIndex = 85;
            this._Pnl_Rechazar.Visible = false;
            this._Pnl_Rechazar.VisibleChanged += new System.EventHandler(this._Pnl_Rechazar_VisibleChanged);
            // 
            // _Cmb_Motivo
            // 
            this._Cmb_Motivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Motivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Motivo.FormattingEnabled = true;
            this._Cmb_Motivo.Location = new System.Drawing.Point(3, 52);
            this._Cmb_Motivo.Name = "_Cmb_Motivo";
            this._Cmb_Motivo.Size = new System.Drawing.Size(391, 20);
            this._Cmb_Motivo.TabIndex = 74;
            this._Cmb_Motivo.SelectedIndexChanged += new System.EventHandler(this._Cmb_Motivo_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(1, 37);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 12);
            this.label17.TabIndex = 73;
            this.label17.Text = "Motivo:";
            // 
            // _Bt_Aceptar
            // 
            this._Bt_Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Aceptar.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Aceptar.Location = new System.Drawing.Point(159, 77);
            this._Bt_Aceptar.Name = "_Bt_Aceptar";
            this._Bt_Aceptar.Size = new System.Drawing.Size(62, 23);
            this._Bt_Aceptar.TabIndex = 70;
            this._Bt_Aceptar.Text = "Aceptar";
            this._Bt_Aceptar.UseVisualStyleBackColor = true;
            this._Bt_Aceptar.Click += new System.EventHandler(this._Bt_Aceptar_Click);
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(0, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(397, 20);
            this.label12.TabIndex = 69;
            this.label12.Text = "¿Esta seguro de rechazar la anulación?";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 12);
            this.label13.TabIndex = 68;
            this.label13.Text = "Clave:";
            // 
            // _Txt_ClaveR
            // 
            this._Txt_ClaveR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_ClaveR.Location = new System.Drawing.Point(48, 79);
            this._Txt_ClaveR.Name = "_Txt_ClaveR";
            this._Txt_ClaveR.PasswordChar = '*';
            this._Txt_ClaveR.Size = new System.Drawing.Size(95, 18);
            this._Txt_ClaveR.TabIndex = 2;
            // 
            // _Bt_Cancelar
            // 
            this._Bt_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Cancelar.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Cancelar.Location = new System.Drawing.Point(227, 77);
            this._Bt_Cancelar.Name = "_Bt_Cancelar";
            this._Bt_Cancelar.Size = new System.Drawing.Size(66, 23);
            this._Bt_Cancelar.TabIndex = 1;
            this._Bt_Cancelar.Text = "Cancelar";
            this._Bt_Cancelar.UseVisualStyleBackColor = true;
            this._Bt_Cancelar.Click += new System.EventHandler(this._Bt_Cancelar_Click);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Navy;
            this.label16.Dock = System.Windows.Forms.DockStyle.Top;
            this.label16.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(397, 18);
            this.label16.TabIndex = 0;
            this.label16.Text = "Introduzca Clave";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Dg_GridCol_Print
            // 
            this._Dg_GridCol_Print.DataPropertyName = "Anular";
            this._Dg_GridCol_Print.FalseValue = "0";
            this._Dg_GridCol_Print.HeaderText = "Anular";
            this._Dg_GridCol_Print.IndeterminateValue = "0";
            this._Dg_GridCol_Print.Name = "_Dg_GridCol_Print";
            this._Dg_GridCol_Print.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._Dg_GridCol_Print.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._Dg_GridCol_Print.TrueValue = "1";
            // 
            // _Dg_GridCol_factura
            // 
            this._Dg_GridCol_factura.DataPropertyName = "cfactura";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this._Dg_GridCol_factura.DefaultCellStyle = dataGridViewCellStyle1;
            this._Dg_GridCol_factura.HeaderText = "Factura";
            this._Dg_GridCol_factura.Name = "_Dg_GridCol_factura";
            this._Dg_GridCol_factura.ReadOnly = true;
            // 
            // _Dg_GridCol_VendedorName
            // 
            this._Dg_GridCol_VendedorName.DataPropertyName = "cvendedor_name";
            this._Dg_GridCol_VendedorName.HeaderText = "Vendedor";
            this._Dg_GridCol_VendedorName.Name = "_Dg_GridCol_VendedorName";
            this._Dg_GridCol_VendedorName.ReadOnly = true;
            // 
            // _Dg_GridCol_ClienteName
            // 
            this._Dg_GridCol_ClienteName.DataPropertyName = "c_nomb_comer";
            this._Dg_GridCol_ClienteName.HeaderText = "Cliente";
            this._Dg_GridCol_ClienteName.Name = "_Dg_GridCol_ClienteName";
            this._Dg_GridCol_ClienteName.ReadOnly = true;
            // 
            // _Dg_GridCol_Empaques
            // 
            this._Dg_GridCol_Empaques.DataPropertyName = "tot_cajas";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this._Dg_GridCol_Empaques.DefaultCellStyle = dataGridViewCellStyle2;
            this._Dg_GridCol_Empaques.HeaderText = "Empaques";
            this._Dg_GridCol_Empaques.Name = "_Dg_GridCol_Empaques";
            this._Dg_GridCol_Empaques.ReadOnly = true;
            // 
            // _Dg_GridCol_Unidades
            // 
            this._Dg_GridCol_Unidades.DataPropertyName = "tot_unidades";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this._Dg_GridCol_Unidades.DefaultCellStyle = dataGridViewCellStyle3;
            this._Dg_GridCol_Unidades.HeaderText = "Unidades";
            this._Dg_GridCol_Unidades.Name = "_Dg_GridCol_Unidades";
            this._Dg_GridCol_Unidades.ReadOnly = true;
            // 
            // _Dg_GridCol_Monto
            // 
            this._Dg_GridCol_Monto.DataPropertyName = "monto_total";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this._Dg_GridCol_Monto.DefaultCellStyle = dataGridViewCellStyle4;
            this._Dg_GridCol_Monto.HeaderText = "Monto";
            this._Dg_GridCol_Monto.Name = "_Dg_GridCol_Monto";
            this._Dg_GridCol_Monto.ReadOnly = true;
            // 
            // _Dg_GridCol_Motivo
            // 
            this._Dg_GridCol_Motivo.DataPropertyName = "motivo_cdescripcion";
            this._Dg_GridCol_Motivo.HeaderText = "Motivo";
            this._Dg_GridCol_Motivo.Name = "_Dg_GridCol_Motivo";
            this._Dg_GridCol_Motivo.ReadOnly = true;
            // 
            // _Dg_GridCol_cmotianulfact
            // 
            this._Dg_GridCol_cmotianulfact.DataPropertyName = "cmotianulfact";
            this._Dg_GridCol_cmotianulfact.HeaderText = "cmotianulfact";
            this._Dg_GridCol_cmotianulfact.Name = "_Dg_GridCol_cmotianulfact";
            this._Dg_GridCol_cmotianulfact.Visible = false;
            // 
            // _Dg_GridCol_ccliente
            // 
            this._Dg_GridCol_ccliente.DataPropertyName = "ccliente";
            this._Dg_GridCol_ccliente.HeaderText = "ccliente";
            this._Dg_GridCol_ccliente.Name = "_Dg_GridCol_ccliente";
            this._Dg_GridCol_ccliente.Visible = false;
            // 
            // _Dg_GridCol_cfacturanu
            // 
            this._Dg_GridCol_cfacturanu.DataPropertyName = "cfacturanu";
            this._Dg_GridCol_cfacturanu.HeaderText = "cfacturanu";
            this._Dg_GridCol_cfacturanu.Name = "_Dg_GridCol_cfacturanu";
            this._Dg_GridCol_cfacturanu.Visible = false;
            // 
            // _Dg_GridCol_montosimp
            // 
            this._Dg_GridCol_montosimp.DataPropertyName = "c_montotot_si_bs";
            this._Dg_GridCol_montosimp.HeaderText = "montosimp";
            this._Dg_GridCol_montosimp.Name = "_Dg_GridCol_montosimp";
            this._Dg_GridCol_montosimp.Visible = false;
            // 
            // _Dg_GridCol_montoimp
            // 
            this._Dg_GridCol_montoimp.DataPropertyName = "c_impuesto_bs";
            this._Dg_GridCol_montoimp.HeaderText = "montoimp";
            this._Dg_GridCol_montoimp.Name = "_Dg_GridCol_montoimp";
            this._Dg_GridCol_montoimp.Visible = false;
            // 
            // _Dg_GridCol_cpfactura
            // 
            this._Dg_GridCol_cpfactura.DataPropertyName = "cpfactura";
            this._Dg_GridCol_cpfactura.HeaderText = "cpfactura";
            this._Dg_GridCol_cpfactura.Name = "_Dg_GridCol_cpfactura";
            this._Dg_GridCol_cpfactura.Visible = false;
            // 
            // _Dg_GridCol_cidcomprobanul
            // 
            this._Dg_GridCol_cidcomprobanul.DataPropertyName = "cidcomprobanul";
            this._Dg_GridCol_cidcomprobanul.HeaderText = "Comprobante";
            this._Dg_GridCol_cidcomprobanul.Name = "_Dg_GridCol_cidcomprobanul";
            this._Dg_GridCol_cidcomprobanul.ReadOnly = true;
            // 
            // Frm_AprobAnulFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 434);
            this.Controls.Add(this._Pnl_Rechazar);
            this.Controls.Add(this._Pnl_Clave);
            this.Controls.Add(this._Dg_Grid);
            this.Controls.Add(this._Pnl_Inferior);
            this.Controls.Add(this._Tool_Principal);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AprobAnulFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aprobación de anulaciones de facturas";
            this.Load += new System.EventHandler(this.Frm_AprobAnulFactura_Load);
            this._Tool_Principal.ResumeLayout(false);
            this._Tool_Principal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this._Cntx_Menu.ResumeLayout(false);
            this._Pnl_Inferior.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this._Pnl_Clave.ResumeLayout(false);
            this._Pnl_Clave.PerformLayout();
            this._Pnl_Rechazar.ResumeLayout(false);
            this._Pnl_Rechazar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _Tool_Principal;
        private System.Windows.Forms.ToolStripButton _Tool_Actualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _Tool_Quitar;
        private System.Windows.Forms.ToolStripButton _Tool_Seleccionar;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.Panel _Pnl_Inferior;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button _Bt_Aprobar;
        private System.Windows.Forms.Panel _Pnl_Clave;
        private System.Windows.Forms.Button _Bt_AceptarClave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _Txt_Clave;
        private System.Windows.Forms.Button _Bt_CancelarClave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip _Cntx_Menu;
        private System.Windows.Forms.ToolStripMenuItem rechazarToolStripMenuItem;
        private System.Windows.Forms.Panel _Pnl_Rechazar;
        private System.Windows.Forms.ComboBox _Cmb_Motivo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button _Bt_Aceptar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox _Txt_ClaveR;
        private System.Windows.Forms.Button _Bt_Cancelar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _Dg_GridCol_Print;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_GridCol_factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_GridCol_VendedorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_GridCol_ClienteName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_GridCol_Empaques;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_GridCol_Unidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_GridCol_Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_GridCol_Motivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_GridCol_cmotianulfact;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_GridCol_ccliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_GridCol_cfacturanu;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_GridCol_montosimp;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_GridCol_montoimp;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_GridCol_cpfactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Dg_GridCol_cidcomprobanul;
    }
}