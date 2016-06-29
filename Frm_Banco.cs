using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_Banco : Form
    {
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        string _Str_MyProceso = "";

        /// <summary>
        /// Activa o desactiva la botonera de las cuentas.
        /// </summary>
        /// <param name="_P_Bol_Activar">Verdadero si desea activar la botonera.</param>
        public void _Mtd_ActivarBotones(bool _P_Bol_Activar)
        {
            _Bt_AddCuenta.Enabled = _P_Bol_Activar;
            _Bt_DelCuenta.Enabled = _P_Bol_Activar;
            _Bt_EditCuenta.Enabled = _P_Bol_Activar;
        }

        public Frm_Banco()
        {
            InitializeComponent();
        }
        
        private void Frm_Banco_Load(object sender, EventArgs e)
        {
            _Mtd_Ini();
            _Mtd_Color_Estandar(this);
        }
        private void _Mtd_Actualizar()
        {
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("CODIGO");
            _Tsm_Menu[1] = new ToolStripMenuItem("NOMBRE");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cbanco";
            _Str_Campos[1] = "cname";
            string _Str_Cadena = "Select cbanco as Código,cname as Descripción from TBANCO where cdelete='0' and ccompany='" + Frm_Padre._Str_Comp + "'";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Banco", _Tsm_Menu, _Dg_Grid, true, "", "CAST(CONVERT(varchar,LTRIM(RTRIM(cbanco))) as integer)");

        }
        private void _Mtd_Bloquear(bool _Pr_Bol_A)
        {
            _Txt_Cod.Enabled = false;
            _Dpt_Fecha.Enabled = _Pr_Bol_A;
            _Txt_Des.Enabled = _Pr_Bol_A;
            _Txt_Tlf1.Enabled = _Pr_Bol_A;
            _Txt_Tlf2.Enabled = _Pr_Bol_A;
            _Txt_In1.Enabled = _Pr_Bol_A;
            _Txt_In2.Enabled = _Pr_Bol_A;
            _Chk_Activo.Enabled = _Pr_Bol_A;
            _Bt_AddCuenta.Enabled = false;
            _Bt_EditCuenta.Enabled = false;
            _Bt_DelCuenta.Enabled = false;
        }
        public void _Mtd_Ini()
        {
            _Str_MyProceso = "";
            _Txt_Cod.Text = "";
            _Dpt_Fecha.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Txt_Des.Text = "";
            _Txt_Tlf1.Text = "";
            _Txt_Tlf2.Text = "";
            _Txt_In1.Text = "";
            _Txt_In2.Text = "";
            _Chk_Activo.Checked = false;
            _Dg_Cuentas.Rows.Clear();
            _Er_Error.Dispose();
            _Mtd_Actualizar();
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
                if (_Txt_Cod.Text.Trim().Length > 0)
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
        private void _Mtd_CargarData(string _Pr_Str_Id)
        {
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from TBANCO where ccompany='" + Frm_Padre._Str_Comp + "' and cbanco=" + _Pr_Str_Id + "");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Cod.Text = _Pr_Str_Id;
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["cdate"]).Length > 0)
                {
                    _Dpt_Fecha.Value = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cdate"]);
                }
                _Txt_Des.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cname"]).Trim();
                _Txt_Tlf1.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cphone1"]);
                _Txt_Tlf2.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cphone2"]);
                _Txt_In1.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cinfocont1"]);
                _Txt_In2.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cinfocont2"]);
                _Chk_Activo.Checked = Convert.ToBoolean(_Ds.Tables[0].Rows[0]["cactive"]);
                _Mtd_CargarCuentas();
                
            }
        }
        public void _Mtd_CargarCuentas()
        {
            object[] _Str_RowNew = new object[2];
            string _Str_Sql = "SELECT cnumcuenta,cname FROM TCUENTBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cbanco='" + _Txt_Cod.Text.Trim() + "' and cdelete=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            _Dg_Cuentas.Rows.Clear();
            foreach (DataRow _DataR in _Ds.Tables[0].Rows)
            {
                Array.Copy(_DataR.ItemArray, _Str_RowNew, _DataR.ItemArray.Length);
                _Dg_Cuentas.Rows.Add(_Str_RowNew);
            }
            _Dg_Cuentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Bt_AddCuenta.Enabled = true;
            _Bt_DelCuenta.Enabled = false;
            _Bt_EditCuenta.Enabled = false;
        }
        public void _Mtd_Habilitar()
        {
            _Mtd_Bloquear(true);
            _Tb_Tab.SelectedIndex = 1;
            _Str_MyProceso = "M";
            _Bt_AddCuenta.Enabled = true;
        }
        public bool _Mtd_Guardar()
        {
            bool _Bol_R = false;
            string _Str_Sql = "";
            string _Str_IdBanco = "";
            if (_Str_MyProceso == "A")
            {
                if (_Mtd_ValidaSave())
                {
                    try
                    {
                        _Str_Sql = "Select MAX(CONVERT(NUMERIC,cbanco)) FROM TBANCO WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                        _Str_IdBanco = _myUtilidad._Mtd_Correlativo(_Str_Sql);
                        _Str_Sql = "INSERT INTO TBANCO (ccompany,cbanco,cdate,cactive,cname,cphone1,cphone2,cinfocont1,cinfocont2,cdateadd,cuseradd,cdelete) VALUES('";
                        _Str_Sql = _Str_Sql + Frm_Padre._Str_Comp + "','" + _Str_IdBanco + "','" + _Dpt_Fecha.Value.ToShortDateString() + "','" + Convert.ToInt32(_Chk_Activo.Checked).ToString() + "','" + _Txt_Des.Text.Trim().ToUpper() + "','" + _Txt_Tlf1.Text.Trim() + "','" + _Txt_Tlf2.Text.Trim() + "','" + _Txt_In1.Text.Trim().ToUpper() + "','" + _Txt_In2.Text.Trim().ToUpper() + "',GETDATE(),'" + Frm_Padre._Str_Use + "',0)";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        MessageBox.Show("Se guardó correctamente la transacción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Mtd_Ini();
                        _Bol_R = true;
                        _Mtd_Actualizar();
                        _Tb_Tab.SelectTab(0);
                    }
                    catch
                    {
                        _Bol_R = false;
                        MessageBox.Show("Problemas al guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            return _Bol_R;
        }
        public bool _Mtd_Editar()
        {
            bool _Bol_R = false;
            string _Str_Sql = "";
            if (_Str_MyProceso == "M")
            {
                if (_Mtd_ValidaSave())
                {
                    try
                    {
                        _Str_Sql = "UPDATE TBANCO SET cdate='" + _Dpt_Fecha.Value.ToShortDateString() + "',cactive=" + Convert.ToInt32(_Chk_Activo.Checked).ToString() + ",cname='" + _Txt_Des.Text.Trim().ToUpper() + "',cphone1='" + _Txt_Tlf1.Text.Trim() + "',cphone2='" + _Txt_Tlf2.Text.Trim() + "',cinfocont1='" + _Txt_In1.Text.Trim().ToUpper() + "',cinfocont2='" + _Txt_In2.Text.Trim().ToUpper() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "',cdelete=0 WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Txt_Cod.Text + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        MessageBox.Show("Se guardó correctamente la transacción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Mtd_Ini();
                        _Bol_R = true;
                        _Mtd_Actualizar();
                        _Tb_Tab.SelectTab(0);
                    }
                    catch
                    {
                        _Bol_R = false;
                        MessageBox.Show("Problemas al guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            return _Bol_R;
        }
        private bool _Mtd_ValidaSave()
        {
            bool _Bol_R = true;
            if (_Txt_Des.Text.Trim().Length == 0)
            {
                _Er_Error.SetError(_Txt_Des, "Información requerida.");
                _Bol_R = false;
            }
            if (_Txt_Tlf1.Text.Length == 0)
            {
                _Er_Error.SetError(_Txt_Tlf1, "Información requerida.");
                _Bol_R = false;
            }
            if (_Txt_In1.Text.Length == 0)
            {
                _Er_Error.SetError(_Txt_In1, "Información requerida.");
                _Bol_R = false;
            }
            return _Bol_R;
        }
        public bool _Mtd_Eliminar()
        {
            bool _Bol_R = false;
            string _Str_Sql = "";
            if (MessageBox.Show("Está seguro de Elminar este Banco?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Str_Sql = "UPDATE TBANCO SET cdelete=1,cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Txt_Cod.Text + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                MessageBox.Show("Transacción Eliminada Correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Ini();
                _Mtd_Actualizar();
                _Tb_Tab.SelectedIndex = 0;
                _Bol_R = true;
            }
            return _Bol_R;
        }
        public void _Mtd_Nuevo()
        {
            _Mtd_Ini();
            _Mtd_Bloquear(true);
            _Tb_Tab.SelectedIndex = 1;
            _Dpt_Fecha.Focus();
            _Str_MyProceso = "A";
            _Chk_Activo.Checked = true;
            _Mtd_BotonesMenu();
        }

        public void _Mtd_Sorted()
        {
            for (int _Int_i = 0; _Int_i < _Dg_Grid.Columns.Count; _Int_i++)
            {
                _Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void Frm_Banco_Activated(object sender, EventArgs e)
        {
            _Mtd_BotonesMenu();
        }
        
        private void Frm_Banco_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
            try
            {
                _Mtd_CerrarForm("Frm_CuentaBanca", ((Frm_Padre)this.MdiParent));
            }
            catch { }
        }

        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        private void _Txt_Tlf1_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (!_Mtd_IsNumeric(_Txt_Tlf1.Text))
            {
                _Txt_Tlf1.Text = "";
            }
        }

        private void _Txt_Tlf2_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_Tlf2.Text))
            {
                _Txt_Tlf2.Text = "";
            }
        }

        private void _Txt_Tlf1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Tlf2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void _Txt_Des_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
        }

        private void _Txt_In1_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.RowCount >= 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Ini();
                _Mtd_CargarData(Convert.ToString(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex)));
                _Mtd_BotonesMenu();
                Cursor = Cursors.Default;
                _Tb_Tab.SelectedIndex = 1;
            }
        }

        private void _Dg_Cuentas_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Cuentas.Rows.Count > 0)
            {
                //Frm_CuentaBanca _Frm = new Frm_CuentaBanca(_Txt_Cod.Text, Convert.ToString(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex)),this);
                Frm_CuentaBanca _Frm = new Frm_CuentaBanca(_Txt_Cod.Text, _Dg_Cuentas.SelectedRows[0].Cells[0].Value.ToString(), this);
                if (!_Mtd_AbiertoOno(_Frm, (Frm_Padre) this.MdiParent))
                {
                    _Mtd_ActivarBotones(false);
                    _Frm.MdiParent = MdiParent; 
                    _Frm._Bol_FrmSwBlock = true; 
                    _Frm.Show();
                }
                else
                { _Frm.Dispose(); }
            }
            
        }

        public bool _Mtd_AbiertoOno(Form _Frm_Formulario, Frm_Padre _Pr_Frm_Padre)
        {
            foreach (Form _Frm_Hijo in _Pr_Frm_Padre.MdiChildren)
            {
                if (_Frm_Hijo.Name == _Frm_Formulario.Name)
                {
                    _Frm_Hijo.Activate();
                    return true;
                }
            }
            return false;
        }
        public void _Mtd_CerrarForm(string _Pr_Str_Formulario, Frm_Padre _Pr_Frm_Padre)
        {
            foreach (Form _Frm_Hijo in _Pr_Frm_Padre.MdiChildren)
            {
                if (_Frm_Hijo.Name == _Pr_Str_Formulario)
                {
                    _Frm_Hijo.Close();
                }
            }
        }
        private void _Bt_AddCuenta_Click(object sender, EventArgs e)
        {
            Frm_CuentaBanca _Frm;
            if (_Dg_Cuentas.RowCount > 0)
            {
                _Frm = new Frm_CuentaBanca(_Txt_Cod.Text, Convert.ToString(_Dg_Cuentas[0, _Dg_Cuentas.CurrentCell.RowIndex].Value),this);
            }
            else
            {
                _Frm = new Frm_CuentaBanca(_Txt_Cod.Text, "", this);
            }
            if (!_Mtd_AbiertoOno(_Frm, (Frm_Padre)this.MdiParent))
            {
                _Frm.MdiParent = this.MdiParent; _Frm.Show();
                _Frm._Mtd_Nuevo();
                _Frm._Mtd_BotonesMenu();
                _Mtd_ActivarBotones(false);
            }
            else
            { _Frm.Dispose(); }
        }

        private void _Bt_EditCuenta_Click(object sender, EventArgs e)
        {
            Frm_CuentaBanca _Frm = new Frm_CuentaBanca(_Txt_Cod.Text, Convert.ToString(_Dg_Cuentas[0, _Dg_Cuentas.CurrentCell.RowIndex].Value), this);
            if (!_Mtd_AbiertoOno(_Frm, (Frm_Padre)this.MdiParent))
            {
                _Frm.MdiParent = this.MdiParent; _Frm.Show();
                _Frm._Mtd_Habilitar();
                _Frm._Mtd_BotonesMenu();
                _Mtd_ActivarBotones(false);
            }
            else
            { _Frm.Dispose(); }
        }

        private void _Dg_Cuentas_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Txt_Cod.Text.Trim().Length > 0)
            {
                _Bt_AddCuenta.Enabled = true;
                _Bt_DelCuenta.Enabled = true;
                _Bt_EditCuenta.Enabled = true;
            }
        }

        private void _Bt_DelCuenta_Click(object sender, EventArgs e)
        {
            string _Str_Sql = "";
            if (MessageBox.Show("Esta seguro de Eliminar el registro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Str_Sql = "UPDATE TCUENTBANC Set cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' where cnumcuenta='" + Convert.ToString(_Dg_Cuentas[0, _Dg_Cuentas.CurrentCell.RowIndex].Value) + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cbanco='" + _Txt_Cod.Text.Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Mtd_CargarCuentas();
                MessageBox.Show("El registro fue eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void _Dg_Cuentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_Txt_Cod.Text.Trim().Length > 0)
            {
                _Bt_AddCuenta.Enabled = true;
                _Bt_EditCuenta.Enabled = false;
                _Bt_DelCuenta.Enabled = false;
            }
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex != 0)
            {
                if (!_Txt_Des.Enabled & _Txt_Cod.Text.Trim().Length == 0)
                {
                    e.Cancel = true;
                }
                if (e.TabPageIndex == 2)
                {
                    if (_Str_MyProceso != "M" & _Txt_Cod.Text.Trim().Length == 0)
                    {
                        e.Cancel = true;
                    }
                }
            }
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
    }
}