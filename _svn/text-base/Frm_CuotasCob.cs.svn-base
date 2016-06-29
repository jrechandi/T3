using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_CuotasCob : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_Variosmetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_CuotasCob()
        {
            InitializeComponent();
            _Dt_Fecha.Value = Convert.ToDateTime(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()));
        }
        private void _Mtd_Sorted()
        {
            for (int _Int_i = 0; _Int_i < _Dg_Grid.Columns.Count; _Int_i++)
            {
                _Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void _Mtd_Actualizar()
        {
            _Dg_Grid.Rows.Clear();
            object _Ob_Monto = new object();
            //-----------------------------------------------------------------------
            string _Str_Cadena = "SELECT cvendedor+' - '+cname,CASE WHEN (SELECT cuotacobra FROM TCUOTACOB WHERE TCUOTACOB.cvendedor=TVENDEDOR.cvendedor AND TCUOTACOB.ccompany=TVENDEDOR.ccompany AND canocuota='" + _Dt_Fecha.Value.Year + "' AND cmescuota='" + _Dt_Fecha.Value.Month + "') IS NULL THEN '0' ELSE (SELECT cuotacobra FROM TCUOTACOB WHERE TCUOTACOB.cvendedor=TVENDEDOR.cvendedor AND TCUOTACOB.ccompany=TVENDEDOR.ccompany AND canocuota='" + _Dt_Fecha.Value.Year + "' AND cmescuota='" + _Dt_Fecha.Value.Month + "') END AS cuotacobra,cvendedor FROM TVENDEDOR WHERE cdelete='0' AND c_activo='1' AND ccompany='" + Frm_Padre._Str_Comp + "' and c_tipo_vend='1'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Btn_VerReporte.Enabled = true;
            }
            else
            {
                _Btn_VerReporte.Enabled = false;
            }
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Ob_Monto = 0;
                if (_Row[1].ToString().Trim().Length > 0)
                { _Ob_Monto = _Row[1].ToString().Trim(); }
                _Dg_Grid.Rows.Add(new object[] { _Row[0].ToString().ToUpper().Trim(), _Ob_Monto, _Row[2].ToString().ToUpper().Trim() });
            }
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //-----------------------------------------------------------------------
            if (new DateTime(_Dt_Fecha.Value.Year, _Dt_Fecha.Value.Month, 1) >= new DateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month, 1))
            { _Dg_Grid.Columns[1].ReadOnly = false; }
            else
            { _Dg_Grid.Columns[1].ReadOnly = true; }
            //-----------------------------------------------------------------------
            if (_Cls_Variosmetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_Variosmetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_MODIF_CUOTACOB"))
            {
                if (_Dg_Grid.Columns[1].ReadOnly & _Dg_Grid.RowCount > 0)
                { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false; _Btn_Generar.Enabled = false; }
                else
                { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true; _Btn_Generar.Enabled = true; }
            }
            else
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false; _Btn_Generar.Enabled = false;
            }
            _Mtd_TotalCuotaCobranzaGrid();
        }

        public bool _Mtd_Guardar()
        {
            _Pnl_Clave.Visible = true;
            _Bol_Sw = false;
            return false;
        }
        private void _Mtd_Guardar_Cob()
        {            
            _Dg_Grid.EndEdit();
            string _Str_Cadena = "";
            DataSet _Ds;
            object _Ob_Monto = new object();
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
            {
                _Ob_Monto = _Dg_Row.Cells[1].Value;
                if (_Ob_Monto == null)
                { _Ob_Monto = 0; }
                else if (_Ob_Monto.ToString().Trim().Length == 0)
                { _Ob_Monto = 0; }
                _Str_Cadena = "SELECT * FROM TCUOTACOB WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cvendedor='" + _Dg_Row.Cells[2].Value.ToString().Trim() + "' AND canocuota='" + _Dt_Fecha.Value.Year + "' AND cmescuota='" + _Dt_Fecha.Value.Month + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                { _Str_Cadena = "UPDATE TCUOTACOB SET cuserupd='"+Frm_Padre._Str_Use+"',cdateupd= GETDATE(), cuotacobra='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_Monto)) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cvendedor='" + _Dg_Row.Cells[2].Value.ToString().Trim() + "' AND canocuota='" + _Dt_Fecha.Value.Year + "' AND cmescuota='" + _Dt_Fecha.Value.Month + "'"; }
                else
                { _Str_Cadena = "INSERT INTO TCUOTACOB (ccompany,cvendedor,canocuota,cmescuota,cuotacobra,cdetallesta,cdateadd,cuseradd) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Dg_Row.Cells[2].Value.ToString().Trim() + "','" + _Dt_Fecha.Value.Year + "','" + _Dt_Fecha.Value.Month + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Ob_Monto)) + "','0',GETDATE(),'"+Frm_Padre._Str_Use+"')"; }
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            _Mtd_TotalCuotaCobranzaGrid();
            MessageBox.Show("La operación fue realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Frm_CuotasCob_Load(object sender, EventArgs e)
        {
            _Mtd_Sorted();
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
        }
        bool _Bol_Boleano = false;
        private void _Dg_Grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!_Bol_Boleano)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
                _Bol_Boleano = true;
            }
        }

        void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_Dg_Grid.CurrentCell.ColumnIndex == 1)
            {
                _Cls_Variosmetodos._Mtd_Valida_Numeros((TextBox)sender, e, 15, 2);
            }
        }
        string _Str_Temp_Monto = "";
        private void _Dg_Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    _Str_Temp_Monto = _Dg_Grid.Rows[e.RowIndex].Cells[1].Value.ToString();
                }
            }
            _Mtd_TotalCuotaCobranzaGrid();
        }

        private void _Dg_Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (_Dg_Grid.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    if (_Dg_Grid.Rows[e.RowIndex].Cells[1].Value.ToString().Trim().Length == 0)
                    {
                        _Dg_Grid.Rows[e.RowIndex].Cells[1].Value = _Str_Temp_Monto;
                    }
                }
                else
                { _Dg_Grid.Rows[e.RowIndex].Cells[1].Value = _Str_Temp_Monto; }
            }
            _Mtd_TotalCuotaCobranzaGrid();
        }
        private void _Mtd_TotalCuotaCobranzaGrid()
        {
            try
            {
                double _Dbl_Monto = 0;
                foreach (DataGridViewRow _Dg_Row in _Dg_Grid.Rows)
                {
                    if (_Dg_Row.Cells[0].Value != null)
                    {
                        _Dbl_Monto += Convert.ToDouble(_Dg_Row.Cells[1].Value.ToString().Trim());
                    }
                }
                this._Lbl_ToTal.Text = _Dbl_Monto.ToString("#,##0.00");
            }
            catch
            {
            }
        }
        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
            Cursor = Cursors.Default;
        }

        private void _Dt_Fecha_ValueChanged(object sender, EventArgs e)
        {
            _Btn_Generar.Enabled = false;
            _Dg_Grid.Rows.Clear();
            if (this.MdiParent != null)
            { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false; }
            if (new DateTime(_Dt_Fecha.Value.Year, _Dt_Fecha.Value.Month, 1) >= new DateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month, 1))
            { _Dg_Grid.Columns[1].ReadOnly = false; }
            else
            { _Dg_Grid.Columns[1].ReadOnly = true; }
            //-----------------------------------------------------------------------
            if (_Dg_Grid.Columns[1].ReadOnly)
            {_Btn_Generar.Enabled = false; }
            else
            { _Btn_Generar.Enabled = true; }
        }

        private void Frm_CuotasCob_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        
        private void Frm_CuotasCob_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            if (_Cls_Variosmetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_Variosmetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_MODIF_CUOTACOB"))
            {
                if (!_Dg_Grid.Columns[1].ReadOnly & _Dg_Grid.RowCount > 0)
                { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true; }
                else
                { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false; }
            }
            else
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            }
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Pnl_Superior.Enabled = false;
                _Dg_Grid.Enabled = false;
                _Txt_Clave.Text = "";
                _Txt_Clave.Focus();
            }
            else
            {
                _Pnl_Superior.Enabled = true;
                _Dg_Grid.Enabled = true;
            }
        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }
        private void _Mtd_GenerarCuota()
        {
            try
            {
                Ejecutar:
                string _Str_SentenciaSQL = "SELECT * FROM VST_T3_SALDOCUOTAVENDEDOR WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CMESCUOTA='" + _Dt_Fecha.Value.Month.ToString() + "' AND CANOCUOTA='" + _Dt_Fecha.Value.Year.ToString() + "'";
                DataSet _Ds_DataSet = new DataSet();
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros("SELECT CMESCUOTA FROM TCUOTACOB WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CMESCUOTA='" + _Dt_Fecha.Value.Month.ToString() + "' AND CANOCUOTA='" + _Dt_Fecha.Value.Year.ToString() + "'"))
                    {
                        if (MessageBox.Show("Las cuotas de cobranza fueron generadas anteriormente, desea generarlas nuevamente", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            _Str_SentenciaSQL = "DELETE FROM TCUOTACOBCAL WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CMESCUOTA='" + _Dt_Fecha.Value.Month.ToString() + "' AND CANOCUOTA='" + _Dt_Fecha.Value.Year.ToString() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                            _Str_SentenciaSQL = "DELETE FROM TCUOTACOB WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CMESCUOTA='" + _Dt_Fecha.Value.Month.ToString() + "' AND CANOCUOTA='" + _Dt_Fecha.Value.Year.ToString() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                            foreach (DataRow _Dtw_Item in _Ds_DataSet.Tables[0].Rows)
                            {
                                _Str_SentenciaSQL = "INSERT INTO TCUOTACOBCAL(ccompany,canocuota,cmescuota,czona,cvendedor,ccuotabs,cfactorzona,csaldocartera,ccalculado) VALUES('" + _Dtw_Item["CCOMPANY"].ToString() + "','" + _Dtw_Item["CANOCUOTA"].ToString() + "','" + _Dtw_Item["CMESCUOTA"].ToString() + "','" + _Dtw_Item["C_ZONA"].ToString() + "','" + _Dtw_Item["CVENDEDOR"].ToString() + "'";
                                _Str_SentenciaSQL += ",'" + _Dtw_Item["CCUOTA"].ToString().Replace(",", ".") + "','" + _Dtw_Item["CFACTOR"].ToString().Replace(",", ".") + "','" + _Dtw_Item["CSALDO"].ToString().Replace(",", ".") + "','0')";
                                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
                            }
                            MessageBox.Show(this, "Se generaron correctamente las cuotas de cobranza", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        foreach (DataRow _Dtw_Item in _Ds_DataSet.Tables[0].Rows)
                        {
                            _Str_SentenciaSQL = "INSERT INTO TCUOTACOBCAL(ccompany,canocuota,cmescuota,czona,cvendedor,ccuotabs,cfactorzona,csaldocartera,ccalculado) VALUES('" + _Dtw_Item["CCOMPANY"].ToString() + "','" + _Dtw_Item["CANOCUOTA"].ToString() + "','" + _Dtw_Item["CMESCUOTA"].ToString() + "','" + _Dtw_Item["C_ZONA"].ToString() + "','" + _Dtw_Item["CVENDEDOR"].ToString() + "'";
                            _Str_SentenciaSQL += ",'" + _Dtw_Item["CCUOTA"].ToString().Replace(",", ".") + "','" + _Dtw_Item["CFACTOR"].ToString().Replace(",", ".") + "','" + _Dtw_Item["CSALDO"].ToString().Replace(",", ".") + "','0')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);                            
                        }
                        MessageBox.Show(this, "Se generaron correctamente las cuotas de cobranza", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    _Mtd_Actualizar();
                }
                else
                {
                    _Mtd_GenerarSaldos();
                    goto Ejecutar;
                }
            }
            catch
            {
            }
        }
        private void _Mtd_GenerarSaldos()
        {
            try
            {
                string _Str_SentenciaSQL = "INSERT INTO TSALDOCARTERA(CCOMPANY,CMES,CANO,CVENDEDOR,CSALDO,CDATEADD,CUSERADD,CDELETE) SELECT CCOMPANY,'" + _Dt_Fecha.Value.Month.ToString() + "','" + _Dt_Fecha.Value.Year.ToString() + "',CVENDEDOR,CSALDOSIM,GETDATE(),'SISTEMA','0' FROM VST_T3_SALDOCARTERAVEN";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SentenciaSQL);
            }
            catch
            {
            }
        }
        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Cls_Variosmetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
                {
                    this.Cursor = Cursors.WaitCursor;
                    _Pnl_Clave.Visible = false;
                    if (!_Bol_Sw)
                    {
                        _Mtd_Guardar_Cob();
                    }
                    else
                    {
                        _Mtd_GenerarCuota();
                    }
                    this.Cursor = Cursors.Default;
                }
                else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
            }
            catch(Exception _Err)
            {
                MessageBox.Show("Ha ocurrido un error de tipo " + _Err.Message.ToString() + ". Por favor enviar notificar por control de fallas el error indicado. Gracias","Información",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        bool _Bol_Sw=false;
        private void _Pnl_Superior_Paint(object sender, PaintEventArgs e)
        {

        }
        private bool _Mtd_ValidarCuotaVentas()
        {
            bool _Bol_Valido = false;
            string _Str_SentenciaSQL = "SELECT TOP 1 CMESCUOTA FROM TCUOTAVTA WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CMESCUOTA='" + _Dt_Fecha.Value.Month.ToString() + "' AND CANOCUOTA='" + _Dt_Fecha.Value.Year.ToString() + "'";
            DataSet _Ds_DataSet = new DataSet();
            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
            {
                _Bol_Valido = true;
            }            
            return _Bol_Valido;
        }
        private void _Btn_Generar_Click(object sender, EventArgs e)
        {
            if (_Mtd_ValidarCuotaVentas())
            {
                _Bol_Sw = true;
                _Pnl_Clave.Visible = true;
            }
            else
            {
                _Pnl_Clave.Visible = false;
                MessageBox.Show(this, "No existen cuotas de ventas cargadas para el mes seleccionado", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void _Btn_VerReporte_Click(object sender, EventArgs e)
        {
            Frm_Inf_ReportCalCob _Frm_Cob = new Frm_Inf_ReportCalCob(_Dt_Fecha.Value.Year.ToString(), _Dt_Fecha.Value.Month.ToString());
            _Frm_Cob.ShowDialog();
        }
    }
}