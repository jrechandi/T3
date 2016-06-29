using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConfigCompra : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        string _Str_MyProceso = "";
        public Frm_ConfigCompra()
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
                if (_Cb_TpoDocFactura.Enabled)
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
            string _Str_Sql = "SELECT * FROM TCONFIGCOMP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocumentnr"]) != "")
                {
                    _Cb_TpoDocNRCpr.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocumentnr"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocumentnrd"]) != "")
                {
                    _Cb_TpoDocNRDev.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocumentnrd"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocumentfact"]) != "")
                {
                    _Cb_TpoDocFactura.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocumentfact"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocumentoc"]) != "")
                {
                    _Cb_TpoDocOC.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocumentoc"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmotndfaltante"]) != "")
                {
                    _Cb_MotivoFaltRec.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cmotndfaltante"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmotncsobrante"]) != "")
                {
                    _Cb_MotivoSobRec.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cmotncsobrante"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmotncdiferprec"]) != "")
                {
                    _Cb_MotivoDifPrecio.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cmotncdiferprec"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctiponotreceprp"]) != "")
                {
                    _Cb_TpoNotRecProv.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctiponotreceprp"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocumentrp"]) != "")
                {
                    _Cb_TpoDocRecProv.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocumentrp"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctiponotentregaec"]) != "")
                {
                    _Cb_TpoNotCpr.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctiponotentregaec"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocumentnrec"]) != "")
                {
                    _Cb_TpoDocNE.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocumentnrec"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmaxefectivioc"]) != "")
                {
                    _Txt_MaxEfectOC.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmaxefectivioc"]).ToString("#,##0.00");
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctiponotrecepdevbe"]) != "")
                {
                    _Cb_TpoNotRecDevB.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctiponotrecepdevbe"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctiponotrecepdevme"]) != "")
                {
                    _Cb_TpoNotRecDevM.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctiponotrecepdevme"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctax"]).Length > 0)
                {
                    _Cb_Imp.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctax"]).Trim();
                }
            }
        }
        private void _Mtd_CargarTpoDoc()
        {
            string _Str_Sql = "SELECT rtrim(ctdocument),cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocFactura, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocOC, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocRecProv, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocNE, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocNRCpr, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocNRDev, _Str_Sql);
        }
        private void _Mtd_CargarMotivos()
        {
            string _Str_Sql = "SELECT rtrim(cidmotivo),rtrim(cdescripcion) as cdescripcion FROM TMOTIVO WHERE cdelete=0 ORDER BY cdescripcion";
            _myUtilidad._Mtd_CargarCombo(_Cb_MotivoFaltRec, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_MotivoSobRec, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_MotivoDifPrecio, _Str_Sql);
        }
        private void _Mtd_CargarTpoNotas()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cb_TpoNotRecProv.DataSource = null;
            _Cb_TpoNotCpr.DataSource = null;
            _Cb_TpoNotRecDevB.DataSource = null;
            _Cb_TpoNotRecDevM.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Devolución de Mercancia", "A"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Devolución de Mercancia mal estado", "B"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Recepción de Mercancia a Proveedores", "C"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Otros", "O"));
            _Cb_TpoNotRecProv.DataSource = _myArrayList;
            _Cb_TpoNotRecProv.DisplayMember = "Display";
            _Cb_TpoNotRecProv.ValueMember = "Value";
            _Cb_TpoNotRecProv.SelectedValue = "nulo";
            System.Collections.ArrayList _myArrayList1 = new System.Collections.ArrayList();
            for (int _I = 0; _I < _myArrayList.Count; _I++)
            {
                _myArrayList1.Add(new T3.Clases._Cls_ArrayList(((Clases._Cls_ArrayList)_myArrayList[_I]).Display, ((Clases._Cls_ArrayList)_myArrayList[_I]).Value));
            }
            _Cb_TpoNotCpr.DataSource = _myArrayList1;
            _Cb_TpoNotCpr.DisplayMember = "Display";
            _Cb_TpoNotCpr.ValueMember = "Value";
            _Cb_TpoNotCpr.SelectedValue = "nulo";
            System.Collections.ArrayList _myArrayList2 = new System.Collections.ArrayList();
            for (int _I = 0; _I < _myArrayList.Count; _I++)
            {
                _myArrayList2.Add(new T3.Clases._Cls_ArrayList(((Clases._Cls_ArrayList)_myArrayList[_I]).Display, ((Clases._Cls_ArrayList)_myArrayList[_I]).Value));
            }
            _Cb_TpoNotRecDevB.DataSource = _myArrayList2;
            _Cb_TpoNotRecDevB.DisplayMember = "Display";
            _Cb_TpoNotRecDevB.ValueMember = "Value";
            _Cb_TpoNotRecDevB.SelectedValue = "nulo";
            System.Collections.ArrayList _myArrayList3 = new System.Collections.ArrayList();
            for (int _I = 0; _I < _myArrayList.Count; _I++)
            {
                _myArrayList3.Add(new T3.Clases._Cls_ArrayList(((Clases._Cls_ArrayList)_myArrayList[_I]).Display, ((Clases._Cls_ArrayList)_myArrayList[_I]).Value));
            }
            _Cb_TpoNotRecDevM.DataSource = _myArrayList3;
            _Cb_TpoNotRecDevM.DisplayMember = "Display";
            _Cb_TpoNotRecDevM.ValueMember = "Value";
            _Cb_TpoNotRecDevM.SelectedValue = "nulo";
        }
        private void _Mtd_Bloquear(bool _Pr_Bol_A)
        {
            foreach (Control _Ctrl in tabPage1.Controls)
            {
                if (!(_Ctrl is Label))
                {
                    _Ctrl.Enabled = _Pr_Bol_A;
                }
            }
            foreach (Control _Ctrl in tabPage2.Controls)
            {
                if (!(_Ctrl is Label))
                {
                    _Ctrl.Enabled = _Pr_Bol_A;
                }
            }
            foreach (Control _Ctrl in tabPage3.Controls)
            {
                if (!(_Ctrl is Label))
                {
                    _Ctrl.Enabled = _Pr_Bol_A;
                }
            }
        }
        public void _Mtd_Ini()
        {
            _Er_Error.Dispose();
            _Str_MyProceso = "";
            foreach (Control _Ctrl in tabPage1.Controls)
            {
                if (!(_Ctrl is Label))
                {
                    if (!(_Ctrl is ComboBox))
                    {
                        _Ctrl.Text = "";
                    }
                    else if (_Ctrl is ComboBox)
                    {
                        if (((ComboBox)_Ctrl).DataSource != null)
                        {
                            ((ComboBox)_Ctrl).SelectedIndex = 0;
                        }
                        else
                        {
                            ((ComboBox)_Ctrl).SelectedIndex = -1;
                        }
                    }
                }
            }
            foreach (Control _Ctrl in tabPage2.Controls)
            {
                if (!(_Ctrl is Label))
                {
                    if (!(_Ctrl is ComboBox))
                    {
                        _Ctrl.Text = "";
                    }
                    else if (_Ctrl is ComboBox)
                    {
                        if (((ComboBox)_Ctrl).DataSource != null)
                        {
                            ((ComboBox)_Ctrl).SelectedIndex = 0;
                        }
                        else
                        {
                            ((ComboBox)_Ctrl).SelectedIndex = -1;
                        }
                    }
                }
            }
            foreach (Control _Ctrl in tabPage3.Controls)
            {
                if (!(_Ctrl is Label))
                {
                    if (!(_Ctrl is ComboBox))
                    {
                        _Ctrl.Text = "";
                    }
                    else if (_Ctrl is ComboBox)
                    {
                        if (((ComboBox)_Ctrl).DataSource != null)
                        {
                            ((ComboBox)_Ctrl).SelectedIndex = 0;
                        }
                        else
                        {
                            ((ComboBox)_Ctrl).SelectedIndex = -1;
                        }
                    }
                }
            }
            _Mtd_Bloquear(false);
            _Mtd_CargarTpoDoc();
            _Mtd_CargarMotivos();
            _Mtd_CargarTpoNotas();
            _Mtd_CargarOtros();
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
                _Str_Sql = "SELECT * FROM TCONFIGCOMP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
                {
                    _Str_Sql = "UPDATE TCONFIGCOMP SET ctipodocumentfact='" + _Cb_TpoDocFactura.SelectedValue.ToString() + "',ctipodocumentoc='" + _Cb_TpoDocOC.SelectedValue.ToString() + "',cmotndfaltante='" + _Cb_MotivoFaltRec.SelectedValue.ToString() + "',cmotncsobrante='" + _Cb_MotivoSobRec.SelectedValue.ToString() + "',cmotncdiferprec='" + _Cb_MotivoDifPrecio.SelectedValue.ToString() + "',ctiponotreceprp='" + _Cb_TpoNotRecProv.SelectedValue.ToString() + "',ctipodocumentrp='" + _Cb_TpoDocRecProv.SelectedValue.ToString() + "',ctiponotentregaec='" + _Cb_TpoNotCpr.SelectedValue.ToString() + "',ctipodocumentnrec='" + _Cb_TpoDocNE.SelectedValue.ToString() + "',cmaxefectivioc='" + _Txt_MaxEfectOC.Text.Replace(".", "").Replace(",", ".") + "',ctiponotrecepdevbe='" + _Cb_TpoNotRecDevB.SelectedValue.ToString() + "',ctiponotrecepdevme='" + _Cb_TpoNotRecDevM.SelectedValue.ToString() + "',ctipodocumentnr='" + _Cb_TpoDocNRCpr.SelectedValue.ToString() + "',ctipodocumentnrd='" + _Cb_TpoDocNRDev.SelectedValue.ToString() + "',ctax='" + _Cb_Imp.SelectedValue.ToString() + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
                else
                {
                    _Str_Sql = "INSERT INTO TCONFIGCOMP (ctipodocumentfact,ctipodocumentoc,cmotndfaltante,cmotncsobrante,cmotncdiferprec,ctiponotreceprp,ctipodocumentrp,ctiponotentregaec,ctipodocumentnrec,cmaxefectivioc,ctiponotrecepdevbe,ctiponotrecepdevme,ccompany,ctipodocumentnr,ctipodocumentnrd,ctax)";
                    _Str_Sql = _Str_Sql + " VALUES('" + _Cb_TpoDocFactura.SelectedValue.ToString() + "','" + _Cb_TpoDocOC.SelectedValue.ToString() + "','" + _Cb_MotivoFaltRec.SelectedValue.ToString() + "','" + _Cb_MotivoSobRec.SelectedValue.ToString() + "','" + _Cb_MotivoDifPrecio.SelectedValue.ToString() + "','" + _Cb_TpoNotRecProv.SelectedValue.ToString() + "','" + _Cb_TpoDocRecProv.SelectedValue.ToString() + "','" + _Cb_TpoNotCpr.SelectedValue.ToString() + "','" + _Cb_TpoDocNE.SelectedValue.ToString() + "','" + _Txt_MaxEfectOC.Text.Replace(".", "").Replace(",", ".") + "','" + _Cb_TpoNotRecDevB.SelectedValue.ToString() + "','" + _Cb_TpoNotRecDevM.SelectedValue.ToString() + "','" + Frm_Padre._Str_Comp + "','" + _Cb_TpoDocNRCpr.SelectedValue.ToString() + "','" + _Cb_TpoDocNRDev.SelectedValue.ToString() + "','" + _Cb_Imp.SelectedValue.ToString() + "')";
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

        private void Frm_ConfigCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_ConfigCompra_Activated(object sender, EventArgs e)
        {
            _Mtd_BotonesMenu();
        }

        private void Frm_ConfigCompra_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
            _Mtd_Ini();
            _Mtd_CargarData();
        }

        private void _Txt_MaxEfectOC_KeyPress(object sender, KeyPressEventArgs e)
        {
            _myUtilidad._Mtd_Valida_Numeros(_Txt_MaxEfectOC, e, 3, 2);
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

        private void _Cb_TpoDocFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoDocFactura, "");
        }

        private void _Cb_TpoDocOC_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoDocOC, "");
        }

        private void _Cb_TpoDocRecProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoDocRecProv, "");
        }

        private void _Cb_TpoDocNE_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoDocNE, "");
        }

        private void _Cb_MotivoFaltRec_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_MotivoFaltRec, "");
        }

        private void _Cb_MotivoSobRec_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_MotivoSobRec, "");
        }

        private void _Cb_MotivoDifPrecio_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_MotivoDifPrecio, "");
        }

        private void _Cb_TpoNotCpr_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoNotCpr, "");
        }

        private void _Cb_TpoNotRecDevB_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoNotRecDevB, "");
        }

        private void _Cb_TpoNotRecDevM_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoNotRecDevM, "");
        }

        private void _Cb_TpoNotRecProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoNotRecProv, "");
        }

        private void _Txt_MaxEfectOC_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Txt_MaxEfectOC, "");
        }

        private void _Cb_TpoDocFactura_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT rtrim(ctdocument),cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocFactura, _Str_Sql);
            this.Cursor = Cursors.Default;
        }

        private void _Cb_TpoDocOC_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT rtrim(ctdocument),cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocOC, _Str_Sql);
            this.Cursor = Cursors.Default;
        }

        private void _Cb_TpoDocRecProv_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT rtrim(ctdocument),cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocRecProv, _Str_Sql);
            this.Cursor = Cursors.Default;
        }

        private void _Cb_TpoDocNE_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT rtrim(ctdocument),cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocNE, _Str_Sql);
            this.Cursor = Cursors.Default;
        }

        private void _Cb_MotivoFaltRec_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT rtrim(cidmotivo),rtrim(cdescripcion) as cdescripcion FROM TMOTIVO WHERE cdelete=0 ORDER BY cdescripcion";
            _myUtilidad._Mtd_CargarCombo(_Cb_MotivoFaltRec, _Str_Sql);
            this.Cursor = Cursors.Default;
        }

        private void _Cb_MotivoSobRec_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT rtrim(cidmotivo),rtrim(cdescripcion) as cdescripcion FROM TMOTIVO WHERE cdelete=0 ORDER BY cdescripcion";
            _myUtilidad._Mtd_CargarCombo(_Cb_MotivoSobRec, _Str_Sql);
            this.Cursor = Cursors.Default;
        }

        private void _Cb_MotivoDifPrecio_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT rtrim(cidmotivo),rtrim(cdescripcion) as cdescripcion FROM TMOTIVO WHERE cdelete=0 ORDER BY cdescripcion";
            _myUtilidad._Mtd_CargarCombo(_Cb_MotivoDifPrecio, _Str_Sql);
            this.Cursor = Cursors.Default;
        }

        private void _Cb_TpoDocNRCpr_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT rtrim(ctdocument),cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocNRCpr, _Str_Sql);
            this.Cursor = Cursors.Default;
        }

        private void _Cb_TpoDocNRDev_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT rtrim(ctdocument),cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocNRDev, _Str_Sql);
            this.Cursor = Cursors.Default;
        }

        private void _Cb_TpoDocNRCpr_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoDocNRCpr, "");
        }

        private void _Cb_TpoDocNRDev_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoDocNRDev, "");
        }
        private void _Mtd_CargarOtros()
        {
            string _Str_Sql = "SELECT rtrim(ctax),rtrim(cname) as cname FROM TTAX WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_Imp, _Str_Sql);
        }

        private void _Cb_Imp_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Sql = "SELECT rtrim(ctax),rtrim(cname) as cname FROM TTAX WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_Imp, _Str_Sql);
            this.Cursor = Cursors.Default;
        }
    }
}