using System;
using System.Linq;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using T3.Clases;

namespace T3
{
    public partial class Frm_RC_Resumen : Form
    {
        private readonly int _G_Str_Cguiddesp;
        private bool _G_EstamosAprobando;
        private readonly CLASES._Cls_Varios_Metodos _MyUtilidad = new CLASES._Cls_Varios_Metodos(true);

        public Frm_RC_Resumen()
        {
            InitializeComponent();
        }

        private void Frm_RC_Resumen_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
        }

        public Frm_RC_Resumen(int _P_Str_Cguiddesp)
        {
            InitializeComponent();
            _G_Str_Cguiddesp = _P_Str_Cguiddesp;
            _Mtd_CargarResumen(_G_Str_Cguiddesp);
        }

        private void _Mtd_CargarResumen(int _P_Str_Cguiddesp)
        {
            Text = "Cobranza de Guía de Despacho #" + _P_Str_Cguiddesp;
            _Mtd_Actualizar_Clientes();
            _Mtd_Actualizar_Cheques();
            _Mtd_Actualizar_Depositos();
            _Mtd_Actualizar_Retenciones();
            _Mtd_Actualizar_SobranteFaltante();
            _Mtd_Actualizar_GuiasGeneradas();
        }

        private void _Mtd_Actualizar_Clientes()
        {
            Cursor = Cursors.WaitCursor;

            //Cargamos los datos
            //var _Str_Cadena = "SELECT CONVERT(VARCHAR,[Cliente],103) AS [Cliente],[Nombre del Cliente],[Documento],[MontoRetencion],[MontoNotasDeCredito],[MontoCheques],[MontoDepositos],[MontoCobrado] FROM [VST_RC_INGRESADAS_RESUMEN_CLIENTES] WHERE cguiadesp='" + _G_Str_Cguiddesp + "'";
            var _Str_Cadena = "EXEC PA_RC_INGRESADAS_RESUMEN_CLIENTES '" + Frm_Padre._Str_GroupComp + "','" + _G_Str_Cguiddesp + "', '0'";

            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            //Agregamos Totales
            var _Dbl_Total_MontoRetencion = 0.0;
            var _Dbl_Total_MontoNotasDeCredito = 0.0;
            var _Dbl_Total_MontoCheques = 0.0;
            var _Dbl_Total_MontoDepositos = 0.0;
            var _Dbl_Total_MontoCobrado = 0.0;

            _Ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(_Row =>
            {
                _Dbl_Total_MontoRetencion += Convert.ToDouble(_Row["MontoRetencion"]);
                _Dbl_Total_MontoNotasDeCredito += Convert.ToDouble(_Row["MontoNotasDeCredito"]);
                _Dbl_Total_MontoCheques += Convert.ToDouble(_Row["MontoCheques"]);
                _Dbl_Total_MontoDepositos += Convert.ToDouble(_Row["MontoDepositos"]);
                _Dbl_Total_MontoCobrado += Convert.ToDouble(_Row["MontoCobrado"]);
            });
            _Ds.Tables[0].Rows.Add(new object[] { "Totales", null, null, _Dbl_Total_MontoRetencion, _Dbl_Total_MontoNotasDeCredito, _Dbl_Total_MontoCheques, _Dbl_Total_MontoDepositos, _Dbl_Total_MontoCobrado });

            //Pasamos al Grid
            _Dg_Grid_Clientes.Columns.Clear();
            _Dg_Grid_Clientes.DataSource = _Ds.Tables[0];
            _Dg_Grid_Clientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _Dg_Grid_Clientes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid_Clientes.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid_Clientes.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid_Clientes.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid_Clientes.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid_Clientes.Columns[3].DefaultCellStyle.Format = "c";
            _Dg_Grid_Clientes.Columns[4].DefaultCellStyle.Format = "c";
            _Dg_Grid_Clientes.Columns[5].DefaultCellStyle.Format = "c";
            _Dg_Grid_Clientes.Columns[6].DefaultCellStyle.Format = "c";
            _Dg_Grid_Clientes.Columns[7].DefaultCellStyle.Format = "c";


            Cursor = Cursors.Default;
        }

        private void _Mtd_Actualizar_Cheques()
        {
            Cursor = Cursors.WaitCursor;

            //Cargamos los datos
            //var _Str_Cadena = "SELECT [Nº Cheque],[Banco],[Fecha],[Monto] FROM [VST_RC_INGRESADAS_RESUMEN_CHEQUES] WHERE cguiacobro='" + _G_Str_Cguiddesp + "'";
            var _Str_Cadena = "EXEC PA_RC_INGRESADAS_RESUMEN_CHEQUES '" + Frm_Padre._Str_GroupComp + "','" + _G_Str_Cguiddesp + "', '0'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            //Agregamos Totales
            var _Dbl_Total_Monto = 0.0;
            _Ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(_Row =>
            {
                _Dbl_Total_Monto += Convert.ToDouble(_Row["Monto"]);
            });
            _Ds.Tables[0].Rows.Add(new object[] { "Totales", null, null, _Dbl_Total_Monto});

            //Pasamos al Grid
            _Dg_Grid_Cheques.Columns.Clear();
            _Dg_Grid_Cheques.DataSource = _Ds.Tables[0];
            _Dg_Grid_Cheques.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _Dg_Grid_Cheques.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid_Cheques.Columns[3].DefaultCellStyle.Format = "c";
            Cursor = Cursors.Default;
        }

        private void _Mtd_Actualizar_Depositos()
        {
            Cursor = Cursors.WaitCursor;

            //Cargamos los datos
            //var _Str_Cadena = "SELECT [Nº Depósito],[Fecha],[Banco],[Cuenta],[Monto] FROM [VST_RC_INGRESADAS_RESUMEN_DEPOSITOS] WHERE cguiacobro='" + _G_Str_Cguiddesp + "'";
            var _Str_Cadena = "EXEC PA_RC_INGRESADAS_RESUMEN_DEPOSITOS '" + Frm_Padre._Str_GroupComp + "','" + _G_Str_Cguiddesp + "', '0'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            //Agregamos Totales
            var _Dbl_Total_Monto = 0.0;
            _Ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(_Row =>
            {
                _Dbl_Total_Monto += Convert.ToDouble(_Row["Monto"]);
            });
            _Ds.Tables[0].Rows.Add(new object[] { "Totales", null, null, null, _Dbl_Total_Monto });

            //Pasamos al Grid
            _Dg_Grid_Depositos.Columns.Clear();
            _Dg_Grid_Depositos.DataSource = _Ds.Tables[0];
            _Dg_Grid_Depositos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _Dg_Grid_Depositos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid_Depositos.Columns[4].DefaultCellStyle.Format = "c";

            Cursor = Cursors.Default;
        }

        private void _Mtd_Actualizar_Retenciones()
        {
            Cursor = Cursors.WaitCursor;

            //Cargamos los datos
            //var _Str_Cadena = "SELECT [Cliente],[Nº],[Tipo],[Nº Comprobante],[Monto Comprobante],[Nº Control],[Fecha Comprobante]  FROM [VST_RC_INGRESADAS_RESUMEN_RETENCIONES] WHERE cguiacobro='" + _G_Str_Cguiddesp + "'";
            var _Str_Cadena = "EXEC PA_RC_INGRESADAS_RESUMEN_RETENCIONES '" + Frm_Padre._Str_GroupComp + "','" + _G_Str_Cguiddesp + "', '0'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            //Agregamos Totales
            var _Dbl_Total_Monto = 0.0;
            _Ds.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(_Row =>
            {
                _Dbl_Total_Monto += Convert.ToDouble(_Row["Monto Comprobante"]);
            });
            _Ds.Tables[0].Rows.Add(new object[] { "Totales", null, null, null, _Dbl_Total_Monto, null, null });

            //Pasamos al Grid
            _Dg_Grid_Retenciones.Columns.Clear();
            _Dg_Grid_Retenciones.DataSource = _Ds.Tables[0];
            _Dg_Grid_Retenciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _Dg_Grid_Retenciones.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid_Retenciones.Columns[4].DefaultCellStyle.Format = "c";

            Cursor = Cursors.Default;
        }

        private void _Mtd_Actualizar_SobranteFaltante()
        {
            Cursor = Cursors.WaitCursor;

            //Cargamos los datos
            var _Str_Cadena = "EXEC PA_RC_INGRESADAS_RESUMEN_SOBRANTEFALTANTE '" + Frm_Padre._Str_GroupComp + "','" + _G_Str_Cguiddesp + "', '0'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            //Pasamos al Grid
            _Dg_Grid_SobranteFaltante.Columns.Clear();
            _Dg_Grid_SobranteFaltante.DataSource = _Ds.Tables[0];
            _Dg_Grid_SobranteFaltante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _Dg_Grid_SobranteFaltante.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid_SobranteFaltante.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid_SobranteFaltante.Columns[0].DefaultCellStyle.Format = "c";
            _Dg_Grid_SobranteFaltante.Columns[1].DefaultCellStyle.Format = "c";

            Cursor = Cursors.Default;
        }

        private void _Mtd_Actualizar_GuiasGeneradas()
        {
            Cursor = Cursors.WaitCursor;

            //Cargamos los datos
            var _Str_Cadena = "SELECT TRELACCOBM.cidrelacobro AS [Id Relación], (RTRIM(LTRIM(TCOMPANY.ccompany)) COLLATE database_default + ' - ' + RTRIM(LTRIM(TCOMPANY.cname)) COLLATE database_default) AS [Compañia] FROM TRELACCOBM INNER JOIN TCOMPANY ON TRELACCOBM.ccompany = TCOMPANY.ccompany WHERE (TRELACCOBM.cdelete = 0) AND (TRELACCOBM.cguiacobro = '" + _G_Str_Cguiddesp + "')";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            //Pasamos al Grid
            _Dg_Grid_GuiasGeneradas.Columns.Clear();
            _Dg_Grid_GuiasGeneradas.DataSource = _Ds.Tables[0];
            _Dg_Grid_GuiasGeneradas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Cursor = Cursors.Default;
        }

        private void _Dg_Grid_Clientes_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Llamada de Edicion a Formularios desarrollados por Angel
            //Variables a Pasar
            var _Str_ccliente = Convert.ToString(_Dg_Grid_Clientes.Rows[_Dg_Grid_Clientes.CurrentCell.RowIndex].Cells["Cliente"].Value);

            //Verificamos si se permite cargar la cobranza del cliente
            if (!Frm_RC_CobrosContraCamion._Mtd_EsPermitidoCargarCobranzaCliente(_Str_ccliente, _G_Str_Cguiddesp.ToString(CultureInfo.InvariantCulture)))
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Disculpe, el documento tiene un pago procesado por parte de su casa matriz, solo puede procesar pagos con el código de la casa matriz... verifique...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            //Verificamos
            Int64 _Int_ccliente = 0;
            var _Bol_ConversionCorrecta = Int64.TryParse(_Str_ccliente, out _Int_ccliente);
            if (!_Bol_ConversionCorrecta) return;
            //Llamamos al Formulario de Modo Modal
            var _Frm = new Frm_RC_DocumentosClientes(_G_Str_Cguiddesp.ToString(CultureInfo.InvariantCulture), _Str_ccliente, Cobranza.TiposEstadoRelacion.EstadoPagoEditando);
            _Frm.ShowDialog();
            //Verificamos el estado de la guia
            Cursor = Cursors.WaitCursor;
            var _Bool_GuiaVerificada = Clases._Cls_RutinasGuiasRelacionesCobranza._Mtd_EsValidaCobranza(Frm_Padre._Str_GroupComp, _G_Str_Cguiddesp.ToString(CultureInfo.InvariantCulture));
            if (!_Bool_GuiaVerificada)
            {
                //Desmarcamos la guia como cobrada
                var _Str_Cadena = "update TGUIADESPACHOM set cguiacobrada='0' where ((TGUIADESPACHOM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "') and (TGUIADESPACHOM.cguiadesp='" + _G_Str_Cguiddesp + "'));";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                Cursor = Cursors.Default;
                //Cerramos 
                Close();
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                //Asignamos los codigos de vendedor 
                _Cls_RutinasGuiasRelacionesCobranza._Mtd_AsignarCodigosDeVendedor(Frm_Padre._Str_GroupComp, _G_Str_Cguiddesp.ToString(CultureInfo.InvariantCulture));
                
                //Recargamos el resumen
                _Mtd_CargarResumen(_G_Str_Cguiddesp);
                Cursor = Cursors.Default;
            }
        }

        private void _Btn_Aprobar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de Aprobar la relación de cobranza?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _G_EstamosAprobando = true;
                _Lbl_Titulo.Text = "¿Esta seguro de Aprobar la relación de cobranza?";
                _Pnl_Clave.Parent = this;
                _Pnl_Clave.BringToFront();
                _Pnl_Clave.Visible = true;
                _Txt_Clave.Focus();
            }
        }

        private void _Btn_Rechazar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de rechazar la relación de cobranza?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _G_EstamosAprobando = false;
                _Lbl_Titulo.Text = "¿Esta seguro de rechazar la relación de cobranza?";
                _Pnl_Clave.Parent = this;
                _Pnl_Clave.BringToFront();
                _Pnl_Clave.Visible = true;
                _Txt_Clave.Focus();
            }
        }

        public bool _Mtd_SeEstaCerrandoCaja(int _P_Int_Cguiddesp)
        {
            try
            {
                //Por defecto nadie esta cerrando caja
                var _Bol_CierreCajaActivado = false;

                //Cargamos las compañias de la guia
                var _Str_Cadena = "SELECT ccompany FROM TRELACCOBM WHERE (cdelete = 0) AND (cguiacobro = '" + _P_Int_Cguiddesp + "')";
                var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                foreach (DataRow _Row in _Ds.Tables[0].Rows)
                {
                    var _Str_ccompany = _Row["ccompany"].ToString();
                    //Verificamos si se esta cerrando la caja para la compañia actual
                    _Str_Cadena = "SELECT ccerrando FROM TCAJACXC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + _Str_ccompany + "' AND ccerrada='0' AND ccerrando='1'";
                    var _Ds_CierreCaja = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds_CierreCaja.Tables[0].Rows.Count > 0)
                    {
                        _Bol_CierreCajaActivado = true;
                        break;
                    }
                }
                return _Bol_CierreCajaActivado;
            }
            catch
            {
                return false;
            }
        }

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (_MyUtilidad._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                //Estamos Aprobando
                if (_G_EstamosAprobando)
                {
                    //Verificamos si la caja esta cerrando
                    var _Bol_CierreCajaActivado = _Mtd_SeEstaCerrandoCaja(_G_Str_Cguiddesp);

                        //Tomamos el valor
                    if (_Bol_CierreCajaActivado)
                    {
                        MessageBox.Show("Se esta cerrando caja en otro equipo.\nNo es posible aprobar relaciones en estos momentos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // ====================================  MARCAMOS LAS GUIAS COMO APROBADAS  ====================================  

                        //cargamos la compañias de  la guia
                        var _Str_Cadena = "SELECT ccompany FROM TRELACCOBM WHERE (cdelete = 0) AND (cguiacobro = '" + _G_Str_Cguiddesp + "')";
                        var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        foreach (DataRow _Row in _Ds.Tables[0].Rows)
                        {
                            //Obtenemos los valores
                            var _Str_ccompany = _Row["ccompany"].ToString();
                            //Marcamos la relacion como aproba
                            _Str_Cadena = "UPDATE TRELACCOBM SET caprobadocredito = '1', cdateupd=getdate(), cuserupd='" + Frm_Padre._Str_Use + "' WHERE cguiacobro='" + _G_Str_Cguiddesp + "' AND ccompany = '" +
                                          _Str_ccompany + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        }

                        // ====================================  IMPRESION   ====================================  

                        //Obtenemos las relaciones que tenga generada  la guia
                        _Str_Cadena = "SELECT TRELACCOBM.cidrelacobro, TRELACCOBM.ccompany FROM TRELACCOBM  WHERE (TRELACCOBM.cdelete = 0) AND (TRELACCOBM.cguiacobro = '" + _G_Str_Cguiddesp + "')";
                        _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                        //Mensaje
                        if (_Ds.Tables[0].Rows.Count > 1) MessageBox.Show("Se van a proceder a imprimir los reporte de la relaciones de cobranza aprobadas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show("Se va a proceder a imprimir el reporte de la relación de cobranza aprobada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Recorremos
                        foreach (DataRow _Row in _Ds.Tables[0].Rows)
                        {
                            var _Str_cidrelacobro = _Row["cidrelacobro"].ToString();
                            var _Str_ccompany = _Row["ccompany"].ToString();
                            var _Str_NombCompany = _Mtd_NombComp(_Str_ccompany);
                            _ImprimirReporte:

                            //Mensaje
                            MessageBox.Show("Se va a imprimir el reporte de la relación #" + _Str_cidrelacobro + " de la companía " + _Str_NombCompany + " ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Imprimo
                            Cursor = Cursors.WaitCursor;
                            _Mtd_ImprimirReporte(Frm_Padre._Str_GroupComp, _Str_ccompany, "0", _Str_cidrelacobro, false);
                            Cursor = Cursors.Default;
                            //Confirmo que imprimio correctamente 
                            Cursor = Cursors.Default;
                            if (MessageBox.Show("¿El reporte de la relación #" + _Str_cidrelacobro + " se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                //Devuelvo
                                goto _ImprimirReporte;
                            }
                        }

                        // ====================================  TERMINADO   ====================================  

                    }
                }
                else
                {
                    //Borramos la relación de cobranza
                    _Mtd_BorrarRelacionesCobranzaSegunGuiaDespacho(_G_Str_Cguiddesp);
                }
                if (this.MdiParent != null)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre) this.MdiParent)._Frm_Contenedor._async_Default);
                }
                _Pnl_Clave.Visible = false;
                MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("La clave es incorrecta, intentelo de nuevo", "Clave Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Cursor = Cursors.Default;
        }

        private void _Mtd_BorrarRelacionesCobranzaSegunGuiaDespacho(int _P_Int_Cguiadesp)
        {
            //Obtenemos las relaciones segun la guia de despacho
            var _Str_Cadena = "SELECT cgroupcomp, ccompany,cidrelacobro FROM TRELACCOBM WHERE cguiacobro='" + _P_Int_Cguiadesp + "' AND cdelete='0'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                //Obtenemos los valores
                var _Str_cgroupcomp = _Row["cgroupcomp"].ToString();
                var _Str_ccompany = _Row["ccompany"].ToString();
                var _Str_cidrelacobro = _Row["cidrelacobro"].ToString();

                //Borramos las tablas verdaderas
                _Str_Cadena = "DELETE FROM TRELACCOBDCHEQ WHERE cgroupcomp='" + _Str_cgroupcomp + "' AND ccompany='" + _Str_ccompany + "' AND cidrelacobro='" + _Str_cidrelacobro + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "DELETE FROM TRELACCOBDDEPD WHERE cgroupcomp='" + _Str_cgroupcomp + "' AND ccompany='" + _Str_ccompany + "' AND cidrelacobro='" + _Str_cidrelacobro + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "DELETE FROM TRELACCOBDD WHERE cgroupcomp='" + _Str_cgroupcomp + "' AND ccompany='" + _Str_ccompany + "' AND cidrelacobro='" + _Str_cidrelacobro + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "DELETE FROM TRELACCOBDDEPM WHERE cgroupcomp='" + _Str_cgroupcomp + "' AND ccompany='" + _Str_ccompany + "' AND cidrelacobro='" + _Str_cidrelacobro + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "DELETE FROM TRELACCOBD WHERE cgroupcompany='" + _Str_cgroupcomp + "' AND ccompany='" + _Str_ccompany + "' AND cidrelacobro='" + _Str_cidrelacobro + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Str_Cadena = "DELETE FROM TRELACCOBM WHERE cgroupcomp='" + _Str_cgroupcomp + "' AND ccompany='" + _Str_ccompany + "' AND cidrelacobro='" + _Str_cidrelacobro + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }

            //Borramos tablas temporales de angel //OJO
            _Str_Cadena = "DELETE FROM TTRCDOCUMENTO WHERE cguia ='" + _P_Int_Cguiadesp + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "DELETE TABLITA FROM TTRCPAGOM INNER JOIN TTRCRETENCION AS TABLITA ON TTRCPAGOM.cidpago = TABLITA.cidpago WHERE(TTRCPAGOM.cguia = '" + _P_Int_Cguiadesp + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "DELETE TABLITA FROM TTRCPAGOM INNER JOIN TTRCNOTACREDD AS TABLITA ON TTRCPAGOM.cidpago = TABLITA.cidpago WHERE(TTRCPAGOM.cguia = '" + _P_Int_Cguiadesp + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "DELETE TABLITA FROM TTRCPAGOM INNER JOIN TTRCPAGOD AS TABLITA ON TTRCPAGOM.cidpago = TABLITA.cidpago WHERE(TTRCPAGOM.cguia = '" + _P_Int_Cguiadesp + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Str_Cadena = "DELETE TABLITA FROM TTRCPAGOM INNER JOIN TTRCPAGOM AS TABLITA ON TTRCPAGOM.cidpago = TABLITA.cidpago WHERE(TTRCPAGOM.cguia = '" + _P_Int_Cguiadesp + "')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

            //Marcamos la Guia como no CObrada
            _Str_Cadena = "UPDATE TGUIADESPACHOM SET cguiacobrada = '0' WHERE TGUIADESPACHOM.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TGUIADESPACHOM.cguiadesp='" + _P_Int_Cguiadesp + "' ";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

        }

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Btn_Imprimir_Click(object sender, EventArgs e)
        {
            //Obtenemos las relaciones que tenga generada  la guia
            var _Str_Cadena = "SELECT TRELACCOBM.cidrelacobro, TRELACCOBM.ccompany FROM TRELACCOBM  WHERE (TRELACCOBM.cdelete = 0) AND (TRELACCOBM.cguiacobro = '" + _G_Str_Cguiddesp + "')";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //Recorremos
            foreach (DataRow _Row in _Ds.Tables[0].Rows)
            {
                var _Str_cidrelacobro = _Row["cidrelacobro"].ToString();
                var _Str_ccompany = _Row["ccompany"].ToString();
                var _Str_NombCompany = _Mtd_NombComp(_Str_ccompany);
            _ImprimirReporte:
                //Mensaje
                MessageBox.Show("Se va a imprimir el reporte de la relación #" + _Str_cidrelacobro + " de la companía " + _Str_NombCompany + " ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Imprimo
                Cursor = Cursors.WaitCursor;
                _Mtd_ImprimirReporte(Frm_Padre._Str_GroupComp, _Str_ccompany, "0", _Str_cidrelacobro, true);
                Cursor = Cursors.Default;
                //Confirmo que imprimio correctamente 
                Cursor = Cursors.Default;
                if (MessageBox.Show("¿El reporte de verificación de la relación #" + _Str_cidrelacobro + " se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    //Devuelvo
                    goto _ImprimirReporte;
                }
            }
        }

        private static string _Mtd_NombComp(string _P_ccompany)
        {
            var _Str_Cadena = "Select cname from dbo.TCOMPANY WHERE ccompany='" + _P_ccompany + "' AND cdelete='0'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
            }
            return "";
        }


        public static void _Mtd_ImprimirReporte(string _P_Str_cgroupcompany, string _P_Str_ccompany, string _P_Str_Cguiddesp, string _P_Str_cidrelacobro, bool _P_Bol_EsVerificacion)
        {
            try
            {
                PrintDialog _Print = new PrintDialog();
                _PrintG:
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    string _Str_Cadena = "";
                    DataSet _Ds;
                    //Inicializamos el reporte
                    Report.rResumenCobranza _MyReport = new Report.rResumenCobranza();
                    //Cargamos los datos para el reporte principal
                    //_Str_Cadena = "SELECT * FROM VST_RC_REPORTE_MAESTRA WHERE cgroupcomp='" + _P_Str_cgroupcompany + "' AND ccompany='" + _P_Str_ccompany + "' AND cidrelacobro='" + _P_Str_cidrelacobro + "' AND cguiadesp='" + _P_Str_Cguiddesp + "'";
                    _Str_Cadena = "EXEC PA_RC_INGRESADAS_RESUMEN_MAESTRA '" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Cguiddesp + "', '" + _P_Str_cidrelacobro + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    _MyReport.SetDataSource(_Ds.Tables[0]);
                    //Recorremos y cargamos los datos para los subreportes
                    for (int _I = 0; _I < _MyReport.Subreports.Count; _I++)
                    {
                        if (_MyReport.Subreports[_I].Name == "CLIENTES_DOCUMENTOS")
                        {
                            //_Str_Cadena = "SELECT CONVERT(VARCHAR,[Cliente],103) AS [Cliente],[Nombre del Cliente],[Documento],[MontoRetencion],[MontoNotasDeCredito],[MontoCheques],[MontoDepositos],[MontoCobrado] FROM [VST_RC_INGRESADAS_RESUMEN_CLIENTES] WHERE cidrelacobro='" + _P_Str_cidrelacobro + "'";
                            _Str_Cadena = "EXEC PA_RC_INGRESADAS_RESUMEN_CLIENTES '" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Cguiddesp + "', '" + _P_Str_cidrelacobro + "'";
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                        }
                        else if (_MyReport.Subreports[_I].Name == "CHEQUES")
                        {
                            //_Str_Cadena = "SELECT [Nº Cheque],[Banco],[Fecha],[Monto] FROM [VST_RC_INGRESADAS_RESUMEN_CHEQUES] WHERE cidrelacobro='" + _P_Str_cidrelacobro + "'";
                            _Str_Cadena = "EXEC PA_RC_INGRESADAS_RESUMEN_CHEQUES '" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Cguiddesp + "', '" + _P_Str_cidrelacobro + "'";
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                        }
                        else if (_MyReport.Subreports[_I].Name == "DEPOSITOS")
                        {
                            //_Str_Cadena = "SELECT [Nº Depósito],[Fecha],[Banco],[Cuenta],[Monto] FROM [VST_RC_INGRESADAS_RESUMEN_DEPOSITOS] WHERE cidrelacobro='" + _P_Str_cidrelacobro + "'";
                            _Str_Cadena = "EXEC PA_RC_INGRESADAS_RESUMEN_DEPOSITOS '" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Cguiddesp + "', '" + _P_Str_cidrelacobro + "'";
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                        }
                        else if (_MyReport.Subreports[_I].Name == "RETENCIONES")
                        {
                            //_Str_Cadena = "SELECT [Cliente],[Nº],[Tipo],[Nº Comprobante],[Monto Comprobante],[Nº Control],[Fecha Comprobante]  FROM [VST_RC_INGRESADAS_RESUMEN_RETENCIONES] WHERE cidrelacobro='" + _P_Str_cidrelacobro + "'";
                            _Str_Cadena = "EXEC PA_RC_INGRESADAS_RESUMEN_RETENCIONES '" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Cguiddesp + "', '" + _P_Str_cidrelacobro + "'";
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                        }
                        else if (_MyReport.Subreports[_I].Name == "SOBRANTEFALTANTE")
                        {
                            //_Str_Cadena = "EXEC PA_RC_CALCULO_SOBRANTE_FALTANTE_GUIA '" + _P_Str_cgroupcompany + "', '0' ,'" + _P_Str_cidrelacobro + "'";
                            _Str_Cadena = "EXEC PA_RC_INGRESADAS_RESUMEN_SOBRANTEFALTANTE '" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Cguiddesp + "', '" + _P_Str_cidrelacobro + "'";
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                        }
                        else if (_MyReport.Subreports[_I].Name == "GUIASGENERADAS")
                        {
                            //_Str_Cadena = "SELECT TRELACCOBM.cidrelacobro AS [Id Relación], (RTRIM(LTRIM(TCOMPANY.ccompany)) COLLATE database_default + ' - ' + RTRIM(LTRIM(TCOMPANY.cname)) COLLATE database_default) AS [Compañia] FROM TRELACCOBM INNER JOIN TCOMPANY ON TRELACCOBM.ccompany = TCOMPANY.ccompany WHERE (TRELACCOBM.cdelete = 0) AND (TRELACCOBM.cguiacobro = '" + _G_Str_Cguiddesp + "')";
                            _Str_Cadena = "EXEC PA_RC_INGRESADAS_RESUMEN_GUIASGENERADAS '" + Frm_Padre._Str_GroupComp + "','" + _P_Str_Cguiddesp + "', '" + _P_Str_cidrelacobro + "'";
                            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                            _MyReport.Subreports[_I].SetDataSource(_Ds.Tables[0]);
                        }
                    }

                    //Ocultamos el subreporte Guias Generadas para cuando es por Guia
                    if (_P_Str_cidrelacobro != "0")
                    {
                        _MyReport.ReportDefinition.Sections["DetailSection5"].SectionFormat.EnableSuppress = true;
                    }

                    //Cambiamos los Titulos del Reporte
                    var _Txt_Titulo1 = "";
                    _Str_Cadena = "SELECT cname FROM TCOMPANY WHERE ccompany = '" + _P_Str_ccompany + "'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Txt_Titulo1 = _Ds.Tables[0].Rows[0]["cname"].ToString().Trim().ToUpper();
                    }

                    var _Txt_Titulo2 = "";
                    if (_P_Str_Cguiddesp != "0") //SI ES POR GUIA
                    {
                        _Txt_Titulo1 = "";
                        if (_P_Bol_EsVerificacion)
                            _Txt_Titulo2 = "(VERIFICACION) RESUMEN DE COBRANZA DE LA GUÍA #" + _P_Str_Cguiddesp;
                        else
                            _Txt_Titulo2 = "RESUMEN DE COBRANZA DE LA GUÍA #" + _P_Str_Cguiddesp;
                    }
                    else  //SI ES POR RELACION
                    {
                        if (_P_Bol_EsVerificacion)
                            _Txt_Titulo2 = "(VERIFICACION) RESUMEN DE COBRANZA DE LA RELACIÓN #" + _P_Str_cidrelacobro;
                        else
                            _Txt_Titulo2 = "RESUMEN DE COBRANZA DE LA RELACIÓN #" + _P_Str_cidrelacobro;
                    }

                    //Pasamos los valores del Titulo 1
                    var _TxtTitulo1 = _MyReport.ReportDefinition.Sections["Section2"].ReportObjects["Txt_Titulo1"] as TextObject;
                    _TxtTitulo1.Text = _Txt_Titulo1.ToUpper();

                    //Pasamos los valores del Titulo 2
                    var _TxtTitulo2 = _MyReport.ReportDefinition.Sections["Section2"].ReportObjects["Txt_Titulo2"] as TextObject;
                    _TxtTitulo2.Text = _Txt_Titulo2.ToUpper();




                    _MyReport.Refresh();

                    //---Configuración de impresión.
                    var _PageSettings = new System.Drawing.Printing.PageSettings();
                    _PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
                    _PageSettings.Landscape = false;
                    var _PrtSettings = new System.Drawing.Printing.PrinterSettings
                        {
                            PrinterName = _Print.PrinterSettings.PrinterName,
                            Copies = _Print.PrinterSettings.Copies,
                            Collate = _Print.PrinterSettings.Collate
                        };
                    _MyReport.PrintToPrinter(_PrtSettings, _PageSettings, false);
                    //---Configuración de impresión.
                    //_Frm.Close();
                    GC.Collect();
                }
            }
            catch (Exception _Ex)
            {
                MessageBox.Show(_Ex.Message);
            }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Layout_Principal.Enabled = false;
                _Txt_Clave.Text = "";
                _Txt_Clave.Focus();
            }
            else
            {
                _Layout_Principal.Enabled = true;
            }
        }
    }
}