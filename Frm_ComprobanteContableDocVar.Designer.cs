namespace T3
{
    partial class Frm_ComprobanteContableDocVar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ComprobanteContableDocVar));
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._Dg_Grid = new System.Windows.Forms.DataGridView();
            this._Lbl_DgCargaInfo = new System.Windows.Forms.Label();
            this._Bt_Nuevo = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._Dtp_FechaDoc = new System.Windows.Forms.DateTimePicker();
            this._Bt_BuscarEntidad = new System.Windows.Forms.Button();
            this._Chk_GenSistema = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._Txt_Monto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._Txt_Entidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._Cmb_TipoEntidad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._Txt_Documento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Cmb_TipoDoc = new System.Windows.Forms.ComboBox();
            this._Bt_Cancelar = new System.Windows.Forms.Button();
            this._Bt_Aceptar = new System.Windows.Forms.Button();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Ctrl_Busqueda1 = new T3.Controles._Ctrl_Busqueda();
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
            this._Tb_Tab.Size = new System.Drawing.Size(625, 333);
            this._Tb_Tab.TabIndex = 1;
            this._Tb_Tab.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this._Tb_Tab_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this._Dg_Grid);
            this.tabPage1.Controls.Add(this._Lbl_DgCargaInfo);
            this.tabPage1.Controls.Add(this._Bt_Nuevo);
            this.tabPage1.Controls.Add(this._Ctrl_Busqueda1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(617, 307);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _Dg_Grid
            // 
            this._Dg_Grid.AllowUserToAddRows = false;
            this._Dg_Grid.AllowUserToDeleteRows = false;
            this._Dg_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid.Location = new System.Drawing.Point(3, 47);
            this._Dg_Grid.Name = "_Dg_Grid";
            this._Dg_Grid.ReadOnly = true;
            this._Dg_Grid.Size = new System.Drawing.Size(611, 245);
            this._Dg_Grid.TabIndex = 17;
            this._Dg_Grid.MouseLeave += new System.EventHandler(this._Dg_Grid_MouseLeave);
            this._Dg_Grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._Dg_Grid_RowHeaderMouseDoubleClick);
            this._Dg_Grid.MouseEnter += new System.EventHandler(this._Dg_Grid_MouseEnter);
            // 
            // _Lbl_DgCargaInfo
            // 
            this._Lbl_DgCargaInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._Lbl_DgCargaInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Lbl_DgCargaInfo.Location = new System.Drawing.Point(3, 292);
            this._Lbl_DgCargaInfo.Name = "_Lbl_DgCargaInfo";
            this._Lbl_DgCargaInfo.Size = new System.Drawing.Size(611, 12);
            this._Lbl_DgCargaInfo.TabIndex = 28;
            this._Lbl_DgCargaInfo.Text = "Use doble click";
            this._Lbl_DgCargaInfo.Visible = false;
            // 
            // _Bt_Nuevo
            // 
            this._Bt_Nuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Nuevo.FlatAppearance.BorderSize = 0;
            this._Bt_Nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Bt_Nuevo.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Nuevo.Image")));
            this._Bt_Nuevo.Location = new System.Drawing.Point(33, 3);
            this._Bt_Nuevo.Name = "_Bt_Nuevo";
            this._Bt_Nuevo.Size = new System.Drawing.Size(27, 25);
            this._Bt_Nuevo.TabIndex = 2;
            this._Bt_Nuevo.UseVisualStyleBackColor = true;
            this._Bt_Nuevo.Click += new System.EventHandler(this._Bt_Nuevo_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._Dtp_FechaDoc);
            this.tabPage2.Controls.Add(this._Bt_BuscarEntidad);
            this.tabPage2.Controls.Add(this._Chk_GenSistema);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this._Txt_Monto);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this._Txt_Entidad);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this._Cmb_TipoEntidad);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this._Txt_Documento);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this._Cmb_TipoDoc);
            this.tabPage2.Controls.Add(this._Bt_Cancelar);
            this.tabPage2.Controls.Add(this._Bt_Aceptar);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(617, 307);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _Dtp_FechaDoc
            // 
            this._Dtp_FechaDoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._Dtp_FechaDoc.Location = new System.Drawing.Point(129, 233);
            this._Dtp_FechaDoc.Name = "_Dtp_FechaDoc";
            this._Dtp_FechaDoc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Dtp_FechaDoc.Size = new System.Drawing.Size(139, 20);
            this._Dtp_FechaDoc.TabIndex = 7;
            // 
            // _Bt_BuscarEntidad
            // 
            this._Bt_BuscarEntidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_BuscarEntidad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_BuscarEntidad.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_BuscarEntidad.Image")));
            this._Bt_BuscarEntidad.Location = new System.Drawing.Point(533, 152);
            this._Bt_BuscarEntidad.Name = "_Bt_BuscarEntidad";
            this._Bt_BuscarEntidad.Size = new System.Drawing.Size(25, 20);
            this._Bt_BuscarEntidad.TabIndex = 5;
            this._Bt_BuscarEntidad.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this._Bt_BuscarEntidad.UseVisualStyleBackColor = true;
            this._Bt_BuscarEntidad.Click += new System.EventHandler(this._Bt_BuscarEntidad_Click);
            // 
            // _Chk_GenSistema
            // 
            this._Chk_GenSistema.AutoSize = true;
            this._Chk_GenSistema.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold);
            this._Chk_GenSistema.Location = new System.Drawing.Point(342, 73);
            this._Chk_GenSistema.Name = "_Chk_GenSistema";
            this._Chk_GenSistema.Size = new System.Drawing.Size(155, 16);
            this._Chk_GenSistema.TabIndex = 2;
            this._Chk_GenSistema.Text = "Generar automáticamente";
            this._Chk_GenSistema.UseVisualStyleBackColor = true;
            this._Chk_GenSistema.CheckedChanged += new System.EventHandler(this._Chk_GenSistema_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 12);
            this.label6.TabIndex = 163;
            this.label6.Text = "Fecha del documento:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 12);
            this.label5.TabIndex = 161;
            this.label5.Text = "Monto del documento:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _Txt_Monto
            // 
            this._Txt_Monto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Monto.Location = new System.Drawing.Point(129, 192);
            this._Txt_Monto.MaxLength = 20;
            this._Txt_Monto.Name = "_Txt_Monto";
            this._Txt_Monto.Size = new System.Drawing.Size(139, 20);
            this._Txt_Monto.TabIndex = 6;
            this._Txt_Monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Txt_Monto.TextChanged += new System.EventHandler(this._Txt_Monto_TextChanged);
            this._Txt_Monto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Monto_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(76, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 159;
            this.label4.Text = "Entidad:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _Txt_Entidad
            // 
            this._Txt_Entidad.BackColor = System.Drawing.Color.White;
            this._Txt_Entidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Entidad.Location = new System.Drawing.Point(129, 152);
            this._Txt_Entidad.MaxLength = 20;
            this._Txt_Entidad.Name = "_Txt_Entidad";
            this._Txt_Entidad.ReadOnly = true;
            this._Txt_Entidad.Size = new System.Drawing.Size(398, 20);
            this._Txt_Entidad.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 12);
            this.label3.TabIndex = 157;
            this.label3.Text = "Tipo de entidad:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _Cmb_TipoEntidad
            // 
            this._Cmb_TipoEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_TipoEntidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_TipoEntidad.FormattingEnabled = true;
            this._Cmb_TipoEntidad.Location = new System.Drawing.Point(129, 111);
            this._Cmb_TipoEntidad.Name = "_Cmb_TipoEntidad";
            this._Cmb_TipoEntidad.Size = new System.Drawing.Size(209, 21);
            this._Cmb_TipoEntidad.TabIndex = 3;
            this._Cmb_TipoEntidad.SelectedIndexChanged += new System.EventHandler(this._Cmb_TipoEntidad_SelectedIndexChanged);
            this._Cmb_TipoEntidad.DropDown += new System.EventHandler(this._Cmb_TipoEntidad_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 155;
            this.label2.Text = "Documento:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _Txt_Documento
            // 
            this._Txt_Documento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_Documento.Location = new System.Drawing.Point(129, 72);
            this._Txt_Documento.MaxLength = 20;
            this._Txt_Documento.Name = "_Txt_Documento";
            this._Txt_Documento.Size = new System.Drawing.Size(209, 20);
            this._Txt_Documento.TabIndex = 1;
            this._Txt_Documento.TextChanged += new System.EventHandler(this._Txt_Documento_TextChanged);
            this._Txt_Documento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_Documento_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 12);
            this.label1.TabIndex = 153;
            this.label1.Text = "Tipo de documento:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _Cmb_TipoDoc
            // 
            this._Cmb_TipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cmb_TipoDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cmb_TipoDoc.FormattingEnabled = true;
            this._Cmb_TipoDoc.Location = new System.Drawing.Point(129, 31);
            this._Cmb_TipoDoc.Name = "_Cmb_TipoDoc";
            this._Cmb_TipoDoc.Size = new System.Drawing.Size(209, 21);
            this._Cmb_TipoDoc.TabIndex = 0;
            this._Cmb_TipoDoc.DropDown += new System.EventHandler(this._Cmb_TipoDoc_DropDown);
            // 
            // _Bt_Cancelar
            // 
            this._Bt_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Bt_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Cancelar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Cancelar.Image")));
            this._Bt_Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Cancelar.Location = new System.Drawing.Point(363, 213);
            this._Bt_Cancelar.Name = "_Bt_Cancelar";
            this._Bt_Cancelar.Size = new System.Drawing.Size(95, 40);
            this._Bt_Cancelar.TabIndex = 8;
            this._Bt_Cancelar.Text = "Cancelar";
            this._Bt_Cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Cancelar.UseVisualStyleBackColor = true;
            this._Bt_Cancelar.Click += new System.EventHandler(this._Bt_Cancelar_Click);
            // 
            // _Bt_Aceptar
            // 
            this._Bt_Aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Bt_Aceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this._Bt_Aceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this._Bt_Aceptar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Bt_Aceptar.Image = ((System.Drawing.Image)(resources.GetObject("_Bt_Aceptar.Image")));
            this._Bt_Aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._Bt_Aceptar.Location = new System.Drawing.Point(464, 213);
            this._Bt_Aceptar.Name = "_Bt_Aceptar";
            this._Bt_Aceptar.Size = new System.Drawing.Size(94, 40);
            this._Bt_Aceptar.TabIndex = 9;
            this._Bt_Aceptar.Text = "Aceptar";
            this._Bt_Aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Bt_Aceptar.UseVisualStyleBackColor = true;
            this._Bt_Aceptar.Click += new System.EventHandler(this._Bt_Aceptar_Click);
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
            this._Ctrl_Busqueda1.Size = new System.Drawing.Size(611, 44);
            this._Ctrl_Busqueda1.TabIndex = 18;
            // 
            // Frm_ComprobanteContableDocVar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 333);
            this.Controls.Add(this._Tb_Tab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ComprobanteContableDocVar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Documentos varios";
            this.Load += new System.EventHandler(this.Frm_ComprobanteContableDocVar_Load);
            this.Shown += new System.EventHandler(this.Frm_ComprobanteContableDocVar_Shown);
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
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button _Bt_Cancelar;
        private System.Windows.Forms.Button _Bt_Aceptar;
        private System.Windows.Forms.TextBox _Txt_Documento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _Cmb_TipoDoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _Txt_Entidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _Cmb_TipoEntidad;
        private System.Windows.Forms.CheckBox _Chk_GenSistema;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _Txt_Monto;
        private System.Windows.Forms.Button _Bt_BuscarEntidad;
        private System.Windows.Forms.DateTimePicker _Dtp_FechaDoc;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        public T3.Controles._Ctrl_Busqueda _Ctrl_Busqueda1;
        private System.Windows.Forms.Button _Bt_Nuevo;
        private System.Windows.Forms.Label _Lbl_DgCargaInfo;
    }
}