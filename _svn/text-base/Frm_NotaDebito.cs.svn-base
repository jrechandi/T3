using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using CrystalDecisions.CrystalReports.Engine;
namespace T3
{
    public partial class Frm_NotaDebito : Form
    {
        int _Int_Clave = 0;
        bool _Bol_Constructor = false;
        string _Str_MyProceso = "";
        bool _G_Bol_Edit = false;
        string _Str_NR_Dif_Pmv = "";
        bool _Bol_PMV = false;
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        CLASES._Cls_Varios_Metodos _myUtilidad = new CLASES._Cls_Varios_Metodos(true);
        private decimal _G_Dcm_DescFinanBExcenta = 0;
        private decimal _G_Dcm_DescFinanBGrabada = 0;
        public Frm_NotaDebito()
        {
            InitializeComponent();
        }
        public Frm_NotaDebito(bool _P_Bol_PMV, string _P_Str_NR_Dif_Pmv,string _P_Str_Proveedor,string _P_Str_NombProveedor)
        {
            InitializeComponent();
            _Str_NR_Dif_Pmv = _P_Str_NR_Dif_Pmv;
            _Txt_DesProveedor.Tag = _P_Str_Proveedor.Trim();
            _Txt_DesProveedor.Text = _P_Str_NombProveedor.Trim();
            _Bol_PMV = true;
            _Tb_Tab.SelectTab(1);
        }
        public Frm_NotaDebito(string _P_Str_Clave,string _P_Str_Proveedor,string _P_Str_Documento)
        {
            InitializeComponent();
            _Bol_Constructor = true;
            _Mtd_CargarMotivo();
            _Mtd_CargarData(_P_Str_Clave);
            _Tb_Tab.SelectTab(1);
        }
        private void Frm_NotaDebito_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Mtd_Actualizar();
            if (!_Bol_Constructor)
            {
                _Mtd_Ini();
            }
        }
        private void Frm_NotaDebito_Activated(object sender, EventArgs e)
        {
            _Mtd_BotonesMenu();
        }
        private void Frm_NotaDebito_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._txt_text.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }
        private void _Mtd_CargarData(string _Pr_Str_IdND)
        {
            _Er_Error.Dispose();
            DataSet _Ds_A;
            string _Str_Sql = "SELECT cgroupcomp, ccompany, cidnotadebitocxp, cproveedor, ctipodocument, cnumdocu, cnumcontrolnd, cfechand, cdescripcion, CASE WHEN ISNULL(cidnotrecepc,0)>0 THEN ISNULL(cbasegrabada,0) ELSE cmontototsi END AS cmontototsi, cimpuesto, " +
                      "cfvfnotadebitop, cdescontada, canulado, cidcomprob, cdateadd, cuseradd, cdateupd, cuserupd, cdelete, cdatedel, cuserdel, cactivo, cimpresa, " +
                      "cdiferenciaprec, cporcinvendible, ctotaldocu, cbasegrabada, cbaseexcenta, cnotanulado, cidcomprobanul, cidnotrecepc, cidmotivo, cestatusfirma, " +
                      "calicuota, cfechaanul, cmotivoanulacion, cidprocesomanual, canticipo, cmanual, cdescfinanporc, cdescfinanmonto, cdescfinanmontobexcenta, cdescfinanmontobgrabada FROM TNOTADEBITOCP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp='" + _Pr_Str_IdND + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Cod.Text = _Pr_Str_IdND;
                _Txt_Fecha.Text = _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechand"]));
                _Txt_Control.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumcontrolnd"]);
                _Txt_DesProveedor.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["cproveedor"]);
                _Str_Sql = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE cproveedor='" + _Txt_DesProveedor.Tag.ToString() + "' AND (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1)";
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    _Txt_DesProveedor.Text = _Ds_A.Tables[0].Rows[0]["c_nomb_comer"].ToString().Trim();
                }
                _Cmb_Motivo.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cidmotivo"]).Trim();
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocument"]).Trim().Length > 0)
                {
                    _Rb_ConFact.Checked = true;
                    _Txt_Document.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumdocu"]);
                    _Txt_Document.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["calicuota"]);
                }
                else
                {
                    //_Rb_SinFact.Checked = true;
                    _Txt_Document.Text = "";
                    _Txt_Document.Tag = "";
                }
                _Txt_Monto.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototsi"]).ToString("#,##0.00");
                _Txt_Exento.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cbaseexcenta"]).ToString("#,##0.00");
                _Txt_Invendible.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cporcinvendible"]).ToString("#,##0.00");
                _Txt_Impuesto.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]).ToString("#,##0.00");
                if (Convert.ToDouble(_Txt_Impuesto.Text) > 0) 
                { _Chk_Impuesto.Checked = true; }
                else
                { _Chk_Impuesto.Checked = false; }
                //Inicializamos
                _G_Dcm_DescFinanBExcenta = 0;
                _G_Dcm_DescFinanBGrabada = 0;
                //
                if (_Ds.Tables[0].Rows[0]["cdescfinanmonto"].ToString() != "")
                {
                    if (Math.Round(Convert.ToDouble(_Ds.Tables[0].Rows[0]["cdescfinanmonto"])) != 0)
                    {
                        _Chk_AplicaDescuentoFinanciero.Checked = true;
                        _Txt_DescuentoFinanciero.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cdescfinanmonto"]).ToString("#,##0.00");
                        if (_Ds.Tables[0].Rows[0]["cdescfinanmontobexcenta"].ToString() != "")
                            _G_Dcm_DescFinanBExcenta = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cdescfinanmontobexcenta"]);
                        if (_Ds.Tables[0].Rows[0]["cdescfinanmontobgrabada"].ToString() != "")
                            _G_Dcm_DescFinanBGrabada = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cdescfinanmontobgrabada"]);
                    }
                    else
                    {
                        _Chk_AplicaDescuentoFinanciero.Checked = false;
                        _Txt_DescuentoFinanciero.Text = Convert.ToDouble(0).ToString("#,##0.00");
                    }
                }
                else
                {
                    _Chk_AplicaDescuentoFinanciero.Checked = false;
                    _Txt_DescuentoFinanciero.Text = Convert.ToDouble(0).ToString("#,##0.00");
                }



                _Txt_Total.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]).ToString("#,##0.00");
                _Txt_Descripcion.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cdescripcion"]).Trim();
                _G_Bol_Edit = false;
                string _Str_Cadena = "SELECT * FROM TNOTADEBITOCP WHERE (cestatusfirma=2 OR cidnotrecepc>0) AND cactivo=0 AND cimpresa=0 AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp='" + _Txt_Cod.Text + "'";
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Cadena))
                {
                    _Bt_Imprimir.Enabled = true;
                }
                else
                {
                    _Bt_Imprimir.Enabled = false;
                }
                _Bt_Firmar.Visible = false;
                _Bt_Detalle.Enabled = true;
            }
        }

        private void _Mtd_CargarDataTemp(string _Pr_Str_IdND)
        {
            _Er_Error.Dispose();
            DataSet _Ds_A;
            string _Str_Sql = "SELECT cgroupcomp, ccompany, cidnotadebitocxptemp, cproveedor, ctipodocument, cnumdocu, cnumcontrolnd, cfechand, cdescripcion, CASE WHEN ISNULL(cidnotrecepc,0)>0 THEN ISNULL(cmontototsi,0)-ISNULL(cbaseexcenta,0) ELSE cmontototsi END AS cmontototsi, cimpuesto, " +
                      "cdateadd, cuseradd, cdateupd, cuserupd, cporcinvendible, ctotaldocu, cbasegrabada, cbaseexcenta, cidnotrecepc, cidmotivo, cestatusfirma, calicuota, cdescfinanporc, cdescfinanmonto, cdescfinanmontobexcenta, cdescfinanmontobgrabada FROM TNOTADEBITOCPTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxptemp='" + _Pr_Str_IdND + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Txt_Cod.Text = _Pr_Str_IdND;
                _Txt_Fecha.Text = _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechand"]));
                _Txt_Control.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumcontrolnd"]);
                _Txt_DesProveedor.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["cproveedor"]);
                _Str_Sql = "SELECT c_nomb_comer FROM TPROVEEDOR WHERE cproveedor='" + _Txt_DesProveedor.Tag.ToString() + "' AND (ccompany='" + Frm_Padre._Str_Comp + "' OR cglobal=1)";
                _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                if (_Ds_A.Tables[0].Rows.Count > 0)
                {
                    _Txt_DesProveedor.Text = _Ds_A.Tables[0].Rows[0]["c_nomb_comer"].ToString().Trim();
                }
                _Cmb_Motivo.SelectedValue = Convert.ToString(_Ds.Tables[0].Rows[0]["cidmotivo"]).Trim();
                if (Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocument"]).Trim().Length > 0)
                {
                    _Rb_ConFact.Checked = true;
                    _Txt_Document.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cnumdocu"]);
                    _Txt_Document.Tag = Convert.ToString(_Ds.Tables[0].Rows[0]["calicuota"]);
                }
                else
                {
                    //_Rb_SinFact.Checked = true;
                    _Txt_Document.Text = "";
                    _Txt_Document.Tag = "";
                }
                _Txt_Monto.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cmontototsi"]).ToString("#,##0.00");
                _Txt_Exento.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cbaseexcenta"]).ToString("#,##0.00");
                _Txt_Invendible.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cporcinvendible"]).ToString("#,##0.00");
                _Txt_Impuesto.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cimpuesto"]).ToString("#,##0.00");
                if (Convert.ToDouble(_Txt_Impuesto.Text) > 0)
                { _Chk_Impuesto.Checked = true; }
                else
                { _Chk_Impuesto.Checked = false; }
                //Inicializamos
                _G_Dcm_DescFinanBExcenta = 0;
                _G_Dcm_DescFinanBGrabada = 0;
                if (_Ds.Tables[0].Rows[0]["cdescfinanmonto"].ToString() != "")
                {
                    if (Math.Round(Convert.ToDouble(_Ds.Tables[0].Rows[0]["cdescfinanmonto"])) != 0)
                    {
                        _Chk_AplicaDescuentoFinanciero.Checked = true;
                        _Txt_DescuentoFinanciero.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["cdescfinanmonto"]).ToString("#,##0.00");
                        if (_Ds.Tables[0].Rows[0]["cdescfinanmontobexcenta"].ToString() != "")
                            _G_Dcm_DescFinanBExcenta = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cdescfinanmontobexcenta"]);
                        if (_Ds.Tables[0].Rows[0]["cdescfinanmontobgrabada"].ToString() != "")
                            _G_Dcm_DescFinanBGrabada = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cdescfinanmontobgrabada"]);
                    }
                    else
                    {
                        _Chk_AplicaDescuentoFinanciero.Checked = false;
                        _Txt_DescuentoFinanciero.Text = Convert.ToDouble(0).ToString("#,##0.00");
                    }
                }
                else
                {
                    _Chk_AplicaDescuentoFinanciero.Checked = false;
                    _Txt_DescuentoFinanciero.Text = Convert.ToDouble(0).ToString("#,##0.00");
                }
                _Txt_Total.Text = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotaldocu"]).ToString("#,##0.00");
                _Txt_Descripcion.Text = Convert.ToString(_Ds.Tables[0].Rows[0]["cdescripcion"]).Trim();
                string _Str_Cadena = "SELECT cidnotadebitocxptemp FROM TNOTADEBITOCPTEMP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxptemp='" + _Txt_Cod.Text + "' AND cestatusfirma=1";
                if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Cadena))
                {
                    _G_Bol_Edit = true;
                }
                else
                {
                    _G_Bol_Edit = false;
                }
                _Bt_Imprimir.Enabled = false;
                _Bt_Firmar.Visible = false;
                _Bt_Detalle.Enabled = true;
            }
        }
        private void _Txt_Cod_EnabledChanged(object sender, EventArgs e)
        {
            if (_Txt_Cod.Enabled)
            { _Bt_Proveedor.Enabled = true; _Txt_DesProveedor.Enabled = true; }
            else
            { _Bt_Proveedor.Enabled = false; _Txt_DesProveedor.Enabled = false; }
        }
        private void _Bt_Proveedor_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(39);
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
            if (_Frm._Str_FrmResult == "1")
            {
                _Er_Error.Dispose();
                _Txt_DesProveedor.Text = _Frm._Dg_Grid[1, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().ToUpper();
                _Txt_DesProveedor.Tag = _Frm._Dg_Grid[0, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().ToUpper();
                _Cmb_Motivo.Enabled = true;
                _Cmb_Motivo.SelectedIndex = -1;
                _Txt_Monto.Text = "0";
                _Txt_Exento.Text = "0";
                _Txt_Document.Text = "";
            }
            _Frm.Dispose();
        }
        private void _Cmb_Motivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Str_MyProceso.Length > 0)
            {
                if (_Cmb_Motivo.SelectedIndex > 0)
                {
                    _Rb_ConFact.Enabled = true;
                    //_Rb_SinFact.Enabled = true;
                    if (_Rb_ConFact.Checked)
                    {
                        _Txt_Descripcion.Text = _Cmb_Motivo.Text.ToString().Trim() + " FACTURA# " + _Txt_Document.Text;
                        _Bt_FindFactura.Enabled = true;
                        _Er_Error.Dispose();
                    }
                    else
                    {
                        _Txt_Descripcion.Text = _Cmb_Motivo.Text.ToString().Trim();
                    }
                    _Txt_Monto.Text = "0";
                    _Txt_Exento.Text = "0";
                }
                else
                {
                    _Txt_Descripcion.Text = "";
                    _Bt_FindFactura.Enabled = false;
                }
            }
        }
        private void _Txt_Monto_KeyPress(object sender, KeyPressEventArgs e)
        {
            _myUtilidad._Mtd_Valida_Numeros(_Txt_Monto, e, 10, 2);
        }
        private void _Bt_Imprimir_Click(object sender, EventArgs e)
        {
            string _Str_Sql = "SELECT * FROM TNOTADEBITOCP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp='" + _Txt_Cod.Text + "' AND cestatusfirma=2";// AND (cidnotrecepc=0 OR cidnotrecepc IS NULL)";
            if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
            {
                if (MessageBox.Show("Esta seguro de imprimir la ND# " + _Txt_Cod.Text.Trim(), "Precausión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _Int_Clave = 0;
                    _Pnl_Clave.Visible = true;
                    _Txt_Clave.Focus();
                }
            }
            else
            {
                MessageBox.Show("Debe guardar la información antes de imprimir", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void _Mtd_Imprimir(string _P_Str_TipoND, string _P_Str_CuentaOtros)
        {
            try
            {
                string _Str_PrefijoCorrel = CLASES._Cls_Varios_Metodos._Mtd_ObtenerPrefijoCorrel(Frm_Padre._Str_Comp);
                string _Str_Cadena = "select cimpresa,cidcomprob,cdiferenciaprec,cnumdocu,cproveedor,cidnotrecepc from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text + "' and cproveedor='" + _Txt_DesProveedor.Tag.ToString() + "'";
                DataSet _Ds2 = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds2.Tables[0].Rows.Count > 0)
                {
                    if (_Ds2.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        PrintDialog _Print = new PrintDialog();
                    _PrintG:
                        if (_Print.ShowDialog() == DialogResult.OK)
                        {
                            //------------------ACTUALIACIÓN DE FECHA
                            _Str_Cadena = "Update TNOTADEBITOCP set cfechand='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "' where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text.Trim() + "'";
                            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
                            //------------------
                            //NUevo
                            DataRow _Row = _Ds2.Tables[0].Rows[0];
                            string _Str_Sql = "Select cdatevencimiento from TRECEPCIONDFM where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cnfacturapro='" + _Row[3].ToString().Trim() + "' and cproveedor='" + _Row[4].ToString().Trim() + "'";
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows.Count > 0)
                            {
                                _Row = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql).Tables[0].Rows[0];
                                if (_Row[0] != System.DBNull.Value)
                                {
                                    Program._MyClsCnn._mtd_conexion._Mtd_modificar("TNOTADEBITOCP", "cfvfnotadebitop='" + new clslibraryconssa._Cls_Formato("es-VE")._Mtd_fecha(Convert.ToDateTime(_Row[0].ToString().Trim())) + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text + "' and cproveedor='" + _Txt_DesProveedor.Tag.ToString() + "'");
                                }
                                else
                                {
                                    Program._MyClsCnn._mtd_conexion._Mtd_modificar("TNOTADEBITOCP", "cfvfnotadebitop=CONVERT(DATETIME,CONVERT(VARCHAR,cfechand,103)),cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text + "' and cproveedor='" + _Txt_DesProveedor.Tag.ToString() + "'");
                                }
                            }
                            else
                            {
                                Program._MyClsCnn._mtd_conexion._Mtd_modificar("TNOTADEBITOCP", "cfvfnotadebitop=CONVERT(DATETIME,CONVERT(VARCHAR,cfechand,103)),cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text + "' and cproveedor='" + _Txt_DesProveedor.Tag.ToString() + "'");
                            }
                            //NUevo
                            _Txt_Clave.Text = "";
                            _Pnl_Clave.Visible = false;
                            Cursor = Cursors.WaitCursor;
                            REPORTESS _Frm;
                            //GIANQUI
                            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT * FROM TNOTADEBITOCPD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp='" + _Txt_Cod.Text + "' AND cproveedor='" + _Txt_DesProveedor.Tag.ToString() + "'");
                            if (_Ds.Tables[0].Rows.Count > 0)
                            {
                                //-----------
                                //_Frm = new REPORTESS(new string[] { "VST_REPORTENOTADEBITO" }, "", "T3.Report.rNotaDebito", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidnotadebitocxp='" + _Txt_Cod.Text + "' and cproveedor='" + _Txt_DesProveedor.Tag.ToString() + "'", _Print, true);
                                //-----------
                                //----------------------------------------------
                                Cursor = Cursors.WaitCursor;
                                _Str_Cadena = "SELECT c_nomb_fiscal, c_direcc_fiscal, c_rif, c_nit, cproducto, cnamef, ccajas, cmontosimp, cmontoinvendi, cbasegrabada, cbasexcenta, cimpuesto, cmontototal, cgroupcomp, ccompany, '" + _Str_PrefijoCorrel + "'+CONVERT(VARCHAR,cidnotadebitocxp) AS cidnotadebitocxp, cproveedor, cfvfnotadebitop, cdescripcion, calicuota, cunidades, c_telefono, cfechand, cdescfinanporc, cdescfinanmonto FROM VST_REPORTENOTADEBITO WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidnotadebitocxp='" + _Txt_Cod.Text + "' and cproveedor='" + _Txt_DesProveedor.Tag.ToString() + "'";
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                                Report.rNotaDebito _My_Reporte = new T3.Report.rNotaDebito();
                                _My_Reporte.SetDataSource(_Ds.Tables[0]);
                                //---Configuración de impresión.
                                var _PageSettings = new System.Drawing.Printing.PageSettings();
                                _PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
                                _PageSettings.Landscape = false;
                                var _PrtSettings = new System.Drawing.Printing.PrinterSettings { PrinterName = _Print.PrinterSettings.PrinterName, Copies = _Print.PrinterSettings.Copies, Collate = _Print.PrinterSettings.Collate };
                                _My_Reporte.PrintToPrinter(_PrtSettings, _PageSettings, false);
                                //---Configuración de impresión.
                                Cursor = Cursors.Default;
                                //----------------------------------------------
                            }
                            else
                            {
                                //-----------
                                //_Frm = new REPORTESS(new string[] { "VST_NOTADEBITO_SINDET" }, "", "T3.Report.rNotaDebitoSDet", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidnotadebitocxp='" + _Txt_Cod.Text + "' and cproveedor='" + _Txt_DesProveedor.Tag.ToString() + "'", _Print, true);
                                //-----------
                                //----------------------------------------------
                                Cursor = Cursors.WaitCursor;
                                _Str_Cadena = "SELECT c_nomb_fiscal, c_direcc_fiscal, c_rif, c_nit, cgroupcomp, ccompany, '" + _Str_PrefijoCorrel + "'+CONVERT(VARCHAR,cidnotadebitocxp) AS cidnotadebitocxp, cproveedor, cfvfnotadebitop, cdescripcion, cnumcontrolnd, cmontototsi, cimpuesto, ctotaldocu, cporcinvendible, cbasegrabada, cbaseexcenta, ctipodocument, cnumdocu, cfechand, cdescfinanporc, cdescfinanmonto FROM VST_NOTADEBITO_SINDET WHERE ccompany='" + Frm_Padre._Str_Comp + "' and cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and cidnotadebitocxp='" + _Txt_Cod.Text + "' and cproveedor='" + _Txt_DesProveedor.Tag.ToString() + "'";
                                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                                Report.rNotaDebitoSDet _My_Reporte = new T3.Report.rNotaDebitoSDet();
                                _My_Reporte.SetDataSource(_Ds.Tables[0]);
                                //---Configuración de impresión.
                                var _PageSettings = new System.Drawing.Printing.PageSettings();
                                _PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
                                _PageSettings.Landscape = false;
                                var _PrtSettings = new System.Drawing.Printing.PrinterSettings { PrinterName = _Print.PrinterSettings.PrinterName, Copies = _Print.PrinterSettings.Copies, Collate = _Print.PrinterSettings.Collate };
                                _My_Reporte.PrintToPrinter(_PrtSettings, _PageSettings, false);
                                //---Configuración de impresión.
                                Cursor = Cursors.Default;
                                //----------------------------------------------
                            }
                            //_________________________________
                            int _Int_Id_Comprobante = new int();
                            CLASES._Cls_Varios_Metodos _Cls_Proceso = new T3.CLASES._Cls_Varios_Metodos(true);
                            _Str_Cadena = "Select cidcomprob from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text.Trim() + "' and cproveedor='" + _Txt_DesProveedor.Tag.ToString() + "'";
                            if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                            {
                                if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim() == "0")
                                {
                                    if (_Mtd_MateriaPrima(Convert.ToString(_Txt_DesProveedor.Tag).Trim()))
                                    {
                                        if (_P_Str_TipoND.Trim().Length == 0)
                                        {
                                            if (_Ds2.Tables[0].Rows[0][2].ToString() == "1")
                                            {
                                                _Int_Id_Comprobante = _Cls_Proceso._Mtd_Proceso_P_CXP_ND_DIFPRECIO(_Txt_Cod.Text.Trim(), _Txt_DesProveedor.Tag.ToString());
                                                Program._MyClsCnn._mtd_conexion._Mtd_modificar("TNOTADEBITOCP", "cidcomprob='" + _Int_Id_Comprobante.ToString() + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text.Trim() + "' and cproveedor='" + _Txt_DesProveedor.Tag.ToString() + "'");
                                            }
                                            else
                                            {
                                                _Int_Id_Comprobante = _Cls_Proceso._Mtd_Proceso_P_CXP_ND_FALTANTE(_Txt_Cod.Text.Trim(), _Txt_DesProveedor.Tag.ToString());
                                                Program._MyClsCnn._mtd_conexion._Mtd_modificar("TNOTADEBITOCP", "cidcomprob='" + _Int_Id_Comprobante.ToString() + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text.Trim() + "' and cproveedor='" + _Txt_DesProveedor.Tag.ToString() + "'");
                                            }
                                        }
                                        else
                                        {
                                            _Int_Id_Comprobante = _Cls_Proceso._Mtd_Proceso_P_CXP_ND_MANUAL(_Txt_Cod.Text.Trim(), _Txt_DesProveedor.Tag.ToString(), _P_Str_TipoND, _Cmb_Tipo.Text.Trim(), _P_Str_CuentaOtros);
                                            Program._MyClsCnn._mtd_conexion._Mtd_modificar("TNOTADEBITOCP", "cidcomprob='" + _Int_Id_Comprobante.ToString() + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text.Trim() + "' and cproveedor='" + _Txt_DesProveedor.Tag.ToString() + "'");
                                        }
                                    }
                                    else
                                    {
                                        _Int_Id_Comprobante = _Cls_Proceso._Mtd_Proceso_P_CXP_ND_MANUAL(_Txt_Cod.Text.Trim(), _Txt_DesProveedor.Tag.ToString(), _P_Str_TipoND, _Cmb_Motivo.Text.Trim(), _P_Str_CuentaOtros);
                                        Program._MyClsCnn._mtd_conexion._Mtd_modificar("TNOTADEBITOCP", "cidcomprob='" + _Int_Id_Comprobante.ToString() + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text.Trim() + "' and cproveedor='" + _Txt_DesProveedor.Tag.ToString() + "'");
                                    }
                                }
                                else
                                {
                                    if (_P_Str_TipoND.Trim().Length == 0)
                                    { _Int_Id_Comprobante = Convert.ToInt32(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim()); }
                                    else
                                    {
                                        if (_Mtd_MateriaPrima(Convert.ToString(_Txt_DesProveedor.Tag).Trim()))
                                        {
                                            int _Int_ComprobExistente = Convert.ToInt32(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim());
                                            _Int_Id_Comprobante = _Cls_Proceso._Mtd_Proceso_P_CXP_ND_MANUAL(_Txt_Cod.Text.Trim(), _Txt_DesProveedor.Tag.ToString(), _P_Str_TipoND, _Cmb_Tipo.Text.Trim(), _Int_ComprobExistente, _P_Str_CuentaOtros);
                                        }
                                        else
                                        {
                                            int _Int_ComprobExistente = Convert.ToInt32(Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows[0][0].ToString().Trim());
                                            _Int_Id_Comprobante = _Cls_Proceso._Mtd_Proceso_P_CXP_ND_MANUAL(_Txt_Cod.Text.Trim(), _Txt_DesProveedor.Tag.ToString(), _P_Str_TipoND, _Cmb_Motivo.Text.Trim(), _Int_ComprobExistente, _P_Str_CuentaOtros);
                                        }
                                    }
                                }
                            }
                            if (MessageBox.Show("¿La impresión se ha realizado correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //_________________________________
                                MessageBox.Show("Se va a imprimir el comprobante contable.  Coloque el tipo de papel para este documento", "Requerimieno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _Frm = new REPORTESS(new string[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Int_Id_Comprobante.ToString() + "'", _Print, true);
                                //_Frm.MdiParent = this.MdiParent;
                                //_Frm.Show();
                                Cursor = Cursors.Default;
                                if (MessageBox.Show("¿La impresión se ha realizado correctamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                A:
                                    string _Str_Numero = InputBox.Show("Introduzca el número de control").Text;
                                    if (_Str_Numero.Trim().Length > 0)
                                    {
                                        _Str_Cadena = "Select * from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cnumcontrolnd='" + _Str_Numero + "'";
                                        if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                                        {
                                            if (MessageBox.Show("El número de control del documento ya fue registrado. ¿Desea intentarlo nuevamente?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                            {
                                                goto A;
                                            }
                                        }
                                        else
                                        {
                                            Program._MyClsCnn._mtd_conexion._Mtd_modificar("TCOMPROBANC", "cstatus='1',clvalidado='1',cvalidate='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "'", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _Int_Id_Comprobante.ToString() + "'");
                                            Program._MyClsCnn._mtd_conexion._Mtd_modificar("TNOTADEBITOCP", "cnumcontrolnd ='" + _Str_Numero + "',cidprocesomanual='" + _P_Str_TipoND + "',cimpresa='1',cactivo='1',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "'", "cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text + "' and cproveedor='" + _Txt_DesProveedor.Tag.ToString() + "'");
                                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                                            this.Close();
                                        }
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Verifique la información y vuelva a intentarlo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                //_Frm.Close();
                                GC.Collect();
                                goto _PrintG;
                            }
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            _Pnl_Clave.Visible = false;
                            _Txt_Clave.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("La ND ya fue impresa", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Pnl_Clave.Visible = false;
                        _Txt_Clave.Text = "";
                    }
                }
            }
            catch (Exception _Ex)
            { MessageBox.Show(_Ex.Message); Cursor = Cursors.Default; }
            Cursor = Cursors.Default;
        }
        private string _Mtd_CuentaProveedorServicio(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT TPROVEEDOR.ctcount from TPROVEEDOR INNER JOIN TCOUNT ON TPROVEEDOR.ctcount=TCOUNT.ccount AND TPROVEEDOR.ccompany=TCOUNT.ccompany WHERE TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _P_Str_Proveedor + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                { return _Ds.Tables[0].Rows[0][0].ToString(); }
            }
            return "";
        }
        private bool _Mtd_MateriaPrima(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT cglobal FROM TPROVEEDOR WHERE cproveedor='" + _P_Str_Proveedor + "' AND cglobal='1'";
            return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
        }
        private string _Mtd_ProcesoContable(string _P_Str_Proveedor)
        {
            string _Str_Cadena = "SELECT ccatproveedor,cglobal FROM TPROVEEDOR WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _P_Str_Proveedor + "' AND cglobal<>1";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            string _Str_CategProv = "";
            string _Str_TipoProv = "";
            string _Str_CatCompRel = "";
            string _Str_CatAccion = "";
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_CategProv = Convert.ToString(_Ds.Tables[0].Rows[0]["ccatproveedor"]);
                _Str_TipoProv = Convert.ToString(_Ds.Tables[0].Rows[0]["cglobal"]);
            }
            _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ccatproveciarel,ccatproveaccio FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_CatCompRel = Convert.ToString(_Ds.Tables[0].Rows[0]["ccatproveciarel"]);
                _Str_CatAccion = Convert.ToString(_Ds.Tables[0].Rows[0]["ccatproveaccio"]);
            }
            if (_Str_TipoProv.Trim() == "0")
            {
                if (CLASES._Cls_Varios_Metodos._Mtd_EsProveedorIC(_P_Str_Proveedor))
                    return "P_CxP_ND_CIA_RELAC";
                return "P_CxP_ND_SERVICIOS";
            }
            else if (_Str_TipoProv.Trim() == "2" & _Str_CategProv.Trim().ToUpper() == _Str_CatAccion.Trim().ToUpper())
            {
                return "P_CxP_ND_ACC";
            }
            else
            {
                if (CLASES._Cls_Varios_Metodos._Mtd_EsProveedorIC(_P_Str_Proveedor))
                    return "P_CxP_ND_CIA_RELAC";
                return "P_CxP_ND_P_OTROS";//Se le agrego una 'P' porque ya existe P_CxP_ND_OTROS y no es una cuenta de servicios y otros.
            }
            return "";
        }

        private void _Mtd_Aprobar()
        {
            string _Str_Sql = "SELECT cidnotadebitocxp FROM TNOTADEBITOCPTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxptemp='" + _Txt_Cod.Text + "' AND ISNULL(cidnotadebitocxp,0)>0";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                //Si da algún error se actualiza primero en cestatusfirma=2 para que no quede pendiente y se pueda resolver.
                _Str_Sql = "UPDATE TNOTADEBITOCPTEMP SET cestatusfirma=2,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxptemp='" + _Txt_Cod.Text + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Str_Sql = "UPDATE TNOTADEBITOCP SET cestatusfirma='2',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp='" + _Ds.Tables[0].Rows[0][0].ToString() + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            else
            {
                //Si da algún error se actualiza primero en cestatusfirma=2 para que no quede pendiente y se pueda resolver.
                string _Str_ID_ND = _myUtilidad._Mtd_Correlativo("SELECT MAX(cidnotadebitocxp) FROM TNOTADEBICC WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'");
                _Str_Sql = "UPDATE TNOTADEBITOCPTEMP SET cestatusfirma=2,cidnotadebitocxp='" + _Str_ID_ND + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxptemp='" + _Txt_Cod.Text + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                _Str_Sql = "INSERT INTO TNOTADEBITOCP (ccompany,cgroupcomp,cidnotadebitocxp,cnumcontrolnd,cproveedor,ctipodocument,cnumdocu,cfechand,cdescripcion,cmontototi,cimpuesto,ctotaldocu,cporcinvendible,cbasegrabada,cidnotrecepc,cidmotivo,cdateadd,cuseradd,calicuota,cbaseexcenta,cdescfinanporc,cdescfinanmonto,cdescfinanmontobexcenta,cdescfinanmontobgrabada,cdescontada,canulado,cidcomprob,cactivo,cimpresa,cdelete,cmanual,cestatusfirma,cdateupd,cuserupd) " +
                                             "SELECT ccompany,cgroupcomp," + _Str_ID_ND + ",cnumcontrolnd,cproveedor,ctipodocument,cnumdocu,cfechand,cdescripcion,cmontototi,cimpuesto,ctotaldocu,cporcinvendible,cbasegrabada,cidnotrecepc,cidmotivo,cdateadd,cuseradd,calicuota,cbaseexcenta,cdescfinanporc,cdescfinanmonto,cdescfinanmontobexcenta,cdescfinanmontobgrabada,0,0,0,0,0,0,1,2,cdateupd,cuserupd FROM TNOTADEBITOCPTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxptemp='" + _Txt_Cod.Text + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
            }
            if ((Frm_Padre)this.MdiParent != null)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
            }
            MessageBox.Show("Nota de débito aprobada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _Mtd_Ini();
            _Mtd_BotonesMenu();
            _Mtd_Actualizar();
            _Pnl_Clave.Visible = false;
            _Tb_Tab.SelectTab(0);
        }
        private void _Txt_Monto_Enter(object sender, EventArgs e)
        {
            if (_Str_MyProceso.Length > 0)
            {
                if (_Txt_Monto.Text.Trim().Length > 0)
                {
                    _Txt_Monto.Text = Convert.ToDouble(_Txt_Monto.Text).ToString("###0.00");
                }
            }
        }
        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            {
                _Tb_Tab.Enabled = false;
                _Mtd_CargarTipoND();
                if (_Int_Clave == 0)
                {
                    string _Str_Cadena = "select cmanual from TNOTADEBITOCP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "' and cidnotadebitocxp='" + _Txt_Cod.Text + "' and cproveedor='" + _Txt_DesProveedor.Tag.ToString() + "' AND cmanual='1'";
                    if (Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0)
                    {
                        _Txt_Clave.Text = "";
                        _Txt_Clave.Enabled = false;
                        if (_Mtd_MateriaPrima(Convert.ToString(_Txt_DesProveedor.Tag).Trim()))
                        {
                            _Cmb_Tipo.Enabled = true;
                            _Cmb_Tipo.Focus();
                        }
                        else
                        {
                            _Cmb_Tipo.Enabled = false;
                            _Txt_Clave.Enabled = true;
                            _Txt_Clave.Focus();
                        }

                    }
                    else
                    {
                        _Cmb_Tipo.Enabled = false;
                        _Txt_Clave.Text = "";
                        _Txt_Clave.Enabled = true;
                        _Txt_Clave.Focus();
                    }
                }
                else
                {
                    _Cmb_Tipo.Enabled = false;
                    _Txt_Clave.Text = "";
                    _Txt_Clave.Enabled = true;
                    _Txt_Clave.Focus();
                }
            }
            else
            {
                _Tb_Tab.Enabled = true; 
            }
        }
        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
            _Txt_Clave.Text = "";
        }
        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (_myUtilidad._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                if (_Int_Clave == 0)
                {
                    TextBox _Txt_Temp = new TextBox();
                    if (_Mtd_MateriaPrima(Convert.ToString(_Txt_DesProveedor.Tag).Trim()))
                    {
                        string _Str_Tipo = "";
                        if (_Cmb_Tipo.SelectedIndex == 0)
                        { _Str_Tipo = ""; }
                        else if (_Cmb_Tipo.SelectedIndex == 1)
                        { _Str_Tipo = "P_CXP_ND_ODCTOS"; }
                        else if (_Cmb_Tipo.SelectedIndex == 2)
                        { _Str_Tipo = "P_CXP_ND_DCTOPP"; }
                        else if (_Cmb_Tipo.SelectedIndex == 3)
                        { _Str_Tipo = "P_CXP_ND_DEVOLUCION"; }
                        else if (_Cmb_Tipo.SelectedIndex == 4)
                        { _Str_Tipo = "P_CXP_ND_FALTANTE"; }
                        else if (_Cmb_Tipo.SelectedIndex == 5)
                        {
                            _Str_Tipo = "P_CXP_ND_OTROS";
                            Frm_Busqueda2 _Frm = new Frm_Busqueda2(45, _Txt_Temp, 0, "");
                            _Frm.ShowDialog();
                        }
                        if (_Cmb_Tipo.SelectedIndex == 5 & _Txt_Temp.Text.Trim().Length == 0)
                        { MessageBox.Show("Debe elegir una cuenta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        else
                        { _Mtd_Imprimir(_Str_Tipo, _Txt_Temp.Text.Trim()); }
                        _Txt_Temp.Text = "";
                    }
                    else
                    {
                        string _Str_ProcesoContable = _Mtd_ProcesoContable(Convert.ToString(_Txt_DesProveedor.Tag).Trim());
                        if (_Str_ProcesoContable == "P_CxP_ND_SERVICIOS")
                        {
                            string _Str_CuentaProveedor = _Mtd_CuentaProveedorServicio(Convert.ToString(_Txt_DesProveedor.Tag).Trim());
                            if (_Str_CuentaProveedor.Trim().Length > 0)
                            {
                                _Mtd_Imprimir(_Str_ProcesoContable, _Str_CuentaProveedor);
                            }
                            else
                            { MessageBox.Show("No se obtuvo la cuenta del proveedor. Debe agregar la cuenta al proveedor seleccionado desde el módulo de proveedores.", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        }
                        else
                        {
                            Frm_Busqueda2 _Frm = new Frm_Busqueda2(45, _Txt_Temp, 0, "");
                            _Frm.ShowDialog();
                            if (_Txt_Temp.Text.Trim().Length == 0)
                            { MessageBox.Show("Debe elegir una cuenta", "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            else
                            { _Mtd_Imprimir(_Str_ProcesoContable, _Txt_Temp.Text.Trim()); }
                            _Txt_Temp.Text = "";
                        }
                    }

                }
                else if (_Int_Clave == 1)
                { _Mtd_Aprobar(); }
            }
            else
            {
                MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length);
            }
        }
        private void _Txt_Document_TextChanged(object sender, EventArgs e)
        {
            if (_Str_MyProceso.Length > 0)
            {
                if (_Cmb_Motivo.SelectedIndex > 0)
                {
                    if (_Rb_ConFact.Checked)
                    {
                        _Txt_Descripcion.Text = _Cmb_Motivo.Text.ToString().Trim() + " FACTURA# " + _Txt_Document.Text;
                    }
                    else
                    {
                        _Txt_Descripcion.Text = _Cmb_Motivo.Text.ToString().Trim();
                    }
                }
            }
        }
        private void _Bt_Detalle_Click(object sender, EventArgs e)
        {
            Frm_DetalleNcNd _Frm = new Frm_DetalleNcNd(_Txt_Cod.Text.Trim(), _Txt_Document.Text.Trim(), 1, _Txt_DesProveedor.Tag.ToString().Trim());
            _Frm.ShowDialog();
        }
        private void _Txt_Monto_Leave(object sender, EventArgs e)
        {
            if (_Str_MyProceso.Length > 0)
            {
                if (_Txt_Monto.Text.Trim() != "")
                {
                    _Txt_Monto.Text = Convert.ToDouble(_Txt_Monto.Text).ToString("#,##0.00");
                }
            }
        }
        private void _Dg_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                _Lbl_DgInfo.Visible = true;
            }
            else
            {
                _Lbl_DgInfo.Visible = false;
            }
        }
        private void _Cmb_Motivo_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_CargarMotivo();
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_Actualizar()
        {
            //___________________________________
            ToolStripMenuItem[] _Tsm_Menu = new ToolStripMenuItem[2];
            _Tsm_Menu[0] = new ToolStripMenuItem("Código");
            _Tsm_Menu[1] = new ToolStripMenuItem("Descripción");
            string[] _Str_Campos = new string[2];
            _Str_Campos[0] = "cidnotadebitocxp";
            _Str_Campos[1] = "cdescripcion";
            string _Str_Where = "";
            if (_Rb_Aplicada.Checked)
            { _Str_Where = _Str_Where + " AND cdescontada = '1'"; }
            else if (_Rb_NoAplicada.Checked)
            { _Str_Where = _Str_Where + " AND cdescontada = '0'"; }
            else
            { _Str_Where = " AND cestatusfirma = '9'"; }
            if (!_Rb_Rechazada.Checked)
            {
                if (!_Chk_FindAprob.Checked)
                { _Str_Where = _Str_Where + " AND cestatusfirma = '2'"; }
                else
                { _Str_Where = " AND cestatusfirma = '1'"; }
            }
            if (_Rb_Rechazada.Checked || (_Rb_NoAplicada.Checked && _Chk_FindAprob.Checked))
            {
                string _Str_FindSql = "Select top ?sel cidnotadebitocxptemp AS Código, cdescripcion AS Descripción,dbo.Fnc_Formatear(ctotaldocu) as Monto,'NO' AS Impresa FROM TNOTADEBITOCPTEMP WHERE NOT cidnotadebitocxptemp IN (select top ?omi cidnotadebitocxptemp FROM TNOTADEBITOCPTEMP WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'" + _Str_Where + ") AND cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'" + _Str_Where;
                _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_Campos, "", _Tsm_Menu, _Dg_Grid, "TNOTADEBITOCPTEMP", "WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'" + _Str_Where, 100, "ORDER BY cidnotadebitocxptemp");
            }
            else
            {
                string _Str_FindSql = "Select top ?sel cidnotadebitocxp AS Código, cdescripcion AS Descripción,dbo.Fnc_Formatear(ctotaldocu) as Monto,CASE WHEN cimpresa=1 THEN 'SI' ELSE 'NO' END AS Impresa FROM TNOTADEBITOCP WHERE NOT cidnotadebitocxp IN (select top ?omi cidnotadebitocxp FROM TNOTADEBITOCP WHERE (cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0 AND canulado=0 AND (cmanual='1' OR cidnotrecepc>0 OR (cmanual='0' AND cidnotrecepc='0' AND cidcomprob>0 AND (cdescontada='1' OR ISNULL(cnumcontrolnd,0)=0)))" + _Str_Where + ")) and cdelete=0 AND canulado=0 AND (cmanual='1' OR cidnotrecepc>0 OR (cmanual='0' AND cidnotrecepc='0' AND cidcomprob>0 AND (cdescontada='1' OR ISNULL(cnumcontrolnd,0)=0))) AND cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "'" + _Str_Where;
                _Ctrl_Busqueda1._Mtd_Inicializar(_Str_FindSql, _Str_Campos, "", _Tsm_Menu, _Dg_Grid, "TNOTADEBITOCP", "WHERE cgroupcomp = '" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cdelete=0 AND canulado=0 AND (cmanual='1' OR cidnotrecepc>0 OR (cmanual='0' AND cidnotrecepc='0' AND cidcomprob>0 AND (cdescontada='1' OR ISNULL(cnumcontrolnd,0)=0)))" + _Str_Where, 100, "ORDER BY cidnotadebitocxp");
            }
            //___________________________________
            _Dg_Grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private string _Mtd_ProxIdND()
        {
            string _Str_Sql = "SELECT MAX(cidnotadebitocxptemp) FROM TNOTADEBITOCPTEMP where cgroupcomp='" + Frm_Padre._Str_GroupComp + "' and ccompany='" + Frm_Padre._Str_Comp + "'";
            return _myUtilidad._Mtd_Correlativo(_Str_Sql);
        }
        private void _Mtd_CargarMotivo()
        {
            string _Str_Sql = "SELECT cidmotivo,RTRIM(cdescripcion) FROM TMOTIVO where cdocumentnd='1' or cmotivodev='1' OR cmotexcpago='1' ORDER BY cdescripcion ASC";
            _Cmb_Motivo.SelectedIndexChanged -= new System.EventHandler(_Cmb_Motivo_SelectedIndexChanged);
            _myUtilidad._Mtd_CargarCombo(_Cmb_Motivo, _Str_Sql);
            _Cmb_Motivo.SelectedIndexChanged += new System.EventHandler(_Cmb_Motivo_SelectedIndexChanged);
        }
        private void _Mtd_CargarTipoND()
        {
            System.Collections.ArrayList _myArrayList = new System.Collections.ArrayList();
            _Cmb_Tipo.DataSource = null;
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("...", "nulo"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Descuento", "1"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Descuento P/P", "2"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Devolución", "3"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Dif. En Compra", "4"));
            _myArrayList.Add(new T3.Clases._Cls_ArrayList("Otros", "5"));
            _Cmb_Tipo.DataSource = _myArrayList;
            _Cmb_Tipo.DisplayMember = "Display";
            _Cmb_Tipo.ValueMember = "Value";
            _Cmb_Tipo.SelectedValue = "nulo";
            _Cmb_Tipo.DataSource = _myArrayList;
            _Cmb_Tipo.SelectedIndex = 0;
        }
        private double _Mtd_Impuesto(double _P_Dbl_Monto)
        {
            string _Str_Sql = "SELECT TTAX.cpercent FROM TTAX INNER JOIN TCONFIGCOMP ON TTAX.ctax = TCONFIGCOMP.ctax WHERE (TCONFIGCOMP.ccompany = '" + Frm_Padre._Str_Comp + "')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    return (_P_Dbl_Monto * Convert.ToDouble(_Ds.Tables[0].Rows[0][0].ToString())) / 100;
                }
                else
                { return 0; }
            }
            else
            { return 0; }
        }
        public void _Mtd_Cancelar()
        {
            _Mtd_Bloquear(false);
        }
        public void _Mtd_Ini()
        {
            _Er_Error.Dispose();
            _Txt_Cod.Text = "";
            _Txt_Fecha.Text = "";
            _Txt_Control.Text = "";
            if (!_Bol_PMV)
            {
                _Txt_DesProveedor.Text = "";
                _Txt_DesProveedor.Tag = "";
            }
            //_Rb_ConFact.Checked = false;
            //_Rb_SinFact.Checked = false;
            _Rb_ConFact.Enabled = false;
            _Rb_ConFact.Checked = true;            
            _Txt_Document.Text = "";
            _Txt_Monto.Text = "";
            _Txt_Exento.Text = "";
            _Txt_Invendible.Text = "";
            _Txt_Impuesto.Text = "";
            _Txt_DescuentoFinanciero.Text = "";
            _Txt_Total.Text = "";
            _Txt_Descripcion.Text = "";
            _G_Bol_Edit = false;
            _Mtd_CargarMotivo();
            _Mtd_Bloquear(false);
            _Str_MyProceso = "";
        }
        private void _Mtd_Bloquear(bool _Pr_Bol_A)
        {
            _Txt_Cod.Enabled = false;
            _Txt_Fecha.Enabled = false;
            _Txt_Control.Enabled = false;
            _Txt_DesProveedor.Enabled = false;
            _Rb_ConFact.Enabled = false;
            _Bt_FindFactura.Enabled = false;
            _Rb_SinFact.Enabled = false;
            _Txt_Document.Enabled = false;
            _Txt_Monto.Enabled = false;
            _Txt_Exento.Enabled = false;
            _Txt_Invendible.Enabled = false;
            _Txt_Impuesto.Enabled = false;
            _Txt_DescuentoFinanciero.Enabled = false;
            _Txt_Total.Enabled = false;
            _Cmb_Motivo.Enabled = false;
            _Txt_Descripcion.Enabled = false;
            _Bt_Proveedor.Enabled = _Pr_Bol_A;
            _Bt_Imprimir.Enabled = false;
            _Bt_Detalle.Enabled = false;
        }
        public void _Mtd_Habilitar()
        {
            _Mtd_Bloquear(true);
            _Str_MyProceso = "M";
        }
        public void _Mtd_Nuevo()
        {
            _Mtd_Ini();
            _Txt_Fecha.Text = _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate());
            _Bt_Proveedor.Enabled = !_Bol_PMV;//true;
            if (_Bol_PMV)
            { _Cmb_Motivo.Enabled = true; _Cmb_Motivo.Focus(); }
            _Tb_Tab.SelectTab(1);
            _Str_MyProceso = "A";
        }
        private bool _Mtd_ValidaSave()
        {
            double _Dbl_Monto = 0, _Dbl_MontoTotal = 0, _Dbl_MontoNCant = 0, _Dbl_MontoFac = 0, _Dbl_Exento = 0, _Dbl_DescuentoFinanaciero = 0;
            bool _Bol_R = true;
            if (_Txt_DesProveedor.Text.Trim().Length == 0)
            {
                _Er_Error.SetError(_Txt_DesProveedor, "Información requerida.");
                _Bol_R = false;
            }
            if (_Txt_Cod.Text.Trim().Length == 0)
            {
                _Txt_Cod.Text = "0";
            }
            if (_Cmb_Motivo.SelectedIndex < 1)
            {
                _Er_Error.SetError(_Cmb_Motivo, "Información requerida.");
                _Bol_R = false;
            }
            if (!_Rb_ConFact.Checked && !_Rb_SinFact.Checked)
            {
                _Er_Error.SetError(_Rb_ConFact, "Información requerida.");
                _Er_Error.SetError(_Rb_SinFact, "Información requerida.");
                _Bol_R = false;
            }
            else if (_Rb_ConFact.Checked)
            {
                if (_Txt_Document.Text.Trim().Length == 0)
                {
                    _Er_Error.SetError(_Txt_Document, "Información requerida.");
                    _Bol_R = false;
                }
            }
            if (_Txt_Monto.Text.Trim().Length == 0)
            {
                _Dbl_Monto = 0;
            }
            else
            {
                _Dbl_Monto = Convert.ToDouble(_Txt_Monto.Text);
            }
            if (_Txt_Exento.Text.Trim().Length == 0)
            {
                _Dbl_Exento = 0;
            }
            else
            {
                _Dbl_Exento = Convert.ToDouble(_Txt_Exento.Text);
            }
            if (_Dbl_Monto + _Dbl_Exento == 0)
            {
                _Er_Error.SetError(_Txt_Monto, "Información requerida.");
                _Er_Error.SetError(_Txt_Exento, "Información requerida.");
                _Bol_R = false;
            }
            if (_Txt_DescuentoFinanciero.Text.Trim().Length == 0)
            {
                _Dbl_DescuentoFinanaciero = 0;
            }
            else
            {
                _Dbl_DescuentoFinanaciero = Convert.ToDouble(_Txt_DescuentoFinanciero.Text);
            }
            if (_Txt_Total.Text.Trim().Length == 0)
            {
                _Dbl_MontoTotal = 0;
            }
            else
            {
                _Dbl_MontoTotal = Convert.ToDouble(_Txt_Total.Text);
            }
            //________________________________________________________
            if (_Txt_Document.Text.Trim().Length > 0)
            {
                string _Str_TpoDocFact = "";
                string _Str_Cadena = "SELECT ctipdocfact FROM TCONFIGCXC WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_TpoDocFact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipdocfact"]).Trim();
                }
                _Str_Cadena = "SELECT SUM(cmontototsi) FROM TNOTADEBITOCPTEMP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ctipodocument='" + _Str_TpoDocFact + "' AND cnumdocu='" + _Txt_Document.Text + "' AND cidnotadebitocxptemp<>'" + _Txt_Cod.Text + "' AND cestatusfirma='1'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim().Length > 0)
                    {
                        _Dbl_MontoNCant = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                    }
                }
                _Str_Cadena = "SELECT SUM(cmontototsi) FROM TNOTADEBITOCP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ctipodocument='" + _Str_TpoDocFact + "' AND cnumdocu='" + _Txt_Document.Text + "' AND canulado=0 AND cdelete=0 AND cestatusfirma='2'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(_Ds.Tables[0].Rows[0][0]).Trim().Length > 0)
                    {
                        _Dbl_MontoNCant += Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                    }
                }
                _Str_Cadena = "SELECT ctotalsimp + ISNULL(ctotmontexcento,0) FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ctipodocument='" + _Str_TpoDocFact + "' AND cactivo=1 AND canulado=0 AND cordenpaghecha=0 AND cproveedor='" + _Txt_DesProveedor.Tag.ToString() + "' AND cnumdocu='" + _Txt_Document.Text + "'";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        _Dbl_MontoFac = Convert.ToDouble(_Ds.Tables[0].Rows[0][0]);
                    }
                }
                if ((_Dbl_MontoNCant + (_Dbl_Monto + _Dbl_Exento)) > _Dbl_MontoFac)
                {
                    _Er_Error.SetError(_Txt_Monto, "Información requerida.");
                    _Er_Error.SetError(_Txt_Exento, "Información requerida.");
                    _Bol_R = false;
                }
            }
            //________________________________________________________
            if (_Txt_Descripcion.Text.Trim().Length == 0)
            {
                _Er_Error.SetError(_Txt_Descripcion, "Información requerida.");
                _Bol_R = false;
            }
            return _Bol_R;
        }
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            bool _Bol_R = false;
            string _Str_Sql = "";
            if (_Str_MyProceso == "A")
            {
                if (_Mtd_ValidaSave())
                {
                    string _Str_TpoDocFact = "";
                    string _Str_TpoDoc = "null";
                    string _Str_NumDocu = "null";
                    double _Dbl_MontoSimp = 0;
                    double _Dbl_MontoExento = 0;
                    double _Dbl_MontoTotal = 0;
                    double _Dbl_MontoImp = 0;
                    double _Ddl_Invendible = 0;
                    double _Dbl_BaseGrabada = 0;
                    double _Dbl_DescFinan_Porcentaje = 0;
                    double _Dbl_DescFinan_MontoTotal = 0;
                    double _Dbl_DescFinan_MontoBExcenta = 0;
                    double _Dbl_DescFinan_MontoBGrabada = 0;
                    try
                    {
                        _Str_Sql = "SELECT ctipodocumentfact FROM TCONFIGCOMP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                        DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds.Tables[0].Rows.Count>0)
                        {
                            _Str_TpoDocFact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocumentfact"]).Trim();
                        }
                        if (_Rb_ConFact.Checked)
                        {
                            _Str_TpoDoc = "'" + _Str_TpoDocFact + "'";
                            _Str_NumDocu = "'" + _Txt_Document.Text + "'";
                        }
                        _Dbl_MontoSimp = Convert.ToDouble(_Txt_Monto.Text);
                        _Dbl_MontoExento = Convert.ToDouble(_Txt_Exento.Text);
                        if (_Txt_Impuesto.Text.Trim().Length > 0)
                        {
                            _Dbl_MontoImp = Convert.ToDouble(_Txt_Impuesto.Text);
                        }
                        _Dbl_MontoTotal = Convert.ToDouble(_Txt_Total.Text);
                        if (_Txt_Invendible.Text.Trim().Length > 0)
                        {
                            _Ddl_Invendible = Convert.ToDouble(_Txt_Invendible.Text);
                        }
                        _Dbl_BaseGrabada = _Dbl_MontoSimp + _Ddl_Invendible;
                        //-----------------------------------------------------------
                        if (_Chk_AplicaDescuentoFinanciero.Checked)
                        {
                            _Dbl_DescFinan_Porcentaje = _myUtilidad._Mtd_MontoPorcentajeDescuentoFinanciero(Frm_Padre._Str_GroupComp, _Txt_DesProveedor.Tag.ToString(), _Txt_Document.Text);
                            _Dbl_DescFinan_MontoBExcenta = Convert.ToDouble(_G_Dcm_DescFinanBExcenta);
                            _Dbl_DescFinan_MontoBGrabada = Convert.ToDouble(_G_Dcm_DescFinanBGrabada);
                            _Dbl_DescFinan_MontoTotal = Convert.ToDouble(_Txt_DescuentoFinanciero.Text);
                        }
                        //-----------------------------------------------------------
                        _Txt_Cod.Text = _Mtd_ProxIdND();
                        _Str_Sql = "INSERT INTO TNOTADEBITOCPTEMP (ccompany,cgroupcomp,cidnotadebitocxptemp,cnumcontrolnd,cproveedor,ctipodocument,cnumdocu,cfechand,cdescripcion,cmontototsi,cimpuesto,ctotaldocu,cporcinvendible,cbasegrabada,cidnotrecepc,cidmotivo,cdateadd,cuseradd,cestatusfirma,calicuota,cbaseexcenta,cdescfinanporc,cdescfinanmonto,cdescfinanmontobexcenta,cdescfinanmontobgrabada) VALUES('" +
                        Frm_Padre._Str_Comp + "','" + Frm_Padre._Str_GroupComp + "','" + _Txt_Cod.Text + "',0,'" + _Txt_DesProveedor.Tag.ToString() + "'," + _Str_TpoDoc + "," + _Str_NumDocu + ",'" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()) + "','" + _Txt_Descripcion.Text.Trim().ToUpper() + "'," + _Dbl_MontoSimp.ToString().Replace(",", ".") + "," + _Dbl_MontoImp.ToString().Replace(",", ".") + "," + _Dbl_MontoTotal.ToString().Replace(",", ".") + "," + _Ddl_Invendible.ToString().Replace(",", ".") + "," + _Dbl_BaseGrabada.ToString().Replace(",", ".") + ",0,'" + _Cmb_Motivo.SelectedValue.ToString() + "','" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "','" + Frm_Padre._Str_Use + "',1,'" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Document.Tag)) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoExento) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_DescFinan_Porcentaje) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_DescFinan_MontoTotal) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_DescFinan_MontoBExcenta) + "','" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_DescFinan_MontoBGrabada) + "')";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        if (_Bol_PMV)
                        {
                            _Mtd_ActualizarInformacionPMV(_Str_NR_Dif_Pmv, _Txt_Cod.Text);
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)this.MdiParent)._Frm_Contenedor._async_Default);
                            MessageBox.Show("Se guardó correctamente la transacción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Se guardó correctamente la transacción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _G_Bol_Edit = false;
                            _Mtd_Ini();
                            _Bol_R = true;
                            _Mtd_Actualizar();
                            _Tb_Tab.SelectTab(0);
                        }
                    }
                    catch
                    {
                        _Bol_R = false;
                        MessageBox.Show("Problemas al guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            return _Bol_R;
        }
        public bool _Mtd_Editar()
        {
            bool _Bol_R = false;
            string _Str_Sql = "";
            if (_Str_MyProceso == "M")
            {
                if (_Mtd_ValidaSave())
                {
                    string _Str_TpoDocFact = "";
                    string _Str_TpoDoc = "null";
                    string _Str_NumDocu = "null";
                    double _Dbl_MontoSimp = 0;
                    double _Dbl_MontoExento = 0;
                    double _Dbl_MontoTotal = 0;
                    double _Dbl_MontoImp = 0;
                    double _Ddl_Invendible = 0;
                    double _Dbl_BaseGrabada = 0;
                    double _Dbl_DescFinan_Porcentaje = 0;
                    double _Dbl_DescFinan_MontoTotal = 0;
                    double _Dbl_DescFinan_MontoBExcenta = 0;
                    double _Dbl_DescFinan_MontoBGrabada = 0;
                    try
                    {
                        _Str_Sql = "SELECT ctipodocumentfact FROM TCONFIGCOMP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
                        DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                        if (_Ds.Tables[0].Rows.Count > 0)
                        {
                            _Str_TpoDocFact = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocumentfact"]).Trim();
                        }
                        if (_Rb_ConFact.Checked)
                        {
                            _Str_TpoDoc = "'" + _Str_TpoDocFact + "'";
                            _Str_NumDocu = "'" + _Txt_Document.Text + "'";
                        }
                        _Dbl_MontoSimp = Convert.ToDouble(_Txt_Monto.Text);
                        _Dbl_MontoExento = Convert.ToDouble(_Txt_Exento.Text);
                        if (_Txt_Impuesto.Text.Trim().Length > 0)
                        {
                            _Dbl_MontoImp = Convert.ToDouble(_Txt_Impuesto.Text);
                        }
                        _Dbl_MontoTotal = Convert.ToDouble(_Txt_Total.Text);
                        if (_Txt_Invendible.Text.Trim().Length > 0)
                        {
                            _Ddl_Invendible = Convert.ToDouble(_Txt_Invendible.Text);
                        }
                        _Dbl_BaseGrabada = _Dbl_MontoSimp + _Ddl_Invendible;
                        //-----------------------------------------------------------
                        if (_Chk_AplicaDescuentoFinanciero.Checked)
                        {
                            _Dbl_DescFinan_Porcentaje = _myUtilidad._Mtd_MontoPorcentajeDescuentoFinanciero(Frm_Padre._Str_GroupComp, _Txt_DesProveedor.Tag.ToString(), _Txt_Document.Text);
                            _Dbl_DescFinan_MontoBExcenta = Convert.ToDouble(_G_Dcm_DescFinanBExcenta);
                            _Dbl_DescFinan_MontoBGrabada = Convert.ToDouble(_G_Dcm_DescFinanBGrabada);
                            _Dbl_DescFinan_MontoTotal = Convert.ToDouble(_Txt_DescuentoFinanciero.Text);
                        }
                        _Str_Sql = "UPDATE TNOTADEBITOCPTEMP SET ctipodocument=" + _Str_TpoDoc + ",cnumdocu=" + _Str_NumDocu + ",cdescripcion='" + _Txt_Descripcion.Text + "',cmontototsi=" + _Dbl_MontoSimp.ToString().Replace(",", ".") + ",cimpuesto=" + _Dbl_MontoImp.ToString().Replace(",", ".") + ",ctotaldocu=" + _Dbl_MontoTotal.ToString().Replace(",", ".") + ",cporcinvendible=" + _Ddl_Invendible.ToString().Replace(",", ".") + ",cbasegrabada=" + _Dbl_BaseGrabada.ToString().Replace(",", ".") + ",cidmotivo='" + _Cmb_Motivo.SelectedValue.ToString() + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "',calicuota='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Document.Tag)) + "',cbaseexcenta='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_MontoExento) + "' " +
                        ",cdescfinanmonto='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_DescFinan_MontoTotal) + "' " +
                        ",cdescfinanmontobexcenta='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_DescFinan_MontoBExcenta) + "' " +
                        ",cdescfinanmontobgrabada='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_DescFinan_MontoBGrabada) + "' " +
                        "WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidnotadebitocxptemp='" + _Txt_Cod.Text + "'";
                        Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                        MessageBox.Show("Se guardó correctamente la transacción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _G_Bol_Edit = false;
                        _Mtd_Ini();
                        _Bol_R = true;
                        _Mtd_Actualizar();
                        _Tb_Tab.SelectTab(0);
                    }
                    catch
                    {
                        _Bol_R = false;
                        MessageBox.Show("Problemas al guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            return _Bol_R;
        }
        //public bool _Mtd_Eliminar()
        //{
        //    bool _Bol_R = false;
        //    string _Str_Sql = "";
        //    string _Str_TpoDocND = "";
        //    if (MessageBox.Show("Está seguro de Eliminar esta ND?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        _Str_Sql = "SELECT ctipodocnd FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
        //        DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
        //        if (_Ds.Tables[0].Rows.Count > 0)
        //        {
        //            _Str_TpoDocND = Convert.ToString(_Ds.Tables[0].Rows[0]["ctipodocnd"]).Trim();
        //        }
        //        _Str_Sql = "SELECT cidfactxp FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ctipodocument='" + _Str_TpoDocND + "' AND cnumdocu='" + _Txt_Cod.Text + "' AND cordenpaghecha=0";
        //        if (Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql))
        //        {
        //            _Str_Sql = "DELETE FROM TFACTPPAGARM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ctipodocument='" + _Str_TpoDocND + "' AND cnumdocu='" + _Txt_Cod.Text + "'";
        //            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
        //            _Str_Sql = "DELETE FROM TMOVCXPM WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND ctipodocument='" + _Str_TpoDocND + "' AND cnumdocu='" + _Txt_Cod.Text + "'";
        //            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
        //            _Str_Sql = "UPDATE TNOTADEBITOCP SET cdelete=1,cdatedel='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserdel='" + Frm_Padre._Str_Use + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND cidnotadebitocxp='" + _Txt_Cod.Text + "'";
        //            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
        //            MessageBox.Show("Transacción eliminada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            _Mtd_Ini();
        //            _Mtd_Actualizar();
        //            _Tb_Tab.SelectedIndex = 0;
        //            _Bol_R = true;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Esta ND esta en proceso en cuentas por pagar. No se puede eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            _Bol_R = false;
        //        }
        //    }
        //    return _Bol_R;
        //}
        public void _Mtd_BotonesMenu()
        {
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            CONTROLES._Ctrl_Buscar._Tb_Tab = _Tb_Tab;
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            if (_Str_MyProceso == "A")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = false;
                if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ND_CXP"))
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                }
                else
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                }
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            if (_Str_MyProceso == "M")
            {
                CONTROLES._Ctrl_Buscar._Bl_Modifi = true;
                if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ND_CXP"))
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                }
                else
                {
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                }
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
            }
            if (_Str_MyProceso == "")
            {
                if (_Txt_Cod.Text.Trim().Length > 0 && _Bt_Proveedor.Enabled)
                {
                    if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ND_CXP"))
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    }
                    else
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    }
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ND_CXP"))
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true;
                    }
                    else
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    }
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                }
                else if (_Txt_Cod.Text.Trim().Length > 0 && !_Bt_Proveedor.Enabled)
                {
                    if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ND_CXP"))
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    }
                    else
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    }
                    if (_Rb_NoAplicada.Checked & _Chk_FindAprob.Checked)
                    { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = _G_Bol_Edit; }
                    else
                    { ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false; }
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
                }
                else if (_Txt_Cod.Text.Trim().Length == 0 && !_Bt_Proveedor.Enabled)
                {
                    if (_myUtilidad._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_ND_CXP"))
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = true;
                    }
                    else
                    {
                        ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = false;
                    }
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_editar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_borrar2.Enabled = false;
                    ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
                }
            }
        }
        //private bool _Mtd_NdImpresa(string _Pr_Str_IdNd)
        //{
        //    string _Str_Sql = "SELECT cidnotadebitocxp FROM TNOTADEBITOCP WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotadebitocxp='" + _Txt_Cod.Text + "' AND cimpresa=1";
        //    return Program._MyClsCnn._mtd_conexion._Mtd_ExistenRegistros(_Str_Sql);
        //}
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_Dg_Grid.Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_Ini();
                if (_Rb_Rechazada.Checked || (_Rb_NoAplicada.Checked && _Chk_FindAprob.Checked))
                    _Mtd_CargarDataTemp(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex));
                _Mtd_CargarData(_Ctrl_Busqueda1._Mtd_RetornarStringCelda(0, e.RowIndex));
                _Mtd_BotonesMenu();
                _Tb_Tab.SelectTab(1);
                Cursor = Cursors.Default;
            }
        }
        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex != 0)
            {
                if (!_Bt_Proveedor.Enabled & _Txt_Cod.Text.Trim().Length == 0)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = _Bol_PMV;
            }
        }
        private void _Bt_FindFactura_Click(object sender, EventArgs e)
        {
            double _Dbl_Monto = 0;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(40, " AND cproveedor='" + _Txt_DesProveedor.Tag.ToString() + "'");
            _Frm.ShowDialog();
            if (_Frm._Str_FrmResult == "1")
            {
                _Er_Error.Dispose();
                _Dbl_Monto = Convert.ToDouble(_Frm._Dg_Grid[1, _Frm._Dg_Grid.CurrentCell.RowIndex].Value);
                _Txt_Document.Text = _Frm._Dg_Grid[0, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString();
                if (_Frm._Dg_Grid[2, _Frm._Dg_Grid.CurrentCell.RowIndex].Value == null)
                { _Txt_Document.Tag = 0; }
                else if (_Frm._Dg_Grid[2, _Frm._Dg_Grid.CurrentCell.RowIndex].Value.ToString().Trim().Length == 0)
                { _Txt_Document.Tag = 0; }
                else
                { _Txt_Document.Tag = _Frm._Dg_Grid[2, _Frm._Dg_Grid.CurrentCell.RowIndex].Value; }
                var _Dcm_PorcentajeDescuentoFinanciero = Convert.ToDecimal(_myUtilidad._Mtd_MontoPorcentajeDescuentoFinanciero(Frm_Padre._Str_GroupComp, _Txt_DesProveedor.Tag.ToString(), _Txt_Document.Text));
                _Chk_AplicaDescuentoFinanciero.Enabled = Math.Round(_Dcm_PorcentajeDescuentoFinanciero) != 0;
                _Chk_AplicaDescuentoFinanciero.Checked = _Chk_AplicaDescuentoFinanciero.Enabled;
                _Txt_Monto.Enabled = true;
                _Txt_Exento.Enabled = true;
                _Txt_Monto.Focus();
            }
            _Frm.Dispose();
        }
        private bool _Mtd_Exhibicion()
        {
            if (_Cmb_Motivo.SelectedIndex > 0)
            {
                string _Str_Cadena = "SELECT cidmotivo FROM TMOTIVO WHERE (cdocumentnd='1' OR cmotivodev='1') AND cidmotivo='" + Convert.ToString(_Cmb_Motivo.SelectedValue).Trim() + "' AND cexhibicion='1'";
                return Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena).Tables[0].Rows.Count > 0;
            }
            return false;
        }
        private void _Txt_Monto_TextChanged(object sender, EventArgs e)
        {
            if (_Str_MyProceso.Length > 0)
            {
                _Mtd_CalcularMontos();
            }
        }
        private decimal _Mtd_Porcentaje()
        {
            if (_Chk_Impuesto.Checked)
            {
                try
                {
                    if (Convert.ToString(_Txt_Document.Tag).Trim().Length > 0)
                    {
                        if (Convert.ToDouble(_Txt_Document.Tag) > 0)
                        {
                            return Convert.ToDecimal(_Txt_Document.Tag);
                        }
                    }
                    string _Str_Cadena = "SELECT TTAX.cpercent FROM TTAX INNER JOIN TCONFIGCOMP ON TTAX.ctax = TCONFIGCOMP.ctax WHERE (TCONFIGCOMP.ccompany = '" + Frm_Padre._Str_Comp + "')";
                    DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    return Convert.ToDecimal(_Ds.Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            return 0;
        }
        private void _Rb_Aplicada_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Aplicada.Checked)
            {
                _Chk_FindAprob.CheckedChanged -= new EventHandler(_Chk_FindAprob_CheckedChanged);
                _Chk_FindAprob.Checked = false;
                _Chk_FindAprob.CheckedChanged += new EventHandler(_Chk_FindAprob_CheckedChanged);
                _Chk_FindAprob.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                _Mtd_Actualizar();
                this.Cursor = Cursors.Default;
            }
        }

        private void _Rb_NoAplicada_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_NoAplicada.Checked)
            {
                _Chk_FindAprob.CheckedChanged -= new EventHandler(_Chk_FindAprob_CheckedChanged);
                _Chk_FindAprob.Checked = false;
                _Chk_FindAprob.CheckedChanged += new EventHandler(_Chk_FindAprob_CheckedChanged);
                _Chk_FindAprob.Enabled = true;
                this.Cursor = Cursors.WaitCursor;
                _Mtd_Actualizar();
                this.Cursor = Cursors.Default;
            }
        }

        private void _Chk_FindAprob_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _Mtd_Actualizar();
            this.Cursor = Cursors.Default;
        }

        private void _Bt_Firmar_Click(object sender, EventArgs e)
        {
            _Int_Clave = 1;
            _Pnl_Clave.Visible = true;
            _Txt_Clave.Focus();
        }

        private void _Bt_Proveedor_EnabledChanged(object sender, EventArgs e)
        {
            //_Bt_Descrip.Enabled = _Bt_Proveedor.Enabled;
        }

        private void _Bt_Descrip_Click(object sender, EventArgs e)
        {
            if (_Txt_Descripcion.Enabled) { _Txt_Descripcion.Enabled = false; } else { _Txt_Descripcion.Enabled = true; }
        }

        private void _Cmb_Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Tipo.SelectedIndex > 0)
            { _Txt_Clave.Enabled = true; _Txt_Clave.Focus(); }
            else
            { _Txt_Clave.Text = ""; _Txt_Clave.Enabled = false; }
        }

        private void _Bt_FindFactura_EnabledChanged(object sender, EventArgs e)
        {
            _Chk_Impuesto.Enabled = _Bt_FindFactura.Enabled;
            _Chk_AplicaDescuentoFinanciero.Enabled = _Bt_FindFactura.Enabled;
        }
        private void _Mtd_ActualizarCampos()
        {
            //Solo si estamos agregando o modificando
            if (_Str_MyProceso == "A" || _Str_MyProceso == "M")
            {
                if (_Chk_Impuesto.Checked)
                {
                    _Txt_Monto.Enabled = true;
                }
                else
                {
                    //Si se deselecciona, se limpia el campo de base imponible
                    _Txt_Monto.Text = Convert.ToDouble(0).ToString("#,##0.00");
                    _Txt_Monto.Enabled = false;
                }
            }
        }
        private void _Mtd_CalcularMontos()
        {
            decimal _Dcm_MontoSimp = 0;
            decimal _Dcm_MontoExento = 0;
            string _Str_Sql = "Select cporcinvendible from TPROVEEDOR WHERE cproveedor='" + _Txt_DesProveedor.Tag.ToString() + "' and cdelete='0' AND cglobal=1";
            decimal _Dcm_Invendible = 0;
            decimal _Dcm_PorcentajeDescuentoFinanciero = 0;
            decimal _Dcm_DescFinanTotal = 0;
            decimal _Dcm_DescFinanBExcenta = 0;
            decimal _Dcm_DescFinanBGrabada = 0;
            decimal _Dcm_DescFinanImp = 0;
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    _Dcm_Invendible = Convert.ToDecimal(_Ds.Tables[0].Rows[0][0]);
                }
            }
            //-----------------------------
            if (_Txt_Monto.Text.Trim().Length > 0)
            {
                _Dcm_MontoSimp = Convert.ToDecimal(_Txt_Monto.Text);
            }
            if (_Txt_Exento.Text.Trim().Length > 0)
            {
                _Dcm_MontoExento = Convert.ToDecimal(_Txt_Exento.Text);
            }
            _Dcm_Invendible = ((_Dcm_MontoSimp * _Dcm_Invendible) / 100);
            //-----------------------------
            if (_Mtd_Exhibicion())
            { _Dcm_Invendible = 0; }
            //-----------------------------
            _Txt_Invendible.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double) _Dcm_Invendible, 2).ToString("#,##0.00");
            //-----------------------------
            decimal _Dbl_D1 = _Mtd_Porcentaje();
            decimal _Dbl_D2 = ((_Dcm_MontoSimp - _Dcm_Invendible) * _Dbl_D1) / 100;
            //-----------------------------
            if (_Chk_AplicaDescuentoFinanciero.Checked)
            {
                _Dcm_PorcentajeDescuentoFinanciero =  Convert.ToDecimal(_myUtilidad._Mtd_MontoPorcentajeDescuentoFinanciero(Frm_Padre._Str_GroupComp, _Txt_DesProveedor.Tag.ToString(), _Txt_Document.Text));
                _Dcm_DescFinanBExcenta = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)((_Dcm_MontoExento) * (_Dcm_PorcentajeDescuentoFinanciero / 100)), 2));
                _Dcm_DescFinanBGrabada = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)((_Dcm_MontoSimp) * (_Dcm_PorcentajeDescuentoFinanciero / 100)), 2));
                _Dcm_DescFinanTotal = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)(_Dcm_DescFinanBExcenta + _Dcm_DescFinanBGrabada), 2));
                _Dcm_DescFinanImp = Convert.ToDecimal(CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)(((_Dcm_MontoSimp * _Dcm_PorcentajeDescuentoFinanciero / 100) * _Dbl_D1) / 100), 2));
                //Paso a las variables Globales
                _G_Dcm_DescFinanBExcenta = _Dcm_DescFinanBExcenta;
                _G_Dcm_DescFinanBGrabada = _Dcm_DescFinanBGrabada;
            }
            //-----------------------------
            _Txt_Impuesto.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)(_Dbl_D2 - _Dcm_DescFinanImp), 2).ToString("#,##0.00");
            _Txt_Total.Text = Convert.ToString(((CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)_Dcm_MontoSimp, 2)
                            + CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)_Dcm_MontoExento, 2))
                            - CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)_Dcm_Invendible, 2))
                            - CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)_Dcm_DescFinanTotal, 2)
                            + CLASES._Cls_Varios_Metodos._Mtd_MontoTruncado((double)(_Dbl_D2 - _Dcm_DescFinanImp), 2));
            _Txt_Total.Text = Convert.ToDouble(_Txt_Total.Text).ToString("#,##0.00");
            _Txt_DescuentoFinanciero.Text = _Dcm_DescFinanTotal.ToString("#,##0.00");
        }


        private void _Chk_Impuesto_CheckedChanged(object sender, EventArgs e)
        {
            _Mtd_ActualizarCampos();
            _Mtd_CalcularMontos();
        }

        private void _Rb_Rechazada_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Rechazada.Checked)
            {
                _Chk_FindAprob.CheckedChanged -= new EventHandler(_Chk_FindAprob_CheckedChanged);
                _Chk_FindAprob.Checked = false;
                _Chk_FindAprob.CheckedChanged += new EventHandler(_Chk_FindAprob_CheckedChanged);
                _Chk_FindAprob.Enabled = false;
                _Mtd_Actualizar();
            }
        }

        private void _Cmb_Motivo_EnabledChanged(object sender, EventArgs e)
        {
            _Bt_Descrip.Enabled = _Cmb_Motivo.Enabled;
        }

        private void _Txt_Exento_Enter(object sender, EventArgs e)
        {
            if (_Str_MyProceso.Length > 0)
            {
                if (_Txt_Exento.Text.Trim().Length > 0)
                {
                    _Txt_Exento.Text = Convert.ToDouble(_Txt_Exento.Text).ToString("###0.00");
                }
            }
        }

        private void _Txt_Exento_KeyPress(object sender, KeyPressEventArgs e)
        {
            _myUtilidad._Mtd_Valida_Numeros(_Txt_Exento, e, 10, 2);
        }

        private void _Txt_Exento_Leave(object sender, EventArgs e)
        {
            if (_Str_MyProceso.Length > 0)
            {
                if (_Txt_Exento.Text.Trim() != "")
                {
                    _Txt_Exento.Text = Convert.ToDouble(_Txt_Exento.Text).ToString("#,##0.00");
                }
            }
        }

        private void _Txt_Exento_TextChanged(object sender, EventArgs e)
        {
            if (_Str_MyProceso.Length > 0)
            {
               _Mtd_CalcularMontos();
            }
        }
        private void _Mtd_ActualizarInformacionPMV(string _P_Str_NR, string _P_Str_ND)
        {
            string _Str_Cadena = "UPDATE TPMVNOTIFICADORM SET cidnotadebitocxp='" + _P_Str_ND + "',cndgenerado='1' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidnotrecepc='" + _P_Str_NR + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }

        private void _Chk_AplicaDescuentoFinanciero_CheckedChanged(object sender, EventArgs e)
        {
            _Mtd_CalcularMontos();
        }
    }
}