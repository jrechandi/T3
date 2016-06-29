namespace T3
{
    partial class Frm_VentaporProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_VentaporProveedor));
            this._Dg_Grid1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this._Dg_Grid2 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this._bt_Agregar = new System.Windows.Forms.Button();
            this._Bt_Eliminar = new System.Windows.Forms.Button();
            this._Bt_Actualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid2)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Dg_Grid1
            // 
            this._Dg_Grid1.AllowUserToAddRows = false;
            this._Dg_Grid1.AllowUserToDeleteRows = false;
            this._Dg_Grid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this._Dg_Grid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid1.Location = new System.Drawing.Point(0, 22);
            this._Dg_Grid1.Name = "_Dg_Grid1";
            this._Dg_Grid1.ReadOnly = true;
            this._Dg_Grid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid1.Size = new System.Drawing.Size(316, 473);
            this._Dg_Grid1.TabIndex = 5;
            this._Dg_Grid1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid1_RowHeaderMouseClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Grupo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Dg_Grid2
            // 
            this._Dg_Grid2.AllowUserToAddRows = false;
            this._Dg_Grid2.AllowUserToDeleteRows = false;
            this._Dg_Grid2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this._Dg_Grid2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid2.Location = new System.Drawing.Point(0, 22);
            this._Dg_Grid2.Name = "_Dg_Grid2";
            this._Dg_Grid2.ReadOnly = true;
            this._Dg_Grid2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid2.Size = new System.Drawing.Size(389, 473);
            this._Dg_Grid2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Proveedores";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._Dg_Grid1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(316, 495);
            this.panel3.TabIndex = 13;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this._Dg_Grid2);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(407, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(389, 495);
            this.panel5.TabIndex = 14;
            // 
            // _bt_Agregar
            // 
            this._bt_Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._bt_Agregar.Image = ((System.Drawing.Image)(resources.GetObject("_bt_Agregar.Image")));
            this._bt_Agregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._bt_Agregar.Location = new System.Drawing.Point(322, 162);
            this._bt_Agregar.Name = "_bt_Agregar";
            this._bt_Agregar.Size = new System.Drawing.Size(79, 22);
            this._bt_Agregar.TabIndex = 15;
            this._bt_Agregar.Text = "Agregar";
            this._bt_Agregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._bt_Agregar.Visible = false;
            this._bt_Agregar.Click += new System.EventHandler(this._bt_Agregar_Click);
            // 
            // _Bt_Eliminar
            // 
            this._Bt_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Eliminar.Image")));
            this._Bt_Eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Eliminar.Location = new System.Drawing.Point(322, 202);
            this._Bt_Eliminar.Name = "_Bt_Eliminar";
            this._Bt_Eliminar.Size = new System.Drawing.Size(79, 22);
            this._Bt_Eliminar.TabIndex = 16;
            this._Bt_Eliminar.Text = "Eliminar";
            this._Bt_Eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Eliminar.Visible = false;
            this._Bt_Eliminar.Click += new System.EventHandler(this._Bt_Eliminar_Click);
            // 
            // _Bt_Actualizar
            // 
            this._Bt_Actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Actualizar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Actualizar.Image")));
            this._Bt_Actualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Actualizar.Location = new System.Drawing.Point(322, 245);
            this._Bt_Actualizar.Name = "_Bt_Actualizar";
            this._Bt_Actualizar.Size = new System.Drawing.Size(79, 22);
            this._Bt_Actualizar.TabIndex = 17;
            this._Bt_Actualizar.Text = "Actualizar";
            this._Bt_Actualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Actualizar.Click += new System.EventHandler(this._Bt_Actualizar_Click);
            // 
            // Frm_VentaporProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 495);
            this.Controls.Add(this._Bt_Actualizar);
            this.Controls.Add(this._Bt_Eliminar);
            this.Controls.Add(this._bt_Agregar);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_VentaporProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupo de Ventas por Proveedor";
            this.Load += new System.EventHandler(this.Frm_VentaporProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _Dg_Grid1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView _Dg_Grid2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button _bt_Agregar;
        private System.Windows.Forms.Button _Bt_Eliminar;
        private System.Windows.Forms.Button _Bt_Actualizar;
    }
}