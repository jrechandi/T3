using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using T3.Clases;
using System.Diagnostics;
namespace T3
{
    public partial class Frm_CapturaDispBanco2 : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");

        //Variables Nuevas de Configuracion
        List<string> _Str_TipoDeArchivoPer = new List<string>();
        string[] _Str_Delimitador = new string[0];
        int _Int_LineaInicioDatos;
        int _Int_ColumnaFinalDatos;
        private byte _G_Byte_ctiposeparadordecimal;
        private byte _G_Byte_ccantidaddigitosdecimales;
        private bool _G_Bool_ObtenerMontoRegistroSegunColumnaSaldo;
        private bool _G_Bool_ObtenerTipoOperacionSegunColumnaConcepto;
        private bool _G_Bool_ObtenerTipoOperacionSegunSignoMonto;
        private bool _G_Bool_ObtenerTipoOperacionSegunElUsuario;
        private readonly bool _G_Bol_PermisoCreacion;
        private double _G_Dbl_SaldoFinalUsuario = 0;
        private bool _G_Bool_LimpiarRadioButtonsDeBusqueda;
        private double _G_Dbl_MontoBloqueado = 0;
        private double _G_Dbl_MontoDisponible = 0;
        private double _G_Dbl_MontoSaldoReal = 0;
        private int _G_Int_CaracteresATomarDelConcepto = 0;
        private int _G_Int_CantidadColumnasVaciasPermitidas = 0;
        private bool _G_EstamosSeteandoCombos;
        private Color _G_ColorInicialGrid;
        private bool _G_Bool_LimpiarRadioButtonsDeCaptura;

        //Variables Globales
        private DataSet _G_Ds_Registros;
        private string _G_Str_TipoArchivo;

        string _Str_FormatoFecha = "";

        public Frm_CapturaDispBanco2()
        {
            InitializeComponent();
            _G_Bol_PermisoCreacion = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CONC_NUEVO_ESTADOCUENTA");
            _Dtp_Desde.MaxDate = Convert.ToDateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().ToString("dd/MM/yyyy"));
            _Dtp_Desde.Value = Convert.ToDateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().ToString("dd/MM/yyyy"));
            _Dtp_Hasta.Value = Convert.ToDateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().ToString("dd/MM/yyyy"));
            
        }

        private string _Mtd_DescripColumnas(string _P_Str_NombreCampo)
        {
            switch (_P_Str_NombreCampo)
            {
                case "cposdatemovi":
                    return "Fecha";
                case "cposnumdocu":
                    return "Documento";
                case "cpostipoperacio":
                    return "T. Oper.";
                case "cposconcepto":
                    return "Concepto";
                case "cposmontomov":
                    return "Monto";
                case "cposmontomov1":
                    return "Monto 1";
                case "cpossaldomov":
                    return "Saldo";
                case "cposoficinabanc":
                    return "Ofic. Banco";
                default:
                    return "";
            }
        }
        private bool _Mtd_EsMonto(string _P_Str_NombreCampo)
        {
            switch (_P_Str_NombreCampo)
            {
                case "cposmontomov":
                    return true;
                case "cposmontomov1":
                    return true;
                case "cpossaldomov":
                    return true;
                default:
                    return false;
            }
        }
        private void _Mtd_IniGridDetalle(Dictionary<string, int>.KeyCollection _P_Keys)
        {
            _Dg_Grid.Rows.Clear();
            _Dg_Grid.Columns.Clear();
            DataGridViewTextBoxColumn _Col;
            _P_Keys.ToList().ForEach(_Key =>
            {
                _Col = new DataGridViewTextBoxColumn();
                _Col.Name = _Key;
                _Col.HeaderText = _Mtd_DescripColumnas(_Key);
                if (_Mtd_EsMonto(_Key))
                { _Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; }
                _Dg_Grid.Columns.Add(_Col);
            });
        }
        private bool _Mtd_EstanConfiguradasTiposDeOperacionBancariaParaCadaSigno(string _P_Str_cgroupcompany, string _P_Str_cbanco)
        {
            var _Str_Cadena = "SELECT * " +
                              "FROM [VST_CONCILIACION_TIPOSOPERACIONESPARACAPTURA] " +
                              "WHERE cgroupcomp='" + _P_Str_cgroupcompany + "' AND cbanco='" + _P_Str_cbanco + "' AND cantidadregistros >=2";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }
        private string _Mtd_ObtenerTipoOperacionBancariaSegunSigno(string _P_Str_cgroupcompany, string _P_Str_cbanco, bool _P_Bol_SignoNegativo)
        {
            var _Str_Resultado = "";
            var _Str_Cadena = "SELECT TOPERBANCD.coperbancd " +
                              "FROM TOPERBANCD INNER JOIN TOPERBANC ON TOPERBANCD.coperbanc = TOPERBANC.coperbanc " +
                              "WHERE (TOPERBANCD.cdelete = 0) AND (TOPERBANC.cdelete = 0)  " +
                              "AND cgroupcomp='" + _P_Str_cgroupcompany + "' AND cbanco='" + _P_Str_cbanco + "'";
            if (!_P_Bol_SignoNegativo)
            {
                _Str_Cadena += "AND (TOPERBANC.cdebe = 1) ";
            }
            else
            {
                _Str_Cadena += "AND (TOPERBANC.chaber = 1) ";
            }
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Resultado = _Ds.Tables[0].Rows[0][0].ToString();
            }
            return _Str_Resultado;
        }
        private void _Mtd_CargarGrid(string _P_Str_Banco, string _P_Str_TipoArchivo, DataSet _P_Ds_DataSet)
        {
            _Dg_Grid.SuspendLayout();
            _Dg_Grid.Rows.Clear();
            var _Str_ctipoconfiguracion = _Opt_TipoConciliacion_Captura.Checked ? "1" : "2";
            string _Str_Cadena = "SELECT ISNULL(cposdatemovi,0) AS cposdatemovi,ISNULL(cposnumdocu,0) AS cposnumdocu,ISNULL(cpostipoperacio,0) AS cpostipoperacio,ISNULL(cposconcepto,0) AS cposconcepto,ISNULL(cposmontomov,0) AS cposmontomov,ISNULL(cposmontomov1,0) AS cposmontomov1,ISNULL(cpossaldomov,0) AS cpossaldomov,ISNULL(cposoficinabanc,0) AS cposoficinabanc FROM TCONFCAPBANCD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _P_Str_Banco + "' AND cascciexcel='" + _P_Str_TipoArchivo + "' AND ctipoconfiguracion = '" + _Str_ctipoconfiguracion + "' ";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_PosicionMayor = _Ds.Tables[0].Rows[0].ItemArray.OrderByDescending(x => int.Parse(x.ToString())).First().ToString();
                int _Int_PosicionMayor = 0;
                int.TryParse(_Str_PosicionMayor, out _Int_PosicionMayor);
                if (_Int_PosicionMayor > _P_Ds_DataSet.Tables[0].Columns.Count)
                {
                    throw new Exception("El archivo contiene mas columnas que las configuradas.");
                }
                else
                {
                    _Dg_Grid.SuspendLayout();
                    _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                    var _Int_MesSeleccionado = _Cmb_Mes.SelectedValue == null? 0 : Convert.ToInt32(_Cmb_Mes.SelectedValue.ToString());
                    var _Int_AnoSeleccionado = _Cmb_Año.SelectedValue == null ? 0 : Convert.ToInt32(_Cmb_Año.SelectedValue.ToString());

                    //Posicion Concepto
                    Int32 _Int_PosicionConcepto = 0;
                    Int32.TryParse(_Ds.Tables[0].Rows[0]["cposconcepto"].ToString(), out _Int_PosicionConcepto);

                    //Posicion Monto
                    Int32 _Int_PosicionMonto = 0;
                    Int32.TryParse(_Ds.Tables[0].Rows[0]["cposmontomov"].ToString(), out _Int_PosicionMonto);

                    Dictionary<string, int> _Dic = new Dictionary<string, int>();
                    if (_G_Bool_ObtenerTipoOperacionSegunColumnaConcepto)
                    {
                        //Añado manualmente el campo de tipo de operacion 
                        _Ds.Tables[0].Columns.Cast<DataColumn>().Where(x => (Convert.ToInt32(_Ds.Tables[0].Rows[0][x]) > 0) | (x.ColumnName == "cpostipoperacio")).ToList().ForEach(x => _Dic.Add(x.ColumnName, Convert.ToInt32(_Ds.Tables[0].Rows[0][x])));
                    }
                    else if (_G_Bool_ObtenerTipoOperacionSegunSignoMonto)
                    {
                        //Añado manualmente el campo de tipo de operacion
                        _Ds.Tables[0].Columns.Cast<DataColumn>().Where(x => (Convert.ToInt32(_Ds.Tables[0].Rows[0][x]) > 0) | (x.ColumnName == "cpostipoperacio")).ToList().ForEach(x => _Dic.Add(x.ColumnName, Convert.ToInt32(_Ds.Tables[0].Rows[0][x])));
                    }
                    else if (_G_Bool_ObtenerTipoOperacionSegunElUsuario)
                    {
                        //Añado manualmente el campo de tipo de operacion
                        _Ds.Tables[0].Columns.Cast<DataColumn>().Where(x => (Convert.ToInt32(_Ds.Tables[0].Rows[0][x]) > 0) | (x.ColumnName == "cpostipoperacio")).ToList().ForEach(x => _Dic.Add(x.ColumnName, Convert.ToInt32(_Ds.Tables[0].Rows[0][x])));
                    }
                    else
                    {
                        //Normal
                        _Ds.Tables[0].Columns.Cast<DataColumn>().Where(x => Convert.ToInt32(_Ds.Tables[0].Rows[0][x]) > 0).ToList().ForEach(x => _Dic.Add(x.ColumnName, Convert.ToInt32(_Ds.Tables[0].Rows[0][x])));
                    }
                    _Mtd_IniGridDetalle(_Dic.Keys);
                    _Dg_Grid.SuspendLayout();

                    //Si es necesario que el usuario seleccione el tipo de operacion, debemos agregar el combo al grid
                    if (_G_Bool_ObtenerTipoOperacionSegunElUsuario)
                    {
                        //Cargamos la Columna  de Combo
                        DataGridViewComboBoxColumn oComboEstadoBanco = new DataGridViewComboBoxColumn();
                        oComboEstadoBanco.HeaderText = "Tipo Operación Bancaria";
                        oComboEstadoBanco.Name = "cmbTipoOperacionBancaria";
                        oComboEstadoBanco.Width = 300;
                        _Dg_Grid.Columns.Add(oComboEstadoBanco);

                        //Asigno las caracteristicas del combo
                        ((DataGridViewComboBoxColumn)_Dg_Grid.Columns["cmbTipoOperacionBancaria"]).AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        ((DataGridViewComboBoxColumn)_Dg_Grid.Columns["cmbTipoOperacionBancaria"]).DisplayMember = "Display";
                        ((DataGridViewComboBoxColumn)_Dg_Grid.Columns["cmbTipoOperacionBancaria"]).ValueMember = "Value";
                        ((DataGridViewComboBoxColumn)_Dg_Grid.Columns["cmbTipoOperacionBancaria"]).Width = 300;

                    }

                    _P_Ds_DataSet.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(_Row =>
                    {
                        //Añadimos al grid
                        _Dg_Grid.Rows.Add();
                        _Dic.ToList().ForEach(_Par =>
                        {
                            var _Str_DatoOriginal = _Par.Value == 0? "" : _Row[_Par.Value - 1].ToString().Replace("'", "");
                            string _Str_DatoConvertido;
                            switch (_Par.Key)
                            {
                                    //Si la Columna es de Numero de Documento (convertimos por si viene en notacion cientifica)
                                case "cposnumdocu":
                                    _Str_DatoConvertido = _Cls_RutinasInterfazBancaria._Mtd_FormatearNumeroDocumento(_Str_DatoOriginal);
                                    break;
                                    //Si la columna es Fecha (formateamos)
                                case "cposdatemovi":
                                    bool _Bool_ConversionCorrecta;
                                    _Str_DatoConvertido = _Cls_RutinasInterfazBancaria._Mtd_FormatearFecha(_Str_DatoOriginal, _Str_FormatoFecha, out _Bool_ConversionCorrecta, _Int_MesSeleccionado, _Int_AnoSeleccionado);
                                    break;
                                    //Si la Columnas es Monto (formateamos)
                                case "cposmontomov":
                                case "cposmontomov1":
                                    if (_G_Bool_ObtenerTipoOperacionSegunElUsuario)
                                        _Str_DatoConvertido = _Cls_RutinasInterfazBancaria._Mtd_FormatearMonto(_Str_DatoOriginal, _G_Byte_ctiposeparadordecimal, _G_Byte_ccantidaddigitosdecimales,true);
                                    else
                                        _Str_DatoConvertido = _Cls_RutinasInterfazBancaria._Mtd_FormatearMonto(_Str_DatoOriginal, _G_Byte_ctiposeparadordecimal, _G_Byte_ccantidaddigitosdecimales);
                                    break;
                                case "cpossaldomov":
                                    _Str_DatoConvertido = _Cls_RutinasInterfazBancaria._Mtd_FormatearMonto(_Str_DatoOriginal, _G_Byte_ctiposeparadordecimal, _G_Byte_ccantidaddigitosdecimales,true); 
                                    break;
                                case "cpostipoperacio":
                                    if (_G_Bool_ObtenerTipoOperacionSegunColumnaConcepto) //Si hay que optener el tipo de operacion desde el concepto
                                    {
                                        var _Str_Concepto = _Row[_Int_PosicionConcepto - 1].ToString();
                                        var _Str_Split = _Str_Concepto.Split(' ');
                                        var _Str_TipoOperacion = "";
                                        if (_Str_Split.Any()) 
                                            _Str_TipoOperacion = _Str_Split[0].Trim().ToUpper();
                                        _Str_DatoConvertido = _Str_TipoOperacion;
                                    }
                                    else if (_G_Bool_ObtenerTipoOperacionSegunSignoMonto) //Si hay que optener el tipo de operacion desde el signo del monto
                                    {
                                        var _Str_Monto = _Row[_Int_PosicionMonto - 1].ToString();
                                        var _Bool_SignoNegativo = _Str_Monto.IndexOf('-') >= 0;
                                        //Obtenemos el tipo de operacion bancaria que le debe corresponder
                                        var _Str_TipoOperacionCorrespondiente = _Mtd_ObtenerTipoOperacionBancariaSegunSigno(Frm_Padre._Str_GroupComp, _P_Str_Banco, _Bool_SignoNegativo);
                                        _Str_DatoConvertido = _Str_TipoOperacionCorrespondiente;
                                    }
                                    else if (_G_Bool_ObtenerTipoOperacionSegunElUsuario) //Si hay que optener el tipo de operacion segun los historiales (idea de carlos longa)
                                    {
                                        //Si la cantidad de caracteres es cero, no hace la busqueda loca
                                        if (_G_Int_CaracteresATomarDelConcepto == 0)
                                        {
                                            _Str_DatoConvertido = "";
                                        }
                                        else
                                        {
                                            //Obtenemos el concepto
                                            var _Str_Concepto = _Row[_Int_PosicionConcepto - 1].ToString();
                                            //Limpiamos las comillas 
                                            _Str_Concepto = _Str_Concepto.Replace("'", "");
                                            //Verificamos la cantidad de caracteres a tomar no puede ser mayor al largo de la cadena
                                            var _Int_CaracteresATomarDelConcepto = _G_Int_CaracteresATomarDelConcepto > _Str_Concepto.Length ? _Str_Concepto.Length : _G_Int_CaracteresATomarDelConcepto;
                                            //Tomamos los primero ciertos caracteres del concepto
                                            var _Str_ConceptoLimpio = _Str_Concepto.Substring(0, _Int_CaracteresATomarDelConcepto);
                                            //Buscamos en la tabla de registros
                                            var _Str_ctipooperacion = _Mtd_BuscarTipoOperacionSegunConcepto(_Str_ConceptoLimpio);
                                            //Devuelvo
                                            _Str_DatoConvertido = _Str_ctipooperacion;
                                        }
                                    }
                                    else
                                    {
                                        //Caso Normal
                                        _Str_DatoConvertido = _Str_DatoOriginal;
                                    }
                                    break;
                                case "cposconcepto":
                                    //Si hay que optener el tipo de operacion desde el concepto (LIMPIENZA DEL CONCEPTO)
                                    if (_G_Bool_ObtenerTipoOperacionSegunColumnaConcepto)
                                    {
                                        var _Str_Concepto = _Row[_Int_PosicionConcepto - 1].ToString();
                                        var _Str_Split = _Str_Concepto.Split(' ');
                                        var _Str_TipoOperacion = "";
                                        if (_Str_Split.Any())
                                            _Str_TipoOperacion = _Str_Split[0];
                                        _Str_DatoConvertido = _Str_Concepto.Substring(_Str_TipoOperacion.Length).Trim();
                                    }
                                    else
                                    {
                                        //Caso Normal
                                        //Limpiamos las comillas 
                                        _Str_DatoOriginal = _Str_DatoOriginal.Replace("'", "");
                                        _Str_DatoConvertido = _Str_DatoOriginal;
                                    }
                                    break;
                                default:
                                    _Str_DatoConvertido = _Str_DatoOriginal;
                                    break;
                            }
                            _Dg_Grid.Rows[_Dg_Grid.RowCount - 1].Cells[_Par.Key].Value = _Str_DatoConvertido;
                        });
                    });

                    //Cargamos los los combos segun el valor del monto y setamos su valor segun el tipo de operacion que consiguio el sistema
                    if (_G_Bool_ObtenerTipoOperacionSegunElUsuario)
                    {
                        _G_EstamosSeteandoCombos = true;
                        _Dg_Grid.Rows.Cast<DataGridViewRow>().ToList().ForEach(_Row =>
                        {
                            //Obtengo el valor del Monto de la fila seleccionada
                            var _Str_Monto = _Row.Cells["cposmontomov"].Value.ToString();
                            var _Str_ctipooperacion = _Row.Cells["cpostipoperacio"].Value.ToString();

                            //Obtenemos el signo del monto
                            var _Bool_SignoPositivo = _Str_Monto.IndexOf("-") < 0;

                            //Obtenemos el combo
                            var _CeldaCombo = (DataGridViewComboBoxCell)_Row.Cells["cmbTipoOperacionBancaria"];

                            //Cargamos los valores del combo para la compañia banco seleccionado
                            _Mtd_CargarComboTipoOperacion(_CeldaCombo, _Bool_SignoPositivo);

                            //Seteamos el valor
                            if (_Str_ctipooperacion.Trim() != "") _CeldaCombo.Value = _Str_ctipooperacion;

                        });
                        _G_EstamosSeteandoCombos = false;
                    }

                    //Aqui actualizamos las columnas que tengan valores que deban actualizase
                    var _Dc_SaldoInicial = _Cls_RutinasConciliacion._Mtd_ObtenerSaldoInicialBanco(_Cmb_BancoD.SelectedValue.ToString(), _Cmb_CuentaD.SelectedValue.ToString());
                    var _Dc_SaldoAnterior = _Dc_SaldoInicial;
                    var _Dc_SaldoActual = new decimal(0);
                    //Solo si hay que calcular
                    if (_G_Bool_ObtenerMontoRegistroSegunColumnaSaldo)
                    {
                        //Declaramos
                        var _Str_cposmontomov = "";
                        var _Str_cposmontomov1 = "";
                        var _Str_cpossaldomov = "";

                        //Asignamos los indices
                        if (_Dic.ContainsKey("cposmontomov")) _Str_cposmontomov = "cposmontomov";
                        if (_Dic.ContainsKey("cposmontomov1")) _Str_cposmontomov1 = "cposmontomov1";
                        if (_Dic.ContainsKey("cpossaldomov")) _Str_cpossaldomov = "cpossaldomov";


                        _Dg_Grid.Rows.Cast<DataGridViewRow>().ToList().ForEach(_RowGrid =>
                            {
                                //Obtenemos los valores si es el caso
                                var _Dc_MontoMovimiento = new decimal(0);
                                var _Dc_MontoMovimiento1 = new decimal(0);
                                var _Dc_MontoSaldo = new decimal(0);

                                if (_Str_cposmontomov != "") decimal.TryParse(_RowGrid.Cells[_Str_cposmontomov].Value.ToString(), out _Dc_MontoMovimiento);
                                if (_Str_cposmontomov1 != "") decimal.TryParse(_RowGrid.Cells[_Str_cposmontomov1].Value.ToString(), out _Dc_MontoMovimiento1);
                                if (_Str_cpossaldomov != "") decimal.TryParse(_RowGrid.Cells[_Str_cpossaldomov].Value.ToString(), out _Dc_MontoSaldo);

                                //Redondeamos
                                _Dc_MontoMovimiento = Math.Round(_Dc_MontoMovimiento, 2);
                                _Dc_MontoMovimiento1 = Math.Round(_Dc_MontoMovimiento1, 2);
                                _Dc_MontoSaldo = Math.Round(_Dc_MontoSaldo, 2);

                                //Calculamos
                                var _Dc_MontoConsigno = _Dc_MontoMovimiento + _Dc_MontoMovimiento1;
                                _Dc_MontoConsigno = Math.Round(_Dc_MontoConsigno, 2);

                                _Dc_SaldoActual = _Dc_MontoSaldo;
                                var _Dc_DiferenciaSegunSaldo = _Dc_SaldoActual - _Dc_SaldoAnterior;
                                _Dc_DiferenciaSegunSaldo = Math.Round(_Dc_DiferenciaSegunSaldo, 2);

                                var _Dc_Diferencia = Math.Abs(_Dc_MontoConsigno) - Math.Abs(_Dc_DiferenciaSegunSaldo);
                                _Dc_Diferencia = Math.Round(_Dc_Diferencia, 2);

                                //Verificamos
                                if (_Dc_Diferencia != 0)
                                {
                                    //Asignamos segun donde haya valor
                                    if (_Dc_MontoMovimiento != 0)
                                    {
                                        _RowGrid.Cells[_Str_cposmontomov].Value = _Dc_DiferenciaSegunSaldo.ToString("#,##0.00");
                                    }
                                    if (_Dc_MontoMovimiento1 != 0)
                                    {
                                        _RowGrid.Cells[_Str_cposmontomov1].Value = _Dc_DiferenciaSegunSaldo.ToString("#,##0.00");
                                    }
                                }

                                //Actualizamos el saldo anterior
                                _Dc_SaldoAnterior = _Dc_SaldoActual;

                            });
                    }

                    _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    _Dg_Grid.ResumeLayout();
                }
            }
            else
            {
                _Dg_Grid.ResumeLayout();
                throw new Exception("Debe configurar las columnas del archivo para realizar esta operación.");
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
        private void _Mtd_CargarBanco(ComboBox _P_Cmb_Combo, bool _P_Bol_Consulta)
        {
            this.Cursor = Cursors.WaitCursor;

            var _Str_TablaMaestra = "";
            var _Str_TablaDetalle = "";
            var _Str_ctipoconfiguracion = "";

            _Mtd_ObtenerNombresTablas(out _Str_TablaMaestra, out _Str_TablaDetalle, _P_Bol_Consulta);

            if (_P_Bol_Consulta)
            {
                _Str_ctipoconfiguracion = _Opt_TipoConciliacion_Busqueda.Checked ? "1" : "2";
            }
            else
            {
                _Str_ctipoconfiguracion = _Opt_TipoConciliacion_Captura.Checked ? "1" : "2";
            }

            string _Str_Cadena = "SELECT LTRIM(RTRIM(TBANCO.cbanco)),TBANCO.cname FROM TBANCO INNER JOIN TCONFCAPBANCD ON TBANCO.ccompany=TCONFCAPBANCD.ccompany AND LTRIM(RTRIM(TBANCO.cbanco))=LTRIM(RTRIM(TCONFCAPBANCD.cbanco)) AND ISNULL(TBANCO.cdelete,0)=ISNULL(TCONFCAPBANCD.cdelete,0) WHERE TBANCO.ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(TBANCO.cdelete,0)=0 AND ctipoconfiguracion = '" + _Str_ctipoconfiguracion + "'";
            //-----------
            if (_P_Bol_Consulta)
            { _Str_Cadena += " AND EXISTS(SELECT cbanco FROM " + _Str_TablaMaestra + " WHERE " + _Str_TablaMaestra + ".ccompany=TBANCO.ccompany AND LTRIM(RTRIM(" + _Str_TablaMaestra + ".cbanco))=LTRIM(RTRIM(TBANCO.cbanco)) AND ISNULL(" + _Str_TablaMaestra + ".cdelete,0)=0)"; }
            //-----------
            _Str_Cadena += " ORDER BY REPLACE(TBANCO.cname,'BANCO','')";
            _Cls_VariosMetodos._Mtd_CargarCombo(_P_Cmb_Combo, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_CargarCuentas(ComboBox _P_Cmb_Combo, string _P_Str_Banco)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT cnumcuenta,cname FROM TCUENTBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cbanco='" + _P_Str_Banco + "' and ISNULL(cdelete,0)=0";
            _Cls_VariosMetodos._Mtd_CargarCombo(_P_Cmb_Combo, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_CargarTipoArchivo(ComboBox _P_Cmb_Combo)
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _P_Cmb_Combo.DataSource = null;

            //Cargo los Archivos Para el Banco Seleccionado
           var _Dt = _Mtd_CargarConfiguracion(Frm_Padre._Str_Comp, Convert.ToString(_Cmb_BancoD.SelectedValue).Trim());
           //Verifico si obtuve datos
           if (_Dt != null)
            {
                if (_Dt.Rows.Count > 0)
                {
                    _Str_TipoDeArchivoPer = new List<string>();
                    foreach (DataRow _DRow in _Dt.Rows)
                    {
                        _Str_TipoDeArchivoPer.Add(_DRow["cascciexcel"].ToString());
                    }
                }
            }

            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            foreach (string _Str_TipoArchivo in _Str_TipoDeArchivoPer)
            {
                switch (_Str_TipoArchivo)
                {
                    case "A":
                        _myArrayList.Add(new T3.Clases._Cls_ArrayList("ASCII", "A"));
                        break;
                    case "C":
                        _myArrayList.Add(new T3.Clases._Cls_ArrayList("CSV", "C"));
                        break;
                    case "E":
                        _myArrayList.Add(new T3.Clases._Cls_ArrayList("EXCEL", "E"));
                        break;
                }
            }
            _P_Cmb_Combo.DataSource = _myArrayList;
            _P_Cmb_Combo.DisplayMember = "Display";
            _P_Cmb_Combo.ValueMember = "Value";
            _P_Cmb_Combo.SelectedValue = "nulo";
            _P_Cmb_Combo.DataSource = _myArrayList;
            _P_Cmb_Combo.SelectedIndex = 0;
        }
        private void _Mtd_CargarComboMeses()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_Mes.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "0"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Enero", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Febrero", "2"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Marzo", "3"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Abril", "4"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Mayo", "5"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Junio", "6"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Julio", "7"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Agosto", "8"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Septiembre", "9"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Octubre", "10"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Noviembre", "11"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Diciembre", "12"));
            _Cmb_Mes.DataSource = _myArrayList;
            _Cmb_Mes.DisplayMember = "Display";
            _Cmb_Mes.ValueMember = "Value";
            _Cmb_Mes.SelectedValue = "nulo";
            _Cmb_Mes.DataSource = _myArrayList;
            _Cmb_Mes.SelectedIndex = 0;
        }

        private void _Mtd_CargarComboAños()
        {
            int _Int_AñoDesde = DateTime.Now.Year - 5;
            int _Int_AñoHasta = DateTime.Now.Year + 5;

            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_Año.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "0"));

            for (int _Int_Año = _Int_AñoDesde; _Int_Año <= _Int_AñoHasta; _Int_Año++)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_Int_Año.ToString(), _Int_Año.ToString()));
            }

            _Cmb_Año.DataSource = _myArrayList;
            _Cmb_Año.DisplayMember = "Display";
            _Cmb_Año.ValueMember = "Value";
            _Cmb_Año.SelectedValue = "nulo";
            _Cmb_Año.DataSource = _myArrayList;
            _Cmb_Año.SelectedIndex = 0;
        }
        private void _Mtd_ActualizarCapturas()
        {
            Cursor = Cursors.WaitCursor;
            var _Str_Vista = _Opt_TipoConciliacion_Busqueda.Checked ? "VST_TDISPBANC" : "VST_TEDOCUENTADISPM";
            string _Str_Cadena = "SELECT cdispbanc,cbanconame AS Banco,cnumcuentaname AS Cuenta,CONVERT(VARCHAR,cfechacaptura,103) AS Fecha,cnombrearchivo AS Archivo,dbo.Fnc_Formatear(csaldobanco) AS csaldobanco, CASE cregistroinicial WHEN 1 THEN 'SI' ELSE 'NO' END AS [Registro Inicial], cbanco, cnumcuenta FROM " + _Str_Vista + " WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ISNULL(cdelete,0)=0";
            if (_Cmb_Banco.SelectedIndex > 0)
            {
                _Str_Cadena += " AND cbanco='" + Convert.ToString(_Cmb_Banco.SelectedValue).Trim() + "'";
            }
            if (_Cmb_Cuenta.SelectedIndex > 0)
            {
                _Str_Cadena += " AND cnumcuenta='" + Convert.ToString(_Cmb_Cuenta.SelectedValue).Trim() + "'";
            }
            if (!_Chk_Todas.Checked)
            {
                _Str_Cadena += " AND CONVERT(DATETIME,CONVERT(VARCHAR,cfechacaptura,103)) BETWEEN '" + _Cls_Formato._Mtd_fecha(_Dtp_Desde.Value) + "' AND '" + _Cls_Formato._Mtd_fecha(_Dtp_Hasta.Value) + "'";
            }
            _Str_Cadena += " ORDER BY cfechacaptura DESC";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Capturas.DataSource = _Ds.Tables[0];
            _Dg_Capturas.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Capturas.Columns["cdispbanc"].Visible = false;
            _Dg_Capturas.Columns["csaldobanco"].Visible = false;
            _Dg_Capturas.Columns["cbanco"].Visible = false;
            _Dg_Capturas.Columns["cnumcuenta"].Visible = false;
            _Dg_Capturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
        }
        string _Str_Disp = "";

        private void _Mtd_ActualizarDetalleDispon(string _P_Str_Disp, string _P_Str_Saldo)
        {
            Cursor = Cursors.WaitCursor;

            var _Str_TablaMaestra = "";
            var _Str_TablaDetalle = "";
            _Mtd_ObtenerNombresTablas(out _Str_TablaMaestra, out _Str_TablaDetalle, true);

            //Consulto lo saldos
            var _Str_Cadena = "";
            if (_Opt_TipoConciliacion_Busqueda.Checked)
            {
                _Str_Cadena = "SELECT csaldobancoinicial, csaldobanco  FROM " + _Str_TablaMaestra + " WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdispbanc='" + _P_Str_Disp + "'";
            }
            else if (_Opt_TipoDisponibilidad_Busqueda.Checked)
            {
                _Str_Cadena = "SELECT csaldobancoinicial, csaldobanco, cmontodiferido, cmontodisponible FROM " + _Str_TablaMaestra + " WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdispbanc='" + _P_Str_Disp + "'";
            }
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            var _Dbl_SaldoInicialBancoConsulta = Convert.ToDouble(_Ds.Tables[0].Rows[0]["csaldobancoinicial"]);
            var _Dbl_SaldoFinalBancoConsulta = Convert.ToDouble(_Ds.Tables[0].Rows[0]["csaldobanco"]);

            double _Dbl_MontoBloqueadoFinalConsulta = 0;
            double _Dbl_MontoDisponibleFinalConsulta = 0;

            if (_Opt_TipoDisponibilidad_Busqueda.Checked) 
            {
                _Dbl_MontoBloqueadoFinalConsulta = _Ds.Tables[0].Rows[0]["cmontodiferido"].ToString() == "" ? 0 : Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontodiferido"]);
                _Dbl_MontoDisponibleFinalConsulta = _Ds.Tables[0].Rows[0]["cmontodisponible"].ToString() == "" ? 0 : Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontodisponible"]);
            }

            var _Dbl_MontoSaldoRealFinalConsulta = _Dbl_SaldoFinalBancoConsulta + _Dbl_MontoBloqueadoFinalConsulta;

            _Txt_SaldoInicialBancoConsulta.Text = _Dbl_SaldoInicialBancoConsulta.ToString("#,##0.00");
            _Txt_SaldoFinalBancoConsulta.Text = _Dbl_SaldoFinalBancoConsulta.ToString("#,##0.00");
            _Txt_MontoBloqueadoFinalConsulta.Text = _Dbl_MontoBloqueadoFinalConsulta.ToString("#,##0.00");
            _Txt_MontoDisponibleFinalConsulta.Text = _Dbl_MontoDisponibleFinalConsulta.ToString("#,##0.00");
            _Txt_MontoSaldoRealFinalConsulta.Text = _Dbl_MontoSaldoRealFinalConsulta.ToString("#,##0.00");

            //Consulto el detalle
            _Str_Cadena = "SELECT CONVERT(VARCHAR,cdatemovi,103) AS Fecha,cnumdocu AS Documento,ctipoperacio AS [T. Oper.],cconcepto AS Concepto,dbo.Fnc_Formatear(cmontomov) AS Monto,dbo.Fnc_Formatear(csaldomov) AS Saldo,coficinabanc AS [Ofic. Banco],CASE cconciliado WHEN 1 THEN 'SI' ELSE 'NO' END AS Conciliado FROM " + _Str_TablaDetalle + " WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdispbanc='" + _P_Str_Disp + "'";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Dg_Detalle.DataSource = _Ds.Tables[0];
            _Dg_Detalle.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _Dg_Detalle.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns["Saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cursor = Cursors.Default;
            //_Txt_Saldo.Text = _P_Str_Saldo;
            _Bt_Visualizar.Enabled = _Dg_Detalle.RowCount > 0;
            _Str_Disp = _P_Str_Disp;
        }
        private void _Mtd_Limpiar()
        {
            _Mtd_CargarBanco(_Cmb_Banco, true);
            _Dtp_Desde.MaxDate = Convert.ToDateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().ToString("dd/MM/yyyy"));
            _Dtp_Desde.Value = Convert.ToDateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().ToString("dd/MM/yyyy"));
            _Dtp_Hasta.Value = Convert.ToDateTime(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().ToString("dd/MM/yyyy"));
            _Dg_Capturas.DataSource = null;
            _Dg_Detalle.DataSource = null;
            _Bt_Visualizar.Enabled = false;
            //_Txt_Saldo.Text = "";
            _Str_Disp = "";
            _Chk_Todas.Checked = true;
            _Cmb_Banco.Focus();
            _Txt_SaldoInicialBanco.Text = "";
            _Txt_SaldoFinalBanco.Text = "";
            _Txt_SaldoInicialBancoConsulta.Text = "";
            _Txt_SaldoFinalBancoConsulta.Text = "";
            _Txt_MontoBloqueadoFinalConsulta.Text = "";
            _Txt_MontoDisponibleFinalConsulta.Text = "";
            _Txt_MontoSaldoRealFinalConsulta.Text = "";
            _Txt_MontoBloqueadoFinalCaptura.Text = "";
            _Txt_MontoDisponibleFinalCaptura.Text = "";
            _Txt_MontoSaldoRealFinalCaptura.Text = "";
            _Opt_TipoConciliacion_Busqueda.Checked = false;
            _Opt_TipoDisponibilidad_Busqueda.Checked = false;
        }

        private void _Mtd_Limpiar_Tipo_Captura()
        {
            if (_Cmb_BancoD.SelectedIndex > 0) { _Cmb_BancoD.SelectedIndex = 0; }
            _Cmb_BancoD.Enabled = true;
            if (_Cmb_CuentaD.SelectedIndex > 0){_Cmb_CuentaD.SelectedIndex = 0;}
            _Cmb_CuentaD.Enabled = false;
            if (_Cmb_Mes.SelectedIndex > 0) { _Cmb_Mes.SelectedIndex = 0; }
            _Cmb_Mes.Enabled = false;
            if (_Cmb_Año.SelectedIndex > 0) { _Cmb_Año.SelectedIndex = 0; }
            _Cmb_Año.Enabled = false;
            if (_Chk_RegistrosIniciales.Checked) { _Chk_RegistrosIniciales.Checked = false; }
            _Chk_RegistrosIniciales.Enabled = false;
            if (_Chk_SoloSaldos.Checked) { _Chk_SoloSaldos.Checked = false; }
            _Chk_SoloSaldos.Enabled = false;
            if (_Cmb_TipArchivo.SelectedIndex > 0) { _Cmb_TipArchivo.SelectedIndex = 0; }
            _Cmb_TipArchivo.Enabled = false;
            _Bt_Abrir.Enabled = false;
            _Dg_Grid.Rows.Clear();
            _Dg_Grid.Columns.Clear();
            _Dg_Grid.DataSource = null;
            _Dg_Grid.Refresh();
            _Txt_SaldoInicialBanco.Text = "";
            _Txt_SaldoFinalBanco.Text = "";
            _Txt_MontoBloqueadoFinalCaptura.Text = "";
            _Txt_MontoDisponibleFinalCaptura.Text = "";
            _Txt_MontoSaldoRealFinalCaptura.Text = "";
            _Cmb_BancoD.Focus();
        }

        private void _Mtd_ObtenerNombresTablas(out string _P_Str_TablaMaestra, out string _P_Str_TablaDetalle, bool _P_Bol_Busqueda)
        {
            var _Str_TablaMaestra = "";
            var _Str_TablaDetalle = "";
            var _Bol_Conciliacion    = false;

            _Bol_Conciliacion = _P_Bol_Busqueda ? _Opt_TipoConciliacion_Busqueda.Checked : _Opt_TipoConciliacion_Captura.Checked;

            if (_Bol_Conciliacion)
            {
                _Str_TablaMaestra = "TDISPBANC";
                _Str_TablaDetalle = "TDISPBAND";
            }
            else
            {
                _Str_TablaMaestra = "TEDOCUENTADISPM";
                _Str_TablaDetalle = "TEDOCUENTADISPD";
            }
            _P_Str_TablaMaestra = _Str_TablaMaestra;
            _P_Str_TablaDetalle = _Str_TablaDetalle;
        }

        private void _Mtd_EliminarDisp(string _P_Str_ccompany, string _P_Str_cbanco, string _P_Str_cnumcuenta, string _P_Str_cdispbanc)
        {
            var _Str_TablaMaestra = "";
            var _Str_TablaDetalle = "";
            _Mtd_ObtenerNombresTablas(out _Str_TablaMaestra, out _Str_TablaDetalle,true);

            var _Str_Cadena = "";
            if (_Opt_TipoConciliacion_Busqueda.Checked)
            {
                //Si existe alguna conciliación sin finalizar (no se permite eliminar ya que se utilizaron los registros)
                _Str_Cadena = "select * from TCONCILIACION where ccompany = '" + _P_Str_ccompany + "' AND cbanco = '" + _P_Str_cbanco + "' AND cnumcuenta = '" + _P_Str_cnumcuenta + "' AND cdispbanc='" + _P_Str_cdispbanc + "' AND cfinalizado = '0'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("No se puede eliminar la captura porque tienes datos conciliados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Si hay datos conciliados
                _Str_Cadena = "SELECT cdispbanc FROM " + _Str_TablaMaestra  + " WHERE ccompany='" + _P_Str_ccompany + "' AND cdispbanc='" + _P_Str_cdispbanc + "' AND cconciliado='1'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("No se puede eliminar la captura porque tienes datos conciliados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                //Si existe alguna conciliación sin finalizar (no se permite eliminar ya que se utilizaron los registros)
                _Str_Cadena = "select * from TDISPONIBILIDAD where ccompany = '" + _P_Str_ccompany + "' AND cbanco = '" + _P_Str_cbanco + "' AND cnumcuenta = '" + _P_Str_cnumcuenta + "' AND cdispbanc='" + _P_Str_cdispbanc + "' AND cfinalizado = '0'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("No se puede eliminar la captura porque tienes datos que pueden estar utilizados en una disponibilidad", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Si hay datos conciliados
                _Str_Cadena = "SELECT cdispbanc FROM " + _Str_TablaMaestra + " WHERE ccompany='" + _P_Str_ccompany + "' AND cdispbanc='" + _P_Str_cdispbanc + "' AND cconciliado='1'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("No se puede eliminar la captura porque tienes datos utilizados en una disponibilidad", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            //Si vamos bien
            if (MessageBox.Show("¿Esta seguro de eliminar la captura?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _Str_Cadena = "UPDATE " + _Str_TablaMaestra + " SET cdelete=1,cdatedel=GETDATE(),cuserdel='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + _P_Str_ccompany + "' AND cdispbanc='" + _P_Str_cdispbanc + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                _Mtd_Limpiar();
                MessageBox.Show("La captura ha sido eliminada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Abre el archivo mediante shell
        /// </summary>
        /// <param name="_P_Str_RutaArchivo"></param>
        public static void AbrirArchivoPorShell(string _P_Str_RutaArchivo)
        {
            Process _Prc_Proceso = new Process();
            _Prc_Proceso.StartInfo.UseShellExecute = true;
            _Prc_Proceso.StartInfo.FileName = _P_Str_RutaArchivo;
            _Prc_Proceso.Start();
        }
        Microsoft.Office.Interop.Excel.Application _ExcelAppFind;

        private void _Mtd_VisualizarArchivo(string _P_Str_Disp)
        {
            Cursor = Cursors.WaitCursor;

            var _Str_TablaMaestra = "";
            var _Str_TablaDetalle = "";
            _Mtd_ObtenerNombresTablas(out _Str_TablaMaestra, out _Str_TablaDetalle,true);

            string _Str_Sql = "SELECT carchivo,cnombrearchivo FROM " + _Str_TablaMaestra + " WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cdispbanc='" + _P_Str_Disp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                //Genero el Ruta Completa del archivo
                string _Str_Path = System.Windows.Forms.Application.StartupPath + "\\" + Convert.ToString(_Ds.Tables[0].Rows[0]["cnombrearchivo"]);
                //En funcion al tipo del archivo
                if (_Cls_RutinasInterfazBancaria._Mtd_EsAscii(_Str_Path))
                {
                    _Cls_VariosMetodos._Mtd_ConvertByteToFile((byte[])_Ds.Tables[0].Rows[0]["carchivo"], _Str_Path);
                    if (System.IO.File.Exists(_Str_Path))
                    {
                        AbrirArchivoPorShell(_Str_Path);
                    }
                }
                else if (_Cls_RutinasInterfazBancaria._Mtd_EsCsv(_Str_Path))
                {
                    _Cls_VariosMetodos._Mtd_ConvertByteToFile((byte[])_Ds.Tables[0].Rows[0]["carchivo"], _Str_Path);
                    if (System.IO.File.Exists(_Str_Path))
                    {
                        AbrirArchivoPorShell(_Str_Path);
                    }
                }
                else if (_Cls_RutinasInterfazBancaria._Mtd_EsExcel(_Str_Path))
                {
                    if (_ExcelAppFind != null)
                    { _ExcelAppFind.Workbooks.Close(); }
                    _Cls_VariosMetodos._Mtd_ConvertByteToFile((byte[])_Ds.Tables[0].Rows[0]["carchivo"], _Str_Path);
                    if (System.IO.File.Exists(_Str_Path))
                    {
                        System.IO.File.SetAttributes(_Str_Path, System.IO.FileAttributes.ReadOnly);
                        if (_ExcelAppFind == null)
                        { _ExcelAppFind = new Microsoft.Office.Interop.Excel.Application(); }
                        if (_ExcelAppFind.Workbooks.Count != 0)
                        { _ExcelAppFind.Workbooks.Close(); }
                        if (_ExcelAppFind.Workbooks.Count == 0)
                        {
                            _ExcelAppFind.Workbooks.Open(_Str_Path, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                        }
                        _ExcelAppFind.Visible = true;
                    }
                }
            }
            Cursor = Cursors.Default;
        }
        private void _Mtd_Ini()
        {
            _G_Ds_Registros = null;
            _G_Str_TipoArchivo = "";
            _Mtd_CargarBanco(_Cmb_BancoD, false);
            _Mtd_CargarTipoArchivo(_Cmb_TipArchivo);
            _Mtd_CargarComboMeses();
            _Mtd_CargarComboAños();
            _Lbl_Fecha.Text = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ().ToShortDateString();
            _Er_Error.Dispose();
            if (_G_Bool_LimpiarRadioButtonsDeBusqueda)
            {
                _Opt_TipoConciliacion_Busqueda.Checked = false;
                _Opt_TipoDisponibilidad_Busqueda.Checked = false;
            }
            if (_G_Bool_LimpiarRadioButtonsDeCaptura)
            {
                _Opt_TipoConciliacion_Captura.Checked = false;
                _Opt_TipoDisponibilidad_Captura.Checked = false;
                _G_Bool_LimpiarRadioButtonsDeCaptura = false;
            }
        }
        public void _Mtd_Nuevo()
        {
            _G_Bool_LimpiarRadioButtonsDeBusqueda = false;
            _G_Bool_LimpiarRadioButtonsDeCaptura = true;
            _Chk_RegistrosIniciales.Checked = false;
            _Chk_RegistrosIniciales.Enabled = false;
            _Chk_SoloSaldos.Checked = false;
            _Chk_SoloSaldos.Enabled = false;
            _Pnl_SuperiorD.Enabled = true;
            _Mtd_Ini();
            _Tb_Tab.SelectedIndex = 1;
            _Cmb_BancoD.Enabled = false;
            //_Cmb_BancoD.Focus();
        }
        private bool _Mtd_TodasLasOperacionesRegistradas(string _P_Str_Banco, out bool _P_Bol_Return)
        {
            int _Int_CantidadDeFilasConError = 0;
            _Dg_Grid.Rows.Cast<DataGridViewRow>().ToList().ForEach(x =>
            {
                x.Cells["cpostipoperacio"].Style.BackColor = Color.White;
            });
            //Variables
            string _Str_Cadena;
            DataSet _Ds_TiposDeCuentaValidos = new DataSet("DatasetValidos");

            //Cargamos los Tipos de Cuentas Permitidas
            _Str_Cadena = "SELECT coperbancd FROM TOPERBANCD INNER JOIN TOPERBANC ON TOPERBANCD.coperbanc = TOPERBANC.coperbanc AND ISNULL(TOPERBANCD.cdelete, 0) = ISNULL(TOPERBANC.cdelete, 0) WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cbanco='" + _P_Str_Banco + "' AND ISNULL(TOPERBANCD.cdelete,0)=0";
            DataSet _Ds_DataSetsPermitidos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //Cargamos los Tipos de Cuenta (Excepciones)
            //_Str_Cadena = "SELECT coperbancd FROM TOPERBANCDEXCEP INNER JOIN TOPERBANC ON TOPERBANCDEXCEP.coperbanc = TOPERBANC.coperbanc AND ISNULL(TOPERBANCDEXCEP.cdelete, 0) = ISNULL(TOPERBANC.cdelete, 0) WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cbanco='" + _P_Str_Banco + "' AND ISNULL(TOPERBANCDEXCEP.cdelete,0)=0";
            _Str_Cadena = "SELECT coperbancd FROM TOPERBANCDEXCEP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cbanco='" + _P_Str_Banco + "' AND ISNULL(TOPERBANCDEXCEP.cdelete,0)=0";
            DataSet _Ds_DataSetsExcepciones = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //Unimos los Dataset
            _Ds_TiposDeCuentaValidos.Merge(_Ds_DataSetsPermitidos);
            _Ds_TiposDeCuentaValidos.Merge(_Ds_DataSetsExcepciones);

            //Obtenemos las Filas las cuales no estan dentro de los tipos de cuenta permitidos y excepciones
            var _Var_Datos = _Dg_Grid.Rows.Cast<DataGridViewRow>().Where(x => !_Ds_TiposDeCuentaValidos.Tables[0].Rows.Cast<DataRow>().Select(z => z["coperbancd"].ToString()).Contains(Convert.ToString(x.Cells["cpostipoperacio"].Value).Trim())).ToList();
            _Var_Datos.ForEach(x =>
            {
                x.Cells["cpostipoperacio"].Style.BackColor = Color.Yellow;
            });
            _P_Bol_Return = !(_Var_Datos.Count() > 0);
            return _P_Bol_Return;
        }

        private bool _Mtd_TodosLosMontosCorrectos(out bool _P_Bol_Return)
        {
            bool _Bol_Return = true;
            bool _Bol_MontoCorrecto = true;
            bool _Bol_Monto1Correcto = true;
            double _Dbl_Monto = 0;
            List<string> _Lst_CamposMontoCargados = new List<string>();
            _Lst_CamposMontoCargados.AddRange(_Dg_Grid.Columns.Cast<DataGridViewColumn>().Where(x => x.Name == "cposmontomov" || x.Name == "cposmontomov1" || x.Name == "cpossaldomov").Select(z => z.Name));
            _Dg_Grid.Rows.Cast<DataGridViewRow>().ToList().ForEach(_Dvr_Fila =>
            {
                _Bol_MontoCorrecto = true;
                _Bol_Monto1Correcto = true;
                _Lst_CamposMontoCargados.ForEach(campo =>
                {
                    _Dvr_Fila.Cells[campo].Style.BackColor = Color.White;

                    string _Str_DatoOriginal = _Dvr_Fila.Cells[campo].Value.ToString().Trim();

                    if (!double.TryParse(_Str_DatoOriginal, out _Dbl_Monto))
                    {
                        if (campo == "cposmontomov") { _Bol_MontoCorrecto = false; }
                        if (campo == "cposmontomov1") { _Bol_Monto1Correcto = false; }
                    }
                });

                //Verifico si es correcto los montos
                if (_Lst_CamposMontoCargados.Contains("cposmontomov1"))
                {
                    if (!_Bol_MontoCorrecto && !_Bol_Monto1Correcto)
                    {
                        _Dvr_Fila.Cells["cposmontomov"].Style.BackColor = Color.Yellow;
                        _Dvr_Fila.Cells["cposmontomov1"].Style.BackColor = Color.Yellow;
                        _Bol_Return = false;
                    }
                }
                else
                {
                    if (!_Bol_MontoCorrecto)
                    {
                        _Dvr_Fila.Cells["cposmontomov"].Style.BackColor = Color.Yellow; ;
                        _Bol_Return = false;
                    }
                }

            });
            _P_Bol_Return = _Bol_Return;
            return _Bol_Return;
        }
        private bool _Mtd_TodasLasFechasCorrectas(out bool _P_Bol_Return)
        {
            bool _Bol_Return = true;
            DateTime _Dtm_Fecha = new DateTime();
            _Dg_Grid.Rows.Cast<DataGridViewRow>().ToList().ForEach(_Dvr_Fila =>
            {
                _Dvr_Fila.Cells["cposdatemovi"].Style.BackColor = Color.White;
                string _Str_DatoOriginal = _Dvr_Fila.Cells["cposdatemovi"].Value.ToString().Trim();
                if (!DateTime.TryParse(_Str_DatoOriginal, out _Dtm_Fecha))
                {
                    _Dvr_Fila.Cells["cposdatemovi"].Style.BackColor = Color.Yellow;
                    _Bol_Return = false;
                }
            });
            _P_Bol_Return = _Bol_Return;
            return _Bol_Return;
        }
        private bool _Mtd_NoExisteOtraCapturaActiva(out bool _P_Bol_Return)
        {
            var _Str_TablaMaestra = "";
            var _Str_TablaDetalle = "";
            _Mtd_ObtenerNombresTablas(out _Str_TablaMaestra, out _Str_TablaDetalle,false);

            bool _Bol_Return = true;
            string _Str_Cadena = "";
            DataSet _Ds_DataSet;
            _Str_Cadena = "SELECT cdispbanc FROM " + _Str_TablaMaestra + " WHERE " + _Str_TablaMaestra + ".ccompany='" + Frm_Padre._Str_Comp + "' AND LTRIM(RTRIM(" + _Str_TablaMaestra + ".cbanco))='" + Convert.ToString(_Cmb_BancoD.SelectedValue).Trim() + "' AND LTRIM(RTRIM(" + _Str_TablaMaestra + ".cnumcuenta))='" + Convert.ToString(_Cmb_CuentaD.SelectedValue).Trim() + "' AND " + _Str_TablaMaestra + ".cdelete=0 AND " + _Str_TablaMaestra + ".cconciliado=0 and cregistroinicial=0";
            _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
            {
                //Si estamos guardando un registro inicial
                _Bol_Return = _Chk_RegistrosIniciales.Checked;
            }
            _P_Bol_Return = _Bol_Return;
            return _P_Bol_Return;
        }
        private void _Mtd_MontoMov(List<string> _P_Lst_CamposNoObligatoriosCargados, DataGridViewRow _P_Dvr_Fila, out double _P_Dbl_Monto)
        {
            //Obtenemos el Dato Original
            string _Str_DatoOriginal = _P_Dvr_Fila.Cells["cposmontomov"].Value.ToString().Trim();

            //Tratamos de convertir
            double.TryParse(_Str_DatoOriginal, out _P_Dbl_Monto);
            if (_P_Lst_CamposNoObligatoriosCargados.Contains("cposmontomov1") && _P_Dbl_Monto == 0)
            {
                //Obtenemos el Dato Original
                var _Str_DatoOriginal1 = _P_Dvr_Fila.Cells["cposmontomov1"].Value.ToString().Trim();
                //Formateamos segun la configuracion
                double.TryParse(_Str_DatoOriginal1, out _P_Dbl_Monto);
            }
        }

        private void _Mtd_SaldoMov(List<string> _P_Lst_CamposNoObligatoriosCargados, DataGridViewRow _P_Dvr_Fila, out double _P_Dbl_Monto)
        {
            if (_P_Lst_CamposNoObligatoriosCargados.Contains("cpossaldomov"))
            {
                //Obtenemos el Dato Original
                string _Str_DatoOriginal = _P_Dvr_Fila.Cells["cpossaldomov"].Value.ToString().Trim();
                //Tratamos de convertir
                double.TryParse(_Str_DatoOriginal, out _P_Dbl_Monto);
            }
            else
            {
                _P_Dbl_Monto = 0;
            }
        }

        private void _Mtd_GuardarArchivo(int _P_Int_DispBanc, FileInfo _P_Fli_Archivo)
        {
            try
            {
                var _Str_TablaMaestra = "";
                var _Str_TablaDetalle = "";
                _Mtd_ObtenerNombresTablas(out _Str_TablaMaestra, out _Str_TablaDetalle,false);

                string _Str_RutaDest = "C:\\WINDOWS\\Temp\\" + _P_Fli_Archivo.Name;
                File.Copy(_P_Fli_Archivo.FullName, _Str_RutaDest, true);
                FileStream _Fls_Stream = new FileStream(_Str_RutaDest, FileMode.Open, FileAccess.Read);
                //FileStream fs = _Pr_archivo.OpenRead();
                //Creamos un array de bytes para almacenar los datos leídos por fs.
                Byte[] _Byt_Data = new byte[_Fls_Stream.Length];
                //Y guardamos los datos en el array data
                _Fls_Stream.Read(_Byt_Data, 0, Convert.ToInt32(_Fls_Stream.Length));
                //Abrimos una conexion. En este caso los datos de la cadena de
                //conexion a la base de datos se recuperan de una sección del
                System.Data.SqlClient.SqlConnection _Sql_Conex = new System.Data.SqlClient.SqlConnection(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
                _Sql_Conex.Open();
                //Creamos un comando de tipo StoredProcedure para invocar a
                //UploadDocs
                System.Data.SqlClient.SqlCommand _Sql_Cmd = new System.Data.SqlClient.SqlCommand("SPE_TDISPBANC_SAVEFILE", _Sql_Conex);
                _Sql_Cmd.CommandType = CommandType.StoredProcedure;
                //Añadimos los parametros esperados y los valores de los mismos
                _Sql_Cmd.Parameters.AddWithValue("@doc", _Byt_Data); //los datos del fichero
                _Sql_Cmd.Parameters.AddWithValue("@nombre", _P_Int_DispBanc.ToString() + _P_Fli_Archivo.Extension); //y su nombre
                _Sql_Cmd.Parameters.AddWithValue("@ccompany", Frm_Padre._Str_Comp); //y su nombre
                _Sql_Cmd.Parameters.AddWithValue("@cdispbanc", _P_Int_DispBanc); //y su nombre
                _Sql_Cmd.Parameters.AddWithValue("@cnombretabla", _Str_TablaMaestra); //y su nombre
                //Ejecutamos el procedimiento almacenado, que inserta un nuevo
                //registro en DocsBinarios con los datos que queremos introducir
                _Sql_Cmd.ExecuteNonQuery();
                //Cerramos la conexión y el fichero 
                _Sql_Cmd.Dispose();
                _Sql_Conex.Close();
                _Sql_Conex.Dispose();
                _Fls_Stream.Close();
                File.Delete(_Str_RutaDest);
            }
            catch (Exception)
            {
            }
        }
        private void _Mtd_InsertarRegistros()
        {
            var _Str_TablaMaestra = "";
            var _Str_TablaDetalle = "";
            _Mtd_ObtenerNombresTablas(out _Str_TablaMaestra, out _Str_TablaDetalle,false);

            string _Str_cregistroinicial = _Chk_RegistrosIniciales.Checked ? "1" : "0";

            List<string> _Lst_CamposNoObligatoriosCargados = new List<string>();
            _Lst_CamposNoObligatoriosCargados.AddRange(_Dg_Grid.Columns.Cast<DataGridViewColumn>().Where(x => x.Name == "cposmontomov1" || x.Name == "cpossaldomov" || x.Name == "cposoficinabanc").Select(z => z.Name));
            string _Str_DispBanc = _Cls_VariosMetodos._Mtd_Correlativo("SELECT MAX(cdispbanc) FROM " + _Str_TablaMaestra + " WHERE ccompany='" + Frm_Padre._Str_Comp + "'");

            string _Str_Cadena = "";

            if (_Opt_TipoConciliacion_Captura.Checked) //Conciliacion
            {
                _Str_Cadena = "INSERT INTO " + _Str_TablaMaestra + " (ccompany,cdispbanc,cnumcuenta,cbanco,cfechacaptura,csaldobanco,cdateadd,cuseradd,cdelete,cregistroinicial) VALUES('" + Frm_Padre._Str_Comp + "'," + _Str_DispBanc + ",'" + Convert.ToString(_Cmb_CuentaD.SelectedValue).Trim() + "','" + Convert.ToString(_Cmb_BancoD.SelectedValue).Trim() + "',GETDATE(),'0',GETDATE(),'" + Frm_Padre._Str_Use + "',0," + _Str_cregistroinicial + ")";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            else
            {
                _Str_Cadena = "INSERT INTO " + _Str_TablaMaestra + " (ccompany,cdispbanc,cnumcuenta,cbanco,cfechacaptura,csaldobanco,cdateadd,cuseradd,cdelete,cregistroinicial,cmontodiferido,cmontodisponible,csaldobancoinicial,cconciliado) VALUES('" + Frm_Padre._Str_Comp + "'," + _Str_DispBanc + ",'" + Convert.ToString(_Cmb_CuentaD.SelectedValue).Trim() + "','" + Convert.ToString(_Cmb_BancoD.SelectedValue).Trim() + "',GETDATE(),'0',GETDATE(),'" + Frm_Padre._Str_Use + "',0," + _Str_cregistroinicial + ",'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_G_Dbl_MontoBloqueado) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_G_Dbl_MontoDisponible) + "','0','0')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }

            //Cargo los tipos de cuentas permitidas
            _Str_Cadena = "SELECT coperbancd FROM TOPERBANCD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cbanco='" + Convert.ToString(_Cmb_BancoD.SelectedValue).Trim() + "' AND ISNULL(cdelete,0)=0";
            DataSet _Ds_DataSetsPermitidos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            //Obtenemos las Filas validas sin las excepciones
            var _Var_Datos = _Dg_Grid.Rows.Cast<DataGridViewRow>().Where(x => _Ds_DataSetsPermitidos.Tables[0].Rows.Cast<DataRow>().Select(z => z["coperbancd"].ToString()).Contains(Convert.ToString(x.Cells["cpostipoperacio"].Value).Trim())).ToList();
            _Var_Datos.ForEach(_Dvr_Fila =>
            {
                double _Dbl_Monto = 0;
                _Mtd_MontoMov(_Lst_CamposNoObligatoriosCargados, _Dvr_Fila, out _Dbl_Monto);
                double _Dbl_Saldo = 0;
                _Mtd_SaldoMov(_Lst_CamposNoObligatoriosCargados, _Dvr_Fila, out _Dbl_Saldo);

                //Quitamos los signos
                _Dbl_Monto = Math.Abs(_Dbl_Monto);
                _Dbl_Saldo = Math.Abs(_Dbl_Saldo);

                //Convierto las Fechas
                string _Str_FechaConvertida = "";
                DateTime _DtmFechaConvertida;
                _Dvr_Fila.Cells["cposdatemovi"].Style.BackColor = Color.White;
                string _Str_DatoOriginal = _Dvr_Fila.Cells["cposdatemovi"].Value.ToString().Trim();
                if (DateTime.TryParse(_Str_DatoOriginal, out _DtmFechaConvertida))
                {
                    _Str_FechaConvertida = _Cls_Formato._Mtd_fecha(_DtmFechaConvertida);
                }

                //Genero el Concepto si es necesario
                string _Str_ConceptoGenerado = "";
                if (!_Dg_Grid.Columns.Contains("cposconcepto"))
                {
                    _Str_ConceptoGenerado = _Mtd_GenerarConcepto(_Dvr_Fila.Cells["cposnumdocu"].Value.ToString(), _Dvr_Fila.Cells["cpostipoperacio"].Value.ToString());
                }
                else
                {
                    _Str_ConceptoGenerado = Convert.ToString(_Dvr_Fila.Cells["cposconcepto"].Value).Trim();
                }

                _Str_Cadena = "INSERT INTO " + _Str_TablaDetalle + " (ccompany,cdispbanc,cdispband,cbanco,cnumcuenta,cdatemovi,cnumdocu,ctipoperacio,cconcepto,cmontomov,csaldomov,coficinabanc) VALUES ('" + Frm_Padre._Str_Comp + "','" + _Str_DispBanc + "','" + (_Dvr_Fila.Index) + "','" + Convert.ToString(_Cmb_BancoD.SelectedValue).Trim() + "','" + Convert.ToString(_Cmb_CuentaD.SelectedValue).Trim() + "','" + _Str_FechaConvertida + "','" + Convert.ToString(_Dvr_Fila.Cells["cposnumdocu"].Value).Trim() + "','" + Convert.ToString(_Dvr_Fila.Cells["cpostipoperacio"].Value).Trim() + "','" + _Str_ConceptoGenerado + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Monto) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Saldo) + "','" + (_Lst_CamposNoObligatoriosCargados.Contains("cposoficinabanc") ? Convert.ToString(_Dvr_Fila.Cells["cposoficinabanc"].Value).Trim() : "") + "')";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            });

            //Si no es solo saldos
            if (!_Chk_SoloSaldos.Checked)
            {
                _Mtd_GuardarArchivo(Convert.ToInt32(_Str_DispBanc), new FileInfo(_Txt_RutaFile.Text));
            }

            //Calculo el Saldo (en funcion a la Vista que es al que se usa en la conciliacion para luego guardar ese datos en la tabla de la captura
            var _decSaldoInicial = Convert.ToDouble(_Cls_RutinasConciliacion._Mtd_ObtenerSaldoInicialBanco(_Cmb_BancoD.SelectedValue.ToString(), _Cmb_CuentaD.SelectedValue.ToString()));
            var _decSaldoCaptura = _Mtd_CalcularSaldoCaptura();
            var _decSaldoFinal = _decSaldoInicial + _decSaldoCaptura;

            //Guardo el saldo calculado
            var _Sql = "UPDATE " + _Str_TablaMaestra + " SET csaldobancoinicial = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_decSaldoInicial) + "', csaldobanco = '" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_decSaldoFinal) + "'  WHERE ccompany = '" + Frm_Padre._Str_Comp + "' AND cbanco = '" + _Cmb_BancoD.SelectedValue.ToString() + "' AND cnumcuenta = '" + _Cmb_CuentaD.SelectedValue.ToString() + "' and cdispbanc = '" + _Str_DispBanc + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Sql);

            //Solo si el tipo de operacion es segun el usuario
            if (_G_Bool_ObtenerTipoOperacionSegunElUsuario)
            {
                //Guardamos los registros en la tabla de autobicheo de tipos de operacion
                //Obtenemos las Filas validas sin las excepciones
                _Var_Datos = _Dg_Grid.Rows.Cast<DataGridViewRow>().Where(x => _Ds_DataSetsPermitidos.Tables[0].Rows.Cast<DataRow>().Select(z => z["coperbancd"].ToString()).Contains(Convert.ToString(x.Cells["cpostipoperacio"].Value).Trim())).ToList();
                _Var_Datos.ForEach(_Dvr_Fila =>
                {
                    //Obtenemos los caracateres a buscar
                    var _Str_Concepto = Convert.ToString(_Dvr_Fila.Cells["cposconcepto"].Value).Trim();

                    //Verificamos la cantidad de caracteres a tomar no puede ser mayor al largo de la cadena
                    var _Int_CaracteresATomarDelConcepto = _G_Int_CaracteresATomarDelConcepto > _Str_Concepto.Length ? _Str_Concepto.Length : _G_Int_CaracteresATomarDelConcepto;

                    var _Str_ConceptoLimpio = _Str_Concepto.Substring(0, _Int_CaracteresATomarDelConcepto);

                    var _Str_ccompany = Frm_Padre._Str_Comp;
                    var _Str_cbanco = Convert.ToString(_Cmb_BancoD.SelectedValue).Trim();
                    var _Str_cdescripcion = _Str_ConceptoLimpio;
                    var _Str_coperbancd = Convert.ToString(_Dvr_Fila.Cells["cpostipoperacio"].Value).Trim();

                    //Buscamos en la tabla
                    if (!_Mtd_ExisteConceptoTablaDeAutoBicheo(_Str_ConceptoLimpio))
                    {
                        //Insertamos el registro   
                        _Str_Cadena = "INSERT INTO TCONFCAPBANCDDD ([ccompany],[cbanco],[cdescripcion],[coperbancd],[cdateadd],[cuseradd],[cdelete]) " +
                                      "VALUES " +
                                      "('" + _Str_ccompany + "','" + _Str_cbanco + "','" + _Str_cdescripcion + "','" + _Str_coperbancd + "',getdate(),'" + Frm_Padre._Str_Use + "','0')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                    }
                });
            }
        }

        private bool _Mtd_ExisteConceptoTablaDeAutoBicheo(string _P_Str_Concepto)
        {
            var _Str_SQL = "SELECT * FROM TCONFCAPBANCDDD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + Convert.ToString(_Cmb_BancoD.SelectedValue).Trim() + "' AND ISNULL(cdelete,0) = 0 " + " AND cdescripcion = '" + _P_Str_Concepto + "'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            return _Ds.Tables[0].Rows.Count > 0;
        }
        private string _Mtd_BuscarTipoOperacionSegunConcepto(string _P_Str_Concepto)
        {
            var _Str_Resultado = "";
            var _SQL_Parametros = new SqlParameter[3];
            _SQL_Parametros[0] = new SqlParameter("@CCOMPANY", SqlDbType.VarChar) {Value = Frm_Padre._Str_Comp};
            _SQL_Parametros[1] = new SqlParameter("@CBANCO", SqlDbType.VarChar) {Value = Convert.ToString(_Cmb_BancoD.SelectedValue).Trim()};
            _SQL_Parametros[2] = new SqlParameter("@CCONCEPTO", SqlDbType.VarChar) {Value = _P_Str_Concepto};
            var _Ds = _Mtd_EjecutarSP("PA_CAPTURA_TCONFCAPBANCDDD", _SQL_Parametros, "@CRESULTADO");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Resultado = _Ds.Tables[0].Rows[0][0].ToString();
            }
            return _Str_Resultado;
        }

        private DataSet _Mtd_EjecutarSP(string nombreSP, SqlParameter[] parametroSP, String _Str_OutPut)
        {
            var oDs = new DataSet();
            var oConexion = new SqlConnection(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            oConexion.Open();
            var oSqlCommando = new SqlCommand(nombreSP, oConexion)
                {
                    CommandTimeout = 3600, 
                    CommandType = CommandType.StoredProcedure
                };
            var parametrossp = new SqlParameter[parametroSP.Length];
            for (int i = 0; i < parametroSP.Length; i++)
            {
                parametrossp[i] = parametroSP[i];
                oSqlCommando.Parameters.Add(parametrossp[i]);
            }
            //var oReader = oSqlCommando.ExecuteReader();
            var oAdaptador = new SqlDataAdapter(oSqlCommando);
            oAdaptador.Fill(oDs);
            oConexion.Close();
            return oDs;
        }
        

        public string _Mtd_GenerarConcepto(string _P_Str_NumeroDocumento, string _P_Str_TipoOperacion)
        {
            string _Str_ConceptoGenerado = "";
            string _Str_SQL = "SELECT coperbancd, cname FROM TOPERBANCD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cbanco='" + Convert.ToString(_Cmb_BancoD.SelectedValue).Trim() + "' AND ISNULL(cdelete,0) = 0 " + " AND coperbancd = '" + _P_Str_TipoOperacion + "'";
            DataSet _Ds_DataSets = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SQL);
            //Genero el Concepto
            _Str_ConceptoGenerado = _Ds_DataSets.Tables[0].Rows[0]["cname"].ToString() + ": " + _P_Str_NumeroDocumento;
            //Devuelvo
            return _Str_ConceptoGenerado;
        }
        private string _Mtd_ObtenerNombreCompania()
        {
            string _Str_Cadena = "Select LTRIM(cname) AS cname from TCOMPANY where ccompany='" + Frm_Padre._Str_Comp + "'";
            var _Str_Resultado = "";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_Resultado = _Ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper();
            }
            return _Str_Resultado;
        }
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            //double _Dbl_Saldo = 0;
            //double.TryParse(_Txt_SaldoD.Text.Trim(), out _Dbl_Saldo);
            if (_Cmb_BancoD.SelectedIndex > 0 && _Cmb_CuentaD.SelectedIndex > 0 && _Cmb_TipArchivo.SelectedIndex > 0 && ((_Txt_RutaFile.Text.Trim().Length > 0) |  (_Chk_SoloSaldos.Checked)))
            {
                bool _Bol_TodasLasOperacionesRegistradas = false;
                bool _Bol_TodosLosMontosCorrectos = false;
                bool _Bol_TodasLasFechasCorrectas = false;
                //bool _Bol_TodosLosRegistrosNoEstanProcesados = false;
                bool _Bol_NoExisteOtraCapturaActiva = false;

                if ((_Str_FormatoFecha == "d") | (_Str_FormatoFecha == "dd"))
                {
                    if (!(_Cmb_Mes.SelectedIndex > 0))
                    {
                        _Er_Error.SetError(_Cmb_Mes, "Información requerida!!!");
                        MessageBox.Show("La configuración de este archivo exige que debe seleccionar un Mes", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (!(_Cmb_Año.SelectedIndex > 0))
                    {
                        _Er_Error.SetError(_Cmb_Año, "Información requerida!!!");
                        MessageBox.Show("La configuración de este archivo exige que debe seleccionar un Año", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }

                if (_Mtd_TodasLasOperacionesRegistradas(Convert.ToString(_Cmb_BancoD.SelectedValue).Trim(), out _Bol_TodasLasOperacionesRegistradas) && _Mtd_TodosLosMontosCorrectos(out _Bol_TodosLosMontosCorrectos) && _Mtd_TodasLasFechasCorrectas(out _Bol_TodasLasFechasCorrectas) && _Mtd_NoExisteOtraCapturaActiva(out _Bol_NoExisteOtraCapturaActiva))
                {
                    var _Resultado = DialogResult.No;

                    if (_Opt_TipoConciliacion_Captura.Checked == true && _Chk_SoloSaldos.Checked == true)
                    {
                        _Resultado = MessageBox.Show("Confirme que se va a registrar un estado de cuenta con solo su saldo", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    }
                    else
                    {
                        _Resultado = MessageBox.Show("Está seguro que el estado de cuenta visualizado pertenece a la compañia " + _Mtd_ObtenerNombreCompania(), "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    }

                    if (_Resultado == DialogResult.Yes)
                    {
                        //Tomamos el Saldo y comparamos
                        var _Dbl_SaldoFinalCalculado = 0.0;
                        var _Bol_Coinciden = false;

                        Double.TryParse(_Txt_SaldoFinalBanco.Text, out _Dbl_SaldoFinalCalculado);
                        //Redondeamos
                        _G_Dbl_SaldoFinalUsuario = Math.Round(_G_Dbl_SaldoFinalUsuario, 2);
                        _Dbl_SaldoFinalCalculado = Math.Round(_Dbl_SaldoFinalCalculado, 2);
                        //Verificamos
                        _Bol_Coinciden = _G_Dbl_SaldoFinalUsuario == _Dbl_SaldoFinalCalculado;
                        if (_Opt_TipoConciliacion_Captura.Checked == true && _Chk_SoloSaldos.Checked == true){_Bol_Coinciden = true;}

                        if (!_Bol_Coinciden)
                        {
                            if (_Opt_TipoConciliacion_Captura.Checked) //Conciliacion
                                MessageBox.Show(this, "El Monto del Saldo Final introducido no coincide!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            else // Disponibilidad
                                MessageBox.Show(this, "El monto del saldo real debe coincidir con el sado final del estado de cuenta a registrar!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        else
                        {
                            _Pnl_MontoSaldoFinal.Visible = false;
                            _Pnl_MontosEstadoCuenta_Disponibilidad.Visible = false;
                            Cursor = Cursors.WaitCursor;
                            _Mtd_InsertarRegistros();
                            Cursor = Cursors.Default;
                            _Mtd_Limpiar();
                            _Opt_TipoConciliacion_Busqueda.Checked = _Opt_TipoConciliacion_Captura.Checked;
                            _Opt_TipoDisponibilidad_Busqueda.Checked = _Opt_TipoDisponibilidad_Captura.Checked;
                            _Cmb_Banco.SelectedValue = Convert.ToString(_Cmb_BancoD.SelectedValue).Trim();
                            _Cmb_Cuenta.SelectedValue = Convert.ToString(_Cmb_CuentaD.SelectedValue).Trim();
                            _Dg_Detalle.DataSource = null;
                            _Mtd_ActualizarCapturas();
                            MessageBox.Show("La captura fue realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _G_Bool_LimpiarRadioButtonsDeBusqueda = false;
                            _Tb_Tab.SelectedIndex = 0;
                            _G_Bool_LimpiarRadioButtonsDeBusqueda = false;
                        }
                    }
                }
                else
                {
                    //if (_Dg_Grid.RowCount == 0)
                    //{ MessageBox.Show("Deben existir registros para realizar la operación", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    if (!_Bol_TodasLasOperacionesRegistradas)
                    { MessageBox.Show("Las operaciones bancarias marcadas en amarillo no estan configuradas en el sistema. Por favor verifique!!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                    else if (!_Bol_TodosLosMontosCorrectos)
                    { MessageBox.Show("Los montos marcados en amarillo no tiene el formato correcto o no eligió el separador de decimales correcto. Por favor verifique!!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                    else if (!_Bol_TodasLasFechasCorrectas)
                    { MessageBox.Show("Las fechas marcadas en amarillo no tienen el formato correcto. Por favor verifique!!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                    //else if (!_Bol_TodosLosRegistrosNoEstanProcesados)
                    //{ MessageBox.Show("No se puede realizar la operación, los documentos con tipo de operación marcados en amarillo han sido procesados anteriormente. Por favor verifique!!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else if (!_Bol_NoExisteOtraCapturaActiva)
                    { MessageBox.Show("Ya existe otra captura por conciliar para la cuenta seleccionada. Por favor verifique!!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                    else if (Math.Round(_G_Dbl_SaldoFinalUsuario, 2) == 0)
                    { MessageBox.Show("Debe introducir el Saldo Final del Estado de Cuenta. Por favor verifique!!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                    else
                    { MessageBox.Show("No se puede realizar la operación... Por favor verifique!!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }

            }
            else
            {
                if (_Cmb_BancoD.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_BancoD, "Información requerida!!!"); }
                else if (_Cmb_CuentaD.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_CuentaD, "Información requerida!!!"); }
                else if (_Cmb_TipArchivo.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_TipArchivo, "Información requerida!!!"); }
                else if (_Txt_RutaFile.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_RutaFile, "Información requerida!!!"); }

            }
            return false;
        }
        private void Frm_CapturaDispBanco2_Load(object sender, EventArgs e)
        {
            _G_Bool_LimpiarRadioButtonsDeBusqueda = true;
            _G_Bool_LimpiarRadioButtonsDeCaptura = false;
            _G_Ds_Registros = null;
            _G_Str_TipoArchivo = "";
            _Mtd_Color_Estandar(this);
            _Mtd_CargarBanco(_Cmb_Banco, true);
            //_Mtd_CargarTipoArchivo(_Cmb_TipArchivo);
            _Txt_SaldoInicialBanco.Text = "";
            _Txt_SaldoFinalBanco.Text = "";
            _Txt_SaldoInicialBancoConsulta.Text = "";
            _Txt_SaldoFinalBancoConsulta.Text = "";

            _Txt_MontoBloqueadoFinalConsulta.Text = "";
            _Txt_MontoDisponibleFinalConsulta.Text = "";
            _Txt_MontoSaldoRealFinalConsulta.Text = "";

            _Txt_MontoBloqueadoFinalCaptura.Text = "";
            _Txt_MontoDisponibleFinalCaptura.Text = "";
            _Txt_MontoSaldoRealFinalCaptura.Text = "";

            _Chk_RegistrosIniciales.Checked = false;
            _Chk_SoloSaldos.Checked = false;

            _Pnl_MontoSaldoFinal.Left = (Width / 2) - (_Pnl_MontoSaldoFinal.Width / 2);
            _Pnl_MontoSaldoFinal.Top = (Height / 2) - (_Pnl_MontoSaldoFinal.Height / 2);
            _Pnl_MontoSaldoFinal.BringToFront();

            _Pnl_MontosEstadoCuenta_Disponibilidad.Left = (Width / 2) - (_Pnl_MontosEstadoCuenta_Disponibilidad.Width / 2);
            _Pnl_MontosEstadoCuenta_Disponibilidad.Top = (Height / 2) - (_Pnl_MontosEstadoCuenta_Disponibilidad.Height / 2);
            _Pnl_MontosEstadoCuenta_Disponibilidad.BringToFront();
        }

        private void _Dtp_Hasta_ValueChanged(object sender, EventArgs e)
        {
            _Dtp_Desde.MaxDate = _Dtp_Hasta.Value;
        }

        private void _Cmb_Banco_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarBanco(_Cmb_Banco, true);
        }

        private void _Cmb_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Banco.SelectedIndex > 0)
            { _Mtd_CargarCuentas(_Cmb_Cuenta, Convert.ToString(_Cmb_Banco.SelectedValue).Trim()); _Cmb_Cuenta.Enabled = true; }
            else
            { _Cmb_Cuenta.Enabled = false; _Cmb_Cuenta.DataSource = null; }
        }

        private void _Cmb_Cuenta_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarCuentas(_Cmb_Cuenta, Convert.ToString(_Cmb_Banco.SelectedValue).Trim());
        }

        private void _Bt_Consultar_Click(object sender, EventArgs e)
        {
            if (!_Opt_TipoConciliacion_Busqueda.Checked && !_Opt_TipoDisponibilidad_Busqueda.Checked)
            {
                MessageBox.Show("Debe seleccionar el tipo de estado de cuenta a consultar.\n", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _Dg_Detalle.DataSource = null;
            _Mtd_ActualizarCapturas();
        }

        private void _Bt_Limpiar_Click(object sender, EventArgs e)
        {
            _Mtd_Limpiar();
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = _Dg_Capturas.SelectedRows.Count == 0;
        }

        private void _Tol_Ver_Click(object sender, EventArgs e)
        {
            _Mtd_ActualizarDetalleDispon(Convert.ToString(_Dg_Capturas.Rows[_Dg_Capturas.CurrentCell.RowIndex].Cells["cdispbanc"].Value).Trim(), Convert.ToString(_Dg_Capturas.Rows[_Dg_Capturas.CurrentCell.RowIndex].Cells["csaldobanco"].Value).Trim());
        }

        private void _Tol_Visualizar_Click(object sender, EventArgs e)
        {
            _Mtd_VisualizarArchivo(Convert.ToString(_Dg_Capturas.Rows[_Dg_Capturas.CurrentCell.RowIndex].Cells["cdispbanc"].Value).Trim());
        }

        private void _Tol_Eliminar_Click(object sender, EventArgs e)
        {
            var _Str_ccompany = Frm_Padre._Str_Comp;
            var _Str_cbanco = Convert.ToString(_Dg_Capturas.Rows[_Dg_Capturas.CurrentCell.RowIndex].Cells["cbanco"].Value).Trim(); ;
            var _Str_cnumcuenta = Convert.ToString(_Dg_Capturas.Rows[_Dg_Capturas.CurrentCell.RowIndex].Cells["cnumcuenta"].Value).Trim(); ;
            var _Str_cdispbanc = Convert.ToString(_Dg_Capturas.Rows[_Dg_Capturas.CurrentCell.RowIndex].Cells["cdispbanc"].Value).Trim();

            _Mtd_EliminarDisp(_Str_ccompany, _Str_cbanco, _Str_cnumcuenta, _Str_cdispbanc);
        }

        private void _Dg_Capturas_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgConsultaInfo.Visible = true;
            }
            else
            {
                _Lbl_DgConsultaInfo.Visible = false;
            }
        }

        private void _Dg_Capturas_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Capturas.SelectedRows.Count == 1)
            {
                _Mtd_ActualizarDetalleDispon(Convert.ToString(_Dg_Capturas.Rows[e.RowIndex].Cells["cdispbanc"].Value).Trim(), Convert.ToString(_Dg_Capturas.Rows[e.RowIndex].Cells["csaldobanco"].Value).Trim());
            }
        }

        private void _Bt_Visualizar_Click(object sender, EventArgs e)
        {
            _Mtd_VisualizarArchivo(_Str_Disp);
        }

        private void Frm_CapturaDispBanco2_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = _G_Bol_PermisoCreacion && !_Pnl_SuperiorD.Enabled; 
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _Pnl_SuperiorD.Enabled;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false; //!_Pnl_SuperiorD.Enabled & _Tb_Tab.SelectedIndex == 1;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
        }

        private void Frm_CapturaDispBanco2_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_Pnl_SuperiorD.Enabled & e.TabPageIndex == 1)
            { e.Cancel = true; }
            else if (e.TabPageIndex == 0)
            {
                _G_Bool_LimpiarRadioButtonsDeBusqueda = false;
                _Mtd_Ini();
                _Pnl_SuperiorD.Enabled = false;
                _Pnl_Inferior.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
            }
        }

        private void _Cmb_BancoD_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarBanco(_Cmb_BancoD, false);
        }

        private DataTable _Mtd_CargarConfiguracion(string _P_Str_CCompany, string _P_Str_CBanco, string _P_TipoDeArchivo = "")
        {

            DataSet _Ds;
            string _Str_Sql = "";
            var _Str_ctipoconfiguracion = _Opt_TipoConciliacion_Captura.Checked ? "1" : "2";

            _Str_Sql += "SELECT ";
            _Str_Sql += "cformatofecha, ";
            _Str_Sql += "ctiposeparador, ";
            _Str_Sql += "cdelimitador, ";
            _Str_Sql += "clineainiciodatos, ";
            _Str_Sql += "cascciexcel ";
            _Str_Sql += ",ctiposeparadordecimal ";
            _Str_Sql += ",ccantidaddigitosdecimales ";
            _Str_Sql += ",cobtenermontoregistroseguncolumnasaldo ";
            _Str_Sql += ",cobtenertipooperacionseguncolumnaconcepto ";
            _Str_Sql += ",cobtenertipooperacionsegunsignomonto ";
            _Str_Sql += ",cobtenertipooperacionsegunelusuario ";
            _Str_Sql += ",ccantidadcaracteresatomarconcepto ";
            _Str_Sql += ",ccantidadcolumnasvaciaspermitidas ";
            _Str_Sql += "FROM TCONFCAPBANCD ";
            _Str_Sql += "WHERE ";
            _Str_Sql += "(ccompany='" + _P_Str_CCompany + "') ";
            _Str_Sql += "AND ";
            _Str_Sql += "(cbanco='" + _P_Str_CBanco + "') ";
            _Str_Sql += "AND ";
            _Str_Sql += "(ISNULL(cdelete,0) = 0) ";

            if (_P_TipoDeArchivo.Length > 0)
            {
                _Str_Sql += "AND ";
                _Str_Sql += "(cascciexcel='" + _P_TipoDeArchivo + "') ";
            }

            _Str_Sql += "AND ";
            _Str_Sql += "(ctipoconfiguracion = '" + _Str_ctipoconfiguracion + "') ";

            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //Devuelvo la Tabla
            if (_Ds != null)
            {
                return _Ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        private int _Mtd_ObtenerColumnaFinalDatos(string _P_Str_Banco, string _P_Str_TipoArchivo)
        {
            var _Int_ColumnaFinalDatos = 0;
            string _Str_Cadena = "SELECT ISNULL(cposdatemovi,0) AS cposdatemovi,ISNULL(cposnumdocu,0) AS cposnumdocu,ISNULL(cpostipoperacio,0) AS cpostipoperacio,ISNULL(cposconcepto,0) AS cposconcepto,ISNULL(cposmontomov,0) AS cposmontomov,ISNULL(cposmontomov1,0) AS cposmontomov1,ISNULL(cpossaldomov,0) AS cpossaldomov,ISNULL(cposoficinabanc,0) AS cposoficinabanc FROM TCONFCAPBANCD WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _P_Str_Banco + "' AND cascciexcel='" + _P_Str_TipoArchivo + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                string _Str_PosicionMayor = _Ds.Tables[0].Rows[0].ItemArray.OrderByDescending(x => int.Parse(x.ToString())).First().ToString();
                _Int_ColumnaFinalDatos = Convert.ToInt32(_Str_PosicionMayor);
            }
            return _Int_ColumnaFinalDatos;
        }

        private void _Cmb_BancoD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_BancoD.SelectedIndex > 0)
            {
                //Valido que este seleccionado el tipo de captura
                if (!_Opt_TipoConciliacion_Captura.Checked && !_Opt_TipoDisponibilidad_Captura.Checked)
                {
                    MessageBox.Show("Debe seleccionar el Tipo de Captura. Por favor verifique!!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    _Cmb_BancoD.SelectedIndex = 0;
                    return;
                }
                _Mtd_CargarCuentas(_Cmb_CuentaD, Convert.ToString(_Cmb_BancoD.SelectedValue).Trim());
                _Cmb_CuentaD.Enabled = true;
                _Cmb_CuentaD.Focus();
            }
            else
            {
                _Cmb_CuentaD.Enabled = false;
                _Cmb_CuentaD.DataSource = null;
                _Mtd_CargarTipoArchivo(_Cmb_TipArchivo);
                _Cmb_TipArchivo.Enabled = false;
                _Cmb_Mes.Enabled = false;
                _Cmb_Año.Enabled = false;
            }
        }

        private void _Cmb_CuentaD_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarCuentas(_Cmb_CuentaD, Convert.ToString(_Cmb_BancoD.SelectedValue).Trim());
        }

        private void _Cmb_CuentaD_SelectedIndexChanged(object sender, EventArgs e)
        {
            var _oTipoEstadoDeCuenta = _Opt_TipoConciliacion_Captura.Checked ? _Cls_RutinasConciliacion._TipoEstadoDeCuenta.Conciliacion : _Cls_RutinasConciliacion._TipoEstadoDeCuenta.Disponibilidad;
            if (_Cmb_CuentaD.SelectedIndex > 0)
            {
                _Mtd_CargarTipoArchivo(_Cmb_TipArchivo);
                _Cmb_TipArchivo.Enabled =  true;
                _Chk_SoloSaldos.Enabled = true;
                _Bt_Abrir.Enabled = true;

                //Validacion de registros Iniciales
                if ((_Cmb_BancoD.SelectedValue != null) && (_Cmb_CuentaD.SelectedValue != null))
                    if (_Chk_RegistrosIniciales.Enabled = _oTipoEstadoDeCuenta == _Cls_RutinasConciliacion._TipoEstadoDeCuenta.Conciliacion && !_Cls_RutinasConciliacion._Mtd_ExisteRegistroInicial(_Cmb_BancoD.SelectedValue.ToString(), _Cmb_CuentaD.SelectedValue.ToString(), _oTipoEstadoDeCuenta))
                    {
                        _Chk_RegistrosIniciales.Checked = false;
                    }
            }


            

            //Si existe alguna conciliación sin finalizar (no se permite agregar un nueva estado de cuenta)
            if ((_Cmb_BancoD.SelectedValue != null) && (_Cmb_CuentaD.SelectedValue != null))
            {
                if (_Opt_TipoConciliacion_Captura.Checked)
                {
                    var _Str_ccompany = Frm_Padre._Str_Comp;
                    var _Str_cbanco = _Cmb_BancoD.SelectedValue.ToString();
                    var _Str_cnumcuenta = _Cmb_CuentaD.SelectedValue.ToString();
                    var _Str_Cadena = "select * from TCONCILIACION where ccompany = '" + _Str_ccompany + "' AND cbanco = '" + _Str_cbanco + "' AND cnumcuenta = '" + _Str_cnumcuenta + "' AND cfinalizado = '0'";
                    var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("No se puede agrega un nuevo Estado de cuenta porque la cuenta seleccionada tiene un conciliación por finalizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Cmb_CuentaD.SelectedIndex = 0;
                        return;
                    }
                    //Solo permitimos una captura a la vez
                    if ((_Cmb_BancoD.SelectedIndex > 0) && (_Cmb_CuentaD.SelectedIndex > 0))
                    {
                        var _Bol_NoExisteOtraCapturaActiva = false;
                        _Mtd_NoExisteOtraCapturaActiva(out _Bol_NoExisteOtraCapturaActiva);
                        if (!_Bol_NoExisteOtraCapturaActiva)
                        {
                            MessageBox.Show("Ya existe otra captura por conciliar para la cuenta seleccionada. Por favor verifique!!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            _Cmb_CuentaD.SelectedIndex = 0;
                            return;
                        }
                    }
                }
                else
                {
                    var _Str_ccompany = Frm_Padre._Str_Comp;
                    var _Str_cbanco = _Cmb_BancoD.SelectedValue.ToString();
                    var _Str_cnumcuenta = _Cmb_CuentaD.SelectedValue.ToString();
                    var _Str_Cadena = "select * from TDISPONIBILIDAD where ccompany = '" + _Str_ccompany + "' AND cbanco = '" + _Str_cbanco + "' AND cnumcuenta = '" + _Str_cnumcuenta + "' AND cfinalizado = '0'";
                    var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("No se puede agrega un nuevo Estado de cuenta porque la cuenta seleccionada tiene un disponibilidad por finalizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Cmb_CuentaD.SelectedIndex = 0;
                        return;
                    }
                    //Solo permitimos una captura a la vez
                    if ((_Cmb_BancoD.SelectedIndex > 0) && (_Cmb_CuentaD.SelectedIndex > 0))
                    {
                        var _Bol_NoExisteOtraCapturaActiva = false;
                        _Mtd_NoExisteOtraCapturaActiva(out _Bol_NoExisteOtraCapturaActiva);
                        if (!_Bol_NoExisteOtraCapturaActiva)
                        {
                            MessageBox.Show("Ya existe otra captura por utilizar en la disponibilidad para la cuenta seleccionada. Por favor verifique!!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            _Cmb_CuentaD.SelectedIndex = 0;
                            return;
                        }
                    }
                }
            }
        }

        private void _Cmb_TipArchivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Bt_Abrir.Enabled = _Cmb_TipArchivo.SelectedIndex > 0;
            _Txt_RutaFile.Text = "";
            _Dg_Grid.Rows.Clear();
            _Dg_Grid.Columns.Clear();
            _Mtd_CargarComboMeses();
            _Mtd_CargarComboAños();

            //Si selecciono algun tipo de archivo valido
            if (_Cmb_TipArchivo.SelectedIndex > 0)
            {
                //Solo saldos
                if ((_Opt_TipoDisponibilidad_Captura.Checked) & (_Chk_SoloSaldos.Checked))
                {
                    _Mtd_SoloSaldos();
                    return;
                }

                //Cargo todos los datos de configuracion del archivo
                DataTable _Dt_Tabla = _Mtd_CargarConfiguracion(Frm_Padre._Str_Comp, Convert.ToString(_Cmb_BancoD.SelectedValue).Trim(), Convert.ToString(_Cmb_TipArchivo.SelectedValue).Trim());
                if (_Dt_Tabla.Rows.Count > 0)
                {
                    _Str_Delimitador = new string[0];
                    _Str_Delimitador = (string[])CLASES._Cls_Varios_Metodos._Mtd_ArrayRedim(_Str_Delimitador, _Str_Delimitador.Length + 1);
                    _Str_Delimitador[_Str_Delimitador.Length - 1] = _Dt_Tabla.Rows[0]["cdelimitador"].ToString();

                    _Int_LineaInicioDatos = Convert.ToInt32(_Dt_Tabla.Rows[0]["clineainiciodatos"].ToString());

                    _G_Byte_ctiposeparadordecimal = Convert.ToByte(_Dt_Tabla.Rows[0]["ctiposeparadordecimal"].ToString());
                    _G_Byte_ccantidaddigitosdecimales = Convert.ToByte(_Dt_Tabla.Rows[0]["ccantidaddigitosdecimales"].ToString());
                    _G_Bool_ObtenerMontoRegistroSegunColumnaSaldo = Convert.ToByte(_Dt_Tabla.Rows[0]["cobtenermontoregistroseguncolumnasaldo"]) == 1;
                    _G_Bool_ObtenerTipoOperacionSegunColumnaConcepto = Convert.ToByte(_Dt_Tabla.Rows[0]["cobtenertipooperacionseguncolumnaconcepto"]) == 1;
                    _G_Bool_ObtenerTipoOperacionSegunSignoMonto = Convert.ToByte(_Dt_Tabla.Rows[0]["cobtenertipooperacionsegunsignomonto"]) == 1;
                    _G_Bool_ObtenerTipoOperacionSegunElUsuario = Convert.ToByte(_Dt_Tabla.Rows[0]["cobtenertipooperacionsegunelusuario"]) == 1;
                    _G_Int_CaracteresATomarDelConcepto = Convert.ToByte(_Dt_Tabla.Rows[0]["ccantidadcaracteresatomarconcepto"]);
                    _G_Int_CantidadColumnasVaciasPermitidas = Convert.ToByte(_Dt_Tabla.Rows[0]["ccantidadcolumnasvaciaspermitidas"]);

                    _Int_ColumnaFinalDatos = _Mtd_ObtenerColumnaFinalDatos(Convert.ToString(_Cmb_BancoD.SelectedValue).Trim(), Convert.ToString(_Cmb_TipArchivo.SelectedValue).Trim());

                    _Str_FormatoFecha = _Dt_Tabla.Rows[0]["cformatofecha"].ToString();

                    //En función al tipo de formato de fecha, habilito o no los controles de mes y año
                    if ((_Str_FormatoFecha == "d") | (_Str_FormatoFecha == "dd"))
                    {
                        _Cmb_Mes.Enabled = true;
                        _Cmb_Año.Enabled = true;
                        _Cmb_Mes.SelectedIndex = 0;
                        _Cmb_Año.SelectedIndex = 0;
                    }
                    else
                    {
                        _Cmb_Mes.Enabled = false;
                        _Cmb_Año.Enabled = false;
                        _Cmb_Mes.SelectedIndex = 0;
                        _Cmb_Año.SelectedIndex = 0;
                    }
                   //Verifico que esten configuradas las cuentas si es el caso
                    if (_G_Bool_ObtenerTipoOperacionSegunSignoMonto)
                    {
                        var _Str_cbanco = Convert.ToString(_Cmb_BancoD.SelectedValue).Trim();
                        if (!_Mtd_EstanConfiguradasTiposDeOperacionBancariaParaCadaSigno(Frm_Padre._Str_GroupComp, _Str_cbanco))
                        {
                            _Bt_Abrir.Enabled = false;
                            MessageBox.Show("El Banco seleccionado no tiene cargado los tipos de operación bancaria necesarios.\n", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    _Bt_Abrir.Enabled = true;
                }
                else
                {
                    _Bt_Abrir.Enabled = false;
                    MessageBox.Show("Error en la operación. El Banco seleccionado no tiene cargada ninguna configuración.\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _Cmb_Mes.Enabled = false;
                _Cmb_Año.Enabled = false;
                _Cmb_Mes.SelectedIndex = 0;
                _Cmb_Año.SelectedIndex = 0;
            }
        }

        private void _Bt_Abrir_Click(object sender, EventArgs e)
        {
            if (_EsValidoControles())
            {
                _Txt_SaldoInicialBanco.Text = "";
                _Txt_SaldoFinalBanco.Text = "";
                _Txt_MontoBloqueadoFinalCaptura.Text = "";
                _Txt_MontoDisponibleFinalCaptura.Text = "";
                _Txt_MontoSaldoRealFinalCaptura.Text = "";
                if (_Opt_TipoConciliacion_Captura.Enabled == true && _Chk_SoloSaldos.Checked == false)
                {
                    //Abrimos el archivo
                    if (_Mtd_AbrirArchivo())
                    {
                        //Pedir Saldo Final Usuario
                        _Mtd_PedirSaldoFinalUsuario();
                    }   
                }
                else if(_Opt_TipoConciliacion_Captura.Enabled == true && _Chk_SoloSaldos.Checked == true)
                {
                    _Mtd_PedirSaldoFinalUsuario();
                }
            }
        }

        private bool _EsValidoControles()
        {
            //Si selecciono una cuenta valida
            if (_Cmb_CuentaD.SelectedIndex > 0)
            {
                //Si estamos chequeando
                if (_Chk_RegistrosIniciales.Checked)
                {
                    //Validacion de registros Iniciales
                    if (_Opt_TipoConciliacion_Captura.Checked)
                    {
                        var _oTipoEstadoDeCuenta = _Cls_RutinasConciliacion._TipoEstadoDeCuenta.Conciliacion;
                        if (_Cls_RutinasConciliacion._Mtd_ExisteRegistroInicial(_Cmb_BancoD.SelectedValue.ToString(), _Cmb_CuentaD.SelectedValue.ToString(), _oTipoEstadoDeCuenta))
                        {
                            Cursor = Cursors.Default;
                            MessageBox.Show("Ya existe una captura de registros iniciales para el banco y cuenta seleccionado, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            _Chk_RegistrosIniciales.Checked = false;
                            _Mtd_CargarComboMeses();
                            _Mtd_CargarComboAños();
                            return false;
                        }
                    }
                    return false;
                }
                //Solo para capturas normales
                else
                {
                    //Validacion del Monto Inicial
                    if (!_Cls_RutinasConciliacion._Mtd_EsValidoSaldoInicialBanco(_Cmb_BancoD.SelectedValue.ToString(), _Cmb_CuentaD.SelectedValue.ToString()))
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("No existe saldo inicial para el banco y cuenta seleccionado, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _Mtd_CargarComboMeses();
                        _Mtd_CargarComboAños();
                        return false;
                    }
                }
            }
            //vamos bien
            return true;
        }

        private bool _Mtd_AbrirArchivo()
        {
            if (Convert.ToString(_Cmb_TipArchivo.SelectedValue).Trim() == "A")
            {
                _Dlg_OpenFile.Filter = "Txt files (*.txt)|*.txt";
            }
            else if (Convert.ToString(_Cmb_TipArchivo.SelectedValue).Trim() == "C")
            {
                _Dlg_OpenFile.Filter = "Csv files (*.csv)|*.csv";
            }
            else
            {
                _Dlg_OpenFile.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All files (*.*)|*.*";
            }
            if (_Dlg_OpenFile.ShowDialog() == DialogResult.OK && _Dlg_OpenFile.CheckFileExists)
            {
                //Inicializamos
                _G_Ds_Registros = null;
                _G_Str_TipoArchivo = "";

                //Pasamos le nombre a minuscula
                var _Str_NombreArchivo = _Dlg_OpenFile.FileName.Trim().ToLower();
                
                //En función al Tipo de archivo abierto
                if (_Cls_RutinasInterfazBancaria._Mtd_EsAscii(_Str_NombreArchivo))          //ASCII
                {
                    _Pnl_Inferior.Enabled = false;
                    _Mtd_CargarComboMeses();
                    _Mtd_CargarComboAños();
                    //_Txt_SaldoD.Text = "";
                    try
                    {
                        var _Ds_NewDataDs = _Cls_RutinasInterfazBancaria._Mtd_ObtenerDsDesdeArchivo(_Str_NombreArchivo, _Str_Delimitador, _Int_LineaInicioDatos);
                        _Ds_NewDataDs = _Cls_RutinasInterfazBancaria._Mtd_ConfigurarDataSet(_Ds_NewDataDs, 1, _Int_ColumnaFinalDatos, _G_Int_CantidadColumnasVaciasPermitidas);
                        //if (_Ds_NewDataDs.Tables[0].Rows.Count == 0)
                        //{ throw new Exception(); }
                        try
                        {
                            _G_Ds_Registros = _Ds_NewDataDs;
                            _G_Str_TipoArchivo = Convert.ToString(_Cmb_TipArchivo.SelectedValue).Trim();
                            _Mtd_CargarGrid(Convert.ToString(_Cmb_BancoD.SelectedValue).Trim(), Convert.ToString(_Cmb_TipArchivo.SelectedValue).Trim(), _Ds_NewDataDs);
                        }
                        catch (Exception _Ex)
                        {
                            MessageBox.Show(_Ex.Message);
                            return false;
                        }
                    }
                    catch (Exception _Ex)
                    {
                        MessageBox.Show("Error en la operación. Verifique que el archivo elegido corresponda con el banco seleccionado.\n" + _Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    Cursor = Cursors.Default;
                    if (_Dg_Grid.RowCount > 0)
                    {
                        _Txt_RutaFile.Text = _Str_NombreArchivo;
                        _Pnl_Inferior.Enabled = true;
                        return true;
                    }
                }
                else if (_Cls_RutinasInterfazBancaria._Mtd_EsCsv(_Str_NombreArchivo))       //CSV
                {
                    _Pnl_Inferior.Enabled = false;
                    _Mtd_CargarComboMeses();
                    _Mtd_CargarComboAños();
                    //_Txt_SaldoD.Text = "";
                    try
                    {
                        var _Ds_NewDataDs = _Cls_RutinasInterfazBancaria._Mtd_ObtenerDsDesdeArchivo(_Str_NombreArchivo, _Str_Delimitador, _Int_LineaInicioDatos);
                        _Ds_NewDataDs = _Cls_RutinasInterfazBancaria._Mtd_ConfigurarDataSet(_Ds_NewDataDs, 1, _Int_ColumnaFinalDatos, _G_Int_CantidadColumnasVaciasPermitidas);
                        //if (_Ds_NewDataDs.Tables[0].Rows.Count == 0)
                        //{ throw new Exception(); }
                        try
                        {
                            _G_Ds_Registros = _Ds_NewDataDs;
                            _G_Str_TipoArchivo = Convert.ToString(_Cmb_TipArchivo.SelectedValue).Trim();
                            _Mtd_CargarGrid(Convert.ToString(_Cmb_BancoD.SelectedValue).Trim(), Convert.ToString(_Cmb_TipArchivo.SelectedValue).Trim(), _Ds_NewDataDs);
                        }
                        catch (Exception _Ex)
                        {
                            MessageBox.Show(_Ex.Message);
                            return false;
                        }
                    }
                    catch (Exception _Ex)
                    {
                        MessageBox.Show("Error en la operación. Verifique que el archivo elegido corresponda con el banco seleccionado.\n" + _Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    Cursor = Cursors.Default;
                    if (_Dg_Grid.RowCount > 0)
                    {
                        _Txt_RutaFile.Text = _Str_NombreArchivo;
                        _Pnl_Inferior.Enabled = true;
                        return true;
                    }
                }
                else if (_Cls_RutinasInterfazBancaria._Mtd_EsExcel(_Str_NombreArchivo))     //EXCEL
                {
                    _Pnl_Inferior.Enabled = false;
                    _Mtd_CargarComboMeses();
                    _Mtd_CargarComboAños();
                    //_Txt_SaldoD.Text = "";
                    Cursor = Cursors.WaitCursor;
                    var _Ds_NewDataDs = _Cls_RutinasInterfazBancaria._Mtd_GetExcel(_Str_NombreArchivo);
                    try
                    {
                        _Ds_NewDataDs = _Cls_RutinasInterfazBancaria._Mtd_ConfigurarDataSet(_Ds_NewDataDs, _Int_LineaInicioDatos, _Int_ColumnaFinalDatos, _G_Int_CantidadColumnasVaciasPermitidas);
                        //if (_Ds_NewDataDs.Tables[0].Rows.Count == 0)
                        //{
                        //    Cursor = Cursors.Default;
                        //    MessageBox.Show("Archivo no válido, no se pudo capturar datos, asegúrese de que no fue manipulado. ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //    return false;
                        //}
                        try
                        {
                            _G_Ds_Registros = _Ds_NewDataDs;
                            _G_Str_TipoArchivo = Convert.ToString(_Cmb_TipArchivo.SelectedValue).Trim();
                            _Mtd_CargarGrid(Convert.ToString(_Cmb_BancoD.SelectedValue).Trim(), Convert.ToString(_Cmb_TipArchivo.SelectedValue).Trim(), _Ds_NewDataDs);
                        }
                        catch (Exception _Ex)
                        {
                            Cursor = Cursors.Default;
                            MessageBox.Show(_Ex.Message);
                            return false;
                        }
                    }
                    catch (Exception _Ex)
                    {
                        MessageBox.Show("Error en la operación. Verifique que el archivo elegido corresponda con el banco seleccionado.\n" + _Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    Cursor = Cursors.Default;
                    //if (_Dg_Grid.RowCount > 0)
                    //{
                    _Txt_RutaFile.Text = _Str_NombreArchivo;
                    _Pnl_Inferior.Enabled = true;
                    return true;
                    //}
                }
                else
                {
                    MessageBox.Show("Archivo no válido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            //fue cancelado
            return false;
            Cursor = Cursors.Default;
        }

        private void _Mtd_PedirSaldoFinalUsuario()
        {
            //Pedimos el saldo final del banco para re-re-verificar
            if (_Opt_TipoConciliacion_Captura.Checked)
            {
                _Pnl_MontoSaldoFinal.Visible = true;
                _Pnl_MontoSaldoFinal.BringToFront();
                _Txt_MontoSaldoFinal.Enabled = !_Chk_SoloSaldos.Checked;
            }

            else if (_Opt_TipoDisponibilidad_Captura.Checked)
            {
                _Pnl_MontosEstadoCuenta_Disponibilidad.Visible = true;
                _Pnl_MontosEstadoCuenta_Disponibilidad.BringToFront();
            }
        }

        private void _Pnl_MontoSaldoFinal_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_MontoSaldoFinal.Visible)
            {
                _Tb_Tab.Enabled = true;
                _Txt_MontoSaldoFinal.Text = "";
                if (_Chk_SoloSaldos.Checked){_Mtd_ObtenerSaldoInicial();}
                _Txt_MontoSaldoFinal.Focus();
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
             }
            else
            {
                _Tb_Tab.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = _G_Bol_PermisoCreacion;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _Pnl_SuperiorD.Enabled;
            }
        }

        private void _Pnl_MontosEstadoCuenta_Disponibilidad_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_MontosEstadoCuenta_Disponibilidad.Visible)
            {
                _Tb_Tab.Enabled = false;
                _Txt_MontoBloqueado_Disponibilidad.Text = "";
                _Txt_MontoDisponible_Disponibilidad.Text = "";
                _Txt_MontoSaldoReal_Disponibilidad.Text = "";
                _Txt_MontoBloqueado_Disponibilidad.Focus();
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            }
            else
            {
                _Tb_Tab.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = _G_Bol_PermisoCreacion;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _Pnl_SuperiorD.Enabled;
            }
        }

        private void _Bt_CancelarMonto_Click(object sender, EventArgs e)
        {
            _Dg_Grid.Rows.Clear();
            _Dg_Grid.Columns.Clear();
            _Dg_Grid.DataSource = null;
            _Dg_Grid.Refresh();
            _Txt_RutaFile.Text = "";
            _Txt_SaldoInicialBanco.Text = "";
            _Txt_SaldoFinalBanco.Text = "";
            _Pnl_MontoSaldoFinal.Visible = false;
        }
        private void _Bt_CancelarMonto_Disponibilidad_Click(object sender, EventArgs e)
        {
            _Dg_Grid.Rows.Clear();
            _Dg_Grid.Columns.Clear();
            _Dg_Grid.DataSource = null;
            _Dg_Grid.Refresh();
            _Txt_RutaFile.Text = "";
            _Txt_SaldoInicialBanco.Text = "";
            _Txt_SaldoFinalBanco.Text = "";
            _Pnl_MontosEstadoCuenta_Disponibilidad.Visible = false;
            _Chk_SoloSaldos.Checked = false;
        }

        private void _Bt_AceptarMonto_Click(object sender, EventArgs e)
        {
            if (_Chk_SoloSaldos.Checked == false)
            {
                //Validamos
                if (_Txt_MontoSaldoFinal.Text.Trim() == "")
                {
                    MessageBox.Show("Debe introducir un Monto válido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _G_Dbl_SaldoFinalUsuario = 0;
                    _Txt_MontoSaldoFinal.Focus();
                    return;
                }

                //Tomamos
                Double.TryParse(_Txt_MontoSaldoFinal.Text, out _G_Dbl_SaldoFinalUsuario);

                //Continuamos la carga del archivo - - - - 

                //Asignar Signos a Montos
                _Mtd_AsignarSignos();

                //Calcula los Saldos
                _Mtd_CalcularMostrarSaldos();

                //Mostramos las operaciones que no estan registrads
                bool _Bol_TodasLasOperacionesRegistradas;
                _Mtd_TodasLasOperacionesRegistradas(Convert.ToString(_Cmb_BancoD.SelectedValue).Trim(), out _Bol_TodasLasOperacionesRegistradas);
            }

            //Ocultamos el panel
            _Pnl_MontoSaldoFinal.Visible = false;
        }

        private void _Bt_AceptarMonto_Disponibilidad_Click(object sender, EventArgs e)
        {
            //Validamos
            if (_Txt_MontoBloqueado_Disponibilidad.Text.Trim() == "")
            {
                MessageBox.Show("Debe introducir un Monto válido para el campo Monto Bloqueado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _G_Dbl_MontoBloqueado = 0;
                _G_Dbl_MontoDisponible = 0;
                _G_Dbl_MontoSaldoReal = 0;
                _Txt_MontoBloqueado_Disponibilidad.Focus();
                return;
            }
            if (_Txt_MontoDisponible_Disponibilidad.Text.Trim() == "")
            {
                MessageBox.Show("Debe introducir un Monto válido para el campo Monto Disponible .", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _G_Dbl_MontoBloqueado = 0;
                _G_Dbl_MontoDisponible = 0;
                _G_Dbl_MontoSaldoReal = 0;
                _Txt_MontoDisponible_Disponibilidad.Focus();
                return;
            }

            //Tomamos
            Double.TryParse(_Txt_MontoBloqueado_Disponibilidad.Text, out _G_Dbl_MontoBloqueado);
            Double.TryParse(_Txt_MontoDisponible_Disponibilidad.Text, out _G_Dbl_MontoDisponible);
            _G_Dbl_MontoSaldoReal = _G_Dbl_MontoBloqueado + _G_Dbl_MontoDisponible;
            _G_Dbl_SaldoFinalUsuario = _G_Dbl_MontoSaldoReal;
            
            //Continuamos la carga del archivo - - - - 
            
            //Asignar Signos a Montos
            _Mtd_AsignarSignos();

            //Calcula los Saldos
            _Mtd_CalcularMostrarSaldos();

            //Mostramos las operaciones que no estan registrads
            bool _Bol_TodasLasOperacionesRegistradas;
            _Mtd_TodasLasOperacionesRegistradas(Convert.ToString(_Cmb_BancoD.SelectedValue).Trim(), out _Bol_TodasLasOperacionesRegistradas);

            //Ocultamos el panel
            _Pnl_MontosEstadoCuenta_Disponibilidad.Visible = false;

        }





        private void _Chk_Todas_CheckedChanged(object sender, EventArgs e)
        {
            _Dtp_Desde.Enabled = !_Chk_Todas.Checked;
            _Dtp_Hasta.Enabled = !_Chk_Todas.Checked;
        }

        private double _Mtd_CalcularSaldoCaptura()
        {
            double _Dbl_Saldo = 0;

            //Configuramos los campos a tomar en cuenta
            List<string> _Lst_CamposNoObligatoriosCargados = new List<string>();
            _Lst_CamposNoObligatoriosCargados.AddRange(_Dg_Grid.Columns.Cast<DataGridViewColumn>().Where(x => x.Name == "cposmontomov1" || x.Name == "cpossaldomov" || x.Name == "cposoficinabanc").Select(z => z.Name));

            //Cargo los tipos de cuentas permitidas
            string _Str_Cadena = "SELECT TOPERBANCD.coperbancd,  TOPERBANC.cdebe, TOPERBANC.chaber FROM TOPERBANCD INNER JOIN TOPERBANC ON TOPERBANCD.coperbanc = TOPERBANC.coperbanc WHERE TOPERBANCD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TOPERBANCD.cbanco='" + Convert.ToString(_Cmb_BancoD.SelectedValue).Trim() + "' AND ISNULL(TOPERBANCD.cdelete,0)=0";
            DataSet _Ds_DataSetsPermitidos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            //Obtenemos las Filas validas sin las excepciones
            var _Var_Datos = _Dg_Grid.Rows.Cast<DataGridViewRow>().Where(x => _Ds_DataSetsPermitidos.Tables[0].Rows.Cast<DataRow>().Select(z => z["coperbancd"].ToString()).Contains(Convert.ToString(x.Cells["cpostipoperacio"].Value).Trim())).ToList();

            //Recorro el Grid
            _Var_Datos.ForEach(_Dvr_Fila =>
            {
                double _Dbl_Monto = 0;

                //Obtenemos el monto del movimiento
                _Mtd_MontoMov(_Lst_CamposNoObligatoriosCargados, _Dvr_Fila, out _Dbl_Monto);

                //Acumulamos el Saldo
                _Dbl_Saldo += _Dbl_Monto;

            });

            //Devuelvo
            return _Dbl_Saldo;
        }

        private void _Mtd_AsignarSignos()
        {
            //Configuramos los campos a tomar en cuenta
            List<string> _Lst_CamposNoObligatoriosCargados = new List<string>();
            _Lst_CamposNoObligatoriosCargados.AddRange(_Dg_Grid.Columns.Cast<DataGridViewColumn>().Where(x => x.Name == "cposmontomov1" || x.Name == "cpossaldomov" || x.Name == "cposoficinabanc").Select(z => z.Name));

            //Cargo los tipos de cuentas permitidas
            string _Str_Cadena = "SELECT TOPERBANCD.coperbancd,  TOPERBANC.cdebe, TOPERBANC.chaber FROM TOPERBANCD INNER JOIN TOPERBANC ON TOPERBANCD.coperbanc = TOPERBANC.coperbanc WHERE TOPERBANCD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TOPERBANCD.cbanco='" + Convert.ToString(_Cmb_BancoD.SelectedValue).Trim() + "' AND ISNULL(TOPERBANCD.cdelete,0)=0";
            DataSet _Ds_DataSetsPermitidos = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);

            //Obtenemos las Filas validas sin las excepciones
            var _Var_Datos = _Dg_Grid.Rows.Cast<DataGridViewRow>().Where(x => _Ds_DataSetsPermitidos.Tables[0].Rows.Cast<DataRow>().Select(z => z["coperbancd"].ToString()).Contains(Convert.ToString(x.Cells["cpostipoperacio"].Value).Trim())).ToList();

            //Recorro el Grid
            _Var_Datos.ForEach(_Dvr_Fila =>
            {
                double _Dbl_Monto = 0;

                //Obtenemos el monto del movimiento
                _Mtd_MontoMov(_Lst_CamposNoObligatoriosCargados, _Dvr_Fila, out _Dbl_Monto);

                //Obtenemos el signo segun la cuenta configurada
                var _Registro = _Ds_DataSetsPermitidos.Tables[0].Rows.Cast<DataRow>().Where(f => f["coperbancd"].ToString() == _Dvr_Fila.Cells["cpostipoperacio"].Value.ToString()).ToList();
                var _SignoPositivo = false;
                if (_Registro.Any())
                {
                    //Obtenemos el signo
                    if (_Registro[0]["cdebe"].ToString() == "1")
                    {
                        _SignoPositivo = true;
                    }
                    //AsignamosConvierto el monto
                    _Mtd_ColocarSaldosEnGrid(_Dvr_Fila, _SignoPositivo);
                }
                else
                {
                    //Marcamos el Saldo en amarillo 
                }
            });
        }

        private void _Mtd_ColocarSaldosEnGrid(DataGridViewRow _P_Dvr_Fila, bool _P_Bool_SingoPositivo)
        {
            double _Dec_Monto = 0;
            double _Dec_Monto1 = 0;

            double.TryParse(Convert.ToString(_P_Dvr_Fila.Cells["cposmontomov"].Value).Trim().Replace("-", ""), out _Dec_Monto);
            if (_Dec_Monto != 0)
            {
                //Cambio el Signo
                if (!_P_Bool_SingoPositivo)
                {
                    _Dec_Monto = (-1)*_Dec_Monto;
                }
                //Guardo en el Grid
                _P_Dvr_Fila.Cells["cposmontomov"].Value = _Dec_Monto.ToString("#,##0.00");
            }
            if (_Dg_Grid.Columns.Contains("cposmontomov1"))
            {
                double.TryParse(Convert.ToString(_P_Dvr_Fila.Cells["cposmontomov1"].Value).Trim().Replace("-", ""), out _Dec_Monto1);
                if (_Dec_Monto1 != 0)
                {
                    //Cambio el Signo
                    if (!_P_Bool_SingoPositivo)
                    {
                        _Dec_Monto1 = (-1)*_Dec_Monto1;
                    }
                    //Guardo en el Grid
                    _P_Dvr_Fila.Cells["cposmontomov1"].Value = _Dec_Monto1.ToString("#,##0.00");
                }
            }

        }

        private void _Mtd_ObtenerSaldoInicial()
        {
            Double _Dbl_SaldoInicial = 0;

            _Dbl_SaldoInicial = Convert.ToDouble(_Cls_RutinasConciliacion._Mtd_ObtenerSaldoInicialBanco(_Cmb_BancoD.SelectedValue.ToString(), _Cmb_CuentaD.SelectedValue.ToString()));
            _Txt_MontoSaldoFinal.Text = _Dbl_SaldoInicial.ToString("#,##0.00");
            _Txt_SaldoInicialBanco.Text = _Dbl_SaldoInicial.ToString("#,##0.00");
            _Txt_SaldoFinalBanco.Text = _Dbl_SaldoInicial.ToString("#,##0.00");

        }

        private void _Mtd_CalcularMostrarSaldos()
        {
            double _Dbl_SaldoInicial = 0;
            double _Dbl_SaldoFinal = 0;
            double _Dbl_SaldoCaptura = 0;
            double _Dbl_MontoBloqueadoCaptura = 0;
            double _Dbl_MontoDisponibleCaptura = 0;
            double _Dbl_MontoSaldoRealCaptura = 0;


            if (_Opt_TipoConciliacion_Captura.Checked)
            {
                if (_Chk_RegistrosIniciales.Checked)
                {
                    //Obtenemos los saldos
                    _Dbl_SaldoInicial = 0;
                    _Dbl_SaldoFinal = 0;
                }
                else
                {
                    //Obtenemos los saldos
                    _Dbl_SaldoInicial = Convert.ToDouble(_Cls_RutinasConciliacion._Mtd_ObtenerSaldoInicialBanco(_Cmb_BancoD.SelectedValue.ToString(), _Cmb_CuentaD.SelectedValue.ToString()));
                    _Dbl_SaldoCaptura = _Mtd_CalcularSaldoCaptura();
                    _Dbl_SaldoFinal = _Dbl_SaldoInicial + _Dbl_SaldoCaptura;
                }
            }
            else if (_Opt_TipoDisponibilidad_Captura.Checked)
            {
                //Obtenemos los saldos
                _Dbl_SaldoInicial = Convert.ToDouble(_Cls_RutinasConciliacion._Mtd_ObtenerSaldoInicialBanco(_Cmb_BancoD.SelectedValue.ToString(), _Cmb_CuentaD.SelectedValue.ToString()));
                _Dbl_SaldoCaptura = _Mtd_CalcularSaldoCaptura();
                _Dbl_SaldoFinal = _Dbl_SaldoInicial + _Dbl_SaldoCaptura;
                _Dbl_MontoBloqueadoCaptura = _G_Dbl_MontoBloqueado;
                _Dbl_MontoDisponibleCaptura = _G_Dbl_MontoDisponible;
                _Dbl_MontoSaldoRealCaptura = _G_Dbl_MontoSaldoReal;
            }

            //Muestro los Saldo
            _Txt_SaldoInicialBanco.Text = _Dbl_SaldoInicial.ToString("#,##0.00");
            _Txt_SaldoFinalBanco.Text = _Dbl_SaldoFinal.ToString("#,##0.00");
            _Txt_MontoBloqueadoFinalCaptura.Text = _Dbl_MontoBloqueadoCaptura.ToString("#,##0.00");
            _Txt_MontoDisponibleFinalCaptura.Text = _Dbl_MontoDisponibleCaptura.ToString("#,##0.00");
            _Txt_MontoSaldoRealFinalCaptura.Text = _Dbl_MontoSaldoRealCaptura.ToString("#,##0.00");
        }

        private void _Chk_RegistrosIniciales_CheckedChanged(object sender, EventArgs e)
        {
            //Si estamos chequeando
            if (_Chk_RegistrosIniciales.Checked)
            {
                //Si selecciono una cuenta valida
                if (_Cmb_CuentaD.SelectedIndex > 0)
                {
                    //Validacion de registros Iniciales
                    if (_Cls_RutinasConciliacion._Mtd_ExisteRegistroInicial(_Cmb_BancoD.SelectedValue.ToString(), _Cmb_CuentaD.SelectedValue.ToString(),_Cls_RutinasConciliacion._TipoEstadoDeCuenta.Conciliacion))
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("Ya existe una captura de registros iniciales para el banco y cuenta seleccionado, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _Chk_RegistrosIniciales.Checked = false;
                    }
                }
            }
            else
            {
                //Validacion del Monto Inicial
                //Si selecciono una cuenta valida
                if (_Cmb_CuentaD.SelectedIndex > 0)
                {
                    if (!_Cls_RutinasConciliacion._Mtd_EsValidoSaldoInicialBanco(_Cmb_BancoD.SelectedValue.ToString(), _Cmb_CuentaD.SelectedValue.ToString()))
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("No existe saldo inicial para el banco y cuenta seleccionado, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _Txt_RutaFile.Text = "";
                        _Dg_Grid.Rows.Clear();
                        _Dg_Grid.Columns.Clear();
                        _Mtd_CargarComboMeses();
                        _Mtd_CargarComboAños();
                    }
                }
            }
            _Mtd_CalcularMostrarSaldos();
        }

        private void _Mtd_RecargarGrid()
        {
            Cursor = Cursors.WaitCursor;
            if ((_G_Ds_Registros != null) & (_G_Str_TipoArchivo != ""))
            {
                //Cargamos de nuevo el grid
                _Mtd_CargarGrid(Convert.ToString(_Cmb_BancoD.SelectedValue).Trim(), _G_Str_TipoArchivo, _G_Ds_Registros);
                //Asignar Signos a Montos
                _Mtd_AsignarSignos();
                //Calcula los Saldos
                _Mtd_CalcularMostrarSaldos();
                //Mostramos las operaciones que no estan registrads
                bool _Bol_TodasLasOperacionesRegistradas;
                _Mtd_TodasLasOperacionesRegistradas(Convert.ToString(_Cmb_BancoD.SelectedValue).Trim(), out _Bol_TodasLasOperacionesRegistradas);

            }
            Cursor = Cursors.Default;
        }
        private void _Cmb_Mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_BancoD.SelectedIndex > 0 && _Cmb_CuentaD.SelectedIndex > 0 && _Cmb_TipArchivo.SelectedIndex > 0 && _Txt_RutaFile.Text.Trim().Length > 0)
                _Mtd_RecargarGrid();
        }

        private void _Cmb_Año_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_BancoD.SelectedIndex > 0 && _Cmb_CuentaD.SelectedIndex > 0 && _Cmb_TipArchivo.SelectedIndex > 0 && _Txt_RutaFile.Text.Trim().Length > 0)
                _Mtd_RecargarGrid();
        }

        private void _Txt_MontoSaldoFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar)) && (e.KeyChar != ',') && (e.KeyChar != '.') && (e.KeyChar != '-')))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.'))
            {
                e.KeyChar = ',';
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void _Opt_TipoConciliacion_Captura_CheckedChanged(object sender, EventArgs e)
        {
            if (_Opt_TipoConciliacion_Captura.Checked)
            {
                _Mtd_Limpiar_Tipo_Captura();
                //_Mtd_Ini();
                //_Chk_RegistrosIniciales.Enabled = true;
                //_Txt_MontoBloqueadoFinalCaptura.Visible = false;
                //_Txt_MontoDisponibleFinalCaptura.Visible = false;
                //_Txt_MontoSaldoRealFinalCaptura.Visible = false;
                //_Lbl_MontoBloqueadoFinalCaptura.Visible = false;
                //_Lbl_MontoDisponibleFinalCaptura.Visible = false;
                //_Lbl_MontoSaldoRealFinalCaptura.Visible = false;
                //_Mtd_CargarBanco(_Cmb_Banco, false);
                //_Chk_SoloSaldos.Enabled = true;
            }
        }

        private void _Opt_TipoDisponibilidad_Captura_CheckedChanged(object sender, EventArgs e)
        {
            if (_Opt_TipoDisponibilidad_Captura.Checked)
            {
                _Mtd_Limpiar_Tipo_Captura();
                //_Mtd_Ini();
                //_Chk_RegistrosIniciales.Checked = false;
                //_Chk_RegistrosIniciales.Enabled = false;
                //_Txt_MontoBloqueadoFinalCaptura.Visible = true;
                //_Txt_MontoDisponibleFinalCaptura.Visible = true;
                //_Txt_MontoSaldoRealFinalCaptura.Visible = true;
                //_Lbl_MontoBloqueadoFinalCaptura.Visible = true;
                //_Lbl_MontoDisponibleFinalCaptura.Visible = true;
                //_Lbl_MontoSaldoRealFinalCaptura.Visible = true;
                //_Mtd_CargarBanco(_Cmb_Banco, false);
                //_Chk_SoloSaldos.Enabled = true;
            }
        }

        private void _Txt_MontoDiferido_Disponibilidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar)) && (e.KeyChar != ',') && (e.KeyChar != '.') && (e.KeyChar != '-')))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.'))
            {
                e.KeyChar = ',';
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void _Txt_MontoSaldoFinal_Disponibilidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar)) && (e.KeyChar != ',') && (e.KeyChar != '.') && (e.KeyChar != '-')))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.'))
            {
                e.KeyChar = ',';
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void _Txt_MontoDiferido_Disponibilidad_TextChanged(object sender, EventArgs e)
        {
            _Mtd_CalcularSaldoReal();
        }

        private void _Txt_MontoSaldoFinal_Disponibilidad_TextChanged(object sender, EventArgs e)
        {
            _Mtd_CalcularSaldoReal();
        }

        private void _Mtd_CalcularSaldoReal()
        {
            var _Dbl_MontoDiferido = 0.0;
            var _Dbl_MontoDisponible = 0.0;
            var _Dbl_MontoSaldoReal = 0.0;
            Double.TryParse(_Txt_MontoBloqueado_Disponibilidad.Text, out _Dbl_MontoDiferido);
            Double.TryParse(_Txt_MontoDisponible_Disponibilidad.Text, out _Dbl_MontoDisponible);
            _Dbl_MontoSaldoReal = _Dbl_MontoDiferido + _Dbl_MontoDisponible;
            _Txt_MontoSaldoReal_Disponibilidad.Text = _Dbl_MontoSaldoReal.ToString("#,##0.00");
        }

        private void _Opt_TipoConciliacion_Busqueda_CheckedChanged(object sender, EventArgs e)
        {
            if (_Opt_TipoConciliacion_Busqueda.Checked)
            {
                _Txt_MontoBloqueadoFinalConsulta.Visible = false;
                _Txt_MontoDisponibleFinalConsulta.Visible = false;
                _Txt_MontoSaldoRealFinalConsulta.Visible = false;
                _Lbl_MontoBloqueadoFinalConsulta.Visible = false;
                _Lbl_MontoDisponibleFinalConsulta.Visible = false;
                _Lbl_MontoSaldoRealFinalConsulta.Visible = false;
            }
        }

        private void _Opt_TipoDisponibilidad_Busqueda_CheckedChanged(object sender, EventArgs e)
        {
            if (_Opt_TipoDisponibilidad_Busqueda.Checked)
            {
                _Txt_MontoBloqueadoFinalConsulta.Visible = true;
                _Txt_MontoDisponibleFinalConsulta.Visible = true;
                _Txt_MontoSaldoRealFinalConsulta.Visible = true;
                _Lbl_MontoBloqueadoFinalConsulta.Visible = true;
                _Lbl_MontoDisponibleFinalConsulta.Visible = true;
                _Lbl_MontoSaldoRealFinalConsulta.Visible = true;
            }
        }

        private string _G_Str_Monto = "";
        private void _Dg_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Fila
                int _intFila = e.RowIndex;

                //Evito los encabezados
                if (e.RowIndex < 0)
                {
                    _intFila = 0;
                }

                //Columna
                int _intColumna = e.ColumnIndex;

                //Solo permito la edicion de la columna del combo
                if ((_intColumna == 5) & _G_Bool_ObtenerTipoOperacionSegunElUsuario)
                {
                    //Obtengo el valor del Monto de la fila seleccionada
                    _G_Str_Monto = _Dg_Grid.Rows[_intFila].Cells["cposmontomov"].Value.ToString();
                    //Obtenemos el signo del monto
                    var _Bool_SignoPositivo = _G_Str_Monto.IndexOf("-") < 0;

                    //Obtenemos el combo
                    var _CeldaCombo = (DataGridViewComboBoxCell)_Dg_Grid.Rows[_intFila].Cells["cmbTipoOperacionBancaria"];

                    //Cargamos los valores del combo para la compañia banco seleccionado
                    //_Mtd_CargarComboTipoOperacion(_CeldaCombo, _Bool_SignoPositivo);

                    _Dg_Grid.CurrentCell = _Dg_Grid.Rows[_intFila].Cells[_intColumna];
                    _Dg_Grid.BeginEdit(true);
                }
                else
                {
                    _Dg_Grid.CancelEdit();
                }

            }
            catch (Exception)
            {
            }
        }

        private void _Dg_Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_G_Bool_ObtenerTipoOperacionSegunElUsuario)
            {
                //Si es la columna del combo
                if (e.ColumnIndex == 5)
                {
                    //Verifico que sea valido la celda
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {
                        if (!_G_EstamosSeteandoCombos)
                        {
                            //Obtengo el valor seleccionado
                            var strValor = this._Dg_Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                            //En función al valor coloreo
                            if (strValor != "nulo")
                            {
                                _Dg_Grid.Rows[e.RowIndex].Cells["cpostipoperacio"].Value = strValor;
                                _Dg_Grid.Rows[e.RowIndex].Cells["cpostipoperacio"].Style.BackColor = _G_ColorInicialGrid;
                            }
                            else
                            {
                                _Dg_Grid.Rows[e.RowIndex].Cells["cpostipoperacio"].Value = "";
                                _Dg_Grid.Rows[e.RowIndex].Cells["cpostipoperacio"].Style.BackColor = Color.Yellow;
                            }
                        }
                    }
                    _Mtd_CalcularMostrarSaldos();
                }
            }
        }

        private void _Dg_Grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            var _Dtg = (DataGridView)sender;
            if (_Dtg.IsCurrentCellDirty)
            {
                _Dtg.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void _Dg_Grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var _Control = e.Control as ComboBox;
            if (_Control != null)
            {
                _Control.Enter -= new EventHandler(_Dg_Grid_Enter);
                _Control.Enter += new EventHandler(_Dg_Grid_Enter);
            }
        }
        void _Dg_Grid_Enter(object sender, EventArgs e)
        {
            var _Control = sender as ComboBox;
            if (_Control != null)
            {
                _Control.DroppedDown = true;
                _Control.SelectedIndex = 0;
                //_Control.Click += new EventHandler(_Mtd_ComboBox_BancoNoConciliados_Click);
                //_Control.SelectedIndexChanged -= new EventHandler(_Mtd_ComboBox_BancoNoConciliados_SelectedIndexChanged);
                //_Control.SelectedIndexChanged += new EventHandler(_Mtd_ComboBox_BancoNoConciliados_SelectedIndexChanged);
            }
        }

        private void _Mtd_CargarComboTipoOperacion(DataGridViewComboBoxCell _P_Cmb_Combo, bool pSignoPositivo)
        {
            Cursor = Cursors.WaitCursor;

            if (_P_Cmb_Combo.Items.Count > 0)
            {
                Cursor = Cursors.Default;
                return;
            }
            var _Str_Consulta = "SELECT TOPERBANCD.coperbancd, TOPERBANCD.cname " +
                                "FROM TOPERBANCD INNER JOIN TOPERBANC ON TOPERBANCD.coperbanc = TOPERBANC.coperbanc " +
                                "WHERE (TOPERBANC.cdelete = 0) AND (TOPERBANCD.cdelete = 0) AND (TOPERBANCD.cbanco = 1) " +
                                "AND (TOPERBANCD.cgroupcomp = '" + Frm_Padre._Str_GroupComp + "') " +
                                "AND (TOPERBANCD.cbanco = '" + _Cmb_BancoD.SelectedValue.ToString() + "') " +
                                "AND " + (pSignoPositivo ? "(TOPERBANC.cdebe = 1)" : "(TOPERBANC.chaber = 1) ") +
                                "ORDER BY TOPERBANCD.cname ";
            _Mtd_CargarComboGrid(_P_Cmb_Combo, _Str_Consulta);
            Cursor = Cursors.Default;
        }
        public void _Mtd_CargarComboGrid(DataGridViewComboBoxCell _Pr_Cb, string _Str_Sql)
        {
            DataSet _Ds;
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Pr_Cb.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString(), _DRow[0].ToString()));
            }
            _Pr_Cb.DataSource = _myArrayList;
            _Pr_Cb.DisplayMember = "Display";
            _Pr_Cb.ValueMember = "Value";
        }

        private void _Dg_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void _Chk_SoloSaldos_CheckedChanged(object sender, EventArgs e)
        {
            //if (_Opt_TipoDisponibilidad_Captura.Checked == true || _Opt_TipoConciliacion_Captura.Checked == true)
            //{
            //    _Cmb_TipArchivo.Enabled = true;
                _Cmb_TipArchivo.SelectedIndex=0;
            //    _Bt_Abrir.Enabled = true;
            //    //_Mtd_SoloSaldos();
            //}
            ////else if ((_Opt_TipoDisponibilidad_Captura.Checked == true || _Opt_TipoConciliacion_Captura.Checked == true) && _Chk_SoloSaldos.Checked == false)
            //{
            //    _Cmb_TipArchivo.Enabled = true;
            //    _Bt_Abrir.Enabled = true;
            //}
        }

        private void _Mtd_SoloSaldos()
        {
            if (_EsValidoControles())
            {
                _Txt_SaldoInicialBanco.Text = "";
                _Txt_SaldoFinalBanco.Text = "";
                _Txt_MontoBloqueadoFinalCaptura.Text = "";
                _Txt_MontoDisponibleFinalCaptura.Text = "";
                _Txt_MontoSaldoRealFinalCaptura.Text = "";
                //Pedir Saldo Final Usuario
                _Mtd_PedirSaldoFinalUsuario();
            }
        }



    }
}
