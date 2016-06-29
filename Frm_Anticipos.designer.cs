namespace T3
{
    partial class Frm_Anticipos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Anticipos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this._Txt_ChequeTransf = new System.Windows.Forms.TextBox();
            this._Bt_Restablecer = new System.Windows.Forms.Button();
            this._Chk_Fecha = new System.Windows.Forms.CheckBox();
            this._Txt_Beneficiario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._Cmb_Cuenta = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this._Cmb_Banco = new System.Windows.Forms.ComboBox();
            this._Bt_Consultar = new System.Windows.Forms.Button();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this._Cntx_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._CMen_OrdPago_Sel = new System.Windows.Forms.ToolStripMenuItem();
            this._Lbl_DgInfo = new System.Windows.Forms.Label();
            this._Bt_Guardar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._Dg_Grid_2 = new System.Windows.Forms.DataGridView();
            this._Cntx_Menu_2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._Lbl_DgInfo_2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this._Bt_Quitar = new System.Windows.Forms.Button();
            this._Pnl_Opcionnes = new System.Windows.Forms.Panel();
            this._Bt_Cancelar = new System.Windows.Forms.Button();
            this._Bt_Registrar = new System.Windows.Forms.Button();
            this._Bt_ND = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this._Pnl_Clave = new System.Windows.Forms.Panel();
            this._Bt_AceptarClave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this._Txt_Clave = new System.Windows.Forms.TextBox();
            this._Bt_CancelarClave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this._Ctrl_ConsultaMes1 = new T3.Controles._Ctrl_ConsultaMes();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).BeginInit();
            this._Cntx_Menu.SuspendLayout();
            this.panel3.SuspendLayout();
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_2)).BeginInit();
            this._Cntx_Menu_2.SuspendLayout();
            this.panel2.SuspendLayout();
            this._Pnl_Opcionnes.SuspendLayout();
            this._Pnl_Clave.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._Txt_ChequeTransf);
            this.panel1.Controls.Add(this._Bt_Restablecer);
            this.panel1.Controls.Add(this._Chk_Fecha);
            this.panel1.Controls.Add(this._Txt_Beneficiario);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this._Cmb_Cuenta);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this._Cmb_Banco);
            this.panel1.Controls.Add(this._Bt_Consultar);
            this.panel1.Controls.Add(this._Ctrl_ConsultaMes1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(738, 179);
            this.panel1.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 98;
            this.label1.Text = "Cheque / Transferencia";
            // 
            // _Txt_ChequeTransf
            // 
            this._Txt_ChequeTransf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_ChequeTransf.Location = new System.Drawing.Point(15, 110);
            this._Txt_ChequeTransf.Name = "_Txt_ChequeTransf";
            this._Txt_ChequeTransf.Size = new System.Drawing.Size(184, 21);
            this._Txt_ChequeTransf.TabIndex = 2;
            this._Txt_ChequeTransf.TextChanged += new System.EventHandler(this._Txt_Cheque_TextChanged);
            this._Txt_ChequeTransf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Cheque_KeyPress);
            // 
            // _Bt_Restablecer
            // 
            this._Bt_Restablecer.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Restablecer.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this._Bt_Restablecer.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Restablecer.Image")));
            this._Bt_Restablecer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Restablecer.Location = new System.Drawing.Point(383, 84);
            this._Bt_Restablecer.Name = "_Bt_Restablecer";
            this._Bt_Restablecer.Size = new System.Drawing.Size(120, 33);
            this._Bt_Restablecer.TabIndex = 6;
            this._Bt_Restablecer.Text = "Restablecer";
            this._Bt_Restablecer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Restablecer.UseVisualStyleBackColor = true;
            this._Bt_Restablecer.Click += new System.EventHandler(this._Bt_Restablecer_Click);
            // 
            // _Chk_Fecha
            // 
            this._Chk_Fecha.AutoSize = true;
            this._Chk_Fecha.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Chk_Fecha.Location = new System.Drawing.Point(488, 60);
            this._Chk_Fecha.Name = "_Chk_Fecha";
            this._Chk_Fecha.Size = new System.Drawing.Size(72, 16);
            this._Chk_Fecha.TabIndex = 97;
            this._Chk_Fecha.Text = "Por fecha";
            this._Chk_Fecha.UseVisualStyleBackColor = true;
            this._Chk_Fecha.CheckedChanged += new System.EventHandler(this._Chk_Fecha_CheckedChanged);
            // 
            // _Txt_Beneficiario
            // 
            this._Txt_Beneficiario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Beneficiario.Location = new System.Drawing.Point(15, 149);
            this._Txt_Beneficiario.Name = "_Txt_Beneficiario";
            this._Txt_Beneficiario.Size = new System.Drawing.Size(330, 21);
            this._Txt_Beneficiario.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 95;
            this.label5.Text = "Beneficiario:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 92;
            this.label3.Text = "Cuenta Bancaria:";
            // 
            // _Cmb_Cuenta
            // 
            this._Cmb_Cuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Cuenta.Enabled = false;
            this._Cmb_Cuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Cuenta.FormattingEnabled = true;
            this._Cmb_Cuenta.Location = new System.Drawing.Point(15, 64);
            this._Cmb_Cuenta.Name = "_Cmb_Cuenta";
            this._Cmb_Cuenta.Size = new System.Drawing.Size(330, 21);
            this._Cmb_Cuenta.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 91;
            this.label4.Text = "Banco:";
            // 
            // _Cmb_Banco
            // 
            this._Cmb_Banco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_Banco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_Banco.FormattingEnabled = true;
            this._Cmb_Banco.Location = new System.Drawing.Point(15, 24);
            this._Cmb_Banco.Name = "_Cmb_Banco";
            this._Cmb_Banco.Size = new System.Drawing.Size(330, 21);
            this._Cmb_Banco.TabIndex = 0;
            this._Cmb_Banco.SelectedIndexChanged += new System.EventHandler(this._Cmb_Banco_SelectedIndexChanged);
            this._Cmb_Banco.DropDown += new System.EventHandler(this._Cmb_Banco_DropDown);
            // 
            // _Bt_Consultar
            // 
            this._Bt_Consultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Consultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Consultar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Consultar.Image")));
            this._Bt_Consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Consultar.Location = new System.Drawing.Point(383, 126);
            this._Bt_Consultar.Name = "_Bt_Consultar";
            this._Bt_Consultar.Size = new System.Drawing.Size(120, 43);
            this._Bt_Consultar.TabIndex = 7;
            this._Bt_Consultar.Text = "Consultar";
            this._Bt_Consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Consultar.UseVisualStyleBackColor = true;
            this._Bt_Consultar.Click += new System.EventHandler(this._Bt_Consultar_Click);
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.ContextMenuStrip = this._Cntx_Menu;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(3, 182);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid.Size = new System.Drawing.Size(738, 198);
            this._Dg_Grid.TabIndex = 0;
            this._Dg_Grid.MouseLeave += new System.EventHandler(this._Dg_Grid_MouseLeave);
            this._Dg_Grid.MouseEnter += new System.EventHandler(this._Dg_Grid_MouseEnter);
            // 
            // _Cntx_Menu
            // 
            this._Cntx_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._CMen_OrdPago_Sel});
            this._Cntx_Menu.Name = "_CMen_OrdPago";
            this._Cntx_Menu.Size = new System.Drawing.Size(129, 26);
            this._Cntx_Menu.Opening += new System.ComponentModel.CancelEventHandler(this._Cntx_Menu_Opening);
            // 
            // _CMen_OrdPago_Sel
            // 
            this._CMen_OrdPago_Sel.Name = "_CMen_OrdPago_Sel";
            this._CMen_OrdPago_Sel.Size = new System.Drawing.Size(128, 22);
            this._CMen_OrdPago_Sel.Text = "Seleccionar";
            this._CMen_OrdPago_Sel.Click += new System.EventHandler(this._CMen_OrdPago_Sel_Click);
            // 
            // _Lbl_DgInfo
            // 
            this._Lbl_DgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo.Location = new System.Drawing.Point(3, 380);
            this._Lbl_DgInfo.Name = "_Lbl_DgInfo";
            this._Lbl_DgInfo.Size = new System.Drawing.Size(738, 11);
            this._Lbl_DgInfo.TabIndex = 93;
            this._Lbl_DgInfo.Text = "Use clic derecho";
            this._Lbl_DgInfo.Visible = false;
            // 
            // _Bt_Guardar
            // 
            this._Bt_Guardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Bt_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Guardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Guardar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this._Bt_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Guardar.Image")));
            this._Bt_Guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Guardar.Location = new System.Drawing.Point(639, 5);
            this._Bt_Guardar.Name = "_Bt_Guardar";
            this._Bt_Guardar.Size = new System.Drawing.Size(93, 24);
            this._Bt_Guardar.TabIndex = 99;
            this._Bt_Guardar.Text = "Agregar";
            this._Bt_Guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Guardar.UseVisualStyleBackColor = true;
            this._Bt_Guardar.Click += new System.EventHandler(this._Bt_Guardar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._Bt_Guardar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 391);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(738, 33);
            this.panel3.TabIndex = 101;
            // 
            // _Tb_Tab
            // 
            this._Tb_Tab.Controls.Add(this.tabPage1);
            this._Tb_Tab.Controls.Add(this.tabPage2);
            this._Tb_Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Tb_Tab.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Tb_Tab.Location = new System.Drawing.Point(0, 0);
            this._Tb_Tab.Name = "_Tb_Tab";
            this._Tb_Tab.SelectedIndex = 0;
            this._Tb_Tab.Size = new System.Drawing.Size(752, 453);
            this._Tb_Tab.TabIndex = 99;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._Dg_Grid);
            this.tabPage1.Controls.Add(this._Lbl_DgInfo);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(744, 427);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._Dg_Grid_2);
            this.tabPage2.Controls.Add(this._Lbl_DgInfo_2);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(744, 427);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Edición";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _Dg_Grid_2
            // 
            this._Dg_Grid_2.AllowUserToAddRows = false;
            this._Dg_Grid_2.AllowUserToDeleteRows = false;
            this._Dg_Grid_2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid_2.ContextMenuStrip = this._Cntx_Menu_2;
            this._Dg_Grid_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid_2.Location = new System.Drawing.Point(3, 3);
            this._Dg_Grid_2.Name = "_Dg_Grid_2";
            this._Dg_Grid_2.ReadOnly = true;
            this._Dg_Grid_2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this._Dg_Grid_2.Size = new System.Drawing.Size(738, 377);
            this._Dg_Grid_2.TabIndex = 102;
            this._Dg_Grid_2.MouseLeave += new System.EventHandler(this._Dg_Grid_2_MouseLeave);
            this._Dg_Grid_2.MouseEnter += new System.EventHandler(this._Dg_Grid_2_MouseEnter);
            // 
            // _Cntx_Menu_2
            // 
            this._Cntx_Menu_2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this._Cntx_Menu_2.Name = "_CMen_OrdPago";
            this._Cntx_Menu_2.Size = new System.Drawing.Size(129, 26);
            this._Cntx_Menu_2.Opening += new System.ComponentModel.CancelEventHandler(this._Cntx_Menu_2_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem1.Text = "Seleccionar";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // _Lbl_DgInfo_2
            // 
            this._Lbl_DgInfo_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgInfo_2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgInfo_2.Location = new System.Drawing.Point(3, 380);
            this._Lbl_DgInfo_2.Name = "_Lbl_DgInfo_2";
            this._Lbl_DgInfo_2.Size = new System.Drawing.Size(738, 11);
            this._Lbl_DgInfo_2.TabIndex = 103;
            this._Lbl_DgInfo_2.Text = "Use click derecho";
            this._Lbl_DgInfo_2.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._Bt_Quitar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 391);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(738, 33);
            this.panel2.TabIndex = 104;
            // 
            // _Bt_Quitar
            // 
            this._Bt_Quitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Bt_Quitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Quitar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Quitar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this._Bt_Quitar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Quitar.Image")));
            this._Bt_Quitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Quitar.Location = new System.Drawing.Point(639, 5);
            this._Bt_Quitar.Name = "_Bt_Quitar";
            this._Bt_Quitar.Size = new System.Drawing.Size(93, 24);
            this._Bt_Quitar.TabIndex = 99;
            this._Bt_Quitar.Text = "Quitar";
            this._Bt_Quitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Quitar.UseVisualStyleBackColor = true;
            this._Bt_Quitar.Click += new System.EventHandler(this._Bt_Quitar_Click);
            // 
            // _Pnl_Opcionnes
            // 
            this._Pnl_Opcionnes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._Pnl_Opcionnes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Opcionnes.Controls.Add(this._Bt_Cancelar);
            this._Pnl_Opcionnes.Controls.Add(this._Bt_Registrar);
            this._Pnl_Opcionnes.Controls.Add(this._Bt_ND);
            this._Pnl_Opcionnes.Controls.Add(this.label6);
            this._Pnl_Opcionnes.Location = new System.Drawing.Point(227, 151);
            this._Pnl_Opcionnes.Name = "_Pnl_Opcionnes";
            this._Pnl_Opcionnes.Size = new System.Drawing.Size(299, 148);
            this._Pnl_Opcionnes.TabIndex = 100;
            this._Pnl_Opcionnes.Visible = false;
            this._Pnl_Opcionnes.VisibleChanged += new System.EventHandler(this._Pnl_Opcionnes_VisibleChanged);
            // 
            // _Bt_Cancelar
            // 
            this._Bt_Cancelar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this._Bt_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Bt_Cancelar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Cancelar.Location = new System.Drawing.Point(189, 112);
            this._Bt_Cancelar.Name = "_Bt_Cancelar";
            this._Bt_Cancelar.Size = new System.Drawing.Size(92, 25);
            this._Bt_Cancelar.TabIndex = 72;
            this._Bt_Cancelar.Text = "CANCELAR..";
            this._Bt_Cancelar.UseVisualStyleBackColor = false;
            this._Bt_Cancelar.Click += new System.EventHandler(this._Bt_Cancelar_Click);
            // 
            // _Bt_Registrar
            // 
            this._Bt_Registrar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this._Bt_Registrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Registrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Bt_Registrar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Registrar.Location = new System.Drawing.Point(19, 70);
            this._Bt_Registrar.Name = "_Bt_Registrar";
            this._Bt_Registrar.Size = new System.Drawing.Size(262, 36);
            this._Bt_Registrar.TabIndex = 71;
            this._Bt_Registrar.Text = "CERRAR ORDEN DE PAGO Y REGISTRAR SOBRANTE O FALTANTE EN CAJA";
            this._Bt_Registrar.UseVisualStyleBackColor = false;
            this._Bt_Registrar.Click += new System.EventHandler(this._Bt_Registrar_Click);
            // 
            // _Bt_ND
            // 
            this._Bt_ND.BackColor = System.Drawing.SystemColors.ButtonFace;
            this._Bt_ND.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_ND.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Bt_ND.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_ND.Location = new System.Drawing.Point(19, 28);
            this._Bt_ND.Name = "_Bt_ND";
            this._Bt_ND.Size = new System.Drawing.Size(262, 36);
            this._Bt_ND.TabIndex = 70;
            this._Bt_ND.Text = "CERRAR ORDEN DE PAGO Y EMITIR NOTA DE DÉBITO AL PROVEEDOR";
            this._Bt_ND.UseVisualStyleBackColor = false;
            this._Bt_ND.Click += new System.EventHandler(this._Bt_ND_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Navy;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(297, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "¿QUÉ DESEAS HACER CON EL ANTICIPO?";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Pnl_Clave
            // 
            this._Pnl_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_Clave.Controls.Add(this._Bt_AceptarClave);
            this._Pnl_Clave.Controls.Add(this.label8);
            this._Pnl_Clave.Controls.Add(this._Txt_Clave);
            this._Pnl_Clave.Controls.Add(this._Bt_CancelarClave);
            this._Pnl_Clave.Controls.Add(this.label9);
            this._Pnl_Clave.Location = new System.Drawing.Point(532, 109);
            this._Pnl_Clave.Name = "_Pnl_Clave";
            this._Pnl_Clave.Size = new System.Drawing.Size(154, 86);
            this._Pnl_Clave.TabIndex = 101;
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 68;
            this.label8.Text = "Clave:";
            // 
            // _Txt_Clave
            // 
            this._Txt_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Clave.Location = new System.Drawing.Point(50, 31);
            this._Txt_Clave.Name = "_Txt_Clave";
            this._Txt_Clave.PasswordChar = '*';
            this._Txt_Clave.Size = new System.Drawing.Size(91, 20);
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
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Navy;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 18);
            this.label9.TabIndex = 0;
            this.label9.Text = "Introduzca Clave";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Ctrl_ConsultaMes1
            // 
            this._Ctrl_ConsultaMes1.Enabled = false;
            this._Ctrl_ConsultaMes1.Location = new System.Drawing.Point(351, 0);
            this._Ctrl_ConsultaMes1.Name = "_Ctrl_ConsultaMes1";
            this._Ctrl_ConsultaMes1.Size = new System.Drawing.Size(393, 59);
            this._Ctrl_ConsultaMes1.TabIndex = 5;
            // 
            // Frm_Anticipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 453);
            this.Controls.Add(this._Pnl_Clave);
            this.Controls.Add(this._Pnl_Opcionnes);
            this.Controls.Add(this._Tb_Tab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Anticipos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anticipos";
            this.Load += new System.EventHandler(this.Frm_Anticipos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid)).EndInit();
            this._Cntx_Menu.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_2)).EndInit();
            this._Cntx_Menu_2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this._Pnl_Opcionnes.ResumeLayout(false);
            this._Pnl_Clave.ResumeLayout(false);
            this._Pnl_Clave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _Bt_Consultar;
        private T3.Controles._Ctrl_ConsultaMes _Ctrl_ConsultaMes1;
        private System.Windows.Forms.DataGridView _Dg_Grid;
        private System.Windows.Forms.Label _Lbl_DgInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _Cmb_Cuenta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox _Cmb_Banco;
        public System.Windows.Forms.TextBox _Txt_Beneficiario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox _Chk_Fecha;
        private System.Windows.Forms.Button _Bt_Restablecer;
        public System.Windows.Forms.TextBox _Txt_ChequeTransf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip _Cntx_Menu;
        private System.Windows.Forms.ToolStripMenuItem _CMen_OrdPago_Sel;
        private System.Windows.Forms.Button _Bt_Guardar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView _Dg_Grid_2;
        private System.Windows.Forms.Label _Lbl_DgInfo_2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button _Bt_Quitar;
        private System.Windows.Forms.ContextMenuStrip _Cntx_Menu_2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Panel _Pnl_Opcionnes;
        private System.Windows.Forms.Button _Bt_Cancelar;
        private System.Windows.Forms.Button _Bt_Registrar;
        private System.Windows.Forms.Button _Bt_ND;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel _Pnl_Clave;
        private System.Windows.Forms.Button _Bt_AceptarClave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _Txt_Clave;
        private System.Windows.Forms.Button _Bt_CancelarClave;
        private System.Windows.Forms.Label label9;
    }
}