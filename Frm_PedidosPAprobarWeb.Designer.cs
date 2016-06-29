namespace T3
{
    partial class Frm_PedidosPAprobarWeb
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
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this.codcliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ncliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this._Dg_Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Dg_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codcliente,
            this.ncliente,
            this.cpedido,
            this.fecha});
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(0, 0);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this._Dg_Grid.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this._Dg_Grid.Size = new System.Drawing.Size(656, 315);
            this._Dg_Grid.TabIndex = 2;
            // 
            // codcliente
            // 
            this.codcliente.DataPropertyName = "codcliente";
            this.codcliente.HeaderText = "Código Cliente";
            this.codcliente.Name = "codcliente";
            this.codcliente.ReadOnly = true;
            // 
            // ncliente
            // 
            this.ncliente.DataPropertyName = "ncliente";
            this.ncliente.HeaderText = "Descripción";
            this.ncliente.Name = "ncliente";
            this.ncliente.ReadOnly = true;
            this.ncliente.Width = 88;
            // 
            // cpedido
            // 
            this.cpedido.DataPropertyName = "cpedido";
            this.cpedido.HeaderText = "Código Pedido";
            this.cpedido.Name = "cpedido";
            this.cpedido.ReadOnly = true;
            this.cpedido.Width = 101;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "fecha";
            this.fecha.HeaderText = "Fecha Pedido";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 98;
            // 
            // Frm_PedidosPAprobarWeb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 315);
            this.Controls.Add(this._Dg_Grid);
            this.Name = "Frm_PedidosPAprobarWeb";
            this.Text = "Pedidos pendientes por aprobar";
            this.Load += new System.EventHandler(this.Frm_PedidosPAprobarWeb_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn codcliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ncliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
    }
}