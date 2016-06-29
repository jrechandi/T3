using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ParLimPago : Form
    {
        string _Str_MyProceso = "";
        string _Str_FrmIdlimitpago = "";
        string _Str_FrmTpoProvEdit = "";
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        public Frm_ParLimPago()
        {
            InitializeComponent();
            _Mtd_CargarTipoProv();
        }
        private void _Mtd_CargarBusqueda()
        {
            object[] _Str_RowNew = new object[8];
            string _Str_Sql = "Select cidlimitpago,cusuariop + ' - ' + cname AS cname, dbo.TCARGOSNOM.cdescripcion AS Cargo,('DESDE:' + dbo.Fnc_Formatear(cmontlimited) + ' HASTA:' + dbo.Fnc_Formatear(cmontlimiteh)) as climitedescrip FROM VST_PAGOSCXPP INNER JOIN TCARGOSNOM ON VST_PAGOSCXPP.cposition COLLATE DATABASE_DEFAULT = TCARGOSNOM.cidcargonom WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " and ccompany='" + Frm_Padre._Str_Comp + "'";
            if (_Rb_FMatPrim.Checked)
            { _Str_Sql = _Str_Sql + " AND ctipoproveedor=1"; }
            else if (_Rb_FOtros.Checked)
            { _Str_Sql = _Str_Sql + " AND ctipoproveedor=2"; }
            else if (_Rb_FServicio.Checked)
            { _Str_Sql = _Str_Sql + " AND ctipoproveedor=0"; }
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_Find.DataSource = _Ds_Data.Tables[0];
            _Dg_Find.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void _Mtd_CargarTipoProv()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_TipoProv.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("SERVICIO", "0"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("MATERIA PRIMA", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("OTROS", "2"));
            _Cmb_TipoProv.DataSource = _myArrayList;
            _Cmb_TipoProv.DisplayMember = "Display";
            _Cmb_TipoProv.ValueMember = "Value";
            _Cmb_TipoProv.SelectedValue = "nulo";
            _Cmb_TipoProv.DataSource = _myArrayList;
            _Cmb_TipoProv.SelectedIndex = 0;
        }
        private void _Mtd_Bloquear(bool _Pr_Bol_A)
        {
            _Cb_Usuario.Enabled = _Pr_Bol_A;
            _Cmb_TipoProv.Enabled = _Pr_Bol_A;
            _Txt_Desde.Enabled = _Pr_Bol_A;
            _Txt_Hasta.Enabled = _Pr_Bol_A;
        }
        public void _Mtd_Ini()
        {
            _Str_MyProceso = "";
            _Txt_Desde.Text = "";
            _Txt_Hasta.Text = "";
            _Str_FrmIdlimitpago = "";
            _Mtd_CargarTipoProv();
            _Er_Error.Dispose();
            _Mtd_CargarUsuarios();
            _Mtd_CargarBusqueda();
            _Mtd_BotonesMenu();
            _Mtd_Bloquear(false);
        }
        public void _Mtd_BotonesMenu()
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            if (_Str_MyProceso == "A")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            if (_Str_MyProceso == "M")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            if (_Str_MyProceso == "")
            {
                if (_Cb_Usuario.SelectedIndex > 0)
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = true;
                }
                else
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                }
            }
        }
        private void _Mtd_CargarUsuarios()
        {
            _Cb_Usuario.SelectedIndexChanged -= new EventHandler(_Cb_Usuario_SelectedIndexChanged);
            _myUtilidad._Mtd_CargarCombo(_Cb_Usuario, "SELECT TUSER.cuser, TUSER.cuser + ' - ' + TCARGOSNOM.cdescripcion AS usudescrip FROM TUSER INNER JOIN TCARGOSNOM ON TUSER.cposition = TCARGOSNOM.cidcargonom WHERE TUSER.cdelete=0 ORDER BY cuser");
            _Cb_Usuario.SelectedIndexChanged += new EventHandler(_Cb_Usuario_SelectedIndexChanged);
        }
        private void _Mtd_CargarData(string _Pr_Str_Id)
        {
            //CARGO LOS MONTOS
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from TPAGOSCXPP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidlimitpago=" + _Pr_Str_Id + "");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_FrmIdlimitpago = _Pr_Str_Id;
                _Mtd_CargarUsuarios();
                _Mtd_CargarTipoProv();
                _Cb_Usuario.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cusuariop"]);
                _Cmb_TipoProv.SelectedValue = _Ds.Tables[0].Rows[0]["ctipoproveedor"].ToString().Trim();
                _Txt_Desde.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontlimited"]).ToString("#,##0.00");
                _Txt_Hasta.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontlimiteh"]).ToString("#,##0.00");
            }
        }
        private void _Mtd_CargarData2(string _P_Str_Usuario,string _P_Str_Tipo)
        {
            if (_Cmb_TipoProv.Enabled)
            {
                //CARGO LOS MONTOS
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cidlimitpago,cmontlimited,cmontlimiteh from TPAGOSCXPP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cusuariop='" + _P_Str_Usuario + "' AND ctipoproveedor='" + _P_Str_Tipo + "'");
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_FrmIdlimitpago = Convert.ToString(_Ds.Tables[0].Rows[0]["cidlimitpago"]);
                    _Txt_Desde.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontlimited"]).ToString("#,##0.00");
                    _Txt_Hasta.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontlimiteh"]).ToString("#,##0.00");
                    CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                    _Str_MyProceso = "M";                    
                }
                else
                { CONTROLES._Ctrl_Buscar._Bl_Modifi = false; _Str_MyProceso = "A"; }
            }
        }
        public void _Mtd_Habilitar()
        {
            _Mtd_Bloquear(true);
            _Cb_Usuario.Enabled = false;
            _Str_FrmTpoProvEdit = Convert.ToString(_Cmb_TipoProv.SelectedValue);
            _Tb_Tab.SelectedIndex = 1;
            _Str_MyProceso = "M";
        }
        public bool _Mtd_Guardar()
        {
            bool _Bol_Val = false, _Bol_R= false;
            string _Str_Sql = "";
            string _Str_IdTrans = "";
            string _Str_TpoProv = "";
            _Er_Error.Dispose();
            if (_Str_MyProceso == "A")
            {
                if (_Txt_Desde.Text.Trim() == "")
                {
                    _Er_Error.SetError(_Txt_Desde, "Ingrese el límite inferior.");
                    _Bol_Val = true;
                }
                if (_Txt_Hasta.Text.Trim() == "")
                {
                    _Er_Error.SetError(_Txt_Hasta, "Ingrese el límite superior.");
                    _Bol_Val = true;
                }
                if (_Cmb_TipoProv.SelectedIndex <= 0)
                {
                    _Er_Error.SetError(_Cmb_TipoProv, "Información requerida!!!");
                    _Bol_Val = true;
                }
                else
                {
                    _Str_TpoProv = Convert.ToString(_Cmb_TipoProv.SelectedValue);
                }
                if (_Cb_Usuario.SelectedIndex < 1)
                {
                    _Er_Error.SetError(_Cb_Usuario, "Seleccione un Usuario.");
                    _Bol_Val = true;
                }
                else
                {
                    if (_Mtd_ValidarUsuario(_Cb_Usuario.SelectedValue.ToString(), _Str_TpoProv))
                    {
                        MessageBox.Show("El usuario " + _Cb_Usuario.SelectedValue.ToString() + " ya tiene esta configuración.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _Bol_Val = true;
                    }
                }
                if (_Mtd_ValidarRangos())
                {
                    _Er_Error.SetError(_Txt_Desde, "Información requerida!!!");
                    _Er_Error.SetError(_Txt_Hasta, "Información requerida!!!");
                    _Txt_Desde.Focus();
                    _Bol_Val = true;
                }
                

                if (!_Bol_Val)
                {
                    try
                    {
                        _Str_Sql = "Select Max(cidlimitpago) FROM TPAGOSCXPP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                        _Str_IdTrans = _myUtilidad._Mtd_Correlativo(_Str_Sql);
                        _Str_Sql = "INSERT INTO TPAGOSCXPP (cgroupcomp,ccompany,cidlimitpago,cmontlimited,cmontlimiteh,cusuariop,ctipoproveedor) VALUES('";
                        _Str_Sql = _Str_Sql + Frm_Padre._Str_GroupComp + "','" + Frm_Padre._Str_Comp + "','" + _Str_IdTrans + "','" + _Txt_Desde.Text.Replace(".", "").Replace(",", ".") + "','" + _Txt_Hasta.Text.Replace(".", "").Replace(",", ".") + "','" + _Cb_Usuario.SelectedValue.ToString() + "'," + _Str_TpoProv + ")";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        _Mtd_Ini();
                        MessageBox.Show("Se guardó correctamente la transacción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Mtd_BotonesMenu();
                        _Bol_R = true;
                        _Mtd_CargarBusqueda();
                        _Tb_Tab.SelectTab(0);
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
            _Er_Error.Dispose();
            if (_Str_MyProceso == "M")
            {
                if (_Txt_Desde.Text.Trim() == "")
                {
                    _Er_Error.SetError(_Txt_Desde, "Ingrese el límite inferior.");
                    _Bol_Val = true;
                }
                if (_Txt_Hasta.Text.Trim() == "")
                {
                    _Er_Error.SetError(_Txt_Hasta, "Ingrese el límite superior.");
                    _Bol_Val = true;
                }
                if (_Cmb_TipoProv.SelectedIndex <= 0)
                {
                    _Er_Error.SetError(_Cmb_TipoProv, "Información requerida!!!");
                    _Bol_Val = true;
                }
                else
                {
                    _Str_TpoProv = Convert.ToString(_Cmb_TipoProv.SelectedValue);
                }
                if (_Cb_Usuario.SelectedIndex < 1)
                {
                    _Er_Error.SetError(_Cb_Usuario, "Seleccione un Usuario.");
                    _Bol_Val = true;
                }
                if (_Mtd_ValidarRangos())
                {
                    _Er_Error.SetError(_Txt_Desde, "Información requerida!!!");
                    _Er_Error.SetError(_Txt_Hasta, "Información requerida!!!");
                    _Txt_Desde.Focus();
                    _Bol_Val = true;
                }
                if (!_Bol_Val)
                {
                    try
                    {
                        _Str_Sql = "UPDATE TPAGOSCXPP SET cmontlimited=" + Convert.ToDouble(_Txt_Desde.Text) + ",cmontlimiteh=" + Convert.ToDouble(_Txt_Hasta.Text) + ",ctipoproveedor='"+_Str_TpoProv+"' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidlimitpago=" + _Str_FrmIdlimitpago + "";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        _Mtd_Ini();
                        _Mtd_CargarBusqueda();
                        MessageBox.Show("Se guardó correctamente la transacción.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Tb_Tab.SelectTab(0);
                        _Bol_R = true;
                    }
                    catch
                    { _Bol_R = false; }
                }
            }

            return _Bol_R;
        }
        public bool _Mtd_Eliminar()
        {
            bool _Bol_R = false;
            string _Str_Sql = "";
            if (MessageBox.Show("Está seguro de Elminar esta Configuración?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Str_Sql = "DELETE FROM TPAGOSCXPP WHERE cgroupcomp=" + Frm_Padre._Str_GroupComp + " AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidlimitpago=" + _Str_FrmIdlimitpago;
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                MessageBox.Show("Transacción Eliminada Correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Ini();
                _Mtd_CargarBusqueda();
                _Tb_Tab.SelectedIndex = 0;
                _Bol_R = true;
            }
            return _Bol_R;
        }
        public void _Mtd_Nuevo()
        {
            _Mtd_Ini();
            _Mtd_Bloquear(true);
            _Cmb_TipoProv.Enabled = false;
            _Txt_Desde.Enabled = false;
            _Txt_Hasta.Enabled = false;
            _Mtd_CargarUsuarios();
            _Tb_Tab.SelectedIndex = 1;
            _Txt_Desde.Focus();
            _Str_MyProceso = "A";
            _Mtd_BotonesMenu();
        }
        private bool _Mtd_ValidarRangos()
        {
            bool _Bol_R = false;
            double _Dbl_LimInf = 0, _Dbl_LimSup = 0;
            if (_Txt_Desde.Text != "")
            {
                _Dbl_LimInf = Convert.ToDouble(_Txt_Desde.Text);
            }
            if (_Txt_Hasta.Text != "")
            {
                _Dbl_LimSup = Convert.ToDouble(_Txt_Hasta.Text);
            }
            if (_Dbl_LimInf == _Dbl_LimSup || _Dbl_LimInf > _Dbl_LimSup)
            {
                _Bol_R = true;
            }
            return _Bol_R;
        }
        private bool _Mtd_ValidarUsuario(string _Pr_Str_User, string _Pr_Str_TpoProvedor)
        {
            bool _Bol_R = false;
            string _Str_Sql = "SELECT * FROM TPAGOSCXPP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cusuariop='" + _Pr_Str_User + "' AND ctipoproveedor='" + _Pr_Str_TpoProvedor + "'";
            _Bol_R = Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql);
            return _Bol_R;
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
        private void _Cb_Usuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cb_Usuario.SelectedIndex > 0)
            { _Mtd_CargarTipoProv(); _Cmb_TipoProv.Enabled = _Cb_Usuario.Enabled; }
            else
            { _Mtd_CargarTipoProv(); _Cmb_TipoProv.Enabled = false; }
        }

        private void Frm_ParLimPago_Activated(object sender, EventArgs e)
        {
            _Mtd_BotonesMenu();
        }

        private void _Dg_Find_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Find.RowCount >= 0)
            {
                _Str_MyProceso = "";
                Cursor = Cursors.WaitCursor;
                _Mtd_Ini();
                _Mtd_CargarData(Convert.ToString(_Dg_Find[0, e.RowIndex].Value));
                _Mtd_BotonesMenu();
                Cursor = Cursors.Default;
                _Tb_Tab.SelectedIndex = 1;
            }
        }

        private void _Rb_FMatPrim_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_FMatPrim.Checked)
            {
                _Mtd_CargarBusqueda();
            }
        }

        private void _Rb_FServicio_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_FServicio.Checked)
            {
                _Mtd_CargarBusqueda();
            }
        }

        private void _Rb_FOtros_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_FOtros.Checked)
            {
                _Mtd_CargarBusqueda();
            }
        }

        private void Frm_ParLimPago_Load(object sender, EventArgs e)
        {
            _Mtd_Ini();
            _Mtd_Color_Estandar(this);
        }

        private void _Txt_Desde_KeyPress(object sender, KeyPressEventArgs e)
        {
            _myUtilidad._Mtd_Valida_Numeros(_Txt_Desde, e, 13, 2);
        }

        private void _Txt_Desde_Enter(object sender, EventArgs e)
        {
            if (_Txt_Desde.Text != "")
            { _Txt_Desde.Text = _Txt_Desde.Text.Replace(".", ""); }
        }

        private void _Txt_Desde_Leave(object sender, EventArgs e)
        {
            if (_Txt_Desde.Text != "")
            { _Txt_Desde.Text = Convert.ToDouble(_Txt_Desde.Text).ToString("#,##0.00"); }
        }

        private void _Txt_Hasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            _myUtilidad._Mtd_Valida_Numeros(_Txt_Hasta, e, 13, 2);
        }

        private void _Txt_Hasta_Enter(object sender, EventArgs e)
        {
            if (_Txt_Hasta.Text != "")
            { _Txt_Hasta.Text = _Txt_Hasta.Text.Replace(".", ""); }
        }

        private void _Txt_Hasta_Leave(object sender, EventArgs e)
        {
            if (_Txt_Hasta.Text != "")
            { _Txt_Hasta.Text = Convert.ToDouble(_Txt_Hasta.Text).ToString("#,##0.00"); }
        }

        private void _Dg_Find_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
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

        private void _Bt_Actualiza_Click(object sender, EventArgs e)
        {
            _Mtd_CargarBusqueda();
        }

        private void Frm_ParLimPago_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_Cb_Usuario.Enabled & _Cb_Usuario.SelectedIndex <= 0 & e.TabPageIndex == 1)
            { e.Cancel = true; }
        }

        private void _Cmb_TipoProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Txt_Desde.Text = "";
            _Txt_Hasta.Text = "";
            if (_Cmb_TipoProv.SelectedIndex > 0)
            {
                _Mtd_CargarData2(Convert.ToString(_Cb_Usuario.SelectedValue), Convert.ToString(_Cmb_TipoProv.SelectedValue));
                _Txt_Desde.Enabled = _Cmb_TipoProv.Enabled; _Txt_Hasta.Enabled = _Cmb_TipoProv.Enabled; _Txt_Desde.Focus();
            }
            else
            { _Txt_Desde.Enabled = false; _Txt_Hasta.Enabled = false; }
        }
    }
}