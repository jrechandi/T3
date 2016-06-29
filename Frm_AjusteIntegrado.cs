using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_AjusteIntegrado : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");

        public List<string> ProductosSalida { get; set; }
        public List<string> ProductosEntrada { get; set; }

        int _Int_TipoNotificador = 0;
        public Frm_AjusteIntegrado(int _P_Int_TipoNotificador)
        {
            InitializeComponent();
            _Int_TipoNotificador = _P_Int_TipoNotificador;
            if (_Int_TipoNotificador > 0)
            {
                _Dtp_Desde.Enabled = false;
                _Dtp_Hasta.Enabled = false;
                _Chk_Anulados.Enabled = false;
            }
            var _Dt_Fecha = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Dtp_Desde.MaxDate = _Dt_Fecha;
            _Dtp_Desde.Value = new DateTime(_Dt_Fecha.Year, _Dt_Fecha.Month, 1);
            _Dtp_Hasta.Value = _Dt_Fecha;
            _Col_ProductoSalida.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Col_ProductoSalida.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Col_ProductoEntrada.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Col_ProductoEntrada.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Col_Cajas.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Col_Cajas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Col_Unidades.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Col_Unidades.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Col_LoteSalida.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Col_LoteSalida.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Col_LoteEntrada.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Col_LoteEntrada.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Col_PmvSalida.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Col_PmvSalida.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Col_PmvEntrada.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Col_PmvEntrada.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ProductosSalida = new List<string>();
            ProductosEntrada = new List<string>();
        }

        public void _Mtd_Nuevo()
        {
            _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Tb_Tab.SelectedIndex = 1;
            _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Mtd_InicializarFormulario();
            _Mtd_Hab_Deshab_Controles(true);
            _Dg_Detalle.ContextMenuStrip = _Cntx_Menu;
            _Dtp_Desde.Enabled = true;
            _Dtp_Hasta.Enabled = true;
            _Chk_Anulados.Enabled = true;
            _Int_TipoNotificador = 0;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
        }

        private void _Mtd_InicializarFormulario()
        {
            _Mtd_LimpiarGrid();
            _Mtd_CargarMotivos();
            _Mtd_CargarProveedores();
            _Dg_Detalle.ContextMenuStrip = null;
            _Txt_AjusteIntegrado.Text = "";
            _Txt_AjusteSalida.Text = "";
            _Txt_AjusteEntrada.Text = "";
            _Txt_NotaRecepcion.Text = "";
            _Txt_NotaEntrega.Text = "";
            _Txt_Observacion.Text = "";
            _Txt_FirmaAprobador1.Text = "";
            _Txt_FirmaAprobador2.Text = "";
            _Dtp_Fecha.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
        }

        private void _Mtd_Hab_Deshab_Controles(bool _P_Bol_Valor)
        {
            _Cmb_Proveedor.Enabled = _P_Bol_Valor;
            _Cmb_Motivo.Enabled = _P_Bol_Valor;
            _Txt_NotaRecepcion.Enabled = false;
            _Txt_NotaEntrega.Enabled = _P_Bol_Valor;
            _Txt_Observacion.Enabled = _P_Bol_Valor;
            _Bt_Agregar.Enabled = _P_Bol_Valor;
            _Bt_FirmaAprobador1.Enabled = false;
            _Bt_FirmaAprobador2.Enabled = false;
            _Bt_EliminarAprobador1.Enabled = false;
            _Bt_EliminarAprobador2.Enabled = false;
            _Bt_Imprimir.Enabled = false;
        }

        private void _Mtd_CargarProveedores()
        {
            string _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_comer FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1' AND TGRUPPROVEE.CCOMPANY='" + Frm_Padre._Str_Comp + "' AND TPROVEEDOR.cglobal='1' ORDER BY TPROVEEDOR.c_nomb_comer";
            Cursor = Cursors.WaitCursor;
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Proveedor, _Str_Cadena);
            Cursor = Cursors.Default;
        }

        private void _Mtd_CargarMotivos()
        {
            string _Str_Cadena = "SELECT cidmotivo,cdescripcion FROM TMOTIVO WHERE cajusteentr='1' OR cajustesali='1' OR ctransmme='1' ORDER BY cconcepto ASC";
            Cursor = Cursors.WaitCursor;
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Motivo, _Str_Cadena);
            Cursor = Cursors.Default;
        }

        public void _Mtd_Ini()
        {
            _Tb_Tab.SelectedIndex = 0;
        }

        private void _Mtd_LimpiarGrid()
        {
            _Dg_Detalle.Rows.Clear();
            ProductosSalida.Clear();
            ProductosEntrada.Clear();
            _Txt_TotalCostoSalida.Text = "";
            _Txt_TotalImpuestoSalida.Text = "";
            _Txt_TotalCostoEntrada.Text = "";
            _Txt_TotalImpuestoEntrada.Text = "";
        }

        private bool _Mtd_VerificarProveedorNr(string _P_Str_Proveedor, string _P_Str_Nr)
        {
            var _Str_Cadena = "SELECT cproveedor FROM TNOTARECEPD INNER JOIN TPRODUCTO ON TNOTARECEPD.cproducto=TPRODUCTO.cproducto WHERE TNOTARECEPD.ccompany='" + Frm_Padre._Str_Comp + "' AND TPRODUCTO.cproveedor='" + _P_Str_Proveedor + "' AND cidnotrecepc='" + _P_Str_Nr + "'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        private void _Mtd_AgregarRegistro(Frm_AjusteIntegradoP _P_Frm_Frm_AjusteIntegradoP)
        {
            _Dg_Detalle.Rows.Add(new object[] { 
                _P_Frm_Frm_AjusteIntegradoP.ProductoSalida, 
                _P_Frm_Frm_AjusteIntegradoP.ProductoSalidaLote,
                _P_Frm_Frm_AjusteIntegradoP.ProductoSalidaPmv,
                _P_Frm_Frm_AjusteIntegradoP.ProductoCajas,
                _P_Frm_Frm_AjusteIntegradoP.ProductoUnidades,
                _P_Frm_Frm_AjusteIntegradoP.ProductoEntrada,
                _P_Frm_Frm_AjusteIntegradoP.ProductoEntradaLote,
                _P_Frm_Frm_AjusteIntegradoP.ProductoEntradaPmv});
            //---------------
            ProductosSalida.Add(_P_Frm_Frm_AjusteIntegradoP.ProductoSalida.Trim());
            ProductosEntrada.Add(_P_Frm_Frm_AjusteIntegradoP.ProductoEntrada.Trim());
            _Mtd_CalcularTotales("_Col_ProductoSalida", "_Col_LoteSalida", true);
            _Mtd_CalcularTotales("_Col_ProductoEntrada", "_Col_LoteEntrada", false);
        }

        private void _Mtd_EditarRegistro(Frm_AjusteIntegradoP _P_Frm_Frm_AjusteIntegradoP, int _P_Int_RowIndex)
        {

            var _DgRow = _Dg_Detalle.Rows[_P_Int_RowIndex];
            _DgRow.Cells["_Col_ProductoSalida"].Value = _P_Frm_Frm_AjusteIntegradoP.ProductoSalida;
            _DgRow.Cells["_Col_LoteSalida"].Value = _P_Frm_Frm_AjusteIntegradoP.ProductoSalidaLote;
            _DgRow.Cells["_Col_PmvSalida"].Value = _P_Frm_Frm_AjusteIntegradoP.ProductoSalidaPmv;
            _DgRow.Cells["_Col_Cajas"].Value = _P_Frm_Frm_AjusteIntegradoP.ProductoCajas;
            _DgRow.Cells["_Col_Unidades"].Value = _P_Frm_Frm_AjusteIntegradoP.ProductoUnidades;
            _DgRow.Cells["_Col_ProductoEntrada"].Value = _P_Frm_Frm_AjusteIntegradoP.ProductoEntrada;
            _DgRow.Cells["_Col_LoteEntrada"].Value = _P_Frm_Frm_AjusteIntegradoP.ProductoEntradaLote;
            _DgRow.Cells["_Col_PmvEntrada"].Value = _P_Frm_Frm_AjusteIntegradoP.ProductoEntradaPmv;
            //---------------
            ProductosSalida.Add(_P_Frm_Frm_AjusteIntegradoP.ProductoSalida.Trim());
            ProductosEntrada.Add(_P_Frm_Frm_AjusteIntegradoP.ProductoEntrada.Trim());
            _Mtd_CalcularTotales("_Col_ProductoSalida", "_Col_LoteSalida", true);
            _Mtd_CalcularTotales("_Col_ProductoEntrada", "_Col_LoteEntrada", false);
        }

        private void _Mtd_EliminarRegistros()
        {
            _Dg_Detalle.SelectedRows.Cast<DataGridViewRow>().ToList().ForEach(x =>
            {
                ProductosSalida.Remove(Convert.ToString(x.Cells["_Col_ProductoSalida"].Value).Trim());
                ProductosEntrada.Remove(Convert.ToString(x.Cells["_Col_ProductoEntrada"].Value).Trim());
                _Dg_Detalle.Rows.Remove(x);
            });
            _Mtd_CalcularTotales("_Col_ProductoSalida", "_Col_LoteSalida", true);
            _Mtd_CalcularTotales("_Col_ProductoEntrada", "_Col_LoteEntrada", false);
        }

        /// <summary>
        /// Realiza el calculo que determina el total del Costo y total del Impuesto determinado
        /// por todos los registros del detalle.
        /// </summary>
        private bool _Mtd_CalcularTotales(string _P_Str_ColumnaProducto, string _P_Str_ColumnaLote, bool _P_Bol_Salida)
        {
            string _Str_Cadena = "";
            DataSet _Ds = new DataSet();
            double _Dbl_MontoTotal = 0;
            double _Dbl_ImpuestoTotal = 0;
            bool _Bol_Return = true;
            foreach (DataGridViewRow _Dg_Row in _Dg_Detalle.Rows)
            {
                double _Dbl_CostoCajas = 0;
                double _Dbl_CostoUnidades = 0;
                double _Dbl_ImpuestoCajas = 0;
                double _Dbl_ImpuestoUnidades = 0;
                double _Dbl_Impuesto = 0;
                int _Int_Cajas = 0;
                int _Int_Unidades = 0;
                double _Dbl_ccostoneto_u1 = 0;
                double _Dbl_ccostoneto_u2 = 0;
                if (Convert.ToString(_Dg_Row.Cells[0].Value).Length > 0 & Convert.ToString(_Dg_Row.Cells[4].Value).Length > 0 & (Convert.ToString(_Dg_Row.Cells[5].Value).Length > 0 | Convert.ToString(_Dg_Row.Cells[6].Value).Length > 0))
                {
                    //_Str_Cadena = "SELECT TPRODUCTO.cproveedor,TPRODUCTO.cgrupo,TPRODUCTO.csku,TPRODUCTO.csubgrupo,TPRODUCTOD.ccostonetolote AS ccostoneto_u1,TPRODUCTOd.ccostobrutolote AS ccostobruto_u1,(TPRODUCTOD.ccostonetolote / (TPRODUCTO.CCONTENIDOMA1/CASE WHEN TPRODUCTO.CCONTENIDOMA2>0 THEN TPRODUCTO.CCONTENIDOMA2 ELSE 1 END)) as ccostoneto_u2,(TPRODUCTOd.ccostobrutolote / (TPRODUCTO.CCONTENIDOMA1/CASE WHEN TPRODUCTO.CCONTENIDOMA2>0 THEN TPRODUCTO.CCONTENIDOMA2 ELSE 1 END)) AS ccostobruto_u2,TPRODUCTO.ccontenidoma1,TPRODUCTO.ccontenidoma2 FROM TPRODUCTO INNER JOIN TPRODUCTOD ON TPRODUCTOD.CPRODUCTO=TPRODUCTO.CPRODUCTO WHERE TPRODUCTO.cproducto='" + Convert.ToString(_Dg_Row.Cells[_P_Str_ColumnaProducto].Value).Trim() + "' AND TPRODUCTOD.cidproductod='" + Convert.ToString(_Dg_Row.Cells[_P_Str_ColumnaLote].Value).Trim() + "'";
                    _Str_Cadena = "SELECT TPRODUCTO.cproveedor,TPRODUCTO.cgrupo,TPRODUCTO.csku,TPRODUCTO.csubgrupo,TPRODUCTO.CCOSTONETO_U1 AS ccostoneto_u1,TPRODUCTO.CCOSTOBRUTO_U1 AS ccostobruto_u1,(TPRODUCTO.CCOSTONETO_U1 / (TPRODUCTO.CCONTENIDOMA1/CASE WHEN TPRODUCTO.CCONTENIDOMA2>0 THEN TPRODUCTO.CCONTENIDOMA2 ELSE 1 END)) as ccostoneto_u2,(TPRODUCTO.CCOSTOBRUTO_U1 / (TPRODUCTO.CCONTENIDOMA1/CASE WHEN TPRODUCTO.CCONTENIDOMA2>0 THEN TPRODUCTO.CCONTENIDOMA2 ELSE 1 END)) AS ccostobruto_u2,TPRODUCTO.ccontenidoma1,TPRODUCTO.ccontenidoma2 FROM TPRODUCTO INNER JOIN TPRODUCTOD ON TPRODUCTOD.CPRODUCTO=TPRODUCTO.CPRODUCTO WHERE TPRODUCTO.cproducto='" + Convert.ToString(_Dg_Row.Cells[_P_Str_ColumnaProducto].Value).Trim() + "' AND TPRODUCTOD.cidproductod='" + Convert.ToString(_Dg_Row.Cells[_P_Str_ColumnaLote].Value).Trim() + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        double.TryParse(_Ds.Tables[0].Rows[0]["ccostoneto_u1"].ToString(), out _Dbl_ccostoneto_u1);
                        _Dbl_ccostoneto_u2 = _Dbl_ccostoneto_u1 / (Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma1"].ToString()) / Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma2"].ToString()));
                        int.TryParse(Convert.ToString(_Dg_Row.Cells["_Col_Cajas"].Value).Trim(), out _Int_Cajas);
                        int.TryParse(Convert.ToString(_Dg_Row.Cells["_Col_Unidades"].Value).Trim(), out _Int_Unidades);
                        _Dbl_CostoCajas = _Int_Cajas * _Dbl_ccostoneto_u1;

                        double _Dbl_ContenidoUnd = 1;
                        if (Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma2"].ToString()) > 0)
                        {
                            _Dbl_ContenidoUnd = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma1"].ToString()) / Convert.ToDouble(_Ds.Tables[0].Rows[0]["ccontenidoma2"].ToString());
                        }
                        _Dbl_CostoUnidades = _Int_Unidades * (_Dbl_ccostoneto_u1 / _Dbl_ContenidoUnd);
                        _Str_Cadena = "SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax  WHERE (TPRODUCTO.cproducto = '" + _Dg_Row.Cells[0].Value.ToString().Trim() + "')";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            double.TryParse(_Ds.Tables[0].Rows[0][0].ToString(), out _Dbl_Impuesto);
                        }
                        else
                        { _Dbl_Impuesto = 0; }
                        _Dbl_ImpuestoCajas = (_Dbl_CostoCajas * _Dbl_Impuesto) / 100;
                        _Dbl_ImpuestoUnidades = (_Dbl_CostoUnidades * _Dbl_Impuesto) / 100;
                        _Dbl_MontoTotal = _Dbl_MontoTotal + (_Dbl_CostoCajas + _Dbl_CostoUnidades);
                        _Dbl_ImpuestoTotal = _Dbl_ImpuestoTotal + (Math.Round(_Dbl_ImpuestoCajas, 2) + Math.Round(_Dbl_ImpuestoUnidades, 2));
                        if (_Dbl_MontoTotal == 0)
                        { _Dg_Row.Cells[_P_Str_ColumnaProducto].Style.BackColor = Color.Khaki; _Bol_Return = false; }
                        else
                        { _Dg_Row.Cells[_P_Str_ColumnaProducto].Style.BackColor = Color.White; }
                    }
                }
            }
            if (_P_Bol_Salida)
            {
                _Txt_TotalCostoSalida.Text = _Dbl_MontoTotal.ToString("#,##0.00");
                _Txt_TotalImpuestoSalida.Text = _Dbl_ImpuestoTotal.ToString("#,##0.00");
            }
            else
            {
                _Txt_TotalCostoEntrada.Text = _Dbl_MontoTotal.ToString("#,##0.00");
                _Txt_TotalImpuestoEntrada.Text = _Dbl_ImpuestoTotal.ToString("#,##0.00");
            }
            return _Bol_Return;
        }

        public bool _Mtd_Guardar()
        {
            if (CLASES._Cls_Varios_Metodos._Mtd_Conteo_Iniciado())
            {
                MessageBox.Show("Se ha iniciado el conteo de inventario.\n No puede realizar operaciónes en este ámbito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            _Er_Error.Dispose();
            if (!string.IsNullOrEmpty(_Txt_AjusteIntegrado.Text))
            {
                MessageBox.Show("No se puede realizar la operación, ha ocurrido un error.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (_Cmb_Motivo.SelectedIndex == 0)
            {
                _Er_Error.SetError(_Cmb_Motivo, "Información requerida!");
                _Cmb_Proveedor.Focus();
                return false;
            }
            if (_Cmb_Proveedor.SelectedIndex == 0)
            {
                _Er_Error.SetError(_Cmb_Proveedor, "Información requerida!");
                _Cmb_Proveedor.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(_Txt_NotaRecepcion.Text))
            {
                _Er_Error.SetError(_Txt_NotaRecepcion, "Información requerida!");
                _Txt_NotaRecepcion.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(_Txt_NotaEntrega.Text))
            {
                _Er_Error.SetError(_Txt_NotaEntrega, "Información requerida!");
                _Txt_NotaEntrega.Focus();
                return false;
            }
            if (_Dg_Detalle.RowCount == 0)
            {
                MessageBox.Show("Debe agregar por lo menos un producto.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            Cursor = Cursors.WaitCursor;
            bool _Bol_CostoSalida = _Mtd_CalcularTotales("_Col_ProductoSalida", "_Col_LoteSalida", true);
            bool _Bol_CostoEntrada = _Mtd_CalcularTotales("_Col_ProductoEntrada", "_Col_LoteEntrada", false);
            Cursor = Cursors.Default;
            if (!_Bol_CostoSalida || !_Bol_CostoEntrada)
            {
                MessageBox.Show("No se obtuvo el costo de los productos marcados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (new Frm_Clave().ShowDialog(this) != DialogResult.OK)
                return false;
            Cursor = Cursors.WaitCursor;
            if (!_Mtd_VerificarExistencia())
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Uno o más productos no pueden ser ajustados porque las existencias no lo permiten.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_GuardarAjusteIntegrado();
                Cursor = Cursors.Default;
                MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                _Tb_Tab.SelectedIndex = 0;
                return true;
            }
            catch (Exception _Ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Error en la operación.\n" + _Ex.Message + "\nPor favor envíe un ticket adjuntando la imagen de este error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool _Mtd_VerificarExistencia()
        {
            DataSet _Ds = new DataSet();
            string _Str_Cadena = "";
            double _Int_UniMinExis = 0;
            double _Int_UniMinComp = 0;
            double _Int_UnidadesAjus = 0;
            int _Int_Cajas = 0;
            int _Int_Unidades = 0;
            bool _Bol_Retorno = true;
            foreach (DataGridViewRow _Dg_Row in _Dg_Detalle.Rows)
            {
                _Int_UniMinExis = 0;
                _Int_UniMinComp = 0;
                _Int_UnidadesAjus = 0;
                _Int_Cajas = 0;
                _Int_Unidades = 0;
                int.TryParse(Convert.ToString(_Dg_Row.Cells["_Col_Cajas"].Value), out _Int_Cajas);
                int.TryParse(Convert.ToString(_Dg_Row.Cells["_Col_Unidades"].Value), out _Int_Unidades);
                _Str_Cadena = "SELECT ISNULL(cexisrealu1,0) AS cexisrealu1,ISNULL(cexisrealu2,0) AS cexisrealu2,ISNULL(cexiscomu1,0) AS cexiscomu1,ISNULL(cexiscomu2,0) AS cexiscomu2 FROM TPRODUCTOD WHERE cproducto='" + Convert.ToString(_Dg_Row.Cells["_Col_ProductoSalida"].Value).Trim() + "' and cidproductod='" + Convert.ToString(_Dg_Row.Cells["_Col_LoteSalida"].Value).Trim() + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                _Int_UniMinExis = Convert.ToDouble(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(Convert.ToString(_Dg_Row.Cells["_Col_ProductoSalida"].Value).Trim(), Convert.ToInt32(_Ds.Tables[0].Rows[0]["cexisrealu1"].ToString()), Convert.ToInt32(_Ds.Tables[0].Rows[0]["cexisrealu2"].ToString())));
                _Int_UniMinComp = Convert.ToDouble(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(Convert.ToString(_Dg_Row.Cells["_Col_ProductoSalida"].Value).Trim(), Convert.ToInt32(_Ds.Tables[0].Rows[0]["cexiscomu1"].ToString()), Convert.ToInt32(_Ds.Tables[0].Rows[0]["cexiscomu2"].ToString())));
                _Int_UnidadesAjus = Convert.ToDouble(CLASES._Cls_Varios_Metodos._Mtd_ConvertCajasUnid(Convert.ToString(_Dg_Row.Cells["_Col_ProductoSalida"].Value).Trim(), _Int_Cajas, _Int_Unidades));
                if (_Int_UnidadesAjus > (_Int_UniMinExis - _Int_UniMinComp))
                {
                    _Bol_Retorno = false;
                    _Dg_Row.Cells["_Col_ProductoSalida"].Style.BackColor = Color.Khaki;
                }
            }
            return _Bol_Retorno;
        }

        private void _Mtd_GuardarAjusteIntegrado()
        {
            var _Str_Cadena = "INSERT INTO TAJUSTEINTEGRADO (ccompany,cnrecepcion,cnentrega,cidmotivo,cproveedor,cobservacion,ctotalcostosalida,ctotalimpuestosalida,ctotalcostoentrada,ctotalimpuestoentrada,cdateadd,cuseradd,cimpreso,canulado) VALUES (@ccompany,@cnrecepcion,@cnentrega,@cidmotivo,@cproveedor,@cobservacion,@ctotalcostosalida,@ctotalimpuestosalida,@ctotalcostoentrada,@ctotalimpuestoentrada,@cdateadd,@cuseradd,@cimpreso,@canulado) SELECT SCOPE_IDENTITY()";
            var _Sql_CnxConexion = new SqlConnection(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            var _Sql_ComInsert = new SqlCommand(_Str_Cadena, _Sql_CnxConexion);
            _Sql_ComInsert.Parameters.AddWithValue("@ccompany", Frm_Padre._Str_Comp);
            _Sql_ComInsert.Parameters.AddWithValue("@cnrecepcion", _Txt_NotaRecepcion.Text);
            _Sql_ComInsert.Parameters.AddWithValue("@cnentrega", _Txt_NotaEntrega.Text);
            _Sql_ComInsert.Parameters.AddWithValue("@cidmotivo", Convert.ToString(_Cmb_Motivo.SelectedValue).Trim());
            _Sql_ComInsert.Parameters.AddWithValue("@cproveedor", Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim());
            _Sql_ComInsert.Parameters.AddWithValue("@cobservacion", _Txt_Observacion.Text.Trim().ToUpper());
            _Sql_ComInsert.Parameters.AddWithValue("@ctotalcostosalida", CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_TotalCostoSalida.Text)));
            _Sql_ComInsert.Parameters.AddWithValue("@ctotalimpuestosalida", CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_TotalImpuestoSalida.Text)));
            _Sql_ComInsert.Parameters.AddWithValue("@ctotalcostoentrada", CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_TotalCostoEntrada.Text)));
            _Sql_ComInsert.Parameters.AddWithValue("@ctotalimpuestoentrada", CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_TotalImpuestoEntrada.Text)));
            _Sql_ComInsert.Parameters.AddWithValue("@cdateadd", CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ());
            _Sql_ComInsert.Parameters.AddWithValue("@cuseradd", Frm_Padre._Str_Use);
            _Sql_ComInsert.Parameters.AddWithValue("@cimpreso", "0");
            _Sql_ComInsert.Parameters.AddWithValue("@canulado", "0");
            _Sql_ComInsert.Connection = _Sql_CnxConexion;
            _Sql_CnxConexion.Open();
            var _Str_AjusteIntegradoId = _Sql_ComInsert.ExecuteScalar().ToString();
            _Txt_AjusteIntegrado.Text = _Str_AjusteIntegradoId;
            foreach (DataGridViewRow _Row in _Dg_Detalle.Rows)
            {
                _Str_Cadena = "INSERT INTO TAJUSTEINTEGRADOD (cidajuste,cproductosalida,clotesalida,cpmvsalida,cproductoentrada,cloteentrada,cpmventrada,ccajas,cunidades)" +
                    "VALUES ('" + _Str_AjusteIntegradoId + "','" +
                    _Row.Cells["_Col_ProductoSalida"].Value + "','" +
                    _Row.Cells["_Col_LoteSalida"].Value + "','" +
                    CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Row.Cells["_Col_PmvSalida"].Value)) + "','" +
                    _Row.Cells["_Col_ProductoEntrada"].Value + "','" +
                    _Row.Cells["_Col_LoteEntrada"].Value + "','" +
                    CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Row.Cells["_Col_PmvEntrada"].Value)) + "','" +
                    _Row.Cells["_Col_Cajas"].Value + "','" +
                    _Row.Cells["_Col_Unidades"].Value+ "')";
                Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            }
            _Mtd_GuardarAjusteSalida(_Str_AjusteIntegradoId);
            _Mtd_GuardarAjusteEntrada(_Str_AjusteIntegradoId);
        }

        private void _Mtd_GuardarAjusteSalida(string _P_Str_AjusteIntegradoId)
        {
            var _Str_Cadena = "SELECT ISNULL(MAX(cajustsal),0)+1 FROM TAJUSSALC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_AjusteSalidaId = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                _Str_Cadena = "INSERT INTO TAJUSSALC (ccompany,cajustsal,cnentrega,cname,cidmotivo,cyearacco,cmontacco,cdateajus,cdateadd,cuseradd,cdelete,cajusteintegrado)" +
                    "VALUES ('" + Frm_Padre._Str_Comp + "','" +
                    _Str_AjusteSalidaId + "','" +
                    _Txt_NotaEntrega.Text + "','" +
                    "AJUSTE DE SALIDA AL '+CONVERT(VARCHAR,GETDATE(),103)+' SEGUN LA NOTA DE ENTREGA # " + _Txt_NotaEntrega.Text + "','" +
                    Convert.ToString(_Cmb_Motivo.SelectedValue) + "','" +
                    CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year + "','" +
                    CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month + "','" +
                    _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "'," +
                    "GETDATE(),'" +
                    Frm_Padre._Str_Use + "'," +
                    "0,1)";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Txt_AjusteSalida.Text = _Str_AjusteSalidaId;
                _Str_Cadena = "INSERT INTO TAJUSSALD (ccompany,cajustsal,cproveedor,cgrupo,csubgrupo,csku,cproducto,ccostnet_u1,ccostbruto_u1,ccostnet_u2,ccostbruto_u2,cantajuse_u1,cantajuse_u2,ccosttot_u1,ccosttot_u2,cimpuesto_u1,cimpuesto_u2,cdateadd,cuseradd,cdelete,cidproductod) " +
                    "SELECT '" + Frm_Padre._Str_Comp + "','" +
                    _Str_AjusteSalidaId + "'," +
                    "TPRODUCTO.cproveedor,TPRODUCTO.cgrupo,TPRODUCTO.csubgrupo,TPRODUCTO.csku,TPRODUCTO.cproducto,TPRODUCTO.ccostoneto_u1,TPRODUCTO.ccostobruto_u1," +
                    "(TPRODUCTO.ccostoneto_u1 / (TPRODUCTO.ccontenidoma1/CASE WHEN TPRODUCTO.ccontenidoma2>0 THEN TPRODUCTO.ccontenidoma2 ELSE 1 END)) AS ccostoneto_u2," +
                    "(TPRODUCTO.ccostobruto_u1 / (TPRODUCTO.ccontenidoma1/CASE WHEN TPRODUCTO.ccontenidoma2>0 THEN TPRODUCTO.ccontenidoma2 ELSE 1 END)) AS ccostobruto_u2," +
                    "TAJUSTEINTEGRADOD.ccajas,TAJUSTEINTEGRADOD.cunidades," +
                    "(TAJUSTEINTEGRADOD.ccajas * TPRODUCTO.ccostoneto_u1) AS ccostocaja," +
                    "(TAJUSTEINTEGRADOD.cunidades * (TPRODUCTO.ccostoneto_u1 / (TPRODUCTO.ccontenidoma1/TPRODUCTO.ccontenidoma2))) AS ccostounidad," +
                    "CASE WHEN ISNULL(TTAX.cpercent,0)>0 THEN ((TAJUSTEINTEGRADOD.ccajas * TPRODUCTO.ccostoneto_u1) * TTAX.cpercent) / 100 ELSE 0 END AS cimpuestocaja," +
                    "CASE WHEN ISNULL(TTAX.cpercent,0)>0 THEN ((TAJUSTEINTEGRADOD.cunidades * (TPRODUCTO.ccostoneto_u1 / (TPRODUCTO.ccontenidoma1/TPRODUCTO.ccontenidoma2))) * TTAX.cpercent) / 100 ELSE 0 END AS cimpuestounidad," +
                    "GETDATE(),'" + Frm_Padre._Str_Use + "',0,TAJUSTEINTEGRADOD.clotesalida " +
                    "FROM TAJUSTEINTEGRADOD INNER JOIN TPRODUCTOD ON TAJUSTEINTEGRADOD.cproductosalida=TPRODUCTOD.cproducto AND TAJUSTEINTEGRADOD.clotesalida=TPRODUCTOD.cidproductod INNER JOIN TPRODUCTO ON TPRODUCTOD.cproducto=TPRODUCTO.cproducto LEFT JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax WHERE TAJUSTEINTEGRADOD.cidajuste='" + _P_Str_AjusteIntegradoId + "'";
                //_Str_Cadena = "INSERT INTO TAJUSSALD (ccompany,cajustsal,cproveedor,cgrupo,csubgrupo,csku,cproducto,ccostnet_u1,ccostbruto_u1,ccostnet_u2,ccostbruto_u2,cantajuse_u1,cantajuse_u2,ccosttot_u1,ccosttot_u2,cimpuesto_u1,cimpuesto_u2,cdateadd,cuseradd,cdelete,cidproductod) " +
                //    "SELECT '" + Frm_Padre._Str_Comp + "','" +
                //    _Str_AjusteSalidaId + "'," +
                //    "TPRODUCTO.cproveedor,TPRODUCTO.cgrupo,TPRODUCTO.csubgrupo,TPRODUCTO.csku,TPRODUCTO.cproducto,TPRODUCTOD.ccostonetolote,TPRODUCTOD.ccostobrutolote," +
                //    "(TPRODUCTOD.ccostonetolote / (TPRODUCTO.ccontenidoma1/CASE WHEN TPRODUCTO.ccontenidoma2>0 THEN TPRODUCTO.ccontenidoma2 ELSE 1 END)) AS ccostoneto_u2," +
                //    "(TPRODUCTOD.ccostobrutolote / (TPRODUCTO.ccontenidoma1/CASE WHEN TPRODUCTO.ccontenidoma2>0 THEN TPRODUCTO.ccontenidoma2 ELSE 1 END)) AS ccostobruto_u2," +
                //    "TAJUSTEINTEGRADOD.ccajas,TAJUSTEINTEGRADOD.cunidades," +
                //    "(TAJUSTEINTEGRADOD.ccajas * TPRODUCTOD.ccostonetolote) AS ccostocaja," +
                //    "(TAJUSTEINTEGRADOD.cunidades * (TPRODUCTOD.ccostonetolote / (TPRODUCTO.ccontenidoma1/TPRODUCTO.ccontenidoma2))) AS ccostounidad," +
                //    "CASE WHEN ISNULL(TTAX.cpercent,0)>0 THEN ((TAJUSTEINTEGRADOD.ccajas * TPRODUCTOD.ccostonetolote) * TTAX.cpercent) / 100 ELSE 0 END AS cimpuestocaja," +
                //    "CASE WHEN ISNULL(TTAX.cpercent,0)>0 THEN ((TAJUSTEINTEGRADOD.cunidades * (TPRODUCTOD.ccostonetolote / (TPRODUCTO.ccontenidoma1/TPRODUCTO.ccontenidoma2))) * TTAX.cpercent) / 100 ELSE 0 END AS cimpuestounidad," +
                //    "GETDATE(),'" + Frm_Padre._Str_Use + "',0,TAJUSTEINTEGRADOD.clotesalida " +
                //    "FROM TAJUSTEINTEGRADOD INNER JOIN TPRODUCTOD ON TAJUSTEINTEGRADOD.cproductosalida=TPRODUCTOD.cproducto AND TAJUSTEINTEGRADOD.clotesalida=TPRODUCTOD.cidproductod INNER JOIN TPRODUCTO ON TPRODUCTOD.cproducto=TPRODUCTO.cproducto LEFT JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax WHERE TAJUSTEINTEGRADOD.cidajuste='" + _P_Str_AjusteIntegradoId + "'";

                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "UPDATE TAJUSTEINTEGRADO SET cajustsal='" + _Str_AjusteSalidaId + "' WHERE cidajuste='" + _P_Str_AjusteIntegradoId + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "UPDATE TAJUSSALC SET ccosttotsimp=ccostocaja,cvalorimp=cimpuesto FROM TAJUSSALC INNER JOIN (SELECT ccompany,cajustsal,SUM(ISNULL(ccosttot_u1,0)+ISNULL(ccosttot_u2,0)) AS ccostocaja,SUM(ISNULL(cimpuesto_u1,0)+ISNULL(cimpuesto_u2,0)) AS cimpuesto FROM TAJUSSALD GROUP BY ccompany,cajustsal) AS TABLA ON TAJUSSALC.ccompany=TABLA.ccompany AND TAJUSSALC.cajustsal=TABLA.cajustsal " +
                               "WHERE TAJUSSALC.ccompany='" + Frm_Padre._Str_Comp + "' AND TAJUSSALC.cajustsal='" + _Str_AjusteSalidaId + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
        }

        private void _Mtd_GuardarAjusteEntrada(string _P_Str_AjusteIntegradoId)
        {
            var _Str_Cadena = "SELECT ISNULL(MAX(cajustent),0)+1 FROM TAJUSENTC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_AjusteEntradaId = Convert.ToString(_Ds.Tables[0].Rows[0][0]);
                _Str_Cadena = "INSERT INTO TAJUSENTC (ccompany,cajustent,cnrecepcion,cname,cidmotivo,cyearacco,cmontacco,cdateajus,cdateadd,cuseradd,cdelete,cajusteintegrado)" +
                    "VALUES ('" + Frm_Padre._Str_Comp + "','" +
                    _Str_AjusteEntradaId + "','" +
                    _Txt_NotaRecepcion.Text + "','" +
                    "AJUSTE DE ENTRADA AL '+CONVERT(VARCHAR,GETDATE(),103)+' SEGÚN LA NOTA DE RECEPCIÓN # " + _Txt_NotaRecepcion.Text + "','" +
                    Convert.ToString(_Cmb_Motivo.SelectedValue) + "','" +
                    CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Year + "','" +
                    CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().Month + "','" +
                    _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "'," +
                    "GETDATE(),'" +
                    Frm_Padre._Str_Use + "'," +
                    "0,1)";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Txt_AjusteEntrada.Text = _Str_AjusteEntradaId;
                _Str_Cadena = "INSERT INTO TAJUSENTD (ccompany,cajustent,cproveedor,cgrupo,csubgrupo,csku,cproducto,ccostnet_u1,ccostbruto_u1,ccostnet_u2,ccostbruto_u2,cantajuse_u1,cantajuse_u2,ccosttot_u1,ccosttot_u2,cimpuesto_u1,cimpuesto_u2,cdateadd,cuseradd,cdelete,cidproductod) " +
                    "SELECT '" + Frm_Padre._Str_Comp + "','" +
                    _Str_AjusteEntradaId + "'," +
                    "TPRODUCTO.cproveedor,TPRODUCTO.cgrupo,TPRODUCTO.csubgrupo,TPRODUCTO.csku,TPRODUCTO.cproducto,TPRODUCTO.ccostoneto_u1,TPRODUCTO.ccostobruto_u1," +
                    "(TPRODUCTO.ccostoneto_u1 / (TPRODUCTO.ccontenidoma1/CASE WHEN TPRODUCTO.ccontenidoma2>0 THEN TPRODUCTO.ccontenidoma2 ELSE 1 END)) AS ccostoneto_u2," +
                    "(TPRODUCTO.ccostobruto_u1 / (TPRODUCTO.ccontenidoma1/CASE WHEN TPRODUCTO.ccontenidoma2>0 THEN TPRODUCTO.ccontenidoma2 ELSE 1 END)) AS ccostobruto_u2," +
                    "TAJUSTEINTEGRADOD.ccajas,TAJUSTEINTEGRADOD.cunidades," +
                    "(TAJUSTEINTEGRADOD.ccajas * TPRODUCTO.ccostoneto_u1) AS ccostocaja," +
                    "(TAJUSTEINTEGRADOD.cunidades * (TPRODUCTO.ccostoneto_u1 / (TPRODUCTO.ccontenidoma1/TPRODUCTO.ccontenidoma2))) AS ccostounidad," +
                    "CASE WHEN ISNULL(TTAX.cpercent,0)>0 THEN ((TAJUSTEINTEGRADOD.ccajas * TPRODUCTO.ccostoneto_u1) * TTAX.cpercent) / 100 ELSE 0 END AS cimpuestocaja," +
                    "CASE WHEN ISNULL(TTAX.cpercent,0)>0 THEN ((TAJUSTEINTEGRADOD.cunidades * (TPRODUCTO.ccostoneto_u1 / (TPRODUCTO.ccontenidoma1/TPRODUCTO.ccontenidoma2))) * TTAX.cpercent) / 100 ELSE 0 END AS cimpuestounidad," +
                    "GETDATE(),'" + Frm_Padre._Str_Use + "',0,TAJUSTEINTEGRADOD.cloteentrada " +
                    "FROM TAJUSTEINTEGRADOD INNER JOIN TPRODUCTOD ON TAJUSTEINTEGRADOD.cproductoentrada=TPRODUCTOD.cproducto AND TAJUSTEINTEGRADOD.cloteentrada=TPRODUCTOD.cidproductod INNER JOIN TPRODUCTO ON TPRODUCTOD.cproducto=TPRODUCTO.cproducto LEFT JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax WHERE TAJUSTEINTEGRADOD.cidajuste='" + _P_Str_AjusteIntegradoId + "'";
                //_Str_Cadena = "INSERT INTO TAJUSENTD (ccompany,cajustent,cproveedor,cgrupo,csubgrupo,csku,cproducto,ccostnet_u1,ccostbruto_u1,ccostnet_u2,ccostbruto_u2,cantajuse_u1,cantajuse_u2,ccosttot_u1,ccosttot_u2,cimpuesto_u1,cimpuesto_u2,cdateadd,cuseradd,cdelete,cidproductod) " +
                //    "SELECT '" + Frm_Padre._Str_Comp + "','" +
                //    _Str_AjusteEntradaId + "'," +
                //    "TPRODUCTO.cproveedor,TPRODUCTO.cgrupo,TPRODUCTO.csubgrupo,TPRODUCTO.csku,TPRODUCTO.cproducto,TPRODUCTOD.ccostonetolote,TPRODUCTOD.ccostobrutolote," +
                //    "(TPRODUCTOD.ccostonetolote / (TPRODUCTO.ccontenidoma1/CASE WHEN TPRODUCTO.ccontenidoma2>0 THEN TPRODUCTO.ccontenidoma2 ELSE 1 END)) AS ccostoneto_u2," +
                //    "(TPRODUCTOD.ccostobrutolote / (TPRODUCTO.ccontenidoma1/CASE WHEN TPRODUCTO.ccontenidoma2>0 THEN TPRODUCTO.ccontenidoma2 ELSE 1 END)) AS ccostobruto_u2," +
                //    "TAJUSTEINTEGRADOD.ccajas,TAJUSTEINTEGRADOD.cunidades," +
                //    "(TAJUSTEINTEGRADOD.ccajas * TPRODUCTOD.ccostonetolote) AS ccostocaja," +
                //    "(TAJUSTEINTEGRADOD.cunidades * (TPRODUCTOD.ccostonetolote / (TPRODUCTO.ccontenidoma1/TPRODUCTO.ccontenidoma2))) AS ccostounidad," +
                //    "CASE WHEN ISNULL(TTAX.cpercent,0)>0 THEN ((TAJUSTEINTEGRADOD.ccajas * TPRODUCTOD.ccostonetolote) * TTAX.cpercent) / 100 ELSE 0 END AS cimpuestocaja," +
                //    "CASE WHEN ISNULL(TTAX.cpercent,0)>0 THEN ((TAJUSTEINTEGRADOD.cunidades * (TPRODUCTOD.ccostonetolote / (TPRODUCTO.ccontenidoma1/TPRODUCTO.ccontenidoma2))) * TTAX.cpercent) / 100 ELSE 0 END AS cimpuestounidad," +
                //    "GETDATE(),'" + Frm_Padre._Str_Use + "',0,TAJUSTEINTEGRADOD.cloteentrada " +
                //    "FROM TAJUSTEINTEGRADOD INNER JOIN TPRODUCTOD ON TAJUSTEINTEGRADOD.cproductoentrada=TPRODUCTOD.cproducto AND TAJUSTEINTEGRADOD.cloteentrada=TPRODUCTOD.cidproductod INNER JOIN TPRODUCTO ON TPRODUCTOD.cproducto=TPRODUCTO.cproducto LEFT JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax WHERE TAJUSTEINTEGRADOD.cidajuste='" + _P_Str_AjusteIntegradoId + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "UPDATE TAJUSTEINTEGRADO SET cajustent='" + _Str_AjusteEntradaId + "' WHERE cidajuste='" + _P_Str_AjusteIntegradoId + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "UPDATE TAJUSENTC SET ccosttotsimp=ccostocaja,cvalorimp=cimpuesto FROM TAJUSENTC INNER JOIN (SELECT ccompany,cajustent,SUM(ISNULL(ccosttot_u1,0)+ISNULL(ccosttot_u2,0)) AS ccostocaja,SUM(ISNULL(cimpuesto_u1,0)+ISNULL(cimpuesto_u2,0)) AS cimpuesto FROM TAJUSENTD GROUP BY ccompany,cajustent) AS TABLA ON TAJUSENTC.ccompany COLLATE DATABASE_DEFAULT = TABLA.ccompany AND TAJUSENTC.cajustent=TABLA.cajustent " +
                               "WHERE TAJUSENTC.ccompany='" + Frm_Padre._Str_Comp + "' AND TAJUSENTC.cajustent='" + _Str_AjusteEntradaId + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
        }

        private void _Mtd_Actualizar()
        {
            Cursor = Cursors.WaitCursor;
            var _Str_Cadena = "SELECT cidajuste AS [Ajuste Integrado],CONVERT(VARCHAR,TAJUSTEINTEGRADO.cdateadd,103) AS Fecha,c_nomb_comer AS Proveedor,cajustsal AS [Ajuste Salida],cajustent AS [Ajuste Entrada] FROM TAJUSTEINTEGRADO INNER JOIN TPROVEEDOR ON TAJUSTEINTEGRADO.cproveedor=TPROVEEDOR.cproveedor WHERE TAJUSTEINTEGRADO.ccompany='" + Frm_Padre._Str_Comp + "'";
            if (_Int_TipoNotificador == 1)
                _Str_Cadena += " AND canulado='0' AND ISNULL(cfuseraprobador1,0)=0 AND ISNULL(cfuseraprobador2,0)=0";
            else if (_Int_TipoNotificador == 2)
                _Str_Cadena += " AND canulado='0' AND cfuseraprobador1=1 AND ISNULL(cfuseraprobador2,0)=0";
            else if (_Int_TipoNotificador == 3)
                _Str_Cadena += " AND cfuseraprobador2=1 AND cimpreso=0";
            else
                _Str_Cadena += " AND CONVERT(DATETIME,CONVERT(VARCHAR,TAJUSTEINTEGRADO.cdateadd,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dtp_Desde.Value) + "' AND '" + _Cls_Formato._Mtd_fecha(_Dtp_Hasta.Value) + "' AND canulado='" + Convert.ToInt32(_Chk_Anulados.Checked) + "'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Grid.DataSource = _Ds.Tables[0];
            _Dg_Grid.Columns["Ajuste Integrado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns["Ajuste Integrado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns["Ajuste Salida"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns["Ajuste Salida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns["Ajuste Entrada"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.Columns["Ajuste Entrada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }

        private void _Mtd_CargarFormulario(string _P_Str_AjusteIntegrado)
        {
            string _Str_Cadena = "SELECT cajustsal,cajustent,cidmotivo,cproveedor,cnrecepcion,cnentrega,cobservacion,dbo.Fnc_Formatear(ctotalcostosalida) AS ctotalcostosalida,dbo.Fnc_Formatear(ctotalimpuestosalida) AS ctotalimpuestosalida,dbo.Fnc_Formatear(ctotalcostoentrada) AS ctotalcostoentrada,dbo.Fnc_Formatear(ctotalimpuestoentrada) AS ctotalimpuestoentrada,cuseraprobador1,cuseraprobador2 FROM TAJUSTEINTEGRADO WHERE cidajuste='" + _P_Str_AjusteIntegrado + "'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No se obtuvieron los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Txt_AjusteIntegrado.Text = _P_Str_AjusteIntegrado;
            _Txt_AjusteSalida.Text = _Ds.Tables[0].Rows[0]["cajustsal"].ToString();
            _Txt_AjusteEntrada.Text = _Ds.Tables[0].Rows[0]["cajustent"].ToString();
            _Cmb_Motivo.SelectedValue = _Ds.Tables[0].Rows[0]["cidmotivo"].ToString();
            _Cmb_Proveedor.SelectedValue = _Ds.Tables[0].Rows[0]["cproveedor"].ToString();
            _Txt_NotaRecepcion.Text = _Ds.Tables[0].Rows[0]["cnrecepcion"].ToString();
            _Txt_NotaEntrega.Text = _Ds.Tables[0].Rows[0]["cnentrega"].ToString();
            _Txt_Observacion.Text = _Ds.Tables[0].Rows[0]["cobservacion"].ToString();
            _Txt_TotalCostoSalida.Text = _Ds.Tables[0].Rows[0]["ctotalcostosalida"].ToString();
            _Txt_TotalImpuestoSalida.Text = _Ds.Tables[0].Rows[0]["ctotalimpuestosalida"].ToString();
            _Txt_TotalCostoEntrada.Text = _Ds.Tables[0].Rows[0]["ctotalcostoentrada"].ToString();
            _Txt_TotalImpuestoEntrada.Text = _Ds.Tables[0].Rows[0]["ctotalimpuestoentrada"].ToString();
            _Txt_FirmaAprobador1.Text = _Ds.Tables[0].Rows[0]["cuseraprobador1"].ToString();
            _Txt_FirmaAprobador2.Text = _Ds.Tables[0].Rows[0]["cuseraprobador2"].ToString();
            _Str_Cadena = "SELECT cproductosalida,clotesalida,dbo.Fnc_Formatear(cpmvsalida) AS cpmvsalida,ccajas,cunidades,cproductoentrada,cloteentrada,dbo.Fnc_Formatear(cpmventrada) AS cpmventrada FROM TAJUSTEINTEGRADOD WHERE cidajuste='" + _P_Str_AjusteIntegrado + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No se obtuvo el detalle.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Dg_Detalle.Rows.Add(new object[] { 
                    _Row["cproductosalida"], 
                    _Row["clotesalida"],
                    _Row["cpmvsalida"],
                    _Row["ccajas"],
                    _Row["cunidades"],
                    _Row["cproductoentrada"],
                    _Row["cloteentrada"],
                    _Row["cpmventrada"]});
            }
            _Tb_Tab.Selecting -= (_Tb_Tab_Selecting);
            _Tb_Tab.SelectedIndex = 1;
            _Tb_Tab.Selecting += (_Tb_Tab_Selecting);
            if (_Int_TipoNotificador == 1 && _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_AJUSTE_INTEGRADO_APROB"))
            {
                _Bt_FirmaAprobador1.Enabled = true;
                _Bt_EliminarAprobador1.Enabled = true;
            }
            else if (_Int_TipoNotificador == 2 && _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_AJUSTE_INTEGRADO_APROB_2"))
            {
                _Bt_FirmaAprobador2.Enabled = true;
                _Bt_EliminarAprobador2.Enabled = true;
            }
            else if (_Int_TipoNotificador == 3 && _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_AJUSTE_INTEGRADO"))
            {
                _Bt_Imprimir.Enabled = true;
                return;
            }
        }

        private void _Mtd_GuadarPrimeraAprobacion()
        {
            var _Str_Cadena = "UPDATE TAJUSSALC SET cfuseraprobador1=1, cuseraprobador1='" + Frm_Padre._Str_Use + "', cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cajustsal='" + _Txt_AjusteSalida.Text + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "UPDATE TAJUSENTC SET cfuseraprobador1=1, cuseraprobador1='" + Frm_Padre._Str_Use + "', cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cajustent='" + _Txt_AjusteEntrada.Text + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "UPDATE TAJUSTEINTEGRADO SET cfuseraprobador1=1, cuseraprobador1='" + Frm_Padre._Str_Use + "', cdateupd=GETDATE(), cuserupd='" + Frm_Padre._Str_Use + "' WHERE cidajuste='" + _Txt_AjusteIntegrado.Text + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }

        private void _Mtd_GuadarSegundaAprobacion()
        {
            var _Str_Cadena = "UPDATE TAJUSSALC SET cfuseraprobador2=1, cuseraprobador2='" + Frm_Padre._Str_Use + "', cejecutada='1', cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cajustsal='" + _Txt_AjusteSalida.Text + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "UPDATE TAJUSENTC SET cfuseraprobador2=1, cuseraprobador2='" + Frm_Padre._Str_Use + "', cejecutada='1', cdateupd=GETDATE(),cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cajustent='" + _Txt_AjusteEntrada.Text + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "UPDATE TAJUSTEINTEGRADO SET cfuseraprobador2=1, cuseraprobador2='" + Frm_Padre._Str_Use + "', cdateupd=GETDATE(), cuserupd='" + Frm_Padre._Str_Use + "' WHERE cidajuste='" + _Txt_AjusteIntegrado.Text + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }

        private void AnularAjuste()
        {
            var _Str_Cadena = "UPDATE TAJUSSALC SET canulado='1', cdateupd=GETDATE(), cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cajustsal='" + _Txt_AjusteSalida.Text + "' AND ISNULL(canulado,0)=0";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "UPDATE TAJUSSALD SET canulado='1', cdateupd=GETDATE(), cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cajustsal='" + _Txt_AjusteSalida.Text + "' AND ISNULL(canulado,0)=0";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "UPDATE TAJUSENTC SET canulado='1', cdateupd=GETDATE(), cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cajustent='" + _Txt_AjusteEntrada.Text + "' AND ISNULL(canulado,0)=0";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "UPDATE TAJUSTEINTEGRADO SET canulado='1', cdateupd=GETDATE(), cuserupd='" + Frm_Padre._Str_Use + "' WHERE cidajuste='" + _Txt_AjusteIntegrado.Text.Trim() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }

        private void _Mtd_ImprimirAjustes()
        {
            try
            {
                MessageBox.Show("A continuación se va a imprimir el ajuste de salida.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PrintDialog _Print = new PrintDialog();
            Etiq_Print_Salida:
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    REPORTESS _Frm = new REPORTESS(new string[] { "VST_AJUSTESAL_RPT" }, "", "T3.Report.rAjtSalida", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' AND cajustsal='" + _Txt_AjusteSalida.Text + "'", _Print, true);
                    Cursor = Cursors.Default;
                    if (MessageBox.Show("¿Se ha impreso correctamente el ajuste de salida?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        _Frm.Close();
                        _Frm.Dispose();
                        goto Etiq_Print_Salida;
                    }
                    MessageBox.Show("A continuación se va a imprimir el ajuste de entrada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Etiq_Print_Entrada:
                    if (_Print.ShowDialog() == DialogResult.OK)
                    {
                        Cursor = Cursors.WaitCursor;
                        _Frm = new REPORTESS(new string[] { "VST_AJUSTEENT_RPT" }, "", "T3.Report.rAjtEntrada", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' AND cajustent='" + _Txt_AjusteEntrada.Text + "'", _Print, true);
                        Cursor = Cursors.Default;
                        if (MessageBox.Show("¿Se ha impreso correctamente el ajuste de entrada?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            _Frm.Close();
                            _Frm.Dispose();
                            goto Etiq_Print_Entrada;
                        }
                        //-----------------------------
                        Cursor = Cursors.WaitCursor;
                        var _Str_Cadena = "UPDATE TAJUSSALC SET cimpreso=1, cdateupd=GETDATE(), cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cajustsal='" + _Txt_AjusteSalida.Text + "' AND ISNULL(cimpreso,0)=0";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "UPDATE TAJUSENTC SET cimpreso=1, cdateupd=GETDATE(), cuserupd='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cajustent='" + _Txt_AjusteEntrada.Text + "' AND ISNULL(cimpreso,0)=0";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "UPDATE TINVFISICOHISTM SET cfinalizado='2' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cfinalizado='1'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        _Str_Cadena = "UPDATE TAJUSTEINTEGRADO SET cimpreso='1', cdateupd=GETDATE(), cuserupd='" + Frm_Padre._Str_Use + "' WHERE cidajuste='" + _Txt_AjusteIntegrado.Text + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        Cursor = Cursors.Default;
                        //-----------------------------
                        MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                        _Tb_Tab.SelectedIndex = 0;
                        if (_Dg_Grid.RowCount == 0)
                            this.Close();
                    }
                }
            }
            catch (Exception _Ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Error al conectarse con la impresora.\n" + _Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
             
        }

        private void Frm_AjusteIntegrado_Load(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
            _Mtd_InicializarFormulario();
        }

        private void Frm_AjusteIntegrado_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_AJUSTE_INTEGRADO");
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            if (_Cmb_Proveedor.Enabled)
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = true;
            }
            else
            {
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            }
        }


        private void Frm_AjusteIntegrado_FormClosing(object sender, FormClosingEventArgs e)
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
                _Mtd_InicializarFormulario();
                _Mtd_Hab_Deshab_Controles(false);
                _Mtd_Actualizar();
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            }
            else if (!_Cmb_Proveedor.Enabled)
                e.Cancel = true;
        }

        private void _Bt_Agregar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Cmb_Proveedor.SelectedIndex == 0)
            {
                _Er_Error.SetError(_Cmb_Proveedor, "Información requerida!");
                _Cmb_Proveedor.Focus();
                return;
            }
            if (string.IsNullOrEmpty(_Txt_NotaRecepcion.Text))
            {
                _Er_Error.SetError(_Txt_NotaRecepcion, "Información requerida!");
                _Txt_NotaRecepcion.Focus();
                return;
            }
            if (!_Mtd_VerificarProveedorNr(Convert.ToString(_Cmb_Proveedor.SelectedValue), _Txt_NotaRecepcion.Text))
            {
                MessageBox.Show("La nota de recepción ingresada no corresponde con el proveedor seleccionado. Por favor verifique!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var _Frm_AjusteIntegradoP = new Frm_AjusteIntegradoP(Convert.ToString(_Cmb_Proveedor.SelectedValue), _Txt_NotaRecepcion.Text);
            _Frm_AjusteIntegradoP.ShowDialog(this);
            if (_Frm_AjusteIntegradoP.DialogResult == DialogResult.OK)
            {
                _Mtd_AgregarRegistro(_Frm_AjusteIntegradoP);
            }
        }

        private void _Cmb_Motivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
        }

        private void _Cmb_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            _Txt_NotaRecepcion.Text = "";
            _Txt_NotaRecepcion.Enabled = _Cmb_Proveedor.SelectedIndex > 0;
        }

        private void _Txt_NotaRecepcion_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_NotaRecepcion.Text)) { _Txt_NotaRecepcion.Text = ""; }
            _Er_Error.Dispose();
            _Mtd_LimpiarGrid();
        }

        private void _Txt_NotaRecepcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_NotaRecepcion, e, 8, 0);
        }

        private void _Txt_NotaEntrega_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_NotaEntrega.Text)) { _Txt_NotaEntrega.Text = ""; }
            _Er_Error.Dispose();
        }

        private void _Txt_NotaEntrega_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_NotaEntrega, e, 8, 0);
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Detalle.CurrentCell == null || _Dg_Detalle.SelectedRows.Count == 0)
                e.Cancel = true;
            else
                _Mnu_Editar.Visible = _Dg_Detalle.SelectedRows.Count == 1;
        }

        private void _Mnu_Editar_Click(object sender, EventArgs e)
        {
            var _Frm_AjusteIntegradoP = new Frm_AjusteIntegradoP(Convert.ToString(_Cmb_Proveedor.SelectedValue), _Txt_NotaRecepcion.Text);
            var _DgRow = _Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex];
            //--------------
            _Frm_AjusteIntegradoP.ProductoSalida = Convert.ToString(_DgRow.Cells["_Col_ProductoSalida"].Value);
            _Frm_AjusteIntegradoP.ProductoSalidaLote = Convert.ToString(_DgRow.Cells["_Col_LoteSalida"].Value);
            _Frm_AjusteIntegradoP.ProductoSalidaPmv = Convert.ToString(_DgRow.Cells["_Col_PmvSalida"].Value);
            _Frm_AjusteIntegradoP.ProductoCajas = Convert.ToInt32(_DgRow.Cells["_Col_Cajas"].Value);
            _Frm_AjusteIntegradoP.ProductoUnidades = Convert.ToInt32(_DgRow.Cells["_Col_Unidades"].Value);
            _Frm_AjusteIntegradoP.ProductoEntrada = Convert.ToString(_DgRow.Cells["_Col_ProductoEntrada"].Value);
            _Frm_AjusteIntegradoP.ProductoEntradaLote = Convert.ToString(_DgRow.Cells["_Col_LoteEntrada"].Value);
            _Frm_AjusteIntegradoP.ProductoEntradaPmv = Convert.ToString(_DgRow.Cells["_Col_PmvEntrada"].Value);
            //--------------
            _Frm_AjusteIntegradoP._Mtd_CargarFormulario();
            var _Str_ProductoSalida = _Frm_AjusteIntegradoP.ProductoSalida;
            var _Str_ProductoEntrada = _Frm_AjusteIntegradoP.ProductoEntrada;
            ProductosSalida.Remove(_Frm_AjusteIntegradoP.ProductoSalida);
            ProductosEntrada.Remove(_Frm_AjusteIntegradoP.ProductoEntrada);
            //--------------
            _Frm_AjusteIntegradoP.ShowDialog(this);
            if (_Frm_AjusteIntegradoP.DialogResult == DialogResult.OK)
            {
                _Mtd_EditarRegistro(_Frm_AjusteIntegradoP, _Dg_Detalle.CurrentCell.RowIndex);
            }
            else
            {
                ProductosSalida.Add(_Str_ProductoSalida);
                ProductosEntrada.Add(_Str_ProductoEntrada);
            }
        }

        private void _Mnu_Eliminar_Click(object sender, EventArgs e)
        {
            if (_Dg_Detalle.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar por lo menos un registro.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            _Mtd_EliminarRegistros();
        }

        private void _Dtp_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dtp_Desde.MaxDate = _Dtp_Hasta.Value;
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            _Mtd_Actualizar();
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_CargarFormulario(Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value));
            Cursor = Cursors.Default;
        }

        private void _Bt_FirmaAprobador1_Click(object sender, EventArgs e)
        {
            if (CLASES._Cls_Varios_Metodos._Mtd_Conteo_Iniciado())
            {
                MessageBox.Show("Se ha iniciado el conteo de inventario.\n No puede realizar operaciónes en este ámbito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_AJUSTE_INTEGRADO_APROB"))
            {
                if (new Frm_Clave().ShowDialog(this) != DialogResult.OK)
                    return;
                _Mtd_GuadarPrimeraAprobacion();
                _Txt_FirmaAprobador1.Text = Frm_Padre._Str_Use;
                MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                _Tb_Tab.SelectedIndex = 0;
                if (_Dg_Grid.RowCount == 0)
                    this.Close();
            }
            else
                MessageBox.Show("Su usuario no esta autorizado para realizar esta operación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void _Bt_EliminarAprobador1_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_AJUSTE_INTEGRADO_APROB"))
            {
                if (new Frm_Clave().ShowDialog(this) != DialogResult.OK)
                    return;
                AnularAjuste();
                MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                _Tb_Tab.SelectedIndex = 0;
                if (_Dg_Grid.RowCount == 0)
                    this.Close();
            }
            else
                MessageBox.Show("Su usuario no esta autorizado para realizar esta operación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void _Bt_FirmaAprobador2_Click(object sender, EventArgs e)
        {
            if (CLASES._Cls_Varios_Metodos._Mtd_Conteo_Iniciado())
            {
                MessageBox.Show("Se ha iniciado el conteo de inventario.\n No puede realizar operaciónes en este ámbito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_AJUSTE_INTEGRADO_APROB_2"))
            {
                if (new Frm_Clave().ShowDialog(this) != DialogResult.OK)
                    return;
                _Mtd_GuadarSegundaAprobacion();
                _Txt_FirmaAprobador2.Text = Frm_Padre._Str_Use;
                MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                _Tb_Tab.SelectedIndex = 0;
                if (_Dg_Grid.RowCount == 0)
                    this.Close();
            }
            else
                MessageBox.Show("Su usuario no esta autorizado para realizar esta operación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void _Bt_EliminarAprobador2_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" && _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_AJUSTE_INTEGRADO_APROB_2"))
            {
                if (new Frm_Clave().ShowDialog(this) != DialogResult.OK)
                    return;
                AnularAjuste();
                MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                _Tb_Tab.SelectedIndex = 0;
                if (_Dg_Grid.RowCount == 0)
                    this.Close();
            }
            else
                MessageBox.Show("Su usuario no esta autorizado para realizar esta operación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void _Bt_Imprimir_Click(object sender, EventArgs e)
        {
            _Mtd_ImprimirAjustes();
        }
    }
}
