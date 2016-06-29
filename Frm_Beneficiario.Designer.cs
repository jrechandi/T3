namespace T3
{
    partial class Frm_Beneficiario
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
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this._Txt_Rif = new System.Windows.Forms.MaskedTextBox();
            this._Pnl_SeleccTipo = new System.Windows.Forms.Panel();
            this._Rbt_Rif = new System.Windows.Forms.RadioButton();
            this._Rbt_Cedula = new System.Windows.Forms.RadioButton();
            this._Cmb_TipoBeneficiario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Txt_Descripcion = new System.Windows.Forms.TextBox();
            this._Txt_BeneficiarioId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Ctrl_Busqueda1 = new T3.Controles._Ctrl_Busqueda();
            this._Txt_Apellido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this.tabPage2.SuspendLayout();
            this._Pnl_SeleccTipo.SuspendLayout();
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
            this._Tb_Tab.Size = new System.Drawing.Size(658, 266);
            this._Tb_Tab.TabIndex = 4;
            this._Tb_Tab.SelectedIndexChanged += new System.EventHandler(this._Tb_Tab_SelectedIndexChanged);
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
            this.tabPage1.Size = new System.Drawing.Size(629, 229);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Dg_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(3, 47);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Size = new System.Drawing.Size(623, 167);
            this._Dg_Grid.TabIndex = 1;
            this._Dg_Grid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_CellMouseEnter);
            this._Dg_Grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseDoubleClick);
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(3, 214);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(623, 12);
            this._Lbl_DgInfo.TabIndex = 6;
            this._Lbl_DgInfo.Text = "Use doble click";
            this._Lbl_DgInfo.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._Txt_Apellido);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this._Txt_Rif);
            this.tabPage2.Controls.Add(this._Pnl_SeleccTipo);
            this.tabPage2.Controls.Add(this._Cmb_TipoBeneficiario);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this._Txt_Descripcion);
            this.tabPage2.Controls.Add(this._Txt_BeneficiarioId);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(650, 241);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 12);
            this.label4.TabIndex = 160;
            this.label4.Text = "Cédula o Rif del Beneficiario:";
            // 
            // _Txt_Rif
            // 
            this._Txt_Rif.BackColor = System.Drawing.SystemColors.Control;
            this._Txt_Rif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Rif.Enabled = false;
            this._Txt_Rif.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold);
            this._Txt_Rif.Location = new System.Drawing.Point(11, 104);
            this._Txt_Rif.Mask = "L-00000000-0";
            this._Txt_Rif.Name = "_Txt_Rif";
            this._Txt_Rif.Size = new System.Drawing.Size(320, 18);
            this._Txt_Rif.TabIndex = 1;
            // 
            // _Pnl_SeleccTipo
            // 
            this._Pnl_SeleccTipo.Controls.Add(this._Rbt_Rif);
            this._Pnl_SeleccTipo.Controls.Add(this._Rbt_Cedula);
            this._Pnl_SeleccTipo.Location = new System.Drawing.Point(10, 59);
            this._Pnl_SeleccTipo.Name = "_Pnl_SeleccTipo";
            this._Pnl_SeleccTipo.Size = new System.Drawing.Size(118, 21);
            this._Pnl_SeleccTipo.TabIndex = 0;
            // 
            // _Rbt_Rif
            // 
            this._Rbt_Rif.AutoSize = true;
            this._Rbt_Rif.Checked = true;
            this._Rbt_Rif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Rbt_Rif.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Rbt_Rif.Location = new System.Drawing.Point(61, 2);
            this._Rbt_Rif.Name = "_Rbt_Rif";
            this._Rbt_Rif.Size = new System.Drawing.Size(35, 16);
            this._Rbt_Rif.TabIndex = 12;
            this._Rbt_Rif.TabStop = true;
            this._Rbt_Rif.Text = "Rif";
            this._Rbt_Rif.UseVisualStyleBackColor = true;
            this._Rbt_Rif.CheckedChanged += new System.EventHandler(this._Rbt_Rif_CheckedChanged);
            // 
            // _Rbt_Cedula
            // 
            this._Rbt_Cedula.AutoSize = true;
            this._Rbt_Cedula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Rbt_Cedula.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Rbt_Cedula.Location = new System.Drawing.Point(3, 2);
            this._Rbt_Cedula.Name = "_Rbt_Cedula";
            this._Rbt_Cedula.Size = new System.Drawing.Size(57, 16);
            this._Rbt_Cedula.TabIndex = 11;
            this._Rbt_Cedula.Text = "Cedula";
            this._Rbt_Cedula.UseVisualStyleBackColor = true;
            this._Rbt_Cedula.CheckedChanged += new System.EventHandler(this._Rbt_Cedula_CheckedChanged);
            // 
            // _Cmb_TipoBeneficiario
            // 
            this._Cmb_TipoBeneficiario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_TipoBeneficiario.FormattingEnabled = true;
            this._Cmb_TipoBeneficiario.Location = new System.Drawing.Point(10, 204);
            this._Cmb_TipoBeneficiario.Name = "_Cmb_TipoBeneficiario";
            this._Cmb_TipoBeneficiario.Size = new System.Drawing.Size(321, 20);
            this._Cmb_TipoBeneficiario.TabIndex = 3;
            this._Cmb_TipoBeneficiario.DropDown += new System.EventHandler(this._Cmb_TipoBeneficiario_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Id Beneficario:";
            // 
            // _Txt_Descripcion
            // 
            this._Txt_Descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Descripcion.Enabled = false;
            this._Txt_Descripcion.Location = new System.Drawing.Point(11, 138);
            this._Txt_Descripcion.MaxLength = 50;
            this._Txt_Descripcion.Name = "_Txt_Descripcion";
            this._Txt_Descripcion.Size = new System.Drawing.Size(321, 18);
            this._Txt_Descripcion.TabIndex = 2;
            // 
            // _Txt_BeneficiarioId
            // 
            this._Txt_BeneficiarioId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_BeneficiarioId.Enabled = false;
            this._Txt_BeneficiarioId.Location = new System.Drawing.Point(10, 35);
            this._Txt_BeneficiarioId.MaxLength = 10;
            this._Txt_BeneficiarioId.Name = "_Txt_BeneficiarioId";
            this._Txt_BeneficiarioId.ReadOnly = true;
            this._Txt_BeneficiarioId.Size = new System.Drawing.Size(122, 18);
            this._Txt_BeneficiarioId.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nombres:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tipo:";
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // _Ctrl_Busqueda1
            // 
            this._Ctrl_Busqueda1.Dock = System.Windows.Forms.DockStyle.Top;
            this._Ctrl_Busqueda1.Location = new System.Drawing.Point(3, 3);
            this._Ctrl_Busqueda1.Name = "_Ctrl_Busqueda1";
            this._Ctrl_Busqueda1.Size = new System.Drawing.Size(623, 44);
            this._Ctrl_Busqueda1.TabIndex = 2;
            // 
            // _Txt_Apellido
            // 
            this._Txt_Apellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Apellido.Enabled = false;
            this._Txt_Apellido.Location = new System.Drawing.Point(11, 171);
            this._Txt_Apellido.MaxLength = 50;
            this._Txt_Apellido.Name = "_Txt_Apellido";
            this._Txt_Apellido.Size = new System.Drawing.Size(321, 18);
            this._Txt_Apellido.TabIndex = 161;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 12);
            this.label5.TabIndex = 162;
            this.label5.Text = "Apellidos:";
            // 
            // Frm_Beneficiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 266);
            this.Controls.Add(this._Tb_Tab);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Beneficiario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Beneficiario";
            this.Activated += new System.EventHandler(this.Frm_Beneficiario_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Beneficiario_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Beneficiario_Load);
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this._Pnl_SeleccTipo.ResumeLayout(false);
            this._Pnl_SeleccTipo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _Txt_Descripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _Txt_BeneficiarioId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private T3.Controles._Ctrl_Busqueda _Ctrl_Busqueda1;
        private System.Windows.Forms.Label _Lbl_DgInfo;
        private System.Windows.Forms.ComboBox _Cmb_TipoBeneficiario;
        private System.Windows.Forms.Panel _Pnl_SeleccTipo;
        private System.Windows.Forms.RadioButton _Rbt_Rif;
        private System.Windows.Forms.RadioButton _Rbt_Cedula;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox _Txt_Rif;
        private System.Windows.Forms.TextBox _Txt_Apellido;
        private System.Windows.Forms.Label label5;
    }
}