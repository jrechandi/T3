using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T3.Clases
{
    public class _Cls_RutinasGuiasRelacionesCobranza
    {
        public enum _TiposEstadoCobranzaCliente
        {
            NadaCargado = 1,
            Incompleta,
            Completa
        }

        #region Rutinas Publicas de Validación

        public static bool _Mtd_ValidarGuiaDespacho_Cobranza(string _P_Str_cguiadesp, string _P_Str_cgroupcomp, bool _P_MostrarMensajes = false)
        {
            //Validamos Primero si todos los documentos estan posteados
            var _Bol_DatosValidos = _Mtd_ValidarTodosDocumentosposteados_GuiaDespacho_Cobranza(_P_Str_cguiadesp,_P_Str_cgroupcomp );
            //Verifico
            if (!_Bol_DatosValidos)
            {
                if (_P_MostrarMensajes)
                    MessageBox.Show("Hay documentos de la guía de despacho que aún no han sido posteados en alguna relacion de cobranza. No se puede marcar la guía como cobrada. Verifique.", "Requerimiento",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            //Consultamos las relaciones de cobranza asociadas a la guia
            var _Str_Cadena = "SELECT cidrelacobro, ccompany FROM TRELACCOBM WHERE cgroupcomp='" + _P_Str_cgroupcomp + "' AND cguiacobro='" + _P_Str_cguiadesp + "' AND ISNULL(cdelete,0)=0 ";
            var _Ds_Relaciones = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //Recorro las Relaciones
            foreach (DataRow _Dtr_Relacion in _Ds_Relaciones.Tables[0].Rows)
            {
                // Obtengo el valor de la celda
                var _Str_cidrelacobro = _Dtr_Relacion["cidrelacobro"].ToString();
                var _Str_ccompany = _Dtr_Relacion["ccompany"].ToString();
                _Bol_DatosValidos = _Mtd_ValidarRelacion(_Str_cidrelacobro, _Str_ccompany, _P_Str_cgroupcomp, _P_MostrarMensajes);
                //Verifico
                if (!_Bol_DatosValidos)
                {
                    return false;
                }
            }

            //Validamos los saldos de los clientes
            var _Bol_SaldoCero = _Mtd_TodosLosClientesTieneSaldoCero(_P_Str_cguiadesp, _P_Str_cgroupcomp);
            if (!_Bol_SaldoCero)
            {
                if (_P_MostrarMensajes)
                    MessageBox.Show("Hay clientes que aun tienen saldo. No se puede marcar la guía como cobrada. Verifique.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }


            //si llegamos aqui todas las validaciones estan bien
            return true;
        }

        #endregion

        #region Rutinas Publicas de Validaciónes nuevas

        public static bool _Mtd_EsValidaCobranza(string _P_Str_cgroupcompany, string _P_Str_Cguiddesp, bool _P_MostrarMensajes = false)
        {
            var _Bol_GuiaValida = true;

            //Validaciones que ya existian
            _Bol_GuiaValida = _Mtd_ValidarGuiaDespacho_Cobranza(_P_Str_Cguiddesp, _P_Str_cgroupcompany, _P_MostrarMensajes);
            if (!_Bol_GuiaValida) return _Bol_GuiaValida;

            //Validacion nueva
            //Obtenemos las relaciones que tenga generada  la guia
            var _Str_Cadena = "SELECT TRELACCOBM.cidrelacobro, TRELACCOBM.ccompany FROM TRELACCOBM  WHERE (TRELACCOBM.cdelete = 0) AND (TRELACCOBM.cguiacobro = '" + _P_Str_Cguiddesp + "')";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //Recorremos
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                var _Str_cidrelacobro = _Row["cidrelacobro"].ToString();
                var _Str_ccompany = _Row["ccompany"].ToString();
                _Bol_GuiaValida = _Mtd_EsValidaCobranza(_P_Str_cgroupcompany, _Str_ccompany, _P_Str_Cguiddesp, _Str_cidrelacobro, _P_MostrarMensajes);
                if (!_Bol_GuiaValida) break;
            }
            return _Bol_GuiaValida;
        }
        public static bool _Mtd_EsValidaCobranza(string _P_Str_cgroupcompany, string _P_Str_ccompany, string _P_Str_Cguiddesp, string _P_Str_cidrelacobro, bool _P_Bol_MostrarMensajes = false, double _P_Dbl_LimiteFaltante = 0)
        {
            //Si no pasamos el limite faltante, debemos consultarlo
            if (_P_Dbl_LimiteFaltante <= 0)
                _P_Dbl_LimiteFaltante = Frm_RC_DocumentosClientes._Mtd_ObtenerLimiteFaltante(_P_Str_ccompany);

            // --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= VALIDACIONES de TABLAS TEMPORALES EN TABLAS FINALES = --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= 

            // Obtenemos todos los pagos de dicha relacion
            var _Lst_PagossAValidar = _Mtd_ObtenerTodosLosPagosSegunGuiaYCompania_EnGuia(_P_Str_cgroupcompany, _P_Str_ccompany, _P_Str_Cguiddesp);
            //
            foreach (var _oPago in _Lst_PagossAValidar)
            {
                var _Bol_EsValido = _Mtd_EsValidoPagoDeTemporalesEnFinales(_P_Str_cgroupcompany, _P_Str_ccompany, _oPago.cidpago, _P_Bol_MostrarMensajes);
                if (!_Bol_EsValido)
                {
                    if (_P_Bol_MostrarMensajes)
                        MessageBox.Show("Existe un error con el cliente #" + _oPago.ccliente + " por favor vuelva a consultarlo y a finalizarlo. Verifique.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            // --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= VALIDACIONES EN TABLAS FINALES = --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= --= 

            // -- Obtenemos todos los documentos de la guia y compañia a validar
            var _Lst_DocumentosAValidar = _Mtd_ObtenerTodosLosDocumentosSegunGuiaYCompania_EnGuia(_P_Str_cgroupcompany, _P_Str_ccompany, _P_Str_Cguiddesp);

            // -- Validamos que todos los documentos esten cargados y saldados (tablas finales)
            foreach (var _Documento in _Lst_DocumentosAValidar)
            {
                //Obtenemos los totales
                var _Dbl_MontoCanceladoResumen = _Mtd_ObtenerMontoCanceladoDocumento(_P_Str_cgroupcompany, _P_Str_ccompany, _P_Str_cidrelacobro, _Documento.ccliente, _Documento.cfactura);
                var _Dbl_MontoCanceladoDetalle = _Mtd_ObtenerMontoCanceladoDocumentoDesdeElDetalle(_P_Str_cgroupcompany, _P_Str_ccompany, _P_Str_cidrelacobro, _Documento.ccliente, _Documento.cfactura);

                //Redondeamos a dos decimales
                _Dbl_MontoCanceladoResumen = Math.Round(_Dbl_MontoCanceladoResumen, 2);
                _Dbl_MontoCanceladoDetalle = Math.Round(_Dbl_MontoCanceladoDetalle, 2);

                //Valido que los montos cancelados sean iguales
                if (_Dbl_MontoCanceladoResumen != _Dbl_MontoCanceladoDetalle)
                {
                    if (_P_Bol_MostrarMensajes)
                        MessageBox.Show("La relación de cobranza " + _P_Str_cidrelacobro + " no es valida por favor vuelva a finalizar. Verifique.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                //Obtenemos los totales de cada documento y verificamos si verdaderamente cancelan el documento
                //con una tolerancia segun la tabla de faltante (esto es por documento) y deberia ser por cliente pero para hacerlo mas rapido validamos asi
                var _Dbl_MontoTotalNC = _Mtd_ObtenerMontoNCDocumento(_P_Str_cgroupcompany, _P_Str_ccompany, _P_Str_cidrelacobro, _Documento.ccliente, _Documento.cfactura);
                var _Dbl_MontoTotalRetenciones = _Mtd_ObtenerMontoRetencionesDocumento(_P_Str_cgroupcompany, _P_Str_ccompany, _P_Str_cidrelacobro, _Documento.ccliente, _Documento.cfactura);

                var _Dbl_MontoRestanteDocumento = _Documento.cmontototal - _Dbl_MontoTotalNC - _Dbl_MontoTotalRetenciones;
                _Dbl_MontoRestanteDocumento = Math.Round(_Dbl_MontoRestanteDocumento, 2);

                var _Dbl_Saldo = (_Dbl_MontoRestanteDocumento - _Dbl_MontoCanceladoResumen);
                _Dbl_Saldo = Math.Round(_Dbl_Saldo, 2);

                if ((Math.Abs(_Dbl_Saldo) >= _P_Dbl_LimiteFaltante))
                {
                    if (_P_Bol_MostrarMensajes)
                        MessageBox.Show("La relación de cobranza " + _P_Str_cidrelacobro + " no es valida por favor vuelva a finalizar. Verifique.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            //Si llegamos aqui
            return true;

        }
        public static bool _Mtd_EsValidoPagoDeTemporalesEnFinales(string _P_Str_cgroupcompany, string _P_Str_ccompany, string _P_Str_cidpago, bool _P_Bol_MostrarMensajes = false)
        {
            var _Dbl_LimiteFaltante = Frm_RC_DocumentosClientes._Mtd_ObtenerLimiteFaltante(_P_Str_ccompany);

            //Obtenemos el pago
            var _Str_Consulta = "SELECT * FROM TTRCPAGOM where (cidpago = '" + _P_Str_cidpago + "') AND (ccompany = '" + _P_Str_ccompany + "') ";
            var _Ds_TTRCPAGOM = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Consulta);
            if (_Ds_TTRCPAGOM.Tables[0].Rows.Count > 0 )
            {
                var _Str_cnumerodoc = _Ds_TTRCPAGOM.Tables[0].Rows[0]["cnumerodoc"].ToString();
                var _Str_cbanco = _Ds_TTRCPAGOM.Tables[0].Rows[0]["cbanco"].ToString();
                var _Str_ccliente = _Ds_TTRCPAGOM.Tables[0].Rows[0]["ccliente"].ToString();
                var _Str_ctipodoc = _Ds_TTRCPAGOM.Tables[0].Rows[0]["ctipodoc"].ToString();
                var _Str_cmontototal = Convert.ToDouble(_Ds_TTRCPAGOM.Tables[0].Rows[0]["cmontototal"]).ToString().Replace(",", ".");

                // - - - - - -- - - - - -- - - - - -- - - - - -- - - - - -- - - - - -- - - - - - Validamos las maestras o deposito - - - - - -- - - - - -- - - - - -- - - - - -- - - - - -- - - - - -- - - - - -
                //En función al tipo de documento
                if (_Str_ctipodoc == "C") //Si es cheque
                {
                    //Verificamos si existe en la bd
                    _Str_Consulta = "SELECT cidrelacobro FROM TRELACCOBDCHEQ " +
                                    "WHERE (cgroupcomp='" + _P_Str_cgroupcompany + "') AND (ccompany='" + _P_Str_ccompany + "') " +
                                    "AND (cnumcheque='" + _Str_cnumerodoc + "') AND (cbancocheque='" + _Str_cbanco + "') AND (ccliente='" + _Str_ccliente + "') AND (cmontocheq='" + _Str_cmontototal + "') ";
                    var _Ds_Consulta = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Consulta);
                    if (_Ds_Consulta.Tables[0].Rows.Count <= 0)
                    {
                        return false;
                    }
                }
                else //Si es deposito
                {
                    //Verificamos si existe en la bd
                    _Str_Consulta = "SELECT cidrelacobro FROM TRELACCOBDDEPM " +
                                    "WHERE (cgroupcomp='" + _P_Str_cgroupcompany + "') AND (ccompany='" + _P_Str_ccompany + "') " +
                                    "AND (cnumdepo='" + _Str_cnumerodoc + "') AND (cbancodepo='" + _Str_cbanco + "')  AND (cmontodepo='" + _Str_cmontototal + "') ";
                    var _Ds_Consulta = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Consulta);
                    if (_Ds_Consulta.Tables[0].Rows.Count <= 0)
                    {
                        return false;
                    }
                }

                // - - - - - -- - - - - -- - - - - -- - - - - -- - - - - -- - - - - -- - - - - - Validamos el detalle de los pagos - - - - - -- - - - - -- - - - - -- - - - - -- - - - - -- - - - - -- - - - - -
                //Cargamos el detalle de los pagos
                _Str_Consulta = "SELECT * FROM TTRCPAGOD where (cidpago = '" + _P_Str_cidpago + "') ";
                var _Ds_TTRCPAGOD = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Consulta);
                foreach (DataRow _oDetallePago in _Ds_TTRCPAGOD.Tables[0].Rows)
                {
                    var _Str_cfactura = _oDetallePago["cfactura"].ToString();
                    var _Str_cmontoabono = Convert.ToDouble(_oDetallePago["cmontoabono"]).ToString(CultureInfo.InvariantCulture).Replace(",", ".");
                    var _Str_ctipocancelado = _Str_ctipodoc == "C" ? "2" : "1";

                    //Verificamos si el documento fue pagado solo con Nc
                    _Str_Consulta = "SELECT (TTRCDOCUMENTO.cmontodocumento - TTRCDOCUMENTO.cmontonotacredito) AS csaldodocumento " +
                                    "FROM TTRCPAGOD INNER JOIN TTRCDOCUMENTO ON TTRCPAGOD.cfactura = TTRCDOCUMENTO.cfactura INNER JOIN TTRCPAGOM ON TTRCPAGOD.cidpago = TTRCPAGOM.cidpago AND TTRCDOCUMENTO.ccompany = TTRCPAGOM.ccompany AND TTRCDOCUMENTO.cguia = TTRCPAGOM.cguia " +
                                    "WHERE (TTRCPAGOD.cdelete = 0) AND (TTRCDOCUMENTO.cdelete = 0) AND (TTRCPAGOM.cdelete = 0) AND (TTRCPAGOD.cmontoabono = 0) AND " +
                                    "(TTRCPAGOD.cidpago = '" + _P_Str_cidpago + "') AND (TTRCPAGOD.cfactura = '" + _Str_cfactura + "')";
                    var _Ds_Consulta = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Consulta);
                    if (_Ds_Consulta.Tables[0].Rows.Count > 0)
                    {
                        var _Dbl_SaldoDocumento = Convert.ToDouble(_Ds_Consulta.Tables[0].Rows[0][0].ToString());
                        if ((Math.Abs(_Dbl_SaldoDocumento) >= _Dbl_LimiteFaltante))
                        {
                            return false;
                        }
                         _Str_ctipocancelado = "0"; //Pagado por Nc
                    }

                    //Verificamos si existe en la bd
                    _Str_Consulta = "SELECT cidrelacobro FROM TRELACCOBDD " +
                                    "WHERE (cgroupcomp='" + _P_Str_cgroupcompany + "') AND (ccompany='" + _P_Str_ccompany + "') AND (ctipodocument='FACT') " +
                                    "AND (cnumdocu='" + _Str_cfactura + "') AND (cmontodeefectivo='" + _Str_cmontoabono + "') " +
                                    "AND (ctipocancelado='" + _Str_ctipocancelado + "')";
                    _Ds_Consulta = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Consulta);
                    if (_Ds_Consulta.Tables[0].Rows.Count <= 0)
                    {
                        return false;
                    }
                }

                // - - - - - -- - - - - -- - - - - -- - - - - -- - - - - -- - - - - -- - - - - - Validamos el detalle de las notas de credito  - - - - - -- - - - - -- - - - - -- - - - - -- - - - - -- - - - - -- - - - - -
                //Cargamos el detalle de los pagos
                _Str_Consulta = "SELECT * FROM TTRCNOTACREDD where (cidpago = '" + _P_Str_cidpago + "') ";
                var _Ds_TTRCNOTACREDD = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Consulta);
                foreach (DataRow _oDetalleNc in _Ds_TTRCNOTACREDD.Tables[0].Rows)
                {
                    var _Str_cfactura = _oDetalleNc["cfactura"].ToString();
                    var _Str_cnotacredito = _oDetalleNc["cnotacredito"].ToString();

                    //Verificamos si existe en la bd
                    _Str_Consulta = "SELECT cidrelacobro FROM TRELACCOBD " +
                                    "WHERE (cgroupcompany='" + _P_Str_cgroupcompany + "') AND (ccompany='" + _P_Str_ccompany + "') AND (ctipodocument='FACT') " +
                                    "AND (cnumdocu='" + _Str_cfactura + "') " +
                                    "AND ((cnotacred1='" + _Str_cnotacredito + "') OR (cnotacred2='" + _Str_cnotacredito + "') OR (cnotacred3='" + _Str_cnotacredito + "'))";
                    var _Ds_Consulta = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Consulta);
                    if (_Ds_Consulta.Tables[0].Rows.Count <= 0)
                    {
                        return false;
                    }
                }

                // - - - - - -- - - - - -- - - - - -- - - - - -- - - - - -- - - - - -- - - - - - Validamos el detalle de las retenciones  - - - - - -- - - - - -- - - - - -- - - - - -- - - - - -- - - - - -- - - - - -
                //Cargamos el detalle de los pagos
                _Str_Consulta = "SELECT * FROM TTRCRETENCION where (cidpago = '" + _P_Str_cidpago + "') ";
                var _Ds_TTRCRETENCION = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Consulta);
                foreach (DataRow _oDetalleReten in _Ds_TTRCRETENCION.Tables[0].Rows)
                {
                    var _Str_cfactura = _oDetalleReten["cfactura"].ToString();
                    var _Str_cnumretencion = _oDetalleReten["cnumretencion"].ToString();
                    var _Str_cmonto = Convert.ToDouble(_oDetalleReten["cmonto"]).ToString(CultureInfo.InvariantCulture).Replace(",", ".");

                    //Verificamos si existe en la bd
                    _Str_Consulta = "SELECT cidrelacobro FROM TRELACCOBD " +
                                    "WHERE (cgroupcompany='" + _P_Str_cgroupcompany + "') AND (ccompany='" + _P_Str_ccompany + "') AND (ctipodocument='FACT') " +
                                    "AND (cnumdocu='" + _Str_cfactura + "') " +
                                    "AND (cnumcomproclie='" + _Str_cnumretencion + "') AND (cmontcompretiva='" + _Str_cmonto + "') AND (cretencioniva='1')";
                    var _Ds_Consulta = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Consulta);
                    if (_Ds_Consulta.Tables[0].Rows.Count <= 0)
                    {
                        return false;
                    }
                }


                //Por defecto
                return true;
            }

            //Por defecto si no consigue el pago, es que hay un error
            return false;
        }

        #endregion

        #region Rutinas Publicas de asignación de codigos de vendedor

        public static void _Mtd_AsignarCodigosDeVendedor(string _P_Str_cgroupcompany, string _P_Str_Cguiddesp)
        {
            //Obtenemos las relaciones que tenga generada  la guia
            var _Str_Cadena = "SELECT TRELACCOBM.cidrelacobro, TRELACCOBM.ccompany FROM TRELACCOBM  WHERE (TRELACCOBM.cdelete = 0) AND (TRELACCOBM.cguiacobro = '" + _P_Str_Cguiddesp + "')";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //Recorremos
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                var _Str_cidrelacobro = _Row["cidrelacobro"].ToString();
                var _Str_ccompany = _Row["ccompany"].ToString();
                _Mtd_AsignarCodigosDeVenededor(_P_Str_cgroupcompany, _Str_ccompany, _Str_cidrelacobro);
            }
        }

        public static void _Mtd_AsignarCodigosDeVenededor(string _P_Str_cgroupcompany, string _P_Str_ccompany, string _P_Str_cidrelacobro)
        {

            // ------------------------  Para cheqhes en transito ------------------------

            //Obtenemos todos los cheques en transito
            var _Lst_ChequesEntransito = _Mtd_ObtenerChequesEnTransito(_P_Str_cgroupcompany, _P_Str_ccompany, _P_Str_cidrelacobro);

            //Por cada cheque
            foreach (var _Cheque in _Lst_ChequesEntransito)
            {
                //Variables
                var _Str_cvendedor = "";

                //Obtenemos los documentos con mayor valor pagado
                var _Lst_Documentos = _Mtd_ObtenerDocumentosConMayorValorSegunChequeEnTransito(_P_Str_cgroupcompany, _P_Str_ccompany, _P_Str_cidrelacobro, _Cheque.cnumcheque, _Cheque.cbancocheque, _Cheque.ciddrelacobro_cheq);

                //Verificamos si existen varios documentos con el mismo monto como valor monto pagado
                if (_Lst_Documentos.Count > 1) //Varios
                {
                    //Tomamos uno de forma aleatoria
                    var _ObjetoRandom = new Random();
                    _Str_cvendedor = _Lst_Documentos[_ObjetoRandom.Next(_Lst_Documentos.Count)].cvendedor;
                }
                else if (_Lst_Documentos.Count == 1) //Solo uno
                {
                    //Tomamos el unico
                    _Str_cvendedor = _Lst_Documentos[0].cvendedor;
                }

                //Si obtenemos un codigo actualizamos
                if (_Str_cvendedor != "")
                {
                    //Actualizamos el campo
                    _Mtd_ActualizarVendedorChequeTransito(_P_Str_cgroupcompany, _P_Str_ccompany, _P_Str_cidrelacobro, _Cheque.cnumcheque, _Cheque.cbancocheque, _Cheque.ciddrelacobro_cheq, _Str_cvendedor);
                }

            }

            // ------------------------  Para cheqhes despositados ------------------------

            //Obtenemos todos los cheques en transito
            var _Lst_ChequesDepositados = _Mtd_ObtenerChequesDepositados(_P_Str_cgroupcompany, _P_Str_ccompany, _P_Str_cidrelacobro);

            //Por cada cheque
            foreach (var _Cheque in _Lst_ChequesDepositados)
            {
                //Variables
                var _Str_cvendedor = "";

                //Obtenemos los documentos con mayor valor pagado
                var _Lst_Documentos = _Mtd_ObtenerDocumentosConMayorValorSegunChequeDepositado(_P_Str_cgroupcompany, _P_Str_ccompany, _P_Str_cidrelacobro,_Cheque.cnumdepo, _Cheque.cnumcheque, _Cheque.cbancocheque, _Cheque.ciddrelacobrodep, _Cheque.ciddrelacobro_depd);

                //Verificamos si existen varios documentos con el mismo monto como valor monto pagado
                if (_Lst_Documentos.Count > 1) //Varios
                {
                    //Tomamos uno de forma aleatoria
                    var _ObjetoRandom = new Random();
                    _Str_cvendedor = _Lst_Documentos[_ObjetoRandom.Next(_Lst_Documentos.Count)].cvendedor;
                }
                else if (_Lst_Documentos.Count == 1) //Solo uno
                {
                    //Tomamos el unico
                    _Str_cvendedor = _Lst_Documentos[0].cvendedor;
                }

                //Si obtenemos un codigo actualizamos
                if (_Str_cvendedor != "")
                {
                    //Actualizamos el campo
                    _Mtd_ActualizarVendedorChequeDepositado(_P_Str_cgroupcompany, _P_Str_ccompany, _P_Str_cidrelacobro, _Cheque.cnumdepo, _Cheque.cnumcheque, _Cheque.cbancocheque, _Cheque.ciddrelacobrodep, _Cheque.ciddrelacobro_depd, _Str_cvendedor);
                }
            }
        }

        #endregion

        #region Rutinas Privadas de asignación de codigos de vendedores

        private static List<_Cls_ChequesEntransito> _Mtd_ObtenerChequesEnTransito(string _P_Str_cgroupcompany, string _P_Str_ccompany, string _P_Str_cidrelacobro)
        {
            var _oResultado = new List<_Cls_ChequesEntransito>();
            var _Str_Cadena = "SELECT cgroupcomp, ccompany, cnumcheque, ccliente, cbancocheque, ciddrelacobro_cheq " + 
                              "FROM TRELACCOBDCHEQ  " +
                              "WHERE (TRELACCOBDCHEQ.cdelete = 0) AND (TRELACCOBDCHEQ.cgroupcomp = '" + _P_Str_cgroupcompany + "') AND (TRELACCOBDCHEQ.ccompany = '" + _P_Str_ccompany + "')  AND (TRELACCOBDCHEQ.cidrelacobro = '" + _P_Str_cidrelacobro + "')";
            var _Ds_Documentos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds_Documentos.Tables[0].Rows)
            {
                var _Str_cnumcheque = _Row["cnumcheque"].ToString();
                var _Str_ccliente = _Row["ccliente"].ToString();
                var _Str_cbanco = _Row["cbancocheque"].ToString();
                var _Str_ciddrelacobro_cheq = _Row["ciddrelacobro_cheq"].ToString();
                var _oItem = new _Cls_ChequesEntransito
                    {
                        cgroupcompany = _P_Str_cgroupcompany,
                        ccompany = _P_Str_ccompany, 
                        cnumcheque = _Str_cnumcheque,
                        ccliente = _Str_ccliente,
                        cbancocheque = _Str_cbanco,
                        ciddrelacobro_cheq = _Str_ciddrelacobro_cheq
                    };
                _oResultado.Add(_oItem);
            }
            return _oResultado;
        }
        private static List<_Cls_Documentos> _Mtd_ObtenerDocumentosConMayorValorSegunChequeEnTransito(string _P_Str_cgroupcompany, string _P_Str_ccompany, string _P_Str_cidrelacobro, string _P_Str_cnumcheque, string _P_Str_cbancocheque, string _P_Str_ciddrelacobro_cheq)
        {
            var _oResultado = new List<_Cls_Documentos>();
            var _Str_Cadena = "SELECT TRELACCOBDCHEQ.ccompany, TRELACCOBDCHEQ.cgroupcomp, TRELACCOBDCHEQ.cidrelacobro, TRELACCOBDCHEQ.ciddrelacobro_cheq, TRELACCOBDCHEQ.cnumcheque, TRELACCOBDCHEQ.cbancocheque, TRELACCOBDCHEQ.ccliente, TRELACCOBDCHEQ.cmontocheq, TRELACCOBDD.cmontodeefectivo, TRELACCOBDD.cnumdocu, TFACTURAM.cvendedorc " +
                              "FROM TRELACCOBDCHEQ INNER JOIN TRELACCOBD ON TRELACCOBDCHEQ.cgroupcomp = TRELACCOBD.cgroupcompany AND TRELACCOBDCHEQ.ccompany = TRELACCOBD.ccompany AND TRELACCOBDCHEQ.cidrelacobro = TRELACCOBD.cidrelacobro INNER JOIN TRELACCOBDD ON TRELACCOBD.ctipodocument = TRELACCOBDD.ctipodocument AND TRELACCOBD.cnumdocu = TRELACCOBDD.cnumdocu AND TRELACCOBD.cgroupcompany = TRELACCOBDD.cgroupcomp AND TRELACCOBD.ccompany = TRELACCOBDD.ccompany AND TRELACCOBD.cidrelacobro = TRELACCOBDD.cidrelacobro AND TRELACCOBDCHEQ.ciddrelacobro_cheq = TRELACCOBDD.cidrelaciondetalle INNER JOIN TFACTURAM ON TRELACCOBDCHEQ.cgroupcomp = TFACTURAM.cgroupcomp AND TRELACCOBDD.ccompany = TFACTURAM.ccompany AND TRELACCOBDD.cnumdocu = TFACTURAM.cfactura " +
                              "WHERE (TRELACCOBDCHEQ.cgroupcomp = '" + _P_Str_cgroupcompany + "') AND (TRELACCOBDCHEQ.ccompany = '" + _P_Str_ccompany + "') AND (TRELACCOBDCHEQ.cidrelacobro = '" + _P_Str_cidrelacobro + "') AND (TRELACCOBDCHEQ.cnumcheque = '" + _P_Str_cnumcheque + "') AND (TRELACCOBDCHEQ.cbancocheque = '" + _P_Str_cbancocheque + "') AND (TRELACCOBDCHEQ.ciddrelacobro_cheq = '" + _P_Str_ciddrelacobro_cheq + "') " +
                              "AND (TRELACCOBDD.cidrelaciondep = 0) AND (TRELACCOBDD.ctipocancelado = 2) " +
                              "AND TRELACCOBDD.cmontodeefectivo=(" +
                              "SELECT MAX(cmontodeefectivo) " +
                              "FROM TRELACCOBDCHEQ INNER JOIN TRELACCOBD ON TRELACCOBDCHEQ.cgroupcomp = TRELACCOBD.cgroupcompany AND TRELACCOBDCHEQ.ccompany = TRELACCOBD.ccompany AND TRELACCOBDCHEQ.cidrelacobro = TRELACCOBD.cidrelacobro INNER JOIN TRELACCOBDD ON TRELACCOBD.ctipodocument = TRELACCOBDD.ctipodocument AND TRELACCOBD.cnumdocu = TRELACCOBDD.cnumdocu AND TRELACCOBD.cgroupcompany = TRELACCOBDD.cgroupcomp AND TRELACCOBD.ccompany = TRELACCOBDD.ccompany AND TRELACCOBD.cidrelacobro = TRELACCOBDD.cidrelacobro AND TRELACCOBDCHEQ.ciddrelacobro_cheq = TRELACCOBDD.cidrelaciondetalle INNER JOIN TFACTURAM ON TRELACCOBDCHEQ.cgroupcomp = TFACTURAM.cgroupcomp AND TRELACCOBDD.ccompany = TFACTURAM.ccompany AND TRELACCOBDD.cnumdocu = TFACTURAM.cfactura " +
                              "WHERE (TRELACCOBDCHEQ.cgroupcomp = '" + _P_Str_cgroupcompany + "') AND (TRELACCOBDCHEQ.ccompany = '" + _P_Str_ccompany + "') AND (TRELACCOBDCHEQ.cidrelacobro = '" + _P_Str_cidrelacobro + "') AND (TRELACCOBDCHEQ.cnumcheque = '" + _P_Str_cnumcheque + "') AND (TRELACCOBDCHEQ.cbancocheque = '" + _P_Str_cbancocheque + "') AND (TRELACCOBDCHEQ.ciddrelacobro_cheq = '" + _P_Str_ciddrelacobro_cheq + "') " +
                              "AND (TRELACCOBDD.cidrelaciondep = 0) AND (TRELACCOBDD.ctipocancelado = 2) " +
                              ") ";
            var _Ds_Documentos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds_Documentos.Tables[0].Rows)
            {
                var _Str_cnumdocu = _Row["cnumdocu"].ToString();
                var _Str_ccliente = _Row["ccliente"].ToString();
                var _Str_cvendedorc = _Row["cvendedorc"].ToString();
                var _oItem = new _Cls_Documentos
                {
                    cgroupcompany = _P_Str_cgroupcompany,
                    ccompany = _P_Str_ccompany,
                    cnumdocu = _Str_cnumdocu,
                    ccliente = _Str_ccliente,
                    cvendedor = _Str_cvendedorc
                };
                _oResultado.Add(_oItem);
            }
            return _oResultado;
        }
        private static void _Mtd_ActualizarVendedorChequeTransito(string _P_Str_cgroupcompany, string _P_Str_ccompany, string _P_Str_cidrelacobro, string _P_Str_cnumcheque, string _P_Str_cbancocheque, string _P_Str_ciddrelacobro_cheq, string _P_Str_cvendedor)
        {
            var _Str_Cadena = "UPDATE TRELACCOBDCHEQ " +
                              "SET cvendedor='" + _P_Str_cvendedor + "'" +
                              "WHERE (TRELACCOBDCHEQ.cgroupcomp = '" + _P_Str_cgroupcompany + "') AND (TRELACCOBDCHEQ.ccompany = '" + _P_Str_ccompany + "') AND (TRELACCOBDCHEQ.cidrelacobro = '" + _P_Str_cidrelacobro + "') AND (TRELACCOBDCHEQ.cnumcheque = '" + _P_Str_cnumcheque + "') AND (TRELACCOBDCHEQ.cbancocheque = '" + _P_Str_cbancocheque + "') AND (TRELACCOBDCHEQ.ciddrelacobro_cheq = '" + _P_Str_ciddrelacobro_cheq + "') ";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }

        private static List<_Cls_ChequesDepositados> _Mtd_ObtenerChequesDepositados(string _P_Str_cgroupcompany, string _P_Str_ccompany, string _P_Str_cidrelacobro)
        {
            var _oResultado = new List<_Cls_ChequesDepositados>();
            var _Str_Cadena = "SELECT cgroupcomp, ccompany, cnumdepo, cnumcheque, ccliente, cbancocheque, ciddrelacobrodep, ciddrelacobro_depd " +
                              "FROM TRELACCOBDDEPD  " +
                              "WHERE (TRELACCOBDDEPD.cdelete = 0) AND (TRELACCOBDDEPD.cefectivocheq = 2) AND (TRELACCOBDDEPD.cgroupcomp = '" + _P_Str_cgroupcompany + "') AND (TRELACCOBDDEPD.ccompany = '" + _P_Str_ccompany + "')  AND (TRELACCOBDDEPD.cidrelacobro = '" + _P_Str_cidrelacobro + "')";
            var _Ds_Documentos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds_Documentos.Tables[0].Rows)
            {
                var _Str_cnumdepo = _Row["cnumdepo"].ToString();
                var _Str_cnumcheque = _Row["cnumcheque"].ToString();
                var _Str_ccliente = _Row["ccliente"].ToString();
                var _Str_cbancocheque = _Row["cbancocheque"].ToString();
                var _Str_ciddrelacobrodep = _Row["ciddrelacobrodep"].ToString();
                var _Str_ciddrelacobro_depd = _Row["ciddrelacobro_depd"].ToString();
                var _oItem = new _Cls_ChequesDepositados
                {
                    cgroupcompany = _P_Str_cgroupcompany,
                    ccompany = _P_Str_ccompany,
                    cnumdepo = _Str_cnumdepo,
                    cnumcheque = _Str_cnumcheque,
                    ccliente = _Str_ccliente,
                    cbancocheque = _Str_cbancocheque,
                    ciddrelacobrodep= _Str_ciddrelacobrodep,
                    ciddrelacobro_depd = _Str_ciddrelacobro_depd
                };
                _oResultado.Add(_oItem);
            }
            return _oResultado;
        }
        private static List<_Cls_Documentos> _Mtd_ObtenerDocumentosConMayorValorSegunChequeDepositado(string _P_Str_cgroupcompany, string _P_Str_ccompany, string _P_Str_cidrelacobro, string _P_Str_cnumdepo, string _P_Str_cnumcheque, string _P_Str_cbancocheque, string _P_Str_ciddrelacobrodep, string _P_Str_ciddrelacobro_depd)
        {
            var _oResultado = new List<_Cls_Documentos>();
            var _Str_Cadena = "SELECT TRELACCOBDD.ccompany, TRELACCOBDD.cgroupcomp, TRELACCOBDD.cidrelacobro, TRELACCOBDDEPD.ciddrelacobrodep, TRELACCOBDDEPD.ciddrelacobro_depd, TRELACCOBDDEPD.cnumcheque, TRELACCOBDDEPD.cbancocheque, TRELACCOBDDEPD.ccliente, TRELACCOBDDEPD.cmontocheq, TRELACCOBDD.cmontodeefectivo, TRELACCOBDD.cnumdocu, TFACTURAM.cvendedorc  " +
                              "FROM TRELACCOBDDEPD INNER JOIN TRELACCOBDDEPM ON TRELACCOBDDEPD.ccompany = TRELACCOBDDEPM.ccompany AND TRELACCOBDDEPD.cgroupcomp = TRELACCOBDDEPM.cgroupcomp AND TRELACCOBDDEPD.ciddrelacobrodep = TRELACCOBDDEPM.ciddrelacobro_dep AND TRELACCOBDDEPD.cidrelacobro = TRELACCOBDDEPM.cidrelacobro INNER JOIN TRELACCOBD INNER JOIN TRELACCOBDD ON TRELACCOBD.ctipodocument = TRELACCOBDD.ctipodocument AND TRELACCOBD.cnumdocu = TRELACCOBDD.cnumdocu AND TRELACCOBD.cgroupcompany = TRELACCOBDD.cgroupcomp AND TRELACCOBD.ccompany = TRELACCOBDD.ccompany AND TRELACCOBD.cidrelacobro = TRELACCOBDD.cidrelacobro INNER JOIN TFACTURAM ON TRELACCOBD.ccliente = TFACTURAM.ccliente AND TRELACCOBD.cgroupcompany = TFACTURAM.cgroupcomp AND TRELACCOBD.ccompany = TFACTURAM.ccompany AND TRELACCOBD.cnumdocu = TFACTURAM.cfactura ON TRELACCOBDDEPM.ccompany = TRELACCOBD.ccompany AND TRELACCOBDDEPM.cgroupcomp = TRELACCOBD.cgroupcompany AND TRELACCOBDDEPM.cidrelacobro = TRELACCOBD.cidrelacobro AND TRELACCOBDDEPM.ciddrelacobro_dep = TRELACCOBDD.cidrelaciondep AND TRELACCOBDDEPD.ciddrelacobro_depd = TRELACCOBDD.cidrelaciondetalle  " +
                              "WHERE (TRELACCOBDDEPD.cgroupcomp = '" + _P_Str_cgroupcompany + "') AND (TRELACCOBDDEPD.ccompany = '" + _P_Str_ccompany + "') AND (TRELACCOBDDEPD.cidrelacobro = '" + _P_Str_cidrelacobro + "') AND (TRELACCOBDDEPD.cnumdepo = '" + _P_Str_cnumdepo + "') AND (TRELACCOBDDEPD.cnumcheque = '" + _P_Str_cnumcheque + "') AND (TRELACCOBDDEPD.cbancocheque = '" + _P_Str_cbancocheque + "') AND (TRELACCOBDDEPD.ciddrelacobrodep = '" + _P_Str_ciddrelacobrodep + "') AND (TRELACCOBDDEPD.ciddrelacobro_depd = '" + _P_Str_ciddrelacobro_depd + "') " +
                              "AND (TRELACCOBDD.ctipocancelado = 1) AND (TRELACCOBDDEPD.cefectivocheq = 2) " +
                              "AND TRELACCOBDD.cmontodeefectivo=(" +
                              "SELECT MAX(cmontodeefectivo) " +
                              "FROM TRELACCOBDDEPD INNER JOIN TRELACCOBDDEPM ON TRELACCOBDDEPD.ccompany = TRELACCOBDDEPM.ccompany AND TRELACCOBDDEPD.cgroupcomp = TRELACCOBDDEPM.cgroupcomp AND TRELACCOBDDEPD.ciddrelacobrodep = TRELACCOBDDEPM.ciddrelacobro_dep AND TRELACCOBDDEPD.cidrelacobro = TRELACCOBDDEPM.cidrelacobro INNER JOIN TRELACCOBD INNER JOIN TRELACCOBDD ON TRELACCOBD.ctipodocument = TRELACCOBDD.ctipodocument AND TRELACCOBD.cnumdocu = TRELACCOBDD.cnumdocu AND TRELACCOBD.cgroupcompany = TRELACCOBDD.cgroupcomp AND TRELACCOBD.ccompany = TRELACCOBDD.ccompany AND TRELACCOBD.cidrelacobro = TRELACCOBDD.cidrelacobro INNER JOIN TFACTURAM ON TRELACCOBD.ccliente = TFACTURAM.ccliente AND TRELACCOBD.cgroupcompany = TFACTURAM.cgroupcomp AND TRELACCOBD.ccompany = TFACTURAM.ccompany AND TRELACCOBD.cnumdocu = TFACTURAM.cfactura ON TRELACCOBDDEPM.ccompany = TRELACCOBD.ccompany AND TRELACCOBDDEPM.cgroupcomp = TRELACCOBD.cgroupcompany AND TRELACCOBDDEPM.cidrelacobro = TRELACCOBD.cidrelacobro AND TRELACCOBDDEPM.ciddrelacobro_dep = TRELACCOBDD.cidrelaciondep AND TRELACCOBDDEPD.ciddrelacobro_depd = TRELACCOBDD.cidrelaciondetalle  " +
                              "WHERE (TRELACCOBDDEPD.cgroupcomp = '" + _P_Str_cgroupcompany + "') AND (TRELACCOBDDEPD.ccompany = '" + _P_Str_ccompany + "') AND (TRELACCOBDDEPD.cidrelacobro = '" + _P_Str_cidrelacobro + "') AND (TRELACCOBDDEPD.cnumdepo = '" + _P_Str_cnumdepo + "') AND (TRELACCOBDDEPD.cnumcheque = '" + _P_Str_cnumcheque + "') AND (TRELACCOBDDEPD.cbancocheque = '" + _P_Str_cbancocheque + "') AND (TRELACCOBDDEPD.ciddrelacobrodep = '" + _P_Str_ciddrelacobrodep + "') AND (TRELACCOBDDEPD.ciddrelacobro_depd = '" + _P_Str_ciddrelacobro_depd + "') " +
                              "AND (TRELACCOBDD.ctipocancelado = 1) AND (TRELACCOBDDEPD.cefectivocheq = 2) " +
                              ") ";
            var _Ds_Documentos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds_Documentos.Tables[0].Rows)
            {
                var _Str_cnumdocu = _Row["cnumdocu"].ToString();
                var _Str_ccliente = _Row["ccliente"].ToString();
                var _Str_cvendedorc = _Row["cvendedorc"].ToString();
                var _oItem = new _Cls_Documentos
                {
                    cgroupcompany = _P_Str_cgroupcompany,
                    ccompany = _P_Str_ccompany,
                    cnumdocu = _Str_cnumdocu,
                    ccliente = _Str_ccliente,
                    cvendedor = _Str_cvendedorc
                };
                _oResultado.Add(_oItem);
            }
            return _oResultado;
        }
        private static void _Mtd_ActualizarVendedorChequeDepositado(string _P_Str_cgroupcompany, string _P_Str_ccompany, string _P_Str_cidrelacobro, string _P_Str_cnumdepo, string _P_Str_cnumcheque, string _P_Str_cbancocheque, string _P_Str_ciddrelacobrodep, string _P_Str_ciddrelacobro_depd, string _P_Str_cvendedor)
        {
            var _Str_Cadena = "UPDATE TRELACCOBDDEPD " +
                              "SET cvendedor='" + _P_Str_cvendedor + "'" +
                              "WHERE (TRELACCOBDDEPD.cgroupcomp = '" + _P_Str_cgroupcompany + "') AND (TRELACCOBDDEPD.ccompany = '" + _P_Str_ccompany + "') AND (TRELACCOBDDEPD.cidrelacobro = '" + _P_Str_cidrelacobro + "') AND (TRELACCOBDDEPD.cnumdepo = '" + _P_Str_cnumdepo + "') AND (TRELACCOBDDEPD.cnumcheque = '" + _P_Str_cnumcheque + "') AND (TRELACCOBDDEPD.cbancocheque = '" + _P_Str_cbancocheque + "') AND (TRELACCOBDDEPD.ciddrelacobrodep = '" + _P_Str_ciddrelacobrodep + "') AND (TRELACCOBDDEPD.ciddrelacobro_depd = '" + _P_Str_ciddrelacobro_depd + "') ";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }

        #endregion

        #region Rutinas Privadas de Validación

        public static bool _Mtd_TodosLosClientesTieneSaldoCero(string _P_Str_cguiadesp, string _P_Str_cgroupcomp)
        {
            var _Dbl_Saldo = 0.0;
            //Cargamos el Limite máximo permitido por cliente
            var _Dbl_LimiteFaltante = Frm_RC_DocumentosClientes._Mtd_ObtenerLimiteFaltante(Frm_Padre._Str_Comp);
            //Cargamos los Clientes al grid
            var _Str_Cadena = "SELECT TCLIENTE.ccliente AS [Cliente] ,TCLIENTE.c_nomb_comer AS [Nombre del Cliente] , SUM(TSALDOCLIENTED.csaldofactura) AS [Saldo] FROM TGUIADESPACHOD INNER JOIN TFACTURAM ON TGUIADESPACHOD.cgroupcomp = TFACTURAM.cgroupcomp AND TGUIADESPACHOD.ccompany = TFACTURAM.ccompany AND TGUIADESPACHOD.cfactura = TFACTURAM.cfactura INNER JOIN TCLIENTE ON TFACTURAM.cgroupcomp = TCLIENTE.cgroupcomp AND TFACTURAM.ccliente = TCLIENTE.ccliente INNER JOIN TSALDOCLIENTED ON TFACTURAM.cgroupcomp = TSALDOCLIENTED.cgroupcomp AND TFACTURAM.ccompany = TSALDOCLIENTED.ccompany AND TFACTURAM.ccliente = TSALDOCLIENTED.ccliente AND TFACTURAM.cfactura = TSALDOCLIENTED.cnumdocu WHERE (TFACTURAM.cdelete = 0) AND (TCLIENTE.cdelete = 0) AND (TGUIADESPACHOD.cguiadesp = '" + _P_Str_cguiadesp + "') AND ((TGUIADESPACHOD.c_estatus='PAG' AND TGUIADESPACHOD.c_cancelaciontot='1') OR (TGUIADESPACHOD.c_estatus='PAG' AND TGUIADESPACHOD.c_cancelaciontot='0')) AND (ISNULL(TGUIADESPACHOD.csinretencion,0)=0) AND (TSALDOCLIENTED.ctipodocument = 'FACT') GROUP BY TCLIENTE.ccliente ,TCLIENTE.c_nomb_comer";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            //Consutamos los Montos Cobrados (por cliente)
            foreach (DataRow row in _Ds.Tables[0].Rows)
            {
                var _Str_ccliente = row["Cliente"].ToString();
                var _Dbl_MontoOriginal = Convert.ToDouble(row["Saldo"]);
                _Str_Cadena = "SELECT SUM((cmontocancelado+cmontoretencion+cmontodescuentos+cmontonotascredito)) As [Monto] FROM VST_RC_COBROSCONTRACAMION_MONTOCOBRADO WHERE cguiacobro='" + _P_Str_cguiadesp + "' AND ccliente = '" + _Str_ccliente + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    var _Dbl_Monto = 0.0;
                    Double.TryParse(_Ds.Tables[0].Rows[0][0].ToString(), out _Dbl_Monto);
                    _Dbl_Monto = Math.Round(_Dbl_Monto, 2);
                    if (_Dbl_Monto > 0)
                    {
                        _Dbl_Saldo = (_Dbl_MontoOriginal - _Dbl_Monto);
                        _Dbl_Saldo = Math.Round(_Dbl_Saldo, 2);
                        if (_Dbl_Saldo >= _Dbl_LimiteFaltante)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;

        }
        public static List<_Cls_CompaniaFactura> _Mtd_ObtenerTodosLosDocumentosSegunGuiaDespacho_EnGuia(string _P_Str_cguiadesp, string _P_Str_cgroupcomp)
        {
            var _oResultado = new List<_Cls_CompaniaFactura>();
            var _Str_Cadena =
                "SELECT TGUIADESPACHOD.ccompany, TGUIADESPACHOD.cfactura, TFACTURAM.ccliente FROM TGUIADESPACHOD INNER JOIN TFACTURAM ON TGUIADESPACHOD.cgroupcomp = TFACTURAM.cgroupcomp AND TGUIADESPACHOD.ccompany = TFACTURAM.ccompany AND TGUIADESPACHOD.cfactura = TFACTURAM.cfactura WHERE (TGUIADESPACHOD.cgroupcomp = '" + _P_Str_cgroupcomp + "') AND (TGUIADESPACHOD.cguiadesp = '" + _P_Str_cguiadesp + "') AND (TFACTURAM.cdelete = 0) AND (TGUIADESPACHOD.c_fact_anul = 0) AND ((TGUIADESPACHOD.c_estatus='PAG' AND TGUIADESPACHOD.c_cancelaciontot='1') OR (TGUIADESPACHOD.c_estatus='PAG' AND TGUIADESPACHOD.c_cancelaciontot='0')) AND (ISNULL(TGUIADESPACHOD.csinretencion,0)=0)";
            var _Ds_Documentos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds_Documentos.Tables[0].Rows)
            {
                var _Str_ccompany = _Row["ccompany"].ToString();
                var _Str_cfactura = _Row["cfactura"].ToString();
                var _Str_ccliente = _Row["ccliente"].ToString();
                var _oItem = new _Cls_CompaniaFactura { ccompany = _Str_ccompany, cfactura = _Str_cfactura, ccliente = _Str_ccliente};
                _oResultado.Add(_oItem);
            }
            return _oResultado;
        }
        public static List<_Cls_CompaniaFactura> _Mtd_ObtenerTodosLosDocumentosSegunGuiaDespacho_EnCobranza(string _P_Str_cguiadesp, string _P_Str_cgroupcomp)
        {
            var _oResultado = new List<_Cls_CompaniaFactura>();
            var _Str_Cadena = "SELECT TRELACCOBD.cnumdocu AS cfactura ,TRELACCOBD.ccliente ,TRELACCOBM.cgroupcomp, TRELACCOBM.ccompany ,TRELACCOBM.cguiacobro FROM TRELACCOBM INNER JOIN TRELACCOBD ON TRELACCOBM.cgroupcomp = TRELACCOBD.cgroupcompany AND TRELACCOBM.ccompany = TRELACCOBD.ccompany AND TRELACCOBM.cidrelacobro = TRELACCOBD.cidrelacobro WHERE (TRELACCOBM.cdelete = 0) AND ( TRELACCOBD.ctipodocument = ( SELECT ctipdocfact FROM TCONFIGCXC WHERE (ccompany = TRELACCOBD.ccompany) ) ) AND (TRELACCOBD.cdelete = 0) AND (TRELACCOBM.cgroupcomp = '" + _P_Str_cgroupcomp + "') AND (TRELACCOBM.cguiacobro = '" + _P_Str_cguiadesp + "')";
            var _Ds_Documentos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds_Documentos.Tables[0].Rows)
            {
                var _Str_ccompany = _Row["ccompany"].ToString();
                var _Str_cfactura = _Row["cfactura"].ToString();
                var _Str_ccliente = _Row["ccliente"].ToString();
                var _oItem = new _Cls_CompaniaFactura { ccompany = _Str_ccompany, cfactura = _Str_cfactura, ccliente = _Str_ccliente };
                _oResultado.Add(_oItem);
            }
            return _oResultado;
        }
        public static bool _Mtd_ValidarTodosDocumentosposteados_GuiaDespacho_Cobranza(string _P_Str_cguiadesp, string _P_Str_cgroupcomp)
        {
            var _Str_Cadena = "SELECT COUNT(cfactura) AS CANTIDAD FROM TGUIADESPACHOD WHERE cgroupcomp = '" + _P_Str_cgroupcomp + "' AND cguiadesp = '" + _P_Str_cguiadesp +
                              "' AND (c_fact_anul = 0) AND ((c_estatus='PAG' AND c_cancelaciontot='1') OR (c_estatus='PAG' AND c_cancelaciontot='0')) AND (ISNULL(csinretencion,0)=0) AND NOT EXISTS ( SELECT TRELACCOBM.cidrelacobro FROM TRELACCOBD INNER JOIN TRELACCOBM ON TRELACCOBD.ccompany = TRELACCOBM.ccompany AND TRELACCOBD.cgroupcompany = TRELACCOBM.cgroupcomp AND TRELACCOBD.cidrelacobro = TRELACCOBM.cidrelacobro WHERE (TRELACCOBM.cgroupcomp = TGUIADESPACHOD.cgroupcomp) AND (TRELACCOBM.ccompany = TGUIADESPACHOD.ccompany) AND (TRELACCOBM.cdelete = '0') AND (cnumdocu = TGUIADESPACHOD.cfactura) AND (Ctipodocument = (SELECT ctipdocfact FROM TCONFIGCXC WHERE ccompany = TRELACCOBD.ccompany)) AND (TRELACCOBM.cguiacobro = TGUIADESPACHOD.cguiadesp))";
            var _Ds_Documentos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            var _Int_Cantidad = Convert.ToInt32(_Ds_Documentos.Tables[0].Rows[0]["Cantidad"]);
            return _Int_Cantidad <= 0;
        }
        public static bool _Mtd_ValidarRelacion(string _P_Str_cidrelacobro, string _P_Str_ccompany, string _P_Str_cgroupcomp, bool _P_MostrarMensajes)
        {
            bool _Bol_Valido = true;
            _Bol_Valido = _Mtd_ValidarNCRelacion(_P_Str_cidrelacobro, _P_Str_ccompany, _P_Str_cgroupcomp, _P_MostrarMensajes);
            if (_Bol_Valido)
            {
                var _Str_SentenciaSQL = "select * from VST_VERIFYRELACOBM where ccompany='" + _P_Str_ccompany + "' and cidrelacobro='" + _P_Str_cidrelacobro + "'";
                var _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    if (_P_MostrarMensajes)
                        MessageBox.Show("Existen depositos y/o cheques en transito sin relacionar", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Bol_Valido = false;
                }
                if (_Bol_Valido)
                {
                    _Str_SentenciaSQL = "EXEC PA_VALIDAR_RELACION_COBRANZA '" + _P_Str_cidrelacobro + "','" + _P_Str_ccompany + "','" + _P_Str_cgroupcomp + "'";
                    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                    if (_Ds_DataSet.Tables[0].Rows[0][0].ToString().Trim().Length > 0)
                    {
                        if (_P_MostrarMensajes)
                            MessageBox.Show(_Ds_DataSet.Tables[0].Rows[0][0].ToString().Trim(), "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Bol_Valido = false;
                    }
                    _Str_SentenciaSQL =
                        "SELECT cnumdepo FROM TRELACCOBDDEPM WHERE (NOT EXISTS (SELECT  cidrelacobro FROM TRELACCOBDDEPD WHERE (TRELACCOBDDEPM.ccompany = ccompany) AND (TRELACCOBDDEPM.cgroupcomp = cgroupcomp) AND (TRELACCOBDDEPM.cidrelacobro = cidrelacobro) AND (TRELACCOBDDEPM.ciddrelacobro_dep = ciddrelacobrodep) AND (TRELACCOBDDEPM.cnumdepo = cnumdepo))) AND TRELACCOBDDEPM.CIDRELACOBRO='" +
                        _P_Str_cidrelacobro + "' AND TRELACCOBDDEPM.CCOMPANY='" + _P_Str_ccompany + "'";
                    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                    if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                    {
                        if (_Ds_DataSet.Tables[0].Rows.Count == 1)
                        {
                            foreach (DataRow _Dtw_Item in _Ds_DataSet.Tables[0].Rows)
                            {
                                if (_P_MostrarMensajes)
                                    MessageBox.Show("Existen 1 deposito incompleto con el numero " + _Dtw_Item["cnumdepo"].ToString().Trim(), "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _Bol_Valido = false;
                            }
                        }
                        else
                        {
                            if (_P_MostrarMensajes)
                                MessageBox.Show("Existen varios depositos incompletos", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Bol_Valido = false;
                        }
                    }
                    _Str_SentenciaSQL = "SELECT cmontodepo,montodetalle FROM VST_VERIFICARDEPOSITOSRELACION WHERE CIDRELACOBRO='" + _P_Str_cidrelacobro + "' and ccompany='" + _P_Str_ccompany + "'";
                    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                    double _Dbl_MontoDeposito = 0;
                    double _Dbl_MontoDetalleDeposito = 0;
                    if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow _Dtw_Item in _Ds_DataSet.Tables[0].Rows)
                        {
                            _Dbl_MontoDeposito = Convert.ToDouble(_Dtw_Item["cmontodepo"].ToString());
                            _Dbl_MontoDetalleDeposito = Convert.ToDouble(_Dtw_Item["montodetalle"].ToString());
                            if (_Dbl_MontoDeposito != _Dbl_MontoDetalleDeposito)
                            {
                                if (_P_MostrarMensajes)
                                    MessageBox.Show("Existe uno o varios depositos en los cuales el monto total no cuadra con su detalle por favor verifique.", "Requerimiento", MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                                _Bol_Valido = false;
                                break;
                            }
                        }
                    }
                }
            }
            return _Bol_Valido;
        }
        private static bool _Mtd_ValidarNCRelacion(string _P_Str_cidrelacobro, string _P_Str_ccompany, string _P_Str_cgroupcomp, bool _P_MostrarMensajes)
        {
            bool _Bol_Valido = true;
            Int32 _Str_IDNC1;
            Int32 _Str_IDNC2;
            Int32 _Str_IDNC3;
            var _Str_SentenciaSQL = "SELECT cnotacred1,cnotacred2,cnotacred3 FROM TRELACCOBD WHERE CIDRELACOBRO='" + _P_Str_cidrelacobro + "' and CCOMPANY='" + _P_Str_ccompany + "' AND cgroupcompany='" +
                                    _P_Str_cgroupcomp + "'";
            var _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
            foreach (DataRow _Dtw_Item in _Ds_DataSet.Tables[0].Rows)
            {
                _Str_IDNC1 = Convert.ToInt32(_Dtw_Item["cnotacred1"].ToString() == "" ? "0" : _Dtw_Item["cnotacred1"]);
                _Str_IDNC2 = Convert.ToInt32(_Dtw_Item["cnotacred2"].ToString() == "" ? "0" : _Dtw_Item["cnotacred2"]);
                _Str_IDNC3 = Convert.ToInt32(_Dtw_Item["cnotacred3"].ToString() == "" ? "0" : _Dtw_Item["cnotacred3"]);
                _Bol_Valido = _Mtd_ValidarNCAnuladas(_Str_IDNC1, _P_Str_ccompany, _P_Str_cgroupcomp);
                if (!_Bol_Valido)
                {
                    if (_P_MostrarMensajes)
                        MessageBox.Show("La NC " + _Str_IDNC1 + " se encuentra anulada debe eliminar el documento en el cual esta aplicada en la presente relacion de cobranza", "Requerimiento", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;
                }
                _Bol_Valido = _Mtd_ValidarNCAnuladas(_Str_IDNC2, _P_Str_ccompany, _P_Str_cgroupcomp);
                if (!_Bol_Valido)
                {
                    if (_P_MostrarMensajes)
                        MessageBox.Show("La NC " + _Str_IDNC2 + " se encuentra anulada debe eliminar el documento en el cual esta aplicada en la presente relacion de cobranza", "Requerimiento", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;
                }
                _Bol_Valido = _Mtd_ValidarNCAnuladas(_Str_IDNC3, _P_Str_ccompany, _P_Str_cgroupcomp);
                if (!_Bol_Valido)
                {
                    if (_P_MostrarMensajes)
                        MessageBox.Show("La NC " + _Str_IDNC3 + " se encuentra anulada debe eliminar el documento en el cual esta aplicada en la presente relacion de cobranza", "Requerimiento", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;
                }
            }
            return _Bol_Valido;
        }
        private static bool _Mtd_ValidarNCAnuladas(int _Str_IDNC, string _P_Str_ccompany, string _P_Str_cgroupcompany)
        {
            bool _Bol_Valido = true;
            if (_Str_IDNC > 0)
            {
                try
                {
                    var _Str_SentenciaSQL = "SELECT canulado from TNOTACREDICC WHERE CCOMPANY='" + _P_Str_ccompany + "' AND cidnotcredicc='" + _Str_IDNC + "' AND cgroupcomp='" + _P_Str_cgroupcompany +
                                            "' AND canulado='1'";
                    var _Ds_Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                    if (_Ds_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Bol_Valido = false;
                    }
                }
                catch
                {
                    _Bol_Valido = true;
                }
            }
            return _Bol_Valido;
        }

        #endregion

        #region Rutinas Privadas de Validación nueva de guia y relaciones de cobranza

        public static List<_Cls_PagoCliente> _Mtd_ObtenerTodosLosPagosSegunGuiaYCompania_EnGuia(string _P_Str_cgroupcomp, string _P_Str_ccompany, string _P_Str_cguiadesp)
        {
            var _oResultado = new List<_Cls_PagoCliente>();
            var _Str_Cadena = "SELECT TTRCPAGOM.cidpago, TTRCPAGOM.ccliente  " +
                              "FROM TTRCPAGOM " +
                              "WHERE (TTRCPAGOM.ccompany = '" + _P_Str_ccompany + "') AND (TTRCPAGOM.cguia = '" + _P_Str_cguiadesp + "') AND (TTRCPAGOM.cdelete = 0) " +
                              "ORDER BY TTRCPAGOM.cidpago ";
            var _Ds_Documentos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds_Documentos.Tables[0].Rows)
            {
                var _Str_cidpago = Convert.ToInt32(_Row["cidpago"]);
                var _Str_ccliente = Convert.ToInt32(_Row["ccliente"]);
                var _oPagoCliente = new _Cls_PagoCliente() { cidpago = _Str_cidpago.ToString(CultureInfo.InvariantCulture), ccliente = _Str_ccliente.ToString(CultureInfo.InvariantCulture) };
                _oResultado.Add(_oPagoCliente);
            }
            return _oResultado;
        }
        public static List<_Cls_CompaniaFactura> _Mtd_ObtenerTodosLosDocumentosSegunGuiaYCompania_EnGuia(string _P_Str_cgroupcomp, string _P_Str_ccompany, string _P_Str_cguiadesp)
        {
            var _oResultado = new List<_Cls_CompaniaFactura>();
            var _Str_Cadena = "SELECT TGUIADESPACHOD.ccompany, TGUIADESPACHOD.cfactura, TFACTURAM.ccliente, (TFACTURAM.c_montotot_si_bs + TFACTURAM.c_impuesto_bs) as cmontototal " +
                              "FROM TGUIADESPACHOD INNER JOIN TFACTURAM ON TGUIADESPACHOD.cgroupcomp = TFACTURAM.cgroupcomp AND TGUIADESPACHOD.ccompany = TFACTURAM.ccompany AND TGUIADESPACHOD.cfactura = TFACTURAM.cfactura " +
                              "WHERE (TGUIADESPACHOD.cgroupcomp = '" + _P_Str_cgroupcomp + "') AND (TGUIADESPACHOD.ccompany = '" + _P_Str_ccompany + "') AND (TGUIADESPACHOD.cguiadesp = '" + _P_Str_cguiadesp + "') " +
                              "AND (TFACTURAM.cdelete = 0) AND (TGUIADESPACHOD.c_fact_anul = 0) " +
                              "AND ((TGUIADESPACHOD.c_estatus='PAG' AND TGUIADESPACHOD.c_cancelaciontot='1') OR (TGUIADESPACHOD.c_estatus='PAG' AND TGUIADESPACHOD.c_cancelaciontot='0')) AND (ISNULL(TGUIADESPACHOD.csinretencion,0)=0)";
            var _Ds_Documentos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds_Documentos.Tables[0].Rows)
            {
                var _Str_ccompany = _Row["ccompany"].ToString();
                var _Str_cfactura = _Row["cfactura"].ToString();
                var _Str_ccliente = _Row["ccliente"].ToString();
                var _Dbl_cmontototal = Convert.ToDouble(_Row["cmontototal"]);
                var _oItem = new _Cls_CompaniaFactura { ccompany = _Str_ccompany, cfactura = _Str_cfactura, ccliente = _Str_ccliente, cmontototal = _Dbl_cmontototal };
                _oResultado.Add(_oItem);
            }
            return _oResultado;
        }
        private static double _Mtd_ObtenerMontoCanceladoDocumento(string _P_Str_cgroupcompany, string _P_Str_ccompany, string _P_Str_cidrelacobro, string _P_Str_ccliente, string _P_Str_cnumdocu)
        {
            double _Dbl_Resultado = 0;
            var _Str_Cadena = "SELECT cmontocancel as cmontotal " +
                              "FROM TRELACCOBD  " +
                              "WHERE (TRELACCOBD.cdelete = 0) " +
                              "AND (TRELACCOBD.cgroupcompany = '" + _P_Str_cgroupcompany + "') AND (TRELACCOBD.ccompany = '" + _P_Str_ccompany + "')  AND (TRELACCOBD.cidrelacobro = '" + _P_Str_cidrelacobro + "') " + 
                              "AND (TRELACCOBD.ccliente = '" + _P_Str_ccliente + "') AND (TRELACCOBD.cnumdocu = '" + _P_Str_cnumdocu + "') AND (TRELACCOBD.ctipodocument = 'FACT')";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                double.TryParse(_Ds.Tables[0].Rows[0][0].ToString(), out _Dbl_Resultado);
            }
            return _Dbl_Resultado;
        }
        private static double _Mtd_ObtenerMontoCanceladoDocumentoDesdeElDetalle(string _P_Str_cgroupcompany, string _P_Str_ccompany, string _P_Str_cidrelacobro, string _P_Str_ccliente, string _P_Str_cnumdocu)
        {
            double _Dbl_Resultado = 0;
            var _Str_Cadena = "SELECT SUM(cmontodeefectivo) as cmontotal  " +
                              "FROM TRELACCOBDD  " +
                              "WHERE  " +
                              "(TRELACCOBDD.cgroupcomp = '" + _P_Str_cgroupcompany + "') AND (TRELACCOBDD.ccompany = '" + _P_Str_ccompany + "')  AND (TRELACCOBDD.cidrelacobro = '" + _P_Str_cidrelacobro + "') " +
                              "AND (TRELACCOBDD.cnumdocu = '" + _P_Str_cnumdocu + "') AND (TRELACCOBDD.ctipodocument = 'FACT') " +
                              "GROUP BY TRELACCOBDD.cgroupcomp, TRELACCOBDD.ccompany, TRELACCOBDD.cidrelacobro, TRELACCOBDD.cnumdocu, TRELACCOBDD.ctipodocument ";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                double.TryParse(_Ds.Tables[0].Rows[0][0].ToString(), out _Dbl_Resultado);
            }
            return _Dbl_Resultado;
        }
        private static double _Mtd_ObtenerMontoNCDocumento(string _P_Str_cgroupcompany, string _P_Str_ccompany, string _P_Str_cidrelacobro, string _P_Str_ccliente, string _P_Str_cnumdocu)
        {
            double _Dbl_Acumulado = 0;
            double _Dbl_Resultado = 0;
            //Nc1
            var _Str_Cadena = "SELECT TNOTACREDICC.ctotaldocu as MontoTotal " +
                              "FROM TRELACCOBD INNER JOIN TNOTACREDICC ON TRELACCOBD.cgroupcompany = TNOTACREDICC.cgroupcomp AND TRELACCOBD.ccompany = TNOTACREDICC.ccompany AND TRELACCOBD.ccliente = TNOTACREDICC.ccliente AND TRELACCOBD.cnotacred1 = TNOTACREDICC.cidnotcredicc " +
                              "WHERE (TNOTACREDICC.cdelete = 0) AND (TRELACCOBD.cdelete = 0) AND (TNOTACREDICC.cactivo = 1) " +
                              "AND (TRELACCOBD.cgroupcompany = '" + _P_Str_cgroupcompany + "') AND (TRELACCOBD.ccompany = '" + _P_Str_ccompany + "')  AND (TRELACCOBD.cidrelacobro = '" + _P_Str_cidrelacobro + "') " +
                              "AND (TRELACCOBD.ccliente = '" + _P_Str_ccliente + "') AND (TRELACCOBD.cnumdocu = '" + _P_Str_cnumdocu + "') AND (TRELACCOBD.ctipodocument = 'FACT')";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                double.TryParse(_Ds.Tables[0].Rows[0][0].ToString(), out _Dbl_Resultado);
                _Dbl_Acumulado += _Dbl_Resultado;
            }
            //Nc2
            _Str_Cadena = "SELECT TNOTACREDICC.ctotaldocu as MontoTotal " +
                              "FROM TRELACCOBD INNER JOIN TNOTACREDICC ON TRELACCOBD.cgroupcompany = TNOTACREDICC.cgroupcomp AND TRELACCOBD.ccompany = TNOTACREDICC.ccompany AND TRELACCOBD.ccliente = TNOTACREDICC.ccliente AND TRELACCOBD.cnotacred2 = TNOTACREDICC.cidnotcredicc " +
                              "WHERE (TNOTACREDICC.cdelete = 0) AND (TRELACCOBD.cdelete = 0) AND (TNOTACREDICC.cactivo = 1) " +
                              "AND (TRELACCOBD.cgroupcompany = '" + _P_Str_cgroupcompany + "') AND (TRELACCOBD.ccompany = '" + _P_Str_ccompany + "')  AND (TRELACCOBD.cidrelacobro = '" + _P_Str_cidrelacobro + "') " +
                              "AND (TRELACCOBD.ccliente = '" + _P_Str_ccliente + "') AND (TRELACCOBD.cnumdocu = '" + _P_Str_cnumdocu + "') AND (TRELACCOBD.ctipodocument = 'FACT')";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                double.TryParse(_Ds.Tables[0].Rows[0][0].ToString(), out _Dbl_Resultado);
                _Dbl_Acumulado += _Dbl_Resultado;
            }
            //Nc3
            _Str_Cadena = "SELECT TNOTACREDICC.ctotaldocu as MontoTotal " +
                              "FROM TRELACCOBD INNER JOIN TNOTACREDICC ON TRELACCOBD.cgroupcompany = TNOTACREDICC.cgroupcomp AND TRELACCOBD.ccompany = TNOTACREDICC.ccompany AND TRELACCOBD.ccliente = TNOTACREDICC.ccliente AND TRELACCOBD.cnotacred3 = TNOTACREDICC.cidnotcredicc " +
                              "WHERE (TNOTACREDICC.cdelete = 0) AND (TRELACCOBD.cdelete = 0) AND (TNOTACREDICC.cactivo = 1) " +
                              "AND (TRELACCOBD.cgroupcompany = '" + _P_Str_cgroupcompany + "') AND (TRELACCOBD.ccompany = '" + _P_Str_ccompany + "')  AND (TRELACCOBD.cidrelacobro = '" + _P_Str_cidrelacobro + "') " +
                              "AND (TRELACCOBD.ccliente = '" + _P_Str_ccliente + "') AND (TRELACCOBD.cnumdocu = '" + _P_Str_cnumdocu + "') AND (TRELACCOBD.ctipodocument = 'FACT')";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                double.TryParse(_Ds.Tables[0].Rows[0][0].ToString(), out _Dbl_Resultado);
                _Dbl_Acumulado += _Dbl_Resultado;
            }
            return _Dbl_Acumulado;
        }
        private static double _Mtd_ObtenerMontoRetencionesDocumento(string _P_Str_cgroupcompany, string _P_Str_ccompany, string _P_Str_cidrelacobro, string _P_Str_ccliente, string _P_Str_cnumdocu)
        {
            double _Dbl_Resultado = 0;
            var _Str_Cadena = "SELECT cmontcompretiva " +
                              "FROM TRELACCOBD  " +
                              "WHERE (TRELACCOBD.cdelete = 0) " +
                              "AND (TRELACCOBD.cgroupcompany = '" + _P_Str_cgroupcompany + "') AND (TRELACCOBD.ccompany = '" + _P_Str_ccompany + "')  AND (TRELACCOBD.cidrelacobro = '" + _P_Str_cidrelacobro + "') " +
                              "AND (TRELACCOBD.ccliente = '" + _P_Str_ccliente + "') AND (TRELACCOBD.cnumdocu = '" + _P_Str_cnumdocu + "') AND (TRELACCOBD.ctipodocument = 'FACT') " +
                              "AND (cretencioniva = '1')";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                double.TryParse(_Ds.Tables[0].Rows[0][0].ToString(), out _Dbl_Resultado);
            }
            return _Dbl_Resultado;
        }

        #endregion


    }

    public class _Cls_PagoCliente
    {
        public string cidpago { get; set; }
        public string ccliente { get; set; }
    }
    public class _Cls_CompaniaFactura
    {
        public string ccompany { get; set; }
        public string cfactura { get; set; }
        public string ccliente { get; set; }
        public double cmontototal { get; set; }
    }
    public class _Cls_ChequesEntransito
    {
        public string cgroupcompany { get; set; }
        public string ccompany { get; set; }
        public string cnumcheque { get; set; }
        public string ccliente { get; set; }
        public string cbancocheque { get; set; }
        public string ciddrelacobro_cheq { get; set; }
    }
    public class _Cls_Documentos
    {
        public string cgroupcompany { get; set; }
        public string ccompany { get; set; }
        public string cnumdocu { get; set; }
        public string ccliente { get; set; }
        public string cvendedor { get; set; }
    }
    public class _Cls_ChequesDepositados
    {
        public string cgroupcompany { get; set; }
        public string ccompany { get; set; }
        public string cnumdepo { get; set; }
        public string cnumcheque { get; set; }
        public string ccliente { get; set; }
        public string cbancocheque { get; set; }
        public string ciddrelacobrodep { get; set; }
        public string ciddrelacobro_depd { get; set; }


        
    }



}