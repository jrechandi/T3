using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace T3.Controles
{
    /// <summary>
    /// Delegado de los eventos click.
    /// </summary>
    public delegate void Click_Boton();

    /// <summary>
    /// Delegado de los eventos keypress.
    /// </summary>
    public delegate void KeyPress_Caja();

    /// <summary>
    /// Delegado de los eventos SelectionChangeCommitted.
    /// </summary>
    public delegate void SelectionChangeCommitted_Combo();

    public partial class _Ctrl_Multifiltro : UserControl
    {
        private clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");

        private string _Str_FiltroAnterior;

        private _Enu_TiposConsultas _Enu_TipoConsulta;

        /// <summary>
        /// Evento Click del filtro Rango.
        /// </summary>
        public event Click_Boton Click_Rango;

        /// <summary>
        /// Evento Click del filtro Vendedor.
        /// </summary>
        public event Click_Boton Click_Vendedor;

        /// <summary>
        /// Evento Click del filtro Cliente.
        /// </summary>
        public event Click_Boton Click_Cliente;

        /// <summary>
        /// Evento Click del filtro Proveedor.
        /// </summary>
        public event Click_Boton Click_Proveedor;

        /// <summary>
        /// Evento Click del filtro Banco.
        /// </summary>
        public event Click_Boton Click_Banco;

        /// <summary>
        /// Evento Click del filtro Gerente.
        /// </summary>
        public event Click_Boton Click_Gerente;

        /// <summary>
        /// Evento Click del filtro Producto.
        /// </summary>
        public event Click_Boton Click_Producto;

        /// <summary>
        /// Evento KeyPress del filtro Pedido.
        /// </summary>
        public event KeyPress_Caja KeyPress_Pedido;

        /// <summary>
        /// Evento KeyPress del filtro Prefactura.
        /// </summary>
        public event KeyPress_Caja KeyPress_Prefactura;

        /// <summary>
        /// Evento KeyPress del filtro Factura.
        /// </summary>
        public event KeyPress_Caja KeyPress_Factura;

        /// <summary>
        /// Evento SelectionChangeCommitted del filtro Año.
        /// </summary>
        public event SelectionChangeCommitted_Combo SelectionChangeCommitted_Año;

        /// <summary>
        /// Evento SelectionChangeCommitted del filtro Mes.
        /// </summary>
        public event SelectionChangeCommitted_Combo SelectionChangeCommitted_Mes;

        /// <summary>
        /// Evento SelectionChangeCommitted del filtro FiltrarPor.
        /// </summary>
        public event SelectionChangeCommitted_Combo SelectionChangeCommitted_FiltrarPor;

        /// <summary>
        /// Evento SelectionChangeCommitted del filtro Proveedores.
        /// </summary>
        public event SelectionChangeCommitted_Combo SelectionChangeCommitted_ProveedoresPGS;

        /// <summary>
        /// Evento SelectionChangeCommitted del filtro Grupos.
        /// </summary>
        public event SelectionChangeCommitted_Combo SelectionChangeCommitted_GruposPGS;

        /// <summary>
        /// Devuelve el filtro anterior.
        /// </summary>
        public string TipoFiltroAnterior
        {
            get { return _Str_FiltroAnterior; }
        }

        /// <summary>
        /// Devuelve el TextBox cliente.
        /// </summary>
        public TextBox Cliente
        {
            get { return _Txt_Cliente; }
        }

        /// <summary>
        /// Devuelve el TextBox rango.
        /// </summary>
        public TextBox Rango
        {
            get { return _Txt_Rango; }
        }

        /// <summary>
        /// Devuelve el TextBox vendedor.
        /// </summary>
        public TextBox Vendedor
        {
            get { return _Txt_Vendedor; }
        }

        /// <summary>
        /// Devuelve el TextBox proveedor.
        /// </summary>
        public TextBox Proveedor
        {
            get { return _Txt_Proveedor; }
        }

        /// <summary>
        /// Devuelve el TextBox banco.
        /// </summary>
        public TextBox Banco
        {
            get { return _Txt_Banco; }
        }

        /// <summary>
        /// Devuelve el TextBox gerente.
        /// </summary>
        public TextBox Gerente
        {
            get { return _Txt_Gerente; }
        }

        /// <summary>
        /// Devuelve el TextBox gerente.
        /// </summary>
        public TextBox Producto
        {
            get { return _Txt_Producto; }
        }

        /// <summary>
        /// Devuelve el pedido.
        /// </summary>
        public string Pedido
        {
            get { return _Txt_Pedido.Text; }
        }

        /// <summary>
        /// Devuelve la prefactura.
        /// </summary>
        public string Prefactura
        {
            get { return _Txt_Prefactura.Text; }
        }

        /// <summary>
        /// Devuelve la factura.
        /// </summary>
        public string Factura
        {
            get { return _Txt_Factura.Text; }
        }

        /// <summary>
        /// Devuelve el tipo de filtro.
        /// </summary>
        public string TipoFiltro
        {
            set { _Cmb_FiltrarPor.Text = value; }
            get { return _Cmb_FiltrarPor.Text; }
        }

        /// <summary>
        /// Devuelve la fecha desde.
        /// </summary>
        public string FechaDesde
        {
            get { return _Cls_Formato._Mtd_fecha(_Dtp_Desde.Value); }
        }

        /// <summary>
        /// Devuelve la fecha hasta.
        /// </summary>
        public string FechaHasta
        {
            get { return _Cls_Formato._Mtd_fecha(_Dtp_Hasta.Value); }
        }

        /// <summary>
        /// Devuelve el año.
        /// </summary>
        public int Año
        {
            get { return Convert.ToInt32(_Cmb_Año.SelectedValue); }
        }

        /// <summary>
        /// Devuelve el mes.
        /// </summary>
        public int Mes
        {
            get { return Convert.ToInt32(_Cmb_Mes.SelectedValue); }
        }

        /// <summary>
        /// Devuelve el estado.
        /// </summary>
        public string Estado
        {
            set { _Cmb_Estado.Text = value; }

            get
            {
                if (_Enu_TipoConsulta == _Enu_TiposConsultas.LimiteCreditoClientes)
                {
                    return Convert.ToDateTime(_Cmb_Estado.SelectedValue).ToShortDateString();
                }

                return _Cmb_Estado.Text;
            }
        }

        /// <summary>
        /// Devuelve el estado para el caso de reportes específicos.
        /// </summary>
        public string EstadoFijo
        {
            set { _Cmb_EstadoFijo.Text = value; }
            get { return _Cmb_EstadoFijo.Text; }
        }

        /// <summary>
        /// Devuelve el código.
        /// </summary>
        public string Codigo
        {
            get { return _Txt_Codigo.Text; }
        }

        /// <summary>
        /// Devuelve el TextBox proveedor.
        /// </summary>
        public TextBox TxtProveedor
        {
            get { return _Txt_Proveedor; }
        }

        /// <summary>
        /// Devuelve el proveedor PGSM.
        /// </summary>
        public string ProveedorPGSM
        {
            get { return _Cmb_ProveedorPGSM.SelectedValue.ToString(); }
        }

        /// <summary>
        /// Devuelve el grupo PGSM.
        /// </summary>
        public string GrupoPGSM
        {
            get { return _Cmb_GrupoPGSM.SelectedValue.ToString(); }
        }

        /// <summary>
        /// Devuelve el subgrupo PGSM.
        /// </summary>
        public string SubgrupoPGSM
        {
            get { return _Cmb_SubgrupoPGSM.SelectedValue.ToString(); }
        }

        /// <summary>
        /// Devuelve el marca PGSM.
        /// </summary>
        public string MarcaPGSM
        {
            get { return _Cmb_MarcaPGSM.SelectedValue.ToString(); }
        }

        /// <summary>
        /// Devuelve la fecha del reporte de valorizado de inventario.
        /// </summary>
        public string ValorizadoInventarioReporteFecha
        {
            get
            {
                if (_Cmb_ReporteValInv.SelectedValue == null)
                {
                    return DateTime.Now.ToString();
                }

                return _Cmb_ReporteValInv.SelectedValue.ToString();
            }
        }

        /// <summary>
        /// Devuelve el valor de si lleva impuesto el valorizado de inventario.
        /// </summary>
        public string ValorizadoInventarioImpuesto
        {
            get { return _Cmb_ImpuestoValInv.Text; }
        }

        /// <summary>
        /// Devuelve el tipo de existencia del valorizado de inventario.
        /// </summary>
        public string ValorizadoInventarioTipoExistencia
        {
            get { return _Cmb_TipoExisValInv.Text; }
        }

        /// <summary>
        /// Devuelve el nivel de detalle del reporte de valorizado de inventario.
        /// </summary>
        public string ValorizadoInventarioNivelDetalle
        {
            get { return _Cmb_NivelDetaValInv.Text; }
        }

        /// <summary>
        /// Carga los estados.
        /// </summary>
        private void _Mtd_CargarEstado()
        {
            _Cmb_Estado.Items.Clear();

            switch (_Enu_TipoConsulta)
            {
                case _Enu_TiposConsultas.Pedido:

                    _Cmb_Estado.Items.Add("PENDIENTE (POR FACTURAR Y BLOQUEADO POR CRÉDITO)");
                    _Cmb_Estado.Items.Add("BLOQUEADOS POR CRÉDITO - ACTUAL");
                    _Cmb_Estado.Items.Add("BLOQUEADOS POR CRÉDITO - HISTORICO");
                    _Cmb_Estado.Items.Add("RECHAZADOS POR EXISTENCIA");
                    _Cmb_Estado.Items.Add("POR FACTURAR");
                    _Cmb_Estado.Items.Add("ANULADOS");
                    _Cmb_Estado.Items.Add("FACTURADOS");

                    break;

                case _Enu_TiposConsultas.Prefactura:

                    _Cmb_Estado.Items.Add("PENDIENTE (POR FACTURAR Y EN PRE-CARGA)");
                    _Cmb_Estado.Items.Add("POR FACTURAR");
                    _Cmb_Estado.Items.Add("EN PRE-CARGA");
                    _Cmb_Estado.Items.Add("FACTURADAS");

                    break;

                case _Enu_TiposConsultas.ClientesEstatus:

                    _Cmb_Estado.Items.Add("ACTIVOS");
                    _Cmb_Estado.Items.Add("INACTIVOS");

                    break;

                case _Enu_TiposConsultas.RelacionChequesTransitoDepositado:

                    _Cmb_EstadoFijo.Items.Add("DEPOSITADOS");
                    _Cmb_EstadoFijo.Items.Add("EN TRÁNSITO");
                    _Cmb_EstadoFijo.Items.Add("TODOS");
                    _Cmb_EstadoFijo.Sorted = true;
                    _Cmb_EstadoFijo.SelectedIndex = 0;

                    break;
            }

            if (_Cmb_Estado.Items.Count > 0)
            {
                _Cmb_Estado.Sorted = true;
                _Cmb_Estado.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Carga los filtros. 
        /// </summary>
        /// <param name="_P_Enu_Tipo">Tipo de consulta.</param>
        public void _Mtd_CargarFiltros(_Enu_TiposConsultas _P_Enu_Tipo)
        {
            _Cmb_FiltrarPor.Items.Clear();

            _Enu_TipoConsulta = _P_Enu_Tipo;

            switch (_P_Enu_Tipo)
            {
                case _Enu_TiposConsultas.Pedido:

                    _Cmb_FiltrarPor.Items.Add("POR MES");
                    _Cmb_FiltrarPor.Items.Add("POR FECHA");
                    _Cmb_FiltrarPor.Items.Add("POR ESTADO");
                    _Cmb_FiltrarPor.Items.Add("POR CÓDIGO DE PEDIDO");
                    _Cmb_FiltrarPor.Items.Add("POR CLIENTE");
                    _Cmb_FiltrarPor.Items.Add("POR VENDEDOR");

                    break;

                case _Enu_TiposConsultas.Prefactura:

                    _Cmb_FiltrarPor.Items.Add("POR MES");
                    _Cmb_FiltrarPor.Items.Add("POR FECHA");
                    _Cmb_FiltrarPor.Items.Add("POR ESTADO");
                    _Cmb_FiltrarPor.Items.Add("POR CÓDIGO DE PEDIDO");
                    _Cmb_FiltrarPor.Items.Add("POR CÓDIGO DE PRE-FACTURA");
                    _Cmb_FiltrarPor.Items.Add("POR CLIENTE");
                    _Cmb_FiltrarPor.Items.Add("POR VENDEDOR");
                    _Cmb_FiltrarPor.Items.Add("POR GERENTE");
                    _Cmb_FiltrarPor.Items.Add("POR PRODUCTO");

                    break;

                case _Enu_TiposConsultas.Factura:

                    _Cmb_FiltrarPor.Items.Add("POR MES");
                    _Cmb_FiltrarPor.Items.Add("POR FECHA");
                    _Cmb_FiltrarPor.Items.Add("POR CÓDIGO DE PEDIDO");
                    _Cmb_FiltrarPor.Items.Add("POR CÓDIGO DE FACTURA");
                    _Cmb_FiltrarPor.Items.Add("POR CLIENTE");
                    _Cmb_FiltrarPor.Items.Add("POR VENDEDOR");

                    break;

                case _Enu_TiposConsultas.RecepcionComprasResumidoSemanal:

                    _Cmb_FiltrarPor.Items.Add("POR FECHA");

                    break;

                case _Enu_TiposConsultas.NotasRecepcionDetallado:

                    _Cmb_FiltrarPor.Items.Add("POR FECHA");
                    _Cmb_FiltrarPor.Items.Add("POR MES");
                    _Cmb_FiltrarPor.Items.Add("POR PROVEEDOR");
                    _Cmb_FiltrarPor.Items.Add("POR CÓDIGO DE LA NOTA");

                    _Lbl_Codigo.Text = "Código de la nota:";

                    _Txt_Codigo.Location = new Point((_Lbl_Codigo.Location.X + 130), _Txt_Codigo.Location.Y);

                    break;

                case _Enu_TiposConsultas.CostoUtilidadProducto:

                    _Cmb_FiltrarPorPGSM.Items.Add("POR PROVEEDOR, GRUPO O SUBGRUPO");
                    _Cmb_FiltrarPorPGSM.Items.Add("POR PROVEEDOR, GRUPO O MARCA");

                    _Pnl_PGSM.Location = new Point((_Cmb_FiltrarPor.Width + 100), _Pnl_PGSM.Location.Y);

                    Width += 100;

                    break;

                case _Enu_TiposConsultas.EfectividadCobranza:

                    _Cmb_FiltrarPor.Items.Add("POR FECHA");
                    _Cmb_FiltrarPor.Items.Add("POR MES");

                    break;

                case _Enu_TiposConsultas.ClientesEstatus:

                    _Cmb_FiltrarPor.Items.Add("POR FECHA DE CREACIÓN");
                    _Cmb_FiltrarPor.Items.Add("POR MES DE CREACIÓN");
                    _Cmb_FiltrarPor.Items.Add("POR ESTADO");

                    break;

                case _Enu_TiposConsultas.RelacionChequesTransitoDepositado:

                    _Cmb_FiltrarPor.Items.Add("POR FECHA");
                    _Cmb_FiltrarPor.Items.Add("POR MES");
                    _Cmb_FiltrarPor.Items.Add("POR BANCO");
                    _Cmb_FiltrarPor.Items.Add("POR CLIENTE");
                    _Cmb_FiltrarPor.Items.Add("POR N° DE CHEQUE");
                    _Cmb_FiltrarPor.Items.Add("POR N° DE DEPOSITO");

                    break;

                case _Enu_TiposConsultas.LimiteCreditoClientes:

                    _Cmb_FiltrarPor.Items.Add("POR MES");
                    
                    break;

                case _Enu_TiposConsultas.ValorizadoInventario:

                    _Cmb_ReporteValInv.Items.Add("ACTUAL");

                    _Cmb_ImpuestoValInv.Items.Add("SI, CON IMPUESTO");
                    _Cmb_ImpuestoValInv.Items.Add("NO, SIN IMPUESTO");

                    _Cmb_NivelDetaValInv.Items.Add("TODOS LOS PRODUCTOS");
                    _Cmb_NivelDetaValInv.Items.Add("RESUMIDO");

                    _Cmb_TipoExisValInv.Items.Add("COMPLETA (DISPONIBLE + COMPROMETIDA)");
                    _Cmb_TipoExisValInv.Items.Add("REAL (SÓLO DISPONIBLE)");
                    _Cmb_TipoExisValInv.Items.Add("MAL ESTADO (SÓLO MAL ESTADO)");

                    _Cmb_FiltrarPorPGSM.Items.Add("POR PROVEEDOR, GRUPO O SUBGRUPO");
                    _Cmb_FiltrarPorPGSM.Items.Add("POR PROVEEDOR, GRUPO O MARCA");

                    break;

                case _Enu_TiposConsultas.LotesPorDevolucion:

                    _Cmb_FiltrarPor.Items.Add("POR NOTA DE CRÉDITO");
                    _Cmb_FiltrarPor.Items.Add("POR NOTA DE DEVOLUCIÓN");

                    _Lbl_Codigo.Text = "N°:";

                    break;

                case _Enu_TiposConsultas.FacturasProductos:

                    _Cmb_FiltrarPor.Items.Add("POR FECHA");
                    _Cmb_FiltrarPor.Items.Add("POR MES");

                    break;

                case _Enu_TiposConsultas.DetalleLotesFacturas:

                    _Cmb_FiltrarPor.Items.Add("POR FECHA");

                    break;
            }

            _Cmb_FiltrarPor.Sorted = true;

            if (_Cmb_FiltrarPor.Items.Contains("POR MES"))
            {
                _Cmb_FiltrarPor.SelectedIndex = _Cmb_FiltrarPor.Items.IndexOf("POR MES");
            }
            else if (_Cmb_FiltrarPor.Items.Contains("POR MES DE CREACIÓN"))
            {
                _Cmb_FiltrarPor.SelectedIndex = _Cmb_FiltrarPor.Items.IndexOf("POR MES DE CREACIÓN");
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.ValorizadoInventario)
            {
                _Cmb_ReporteValInv.SelectedIndex = 0;
                _Cmb_ImpuestoValInv.SelectedIndex = 0;
                _Cmb_NivelDetaValInv.SelectedIndex = 0;
                _Cmb_TipoExisValInv.SelectedIndex = 0;
                _Cmb_FiltrarPorPGSM.SelectedIndex = 0;
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.CostoUtilidadProducto)
            {
                _Cmb_FiltrarPorPGSM.SelectedIndex = 0;
            }
            else
            {
                _Cmb_FiltrarPor.SelectedIndex = 0;
            }

            _Mtd_CargarEstado();
        }

        /// <summary>
        /// Carga los años.
        /// </summary>
        /// <param name="_P_Dat_Datos">Dataset con los resultados de la consulta.</param>
        public void _Mtd_CargarAños(DataSet _P_Dat_Datos)
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();

            _Cmb_Año.DataSource = null;

            foreach (DataRow Fila in _P_Dat_Datos.Tables[0].Rows)
            {
                _myArrayList.Add(new Clases._Cls_ArrayList(Fila[1].ToString(), Fila[0].ToString()));
            }

            _Cmb_Año.DataSource = _myArrayList;
            _Cmb_Año.DisplayMember = "Display";
            _Cmb_Año.ValueMember = "Value";
        }

        /// <summary>
        /// Carga los meses.
        /// </summary>
        /// <param name="_P_Dat_Datos">Dataset con los resultados de la consulta.</param>
        public void _Mtd_CargarMeses(DataSet _P_Dat_Datos)
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();

            _Cmb_Mes.DataSource = null;

            foreach (DataRow Fila in _P_Dat_Datos.Tables[0].Rows)
            {
                _myArrayList.Add(new Clases._Cls_ArrayList(Fila[1].ToString(), Fila[0].ToString()));
            }

            _Cmb_Mes.DataSource = _myArrayList;
            _Cmb_Mes.DisplayMember = "Display";
            _Cmb_Mes.ValueMember = "Value";
        }

        /// <summary>
        /// Carga los períodos para el reporte de valorización de inventario.
        /// </summary>
        /// <param name="_P_Dat_Datos">Dataset con los resultados de la consulta.</param>
        public void _Mtd_CargarPeriodo(DataSet _P_Dat_Datos)
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();

            if (_P_Dat_Datos.Tables[0].Rows.Count > 0)
            {
                _Cmb_ReporteValInv.DataSource = null;

                foreach (DataRow Fila in _P_Dat_Datos.Tables[0].Rows)
                {
                    _myArrayList.Add(new Clases._Cls_ArrayList(Fila[1].ToString(), Fila[0].ToString()));
                }

                _Cmb_ReporteValInv.DataSource = _myArrayList;
                _Cmb_ReporteValInv.DisplayMember = "Display";
                _Cmb_ReporteValInv.ValueMember = "Value";
            }
        }

        /// <summary>
        /// Carga los proveedores.
        /// </summary>
        /// <param name="_P_Dat_Datos">Dataset con los resultados de la consulta.</param>
        public void _Mtd_CargarProveedores(DataSet _P_Dat_Datos)
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();

            _Cmb_ProveedorPGSM.DataSource = null;

            _myArrayList.Add(new Clases._Cls_ArrayList("TODOS", "0"));

            foreach (DataRow Fila in _P_Dat_Datos.Tables[0].Rows)
            {
                _myArrayList.Add(new Clases._Cls_ArrayList(Fila[1].ToString(), Fila[0].ToString()));
            }

            _Cmb_ProveedorPGSM.DataSource = _myArrayList;
            _Cmb_ProveedorPGSM.DisplayMember = "Display";
            _Cmb_ProveedorPGSM.ValueMember = "Value";
        }

        /// <summary>
        /// Carga los grupos.
        /// </summary>
        /// <param name="_P_Dat_Datos">Dataset con los resultados de la consulta.</param>
        public void _Mtd_CargarGrupos(DataSet _P_Dat_Datos)
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();

            _Cmb_GrupoPGSM.DataSource = null;

            _myArrayList.Add(new Clases._Cls_ArrayList("TODOS", "0"));

            foreach (DataRow Fila in _P_Dat_Datos.Tables[0].Rows)
            {
                _myArrayList.Add(new Clases._Cls_ArrayList(Fila[1].ToString(), Fila[0].ToString()));
            }

            _Cmb_GrupoPGSM.DataSource = _myArrayList;
            _Cmb_GrupoPGSM.DisplayMember = "Display";
            _Cmb_GrupoPGSM.ValueMember = "Value";
        }

        /// <summary>
        /// Carga los subgrupos.
        /// </summary>
        /// <param name="_P_Dat_Datos">Dataset con los resultados de la consulta.</param>
        public void _Mtd_CargarSubgrupos(DataSet _P_Dat_Datos)
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();

            _Cmb_SubgrupoPGSM.DataSource = null;

            _myArrayList.Add(new Clases._Cls_ArrayList("TODOS", "0"));

            foreach (DataRow Fila in _P_Dat_Datos.Tables[0].Rows)
            {
                _myArrayList.Add(new Clases._Cls_ArrayList(Fila[1].ToString(), Fila[0].ToString()));
            }

            _Cmb_SubgrupoPGSM.DataSource = _myArrayList;
            _Cmb_SubgrupoPGSM.DisplayMember = "Display";
            _Cmb_SubgrupoPGSM.ValueMember = "Value";
        }

        /// <summary>
        /// Carga las marcas.
        /// </summary>
        /// <param name="_P_Dat_Datos">Dataset con los resultados de la consulta.</param>
        public void _Mtd_CargarMarcas(DataSet _P_Dat_Datos)
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();

            _Cmb_MarcaPGSM.DataSource = null;

            _myArrayList.Add(new Clases._Cls_ArrayList("TODOS", "0"));

            foreach (DataRow Fila in _P_Dat_Datos.Tables[0].Rows)
            {
                _myArrayList.Add(new Clases._Cls_ArrayList(Fila[1].ToString(), Fila[0].ToString()));
            }

            _Cmb_MarcaPGSM.DataSource = _myArrayList;
            _Cmb_MarcaPGSM.DisplayMember = "Display";
            _Cmb_MarcaPGSM.ValueMember = "Value";
        }

        /// <summary>
        /// Carga los reportes generados.
        /// </summary>
        /// <param name="_P_Dat_Datos">Dataset con los resultados de la consulta.</param>
        public void _Mtd_CargarReportesGenerados(DataSet _P_Dat_Datos)
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();

            _Cmb_Estado.DataSource = null;

            foreach (DataRow Fila in _P_Dat_Datos.Tables[0].Rows)
            {
                _myArrayList.Add(new Clases._Cls_ArrayList(Fila[1].ToString(), Fila[0].ToString()));
            }

            if (_P_Dat_Datos.Tables[0].Rows.Count > 0)
            {
                _Cmb_Estado.DataSource = _myArrayList;
                _Cmb_Estado.DisplayMember = "Display";
                _Cmb_Estado.ValueMember = "Value";
            }
        }

        /// <summary>
        /// Agrega un filtro al combo.
        /// </summary>
        /// <param name="_P_Str_Filtro">Nombre del filtro.</param>
        public void _Mtd_AgregarFiltro(string _P_Str_Filtro)
        {
            if (!_Cmb_FiltrarPor.Items.Contains(_P_Str_Filtro))
            {
                _Cmb_FiltrarPor.Items.Add(_P_Str_Filtro);

                if (_P_Str_Filtro == "POR FECHA")
                {
                    _Cmb_FiltrarPor.Items.Add("POR MES");
                }
                else if (_P_Str_Filtro == "POR MES")
                {
                    _Cmb_FiltrarPor.Items.Add("POR FECHA");
                }

                if (_P_Str_Filtro == "POR FECHA DE CREACIÓN")
                {
                    _Cmb_FiltrarPor.Items.Add("POR MES DE CREACIÓN");
                }
                else if (_P_Str_Filtro == "POR MES DE CREACIÓN")
                {
                    _Cmb_FiltrarPor.Items.Add("POR FECHA DE CREACIÓN");
                }
            }
        }

        /// <summary>
        /// Elimina un filtro del combo.
        /// </summary>
        /// <param name="_P_Str_Filtro">Nombre del filtro a remover.</param>
        public void _Mtd_RemoverFiltro(string _P_Str_Filtro)
        {
            if (_Cmb_FiltrarPor.Items.Contains(_P_Str_Filtro))
            {
                _Cmb_FiltrarPor.Items.Remove(_P_Str_Filtro);

                if (_P_Str_Filtro == "POR FECHA")
                {
                    _Cmb_FiltrarPor.Items.Remove("POR MES");
                }
                else if (_P_Str_Filtro == "POR MES")
                {
                    _Cmb_FiltrarPor.Items.Remove("POR FECHA");
                }

                if (_P_Str_Filtro == "POR FECHA DE CREACIÓN")
                {
                    _Cmb_FiltrarPor.Items.Remove("POR MES DE CREACIÓN");
                }
                else if (_P_Str_Filtro == "POR MES DE CREACIÓN")
                {
                    _Cmb_FiltrarPor.Items.Remove("POR FECHA DE CREACIÓN");
                }

                if (!Visible)
                {
                    _Cmb_FiltrarPor.SelectedIndex = 0;
                    _Cmb_FiltrarPor.Text = _Cmb_FiltrarPor.Items[_Cmb_FiltrarPor.SelectedIndex].ToString();
                }
            }
        }

        /// <summary>
        /// Limpia los filtros y campos.
        /// </summary>
        public void _Mtd_Limpiar()
        {
            foreach (Control _Ctr_Control in _Pnl_Filtro.Controls)
            {
                if (_Ctr_Control is TextBox)
                {
                    TextBox _Txt_Caja = (TextBox) _Ctr_Control;

                    _Txt_Caja.Text = "";
                }
                else if (_Ctr_Control is ComboBox)
                {
                    ComboBox _Cmb_Combo = (ComboBox) _Ctr_Control;

                    _Cmb_Combo.Text = "";

                    if (_Cmb_Combo.Items.Count > 0)
                    {
                        _Cmb_Combo.SelectedIndex = 0;
                    }
                }
                else if (_Ctr_Control is DateTimePicker)
                {
                    DateTimePicker _Dte_Fecha = (DateTimePicker) _Ctr_Control;

                    _Dte_Fecha.Value = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Muestra el filtro seleccionado en el combo.
        /// </summary>
        /// <param name="_P_Str_Tipo">Tipo de filtro.</param>
        private void _Mtd_MostrarFiltro(string _P_Str_Tipo)
        {
            switch (_P_Str_Tipo)
            {
                case "POR CÓDIGO DE FACTURA":

                    foreach (Control _Ctrl_Control in _Pnl_Filtro.Controls)
                    {
                        if ((_Ctrl_Control is Label) && (_Ctrl_Control.Name == "_Lbl_Factura"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Lbl_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else if ((_Ctrl_Control is TextBox) && (_Ctrl_Control.Name == "_Txt_Factura"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Cmb_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else
                        {
                            _Ctrl_Control.Visible = false;
                        }
                    }

                    break;

                case "POR CÓDIGO DE PRE-FACTURA":

                    foreach (Control _Ctrl_Control in _Pnl_Filtro.Controls)
                    {
                        if ((_Ctrl_Control is Label) && (_Ctrl_Control.Name == "_Lbl_Prefactura"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Lbl_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else if ((_Ctrl_Control is TextBox) && (_Ctrl_Control.Name == "_Txt_Prefactura"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Cmb_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else
                        {
                            _Ctrl_Control.Visible = false;
                        }
                    }

                    break;

                case "POR ESTADO":

                    foreach (Control _Ctrl_Control in _Pnl_Filtro.Controls)
                    {
                        if ((_Ctrl_Control is Label) && (_Ctrl_Control.Name == "_Lbl_Estado"))
                        {
                            _Ctrl_Control.Visible = true;
                        }
                        else if ((_Ctrl_Control is ComboBox) && (_Ctrl_Control.Name == "_Cmb_Estado"))
                        {
                            _Ctrl_Control.Visible = true;
                        }
                        else
                        {
                            _Ctrl_Control.Visible = false;
                        }
                    }

                    break;

                case "POR CLIENTE":

                    foreach (Control _Ctrl_Control in _Pnl_Filtro.Controls)
                    {
                        if ((_Ctrl_Control is Label) && (_Ctrl_Control.Name == "_Lbl_Cliente"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Lbl_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else if ((_Ctrl_Control is TextBox) && (_Ctrl_Control.Name == "_Txt_Cliente"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Cmb_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else if ((_Ctrl_Control is Button) && ((_Ctrl_Control.Name == "_Btn_Cliente") || (_Ctrl_Control.Name == "_Btn_LimpiarCliente")))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X,
                                                               (_Cmb_Estado.Location.Y - 2));
                            _Ctrl_Control.Visible = true;
                        }
                        else
                        {
                            _Ctrl_Control.Visible = false;
                        }
                    }

                    break;

                case "POR VENDEDOR":
                
                    foreach (Control _Ctrl_Control in _Pnl_Filtro.Controls)
                    {
                        if ((_Ctrl_Control is Label) && (_Ctrl_Control.Name == "_Lbl_Vendedor"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Lbl_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else if ((_Ctrl_Control is TextBox) && (_Ctrl_Control.Name == "_Txt_Vendedor"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Cmb_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else if ((_Ctrl_Control is Button) &&
                                 ((_Ctrl_Control.Name == "_Btn_Vendedor") ||
                                  (_Ctrl_Control.Name == "_Btn_LimpiarVendedor")))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X,
                                                               (_Cmb_Estado.Location.Y - 2));
                            _Ctrl_Control.Visible = true;
                        }
                        else
                        {
                            _Ctrl_Control.Visible = false;
                        }
                    }

                    break;

                case "POR GERENTE":

                    foreach (Control _Ctrl_Control in _Pnl_Filtro.Controls)
                    {
                        if ((_Ctrl_Control is Label) && (_Ctrl_Control.Name == "_Lbl_Gerente"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Lbl_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else if ((_Ctrl_Control is TextBox) && (_Ctrl_Control.Name == "_Txt_Gerente"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Cmb_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else if ((_Ctrl_Control is Button) &&
                                 ((_Ctrl_Control.Name == "_Btn_Gerente") ||
                                  (_Ctrl_Control.Name == "_Btn_LimpiarGerente")))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X,
                                                               (_Cmb_Estado.Location.Y - 2));
                            _Ctrl_Control.Visible = true;
                        }
                        else
                        {
                            _Ctrl_Control.Visible = false;
                        }
                    }

                    break;

                case "POR CÓDIGO DE PEDIDO":

                    foreach (Control _Ctrl_Control in _Pnl_Filtro.Controls)
                    {
                        if ((_Ctrl_Control is Label) && (_Ctrl_Control.Name == "_Lbl_Pedido"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Lbl_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else if ((_Ctrl_Control is TextBox) && (_Ctrl_Control.Name == "_Txt_Pedido"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Cmb_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else
                        {
                            _Ctrl_Control.Visible = false;
                        }
                    }

                    break;

                case "POR FECHA":
                case "POR FECHA DE CREACIÓN":

                    foreach (Control _Ctrl_Control in _Pnl_Filtro.Controls)
                    {
                        if ((_Ctrl_Control is Label) && ((_Ctrl_Control.Name == "_Lbl_Desde") || (_Ctrl_Control.Name == "_Lbl_Hasta")))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Lbl_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else if ((_Ctrl_Control is DateTimePicker) && ((_Ctrl_Control.Name == "_Dtp_Desde") || (_Ctrl_Control.Name == "_Dtp_Hasta")))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Cmb_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else
                        {
                            _Ctrl_Control.Visible = false;
                        }
                    }

                    break;

                case "POR MES":
                case "POR MES DE CREACIÓN":

                    foreach (Control _Ctrl_Control in _Pnl_Filtro.Controls)
                    {
                        if ((_Ctrl_Control is Label) && ((_Ctrl_Control.Name == "_Lbl_Año") || (_Ctrl_Control.Name == "_Lbl_Mes")))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Lbl_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else if ((_Ctrl_Control is ComboBox) && ((_Ctrl_Control.Name == "_Cmb_Año") || (_Ctrl_Control.Name == "_Cmb_Mes")))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Cmb_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else
                        {
                            _Ctrl_Control.Visible = false;
                        }
                    }

                    break;

                case "POR CÓDIGO":
                case "POR CÓDIGO DE LA NOTA":
                case "POR N° DE CHEQUE":
                case "POR N° DE DEPOSITO":
                case "POR NOTA DE CRÉDITO":
                case "POR NOTA DE DEVOLUCIÓN":

                    foreach (Control _Ctrl_Control in _Pnl_Filtro.Controls)
                    {
                        if ((_Ctrl_Control is Label) && (_Ctrl_Control.Name == "_Lbl_Codigo"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Lbl_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else if ((_Ctrl_Control is TextBox) && (_Ctrl_Control.Name == "_Txt_Codigo"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Cmb_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else
                        {
                            _Ctrl_Control.Visible = false;
                        }
                    }
                    
                    break;

                case "POR PROVEEDOR":

                    foreach (Control _Ctrl_Control in _Pnl_Filtro.Controls)
                    {
                        if ((_Ctrl_Control is Label) && (_Ctrl_Control.Name == "_Lbl_Proveedor"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Lbl_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else if ((_Ctrl_Control is TextBox) && (_Ctrl_Control.Name == "_Txt_Proveedor"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Cmb_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else if ((_Ctrl_Control is Button) && ((_Ctrl_Control.Name == "_Btn_Proveedor") || (_Ctrl_Control.Name == "_Btn_LimpiarProveedor")))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X,
                                                               (_Cmb_Estado.Location.Y - 2));
                            _Ctrl_Control.Visible = true;
                        }
                        else
                        {
                            _Ctrl_Control.Visible = false;
                        }
                    }

                    break;

                case "POR PROVEEDOR, GRUPO O SUBGRUPO":

                    _Lbl_ProveedorPGSM.Visible = true;
                    _Lbl_GrupoPGSM.Visible = true;

                    _Cmb_ProveedorPGSM.Visible = true;
                    _Cmb_GrupoPGSM.Visible = true;

                    _Lbl_SubgrupoPGSM.Visible = true;
                    _Cmb_SubgrupoPGSM.Visible = true;

                    _Lbl_MarcaPGSM.Visible = false;
                    _Cmb_MarcaPGSM.Visible = false;

                    break;

                case "POR PROVEEDOR, GRUPO O MARCA":

                    _Lbl_MarcaPGSM.Location = new Point(_Lbl_MarcaPGSM.Location.X, _Lbl_SubgrupoPGSM.Location.Y);
                    _Cmb_MarcaPGSM.Location = _Cmb_SubgrupoPGSM.Location;

                    _Lbl_ProveedorPGSM.Visible = true;
                    _Lbl_GrupoPGSM.Visible = true;

                    _Cmb_ProveedorPGSM.Visible = true;
                    _Cmb_GrupoPGSM.Visible = true;

                    _Lbl_SubgrupoPGSM.Visible = false;
                    _Cmb_SubgrupoPGSM.Visible = false;

                    _Lbl_MarcaPGSM.Visible = true;
                    _Cmb_MarcaPGSM.Visible = true;

                    break;

                case "TODOS LOS PRODUCTOS":

                    _Lbl_ProveedorPGSM.Visible = false;
                    _Lbl_GrupoPGSM.Visible = false;
                    _Lbl_SubgrupoPGSM.Visible = false;
                    _Lbl_MarcaPGSM.Visible = false;

                    _Cmb_ProveedorPGSM.Visible = false;
                    _Cmb_GrupoPGSM.Visible = false;
                    _Cmb_SubgrupoPGSM.Visible = false;
                    _Cmb_MarcaPGSM.Visible = false;

                    break;

                case "POR BANCO":

                    foreach (Control _Ctrl_Control in _Pnl_Filtro.Controls)
                    {
                        if ((_Ctrl_Control is Label) && (_Ctrl_Control.Name == "_Lbl_Banco"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Lbl_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else if ((_Ctrl_Control is TextBox) && (_Ctrl_Control.Name == "_Txt_Banco"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Cmb_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else if ((_Ctrl_Control is Button) && ((_Ctrl_Control.Name == "_Btn_Banco") || (_Ctrl_Control.Name == "_Btn_LimpiarBanco")))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, (_Cmb_Estado.Location.Y - 2));
                            _Ctrl_Control.Visible = true;
                        }
                        else
                        {
                            _Ctrl_Control.Visible = false;
                        }
                    }

                    break;

                case "POR RANGO":

                    foreach (Control _Ctrl_Control in _Pnl_Filtro.Controls)
                    {
                        if ((_Ctrl_Control is Label) && (_Ctrl_Control.Name == "_Lbl_Rango"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Lbl_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else if ((_Ctrl_Control is TextBox) && (_Ctrl_Control.Name == "_Txt_Rango"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Cmb_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else if ((_Ctrl_Control is Button) && ((_Ctrl_Control.Name == "_Btn_Rango") || (_Ctrl_Control.Name == "_Btn_LimpiarRango")))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, (_Cmb_Estado.Location.Y - 2));
                            _Ctrl_Control.Visible = true;
                        }
                        else
                        {
                            _Ctrl_Control.Visible = false;
                        }
                    }

                    break;

                case "POR PRODUCTO":

                    foreach (Control _Ctrl_Control in _Pnl_Filtro.Controls)
                    {
                        if ((_Ctrl_Control is Label) && (_Ctrl_Control.Name == "_Lbl_Producto"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Lbl_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else if ((_Ctrl_Control is TextBox) && (_Ctrl_Control.Name == "_Txt_Producto"))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, _Cmb_Estado.Location.Y);
                            _Ctrl_Control.Visible = true;
                        }
                        else if ((_Ctrl_Control is Button) && ((_Ctrl_Control.Name == "_Btn_Producto") || (_Ctrl_Control.Name == "_Btn_LimpiarProducto")))
                        {
                            _Ctrl_Control.Location = new Point(_Ctrl_Control.Location.X, (_Cmb_Estado.Location.Y - 2));
                            _Ctrl_Control.Visible = true;
                        }
                        else
                        {
                            _Ctrl_Control.Visible = false;
                        }
                    }

                    break;
            }

            // Para evitar que la etiqueta _Lbl_FiltrarPor y el combo _Cmb_FiltrarPor se oculten, lo forzamos a que se muestren.

            foreach (Control _Ctrl_Control in _Pnl_Filtro.Controls)
            {
                if ((_Ctrl_Control is Label) && (_Ctrl_Control.Name == "_Lbl_Filtro") || (_Ctrl_Control is ComboBox) && (_Ctrl_Control.Name == "_Cmb_FiltrarPor"))
                {
                    _Ctrl_Control.Visible = true;
                }
            }
        }

        /// <summary>
        /// Muestra un filtro fijo específico.
        /// </summary>
        /// <param name="_P_Enu_Tipo">Tipo de consulta.</param>
        public void _Mtd_MostrarPanel()
        {
            switch (_Enu_TipoConsulta)
            {
                case _Enu_TiposConsultas.LimiteCreditoClientes:

                    _Mtd_MostrarFiltro("POR MES");

                    _Lbl_FiltrarPor.Visible = false;
                    _Cmb_FiltrarPor.Visible = false;

                    /*
                     * Este cambio se hace para no agregar otro combo más al control,
                     * se reutiliza el combo estado y su etiqueta.
                     */

                    _Lbl_Estado.Text = "Día:";
                    _Lbl_Estado.TextAlign = ContentAlignment.MiddleRight;
                    _Lbl_Estado.Top += 30;
                    _Lbl_Estado.Left += 23;
                    _Lbl_Estado.Visible = true;

                    _Cmb_Estado.Top += 30;
                    _Cmb_Estado.Visible = true;
                    _Cmb_Estado.Width -= 38;

                    _Pnl_Filtro.Height += 32;

                    Height += 35;

                    break;

                case _Enu_TiposConsultas.CostoUtilidadProducto:

                    _Pnl_PGSM.Top = 0;
                    _Pnl_PGSM.Visible = true;
                    _Pnl_Filtro.Visible = false;
                    _Pnl_FiltroFijo.Visible = false;

                    _Cmb_FiltrarPorPGSM.Width += 60;

                    _Lbl_ProveedorPGSM.Left += 70;
                    _Cmb_ProveedorPGSM.Left += 67;
                    _Cmb_ProveedorPGSM.Width -= 16;

                    _Lbl_GrupoPGSM.Left += 70;
                    _Cmb_GrupoPGSM.Left += 67;
                    _Cmb_GrupoPGSM.Width -= 16;

                    _Lbl_SubgrupoPGSM.Left += 70;
                    _Cmb_SubgrupoPGSM.Left += 67;
                    _Cmb_SubgrupoPGSM.Width -= 16;

                    _Lbl_MarcaPGSM.Left += 69;
                    _Cmb_MarcaPGSM.Left += 67;
                    _Cmb_MarcaPGSM.Width -= 16;

                    Height += 50;

                    break;

                case _Enu_TiposConsultas.RelacionChequesTransitoDepositado:

                    _Pnl_FiltroFijo.Height -= 8;
                    _Pnl_FiltroFijo.Visible = true;

                    Height += 30;

                    break;

                case _Enu_TiposConsultas.ValorizadoInventario:

                    _Pnl_FiltroValInv.Width += 50;
                    _Pnl_FiltroValInv.Visible = true;
                    _Pnl_Filtro.Visible = false;

                    _Pnl_PGSM.Left += 120;
                    _Pnl_PGSM.Visible = true;

                    _Cmb_FiltrarPorPGSM.Width += 60;
                    _Cmb_ImpuestoValInv.Width += 48;
                    _Cmb_TipoExisValInv.Width += 48;

                    _Lbl_ProveedorPGSM.Left += 70;
                    _Cmb_ProveedorPGSM.Left += 67;
                    _Cmb_ProveedorPGSM.Width -= 16;

                    _Lbl_GrupoPGSM.Left += 70;
                    _Cmb_GrupoPGSM.Left += 67;
                    _Cmb_GrupoPGSM.Width -= 16;

                    _Lbl_SubgrupoPGSM.Left += 70;
                    _Cmb_SubgrupoPGSM.Left += 67;
                    _Cmb_SubgrupoPGSM.Width -= 16;

                    _Lbl_MarcaPGSM.Left += 69;
                    _Cmb_MarcaPGSM.Left += 67;
                    _Cmb_MarcaPGSM.Width -= 16;

                    Width += 54;
                    Height += 128;

                    break;
            }
        }

        /// <summary>
        /// Devuelve la fecha del filtro Año - Mes.
        /// </summary>
        /// <param name="_P_Dat_Datos">Dataset con los resultados de la consulta.</param>
        /// <returns>Fecha desde.</returns>
        public string _Mtd_ConvertirFechaDesde(DataSet _P_Dat_Datos)
        {
            DateTime _Dte_Fecha;

            if (_P_Dat_Datos.Tables[0].Rows.Count > 0)
            {
                if (_P_Dat_Datos.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    _Dte_Fecha = Convert.ToDateTime(_P_Dat_Datos.Tables[0].Rows[0][0].ToString());

                    return _Cls_Formato._Mtd_fecha(_Dte_Fecha);
                }
            }

            _Dte_Fecha = new DateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Year, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Month, 1);

            return _Cls_Formato._Mtd_fecha(_Dte_Fecha);
        }

        /// <summary>
        /// Devuelve la fecha del filtro Año - Mes.
        /// </summary>
        /// <param name="_P_Dat_Datos">Dataset con los resultados de la consulta.</param>
        /// <returns>Fecha hasta.</returns>
        public string _Mtd_ConvertirFechaHasta(DataSet _P_Dat_Datos)
        {
            DateTime _Dte_Fecha;

            if (_P_Dat_Datos.Tables[0].Rows.Count > 0)
            {
                if (_P_Dat_Datos.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    _Dte_Fecha = Convert.ToDateTime(_P_Dat_Datos.Tables[0].Rows[0][0].ToString());

                    return _Cls_Formato._Mtd_fecha(_Dte_Fecha);
                }
            }

            _Dte_Fecha = new DateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().Year, CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().AddMonths(1).Month, 1);

            return _Cls_Formato._Mtd_fecha(_Dte_Fecha.AddDays(-1));
        }

        /// <summary>
        /// Verifica los filtros según la consulta que se esté haciendo.
        /// </summary>
        /// <returns>Falso si el filtro no tiene valores o están incorrectos.</returns>
        public bool _Mtd_VerificarFiltros()
        {
            switch (TipoFiltro)
            {
                case "POR CÓDIGO DE FACTURA":

                    if (Factura == "")
                    {
                        MessageBox.Show("Debe especificar la factura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    break;

                case "POR CÓDIGO DE PRE-FACTURA":

                    if (Prefactura == "")
                    {
                        MessageBox.Show("Debe especificar la prefactura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    break;

                case "POR VENDEDOR":

                    if (Vendedor.Text == "")
                    {
                        MessageBox.Show("Debe especificar un vendedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    break;

                case "POR CLIENTE":

                    if (Cliente.Text == "")
                    {
                        MessageBox.Show("Debe especificar un cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    break;

                case "POR CÓDIGO DE PEDIDO":

                    if (Pedido == "")
                    {
                        MessageBox.Show("Debe especificar un pedido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    break;

                case "POR PROVEEDOR":

                    if (Proveedor.Text == "")
                    {
                        MessageBox.Show("Debe especificar un proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    break;

                case "POR CÓDIGO":
                case "POR CÓDIGO DE LA NOTA":
                case "POR NOTA DE CRÉDITO":
                case "POR NOTA DE DEVOLUCIÓN":

                    if (Codigo == "")
                    {
                        MessageBox.Show("Debe especificar un código.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    break;

                case "POR FECHA":
                case "POR FECHA DE CREACIÓN":

                    if ((FechaDesde == "") || (FechaHasta == ""))
                    {
                        MessageBox.Show("Debe especificar un rango de fechas correcto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    
                    if (Convert.ToDateTime(FechaDesde) > Convert.ToDateTime(FechaHasta))
                    {
                        MessageBox.Show("Debe especificar algún valor en los filtros.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    break;
            }

            return true;
        }

        /// <summary>
        /// Constructor de la clase _CtrlMultifiltro.
        /// </summary>
        public _Ctrl_Multifiltro()
        {
            InitializeComponent();

            _Dtp_Desde.Value = DateTime.Now;
            _Dtp_Hasta.Value = DateTime.Now;
        }

        private void _Txt_Pedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == (char)13)
                {
                    Cursor = Cursors.WaitCursor;
                    KeyPress_Pedido();
                    Cursor = Cursors.Default;
                }
            }
        }

        private void _Txt_Prefactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == (char)13)
                {
                    Cursor = Cursors.WaitCursor;
                    KeyPress_Prefactura();
                    Cursor = Cursors.Default;
                }
            }
        }

        private void _Txt_Factura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == (char)13)
                {
                    Cursor = Cursors.WaitCursor;
                    KeyPress_Factura();
                    Cursor = Cursors.Default;
                }
            }
        }

        private void _Txt_Codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
        }

        private void _Cmb_FiltrarPor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SelectionChangeCommitted_FiltrarPor();
        }

        private void _Cmb_Año_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SelectionChangeCommitted_Año();
        }

        private void _Cmb_Mes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (SelectionChangeCommitted_Mes != null)
            {
                SelectionChangeCommitted_Mes();
            }
        }

        private void _Cmb_ProveedorPGSM_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SelectionChangeCommitted_ProveedoresPGS();
        }

        private void _Cmb_GrupoPGSM_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SelectionChangeCommitted_GruposPGS();
        }

        private void _Cmb_FiltrarPor_DropDown(object sender, EventArgs e)
        {
            _Str_FiltroAnterior = _Cmb_FiltrarPor.Text;
        }

        private void _Cmb_FiltrarPorPGSM_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mtd_MostrarFiltro(_Cmb_FiltrarPorPGSM.Text);
        }

        private void _Cmb_FiltrarPor_TxtChanged(object sender, EventArgs e)
        {
            _Mtd_MostrarFiltro(_Cmb_FiltrarPor.Text);
        }

        private void _Btn_Proveedor_Click(object sender, EventArgs e)
        {
            if (Click_Proveedor != null)
            {
                Click_Proveedor();
            }
        }

        private void _Btn_LimpiarProveedor_Click(object sender, EventArgs e)
        {
            _Txt_Proveedor.Text = "";
        }

        private void _Btn_Banco_Click(object sender, EventArgs e)
        {
            if (Click_Banco != null)
            {
                Click_Banco();
            }
        }

        private void _Btn_LimpiarBanco_Click(object sender, EventArgs e)
        {
            _Txt_Banco.Text = "";
        }

        private void _Btn_Rango_Click(object sender, EventArgs e)
        {
            if (Click_Rango != null)
            {
                Click_Rango();
            }
        }

        private void _Btn_LimpiarRango_Click(object sender, EventArgs e)
        {
            _Txt_Rango.Text = "";
        }

        private void _Btn_Cliente_Click(object sender, EventArgs e)
        {
            if (Click_Cliente != null)
            {
                Click_Cliente();
            }
        }

        private void _Btn_Vendedor_Click(object sender, EventArgs e)
        {
            if (Click_Vendedor != null)
            {
                Click_Vendedor();
            }
        }

        private void _Btn_Gerente_Click(object sender, EventArgs e)
        {
            if (Click_Gerente != null)
            {
                Click_Gerente();
            }
        }

        private void _Btn_LimpiarCliente_Click(object sender, EventArgs e)
        {
            _Txt_Cliente.Text = "";
        }

        private void _Btn_LimpiarVendedor_Click(object sender, EventArgs e)
        {
            _Txt_Vendedor.Text = "";
        }

        private void _Btn_LimpiarGerente_Click(object sender, EventArgs e)
        {
            _Txt_Gerente.Text = "";
        }

        private void _Btn_Producto_Click(object sender, EventArgs e)
        {
            if (Click_Producto != null)
            {
                Click_Producto();
            }
        }

        private void _Btn_LimpiarProducto_Click(object sender, EventArgs e)
        {
            _Txt_Producto.Text = "";
        }
    }
}
