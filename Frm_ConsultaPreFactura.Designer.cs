namespace T3
{
    partial class Frm_ConsultaPreFactura
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ConsultaPreFactura));
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.c_fecha_pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpfactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_nomb_comer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cvendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cempaques = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_montotot_si = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cefectividad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cefectividad2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfacturado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clistofacturar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cprecarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbackorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cunidades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_factdevuelta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Cntx_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verDetalleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this._Rb_Todos = new System.Windows.Forms.RadioButton();
            this._Rb_Esperando = new System.Windows.Forms.RadioButton();
            this._Rb_EnPrecarga = new System.Windows.Forms.RadioButton();
            this._Rb_Facturado = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Btn_Exportar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this._Txt_Pedido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Txt_Prefactura = new System.Windows.Forms.TextBox();
            this._Bt_Consultar = new System.Windows.Forms.Button();
            this._Ctrl_ConsultaMes1 = new T3.Controles._Ctrl_ConsultaMes();
            this._Txt_Cliente = new System.Windows.Forms.TextBox();
            this.Bt_LimpiarCliente = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Bt_Cliente = new System.Windows.Forms.Button();
            this._Txt_Vendedor = new System.Windows.Forms.TextBox();
            this._Bt_LimpiarVendedor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this._Bt_Vendedor = new System.Windows.Forms.Button();
            this._Ctr_Dialogo = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this._Cntx_Menu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.c_fecha_pedido,
            this.cpedido,
            this.cpfactura,
            this.ccliente,
            this.c_nomb_comer,
            this.cvendedor,
            this.cname,
            this.cempaques,
            this.c_montotot_si,
            this.cefectividad,
            this.cefectividad2,
            this.cfacturado,
            this.clistofacturar,
            this.cprecarga,
            this.cbackorder,
            this.cunidades,
            this.Dias,
            this.c_factdevuelta});
            this._Dg_Grid.ContextMenuStrip = this._Cntx_Menu;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(0, 131);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Size = new System.Drawing.Size(1001, 319);
            this._Dg_Grid.TabIndex = 4;
            this._Dg_Grid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_ColumnHeaderMouseClick);
            this._Dg_Grid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_CellMouseEnter);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Estatus";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Visible = false;
            // 
            // c_fecha_pedido
            // 
            this.c_fecha_pedido.DataPropertyName = "c_fecha_pedido";
            dataGridViewCellStyle1.NullValue = " ";
            this.c_fecha_pedido.DefaultCellStyle = dataGridViewCellStyle1;
            this.c_fecha_pedido.HeaderText = "Fecha";
            this.c_fecha_pedido.Name = "c_fecha_pedido";
            this.c_fecha_pedido.ReadOnly = true;
            // 
            // cpedido
            // 
            this.cpedido.DataPropertyName = "cpedido";
            dataGridViewCellStyle2.NullValue = "0";
            this.cpedido.DefaultCellStyle = dataGridViewCellStyle2;
            this.cpedido.HeaderText = "Pedido";
            this.cpedido.Name = "cpedido";
            this.cpedido.ReadOnly = true;
            // 
            // cpfactura
            // 
            this.cpfactura.DataPropertyName = "cpfactura";
            dataGridViewCellStyle3.NullValue = "0";
            this.cpfactura.DefaultCellStyle = dataGridViewCellStyle3;
            this.cpfactura.HeaderText = "Pre-Factura";
            this.cpfactura.Name = "cpfactura";
            this.cpfactura.ReadOnly = true;
            // 
            // ccliente
            // 
            this.ccliente.DataPropertyName = "ccliente";
            dataGridViewCellStyle4.NullValue = "0";
            this.ccliente.DefaultCellStyle = dataGridViewCellStyle4;
            this.ccliente.HeaderText = "Codigo";
            this.ccliente.Name = "ccliente";
            this.ccliente.ReadOnly = true;
            // 
            // c_nomb_comer
            // 
            this.c_nomb_comer.DataPropertyName = "c_nomb_comer";
            dataGridViewCellStyle5.NullValue = "0";
            this.c_nomb_comer.DefaultCellStyle = dataGridViewCellStyle5;
            this.c_nomb_comer.HeaderText = "Cliente";
            this.c_nomb_comer.Name = "c_nomb_comer";
            this.c_nomb_comer.ReadOnly = true;
            // 
            // cvendedor
            // 
            this.cvendedor.DataPropertyName = "cvendedor";
            dataGridViewCellStyle6.NullValue = "0";
            this.cvendedor.DefaultCellStyle = dataGridViewCellStyle6;
            this.cvendedor.HeaderText = "Codigo";
            this.cvendedor.Name = "cvendedor";
            this.cvendedor.ReadOnly = true;
            // 
            // cname
            // 
            this.cname.DataPropertyName = "cname";
            dataGridViewCellStyle7.NullValue = "0";
            this.cname.DefaultCellStyle = dataGridViewCellStyle7;
            this.cname.HeaderText = "Vendedor";
            this.cname.Name = "cname";
            this.cname.ReadOnly = true;
            // 
            // cempaques
            // 
            this.cempaques.DataPropertyName = "cempaques";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.NullValue = "0";
            this.cempaques.DefaultCellStyle = dataGridViewCellStyle8;
            this.cempaques.HeaderText = "Cajas";
            this.cempaques.Name = "cempaques";
            this.cempaques.ReadOnly = true;
            // 
            // c_montotot_si
            // 
            this.c_montotot_si.DataPropertyName = "c_montotot_si";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.NullValue = "0";
            this.c_montotot_si.DefaultCellStyle = dataGridViewCellStyle9;
            this.c_montotot_si.HeaderText = "Monto";
            this.c_montotot_si.Name = "c_montotot_si";
            this.c_montotot_si.ReadOnly = true;
            // 
            // cefectividad
            // 
            this.cefectividad.DataPropertyName = "cefectividad";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.NullValue = "0";
            this.cefectividad.DefaultCellStyle = dataGridViewCellStyle10;
            this.cefectividad.HeaderText = "Efectividad";
            this.cefectividad.Name = "cefectividad";
            this.cefectividad.ReadOnly = true;
            // 
            // cefectividad2
            // 
            this.cefectividad2.DataPropertyName = "cefectividad2";
            dataGridViewCellStyle11.NullValue = "0";
            this.cefectividad2.DefaultCellStyle = dataGridViewCellStyle11;
            this.cefectividad2.HeaderText = "cefectividad";
            this.cefectividad2.Name = "cefectividad2";
            this.cefectividad2.ReadOnly = true;
            this.cefectividad2.Visible = false;
            // 
            // cfacturado
            // 
            this.cfacturado.DataPropertyName = "cfacturado";
            dataGridViewCellStyle12.NullValue = "0";
            this.cfacturado.DefaultCellStyle = dataGridViewCellStyle12;
            this.cfacturado.HeaderText = "cfacturado";
            this.cfacturado.Name = "cfacturado";
            this.cfacturado.ReadOnly = true;
            this.cfacturado.Visible = false;
            // 
            // clistofacturar
            // 
            this.clistofacturar.DataPropertyName = "clistofacturar";
            dataGridViewCellStyle13.NullValue = "0";
            this.clistofacturar.DefaultCellStyle = dataGridViewCellStyle13;
            this.clistofacturar.HeaderText = "clistofacturar";
            this.clistofacturar.Name = "clistofacturar";
            this.clistofacturar.ReadOnly = true;
            this.clistofacturar.Visible = false;
            // 
            // cprecarga
            // 
            this.cprecarga.DataPropertyName = "cprecarga";
            dataGridViewCellStyle14.NullValue = "0";
            this.cprecarga.DefaultCellStyle = dataGridViewCellStyle14;
            this.cprecarga.HeaderText = "cprecarga";
            this.cprecarga.Name = "cprecarga";
            this.cprecarga.ReadOnly = true;
            this.cprecarga.Visible = false;
            // 
            // cbackorder
            // 
            this.cbackorder.DataPropertyName = "cbackorder";
            dataGridViewCellStyle15.NullValue = "0";
            this.cbackorder.DefaultCellStyle = dataGridViewCellStyle15;
            this.cbackorder.HeaderText = "cbackorder";
            this.cbackorder.Name = "cbackorder";
            this.cbackorder.ReadOnly = true;
            this.cbackorder.Visible = false;
            // 
            // cunidades
            // 
            this.cunidades.DataPropertyName = "cunidades";
            dataGridViewCellStyle16.NullValue = "0";
            this.cunidades.DefaultCellStyle = dataGridViewCellStyle16;
            this.cunidades.HeaderText = "cunidades";
            this.cunidades.Name = "cunidades";
            this.cunidades.ReadOnly = true;
            this.cunidades.Visible = false;
            // 
            // Dias
            // 
            this.Dias.DataPropertyName = "Dias";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Dias.DefaultCellStyle = dataGridViewCellStyle17;
            this.Dias.HeaderText = "Días Transcurridos";
            this.Dias.Name = "Dias";
            this.Dias.ReadOnly = true;
            this.Dias.Width = 110;
            // 
            // c_factdevuelta
            // 
            this.c_factdevuelta.DataPropertyName = "c_factdevuelta";
            this.c_factdevuelta.HeaderText = "c_factdevuelta";
            this.c_factdevuelta.Name = "c_factdevuelta";
            this.c_factdevuelta.ReadOnly = true;
            this.c_factdevuelta.Visible = false;
            // 
            // _Cntx_Menu
            // 
            this._Cntx_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verDetalleToolStripMenuItem});
            this._Cntx_Menu.Name = "_Cntx_Menu";
            this._Cntx_Menu.Size = new System.Drawing.Size(130, 26);
            // 
            // verDetalleToolStripMenuItem
            // 
            this.verDetalleToolStripMenuItem.Name = "verDetalleToolStripMenuItem";
            this.verDetalleToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.verDetalleToolStripMenuItem.Text = "Ver detalle";
            this.verDetalleToolStripMenuItem.Click += new System.EventHandler(this.verDetalleToolStripMenuItem_Click);
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(0, 450);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(1001, 11);
            this._Lbl_DgInfo.TabIndex = 6;
            this._Lbl_DgInfo.Text = "Use botón derecho";
            this._Lbl_DgInfo.Visible = false;
            // 
            // _Rb_Todos
            // 
            this._Rb_Todos.AutoSize = true;
            this._Rb_Todos.Checked = true;
            this._Rb_Todos.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Rb_Todos.Location = new System.Drawing.Point(14, 5);
            this._Rb_Todos.Name = "_Rb_Todos";
            this._Rb_Todos.Size = new System.Drawing.Size(218, 17);
            this._Rb_Todos.TabIndex = 161;
            this._Rb_Todos.TabStop = true;
            this._Rb_Todos.Text = "Todos los pedidos pendientes";
            this._Rb_Todos.UseVisualStyleBackColor = true;
            this._Rb_Todos.CheckedChanged += new System.EventHandler(this._Rb_Todos_CheckedChanged);
            // 
            // _Rb_Esperando
            // 
            this._Rb_Esperando.AutoSize = true;
            this._Rb_Esperando.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Rb_Esperando.Location = new System.Drawing.Point(14, 36);
            this._Rb_Esperando.Name = "_Rb_Esperando";
            this._Rb_Esperando.Size = new System.Drawing.Size(177, 17);
            this._Rb_Esperando.TabIndex = 162;
            this._Rb_Esperando.Text = "Esperando por facturar";
            this._Rb_Esperando.UseVisualStyleBackColor = true;
            this._Rb_Esperando.CheckedChanged += new System.EventHandler(this._Rb_Esperando_CheckedChanged);
            // 
            // _Rb_EnPrecarga
            // 
            this._Rb_EnPrecarga.AutoSize = true;
            this._Rb_EnPrecarga.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Rb_EnPrecarga.Location = new System.Drawing.Point(14, 67);
            this._Rb_EnPrecarga.Name = "_Rb_EnPrecarga";
            this._Rb_EnPrecarga.Size = new System.Drawing.Size(110, 17);
            this._Rb_EnPrecarga.TabIndex = 163;
            this._Rb_EnPrecarga.Text = "En Pre-carga";
            this._Rb_EnPrecarga.UseVisualStyleBackColor = true;
            this._Rb_EnPrecarga.CheckedChanged += new System.EventHandler(this._Rb_EnPrecarga_CheckedChanged);
            // 
            // _Rb_Facturado
            // 
            this._Rb_Facturado.AutoSize = true;
            this._Rb_Facturado.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._Rb_Facturado.Location = new System.Drawing.Point(14, 98);
            this._Rb_Facturado.Name = "_Rb_Facturado";
            this._Rb_Facturado.Size = new System.Drawing.Size(91, 17);
            this._Rb_Facturado.TabIndex = 164;
            this._Rb_Facturado.Text = "Facturado";
            this._Rb_Facturado.UseVisualStyleBackColor = true;
            this._Rb_Facturado.CheckedChanged += new System.EventHandler(this._Rb_Facturado_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Btn_Exportar);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this._Txt_Pedido);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._Txt_Prefactura);
            this.panel1.Controls.Add(this._Bt_Consultar);
            this.panel1.Controls.Add(this._Ctrl_ConsultaMes1);
            this.panel1.Controls.Add(this._Txt_Cliente);
            this.panel1.Controls.Add(this.Bt_LimpiarCliente);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Bt_Cliente);
            this.panel1.Controls.Add(this._Txt_Vendedor);
            this.panel1.Controls.Add(this._Bt_LimpiarVendedor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this._Bt_Vendedor);
            this.panel1.Controls.Add(this._Rb_Todos);
            this.panel1.Controls.Add(this._Rb_Facturado);
            this.panel1.Controls.Add(this._Rb_Esperando);
            this.panel1.Controls.Add(this._Rb_EnPrecarga);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1001, 131);
            this.panel1.TabIndex = 165;
            // 
            // _Btn_Exportar
            // 
            this._Btn_Exportar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Btn_Exportar.Image = global::T3.Properties.Resources.excel1;
            this._Btn_Exportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Btn_Exportar.Location = new System.Drawing.Point(739, 76);
            this._Btn_Exportar.Name = "_Btn_Exportar";
            this._Btn_Exportar.Size = new System.Drawing.Size(123, 44);
            this._Btn_Exportar.TabIndex = 183;
            this._Btn_Exportar.Text = "&Exportar";
            this._Btn_Exportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Btn_Exportar.UseVisualStyleBackColor = true;
            this._Btn_Exportar.Click += new System.EventHandler(this._Btn_Exportar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(353, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 182;
            this.label4.Text = "Pedido:";
            // 
            // _Txt_Pedido
            // 
            this._Txt_Pedido.BackColor = System.Drawing.SystemColors.HighlightText;
            this._Txt_Pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Pedido.Location = new System.Drawing.Point(356, 22);
            this._Txt_Pedido.Name = "_Txt_Pedido";
            this._Txt_Pedido.Size = new System.Drawing.Size(106, 18);
            this._Txt_Pedido.TabIndex = 181;
            this._Txt_Pedido.TextChanged += new System.EventHandler(this._Txt_Pedido_TextChanged);
            this._Txt_Pedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Pedido_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(238, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 180;
            this.label1.Text = "Prefactura";
            // 
            // _Txt_Prefactura
            // 
            this._Txt_Prefactura.BackColor = System.Drawing.SystemColors.HighlightText;
            this._Txt_Prefactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Prefactura.Location = new System.Drawing.Point(241, 22);
            this._Txt_Prefactura.Name = "_Txt_Prefactura";
            this._Txt_Prefactura.Size = new System.Drawing.Size(106, 18);
            this._Txt_Prefactura.TabIndex = 179;
            this._Txt_Prefactura.TextChanged += new System.EventHandler(this._Txt_Prefactura_TextChanged);
            this._Txt_Prefactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Prefactura_KeyPress);
            // 
            // _Bt_Consultar
            // 
            this._Bt_Consultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Consultar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this._Bt_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Consultar.Image")));
            this._Bt_Consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Consultar.Location = new System.Drawing.Point(615, 76);
            this._Bt_Consultar.Name = "_Bt_Consultar";
            this._Bt_Consultar.Size = new System.Drawing.Size(118, 44);
            this._Bt_Consultar.TabIndex = 178;
            this._Bt_Consultar.Text = "Consultar";
            this._Bt_Consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Consultar.UseVisualStyleBackColor = true;
            this._Bt_Consultar.Click += new System.EventHandler(this._Bt_Consultar_Click);
            // 
            // _Ctrl_ConsultaMes1
            // 
            this._Ctrl_ConsultaMes1.Location = new System.Drawing.Point(604, 12);
            this._Ctrl_ConsultaMes1.Name = "_Ctrl_ConsultaMes1";
            this._Ctrl_ConsultaMes1.Size = new System.Drawing.Size(377, 54);
            this._Ctrl_ConsultaMes1.TabIndex = 177;
            // 
            // _Txt_Cliente
            // 
            this._Txt_Cliente.BackColor = System.Drawing.SystemColors.HighlightText;
            this._Txt_Cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Cliente.Location = new System.Drawing.Point(240, 61);
            this._Txt_Cliente.Name = "_Txt_Cliente";
            this._Txt_Cliente.ReadOnly = true;
            this._Txt_Cliente.Size = new System.Drawing.Size(298, 18);
            this._Txt_Cliente.TabIndex = 173;
            // 
            // Bt_LimpiarCliente
            // 
            this.Bt_LimpiarCliente.Image = ((System.Drawing.Image)(resources.GetObject("Bt_LimpiarCliente.Image")));
            this.Bt_LimpiarCliente.Location = new System.Drawing.Point(573, 61);
            this.Bt_LimpiarCliente.Name = "Bt_LimpiarCliente";
            this.Bt_LimpiarCliente.Size = new System.Drawing.Size(25, 18);
            this.Bt_LimpiarCliente.TabIndex = 176;
            this.Bt_LimpiarCliente.UseVisualStyleBackColor = true;
            this.Bt_LimpiarCliente.Click += new System.EventHandler(this.Bt_LimpiarCliente_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(238, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 175;
            this.label2.Text = "Cliente:";
            // 
            // Bt_Cliente
            // 
            this.Bt_Cliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bt_Cliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this.Bt_Cliente.Image = ((System.Drawing.Image)(resources.GetObject("Bt_Cliente.Image")));
            this.Bt_Cliente.Location = new System.Drawing.Point(542, 61);
            this.Bt_Cliente.Name = "Bt_Cliente";
            this.Bt_Cliente.Size = new System.Drawing.Size(25, 18);
            this.Bt_Cliente.TabIndex = 174;
            this.Bt_Cliente.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.Bt_Cliente.UseVisualStyleBackColor = true;
            this.Bt_Cliente.Click += new System.EventHandler(this.Bt_Cliente_Click);
            // 
            // _Txt_Vendedor
            // 
            this._Txt_Vendedor.BackColor = System.Drawing.SystemColors.HighlightText;
            this._Txt_Vendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Vendedor.Location = new System.Drawing.Point(240, 102);
            this._Txt_Vendedor.Name = "_Txt_Vendedor";
            this._Txt_Vendedor.ReadOnly = true;
            this._Txt_Vendedor.Size = new System.Drawing.Size(298, 18);
            this._Txt_Vendedor.TabIndex = 169;
            // 
            // _Bt_LimpiarVendedor
            // 
            this._Bt_LimpiarVendedor.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_LimpiarVendedor.Image")));
            this._Bt_LimpiarVendedor.Location = new System.Drawing.Point(573, 102);
            this._Bt_LimpiarVendedor.Name = "_Bt_LimpiarVendedor";
            this._Bt_LimpiarVendedor.Size = new System.Drawing.Size(25, 18);
            this._Bt_LimpiarVendedor.TabIndex = 172;
            this._Bt_LimpiarVendedor.UseVisualStyleBackColor = true;
            this._Bt_LimpiarVendedor.Click += new System.EventHandler(this._Bt_LimpiarVendedor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(238, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 171;
            this.label3.Text = "Vendedor:";
            // 
            // _Bt_Vendedor
            // 
            this._Bt_Vendedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Vendedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Vendedor.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Vendedor.Image")));
            this._Bt_Vendedor.Location = new System.Drawing.Point(542, 102);
            this._Bt_Vendedor.Name = "_Bt_Vendedor";
            this._Bt_Vendedor.Size = new System.Drawing.Size(25, 18);
            this._Bt_Vendedor.TabIndex = 170;
            this._Bt_Vendedor.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._Bt_Vendedor.UseVisualStyleBackColor = true;
            this._Bt_Vendedor.Click += new System.EventHandler(this._Bt_Vendedor_Click);
            // 
            // _Ctr_Dialogo
            // 
            this._Ctr_Dialogo.DefaultExt = "xlsx";
            this._Ctr_Dialogo.Filter = "Archivos Excel|*.xlsx";
            this._Ctr_Dialogo.Title = "Exportar datos";
            // 
            // Frm_ConsultaPreFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 461);
            this.Controls.Add(this._Dg_Grid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._Lbl_DgInfo);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ConsultaPreFactura";
            this.Text = "Consulta de Pre-Facturas (Ventas)";
            this.Load += new System.EventHandler(this.Frm_ConsultaPreFactura_Load);
            this.Activated += new System.EventHandler(this.Frm_ConsultaPreFactura_Activated);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this._Cntx_Menu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.ContextMenuStrip _Cntx_Menu;
        private System.Windows.Forms.ToolStripMenuItem verDetalleToolStripMenuItem;
        private System.Windows.Forms.Label _Lbl_DgInfo;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_fecha_pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpfactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_nomb_comer;
        private System.Windows.Forms.DataGridViewTextBoxColumn cvendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cname;
        private System.Windows.Forms.DataGridViewTextBoxColumn cempaques;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_montotot_si;
        private System.Windows.Forms.DataGridViewTextBoxColumn cefectividad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cefectividad2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cfacturado;
        private System.Windows.Forms.DataGridViewTextBoxColumn clistofacturar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cprecarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn cbackorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn cunidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dias;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_factdevuelta;
        private System.Windows.Forms.RadioButton _Rb_Todos;
        private System.Windows.Forms.RadioButton _Rb_Esperando;
        private System.Windows.Forms.RadioButton _Rb_EnPrecarga;
        private System.Windows.Forms.RadioButton _Rb_Facturado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox _Txt_Cliente;
        private System.Windows.Forms.Button Bt_LimpiarCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Bt_Cliente;
        private System.Windows.Forms.TextBox _Txt_Vendedor;
        private System.Windows.Forms.Button _Bt_LimpiarVendedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _Bt_Vendedor;
        private System.Windows.Forms.Button _Bt_Consultar;
        private T3.Controles._Ctrl_ConsultaMes _Ctrl_ConsultaMes1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _Txt_Prefactura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _Txt_Pedido;
        private System.Windows.Forms.Button _Btn_Exportar;
        private System.Windows.Forms.SaveFileDialog _Ctr_Dialogo;
    }
}