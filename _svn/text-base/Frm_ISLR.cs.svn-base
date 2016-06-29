using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ISLR : Form
    {
        public Frm_ISLR()
        {
            InitializeComponent();
        }

        string _Str_MyProceso = "";
        Control[] _Ctrl_Controles = new Control[8];
        CLASES._Cls_Varios_Metodos myUtilidad = new CLASES._Cls_Varios_Metodos(true);

        private void _Mtd_Bloquear(bool _Pr_Bol_A)
        {
            _Txt_ISLR.Enabled = false;
            _Txt_Concepto.Enabled = _Pr_Bol_A;
            _Txt_Pagador.Enabled = _Pr_Bol_A;
            _Grb_Prov.Enabled = _Pr_Bol_A;
            _Txt_PJD.Enabled = false;
            _Txt_PJND.Enabled = false;
            _Txt_PNNR.Enabled = false;
            _Txt_PNR.Enabled = false;
            _Bt_Form.Enabled = _Pr_Bol_A;
            _Bt_Form1.Enabled = _Pr_Bol_A;
            _Bt_Form2.Enabled = _Pr_Bol_A;
            _Bt_Form3.Enabled = _Pr_Bol_A;
            _Bt_FormE.Enabled = _Pr_Bol_A;
            _Bt_FormE1.Enabled = _Pr_Bol_A;
            _Bt_FormE2.Enabled = _Pr_Bol_A;
            _Bt_FormE3.Enabled = _Pr_Bol_A;
        }

        public void _Mtd_Ini()
        {
            _Str_MyProceso = "";
            _Txt_ISLR.Text = "";
            _Txt_Concepto.Text = "";
            _Txt_Pagador.Text = "";
            //_Rb_MatPrim.Checked = false;
            _Rb_Servicio.Checked = false;
            _Rb_Otros.Checked = false;
            _Cb_CatProve.SelectedValue = "nulo";
            _Txt_PNR.Text = "";
            _Txt_PNR.Tag = "";
            _Txt_PNNR.Text = "";
            _Txt_PNNR.Tag = "";
            _Txt_PJD.Text = "";
            _Txt_PJD.Tag = "";
            _Txt_PJND.Text = "";
            _Txt_PJND.Tag = "";
            //_Grb_Formulacion.Visible = false;
            _Mtd_Bloquear(false);
        }

        private void _Mtd_BotonesMenu()
        {
            if (_Str_MyProceso == "A")
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                //CONTROLES._Ctrl_Buscar._Txt_BotonCtrl.Text = "NF,MF,GT,EF,AF,CT"; 
            }
            if (_Str_MyProceso == "M")
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                //CONTROLES._Ctrl_Buscar._Txt_BotonCtrl.Text = "NT,MF,GT,EF,AF,CT"; 
            }
            if (_Str_MyProceso == "")
            {
                if (_Txt_ISLR.Text != "")
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                    //CONTROLES._Ctrl_Buscar._Txt_BotonCtrl.Text = "NT,MT,GF,ET,AT,CT"; 
                }
                else
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                    //CONTROLES._Ctrl_Buscar._Txt_BotonCtrl.Text = "NT,MF,GF,EF,AT,CT"; 
                }
            }
        }

        private void _Mtd_Sorted(DataGridView _Pr_Dg)
        {
            for (int _Int_i = 0; _Int_i < _Dg_Grid.Columns.Count; _Int_i++)
            {
                _Pr_Dg.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void _Mtd_CargarData(string _Pr_Str_Id)
        {
            string _Str_Sql = "";
            _Str_Sql = "SELECT * FROM VST_ISLR WHERE cislr_id='" + _Pr_Str_Id + "'";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
                _Txt_ISLR.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cislr_id"]);
                _Txt_Concepto.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cdescrip"]);
                _Txt_Pagador.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cpagador"]);
                if (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cglobal"])=="0")
                { _Rb_Servicio.Checked = true; }
                else if (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cglobal"])=="2")
                { _Rb_Otros.Checked = true; }
                //else if (Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cglobal"])=="1")
                //{ _Rb_MatPrim.Checked = true; }
                _Cb_CatProve.SelectedValue = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ccatproveedor"]);
                _Txt_PNR.Tag = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cpnrformula"]);
                _Txt_PNR.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cpnrformulaname"]);
                _Txt_PNNR.Tag = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cpnnrformula"]);
                _Txt_PNNR.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cpnnrformulaname"]);
                _Txt_PJD.Tag = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cpjdformula"]);
                _Txt_PJD.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cpjdformulaname"]);
                _Txt_PJND.Tag = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cpjndformula"]);
                _Txt_PJND.Text = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cpjndformulaname"]);

            }
        }

        private void _Mtd_CagarFormulas()
        {
            string _Str_Sql = "";
            _Lst_Formula.DataSource = null;
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cformula_id,cformula_name from TFORMULAS where cactivo=1 and cinactivo=0");
            _Lst_Formula.DisplayMember = "cformula_name";
            _Lst_Formula.ValueMember = "cformula_id";
            _Lst_Formula.DataSource = _Ds.Tables[0];
            
        }

        public void _Mtd_Cancelar()
        {
            _Mtd_Ini();
            _Tb_Tab.SelectedIndex = 0;
        }

        public void _Mtd_Habilitar()
        {
            _Str_MyProceso = "M";
            _Mtd_Bloquear(true);
            _Mtd_BotonesMenu();
            _Tb_Tab.SelectedIndex = 1;
        }

        public void _Mtd_Nuevo()
        {
            _Mtd_Ini();
            _Mtd_Bloquear(true);
            _Tb_Tab.SelectTab(1);
            _Str_MyProceso = "A";
            _Cb_CatProve.Enabled = false;
            _Bt_Form.Enabled = true;
            _Bt_Form1.Enabled = true;
            _Bt_Form2.Enabled = true;
            _Bt_Form3.Enabled = true;
            _Mtd_BotonesMenu();
        }

        public bool _Mtd_Eliminar()
        {
            string _Str_Sql = "";
            bool _Bol_R = false;
            if (MessageBox.Show("Está seguro de Elminar este ISLR?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Str_Sql = "UPDATE TISLR SET cinactivo=1,cactivo=0 WHERE cislr_id='" + _Txt_ISLR.Text + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Mtd_Ini();
                _Mtd_Actualizar();
                _Tb_Tab.SelectedIndex = 0;
                _Mtd_BotonesMenu();
                _Bol_R = true;
            }

            return _Bol_R;
        }

        public bool _Mtd_Guardar()
        {
            bool _Bol_Val = false;
            bool _Bol_R = false;
            string _Str_Sql = "";
            string _Str_Id = "";
            string _Str_TpoProv = "";
            if (_Str_MyProceso == "A")
            {
                if (_Txt_Concepto.Text.Trim() == "")
                {
                    _Er_Error.SetError(_Txt_Concepto, "Ingrese el Concepto.");
                    _Bol_Val = true;
                }
                if (_Txt_Pagador.Text.Trim() == "")
                {
                    _Er_Error.SetError(_Txt_Pagador, "Ingrese el Pagador.");
                    _Bol_Val = true;
                }
                //if (!_Rb_Servicio.Checked && !_Rb_Otros.Checked && !_Rb_MatPrim.Checked)
                //{
                //    MessageBox.Show("Seleccione un Tipo de Proveedor.","Validación",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                //    _Bol_Val = true;
                //}
                if (Convert.ToString(_Cb_CatProve.SelectedValue) == "nulo" && _Cb_CatProve.SelectedIndex>-1)
                {
                    _Er_Error.SetError(_Txt_Pagador, "Seleccione la Categoría del Proveedor.");
                    _Bol_Val = true;
                }
                if (_Txt_PNR.Text.Trim() == "" && _Txt_PNNR.Text.Trim() == "" && _Txt_PJD.Text.Trim() == "" && _Txt_PJND.Text.Trim() == "")
                {
                    MessageBox.Show("Debes ingresar formulaciones.","Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _Bol_Val = true;
                }

                if (!_Bol_Val)
                {
                    try
                    {
                        if (_Rb_Servicio.Checked )
                        {
                            _Str_TpoProv = "0";
                        }
                        if (_Rb_Otros.Checked)
                        {
                            _Str_TpoProv = "2";
                        }
                        //if (_Rb_MatPrim.Checked)
                        //{
                        //    _Str_TpoProv = "1";
                        //}

                        _Str_Sql = "Select Max(cislr_id) FROM TISLR";
                        _Str_Id = myUtilidad._Mtd_Correlativo(_Str_Sql);
                        _Str_Sql = "INSERT INTO TISLR (cislr_id,cdescrip,cpagador,cglobal,ccatproveedor,cpnrformula,cpnnrformula,cpjdformula,cpjndformula,cinactivo,cactivo) VALUES(";
                        _Str_Sql = _Str_Sql + _Str_Id + ",'" + _Txt_Concepto.Text.Trim().ToUpper() + "','" + _Txt_Pagador.Text.Trim().ToUpper() + "','" + _Str_TpoProv + "','" + Convert.ToString(_Cb_CatProve.SelectedValue) + "','" + Convert.ToString(_Txt_PNR.Tag) + "','" + Convert.ToString(_Txt_PNNR.Tag) + "','" + Convert.ToString(_Txt_PJD.Tag) + "','" + Convert.ToString(_Txt_PJND.Tag) + "',0,1)";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        _Txt_ISLR.Text = _Str_Id;
                        _Str_MyProceso = "";
                        _Mtd_Bloquear(false);
                        _Mtd_Actualizar();
                        _Mtd_BotonesMenu();
                        MessageBox.Show("Transacción guardada correctamente.", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Bol_R = false;
                    }
                    catch
                    { _Bol_R = false; }
                }
            }

            return _Bol_R;
        }

        public bool _Mtd_Editar()
        {
            bool _Bol_Val = false;
            bool _Bol_R = false;
            string _Str_Sql = "";
            string _Str_TpoProv = "";
            if (_Str_MyProceso == "M")
            {
                if (_Txt_Concepto.Text.Trim() == "")
                {
                    _Er_Error.SetError(_Txt_Concepto, "Ingrese el Concepto.");
                    _Bol_Val = true;
                }
                if (_Txt_Pagador.Text.Trim() == "")
                {
                    _Er_Error.SetError(_Txt_Pagador, "Ingrese el Pagador.");
                    _Bol_Val = true;
                }
                //if (!_Rb_Servicio.Checked && !_Rb_Otros.Checked && !_Rb_MatPrim.Checked)
                //{
                //    MessageBox.Show("Seleccione un Tipo de Proveedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    _Bol_Val = true;
                //}
                if (Convert.ToString(_Cb_CatProve.SelectedValue) == "nulo" && _Cb_CatProve.SelectedIndex > -1)
                {
                    _Er_Error.SetError(_Txt_Pagador, "Seleccione la Categoría del Proveedor.");
                    _Bol_Val = true;
                }
                if (_Txt_PNR.Text.Trim() == "" && _Txt_PNNR.Text.Trim() == "" && _Txt_PJD.Text.Trim() == "" && _Txt_PJND.Text.Trim() == "")
                {
                    MessageBox.Show("Tiene que tener una formulación.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _Bol_Val = true;
                }

                if (!_Bol_Val)
                {
                    try
                    {
                        if (_Rb_Servicio.Checked)
                        {
                            _Str_TpoProv = "0";
                        }
                        if (_Rb_Otros.Checked)
                        {
                            _Str_TpoProv = "2";
                        }
                        //if (_Rb_MatPrim.Checked)
                        //{
                        //    _Str_TpoProv = "1";
                        //}

                        _Str_Sql = "UPDATE TISLR SET cdescrip='" + _Txt_Concepto.Text.Trim().ToUpper() + "',cpagador='" + _Txt_Pagador.Text.Trim().ToUpper() + "',cglobal=" + _Str_TpoProv + ",ccatproveedor='" + Convert.ToString(_Cb_CatProve.SelectedValue) + "',cpnrformula='" + Convert.ToString(_Txt_PNR.Tag) + "',cpnnrformula='" + Convert.ToString(_Txt_PNNR.Tag) + "',cpjdformula='" + Convert.ToString(_Txt_PJD.Tag) + "',cpjndformula='" + Convert.ToString(_Txt_PJND.Tag) + "'";
                        _Str_Sql = _Str_Sql + " WHERE cislr_id=" + _Txt_ISLR.Text;
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        _Str_MyProceso = "";
                        _Mtd_Bloquear(false);
                        _Mtd_Actualizar();
                        _Mtd_BotonesMenu();
                        MessageBox.Show("Transacción guardada correctamente.", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Bol_R = false;
                    }
                    catch
                    { _Bol_R = false; }
                }
            }

            return _Bol_R;
        }

        private void Frm_ISLR_Load(object sender, EventArgs e)
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[1];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            string[] _Str_Campos = new string[1];
            _Str_Campos[0] = "cislr_id";
            string _Str_Cadena = "Select cislr_id as Código,cdescrip as Concepto,cpagador as [Pagador] from VST_ISLR where cinactivo=0 and cactivo=1";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "ISLR", _Tsm_Menu, _Dg_Grid, true, "");
            _Mtd_Actualizar();
            _Mtd_Ini();
            _Tb_Tab.SelectedIndex = 0; 
        }

        private void _Mtd_Actualizar()
        {
            string _Str_Cadena = "Select cislr_id as Código,cdescrip as Concepto,cpagador as [Pagador] from VST_ISLR where cinactivo=0 and cactivo=1";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void Frm_ISLR_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            //-------------------------------------------------------
            _Ctrl_Controles[0] = _Txt_ISLR;
            _Ctrl_Controles[1] = _Txt_Concepto;
            _Ctrl_Controles[2] = _Txt_Pagador;
            _Ctrl_Controles[3] = _Cb_CatProve;
            _Ctrl_Controles[4] = _Txt_PNR;
            _Ctrl_Controles[5] = _Txt_PNNR;
            _Ctrl_Controles[6] = _Txt_PJD;
            _Ctrl_Controles[7] = _Txt_PJND;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._Txt_BotonCtrl.Text = "";
            if (_Str_MyProceso == "M")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
            }
            else
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
                if (_Str_MyProceso == "A")
                { _Txt_Concepto.Focus(); }
            }
            CLASES._Cls_Varios_Metodos _Cls_CL = new CLASES._Cls_Varios_Metodos(_Ctrl_Controles);
            _Cls_CL._Mtd_Foco();
            _Mtd_BotonesMenu();
        }

        private void Frm_ISLR_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Bt_Form_Click(object sender, EventArgs e)
        {
            //_Grb_Formulacion.Visible = true;
            _Mtd_CagarFormulas();
            label4.Font = new Font(label4.Font.FontFamily, label4.Font.Size, FontStyle.Bold);
            label5.Font = new Font(label5.Font.FontFamily, label5.Font.Size, FontStyle.Regular);
            label7.Font = new Font(label7.Font.FontFamily, label7.Font.Size, FontStyle.Regular);
            label6.Font = new Font(label6.Font.FontFamily, label6.Font.Size, FontStyle.Regular);
            _Pnl_Form.Visible = true;
            //_Lst_Formula.Enabled = true;
            //_Bt_Aceptar.Enabled = true;
            //_Bt_Cancel.Enabled = true;            
        }

        private void _Txt_PNR_Enter(object sender, EventArgs e)
        {
            
        }

        private void _Bt_Form1_Click(object sender, EventArgs e)
        {
            //_Grb_Formulacion.Visible = true;
            _Mtd_CagarFormulas();
            label4.Font = new Font(label4.Font.FontFamily, label4.Font.Size, FontStyle.Regular);
            label5.Font = new Font(label5.Font.FontFamily, label5.Font.Size, FontStyle.Bold);
            label7.Font = new Font(label7.Font.FontFamily, label7.Font.Size, FontStyle.Regular);
            label6.Font = new Font(label6.Font.FontFamily, label6.Font.Size, FontStyle.Regular);
            //_Lst_Formula.Enabled = true;
            //_Bt_Aceptar.Enabled = true;
            //_Bt_Cancel.Enabled = true;  
            _Pnl_Form.Visible = true;
        }

        private void _Bt_Form2_Click(object sender, EventArgs e)
        {
            //_Grb_Formulacion.Visible = true;
            _Mtd_CagarFormulas();
            label4.Font = new Font(label4.Font.FontFamily, label4.Font.Size, FontStyle.Regular);
            label5.Font = new Font(label5.Font.FontFamily, label5.Font.Size, FontStyle.Regular);
            label7.Font = new Font(label7.Font.FontFamily, label7.Font.Size, FontStyle.Bold);
            label6.Font = new Font(label6.Font.FontFamily, label6.Font.Size, FontStyle.Regular);
            //_Lst_Formula.Enabled = true;
            //_Bt_Aceptar.Enabled = true;
            //_Bt_Cancel.Enabled = true;  
            _Pnl_Form.Visible = true;
        }

        private void _Bt_Form3_Click(object sender, EventArgs e)
        {
            //_Grb_Formulacion.Visible = true;
            _Mtd_CagarFormulas();
            label4.Font = new Font(label4.Font.FontFamily, label4.Font.Size, FontStyle.Regular);
            label5.Font = new Font(label5.Font.FontFamily, label5.Font.Size, FontStyle.Regular);
            label7.Font = new Font(label7.Font.FontFamily, label7.Font.Size, FontStyle.Regular);
            label6.Font = new Font(label6.Font.FontFamily, label6.Font.Size, FontStyle.Bold);
            //_Lst_Formula.Enabled = true;
            //_Bt_Aceptar.Enabled = true;
            //_Bt_Cancel.Enabled = true;  
            _Pnl_Form.Visible = true;
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            
            if (_Lst_Formula.SelectedIndex > -1)
            {
                
                if (label4.Font.Bold)
                {
                    _Txt_PNR.Text = Convert.ToString(_Lst_Formula.Text);
                    _Txt_PNR.Tag = Convert.ToString(_Lst_Formula.SelectedValue);
                    label4.Font = new Font(label4.Font.FontFamily, label4.Font.Size, FontStyle.Regular);
                }
                if (label5.Font.Bold)
                {
                    _Txt_PNNR.Text = Convert.ToString(_Lst_Formula.Text);
                    _Txt_PNNR.Tag = Convert.ToString(_Lst_Formula.SelectedValue);
                    label5.Font = new Font(label5.Font.FontFamily, label5.Font.Size, FontStyle.Regular);
                }
                if (label7.Font.Bold)
                {
                    _Txt_PJD.Text = Convert.ToString(_Lst_Formula.Text);
                    _Txt_PJD.Tag = Convert.ToString(_Lst_Formula.SelectedValue);
                    label7.Font = new Font(label7.Font.FontFamily, label7.Font.Size, FontStyle.Regular);
                }
                if (label6.Font.Bold)
                {
                    _Txt_PJND.Text = Convert.ToString(_Lst_Formula.Text);
                    _Txt_PJND.Tag = Convert.ToString(_Lst_Formula.SelectedValue);
                    label6.Font = new Font(label6.Font.FontFamily, label6.Font.Size, FontStyle.Regular);
                }
                //_Bt_Aceptar.Enabled = false;
                //_Bt_Cancel.Enabled = false;
                //_Lst_Formula.Enabled = false;
                _Pnl_Form.Visible = false;            
            }
            //_Grb_Formulacion.Visible = false;
        }

        private void _Mtd_CargarCatProv()
        {
            string _Str_CatProv = "";
            //if (_Rb_MatPrim.Checked)
            //{ _Str_CatProv = "1"; }
            if (_Rb_Otros.Checked)
            { _Str_CatProv = "2"; }
            if (_Rb_Servicio.Checked)
            { _Str_CatProv = "0"; }

            string _Str_Sql = "Select ccatproveedor,UPPER(cnombre) AS cnombre from TCATPROVEEDOR where cdelete='0' and cglobal='" + _Str_CatProv + "' order by cnombre";

            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            DataRow _DRow_ = _Ds.Tables[0].NewRow();
            _DRow_["ccatproveedor"] = "nulo";
            _DRow_["cnombre"] = "...";
            _Ds.Tables[0].Rows.Add(_DRow_);
            _Cb_CatProve.DisplayMember = "cnombre";
            _Cb_CatProve.ValueMember = "ccatproveedor";
            _Cb_CatProve.DataSource = _Ds.Tables[0];
            _Cb_CatProve.SelectedValue = "nulo";
        }

        private void _Rb_MatPrim_CheckedChanged(object sender, EventArgs e)
        {
            //if (_Rb_MatPrim.Checked)
            //{
            //    _Cb_CatProve.Enabled = true;
            //    _Mtd_CargarCatProv();
            //}
        }

        private void _Rb_Servicio_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Servicio.Checked)
            {
                _Cb_CatProve.Enabled = true;
                _Mtd_CargarCatProv();
            }
        }

        private void _Rb_Otros_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Otros.Checked)
            {
                _Cb_CatProve.Enabled = true;
                _Mtd_CargarCatProv();
            }
        }

        private void _Bt_Cancel_Click(object sender, EventArgs e)
        {
            //_Grb_Formulacion.Visible = false;
            label4.Font = new Font(label4.Font.FontFamily, label4.Font.Size, FontStyle.Regular);
            label5.Font = new Font(label5.Font.FontFamily, label5.Font.Size, FontStyle.Regular);
            label7.Font = new Font(label7.Font.FontFamily, label7.Font.Size, FontStyle.Regular);
            label6.Font = new Font(label6.Font.FontFamily, label6.Font.Size, FontStyle.Regular);
            //_Bt_Aceptar.Enabled = false;
            //_Bt_Cancel.Enabled = false;
            //_Lst_Formula.Enabled = false;
            _Pnl_Form.Visible = false; 
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.RowCount >= 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Ini();
                _Mtd_CargarData(Convert.ToString(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex)));
                _Tb_Tab.SelectTab(1);
                _Mtd_BotonesMenu();
                Cursor = Cursors.Default;
            }
        }

        private void _Bt_FormE_Click(object sender, EventArgs e)
        {
            _Txt_PNR.Text = "";
            _Txt_PNR.Tag = "0";
        }
        
        private void _Bt_FormE1_Click(object sender, EventArgs e)
        {
            _Txt_PNNR.Text = "";
            _Txt_PNNR.Tag = "0";
        }

        private void _Bt_FormE2_Click(object sender, EventArgs e)
        {
            _Txt_PJD.Text = "";
            _Txt_PJD.Tag = "0";
        }

        private void _Bt_FormE3_Click(object sender, EventArgs e)
        {
            _Txt_PJND.Text = "";
            _Txt_PJND.Tag = "0";
        }

        private void _Lst_Formula_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _Dg_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgInfo.Visible = true;
            }
            else
            {
                _Lbl_DgInfo.Visible = false;
            }
        }
    }
}