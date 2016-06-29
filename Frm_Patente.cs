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
    public partial class Frm_Patente : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        public Frm_Patente()
        {
            InitializeComponent();
            _Mtd_Color_Estandar(this);
            _Mtd_Actualizar();
        }
        private void _Mtd_Color_Estandar(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Color_Estandar(_Ctrl);
                }
                else
                {
                    if (_Ctrl.GetType() != typeof(RadioButton))
                    { new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco(); }
                }
            }
        }
        private void _Mtd_Actualizar()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT capatenteid AS Patente,cdescripcion AS Descripción,dbo.Fnc_Formatear(cfactorpatente) AS [Factor(%)],ISNULL(cdetallada,0) AS cdetallada FROM TPATENTEM WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            if (_Rbt_PatenteSencilla.Checked)
            { _Str_Cadena += " AND cdetallada='0'"; }
            else if (_Rbt_PatenteDetallada.Checked)
            { _Str_Cadena += " AND cdetallada='1'"; }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns["Factor(%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["cdetallada"].Visible = false;
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }
        private void _Mtd_ActualizarDetalle(string _P_Str_PatenteID)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = @"SELECT TPATENTED.capatenteidd, TPATENTED.cproveedor, TPATENTED.cgrupo, TPROVEEDOR.c_nomb_abreviado, TGRUPPROM.cname, TPATENTED.cfactorpatente 
                                  FROM TPATENTED INNER JOIN TPROVEEDOR ON TPATENTED.cproveedor = TPROVEEDOR.cproveedor INNER JOIN TGRUPPROM ON TPATENTED.cgrupo = TGRUPPROM.ccodgrupop WHERE TPATENTED.ccompany='" + Frm_Padre._Str_Comp + "' AND TPATENTED.capatenteid='" + _P_Str_PatenteID + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Detalle.DataSource = _Ds.Tables[0];
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }
        private void _Mtd_Cargar_Proveedor()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT DISTINCT VST_PRODUCTOS_A.cproveedor AS cproveedor,VST_PRODUCTOS_A.c_nomb_abreviado AS c_nomb_abreviado FROM VST_PRODUCTOS_A WHERE NOT EXISTS(SELECT TFILTROREGIONALP.cproducto FROM TFILTROREGIONALP WHERE VST_PRODUCTOS_A.cproveedor=TFILTROREGIONALP.cproveedor AND VST_PRODUCTOS_A.cproducto=TFILTROREGIONALP.cproducto AND TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' AND TFILTROREGIONALP.cdelete='0') AND VST_PRODUCTOS_A.cdelete=0 AND VST_PRODUCTOS_A.companyprov='" + Frm_Padre._Str_Comp + "' ORDER BY VST_PRODUCTOS_A.c_nomb_abreviado ";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Proveedor, _Str_Cadena);
            Cursor = Cursors.Default;
        }
        private void _Mtd_SelecccionarGrupo(string _P_Str_Grupo)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT RTRIM(TGRUPPROM.ccodgrupop) AS ccodgrupop, TGRUPPROM.cname FROM TGRUPPROM WHERE RTRIM(TGRUPPROM.ccodgrupop)='" + _P_Str_Grupo + "'";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Grupo, _Str_Cadena);
            _Cmb_Grupo.SelectedValue = _P_Str_Grupo;
            Cursor = Cursors.Default;
        }
        private void _Mtd_Cargar_Grupo(string _P_Str_Proveedor)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT DISTINCT RTRIM(TGRUPPROM.ccodgrupop) AS ccodgrupop, TGRUPPROM.cname " +
            "FROM TGRUPPROM INNER JOIN " +
            "TGRUPPROD ON TGRUPPROM.ccodgrupop = TGRUPPROD.ccodgrupop AND " +
            "TGRUPPROM.cdelete = TGRUPPROD.cdelete INNER JOIN " +
            "TPRODUCTO ON TGRUPPROD.cproveedor = TPRODUCTO.cproveedor AND TGRUPPROD.ccodgrupop = TPRODUCTO.cgrupo " +
            "WHERE NOT EXISTS(SELECT TFILTROREGIONALP.cproducto FROM TFILTROREGIONALP WHERE TGRUPPROD.cproveedor=TFILTROREGIONALP.cproveedor AND TPRODUCTO.cproducto=TFILTROREGIONALP.cproducto AND TFILTROREGIONALP.ccompany='" + Frm_Padre._Str_Comp + "' AND TFILTROREGIONALP.cdelete='0') " +
            "AND (TGRUPPROD.cproveedor = '" + _P_Str_Proveedor + "') AND (TGRUPPROM.cdelete = 0) AND (TPRODUCTO.cdelete=0) AND NOT EXISTS(SELECT capatenteidd FROM TPATENTED WHERE TPATENTED.ccompany='" + Frm_Padre._Str_Comp + "' AND TPATENTED.cproveedor=TGRUPPROD.cproveedor AND TPATENTED.cgrupo=TGRUPPROD.ccodgrupop) ORDER BY TGRUPPROM.cname";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Grupo, _Str_Cadena);
            Cursor = Cursors.Default;
        }
        public void _Mtd_Ini()
        {
            _Txt_Patente.Text = "";
            _Txt_Descripcion.Text = "";
            _Num_FactorPatente.Value = 0;
            _Chk_Detallado.Checked = false;
            _Mtd_Cargar_Proveedor();
            _Cmb_Proveedor.Enabled = true;
            _Mtd_ActualizarDetalle("0");
            _Num_FactorGrupo.Value = 0;
            _Bt_Guardar.Enabled = false;
        }
        public void _Mtd_Habilitar()
        {
            _Txt_Descripcion.Enabled = true;
            _Num_FactorPatente.Enabled = !_Chk_Detallado.Checked;
            _Pnl_Detalle.Enabled = _Chk_Detallado.Checked;
        }
        private void _Mtd_DesHabilitar()
        {
            _Txt_Descripcion.Enabled = false;
            _Num_FactorPatente.Enabled = false;
            _Chk_Detallado.Enabled = false;
            _Pnl_Detalle.Enabled = false;
        }
        private string _Mtd_PatenteID()
        {
            string _Str_Cadena = "SELECT ISNULL(MAX(capatenteid),0)+1 FROM TPATENTEM WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim();
        }
        private string _Mtd_PatenteDetalleID(string _P_Str_PatenteID)
        {
            string _Str_Cadena = "SELECT ISNULL(MAX(capatenteidd),0)+1 FROM TPATENTED WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND capatenteid='" + _P_Str_PatenteID + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim();
        }
        private string _Mtd_GuadarEditarMaestra()
        {
            string _Str_PatenteID = _Txt_Patente.Text.Trim();
            if (_Str_PatenteID.Trim().Length == 0)
            {
                _Str_PatenteID = _Mtd_PatenteID();
                string _Str_Cadena = "INSERT INTO TPATENTEM (ccompany,capatenteid,cdescripcion,cfactorpatente,cdetallada) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_PatenteID + "','" + _Txt_Descripcion.Text.Trim() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Num_FactorPatente.Value)) + "','" + Convert.ToInt32(_Chk_Detallado.Checked) + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Txt_Patente.Text = _Str_PatenteID;
            }
            else
            {
                string _Str_Cadena = "UPDATE TPATENTEM SET cdescripcion='" + _Txt_Descripcion.Text.Trim() + "',cfactorpatente='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Num_FactorPatente.Value)) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND capatenteid='" + _Str_PatenteID + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = _Mtd_EnabledNuevo();
            return _Str_PatenteID;
        }
        private void _Mtd_GuadarEditarDetalle()
        {
            string _Str_PatenteID = _Txt_Patente.Text.Trim();
            if (_Str_PatenteID.Trim().Length == 0)
            { _Str_PatenteID = _Mtd_GuadarEditarMaestra(); }
            string _Str_Cadena = "SELECT capatenteidd FROM TPATENTED WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND capatenteid='" + _Str_PatenteID + "' AND cproveedor='" + Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim() + "' AND cgrupo='" + Convert.ToString(_Cmb_Grupo.SelectedValue).Trim() + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                string _Str_PatenteDetalleID = _Mtd_PatenteDetalleID(_Str_PatenteID);
                _Str_Cadena = "INSERT INTO TPATENTED (ccompany,capatenteid,capatenteidd,cproveedor,cgrupo,cfactorpatente) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_PatenteID + "','" + _Str_PatenteDetalleID + "','" + Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim() + "','" + Convert.ToString(_Cmb_Grupo.SelectedValue).Trim() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Num_FactorGrupo.Value)) + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            else 
            {
                string _Str_PatenteDetalleID = _Ds.Tables[0].Rows[0][0].ToString().Trim();
                _Str_Cadena = "UPDATE TPATENTED SET cfactorpatente='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Num_FactorGrupo.Value)) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND capatenteid='" + _Str_PatenteID + "' AND capatenteidd='" + _Str_PatenteDetalleID + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
        }
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            if (_Txt_Descripcion.Text.Trim().Length > 0)
            {
                _Mtd_GuadarEditarMaestra();
                MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Tb_Tab.SelectedIndex = 0;
            }
            else
            {
                _Er_Error.SetError(_Txt_Descripcion, "Información requerida");
                return false;
            }
            return true;
        }
        public bool _Mtd_Editar()
        {
            return _Mtd_Guardar();
        }
        public void _Mtd_Nuevo()
        {
            _Mtd_Ini();
            _Mtd_DesHabilitar();
            _Txt_Descripcion.Enabled = true;
            if (_Mtd_CatidadPatentes() == 0)
            { _Chk_Detallado.Enabled = true; _Num_FactorPatente.Enabled = true; }
            else
            {
                _Chk_Detallado.Enabled = false;
                _Chk_Detallado.Checked = _Mtd_ExistePatenteSencilla();
                _Num_FactorPatente.Enabled = !_Chk_Detallado.Checked;
            }
            _Tb_Tab.SelectedIndex = 1;
            _Txt_Descripcion.Focus();
        }
        private int _Mtd_CatidadPatentes()
        {
            string _Str_Cadena = "SELECT capatenteid FROM TPATENTEM WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count;
        }
        private bool _Mtd_ExistePatenteSencilla()
        {
            string _Str_Cadena = "SELECT capatenteid FROM TPATENTEM WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(cdetallada,0)='0'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_EnabledNuevo()
        {
            if (((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled)
            {
                return _Mtd_CatidadPatentes() < 2;
            }
            return false;
        }
        private void _Mtd_EliminarDetalles()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "DELETE FROM TPATENTED WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND capatenteid='" + _Txt_Patente.Text.Trim() + "'";
            foreach (DataGridViewRow _Dg_Row in _Dg_Detalle.SelectedRows)
            {
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena + " AND capatenteidd='" + Convert.ToString(_Dg_Row.Cells["capatenteidd"].Value).Trim() + "'");
            }
            Cursor = Cursors.Default;
            _Mtd_ActualizarDetalle(_Txt_Patente.Text.Trim());
        }
        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
        }

        private void FrmPatente_Load(object sender, EventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Inyeccion_Sql(this);
        }

        private void Frm_Patente_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = _Mtd_EnabledNuevo();
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _Txt_Descripcion.Enabled;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            { e.Cancel = !_Txt_Descripcion.Enabled; }
            else
            {
                if (_Rbt_Todas.Checked)
                { _Mtd_Actualizar(); }
                else
                { _Rbt_Todas.Checked = true; }
                _Mtd_Ini();
                _Mtd_DesHabilitar();
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            }
        }

        private void Frm_Patente_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Cmb_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                _Mtd_Cargar_Grupo(Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim()); 
                _Cmb_Grupo.Enabled = true;
            }
            else
            {
                _Cmb_Grupo.DataSource = null; 
                _Cmb_Grupo.Enabled = false;
                _Num_FactorGrupo.Enabled = false;
                _Num_FactorGrupo.Value = 0;
                _Bt_Guardar.Enabled = false;
            }
        }

        private void _Cmb_Grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Num_FactorGrupo.Enabled = _Cmb_Grupo.SelectedIndex > 0;
            _Num_FactorGrupo.Value = 0;
            _Bt_Guardar.Enabled = _Cmb_Grupo.SelectedIndex > 0;
        }

        private void _Txt_Descripcion_TextChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            _Pnl_Detalle.Enabled = _Chk_Detallado.Checked && _Txt_Descripcion.Text.Trim().Length > 0;
        }

        private void _Chk_Detallado_CheckedChanged(object sender, EventArgs e)
        {
            _Pnl_Detalle.Enabled = _Chk_Detallado.Checked;
            _Num_FactorPatente.Enabled = !_Chk_Detallado.Checked;
            _Num_FactorPatente.Value = 0;
            _Mtd_Cargar_Proveedor();
            _Pnl_Detalle.Enabled = _Chk_Detallado.Checked && _Txt_Descripcion.Text.Trim().Length > 0;
            if (_Chk_Detallado.Checked & _Txt_Descripcion.Text.Trim().Length == 0)
            {
                _Er_Error.SetError(_Txt_Descripcion, "Información requerida!!!");
            }
        }

        private void _Rbt_Filtro_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            { _Mtd_Actualizar(); }
        }

        private void _Cmb_Proveedor_DropDown(object sender, EventArgs e)
        {
            _Mtd_Cargar_Proveedor();
        }

        private void _Cmb_Grupo_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                _Mtd_Cargar_Grupo(Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim());
            }
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Mtd_Cargar_Proveedor();
            _Cmb_Proveedor.Enabled = true;
            _Cmb_Proveedor.Focus();
        }

        private void _Bt_Guardar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Num_FactorGrupo.Value > 0)
            {
                _Mtd_GuadarEditarDetalle();
                _Mtd_ActualizarDetalle(_Txt_Patente.Text.Trim());
                _Bt_Cancelar.PerformClick();
            }
            else
            { _Er_Error.SetError(_Num_FactorGrupo, "Información requerida!!!"); }
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count == 1)
            {
                _Txt_Patente.Text = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Patente"].Value).Trim();
                _Txt_Descripcion.Text = Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Descripción"].Value).Trim();
                _Num_FactorPatente.Value = Convert.ToDecimal(Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["Factor(%)"].Value).Trim());
                _Chk_Detallado.Checked = Convert.ToBoolean(Convert.ToInt32(Convert.ToString(_Dg_Grid.Rows[e.RowIndex].Cells["cdetallada"].Value).Trim()));
                _Mtd_ActualizarDetalle(_Txt_Patente.Text.Trim());
                _Mtd_DesHabilitar();
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = true;
                _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
                _Tb_Tab.SelectedIndex = 1;
                _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            }
        }

        private void _Dg_Detalle_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Detalle.SelectedRows.Count == 1 & _Pnl_Detalle.Enabled)
            {
                _Bt_Cancelar.PerformClick();
                _Cmb_Proveedor.Enabled = false;
                _Cmb_Grupo.Enabled = false;
                _Num_FactorGrupo.Enabled = true;
                _Bt_Guardar.Enabled = true;
                _Cmb_Proveedor.SelectedIndexChanged -= new EventHandler(_Cmb_Proveedor_SelectedIndexChanged);
                _Cmb_Proveedor.SelectedValue = Convert.ToString(_Dg_Detalle.Rows[e.RowIndex].Cells["cproveedor"].Value).Trim();
                _Cmb_Proveedor.SelectedIndexChanged += new EventHandler(_Cmb_Proveedor_SelectedIndexChanged);
                _Cmb_Grupo.SelectedIndexChanged -= new EventHandler(_Cmb_Grupo_SelectedIndexChanged);
                _Mtd_SelecccionarGrupo(Convert.ToString(_Dg_Detalle.Rows[e.RowIndex].Cells["cgrupo"].Value).Trim());
                _Cmb_Grupo.SelectedIndexChanged += new EventHandler(_Cmb_Grupo_SelectedIndexChanged);
                _Num_FactorGrupo.Value = Convert.ToDecimal(Convert.ToString(_Dg_Detalle.Rows[e.RowIndex].Cells["cfactorpatente"].Value).Trim());
                _Num_FactorGrupo.Focus();
            }
        }

        private void _Dg_Detalle_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1 & _Pnl_Detalle.Enabled)
            {
                _Lbl_DetalleInfo.Visible = true;
            }
            else
            {
                _Lbl_DetalleInfo.Visible = false;
            }
        }

        private void _Dg_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_MaestraInfo.Visible = true;
            }
            else
            {
                _Lbl_MaestraInfo.Visible = false;
            }
        }

        private void _Cntx_Eliminar_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = !_Pnl_Detalle.Enabled;
        }

        private void _Tol_Eliminar_Click(object sender, EventArgs e)
        {
            _Mtd_EliminarDetalles();
            _Bt_Cancelar.PerformClick();
        }
    }
}
