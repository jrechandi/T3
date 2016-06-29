namespace T3
{
    partial class Frm_Tabs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Tabs));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this._lis_1 = new System.Windows.Forms.ListBox();
            this._lis_2 = new System.Windows.Forms.ListBox();
            this._Bt_Rem = new System.Windows.Forms.Button();
            this._Bt_Add = new System.Windows.Forms.Button();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this._Bt_Edit = new System.Windows.Forms.Button();
            this._Bt_TabDel = new System.Windows.Forms.Button();
            this._Bt_TabNuevo = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this._Pnl_TabDatos = new System.Windows.Forms.Panel();
            this._Chk_CodManual = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Txt_TabId = new System.Windows.Forms.TextBox();
            this._Bt_TabSave = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this._Txt_TabName = new System.Windows.Forms.TextBox();
            this._Bt_TabCancel = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this._Pnl_TabDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(228, 20);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // _lis_1
            // 
            this._lis_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lis_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lis_1.FormattingEnabled = true;
            this._lis_1.ItemHeight = 12;
            this._lis_1.Location = new System.Drawing.Point(0, 32);
            this._lis_1.Name = "_lis_1";
            this._lis_1.Size = new System.Drawing.Size(299, 278);
            this._lis_1.TabIndex = 7;
            this._lis_1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // _lis_2
            // 
            this._lis_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lis_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lis_2.FormattingEnabled = true;
            this._lis_2.ItemHeight = 12;
            this._lis_2.Location = new System.Drawing.Point(345, 28);
            this._lis_2.Name = "_lis_2";
            this._lis_2.Size = new System.Drawing.Size(299, 290);
            this._lis_2.TabIndex = 8;
            // 
            // _Bt_Rem
            // 
            this._Bt_Rem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Rem.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Rem.Image")));
            this._Bt_Rem.Location = new System.Drawing.Point(8, 134);
            this._Bt_Rem.Name = "_Bt_Rem";
            this._Bt_Rem.Size = new System.Drawing.Size(30, 22);
            this._Bt_Rem.TabIndex = 58;
            this._Bt_Rem.Click += new System.EventHandler(this._Bt_Rem_Click);
            // 
            // _Bt_Add
            // 
            this._Bt_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Add.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Add.Image")));
            this._Bt_Add.Location = new System.Drawing.Point(8, 106);
            this._Bt_Add.Name = "_Bt_Add";
            this._Bt_Add.Size = new System.Drawing.Size(30, 22);
            this._Bt_Add.TabIndex = 57;
            this._Bt_Add.Click += new System.EventHandler(this._Bt_Add_Click);
            // 
            // _Er_Error
            // 
            this._Er_Error.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this._lis_1);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 321);
            this.panel1.TabIndex = 59;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this._Bt_Add);
            this.panel5.Controls.Add(this._Bt_Rem);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(299, 32);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(44, 287);
            this.panel5.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this._Bt_Edit);
            this.panel4.Controls.Add(this._Bt_TabDel);
            this.panel4.Controls.Add(this._Bt_TabNuevo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(343, 32);
            this.panel4.TabIndex = 2;
            // 
            // _Bt_Edit
            // 
            this._Bt_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Edit.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Edit.Image")));
            this._Bt_Edit.Location = new System.Drawing.Point(37, 3);
            this._Bt_Edit.Name = "_Bt_Edit";
            this._Bt_Edit.Size = new System.Drawing.Size(27, 24);
            this._Bt_Edit.TabIndex = 2;
            this._Bt_Edit.UseVisualStyleBackColor = true;
            this._Bt_Edit.Click += new System.EventHandler(this._Bt_Edit_Click);
            // 
            // _Bt_TabDel
            // 
            this._Bt_TabDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_TabDel.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_TabDel.Image")));
            this._Bt_TabDel.Location = new System.Drawing.Point(70, 3);
            this._Bt_TabDel.Name = "_Bt_TabDel";
            this._Bt_TabDel.Size = new System.Drawing.Size(27, 24);
            this._Bt_TabDel.TabIndex = 1;
            this._Bt_TabDel.UseVisualStyleBackColor = true;
            this._Bt_TabDel.Click += new System.EventHandler(this._Bt_TabDel_Click);
            // 
            // _Bt_TabNuevo
            // 
            this._Bt_TabNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_TabNuevo.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_TabNuevo.Image")));
            this._Bt_TabNuevo.Location = new System.Drawing.Point(4, 3);
            this._Bt_TabNuevo.Name = "_Bt_TabNuevo";
            this._Bt_TabNuevo.Size = new System.Drawing.Size(27, 24);
            this._Bt_TabNuevo.TabIndex = 0;
            this._Bt_TabNuevo.UseVisualStyleBackColor = true;
            this._Bt_TabNuevo.Click += new System.EventHandler(this._Bt_TabNuevo_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(345, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(299, 28);
            this.panel3.TabIndex = 60;
            // 
            // _Pnl_TabDatos
            // 
            this._Pnl_TabDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Pnl_TabDatos.Controls.Add(this._Chk_CodManual);
            this._Pnl_TabDatos.Controls.Add(this.label1);
            this._Pnl_TabDatos.Controls.Add(this._Txt_TabId);
            this._Pnl_TabDatos.Controls.Add(this._Bt_TabSave);
            this._Pnl_TabDatos.Controls.Add(this.label13);
            this._Pnl_TabDatos.Controls.Add(this._Txt_TabName);
            this._Pnl_TabDatos.Controls.Add(this._Bt_TabCancel);
            this._Pnl_TabDatos.Controls.Add(this.label16);
            this._Pnl_TabDatos.Location = new System.Drawing.Point(126, 94);
            this._Pnl_TabDatos.Name = "_Pnl_TabDatos";
            this._Pnl_TabDatos.Size = new System.Drawing.Size(405, 130);
            this._Pnl_TabDatos.TabIndex = 77;
            this._Pnl_TabDatos.Visible = false;
            this._Pnl_TabDatos.VisibleChanged += new System.EventHandler(this._Pnl_TabDatos_VisibleChanged);
            // 
            // _Chk_CodManual
            // 
            this._Chk_CodManual.AutoSize = true;
            this._Chk_CodManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Chk_CodManual.Location = new System.Drawing.Point(173, 34);
            this._Chk_CodManual.Name = "_Chk_CodManual";
            this._Chk_CodManual.Size = new System.Drawing.Size(83, 16);
            this._Chk_CodManual.TabIndex = 73;
            this._Chk_CodManual.Text = "Cod. Manual";
            this._Chk_CodManual.UseVisualStyleBackColor = true;
            this._Chk_CodManual.CheckedChanged += new System.EventHandler(this._Chk_CodManual_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 72;
            this.label1.Text = "Código:";
            // 
            // _Txt_TabId
            // 
            this._Txt_TabId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_TabId.Location = new System.Drawing.Point(83, 33);
            this._Txt_TabId.Name = "_Txt_TabId";
            this._Txt_TabId.ReadOnly = true;
            this._Txt_TabId.Size = new System.Drawing.Size(66, 18);
            this._Txt_TabId.TabIndex = 71;
            // 
            // _Bt_TabSave
            // 
            this._Bt_TabSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_TabSave.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_TabSave.Location = new System.Drawing.Point(134, 91);
            this._Bt_TabSave.Name = "_Bt_TabSave";
            this._Bt_TabSave.Size = new System.Drawing.Size(66, 20);
            this._Bt_TabSave.TabIndex = 70;
            this._Bt_TabSave.Text = "Guardar";
            this._Bt_TabSave.UseVisualStyleBackColor = true;
            this._Bt_TabSave.Click += new System.EventHandler(this._Bt_TabSave_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 12);
            this.label13.TabIndex = 68;
            this.label13.Text = "Descripción:";
            // 
            // _Txt_TabName
            // 
            this._Txt_TabName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_TabName.Location = new System.Drawing.Point(83, 57);
            this._Txt_TabName.MaxLength = 100;
            this._Txt_TabName.Name = "_Txt_TabName";
            this._Txt_TabName.Size = new System.Drawing.Size(305, 18);
            this._Txt_TabName.TabIndex = 2;
            // 
            // _Bt_TabCancel
            // 
            this._Bt_TabCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_TabCancel.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_TabCancel.Location = new System.Drawing.Point(206, 91);
            this._Bt_TabCancel.Name = "_Bt_TabCancel";
            this._Bt_TabCancel.Size = new System.Drawing.Size(63, 20);
            this._Bt_TabCancel.TabIndex = 1;
            this._Bt_TabCancel.Text = "Cancelar";
            this._Bt_TabCancel.UseVisualStyleBackColor = true;
            this._Bt_TabCancel.Click += new System.EventHandler(this._Bt_TabCancel_Click);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Navy;
            this.label16.Dock = System.Windows.Forms.DockStyle.Top;
            this.label16.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(403, 19);
            this.label16.TabIndex = 0;
            this.label16.Text = "Agregando Notificación";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_Tabs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 321);
            this.Controls.Add(this._Pnl_TabDatos);
            this.Controls.Add(this._lis_2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Tabs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración de Notificaciones";
            this.Load += new System.EventHandler(this.Frm_Tabs_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this._Pnl_TabDatos.ResumeLayout(false);
            this._Pnl_TabDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox _lis_1;
        private System.Windows.Forms.ListBox _lis_2;
        private System.Windows.Forms.Button _Bt_Rem;
        private System.Windows.Forms.Button _Bt_Add;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _Bt_TabNuevo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button _Bt_TabDel;
        private System.Windows.Forms.Panel _Pnl_TabDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _Txt_TabId;
        private System.Windows.Forms.Button _Bt_TabSave;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox _Txt_TabName;
        private System.Windows.Forms.Button _Bt_TabCancel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox _Chk_CodManual;
        private System.Windows.Forms.Button _Bt_Edit;
    }
}