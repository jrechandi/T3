using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using clslibraryconssa;
using LibNumLetras;
using T3.CLASES;
using T3.Clases;

namespace T3
{
    public partial class Frm_IC_GeneracionOP : Form
    {

        private void _Mtd_Sorted(DataGridView _P_Dg_Grid)
        {
            for (int _Int_i = 0; _Int_i < _P_Dg_Grid.Columns.Count; _Int_i++)
            {
                _P_Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        //----------------------------------------------------------------------------------------------------------
        //  Atributos.
        //----------------------------------------------------------------------------------------------------------

        private string _G_Str_Proveedor;

        private string[] _G_Str_Tipos;
        private string[] _G_Str_Documentos;

        private _Cls_Formato _Obj_Formato = new _Cls_Formato("es-VE");
        private clsNumerosaLetras _Obj_Convertir = new clsNumerosaLetras();
        private _Cls_Varios_Metodos _Obj_Utilidad = new _Cls_Varios_Metodos(true);
        private _Cls_ProcesosCont _Obj_Proceso = new _Cls_ProcesosCont("P_BCO_CHQ_CIARELPAGO");

        //----------------------------------------------------------------------------------------------------------
        //  Métodos.
        //----------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Método para calcular el total del comprobante debe o haber.
        /// </summary>
        /// <param name="_P_Int_Indice">Indice de la columna del debe o del haber.</param>
        /// <returns>Monto total del comprobante.</returns>
        private string _Mtd_TotalComprobante(int _P_Int_Indice)
        {
            double _Dbl_Total = 0;

            foreach (DataGridViewRow _Obj_Fila in _Dtg_Comprobante.Rows)
            {
                //Excepto la Linea de Totales
                if (_Obj_Fila.Cells[2].Value != "Total:")
                {
                    if (_Obj_Fila.Cells[_P_Int_Indice].Value != "")
                    {
                        _Dbl_Total += Convert.ToDouble(_Obj_Fila.Cells[_P_Int_Indice].Value);
                    }
                }
            }

            return _Dbl_Total.ToString("#,##0.00");
        }

        /// <summary>
        /// Método para verificar si los documentos no está en otra orden de pago.
        /// </summary>
        /// <returns>Verdadero si los documentos no están en otra orden de pago.</returns>
        private bool _Mtd_VerificarTotalDocumentos()
        {
            string _Str_SQL;
            string _Str_Tipo = "";

            DataSet _Obj_Resultados;

            foreach (DataGridViewRow _Obj_Fila in _Dtg_Documentos.Rows)
            {
                _Str_SQL = "SELECT TPAGOSCXPM.cidordpago FROM  TPAGOSCXPD INNER JOIN TPAGOSCXPM ON TPAGOSCXPD.cidordpago = TPAGOSCXPM.cidordpago AND TPAGOSCXPD.cgroupcomp = TPAGOSCXPM.cgroupcomp AND TPAGOSCXPD.ccompany = TPAGOSCXPM.ccompany ";

                //Convierto el tipo de documento de largo a corto . ignacio 22/05/2013
                _Str_Tipo = _Mtd_ConvertirTipoDocumentoDeLargoACorto(_Obj_Fila.Cells[3].Value.ToString());

                _Str_SQL += " WHERE (TPAGOSCXPD.ctipodocument = '" + _Str_Tipo + "' AND TPAGOSCXPD.cnumdocu = '" + _Obj_Fila.Cells[2].Value + "' AND TPAGOSCXPM.canulado = 0 AND TPAGOSCXPM.cproveedor = '" + _G_Str_Proveedor.Trim() + "' )";

                _Obj_Resultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                if (_Obj_Resultados.Tables[0].Rows.Count > 0)
                {
                    string _Str_Advertencia;

                    _Str_Advertencia = "El siguiente documento ya se encuentra en la orden de pago";
                    _Str_Advertencia += " N° " + _Obj_Resultados.Tables[0].Rows[0]["cidordpago"] + ".";
                    _Str_Advertencia += " Por favor verifique: " + _Obj_Fila.Cells[3].Value + ", N° " + _Obj_Fila.Cells[2].Value + ".";

                    MessageBox.Show(_Str_Advertencia, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Método para generar el comprobante contable.
        /// </summary>
        /// <returns>Número de comprobante.</returns>
        private int _Mtd_GenerarComprobante()
        {
            string _Str_SQL;
            string _Str_Concepto;
            string _Str_Tipo;

            int _Int_Comprobante;

            _Int_Comprobante = _Obj_Utilidad._Mtd_Consecutivo_TCOMPROBANC();
            _Str_Concepto = _Obj_Proceso._Field_ConceptoComprobante;
            _Str_Tipo = _Obj_Proceso._Field_TipoComprobante;

            _Str_SQL = "INSERT INTO TCOMPROBANC (";
            _Str_SQL += " ccompany,";
            _Str_SQL += " cidcomprob,";
            _Str_SQL += " ctypcomp,";
            _Str_SQL += " cname,";
            _Str_SQL += " cyearacco,";
            _Str_SQL += " cmontacco,";
            _Str_SQL += " cregdate,";
            _Str_SQL += " ctotdebe,";
            _Str_SQL += " ctothaber,";
            _Str_SQL += " cbalance,";
            _Str_SQL += " cdateadd,";
            _Str_SQL += " cuseradd,";
            _Str_SQL += " clvalidado,";
            _Str_SQL += " cstatus";
            _Str_SQL += ") VALUES (";
            _Str_SQL += " '" + Frm_Padre._Str_Comp + "',";
            _Str_SQL += " '" + _Int_Comprobante + "',";
            _Str_SQL += " '" + _Str_Tipo + "',";
            _Str_SQL += " '" + _Str_Concepto + "',";
            _Str_SQL += " '" + _Cls_ProcesosCont._Mtd_ContableAno(_Obj_Formato._Mtd_fecha(_Cls_Varios_Metodos._Mtd_SQLGetDate())) + "',";
            _Str_SQL += " '" + _Cls_ProcesosCont._Mtd_ContableMes(_Obj_Formato._Mtd_fecha(_Cls_Varios_Metodos._Mtd_SQLGetDate())) + "',";
            _Str_SQL += " '" + _Obj_Formato._Mtd_fecha(_Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',";
            _Str_SQL += " '" + _Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Mtd_TotalComprobante(3))) + "',";
            _Str_SQL += " '" + _Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Mtd_TotalComprobante(4))) + "',";
            _Str_SQL += " '0', GETDATE(), '" + Frm_Padre._Str_Use + "', '1', '9');";

            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _Int_Comprobante.ToString());
            foreach (DataGridViewRow _Obj_Fila in _Dtg_Comprobante.Rows)
            {

                // determina el indice de la ultima fila del grid
                // esta fila tiene solamente ´totales´, y no se inserta en la BD
                int _Int_IndiceUltimaFila = _Dtg_Comprobante.Rows.Count - 1;

                // inserta todas las filas, excepto la ultima
                if (_Obj_Fila.Index < _Int_IndiceUltimaFila)
                {
                    _Str_SQL = "INSERT INTO TCOMPROBAND (";
                    _Str_SQL += " ccompany,";
                    _Str_SQL += " cidcomprob,";
                    _Str_SQL += " corder,";
                    _Str_SQL += " ccount,";
                    _Str_SQL += " ctdocument,";
                    _Str_SQL += " cnumdocu,";
                    _Str_SQL += " cdatedocu,";
                    _Str_SQL += " ctotdebe,";
                    _Str_SQL += " ctothaber,";
                    _Str_SQL += " cdateadd,";
                    _Str_SQL += " cuseradd,";
                    _Str_SQL += " cdescrip";
                    _Str_SQL += ") VALUES (";
                    _Str_SQL += " '" + Frm_Padre._Str_Comp.Trim() + "',";
                    _Str_SQL += " " + _Int_Comprobante + ",";
                    _Str_SQL += " " + _Obj_Fila.Cells[5].Value + ",";
                    _Str_SQL += " '" + _Obj_Fila.Cells[0].Value + "',";
                    _Str_SQL += " '" + _Obj_Fila.Cells["_Dtg_Vista_TipoDocumentoCorto"].Value + "',";
                    _Str_SQL += " '" + _Obj_Fila.Cells[7].Value + "',";
                    _Str_SQL += " CONVERT(DATETIME, '" + _Obj_Formato._Mtd_fecha(Convert.ToDateTime(_Obj_Fila.Cells[8].Value)) + "', 103),";

                    if (_Obj_Fila.Cells[3].Value != "")
                    {
                        _Str_SQL += " " + _Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Obj_Fila.Cells[3].Value)) + ", ";
                    }
                    else
                    {
                        _Str_SQL += " 0, ";
                    }
                    if (_Obj_Fila.Cells[4].Value != "")
                    {
                        _Str_SQL += " " + _Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Obj_Fila.Cells[4].Value)) + ", ";
                    }
                    else
                    {
                        _Str_SQL += " 0, ";
                    }

                    _Str_SQL += " GETDATE(), '" + Frm_Padre._Str_Use + "', '" + _Obj_Fila.Cells[2].Value + "');";

                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

                    /*
                     *  Guardamos el comprobante auxiliar. 
                     */

                    string _Str_NaturalezaAuxiliar = "";
                    string _Str_CodigoCuentaContableAuxiliar = _Obj_Fila.Cells[0].Value.ToString().Trim();

                    string _Str_MontoAuxiliar = "";

                    // dependiendo de si el monto esta por el debe o por el haber, saca el monto de una columna diferente
                    if (_Obj_Fila.Cells[3].Value != "")
                    {
                        _Str_MontoAuxiliar = _Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Obj_Fila.Cells[3].Value));
                        _Str_NaturalezaAuxiliar = "D";
                    }
                    if (_Obj_Fila.Cells[4].Value != "")
                    {
                        _Str_MontoAuxiliar = _Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Obj_Fila.Cells[4].Value));
                        _Str_NaturalezaAuxiliar = "H";
                    }


                    _Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_Int_Comprobante.ToString(),
                                                                _Str_CodigoCuentaContableAuxiliar,
                                                                _G_Str_Proveedor.Trim(),
                                                                _Obj_Fila.Cells[2].Value.ToString().Trim().ToUpper(),
                                                                _Obj_Fila.Cells["_Dtg_Vista_TipoDocumentoCorto"].Value.ToString().Trim(),
                                                                _Obj_Fila.Cells[7].Value.ToString().Trim(),
                                                                _Obj_Formato._Mtd_fecha(Convert.ToDateTime(_Obj_Fila.Cells[8].Value)),
                                                                _Obj_Formato._Mtd_fecha(Convert.ToDateTime(_Obj_Fila.Cells[9].Value)),
                                                                _Str_MontoAuxiliar,
                                                                _Cls_ProcesosCont._Mtd_ContableMes(_Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()),
                                                                _Cls_ProcesosCont._Mtd_ContableAno(_Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()),
                                                                _Str_NaturalezaAuxiliar);
                }
            }

            return _Int_Comprobante;
        }

        /// <summary>
        /// Método para generar la orden de pago.
        /// </summary>
        private void _Mtd_GenerarOrdenPago()
        {
            string _Str_SQL;
            string _Str_Id;
            string _Str_Rif;
            string _Str_Total;
            string _Str_Tipo = "";

            int _Str_Comprobante;

            DataSet _Obj_Resultados;

            /*
             *  Después de obtener la última orden de pago, se inserta el 
             *  encabezado de la nueva en la tabla TPAGOSCXPM.
             */

            _Str_SQL = "SELECT MAX(cidordpago) AS cmaximo FROM TPAGOSCXPM;";
            _Obj_Resultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            _Str_Id = _Obj_Resultados.Tables[0].Rows[0]["cmaximo"].ToString();

            _Str_SQL = "SELECT c_rif FROM TCLIENTE WHERE c_nomb_comer = '" + _Mtd_ObtenerCliente() + "';";
            _Obj_Resultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            _Str_Rif = _Obj_Resultados.Tables[0].Rows[0]["c_rif"].ToString();

            _Str_Comprobante = _Mtd_GenerarComprobante();

            _Str_Total = _Mtd_CalcularTotal().ToString();

            _Str_SQL = "INSERT INTO TPAGOSCXPM (";
            _Str_SQL += " cgroupcomp,";
            _Str_SQL += " ccompany,";
            _Str_SQL += " cidordpago,";
            _Str_SQL += " cproveedor,";
            _Str_SQL += " ctippago,";
            _Str_SQL += " cfpago,";
            _Str_SQL += " cfecha,";
            _Str_SQL += " cuserfirmante,";
            _Str_SQL += " cmontototal,";
            _Str_SQL += " cdescpppago,";
            _Str_SQL += " cbanco,";
            _Str_SQL += " ccaja,";
            _Str_SQL += " cnumcuentad,";
            _Str_SQL += " ccancelado,";
            _Str_SQL += " canulado,";
            _Str_SQL += " cidemisioncheq,";
            _Str_SQL += " cidemisioncaja,";
            _Str_SQL += " cmontototaltext,";
            _Str_SQL += " cidcomprob,";
            _Str_SQL += " cotrospago,";
            _Str_SQL += " cconcepto,";
            _Str_SQL += " cbeneficiario,";
            _Str_SQL += " ctipotrospago,";
            _Str_SQL += " antidescontado,";
            _Str_SQL += " cidordpagodesc,";
            _Str_SQL += " crif";
            _Str_SQL += ") VALUES (";
            _Str_SQL += "'" + Frm_Padre._Str_GroupComp + "',";
            _Str_SQL += " '" + Frm_Padre._Str_Comp + "',";
            _Str_SQL += " '" + (Convert.ToInt32(_Str_Id) + 1) + "',";
            _Str_SQL += " '" + _G_Str_Proveedor + "',";
            _Str_SQL += " 'PTOT',";

            if (_Chk_Cheque.Checked)
            {
                _Str_SQL += " 'CHEQ',";
            }
            else
            {
                _Str_SQL += " 'TRANSF',";
            }

            _Str_SQL += " '" + _Obj_Formato._Mtd_fecha(_Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',";
            _Str_SQL += " '" + Frm_Padre._Str_Use.Trim() + "',";
            _Str_SQL += " '" + _Str_Total.Replace(".", "").Replace(",", ".") + "', 0,";
            _Str_SQL += " '" + _Cmb_Banco.SelectedValue + "', null,";
            _Str_SQL += " '" + _Cmb_Cuenta.SelectedValue + "', 0, 0, 0, 0,";
            _Str_SQL += " '" + _Obj_Convertir.Numero2Letra(_Str_Total.Replace(".", ""), 0, 2, "", "Céntimo", clsNumerosaLetras.eSexo.Masculino).ToUpper() + "',";
            _Str_SQL += " '" + _Str_Comprobante + "', '0', 'PAGO A COMPAÑÍA RELACIONADA " + _Lbl_Proveedor.Text + "', ";
            _Str_SQL += " '" + _Lbl_Proveedor.Text + "', 0, 0, 0, '" + _Str_Rif + "');";

            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);

            /*
             *  Dependiendo del tipo de documento, el detalle de la orden de pago
             *  tendrá dos detalles, un para cuentas por pagar en TPAGOSCXPD y para
             *  cuentas por cobrar TPAGOSCXCD.
             */

            foreach (DataGridViewRow _Obj_Fila in _Dtg_Documentos.Rows)
            {
                if (_Obj_Fila.Index < _Dtg_Documentos.Rows.Count)
                {

                    //Convierto el tipo de documento de largo a corto . ignacio 22/05/2013
                    _Str_Tipo = _Mtd_ConvertirTipoDocumentoDeLargoACorto(_Obj_Fila.Cells[3].Value.ToString());

                    switch (_Obj_Fila.Cells[3].Value.ToString())
                    {
                        case "FACTURA CXC":
                        case "NOTA DE DEBITO CXC":
                        case "NOTA DE CREDITO CXC":
                        case "AVISO DE COBRO CXC":

                            _Str_SQL = "INSERT INTO TPAGOSCXCD (";
                            _Str_SQL += " ccompany,";
                            _Str_SQL += " cidordpago,";
                            _Str_SQL += " cnumdocu,";
                            _Str_SQL += " ctipodocument,";
                            _Str_SQL += " cmontodocu,";
                            _Str_SQL += " cfechaemision,";
                            _Str_SQL += " cfechavencimiento,";
                            _Str_SQL += " cdateadd,";
                            _Str_SQL += " cuseradd";

                            break;

                        case "NOTA DE DEBITO CXP":
                        case "NOTA DE CREDITO PROVEEDOR CXP":
                        case "FACTURA CXP":
                        case "NOTA DE CREDITO CXP":
                        case "NOTA DE DEBITO PROVEEDOR CXP":
                        case "AVISO DE COBRO CXP":

                            _Str_SQL = "INSERT INTO TPAGOSCXPD (";
                            _Str_SQL += " cgroupcomp,";
                            _Str_SQL += " ccompany,";
                            _Str_SQL += " cidordpago,";
                            _Str_SQL += " cproveedor,";
                            _Str_SQL += " cnumdocu,";
                            _Str_SQL += " ctipodocument,";
                            _Str_SQL += " cfechaemision,";
                            _Str_SQL += " cfechavencimiento,";
                            _Str_SQL += " cmontodocu,";
                            _Str_SQL += " cmontocancelar,";
                            _Str_SQL += " cmontoimp,";
                            _Str_SQL += " cidescuentoppp,";
                            _Str_SQL += " cmontoddpp,";
                            _Str_SQL += " cncppp";

                            break;
                    }

                    _Str_SQL += ") VALUES (";

                    double _Dbl_Monto = 0;
                    switch (_Obj_Fila.Cells[3].Value.ToString())
                    {
                        case "FACTURA CXC":
                        case "NOTA DE DEBITO CXC":
                        case "NOTA DE CREDITO CXC":
                        case "AVISO DE COBRO CXC":

                            //Se le quita el signo . Ignacio 23/05/2013
                            _Dbl_Monto = Convert.ToDouble(Convert.ToString(_Obj_Fila.Cells[4].Value).Replace("-", ""));

                            _Str_SQL += " '" + Frm_Padre._Str_Comp + "',";
                            _Str_SQL += " '" + (Convert.ToInt32(_Str_Id) + 1) + "',";
                            _Str_SQL += " '" + _Obj_Fila.Cells[2].Value + "',";
                            _Str_SQL += " '" + _Str_Tipo + "',";
                            _Str_SQL += " " + _Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Dbl_Monto)) + ",";
                            _Str_SQL += " CONVERT(DATETIME, '" + Convert.ToDateTime(_Obj_Fila.Cells[0].Value).ToShortDateString() + "', 103),";
                            _Str_SQL += " CONVERT(DATETIME, '" + Convert.ToDateTime(_Obj_Fila.Cells[1].Value).ToShortDateString() + "', 103),";
                            _Str_SQL += " GETDATE(),";
                            _Str_SQL += " '" + Frm_Padre._Str_Use + "'";

                            break;

                        case "NOTA DE DEBITO CXP":
                        case "NOTA DE CREDITO PROVEEDOR CXP":
                        case "FACTURA CXP":
                        case "NOTA DE CREDITO CXP":
                        case "NOTA DE DEBITO PROVEEDOR CXP":
                        case "AVISO DE COBRO CXP":

                            //Se le quita el signo . Ignacio 23/05/2013
                            _Dbl_Monto = Convert.ToDouble(Convert.ToString(_Obj_Fila.Cells[4].Value).Replace("-", ""));

                            _Str_SQL += "'" + Frm_Padre._Str_GroupComp + "',";
                            _Str_SQL += " '" + Frm_Padre._Str_Comp + "',";
                            _Str_SQL += " '" + (Convert.ToInt32(_Str_Id) + 1) + "',";
                            _Str_SQL += " '" + _G_Str_Proveedor + "',";
                            _Str_SQL += " '" + _Obj_Fila.Cells[2].Value + "',";
                            _Str_SQL += " '" + _Str_Tipo + "',";
                            _Str_SQL += " CONVERT(DATETIME, '" + Convert.ToDateTime(_Obj_Fila.Cells[0].Value).ToShortDateString() + "', 103),";
                            _Str_SQL += " CONVERT(DATETIME, '" + Convert.ToDateTime(_Obj_Fila.Cells[1].Value).ToShortDateString() + "', 103),";
                            _Str_SQL += " " + _Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Dbl_Monto)) + ",";
                            _Str_SQL += " " + _Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Dbl_Monto)) + ",";
                            _Str_SQL += " 0, NULL, 0, NULL";

                            break;
                    }

                    _Str_SQL += ");";

                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                }
            }
        }

        /// <summary>
        /// Método para obtener el cliente del documento.
        /// </summary>
        /// <returns>Nombre comercial del cliente.</returns>
        private string _Mtd_ObtenerCliente()
        {
            string _Str_SQL;

            DataSet _Obj_Resultados;

            _Str_SQL = "SELECT TCLIENTE.c_nomb_comer FROM TICRELAPROCLI";
            _Str_SQL += " INNER JOIN TCLIENTE ON TICRELAPROCLI.ccliente = TCLIENTE.ccliente";
            _Str_SQL += " WHERE TICRELAPROCLI.cproveedor = '" + _G_Str_Proveedor + "';";

            _Obj_Resultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            return _Obj_Resultados.Tables[0].Rows[0]["c_nomb_comer"].ToString();
        }

        /// <summary>
        /// Método para obtener el proveedor de la orden de pago.
        /// </summary>
        /// <returns>Nombre comercial del proveedor.</returns>
        private string _Mtd_ObtenerProveedor()
        {
            string _Str_SQL;

            DataSet _Obj_Resultados;

            _Str_SQL = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE cproveedor = '" + _G_Str_Proveedor + "';";

            _Obj_Resultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            return _Obj_Resultados.Tables[0].Rows[0]["c_nomb_comer"].ToString();
        }

        /// <summary>
        /// Método para obtener la cuenta contable del banco.
        /// </summary>
        /// <returns>Número de la cuenta del banco.</returns>
        private string _Mtd_ObtenerCuentaContable()
        {
            string _Str_SQL;

            DataSet _Obj_Resultados;

            _Str_SQL = "SELECT ccount FROM dbo.TCUENTBANC";
            _Str_SQL += " WHERE cnumcuenta = '" + _Cmb_Cuenta.SelectedValue + "'";
            _Str_SQL += " AND cbanco = " + _Cmb_Banco.SelectedValue + ";";

            _Obj_Resultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            return _Obj_Resultados.Tables[0].Rows[0]["ccount"].ToString();
        }

        /// <summary>
        /// Método para visualizar la plantilla del comprobante.
        /// </summary>
        private void _Mtd_VisualizarComprobante()
        {
            //Valido que hayan documentos y que tengan saldo
            if (_Dtg_Documentos.Rows.Count == 0)
            {
                MessageBox.Show("Debe haber algún documento para poder generar el comprobante, verifique.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_Mtd_CalcularTotal() == 0)
            {
                MessageBox.Show("La suma de los montos de los documento no puede ser cero, verifique.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_Mtd_CalcularTotal() < 0)
            {
                MessageBox.Show("La suma de los montos de los documentos no puede ser negativo, verifique.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string _Str_SQL;
            string _Str_Cuenta = "";
            string _Str_Naturaleza;
            string _Str_Naturaleza_CxC;
            string _Str_Naturaleza_CxP;
            string _Str_Naturalidad;
            string _Str_Naturaleza_CheqYTrans;
            string _Str_Descripcion;
            string _Str_Monto;
            string _Str_MontoDebe;
            string _Str_MontoHaber;
            string _Str_TipoDocumento;
            string _Str_TipoDocumentoCorto;
            string _Str_NumeroDocumento;
            string _Str_FechaEmision;
            string _Str_FechaVencimiento;

            int _Int_Orden = 1;

            double _Dbl_Diferencia;

            DataSet _Obj_Resultados;

            _Dtg_Comprobante.Rows.Clear();

            if (_Dtg_Comprobante.Columns.Count == 0)
            {
                _Dtg_Comprobante.Columns.Add("_Dtg_Vista_Cuenta", "Cuenta");
                _Dtg_Comprobante.Columns.Add("_Dtg_Vista_Cambiar", "");
                _Dtg_Comprobante.Columns.Add("_Dtg_Vista_Descripcion", "Descripción");
                _Dtg_Comprobante.Columns.Add("_Dtg_Vista_Debe", "Debe");
                _Dtg_Comprobante.Columns.Add("_Dtg_Vista_Haber", "Haber");
                _Dtg_Comprobante.Columns.Add("_Dtg_Vista_Orden", "Orden");
                _Dtg_Comprobante.Columns.Add("_Dtg_Vista_TipoDocumento", "Tipo de documento");
                _Dtg_Comprobante.Columns.Add("_Dtg_Vista_NumeroDocumento", "Número de documento");
                _Dtg_Comprobante.Columns.Add("_Dtg_Vista_FechaDocumento", "Fecha del documento");
                _Dtg_Comprobante.Columns.Add("_Dtg_Vista_FechaVencimiento", "Fecha de vencimiento");
                _Dtg_Comprobante.Columns.Add("_Dtg_Vista_TipoDocumentoCorto", "Tipo de documento Corto");

                _Dtg_Comprobante.Columns[0].Width = 100;
                _Dtg_Comprobante.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dtg_Comprobante.Columns[1].Width = 30;
                _Dtg_Comprobante.Columns[1].DefaultCellStyle.BackColor = Color.DarkBlue;
                _Dtg_Comprobante.Columns[1].DefaultCellStyle.ForeColor = Color.White;
                _Dtg_Comprobante.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _Dtg_Comprobante.Columns[2].Width = 400;
                _Dtg_Comprobante.Columns[3].Width = 100;
                _Dtg_Comprobante.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Dtg_Comprobante.Columns[4].Width = 100;
                _Dtg_Comprobante.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                _Dtg_Comprobante.Columns[5].Visible = false;
                _Dtg_Comprobante.Columns[6].Visible = false;
                _Dtg_Comprobante.Columns[7].Visible = false;
                _Dtg_Comprobante.Columns[8].Visible = false;
                _Dtg_Comprobante.Columns[9].Visible = false;
                _Dtg_Comprobante.Columns[10].Visible = false;

            }

            //Cargamos lel proceso contable
            //CXC
            _Str_SQL = "SELECT * FROM VST_PROCESOSCONTD WHERE cidproceso = 'P_BCO_CHQ_CIARELPAGO' AND (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL)  ORDER BY cideprocesod";
            _Obj_Resultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            if (_Obj_Resultados.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Error no se encuentra el proceso contable. Por favor contacte con el personal de sistemas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Obtengo la plantilla de los Cheques y Transferencias
            PlantillaCuentaContable _Plantilla_ChequesYTransferencias_IC = new PlantillaCuentaContable();
            _Plantilla_ChequesYTransferencias_IC.Cuenta = "";
            _Plantilla_ChequesYTransferencias_IC.Descripcion = "";
            _Plantilla_ChequesYTransferencias_IC.Naturaleza = "D";

            //Obtengo la plantilla de las CXP IC
            PlantillaCuentaContable _Plantilla_CxP_IC = new PlantillaCuentaContable();
            _Plantilla_CxP_IC.Cuenta = _Obj_Resultados.Tables[0].Rows[0]["ccount"].ToString();
            _Plantilla_CxP_IC.Descripcion = _Obj_Resultados.Tables[0].Rows[0]["ccountname"].ToString();
            _Plantilla_CxP_IC.Naturaleza = _Obj_Resultados.Tables[0].Rows[0]["cnaturaleza"].ToString();

            //Obtengo la plantilla de las CXC IC
            PlantillaCuentaContable _Plantilla_CxC_IC = new PlantillaCuentaContable();
            _Plantilla_CxC_IC.Cuenta = _Obj_Resultados.Tables[0].Rows[2]["ccount"].ToString();
            _Plantilla_CxC_IC.Descripcion = _Obj_Resultados.Tables[0].Rows[2]["ccountname"].ToString();
            _Plantilla_CxC_IC.Naturaleza = _Obj_Resultados.Tables[0].Rows[2]["cnaturaleza"].ToString();

            foreach (DataGridViewRow _Obj_Fila in _Dtg_Documentos.Rows)
            {
                /*
                 *  Fijamos la cuenta contable.  
                 */

                switch (_Obj_Fila.Cells[3].Value.ToString())
                {
                    case "FACTURA CXC":
                    case "NOTA DE DEBITO CXC":
                    case "NOTA DE CREDITO CXC":
                    case "AVISO DE COBRO CXC":
                        _Str_Cuenta = _Plantilla_CxC_IC.Cuenta;
                        break;

                    case "NOTA DE DEBITO CXP":
                    case "NOTA DE CREDITO PROVEEDOR CXP":
                    case "FACTURA CXP":
                    case "NOTA DE CREDITO CXP":
                    case "NOTA DE DEBITO PROVEEDOR CXP":
                    case "AVISO DE COBRO CXP":
                        _Str_Cuenta = _Plantilla_CxP_IC.Cuenta;
                        break;
                }

                /*
                 *  Construimos la descripción de la cuenta del comprobante.
                 */

                _Str_SQL = "SELECT cname FROM TPROCESOSCONTD INNER JOIN TCOUNT ON TPROCESOSCONTD.ccount = TCOUNT.ccount";
                _Str_SQL += " WHERE cidproceso = 'P_BCO_CHQ_CIARELPAGO' AND TPROCESOSCONTD.ccount = '" + _Str_Cuenta +
                            "';";

                _Obj_Resultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

                _Str_Descripcion = _Obj_Resultados.Tables[0].Rows[0]["cname"].ToString();

                /*
                 *  En esta parte dependiendo del tipo de documento, vamos a obtener el cliente o 
                 *  el proveedor. Luego terminamos de estructurar la descripción según el tipo de 
                 *  documento, pues en unos casos se muestra la fecha de vencimiento y en otros se
                 *  muestra el número de documento.
                 */

                switch (_Obj_Fila.Cells[3].Value.ToString())
                {
                    case "FACTURA CXC":
                    case "NOTA DE DEBITO CXC":
                    case "NOTA DE CREDITO CXC":
                    case "AVISO DE COBRO CXC":

                        _Str_Descripcion += " " + _Mtd_ObtenerCliente();

                        break;

                    case "NOTA DE DEBITO CXP":
                    case "NOTA DE CREDITO PROVEEDOR CXP":
                    case "FACTURA CXP":
                    case "NOTA DE CREDITO CXP":
                    case "NOTA DE DEBITO PROVEEDOR CXP":
                    case "AVISO DE COBRO CXP":

                        _Str_Descripcion += " " + _Lbl_Proveedor.Text;

                        break;
                }

                switch (_Obj_Fila.Cells[3].Value.ToString())
                {
                    case "FACTURA CXC":

                        _Str_Descripcion += " COBRO " + _Obj_Fila.Cells[3].Value + ":" + _Obj_Fila.Cells[2].Value;
                        _Str_Descripcion += " VEC:" +
                                            Convert.ToDateTime(_Obj_Fila.Cells[1].Value.ToString()).ToShortDateString();

                        break;

                    case "NOTA DE DEBITO CXC":
                    case "NOTA DE DEBITO CXP":
                    case "NOTA DE CREDITO PROVEEDOR CXP":

                        _Str_Descripcion += " SEGUN " + _Obj_Fila.Cells[3].Value + " #" + _Obj_Fila.Cells[2].Value;

                        break;

                    case "NOTA DE CREDITO CXC":

                        _Str_Descripcion += " COBRO " + _Obj_Fila.Cells[3].Value + " #" + _Obj_Fila.Cells[2].Value;

                        break;

                    case "FACTURA CXP":

                        _Str_Descripcion += " CANCELACION " + _Obj_Fila.Cells[3].Value + " #" + _Obj_Fila.Cells[2].Value;
                        _Str_Descripcion += " VEC:" +
                                            Convert.ToDateTime(_Obj_Fila.Cells[1].Value.ToString()).ToShortDateString();

                        break;

                    case "NOTA DE CREDITO CXP":
                    case "NOTA DE DEBITO PROVEEDOR CXP":

                        _Str_Descripcion += " CANCELACION " + _Obj_Fila.Cells[3].Value + " #" + _Obj_Fila.Cells[2].Value;

                        break;

                    case "AVISO DE COBRO CXC":
                        _Str_Descripcion += " COBRO " + _Obj_Fila.Cells[3].Value + " #" + _Obj_Fila.Cells[2].Value;
                        break;

                    case "AVISO DE COBRO CXP":
                        _Str_Descripcion += " CANCELACION " + _Obj_Fila.Cells[3].Value + " #" + _Obj_Fila.Cells[2].Value;
                        break;
                }

                /*
                 *  Buscamos la naturaleza del documento, en caso de que sea cheque o transferencia
                 *  la naturaleza del documento será por el debe, en caso contrario, si es un documento,
                 *  su naturaleza se busca por el proceso contable en la tabla TPROCESOSCONTD.
                 */

                switch (_Obj_Fila.Cells[3].Value.ToString())
                {
                    case "FACTURA CXC":
                    case "NOTA DE DEBITO CXC":
                    case "NOTA DE CREDITO CXC":
                    case "AVISO DE COBRO CXC":
                        _Str_Naturaleza = _Plantilla_CxC_IC.Naturaleza;
                        break;
                    case "FACTURA CXP":
                    case "NOTA DE CREDITO CXP":
                    case "NOTA DE DEBITO PROVEEDOR CXP":
                    case "NOTA DE DEBITO CXP":
                    case "NOTA DE CREDITO PROVEEDOR CXP":
                    case "AVISO DE COBRO CXP":
                        _Str_Naturaleza = _Plantilla_CxP_IC.Naturaleza;
                        break;
                    case "CHEQUE":
                    case "TRANSFERENCIA":
                        _Str_Naturaleza = _Plantilla_ChequesYTransferencias_IC.Naturaleza;
                        break;
                    default:
                        _Str_Naturaleza = "";
                        break;
                }
                _Str_TipoDocumento = _Mtd_ConvertirTipoDocumentoDeLargoACorto(_Obj_Fila.Cells[3].Value.ToString());


                /*
                 *  Obtenemos la Naturalidad para saber donde va colocado el monto
                 */

                switch (_Obj_Fila.Cells[3].Value.ToString())
                {
                    case "FACTURA CXC":
                    case "NOTA DE DEBITO CXC":
                    case "FACTURA CXP":
                    case "NOTA DE CREDITO CXP":
                    case "NOTA DE DEBITO PROVEEDOR CXP":
                    case "CHEQUE":
                    case "TRANSFERENCIA":
                    case "AVISO DE COBRO CXC":
                    case "AVISO DE COBRO CXP":
                        _Str_Naturalidad = "NATURAL";
                        break;
                    case "NOTA DE DEBITO CXP":
                    case "NOTA DE CREDITO PROVEEDOR CXP":
                    case "NOTA DE CREDITO CXC":
                        _Str_Naturalidad = "ANTINATURAL";
                        break;
                    default:
                        _Str_Naturalidad = "";
                        break;
                }


                /*
                 *  Obtenemos el monto total del documento para agregarlo al comprobante.
                 */

                if (Convert.ToDouble(_Obj_Fila.Cells[4].Value.ToString()) < 0)
                {
                    _Str_Monto = Math.Abs((Convert.ToDouble(_Obj_Fila.Cells[4].Value.ToString()) * -1)).ToString();
                }
                else
                {
                    _Str_Monto = _Obj_Fila.Cells[4].Value.ToString();
                }

                /*
                 *  Agregamos la fila al grid de comprobante. 
                 */

                _Str_FechaEmision = _Obj_Fila.Cells[0].Value.ToString();
                _Str_FechaVencimiento = _Obj_Fila.Cells[1].Value.ToString();
                _Str_NumeroDocumento = _Obj_Fila.Cells[2].Value.ToString();

                //Obtenemos el Tipo de Documento corto para el detalle del comprobante (Ignacio 16/05/2013)
                _Str_TipoDocumentoCorto = _Mtd_ConvertirTipoDocumentoDeLargoACorto(_Obj_Fila.Cells[3].Value.ToString());

                if (_Str_Naturaleza == "D")
                {
                    if (_Str_Naturalidad == "NATURAL")
                    {
                        _Dtg_Comprobante.Rows.Add(_Str_Cuenta, "...", _Str_Descripcion, Convert.ToDouble(_Str_Monto).ToString("#,##0.00"), "", _Int_Orden, _Str_TipoDocumento, _Str_NumeroDocumento, _Str_FechaEmision, _Str_FechaVencimiento, _Str_TipoDocumentoCorto);
                    }
                    else
                    {
                        _Dtg_Comprobante.Rows.Add(_Str_Cuenta, "...", _Str_Descripcion, "", Convert.ToDouble(_Str_Monto).ToString("#,##0.00"), _Int_Orden, _Str_TipoDocumento, _Str_NumeroDocumento, _Str_FechaEmision, _Str_FechaVencimiento, _Str_TipoDocumentoCorto);
                    }
                }
                else
                {
                    if (_Str_Naturalidad == "NATURAL")
                    {
                        _Dtg_Comprobante.Rows.Add(_Str_Cuenta, "...", _Str_Descripcion, "", Convert.ToDouble(_Str_Monto).ToString("#,##0.00"), _Int_Orden, _Str_TipoDocumento, _Str_NumeroDocumento, _Str_FechaEmision, _Str_FechaVencimiento, _Str_TipoDocumentoCorto);
                    }
                    else
                    {
                        _Dtg_Comprobante.Rows.Add(_Str_Cuenta, "...", _Str_Descripcion, Convert.ToDouble(_Str_Monto).ToString("#,##0.00"), "", _Int_Orden, _Str_TipoDocumento, _Str_NumeroDocumento, _Str_FechaEmision, _Str_FechaVencimiento, _Str_TipoDocumentoCorto);
                    }
                }

                _Int_Orden++;

            } //fin -> foreach (DataGridViewRow _Obj_Fila in _Dtg_Documentos.Rows)

            /*
             *  Agregamos la fila del cheque o la transferencia.
             */

            _Str_Cuenta = _Mtd_ObtenerCuentaContable();

            _Dbl_Diferencia = _Mtd_CalcularTotal();

            _Dbl_Diferencia = Math.Abs(_Dbl_Diferencia);

            _Str_SQL = "SELECT cnaturaleza FROM TPROCESOSCONTD WHERE ccount = 'BNC.X' AND cidproceso = 'P_BCO_CHQ_CIARELPAGO';";

            _Obj_Resultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            _Str_Naturaleza = _Obj_Resultados.Tables[0].Rows[0]["cnaturaleza"].ToString();

            string _Str_FechaActual = DateTime.Now.ToShortDateString();


            if (_Chk_Cheque.Checked)
            {
                //Obtenemos el Tipo de Documento corto para el detalle del comprobante (Ignacio 16/05/2013)
                _Str_TipoDocumentoCorto = _Mtd_ConvertirTipoDocumentoDeLargoACorto("CHEQUE");
                if (_Str_Naturaleza == "D")
                {

                    _Dtg_Comprobante.Rows.Add(_Str_Cuenta, "...", _Cmb_Banco.Text + " CHEQUE", _Dbl_Diferencia.ToString("#,##0.00"), "", _Int_Orden, _Str_Naturaleza, "0", _Str_FechaActual, _Str_FechaActual, _Str_TipoDocumentoCorto);
                }
                else
                {
                    _Dtg_Comprobante.Rows.Add(_Str_Cuenta, "...", _Cmb_Banco.Text + " CHEQUE", "", _Dbl_Diferencia.ToString("#,##0.00"), _Int_Orden, _Str_Naturaleza, "0", _Str_FechaActual, _Str_FechaActual, _Str_TipoDocumentoCorto);
                }
            }
            else
            {
                //Obtenemos el Tipo de Documento corto para el detalle del comprobante (Ignacio 16/05/2013)
                _Str_TipoDocumentoCorto = _Mtd_ConvertirTipoDocumentoDeLargoACorto("TRANSFERENCIA");
                if (_Str_Naturaleza == "D")
                {
                    _Dtg_Comprobante.Rows.Add(_Str_Cuenta, "...", _Cmb_Banco.Text + " TRANSFERENCIA", _Dbl_Diferencia.ToString("#,##0.00"), "", _Int_Orden, _Str_Naturaleza, "0", _Str_FechaActual, _Str_FechaActual, _Str_TipoDocumentoCorto);
                }
                else
                {
                    _Dtg_Comprobante.Rows.Add(_Str_Cuenta, "...", _Cmb_Banco.Text + " TRANSFERENCIA", "", _Dbl_Diferencia.ToString("#,##0.00"), _Int_Orden, _Str_Naturaleza, "0", _Str_FechaActual, _Str_FechaActual, _Str_TipoDocumentoCorto);
                }
            }

            _Str_MontoDebe = _Mtd_TotalComprobante(3);
            _Str_MontoHaber = _Mtd_TotalComprobante(4);

            _Dtg_Comprobante.Rows.Add("", "", "Total:", _Str_MontoDebe, _Str_MontoHaber);
            _Dtg_Comprobante.Rows[_Dtg_Comprobante.Rows.Count - 1].Cells[1].Style.BackColor = SystemColors.Window;
            _Dtg_Comprobante.Rows[_Dtg_Comprobante.Rows.Count - 1].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dtg_Comprobante.ClearSelection();
        }

        /// <summary>
        /// Para convertir de tipo documento largo (viene de la vista) a corto (para guardar en el detalle del comprobante)
        /// </summary>
        /// <param name="_P_Str_TipoDocumentoLargo"></param>
        /// <returns></returns>
        private string _Mtd_ConvertirTipoDocumentoDeLargoACorto(string _P_Str_TipoDocumentoLargo)
        {
            string _Str_TipoDocumentoCorto = "";
            switch (_P_Str_TipoDocumentoLargo)
            {
                case "FACTURA CXC":
                    _Str_TipoDocumentoCorto = "FACT";
                    break;
                case "NOTA DE DEBITO CXC":
                    _Str_TipoDocumentoCorto = "N/D";
                    break;
                case "NOTA DE CREDITO CXC":
                    _Str_TipoDocumentoCorto = "N/C";
                    break;
                case "FACTURA CXP":
                    _Str_TipoDocumentoCorto = "FACT";
                    break;
                case "NOTA DE DEBITO CXP":
                    _Str_TipoDocumentoCorto = "N/D";
                    break;
                case "NOTA DE CREDITO CXP":
                    _Str_TipoDocumentoCorto = "N/C";
                    break;
                case "NOTA DE CREDITO PROVEEDOR CXP":
                    _Str_TipoDocumentoCorto = "NCP";
                    break;
                case "NOTA DE DEBITO PROVEEDOR CXP":
                    _Str_TipoDocumentoCorto = "NDP";
                    break;
                case "CHEQUE":
                    _Str_TipoDocumentoCorto = "CHEQ";
                    break;
                case "TRANSFERENCIA":
                    _Str_TipoDocumentoCorto = "TRANSB";
                    break;
                case "AVISO DE COBRO CXC":
                    _Str_TipoDocumentoCorto = "AVISOCXC";
                    break;
                case "AVISO DE COBRO CXP":
                    _Str_TipoDocumentoCorto = "AVISOCXP";
                    break;
            }
            return _Str_TipoDocumentoCorto;
        }


        /// <summary>
        /// Método para cargar los bancos.
        /// </summary>
        /// <param name="_P_Obj_Combo">Combo para agregar los bancos.</param>
        private void _Mtd_CargarBancos(ComboBox _P_Obj_Combo)
        {
            string _Str_SQL;

            DataSet _Obj_Resultados;

            System.Collections.ArrayList _Obj_Lista = new System.Collections.ArrayList();

            _P_Obj_Combo.DataSource = null;

            _Str_SQL = "SELECT DISTINCT cbanco, cname FROM VST_BANCOCUENTAS WHERE ccompany = '" + Frm_Padre._Str_Comp + "';";

            _Obj_Resultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            foreach (DataRow _Obj_Fila in _Obj_Resultados.Tables[0].Rows)
            {
                _Obj_Lista.Add(new _Cls_ArrayList(_Obj_Fila[1].ToString(), _Obj_Fila[0].ToString()));
            }

            _P_Obj_Combo.DataSource = _Obj_Lista;
            _P_Obj_Combo.DisplayMember = "Display";
            _P_Obj_Combo.ValueMember = "Value";

        }

        /// <summary>
        /// Método para cargar las cuentas.
        /// </summary>
        /// <param name="_P_Obj_Combo">Combo para agregar las cuentas según el banco.</param>
        /// <param name="_P_Str_Banco">Código del banco.</param>
        private void _Mtd_CargarCuenta(ComboBox _P_Obj_Combo, string _P_Str_Banco)
        {
            string _Str_SQL;

            DataSet _Obj_Resultados;

            System.Collections.ArrayList _Obj_Lista = new System.Collections.ArrayList();

            _P_Obj_Combo.DataSource = null;

            _Str_SQL = "SELECT cnumcuenta, cuentabanname FROM VST_BANCOCUENTAS";
            _Str_SQL += " WHERE ccompany = '" + Frm_Padre._Str_Comp + "' AND cbanco = '" + _P_Str_Banco + "';";

            _Obj_Resultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);

            foreach (DataRow _Obj_Fila in _Obj_Resultados.Tables[0].Rows)
            {
                _Obj_Lista.Add(new _Cls_ArrayList(_Obj_Fila[1].ToString(), _Obj_Fila[0].ToString()));
            }

            _P_Obj_Combo.DataSource = _Obj_Lista;
            _P_Obj_Combo.DisplayMember = "Display";
            _P_Obj_Combo.ValueMember = "Value";
        }

        /// <summary>
        /// Método para totalizar la orden de pago.
        /// </summary>
        /// <returns>>Total de la orden de pago.</returns>
        private double _Mtd_CalcularTotal()
        {
            int _Int_Indice;
            double _Dbl_TotalMonto = 0;
            for (_Int_Indice = 0; _Int_Indice < _Dtg_Documentos.Rows.Count; _Int_Indice++)
            {
                _Dbl_TotalMonto += Convert.ToDouble(_Dtg_Documentos.Rows[_Int_Indice].Cells[4].Value.ToString());
            }
            return _Dbl_TotalMonto * -1;
        }

        /// <summary>
        /// Método para consultar los documentos de la orden de pago.
        /// </summary>
        /// <param name="_P_Str_Tipos">Tipos de documentos.</param>
        /// <param name="_P_Str_Documentos">Número de documentos.</param>
        private void _Mtd_ConsultarDocumentos()
        {
            string _Str_SQL;

            int _Int_Indice;

            /*
             *  Filtramos por los tipos y números de documentos para llenar el grid _Dtg_Documentos.
             */

            _Str_SQL = "SELECT CONVERT(DATETIME, CONVERT(VARCHAR, cfechaemision, 101), 101) AS Emisión,";
            _Str_SQL += " CONVERT(DATETIME, CONVERT(VARCHAR, cfechavencimiento, 101), 101) AS Vencimiento,";
            _Str_SQL += " cnumdocu AS Documento,";
            _Str_SQL += " ctipo AS Tipo,";
            _Str_SQL += " dbo.Fnc_Formatear(CASE WHEN ctipo IN('AVISO DE COBRO CXC', 'FACTURA CXC', 'NOTA DE DEBITO CXP', 'NOTA DE CREDITO PROVEEDOR CXP', 'NOTA DE DEBITO CXC') THEN cmonto ELSE -1*cmonto END) as Monto";
            _Str_SQL += " FROM VST_CONSOLIDADO_INTERCOMPANIAS";
            _Str_SQL += " WHERE ccompany = '" + Frm_Padre._Str_Comp + "'";
            _Str_SQL += " AND cproveedor = '" + _G_Str_Proveedor + "'";
            _Str_SQL += " AND canulado = 0";
            _Str_SQL += " AND cimpreso = 1";
            _Str_SQL += " AND cestado = 0";

            if (_G_Str_Tipos.Length > 0)
                _Str_SQL += " AND ( ";

            for (_Int_Indice = 0; _Int_Indice < _G_Str_Tipos.Length; _Int_Indice++)
            {
                if (_Int_Indice == 0)
                {
                    _Str_SQL += " (ctipo = '" + _G_Str_Tipos[_Int_Indice] + "' AND cnumdocu = '" + _G_Str_Documentos[_Int_Indice] + "')";
                }
                else
                {
                    _Str_SQL += " OR (ctipo = '" + _G_Str_Tipos[_Int_Indice] + "' AND cnumdocu = '" + _G_Str_Documentos[_Int_Indice] + "')";
                }
            }

            if (_G_Str_Tipos.Length > 0)
                _Str_SQL += " ) ";

            _Str_SQL += ";";

            Cursor = Cursors.WaitCursor;

            _Dtg_Documentos.DataSource = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL).Tables[0];

            _Dtg_Documentos.Columns[0].Width = 100;
            _Dtg_Documentos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dtg_Documentos.Columns[1].Width = 100;
            _Dtg_Documentos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dtg_Documentos.Columns[2].Width = 100;
            _Dtg_Documentos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dtg_Documentos.Columns[3].Width = 380;
            _Dtg_Documentos.Columns[4].Width = 100;
            _Dtg_Documentos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            Cursor = Cursors.Default;

            /*
             *  Cambiamos el color de la fila en caso de que sea un documento de 
             *  cuentas por cobrar y el formato de los montos cambia a negativo.
             */

            foreach (DataGridViewRow _Obj_Fila in _Dtg_Documentos.Rows)
            {
                switch (_Obj_Fila.Cells[3].Value.ToString())
                {
                    case "FACTURA CXC":
                    case "NOTA DE DEBITO CXC":
                    case "NOTA DE DEBITO CXP":
                    case "NOTA DE CREDITO PROVEEDOR CXP":
                    case "AVISO DE COBRO CXC":
                        _Obj_Fila.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                    default:
                        _Obj_Fila.DefaultCellStyle.ForeColor = Color.Red;
                        break;
                }
            }

            _Dtg_Documentos.ClearSelection();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="_P_Str_Proveedor">Arreglo con los proveedores.</param>
        /// <param name="_P_Str_Tipos">Arreglo con los tipos.</param>
        /// <param name="_P_Str_Documentos">Arreglo con los documentos.</param>
        public Frm_IC_GeneracionOP(string _P_Str_Proveedor, string[] _P_Str_Tipos, string[] _P_Str_Documentos)
        {
            InitializeComponent();

            _Lbl_Proveedor.Text = "";

            /*
             *  Verificamos que ambos arreglos sean del mismo tamaño.
             */

            if ((_P_Str_Proveedor != "") && (_P_Str_Tipos.Length == _P_Str_Documentos.Length))
            {
                _G_Str_Proveedor = _P_Str_Proveedor;
                _G_Str_Tipos = _P_Str_Tipos;
                _G_Str_Documentos = _P_Str_Documentos;

                _Mtd_CargarBancos(_Cmb_Banco);

                _Cmb_Banco.SelectedIndex = 0;

                _Mtd_CargarCuenta(_Cmb_Cuenta, _Cmb_Banco.SelectedValue.ToString());
            }
        }

        //----------------------------------------------------------------------------------------------------------
        //  Eventos.
        //----------------------------------------------------------------------------------------------------------

        private void _Btn_Agregar_Click(object sender, EventArgs e)
        {
            string[] _Str_Temporal = new string[_G_Str_Tipos.Length + 1];

            Double _Dbl_Total;

            Cursor = Cursors.WaitCursor;

            Frm_Busqueda2 _Frm = new Frm_Busqueda2(_G_Str_Proveedor);

            Cursor = Cursors.Default;

            _Frm.ShowDialog();

            if (_Frm._G_Str_Resultados == null)
            {
                return;
            }

            foreach (DataGridViewRow _Obj_Fila in _Dtg_Documentos.Rows)
            {
                if ((_Obj_Fila.Cells[2].Value.ToString() == _Frm._G_Str_Resultados[0].ToUpper()) && (_Obj_Fila.Cells[3].Value.ToString() == _Frm._G_Str_Resultados[1].ToUpper()))
                {
                    MessageBox.Show("El siguiente documento ya se encuentra en la orden de pago. Por favor verifique.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //Validamos que el documento no se encuentre en ninguna otra orden de pago ni cobranza
            int _Int_IndiceFilaActual = _Frm._Dg_Grid.CurrentCell.RowIndex;
            string _Str_CodigoProveedor = _G_Str_Proveedor;
            string _Str_TipoDocumento = _Frm._Dg_Grid.Rows[_Int_IndiceFilaActual].Cells[4].Value.ToString().ToUpper();
            string _Str_NumeroDocumento = _Frm._Dg_Grid.Rows[_Int_IndiceFilaActual].Cells[0].Value.ToString().ToUpper();
            string _Str_CodigoOrdenPago = _Mtd_DocumentoSeEncuentraEnOrdenPagoNoAnulada(_Str_CodigoProveedor, _Str_TipoDocumento, _Str_NumeroDocumento);
            if (_Str_CodigoOrdenPago != "")
            {
                MessageBox.Show("El siguiente documento ya se encuentra en la orden de pago No. " + _Str_CodigoOrdenPago + " . Por favor verifique: \n" + _Str_TipoDocumento + ", No. " + _Str_NumeroDocumento, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string _Str_CodigoCobranzaIC = _Mtd_DocumentoSeEncuentraCobranzaIcNoRechazada(_Str_CodigoProveedor, _Str_TipoDocumento, _Str_NumeroDocumento);
            if (_Str_CodigoCobranzaIC != "")
            {
                MessageBox.Show("El siguiente documento ya se encuentra en la cobranza intercompañía No. " + _Str_CodigoCobranzaIC + " . Por favor verifique: \n" + _Str_TipoDocumento + ", No. " + _Str_NumeroDocumento, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            /*
             *  Trabajando con una matriz temporal, se redimensiona la matriz
             *  de tipos de documentos para agregar el tipo del documento que
             *  seleccionó el usuario en la búsqueda.
             */

            for (int _Int_Indice = 0; _Int_Indice < _G_Str_Tipos.Length; _Int_Indice++)
            {
                _Str_Temporal[_Int_Indice] = _G_Str_Tipos[_Int_Indice];
            }

            _Str_Temporal[_Str_Temporal.Length - 1] = _Frm._G_Str_Resultados[1].ToUpper();

            _G_Str_Tipos = null;
            _G_Str_Tipos = new string[_Str_Temporal.Length];

            for (int _Int_Indice = 0; _Int_Indice < _Str_Temporal.Length; _Int_Indice++)
            {
                _G_Str_Tipos[_Int_Indice] = _Str_Temporal[_Int_Indice];
            }

            /*
             *  Trabajando con una matriz temporal, se redimensiona la matriz
             *  de documentos para agregar el número del documento que seleccionó
             *  el usuario en la búsqueda.
             */

            for (int _Int_Indice = 0; _Int_Indice < _G_Str_Documentos.Length; _Int_Indice++)
            {
                _Str_Temporal[_Int_Indice] = _G_Str_Documentos[_Int_Indice];
            }

            _Str_Temporal[_Str_Temporal.Length - 1] = _Frm._G_Str_Resultados[0].ToUpper();

            _G_Str_Documentos = null;
            _G_Str_Documentos = new string[_Str_Temporal.Length];

            for (int _Int_Indice = 0; _Int_Indice < _Str_Temporal.Length; _Int_Indice++)
            {
                _G_Str_Documentos[_Int_Indice] = _Str_Temporal[_Int_Indice];
            }

            _Mtd_ConsultarDocumentos();

            _Dbl_Total = _Mtd_CalcularTotal();

            _Lbl_MontoTotal.Text = _Dbl_Total.ToString("Bsf #,##0.00");

            _Dtg_Comprobante.Rows.Clear();
        }

        private void _Mnu_Eliminar_Click(object sender, EventArgs e)
        {
            int _Int_Indice = 0;

            Double _Dbl_Total;

            _Dtg_Documentos.Rows.Remove(_Dtg_Documentos.Rows[_Dtg_Documentos.CurrentRow.Index]);

            _G_Str_Tipos = new string[_Dtg_Documentos.Rows.Count];
            _G_Str_Documentos = new string[_Dtg_Documentos.Rows.Count];

            foreach (DataGridViewRow _Obj_Fila in _Dtg_Documentos.Rows)
            {
                _G_Str_Tipos[_Int_Indice] = _Obj_Fila.Cells[3].Value.ToString();
                _G_Str_Documentos[_Int_Indice] = _Obj_Fila.Cells[2].Value.ToString();

                _Int_Indice++;
            }

            _Dbl_Total = _Mtd_CalcularTotal();

            _Lbl_MontoTotal.Text = _Dbl_Total.ToString("Bsf #,##0.00");

            _Dtg_Comprobante.Rows.Clear();
        }

        private void _Btn_Generar_Click(object sender, EventArgs e)
        {
            double _Dbl_Debe;
            double _Dbl_Haber;

            _Dbl_Debe = Convert.ToDouble(_Mtd_TotalComprobante(3));
            _Dbl_Haber = Convert.ToDouble(_Mtd_TotalComprobante(4));

            if (!_Mtd_VerificarTotalDocumentos())
            {
                return;
            }

            if (_Dbl_Debe != _Dbl_Haber)
            {
                MessageBox.Show("El comprobante no está cuadrado, verifique.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (_Dtg_Comprobante.Rows.Count == 0)
            {
                MessageBox.Show("Debe generar o visualizar el comprobante.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _Mtd_GenerarOrdenPago();

            MessageBox.Show("Se generó la orden de pago exitosamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }

        private void _Btn_Visualizar_Click(object sender, EventArgs e)
        {
            _Mtd_VisualizarComprobante();
        }

        private void Frm_GeneracionOPIC_Load(object sender, EventArgs e)
        {
            _Mtd_ConsultarDocumentos();

            _Lbl_Proveedor.Text = _Mtd_ObtenerProveedor();

            _Lbl_MontoTotal.Text = _Mtd_CalcularTotal().ToString("Bsf #,##0.00");
            _Mtd_Sorted(_Dtg_Documentos);
            _Mtd_Sorted(_Dtg_Comprobante);
        }

        private void _Btn_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _Cmb_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Banco.SelectedValue != null && _Obj_Utilidad._Mtd_IsNumeric(_Cmb_Banco.SelectedValue.ToString()))
            {
                _Mtd_CargarCuenta(_Cmb_Cuenta, _Cmb_Banco.SelectedValue.ToString());
            }
        }

        private void _Cmb_Cuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Dtg_Comprobante.Rows.Clear();
        }

        /// <summary>
        /// Determina si un documento se encuentra previamente en una OP no anulada. Devuelve "" si no está. Devuelve el código de la OP si está.
        /// </summary>
        /// <param name="_Str_CodigoProveedor">Código del proveedor al que corresponde el documento</param>
        /// <param name="_Str_TipoDocumento">Tipo 'largo' de documento ic</param>
        /// <param name="_Str_NumeroDocumento">Número o código del documento</param>
        /// <returns>Vacio ("") en caso de que el documento no esté en en ninguna OP no anulada. Código de la OP en caso de que si esté.</returns>
        private string _Mtd_DocumentoSeEncuentraEnOrdenPagoNoAnulada(string _P_Str_CodigoProveedor, string _P_Str_TipoDocumento, string _P_Str_NumeroDocumento)
        {
            string _Str_SQL = "";
            string _Str_Retornar = "";


            switch (_P_Str_TipoDocumento)
            {
                case "FACTURA CXC":
                case "NOTA DE DEBITO CXC":
                case "NOTA DE CREDITO CXC":
                case "AVISO DE COBRO CXC":

                    _Str_SQL += "SELECT     dbo.TPAGOSCXPM.cidordpago ";
                    _Str_SQL += "FROM       dbo.TPAGOSCXPM INNER JOIN dbo.TPAGOSCXCD ON dbo.TPAGOSCXPM.ccompany = dbo.TPAGOSCXCD.ccompany AND dbo.TPAGOSCXPM.cidordpago = dbo.TPAGOSCXCD.cidordpago ";
                    _Str_SQL += "WHERE     (dbo.TPAGOSCXPM.canulado = 0) AND (dbo.TPAGOSCXCD.ccompany = '" + Frm_Padre._Str_Comp + "') AND (dbo.TPAGOSCXCD.cnumdocu = '" + _P_Str_NumeroDocumento + "') ";

                    if (_P_Str_TipoDocumento == "FACTURA CXC") _Str_SQL += " AND (dbo.TPAGOSCXCD.ctipodocument = 'FACT') ";
                    if (_P_Str_TipoDocumento == "NOTA DE DEBITO CXC") _Str_SQL += " AND (dbo.TPAGOSCXCD.ctipodocument = 'N/D') ";
                    if (_P_Str_TipoDocumento == "NOTA DE CREDITO CXC") _Str_SQL += " AND (dbo.TPAGOSCXCD.ctipodocument = 'N/C') ";
                    if (_P_Str_TipoDocumento == "AVISO DE COBRO CXC") _Str_SQL += " AND (dbo.TPAGOSCXCD.ctipodocument = 'AVISOCXC') ";

                    break;

                case "FACTURA CXP":
                case "NOTA DE DEBITO CXP":
                case "NOTA DE CREDITO CXP":
                case "NOTA DE CREDITO PROVEEDOR CXP":
                case "NOTA DE DEBITO PROVEEDOR CXP":
                case "AVISO DE COBRO CXP":

                    _Str_SQL = "";
                    _Str_SQL += "SELECT     dbo.TPAGOSCXPM.cidordpago ";
                    _Str_SQL += "FROM         dbo.TPAGOSCXPM INNER JOIN dbo.TPAGOSCXPD ON dbo.TPAGOSCXPM.ccompany = dbo.TPAGOSCXPD.ccompany AND dbo.TPAGOSCXPM.cidordpago = dbo.TPAGOSCXPD.cidordpago AND dbo.TPAGOSCXPM.cgroupcomp = dbo.TPAGOSCXPD.cgroupcomp AND dbo.TPAGOSCXPM.cproveedor = dbo.TPAGOSCXPD.cproveedor ";
                    _Str_SQL += "WHERE     (dbo.TPAGOSCXPM.ccompany = '" + Frm_Padre._Str_Comp + "') AND (dbo.TPAGOSCXPM.canulado = 0) AND (dbo.TPAGOSCXPD.cproveedor = '" + _P_Str_CodigoProveedor + "') AND (dbo.TPAGOSCXPD.cnumdocu = '" + _P_Str_NumeroDocumento + "') ";

                    if (_P_Str_TipoDocumento == "FACTURA CXP") _Str_SQL += " AND (dbo.TPAGOSCXPD.ctipodocument = 'FACT') ";
                    if (_P_Str_TipoDocumento == "NOTA DE DEBITO CXP") _Str_SQL += " AND (dbo.TPAGOSCXPD.ctipodocument = 'N/D') ";
                    if (_P_Str_TipoDocumento == "NOTA DE CREDITO CXP") _Str_SQL += " AND (dbo.TPAGOSCXPD.ctipodocument = 'N/C') ";
                    if (_P_Str_TipoDocumento == "NOTA DE CREDITO PROVEEDOR CXP") _Str_SQL += " AND (dbo.TPAGOSCXPD.ctipodocument = 'NCP') ";
                    if (_P_Str_TipoDocumento == "NOTA DE DEBITO PROVEEDOR CXP") _Str_SQL += " AND (dbo.TPAGOSCXPD.ctipodocument = 'NDP') ";
                    if (_P_Str_TipoDocumento == "AVISO DE COBRO CXP") _Str_SQL += " AND (dbo.TPAGOSCXPD.ctipodocument = 'AVISOCXP') ";

                    break;
            }

            try
            {
                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Str_Retornar = _Ds_DataSet.Tables[0].Rows[0]["cidordpago"].ToString();
                }
            }
            catch
            {
                // en caso de que haya una excepcion, devuelve un valor y previene que se complete la OP
                _Str_Retornar = "0";
                MessageBox.Show("Lo sentimos, ha ocurrido un error inesperado. Por favor contacte al desarollador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return _Str_Retornar;
        }

        /// <summary>
        /// Determina si un documento se encuentra previamente en una cobranza intercompañía no rechazada. Devuelve "" si no está. Devuelve el código de la cobranza si está.
        /// </summary>
        /// <param name="_Str_CodigoProveedor">Código del proveedor al que corresponde el documento</param>
        /// <param name="_Str_TipoDocumento">Tipo 'largo' de documento ic</param>
        /// <param name="_Str_NumeroDocumento">Número o código del documento</param>
        /// <returns>Vacio ("") en caso de que el documento no esté en en ninguna cobranza no rechazada. Código de la cobranza en caso de que si esté.</returns>
        private string _Mtd_DocumentoSeEncuentraCobranzaIcNoRechazada(string _P_Str_CodigoProveedor, string _P_Str_TipoDocumento, string _P_Str_NumeroDocumento)
        {
            string _Str_SQL = "";
            string _Str_Retornar = "";


            switch (_P_Str_TipoDocumento)
            {
                case "FACTURA CXC":
                case "NOTA DE DEBITO CXC":
                case "NOTA DE CREDITO CXC":
                case "AVISO DE COBRO CXC":

                    _Str_SQL += "SELECT    dbo.TICCOBRAM.cidcobranzaic ";
                    _Str_SQL += "FROM      dbo.TICCOBRAM INNER JOIN dbo.TICCOBRAD_CXC ON dbo.TICCOBRAM.cidcobranzaic = dbo.TICCOBRAD_CXC.cidcobranzaic AND dbo.TICCOBRAM.ccompany = dbo.TICCOBRAD_CXC.ccompany ";
                    _Str_SQL += "WHERE    (dbo.TICCOBRAD_CXC.cnumdocu = " + _P_Str_NumeroDocumento + ")  AND (dbo.TICCOBRAD_CXC.ccompany = '" + Frm_Padre._Str_Comp + "')";

                    if (_P_Str_TipoDocumento == "FACTURA CXC") _Str_SQL += " AND (dbo.TICCOBRAD_CXC.ctipodocument = 'FACT') ";
                    if (_P_Str_TipoDocumento == "NOTA DE DEBITO CXC") _Str_SQL += " AND (dbo.TICCOBRAD_CXC.ctipodocument = 'N/D') ";
                    if (_P_Str_TipoDocumento == "NOTA DE CREDITO CXC") _Str_SQL += " AND (dbo.TICCOBRAD_CXC.ctipodocument = 'N/C') ";
                    if (_P_Str_TipoDocumento == "AVISO DE COBRO CXC") _Str_SQL += " AND (dbo.TICCOBRAD_CXC.ctipodocument = 'AVISOCXC') ";
                    break;

                case "FACTURA CXP":
                case "NOTA DE DEBITO CXP":
                case "NOTA DE CREDITO CXP":
                case "NOTA DE CREDITO PROVEEDOR CXP":
                case "NOTA DE DEBITO PROVEEDOR CXP":
                case "AVISO DE COBRO CXP":

                    _Str_SQL = "";
                    _Str_SQL += "SELECT    dbo.TICCOBRAM.cidcobranzaic ";
                    _Str_SQL += "FROM         dbo.TICCOBRAM INNER JOIN  dbo.TICCOBRAD_CXP ON dbo.TICCOBRAM.cidcobranzaic = dbo.TICCOBRAD_CXP.cidcobranzaic AND  dbo.TICCOBRAM.ccompany = dbo.TICCOBRAD_CXP.ccompany ";
                    _Str_SQL += "WHERE       (dbo.TICCOBRAD_CXP.cnumdocu = '" + _P_Str_NumeroDocumento + "') AND (dbo.TICCOBRAD_CXP.cproveedor = '" + _P_Str_CodigoProveedor + "') ";

                    if (_P_Str_TipoDocumento == "FACTURA CXP") _Str_SQL += " AND (dbo.TICCOBRAD_CXP.ctipodocument = 'FACT') ";
                    if (_P_Str_TipoDocumento == "NOTA DE DEBITO CXP") _Str_SQL += " AND (dbo.TICCOBRAD_CXP.ctipodocument = 'N/D') ";
                    if (_P_Str_TipoDocumento == "NOTA DE CREDITO CXP") _Str_SQL += " AND (dbo.TICCOBRAD_CXP.ctipodocument = 'N/C') ";
                    if (_P_Str_TipoDocumento == "NOTA DE CREDITO PROVEEDOR CXP") _Str_SQL += " AND (dbo.TICCOBRAD_CXP.ctipodocument = 'NCP') ";
                    if (_P_Str_TipoDocumento == "NOTA DE DEBITO PROVEEDOR CXP") _Str_SQL += " AND (dbo.TICCOBRAD_CXP.ctipodocument = 'NDP') ";
                    if (_P_Str_TipoDocumento == "AVISO DE COBRO CXP") _Str_SQL += " AND (dbo.TICCOBRAD_CXP.ctipodocument = 'AVISOCXP') ";

                    break;
            }

            try
            {
                DataSet _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _Str_Retornar = _Ds_DataSet.Tables[0].Rows[0]["cidcobranzaic"].ToString();
                }
            }
            catch
            {
                // en caso de que haya una excepcion, devuelve un valor y previene que se complete la cobranza
                _Str_Retornar = "0";
                MessageBox.Show("Lo sentimos, ha ocurrido un error inesperado. Por favor contacte al desarollador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return _Str_Retornar;
        }

    }
}
