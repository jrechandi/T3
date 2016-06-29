namespace T3
{
    partial class Frm_ConsultaFacturaDetalle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ConsultaFacturaDetalle));
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this._Txt_Vendedor = new System.Windows.Forms.TextBox();
            this._Txt_Cliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._Txt_StsDesp = new System.Windows.Forms.TextBox();
            this._Txt_Cajas = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this._Txt_NPedido = new System.Windows.Forms.TextBox();
            this._Txt_Unidades = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this._Txt_NFactura = new System.Windows.Forms.TextBox();
            this._Txt_Monto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this._Txt_Obs = new System.Windows.Forms.TextBox();
            this._Pnl_PanelPrincipal = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this._Txt_MontoIVA = new System.Windows.Forms.TextBox();
            this._Txt_MontoSinIVA = new System.Windows.Forms.TextBox();
            this._Txt_ObsCobro = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this._Txt_StsGen = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this._Txt_StsCobro = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._Txt_NGuiaDesp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._Txt_Fecha = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this._Txt_NroControl = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this._Txt_CondicionPago = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this._Pnl_PanelPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(0, 257);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.Size = new System.Drawing.Size(654, 219);
            this._Dg_Grid.TabIndex = 82;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "cproducto";
            this.Column1.HeaderText = "Producto";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "cnamef";
            this.Column2.HeaderText = "Descripción";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "cempaques";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column3.HeaderText = "Cajas";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "cunidades";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "Unidades";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "c_monto_si_bs";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column5.HeaderText = "Monto sin IVA";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "c_impuesto_bs";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column6.HeaderText = "Monto IVA";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "ctotal";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column7.HeaderText = "Monto Total";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Vendedor:";
            // 
            // _Txt_Vendedor
            // 
            this._Txt_Vendedor.BackColor = System.Drawing.Color.White;
            this._Txt_Vendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Vendedor.Location = new System.Drawing.Point(12, 89);
            this._Txt_Vendedor.Name = "_Txt_Vendedor";
            this._Txt_Vendedor.ReadOnly = true;
            this._Txt_Vendedor.Size = new System.Drawing.Size(386, 18);
            this._Txt_Vendedor.TabIndex = 9;
            // 
            // _Txt_Cliente
            // 
            this._Txt_Cliente.BackColor = System.Drawing.Color.White;
            this._Txt_Cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Cliente.Location = new System.Drawing.Point(12, 55);
            this._Txt_Cliente.Name = "_Txt_Cliente";
            this._Txt_Cliente.ReadOnly = true;
            this._Txt_Cliente.Size = new System.Drawing.Size(386, 18);
            this._Txt_Cliente.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cliente:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "Total cajas:";
            // 
            // _Txt_StsDesp
            // 
            this._Txt_StsDesp.BackColor = System.Drawing.Color.Khaki;
            this._Txt_StsDesp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_StsDesp.Location = new System.Drawing.Point(413, 22);
            this._Txt_StsDesp.Name = "_Txt_StsDesp";
            this._Txt_StsDesp.ReadOnly = true;
            this._Txt_StsDesp.Size = new System.Drawing.Size(226, 18);
            this._Txt_StsDesp.TabIndex = 5;
            // 
            // _Txt_Cajas
            // 
            this._Txt_Cajas.BackColor = System.Drawing.Color.White;
            this._Txt_Cajas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Cajas.Location = new System.Drawing.Point(12, 122);
            this._Txt_Cajas.Name = "_Txt_Cajas";
            this._Txt_Cajas.ReadOnly = true;
            this._Txt_Cajas.Size = new System.Drawing.Size(72, 18);
            this._Txt_Cajas.TabIndex = 12;
            this._Txt_Cajas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(411, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Estatus de despacho:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(82, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "Total unidades:";
            // 
            // _Txt_NPedido
            // 
            this._Txt_NPedido.BackColor = System.Drawing.Color.White;
            this._Txt_NPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_NPedido.Location = new System.Drawing.Point(114, 22);
            this._Txt_NPedido.Name = "_Txt_NPedido";
            this._Txt_NPedido.ReadOnly = true;
            this._Txt_NPedido.Size = new System.Drawing.Size(85, 18);
            this._Txt_NPedido.TabIndex = 3;
            // 
            // _Txt_Unidades
            // 
            this._Txt_Unidades.BackColor = System.Drawing.Color.White;
            this._Txt_Unidades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Unidades.Location = new System.Drawing.Point(90, 122);
            this._Txt_Unidades.Name = "_Txt_Unidades";
            this._Txt_Unidades.ReadOnly = true;
            this._Txt_Unidades.Size = new System.Drawing.Size(72, 18);
            this._Txt_Unidades.TabIndex = 14;
            this._Txt_Unidades.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(112, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pedido:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(326, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 12);
            this.label10.TabIndex = 15;
            this.label10.Text = "Monto Total:";
            // 
            // _Txt_NFactura
            // 
            this._Txt_NFactura.BackColor = System.Drawing.Color.White;
            this._Txt_NFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_NFactura.Location = new System.Drawing.Point(12, 22);
            this._Txt_NFactura.Name = "_Txt_NFactura";
            this._Txt_NFactura.ReadOnly = true;
            this._Txt_NFactura.Size = new System.Drawing.Size(95, 18);
            this._Txt_NFactura.TabIndex = 1;
            // 
            // _Txt_Monto
            // 
            this._Txt_Monto.BackColor = System.Drawing.Color.White;
            this._Txt_Monto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Monto.Location = new System.Drawing.Point(324, 122);
            this._Txt_Monto.Name = "_Txt_Monto";
            this._Txt_Monto.ReadOnly = true;
            this._Txt_Monto.Size = new System.Drawing.Size(72, 18);
            this._Txt_Monto.TabIndex = 16;
            this._Txt_Monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Factura:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 240);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 12);
            this.label11.TabIndex = 17;
            this.label11.Text = "Detalle de la Factura";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 12);
            this.label12.TabIndex = 27;
            this.label12.Text = "Observaciones de Factura:";
            // 
            // _Txt_Obs
            // 
            this._Txt_Obs.BackColor = System.Drawing.Color.White;
            this._Txt_Obs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Obs.Location = new System.Drawing.Point(12, 158);
            this._Txt_Obs.Multiline = true;
            this._Txt_Obs.Name = "_Txt_Obs";
            this._Txt_Obs.ReadOnly = true;
            this._Txt_Obs.Size = new System.Drawing.Size(386, 37);
            this._Txt_Obs.TabIndex = 28;
            // 
            // _Pnl_PanelPrincipal
            // 
            this._Pnl_PanelPrincipal.Controls.Add(this.label19);
            this._Pnl_PanelPrincipal.Controls.Add(this._Txt_CondicionPago);
            this._Pnl_PanelPrincipal.Controls.Add(this._Txt_NroControl);
            this._Pnl_PanelPrincipal.Controls.Add(this.label18);
            this._Pnl_PanelPrincipal.Controls.Add(this.label17);
            this._Pnl_PanelPrincipal.Controls.Add(this.label16);
            this._Pnl_PanelPrincipal.Controls.Add(this._Txt_MontoIVA);
            this._Pnl_PanelPrincipal.Controls.Add(this._Txt_MontoSinIVA);
            this._Pnl_PanelPrincipal.Controls.Add(this._Txt_ObsCobro);
            this._Pnl_PanelPrincipal.Controls.Add(this.label15);
            this._Pnl_PanelPrincipal.Controls.Add(this.label14);
            this._Pnl_PanelPrincipal.Controls.Add(this._Txt_StsGen);
            this._Pnl_PanelPrincipal.Controls.Add(this.label13);
            this._Pnl_PanelPrincipal.Controls.Add(this._Txt_StsCobro);
            this._Pnl_PanelPrincipal.Controls.Add(this.label7);
            this._Pnl_PanelPrincipal.Controls.Add(this._Txt_NGuiaDesp);
            this._Pnl_PanelPrincipal.Controls.Add(this.label6);
            this._Pnl_PanelPrincipal.Controls.Add(this._Txt_Fecha);
            this._Pnl_PanelPrincipal.Controls.Add(this._Txt_Obs);
            this._Pnl_PanelPrincipal.Controls.Add(this.label12);
            this._Pnl_PanelPrincipal.Controls.Add(this.label11);
            this._Pnl_PanelPrincipal.Controls.Add(this.label1);
            this._Pnl_PanelPrincipal.Controls.Add(this._Txt_Monto);
            this._Pnl_PanelPrincipal.Controls.Add(this._Txt_NFactura);
            this._Pnl_PanelPrincipal.Controls.Add(this.label10);
            this._Pnl_PanelPrincipal.Controls.Add(this.label2);
            this._Pnl_PanelPrincipal.Controls.Add(this._Txt_Unidades);
            this._Pnl_PanelPrincipal.Controls.Add(this._Txt_NPedido);
            this._Pnl_PanelPrincipal.Controls.Add(this.label9);
            this._Pnl_PanelPrincipal.Controls.Add(this.label3);
            this._Pnl_PanelPrincipal.Controls.Add(this._Txt_Cajas);
            this._Pnl_PanelPrincipal.Controls.Add(this._Txt_StsDesp);
            this._Pnl_PanelPrincipal.Controls.Add(this.label8);
            this._Pnl_PanelPrincipal.Controls.Add(this.label4);
            this._Pnl_PanelPrincipal.Controls.Add(this._Txt_Cliente);
            this._Pnl_PanelPrincipal.Controls.Add(this._Txt_Vendedor);
            this._Pnl_PanelPrincipal.Controls.Add(this.label5);
            this._Pnl_PanelPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this._Pnl_PanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this._Pnl_PanelPrincipal.Name = "_Pnl_PanelPrincipal";
            this._Pnl_PanelPrincipal.Size = new System.Drawing.Size(654, 257);
            this._Pnl_PanelPrincipal.TabIndex = 81;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(167, 108);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 12);
            this.label17.TabIndex = 42;
            this.label17.Text = "Monto sin IVA:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(253, 108);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 12);
            this.label16.TabIndex = 41;
            this.label16.Text = "Monto IVA:";
            // 
            // _Txt_MontoIVA
            // 
            this._Txt_MontoIVA.BackColor = System.Drawing.Color.White;
            this._Txt_MontoIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_MontoIVA.Location = new System.Drawing.Point(246, 122);
            this._Txt_MontoIVA.Name = "_Txt_MontoIVA";
            this._Txt_MontoIVA.ReadOnly = true;
            this._Txt_MontoIVA.Size = new System.Drawing.Size(72, 18);
            this._Txt_MontoIVA.TabIndex = 40;
            this._Txt_MontoIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _Txt_MontoSinIVA
            // 
            this._Txt_MontoSinIVA.BackColor = System.Drawing.Color.White;
            this._Txt_MontoSinIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_MontoSinIVA.Location = new System.Drawing.Point(168, 122);
            this._Txt_MontoSinIVA.Name = "_Txt_MontoSinIVA";
            this._Txt_MontoSinIVA.ReadOnly = true;
            this._Txt_MontoSinIVA.Size = new System.Drawing.Size(72, 18);
            this._Txt_MontoSinIVA.TabIndex = 39;
            this._Txt_MontoSinIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _Txt_ObsCobro
            // 
            this._Txt_ObsCobro.BackColor = System.Drawing.Color.Khaki;
            this._Txt_ObsCobro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_ObsCobro.Location = new System.Drawing.Point(413, 125);
            this._Txt_ObsCobro.Multiline = true;
            this._Txt_ObsCobro.Name = "_Txt_ObsCobro";
            this._Txt_ObsCobro.ReadOnly = true;
            this._Txt_ObsCobro.Size = new System.Drawing.Size(226, 70);
            this._Txt_ObsCobro.TabIndex = 38;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(411, 110);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(144, 12);
            this.label15.TabIndex = 37;
            this.label15.Text = "Observaciones de Cobranza:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(411, 75);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 12);
            this.label14.TabIndex = 35;
            this.label14.Text = "Estatus general:";
            // 
            // _Txt_StsGen
            // 
            this._Txt_StsGen.BackColor = System.Drawing.Color.Khaki;
            this._Txt_StsGen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_StsGen.Location = new System.Drawing.Point(413, 89);
            this._Txt_StsGen.Name = "_Txt_StsGen";
            this._Txt_StsGen.ReadOnly = true;
            this._Txt_StsGen.Size = new System.Drawing.Size(226, 18);
            this._Txt_StsGen.TabIndex = 36;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(411, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 12);
            this.label13.TabIndex = 33;
            this.label13.Text = "Estatus de cobranza:";
            // 
            // _Txt_StsCobro
            // 
            this._Txt_StsCobro.BackColor = System.Drawing.Color.Khaki;
            this._Txt_StsCobro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_StsCobro.Location = new System.Drawing.Point(413, 55);
            this._Txt_StsCobro.Name = "_Txt_StsCobro";
            this._Txt_StsCobro.ReadOnly = true;
            this._Txt_StsCobro.Size = new System.Drawing.Size(226, 18);
            this._Txt_StsCobro.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(203, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 12);
            this.label7.TabIndex = 31;
            this.label7.Text = "Guía D.:";
            // 
            // _Txt_NGuiaDesp
            // 
            this._Txt_NGuiaDesp.BackColor = System.Drawing.Color.White;
            this._Txt_NGuiaDesp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_NGuiaDesp.Location = new System.Drawing.Point(205, 22);
            this._Txt_NGuiaDesp.Name = "_Txt_NGuiaDesp";
            this._Txt_NGuiaDesp.ReadOnly = true;
            this._Txt_NGuiaDesp.Size = new System.Drawing.Size(85, 18);
            this._Txt_NGuiaDesp.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(294, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "Fecha:";
            // 
            // _Txt_Fecha
            // 
            this._Txt_Fecha.BackColor = System.Drawing.Color.White;
            this._Txt_Fecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Fecha.Location = new System.Drawing.Point(296, 22);
            this._Txt_Fecha.Name = "_Txt_Fecha";
            this._Txt_Fecha.ReadOnly = true;
            this._Txt_Fecha.Size = new System.Drawing.Size(102, 18);
            this._Txt_Fecha.TabIndex = 30;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(12, 200);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 12);
            this.label18.TabIndex = 43;
            this.label18.Text = "Nro. de control:";
            // 
            // _Txt_NroControl
            // 
            this._Txt_NroControl.BackColor = System.Drawing.Color.White;
            this._Txt_NroControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_NroControl.Location = new System.Drawing.Point(12, 215);
            this._Txt_NroControl.Name = "_Txt_NroControl";
            this._Txt_NroControl.ReadOnly = true;
            this._Txt_NroControl.Size = new System.Drawing.Size(82, 18);
            this._Txt_NroControl.TabIndex = 44;
            this._Txt_NroControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(411, 201);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(98, 12);
            this.label19.TabIndex = 45;
            this.label19.Text = "Condición de pago:";
            // 
            // _Txt_CondicionPago
            // 
            this._Txt_CondicionPago.BackColor = System.Drawing.Color.Khaki;
            this._Txt_CondicionPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_CondicionPago.Location = new System.Drawing.Point(413, 215);
            this._Txt_CondicionPago.Name = "_Txt_CondicionPago";
            this._Txt_CondicionPago.ReadOnly = true;
            this._Txt_CondicionPago.Size = new System.Drawing.Size(226, 18);
            this._Txt_CondicionPago.TabIndex = 46;
            // 
            // Frm_ConsultaFacturaDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 476);
            this.Controls.Add(this._Dg_Grid);
            this.Controls.Add(this._Pnl_PanelPrincipal);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ConsultaFacturaDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de la factura";
            this.Load += new System.EventHandler(this.Frm_ConsultaFacturaDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this._Pnl_PanelPrincipal.ResumeLayout(false);
            this._Pnl_PanelPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _Txt_Vendedor;
        private System.Windows.Forms.TextBox _Txt_Cliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _Txt_StsDesp;
        private System.Windows.Forms.TextBox _Txt_Cajas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox _Txt_NPedido;
        private System.Windows.Forms.TextBox _Txt_Unidades;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox _Txt_NFactura;
        private System.Windows.Forms.TextBox _Txt_Monto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox _Txt_Obs;
        private System.Windows.Forms.Panel _Pnl_PanelPrincipal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _Txt_Fecha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _Txt_NGuiaDesp;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox _Txt_StsCobro;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox _Txt_StsGen;
        private System.Windows.Forms.TextBox _Txt_ObsCobro;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox _Txt_MontoIVA;
        private System.Windows.Forms.TextBox _Txt_MontoSinIVA;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox _Txt_NroControl;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox _Txt_CondicionPago;
    }
}