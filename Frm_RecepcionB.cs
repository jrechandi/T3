using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace T3
{
    public partial class Frm_RecepcionB : Form
    {
        #region Métodos para las validaciones

        /// <summary>
        /// Método para optener el precio máximo de venta del productor o importador.
        /// </summary>
        /// <param name="_P_Str_Producto">Código del producto.</param>
        /// <returns>Valor del precio máximo de venta para el productor o el importador en la tabla THISTORICOPMV.</returns>
        private decimal _Mtd_ObtenerPMVPI(string _P_Str_Producto)
        {
            string _Str_SQL = "SELECT cpmvpi FROM THISTORICOPMV INNER JOIN TPRODUCTO ON THISTORICOPMV.cproducto = TPRODUCTO.cproducto WHERE (THISTORICOPMV.cproducto = '" + _P_Str_Producto + "') AND (cpreciomanejado=1) AND (GETDATE() BETWEEN THISTORICOPMV.cfechainicio AND ISNULL(THISTORICOPMV.cfechafinal, GETDATE()));";
            
            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            return Convert.ToDecimal(_Ds_A.Tables[0].Rows.Count > 0 ? _Ds_A.Tables[0].Rows[0]["cpmvpi"] : 0);
        }

        /// <summary>Método para validar si el producto requiere precio máximo de venta, solamente para los casos cuando el producto es nuevo y no tiene registros en THISTORICOPMV.</summary>
        /// <returns>Verdadero si existen productos que requieren precio máximo de venta.</returns>
        private bool _Mtd_ValidarPrecioMaximoVentaRequerido()
        {
            bool _Bol_Validar = true;
            string _Str_SQL;
            DataSet _Ds;

            foreach (DataGridViewRow _Obj_Fila in _Dg_Grid2.Rows)
            {
                if (_Obj_Fila.Cells[2].Value != null)
                {
                    _Str_SQL = "SELECT cregpmv FROM TPRODUCTO WHERE cproducto = '" + _Obj_Fila.Cells[2].Value + "';";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                    //Validacion de Producto con regulacion flexible
                    var _Str_cproducto = _Obj_Fila.Cells[2].Value.ToString();
                    bool _Bol_cprecioventamax_Correcto;
                    var _oValor = _Obj_Fila.Cells["cprecioventamax"].Value;
                    if (_MyUtilidad._Mtd_ProductoEsConRegulacionFlexible(_Str_cproducto))
                    {
                        decimal _DecValor;
                        decimal.TryParse(_oValor.ToString(), out _DecValor);
                        _Bol_cprecioventamax_Correcto = _DecValor == 0 || _Mtd_ValorValidoCelda(_oValor);
                    }
                    else
                    {
                        _Bol_cprecioventamax_Correcto = _Mtd_ValorValidoCelda(_oValor);
                    }

                    if (((_Ds.Tables[0].Rows[0]["cregpmv"].ToString() == "1") || (_Ds.Tables[0].Rows[0]["cregpmv"].ToString() == "2")) && !_Bol_cprecioventamax_Correcto)
                    {
                        _Obj_Fila.DefaultCellStyle.BackColor = Color.Gold;
                        _Obj_Fila.Cells["ccostobrutolote"].Style.BackColor = Color.Gold;
                        _Obj_Fila.Cells["cpreciolista"].Style.BackColor = Color.Gold;
                        _Obj_Fila.Cells["Column9"].Style.BackColor = Color.Gold;
                        _Obj_Fila.Cells["Unidades"].Style.BackColor = Color.Gold;
                        _Obj_Fila.Cells["Column10"].Style.BackColor = Color.Gold;
                        _Bol_Validar = false;
                    }

                }
            }

            return _Bol_Validar;
        }
        private void _Mtd_LimpiarNoReguladosPMV()
        {
           string _Str_SQL;
            DataSet _Ds;

            foreach (DataGridViewRow _Obj_Fila in _Dg_Grid2.Rows)
            {
                if (_Obj_Fila.Cells[2].Value != null)
                {
                    _Str_SQL = "SELECT cregpmv FROM TPRODUCTO WHERE cproducto = '" + _Obj_Fila.Cells[2].Value + "';";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                    if ((_Ds.Tables[0].Rows[0]["cregpmv"].ToString() == "0") && (Convert.ToDecimal(_Obj_Fila.Cells["cprecioventamax"].Value) > 0))
                    {
                        _Obj_Fila.Cells["cprecioventamax"].Value = "0";
                    }
                }
            }
        }
        /// <summary>Método para validar el costo por unidad minima de cada producto cuando estos son compiados de una orden de compra.</summary>
        /// <param name="_P_Dec_PMVPI">Precio máximo de venta del proveedor importador a mostrar.</param>
        /// <returns>Verdadero si existen productos cuyo costo por unidad minima es menor al THISTORICOPMV.cpmvpi.</returns>
        private bool _Mtd_ValidarCostoUnidadMinimaActual(out decimal _P_Dec_PMVPI)
        {
            bool _Bol_Validar = true;
            decimal _Dec_ContenidoManejo;
            decimal _Dec_CostoUnidad;
            decimal _Dec_PMVPI = 0;
            string _Str_SQL;
            DataSet _Ds;

            using (DataGridViewRow _Obj_Fila = _Dg_Grid2.CurrentRow)
            {
                if (_Obj_Fila.Cells[2].Value != null)
                {
                    _Str_SQL = "SELECT cregpmv FROM TPRODUCTO WHERE cproducto = '" + _Obj_Fila.Cells[2].Value + "';";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                    if (_Ds.Tables[0].Rows[0]["cregpmv"].ToString() == "1")
                    {
                        if ((_Obj_Fila.Cells["ccontenidoma1"].Value != null) && (_Obj_Fila.Cells[2].Value != null) && (_Obj_Fila.Cells[7].Value != null))
                        {
                            _Dec_ContenidoManejo = Convert.ToDecimal(_Obj_Fila.Cells["ccontenidoma1"].Value);
                            _Dec_CostoUnidad = Convert.ToDecimal(_Obj_Fila.Cells[7].Value.ToString());
                            _Dec_PMVPI = _Mtd_ObtenerPMVPI(_Obj_Fila.Cells[2].Value.ToString());

                            if ((_Dec_PMVPI > 0) && (Decimal.Round((_Dec_CostoUnidad / _Dec_ContenidoManejo), 2) > _Dec_PMVPI))
                            {
                                _Bol_Validar = false;
                            }
                        }
                    }
                }
            }

            _P_Dec_PMVPI = _Dec_PMVPI;

            return _Bol_Validar;
        }

        private bool _Mtd_ValidarCostoUnidadMinimaActualExistencia(out decimal _P_Dec_PMVPI)
        {
            bool _Bol_Validar = true;
            decimal _Dec_ContenidoManejo;
            decimal _Dec_CostoUnidad;
            decimal _Dec_PMVPI = 0;
            string _Str_SQL;
            DataSet _Ds;

            using (DataGridViewRow _Obj_Fila = _Dg_Grid2.CurrentRow)
            {
                if (_Obj_Fila.Cells[2].Value != null)
                {
                    _Str_SQL = "SELECT cregpmv FROM TPRODUCTO WHERE cproducto = '" + _Obj_Fila.Cells[2].Value + "';";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                    if (_Ds.Tables[0].Rows[0]["cregpmv"].ToString() == "1")
                    {
                        if ((_Obj_Fila.Cells["ccontenidoma1"].Value != null) && (_Obj_Fila.Cells[2].Value != null) && (_Obj_Fila.Cells[7].Value != null))
                        {
                            _Dec_ContenidoManejo = Convert.ToDecimal(_Obj_Fila.Cells["ccontenidoma1"].Value);
                            _Dec_CostoUnidad = Convert.ToDecimal(_Obj_Fila.Cells[7].Value.ToString());
                            _Dec_PMVPI = _Mtd_ObtenerPMVPI(_Obj_Fila.Cells[2].Value.ToString());

                            if ((_Dec_PMVPI == 0))
                            {
                                _Bol_Validar = false;
                            }
                        }
                    }
                }
            }

            _P_Dec_PMVPI = _Dec_PMVPI;

            return _Bol_Validar;
        }

        /// <summary>Método para validar el costo por unidad minima de cada producto cuando estos son compiados de una orden de compra.</summary>
        /// <returns>Verdadero si existen productos cuyo costo por unidad minima es menor al THISTORICOPMV.cpmvpi.</returns>
        private bool _Mtd_ValidarCostoUnidadMinima()
        {
            bool _Bol_Validar = true;
            decimal _Dec_ContenidoManejo;
            decimal _Dec_CostoUnidad;
            decimal _Dec_PMVPI = 0;
            string _Str_SQL;            
            DataSet _Ds;

            foreach (DataGridViewRow _Obj_Fila in _Dg_Grid2.Rows)
            {
                if (_Obj_Fila.Index < (_Dg_Grid2.Rows.Count - 1))
                {
                    _Str_SQL = "SELECT cregpmv FROM TPRODUCTO WHERE cproducto = '" + _Obj_Fila.Cells[2].Value + "';";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                    if (_Ds.Tables[0].Rows[0]["cregpmv"].ToString() == "1")
                    {
                        if ((_Obj_Fila.Cells["ccontenidoma1"].Value != null) && (_Obj_Fila.Cells[2].Value != null) && (_Obj_Fila.Cells[7].Value != null))
                        {
                            _Dec_ContenidoManejo = Convert.ToDecimal(_Obj_Fila.Cells["ccontenidoma1"].Value);
                            _Dec_CostoUnidad = Convert.ToDecimal(_Obj_Fila.Cells[7].Value.ToString());
                            _Dec_PMVPI = _Mtd_ObtenerPMVPI(_Obj_Fila.Cells[2].Value.ToString());

                            if ((_Dec_PMVPI > 0) && (Decimal.Round((_Dec_CostoUnidad / _Dec_ContenidoManejo), 2) > _Dec_PMVPI))
                            {
                                _Obj_Fila.DefaultCellStyle.BackColor = Color.Gold;
                                _Obj_Fila.Cells["ccostobrutolote"].Style.BackColor = Color.Gold;
                                _Obj_Fila.Cells["cpreciolista"].Style.BackColor = Color.Gold;
                                _Obj_Fila.Cells["Column9"].Style.BackColor = Color.Gold;
                                _Obj_Fila.Cells["Unidades"].Style.BackColor = Color.Gold;
                                _Obj_Fila.Cells["Column10"].Style.BackColor = Color.Gold;
                                _Bol_Validar = false;
                            }
                            else
                            {
                                _Obj_Fila.DefaultCellStyle.BackColor = Color.White;
                                _Obj_Fila.Cells["ccostobrutolote"].Style.BackColor = Color.FromArgb(255, 255, 192);
                                _Obj_Fila.Cells["cpreciolista"].Style.BackColor = Color.FromArgb(255, 255, 192);
                                _Obj_Fila.Cells["Column9"].Style.BackColor = Color.FromArgb(255, 255, 192);
                                _Obj_Fila.Cells["Unidades"].Style.BackColor = Color.FromArgb(255, 255, 192);
                                _Obj_Fila.Cells["Column10"].Style.BackColor = Color.FromArgb(255, 255, 192);
                            }
                        }
                    }
                }
            }

            return _Bol_Validar;
        }

        private bool _Mtd_ValidarCostoUnidadMinimaExistencia()
        {
            bool _Bol_Validar = true;
            decimal _Dec_ContenidoManejo;
            decimal _Dec_CostoUnidad;
            decimal _Dec_PMVPI = 0;
            string _Str_SQL;
            DataSet _Ds;

            foreach (DataGridViewRow _Obj_Fila in _Dg_Grid2.Rows)
            {
                if (_Obj_Fila.Index < (_Dg_Grid2.Rows.Count - 1))
                {
                    _Str_SQL = "SELECT cregpmv FROM TPRODUCTO WHERE cproducto = '" + _Obj_Fila.Cells[2].Value + "';";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                    if (_Ds.Tables[0].Rows[0]["cregpmv"].ToString() == "1")
                    {
                        if ((_Obj_Fila.Cells["ccontenidoma1"].Value != null) && (_Obj_Fila.Cells[2].Value != null) && (_Obj_Fila.Cells[7].Value != null))
                        {
                            _Dec_ContenidoManejo = Convert.ToDecimal(_Obj_Fila.Cells["ccontenidoma1"].Value);
                            _Dec_CostoUnidad = Convert.ToDecimal(_Obj_Fila.Cells[7].Value.ToString());
                            _Dec_PMVPI = _Mtd_ObtenerPMVPI(_Obj_Fila.Cells[2].Value.ToString());

                            if (_Dec_PMVPI == 0)
                            {
                                _Obj_Fila.DefaultCellStyle.BackColor = Color.Gold;
                                _Obj_Fila.Cells["ccostobrutolote"].Style.BackColor = Color.Gold;
                                _Obj_Fila.Cells["cpreciolista"].Style.BackColor = Color.Gold;
                                _Obj_Fila.Cells["Column9"].Style.BackColor = Color.Gold;
                                _Obj_Fila.Cells["Unidades"].Style.BackColor = Color.Gold;
                                _Obj_Fila.Cells["Column10"].Style.BackColor = Color.Gold;
                                _Bol_Validar = false;
                            }
                            else
                            {
                                _Obj_Fila.DefaultCellStyle.BackColor = Color.White;
                                _Obj_Fila.Cells["ccostobrutolote"].Style.BackColor = Color.FromArgb(255, 255, 192);
                                _Obj_Fila.Cells["cpreciolista"].Style.BackColor = Color.FromArgb(255, 255, 192);
                                _Obj_Fila.Cells["Column9"].Style.BackColor = Color.FromArgb(255, 255, 192);
                                _Obj_Fila.Cells["Unidades"].Style.BackColor = Color.FromArgb(255, 255, 192);
                                _Obj_Fila.Cells["Column10"].Style.BackColor = Color.FromArgb(255, 255, 192);
                            }
                        }
                    }
                }
            }

            return _Bol_Validar;
        }

        /// <summary>Método para validar el PMV del producto cuando estos son copiados de una orden de compra.</summary>
        /// <returns>Verdadero si existen producto con PMV mayores al que está en THISTORICOPMV.</returns>
        private bool _Mtd_ValidarPrecioMaximoVenta()
        {
	        bool _Bol_Validar = true, _Bol_EsValidoPMV = true, _Bol_NoTienePMV = true;
	        string _Str_SQL;
	        DataSet _Ds;            

	        foreach (DataGridViewRow _Obj_Fila in _Dg_Grid2.Rows)
	        {
		        if (_Obj_Fila.Index < (_Dg_Grid2.Rows.Count - 1))
		        {
			        _Str_SQL = "SELECT cregpmv FROM TPRODUCTO WHERE cproducto = '" + _Obj_Fila.Cells[2].Value + "';";
			        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

			        if (_Ds.Tables[0].Rows[0]["cregpmv"].ToString() == "1" || _Ds.Tables[0].Rows[0]["cregpmv"].ToString() == "2")
			        {
                        _Bol_EsValidoPMV = _MyUtilidad._Mtd_VerificarPMV(_Obj_Fila.Cells[2].Value.ToString(), Convert.ToDecimal(_Obj_Fila.Cells["cprecioventamax"].Value), out _Bol_NoTienePMV);

				        if ((_Obj_Fila.Cells["cprecioventamax"].Value != null) && (_Obj_Fila.Cells[2].Value != null))
				        {
					        if ((!_Bol_NoTienePMV) || (!_Bol_EsValidoPMV))
					        {
						        _Obj_Fila.DefaultCellStyle.BackColor = Color.Gold;
						        _Obj_Fila.Cells["ccostobrutolote"].Style.BackColor = Color.Gold;
						        _Obj_Fila.Cells["cpreciolista"].Style.BackColor = Color.Gold;
						        _Obj_Fila.Cells["Column9"].Style.BackColor = Color.Gold;
						        _Obj_Fila.Cells["Unidades"].Style.BackColor = Color.Gold;
						        _Obj_Fila.Cells["Column10"].Style.BackColor = Color.Gold;
						        _Bol_Validar = false;
					        }
					        else
					        {
						        _Obj_Fila.DefaultCellStyle.BackColor = Color.White;
						        _Obj_Fila.Cells["ccostobrutolote"].Style.BackColor = Color.FromArgb(255, 255, 192);
						        _Obj_Fila.Cells["cpreciolista"].Style.BackColor = Color.FromArgb(255, 255, 192);
						        _Obj_Fila.Cells["Column9"].Style.BackColor = Color.FromArgb(255, 255, 192);
						        _Obj_Fila.Cells["Unidades"].Style.BackColor = Color.FromArgb(255, 255, 192);
						        _Obj_Fila.Cells["Column10"].Style.BackColor = Color.FromArgb(255, 255, 192);
					        }
				        }
			        }
		        }
	        }

	        return _Bol_Validar;
        }

        #endregion

        public Frm_RecepcionB()
        {
            InitializeComponent();
        }
        string[] _Str_Array = new string[0];
        CLASES._Cls_Varios_Metodos _MyUtilidad = new CLASES._Cls_Varios_Metodos(true);
        string _Str_Proveedor = "";
        int _Int_Switch = 0;
        bool _Bol_FacMalCargFormClos = false;//Esta variable es para que abra el notificador correcto al cerrarse el formulario desde la "eliminación de una factura" porque en ese proceso el status de _Int_Switch puede cambiar·
        public Frm_RecepcionB(string _P_Str_Proveedor, string _P_Str_Placa, string _P_Str_Recepcion, int _P_Int_Switch)
        {
            InitializeComponent();
            _Int_Switch = _P_Int_Switch;
            _Bt_Finalizar.Enabled = _Int_Switch == 0;
            _Bt_Nuevo.Enabled = _Int_Switch == 0;
            _Str_Proveedor = _P_Str_Proveedor;
            _Txt_Placa.Text = _P_Str_Placa;
            _Txt_Rec.Text = _P_Str_Recepcion;
            _Txt_Proveedor.Text = _Mtd_DesProveedor(_P_Str_Proveedor);
            if (_P_Int_Switch == 0)
            { 
                _Lbl_DgFactInfo.Text = "Use botón derecho o doble click"; 
            }
            else if (_P_Int_Switch == 1)
            {
                _Lbl_DgFactInfo.Text = "Use botón derecho o doble click";
                _Bol_FacMalCargFormClos = true;
            }
            else if (_P_Int_Switch == 2)
            {
                _Lbl_DgFactInfo.Text = "Use doble click";
                _Tb_Tab.SelectedIndex = 2;
                Cursor = Cursors.WaitCursor;
                _Mtd_IniLists();
                Cursor = Cursors.Default;
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
        private void _Mtd_Sorted(DataGridView _P_Dg_Grid)
        {
            for (int _Int_i = 0; _Int_i < _P_Dg_Grid.Columns.Count; _Int_i++)
            {
                _P_Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public void _Mtd_Habilitar_Bt_Fac()
        {
            _Txt_Inven.Text = "";
            _Txt_DescComer.Text = "";
            _Txt_DescFinan.Text = "";
            _Txt_Cajas.Text = "";
            _Txt_Unidades.Text = "";
            _Txt_Fac.Text = "";
            _Txt_Fac.Tag = "";
            _Txt_Observacion.Text = "";
            _Txt_NumCtrl.Text = "";
            _Txt_NumCtrlPref.Text = "";
            _Txt_NumCtrl.Tag = "";
            _Txt_GuiaSada.Text = "";
            _Txt_SubTotal.Text = "";
            _Txt_Total.Text = "";
            _Txt_Impuesto.Text = "";
            _Txt_TotalSinImp.Text = "";
            _Txt_MontoExento.Text = "";
            _Dpt_FechaFac.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dpt_FechaEmiFac.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dpt_FechaFacVen.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate();
            _Dg_Grid2.Columns[8].Visible = false;
            _Dg_Grid2.Columns[8].HeaderText = "Descuento";
            _Chk_Descuento.Enabled = true;
            _Chk_Descuento.Checked = false;
            _Num_DescFinanciero.Enabled = true;
            _Rb_R1.Checked = false;
            _Rb_R1.Enabled = false;
            _Rb_R2.Checked = false;
            _Rb_R2.Enabled = false;
            _Num_DescFinanciero.ValueChanged -= new EventHandler(_Num_DescFinanciero_ValueChanged);
            _Num_DescFinanciero.Value = 0;
            _Num_DescFinanciero.ValueChanged += new EventHandler(_Num_DescFinanciero_ValueChanged);
            _Dpt_FechaFac.Enabled = true;
            _Dpt_FechaEmiFac.Enabled = true;
            _Dpt_FechaFacVen.Enabled = true;
            _Txt_Fac.Enabled = true;
            _Txt_Observacion.Enabled = true;
            _Dg_Grid2.ReadOnly = false;
            _Dg_Grid2.Columns[2].ReadOnly = true;
            _Dg_Grid2.Columns[3].ReadOnly = true;
            _Dg_Grid2.Columns[7].ReadOnly = true;
            _Dg_Grid2.Columns["CostoNeto"].ReadOnly = true;
            _Dg_Grid2.Columns["ccostobrutolote"].ReadOnly = true;
            _Dg_Grid2.Columns["cpreciolista"].ReadOnly = true;
            _Bt_Evaluar.Enabled = true;
            _Dg_Grid2.Rows.Clear();
        }
        public void _Mtd_DasHabilitar_Bt_Fac()
        {
            _Bt_Guardar.Enabled = false;
            _Bt_Editar.Enabled = false;
            _Bt_Buscar.Enabled = false;
            _Dg_Grid2.ReadOnly = true;
            _Dpt_FechaFac.Enabled = false;
            _Dpt_FechaEmiFac.Enabled = false;
            _Dpt_FechaFacVen.Enabled = false;
            _Chk_Descuento.Enabled = false;
            _Num_DescFinanciero.Enabled = false;
            _Txt_Inven.Enabled = false;
            _Txt_Fac.Enabled = false;
            _Txt_Observacion.Enabled = false;
        }
        private string _Mtd_DesProveedor(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal='1') AND cproveedor='" + _P_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            return "";
        }
        private decimal _Mtd_RetornarCostoNeto(string _P_Str_Producto, decimal _P_Dec_Precio)
        {
            if (_P_Str_Producto.Trim().Trim().Length > 0)
            {
                //Cargamos los lotes y tomamos el costo neto de alli
                var _Str_SQL = "select ccostonetolote from tproductod where cproducto = '" + _P_Str_Producto + "' and cprecioventamax = " + _P_Dec_Precio.ToString().Replace(',', '.') + " order by cfechaautorizado desc";
                var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                //Si existe lo tomamos de los lotes (el primero)
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    return Convert.ToDecimal(_Ds.Tables[0].Rows[0][0].ToString().Trim());
                }

                //Sino lo tomamos de la maestra
                _Str_SQL = "SELECT dbo.Fnc_Formatear(ccostoneto_u1) FROM TPRODUCTO WHERE cproducto='" + _P_Str_Producto + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                    {
                        return Convert.ToDecimal(_Ds.Tables[0].Rows[0][0].ToString().Trim());
                    }
                }
            }
            return 0;
        }
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public bool _Mtd_IsNumeric(object Expression)
        {
            bool isNum;
            decimal retNum;

            isNum = decimal.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private decimal _Mtd_Alicuota()
        {
            string _Str_Cadena = "SELECT TTAX.cpercent FROM TTAX INNER JOIN TCONFIGCOMP ON TTAX.ctax = TCONFIGCOMP.ctax WHERE (TCONFIGCOMP.ccompany = '" + Frm_Padre._Str_Comp + "')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                { return Convert.ToDecimal(_Ds.Tables[0].Rows[0][0]); }
            }
            return 0;
        }
        private void _Mtd_Totalizar()
        {
            string _Str_CodProd = "";
            bool _Bol_DtoPP = false;
            decimal _Dcm_Invendible = 0, _Dcm_PrecioPro = 0, _Dcm_D1 = 0, _Dcm_SubTotal = 0, _Dcm_PreicioproCarg = 0, _Dcm_Guardar = 0;
            decimal _Dcm_Descuento = 0, _Dcm_Monto = 0, _Dcm_MontoInvendible = 0, _Dcm_Impuesto = 0, _Dcm_Base_Grabada = 0;
            decimal _Dcm_ImpuestoCalculado = 0, _Dcm_Base_Excenta = 0;
            decimal _Dcm_MontoSinImpuesto = 0, _Dcm_TotalImpuesto = 0, _Dcm_TotalFactura = 0, _Dcm_TotalInvendible = 0;
            decimal _Dcm_DescFinan = 0, _Dcm_DescFinanImp = 0, _Dcm_TotalDescFinan = 0, _Dcm_TotalDescFinanImp = 0;
            int _Int_empaques = 0, _Int_CajasTot=0, _Int_Unidades=0, _Int_UnidadesTotal=0;
            string _Str_Sql = "";
            DataSet _Ds;
            foreach (DataGridViewRow _DgRow in _Dg_Grid2.Rows)
            {
                _Dcm_Guardar = 0;
                _Dcm_PrecioPro = 0;
                _Dcm_Invendible = 0;
                _Int_empaques = 0;
                _Int_Unidades = 0;
                _Dcm_D1 = 0;
                _Dcm_PreicioproCarg = 0;
                _Dcm_Monto = 0;
                _Dcm_MontoInvendible = 0;
                _Dcm_Impuesto = 0;
                _Dcm_ImpuestoCalculado = 0;
                _Dcm_DescFinan = 0;
                _Dcm_DescFinanImp = 0;
                if (Convert.ToString(_DgRow.Cells[2].Value).Trim().Length > 0 & Convert.ToString(_DgRow.Cells[3].Value).Trim().Length > 0 & (_Mtd_ValorValidoCelda(_DgRow.Cells[4].Value) | _Mtd_ValorValidoCelda(_DgRow.Cells[5].Value)) & _Mtd_ValorValidoCelda(_DgRow.Cells[6].Value))
                {
                    _Str_Sql = "SELECT cproducto,cdescpp FROM TPRODUCTO WHERE CPRODUCTO='" + Convert.ToString(_DgRow.Cells[2].Value) + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_CodProd = _Ds.Tables[0].Rows[0][0].ToString();
                        _Bol_DtoPP=(_Ds.Tables[0].Rows[0][1].ToString()=="1");
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cporcinvendible from TPROVEEDOR where cproveedor='" + _Str_Proveedor + "'");
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Length > 0)
                            {
                                _Dcm_Invendible = Convert.ToDecimal(_Ds.Tables[0].Rows[0][0]);
                            }
                        }

                        if (Convert.ToString(_DgRow.Cells[6].Value).Trim().Length > 0)
                        { _Dcm_PrecioPro = Convert.ToDecimal(_DgRow.Cells[6].Value); }
                        if (Convert.ToString(_DgRow.Cells[4].Value).Trim().Length > 0)
                        { _Int_empaques = Convert.ToInt32(_DgRow.Cells[4].Value); }
                        if (_DgRow.Cells[5].Value != null)
                        { _Int_Unidades = Convert.ToInt32(_DgRow.Cells[5].Value); }
                        _Int_UnidadesTotal += _Int_Unidades;
                        _Int_CajasTot = _Int_CajasTot + _Int_empaques;
                        if (_DgRow.Cells[8].Value != null)
                        { _Dcm_D1 = Convert.ToDecimal(_DgRow.Cells[8].Value); }
                        _Dcm_PreicioproCarg = _Dcm_PrecioPro;
                        if (_Rb_R1.Checked)
                        {
                            _Dcm_Guardar = (_Dcm_PrecioPro * _Dcm_D1) / 100;
                            _Dcm_PrecioPro = _Dcm_PrecioPro - _Dcm_Guardar;
                        }
                        else if (_Rb_R2.Checked)
                        {
                            _Dcm_Guardar = _Dcm_D1;
                            _Dcm_PrecioPro = _Dcm_PrecioPro - _Dcm_D1;
                        }
                        _Dcm_SubTotal = _Dcm_SubTotal + _Dcm_PrecioPro;
                        _Dcm_Descuento = _Dcm_Descuento + _Dcm_Guardar;
                        if (Convert.ToString(_DgRow.Cells[7].Value).Trim().Length > 0)
                        { _Dcm_Monto = Convert.ToDecimal(_DgRow.Cells[7].Value); }
                        _Dcm_MontoInvendible = ((_Dcm_PrecioPro * _Dcm_Invendible) / 100);
                        _Dcm_PrecioPro = _Dcm_PrecioPro - _Dcm_MontoInvendible;
                        if (_Bol_DtoPP)
                        {
                            _Dcm_DescFinan = (Convert.ToDecimal(_Num_DescFinanciero.Value) * _Dcm_PrecioPro) / 100;//NUEVO DESC FINAN
                        }
                        else
                        {
                            _Dcm_DescFinan = 0;
                        }
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax AND TPRODUCTO.cdelete = TTAX.cdelete WHERE (TPRODUCTO.cproducto = '" + _Str_CodProd + "')");
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            try
                            {
                                _Dcm_Impuesto = Convert.ToDecimal(_Ds.Tables[0].Rows[0][0].ToString());
                                _Dcm_Base_Grabada = _Dcm_Base_Grabada + _Dcm_PreicioproCarg;
                            }
                            catch { }
                            _Dcm_ImpuestoCalculado = (_Dcm_PrecioPro * _Dcm_Impuesto) / 100; // Andres me dijo que lo cambiara
                            if (_Bol_DtoPP)
                            {
                                _Dcm_DescFinanImp = (_Dcm_DescFinan * _Dcm_Impuesto) / 100;//NUEVO DESC FINAN
                            }
                            else
                            {
                                _Dcm_DescFinanImp = 0;
                            }
                        }
                        else
                        {
                            _Dcm_Base_Excenta = _Dcm_Base_Excenta + (_Dcm_PreicioproCarg - _Dcm_Guardar);
                            _Dcm_Base_Excenta = _Dcm_Base_Excenta - _Dcm_DescFinan;
                        }
                        _Dcm_TotalDescFinan = _Dcm_TotalDescFinan + _Dcm_DescFinan;
                        _Dcm_TotalDescFinanImp = _Dcm_TotalDescFinanImp + _Dcm_DescFinanImp;
                        _Dcm_MontoSinImpuesto = _Dcm_MontoSinImpuesto + _Dcm_PrecioPro;
                        _Dcm_TotalImpuesto = _Dcm_TotalImpuesto + _Dcm_ImpuestoCalculado;
                        _Dcm_TotalInvendible = _Dcm_Invendible;
                    }
                }
            }
            //------------
            _Dcm_MontoSinImpuesto = _Dcm_MontoSinImpuesto - _Dcm_TotalDescFinan;
            _Dcm_TotalImpuesto = _Dcm_TotalImpuesto - _Dcm_TotalDescFinanImp;
            _Dcm_TotalFactura = _Dcm_MontoSinImpuesto + _Dcm_TotalImpuesto;
            //------------
            _Txt_Cajas.Text = _Int_CajasTot.ToString();
            _Txt_Unidades.Text = _Int_UnidadesTotal.ToString();
            _Txt_DescComer.Text = _Dcm_Descuento.ToString("#,##0.00");
            _Txt_SubTotal.Text = _Dcm_SubTotal.ToString("#,##0.00");
            _Txt_Inven.Text = _Dcm_TotalInvendible.ToString("#,##0.00");
            _Txt_DescFinan.Text = _Dcm_TotalDescFinan.ToString("#,##0.00");
            _Txt_MontoExento.Text = _Dcm_Base_Excenta.ToString("#,##0.00");
            _Txt_TotalSinImp.Text = _Dcm_MontoSinImpuesto.ToString("#,##0.00");
            _Txt_Impuesto.Text = _Dcm_TotalImpuesto.ToString("#,##0.00");
            _Txt_Total.Text = _Dcm_TotalFactura.ToString("#,##0.00");
        }
        private bool _Mtd_ValorValidoCelda(object _P_Ob_Valor)
        {
            try
            {
                if (Convert.ToString(_P_Ob_Valor).Trim().Length > 0)
                {
                    if (Convert.ToDecimal(_P_Ob_Valor) > 0)
                    { return true; }
                }
            }
            catch { }
            return false;
        }
        private bool _Mtd_VerificarRegInval()
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells[2].Value).Trim().Length > 0 & Convert.ToString(_Dg_Row.Cells[3].Value).Trim().Length > 0 & !_Mtd_ValorValidoCelda(_Dg_Row.Cells[7].Value))
                {
                    return true;           
                }
            }
            return false;
        }
        private bool _Mtd_ObligatorioPMV(string _P_Str_Producto)
        {
            string _Str_Cadena = "SELECT cproducto FROM TPRODUCTO WHERE cproducto='" + _P_Str_Producto + "' AND (cregpmv='1' or cregpmv='2')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_VerificarRegCostBrutPrecMaxInval()
        {
            bool _Bol_Return = false;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
            {
                _Dg_Row.Cells["ccostobrutolote"].Style.BackColor = Color.FromArgb(255, 255, 192);
                _Dg_Row.Cells["cpreciolista"].Style.BackColor = Color.FromArgb(255, 255, 192);
                _Dg_Row.Cells["cprecioventamax"].Style.BackColor = Color.FromArgb(255, 255, 192);

                //Esta validacion es solo cuando el producto no es con regulacion flexible
                var _Str_cproducto = Convert.ToString(_Dg_Row.Cells["ProductoInterno"].Value).Trim();
                bool _Bol_cprecioventamax_Correcto;
                var _oValor = _Dg_Row.Cells["cprecioventamax"].Value;
                if (_MyUtilidad._Mtd_ProductoEsConRegulacionFlexible(_Str_cproducto))
                {
                    decimal _DecValor;
                    decimal.TryParse(_oValor.ToString(), out _DecValor);
                    _Bol_cprecioventamax_Correcto = _DecValor == 0 || _Mtd_ValorValidoCelda(_oValor);
                }
                else
                {
                    _Bol_cprecioventamax_Correcto = _Mtd_ValorValidoCelda(_oValor);
                }

                if (Convert.ToString(_Dg_Row.Cells[2].Value).Trim().Length > 0 & Convert.ToString(_Dg_Row.Cells[3].Value).Trim().Length > 0 & _Mtd_ValorValidoCelda(_Dg_Row.Cells[7].Value) & (!_Mtd_ValorValidoCelda(_Dg_Row.Cells["ccostobrutolote"].Value) || !_Bol_cprecioventamax_Correcto || !_Mtd_ValorValidoCelda(_Dg_Row.Cells["cpreciolista"].Value)))
                {
                    if (!_Mtd_ValorValidoCelda(_Dg_Row.Cells["ccostobrutolote"].Value))
                    {
                        _Dg_Row.Cells["ccostobrutolote"].Style.BackColor = Color.Yellow;
                        _Bol_Return = true;
                    }
                    //-----
                    if (!_Bol_cprecioventamax_Correcto && _Mtd_ObligatorioPMV(Convert.ToString(_Dg_Row.Cells["ProductoInterno"].Value).Trim()))
                    {
                        _Dg_Row.Cells["cprecioventamax"].Style.BackColor = Color.Yellow;
                        _Dg_Row.Cells["cprecioventamax"].ReadOnly = false;
                        _Bol_Return = true;
                    }
                    else
                    {
                        _Dg_Row.Cells["cprecioventamax"].ReadOnly = true;
                    }
                    //-----
                    if (!_Mtd_ValorValidoCelda(_Dg_Row.Cells["cpreciolista"].Value))
                    {
                        _Dg_Row.Cells["cpreciolista"].Style.BackColor = Color.Yellow;
                        _Bol_Return = true;
                    }
                }
            }
            return _Bol_Return;
        }
        private bool _Mtd_RecepcionAbierta(string _P_Str_Recepcion)
        {
            string _Str_Cadena = "SELECT cidrecepcion FROM TRECEPCIONM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _P_Str_Recepcion + "' AND ISNULL(ccerrada,0)='0'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private bool _Mtd_FacturaMalCargarda()
        {
            string _Str_Cadena = "SELECT cnfacturapro FROM TRECEPCIONDFM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _Txt_Rec.Text.Trim() + "' AND cnfacturapro='" + _Txt_Fac.Text.Trim() + "' AND cfactverif='2'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private void _Mtd_Nuevo()
        {
            _Str_OrdenCompra = "0";
            _Mtd_Habilitar_Bt_Fac();
            _Er_Error.Dispose();
            _Dg_Grid2.Rows.Add();
            _Bt_Guardar.Enabled = true;
            _Bt_Copiar.Enabled = true;
            _Bt_Buscar.Enabled = false;
            _Bt_Editar.Enabled = false;
            _Bt_Depurar.Enabled = false;
            _Bt_Finalizar.Enabled = false;
            _Txt_Fac.Focus();
        }
        private void _Mtd_SubTotalCompra(string _P_Str_Recepcion, string _P_Str_Factura)
        {
            string _Str_Cadena = "SELECT ROUND(ISNULL(SUM(((ISNULL(cpresioprocarg,0)-ISNULL(cdescuento1,0))*ISNULL(cporcinvendible,0))/100),0),2,1) FROM TRECEPCIONDFD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _P_Str_Recepcion + "' AND cnfacturapro='" + _P_Str_Factura + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            decimal _Dec_Invendible = Convert.ToDecimal(_Ds.Tables[0].Rows[0][0]);
            _Str_Cadena = "UPDATE TRECEPCIONDFM SET csubtotal=(ctotfactura-ctotalimp)+cdescfinanmonto+" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_Invendible) + " WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _P_Str_Recepcion + "' AND cnfacturapro='" + _P_Str_Factura + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private void _Mtd_Guardar()
        {
            //Limpia los productos no regulado si vienen con PMV
            _Mtd_LimpiarNoReguladosPMV();
            // Validaciones del sprint 16 para el PMV y costo por unidad.

            if (!_Mtd_ValidarPrecioMaximoVentaRequerido())
            {
                MessageBox.Show("Hay productos agregados en la factura que necesitan el precio máximo de venta.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1);
                return;
            }

            if (!_Mtd_ValidarCostoUnidadMinima())
            {
                MessageBox.Show("El costo por unidad de algunos productos no puede ser superior al precio máximo de venta del productor.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1);
                return;
            }
            if (!_Mtd_ValidarCostoUnidadMinimaExistencia())
            {
                MessageBox.Show("Hay productos que requieren el precio máximo de venta del productor y este no se encuentra configurado.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1);
                return;
            }            
            if (!_Mtd_ValidarPrecioMaximoVenta())
            {
                MessageBox.Show("El precio máximo de venta de algunos productos tiene que ser igual a los registrados en el sistema.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1);
                return;
            }
            
            //--Nuevo
            Cursor = Cursors.WaitCursor;
            _Er_Error.Dispose();
            _Dg_Grid2.EndEdit();
            _Num_DescFinanciero.EndInit();
            if (_Mtd_RecepcionAbierta(_Txt_Rec.Text.Trim()))
            {
                if (_Txt_SubTotal.Text != "")
                {
                    if (Convert.ToDecimal(_Txt_SubTotal.Text) > 0 & (Convert.ToDecimal(_Txt_Cajas.Text) > 0 | Convert.ToDecimal(_Txt_Unidades.Text) > 0))
                    {
                        //--Nuevo
                        if (_Txt_Fac.Text.Trim().Length < 1 | _Dg_Grid2.RowCount <= 1 | (_Dpt_FechaFac.Value >= _Dpt_FechaFacVen.Value) | !_Mtd_VerifContTextBoxNumeric(_Txt_NumCtrl) | !_Mtd_VerifContTextBoxVarcharNoCero(_Txt_Fac) | (_Dpt_FechaEmiFac.Value > _Dpt_FechaFac.Value))
                        {
                            if (_Txt_Fac.Text.Trim().Length < 1) { _Er_Error.SetError(_Txt_Fac, "Información requerida!!!"); }
                            else if (_Dg_Grid2.RowCount <= 1)
                            {
                                MessageBox.Show("Debe ingresar el detalle de la factura", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (_Dpt_FechaFac.Value >= _Dpt_FechaFacVen.Value)
                            {
                                MessageBox.Show("La fecha de vencimiento debe ser mayor a la fecha de la factura", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (_Dpt_FechaEmiFac.Value >= _Dpt_FechaFac.Value)
                            {
                                MessageBox.Show("La fecha de emisión de la factura debe ser menor o igual a la fecha de recepción", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            //---------------------
                            if (!_Mtd_VerifContTextBoxVarcharNoCero(_Txt_Fac)) { _Er_Error.SetError(_Txt_Fac, "Información requerida!!!"); }
                            if (!_Mtd_VerifContTextBoxNumeric(_Txt_NumCtrl)) { _Er_Error.SetError(_Txt_NumCtrl, "Información requerida!!!"); }
                            //if (!_Mtd_VerifContTextBoxVarcharNoCero(_Txt_GuiaSada)) { _Er_Error.SetError(_Txt_GuiaSada, "Información requerida!!!"); }
                        }
                        else
                        {
                            //--------------------------------------------------------------------
                            string _Str_NumControl = _Mtd_NumeroControl(_Txt_NumCtrlPref.Text.Trim(), _Txt_NumCtrl.Text.Trim()).ToUpper();
                            //--------------------------------------------------------------------
                            string _Str_Factura = Convert.ToString(_Txt_Fac.Tag).Trim();
                            if (_Str_Factura.Length == 0)
                            { _Str_Factura = _Txt_Fac.Text.Trim(); }
                            //--------------------------------------------------------------------
                            string _Str_TipoDocument = _MyUtilidad._Mtd_TipoDocumentFACT_CXP("ctipdocfact");
                            if ((Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cnfacturapro='" + _Txt_Fac.Text.Trim() + "' and cproveedor='" + _Str_Proveedor + "'").Tables[0].Rows.Count > 0 | Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from TFACTPPAGARM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and ctipodocument='" + _Str_TipoDocument + "' and cnumdocu='" + _Txt_Fac.Text.Trim() + "' and cproveedor='" + _Str_Proveedor + "'").Tables[0].Rows.Count > 0) & Convert.ToString(_Txt_Fac.Tag).Trim() != _Txt_Fac.Text.Trim())
                            {
                                MessageBox.Show("La factura ya se registro anteriormente. Coloque un código de factura diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _Txt_Fac.Focus();
                            }
                            else if ((Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from TRECEPCIONDFM where cnumdocuctrl='" + _Str_NumControl + "' and cproveedor='" + _Str_Proveedor + "' and cidrecepcion <> '" + _Txt_Rec.Text.Trim() + "'").Tables[0].Rows.Count > 0 | Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select * from TFACTPPAGARM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' and ctipodocument='" + _Str_TipoDocument + "' and cnumdocuctrl='" + _Str_NumControl + "' and cproveedor='" + _Str_Proveedor + "'").Tables[0].Rows.Count > 0) & Convert.ToString(_Txt_NumCtrl.Tag).Trim() != _Str_NumControl.Trim())
                            {
                                MessageBox.Show("La número de control ya se registro anteriormente. Coloque un número de control diferente diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _Txt_NumCtrl.Focus();
                            }
                            else
                            {
                                bool _Bol_Guardar = true;
                                if (_Mtd_VerificarRegInval())
                                {
                                    MessageBox.Show("Existen registros sin costo unitario. Debe completar la información.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    _Bol_Guardar = false;
                                }
                                else if (_Mtd_VerificarRegCostBrutPrecMaxInval())
                                {
                                    MessageBox.Show("Existen registros sin costo bruto, precio máximo o precio de lista. Debe completar la información en las celdas marcadas en amarillo.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    _Bol_Guardar = false;
                                }
                                if (_Bol_Guardar)
                                {
                                    bool _Bol_FacturaMalCargarda = _Mtd_FacturaMalCargarda();
                                    string _Str_Cade = "Delete from TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_Rec.Text.Trim() + "' and cnfacturapro='" + _Str_Factura + "' and cproveedor='" + _Str_Proveedor + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cade);
                                    _Str_Cade = "Delete from TRECEPCIONDFD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_Rec.Text.Trim() + "' and cnfacturapro='" + _Str_Factura + "' and cproveedor='" + _Str_Proveedor + "'";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cade);
                                    DataSet _Ds = new DataSet();
                                    decimal _Dcm_MontoSinImpuesto = 0;
                                    decimal _Dcm_Descuento = 0;
                                    decimal _Dcm_SubTotal = 0;
                                    decimal _Dcm_TotalImpuesto = 0;
                                    decimal _Dcm_TotalFactura = 0;
                                    decimal _Dcm_TotalInvendible = 0;
                                    decimal _Dcm_Base_Grabada = 0;
                                    decimal _Dcm_Base_Excenta = 0;
                                    decimal _Dcm_DescFinan = 0, _Dcm_DescFinanImp = 0, _Dcm_TotalDescFinan = 0, _Dcm_TotalDescFinanImp = 0;
                                    bool _Bol_Guardado = false;
                                    foreach (DataGridViewRow _DgRow in _Dg_Grid2.Rows)
                                    {
                                        //Validacion de Producto con regulacion flexible
                                        var _Bol_cprecioventamax_Correcto = false;
                                        if (Convert.ToString(_DgRow.Cells[2].Value).Trim().Length > 0)
                                        {
                                            var _Str_cproducto = _DgRow.Cells[2].Value.ToString();
                                            var _oValor = _DgRow.Cells["cprecioventamax"].Value;
                                            if (_MyUtilidad._Mtd_ProductoEsConRegulacionFlexible(_Str_cproducto))
                                            {
                                                decimal _DecValor;
                                                decimal.TryParse(_oValor.ToString(), out _DecValor);
                                                _Bol_cprecioventamax_Correcto = _DecValor == 0 || _Mtd_ValorValidoCelda(_oValor);
                                            }
                                            else
                                            {
                                                _Bol_cprecioventamax_Correcto = _Mtd_ValorValidoCelda(_oValor);
                                            }
                                        }

                                        if (Convert.ToString(_DgRow.Cells[2].Value).Trim().Length > 0 & Convert.ToString(_DgRow.Cells[3].Value).Trim().Length > 0 & (_Mtd_ValorValidoCelda(_DgRow.Cells[4].Value) | _Mtd_ValorValidoCelda(_DgRow.Cells[5].Value)) & _Mtd_ValorValidoCelda(_DgRow.Cells[6].Value) & _Mtd_ValorValidoCelda(_DgRow.Cells["ccostobrutolote"].Value) & (_Bol_cprecioventamax_Correcto || !_Mtd_ObligatorioPMV(Convert.ToString(_DgRow.Cells["ProductoInterno"].Value).Trim())) & _Mtd_ValorValidoCelda(_DgRow.Cells["cpreciolista"].Value))
                                        {
                                            decimal _Dcm_ccostobrutolote = 0;
                                            decimal _Dcm_cprecioventamax = 0;
                                            decimal _Dcm_cpreciolista = 0;
                                            decimal _Dcm_PrecioPro = 0;
                                            int _Int_empaques = 0;
                                            int _Int_Unidades = 0;
                                            decimal _Dcm_D1 = 0;
                                            decimal _Dcm_Guardar = 0;
                                            decimal _Dcm_Monto = 0;
                                            decimal _Dcm_PreicioproCarg = 0;
                                            decimal _Dcm_Invendible = 0;
                                            _Dcm_DescFinan = 0;
                                            _Dcm_DescFinanImp = 0;
                                            //-----------------------------
                                            int.TryParse(Convert.ToString(_DgRow.Cells[4].Value).Trim(), out _Int_empaques);
                                            int.TryParse(Convert.ToString(_DgRow.Cells[5].Value).Trim(), out _Int_Unidades);
                                            decimal.TryParse(Convert.ToString(_DgRow.Cells[6].Value).Trim(), out _Dcm_PrecioPro);
                                            decimal.TryParse(Convert.ToString(_DgRow.Cells[8].Value).Trim(), out _Dcm_D1);
                                            decimal.TryParse(Convert.ToString(_DgRow.Cells["ccostobrutolote"].Value).Trim(), out _Dcm_ccostobrutolote);
                                            decimal.TryParse(Convert.ToString(_DgRow.Cells["cprecioventamax"].Value).Trim(), out _Dcm_cprecioventamax);
                                            decimal.TryParse(Convert.ToString(_DgRow.Cells["cpreciolista"].Value).Trim(), out _Dcm_cpreciolista);
                                            //-----------------------------
                                            _Dcm_PreicioproCarg = _Dcm_PrecioPro;
                                            if (_Rb_R1.Checked)
                                            {
                                                _Dcm_Guardar = (_Dcm_PrecioPro * _Dcm_D1) / 100;
                                                _Dcm_PrecioPro = _Dcm_PrecioPro - _Dcm_Guardar;
                                            }
                                            else if (_Rb_R2.Checked)
                                            {
                                                _Dcm_Guardar = _Dcm_D1;
                                                _Dcm_PrecioPro = _Dcm_PrecioPro - _Dcm_D1;
                                            }
                                            _Dcm_SubTotal = _Dcm_SubTotal + _Dcm_PrecioPro;
                                            _Dcm_Descuento = _Dcm_Descuento + _Dcm_Guardar;
                                            if (_DgRow.Cells[7].Value != null)
                                            { _Dcm_Monto = Convert.ToDecimal(_DgRow.Cells[7].Value.ToString()); }
                                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cproducto,cdescpp from TPRODUCTO where cproducto='" + _DgRow.Cells[2].Value.ToString() + "' and cdelete='0'");
                                            string _Str_Producto = _Ds.Tables[0].Rows[0][0].ToString();
                                            bool _Bol_DtoPP = (_Ds.Tables[0].Rows[0][1].ToString()=="1");
                                            decimal _Dcm_Impuesto = 0;
                                            decimal _Dcm_ImpuestoCalculado = 0;
                                            try
                                            {
                                                _Txt_Inven.Text = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cporcinvendible from TPROVEEDOR where cproveedor='" + _Str_Proveedor + "' and cdelete='0'").Tables[0].Rows[0][0].ToString();

                                                if (_Txt_Inven.Text.Trim() == "")
                                                {
                                                    _Txt_Inven.Text = "0";
                                                }
                                            }
                                            catch { _Txt_Inven.Text = "0"; }
                                            //-----------------------------
                                            _Dcm_Invendible = (_Dcm_PrecioPro * Convert.ToDecimal(_Txt_Inven.Text)) / 100;
                                            _Dcm_PrecioPro = _Dcm_PrecioPro - _Dcm_Invendible;
                                            if (_Bol_DtoPP)
                                            {
                                                _Dcm_DescFinan = (Convert.ToDecimal(_Num_DescFinanciero.Value) * _Dcm_PrecioPro) / 100;//NUEVO DESC FINAN
                                            }
                                            else
                                            {
                                                _Dcm_DescFinan = 0;
                                            }
                                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT TTAX.cpercent FROM TPRODUCTO INNER JOIN TTAX ON TPRODUCTO.ctax1 = TTAX.ctax AND TPRODUCTO.cdelete = TTAX.cdelete WHERE (TPRODUCTO.cproducto = '" + _Str_Producto + "')");
                                            if (_Ds.Tables[0].Rows.Count > 0)
                                            {
                                                try
                                                {
                                                    _Dcm_Impuesto = Convert.ToDecimal(_Ds.Tables[0].Rows[0][0].ToString());
                                                    _Dcm_Base_Grabada = _Dcm_Base_Grabada + _Dcm_PreicioproCarg;
                                                }
                                                catch { }
                                                _Dcm_ImpuestoCalculado = (_Dcm_PrecioPro * _Dcm_Impuesto) / 100; // Andres me dijo que lo cambiara
                                                if (_Bol_DtoPP)
                                                {
                                                    _Dcm_DescFinanImp = (_Dcm_DescFinan * _Dcm_Impuesto) / 100;//NUEVO DESC FINAN
                                                }
                                                else
                                                {
                                                    _Dcm_DescFinanImp = 0;
                                                }
                                            }
                                            else
                                            {
                                                _Dcm_Base_Excenta = _Dcm_Base_Excenta + (_Dcm_PreicioproCarg - _Dcm_Guardar);
                                                _Dcm_Base_Excenta = _Dcm_Base_Excenta - _Dcm_DescFinan;
                                            }
                                            //-----------------------------
                                            _Dcm_TotalDescFinan = _Dcm_TotalDescFinan + _Dcm_DescFinan;
                                            _Dcm_TotalDescFinanImp = _Dcm_TotalDescFinanImp + _Dcm_DescFinanImp;
                                            _Dcm_MontoSinImpuesto = _Dcm_MontoSinImpuesto + _Dcm_PrecioPro;
                                            _Dcm_TotalImpuesto = _Dcm_TotalImpuesto + _Dcm_ImpuestoCalculado;
                                            _Dcm_TotalInvendible = _Dcm_TotalInvendible + _Dcm_Invendible;
                                            //-----------------------------
                                            if (!_Mtd_ObligatorioPMV(_Str_Producto))
                                            {
                                                _Dcm_cprecioventamax = 0;
                                            }
                                            string _Str_Sentencia = "insert into TRECEPCIONDFD (cgroupcomp,cidrecepcion,cnfacturapro,cproducto,ccodfabrica,cempaques,cunidades,cpreciouni,cdescuento1,cdescuento2,cprecioxpro,ctasaimp,ccalcimp,cproveedor,cpresioprocarg,cporcinvendible,ctipodescuento,cporcmontodesc,ccostobrutolote,cprecioventamax,cpreciolista) values('" + Frm_Padre._Str_GroupComp + "','" + _Txt_Rec.Text.Trim() + "','" + _Txt_Fac.Text + "','" + _Str_Producto + "','" + _DgRow.Cells[0].Value.ToString() + "','" + _DgRow.Cells[4].Value.ToString() + "','" + _DgRow.Cells[5].Value.ToString() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Monto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Guardar) + "','0','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_PrecioPro) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Impuesto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_ImpuestoCalculado) + "','" + _Str_Proveedor + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_PreicioproCarg) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDecimal(_Txt_Inven.Text)) + "','" + Convert.ToInt32(_Rb_R1.Checked) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_D1) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_ccostobrutolote) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_cprecioventamax) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_cpreciolista) + "')";
                                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sentencia);
                                            _Bol_Guardado = true;
                                        }
                                    }
                                    //----14/11/2008
                                    decimal _Dcm_Alicuota = 0;
                                    string _Str_Cadena = "SELECT TTAX.cpercent FROM TTAX INNER JOIN TCONFIGCXP ON TTAX.ctax = TCONFIGCXP.ctipimpuesto WHERE TCONFIGCXP.ccompany = '" + Frm_Padre._Str_Comp + "'";
                                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                                    if (_Ds.Tables[0].Rows.Count > 0)
                                    {
                                        if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                                        {
                                            _Dcm_Alicuota = Convert.ToDecimal(_Ds.Tables[0].Rows[0][0]);
                                        }
                                    }
                                    //----------------------
                                    _Dcm_MontoSinImpuesto = _Dcm_MontoSinImpuesto - _Dcm_TotalDescFinan;
                                    _Dcm_TotalImpuesto = _Dcm_TotalImpuesto - _Dcm_TotalDescFinanImp;
                                    _Dcm_TotalFactura = _Dcm_MontoSinImpuesto + _Dcm_TotalImpuesto;
                                    //----------------------
                                    _Str_Cadena = "Insert into TRECEPCIONDFM (cgroupcomp,cidrecepcion,cnfacturapro,cdatefactura,ctotmontsimp,ctotdescuento,cporcinvendible,csubtotal,ctotalimp,ctotfactura,cproveedor,cdatevencimiento,cnumdocuctrl,cbasegrabada,cbaseexcenta,calicuota,cdateemifactura,cobservacion,cnumguiasada,cdescfinanporc,cdescfinanmonto,ccopiaoc)values('" + Frm_Padre._Str_GroupComp + "','" + _Txt_Rec.Text.Trim() + "','" + _Txt_Fac.Text.Trim() + "','" + _Cls_Formato._Mtd_fecha(_Dpt_FechaFac.Value) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_MontoSinImpuesto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Descuento) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDecimal(_Txt_Inven.Text)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_SubTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_TotalImpuesto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_TotalFactura) + "','" + _Str_Proveedor + "','" + _Cls_Formato._Mtd_fecha(_Dpt_FechaFacVen.Value) + "','" + _Str_NumControl + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_Grabada) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Base_Excenta) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_Alicuota) + "','" + _Cls_Formato._Mtd_fecha(_Dpt_FechaEmiFac.Value) + "','" + _Txt_Observacion.Text.Trim().ToUpper() + "','" + _Txt_GuiaSada.Text.Trim().ToUpper() + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDecimal(_Num_DescFinanciero.Value)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dcm_TotalDescFinan) + "','" + _Str_OrdenCompra + "')";
                                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                                    _Mtd_SubTotalCompra(_Txt_Rec.Text.Trim(), _Txt_Fac.Text.Trim());
                                    _Txt_Fac.Tag = _Txt_Fac.Text;
                                    _Txt_NumCtrl.Tag = _Str_NumControl;
                                    _Str_Factura = _Txt_Fac.Text.Trim();
                                    if (_Bol_Guardado)
                                    {
                                        _Bt_Copiar.Enabled = false;
                                        _Bt_Depurar.Enabled = false;
                                        _Bt_Guardar.Enabled = false;
                                        _Chk_Descuento.Checked = _Rb_R1.Checked | _Rb_R2.Checked;
                                        _Chk_Descuento.Enabled = false;
                                        _Num_DescFinanciero.Enabled = false;
                                        _Rb_R1.Enabled = false;
                                        _Rb_R2.Enabled = false;
                                        _Bt_Finalizar.Enabled = _Int_Switch == 0;
                                        if (_Bol_FacturaMalCargarda)
                                        {
                                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                                            _Mtd_Actualizar();
                                            _Mtd_Inicializar();
                                            _Mtd_MostrarFactura(_Str_Factura, _Str_Proveedor, true);
                                            if (_Dg_Grid.RowCount == 0)
                                            { this.Close(); }
                                            else
                                            { _Tb_Tab.SelectedIndex = 0; }
                                            MessageBox.Show("Se ha enviado la factura para ser verificada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            _Mtd_Actualizar();
                                            _Mtd_DasHabilitar_Bt_Fac();
                                            _Bt_Editar.Enabled = true;
                                            _Bt_Buscar.Enabled = true;
                                            _Mtd_MostrarFactura(_Str_Factura, _Str_Proveedor, false);
                                            MessageBox.Show("Los datos fueron guardados correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar el detalle de la factura", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar el detalle de la factura", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("La recepción ha sido cerrada por otro usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                this.Close();
            }
            Cursor = Cursors.Default;
        }
        private void _Mtd_ReadOnlyPMV()
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
            {
                _Dg_Row.Cells["cprecioventamax"].ReadOnly = !_Mtd_ObligatorioPMV(Convert.ToString(_Dg_Row.Cells["ProductoInterno"].Value).Trim());
            }
        }
        private void _Mtd_Editar()
        {
            _Mtd_RegresarFormato();
            _Dg_Grid2.ReadOnly = false;
            _Dg_Grid2.Columns[2].ReadOnly = true;
            _Dg_Grid2.Columns[3].ReadOnly = true;
            _Dg_Grid2.Columns[7].ReadOnly = true;
            _Dg_Grid2.Columns["CostoNeto"].ReadOnly = true;
            _Dg_Grid2.Columns["ccostobrutolote"].ReadOnly = true;
            _Dg_Grid2.Columns["cpreciolista"].ReadOnly = true;
            _Bt_Guardar.Enabled = true;
            _Bt_Copiar.Enabled = true;
            _Bt_Depurar.Enabled = true;
            _Txt_Fac.Enabled = true;
            _Txt_NumCtrlPref.Enabled = true;
            _Txt_NumCtrl.Enabled = true;
            _Txt_GuiaSada.Enabled = true;
            _Dpt_FechaFac.Enabled = true;
            _Dpt_FechaEmiFac.Enabled = true;
            _Dpt_FechaFacVen.Enabled = true;
            _Bt_Editar.Enabled = false;
            _Bt_Buscar.Enabled = false;
            _Bt_Finalizar.Enabled = false;
            _Txt_Observacion.Enabled = true;
            _Chk_Descuento.Enabled = true;
            _Rb_R1.Enabled = _Chk_Descuento.Checked;
            _Rb_R2.Enabled = _Chk_Descuento.Checked;
            _Num_DescFinanciero.Enabled = true;
            _Mtd_ReadOnlyPMV();
        }
        private void _Mtd_MostrarFactura(string _P_Str_Factura, string _P_Str_Proveedor, bool _Bol_MarCargada)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Inf_Varios _Frm_Inf = new Frm_Inf_Varios(3, _P_Str_Factura, _P_Str_Proveedor);
            if (_Bol_MarCargada)
            { _Frm_Inf.Name = "_Frm_FactMalCargada"; }
            Cursor = Cursors.Default;
            _Frm_Inf.MdiParent = this.MdiParent;
            _Frm_Inf.Dock = DockStyle.Fill;
            _Frm_Inf.Show();
        }
        private string _Mtd_MensajeCostonetoCostoBruto(string _P_Str_Producto, decimal _Dcm_CostoUnitario, decimal _Dcm_CostoBruto)
        {
            string _Str_Cadena = "SELECT dbo.Fnc_Formatear(ccostoneto_u1),dbo.Fnc_Formatear(ccostobruto_u1) FROM TPRODUCTO WHERE cproducto='" + _P_Str_Producto + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return "El costo unitario (" + _Dcm_CostoUnitario.ToString("#,##0.00") + " Bs) del producto '" + _P_Str_Producto + "' es mayor al costo bruto (" + _Dcm_CostoBruto.ToString("#,##0.00") + " Bs). ¿Desea agregarlo?";
            }
            else
            {
                return "El costo unitario es mayor al costo bruto. ¿Desea continuar?";
            }
        }
        private bool _Mtd_EvaluarCantCostoBruto2(decimal _Dcm_Precio, string _Str_Producto)
        {
            bool _Bol_Mayor = false;
            try
            {
                decimal _Dcm_PrecioCB = 0;
                string _Str_SentenciaSQL = "SELECT CCOSTOBRUTO_U1 FROM TPRODUCTO WHERE CPRODUCTO='"+_Str_Producto+"'";
                DataSet _Ds_DataSet = new DataSet();
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                foreach (DataRow _Dtw_Item in _Ds_DataSet.Tables[0].Rows)
                {
                    _Dcm_PrecioCB = Convert.ToDecimal(_Dtw_Item["CCOSTOBRUTO_U1"].ToString());
                }
                if (_Dcm_PrecioCB < Math.Round(_Dcm_Precio,2))
                {
                    _Bol_Mayor = true;
                }
            }
            catch
            {
            }
            return _Bol_Mayor;
        }
        private bool _Mtd_EvaluarCostoNetoCostoBruto(decimal _Dcm_CostoNeto, decimal _Dcm_CostoBruto)
        {
            bool _Bol_Mayor = false;
            try
            {
                //Redondeo 
                _Dcm_CostoBruto = Math.Round(_Dcm_CostoBruto, 2);
                _Dcm_CostoNeto = Math.Round(_Dcm_CostoNeto, 2);

                //Verificamos 
                if (_Dcm_CostoBruto < _Dcm_CostoNeto)
                {
                    _Bol_Mayor = true;
                }
            }
            catch
            {
            }
            return _Bol_Mayor;
        }
        private int _Mtd_Contar_Cajas()
        {
            int _Int_I = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
            {
                if (_Dg_Row.Cells[4].Value != null)
                {
                    _Int_I = _Int_I + Convert.ToInt32(_Dg_Row.Cells[4].Value.ToString());
                }
            }
            return _Int_I;
        }
        private int _Mtd_Contar_Unidades()
        {
            int _Int_I = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
            {
                if (_Dg_Row.Cells[5].Value != null)
                {
                    _Int_I = _Int_I + Convert.ToInt32(_Dg_Row.Cells[5].Value.ToString());
                }
            }
            return _Int_I;
        }
        private void _Mtd_Actualizar()
        {
            string _Str_Cadena = "";
            if (_Int_Switch == 0)
            { _Str_Cadena = "SELECT Factura, Fecha, Total, ctotmontsimp, ctotdescuento, cporcentajeinv as cporcinvendible, csubtotal, ctotalimp, ctotfactura, cidrecepcion, cdatevencimiento, cnumdocuctrl, Cajas, cunidades AS Unidades, cgroupcomp, cnotarecepcion, cproveedor, ccopiaoc, cfirmado,cdateemifactura,cnumguiasada,ISNULL(cdescfinanporc,0) AS cdescfinanporc,ISNULL(cdescfinanmonto,0) AS cdescfinanmonto FROM VST_RECEPFACTURAS WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _Txt_Rec.Text.Trim() + "' AND ccargfactura='0'"; }
            else if (_Int_Switch == 1)
            { _Str_Cadena = "SELECT Factura, Fecha, Total, ctotmontsimp, ctotdescuento, cporcentajeinv as cporcinvendible, csubtotal, ctotalimp, ctotfactura, cidrecepcion, cdatevencimiento, cnumdocuctrl, Cajas, cunidades AS Unidades, cgroupcomp, cnotarecepcion, cproveedor, ccopiaoc, cfirmado,cdateemifactura,cnumguiasada,ISNULL(cdescfinanporc,0) AS cdescfinanporc,ISNULL(cdescfinanmonto,0) AS cdescfinanmonto FROM VST_RECEPFACTURAS WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _Txt_Rec.Text.Trim() + "' AND ccargfactura='2' AND cfactverif='2'"; }
            else
            { _Str_Cadena = "SELECT Factura, Fecha, Total, ctotmontsimp, ctotdescuento, cporcentajeinv as cporcinvendible, csubtotal, ctotalimp, ctotfactura, cidrecepcion, cdatevencimiento, cnumdocuctrl, Cajas, cunidades AS Unidades, cgroupcomp, cnotarecepcion, cproveedor, ccopiaoc, cfirmado,cdateemifactura,cnumguiasada,ISNULL(cdescfinanporc,0) AS cdescfinanporc,ISNULL(cdescfinanmonto,0) AS cdescfinanmonto FROM VST_RECEPFACTURAS WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _Txt_Rec.Text.Trim() + "' AND ccargfactura='1'"; }
            _Dg_Grid.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0];
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid2.ReadOnly = true;
            int _Int_i = 0;
            foreach (DataGridViewColumn _Gg_Col in _Dg_Grid.Columns)
            {
                if (_Int_i > 2 & _Int_i != 12 & _Int_i != 13)
                {
                    _Gg_Col.Visible = false;
                }
                _Int_i++;
            }
        }
        private string _Mtd_CostoUnitario(string _P_Str_Recepcion, string _P_Str_Factura, string _P_Str_Producto)
        {
            string _Str_Cadena = "SELECT dbo.Fnc_Formatear(((cpresioprocarg-ISNULL(cdescuento1,0))/((cempaques*(ccontenidoma1/ccontenidoma2))+cunidades))*(ccontenidoma1/ccontenidoma2)) FROM TPRODUCTO INNER JOIN TRECEPCIONDFD ON TPRODUCTO.cproducto = TRECEPCIONDFD.cproducto WHERE TRECEPCIONDFD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TRECEPCIONDFD.cidrecepcion='" + _P_Str_Recepcion + "' AND cnfacturapro='" + _P_Str_Factura + "' AND TRECEPCIONDFD.cproducto='" + _P_Str_Producto + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim();
        }
        private string _Mtd_MostrarObservacion(string _P_Str_Recepcion, string _P_Str_Factura)
        {
            string _Str_Cadena = "SELECT cobservacion FROM TRECEPCIONDFM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _P_Str_Recepcion + "' AND cnfacturapro='" + _P_Str_Factura + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim();
        }
        private bool _Mtd_TodasFactCorrectas(string _P_Str_Recepcion)
        {
            string _Str_Cadena = "SELECT cnfacturapro FROM TRECEPCIONDFM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _P_Str_Recepcion + "'";
            int _Int_TotalFacturas = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count;
            _Str_Cadena = "SELECT cnfacturapro FROM TRECEPCIONDFM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _P_Str_Recepcion + "' AND cfactverif='1'";
            int _Int_TotalCorrectas = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count;
            return _Int_TotalFacturas == _Int_TotalCorrectas;
        }
        private void _Mtd_MostrarDet()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Inicializar();
                _Bt_Guardar.Enabled = false;
                _Bt_Copiar.Enabled = false;
                _Bt_Buscar.Enabled = true;
                _Bt_Editar.Enabled = true;
                _Bt_Depurar.Enabled = false;
                _Txt_Fac.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString();
                _Txt_Fac.Tag = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString();
                _Txt_Observacion.Text = _Mtd_MostrarObservacion(_Txt_Rec.Text.Trim(), _Txt_Fac.Text.Trim());
                //-----------
                if (Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[11].Value).Trim() != "NA")
                {
                    string _Str_NumDocContrl = Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[11].Value).Trim();
                    _Txt_NumCtrlPref.Text = _Str_NumDocContrl.Substring(0, _Str_NumDocContrl.IndexOf("-"));
                    _Txt_NumCtrl.Text = _Str_NumDocContrl.Substring(_Str_NumDocContrl.IndexOf("-") + 1);
                    _Txt_NumCtrl.Tag = _Str_NumDocContrl;
                }
                //-----------
                _Txt_GuiaSada.Text = Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cnumguiasada"].Value).Trim();
                _Txt_Cajas.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[12].Value.ToString();
                _Txt_Unidades.Text = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[13].Value.ToString();
                _Str_OrdenCompra =Convert.ToString(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[17].Value);
                string _Str_Cadena = "SELECT TRECEPCIONDFD.ccodfabrica, '' AS campo, VST_PRODUCTOS.cproducto, RTRIM(VST_PRODUCTOS.produc_descrip) " +
                "+ N' ' + RTRIM(VST_PRODUCTOS.produc_descrip_2) AS cnamef, TRECEPCIONDFD.cempaques, TRECEPCIONDFD.cunidades, " +
                "dbo.Fnc_Formatear(TRECEPCIONDFD.cpresioprocarg) AS cpresioprocarg, dbo.Fnc_Formatear(TRECEPCIONDFD.cdescuento1) AS cdescuento1, " +
                "dbo.Fnc_Formatear(TRECEPCIONDFD.cpreciouni) AS cpreciouni, VST_PRODUCTOS.ccontenidoma1, VST_PRODUCTOS.ccontenidoma2, " +
                "VST_PRODUCTOS.ccodfabrica as CodFabrica,ISNULL(ctipodescuento,0) AS ctipodescuento,ISNULL(cporcmontodesc,0) AS cporcmontodesc,ISNULL(ccostobrutolote,0) AS ccostobrutolote,ISNULL(cprecioventamax,0) AS cprecioventamax,ISNULL(TRECEPCIONDFD.cpreciolista,0) AS cpreciolista FROM TRECEPCIONDFD INNER JOIN " +
                "VST_PRODUCTOS ON TRECEPCIONDFD.cproveedor = VST_PRODUCTOS.cproveedor AND " +
                "TRECEPCIONDFD.cproducto = VST_PRODUCTOS.cproducto " +
                "WHERE TRECEPCIONDFD.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' and TRECEPCIONDFD.cnfacturapro = '" + _Txt_Fac.Text + "' and TRECEPCIONDFD.cidrecepcion='" + _Txt_Rec.Text.Trim() + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                int _Int_i=0;
                object[] _Obj=new object[15];
                bool _Bol_DescuentoPorc = false;
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Obj[0] = _Row["CodFabrica"].ToString();
                    _Obj[1] = "";
                    _Obj[2] = _Row["cproducto"].ToString();
                    _Obj[3] = _Row["cnamef"].ToString();
                    _Obj[4] = _Row["cempaques"].ToString();
                    _Obj[5] = _Row["cunidades"].ToString();
                    _Obj[7] = _Mtd_CostoUnitario(_Txt_Rec.Text.Trim(), _Txt_Fac.Text.Trim(), _Row["cproducto"].ToString().Trim());
                    if (_Row["ctipodescuento"].ToString().Trim() == "1")
                    { _Obj[8] = _Row["cporcmontodesc"].ToString(); _Bol_DescuentoPorc = true; }
                    else
                    { _Obj[8] = _Row["cdescuento1"].ToString(); }
                    _Obj[6] = _Row["cpresioprocarg"].ToString();
                    _Obj[9] = _Row["ccontenidoma1"].ToString();
                    _Obj[10] = _Row["ccontenidoma2"].ToString();
                    var _Dcm_cprecioventamax = Convert.ToDecimal(_Row["cprecioventamax"].ToString());
                    _Obj[11] = _Mtd_RetornarCostoNeto(_Row["cproducto"].ToString(), _Dcm_cprecioventamax);
                    _Obj[12] = _Row["ccostobrutolote"].ToString();
                    _Obj[13] = _Row["cprecioventamax"].ToString();
                    _Obj[14] = _Row["cpreciolista"].ToString();
                    _Dg_Grid2.Rows.Add(_Obj);
                    _Int_i++;
                }
                _Dg_Grid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                _Txt_Inven.Text = Convert.ToDecimal(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[5].Value.ToString()).ToString("#,##0.00");
                _Txt_TotalSinImp.Text = Convert.ToDecimal(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[3].Value.ToString()).ToString("#,##0.00");
                if (Convert.ToDecimal(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[4].Value.ToString()) > 0)
                {
                    _Chk_Descuento.CheckedChanged -= new EventHandler(_Chk_Descuento_CheckedChanged);
                    _Chk_Descuento.Checked = true;
                    _Dg_Grid2.Columns[8].Visible = true;
                    _Chk_Descuento.CheckedChanged += new EventHandler(_Chk_Descuento_CheckedChanged);
                    if (_Bol_DescuentoPorc)
                    {
                        _Rb_R1.CheckedChanged -= new EventHandler(_Rb_R1_CheckedChanged);
                        _Rb_R1.Checked = true;
                        _Rb_R1.CheckedChanged += new EventHandler(_Rb_R1_CheckedChanged);
                    }
                    else
                    {
                        _Rb_R2.CheckedChanged -= new EventHandler(_Rb_R2_CheckedChanged);
                        _Rb_R2.Checked = true;
                        _Rb_R2.CheckedChanged += new EventHandler(_Rb_R2_CheckedChanged);
                    }
                }
                _Txt_DescComer.Text = Convert.ToDecimal(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[4].Value.ToString()).ToString("#,##0.00");
                _Txt_SubTotal.Text = Convert.ToDecimal(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[6].Value.ToString()).ToString("#,##0.00");
                decimal _Dcm_Excento_Fact = 0;
                _Str_Cadena = "SELECT ISNULL(cbaseexcenta,0) FROM TRECEPCIONDFM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cnfacturapro='" + _Txt_Fac.Text.Trim() + "' and cproveedor='" + _Str_Proveedor + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Dcm_Excento_Fact = Convert.ToDecimal(_Ds.Tables[0].Rows[0][0].ToString());
                }
                _Txt_MontoExento.Text = _Dcm_Excento_Fact.ToString("#,##0.00");
                _Txt_Impuesto.Text = Convert.ToDecimal(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[7].Value.ToString()).ToString("#,##0.00");
                _Txt_Total.Text = Convert.ToDecimal(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[8].Value.ToString()).ToString("#,##0.00");
                _Dpt_FechaFac.Value = Convert.ToDateTime(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[1].Value.ToString());
                _Dpt_FechaEmiFac.Value = Convert.ToDateTime(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[19].Value.ToString());
                _Dpt_FechaFacVen.Value = Convert.ToDateTime(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[10].Value.ToString());
                _Num_DescFinanciero.ValueChanged -= new EventHandler(_Num_DescFinanciero_ValueChanged);
                _Num_DescFinanciero.Value = Convert.ToDecimal(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cdescfinanporc"].Value);
                _Num_DescFinanciero.ValueChanged += new EventHandler(_Num_DescFinanciero_ValueChanged);
                _Txt_DescFinan.Text = Convert.ToDecimal(_Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells["cdescfinanmonto"].Value).ToString("#,##0.00");
                _Dg_Grid2.Rows.Add();
                _Dg_Grid2.Columns[2].ReadOnly = true;
                _Dg_Grid2.Columns[3].ReadOnly = true;
                _Dg_Grid2.Columns[7].ReadOnly = true;
                _Dg_Grid2.Columns["CostoNeto"].ReadOnly = true;
                _Dg_Grid2.Columns["ccostobrutolote"].ReadOnly = true;
                _Dg_Grid2.Columns["cpreciolista"].ReadOnly = true;
                Cursor = Cursors.Default;
            }
            catch { Cursor = Cursors.Default; }
        }
        private void _Mtd_RegresarFormato()
        {
            foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
            {
                try
                {
                    if (_Dg_Row.Cells[5].Value != null)
                    {
                        _Dg_Row.Cells[5].Value = _Dg_Row.Cells[5].Value.ToString().Replace(".", "");
                    }
                }
                catch { }
            }
        }
        private void _Mtd_Cargar_lista()
        {
            //Si el campo ccargfactura esta marcado en uno (1) quiere decir que tods las facturas estan bien cargadas.
            _Lst_FAC.Items.Clear();
            string _Str_Cadena = "SELECT cnfacturapro FROM TRECEPCIONM INNER JOIN TRECEPCIONDFM ON TRECEPCIONM.cgroupcomp = TRECEPCIONDFM.cgroupcomp AND TRECEPCIONM.cidrecepcion = TRECEPCIONDFM.cidrecepcion AND TRECEPCIONM.cproveedor = TRECEPCIONDFM.cproveedor WHERE TRECEPCIONM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TRECEPCIONM.cidrecepcion='" + _Txt_Rec.Text.Trim() + "' AND ccargfactura='1'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Lst_FAC.Items.Add(_Row[0].ToString());
            }
        }
        private void _Mtd_OCR()
        {
            DataSet _Ds;
            _Lst_OC.Items.Clear();
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cnumoc FROM TORDENCOMPM WHERE cdelete = '0' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _Str_Proveedor + "' and ccerrada = '0' AND (TORDENCOMPM.cefectividad<=(Select cmaxefectivioc from TCONFIGCOMP where ccompany='" + Frm_Padre._Str_Comp + "'))");
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                _Lst_OC.Items.Add(_Row[0].ToString());
            }
            foreach (object _Obj_Factura in _Lst_FAC.Items)
            {
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT TRECEPCIONDFM.ccopiaoc FROM TRECEPCIONDFM INNER JOIN TORDENCOMPM ON TORDENCOMPM.CNUMOC=TRECEPCIONDFM.CCOPIAOC AND TORDENCOMPM.CPROVEEDOR=TRECEPCIONDFM.CPROVEEDOR WHERE TORDENCOMPM.cdelete = '0' and TORDENCOMPM.ccompany='" + Frm_Padre._Str_Comp + "' and TORDENCOMPM.cproveedor='" + _Str_Proveedor + "' and TORDENCOMPM.ccerrada = '1' AND TRECEPCIONDFM.cnfacturapro='"+_Obj_Factura.ToString()+"'");
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Lst_OC.Items.Add(_Row[0].ToString());
                }
            }
        }
        private void _Mtd_Actulizar_TRECEPCIONRELDIF()
        {
            string _Str_Cadena = "Select DISTINCT cnfacturapro from TRECEPCIONDDDOCF where cidrecepcion='" + _Txt_Rec.Text.Trim() + "' and cproveedor='" + _Str_Proveedor + "' and cnecfirma='1'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                Program._MyClsCnn._mtd_conexion._Mtd_modificar("TRECEPCIONRELDIF", "cnecfirma='1'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_Rec.Text.Trim() + "' and cnfacturapro='" + _Row[0].ToString() + "'");
            }
        }
        string _Str_OC_Sep = "";
        string _Str_FAC_Sep = "";
        private void _Mtd_Separar_OC_FAC_NUEVO(string _P_Str_Item)
        {
            _Str_OC_Sep = "";
            _Str_FAC_Sep = "";
            int _Int_i = _P_Str_Item.Trim().IndexOf(" -> ");
            _Int_i++;
            _Str_OC_Sep = _P_Str_Item.Substring(0, _Int_i).Trim();
            _Str_FAC_Sep = _P_Str_Item.Substring(_Int_i + 2).Trim();
        }
        private void _Mtd_IniLists()
        {
            _Int_N = 0;
            _Rbt_OC.Checked = false; _Rbt_FAC.Checked = false; _Rbt_Un.Checked = false;
            _Rbt_OC.Enabled = false; _Rbt_FAC.Enabled = false; _Rbt_Un.Enabled = false;
            _Lst_OC.Enabled = false;
            _Lst_FAC.Enabled = false;
            _Mtd_Cargar_lista();
            _Mtd_OCR();
            if (_Lst_FAC.Items.Count == 1)
            { _Rbt_FAC.Enabled = true; _Rbt_Un.Enabled = true; }
            else if (_Lst_FAC.Items.Count > 1)
            { _Rbt_OC.Enabled = true; }
            _Lst_OC_FAC.Items.Clear();
        }
        private int _Mtd_Validar_Copia_OC()
        {
            string _Str_Cadena ="";
            DataSet _Ds = new DataSet();
            if (_Int_N == 2 | _Int_N == 3)
            {
                foreach (object _Ob in _Lst_FAC.CheckedItems)
                {
                    _Str_Cadena = "Select ccopiaoc from TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_Rec.Text.Trim() + "' and cnfacturapro='" + _Ob.ToString() + "' and cproveedor='" + _Str_Proveedor + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows[0][0] == System.DBNull.Value)
                    {
                        return 0;
                    }
                    else
                    {
                        bool _Bol_Sw = false;
                        foreach (object _Ob2 in _Lst_OC.CheckedItems)
                        {
                            if (_Ds.Tables[0].Rows[0][0].ToString().Trim() == _Ob2.ToString().Trim())
                            { _Bol_Sw = true; }
                        }
                        if (!_Bol_Sw)
                        { return Convert.ToInt32(_Ds.Tables[0].Rows[0][0].ToString().Trim()); }                        
                    }
                }
                return 0;
            }
            return 0;
        }

        private bool _Mtd_Validar_Selecion()
        {
            if (_Rbt_FAC.Checked)
            {
                if (_Lst_FAC.CheckedItems.Count == 1 & _Lst_OC.CheckedItems.Count > 1)
                { return true; }
                else
                { return false; }
            }
            else if (_Rbt_OC.Checked)
            {
                if (_Lst_FAC.CheckedItems.Count > 1 & _Lst_OC.CheckedItems.Count == 1)
                { return true; }
                else
                { return false; }
            }
            else if (_Rbt_Un.Checked)
            {
                if (_Lst_FAC.CheckedItems.Count == 1 & _Lst_OC.CheckedItems.Count == 1)
                { return true; }
                else
                { return false; }
            }
            else
            { return false; }
        }
        private void _Mtd_CopiarOC(string _P_Str_OC)
        {
            object[] _Obj = new object[15];
            DataSet _Ds_A;
            decimal _Dcm_Empaques = 0, _Dcm_EmpaquesNew = 0, _Dcm_Unidades=0, _Dcm_UnidadesNew=0, _Dcm_Presio=0;
            decimal _Dcm_CantTempOC = 0;
            decimal _Dcm_CantTUniOC = 0;
            string _Str_TpoOC = "";
            bool _Bol_Agregar = true;
            _Dg_Grid2.Rows.Clear();
            string _Str_Sql = "SELECT ctipodocumentoc FROM TCONFIGCOMP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_TpoOC = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocumentoc"]);
            }
            _Str_Sql = "SELECT TORDENCOMPD.ccodproveedor, VST_PRODUCTOS.produc_descrip, VST_PRODUCTOS.produc_descrip_2, " +
              "TORDENCOMPD.ccantunidadma1, TORDENCOMPD.ccantunidadma2, TORDENCOMPD.ctotcostosimp, VST_PRODUCTOS.cproducto, " +
              "TORDENCOMPD.ccostoneto_u1, VST_PRODUCTOS.ccontenidoma2, VST_PRODUCTOS.ccontenidoma1, " +
              "VST_PRODUCTOS.cunidadma2, dbo._fnc_DivOCEmpaques(TORDENCOMPD.ctotcostosimp, TORDENCOMPD.ccantunidadma1, " +
              "TORDENCOMPD.ccantunidadma2, TORDENCOMPD.cproducto) AS CPRECIOUNI,VST_PRODUCTOS.cunidad2, " +
              "VST_PRODUCTOS.ccodfabrica as CodFabrica,TORDENCOMPD.ccostobruto_u1 AS ccostobrutolote,CASE WHEN (cregpmv='1' or cregpmv='2') THEN ISNULL(TORDENCOMPD.cprecioventamax,0) ELSE 0 END AS cprecioventamax,ISNULL((SELECT TOP 1 cpreciolista FROM TPRODUCTOD WHERE TPRODUCTOD.cproducto=VST_PRODUCTOS.cproducto ORDER BY cidproductod DESC),VST_PRODUCTOS.cpreciolista) AS cpreciolista,ISNULL(cregpmv,0) AS cregpmv FROM TORDENCOMPD INNER JOIN " +
              "VST_PRODUCTOS ON TORDENCOMPD.cproveedor = VST_PRODUCTOS.cproveedor AND " +
              "TORDENCOMPD.cgrupo = VST_PRODUCTOS.cgrupo AND TORDENCOMPD.csku = VST_PRODUCTOS.csku AND " +
              "TORDENCOMPD.csubgrupo = VST_PRODUCTOS.csubgrupo AND TORDENCOMPD.cproducto = VST_PRODUCTOS.cproducto " +
              "WHERE VST_PRODUCTOS.cactivate='1' AND TORDENCOMPD.cdelete = 0 AND TORDENCOMPD.ccompany='" + Frm_Padre._Str_Comp + "' AND TORDENCOMPD.cproveedor='" + _Str_Proveedor + "' AND TORDENCOMPD.cnumoc='" + _P_Str_OC + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            int _Int_Index = 0;
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    _Dcm_CantTempOC = 0;
                    _Str_Sql = "SELECT ccantidad_u1,ccantidad_u2 FROM TTEMPOC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ctdocument='" + _Str_TpoOC + "' AND cnumdocu='" + _P_Str_OC + "' AND cproveedor='" + _Str_Proveedor + "' AND cproducto='" + Convert.ToString(_Row["cproducto"]) + "' AND csuma=0";
                    _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    if (_Ds_A.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(_Ds_A.Tables[0].Rows[0]["ccantidad_u1"]).Trim() != "" || Convert.ToString(_Ds_A.Tables[0].Rows[0]["ccantidad_u2"]).Trim() != "")
                        {
                            _Dcm_CantTempOC = Convert.ToDecimal(_Ds_A.Tables[0].Rows[0]["ccantidad_u1"]);
                            _Dcm_CantTUniOC = Convert.ToDecimal(_Ds_A.Tables[0].Rows[0]["ccantidad_u2"]);
                        }
                        _Dcm_Empaques = Convert.ToDecimal(_Row["ccantunidadma1"]);
                        _Dcm_Unidades = Convert.ToDecimal(_Row["ccantunidadma2"]);
                        decimal _Dcm_Calculo = _Dcm_Empaques * (Convert.ToDecimal(_Row["ccontenidoma1"]) / Convert.ToDecimal(_Row["ccontenidoma2"]));
                        _Dcm_Calculo += _Dcm_Unidades;
                        decimal _Dcm_Calculo_2 = _Dcm_CantTempOC * (Convert.ToDecimal(_Row["ccontenidoma1"]) / Convert.ToDecimal(_Row["ccontenidoma2"]));
                        _Dcm_Calculo_2 += _Dcm_CantTUniOC;
                        decimal _Dcm_Calculo_3 = _Dcm_Calculo - _Dcm_Calculo_2;
                        if (_Dcm_Calculo_3 > 0)
                        {
                            _Dcm_EmpaquesNew = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidCajas(Convert.ToString(_Row["cproducto"]), Convert.ToInt32(_Dcm_Calculo_3), 0));
                            _Dcm_UnidadesNew = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_ConvertUnidSobrante(Convert.ToString(_Row["cproducto"]), Convert.ToInt32(_Dcm_Calculo_3)));
                            _Obj[0] = _Row["CodFabrica"].ToString();
                            _Obj[1] = "";
                            _Obj[2] = _Row["cproducto"].ToString();
                            _Obj[3] = _Row["produc_descrip"].ToString().Trim() + " " + _Row["produc_descrip_2"].ToString().Trim();
                            _Obj[4] = _Dcm_EmpaquesNew.ToString();
                            _Obj[5] = _Dcm_UnidadesNew.ToString();
                            if (_Row["ccostoneto_u1"] != System.DBNull.Value)
                            {
                                if (_Dcm_EmpaquesNew > 0)
                                {
                                    _Dcm_Presio = Convert.ToDecimal(_Row["ccostoneto_u1"].ToString().Trim()) * _Dcm_EmpaquesNew;
                                    _Obj[6] = _Dcm_Presio;
                                    _Obj[7] = Convert.ToDecimal(_Row["ccostoneto_u1"].ToString().Trim()).ToString("#,##0.00");
                                }
                                else if (_Dcm_EmpaquesNew == 0 && _Dcm_UnidadesNew > 0)
                                {
                                    if (_Row["cunidad2"].ToString() == "1")
                                    {
                                        int _Int_ContenidoUn = Convert.ToInt32(_Row["ccontenidoma1"].ToString()) / Convert.ToInt32(_Row["ccontenidoma2"].ToString());
                                        if (_Int_ContenidoUn > 0)
                                        {
                                            _Dcm_Presio = (Convert.ToDecimal(_Row["ccostoneto_u1"].ToString().Trim()) / _Int_ContenidoUn) * _Dcm_UnidadesNew;
                                            _Obj[6] = _Dcm_Presio;
                                            _Obj[7] = Convert.ToDecimal(_Row["ccostoneto_u1"].ToString().Trim()).ToString("#,##0.00");
                                        }
                                    }
                                }
                            }
                            _Obj[8] = null;
                            _Obj[9] = _Row["ccontenidoma1"].ToString();
                            _Obj[10] = _Row["ccontenidoma2"].ToString();
                            var _Dcm_cprecioventamax = Convert.ToDecimal(_Row["cprecioventamax"].ToString());
                            _Obj[11] = _Mtd_RetornarCostoNeto(_Row["cproducto"].ToString(), _Dcm_cprecioventamax);
                            _Obj[12] = _Row["ccostobrutolote"].ToString();
                            _Obj[13] = _Row["cprecioventamax"].ToString();
                            _Obj[14] = _Row["cpreciolista"].ToString();
                            _Bol_Agregar = true;
                            //if (_Mtd_EvaluarCantCostoBruto(Convert.ToDecimal(_Obj[7]), Convert.ToString(_Obj[2])))
                            //{
                            //    if (MessageBox.Show(_Mtd_Mensaje(Convert.ToString(_Obj[2]), Convert.ToDecimal(_Obj[7])), "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                            //    {
                            //        _Bol_Agregar = false;
                            //    }
                            //}
                            decimal _Dcm_Uni = Convert.ToDecimal(_Row["ccostoneto_u1"].ToString());
                            decimal _Dcm_CostoBruto = Convert.ToDecimal(_Row["ccostobrutolote"].ToString());
                            if (_Mtd_EvaluarCostoNetoCostoBruto(_Dcm_Uni, _Dcm_CostoBruto))
                            {
                                if (MessageBox.Show(_Mtd_MensajeCostonetoCostoBruto(Convert.ToString(_Obj[2]), _Dcm_Uni, _Dcm_CostoBruto), "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                                {
                                    _Bol_Agregar = false;
                                }
                            }
                            if (_Bol_Agregar)
                            {
                                _Dg_Grid2.Rows.Add(_Obj);
                                _Dg_Grid2["cprecioventamax", _Int_Index].ReadOnly = _Row["cregpmv"].ToString().Trim() == "0";
                                if (_Row["cunidad2"].ToString() == "1")
                                {
                                    _Dg_Grid2[5, _Int_Index].ReadOnly = false;
                                }
                                else
                                {
                                    _Dg_Grid2[5, _Int_Index].ReadOnly = true;
                                }
                                _Int_Index++;
                            }
                        }
                    }
                    else
                    {
                        decimal _Dcm_Uni = 0;
                        decimal _Dcm_CostoBruto = 0;
                        _Obj[0] = _Row["CodFabrica"].ToString();
                        _Obj[1] = "";
                        _Obj[2] = _Row["cproducto"].ToString();
                        _Obj[3] = _Row["produc_descrip"].ToString().Trim() + " " + _Row["produc_descrip_2"].ToString().Trim();
                        _Obj[4] = _Row["ccantunidadma1"].ToString();
                        _Obj[5] = _Row["ccantunidadma2"].ToString();
                        _Obj[6] = _Row["ctotcostosimp"].ToString();
                        if (_Row["ccostoneto_u1"] != System.DBNull.Value)
                        { _Dcm_Uni = Convert.ToDecimal(_Row["CPRECIOUNI"].ToString()); }
                        _Obj[7] = _Dcm_Uni.ToString("#,##0.00");
                        _Obj[8] = null;
                        _Obj[9] = _Row["ccontenidoma1"].ToString();
                        _Obj[10] = _Row["ccontenidoma2"].ToString();
                        var _Dcm_cprecioventamax = Convert.ToDecimal(_Row["cprecioventamax"].ToString());
                        _Obj[11] = _Mtd_RetornarCostoNeto(_Row["cproducto"].ToString(), _Dcm_cprecioventamax);
                        _Obj[12] = _Row["ccostobrutolote"].ToString();
                        _Obj[13] = _Row["cprecioventamax"].ToString();
                        _Obj[14] = _Row["cpreciolista"].ToString();
                        _Bol_Agregar = true;
                        //if (_Mtd_EvaluarCantCostoBruto(Convert.ToDecimal(_Obj[7]), Convert.ToString(_Obj[2])))
                        //{
                        //    if (MessageBox.Show(_Mtd_Mensaje(Convert.ToString(_Obj[2]), Convert.ToDecimal(_Obj[7])), "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        //    {
                        //        _Bol_Agregar = false;
                        //    }
                        //}

                        _Dcm_CostoBruto = Convert.ToDecimal(_Row["ccostobrutolote"].ToString());
                        if (_Mtd_EvaluarCostoNetoCostoBruto(_Dcm_Uni, _Dcm_CostoBruto))
                        {
                            if (MessageBox.Show(_Mtd_MensajeCostonetoCostoBruto(Convert.ToString(_Obj[2]), _Dcm_Uni, _Dcm_CostoBruto), "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                            {
                                _Bol_Agregar = false;
                            }
                        }

                        if (_Bol_Agregar)
                        {
                            _Dg_Grid2.Rows.Add(_Obj);
                            _Dg_Grid2["cprecioventamax", _Int_Index].ReadOnly = _Row["cregpmv"].ToString().Trim() == "0";
                            if (_Row["cunidad2"].ToString() == "1")
                            {
                                _Dg_Grid2[5, _Int_Index].ReadOnly = false;
                            }
                            else
                            {
                                _Dg_Grid2[5, _Int_Index].ReadOnly = true;
                            }
                            _Int_Index++;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No existen productos activos en la orden de compra seleccionada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            _Txt_Cajas.Text = _Mtd_Contar_Cajas().ToString();
            _Txt_Unidades.Text = _Mtd_Contar_Unidades().ToString();
            _Dg_Grid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid2.Rows.Add();
        }
        private void _Mtd_FechaVenc()
        {
            if (_Str_OrdenCompra.Trim().Length > 0)
            {
                string _Str_FechaVenc = "Select cfpago from TORDENCOMPM where cnumoc='" + _Str_OrdenCompra + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cproveedor='" + _Str_Proveedor + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_FechaVenc).Tables[0].Rows.Count > 0)
                {
                    DataRow _Row = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_FechaVenc).Tables[0].Rows[0];
                    _Str_FechaVenc = "Select cdiacredito from TDIACREDITO where ciddcredito='" + _Row[0].ToString().Trim() + "' and cproveedor='" + _Str_Proveedor + "'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_FechaVenc).Tables[0].Rows.Count > 0)
                    {
                        _Row = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_FechaVenc).Tables[0].Rows[0];
                        if (_Row[0] != System.DBNull.Value)
                        {
                            _Dpt_FechaFacVen.Value = _Dpt_FechaFac.Value.AddDays(Convert.ToDouble(_Row[0].ToString().Trim()));
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Verifica si no se le ha cargado ninguna factura
        /// </summary>
        private bool _Mtd_SoloMaestra(string _P_Str_Recepcion)
        {
            string _Str_Cadena = "SELECT cidrecepcion FROM TRECEPCIONDFM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _P_Str_Recepcion + "'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count == 0;
        }
        private void _Mtd_Inicializar()
        {
            _Mtd_Habilitar_Bt_Fac();
            _Mtd_DasHabilitar_Bt_Fac();
        }
        private void _Mtd_EliminarDesmarcados()
        {
            bool _Bol_Borrar = false;
            if (_Dg_Grid2.Rows.Count > 0)
            {
                foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
                {
                    if (_Dg_Row.DefaultCellStyle.BackColor == Color.Gold)
                    {
                        _Bol_Borrar = true;
                    }
                }
            }
            if (_Bol_Borrar)
            {
                if (MessageBox.Show("Se procederá a eliminar los productos desmarcados en la depuración, ¿desea continuar?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool _Bol_Seguir = false;
                A:
                    _Bol_Seguir = false;
                    foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
                    {
                        if (_Dg_Row.DefaultCellStyle.BackColor != Color.Gold)
                        {
                            _Dg_Grid2.Rows.Remove(_Dg_Row);
                            _Bol_Seguir = true;
                            break;
                        }
                    }
                    if (_Bol_Seguir)
                    {
                        goto A;
                    }
                    foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
                    {
                        _Dg_Row.DefaultCellStyle.BackColor = Color.White;
                        _Dg_Row.Cells["Column9"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        _Dg_Row.Cells["Unidades"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        _Dg_Row.Cells["Column10"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        _Dg_Row.Cells["Column1"].Style.BackColor = Color.FromArgb(192, 192, 255);
                        _Dg_Row.Cells["Column14"].Style.BackColor = Color.FromKnownColor(KnownColor.Control);
                    }
                    _Mtd_Totalizar();
                    _Dg_Grid2.Rows.Add();
                }
                else
                {
                    foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
                    {
                        _Dg_Row.DefaultCellStyle.BackColor = Color.White;
                        _Dg_Row.Cells["Column9"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        _Dg_Row.Cells["Unidades"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        _Dg_Row.Cells["Column10"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        _Dg_Row.Cells["Column1"].Style.BackColor = Color.FromArgb(192, 192, 255);
                        _Dg_Row.Cells["Column14"].Style.BackColor = Color.FromKnownColor(KnownColor.Control);
                    }
                }
            }
        }
        private void _Mtd_Buscar()
        {
            if (_Dg_Grid2.Rows.Count > 0)
            {
                string[] _Str_CodFabricaM = new string[_Str_Array.Length];
                string[] _Str_CodProductoM = new string[_Str_Array.Length];
                int _Int_I = 0;
                foreach (string _Str_String in _Str_Array)
                {
                    string[] _Str_Palabra = _Str_String.Split('|');
                    _Str_CodFabricaM[_Int_I] = _Str_Palabra[0];
                    _Str_CodProductoM[_Int_I] = _Str_Palabra[1];
                    _Int_I++;
                }
                int _Int_Index = Array.IndexOf(_Str_CodFabricaM, _Txt_Producto_Buscar.Text.ToUpper().Trim());
                int _Int_Index_1 = Array.IndexOf(_Str_CodProductoM, _Txt_Producto_Buscar.Text.ToUpper().Trim());
                if (_Int_Index != -1 || _Int_Index_1 != -1)
                {
                    if (_Int_Index != -1)
                    {
                        if (_Dg_Grid2.Rows[_Int_Index].Cells["Column8"] != null && _Dg_Grid2.Rows[_Int_Index].Cells["Column15"] != null && _Dg_Grid2.Rows[_Int_Index].Cells["ProductoInterno"] != null)
                        {
                            _Txt_CodProductoB.Text = _Dg_Grid2.Rows[_Int_Index].Cells["ProductoInterno"].Value.ToString();
                            _Txt_CodFabricaB.Text = _Dg_Grid2.Rows[_Int_Index].Cells["Column8"].Value.ToString();
                            _Txt_DescripcionB.Text = _Dg_Grid2.Rows[_Int_Index].Cells["Column15"].Value.ToString();
                            _Bt_Marcar.Enabled = true;
                            _Bt_Desmarcar.Enabled = true;
                            _Bt_Marcar.Focus();
                        }
                        else
                        {
                            _Bt_Marcar.Enabled = false;
                            _Bt_Desmarcar.Enabled = false;
                            MessageBox.Show("No hay registros cargados en la factura actual con el código ingresado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    if (_Int_Index_1 != -1)
                    {
                        if (_Dg_Grid2.Rows[_Int_Index_1].Cells["Column8"] != null && _Dg_Grid2.Rows[_Int_Index_1].Cells["Column15"] != null && _Dg_Grid2.Rows[_Int_Index_1].Cells["ProductoInterno"] != null)
                        {
                            _Txt_CodProductoB.Text = _Dg_Grid2.Rows[_Int_Index_1].Cells["ProductoInterno"].Value.ToString();
                            _Txt_CodFabricaB.Text = _Dg_Grid2.Rows[_Int_Index_1].Cells["Column8"].Value.ToString();
                            _Txt_DescripcionB.Text = _Dg_Grid2.Rows[_Int_Index_1].Cells["Column15"].Value.ToString();
                            _Bt_Marcar.Enabled = true;
                            _Bt_Desmarcar.Enabled = true;
                            _Bt_Marcar.Focus();
                        }
                        else
                        {
                            _Bt_Marcar.Enabled = false;
                            _Bt_Desmarcar.Enabled = false;
                            MessageBox.Show("No hay registros cargados en la factura actual con el código ingresado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    _Bt_Marcar.Enabled = false;
                    _Bt_Desmarcar.Enabled = false;
                    MessageBox.Show("No hay registros cargados en la factura actual con el código ingresado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                _Bt_Marcar.Enabled = false;
                _Bt_Desmarcar.Enabled = false;
                MessageBox.Show("No hay registros cargados en la factura actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private string _Mtd_NumeroControl(string _P_Str_NumCtrlPref, string _P_Str_NumCtrl)
        {
            if (_P_Str_NumCtrl.Trim().Length == 0)
            {
                return "NA";
            }
            else
            {
                string _Str_Pref = _P_Str_NumCtrlPref.Trim();
                string _Str_NumCtrl = "00000000";
                if (_P_Str_NumCtrlPref.Trim().Length == 0)
                {
                    _Str_Pref = "00";
                }
                else if (_P_Str_NumCtrlPref.Trim().Length == 1 & _MyUtilidad._Mtd_IsNumeric(_P_Str_NumCtrlPref.Trim()))
                {
                    _Str_Pref = "0" + _P_Str_NumCtrlPref.Trim();
                }
                _Str_NumCtrl = _Str_NumCtrl.Remove(0, _P_Str_NumCtrl.Trim().Length) + _P_Str_NumCtrl.Trim();
                return _Str_Pref + "-" + _P_Str_NumCtrl;//_Str_NumCtrl
            }
        }
        private bool _Mtd_VerifContTextBoxVarcharNoCero(TextBox _P_Txt_TextBox)
        {
            if (_P_Txt_TextBox.Text.Trim().Length > 0)
            {
                if (_Mtd_IsNumeric(_P_Txt_TextBox.Text))
                {
                    if (Convert.ToDecimal(_P_Txt_TextBox.Text) > 0)
                    { return true; }
                }
                else
                { return true; }
            }
            return false;
        }
        private bool _Mtd_VerifContTextBoxNumeric(TextBox _P_Txt_TextBox)
        {
            if (_P_Txt_TextBox.Text.Trim().Length > 0)
            {
                if (Convert.ToDecimal(_P_Txt_TextBox.Text) > 0)
                { return true; }
            }
            return false;
        }
        private void _Cmb_Fac_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
        }

        private void _Lst_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
        }
        private void _Bt_Evaluar_Click(object sender, EventArgs e)
        {
            _Bt_Evaluar.Enabled = false;
            Cursor = Cursors.WaitCursor;
            if (_Lst_OC_FAC.Items.Count > 0)
            {
                string[] _Str_Facturas;
                string _Str_Sentencia = "insert into TRECEPCIONTDIF (cgroupcomp,cidrecepcion,ctdiferencia) values('" + Frm_Padre._Str_GroupComp + "','" + _Txt_Rec.Text.Trim() + "','" + _Int_N.ToString() + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sentencia);
                _Str_Facturas = new string[_Lst_OC_FAC.Items.Count];
                int _Int_Index = 0;
                foreach (object _ObItem in _Lst_OC_FAC.Items)
                {
                    _Mtd_Separar_OC_FAC_NUEVO(_ObItem.ToString());
                    if (_Int_N == 2 | _Int_N == 3)
                    {
                        _Str_Sentencia = "insert into TRECEPCIONRELDIF (cgroupcomp,cidrecepcion,cnumoc,cnfacturapro) values('" + Frm_Padre._Str_GroupComp + "','" + _Txt_Rec.Text.Trim() + "','" + _Str_OC_Sep + "','" + _Str_FAC_Sep + "')";
                        _Str_Facturas[_Int_Index] = _Str_FAC_Sep;
                    }
                    else
                    {
                        _Str_Sentencia = "insert into TRECEPCIONRELDIF (cgroupcomp,cidrecepcion,cnumoc,cnfacturapro) values('" + Frm_Padre._Str_GroupComp + "','" + _Txt_Rec.Text.Trim() + "','" + _Str_FAC_Sep + "','" + _Str_OC_Sep + "')";
                        _Str_Facturas[_Int_Index] = _Str_OC_Sep;
                    }
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sentencia);
                    _Int_Index++;
                }
                SqlParameter[] paramsToStore = new SqlParameter[5];
                paramsToStore[0] = new SqlParameter("@cgroupcomp", SqlDbType.NVarChar);
                paramsToStore[0].Value = Frm_Padre._Str_GroupComp;
                paramsToStore[1] = new SqlParameter("@cidrecepcion", SqlDbType.Int);
                paramsToStore[1].Value = _Txt_Rec.Text.Trim();
                paramsToStore[2] = new SqlParameter("@ctdiferencia", SqlDbType.TinyInt);
                paramsToStore[2].Value = _Int_N.ToString();
                paramsToStore[3] = new SqlParameter("@ccompany", SqlDbType.VarChar);
                paramsToStore[3].Size = 10;
                paramsToStore[3].Value = Frm_Padre._Str_Comp;
                paramsToStore[4] = new SqlParameter("@cproveedor", SqlDbType.VarChar);
                paramsToStore[4].Size = 10;
                paramsToStore[4].Value = _Str_Proveedor;
                CLASES._Cls_Varios_Metodos._Mtd_EjecutarSP("SPE_RECEPCION2", paramsToStore);
                Frm_OC_FAC _Frm = new Frm_OC_FAC(_Txt_Rec.Text, _Str_Proveedor, _Int_N, _Str_Facturas);
                _Frm.Name = "_Frm_OC_FAC_Eval";
                _Frm.MdiParent = this.MdiParent;
                _Mtd_Actulizar_TRECEPCIONRELDIF();
                Cursor = Cursors.Default;
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                MessageBox.Show("La operación fue realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Frm.Show();
                this.Close();
            }
            else
            {
                Cursor = Cursors.Default;
                _Bt_Evaluar.Enabled = true;
                MessageBox.Show("Debe selecionar facturas para realizar la evaluación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void _Rb_R1_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_R1.Checked)
            {
                //_Chk_Descuento.Enabled = false;
                _Dg_Grid2.Columns[8].HeaderText = "Des. %";
                _Dg_Grid2.ReadOnly = false;
                _Dg_Grid2.Columns[2].ReadOnly = true;
                _Dg_Grid2.Columns[3].ReadOnly = true;
                _Dg_Grid2.Columns[7].ReadOnly = true;
                _Dg_Grid2.Columns["CostoNeto"].ReadOnly = true;
                _Dg_Grid2.Columns["ccostobrutolote"].ReadOnly = true;
                _Dg_Grid2.Columns["cpreciolista"].ReadOnly = true;
                _Mtd_RecalcularCostoUni();

            }
        }
        private void _Rb_R2_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_R2.Checked)
            {
                //_Chk_Descuento.Enabled = false;
                _Dg_Grid2.Columns[8].HeaderText = "Des. Valor";
                _Dg_Grid2.ReadOnly = false;
                _Dg_Grid2.Columns[2].ReadOnly = true;
                _Dg_Grid2.Columns[3].ReadOnly = true;
                _Dg_Grid2.Columns[7].ReadOnly = true;
                _Dg_Grid2.Columns["CostoNeto"].ReadOnly = true;
                _Dg_Grid2.Columns["ccostobrutolote"].ReadOnly = true;
                _Dg_Grid2.Columns["cpreciolista"].ReadOnly = true;
                _Mtd_RecalcularCostoUni();
            }
        }
        private void _Mtd_RecalcularCostoUni()
        {
            foreach (DataGridViewRow _RowView in _Dg_Grid2.Rows)
            {
                int _Int_Cajas = 0;
                int _Int_Unidades = 0;
                int.TryParse(Convert.ToString(_RowView.Cells[4].Value).Trim(), out _Int_Cajas);
                int.TryParse(Convert.ToString(_RowView.Cells[5].Value).Trim(), out _Int_Unidades);
                _RowView.Cells[4].Value = _Int_Cajas;
                _RowView.Cells[5].Value = _Int_Unidades;
                if (Convert.ToString(_RowView.Cells[0].Value).Trim().Length > 0 & Convert.ToString(_RowView.Cells[3].Value).Trim().Length > 0 & (Convert.ToString(_RowView.Cells[4].Value).Trim().Length > 0) & (Convert.ToString(_RowView.Cells[6].Value).Trim().Length > 0 & Convert.ToString(_RowView.Cells[6].Value).Trim() != "0") & Convert.ToString(_RowView.Cells[5].Value).Trim().Length > 0)
                {
                    if ((Convert.ToDecimal(_RowView.Cells[4].Value) > 0 | Convert.ToDecimal(_RowView.Cells[5].Value) > 0) & !(Convert.ToDecimal(_RowView.Cells[4].Value) < 0) & !(Convert.ToDecimal(_RowView.Cells[5].Value) < 0))
                    {
                        //----------------------------------Cálculo del costo neto
                        decimal _Dcm_Uni = 0;
                        int _Int_ContenidoU = Convert.ToInt32(_RowView.Cells[9].Value.ToString()) / Convert.ToInt32(_RowView.Cells[10].Value.ToString());
                        int _Int_CantidadUni = (_Int_Cajas * (Convert.ToInt32(_RowView.Cells[9].Value.ToString()) / Convert.ToInt32(_RowView.Cells[10].Value.ToString()))) + _Int_Unidades;
                        _RowView.Cells[8].Value = 0;
                        _Dcm_Uni = Convert.ToDecimal(_RowView.Cells[6].Value.ToString()) / _Int_CantidadUni;
                        _Dcm_Uni = _Dcm_Uni * _Int_ContenidoU;
                        _RowView.Cells[7].Value = _Dcm_Uni.ToString("#,##0.00");
                        //----------------------------------Cálculo del costo neto
                    }
                }
            }
            _Mtd_Totalizar();
        }
        private void _Chk_Descuento_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chk_Descuento.Checked)
            {
                _Rb_R1.Enabled = true;
                _Rb_R2.Enabled = true;
                _Dg_Grid2.ReadOnly = true;
                _Dg_Grid2.Columns[8].Visible = true;
            }
            else
            {
                _Rb_R1.Checked = false;
                _Rb_R2.Checked = false;
                _Rb_R1.Enabled = false;
                _Rb_R2.Enabled = false;
                _Dg_Grid2.ReadOnly = false;
                _Dg_Grid2.Columns[8].Visible = false;
                _Dg_Grid2.Columns[2].ReadOnly = true;
                _Dg_Grid2.Columns[3].ReadOnly = true;
                _Dg_Grid2.Columns[7].ReadOnly = true;
                _Dg_Grid2.Columns["CostoNeto"].ReadOnly = true;
                _Dg_Grid2.Columns["ccostobrutolote"].ReadOnly = true;
                _Dg_Grid2.Columns["cpreciolista"].ReadOnly = true;
                _Mtd_RecalcularCostoUni();
            }
        }
        private void _Lst_OC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Rbt_OC.Checked | _Rbt_Un.Checked)
            {
                bool _Bol = false;
                foreach (object _Ob in _Lst_OC.CheckedItems)
                {
                    _Bol = true;
                }
                if (_Bol)
                {
                    _Lst_OC.Enabled = false;
                }
            }
        }

        private void _Lst_FAC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Rbt_FAC.Checked | _Rbt_Un.Checked)
            {
                bool _Bol = false;
                foreach (object _Ob in _Lst_FAC.CheckedItems)
                {
                    _Bol = true;
                }
                if (_Bol)
                {
                    _Lst_FAC.Enabled = false;
                }
            }
        }
        private void _Mtd_DesCheckearLista(CheckedListBox _P_Lst_Lista)
        {
            int _Int_Count = _P_Lst_Lista.Items.Count - 1;
            for (int _Int_Index = 0; _Int_Index <= _Int_Count; _Int_Index++)
            {
                _P_Lst_Lista.SetItemChecked(_Int_Index, false);
            }
        }

        int _Int_N = 0;
        private void _Rbt_FAC_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_FAC.Checked)
            {
                _Int_N = 1;
                _Mtd_DesCheckearLista(_Lst_FAC);
                _Mtd_DesCheckearLista(_Lst_OC);
                _Lst_OC.Enabled = true;
                _Lst_FAC.Enabled = true;
                _Lst_OC_FAC.Items.Clear();
            }
        }

        private void _Rbt_OC_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_OC.Checked)
            {
                _Int_N = 2;
                _Mtd_DesCheckearLista(_Lst_FAC);
                _Mtd_DesCheckearLista(_Lst_OC);
                _Lst_OC.Enabled = true;
                _Lst_FAC.Enabled = true;
                _Lst_OC_FAC.Items.Clear();
            }
        }

        private void _Rbt_Un_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rbt_Un.Checked)
            {
                _Int_N = 3;
                _Mtd_DesCheckearLista(_Lst_FAC);
                _Mtd_DesCheckearLista(_Lst_OC);
                _Lst_OC.Enabled = true;
                _Lst_FAC.Enabled = true;
                _Lst_OC_FAC.Items.Clear();
            }
        }

        private void _Bt_Insertar_Click(object sender, EventArgs e)
        {
            string _Str_Sentencia = "";
            if (_Lst_OC_FAC.Items.Count > 0)
            {
                _Str_Sentencia = "insert into TRECEPCIONTDIF (cgroupcomp,cidrecepcion,ctdiferencia) values('" + Frm_Padre._Str_GroupComp + "','" + _Txt_Rec.Text.Trim() + "','" + _Int_N.ToString() + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sentencia);
                foreach (object _ObItem in _Lst_OC_FAC.Items)
                {
                    _Mtd_Separar_OC_FAC_NUEVO(_ObItem.ToString());
                    _Str_Sentencia = "insert into TRECEPCIONTDIF (cgroupcomp,cidrecepcion,cnumoc,cnfacturapro) values('" + Frm_Padre._Str_GroupComp + "','" + _Txt_Rec.Text.Trim() + "','" + _Str_OC_Sep + "','" + _Str_FAC_Sep + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sentencia);
                }
            }
        }
        private void _Bt_Agre_Click(object sender, EventArgs e)
        {
            if (_Lst_FAC.CheckedItems.Count == _Lst_FAC.Items.Count)
            {
                if (_Mtd_Validar_Selecion())
                {
                    int _Int_Orden = _Mtd_Validar_Copia_OC();
                    if (_Int_Orden == 0)
                    {
                        if (_Rbt_OC.Checked | _Rbt_Un.Checked)
                        {
                            foreach (object _Ob in _Lst_OC.CheckedItems)
                            {
                                foreach (object _Ob2 in _Lst_FAC.CheckedItems)
                                {
                                    if (_Lst_OC_FAC.Items.Count == 0)
                                    { _Lst_OC_FAC.Items.Add(_Ob.ToString() + " -> " + _Ob2.ToString()); }
                                    else
                                    {
                                        if (_Lst_OC_FAC.Items.IndexOf((_Ob.ToString() + " -> " + _Ob2.ToString())) == -1)
                                        { _Lst_OC_FAC.Items.Add(_Ob.ToString() + " -> " + _Ob2.ToString()); }
                                    }

                                }
                                break;
                            }
                        }
                        if (_Rbt_FAC.Checked)
                        {
                            foreach (object _Ob in _Lst_FAC.CheckedItems)
                            {
                                foreach (object _Ob2 in _Lst_OC.CheckedItems)
                                {
                                    if (_Lst_OC_FAC.Items.Count == 0)
                                    { _Lst_OC_FAC.Items.Add(_Ob.ToString() + " -> " + _Ob2.ToString()); }
                                    else
                                    {
                                        if (_Lst_OC_FAC.Items.IndexOf((_Ob.ToString() + " -> " + _Ob2.ToString())) == -1)
                                        { _Lst_OC_FAC.Items.Add(_Ob.ToString() + " -> " + _Ob2.ToString()); }
                                    }
                                }
                                break;
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("La orden de compra seleccionada no corresponde con la copiada. (OC copiada=" + _Int_Orden.ToString() + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _Mtd_OCR();
                        _Lst_OC.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Debe cumplir con el criterio seleccionado en tipo de evaluación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _Lst_OC.Enabled = true;
                    _Lst_FAC.Enabled = true;
                }
            }
            else
            { MessageBox.Show("Debe seleccionar todas las facturas que pertenecen a la recepción de transporte", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        string _Str_OrdenCompra = "0";
        private void _Bt_Copiar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Mtd_VerifContTextBoxVarcharNoCero(_Txt_Fac) & _Mtd_VerifContTextBoxNumeric(_Txt_NumCtrl))
            {
                string _Str_Cadena = "SELECT TORDENCOMPM.cnumoc AS [Id O.C.], Convert(varchar,TORDENCOMPM.cfechaoc,103) AS Fecha, TPROVEEDOR.c_nomb_abreviado AS Proveedor, SUM(TORDENCOMPD.ccantunidadma1) AS Cajas,dbo.Fnc_Formatear(TORDENCOMPM.ctotsimp) AS Monto " +
                "FROM TORDENCOMPM INNER JOIN " +
                "TPROVEEDOR ON TORDENCOMPM.cproveedor = TPROVEEDOR.cproveedor AND " +
                "TORDENCOMPM.cdelete = TPROVEEDOR.cdelete INNER JOIN " +
                "TORDENCOMPD ON TORDENCOMPM.ccompany = TORDENCOMPD.ccompany AND " +
                "TORDENCOMPM.cnumoc = TORDENCOMPD.cnumoc AND TORDENCOMPM.cproveedor = TORDENCOMPD.cproveedor " +
                "WHERE (TORDENCOMPM.cdelete = 0) AND (TORDENCOMPM.cocaprovee = 1) AND (TORDENCOMPM.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TORDENCOMPM.centroinvent = 0) AND (TORDENCOMPM.ccerrada = 0) AND (TORDENCOMPM.cproveedor = '" + _Str_Proveedor + "') AND (TORDENCOMPM.cefectividad<=(Select cmaxefectivioc from TCONFIGCOMP where ccompany='" + Frm_Padre._Str_Comp + "')) " +// AND not exists(Select * from TRECEPCIONDFM where TORDENCOMPM.cnumoc=TRECEPCIONDFM.ccopiaoc AND TRECEPCIONDFM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TRECEPCIONDFM.cproveedor='" + _Str_Proveedor + "') AND not exists(Select * from TRECEPCIONRELDIF where TORDENCOMPM.cnumoc=TRECEPCIONRELDIF.cnumoc and TRECEPCIONRELDIF.cgroupcomp='" + Frm_Padre._Str_GroupComp + "') "+
                "GROUP BY TORDENCOMPM.cnumoc, CONVERT(varchar, TORDENCOMPM.cfechaoc, 103), TPROVEEDOR.c_nomb_abreviado, " +
                "dbo.Fnc_Formatear(TORDENCOMPM.ctotsimp)";
                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                {
                    TextBox _Txt_OC = new TextBox();
                    ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
                    _Tsm_Menu[0] = new ToolStripMenuItem("Id O.C.");
                    _Tsm_Menu[1] = new ToolStripMenuItem("Fecha");
                    _Tsm_Menu[2] = new ToolStripMenuItem("Proveedor");
                    string[] _Str_Campos = new string[3];
                    _Str_Campos[0] = "cnumoc";
                    _Str_Campos[1] = "cfechaoc";
                    _Str_Campos[2] = "c_nomb_abreviado";
                    Cursor = Cursors.WaitCursor;
                    Frm_Busqueda _Frm = new Frm_Busqueda(_Str_Cadena, _Str_Campos, "Orden de Compra", _Tsm_Menu, _Txt_OC);
                    Cursor = Cursors.Default;
                    _Frm.ShowDialog();
                    if (_Txt_OC.Text.Trim().Length > 0)
                    {
                        _Str_OrdenCompra = _Txt_OC.Text;
                        Cursor = Cursors.WaitCursor;
                        _Dg_Grid2.Rows.Clear();
                        foreach (DataGridViewRow _DgRow in _Frm._Dg_Datagrid.SelectedRows)
                        {
                            _Mtd_CopiarOC(_DgRow.Cells[0].Value.ToString());
                        }
                        _Mtd_Totalizar();
                        _Bt_Depurar.Enabled = true;
                        _Mtd_FechaVenc();
                        Cursor = Cursors.Default;
                    }
                }
                else
                {
                    MessageBox.Show("No existen ordenes de compra para este proveedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (!_Mtd_VerifContTextBoxVarcharNoCero(_Txt_Fac)) { _Er_Error.SetError(_Txt_Fac, "Información requerida!!!"); }
                if (!_Mtd_VerifContTextBoxNumeric(_Txt_NumCtrl)) { _Er_Error.SetError(_Txt_NumCtrl, "Información requerida!!!"); }
                //if (!_Mtd_VerifContTextBoxVarcharNoCero(_Txt_GuiaSada)) { _Er_Error.SetError(_Txt_GuiaSada, "Información requerida!!!"); }
            }
        }

        private void _Txt_Fac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "'" | e.KeyChar.ToString() == "*" | e.KeyChar.ToString() == "=" | e.KeyChar.ToString() == "%")
            {
                e.Handled = true;
            }
        }

        private void _Bt_Inicial_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_IniLists();
            Cursor = Cursors.Default;
        }

        private void _Txt_Fac_EnabledChanged(object sender, EventArgs e)
        {
            _Txt_NumCtrl.Enabled = _Txt_Fac.Enabled;
            _Txt_GuiaSada.Enabled = _Txt_Fac.Enabled;
        }

        private void _Tb_Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Tb_Tab.SelectedIndex == 2)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_IniLists();
                Cursor = Cursors.Default;
            }
        }

        private void _Pnl_Depurar_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Depurar.Visible)
            {
                _Txt_Producto_Buscar.Focus();
                _Tb_Tab.Enabled = false;
            }
            else
            {
                _Tb_Tab.Enabled = true; _Txt_Producto_Buscar.Text = "";
                _Txt_CodFabricaB.Text = "";
                _Txt_CodProductoB.Text = "";
                _Txt_DescripcionB.Text = "";
                _Bt_Marcar.Enabled = false;
                _Bt_Desmarcar.Enabled = false;
            }
        }

        private void _Bt_Depurar_Click(object sender, EventArgs e)
        {
            _Str_Array = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Array, 0);
            _Pnl_Depurar.Visible = true;
            _Txt_Producto_Buscar.Text = "";
            if (_Dg_Grid2.Rows.Count > 0)
            {
                foreach (DataGridViewRow _Dg_Row in _Dg_Grid2.Rows)
                {
                    if (_Dg_Row.Cells["Column8"] != null)
                    {
                        if (_Dg_Row.Cells["Column8"].Value != null)
                        {
                            if (_Dg_Row.Cells["Column8"].Value.ToString().Trim().Length > 0)
                            {
                                _Str_Array = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Array, _Str_Array.Length + 1);
                                _Str_Array[_Str_Array.Length - 1] = Convert.ToString(_Dg_Row.Cells["Column8"].Value.ToString().ToUpper()) + "|" + Convert.ToString(_Dg_Row.Cells["ProductoInterno"].Value.ToString().ToUpper());
                            }
                        }
                    }
                }
            }
        }

        private void _Bt_Marcar_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid2.Rows.Count > 0)
            {
                string[] _Str_CodFabricaM = new string[_Str_Array.Length];
                string[] _Str_CodProductoM = new string[_Str_Array.Length];
                int _Int_I = 0;
                foreach (string _Str_String in _Str_Array)
                {
                    string[] _Str_Palabra = _Str_String.Split('|');
                    _Str_CodFabricaM[_Int_I] = _Str_Palabra[0];
                    _Str_CodProductoM[_Int_I] = _Str_Palabra[1];
                    _Int_I++;
                }
                int _Int_Index = Array.IndexOf(_Str_CodFabricaM, _Txt_CodFabricaB.Text.ToUpper().Trim());
                int _Int_Index_1 = Array.IndexOf(_Str_CodProductoM, _Txt_CodFabricaB.Text.ToUpper().Trim());
                if (_Int_Index != -1 || _Int_Index_1 != -1)
                {
                    if (_Int_Index != -1)
                    {
                        _Dg_Grid2.Rows[_Int_Index].DefaultCellStyle.BackColor = Color.Gold;
                        _Dg_Grid2.Rows[_Int_Index].Cells["Column9"].Style.BackColor = Color.Gold;
                        _Dg_Grid2.Rows[_Int_Index].Cells["Unidades"].Style.BackColor = Color.Gold;
                        _Dg_Grid2.Rows[_Int_Index].Cells["Column10"].Style.BackColor = Color.Gold;
                        _Dg_Grid2.Rows[_Int_Index].Cells["Column1"].Style.BackColor = Color.Gold;
                        _Txt_Producto_Buscar.Text = "";
                        _Txt_CodFabricaB.Text = "";
                        _Txt_CodProductoB.Text = "";
                        _Txt_DescripcionB.Text = "";
                        _Bt_Marcar.Enabled = false;
                        _Bt_Desmarcar.Enabled = false;
                        _Txt_Producto_Buscar.Focus();
                    }
                    if (_Int_Index_1 != -1)
                    {
                        _Dg_Grid2.Rows[_Int_Index_1].DefaultCellStyle.BackColor = Color.Gold;
                        _Dg_Grid2.Rows[_Int_Index_1].Cells["Column9"].Style.BackColor = Color.Gold;
                        _Dg_Grid2.Rows[_Int_Index_1].Cells["Unidades"].Style.BackColor = Color.Gold;
                        _Dg_Grid2.Rows[_Int_Index_1].Cells["Column10"].Style.BackColor = Color.Gold;
                        _Dg_Grid2.Rows[_Int_Index_1].Cells["Column1"].Style.BackColor = Color.Gold;
                        _Txt_Producto_Buscar.Text = "";
                        _Txt_CodFabricaB.Text = "";
                        _Txt_CodProductoB.Text = "";
                        _Txt_DescripcionB.Text = "";
                        _Bt_Marcar.Enabled = false;
                        _Bt_Desmarcar.Enabled = false;
                        _Txt_Producto_Buscar.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("No hay registros cargados en la factura actual con el código ingresado");
                }
            }
            else
            {
                MessageBox.Show("No hay registros cargados en la factura actual");
            }
        }

        private void _Bt_Desmarcar_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid2.Rows.Count > 0)
            {
                string[] _Str_CodFabricaM = new string[_Str_Array.Length];
                string[] _Str_CodProductoM = new string[_Str_Array.Length];
                int _Int_I = 0;
                foreach (string _Str_String in _Str_Array)
                {
                    string[] _Str_Palabra = _Str_String.Split('|');
                    _Str_CodFabricaM[_Int_I] = _Str_Palabra[0];
                    _Str_CodProductoM[_Int_I] = _Str_Palabra[1];
                    _Int_I++;
                }
                int _Int_Index = Array.IndexOf(_Str_CodFabricaM, _Txt_CodFabricaB.Text.ToUpper().Trim());
                int _Int_Index_1 = Array.IndexOf(_Str_CodProductoM, _Txt_CodFabricaB.Text.ToUpper().Trim());
                if (_Int_Index != -1 || _Int_Index_1 != -1)
                {
                    if (_Int_Index != -1)
                    {
                        _Dg_Grid2.Rows[_Int_Index].DefaultCellStyle.BackColor = Color.White;
                        _Dg_Grid2.Rows[_Int_Index].Cells["Column9"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        _Dg_Grid2.Rows[_Int_Index].Cells["Unidades"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        _Dg_Grid2.Rows[_Int_Index].Cells["Column10"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        _Dg_Grid2.Rows[_Int_Index].Cells["Column1"].Style.BackColor = Color.FromArgb(192, 192, 255);
                        _Txt_Producto_Buscar.Text = "";
                        _Txt_CodFabricaB.Text = "";
                        _Txt_CodProductoB.Text = "";
                        _Txt_DescripcionB.Text = "";
                        _Bt_Marcar.Enabled = false;
                        _Bt_Desmarcar.Enabled = false;
                        _Dg_Grid2.Rows[_Int_Index].Cells["Column14"].Style.BackColor = Color.FromKnownColor(KnownColor.Control);
                        _Txt_Producto_Buscar.Focus();
                    }
                    if (_Int_Index_1 != -1)
                    {
                        _Dg_Grid2.Rows[_Int_Index_1].DefaultCellStyle.BackColor = Color.White;
                        _Dg_Grid2.Rows[_Int_Index_1].Cells["Column9"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        _Dg_Grid2.Rows[_Int_Index_1].Cells["Unidades"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        _Dg_Grid2.Rows[_Int_Index_1].Cells["Column10"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        _Dg_Grid2.Rows[_Int_Index_1].Cells["Column1"].Style.BackColor = Color.FromArgb(192, 192, 255);
                        _Txt_Producto_Buscar.Text = "";
                        _Txt_CodFabricaB.Text = "";
                        _Txt_CodProductoB.Text = "";
                        _Txt_DescripcionB.Text = "";
                        _Bt_Marcar.Enabled = false;
                        _Bt_Desmarcar.Enabled = false;
                        _Dg_Grid2.Rows[_Int_Index_1].Cells["Column14"].Style.BackColor = Color.FromKnownColor(KnownColor.Control);
                        _Txt_Producto_Buscar.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("No hay registros cargados en la factura actual con el código ingresado");
                }
            }
            else
            {
                MessageBox.Show("No hay registros cargados en la factura actual");
            }
        }

        private void _Bt_CerrarC_Click(object sender, EventArgs e)
        {
            _Mtd_EliminarDesmarcados();
            _Pnl_Depurar.Visible = false;
        }
        private void _Bt_BuscarC_Click(object sender, EventArgs e)
        {
            _Mtd_Buscar();
        }

        private void _Txt_Producto_Buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                _Mtd_Buscar();
            }
        }

        private void _Bt_FinalizarProceso_Click(object sender, EventArgs e)
        {
            _Mtd_EliminarDesmarcados();
            _Pnl_Depurar.Visible = false;
        }

        private void _Txt_NumCtrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            _MyUtilidad._Mtd_Valida_Numeros(_Txt_NumCtrl, e, 8, 0);
        }
        private void _Txt_Control_TextChanged(object sender, EventArgs e)
        {
            if (!_Mtd_IsNumeric(_Txt_NumCtrl.Text))
            {
                _Txt_NumCtrl.Text = "";
            }
        }

        private void _Txt_NumCtrlPref_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "'" | e.KeyChar.ToString() == "*" | e.KeyChar.ToString() == "-" | e.KeyChar.ToString() == "=" | e.KeyChar.ToString() == "%")
            {
                e.Handled = true;
            }
        }

        private void _Txt_NumCtrl_EnabledChanged(object sender, EventArgs e)
        {
            _Txt_NumCtrlPref.Enabled = _Txt_NumCtrl.Enabled;
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = e.TabPageIndex == 2 & _Int_Switch != 2;
        }

        private void _Bt_Finalizar_Click(object sender, EventArgs e)
        {
            string _Str_Cadena = "SELECT cnfacturapro FROM TRECEPCIONDFM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _Txt_Rec.Text.Trim() + "'";
            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
            {
                if (MessageBox.Show("¿Esta seguro de haber cargado todas las facturas de la recepción seleccionada?", "Varificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _Str_Cadena = "UPDATE TRECEPCIONM SET ccargfactura=2 WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _Txt_Rec.Text.Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                    MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            { MessageBox.Show("Debe cargar por lo menos una factura para la recepción seleccionada.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void _Bt_Nuevo_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("¿Usted desea agregar una nueva factura?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information)) == DialogResult.Yes)
            {
                _Mtd_Nuevo();
            }
        }

        private void _Bt_Editar_Click(object sender, EventArgs e)
        {
            _Mtd_Editar();
        }

        private void _Bt_Guardar_Click(object sender, EventArgs e)
        {
            _Mtd_Guardar();
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid2.RowCount > 0)
            { _Mtd_MostrarFactura(_Txt_Fac.Text.Trim(), _Str_Proveedor, false); }
            else
            { MessageBox.Show("La factura no tiene detalle", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        Control[] _Ctrl_Controles = new Control[11];
        private void Frm_RecepcionB_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Pnl_Depurar.Left = (this.Width / 2) - (_Pnl_Depurar.Width / 2);
            _Pnl_Depurar.Top = (this.Height / 2) - (_Pnl_Depurar.Height / 2);
            _Mtd_Actualizar();
            _Mtd_Color_Estandar(this);
            _Mtd_Sorted(_Dg_Grid);
            _Mtd_Sorted(_Dg_Grid2);
        }
        private void Frm_Recepcion_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        private void Frm_Recepcion_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Debe quedar en este orden.
            if (_Int_Switch == 1 | _Bol_FacMalCargFormClos)
            {
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(85);
                if (_Frm._Dg_Grid.RowCount == 0)
                { _Frm.Close(); }
                else
                { _Frm.MdiParent = this.MdiParent; }
                try
                {
                    _Frm.Show(); 
                    Application.OpenForms["_Frm_FactMalCargada"].Activate();
                }
                catch { }
            }
            else if (_Int_Switch == 0)
            {
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(83);
                if (_Frm._Dg_Grid.RowCount == 0)
                { _Frm.Close(); }
                else
                { _Frm.MdiParent = this.MdiParent; _Frm.Show(); }
            }
            else
            {
                Frm_Busqueda2 _Frm = new Frm_Busqueda2(86);
                if (_Frm._Dg_Grid.RowCount == 0)
                { _Frm.Close(); }
                else
                { _Frm.MdiParent = this.MdiParent; }
                try
                {
                    _Frm.Show();
                    Application.OpenForms["_Frm_OC_FAC_Eval"].Activate();
                }
                catch { }
            }
        }
        private void _Dg_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgFactInfo.Visible = true;
            }
            else
            {
                _Lbl_DgFactInfo.Visible = false;
            }
        }

        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                _Mtd_MostrarDet();
                if (_Int_Switch == 2) { _Bt_Editar.Enabled = false; }
                _Tb_Tab.SelectedIndex = 1;
            }
        }
        private void _Dg_Grid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (_Mtd_VerifContTextBoxVarcharNoCero(_Txt_Fac) & _Mtd_VerifContTextBoxNumeric(_Txt_NumCtrl))
                    {
                        TextBox _Txt_TemporalCod = new TextBox();
                        TextBox _Txt_TemporalDes = new TextBox();
                        ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[3];
                        _Tsm_Menu[0] = new ToolStripMenuItem("Cod. Fabricante");
                        _Tsm_Menu[1] = new ToolStripMenuItem("Cod. Interno");
                        _Tsm_Menu[2] = new ToolStripMenuItem("Cod. Descripción");
                        string[] _Str_Campos = new string[3];
                        _Str_Campos[0] = "ccodfabrica";
                        _Str_Campos[1] = "cproducto";
                        _Str_Campos[2] = "cnamefc";
                        if (e.ColumnIndex == 1 && !this._Dg_Grid2.ReadOnly)
                        {
                            Frm_Busqueda _Frm = new Frm_Busqueda(_Txt_TemporalCod, _Txt_TemporalDes, "Select ccodfabrica as [cod. Fabricante],cproducto as [Cod. Interno],CASE WHEN cunidad2 = 0 THEN rtrim(tmarcasm.cname) + ' ' + RTRIM(tproducto.CNAMEF) ELSE RTRIM(tmarcasm.cname) + ' ' + RTRIM(tproducto.cnamef) END as Descripción from TPRODUCTO INNER JOIN TMARCASM ON TPRODUCTO.cmarca=TMARCASM.cmarca where cproveedor='" + _Str_Proveedor + "' and TPRODUCTO.cdelete='0' AND TPRODUCTO.cactivate='1'", _Str_Campos, "Productos", _Tsm_Menu, 0, 1);
                            _Frm.ShowDialog();
                            bool _Bol_ = false;
                            int _int_i = -1;
                            foreach (DataGridViewRow _DgRow in _Dg_Grid2.Rows)
                            {
                                try
                                {
                                    if (_DgRow.Cells[2].Value.ToString().ToUpper() == _Txt_TemporalDes.Text)
                                    {
                                        _Bol_ = true;
                                        _int_i++;
                                        break;
                                    }
                                }
                                catch { }
                            }
                            if (!_Bol_)
                            {
                                if (_Txt_TemporalDes.Text.Trim().Length > 0)
                                {
                                    _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = _Txt_TemporalCod.Text;
                                    _Dg_Grid2.Rows[e.RowIndex].Cells[2].Value = _Txt_TemporalDes.Text;
                                    string _Str_Cadena = "Select cnamefc,produc_descrip_2, ccontenidoma1, ccontenidoma2, cunidad2, ISNULL(cregpmv,0) AS cregpmv, cproducto from VST_PRODUCTOS WHERE cproducto='" + _Txt_TemporalDes.Text.Trim() + "'";
                                    DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                                    if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow _Dtw_Item in _Ds_DataSet.Tables[0].Rows)
                                        {
                                            _Dg_Grid2.Rows[e.RowIndex].Cells[3].Value = _Dtw_Item["cnamefc"].ToString().Trim() + " " + _Dtw_Item["produc_descrip_2"].ToString().Trim();
                                            _Dg_Grid2.Rows[e.RowIndex].Cells[9].Value = _Dtw_Item["ccontenidoma1"].ToString().Trim();
                                            _Dg_Grid2.Rows[e.RowIndex].Cells[10].Value = _Dtw_Item["ccontenidoma2"].ToString().Trim();
                                            decimal _Dcm_ccostobrutolote = 0;
                                            decimal _Dcm_ccostonetolote = 0;
                                            decimal _Dcm_cprecioventamax = 0;
                                            decimal _Dcm_cpreciolista = 0;
                                            _Mtd_ObtenerCostoBrutoCostoNetoPrecioListayPrecioMax(_Txt_TemporalDes.Text.Trim(), ref _Dcm_ccostobrutolote, ref _Dcm_cprecioventamax, ref _Dcm_cpreciolista, ref _Dcm_ccostonetolote);
                                            _Dg_Grid2.Rows[e.RowIndex].Cells["ccostobrutolote"].Value = _Dcm_ccostobrutolote;
                                            _Dg_Grid2.Rows[e.RowIndex].Cells["CostoNeto"].Value = _Dcm_ccostonetolote;
                                            _Dg_Grid2.Rows[e.RowIndex].Cells["cprecioventamax"].Value = _Dtw_Item["cregpmv"].ToString().Trim() == "0" ? "0" : null;
                                            _Dg_Grid2.Rows[e.RowIndex].Cells["cpreciolista"].Value = _Dcm_cpreciolista;
                                            _Dg_Grid2.Rows[e.RowIndex].Cells["cprecioventamax"].ReadOnly = _Dtw_Item["cregpmv"].ToString().Trim() == "0";
                                            if (_Dtw_Item["cunidad2"].ToString() == "1")
                                            {
                                                _Dg_Grid2.Rows[e.RowIndex].Cells[5].ReadOnly = false;
                                            }
                                            else
                                            {
                                                _Dg_Grid2.Rows[e.RowIndex].Cells[5].ReadOnly = true;
                                            }
                                        }
                                    }
                                    _Mtd_Totalizar();
                                }
                            }
                            else
                            {
                                MessageBox.Show("El producto seleccionado ya a sido cargado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        if (!_Mtd_VerifContTextBoxVarcharNoCero(_Txt_Fac)) { _Er_Error.SetError(_Txt_Fac, "Información requerida!!!"); }
                        if (!_Mtd_VerifContTextBoxNumeric(_Txt_NumCtrl)) { _Er_Error.SetError(_Txt_NumCtrl, "Información requerida!!!"); }
                        //if (!_Mtd_VerifContTextBoxVarcharNoCero(_Txt_GuiaSada)) { _Er_Error.SetError(_Txt_GuiaSada, "Información requerida!!!"); }
                    }
                }
            }
            catch (Exception _Ex) { MessageBox.Show("Ha ocurrido un error." + _Ex.ToString()); }
        }

        private void _Dg_Grid2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_Dg_Grid2.Rows.Count > 0)
            {
                if (_Dg_Grid2.CurrentCell != null)
                {
                    if (e.ColumnIndex >= 0 & e.RowIndex >= 0)
                    {
                        if (e.ColumnIndex != 0 && e.ColumnIndex != 2 && e.ColumnIndex != 3)
                        {
                            if (!_Mtd_ValorValidoCelda(_Dg_Grid2[e.ColumnIndex, e.RowIndex].Value)) { _Dg_Grid2[e.ColumnIndex, e.RowIndex].Value = "0"; }
                        }
                        string _Str_CodProducto = "";
                        decimal _Dcm_CantUnidades = 0, _Dcm_CantUnid2Prod = 0;
                        if (e.ColumnIndex == 5)
                        {
                            _Str_CodProducto = Convert.ToString(_Dg_Grid2[2, e.RowIndex].Value).Trim();
                            if (_Str_CodProducto.Length > 0)
                            {
                                if (Convert.ToString(_Dg_Grid2[e.ColumnIndex, e.RowIndex].Value).Length > 0)
                                {
                                    _Dcm_CantUnidades = Convert.ToDecimal(_Dg_Grid2[e.ColumnIndex, e.RowIndex].Value);
                                }
                                if (_Dcm_CantUnidades > 0)
                                {
                                    string _Str_Sql = "SELECT cproducto FROM TPRODUCTO WHERE cproducto='" + _Str_CodProducto + "' AND cventaund2=1";
                                    if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
                                    {
                                        _Dcm_CantUnid2Prod = _MyUtilidad._Mtd_ProductoUndManejo2Dec(_Str_CodProducto);
                                        if (_Dcm_CantUnid2Prod <= _Dcm_CantUnidades)
                                        {
                                            _Bol_Mensaje = true;
                                            MessageBox.Show("No puede ingresar esta cantidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            _Dg_Grid2.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_Grid2_CellValueChanged);
                                            _Dg_Grid2[e.ColumnIndex, e.RowIndex].Value = _Str_Temp_Unidades;
                                            _Dg_Grid2.CellValueChanged += new DataGridViewCellEventHandler(_Dg_Grid2_CellValueChanged);
                                        }
                                    }
                                    else
                                    {
                                        _Bol_Mensaje = true;
                                        MessageBox.Show("No puede ingresar esta cantidad. El producto no se comercializa en Unidades", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        _Dg_Grid2.CellValueChanged -= new DataGridViewCellEventHandler(_Dg_Grid2_CellValueChanged);
                                        _Dg_Grid2[e.ColumnIndex, e.RowIndex].Value = _Str_Temp_Unidades;
                                        _Dg_Grid2.CellValueChanged += new DataGridViewCellEventHandler(_Dg_Grid2_CellValueChanged);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private decimal _Mtd_ValorDescuento(string _P_Str_Descuento, decimal _P_Dcm_Precio)
        {
            decimal _Dcm_Descuento = 0;
            if (decimal.TryParse(_P_Str_Descuento, out _Dcm_Descuento))
            {
                if (_Rb_R1.Checked)
                {
                    return (_P_Dcm_Precio * _Dcm_Descuento) / 100;
                }
                else
                {
                    return _Dcm_Descuento;
                }
            }
            return 0;
        }
        private void _Mtd_ObtenerCostoBrutoCostoNetoPrecioListayPrecioMax(string _P_Str_Producto, ref decimal _P_Dcm_ccostobrutolote, ref decimal _P_Dcm_cprecioventamax, ref decimal _P_Dcm_cpreciolista, ref decimal _P_Dcm_ccostonetolote)
        {
            string _Str_Cadena = "SELECT TOP 1 ISNULL(TPRODUCTOD.ccostobrutolote,TPRODUCTO.CCOSTOBRUTO_U1) AS ccostobrutolote,0 AS cprecioventamax,ISNULL(TPRODUCTOD.cpreciolista,TPRODUCTO.cpreciolista) AS cpreciolista, ISNULL(TPRODUCTOD.ccostonetolote,TPRODUCTO.ccostoneto_U1) AS ccostonetolote FROM TPRODUCTOD RIGHT JOIN TPRODUCTO ON TPRODUCTOD.cproducto=TPRODUCTO.cproducto WHERE TPRODUCTO.cproducto='" + _P_Str_Producto + "' ORDER BY cidproductod DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_P_Dcm_ccostobrutolote == 0)
                { _P_Dcm_ccostobrutolote = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["ccostobrutolote"]); }
                if (_P_Dcm_cprecioventamax == 0)
                { _P_Dcm_cprecioventamax = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cprecioventamax"]); }
                if (_P_Dcm_cpreciolista == 0)
                { _P_Dcm_cpreciolista = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cpreciolista"]); }
                if (_P_Dcm_ccostonetolote == 0)
                { _P_Dcm_ccostonetolote = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["ccostonetolote"]); }
            }
        }
        bool _Bol_Mensaje = false;//Si entra en CellValueChanged no mostrara los mensajes de CellEndEdit
        private void _Dg_Grid2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_Mtd_VerifContTextBoxVarcharNoCero(_Txt_Fac) & _Mtd_VerifContTextBoxNumeric(_Txt_NumCtrl) & !_Bol_Mensaje)//Guia sada valid
            {
                if (e.ColumnIndex == 0)
                {
                    bool _Bol_ = false;
                    int _int_i = -1;
                    foreach (DataGridViewRow _DgRow in _Dg_Grid2.Rows)
                    {
                        try
                        {
                            if (Convert.ToString(_DgRow.Cells[0].Value).ToString().Trim().ToUpper() == Convert.ToString(_Dg_Grid2.Rows[e.RowIndex].Cells[0].Value).ToString().Trim().ToUpper() & _DgRow.Index != e.RowIndex & Convert.ToString(_Dg_Grid2.Rows[e.RowIndex].Cells[0].Value).ToString().Trim().Length > 0)
                            {
                                _Bol_ = true;
                                _int_i++;
                                break;
                            }
                        }
                        catch { }
                    }
                    if (!_Bol_)
                    {
                        DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("Select cnamefc,produc_descrip_2,cproducto, ccontenidoma1, ccontenidoma2, cunidad2, cactivate FROM VST_PRODUCTOS where ccodfabrica='" + Convert.ToString(_Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[0].Value).Trim() + "' and cproveedor='" + _Str_Proveedor + "'");
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            if (_Ds.Tables[0].Rows[0]["cactivate"].ToString().Trim() == "1")
                            {
                                _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value.ToString().Trim().ToUpper();//CODIGO FABRICA
                                _Dg_Grid2.Rows[e.RowIndex].Cells[3].Value = _Ds.Tables[0].Rows[0]["cnamefc"].ToString().Trim() + " " + _Ds.Tables[0].Rows[0]["produc_descrip_2"].ToString().Trim();//DESCRIPCION
                                _Dg_Grid2.Rows[e.RowIndex].Cells[2].Value = _Ds.Tables[0].Rows[0]["cproducto"].ToString();//COD.T3
                                _Dg_Grid2.Rows[e.RowIndex].Cells[9].Value = _Ds.Tables[0].Rows[0]["ccontenidoma1"].ToString().Trim();
                                _Dg_Grid2.Rows[e.RowIndex].Cells[10].Value = _Ds.Tables[0].Rows[0]["ccontenidoma2"].ToString().Trim();
                                //var _Dcm_cprecioventamax = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cprecioventamax"].ToString());
                                //_Dg_Grid2.Rows[e.RowIndex].Cells["CostoNeto"].Value = _Mtd_RetornarCostoNeto(_Ds.Tables[0].Rows[0]["cproducto"].ToString(), _Dcm_cprecioventamax);
                                if (_Ds.Tables[0].Rows[0]["cunidad2"].ToString().Trim() == "1")
                                {
                                    _Dg_Grid2.Rows[e.RowIndex].Cells[5].ReadOnly = false;
                                }
                                else
                                {
                                    _Dg_Grid2.Rows[e.RowIndex].Cells[5].ReadOnly = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("El producto cargado esta inactivo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = _Str_Temp_Producto;
                            }
                        }
                        else
                        {
                            MessageBox.Show("El producto cargado no corresponde con el proveedor seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = _Str_Temp_Producto;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El producto escrito ya a sido cargado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (e.RowIndex != _int_i)
                        {
                            _Dg_Grid2.Rows[e.RowIndex].Cells[0].Value = null;
                            _Dg_Grid2.Rows[e.RowIndex].Cells[3].Value = null;
                            _Dg_Grid2.Rows[e.RowIndex].Cells[2].Value = null;
                        }
                    }
                }
                else if ((e.ColumnIndex == 13) && (_Dg_Grid2.Rows[e.RowIndex].Cells["cprecioventamax"].Value != null))
                {
	                bool _Bol_EsValidoPMV = true, _Bol_NoTienePMV = true;
	                string _Str_SQL;
	                DataSet _Ds;

	                /*
	                 * Validaciones cuando se esté ingresando el precio máximo de venta - Sprint 16.
	                 */

                    using (DataGridViewRow _Obj_Fila = _Dg_Grid2.Rows[e.RowIndex])
                    {
                        _Str_SQL = "SELECT cregpmv FROM TPRODUCTO WHERE cproducto = '" + _Obj_Fila.Cells[2].Value.ToString() + "';";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                        if (_Ds.Tables[0].Rows[0]["cregpmv"].ToString() == "1" || _Ds.Tables[0].Rows[0]["cregpmv"].ToString() == "2")
                        {
                            _Bol_EsValidoPMV = _MyUtilidad._Mtd_VerificarPMV(_Obj_Fila.Cells[2].Value.ToString(), Convert.ToDecimal(_Obj_Fila.Cells["cprecioventamax"].Value), out _Bol_NoTienePMV);

                            if (!_Bol_NoTienePMV)
                            {
                                _Obj_Fila.DefaultCellStyle.BackColor = Color.Gold;
                                _Obj_Fila.Cells["ccostobrutolote"].Style.BackColor = Color.Gold;
                                _Obj_Fila.Cells["cpreciolista"].Style.BackColor = Color.Gold;
                                _Obj_Fila.Cells["Column9"].Style.BackColor = Color.Gold;
                                _Obj_Fila.Cells["Unidades"].Style.BackColor = Color.Gold;
                                _Obj_Fila.Cells["Column10"].Style.BackColor = Color.Gold;
                                MessageBox.Show("El producto requiere el precio máximo de venta al público y este no se encuentra configurado.",
                                                "Advertencia",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information,
                                                MessageBoxDefaultButton.Button1);
                                return;
                            }

                            if (!_Bol_EsValidoPMV)
                            {
                                _Obj_Fila.DefaultCellStyle.BackColor = Color.Gold;
                                _Obj_Fila.Cells["ccostobrutolote"].Style.BackColor = Color.Gold;
                                _Obj_Fila.Cells["cpreciolista"].Style.BackColor = Color.Gold;
                                _Obj_Fila.Cells["Column9"].Style.BackColor = Color.Gold;
                                _Obj_Fila.Cells["Unidades"].Style.BackColor = Color.Gold;
                                _Obj_Fila.Cells["Column10"].Style.BackColor = Color.Gold;
                                MessageBox.Show("El precio máximo de venta que está ingresando debe ser igual al que está registrado en el sistema.",
                                                "Advertencia",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information,
                                                MessageBoxDefaultButton.Button1);
                                return;
                            }


                            //Validacion de Producto con regulacion flexible
                            var _Str_cproducto = _Obj_Fila.Cells[2].Value.ToString();
                            if (!_MyUtilidad._Mtd_ProductoEsConRegulacionFlexible(_Str_cproducto))
                            {
                                if (Convert.ToDecimal(_Obj_Fila.Cells["cprecioventamax"].Value.ToString()) == 0)
                                {
                                    _Obj_Fila.DefaultCellStyle.BackColor = Color.Gold;
                                    _Obj_Fila.Cells["ccostobrutolote"].Style.BackColor = Color.Gold;
                                    _Obj_Fila.Cells["cpreciolista"].Style.BackColor = Color.Gold;
                                    _Obj_Fila.Cells["Column9"].Style.BackColor = Color.Gold;
                                    _Obj_Fila.Cells["Unidades"].Style.BackColor = Color.Gold;
                                    _Obj_Fila.Cells["Column10"].Style.BackColor = Color.Gold;
                                    MessageBox.Show("Este producto requiere precio máximo de venta, por lo tanto, no puede ser igual cero.",
                                                    "Advertencia",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information,
                                                    MessageBoxDefaultButton.Button1);
                                    return;
                                }
                            }

                            //Si pasamos por aqui es que todo esta bien, obtenmos el costo bruto segun el pvjusto selccionado
                            var _Dcm_cpvjusto = Convert.ToDecimal(_Obj_Fila.Cells["cprecioventamax"].Value);
                            var _Dcm_ccostobrutolote = _MyUtilidad._Mtd_ObtenerCostoBrutoSegunProductoPvJusto(_Str_cproducto, _Dcm_cpvjusto);
                            _Dg_Grid2.Rows[e.RowIndex].Cells["ccostobrutolote"].Value = _Dcm_ccostobrutolote;

                            //Todo bien
                            _Obj_Fila.DefaultCellStyle.BackColor = Color.White;
                            _Obj_Fila.Cells["ccostobrutolote"].Style.BackColor = Color.FromArgb(255, 255, 192);
                            _Obj_Fila.Cells["cpreciolista"].Style.BackColor = Color.FromArgb(255, 255, 192);
                            _Obj_Fila.Cells["Column9"].Style.BackColor = Color.FromArgb(255, 255, 192);
                            _Obj_Fila.Cells["Unidades"].Style.BackColor = Color.FromArgb(255, 255, 192);
                            _Obj_Fila.Cells["Column10"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        }
                    }
                }

                _Dg_Grid2.Refresh();

                try
                {
                    int _Int_Cajas = 0;
                    int _Int_Unidades = 0;
                    decimal _Dcm_Precio = 0;
                    decimal _Dcm_ccostobrutolote = 0;
                    decimal _Dcm_ccostonetolote = 0;
                    decimal _Dcm_cprecioventamax = 0;
                    decimal _Dcm_cpreciolista = 0;
                    int.TryParse(Convert.ToString(_Dg_Grid2.Rows[e.RowIndex].Cells[4].Value).Trim(), out _Int_Cajas);
                    int.TryParse(Convert.ToString(_Dg_Grid2.Rows[e.RowIndex].Cells[5].Value).Trim(), out _Int_Unidades);
                    decimal.TryParse(Convert.ToString(_Dg_Grid2.Rows[e.RowIndex].Cells[6].Value).Trim(), out _Dcm_Precio);
                    decimal.TryParse(Convert.ToString(_Dg_Grid2.Rows[e.RowIndex].Cells["ccostobrutolote"].Value).Trim(), out _Dcm_ccostobrutolote);
                    decimal.TryParse(Convert.ToString(_Dg_Grid2.Rows[e.RowIndex].Cells["cprecioventamax"].Value).Trim(), out _Dcm_cprecioventamax);
                    decimal.TryParse(Convert.ToString(_Dg_Grid2.Rows[e.RowIndex].Cells["cpreciolista"].Value).Trim(), out _Dcm_cpreciolista);
                    if (_Int_Cajas < 0) { _Int_Cajas = 0; }
                    if (_Int_Unidades < 0) { _Int_Unidades = 0; }
                    _Dg_Grid2.Rows[e.RowIndex].Cells[4].Value = _Int_Cajas;
                    _Dg_Grid2.Rows[e.RowIndex].Cells[5].Value = _Int_Unidades;
                    _Dg_Grid2.Rows[e.RowIndex].Cells[6].Value = _Dcm_Precio;
                    if (_Dcm_Precio == 0) { _Dg_Grid2.Rows[e.RowIndex].Cells[7].Value = 0; }
                    _Mtd_ObtenerCostoBrutoCostoNetoPrecioListayPrecioMax(Convert.ToString(_Dg_Grid2.Rows[e.RowIndex].Cells[2].Value).Trim(), ref _Dcm_ccostobrutolote, ref _Dcm_cprecioventamax, ref _Dcm_cpreciolista, ref _Dcm_ccostonetolote);
                    if (e.ColumnIndex == 13)
                        _Dg_Grid2.Rows[e.RowIndex].Cells["CostoNeto"].Value = _Mtd_RetornarCostoNeto(Convert.ToString(_Dg_Grid2.Rows[e.RowIndex].Cells["ProductoInterno"].Value).Trim(), _Dcm_cprecioventamax);
                    _Dg_Grid2.Rows[e.RowIndex].Cells["ccostobrutolote"].Value = _Dcm_ccostobrutolote;
                    _Dg_Grid2.Rows[e.RowIndex].Cells["cprecioventamax"].Value = _Dcm_cprecioventamax;
                    _Dg_Grid2.Rows[e.RowIndex].Cells["cpreciolista"].Value = _Dcm_cpreciolista;
                    _Dg_Grid2.Rows[e.RowIndex].Cells["cprecioventamax"].ReadOnly = !_Mtd_ObligatorioPMV(Convert.ToString(_Dg_Grid2.Rows[e.RowIndex].Cells["ProductoInterno"].Value).Trim());
                    if (_Dcm_Precio > 0 & (_Int_Cajas > 0 || _Int_Unidades > 0))
                    {
                        //if (_Dcm_ccostobrutolote > 0 & _Dcm_cprecioventamax > 0 & _Dcm_cpreciolista > 0)
                        if (_Dcm_ccostobrutolote > 0 && (_Dcm_cprecioventamax > 0 || _Dg_Grid2.Rows[e.RowIndex].Cells["cprecioventamax"].ReadOnly) && _Dcm_cpreciolista > 0)
                        {
                            if (e.RowIndex == _Dg_Grid2.RowCount - 1)
                            { _Dg_Grid2.Rows.Add(); }
                        }
                        //----------------------------------Cálculo del costo neto
                        decimal _Dcm_Uni = 0;
                        int _Int_ContenidoU = Convert.ToInt32(_Dg_Grid2.Rows[e.RowIndex].Cells[9].Value.ToString()) / Convert.ToInt32(_Dg_Grid2.Rows[e.RowIndex].Cells[10].Value.ToString());
                        int _Int_CantidadUni = (_Int_Cajas * (Convert.ToInt32(_Dg_Grid2.Rows[e.RowIndex].Cells[9].Value.ToString()) / Convert.ToInt32(_Dg_Grid2.Rows[e.RowIndex].Cells[10].Value.ToString()))) + _Int_Unidades;
                        decimal _Dcm_Descuento = _Mtd_ValorDescuento(Convert.ToString(_Dg_Grid2.Rows[e.RowIndex].Cells[8].Value).Trim(), Convert.ToDecimal(_Dg_Grid2.Rows[e.RowIndex].Cells[6].Value));
                        _Dcm_Uni = (Convert.ToDecimal(_Dg_Grid2.Rows[e.RowIndex].Cells[6].Value.ToString()) - _Dcm_Descuento) / _Int_CantidadUni;
                        _Dcm_Uni = _Dcm_Uni * _Int_ContenidoU;
                        //----------------------------------Cálculo del costo neto
                        if (_Mtd_EvaluarCostoNetoCostoBruto(_Dcm_Uni, _Dcm_ccostobrutolote))
                        {
                            if (MessageBox.Show(_Mtd_MensajeCostonetoCostoBruto(Convert.ToString(_Dg_Grid2.Rows[e.RowIndex].Cells["ProductoInterno"].Value), _Dcm_Uni, _Dcm_ccostobrutolote), "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                            {
                                _Dg_Grid2.Rows[e.RowIndex].Cells[4].Value = "0";
                                _Dg_Grid2.Rows[e.RowIndex].Cells[5].Value = "0";
                                _Dg_Grid2.Rows[e.RowIndex].Cells[6].Value = "0";
                                _Dg_Grid2.Rows[e.RowIndex].Cells[7].Value = "0";
                            }
                            else
                            {
                                _Dg_Grid2.Rows[e.RowIndex].Cells[7].Value = _Dcm_Uni.ToString("#,##0.00");
                                _Txt_Cajas.Text = _Mtd_Contar_Cajas().ToString();
                                _Txt_Unidades.Text = _Mtd_Contar_Unidades().ToString();
                            }
                        }
                        else
                        {
                            _Dg_Grid2.Rows[e.RowIndex].Cells[7].Value = _Dcm_Uni.ToString("#,##0.00");
                            _Txt_Cajas.Text = _Mtd_Contar_Cajas().ToString();
                            _Txt_Unidades.Text = _Mtd_Contar_Unidades().ToString();
                        }
                    }
                }
                catch { }
                
                _Mtd_Totalizar();

                /*
                 * Validaciones cuando se esté para el costo por unidad del producto - Sprint 16.
                 */

                if ((e.ColumnIndex == 4) || (e.ColumnIndex == 6))
                {
                    decimal _Dec_PMVPI;

                    if (!_Mtd_ValidarCostoUnidadMinimaActual(out _Dec_PMVPI))
                    {
                       _Dg_Grid2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gold;
                       _Dg_Grid2.Rows[e.RowIndex].Cells["ccostobrutolote"].Style.BackColor = Color.Gold;
                       _Dg_Grid2.Rows[e.RowIndex].Cells["cpreciolista"].Style.BackColor = Color.Gold;
                       //_Obj_Fila.Cells["cprecioventamax"].Style.BackColor = Color.FromArgb(255, 255, 192);
                       _Dg_Grid2.Rows[e.RowIndex].Cells["Column9"].Style.BackColor = Color.Gold;
                       _Dg_Grid2.Rows[e.RowIndex].Cells["Unidades"].Style.BackColor = Color.Gold;
                       _Dg_Grid2.Rows[e.RowIndex].Cells["Column10"].Style.BackColor = Color.Gold;
                        MessageBox.Show("El costo por unidad del producto no puede ser superior al precio máximo de venta del productor, valor del PMVPI = " + _Dec_PMVPI + ".",
                                        "Advertencia",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information,
                                        MessageBoxDefaultButton.Button1);

                        _Dg_Grid2.Rows[e.RowIndex].Cells[6].Value = 0;
                        _Dg_Grid2.Rows[e.RowIndex].Cells[7].Value = 0;

                        return;
                    }
                    else
                    {
                        _Dg_Grid2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        _Dg_Grid2.Rows[e.RowIndex].Cells["ccostobrutolote"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        _Dg_Grid2.Rows[e.RowIndex].Cells["cpreciolista"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        //_Obj_Fila.Cells["cprecioventamax"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        _Dg_Grid2.Rows[e.RowIndex].Cells["Column9"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        _Dg_Grid2.Rows[e.RowIndex].Cells["Unidades"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        _Dg_Grid2.Rows[e.RowIndex].Cells["Column10"].Style.BackColor = Color.FromArgb(255, 255, 192);
                    }
                    if (!_Mtd_ValidarCostoUnidadMinimaActualExistencia(out _Dec_PMVPI))
                    {
                        _Dg_Grid2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gold;
                        _Dg_Grid2.Rows[e.RowIndex].Cells["ccostobrutolote"].Style.BackColor = Color.Gold;
                        _Dg_Grid2.Rows[e.RowIndex].Cells["cpreciolista"].Style.BackColor = Color.Gold;
                        //_Obj_Fila.Cells["cprecioventamax"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        _Dg_Grid2.Rows[e.RowIndex].Cells["Column9"].Style.BackColor = Color.Gold;
                        _Dg_Grid2.Rows[e.RowIndex].Cells["Unidades"].Style.BackColor = Color.Gold;
                        _Dg_Grid2.Rows[e.RowIndex].Cells["Column10"].Style.BackColor = Color.Gold;
                        MessageBox.Show("El producto requiere el precio máximo de venta del producto y este no se encuentra configurado",
                                        "Advertencia",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information,
                                        MessageBoxDefaultButton.Button1);

                        _Dg_Grid2.Rows[e.RowIndex].Cells[6].Value = 0;
                        _Dg_Grid2.Rows[e.RowIndex].Cells[7].Value = 0;

                        return;
                    }
                    else
                    {
                        _Dg_Grid2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        _Dg_Grid2.Rows[e.RowIndex].Cells["ccostobrutolote"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        _Dg_Grid2.Rows[e.RowIndex].Cells["cpreciolista"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        //_Obj_Fila.Cells["cprecioventamax"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        _Dg_Grid2.Rows[e.RowIndex].Cells["Column9"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        _Dg_Grid2.Rows[e.RowIndex].Cells["Unidades"].Style.BackColor = Color.FromArgb(255, 255, 192);
                        _Dg_Grid2.Rows[e.RowIndex].Cells["Column10"].Style.BackColor = Color.FromArgb(255, 255, 192);
                    }
                }
            }

            _Bol_Mensaje = false;
        }
        private void _Dg_Grid2_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgCargaInfo.Visible = true;
            }
            else
            {
                _Lbl_DgCargaInfo.Visible = false;
            }
        }

        private void _Dg_Grid2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            _Er_Error.Dispose();
            if (_Dg_Grid2.CurrentCell.ColumnIndex == 4 || _Dg_Grid2.CurrentCell.ColumnIndex == 5 || _Dg_Grid2.CurrentCell.ColumnIndex == 6 || _Dg_Grid2.CurrentCell.ColumnIndex == 8 || _Dg_Grid2.CurrentCell.ColumnIndex == 0 || _Dg_Grid2.Columns[_Dg_Grid2.CurrentCell.ColumnIndex].Name == "ccostobrutolote" ||  _Dg_Grid2.Columns[_Dg_Grid2.CurrentCell.ColumnIndex].Name == "cpreciolista")
            {
                if (!_Mtd_VerifContTextBoxVarcharNoCero(_Txt_Fac) | !_Mtd_VerifContTextBoxNumeric(_Txt_NumCtrl))
                {
                    ((TextBox)e.Control).ReadOnly = true;
                    if (!_Mtd_VerifContTextBoxVarcharNoCero(_Txt_Fac)) { _Er_Error.SetError(_Txt_Fac, "Información requerida!!!"); }
                    if (!_Mtd_VerifContTextBoxNumeric(_Txt_NumCtrl)) { _Er_Error.SetError(_Txt_NumCtrl, "Información requerida!!!"); }
                    //if (!_Mtd_VerifContTextBoxVarcharNoCero(_Txt_GuiaSada)) { _Er_Error.SetError(_Txt_GuiaSada, "Información requerida!!!"); }
                }
                else if (Convert.ToString(_Dg_Grid2[0, _Dg_Grid2.CurrentCell.RowIndex].Value).Length == 0 & _Dg_Grid2.CurrentCell.ColumnIndex != 0)
                { ((TextBox)e.Control).ReadOnly = true; }
                else
                { ((TextBox)e.Control).ReadOnly = false; }
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }
        }

        void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_Mtd_VerifContTextBoxVarcharNoCero(_Txt_Fac) & _Mtd_VerifContTextBoxNumeric(_Txt_NumCtrl))//guia sada valid
            {
                if (_Dg_Grid2.CurrentCell.ColumnIndex == 6 || _Dg_Grid2.Columns[_Dg_Grid2.CurrentCell.ColumnIndex].Name == "ccostobrutolote" || _Dg_Grid2.Columns[_Dg_Grid2.CurrentCell.ColumnIndex].Name == "cprecioventamax" || _Dg_Grid2.Columns[_Dg_Grid2.CurrentCell.ColumnIndex].Name == "cpreciolista")
                {
                    _MyUtilidad._Mtd_Valida_Numeros(((TextBox)sender), e, 18, 2);
                }
                else if (_Dg_Grid2.CurrentCell.ColumnIndex != 8 & _Dg_Grid2.CurrentCell.ColumnIndex != 0)
                {
                    _MyUtilidad._Mtd_Valida_Numeros(((TextBox)sender), e, 6, 0);
                }
                else if (_Dg_Grid2.CurrentCell.ColumnIndex != 0)
                {
                    if (_Rb_R1.Checked)
                    {
                        _MyUtilidad._Mtd_Valida_Numeros(((TextBox)sender), e, 3, 2, 100);
                    }
                    else
                    {
                        double _Dbl_Prec = 0;
                        if (Convert.ToString(_Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[6].Value).Trim().Length > 0)
                        {
                            _Dbl_Prec = Convert.ToDouble(_Dg_Grid2.Rows[_Dg_Grid2.CurrentCell.RowIndex].Cells[6].Value);
                        }
                        _MyUtilidad._Mtd_Valida_Numeros(((TextBox)sender), e, 18, 2, _Dbl_Prec);
                    }
                }
            }
        }
        string _Str_Temp_Producto = "";
        string _Str_Temp_Cajas = "";
        string _Str_Temp_Unidades = "";
        private void _Dg_Grid2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                _Str_Temp_Producto = Convert.ToString(_Dg_Grid2.Rows[e.RowIndex].Cells[0].Value).Trim();
            }
            else if (e.ColumnIndex == 4 | e.ColumnIndex == 5)
            {
                _Str_Temp_Cajas = Convert.ToString(_Dg_Grid2.Rows[e.RowIndex].Cells[4].Value).Trim();
                _Str_Temp_Unidades = Convert.ToString(_Dg_Grid2.Rows[e.RowIndex].Cells[5].Value).Trim();
            }
        }

        private void _Cntx_Fact_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Grid.SelectedRows.Count != 1 | _Int_Switch == 2)
            { e.Cancel = true; }
        }

        private void _Cntx_Prod_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Grid2.SelectedRows.Count != 1 | !_Bt_Copiar.Enabled)
            { e.Cancel = true; }
        }

        private void _Tool_EditFact_Click(object sender, EventArgs e)
        {
            if (_Dg_Grid.CurrentCell.RowIndex != -1)
            {
                _Mtd_MostrarDet();
                _Tb_Tab.SelectedIndex = 1;
                _Bt_Editar.PerformClick();
            }
        }

        private void _Tool_ElimFact_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la factura?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string _Str_Factura = _Dg_Grid.Rows[_Dg_Grid.CurrentCell.RowIndex].Cells[0].Value.ToString();
                string _Str_Cadena = "Delete from TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_Rec.Text.Trim() + "' and cnfacturapro='" + _Str_Factura + "' and cproveedor='" + _Str_Proveedor + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "Delete from TRECEPCIONDFD where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidrecepcion='" + _Txt_Rec.Text.Trim() + "' and cnfacturapro='" + _Str_Factura + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                if (_Mtd_SoloMaestra(_Txt_Rec.Text.Trim()))
                {
                    _Str_Cadena = "UPDATE TRECEPCIONM SET ccargfactura='0' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _Txt_Rec.Text.Trim() + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    _Bt_Nuevo.Enabled = true; _Bt_Finalizar.Enabled = true; _Int_Switch = 0; _Tb_Tab.SelectedIndex = 1;
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                    _Mtd_Actualizar();
                    _Mtd_Inicializar();
                }
                else
                {
                    _Mtd_Actualizar();
                    _Mtd_Inicializar();
                    if (_Int_Switch == 1 & _Dg_Grid.RowCount == 0)
                    {
                        //Si se desean eliminar facturas ya aprobadas:
                        //Si se habilita se debe quitar la condición _Int_Switch == 2 del evento _Cntx_Fact_Opening para que aparezca el menu
                        //tambien se debe inhabilitar el menú editar del ContextMenuStrip.
                        if (_Mtd_TodasFactCorrectas(_Txt_Rec.Text.Trim()))
                        {
                            _Str_Cadena = "UPDATE TRECEPCIONM SET ccargfactura='1' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidrecepcion='" + _Txt_Rec.Text.Trim() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }
                        System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                        this.Close();
                    }
                }
            }
        }

        private void _Tool_ElimProd_Click(object sender, EventArgs e)
        {
            if (!_Dg_Grid2.ReadOnly)
            {
                bool _Bol_Sw_Temp = false;
                if (_Dg_Grid2.CurrentCell.RowIndex == _Dg_Grid2.RowCount - 1)
                { _Bol_Sw_Temp = true; }
                _Dg_Grid2.Rows.RemoveAt(_Dg_Grid2.CurrentCell.RowIndex);
                _Mtd_Totalizar();
                if (_Dg_Grid2.Rows.Count == 0 | _Bol_Sw_Temp)
                { _Dg_Grid2.Rows.Add(); }
                else if (_Dg_Grid2.Rows.Count == 1)
                { _Bt_Depurar.Enabled = false; }
            }
        }

        private void _Txt_GuiaSada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "'" | e.KeyChar.ToString() == "*" | e.KeyChar.ToString() == "=" | e.KeyChar.ToString() == "%")
            {
                e.Handled = true;
            }
        }

        private void _Num_DescFinanciero_ValueChanged(object sender, EventArgs e)
        {
            _Mtd_Totalizar();
        }
    }   
}