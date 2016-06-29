using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_OperBancDExcep : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        private const string _Str_CodigoExcepcion = "Excepcion";
        private string _Str_coperbanc = "";
        private string _Str_coperbancd = "";

        public Frm_OperBancDExcep()
        {
            InitializeComponent();
            _Mtd_CargarBanco(_Cmb_Banco);
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
        private void _Mtd_CargarBanco(ComboBox _P_Cmb_Combo)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT DISTINCT LTRIM(RTRIM(TBANCO.cbanco)),TBANCO.cname FROM TBANCO INNER JOIN TCUENTBANC ON TBANCO.ccompany=TCUENTBANC.ccompany AND LTRIM(RTRIM(TBANCO.cbanco))=LTRIM(RTRIM(TCUENTBANC.cbanco)) AND ISNULL(TBANCO.cdelete,0)=ISNULL(TCUENTBANC.cdelete,0) WHERE TBANCO.ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(TBANCO.cdelete,0)=0";
            //-----------
            _Str_Cadena += " ORDER BY TBANCO.cname";
            _Cls_VariosMetodos._Mtd_CargarCombo(_P_Cmb_Combo, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_Ini()
        {
            _Mtd_CargarBanco(_Cmb_BancoD);
            _Cmb_BancoD.Enabled = false;
        }
        public void _Mtd_Nuevo()
        {
            _Str_coperbanc = "";
            _Str_coperbancd = "";
            _Mtd_CargarBanco(_Cmb_BancoD);
            _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Tb_Tab.SelectedIndex = 1;
            _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Cmb_BancoD.Enabled = true;
            _Cmb_BancoD.Focus();
        }
        public void _Mtd_Habilitar()
        {
            _Txt_CodOper.Enabled = true;
            _Txt_DesOper.Enabled = true;
            _Txt_DesOper.Focus();
        }
        private string _Mtd_RetortarNombreTipoOperacion(string _P_Str_TipoOperacion)
        {
            string _Str_Cadena = "SELECT cname FROM TOPERBANC WHERE coperbanc='" + _P_Str_TipoOperacion + "' AND ISNULL(cdelete,0)=0";
            DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
            {
                return _Ds_DataSet.Tables[0].Rows[0][0].ToString().ToUpper();
            }
            return "";
        }
        public bool _Mtd_Editar()
        {
            return _Mtd_Guardar();
        }
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            if (_Cmb_BancoD.SelectedIndex > 0 & _Txt_CodOper.Text.Trim().Length > 0 & _Txt_DesOper.Text.Trim().Length > 0)
            {
                string _Str_Cadena = "";
                DataSet _Ds_DataSet;
                if (_Cmb_BancoD.Enabled) //Guardando Nuevo Registro
                {
                    //Busco  para ver si esta activo (grupo, banco, codigo)
                    _Str_Cadena = "SELECT coperbanc FROM TOPERBANCDEXCEP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cbanco='" + Convert.ToString(_Cmb_BancoD.SelectedValue).Trim() + "' AND LTRIM(RTRIM(coperbancd))='" + _Txt_CodOper.Text.Trim().ToUpper() + "' AND ISNULL(cdelete,0)=0";
                    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds_DataSet.Tables[0].Rows.Count > 0) //Si existe activo
                    {
                        MessageBox.Show("El código que introdujo ya existe para el banco seleccionado y pertenece al tipo de operación :" + _Ds_DataSet.Tables[0].Rows[0][0].ToString().Trim() + ". Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Txt_CodOper.SelectAll();
                        _Txt_CodOper.Focus();
                    }
                    else //Si no existe activo
                    {
                        Cursor = Cursors.WaitCursor;
                        //Busco si existe borrado (grupo, banco, descripcion, codigo)
                        _Str_Cadena = "SELECT coperbancd FROM TOPERBANCDEXCEP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cbanco='" + Convert.ToString(_Cmb_BancoD.SelectedValue).Trim() + "' AND coperbanc='" + _Str_CodigoExcepcion + "' AND coperbancd='" + _Txt_CodOper.Text.Trim().ToUpper() + "' AND ISNULL(cdelete,0)=1";
                        _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds_DataSet.Tables[0].Rows.Count > 0) //Si Existe borrado
                        {
                            _Str_Cadena = "UPDATE TOPERBANCDEXCEP SET cname='" + _Txt_DesOper.Text.Trim().ToUpper() + "',cdelete='0',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cbanco='" + Convert.ToString(_Cmb_BancoD.SelectedValue).Trim() + "' AND coperbanc='" + _Str_CodigoExcepcion + "' AND coperbancd='" + _Txt_CodOper.Text.Trim().ToUpper() + "'";
                        }
                        else //Si No existe como borrado
                        {
                            _Str_Cadena = "INSERT INTO TOPERBANCDEXCEP (cgroupcomp,cbanco,coperbanc,coperbancd,cname,cdateadd,cuseradd,cdelete) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Convert.ToString(_Cmb_BancoD.SelectedValue).Trim() + "','" + _Str_CodigoExcepcion + "','" + _Txt_CodOper.Text.Trim().ToUpper() + "','" + _Txt_DesOper.Text.Trim().ToUpper() + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                        }
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor = Cursors.Default;
                        _Mtd_CargarBanco(_Cmb_Banco);
                        _Cmb_Banco.SelectedValue = Convert.ToString(_Cmb_BancoD.SelectedValue).Trim();
                        _Er_Error.Dispose();
                        _Mtd_Actualizar(Convert.ToString(_Cmb_BancoD.SelectedValue).Trim());
                        _Txt_CodOper.Text = ""; _Txt_CodOper.Enabled = _Cmb_BancoD.SelectedIndex >0;
                        _Txt_DesOper.Text = ""; _Txt_DesOper.Enabled = _Cmb_BancoD.SelectedIndex > 0;
                        _Tb_Tab.SelectedIndex = 0;
                        return false;
                    }
                }
                else//Moficando
                {
                    _Str_Cadena = "SELECT cname FROM TOPERBANCDEXCEP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cbanco='" + Convert.ToString(_Cmb_BancoD.SelectedValue).Trim() + "' AND coperbanc<>'" + _Str_CodigoExcepcion + "' AND LTRIM(RTRIM(coperbancd))='" + _Txt_CodOper.Text.Trim().ToUpper() + "' AND ISNULL(cdelete,0)=0";
                    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("El código que introdujo ya existe para el banco seleccionado y pertenece al tipo de operación :" + _Ds_DataSet.Tables[0].Rows[0][0].ToString().Trim() + ". Por favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Txt_CodOper.SelectAll();
                        _Txt_CodOper.Focus();
                    }
                    else
                    {
                        //_Str_Cadena = "UPDATE TOPERBANCDEXCEP SET coperbancd='" + _Txt_CodOper.Text.Trim().ToUpper() + "',cname='" + _Txt_DesOper.Text.Trim().ToUpper() + "',cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cbanco='" + Convert.ToString(_Cmb_BancoD.SelectedValue).Trim() + "' AND coperbanc='" + _Str_CodigoExcepcion + "'";
                        //Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                        //Elimino el Registro
                        _Str_Cadena = "DELETE FROM TOPERBANCDEXCEP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cbanco='" + Convert.ToString(_Cmb_BancoD.SelectedValue).Trim() + "' AND coperbanc='" + _Str_CodigoExcepcion + "' AND coperbancd ='" + _Txt_CodOper.Text.Trim().ToUpper() + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                        //Inserto el Nuevo
                        _Str_Cadena = "INSERT INTO TOPERBANCDEXCEP (cgroupcomp,cbanco,coperbanc,coperbancd,cname,cdateadd,cuseradd,cdelete) VALUES ('" + Frm_Padre._Str_GroupComp + "','" + Convert.ToString(_Cmb_BancoD.SelectedValue).Trim() + "','" + _Str_CodigoExcepcion + "','" + _Txt_CodOper.Text.Trim().ToUpper() + "','" + _Txt_DesOper.Text.Trim().ToUpper() + "',GETDATE(),'" + Frm_Padre._Str_Use + "','0')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                        MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor = Cursors.Default;
                        _Mtd_CargarBanco(_Cmb_Banco);
                        _Cmb_Banco.SelectedValue = Convert.ToString(_Cmb_BancoD.SelectedValue).Trim();
                        _Er_Error.Dispose();
                        _Mtd_Actualizar(Convert.ToString(_Cmb_BancoD.SelectedValue).Trim());
                        _Tb_Tab.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                if (_Cmb_BancoD.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_BancoD, "Información requerida!!!"); }
                if (_Txt_CodOper.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_CodOper, "Información requerida!!!"); }
                if (_Txt_DesOper.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_DesOper, "Información requerida!!!"); }
            }
            return false;
        }
        private void _Mtd_EliminarRegistros()
        {
            string _Str_Cadena = "";
            Cursor = Cursors.WaitCursor;
            foreach (DataGridViewRow _Dvr_Fila in _Dg_Grid.SelectedRows)
            {
                _Str_Cadena = "UPDATE TOPERBANCDEXCEP SET cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "',cdelete='1' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cbanco='" + Convert.ToString(_Dvr_Fila.Cells["cbanco"].Value).Trim() + "' AND coperbanc='" + Convert.ToString(_Dvr_Fila.Cells["coperbanc"].Value).Trim() + "'  AND coperbancd='" + Convert.ToString(_Dvr_Fila.Cells["coperbancd"].Value).Trim() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            Cursor = Cursors.Default;
        }
        private void _Mtd_Actualizar(string _P_Str_Banco)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT LTRIM(RTRIM(TOPERBANCDEXCEP.cbanco)) AS cbanco,TOPERBANCDEXCEP.coperbanc,TOPERBANCDEXCEP.coperbancd,TOPERBANCDEXCEP.cname, LTRIM(RTRIM(TOPERBANCDEXCEP.coperbanc)) AS 'Cod.Comp.',LTRIM(RTRIM(TOPERBANCDEXCEP.cname)) AS 'Tip. Oper. Banc. (del banco)',LTRIM(RTRIM(TOPERBANCDEXCEP.coperbancd)) AS 'Cod.Banc.' FROM TOPERBANCDEXCEP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cbanco='" + _P_Str_Banco + "' AND ISNULL(TOPERBANCDEXCEP.cdelete,0)=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns["cbanco"].Visible = false;
            _Dg_Grid.Columns["coperbanc"].Visible = false;
            _Dg_Grid.Columns["coperbancd"].Visible = false;
            _Dg_Grid.Columns["cname"].Visible = false;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }
        private void Frm_OperBancD_Load(object sender, EventArgs e)
        {
            _Mtd_Color_Estandar(this);
        }

        private void Frm_OperBancD_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _Cmb_BancoD.Enabled || _Txt_CodOper.Enabled;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = !_Cmb_BancoD.Enabled && _Cmb_BancoD.SelectedIndex > 0 && !((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
        }

        private void Frm_OperBancD_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Cmb_BancoD_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarBanco(_Cmb_BancoD);
        }

        private void _Cmb_BancoD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_BancoD.SelectedIndex > 0)
            {
                _Txt_CodOper.Text = ""; _Txt_CodOper.Enabled = _Cmb_BancoD.SelectedIndex > 0;
                _Txt_DesOper.Text = ""; _Txt_DesOper.Enabled = _Cmb_BancoD.SelectedIndex > 0;
            }
            else
            {
                _Txt_CodOper.Text = ""; _Txt_CodOper.Enabled = false;
                _Txt_DesOper.Text = ""; _Txt_DesOper.Enabled = false;
            }
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

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count == 1)
            {
                _Mtd_CargarBanco(_Cmb_BancoD);
                _Cmb_BancoD.SelectedIndexChanged -= new EventHandler(_Cmb_BancoD_SelectedIndexChanged);
                _Cmb_BancoD.SelectedValue = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["cbanco"].Value).Trim();
                _Cmb_BancoD.SelectedIndexChanged += new EventHandler(_Cmb_BancoD_SelectedIndexChanged);
                _Txt_CodOper.Text = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["coperbancd"].Value).Trim();
                _Txt_DesOper.Text = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["cname"].Value).Trim();
                _Str_coperbanc = "";
                _Str_coperbancd = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["coperbancd"].Value).Trim();
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
            if (MessageBox.Show("¿Esta seguro de eliminar los registros seleccionados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Mtd_EliminarRegistros();
                _Mtd_Actualizar(Convert.ToString(_Cmb_Banco.SelectedValue).Trim());
                MessageBox.Show("Los registros seleccionados han sido eliminados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Cmb_Banco.SelectedIndex > 0)
            { _Mtd_Actualizar(Convert.ToString(_Cmb_Banco.SelectedValue).Trim()); }
            else
            { _Er_Error.SetError(_Cmb_Banco, "Información requerida!!!"); }
        }

        private void _Cmb_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Dg_Grid.DataSource = null;
            if (_Cmb_Banco.SelectedIndex > 0)
            { _Er_Error.Dispose(); _Er_Error.SetError(_Bt_Consultar, "Haga click para consultar."); }
        }
    }
}
