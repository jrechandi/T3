namespace T3
{
    partial class Frm_GrupodeVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_GrupodeVentas));
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this._Ctrl_Busqueda1 = new T3.Controles._Ctrl_Busqueda();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._Txt_Descripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Txt_Codigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
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
            this._Tb_Tab.Size = new System.Drawing.Size(338, 213);
            this._Tb_Tab.TabIndex = 5;
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
            this.tabPage1.Size = new System.Drawing.Size(330, 188);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(3, 47);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Size = new System.Drawing.Size(324, 126);
            this._Dg_Grid.TabIndex = 1;
            this._Dg_Grid.DoubleClick += new System.EventHandler(this._Dg_Grid_DoubleClick);
            this._Dg_Grid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_CellMouseEnter);
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(3, 173);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(324, 12);
            this._Lbl_DgInfo.TabIndex = 6;
            this._Lbl_DgInfo.Text = "Use doble click";
            this._Lbl_DgInfo.Visible = false;
            // 
            // _Ctrl_Busqueda1
            // 
            this._Ctrl_Busqueda1.Dock = System.Windows.Forms.DockStyle.Top;
            this._Ctrl_Busqueda1.Location = new System.Drawing.Point(3, 3);
            this._Ctrl_Busqueda1.Name = "_Ctrl_Busqueda1";
            this._Ctrl_Busqueda1.Size = new System.Drawing.Size(324, 44);
            this._Ctrl_Busqueda1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._Txt_Descripcion);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this._Txt_Codigo);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(330, 188);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _Txt_Descripcion
            // 
            this._Txt_Descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Descripcion.Enabled = false;
            this._Txt_Descripcion.Location = new System.Drawing.Point(85, 77);
            this._Txt_Descripcion.MaxLength = 30;
            this._Txt_Descripcion.Name = "_Txt_Descripcion";
            this._Txt_Descripcion.Size = new System.Drawing.Size(216, 18);
            this._Txt_Descripcion.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Descripción:";
            // 
            // _Txt_Codigo
            // 
            this._Txt_Codigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Codigo.Enabled = false;
            this._Txt_Codigo.Location = new System.Drawing.Point(85, 43);
            this._Txt_Codigo.MaxLength = 20;
            this._Txt_Codigo.Name = "_Txt_Codigo";
            this._Txt_Codigo.Size = new System.Drawing.Size(122, 18);
            this._Txt_Codigo.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "Código:";
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // Frm_GrupodeVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 213);
            this.Controls.Add(this._Tb_Tab);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_GrupodeVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupos de Venta";
            this.Load += new System.EventHandler(this.Frm_GrupodeVentas_Load);
            this.Activated += new System.EventHandler(this.Frm_GrupodeVentas_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_GrupodeVentas_FormClosing);
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private T3.Controles._Ctrl_Busqueda _Ctrl_Busqueda1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.TextBox _Txt_Descripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _Txt_Codigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _Lbl_DgInfo;
    }
}