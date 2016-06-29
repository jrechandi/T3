using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using T3.Clases;

namespace T3
{
    public partial class Frm_ConciliacionBancariaSaldoInicial : Form
    {
        enum _G_TiposEstadoFormulario
        {
            Consultando = 0,
            Agregando,
            Modificando
        }

        private _G_TiposEstadoFormulario _G_EstadoFormulario = _G_TiposEstadoFormulario.Consultando;
        private string _G_Str_cidconciliacionsaldoinicial = "";

        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_ConciliacionBancariaSaldoInicial()
        {
            InitializeComponent();
        }

        private void Frm_ConciliacionBancariaSaldoInicial_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Mtd_Color_Estandar(_Tb_Tab);
            _Mtd_Actualizar();
            _Mtd_HabilitarControles(false);
            _G_EstadoFormulario = _G_TiposEstadoFormulario.Consultando;
            _Mtd_CargarBanco(_Cmb_Banco, false);
            Cursor = Cursors.Default;
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
        private void _Mtd_Actualizar()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Tipo Documento");
            _Tsm_Menu[2] = new ToolStripMenuItem("Impresora");
            string[] _Str_Campos = new string[3];
            _Str_Campos[0] = "cidconciliacionsaldoinicial";
            _Str_Campos[1] = "Banco";
            _Str_Campos[2] = "Cuenta";
            String _Str_Cadena = "SELECT TCONCILIACIONSALDOINICIAL.cidconciliacionsaldoinicial AS Id,TBANCO.cname AS Banco, TCUENTBANC.cnumcuenta AS Cuenta, dbo.Fnc_Formatear(TCONCILIACIONSALDOINICIAL.csaldoinicial) AS [Saldo Inicial], TCONCILIACIONSALDOINICIAL.cbanco, TCONCILIACIONSALDOINICIAL.cnumcuenta  FROM TCUENTBANC INNER JOIN TBANCO ON TCUENTBANC.ccompany = TBANCO.ccompany AND TCUENTBANC.cbanco = TBANCO.cbanco INNER JOIN  TCONCILIACIONSALDOINICIAL ON TCUENTBANC.ccompany = TCONCILIACIONSALDOINICIAL.ccompany AND   TCUENTBANC.cnumcuenta = TCONCILIACIONSALDOINICIAL.cnumcuenta WHERE (TCONCILIACIONSALDOINICIAL.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TCONCILIACIONSALDOINICIAL.cdelete = 0) ";
            _Ctrl_Busqueda1._Mtd_Inicializar(_Str_Cadena, _Str_Campos, "Configuraciones", _Tsm_Menu, _Dg_Grid, true, "", "Banco");
            //___________________________________
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.Columns[0].Visible = false;
            _Dg_Grid.Columns[4].Visible = false;
            _Dg_Grid.Columns[5].Visible = false;
            _Dg_Grid.Columns["Saldo Inicial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void _Mtd_CargarBanco(ComboBox _P_Cmb_Combo, bool _P_Bol_Consulta)
        {
            this.Cursor = Cursors.WaitCursor;
            //string _Str_Cadena = "SELECT LTRIM(RTRIM(TBANCO.cbanco)),TBANCO.cname FROM TBANCO INNER JOIN TCONFCAPBANCD ON TBANCO.ccompany=TCONFCAPBANCD.ccompany AND LTRIM(RTRIM(TBANCO.cbanco))=LTRIM(RTRIM(TCONFCAPBANCD.cbanco)) AND ISNULL(TBANCO.cdelete,0)=ISNULL(TCONFCAPBANCD.cdelete,0) WHERE TBANCO.ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(TBANCO.cdelete,0)=0";
            string _Str_Cadena = "SELECT DISTINCT LTRIM(RTRIM(TBANCO.cbanco)),TBANCO.cname FROM TBANCO INNER JOIN TCUENTBANC ON TBANCO.ccompany=TCUENTBANC.ccompany AND LTRIM(RTRIM(TBANCO.cbanco))=LTRIM(RTRIM(TCUENTBANC.cbanco)) AND ISNULL(TBANCO.cdelete,0)=ISNULL(TCUENTBANC.cdelete,0) WHERE  TBANCO.ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(TBANCO.cdelete,0)=0";
            //-----------
            if (_P_Bol_Consulta)
            { _Str_Cadena += " AND EXISTS(SELECT cbanco FROM TDISPBANC WHERE TDISPBANC.ccompany=TBANCO.ccompany AND LTRIM(RTRIM(TDISPBANC.cbanco))=LTRIM(RTRIM(TBANCO.cbanco)) AND ISNULL(TDISPBANC.cdelete,0)=0)"; }
            //-----------
            _Str_Cadena += " ORDER BY TBANCO.cname";
            _Cls_VariosMetodos._Mtd_CargarCombo(_P_Cmb_Combo, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_CargarCuentas(ComboBox _P_Cmb_Combo, string _P_Str_Banco)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT cnumcuenta,cname FROM TCUENTBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cbanco='" + _P_Str_Banco + "' and ISNULL(cdelete,0)=0";
            _Cls_VariosMetodos._Mtd_CargarCombo(_P_Cmb_Combo, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }
        private void Frm_ConciliacionBancariaSaldoInicial_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;

        }
        private void Frm_ConciliacionBancariaSaldoInicial_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }


        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                _Mtd_Ini();
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            }
            else
            { e.Cancel = true; }
        }
        public void _Mtd_Ini()
        {
            _Mtd_HabilitarControles(false);
            _G_Str_cidconciliacionsaldoinicial = "";
            //_Cmb_Banco.SelectedIndex = 0;
            //_Cmb_Cuenta.SelectedIndex = 0;
            _Txt_Saldo.Text = "";
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            _Mtd_Actualizar();
            _Tb_Tab.SelectedIndex = 0;
        }
        public void _Mtd_Nuevo()
        {
            _Mtd_CargarBanco(_Cmb_Banco, false);
            _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Tb_Tab.SelectedIndex = 1;
            _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Mtd_HabilitarControles(true);
            _G_EstadoFormulario = _G_TiposEstadoFormulario.Agregando;
            _Cmb_Banco.Focus();
            _Txt_Saldo.Text = "";
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
        }
        public void _Mtd_Habilitar()
        {
            if (_Cls_RutinasConciliacion._Mtd_ExisteConciliacionRegistrada(_Cmb_Banco.SelectedValue.ToString(), _Cmb_Cuenta.SelectedValue.ToString()))
            {
                MessageBox.Show("Ya existe una conciliación registrada para esta cuenta, no se puede modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Tb_Tab.SelectedIndex = 1;
            _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Mtd_HabilitarControles(true);
            _Cmb_Banco.Enabled = false;
            _Cmb_Cuenta.Enabled = false;
            _G_EstadoFormulario = _G_TiposEstadoFormulario.Modificando;
            _Cmb_Banco.Focus();
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
        }
        public void _Mtd_HabilitarControles(bool pActivar)
        {
            _Cmb_Banco.Enabled = pActivar;
            _Cmb_Cuenta.Enabled = pActivar;
            _Txt_Saldo.Enabled = pActivar;
        }

        public bool _Mtd_Editar()
        {
            return _Mtd_Guardar();
        }

        private void _Mtd_EliminarRegistros()
        {
            string _Str_Cadena = "";
            Cursor = Cursors.WaitCursor;
            foreach (DataGridViewRow _Dvr_Fila in _Dg_Grid.SelectedRows)
            {
                _Str_Cadena = "UPDATE TCONCILIACIONSALDOINICIAL SET cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' WHERE cidconciliacionsaldoinicial='" + Convert.ToString(_Dvr_Fila.Cells["Id"].Value).Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            Cursor = Cursors.Default;
        }

        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            double _Dbl_Saldo = 0;
            double.TryParse(_Txt_Saldo.Text.Trim(), out _Dbl_Saldo);
            if (_Cmb_Banco.SelectedIndex > 0 && _Cmb_Cuenta.SelectedIndex > 0 && _Dbl_Saldo > 0)
            {
                string _Str_Cadena = "";
                DataSet _Ds_DataSet;

                if (_G_EstadoFormulario == _G_TiposEstadoFormulario.Agregando) //Agregando
                {
                    if (_Mtd_Validar())
                    {
                        Cursor = Cursors.WaitCursor;

                        //Obtengo lo datos
                        string _cbanco = _Cmb_Banco.SelectedValue.ToString();
                        string _cnumcuenta = _Cmb_Cuenta.SelectedValue.ToString();
                        double _saldoinicial = Convert.ToDouble(_Txt_Saldo.Text);

                        _Str_Cadena = "SELECT cidconciliacionsaldoinicial FROM TCONCILIACIONSALDOINICIAL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _cbanco + "' AND cnumcuenta = '" + _cnumcuenta + "' AND ISNULL(cdelete,0)=1";
                        _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                        {
                            //Existe y estaba eliminado
                            _Str_Cadena = "UPDATE TCONCILIACIONSALDOINICIAL SET csaldoinicial='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_saldoinicial) + "',cdelete='0',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _cbanco + "' AND cnumcuenta = '" + _cnumcuenta + "'";
                        }
                        else
                        {
                            //No existe
                            _Str_Cadena = "INSERT INTO TCONCILIACIONSALDOINICIAL (ccompany,cbanco,cnumcuenta,csaldoinicial,cdateadd,cuseradd,cdelete) VALUES ('" + Frm_Padre._Str_Comp + "','" + _cbanco + "','" + _cnumcuenta + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_saldoinicial) + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                        }
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                        MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor = Cursors.Default;
                        _Er_Error.Dispose();
                        _Mtd_Actualizar();
                        _Tb_Tab.SelectedIndex = 0;
                        return false;
                    }
                }
                else if (_G_EstadoFormulario == _G_TiposEstadoFormulario.Modificando) //Modificando
                {
                    if (_Mtd_Validar())
                    {
                        //Obtengo lo datos
                        string _cbanco = _Cmb_Banco.SelectedValue.ToString();
                        string _cnumcuenta = _Cmb_Cuenta.SelectedValue.ToString();
                        double _saldoinicial = Convert.ToDouble(_Txt_Saldo.Text);

                        _Str_Cadena = "UPDATE TCONCILIACIONSALDOINICIAL SET csaldoinicial='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_saldoinicial) + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _cbanco + "' AND cnumcuenta = '" + _cnumcuenta + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                        MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor = Cursors.Default;
                        _Er_Error.Dispose();
                        _Mtd_Actualizar();
                        _Tb_Tab.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                if (_Cmb_Banco.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Banco, "Información requerida!!!"); }
                if (_Cmb_Cuenta.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Cuenta, "Información requerida!!!"); }
                if (_Dbl_Saldo == 0 & _Txt_Saldo.Enabled) { _Er_Error.SetError(_Txt_Saldo, "Información requerida!!!"); }
            }
            return false;
        }

        private bool _Mtd_Validar()
        {
            string _Str_Cadena = "";
            DataSet _Ds_DataSet;

            //Obtengo lo datos
            string _cbanco = _Cmb_Banco.SelectedValue.ToString();
            string _cnumcuenta = _Cmb_Cuenta.SelectedValue.ToString();
            double _saldoinicial = 0;
            double.TryParse(_Txt_Saldo.Text.Trim(), out _saldoinicial);

            if (_G_EstadoFormulario == _G_TiposEstadoFormulario.Agregando)
            {
                _Str_Cadena = "SELECT cidconciliacionsaldoinicial FROM TCONCILIACIONSALDOINICIAL WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _cbanco + "' AND cnumcuenta = '" + _cnumcuenta + "' AND ISNULL(cdelete,0)=0";
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("El Banco y cuenta seleccionadas ya tiene configurado un saldo incial. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            if (_saldoinicial == 0)
            {
                MessageBox.Show("Debe introducir un saldo valido. Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count == 1)
            {
                _G_EstadoFormulario = _G_TiposEstadoFormulario.Consultando;

                _Mtd_CargarBanco(_Cmb_Banco, false);
                _G_Str_cidconciliacionsaldoinicial = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Id"].Value).Trim();

                _Cmb_Banco.SelectedValue = _Dg_Grid.Rows[e.RowIndex].Cells["cbanco"].Value;
                _Cmb_Cuenta.SelectedValue = _Dg_Grid.Rows[e.RowIndex].Cells["cnumcuenta"].Value;
                _Txt_Saldo.Text = Convert.ToDouble(_Dg_Grid.Rows[e.RowIndex].Cells["Saldo Inicial"].Value).ToString("#,##0.00");
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                _Tb_Tab.SelectedIndex = 1;
                _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
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

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _Dg_Grid.SelectedRows.Count == 0;
        }


        private void _Tool_Eliminar_Click(object sender, EventArgs e)
        {
            string _Str_Cadena = "";
            bool _B_SePuedeEliminar = true;
            Cursor = Cursors.WaitCursor;
            foreach (DataGridViewRow _Dvr_Fila in _Dg_Grid.SelectedRows)
            {
                //Busco Banco y Cuenta
                _Str_Cadena = "SELECT cidconciliacionsaldoinicial,cbanco,cnumcuenta  FROM TCONCILIACIONSALDOINICIAL WHERE cidconciliacionsaldoinicial='" + Convert.ToString(_Dvr_Fila.Cells["Id"].Value).Trim() + "'";
                var _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    var _Str_Banco = _Ds_DataSet.Tables[0].Rows[0]["cbanco"].ToString();
                    var _Str_NumCuenta = _Ds_DataSet.Tables[0].Rows[0]["cnumcuenta"].ToString();
                    if (_Cls_RutinasConciliacion._Mtd_ExisteConciliacionRegistrada(_Str_Banco, _Str_NumCuenta))
                    {
                        _B_SePuedeEliminar = false;
                    }
                }
            }
            if (!_B_SePuedeEliminar)
            {
                MessageBox.Show("Ya existe una conciliación registrada para esta cuenta, no se puede eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Esta seguro de eliminar los registros seleccionados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Mtd_EliminarRegistros();
                _Mtd_Actualizar();
                MessageBox.Show("Los registros seleccionados han sido eliminados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Cmb_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Banco.SelectedIndex > 0)
            { _Mtd_CargarCuentas(_Cmb_Cuenta, Convert.ToString(_Cmb_Banco.SelectedValue).Trim()); 
              _Cmb_Cuenta.Enabled =  _G_EstadoFormulario == _G_TiposEstadoFormulario.Agregando || _G_EstadoFormulario == _G_TiposEstadoFormulario.Modificando; 
            }
            else
            { _Cmb_Cuenta.Enabled = false; _Cmb_Cuenta.DataSource = null; }

        }

        private void _Txt_Saldo_TextChanged(object sender, EventArgs e)
        {
            //if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_Saldo.Text)) { _Txt_Saldo.Text = ""; }
        }

        private void _Txt_Saldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Saldo, e, 15, 2);
        }


    }
}
