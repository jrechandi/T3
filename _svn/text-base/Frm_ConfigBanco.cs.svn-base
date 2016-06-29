using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ConfigBanco : Form
    {
        TabControl _Tab = new TabControl();
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        string _Str_MyProceso = "";
        public Frm_ConfigBanco()
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
                if (_Cb_TpoDocDep.Enabled)
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
            string _Str_Sql = "SELECT * FROM TCONFIGBANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocumentdep"]) != "")
                {
                    _Cb_TpoDocDep.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocumentdep"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["coperdeposito"]) != "")
                {
                    _Cb_TpoOperDep.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["coperdeposito"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["copernotadebito"]) != "")
                {
                    _Cb_TpoOperND.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["copernotadebito"]);
                }
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["coperbancemicheq"]) != "")
                {
                    _Cb_TpoOperEmiCheq.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["coperbancemicheq"]);
                }
            }
        }
        private void _Mtd_CargarTpoDoc()
        {
            string _Str_Sql = "SELECT ctdocument,cname FROM TDOCUMENT WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoDocDep, _Str_Sql);
        }
        private void _Mtd_CargarTpoOper()
        {
            string _Str_Sql = "SELECT coperbanc,cname FROM TOPERBANC WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoOperDep, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoOperND, _Str_Sql);
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoOperEmiCheq, _Str_Sql);
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
            _Mtd_CargarTpoOper();
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
                _Str_Sql = "SELECT * FROM TCONFIGBANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
                {
                    _Str_Sql = "UPDATE TCONFIGBANCO SET coperbancemicheq='" + _Cb_TpoOperEmiCheq.SelectedValue.ToString() + "',ctipdocumentdep='" + _Cb_TpoDocDep.SelectedValue.ToString() + "',coperdeposito='" + _Cb_TpoOperDep.SelectedValue.ToString() + "',copernotadebito='" + _Cb_TpoOperND.SelectedValue.ToString() + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
                else
                {
                    _Str_Sql = "INSERT INTO TCONFIGBANCO (coperbancemicheq,ctipdocumentdep,coperdeposito,copernotadebito,ccompany)";
                    _Str_Sql = _Str_Sql + " VALUES('" + _Cb_TpoOperEmiCheq.SelectedValue.ToString() + "','" + _Cb_TpoDocDep.SelectedValue.ToString() + "','" + _Cb_TpoOperDep.SelectedValue.ToString() + "','" + _Cb_TpoOperND.SelectedValue.ToString() + "','" + Frm_Padre._Str_Comp + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
                _Bol_R = true;
                MessageBox.Show("Transacción guardada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Bloquear(false);
                _Str_MyProceso = "";
                _Er_Error.Dispose();
            }
            else
            {
                MessageBox.Show("Faltan datos requeridos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return _Bol_R;
        }

        private void Frm_ConfigBanco_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void Frm_ConfigBanco_Activated(object sender, EventArgs e)
        {
            _Mtd_BotonesMenu();
        }

        private void Frm_ConfigBanco_Load(object sender, EventArgs e)
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

        private void _Cb_TpoDocDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoDocDep, "");
        }

        private void _Cb_TpoOperDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoOperDep, "");
        }

        private void _Cb_TpoOperND_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoOperND, "");
        }

        private void _Cb_TpoOperEmiCheq_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.SetError(_Cb_TpoOperEmiCheq, "");
        }

        private void _Cb_TpoDocDep_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarTpoDoc();
        }

        private void _Cb_TpoOperDep_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT coperbanc,cname FROM TOPERBANC WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoOperDep, _Str_Sql);
        }

        private void _Cb_TpoOperND_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT coperbanc,cname FROM TOPERBANC WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoOperND, _Str_Sql);
        }

        private void _Cb_TpoOperEmiCheq_DropDown(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT coperbanc,cname FROM TOPERBANC WHERE cdelete=0 ORDER BY cname";
            _myUtilidad._Mtd_CargarCombo(_Cb_TpoOperEmiCheq, _Str_Sql);
        }
    }
}