namespace T3
{
    partial class Frm_BusquedaProductoLote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_BusquedaProductoLote));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this._Bt_Restablecer = new System.Windows.Forms.Button();
            this._Lbl_CodLote = new System.Windows.Forms.Label();
            this._Txt_CodLote = new System.Windows.Forms.TextBox();
            this._Bt_Buscar = new System.Windows.Forms.Button();
            this._Lbl_Producto = new System.Windows.Forms.Label();
            this._Txt_CodProducto = new System.Windows.Forms.TextBox();
            this._Lbl_SubGrupo = new System.Windows.Forms.Label();
            this._Lbl_Grupo = new System.Windows.Forms.Label();
            this._Lbl_Proveedor = new System.Windows.Forms.Label();
            this._Cmb_Proveedor = new System.Windows.Forms.ComboBox();
            this._Cmb_Grupo = new System.Windows.Forms.ComboBox();
            this._Cmb_Subgrupo = new System.Windows.Forms.ComboBox();
            this._Dtg_Productos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PMV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnamefc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dtg_Productos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._Bt_Restablecer);
            this.panel1.Controls.Add(this._Lbl_CodLote);
            this.panel1.Controls.Add(this._Txt_CodLote);
            this.panel1.Controls.Add(this._Bt_Buscar);
            this.panel1.Controls.Add(this._Lbl_Producto);
            this.panel1.Controls.Add(this._Txt_CodProducto);
            this.panel1.Controls.Add(this._Lbl_SubGrupo);
            this.panel1.Controls.Add(this._Lbl_Grupo);
            this.panel1.Controls.Add(this._Lbl_Proveedor);
            this.panel1.Controls.Add(this._Cmb_Proveedor);
            this.panel1.Controls.Add(this._Cmb_Grupo);
            this.panel1.Controls.Add(this._Cmb_Subgrupo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(721, 146);
            this.panel1.TabIndex = 0;
            // 
            // _Bt_Restablecer
            // 
            this._Bt_Restablecer.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Restablecer.Image")));
            this._Bt_Restablecer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Restablecer.Location = new System.Drawing.Point(266, 114);
            this._Bt_Restablecer.Name = "_Bt_Restablecer";
            this._Bt_Restablecer.Size = new System.Drawing.Size(92, 20);
            this._Bt_Restablecer.TabIndex = 73;
            this._Bt_Restablecer.Text = "Restablecer";
            this._Bt_Restablecer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Restablecer.UseVisualStyleBackColor = true;
            this._Bt_Restablecer.Click += new System.EventHandler(this._Bt_Restablecer_Click);
            // 
            // _Lbl_CodLote
            // 
            this._Lbl_CodLote.AutoSize = true;
            this._Lbl_CodLote.Location = new System.Drawing.Point(37, 117);
            this._Lbl_CodLote.Name = "_Lbl_CodLote";
            this._Lbl_CodLote.Size = new System.Drawing.Size(84, 13);
            this._Lbl_CodLote.TabIndex = 72;
            this._Lbl_CodLote.Text = "Código del Lote:";
            // 
            // _Txt_CodLote
            // 
            this._Txt_CodLote.Location = new System.Drawing.Point(129, 114);
            this._Txt_CodLote.Name = "_Txt_CodLote";
            this._Txt_CodLote.Size = new System.Drawing.Size(114, 20);
            this._Txt_CodLote.TabIndex = 71;
            this._Txt_CodLote.TextChanged += new System.EventHandler(this._Txt_CodLote_TextChanged);
            this._Txt_CodLote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_CodLote_KeyPress);
            // 
            // _Bt_Buscar
            // 
            this._Bt_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Buscar.Image")));
            this._Bt_Buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Buscar.Location = new System.Drawing.Point(364, 114);
            this._Bt_Buscar.Name = "_Bt_Buscar";
            this._Bt_Buscar.Size = new System.Drawing.Size(69, 20);
            this._Bt_Buscar.TabIndex = 70;
            this._Bt_Buscar.Text = "Buscar";
            this._Bt_Buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Buscar.UseVisualStyleBackColor = true;
            this._Bt_Buscar.Click += new System.EventHandler(this._Bt_Buscar_Click);
            // 
            // _Lbl_Producto
            // 
            this._Lbl_Producto.AutoSize = true;
            this._Lbl_Producto.Location = new System.Drawing.Point(16, 92);
            this._Lbl_Producto.Name = "_Lbl_Producto";
            this._Lbl_Producto.Size = new System.Drawing.Size(105, 13);
            this._Lbl_Producto.TabIndex = 27;
            this._Lbl_Producto.Text = "Código Producto T3:";
            // 
            // _Txt_CodProducto
            // 
            this._Txt_CodProducto.Location = new System.Drawing.Point(129, 89);
            this._Txt_CodProducto.Name = "_Txt_CodProducto";
            this._Txt_CodProducto.Size = new System.Drawing.Size(150, 20);
            this._Txt_CodProducto.TabIndex = 26;
            // 
            // _Lbl_SubGrupo
            // 
            this._Lbl_SubGrupo.AutoSize = true;
            this._Lbl_SubGrupo.Location = new System.Drawing.Point(65, 66);
            this._Lbl_SubGrupo.Name = "_Lbl_SubGrupo";
            this._Lbl_SubGrupo.Size = new System.Drawing.Size(56, 13);
            this._Lbl_SubGrupo.TabIndex = 25;
            this._Lbl_SubGrupo.Text = "Subgrupo:";
            // 
            // _Lbl_Grupo
            // 
            this._Lbl_Grupo.AutoSize = true;
            this._Lbl_Grupo.Location = new System.Drawing.Point(82, 38);
            this._Lbl_Grupo.Name = "_Lbl_Grupo";
            this._Lbl_Grupo.Size = new System.Drawing.Size(39, 13);
            this._Lbl_Grupo.TabIndex = 24;
            this._Lbl_Grupo.Text = "Grupo:";
            // 
            // _Lbl_Proveedor
            // 
            this._Lbl_Proveedor.AutoSize = true;
            this._Lbl_Proveedor.Location = new System.Drawing.Point(62, 14);
            this._Lbl_Proveedor.Name = "_Lbl_Proveedor";
            this._Lbl_Proveedor.Size = new System.Drawing.Size(59, 13);
            this._Lbl_Proveedor.TabIndex = 23;
            this._Lbl_Proveedor.Text = "Proveedor:";
            // 
            // _Cmb_Proveedor
            // 
            this._Cmb_Proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Proveedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Cmb_Proveedor.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Proveedor.FormattingEnabled = true;
            this._Cmb_Proveedor.Location = new System.Drawing.Point(129, 12);
            this._Cmb_Proveedor.Name = "_Cmb_Proveedor";
            this._Cmb_Proveedor.Size = new System.Drawing.Size(304, 20);
            this._Cmb_Proveedor.TabIndex = 20;
            this._Cmb_Proveedor.SelectedIndexChanged += new System.EventHandler(this._Cmb_Proveedor_SelectedIndexChanged);
            // 
            // _Cmb_Grupo
            // 
            this._Cmb_Grupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Grupo.Enabled = false;
            this._Cmb_Grupo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Cmb_Grupo.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Grupo.FormattingEnabled = true;
            this._Cmb_Grupo.Location = new System.Drawing.Point(129, 36);
            this._Cmb_Grupo.Name = "_Cmb_Grupo";
            this._Cmb_Grupo.Size = new System.Drawing.Size(304, 20);
            this._Cmb_Grupo.TabIndex = 21;
            this._Cmb_Grupo.DropDown += new System.EventHandler(this._Cmb_Grupo_DropDown);
            this._Cmb_Grupo.SelectedIndexChanged += new System.EventHandler(this._Cmb_Grupo_SelectedIndexChanged);
            // 
            // _Cmb_Subgrupo
            // 
            this._Cmb_Subgrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Subgrupo.Enabled = false;
            this._Cmb_Subgrupo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._Cmb_Subgrupo.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cmb_Subgrupo.FormattingEnabled = true;
            this._Cmb_Subgrupo.Location = new System.Drawing.Point(129, 62);
            this._Cmb_Subgrupo.Name = "_Cmb_Subgrupo";
            this._Cmb_Subgrupo.Size = new System.Drawing.Size(304, 20);
            this._Cmb_Subgrupo.TabIndex = 22;
            this._Cmb_Subgrupo.DropDown += new System.EventHandler(this._Cmb_Subgrupo_DropDown);
            // 
            // _Dtg_Productos
            // 
            this._Dtg_Productos.AllowUserToAddRows = false;
            this._Dtg_Productos.AllowUserToDeleteRows = false;
            this._Dtg_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dtg_Productos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.CodLote,
            this.PMV,
            this.cnamefc});
            this._Dtg_Productos.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dtg_Productos.Location = new System.Drawing.Point(0, 146);
            this._Dtg_Productos.Name = "_Dtg_Productos";
            this._Dtg_Productos.Size = new System.Drawing.Size(721, 206);
            this._Dtg_Productos.TabIndex = 1;
            this._Dtg_Productos.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dtg_Productos_RowHeaderMouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "cproducto";
            this.Column1.HeaderText = "Cód. Producto";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // CodLote
            // 
            this.CodLote.DataPropertyName = "cidproductod";
            this.CodLote.HeaderText = "Lote";
            this.CodLote.Name = "CodLote";
            this.CodLote.ReadOnly = true;
            // 
            // PMV
            // 
            this.PMV.DataPropertyName = "cprecioventamax";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PMV.DefaultCellStyle = dataGridViewCellStyle2;
            this.PMV.HeaderText = "PMV";
            this.PMV.Name = "PMV";
            this.PMV.ReadOnly = true;
            // 
            // cnamefc
            // 
            this.cnamefc.DataPropertyName = "cnamefc";
            this.cnamefc.HeaderText = "Descripción";
            this.cnamefc.Name = "cnamefc";
            this.cnamefc.ReadOnly = true;
            // 
            // Frm_BusquedaProductoLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 352);
            this.Controls.Add(this._Dtg_Productos);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_BusquedaProductoLote";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda de productos";
            this.Load += new System.EventHandler(this.Frm_BusquedaProductoLote_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dtg_Productos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView _Dtg_Productos;
        private System.Windows.Forms.Label _Lbl_Producto;
        private System.Windows.Forms.TextBox _Txt_CodProducto;
        private System.Windows.Forms.Label _Lbl_SubGrupo;
        private System.Windows.Forms.Label _Lbl_Grupo;
        private System.Windows.Forms.Label _Lbl_Proveedor;
        private System.Windows.Forms.ComboBox _Cmb_Proveedor;
        private System.Windows.Forms.ComboBox _Cmb_Grupo;
        private System.Windows.Forms.ComboBox _Cmb_Subgrupo;
        private System.Windows.Forms.Label _Lbl_CodLote;
        private System.Windows.Forms.TextBox _Txt_CodLote;
        private System.Windows.Forms.Button _Bt_Buscar;
        private System.Windows.Forms.Button _Bt_Restablecer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn PMV;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnamefc;
    }
}