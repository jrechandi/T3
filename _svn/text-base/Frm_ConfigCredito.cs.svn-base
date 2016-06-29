using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConfigCredito : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        string _Str_MyProceso = "";
        public Frm_ConfigCredito()
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
            string _Str_Sql = "SELECT * FROM VST_CONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cporcsobregiro"]) != "")
                {
                    _Txt_PorcSob.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cporcsobregiro"]).ToString("#,##0.00");
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdoccheqdev"]) != "")
                {
                    _Cb_TpoDocCheqDev.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdoccheqdev"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]) != "")
                {
                    _Cb_TpoDocFactura.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocnotdeb"]) != "")
                {
                    _Cb_TpoDocND.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocnotdeb"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocnotcred"]) != "")
                {
                    _Cb_TpoDocNC.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocnotcred"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdoccheq"]) != "")
                {
                    _Cb_TpoDocCheq.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdoccheq"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocrelcob"]) != "")
                {
                    _Cb_TpoDocRelCob.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocrelcob"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdoccaja"]) != "")
                {
                    _Cb_TpoDocCaja.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdoccaja"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocumentdep"]) != "")
                {
                    _Cb_TpoDocDep.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocumentdep"]);
                }
                
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqdia"]).Trim() != "")
                {
                    _Txt_CountCheqDia.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqdia"]);
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqdianame"]).Trim() == "")
                    {
                        _Txt_CountCheqDia.Text = "Cuenta Desconocida";
                    }
                    else
                    {
                        _Txt_CountCheqDia.Text = _Txt_CountCheqDia.Tag.ToString() + " - " + Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqdianame"]).Trim();
                    }
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqtransito"]).Trim() != "")
                {
                    _Txt_CountCheqTrans.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqtransito"]);
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqtransitoname"]).Trim() == "")
                    {
                        _Txt_CountCheqTrans.Text = "Cuenta Desconocida";
                    }
                    else
                    {
                        _Txt_CountCheqTrans.Text = _Txt_CountCheqTrans.Tag.ToString() + " - " + Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqtransitoname"]).Trim();
                    }
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqdevuelto"]).Trim() != "")
                {
                    _Txt_CountCheqDev.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqdevuelto"]);
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqdevueltoname"]).Trim() == "")
                    {
                        _Txt_CountCheqDev.Text = "Cuenta Desconocida";
                    }
                    else
                    {
                        _Txt_CountCheqDev.Text = _Txt_CountCheqDev.Tag + " - " + Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacheqdevueltoname"]).Trim();
                    }
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentadescuentos"]).Trim() != "")
                {
                    _Txt_CountDescPPP.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentadescuentos"]);
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentadescuentosname"]).Trim() == "")
                    {
                        _Txt_CountDescPPP.Text = "Cuenta Desconocida";
                    }
                    else
                    {
                        _Txt_CountDescPPP.Text = _Txt_CountDescPPP.Tag.ToString() + " - " + Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentadescuentosname"]).Trim();
                    }
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentaivareten"]).Trim() != "")
                {
                    _Txt_CountRetImp.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentaivareten"]);
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentaivaretenname"]).Trim() == "")
                    {
                        _Txt_CountRetImp.Text = "Cuenta Desconocida";
                    }
                    else
                    {
                        _Txt_CountRetImp.Text = _Txt_CountRetImp.Tag.ToString() + " - " + Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentaivaretenname"]);
                    }
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentaiva"]).Trim() != "")
                {
                    _Txt_CountIVA.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentaiva"]);
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentaivaname"]).Trim() == "")
                    {
                        _Txt_CountIVA.Text = "Cuenta Desconocida";
                    }
                    else
                    {
                        _Txt_CountIVA.Text = _Txt_CountIVA.Tag.ToString() + " - " + Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentaivaname"]);
                    }
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacxc"]).Trim() != "")
                {
                    _Txt_CountCxC.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacxc"]);
                    if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacxcname"]).Trim() == "")
                    {
                        _Txt_CountCxC.Text = "Cuenta Desconocida";
                    }
                    else
                    {
                        _Txt_CountCxC.Text = _Txt_CountCxC.Tag.ToString() + " - " + Convert.ToString(_Ds.Tables[0].Rows[0]["ccuentacxcname"]);
                    }
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cfpagocheqdev"]) != "")
                {
                    _Cb_FPcheqDev.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cfpagocheqdev"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctypcompro"]) != "")
                {
                    _Cb_TpoComprob.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctypcompro"]);
                }
                _Txt_TpoComprobDescrip.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cconceptocomp"]).Trim();
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmotivodescpp"]).Length > 0)
                {
                    _Cb_MotivoDescppp.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cmotivodescpp"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cmotivodescod"]).Length > 0)
                {
                    _Cb_MotivoOtrosDesc.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cmotivodescod"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctax"]).Length > 0)
                {
                    _Cb_Imp.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctax"]).Trim();
                }
            }
        }
        private void _Mtd_CargarTpoDoc()
        {
            string _Str_Sql = "SELECT ctdocument,cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocFactura, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocCaja, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocCheq, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocCheqDev, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocDep, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocNC, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocND, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocRelCob, _Str_Sql);
        }
        private void _Mtd_CargarMotivos()
        {
            string _Str_Sql = "SELECT rtrim(cidmotivo),rtrim(cdescripcion) as cdescripcion FROM TMOTIVO WHERE cdelete=0 and cmotivodes=1 ORDER BY cdescripcion";
            _myUtilidad._Mtd_CargarCombo(_Cb_MotivoDescppp, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_MotivoOtrosDesc, _Str_Sql);
        }
        private void _Mtd_CargarOtros()
        {
            string _Str_Sql = "SELECT cfpago,cname FROM TFPAGO WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_FPcheqDev, _Str_Sql);
            _Str_Sql = "SELECT ctypcompro,rtrim(cname) as cname FROM TTCOMPROBAN ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoComprob, _Str_Sql);
            _Str_Sql = "SELECT rtrim(ctax),rtrim(cname) as cname FROM TTAX WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_Imp, _Str_Sql);
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
            foreach (Control _Ctrl in tabPage4.Controls)
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
            _Mtd_CargarMotivos();
            _Mtd_CargarTpoDoc();
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
                _Str_Sql = "SELECT * FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
                {
                    _Str_Sql = "UPDATE TCONFIGCXC SET cporcsobregiro='" + _Txt_PorcSob.Text.Replace(".", "").Replace(",", ".") + "',ctipdoccheqdev='" + _Cb_TpoDocCheqDev.SelectedValue.ToString() + "',ctipdocfact='" + _Cb_TpoDocFactura.SelectedValue.ToString() + "',ctipdocnotdeb='" + _Cb_TpoDocND.SelectedValue.ToString() + "',ctipdocnotcred='" + _Cb_TpoDocNC.SelectedValue.ToString() + "',ctipdoccheq='" + _Cb_TpoDocCheq.SelectedValue.ToString() + "',ctipdocrelcob='" + _Cb_TpoDocRelCob.SelectedValue.ToString() + "',ctipdocumentdep='" + _Cb_TpoDocDep.SelectedValue.ToString() + "',ctipdoccaja='" + _Cb_TpoDocCaja.SelectedValue.ToString() + "',ccuentacheqdia='" + Convert.ToString(_Txt_CountCheqDia.Tag) + "',ccuentacheqtransito='" + Convert.ToString(_Txt_CountCheqTrans.Tag) + "',ccuentacheqdevuelto='" + Convert.ToString(_Txt_CountCheqDev.Tag) + "',ccuentadescuentos='" + Convert.ToString(_Txt_CountDescPPP.Tag) + "',ccuentaivareten='" + Convert.ToString(_Txt_CountRetImp.Tag) + "',ccuentaiva='" + Convert.ToString(_Txt_CountIVA.Tag) + "',ccuentacxc='" + Convert.ToString(_Txt_CountCxC.Tag) + "',cfpagocheqdev='" + _Cb_FPcheqDev.SelectedValue.ToString() + "',ctypcompro='" + _Cb_TpoComprob.SelectedValue.ToString() + "',cconceptocomp='" + _Txt_TpoComprobDescrip.Text.Trim() + "',cmotivodescpp='" + _Cb_MotivoDescppp.SelectedValue.ToString() + "',cmotivodescod='" + _Cb_MotivoOtrosDesc.SelectedValue.ToString() + "',ctax='"+_Cb_Imp.SelectedValue.ToString()+"' WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
                else
                {
                    _Str_Sql = "INSERT INTO TCONFIGCXC (cporcsobregiro,ctipdoccheqdev,ctipdocfact,ctipdocnotdeb,ctipdocnotcred,ctipdoccheq,ctipdocrelcob,ctipdocumentdep,ctipdoccaja,ccuentacheqdia,ccuentacheqtransito,ccuentacheqdevuelto,ccuentadescuentos,ccuentaivareten,ccuentaiva,ccuentacxc,cfpagocheqdev,ccompany,ctypcompro,cconceptocomp,cmotivodescpp,cmotivodescod,ctax)";
                    _Str_Sql = _Str_Sql + " VALUES('" + _Txt_PorcSob.Text.Replace(".", "").Replace(",", ".") + "','" + _Cb_TpoDocCheqDev.SelectedValue.ToString() + "','" + _Cb_TpoDocFactura.SelectedValue.ToString() + "','" + _Cb_TpoDocND.SelectedValue.ToString() + "','" + _Cb_TpoDocNC.SelectedValue.ToString() + "','" + _Cb_TpoDocCheq.SelectedValue.ToString() + "','" + _Cb_TpoDocRelCob.SelectedValue.ToString() + "','" + _Cb_TpoDocDep.SelectedValue.ToString() + "','" + _Cb_TpoDocCaja.SelectedValue.ToString() + "','" + Convert.ToString(_Txt_CountCheqDia.Tag) + "','" + Convert.ToString(_Txt_CountCheqTrans.Tag) + "','" + Convert.ToString(_Txt_CountCheqDev.Tag) + "','" + Convert.ToString(_Txt_CountDescPPP.Tag) + "','" + Convert.ToString(_Txt_CountRetImp.Tag) + "','" + Convert.ToString(_Txt_CountIVA.Tag) + "','" + Convert.ToString(_Txt_CountCxC.Tag) + "','" + _Cb_FPcheqDev.SelectedValue.ToString() + "','" + Frm_Padre._Str_Comp + "','" + _Cb_TpoComprob.SelectedValue.ToString() + "','" + _Txt_TpoComprobDescrip.Text.Trim() + "','"+_Cb_MotivoDescppp.SelectedValue.ToString()+"','"+_Cb_MotivoOtrosDesc.SelectedValue.ToString()+"','"+_Cb_Imp.SelectedValue.ToString()+"')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
                _Bol_R = true;
                _Str_MyProceso = "";
                MessageBox.Show("Transacción guardada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Bloquear(false);
                _Er_Error.Dispose();
            }
            else
            {
                MessageBox.Show("Faltan datos requeridos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return _Bol_R;
        }

        private void Frm_ConfigCredito_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_ConfigCredito_Activated(object sender, EventArgs e)
        {
            _Mtd_BotonesMenu();
        }

        private void Frm_ConfigCredito_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
            _Mtd_Ini();
            _Mtd_CargarData();
        }

        private void _Txt_PorcSob_KeyPress(object sender, KeyPressEventArgs e)
        {
            _myUtilidad._Mtd_Valida_Numeros(_Txt_PorcSob, e, 3, 2);
        }

        private void _Bt_ChqTrans_Click(object sender, EventArgs e)
        {
            DataSet _Ds;
            string _Str_CodCuenta = "", _Str_Sql = ""; 
            Frm_VstCuentas _Frm_Vista = new Frm_VstCuentas();
            _Frm_Vista.ShowDialog();
            _Str_CodCuenta = _Frm_Vista._Str_FrmNodeSelec;
            if (_Str_CodCuenta != "")
            {
                _Txt_CountCheqTrans.Tag = _Str_CodCuenta;
                _Str_Sql = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_CodCuenta + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_CountCheqTrans.Text = _Str_CodCuenta + " - " + Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                }
            }
            _Frm_Vista.Dispose();
        }

        private void _Bt_ChqDev_Click(object sender, EventArgs e)
        {
            DataSet _Ds;
            string _Str_CodCuenta = "", _Str_Sql = "";
            Frm_VstCuentas _Frm_Vista = new Frm_VstCuentas();
            _Frm_Vista.ShowDialog();
            _Str_CodCuenta = _Frm_Vista._Str_FrmNodeSelec;
            if (_Str_CodCuenta != "")
            {
                _Txt_CountCheqDev.Tag = _Str_CodCuenta;
                _Str_Sql = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_CodCuenta + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_CountCheqDev.Text = _Str_CodCuenta + " - " + Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                }
            }
            _Frm_Vista.Dispose();
        }

        private void _Bt_DescPPP_Click(object sender, EventArgs e)
        {
            DataSet _Ds;
            string _Str_CodCuenta = "", _Str_Sql = "";
            Frm_VstCuentas _Frm_Vista = new Frm_VstCuentas();
            _Frm_Vista.ShowDialog();
            _Str_CodCuenta = _Frm_Vista._Str_FrmNodeSelec;
            if (_Str_CodCuenta != "")
            {
                _Txt_CountDescPPP.Tag = _Str_CodCuenta;
                _Str_Sql = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_CodCuenta + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_CountDescPPP.Text = _Str_CodCuenta + " - " + Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                }
            }
            _Frm_Vista.Dispose();
        }

        private void _Bt_RetImp_Click(object sender, EventArgs e)
        {
            DataSet _Ds;
            string _Str_CodCuenta = "", _Str_Sql = "";
            Frm_VstCuentas _Frm_Vista = new Frm_VstCuentas();
            _Frm_Vista.ShowDialog();
            _Str_CodCuenta = _Frm_Vista._Str_FrmNodeSelec;
            if (_Str_CodCuenta != "")
            {
                _Txt_CountRetImp.Tag = _Str_CodCuenta;
                _Str_Sql = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_CodCuenta + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_CountRetImp.Text = _Str_CodCuenta + " - " + Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                }
            }
            _Frm_Vista.Dispose();
        }

        private void _Bt_IVA_Click(object sender, EventArgs e)
        {
            DataSet _Ds;
            string _Str_CodCuenta = "", _Str_Sql = "";
            Frm_VstCuentas _Frm_Vista = new Frm_VstCuentas();
            _Frm_Vista.ShowDialog();
            _Str_CodCuenta = _Frm_Vista._Str_FrmNodeSelec;
            if (_Str_CodCuenta != "")
            {
                _Txt_CountIVA.Tag = _Str_CodCuenta;
                _Str_Sql = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_CodCuenta + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_CountIVA.Text = _Str_CodCuenta + " - " + Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                }
            }
            _Frm_Vista.Dispose();
        }

        private void _Bt_ChqDia_Click(object sender, EventArgs e)
        {
            DataSet _Ds;
            string _Str_CodCuenta = "", _Str_Sql = "";
            Frm_VstCuentas _Frm_Vista = new Frm_VstCuentas();
            _Frm_Vista.ShowDialog();
            _Str_CodCuenta = _Frm_Vista._Str_FrmNodeSelec;
            if (_Str_CodCuenta != "")
            {
                _Txt_CountCheqDia.Tag = _Str_CodCuenta;
                _Str_Sql = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_CodCuenta + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_CountCheqDia.Text = _Str_CodCuenta + " - " + Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                }
            }
            _Frm_Vista.Dispose();
        }

        private void _Bt_CxC_Click(object sender, EventArgs e)
        {
            DataSet _Ds;
            string _Str_CodCuenta = "", _Str_Sql = "";
            Frm_VstCuentas _Frm_Vista = new Frm_VstCuentas();
            _Frm_Vista.ShowDialog();
            _Str_CodCuenta = _Frm_Vista._Str_FrmNodeSelec;
            if (_Str_CodCuenta != "")
            {
                _Txt_CountCxC.Tag = _Str_CodCuenta;
                _Str_Sql = "SELECT cname FROM TCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Str_CodCuenta + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Txt_CountCxC.Text = _Str_CodCuenta + " - " + Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                }
            }
            _Frm_Vista.Dispose();
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

        private void _Cb_TpoDocFactura_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT ctdocument,cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocFactura, _Str_Sql);
        }

        private void _Cb_TpoDocND_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT ctdocument,cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocND, _Str_Sql);
        }

        private void _Cb_TpoDocNC_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT ctdocument,cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocNC, _Str_Sql);
        }

        private void _Cb_TpoDocCheq_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT ctdocument,cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocCheq, _Str_Sql);
        }

        private void _Cb_TpoDocCheqDev_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT ctdocument,cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocCheqDev, _Str_Sql);
        }

        private void _Cb_TpoDocRelCob_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT ctdocument,cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocRelCob, _Str_Sql);
        }

        private void _Cb_TpoDocDep_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT ctdocument,cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocDep, _Str_Sql);
        }

        private void _Cb_TpoDocCaja_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT ctdocument,cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocCaja, _Str_Sql);
        }

        private void _Cb_FPcheqDev_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT cfpago,cname FROM TFPAGO WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_FPcheqDev, _Str_Sql);
        }

        private void _Cb_TpoComprob_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT ctypcompro,rtrim(cname) as cname FROM TTCOMPROBAN ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoComprob, _Str_Sql);
        }

        private void _Cb_MotivoDescppp_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT rtrim(cidmotivo),rtrim(cdescripcion) as cdescripcion FROM TMOTIVO WHERE cdelete=0 and cmotivodes=1 ORDER BY cdescripcion";
            _myUtilidad._Mtd_CargarCombo(_Cb_MotivoDescppp, _Str_Sql);
        }

        private void _Cb_MotivoOtrosDesc_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT rtrim(cidmotivo),rtrim(cdescripcion) as cdescripcion FROM TMOTIVO WHERE cdelete=0 and cmotivodes=1 ORDER BY cdescripcion";
            _myUtilidad._Mtd_CargarCombo(_Cb_MotivoOtrosDesc, _Str_Sql);
        }

        private void _Cb_Imp_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT ctax,rtrim(cname) as cname FROM TTAX WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_Imp, _Str_Sql);
        }
    }
}