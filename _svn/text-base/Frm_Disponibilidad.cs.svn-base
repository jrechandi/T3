using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using T3.Clases;

namespace T3
{
    public partial class Frm_Disponibilidad : Form
    {
        private string _G_Str_SentenciaSql;
        private DataSet _G_Ds_DataSet = new DataSet();
        private Color _G_ColorInicialGrid;
        private readonly CLASES._Cls_Varios_Metodos _G_myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        private bool _G_Bol_ModoGuardar;
        private bool _G_Bol_ModoReporte;
        private bool _G_Bol_ModoConsulta = true;
        private int _G_Int_Paso = 1;
        private DataSet _G_Ds_BancoLibro = new DataSet(); //Variable global para guardar
        private DataTable _G_Dt_BancoNoConciliado = new DataTable(); //Solo se utiliza para mostrar los registros ordenados en el grid
        private DataTable _G_Dt_MayorAnalitico = new DataTable(); //Solo se utiliza para mostrar los registros ordenados en el grid
        private DataSet _G_Ds_EstadosBanco = new DataSet();
        private DataSet _G_Ds_EstadosLibro = new DataSet();
        private bool _G_Bol_Impreso;
        private bool _G_EstamosSeteandoCombos;
        private readonly bool _G_Bol_PermisoCreacion;
        private string _G_Str_cdispbanc = "";
        private string _G_Str_cbanco = "";
        private string _G_Str_cnumcuenta = "";
        private bool _G_Bol_ExisteConciliacion = false;


        private int _G_Int_Ciddetalleconciliacion;

        private int _G_Int_ciddisponibilidad = 0;
        private int _G_Int_cdispbanc = 0;
        private int _G_Int_cidconciliacion = 0;
        private DataView _G_Dtv_RegistrosChequesPendientes;
        private string _G_Str_cestadoid;


        //Constantes mostrar caracteres especiales en el grid
        private const string _G_Str_Seleccionado = "ü";
        private const string _G_Str_SeleccionadoManual = "Ü";
        private const string _G_Str_NoSeleccionado = "û";


        public Frm_Disponibilidad()
        {
            InitializeComponent();
            _G_Bol_PermisoCreacion = _G_myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _G_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CONC_NUEVA_CONCILIACION");
            _Rpt_ReporteConciliacion.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_ReporteConciliacion.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_ConciliacionBancaria";
            //_Dtp_Hasta.MaxDate = DateTime.Now.AddDays(-1);
            _Mtd_CargarBancoConsulta();
            _Mtd_Consultar("", "");
        }

        public Frm_Disponibilidad(string _P_Str_Impreso)
        {
            InitializeComponent();
            _G_Bol_PermisoCreacion = _G_myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _G_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CONC_NUEVA_CONCILIACION");
            _Rpt_ReporteConciliacion.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_ReporteConciliacion.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_ConciliacionBancaria";
            //_Dtp_Hasta.MaxDate = DateTime.Now.AddDays(-1);
            _Mtd_CargarBancoConsulta();
            if (_P_Str_Impreso == "1")
            {
                _Chk_PorImprimir.Checked = true;
            }
            _Mtd_Consultar("", "");
        }

        private bool _Bol_NotificadorAprobacion = false;

        private void _Mtd_CargarBancoConsulta()
        {
            try
            {
                _G_Str_SentenciaSql = "SELECT DISTINCT CBANCO,CNAME FROM VST_BANCOCUENTAS WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                _Mtd_CargarComboLimpiandoCampos(_Cmb_BancoConsulta, _G_Str_SentenciaSql);
                _Mtd_CargarComboLimpiandoCampos(_Cmb_BancoDetalle, _G_Str_SentenciaSql);
            }
            catch
            {
            }
        }

        private void _Mtd_CargarComboLimpiandoCampos(ComboBox _Pr_Cb, string _Str_Sql)
        {
            DataSet _Ds;
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Pr_Cb.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            foreach (DataRow _DRow in _Ds.Tables[0].Rows)
            {
                _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString(), _DRow[0].ToString().Trim()));
            }
            _Pr_Cb.DataSource = _myArrayList;
            _Pr_Cb.DisplayMember = "Display";
            _Pr_Cb.ValueMember = "Value";
            _Pr_Cb.SelectedValue = "nulo";
        }

        private void _Mtd_CargarCuentaConsultas(string _P_Str_Banco)
        {
            try
            {
                _G_Str_SentenciaSql = "SELECT cnumcuenta,cuentabanname FROM VST_BANCOCUENTAS WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CBANCO='" + _P_Str_Banco + "'";
                _G_myUtilidad._Mtd_CargarCombo(_Cmb_CuentaConsulta, _G_Str_SentenciaSql);
                if (_Cmb_CuentaConsulta.Items.Count > 1)
                {
                    _Cmb_CuentaConsulta.Enabled = true;
                }
                else
                {
                    _Cmb_CuentaConsulta.Enabled = false;
                }
            }
            catch
            {
            }
        }

        private void _Mtd_CargarCuentaConsultas(string _P_Str_Banco, ComboBox _P_Cmb_Combo)
        {
            try
            {
                _G_Str_SentenciaSql = "SELECT cnumcuenta,cuentabanname FROM VST_BANCOCUENTAS WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CBANCO='" + _P_Str_Banco + "'";
                _G_myUtilidad._Mtd_CargarCombo(_P_Cmb_Combo, _G_Str_SentenciaSql);
                if (_P_Cmb_Combo.Items.Count > 1)
                {
                    _P_Cmb_Combo.Enabled = true;
                }
                else
                {
                    _P_Cmb_Combo.Enabled = false;
                }
            }
            catch
            {
            }
        }

        private void _Cmb_BancoConsulta_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarBancoConsulta();
        }

        private void _Cmb_BancoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_BancoConsulta.SelectedValue != null)
            {
                if (_Cmb_BancoConsulta.SelectedIndex > 0)
                {
                    _Mtd_CargarCuentaConsultas(_Cmb_BancoConsulta.SelectedValue.ToString(), _Cmb_CuentaConsulta);
                }
            }
        }

        private void _Cmb_CuentaConsulta_DropDown(object sender, EventArgs e)
        {
            if (_Cmb_BancoConsulta.SelectedValue != null)
            {
                if (_Cmb_BancoConsulta.SelectedIndex > 0)
                {
                    _Mtd_CargarCuentaConsultas(_Cmb_BancoConsulta.SelectedValue.ToString());
                }
            }
        }

        private void _Btn_Consultar_Click(object sender, EventArgs e)
        {
            string _Str_Banco = "";
            string _Str_NumCuenta = "";
            if (_Cmb_BancoConsulta.SelectedValue != null)
            {
                if (_Cmb_BancoConsulta.SelectedValue.ToString() != "nulo")
                {
                    _Str_Banco = _Cmb_BancoConsulta.SelectedValue.ToString();
                }
            }
            if (_Cmb_CuentaConsulta.SelectedValue != null)
            {
                if (_Cmb_CuentaConsulta.SelectedValue.ToString() != "nulo")
                {
                    _Str_NumCuenta = _Cmb_CuentaConsulta.SelectedValue.ToString();
                }
            }
            _Mtd_Consultar(_Str_Banco, _Str_NumCuenta);
        }

        private void _Mtd_Habilitar(bool _Bol_Habilitar)
        {
            _Tab_PasosConciliacion.Enabled = _Bol_Habilitar;
            _Pnl_DetalleProceso.Enabled = false;
        }

        private void _Mtd_Consultar(string _Str_Banco, string _Str_NumeroCuenta)
        {
            string _Str_Where = "";
            if (_Str_Banco.Length > 0)
            {
                _Str_Where += " AND TDISPONIBILIDAD.CBANCO='" + _Str_Banco + "'";
            }
            if (_Str_NumeroCuenta.Length > 0)
            {
                _Str_Where += " AND TDISPONIBILIDAD.CNUMCUENTA='" + _Str_NumeroCuenta + "'";
            }
            _Str_Where += " AND CIMPRESO='" + Convert.ToInt32(!_Chk_PorImprimir.Checked) + "'";
            _G_Str_SentenciaSql =
                "SELECT TDISPONIBILIDAD.ciddisponibilidad AS [Id Disponibilidad]" +
                        ",TBANCO.cname As [Banco]" +
                        ",TDISPONIBILIDAD.cnumcuenta As [Nº Cuenta]" +
                        ",CONVERT(VARCHAR, TDISPONIBILIDAD.cfechadisponibilidad, 103) AS [Fecha]" +
                        "FROM TDISPONIBILIDAD INNER JOIN TBANCO ON TDISPONIBILIDAD.ccompany = TBANCO.ccompany AND TDISPONIBILIDAD.cbanco = TBANCO.cbanco WHERE TDISPONIBILIDAD.CCOMPANY='" +
                Frm_Padre._Str_Comp + "' and TDISPONIBILIDAD.cfinalizado=1 " + _Str_Where + " ORDER BY TDISPONIBILIDAD.ciddisponibilidad DESC";
            _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);
            _Dtg_Consulta.DataSource = _G_Ds_DataSet.Tables[0];
            //_Dtg_Consulta.Columns["Monto Conciliación Bancaria"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dtg_Consulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void Frm_ConciliacionBancariaV2_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            ((Frm_Padre) this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = _G_Bol_PermisoCreacion;
            ((Frm_Padre) this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            ((Frm_Padre) this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
        }

        private void Frm_ConciliacionBancariaV2_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
            ((Frm_Padre) this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            ((Frm_Padre) this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
        }

        public void _Mtd_Nuevo()
        {
            //Habilito el boton exportar
            _Rpt_ReporteConciliacion.ShowExportButton = false;
            _Mtd_Ini();
            _Btn_Finalizar.Text = "Finalizar";
            _Tab_Contenedor.SelectedIndex = 1;
            ((Frm_Padre) this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
        }

        private void _Mtd_Ini()
        {
            string _G_Str_SentenciaSQLBanco = "";

            // (Solo muestra las columnas en el grid vacio)
            _G_Str_SentenciaSQLBanco = "SELECT ";
            _G_Str_SentenciaSQLBanco += " char(251) as cseleccionado "; //00
            _G_Str_SentenciaSQLBanco += ", 'BANCO' as [Tip.Reg.]  "; //01
            _G_Str_SentenciaSQLBanco += ", cnumdocu as [Número Doc.] "; //02
            _G_Str_SentenciaSQLBanco += ", '' as [Comprobante] "; //03
            _G_Str_SentenciaSQLBanco += ", cconcepto as [Concepto] "; //04
            _G_Str_SentenciaSQLBanco += ", cname as [Tipo de Operación] "; //05
            _G_Str_SentenciaSQLBanco += ", dbo.Fnc_Formatear(cmontomov) AS Monto "; //06
            _G_Str_SentenciaSQLBanco += ", cdispband "; //07
            _G_Str_SentenciaSQLBanco += ", cdispbanc "; //08
            _G_Str_SentenciaSQLBanco += ", cdebe as ctotdebe "; //09
            _G_Str_SentenciaSQLBanco += ", chaber as ctothaber"; //10
            _G_Str_SentenciaSQLBanco += ", 0 AS cidedetalleconciliacion "; //11
            _G_Str_SentenciaSQLBanco += ", 0 as cidcomprob "; //12
            _G_Str_SentenciaSQLBanco += ", 0 as corder "; //13
            _G_Str_SentenciaSQLBanco += ", 0 as estado "; //14
            _G_Str_SentenciaSQLBanco += ", '' as estadodescripcion "; //15
            _G_Str_SentenciaSQLBanco += ", 0 as cconciliado "; //16
            _G_Str_SentenciaSQLBanco += ", '' as ccount_ajustar "; //17
            _G_Str_SentenciaSQLBanco += ", '' as cGeneraAjustesAutomaticos "; //18
            _G_Str_SentenciaSQLBanco += ", 0 as cconciliadoAutomaticamente "; //19
            _G_Str_SentenciaSQLBanco += ", '' as coperbancseleccionado "; //20
            _G_Str_SentenciaSQLBanco += ", 0 as ciddisponibilidad "; //21
            _G_Str_SentenciaSQLBanco += ", 0 as ciddetalleconciliacion "; //22
            _G_Str_SentenciaSQLBanco += ", 0 as ctiporegistro "; //23
            _G_Str_SentenciaSQLBanco += ", '' as [Cuenta Contable] "; //24
            _G_Str_SentenciaSQLBanco += ", cdatemovi as [Fecha] "; //25
            _G_Str_SentenciaSQLBanco += ", 0 as [ctipoajuste] "; //26
            _G_Str_SentenciaSQLBanco += "FROM VST_BANCONOCONCILIADO WHERE 1=0";

            //Consulto
            var _Ds_InicializarGrids = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQLBanco);

            //Cargo la Consulta en los grid
            _Dtg_ConciliarBancoLibro.DataSource = _Ds_InicializarGrids.Tables[0];
            _Dtg_BancoNoConciliados.DataSource = _Ds_InicializarGrids.Tables[0];
            _Dtg_MayorAnalitico.DataSource = _Ds_InicializarGrids.Tables[0];


            //Ocultamos las columnasinternas
            _Dtg_ConciliarBancoLibro.Columns[7].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[8].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[9].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[10].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[11].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[12].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[13].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[14].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[15].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[16].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[17].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[18].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[19].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[20].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[21].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[22].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[23].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[24].Visible = false;
            //_Dtg_ConciliarBancoLibro.Columns[25].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[26].Visible = false;

            _Dtg_ConciliarBancoLibro.ReadOnly = true;

            _Cmb_BancoDetalle.SelectedIndex = 0;
            _Cmb_CuentaDetalle.DataSource = null;
            _Cmb_CuentaDetalle.Enabled = false;
            _Cmb_BancoDetalle.Enabled = true;
            _Btn_IniciarProceso.Enabled = false;
            _G_Int_Paso = 1;
            _Tab_PasosConciliacion.SelectedIndex = 0;
            _G_Bol_ModoConsulta = false;
            _G_Bol_ModoReporte = false;
            _Txt_SaldoInicialBanco.Text = "";
            _Txt_MontoDisponible.Text = "";
            _Txt_TotalDocumentosSeleccionados_Libro.Text = "";
            _Txt_TotalDocumentosSeleccionados_Banco.Text = "";
            _G_Bol_ModoGuardar = true;
            _G_Bol_Impreso = false;
            _G_Str_cdispbanc = "";
            _G_Str_cbanco = "";
            _G_Str_cnumcuenta = "";
            _Lbl_NumeroDeUltimaConciliacion.Text = "";
            _Txt_MontoDiferido.Text = "";
            _Txt_MontoDisponible.Text = "";
            _Txt_SaldoReal.Text = "";
            ((Frm_Padre) Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
        }

        private void _Tab_Contenedor_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                if (_G_Bol_ModoGuardar)
                {
                    if (MessageBox.Show("Está seguro de volver a la consulta se perderá la información ya cargada en la presente Disponibilidad?", "Información", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
                        DialogResult.OK)
                    {
                        _G_Bol_ModoGuardar = false;
                        _G_Bol_ModoConsulta = true;
                    }
                }
                e.Cancel = !_G_Bol_ModoConsulta;
            }
            if (e.TabPageIndex == 1)
            {
                e.Cancel = !_G_Bol_ModoGuardar;
            }
            else if (e.TabPageIndex == 2)
            {
                e.Cancel = !_G_Bol_ModoReporte;
            }
            else
            {

            }
        }

        private void _Cmb_BancoDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_BancoDetalle.SelectedValue != null)
            {
                _Mtd_CargarCuentaConsultas(_Cmb_BancoDetalle.SelectedValue.ToString(), _Cmb_CuentaDetalle);
            }
        }

        private bool HayDescripcionesVaciasEstadosDisponibilidad()
        {
            string _Str_Sql =
                "SELECT isnull(cdescrip_dispbanc,'') as cdescrip_dispbanc " +
                "FROM TESTADOSCONC " +
                "WHERE isnull(cdescrip_dispbanc,'') = ''";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        private void _Btn_IniciarProceso_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //Validaciones previas de los datos para arrancar el proceso

            //Validacion de existencia de conciliacion
            if (!_G_Bol_ExisteConciliacion)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("No existe Conciliación para el banco y cuenta seleccionado, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //Validacion del Estado de Cuenta
            if (!_Cls_RutinasConciliacion._Mtd_ExisteEstadoDeCuentaPorConciliar(_Cmb_BancoDetalle.SelectedValue.ToString(), _Cmb_CuentaDetalle.SelectedValue.ToString(),_Cls_RutinasConciliacion._TipoEstadoDeCuenta.Disponibilidad))
            {
                Cursor = Cursors.Default;
                MessageBox.Show("No existe un estado de cuenta cargado para el banco y cuenta seleccionado, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //Verifico que haya seleccionado un banco y una  cuenta
            if (_Cmb_BancoDetalle.SelectedIndex > 0 && _Cmb_CuentaDetalle.SelectedIndex > 0)
            {
                Cursor = Cursors.WaitCursor;
                //Inicia el proceso
                //Cargo los Saldos
                _Mtd_MostrarSaldosEstadoDeCuenta();
                _Mtd_LlenarBancoLibroNoConciliado();
                _Mtd_ObtenerEstadoDeCuentaAUsar();
                _Cmb_BancoDetalle.Enabled = false;
                _Cmb_CuentaDetalle.Enabled = false;
                _Btn_IniciarProceso.Enabled = false;
                _Tab_PasosConciliacion.Enabled = true;
                //Desactivo los botones
                _Btn_Siguiente.Enabled = false;
                _Btn_ConciliarManualmente.Enabled = false;
                _Btn_DesConciliarManualmente.Enabled = false;
                _Btn_FiltrarGrid.Enabled = false;
                _Btn_BorrarFiltro.Enabled = false;
                _Txt_NumeroDocumentoAFiltrar.Enabled = false;
                Cursor = Cursors.WaitCursor;
                //Concilio automaticamente
                _Mtd_ConciliarAutomaticamente();
                _Mtd_OrdenadoPorDefecto();
                _Mtd_ColorGridConciliado();
                //Quito la ordenacion
                _Mtd_QuitarOrdenamientoGridBancoLibro();
                //Activo los botones
                _Btn_Siguiente.Enabled = true;
                _Btn_ConciliarManualmente.Enabled = true;
                _Btn_DesConciliarManualmente.Enabled = true;
                _Btn_FiltrarGrid.Enabled = true;
                _Btn_BorrarFiltro.Enabled = true;
                _Txt_NumeroDocumentoAFiltrar.Enabled = true;
                Cursor = Cursors.Default;
            }
            Cursor = Cursors.Default;
        }

        private void _Mtd_LlenarEtiquetaInformativa()
        {
            string _Str_Id = "";
            var _Str_Etiqueta = "";
            _G_Str_SentenciaSql = "SELECT MAX(cidconciliacion) as cidconciliacion FROM TCONCILIACION WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CBANCO='" + _Cmb_BancoDetalle.SelectedValue.ToString() + "' AND CNUMCUENTA='" + _Cmb_CuentaDetalle.SelectedValue.ToString() + "' AND cfinalizado=1";
            _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);
            foreach (DataRow _Dtw_Item in _G_Ds_DataSet.Tables[0].Rows)
            {
                _Str_Id = _Dtw_Item["cidconciliacion"].ToString();
                _G_Int_cidconciliacion = Convert.ToInt32(_Dtw_Item["cidconciliacion"].ToString());
            }
            if (_Str_Id.Length > 0)
            {
                _Str_Etiqueta = "#" + _Str_Id + " ";
                _G_Bol_ExisteConciliacion = true;
            }
            else
            {
                _Str_Etiqueta = "NO EXISTE";
                _G_Bol_ExisteConciliacion = false;
                _G_Int_cidconciliacion = 0;
            }
            //Fecha
            _Lbl_NumeroDeUltimaConciliacion.Text = _Str_Etiqueta;
            _Lbl_LibroNoConciliado.Text = "MAYOR ANALÍTICO APLICADO EN LA CONCILIACIÓN #" + _Str_Id + " ";
        }

        private void _Mtd_ObtenerDatosConciliacion(int _P_Int_cidconciliacion, out DateTime _P_Dt_FechaDesde, out DateTime _P_Dt_FechaHasta)
        {
            _G_Str_SentenciaSql = "SELECT cidconciliacion,CONVERT(VARCHAR,TCONCILIACION.cfechadesde,103) AS [FechaDesde], CONVERT(VARCHAR,TCONCILIACION.cfechahasta,103) AS [FechaHasta], cbanco, cnumcuenta FROM TCONCILIACION WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' and cidconciliacion = '" + _P_Int_cidconciliacion + "'";
            var _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);

            var _Dt_FechaDesde = Convert.ToDateTime(_Ds_DataSet.Tables[0].Rows[0]["FechaDesde"]);
            var _Dt_FechaHasta = Convert.ToDateTime(_Ds_DataSet.Tables[0].Rows[0]["FechaHasta"]);

            _P_Dt_FechaDesde = _Dt_FechaDesde;
            _P_Dt_FechaHasta = _Dt_FechaHasta;
        }
        private string _Mtd_Obtener_cdispbanc_EstadoDeCuenta(string pcbanco, string pcnumcuenta)
        {
            var _Str_Sql = "SELECT max(cdispbanc) as cdispbanc FROM TEDOCUENTADISPM WHERE ccompany = '" + Frm_Padre._Str_Comp + "' AND cbanco = '" + pcbanco + "' AND cnumcuenta = '" + pcnumcuenta + "' AND cdelete = 0 AND cconciliado = 0 and cregistroinicial = 0";
            var _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
            {
                return _Ds_DataSet.Tables[0].Rows[0][0].ToString();
            }
            return "";
        }

        private string _Mtd_Obtener_cestadoid_ChequesPendientes()
        {
            var _Str_Sql = "SELECT cestadoidcheqpendiente FROM TCONFIGCONCILIACION";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString();
            }
            return "";
        }

        private void _Mtd_LlenarBancoLibroNoConciliado()
        {
            string _G_Str_SentenciaSQL = "";

            Cursor = Cursors.WaitCursor;

            //Obtenemos los datos necesarios para la consulta
            _G_Str_cestadoid = _Mtd_Obtener_cestadoid_ChequesPendientes();

            //Valores para filtra la consulta
            //Banco
            var _Str_cdispbanc = _Mtd_Obtener_cdispbanc_EstadoDeCuenta(_Cmb_BancoDetalle.SelectedValue.ToString(), _Cmb_CuentaDetalle.SelectedValue.ToString());
            if (_Str_cdispbanc != "") _G_Int_cdispbanc = Convert.ToInt32(_Str_cdispbanc);

            //Libro
            DateTime _Dt_FechaDesde = new DateTime();
            DateTime _Dt_FechaHasta = new DateTime();
            _Mtd_ObtenerDatosConciliacion(_G_Int_cidconciliacion, out _Dt_FechaDesde, out _Dt_FechaHasta);

            //Mayor Analitico



            //Inicializo el contador interno de conciliaciones atomicas
            _G_Int_Ciddetalleconciliacion = 0;

            _G_Ds_EstadosBanco = new DataSet();
            _G_Ds_EstadosLibro = new DataSet();
            _G_Ds_BancoLibro = new DataSet();

            //Fecha hasta para los registros de libro
             //var _Dt_Hasta = new DateTime(_Dtp_Hasta.Value.Year, _Dtp_Hasta.Value.Month, _Dtp_Hasta.Value.Day);

            //Genero la Consulta de los registro de disponibilidad
            _G_Str_SentenciaSQL = "SELECT * ";
            _G_Str_SentenciaSQL += "FROM VST_DISPONIBILIDAD ";
            _G_Str_SentenciaSQL += "WHERE ";
            _G_Str_SentenciaSQL += "CCOMPANY='" + Frm_Padre._Str_Comp + "' ";
            _G_Str_SentenciaSQL += "AND CBANCO='" + _Cmb_BancoDetalle.SelectedValue.ToString() + "' ";
            _G_Str_SentenciaSQL += "AND CNUMCUENTA='" + _Cmb_CuentaDetalle.SelectedValue.ToString() + "' ";
            
            _G_Str_SentenciaSQL += "AND ( ";

            //BANCO
            _G_Str_SentenciaSQL += "( ";
            _G_Str_SentenciaSQL += "[Tip.Reg.]='BANCO' ";
            _G_Str_SentenciaSQL += "AND ";
            _G_Str_SentenciaSQL += "cdispbanc='" + _Str_cdispbanc + "'";
            _G_Str_SentenciaSQL += ") ";

            //OR
            _G_Str_SentenciaSQL += "OR ";

            //LIBRO
            _G_Str_SentenciaSQL += "( ";
            _G_Str_SentenciaSQL += "[Tip.Reg.]='LIBRO' ";
            _G_Str_SentenciaSQL += "AND ";
            _G_Str_SentenciaSQL += "cidconciliacion = '" + _G_Int_cidconciliacion + "'";
            _G_Str_SentenciaSQL += "AND ";
            _G_Str_SentenciaSQL += "cestadoid <> '-1'";
            _G_Str_SentenciaSQL += ")";

            //OR
            _G_Str_SentenciaSQL += "OR ";

            //MAYOR ANALITICO
            _G_Str_SentenciaSQL += "( ";
            _G_Str_SentenciaSQL += "[Tip.Reg.]='LIBRO' ";
            _G_Str_SentenciaSQL += "AND ";
            _G_Str_SentenciaSQL += "cestadoid = '-1'";
            _G_Str_SentenciaSQL += "AND ";
            _G_Str_SentenciaSQL += "cidconciliacion = '" + _G_Int_cidconciliacion + "'";
            _G_Str_SentenciaSQL += "AND ";
            _G_Str_SentenciaSQL += "cregdate >= CONVERT(DATETIME, '" + _Dt_FechaDesde.ToShortDateString() + "')";
            _G_Str_SentenciaSQL += "AND ";
            _G_Str_SentenciaSQL += "cregdate <= CONVERT(DATETIME, '" + _Dt_FechaHasta.ToShortDateString() + "')";
            _G_Str_SentenciaSQL += ")";

            _G_Str_SentenciaSQL += ")";

            //Instancio el DataSet Internos
            _G_Ds_BancoLibro = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);

            //Pasamos los datos al grid solo los registro que correspondel al estado de cheques pendientes
            _G_Dtv_RegistrosChequesPendientes = new DataView(_G_Ds_BancoLibro.Tables[0], "((cestadoid=" + _G_Str_cestadoid + ") AND ([Tip.Reg.]='LIBRO')) OR ([Tip.Reg.]='BANCO')", "Monto", DataViewRowState.OriginalRows);
            _Dtg_ConciliarBancoLibro.DataSource = _G_Dtv_RegistrosChequesPendientes;

            //Formateamos la Columna
            _Dtg_ConciliarBancoLibro.Columns["Monto"].DefaultCellStyle.Format = "#,##0.00";

            //Configuramos los anchos de cada columna
            _Dtg_ConciliarBancoLibro.Columns[0].Width = 20;
            _Dtg_ConciliarBancoLibro.Columns[1].Width = 50;
            //_Dtg_ConciliarBancoLibro.Columns[2].Width = 80;
            //_Dtg_ConciliarBancoLibro.Columns[3].Width = 120;
            _Dtg_ConciliarBancoLibro.Columns[4].Width = 250;
            _Dtg_ConciliarBancoLibro.Columns[5].Width = 110;
            _Dtg_ConciliarBancoLibro.Columns[6].Width = 110;

            _Dtg_ConciliarBancoLibro.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            _Dtg_ConciliarBancoLibro.Columns[25].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            _Dtg_ConciliarBancoLibro.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            _Dtg_ConciliarBancoLibro.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _Dtg_ConciliarBancoLibro.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Ocultamos las columnasinternas
            _Dtg_ConciliarBancoLibro.Columns[7].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[8].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[9].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[10].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[11].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[12].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[13].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[14].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[15].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[16].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[17].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[18].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[19].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[20].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[21].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[22].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[23].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[24].Visible = false;
            //_Dtg_ConciliarBancoLibro.Columns[25].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[26].Visible = false;

            _Dtg_ConciliarBancoLibro.Columns[27].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[28].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[29].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[30].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[31].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[32].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[33].Visible = false;

            _Dtg_ConciliarBancoLibro.Columns[34].Visible = false;
            _Dtg_ConciliarBancoLibro.Columns[35].Visible = false;


            if (_Dtg_ConciliarBancoLibro.Rows.Count > 0)
            {
                _G_ColorInicialGrid = _Dtg_ConciliarBancoLibro.Rows[0].DefaultCellStyle.BackColor;
            }

            //Ordenamos las columnas visibles
            _Dtg_ConciliarBancoLibro.Columns["BancoConChecked"].DisplayIndex = 0;
            _Dtg_ConciliarBancoLibro.Columns["Tip.Reg."].DisplayIndex = 1;
            _Dtg_ConciliarBancoLibro.Columns["Fecha"].DisplayIndex = 2;
            _Dtg_ConciliarBancoLibro.Columns["Número Doc."].DisplayIndex = 3;
            _Dtg_ConciliarBancoLibro.Columns["Comprobante"].DisplayIndex = 4;
            _Dtg_ConciliarBancoLibro.Columns["Concepto"].DisplayIndex = 5;
            _Dtg_ConciliarBancoLibro.Columns["Tipo de Operación"].DisplayIndex = 6;
            _Dtg_ConciliarBancoLibro.Columns["Monto"].DisplayIndex = 7;

            //Cargamos los Estados
            _G_Str_SentenciaSql = "SELECT * FROM TESTADOSOPERB WHERE CCOMPANY = '" + Frm_Padre._Str_Comp + "' AND CBANCO = '" + _Cmb_BancoDetalle.SelectedValue.ToString() + "' ";
            _G_Ds_EstadosBanco = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);
            _G_Str_SentenciaSql = "SELECT * FROM TESTADOSOPERL";
            _G_Ds_EstadosLibro = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);

            Cursor = Cursors.Default;
        }

        private void _Mtd_CargarBancoNoConciliado()
        {
            //Cargamos el DataSource
            var _BancoNoConciliado = _G_Ds_BancoLibro.Tables[0].Select("cconciliado=0").Where(x => x["Tip.Reg."].ToString().ToUpper() == "BANCO");
            var _Rows = _BancoNoConciliado as IList<DataRow> ?? _BancoNoConciliado.ToList();
            if (_Rows.Any())
                _G_Dt_BancoNoConciliado = _Rows.CopyToDataTable();
            //Seteamos los estados
            _Mtd_SetearBancoNoConciliados();
            //Ordenamos
            _Mtd_OrdenarBancoNoConciliado();
            //Mostramos
            _Mtd_MostrarBancoNoConciliados();
            //Seteamos los Combos
            _Mtd_SetearCombosBancoNoConciliado();
            //Coloreamos
            _Mtd_ColorearBancoNoConciliados();
        }

        private void _Mtd_MostrarBancoNoConciliados()
        {
            try
            {
                //Inicializamos el Grid
                _Dtg_BancoNoConciliados.DataSource = null;
                _Dtg_BancoNoConciliados.Rows.Clear();
                _Dtg_BancoNoConciliados.Columns.Clear();

                //Cargamos la Columna  de Combo
                DataGridViewComboBoxColumn oComboEstadoBanco = new DataGridViewComboBoxColumn();
                oComboEstadoBanco.HeaderText = "Estado";
                oComboEstadoBanco.Name = "estadoelegirbanco";
                oComboEstadoBanco.Width = 300;
                _Dtg_BancoNoConciliados.Columns.Add(oComboEstadoBanco);

                //Cargamos el grid
                _Dtg_BancoNoConciliados.DataSource = _G_Dt_BancoNoConciliado;

                //Ocultamos las columnas innecesarias
                _Dtg_BancoNoConciliados.Columns["cseleccionado"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["Tip.Reg."].Visible = false;
                _Dtg_BancoNoConciliados.Columns["Número Doc."].Visible = true;
                _Dtg_BancoNoConciliados.Columns["Comprobante"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["Concepto"].Visible = true;
                _Dtg_BancoNoConciliados.Columns["Tipo de Operación"].Visible = true;
                _Dtg_BancoNoConciliados.Columns["Monto"].Visible = true;
                _Dtg_BancoNoConciliados.Columns["cdispband"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["cdispbanc"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["ctotdebe"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["ctothaber"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["cidedetalleconciliacion"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["cidcomprob"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["corder"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["estado"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["estadodescripcion"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["cconciliado"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["ccount_ajustar"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["cGeneraAjustesAutomaticos"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["cconciliadoAutomaticamente"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["coperbancseleccionado"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["ciddisponibilidad"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["ciddetalleconciliacion"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["ctiporegistro"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["Cuenta Contable"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["ctipoajuste"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["cregdate"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["ccompany"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["cbanco"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["cnumcuenta"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["cidconciliaciondmanual"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["cestadoid"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["cidconciliacion"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["centregado"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["centregado_descripcion"].Visible = false;

                //Ordenamos las columnas visibles
                //_Dtg_BancoNoConciliados.Columns["Id"].DisplayIndex = 0;
                _Dtg_BancoNoConciliados.Columns["Tipo de Operación"].DisplayIndex = 1;
                _Dtg_BancoNoConciliados.Columns["Fecha"].DisplayIndex = 2;
                _Dtg_BancoNoConciliados.Columns["Número Doc."].DisplayIndex = 3;
                _Dtg_BancoNoConciliados.Columns["Concepto"].DisplayIndex = 4;
                _Dtg_BancoNoConciliados.Columns["Monto"].DisplayIndex = 5;
                _Dtg_BancoNoConciliados.Columns["estadoelegirbanco"].DisplayIndex = 6;

                //Configuro los tamaños de las columnas
                _Dtg_BancoNoConciliados.Columns["Tipo de Operación"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                _Dtg_BancoNoConciliados.Columns["Número Doc."].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                _Dtg_BancoNoConciliados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                //Configuro los alineamientos de las columnas
                _Dtg_BancoNoConciliados.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //Formateamos la Columna
                _Dtg_BancoNoConciliados.Columns["Monto"].DefaultCellStyle.Format = "#,##0.00";


                //Ponemos el solo lectura
                _Dtg_BancoNoConciliados.Columns["Tip.Reg."].ReadOnly = true;
                _Dtg_BancoNoConciliados.Columns["Número Doc."].ReadOnly = true;
                _Dtg_BancoNoConciliados.Columns["Comprobante"].ReadOnly = true;
                _Dtg_BancoNoConciliados.Columns["Concepto"].ReadOnly = true;
                _Dtg_BancoNoConciliados.Columns["Tipo de Operación"].ReadOnly = true;
                _Dtg_BancoNoConciliados.Columns["Monto"].ReadOnly = true;

                //Asigno las caracteristicas del combo
                ((DataGridViewComboBoxColumn) _Dtg_BancoNoConciliados.Columns["estadoelegirbanco"]).AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                ((DataGridViewComboBoxColumn) _Dtg_BancoNoConciliados.Columns["estadoelegirbanco"]).DataSource = _Mtd_LlenarEstadoBanco();
                ((DataGridViewComboBoxColumn) _Dtg_BancoNoConciliados.Columns["estadoelegirbanco"]).DisplayMember = "Display";
                ((DataGridViewComboBoxColumn) _Dtg_BancoNoConciliados.Columns["estadoelegirbanco"]).ValueMember = "Value";
                ((DataGridViewComboBoxColumn) _Dtg_BancoNoConciliados.Columns["estadoelegirbanco"]).Width = 300;

            }
            catch (Exception oException)
            {
            }
        }

        private void _Mtd_SetearBancoNoConciliados()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                //Cargo los estados
                string _Str_SentenciaSQL = "SELECT * FROM TESTADOSOPERB WHERE CCOMPANY = '" + Frm_Padre._Str_Comp + "' AND CBANCO = '" + _Cmb_BancoDetalle.SelectedValue.ToString() + "' ";
                _G_Ds_EstadosBanco = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);

                //Obtengo los estados y lo guardo en el datatable
                foreach (DataRow _Fila in _G_Dt_BancoNoConciliado.Rows)
                {
                    //Obtengo los valores
                    var _Str_ccompany = Frm_Padre._Str_Comp;
                    var _Str_cdispbanc = _Fila["cdispbanc"].ToString();
                    var _Str_cdispband = _Fila["cdispband"].ToString();
                    var _Str_cbanco = _Cmb_BancoDetalle.SelectedValue.ToString();
                    var _Str_cnumcuenta = _Cmb_CuentaDetalle.SelectedValue.ToString();

                    //Obtenemos el estado que le fue asignado al registro en la conciliacion cargada
                    string _cestadoid_asignado = Obtener_cestadoid_AsignadoEnConciliacion_Banco(_Str_ccompany, _G_Int_cidconciliacion, _Str_cdispbanc, _Str_cdispband);

                    //Obtenemos el estado que corresponda
                    var _cestadoid = "";
                    _cestadoid = _cestadoid_asignado != "" ? _cestadoid_asignado : Obtener_cestadoid_Banco(_Str_ccompany, _Str_cdispband, _Str_cdispbanc, _Str_cbanco, _Str_cnumcuenta);

                    //Verifico
                    if (_cestadoid != "")
                    {
                        //Actualizamos el DataTable que se usa para mostrar el grid
                        _Fila["estado"] = _cestadoid;

                        //Actualizamos el DataSet Unificado
                        var _RegistroBanco = _G_Ds_BancoLibro.Tables[0]
                            .AsEnumerable()
                            .SingleOrDefault(x =>
                                             x["cdispband"].ToString() == _Str_cdispband
                                             && x["cdispbanc"].ToString() == _Str_cdispbanc
                            );
                        if (_RegistroBanco != null)
                        {
                            var _Int_IndexBanco = _G_Ds_BancoLibro.Tables[0].Rows.IndexOf(_RegistroBanco);
                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco]["estado"] = _cestadoid;
                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco].AcceptChanges();
                        }
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception oException)
            {
                Cursor = Cursors.Default;
            }
        }

        private void _Mtd_SetearCombosBancoNoConciliado()
        {
            _G_EstamosSeteandoCombos = true;
            //Selecciono cada combo en función a la tabla de estados
            foreach (DataGridViewRow _Fila in _Dtg_BancoNoConciliados.Rows)
            {
                //Obtengo los valores
                string _cestadoid = _Fila.Cells["estado"].Value.ToString();
                //Verifico
                if (_cestadoid != "" && _cestadoid != "0")
                {
                    //Obtengo el objeto del combo
                    var _CeldaCombo = (DataGridViewComboBoxCell) _Fila.Cells["estadoelegirbanco"];
                    //Selecciono solo si no esta ya seteado
                    if (_CeldaCombo.Value == null || _CeldaCombo.Value.ToString() == "0")
                    {
                        _CeldaCombo.Value = _cestadoid.ToString();
                    }
                }
                else
                {
                    //Obtengo el objeto del combo
                    var _CeldaCombo = (DataGridViewComboBoxCell) _Fila.Cells["estadoelegirbanco"];
                    //Selecciono solo si no esta ya seteado
                    if (_CeldaCombo != null)
                    {
                        _CeldaCombo.Value = "nulo";
                    }
                }
            }
            _G_EstamosSeteandoCombos = false;
        }

        private void _Mtd_ColorearBancoNoConciliados()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                //Selecciono cada combo en función a la tabla de estados
                foreach (DataGridViewRow _Fila in _Dtg_BancoNoConciliados.Rows)
                {
                    //Obtengo los valores
                    string _cestadoid = _Fila.Cells["estado"].Value.ToString();
                    //Verifico
                    if (_cestadoid != "" && _cestadoid != "0")
                    {
                        //Coloreo
                        _Fila.DefaultCellStyle.BackColor = _G_ColorInicialGrid;
                    }
                    else
                    {
                        //Coloreo
                        _Fila.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception oException)
            {
                Cursor = Cursors.Default;
            }
        }

        private void _Mtd_OrdenarBancoNoConciliado()
        {
            var _Int_CantidadBancoNoConciliado = _G_Dt_BancoNoConciliado.AsEnumerable().OrderBy(o => o.Field<Int32>("estado")).Count();
            if (_Int_CantidadBancoNoConciliado > 0)
                _G_Dt_BancoNoConciliado = _G_Dt_BancoNoConciliado.AsEnumerable().OrderBy(o => o.Field<Int32>("estado")).CopyToDataTable(); ;
        }

        private void _Mtd_CargarMayorAnalitico()
        {
            //Cargamos el DataSource
            var _MayorAnalitico = _G_Ds_BancoLibro.Tables[0].AsEnumerable().Where(x => x["Tip.Reg."].ToString().ToUpper() == "LIBRO" && 
                                                                                     x["cidconciliacion"].ToString() == _G_Int_cidconciliacion.ToString(CultureInfo.InvariantCulture) &&
                                                                                     x["cestadoid"].ToString().ToUpper() == "-1"
                                                                                     );
            var _Rows = _MayorAnalitico as IList<DataRow> ?? _MayorAnalitico.ToList();
            if (_Rows.Any())
                _G_Dt_MayorAnalitico = _Rows.CopyToDataTable();
            //Seteamos los estados
            _Mtd_SetearMayorAnalitico();
            //Ordenamos
            _Mtd_OrdenarMayorAnalitico();
            //Mostramos
            _Mtd_MostrarMayorAnalitico();
            //Seteamos los Combos
            _Mtd_SetearCombosMayorAnalitico();
            //Coloreamos
            _Mtd_ColorearMayorAnalitico();
        }

        private void _Mtd_MostrarMayorAnalitico()
        {
            try
            {
                //Inicializamos el Grid
                _Dtg_MayorAnalitico.DataSource = null;
                _Dtg_MayorAnalitico.Rows.Clear();
                _Dtg_MayorAnalitico.Columns.Clear();

                //Cargamos la Columna  de Combo
                DataGridViewComboBoxColumn oComboEstadoLibro = new DataGridViewComboBoxColumn();
                oComboEstadoLibro.HeaderText = "Estado";
                oComboEstadoLibro.Name = "comboestadolibro";
                oComboEstadoLibro.Width = 300;
                _Dtg_MayorAnalitico.Columns.Add(oComboEstadoLibro);

                //Cargamos el grid
                _Dtg_MayorAnalitico.DataSource = _G_Dt_MayorAnalitico;

                //Ocultamos las columnas innecesarias
                _Dtg_MayorAnalitico.Columns["cseleccionado"].Visible = false;
                _Dtg_MayorAnalitico.Columns["cseleccionado"].Visible = false;
                _Dtg_MayorAnalitico.Columns["Tip.Reg."].Visible = false;
                _Dtg_MayorAnalitico.Columns["Número Doc."].Visible = true;
                _Dtg_MayorAnalitico.Columns["Comprobante"].Visible = true;
                _Dtg_MayorAnalitico.Columns["Concepto"].Visible = true;
                _Dtg_MayorAnalitico.Columns["Tipo de Operación"].Visible = false;
                _Dtg_MayorAnalitico.Columns["Monto"].Visible = true;
                _Dtg_MayorAnalitico.Columns["cdispband"].Visible = false;
                _Dtg_MayorAnalitico.Columns["cdispbanc"].Visible = false;
                _Dtg_MayorAnalitico.Columns["ctotdebe"].Visible = false;
                _Dtg_MayorAnalitico.Columns["ctothaber"].Visible = false;
                _Dtg_MayorAnalitico.Columns["cidedetalleconciliacion"].Visible = false;
                _Dtg_MayorAnalitico.Columns["cidcomprob"].Visible = false;
                _Dtg_MayorAnalitico.Columns["corder"].Visible = false;
                _Dtg_MayorAnalitico.Columns["estado"].Visible = false;
                _Dtg_MayorAnalitico.Columns["estadodescripcion"].Visible = false;
                _Dtg_MayorAnalitico.Columns["cconciliado"].Visible = false;
                _Dtg_MayorAnalitico.Columns["ccount_ajustar"].Visible = false;
                _Dtg_MayorAnalitico.Columns["cGeneraAjustesAutomaticos"].Visible = false;
                _Dtg_MayorAnalitico.Columns["cconciliadoAutomaticamente"].Visible = false;
                _Dtg_MayorAnalitico.Columns["coperbancseleccionado"].Visible = false;
                _Dtg_MayorAnalitico.Columns["ciddisponibilidad"].Visible = false;
                _Dtg_MayorAnalitico.Columns["ciddetalleconciliacion"].Visible = false;
                _Dtg_MayorAnalitico.Columns["ctiporegistro"].Visible = false;
                _Dtg_MayorAnalitico.Columns["Cuenta Contable"].Visible = false;
                _Dtg_MayorAnalitico.Columns["ctipoajuste"].Visible = false;
                _Dtg_MayorAnalitico.Columns["cregdate"].Visible = false;
                _Dtg_MayorAnalitico.Columns["ccompany"].Visible = false;
                _Dtg_MayorAnalitico.Columns["cbanco"].Visible = false;
                _Dtg_MayorAnalitico.Columns["cnumcuenta"].Visible = false;
                _Dtg_MayorAnalitico.Columns["cidconciliaciondmanual"].Visible = false;
                _Dtg_MayorAnalitico.Columns["centregado"].Visible = false;
                _Dtg_MayorAnalitico.Columns["centregado_descripcion"].Visible = false;

                //Ordenamos las columnas visibles
                _Dtg_MayorAnalitico.Columns["Comprobante"].DisplayIndex = 0;
                _Dtg_MayorAnalitico.Columns["Concepto"].DisplayIndex = 1;
                _Dtg_MayorAnalitico.Columns["Fecha"].DisplayIndex = 2;
                _Dtg_MayorAnalitico.Columns["Número Doc."].DisplayIndex = 3;
                _Dtg_MayorAnalitico.Columns["Monto"].DisplayIndex = 4;
                _Dtg_MayorAnalitico.Columns["comboestadolibro"].DisplayIndex = 5;
                _Dtg_MayorAnalitico.Columns["cestadoid"].Visible = false;
                _Dtg_MayorAnalitico.Columns["cidconciliacion"].Visible = false;

                //Configuro los tamaños de las columnas
                _Dtg_MayorAnalitico.Columns["Concepto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                _Dtg_MayorAnalitico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                //Configuro los alineamientos de las columnas
                _Dtg_MayorAnalitico.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //Formateamos la Columna
                _Dtg_MayorAnalitico.Columns["Monto"].DefaultCellStyle.Format = "#,##0.00";


                //Ponemos el solo lectura
                _Dtg_MayorAnalitico.Columns["Tip.Reg."].ReadOnly = true;
                _Dtg_MayorAnalitico.Columns["Número Doc."].ReadOnly = true;
                _Dtg_MayorAnalitico.Columns["Comprobante"].ReadOnly = true;
                _Dtg_MayorAnalitico.Columns["Concepto"].ReadOnly = true;
                _Dtg_MayorAnalitico.Columns["Tipo de Operación"].ReadOnly = true;
                _Dtg_MayorAnalitico.Columns["Monto"].ReadOnly = true;
                _Dtg_MayorAnalitico.Columns["Fecha"].ReadOnly = true;


                //Asigno las caracteristicas del combo
                ((DataGridViewComboBoxColumn) _Dtg_MayorAnalitico.Columns["comboestadolibro"]).AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                ((DataGridViewComboBoxColumn) _Dtg_MayorAnalitico.Columns["comboestadolibro"]).DataSource = _Mtd_LlenarEstadoLibro();
                ((DataGridViewComboBoxColumn) _Dtg_MayorAnalitico.Columns["comboestadolibro"]).DisplayMember = "Display";
                ((DataGridViewComboBoxColumn) _Dtg_MayorAnalitico.Columns["comboestadolibro"]).ValueMember = "Value";
                ((DataGridViewComboBoxColumn) _Dtg_MayorAnalitico.Columns["comboestadolibro"]).Width = 300;

            }
            catch (Exception oException)
            {
            }
        }

        private void _Mtd_SetearMayorAnalitico()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                //Cargo los estados
                string _Str_SentenciaSQL = "SELECT * FROM TESTADOSOPERL";
                _G_Ds_EstadosLibro = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);

                //Obtengo los estados y lo guardo en el datatable
                foreach (DataRow _Fila in _G_Dt_MayorAnalitico.Rows)
                {
                    //Obtengo los valores
                    var _Str_ccompany = Frm_Padre._Str_Comp;
                    var _Str_cidcomprob = _Fila["cidcomprob"].ToString();
                    var _Str_corder = _Fila["corder"].ToString();

                    //Obtenemos el estado que le fue asignado al registro en la conciliacion cargada
                    string _cestadoid_asignado = Obtener_cestadoid_AsignadoEnConciliacion_Libro(_Str_ccompany, _G_Int_cidconciliacion, _Str_cidcomprob, _Str_corder);

                    //Obtenemos el estado que corresponda
                    var _cestadoid = "";
                    _cestadoid = _cestadoid_asignado != "" ? _cestadoid_asignado : Obtener_cestadoid_Libro(_Str_ccompany, _Str_cidcomprob, _Str_corder);
                    
                    //Verifico
                    if (_cestadoid != "")
                    {
                        //Actualizamos el DataTable que se usa para mostrar el grid
                        _Fila["estado"] = _cestadoid;

                        //Actualizamos el DataSet Unificado
                        var _RegistroLibro = _G_Ds_BancoLibro.Tables[0]
                            .AsEnumerable()
                            .SingleOrDefault(x =>
                                             x["cidcomprob"].ToString() == _Str_cidcomprob
                                             && x["corder"].ToString() == _Str_corder
                                             && x["cidconciliacion"].ToString() == _G_Int_cidconciliacion.ToString(CultureInfo.InvariantCulture)
                                             && x["cestadoid"].ToString() == "-1"
                                             && x["Tip.Reg."].ToString() == "LIBRO"
                            );
                        if (_RegistroLibro != null)
                        {
                            var _Int_IndexLibro = _G_Ds_BancoLibro.Tables[0].Rows.IndexOf(_RegistroLibro);
                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro]["estado"] = _cestadoid;
                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro].AcceptChanges();
                        }
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception oException)
            {
                Cursor = Cursors.Default;
            }
        }

        private void _Mtd_SetearCombosMayorAnalitico()
        {
            _G_EstamosSeteandoCombos = true;
            //Selecciono cada combo en función a la tabla de estados
            foreach (DataGridViewRow _Fila in _Dtg_MayorAnalitico.Rows)
            {
                //Obtengo los valores
                string _cestadoid = _Fila.Cells["estado"].Value.ToString();
                //Verifico
                if (_cestadoid != "" && _cestadoid != "0")
                {
                    //Obtengo el objeto del combo
                    var _CeldaCombo = (DataGridViewComboBoxCell) _Fila.Cells["comboestadolibro"];
                    //Selecciono solo si no esta ya seteado
                    if (_CeldaCombo.Value == null || _CeldaCombo.Value.ToString() == "0")
                    {
                        _CeldaCombo.Value = _cestadoid.ToString();
                    }
                }
                else
                {
                    //Obtengo el objeto del combo
                    var _CeldaCombo = (DataGridViewComboBoxCell) _Fila.Cells["comboestadolibro"];
                    //Selecciono solo si no esta ya seteado
                    if (_CeldaCombo != null)
                    {
                        _CeldaCombo.Value = "nulo";
                    }
                }
            }
            _G_EstamosSeteandoCombos = false;
        }

        private void _Mtd_ColorearMayorAnalitico()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                //Selecciono cada combo en función a la tabla de estados
                foreach (DataGridViewRow _Fila in _Dtg_MayorAnalitico.Rows)
                {
                    //Obtengo los valores
                    string _cestadoid = _Fila.Cells["estado"].Value.ToString();
                    //Verifico
                    if (_cestadoid != "" && _cestadoid != "0")
                    {
                        //Coloreo
                        _Fila.DefaultCellStyle.BackColor = _G_ColorInicialGrid;
                    }
                    else
                    {
                        //Coloreo
                        _Fila.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception oException)
            {
                Cursor = Cursors.Default;
            }
        }

        private void _Mtd_OrdenarMayorAnalitico()
        {
            var _MayorAnalitico = _G_Dt_MayorAnalitico.AsEnumerable().OrderBy(o => o.Field<Int32>("estado"));
            if (_MayorAnalitico.Any())
                _G_Dt_MayorAnalitico = _MayorAnalitico.CopyToDataTable();
        }

        /// <summary>
        /// Devuelveo el cestadoid a seleccionar en el combo
        /// </summary>
        /// <param name="_P_Str_Compania"></param>
        /// <param name="_p_Str_IdComprob"></param>
        /// <param name="_P_Str_Order"></param>
        /// <returns></returns>
        private string Obtener_cestadoid_Libro(string _P_Str_Compania, string _p_Str_IdComprob, string _P_Str_Order)
        {
            string strctypcomp = "";
            string strcdescrip = "";
            string strResultado = "";
            string strSql = "";
            DataSet dsResultados;

            //Seleccionamos de TCOMPROBANC y TCOMPROBAND (el tipo de comprobante y su descripcion)
            strSql =
                "SELECT TCOMPROBANC.ctypcomp, TCOMPROBAND.cdescrip, TCOMPROBANC.cname FROM TCOMPROBANC INNER JOIN TCOMPROBAND ON dbo.TCOMPROBANC.ccompany = dbo.TCOMPROBAND.ccompany AND TCOMPROBANC.cidcomprob = TCOMPROBAND.cidcomprob ";
            strSql += "WHERE TCOMPROBANC.CCOMPANY='" + _P_Str_Compania + "' AND TCOMPROBANC.cidcomprob='" + _p_Str_IdComprob + "' AND corder='" + _P_Str_Order + "' ";
            dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(strSql);
            if (dsResultados.Tables[0].Rows.Count > 0)
            {
                strctypcomp = dsResultados.Tables[0].Rows[0][0].ToString();
                strcdescrip = dsResultados.Tables[0].Rows[0]["cdescrip"].ToString();
                //strcdescrip = dsResultados.Tables[0].Rows[0]["cdescrip"] + " \\ " + dsResultados.Tables[0].Rows[0]["cname"]; 

                //Buscamos una estado que corresponda con esos valores
                var _Consulta =
                    _G_Ds_EstadosLibro.Tables[0].AsEnumerable().Where(
                        _Fila => _Fila["ctypcompro"].ToString() == strctypcomp
                                 && strcdescrip.Contains(_Fila["cpalabraclave"].ToString().ToUpper()));

                //Convierto la Consulta
                var _Dtw_Items = _Consulta.Cast<DataRow>();

                //Si se obtuvo filas
                if (_Dtw_Items.Count() == 1)
                    strResultado = _Dtw_Items.First()["cestadoid"].ToString();
                else
                    strResultado = "";
            }

            return strResultado;
        }

        /// <summary>
        /// Devuelve el cestaoid a seleccionar en el combo
        /// </summary>
        /// <param name="_P_Str_Compania"></param>
        /// <param name="_P_Str_IdDispband"></param>
        /// <param name="_P_Str_IdDispbanc"></param>
        /// <param name="_P_Str_IDBanco"></param>
        /// <param name="_P_Str_NumCuenta"></param>
        /// <returns></returns>
        private string Obtener_cestadoid_Banco(string _P_Str_Compania, string _P_Str_IdDispband, string _P_Str_IdDispbanc, string _P_Str_IDBanco, string _P_Str_NumCuenta)
        {
            string strResultado = "";
            string strSql = "";
            DataSet dsResultados;

            //Seleccionamos de TDISPBAND
            strSql = "SELECT ctipoperacio FROM  TDISPBAND WHERE CCOMPANY='" + _P_Str_Compania + "' AND cdispband='" + _P_Str_IdDispband + "' AND cdispbanc='" + _P_Str_IdDispbanc + "' AND cbanco='" + _P_Str_IDBanco +
                     "' AND cnumcuenta='" + _P_Str_NumCuenta + "'";
            dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(strSql);
            if (dsResultados.Tables[0].Rows.Count > 0)
                strResultado = dsResultados.Tables[0].Rows[0][0].ToString();

            //Seleccionamos de TOPERBANCD
            if (strResultado != "")
            {
                strSql = "SELECT coperbanc FROM TOPERBANCD WHERE cbanco='" + _P_Str_IDBanco + "' AND coperbancd='" + strResultado + "'";
                dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(strSql);
                if (dsResultados.Tables[0].Rows.Count > 0)
                    strResultado = dsResultados.Tables[0].Rows[0][0].ToString();
            }

            //Seleccionamos de TESTADOSOPERB
            if (strResultado != "")
            {
                //Buscamos una estado que corresponda con esos valores
                var _Consulta =
                    _G_Ds_EstadosBanco.Tables[0].AsEnumerable().Where(
                        _Fila => _Fila["coperbanc"].ToString() == strResultado);

                //Convierto la Consulta
                EnumerableRowCollection<DataRow> _Dtw_Items = _Consulta.Cast<DataRow>();

                //Si se obtuvo filas
                if (_Dtw_Items.Count() > 0)
                {
                    strResultado = _Dtw_Items.First()["cestadoid"].ToString();
                }
                else
                    strResultado = "";

            }

            return strResultado;
        }

        /// <summary>
        /// Obtiene el estado asignado por el usuario en la conciliacion Banco
        /// </summary>
        /// <param name="_P_Str_Compania"></param>
        /// <param name="_P_Int_cidconciliacion"></param>
        /// <param name="_P_Str_ciddispbanc"></param>
        /// <param name="_P_Str_ciddispband"></param>
        /// <returns></returns>
        private string Obtener_cestadoid_AsignadoEnConciliacion_Banco(string _P_Str_Compania, int _P_Int_cidconciliacion, string _P_Str_ciddispbanc, string _P_Str_ciddispband)
        {
            string strResultado = "";
            string strSql = "";
            DataSet dsResultados;

            //Seleccionamos 
            strSql = "SELECT cestado FROM TCONCILIACIOND WHERE CCOMPANY='" + _P_Str_Compania + "' AND cidconciliacion='" + _P_Int_cidconciliacion + "' AND ciddispbanc='" + _P_Str_ciddispbanc + "' AND ciddispband='" + _P_Str_ciddispband + "' AND ctipodetalle='" + (byte)_Cls_RutinasConciliacion._TipoDetalle.Banco + "'";
            dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(strSql);
            if (dsResultados.Tables[0].Rows.Count > 0)
                strResultado = dsResultados.Tables[0].Rows[0][0].ToString();
            strResultado = strResultado == "0" ? "" : strResultado;
            return strResultado;
        }

        /// <summary>
        /// Obtiene el estado asignado por el usuario en la conciliacion Libro
        /// </summary>
        /// <param name="_P_Str_Compania"></param>
        /// <param name="_P_Int_cidconciliacion"></param>
        /// <param name="_P_Str_cidcomprob"></param>
        /// <param name="_P_Str_corder"></param>
        /// <returns></returns>
        private string Obtener_cestadoid_AsignadoEnConciliacion_Libro(string _P_Str_Compania, int _P_Int_cidconciliacion, string _P_Str_cidcomprob, string _P_Str_corder)
        {
            string strResultado = "";
            string strSql = "";
            DataSet dsResultados;

            //Seleccionamos 
            strSql = "SELECT cestado FROM TCONCILIACIOND WHERE CCOMPANY='" + _P_Str_Compania + "' AND cidconciliacion='" + _P_Int_cidconciliacion + "' AND cidcomprob='" + _P_Str_cidcomprob + "' AND corder='" + _P_Str_corder + "'  AND ctipodetalle='" + (byte)_Cls_RutinasConciliacion._TipoDetalle.Libro + "'";
            dsResultados = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(strSql);
            if (dsResultados.Tables[0].Rows.Count > 0)
                strResultado = dsResultados.Tables[0].Rows[0][0].ToString();
            strResultado = strResultado == "0" ? "" : strResultado;
            return strResultado;
        }

        private void _Mtd_MarcarRegistrosConciliados(string _P_Str_Cidedetalleconciliacion)
        {
            //Si selecciono u registro que no esta conciliado no hago nada
            if (_P_Str_Cidedetalleconciliacion == "0")
            {
                return;
            }

            //Borro el marcado de registros
            _Dtg_ConciliarBancoLibro.ClearSelection();

            //Selecciono las filas de Banco
            List<DataGridViewRow> _Dtg_FilasBanco = _Dtg_ConciliarBancoLibro.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["cidedetalleconciliacion"].Value.ToString() == _P_Str_Cidedetalleconciliacion).ToList();
            if (_Dtg_FilasBanco.Count > 0)
            {
                foreach (DataGridViewRow _Dgvr in _Dtg_FilasBanco)
                {
                    _Dgvr.Selected = true;
                }
                _Dtg_ConciliarBancoLibro.FirstDisplayedScrollingRowIndex = _Dtg_FilasBanco[0].Index;
                _Dtg_ConciliarBancoLibro.Refresh();
            }

            //Selecciono las filas de Libro
            List<DataGridViewRow> _Dtg_FilasLibro = _Dtg_ConciliarBancoLibro.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["cidedetalleconciliacion"].Value.ToString() == _P_Str_Cidedetalleconciliacion).ToList();
            if (_Dtg_FilasLibro.Count > 0)
            {
                foreach (DataGridViewRow _Dgvr in _Dtg_FilasLibro)
                {
                    _Dgvr.Selected = true;
                }
                _Dtg_ConciliarBancoLibro.FirstDisplayedScrollingRowIndex = _Dtg_FilasLibro[0].Index;
                _Dtg_ConciliarBancoLibro.Refresh();
            }
        }

        private void _Btn_Siguiente_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _G_Int_Paso = 2;
            _Tab_PasosConciliacion.SelectedIndex = _G_Int_Paso - 1;
            if (_G_Bol_ModoGuardar)
            {
                _Mtd_MostrarSaldosEstadoDeCuenta();
                _Mtd_CargarBancoNoConciliado();
            }
            Cursor = Cursors.Default;
        }

        private void _Btn_AnteriorBanco_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de volver al paso anterior? esto hará que pierdas los datos seleccionados de Banco No Conciliados?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                _G_Int_Paso = 1;
                _Tab_PasosConciliacion.SelectedIndex = _G_Int_Paso - 1;
                if (_Bol_NotificadorAprobacion)
                {
                    _Mtd_ColorGridConciliado();
                    _Bol_NotificadorAprobacion = false;
                }
            }
        }

        private void _Btn_SiguienteBanco_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //Valido los estados
            if (!_Mtd_EsValidoEstadosBancoNoConciliado())
            {
                return;
            }
            _Er_Error.Dispose();
            _G_Int_Paso = 3;
            _Tab_PasosConciliacion.SelectedIndex = _G_Int_Paso - 1;
            if (_G_Bol_ModoGuardar)
            {
                _Mtd_MostrarSaldosLibro();
                _Mtd_CargarMayorAnalitico();
            }
            Cursor = Cursors.Default;
        }


        private void _Mtd_MostrarSaldosLibro()
        {
            decimal _Dc_SaldoLibroDesde = 0;
            decimal _Dc_SaldoLibroHasta = 0;

            _G_Str_SentenciaSql = "SELECT cidconciliacion,CONVERT(VARCHAR,TCONCILIACION.cfechaconciliacion,103) AS [FechaDesde], CONVERT(VARCHAR,TCONCILIACION.cfechahasta,103) AS [FechaHasta], cbanco, cnumcuenta, csaldoinicialsegunlibro, csaldosegunlibro FROM TCONCILIACION WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' and cidconciliacion = '" + _G_Int_cidconciliacion + "'";
            var _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);

            //Obtenemos los Saldo del Libro desde la conciliacion 
            _Dc_SaldoLibroDesde = Convert.ToDecimal(_Ds_DataSet.Tables[0].Rows[0]["csaldoinicialsegunlibro"]);
            _Dc_SaldoLibroHasta = Convert.ToDecimal(_Ds_DataSet.Tables[0].Rows[0]["csaldosegunlibro"]);

            _Txt_SaldoInicialLibro.Text = _Dc_SaldoLibroDesde.ToString("#,##0.00");
            _Txt_SaldoFinalLibro.Text = _Dc_SaldoLibroHasta.ToString("#,##0.00");

        }



        private void _Btn_AnteriorLibro_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de volver al paso anterior? esto hará que pierdas los datos seleccionados de Libro No Conciliados?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                _G_Int_Paso = 2;
                _Tab_PasosConciliacion.SelectedIndex = _G_Int_Paso - 1;
            }
        }

        private void _Btn_SiguienteLibro_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //Valido los estados
            if (!_Mtd_EsValidoEstadosBancoNoConciliado())
            {
                return;
            }
            _Btn_AnteriorReporte.Visible = true;
            _Er_Error.Dispose();
            _G_Int_Paso = 3;
            if (_Mtd_GuardarDisponibilidad())
            {
                Cursor = Cursors.WaitCursor;
                //Me coloco en la pestaña reporte 
                _Tab_Contenedor.SelectedIndex = 2;
                //Muestro el Reporte de la Conciliacion
                _Mtd_MostrarReporteConciliacion(_G_Int_ciddisponibilidad, Frm_Padre._Str_Comp);
                //Activamos el boton finalizar
                _Btn_Finalizar.Enabled = true;
            }
            Cursor = Cursors.Default;
        }

        private void _Btn_AnteriorReporte_Click(object sender, EventArgs e)
        {
            _G_Int_Paso = 3;
            _Tab_PasosConciliacion.SelectedIndex = _G_Int_Paso - 1;
            _Tab_Contenedor.SelectedIndex = 1;
            _G_Bol_ModoReporte = false;
        }

        private void _Mtd_ImprimirReporte()
        {
            try
            {
                if (!_G_Bol_Impreso)
                {
                    _Rpt_ReporteConciliacion.PrintDialog();

                    switch (MessageBox.Show("¿El reporte fue impreso correctamente?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            //Agregar Registro
                            _G_Bol_Impreso = true;
                            _G_Str_SentenciaSql = "UPDATE TDISPONIBILIDAD SET CIMPRESO='1' WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND ciddisponibilidad='" + _G_Int_ciddisponibilidad + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSql);
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                            break;
                        case DialogResult.No:
                            _G_Bol_Impreso = false;
                            break;
                        case DialogResult.Cancel:
                            //Cancelar
                            _G_Bol_Impreso = false;
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("El reporte ya fué Impreso", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception _Ex)
            {
                //Inicializamos
                _intNivelDeError = 0;
                _oMensaje = new StringBuilder();
                //Generamos el Mensaje
                MostrarMensaje(_Ex);
                //Enviamos el Mensaje por correo

                MessageBox.Show("Lo sentimos, ha ocurrido un error inesperado. Por favor envie un Ticket con la captura de esta pantalla.\n" +
                                "Error : \n" + _oMensaje.ToString()
                                , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static StringBuilder _oMensaje;
        private static int _intNivelDeError;
        private static void MostrarMensaje(Exception pExcepcion)
        {
            //Contamos el Nivel del Error
            _intNivelDeError++;
            //Creamos una sangria para el nivel del error
            var strSangria = new string('\t', _intNivelDeError - 1);
            //Nueva linea
            var strNuevaLinea = Environment.NewLine;

            //Creamos le Mensaje
            _oMensaje.Append(strSangria + String.Format("******************** Nivel de Excepción {0} ********************", _intNivelDeError) + strNuevaLinea);
            _oMensaje.Append(strSangria + "Tipo de Excepción: " + pExcepcion.GetType().Name.ToString(CultureInfo.InvariantCulture) + strNuevaLinea);
            _oMensaje.Append(strSangria + "Linea de ayuda: " + pExcepcion.HelpLink + strNuevaLinea);
            _oMensaje.Append(strSangria + "Mensaje: " + pExcepcion.Message + strNuevaLinea);
            _oMensaje.Append(strSangria + "Origen: " + pExcepcion.Source + strNuevaLinea);
            _oMensaje.Append(strSangria + "Pila de llamadas: " + pExcepcion.StackTrace + strNuevaLinea);
            _oMensaje.Append(strSangria + "Destino: " + pExcepcion.TargetSite + strNuevaLinea);
            _oMensaje.Append(strSangria + "Datos: " + pExcepcion.Data + strNuevaLinea);
            //Recorremos los datos
            foreach (DictionaryEntry oDato in pExcepcion.Data)
            {
                _oMensaje.Append(String.Format("{0} : {1}", oDato.Key, oDato.Value) + strNuevaLinea);
            }
            //Excepcion Interna
            var oExcepcionInterna = pExcepcion.InnerException;
            //Mostramos las excepciones internas
            while (oExcepcionInterna != null)
            {
                MostrarMensaje(oExcepcionInterna);
                //Verificamos si estamos haciendo una excepcion interna
                oExcepcionInterna = _intNivelDeError > 1 ? oExcepcionInterna.InnerException : null;
            }
            //Bajamos el Nivel de Error
            _intNivelDeError--;
        }


        private void _Btn_Finalizar_Click(object sender, EventArgs e)
        {
            if (_Btn_Finalizar.Text == "Imprimir")
            {
                //Habilito el boton exportar
                _Rpt_ReporteConciliacion.ShowExportButton = true;
                //Mando a Imprimir
                _Mtd_ImprimirReporte();
                //Inicializo el Formulario
                _Cmb_BancoConsulta.SelectedIndex = 0;
                _Cmb_CuentaConsulta.DataSource = null;
                _Cmb_CuentaConsulta.Enabled = false;
                _G_Bol_ModoReporte = false;
                _Tab_Contenedor.SelectedIndex = 0;
                _Mtd_Consultar("", "");
            }
            else
            {
                if (
                    MessageBox.Show(
                        "La acción solicitada finalizará la Disponibilidad y usted ya no podrá realizar modificaciones. ¿Está seguro de continuar?",
                        "Información", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _Er_Error.Dispose();
                    _G_Int_Paso = 4;
                    if (_Mtd_FinalizarConciliacion())
                    {
                        //Habilito el boton exportar
                        _Rpt_ReporteConciliacion.ShowExportButton = true;
                        //Mando a Imprimir
                        _Mtd_ImprimirReporte();
                        //Inicializo el Formulario
                        _G_Bol_ModoGuardar = false;
                        _G_Bol_ModoConsulta = true;
                        _G_Bol_ModoReporte = false;
                        _Cmb_BancoConsulta.SelectedIndex = 0;
                        _Cmb_CuentaConsulta.DataSource = null;
                        _Cmb_CuentaConsulta.Enabled = false;
                        _Tab_Contenedor.SelectedIndex = 0;
                        _Mtd_Consultar("", "");
                    }
                }

            }
        }

        private void _Tab_PasosConciliacion_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                e.Cancel = !(_G_Int_Paso == 1);
            }
            else if (e.TabPageIndex == 1)
            {
                e.Cancel = !(_G_Int_Paso == 2);
            }
            else if (e.TabPageIndex == 2)
            {
                e.Cancel = !(_G_Int_Paso == 3);
            }
        }


        private void Frm_ConciliacionBancariaV2_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Pnl_TipoOperacionBancaria.Left = (Width / 2) - (_Pnl_TipoOperacionBancaria.Width / 2);
            _Pnl_TipoOperacionBancaria.Top = (Height / 2) - (_Pnl_TipoOperacionBancaria.Height / 2);
        }

        /// <summary>
        /// Indica que 
        /// </summary>
        private bool _Mtd_RegistroTieneRegistroCorrespondienteDeAjusteAprobado()
        {
            return false;
        }


        /// <summary>
        /// Concilia Automaticamente (1 a 1)
        /// </summary>
        private void _Mtd_ConciliarAutomaticamente()
        {
            // - -
            // 1ra CORRIDA -> Tomando como Origen Banco
            // - -
            //Recorremos cada registro del banco

            var _Registros_Banco = _G_Ds_BancoLibro.Tables[0].AsEnumerable().Where(x => x["Tip.Reg."].ToString().ToUpper() == "BANCO" && x["cconciliado"].ToString() == "0");
            var _Int_CantidadRegistroBanco = _Registros_Banco.Count();
            //Si hay registros
            if (_Int_CantidadRegistroBanco > 0)
            {
                //Cargamos los Datos
                var _Dt_Banco = _Registros_Banco.CopyToDataTable();

                //Recorremos los registros de Banco
                foreach (DataRow _Dtw_ItemBanco in _Dt_Banco.Rows)
                {
                    var _cdispbanc = _Dtw_ItemBanco["cdispbanc"].ToString();
                    var _cdispband = _Dtw_ItemBanco["cdispband"].ToString();
                    string _Str_NumeroDeDocumento = _Dtw_ItemBanco[2].ToString();
                    Int64 _Int_NumeroDocumento = 0;
                    Int64.TryParse(_Str_NumeroDeDocumento, out _Int_NumeroDocumento);
                    var _Int_Comprobante = 0;
                    int.TryParse(_Dtw_ItemBanco["cidcomprob"].ToString(), out _Int_Comprobante);
                    var _Int_Order = 0;
                    int.TryParse(_Dtw_ItemBanco["corder"].ToString(), out _Int_Order);
                    //Si existe un numero de documento
                    if (_Str_NumeroDeDocumento.Length >= 0)
                    {
                        //Obtengo aquellos registros de libro donde coincida el numero de documento

                        //Consulto
                        EnumerableRowCollection<DataRow> _Consulta;
                        //Si el numero de documento del banco trae caracteres extraños busco por su original, no por su valor
                        if (_Int_NumeroDocumento == 0)
                        {
                            _Consulta = _G_Dtv_RegistrosChequesPendientes.Table.AsEnumerable()
                                                                  .Where(x => x["Tip.Reg."].ToString().ToUpper() == "LIBRO")
                                                                  .Where(x =>
                                                                         !String.IsNullOrEmpty(x["Número Doc."].ToString())
                                                                         && x["cconciliado"].ToString() == "0"
                                                                         && (
                                                                                x["Número Doc."].ToString() == _Str_NumeroDeDocumento
                                                                                ||
                                                                                x["Concepto"].ToString().Contains(_Str_NumeroDeDocumento))
                                );
                        }
                        else
                        {
                            _Consulta = _G_Dtv_RegistrosChequesPendientes.Table.AsEnumerable()
                                                                  .Where(x => x["Tip.Reg."].ToString().ToUpper() == "LIBRO")
                                                                  .Where(x =>
                                                                         //!String.IsNullOrEmpty(x["Número Doc."].ToString()) && 
                                                                         x["cconciliado"].ToString() == "0"
                                                                         //&& x["Número Doc."].ToString().Length > 0
                                                                         && (
                                                                                x["Número Doc."].ToString() == _Str_NumeroDeDocumento
                                                                                ||
                                                                                x["Número Doc."].ToString() == _Int_NumeroDocumento.ToString(CultureInfo.InvariantCulture)
                                                                                ||
                                                                                x["Concepto"].ToString().Contains(_Int_NumeroDocumento.ToString(CultureInfo.InvariantCulture)))
                                );
                        }
                        //Convierto la Consulta
                        EnumerableRowCollection<DataRow> _Dtw_ItemsSeleccionadosLibro = _Consulta.Cast<DataRow>();

                        //Si se obtuvo filas de libro
                        if (_Dtw_ItemsSeleccionadosLibro.Any())
                        {
                            var _Bool_Fueconciliado = false;

                            //Recorremos los registros que coinciden
                            foreach (DataRow _Dtw_ItemLibro in _Dtw_ItemsSeleccionadosLibro)
                            {
                                if (!_Bool_Fueconciliado)
                                {
                                    //Ubicamos los registros en el dataset
                                    var _RegistroLibro = _G_Ds_BancoLibro.Tables[0]
                                        .AsEnumerable()
                                        .SingleOrDefault(x =>
                                                         x["cdispbanc"].ToString() == "0"
                                                         && x["cidcomprob"].ToString() == _Dtw_ItemLibro["cidcomprob"].ToString()
                                                         && x["corder"].ToString() == _Dtw_ItemLibro["corder"].ToString()


                                        );
                                    //var _RegistroBanco2222 = _G_Ds_BancoLibro.Tables[0]
                                    //    .AsEnumerable()
                                    //    .Where(x =>
                                    //                     x["cdispband"].ToString() == _Dtw_ItemBanco["cdispband"].ToString()
                                    //                     && x["cdispbanc"].ToString() == _Dtw_ItemBanco["cdispbanc"].ToString()
                                    //    ).ToList();

                                    var _RegistroBanco = _G_Ds_BancoLibro.Tables[0]
                                        .AsEnumerable()
                                        .SingleOrDefault(x =>
                                                         x["cdispband"].ToString() == _Dtw_ItemBanco["cdispband"].ToString()
                                                         && x["cdispbanc"].ToString() == _Dtw_ItemBanco["cdispbanc"].ToString()
                                        );

                                    int _Int_IndexLibro_BancoLibro = _G_Ds_BancoLibro.Tables[0].Rows.IndexOf(_RegistroLibro);
                                    int _Int_IndexBanco_BancoLibro = _G_Ds_BancoLibro.Tables[0].Rows.IndexOf(_RegistroBanco);

                                    //Obtenemos los Montos
                                    decimal _Dec_MontoLibro;
                                    decimal _Dec_MontoBanco;
                                    decimal _Dec_SaldoMontos = 0;
                                    if ((_RegistroLibro != null) & (_RegistroBanco != null))
                                    {
                                        _Dec_MontoLibro = Convert.ToDecimal(_Dtw_ItemLibro["monto"]);
                                        _Dec_MontoBanco = Convert.ToDecimal(_Dtw_ItemBanco["monto"]);
                                        _Dec_SaldoMontos = _Dec_MontoBanco - _Dec_MontoLibro;
                                    }

                                    //verifico que los saldos se salden
                                    if (_Dec_SaldoMontos == 0)
                                    {
                                        //Marcamos como conciliado en el foreach
                                        _Bool_Fueconciliado = true;

                                        //Actualizo el contador atomico
                                        _G_Int_Ciddetalleconciliacion++;

                                        //-->Libro
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["cconciliado"] = "1";
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["cconciliadoAutomaticamente"] = "1";
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["coperbancseleccionado"] = "";
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["cdispband"] = _Dtw_ItemBanco["cdispband"].ToString();
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["cdispbanc"] = _Dtw_ItemBanco["cdispbanc"].ToString();
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["cseleccionado"] = _G_Str_Seleccionado;
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["estado"] = "0";
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["estadodescripcion"] = "";
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["cidedetalleconciliacion"] = _G_Int_Ciddetalleconciliacion;
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro].AcceptChanges();
                                        //-->Banco
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["cconciliado"] = "1";
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["cconciliadoAutomaticamente"] = "1";
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["coperbancseleccionado"] = "";
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["cseleccionado"] = _G_Str_Seleccionado;
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["cidcomprob"] = _Dtw_ItemLibro["cidcomprob"].ToString();
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["corder"] = _Dtw_ItemLibro["corder"].ToString();
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["estado"] = "0";
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["estadodescripcion"] = "";
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["cidedetalleconciliacion"] = _G_Int_Ciddetalleconciliacion;
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro].AcceptChanges();

                                    }
                                }
                            }
                        }
                    }
                }
            }

            // - -
            // 2da CORRIDA -> Tomando como Origen Libro
            // - -

            //Cargamos de nuevo las variables con solo registros no conciliados
            var _Registros_Libro = _G_Dtv_RegistrosChequesPendientes.Table.AsEnumerable().Where(x => x["Tip.Reg."].ToString().ToUpper() == "LIBRO" && x["cconciliado"].ToString() == "0");
            var _Int_CantidadRegistroLibro = _Registros_Libro.Count();
            //Si hay registros
            if (_Int_CantidadRegistroLibro > 0)
            {
                //Pasamos a la tabla
                var _Dt_Libro = _Registros_Libro.CopyToDataTable();

                //Recorremos cada registro del libro que no este conciliado
                foreach (DataRow _Dtw_ItemLibro in _Dt_Libro.Rows)
                {
                    //string _Str_Monto = _Dtw_Item[5].ToString();
                    string _Str_NumeroDeDocumento = _Dtw_ItemLibro[2].ToString();
                    var _cestadoid = _Dtw_ItemLibro["cestadoid"].ToString();

                    //Si existe un numero de documento
                    if (_Str_NumeroDeDocumento.Length >= 0)
                    {
                        Int64 _Int_NumeroDocumento = 0; // Convert.ToInt64(_Str_NumeroDeDocumento);
                        Int64.TryParse(_Str_NumeroDeDocumento, out _Int_NumeroDocumento);

                        //Obtengo aquellos registros de banco donde coincida el numero de documento
                        //Consulto
                        EnumerableRowCollection<DataRow> _Consulta;
                        if (_Str_NumeroDeDocumento.Length > 0)
                        {
                            _Consulta = _G_Ds_BancoLibro.Tables[0].AsEnumerable()
                                                                  .Where(x => x["Tip.Reg."].ToString().ToUpper() == "BANCO" && x["cconciliado"].ToString() == "0")
                                                                  .Where(x =>
                                                                         !String.IsNullOrEmpty(x["Número Doc."].ToString())
                                                                         && x["cconciliado"].ToString() == "0"
                                                                         && (
                                                                                x["Número Doc."].ToString() == _Int_NumeroDocumento.ToString(CultureInfo.InvariantCulture)
                                                                                ||
                                                                                x["Concepto"].ToString().Contains(_Int_NumeroDocumento.ToString(CultureInfo.InvariantCulture)
                                                                                    )));
                        }
                        else //Solo registros de banco sin numero de documento
                        {
                            _Consulta = _G_Ds_BancoLibro.Tables[0].AsEnumerable()
                                                                  .Where(x => x["Tip.Reg."].ToString().ToUpper() == "BANCO" && x["cconciliado"].ToString() == "0")
                                                                  .Where(x =>
                                                                         String.IsNullOrEmpty(x["Número Doc."].ToString()) 
                                                                         && x["cconciliado"].ToString() == "0"
                                                                         && (
                                                                                x["Número Doc."].ToString() == _Int_NumeroDocumento.ToString(CultureInfo.InvariantCulture)
                                                                                ||
                                                                                x["Concepto"].ToString().Contains(_Str_NumeroDeDocumento)
                                                                             ));
                        }

                        //Convierto la Consulta
                        EnumerableRowCollection<DataRow> _Dtw_ItemsSeleccionadosBanco = _Consulta.Cast<DataRow>();

                        //Si se obtuvo filas de Banco
                        if (_Dtw_ItemsSeleccionadosBanco.Any())
                        {
                            var _Bool_Fueconciliado = false;

                            //Recorremos los registros que coinciden
                            foreach (DataRow _Dtw_ItemBanco in _Dtw_ItemsSeleccionadosBanco)
                            {
                                if (!_Bool_Fueconciliado)
                                {
                                    //Ubicamos los registros en el dataset
                                    var _RegistroLibro = _G_Ds_BancoLibro.Tables[0]
                                        .AsEnumerable()
                                        .SingleOrDefault(x =>
                                                         x["cidcomprob"].ToString() == _Dtw_ItemLibro["cidcomprob"].ToString()
                                                         && x["corder"].ToString() == _Dtw_ItemLibro["corder"].ToString()
                                                         && x["cestadoid"].ToString() == _cestadoid
                                        );

                                    var _RegistroBanco = _G_Ds_BancoLibro.Tables[0]
                                        .AsEnumerable()
                                        .SingleOrDefault(x =>
                                                         x["cdispband"].ToString() == _Dtw_ItemBanco["cdispband"].ToString()
                                                         && x["cdispbanc"].ToString() == _Dtw_ItemBanco["cdispbanc"].ToString()
                                        );

                                    int _Int_IndexLibro_BancoLibro = _G_Ds_BancoLibro.Tables[0].Rows.IndexOf(_RegistroLibro);
                                    int _Int_IndexBanco_BancoLibro = _G_Ds_BancoLibro.Tables[0].Rows.IndexOf(_RegistroBanco);

                                    //Obtenemos los Montos
                                    decimal _Dec_MontoLibro = 0;
                                    decimal _Dec_MontoBanco = 0;
                                    decimal _Dec_SaldoMontos = 0;
                                    if ((_RegistroLibro != null) & (_RegistroBanco != null))
                                    {
                                        _Dec_MontoLibro = Convert.ToDecimal(_Dtw_ItemLibro["monto"]);
                                        _Dec_MontoBanco = Convert.ToDecimal(_Dtw_ItemBanco["monto"]);
                                        _Dec_SaldoMontos = _Dec_MontoBanco - _Dec_MontoLibro;
                                    }

                                    //verifico que los saldos se salden
                                    if (_Dec_SaldoMontos == 0)
                                    {
                                        //Marcamos como conciliado en el foreach
                                        _Bool_Fueconciliado = true;

                                        //Actualizo el contador atomico
                                        _G_Int_Ciddetalleconciliacion++;

                                        //-->Libro
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["cconciliado"] = "1";
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["cconciliadoAutomaticamente"] = "1";
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["coperbancseleccionado"] = "";
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["cdispband"] = _Dtw_ItemBanco["cdispband"].ToString();
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["cdispbanc"] = _Dtw_ItemBanco["cdispbanc"].ToString();
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["cseleccionado"] = _G_Str_Seleccionado;
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["estado"] = "0";
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["estadodescripcion"] = "";
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["cidedetalleconciliacion"] = _G_Int_Ciddetalleconciliacion;
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro].AcceptChanges();
                                        //-->Banco
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["cconciliado"] = "1";
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["cconciliadoAutomaticamente"] = "1";
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["coperbancseleccionado"] = "";
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["cseleccionado"] = _G_Str_Seleccionado;
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["cidcomprob"] = _Dtw_ItemLibro["cidcomprob"].ToString();
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["corder"] = _Dtw_ItemLibro["corder"].ToString();
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["estado"] = "0";
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["estadodescripcion"] = "";
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["cidedetalleconciliacion"] = _G_Int_Ciddetalleconciliacion;
                                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro].AcceptChanges();

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void _Mtd_ColorGridConciliado()
        {
            Color _Color_Default = Color.White;
            if (_G_ColorInicialGrid != null)
            {
                _Color_Default = _G_ColorInicialGrid;
            }
            //Color Seleccionado
            _Dtg_ConciliarBancoLibro.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["cconciliado"].Value.ToString() == "1").ToList().ForEach(x =>
                {
                    x.DefaultCellStyle.BackColor = Color.Khaki;
                });
            //Color Normal
            _Dtg_ConciliarBancoLibro.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["cconciliado"].Value.ToString() != "1").ToList().ForEach(x =>
                {
                    x.DefaultCellStyle.BackColor = _Color_Default;
                });
        }

        private void _Mtd_QuitarOrdenamientoGridBancoLibro()
        {
            //Quitamos el Ordenamiento de las columnas
            _Dtg_ConciliarBancoLibro.Columns.Cast<DataGridViewColumn>().ToList().ForEach(x =>
                {
                    //Excepto estas columnas
                    switch (x.Name)
                    {
                        case "BancoConChecked":
                        case "Número Doc.":
                        case "Concepto" :
                            break;
                        case "Monto":
                            x.ValueType = typeof(double);
                            x.SortMode = DataGridViewColumnSortMode.Automatic;
                            break;
                        default:
                            x.SortMode = DataGridViewColumnSortMode.NotSortable;
                            break;
                    }
                });
        }

        /// <summary>
        /// Validaciones de la conciliacion manual
        /// </summary>
        /// <returns></returns>
        private bool _Mtd_EsValidoRegistrosSeleccionadosConciliacioManual(out Frm_AprobConcManuales.Tipoajuste _P_oTipoAjuste)
        {
            var _oTipoAjuste  = Frm_AprobConcManuales.Tipoajuste.SinAsignar;

            // - = 
            // - = - = - = - = - = - = - = - = - = - = - = - = - = Valido que esten seleccionados por lo menos dos registros  - = - = - = - = - = - = - = - = - = - = - = - = - = 
            // - = 
            if (_Dtg_ConciliarBancoLibro.SelectedRows.Count < 1)
            {
                MessageBox.Show("Debe seleccionar al menos un registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _P_oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.SinAsignar;
                return false;
            }

            // - = 
            // - = - = - = - = - = - = - = - = - = - = - = - = - = Validaciones de de que ninguno ya este conciliado en el grid - = - = - = - = - = - = - = - = - = - = - = - = - = 
            // - = 
            var _Int_CantidadRegistrosConciliados = _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Count(x => x.Cells["cconciliado"].Value.ToString() == "1");
            if (_Int_CantidadRegistrosConciliados > 0)
            {
                MessageBox.Show("No se pueden conciliar registros ya conciliados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _P_oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.SinAsignar;
                return false;
            }

            // - = 
            // - = - = - = - = - = - = - = - = - = - = - = - = - = Validaciones de cantidades de registros seleccionados - = - = - = - = - = - = - = - = - = - = - = - = - = 
            // - = 
            var _Int_CantidadFilasSeleccionadasLibro = _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Count(x => x.Cells["Tip.Reg."].Value.ToString().ToUpper() == "LIBRO");
            var _Int_CantidadFilasSeleccionadasBanco = _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Count(x => x.Cells["Tip.Reg."].Value.ToString().ToUpper() == "BANCO");
            Boolean _Bool_SeleccionValida = false;

            //Obtenemos la sumatoria de los registros
            var _Dcm_SumatoriaLibro = _Int_CantidadFilasSeleccionadasLibro == 0 ? 0 : _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Where(x => x.Cells["Tip.Reg."].Value.ToString().ToUpper() == "LIBRO").Sum(x => Convert.ToDecimal(x.Cells["Monto"].Value));
            var _Dcm_SumatoriaBanco = _Int_CantidadFilasSeleccionadasBanco == 0 ? 0 : _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Where(x => x.Cells["Tip.Reg."].Value.ToString().ToUpper() == "BANCO").Sum(x => Convert.ToDecimal(x.Cells["Monto"].Value));
            var _Dcm_Saldo = Math.Round(_Dcm_SumatoriaLibro - _Dcm_SumatoriaBanco, 2);

            //Caso normal : 1 Libro <-> 1 Banco //Solo uno a uno para disponibilidad , se obian todos los demas casos por los momentos al 03-12-2014
            if ((_Int_CantidadFilasSeleccionadasLibro == 1) && (_Int_CantidadFilasSeleccionadasBanco == 1))
            {
                if (_Dcm_Saldo == 0)
                {
                    _Bool_SeleccionValida = true;
                    _oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.UnoAUnoDiferenciaNumero;
                }
            }

            //Valido que al menos este seleccionada una fila de banco y una de libro
            if (!_Bool_SeleccionValida)
            {
                MessageBox.Show("Seleccion de registros no permitida.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _P_oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.SinAsignar;
                return false;
            }

            //Si el ajuste tiene diferencia de monto, entonces preguntamos si esta seguro
            if (_Dcm_Saldo != 0)
            {

                switch (_oTipoAjuste)
                {
                    case Frm_AprobConcManuales.Tipoajuste.UnoAUnoDiferenciaNumero:
                    case Frm_AprobConcManuales.Tipoajuste.UnoAUnoDiferenciaMonto:
                    case Frm_AprobConcManuales.Tipoajuste.MultiplesAgrupamientoRegistros:
                    case Frm_AprobConcManuales.Tipoajuste.MultiplesAgrupamientoRegistrosConDiferenciaMonto:
                    case Frm_AprobConcManuales.Tipoajuste.MultiplesDivisionRegistros:
                    case Frm_AprobConcManuales.Tipoajuste.MultiplesDivisionRegistrosConDiferenciaMonto:
                    case Frm_AprobConcManuales.Tipoajuste.CruceMovimientosBanco:
                    case Frm_AprobConcManuales.Tipoajuste.ComisionesEIntereses:
                    case Frm_AprobConcManuales.Tipoajuste.ComisionesEIntereses_Reverso:
                    case Frm_AprobConcManuales.Tipoajuste.MuchosLibrosConMuchosBancos:
                    case Frm_AprobConcManuales.Tipoajuste.MuchosLibrosConMuchosBancosConDiferenciaMonto:
                    case Frm_AprobConcManuales.Tipoajuste.CruceMovimientosContables:
                        if (MessageBox.Show("El ajuste a generar posee diferencia de montos por un valor de : " + _Dcm_Saldo.ToString("#,##0.00") + ". ¿Está seguro que desea conciliar?.", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        {
                            _P_oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.SinAsignar;
                            return false;
                        }
                        break;
                }
            }

            //Si llegamos aqui las validaciones pasaron
            _P_oTipoAjuste = _oTipoAjuste;
            return true;
        }

        private void _Mtd_ConciliarManualmente(string _P_Str_tipooperacionbancaria)
        {
            var _oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.SinAsignar;

            //
            // - = - = - = - = - = - = - = - = - = - = - = - = Validamos - = - = - = - = - = - = - = - = - = - = - = - = 
            //
            if (!_Mtd_EsValidoRegistrosSeleccionadosConciliacioManual(out _oTipoAjuste)) return;

            //
            //- = - = - = - = - = - = - = - = - = - = - = - = Marcamos los registros como conciliados manualmente - = - = - = - = - = - = - = - = - = - = - = - = 
            //
            var _RegistrosSeleccionados = _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().ToList();

            //Validamos
            if (!_RegistrosSeleccionados.Any()) return;

            //Si es el caso de un solo registro -> Saltamos el codigo a otra rutina
            if ((_RegistrosSeleccionados.Count == 1) & (_P_Str_tipooperacionbancaria == ""))
            {
                _Pnl_TipoOperacionBancaria.Visible = true;
                _Pnl_TipoOperacionBancaria.BringToFront();
                ((Frm_Padre)MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                return;
            }

            //Obtenemos el nuevo id para los registros a conciliar
            //Actualizo el contador atomico
            _G_Int_Ciddetalleconciliacion++;

            //
            // - = - = - = - = - = - = - = - = - = - = - = - = Conciliamos de la variable de trabajo  - = - = - = - = - = - = - = - = - = - = - = - = 
            //
            foreach (var _Dtw_ItemActual in _RegistrosSeleccionados)
            {
                string _Str_TipoReg = _Dtw_ItemActual.Cells["Tip.Reg."].Value.ToString();
                if (_Str_TipoReg == "LIBRO")
                {
                    //Obtenemos las claves del comprobante
                    var _Str_cidcomprob = _Dtw_ItemActual.Cells["cidcomprob"].Value.ToString();
                    var _Str_corder = _Dtw_ItemActual.Cells["corder"].Value.ToString();
                    var _RegistroLibro = _G_Ds_BancoLibro.Tables[0]
                        .AsEnumerable()
                        .SingleOrDefault(x =>
                                         x["cdispbanc"].ToString() == "0"
                                         && x["cidcomprob"].ToString() == _Str_cidcomprob
                                         && x["corder"].ToString() == _Str_corder
                        );
                    //Verificamos
                    if (_RegistroLibro != null)
                    {
                        //Obtenemos los indices
                        int _Int_IndexLibro_BancoLibro = _G_Ds_BancoLibro.Tables[0].Rows.IndexOf(_RegistroLibro);
                        //-->Libro
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["cconciliado"] = "1";
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["cconciliadoAutomaticamente"] = "0";
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["coperbancseleccionado"] = "";
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["cdispband"] = 0;
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["cdispbanc"] = 0;
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["cseleccionado"] = _G_Str_SeleccionadoManual;
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["estado"] = "0";
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["estadodescripcion"] = "";
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["cidedetalleconciliacion"] = _G_Int_Ciddetalleconciliacion;
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro]["ctipoajuste"] = _oTipoAjuste;
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro_BancoLibro].AcceptChanges();
                    }

                }
                else
                {
                    //Obtenemos las claves del banco
                    var _Str_cdispband = _Dtw_ItemActual.Cells["cdispband"].Value.ToString();
                    var _Str_cdispbanc = _Dtw_ItemActual.Cells["cdispbanc"].Value.ToString();
                    var _RegistroBanco = _G_Ds_BancoLibro.Tables[0]
                        .AsEnumerable()
                        .SingleOrDefault(x =>
                                         x["cdispband"].ToString() == _Str_cdispband
                                         && x["cdispbanc"].ToString() == _Str_cdispbanc
                        );
                    //Verificamos
                    if (_RegistroBanco != null)
                    {
                        //Obtenemos los indices
                        int _Int_IndexBanco_BancoLibro = _G_Ds_BancoLibro.Tables[0].Rows.IndexOf(_RegistroBanco);
                        //-->Banco
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["cconciliado"] = "1";
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["cconciliadoAutomaticamente"] = "0";
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["coperbancseleccionado"] = _P_Str_tipooperacionbancaria;
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["cseleccionado"] = _G_Str_SeleccionadoManual;
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["cidcomprob"] = 0;
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["corder"] = 0;
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["estado"] = "0";
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["estadodescripcion"] = "";
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["cidedetalleconciliacion"] = _G_Int_Ciddetalleconciliacion;
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["ctipoajuste"] = _oTipoAjuste;
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro].AcceptChanges();
                    }
                }
            }

            //
            // - = - = - = - = - = - = - = - = - = - = - = - = Conciliamos el grid  - = - = - = - = - = - = - = - = - = - = - = - = 
            //
            foreach (var _RegistroSeleccionado in _RegistrosSeleccionados)
            {
                //Seleccciono
                _RegistroSeleccionado.Cells[0].Value = _G_Str_SeleccionadoManual;
                _RegistroSeleccionado.Cells[11].Value = _G_Int_Ciddetalleconciliacion;
                _RegistroSeleccionado.Cells["cconciliado"].Value = "1";
                _RegistroSeleccionado.Cells["cconciliadoAutomaticamente"].Value = "0";
                _RegistroSeleccionado.Cells["coperbancseleccionado"].Value = _P_Str_tipooperacionbancaria;
                //Coloreo toda la fila
                _RegistroSeleccionado.DefaultCellStyle.BackColor = Color.Khaki;
            }
        }


        private void _Mtd_DesconciliarManualmente()
        {
            //Obtenemos el codigo de los registros a desconciliar
            var _RegistroADesconciliar = _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().FirstOrDefault();

            //Validamos
            if (_RegistroADesconciliar == null) return;

            //Verificamos que todos los registros esten marcados como conciliados
            var _Bool_HayRegistrosSinConciliar = _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Any(x => x.Cells["cconciliado"].Value.ToString() == "0");
            if (_Bool_HayRegistrosSinConciliar)
            {
                MessageBox.Show("No se pueden desconciliar registros que no están conciliados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Obtenemos el id del registros a desconciliar
            var _Str_cidedetalleconciliacion = _RegistroADesconciliar.Cells["cidedetalleconciliacion"].Value.ToString();

            //Verificamos que todos los registros pertenezcan a la misma detalle de la conciliación
            var _Bool_HayRegistrosDeOtroDetalle = _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Any(x => x.Cells["cidedetalleconciliacion"].Value.ToString() != _Str_cidedetalleconciliacion);
            if (_Bool_HayRegistrosDeOtroDetalle)
            {
                MessageBox.Show("La selección de registros es inválida, seleccione solo el grupo de registros que esten ya conciliado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // - = - = - = - = - = - = - = - = - = - = - = - = Desconciliamos de la variable de trabajo  - = - = - = - = - = - = - = - = - = - = - = - = 
            DataRow[] _Dtw_FilasADesconciliar = _G_Ds_BancoLibro.Tables[0].Select("cidedetalleconciliacion='" + _Str_cidedetalleconciliacion + "'");
            foreach (var _Dtw_ItemActual in _Dtw_FilasADesconciliar)
            {
                //Actualizo el Dataset de BancoLibro
                int _Int_Index_ItemActual = _G_Ds_BancoLibro.Tables[0].Rows.IndexOf(_Dtw_ItemActual);
                string _Str_TipoReg = _Dtw_ItemActual["Tip.Reg."].ToString();
                if (_Str_TipoReg == "LIBRO")
                {
                    //-->Libro
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual]["cconciliado"] = "0";
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual]["cconciliadoAutomaticamente"] = "0";
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual]["coperbancseleccionado"] = "";
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual]["cdispband"] = 0;
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual]["cdispbanc"] = 0;
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual]["cseleccionado"] = _G_Str_NoSeleccionado;
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual]["estado"] = "0";
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual]["estadodescripcion"] = "";
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual]["cidedetalleconciliacion"] = 0;
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual]["ctipoajuste"] = 0;
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual].AcceptChanges();
                }
                else
                {
                    //-->Banco
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual]["cconciliado"] = "0";
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual]["cconciliadoAutomaticamente"] = "0";
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual]["coperbancseleccionado"] = "";
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual]["cseleccionado"] = _G_Str_NoSeleccionado;
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual]["cidcomprob"] = 0;
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual]["corder"] = 0;
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual]["estado"] = "0";
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual]["estadodescripcion"] = "";
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual]["cidedetalleconciliacion"] = 0;
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual]["ctipoajuste"] = 0;
                    _G_Ds_BancoLibro.Tables[0].Rows[_Int_Index_ItemActual].AcceptChanges();
                }
            }


            // - = - = - = - = - = - = - = - = - = - = - = - = Desconciliamos el grid  - = - = - = - = - = - = - = - = - = - = - = - = 

            //Selecciono las filas 
            List<DataGridViewRow> _Dtg_Filas = _Dtg_ConciliarBancoLibro.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["cidedetalleconciliacion"].Value.ToString() == _Str_cidedetalleconciliacion).ToList();
            if (_Dtg_Filas.Count > 0)
            {
                foreach (DataGridViewRow _Dgvr in _Dtg_Filas)
                {
                    //Deseleccciono
                    _Dgvr.Cells[0].Value = _G_Str_NoSeleccionado;
                    _Dgvr.Cells["cidedetalleconciliacion"].Value = 0;
                    _Dgvr.Cells["cconciliado"].Value = "0";
                    _Dgvr.Cells["cconciliadoAutomaticamente"].Value = "0";
                    _Dgvr.Cells["coperbancseleccionado"].Value = "";
                    _Dgvr.Cells["ctipoajuste"].Value = 0;
                    //Coloreo toda la fila
                    _Dgvr.DefaultCellStyle.BackColor = Color.White;
                }
                _Dtg_ConciliarBancoLibro.Refresh();
            }

        }

        private void _Dtg_ConciliarBancoLibro_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dtg_ConciliarBancoLibro.SelectedRows.Count == 1)
            {
                _Mtd_MarcarRegistrosConciliados(_Dtg_ConciliarBancoLibro.Rows[e.RowIndex].Cells["cidedetalleconciliacion"].Value.ToString());
            }
        }

        private void _Btn_ConciliarManualmente_Click(object sender, EventArgs e)
        {
            _Mtd_ConciliarManualmente("");
        }

        private void _Btn_DesConciliarManualmente_Click(object sender, EventArgs e)
        {
            _Mtd_DesconciliarManualmente();
        }

        public bool _Mtd_Guardar()
        {
            return false;
        }

        private void _Mtd_EliminarConciliacionesNoFinalizadas()
        {

            //Cargo las conciliaciones no finalizadas
            string _Str_Sql = "SELECT ciddisponibilidad FROM TDISPONIBILIDAD WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cbanco='" + _Cmb_BancoDetalle.SelectedValue.ToString() + "' and cnumcuenta='" +
                              _Cmb_CuentaDetalle.SelectedValue.ToString() + "' and cfinalizado=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //Verifico si se obtuvo algo
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                //Recorro 
                for (int intI = 0; intI < _Ds.Tables[0].Rows.Count; intI++)
                {
                    //Elimino los Detalles
                    _Str_Sql = "DELETE FROM TDISPONIBILIDADD WHERE ciddisponibilidad = " + _Ds.Tables[0].Rows[intI][0] + "AND ccompany='" + Frm_Padre._Str_Comp + "' ";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);

                    //Elimino las Maestras
                    _Str_Sql = "DELETE FROM TDISPONIBILIDAD WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cbanco='" + _Cmb_BancoDetalle.SelectedValue.ToString() + "' and cnumcuenta='" + _Cmb_CuentaDetalle.SelectedValue.ToString() + "' and cfinalizado=0";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);

                }
            }
        }

        private bool _Mtd_FinalizarConciliacion()
        {
            if (_Mtd_EsValidaDisponibilidadParaFinalizar())
            {
                //Marco el detalle de la conciliacion
                _Mtd_ActualizarSaldosDisponibilidad();

                //Marcamos los Estado de Cuenta de la Cuenta Conciliada 
                _Mtd_MarcarEstadosDeCuentaComoConciliado(Frm_Padre._Str_Comp, _Cmb_BancoDetalle.SelectedValue.ToString(), _Cmb_CuentaDetalle.SelectedValue.ToString());

                //Marco la conciliacion como finalizada
                string _Str_Sql = "UPDATE TDISPONIBILIDAD SET cfinalizado=1 WHERE ciddisponibilidad='" + _G_Int_ciddisponibilidad + "' and CCOMPANY='" + Frm_Padre._Str_Comp + "' ";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                return true;
            }
            else
            {
                Cursor = Cursors.Default;
                MessageBox.Show("No se puede finalizar la Disponibilida debido que la diferencia no es cero.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private void _Mtd_CrearDisponibilidad()
        {
            _Mtd_EliminarConciliacionesNoFinalizadas();

            //Obtenemos el ultimo id generado
            _G_Str_SentenciaSql = "SELECT ISNULL(MAX(ciddisponibilidad),0) FROM TDISPONIBILIDAD WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'";
            _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);
            var _Int_ciddisponibilidad = Convert.ToInt32(_G_Ds_DataSet.Tables[0].Rows[0][0].ToString());

            //Contamos uno mas
            _Int_ciddisponibilidad++;

            //Creamos la maestra de la disponibilidad
            _G_Str_SentenciaSql = "INSERT INTO [TDISPONIBILIDAD] (ciddisponibilidad,[ccompany],[cyearacco],[cmontacco],[cbanco],[cnumcuenta],[cfechadisponibilidad],[cimpreso],[cdateadd],[cuseradd],[cdelete],[cdispbanc],[cidconciliacion]) " +
    	                         " VALUES " +
                                 " ('" + _Int_ciddisponibilidad + "','" + Frm_Padre._Str_Comp + "','" + 
                                 _Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()) + "','" +
                                 _Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()) + "','" +
                                 _Cmb_BancoDetalle.SelectedValue.ToString() + "','" +
                                 _Cmb_CuentaDetalle.SelectedValue.ToString() + "',GETDATE(),0,GETDATE(),'" + Frm_Padre._Str_Use + "',0" +
                                  ",'" + _G_Int_cdispbanc + "'" +
                                  ",'" + _G_Int_cidconciliacion + "'" +
                                  ")";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSql);
            _G_Int_ciddisponibilidad = _Int_ciddisponibilidad; 

        }

        private bool _Mtd_GuardarDisponibilidad()
        {
            Cursor = Cursors.WaitCursor;
            if (_Mtd_Validar())
            {
                //Creo la Disponibilidad
                _Mtd_CrearDisponibilidad();

                //Guardamos el Detalle de la Conciliacion
                _Mtd_GuardarDetalleDeDisponibilidad();

                //Actualizamos los Saldos
                _Mtd_ActualizarSaldosDisponibilidad();

                _G_Bol_ModoGuardar = true;
                _G_Bol_ModoReporte = true;
                Cursor = Cursors.Default;
                return true;
            }
            else
            {
                string _Str_Mensaje = "";
                //if (_Er_Error.GetError(_Dtp_Hasta) != "")
                //{
                //    _Str_Mensaje += "\n -" + _Er_Error.GetError(_Dtp_Hasta);
                //}
                if (_Er_Error.GetError(_Lbl_BancoNoConciliado) != "")
                {
                    _Str_Mensaje += "\n -" + _Er_Error.GetError(_Lbl_BancoNoConciliado);
                }
                if (_Er_Error.GetError(_Lbl_LibroNoConciliado) != "")
                {
                    _Str_Mensaje += "\n -" + _Er_Error.GetError(_Lbl_LibroNoConciliado);
                }
                Cursor = Cursors.Default;
                MessageBox.Show("No se puede culminar la Disponibilidad debido a: " + _Str_Mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private ArrayList _Mtd_LlenarEstadoLibro()
        {
            var _myArrayList = new ArrayList();
            _myArrayList.Add(new _Cls_ArrayList("...", "nulo"));
            //Genero la Consulta
            DataSet _Ds;
            string _Str_Sql = "SELECT cestadoid, cdescrip_dispbanc  FROM TESTADOSCONC WHERE ctlibro = 1 order by cdescrip_dispbanc ";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //Si hay datos
            if (_Ds.Tables[0].Rows.Count > 0)
                foreach (DataRow _DRow in _Ds.Tables[0].Rows)
                {
                    _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString(), _DRow[0].ToString()));
                }
            return _myArrayList;
        }

        private ArrayList _Mtd_LlenarEstadoBanco()
        {
            var _myArrayList = new ArrayList();
            _myArrayList.Add(new _Cls_ArrayList("...", "nulo"));
            //Genero la Consulta
            DataSet _Ds;
            string _Str_Sql = "SELECT cestadoid, cdescrip_dispbanc  FROM TESTADOSCONC WHERE ctbanco = 1 order by cdescrip_dispbanc";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //Si hay datos
            if (_Ds.Tables[0].Rows.Count > 0)
                foreach (DataRow _DRow in _Ds.Tables[0].Rows)
                {
                    _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString(), _DRow[0].ToString()));
                }
            return _myArrayList;
        }

        private bool _Mtd_Validar()
        {
            _Er_Error.Dispose();
            bool _Bol_Valido = true;

            foreach (DataGridViewRow _Dtw_Fila in _Dtg_BancoNoConciliados.Rows)
            {
                if (_Dtw_Fila.Cells["estadoelegirbanco"].Value == null)
                {
                    if (_Bol_Valido)
                    {
                        _G_Int_Paso = 2;
                        _Tab_PasosConciliacion.SelectedIndex = 1;
                    }
                    _Bol_Valido = false;
                    _Er_Error.SetError(_Lbl_BancoNoConciliado, "Debe ingresar el estado en todos los registros del banco no conciliados");
                    break;
                }
                else if (_Dtw_Fila.Cells["estadoelegirbanco"].Value.ToString() == "nulo")
                {
                    if (_Bol_Valido)
                    {
                        _G_Int_Paso = 2;
                        _Tab_PasosConciliacion.SelectedIndex = 1;
                    }
                    _Bol_Valido = false;
                    _Er_Error.SetError(_Lbl_BancoNoConciliado, "Debe ingresar el estado en todos los registros del banco no conciliados");
                    break;
                }
                else if (_Dtw_Fila.Cells["estadoelegirbanco"].Value.ToString() == "0")
                {
                    if (_Bol_Valido)
                    {
                        _G_Int_Paso = 2;
                        _Tab_PasosConciliacion.SelectedIndex = 1;
                    }
                    _Bol_Valido = false;
                    _Er_Error.SetError(_Lbl_BancoNoConciliado, "Debe ingresar el estado en todos los registros del banco no conciliados");
                    break;
                }
            }

            foreach (DataGridViewRow _Dtw_Fila in _Dtg_MayorAnalitico.Rows)
            {
                if (_Dtw_Fila.Cells["comboestadolibro"].Value == null)
                {
                    if (_Bol_Valido)
                    {
                        _G_Int_Paso = 3;
                        _Tab_PasosConciliacion.SelectedIndex = 2;
                    }
                    _Bol_Valido = false;
                    _Er_Error.SetError(_Lbl_LibroNoConciliado, "Debe ingresar el estado en todos los registros del libro no conciliados");
                    break;
                }
                else if (_Dtw_Fila.Cells["comboestadolibro"].Value.ToString() == "nulo")
                {
                    if (_Bol_Valido)
                    {
                        _G_Int_Paso = 3;
                        _Tab_PasosConciliacion.SelectedIndex = 2;
                    }
                    _Bol_Valido = false;
                    _Er_Error.SetError(_Lbl_LibroNoConciliado, "Debe ingresar el estado en todos los registros del libro no conciliados");
                    break;
                }
                else if (_Dtw_Fila.Cells["comboestadolibro"].Value.ToString() == "0")
                {
                    if (_Bol_Valido)
                    {
                        _G_Int_Paso = 3;
                        _Tab_PasosConciliacion.SelectedIndex = 2;
                    }
                    _Bol_Valido = false;
                    _Er_Error.SetError(_Lbl_LibroNoConciliado, "Debe ingresar el estado en todos los registros del libro no conciliados");
                    break;
                }
            }
            return _Bol_Valido;
        }

        private void _Mtd_MarcarEstadosDeCuentaComoConciliado(string _P_Str_Compania, string _P_Str_IDBanco, string _P_Str_NumCuenta)
        {
            _G_Str_SentenciaSql = "UPDATE TEDOCUENTADISPM SET CCONCILIADO='1',CDATEUPD=GETDATE(),CUSERUPD='" + Frm_Padre._Str_Use + "' WHERE CCOMPANY='" + _P_Str_Compania + "' AND cbanco='" + _P_Str_IDBanco +
                                  "' AND cnumcuenta='" + _P_Str_NumCuenta + "' AND CCONCILIADO=0 and cdelete=0";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSql);
        }
        private void _Mtd_ObtenerEstadoDeCuentaAUsar()
        {
            var _Str_Compania = Frm_Padre._Str_Comp;
            var _Str_IdBanco = _Cmb_BancoDetalle.SelectedValue.ToString();
            var _Str_NumCuenta = _Cmb_CuentaDetalle.SelectedValue.ToString();
            var _Str_SentenciaSql = "SELECT cdispbanc FROM TEDOCUENTADISPM WHERE CCOMPANY='" + _Str_Compania + "' AND cbanco='" + _Str_IdBanco + "' AND cnumcuenta='" + _Str_NumCuenta + "' AND CCONCILIADO=0 and cdelete=0 and cregistroinicial='0' ";
            var _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSql);
            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
            {
                _G_Str_cdispbanc = _Ds_DataSet.Tables[0].Rows[0][0].ToString();
            }
        }

        private void _Mtd_GuardarDetalleDeDisponibilidad()
        {
            var _Registros = _G_Ds_BancoLibro.Tables[0].AsEnumerable();
            if (_Registros.Any())
            {
                var _Dt_ = _Registros.CopyToDataTable();
                foreach (DataRow _Dtw_Fila in _Dt_.Rows)
                {
                    var _Str_Estado = "";
                    if (_Dtw_Fila["cconciliado"].ToString() == "1") 
                        _Str_Estado = "0";
                    else 
                        _Str_Estado = _Dtw_Fila["estado"].ToString();

                    var _Str_TipoDetalle = "";
                    //Banco
                    if (_Dtw_Fila["Tip.Reg."].ToString().ToUpper() == "BANCO")
                    {
                        _Str_TipoDetalle = ((byte) _Cls_RutinasConciliacion._TipoDetalle.Banco).ToString(CultureInfo.InvariantCulture);
                    }
                    //Libro
                    if (_Dtw_Fila["Tip.Reg."].ToString().ToUpper() == "LIBRO" && _Dtw_Fila["cidconciliacion"].ToString().ToUpper() != "0" && _Dtw_Fila["cestadoid"].ToString().ToUpper() != "-1")
                    {
                        _Str_TipoDetalle = ((byte)_Cls_RutinasConciliacion._TipoDetalle.Libro).ToString(CultureInfo.InvariantCulture);
                    }
                    //Mayor Analitico
                    if (_Dtw_Fila["Tip.Reg."].ToString().ToUpper() == "LIBRO" && _Dtw_Fila["cidconciliacion"].ToString().ToUpper() == _G_Int_cidconciliacion.ToString(CultureInfo.InvariantCulture) && _Dtw_Fila["cestadoid"].ToString().ToUpper() == "-1")
                    {
                        _Str_TipoDetalle = ((byte)_Cls_RutinasConciliacion._TipoDetalle.MayorAnalitico).ToString(CultureInfo.InvariantCulture);
                    }

                    //Guardamos
                    _G_Str_SentenciaSql = "INSERT INTO TDISPONIBILIDADD(ciddisponibilidad,CCOMPANY,CIDDISPBAND,CIDDISPBANC,CIDCOMPROB,CORDER,CESTADO,CDATEADD,CUSERADD,CDELETE,CTIPODETALLE,CENTREGADO)";
                    _G_Str_SentenciaSql += " VALUES ('" + _G_Int_ciddisponibilidad + "','" + Frm_Padre._Str_Comp + "','" +
                                           _Dtw_Fila["cdispband"].ToString() + "','" + _Dtw_Fila["cdispbanc"].ToString() + "','" +
                                           _Dtw_Fila["cidcomprob"].ToString() + "','" + _Dtw_Fila["corder"].ToString() + "','" +
                                           _Str_Estado + "',GETDATE(),'" + Frm_Padre._Str_Use + "',0,'" + _Str_TipoDetalle + "','" + _Dtw_Fila["centregado"].ToString() + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSql);
                }
            }
        }

        private void _Mtd_ObtenerMontosPorEstadoConciliacion(out decimal _P_Dec_CDEPOSITOSDELDIA
                                                           , out decimal _P_Dec_CNOTASDEBITODELDIA
                                                           , out decimal _P_Dec_CREVERSOSDECHEQUEYOTROS
                                                           , out decimal _P_Dec_CCHEQUESEMITIDOS
                                                           , out decimal _P_Dec_CDEPOSITOSENBANCONOREGISTRADASENLIBRO
                                                           , out decimal _P_Dec_CNDENBANCONOREGISTRADASENLIBRO
                                                           , out decimal _P_Dec_CNCENBANCONOREGISTRADASENLIBRO
            )
        {
            decimal _Dec_CDEPOSITOSDELDIA = 0;
            decimal _Dec_CNOTASDEBITODELDIA = 0;
            decimal _Dec_CREVERSOSDECHEQUEYOTROS = 0;
            decimal _Dec_CCHEQUESEMITIDOS = 0;
            decimal _Dec_CDEPOSITOSENBANCONOREGISTRADASENLIBRO = 0;
            decimal _Dec_CNDENBANCONOREGISTRADASENLIBRO = 0;
            decimal _Dec_CNCENBANCONOREGISTRADASENLIBRO = 0;

            //Cargamos de los estados que selecciono el usuario en el grid del mayor analitico
            //Registros de Libro
            var _Registros_Libro = _G_Ds_BancoLibro.Tables[0].AsEnumerable().Where(x => x["Tip.Reg."].ToString().ToUpper() == "LIBRO" && 
                                                                                   x["cidconciliacion"].ToString() == _G_Int_cidconciliacion.ToString(CultureInfo.InvariantCulture) &&
                                                                                   x["cestadoid"].ToString().ToUpper() == "-1"
                                                                                   );
            if (_Registros_Libro.Any())
            {
                var _Dt_Libro = _Registros_Libro.CopyToDataTable();
                foreach (DataRow _Dtw_Fila in _Dt_Libro.Rows)
                {
                    switch (_Dtw_Fila["estado"].ToString())
                    {
                        case "4":
                            _Dec_CCHEQUESEMITIDOS += (Convert.ToDecimal(_Dtw_Fila["Monto"].ToString()));
                            break;
                        case "7":
                            _Dec_CNOTASDEBITODELDIA += (Convert.ToDecimal(_Dtw_Fila["Monto"].ToString()));
                            break;
                        case "6":
                            _Dec_CREVERSOSDECHEQUEYOTROS += (Convert.ToDecimal(_Dtw_Fila["Monto"].ToString()));
                            break;
                        case "5":
                            _Dec_CDEPOSITOSDELDIA += (Convert.ToDecimal(_Dtw_Fila["Monto"].ToString()));
                            break;
                        default:
                            break;
                    }
                }
            }

            //Registros de Banco    
            var _Registros_Banco = _G_Ds_BancoLibro.Tables[0].AsEnumerable().Where(x => x["Tip.Reg."].ToString().ToUpper() == "BANCO");
            if (_Registros_Banco.Any())
            {
                var _Dt_Banco = _Registros_Banco.CopyToDataTable();
                foreach (DataRow _Dtw_Fila in _Dt_Banco.Rows)
                {
                    //Si no esta conciliado acumulo
                    if (_Dtw_Fila["cconciliado"].ToString() != "1")
                    {
                        switch (_Dtw_Fila["estado"].ToString())
                        {
                            case "1":
                                _Dec_CDEPOSITOSENBANCONOREGISTRADASENLIBRO += (Convert.ToDecimal(_Dtw_Fila["Monto"].ToString()));
                                break;
                            case "2":
                                _Dec_CNDENBANCONOREGISTRADASENLIBRO += (Convert.ToDecimal(_Dtw_Fila["Monto"].ToString()));
                                break;
                            case "3":
                                _Dec_CNCENBANCONOREGISTRADASENLIBRO += (Convert.ToDecimal(_Dtw_Fila["Monto"].ToString()));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            //devuelvo
            _P_Dec_CDEPOSITOSDELDIA = _Dec_CDEPOSITOSDELDIA;
            _P_Dec_CNOTASDEBITODELDIA = _Dec_CNOTASDEBITODELDIA;
            _P_Dec_CREVERSOSDECHEQUEYOTROS = _Dec_CREVERSOSDECHEQUEYOTROS;
            _P_Dec_CCHEQUESEMITIDOS = _Dec_CCHEQUESEMITIDOS;

            _P_Dec_CDEPOSITOSENBANCONOREGISTRADASENLIBRO = _Dec_CDEPOSITOSENBANCONOREGISTRADASENLIBRO;
            _P_Dec_CNDENBANCONOREGISTRADASENLIBRO = _Dec_CNDENBANCONOREGISTRADASENLIBRO;
            _P_Dec_CNCENBANCONOREGISTRADASENLIBRO = _Dec_CNCENBANCONOREGISTRADASENLIBRO;

        }

        private void _Mtd_CalcularSaldosDisponibilidad(out decimal  _P_Dec_CSALDOANTERIORLIBRO ,
                                                       out decimal _P_Dec_CDEPOSITOSDELDIA,
                                                       out decimal _P_Dec_CNOTASDEBITODELDIA,
                                                       out decimal _P_Dec_CREVERSOSDECHEQUEYOTROS,
                                                       out decimal _P_Dec_CCHEQUESEMITIDOS,
                                                       out decimal _P_Dec_CSALDOACTUALLIBRO,
                                                       out decimal _P_Dec_CCHEQUESPOSTFECHADOS,
                                                       out decimal _P_Dec_CSALDODISPONIBLESEGUNLIBRO,
                                                       out decimal _P_Dec_CSALDODISPONIBLESEGUNBANCO,
                                                       out decimal _P_Dec_CSALDODIFERIDOENBANCO,
                                                       out decimal _P_Dec_CSALDOREALENBANCO,
                                                       out decimal _P_Dec_CCHEQUESENTREGADOSNOCONCILIADOS,
                                                       out decimal _P_Dec_CDISPONIBLE,
                                                       out decimal _P_Dec_CDEPOSITOSENLIBRONOREGISTRADOSENBANCO,
                                                       out decimal _P_Dec_CNCENLIBRONOREGISTRADASENBANCO,
                                                       out decimal _P_Dec_CNDENLIBRONOREGISTRADASENBANCO,
                                                       out decimal _P_Dec_CDEPOSITOSENBANCONOREGISTRADASENLIBRO,
                                                       out decimal _P_Dec_CNDENBANCONOREGISTRADASENLIBRO,
                                                       out decimal _P_Dec_CNCENBANCONOREGISTRADASENLIBRO,
                                                       out decimal _P_Dec_CTOTALPARTIDASENCONCILIACION,
                                                       out decimal _P_Dec_CSALDODELIBRO,
                                                       out decimal _P_Dec_CDIFERENCIA
            )
        {
            decimal _Dec_CSALDOANTERIORLIBRO = 0;
            decimal _Dec_CDEPOSITOSDELDIA = 0;
            decimal _Dec_CNOTASDEBITODELDIA = 0;
            decimal _Dec_CREVERSOSDECHEQUEYOTROS = 0;
            decimal _Dec_CCHEQUESEMITIDOS = 0;
            decimal _Dec_CSALDOACTUALLIBRO = 0;
            decimal _Dec_CCHEQUESNOENTREGADOSNOCONCILIADOS = 0;
            decimal _Dec_CSALDODISPONIBLESEGUNLIBRO = 0;
            decimal _Dec_CSALDODISPONIBLESEGUNBANCO = 0;
            decimal _Dec_CSALDODIFERIDOENBANCO = 0;
            decimal _Dec_CSALDOREALENBANCO = 0;
            decimal _Dec_CCHEQUESENTREGADOSNOCONCILIADOS = 0;
            decimal _Dec_CDISPONIBLE = 0;
            decimal _Dec_CDEPOSITOSENLIBRONOREGISTRADOSENBANCO = 0;
            decimal _Dec_CNCENLIBRONOREGISTRADASENBANCO = 0;
            decimal _Dec_CNDENLIBRONOREGISTRADASENBANCO = 0;
            decimal _Dec_CDEPOSITOSENBANCONOREGISTRADASENLIBRO = 0;
            decimal _Dec_CNDENBANCONOREGISTRADASENLIBRO = 0;
            decimal _Dec_CNCENBANCONOREGISTRADASENLIBRO = 0;

            decimal _Dec_CDEPOSITOSENBANCONOREGISTRADASENLIBRO_DESCONTAR = 0;
            decimal _Dec_CNDENBANCONOREGISTRADASENLIBRO_DESCONTAR = 0;
            decimal _Dec_CNCENBANCONOREGISTRADASENLIBRO_DESCONTAR = 0;
            
            decimal _Dec_CTOTALPARTIDASENCONCILIACION = 0;
            decimal _Dec_CSALDODELIBRO = 0;
            decimal _Dec_CDIFERENCIA = 0;


            //Obtenemos los datos no guardados de la conciliacion
            _G_Str_SentenciaSql = "SELECT cidconciliacion,CONVERT(VARCHAR,TCONCILIACION.cfechadesde,103) AS [FechaDesde], CONVERT(VARCHAR,TCONCILIACION.cfechahasta,103) AS [FechaHasta], cbanco, cnumcuenta, csaldosegunlibro, csaldoinicialsegunlibro FROM TCONCILIACION WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' and cidconciliacion = '" + _G_Int_cidconciliacion + "'";
            var _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);
            var _Dc_SaldoLibroDesde = Convert.ToDecimal(_Ds_DataSet.Tables[0].Rows[0]["csaldoinicialsegunlibro"]);

            //Cargamos la conciliacion asociada
            var _Str_Sql = "SELECT " +
                       "isnull(ctotaldnreb,0) AS CDEPOSITOSENLIBRONOREGISTRADOSENBANCO" +
                       ",isnull(ctotalncnreb,0) AS CNCENLIBRONOREGISTRADASENBANCO" +
                       ",isnull(ctotalndnreb,0) AS CNDENLIBRONOREGISTRADASENBANCO" +
                       ",isnull(ctotaldnrel,0) AS CDEPOSITOSENBANCONOREGISTRADASENLIBRO" +
                       ",isnull(ctotalndnrel,0) AS CNDENBANCONOREGISTRADASENLIBRO" +
                       ",(isnull(ctotaldnreb,0) + isnull(ctotalncnreb,0) + isnull(ctotalndnreb,0) + isnull(ctotaldnrel,0) + isnull(ctotalndnrel,0)) AS CTOTALPARTIDASENCONCILIACION " +
                       "FROM TCONCILIACION WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CIDCONCILIACION='" + _G_Int_cidconciliacion + "' ";
            var _Ds_Conciliacion = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Conciliacion.Tables[0].Rows.Count > 0)
            {
                _Dec_CSALDOANTERIORLIBRO = _Dc_SaldoLibroDesde;
                _Dec_CDEPOSITOSENLIBRONOREGISTRADOSENBANCO = Convert.ToDecimal(_Ds_Conciliacion.Tables[0].Rows[0]["CDEPOSITOSENLIBRONOREGISTRADOSENBANCO"]);
                _Dec_CNCENLIBRONOREGISTRADASENBANCO = Convert.ToDecimal(_Ds_Conciliacion.Tables[0].Rows[0]["CNCENLIBRONOREGISTRADASENBANCO"]);
                _Dec_CNDENLIBRONOREGISTRADASENBANCO = Convert.ToDecimal(_Ds_Conciliacion.Tables[0].Rows[0]["CNDENLIBRONOREGISTRADASENBANCO"]);
                _Dec_CDEPOSITOSENBANCONOREGISTRADASENLIBRO = Convert.ToDecimal(_Ds_Conciliacion.Tables[0].Rows[0]["CDEPOSITOSENBANCONOREGISTRADASENLIBRO"]);
                _Dec_CNDENBANCONOREGISTRADASENLIBRO = Convert.ToDecimal(_Ds_Conciliacion.Tables[0].Rows[0]["CNDENBANCONOREGISTRADASENLIBRO"]);
            }

            //Obtenemos los datos de la conciliacion pasada
            _Mtd_ObtenerMontosPorEstadoConciliacion(out _Dec_CDEPOSITOSDELDIA
                                                    , out _Dec_CNOTASDEBITODELDIA
                                                    , out _Dec_CREVERSOSDECHEQUEYOTROS
                                                    , out _Dec_CCHEQUESEMITIDOS
                                                    , out _Dec_CDEPOSITOSENBANCONOREGISTRADASENLIBRO_DESCONTAR
                                                    , out _Dec_CNDENBANCONOREGISTRADASENLIBRO_DESCONTAR
                                                    , out _Dec_CNCENBANCONOREGISTRADASENLIBRO_DESCONTAR
                                                    );

            //Descontamos los registro del estado de cuenta actual
            _Dec_CDEPOSITOSENBANCONOREGISTRADASENLIBRO -= _Dec_CDEPOSITOSENBANCONOREGISTRADASENLIBRO_DESCONTAR;
            _Dec_CNDENBANCONOREGISTRADASENLIBRO -= _Dec_CNDENBANCONOREGISTRADASENLIBRO_DESCONTAR;
            _Dec_CNCENBANCONOREGISTRADASENLIBRO -= _Dec_CNCENBANCONOREGISTRADASENLIBRO_DESCONTAR;

            _Dec_CSALDOACTUALLIBRO = _Dec_CSALDOANTERIORLIBRO + _Dec_CDEPOSITOSDELDIA + _Dec_CNOTASDEBITODELDIA + _Dec_CREVERSOSDECHEQUEYOTROS + _Dec_CCHEQUESEMITIDOS;
            _Dec_CCHEQUESNOENTREGADOSNOCONCILIADOS = _G_Dtv_RegistrosChequesPendientes.Table.AsEnumerable().Where(x => x["Tip.Reg."].ToString().ToUpper() == "LIBRO" && x["cconciliado"].ToString() == "0" && x["centregado"].ToString() == "0").Sum(x => Convert.ToDecimal(x["Monto"]));
            _Dec_CSALDODISPONIBLESEGUNLIBRO = _Dec_CSALDOACTUALLIBRO - _Dec_CCHEQUESNOENTREGADOSNOCONCILIADOS;

            double _Dbl_SaldoInicialBancoConsulta = 0;
            double _Dbl_SaldoFinalBancoConsulta = 0;
            double _Dbl_MontoBloqueadoFinalConsulta = 0;
            double _Dbl_MontoDisponibleFinalConsulta = 0;
            double _Dbl_MontoSaldoRealFinalConsulta = 0;

            //Calculo Saldos
            _Cls_RutinasConciliacion._Mtd_ObtenerSaldosEstadoDeCuentaDisponibilidad(_Cmb_BancoDetalle.SelectedValue.ToString(), _Cmb_CuentaDetalle.SelectedValue.ToString(), out _Dbl_SaldoInicialBancoConsulta, out _Dbl_SaldoFinalBancoConsulta, out  _Dbl_MontoBloqueadoFinalConsulta, out _Dbl_MontoSaldoRealFinalConsulta, out _Dbl_MontoDisponibleFinalConsulta);

            _Dec_CSALDODISPONIBLESEGUNBANCO = Convert.ToDecimal(_Dbl_MontoDisponibleFinalConsulta);
            _Dec_CSALDODIFERIDOENBANCO = Convert.ToDecimal(_Dbl_MontoBloqueadoFinalConsulta);
            _Dec_CSALDOREALENBANCO = _Dec_CSALDODISPONIBLESEGUNBANCO + _Dec_CSALDODIFERIDOENBANCO;

            _Dec_CCHEQUESENTREGADOSNOCONCILIADOS = _G_Dtv_RegistrosChequesPendientes.Table.AsEnumerable().Where(x => x["Tip.Reg."].ToString().ToUpper() == "LIBRO" && x["cconciliado"].ToString() == "0" && x["centregado"].ToString() == "1").Sum(x => Convert.ToDecimal(x["Monto"]));


            _Dec_CDISPONIBLE = _Dec_CSALDOREALENBANCO + _Dec_CCHEQUESENTREGADOSNOCONCILIADOS;


            //Colocamos los signos

            //Totalizamos
            _Dec_CTOTALPARTIDASENCONCILIACION = _Dec_CDEPOSITOSENLIBRONOREGISTRADOSENBANCO 
                                              + _Dec_CNCENLIBRONOREGISTRADASENBANCO 
                                              + _Dec_CNDENLIBRONOREGISTRADASENBANCO 
                                              + _Dec_CDEPOSITOSENBANCONOREGISTRADASENLIBRO 
                                              + _Dec_CNDENBANCONOREGISTRADASENLIBRO
                                              + _Dec_CNCENBANCONOREGISTRADASENLIBRO
                                              ;

            _Dec_CSALDODELIBRO = _Dec_CDISPONIBLE + _Dec_CTOTALPARTIDASENCONCILIACION;

            _Dec_CDIFERENCIA = _Dec_CSALDODELIBRO - _Dec_CSALDODISPONIBLESEGUNLIBRO;

            //Pasamos los valores
            _P_Dec_CSALDOANTERIORLIBRO = _Dec_CSALDOANTERIORLIBRO;
            _P_Dec_CDEPOSITOSDELDIA = _Dec_CDEPOSITOSDELDIA;
            _P_Dec_CNOTASDEBITODELDIA = _Dec_CNOTASDEBITODELDIA;
            _P_Dec_CREVERSOSDECHEQUEYOTROS = _Dec_CREVERSOSDECHEQUEYOTROS;
            _P_Dec_CCHEQUESEMITIDOS = _Dec_CCHEQUESEMITIDOS;
            _P_Dec_CSALDOACTUALLIBRO = _Dec_CSALDOACTUALLIBRO;
            _P_Dec_CCHEQUESPOSTFECHADOS = _Dec_CCHEQUESNOENTREGADOSNOCONCILIADOS;
            _P_Dec_CSALDODISPONIBLESEGUNLIBRO = _Dec_CSALDODISPONIBLESEGUNLIBRO;
            _P_Dec_CSALDODISPONIBLESEGUNBANCO = _Dec_CSALDODISPONIBLESEGUNBANCO;
            _P_Dec_CSALDODIFERIDOENBANCO = _Dec_CSALDODIFERIDOENBANCO;
            _P_Dec_CSALDOREALENBANCO = _Dec_CSALDOREALENBANCO;
            _P_Dec_CCHEQUESENTREGADOSNOCONCILIADOS = _Dec_CCHEQUESENTREGADOSNOCONCILIADOS;
            _P_Dec_CDISPONIBLE = _Dec_CDISPONIBLE;
            _P_Dec_CDEPOSITOSENLIBRONOREGISTRADOSENBANCO = _Dec_CDEPOSITOSENLIBRONOREGISTRADOSENBANCO;
            _P_Dec_CNCENLIBRONOREGISTRADASENBANCO = _Dec_CNCENLIBRONOREGISTRADASENBANCO;
            _P_Dec_CNDENLIBRONOREGISTRADASENBANCO = _Dec_CNDENLIBRONOREGISTRADASENBANCO;
            _P_Dec_CDEPOSITOSENBANCONOREGISTRADASENLIBRO = _Dec_CDEPOSITOSENBANCONOREGISTRADASENLIBRO;
            _P_Dec_CNDENBANCONOREGISTRADASENLIBRO = _Dec_CNDENBANCONOREGISTRADASENLIBRO;
            _P_Dec_CNCENBANCONOREGISTRADASENLIBRO = _Dec_CNCENBANCONOREGISTRADASENLIBRO;
            _P_Dec_CTOTALPARTIDASENCONCILIACION = _Dec_CTOTALPARTIDASENCONCILIACION;
            _P_Dec_CSALDODELIBRO = _Dec_CSALDODELIBRO;
            _P_Dec_CDIFERENCIA = _Dec_CDIFERENCIA;

        }

        private void _Mtd_ActualizarSaldosDisponibilidad()
        {
            decimal _Dec_CSALDOANTERIORLIBRO = 0;
            decimal _Dec_CDEPOSITOSDELDIA = 0;
            decimal _Dec_CNOTASDEBITODELDIA = 0;
            decimal _Dec_CREVERSOSDECHEQUEYOTROS = 0;
            decimal _Dec_CCHEQUESEMITIDOS = 0;
            decimal _Dec_CSALDOACTUALLIBRO = 0;
            decimal _Dec_CCHEQUESPOSTFECHADOS = 0;
            decimal _Dec_CSALDODISPONIBLESEGUNLIBRO = 0;
            decimal _Dec_CSALDODISPONIBLESEGUNBANCO = 0;
            decimal _Dec_CSALDODIFERIDOENBANCO = 0;
            decimal _Dec_CSALDOREALENBANCO = 0;
            decimal _Dec_CCHEQUESENTREGADOSNOCONCILIADOS = 0;
            decimal _Dec_CDISPONIBLE = 0;
            decimal _Dec_CDEPOSITOSENLIBRONOREGISTRADOSENBANCO = 0;
            decimal _Dec_CNCENLIBRONOREGISTRADASENBANCO = 0;
            decimal _Dec_CNDENLIBRONOREGISTRADASENBANCO = 0;
            decimal _Dec_CDEPOSITOSENBANCONOREGISTRADASENLIBRO = 0;
            decimal _Dec_CNDENBANCONOREGISTRADASENLIBRO = 0;
            decimal _Dec_CNCENBANCONOREGISTRADASENLIBRO = 0;
            decimal _Dec_CTOTALPARTIDASENCONCILIACION = 0;
            decimal _Dec_CSALDODELIBRO = 0;
            decimal _Dec_CDIFERENCIA = 0;

            //Obtenemos los saldos
            _Mtd_CalcularSaldosDisponibilidad(out _Dec_CSALDOANTERIORLIBRO ,
                                              out _Dec_CDEPOSITOSDELDIA ,
                                              out _Dec_CNOTASDEBITODELDIA ,
                                              out _Dec_CREVERSOSDECHEQUEYOTROS ,
                                              out _Dec_CCHEQUESEMITIDOS ,
                                              out _Dec_CSALDOACTUALLIBRO ,
                                              out _Dec_CCHEQUESPOSTFECHADOS ,
                                              out _Dec_CSALDODISPONIBLESEGUNLIBRO ,
                                              out _Dec_CSALDODISPONIBLESEGUNBANCO ,
                                              out _Dec_CSALDODIFERIDOENBANCO ,
                                              out _Dec_CSALDOREALENBANCO ,
                                              out _Dec_CCHEQUESENTREGADOSNOCONCILIADOS,
                                              out _Dec_CDISPONIBLE ,
                                              out _Dec_CDEPOSITOSENLIBRONOREGISTRADOSENBANCO ,
                                              out _Dec_CNCENLIBRONOREGISTRADASENBANCO ,
                                              out _Dec_CNDENLIBRONOREGISTRADASENBANCO ,
                                              out _Dec_CDEPOSITOSENBANCONOREGISTRADASENLIBRO ,
                                              out _Dec_CNDENBANCONOREGISTRADASENLIBRO ,
                                              out _Dec_CNCENBANCONOREGISTRADASENLIBRO,
                                              out _Dec_CTOTALPARTIDASENCONCILIACION,
                                              out _Dec_CSALDODELIBRO ,
                                              out _Dec_CDIFERENCIA);


            //Genero la consulta de actualizacion
            _G_Str_SentenciaSql = "UPDATE TDISPONIBILIDAD SET ";
            _G_Str_SentenciaSql += "CSALDOANTERIORLIBRO='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDecimal(_Dec_CSALDOANTERIORLIBRO)) + "'";
            _G_Str_SentenciaSql += ",CDEPOSITOSDELDIA='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_CDEPOSITOSDELDIA) + "'";
            _G_Str_SentenciaSql += ",CNOTASDEBITODELDIA='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_CNOTASDEBITODELDIA) + "'";
            _G_Str_SentenciaSql += ",CREVERSOSDECHEQUEYOTROS='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_CREVERSOSDECHEQUEYOTROS) + "'";
            _G_Str_SentenciaSql += ",CCHEQUESEMITIDOS='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_CCHEQUESEMITIDOS) + "'";
            _G_Str_SentenciaSql += ",CSALDOACTUALLIBRO='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_CSALDOACTUALLIBRO) + "'";
            _G_Str_SentenciaSql += ",CCHEQUESPOSTFECHADOS='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_CCHEQUESPOSTFECHADOS) + "'";
            _G_Str_SentenciaSql += ",CSALDODISPONIBLESEGUNLIBRO='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_CSALDODISPONIBLESEGUNLIBRO) + "'";
            _G_Str_SentenciaSql += ",CSALDODISPONIBLESEGUNBANCO='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_CSALDODISPONIBLESEGUNBANCO) + "'";
            _G_Str_SentenciaSql += ",CSALDODIFERIDOENBANCO='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_CSALDODIFERIDOENBANCO) + "'";
            _G_Str_SentenciaSql += ",CSALDOREALENBANCO='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_CSALDOREALENBANCO) + "'";
            _G_Str_SentenciaSql += ",CCHEQUESENTREGADOSNOCONCILIADOS='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_CCHEQUESENTREGADOSNOCONCILIADOS) + "'";
            _G_Str_SentenciaSql += ",CDISPONIBLE='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_CDISPONIBLE) + "'";
            _G_Str_SentenciaSql += ",CDEPOSITOSENLIBRONOREGISTRADOSENBANCO='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_CDEPOSITOSENLIBRONOREGISTRADOSENBANCO) + "'";
            _G_Str_SentenciaSql += ",CNCENLIBRONOREGISTRADASENBANCO='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_CNCENLIBRONOREGISTRADASENBANCO) + "'";
            _G_Str_SentenciaSql += ",CNDENLIBRONOREGISTRADASENBANCO='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_CNDENLIBRONOREGISTRADASENBANCO) + "'";
            _G_Str_SentenciaSql += ",CDEPOSITOSENBANCONOREGISTRADASENLIBRO='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_CDEPOSITOSENBANCONOREGISTRADASENLIBRO) + "'";
            _G_Str_SentenciaSql += ",CNDENBANCONOREGISTRADASENLIBRO='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_CNDENBANCONOREGISTRADASENLIBRO) + "'";
            _G_Str_SentenciaSql += ",CNCENBANCONOREGISTRADASENLIBRO='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_CNCENBANCONOREGISTRADASENLIBRO) + "'";
            _G_Str_SentenciaSql += ",CTOTALPARTIDASENCONCILIACION='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_CTOTALPARTIDASENCONCILIACION) + "'";
            _G_Str_SentenciaSql += ",CSALDODELIBRO='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_CSALDODELIBRO) + "'";
            _G_Str_SentenciaSql += ",CDIFERENCIA='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_CDIFERENCIA) + "'";
            _G_Str_SentenciaSql += " WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND ciddisponibilidad='" + _G_Int_ciddisponibilidad + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSql);
        }

        /// <summary>
        /// Devuelve si es posible guardar o no la conciliacion
        /// </summary>
        /// <returns></returns>
        private bool _Mtd_EsValidaDisponibilidadParaFinalizar()
        {

            decimal _Dec_CSALDOANTERIORLIBRO = 0;
            decimal _Dec_CDEPOSITOSDELDIA = 0;
            decimal _Dec_CNOTASDEBITODELDIA = 0;
            decimal _Dec_CREVERSOSDECHEQUEYOTROS = 0;
            decimal _Dec_CCHEQUESEMITIDOS = 0;
            decimal _Dec_CSALDOACTUALLIBRO = 0;
            decimal _Dec_CCHEQUESPOSTFECHADOS = 0;
            decimal _Dec_CSALDODISPONIBLESEGUNLIBRO = 0;
            decimal _Dec_CSALDODISPONIBLESEGUNBANCO = 0;
            decimal _Dec_CSALDODIFERIDOENBANCO = 0;
            decimal _Dec_CSALDOREALENBANCO = 0;
            decimal _Dec_CCHEQUESENTREGADOSNOCONCILIADOS = 0;
            decimal _Dec_CDISPONIBLE = 0;
            decimal _Dec_CDEPOSITOSENLIBRONOREGISTRADOSENBANCO = 0;
            decimal _Dec_CNCENLIBRONOREGISTRADASENBANCO = 0;
            decimal _Dec_CNDENLIBRONOREGISTRADASENBANCO = 0;
            decimal _Dec_CDEPOSITOSENBANCONOREGISTRADASENLIBRO = 0;
            decimal _Dec_CNDENBANCONOREGISTRADASENLIBRO = 0;
            decimal _Dec_CNCENBANCONOREGISTRADASENLIBRO = 0;
            decimal _Dec_CTOTALPARTIDASENCONCILIACION = 0;
            decimal _Dec_CSALDODELIBRO = 0;
            decimal _Dec_CDIFERENCIA = 0;

            //Obtenemos los saldos
            _Mtd_CalcularSaldosDisponibilidad(out _Dec_CSALDOANTERIORLIBRO,
                                              out _Dec_CDEPOSITOSDELDIA,
                                              out _Dec_CNOTASDEBITODELDIA,
                                              out _Dec_CREVERSOSDECHEQUEYOTROS,
                                              out _Dec_CCHEQUESEMITIDOS,
                                              out _Dec_CSALDOACTUALLIBRO,
                                              out _Dec_CCHEQUESPOSTFECHADOS,
                                              out _Dec_CSALDODISPONIBLESEGUNLIBRO,
                                              out _Dec_CSALDODISPONIBLESEGUNBANCO,
                                              out _Dec_CSALDODIFERIDOENBANCO,
                                              out _Dec_CSALDOREALENBANCO,
                                              out _Dec_CCHEQUESENTREGADOSNOCONCILIADOS,
                                              out _Dec_CDISPONIBLE,
                                              out _Dec_CDEPOSITOSENLIBRONOREGISTRADOSENBANCO,
                                              out _Dec_CNCENLIBRONOREGISTRADASENBANCO,
                                              out _Dec_CNDENLIBRONOREGISTRADASENBANCO,
                                              out _Dec_CDEPOSITOSENBANCONOREGISTRADASENLIBRO,
                                              out _Dec_CNDENBANCONOREGISTRADASENLIBRO,
                                              out _Dec_CNCENBANCONOREGISTRADASENLIBRO,
                                              out _Dec_CTOTALPARTIDASENCONCILIACION,
                                              out _Dec_CSALDODELIBRO,
                                              out _Dec_CDIFERENCIA);

            //Redondeo
            _Dec_CDIFERENCIA = Math.Round(_Dec_CDIFERENCIA, 2);

            //Devuelvo
            var bResultado = (_Dec_CDIFERENCIA == 0);
            return bResultado;
        }


        private void _Mtd_MostrarReporteConciliacion(int _P_Int_ciddisponibilidad, string _P_Str_Compania)
        {
            var _Str_CNOMEMP = "";
            var _Str_CBANCO = "";
            var _Str_CNUMCUENTA = "";
            var _Str_CFECHA = "";

            _Rpt_ReporteConciliacion.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_ReporteConciliacion.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_DisponibilidadBancaria";

            //Obtenemos el Nombre de la compañia
            var _Str_Cadena = "Select cname from TCOMPANY where ccompany='" + _P_Str_Compania + "'";
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            _Str_CNOMEMP = _Ds.Tables[0].Rows[0][0].ToString().TrimEnd();
            
            //Obtenemos banco y numero de cuenta
            _Str_Cadena = "SELECT TBANCO.cbanco, TBANCO.cname AS cnombrebanco, TDISPONIBILIDAD.cnumcuenta, TDISPONIBILIDAD.cfechadisponibilidad " +
                          "FROM TBANCO INNER JOIN TDISPONIBILIDAD ON TBANCO.ccompany = TDISPONIBILIDAD.ccompany " +
                          "WHERE (TBANCO.cdelete = 0) AND (TDISPONIBILIDAD.cdelete = 0) AND (ciddisponibilidad = '" + _P_Int_ciddisponibilidad + "') AND (TDISPONIBILIDAD.ccompany = '" + _P_Str_Compania + "')";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_CBANCO = _Ds.Tables[0].Rows[0]["cnombrebanco"].ToString();
                _Str_CNUMCUENTA = _Ds.Tables[0].Rows[0]["cnumcuenta"].ToString();
                _Str_CFECHA = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechadisponibilidad"]).ToShortDateString();
            }

            var parm = new ReportParameter[6];
            parm[0] = new ReportParameter("CCOMPANY", _P_Str_Compania);
            parm[1] = new ReportParameter("CIDDISPONIBILIDAD", _P_Int_ciddisponibilidad.ToString(CultureInfo.InvariantCulture));
            parm[2] = new ReportParameter("CNOMEMP", _Str_CNOMEMP);
            parm[3] = new ReportParameter("CBANCO", _Str_CBANCO);
            parm[4] = new ReportParameter("CNUMCUENTA", _Str_CNUMCUENTA);
            parm[5] = new ReportParameter("CFECHA", _Str_CFECHA);

            _Rpt_ReporteConciliacion.ServerReport.SetParameters(parm);
            this._Rpt_ReporteConciliacion.ServerReport.Refresh();
            this._Rpt_ReporteConciliacion.RefreshReport();
        }

        private void _Dtg_Consulta_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dtg_Consulta.SelectedRows.Count == 1)
            {
                _G_Bol_ModoGuardar = false;
                _G_Bol_ModoConsulta = true;
                _G_Bol_ModoReporte = true;

                //Buscamos si ya esta impreso
                _G_Str_SentenciaSql = "SELECT CIMPRESO FROM TDISPONIBILIDAD WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND ciddisponibilidad='" + _Dtg_Consulta.Rows[e.RowIndex].Cells["Id Disponibilidad"].Value.ToString() + "' AND CIMPRESO='1'";
                _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);
                _G_Bol_Impreso = _G_Ds_DataSet.Tables[0].Rows.Count == 1;
                _Tab_Contenedor.SelectedIndex = 2;

                //Obtenemos el id de la conciliacion
                _G_Int_ciddisponibilidad = Convert.ToInt32(_Dtg_Consulta.Rows[e.RowIndex].Cells["Id Disponibilidad"].Value);

                //Obtenemos los valores de otros campos
                var _Str_SentenciaSql = "SELECT cdispbanc,cbanco,cnumcuenta,cfechadisponibilidad FROM TDISPONIBILIDAD WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND ciddisponibilidad='" + _G_Int_ciddisponibilidad + "' ";
                var _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSql);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    _G_Str_cdispbanc = _Ds_DataSet.Tables[0].Rows[0]["cdispbanc"].ToString().Trim();
                    _G_Str_cbanco = _Ds_DataSet.Tables[0].Rows[0]["cbanco"].ToString().Trim();
                    _G_Str_cnumcuenta = _Ds_DataSet.Tables[0].Rows[0]["cnumcuenta"].ToString().Trim();
                }

                //Me coloco en la pestaña reporte 
                _Tab_Contenedor.SelectedIndex = 2;
                //Muestro el reporte
                _Mtd_MostrarReporteConciliacion(_G_Int_ciddisponibilidad, Frm_Padre._Str_Comp);
                
                //Cambio el nombre del boton
                _Btn_AnteriorReporte.Visible = false;
                //Habilito el boton exportar
                _Rpt_ReporteConciliacion.ShowExportButton = true;
                _Btn_Finalizar.Text = "Imprimir";

                //Si la conciliación ya esta impresa, deshabilito el boton
                _Btn_Finalizar.Enabled = !_G_Bol_Impreso;

            }
        }

        private void _Dtg_ConciliarBancoLibro_Sorted(object sender, EventArgs e)
        {
            _Mtd_ColorGridConciliado();
        }

        private void _Dtg_BancoNoConciliados_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Si es la columna del combo
            if (e.ColumnIndex == 0)
            {
                //Verifico que sea valido la celda
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (!_G_EstamosSeteandoCombos)
                    {
                        //Obtengo el valor seleccionado
                        var strValor = this._Dtg_BancoNoConciliados.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        //En función al valor coloreo
                        if (strValor != "nulo")
                        {
                            this._Dtg_BancoNoConciliados.Rows[e.RowIndex].DefaultCellStyle.BackColor = _G_ColorInicialGrid;
                        }
                        else
                        {
                            this._Dtg_BancoNoConciliados.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                        }

                        //Si el valor el correcto
                        if ((strValor != "nulo") && (strValor != "T3.Clases._Cls_ArrayList") && (strValor != "..."))
                        {
                            string strId = this._Dtg_BancoNoConciliados.Rows[e.RowIndex].Cells["cdispband"].Value.ToString();
                            string strcdispbanc = this._Dtg_BancoNoConciliados.Rows[e.RowIndex].Cells["cdispbanc"].Value.ToString();

                            //Guardo la seleccion en el datasource del grid
                            var oFilasGrid = _G_Dt_BancoNoConciliado.Select("cdispband='" + strId + "' and cdispbanc='" + strcdispbanc + "'");
                            foreach (var oFila in oFilasGrid)
                            {
                                if (oFila["estado"].ToString() != strValor)
                                {
                                    oFila["estado"] = strValor;
                                }
                            }

                            //Guardo la seleccion en el datasource unificado
                            var oFilasUnificado = _G_Ds_BancoLibro.Tables[0].Select("cdispband='" + strId + "' and cdispbanc='" + strcdispbanc + "'");
                            foreach (var oFila in oFilasUnificado)
                            {
                                if (oFila["estado"].ToString() != strValor)
                                {
                                    oFila["estado"] = strValor;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void _Dtg_MayorAnalitico_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Si es la columna del combo
            if (e.ColumnIndex == 0)
            {
                //Verifico que sea valido la celda
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (!_G_EstamosSeteandoCombos)
                    {
                        //Obtengo el valor seleccionado
                        var strValor = this._Dtg_MayorAnalitico.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        //En función al valor coloreo
                        if (strValor != "nulo")
                        {
                            this._Dtg_MayorAnalitico.Rows[e.RowIndex].DefaultCellStyle.BackColor = _G_ColorInicialGrid;
                        }
                        else
                        {
                            this._Dtg_MayorAnalitico.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                        }

                        //Si el valor e valido
                        if ((strValor != "nulo") && (strValor != "T3.Clases._Cls_ArrayList") && (strValor != "..."))
                        {
                            //Guardo la seleccion en el datasource del grid
                            string strIdc = this._Dtg_MayorAnalitico.Rows[e.RowIndex].Cells["cidcomprob"].Value.ToString();
                            string strcdispbanc = this._Dtg_MayorAnalitico.Rows[e.RowIndex].Cells["corder"].Value.ToString();

                            //Guardo la seleccion en el datasource del grid
                            var oFilasDatagrid = _G_Dt_MayorAnalitico.Select("cidcomprob='" + strIdc + "' and corder='" + strcdispbanc + "' and cidconciliacion='" + _G_Int_cidconciliacion.ToString(CultureInfo.InvariantCulture) + "' and cestadoid=-1 ");
                            foreach (var oFila in oFilasDatagrid)
                            {
                                if ((oFila["estado"].ToString() != strValor))
                                {
                                    oFila["estado"] = strValor;
                                }
                            }

                            //Guardo la seleccion en el datasource unificado
                            var oFilasunificado = _G_Ds_BancoLibro.Tables[0].Select("cidcomprob='" + strIdc + "' and corder='" + strcdispbanc + "' and cidconciliacion='" + _G_Int_cidconciliacion.ToString(CultureInfo.InvariantCulture) + "' and cestadoid=-1 ");
                            foreach (var oFila in oFilasunificado)
                            {
                                if ((oFila["estado"].ToString() != strValor))
                                {
                                    oFila["estado"] = strValor;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void _Dtg_BancoNoConciliados_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void _Dtg_MayorAnalitico_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void _Cmb_CuentaDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_CuentaDetalle.SelectedValue != null)
            {
                if (_Cmb_CuentaDetalle.SelectedValue.ToString() != "nulo" && _Cmb_CuentaDetalle.SelectedValue.ToString() != "T3.Clases._Cls_ArrayList")
                {
                    _Mtd_LlenarEtiquetaInformativa();
                    _Btn_IniciarProceso.Enabled = _G_Bol_PermisoCreacion;
                }
                else
                {
                    _Btn_IniciarProceso.Enabled = false;
                }
            }
            else
            {
                _Btn_IniciarProceso.Enabled = false;
            }
        }

        private void _Dtg_BancoNoConciliados_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Cambiamos la bandera
            _G_EstamosSeteandoCombos = true;
            //Seteamos los estados en la variable
            _Mtd_SetearBancoNoConciliados();
            //Mostramos
            _Mtd_MostrarBancoNoConciliados();
            //Seteamos los Combos
            _Mtd_SetearCombosBancoNoConciliado();
            //Coloreamos
            _Mtd_ColorearBancoNoConciliados();
            //Cambiamos la bandera
            _G_EstamosSeteandoCombos = false;
            //
            _Dtg_BancoNoConciliados.EndEdit();
        }

        private void _Dtg_MayorAnalitico_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Cambiamos la bandera
            _G_EstamosSeteandoCombos = true;
            //Seteamos los estados
            _Mtd_SetearMayorAnalitico();    
            //Mostramos
            _Mtd_MostrarMayorAnalitico();
            //Seteamos los Combos
            _Mtd_SetearCombosMayorAnalitico();
            //Coloreamos
            _Mtd_ColorearMayorAnalitico();
            //Cambiamos la bandera
            _G_EstamosSeteandoCombos = false;
            //
            _Dtg_MayorAnalitico.EndEdit();
        }

        /// <summary>
        /// Muestra los Saldos
        /// </summary>
        private void _Mtd_MostrarSaldosEstadoDeCuenta()
        {
            double _Dbl_SaldoInicialBancoConsulta = 0;
            double _Dbl_SaldoFinalBancoConsulta = 0;
            double _Dbl_MontoBloqueadoFinalConsulta = 0;
            double _Dbl_MontoDisponibleFinalConsulta = 0;
            double _Dbl_MontoSaldoRealFinalConsulta = 0;

            //Calculo Saldos
            _Cls_RutinasConciliacion._Mtd_ObtenerSaldosEstadoDeCuentaDisponibilidad(_Cmb_BancoDetalle.SelectedValue.ToString(), _Cmb_CuentaDetalle.SelectedValue.ToString(), out _Dbl_SaldoInicialBancoConsulta, out _Dbl_SaldoFinalBancoConsulta, out  _Dbl_MontoBloqueadoFinalConsulta, out _Dbl_MontoSaldoRealFinalConsulta, out _Dbl_MontoDisponibleFinalConsulta);

            //Muestro los saldos
            _Txt_MontoDiferido.Text = _Dbl_MontoBloqueadoFinalConsulta.ToString("#,##0.00");
            _Txt_MontoDisponible.Text = _Dbl_MontoDisponibleFinalConsulta.ToString("#,##0.00");
            _Txt_SaldoReal.Text = _Dbl_MontoSaldoRealFinalConsulta.ToString("#,##0.00");

            _Txt_SaldoInicialBanco.Text = _Dbl_SaldoInicialBancoConsulta.ToString("#,##0.00");
            _Txt_SaldoFinalBanco.Text = _Dbl_SaldoFinalBancoConsulta.ToString("#,##0.00");
        }

        /// <summary>
        /// Valida que esten asignados todos los estados en todos los registros de banco
        /// </summary>
        /// <returns></returns>
        private bool _Mtd_EsValidoEstadosBancoNoConciliado()
        {
            _Er_Error.Dispose();
            var _Bol_Valido = true;
            foreach (DataGridViewRow _Dtw_Fila in _Dtg_BancoNoConciliados.Rows)
            {
                if (_Dtw_Fila.Cells["estadoelegirbanco"].Value == null)
                {
                    _Bol_Valido = false;
                    _Er_Error.SetError(_Lbl_BancoNoConciliado, "Debe ingresar el estado en todos los registros del banco no conciliados");
                    break;
                }
                if (_Dtw_Fila.Cells["estadoelegirbanco"].Value.ToString() == "nulo")
                {
                    _Bol_Valido = false;
                    _Er_Error.SetError(_Lbl_BancoNoConciliado, "Debe ingresar el estado en todos los registros del banco no conciliados");
                    break;
                }
                if (_Dtw_Fila.Cells["estadoelegirbanco"].Value.ToString() == "0")
                {
                    _Bol_Valido = false;
                    _Er_Error.SetError(_Lbl_BancoNoConciliado, "Debe ingresar el estado en todos los registros del banco no conciliados");
                    break;
                }
            }
            if (!_Bol_Valido)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Debe asignar todos los estados de todos los registros...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return _Bol_Valido;
        }

        /// <summary>
        /// Valida que esten asignados todos los estados en todos los registros de libro
        /// </summary>
        /// <returns></returns>
        private bool _Mtd_EsValidoEstadosLibroNoConciliado()
        {
            _Er_Error.Dispose();
            var _Bol_Valido = true;
            foreach (DataGridViewRow _Dtw_Fila in _Dtg_MayorAnalitico.Rows)
            {
                if (_Dtw_Fila.Cells["comboestadolibro"].Value == null)
                {
                    _Bol_Valido = false;
                    _Er_Error.SetError(_Lbl_LibroNoConciliado, "Debe ingresar el estado en todos los registros del libro no conciliados");
                    break;
                }
                if (_Dtw_Fila.Cells["comboestadolibro"].Value.ToString() == "nulo")
                {
                    _Bol_Valido = false;
                    _Er_Error.SetError(_Lbl_LibroNoConciliado, "Debe ingresar el estado en todos los registros del libro no conciliados");
                    break;
                }
                if (_Dtw_Fila.Cells["comboestadolibro"].Value.ToString() == "0")
                {
                    _Bol_Valido = false;
                    _Er_Error.SetError(_Lbl_LibroNoConciliado, "Debe ingresar el estado en todos los registros del libro no conciliados");
                    break;
                }
            }
            if (!_Bol_Valido)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Debe asignar todos los estados de todos los registros...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return _Bol_Valido;
        }

        private void _Dtg_BancoNoConciliados_CellClick(object sender, DataGridViewCellEventArgs e)
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
            if (_intColumna == 0)
            {
                _Dtg_BancoNoConciliados.CurrentCell = _Dtg_BancoNoConciliados.Rows[_intFila].Cells[_intColumna];
                _Dtg_BancoNoConciliados.BeginEdit(true);
            }
            else
            {
                //_Dtg_BancoNoConciliados.CurrentCell = _Dtg_BancoNoConciliados.Rows[_intFila].Cells[_intColumna];
                _Dtg_BancoNoConciliados.CancelEdit();
            }

        }

        private void _Dtg_MayorAnalitico_CellClick(object sender, DataGridViewCellEventArgs e)
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
            if (_intColumna == 0)
            {
                //_Dtg_MayorAnalitico.CurrentCell = _Dtg_MayorAnalitico.Rows[_intFila].Cells[_intColumna];
                //_Dtg_MayorAnalitico.BeginEdit(true);
            }
            else
            {
                //_Dtg_MayorAnalitico.CurrentCell = _Dtg_MayorAnalitico.Rows[_intFila].Cells[_intColumna];
                _Dtg_MayorAnalitico.CancelEdit();
            }
        }

        private int _Int_Orden = 1;
        private void _Dtg_ConciliarBancoLibro_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void Frm_ConciliacionBancariaV2_Shown(object sender, EventArgs e)
        {
            if (_Bol_NotificadorAprobacion)
                _Mtd_ColorGridConciliado();
            if (HayDescripcionesVaciasEstadosDisponibilidad())
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Hay estados de la disponibilidad que aún no se les ha asignado su descripción, por favor envíe un ticket con este mensaje, no es posible continuar.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void _Btn_FiltrarGrid_Click(object sender, EventArgs e)
        {
            _Mtd_FiltrarLibro();
        }

        private void _Mtd_FiltrarLibro(bool _P_Bool_Ordenar = true)
        {
            //Verificamos
            string[] _Str_Filtros = _Txt_NumeroDocumentoAFiltrar.Text.Split(',');
            string _Str_FiltroGenerado = "";
            //Filtramos
            foreach (var _Str_Filtro in _Str_Filtros)
            {
                if (_Str_FiltroGenerado == "")
                   _Str_FiltroGenerado = String.Format("(([Número Doc.] Like '%{0}%') OR ([Concepto] Like '%{0}%'))", _Str_Filtro);
                else
                   _Str_FiltroGenerado += String.Format(" OR (([Número Doc.] Like '%{0}%') OR ([Concepto] Like '%{0}%'))", _Str_Filtro);
            }
            _Str_FiltroGenerado = "(((cestadoid=" + _G_Str_cestadoid + ") AND ([Tip.Reg.]='LIBRO')) OR ([Tip.Reg.]='BANCO')) AND (" + _Str_FiltroGenerado + ")";

            //Pasamos el filtro
            _G_Dtv_RegistrosChequesPendientes = new DataView(_G_Ds_BancoLibro.Tables[0], _Str_FiltroGenerado, "Monto", DataViewRowState.OriginalRows);
            _Dtg_ConciliarBancoLibro.DataSource = _G_Dtv_RegistrosChequesPendientes;
            //Marcamos
            _Mtd_ColorGridConciliado();
            //Quitamos Ordenamiento
            _Mtd_QuitarOrdenamientoGridBancoLibro();
            //Ordenamos
            if (_P_Bool_Ordenar)
                _Mtd_OrdenarSegun("Número Doc.");
        }

        private void _Btn_BorrarFiltro_Click(object sender, EventArgs e)
        {
            _Txt_NumeroDocumentoAFiltrar.Text = "";
            _Mtd_FiltrarLibro(false);
            _Mtd_OrdenadoPorDefecto();
            _Mtd_ColorGridConciliado();
        }

        private void _Mtd_OrdenadoPorDefecto()
        {
            //Cargamos el DataSet
            var _Int_Count = _G_Ds_BancoLibro.Tables[0].AsEnumerable().Count(x => ((x["cestadoid"].ToString() == _G_Str_cestadoid) && x["Tip.Reg."].ToString().ToUpper() == "LIBRO") || (x["Tip.Reg."].ToString().ToUpper() == "BANCO"));
            //Ordenamos
            if (_Int_Count > 0)
            {
                var _Dt_BancoLibroConciliado = _G_Ds_BancoLibro.Tables[0].AsEnumerable()
                                                                       .Where(x => ((x["cestadoid"].ToString() == _G_Str_cestadoid) && x["Tip.Reg."].ToString().ToUpper() == "LIBRO") || (x["Tip.Reg."].ToString().ToUpper() == "BANCO"))
                                                                       .OrderByDescending(n => n["cconciliado"])
                                                                       .ThenBy(n => n["cseleccionado"])
                                                                       .ThenBy(n => decimal.Parse(n["Monto"].ToString()))
                                                                       .ThenBy(n => n["Número Doc."])
                                                                       .CopyToDataTable();
                //Paso el Dataset Actualizado
                _G_Dtv_RegistrosChequesPendientes = _Dt_BancoLibroConciliado.DefaultView;
                _Dtg_ConciliarBancoLibro.DataSource = _G_Dtv_RegistrosChequesPendientes;
            }
        }

        private void _Mtd_OrdenarSegun(string _P_Str_NombreColumna)
        {
            var _Columna = _Dtg_ConciliarBancoLibro.Columns[_P_Str_NombreColumna];
            if (_Columna != null)
                _Dtg_ConciliarBancoLibro.Sort(_Columna, System.ComponentModel.ListSortDirection.Descending);
        }

        private void _Dtg_ConciliarBancoLibro_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
        }

        private void _Dtg_ConciliarBancoLibro_SelectionChanged(object sender, EventArgs e)
        {
            //Totalizamos
            _Txt_TotalDocumentosSeleccionados_Libro.Text = "";
            _Txt_TotalDocumentosSeleccionados_Banco.Text = "";
            //Sumo
            var _Dcm_Sumatoria_Libro = _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Where(x => x.Cells["Tip.Reg."].Value.ToString().ToUpper() == "LIBRO").Sum(x => Convert.ToDecimal(x.Cells["Monto"].Value));
            var _Dcm_Sumatoria_Banco = _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Where(x => x.Cells["Tip.Reg."].Value.ToString().ToUpper() == "BANCO").Sum(x => Convert.ToDecimal(x.Cells["Monto"].Value));
            //
            _Txt_TotalDocumentosSeleccionados_Libro.Text = _Dcm_Sumatoria_Libro.ToString("#,##0.00");
            _Txt_TotalDocumentosSeleccionados_Banco.Text = _Dcm_Sumatoria_Banco.ToString("#,##0.00");
        }

        private void _Bt_AceptarTipoOperacionBancaria_Click(object sender, EventArgs e)
        {
            if (_CmbTipoOperacionBancaria.Items.Count <= 0)
            {
                MessageBox.Show(this, "Debe seleccionar el Tipo de Operacion Bancaria", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _CmbTipoOperacionBancaria.Focus();
                return;
            }
            if (_CmbTipoOperacionBancaria.SelectedIndex <= 0)
            {
                MessageBox.Show(this, "Debe seleccionar el Tipo de Operacion Bancaria", "Verificar", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                _CmbTipoOperacionBancaria.Focus();
                return;
            }
            if (!_Mtd_EsValidaLasNaturalezasSeleccionadas())
            {
                MessageBox.Show(this, "La Naturaleza del tipo de operación bancaria seleccionado no coincide con la naturaleza del registro de banco seleccionado, verifique...", "Verificar", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                _CmbTipoOperacionBancaria.Focus();
                return;
            }

            //Llamamor a la rutina de marcar conciliado manualmente
            _Pnl_TipoOperacionBancaria.Visible = false;
            _Mtd_ConciliarManualmente(_CmbTipoOperacionBancaria.SelectedValue.ToString()); //Pasamos el valor seleccionado de tipo de operacion bancaria
        }

        private bool _Mtd_EsValidaLasNaturalezasSeleccionadas()
        {
            var _Str_Naturaleza_Combo = "";
            var _Str_Naturaleza_Banco = "";

            //Obtenemos la Naturaleza del Tipo de Cuenta seleccionada en el combo
            var _Str_coperbanc_Original = _CmbTipoOperacionBancaria.SelectedValue.ToString();
            if (_Str_coperbanc_Original.Length > 0)
            {
                var _Str_coperbanc = "";
                var _Bol_EsReverso = false;

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

                //Consultamos
                var _Str_Consulta = "SELECT CDEBE FROM TOPERBANC WHERE coperbanc = '" + _Str_coperbanc + "' AND CDELETE='0'";
                var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Consulta);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Bol_EsReverso)
                        _Str_Naturaleza_Combo = _Ds.Tables[0].Rows[0][0].ToString() == "1" ? "H" : "D";
                    else
                        _Str_Naturaleza_Combo = _Ds.Tables[0].Rows[0][0].ToString() == "1" ? "D" : "H";
                }
            }

            //Obtenermos la Naturaleza del registro de banco seleccionado
            var _RegistrosBancoSeleccionados = _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Where(x => x.Cells["Tip.Reg."].Value.ToString().ToUpper() == "BANCO").ToList();
            if (_RegistrosBancoSeleccionados.Count > 0)
            {
                var _Str_cdispbanc = _RegistrosBancoSeleccionados.First().Cells["cdispbanc"].Value.ToString();
                var _Str_cdispband = _RegistrosBancoSeleccionados.First().Cells["cdispband"].Value.ToString();

                var _Str_Consulta = "SELECT TOPERBANC.ccount,TOPERBANC.cname AS Coletilla, TOPERBANC.cdebe, TOPERBANC.chaber " +
                                "FROM TDISPBAND INNER JOIN TOPERBANCD ON TDISPBAND.cbanco = TOPERBANCD.cbanco AND TDISPBAND.ctipoperacio = TOPERBANCD.coperbancd INNER JOIN TOPERBANC ON TOPERBANCD.coperbanc = TOPERBANC.coperbanc " +
                                "WHERE (TDISPBAND.cdispbanc='" + _Str_cdispbanc + "') AND (TDISPBAND.cdispband='" + _Str_cdispband + "') AND (TDISPBAND.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TOPERBANCD.cdelete = 0) AND (TOPERBANC.cdelete = 0) ";

                var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Consulta);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_Naturaleza_Banco = _Ds.Tables[0].Rows[0]["cdebe"].ToString() == "1" ? "D" : "H";
                }
            }

            return _Str_Naturaleza_Combo == _Str_Naturaleza_Banco;
        }

        private void _Bt_CancelarTipoOperacionBancaria_Click(object sender, EventArgs e)
        {
            _Pnl_TipoOperacionBancaria.Visible = false;
            ((Frm_Padre)MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
        }

        private void _Pnl_TipoOperacionBancaria_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_TipoOperacionBancaria.Visible)
            {
                _Tab_Contenedor.Enabled = false;
                var _G_Str_SentenciaSql = "SELECT TOPERBANC.coperbanc, TOPERBANC.cname FROM TOPERBANC_GENERAAJUSTESAUTOMATICOS INNER JOIN TOPERBANC ON TOPERBANC_GENERAAJUSTESAUTOMATICOS.coperbanc = TOPERBANC.coperbanc WHERE (TOPERBANC.cdelete = 0) " +
                                          "UNION " +
                                          "SELECT TOPERBANC.coperbanc + '" +  _Cls_RutinasConciliacion._Str_Coletilla_Reverso + "', TOPERBANC.cname + ' (REVERSO)' FROM TOPERBANC_GENERAAJUSTESAUTOMATICOS INNER JOIN TOPERBANC ON TOPERBANC_GENERAAJUSTESAUTOMATICOS.coperbanc = TOPERBANC.coperbanc WHERE (TOPERBANC.cdelete = 0) ";
                _Mtd_CargarComboLimpiandoCampos(_CmbTipoOperacionBancaria, _G_Str_SentenciaSql);
                _CmbTipoOperacionBancaria.Focus();
            }
            else
            {
                _Tab_Contenedor.Enabled = true;
            }

        }

        // BANCO NO CONCILIADO
        private bool _Bol_EditandoCombo = false;
        private void _Dtg_BancoNoConciliados_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var _Control = e.Control as ComboBox;
            if (_Control != null)
            {
                _Control.Enter -= new EventHandler(_Mtd_Combo_BancoNoConciliados_Enter);
                _Control.Enter += new EventHandler(_Mtd_Combo_BancoNoConciliados_Enter);
            }
        }
        void _Mtd_Combo_BancoNoConciliados_Enter(object sender, EventArgs e)
        {
            var _Control = sender as ComboBox;
            if (_Control != null)
            {
                _Control.DroppedDown = true;
                _Control.SelectedIndex = 0;
            }
        }
        private void _Mtd_ComboBox_BancoNoConciliados_Click(object sender, EventArgs e)
        {
            var _Control = sender as ComboBox;
            if (_Control != null)
            {
                if (_Dtg_BancoNoConciliados.IsCurrentCellDirty && _Bol_EditandoCombo)
                {
                    _Dtg_BancoNoConciliados.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    _Dtg_BancoNoConciliados.EndEdit();
                    _Bol_EditandoCombo = false;
                }
            }
        }
        private void _Dtg_BancoNoConciliados_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            var _Dtg = (DataGridView)sender;
            if (_Dtg.IsCurrentCellDirty)
            {
                _Dtg.CommitEdit(DataGridViewDataErrorContexts.Commit);
                _Dtg.EndEdit();
            }
        }

        // MAYOR ANALITICO
        private void _Dtg_MayorAnalitico_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var _Control = e.Control as ComboBox;
            if (_Control != null)
            {
                _Control.Enter -= new EventHandler(_Mtd_Combo_LibroNoConciliados_Enter);
                _Control.Enter += new EventHandler(_Mtd_Combo_LibroNoConciliados_Enter);
            }
        }
        void _Mtd_Combo_LibroNoConciliados_Enter(object sender, EventArgs e)
        {
            var _Control = sender as ComboBox;
            if (_Control != null)
            {
                _Control.DroppedDown = true;
                _Control.SelectedIndex = 0;
            }
        }
        private void _Dtg_MayorAnalitico_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            var _Dtg = (DataGridView)sender;
            if (_Dtg.IsCurrentCellDirty)
            {
                _Dtg.CommitEdit(DataGridViewDataErrorContexts.Commit);
                _Dtg.EndEdit();
            }
        }

    }
}
