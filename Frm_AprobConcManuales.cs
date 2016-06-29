using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using T3.Clases;

namespace T3
{
    public partial class Frm_AprobConcManuales : Form
    {
        private readonly CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        private readonly clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        private DataSet _G_Ds_BancoLibro = new DataSet();
        private Color _G_ColorInicialGrid;
        private readonly bool _G_Bol_PermisoAprobacion;
        private bool _G_EditandoFila;
        private int _G_Int_Cidconciliacion;
        private readonly int _G_Int_Banco;
        private readonly string _G_Str_Cnumcuenta;
        private readonly DateTime _G_Dt_FechaHasta;
        bool _Bol_MesContableCerrado = false;
        bool _Bol_TiposOperacionBancariaSinCuentaContable = false;
        private string _G_Str_PestañaActual = "";
        private bool _G_Bol_ModoGuardar = false;
        private int _G_Int_Tipo_Ajuste_Pestaña = 0;

        public enum EstadosAprobacion
        {
            EnEspera = 1,
            Aprobada,
            Rechazada
        }

        public enum Tipoajuste
        {
            SinAsignar = 0,
            UnoAUnoDiferenciaNumero = 1,
            UnoAUnoDiferenciaMonto,
            MultiplesAgrupamientoRegistros,
            MultiplesAgrupamientoRegistrosConDiferenciaMonto,
            MultiplesDivisionRegistros,
            MultiplesDivisionRegistrosConDiferenciaMonto,
            CruceMovimientosContables,
            CruceMovimientosBanco,
            ComisionesEIntereses,
            ComisionesEIntereses_Reverso,
            MuchosLibrosConMuchosBancos,
            MuchosLibrosConMuchosBancosConDiferenciaMonto
        }

        public Frm_AprobConcManuales(int _P_Int_IdConciliacion)
        {
            InitializeComponent();
            _G_Bol_PermisoAprobacion = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CONC_AJUSTES_APROBAR");

            //Asignamos los nombes a los Tabs
            foreach (TabPage _Tab_Actual in _Tabs_.TabPages)
            {
                var _Str_Nombre = _Mtd_GenerarColetillaConceptoComprobante(_Tab_Actual.Name);
                _Tab_Actual.Text = _Str_Nombre;
            }

            //Obtenemos los datos de la conciliacion
            var _Str_Sql = "SELECT * FROM TCONCILIACION WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND cidconciliacion = '" + _P_Int_IdConciliacion  + "'";
            var _G_Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_G_Ds.Tables[0].Rows.Count > 0)
            {
                _G_Int_Cidconciliacion = Convert.ToInt32(_G_Ds.Tables[0].Rows[0]["cidconciliacion"]);
                _G_Int_Banco = Convert.ToInt32(_G_Ds.Tables[0].Rows[0]["cbanco"]);
                _G_Str_Cnumcuenta = _G_Ds.Tables[0].Rows[0]["cnumcuenta"].ToString();
                _G_Dt_FechaHasta = Convert.ToDateTime(_G_Ds.Tables[0].Rows[0]["cfechahasta"]);
            }

        }

        private void _Mtd_LimpiarGrids()
        {
            //Setemos los grid vacios
            _Dtg_AjustesSimples.DataSource = null;
            _Dtg_AjustesMultiplesUnoBancoNLibro.DataSource = null;
            _Dtg_AjustesMultiplesUnoLibroNBanco.DataSource = null;
            _Dtg_AjustesCruceMovimientosLibro.DataSource = null;
            _Dtg_AjustesRedepositos.DataSource = null;
            _Dtg_AjustesComisionesInteresesReversos.DataSource = null;
            _Dtg_AjustesDepCheProvincialOtros.DataSource = null;

            //Removemos las Columnas 
            _Mtd_RemoverColumnasAgregadasManualmente(_Dtg_AjustesSimples);
            _Mtd_RemoverColumnasAgregadasManualmente(_Dtg_AjustesMultiplesUnoBancoNLibro);
            _Mtd_RemoverColumnasAgregadasManualmente(_Dtg_AjustesMultiplesUnoLibroNBanco);
            _Mtd_RemoverColumnasAgregadasManualmente(_Dtg_AjustesCruceMovimientosLibro);
            _Mtd_RemoverColumnasAgregadasManualmente(_Dtg_AjustesRedepositos);
            _Mtd_RemoverColumnasAgregadasManualmente(_Dtg_AjustesComisionesInteresesReversos);
            _Mtd_RemoverColumnasAgregadasManualmente(_Dtg_AjustesDepCheProvincialOtros);
        }

        private void _Mtd_RemoverColumnasAgregadasManualmente(DataGridView _P_Dtg)
        {
            if (_P_Dtg != null)
            {
                _P_Dtg.Columns.Clear();
            }
        }

        private void _Mtd_ActualizarFormulario()
        {
            _Mtd_LimpiarGrids();
            _Mtd_InicializarGrids();
            _Mtd_CargaDeDatos();
            if (_G_Ds_BancoLibro.Tables[0].Rows.Count <= 0)
            {
                //Si no hay datos Cerramos
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)MdiParent)._Frm_Contenedor._async_Default);
                Close();
            }
        }

        private void Frm_AprobConcManuales_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            _Mtd_InicializarGrids();
            _G_Bol_ModoGuardar = false;
            _Bt_Continuar.Visible = true;
            _Bt_GuardarCambios.Visible = false;
            _Mtd_CargaDeDatos();

            //Centramos
            _Pnl_Clave.Left = (Width/2) - (_Pnl_Clave.Width/2);
            _Pnl_Clave.Top = (Height/2) - (_Pnl_Clave.Height/2);
            _Bt_Continuar.Left = (Width / 2) - (_Bt_Continuar.Width / 2);
            _Bt_GuardarCambios.Left = (Width / 2) - (_Bt_GuardarCambios.Width / 2);

            _Bol_MesContableCerrado = false;
            _Bol_TiposOperacionBancariaSinCuentaContable = false;

            //Validacion del mes cerrado
            //Verificamos si el mes y año contable esta cerrado
            var _Str_Sql = "SELECT ccerrado FROM TMESCONTABLE WHERE ccerrado = 1 AND ccompany = '" + Frm_Padre._Str_Comp + "' AND cmontacco='" + _G_Dt_FechaHasta.Month.ToString(CultureInfo.InvariantCulture) + "' AND cyearacco='" + _G_Dt_FechaHasta.Year.ToString(CultureInfo.InvariantCulture) + "'";
            var _G_Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_G_Ds.Tables[0].Rows.Count > 0)
            {
                _Bol_MesContableCerrado = true;
            }

            //Validacion que existan las cuentas contables para los tipos de operaciones bancarias que generan ajustes automaticos
            //Verificamos si el mes y año contable esta cerrado
            _Str_Sql = "SELECT ISNULL(TOPERBANC.ccount,'') FROM TOPERBANC_GENERAAJUSTESAUTOMATICOS INNER JOIN TOPERBANC ON TOPERBANC_GENERAAJUSTESAUTOMATICOS.coperbanc = TOPERBANC.coperbanc WHERE (TOPERBANC.cdelete = 0) AND ISNULL(TOPERBANC.ccount,'')='' ";
            _G_Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_G_Ds.Tables[0].Rows.Count > 0)
            {
                _Bol_TiposOperacionBancariaSinCuentaContable = true;
            }
        }

        private void Frm_AprobConcManuales_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                //Validacion del mes cerrado
                if (_Bol_MesContableCerrado)
                {
                    MessageBox.Show("El Mes contable de la fecha (" + _G_Dt_FechaHasta.ToShortDateString() + ") a crear el comprobante está cerrado, no se puede crear el comprobante contable...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                }

                //Validacion que existan las cuentas contables para los tipos de operaciones bancarias que generan ajustes automaticos
                if (_Bol_TiposOperacionBancariaSinCuentaContable)
                {
                    MessageBox.Show("Existen tipos de operaciones bancarias a las cuales aún no les han sido asignadas las cuentas contables para generar los ajustes, no se puede crear el comprobante contable...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                }
            }
        }

        private void _Mtd_InicializarGrids()
        {
            //
            // - = - = - = - = - = - = - = - = - = - = - = - = - = - = Cargamos las Conciliaciones Manuales - = - = - = - = - = - = - = - = - = - = - = - = - = - = 
            //

            Cursor = Cursors.WaitCursor;

            _G_Ds_BancoLibro = new DataSet();

            //Genero la Consulta de Banco No Conciliado
            var _G_Str_SentenciaSqlBanco = "SELECT ";
            _G_Str_SentenciaSqlBanco += " char(251) as cseleccionado "; //00
            _G_Str_SentenciaSqlBanco += ", 'BANCO' as [Tip.Reg.]  "; //01
            _G_Str_SentenciaSqlBanco += ", cnumdocu as [Número Doc.] "; //02
            _G_Str_SentenciaSqlBanco += ", cdatemovi as [Fecha] "; //03
            _G_Str_SentenciaSqlBanco += ", '' as [Comprobante] "; //04
            _G_Str_SentenciaSqlBanco += ", cconcepto COLLATE DATABASE_DEFAULT as [Concepto] "; //05
            _G_Str_SentenciaSqlBanco += ", cname as [Tipo de Operación] "; //06
            _G_Str_SentenciaSqlBanco += ", dbo.Fnc_Formatear(cmontomov) AS Monto "; //07

            _G_Str_SentenciaSqlBanco += "FROM TCONCILIACIOND_MANUALV2 INNER JOIN VST_BANCONOCONCILIADO ";
            _G_Str_SentenciaSqlBanco += "ON TCONCILIACIOND_MANUALV2.ciddispbanc = VST_BANCONOCONCILIADO.cdispbanc ";
            _G_Str_SentenciaSqlBanco += "AND TCONCILIACIOND_MANUALV2.ciddispband = VST_BANCONOCONCILIADO.cdispband ";
            _G_Str_SentenciaSqlBanco += "AND '" + Frm_Padre._Str_Comp + "' = VST_BANCONOCONCILIADO.ccompany ";

            _G_Str_SentenciaSqlBanco += " WHERE ";
            _G_Str_SentenciaSqlBanco += " TCONCILIACIOND_MANUALV2.CCOMPANY='" + Frm_Padre._Str_Comp + "' ";
            _G_Str_SentenciaSqlBanco += " AND VST_BANCONOCONCILIADO.cbanco='-1' ";
            _G_Str_SentenciaSqlBanco += " AND ISNULL(TCONCILIACIOND_MANUALV2.cdelete,0)=0 ";

            //Instancio el DataSet Interno
            _G_Ds_BancoLibro = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSqlBanco);

            //Setemos los grid vacios
            _Dtg_AjustesSimples.DataSource = _G_Ds_BancoLibro.Tables[0];
            _Dtg_AjustesMultiplesUnoBancoNLibro.DataSource = _G_Ds_BancoLibro.Tables[0];
            _Dtg_AjustesMultiplesUnoLibroNBanco.DataSource = _G_Ds_BancoLibro.Tables[0];
            _Dtg_AjustesCruceMovimientosLibro.DataSource = _G_Ds_BancoLibro.Tables[0];
            _Dtg_AjustesRedepositos.DataSource = _G_Ds_BancoLibro.Tables[0];
            _Dtg_AjustesComisionesInteresesReversos.DataSource = _G_Ds_BancoLibro.Tables[0];
            _Dtg_AjustesDepCheProvincialOtros.DataSource = _G_Ds_BancoLibro.Tables[0];

            Cursor = Cursors.Default;
        }

        private void _Mtd_CargaDeDatos()
        {
            //
            // - = - = - = - = - = - = - = - = - = - = - = - = - = - = Cargamos las Conciliaciones Manuales - = - = - = - = - = - = - = - = - = - = - = - = - = - = 
            //

            var _G_Str_SentenciaSql = "";

            Cursor = Cursors.WaitCursor;

            _G_Ds_BancoLibro = new DataSet();

            //Genero la Consulta de registros por aprobar
            _G_Str_SentenciaSql += "SELECT * ";
            _G_Str_SentenciaSql += "FROM [VST_CONCILIACION_AJUSTES_PORAPROBAR] ";
            _G_Str_SentenciaSql += " WHERE ";
            _G_Str_SentenciaSql += " (CCOMPANY='" + Frm_Padre._Str_Comp + "') ";
            _G_Str_SentenciaSql += " AND (CCOMPANY2='" + Frm_Padre._Str_Comp + "') ";
            _G_Str_SentenciaSql += " AND (cbanco='" + _G_Int_Banco + "') ";
            _G_Str_SentenciaSql += " AND (cnumcuenta='" + _G_Str_Cnumcuenta + "') ";

            //Instancio el DataSet Interno
            _G_Ds_BancoLibro = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);

            //
            // - = - = - = - = - = - = - = - = - = - = - = - = - = - = Asignamos cada registro su tipo de ajuste correspondiente - = - = - = - = - = - = - = - = - = - = - = - = - = - = 
            //

            //Cargamos el DataSet en una variable local de trabajo
            var _G_Dt_BancoLibroNoConciliado = _G_Ds_BancoLibro.Tables[0];

            //Obtenemos si hay algun registro sin asignación de tipo de ajuste
            var _Int_CantidadRegistrosSinTipoAjuste = _G_Dt_BancoLibroNoConciliado.Select("ctipoajuste=0").Count();

            //Mientras haya registos sin tipo de ajuste asignado
            while (_Int_CantidadRegistrosSinTipoAjuste > 0)
            {
                //Cargamos le primero registro sin tipo de ajuste
                var _Dr_Registro = _G_Dt_BancoLibroNoConciliado.AsEnumerable().FirstOrDefault(x => x["ctipoajuste"].ToString() == "0");
                if (_Dr_Registro != null)
                {
                    //Obtenemos su ciddetalleconciliacion
                    var _Str_ciddetalleconciliacion = _Dr_Registro["ciddetalleconciliacion"].ToString();

                    //Obtenemos la cantidad de registros de banco y de libro cargados con esa ciddetalleconciliacion
                    var _Int_CantidadFilasSeleccionadasLibro = _G_Dt_BancoLibroNoConciliado.AsEnumerable().Where(x => x["ciddetalleconciliacion"].ToString() == _Str_ciddetalleconciliacion).Count(x => x["Tip.Reg."].ToString().ToUpper() == "LIBRO");
                    var _Int_CantidadFilasSeleccionadasBanco = _G_Dt_BancoLibroNoConciliado.AsEnumerable().Where(x => x["ciddetalleconciliacion"].ToString() == _Str_ciddetalleconciliacion).Count(x => x["Tip.Reg."].ToString().ToUpper() == "BANCO");
                    //Obtenemos la sumatoria de los registros
                    var _Dcm_SumatoriaLibro = _G_Dt_BancoLibroNoConciliado.AsEnumerable().Where(x => x["ciddetalleconciliacion"].ToString() == _Str_ciddetalleconciliacion && x["Tip.Reg."].ToString().ToUpper() == "LIBRO").Sum(x => Convert.ToDecimal(x["Monto"]));
                    var _Dcm_SumatoriaBanco = _Int_CantidadFilasSeleccionadasBanco == 0? 0 : _G_Dt_BancoLibroNoConciliado.AsEnumerable().Where(x => x["ciddetalleconciliacion"].ToString() == _Str_ciddetalleconciliacion && x["Tip.Reg."].ToString().ToUpper() == "BANCO").Sum(x => Convert.ToDecimal(x["Monto"]));
                    var _Dcm_Saldo = Math.Round(_Dcm_SumatoriaLibro - _Dcm_SumatoriaBanco, 2);

                    //En función a las cantidades defino el tipo de ajuste
                    var _Int_TipoAjuste = 0;
                    //Caso normal : 1 Libro <-> 1 Banco
                    if ((_Int_CantidadFilasSeleccionadasLibro == 1) && (_Int_CantidadFilasSeleccionadasBanco == 1))
                    {
                        if (_Dcm_Saldo == 0)
                            _Int_TipoAjuste = (int) Tipoajuste.UnoAUnoDiferenciaNumero;
                        else
                            _Int_TipoAjuste = (int)Tipoajuste.UnoAUnoDiferenciaMonto;
                    }
                    //Caso Multiple : >=2 Libro <-> 1 Banco
                    else if ((_Int_CantidadFilasSeleccionadasLibro >= 2) && (_Int_CantidadFilasSeleccionadasBanco == 1))
                    {
                        if (_Dcm_Saldo == 0)
                            _Int_TipoAjuste = (int)Tipoajuste.MultiplesAgrupamientoRegistros;
                        else
                            _Int_TipoAjuste = (int)Tipoajuste.MultiplesAgrupamientoRegistrosConDiferenciaMonto;
                    }
                    //Caso Multiple : 1 Libro <-> >=2 Banco
                    else if ((_Int_CantidadFilasSeleccionadasLibro == 1) && (_Int_CantidadFilasSeleccionadasBanco >= 2))
                    {
                        if (_Dcm_Saldo == 0)
                            _Int_TipoAjuste = (int)Tipoajuste.MultiplesDivisionRegistros;
                        else
                            _Int_TipoAjuste = (int)Tipoajuste.MultiplesDivisionRegistrosConDiferenciaMonto;
                    }
                    //Caso Multiple : >=2 Libro <-> 0 Banco
                    else if ((_Int_CantidadFilasSeleccionadasLibro >= 2) && (_Int_CantidadFilasSeleccionadasBanco == 0))
                    {
                        _Int_TipoAjuste = (int)Tipoajuste.CruceMovimientosContables;
                    }
                    //Caso Banco con Banco : 0 Libro <-> 2 Banco
                    else if ((_Int_CantidadFilasSeleccionadasLibro == 0) && (_Int_CantidadFilasSeleccionadasBanco == 2))
                    {
                        _Int_TipoAjuste = (int)Tipoajuste.CruceMovimientosBanco;
                    }
                    //Caso Comisiones e Intereses : 0 Libro <-> 1 Banco
                    else if ((_Int_CantidadFilasSeleccionadasLibro == 0) && (_Int_CantidadFilasSeleccionadasBanco == 1))
                    {
                        //Obtenemos el operbanc del registro de banco
                        var _RegistroBanco = _G_Dt_BancoLibroNoConciliado.AsEnumerable().Where(x => x["ciddetalleconciliacion"].ToString() == _Str_ciddetalleconciliacion && x["Tip.Reg."].ToString().ToUpper() == "BANCO").FirstOrDefault();
                        var _Str_coperbanc = "";
                        var _Bol_EsReverso = false;
                        if (_RegistroBanco != null)
                        {
                            var _Str_coperbanc_Original = _RegistroBanco["coperbancseleccionado"].ToString().ToUpper();

                            //Detectamos el coperbanc correspondiente y si viene o no con reverso
                            var _Int_Posicion = _Str_coperbanc_Original.IndexOf(_Cls_RutinasConciliacion._Str_Coletilla_Reverso);
                            if ((_Int_Posicion > 0))
                            {
                                _Bol_EsReverso = true;
                                _Str_coperbanc = _Str_coperbanc_Original.Substring(0, _Int_Posicion);
                            }
                            else
                            {
                                _Str_coperbanc = _Str_coperbanc_Original;
                            }
                        }
                        if (_Bol_EsReverso)
                            _Int_TipoAjuste = (int)Tipoajuste.ComisionesEIntereses_Reverso;
                        else
                            _Int_TipoAjuste = (int)Tipoajuste.ComisionesEIntereses;
                    }
                    //Caso Multiples Registros de Banco con Multiples registros de libro
                    else if ((_Int_CantidadFilasSeleccionadasLibro >= 2) && (_Int_CantidadFilasSeleccionadasBanco >= 2))
                    {
                        if (_Dcm_Saldo == 0)
                            _Int_TipoAjuste = (int)Tipoajuste.MuchosLibrosConMuchosBancos;
                        else
                            _Int_TipoAjuste = (int)Tipoajuste.MuchosLibrosConMuchosBancosConDiferenciaMonto;
                    }

                    //Verificacion
                    if (_Int_TipoAjuste == 0)
                    {
                        MessageBox.Show("Esto no debería pasar, por favor mande un Ticket con la captura de esta pantalla...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    //Asignamos el tipo de ajuste a los registros correspondientes
                    var _Registros = _G_Dt_BancoLibroNoConciliado.AsEnumerable().Where(z => z["ciddetalleconciliacion"].ToString() == _Str_ciddetalleconciliacion);
                    foreach (var _Registro in _Registros)
                    {
                        //Marco
                        _Registro["ctipoajuste"] = _Int_TipoAjuste;
                    }

                    //Añadimos el registro con el detalle de la diferencia
                    switch (_Int_TipoAjuste)
                    {
                        //Si pueden generar diferencia de monto
                        case (byte) Tipoajuste.UnoAUnoDiferenciaMonto:
                        case (byte) Tipoajuste.MultiplesAgrupamientoRegistrosConDiferenciaMonto:
                        case (byte) Tipoajuste.MultiplesDivisionRegistrosConDiferenciaMonto:
                        case (byte) Tipoajuste.MuchosLibrosConMuchosBancosConDiferenciaMonto:
                            if (Math.Abs(_Dcm_Saldo) > 0) _Mtd_AgregarRegistroDeDiferencia(ref _G_Dt_BancoLibroNoConciliado, _Str_ciddetalleconciliacion, _Dcm_Saldo, _Int_TipoAjuste);
                            break;
                        case (byte)Tipoajuste.UnoAUnoDiferenciaNumero:
                        case (byte)Tipoajuste.CruceMovimientosContables:
                        case (byte)Tipoajuste.MultiplesAgrupamientoRegistros:
                        case (byte)Tipoajuste.MultiplesDivisionRegistros:
                        case (byte)Tipoajuste.MuchosLibrosConMuchosBancos:
                        case (byte)Tipoajuste.CruceMovimientosBanco:
                        case (byte)Tipoajuste.ComisionesEIntereses:
                        case (byte)Tipoajuste.ComisionesEIntereses_Reverso:
                            break;
                    }

                }

                //Obtenemos si hay algun registro sin asignación de tipo de ajuste (para poder salir del bucle
                _Int_CantidadRegistrosSinTipoAjuste = _G_Dt_BancoLibroNoConciliado.Select("ctipoajuste=0").Count();
            }

            //
            // - = - = - = - = - = - = - = - = - = - = - = - = - = - = Cargamos los Grids - = - = - = - = - = - = - = - = - = - = - = - = - = - = 
            //

            //Filtramos
            var _Query_AjustesSimples = _G_Dt_BancoLibroNoConciliado.AsEnumerable().Where(x =>
                                                                                                   Convert.ToByte(x["ctipoajuste"]) == (byte)Tipoajuste.UnoAUnoDiferenciaNumero
                                                                                                || Convert.ToByte(x["ctipoajuste"]) == (byte)Tipoajuste.UnoAUnoDiferenciaMonto
                                                                                                   );
            var _Query_AjustesMultiplesUnoBancoNLibro = _G_Dt_BancoLibroNoConciliado.AsEnumerable().Where(x =>
                                                                                                   Convert.ToByte(x["ctipoajuste"]) == (byte)Tipoajuste.MultiplesAgrupamientoRegistros
                                                                                                || Convert.ToByte(x["ctipoajuste"]) == (byte)Tipoajuste.MultiplesAgrupamientoRegistrosConDiferenciaMonto
                                                                                                   );
            var _Query_AjustesMultiplesUnoLibroNBanco = _G_Dt_BancoLibroNoConciliado.AsEnumerable().Where(x =>
                                                                                                   Convert.ToByte(x["ctipoajuste"]) == (byte)Tipoajuste.MultiplesDivisionRegistros
                                                                                                || Convert.ToByte(x["ctipoajuste"]) == (byte)Tipoajuste.MultiplesDivisionRegistrosConDiferenciaMonto
                                                                                                   );
            var _Query_AjustesCruceMovimientosLibro = _G_Dt_BancoLibroNoConciliado.Select("ctipoajuste=" + (byte)Tipoajuste.CruceMovimientosContables);
            var _Query_AjustesRedepositos = _G_Dt_BancoLibroNoConciliado.Select("ctipoajuste=" + (byte)Tipoajuste.CruceMovimientosBanco);
            var _Query_AjustesComisionesInteresesReversos = _G_Dt_BancoLibroNoConciliado.AsEnumerable().Where(x =>
                                                                                                   Convert.ToByte(x["ctipoajuste"]) == (byte)Tipoajuste.ComisionesEIntereses
                                                                                                || Convert.ToByte(x["ctipoajuste"]) == (byte)Tipoajuste.ComisionesEIntereses_Reverso
                                                                                                   );
            var _Query_AjustesDepCheProvincialOtros = _G_Dt_BancoLibroNoConciliado.AsEnumerable().Where(x =>
                                                                                                   Convert.ToByte(x["ctipoajuste"]) == (byte)Tipoajuste.MuchosLibrosConMuchosBancos
                                                                                                || Convert.ToByte(x["ctipoajuste"]) == (byte)Tipoajuste.MuchosLibrosConMuchosBancosConDiferenciaMonto
                                                                                                   );
            //-------
            var _Dt_AjustesSimples = _Query_AjustesSimples.Any() ? _Query_AjustesSimples.CopyToDataTable() : null;
            var _Dt_AjustesMultiplesUnoBancoNLibro = _Query_AjustesMultiplesUnoBancoNLibro.Any() ? _Query_AjustesMultiplesUnoBancoNLibro.CopyToDataTable() : null;
            var _Dt_AjustesMultiplesUnoLibroNBanco = _Query_AjustesMultiplesUnoLibroNBanco.Any() ? _Query_AjustesMultiplesUnoLibroNBanco.CopyToDataTable() : null;
            var _Dt_AjustesCruceMovimientosLibro = _Query_AjustesCruceMovimientosLibro.Any() ? _Query_AjustesCruceMovimientosLibro.CopyToDataTable() : null;
            var _Dt_AjustesRedepositos = _Query_AjustesRedepositos.Any() ? _Query_AjustesRedepositos.CopyToDataTable() : null;
            var _Dt_AjustesComisionesInteresesReversos = _Query_AjustesComisionesInteresesReversos.Any() ? _Query_AjustesComisionesInteresesReversos.CopyToDataTable() : null;
            var _Dt_AjustesDepCheProvincialOtros = _Query_AjustesDepCheProvincialOtros.Any() ? _Query_AjustesDepCheProvincialOtros.CopyToDataTable() : null;

            //------- Cargamos  los grid
            _Mtd_MostrarGrid(_Dt_AjustesSimples, _Dtg_AjustesSimples);
            _Mtd_MostrarGrid(_Dt_AjustesMultiplesUnoBancoNLibro, _Dtg_AjustesMultiplesUnoBancoNLibro);
            _Mtd_MostrarGrid(_Dt_AjustesMultiplesUnoLibroNBanco, _Dtg_AjustesMultiplesUnoLibroNBanco);
            _Mtd_MostrarGrid(_Dt_AjustesCruceMovimientosLibro, _Dtg_AjustesCruceMovimientosLibro);
            _Mtd_MostrarGrid(_Dt_AjustesRedepositos, _Dtg_AjustesRedepositos);
            _Mtd_MostrarGrid(_Dt_AjustesComisionesInteresesReversos, _Dtg_AjustesComisionesInteresesReversos);
            _Mtd_MostrarGrid(_Dt_AjustesDepCheProvincialOtros, _Dtg_AjustesDepCheProvincialOtros);

            // - = - = - = - = - = - = - = - = - = - = - = - = - = - = Ocultamos los gris sin registros - = - = - = - = - = - = - = - = - = - = - = - = - = - = 
            //if (_Dtg_AjustesSimples.Rows.Count == 0)
            //    _Tabs_.TabPages.RemoveByKey("_Tab_AjustesSimples");
            //if (_Dtg_AjustesMultiplesUnoBancoNLibro.Rows.Count == 0)
            //    _Tabs_.TabPages.RemoveByKey("_Tab_AjustesMultiplesUnoBancoNLibro");
            //if (_Dtg_AjustesMultiplesUnoLibroNBanco.Rows.Count == 0)
            //    _Tabs_.TabPages.RemoveByKey("_Tab_AjustesMultiplesUnoLibroNBanco");
            //if (_Dtg_AjustesCruceMovimientosLibro.Rows.Count == 0)
            //    _Tabs_.TabPages.RemoveByKey("_Tab_AjustesCruceMovimientosLibro");
            //if (_Dtg_AjustesRedepositos.Rows.Count == 0)
            //    _Tabs_.TabPages.RemoveByKey("_Tab_AjustesRedepositos");
            //if (_Dtg_AjustesComisionesInteresesReversos.Rows.Count == 0)
            //    _Tabs_.TabPages.RemoveByKey("_Tab_AjustesComisionesInteresesReversos");
            //if (_Dtg_AjustesDepCheProvincialOtros.Rows.Count == 0)
            //    _Tabs_.TabPages.RemoveByKey("_Tab_AjustesDepCheProvincialOtros");

            // - = - = - = - = - = - = - = - = - = - = - = - = - = - = Seleccionamos el primero grid que tenga algun ajuste - = - = - = - = - = - = - = - = - = - = - = - = - = - = 
            if (_Dtg_AjustesSimples.Rows.Count > 0)
                _Tabs_.SelectTab("_Tab_AjustesSimples");
            else if (_Dtg_AjustesMultiplesUnoBancoNLibro.Rows.Count > 0)
                _Tabs_.SelectTab("_Tab_AjustesMultiplesUnoBancoNLibro");
            else if (_Dtg_AjustesMultiplesUnoLibroNBanco.Rows.Count > 0)
                _Tabs_.SelectTab("_Tab_AjustesMultiplesUnoLibroNBanco");
            else if (_Dtg_AjustesCruceMovimientosLibro.Rows.Count > 0)
                _Tabs_.SelectTab("_Tab_AjustesCruceMovimientosLibro");
            else if (_Dtg_AjustesRedepositos.Rows.Count > 0)
                _Tabs_.SelectTab("_Tab_AjustesRedepositos");
            else if (_Dtg_AjustesComisionesInteresesReversos.Rows.Count > 0)
                _Tabs_.SelectTab("_Tab_AjustesComisionesInteresesReversos");
            else if (_Dtg_AjustesDepCheProvincialOtros.Rows.Count > 0)
                _Tabs_.SelectTab("_Tab_AjustesDepCheProvincialOtros");

            //
            // - = - = - = - = - = - = - = - = - = - = - = - = - = - = Formateamos los Grids - = - = - = - = - = - = - = - = - = - = - = - = - = - = 
            //
            //Coloreamos
            _Mtd_ColorearRegistros();
            //Quitamos el Ordenamiento
            _Mtd_QuitarOrdenamiento();

            Cursor = Cursors.Default;
        }

        private void _Mtd_AgregarRegistroDeDiferencia(ref DataTable _P_Dt, string _P_Str_ciddetalleconciliacion, decimal _P_Dcm_Diferencia, int _P_Int_TipoAjuste)
        {
            //Creamos el objeto
            var _Registro = _P_Dt.NewRow();
            //Pasamos los datos
            _Registro["Tipo de Operación"] = "Diferencia:";
            _Registro["Monto"] = _P_Dcm_Diferencia.ToString("#,##0.00");
            _Registro["ciddetalleconciliacion"] = _P_Str_ciddetalleconciliacion;
            _Registro["ctipoajuste"] = _P_Int_TipoAjuste;
            _Registro["estadoaprobacion"] = (byte) EstadosAprobacion.EnEspera;
            _Registro["Tip.Reg."] = "";
            _Registro["cidconciliaciondmanual"] = "0";
            //Agregamos el nuevo registro
            _P_Dt.Rows.Add(_Registro);
        }

        /// <summary>
        ///  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
        /// </summary>
        private void _Mtd_MostrarGrid(DataTable _P_Dt_Registros, DataGridView _P_Dtw_Grid)
        {
            //Verifico
            if (_P_Dt_Registros == null)
            {
                //Limpiamos el grid
                _P_Dtw_Grid.DataSource = null;
                return;
            }

            //Pasamos a la Variable local
            var _Dt_Registros = _P_Dt_Registros;

            //Ordenamos solo si hay datos
            if (_Dt_Registros.Rows.Count > 0)
            {
                _Dt_Registros = _Dt_Registros.AsEnumerable()
                                             .OrderByDescending(n => n["ciddetalleconciliacion"])
                                             .ThenByDescending(p => p["Tip.Reg."])
                                             .CopyToDataTable();
            }

            //Paso el Dataset Actualizado al Datagrid
            _P_Dtw_Grid.DataSource = _Dt_Registros.DefaultView;

            //Configuramos los anchos de cada columna
            _P_Dtw_Grid.Columns[1].Width = 50;
            _P_Dtw_Grid.Columns[2].Width = 120;
            _P_Dtw_Grid.Columns[3].Width = 80;
            _P_Dtw_Grid.Columns[4].Width = 110;
            _P_Dtw_Grid.Columns[5].Width = 210;
            _P_Dtw_Grid.Columns[6].Width = 110;
            _P_Dtw_Grid.Columns[7].Width = 110;
            _P_Dtw_Grid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _P_Dtw_Grid.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Ocultamos las columnasinternas
            _P_Dtw_Grid.Columns[0].Visible = false;
            _P_Dtw_Grid.Columns[8].Visible = false;
            _P_Dtw_Grid.Columns[9].Visible = false;
            _P_Dtw_Grid.Columns[10].Visible = false;
            _P_Dtw_Grid.Columns[11].Visible = false;
            _P_Dtw_Grid.Columns[12].Visible = false;
            _P_Dtw_Grid.Columns[13].Visible = false;
            _P_Dtw_Grid.Columns[14].Visible = false;
            _P_Dtw_Grid.Columns[15].Visible = false;
            _P_Dtw_Grid.Columns[16].Visible = false;
            _P_Dtw_Grid.Columns[17].Visible = false;
            _P_Dtw_Grid.Columns[18].Visible = false;
            _P_Dtw_Grid.Columns[19].Visible = false;
            _P_Dtw_Grid.Columns[20].Visible = false;
            _P_Dtw_Grid.Columns[21].Visible = false;
            _P_Dtw_Grid.Columns[22].Visible = false;
            _P_Dtw_Grid.Columns[23].Visible = false;
            _P_Dtw_Grid.Columns[24].Visible = false;
            _P_Dtw_Grid.Columns[25].Visible = false;
            _P_Dtw_Grid.Columns[26].Visible = false;
            _P_Dtw_Grid.Columns[27].Visible = false;
            if (_P_Dtw_Grid.Rows.Count > 0)
            {
                _G_ColorInicialGrid = _P_Dtw_Grid.Rows[0].DefaultCellStyle.BackColor;
            }

            //Ponemos el solo lectura
            _P_Dtw_Grid.Columns[0].ReadOnly = true;
            _P_Dtw_Grid.Columns[1].ReadOnly = true;
            _P_Dtw_Grid.Columns[2].ReadOnly = true;
            _P_Dtw_Grid.Columns[3].ReadOnly = true;
            _P_Dtw_Grid.Columns[4].ReadOnly = true;
            _P_Dtw_Grid.Columns[5].ReadOnly = true;
            _P_Dtw_Grid.Columns[6].ReadOnly = true;
            _P_Dtw_Grid.Columns[7].ReadOnly = true;
            _P_Dtw_Grid.Columns[8].ReadOnly = true;
            _P_Dtw_Grid.Columns[9].ReadOnly = true;
            _P_Dtw_Grid.Columns[10].ReadOnly = true;
            _P_Dtw_Grid.Columns[11].ReadOnly = true;
            _P_Dtw_Grid.Columns[12].ReadOnly = true;
            _P_Dtw_Grid.Columns[13].ReadOnly = true;
            _P_Dtw_Grid.Columns[14].ReadOnly = true;
            _P_Dtw_Grid.Columns[15].ReadOnly = true;
            _P_Dtw_Grid.Columns[16].ReadOnly = true;
            _P_Dtw_Grid.Columns[17].ReadOnly = true;
            _P_Dtw_Grid.Columns[18].ReadOnly = true;
            _P_Dtw_Grid.Columns[19].ReadOnly = true;
            _P_Dtw_Grid.Columns[20].ReadOnly = true;
            _P_Dtw_Grid.Columns[21].ReadOnly = true;
            _P_Dtw_Grid.Columns[22].ReadOnly = true;
            _P_Dtw_Grid.Columns[23].ReadOnly = true;
            _P_Dtw_Grid.Columns[24].ReadOnly = true;
            _P_Dtw_Grid.Columns[25].ReadOnly = true;
            _P_Dtw_Grid.Columns[26].ReadOnly = true;
            _P_Dtw_Grid.Columns[27].ReadOnly = true;

            //Añadimos los Checkboxes
            var _OColumnaAprobar = new DataGridViewCheckBoxColumn
                {
                    Name = "Aprobar",
                    HeaderText = "Aprob.",
                    Width = 50,
                    ReadOnly = false,
                    FillWeight = 10
                };
            var _OColumnaRechazar = new DataGridViewCheckBoxColumn
                {
                    Name = "Rechazar",
                    HeaderText = "Recha.",
                    Width = 50,
                    ReadOnly = false,
                    FillWeight = 10
                };

            _P_Dtw_Grid.Columns.Add(_OColumnaAprobar);
            _P_Dtw_Grid.Columns.Add(_OColumnaRechazar);

        }

        private void _Dtg_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var _Dtg = (DataGridView)sender;
            if (_Dtg.SelectedRows.Count == 1)
            {
                _Mtd_MarcarRegistrosConciliados(_Dtg.Rows[e.RowIndex].Cells["ciddetalleconciliacion"].Value.ToString(), _Dtg);
            }
        }

        private void _Mtd_MarcarRegistrosConciliados(string _P_Str_Ciddetalleconciliacion, DataGridView _P_Dtw_Grid)
        {
            //Si selecciono u registro que no esta conciliado no hago nada
            if (_P_Str_Ciddetalleconciliacion == "0") return;

            //Borro el marcado de registros
            _P_Dtw_Grid.ClearSelection();

            //Selecciono las filas 
            var _Dtg_Registros = _P_Dtw_Grid.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["ciddetalleconciliacion"].Value.ToString() == _P_Str_Ciddetalleconciliacion).ToList();
            if (_Dtg_Registros.Count > 0)
            {
                foreach (DataGridViewRow _Dgvr in _Dtg_Registros)
                {
                    _Dgvr.Selected = true;
                }
                _P_Dtw_Grid.FirstDisplayedScrollingRowIndex = _Dtg_Registros[0].Index;
                _P_Dtw_Grid.Refresh();
            }
        }

        private void Frm_AprobConcManuales_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            if (!_Pnl_Clave.Visible)
            {
                ((Frm_Padre) MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            }
            ((Frm_Padre) MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
            ((Frm_Padre) MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            ((Frm_Padre) MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            ((Frm_Padre) MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
        }

        private void Frm_AprobConcManuales_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Mtd_ColorearRegistros()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                _Dtg_AjustesSimples.SuspendLayout();
                _Dtg_AjustesMultiplesUnoBancoNLibro.SuspendLayout();
                _Dtg_AjustesMultiplesUnoLibroNBanco.SuspendLayout();
                _Dtg_AjustesCruceMovimientosLibro.SuspendLayout();
                _Dtg_AjustesRedepositos.SuspendLayout();
                _Dtg_AjustesComisionesInteresesReversos.SuspendLayout();
                _Dtg_AjustesDepCheProvincialOtros.SuspendLayout();

                // ========================================================== AjustesSimples ==========================================================
                //Selecciono cada combo en función al grid
                foreach (DataGridViewRow _Fila in _Dtg_AjustesSimples.Rows)
                {
                    //Obtengo los valores
                    string _EstadoAprobacion = _Fila.Cells["estadoaprobacion"].Value.ToString();
                    //Verifico
                    if (_EstadoAprobacion != "")
                    {
                        switch (Convert.ToInt32(_EstadoAprobacion))
                        {
                            case (byte)EstadosAprobacion.Aprobada:
                                _Fila.DefaultCellStyle.BackColor = Color.GreenYellow;
                                break;
                            case (byte)EstadosAprobacion.Rechazada:
                                _Fila.DefaultCellStyle.BackColor = Color.Pink;
                                break;
                            case (byte)EstadosAprobacion.EnEspera:
                                _Fila.DefaultCellStyle.BackColor = _G_ColorInicialGrid;
                                break;
                        }
                    }
                    else
                    {
                        _Fila.DefaultCellStyle.BackColor = _G_ColorInicialGrid;
                    }
                }

                // ========================================================== AjustesMultiplesUnoBancoNLibro ==========================================================
                //Selecciono cada combo en función al grid
                foreach (DataGridViewRow _FilaMonto in _Dtg_AjustesMultiplesUnoBancoNLibro.Rows)
                {
                    //Obtengo los valores
                    string _EstadoAprobacionMonto = _FilaMonto.Cells["estadoaprobacion"].Value.ToString();
                    //Verifico
                    if (_EstadoAprobacionMonto != "")
                    {
                        switch (Convert.ToInt32(_EstadoAprobacionMonto))
                        {
                            case (byte)EstadosAprobacion.Aprobada:
                                _FilaMonto.DefaultCellStyle.BackColor = Color.GreenYellow;
                                break;
                            case (byte)EstadosAprobacion.Rechazada:
                                _FilaMonto.DefaultCellStyle.BackColor = Color.Pink;
                                break;
                            case (byte)EstadosAprobacion.EnEspera:
                                _FilaMonto.DefaultCellStyle.BackColor = _G_ColorInicialGrid;
                                break;
                        }
                    }
                    else
                    {
                        _FilaMonto.DefaultCellStyle.BackColor = _G_ColorInicialGrid;
                    }
                }

                // ========================================================== AjustesMultiplesUnoLibroNBanco ==========================================================
                //Selecciono cada combo en función al grid
                foreach (DataGridViewRow _FilaMonto in _Dtg_AjustesMultiplesUnoLibroNBanco.Rows)
                {
                    //Obtengo los valores
                    string _EstadoAprobacionMonto = _FilaMonto.Cells["estadoaprobacion"].Value.ToString();
                    //Verifico
                    if (_EstadoAprobacionMonto != "")
                    {
                        switch (Convert.ToInt32(_EstadoAprobacionMonto))
                        {
                            case (byte)EstadosAprobacion.Aprobada:
                                _FilaMonto.DefaultCellStyle.BackColor = Color.GreenYellow;
                                break;
                            case (byte)EstadosAprobacion.Rechazada:
                                _FilaMonto.DefaultCellStyle.BackColor = Color.Pink;
                                break;
                            case (byte)EstadosAprobacion.EnEspera:
                                _FilaMonto.DefaultCellStyle.BackColor = _G_ColorInicialGrid;
                                break;
                        }
                    }
                    else
                    {
                        _FilaMonto.DefaultCellStyle.BackColor = _G_ColorInicialGrid;
                    }
                }

                // ========================================================== AjustesCruceMovimientosLibro ==========================================================
                //Selecciono cada combo en función al grid
                foreach (DataGridViewRow _FilaMonto in _Dtg_AjustesCruceMovimientosLibro.Rows)
                {
                    //Obtengo los valores
                    string _EstadoAprobacionMonto = _FilaMonto.Cells["estadoaprobacion"].Value.ToString();
                    //Verifico
                    if (_EstadoAprobacionMonto != "")
                    {
                        switch (Convert.ToInt32(_EstadoAprobacionMonto))
                        {
                            case (byte)EstadosAprobacion.Aprobada:
                                _FilaMonto.DefaultCellStyle.BackColor = Color.GreenYellow;
                                break;
                            case (byte)EstadosAprobacion.Rechazada:
                                _FilaMonto.DefaultCellStyle.BackColor = Color.Pink;
                                break;
                            case (byte)EstadosAprobacion.EnEspera:
                                _FilaMonto.DefaultCellStyle.BackColor = _G_ColorInicialGrid;
                                break;
                        }
                    }
                    else
                    {
                        _FilaMonto.DefaultCellStyle.BackColor = _G_ColorInicialGrid;
                    }
                }

                // ========================================================== AjustesRedepositos ==========================================================
                //Selecciono cada combo en función al grid
                foreach (DataGridViewRow _FilaMonto in _Dtg_AjustesRedepositos.Rows)
                {
                    //Obtengo los valores
                    string _EstadoAprobacionMonto = _FilaMonto.Cells["estadoaprobacion"].Value.ToString();
                    //Verifico
                    if (_EstadoAprobacionMonto != "")
                    {
                        switch (Convert.ToInt32(_EstadoAprobacionMonto))
                        {
                            case (byte)EstadosAprobacion.Aprobada:
                                _FilaMonto.DefaultCellStyle.BackColor = Color.GreenYellow;
                                break;
                            case (byte)EstadosAprobacion.Rechazada:
                                _FilaMonto.DefaultCellStyle.BackColor = Color.Pink;
                                break;
                            case (byte)EstadosAprobacion.EnEspera:
                                _FilaMonto.DefaultCellStyle.BackColor = _G_ColorInicialGrid;
                                break;
                        }
                    }
                    else
                    {
                        _FilaMonto.DefaultCellStyle.BackColor = _G_ColorInicialGrid;
                    }
                }

                // ========================================================== AjustesComisionesInteresesReversos ==========================================================
                //Selecciono cada combo en función al grid
                foreach (DataGridViewRow _FilaMonto in _Dtg_AjustesComisionesInteresesReversos.Rows)
                {
                    //Obtengo los valores
                    string _EstadoAprobacionMonto = _FilaMonto.Cells["estadoaprobacion"].Value.ToString();
                    //Verifico
                    if (_EstadoAprobacionMonto != "")
                    {
                        switch (Convert.ToInt32(_EstadoAprobacionMonto))
                        {
                            case (byte)EstadosAprobacion.Aprobada:
                                _FilaMonto.DefaultCellStyle.BackColor = Color.GreenYellow;
                                break;
                            case (byte)EstadosAprobacion.Rechazada:
                                _FilaMonto.DefaultCellStyle.BackColor = Color.Pink;
                                break;
                            case (byte)EstadosAprobacion.EnEspera:
                                _FilaMonto.DefaultCellStyle.BackColor = _G_ColorInicialGrid;
                                break;
                        }
                    }
                    else
                    {
                        _FilaMonto.DefaultCellStyle.BackColor = _G_ColorInicialGrid;
                    }
                }

                // ========================================================== AjustesDepCheProvincialOtros ==========================================================
                //Selecciono cada combo en función al grid
                foreach (DataGridViewRow _FilaMonto in _Dtg_AjustesDepCheProvincialOtros.Rows)
                {
                    //Obtengo los valores
                    string _EstadoAprobacionMonto = _FilaMonto.Cells["estadoaprobacion"].Value.ToString();
                    //Verifico
                    if (_EstadoAprobacionMonto != "")
                    {
                        switch (Convert.ToInt32(_EstadoAprobacionMonto))
                        {
                            case (byte)EstadosAprobacion.Aprobada:
                                _FilaMonto.DefaultCellStyle.BackColor = Color.GreenYellow;
                                break;
                            case (byte)EstadosAprobacion.Rechazada:
                                _FilaMonto.DefaultCellStyle.BackColor = Color.Pink;
                                break;
                            case (byte)EstadosAprobacion.EnEspera:
                                _FilaMonto.DefaultCellStyle.BackColor = _G_ColorInicialGrid;
                                break;
                        }
                    }
                    else
                    {
                        _FilaMonto.DefaultCellStyle.BackColor = _G_ColorInicialGrid;
                    }
                }

                _Dtg_AjustesSimples.ResumeLayout();
                _Dtg_AjustesMultiplesUnoBancoNLibro.ResumeLayout();
                _Dtg_AjustesMultiplesUnoLibroNBanco.ResumeLayout();
                _Dtg_AjustesCruceMovimientosLibro.ResumeLayout();
                _Dtg_AjustesRedepositos.ResumeLayout();
                _Dtg_AjustesComisionesInteresesReversos.ResumeLayout();
                _Dtg_AjustesDepCheProvincialOtros.ResumeLayout();
                Cursor = Cursors.Default;
            }
            catch (Exception)
            {
                _Dtg_AjustesSimples.ResumeLayout();
                _Dtg_AjustesMultiplesUnoBancoNLibro.ResumeLayout();
                _Dtg_AjustesMultiplesUnoLibroNBanco.ResumeLayout();
                _Dtg_AjustesCruceMovimientosLibro.ResumeLayout();
                _Dtg_AjustesRedepositos.ResumeLayout();
                _Dtg_AjustesComisionesInteresesReversos.ResumeLayout();
                _Dtg_AjustesDepCheProvincialOtros.ResumeLayout();
                Cursor = Cursors.Default;
            }
        }

        private void _Mtd_QuitarOrdenamiento()
        {
            foreach (DataGridViewColumn _Columna in _Dtg_AjustesSimples.Columns)
            {
                _Columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn _Columna in _Dtg_AjustesMultiplesUnoBancoNLibro.Columns)
            {
                _Columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn _Columna in _Dtg_AjustesMultiplesUnoLibroNBanco.Columns)
            {
                _Columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn _Columna in _Dtg_AjustesCruceMovimientosLibro.Columns)
            {
                _Columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn _Columna in _Dtg_AjustesRedepositos.Columns)
            {
                _Columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn _Columna in _Dtg_AjustesComisionesInteresesReversos.Columns)
            {
                _Columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn _Columna in _Dtg_AjustesDepCheProvincialOtros.Columns)
            {
                _Columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void _Mtd_GuardarFormulario()
        {
            //Si no hay pestaña de trabajo salimos
            if (_G_Str_PestañaActual == "") return;

            //Validaciones
            if (_Mtd_HayRegistrosRegistrosEnEsperaSegunPestaña(_G_Str_PestañaActual))
            {
                MessageBox.Show("Existen Registros a la Espera de Aprobación o Rechazo, por favor verifique...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //Guardo el Comprobante
            if (!_Mtd_TodosLosRegistrosNoGenerarComprobanteSegunPestaña(_G_Str_PestañaActual))
            {
                //Guardamos el Comprobante
                var _Str_Comprobante = _Mtd_GuardarComprobante();
                //Actualizo los Registros
                _Mtd_ActualizarRegistros(_G_Str_PestañaActual);
                //Imprimimos el Comprobante
                _Mtd_ImprimirComprobante(_Str_Comprobante);
            }
            //Actualizo los Registros
            _Mtd_ActualizarRegistros(_G_Str_PestañaActual);

            //Actualizamos el formulario
            _Mtd_ActualizarFormulario();
        }

        private void _Mtd_ActualizarRegistros(string _P_Str_NombrePestaña)
        {
            //Obtenemos los tipos de ajuste segun la pestaña actual
            var _Lst_TiposAjuste = _Mtd_ObtenerTiposDeAjusteSegunPestaña(_P_Str_NombrePestaña);            

            //Si no hay tipos de ajuste salimos
            if (_Lst_TiposAjuste.Count == 0) return;
            
            //Guardamos
            //Obtenemos todos los ciddetalleconciliacion distintos para su procesamiento
            var _Lst_DetalleAprobacion = _G_Ds_BancoLibro.Tables[0]
                                                         .AsEnumerable()
                                                         .Where(x => _Lst_TiposAjuste.Any(y => y.ToString(CultureInfo.InvariantCulture) == x["ctipoajuste"].ToString()))
                                                         .Select(x => Convert.ToInt32(x["ciddetalleconciliacion"]))
                                                         .Distinct()
                                                         .ToList();

            //Por cada ciddetalleconciliacion
            foreach (var _DetalleAprobacion in _Lst_DetalleAprobacion)
            {
                //Cargamos los registros que pertenecen al ciddetalleconciliacion actual
                var _Int_ciddetalleconciliacion = _DetalleAprobacion;

                //Obtenemos el estado de Aprobacion
                var _Int_EstadoAprobacion = (int)_G_Ds_BancoLibro.Tables[0].AsEnumerable().First(x => Convert.ToInt32(x["ciddetalleconciliacion"]) == _Int_ciddetalleconciliacion)["estadoaprobacion"];

                //Cargamos todos los registros del ciddetalleconciliacion
                var _Registros = _G_Ds_BancoLibro.Tables[0].AsEnumerable().Where(x => Convert.ToInt32(x["ciddetalleconciliacion"]) == _Int_ciddetalleconciliacion);

                //Recorremos los registros
                foreach (DataRow _Registro in _Registros)
                {
                    //Obtenemos el tipo de registro
                    var _Str_TipoRegistro = _Registro["Tip.Reg."].ToString();
                    
                    //En función al estado de aprobación
                    if (_Int_EstadoAprobacion == (int)EstadosAprobacion.Aprobada) //Aprobacion
                    {

                        //Obtenemos el cidconciliaciondmanual
                        var _Int_cidconciliaciondmanual = Convert.ToInt32(_Registro["cidconciliaciondmanual"]);

                        var _Str_ctiporegistro = "";

                        //Si es banco
                        _Str_ctiporegistro = _Str_TipoRegistro == "BANCO" ?  
                                             ((byte) Clases._Cls_RutinasConciliacion._TipoRegistro.NoAplica).ToString(CultureInfo.InvariantCulture) :
                                             ((byte)Clases._Cls_RutinasConciliacion._TipoRegistro.Original).ToString(CultureInfo.InvariantCulture) ;


                        //string _Str_Sql = "";
                        //Apruebo el Detalle esto lo coloco de ultimo por si hay algun intermedio sabemos donde quedo el marcaje
                        var _Str_Sql = "UPDATE TCONCILIACIOND_MANUALV2 " +
                                       "SET caprobado = '1'" +
                                       ",ctiporegistro='" + _Str_ctiporegistro + "'" +
                                       ",cdateupd=getdate()" +
                                       ",cuserupd='" + Frm_Padre._Str_Use + "'" +
                                       " WHERE cidconciliaciondmanual = " + _Int_cidconciliaciondmanual;
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        
                        if (_G_Int_Tipo_Ajuste_Pestaña != 6)
                        {
                            var _G_Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select cidcomprob, corder, ccompany from TCONCILIACIOND_MANUALV2 where cidconciliaciondmanual = " + _Int_cidconciliaciondmanual);
                            if (_G_Ds.Tables[0].Rows.Count > 0)
                            {
                                var _Int_Id_Comprobante = Convert.ToInt32(_G_Ds.Tables[0].Rows[0]["cidcomprob"]);
                                var _Int_Order = Convert.ToInt32(_G_Ds.Tables[0].Rows[0]["corder"]);
                                var _Str_Cod_Compañia = _G_Ds.Tables[0].Rows[0]["ccompany"].ToString();
                                _G_Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("select TCONCILIACIOND_MANUALV2.cidcomprob_nuevo, TCONCILIACIOND_MANUALV2.corder_nuevo, tcuentbanc.ccount from TCONCILIACIOND_MANUALV2 " +
                                                                                             "inner join tconciliacion on TCONCILIACIOND_MANUALV2.cidconciliacion = tconciliacion.cidconciliacion " +
                                                                                             "inner join tcuentbanc on TCONCILIACIOND_MANUALV2.ccompany = tcuentbanc.ccompany and tconciliacion.cbanco = tcuentbanc.cbanco and tconciliacion.cnumcuenta = tcuentbanc.cnumcuenta " +
                                                                                             "where TCONCILIACIOND_MANUALV2.cidcomprob_nuevo = " + _Int_Id_Comprobante + " and TCONCILIACIOND_MANUALV2.corder_nuevo = " + _Int_Order + " AND TCONCILIACIOND_MANUALV2.ccompany='" + _Str_Cod_Compañia + "' and TCONCILIACIOND_MANUALV2.ctipoajuste = 9 and TCONCILIACIOND_MANUALV2.ctiporegistro = 1");
                                if (_G_Ds.Tables[0].Rows.Count > 0)
                                {
                                    var _Int_Id_Comprobante_Nuevo = Convert.ToInt32(_G_Ds.Tables[0].Rows[0]["cidcomprob_nuevo"]);
                                    var _Int_Order_Nuevo = Convert.ToInt32(_G_Ds.Tables[0].Rows[0]["corder_nuevo"]);
                                    var _Str_Cuenta_Contable = _G_Ds.Tables[0].Rows[0]["ccount"].ToString();
                                    Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("update tcomproband set cconciliado = 1 where cidcomprob = " + _Int_Id_Comprobante_Nuevo + " AND corder = " + _Int_Order_Nuevo + " and CCOUNT = '" + _Str_Cuenta_Contable + "'");
                                }
                            }                            
                        }

                    }
                    else if (_Int_EstadoAprobacion == (int)EstadosAprobacion.Rechazada) //Rechazo
                    {
                        //var _strCandena3 = "DELETE FROM TCONCILIACIOND_MANUALV2 WHERE cidconciliaciondmanual = " + _Registro["cidconciliaciondmanual"];
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia("DELETE FROM TCONCILIACIOND_MANUALV2 WHERE cidconciliaciondmanual = " + _Registro["cidconciliaciondmanual"]);
                    }
                }
            }
        }

        private void _Bt_Continuar_Click(object sender, EventArgs e)
        {
            //Asignamos la Pestaña con el cual se esta trabajando
            _G_Str_PestañaActual = _Tabs_.SelectedTab.Name;
            _G_Bol_ModoGuardar = false;

            //Valido que no hayan conciliaciones por aprobar que no sean cruces 
            if (_Mtd_HayRegistrosRegistrosEnEsperaSegunPestaña(_G_Str_PestañaActual))
            {
                _G_Str_PestañaActual = "";
                _G_Bol_ModoGuardar = false;
                MessageBox.Show("Existen Registros a la Espera de Aprobación o Rechazo, por favor verifique...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //Solo si hay aprobaciones que genere un comprobante 
            if (!_Mtd_TodosLosRegistrosNoGenerarComprobanteSegunPestaña(_G_Str_PestañaActual))
            {
                _G_Bol_ModoGuardar = true;
                _Mtd_VisualizarComprobante();
                _Tabs_.SelectTab("_Tab_ComprobanteContable");
            }
            else
            {
                //Todos son rechazos o todos no generan comprobante contable
                _G_Bol_ModoGuardar = true;
                _Mtd_VisualizarComprobanteNoComprobante();
                _Tabs_.SelectTab("_Tab_ComprobanteContable");
            }
        }

        private void _Mtd_VisualizarComprobanteNoComprobante()
        {
            _Txt_EncabezadoComprobante.Text = "AJUSTES NO GENERAN COMPROBANTE";
            _Txt_EncabezadoComprobante.ReadOnly = true;
        }

        private string _Mtd_Obtiene_Cuenta_Contable_DB(string _P_Str_Proceso, int _P_Int_IdProceso)
        {
            var _Str_SQL = "select ccount from TPROCESOSCONTD where cidproceso = '" + _P_Str_Proceso + "' and cideprocesod = " + _P_Int_IdProceso;
            var _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            string _Str_Cuenta = "";

            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
            {
                _Str_Cuenta = _Ds_DataSet.Tables[0].Rows[0]["ccount"].ToString();
            }
            return _Str_Cuenta;
        }


        private double _Mtd_Aplica_Debito_Bancario()
        {
            var _Str_SQL = "select cdebitobancario, cporcentdebitobancario from tconfigconssa";
            var _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            double _Dbl_Procentaje = 0; 

            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToInt16(_Ds_DataSet.Tables[0].Rows[0]["cdebitobancario"]) == 1)
                {
                    _Dbl_Procentaje= Convert.ToDouble(_Ds_DataSet.Tables[0].Rows[0]["cporcentdebitobancario"]);
                }
            }
            return _Dbl_Procentaje;
        }
       
       private string _Mtd_GenerarColetillaConceptoComprobante(string _P_Str_NombrePestaña)
       {
           var _Str_ = "";
           switch (_P_Str_NombrePestaña)
           {
               case "_Tab_AjustesSimples":
                   _Str_ = "SIMPLES UNO BANCO UNO LIBRO";
                   break;
               case "_Tab_AjustesMultiplesUnoBancoNLibro":
                   _Str_ = "MUTIPLES UNO BANCO VARIOS LIBRO";
                   break;
               case "_Tab_AjustesMultiplesUnoLibroNBanco":
                   _Str_ = "MUTIPLES UNO LIBRO VARIOS BANCO";
                   break;
               case "_Tab_AjustesCruceMovimientosLibro":
                   _Str_ = "CRUCE MOVIMIENTOS CONTABLES";
                   break;
               case "_Tab_AjustesRedepositos":
                   _Str_ = "REDEPOSITOS";
                   break;
               case "_Tab_AjustesComisionesInteresesReversos":
                   _Str_ = "COMISIONES INTERESES Y REVERSOS";
                   break;
               case "_Tab_AjustesDepCheProvincialOtros":
                   _Str_ = "DEP. EN CHEQ. PROVIN. Y OTROS";
                   break;
               case "_Tab_ComprobanteContable":
                   _Str_ = "COMPROBANTE CONTABLE";
                   break;
           }
           return _Str_;
       }
        private string _Mtd_GenerarConceptoComprobante(string _P_Str_NombrePestaña)
        {
            var _Str_ = "";
            var _Str_Nombre = _Mtd_GenerarColetillaConceptoComprobante(_P_Str_NombrePestaña);
            switch (_P_Str_NombrePestaña)
            {
                case "_Tab_AjustesSimples":
                    _Str_ = "AJUSTES CONTABLES " + _Str_Nombre + " CONC. " + _G_Int_Cidconciliacion;
                    break;
                case "_Tab_AjustesMultiplesUnoBancoNLibro":
                    _Str_ = "AJUSTES CONTABLES " + _Str_Nombre + " CONC. " + _G_Int_Cidconciliacion;
                    break;
                case "_Tab_AjustesMultiplesUnoLibroNBanco":
                    _Str_ = "AJUSTES CONTABLES " + _Str_Nombre + " CONC. " + _G_Int_Cidconciliacion;
                    break;
                case "_Tab_AjustesCruceMovimientosLibro":
                    _Str_ = "AJUSTES CONTABLES " + _Str_Nombre + " CONC. " + _G_Int_Cidconciliacion;
                    break;
                case "_Tab_AjustesRedepositos":
                    _Str_ = "AJUSTES CONTABLES " + _Str_Nombre + " CONC. " + _G_Int_Cidconciliacion;
                    break;
                case "_Tab_AjustesComisionesInteresesReversos":
                    _Str_ = "AJUSTES CONTABLES " + _Str_Nombre + " CONC. " + _G_Int_Cidconciliacion;
                    break;
                case "_Tab_AjustesDepCheProvincialOtros":
                    _Str_ = "AJUSTES CONTABLES " + _Str_Nombre + " CONC. " + _G_Int_Cidconciliacion;
                    break;
            }
            return _Str_;
        }

        /// <summary>
        /// Obtiene los tipos de ajuste segun la pestaña actual
        /// </summary>
        /// <param name="_P_Str_NombrePestaña"></param>
        /// <returns></returns>
        private List<int> _Mtd_ObtenerTiposDeAjusteSegunPestaña(string _P_Str_NombrePestaña)
        {
            var _Lst_ = new List<int>();
            switch (_P_Str_NombrePestaña)
            {
                case "_Tab_AjustesSimples":
                    _Lst_.Add((byte) Tipoajuste.UnoAUnoDiferenciaNumero);
                    _Lst_.Add((byte) Tipoajuste.UnoAUnoDiferenciaMonto);
                    _G_Int_Tipo_Ajuste_Pestaña = 1;
                    break;
                case "_Tab_AjustesMultiplesUnoBancoNLibro":
                    _Lst_.Add((byte) Tipoajuste.MultiplesAgrupamientoRegistros);
                    _Lst_.Add((byte)Tipoajuste.MultiplesAgrupamientoRegistrosConDiferenciaMonto);
                    _G_Int_Tipo_Ajuste_Pestaña = 2;
                    break;
                case "_Tab_AjustesMultiplesUnoLibroNBanco":
                    _Lst_.Add((byte) Tipoajuste.MultiplesDivisionRegistros);
                    _Lst_.Add((byte)Tipoajuste.MultiplesDivisionRegistrosConDiferenciaMonto);
                    _G_Int_Tipo_Ajuste_Pestaña = 3;
                    break;
                case "_Tab_AjustesCruceMovimientosLibro":
                    _Lst_.Add((byte) Tipoajuste.CruceMovimientosContables);
                    _G_Int_Tipo_Ajuste_Pestaña = 4;
                    break;
                case "_Tab_AjustesRedepositos":
                    _Lst_.Add((byte) Tipoajuste.CruceMovimientosBanco);
                    _G_Int_Tipo_Ajuste_Pestaña = 5;
                    break;
                case "_Tab_AjustesComisionesInteresesReversos":
                    _Lst_.Add((byte) Tipoajuste.ComisionesEIntereses);
                    _Lst_.Add((byte)Tipoajuste.ComisionesEIntereses_Reverso);
                    _G_Int_Tipo_Ajuste_Pestaña = 6;
                    break;
                case "_Tab_AjustesDepCheProvincialOtros":
                    _Lst_.Add((byte) Tipoajuste.MuchosLibrosConMuchosBancos);
                    _Lst_.Add((byte)Tipoajuste.MuchosLibrosConMuchosBancosConDiferenciaMonto);
                    _G_Int_Tipo_Ajuste_Pestaña = 7;
                    break;
            }
            return _Lst_;
        }

        private void _Mtd_VisualizarComprobante()
        {
            //Solo si estamos en una pestaña que permite visualizar comprobante
            if (_G_Str_PestañaActual == "_Tab_ComprobanteContable") return;
            
            //Obtenemos los tipos de ajuste segun la pestaña actual
            var _Lst_TiposAjuste = _Mtd_ObtenerTiposDeAjusteSegunPestaña(_G_Str_PestañaActual);

            //Si no hay tipos de ajuste salimos
            if (_Lst_TiposAjuste.Count == 0) return;

            //Mostramos la descripción del comprobante a generar
            _Txt_EncabezadoComprobante.Text = _Mtd_GenerarConceptoComprobante(_G_Str_PestañaActual);

            //Limpiamos el grid
            _Dtg_Comprobante.Rows.Clear();

            //Obtenemos todos los ciddetalleconciliacion distintos para su procesamiento
            var _Lst_DetalleAprobacion = _G_Ds_BancoLibro.Tables[0]
                                                         .AsEnumerable()
                                                         .Where(x => Convert.ToByte(x["estadoaprobacion"]) == (byte) EstadosAprobacion.Aprobada)
                                                         .Where(x => _Lst_TiposAjuste.Any(y => y.ToString(CultureInfo.InvariantCulture) == x["ctipoajuste"].ToString()))
                                                         .Select(x => Convert.ToInt32(x["ciddetalleconciliacion"]))
                                                         .Distinct()
                                                         .ToList();

            //Por cada ciddetalleconciliacion
            foreach (var _DetalleAprobacion in _Lst_DetalleAprobacion)
            {

                //Cargamos los registros que pertenecen al ciddetalleconciliacion actual
                var _Int_ciddetalleconciliacion = _DetalleAprobacion;

                //Obtenemos el tipo de ajuste 
                var _Int_TipoAjuste = (int) _G_Ds_BancoLibro.Tables[0].AsEnumerable().First(x => Convert.ToInt32(x["ciddetalleconciliacion"]) == _Int_ciddetalleconciliacion)["ctipoajuste"];

                //Obtenemos el registro del LIBRO y BANCO
                var _RegistrosLIBRO = _G_Ds_BancoLibro.Tables[0].AsEnumerable().Where(x => Convert.ToInt32(x["ciddetalleconciliacion"]) == _Int_ciddetalleconciliacion && x["Tip.Reg."].ToString() == "LIBRO").ToList();
                var _RegistrosBANCO = _G_Ds_BancoLibro.Tables[0].AsEnumerable().Where(x => Convert.ToInt32(x["ciddetalleconciliacion"]) == _Int_ciddetalleconciliacion && x["Tip.Reg."].ToString() == "BANCO").ToList();
                var _Dbl_TotalRegistrosLIBRO = _RegistrosLIBRO.Sum(x => Convert.ToDouble(x["Monto"]));
                var _Dbl_TotalRegistrosBANCO = _RegistrosBANCO.Sum(x => Convert.ToDouble(x["Monto"]));

                //Si hay registros
                if (_RegistrosLIBRO.Any() || _RegistrosBANCO.Any())
                {
                    // = -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= - Rutina Principal de Generacion de Ajustes  = -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -
                    var _Str_ccompany = Frm_Padre._Str_Comp;

                    //= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= - RECORREMOS LOS REGISTROS LIBRO  = -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -= -
                    foreach (var _RegLibro in _RegistrosLIBRO)
                    {
                        //Varibles de Trabajo
                        var _Str_cidcomprob = _RegLibro["cidcomprob"].ToString();
                        var _Str_corder = _RegLibro["corder"].ToString();
                        var _Str_Concepto = _RegLibro["Concepto"].ToString();
                        //Cargamos los Registros Originales del libro
                        var _Str_SentenciaSQL = "SELECT * FROM TCOMPROBAND WHERE CCOMPANY='" + _Str_ccompany + "' AND CIDCOMPROB='" + _Str_cidcomprob + "' AND CORDER='" + _Str_corder + "'";
                        var _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                        //Si existe
                        if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                        {
                            //Obtenemos los otros datos necesarios
                            var _Str_cnumdocu = _Ds_DataSet.Tables[0].Rows[0]["cnumdocu"].ToString();
                            var _Str_cdescrip = _Ds_DataSet.Tables[0].Rows[0]["cdescrip"].ToString();
                            var _Str_ccount = _Ds_DataSet.Tables[0].Rows[0]["ccount"].ToString();
                            var _Dbl_ctotdebe = Convert.ToDouble(_Ds_DataSet.Tables[0].Rows[0]["ctotdebe"]);
                            var _Dbl_ctothaber = Convert.ToDouble(_Ds_DataSet.Tables[0].Rows[0]["ctothaber"]);
                            var _Dbl_Monto = Math.Round(_Dbl_ctotdebe - _Dbl_ctothaber, 2);
                            var _Str_ctdocument = _Ds_DataSet.Tables[0].Rows[0]["ctdocument"].ToString();

                            //Obtenemos el registro del auxiliar
                            _Str_SentenciaSQL = "SELECT * FROM TCOMPROBANDD WHERE CCOMPANY='" + _Str_ccompany + "' AND CIDCOMPROB='" + _Str_cidcomprob + "' AND CORDER='" + _Str_corder + "' AND CCOUNT = '" + _Str_ccount + "'";
                            var _Ds_DataSetAuxiliar = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                            var _Bool_TieneAuxiliar = _Ds_DataSetAuxiliar.Tables[0].Rows.Count > 0;
                            var _Str_cidauxiliarcont = _Ds_DataSetAuxiliar.Tables[0].Rows.Count > 0 ? _Ds_DataSetAuxiliar.Tables[0].Rows[0]["cidauxiliarcont"].ToString() : "";

                            // = -= -= -= -= -= -= -= -= -= -= -= - OBTENEMOS LOS DATOS NECESARIOS DEL BANCO = -= -= -= -= -= -= -= -= -= -= -= - 

                            //Obtengo los valores nuevos desde el registro correspondiente de BANCo
                            var _Str_NumeroDocumentoNuevo = "";
                            var _Str_ConceptoNuevo = "";

                            var _RegBanco = _RegistrosBANCO.FirstOrDefault();
                            if (_RegBanco != null)
                            {
                                _Str_NumeroDocumentoNuevo = _RegBanco["Número Doc."].ToString();
                                _Str_ConceptoNuevo = _RegBanco["Concepto"].ToString();
                            }

                            var _Str_Coletilla = " (REV.)";

                            //Generamos el Asiento de Reverso
                            //Exceptuando los cruces que no generan reversos de libros
                            switch (_Int_TipoAjuste)
                            {
                                    //SI generan Registro de Reverso
                                case (byte) Tipoajuste.UnoAUnoDiferenciaNumero:
                                case (byte) Tipoajuste.UnoAUnoDiferenciaMonto:
                                case (byte) Tipoajuste.MultiplesAgrupamientoRegistros:
                                case (byte) Tipoajuste.MultiplesAgrupamientoRegistrosConDiferenciaMonto:
                                case (byte) Tipoajuste.MultiplesDivisionRegistros:
                                case (byte) Tipoajuste.MultiplesDivisionRegistrosConDiferenciaMonto:
                                case (byte)Tipoajuste.MuchosLibrosConMuchosBancos:
                                case (byte)Tipoajuste.MuchosLibrosConMuchosBancosConDiferenciaMonto:
                                    _Mtd_Proceso_GenerarAsientoReverso(_Dtg_Comprobante, _Int_TipoAjuste, _Str_ccount, _Str_Concepto, _Dbl_Monto, _Bool_TieneAuxiliar, _Str_cidauxiliarcont, _Str_ctdocument, _Str_cnumdocu, _Int_ciddetalleconciliacion.ToString(CultureInfo.InvariantCulture), _Str_ConceptoNuevo, _Str_NumeroDocumentoNuevo, _Str_Coletilla);
                                    break;

                                    //NO generan Registro de Reverso
                                case (byte) Tipoajuste.CruceMovimientosContables:
                                case (byte) Tipoajuste.CruceMovimientosBanco:
                                case (byte)Tipoajuste.ComisionesEIntereses:
                                case (byte)Tipoajuste.ComisionesEIntereses_Reverso:
                                    break;
                            }

                        }
                    }

                    // - = - = - = - = - = En funcion al tipo de ajuste - = - = - = - = - = - =
                    switch (_Int_TipoAjuste)
                    {
                        case (byte)Tipoajuste.UnoAUnoDiferenciaNumero:
                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 

                            //Obtenemos lo datos del registro original
                            //Varibles de Trabajo
                            var _RegLibro = _RegistrosLIBRO.First();
                            var _Str_cidcomprob = _RegLibro["cidcomprob"].ToString();
                            var _Str_corder = _RegLibro["corder"].ToString();
                            var _Str_ccountcname = _RegLibro["CuentaDescripcion"].ToString();
                            var _Str_cidconciliaciondmanual = _RegLibro["cidconciliaciondmanual"].ToString();
                            var _Str_CuentaDiferenciaNumero = _RegLibro["CuentaNumero"].ToString();
                            var _Str_CuentaDiferenciaDescripcion = _RegLibro["CuentaDescripcion"].ToString();
                            //Cargamos los Registros Originales del libro
                            var _Str_SentenciaSQL = "SELECT * FROM TCOMPROBAND WHERE CCOMPANY='" + _Str_ccompany + "' AND CIDCOMPROB='" + _Str_cidcomprob + "' AND CORDER='" + _Str_corder + "'";
                            var _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                            //Si existe
                            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                            {
                                //Obtenemos los otros datos necesarios
                                var _Str_cnumdocu = _Ds_DataSet.Tables[0].Rows[0]["cnumdocu"].ToString();
                                var _Str_cdescrip = _Ds_DataSet.Tables[0].Rows[0]["cdescrip"].ToString();
                                var _Str_ccount = _Ds_DataSet.Tables[0].Rows[0]["ccount"].ToString();
                                var _Dbl_ctotdebe = Convert.ToDouble(_Ds_DataSet.Tables[0].Rows[0]["ctotdebe"]);
                                var _Dbl_ctothaber = Convert.ToDouble(_Ds_DataSet.Tables[0].Rows[0]["ctothaber"]);
                                var _Str_ctdocument = _Ds_DataSet.Tables[0].Rows[0]["ctdocument"].ToString();
                                var _Dbl_Monto = Math.Round(_Dbl_ctotdebe - _Dbl_ctothaber, 2);

                                //Obtenemos el registro del auxiliar
                                _Str_SentenciaSQL = "SELECT * FROM TCOMPROBANDD WHERE CCOMPANY='" + _Str_ccompany + "' AND CIDCOMPROB='" + _Str_cidcomprob + "' AND CORDER='" + _Str_corder + "' AND CCOUNT = '" +
                                                    _Str_ccount + "'";
                                var _Ds_DataSetAuxiliar = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                                var _Bool_TieneAuxiliar = _Ds_DataSetAuxiliar.Tables[0].Rows.Count > 0;
                                var _Str_cidauxiliarcont = _Ds_DataSetAuxiliar.Tables[0].Rows.Count > 0 ? _Ds_DataSetAuxiliar.Tables[0].Rows[0]["cidauxiliarcont"].ToString() : "";

                                // = -= -= -= -= -= -= -= -= -= -= -= - OBTENEMOS LOS DATOS NECESARIOS DEL BANCO = -= -= -= -= -= -= -= -= -= -= -= - 

                                //Obtengo los valores nuevos desde el registro correspondiente de BANCO
                                var _Str_NumeroDocumentoNuevo = "";
                                var _Str_ConceptoNuevo = "";
                                var _Dbl_MontoNuevo = 0.0;

                                var _RegBanco = _RegistrosBANCO.FirstOrDefault();
                                if (_RegBanco != null)
                                {
                                    _Str_NumeroDocumentoNuevo = _RegBanco["Número Doc."].ToString();
                                    _Str_ConceptoNuevo = _RegBanco["Concepto"].ToString();
                                    _Dbl_MontoNuevo = Math.Round(Convert.ToDouble(_RegBanco["Monto"]), 2);

                                }

                                // = -= -= -= -= -= -= -= -= -= -= -= - GENERAMOS ASIENTOS = -= -= -= -= -= -= -= -= -= -= -= - 
                                
                                //Generamos el Asiento Nuevo
                                var _Str_Coletilla = " (DIF.NUM)";
                                _Mtd_Proceso_GenerarAsientoNuevo(_Dtg_Comprobante, _Int_TipoAjuste, _Str_ccount, _Str_ccountcname, _Dbl_Monto, _Bool_TieneAuxiliar, _Str_cidauxiliarcont, _Str_ctdocument, _Str_NumeroDocumentoNuevo, _Str_cidconciliaciondmanual, _Str_ConceptoNuevo, _Str_NumeroDocumentoNuevo, _Int_ciddetalleconciliacion.ToString(CultureInfo.InvariantCulture), ((byte)Clases._Cls_RutinasConciliacion._TipoRegistro.Nuevo).ToString(CultureInfo.InvariantCulture), _Str_Coletilla);
                            }

                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 
                            break;

                        case (byte)Tipoajuste.UnoAUnoDiferenciaMonto:
                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 

                            //Obtenemos lo datos del registro original
                            //Varibles de Trabajo
                            _RegLibro = _RegistrosLIBRO.First();
                            _Str_cidcomprob = _RegLibro["cidcomprob"].ToString();
                            _Str_corder = _RegLibro["corder"].ToString();
                            _Str_ccountcname = _RegLibro["CuentaDescripcion"].ToString();
                            _Str_cidconciliaciondmanual = _RegLibro["cidconciliaciondmanual"].ToString();
                            _Str_CuentaDiferenciaNumero = _RegLibro["CuentaNumero"].ToString();
                            _Str_CuentaDiferenciaDescripcion = _RegLibro["CuentaDescripcion"].ToString();
                            //Cargamos los Registros Originales del libro
                            _Str_SentenciaSQL = "SELECT * FROM TCOMPROBAND WHERE CCOMPANY='" + _Str_ccompany + "' AND CIDCOMPROB='" + _Str_cidcomprob + "' AND CORDER='" + _Str_corder + "'";
                            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                            //Si existe
                            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                            {
                                //Obtenemos los otros datos necesarios
                                var _Str_cnumdocu = _Ds_DataSet.Tables[0].Rows[0]["cnumdocu"].ToString();
                                var _Str_cdescrip = _Ds_DataSet.Tables[0].Rows[0]["cdescrip"].ToString();
                                var _Str_ccount = _Ds_DataSet.Tables[0].Rows[0]["ccount"].ToString();
                                var _Dbl_ctotdebe = Convert.ToDouble(_Ds_DataSet.Tables[0].Rows[0]["ctotdebe"]);
                                var _Dbl_ctothaber = Convert.ToDouble(_Ds_DataSet.Tables[0].Rows[0]["ctothaber"]);
                                var _Str_ctdocument = _Ds_DataSet.Tables[0].Rows[0]["ctdocument"].ToString();
                                var _Dbl_Monto = Math.Round(_Dbl_ctotdebe - _Dbl_ctothaber, 2);

                                //Obtenemos el registro del auxiliar
                                _Str_SentenciaSQL = "SELECT * FROM TCOMPROBANDD WHERE CCOMPANY='" + _Str_ccompany + "' AND CIDCOMPROB='" + _Str_cidcomprob + "' AND CORDER='" + _Str_corder + "' AND CCOUNT = '" +
                                                    _Str_ccount + "'";
                                var _Ds_DataSetAuxiliar = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                                var _Bool_TieneAuxiliar = _Ds_DataSetAuxiliar.Tables[0].Rows.Count > 0;
                                var _Str_cidauxiliarcont = _Ds_DataSetAuxiliar.Tables[0].Rows.Count > 0 ? _Ds_DataSetAuxiliar.Tables[0].Rows[0]["cidauxiliarcont"].ToString() : "";

                                // = -= -= -= -= -= -= -= -= -= -= -= - OBTENEMOS LOS DATOS NECESARIOS DEL BANCO = -= -= -= -= -= -= -= -= -= -= -= - 

                                //Obtengo los valores nuevos desde el registro correspondiente de BANCo
                                var _Str_NumeroDocumentoNuevo = "";
                                var _Str_ConceptoNuevo = "";
                                var _Dbl_MontoNuevo = 0.0;

                                var _RegBanco = _RegistrosBANCO.FirstOrDefault();
                                if (_RegBanco != null)
                                {
                                    _Str_NumeroDocumentoNuevo = _RegBanco["Número Doc."].ToString();
                                    _Str_ConceptoNuevo = _RegBanco["Concepto"].ToString();
                                    _Dbl_MontoNuevo = Math.Round(Convert.ToDouble(_RegBanco["Monto"]), 2);
                                }
                                var _Dbl_MontoDiferencia = Math.Round(_Dbl_MontoNuevo -_Dbl_Monto, 2);

                                // = -= -= -= -= -= -= -= -= -= -= -= - GENERAMOS ASIENTOS = -= -= -= -= -= -= -= -= -= -= -= - 

                                var _Str_Coletilla = " (DIF.MONT)";

                                //Generamos el Asiento Nuevo
                                _Mtd_Proceso_GenerarAsientoNuevo(_Dtg_Comprobante, _Int_TipoAjuste, _Str_ccount, _Str_ccountcname, _Dbl_MontoNuevo, _Bool_TieneAuxiliar, _Str_cidauxiliarcont, _Str_ctdocument, _Str_NumeroDocumentoNuevo, _Str_cidconciliaciondmanual, _Str_ConceptoNuevo, _Str_NumeroDocumentoNuevo, _Int_ciddetalleconciliacion.ToString(CultureInfo.InvariantCulture), ((byte)Clases._Cls_RutinasConciliacion._TipoRegistro.Nuevo).ToString(CultureInfo.InvariantCulture), _Str_Coletilla);

                                //Generamos el Asiento Nuevo con la Diferencia
                                _Mtd_Proceso_GenerarAsientoNuevoDiferencia(_Dtg_Comprobante, _Str_CuentaDiferenciaNumero, _Str_CuentaDiferenciaDescripcion, _Str_ctdocument, _Str_NumeroDocumentoNuevo, _Dbl_MontoDiferencia, _Str_ConceptoNuevo, _Str_NumeroDocumentoNuevo, _Int_ciddetalleconciliacion.ToString(CultureInfo.InvariantCulture), _Str_Coletilla, _Int_TipoAjuste);
                            }

                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 
                            break;

                        case (byte)Tipoajuste.MultiplesAgrupamientoRegistros:
                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 

                            //Obtenemos lo datos del registro original
                            //Varibles de Trabajo
                            _RegLibro = _RegistrosLIBRO.First(); //Tomamos el primer registro 
                            _Str_cidcomprob = _RegLibro["cidcomprob"].ToString();
                            _Str_corder = _RegLibro["corder"].ToString();
                            _Str_ccountcname = _RegLibro["CuentaDescripcion"].ToString();
                            _Str_cidconciliaciondmanual = _RegLibro["cidconciliaciondmanual"].ToString();
                            _Str_CuentaDiferenciaNumero = _RegLibro["CuentaNumero"].ToString();
                            _Str_CuentaDiferenciaDescripcion = _RegLibro["CuentaDescripcion"].ToString();
                            //Cargamos los Registros Originales del libro
                            _Str_SentenciaSQL = "SELECT * FROM TCOMPROBAND WHERE CCOMPANY='" + _Str_ccompany + "' AND CIDCOMPROB='" + _Str_cidcomprob + "' AND CORDER='" + _Str_corder + "'";
                            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                            //Si existe
                            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                            {
                                //Obtenemos los otros datos necesarios
                                var _Str_cnumdocu = _Ds_DataSet.Tables[0].Rows[0]["cnumdocu"].ToString();
                                var _Str_cdescrip = _Ds_DataSet.Tables[0].Rows[0]["cdescrip"].ToString();
                                var _Str_ccount = _Ds_DataSet.Tables[0].Rows[0]["ccount"].ToString();
                                var _Dbl_ctotdebe = Convert.ToDouble(_Ds_DataSet.Tables[0].Rows[0]["ctotdebe"]);
                                var _Dbl_ctothaber = Convert.ToDouble(_Ds_DataSet.Tables[0].Rows[0]["ctothaber"]);
                                var _Str_ctdocument = _Ds_DataSet.Tables[0].Rows[0]["ctdocument"].ToString();
                                var _Dbl_Monto = Math.Round(_Dbl_ctotdebe - _Dbl_ctothaber, 2);

                                //Obtenemos el registro del auxiliar
                                _Str_SentenciaSQL = "SELECT * FROM TCOMPROBANDD WHERE CCOMPANY='" + _Str_ccompany + "' AND CIDCOMPROB='" + _Str_cidcomprob + "' AND CORDER='" + _Str_corder + "' AND CCOUNT = '" +
                                                    _Str_ccount + "'";
                                var _Ds_DataSetAuxiliar = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                                var _Bool_TieneAuxiliar = _Ds_DataSetAuxiliar.Tables[0].Rows.Count > 0;
                                var _Str_cidauxiliarcont = _Ds_DataSetAuxiliar.Tables[0].Rows.Count > 0 ? _Ds_DataSetAuxiliar.Tables[0].Rows[0]["cidauxiliarcont"].ToString() : "";

                                // = -= -= -= -= -= -= -= -= -= -= -= - OBTENEMOS LOS DATOS NECESARIOS DEL BANCO = -= -= -= -= -= -= -= -= -= -= -= - 

                                //Obtengo los valores nuevos desde el registro correspondiente de BANCO
                                var _Str_NumeroDocumentoNuevo = "";
                                var _Str_ConceptoNuevo = "";
                                var _Dbl_MontoNuevo = 0.0;

                                var _RegBanco = _RegistrosBANCO.FirstOrDefault();
                                if (_RegBanco != null)
                                {
                                    _Str_NumeroDocumentoNuevo = _RegBanco["Número Doc."].ToString();
                                    _Str_ConceptoNuevo = _RegBanco["Concepto"].ToString();
                                    _Dbl_MontoNuevo = Math.Round(Convert.ToDouble(_RegBanco["Monto"]), 2);
                                }
                                var _Dbl_MontoDiferencia = Math.Round(_Dbl_TotalRegistrosLIBRO - _Dbl_Monto, 2);

                                // = -= -= -= -= -= -= -= -= -= -= -= - GENERAMOS ASIENTOS = -= -= -= -= -= -= -= -= -= -= -= - 

                                var _Str_Coletilla = " (AGRUP.REGIS)";

                                //Generamos el Asiento Nuevo
                                _Mtd_Proceso_GenerarAsientoNuevo(_Dtg_Comprobante, _Int_TipoAjuste, _Str_ccount, _Str_ccountcname, _Dbl_MontoNuevo, _Bool_TieneAuxiliar, _Str_cidauxiliarcont, _Str_ctdocument, _Str_NumeroDocumentoNuevo, _Str_cidconciliaciondmanual, _Str_ConceptoNuevo, _Str_NumeroDocumentoNuevo, _Int_ciddetalleconciliacion.ToString(CultureInfo.InvariantCulture), ((byte)Clases._Cls_RutinasConciliacion._TipoRegistro.Nuevo).ToString(CultureInfo.InvariantCulture), _Str_Coletilla);

                            }

                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 
                            break;

                        case (byte)Tipoajuste.MultiplesAgrupamientoRegistrosConDiferenciaMonto:

                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 

                            //Obtenemos lo datos del registro original
                            //Varibles de Trabajo
                            _RegLibro = _RegistrosLIBRO.First(); //Tomamos el primer registro 
                            _Str_cidcomprob = _RegLibro["cidcomprob"].ToString();
                            _Str_corder = _RegLibro["corder"].ToString();
                            _Str_ccountcname = _RegLibro["CuentaDescripcion"].ToString();
                            _Str_cidconciliaciondmanual = _RegLibro["cidconciliaciondmanual"].ToString();
                            _Str_CuentaDiferenciaNumero = _RegLibro["CuentaNumero"].ToString();
                            _Str_CuentaDiferenciaDescripcion = _RegLibro["CuentaDescripcion"].ToString();
                            //Cargamos los Registros Originales del libro
                            _Str_SentenciaSQL = "SELECT * FROM TCOMPROBAND WHERE CCOMPANY='" + _Str_ccompany + "' AND CIDCOMPROB='" + _Str_cidcomprob + "' AND CORDER='" + _Str_corder + "'";
                            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                            //Si existe
                            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                            {
                                //Obtenemos los otros datos necesarios
                                var _Str_cnumdocu = _Ds_DataSet.Tables[0].Rows[0]["cnumdocu"].ToString();
                                var _Str_cdescrip = _Ds_DataSet.Tables[0].Rows[0]["cdescrip"].ToString();
                                var _Str_ccount = _Ds_DataSet.Tables[0].Rows[0]["ccount"].ToString();
                                var _Dbl_ctotdebe = Convert.ToDouble(_Ds_DataSet.Tables[0].Rows[0]["ctotdebe"]);
                                var _Dbl_ctothaber = Convert.ToDouble(_Ds_DataSet.Tables[0].Rows[0]["ctothaber"]);
                                var _Str_ctdocument = _Ds_DataSet.Tables[0].Rows[0]["ctdocument"].ToString();
                                var _Dbl_Monto = Math.Round(_Dbl_ctotdebe - _Dbl_ctothaber, 2);

                                //Obtenemos el registro del auxiliar
                                _Str_SentenciaSQL = "SELECT * FROM TCOMPROBANDD WHERE CCOMPANY='" + _Str_ccompany + "' AND CIDCOMPROB='" + _Str_cidcomprob + "' AND CORDER='" + _Str_corder + "' AND CCOUNT = '" +
                                                    _Str_ccount + "'";
                                var _Ds_DataSetAuxiliar = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                                var _Bool_TieneAuxiliar = _Ds_DataSetAuxiliar.Tables[0].Rows.Count > 0;
                                var _Str_cidauxiliarcont = _Ds_DataSetAuxiliar.Tables[0].Rows.Count > 0 ? _Ds_DataSetAuxiliar.Tables[0].Rows[0]["cidauxiliarcont"].ToString() : "";

                                // = -= -= -= -= -= -= -= -= -= -= -= - OBTENEMOS LOS DATOS NECESARIOS DEL BANCO = -= -= -= -= -= -= -= -= -= -= -= - 

                                //Obtengo los valores nuevos desde el registro correspondiente de BANCo
                                var _Str_NumeroDocumentoNuevo = "";
                                var _Str_ConceptoNuevo = "";
                                var _Dbl_MontoNuevo = 0.0;

                                var _RegBanco = _RegistrosBANCO.FirstOrDefault();
                                if (_RegBanco != null)
                                {
                                    _Str_NumeroDocumentoNuevo = _RegBanco["Número Doc."].ToString();
                                    _Str_ConceptoNuevo = _RegBanco["Concepto"].ToString();
                                    _Dbl_MontoNuevo = Math.Round(Convert.ToDouble(_RegBanco["Monto"]), 2);
                                }
                                var _Dbl_MontoDiferencia = Math.Round(_Dbl_MontoNuevo - _Dbl_TotalRegistrosLIBRO, 2);

                                // = -= -= -= -= -= -= -= -= -= -= -= - GENERAMOS ASIENTOS = -= -= -= -= -= -= -= -= -= -= -= - 

                                var _Str_Coletilla = " (AGRUP.REGIS.DIF.MONT)";

                                //Generamos el Asiento Nuevo
                                _Mtd_Proceso_GenerarAsientoNuevo(_Dtg_Comprobante, _Int_TipoAjuste, _Str_ccount, _Str_ccountcname, _Dbl_MontoNuevo, _Bool_TieneAuxiliar, _Str_cidauxiliarcont, _Str_ctdocument, _Str_NumeroDocumentoNuevo, _Str_cidconciliaciondmanual, _Str_ConceptoNuevo, _Str_NumeroDocumentoNuevo, _Int_ciddetalleconciliacion.ToString(CultureInfo.InvariantCulture), ((byte)Clases._Cls_RutinasConciliacion._TipoRegistro.Nuevo).ToString(CultureInfo.InvariantCulture), _Str_Coletilla);


                                //Generamos el Asiento Nuevo con la Diferencia
                                _Mtd_Proceso_GenerarAsientoNuevoDiferencia(_Dtg_Comprobante, _Str_CuentaDiferenciaNumero, _Str_CuentaDiferenciaDescripcion, _Str_ctdocument, _Str_cnumdocu, _Dbl_MontoDiferencia, _Str_ConceptoNuevo, _Str_NumeroDocumentoNuevo, _Int_ciddetalleconciliacion.ToString(CultureInfo.InvariantCulture), _Str_Coletilla, _Int_TipoAjuste);

                            }


                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 
                            break;

                        case (byte)Tipoajuste.MultiplesDivisionRegistros:

                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 

                            //Obtenemos lo datos del registro original
                            //Varibles de Trabajo
                            _RegLibro = _RegistrosLIBRO.First(); //Tomamos el primer registro 
                            _Str_cidcomprob = _RegLibro["cidcomprob"].ToString();
                            _Str_corder = _RegLibro["corder"].ToString();
                            _Str_ccountcname = _RegLibro["CuentaDescripcion"].ToString();
                            _Str_cidconciliaciondmanual = _RegLibro["cidconciliaciondmanual"].ToString();
                            _Str_CuentaDiferenciaNumero = _RegLibro["CuentaNumero"].ToString();
                            _Str_CuentaDiferenciaDescripcion = _RegLibro["CuentaDescripcion"].ToString();
                            //Cargamos los Registros Originales del libro
                            _Str_SentenciaSQL = "SELECT * FROM TCOMPROBAND WHERE CCOMPANY='" + _Str_ccompany + "' AND CIDCOMPROB='" + _Str_cidcomprob + "' AND CORDER='" + _Str_corder + "'";
                            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                            //Si existe
                            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                            {
                                //Obtenemos los otros datos necesarios
                                var _Str_cnumdocu = _Ds_DataSet.Tables[0].Rows[0]["cnumdocu"].ToString();
                                var _Str_cdescrip = _Ds_DataSet.Tables[0].Rows[0]["cdescrip"].ToString();
                                var _Str_ccount = _Ds_DataSet.Tables[0].Rows[0]["ccount"].ToString();
                                var _Dbl_ctotdebe = Convert.ToDouble(_Ds_DataSet.Tables[0].Rows[0]["ctotdebe"]);
                                var _Dbl_ctothaber = Convert.ToDouble(_Ds_DataSet.Tables[0].Rows[0]["ctothaber"]);
                                var _Str_ctdocument = _Ds_DataSet.Tables[0].Rows[0]["ctdocument"].ToString();
                                var _Dbl_Monto = Math.Round(_Dbl_ctotdebe - _Dbl_ctothaber, 2);

                                //Obtenemos el registro del auxiliar
                                _Str_SentenciaSQL = "SELECT * FROM TCOMPROBANDD WHERE CCOMPANY='" + _Str_ccompany + "' AND CIDCOMPROB='" + _Str_cidcomprob + "' AND CORDER='" + _Str_corder + "' AND CCOUNT = '" +
                                                    _Str_ccount + "'";
                                var _Ds_DataSetAuxiliar = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                                var _Bool_TieneAuxiliar = _Ds_DataSetAuxiliar.Tables[0].Rows.Count > 0;
                                var _Str_cidauxiliarcont = _Ds_DataSetAuxiliar.Tables[0].Rows.Count > 0 ? _Ds_DataSetAuxiliar.Tables[0].Rows[0]["cidauxiliarcont"].ToString() : "";

                                // = -= -= -= -= -= -= -= -= -= -= -= - OBTENEMOS LOS DATOS NECESARIOS DEL BANCO = -= -= -= -= -= -= -= -= -= -= -= - 

                                //Recorremos los registro de Banco
                                foreach (var _RegBanco in _RegistrosBANCO)
                                {

                                    //Obtengo los valores nuevos desde el registro correspondiente de BANCo
                                    var _Str_NumeroDocumentoNuevo = _RegBanco["Número Doc."].ToString();
                                    var _Str_ConceptoNuevo = _RegBanco["Concepto"].ToString();
                                    var _Dbl_MontoNuevo = Math.Round(Convert.ToDouble(_RegBanco["Monto"]), 2);
                                    var _Dbl_MontoDiferencia = Math.Round(_Dbl_TotalRegistrosLIBRO - _Dbl_Monto, 2);

                                    // = -= -= -= -= -= -= -= -= -= -= -= - GENERAMOS ASIENTOS = -= -= -= -= -= -= -= -= -= -= -= - 

                                    var _Str_Coletilla = " (DIV.REGIS)";

                                    //Generamos el Asiento Nuevo
                                    _Mtd_Proceso_GenerarAsientoNuevo(_Dtg_Comprobante, _Int_TipoAjuste, _Str_ccount, _Str_ccountcname, _Dbl_MontoNuevo, _Bool_TieneAuxiliar, _Str_cidauxiliarcont, _Str_ctdocument, _Str_NumeroDocumentoNuevo, _Str_cidconciliaciondmanual, _Str_ConceptoNuevo, _Str_NumeroDocumentoNuevo, _Int_ciddetalleconciliacion.ToString(CultureInfo.InvariantCulture), ((byte)Clases._Cls_RutinasConciliacion._TipoRegistro.Nuevo).ToString(CultureInfo.InvariantCulture), _Str_Coletilla);

                                    //Generamos el Asiento Nuevo con la Diferencia
                                    //_Mtd_Proceso_GenerarAsientoNuevoDiferencia(_Dg_Comprobante, _Str_CuentaDiferenciaNumero, _Str_CuentaDiferenciaDescripcion, _Str_ctdocument, _Str_cnumdocu, _Dbl_MontoDiferencia);
                                }
                            }

                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 
                            break;

                        case (byte)Tipoajuste.MultiplesDivisionRegistrosConDiferenciaMonto:
                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 

                            //Obtenemos lo datos del registro original
                            //Varibles de Trabajo
                            _RegLibro = _RegistrosLIBRO.First(); //Tomamos el primer registro 
                            _Str_cidcomprob = _RegLibro["cidcomprob"].ToString();
                            _Str_corder = _RegLibro["corder"].ToString();
                            _Str_ccountcname = _RegLibro["CuentaDescripcion"].ToString();
                            _Str_cidconciliaciondmanual = _RegLibro["cidconciliaciondmanual"].ToString();
                            _Str_CuentaDiferenciaNumero = _RegLibro["CuentaNumero"].ToString();
                            _Str_CuentaDiferenciaDescripcion = _RegLibro["CuentaDescripcion"].ToString();
                            //Cargamos los Registros Originales del libro
                            _Str_SentenciaSQL = "SELECT * FROM TCOMPROBAND WHERE CCOMPANY='" + _Str_ccompany + "' AND CIDCOMPROB='" + _Str_cidcomprob + "' AND CORDER='" + _Str_corder + "'";
                            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                            //Si existe
                            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                            {
                                //Obtenemos los otros datos necesarios
                                var _Str_cnumdocu = _Ds_DataSet.Tables[0].Rows[0]["cnumdocu"].ToString();
                                var _Str_cdescrip = _Ds_DataSet.Tables[0].Rows[0]["cdescrip"].ToString();
                                var _Str_ccount = _Ds_DataSet.Tables[0].Rows[0]["ccount"].ToString();
                                var _Dbl_ctotdebe = Convert.ToDouble(_Ds_DataSet.Tables[0].Rows[0]["ctotdebe"]);
                                var _Dbl_ctothaber = Convert.ToDouble(_Ds_DataSet.Tables[0].Rows[0]["ctothaber"]);
                                var _Str_ctdocument = _Ds_DataSet.Tables[0].Rows[0]["ctdocument"].ToString();
                                var _Dbl_Monto = Math.Round(_Dbl_ctotdebe - _Dbl_ctothaber, 2);

                                //Obtenemos el registro del auxiliar
                                _Str_SentenciaSQL = "SELECT * FROM TCOMPROBANDD WHERE CCOMPANY='" + _Str_ccompany + "' AND CIDCOMPROB='" + _Str_cidcomprob + "' AND CORDER='" + _Str_corder + "' AND CCOUNT = '" +
                                                    _Str_ccount + "'";
                                var _Ds_DataSetAuxiliar = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                                var _Bool_TieneAuxiliar = _Ds_DataSetAuxiliar.Tables[0].Rows.Count > 0;
                                var _Str_cidauxiliarcont = _Ds_DataSetAuxiliar.Tables[0].Rows.Count > 0 ? _Ds_DataSetAuxiliar.Tables[0].Rows[0]["cidauxiliarcont"].ToString() : "";

                                // = -= -= -= -= -= -= -= -= -= -= -= - OBTENEMOS LOS DATOS NECESARIOS DEL BANCO = -= -= -= -= -= -= -= -= -= -= -= - 

                                var _Str_Coletilla = " (DIV.REGIS.DIF.MONT)";

                                //Recorremos los registro de Banco
                                foreach (var _RegBanco in _RegistrosBANCO)
                                {

                                    //Obtengo los valores nuevos desde el registro correspondiente de BANCo
                                    var _Str_NumeroDocumentoNuevo = _RegBanco["Número Doc."].ToString();
                                    var _Str_ConceptoNuevo = _RegBanco["Concepto"].ToString();
                                    var _Dbl_MontoNuevo = Math.Round(Convert.ToDouble(_RegBanco["Monto"]), 2);

                                    // = -= -= -= -= -= -= -= -= -= -= -= - GENERAMOS ASIENTOS = -= -= -= -= -= -= -= -= -= -= -= - 

                                    //Generamos el Asiento Nuevo
                                    _Mtd_Proceso_GenerarAsientoNuevo(_Dtg_Comprobante, _Int_TipoAjuste, _Str_ccount, _Str_ccountcname, _Dbl_MontoNuevo, _Bool_TieneAuxiliar, _Str_cidauxiliarcont, _Str_ctdocument, _Str_NumeroDocumentoNuevo, _Str_cidconciliaciondmanual, _Str_ConceptoNuevo, _Str_NumeroDocumentoNuevo, _Int_ciddetalleconciliacion.ToString(CultureInfo.InvariantCulture), ((byte)Clases._Cls_RutinasConciliacion._TipoRegistro.Nuevo).ToString(CultureInfo.InvariantCulture), _Str_Coletilla);

                                }

                                //Generamos el Asiento Nuevo con la Diferencia
                                var _Dbl_MontoDiferencia = Math.Round(_Dbl_TotalRegistrosBANCO - _Dbl_Monto, 2);
                                _Mtd_Proceso_GenerarAsientoNuevoDiferencia(_Dtg_Comprobante, _Str_CuentaDiferenciaNumero, _Str_CuentaDiferenciaDescripcion, _Str_ctdocument, _Str_cnumdocu, _Dbl_MontoDiferencia, "", "", _Int_ciddetalleconciliacion.ToString(CultureInfo.InvariantCulture), _Str_Coletilla, _Int_TipoAjuste);
                            }


                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 
                            break;

                        case (byte)Tipoajuste.CruceMovimientosContables:
                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 
                            // ESTE NO GENERA ASIENTOS CONTABLES
                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 
                            break;

                        case (byte)Tipoajuste.CruceMovimientosBanco:
                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 

                            //Obtenemos los datos de la cuenta 
                            _Str_SentenciaSQL = "SELECT ccount FROM TCUENTBANC where cbanco = '" + _G_Int_Banco + "' and cnumcuenta = '" + _G_Str_Cnumcuenta + "' and isnull(cdelete,0)=0";
                            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                            //Si existe
                            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                            {
                                //Obtenemos la cuenta contable
                                var _Str_ccount = _Ds_DataSet.Tables[0].Rows[0]["ccount"].ToString();
                                _Str_ccountcname = _Mtd_ObtenerDescripCuenta(_Str_ccount);
                                var _Bool_TieneAuxiliar = false;
                                var _Str_cidauxiliarcont = "";
                                _Str_cidconciliaciondmanual =  _RegistrosBANCO.First()["cidconciliaciondmanual"].ToString();
                                // = -= -= -= -= -= -= -= -= -= -= -= - RECORREMOS LOS REGISTROS DEL BANCO = -= -= -= -= -= -= -= -= -= -= -= - 

                                var _Str_Coletilla = " (RE-DEPOSITO)";

                                //Recorremos los registro de Banco
                                foreach (var _RegBanco in _RegistrosBANCO)
                                {

                                    //Obtengo los valores nuevos desde el registro correspondiente de BANCo
                                    var _Str_NumeroDocumentoNuevo = _RegBanco["Número Doc."].ToString();
                                    var _Str_ConceptoNuevo = _RegBanco["Concepto"].ToString();
                                    var _Dbl_MontoNuevo = Math.Round(Convert.ToDouble(_RegBanco["Monto"]), 2);

                                    var _Str_ctdocument = "";

                                    // = -= -= -= -= -= -= -= -= -= -= -= - GENERAMOS ASIENTOS = -= -= -= -= -= -= -= -= -= -= -= - 

                                    //Generamos el Asiento Nuevo
                                    _Mtd_Proceso_GenerarAsientoNuevo(_Dtg_Comprobante, _Int_TipoAjuste, _Str_ccount, _Str_ccountcname, _Dbl_MontoNuevo, _Bool_TieneAuxiliar, _Str_cidauxiliarcont, _Str_ctdocument, _Str_NumeroDocumentoNuevo, _Str_cidconciliaciondmanual, _Str_ConceptoNuevo, _Str_NumeroDocumentoNuevo, _Int_ciddetalleconciliacion.ToString(CultureInfo.InvariantCulture), ((byte)Clases._Cls_RutinasConciliacion._TipoRegistro.Nuevo).ToString(CultureInfo.InvariantCulture), _Str_Coletilla);
                                }
                            }

                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 
                            break;

                        case (byte)Tipoajuste.ComisionesEIntereses:
                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 

                            //Verifica si aplica debito bancario, de ser verdadero se obtiene % que se debe aplicar.
                            var _Dbl_Procentaje_DB = _Mtd_Aplica_Debito_Bancario();
                            //Obtenemos los datos de la cuenta 
                            _Str_SentenciaSQL = "SELECT ccount FROM TCUENTBANC where cbanco = '" + _G_Int_Banco + "' and cnumcuenta = '" + _G_Str_Cnumcuenta + "' and isnull(cdelete,0)=0";
                            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                            //Si existe
                            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                            {
                                //Obtenemos la cuenta contable del Banco
                                var _Str_ccount = _Ds_DataSet.Tables[0].Rows[0]["ccount"].ToString();
                                _Str_ccountcname = _Mtd_ObtenerDescripCuenta(_Str_ccount);
                                var _Bool_TieneAuxiliar = false;
                                var _Str_cidauxiliarcont = "";
                                _Str_cidconciliaciondmanual = _RegistrosBANCO.First()["cidconciliaciondmanual"].ToString();

                                // = -= -= -= -= -= -= -= -= -= -= -= - RECORREMOS LOS REGISTROS DEL BANCO = -= -= -= -= -= -= -= -= -= -= -= - 

                                //Recorremos los registro de Banco
                                foreach (var _RegBanco in _RegistrosBANCO)
                                {
                                    var _Str_Coletilla = "";
                                    var _Str_ccount_ajustar = "";
                                    var _Str_ccountcname_ajustar = "";
                                    var _Str_coperbancseleccionado = _RegBanco["coperbancseleccionado"].ToString();
                                    var _Str_NaturalezaLibro = "";
                                    var _Str_Fecha_Doc = _RegBanco["fecha"].ToString();
                                    bool _Bol_Aplica_DB = false;

                                    //Si viene el tipo de opearcion bancaria quiere decir que no es automatico
                                    if (_Str_coperbancseleccionado != "")
                                    {
                                        //Cuando es manual
                                        //Obtenemos la cuenta contable del tipo de operacion bancaria a ajustar
                                        _Str_SentenciaSQL = "SELECT TOPERBANC.ccount, TCOUNT.cname, TOPERBANC.cname AS Coletilla, TOPERBANC.cdebe, TOPERBANC.chaber FROM TOPERBANC INNER JOIN TCOUNT ON TOPERBANC.ccount = TCOUNT.ccount " +
                                                            "WHERE (TOPERBANC.coperbanc = '" + _Str_coperbancseleccionado + "') AND (ccompany='" + Frm_Padre._Str_Comp + "') AND (ISNULL(TOPERBANC.cdelete, 0) = 0) AND (ISNULL(TCOUNT.cdelete,0)= 0)";
                                        var _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                                        //Si existe
                                        if (_Ds2.Tables[0].Rows.Count > 0)
                                        {
                                            _Str_ccount_ajustar = _Ds2.Tables[0].Rows[0]["ccount"].ToString();
                                            _Str_ccountcname_ajustar = _Ds2.Tables[0].Rows[0]["cname"].ToString();
                                            _Str_Coletilla = " (" + _Ds2.Tables[0].Rows[0]["Coletilla"].ToString() + ")";
                                            _Str_NaturalezaLibro = _Ds2.Tables[0].Rows[0]["cdebe"].ToString() == "1"? "D" : "H";
                                            _Bol_Aplica_DB = _Str_NaturalezaLibro == "H" ? true : false;
                                        }
                                    }
                                    else
                                    {
                                        //Cuando es automatico

                                        //Obtenemos la cuenta contable del tipo de operacion bancaria a ajustar
                                        var _Str_cdispbanc = _RegBanco["cdispbanc"].ToString();
                                        var _Str_cdispband = _RegBanco["cdispband"].ToString();

                                        _Str_SentenciaSQL = "SELECT TOPERBANC.ccount,TOPERBANC.cname AS Coletilla, TOPERBANC.cdebe, TOPERBANC.chaber FROM TDISPBAND INNER JOIN TOPERBANCD ON TDISPBAND.cbanco = TOPERBANCD.cbanco AND TDISPBAND.ctipoperacio = TOPERBANCD.coperbancd INNER JOIN TOPERBANC ON TOPERBANCD.coperbanc = TOPERBANC.coperbanc " +
                                                           "WHERE (TDISPBAND.cdispbanc='" + _Str_cdispbanc + "') AND (TDISPBAND.cdispband='" + _Str_cdispband + "') AND (TDISPBAND.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TOPERBANCD.cdelete = 0) AND (TOPERBANC.cdelete = 0) ";
                                        var _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                                        //Si existe
                                        if (_Ds2.Tables[0].Rows.Count > 0)
                                        {
                                            _Str_ccount_ajustar = _Ds2.Tables[0].Rows[0]["ccount"].ToString();
                                            _Str_ccountcname_ajustar = _Mtd_ObtenerDescripCuenta(_Str_ccount_ajustar);
                                            _Str_Coletilla = " (" + _Ds2.Tables[0].Rows[0]["Coletilla"].ToString() + ")";
                                            _Str_NaturalezaLibro = _Ds2.Tables[0].Rows[0]["cdebe"].ToString() == "1" ? "D" : "H";
                                            _Bol_Aplica_DB = _Str_NaturalezaLibro == "H" ? true : false;
                                        }
                                    }

                                    //Obtengo los valores nuevos desde el registro correspondiente de BANCO
                                    var _Str_NumeroDocumentoNuevo = _RegBanco["Número Doc."].ToString();
                                    var _Str_ConceptoNuevo = _RegBanco["Concepto"].ToString();
                                    var _Dbl_MontoNuevo = Math.Round(Convert.ToDouble(_RegBanco["Monto"]), 2);
                                    var _Str_ctdocument = "";
                                    var _Dbl_MontoNuevoLibro = _Dbl_MontoNuevo;

                                    //Quitamos signos
                                    _Dbl_MontoNuevo = Math.Abs(_Dbl_MontoNuevo);
                                    _Dbl_MontoNuevoLibro = Math.Abs(_Dbl_MontoNuevoLibro);

                                    var _Dbl_Valida_Monto = Math.Round(((_Dbl_MontoNuevo * _Dbl_Procentaje_DB) / 100),2);

                                    //Corregimos los signos segun la naturaleza
                                    if (_Str_NaturalezaLibro == "D")
                                    {
                                        _Dbl_MontoNuevoLibro = _Dbl_MontoNuevoLibro * (-1);
                                    }
                                    else
                                    {
                                        _Dbl_MontoNuevo = _Dbl_MontoNuevo * (-1);
                                    }

                                    // = -= -= -= -= -= -= -= -= -= -= -= - GENERAMOS ASIENTOS = -= -= -= -= -= -= -= -= -= -= -= - 

                                    //Generamos el Asiento Nuevo (Cuenta Banco)
                                    _Mtd_Proceso_GenerarAsientoNuevo(_Dtg_Comprobante, _Int_TipoAjuste, _Str_ccount, _Str_ccountcname, _Dbl_MontoNuevo, _Bool_TieneAuxiliar, _Str_cidauxiliarcont, _Str_ctdocument, _Str_NumeroDocumentoNuevo, _Str_cidconciliaciondmanual, _Str_ConceptoNuevo, _Str_NumeroDocumentoNuevo, _Int_ciddetalleconciliacion.ToString(CultureInfo.InvariantCulture), ((byte)Clases._Cls_RutinasConciliacion._TipoRegistro.Nuevo).ToString(CultureInfo.InvariantCulture), _Str_Coletilla);
                                    
                                    //Generamos el Asiento Nuevo (Cuenta Comision o Intereses)
                                    _Mtd_Proceso_GenerarAsientoNuevo(_Dtg_Comprobante, _Int_TipoAjuste, _Str_ccount_ajustar, _Str_ccountcname_ajustar, _Dbl_MontoNuevoLibro, _Bool_TieneAuxiliar, _Str_cidauxiliarcont, _Str_ctdocument, _Str_NumeroDocumentoNuevo, _Str_cidconciliaciondmanual, _Str_ConceptoNuevo, _Str_NumeroDocumentoNuevo, _Int_ciddetalleconciliacion.ToString(CultureInfo.InvariantCulture), ((byte)Clases._Cls_RutinasConciliacion._TipoRegistro.Reverso).ToString(CultureInfo.InvariantCulture), _Str_Coletilla);

                                    //Si aplica debito bancario generamos asiento nuevo del debito en cuenta banco y cuenta de egreso por debito bancario
                                    if (_Dbl_Procentaje_DB != 0 && _Bol_Aplica_DB == true && Convert.ToDateTime(_Str_Fecha_Doc.ToString()) >= Convert.ToDateTime("01/02/2016") && _Dbl_Valida_Monto != 0)
                                    {
                                        _Mtd_Proceso_GenerarAsientoNuevo(_Dtg_Comprobante, _Int_TipoAjuste, _Str_ccount, _Str_ccountcname, ((_Dbl_MontoNuevo * _Dbl_Procentaje_DB) / 100), _Bool_TieneAuxiliar, _Str_cidauxiliarcont, _Str_ctdocument, _Str_NumeroDocumentoNuevo, _Str_cidconciliaciondmanual, "(IGTF) " + _Str_ConceptoNuevo, _Str_NumeroDocumentoNuevo, _Int_ciddetalleconciliacion.ToString(CultureInfo.InvariantCulture), ((byte)Clases._Cls_RutinasConciliacion._TipoRegistro.Nuevo).ToString(CultureInfo.InvariantCulture), _Str_Coletilla);
                                        _Mtd_Proceso_GenerarAsientoNuevo(_Dtg_Comprobante, _Int_TipoAjuste, _Mtd_Obtiene_Cuenta_Contable_DB("CXP_DEBITOBANC", 1), _Str_ccountcname_ajustar, ((_Dbl_MontoNuevoLibro * _Dbl_Procentaje_DB) / 100), _Bool_TieneAuxiliar, _Str_cidauxiliarcont, _Str_ctdocument, _Str_NumeroDocumentoNuevo, _Str_cidconciliaciondmanual, "(IGTF) " + _Str_ConceptoNuevo, _Str_NumeroDocumentoNuevo, _Int_ciddetalleconciliacion.ToString(CultureInfo.InvariantCulture), ((byte)Clases._Cls_RutinasConciliacion._TipoRegistro.Reverso).ToString(CultureInfo.InvariantCulture), _Str_Coletilla); 
                                    }                                    

                                    //Si aplica debito bancario generamos asiento nuevo en cuenta de egreso por debito bancario
                                    //if (_Dbl_Procentaje_DB != 0 && _Bol_Aplica_DB == true && Convert.ToDateTime(_Str_Fecha_Doc.ToString()) >= Convert.ToDateTime("01/01/2016")) { _Mtd_Proceso_GenerarAsientoNuevo(_Dtg_Comprobante, _Int_TipoAjuste, _Mtd_Obtiene_Cuenta_Contable_DB("CXP_DEBITOBANC", 1), _Str_ccountcname_ajustar, ((_Dbl_MontoNuevoLibro * _Dbl_Procentaje_DB) / 100), _Bool_TieneAuxiliar, _Str_cidauxiliarcont, _Str_ctdocument, _Str_NumeroDocumentoNuevo, _Str_cidconciliaciondmanual, "(IGTF) " + _Str_ConceptoNuevo, _Str_NumeroDocumentoNuevo, _Int_ciddetalleconciliacion.ToString(CultureInfo.InvariantCulture), ((byte)Clases._Cls_RutinasConciliacion._TipoRegistro.Reverso).ToString(CultureInfo.InvariantCulture), _Str_Coletilla); }
                                }
                            }

                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 
                            break;

                        case (byte)Tipoajuste.ComisionesEIntereses_Reverso:
                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 

                            //Obtenemos los datos de la cuenta 
                            _Str_SentenciaSQL = "SELECT ccount FROM TCUENTBANC where cbanco = '" + _G_Int_Banco + "' and cnumcuenta = '" + _G_Str_Cnumcuenta + "' and isnull(cdelete,0)=0";
                            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                            //Si existe
                            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                            {
                                //Obtenemos la cuenta contable del Banco
                                var _Str_ccount = _Ds_DataSet.Tables[0].Rows[0]["ccount"].ToString();
                                _Str_ccountcname = _Mtd_ObtenerDescripCuenta(_Str_ccount);
                                var _Bool_TieneAuxiliar = false;
                                var _Str_cidauxiliarcont = "";
                                _Str_cidconciliaciondmanual = _RegistrosBANCO.First()["cidconciliaciondmanual"].ToString();

                                // = -= -= -= -= -= -= -= -= -= -= -= - RECORREMOS LOS REGISTROS DEL BANCO = -= -= -= -= -= -= -= -= -= -= -= - 

                                //Recorremos los registro de Banco
                                foreach (var _RegBanco in _RegistrosBANCO)
                                {
                                    var _Str_Coletilla = "";
                                    var _Str_ccount_ajustar = "";
                                    var _Str_ccountcname_ajustar = "";
                                    var _Str_coperbancseleccionadoOriginal = _RegBanco["coperbancseleccionado"].ToString();
                                    var _Str_coperbancseleccionado = "";
                                    var _Bol_EsReverso = false;
                                    var _Str_ColetillaReverso = "";

                                    //Detectamos el coperbanc correspondiente y si viene o no con reverso
                                    var _Int_Posicion = _Str_coperbancseleccionadoOriginal.IndexOf(T3.Clases._Cls_RutinasConciliacion._Str_Coletilla_Reverso);
                                    if ((_Int_Posicion > 0))
                                    {
                                        _Bol_EsReverso = true;
                                        _Str_coperbancseleccionado = _Str_coperbancseleccionadoOriginal.Substring(0, _Int_Posicion);
                                        _Str_ColetillaReverso = " REV. ";
                                    }
                                    else
                                    {
                                        _Str_coperbancseleccionado = _Str_coperbancseleccionadoOriginal;
                                    }

                                    var _Str_NaturalezaLibro = "";
                                    //Si viene el tipo de opearcion bancaria quiere decir que no es automatico
                                    if (_Str_coperbancseleccionado != "")
                                    {
                                        //Cuando es manual
                                        //Obtenemos la cuenta contable del tipo de operacion bancaria a ajustar
                                        _Str_SentenciaSQL = "SELECT TOPERBANC.ccount, TCOUNT.cname, TOPERBANC.cname AS Coletilla, TOPERBANC.cdebe, TOPERBANC.chaber FROM TOPERBANC INNER JOIN TCOUNT ON TOPERBANC.ccount = TCOUNT.ccount " +
                                                            "WHERE (TOPERBANC.coperbanc = '" + _Str_coperbancseleccionado + "') AND (ccompany='" + Frm_Padre._Str_Comp + "') AND (ISNULL(TOPERBANC.cdelete, 0) = 0) AND (ISNULL(TCOUNT.cdelete,0)= 0)";
                                        var _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                                        //Si existe
                                        if (_Ds2.Tables[0].Rows.Count > 0)
                                        {
                                            _Str_ccount_ajustar = _Ds2.Tables[0].Rows[0]["ccount"].ToString();
                                            _Str_ccountcname_ajustar = _Ds2.Tables[0].Rows[0]["cname"].ToString();
                                            _Str_Coletilla = " (" + _Ds2.Tables[0].Rows[0]["Coletilla"].ToString() + _Str_ColetillaReverso + ")";
                                            _Str_NaturalezaLibro = _Ds2.Tables[0].Rows[0]["cdebe"].ToString() == "1" ? "D" : "H";
                                        }
                                    }
                                    else
                                    {
                                        //Cuando es automatico

                                        //Obtenemos la cuenta contable del tipo de operacion bancaria a ajustar
                                        var _Str_cdispbanc = _RegBanco["cdispbanc"].ToString();
                                        var _Str_cdispband = _RegBanco["cdispband"].ToString();

                                        _Str_SentenciaSQL = "SELECT TOPERBANC.ccount,TOPERBANC.cname AS Coletilla, TOPERBANC.cdebe, TOPERBANC.chaber FROM TDISPBAND INNER JOIN TOPERBANCD ON TDISPBAND.cbanco = TOPERBANCD.cbanco AND TDISPBAND.ctipoperacio = TOPERBANCD.coperbancd INNER JOIN TOPERBANC ON TOPERBANCD.coperbanc = TOPERBANC.coperbanc " +
                                                           "WHERE (TDISPBAND.cdispbanc='" + _Str_cdispbanc + "') AND (TDISPBAND.cdispband='" + _Str_cdispband + "') AND (TDISPBAND.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TOPERBANCD.cdelete = 0) AND (TOPERBANC.cdelete = 0) ";
                                        var _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                                        //Si existe
                                        if (_Ds2.Tables[0].Rows.Count > 0)
                                        {
                                            _Str_ccount_ajustar = _Ds2.Tables[0].Rows[0]["ccount"].ToString();
                                            _Str_ccountcname_ajustar = _Mtd_ObtenerDescripCuenta(_Str_ccount_ajustar);
                                            _Str_Coletilla = " (" + _Ds2.Tables[0].Rows[0]["Coletilla"].ToString() + _Str_ColetillaReverso + ")";
                                            _Str_NaturalezaLibro = _Ds2.Tables[0].Rows[0]["cdebe"].ToString() == "1" ? "D" : "H";
                                        }
                                    }

                                    //Obtengo los valores nuevos desde el registro correspondiente de BANCO
                                    var _Str_NumeroDocumentoNuevo = _RegBanco["Número Doc."].ToString();
                                    var _Str_ConceptoNuevo = _RegBanco["Concepto"].ToString();
                                    var _Dbl_MontoNuevo = Math.Round(Convert.ToDouble(_RegBanco["Monto"]), 2);
                                    var _Str_ctdocument = "";
                                    var _Dbl_MontoNuevoLibro = _Dbl_MontoNuevo;

                                    //Quitamos signos
                                    _Dbl_MontoNuevo = Math.Abs(_Dbl_MontoNuevo);
                                    _Dbl_MontoNuevoLibro = Math.Abs(_Dbl_MontoNuevoLibro);

                                    //Corregimos los signos segun la naturaleza
                                    if (_Str_NaturalezaLibro == "H")
                                    {
                                        _Dbl_MontoNuevoLibro = _Dbl_MontoNuevoLibro * (-1);
                                    }
                                    else
                                    {
                                        _Dbl_MontoNuevo = _Dbl_MontoNuevo * (-1);
                                    }

                                    // = -= -= -= -= -= -= -= -= -= -= -= - GENERAMOS ASIENTOS = -= -= -= -= -= -= -= -= -= -= -= - 

                                    //Generamos el Asiento Nuevo (Cuenta Banco)
                                    _Mtd_Proceso_GenerarAsientoNuevo(_Dtg_Comprobante, _Int_TipoAjuste, _Str_ccount, _Str_ccountcname, _Dbl_MontoNuevo, _Bool_TieneAuxiliar, _Str_cidauxiliarcont, _Str_ctdocument, _Str_NumeroDocumentoNuevo, _Str_cidconciliaciondmanual, _Str_ConceptoNuevo, _Str_NumeroDocumentoNuevo, _Int_ciddetalleconciliacion.ToString(CultureInfo.InvariantCulture), ((byte)Clases._Cls_RutinasConciliacion._TipoRegistro.Nuevo).ToString(CultureInfo.InvariantCulture), _Str_Coletilla);

                                    //Generamos el Asiento Nuevo (Cuenta Comision o Intereses)
                                    _Mtd_Proceso_GenerarAsientoNuevo(_Dtg_Comprobante, _Int_TipoAjuste, _Str_ccount_ajustar, _Str_ccountcname_ajustar, _Dbl_MontoNuevoLibro, _Bool_TieneAuxiliar, _Str_cidauxiliarcont, _Str_ctdocument, _Str_NumeroDocumentoNuevo, _Str_cidconciliaciondmanual, _Str_ConceptoNuevo, _Str_NumeroDocumentoNuevo, _Int_ciddetalleconciliacion.ToString(CultureInfo.InvariantCulture), ((byte)Clases._Cls_RutinasConciliacion._TipoRegistro.Reverso).ToString(CultureInfo.InvariantCulture), _Str_Coletilla);
                                }
                            }
                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 
                            break;

                        case (byte)Tipoajuste.MuchosLibrosConMuchosBancos:
                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 

                            //Obtenemos lo datos del registro original
                            //Varibles de Trabajo
                            _RegLibro = _RegistrosLIBRO.First(); //Tomamos el primer registro 
                            _Str_cidcomprob = _RegLibro["cidcomprob"].ToString();
                            _Str_corder = _RegLibro["corder"].ToString();
                            _Str_ccountcname = _RegLibro["CuentaDescripcion"].ToString();
                            _Str_cidconciliaciondmanual = _RegLibro["cidconciliaciondmanual"].ToString();
                            _Str_CuentaDiferenciaNumero = _RegLibro["CuentaNumero"].ToString();
                            _Str_CuentaDiferenciaDescripcion = _RegLibro["CuentaDescripcion"].ToString();
                            //Cargamos los Registros Originales del libro
                            _Str_SentenciaSQL = "SELECT * FROM TCOMPROBAND WHERE CCOMPANY='" + _Str_ccompany + "' AND CIDCOMPROB='" + _Str_cidcomprob + "' AND CORDER='" + _Str_corder + "'";
                            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                            //Si existe
                            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                            {
                                //Obtenemos los otros datos necesarios
                                var _Str_cnumdocu = _Ds_DataSet.Tables[0].Rows[0]["cnumdocu"].ToString();
                                var _Str_cdescrip = _Ds_DataSet.Tables[0].Rows[0]["cdescrip"].ToString();
                                var _Str_ccount = _Ds_DataSet.Tables[0].Rows[0]["ccount"].ToString();
                                var _Dbl_ctotdebe = Convert.ToDouble(_Ds_DataSet.Tables[0].Rows[0]["ctotdebe"]);
                                var _Dbl_ctothaber = Convert.ToDouble(_Ds_DataSet.Tables[0].Rows[0]["ctothaber"]);
                                var _Str_ctdocument = _Ds_DataSet.Tables[0].Rows[0]["ctdocument"].ToString();
                                var _Dbl_Monto = Math.Round(_Dbl_ctotdebe - _Dbl_ctothaber, 2);

                                //Obtenemos el registro del auxiliar
                                _Str_SentenciaSQL = "SELECT * FROM TCOMPROBANDD WHERE CCOMPANY='" + _Str_ccompany + "' AND CIDCOMPROB='" + _Str_cidcomprob + "' AND CORDER='" + _Str_corder + "' AND CCOUNT = '" +
                                                    _Str_ccount + "'";
                                var _Ds_DataSetAuxiliar = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                                var _Bool_TieneAuxiliar = _Ds_DataSetAuxiliar.Tables[0].Rows.Count > 0;
                                var _Str_cidauxiliarcont = _Ds_DataSetAuxiliar.Tables[0].Rows.Count > 0 ? _Ds_DataSetAuxiliar.Tables[0].Rows[0]["cidauxiliarcont"].ToString() : "";

                                // = -= -= -= -= -= -= -= -= -= -= -= - OBTENEMOS LOS DATOS NECESARIOS DEL BANCO = -= -= -= -= -= -= -= -= -= -= -= - 
                                //Recorremos los registros de Banco
                                foreach (var _RegBanco in _RegistrosBANCO)
                                {

                                    //Obtengo los valores nuevos desde el registro correspondiente de BANCo
                                    var _Str_NumeroDocumentoNuevo = _RegBanco["Número Doc."].ToString();
                                    var _Str_ConceptoNuevo = _RegBanco["Concepto"].ToString();
                                    var _Dbl_MontoNuevo = Math.Round(Convert.ToDouble(_RegBanco["Monto"]), 2);
                                    var _Dbl_MontoDiferencia = Math.Round(_Dbl_TotalRegistrosLIBRO - _Dbl_Monto, 2);

                                    // = -= -= -= -= -= -= -= -= -= -= -= - GENERAMOS ASIENTOS = -= -= -= -= -= -= -= -= -= -= -= - 

                                    var _Str_Coletilla = " (AGRUP.REGIS)";

                                    //Generamos el Asiento Nuevo
                                    _Mtd_Proceso_GenerarAsientoNuevo(_Dtg_Comprobante, _Int_TipoAjuste, _Str_ccount, _Str_ccountcname, _Dbl_MontoNuevo, _Bool_TieneAuxiliar, _Str_cidauxiliarcont, _Str_ctdocument, _Str_NumeroDocumentoNuevo, _Str_cidconciliaciondmanual, _Str_ConceptoNuevo, _Str_NumeroDocumentoNuevo, _Int_ciddetalleconciliacion.ToString(CultureInfo.InvariantCulture), ((byte)Clases._Cls_RutinasConciliacion._TipoRegistro.Nuevo).ToString(CultureInfo.InvariantCulture), _Str_Coletilla);

                                }
                            }

                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 
                            break;

                        case (byte)Tipoajuste.MuchosLibrosConMuchosBancosConDiferenciaMonto:
                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 

                            //Obtenemos lo datos del registro original
                            //Varibles de Trabajo
                            _RegLibro = _RegistrosLIBRO.First(); //Tomamos el primer registro 
                            _Str_cidcomprob = _RegLibro["cidcomprob"].ToString();
                            _Str_corder = _RegLibro["corder"].ToString();
                            _Str_ccountcname = _RegLibro["CuentaDescripcion"].ToString();
                            _Str_cidconciliaciondmanual = _RegLibro["cidconciliaciondmanual"].ToString();
                            _Str_CuentaDiferenciaNumero = _RegLibro["CuentaNumero"].ToString();
                            _Str_CuentaDiferenciaDescripcion = _RegLibro["CuentaDescripcion"].ToString();
                            //Cargamos los Registros Originales del libro
                            _Str_SentenciaSQL = "SELECT * FROM TCOMPROBAND WHERE CCOMPANY='" + _Str_ccompany + "' AND CIDCOMPROB='" + _Str_cidcomprob + "' AND CORDER='" + _Str_corder + "'";
                            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                            //Si existe
                            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                            {
                                //Obtenemos los otros datos necesarios
                                var _Str_cnumdocu = _Ds_DataSet.Tables[0].Rows[0]["cnumdocu"].ToString();
                                var _Str_cdescrip = _Ds_DataSet.Tables[0].Rows[0]["cdescrip"].ToString();
                                var _Str_ccount = _Ds_DataSet.Tables[0].Rows[0]["ccount"].ToString();
                                var _Dbl_ctotdebe = Convert.ToDouble(_Ds_DataSet.Tables[0].Rows[0]["ctotdebe"]);
                                var _Dbl_ctothaber = Convert.ToDouble(_Ds_DataSet.Tables[0].Rows[0]["ctothaber"]);
                                var _Str_ctdocument = _Ds_DataSet.Tables[0].Rows[0]["ctdocument"].ToString();
                                var _Dbl_Monto = Math.Round(_Dbl_ctotdebe - _Dbl_ctothaber, 2);

                                //Obtenemos el registro del auxiliar
                                _Str_SentenciaSQL = "SELECT * FROM TCOMPROBANDD WHERE CCOMPANY='" + _Str_ccompany + "' AND CIDCOMPROB='" + _Str_cidcomprob + "' AND CORDER='" + _Str_corder + "' AND CCOUNT = '" +
                                                    _Str_ccount + "'";
                                var _Ds_DataSetAuxiliar = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);
                                var _Bool_TieneAuxiliar = _Ds_DataSetAuxiliar.Tables[0].Rows.Count > 0;
                                var _Str_cidauxiliarcont = _Ds_DataSetAuxiliar.Tables[0].Rows.Count > 0 ? _Ds_DataSetAuxiliar.Tables[0].Rows[0]["cidauxiliarcont"].ToString() : "";

                                // = -= -= -= -= -= -= -= -= -= -= -= - OBTENEMOS LOS DATOS NECESARIOS DEL BANCO = -= -= -= -= -= -= -= -= -= -= -= - 

                                var _Str_Coletilla = " (AGRUP.REGIS.DIF.MONT)";

                                //Recorremos los registros de Banco
                                foreach (var _RegBanco in _RegistrosBANCO)
                                {

                                    //Obtengo los valores nuevos desde el registro correspondiente de BANCo
                                    var _Str_NumeroDocumentoNuevo = _RegBanco["Número Doc."].ToString();
                                    var _Str_ConceptoNuevo = _RegBanco["Concepto"].ToString();
                                    var _Dbl_MontoNuevo = Math.Round(Convert.ToDouble(_RegBanco["Monto"]), 2);

                                    // = -= -= -= -= -= -= -= -= -= -= -= - GENERAMOS ASIENTOS = -= -= -= -= -= -= -= -= -= -= -= - 

                                    //Generamos el Asiento Nuevo
                                    _Mtd_Proceso_GenerarAsientoNuevo(_Dtg_Comprobante, _Int_TipoAjuste, _Str_ccount, _Str_ccountcname, _Dbl_MontoNuevo, _Bool_TieneAuxiliar, _Str_cidauxiliarcont, _Str_ctdocument, _Str_NumeroDocumentoNuevo, _Str_cidconciliaciondmanual, _Str_ConceptoNuevo, _Str_NumeroDocumentoNuevo, _Int_ciddetalleconciliacion.ToString(CultureInfo.InvariantCulture), ((byte)Clases._Cls_RutinasConciliacion._TipoRegistro.Nuevo).ToString(CultureInfo.InvariantCulture), _Str_Coletilla);

                                }

                                //Generamos el Asiento Nuevo con la Diferencia
                                var _Dbl_MontoDiferencia = Math.Round(_Dbl_TotalRegistrosBANCO - _Dbl_TotalRegistrosLIBRO, 2);
                                _Mtd_Proceso_GenerarAsientoNuevoDiferencia(_Dtg_Comprobante, _Str_CuentaDiferenciaNumero, _Str_CuentaDiferenciaDescripcion, _Str_ctdocument, _Str_cnumdocu, _Dbl_MontoDiferencia, "", "", _Int_ciddetalleconciliacion.ToString(CultureInfo.InvariantCulture), _Str_Coletilla, _Int_TipoAjuste);

                            }

                            // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 
                            break;
                    }
                }
            }
            //Generamos el Total del Comprobante
            if (_Dtg_Comprobante.RowCount > 0)
            {
                _Dtg_Comprobante.Rows.Add(new object[]
                    {null, null, "TOTAL", _Mtd_TotalDebeHaber(3), _Mtd_TotalDebeHaber(4)});
            }
            _Dtg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private string _Mtd_GenerarColetilla(string _P_Str_ConceptoBanco, string _P_Str_NumeroDocumentoBanco, string _P_Str_Coletilla, bool _P_Bool_EsNuevo)
        {
            var _Str_Coletilla = "";
            var _Str_NumeroDocumentoBanco = "";
            var _Str_ConceptoBanco = "";

            //Numero del Registro de Banco
            if (_P_Str_NumeroDocumentoBanco.Length>0)
                if (_P_Str_NumeroDocumentoBanco.Trim() == "0")
                {
                    //Numero de documento
                    _Str_NumeroDocumentoBanco = " " + _P_Str_NumeroDocumentoBanco + "";

                    //Concepto del Registro de Banco
                    if (_P_Str_ConceptoBanco.Length > 0)
                        _Str_ConceptoBanco = " " + _P_Str_ConceptoBanco + "";
                }
                else
                {
                    //Numero de documento
                    _Str_NumeroDocumentoBanco = " " + _P_Str_NumeroDocumentoBanco + "";

                    ////Concepto del Registro de Banco
                    if (_P_Bool_EsNuevo)
                        _Str_ConceptoBanco = " " + _P_Str_ConceptoBanco + "";

                }
            else
            {
                //Concepto del Registro de Banco
                if (_P_Str_ConceptoBanco.Length > 0)
                    _Str_ConceptoBanco = " " + _P_Str_ConceptoBanco + "";
            }

            //Generamos
            _Str_Coletilla = _Str_NumeroDocumentoBanco + _Str_ConceptoBanco + _P_Str_Coletilla + " AJU. CONC. " + _G_Int_Cidconciliacion;
            return _Str_Coletilla;
        }
        public void _Mtd_Proceso_GenerarAsientoReverso(DataGridView _P_Dg_Grid, int _P_Int_TipoAjuste, string _P_Str_Ccount, string _P_Str_CountContName, double _P_Dbl_Monto, bool _P_Bool_TieneAuxiliar, string _P_Str_Cidauxiliarcont, string _P_Str_Ctdocument, string _P_Str_Cnumdocu, string _P_Str_Ciddetalleconciliacion, string _P_Str_ConceptoBanco, string _P_Str_NumeroDocumentoBanco, string _P_Str_Coletilla)
        {
            var _Str_Coletilla = _Mtd_GenerarColetilla(_P_Str_ConceptoBanco, _P_Str_NumeroDocumentoBanco, _P_Str_Coletilla,false);

            // - - - - - - - - - - - - - - - - - Registro que Reversa - - - - - - - - - - - - - - - - - 
            string _Str_CountCont = _P_Str_Ccount;
            string _Str_CountContName = _P_Str_CountContName.Trim();
            _P_Dg_Grid.Rows.Add();
            _P_Dg_Grid[0, _P_Dg_Grid.RowCount - 1].Value = _Str_CountCont;
            _P_Dg_Grid[2, _P_Dg_Grid.RowCount - 1].Value = (_Str_CountContName + _Str_Coletilla).Trim();
            if (_P_Dbl_Monto > 0)
            {
                _P_Dg_Grid[3, _P_Dg_Grid.RowCount - 1].Value = "";
                _P_Dg_Grid[4, _P_Dg_Grid.RowCount - 1].Value = Math.Abs(_P_Dbl_Monto).ToString("#,##0.00");
            }
            else
            {
                _P_Dg_Grid[3, _P_Dg_Grid.RowCount - 1].Value = Math.Abs(_P_Dbl_Monto).ToString("#,##0.00");
                _P_Dg_Grid[4, _P_Dg_Grid.RowCount - 1].Value = "";
            }

            //Guardo si tiene auxiliar contable y los datos necesarios
            _P_Dg_Grid[5, _P_Dg_Grid.RowCount - 1].Value = _P_Bool_TieneAuxiliar ? "1" : "0";
            _P_Dg_Grid[6, _P_Dg_Grid.RowCount - 1].Value = _P_Str_Cidauxiliarcont;
            _P_Dg_Grid[7, _P_Dg_Grid.RowCount - 1].Value = "1";
            _P_Dg_Grid[8, _P_Dg_Grid.RowCount - 1].Value = _P_Str_Ctdocument;
            _P_Dg_Grid[9, _P_Dg_Grid.RowCount - 1].Value = _P_Str_Cnumdocu;
            _P_Dg_Grid[10, _P_Dg_Grid.RowCount - 1].Value = "1"; //MarcarConciliado
            _P_Dg_Grid[11, _P_Dg_Grid.RowCount - 1].Value = "";
            _P_Dg_Grid[12, _P_Dg_Grid.RowCount - 1].Value = _P_Str_Ciddetalleconciliacion;
            _P_Dg_Grid[13, _P_Dg_Grid.RowCount - 1].Value = ((byte)Clases._Cls_RutinasConciliacion._TipoRegistro.Reverso).ToString(CultureInfo.InvariantCulture);
            _P_Dg_Grid[14, _P_Dg_Grid.RowCount - 1].Value = _P_Int_TipoAjuste;

        }
        public void _Mtd_Proceso_GenerarAsientoNuevo(DataGridView _P_Dg_Grid, int _P_Int_TipoAjuste, string _P_Str_Ccount, string _P_Str_CountContName, double _P_Dbl_Monto, bool _P_Bool_TieneAuxiliar, string _P_Str_Cidauxiliarcont, string _P_Str_Ctdocument, string _P_Str_Cnumdocu, string _P_Str_Cidconciliaciondmanual, string _P_Str_ConceptoBanco, string _P_Str_NumeroDocumentoBanco, string _P_Str_Ciddetalleconciliacion, string _P_Str_Ctiporegistro, string _P_Str_Coletilla)
        {
            var _Str_Coletilla = _Mtd_GenerarColetilla(_P_Str_ConceptoBanco, _P_Str_NumeroDocumentoBanco, _P_Str_Coletilla,true);
            var _Str_CountCont = _P_Str_Ccount;
            var _Str_CountContName = _P_Str_CountContName;

            _P_Dg_Grid.Rows.Add();
            _P_Dg_Grid[0, _P_Dg_Grid.RowCount - 1].Value = _Str_CountCont;
            _P_Dg_Grid[2, _P_Dg_Grid.RowCount - 1].Value = _Str_Coletilla.Trim();
            if (_P_Dbl_Monto > 0)
            {
                _P_Dg_Grid[3, _P_Dg_Grid.RowCount - 1].Value = Math.Abs(_P_Dbl_Monto).ToString("#,##0.00");
                _P_Dg_Grid[4, _P_Dg_Grid.RowCount - 1].Value = "";
            }
            else
            {
                _P_Dg_Grid[3, _P_Dg_Grid.RowCount - 1].Value = "";
                _P_Dg_Grid[4, _P_Dg_Grid.RowCount - 1].Value = Math.Abs(_P_Dbl_Monto).ToString("#,##0.00");
            }
            //Guardo si tiene axuxiliar contable y los datos necesarios
            _P_Dg_Grid[5, _P_Dg_Grid.RowCount - 1].Value = _P_Bool_TieneAuxiliar ? "1" : "0";
            _P_Dg_Grid[6, _P_Dg_Grid.RowCount - 1].Value = _P_Str_Cidauxiliarcont;
            _P_Dg_Grid[7, _P_Dg_Grid.RowCount - 1].Value = "0";
            _P_Dg_Grid[8, _P_Dg_Grid.RowCount - 1].Value = _P_Str_Ctdocument;
            _P_Dg_Grid[9, _P_Dg_Grid.RowCount - 1].Value = _P_Str_Cnumdocu;
            _P_Dg_Grid[10, _P_Dg_Grid.RowCount - 1].Value = "0"; //MarcarConciliado
            _P_Dg_Grid[11, _P_Dg_Grid.RowCount - 1].Value = _P_Str_Cidconciliaciondmanual;
            _P_Dg_Grid[12, _P_Dg_Grid.RowCount - 1].Value = _P_Str_Ciddetalleconciliacion;
            _P_Dg_Grid[13, _P_Dg_Grid.RowCount - 1].Value = _P_Str_Ctiporegistro;
            _P_Dg_Grid[14, _P_Dg_Grid.RowCount - 1].Value = _P_Int_TipoAjuste;
        }
        public void _Mtd_Proceso_GenerarAsientoNuevoDiferencia(DataGridView _P_Dg_Grid, string _P_Str_Ccount, string _P_Str_CountContName, string _P_Str_Ctdocument, string _P_Str_Cnumdocu, double _P_Dbl_Monto, string _P_Str_ConceptoBanco, string _P_Str_NumeroDocumentoBanco, string _P_Str_Ciddetalleconciliacion, string _P_Str_Coletilla, int _P_Int_TipoAjuste)
        {
            var _Str_Coletilla = _Mtd_GenerarColetilla(_P_Str_ConceptoBanco, _P_Str_NumeroDocumentoBanco, _P_Str_Coletilla, false);
            var _Str_CountCont = _P_Str_Ccount;
            var _Str_CountContName = _P_Str_CountContName;
            _P_Dg_Grid.Rows.Add();
            _P_Dg_Grid[0, _P_Dg_Grid.RowCount - 1].Value = _Str_CountCont;
            _P_Dg_Grid[2, _P_Dg_Grid.RowCount - 1].Value = (_Str_CountContName + _Str_Coletilla).Trim();
            if (_P_Dbl_Monto < 0)
            {
                _P_Dg_Grid[3, _P_Dg_Grid.RowCount - 1].Value = Math.Abs(_P_Dbl_Monto).ToString("#,##0.00");
                _P_Dg_Grid[4, _P_Dg_Grid.RowCount - 1].Value = "";
            }
            else
            {
                _P_Dg_Grid[3, _P_Dg_Grid.RowCount - 1].Value = "";
                _P_Dg_Grid[4, _P_Dg_Grid.RowCount - 1].Value = Math.Abs(_P_Dbl_Monto).ToString("#,##0.00");
            }
            //Guardo si tiene axuxiliar contable y los datos necesarios
            _P_Dg_Grid[5, _P_Dg_Grid.RowCount - 1].Value = "0";
            _P_Dg_Grid[6, _P_Dg_Grid.RowCount - 1].Value = "";
            _P_Dg_Grid[7, _P_Dg_Grid.RowCount - 1].Value = "0";
            _P_Dg_Grid[8, _P_Dg_Grid.RowCount - 1].Value = _P_Str_Ctdocument;
            _P_Dg_Grid[9, _P_Dg_Grid.RowCount - 1].Value = _P_Str_Cnumdocu;
            _P_Dg_Grid[10, _P_Dg_Grid.RowCount - 1].Value = "0"; //MarcarConciliado
            _P_Dg_Grid[11, _P_Dg_Grid.RowCount - 1].Value = "";
            _P_Dg_Grid[12, _P_Dg_Grid.RowCount - 1].Value = _P_Str_Ciddetalleconciliacion;
            _P_Dg_Grid[13, _P_Dg_Grid.RowCount - 1].Value = ((byte) Clases._Cls_RutinasConciliacion._TipoRegistro.Diferencia).ToString(CultureInfo.InvariantCulture);
            _P_Dg_Grid[14, _P_Dg_Grid.RowCount - 1].Value = _P_Int_TipoAjuste;

        }

        private string _Mtd_TotalDebeHaber(int _P_Int_Col_Index)
        {
            double _Dbl_Total = 0;
            foreach (DataGridViewRow _Dg_Row in _Dtg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (_Dg_Row.Cells[0].Value.ToString().Trim().Length > 0)
                    {
                        object _Ob_Valor = _Dg_Row.Cells[_P_Int_Col_Index].Value;
                        if (_Ob_Valor == null)
                        {
                            _Ob_Valor = 0;
                        }
                        else if (_Ob_Valor.ToString().Trim().Length == 0)
                        {
                            _Ob_Valor = 0;
                        }
                        _Dbl_Total += Convert.ToDouble(_Ob_Valor);
                    }
                }
            }
            return _Dbl_Total.ToString("#,##0.00");
        }

        private bool _Mtd_CuentaDetalle(string _P_Str_Cuenta)
        {
            string _Str_Cadena = "Select ctcount from TCOUNT where ccompany='" + Frm_Padre._Str_Comp +
                                 "' AND cactivate='1' AND ccount='" + _P_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper() == "D")
                {
                    return true;
                }
            }
            return false;
        }

        private string _Mtd_ObtenerDescripCuenta(string _P_Str_Cuenta)
        {
            string _Str_Cadena = "Select cname from TCOUNT where ccompany='" + Frm_Padre._Str_Comp + "' and ccount='" +
                                 _P_Str_Cuenta + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            return "";
        }

        #region = - = - = - = - = - = - = - = - = - = - Rutinas del Panel de Contraseña = - = - = - = - = - = - = - = - = - = -

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _LayoutCompleto.Enabled = false;
                _Bt_GuardarCambios.Enabled = false;
                _Txt_Clave.Text = "";
                _Txt_Clave.Focus();
            }
            else
            {
                _Bt_GuardarCambios.Enabled = _G_Bol_PermisoAprobacion;
                _LayoutCompleto.Enabled = true;
            }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
            ((Frm_Padre) MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
        }

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                _Pnl_Clave.Visible = false;
                _Mtd_GuardarFormulario();
            }
            else
            {
                MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                _Txt_Clave.Focus();
                _Txt_Clave.Select(0, _Txt_Clave.Text.Length);
            }
        }
        #endregion

        #region = - = - = - = - = - = - = - = - = - = - Rutinas de comprobante = - = - = - = - = - = - = - = - = - = -

        private string _Mtd_GuardarComprobante()
        {
            var _Str_Comprobante = "";
            Cursor = Cursors.WaitCursor;
            try
            {
                _Str_Comprobante = _Mtd_CrearComprobanteContable();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor = Cursors.Default;
            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre) MdiParent)._Frm_Contenedor._async_Default);
            MessageBox.Show("La operación ha sido realizada correctamente.\nSe va a proceder a imprimir el comprobante: " + _Mtd_RetornarID_Correl(_Str_Comprobante), "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return _Str_Comprobante;
        }

        private string _Mtd_RetornarID_Correl(string _P_Str_Comprobante)
        {
            string _Str_Cadena = "SELECT cidcorrel FROM TCOMPROBANC WHERE ccompany='" + Frm_Padre._Str_Comp +
                                 "' AND cidcomprob='" + _P_Str_Comprobante + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "0";
        }

        private void _Mtd_TotalDebeHaber(out double _P_Str_Debe, out double _P_Str_Haber)
        {
            double _Dbl_Total_Debe = 0, _Dbl_Total_Haber = 0;
            _Dtg_Comprobante.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[0].Value != null).ToList().ForEach(x =>
                {
                    double _Dbl_Debe;
                    double.TryParse(Convert.ToString(x.Cells[3].Value), out _Dbl_Debe);
                    double _Dbl_Haber;
                    double.TryParse(Convert.ToString(x.Cells[4].Value), out _Dbl_Haber);
                    _Dbl_Total_Debe += _Dbl_Debe;
                    _Dbl_Total_Haber += _Dbl_Haber;
                });
            _P_Str_Debe = Math.Round(_Dbl_Total_Debe, 2);
            _P_Str_Haber = Math.Round(_Dbl_Total_Haber, 2);
        }

        private string _Mtd_CrearComprobanteContable()
        {
            //Obtenemos mesy año contable de la fecha hasta
            var _Str_MesContable = _G_Dt_FechaHasta.Month.ToString(CultureInfo.InvariantCulture);
            var _Str_AnoContable = _G_Dt_FechaHasta.Year.ToString(CultureInfo.InvariantCulture);

            //Por defecto tomamo la fecha hasta como fecha del comprobante a generar
            DateTime _Dt_FechaComprobante = _G_Dt_FechaHasta;

            //'---=---=---=---=---=---=---=---=---=---=---=---=---=---=---=---=---=---=---=---=---=---=---=---=---=---=---=---=
            double _Dbl_Debe, _Dbl_Haber;
            _Mtd_TotalDebeHaber(out _Dbl_Debe, out _Dbl_Haber);
            var _Str_Cconceptocomp = _Txt_EncabezadoComprobante.Text.Trim().Replace("'","''");
            var _Str_Ctypcompro = "06";
            var _Int_Comprobante = _Cls_VariosMetodos._Mtd_Consecutivo_TCOMPROBANC();
            var _Str_Cadena =
                "INSERT INTO TCOMPROBANC (ccompany,cidcomprob,ctypcomp,cname,cyearacco,cmontacco,cregdate,ctotdebe,ctothaber,cbalance,cdateadd,cuseradd,clvalidado,cstatus) VALUES ('" +
                Frm_Padre._Str_Comp + "','" + _Int_Comprobante + "','" + _Str_Ctypcompro + "','" + _Str_Cconceptocomp +
                "','" +
                _Str_AnoContable + "','" +
                _Str_MesContable + "','" +
                _Cls_Formato._Mtd_fecha(_Dt_FechaComprobante) + "','" +
                CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "','" +
                CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "','0',GETDATE(),'" + Frm_Padre._Str_Use +
                "','1','0')";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            _Dtg_Comprobante.Rows.Cast<DataGridViewRow>()
                           .Where(x => x.Cells["Cuenta"].Value != null)
                           .ToList()
                           .ForEach(x =>
                               {
                                   var _Str_Cuenta = Convert.ToString(x.Cells["Cuenta"].Value).Trim();
                                   var _Str_Descrip = Convert.ToString(x.Cells["Descripcion"].Value).ToUpper().Trim().Replace("'","''");
                                   var _Str_TipoDocumento = Convert.ToString(x.Cells["ctdocument"].Value).Trim();
                                   var _Str_Documento = Convert.ToString(x.Cells["cnumdocu"].Value).Trim();
                                   //var _Str_MarcarConciliado = x.Cells["MarcarConciliado"].Value.ToString(); //Solicitud 8546
                                   var _Str_MarcarConciliado = "0"; //Solicitud 8546

                                   double _Dbl_DebeD, _Dbl_HaberD;
                                   double.TryParse(Convert.ToString(x.Cells["Debe"].Value), out _Dbl_DebeD);
                                   double.TryParse(Convert.ToString(x.Cells["Haber"].Value), out _Dbl_HaberD);
                                   _Str_Cadena =
                                       "INSERT INTO TCOMPROBAND (ccompany,cidcomprob,corder,ccount,cdescrip,ctdocument,cnumdocu,cdatedocu,ctotdebe,ctothaber,cdateadd,cuseradd,cconciliado)VALUES('" +
                                       Frm_Padre._Str_Comp + "','" + _Int_Comprobante.ToString(CultureInfo.InvariantCulture) + "','" + (x.Index + 1) +
                                       "','" + _Str_Cuenta + "','" + _Str_Descrip + "','" + _Str_TipoDocumento + "','" +
                                       _Str_Documento + "','" +
                                       _Cls_Formato._Mtd_fecha(_Dt_FechaComprobante) + "','" +
                                       CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_DebeD) + "','" +
                                       CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_HaberD) + "',GETDATE(),'" +
                                       Frm_Padre._Str_Use + "','" + _Str_MarcarConciliado + "')";
                                   Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

                                   //Verifico si el registro tiene un auxiliar
                                   var _Bool_TieneAuxiliar = x.Cells["TieneAuxiliar"].Value.ToString() == "1";
                                   var _Str_cidauxiliarcont = Convert.ToString(x.Cells["cidauxiliarcont"].Value).Trim();
                                   var _Bool_EsReverso = x.Cells["EsReverso"].Value.ToString() == "1";

                                   if (_Bool_TieneAuxiliar)
                                   {
                                       if (_Dbl_DebeD != 0)
                                       {
                                           CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(
                                               _Int_Comprobante.ToString(), _Str_Cuenta, _Str_cidauxiliarcont,
                                               _Str_Descrip, _Str_TipoDocumento, _Str_Documento,
                                               _Cls_Formato._Mtd_fecha(_Dt_FechaComprobante),
                                               _Cls_Formato._Mtd_fecha(_Dt_FechaComprobante),
                                               CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_DebeD),
                                               _Str_MesContable,
                                               _Str_AnoContable,
                                               "D");
                                       }
                                       else
                                       {
                                           CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(
                                               _Int_Comprobante.ToString(CultureInfo.InvariantCulture), _Str_Cuenta, _Str_cidauxiliarcont,
                                               _Str_Descrip, _Str_TipoDocumento, _Str_Documento,
                                               _Cls_Formato._Mtd_fecha(_Dt_FechaComprobante),
                                               _Cls_Formato._Mtd_fecha(_Dt_FechaComprobante),
                                               CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_HaberD),
                                               _Str_MesContable,
                                               _Str_AnoContable,
                                               "H");
                                       }
                                   }


                                   //Insertamos en TCONCILIACIOND_MANUALV2 todos los registros nuevos correspondientes a cada detalle de conciliacion 
                                   var _Str_ciddetalleconciliacion = x.Cells["ciddetalleconciliacion"].Value.ToString();
                                   var _Str_ctiporegistro = x.Cells["ctiporegistro"].Value.ToString();
                                   var _Str_ctipoajuste = x.Cells["ctipoajuste"].Value.ToString();
                                   if (_Str_ciddetalleconciliacion.Trim() != "")
                                   {
                                       var _Str_SQL = "INSERT INTO TCONCILIACIOND_MANUALV2 (ccompany,cidconciliacion,ciddetalleconciliacion,ciddispbanc,ciddispband,cidcomprob,corder,cidcomprob_nuevo,corder_nuevo,ctipoajuste,coperbancseleccionado,caprobado,ctiporegistro,cautomatico,cdelete,cdateadd,cuseradd) VALUES (" +
                                           "'" + Frm_Padre._Str_Comp + "','" + _G_Int_Cidconciliacion + "','" + _Str_ciddetalleconciliacion + "','0','0','0','0','" + _Int_Comprobante + "','" + (x.Index + 1) + "'" +
                                                      ",'" + _Str_ctipoajuste + "'" + //Tipoajuste
                                                      ",'','1','" + _Str_ctiporegistro + "'" +
                                                      ",'1'" +
                                                      ",'0',GETDATE(),'" + Frm_Padre._Str_Use + "'" + 
                                                      ")";
                                       Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_SQL);
                                   }

                               });
            return _Int_Comprobante.ToString(CultureInfo.InvariantCulture);
        }

        private void _Mtd_ImprimirComprobante(string _P_Str_Comprobante)
        {
            try
            {
                PrintDialog _Print = new PrintDialog();
                _PrintComprob:
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    REPORTESS _Frm = new REPORTESS(new[] {"vst_reportecomprobante"}, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit","ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" +_P_Str_Comprobante + "'", _Print, true);
                    Cursor = Cursors.Default;
                    if (
                        MessageBox.Show("¿El comprobante se imprimió correctamente?", "Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _Frm.Close();
                        _Frm.Dispose();
                        string _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='1',clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + 
                                            "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Str_Comprobante + "'"; 
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                        MessageBox.Show("El comprobante ha sido actualizado.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        _Frm.Close();
                        _Frm.Dispose();
                        goto _PrintComprob;
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Debe actualizar el comprobante desde el notificador 'COMPROBANTES POR ACTUALIZAR'",
                        "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                Cursor = Cursors.Default;
                MessageBox.Show(
                    "Error al intentar imprimir.\nDebe actualizar el comprobante desde el notificador 'COMPROBANTES POR ACTUALIZAR'\n",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        
        #region = - = - = - = - = - = - = - = - = - = - Guardado de Cambios = - = - = - = - = - = - = - = - = - = -

        private void _Bt_GuardarCambios_Click(object sender, EventArgs e)
        {
            _Mtd_Guardar();
        }
        public bool _Mtd_Guardar()
        {
            try
            {
                //---
                _Dtg_Comprobante.EndEdit();
                //Validaciones
                if (_Mtd_HayRegistrosRegistrosEnEsperaSegunPestaña(_G_Str_PestañaActual))
                {
                    MessageBox.Show("Existen Registros a la Espera de Aprobación o Rechazo, por favor verifique...", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (!_Mtd_TodosLosRegistrosNoGenerarComprobanteSegunPestaña(_G_Str_PestañaActual))
                {
                    if (_Dtg_Comprobante.RowCount == 0)
                    {
                        MessageBox.Show("Debe visualizar el comprobante.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                if (!_Mtd_VerificarCuentas())
                {
                    MessageBox.Show("El registro contable solo puede realizarse con cuentas de detalle que estén activas.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (!_Mtd_DescripcionesCompletas())
                {
                    MessageBox.Show("Debe ingresar la descripción para cada registro.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (_Mtd_DescripcionesDesbordadas())
                {
                    MessageBox.Show("Algunos registros tienen descripciones que superan el máximo permitido (255 caracteres).", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                double _Dbl_Debe, _Dbl_Haber;
                _Mtd_TotalDebeHaber(out _Dbl_Debe, out _Dbl_Haber);
                if (_Dbl_Debe != _Dbl_Haber)
                {
                    MessageBox.Show("El comprobante esta descuadrado. Por favor verifique!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                _Pnl_Clave.Visible = true;
                _Pnl_Clave.BringToFront();
                ((Frm_Padre)MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                return false;
            }
            catch (Exception _Ex) 
            {
                MessageBox.Show(_Ex.Message);
                return false;
            }
        }

        #endregion

        #region = - = - = - = - = - = - = - = - = - = - Rutinas para validación de cuentas seleccionadas por el usuario

        /// <summary>
        /// Indica si la pestaña actual tiene aun registro a la espera de aprobación o rechazo
        /// </summary>
        /// <param name="_P_Str_NombrePestaña"></param>
        /// <returns></returns>
        private bool _Mtd_HayRegistrosRegistrosEnEsperaSegunPestaña(string _P_Str_NombrePestaña)
        {
            //Obtenemos los tipos de ajuste segun la pestaña actual
            var _Lst_TiposAjuste = _Mtd_ObtenerTiposDeAjusteSegunPestaña(_P_Str_NombrePestaña);

            //Si no hay tipos de ajuste salimos
            if (_Lst_TiposAjuste.Count == 0) return false;

            //Valido que no hayan conciliaciones por aprobar
            var _ORegistros = _G_Ds_BancoLibro.Tables[0]
                                              .AsEnumerable()
                                              .Where(x => x["estadoaprobacion"].ToString() == ((byte)EstadosAprobacion.EnEspera).ToString(CultureInfo.InvariantCulture))
                                              .Where(x => _Lst_TiposAjuste.Any(y => y.ToString(CultureInfo.InvariantCulture) == x["ctipoajuste"].ToString()));
            return _ORegistros.Any();
        }


        /// <summary>
        /// verifico si todos los ajustes no generarn comprobante
        /// </summary>
        /// <returns></returns>
        private bool _Mtd_TodosLosRegistrosNoGenerarComprobanteSegunPestaña(string _P_Str_NombrePestaña)
        {
            //Obtenemos los tipos de ajuste segun la pestaña actual
            var _Lst_TiposAjuste = _Mtd_ObtenerTiposDeAjusteSegunPestaña(_P_Str_NombrePestaña);

            //Si no hay tipos de ajuste salimos
            if (_Lst_TiposAjuste.Count == 0) return false;

            //Solo si hay aprobaciones que genere un comprobante 
            var _ORegistros = _G_Ds_BancoLibro.Tables[0]
                                              .AsEnumerable()
                                              .Where(x => _Lst_TiposAjuste.Any(y => y.ToString(CultureInfo.InvariantCulture) == x["ctipoajuste"].ToString()))
                                              .Count(x =>  
                                                     x["estadoaprobacion"].ToString() == ((byte) EstadosAprobacion.Aprobada).ToString(CultureInfo.InvariantCulture)
                                                 &&  Convert.ToByte(x["ctipoajuste"]) != (byte)Tipoajuste.CruceMovimientosContables
                                                     );
            return (_ORegistros == 0);
        }

        /// <summary>
        /// Verifica si todas las cuentas existen
        /// </summary>
        /// <returns></returns>
        private bool _Mtd_VerificarCuentas()
        {
            foreach (DataGridViewRow _Dg_Row in _Dtg_Comprobante.Rows)
            {
                if (Convert.ToString(_Dg_Row.Cells[0].Value).Trim().Length > 0)
                {
                    var _Str_Cadena = "Select ctcount,cactivate from TCOUNT where ccompany='" + Frm_Padre._Str_Comp +
                                         "' and ccount='" + _Dg_Row.Cells[0].Value + "'";
                    var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count == 0)
                    {
                        return false;
                    }
                    if (_Ds.Tables[0].Rows[0]["ctcount"].ToString().Trim().ToUpper() != "D" ||
                             _Ds.Tables[0].Rows[0]["cactivate"].ToString().Trim().ToUpper() != "1")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool _Mtd_DescripcionesCompletas()
        {
            var _Str_Cadena = "";
            var _Ds = new DataSet();
            foreach (DataGridViewRow _Dg_Row in _Dtg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (Convert.ToString(_Dg_Row.Cells[2].Value).Trim().Length == 0)
                        return false;
                }
            }
            return true;
        }

        private bool _Mtd_DescripcionesDesbordadas()
        {
            var _Str_Cadena = "";
            var _Ds = new DataSet();
            foreach (DataGridViewRow _Dg_Row in _Dtg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    if (Convert.ToString(_Dg_Row.Cells[2].Value).Trim().Length > 255)
                        return true;
                }
            }
            return false;
        }

        #endregion

        #region = - = - = - = - = - = - = - = - = - = - Esto es para enviar el edit los checkboxes  = - = - = - = - = - = - = - = - = - = -

        private void _Dtg_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            var _Dtg = (DataGridView)sender;
            if (_Dtg.IsCurrentCellDirty)
            {
                _Dtg.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        #endregion

        #region  = - = - = - = - = - = - = - = - = - = - Usuario hace clic en los checkboxes  = - = - = - = - = - = - = - = - = - = -
        private void _Dtg_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 & e.RowIndex >= 0 & !_G_EditandoFila)
            {
                var intAprobar = 0;
                var intRechazar = 1;
                var intAprobar2 = 28;
                var intRechazar2 = 29;
                var _Str_Accion = "";
                
                //Detecto donde hizo clic
                if ((e.ColumnIndex == intAprobar) || (e.ColumnIndex == intAprobar2))
                {
                    _Str_Accion = "APROBAR";
                }
                else if ((e.ColumnIndex == intRechazar) || (e.ColumnIndex == intRechazar2))
                {
                    _Str_Accion = "RECHAZAR";
                }
                else
                {
                    _Str_Accion = "";
                    return;
                }

                //Cambiamos la bandera
                _G_EditandoFila = true;

                //Inicializamos el Objeto del grid
                var _Dtg = (DataGridView) sender;

                //Limpiamos el grid
                _Dtg_Comprobante.Rows.Clear();

                // Obtengo los dos checks
                var _OAprobar = (DataGridViewCheckBoxCell)_Dtg["Aprobar", e.RowIndex];
                var _ORechazar = (DataGridViewCheckBoxCell)_Dtg["Rechazar", e.RowIndex];
                var _OEstadoAprobacion = (DataGridViewTextBoxCell)_Dtg["estadoaprobacion", e.RowIndex];

                //En funcion a donde hice el clic deschequeo el contrario
                if (_Str_Accion == "APROBAR")
                    _ORechazar.Value = false;
                else
                    _OAprobar.Value = false;

                var _Int_EstadoAprobacion = (byte)EstadosAprobacion.EnEspera;

                //En funcion a donde hice el clic genero el estado de aprobacion
                if (Convert.ToBoolean(_OAprobar.Value))
                    _Int_EstadoAprobacion = (byte)EstadosAprobacion.Aprobada;
                if (Convert.ToBoolean(_ORechazar.Value))
                    _Int_EstadoAprobacion = (byte)EstadosAprobacion.Rechazada;

                //En función al tipo de ajuste que estoy aprobando
                var _Int_TipoAjuste = Convert.ToInt32(_Dtg.Rows[e.RowIndex].Cells["ctipoajuste"].Value);
                var _Str_CuentaNumero = "";
                var _Str_CuentaDescripcion = "";
                switch (_Int_TipoAjuste)
                {
                    //Estos NO muestran formulario de seleccion de cuentas
                    case (byte) Tipoajuste.UnoAUnoDiferenciaNumero:
                    case (byte) Tipoajuste.MultiplesAgrupamientoRegistros:
                    case (byte) Tipoajuste.MultiplesDivisionRegistros:
                    case (byte) Tipoajuste.CruceMovimientosContables:
                    case (byte) Tipoajuste.CruceMovimientosBanco:
                    case (byte) Tipoajuste.ComisionesEIntereses:
                    case (byte) Tipoajuste.ComisionesEIntereses_Reverso:
                    case (byte) Tipoajuste.MuchosLibrosConMuchosBancos:
                        break;

                    //Estos SI muestran formulario de seleccion de cuentas
                    case (byte)Tipoajuste.UnoAUnoDiferenciaMonto:
                    case (byte) Tipoajuste.MultiplesAgrupamientoRegistrosConDiferenciaMonto:
                    case (byte) Tipoajuste.MultiplesDivisionRegistrosConDiferenciaMonto:
                    case (byte) Tipoajuste.MuchosLibrosConMuchosBancosConDiferenciaMonto:

                        //Mostramos la pantalla de seleccion de cuentas
                        if (_Int_EstadoAprobacion == (byte)EstadosAprobacion.Aprobada)
                        {
                            _Int_EstadoAprobacion = (byte)EstadosAprobacion.EnEspera;
                            //La coloco en espera a la espera de selecionar una cuenta valida
                            Cursor = Cursors.WaitCursor;
                            var _Frm = new Frm_VstCuentas();
                            Cursor = Cursors.Default;
                            _Frm.ShowDialog();
                            if (_Frm._Str_FrmNodeSelec.Trim().Length > 0)
                            {
                                if (_Mtd_CuentaDetalle(_Frm._Str_FrmNodeSelec.Trim()))
                                {
                                    _Str_CuentaNumero = _Frm._Str_FrmNodeSelec.Trim();
                                    _Str_CuentaDescripcion = _Mtd_ObtenerDescripCuenta(_Frm._Str_FrmNodeSelec.Trim()); 
                                    _Int_EstadoAprobacion = (byte)EstadosAprobacion.Aprobada;
                                }
                                else
                                {
                                    MessageBox.Show("Debe ingresar una cuenta de detalle", "Requerimiento", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                                }
                            }
                            _Frm.Dispose();
                        }
                        break;
                }

                //Obtenemos el Indice
                var _Int_Id = _Dtg.Rows[e.RowIndex].Cells["ciddetalleconciliacion"].Value.ToString();

                //Marco los registros para Aprobar (Dataset)
                var _ORegistros = _G_Ds_BancoLibro.Tables[0]
                                                  .AsEnumerable()
                                                  .Where(x => x["ciddetalleconciliacion"].ToString() == _Int_Id);
                foreach (DataRow _ORegistro in _ORegistros)
                {
                    //Marco
                    _ORegistro["estadoaprobacion"] = _Int_EstadoAprobacion;
                    _OEstadoAprobacion.Value = _Int_EstadoAprobacion;
                    //Guardo la cuenta seleccionada
                    if (_Int_EstadoAprobacion == (byte)EstadosAprobacion.Aprobada)
                    {
                        if ((_Str_CuentaNumero != "") && (_Str_CuentaDescripcion != ""))
                        {
                            _ORegistro["CuentaNumero"] = _Str_CuentaNumero;
                            _ORegistro["CuentaDescripcion"] = _Str_CuentaDescripcion;
                        }
                    }
                }

                //Esto es para poder que se actualiza el estado del checkbox
                _Dtg.EndEdit();

                //Marco los registros para Aprobar (Grid)
                var _ORegistrosGrid = _Dtg.Rows.Cast<DataGridViewRow>()
                                                       .Where(x => x.Cells["ciddetalleconciliacion"].Value.ToString() == _Int_Id)
                                                       .ToList();
                foreach (var _ORegistro in _ORegistrosGrid)
                {
                    //Marco
                    _ORegistro.Cells["estadoaprobacion"].Value = _Int_EstadoAprobacion;
                    //Guardo la cuenta seleccionada
                    if (_Int_EstadoAprobacion == (byte)EstadosAprobacion.Aprobada)
                    {
                        if ((_Str_CuentaNumero != "") && (_Str_CuentaDescripcion != ""))
                        {
                            _ORegistro.Cells["CuentaNumero"].Value = _Str_CuentaNumero;
                            _ORegistro.Cells["CuentaDescripcion"].Value = _Str_CuentaDescripcion;
                        }
                    }
                    //Borro la cuenta seleccionada
                    if (_Int_EstadoAprobacion == (byte)EstadosAprobacion.Rechazada)
                    {
                        _ORegistro.Cells["CuentaNumero"].Value = "";
                        _ORegistro.Cells["CuentaDescripcion"].Value = "";
                    }
                    //Estado de los Check
                    switch (_Int_EstadoAprobacion)
                    {
                        case (byte)EstadosAprobacion.EnEspera:
                            _ORegistro.Cells["Aprobar"].Value = false;
                            _ORegistro.Cells["Rechazar"].Value = false;
                            break;
                        case (byte)EstadosAprobacion.Aprobada:
                            _ORegistro.Cells["Aprobar"].Value = true;
                            _ORegistro.Cells["Rechazar"].Value = false;
                            break;
                        case (byte)EstadosAprobacion.Rechazada:
                            _ORegistro.Cells["Aprobar"].Value = false;
                            _ORegistro.Cells["Rechazar"].Value = true;
                            break;
                    }
                }

                //Coloreamos
                _Mtd_ColorearRegistros();

                _G_EditandoFila = false;
            }            
        }
        #endregion

        #region = - = - = - = - = - = - = - = - = - = - Esto es para ocultar los checboxes que no se deben mostrar  = - = - = - = - = - = - = - = - = - = -

        private string _Str_Ultimociddetalleconciliacion = "";
        private string _Str_CidconciliaciondmanualPrimeraFila = "";
        private void _Dtg_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //Inicializamos el Objeto del grid
            var _Dtg = (DataGridView)sender;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                (_Dtg.Columns[e.ColumnIndex].Name == "Aprobar" || _Dtg.Columns[e.ColumnIndex].Name == "Rechazar")
                )
            {
                var _Item = _Dtg.Rows[e.RowIndex].DataBoundItem;
                if (_Item != null)
                {
                    var _Registro = (DataRowView)_Item;
                    var _Str_ciddetalleconciliacion = _Registro["ciddetalleconciliacion"].ToString();
                    var _PrimerRegistro = _Dtg.Rows.Cast<DataGridViewRow>().AsEnumerable().FirstOrDefault(x => x.Cells["ciddetalleconciliacion"].Value.ToString() == _Str_ciddetalleconciliacion);
                    if (_PrimerRegistro != null)
                    {
                        var _Str_cidconciliaciondmanualPrimeraFila = _PrimerRegistro.Cells["cidconciliaciondmanual"].Value.ToString();
                        bool _Bool_Pintar;

                        //Si es la primera fila del grupo
                        if ((_Registro["ciddetalleconciliacion"].ToString() != _Str_Ultimociddetalleconciliacion) ||
                            (_Str_cidconciliaciondmanualPrimeraFila != _Str_CidconciliaciondmanualPrimeraFila))
                        {
                            _Str_Ultimociddetalleconciliacion = _Registro["ciddetalleconciliacion"].ToString();
                            _Str_CidconciliaciondmanualPrimeraFila = _Str_cidconciliaciondmanualPrimeraFila;
                        }

                        if ((_Registro["ciddetalleconciliacion"].ToString() == _Str_Ultimociddetalleconciliacion) &&
                            (_Registro["cidconciliaciondmanual"].ToString() == _Str_CidconciliaciondmanualPrimeraFila))
                            _Bool_Pintar = true;
                        else
                            _Bool_Pintar = false;
                        //En funcion a la bandera
                        if (!_Bool_Pintar)
                        {
                            //No Dibujo el checkbox
                            e.PaintBackground(e.ClipBounds, true);
                            e.Handled = true;
                            //Coloco la celda como solo lectura
                            _Dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;

                        }
                    }
                }
            }
        }

        #endregion

        #region = - = - = - = - = - = - = - = - = - = - Rutinas de Control de Tab = - = - = - = - = - = - = - = - = - = -

        /// <summary>
        /// Selecciona el Tab segun tipo de ajuste
        /// </summary>
        /// <param name="_P_Int_TipoAjuste"></param>
        private void _Mtd_SeleccionarTabSegunTipoAjuste(int _P_Int_TipoAjuste)
        {
            //Exceptuando los cruces que no generan reversos de libros
            switch (_P_Int_TipoAjuste)
            {
                case (byte)Tipoajuste.UnoAUnoDiferenciaNumero:
                case (byte)Tipoajuste.UnoAUnoDiferenciaMonto:
                    _Tabs_.SelectTab("_Tab_AjustesSimples");
                    break;
                case (byte)Tipoajuste.MultiplesAgrupamientoRegistros:
                case (byte)Tipoajuste.MultiplesAgrupamientoRegistrosConDiferenciaMonto:
                    _Tabs_.SelectTab("_Tab_AjustesMultiplesUnoBancoNLibro");
                    break;
                case (byte)Tipoajuste.MultiplesDivisionRegistros:
                case (byte)Tipoajuste.MultiplesDivisionRegistrosConDiferenciaMonto:
                    _Tabs_.SelectTab("_Tab_AjustesMultiplesUnoLibroNBanco");
                    break;
                case (byte)Tipoajuste.CruceMovimientosContables:
                    _Tabs_.SelectTab("_Tab_AjustesCruceMovimientosLibro");
                    break;
                case (byte)Tipoajuste.CruceMovimientosBanco:
                    _Tabs_.SelectTab("_Tab_AjustesRedepositos");
                    break;
                case (byte)Tipoajuste.ComisionesEIntereses:
                case (byte)Tipoajuste.ComisionesEIntereses_Reverso:
                    _Tabs_.SelectTab("_Tab_AjustesComisionesInteresesReversos");
                    break;
                case (byte)Tipoajuste.MuchosLibrosConMuchosBancos:
                case (byte)Tipoajuste.MuchosLibrosConMuchosBancosConDiferenciaMonto:
                    _Tabs_.SelectTab("_Tab_AjustesDepCheProvincialOtros");
                    break;
            }
        }

        private void _Tabs__Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_G_Bol_ModoGuardar)
                _G_Str_PestañaActual = "";
            //En funcion a la pestaña. muestro el boton correspondientes
            if (_Tabs_.SelectedTab.Name == "_Tab_ComprobanteContable")
            {
                if (_G_Str_PestañaActual != "")
                {
                    _Bt_Continuar.Visible = false;
                    _Bt_GuardarCambios.Visible = true;
                    _Bt_GuardarCambios.Enabled = _G_Bol_PermisoAprobacion;
                }
                else
                {
                    _G_Bol_ModoGuardar = false;
                    _G_Str_PestañaActual = "";
                    e.Cancel = true;
                }
            }
            else
            {
                _G_Bol_ModoGuardar = false;
                _G_Str_PestañaActual = "";
                _Bt_Continuar.Visible = true;
                _Bt_GuardarCambios.Visible = false;
            }
        }

        #endregion


        private void _Pic_Recargar_DoubleClick(object sender, EventArgs e)
        {
            _Mtd_ActualizarFormulario();
        }
    }
}