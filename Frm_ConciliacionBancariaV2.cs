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
    public partial class Frm_ConciliacionBancariaV2 : Form
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
        private DataTable _G_Dt_LibroNoConciliado = new DataTable(); //Solo se utiliza para mostrar los registros ordenados en el grid
        private DataSet _G_Ds_EstadosBanco = new DataSet();
        private DataSet _G_Ds_EstadosLibro = new DataSet();
        private bool _G_Bol_Impreso;
        private bool _G_EstamosSeteandoCombos;
        private readonly bool _G_Bol_PermisoCreacion;
        private string _G_Str_cdispbanc = "";
        private string _G_Str_cbanco = "";
        private string _G_Str_cnumcuenta = "";
        private int _G_Int_IdConciliacion = 0;

        private int _G_Int_Ciddetalleconciliacion;

        //Constantes mostrar caracteres especiales en el grid
        private const string _G_Str_Seleccionado = "ü";
        private const string _G_Str_SeleccionadoManual = "Ü";
        private const string _G_Str_NoSeleccionado = "û";



        public Frm_ConciliacionBancariaV2()
        {
            InitializeComponent();
            _G_Bol_PermisoCreacion = _G_myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _G_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CONC_NUEVA_CONCILIACION");
            _Rpt_ReporteConciliacion.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_ReporteConciliacion.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_ConciliacionBancaria";
            _Dtp_Hasta.MaxDate = DateTime.Now.AddDays(-1);
            _Mtd_CargarBancoConsulta();
            _Mtd_ConsultarConciliacion("", "");
        }

        public Frm_ConciliacionBancariaV2(string _P_Str_Impreso)
        {
            InitializeComponent();
            _G_Bol_PermisoCreacion = _G_myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _G_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CONC_NUEVA_CONCILIACION");
            _Rpt_ReporteConciliacion.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_ReporteConciliacion.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_ConciliacionBancaria";
            _Dtp_Hasta.MaxDate = DateTime.Now.AddDays(-1);
            _Mtd_CargarBancoConsulta();
            if (_P_Str_Impreso == "1")
            {
                _Chk_PorImprimir.Checked = true;
            }
            _Mtd_ConsultarConciliacion("", "");
        }

        public Frm_ConciliacionBancariaV2(int _P_Int_IdConciliacion)
        {
            InitializeComponent();
            _G_Bol_PermisoCreacion = _G_myUtilidad._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _G_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_CONC_NUEVA_CONCILIACION");
            _G_Int_IdConciliacion = _P_Int_IdConciliacion;

            if (_Mtd_HayComprobantesManualesPorActualizar(Frm_Padre._Str_Comp, _P_Int_IdConciliacion.ToString()))
            {
                return;
            }

            if (!HayComprobantesConciliacionesManualesPorActualizar())
            {
                _Rpt_ReporteConciliacion.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
                _Rpt_ReporteConciliacion.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_ConciliacionBancaria";
                _Dtp_Hasta.MaxDate = DateTime.Now.AddDays(-1);
                _Mtd_CargarBancoConsulta();
                _Mtd_Ini();
                _G_Int_IdConciliacion = _P_Int_IdConciliacion;
                PrepararControles(_P_Int_IdConciliacion.ToString(CultureInfo.InvariantCulture));
            }

        }

        private bool _Bol_NotificadorAprobacion = false;

        private void PrepararControles(string _P_Str_IdConciliacion)
        {
            _Bol_NotificadorAprobacion = true;
            string _Str_Cadena = "SELECT cbanco,cnumcuenta,cfechadesde,cfechahasta,cdispbanc FROM TCONCILIACION WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidconciliacion='" + _P_Str_IdConciliacion + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Cmb_BancoDetalle.SelectedValue = _Ds.Tables[0].Rows[0]["cbanco"].ToString();
                _Cmb_CuentaDetalle.SelectedValue = _Ds.Tables[0].Rows[0]["cnumcuenta"].ToString();
                _Dtp_Desde.Value = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechadesde"]);
                _Dtp_Hasta.Value = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechahasta"]);
                _G_Str_cdispbanc = _Ds.Tables[0].Rows[0]["cdispbanc"].ToString();
                _G_Str_cbanco = _Ds.Tables[0].Rows[0]["cbanco"].ToString().Trim(); 
                _G_Str_cnumcuenta = _Ds.Tables[0].Rows[0]["cnumcuenta"].ToString().Trim();
                _Mtd_MostrarSaldos();
                _Mtd_LlenarBancoLibroNoConciliado();
                _Cmb_BancoDetalle.Enabled = false;
                _Cmb_CuentaDetalle.Enabled = false;
                _Btn_IniciarProceso.Enabled = false;
                _Tab_PasosConciliacion.Enabled = true;
                _Dtp_Desde.Enabled = false;
                _Dtp_Hasta.Enabled = false;
                _Mtd_ConciliarAutomaticamente();
                _Mtd_OrdenadoPorDefecto();
                _Mtd_ColorGridConciliado();
                _Mtd_QuitarOrdenamientoGridBancoLibro();
                _Btn_FiltrarGrid.Enabled = true;
                _Btn_BorrarFiltro.Enabled = true;
                _Txt_NumeroDocumentoAFiltrar.Enabled = true;
                _Btn_ExportConciliados1.Enabled = true;
                _Btn_ExportNoConciliados1.Enabled = true;
                _Tab_Contenedor.SelectedIndex = 1;
                _G_Int_Paso = 1;
                _Tab_PasosConciliacion.SelectedIndex = _G_Int_Paso - 1;
            }
        }

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
            _Mtd_ConsultarConciliacion(_Str_Banco, _Str_NumCuenta);
        }

        private void _Mtd_Habilitar(bool _Bol_Habilitar)
        {
            _Tab_PasosConciliacion.Enabled = _Bol_Habilitar;
            _Pnl_DetalleProceso.Enabled = false;
        }

        private void _Mtd_ConsultarConciliacion(string _Str_Banco, string _Str_NumeroCuenta)
        {
            string _Str_Where = "";
            if (_Str_Banco.Length > 0)
            {
                _Str_Where += " AND TCONCILIACION.CBANCO='" + _Str_Banco + "'";
            }
            if (_Str_NumeroCuenta.Length > 0)
            {
                _Str_Where += " AND TCONCILIACION.CNUMCUENTA='" + _Str_NumeroCuenta + "'";
            }
            _Str_Where += " AND CIMPRESO='" + Convert.ToInt32(!_Chk_PorImprimir.Checked) + "'";
            _G_Str_SentenciaSql =
                "SELECT TCONCILIACION.cidconciliacion AS [Id Conciliación],TBANCO.cname As [Banco],TCONCILIACION.cnumcuenta As [Nº Cuenta],CONVERT(VARCHAR, TCONCILIACION.cfechadesde, 103) AS [Fecha Desde],CONVERT(VARCHAR, TCONCILIACION.cfechahasta, 103) AS [Fecha Hasta],dbo.Fnc_Formatear(TCONCILIACION.ctotalconciliacion) AS [Monto Conciliación Bancaria] FROM TCONCILIACION INNER JOIN TBANCO ON TCONCILIACION.ccompany = TBANCO.ccompany AND TCONCILIACION.cbanco = TBANCO.cbanco " +
                "WHERE TCONCILIACION.CCOMPANY='" + Frm_Padre._Str_Comp + "' " +
                "AND ISNULL(TCONCILIACION.cdelete,0)=0 " +
                "AND TCONCILIACION.cfinalizado=1 " + _Str_Where + " " +
                "ORDER BY TCONCILIACION.cidconciliacion DESC";
            _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);
            _Dtg_Consulta.DataSource = _G_Ds_DataSet.Tables[0];
            _Dtg_Consulta.Columns["Monto Conciliación Bancaria"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
            _Mtd_Ini();
            _Btn_Finalizar.Text = "Finalizar";
            _Tab_Contenedor.SelectedIndex = 1;
            ((Frm_Padre) this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            _Dtp_Desde.MinDate = new DateTime(1900, 1, 1);
            _Dtp_Hasta.MinDate = new DateTime(1900,1,1);
            _Dtp_Desde.MaxDate = DateTime.Now.Date.AddDays(-1);
            _Dtp_Hasta.MaxDate = DateTime.Now.Date.AddDays(-1);
            _Dtp_Desde.Value = DateTime.Now.Date.AddDays(-1);
            _Dtp_Hasta.Value = DateTime.Now.Date.AddDays(-1);

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
            _G_Str_SentenciaSQLBanco += ", 0 as cidconciliacion "; //21
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
            _Dtg_LibrosNoConciliados.DataSource = _Ds_InicializarGrids.Tables[0];


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
            _Txt_SaldoFinalBanco.Text = "";
            _Txt_SaldoInicialSegunLibro.Text = "";
            _Txt_SaldoSegunLibro.Text = "";
            _Txt_TotalDocumentosSeleccionados_Libro.Text = "";
            _Txt_TotalDocumentosSeleccionados_Banco.Text = "";
            _G_Bol_ModoGuardar = true;
            _G_Bol_Impreso = false;
            _G_Str_cdispbanc = "";
            _G_Str_cbanco = "";
            _G_Str_cnumcuenta = "";
            _Dtp_Hasta.Enabled = false;
            _Dtp_Desde.Enabled = false;
            ((Frm_Padre) Application.OpenForms["Frm_Padre"])._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
        }

        private void _Tab_Contenedor_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                if (_G_Bol_ModoGuardar)
                {
                    if (MessageBox.Show("Está seguro de volver a la consulta se perderá la información ya cargada en la presente conciliación?", "Información", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
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

        private bool AprobacionesPendientes()
        {
            string _Str_Sql =
                "SELECT TCONCILIACION.cidconciliacion FROM TCONCILIACION INNER JOIN TCONCILIACIOND_MANUALV2 ON TCONCILIACION.cidconciliacion=TCONCILIACIOND_MANUALV2.cidconciliacion AND TCONCILIACION.ccompany=TCONCILIACIOND_MANUALV2.ccompany WHERE TCONCILIACION.ccompany='" +
                Frm_Padre._Str_Comp + "' AND TCONCILIACION.cbanco='" + _Cmb_BancoDetalle.SelectedValue.ToString() + "' AND TCONCILIACION.cnumcuenta='" + _Cmb_CuentaDetalle.SelectedValue.ToString() +
                "' AND ISNULL(TCONCILIACIOND_MANUALV2.caprobado,0)=0 AND ISNULL(TCONCILIACIOND_MANUALV2.cdelete,0)=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        private bool ProcesoAprobacion()
        {
            string _Str_Sql =
                "SELECT TCONCILIACION.cidconciliacion FROM TCONCILIACION INNER JOIN TCONCILIACIOND_MANUALV2 ON TCONCILIACION.cidconciliacion=TCONCILIACIOND_MANUALV2.cidconciliacion AND TCONCILIACION.ccompany=TCONCILIACIOND_MANUALV2.ccompany WHERE TCONCILIACION.ccompany='" +
                Frm_Padre._Str_Comp + "' AND TCONCILIACION.cbanco='" + _Cmb_BancoDetalle.SelectedValue.ToString() + "' AND TCONCILIACION.cnumcuenta='" + _Cmb_CuentaDetalle.SelectedValue.ToString() +
                "' AND TCONCILIACION.cfinalizado = '0' AND ISNULL(TCONCILIACIOND_MANUALV2.cdelete,0)=0 " +
                "AND NOT EXISTS(SELECT cidconciliacion FROM TCONCILIACIOND_MANUALV2 AS DETALLE_MANUAL WHERE DETALLE_MANUAL.cidconciliacion=TCONCILIACIOND_MANUALV2.cidconciliacion AND DETALLE_MANUAL.ciddispbanc=TCONCILIACIOND_MANUALV2.ciddispbanc AND DETALLE_MANUAL.ciddispband=TCONCILIACIOND_MANUALV2.ciddispband AND DETALLE_MANUAL.cidcomprob=TCONCILIACIOND_MANUALV2.cidcomprob AND DETALLE_MANUAL.corder=TCONCILIACIOND_MANUALV2.corder AND DETALLE_MANUAL.ccompany=TCONCILIACIOND_MANUALV2.ccompany AND ISNULL(DETALLE_MANUAL.caprobado,0)=0 AND ISNULL(DETALLE_MANUAL.cdelete,0)=0)";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        private bool HayComprobantesConciliacionesManualesPorActualizar()
        {
            string _Str_Sql =
                "SELECT TCOMPROBANC.ccompany FROM TCONCILIACIOND_MANUALV2 INNER JOIN TCOMPROBANC ON TCONCILIACIOND_MANUALV2.cidcomprob = TCOMPROBANC.cidcomprob AND TCONCILIACIOND_MANUALV2.ccompany = TCOMPROBANC.ccompany " +
                "WHERE  (TCONCILIACIOND_MANUALV2.caprobado = 1) AND (TCOMPROBANC.ccompany = '" + Frm_Padre._Str_Comp + "') AND (TCOMPROBANC.cstatus = '0') AND ISNULL(TCONCILIACIOND_MANUALV2.cdelete,0)=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        private void _Btn_IniciarProceso_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //Validaciones previas de los datos para arrancar el proceso
            if (_Dtp_Hasta.Value < _Dtp_Desde.Value)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("La fecha hasta no puede ser menor que la fecha desde, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //Validacion del Monto Inicial
            if (!_Cls_RutinasConciliacion._Mtd_EsValidoSaldoInicialBanco(_Cmb_BancoDetalle.SelectedValue.ToString(), _Cmb_CuentaDetalle.SelectedValue.ToString()))
            {
                Cursor = Cursors.Default;
                MessageBox.Show("No existe saldo inicial para el banco y cuenta seleccionado, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //Validacion del Estado de Cuenta
            if (!_Cls_RutinasConciliacion._Mtd_ExisteEstadoDeCuentaPorConciliar(_Cmb_BancoDetalle.SelectedValue.ToString(), _Cmb_CuentaDetalle.SelectedValue.ToString(),_Cls_RutinasConciliacion._TipoEstadoDeCuenta.Conciliacion))
            {
                Cursor = Cursors.Default;
                MessageBox.Show("No existe un estado de cuenta cargado para el banco y cuenta seleccionado, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (AprobacionesPendientes())
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Existe una conciliación pendiente de aprobación para el banco y cuenta seleccionados.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (ProcesoAprobacion())
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Hubo conciliaciones manuales en proceso de aprobación para el banco y cuenta seleccionados, debe ingresar desde el notificador:\n 'APROBACIÓN DE CONC. MANUALES TERMINADAS'.",
                                "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Verifico que haya seleccionado un banco y una  cuenta
            if (_Cmb_BancoDetalle.SelectedIndex > 0 && _Cmb_CuentaDetalle.SelectedIndex > 0)
            {
                Cursor = Cursors.WaitCursor;
                //Inicia el proceso
                //Cargo los Saldos
                _Mtd_MostrarSaldos();
                _Mtd_LlenarBancoLibroNoConciliado();
                _Mtd_ObtenerEstadoDeCuentaAUsar();
                _Cmb_BancoDetalle.Enabled = false;
                _Cmb_CuentaDetalle.Enabled = false;
                _Btn_IniciarProceso.Enabled = false;
                _Tab_PasosConciliacion.Enabled = true;
                //Desactivo los botones
                _Dtp_Desde.Enabled = false;
                _Dtp_Hasta.Enabled = false;
                _Btn_Siguiente.Enabled = false;
                _Btn_ConciliarManualmente.Enabled = false;
                _Btn_DesConciliarManualmente.Enabled = false;
                _Btn_FiltrarGrid.Enabled = false;
                _Btn_BorrarFiltro.Enabled = false;
                _Txt_NumeroDocumentoAFiltrar.Enabled = false;
                _Btn_ExportConciliados1.Enabled = false;
                _Btn_ExportNoConciliados1.Enabled = false;
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
                _Btn_ExportConciliados1.Enabled = true;
                _Btn_ExportNoConciliados1.Enabled = true;
                Cursor = Cursors.Default;
                //Inicializo 
                _G_Int_IdConciliacion = 0;
            }
            Cursor = Cursors.Default;
        }

        private void _Mtd_LlenarFechasOmision()
        {
            string _Str_IdConciliacion = "";
            _G_Str_SentenciaSql = "SELECT MAX(cidconciliacion) as cidconciliacion FROM TCONCILIACION WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND CBANCO='" + _Cmb_BancoDetalle.SelectedValue.ToString() +
                                  "' AND CNUMCUENTA='" + _Cmb_CuentaDetalle.SelectedValue.ToString() + "' AND cfinalizado=1";
            _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);
            foreach (DataRow _Dtw_Item in _G_Ds_DataSet.Tables[0].Rows)
            {
                _Str_IdConciliacion = _Dtw_Item["cidconciliacion"].ToString();
            }
            if (_Str_IdConciliacion.Length > 0)
            {
                _G_Str_SentenciaSql = "SELECT cfechahasta FROM TCONCILIACION WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND cidconciliacion='" + _Str_IdConciliacion + "'";
                _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);
                if (_G_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow _Dtw_Item in _G_Ds_DataSet.Tables[0].Rows)
                    {
                        //Fecha desde (1 dias más que la fecha hasta obtenida)
                        _Dtp_Desde.MaxDate = Convert.ToDateTime(_Dtw_Item["cfechahasta"].ToString()).AddDays(1);
                        _Dtp_Desde.Value = Convert.ToDateTime(_Dtw_Item["cfechahasta"].ToString()).AddDays(1);
                        ;
                        _Dtp_Desde.Enabled = false;

                        //Fecha Hasta
                        var _Dt_UltimoDiaMes = new DateTime(_Dtp_Desde.Value.Year, _Dtp_Desde.Value.Month, DateTime.DaysInMonth(_Dtp_Desde.Value.Year, _Dtp_Desde.Value.Month));
                        //Validamos
                        if (_Dt_UltimoDiaMes < DateTime.Now.Date)
                        {
                            //Tomamos la fecha del ultimo dia del mes
                            _Dtp_Hasta.MaxDate = _Dt_UltimoDiaMes;
                            _Dtp_Hasta.Value = _Dt_UltimoDiaMes;
                        }
                        else
                        {
                            //Tomamos el dia anterior ala fecha actual
                            _Dtp_Hasta.MaxDate = DateTime.Now.Date.AddDays(-1);
                            _Dtp_Hasta.Value = DateTime.Now.Date.AddDays(-1);
                        }
                    }
                }
                else
                {
                    _Dtp_Desde.Enabled = true;
                }
            }
            else
            {
                _Dtp_Desde.Enabled = true;
            }
            //_Dtp_Hasta.Enabled = true;
        }

        private void _Mtd_LlenarBancoLibroNoConciliado()
        {
            string _G_Str_SentenciaSQL = "";

            Cursor = Cursors.WaitCursor;

            //Inicializo el contador interno de conciliaciones atomicas
            _G_Int_Ciddetalleconciliacion = 0;

            _G_Ds_EstadosBanco = new DataSet();
            _G_Ds_EstadosLibro = new DataSet();
            _G_Ds_BancoLibro = new DataSet();

            //Fecha hasta para los registros de libro
             var _Dt_Hasta = new DateTime(_Dtp_Hasta.Value.Year, _Dtp_Hasta.Value.Month, _Dtp_Hasta.Value.Day);

            //Genero la Consulta de Banco No Conciliado
            _G_Str_SentenciaSQL = "SELECT * ";
            _G_Str_SentenciaSQL += "FROM VST_CONCILIACION_BANCOLIBRONOCONCILIADO ";
            _G_Str_SentenciaSQL += "WHERE ";
            _G_Str_SentenciaSQL += "CCOMPANY='" + Frm_Padre._Str_Comp + "' ";
            _G_Str_SentenciaSQL += "AND CBANCO='" + _Cmb_BancoDetalle.SelectedValue.ToString() + "' ";
            _G_Str_SentenciaSQL += "AND CNUMCUENTA='" + _Cmb_CuentaDetalle.SelectedValue.ToString() + "' ";
            _G_Str_SentenciaSQL += "AND (ctiporegistro IN (" +
                                   "'" + ((byte)_Cls_RutinasConciliacion._TipoRegistro.NoAplica) + "'" +
                                   ",'" + ((byte)_Cls_RutinasConciliacion._TipoRegistro.Nuevo) + "'" +
                                   //",'" + ((byte)_Cls_RutinasConciliacion._TipoRegistro.Original) + "'" + //no deben salir
                                   "))";
            
            _G_Str_SentenciaSQL += "AND ( ";

            //BANCO
            _G_Str_SentenciaSQL += "( ";
            _G_Str_SentenciaSQL += "[Tip.Reg.]='BANCO' ";
            _G_Str_SentenciaSQL += ") ";

            //OR
            _G_Str_SentenciaSQL += "OR ";

            //LIBRO
            _G_Str_SentenciaSQL += "( ";
            _G_Str_SentenciaSQL += "[Tip.Reg.]='LIBRO' ";
            _G_Str_SentenciaSQL += "AND ";
            _G_Str_SentenciaSQL += "cregdate <= CONVERT(DATETIME,'" + _Dt_Hasta.ToShortDateString() + "') ";
            _G_Str_SentenciaSQL += ")";

            _G_Str_SentenciaSQL += ")";

            //Instancio el DataSet Internos
            _G_Ds_BancoLibro = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);

            //Pasamos los datos al grid
            _Dtg_ConciliarBancoLibro.DataSource = _G_Ds_BancoLibro.Tables[0].DefaultView;

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
                _Dtg_BancoNoConciliados.Columns["cidconciliacion"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["ciddetalleconciliacion"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["ctiporegistro"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["Cuenta Contable"].Visible = false;
                //_Dtg_BancoNoConciliados.Columns["Fecha"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["ctipoajuste"].Visible = false;

                _Dtg_BancoNoConciliados.Columns["cregdate"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["ccompany"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["cbanco"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["cnumcuenta"].Visible = false;
                _Dtg_BancoNoConciliados.Columns["cidconciliaciondmanual"].Visible = false;

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

                    //Obtenemos el estado que corresponda
                    string _cestadoid = Obtener_cestadoid_Banco(_Str_ccompany, _Str_cdispband, _Str_cdispbanc, _Str_cbanco, _Str_cnumcuenta);

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

        private void _Mtd_CargarLibroNoConciliado()
        {
            //Cargamos el DataSource
            var _LibroNoConciliado = _G_Ds_BancoLibro.Tables[0].Select("cconciliado=0").Where(x => x["Tip.Reg."].ToString().ToUpper() == "LIBRO");
            var _Rows = _LibroNoConciliado as IList<DataRow> ?? _LibroNoConciliado.ToList();
            if (_Rows.Any())
                _G_Dt_LibroNoConciliado = _Rows.CopyToDataTable();
            //Seteamos los estados
            _Mtd_SetearLibroNoConciliados();
            //Ordenamos
            _Mtd_OrdenarLibroNoConciliado();
            //Mostramos
            _Mtd_MostrarLibroNoConciliados();
            //Seteamos los Combos
            _Mtd_SetearCombosLibroNoConciliado();
            //Coloreamos
            _Mtd_ColorearLibroNoConciliados();
        }

        private void _Mtd_MostrarLibroNoConciliados()
        {
            try
            {
                //Inicializamos el Grid
                _Dtg_LibrosNoConciliados.DataSource = null;
                _Dtg_LibrosNoConciliados.Rows.Clear();
                _Dtg_LibrosNoConciliados.Columns.Clear();

                //Cargamos la Columna  de Combo
                DataGridViewComboBoxColumn oComboEstadoLibro = new DataGridViewComboBoxColumn();
                oComboEstadoLibro.HeaderText = "Estado";
                oComboEstadoLibro.Name = "comboestadolibro";
                oComboEstadoLibro.Width = 300;
                _Dtg_LibrosNoConciliados.Columns.Add(oComboEstadoLibro);

                //Cargamos el grid
                _Dtg_LibrosNoConciliados.DataSource = _G_Dt_LibroNoConciliado;

                //Ocultamos las columnas innecesarias
                _Dtg_LibrosNoConciliados.Columns["cseleccionado"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["cseleccionado"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["Tip.Reg."].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["Número Doc."].Visible = true;
                _Dtg_LibrosNoConciliados.Columns["Comprobante"].Visible = true;
                _Dtg_LibrosNoConciliados.Columns["Concepto"].Visible = true;
                _Dtg_LibrosNoConciliados.Columns["Tipo de Operación"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["Monto"].Visible = true;
                _Dtg_LibrosNoConciliados.Columns["cdispband"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["cdispbanc"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["ctotdebe"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["ctothaber"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["cidedetalleconciliacion"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["cidcomprob"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["corder"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["estado"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["estadodescripcion"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["cconciliado"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["ccount_ajustar"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["cGeneraAjustesAutomaticos"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["cconciliadoAutomaticamente"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["coperbancseleccionado"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["cidconciliacion"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["ciddetalleconciliacion"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["ctiporegistro"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["Cuenta Contable"].Visible = false;
                //_Dtg_LibrosNoConciliados.Columns["Fecha"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["ctipoajuste"].Visible = false;

                _Dtg_LibrosNoConciliados.Columns["cregdate"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["ccompany"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["cbanco"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["cnumcuenta"].Visible = false;
                _Dtg_LibrosNoConciliados.Columns["cidconciliaciondmanual"].Visible = false;

                //Ordenamos las columnas visibles
                _Dtg_LibrosNoConciliados.Columns["Comprobante"].DisplayIndex = 0;
                _Dtg_LibrosNoConciliados.Columns["Concepto"].DisplayIndex = 1;
                _Dtg_LibrosNoConciliados.Columns["Fecha"].DisplayIndex = 2;
                _Dtg_LibrosNoConciliados.Columns["Número Doc."].DisplayIndex = 3;
                _Dtg_LibrosNoConciliados.Columns["Monto"].DisplayIndex = 4;
                _Dtg_LibrosNoConciliados.Columns["comboestadolibro"].DisplayIndex = 5;

                //Configuro los tamaños de las columnas
                _Dtg_LibrosNoConciliados.Columns["Concepto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                _Dtg_LibrosNoConciliados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                //Configuro los alineamientos de las columnas
                _Dtg_LibrosNoConciliados.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //Formateamos la Columna
                _Dtg_LibrosNoConciliados.Columns["Monto"].DefaultCellStyle.Format = "#,##0.00";


                //Ponemos el solo lectura
                _Dtg_LibrosNoConciliados.Columns["Tip.Reg."].ReadOnly = true;
                _Dtg_LibrosNoConciliados.Columns["Número Doc."].ReadOnly = true;
                _Dtg_LibrosNoConciliados.Columns["Comprobante"].ReadOnly = true;
                _Dtg_LibrosNoConciliados.Columns["Concepto"].ReadOnly = true;
                _Dtg_LibrosNoConciliados.Columns["Tipo de Operación"].ReadOnly = true;
                _Dtg_LibrosNoConciliados.Columns["Monto"].ReadOnly = true;


                //Asigno las caracteristicas del combo
                ((DataGridViewComboBoxColumn) _Dtg_LibrosNoConciliados.Columns["comboestadolibro"]).AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                ((DataGridViewComboBoxColumn) _Dtg_LibrosNoConciliados.Columns["comboestadolibro"]).DataSource = _Mtd_LlenarEstadoLibro();
                ((DataGridViewComboBoxColumn) _Dtg_LibrosNoConciliados.Columns["comboestadolibro"]).DisplayMember = "Display";
                ((DataGridViewComboBoxColumn) _Dtg_LibrosNoConciliados.Columns["comboestadolibro"]).ValueMember = "Value";
                ((DataGridViewComboBoxColumn) _Dtg_LibrosNoConciliados.Columns["comboestadolibro"]).Width = 300;

            }
            catch (Exception oException)
            {
            }
        }

        private void _Mtd_SetearLibroNoConciliados()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                //Cargo los estados
                string _Str_SentenciaSQL = "SELECT * FROM TESTADOSOPERL";
                _G_Ds_EstadosLibro = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSQL);

                //Obtengo los estados y lo guardo en el datatable
                foreach (DataRow _Fila in _G_Dt_LibroNoConciliado.Rows)
                {
                    //Obtengo los valores
                    var _Str_ccompany = Frm_Padre._Str_Comp;
                    var _Str_cidcomprob = _Fila["cidcomprob"].ToString();
                    var _Str_corder = _Fila["corder"].ToString();
                    //Obtenemos el estado que corresponda
                    string _cestadoid = Obtener_cestadoid_Libro(_Str_ccompany, _Str_cidcomprob, _Str_corder);
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

        private void _Mtd_SetearCombosLibroNoConciliado()
        {
            _G_EstamosSeteandoCombos = true;
            //Selecciono cada combo en función a la tabla de estados
            foreach (DataGridViewRow _Fila in _Dtg_LibrosNoConciliados.Rows)
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

        private void _Mtd_ColorearLibroNoConciliados()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                //Selecciono cada combo en función a la tabla de estados
                foreach (DataGridViewRow _Fila in _Dtg_LibrosNoConciliados.Rows)
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

        private void _Mtd_OrdenarLibroNoConciliado()
        {
            var _LibroNoConciliado = _G_Dt_LibroNoConciliado.AsEnumerable().OrderBy(o => o.Field<Int32>("estado"));
            if (_LibroNoConciliado.Any())
                _G_Dt_LibroNoConciliado = _LibroNoConciliado.CopyToDataTable();
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

            //por ticket 19876 se valida que para finaliza la conciliacion no existan comprobantes de ajustes manuales para el banco y cuenta seleccionado que esten sin actualizar
            if (_Mtd_HayComprobantesManualesPorActualizar(Frm_Padre._Str_Comp, _G_Int_IdConciliacion.ToString()))
            {
                Cursor = Cursors.Default;
                MessageBox.Show("No se puede continuar debido que existen comprobantes de ajustes manuales por actualizar. Debe actualizarlos para poder continuar con el proceso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            _G_Int_Paso = 2;
            _Tab_PasosConciliacion.SelectedIndex = _G_Int_Paso - 1;
            if (_G_Bol_ModoGuardar)
            {
                bool _Bol_ConciliacionesManuales = false;
                _Mtd_CrearConciliacion(ref _Bol_ConciliacionesManuales, _G_Int_IdConciliacion);
                if (_Bol_ConciliacionesManuales)
                {
                    MessageBox.Show("Debe esperar la aprobación de las conciliaciones manuales.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre) this.MdiParent)._Frm_Contenedor._async_Default);
                    this.Close();
                }
                else
                {
                    _Mtd_CargarBancoNoConciliado();
                }
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
                _Mtd_CargarLibroNoConciliado();
            }
            Cursor = Cursors.Default;
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

            //por ticket 19876 se valida que para finaliza la conciliacion no existan comprobantes de ajustes manuales para el banco y cuenta seleccionado que esten sin actualizar
            if (_Mtd_HayComprobantesManualesPorActualizar(Frm_Padre._Str_Comp, _G_Int_IdConciliacion.ToString()))
            {
                Cursor = Cursors.Default;
                MessageBox.Show("No se puede guadar la conciliación debido que existen comprobantes de ajustes manuales por actualizar. Debe actualizarlos para poder continuar con el proceso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            //Valido los estados
            if (!_Mtd_EsValidoEstadosBancoNoConciliado())
            {
                return;
            }
            _Btn_AnteriorReporte.Visible = true;
            _Er_Error.Dispose();
            _G_Int_Paso = 3;
            if (_Mtd_GuardarConciliacion())
            {
                Cursor = Cursors.WaitCursor;
                //Me coloco en la pestaña reporte 
                _Tab_Contenedor.SelectedIndex = 2;
                //Muestro el Reporte de la Conciliacion
                _Mtd_MostrarReporteConciliacion(_G_Int_IdConciliacion.ToString(CultureInfo.InvariantCulture), Frm_Padre._Str_Comp);
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
                            _G_Str_SentenciaSql = "UPDATE TCONCILIACION SET CIMPRESO='1' WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND cidconciliacion='" + _G_Int_IdConciliacion.ToString(CultureInfo.InvariantCulture) + "'";
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
                //Mando a Imprimir
                _Mtd_ImprimirReporte();
                //Inicializo el Formulario
                _Cmb_BancoConsulta.SelectedIndex = 0;
                _Cmb_CuentaConsulta.DataSource = null;
                _Cmb_CuentaConsulta.Enabled = false;
                _G_Bol_ModoReporte = false;
                _Tab_Contenedor.SelectedIndex = 0;
                _Mtd_ConsultarConciliacion("", "");
            }
            else
            {
                if (
                    MessageBox.Show(
                        "La acción solicitada finalizará la conciliación y usted ya no podrá realizar modificaciones. ¿Está seguro de continuar?",
                        "Información", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _Er_Error.Dispose();
                    _G_Int_Paso = 4;
                    if (_Mtd_FinalizarConciliacion())
                    {
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
                        _Mtd_ConsultarConciliacion("", "");
                    }
                }

            }
        }


        private void _Dtp_Hasta_ValueChanged(object sender, EventArgs e)
        {
            //_Dtp_Desde.MaxDate = _Dtp_Hasta.Value;
        }

        private void _Dtp_Desde_ValueChanged(object sender, EventArgs e)
        {
            //Si la fecha es menor o igual que hoy
            if (_Dtp_Desde.Value.Date <= DateTime.Now.Date)
            {
                var _Dt_FechaActual = DateTime.Now.Date;
                var _Dt_FechaDesde = _Dtp_Desde.Value.Date;
                var _Dt_UltimoDiaMesSeleccionadoDesde = new DateTime(_Dt_FechaDesde.Year, _Dt_FechaDesde.Month, DateTime.DaysInMonth(_Dt_FechaDesde.Year, _Dt_FechaDesde.Month)).Date;
                //MessageBox.Show((_Dt_UltimoDiaMes < _Dt_FechaActual ? _Dt_UltimoDiaMes : _Dt_FechaActual).ToString()); OJO esto es para poder depurar en mi computador ya que sino se cuelga :( Ignacio //11/12/2013
                if (_Dt_UltimoDiaMesSeleccionadoDesde < _Dt_FechaActual)
                {
                    _Dtp_Hasta.MinDate = _Dtp_Desde.MinDate;
                    _Dtp_Hasta.MaxDate = _Dt_UltimoDiaMesSeleccionadoDesde;
                    _Dtp_Hasta.Value = _Dt_UltimoDiaMesSeleccionadoDesde;
                }
                else
                {
                    _Dtp_Hasta.MinDate = _Dtp_Desde.MinDate;
                    _Dtp_Hasta.MaxDate = DateTime.Now.AddDays(-1).Date;
                    _Dtp_Hasta.Value = DateTime.Now.AddDays(-1).Date;
                }
            }
            else
            {
                _Dtp_Desde.Value = DateTime.Now.Date;
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
            // 0ra CORRIDA -> Concilicio los registros que provengan de ajustes aprobados
            // - -
            //Recorremos cada registro del banco

            //Cargamos solo los registros que tengan un ajustes relacionado
            var _Registros_Banco = _G_Ds_BancoLibro.Tables[0].AsEnumerable().Where(x => 
                                                                                   x["Tip.Reg."].ToString().ToUpper() == "BANCO"
                                                                                && Convert.ToInt32(x["cidconciliacion"]) > 0
                                                                                && Convert.ToInt32(x["ciddetalleconciliacion"]) > 0
                                                                                && x["cconciliado"].ToString() == "0"
                );
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
                    var _Int_cidconciliacion = Convert.ToInt32(_Dtw_ItemBanco["cidconciliacion"].ToString());
                    var _Int_ciddetalleconciliacion = Convert.ToInt32(_Dtw_ItemBanco["ciddetalleconciliacion"].ToString());
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
                            _Consulta = _G_Ds_BancoLibro.Tables[0].AsEnumerable()
                                                                  .Where(x => x["Tip.Reg."].ToString().ToUpper() == "LIBRO")
                                                                  .Where(x =>
                                                                         !String.IsNullOrEmpty(x["Número Doc."].ToString())
                                                                         && x["cconciliado"].ToString() == "0"
                                                                         && Convert.ToInt32(x["cidconciliacion"]) == _Int_cidconciliacion
                                                                         && Convert.ToInt32(x["ciddetalleconciliacion"]) == _Int_ciddetalleconciliacion
                                                                         && (
                                                                                x["Número Doc."].ToString() == _Str_NumeroDeDocumento
                                                                                ||
                                                                                x["Concepto"].ToString().Contains(_Str_NumeroDeDocumento))

                                );
                        }
                        else
                        {
                            _Consulta = _G_Ds_BancoLibro.Tables[0].AsEnumerable()
                                                                  .Where(x => x["Tip.Reg."].ToString().ToUpper() == "LIBRO")
                                                                  .Where(x =>
                                                                         x["cconciliado"].ToString() == "0"
                                                                         && Convert.ToInt32(x["cidconciliacion"]) == _Int_cidconciliacion
                                                                         && Convert.ToInt32(x["ciddetalleconciliacion"]) == _Int_ciddetalleconciliacion
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
            // 1ra CORRIDA -> Tomando como Origen Banco
            // - -
            //Recorremos cada registro del banco

            _Registros_Banco = _G_Ds_BancoLibro.Tables[0].AsEnumerable().Where(x => x["Tip.Reg."].ToString().ToUpper() == "BANCO" && x["cconciliado"].ToString() == "0");
            _Int_CantidadRegistroBanco = _Registros_Banco.Count();
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
                            _Consulta = _G_Ds_BancoLibro.Tables[0].AsEnumerable()
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
                            _Consulta = _G_Ds_BancoLibro.Tables[0].AsEnumerable()
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
            var _Registros_Libro = _G_Ds_BancoLibro.Tables[0].AsEnumerable().Where(x => x["Tip.Reg."].ToString().ToUpper() == "LIBRO" && x["cconciliado"].ToString() == "0");
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

            // - -
            // 3da CORRIDA -> Si hay comisiones e intereses segun tabla configurada, se marcan como conciliaciones manuales automaticas xD 
            // - -

            //Cargamos de nuevo las variables con solo registros no conciliados
            _Registros_Banco = _G_Ds_BancoLibro.Tables[0].AsEnumerable().Where(x => x["Tip.Reg."].ToString().ToUpper() == "BANCO" && x["cconciliado"].ToString() == "0");
            _Int_CantidadRegistroBanco = _Registros_Banco.Count();
            //Si hay registros
            if (_Int_CantidadRegistroBanco > 0)
            {
                //Pasamos a la tabla
                var _Dt_Banco = _Registros_Banco.CopyToDataTable();

                //Recorremos cada registro del banco que no este conciliado
                foreach (DataRow _Dtw_ItemBanco in _Dt_Banco.Rows)
                {

                    //Verificamos si el registro corresponde con uno de los tipos de operaciones configuradas para generar ajuses automaticos (Comisiones e Intereses)
                    var _Str_cGeneraAjustesAutomaticos = _Dtw_ItemBanco["cGeneraAjustesAutomaticos"].ToString();

                    //Si se debe generar
                    var _Bol_SeDebeGenerarAjusteAutomatico = true;
                    if (_Str_cGeneraAjustesAutomaticos.Length > 0)
                    {
                        //Verificamos si ya no fue conciliado anteriormente en una conciliacion manual.. (por defecto se genere hasta que se demuestre lo contrario)
                        var _cdispbanc = _Dtw_ItemBanco["cdispbanc"].ToString();
                        var _cdispband = _Dtw_ItemBanco["cdispband"].ToString();
                        //Cargo las conciliaciones no finalizadas
                        var _Str_Sql = "SELECT cidconciliaciondmanual FROM TCONCILIACIOND_MANUALV2 WHERE ccompany='" + Frm_Padre._Str_Comp + "' and ciddispbanc='" + _cdispbanc + "' and ciddispband='" + _cdispband + "' AND ISNULL(TCONCILIACIOND_MANUALV2.cdelete,0)=0 ";
                        var _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        //Verifico si se obtuvo algo
                        if (_Ds2.Tables[0].Rows.Count > 0)
                        {
                            _Bol_SeDebeGenerarAjusteAutomatico = false;
                        }
                    }
                    else
                    {
                        _Bol_SeDebeGenerarAjusteAutomatico = false;
                    }

                    //Si se debe generar el ajuste
                    if (_Bol_SeDebeGenerarAjusteAutomatico)
                    {
                        //Ubicamos el registro del libro
                        var _RegistroBanco = _G_Ds_BancoLibro.Tables[0]
                            .AsEnumerable()
                            .SingleOrDefault(x =>
                                             x["cdispband"].ToString() == _Dtw_ItemBanco["cdispband"].ToString()
                                             && x["cdispbanc"].ToString() == _Dtw_ItemBanco["cdispbanc"].ToString()
                            );

                        int _Int_IndexBanco_BancoLibro = _G_Ds_BancoLibro.Tables[0].Rows.IndexOf(_RegistroBanco);

                        //Actualizo el contador atomico
                        _G_Int_Ciddetalleconciliacion++;

                        //-->Banco
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["cconciliado"] = "1";
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["cconciliadoAutomaticamente"] = "1";
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["coperbancseleccionado"] = "";
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["cseleccionado"] = _G_Str_SeleccionadoManual;
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["cidcomprob"] = 0;
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["corder"] = 0;
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["estado"] = "0";
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["estadodescripcion"] = "";
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["cidedetalleconciliacion"] = _G_Int_Ciddetalleconciliacion;
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro]["ctipoajuste"] = (byte)Frm_AprobConcManuales.Tipoajuste.ComisionesEIntereses;
                        _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexBanco_BancoLibro].AcceptChanges();

                    }
                }
            }

            // - -
            // 4da CORRIDA -> Cruces de Movimientos Contables
            // - -

            //Cargamos de nuevo las variables con solo registros no conciliados
            _Registros_Libro = _G_Ds_BancoLibro.Tables[0].AsEnumerable().Where(x => x["Tip.Reg."].ToString().ToUpper() == "LIBRO" && x["cconciliado"].ToString() == "0");
            _Int_CantidadRegistroLibro = _Registros_Libro.Count();
            //Si hay registros
            if (_Int_CantidadRegistroLibro > 0)
            {
                //Pasamos a la tabla
                var _Dt_Libro = _Registros_Libro.CopyToDataTable();

                //Recorremos cada registro del libro que no este conciliado
                foreach (DataRow _Dtw_ItemLibro1 in _Dt_Libro.Rows)
                {
                    string _Str_NumeroDeDocumento = _Dtw_ItemLibro1[2].ToString();
                    //Si existe un numero de documento
                    if (_Str_NumeroDeDocumento.Length >= 0)
                    {
                        Int64 _Int_NumeroDocumento = 0; // Convert.ToInt64(_Str_NumeroDeDocumento);
                        Int64.TryParse(_Str_NumeroDeDocumento, out _Int_NumeroDocumento);

                        //Obtengo aquellos registros de libro donde coincida el numero de documento
                        //Consulto
                        EnumerableRowCollection<DataRow> _Consulta;
                        if (_Str_NumeroDeDocumento.Length > 0)
                        {
                            _Consulta = _G_Ds_BancoLibro.Tables[0].AsEnumerable()
                                                                  .Where(x => x["Tip.Reg."].ToString().ToUpper() == "LIBRO" && x["cconciliado"].ToString() == "0")
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
                                                                  .Where(x => x["Tip.Reg."].ToString().ToUpper() == "LIBRO" && x["cconciliado"].ToString() == "0")
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
                        EnumerableRowCollection<DataRow> _Dtw_ItemsSeleccionadosLibro = _Consulta.Cast<DataRow>();

                        //Si se obtuvo filas de Banco
                        if (_Dtw_ItemsSeleccionadosLibro.Any())
                        {
                            var _Bool_Fueconciliado = false;

                            //Recorremos los registros que coinciden
                            foreach (DataRow _Dtw_ItemLibro2 in _Dtw_ItemsSeleccionadosLibro)
                            {
                                if (!_Bool_Fueconciliado)
                                {
                                    var _Bool_ItemLibro1_Fueconciliado = false;
                                    var _Bool_ItemLibro2_Fueconciliado = false;

                                    //Ubicamos los registros en el dataset
                                    var _RegistroLibro1 = _G_Ds_BancoLibro.Tables[0]
                                        .AsEnumerable()
                                        .SingleOrDefault(x =>
                                                         x["cidcomprob"].ToString() == _Dtw_ItemLibro1["cidcomprob"].ToString()
                                                         && x["corder"].ToString() == _Dtw_ItemLibro1["corder"].ToString()
                                        );

                                    var _RegistroLibro2 = _G_Ds_BancoLibro.Tables[0]
                                        .AsEnumerable()
                                        .SingleOrDefault(x =>
                                                         x["cidcomprob"].ToString() == _Dtw_ItemLibro2["cidcomprob"].ToString()
                                                         && x["corder"].ToString() == _Dtw_ItemLibro2["corder"].ToString()
                                        );

                                    //Verificamos si el registro fue ya conciliado en una vuelta anterior del foreach (esto evita remarcaje de registros ya conciliados )
                                    if (_RegistroLibro1 != null) _Bool_ItemLibro1_Fueconciliado = _RegistroLibro1["cconciliado"].ToString() == "1";
                                    if (_RegistroLibro2 != null) _Bool_ItemLibro2_Fueconciliado = _RegistroLibro2["cconciliado"].ToString() == "1";
                                    
                                    int _Int_IndexLibro1_BancoLibro = _G_Ds_BancoLibro.Tables[0].Rows.IndexOf(_RegistroLibro1);
                                    int _Int_IndexLibro2_BancoLibro = _G_Ds_BancoLibro.Tables[0].Rows.IndexOf(_RegistroLibro2);

                                    //Solo si el registro es distinto a el mismo y ambos estan no conciliados
                                    if ((_Int_IndexLibro1_BancoLibro != _Int_IndexLibro2_BancoLibro) && (!_Bool_ItemLibro1_Fueconciliado && !_Bool_ItemLibro2_Fueconciliado))
                                    {
                                        //Obtenemos los Montos
                                        decimal _Dec_MontoLibro1 = 0;
                                        decimal _Dec_MontoLibro2 = 0;
                                        decimal _Dec_SaldoMontos = 0;
                                        if ((_RegistroLibro1 != null) & (_RegistroLibro2 != null))
                                        {
                                            _Dec_MontoLibro1 = Convert.ToDecimal(_Dtw_ItemLibro1["monto"]);
                                            _Dec_MontoLibro2 = Convert.ToDecimal(_Dtw_ItemLibro2["monto"]);
                                            _Dec_SaldoMontos = _Dec_MontoLibro1 + _Dec_MontoLibro2;
                                        }

                                        //verifico que los saldos se salden
                                        if (_Dec_SaldoMontos == 0)
                                        {
                                            //Marcamos como conciliado en el foreach
                                            _Bool_Fueconciliado = true;

                                            //Actualizo el contador atomico
                                            _G_Int_Ciddetalleconciliacion++;

                                            //-->Libro 1
                                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro1_BancoLibro]["cconciliado"] = "1";
                                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro1_BancoLibro]["cconciliadoAutomaticamente"] = "1";
                                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro1_BancoLibro]["coperbancseleccionado"] = "";
                                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro1_BancoLibro]["cseleccionado"] = _G_Str_SeleccionadoManual;
                                            //_G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro1_BancoLibro]["cidcomprob"] = _Dtw_ItemLibro2["cidcomprob"].ToString();
                                            //_G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro1_BancoLibro]["corder"] = _Dtw_ItemLibro2["corder"].ToString();
                                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro1_BancoLibro]["estado"] = "0";
                                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro1_BancoLibro]["estadodescripcion"] = "";
                                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro1_BancoLibro]["cidedetalleconciliacion"] = _G_Int_Ciddetalleconciliacion;
                                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro1_BancoLibro]["ctipoajuste"] = (byte)Frm_AprobConcManuales.Tipoajuste.CruceMovimientosContables;
                                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro1_BancoLibro].AcceptChanges();
                                            //-->Libro 2
                                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro2_BancoLibro]["cconciliado"] = "1";
                                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro2_BancoLibro]["cconciliadoAutomaticamente"] = "1";
                                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro2_BancoLibro]["coperbancseleccionado"] = "";
                                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro2_BancoLibro]["cseleccionado"] = _G_Str_SeleccionadoManual;
                                            //_G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro2_BancoLibro]["cidcomprob"] = _Dtw_ItemLibro1["cidcomprob"].ToString();
                                            //_G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro2_BancoLibro]["corder"] = _Dtw_ItemLibro1["corder"].ToString();
                                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro2_BancoLibro]["estado"] = "0";
                                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro2_BancoLibro]["estadodescripcion"] = "";
                                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro2_BancoLibro]["cidedetalleconciliacion"] = _G_Int_Ciddetalleconciliacion;
                                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro2_BancoLibro]["ctipoajuste"] = (byte)Frm_AprobConcManuales.Tipoajuste.CruceMovimientosContables;
                                            _G_Ds_BancoLibro.Tables[0].Rows[_Int_IndexLibro2_BancoLibro].AcceptChanges();

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            ////Cargamos el DataSet
            //var _G_Dt_BancoLibroConciliado = _G_Ds_BancoLibro.Tables[0];

            ////Ordenamos
            //var _Registros_Todos = _G_Dt_BancoLibroConciliado.AsEnumerable()
            //                                                 .OrderByDescending(n => n["cconciliado"])
            //                                                 .ThenBy(o => decimal.Parse(o["Monto"].ToString()))
            //                                                 .ThenBy(p => p["Número Doc."]);
            ////Si hay datos
            //if (_Registros_Todos.Any())
            //    _G_Dt_BancoLibroConciliado = _Registros_Todos.CopyToDataTable();

            ////Paso el Dataset Actualizado
            //_Dtg_ConciliarBancoLibro.DataSource = _G_Dt_BancoLibroConciliado.DefaultView;

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
            ;

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
            // - = - = - = - = - = - = - = - = - = - = - = - = - = Validaciones de de que ninguno ya este conciliado manualmente - = - = - = - = - = - = - = - = - = - = - = - = - = 
            // - = 
            //Valido que los registro del banco no este ya en alguna conciliacion manual
            var _RegistrosBancoSeleccionadoAValidar = _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Where(x => x.Cells["Tip.Reg."].Value.ToString().ToUpper() == "BANCO").ToList();
            foreach (var _oRegistroBanco in _RegistrosBancoSeleccionadoAValidar)
            {
                var _cdispbanc = _oRegistroBanco.Cells["cdispbanc"].Value.ToString();
                var _cdispband = _oRegistroBanco.Cells["cdispband"].Value.ToString();
                //Cargo las conciliaciones no finalizadas
                var _Str_Sql = "SELECT cidconciliaciondmanual FROM TCONCILIACIOND_MANUALV2 WHERE ccompany='" + Frm_Padre._Str_Comp + "' and ciddispbanc='" + _cdispbanc + "' and ciddispband='" + _cdispband + "' and cdelete='0' ";
                var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                //Verifico si se obtuvo algo
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(
                        _RegistrosBancoSeleccionadoAValidar.Count() > 1
                            ? "Alguno de los registros de Banco Seleccionado ya fue usado en otra conciliacion manual"
                            : "El registro de Banco Seleccionado ya fue usado en otra conciliacion manual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    _P_oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.SinAsignar;
                    return false;
                }
            }

            //Valido que los registro del libro no este ya en alguna conciliacion manual
            var _RegistrosLibroSeleccionadoAValidar = _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Where(x => x.Cells["Tip.Reg."].Value.ToString().ToUpper() == "LIBRO").ToList();
            foreach (var _oRegistroLibro in _RegistrosLibroSeleccionadoAValidar)
            {
                string _cidcomprob = _oRegistroLibro.Cells["cidcomprob"].Value.ToString();
                string _corder = _oRegistroLibro.Cells["corder"].Value.ToString();
                //Cargo las conciliaciones no finalizadas
                var _Str_Sql = "SELECT cidconciliaciondmanual FROM TCONCILIACIOND_MANUALV2 WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _cidcomprob + "' and corder='" + _corder + "' and cdelete='0' ";
                var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                //Verifico si se obtuvo algo
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(
                        _RegistrosLibroSeleccionadoAValidar.Count() > 1
                            ? "Alguno de los registros de Libro Seleccionado ya fue usado en otra conciliacion manual"
                            : "El registro de Libro Seleccionado ya fue usado en otra conciliacion manual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _P_oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.SinAsignar;
                    return false;
                }
            }

            // - = 
            // - = - = - = - = - = - = - = - = - = - = - = - = - = Validaciones de cantidades de registros seleccionados - = - = - = - = - = - = - = - = - = - = - = - = - = 
            // - = 
            var _Int_CantidadFilasSeleccionadasLibro = _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Count(x => x.Cells["Tip.Reg."].Value.ToString().ToUpper() == "LIBRO");
            var _Int_CantidadFilasSeleccionadasBanco = _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Count(x => x.Cells["Tip.Reg."].Value.ToString().ToUpper() == "BANCO");
            Boolean _Bool_SeleccionValida;

            //Obtenemos la sumatoria de los registros
            var _Dcm_SumatoriaLibro = _Int_CantidadFilasSeleccionadasLibro == 0 ? 0 : _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Where(x => x.Cells["Tip.Reg."].Value.ToString().ToUpper() == "LIBRO").Sum(x => Convert.ToDecimal(x.Cells["Monto"].Value));
            var _Dcm_SumatoriaBanco = _Int_CantidadFilasSeleccionadasBanco == 0 ? 0 : _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Where(x => x.Cells["Tip.Reg."].Value.ToString().ToUpper() == "BANCO").Sum(x => Convert.ToDecimal(x.Cells["Monto"].Value));
            var _Dcm_Saldo = Math.Round(_Dcm_SumatoriaLibro - _Dcm_SumatoriaBanco, 2);

            //Caso normal : 1 Libro <-> 1 Banco
            if ((_Int_CantidadFilasSeleccionadasLibro == 1) && (_Int_CantidadFilasSeleccionadasBanco == 1))
            {
                _Bool_SeleccionValida = true;
                if (_Dcm_Saldo == 0)
                    _oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.UnoAUnoDiferenciaNumero;
                else
                    _oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.UnoAUnoDiferenciaMonto;
            }
            //Caso Multiple : >=2 Libro <-> 1 Banco
            else if ((_Int_CantidadFilasSeleccionadasLibro >= 2) && (_Int_CantidadFilasSeleccionadasBanco == 1))
            {
                _Bool_SeleccionValida = true;
                if (_Dcm_Saldo == 0)
                    _oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.MultiplesAgrupamientoRegistros;
                else
                    _oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.MultiplesAgrupamientoRegistrosConDiferenciaMonto;
            }
            //Caso Multiple : 1 Libro <-> >=2 Banco
            else if ((_Int_CantidadFilasSeleccionadasLibro == 1) && (_Int_CantidadFilasSeleccionadasBanco >= 2))
            {
                _Bool_SeleccionValida = true;
                if (_Dcm_Saldo == 0)
                    _oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.MultiplesDivisionRegistros;
                else
                    _oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.MultiplesDivisionRegistrosConDiferenciaMonto;
            }
            //Caso CruceMovimientosContables : >=2 Libro <-> 0 Banco
            else if ((_Int_CantidadFilasSeleccionadasLibro >= 2) && (_Int_CantidadFilasSeleccionadasBanco == 0))
            {
                //Validacion de Montos (Deben dar cero la sumatoria de ellos)
                var _Dcm_Sumatoria = _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Convert.ToDecimal(x.Cells["Monto"].Value));
                if (_Dcm_Sumatoria != 0)
                {
                    MessageBox.Show("Los sumatoria de los montos debe ser cero.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _P_oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.SinAsignar;
                    return false;
                }
                _Bool_SeleccionValida = true;
                _oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.CruceMovimientosContables;
            }
            //Caso CruceMovimientosBanco : 0 Libro <-> 2 Banco
            else if ((_Int_CantidadFilasSeleccionadasLibro == 0) && (_Int_CantidadFilasSeleccionadasBanco == 2))
            {
                //Validacion de Montos (Deben dar cero la sumatoria de ellos)
                var _Dcm_Sumatoria = _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Convert.ToDecimal(x.Cells["Monto"].Value));
                //Redondeo por si acaso
                _Dcm_Sumatoria = Math.Round(_Dcm_Sumatoria, 2);
                if (_Dcm_Sumatoria != 0)
                {
                    MessageBox.Show("Los sumatoria de los montos debe ser cero.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _P_oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.SinAsignar;
                    return false;
                }
                _Bool_SeleccionValida = true;
                _oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.CruceMovimientosBanco;
            }
            //Caso Comisiones e Intereses (con o sin reversos) : 0 Libro <-> 1 Banco
            else if ((_Int_CantidadFilasSeleccionadasLibro == 0) && (_Int_CantidadFilasSeleccionadasBanco == 1))
            {
                //Obtenemos el operbanc del registro de banco
                var _RegistroBanco = _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().FirstOrDefault(x => x.Cells["Tip.Reg."].Value.ToString().ToUpper() == "BANCO");
                var _Str_coperbanc = "";
                var _Bol_EsReverso = false;
                if (_RegistroBanco != null)
                {
                    var _Str_coperbanc_Original = _RegistroBanco.Cells["coperbancseleccionado"].ToString().ToUpper();

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
                _Bool_SeleccionValida = true;
                if (_Bol_EsReverso)
                    _oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.ComisionesEIntereses_Reverso;
                else
                    _oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.ComisionesEIntereses;
            }
            //Caso Multiples Registros de Banco con Multiples registros de libro
            else if ((_Int_CantidadFilasSeleccionadasLibro >= 2) && (_Int_CantidadFilasSeleccionadasBanco >= 2))
            {
                //Validamos que los registros de banco sean todos positivos
                var _Bol_HayRegistrosDeBancoNegativos = _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Any(x => x.Cells["Tip.Reg."].Value.ToString().ToUpper() == "BANCO" && (Convert.ToDecimal(x.Cells["Monto"].Value) < 0));
                if (_Bol_HayRegistrosDeBancoNegativos)
                {
                    MessageBox.Show("Los registros seleccionados del banco deben ser positivos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _P_oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.SinAsignar;
                    return false;
                }

                //Validamos los numeros de documentos
                //Obtenemos una lista de los numeros de documento
                var _Lst_NumerosDocumentos = _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Where(x => x.Cells["Tip.Reg."].Value.ToString().ToUpper() == "BANCO").Select(x => x.Cells["Número Doc."].Value.ToString());
                //Limpiamos y convertimos a numericos
                var _Lst_Int_NumerosDocumento = new List<Int64>();
                _Lst_NumerosDocumentos.ToList().ForEach(x =>
                {
                    Int64 _Int_NumeroDocumento = 0;
                    Int64.TryParse(x, out _Int_NumeroDocumento);
                    _Lst_Int_NumerosDocumento.Add(_Int_NumeroDocumento);
                });
                var _Bol_NumerosDocumentosSonConsecutivos = !_Lst_Int_NumerosDocumento.Select((i, j) => i - j).Distinct().Skip(1).Any();

                //Validamos los ultimos digitos del concepto
                //Obtenemos una lista de los conceptos
                var _Lst_Conceptos = _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Where(x => x.Cells["Tip.Reg."].Value.ToString().ToUpper() == "BANCO").Select(x => x.Cells["Concepto"].Value.ToString());
                _Lst_Int_NumerosDocumento = new List<Int64>();
                _Lst_Conceptos.ToList().ForEach(x =>
                    {
                        //Extraemos del concepto los ultimos digitos
                        var _Str_Digitos = "";

                        if (!String.IsNullOrEmpty(x))
                        {
                            if (x != null) 
                                _Str_Digitos = x.Substring(x.Length - 3);
                        }
                        //Limpiaamos
                        _Str_Digitos = _Str_Digitos.Trim();

                        //Limpiamos y convertimos a numericos
                        Int64 _Int_NumeroDocumento = 0;
                        Int64.TryParse(_Str_Digitos, out _Int_NumeroDocumento);
                        _Lst_Int_NumerosDocumento.Add(_Int_NumeroDocumento);
                    });
                var _Bol_UltimosDigitosConceptoSonConsecutivos = !_Lst_Int_NumerosDocumento.Select((i, j) => i - j).Distinct().Skip(1).Any();

                //Verificamos las secuencias
                if (!_Bol_NumerosDocumentosSonConsecutivos && !_Bol_UltimosDigitosConceptoSonConsecutivos)
                {
                    MessageBox.Show("Los números de documentos o los últimos digitos del concepto de los registros seleccionados del banco deben ser consecutivos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _P_oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.SinAsignar;
                    return false;
                }

                //Devolvemos
                _Bool_SeleccionValida = true;
                if (_Dcm_Saldo == 0)
                    _oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.MuchosLibrosConMuchosBancos;
                else
                    _oTipoAjuste = Frm_AprobConcManuales.Tipoajuste.MuchosLibrosConMuchosBancosConDiferenciaMonto;
            }
            else
            {
                _Bool_SeleccionValida = false;
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

            //------------------------  Validación quitada por solicitud de carlos longa al 02/10/2014 ------------------------
            ////Verificamos que todos los registros esten marcados como conciliados automáticos y por comision
            //var _Bool_HayRegistrosConciliadosAutomaticamente = _Dtg_ConciliarBancoLibro.SelectedRows.Cast<DataGridViewRow>().AsEnumerable().Any(x => x.Cells["cconciliadoAutomaticamente"].Value.ToString() == "1" &&
            //                                                                                                                                         x.Cells["BancoConChecked"].Value.ToString() != _G_Str_SeleccionadoManual);
            //if (_Bool_HayRegistrosConciliadosAutomaticamente)
            //{
            //    MessageBox.Show("No se pueden desconciliar registros conciliados automáticamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            //------------------------  Validación quitada por solicitud de carlos longa al 02/10/2014 ------------------------

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

        private void _Mtd_EliminarConciliacionesNoFinalizadas(bool _P_Bool_EliminarMaestra, int _P_Int_IdConciliacion)
        {

            //Cargo las conciliaciones no finalizadas
            string _Str_Sql = "SELECT cidconciliacion FROM TCONCILIACION WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cbanco='" + _Cmb_BancoDetalle.SelectedValue.ToString() + "' and cnumcuenta='" +
                              _Cmb_CuentaDetalle.SelectedValue.ToString() + "' and cfinalizado=0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //Verifico si se obtuvo algo
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                //Recorro 
                for (int intI = 0; intI < _Ds.Tables[0].Rows.Count; intI++)
                {
                    //Elimino los Detalles
                    _Str_Sql = "DELETE FROM TCONCILIACIOND WHERE CIDCONCILIACION = " + _Ds.Tables[0].Rows[intI][0] + "AND ccompany='" + Frm_Padre._Str_Comp + "' ";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);

                    //Solicitud 3885 
                    //Agregar Limpieza de Detalles no Usados
                    //Elimino los Detalles
                    _Str_Sql = "DELETE FROM TCONCILIACIONDBANCO WHERE CIDCONCILIACION = " + _Ds.Tables[0].Rows[intI][0] + "AND ccompany='" + Frm_Padre._Str_Comp + "' ";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);

                    //Elimino los Detalles
                    _Str_Sql = "DELETE FROM TCONCILIACIONDLIBRO WHERE CIDCONCILIACION = " + _Ds.Tables[0].Rows[intI][0] + "AND ccompany='" + Frm_Padre._Str_Comp + "' ";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);

                    //Elimino los Detalles
                    _Str_Sql = "DELETE FROM TCONCILIACIONDMAYORANALITICO WHERE CIDCONCILIACION = " + _Ds.Tables[0].Rows[intI][0] + "AND ccompany='" + Frm_Padre._Str_Comp + "' ";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);

                    //Obtengo el codigo de la conciliacion a verificar
                    var _Str_cidconciliacion = _Ds.Tables[0].Rows[intI][0];

                    //Verifico si la conciliacion tiene conciliaciones manuales cargados, tampoco se eliminar la maestra
                    var _Str_Sql2 = "SELECT cidconciliacion FROM TCONCILIACIOND_MANUALV2 WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cidconciliacion='" + _Str_cidconciliacion + "' AND ISNULL(TCONCILIACIOND_MANUALV2.cdelete,0)=0";
                    var _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql2);
                    //Si la conciliacion no tiene ajustes
                    if (_Ds2.Tables[0].Rows.Count == 0)
                    {
                        //Si esta indicado eliminar la maestra y la
                        if (_P_Bool_EliminarMaestra & (_P_Int_IdConciliacion == 0))
                        {
                            //Elimino las Maestras
                            _Str_Sql = "DELETE FROM TCONCILIACION WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cbanco='" + _Cmb_BancoDetalle.SelectedValue.ToString() + "' and cnumcuenta='" + _Cmb_CuentaDetalle.SelectedValue.ToString() + "' and cfinalizado=0";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        }
                    }
                }
            }
        }

        private bool _Mtd_HayComprobantesManualesPorActualizar(string _P_Str_Compania, string _P_Str_IDConciliacion)
        {
            var _Str_SentenciaSql = "SELECT cbanco, cnumcuenta FROM TCONCILIACION WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND cidconciliacion = '" + _P_Str_IDConciliacion + "'";
            var _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSql);
            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
            {
                var _Str_cbanco = _Ds_DataSet.Tables[0].Rows[0]["cbanco"].ToString().Trim();
                var _Str_cnumcuenta = _Ds_DataSet.Tables[0].Rows[0]["cnumcuenta"].ToString().Trim();

                _Str_SentenciaSql = "SELECT ccount FROM TCUENTBANC WHERE CCOMPANY='" + _P_Str_Compania + "' AND cnumcuenta='" + _Str_cnumcuenta + "' AND CBANCO='" + _Str_cbanco + "' and cdelete='0'";
                _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSql);
                if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                {
                    var _Str_CuentaContable = _Ds_DataSet.Tables[0].Rows[0]["ccount"].ToString().Trim();
                    _Str_SentenciaSql = "SELECT TCONCILIACIOND_MANUALV2.cidconciliaciondmanual,TCONCILIACIOND_MANUALV2.cidconciliacion,TCONCILIACIOND_MANUALV2.ciddetalleconciliacion,TCONCILIACIOND_MANUALV2.cidcomprob_nuevo " +
                                        "FROM TCONCILIACIOND_MANUALV2 INNER JOIN TCOMPROBANC ON TCONCILIACIOND_MANUALV2.cidcomprob_nuevo = TCOMPROBANC.cidcomprob AND TCONCILIACIOND_MANUALV2.ccompany = TCOMPROBANC.ccompany INNER JOIN TCOMPROBAND ON TCOMPROBANC.ccompany = TCOMPROBAND.ccompany AND TCOMPROBANC.cidcomprob = TCOMPROBAND.cidcomprob " +
                                        "WHERE (TCONCILIACIOND_MANUALV2.cdelete = 0) AND (TCOMPROBANC.cstatus = '0') " +
                                        "AND (TCOMPROBAND.ccount = '" + _Str_CuentaContable + "') AND (TCOMPROBANC.ccompany = '" + _P_Str_Compania + "')";
                    _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSql);
                    if (_Ds_DataSet.Tables[0].Rows.Count > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool _Mtd_FinalizarConciliacion()
        {
            //por ticket 19876 se valida que para finaliza la conciliacion no existan comprobantes de ajustes manuales para el banco y cuenta seleccionado que esten sin actualizar
            if (_Mtd_HayComprobantesManualesPorActualizar(Frm_Padre._Str_Comp,_G_Int_IdConciliacion.ToString(CultureInfo.InvariantCulture)))
            {
                Cursor = Cursors.Default;
                MessageBox.Show("No se puede finalizar la conciliación debido que existen comprobantes de ajustes manuales por actualizar. Debe actualizarlos para poder continuar con el proceso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Validacion (1)
            if (_Mtd_EsValidaConciliacionParaFinalizar(_G_Int_IdConciliacion.ToString(CultureInfo.InvariantCulture), Frm_Padre._Str_Comp))
            {
                //Marcamos los registros que deben ser marcados como conciliados al finalizar (ajustes, comisiones, etc)
                _Mtd_MarcarRegistrosAjustesComoConciliados(_G_Int_IdConciliacion.ToString(CultureInfo.InvariantCulture), Frm_Padre._Str_Comp, _Cmb_BancoDetalle.SelectedValue.ToString(), _Cmb_CuentaDetalle.SelectedValue.ToString());
                //Marco el detalle de la conciliacion
                _Mtd_ActualizarSaldosConciliacion(_G_Int_IdConciliacion.ToString(CultureInfo.InvariantCulture), Frm_Padre._Str_Comp);
                //Marco el detalle de la conciliacion   
                _Mtd_GuardarLibroBancoConciliado(_G_Int_IdConciliacion.ToString(CultureInfo.InvariantCulture), Frm_Padre._Str_Comp, _Cmb_BancoDetalle.SelectedValue.ToString(), _Cmb_CuentaDetalle.SelectedValue.ToString());
                //Marcamos los Estado de Cuenta de la Cuenta Conciliada 
                _Mtd_MarcarEstadosDeCuentaComoConciliado(Frm_Padre._Str_Comp, _Cmb_BancoDetalle.SelectedValue.ToString(), _Cmb_CuentaDetalle.SelectedValue.ToString());
                //Marco Conciliados los registro de la anulacion de chques
                _Cls_RutinasConciliacion._Mtd_MarcarRegistrosAnulacionCheques(Frm_Padre._Str_Comp, _Cmb_BancoDetalle.SelectedValue.ToString(), _Cmb_CuentaDetalle.SelectedValue.ToString(), _Dtp_Hasta.Value);
                //Marco la conciliacion como finalizada
                string _Str_Sql = "UPDATE TCONCILIACION SET cfinalizado=1, cdateupd=getdate() WHERE cidconciliacion='" + _G_Int_IdConciliacion.ToString(CultureInfo.InvariantCulture) + "' and CCOMPANY='" + Frm_Padre._Str_Comp + "' ";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                return true;
            }
            else
            {
                Cursor = Cursors.Default;
                MessageBox.Show("No se puede finalizar la conciliación debido que el saldo no es cero.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private void _Mtd_CrearConciliacion(ref bool _P_Bol_ConciliacionesManuales, int _P_Int_IdConciliacion)
        {
            _Mtd_EliminarConciliacionesNoFinalizadas(true, _P_Int_IdConciliacion);

            var _Str_IdConciliacion = "";

            //Si es una nueva conciliacion
            if (_P_Int_IdConciliacion == 0)
            {
                _G_Str_SentenciaSql = "SELECT ISNULL(MAX(CIDCONCILIACION),0) FROM TCONCILIACION WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "'";
                _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);
                var _Int_IdConciliacion = Convert.ToInt32(_G_Ds_DataSet.Tables[0].Rows[0][0].ToString());
                _Int_IdConciliacion++;
                _G_Str_SentenciaSql = "EXEC PA_T3_CREARCONCILIACION '" + _Int_IdConciliacion + "','" + Frm_Padre._Str_Comp + "','" +
                                      _Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()) + "','" +
                                      _Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()) + "','" + _Cmb_BancoDetalle.SelectedValue.ToString() + "','" +
                                      _Cmb_CuentaDetalle.SelectedValue.ToString() + "','" + _Dtp_Desde.Value.ToShortDateString() + "','" + _Dtp_Hasta.Value.ToShortDateString() + "','" + Frm_Padre._Str_Use + "'";
                _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);
                _Str_IdConciliacion = _Int_IdConciliacion.ToString(CultureInfo.InvariantCulture);
                _G_Int_IdConciliacion = _Int_IdConciliacion; //Carlos Longa.
            }
            else
            {
                _Str_IdConciliacion = _P_Int_IdConciliacion.ToString(CultureInfo.InvariantCulture); //Editando
            }


            //Guardamos el id del estado de cuenta
            if (_G_Str_cdispbanc != "")
            {
                var _Str_ = "UPDATE TCONCILIACION SET cdispbanc='" + _G_Str_cdispbanc + "' WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _Cmb_BancoDetalle.SelectedValue.ToString() + "' AND cnumcuenta='" + _Cmb_CuentaDetalle.SelectedValue.ToString() + "' AND cidconciliacion='" + _Str_IdConciliacion + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_);
            }

            //Cargamos solo las conciliaciones manuales
            var _Int_CantidadConciliacionesManuales = _G_Ds_BancoLibro.Tables[0].AsEnumerable().Count(x => x["cseleccionado"].ToString() == _G_Str_SeleccionadoManual);
            if (_Int_CantidadConciliacionesManuales > 0)
            {

                var _Registros = _G_Ds_BancoLibro.Tables[0].AsEnumerable().Where(x => x["cseleccionado"].ToString() == _G_Str_SeleccionadoManual).OrderBy(x => x["cidedetalleconciliacion"]);
                if (_Registros.Any())
                {
                    //Obtenemos lo datos a insertar
                    var _Str_ccompany = Frm_Padre._Str_Comp;
                    var _Str_cidconciliacion = _Str_IdConciliacion;

                    //Obtenemos el ultimo cidedetalleconciliacion de la concilicion actual para ser insertado con el codigo siguiente
                    var _Int_Ultimo_cidedetalleconciliacion = _Mtd_ObtenerUltimo_cidedetalleconciliacion(_Str_ccompany, _Str_cidconciliacion);
                    var _Int_CiddetalleconciliacionParaInsertar = 0;
                    var _Int_Ultimo_ciddetalleconciliacion_relativo = 0;
        
                    var _Dt_ConciliacionesManuales = _Registros.CopyToDataTable();
                    foreach (DataRow _Dtw_Fila in _Dt_ConciliacionesManuales.Rows)
                    {
                        var _Int_ciddetalleconciliacion_relativo = Convert.ToInt32(_Dtw_Fila["cidedetalleconciliacion"].ToString());

                        //Actualizamos el contador atómico, solo cuando cambie el contador relativo
                        if (_Int_Ultimo_ciddetalleconciliacion_relativo != _Int_ciddetalleconciliacion_relativo)
                        {
                            _Int_CiddetalleconciliacionParaInsertar++;
                            _Int_Ultimo_ciddetalleconciliacion_relativo = _Int_ciddetalleconciliacion_relativo;
                        }

                        //Calculamos el nuevo cidedetalleconciliacion
                        var _Int_ciddetalleconciliacionSiguiente = _Int_Ultimo_cidedetalleconciliacion + _Int_CiddetalleconciliacionParaInsertar;

                        //Obtenemos lo datos a insertar
                        var _Str_ciddispbanc = _Dtw_Fila["cdispbanc"].ToString();
                        var _Str_ciddispband = _Dtw_Fila["cdispband"].ToString();
                        var _Str_cidcomprob = _Dtw_Fila["cidcomprob"].ToString();
                        var _Str_corder = _Dtw_Fila["corder"].ToString();
                        var _Str_coperbancseleccionado = _Dtw_Fila["coperbancseleccionado"].ToString();
                        var _Str_ctipoajuste = _Dtw_Fila["ctipoajuste"].ToString();
                        var _Str_cautomatico = _Dtw_Fila["cconciliadoAutomaticamente"].ToString();

                        //Generamos la sentencia
                        _G_Str_SentenciaSql =
                            "INSERT INTO TCONCILIACIOND_MANUALV2 (ccompany,cidconciliacion,ciddetalleconciliacion,ciddispbanc,ciddispband,cidcomprob,corder,cidcomprob_nuevo,corder_nuevo,ctipoajuste,coperbancseleccionado,ctiporegistro,cautomatico,cdelete,cdateadd,cuseradd) VALUES (" +
                            "'" + _Str_ccompany + "','" + _Str_cidconciliacion + "','" + _Int_ciddetalleconciliacionSiguiente + "','" +
                            _Str_ciddispbanc + "','" + _Str_ciddispband + "','"
                            + _Str_cidcomprob + "','" + _Str_corder + "','0','0'" +
                            ",'" + _Str_ctipoajuste + "'," +  //tipoajuste
                            "'" + _Str_coperbancseleccionado + "'"
                            + ",'" + ((byte) _Cls_RutinasConciliacion._TipoRegistro.Original).ToString(CultureInfo.InvariantCulture) + "'"
                            + ",'" + _Str_cautomatico + "'"
                            + ",'0',GETDATE(),'" + Frm_Padre._Str_Use + "'"
                            + ")";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSql);
                        _P_Bol_ConciliacionesManuales = true;
                    }
                }
            }
        }

        /// <summary>
        /// Obtiene el ultimo cidedetalleconciliacion de la conciliacion actual
        /// </summary>
        private int _Mtd_ObtenerUltimo_cidedetalleconciliacion(string _P_Str_ccompany, string _P_Str_cidconciliacion)
        {
            var _Int_Resultado = 0;
            var _Str_Sql = "SELECT MAX(ciddetalleconciliacion) from TCONCILIACIOND_MANUALV2 WHERE ccompany='" + _P_Str_ccompany + "' AND cidconciliacion = '" + _P_Str_cidconciliacion + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count >= 0)
            {
                if (_Ds.Tables[0].Rows[0][0].ToString() != "")
                   _Int_Resultado = Convert.ToInt32(_Ds.Tables[0].Rows[0][0]);
            }
            return _Int_Resultado;
        }

        private bool _Mtd_GuardarConciliacion()
        {
            Cursor = Cursors.WaitCursor;
            if (_Mtd_Validar())
            {

                string _Str_Sql = "SELECT cidconciliacion FROM TCONCILIACION WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cbanco='" + _Cmb_BancoDetalle.SelectedValue.ToString() + "' and cnumcuenta='" +
                                  _Cmb_CuentaDetalle.SelectedValue.ToString() + "' and cfinalizado=0";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("La conciliación ha sido borrada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                string _Str_IdConciliacion = _Ds.Tables[0].Rows[0][0].ToString();

                //Elimino las conciliaciones no finalizadas! para tomar cualquier cambio que haya hecho el usuario
                _Mtd_EliminarConciliacionesNoFinalizadas(false, _G_Int_IdConciliacion);

                //Guardamos el Detalle de la Conciliacion
                _Mtd_GuardarDetalleDeConciliacion(_Str_IdConciliacion);

                //Guardo el Detalle del Banco y Libro (Solicitud 3885)
                _Mtd_GuardarLibroBanco(_Str_IdConciliacion);

                //Actualizamos los Saldos
                _Mtd_ActualizarSaldosConciliacion(_G_Int_IdConciliacion.ToString(CultureInfo.InvariantCulture), Frm_Padre._Str_Comp);

                _G_Bol_ModoGuardar = true;
                _G_Bol_ModoReporte = true;
                Cursor = Cursors.Default;
                return true;
            }
            else
            {
                string _Str_Mensaje = "";
                if (_Er_Error.GetError(_Dtp_Hasta) != "")
                {
                    _Str_Mensaje += "\n -" + _Er_Error.GetError(_Dtp_Hasta);
                }
                if (_Er_Error.GetError(_Lbl_BancoNoConciliado) != "")
                {
                    _Str_Mensaje += "\n -" + _Er_Error.GetError(_Lbl_BancoNoConciliado);
                }
                if (_Er_Error.GetError(_Lbl_LibroNoConciliado) != "")
                {
                    _Str_Mensaje += "\n -" + _Er_Error.GetError(_Lbl_LibroNoConciliado);
                }
                if (_Er_Error.GetError(_Txt_SaldoSegunLibro) != "")
                {
                    _Str_Mensaje += "\n -" + _Er_Error.GetError(_Txt_SaldoSegunLibro);
                }
                Cursor = Cursors.Default;
                MessageBox.Show("No se puede culminar la conciliación debido a: " + _Str_Mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private System.Collections.ArrayList _Mtd_LlenarEstadoLibro()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            //Genero la Consulta
            DataSet _Ds;
            string _Str_Sql = "SELECT cestadoid, cdescripcion  FROM TESTADOSCONC WHERE ctlibro = 1 order by cdescripcion ";
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            //Si hay datos
            if (_Ds.Tables[0].Rows.Count > 0)
                foreach (DataRow _DRow in _Ds.Tables[0].Rows)
                {
                    _myArrayList.Add(new T3.Clases._Cls_ArrayList(_DRow[1].ToString(), _DRow[0].ToString()));
                }
            return _myArrayList;
        }

        private System.Collections.ArrayList _Mtd_LlenarEstadoBanco()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            //Genero la Consulta
            DataSet _Ds;
            string _Str_Sql = "SELECT cestadoid, cdescripcion  FROM TESTADOSCONC WHERE ctbanco = 1 order by cdescripcion";
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

            foreach (DataGridViewRow _Dtw_Fila in _Dtg_LibrosNoConciliados.Rows)
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
            _G_Str_SentenciaSql = "UPDATE TDISPBANC SET CCONCILIADO='1',CDATEUPD=GETDATE(),CUSERUPD='" + Frm_Padre._Str_Use + "' WHERE CCOMPANY='" + _P_Str_Compania + "' AND cbanco='" + _P_Str_IDBanco +
                                  "' AND cnumcuenta='" + _P_Str_NumCuenta + "' AND CCONCILIADO=0 and cdelete=0";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSql);
        }
        private void _Mtd_ObtenerEstadoDeCuentaAUsar()
        {
            var _Str_Compania = Frm_Padre._Str_Comp;
            var _Str_IdBanco = _Cmb_BancoDetalle.SelectedValue.ToString();
            var _Str_NumCuenta = _Cmb_CuentaDetalle.SelectedValue.ToString();
            var _Str_SentenciaSql = "SELECT cdispbanc FROM TDISPBANC WHERE CCOMPANY='" + _Str_Compania + "' AND cbanco='" + _Str_IdBanco + "' AND cnumcuenta='" + _Str_NumCuenta + "' AND CCONCILIADO=0 and cdelete=0 and cregistroinicial='0' ";
            var _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSql);
            if (_Ds_DataSet.Tables[0].Rows.Count > 0)
            {
                _G_Str_cdispbanc = _Ds_DataSet.Tables[0].Rows[0][0].ToString();
            }
        }

        private void _Mtd_GuardarLibroBancoConciliado(string _P_Str_IDConciliacion, string _P_Str_Compania, string _P_Str_IDBanco, string _P_Str_NumCuenta)
        {
            _G_Str_SentenciaSql = "SELECT ciddispband,ciddispbanc,cidcomprob,corder,ctipodetalle FROM TCONCILIACIOND WHERE CCOMPANY='" + _P_Str_Compania + "' AND cidconciliacion='" + _P_Str_IDConciliacion + "' AND CESTADO='0'";
                //Estado 0 es Conciliado en la BD
            _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);
            foreach (DataRow _Dtw_Item in _G_Ds_DataSet.Tables[0].Rows)
            {
                string _Str_IdComprob = _Dtw_Item["cidcomprob"].ToString();
                string _Str_Order = _Dtw_Item["corder"].ToString();
                string _Str_IdDispband = _Dtw_Item["ciddispband"].ToString();
                string _Str_IdDispbanc = _Dtw_Item["ciddispbanc"].ToString();
                string _Str_ctipodetalle = _Dtw_Item["ctipodetalle"].ToString();

                if (_Str_ctipodetalle == ((byte) _Cls_RutinasConciliacion._TipoDetalle.Banco).ToString(CultureInfo.InvariantCulture)) //BANCO
                {
                    _G_Str_SentenciaSql = "UPDATE TDISPBAND SET CCONCILIADO='1' WHERE CCOMPANY='" + _P_Str_Compania + "' AND cdispband='" + _Str_IdDispband + "' AND cdispbanc='" + _Str_IdDispbanc + "' AND cbanco='" + _P_Str_IDBanco + "' AND cnumcuenta='" + _P_Str_NumCuenta + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSql);
                    _G_Str_SentenciaSql = "UPDATE TDISPBANC SET CCONCILIADO='1',CDATEUPD=GETDATE(),CUSERUPD='" + Frm_Padre._Str_Use + "' WHERE CCOMPANY='" + _P_Str_Compania + "' AND cdispbanc='" + _Str_IdDispbanc + "' AND cbanco='" + _P_Str_IDBanco + "' AND cnumcuenta='" + _P_Str_NumCuenta + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSql);
                }
                else //LIBRO
                {
                    _G_Str_SentenciaSql = "UPDATE TCOMPROBAND SET CCONCILIADO='1' WHERE CCOMPANY='" + _P_Str_Compania + "' AND CIDCOMPROB='" + _Str_IdComprob + "' AND CORDER='" + _Str_Order + "'";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSql);
                }
            }
        }

        private void _Mtd_MarcarRegistrosAjustesComoConciliados(string _P_Str_IDConciliacion, string _P_Str_Compania, string _P_Str_IDBanco, string _P_Str_NumCuenta)
        {
            var _G_Str_SentenciaSQL = "";

            //Cargamos los registros a marcar como conciliados
            //Reversos y Originales
            _G_Str_SentenciaSQL = "SELECT * " +
                                  "FROM VST_CONCILIACION_BANCOLIBRONOCONCILIADO " +
                                  "WHERE" +
                                  "(CCOMPANY='" + _P_Str_Compania + "') " +
                                  "AND (CBANCO='" + _P_Str_IDBanco + "') " +
                                  "AND (CNUMCUENTA='" + _P_Str_NumCuenta + "') " +
                                  "AND ([Tip.Reg.]='LIBRO') " + 
                                  "AND (ctiporegistro IN (" +
                                   "'" + ((byte)_Cls_RutinasConciliacion._TipoRegistro.Original) + "'" +
                                   ",'" + ((byte)_Cls_RutinasConciliacion._TipoRegistro.Reverso) + "'" +
                                   ",'" + ((byte)_Cls_RutinasConciliacion._TipoRegistro.Diferencia) + "'" + 
                                   "))";
            
            //Instancio el DataSet Internos
            var _Ds_Registros = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);

            //Cargamos los registros que deben ser marcados como conciliados
            var _Ds_Registros_Originales = _G_Ds_BancoLibro
                                            .Tables[0]
                                            .AsEnumerable()
                                            .Where(x =>
                                                   x["Tip.Reg."].ToString().ToUpper() == "LIBRO" &&
                                                   x["cconciliado"].ToString() == "0" &&
                                                   (
                                                       x["ctiporegistro"].ToString() == ((byte)_Cls_RutinasConciliacion._TipoRegistro.Original).ToString(CultureInfo.InvariantCulture)
                                                       ||
                                                       x["ctiporegistro"].ToString() == ((byte)_Cls_RutinasConciliacion._TipoRegistro.Reverso).ToString(CultureInfo.InvariantCulture)
                                                       ||
                                                       x["ctiporegistro"].ToString() == ((byte)_Cls_RutinasConciliacion._TipoRegistro.Diferencia).ToString(CultureInfo.InvariantCulture)
                                                   )
                                                   );


            var _T = _Ds_Registros.Tables[0].AsEnumerable();

            var _Dt_RegistrosCompletos = _T.Union(_Ds_Registros_Originales);

            //Marcamos cada registro como conciliado
            foreach (DataRow _Dtw_Item in _Dt_RegistrosCompletos)
            {
                string _Str_IdComprob = _Dtw_Item["cidcomprob"].ToString();
                string _Str_Order = _Dtw_Item["corder"].ToString();
                string _Str_ctiporegistro = _Dtw_Item["Tip.Reg."].ToString();

                _G_Str_SentenciaSql = "UPDATE TCOMPROBAND SET CCONCILIADO='1' WHERE CCOMPANY='" + _P_Str_Compania + "' AND CIDCOMPROB='" + _Str_IdComprob + "' AND CORDER='" + _Str_Order + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSql);
            }

        }


        private void _Mtd_GuardarDetalleDeConciliacion(string _P_Str_IDConciliacion)
        {
            var _Registros = _G_Ds_BancoLibro.Tables[0].AsEnumerable();
            if (_Registros.Any())
            {
                var _Dt_ = _Registros.CopyToDataTable();
                foreach (DataRow _Dtw_Fila in _Dt_.Rows)
                {
                    var _Str_Estado = "";
                    if (_Dtw_Fila["cconciliado"].ToString() == "1") _Str_Estado = "0";
                    else _Str_Estado = _Dtw_Fila["estado"].ToString();

                    var _Str_TipoDetalle = "";
                    _Str_TipoDetalle = _Dtw_Fila["Tip.Reg."].ToString().ToUpper() == "BANCO"
                                           ? ((byte) _Cls_RutinasConciliacion._TipoDetalle.Banco).ToString(CultureInfo.InvariantCulture)
                                           : ((byte) _Cls_RutinasConciliacion._TipoDetalle.Libro).ToString(CultureInfo.InvariantCulture);

                    //Guardamos
                    _G_Str_SentenciaSql = "INSERT INTO TCONCILIACIOND(CIDCONCILIACION,CCOMPANY,CIDDISPBAND,CIDDISPBANC,CIDCOMPROB,CORDER,CESTADO,CDATEADD,CUSERADD,CDELETE,CTIPODETALLE)";
                    _G_Str_SentenciaSql += " VALUES ('" + _P_Str_IDConciliacion + "','" + Frm_Padre._Str_Comp + "','" +
                                           _Dtw_Fila["cdispband"].ToString() + "','" + _Dtw_Fila["cdispbanc"].ToString() + "','" +
                                           _Dtw_Fila["cidcomprob"].ToString() + "','" + _Dtw_Fila["corder"].ToString() + "','" +
                                           _Str_Estado + "',GETDATE(),'" + Frm_Padre._Str_Use + "',0,'" + _Str_TipoDetalle + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSql);
                }
            }
        }

        private void _Mtd_GuardarLibroBanco(string _P_Str_IDConciliacion)
        {
            var _Registros_Banco = _G_Ds_BancoLibro.Tables[0].AsEnumerable().Where(x => x["Tip.Reg."].ToString().ToUpper() == "BANCO");
            if (_Registros_Banco.Any())
            {
                var _Dt_Banco = _Registros_Banco.CopyToDataTable();
                foreach (DataRow _Dtw_Fila in _Dt_Banco.Rows)
                {
                    _G_Str_SentenciaSql = "INSERT INTO TCONCILIACIONDBANCO(CIDCONCILIACION,CCOMPANY,cdispband,cdispbanc)";
                    _G_Str_SentenciaSql += " VALUES ('" + _P_Str_IDConciliacion + "','" + Frm_Padre._Str_Comp + "','" + _Dtw_Fila["cdispband"].ToString() + "','" + _Dtw_Fila["cdispbanc"].ToString() + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSql);
                }
            }

            var _Registros_Libro = _G_Ds_BancoLibro.Tables[0].AsEnumerable().Where(x => x["Tip.Reg."].ToString().ToUpper() == "LIBRO");
            if (_Registros_Libro.Any())
            {
                var _Dt_Libro = _Registros_Libro.CopyToDataTable();
                foreach (DataRow _Dtw_Fila in _Dt_Libro.Rows)
                {
                    _G_Str_SentenciaSql = "INSERT INTO TCONCILIACIONDLIBRO(CIDCONCILIACION,CCOMPANY,cidcomprob,corder)";
                    _G_Str_SentenciaSql += " VALUES ('" + _P_Str_IDConciliacion + "','" + Frm_Padre._Str_Comp + "','" + _Dtw_Fila["cidcomprob"].ToString() + "','" + _Dtw_Fila["corder"].ToString() + "')";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSql);
                }
            }
            
            //Guardamos los registros del mayor analitico usado en la conciliacion actual
            _Mtd_GuardarDetalleMayorAnalitico(_P_Str_IDConciliacion);

        }

        private void _Mtd_GuardarDetalleMayorAnalitico(string _P_Str_IDConciliacion)
        {
            string _Str_CuentaContable = "";
            string _Str_AnoContable = _Dtp_Desde.Value.Year.ToString();
            string _Str_MesContable = _Dtp_Desde.Value.Month.ToString();
            string _Str_DiaContable = _Dtp_Desde.Value.Day.ToString();
            string _Str_AnoHastaContable = _Dtp_Hasta.Value.Year.ToString();
            string _Str_MesHastaContable = _Dtp_Hasta.Value.Month.ToString();
            string _Str_DiaHastaContable = _Dtp_Hasta.Value.Day.ToString();
            _G_Str_SentenciaSql = "SELECT ccount FROM TCUENTBANC WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND cnumcuenta='" + _Cmb_CuentaDetalle.SelectedValue.ToString() + "' AND CBANCO='" +
                                  _Cmb_BancoDetalle.SelectedValue.ToString() + "' and cdelete='0'";
            _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);
            foreach (DataRow _Dtw_Fila in _G_Ds_DataSet.Tables[0].Rows)
            {
                _Str_CuentaContable = _Dtw_Fila["ccount"].ToString().Trim();
            }
            _G_Str_SentenciaSql = "EXEC SP_T3_CONSULTAMAYORANALITICO_CONCILIACION '" + Frm_Padre._Str_Comp + "','" + _Str_CuentaContable + "','" + _Str_CuentaContable + "','" + _Str_MesContable + "','" +
                                  _Str_MesHastaContable + "','" + _Str_AnoContable + "','" + _Str_AnoHastaContable + "','" + _Str_DiaHastaContable + "'";
            _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);
            foreach (DataRow _Dtw_Fila in _G_Ds_DataSet.Tables[0].Rows)
            {
                if ((_Dtw_Fila["cdia"].ToString().Trim() != ""))
                {
                    var _Int_Dia = Convert.ToInt32(_Dtw_Fila["cdia"].ToString().Trim());
                    if ((_Int_Dia >= Convert.ToInt32(_Str_DiaContable)) & (_Int_Dia <= Convert.ToInt32(_Str_DiaHastaContable)))
                    {
                        if ((_Dtw_Fila["cidcomprob"].ToString().Trim() != "") & (_Dtw_Fila["corder"].ToString().Trim() != ""))
                        {
                            var _Str_cidcomprob = _Dtw_Fila["cidcomprob"].ToString().Trim();
                            var _Str_corder = _Dtw_Fila["corder"].ToString().Trim();
                            _G_Str_SentenciaSql = "INSERT INTO TCONCILIACIONDMAYORANALITICO(CIDCONCILIACION,CCOMPANY,cidcomprob,corder)";
                            _G_Str_SentenciaSql += " VALUES ('" + _P_Str_IDConciliacion + "','" + Frm_Padre._Str_Comp + "','" + _Str_cidcomprob + "','" + _Str_corder + "')";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSql);
                        }
                    }
                }
            }
        }

        private void _Mtd_CalcularSaldosConciliacion(string _P_Str_IDConciliacion, string _P_Str_Compania
                                                     , out decimal _P_Dec_SaldoInicialSegunLibro
                                                     , out decimal _P_Dec_SaldoSegunLibro
                                                     , out decimal _P_Dec_TotalChequesPendientesNoCobradosEnBanco
                                                     , out decimal _P_Dec_TotalDepositosNoRegistradosEnBanco
                                                     , out decimal _P_Dec_TotalDepositosNoRegistradosEnLibro
                                                     , out decimal _P_Dec_TotalNDNoRegistradoEnLibro
                                                     , out decimal _P_Dec_TotalNDNoRegistradoEnBanco
                                                     , out decimal _P_Dec_TotalNCNoRegistradoEnBanco
                                                     , out decimal _P_Dec_TotalNCNoRegistradoEnLibro
                                                     , out decimal _P_Dec_SaldoSegunBanco
                                                     , out decimal _P_Dec_TotalConciliacion
            )
        {
            decimal _Dec_SaldoInicialSegunLibro = 0;
            decimal _Dec_SaldoSegunLibro = 0;
            decimal _Dec_TotalChequesPendientesNoCobradosEnBanco = 0;
            decimal _Dec_TotalDepositosNoRegistradosEnBanco = 0;
            decimal _Dec_TotalDepositosNoRegistradosEnLibro = 0;
            decimal _Dec_TotalNDNoRegistradoEnLibro = 0;
            decimal _Dec_TotalNDNoRegistradoEnBanco = 0;
            decimal _Dec_TotalNCNoRegistradoEnBanco = 0;
            decimal _Dec_TotalNCNoRegistradoEnLibro = 0;
            decimal _Dec_SaldoSegunBanco = 0;
            decimal _Dec_TotalConciliacion = 0;

            //Saldos del Libro
            _Dec_SaldoInicialSegunLibro = Convert.ToDecimal(_Txt_SaldoInicialSegunLibro.Text);
            _Dec_SaldoSegunLibro = Convert.ToDecimal(_Txt_SaldoSegunLibro.Text);

            //Saldo segun Banco
            _Dec_SaldoSegunBanco = Convert.ToDecimal(_Txt_SaldoFinalBanco.Text);

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
                                _Dec_TotalDepositosNoRegistradosEnLibro += (Convert.ToDecimal(_Dtw_Fila["Monto"].ToString()));
                                break;
                            case "2":
                                _Dec_TotalNDNoRegistradoEnLibro += (Convert.ToDecimal(_Dtw_Fila["Monto"].ToString()));
                                break;
                            case "3":
                                _Dec_TotalNCNoRegistradoEnLibro += (Convert.ToDecimal(_Dtw_Fila["Monto"].ToString()));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            //Registros de Libro
            var _Registros_Libro = _G_Ds_BancoLibro.Tables[0].AsEnumerable().Where(x => x["Tip.Reg."].ToString().ToUpper() == "LIBRO");
            if (_Registros_Libro.Any())
            {
                var _Dt_Libro = _Registros_Libro.CopyToDataTable();
                foreach (DataRow _Dtw_Fila in _Dt_Libro.Rows)
                {
                    //Si no esta conciliado acumulo
                    if (_Dtw_Fila["cconciliado"].ToString() != "1")
                    {
                        switch (_Dtw_Fila["estado"].ToString())
                        {
                            case "4":
                                _Dec_TotalChequesPendientesNoCobradosEnBanco += (Convert.ToDecimal(_Dtw_Fila["Monto"].ToString()));
                                break;
                            case "5":
                                _Dec_TotalDepositosNoRegistradosEnBanco += (Convert.ToDecimal(_Dtw_Fila["Monto"].ToString()));
                                break;
                            case "6":
                                _Dec_TotalNCNoRegistradoEnBanco += (Convert.ToDecimal(_Dtw_Fila["Monto"].ToString()));
                                break;
                            case "7":
                                _Dec_TotalNDNoRegistradoEnBanco += (Convert.ToDecimal(_Dtw_Fila["Monto"].ToString()));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            //coloco los signo segun tablita
            //Obtengo el signo del estado 
            decimal _Dec_Signo = 0;

            _Dec_Signo = _Mtd_ObtenerSignoSegunEstado("1");
            _Dec_TotalDepositosNoRegistradosEnLibro = Math.Abs(_Dec_TotalDepositosNoRegistradosEnLibro)*_Dec_Signo;

            _Dec_Signo = _Mtd_ObtenerSignoSegunEstado("2");
            _Dec_TotalNDNoRegistradoEnLibro = Math.Abs(_Dec_TotalNDNoRegistradoEnLibro)*_Dec_Signo;

            _Dec_Signo = _Mtd_ObtenerSignoSegunEstado("3");
            _Dec_TotalNCNoRegistradoEnLibro = Math.Abs(_Dec_TotalNCNoRegistradoEnLibro)*_Dec_Signo;

            _Dec_Signo = _Mtd_ObtenerSignoSegunEstado("4");
            _Dec_TotalChequesPendientesNoCobradosEnBanco = Math.Abs(_Dec_TotalChequesPendientesNoCobradosEnBanco)*_Dec_Signo;

            _Dec_Signo = _Mtd_ObtenerSignoSegunEstado("5");
            _Dec_TotalDepositosNoRegistradosEnBanco = Math.Abs(_Dec_TotalDepositosNoRegistradosEnBanco)*_Dec_Signo;

            _Dec_Signo = _Mtd_ObtenerSignoSegunEstado("6");
            _Dec_TotalNCNoRegistradoEnBanco = Math.Abs(_Dec_TotalNCNoRegistradoEnBanco)*_Dec_Signo;

            _Dec_Signo = _Mtd_ObtenerSignoSegunEstado("7");
            _Dec_TotalNDNoRegistradoEnBanco = Math.Abs(_Dec_TotalNDNoRegistradoEnBanco)*_Dec_Signo;

            //devuelvo
            _P_Dec_TotalDepositosNoRegistradosEnLibro = _Dec_TotalDepositosNoRegistradosEnLibro;
            _P_Dec_TotalNDNoRegistradoEnLibro = _Dec_TotalNDNoRegistradoEnLibro;
            _P_Dec_TotalNCNoRegistradoEnLibro = _Dec_TotalNCNoRegistradoEnLibro;

            _P_Dec_TotalChequesPendientesNoCobradosEnBanco = _Dec_TotalChequesPendientesNoCobradosEnBanco;
            _P_Dec_TotalDepositosNoRegistradosEnBanco = _Dec_TotalDepositosNoRegistradosEnBanco;

            _P_Dec_TotalNCNoRegistradoEnBanco = _Dec_TotalNCNoRegistradoEnBanco;
            _P_Dec_TotalNDNoRegistradoEnBanco = _Dec_TotalNDNoRegistradoEnBanco;

            _P_Dec_SaldoInicialSegunLibro = _Dec_SaldoInicialSegunLibro;
            _P_Dec_SaldoSegunLibro = _Dec_SaldoSegunLibro;
            _P_Dec_SaldoSegunBanco = _Dec_SaldoSegunBanco;
            _P_Dec_TotalConciliacion = _Dec_TotalConciliacion;
        }

        private void _Mtd_ActualizarSaldosConciliacion(string _P_Str_IDConciliacion, string _P_Str_Compania)
        {
            decimal _Dec_SaldoInicialSegunLibro = 0;
            decimal _Dec_SaldoSegunLibro = 0;
            decimal _Dec_TotalChequesPendientesNoCobradosEnBanco = 0;
            decimal _Dec_TotalDepositosNoRegistradosEnBanco = 0;
            decimal _Dec_TotalDepositosNoRegistradosEnLibro = 0;
            decimal _Dec_TotalNDNoRegistradoEnLibro = 0;
            decimal _Dec_TotalNDNoRegistradoEnBanco = 0;
            decimal _Dec_TotalNCNoRegistradoEnBanco = 0;
            decimal _Dec_TotalNCNoRegistradoEnLibro = 0;
            decimal _Dec_SaldoSegunBanco = 0;
            decimal _Dec_TotalConciliacion = 0;

            //Obtenemos los saldos
            _Mtd_CalcularSaldosConciliacion(_P_Str_IDConciliacion, _P_Str_Compania
                                            , out _Dec_SaldoInicialSegunLibro
                                            , out _Dec_SaldoSegunLibro
                                            , out _Dec_TotalChequesPendientesNoCobradosEnBanco
                                            , out _Dec_TotalDepositosNoRegistradosEnBanco
                                            , out _Dec_TotalDepositosNoRegistradosEnLibro
                                            , out _Dec_TotalNDNoRegistradoEnLibro
                                            , out _Dec_TotalNDNoRegistradoEnBanco
                                            , out _Dec_TotalNCNoRegistradoEnBanco
                                            , out _Dec_TotalNCNoRegistradoEnLibro
                                            , out _Dec_SaldoSegunBanco
                                            , out _Dec_TotalConciliacion);


            //Calculo el total
            _Dec_TotalConciliacion = (_Dec_SaldoSegunBanco
                                      + _Dec_TotalChequesPendientesNoCobradosEnBanco
                                      + _Dec_TotalDepositosNoRegistradosEnBanco
                                      + _Dec_TotalDepositosNoRegistradosEnLibro
                                      + _Dec_TotalNDNoRegistradoEnLibro
                                      + _Dec_TotalNDNoRegistradoEnBanco
                                      + _Dec_TotalNCNoRegistradoEnBanco
                                      + _Dec_TotalNCNoRegistradoEnLibro
                                     );
            //Genero la consulta de actualizacion
            _G_Str_SentenciaSql = "UPDATE TCONCILIACION SET ";
            _G_Str_SentenciaSql += "csaldoinicialsegunlibro='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDecimal(_Dec_SaldoInicialSegunLibro)) + "'";
            _G_Str_SentenciaSql += ",csaldosegunlibro='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDecimal(_Dec_SaldoSegunLibro)) + "'";
            _G_Str_SentenciaSql += ",ctotalcet='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_TotalChequesPendientesNoCobradosEnBanco) + "'";
            _G_Str_SentenciaSql += ",ctotaldnreb='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_TotalDepositosNoRegistradosEnBanco) + "'";
            _G_Str_SentenciaSql += ",ctotaldnrel='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_TotalDepositosNoRegistradosEnLibro) + "'";
            _G_Str_SentenciaSql += ",ctotalndnrel='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_TotalNDNoRegistradoEnLibro) + "'";
            _G_Str_SentenciaSql += ",ctotalndnreb='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_TotalNDNoRegistradoEnBanco) + "'";
            _G_Str_SentenciaSql += ",ctotalncnreb='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_TotalNCNoRegistradoEnBanco) + "'";
            _G_Str_SentenciaSql += ",ctotalncnrel='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_TotalNCNoRegistradoEnLibro) + "'";
            _G_Str_SentenciaSql += ",ctotalconciliacion='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_TotalConciliacion) + "'";
            _G_Str_SentenciaSql += ",csaldosegunbanco='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_SaldoSegunBanco) + "'";
            _G_Str_SentenciaSql += " WHERE CCOMPANY='" + _P_Str_Compania + "' AND cidconciliacion='" + _P_Str_IDConciliacion + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_G_Str_SentenciaSql);

        }

        /// <summary>
        /// Devuelve si es posible guardar o no la conciliacion
        /// </summary>
        /// <param name="_P_Str_IDConciliacion"></param>
        /// <param name="_P_Str_Compania"></param>
        /// <returns></returns>
        private bool _Mtd_EsValidaConciliacionParaFinalizar(string _P_Str_IDConciliacion, string _P_Str_Compania)
        {
            decimal _Dec_SaldoInicialSegunLibro = 0;
            decimal _Dec_SaldoSegunLibro = 0;
            decimal _Dec_TotalChequesPendientesNoCobradosEnBanco = 0;
            decimal _Dec_TotalDepositosNoRegistradosEnBanco = 0;
            decimal _Dec_TotalDepositosNoRegistradosEnLibro = 0;
            decimal _Dec_TotalNDNoRegistradoEnLibro = 0;
            decimal _Dec_TotalNDNoRegistradoEnBanco = 0;
            decimal _Dec_TotalNCNoRegistradoEnBanco = 0;
            decimal _Dec_TotalNCNoRegistradoEnLibro = 0;
            decimal _Dec_SaldoSegunBanco = 0;
            decimal _Dec_TotalConciliacion = 0;

            //Obtenemos los saldos
            _Mtd_CalcularSaldosConciliacion(_P_Str_IDConciliacion, _P_Str_Compania
                                            , out _Dec_SaldoInicialSegunLibro
                                            , out _Dec_SaldoSegunLibro
                                            , out _Dec_TotalChequesPendientesNoCobradosEnBanco
                                            , out _Dec_TotalDepositosNoRegistradosEnBanco
                                            , out _Dec_TotalDepositosNoRegistradosEnLibro
                                            , out _Dec_TotalNDNoRegistradoEnLibro
                                            , out _Dec_TotalNDNoRegistradoEnBanco
                                            , out _Dec_TotalNCNoRegistradoEnBanco
                                            , out _Dec_TotalNCNoRegistradoEnLibro
                                            , out _Dec_SaldoSegunBanco
                                            , out _Dec_TotalConciliacion);

            //Calculo el total
            _Dec_TotalConciliacion = (_Dec_SaldoSegunBanco
                                      + _Dec_TotalChequesPendientesNoCobradosEnBanco
                                      + _Dec_TotalDepositosNoRegistradosEnBanco
                                      + _Dec_TotalDepositosNoRegistradosEnLibro
                                      + _Dec_TotalNDNoRegistradoEnLibro
                                      + _Dec_TotalNDNoRegistradoEnBanco
                                      + _Dec_TotalNCNoRegistradoEnBanco
                                      + _Dec_TotalNCNoRegistradoEnLibro
                                     );

            //Devuelvo
            var bResultado = (_Dec_TotalConciliacion - _Dec_SaldoSegunLibro) == 0;
            return bResultado;

        }


        private void _Mtd_MostrarReporteConciliacion(string _P_Str_IDConciliacion, string _P_Str_Compania)
        {
            _Rpt_ReporteConciliacion.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_ReporteConciliacion.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_ConciliacionBancaria";
            ReportParameter[] parm = new ReportParameter[3];
            parm[0] = new ReportParameter("ccompany", _P_Str_Compania);
            parm[1] = new ReportParameter("cidconciliacion", _P_Str_IDConciliacion);
            string _Str_Cadena = "Select cname from TCOMPANY where ccompany='" + _P_Str_Compania + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            parm[2] = new ReportParameter("CNOMEMP", _Ds.Tables[0].Rows[0][0].ToString().TrimEnd());
            _Rpt_ReporteConciliacion.ServerReport.SetParameters(parm);
            this._Rpt_ReporteConciliacion.ServerReport.Refresh();
            this._Rpt_ReporteConciliacion.RefreshReport();
        }

        private void _Mtd_MostrarReporteBanco(string _P_Str_IDConciliacion, string _P_Str_Compania)
        {
            _Rpt_ReporteConciliacion.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_ReporteConciliacion.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_ConciliacionBancariaDBanco";
            ReportParameter[] parm = new ReportParameter[3];
            parm[0] = new ReportParameter("ccompany", _P_Str_Compania);
            parm[1] = new ReportParameter("cidconciliacion", _P_Str_IDConciliacion);
            string _Str_Cadena = "Select cname from TCOMPANY where ccompany='" + _P_Str_Compania + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            parm[2] = new ReportParameter("CNOMEMP", _Ds.Tables[0].Rows[0][0].ToString().TrimEnd());
            _Rpt_ReporteConciliacion.ServerReport.SetParameters(parm);
            this._Rpt_ReporteConciliacion.ServerReport.Refresh();
            this._Rpt_ReporteConciliacion.RefreshReport();
        }

        private void _Mtd_MostrarReporteLibro(string _P_Str_IDConciliacion, string _P_Str_Compania)
        {
            decimal _Dc_SaldoLibroDesde = 0;
            decimal _Dc_SaldoLibroHasta = 0;

            _G_Str_SentenciaSql = "SELECT cidconciliacion,CONVERT(VARCHAR,TCONCILIACION.cfechadesde,103) AS [FechaDesde], CONVERT(VARCHAR,TCONCILIACION.cfechahasta,103) AS [FechaHasta], cbanco, cnumcuenta FROM TCONCILIACION WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' and cidconciliacion = '" + _P_Str_IDConciliacion + "'";
            var _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);

            var _Str_cbanco = _Ds_DataSet.Tables[0].Rows[0]["cbanco"].ToString();
            var _Str_cnumcuenta = _Ds_DataSet.Tables[0].Rows[0]["cnumcuenta"].ToString();
            var _Str_FechaDesde = _Ds_DataSet.Tables[0].Rows[0]["FechaDesde"].ToString();
            var _Str_FechaHasta = _Ds_DataSet.Tables[0].Rows[0]["FechaHasta"].ToString();

            _Rpt_ReporteConciliacion.ServerReport.ReportServerUrl = new Uri(CLASES._Cls_Conexion._Str_ReportServerUrl);
            _Rpt_ReporteConciliacion.ServerReport.ReportPath = CLASES._Cls_Conexion._Str_ReportPath + "Rpt_ConciliacionBancariaDLibro";
            ReportParameter[] parm = new ReportParameter[9];
            parm[0] = new ReportParameter("ccompany", _P_Str_Compania);
            parm[1] = new ReportParameter("cidconciliacion", _P_Str_IDConciliacion);
            string _Str_Cadena = "Select cname from TCOMPANY where ccompany='" + _P_Str_Compania + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            parm[2] = new ReportParameter("CNOMEMP", _Ds.Tables[0].Rows[0][0].ToString().TrimEnd());
            parm[3] = new ReportParameter("cfechadesde", _Str_FechaDesde);
            parm[4] = new ReportParameter("cfechahasta", _Str_FechaHasta);
            parm[5] = new ReportParameter("csaldolibrodesde", _Dc_SaldoLibroDesde.ToString("#,##0.00"));
            parm[6] = new ReportParameter("ccsaldolibrohasta", _Dc_SaldoLibroHasta.ToString("#,##0.00"));
            parm[7] = new ReportParameter("cbanco", _Str_cbanco);
            parm[8] = new ReportParameter("cnumcuenta", _Str_cnumcuenta);
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
                _G_Str_SentenciaSql = "SELECT CIMPRESO FROM TCONCILIACION WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND cidconciliacion='" + _Dtg_Consulta.Rows[e.RowIndex].Cells["Id Conciliación"].Value.ToString() + "' AND CIMPRESO='1'";
                _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);
                _G_Bol_Impreso = _G_Ds_DataSet.Tables[0].Rows.Count == 1;
                _Tab_Contenedor.SelectedIndex = 2;

                //Obtenemos el id de la conciliacion
                _G_Int_IdConciliacion = Convert.ToInt32(_Dtg_Consulta.Rows[e.RowIndex].Cells["Id Conciliación"].Value);

                //Obtenemos los valores de otros campos
                var _Str_SentenciaSql = "SELECT cdispbanc,cbanco,cnumcuenta,cfechadesde,cfechahasta FROM TCONCILIACION WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND cidconciliacion='" + _G_Int_IdConciliacion.ToString(CultureInfo.InvariantCulture) + "' ";
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
                _Mtd_MostrarReporteConciliacion(_G_Int_IdConciliacion.ToString(CultureInfo.InvariantCulture), Frm_Padre._Str_Comp);
                
                //Cambio el nombre del boton
                _Btn_AnteriorReporte.Visible = false;
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
                        var strValor = this._Dtg_BancoNoConciliados.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        //En función al valor coloreo
                        if (strValor != "nulo")
                        {
                            this._Dtg_BancoNoConciliados.Rows[e.RowIndex].DefaultCellStyle.BackColor = _G_ColorInicialGrid;
                        }
                        else
                        {
                            this._Dtg_BancoNoConciliados.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        //Guardo la seleccion en el datasource
                        string strId = this._Dtg_BancoNoConciliados.Rows[e.RowIndex].Cells["cdispband"].Value.ToString();
                        string strcdispbanc = this._Dtg_BancoNoConciliados.Rows[e.RowIndex].Cells["cdispbanc"].Value.ToString();
                        var oFilas = _G_Ds_BancoLibro.Tables[0].Select("cdispband='" + strId + "' and cdispbanc='" + strcdispbanc + "'");
                        foreach (var oFila in oFilas)
                        {
                            if (strValor != "nulo")
                            {
                                if (oFila["estado"] != strValor)
                                {
                                    oFila["estado"] = strValor;
                                }
                            }
                            else
                            {
                                oFila["estado"] = 0;
                            }
                        }
                    }
                }
            }
        }

        private void _Dtg_LibrosNoConciliados_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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
                        var strValor = this._Dtg_LibrosNoConciliados.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        //En función al valor coloreo
                        if (strValor != "nulo")
                        {
                            this._Dtg_LibrosNoConciliados.Rows[e.RowIndex].DefaultCellStyle.BackColor = _G_ColorInicialGrid;
                        }
                        else
                        {
                            this._Dtg_LibrosNoConciliados.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        //Guardo la seleccion en el datasource
                        string strIdc = this._Dtg_LibrosNoConciliados.Rows[e.RowIndex].Cells["cidcomprob"].Value.ToString();
                        string strcdispbanc = this._Dtg_LibrosNoConciliados.Rows[e.RowIndex].Cells["corder"].Value.ToString();
                        var oFilas = _G_Ds_BancoLibro.Tables[0].Select("cidcomprob='" + strIdc + "' and corder='" + strcdispbanc + "'");
                        foreach (var oFila in oFilas)
                        {
                            if (strValor != "nulo")
                            {
                                if (oFila["estado"] != strValor)
                                {
                                    oFila["estado"] = strValor;
                                }
                            }
                            else
                            {
                                oFila["estado"] = 0;
                            }
                        }
                    }
                }
            }
        }

        private void _Dtg_BancoNoConciliados_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void _Dtg_LibrosNoConciliados_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void _Cmb_CuentaDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_CuentaDetalle.SelectedValue != null)
            {
                if (_Cmb_CuentaDetalle.SelectedValue.ToString() != "nulo" && _Cmb_CuentaDetalle.SelectedValue.ToString() != "T3.Clases._Cls_ArrayList")
                {
                    _Mtd_LlenarFechasOmision();
                    _Dtp_Hasta.Enabled = true;
                    _Btn_IniciarProceso.Enabled = _G_Bol_PermisoCreacion;
                }
                else
                {
                    _Dtp_Desde.Enabled = false;
                    _Dtp_Hasta.Enabled = false;
                    _Btn_IniciarProceso.Enabled = false;
                }
            }
            else
            {
                _Dtp_Desde.Enabled = false;
                _Dtp_Hasta.Enabled = false;
                _Btn_IniciarProceso.Enabled = false;
            }

        }

        private void _Dtg_BancoNoConciliados_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Seteamos los estados en la variable
            _Mtd_SetearBancoNoConciliados();
            //Mostramos
            _Mtd_MostrarBancoNoConciliados();
            //Seteamos los Combos
            _Mtd_SetearCombosBancoNoConciliado();
            //Coloreamos
            _Mtd_ColorearBancoNoConciliados();
        }

        private void _Dtg_LibrosNoConciliados_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Seteamos los estados
            _Mtd_SetearLibroNoConciliados();    
            //Mostramos
            _Mtd_MostrarLibroNoConciliados();
            //Seteamos los Combos
            _Mtd_SetearCombosLibroNoConciliado();
            //Coloreamos
            _Mtd_ColorearLibroNoConciliados();
        }

        private void _Mtd_ObtenerSaldosSegunLibro(out decimal _P_Dec_SaldoInicialSegunLibro, out decimal _P_Dec_SaldoSegunLibro)
        {
            decimal _Dbl_SaldoInicialSegunLibro = 0;
            decimal _Dbl_SaldoFinalSegunLibro = 0;
            decimal _Dbl_SaldoSegunLibro = 0;
            string _Str_CuentaContable = "";

            string _Str_AnoContable = _Dtp_Desde.Value.Year.ToString();
            string _Str_MesContable = _Dtp_Desde.Value.Month.ToString();
            string _Str_DiaContable = _Dtp_Desde.Value.Day.ToString();

            string _Str_AnoHastaContable = _Dtp_Hasta.Value.Year.ToString();
            string _Str_MesHastaContable = _Dtp_Hasta.Value.Month.ToString();
            string _Str_DiaHastaContable = _Dtp_Hasta.Value.Day.ToString();

            decimal _Dec_Debe = 0;
            decimal _Dec_Haber = 0;
            decimal _Dec_SaldoAnt = 0;

            //Calculamos el Saldo Inicial
            _Dec_Debe = 0;
            _Dec_Haber = 0;
            _Dec_SaldoAnt = 0;

            _G_Str_SentenciaSql = "SELECT ccount FROM TCUENTBANC WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND cnumcuenta='" + _Cmb_CuentaDetalle.SelectedValue.ToString() + "' AND CBANCO='" +
                                  _Cmb_BancoDetalle.SelectedValue.ToString() + "' and cdelete='0'";
            _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);
            foreach (DataRow _Dtw_Fila in _G_Ds_DataSet.Tables[0].Rows)
            {
                _Str_CuentaContable = _Dtw_Fila["ccount"].ToString().Trim();
            }
            _G_Str_SentenciaSql = "EXEC SP_T3_CONSULTAMAYORANALITICO_CONCILIACION '" + Frm_Padre._Str_Comp + "','" + _Str_CuentaContable + "','" + _Str_CuentaContable + "','" + _Str_MesContable + "','" +
                                  _Str_MesHastaContable + "','" + _Str_AnoContable + "','" + _Str_AnoHastaContable + "','" + _Str_DiaContable + "'";
            _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);
            foreach (DataRow _Dtw_Fila in _G_Ds_DataSet.Tables[0].Rows)
            {
                if (_Dtw_Fila["csaldo"].ToString().Trim() != "")
                {
                    _Dec_SaldoAnt = Convert.ToDecimal(_Dtw_Fila["csaldo"].ToString().Trim());
                }
                if ((_Dtw_Fila["cdia"].ToString().Trim() != ""))
                {
                    var _Int_Dia = Convert.ToInt32(_Dtw_Fila["cdia"].ToString().Trim());
                    var _Int_DiaContable = Convert.ToInt32(_Str_DiaContable);
                    if (_Int_Dia < _Int_DiaContable) // Solo hasta el dia anterior
                    {
                        if (_Dtw_Fila["cdebitos"].ToString().Trim() != "")
                        {
                            _Dec_Debe += Convert.ToDecimal(_Dtw_Fila["cdebitos"].ToString().Trim());
                        }
                        if (_Dtw_Fila["ccreditos"].ToString().Trim() != "")
                        {
                            _Dec_Haber += Convert.ToDecimal(_Dtw_Fila["ccreditos"].ToString().Trim());
                        }
                    }
                }
            }
            _Dbl_SaldoSegunLibro = _Dec_SaldoAnt + (_Dec_Debe - _Dec_Haber);
            _Dbl_SaldoInicialSegunLibro = _Dbl_SaldoSegunLibro;


            //Calculamos el Saldo Final
            _Dec_Debe = 0;
            _Dec_Haber = 0;
            _Dec_SaldoAnt = 0;

            _G_Str_SentenciaSql = "SELECT ccount FROM TCUENTBANC WHERE CCOMPANY='" + Frm_Padre._Str_Comp + "' AND cnumcuenta='" + _Cmb_CuentaDetalle.SelectedValue.ToString() + "' AND CBANCO='" +
                                  _Cmb_BancoDetalle.SelectedValue.ToString() + "' and cdelete='0'";
            _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);
            foreach (DataRow _Dtw_Fila in _G_Ds_DataSet.Tables[0].Rows)
            {
                _Str_CuentaContable = _Dtw_Fila["ccount"].ToString().Trim();
            }
            _G_Str_SentenciaSql = "EXEC SP_T3_CONSULTAMAYORANALITICO_CONCILIACION '" + Frm_Padre._Str_Comp + "','" + _Str_CuentaContable + "','" + _Str_CuentaContable + "','" + _Str_MesContable + "','" +
                                  _Str_MesHastaContable + "','" + _Str_AnoContable + "','" + _Str_AnoHastaContable + "','" + _Str_DiaHastaContable + "'";
            _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);
            foreach (DataRow _Dtw_Fila in _G_Ds_DataSet.Tables[0].Rows)
            {
                if (_Dtw_Fila["csaldo"].ToString().Trim() != "")
                {
                    _Dec_SaldoAnt = Convert.ToDecimal(_Dtw_Fila["csaldo"].ToString().Trim());
                }
                if (_Dtw_Fila["cdebitos"].ToString().Trim() != "")
                {
                    _Dec_Debe += Convert.ToDecimal(_Dtw_Fila["cdebitos"].ToString().Trim());
                }
                if (_Dtw_Fila["ccreditos"].ToString().Trim() != "")
                {
                    _Dec_Haber += Convert.ToDecimal(_Dtw_Fila["ccreditos"].ToString().Trim());
                }
            }
            _Dbl_SaldoSegunLibro = _Dec_SaldoAnt + (_Dec_Debe - _Dec_Haber);
            _Dbl_SaldoFinalSegunLibro = _Dbl_SaldoSegunLibro;

            //Devolvemos
            _P_Dec_SaldoInicialSegunLibro = _Dbl_SaldoInicialSegunLibro;
            _P_Dec_SaldoSegunLibro = _Dbl_SaldoFinalSegunLibro;
        }

        /// <summary>
        /// Muestra los Saldos
        /// </summary>
        private void _Mtd_MostrarSaldos()
        {
            decimal _decSaldoInicialBanco = 0;
            decimal _decSaldoFinalBanco = 0;
            decimal _decSaldoInicialSegunLibro = 0;
            decimal _decSaldoSegunLibro = 0;

            //Calculo Saldos
            _decSaldoInicialBanco = _Cls_RutinasConciliacion._Mtd_ObtenerSaldoInicialBanco(_Cmb_BancoDetalle.SelectedValue.ToString(), _Cmb_CuentaDetalle.SelectedValue.ToString());
            _decSaldoFinalBanco = _Cls_RutinasConciliacion._Mtd_ObtenerSaldoFinalCapturaBanco(_Cmb_BancoDetalle.SelectedValue.ToString(), _Cmb_CuentaDetalle.SelectedValue.ToString(),_Cls_RutinasConciliacion._TipoEstadoDeCuenta.Conciliacion);
            _Mtd_ObtenerSaldosSegunLibro(out _decSaldoInicialSegunLibro, out _decSaldoSegunLibro);

            //Muestro los saldos
            _Txt_SaldoInicialBanco.Text = _decSaldoInicialBanco.ToString("#,##0.00");
            _Txt_SaldoFinalBanco.Text = _decSaldoFinalBanco.ToString("#,##0.00");
            _Txt_SaldoInicialSegunLibro.Text = _decSaldoInicialSegunLibro.ToString("#,##0.00");
            _Txt_SaldoSegunLibro.Text = _decSaldoSegunLibro.ToString("#,##0.00");

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
            foreach (DataGridViewRow _Dtw_Fila in _Dtg_LibrosNoConciliados.Rows)
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

        private void _Dtg_LibrosNoConciliados_CellClick(object sender, DataGridViewCellEventArgs e)
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
                _Dtg_LibrosNoConciliados.CurrentCell = _Dtg_LibrosNoConciliados.Rows[_intFila].Cells[_intColumna];
                _Dtg_LibrosNoConciliados.BeginEdit(true);
            }
            else
            {
                //_Dtg_LibrosNoConciliados.CurrentCell = _Dtg_LibrosNoConciliados.Rows[_intFila].Cells[_intColumna];
                _Dtg_LibrosNoConciliados.CancelEdit();
            }
        }

        private int _Int_Orden = 1;
        private void _Dtg_ConciliarBancoLibro_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (_Dtg_ConciliarBancoLibro.Rows.Count > 0)
            //{
            //    if (_Dtg_ConciliarBancoLibro.Columns[e.ColumnIndex].Name == "Monto")
            //    {
            //        if (_Int_Orden == 1)
            //        {
            //            _Dtg_ConciliarBancoLibro.Sort(new OrdenarColumnaNumerica(System.Windows.Forms.SortOrder.Ascending, e.ColumnIndex));
            //            _Int_Orden = 0;
            //        }
            //        else
            //        {
            //            _Dtg_ConciliarBancoLibro.Sort(new OrdenarColumnaNumerica(System.Windows.Forms.SortOrder.Descending, e.ColumnIndex));
            //            _Int_Orden = 1;
            //        }
            //    }
            //}
        }

        private void _Btn_VerReporteBanco_Click(object sender, EventArgs e)
        {
            _Mtd_MostrarReporteBanco(_G_Int_IdConciliacion.ToString(CultureInfo.InvariantCulture), Frm_Padre._Str_Comp);
        }

        private void _Btn_VerReporteLibro_Click(object sender, EventArgs e)
        {
            _Mtd_MostrarReporteLibro(_G_Int_IdConciliacion.ToString(CultureInfo.InvariantCulture), Frm_Padre._Str_Comp);
        }

        private void _Btn_VerReporteConciliacion_Click(object sender, EventArgs e)
        {
            _Mtd_MostrarReporteConciliacion(_G_Int_IdConciliacion.ToString(CultureInfo.InvariantCulture), Frm_Padre._Str_Comp);
        }

        private void Frm_ConciliacionBancariaV2_Shown(object sender, EventArgs e)
        {
            if (_Bol_NotificadorAprobacion)
                _Mtd_ColorGridConciliado();
                //_Mtd_CargarBancoNoConciliado();
            if (HayComprobantesConciliacionesManualesPorActualizar())
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Hay Comprobantes de conciliaciones manuales por actualizar, debe actualizarlos antes de continuar.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            if (_Mtd_HayComprobantesManualesPorActualizar(Frm_Padre._Str_Comp,  _G_Int_IdConciliacion.ToString()))
            {
                Cursor = Cursors.Default;
                MessageBox.Show("No se puede continuar debido que existen comprobantes de ajustes manuales por actualizar. Debe actualizarlos para poder continuar con el proceso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }
        }

        private decimal _Mtd_ObtenerSignoSegunEstado(string pEstado)
        {
            _G_Str_SentenciaSql = "SELECT ctotalessignopositivo FROM TESTADOSCONC WHERE cestadoid='" + pEstado + "' and cdelete='0'";
            _G_Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSql);
            if (_G_Ds_DataSet.Tables[0].Rows.Count > 0)
            {
                if (_G_Ds_DataSet.Tables[0].Rows[0]["ctotalessignopositivo"].ToString() == "1")
                {
                    return 1;
                }
                return -1;
            }
            return 1;
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
            //Pasamos el filtro
            _G_Ds_BancoLibro.Tables[0].DefaultView.RowFilter = _Str_FiltroGenerado;
            _Dtg_ConciliarBancoLibro.DataSource = _G_Ds_BancoLibro.Tables[0].DefaultView;
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
            var _G_Dt_BancoLibroConciliado = _G_Ds_BancoLibro.Tables[0];
            //Ordenamos
            if (_G_Dt_BancoLibroConciliado.Rows.Count > 0)
            {
                _G_Dt_BancoLibroConciliado = _G_Dt_BancoLibroConciliado.AsEnumerable()
                                                                       .OrderByDescending(n => n["cconciliado"])
                                                                       .ThenBy(n => n["cseleccionado"])
                                                                    //.ThenBy(n => n["cidconciliacion"])
                                                                    //.ThenBy(n => n["ciddetalleconciliacion"])
                                                                    //.ThenBy(n => n["ctiporegistro"])
                                                                       .ThenBy(n => decimal.Parse(n["Monto"].ToString()))
                                                                       .ThenBy(n => n["Número Doc."])
                                                                       .CopyToDataTable();
            }
            //Paso el Dataset Actualizado
            _Dtg_ConciliarBancoLibro.DataSource = _G_Dt_BancoLibroConciliado.DefaultView;
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

       private void _Btn_ExportConciliados1_Click(object sender, EventArgs e)
        {
            _Mtd_ExportarConciliados();
        }
        private void _Btn_ExportConciliados2_Click(object sender, EventArgs e)
        {
            _Mtd_ExportarConciliados();
        }
        private void _Btn_ExportNoConciliados1_Click(object sender, EventArgs e)
        {
            _Mtd_ExportarNoConciliados();
        }
        private void _Btn_ExportNoConciliados2_Click(object sender, EventArgs e)
        {
            _Mtd_ExportarNoConciliados();
        }

        //private void _Mtd_ExportarConciliados_Antiguo()
        //{
        //    //Instanciamos la variables
        //    DataTable _Dt_Conciliados;

        //    //Cargamos los datos
        //    if (_G_Bol_ModoReporte)
        //    {
        //        //Pasamos los datos
        //        var _Dt_TodosLosRegistros = _Mtd_CargarDetalleConciliacion(Frm_Padre._Str_Comp, _G_Str_IdConciliacionReporte);
        //        _Dt_Conciliados = _Dt_TodosLosRegistros.Clone();
        //        foreach (var _Fila in _Dt_TodosLosRegistros.Select("CESTADO=0"))
        //            _Dt_Conciliados.LoadDataRow(_Fila.ItemArray, true);

        //        //Si hay datos
        //        if (_Dt_Conciliados.Rows.Count > 0)
        //        {
        //            //Ordenamos
        //            _Dt_Conciliados = _Dt_Conciliados.AsEnumerable()
        //                                             .OrderByDescending(n => n["ciddetalleconciliacion"])
        //                                             .ThenBy(n => n["ctiporegistro"])
        //                                             .ThenBy(n => decimal.Parse(n["Monto"].ToString()))
        //                                             .ThenBy(n => n["Número Doc."])
        //                                             .CopyToDataTable();

        //        }
        //        //Removemos las Columnas no Necesarias
        //        _Dt_Conciliados.Columns.Remove("cestado");
        //        _Dt_Conciliados.Columns.Remove("ciddetalleconciliacion");
        //        _Dt_Conciliados.Columns.Remove("ctiporegistro");
        //    }
        //    else
        //    {
        //        //Pasamos los datos
        //        _Dt_Conciliados = _G_Ds_BancoLibro.Tables[0].Clone();
        //        foreach (var _Fila in _G_Ds_BancoLibro.Tables[0].Select("cconciliado=1"))
        //            _Dt_Conciliados.LoadDataRow(_Fila.ItemArray, true);

        //        //Si hay datos
        //        if (_Dt_Conciliados.Rows.Count > 0)
        //        {
        //            //Ordenamos
        //            _Dt_Conciliados = _Dt_Conciliados.AsEnumerable()
        //                                             .OrderByDescending(n => n["cconciliado"])
        //                                             .ThenBy(n => n["cseleccionado"])
        //                                             .ThenBy(n => n["cidconciliacion"])
        //                                             .ThenBy(n => n["ciddetalleconciliacion"])
        //                                             .ThenBy(n => n["ctiporegistro"])
        //                                             .ThenBy(n => decimal.Parse(n["Monto"].ToString()))
        //                                             .ThenBy(n => n["Número Doc."])
        //                                             .CopyToDataTable();
        //        }
                
        //        //Removemos las Columnas no Necesarias
        //        _Dt_Conciliados.Columns.Remove("cseleccionado");
        //        _Dt_Conciliados.Columns.Remove("cdispband");
        //        _Dt_Conciliados.Columns.Remove("cdispbanc");
        //        _Dt_Conciliados.Columns.Remove("ctotdebe");
        //        _Dt_Conciliados.Columns.Remove("ctothaber");
        //        _Dt_Conciliados.Columns.Remove("cidedetalleconciliacion");
        //        _Dt_Conciliados.Columns.Remove("cidcomprob");
        //        _Dt_Conciliados.Columns.Remove("corder");
        //        _Dt_Conciliados.Columns.Remove("estado");
        //        _Dt_Conciliados.Columns.Remove("estadodescripcion");
        //        _Dt_Conciliados.Columns.Remove("cconciliado");
        //        _Dt_Conciliados.Columns.Remove("ccount_ajustar");
        //        _Dt_Conciliados.Columns.Remove("cGeneraAjustesAutomaticos");
        //        _Dt_Conciliados.Columns.Remove("cconciliadoAutomaticamente");
        //        _Dt_Conciliados.Columns.Remove("coperbancseleccionado");
        //        _Dt_Conciliados.Columns.Remove("cidconciliacion");
        //        _Dt_Conciliados.Columns.Remove("ciddetalleconciliacion");
        //        _Dt_Conciliados.Columns.Remove("ctiporegistro");
        //    }

        //    //Ordenamos las columnas
        //    _Dt_Conciliados.Columns["Tip.Reg."].SetOrdinal(0);
        //    _Dt_Conciliados.Columns["Número Doc."].SetOrdinal(1);
        //    _Dt_Conciliados.Columns["Fecha"].SetOrdinal(2);
        //    _Dt_Conciliados.Columns["Comprobante"].SetOrdinal(3);
        //    _Dt_Conciliados.Columns["Cuenta Contable"].SetOrdinal(4);
        //    _Dt_Conciliados.Columns["Concepto"].SetOrdinal(5);
        //    _Dt_Conciliados.Columns["Tipo de Operación"].SetOrdinal(6);
        //    _Dt_Conciliados.Columns["Monto"].SetOrdinal(7);

        //    //Pasamos
        //    var _Registros_Conciliados = _Dt_Conciliados.AsEnumerable();

        //    if (_Registros_Conciliados.Any())
        //    {
        //        _Dt_Conciliados = _Registros_Conciliados.CopyToDataTable();
        //        //Guardamos
        //        var _Dlg_GuardarArchivo = new SaveFileDialog { Filter = "Archivos de Excel (*.xls)|*.xls" };
        //        if (_Dlg_GuardarArchivo.ShowDialog() == DialogResult.OK)
        //        {
        //            Cursor = Cursors.WaitCursor;
        //            var _MyExcel = new T3.Clases._Cls_ExcelUtilidades();
        //            _MyExcel._Mtd_DatasetToExcel_Conciliacion(_Dt_Conciliados, _Dlg_GuardarArchivo.FileName, "Conciliados");
        //            _MyExcel = null;
        //            Cursor = Cursors.Default;
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("No hay registros conciliados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //}

        private bool _Mtd_ConciliacionFinalizada(int _P_int_cidconciliacion)
        {
            var _Str_SentenciaSql = "SELECT cfinalizado FROM TCONCILIACION WHERE cfinalizado='1' and cidconciliacion='" + _P_int_cidconciliacion + "' and CCOMPANY='" + Frm_Padre._Str_Comp + "' ";
            var _Ds_DataSet = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_SentenciaSql);
            return _Ds_DataSet.Tables[0].Rows.Count > 0;
        }

        private void _Mtd_ExportarConciliados()
        {
            //Instanciamos la variables
            var _Bol_ConciliacionFinalizada = _Mtd_ConciliacionFinalizada(_G_Int_IdConciliacion);

            //Cargamos los datos
            var _Dt_Conciliados = _Mtd_CargarDetalleConciliacion(Frm_Padre._Str_Comp, _G_Int_IdConciliacion.ToString(CultureInfo.InvariantCulture), _Cls_RutinasConciliacion._TipoDetalleConsulta.Conciliados, _Bol_ConciliacionFinalizada);
            var _Dt_Comprobantes = _Mtd_CargarDetalleConciliacion(Frm_Padre._Str_Comp, _G_Int_IdConciliacion.ToString(CultureInfo.InvariantCulture), _Cls_RutinasConciliacion._TipoDetalleConsulta.AjustesConComprobante, _Bol_ConciliacionFinalizada);
            var _Dt_AjustesSinComprobante = _Mtd_CargarDetalleConciliacion(Frm_Padre._Str_Comp, _G_Int_IdConciliacion.ToString(CultureInfo.InvariantCulture), _Cls_RutinasConciliacion._TipoDetalleConsulta.AjustesSinComprobante, _Bol_ConciliacionFinalizada);

            //Si hay registro en cualquiera de las hojas
            if (_Dt_Conciliados.Rows.Count > 0 || _Dt_Comprobantes.Rows.Count > 0 || _Dt_AjustesSinComprobante.Rows.Count > 0)
            {
                //Generamos el Objeto a pasar al metodo de exportar
                var _oDatos = new List<_Cls_ExportarExcel>();
                _oDatos.Add(new _Cls_ExportarExcel { Datos = _Dt_AjustesSinComprobante, NombreHoja = "Ajustes sin comprobante" });
                _oDatos.Add(new _Cls_ExportarExcel { Datos = _Dt_Comprobantes, NombreHoja = "Comprobantes" });
                _oDatos.Add(new _Cls_ExportarExcel { Datos = _Dt_Conciliados, NombreHoja = "Conciliados" });
                //Guardamos el archivo de excel
                var _Dlg_GuardarArchivo = new SaveFileDialog {Filter = "Archivos de Excel (*.xls)|*.xls"};
                if (_Dlg_GuardarArchivo.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    var _MyExcel = new _Cls_ExcelUtilidades();
                    _MyExcel._Mtd_DatasetToExcel_Conciliacion(_oDatos, _Dlg_GuardarArchivo.FileName);
                    _MyExcel = null;
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                MessageBox.Show("No hay registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void _Mtd_ExportarNoConciliados()
        {
            //Instanciamos la variables
            var _Bol_ConciliacionFinalizada = _Mtd_ConciliacionFinalizada(_G_Int_IdConciliacion);

            //Cargamos los datos
            var _Dt_Registros = _Mtd_CargarDetalleConciliacion(Frm_Padre._Str_Comp, _G_Int_IdConciliacion.ToString(CultureInfo.InvariantCulture), _Cls_RutinasConciliacion._TipoDetalleConsulta.NoConciliados, _Bol_ConciliacionFinalizada);

            if (_Dt_Registros.Rows.Count > 0)
            {
                //Guardamos
                var _Dlg_GuardarArchivo = new SaveFileDialog { Filter = "Archivos de Excel (*.xls)|*.xls" };
                if (_Dlg_GuardarArchivo.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    var _MyExcel = new T3.Clases._Cls_ExcelUtilidades();
                    _MyExcel._Mtd_DatasetToExcel_Conciliacion(_Dt_Registros, _Dlg_GuardarArchivo.FileName, "No Conciliados");
                    _MyExcel = null;
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                MessageBox.Show("No hay registros no conciliados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private DataTable _Mtd_CargarDetalleConciliacion(string _P_Str_Ccompany, string _P_Str_IdConciliacion, _Cls_RutinasConciliacion._TipoDetalleConsulta _P_TipoDetalleConsulta, bool _P_ConciliacionFinalizada)
        {

            if (_P_ConciliacionFinalizada)
            {
                Cursor = Cursors.WaitCursor;
                var _G_Str_SentenciaSQL = "";

                switch (_P_TipoDetalleConsulta)
                {
                    case _Cls_RutinasConciliacion._TipoDetalleConsulta.Conciliados:
                        _G_Str_SentenciaSQL = "SELECT " +
                                              " [Tip.Reg.]  " +
                                              ", [Número Doc.] " +
                                              ", [Fecha] " +
                                              ", [Comprobante] " +
                                              ", [Concepto] " +
                                              ", [Tipo de Operación] " +
                                              ", [Monto] " +
                                              " FROM VST_DETALLECOMPLETOCONCILIACION " +
                                              " WHERE " +
                                              " CCOMPANY='" + _P_Str_Ccompany + "' " +
                                              " AND cidconciliacion='" + _P_Str_IdConciliacion + "' " +
                                              " AND cestado=0" +
                                              " AND ctiporegistro in ('" + (byte)_Cls_RutinasConciliacion._TipoRegistro.NoAplica + "','" + (byte)_Cls_RutinasConciliacion._TipoRegistro.Nuevo + "') " +
                                              " ORDER BY [Monto],[Número Doc.],[Tip.Reg.] ";

                                              break;
                    case _Cls_RutinasConciliacion._TipoDetalleConsulta.NoConciliados:
                        _G_Str_SentenciaSQL = "SELECT " +
                                              " [Tip.Reg.]  " +
                                              ", [Número Doc.] " +
                                              ", [Fecha] " +
                                              ", [Comprobante] " +
                                              ", [Concepto] " +
                                              ", [Tipo de Operación] " +
                                              ", [Monto] " +
                                              " FROM VST_DETALLECOMPLETOCONCILIACION " +
                                              " WHERE " +
                                              " CCOMPANY='" + _P_Str_Ccompany + "' " +
                                              " AND cidconciliacion='" + _P_Str_IdConciliacion + "' " +
                                              " AND cestado<>0 " +
                                              " ORDER BY ctiporegistro, [Monto], [Número Doc.] ";
                        break;
                    case _Cls_RutinasConciliacion._TipoDetalleConsulta.AjustesConComprobante:
                        _G_Str_SentenciaSQL = "SELECT " +
                                              " [Tip.Reg.]  " +
                                              //", [Número Doc.] " +
                                              ", [Fecha] " +
                                              ", [Comprobante] " +
                                              ", [Linea] " +
                                              ", [Concepto] " +
                                              ", [Cuenta] " +
                                              ", [Débitos] " +
                                              ", [Créditos] " +
                                              " FROM [VST_CONCILIACION_COMPROBANTES] " +
                                              " WHERE " +
                                              " CCOMPANY='" + _P_Str_Ccompany + "' " +
                                              " AND cidconciliacion='" + _P_Str_IdConciliacion + "' " +
                                              " ORDER BY cidcomprob, corder ";
                        break;
                    case _Cls_RutinasConciliacion._TipoDetalleConsulta.AjustesSinComprobante:
                        _G_Str_SentenciaSQL = "SELECT " +
                                              " [Tip.Reg.]  " +
                                              //", [Número Doc.] " +
                                              ", [Fecha] " +
                                              ", [Comprobante] " +
                                              ", [Concepto] " +
                                              ", [Linea] " +
                                              ", [Cuenta] " +
                                              ", [Débitos] " +
                                              ", [Créditos] " +
                                              " FROM [VST_CONCILIACION_AJUSTESQUENOGENERANCOMPROBANTE] " +
                                              " WHERE " +
                                              " CCOMPANY='" + _P_Str_Ccompany + "' " +
                                              " AND cidconciliacion='" + _P_Str_IdConciliacion + "' " +
                                              " AND ctipoajuste='" + (byte) Frm_AprobConcManuales.Tipoajuste.CruceMovimientosContables + "' " +
                                              " ORDER BY cidcomprob, corder ";
                        break;
                }

                var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
                Cursor = Cursors.Default;
                return _Ds.Tables[0];
            }
            else
            {
                //Cuando la conciliacion no es finalizada
                Cursor = Cursors.WaitCursor;
                var _Dt_Registros = new DataTable();
                switch (_P_TipoDetalleConsulta)
                {
                    case _Cls_RutinasConciliacion._TipoDetalleConsulta.Conciliados:
                        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - Conciliados - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

                        //Pasamos los datos
                        _Dt_Registros = _G_Ds_BancoLibro.Tables[0].Clone();
                        foreach (var _Fila in _G_Ds_BancoLibro.Tables[0].Select("cconciliado=1")) _Dt_Registros.LoadDataRow(_Fila.ItemArray, true);

                        //Si hay datos
                        if (_Dt_Registros.Rows.Count > 0)
                        {
                            //Ordenamos
                            _Dt_Registros = _Dt_Registros.AsEnumerable()
                                                         .OrderByDescending(n => n["cconciliado"])
                                                         .ThenBy(n => n["cseleccionado"])
                                                         .ThenBy(n => n["cidconciliacion"])
                                                         .ThenBy(n => n["ciddetalleconciliacion"])
                                                         .ThenBy(n => n["ctiporegistro"])
                                                         .ThenBy(n => decimal.Parse(n["Monto"].ToString()))
                                                         .ThenBy(n => n["Número Doc."])
                                                         .CopyToDataTable();
                        }

                        //Removemos las Columnas no Necesarias
                        _Dt_Registros.Columns.Remove("cseleccionado");
                        _Dt_Registros.Columns.Remove("cdispband");
                        _Dt_Registros.Columns.Remove("cdispbanc");
                        _Dt_Registros.Columns.Remove("ctotdebe");
                        _Dt_Registros.Columns.Remove("ctothaber");
                        _Dt_Registros.Columns.Remove("cidedetalleconciliacion");
                        _Dt_Registros.Columns.Remove("cidcomprob");
                        _Dt_Registros.Columns.Remove("corder");
                        _Dt_Registros.Columns.Remove("estado");
                        _Dt_Registros.Columns.Remove("estadodescripcion");
                        _Dt_Registros.Columns.Remove("cconciliado");
                        _Dt_Registros.Columns.Remove("ccount_ajustar");
                        _Dt_Registros.Columns.Remove("cGeneraAjustesAutomaticos");
                        _Dt_Registros.Columns.Remove("cconciliadoAutomaticamente");
                        _Dt_Registros.Columns.Remove("coperbancseleccionado");
                        _Dt_Registros.Columns.Remove("cidconciliacion");
                        _Dt_Registros.Columns.Remove("ciddetalleconciliacion");
                        _Dt_Registros.Columns.Remove("ctiporegistro");
                        _Dt_Registros.Columns.Remove("ctipoajuste");
                        _Dt_Registros.Columns.Remove("Cuenta Contable");
                        _Dt_Registros.Columns.Remove("cregdate");
                        _Dt_Registros.Columns.Remove("ccompany");
                        _Dt_Registros.Columns.Remove("cbanco");
                        _Dt_Registros.Columns.Remove("cnumcuenta");
                        _Dt_Registros.Columns.Remove("cidconciliaciondmanual");

                        //Ordenamos las columnas
                        _Dt_Registros.Columns["Tip.Reg."].SetOrdinal(0);
                        _Dt_Registros.Columns["Número Doc."].SetOrdinal(1);
                        _Dt_Registros.Columns["Fecha"].SetOrdinal(2);
                        _Dt_Registros.Columns["Comprobante"].SetOrdinal(3);
                        _Dt_Registros.Columns["Concepto"].SetOrdinal(4);
                        _Dt_Registros.Columns["Tipo de Operación"].SetOrdinal(5);
                        _Dt_Registros.Columns["Monto"].SetOrdinal(6);

                        break;

                    case _Cls_RutinasConciliacion._TipoDetalleConsulta.NoConciliados:

                        //Pasamos los datos
                        _Dt_Registros = _G_Ds_BancoLibro.Tables[0].Clone();
                        foreach (var _Fila in _G_Ds_BancoLibro.Tables[0].Select("cconciliado=0")) _Dt_Registros.LoadDataRow(_Fila.ItemArray, true);

                        //Si hay datos
                        if (_Dt_Registros.Rows.Count > 0)
                        {
                            //Ordenamos
                            _Dt_Registros = _Dt_Registros.AsEnumerable()
                                                         .OrderByDescending(n => n["cconciliado"])
                                                         .ThenBy(n => n["cseleccionado"])
                                                         .ThenBy(n => n["cidconciliacion"])
                                                         .ThenBy(n => n["ciddetalleconciliacion"])
                                                         .ThenBy(n => n["ctiporegistro"])
                                                         .ThenBy(n => decimal.Parse(n["Monto"].ToString()))
                                                         .ThenBy(n => n["Número Doc."])
                                                         .CopyToDataTable();
                        }

                        //Removemos las Columnas no Necesarias
                        _Dt_Registros.Columns.Remove("cseleccionado");
                        _Dt_Registros.Columns.Remove("cdispband");
                        _Dt_Registros.Columns.Remove("cdispbanc");
                        _Dt_Registros.Columns.Remove("ctotdebe");
                        _Dt_Registros.Columns.Remove("ctothaber");
                        _Dt_Registros.Columns.Remove("cidedetalleconciliacion");
                        _Dt_Registros.Columns.Remove("cidcomprob");
                        _Dt_Registros.Columns.Remove("corder");
                        _Dt_Registros.Columns.Remove("estado");
                        _Dt_Registros.Columns.Remove("estadodescripcion");
                        _Dt_Registros.Columns.Remove("cconciliado");
                        _Dt_Registros.Columns.Remove("ccount_ajustar");
                        _Dt_Registros.Columns.Remove("cGeneraAjustesAutomaticos");
                        _Dt_Registros.Columns.Remove("cconciliadoAutomaticamente");
                        _Dt_Registros.Columns.Remove("coperbancseleccionado");
                        _Dt_Registros.Columns.Remove("cidconciliacion");
                        _Dt_Registros.Columns.Remove("ciddetalleconciliacion");
                        _Dt_Registros.Columns.Remove("ctiporegistro");
                        _Dt_Registros.Columns.Remove("Cuenta Contable");
                        _Dt_Registros.Columns.Remove("ctipoajuste");
                        _Dt_Registros.Columns.Remove("cregdate");
                        _Dt_Registros.Columns.Remove("ccompany");
                        _Dt_Registros.Columns.Remove("cbanco");
                        _Dt_Registros.Columns.Remove("cnumcuenta");
                        _Dt_Registros.Columns.Remove("cidconciliaciondmanual");

                        //Ordenamos las columnas
                        _Dt_Registros.Columns["Tip.Reg."].SetOrdinal(0);
                        _Dt_Registros.Columns["Número Doc."].SetOrdinal(1);
                        _Dt_Registros.Columns["Fecha"].SetOrdinal(2);
                        _Dt_Registros.Columns["Comprobante"].SetOrdinal(3);
                        _Dt_Registros.Columns["Concepto"].SetOrdinal(4);
                        _Dt_Registros.Columns["Tipo de Operación"].SetOrdinal(5);
                        _Dt_Registros.Columns["Monto"].SetOrdinal(6);

                        break;

                    case _Cls_RutinasConciliacion._TipoDetalleConsulta.AjustesConComprobante:

                        var _G_Str_SentenciaSQL = "SELECT " +
                                                  " [Tip.Reg.]  " +
                                                  //", [Número Doc.] " +
                                                  ", [Fecha] " +
                                                  ", [Comprobante] " +
                                                  ", [Concepto] " +
                                                  ", [Linea] " +
                                                  ", [Cuenta] " +
                                                  ", [Débitos] " +
                                                  ", [Créditos] " +
                                                  " FROM [VST_CONCILIACION_COMPROBANTES] " +
                                                  " WHERE " +
                                                  " CCOMPANY='" + _P_Str_Ccompany + "' " +
                                                  " AND cidconciliacion='" + _P_Str_IdConciliacion + "' " +
                                                  " ORDER BY cidcomprob, corder ";

                        _Dt_Registros = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL).Tables[0];

                        break;

                    case _Cls_RutinasConciliacion._TipoDetalleConsulta.AjustesSinComprobante:

                        _G_Str_SentenciaSQL = "SELECT " +
                                              " [Tip.Reg.]  " +
                                              //", [Número Doc.] " +
                                              ", [Fecha] " +
                                              ", [Comprobante] " +
                                              ", [Concepto] " +
                                              ", [Linea] " +
                                              ", [Cuenta] " +
                                              ", [Débitos] " +
                                              ", [Créditos] " +
                                              " FROM [VST_CONCILIACION_AJUSTESQUENOGENERANCOMPROBANTE] " +
                                              " WHERE " +
                                              " CCOMPANY='" + _P_Str_Ccompany + "' " +
                                              " AND cidconciliacion='" + _P_Str_IdConciliacion + "' " +
                                              " AND ctipoajuste='" + (byte) Frm_AprobConcManuales.Tipoajuste.CruceMovimientosContables + "' " +
                                              " ORDER BY cidcomprob, corder ";

                        var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_G_Str_SentenciaSQL);
                        Cursor = Cursors.Default;
                        _Dt_Registros =  _Ds.Tables[0];

                        break;
                }

                //Devolvemos
                Cursor = Cursors.Default;
                return _Dt_Registros;
            }
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
                //_Control.Click += new EventHandler(_Mtd_ComboBox_BancoNoConciliados_Click);
                //_Control.SelectedIndexChanged -= new EventHandler(_Mtd_ComboBox_BancoNoConciliados_SelectedIndexChanged);
                //_Control.SelectedIndexChanged += new EventHandler(_Mtd_ComboBox_BancoNoConciliados_SelectedIndexChanged);
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
                //_Dtg.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // LIBRO NO CONCILIADO
        private void _Dtg_LibrosNoConciliados_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var _Control = e.Control as ComboBox;
            if (_Control != null)
            {
                _Control.Enter -= new EventHandler(_Mtd_Combo_LibroNoConciliados_Enter);
                _Control.Enter += new EventHandler(_Mtd_Combo_LibroNoConciliados_Enter);
                _Control.Leave -= new EventHandler(_Mtd_ComboBox_LibroNoConciliados_Leave);
                _Control.Leave += new EventHandler(_Mtd_ComboBox_LibroNoConciliados_Leave);
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
        private void _Mtd_ComboBox_LibroNoConciliados_Leave(object sender, EventArgs e)
        {
            //if (_Dtg_LibrosNoConciliados.IsCurrentCellDirty)
            //{
            //    _Dtg_LibrosNoConciliados.EndEdit();
            //    _Dtg_LibrosNoConciliados.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //}
        }
        private void _Dtg_LibrosNoConciliados_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            var _Dtg = (DataGridView)sender;
            if (_Dtg.IsCurrentCellDirty)
            {
                _Dtg.CommitEdit(DataGridViewDataErrorContexts.Commit);
                _Dtg.EndEdit();
            }
        }

        private void _Dtg_LibrosNoConciliados_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }


    }

    public class _Cls_ExportarExcel
    {
        public DataTable Datos { get; set; }
        public string NombreHoja { get; set; }
    }

}

