namespace T3
{
    partial class Frm_RC_Verificacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this._Layout = new System.Windows.Forms.TableLayoutPanel();
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this._Tb_Tab_Descargadas = new System.Windows.Forms.TabPage();
            this._Pnl_Descargadas = new System.Windows.Forms.Panel();
            this._Dg_Grid_Descargadas = new System.Windows.Forms.DataGridView();
            this._Tb_Tab_Ingresadas = new System.Windows.Forms.TabPage();
            this._Pnl_Ingresadas = new System.Windows.Forms.Panel();
            this._Dg_Grid_Ingresadas = new System.Windows.Forms.DataGridView();
            this._Btn_Actualizar = new System.Windows.Forms.Button();
            this._Layout.SuspendLayout();
            this._Tb_Tab.SuspendLayout();
            this._Tb_Tab_Descargadas.SuspendLayout();
            this._Pnl_Descargadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_Descargadas)).BeginInit();
            this._Tb_Tab_Ingresadas.SuspendLayout();
            this._Pnl_Ingresadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_Ingresadas)).BeginInit();
            this.SuspendLayout();
            // 
            // _Layout
            // 
            this._Layout.ColumnCount = 1;
            this._Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._Layout.Controls.Add(this._Tb_Tab, 0, 1);
            this._Layout.Controls.Add(this._Btn_Actualizar, 0, 0);
            this._Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Layout.Location = new System.Drawing.Point(0, 0);
            this._Layout.Name = "_Layout";
            this._Layout.RowCount = 2;
            this._Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this._Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._Layout.Size = new System.Drawing.Size(704, 339);
            this._Layout.TabIndex = 1;
            // 
            // _Tb_Tab
            // 
            this._Tb_Tab.Controls.Add(this._Tb_Tab_Descargadas);
            this._Tb_Tab.Controls.Add(this._Tb_Tab_Ingresadas);
            this._Tb_Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Tb_Tab.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Tb_Tab.Location = new System.Drawing.Point(3, 32);
            this._Tb_Tab.Name = "_Tb_Tab";
            this._Tb_Tab.SelectedIndex = 0;
            this._Tb_Tab.Size = new System.Drawing.Size(698, 304);
            this._Tb_Tab.TabIndex = 1;
            // 
            // _Tb_Tab_Descargadas
            // 
            this._Tb_Tab_Descargadas.Controls.Add(this._Pnl_Descargadas);
            this._Tb_Tab_Descargadas.Location = new System.Drawing.Point(4, 21);
            this._Tb_Tab_Descargadas.Name = "_Tb_Tab_Descargadas";
            this._Tb_Tab_Descargadas.Padding = new System.Windows.Forms.Padding(3);
            this._Tb_Tab_Descargadas.Size = new System.Drawing.Size(690, 279);
            this._Tb_Tab_Descargadas.TabIndex = 0;
            this._Tb_Tab_Descargadas.Text = "Descargadas";
            this._Tb_Tab_Descargadas.UseVisualStyleBackColor = true;
            // 
            // _Pnl_Descargadas
            // 
            this._Pnl_Descargadas.Controls.Add(this._Dg_Grid_Descargadas);
            this._Pnl_Descargadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Pnl_Descargadas.Location = new System.Drawing.Point(3, 3);
            this._Pnl_Descargadas.Name = "_Pnl_Descargadas";
            this._Pnl_Descargadas.Size = new System.Drawing.Size(684, 273);
            this._Pnl_Descargadas.TabIndex = 0;
            // 
            // _Dg_Grid_Descargadas
            // 
            this._Dg_Grid_Descargadas.AllowUserToAddRows = false;
            this._Dg_Grid_Descargadas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Dg_Grid_Descargadas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._Dg_Grid_Descargadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid_Descargadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid_Descargadas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this._Dg_Grid_Descargadas.Location = new System.Drawing.Point(0, 0);
            this._Dg_Grid_Descargadas.Name = "_Dg_Grid_Descargadas";
            this._Dg_Grid_Descargadas.Size = new System.Drawing.Size(684, 273);
            this._Dg_Grid_Descargadas.TabIndex = 0;
            this._Dg_Grid_Descargadas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_Descargadas_CellClick);
            // 
            // _Tb_Tab_Ingresadas
            // 
            this._Tb_Tab_Ingresadas.Controls.Add(this._Pnl_Ingresadas);
            this._Tb_Tab_Ingresadas.Location = new System.Drawing.Point(4, 21);
            this._Tb_Tab_Ingresadas.Name = "_Tb_Tab_Ingresadas";
            this._Tb_Tab_Ingresadas.Padding = new System.Windows.Forms.Padding(3);
            this._Tb_Tab_Ingresadas.Size = new System.Drawing.Size(690, 279);
            this._Tb_Tab_Ingresadas.TabIndex = 1;
            this._Tb_Tab_Ingresadas.Text = "Ingresadas";
            this._Tb_Tab_Ingresadas.UseVisualStyleBackColor = true;
            // 
            // _Pnl_Ingresadas
            // 
            this._Pnl_Ingresadas.Controls.Add(this._Dg_Grid_Ingresadas);
            this._Pnl_Ingresadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Pnl_Ingresadas.Location = new System.Drawing.Point(3, 3);
            this._Pnl_Ingresadas.Name = "_Pnl_Ingresadas";
            this._Pnl_Ingresadas.Size = new System.Drawing.Size(684, 273);
            this._Pnl_Ingresadas.TabIndex = 0;
            // 
            // _Dg_Grid_Ingresadas
            // 
            this._Dg_Grid_Ingresadas.AllowUserToAddRows = false;
            this._Dg_Grid_Ingresadas.AllowUserToDeleteRows = false;
            this._Dg_Grid_Ingresadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Dg_Grid_Ingresadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Dg_Grid_Ingresadas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this._Dg_Grid_Ingresadas.Location = new System.Drawing.Point(0, 0);
            this._Dg_Grid_Ingresadas.Name = "_Dg_Grid_Ingresadas";
            this._Dg_Grid_Ingresadas.Size = new System.Drawing.Size(684, 273);
            this._Dg_Grid_Ingresadas.TabIndex = 0;
            this._Dg_Grid_Ingresadas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._Dg_Grid_Ingresadas_CellClick);
            // 
            // _Btn_Actualizar
            // 
            this._Btn_Actualizar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Btn_Actualizar.Image = global::T3.Properties.Resources.arrow_circle_135;
            this._Btn_Actualizar.Location = new System.Drawing.Point(3, 3);
            this._Btn_Actualizar.Name = "_Btn_Actualizar";
            this._Btn_Actualizar.Size = new System.Drawing.Size(146, 23);
            this._Btn_Actualizar.TabIndex = 2;
            this._Btn_Actualizar.Text = "Actualizar";
            this._Btn_Actualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._Btn_Actualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._Btn_Actualizar.UseVisualStyleBackColor = true;
            this._Btn_Actualizar.Click += new System.EventHandler(this._Btn_Actualizar_Click);
            // 
            // Frm_RC_Verificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 339);
            this.Controls.Add(this._Layout);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Frm_RC_Verificacion";
            this.Text = "R.C. por Aprobar";
            this.Load += new System.EventHandler(this.Frm_RC_Verificacion_Load);
            this._Layout.ResumeLayout(false);
            this._Tb_Tab.ResumeLayout(false);
            this._Tb_Tab_Descargadas.ResumeLayout(false);
            this._Pnl_Descargadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_Descargadas)).EndInit();
            this._Tb_Tab_Ingresadas.ResumeLayout(false);
            this._Pnl_Ingresadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Dg_Grid_Ingresadas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _Layout;
        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage _Tb_Tab_Descargadas;
        private System.Windows.Forms.Panel _Pnl_Descargadas;
        private System.Windows.Forms.DataGridView _Dg_Grid_Descargadas;
        private System.Windows.Forms.TabPage _Tb_Tab_Ingresadas;
        private System.Windows.Forms.Panel _Pnl_Ingresadas;
        private System.Windows.Forms.DataGridView _Dg_Grid_Ingresadas;
        private System.Windows.Forms.Button _Btn_Actualizar;

    }
}