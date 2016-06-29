namespace T3
{
    partial class Frm_EstatusBackOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_EstatusBackOrder));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this._Tool_Principal = new System.Windows.Forms.ToolStrip();
            this._Tool_Actualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this._Tool_Todos = new System.Windows.Forms.ToolStripMenuItem();
            this._Tool_Mes = new System.Windows.Forms.ToolStripMenuItem();
            this._Tool_Semana = new System.Windows.Forms.ToolStripMenuItem();
            this._Tool_Hoy = new System.Windows.Forms.ToolStripMenuItem();
            this._Tool_Periodo = new System.Windows.Forms.ToolStripMenuItem();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this.c_fecha_pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_nomb_comer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cempaques = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cvendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cunidades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Cntx_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verDetalleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._Pnl_Rango = new System.Windows.Forms.Panel();
            this._Dtp_FechHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this._Dtp_FechDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this._Bt_Aceptar = new System.Windows.Forms.Button();
            this._Bt_Cancelar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this._Tool_Principal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this._Cntx_Menu.SuspendLayout();
            this._Pnl_Rango.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Tool_Principal
            // 
            this._Tool_Principal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._Tool_Actualizar,
            this.toolStripSeparator2,
            this.toolStripSeparator1,
            this.toolStripSeparator4,
            this.toolStripDropDownButton1});
            this._Tool_Principal.Location = new System.Drawing.Point(0, 0);
            this._Tool_Principal.Name = "_Tool_Principal";
            this._Tool_Principal.Size = new System.Drawing.Size(809, 25);
            this._Tool_Principal.TabIndex = 3;
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
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._Tool_Todos,
            this._Tool_Mes,
            this._Tool_Semana,
            this._Tool_Hoy,
            this._Tool_Periodo});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // _Tool_Todos
            // 
            this._Tool_Todos.Image = ((System.Drawing.Image)(resources.GetObject("_Tool_Todos.Image")));
            this._Tool_Todos.Name = "_Tool_Todos";
            this._Tool_Todos.Size = new System.Drawing.Size(155, 22);
            this._Tool_Todos.Text = "Todos";
            this._Tool_Todos.Click += new System.EventHandler(this._Tool_Todos_Click);
            // 
            // _Tool_Mes
            // 
            this._Tool_Mes.Image = ((System.Drawing.Image)(resources.GetObject("_Tool_Mes.Image")));
            this._Tool_Mes.Name = "_Tool_Mes";
            this._Tool_Mes.Size = new System.Drawing.Size(155, 22);
            this._Tool_Mes.Text = "Mes actual";
            this._Tool_Mes.Click += new System.EventHandler(this._Tool_Mes_Click);
            // 
            // _Tool_Semana
            // 
            this._Tool_Semana.Image = ((System.Drawing.Image)(resources.GetObject("_Tool_Semana.Image")));
            this._Tool_Semana.Name = "_Tool_Semana";
            this._Tool_Semana.Size = new System.Drawing.Size(155, 22);
            this._Tool_Semana.Text = "Semana actual";
            this._Tool_Semana.Click += new System.EventHandler(this._Tool_Semana_Click);
            // 
            // _Tool_Hoy
            // 
            this._Tool_Hoy.Image = ((System.Drawing.Image)(resources.GetObject("_Tool_Hoy.Image")));
            this._Tool_Hoy.Name = "_Tool_Hoy";
            this._Tool_Hoy.Size = new System.Drawing.Size(155, 22);
            this._Tool_Hoy.Text = "Hoy";
            this._Tool_Hoy.Click += new System.EventHandler(this._Tool_Hoy_Click);
            // 
            // _Tool_Periodo
            // 
            this._Tool_Periodo.Image = ((System.Drawing.Image)(resources.GetObject("_Tool_Periodo.Image")));
            this._Tool_Periodo.Name = "_Tool_Periodo";
            this._Tool_Periodo.Size = new System.Drawing.Size(155, 22);
            this._Tool_Periodo.Text = "Período";
            this._Tool_Periodo.Click += new System.EventHandler(this._Tool_Periodo_Click);
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_fecha_pedido,
            this.cpedido,
            this.c_nomb_comer,
            this.cempaques,
            this.ccliente,
            this.cvendedor,
            this.cname,
            this.cunidades,
            this.Dias});
            this._Dg_Grid.ContextMenuStrip = this._Cntx_Menu;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(0, 25);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.Size = new System.Drawing.Size(809, 416);
            this._Dg_Grid.TabIndex = 5;
            this._Dg_Grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this._Dg_Grid_CellFormatting);
            this._Dg_Grid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_CellMouseEnter);
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
            // c_nomb_comer
            // 
            this.c_nomb_comer.DataPropertyName = "c_nomb_comer";
            dataGridViewCellStyle3.NullValue = "0";
            this.c_nomb_comer.DefaultCellStyle = dataGridViewCellStyle3;
            this.c_nomb_comer.HeaderText = "Cliente";
            this.c_nomb_comer.Name = "c_nomb_comer";
            this.c_nomb_comer.ReadOnly = true;
            // 
            // cempaques
            // 
            this.cempaques.DataPropertyName = "cempaques";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.NullValue = "0";
            this.cempaques.DefaultCellStyle = dataGridViewCellStyle4;
            this.cempaques.HeaderText = "Cajas";
            this.cempaques.Name = "cempaques";
            this.cempaques.ReadOnly = true;
            // 
            // ccliente
            // 
            this.ccliente.DataPropertyName = "ccliente";
            dataGridViewCellStyle5.NullValue = "0";
            this.ccliente.DefaultCellStyle = dataGridViewCellStyle5;
            this.ccliente.HeaderText = "ccliente";
            this.ccliente.Name = "ccliente";
            this.ccliente.ReadOnly = true;
            this.ccliente.Visible = false;
            // 
            // cvendedor
            // 
            this.cvendedor.DataPropertyName = "cvendedor";
            dataGridViewCellStyle6.NullValue = "0";
            this.cvendedor.DefaultCellStyle = dataGridViewCellStyle6;
            this.cvendedor.HeaderText = "cvendedor";
            this.cvendedor.Name = "cvendedor";
            this.cvendedor.ReadOnly = true;
            this.cvendedor.Visible = false;
            // 
            // cname
            // 
            this.cname.DataPropertyName = "cname";
            dataGridViewCellStyle7.NullValue = "0";
            this.cname.DefaultCellStyle = dataGridViewCellStyle7;
            this.cname.HeaderText = "cname";
            this.cname.Name = "cname";
            this.cname.ReadOnly = true;
            this.cname.Visible = false;
            // 
            // cunidades
            // 
            this.cunidades.DataPropertyName = "cunidades";
            dataGridViewCellStyle8.NullValue = "0";
            this.cunidades.DefaultCellStyle = dataGridViewCellStyle8;
            this.cunidades.HeaderText = "cunidades";
            this.cunidades.Name = "cunidades";
            this.cunidades.ReadOnly = true;
            this.cunidades.Visible = false;
            // 
            // Dias
            // 
            this.Dias.DataPropertyName = "Dias";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Dias.DefaultCellStyle = dataGridViewCellStyle9;
            this.Dias.HeaderText = "Días Transcurridos";
            this.Dias.Name = "Dias";
            this.Dias.ReadOnly = true;
            this.Dias.Width = 110;
            // 
            // _Cntx_Menu
            // 
            this._Cntx_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verDetalleToolStripMenuItem});
            this._Cntx_Menu.Name = "_Cntx_Menu";
            this._Cntx_Menu.Size = new System.Drawing.Size(137, 26);
            this._Cntx_Menu.Opening += new System.ComponentModel.CancelEventHandler(this._Cntx_Menu_Opening);
            // 
            // verDetalleToolStripMenuItem
            // 
            this.verDetalleToolStripMenuItem.Name = "verDetalleToolStripMenuItem";
            this.verDetalleToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.verDetalleToolStripMenuItem.Text = "Ver detalle";
            this.verDetalleToolStripMenuItem.Click += new System.EventHandler(this.verDetalleToolStripMenuItem_Click);
            // 
            // _Pnl_Rango
            // 
            this._Pnl_Rango.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Rango.Controls.Add(this._Dtp_FechHasta);
            this._Pnl_Rango.Controls.Add(this.label2);
            this._Pnl_Rango.Controls.Add(this._Dtp_FechDesde);
            this._Pnl_Rango.Controls.Add(this.label1);
            this._Pnl_Rango.Controls.Add(this._Bt_Aceptar);
            this._Pnl_Rango.Controls.Add(this._Bt_Cancelar);
            this._Pnl_Rango.Controls.Add(this.label12);
            this._Pnl_Rango.Location = new System.Drawing.Point(317, 186);
            this._Pnl_Rango.Name = "_Pnl_Rango";
            this._Pnl_Rango.Size = new System.Drawing.Size(174, 80);
            this._Pnl_Rango.TabIndex = 79;
            this._Pnl_Rango.Visible = false;
            this._Pnl_Rango.VisibleChanged += new System.EventHandler(this._Pnl_Rango_VisibleChanged);
            // 
            // _Dtp_FechHasta
            // 
            this._Dtp_FechHasta.CalendarFont = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Dtp_FechHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Dtp_FechHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dtp_FechHasta.Location = new System.Drawing.Point(89, 33);
            this._Dtp_FechHasta.Name = "_Dtp_FechHasta";
            this._Dtp_FechHasta.Size = new System.Drawing.Size(80, 18);
            this._Dtp_FechHasta.TabIndex = 73;
            this._Dtp_FechHasta.Value = new System.DateTime(2007, 5, 16, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(89, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 74;
            this.label2.Text = "Fecha hasta";
            // 
            // _Dtp_FechDesde
            // 
            this._Dtp_FechDesde.CalendarFont = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Dtp_FechDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Dtp_FechDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dtp_FechDesde.Location = new System.Drawing.Point(3, 33);
            this._Dtp_FechDesde.Name = "_Dtp_FechDesde";
            this._Dtp_FechDesde.Size = new System.Drawing.Size(80, 18);
            this._Dtp_FechDesde.TabIndex = 72;
            this._Dtp_FechDesde.Value = new System.DateTime(2007, 5, 16, 0, 0, 0, 0);
            this._Dtp_FechDesde.ValueChanged += new System.EventHandler(this._Dtp_FechDesde_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 12);
            this.label1.TabIndex = 71;
            this.label1.Text = "Fecha desde";
            // 
            // _Bt_Aceptar
            // 
            this._Bt_Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Aceptar.Location = new System.Drawing.Point(28, 55);
            this._Bt_Aceptar.Name = "_Bt_Aceptar";
            this._Bt_Aceptar.Size = new System.Drawing.Size(66, 18);
            this._Bt_Aceptar.TabIndex = 70;
            this._Bt_Aceptar.Text = "Aceptar";
            this._Bt_Aceptar.UseVisualStyleBackColor = true;
            this._Bt_Aceptar.Click += new System.EventHandler(this._Bt_Aceptar_Click);
            // 
            // _Bt_Cancelar
            // 
            this._Bt_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Cancelar.Location = new System.Drawing.Point(100, 55);
            this._Bt_Cancelar.Name = "_Bt_Cancelar";
            this._Bt_Cancelar.Size = new System.Drawing.Size(69, 18);
            this._Bt_Cancelar.TabIndex = 1;
            this._Bt_Cancelar.Text = "Cancelar";
            this._Bt_Cancelar.UseVisualStyleBackColor = true;
            this._Bt_Cancelar.Click += new System.EventHandler(this._Bt_Cancelar_Click);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Navy;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(172, 18);
            this.label12.TabIndex = 0;
            this.label12.Text = "Período";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(0, 441);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(809, 11);
            this._Lbl_DgInfo.TabIndex = 80;
            this._Lbl_DgInfo.Text = "Use botón derecho";
            this._Lbl_DgInfo.Visible = false;
            // 
            // Frm_EstatusBackOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 452);
            this.Controls.Add(this._Dg_Grid);
            this.Controls.Add(this._Lbl_DgInfo);
            this.Controls.Add(this._Pnl_Rango);
            this.Controls.Add(this._Tool_Principal);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_EstatusBackOrder";
            this.Text = "Estatus de BackOrder";
            this.Activated += new System.EventHandler(this.Frm_EstatusBackOrder_Activated);
            this.Load += new System.EventHandler(this.Frm_EstatusBackOrder_Load);
            this._Tool_Principal.ResumeLayout(false);
            this._Tool_Principal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this._Cntx_Menu.ResumeLayout(false);
            this._Pnl_Rango.ResumeLayout(false);
            this._Pnl_Rango.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _Tool_Principal;
        private System.Windows.Forms.ToolStripButton _Tool_Actualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem _Tool_Todos;
        private System.Windows.Forms.ToolStripMenuItem _Tool_Mes;
        private System.Windows.Forms.ToolStripMenuItem _Tool_Semana;
        private System.Windows.Forms.ToolStripMenuItem _Tool_Hoy;
        private System.Windows.Forms.ToolStripMenuItem _Tool_Periodo;
        private System.Windows.Forms.Panel _Pnl_Rango;
        private System.Windows.Forms.DateTimePicker _Dtp_FechHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker _Dtp_FechDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _Bt_Aceptar;
        private System.Windows.Forms.Button _Bt_Cancelar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ContextMenuStrip _Cntx_Menu;
        private System.Windows.Forms.ToolStripMenuItem verDetalleToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_fecha_pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_nomb_comer;
        private System.Windows.Forms.DataGridViewTextBoxColumn cempaques;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cvendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cname;
        private System.Windows.Forms.DataGridViewTextBoxColumn cunidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dias;
        private System.Windows.Forms.Label _Lbl_DgInfo;
    }
}