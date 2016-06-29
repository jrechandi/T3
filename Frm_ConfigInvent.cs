using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConfigInvent : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        string _Str_MyProceso = "";
        public Frm_ConfigInvent()
        {
            InitializeComponent();
        }
        public void _Mtd_BotonesMenu()
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            if (_Str_MyProceso == "M")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            if (_Str_MyProceso == "")
            {
                if (_Cb_TpoMovEntAjust.Enabled)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                }
                else
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                }
            }
        }
        private void _Mtd_CargarData()
        {
            string _Str_Sql = "SELECT * FROM VST_TCONFINVENT WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctmovanulfact"]) != "")
                {
                    _Cb_TpoMovAnulFact.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctmovanulfact"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctmoventraajus"]) != "")
                {
                    _Cb_TpoMovEntAjust.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctmoventraajus"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctmovsalajus"]) != "")
                {
                    _Cb_TpoMovSalAjust.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctmovsalajus"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctmovnotrecep"]) != "")
                {
                    _Cb_TpoMovNotRec.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctmovnotrecep"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctmovcompra"]) != "")
                {
                    _Cb_TpoMovCpr.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctmovcompra"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctmovventa"]) != "")
                {
                    _Cb_TpoMovFactVta.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctmovventa"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctmovdevcomp"]) != "")
                {
                    _Cb_TpoMovDevolCpr.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctmovdevcomp"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctmovdevolvent"]) != "")
                {
                    _Cb_TpoMovDevolVta.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctmovdevolvent"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmesconsul"]) != "")
                {
                    _Txt_Meses.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cmesconsul"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctmotentraajus"]) != "")
                {
                    _Cb_MotvEntAjust.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctmotentraajus"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctmotsalajus"]) != "")
                {
                    _Cb_MotvSalAjust.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctmotsalajus"]).Trim();
                }
            }
        }
        private void _Mtd_CargarMotivos()
        {
            string _Str_Sql = "SELECT rtrim(cidmotivo),rtrim(cdescripcion) FROM TMOTIVO WHERE cdelete=0 and cajusteentr=1 ORDER BY cdescripcion";
            _myUtilidad._Mtd_CargarCombo(_Cb_MotvEntAjust, _Str_Sql);
            _Str_Sql = "SELECT rtrim(cidmotivo),rtrim(cdescripcion) FROM TMOTIVO WHERE cdelete=0 and cajustesali=1 ORDER BY cdescripcion";
            _myUtilidad._Mtd_CargarCombo(_Cb_MotvSalAjust, _Str_Sql);
        }
        private void _Mtd_CargarTpoMov()
        {
            string _Str_Sql = "SELECT rtrim(ctmovimiento),cname FROM TTMOVIMIENTO WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoMovEntAjust, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoMovCpr, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoMovFactVta, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoMovNotRec, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoMovSalAjust, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoMovDevolVta, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoMovDevolCpr, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoMovAnulFact, _Str_Sql);
        }
        private void _Mtd_Bloquear(bool _Pr_Bol_A)
        {
            for (int _I = 0; _I < _Tb_Tab.TabPages.Count; _I++)
            {
                foreach (Control _Ctrl in _Tb_Tab.TabPages[_I].Controls)
                {
                    if (!(_Ctrl is Label))
                    {
                        _Ctrl.Enabled = _Pr_Bol_A;
                    }
                }
            }
        }
        public void _Mtd_Ini()
        {
            _Er_Error.Dispose();
            _Str_MyProceso = "";
            foreach (Control _Ctrl in this.Controls)
            {
                if (_Ctrl is Panel)
                {
                    foreach (Control _CtrlH in _Ctrl.Controls)
                    {
                        if (!(_CtrlH is Label) && !(_CtrlH is Button))
                        {
                            if (!(_CtrlH is ComboBox))
                            {
                                _CtrlH.Text = "";
                            }
                            else if (_CtrlH is ComboBox)
                            {
                                if (((ComboBox)_CtrlH).DataSource != null)
                                {
                                    ((ComboBox)_CtrlH).SelectedIndex = 0;
                                }
                                else
                                {
                                    ((ComboBox)_CtrlH).SelectedIndex = -1;
                                }
                            }
                        }
                    }
                }
            }
            _Mtd_Bloquear(false);
            _Mtd_CargarTpoMov();
            _Mtd_CargarMotivos();
        }
        private bool _Mtd_ValidaSave()
        {
            bool _Bol_Sw = true;
            _Er_Error.Dispose();
            for (int _I = 0; _I < _Tb_Tab.TabPages.Count; _I++)
            {
                foreach (Control _Ctrl in _Tb_Tab.TabPages[_I].Controls)
                {
                    if (_Ctrl is TextBox)
                    {
                        if (_Ctrl.Text.Trim() == "")
                        {
                            _Er_Error.SetError(_Ctrl, "Información requerida");
                            _Bol_Sw = false;
                        }
                    }
                    else if (_Ctrl is ComboBox)
                    {
                        if (((ComboBox)_Ctrl).SelectedIndex < 1)
                        {
                            _Er_Error.SetError(_Ctrl, "Información requerida");
                            _Bol_Sw = false;
                        }
                    }
                }
            }
            return _Bol_Sw;
        }
        public void _Mtd_Habilitar()
        {
            _Mtd_Bloquear(true);
            _Str_MyProceso = "M";
        }
        public bool _Mtd_Editar()
        {
            bool _Bol_R = false;
            string _Str_Sql = "";
            if (_Mtd_ValidaSave())
            {
                _Str_Sql = "SELECT * FROM TCONFINVENT WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
                {
                    _Str_Sql = "UPDATE TCONFINVENT SET ctmoventraajus='" + _Cb_TpoMovEntAjust.SelectedValue.ToString() + "',ctmovsalajus='" + _Cb_TpoMovSalAjust.SelectedValue.ToString() + "',ctmovnotrecep='" + _Cb_TpoMovNotRec.SelectedValue.ToString() + "',ctmovcompra='" + _Cb_TpoMovCpr.SelectedValue.ToString() + "',ctmovventa='" + _Cb_TpoMovFactVta.SelectedValue.ToString() + "',cmesconsul='" + _Txt_Meses.Text.Replace(",", ".") + "',cuserupd='" + Frm_Padre._Str_Use + "',cdateupd=GETDATE(),ctmovdevcomp='" + _Cb_TpoMovDevolCpr.SelectedValue.ToString() + "',ctmovdevolvent='" + _Cb_TpoMovDevolVta.SelectedValue.ToString() + "',ctmovanulfact='" + _Cb_TpoMovAnulFact.SelectedValue.ToString() + "',ctmotentraajus='" + _Cb_MotvEntAjust.SelectedValue.ToString() + "',ctmotsalajus='" + _Cb_MotvSalAjust.SelectedValue.ToString() + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
                else
                {
                    _Str_Sql = "INSERT INTO TCONFINVENT (ctmoventraajus,ctmovsalajus,ctmovnotrecep,ctmovcompra,ctmovventa,cmesconsul,ccompany,ctmovdevcomp,ctmovdevolvent,ctmovanulfact,ctmotentraajus,ctmotsalajus)";
                    _Str_Sql = _Str_Sql + " VALUES('" + _Cb_TpoMovEntAjust.SelectedValue.ToString() + "','" + _Cb_TpoMovSalAjust.SelectedValue.ToString() + "','" + _Cb_TpoMovNotRec.SelectedValue.ToString() + "','" + _Cb_TpoMovCpr.SelectedValue.ToString() + "','" + _Cb_TpoMovFactVta.SelectedValue.ToString() + "','" + _Txt_Meses.Text.Replace(",", ".") + "','" + Frm_Padre._Str_Comp + "','" + _Cb_TpoMovDevolCpr.SelectedValue.ToString() + "','" + _Cb_TpoMovDevolVta.SelectedValue.ToString() + "','" + _Cb_TpoMovAnulFact.SelectedValue.ToString() + "','" + _Cb_MotvEntAjust.SelectedValue.ToString() + "','" + _Cb_MotvSalAjust.SelectedValue.ToString() + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
                _Bol_R = true;
                MessageBox.Show("Transacción guardada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Str_MyProceso = "";
                _Mtd_Bloquear(false);
                _Er_Error.Dispose();
            }
            else
            {
                MessageBox.Show("Faltan datos requeridos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return _Bol_R;
        }

        private void Frm_ConfigInvent_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_ConfigInvent_Activated(object sender, EventArgs e)
        {
            _Mtd_BotonesMenu();
        }

        private void Frm_ConfigInvent_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
            _Mtd_Ini();
            _Mtd_CargarData();
        }
        private void _Mtd_Color_Estandar(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Color_Estandar(_Ctrl);
                }
                new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco();
            }
        }

        private void _Txt_Meses_KeyPress(object sender, KeyPressEventArgs e)
        {
            _myUtilidad._Mtd_Valida_Numeros(_Txt_Meses, e, 5, 0);
        }

        private void _Cb_TpoMovEntAjust_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT rtrim(ctmovimiento),cname FROM TTMOVIMIENTO WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoMovEntAjust, _Str_Sql);
            this.Cursor = Cursors.Default;
        }

        private void _Cb_TpoMovSalAjust_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT rtrim(ctmovimiento),cname FROM TTMOVIMIENTO WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoMovSalAjust, _Str_Sql);
            this.Cursor = Cursors.Default;
        }

        private void _Cb_TpoMovNotRec_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT rtrim(ctmovimiento),cname FROM TTMOVIMIENTO WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoMovNotRec, _Str_Sql);
            this.Cursor = Cursors.Default;
        }

        private void _Cb_TpoMovCpr_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT rtrim(ctmovimiento),cname FROM TTMOVIMIENTO WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoMovCpr, _Str_Sql);
            this.Cursor = Cursors.Default;
        }

        private void _Cb_TpoMovFactVta_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT rtrim(ctmovimiento),cname FROM TTMOVIMIENTO WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoMovFactVta, _Str_Sql);
            this.Cursor = Cursors.Default;
        }

        private void _Cb_TpoMovDevolVta_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT rtrim(ctmovimiento),cname FROM TTMOVIMIENTO WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoMovDevolVta, _Str_Sql);
            this.Cursor = Cursors.Default;
        }

        private void _Cb_TpoMovDevolCpr_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT rtrim(ctmovimiento),cname FROM TTMOVIMIENTO WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoMovDevolCpr, _Str_Sql);
            this.Cursor = Cursors.Default;
        }

        private void _Cb_TpoMovAnulFact_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT rtrim(ctmovimiento),cname FROM TTMOVIMIENTO WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoMovAnulFact, _Str_Sql);
            this.Cursor = Cursors.Default;
        }

        private void _Cb_TpoMovAnulFact_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoMovAnulFact, "");
        }

        private void _Cb_TpoMovEntAjust_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoMovEntAjust, "");
        }

        private void _Cb_TpoMovSalAjust_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoMovSalAjust, "");
        }

        private void _Cb_TpoMovNotRec_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoMovNotRec, "");
        }

        private void _Cb_TpoMovCpr_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoMovCpr, "");
        }

        private void _Cb_TpoMovFactVta_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoMovFactVta, "");
        }

        private void _Cb_TpoMovDevolVta_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoMovDevolVta, "");
        }

        private void _Cb_TpoMovDevolCpr_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoMovDevolCpr, "");
        }

        private void _Cb_MotvEntAjust_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT rtrim(cidmotivo),rtrim(cdescripcion) FROM TMOTIVO WHERE cdelete=0 and cajusteentr=1 ORDER BY cdescripcion";
            _myUtilidad._Mtd_CargarCombo(_Cb_MotvEntAjust, _Str_Sql);
            this.Cursor = Cursors.Default;
        }

        private void _Cb_MotvSalAjust_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT rtrim(cidmotivo),rtrim(cdescripcion) FROM TMOTIVO WHERE cdelete=0 and cajustesali=1 ORDER BY cdescripcion";
            _myUtilidad._Mtd_CargarCombo(_Cb_MotvSalAjust, _Str_Sql);
            this.Cursor = Cursors.Default;
        }

        private void _Cb_MotvEntAjust_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_MotvEntAjust, "");
        }

        private void _Cb_MotvSalAjust_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_MotvSalAjust, "");
        }
    }
}