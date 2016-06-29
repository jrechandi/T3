namespace T3
{
    partial class Frm_ReImpresionFacturasPruebas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ReImpresionFacturas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this._Pnl_Superior = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this._Bt_Quitar = new System.Windows.Forms.Button();
            this._Bt_Seleccionar = new System.Windows.Forms.Button();
            this._Bt_Agregar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._Txt_Hasta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Txt_Desde = new System.Windows.Forms.TextBox();
            this._Pnl_Inferior = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this._Bt_Historial = new System.Windows.Forms.Button();
            this._Bt_Imprimir = new System.Windows.Forms.Button();
            this._Bt_Actualizar = new System.Windows.Forms.Button();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imprimir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cidcomprob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Pnl_Clave = new System.Windows.Forms.Panel();
            this._Bt_AceptarClave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this._Txt_Clave = new System.Windows.Forms.TextBox();
            this._Bt_CancelarClave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Pnl_ReImpresion = new System.Windows.Forms.Panel();
            this._Bt_DesdeNumDoc = new System.Windows.Forms.Button();
            this._Bt_ReImprime = new System.Windows.Forms.Button();
            this._Bt_RestNumDoc = new System.Windows.Forms.Button();
            this._LstBox_DocPrint = new System.Windows.Forms.ListBox();
            this._Bt_AddNumDoc = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this._Txt_NumDoc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._Pnl_Numero = new System.Windows.Forms.Panel();
            this._Bt_CancelarNumero = new System.Windows.Forms.Button();
            this._Bt_AceptarNumero = new System.Windows.Forms.Button();
            this._Txt_Numero = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this._Pnl_Superior.SuspendLayout();
            this.panel4.SuspendLayout();
            this._Pnl_Inferior.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this._Pnl_Clave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this._Pnl_ReImpresion.SuspendLayout();
            this._Pnl_Numero.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Pnl_Superior
            // 
            this._Pnl_Superior.Controls.Add(this.panel4);
            this._Pnl_Superior.Controls.Add(this._Bt_Agregar);
            this._Pnl_Superior.Controls.Add(this.label2);
            this._Pnl_Superior.Controls.Add(this._Txt_Hasta);
            this._Pnl_Superior.Controls.Add(this.label1);
            this._Pnl_Superior.Controls.Add(this._Txt_Desde);
            this._Pnl_Superior.Dock = System.Windows.Forms.DockStyle.Top;
            this._Pnl_Superior.Location = new System.Drawing.Point(0, 0);
            this._Pnl_Superior.Name = "_Pnl_Superior";
            this._Pnl_Superior.Size = new System.Drawing.Size(786, 33);
            this._Pnl_Superior.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this._Bt_Quitar);
            this.panel4.Controls.Add(this._Bt_Seleccionar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(553, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(233, 33);
            this.panel4.TabIndex = 5;
            // 
            // _Bt_Quitar
            // 
            this._Bt_Quitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Quitar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Quitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Quitar.Location = new System.Drawing.Point(120, 4);
            this._Bt_Quitar.Name = "_Bt_Quitar";
            this._Bt_Quitar.Size = new System.Drawing.Size(103, 22);
            this._Bt_Quitar.TabIndex = 7;
            this._Bt_Quitar.Text = "Quitar selección";
            this._Bt_Quitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Quitar.UseVisualStyleBackColor = true;
            this._Bt_Quitar.Click += new System.EventHandler(this._Bt_Quitar_Click);
            // 
            // _Bt_Seleccionar
            // 
            this._Bt_Seleccionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Seleccionar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Seleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Seleccionar.Location = new System.Drawing.Point(11, 4);
            this._Bt_Seleccionar.Name = "_Bt_Seleccionar";
            this._Bt_Seleccionar.Size = new System.Drawing.Size(103, 22);
            this._Bt_Seleccionar.TabIndex = 6;
            this._Bt_Seleccionar.Text = "Seleccionar todo";
            this._Bt_Seleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Seleccionar.UseVisualStyleBackColor = true;
            this._Bt_Seleccionar.Click += new System.EventHandler(this._Bt_Seleccionar_Click);
            // 
            // _Bt_Agregar
            // 
            this._Bt_Agregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Agregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Agregar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Agregar.Image")));
            this._Bt_Agregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Agregar.Location = new System.Drawing.Point(403, 4);
            this._Bt_Agregar.Name = "_Bt_Agregar";
            this._Bt_Agregar.Size = new System.Drawing.Size(122, 22);
            this._Bt_Agregar.TabIndex = 1;
            this._Bt_Agregar.Text = "Agregar facturas";
            this._Bt_Agregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Agregar.UseVisualStyleBackColor = true;
            this._Bt_Agregar.Click += new System.EventHandler(this._Bt_Agregar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(203, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Factura hasta:";
            // 
            // _Txt_Hasta
            // 
            this._Txt_Hasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Hasta.Location = new System.Drawing.Point(287, 7);
            this._Txt_Hasta.Name = "_Txt_Hasta";
            this._Txt_Hasta.Size = new System.Drawing.Size(100, 18);
            this._Txt_Hasta.TabIndex = 3;
            this._Txt_Hasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Txt_Hasta.TextChanged += new System.EventHandler(this._Txt_Hasta_TextChanged);
            this._Txt_Hasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Hasta_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Factura desde:";
            // 
            // _Txt_Desde
            // 
            this._Txt_Desde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Desde.Location = new System.Drawing.Point(97, 7);
            this._Txt_Desde.Name = "_Txt_Desde";
            this._Txt_Desde.Size = new System.Drawing.Size(100, 18);
            this._Txt_Desde.TabIndex = 1;
            this._Txt_Desde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Txt_Desde.TextChanged += new System.EventHandler(this._Txt_Desde_TextChanged);
            this._Txt_Desde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Desde_KeyPress);
            // 
            // _Pnl_Inferior
            // 
            this._Pnl_Inferior.Controls.Add(this.panel3);
            this._Pnl_Inferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Pnl_Inferior.Location = new System.Drawing.Point(0, 449);
            this._Pnl_Inferior.Name = "_Pnl_Inferior";
            this._Pnl_Inferior.Size = new System.Drawing.Size(786, 44);
            this._Pnl_Inferior.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._Bt_Historial);
            this.panel3.Controls.Add(this._Bt_Imprimir);
            this.panel3.Controls.Add(this._Bt_Actualizar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(287, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(499, 44);
            this.panel3.TabIndex = 83;
            // 
            // _Bt_Historial
            // 
            this._Bt_Historial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Historial.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Historial.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Historial.Image")));
            this._Bt_Historial.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Historial.Location = new System.Drawing.Point(15, 6);
            this._Bt_Historial.Name = "_Bt_Historial";
            this._Bt_Historial.Size = new System.Drawing.Size(93, 30);
            this._Bt_Historial.TabIndex = 82;
            this._Bt_Historial.Text = "Ver Historial";
            this._Bt_Historial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Historial.UseVisualStyleBackColor = true;
            this._Bt_Historial.Click += new System.EventHandler(this._Bt_Historial_Click);
            // 
            // _Bt_Imprimir
            // 
            this._Bt_Imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Imprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Imprimir.Image")));
            this._Bt_Imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Imprimir.Location = new System.Drawing.Point(114, 6);
            this._Bt_Imprimir.Name = "_Bt_Imprimir";
            this._Bt_Imprimir.Size = new System.Drawing.Size(143, 30);
            this._Bt_Imprimir.TabIndex = 49;
            this._Bt_Imprimir.Text = "Imprimir";
            this._Bt_Imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Imprimir.UseVisualStyleBackColor = true;
            this._Bt_Imprimir.Click += new System.EventHandler(this._Bt_Imprimir_Click);
            // 
            // _Bt_Actualizar
            // 
            this._Bt_Actualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Actualizar.Enabled = false;
            this._Bt_Actualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Actualizar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Actualizar.Image")));
            this._Bt_Actualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Actualizar.Location = new System.Drawing.Point(263, 6);
            this._Bt_Actualizar.Name = "_Bt_Actualizar";
            this._Bt_Actualizar.Size = new System.Drawing.Size(224, 30);
            this._Bt_Actualizar.TabIndex = 81;
            this._Bt_Actualizar.Text = "Actualizar Nº de Control";
            this._Bt_Actualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Actualizar.UseVisualStyleBackColor = true;
            this._Bt_Actualizar.Click += new System.EventHandler(this._Bt_Actualizar_Click);
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Dg_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tipo,
            this.Documento,
            this.Descripcion,
            this.Imprimir,
            this.Numero,
            this.cidcomprob});
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(0, 33);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Size = new System.Drawing.Size(786, 416);
            this._Dg_Grid.TabIndex = 8;
            this._Dg_Grid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this._Dg_Grid_CellBeginEdit);
            this._Dg_Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_CellClick);
            this._Dg_Grid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_CellEndEdit);
            this._Dg_Grid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this._Dg_Grid_EditingControlShowing);
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // Documento
            // 
            this.Documento.DataPropertyName = "Documento";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Documento.DefaultCellStyle = dataGridViewCellStyle1;
            this.Documento.HeaderText = "Documento";
            this.Documento.Name = "Documento";
            this.Documento.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Imprimir
            // 
            this.Imprimir.DataPropertyName = "Imprimir";
            this.Imprimir.FalseValue = "0";
            this.Imprimir.HeaderText = "Imprimir";
            this.Imprimir.IndeterminateValue = "0";
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Imprimir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Imprimir.TrueValue = "1";
            // 
            // Numero
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Numero.DefaultCellStyle = dataGridViewCellStyle2;
            this.Numero.HeaderText = "Nº Control";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            // 
            // cidcomprob
            // 
            this.cidcomprob.DataPropertyName = "cidcomprob";
            this.cidcomprob.HeaderText = "Comprobante";
            this.cidcomprob.Name = "cidcomprob";
            this.cidcomprob.ReadOnly = true;
            this.cidcomprob.Visible = false;
            // 
            // _Pnl_Clave
            // 
            this._Pnl_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Clave.Controls.Add(this._Bt_AceptarClave);
            this._Pnl_Clave.Controls.Add(this.label7);
            this._Pnl_Clave.Controls.Add(this._Txt_Clave);
            this._Pnl_Clave.Controls.Add(this._Bt_CancelarClave);
            this._Pnl_Clave.Controls.Add(this.label3);
            this._Pnl_Clave.Location = new System.Drawing.Point(446, 203);
            this._Pnl_Clave.Name = "_Pnl_Clave";
            this._Pnl_Clave.Size = new System.Drawing.Size(154, 86);
            this._Pnl_Clave.TabIndex = 83;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 12);
            this.label7.TabIndex = 68;
            this.label7.Text = "Clave:";
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
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Navy;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Introduzca Clave";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // _Pnl_ReImpresion
            // 
            this._Pnl_ReImpresion.Controls.Add(this._Bt_DesdeNumDoc);
            this._Pnl_ReImpresion.Controls.Add(this._Bt_ReImprime);
            this._Pnl_ReImpresion.Controls.Add(this._Bt_RestNumDoc);
            this._Pnl_ReImpresion.Controls.Add(this._LstBox_DocPrint);
            this._Pnl_ReImpresion.Controls.Add(this._Bt_AddNumDoc);
            this._Pnl_ReImpresion.Controls.Add(this.label5);
            this._Pnl_ReImpresion.Controls.Add(this._Txt_NumDoc);
            this._Pnl_ReImpresion.Controls.Add(this.label4);
            this._Pnl_ReImpresion.Location = new System.Drawing.Point(143, 157);
            this._Pnl_ReImpresion.Name = "_Pnl_ReImpresion";
            this._Pnl_ReImpresion.Size = new System.Drawing.Size(292, 179);
            this._Pnl_ReImpresion.TabIndex = 84;
            this._Pnl_ReImpresion.Visible = false;
            this._Pnl_ReImpresion.VisibleChanged += new System.EventHandler(this._Pnl_ReImpresion_VisibleChanged);
            // 
            // _Bt_DesdeNumDoc
            // 
            this._Bt_DesdeNumDoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_DesdeNumDoc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_DesdeNumDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_DesdeNumDoc.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_DesdeNumDoc.Location = new System.Drawing.Point(220, 57);
            this._Bt_DesdeNumDoc.Name = "_Bt_DesdeNumDoc";
            this._Bt_DesdeNumDoc.Size = new System.Drawing.Size(62, 22);
            this._Bt_DesdeNumDoc.TabIndex = 72;
            this._Bt_DesdeNumDoc.Text = "Desde";
            this._Bt_DesdeNumDoc.UseVisualStyleBackColor = true;
            this._Bt_DesdeNumDoc.Click += new System.EventHandler(this._Bt_DesdeNumDoc_Click);
            // 
            // _Bt_ReImprime
            // 
            this._Bt_ReImprime.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_ReImprime.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_ReImprime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_ReImprime.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_ReImprime.Location = new System.Drawing.Point(220, 84);
            this._Bt_ReImprime.Name = "_Bt_ReImprime";
            this._Bt_ReImprime.Size = new System.Drawing.Size(62, 22);
            this._Bt_ReImprime.TabIndex = 71;
            this._Bt_ReImprime.Text = "Imprimir";
            this._Bt_ReImprime.UseVisualStyleBackColor = true;
            this._Bt_ReImprime.Click += new System.EventHandler(this._Bt_ReImprime_Click);
            // 
            // _Bt_RestNumDoc
            // 
            this._Bt_RestNumDoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_RestNumDoc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_RestNumDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_RestNumDoc.Location = new System.Drawing.Point(140, 33);
            this._Bt_RestNumDoc.Name = "_Bt_RestNumDoc";
            this._Bt_RestNumDoc.Size = new System.Drawing.Size(23, 22);
            this._Bt_RestNumDoc.TabIndex = 9;
            this._Bt_RestNumDoc.Text = "-";
            this._Bt_RestNumDoc.UseVisualStyleBackColor = true;
            this._Bt_RestNumDoc.Click += new System.EventHandler(this._Bt_RestNumDoc_Click);
            // 
            // _LstBox_DocPrint
            // 
            this._LstBox_DocPrint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._LstBox_DocPrint.FormattingEnabled = true;
            this._LstBox_DocPrint.ItemHeight = 12;
            this._LstBox_DocPrint.Location = new System.Drawing.Point(10, 57);
            this._LstBox_DocPrint.Name = "_LstBox_DocPrint";
            this._LstBox_DocPrint.Size = new System.Drawing.Size(204, 110);
            this._LstBox_DocPrint.TabIndex = 8;
            // 
            // _Bt_AddNumDoc
            // 
            this._Bt_AddNumDoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_AddNumDoc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_AddNumDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_AddNumDoc.Location = new System.Drawing.Point(111, 33);
            this._Bt_AddNumDoc.Name = "_Bt_AddNumDoc";
            this._Bt_AddNumDoc.Size = new System.Drawing.Size(23, 22);
            this._Bt_AddNumDoc.TabIndex = 7;
            this._Bt_AddNumDoc.Text = "+";
            this._Bt_AddNumDoc.UseVisualStyleBackColor = true;
            this._Bt_AddNumDoc.Click += new System.EventHandler(this._Bt_AddNumDoc_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "Nº Documento:";
            // 
            // _Txt_NumDoc
            // 
            this._Txt_NumDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_NumDoc.Location = new System.Drawing.Point(10, 33);
            this._Txt_NumDoc.Name = "_Txt_NumDoc";
            this._Txt_NumDoc.Size = new System.Drawing.Size(95, 18);
            this._Txt_NumDoc.TabIndex = 5;
            this._Txt_NumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Txt_NumDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_NumDoc_KeyPress);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Navy;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(292, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Re-impresión";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Pnl_Numero
            // 
            this._Pnl_Numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Numero.Controls.Add(this._Bt_CancelarNumero);
            this._Pnl_Numero.Controls.Add(this._Bt_AceptarNumero);
            this._Pnl_Numero.Controls.Add(this._Txt_Numero);
            this._Pnl_Numero.Controls.Add(this.label6);
            this._Pnl_Numero.Controls.Add(this.label13);
            this._Pnl_Numero.Location = new System.Drawing.Point(449, 120);
            this._Pnl_Numero.Name = "_Pnl_Numero";
            this._Pnl_Numero.Size = new System.Drawing.Size(224, 67);
            this._Pnl_Numero.TabIndex = 85;
            this._Pnl_Numero.Visible = false;
            this._Pnl_Numero.VisibleChanged += new System.EventHandler(this._Pnl_Numero_VisibleChanged);
            // 
            // _Bt_CancelarNumero
            // 
            this._Bt_CancelarNumero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_CancelarNumero.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_CancelarNumero.Location = new System.Drawing.Point(153, 36);
            this._Bt_CancelarNumero.Name = "_Bt_CancelarNumero";
            this._Bt_CancelarNumero.Size = new System.Drawing.Size(62, 22);
            this._Bt_CancelarNumero.TabIndex = 71;
            this._Bt_CancelarNumero.Text = "Cancelar";
            this._Bt_CancelarNumero.UseVisualStyleBackColor = true;
            this._Bt_CancelarNumero.Click += new System.EventHandler(this._Bt_CancelarNumero_Click);
            // 
            // _Bt_AceptarNumero
            // 
            this._Bt_AceptarNumero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_AceptarNumero.Location = new System.Drawing.Point(89, 36);
            this._Bt_AceptarNumero.Name = "_Bt_AceptarNumero";
            this._Bt_AceptarNumero.Size = new System.Drawing.Size(62, 22);
            this._Bt_AceptarNumero.TabIndex = 5;
            this._Bt_AceptarNumero.Text = "Aceptar";
            this._Bt_AceptarNumero.UseVisualStyleBackColor = true;
            this._Bt_AceptarNumero.Click += new System.EventHandler(this._Bt_AceptarNumero_Click);
            // 
            // _Txt_Numero
            // 
            this._Txt_Numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Numero.Location = new System.Drawing.Point(9, 37);
            this._Txt_Numero.MaxLength = 9;
            this._Txt_Numero.Name = "_Txt_Numero";
            this._Txt_Numero.Size = new System.Drawing.Size(74, 18);
            this._Txt_Numero.TabIndex = 4;
            this._Txt_Numero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Txt_Numero.TextChanged += new System.EventHandler(this._Txt_Numero_TextChanged);
            this._Txt_Numero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Numero_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "Desde:";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Navy;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(222, 18);
            this.label13.TabIndex = 0;
            this.label13.Text = "Número de Control";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_ReImpresionFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 493);
            this.Controls.Add(this._Pnl_Numero);
            this.Controls.Add(this._Pnl_ReImpresion);
            this.Controls.Add(this._Pnl_Clave);
            this.Controls.Add(this._Dg_Grid);
            this.Controls.Add(this._Pnl_Inferior);
            this.Controls.Add(this._Pnl_Superior);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ReImpresionFacturas";
            this.Text = "Proceso de Re-Impresión de Facturas";
            this.Load += new System.EventHandler(this.Frm_ReImpresionFacturas_Load);
            this.Shown += new System.EventHandler(this.Frm_ReImpresionFacturas_Shown);
            this._Pnl_Superior.ResumeLayout(false);
            this._Pnl_Superior.PerformLayout();
            this.panel4.ResumeLayout(false);
            this._Pnl_Inferior.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this._Pnl_Clave.ResumeLayout(false);
            this._Pnl_Clave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this._Pnl_ReImpresion.ResumeLayout(false);
            this._Pnl_ReImpresion.PerformLayout();
            this._Pnl_Numero.ResumeLayout(false);
            this._Pnl_Numero.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _Pnl_Superior;
        private System.Windows.Forms.TextBox _Txt_Desde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _Txt_Hasta;
        private System.Windows.Forms.Button _Bt_Agregar;
        private System.Windows.Forms.Panel _Pnl_Inferior;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Imprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn cidcomprob;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button _Bt_Imprimir;
        private System.Windows.Forms.Button _Bt_Actualizar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button _Bt_Seleccionar;
        private System.Windows.Forms.Button _Bt_Quitar;
        private System.Windows.Forms.Panel _Pnl_Clave;
        private System.Windows.Forms.Button _Bt_AceptarClave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _Txt_Clave;
        private System.Windows.Forms.Button _Bt_CancelarClave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.Panel _Pnl_ReImpresion;
        private System.Windows.Forms.Button _Bt_DesdeNumDoc;
        private System.Windows.Forms.Button _Bt_ReImprime;
        private System.Windows.Forms.Button _Bt_RestNumDoc;
        private System.Windows.Forms.ListBox _LstBox_DocPrint;
        private System.Windows.Forms.Button _Bt_AddNumDoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _Txt_NumDoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel _Pnl_Numero;
        private System.Windows.Forms.Button _Bt_CancelarNumero;
        private System.Windows.Forms.Button _Bt_AceptarNumero;
        private System.Windows.Forms.TextBox _Txt_Numero;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button _Bt_Historial;
    }
}