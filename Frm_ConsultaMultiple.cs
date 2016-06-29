using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Reporting.WinForms;

namespace T3
{
    /// <summary>
    /// Tipos de consultas del multifiltro.
    /// </summary>
    public enum _Enu_TiposConsultas
    {
        Pedido = 0,
        Prefactura,
        Factura,
        RecepcionComprasResumidoSemanal,
        NotasRecepcionDetallado,
        CostoUtilidadProducto,
        EfectividadCobranza,
        ClientesEstatus,
        RelacionChequesTransitoDepositado,
        LimiteCreditoClientes,
        ValorizadoInventario,
        LotesPorDevolucion,
        FacturasProductos,
        DetalleLotesFacturas,
        AnalisisCompraInventario
    }

    public partial class Frm_ConsultaMultiple : Form
    {
        private CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        private _Enu_TiposConsultas _Enu_TipoConsulta;
        private bool _Bol_Notificador = false;

        //--------------------------------------------------------------------------------------------------
        //  Métodos para inicializar los filtros.
        //--------------------------------------------------------------------------------------------------

        /// <summary>
        /// Método para verificar si el filtro de fecha o mes está seleccionado cuando 
        /// se ha seleccionado el filtro por estado.
        /// </summary>
        /// <returns>}Verdadero si alguno de los dos filtros está seleccionado.</returns>
        public bool _Mtd_VerificarFiltroSeleccionado()
        {
            bool _Bol_TieneFiltroEstado = false;
            bool _Bol_TieneFiltroFechaMes = false;

            /*
             * Verificamos si se seleccionó el filtro por estado.
             */

            foreach (Control _Ctr_Control in _Pnl_Contenedor.Controls)
            {
                if ((_Ctr_Control is Controles._Ctrl_Multifiltro) && (_Ctr_Control.Visible))
                {
                    Controles._Ctrl_Multifiltro _Ctr_Filtro = (Controles._Ctrl_Multifiltro)_Ctr_Control;

                    if ((_Ctr_Filtro.TipoFiltro == "POR ESTADO") && ((_Ctr_Filtro.Estado == "FACTURADAS") || (_Ctr_Filtro.Estado == "FACTURADOS") || (_Ctr_Filtro.Estado == "ANULADOS") || (_Ctr_Filtro.Estado == "BLOQUEADOS POR CRÉDITO - HISTORICO")))
                    {
                        _Bol_TieneFiltroEstado = true;

                        break;
                    }
                }
            }

            /*
             * Comprobamos que por lo menos tenga seleccionado el filtro por fecha o por mes 
             * en caso de que esté seleccionado el filtro por estado.
             */

            if (_Bol_TieneFiltroEstado)
            {
                foreach (Control _Ctr_Control in _Pnl_Contenedor.Controls)
                {
                    if ((_Ctr_Control is Controles._Ctrl_Multifiltro) && (_Ctr_Control.Visible))
                    {
                        Controles._Ctrl_Multifiltro _Ctr_Filtro = (Controles._Ctrl_Multifiltro) _Ctr_Control;

                        if ((_Ctr_Filtro.TipoFiltro == "POR FECHA") || (_Ctr_Filtro.TipoFiltro == "POR MES"))
                        {
                            if (!_Bol_TieneFiltroFechaMes)
                            {
                                _Bol_TieneFiltroFechaMes = true;
                            }
                        }
                    }
                }
            }

            /*
             * Si se cumple que el filtro seleccionado es por estado y ha seleccionado por 
             * fecha y por mes devolvemos verdadero.
             */

            if ((_Bol_TieneFiltroEstado) && (!_Bol_TieneFiltroFechaMes))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Método para llenar el grid de pedidos.
        /// </summary>
        public void _Mtd_LlenarGridPedidos()
        {
            string _Str_SQL, _Str_WHERE = "";

            // En caso de que no haya seleccionado un filtro de fecha o mes la rutina aborta.

            if (!_Mtd_VerificarFiltroSeleccionado())
            {
                MessageBox.Show("Debe indicar un rango de fechas o filtrar por mes.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _Str_SQL = "select convert(varchar, c_fecha_pedido, 103) as c_fecha_pedido, cpedido, ccliente, c_nomb_comer, cnamevendedor, cnamefpago, cempaques,";
            _Str_SQL += " c_montotot_si, cstatus, c_rif, cvendedor, cfpago, c_bloqbackorder, c_rechabackorder, cunidades, cbackorder,";
            _Str_SQL += " convert(varchar, cefectividad) + '%' as cefectividad, cefectividad as cefectividad2, c_montotot_si as montoparaordenar from VST_CONSULTAPEDIDOSPORESTATUS";
                        
            if (_Bol_Notificador)
            {
                if (_Ctr_Multifiltro_1.TipoFiltro == "POR ESTADO")
                {
                    if (_Ctr_Multifiltro_1.Estado == "BLOQUEADOS POR CRÉDITO - ACTUAL")
                    {
                        _Str_WHERE = " where cstatus='3' and c_activo='1' and isnull(caprobadocredito, 0)=0";
                    }
                    else if (_Ctr_Multifiltro_1.Estado == "RECHAZADOS POR EXISTENCIA")
                    {
                        _Str_WHERE = " where c_rechabackorder='1' and cstatus='9' and c_pendientebackorder='0'";
                    }
                }

                // Reiniciamos la bandera de notificadores.

                _Bol_Notificador = false;
            }
            else
            {
                // Solo filtra por empresa cuando sea llamado por el menú y no por el notificador, cambio solicitado por Andrés.

                _Str_WHERE = " where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "'";

                foreach (Control _Ctr_Control in _Pnl_Contenedor.Controls)
                {
                    if ((_Ctr_Control is Controles._Ctrl_Multifiltro) && (_Ctr_Control.Visible))
                    {
                        Controles._Ctrl_Multifiltro _Ctr_Filtro = (Controles._Ctrl_Multifiltro)_Ctr_Control;

                        switch (_Ctr_Filtro.TipoFiltro)
                        {
                            case "POR MES":

                                _Str_WHERE += " and convert(datetime, convert(varchar, c_fecha_pedido, 103))" + _Mtd_ObtenerRango(_Ctr_Filtro);

                                break;

                            case "POR FECHA":

                                _Str_WHERE += " and convert(datetime, convert(varchar, c_fecha_pedido, 103)) between '" + _Ctr_Filtro.FechaDesde + "' and '" + _Ctr_Filtro.FechaHasta + "'";

                                break;

                            case "POR ESTADO":

                                if (_Ctr_Filtro.Estado == "PENDIENTE (POR FACTURAR Y BLOQUEADO POR CRÉDITO)")
                                {
                                    _Str_WHERE += " and (cstatus='3' or cstatus='4') and c_pendientebackorder='0'"; ;
                                }
                                else if (_Ctr_Filtro.Estado == "BLOQUEADOS POR CRÉDITO - ACTUAL")
                                {
                                    _Str_WHERE += " and cstatus='3' and c_activo='1'";
                                }
                                else if (_Ctr_Filtro.Estado == "BLOQUEADOS POR CRÉDITO - HISTORICO")
                                {
                                    _Str_WHERE += " and not cfechaaprob is null";
                                }
                                else if (_Ctr_Filtro.Estado == "RECHAZADOS POR EXISTENCIA")
                                {
                                    _Str_WHERE += " and c_rechabackorder='1' and cstatus='9' and c_pendientebackorder='0'";
                                }
                                else if (_Ctr_Filtro.Estado == "POR FACTURAR")
                                {
                                    _Str_WHERE += " and cstatus='4'"; ;
                                }
                                else if (_Ctr_Filtro.Estado == "ANULADOS")
                                {
                                    _Str_SQL = _Str_SQL.Replace("montoparaordenar from", "montoparaordenar, left(cobservaciones, 40) as cobservaciones from");

                                    _Str_WHERE += " and cstatus='7'";
                                }
                                else if (_Ctr_Filtro.Estado == "FACTURADOS")
                                {
                                    _Str_WHERE += " and (cstatus='5' or cstatus='11' or cstatus='10')";
                                }

                                break;

                            case "POR CLIENTE":

                                if (_Ctr_Filtro.Cliente.Text.Trim().Length > 0)
                                {
                                    _Str_WHERE += " and ccliente='" + _Ctr_Filtro.Cliente.Tag + "'";
                                }

                                break;

                            case "POR VENDEDOR":

                                if (_Ctr_Filtro.Vendedor.Text.Trim().Length > 0)
                                {
                                    _Str_WHERE += " and cvendedor='" + _Ctr_Filtro.Vendedor.Tag + "'";
                                }

                                break;

                            case "POR CÓDIGO DE PEDIDO":

                                if (_Ctr_Filtro.Pedido.Trim().Length > 0)
                                {
                                    _Str_WHERE += " and cpedido like '" + _Ctr_Filtro.Pedido.Trim() + "%'";
                                }

                                break;
                        }
                    }
                }
            }

            _Str_SQL += (_Str_WHERE + " order by cpedido, c_fecha_pedido desc;");

            Cursor = Cursors.WaitCursor;

            _Dtg_GridPedido.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL).Tables[0];
            _Dtg_GridPedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dtg_GridPedido.Columns[22].HeaderText = "Observaciones";

            var _oColumna = _Dtg_GridPedido.Columns["_Dtg_GridPedido_CMontototSi"];
            if (_oColumna != null)
            {
                _oColumna.DefaultCellStyle.Format = "#,##0.00";
                _oColumna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            Cursor = Cursors.Default;

            _Dtg_GridPedido.ClearSelection();
        }

        /// <summary>
        /// Método para llenar el grid de pre-facturas. 
        /// </summary>
        public void _Mtd_LlenarGridPreFactura()
        {
            string _Str_SQL, _Str_WHERE;

            bool bPorProducto = false;
            
            /*
             * En caso de que no haya seleccionado un filtro de fecha o mes
             * la rutina aborta.
             */

            if (!_Mtd_VerificarFiltroSeleccionado())
            {
                MessageBox.Show("Debe indicar un rango de fechas o filtrar por mes.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _Str_SQL = "SELECT CONVERT(VARCHAR, dbo.VST_PREFACTURAS.c_fecha_pedido, 103) AS c_fecha_pedido, dbo.VST_PREFACTURAS.cpedido,";
            _Str_SQL += " dbo.VST_PREFACTURAS.cpfactura, dbo.VST_PREFACTURAS.c_nomb_comer, dbo.VST_PREFACTURAS.cname, dbo.VST_PREFACTURAS.cempaques,";
            _Str_SQL += " dbo.VST_PREFACTURAS.c_montotot_si, CONVERT(VARCHAR, dbo.VST_PREFACTURAS.cefectividad) + '%' AS cefectividad,";
            _Str_SQL += " dbo.VST_PREFACTURAS.cefectividad AS cefectividad2, dbo.VST_PREFACTURAS.ccliente, dbo.VST_PREFACTURAS.cfacturado, dbo.VST_PREFACTURAS.clistofacturar,";
            _Str_SQL += " dbo.VST_PREFACTURAS.cprecarga, dbo.VST_PREFACTURAS.cbackorder, dbo.VST_PREFACTURAS.cvendedor, dbo.VST_PREFACTURAS.cunidades,";
            _Str_SQL += " dbo.VST_PREFACTURAS.c_factdevuelta, DATEDIFF(dd, dbo.VST_PREFACTURAS.c_fecha_pedido, GETDATE()) AS Dias,";
            _Str_SQL += " CASE WHEN (VST_PREFACTURAS.cdelete = '0' AND ((VST_PREFACTURAS.cfacturado = '1' AND VST_PREFACTURAS.c_factdevuelta = '0') OR";
            _Str_SQL += " (VST_PREFACTURAS.cfacturado = '1' AND VST_PREFACTURAS.c_factdevuelta = '1'))) THEN 'FACTURADA' WHEN (VST_PREFACTURAS.cdelete = '0' AND";
            _Str_SQL += " (VST_PREFACTURAS.cfacturado = '1' AND (VST_PREFACTURAS.clistofacturar = '1' AND VST_PREFACTURAS.cprecarga > '0' AND";
            _Str_SQL += " VST_PREFACTURAS.cfacturado = '0'))) THEN 'EN PRECARGA' WHEN (VST_PREFACTURAS.cdelete = '0' AND VST_PREFACTURAS.c_facturaanul = 0 AND";
            _Str_SQL += " ((VST_PREFACTURAS.clistofacturar = '1' AND VST_PREFACTURAS.cprecarga = '0' AND VST_PREFACTURAS.cfacturado = '0') OR";
            _Str_SQL += " (c_factdevuelta = '1' AND VST_PREFACTURAS.cprecarga = '0'))) THEN 'POR FACTURAR' WHEN (VST_PREFACTURAS.cdelete = '0' AND";
            _Str_SQL += " VST_PREFACTURAS.c_facturaanul = 0 AND ((VST_PREFACTURAS.clistofacturar = '1' AND VST_PREFACTURAS.cprecarga = '0' AND";
            _Str_SQL += " VST_PREFACTURAS.cfacturado = '0') OR";
            _Str_SQL += " (VST_PREFACTURAS.clistofacturar = '1' AND VST_PREFACTURAS.cprecarga > '0' AND VST_PREFACTURAS.cfacturado = '0') OR";
            _Str_SQL += " (VST_PREFACTURAS.c_factdevuelta = '1' AND VST_PREFACTURAS.cprecarga = '0'))) THEN 'PENDIENTE' END AS Estado,";
            _Str_SQL += " dbo.VST_PREFACTURAS.EstadoDesp AS cruta, dbo.VST_PREFACTURAS_RUTAS.cdescripcion, dbo.VST_PREFACTURAS_RUTAS.ccantdesp, CONVERT(VARCHAR,";
            _Str_SQL += " dbo.VST_PREFACTURAS_RUTAS.cfechasalida, 103) AS cfechasalida";
            _Str_SQL += " ,VST_PREFACTURAS.ctipoalimento_descrip ";
            _Str_SQL += " FROM dbo.VST_PREFACTURAS INNER JOIN";
            _Str_SQL += " dbo.TRUTDESPACHOD ON dbo.VST_PREFACTURAS.cgroupcomp = dbo.TRUTDESPACHOD.cgroupcomp AND";
            _Str_SQL += " dbo.VST_PREFACTURAS.c_estadodesp = dbo.TRUTDESPACHOD.cestate AND dbo.VST_PREFACTURAS.c_ciudaddesp = dbo.TRUTDESPACHOD.ccity INNER JOIN";
            _Str_SQL += " dbo.VST_PREFACTURAS_RUTAS ON dbo.TRUTDESPACHOD.cidrutdespacho = dbo.VST_PREFACTURAS_RUTAS.cidrutdespacho AND";
            _Str_SQL += " dbo.TRUTDESPACHOD.cgroupcomp = dbo.VST_PREFACTURAS_RUTAS.cgroupcomp";

            _Str_WHERE = " WHERE VST_PREFACTURAS.ccompany='" + Frm_Padre._Str_Comp + "'";

            foreach (Control _Ctr_Control in _Pnl_Contenedor.Controls)
            {
                if ((_Ctr_Control is Controles._Ctrl_Multifiltro) && (_Ctr_Control.Visible))
                {
                    Controles._Ctrl_Multifiltro _Ctr_Filtro = (Controles._Ctrl_Multifiltro) _Ctr_Control;

                    switch (_Ctr_Filtro.TipoFiltro)
                    {
                        case "POR MES":

                            _Str_WHERE += " AND CONVERT(DATETIME,CONVERT(VARCHAR,c_fecha_pedido,103))" + _Mtd_ObtenerRango(_Ctr_Filtro);

                            break;

                        case "POR FECHA":

                            _Str_WHERE += " AND CONVERT(DATETIME,CONVERT(VARCHAR,c_fecha_pedido,103)) BETWEEN '" + _Ctr_Filtro.FechaDesde + "' AND '" + _Ctr_Filtro.FechaHasta + "'";

                            break;

                        case "POR ESTADO":

                            if (_Ctr_Filtro.Estado == "PENDIENTE (POR FACTURAR Y EN PRE-CARGA)")
                            {
                                _Str_WHERE += " AND VST_PREFACTURAS.cdelete='0' AND c_facturaanul=0 AND ((clistofacturar='1' AND VST_PREFACTURAS.cprecarga='0' AND cfacturado='0') OR (clistofacturar='1' AND VST_PREFACTURAS.cprecarga>'0' AND cfacturado='0') OR (c_factdevuelta='1' AND VST_PREFACTURAS.cprecarga='0'))";
                            }
                            else if (_Ctr_Filtro.Estado == "POR FACTURAR")
                            {
                                _Str_WHERE += " AND VST_PREFACTURAS.cdelete='0' AND c_facturaanul=0 AND ((clistofacturar='1' AND VST_PREFACTURAS.cprecarga='0' AND cfacturado='0') OR (c_factdevuelta='1' AND VST_PREFACTURAS.cprecarga='0'))";
                            }
                            else if (_Ctr_Filtro.Estado == "EN PRE-CARGA")
                            {
                                _Str_WHERE += " AND VST_PREFACTURAS.cdelete='0' AND (clistofacturar='1' AND VST_PREFACTURAS.cprecarga>'0' AND cfacturado='0')";
                            }
                            else if (_Ctr_Filtro.Estado == "FACTURADAS")
                            {
                                _Str_WHERE += " AND VST_PREFACTURAS.cdelete='0' AND ((cfacturado='1' AND c_factdevuelta='0') OR (cfacturado='1' AND c_factdevuelta='1'))";
                            }

                            break;

                        case "POR CLIENTE":

                            if (_Ctr_Filtro.Cliente.Text.Trim().Length > 0)
                            {
                                _Str_WHERE += " AND VST_PREFACTURAS.ccliente='" + Convert.ToString(_Ctr_Filtro.Cliente.Tag) + "'";
                            }

                            break;

                        case "POR VENDEDOR":

                            if (_Ctr_Filtro.Vendedor.Text.Trim().Length > 0)
                            {
                                _Str_WHERE += " AND cvendedor='" + Convert.ToString(_Ctr_Filtro.Vendedor.Tag) + "'";
                            }

                            break;

                        case "POR CÓDIGO DE PEDIDO":

                            if (_Ctr_Filtro.Pedido.Trim().Length > 0)
                            {
                                _Str_WHERE += " AND cpedido like '" + _Ctr_Filtro.Pedido.Trim() + "%'";
                            }

                            break;

                        case "POR CÓDIGO DE PRE-FACTURA":

                            if (_Ctr_Filtro.Prefactura.Trim().Length > 0)
                            {
                                _Str_WHERE += " AND VST_PREFACTURAS.cpfactura like '" + _Ctr_Filtro.Prefactura.Trim() + "%'";
                            }

                            break;

                        case "POR GERENTE":

                            if (_Ctr_Filtro.Gerente.Text.Trim().Length > 0)
                            {
                                _Str_WHERE += " AND cgerarea like '" + _Ctr_Filtro.Gerente.Tag + "%'";
                            }

                            break;

                        case "POR PRODUCTO":

                            if (_Ctr_Filtro.Producto.Text.Trim().Length > 0)
                            {
                                _Str_WHERE += " AND cproducto = '" + _Ctr_Filtro.Producto.Tag + "'";

                                bPorProducto = true;
                            }

                            break;
                    }
                }
            }

            _Str_SQL += _Str_WHERE;

            _Str_SQL += " ORDER BY VST_PREFACTURAS.cpfactura, c_fecha_pedido DESC";

            if (bPorProducto)
            {
                _Str_SQL = _Str_SQL.Replace("VST_PREFACTURAS_RUTAS", "OTRO");
                _Str_SQL = _Str_SQL.Replace("VST_PREFACTURAS", "VST_PRODUCTOPREFACTURA");
                _Str_SQL = _Str_SQL.Replace("OTRO", "VST_PREFACTURAS_RUTAS");
            }

            Cursor = Cursors.WaitCursor;

            _Dtg_GridPrefactura.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL).Tables[0];
            _Dtg_GridPrefactura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dtg_GridPrefactura.ClearSelection();

            var _oColumna = _Dtg_GridPrefactura.Columns["_Dtg_GridPrefactura_CMontototSi"];
            if (_oColumna != null)
            {
                _oColumna.DefaultCellStyle.Format = "#,##0.00";
                _oColumna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Método para llenar el grid de facturas. 
        /// </summary>
        public void _Mtd_LlenarGridFactura()
        {
            string _Str_SQL;
            string _Str_WHERE;

            /*
             * En caso de que no haya seleccionado un filtro de fecha o mes
             * la rutina aborta.
             */

            if (!_Mtd_VerificarFiltroSeleccionado())
            {
                MessageBox.Show("Debe indicar un rango de fechas o filtrar por mes.", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _Str_SQL = "SELECT cfactura,CONVERT(VARCHAR,c_fecha_factura,103)";
            _Str_SQL += " AS c_fecha_factura,RTRIM(cliente_descrip)";
            _Str_SQL += " AS cliente_descrip,cmontotot_factura,cstsdespacho,null";
            _Str_SQL += " AS obs1,cstscobrado,null";
            _Str_SQL += " AS obs2,cstsgeneral, TVENDEDOR.cvendedor, ISNULL(TVENDEDOR.cname,'CREADO POR OFICINA')";
            _Str_SQL += " AS cvendedorname,ccliente,DATEPART(day,c_fecha_factura-c_fecha_pedido)";
            _Str_SQL += " AS diassinfact,";
            _Str_SQL += " cpedido";
            _Str_SQL += " FROM VST_FACTURA_MAIN LEFT JOIN TVENDEDOR ON VST_FACTURA_MAIN.cvendedor=TVENDEDOR.cvendedor";

            _Str_WHERE = " WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
            _Str_WHERE += " AND VST_FACTURA_MAIN.ccompany='" + Frm_Padre._Str_Comp + "'";

            foreach (Control _Ctr_Control in _Pnl_Contenedor.Controls)
            {
                if ((_Ctr_Control is Controles._Ctrl_Multifiltro) && (_Ctr_Control.Visible))
                {
                    Controles._Ctrl_Multifiltro _Ctr_Filtro = (Controles._Ctrl_Multifiltro)_Ctr_Control;

                    switch (_Ctr_Filtro.TipoFiltro)
                    {
                        case "POR MES":

                            _Str_WHERE += " AND CONVERT(DATETIME,CONVERT(VARCHAR,c_fecha_factura,103))";
                            _Str_WHERE += _Mtd_ObtenerRango(_Ctr_Filtro);

                            break;

                        case "POR FECHA":

                            _Str_WHERE += " AND CONVERT(DATETIME,CONVERT(VARCHAR,c_fecha_factura,103))";
                            _Str_WHERE += " BETWEEN '" + _Ctr_Filtro.FechaDesde + "' AND '" + _Ctr_Filtro.FechaHasta + "'";

                            break;

                        case "POR CLIENTE":

                            if (_Ctr_Filtro.Cliente.Text.Trim().Length > 0)
                            {
                                _Str_WHERE += " AND ccliente='" + Convert.ToString(_Ctr_Filtro.Cliente.Tag).Trim() + "'";
                            }

                            break;

                        case "POR VENDEDOR":

                            if (_Ctr_Filtro.Vendedor.Text.Trim().Length > 0)
                            {
                                _Str_WHERE += " AND VST_FACTURA_MAIN.cvendedor='" + Convert.ToString(_Ctr_Filtro.Vendedor.Tag).Trim() + "'";
                            }

                            break;

                        case "POR CÓDIGO DE PEDIDO":

                            if (_Ctr_Filtro.Pedido.Trim().Length > 0)
                            {
                                _Str_WHERE += " AND cpedido like '" + _Ctr_Filtro.Pedido.Trim() + "%'";
                            }

                            break;

                        case "POR CÓDIGO DE FACTURA":

                            if (_Ctr_Filtro.Factura.Trim().Length > 0)
                            {
                                _Str_WHERE += " AND cfactura like '" + _Ctr_Filtro.Factura.Trim() + "%'";
                            }

                            break;
                    }
                }
            }

            _Str_SQL += _Str_WHERE;

            _Str_SQL += " ORDER BY cfactura";

            Cursor = Cursors.WaitCursor;

            _Dtg_GridFactura.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL).Tables[0];
            _Dtg_GridFactura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dtg_GridFactura.ClearSelection();

            var _oColumna = _Dtg_GridFactura.Columns["_Dtg_GridFactura_Monto"];
            if (_oColumna != null)
            {
                _oColumna.DefaultCellStyle.Format = "#,##0.00";
                _oColumna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }



            Cursor = Cursors.Default;

        }

        /// <summary>
        /// Método para llenar el grid de los límites de crédito de cliente.
        /// </summary>
        public void _Mtd_LlenarGridLimiteCreditoCliente()
        {
            string _Str_SQL;

            if (_Mtd_VerificarReporteProcesado())
            {
                _Dtg_GridLimiteCreditoCliente.Columns[0].Visible = false;
                _Chk_SeleccionarTodo.Visible = false;
                _Btn_Procesar.Enabled = false;
            }
            else
            {
                _Dtg_GridLimiteCreditoCliente.Columns[0].Visible = true;
                _Chk_SeleccionarTodo.Visible = true;
                _Btn_Procesar.Enabled = true;
            }

            if (_Chk_SeleccionarTodo.Checked)
            {
                _Str_SQL = "SELECT 1 AS aprobado,";
            }
            else
            {
                _Str_SQL = "SELECT 0 AS aprobado,";
            }

            _Str_SQL += " dbo.TCLIENTE.ccliente, dbo.TCLIENTE.c_nomb_comer, dbo.TGENLIMCREDD.cmontopromedio, dbo.TGENLIMCREDD.ccantchequesdev,";
            _Str_SQL += " dbo.TGENLIMCREDD.ccodlimite, LIMITE_ACTUAL.cdescripcion AS Actual, LIMITE_SUGERIDO.cdescripcion AS Sugerido";
            _Str_SQL += " FROM dbo.TGENLIMCREDD";
            _Str_SQL += " INNER JOIN dbo.TGENLIMCREDM ON dbo.TGENLIMCREDD.generacionId = dbo.TGENLIMCREDM.generacionId";
            _Str_SQL += " INNER JOIN dbo.TCLIENTE ON dbo.TGENLIMCREDD.ccliente = dbo.TCLIENTE.ccliente";
            _Str_SQL += " INNER JOIN dbo.TLIMITCREDITO AS LIMITE_SUGERIDO ON dbo.TGENLIMCREDD.ccodlimite = LIMITE_SUGERIDO.ccodlimite";
            _Str_SQL += " INNER JOIN dbo.TLIMITCREDITO AS LIMITE_ACTUAL ON dbo.TCLIENTE.c_limt_credit = LIMITE_ACTUAL.ccodlimite";
            _Str_SQL += " WHERE CONVERT(VARCHAR, fecha, 103) = CONVERT(VARCHAR, '" + _Ctr_Multifiltro_1.Estado + "', 103)";
            _Str_SQL += " AND (generado = 1 OR generado = 2)";
            _Str_SQL += " ORDER BY dbo.TCLIENTE.c_nomb_comer;";

            Cursor = Cursors.WaitCursor;

            _Dtg_GridLimiteCreditoCliente.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL).Tables[0];
            _Dtg_GridLimiteCreditoCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Cursor = Cursors.Default;

            if (_Dtg_GridLimiteCreditoCliente.Rows.Count > 0)
            {
                _Btn_Procesar.Enabled = true;
            }
            else
            {
                _Btn_Procesar.Enabled = false;
            }

            _Dtg_GridLimiteCreditoCliente.ClearSelection();
        }

        /// <summary>
        /// Método para verificar si el reporte está procesado.
        /// </summary>
        /// <returns>Verdadero si el reporte está procesado.</returns>
        public bool _Mtd_VerificarReporteProcesado()
        {
            string _Str_SQL;

            _Str_SQL = "SELECT fecha FROM TGENLIMCREDM";
            _Str_SQL += " WHERE CONVERT(VARCHAR, fecha, 103) = CONVERT(VARCHAR, '" + _Ctr_Multifiltro_1.Estado + "', 103)";
            _Str_SQL += " AND generado = 2;";

            DataSet _Ds_Resultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (_Ds_Resultado.Tables[0].Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        //--------------------------------------------------------------------------------------------------
        //  Métodos de los reportes.
        //--------------------------------------------------------------------------------------------------

        /// <summary>
        /// Muestra el reporte de facturas emitidas.
        /// </summary>
        private void _Mtd_MostrarFacturasProductos()
        {
            string _Str_FechaDesde = "";
            string _Str_FechaHasta = "";
            ReportParameter[] _Obj_Parametros = new ReportParameter[3];

            _Rpt_VisorReportes.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_VisorReportes.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_DetalleFacturasProductos";

            //_Obj_Parametros[0] = new ReportParameter("CNOMBCOMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            _Obj_Parametros[0] = new ReportParameter("ccompany", Frm_Padre._Str_Comp.Trim());

            switch (_Ctr_Multifiltro_1.TipoFiltro)
            {
                case "POR FECHA":

                    _Str_FechaDesde = _Ctr_Multifiltro_1.FechaDesde;
                    _Str_FechaHasta = _Ctr_Multifiltro_1.FechaHasta;

                    break;

                case "POR MES":

                    _Str_FechaDesde = _Mtd_ObtenerFechaDesde(_Ctr_Multifiltro_1);
                    _Str_FechaHasta = _Mtd_ObtenerFechaHasta(_Ctr_Multifiltro_1);

                    break;
            }

            _Obj_Parametros[1] = new ReportParameter("cfechadesde", _Str_FechaDesde);
            _Obj_Parametros[2] = new ReportParameter("cfechahasta", _Str_FechaHasta);

            _Rpt_VisorReportes.ServerReport.SetParameters(_Obj_Parametros);
            _Rpt_VisorReportes.ServerReport.Refresh();
            _Rpt_VisorReportes.RefreshReport();
        }

        /// <summary>
        /// Consulta el reporte de valorizado de inventario.
        /// </summary>
        private void _Mtd_MostrarValorizacionInventario()
        {
            DateTime _Dat_Fecha;

            ReportParameter[] _Obj_Parametros;

            String _Str_Ruta;

            if (!_Chk_FiltrarGS.Checked)
            {
                _Str_Ruta = _Chk_SinDiscriminar.Checked ? "Rpt_ValorizadoInventarioSDisc" : "Rpt_ValorizadoInventario";
            }
            else
            {
                _Str_Ruta = "Rpt_ValorizadoInventarioGS";
            }
            
            _Rpt_VisorReportes.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_VisorReportes.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + _Str_Ruta;

            _Obj_Parametros = new ReportParameter[14];

            _Obj_Parametros[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            _Obj_Parametros[1] = new ReportParameter("CNOMBEMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));

            if (_Ctr_Multifiltro_1.ProveedorPGSM != "0")
            {
                _Obj_Parametros[2] = new ReportParameter("CPROVEEDOR", _Ctr_Multifiltro_1.ProveedorPGSM);
            }
            else
            {
                _Obj_Parametros[2] = new ReportParameter("CPROVEEDOR", "NULL");
            }

            if (_Ctr_Multifiltro_1.GrupoPGSM != "0")
            {
                _Obj_Parametros[3] = new ReportParameter("CGRUPO", _Ctr_Multifiltro_1.GrupoPGSM);
            }
            else
            {
                _Obj_Parametros[3] = new ReportParameter("CGRUPO", "NULL");
            }

            if (_Ctr_Multifiltro_1.SubgrupoPGSM != "0")
            {
                _Obj_Parametros[4] = new ReportParameter("CSUBGRUPO", _Ctr_Multifiltro_1.SubgrupoPGSM);
            }
            else
            {
                _Obj_Parametros[4] = new ReportParameter("CSUBGRUPO", "NULL");
            }

            if (_Ctr_Multifiltro_1.MarcaPGSM != "0")
            {
                _Obj_Parametros[5] = new ReportParameter("CMARCA", _Ctr_Multifiltro_1.MarcaPGSM);
            }
            else
            {
                _Obj_Parametros[5] = new ReportParameter("CMARCA", "NULL");
            }

            if (_Ctr_Multifiltro_1.ValorizadoInventarioReporteFecha == "ACTUAL")
            {
                _Obj_Parametros[6] = new ReportParameter("CACTUAL", "1");
                _Obj_Parametros[7] = new ReportParameter("CMES", "0");
                _Obj_Parametros[8] = new ReportParameter("CANO", "0");
            }
            else
            {
                _Dat_Fecha = Convert.ToDateTime(_Ctr_Multifiltro_1.ValorizadoInventarioReporteFecha);

                _Obj_Parametros[6] = new ReportParameter("CACTUAL", "0");
                _Obj_Parametros[7] = new ReportParameter("CMES", _Dat_Fecha.ToString("MM"));
                _Obj_Parametros[8] = new ReportParameter("CANO", _Dat_Fecha.ToString("yyyy"));
            }

            if (_Ctr_Multifiltro_1.ValorizadoInventarioTipoExistencia == "MAL ESTADO (SÓLO MAL ESTADO)")
            {
                _Obj_Parametros[10] = new ReportParameter("CMALESTADO", "1");
            }
            else
            {
                _Obj_Parametros[10] = new ReportParameter("CMALESTADO", "0");
            }

            if (_Ctr_Multifiltro_1.ValorizadoInventarioImpuesto == "SI, CON IMPUESTO")
            {
                _Obj_Parametros[11] = new ReportParameter("CIMPUESTO", true.ToString());
            }
            else
            {
                _Obj_Parametros[11] = new ReportParameter("CIMPUESTO", false.ToString());
            }

            if (_Ctr_Multifiltro_1.ValorizadoInventarioTipoExistencia == "COMPLETA (DISPONIBLE + COMPROMETIDA)")
            {
                _Obj_Parametros[13] = new ReportParameter("CCOMPROMETIDO", true.ToString());
            }
            else
            {
                _Obj_Parametros[13] = new ReportParameter("CCOMPROMETIDO", false.ToString());
            }

            if (_Ctr_Multifiltro_1.ValorizadoInventarioNivelDetalle == "TODOS LOS PRODUCTOS")
            {
                _Obj_Parametros[9] = new ReportParameter("CTODOSLOSPRODUCTOS", "1");
                _Obj_Parametros[12] = new ReportParameter("CRESUMIDO", false.ToString());
            }
            else
            {
                _Obj_Parametros[9] = new ReportParameter("CTODOSLOSPRODUCTOS", "0");
                _Obj_Parametros[12] = new ReportParameter("CRESUMIDO", _Chk_SinDiscriminar.Checked ? false.ToString() : true.ToString());
            }

            _Rpt_VisorReportes.ServerReport.SetParameters(_Obj_Parametros);
            _Rpt_VisorReportes.ServerReport.Refresh();
            _Rpt_VisorReportes.RefreshReport();
        }

        /// <summary>
        /// Consulta el reporte de Cliente por estatus.
        /// </summary>
        private void _Mtd_MostrarClientesEstatus()
        {
            ReportParameter[] _Obj_Parametros = new ReportParameter[4];

            _Rpt_VisorReportes.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_VisorReportes.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_ClientesEstatus";

            _Obj_Parametros[0] = new ReportParameter("CNOMBREMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));

            foreach (Control _Ctr_Control in _Pnl_Contenedor.Controls)
            {
                if ((_Ctr_Control is T3.Controles._Ctrl_Multifiltro) && (_Ctr_Control.Visible == true))
                {
                    Controles._Ctrl_Multifiltro _Ctr_Filtro = (Controles._Ctrl_Multifiltro)_Ctr_Control;

                    switch (_Ctr_Filtro.TipoFiltro)
                    {
                        case "POR FECHA DE CREACIÓN":

                            _Obj_Parametros[1] = new ReportParameter("CDESDE", _Ctr_Filtro.FechaDesde);
                            _Obj_Parametros[2] = new ReportParameter("CHASTA", _Ctr_Filtro.FechaHasta);

                            break;

                        case "POR MES DE CREACIÓN":

                            _Obj_Parametros[1] = new ReportParameter("CDESDE", _Mtd_ObtenerFechaDesde(_Ctr_Filtro));
                            _Obj_Parametros[2] = new ReportParameter("CHASTA", _Mtd_ObtenerFechaHasta(_Ctr_Filtro));

                            break;

                        case "POR ESTADO":

                            if (_Ctr_Filtro.Estado == "ACTIVOS")
                            {
                                _Obj_Parametros[3] = new ReportParameter("CESTATUS", "1");
                            }
                            else
                            {
                                _Obj_Parametros[3] = new ReportParameter("CESTATUS", "0");
                            }

                            break;
                    }
                }
            }

            if (_Obj_Parametros[3] == null)
            {
                _Obj_Parametros[3] = new ReportParameter("CESTATUS", "2");
            }

            if ((_Obj_Parametros[1] == null) && (_Obj_Parametros[2] == null))
            {
                _Obj_Parametros[1] = new ReportParameter("CDESDE", "0");
                _Obj_Parametros[2] = new ReportParameter("CHASTA", "0");
            }

            _Rpt_VisorReportes.ServerReport.SetParameters(_Obj_Parametros);
            _Rpt_VisorReportes.ServerReport.Refresh();
            _Rpt_VisorReportes.RefreshReport();
        }

        /// <summary>
        /// Consulta el reporte de Efectividad y Cobranza.
        /// </summary>
        private void _Mtd_MostrarEfectividadCobranza()
        {
            ReportParameter[] _Obj_Parametros = new ReportParameter[5];

            _Rpt_VisorReportes.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_VisorReportes.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_Inf_EfectividadCobranza";

            _Obj_Parametros[0] = new ReportParameter("CGRUPO", Frm_Padre._Str_GroupComp);
            _Obj_Parametros[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            _Obj_Parametros[2] = new ReportParameter("CNOMBREMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));

            if (_Ctr_Multifiltro_1.TipoFiltro == "POR FECHA")
            {
                _Obj_Parametros[3] = new ReportParameter("CDESDE", _Ctr_Multifiltro_1.FechaDesde);
                _Obj_Parametros[4] = new ReportParameter("CHASTA", _Ctr_Multifiltro_1.FechaHasta);
            }
            else if (_Ctr_Multifiltro_1.TipoFiltro == "POR MES")
            {
                _Obj_Parametros[3] = new ReportParameter("CDESDE", _Mtd_ObtenerFechaDesde(_Ctr_Multifiltro_1));
                _Obj_Parametros[4] = new ReportParameter("CHASTA", _Mtd_ObtenerFechaHasta(_Ctr_Multifiltro_1));
            }

            if ((_Obj_Parametros[3] == null) && (_Obj_Parametros[4] == null))
            {
                MessageBox.Show("Debes indicar un rango de fechas o un mes para ver la consulta.", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _Rpt_VisorReportes.ServerReport.SetParameters(_Obj_Parametros);
                _Rpt_VisorReportes.ServerReport.Refresh();
                _Rpt_VisorReportes.RefreshReport();
            }
        }

        /// <summary>
        /// Muestra el reporte de Costo y Utilidad por producto.
        /// </summary>
        private void _Mtd_MostrarCostoUtilidadProducto()
        {
            ReportParameter[] _Obj_Parametros = new ReportParameter[6];

            _Rpt_VisorReportes.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_VisorReportes.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_CostoUtilidadProducto";

            _Obj_Parametros[0] = new ReportParameter("CNOMBREMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            _Obj_Parametros[1] = new ReportParameter("CCOMPANYPROV", Frm_Padre._Str_Comp.Trim());
            _Obj_Parametros[2] = new ReportParameter("CPROVEEDOR", (_Ctr_Multifiltro_1.ProveedorPGSM == "0" || _Ctr_Multifiltro_1.ProveedorPGSM == "TODOS") ? "NULL" : _Ctr_Multifiltro_1.ProveedorPGSM);
            _Obj_Parametros[3] = new ReportParameter("CGRUPO", (_Ctr_Multifiltro_1.GrupoPGSM == "0" || _Ctr_Multifiltro_1.GrupoPGSM == "TODOS") ? "NULL" : _Ctr_Multifiltro_1.GrupoPGSM);
            _Obj_Parametros[4] = new ReportParameter("CSUBGRUPO", (_Ctr_Multifiltro_1.SubgrupoPGSM == "0" || _Ctr_Multifiltro_1.SubgrupoPGSM == "TODOS") ? "NULL" : _Ctr_Multifiltro_1.SubgrupoPGSM);
            _Obj_Parametros[5] = new ReportParameter("CMARCA", (_Ctr_Multifiltro_1.MarcaPGSM == "0" || _Ctr_Multifiltro_1.MarcaPGSM == "TODOS") ? "NULL" : _Ctr_Multifiltro_1.MarcaPGSM);

            _Rpt_VisorReportes.ServerReport.SetParameters(_Obj_Parametros);
            _Rpt_VisorReportes.ServerReport.Refresh();
            _Rpt_VisorReportes.RefreshReport();
        }

        /// <summary>
        /// Método para mostrar el reporte de las notas de recepción detallado.
        /// </summary>
        private void _Mtd_MostrarNotasRecepcionDetallado()
        {
            string _Str_Codigo = "";
            string _Str_Proveedor = "";

            ReportParameter[] _Obj_Parametros = new ReportParameter[7];

            _Rpt_VisorReportes.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_VisorReportes.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_NotaRecepcionDetallado";

            foreach (Control _Ctr_Control in _Pnl_Contenedor.Controls)
            {
                if ((_Ctr_Control is Controles._Ctrl_Multifiltro) && (_Ctr_Control.Visible))
                {
                    Controles._Ctrl_Multifiltro _Ctr_Filtro = (Controles._Ctrl_Multifiltro)_Ctr_Control;

                    switch (_Ctr_Filtro.TipoFiltro)
                    {
                        case "POR PROVEEDOR":

                            _Str_Proveedor = _Ctr_Filtro.Proveedor.Text.Substring(0, 2);

                            break;

                        case "POR CÓDIGO DE LA NOTA":

                            _Str_Codigo = _Ctr_Filtro.Codigo;

                            break;

                        case "POR FECHA":

                            _Obj_Parametros[5] = new ReportParameter("CFECHADESDE", _Ctr_Filtro.FechaDesde);
                            _Obj_Parametros[6] = new ReportParameter("CFECHAHASTA", _Ctr_Filtro.FechaHasta);

                            break;

                        case "POR MES":

                            _Obj_Parametros[5] = new ReportParameter("CFECHADESDE", _Mtd_ObtenerFechaDesde(_Ctr_Filtro));
                            _Obj_Parametros[6] = new ReportParameter("CFECHAHASTA", _Mtd_ObtenerFechaHasta(_Ctr_Filtro));

                            break;
                    }
                }
            }

            _Obj_Parametros[0] = new ReportParameter("CGRUPO", Frm_Padre._Str_GroupComp.Trim());
            _Obj_Parametros[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp.Trim());
            _Obj_Parametros[2] = new ReportParameter("CNOMBREMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            _Obj_Parametros[3] = new ReportParameter("CNOTA", _Str_Codigo != "" ? _Str_Codigo : "0");
            _Obj_Parametros[4] = new ReportParameter("CPROVEEDOR", _Str_Proveedor != "" ? _Str_Proveedor : "0");

            if ((_Obj_Parametros[5] == null) && (_Obj_Parametros[6] == null))
            {
                MessageBox.Show("Debes indicar un rango de fechas o un mes para ver la consulta.", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _Rpt_VisorReportes.ServerReport.SetParameters(_Obj_Parametros);
                _Rpt_VisorReportes.ServerReport.Refresh();
                _Rpt_VisorReportes.RefreshReport();
            }
        }

        /// <summary>
        /// Método para mostrar el reporte de Detalle de Lotes y Facturas.
        /// </summary>
        private void _Mtd_MostrarDetalleLotesFacturas()
        {
            string _Str_Codigo = "";
            string _Str_Proveedor = "";

            ReportParameter[] _Obj_Parametros = new ReportParameter[5];

            _Rpt_VisorReportes.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_VisorReportes.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_DetalleLotesFacturas";

            foreach (Control _Ctr_Control in _Pnl_Contenedor.Controls)
            {
                if ((_Ctr_Control is Controles._Ctrl_Multifiltro) && (_Ctr_Control.Visible))
                {
                    Controles._Ctrl_Multifiltro _Ctr_Filtro = (Controles._Ctrl_Multifiltro)_Ctr_Control;

                    switch (_Ctr_Filtro.TipoFiltro)
                    {
                        case "POR FECHA":

                            _Obj_Parametros[3] = new ReportParameter("CFECHADESDE", _Ctr_Filtro.FechaDesde);
                            _Obj_Parametros[4] = new ReportParameter("CFECHAHASTA", _Ctr_Filtro.FechaHasta);

                            break;
                    }
                }
            }

            _Obj_Parametros[0] = new ReportParameter("CGRUPO", Frm_Padre._Str_GroupComp.Trim());
            _Obj_Parametros[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp.Trim());
            _Obj_Parametros[2] = new ReportParameter("CNOMBREMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));

            if ((_Obj_Parametros[3] == null) && (_Obj_Parametros[4] == null))
            {
                MessageBox.Show("Debes indicar un rango de fechas o un mes para ver la consulta.", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _Rpt_VisorReportes.ServerReport.SetParameters(_Obj_Parametros);
                _Rpt_VisorReportes.ServerReport.Refresh();
                _Rpt_VisorReportes.RefreshReport();
            }
        }


        /// <summary>
        /// Método para mostrar el reporte de recepción de compras semanal.
        /// </summary>
        private void _Mtd_MostrarRecepcionComprasSemanal()
        {
            ReportParameter[] _Obj_Parametros = new ReportParameter[4];

            _Rpt_VisorReportes.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_VisorReportes.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_RecepcionesSemMes";

            _Obj_Parametros[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            _Obj_Parametros[1] = new ReportParameter("CNAMECOMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            _Obj_Parametros[2] = new ReportParameter("FECHADESDE", _Ctr_Multifiltro_1.FechaDesde);
            _Obj_Parametros[3] = new ReportParameter("FECHAHASTA", _Ctr_Multifiltro_1.FechaHasta);

            _Rpt_VisorReportes.ServerReport.SetParameters(_Obj_Parametros);
            _Rpt_VisorReportes.ServerReport.Refresh();
            _Rpt_VisorReportes.RefreshReport();
        }

        /// <summary>
        /// Muestra el reporte de relación de cheques depositados y en tránsito.
        /// </summary>
        private void _Mtd_MostrarRelacionCheques()
        {
            string _Str_Estado;
            string _Str_FechaDesde = "";
            string _Str_FechaHasta = "";
            string _Str_Banco = "";
            string _Str_Cliente = "";
            string _Str_Cheque = "";
            string _Str_Deposito = "";

            ReportParameter[] _Obj_Parametros;

            _Rpt_VisorReportes.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);

            foreach (Control _Ctr_Control in _Pnl_Contenedor.Controls)
            {
                if ((_Ctr_Control is Controles._Ctrl_Multifiltro) && (_Ctr_Control.Visible == true))
                {
                    Controles._Ctrl_Multifiltro _Ctr_Filtro = (Controles._Ctrl_Multifiltro)_Ctr_Control;

                    switch (_Ctr_Filtro.TipoFiltro)
                    {
                        case "POR FECHA":

                            _Str_FechaDesde = _Ctr_Filtro.FechaDesde;
                            _Str_FechaHasta = _Ctr_Filtro.FechaHasta;

                            break;

                        case "POR MES":

                            _Str_FechaDesde = _Mtd_ObtenerFechaDesde(_Ctr_Filtro);
                            _Str_FechaHasta = _Mtd_ObtenerFechaHasta(_Ctr_Filtro);

                            break;

                        case "POR BANCO":

                            _Str_Banco = _Ctr_Filtro.Banco.Tag.ToString();

                            break;

                        case "POR CLIENTE":

                            _Str_Cliente = _Ctr_Filtro.Cliente.Tag.ToString();

                            break;

                        case "POR N° DE CHEQUE":

                            if (_Ctr_Filtro.Codigo != "")
                            {
                                _Str_Cheque = _Ctr_Filtro.Codigo;
                            }
                            else
                            {
                                MessageBox.Show("Debe indicar el número de cheque.", "Advertencia", MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);

                                Cursor = Cursors.Default;
                                return;
                            }

                            break;

                        case "POR N° DE DEPOSITO":

                            if (_Ctr_Filtro.Codigo != "")
                            {
                                _Str_Deposito = _Ctr_Filtro.Codigo;
                            }
                            else
                            {
                                MessageBox.Show("Debe indicar el número de depósito.", "Advertencia", MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);

                                Cursor = Cursors.Default;
                                return;
                            }

                            break;
                    }
                }
            }

            _Str_Estado = _Ctr_Multifiltro_1.EstadoFijo;


            _Rpt_VisorReportes.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_RelacionChequesTransDepo";
            _Obj_Parametros = new ReportParameter[11];

            if (_Str_Estado == "TODOS")
            {
            }
            else if (_Str_Estado == "EN TRÁNSITO")
            {
            }
            else
            {
            }

            _Obj_Parametros[0] = new ReportParameter("CGROUPCOMP", Frm_Padre._Str_GroupComp.Trim());
            _Obj_Parametros[1] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp.Trim());
            _Obj_Parametros[2] = new ReportParameter("CNOMBEMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));
            _Obj_Parametros[3] = new ReportParameter("CFECHADESDE", _Str_FechaDesde);
            _Obj_Parametros[4] = new ReportParameter("CFECHAHASTA", _Str_FechaHasta);
            _Obj_Parametros[5] = new ReportParameter("CBANCO", _Str_Banco);
            _Obj_Parametros[6] = new ReportParameter("CNUMDEP", _Str_Deposito);
            _Obj_Parametros[7] = new ReportParameter("CNUMCHEQUE", _Str_Cheque);
            _Obj_Parametros[8] = new ReportParameter("CCLIENTE", _Str_Cliente);

            if (_Str_Estado == "TODOS")
            {
                _Obj_Parametros[9] = new ReportParameter("CTIPOCHEQUE", "");
                _Obj_Parametros[10] = new ReportParameter("CNOMBREREPORTE", "RELACIÓN DE CHEQUES DEPOSITADOS Y EN TRÁNSITO");
            }
            else if (_Str_Estado == "EN TRÁNSITO")
            {
                _Obj_Parametros[9] = new ReportParameter("CTIPOCHEQUE", "T");
                _Obj_Parametros[10] = new ReportParameter("CNOMBREREPORTE", "RELACIÓN DE CHEQUES EN TRÁNSITO");
            }
            else
            {
                _Obj_Parametros[9] = new ReportParameter("CTIPOCHEQUE", "D");
                _Obj_Parametros[10] = new ReportParameter("CNOMBREREPORTE", "RELACIÓN DE CHEQUES DEPOSITADOS");
            }

            if ((_Str_FechaDesde != "") && (_Str_FechaHasta != ""))
            {
                _Rpt_VisorReportes.ServerReport.SetParameters(_Obj_Parametros);
                _Rpt_VisorReportes.ServerReport.Refresh();
                _Rpt_VisorReportes.RefreshReport();
            }
            else
            {
                MessageBox.Show("Debe indicar un rango de fechas.", "Advertencia", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método para mostrar el reporte de lotes por devolución.
        /// </summary>
        private void _Mtd_MostrarLotesPorDevolucion()
        {
            string _Str_NumeroNotaDevolucion = "0";
            string _Str_NumeroNotaCredito = "0";

            ReportParameter[] _Obj_Parametros = new ReportParameter[4];

            _Rpt_VisorReportes.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_VisorReportes.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_LoteDev";

            _Obj_Parametros[0] = new ReportParameter("CCOMPANY", Frm_Padre._Str_Comp);
            _Obj_Parametros[1] = new ReportParameter("CNOMBCOMP", CLASES._Cls_Varios_Metodos._Mtd_NombComp(Frm_Padre._Str_Comp));

            foreach (Control _Ctr_Control in _Pnl_Contenedor.Controls)
            {
                if ((_Ctr_Control is Controles._Ctrl_Multifiltro) && (_Ctr_Control.Visible == true))
                {
                    Controles._Ctrl_Multifiltro _Ctr_Filtro = (Controles._Ctrl_Multifiltro)_Ctr_Control;

                    switch (_Ctr_Filtro.TipoFiltro)
                    {
                        case "POR NOTA DE CRÉDITO":

                            _Str_NumeroNotaCredito = _Ctr_Filtro.Codigo;

                            break;

                        case "POR NOTA DE DEVOLUCIÖN":

                            _Str_NumeroNotaDevolucion = _Ctr_Filtro.Codigo;

                            break;
                    }
                }
            }

            _Obj_Parametros[2] = new ReportParameter("CNOTACRED", _Str_NumeroNotaCredito);
            _Obj_Parametros[3] = new ReportParameter("CNOTADEV", _Str_NumeroNotaDevolucion);

            _Rpt_VisorReportes.ServerReport.SetParameters(_Obj_Parametros);
            _Rpt_VisorReportes.ServerReport.Refresh();
            _Rpt_VisorReportes.RefreshReport();
        }

        //--------------------------------------------------------------------------------------------------
        //  Métodos generales.
        //--------------------------------------------------------------------------------------------------

        /// <summary>
        /// Verifica los filtros.
        /// </summary>
        /// <returns>Verdadero si los filtros no tienen problemas.</returns>
        private bool _Mtd_VerificarFiltros()
        {
            bool _Bol_SW = true;

            if ((_Ctr_Multifiltro_1.Visible) && (!_Ctr_Multifiltro_1._Mtd_VerificarFiltros()))
            {
                Cursor = Cursors.Default;
                _Bol_SW = false;
            }

            if ((_Ctr_Multifiltro_2.Visible) && (!_Ctr_Multifiltro_2._Mtd_VerificarFiltros()))
            {
                Cursor = Cursors.Default;
                _Bol_SW = false;
            }

            if ((_Ctr_Multifiltro_3.Visible) && (!_Ctr_Multifiltro_3._Mtd_VerificarFiltros()))
            {
                Cursor = Cursors.Default;
                _Bol_SW = false;
            }

            Cursor = Cursors.Default;
            return _Bol_SW;
        }

        /// <summary>
        /// Método para inicializar los multifiltros del formulario.
        /// </summary>
        /// <param name="_P_Enu_Tipo">Tipo de consulta que se está solicitando.</param>
        private void _Mtd_InicializarMultifiltros()
        {
            _Ctr_Multifiltro_1._Mtd_CargarFiltros(_Enu_TipoConsulta);
            _Ctr_Multifiltro_2._Mtd_CargarFiltros(_Enu_TipoConsulta);
            _Ctr_Multifiltro_3._Mtd_CargarFiltros(_Enu_TipoConsulta);

            _Mtd_CargarAñosFiscales(_Ctr_Multifiltro_1);
            _Mtd_CargarAñosFiscales(_Ctr_Multifiltro_2);
            _Mtd_CargarAñosFiscales(_Ctr_Multifiltro_3);

            _Mtd_CargarMesesFiscales(_Ctr_Multifiltro_1);
            _Mtd_CargarMesesFiscales(_Ctr_Multifiltro_2);
            _Mtd_CargarMesesFiscales(_Ctr_Multifiltro_3);
        }

        /// <summary>
        /// Métod para cargar los proveedores de la compañia.
        /// </summary>
        private void _Mtd_CargarProveedores()
        {
            string _Str_SQL;

            DataSet _Ds_Datos;

            _Str_SQL = "SELECT DISTINCT TPROVEEDOR.cproveedor, TPROVEEDOR.c_nomb_abreviado";
            _Str_SQL += " FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor";
            _Str_SQL += " WHERE ISNULL(TPROVEEDOR.cdelete,0) = '0'";
            _Str_SQL += " AND ISNULL(TGRUPPROVEE.cdelete,0) = '0'";
            _Str_SQL += " AND TPROVEEDOR.c_activo = '1'";
            _Str_SQL += " AND ((cglobal = '1' AND TGRUPPROVEE.ccompany = '" + Frm_Padre._Str_Comp + "'))";
            _Str_SQL += " ORDER BY TPROVEEDOR.c_nomb_abreviado";

            _Ds_Datos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            _Ctr_Multifiltro_1._Mtd_CargarProveedores(_Ds_Datos);
            _Ctr_Multifiltro_2._Mtd_CargarProveedores(_Ds_Datos);
        }

        /// <summary>
        /// Carga los grupos según el proveedor.
        /// </summary>
        /// <param name="_P_Str_Proveedor">Código del proveedor.</param>
        private void _Mtd_CargarGrupos(string _P_Str_Proveedor)
        {
            string _Str_SQL;

            DataSet _Ds_Datos;

            _Str_SQL = "SELECT TGRUPPROM.ccodgrupop, TGRUPPROM.cname";
            _Str_SQL += " FROM TGRUPPROM INNER JOIN TGRUPPROD ON TGRUPPROM.ccodgrupop = TGRUPPROD.ccodgrupop";
            _Str_SQL += " AND TGRUPPROM.cdelete = TGRUPPROD.cdelete";
            _Str_SQL += " WHERE (TGRUPPROM.cdelete = 0)";

            if (_P_Str_Proveedor != "Todos...")
            {
                _Str_SQL += " AND (TGRUPPROD.cproveedor = '" + _P_Str_Proveedor + "')";
            }

            _Str_SQL += " ORDER BY cname;";

            _Ds_Datos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            _Ctr_Multifiltro_1._Mtd_CargarGrupos(_Ds_Datos);
            _Ctr_Multifiltro_2._Mtd_CargarProveedores(_Ds_Datos);
        }

        /// <summary>
        /// Carga los subgrupos según el proveedor y el grupo seleccionado.
        /// </summary>
        /// <param name="_P_Str_Proveedor">Código del proveedor.</param>
        /// <param name="_P_Str_Grupo">Código del grupo.</param>
        private void _Mtd_CargarSubGrupos(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            string _Str_SQL;

            DataSet _Ds_Datos;

            _Str_SQL = "SELECT TSUBGRUPOM.ccodsubgrup, TSUBGRUPOM.cname ";
            _Str_SQL += " FROM TSUBGRUPOM INNER JOIN TSUBGRUPOD ON TSUBGRUPOM.ccodsubgrup = TSUBGRUPOD.ccodsubgrup";
            _Str_SQL += " AND TSUBGRUPOM.cdelete = TSUBGRUPOD.cdelete ";
            _Str_SQL += " WHERE (TSUBGRUPOM.cdelete = 0)";

            if ((_P_Str_Proveedor != "Todos...") && (_P_Str_Grupo != "Todos..."))
            {
                _Str_SQL += " AND (TSUBGRUPOD.cproveedor = '" + _P_Str_Proveedor + "')";
                _Str_SQL += " AND (TSUBGRUPOD.ccodgrupop = '" + _P_Str_Grupo + "')";
            }

            _Str_SQL += " ORDER BY cname;";

            _Ds_Datos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            _Ctr_Multifiltro_1._Mtd_CargarSubgrupos(_Ds_Datos);
            _Ctr_Multifiltro_2._Mtd_CargarProveedores(_Ds_Datos);
        }

        /// <summary>
        /// Carga las marcas según el proveedor y el grupo.
        /// </summary>
        /// <param name="_P_Str_Proveedor">Código del proveedor.</param>
        /// <param name="_P_Str_Grupo">Código del grupo.</param>
        private void _Mtd_CargarMarcas(string _P_Str_Proveedor, string _P_Str_Grupo)
        {
            string _Str_SQL;

            DataSet _Ds_Datos;

            _Str_SQL = "SELECT TMARCASM.cmarca, TMARCASM.cname";
            _Str_SQL += " FROM TMARCASM";
            _Str_SQL += " INNER JOIN TMARCAS ON TMARCASM.cmarca = TMARCAS.cmarca";
            _Str_SQL += " WHERE (TMARCASM.cdelete = 0)";

            if ((_P_Str_Proveedor != "Todos...") && (_P_Str_Grupo != "Todos..."))
            {
                _Str_SQL += " AND (TMARCAS.cproveedor = '" + _P_Str_Proveedor + "')";
                _Str_SQL += " AND (TMARCAS.ccodgrupop = '" + _P_Str_Grupo + "')";
            }

            _Str_SQL += " ORDER BY TMARCASM.cname;";

            _Ds_Datos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            _Ctr_Multifiltro_1._Mtd_CargarMarcas(_Ds_Datos);
            _Ctr_Multifiltro_2._Mtd_CargarMarcas(_Ds_Datos);
        }

        /// <summary>
        /// Este método permite llenar el combo años del multifiltro.
        /// </summary>
        /// <param name="_P_Ctr_Multifiltro">Multifiltro actual.</param>
        private void _Mtd_CargarAñosFiscales(Controles._Ctrl_Multifiltro _P_Ctr_Multifiltro)
        {
            string _Str_SQL;

            _Str_SQL = "SELECT DISTINCT cyearacco,cyearacco FROM TCALENDCONT WHERE cyearacco<=YEAR(GETDATE()) ORDER BY cyearacco DESC";

            DataSet _Ds_Año = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (_Ds_Año.Tables[0].Rows.Count == 0)
            {
                _Str_SQL = "SELECT YEAR(GETDATE()),YEAR(GETDATE())";

                _Ds_Año = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            }

            _P_Ctr_Multifiltro._Mtd_CargarAños(_Ds_Año);
        }

        /// <summary>
        /// Este método permite llenar el combo meses del multifiltro.
        /// </summary>
        /// <param name="_P_Ctr_Multifiltro">Multifiltro actual.</param>
        private void _Mtd_CargarMesesFiscales(Controles._Ctrl_Multifiltro _P_Ctr_Multifiltro)
        {
            string _Str_SQL;

            _Str_SQL = "SELECT DISTINCT cmontacco,CASE";
            _Str_SQL += " WHEN cmontacco=1 THEN 'ENERO'";
            _Str_SQL += " WHEN cmontacco=2 THEN 'FEBRERO'";
            _Str_SQL += " WHEN cmontacco=3 THEN 'MARZO'";
            _Str_SQL += " WHEN cmontacco=4 THEN 'ABRIL'";
            _Str_SQL += " WHEN cmontacco=5 THEN 'MAYO'";
            _Str_SQL += " WHEN cmontacco=6 THEN 'JUNIO'";
            _Str_SQL += " WHEN cmontacco=7 THEN 'JULIO'";
            _Str_SQL += " WHEN cmontacco=8 THEN 'AGOSTO'";
            _Str_SQL += " WHEN cmontacco=9 THEN 'SEPTIEMBRE'";
            _Str_SQL += " WHEN cmontacco=10 THEN 'OCTUBRE'";
            _Str_SQL += " WHEN cmontacco=11 THEN 'NOVIEMBRE'";
            _Str_SQL += " WHEN cmontacco=12 THEN 'DICIEMBRE'";
            _Str_SQL += " END FROM TCALENDCONT";
            _Str_SQL += " WHERE cyearacco='" + _P_Ctr_Multifiltro.Año + "'";
            _Str_SQL += " AND ((cyearacco=YEAR(GETDATE()) AND cmontacco<=MONTH(GETDATE())) OR (cyearacco<>YEAR(GETDATE()))) ORDER BY cmontacco DESC";

            DataSet _Ds_Mes = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (_Ds_Mes.Tables[0].Rows.Count == 0)
            {
                _Str_SQL = "SELECT MONTH(GETDATE()), CASE";
                _Str_SQL += " WHEN MONTH(GETDATE())=1 THEN 'ENERO'";
                _Str_SQL += " WHEN MONTH(GETDATE())=2 THEN 'FEBRERO'";
                _Str_SQL += " WHEN MONTH(GETDATE())=3 THEN 'MARZO'";
                _Str_SQL += " WHEN MONTH(GETDATE())=4 THEN 'ABRIL'";
                _Str_SQL += " WHEN MONTH(GETDATE())=5 THEN 'MAYO'";
                _Str_SQL += " WHEN MONTH(GETDATE())=6 THEN 'JUNIO'";
                _Str_SQL += " WHEN MONTH(GETDATE())=7 THEN 'JULIO'";
                _Str_SQL += " WHEN MONTH(GETDATE())=8 THEN 'AGOSTO'";
                _Str_SQL += " WHEN MONTH(GETDATE())=9 THEN 'SEPTIEMBRE'";
                _Str_SQL += " WHEN MONTH(GETDATE())=10 THEN 'OCTUBRE'";
                _Str_SQL += " WHEN MONTH(GETDATE())=11 THEN 'NOVIEMBRE'";
                _Str_SQL += " WHEN MONTH(GETDATE())=12 THEN 'DICIEMBRE' END";

                _Ds_Mes = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            }

            _P_Ctr_Multifiltro._Mtd_CargarMeses(_Ds_Mes);
        }

        /// <summary>
        /// Este método permite llenar el combo filtrar por para el reporte de valorizado de inventario.
        /// </summary>
        /// <param name="_P_Ctr_Multifiltro">Multifiltro actual.</param>
        private void _Mtd_CargarMesAnoContable(Controles._Ctrl_Multifiltro _P_Ctr_Multifiltro)
        {
            string _Str_SQL;

            _Str_SQL = "SELECT 'ACTUAL' AS cfecha, 'ACTUAL' AS cvalor FROM THISTINVENT WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' UNION";
            _Str_SQL += " SELECT DISTINCT CONVERT(VARCHAR, CONVERT(DATETIME, '01' + '/' + CONVERT(VARCHAR,cmescont) + '/' + CONVERT(VARCHAR,canocont)), 103) AS cfecha,";
            _Str_SQL += " 'AL CIERRE ' + CONVERT(VARCHAR,canocont) + ' - ' + RIGHT('00' + CONVERT(VARCHAR,cmescont), 2) AS cvalor";
            _Str_SQL += " FROM THISTINVENT ";
            _Str_SQL += " WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'";
            _Str_SQL += " ORDER BY cfecha DESC;";

            DataSet _Ds_Meses = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            if (_Ds_Meses.Tables.Count > 0)
            {
                _P_Ctr_Multifiltro._Mtd_CargarPeriodo(_Ds_Meses);
            }
        }

        /// <summary>
        /// Este método llena el combo de reportes generados para el informe de evaluacioón automática
        /// de los límites de cobro.
        /// </summary>
        /// <param name="_P_Ctr_Multifiltro">Multifiltro actual.</param>
        private void _Mtd_CargarReportesGenerados(Controles._Ctrl_Multifiltro _P_Ctr_Multifiltro)
        {
            string _Str_SQL;
            string _Str_Desde = _Mtd_ObtenerFechaDesde(_Ctr_Multifiltro_1);
            string _Str_Hasta = _Mtd_ObtenerFechaHasta(_Ctr_Multifiltro_1);

            _Str_SQL = "SELECT fecha, 'GENERADO AL ' + CONVERT(VARCHAR, fecha, 103)";
            _Str_SQL += " FROM TGENLIMCREDM";
            _Str_SQL += " WHERE fecha BETWEEN CONVERT(DATETIME, '" + _Str_Desde + "', 103)";
            _Str_SQL += " AND CONVERT(DATETIME, '" + _Str_Hasta + "', 103)";
            _Str_SQL += " AND (generado = 1 OR generado = 2)";
            _Str_SQL += " ORDER BY fecha DESC;";

            DataSet _Ds_Reportes = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            _P_Ctr_Multifiltro._Mtd_CargarReportesGenerados(_Ds_Reportes);
        }

        /// <summary>
        /// Retorna un SQL con las fechas después de seleccionar el año y el mes.
        /// </summary>
        /// <param name="_P_Ctr_Multifiltro">Multifiltro actual.</param>
        private string _Mtd_ObtenerRango(Controles._Ctrl_Multifiltro _P_Ctr_Multifiltro)
        {
            string _Str_SQL;

            DataSet _Ds_Desde, _Ds_Hasta;

            _Str_SQL = "SELECT TOP 1 CONVERT(VARCHAR,cdiafecha_reg,103)";
            _Str_SQL += " FROM TCALENDCONT";
            _Str_SQL += " WHERE cyearacco='" + _P_Ctr_Multifiltro.Año + "'";
            _Str_SQL += " AND cmontacco='" + _P_Ctr_Multifiltro.Mes + "'";
            _Str_SQL += " AND cdelete='0' ORDER BY CONVERT(DATETIME,cdiafecha_reg) ASC";

            _Ds_Desde = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            _Str_SQL = "SELECT TOP 1 CONVERT(VARCHAR,cdiafecha_reg,103)";
            _Str_SQL += " FROM TCALENDCONT";
            _Str_SQL += " WHERE cyearacco='" + _P_Ctr_Multifiltro.Año + "'";
            _Str_SQL += " AND cmontacco='" + _P_Ctr_Multifiltro.Mes + "'";
            _Str_SQL += " AND cdelete='0' ORDER BY CONVERT(DATETIME,cdiafecha_reg) DESC";

            _Ds_Hasta = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            return " BETWEEN '" + _P_Ctr_Multifiltro._Mtd_ConvertirFechaDesde(_Ds_Desde) + "' AND '" + _P_Ctr_Multifiltro._Mtd_ConvertirFechaHasta(_Ds_Hasta) + "'";
        }

        /// <summary>
        /// Retorna la fecha desde según el año y el mes seleccionado en el filtro.
        /// </summary>
        /// <param name="_P_Ctr_Multifiltro">Filtro con el mes y el año.</param>
        /// <returns>Fecha desde.</returns>
        private string _Mtd_ObtenerFechaDesde(T3.Controles._Ctrl_Multifiltro _P_Ctr_Multifiltro)
        {
            string _Str_SQL;

            DataSet _Ds_Desde;

            _Str_SQL = "SELECT TOP 1 CONVERT(VARCHAR,cdiafecha_reg,103)";
            _Str_SQL += " FROM TCALENDCONT";
            _Str_SQL += " WHERE cyearacco='" + _P_Ctr_Multifiltro.Año;
            _Str_SQL += "' AND cmontacco='" + _P_Ctr_Multifiltro.Mes;
            _Str_SQL += "' AND cdelete='0' ORDER BY CONVERT(DATETIME,cdiafecha_reg) ASC";

            _Ds_Desde = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            return _P_Ctr_Multifiltro._Mtd_ConvertirFechaDesde(_Ds_Desde);
        }

        /// <summary>
        /// Retorna la fecha hasta según el año y el mes seleccionado en el filtro.
        /// </summary>
        /// <param name="_P_Ctr_Multifiltro">Filtro con el mes y el año.</param>
        /// <returns>Fecha hasta.</returns>
        private string _Mtd_ObtenerFechaHasta(T3.Controles._Ctrl_Multifiltro _P_Ctr_Multifiltro)
        {
            string _Str_SQL;

            DataSet _Ds_Hasta;

            _Str_SQL = "SELECT TOP 1 CONVERT(VARCHAR,cdiafecha_reg,103)";
            _Str_SQL += " FROM TCALENDCONT";
            _Str_SQL += " WHERE cyearacco='" + _P_Ctr_Multifiltro.Año;
            _Str_SQL += "' AND cmontacco='" + _P_Ctr_Multifiltro.Mes;
            _Str_SQL += "' AND cdelete='0' ORDER BY CONVERT(DATETIME,cdiafecha_reg) DESC";

            _Ds_Hasta = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            return _P_Ctr_Multifiltro._Mtd_ConvertirFechaDesde(_Ds_Hasta);
        }

        //--------------------------------------------------------------------------------------------------
        //  Eventos.
        //--------------------------------------------------------------------------------------------------

        /// <summary>
        /// Este método permite exportar la consulta a un archivo de Excel.
        /// </summary>
        private void _Mtd_ExportarExcel(string _P_Str_RutaArchivo)
        {
            Clases._Cls_ExcelUtilidades _MyExcel = new Clases._Cls_ExcelUtilidades();

            if (_P_Str_RutaArchivo != "")
            {
                DataTable oDatos, oCopia;

                if ((_Enu_TipoConsulta == _Enu_TiposConsultas.Pedido) && (_Dtg_GridPedido.DataSource != null))
                {
                    oDatos = (DataTable)_Dtg_GridPedido.DataSource;

                    // Esta copia se hace porque se deben eliminar unas columnas y cambiarle los títulos al resto.

                    oCopia = oDatos.Copy();

                    oCopia.Columns["c_fecha_pedido"].Caption = "Fecha";
                    oCopia.Columns["cpedido"].Caption = "Pedido";
                    oCopia.Columns["ccliente"].Caption = "Cliente";
                    oCopia.Columns["c_nomb_comer"].Caption = "Descripción";
                    oCopia.Columns["cvendedor"].Caption = "Código";
                    oCopia.Columns["cnamevendedor"].Caption = "Vendedor";
                    oCopia.Columns["cnamefpago"].Caption = "F. Pago";
                    oCopia.Columns["cempaques"].Caption = "Cajas";
                    oCopia.Columns["c_montotot_si"].Caption = "Monto";
                    oCopia.Columns["cefectividad"].Caption = "Efectividad";

                    oCopia.Columns["c_fecha_pedido"].SetOrdinal(0);
                    oCopia.Columns["cpedido"].SetOrdinal(1);
                    oCopia.Columns["ccliente"].SetOrdinal(2);
                    oCopia.Columns["c_nomb_comer"].SetOrdinal(3);
                    oCopia.Columns["cvendedor"].SetOrdinal(4);
                    oCopia.Columns["cnamevendedor"].SetOrdinal(5);
                    oCopia.Columns["cnamefpago"].SetOrdinal(6);
                    oCopia.Columns["cempaques"].SetOrdinal(7);
                    oCopia.Columns["c_montotot_si"].SetOrdinal(8);
                    oCopia.Columns["cefectividad"].SetOrdinal(9);
                    
                    oCopia.Columns.Remove("c_rif");
                    oCopia.Columns.Remove("cstatus");
                    oCopia.Columns.Remove("cunidades");
                    oCopia.Columns.Remove("montoparaordenar");
                    oCopia.Columns.Remove("cefectividad2");
                    oCopia.Columns.Remove("cfpago");
                    oCopia.Columns.Remove("c_bloqbackorder");
                    oCopia.Columns.Remove("c_rechabackorder");
                    oCopia.Columns.Remove("cbackorder");

                    _MyExcel._Mtd_DatasetToExcel_ConsultaMultiple(oCopia, _P_Str_RutaArchivo, "Pedidos");
                }
                else if ((_Enu_TipoConsulta == _Enu_TiposConsultas.Prefactura) && (_Dtg_GridPrefactura.DataSource != null))
                {
                    oDatos = (DataTable)_Dtg_GridPrefactura.DataSource;

                    // Esta copia se hace porque se deben eliminar unas columnas y cambiarle los títulos al resto.

                    oCopia = oDatos.Copy();

                    oCopia.Columns["c_fecha_pedido"].Caption = "Fecha del pedido";
                    oCopia.Columns["cpedido"].Caption = "Pedido";
                    oCopia.Columns["cpfactura"].Caption = "Pre-factura";
                    oCopia.Columns["c_nomb_comer"].Caption = "Nombre comercial";
                    oCopia.Columns["cname"].Caption = "Nombre";
                    oCopia.Columns["ccliente"].Caption = "Cliente";
                    oCopia.Columns["cempaques"].Caption = "Empaques";
                    oCopia.Columns["c_montotot_si"].Caption = "Total simp";
                    oCopia.Columns["cefectividad"].Caption = "Efectividad";
                    oCopia.Columns["cfacturado"].Caption = "Facturado";
                    oCopia.Columns["cprecarga"].Caption = "Precarga";
                    oCopia.Columns["cvendedor"].Caption = "Vendedor";
                    oCopia.Columns["cunidades"].Caption = "Unidades";
                    oCopia.Columns["c_factdevuelta"].Caption = "Fact. Devueltas";
                    oCopia.Columns["Dias"].Caption = "Días";
                    oCopia.Columns["Estado"].Caption = "Estado";
                    oCopia.Columns["cruta"].Caption = "Ciudad";
                    oCopia.Columns["cdescripcion"].Caption = "Ruta";
                    oCopia.Columns["ccantdesp"].Caption = "Cantidad al mes";
                    oCopia.Columns["cfechasalida"].Caption = "Fecha último";
                    oCopia.Columns["ctipoalimento_descrip"].Caption = "Es Alimento";

                    oCopia.Columns.Remove("cefectividad2");
                    oCopia.Columns.Remove("clistofacturar");
                    oCopia.Columns.Remove("cbackorder");

                    _MyExcel._Mtd_DatasetToExcel_ConsultaMultiple(oCopia, _P_Str_RutaArchivo, "Prefactura");
                }
                else if ((_Enu_TipoConsulta == _Enu_TiposConsultas.Factura) && (_Dtg_GridFactura.DataSource != null))
                {
                    oDatos = (DataTable)_Dtg_GridFactura.DataSource;

                    // Esta copia se hace porque se deben eliminar unas columnas y cambiarle los títulos al resto.

                    oCopia = oDatos.Copy();

                    oCopia.Columns["cfactura"].Caption = "Factura";
                    oCopia.Columns["c_fecha_factura"].Caption = "Fecha";
                    oCopia.Columns["cliente_descrip"].Caption = "Cliente";
                    oCopia.Columns["cmontotot_factura"].Caption = "Monto";
                    oCopia.Columns["cvendedor"].Caption = "Código";
                    oCopia.Columns["cvendedorname"].Caption = "Vendedor";
                    oCopia.Columns["cstsdespacho"].Caption = "Estatus despacho";
                    oCopia.Columns["cstscobrado"].Caption = "Estatus cobranza";
                    oCopia.Columns["cstsgeneral"].Caption = "Estatus general";
                    oCopia.Columns["diassinfact"].Caption = "Días en facturar";
                    oCopia.Columns["cpedido"].Caption = "Pedido";

                    oCopia.Columns["cfactura"].SetOrdinal(0);
                    oCopia.Columns["c_fecha_factura"].SetOrdinal(1);
                    oCopia.Columns["cliente_descrip"].SetOrdinal(2);
                    oCopia.Columns["cmontotot_factura"].SetOrdinal(3);
                    oCopia.Columns["cvendedor"].SetOrdinal(4);
                    oCopia.Columns["cvendedorname"].SetOrdinal(5);
                    oCopia.Columns["cstsdespacho"].SetOrdinal(6);
                    oCopia.Columns["cstscobrado"].SetOrdinal(7);
                    oCopia.Columns["cstsgeneral"].SetOrdinal(8);
                    oCopia.Columns["diassinfact"].SetOrdinal(9);
                    oCopia.Columns["cpedido"].SetOrdinal(10);

                    oCopia.Columns.Remove("obs1");
                    oCopia.Columns.Remove("obs2");
                    oCopia.Columns.Remove("ccliente");

                    _MyExcel._Mtd_DatasetToExcel_ConsultaMultiple(oCopia, _P_Str_RutaArchivo, "Factura");
                }
            }
        }

        private void _Btn_Agregar_Click(object sender, EventArgs e)
        {
            if (_Enu_TipoConsulta == _Enu_TiposConsultas.LotesPorDevolucion)
            {
                if ((_Ctr_Multifiltro_2.Visible) && (!_Ctr_Multifiltro_3.Visible))
                {
                    return;
                }
            }

            if (!_Ctr_Multifiltro_2.Visible)
            {
                _Ctr_Multifiltro_2._Mtd_RemoverFiltro(_Ctr_Multifiltro_1.TipoFiltro);
                _Ctr_Multifiltro_1._Mtd_RemoverFiltro(_Ctr_Multifiltro_2.TipoFiltro);

                if (_Enu_TipoConsulta == _Enu_TiposConsultas.RelacionChequesTransitoDepositado)
                {
                    _Ctr_Multifiltro_2.Location = new Point(_Ctr_Multifiltro_2.Location.X, 72);
                }
                else
                {
                    _Ctr_Multifiltro_2.Location = new Point(_Ctr_Multifiltro_2.Location.X, 45);
                }

                _Ctr_Multifiltro_2.Visible = true;
            }
            else if (!_Ctr_Multifiltro_3.Visible)
            {
                if (_Enu_TipoConsulta != _Enu_TiposConsultas.ClientesEstatus)
                {
                    _Ctr_Multifiltro_3._Mtd_RemoverFiltro(_Ctr_Multifiltro_1.TipoFiltro);
                    _Ctr_Multifiltro_3._Mtd_RemoverFiltro(_Ctr_Multifiltro_2.TipoFiltro);

                    _Ctr_Multifiltro_1._Mtd_RemoverFiltro(_Ctr_Multifiltro_3.TipoFiltro);
                    _Ctr_Multifiltro_2._Mtd_RemoverFiltro(_Ctr_Multifiltro_3.TipoFiltro);

                    if (_Enu_TipoConsulta == _Enu_TiposConsultas.RelacionChequesTransitoDepositado)
                    {
                        _Ctr_Multifiltro_3.Location = new Point(_Ctr_Multifiltro_3.Location.X, 108);
                    }
                    else
                    {
                        _Ctr_Multifiltro_3.Location = new Point(_Ctr_Multifiltro_3.Location.X, 83);
                    }

                    _Ctr_Multifiltro_3.Visible = true;
                }
            }
        }

        private void _Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (_Ctr_Multifiltro_3.Visible == true)
            {
                _Ctr_Multifiltro_3.Visible = false;
                _Ctr_Multifiltro_3._Mtd_AgregarFiltro(_Ctr_Multifiltro_1.TipoFiltro);
                _Ctr_Multifiltro_3._Mtd_AgregarFiltro(_Ctr_Multifiltro_2.TipoFiltro);
                _Ctr_Multifiltro_2._Mtd_AgregarFiltro(_Ctr_Multifiltro_3.TipoFiltro);
                _Ctr_Multifiltro_1._Mtd_AgregarFiltro(_Ctr_Multifiltro_3.TipoFiltro);
            }
            else if (_Ctr_Multifiltro_2.Visible == true)
            {
                _Ctr_Multifiltro_2.Visible = false;
                _Ctr_Multifiltro_2._Mtd_AgregarFiltro(_Ctr_Multifiltro_1.TipoFiltro);
                _Ctr_Multifiltro_2._Mtd_AgregarFiltro(_Ctr_Multifiltro_3.TipoFiltro);
                _Ctr_Multifiltro_1._Mtd_AgregarFiltro(_Ctr_Multifiltro_2.TipoFiltro);
                _Ctr_Multifiltro_3._Mtd_AgregarFiltro(_Ctr_Multifiltro_2.TipoFiltro);
            }
        }

        private void _Dtg_GridPedido_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (_Dtg_GridPedido.Rows[e.RowIndex].Cells["_Dtg_GridPedido_CRechaBackOrder"].Value != null)
                {
                    if (_Dtg_GridPedido.Rows[e.RowIndex].Cells["_Dtg_GridPedido_CRechaBackOrder"].Value.ToString().Trim() == "1")
                    {
                        e.Value = new Bitmap(GetType(), "Multimedia._Tool_ConsPedRechExis.ico");
                    }
                }
                if (_Dtg_GridPedido.Rows[e.RowIndex].Cells["_Dtg_GridPedido_CStatus"].Value != null)
                {
                    switch (_Dtg_GridPedido.Rows[e.RowIndex].Cells["_Dtg_GridPedido_CStatus"].Value.ToString())
                    {
                        case "3":
                            e.Value = new Bitmap(GetType(), "Multimedia._Tool_ConsPedBloExis.ico");
                            break;
                        case "4":
                            e.Value = new Bitmap(GetType(), "Multimedia._Tool_ConsPedFac.ico");
                            break;
                        case "7":
                            e.Value = new Bitmap(GetType(), "Multimedia._Tool_ConsPedAnul.ico");
                            break;
                        case "2":
                            e.Value = new Bitmap(GetType(), "Multimedia._Tool_Espera.ico");
                            break;
                        case "5":
                        case "10":
                        case "11":
                            e.Value = new Bitmap(GetType(), "Multimedia._Tool_Facturado.ico");
                            break;
                    }
                }
            }
        }

        private void _Dtg_GridPrefactura_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                switch (_Dtg_GridPrefactura.Rows[e.RowIndex].Cells["_Dtg_GridPrefactura_Estado"].Value.ToString())
                {
                    case "FACTURADA":
                        e.Value = new Bitmap(GetType(), "Multimedia._Tool_Facturado.ico");
                        break;
                    case "EN PRECARGA":
                        e.Value = new Bitmap(GetType(), "Multimedia._Tool_Espera.ico");
                        break;
                    case "POR CARGAR":
                        e.Value = new Bitmap(GetType(), "Multimedia._Tool_ConsPedFac.ico");
                        break;
                    case "PENDIENTE":
                        e.Value = new Bitmap(GetType(), "Multimedia._Tool_ConsPedBloExis.ico");
                        break;
                }
            }
        }

        private void _Btn_Consultar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if (!_Mtd_VerificarFiltros())
            {
                Cursor = Cursors.Default;
                return;
            }

            if (_Enu_TipoConsulta == _Enu_TiposConsultas.Pedido)
            {
                _Mtd_LlenarGridPedidos();
                Cursor = Cursors.Default;
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.Prefactura)
            {
                _Mtd_LlenarGridPreFactura();
                Cursor = Cursors.Default;
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.Factura)
            {
                _Mtd_LlenarGridFactura();
                Cursor = Cursors.Default;
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.RecepcionComprasResumidoSemanal)
            {
                _Mtd_MostrarRecepcionComprasSemanal();
                Cursor = Cursors.Default;
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.NotasRecepcionDetallado)
            {
                _Mtd_MostrarNotasRecepcionDetallado();
                Cursor = Cursors.Default;
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.CostoUtilidadProducto)
            {
                _Mtd_MostrarCostoUtilidadProducto();
                Cursor = Cursors.Default;
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.ClientesEstatus)
            {
                _Mtd_MostrarClientesEstatus();
                Cursor = Cursors.Default;
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.EfectividadCobranza)
            {
                _Mtd_MostrarEfectividadCobranza();
                Cursor = Cursors.Default;
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.RelacionChequesTransitoDepositado)
            {
                _Mtd_MostrarRelacionCheques();
                Cursor = Cursors.Default;
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.ValorizadoInventario)
            {
                _Mtd_MostrarValorizacionInventario();
                Cursor = Cursors.Default;
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.LimiteCreditoClientes)
            {
                _Chk_SeleccionarTodo.Checked = true;
                _Mtd_LlenarGridLimiteCreditoCliente();
                Cursor = Cursors.Default;
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.LotesPorDevolucion)
            {
                _Mtd_MostrarLotesPorDevolucion();
                Cursor = Cursors.Default;
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.FacturasProductos)
            {
                _Mtd_MostrarFacturasProductos();
                Cursor = Cursors.Default;
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.DetalleLotesFacturas)
            {
                _Mtd_MostrarDetalleLotesFacturas();
                Cursor = Cursors.Default;
            }
            Cursor = Cursors.Default;

        }

        private void _Ctrl_Multifiltro_1_KeyPress_Pedido()
        {
            if (_Enu_TipoConsulta == _Enu_TiposConsultas.Pedido)
            {
                _Mtd_LlenarGridPedidos();
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.Prefactura)
            {
                _Mtd_LlenarGridPreFactura();
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.Factura)
            {
                _Mtd_LlenarGridFactura();
            }
        }

        private void _Ctrl_Multifiltro_2_KeyPress_Pedido()
        {
            if (_Enu_TipoConsulta == _Enu_TiposConsultas.Pedido)
            {
                _Mtd_LlenarGridPedidos();
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.Prefactura)
            {
                _Mtd_LlenarGridPreFactura();
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.Factura)
            {
                _Mtd_LlenarGridFactura();
            }
        }

        private void _Ctrl_Multifiltro_3_KeyPress_Pedido()
        {
            if (_Enu_TipoConsulta == _Enu_TiposConsultas.Pedido)
            {
                _Mtd_LlenarGridPedidos();
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.Prefactura)
            {
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.Factura)
            {
                _Mtd_LlenarGridFactura();
            }
        }

        private void _Men_Opciones_Opening(object sender, CancelEventArgs e)
        {
            if (_Dtg_GridPedido.SelectedRows.Count == 1)
            {
                if (_Enu_TipoConsulta == _Enu_TiposConsultas.Pedido)
                {
                    using (DataGridViewRow Fila = _Dtg_GridPedido.Rows[_Dtg_GridPedido.CurrentCell.RowIndex])
                    {
                        if (Fila.Cells["_Dtg_GridPedido_CRechaBackOrder"].Value.ToString().Trim() == "1" && Fila.Cells["_Dtg_GridPedido_CStatus"].Value.ToString().Trim() != "7")
                        {
                            _Mnu_Anular.Visible = true;
                        }
                        else
                        {
                            _Mnu_Anular.Visible = false;
                        }
                    }
                }
            }
        }

        private void _Mnu_VerDetalle_Click(object sender, EventArgs e)
        {
            int _Int_Estatus_Temp = 0;

            if (_Enu_TipoConsulta == _Enu_TiposConsultas.Pedido)
            {
                if (_Dtg_GridPedido.CurrentCell != null)
                {
                    if (_Dtg_GridPedido.Rows[_Dtg_GridPedido.CurrentCell.RowIndex].Cells["_Dtg_GridPedido_CStatus"].Value.ToString().Trim() == "3")
                    {
                        _Int_Estatus_Temp = 1;
                    }
                    else if (_Dtg_GridPedido.Rows[_Dtg_GridPedido.CurrentCell.RowIndex].Cells["_Dtg_GridPedido_CRechaBackOrder"].Value.ToString().Trim() == "1" &
                              _Dtg_GridPedido.Rows[_Dtg_GridPedido.CurrentCell.RowIndex].Cells["_Dtg_GridPedido_CStatus"].Value.ToString().Trim() != "7")
                    {
                        _Int_Estatus_Temp = 3;
                    }
                    else if (_Dtg_GridPedido.Rows[_Dtg_GridPedido.CurrentCell.RowIndex].Cells["_Dtg_GridPedido_CStatus"].Value.ToString().Trim() == "4")
                    {
                        _Int_Estatus_Temp = 4;
                    }
                    else if (_Dtg_GridPedido.Rows[_Dtg_GridPedido.CurrentCell.RowIndex].Cells["_Dtg_GridPedido_CStatus"].Value.ToString().Trim() == "7")
                    {
                        _Int_Estatus_Temp = 7;
                    }
                    else
                    {
                        _Int_Estatus_Temp = Convert.ToInt32(_Dtg_GridPedido.Rows[_Dtg_GridPedido.CurrentCell.RowIndex].Cells["_Dtg_GridPedido_CStatus"].Value.ToString());
                    }

                    Frm_ConsultaPedidosDetalle _Frm = new Frm_ConsultaPedidosDetalle(
                                                                          _Dtg_GridPedido.Rows[_Dtg_GridPedido.CurrentCell.RowIndex].Cells["_Dtg_GridPedido_CPedido"].Value.ToString(),
                                                                          _Dtg_GridPedido.Rows[_Dtg_GridPedido.CurrentCell.RowIndex].Cells["_Dtg_GridPedido_CFechaPedido"].Value.ToString(),
                                                                          _Int_Estatus_Temp, _Dtg_GridPedido.Rows[_Dtg_GridPedido.CurrentCell.RowIndex].Cells["_Dtg_GridPedido_CStatus"].Value.ToString(),
                                                                          _Dtg_GridPedido.Rows[_Dtg_GridPedido.CurrentCell.RowIndex].Cells["_Dtg_GridPedido_CCliente"].Value.ToString() + " - " +
                                                                          _Dtg_GridPedido.Rows[_Dtg_GridPedido.CurrentCell.RowIndex].Cells["_Dtg_GridPedido_CNombComer"].Value.ToString().Trim(),
                                                                          _Dtg_GridPedido.Rows[_Dtg_GridPedido.CurrentCell.RowIndex].Cells["_Dtg_GridPedido_CVendedor"].Value.ToString(),
                                                                          _Dtg_GridPedido.Rows[_Dtg_GridPedido.CurrentCell.RowIndex].Cells["_Dtg_GridPedido_CNameVendedor"].Value.ToString(),
                                                                          _Dtg_GridPedido.Rows[_Dtg_GridPedido.CurrentCell.RowIndex].Cells["_Dtg_GridPedido_CEmpaques"].Value.ToString(),
                                                                          _Dtg_GridPedido.Rows[_Dtg_GridPedido.CurrentCell.RowIndex].Cells["_Dtg_GridPedido_CUnidades"].Value.ToString(),
                                                                          _Dtg_GridPedido.Rows[_Dtg_GridPedido.CurrentCell.RowIndex].Cells["_Dtg_GridPedido_CMontototSi"].Value.ToString(),
                                                                          Convert.ToDouble(_Dtg_GridPedido.Rows[_Dtg_GridPedido.CurrentCell.RowIndex].Cells["_Dtg_GridPedido_CEfectividad2"].Value.ToString()),
                                                                          Convert.ToInt32(_Dtg_GridPedido.Rows[_Dtg_GridPedido.CurrentCell.RowIndex].Cells["_Dtg_GridPedido_CBackOrder"].Value.ToString()), this);

                    _Frm.ShowDialog(this);
                }
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.Prefactura)
            {
                if (_Dtg_GridPrefactura.CurrentCell != null)
                {
                    if (_Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CListoFacturar"].Value == null)
                    {
                        _Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CListoFacturar"].Value = 0;
                    }

                    if (_Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CPrecarga"].Value == null)
                    {
                        _Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CPrecarga"].Value = 0;
                    }

                    if (_Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CFacturado"].Value == null)
                    {
                        _Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CFacturado"].Value = 0;
                    }

                    if (_Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CFactDevuelta"].Value == null)
                    {
                        _Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CFactDevuelta"].Value = 0;
                    }

                    if ((_Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CFacturado"].Value.ToString().Trim() == "1" &
                        _Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CFactDevuelta"].Value.ToString().Trim() == "0") |
                        (_Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CFacturado"].Value.ToString().Trim() == "1" &
                        _Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CFactDevuelta"].Value.ToString().Trim() == "1" &
                        Convert.ToInt32(_Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CPrecarga"].Value) > 0))
                    {
                        _Int_Estatus_Temp = 3;
                    }
                    else if ((_Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CListoFacturar"].Value.ToString().Trim() == "1" &
                               _Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CPrecarga"].Value.ToString().Trim() == "0" &
                               _Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CFacturado"].Value.ToString().Trim() == "0") |
                              (_Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CFactDevuelta"].Value.ToString().Trim() == "1" &
                               _Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CPrecarga"].Value.ToString().Trim() == "0"))
                    {
                        _Int_Estatus_Temp = 1;
                    }
                    else if (_Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CListoFacturar"].Value.ToString().Trim() == "1" &
                              Convert.ToInt32(_Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CPrecarga"].Value) > 0 &
                              _Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CFacturado"].Value.ToString().Trim() == "0")
                    {
                        _Int_Estatus_Temp = 2;
                    }

                    Frm_ConsultaPreFacturaDetalle _Frm = new Frm_ConsultaPreFacturaDetalle(
                                                                               _Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CPFactura"].Value.ToString(),
                                                                               _Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CPedido"].Value.ToString(),
                                                                               _Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CFechaPedido"].Value.ToString(),
                                                                               _Int_Estatus_Temp,
                                                                               _Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CCliente"].Value.ToString(),
                                                                               _Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CNombComer"].Value.ToString().Trim(),
                                                                               _Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CVendedor"].Value.ToString(),
                                                                               _Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CName"].Value.ToString(),
                                                                               _Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CEmpaques"].Value.ToString(),
                                                                               _Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CUnidades"].Value.ToString(),
                                                                               _Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CMontototSi"].Value.ToString(),
                                                                               Convert.ToInt32(_Dtg_GridPrefactura.Rows[_Dtg_GridPrefactura.CurrentCell.RowIndex].Cells["_Dtg_GridPrefactura_CBackOrder"].Value.ToString()),
                                                                               Frm_Padre._Str_Comp, this);

                    _Frm.ShowDialog(this);
                }
            }
            else if (_Enu_TipoConsulta == _Enu_TiposConsultas.Factura)
            {
                Cursor = Cursors.WaitCursor;

                Frm_ConsultaFacturaDetalle _Frm = new Frm_ConsultaFacturaDetalle(Convert.ToString(_Dtg_GridFactura["_Dtg_GridFactura_Factura", _Dtg_GridFactura.CurrentCell.RowIndex].Value).Trim());

                Cursor = Cursors.Default;

                _Frm.ShowDialog();
                _Frm.Dispose();
            }
        }

        private void _Mnu_Anular_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = true;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Pnl_Contenedor.Enabled = false;
                _Dtg_GridPedido.Enabled = false;

                _Txt_Clave.Text = "";
                _Txt_Clave.Focus();
            }
            else
            {
                _Pnl_Contenedor.Enabled = true;
                _Dtg_GridPedido.Enabled = true;
            }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Ctrl_Multifiltro_1_Click_Cliente()
        {
            Cursor = Cursors.WaitCursor;

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(64, _Ctr_Multifiltro_1.Cliente, 0, "");

            Cursor = Cursors.Default;

            _Frm.ShowDialog();
        }

        private void _Ctrl_Multifiltro_1_Click_Vendedor()
        {
            Cursor = Cursors.WaitCursor;

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(69, _Ctr_Multifiltro_1.Vendedor, 0, "");

            Cursor = Cursors.Default;

            _Frm.ShowDialog();

            _Ctr_Multifiltro_1.Vendedor.Text = (_Ctr_Multifiltro_1.Vendedor.Tag + " - " + _Ctr_Multifiltro_1.Vendedor.Text);
        }

        private void _Ctrl_Multifiltro_2_Click_Cliente()
        {
            Cursor = Cursors.WaitCursor;

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(64, _Ctr_Multifiltro_2.Cliente, 0, "");

            Cursor = Cursors.Default;

            _Frm.ShowDialog();
        }

        private void _Ctrl_Multifiltro_2_Click_Vendedor()
        {
            Cursor = Cursors.WaitCursor;

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(69, _Ctr_Multifiltro_2.Vendedor, 0, "");

            Cursor = Cursors.Default;

            _Frm.ShowDialog();

            _Ctr_Multifiltro_2.Vendedor.Text = (_Ctr_Multifiltro_2.Vendedor.Tag + " - " + _Ctr_Multifiltro_2.Vendedor.Text);
        }

        private void _Ctrl_Multifiltro_3_Click_Cliente()
        {
            Cursor = Cursors.WaitCursor;

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(64, _Ctr_Multifiltro_3.Cliente, 0, "");

            Cursor = Cursors.Default;

            _Frm.ShowDialog();
        }

        private void _Ctrl_Multifiltro_3_Click_Vendedor()
        {
            Cursor = Cursors.WaitCursor;

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(69, _Ctr_Multifiltro_3.Vendedor, 0, "");

            Cursor = Cursors.Default;

            _Frm.ShowDialog();

            _Ctr_Multifiltro_3.Vendedor.Text = (_Ctr_Multifiltro_3.Vendedor.Tag + " - " + _Ctr_Multifiltro_3.Vendedor.Text);
        }

        private void _Ctrl_Multifiltro_1_SelectionChangeCommitted_Año()
        {
            _Mtd_CargarMesesFiscales(_Ctr_Multifiltro_1);
        }

        private void _Ctrl_Multifiltro_2_SelectionChangeCommitted_Año()
        {
            _Mtd_CargarMesesFiscales(_Ctr_Multifiltro_2);
        }

        private void _Ctrl_Multifiltro_3_SelectionChangeCommitted_Año()
        {
            _Mtd_CargarMesesFiscales(_Ctr_Multifiltro_3);
        }

        private void _Ctr_Multifiltro_1_SelectionChangeCommitted_Mes()
        {
            if (_Enu_TipoConsulta == _Enu_TiposConsultas.LimiteCreditoClientes)
            {
                _Mtd_CargarReportesGenerados(_Ctr_Multifiltro_1);
            }
        }

        private void _Ctrl_Multifiltro_1_SelectionChangeCommitted_FiltrarPor()
        {
            if ((_Ctr_Multifiltro_1.TipoFiltro == "POR MES") || (_Ctr_Multifiltro_1.TipoFiltro == "POR MES DE CREACIÓN"))
            {
                _Mtd_CargarAñosFiscales(_Ctr_Multifiltro_1);
                _Mtd_CargarMesesFiscales(_Ctr_Multifiltro_1);
            }

            if (_Ctr_Multifiltro_2.Visible)
            {
                _Ctr_Multifiltro_2._Mtd_AgregarFiltro(_Ctr_Multifiltro_1.TipoFiltroAnterior);
                _Ctr_Multifiltro_2._Mtd_RemoverFiltro(_Ctr_Multifiltro_1.TipoFiltro);
            }

            if (_Ctr_Multifiltro_3.Visible)
            {
                _Ctr_Multifiltro_3._Mtd_AgregarFiltro(_Ctr_Multifiltro_1.TipoFiltroAnterior);
                _Ctr_Multifiltro_3._Mtd_RemoverFiltro(_Ctr_Multifiltro_1.TipoFiltro);
            }
        }

        private void _Ctrl_Multifiltro_2_SelectionChangeCommitted_FiltrarPor()
        {
            if ((_Ctr_Multifiltro_2.TipoFiltro == "POR MES") || (_Ctr_Multifiltro_2.TipoFiltro == "POR MES DE CREACIÓN"))
            {
                _Mtd_CargarAñosFiscales(_Ctr_Multifiltro_2);
                _Mtd_CargarMesesFiscales(_Ctr_Multifiltro_2);
            }

            if (_Ctr_Multifiltro_1.Visible)
            {
                _Ctr_Multifiltro_1._Mtd_AgregarFiltro(_Ctr_Multifiltro_2.TipoFiltroAnterior);
                _Ctr_Multifiltro_1._Mtd_RemoverFiltro(_Ctr_Multifiltro_2.TipoFiltro);
            }

            if (_Ctr_Multifiltro_3.Visible)
            {
                _Ctr_Multifiltro_3._Mtd_AgregarFiltro(_Ctr_Multifiltro_2.TipoFiltroAnterior);
                _Ctr_Multifiltro_3._Mtd_RemoverFiltro(_Ctr_Multifiltro_2.TipoFiltro);
            }
        }

        private void _Ctrl_Multifiltro_3_SelectionChangeCommitted_FiltrarPor()
        {
            if ((_Ctr_Multifiltro_3.TipoFiltro == "POR MES") || (_Ctr_Multifiltro_3.TipoFiltro == "POR MES DE CREACIÓN"))
            {
                _Mtd_CargarAñosFiscales(_Ctr_Multifiltro_3);
                _Mtd_CargarMesesFiscales(_Ctr_Multifiltro_3);
            }

            _Ctr_Multifiltro_1._Mtd_AgregarFiltro(_Ctr_Multifiltro_3.TipoFiltroAnterior);
            _Ctr_Multifiltro_1._Mtd_RemoverFiltro(_Ctr_Multifiltro_3.TipoFiltro);

            _Ctr_Multifiltro_2._Mtd_AgregarFiltro(_Ctr_Multifiltro_3.TipoFiltroAnterior);
            _Ctr_Multifiltro_2._Mtd_RemoverFiltro(_Ctr_Multifiltro_3.TipoFiltro);
        }

        private void _Dtg_GridPedido_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == -1) && (e.RowIndex > -1))
            {
                _Lbl_Informacion.Visible = true;
            }
            else
            {
                _Lbl_Informacion.Visible = false;
            }
        }

        private void _Dtg_GridPrefactura_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == -1) && (e.RowIndex > -1))
            {
                _Lbl_Informacion.Visible = true;
            }
            else
            {
                _Lbl_Informacion.Visible = false;
            }
        }

        private void _Dtg_GridFactura_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == -1) && (e.RowIndex > -1))
            {
                _Lbl_Informacion.Visible = true;
            }
            else
            {
                _Lbl_Informacion.Visible = false;
            }
        }

        private void _Dtg_GridFactura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 & e.ColumnIndex != -1)
            {
                string _Str_SQL = "";

                DataSet _Ds_Resultado = null;

                if (_Dtg_GridFactura.Columns[e.ColumnIndex].Name == "_Dg_GridFactura_StsDespachoObs")
                {
                    _Str_SQL = "SELECT c_ped_obs";
                    _Str_SQL += " FROM TFACTURAM";
                    _Str_SQL += " WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                    _Str_SQL += " AND ccompany='" + Frm_Padre._Str_Comp + "'";
                    _Str_SQL += " AND cfactura='" + Convert.ToString(_Dtg_GridFactura["_Dg_GridFactura_Factura", e.RowIndex].Value).Trim() + "'";

                    _Ds_Resultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                    if (_Ds_Resultado.Tables[0].Rows.Count > 0)
                    {
                        Frm_FactObs _Frm = new Frm_FactObs(_Ds_Resultado.Tables[0].Rows[0][0].ToString().Trim(), "FACTURA " + Convert.ToString(_Dtg_GridFactura["_Dg_Grid_ColFactura", e.RowIndex].Value).Trim());

                        _Frm.ShowDialog();
                    }
                }
                else if (_Dtg_GridFactura.Columns[e.ColumnIndex].Name == "_Dg_GridFactura_StsCobObs")
                {
                    _Str_SQL = "SELECT c_obs_cob";
                    _Str_SQL += " FROM TFACTURAM";
                    _Str_SQL += " WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "'";
                    _Str_SQL += " AND ccompany='" + Frm_Padre._Str_Comp + "'";
                    _Str_SQL += " AND cfactura='" + Convert.ToString(_Dtg_GridFactura["_Dg_GridFactura_Factura", e.RowIndex].Value).Trim() + "'";

                    _Ds_Resultado = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                    if (_Ds_Resultado.Tables[0].Rows.Count > 0)
                    {
                        Frm_FactObs _Frm = new Frm_FactObs(_Ds_Resultado.Tables[0].Rows[0][0].ToString().Trim(), "FACTURA " + Convert.ToString(_Dtg_GridFactura["_Dg_Grid_ColFactura", e.RowIndex].Value).Trim());

                        _Frm.ShowDialog();
                    }
                }
            }
        }

        private void _Btn_Exportar_Click(object sender, EventArgs e)
        {
            const int _C_Int_LimiteMaximoFilasExcel = 65530; //Se coloco menos filas de las posibles en total el maximo es 65536
            int _Int_FilasAExportar = 0;

            Cursor = Cursors.WaitCursor;

            // - - - - - - - - - - - - - - - - - - - - - Validacion de Cantidad de Filas Posibles a exportar - - - - - - - - - - - - - - - - - - - - - 
            
            // Obtenemos la cantidad de filas a exportar

            if ((_Enu_TipoConsulta == _Enu_TiposConsultas.Pedido) && (_Dtg_GridPedido.DataSource != null))
            {
                _Int_FilasAExportar = _Dtg_GridPedido.RowCount;
            }
            else if ((_Enu_TipoConsulta == _Enu_TiposConsultas.Prefactura) && (_Dtg_GridPrefactura.DataSource != null))
            {
                _Int_FilasAExportar = _Dtg_GridPrefactura.RowCount;
            }
            else if ((_Enu_TipoConsulta == _Enu_TiposConsultas.Factura) && (_Dtg_GridFactura.DataSource != null))
            {
                _Int_FilasAExportar = _Dtg_GridFactura.RowCount;
            }

            // Validamos.

            if (_Int_FilasAExportar >= _C_Int_LimiteMaximoFilasExcel)
            {
                MessageBox.Show("La cantidad de registros a exportar supera el límite de excel. Por favor cambie los filtros, en intente nuevamente", "Información : No es posible exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Cursor = Cursors.Default;

                return;
            }
            // - - - - - - - - - - - - - - - - - - - - - Validacion de Cantidad de Filas Posibles a exportar - - - - - - - - - - - - - - - - - - - - - 

            // Si todo va bien.

            if (_Ctr_Dialogo.ShowDialog() == DialogResult.OK)
            {
                Thread _Thr_Thread = new Thread(new ThreadStart(delegate
                {
                    _Mtd_ExportarExcel(_Ctr_Dialogo.FileName);
                }
                ));

                _Thr_Thread.Start();

                while (!_Thr_Thread.IsAlive);

                Frm_WaitForm _Frm_Form = new Frm_WaitForm(1000, _Thr_Thread, "Exportando consulta, espere...");

                _Frm_Form.ShowDialog();
                _Frm_Form.Dispose();
            }

            Cursor = Cursors.Default;
        }

        private void _Btn_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                string _Str_SQL;

                _Pnl_Clave.Visible = false;

                Cursor = Cursors.WaitCursor;

                _Str_SQL = "UPDATE TCOTPEDFACM";
                _Str_SQL += " SET cstatus='7',";
                _Str_SQL += " cdateupd=GETDATE(),";
                _Str_SQL += " cuserupd='" + Frm_Padre._Str_Use + "'";
                _Str_SQL += " WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                _Str_SQL += " AND cpedido='" + Convert.ToString(_Dtg_GridPedido.Rows[_Dtg_GridPedido.CurrentCell.RowIndex].Cells["_Dtg_GridPedido_CPedido"].Value).Trim() + "'";

                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                Cursor = Cursors.Default;
                Cursor = Cursors.WaitCursor;

                _Mtd_LlenarGridPedidos();

                Cursor = Cursors.Default;

                ThreadPool.QueueUserWorkItem(((Frm_Padre)MdiParent)._Frm_Contenedor._async_Default);

                MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                _Txt_Clave.Focus();
                _Txt_Clave.Select(0, _Txt_Clave.Text.Length);
            }
        }

        private void _Btn_Procesar_Click(object sender, EventArgs e)
        {
            string _Str_SQL;

            if (MessageBox.Show("¿Está seguro de procesar los clientes seleccionados a esta fecha?", "Advertencia",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                _Str_SQL = "UPDATE TGENLIMCREDM";
                _Str_SQL += " SET generado = 2";
                _Str_SQL += " WHERE CONVERT(VARCHAR, fecha, 103) = CONVERT(VARCHAR, '" + _Ctr_Multifiltro_1.Estado + "', 103);";

                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                foreach (DataGridViewRow Fila in _Dtg_GridLimiteCreditoCliente.Rows)
                {
                    if (Convert.ToBoolean(Fila.Cells["_Dtg_GridLimiteCreditoCliente_Aprobado"].Value))
                    {
                        _Str_SQL = "UPDATE TGENLIMCREDD SET caprobado = 1 FROM TGENLIMCREDD";
                        _Str_SQL += " INNER JOIN TGENLIMCREDM ON (TGENLIMCREDD.generacionId = TGENLIMCREDM.generacionId)";
                        _Str_SQL += " WHERE CONVERT(VARCHAR, fecha, 103) = CONVERT(VARCHAR, '" + _Ctr_Multifiltro_1.Estado + "', 103)";
                        _Str_SQL += " AND ccliente = '" + Fila.Cells["_Dtg_GridLimiteCreditoCliente_IdCliente"].Value + "';";

                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                        _Str_SQL = "UPDATE TCLIENTE SET c_limt_credit = '" + Fila.Cells["_Dtg_GridLimiteCreditoCliente_Limite"].Value + "'";
                        _Str_SQL += " WHERE ccliente = '" + Fila.Cells["_Dtg_GridLimiteCreditoCliente_IdCliente"].Value + "';";

                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                    }
                }

                MessageBox.Show("Finalizó la operación", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _Mtd_CargarReportesGenerados(_Ctr_Multifiltro_1);
            }
        }

        private void _Ctr_Multifiltro_1_Click_Proveedor()
        {
            _Ctr_Multifiltro_1.Proveedor.Tag = null;
            _Ctr_Multifiltro_1.Proveedor.Text = "";

            Cursor = Cursors.WaitCursor;

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(50, _Ctr_Multifiltro_1.Proveedor, 0, "");

            Cursor = Cursors.Default;

            _Frm.ShowDialog();

            if (_Ctr_Multifiltro_1.Proveedor.Text != "")
            {
                _Ctr_Multifiltro_1.Proveedor.Text = (_Ctr_Multifiltro_1.Proveedor.Tag + " - " +
                                                     _Ctr_Multifiltro_1.Proveedor.Text);
            }
        }

        private void _Ctr_Multifiltro_2_Click_Proveedor()
        {
            _Ctr_Multifiltro_2.Proveedor.Tag = null;
            _Ctr_Multifiltro_2.Proveedor.Text = "";

            Cursor = Cursors.WaitCursor;

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(50, _Ctr_Multifiltro_2.Proveedor, 0, "");

            Cursor = Cursors.Default;

            _Frm.ShowDialog();

            if (_Ctr_Multifiltro_2.Proveedor.Text != "")
            {
                _Ctr_Multifiltro_2.Proveedor.Text = (_Ctr_Multifiltro_2.Proveedor.Tag + " - " +
                                                     _Ctr_Multifiltro_2.Proveedor.Text);
            }
        }

        private void _Ctr_Multifiltro_3_Click_Proveedor()
        {
            _Ctr_Multifiltro_2.Proveedor.Tag = null;
            _Ctr_Multifiltro_2.Proveedor.Text = "";

            Cursor = Cursors.WaitCursor;

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(50, _Ctr_Multifiltro_3.Proveedor, 0, "");

            Cursor = Cursors.Default;

            _Frm.ShowDialog();

            if (_Ctr_Multifiltro_3.Proveedor.Text != "")
            {
                _Ctr_Multifiltro_3.Proveedor.Text = (_Ctr_Multifiltro_3.Proveedor.Tag + " - " +
                                                     _Ctr_Multifiltro_3.Proveedor.Text);
            }
        }

        private void _Ctr_Multifiltro_1_SelectionChangeCommitted_ProveedoresPGS()
        {
            _Mtd_CargarGrupos(_Ctr_Multifiltro_1.ProveedorPGSM);
            _Mtd_CargarSubGrupos(_Ctr_Multifiltro_1.ProveedorPGSM, _Ctr_Multifiltro_1.GrupoPGSM);
            _Mtd_CargarMarcas(_Ctr_Multifiltro_1.ProveedorPGSM, _Ctr_Multifiltro_1.GrupoPGSM);
        }

        private void _Ctr_Multifiltro_1_SelectionChangeCommitted_GruposPGS()
        {
            _Mtd_CargarSubGrupos(_Ctr_Multifiltro_1.ProveedorPGSM, _Ctr_Multifiltro_1.GrupoPGSM);
            _Mtd_CargarMarcas(_Ctr_Multifiltro_1.ProveedorPGSM, _Ctr_Multifiltro_1.GrupoPGSM);
        }

        private void _Ctr_Multifiltro_1_Click_Banco()
        {
            _Ctr_Multifiltro_1.Banco.Tag = null;
            _Ctr_Multifiltro_1.Banco.Text = "";

            Cursor = Cursors.WaitCursor;

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(76, _Ctr_Multifiltro_1.Banco, 0, "");

            Cursor = Cursors.Default;

            _Frm.ShowDialog();

            if (_Ctr_Multifiltro_1.Proveedor.Text != "")
            {
                _Ctr_Multifiltro_1.Proveedor.Text = (_Ctr_Multifiltro_1.Banco.Tag + " - " +
                                                     _Ctr_Multifiltro_1.Banco.Text);
            }
        }

        private void _Ctr_Multifiltro_2_Click_Banco()
        {
            _Ctr_Multifiltro_2.Banco.Tag = null;
            _Ctr_Multifiltro_2.Banco.Text = "";

            Cursor = Cursors.WaitCursor;

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(76, _Ctr_Multifiltro_2.Banco, 0, "");

            Cursor = Cursors.Default;

            _Frm.ShowDialog();

            if (_Ctr_Multifiltro_2.Proveedor.Text != "")
            {
                _Ctr_Multifiltro_2.Proveedor.Text = (_Ctr_Multifiltro_2.Banco.Tag + " - " +
                                                     _Ctr_Multifiltro_2.Banco.Text);
            }
        }

        private void _Ctr_Multifiltro_3_Click_Banco()
        {
            _Ctr_Multifiltro_3.Banco.Tag = null;
            _Ctr_Multifiltro_3.Banco.Text = "";

            Cursor = Cursors.WaitCursor;

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(76, _Ctr_Multifiltro_3.Banco, 0, "");

            Cursor = Cursors.Default;

            _Frm.ShowDialog();

            if (_Ctr_Multifiltro_3.Proveedor.Text != "")
            {
                _Ctr_Multifiltro_3.Proveedor.Text = (_Ctr_Multifiltro_3.Banco.Tag + " - " +
                                                     _Ctr_Multifiltro_3.Banco.Text);
            }
        }

        private void _Ctr_Multifiltro_1_Click_Rango()
        {
            _Ctr_Multifiltro_1.Rango.Tag = null;
            _Ctr_Multifiltro_1.Rango.Text = "";

            Cursor = Cursors.WaitCursor;

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(88, _Ctr_Multifiltro_1.Rango, 0, "");

            Cursor = Cursors.Default;

            _Frm.ShowDialog();

            if (_Ctr_Multifiltro_1.Rango.Text != "")
            {
                _Ctr_Multifiltro_1.Rango.Text = (_Ctr_Multifiltro_1.Rango.Text);
            }
        }

        private void Frm_ConsultaMultiple_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
        }

        //--------------------------------------------------------------------------------------------------
        //  Constructores.
        //--------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor de la clase Frm_ConsultaMultiple.
        /// </summary>
        /// <param name="_P_Enu_Tipo">Tipo de consulta que se está generando.</param>
        public Frm_ConsultaMultiple(_Enu_TiposConsultas _P_Enu_Tipo)
        {
            InitializeComponent();

            _Chk_SinDiscriminar.Visible = false;
            _Chk_SinDiscriminar.Left += 765;
            _Chk_SinDiscriminar.Top -= 38;

            _Chk_FiltrarGS.Visible = false;
            _Chk_FiltrarGS.Left += 765;
            _Chk_FiltrarGS.Top -= 40;

            _Enu_TipoConsulta = _P_Enu_Tipo;

            _Mtd_InicializarMultifiltros();

            switch (_Enu_TipoConsulta)
            {
                case _Enu_TiposConsultas.Pedido:

                    Text = "Consulta de pedidos";

                    _Dtg_GridPedido.Visible = true;

                    break;

                case _Enu_TiposConsultas.Factura:

                    Text = "Consulta de facturas";

                    _Dtg_GridFactura.Visible = true;

                    break;

                case _Enu_TiposConsultas.Prefactura:

                    Text = "Consulta de pre-facturas";

                    _Dtg_GridPrefactura.Visible = true;

                    break;

                case _Enu_TiposConsultas.RecepcionComprasResumidoSemanal:

                    Text = "Reporte de recepción de Compras (resumido semanal)";

                    _Rpt_VisorReportes.Visible = true;
                    _Btn_Exportar.Visible = false;

                    break;

                case _Enu_TiposConsultas.NotasRecepcionDetallado:

                    Text = "Reporte de notas de recepción detallado";

                    _Rpt_VisorReportes.Visible = true;
                    _Btn_Exportar.Visible = false;

                    break;

                case _Enu_TiposConsultas.CostoUtilidadProducto:
                
                    Text = "Informe - Costo y utilidad por producto";

                    _Rpt_VisorReportes.Visible = true;

                    _Btn_Exportar.Visible = false;
                    _Btn_Agregar.Visible = false;
                    _Btn_Eliminar.Visible = false;
                    _Btn_Consultar.Location = new Point((_Ctr_Multifiltro_1.Width + 90), (_Btn_Consultar.Location.Y + 5));

                    _Mtd_CargarProveedores();
                    _Mtd_CargarGrupos(_Ctr_Multifiltro_1.ProveedorPGSM);
                    _Mtd_CargarSubGrupos(_Ctr_Multifiltro_1.ProveedorPGSM, _Ctr_Multifiltro_1.GrupoPGSM);
                    _Mtd_CargarMarcas(_Ctr_Multifiltro_1.ProveedorPGSM, _Ctr_Multifiltro_1.GrupoPGSM);

                    _Ctr_Multifiltro_1._Mtd_MostrarPanel();

                    break;

                case _Enu_TiposConsultas.EfectividadCobranza:

                    Text = "Informe - Efectividad de cobranza";

                    _Rpt_VisorReportes.Visible = true;

                    _Btn_Agregar.Visible = false;
                    _Btn_Eliminar.Visible = false;
                    _Btn_Exportar.Visible = false;

                    break;

                case _Enu_TiposConsultas.ClientesEstatus:

                    Text = "Reporte de clientes por estatus";

                    _Rpt_VisorReportes.Visible = true;

                    _Btn_Exportar.Visible = false;

                    break;

                case _Enu_TiposConsultas.RelacionChequesTransitoDepositado:

                    Text = "Informe - Relación de Cheques en Tránsito y Depositados";

                    _Rpt_VisorReportes.Visible = true;

                    _Btn_Agregar.Top += 26;
                    _Btn_Eliminar.Top += 26;
                    _Btn_Exportar.Visible = false;

                    _Ctr_Multifiltro_1._Mtd_MostrarPanel();

                    break;

                case _Enu_TiposConsultas.ValorizadoInventario:

                    Text = "Informe - Valorizado de inventario";

                    _Rpt_VisorReportes.Visible = true;
                    
                    _Chk_SinDiscriminar.Visible = true;
                    _Chk_FiltrarGS.Visible = true;

                    _Mtd_CargarProveedores();
                    _Mtd_CargarGrupos(_Ctr_Multifiltro_1.ProveedorPGSM);
                    _Mtd_CargarSubGrupos(_Ctr_Multifiltro_1.ProveedorPGSM, _Ctr_Multifiltro_1.GrupoPGSM);
                    _Mtd_CargarMarcas(_Ctr_Multifiltro_1.ProveedorPGSM, _Ctr_Multifiltro_1.GrupoPGSM);

                    _Btn_Agregar.Visible = false;
                    _Btn_Eliminar.Visible = false;
                    _Btn_Exportar.Visible = false;

                    _Btn_Consultar.Top += 10;
                    _Btn_Consultar.Left += 30;

                    _Ctr_Multifiltro_1._Mtd_MostrarPanel();

                    _Mtd_CargarMesAnoContable(_Ctr_Multifiltro_1);

                    break;

                case _Enu_TiposConsultas.LimiteCreditoClientes:

                    Text = "Informe - Límites de Crédito de los Clientes";

                    _Btn_Agregar.Visible = false;
                    _Btn_Eliminar.Visible = false;
                    _Btn_Exportar.Visible = false;

                    _Btn_Consultar.Top += 15;

                    _Btn_Procesar.Top += 15;
                    _Btn_Procesar.Left -= 120;
                    _Btn_Procesar.Visible = true;

                    _Dtg_GridLimiteCreditoCliente.Visible = true;

                    _Chk_SeleccionarTodo.Top = 30;
                    _Chk_SeleccionarTodo.Left = 100;
                    _Chk_SeleccionarTodo.Visible = true;
                    _Chk_SeleccionarTodo.Checked = true;

                    _Mtd_CargarReportesGenerados(_Ctr_Multifiltro_1);
                    _Mtd_LlenarGridLimiteCreditoCliente();

                    _Ctr_Multifiltro_1._Mtd_MostrarPanel();

                    break;

                case _Enu_TiposConsultas.LotesPorDevolucion:

                    Text = "Informe - Lotes por devolución";

                    _Rpt_VisorReportes.Visible = true;

                    _Btn_Exportar.Visible = false;

                    break;

                case _Enu_TiposConsultas.FacturasProductos:

                    Text = "Informe - Detalle de facturas";

                    _Rpt_VisorReportes.Visible = true;

                    _Btn_Agregar.Visible = false;
                    _Btn_Eliminar.Visible = false;
                    _Btn_Exportar.Visible = false;

                    break;

                case _Enu_TiposConsultas.DetalleLotesFacturas:

                    Text = "Reporte de Detalle de Lotes y Facturas";

                    _Btn_Agregar.Visible = false;
                    _Btn_Eliminar.Visible = false;
                    _Rpt_VisorReportes.Visible = true;
                    _Btn_Exportar.Visible = false;

                    break;

                case _Enu_TiposConsultas.AnalisisCompraInventario:

                    Text = "Análisis de compra e inventario";

                    _Rpt_VisorReportes.Visible = true;

                    _Btn_Exportar.Visible = false;
                    _Btn_Agregar.Visible = false;
                    _Btn_Eliminar.Visible = false;
                    _Btn_Consultar.Location = new Point((_Ctr_Multifiltro_1.Width + 90), (_Btn_Consultar.Location.Y + 5));

                    _Mtd_CargarProveedores();
                    _Mtd_CargarGrupos(_Ctr_Multifiltro_1.ProveedorPGSM);
                    _Mtd_CargarSubGrupos(_Ctr_Multifiltro_1.ProveedorPGSM, _Ctr_Multifiltro_1.GrupoPGSM);
                    _Mtd_CargarMarcas(_Ctr_Multifiltro_1.ProveedorPGSM, _Ctr_Multifiltro_1.GrupoPGSM);

                    _Ctr_Multifiltro_1._Mtd_MostrarPanel();

                    break;
            }

            _Mnu_Opciones.Items[1].Visible = false;
        }

        /// <summary>
        /// Constructor de la clase Frm_ConsultaMultiple.
        /// </summary>
        /// <param name="_P_Enu_Tipo">Tipo de consulta.</param>
        /// <param name="_P_Str_Filtro">Filtro de la consulta.</param>
        /// <param name="_P_Str_Estado">Estado de la consulta.</param>
        public Frm_ConsultaMultiple(_Enu_TiposConsultas _P_Enu_Tipo, string _P_Str_Filtro, string _P_Str_Estado)
        {
            InitializeComponent();

            _Chk_SinDiscriminar.Visible = false;
            _Chk_SinDiscriminar.Left += 765;
            _Chk_SinDiscriminar.Top -= 38;

            _Chk_FiltrarGS.Visible = false;
            _Chk_FiltrarGS.Left += 765;
            _Chk_FiltrarGS.Top -= 50;

            _Enu_TipoConsulta = _P_Enu_Tipo;

            _Mtd_InicializarMultifiltros();

            _Ctr_Multifiltro_1.TipoFiltro = _P_Str_Filtro;
            _Ctr_Multifiltro_1.Estado = _P_Str_Estado;

            _Bol_Notificador = true;

            switch (_Enu_TipoConsulta)
            {
                case _Enu_TiposConsultas.Pedido:

                    Text = "Consulta de pedidos";

                    _Dtg_GridPedido.Visible = true;

                    _Mtd_LlenarGridPedidos();

                    break;

                case _Enu_TiposConsultas.Factura:

                    Text = "Consulta de facturas";

                    _Dtg_GridFactura.Visible = true;

                    break;

                case _Enu_TiposConsultas.Prefactura:

                    Text = "Consulta de pre-facturas";

                    _Dtg_GridPrefactura.Visible = true;

                    break;

                case _Enu_TiposConsultas.RecepcionComprasResumidoSemanal:

                    Text = "Reporte de recepción de Compras (resumido semanal)";

                    _Rpt_VisorReportes.Visible = true;

                    _Btn_Exportar.Visible = false;

                    break;

                case _Enu_TiposConsultas.NotasRecepcionDetallado:

                    Text = "Reporte de notas de recepción detallado";

                    _Rpt_VisorReportes.Visible = true;

                    _Btn_Exportar.Visible = false;

                    break;

                case _Enu_TiposConsultas.CostoUtilidadProducto:

                    Text = "Reporte de costo y utilidad por producto";

                    _Rpt_VisorReportes.Visible = true;

                    _Btn_Exportar.Visible = false;
                    _Btn_Agregar.Visible = false;
                    _Btn_Eliminar.Visible = false;

                    _Mtd_CargarProveedores();
                    _Mtd_CargarGrupos(_Ctr_Multifiltro_1.ProveedorPGSM);
                    _Mtd_CargarSubGrupos(_Ctr_Multifiltro_1.ProveedorPGSM, _Ctr_Multifiltro_1.GrupoPGSM);
                    _Mtd_CargarMarcas(_Ctr_Multifiltro_1.ProveedorPGSM, _Ctr_Multifiltro_1.GrupoPGSM);

                    break;

                case _Enu_TiposConsultas.EfectividadCobranza:

                    Text = "Informe - Efectividad de cobranza";

                    _Rpt_VisorReportes.Visible = true;

                    _Btn_Agregar.Visible = false;
                    _Btn_Eliminar.Visible = false;
                    _Btn_Exportar.Visible = false;

                    break;

                case _Enu_TiposConsultas.ClientesEstatus:

                    Text = "Reporte de clientes por estatus";

                    _Rpt_VisorReportes.Visible = true;

                    _Btn_Exportar.Visible = false;

                    break;

                case _Enu_TiposConsultas.RelacionChequesTransitoDepositado:

                    Text = "Informe - Relación de Cheques en Tránsito y Depositados";

                    _Rpt_VisorReportes.Visible = true;

                    _Btn_Agregar.Top += 26;
                    _Btn_Eliminar.Top += 26;
                    _Btn_Exportar.Visible = false;

                    _Ctr_Multifiltro_1._Mtd_MostrarPanel();

                    break;

                case _Enu_TiposConsultas.ValorizadoInventario:

                    Text = "Informe - Valorizado de inventario";

                    _Rpt_VisorReportes.Visible = true;

                    _Mtd_CargarProveedores();
                    _Mtd_CargarGrupos(_Ctr_Multifiltro_1.ProveedorPGSM);
                    _Mtd_CargarSubGrupos(_Ctr_Multifiltro_1.ProveedorPGSM, _Ctr_Multifiltro_1.GrupoPGSM);
                    _Mtd_CargarMarcas(_Ctr_Multifiltro_1.ProveedorPGSM, _Ctr_Multifiltro_1.GrupoPGSM);

                    _Btn_Agregar.Visible = false;
                    _Btn_Eliminar.Visible = false;
                    _Btn_Exportar.Visible = false;
                    
                    _Chk_SinDiscriminar.Visible = true;
                    _Chk_FiltrarGS.Visible = true;

                    _Btn_Consultar.Top += 10;
                    _Btn_Consultar.Left += 30;

                    _Ctr_Multifiltro_1._Mtd_MostrarPanel();

                    _Mtd_CargarMesAnoContable(_Ctr_Multifiltro_1);

                    break;

                case _Enu_TiposConsultas.LimiteCreditoClientes:

                    Text = "Informe - Límites de Crédito de los Clientes";

                    _Btn_Agregar.Visible = false;
                    _Btn_Eliminar.Visible = false;
                    _Btn_Exportar.Visible = false;

                    _Btn_Consultar.Top += 15;

                    _Btn_Procesar.Top += 15;
                    _Btn_Procesar.Left -= 120;
                    _Btn_Procesar.Visible = true;

                    _Dtg_GridLimiteCreditoCliente.Visible = true;

                    _Chk_SeleccionarTodo.Top = 30;
                    _Chk_SeleccionarTodo.Left = 100;
                    _Chk_SeleccionarTodo.Visible = true;
                    _Chk_SeleccionarTodo.Checked = true;

                    _Mtd_CargarReportesGenerados(_Ctr_Multifiltro_1);
                    _Mtd_LlenarGridLimiteCreditoCliente();

                    _Ctr_Multifiltro_1._Mtd_MostrarPanel();

                    break;

                case _Enu_TiposConsultas.LotesPorDevolucion:

                    Text = "Informe - Lotes por devolución";

                    _Rpt_VisorReportes.Visible = true;

                    _Btn_Exportar.Visible = false;

                    break;

                case _Enu_TiposConsultas.DetalleLotesFacturas:

                    Text = "Reporte de Detalle de Lotes y Facturas";

                    _Btn_Agregar.Visible = false;
                    _Btn_Eliminar.Visible = false;
                    _Rpt_VisorReportes.Visible = true;
                    _Btn_Exportar.Visible = false;

                    break;

                case _Enu_TiposConsultas.AnalisisCompraInventario:

                    Text = "Análisis de compra e inventario";

                    _Rpt_VisorReportes.Visible = true;

                    _Btn_Exportar.Visible = false;
                    _Btn_Agregar.Visible = false;
                    _Btn_Eliminar.Visible = false;

                    _Mtd_CargarProveedores();
                    _Mtd_CargarGrupos(_Ctr_Multifiltro_1.ProveedorPGSM);
                    _Mtd_CargarSubGrupos(_Ctr_Multifiltro_1.ProveedorPGSM, _Ctr_Multifiltro_1.GrupoPGSM);
                    _Mtd_CargarMarcas(_Ctr_Multifiltro_1.ProveedorPGSM, _Ctr_Multifiltro_1.GrupoPGSM);

                    break;
            }

            _Mnu_Opciones.Items[1].Visible = false;
        }

        private void _Chk_SeleccionarTodo_CheckedChanged(object sender, EventArgs e)
        {
            _Mtd_LlenarGridLimiteCreditoCliente();
        }

        private void _Ctr_Multifiltro_1_Click_Gerente()
        {
            _Ctr_Multifiltro_1.Gerente.Tag = null;
            _Ctr_Multifiltro_1.Gerente.Text = "";

            Cursor = Cursors.WaitCursor;

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(55, _Ctr_Multifiltro_1.Gerente, 0, "");

            Cursor = Cursors.Default;

            _Frm.ShowDialog();

            if (_Ctr_Multifiltro_1.Gerente.Text != "")
            {
                _Ctr_Multifiltro_1.Gerente.Text = (_Ctr_Multifiltro_1.Gerente.Text);
            }
        }

        private void _Ctr_Multifiltro_2_Click_Gerente()
        {
            _Ctr_Multifiltro_2.Gerente.Tag = null;
            _Ctr_Multifiltro_2.Gerente.Text = "";

            Cursor = Cursors.WaitCursor;

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(55, _Ctr_Multifiltro_2.Gerente, 0, "");

            Cursor = Cursors.Default;

            _Frm.ShowDialog();

            if (_Ctr_Multifiltro_2.Gerente.Text != "")
            {
                _Ctr_Multifiltro_2.Gerente.Text = (_Ctr_Multifiltro_2.Gerente.Text);
            }
        }

        private void _Ctr_Multifiltro_3_Click_Gerente()
        {
            _Ctr_Multifiltro_3.Gerente.Tag = null;
            _Ctr_Multifiltro_3.Gerente.Text = "";

            Cursor = Cursors.WaitCursor;

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(55, _Ctr_Multifiltro_3.Gerente, 0, "");

            Cursor = Cursors.Default;

            _Frm.ShowDialog();

            if (_Ctr_Multifiltro_3.Gerente.Text != "")
            {
                _Ctr_Multifiltro_3.Gerente.Text = (_Ctr_Multifiltro_3.Gerente.Text);
            }
        }

        private void _Ctr_Multifiltro_1_Click_Producto()
        {
            _Ctr_Multifiltro_1.Producto.Tag = null;
            _Ctr_Multifiltro_1.Producto.Text = "";

            Cursor = Cursors.WaitCursor;

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(96,_Ctr_Multifiltro_1.Producto, 0, "");

            Cursor = Cursors.Default;

            _Frm.ShowDialog();

            if (_Ctr_Multifiltro_1.Producto.Text != "")
            {
                _Ctr_Multifiltro_1.Producto.Text = (_Ctr_Multifiltro_1.Producto.Text);
            }
        }

        private void _Ctr_Multifiltro_2_Click_Producto()
        {
            _Ctr_Multifiltro_2.Producto.Tag = null;
            _Ctr_Multifiltro_2.Producto.Text = "";

            Cursor = Cursors.WaitCursor;

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(96, _Ctr_Multifiltro_2.Producto, 0, "");

            Cursor = Cursors.Default;

            _Frm.ShowDialog();

            if (_Ctr_Multifiltro_2.Producto.Text != "")
            {
                _Ctr_Multifiltro_2.Producto.Text = (_Ctr_Multifiltro_2.Producto.Text);
            }
        }

        private void _Ctr_Multifiltro_3_Click_Producto()
        {
            _Ctr_Multifiltro_3.Producto.Tag = null;
            _Ctr_Multifiltro_3.Producto.Text = "";

            Cursor = Cursors.WaitCursor;

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(96, _Ctr_Multifiltro_3.Producto, 0, "");

            Cursor = Cursors.Default;

            _Frm.ShowDialog();

            if (_Ctr_Multifiltro_3.Producto.Text != "")
            {
                _Ctr_Multifiltro_3.Producto.Text = (_Ctr_Multifiltro_3.Producto.Text);
            }
        }

        private void _Chk_FiltrarGS_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chk_FiltrarGS.Checked)
            {
                _Chk_SeleccionarTodo.Enabled = false;
                _Chk_SinDiscriminar.Enabled = false;
            }
            else
            {
                _Chk_SeleccionarTodo.Enabled = true;
                _Chk_SinDiscriminar.Enabled = true;
            }
        }
    }
}