using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConfigVentas : Form
    {
        TabControl _Tab = new TabControl();
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        string _Str_MyProceso = "";
        public Frm_ConfigVentas()
        {
            InitializeComponent();
        }
        public void _Mtd_BotonesMenu()
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tab;
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
                if (_Cb_PorcEfecMinPed.Enabled)
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
            string _Str_Sql = "SELECT * FROM TCONFIGVENT WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cporcpedidoefec"])!="")
                {
                    _Cb_PorcEfecMinPed.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cporcpedidoefec"]).ToString();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cporcpedidoback"]) != "")
                {
                    _Cb_PorcEfecMinFactBackOrder.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cporcpedidoback"]).ToString();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cgrupowvend"]) != "")
                {
                    _Cb_GrupoUserVend.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cgrupowvend"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cgrupowger"]) != "")
                {
                    _Cb_GrupoUserGA.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cgrupowger"]).Trim();
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cdiasmaxbackorder"]) != "")
                {
                    _Cb_DiasMaxBackOrder.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cdiasmaxbackorder"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cnumprodfact"]) != "")
                {
                    _Txt_NumProdFact.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumprodfact"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ccreaemail1"]) != "")
                {
                    _Txt_MailVend.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["ccreaemail1"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocumentfact"]) != "")
                {
                    _Cb_Factura.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocumentfact"]).Trim();
                }
            }
        }
        private void _Mtd_CargarTpoDoc()
        {
            string _Str_Sql = "SELECT rtrim(ctdocument),UPPER(RTRIM(cname)) FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_Factura, _Str_Sql);
        }
        private void _Mtd_CargarGrupoUser()
        {
            string _Str_Sql = "SELECT rtrim(cgroup),UPPER(RTRIM(cname)) FROM T3TGROUP WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarComboWeb(_Cb_GrupoUserVend, _Str_Sql);
            _myUtilidad._Mtd_CargarComboWeb(_Cb_GrupoUserGA, _Str_Sql);
        }
        private void _Mtd_Bloquear(bool _Pr_Bol_A)
        {
            foreach (Control _Ctrl in this.Controls)
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
            _Mtd_CargarGrupoUser();
        }
        private bool _Mtd_ValidaSave(Control _P_Ctrl_Control)
        {
            bool _Bol_Sw = true;
            _Er_Error.Dispose();
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Bol_Sw = _Mtd_ValidaSave(_Ctrl);
                }
                if (_Ctrl is ComboBox)
                {
                    if (((ComboBox)_Ctrl).SelectedIndex < 1)
                    {
                        _Er_Error.SetError(_Ctrl, "Información requerida");
                        _Bol_Sw = false;
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
            if (_Mtd_ValidaSave(this))
            {
                _Str_Sql = "SELECT * FROM TCONFIGVENT WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
                {
                    _Str_Sql = "UPDATE TCONFIGVENT SET cporcpedidoefec='" + _Cb_PorcEfecMinPed.Text.Replace(".", "").Replace(",", ".") + "',cporcpedidoback='" + _Cb_PorcEfecMinFactBackOrder.Text.Replace(".", "").Replace(",", ".") + "',cgrupowvend='" + _Cb_GrupoUserVend.SelectedValue.ToString() + "',cgrupowger='" + _Cb_GrupoUserGA.SelectedValue.ToString() + "',ccreaemail1='" + _Txt_MailVend.Text.Trim() + "',cdiasmaxbackorder='" + _Cb_DiasMaxBackOrder.Text.Replace(".", "").Replace(",", ".") + "',ctipodocumentfact='" + _Cb_Factura.SelectedValue.ToString() + "',cnumprodfact='" + _Txt_NumProdFact.Text.Replace(".", "").Replace(",", ".") + "',cdateupd=GETDATE(),cuserupd='"+ Frm_Padre._Str_Use +"',cdelete=0 WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
                else
                {
                    _Str_Sql = "INSERT INTO TCONFIGVENT (cporcpedidoefec,cporcpedidoback,cgrupowvend,cgrupowger,ccreaemail1,cdiasmaxbackorder,cnumprodfact,ccompany,cdateadd,cuseradd)";
                    _Str_Sql = _Str_Sql + " VALUES('" + _Cb_PorcEfecMinPed.Text.Replace(".", "").Replace(",", ".") + "','" + _Cb_PorcEfecMinFactBackOrder.Text.Replace(".", "").Replace(",", ".") + "','" + _Cb_GrupoUserVend.SelectedValue.ToString() + "','" + _Cb_GrupoUserGA.SelectedValue.ToString() + "','" + _Txt_MailVend.Text.Trim() + "','" + _Cb_DiasMaxBackOrder.Text.Replace(".", "").Replace(",", ".") + "','" + _Cb_Factura.SelectedValue.ToString() + "','" + _Txt_NumProdFact.Text.Replace(".", "").Replace(",", ".") + "','" + Frm_Padre._Str_Comp + "',GETDATE(),'"+Frm_Padre._Str_Use+"')";
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

        private void Frm_ConfigVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_ConfigVentas_Activated(object sender, EventArgs e)
        {
            _Mtd_BotonesMenu();
        }

        private void Frm_ConfigVentas_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
            _Mtd_Ini();
            _Mtd_CargarComboPorc(_Cb_PorcEfecMinPed,101);
            _Mtd_CargarComboPorc(_Cb_PorcEfecMinFactBackOrder,101);
            _Mtd_CargarComboPorc(_Cb_DiasMaxBackOrder, 31);
            _Mtd_CargarData();
        }

        private void _Txt_NumProdFact_KeyPress(object sender, KeyPressEventArgs e)
        {
            _myUtilidad._Mtd_Valida_Numeros(_Txt_NumProdFact, e, 3, 0);
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
        private void _Mtd_CargarComboPorc(ComboBox _Pr_Cb,int _Pr_Int_Hasta)
        {
            for (int _I = 1; _I < _Pr_Int_Hasta; _I++)
            {
                _Pr_Cb.Items.Add(_I.ToString());
            }
            _Pr_Cb.SelectedIndex = -1;
        }

        private void _Cb_GrupoUserVend_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT RTRIM(cgroup),UPPER(RTRIM(cname)) FROM T3TGROUP WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarComboWeb(_Cb_GrupoUserVend, _Str_Sql);
        }

        private void _Cb_GrupoUserGA_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT RTRIM(cgroup),UPPER(RTRIM(cname)) FROM T3TGROUP WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarComboWeb(_Cb_GrupoUserGA, _Str_Sql);
        }

        private void _Cb_Factura_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT RTRIM(ctdocument),UPPER(RTRIM(cname)) FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_Factura, _Str_Sql);
        }
    }
}