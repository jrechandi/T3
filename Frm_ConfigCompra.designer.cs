namespace T3
{
    partial class Frm_ConfigCompra
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
            this._Cb_TpoDocNE = new System.Windows.Forms.ComboBox();
            this._Cb_TpoDocRecProv = new System.Windows.Forms.ComboBox();
            this._Cb_TpoDocOC = new System.Windows.Forms.ComboBox();
            this._Cb_TpoDocFactura = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._Cb_TpoNotRecDevM = new System.Windows.Forms.ComboBox();
            this._Cb_TpoNotRecDevB = new System.Windows.Forms.ComboBox();
            this._Cb_TpoNotCpr = new System.Windows.Forms.ComboBox();
            this._Cb_TpoNotRecProv = new System.Windows.Forms.ComboBox();
            this._Txt_MaxEfectOC = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this._Er_Error = new System.Windows.Forms.ErrorProvider(this.components);
            this._Tb_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._Cb_TpoDocNRDev = new System.Windows.Forms.ComboBox();
            this._Cb_TpoDocNRCpr = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._Cb_MotivoDifPrecio = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this._Cb_MotivoSobRec = new System.Windows.Forms.ComboBox();
            this._Cb_MotivoFaltRec = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this._Cb_Imp = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).BeginInit();
            this._Tb_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _Cb_TpoDocNE
            // 
            this._Cb_TpoDocNE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoDocNE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoDocNE.FormattingEnabled = true;
            this._Cb_TpoDocNE.Location = new System.Drawing.Point(20, 146);
            this._Cb_TpoDocNE.Name = "_Cb_TpoDocNE";
            this._Cb_TpoDocNE.Size = new System.Drawing.Size(266, 20);
            this._Cb_TpoDocNE.TabIndex = 7;
            this._Cb_TpoDocNE.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoDocNE_SelectedIndexChanged);
            this._Cb_TpoDocNE.DropDown += new System.EventHandler(this._Cb_TpoDocNE_DropDown);
            // 
            // _Cb_TpoDocRecProv
            // 
            this._Cb_TpoDocRecProv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoDocRecProv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoDocRecProv.FormattingEnabled = true;
            this._Cb_TpoDocRecProv.Location = new System.Drawing.Point(20, 108);
            this._Cb_TpoDocRecProv.Name = "_Cb_TpoDocRecProv";
            this._Cb_TpoDocRecProv.Size = new System.Drawing.Size(266, 20);
            this._Cb_TpoDocRecProv.TabIndex = 5;
            this._Cb_TpoDocRecProv.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoDocRecProv_SelectedIndexChanged);
            this._Cb_TpoDocRecProv.DropDown += new System.EventHandler(this._Cb_TpoDocRecProv_DropDown);
            // 
            // _Cb_TpoDocOC
            // 
            this._Cb_TpoDocOC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoDocOC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoDocOC.FormattingEnabled = true;
            this._Cb_TpoDocOC.Location = new System.Drawing.Point(20, 70);
            this._Cb_TpoDocOC.Name = "_Cb_TpoDocOC";
            this._Cb_TpoDocOC.Size = new System.Drawing.Size(266, 20);
            this._Cb_TpoDocOC.TabIndex = 3;
            this._Cb_TpoDocOC.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoDocOC_SelectedIndexChanged);
            this._Cb_TpoDocOC.DropDown += new System.EventHandler(this._Cb_TpoDocOC_DropDown);
            // 
            // _Cb_TpoDocFactura
            // 
            this._Cb_TpoDocFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoDocFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoDocFactura.FormattingEnabled = true;
            this._Cb_TpoDocFactura.Location = new System.Drawing.Point(20, 32);
            this._Cb_TpoDocFactura.Name = "_Cb_TpoDocFactura";
            this._Cb_TpoDocFactura.Size = new System.Drawing.Size(266, 20);
            this._Cb_TpoDocFactura.TabIndex = 1;
            this._Cb_TpoDocFactura.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoDocFactura_SelectedIndexChanged);
            this._Cb_TpoDocFactura.DropDown += new System.EventHandler(this._Cb_TpoDocFactura_DropDown);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(18, 131);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(151, 12);
            this.label21.TabIndex = 6;
            this.label21.Text = "NE por devolución en compra:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "Recepción proveedores:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "OC (orden de compra):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Factura:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(17, 89);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(211, 12);
            this.label24.TabIndex = 4;
            this.label24.Text = "Tipo de NR por Devolución en mal estado:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(17, 51);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(217, 12);
            this.label23.TabIndex = 2;
            this.label23.Text = "Tipo de NR por Devolución en buen estado:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "Tipo de NE por compra:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tipo de NR por Recepción de proveedores";
            // 
            // _Cb_TpoNotRecDevM
            // 
            this._Cb_TpoNotRecDevM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoNotRecDevM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoNotRecDevM.FormattingEnabled = true;
            this._Cb_TpoNotRecDevM.Location = new System.Drawing.Point(19, 104);
            this._Cb_TpoNotRecDevM.Name = "_Cb_TpoNotRecDevM";
            this._Cb_TpoNotRecDevM.Size = new System.Drawing.Size(207, 20);
            this._Cb_TpoNotRecDevM.TabIndex = 5;
            this._Cb_TpoNotRecDevM.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoNotRecDevM_SelectedIndexChanged);
            // 
            // _Cb_TpoNotRecDevB
            // 
            this._Cb_TpoNotRecDevB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoNotRecDevB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoNotRecDevB.FormattingEnabled = true;
            this._Cb_TpoNotRecDevB.Location = new System.Drawing.Point(19, 66);
            this._Cb_TpoNotRecDevB.Name = "_Cb_TpoNotRecDevB";
            this._Cb_TpoNotRecDevB.Size = new System.Drawing.Size(207, 20);
            this._Cb_TpoNotRecDevB.TabIndex = 3;
            this._Cb_TpoNotRecDevB.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoNotRecDevB_SelectedIndexChanged);
            // 
            // _Cb_TpoNotCpr
            // 
            this._Cb_TpoNotCpr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoNotCpr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoNotCpr.FormattingEnabled = true;
            this._Cb_TpoNotCpr.Location = new System.Drawing.Point(19, 28);
            this._Cb_TpoNotCpr.Name = "_Cb_TpoNotCpr";
            this._Cb_TpoNotCpr.Size = new System.Drawing.Size(207, 20);
            this._Cb_TpoNotCpr.TabIndex = 1;
            this._Cb_TpoNotCpr.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoNotCpr_SelectedIndexChanged);
            // 
            // _Cb_TpoNotRecProv
            // 
            this._Cb_TpoNotRecProv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoNotRecProv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoNotRecProv.FormattingEnabled = true;
            this._Cb_TpoNotRecProv.Location = new System.Drawing.Point(19, 142);
            this._Cb_TpoNotRecProv.Name = "_Cb_TpoNotRecProv";
            this._Cb_TpoNotRecProv.Size = new System.Drawing.Size(207, 20);
            this._Cb_TpoNotRecProv.TabIndex = 7;
            this._Cb_TpoNotRecProv.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoNotRecProv_SelectedIndexChanged);
            // 
            // _Txt_MaxEfectOC
            // 
            this._Txt_MaxEfectOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Txt_MaxEfectOC.Location = new System.Drawing.Point(19, 180);
            this._Txt_MaxEfectOC.MaxLength = 30;
            this._Txt_MaxEfectOC.Name = "_Txt_MaxEfectOC";
            this._Txt_MaxEfectOC.Size = new System.Drawing.Size(88, 18);
            this._Txt_MaxEfectOC.TabIndex = 9;
            this._Txt_MaxEfectOC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Txt_MaxEfectOC_KeyPress);
            this._Txt_MaxEfectOC.TextChanged += new System.EventHandler(this._Txt_MaxEfectOC_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(17, 165);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "% Efectividad OC:";
            // 
            // _Er_Error
            // 
            this._Er_Error.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._Er_Error.ContainerControl = this;
            // 
            // _Tb_Tab
            // 
            this._Tb_Tab.Controls.Add(this.tabPage1);
            this._Tb_Tab.Controls.Add(this.tabPage2);
            this._Tb_Tab.Controls.Add(this.tabPage3);
            this._Tb_Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Tb_Tab.Location = new System.Drawing.Point(0, 0);
            this._Tb_Tab.Name = "_Tb_Tab";
            this._Tb_Tab.SelectedIndex = 0;
            this._Tb_Tab.Size = new System.Drawing.Size(310, 283);
            this._Tb_Tab.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._Cb_TpoDocNRDev);
            this.tabPage1.Controls.Add(this._Cb_TpoDocNRCpr);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this._Cb_TpoDocNE);
            this.tabPage1.Controls.Add(this._Cb_TpoDocRecProv);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this._Cb_TpoDocOC);
            this.tabPage1.Controls.Add(this._Cb_TpoDocFactura);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(302, 258);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tipos de Documentos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _Cb_TpoDocNRDev
            // 
            this._Cb_TpoDocNRDev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoDocNRDev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoDocNRDev.FormattingEnabled = true;
            this._Cb_TpoDocNRDev.Location = new System.Drawing.Point(20, 222);
            this._Cb_TpoDocNRDev.Name = "_Cb_TpoDocNRDev";
            this._Cb_TpoDocNRDev.Size = new System.Drawing.Size(266, 20);
            this._Cb_TpoDocNRDev.TabIndex = 11;
            this._Cb_TpoDocNRDev.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoDocNRDev_SelectedIndexChanged);
            this._Cb_TpoDocNRDev.DropDown += new System.EventHandler(this._Cb_TpoDocNRDev_DropDown);
            // 
            // _Cb_TpoDocNRCpr
            // 
            this._Cb_TpoDocNRCpr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_TpoDocNRCpr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_TpoDocNRCpr.FormattingEnabled = true;
            this._Cb_TpoDocNRCpr.Location = new System.Drawing.Point(20, 184);
            this._Cb_TpoDocNRCpr.Name = "_Cb_TpoDocNRCpr";
            this._Cb_TpoDocNRCpr.Size = new System.Drawing.Size(266, 20);
            this._Cb_TpoDocNRCpr.TabIndex = 9;
            this._Cb_TpoDocNRCpr.SelectedIndexChanged += new System.EventHandler(this._Cb_TpoDocNRCpr_SelectedIndexChanged);
            this._Cb_TpoDocNRCpr.DropDown += new System.EventHandler(this._Cb_TpoDocNRCpr_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nota de Recepción por devolución:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "Nota de Recepción por compra:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._Cb_MotivoDifPrecio);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this._Cb_MotivoSobRec);
            this.tabPage2.Controls.Add(this._Cb_MotivoFaltRec);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(302, 258);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Motivos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _Cb_MotivoDifPrecio
            // 
            this._Cb_MotivoDifPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_MotivoDifPrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_MotivoDifPrecio.FormattingEnabled = true;
            this._Cb_MotivoDifPrecio.Location = new System.Drawing.Point(19, 117);
            this._Cb_MotivoDifPrecio.Name = "_Cb_MotivoDifPrecio";
            this._Cb_MotivoDifPrecio.Size = new System.Drawing.Size(262, 20);
            this._Cb_MotivoDifPrecio.TabIndex = 5;
            this._Cb_MotivoDifPrecio.SelectedIndexChanged += new System.EventHandler(this._Cb_MotivoDifPrecio_SelectedIndexChanged);
            this._Cb_MotivoDifPrecio.DropDown += new System.EventHandler(this._Cb_MotivoDifPrecio_DropDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "NC por diferencia de precio:";
            // 
            // _Cb_MotivoSobRec
            // 
            this._Cb_MotivoSobRec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_MotivoSobRec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_MotivoSobRec.FormattingEnabled = true;
            this._Cb_MotivoSobRec.Location = new System.Drawing.Point(19, 79);
            this._Cb_MotivoSobRec.Name = "_Cb_MotivoSobRec";
            this._Cb_MotivoSobRec.Size = new System.Drawing.Size(262, 20);
            this._Cb_MotivoSobRec.TabIndex = 3;
            this._Cb_MotivoSobRec.SelectedIndexChanged += new System.EventHandler(this._Cb_MotivoSobRec_SelectedIndexChanged);
            this._Cb_MotivoSobRec.DropDown += new System.EventHandler(this._Cb_MotivoSobRec_DropDown);
            // 
            // _Cb_MotivoFaltRec
            // 
            this._Cb_MotivoFaltRec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_MotivoFaltRec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_MotivoFaltRec.FormattingEnabled = true;
            this._Cb_MotivoFaltRec.Location = new System.Drawing.Point(19, 41);
            this._Cb_MotivoFaltRec.Name = "_Cb_MotivoFaltRec";
            this._Cb_MotivoFaltRec.Size = new System.Drawing.Size(262, 20);
            this._Cb_MotivoFaltRec.TabIndex = 1;
            this._Cb_MotivoFaltRec.SelectedIndexChanged += new System.EventHandler(this._Cb_MotivoFaltRec_SelectedIndexChanged);
            this._Cb_MotivoFaltRec.DropDown += new System.EventHandler(this._Cb_MotivoFaltRec_DropDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "NC por sobrante en la recepción:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "ND por faltante en la recepción:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this._Cb_Imp);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this._Txt_MaxEfectOC);
            this.tabPage3.Controls.Add(this._Cb_TpoNotRecDevM);
            this.tabPage3.Controls.Add(this._Cb_TpoNotRecDevB);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label24);
            this.tabPage3.Controls.Add(this._Cb_TpoNotCpr);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label23);
            this.tabPage3.Controls.Add(this._Cb_TpoNotRecProv);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(302, 258);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Otros";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // _Cb_Imp
            // 
            this._Cb_Imp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._Cb_Imp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Cb_Imp.FormattingEnabled = true;
            this._Cb_Imp.Location = new System.Drawing.Point(19, 218);
            this._Cb_Imp.Name = "_Cb_Imp";
            this._Cb_Imp.Size = new System.Drawing.Size(207, 20);
            this._Cb_Imp.TabIndex = 128;
            this._Cb_Imp.DropDown += new System.EventHandler(this._Cb_Imp_DropDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(17, 203);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 127;
            this.label20.Text = "Impuesto";
            // 
            // Frm_ConfigCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 283);
            this.Controls.Add(this._Tb_Tab);
            this.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ConfigCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración de compras";
            this.Activated += new System.EventHandler(this.Frm_ConfigCompra_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ConfigCompra_FormClosing);
            this.Load += new System.EventHandler(this.Frm_ConfigCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Er_Error)).EndInit();
            this._Tb_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _Cb_TpoNotRecDevM;
        private System.Windows.Forms.ComboBox _Cb_TpoNotRecDevB;
        private System.Windows.Forms.ComboBox _Cb_TpoNotCpr;
        private System.Windows.Forms.ComboBox _Cb_TpoNotRecProv;
        private System.Windows.Forms.ComboBox _Cb_TpoDocNE;
        private System.Windows.Forms.ComboBox _Cb_TpoDocRecProv;
        private System.Windows.Forms.ComboBox _Cb_TpoDocOC;
        private System.Windows.Forms.ComboBox _Cb_TpoDocFactura;
        private System.Windows.Forms.TextBox _Txt_MaxEfectOC;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ErrorProvider _Er_Error;
        private System.Windows.Forms.TabControl _Tb_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox _Cb_MotivoDifPrecio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox _Cb_MotivoSobRec;
        private System.Windows.Forms.ComboBox _Cb_MotivoFaltRec;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox _Cb_TpoDocNRDev;
        private System.Windows.Forms.ComboBox _Cb_TpoDocNRCpr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox _Cb_Imp;
        private System.Windows.Forms.Label label20;

    }
}