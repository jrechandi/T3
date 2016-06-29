using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T3
{
    public partial class Frm_ReposicionCxP_Aprobacion : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        private Decimal _G_Dec_MontoAReponer = 0;
        public Frm_ReposicionCxP_Aprobacion()
        {
            InitializeComponent();
        }
        int _Int_Reposicion = 0;
        string _Str_TipoReposicion = "";
        string _Str_TipoRep = "";
        public Frm_ReposicionCxP_Aprobacion(int _P_Int_Reposicion, string _P_Str_TipoReposicion, decimal _P_Dec_MontoAReponer)
        {
            InitializeComponent();
            _Int_Reposicion = _P_Int_Reposicion;
            _Str_TipoRep = _P_Str_TipoReposicion;
            if (_P_Str_TipoReposicion.Trim() == "G")
            { _Str_TipoReposicion = "REPOSICIÓN DE GASTOS"; }
            else
            { _Str_TipoReposicion = "REPOSICIÓN DE CAJA CHICA"; }
            _Mtd_CargarBanco();
            //En funcion al tipo de reposición
            _G_Dec_MontoAReponer = _P_Dec_MontoAReponer;
            _G_Dec_MontoAReponer = Math.Round(_G_Dec_MontoAReponer, 2);
            //-----
            _Txt_NumeroDocumento.Text = "";
            _Dtp_FechaDocumento.Value = DateTime.Now.Date;
            //----
            if (_G_Dec_MontoAReponer > 0)
            {
                //Positivo -> Orden de Pago
                _Pnl_Superior.Height = 203;
                _Rb_Cheque.Visible = true;
                _Rb_Transferencia.Visible = true;
                _Lbl_Banco.Visible = true;
                _Cmb_Banco.Visible = true;
                _Lbl_Cuenta.Visible = true;
                _Cmb_Cuenta.Visible = true;
                _Lbl_Concepto.Visible = true;
                _Txt_Concepto.Visible = true;
                _Lbl_NumeroDocumento.Visible = false;
                _Lbl_FechaDocumento.Visible = false;
                _Txt_NumeroDocumento.Visible = false;
                _Dtp_FechaDocumento.Visible = false;
                _Lbl_FormaDeReposicion.Visible = true;
                _Lbl_FormaDeReposicion.Text = "Forma de pago:";
                _Bt_Aprobar.Text = "Crear orden de pago";
                _Bt_Aprobar.Enabled = false;
            }
            else if (_G_Dec_MontoAReponer < 0)
            {
                //Negativo -> Reintegro
                _Pnl_Superior.Height = 125;
                _Rb_Cheque.Visible = true;
                _Rb_Transferencia.Visible = true;
                _Lbl_Banco.Visible = true;
                _Cmb_Banco.Visible = true;
                _Lbl_Cuenta.Visible = true;
                _Cmb_Cuenta.Visible = true;
                _Lbl_Concepto.Visible = false;
                _Txt_Concepto.Visible = false;
                _Lbl_NumeroDocumento.Visible = true;
                _Lbl_FechaDocumento.Visible = true;
                _Txt_NumeroDocumento.Visible = true;
                _Dtp_FechaDocumento.Visible = true;
                _Lbl_FormaDeReposicion.Visible = true;
                _Lbl_FormaDeReposicion.Text = "Forma de reintegro:";
                _Bt_Aprobar.Text = "Crear comprobante";
                _Bt_Aprobar.Enabled = false;
            }
            else
            {
                //Cero -> Solo comprobante
                _Pnl_Superior.Height = 66;
                _Rb_Cheque.Visible = false;
                _Rb_Transferencia.Visible = false;
                _Lbl_Banco.Visible = false;
                _Cmb_Banco.Visible = false;
                _Lbl_Cuenta.Visible = false;
                _Cmb_Cuenta.Visible = false;
                _Lbl_Concepto.Visible = false;
                _Txt_Concepto.Visible = false;
                _Lbl_NumeroDocumento.Visible = false;
                _Lbl_FechaDocumento.Visible = false;
                _Txt_NumeroDocumento.Visible = false;
                _Dtp_FechaDocumento.Visible = false;
                _Lbl_FormaDeReposicion.Visible = false;
                _Bt_Aprobar.Text = "Crear comprobante";
                _Bt_Aprobar.Enabled = true;
                //Motramos el comprobante
                Cursor = Cursors.WaitCursor; 
                _Dg_Comprobante.Rows.Clear(); 
                _Mtd_MostrarComprobante(_Int_Reposicion); 
                Cursor = Cursors.Default;
            }

        }
        private void _Mtd_Sorted(DataGridView _P_Dg_Grid)
        {
            for (int _Int_i = 0; _Int_i < _P_Dg_Grid.Columns.Count; _Int_i++)
            {
                _P_Dg_Grid.Columns[_Int_i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private string _Mtd_FormtadoMoneda(decimal? _P_Dec_Monto)
        {
            return Convert.ToDecimal(_P_Dec_Monto).ToString("#,##0.00");
        }
        private void _Mtd_CargarBanco()
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT DISTINCT TBANCO.cbanco,TBANCO.cname FROM TBANCO INNER JOIN " +
            "TCUENTBANC ON TBANCO.ccompany = TCUENTBANC.ccompany AND TBANCO.cbanco = TCUENTBANC.cbanco WHERE TBANCO.ccompany='" + Frm_Padre._Str_Comp + "' AND TBANCO.cdelete=0";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Banco, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }
        private void _Mtd_CargarCtaBanco(string _P_Str_Banco)
        {
            this.Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT cnumcuenta,cname FROM TCUENTBANC WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cbanco='" + _P_Str_Banco + "' AND cdelete=0";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Cuenta, _Str_Cadena);
            this.Cursor = Cursors.Default;
        }
        private string _Mtd_CuantaIva()
        {
            Program._Dat_Tablas =
new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            return (from Campos in Program._Dat_Tablas.TCONFIGCXP
                    where Campos.ccompany == Frm_Padre._Str_Comp
                    select Campos.ccountiva).Single();
        }
        private string _Mtd_CuantaIvaCredNoComp()
        {
            string _Str_Cadena = "SELECT ccountivacrednocomp FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
                return _Ds.Tables[0].Rows[0][0].ToString().Trim();
            return "";
        }
        private string _Mtd_DescripCount(string _P_Str_Count)
        {
            Program._Dat_Tablas =
new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            return (from Campos in Program._Dat_Tablas.TCOUNT
                    where Campos.ccompany == Frm_Padre._Str_Comp & Campos.ccount == _P_Str_Count
                    select Campos.cname).Single();
        }

        private void _Mtd_MostrarComprobante(int _P_Int_Reposicion)
        {
            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            var _Reposicion = Program._Dat_Tablas.TREPOSICIONESM.FirstOrDefault(x => x.ccompany == Frm_Padre._Str_Comp && x.cidreposiciones == _P_Int_Reposicion);
            var _Str_Beneficiario = _Reposicion == null ? "" : _Reposicion.cbeneficiario;
            Program._Dat_Vistas = new DataContext._Dat_CntxVistasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            //----------------
            string _Str_CuentaIva = _Mtd_CuantaIva();
            string _Str_CuentaIvaDescrip = _Mtd_DescripCount(_Str_CuentaIva);
            string _Str_CuentaIvaCredNoComp = _Mtd_CuantaIvaCredNoComp();
            string _Str_CuentaIvaCredNoCompDescrip = _Mtd_DescripCount(_Str_CuentaIvaCredNoComp);
            var _Var_Datos = from CamposVST_REPOSICIONES_DET in Program._Dat_Vistas.VST_REPOSICIONES_DET
                             where CamposVST_REPOSICIONES_DET.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & CamposVST_REPOSICIONES_DET.ccompany == Frm_Padre._Str_Comp & CamposVST_REPOSICIONES_DET.cidreposiciones == _P_Int_Reposicion
                             select new { CamposVST_REPOSICIONES_DET.ccuentaexep, CamposVST_REPOSICIONES_DET.cname, CamposVST_REPOSICIONES_DET.c_nomb_abreviado, CamposVST_REPOSICIONES_DET.cfechaemision, Monto = CamposVST_REPOSICIONES_DET.cmontosi + CamposVST_REPOSICIONES_DET.cmontoexento, CamposVST_REPOSICIONES_DET.cmontoimp, CamposVST_REPOSICIONES_DET.cmontototal, CamposVST_REPOSICIONES_DET.cnumdocu, CamposVST_REPOSICIONES_DET.ctipodocument, CamposVST_REPOSICIONES_DET.canticipogasto, CamposVST_REPOSICIONES_DET.ctipodocumentodetalle, CamposVST_REPOSICIONES_DET.cproveedor, CamposVST_REPOSICIONES_DET.cnumdocumafec, CamposVST_REPOSICIONES_DET.ciddreposiciones };
            //----------------
            //--------------------------------------- FACTURAS SIN IMPUESTO ---------------------------------------//
            foreach (var _Var_Campos in _Var_Datos.Where(c => !Convert.ToBoolean(c.canticipogasto)))
            {
                var _Str_Descrip = Convert.ToString(_Var_Campos.cname.Trim() + ". " + _Str_Beneficiario + " REP # " + _Int_Reposicion + ' ' + _Var_Campos.c_nomb_abreviado.Trim() + " FACT # " + _Var_Campos.cnumdocu.Trim() + ' ' + Convert.ToDateTime(_Var_Campos.cfechaemision).ToString("dd/MM/yyyy")).Trim();
                if (_Str_Descrip.Length > 255)
                    _Str_Descrip = _Str_Descrip.Remove(255);
                _Dg_Comprobante.Rows.Add(new object[] { _Var_Campos.ccuentaexep, null, _Str_Descrip, _Mtd_FormtadoMoneda(_Var_Campos.Monto), null, _Var_Campos.cnumdocu, _Var_Campos.ctipodocument, _Var_Campos.cproveedor, _Var_Campos.cfechaemision });
            }
            //--------------------------------------- FACTURAS CON IMPUESTO ---------------------------------------//
            foreach (var _Var_Campos in _Var_Datos.Where(c => !Convert.ToBoolean(c.canticipogasto) & c.cmontoimp > 0))
            {
                if (_Mtd_FacturaIvaCredNoComp(_P_Int_Reposicion, _Var_Campos.ciddreposiciones))
                {
                    var _Str_Descrip = Convert.ToString(_Str_CuentaIvaCredNoCompDescrip.Trim() + ". " + _Str_Beneficiario + " REP # " + _Int_Reposicion + ' ' + _Var_Campos.c_nomb_abreviado.Trim() + " FACT # " + _Var_Campos.cnumdocu.Trim() + ' ' + Convert.ToDateTime(_Var_Campos.cfechaemision).ToString("dd/MM/yyyy")).Trim();
                    if (_Str_Descrip.Length > 255)
                        _Str_Descrip = _Str_Descrip.Remove(255);
                    _Dg_Comprobante.Rows.Add(new object[] { _Str_CuentaIvaCredNoComp, null, _Str_Descrip, _Mtd_FormtadoMoneda(_Var_Campos.cmontoimp), null, _Var_Campos.cnumdocu, _Var_Campos.ctipodocument, _Var_Campos.cproveedor, _Var_Campos.cfechaemision });
                }
                else
                {
                    var _Str_Descrip = Convert.ToString(_Str_CuentaIvaDescrip.Trim() + ". " + _Str_Beneficiario + " REP # " + _Int_Reposicion + ' ' + _Var_Campos.c_nomb_abreviado.Trim() + " FACT # " + _Var_Campos.cnumdocu.Trim() + ' ' + Convert.ToDateTime(_Var_Campos.cfechaemision).ToString("dd/MM/yyyy")).Trim();
                    if (_Str_Descrip.Length > 255)
                        _Str_Descrip = _Str_Descrip.Remove(255);
                    _Dg_Comprobante.Rows.Add(new object[] { _Str_CuentaIva, null, _Str_Descrip, _Mtd_FormtadoMoneda(_Var_Campos.cmontoimp), null, _Var_Campos.cnumdocu, _Var_Campos.ctipodocument, _Var_Campos.cproveedor, _Var_Campos.cfechaemision });
                }
            }
            //--------------------------------------- FACTURAS ANTICIPOS DE GASTO ---------------------------------------//
            foreach (var _Var_Campos in _Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)Frm_ReposicionCxP._TipoDocumentoReposicion.Anticipo))
            {
                var _Str_Descrip = Convert.ToString(_Var_Campos.cname.Trim() + ". " + _Str_Beneficiario + " REP # " + _Int_Reposicion + " ANTICIPO DE GASTOS " + Convert.ToDateTime(_Var_Campos.cfechaemision).ToString("dd/MM/yyyy")).Trim();
                if (_Str_Descrip.Length > 255)
                    _Str_Descrip = _Str_Descrip.Remove(255);
                _Dg_Comprobante.Rows.Add(new object[] { _Var_Campos.ccuentaexep, null, _Str_Descrip, null, _Mtd_FormtadoMoneda(_Var_Campos.cmontototal), _Var_Campos.cnumdocu, _Var_Campos.ctipodocument, _Var_Campos.cproveedor, _Var_Campos.cfechaemision });
            }
            //--------------------------------------- RETENCIONES DE ISLR ---------------------------------------//
            foreach (var _Var_Campos in _Var_Datos.Where(c => c.ctipodocumentodetalle == (byte) Frm_ReposicionCxP._TipoDocumentoReposicion.RetencionISLR))
            {
                //Obtenemos la cuenta del proveedor del documento que afecta
                var _Str_ccuentaexep = "";
                var _oRegistro = _Var_Datos.SingleOrDefault(x =>
                                                            x.ctipodocumentodetalle == (byte)Frm_ReposicionCxP._TipoDocumentoReposicion.Factura
                                                            && x.cproveedor == _Var_Campos.cproveedor
                                                            && x.cnumdocu == _Var_Campos.cnumdocumafec
                                                            );
                if (_oRegistro != null) _Str_ccuentaexep = _Mtd_ObtenerCuentaContableAPagarProveedor(_oRegistro.cproveedor, (byte)Frm_ReposicionCxP._TipoDocumentoReposicion.RetencionISLR);
                //----/--
                if (_oRegistro != null)
                {
                    var _Str_Descrip = Convert.ToString(_oRegistro.cname.Trim() + ". " + _Str_Beneficiario + " REP # " + _Int_Reposicion + " RETENC. ISLR " + Convert.ToDateTime(_Var_Campos.cfechaemision).ToString("dd/MM/yyyy")).Trim();
                    if (_Str_Descrip.Length > 255)
                        _Str_Descrip = _Str_Descrip.Remove(255);
                    _Dg_Comprobante.Rows.Add(new object[] { _Str_ccuentaexep, null, _Str_Descrip, null, _Mtd_FormtadoMoneda(_Var_Campos.cmontototal), _Var_Campos.cnumdocu, _Var_Campos.ctipodocument, _Var_Campos.cproveedor, _Var_Campos.cfechaemision });
                }
            }
            //--------------------------------------- RETENCIONES DE IVA ---------------------------------------//
            foreach (var _Var_Campos in _Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)Frm_ReposicionCxP._TipoDocumentoReposicion.RetencionIVA))
            {
                //Obtenemos la cuenta del proveedor del documento que afecta
                var _Str_ccuentaexep = "";
                var _oRegistro = _Var_Datos.SingleOrDefault(x =>
                                                            x.ctipodocumentodetalle == (byte)Frm_ReposicionCxP._TipoDocumentoReposicion.Factura
                                                            && x.cproveedor == _Var_Campos.cproveedor
                                                            && x.cnumdocu == _Var_Campos.cnumdocumafec
                                                            );
                if (_oRegistro != null) _Str_ccuentaexep = _Mtd_ObtenerCuentaContableAPagarProveedor(_oRegistro.cproveedor, (byte)Frm_ReposicionCxP._TipoDocumentoReposicion.RetencionIVA);
                //----/--
                if (_oRegistro != null)
                {
                    var _Str_Descrip = Convert.ToString(_oRegistro.cname.Trim() + ". " + _Str_Beneficiario + " REP # " + _Int_Reposicion + " RETENC. IVA " + Convert.ToDateTime(_Var_Campos.cfechaemision).ToString("dd/MM/yyyy")).Trim();
                    if (_Str_Descrip.Length > 255)
                        _Str_Descrip = _Str_Descrip.Remove(255);
                    _Dg_Comprobante.Rows.Add(new object[] { _Str_ccuentaexep, null, _Str_Descrip, null, _Mtd_FormtadoMoneda(_Var_Campos.cmontototal), _Var_Campos.cnumdocu, _Var_Campos.ctipodocument, _Var_Campos.cproveedor, _Var_Campos.cfechaemision });
                }
            }
            //--------------------------------------- RETENCIONES DE PATENTE ---------------------------------------//
            foreach (var _Var_Campos in _Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)Frm_ReposicionCxP._TipoDocumentoReposicion.RetencionPatente))
            {
                //Obtenemos la cuenta del proveedor del documento que afecta
                var _Str_ccuentaexep = "";
                var _oRegistro = _Var_Datos.SingleOrDefault(x =>
                                                            x.ctipodocumentodetalle == (byte)Frm_ReposicionCxP._TipoDocumentoReposicion.Factura
                                                            && x.cproveedor == _Var_Campos.cproveedor
                                                            && x.cnumdocu == _Var_Campos.cnumdocumafec
                                                            );
                if (_oRegistro != null) _Str_ccuentaexep = _Mtd_ObtenerCuentaContableAPagarProveedor(_oRegistro.cproveedor, (byte)Frm_ReposicionCxP._TipoDocumentoReposicion.RetencionPatente);
                //----/--
                if (_oRegistro != null)
                {
                    var _Str_Descrip = Convert.ToString(_oRegistro.cname.Trim() + ". " + _Str_Beneficiario + " REP # " + _Int_Reposicion + " RETENC. PATENTE " + Convert.ToDateTime(_Var_Campos.cfechaemision).ToString("dd/MM/yyyy")).Trim();
                    if (_Str_Descrip.Length > 255)
                        _Str_Descrip = _Str_Descrip.Remove(255);
                    _Dg_Comprobante.Rows.Add(new object[] { _Str_ccuentaexep, null, _Str_Descrip, null, _Mtd_FormtadoMoneda(_Var_Campos.cmontototal), _Var_Campos.cnumdocu, _Var_Campos.ctipodocument, _Var_Campos.cproveedor, _Var_Campos.cfechaemision });
                }
            }
            decimal _Dcm_TotalDebe = 0, _Dcm_TotalHaber = 0;
            _Dcm_TotalDebe =(decimal)_Var_Datos.Where(c => !Convert.ToBoolean(c.canticipogasto)).Select(c => c.cmontototal).Sum();
            if (_Var_Datos.Where(c => Convert.ToBoolean(c.canticipogasto)).Count() > 0)
            { _Dcm_TotalHaber = (decimal)_Var_Datos.Where(c => Convert.ToBoolean(c.canticipogasto)).Select(c => c.cmontototal).Sum(); }
            decimal _Dcm_TotalBanco = _Dcm_TotalDebe - _Dcm_TotalHaber;
            _Dcm_TotalBanco = Math.Round(_Dcm_TotalBanco, 2);
            _Dcm_TotalBanco = Math.Abs(_Dcm_TotalBanco);

            //--------------------------------------- BANCO ---------------------------------------//
            if (_G_Dec_MontoAReponer > 0)
            {
                _Dg_Comprobante.Rows.Add(new object[] { null, null, "BANCO", null, _Mtd_FormtadoMoneda((decimal?)_Dcm_TotalBanco), null, null, null, null });
                //Debito Bancario
                if (CLASES._Cls_Varios_Metodos._Mtd_DebitoBancarioCuentaBancaria())
                {
                    _Mtd_DebitoBancarioCuentaBancaria();
                    //Agrego la cuenta contable de gastos por debito bancario                            
                    DataSet _Ds_DebitoBancario = null;
                    string _Str_Sql = "select TPROCESOSCONTD.ccount,TPROCESOSCONTD.cnaturaleza from TPROCESOSCONTD where TPROCESOSCONTD.cidproceso='" + _Str_ProcesoContableDebitoBancarioHabilitado + "'";
                    _Ds_DebitoBancario = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                    double _Dbl_MontoDebito = 0;
                    string _Str_CuentaContableDebitoBancarioComp = "";
                    string _Str_CuentaContableDebitoBancarioDescr = "";
                    _Dbl_MontoDebito = Convert.ToDouble(_Dcm_TotalBanco) * _Dbl_PorcentajeDebitoBancarioHabilitado / 100;
                    foreach (DataRow _Dtw_Row in _Ds_DebitoBancario.Tables[0].Rows)
                    {
                        if (_Dtw_Row["ccount"].ToString() == CLASES._Cls_Varios_Metodos._Str_G_CuentaContBanco)
                        {
                            _Str_Sql = "SELECT ccount,cname FROM VST_CUENTBANCCOUNT WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cnumcuenta='" + Convert.ToString(_Cmb_Cuenta.SelectedValue).Trim() + "' AND cbanco='" + Convert.ToString(_Cmb_Banco.SelectedValue) + "'";
                            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds_A.Tables[0].Rows.Count > 0)
                            {
                                _Str_CuentaContableDebitoBancarioComp = _Ds_A.Tables[0].Rows[0]["ccount"].ToString().Trim();
                                _Str_CuentaContableDebitoBancarioDescr = "CARGO IGTF.<REPLACEIGTFBANCO>" + _Ds_A.Tables[0].Rows[0]["cname"].ToString().Trim() + ".";
                            }
                        }
                        else
                        {
                            _Str_Sql = "SELECT cname FROM tcount WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND ccount='" + _Dtw_Row["ccount"].ToString().Trim() + "'";
                            DataSet _Ds_A = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
                            if (_Ds_A.Tables[0].Rows.Count > 0)
                            {
                                _Str_CuentaContableDebitoBancarioComp = _Dtw_Row["ccount"].ToString().Trim();
                                _Str_CuentaContableDebitoBancarioDescr = "CARGO IGTF.<REPLACEIGTF>";
                            }
                        }                        
                        //_Dg_Comprobante[1, _Dg_Comprobante.RowCount - 1].Value = _Str_CuentaContableDebitoBancarioComp;
                        //_Dg_Comprobante[3, _Dg_Comprobante.RowCount - 1].Value = _Str_CuentaContableDebitoBancarioDescr;
                        if (_Dtw_Row["cnaturaleza"].ToString() == "D")
                        {
                            _Dcm_TotalDebe += (decimal)_Dbl_MontoDebito;
                            _Dg_Comprobante.Rows.Add(new object[] { _Str_CuentaContableDebitoBancarioComp, null, _Str_CuentaContableDebitoBancarioDescr, _Mtd_FormtadoMoneda((decimal?)_Dbl_MontoDebito), null, null, null, null, null });
                            //_Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = _Dbl_MontoDebito.ToString("#,##0.00");
                            //_Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = "";
                        }
                        else
                        {
                            _Dcm_TotalHaber += (decimal)_Dbl_MontoDebito;
                            _Dg_Comprobante.Rows.Add(new object[] { _Str_CuentaContableDebitoBancarioComp, null, _Str_CuentaContableDebitoBancarioDescr,null, _Mtd_FormtadoMoneda((decimal?)_Dbl_MontoDebito), null, null, null, null });
                            //_Dg_Comprobante[5, _Dg_Comprobante.RowCount - 1].Value = _Dbl_MontoDebito.ToString("#,##0.00");
                            //_Dg_Comprobante[4, _Dg_Comprobante.RowCount - 1].Value = "";
                        }
                    }
                }
            }
            else if (_G_Dec_MontoAReponer < 0)
            {
                _Dg_Comprobante.Rows.Add(new object[] { null, null, "BANCO", _Mtd_FormtadoMoneda((decimal?)_Dcm_TotalBanco), null, null, null, null, null });
            }

            //--------------------------------------- TOTALES ---------------------------------------//
            decimal _Dcm_Totales = 0;
            if (_G_Dec_MontoAReponer > 0) 
                _Dcm_Totales = _Dcm_TotalDebe;
            else if (_G_Dec_MontoAReponer < 0)
                _Dcm_Totales = _Dcm_TotalDebe + _Dcm_TotalBanco;
            else
                _Dcm_Totales = _Dcm_TotalDebe;

            _Dcm_Totales = Math.Round(_Dcm_Totales, 2);
            _Dg_Comprobante.Rows.Add(new object[] { null, null, "TOTAL", _Mtd_FormtadoMoneda((decimal?)_Dcm_Totales), _Mtd_FormtadoMoneda((decimal?)_Dcm_Totales), null, null });
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        double _Dbl_PorcentajeDebitoBancarioHabilitado = 0;
        string _Str_ProcesoContableDebitoBancarioHabilitado = "CXP_DEBITOBANC";
        private void _Mtd_DebitoBancarioCuentaBancaria()
        {
            //Programación de comprobante contable según debito bancario
            DataSet _Ds_DebitoBancario = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT cdebitobancario,cporcentdebitobancario FROM TCONFIGCONSSA");
            if (_Ds_DebitoBancario.Tables[0].Rows.Count > 0)
            {                
                if (_Ds_DebitoBancario.Tables[0].Rows[0]["cporcentdebitobancario"].ToString() != "")
                {
                    _Dbl_PorcentajeDebitoBancarioHabilitado = Convert.ToDouble(_Ds_DebitoBancario.Tables[0].Rows[0]["cporcentdebitobancario"].ToString());
                }
            }
            //
        }
        private string _Mtd_ObtenerCuentaContableAPagarProveedor(string _P_Str_ccproveedor, byte _P_TipoDocumento)
        {
            var _Str_CodigoTipoProveedor = "";
            var _Str_CodigoCategoriaProveedor = "";
            var _Str_PROCESOCONTABLE = "";
            var _Str_CatCompaRel = "";
            var _Str_CatAccion = "";
            var _Str_ccount = "";

            //Obtenemos los datos necesarios del proveedor
            _Mtd_CodigoTipoCategoriaProveedor(_P_Str_ccproveedor, out _Str_CodigoTipoProveedor, out _Str_CodigoCategoriaProveedor);

            //Obtenemos los datos necesarios de la tabla de configuración
            
            var _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset("SELECT ctipdocretislr,cprovretislr,cprovretiva,ctipdocretiva,ccatproveciarel,ccatproveaccio,ctipodocretpat FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "'");
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                _Str_CatCompaRel = Convert.ToString(_Ds.Tables[0].Rows[0]["ccatproveciarel"]);
                _Str_CatAccion = Convert.ToString(_Ds.Tables[0].Rows[0]["ccatproveaccio"]);
            }

            //En funcion al documento
            switch (_P_TipoDocumento)
            {
                case (byte) Frm_ReposicionCxP._TipoDocumentoReposicion.RetencionIVA:
                    if (_Str_CodigoTipoProveedor.Trim() == "0")
                    {
                        _Str_PROCESOCONTABLE = "P_CXP_COMP_RETEN_S_O";
                    }
                    else if (_Str_CodigoTipoProveedor.Trim() == "1")
                    {
                        _Str_PROCESOCONTABLE = "P_CXP_COMP_RETEN_M";
                    }
                    else if (_Str_CodigoTipoProveedor.Trim() == "2" & _Str_CodigoCategoriaProveedor.Trim().ToUpper() == _Str_CatCompaRel.Trim().ToUpper())
                    {
                        _Str_PROCESOCONTABLE = "P_CXP_COMP_RETEN_C";
                    }
                    else if (_Str_CodigoTipoProveedor.Trim() == "2" & _Str_CodigoCategoriaProveedor.Trim().ToUpper() == _Str_CatAccion.Trim().ToUpper())
                    {
                        _Str_PROCESOCONTABLE = "P_CXP_COMP_RETEN_S_O";
                    }
                    else
                    {
                        _Str_PROCESOCONTABLE = "P_CXP_COMP_RETEN_S_O";
                    }
                break;
                case (byte) Frm_ReposicionCxP._TipoDocumentoReposicion.RetencionISLR:
                if (_Str_CodigoTipoProveedor.Trim() == "0")
                    {
                        _Str_PROCESOCONTABLE = "P_CXP_COMP_RETENISLR";
                    }
                else if (_Str_CodigoTipoProveedor.Trim() == "1")
                    {
                        _Str_PROCESOCONTABLE = "P_CXP_COMP_RETENISLR";
                    }
                else if (_Str_CodigoTipoProveedor.Trim() == "2" & _Str_CodigoCategoriaProveedor.Trim().ToUpper() == _Str_CatCompaRel.Trim().ToUpper())
                    {
                        _Str_PROCESOCONTABLE = "P_CXP_COMP_RETISLRCR";
                    }
                else if (_Str_CodigoTipoProveedor.Trim() == "2" & _Str_CodigoCategoriaProveedor.Trim().ToUpper() == _Str_CatAccion.Trim().ToUpper())
                    {
                        _Str_PROCESOCONTABLE = "P_CXP_COMP_RETISLRAC";
                    }
                    else
                    {
                        _Str_PROCESOCONTABLE = "P_CXP_COMP_RETENISLR";
                    }
                break;
                case (byte)Frm_ReposicionCxP._TipoDocumentoReposicion.RetencionPatente:
                if (_Str_CodigoTipoProveedor.Trim() == "0")
                {
                    _Str_PROCESOCONTABLE = "P_CXP_COMP_RETENPAT";
                }
                else if (_Str_CodigoTipoProveedor.Trim() == "1")
                {
                    _Str_PROCESOCONTABLE = "P_CXP_COMP_RETPATMP";
                }
                else if (_Str_CodigoTipoProveedor.Trim() == "2" & _Str_CodigoCategoriaProveedor.Trim().ToUpper() == _Str_CatCompaRel.Trim().ToUpper())
                {
                    _Str_PROCESOCONTABLE = "P_CXP_COMP_RETPATCR";
                }
                else if (_Str_CodigoTipoProveedor.Trim() == "2" & _Str_CodigoCategoriaProveedor.Trim().ToUpper() == _Str_CatAccion.Trim().ToUpper())
                {
                    _Str_PROCESOCONTABLE = "P_CXP_COMP_RETPATAC";
                }
                else
                {
                    _Str_PROCESOCONTABLE = "P_CXP_COMP_RETENPAT";
                }
                break;
            }

            if (_Str_PROCESOCONTABLE.Trim().Length > 0)
            {
                //Obtenemos la cuenta
                var _Str_Cadena = "select ccount,ctipodocumento,cnaturaleza,cideprocesod,ccountname from VST_PROCESOSCONTD where cidproceso='" + _Str_PROCESOCONTABLE + "' AND (ccompany='" + Frm_Padre._Str_Comp + "' OR ccompany IS NULL) and (cvariable='A') order by cideprocesod";
                _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Str_ccount = _Ds.Tables[0].Rows[0]["ccount"].ToString();
                }
            }
            //Devolvemos
            return _Str_ccount;

        }

        private void _Mtd_CodigoTipoCategoriaProveedor(string _Str_CodigoProveedor, out string _P_Str_cglobal, out string _P_Str_ccatproveedor)
        {
            var _Str_cglobal = "";
            var _Str_ccatproveedor = "";

            string _Str_Sql = "SELECT cglobal,ISNULL(ccatproveedor,0) as ccatproveedor from TPROVEEDOR where CPROVEEDOR = '" + _Str_CodigoProveedor + "'";
            DataSet _Ds_Data = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Data.Tables[0].Rows.Count > 0)
            {
               _Str_cglobal = Convert.ToString(_Ds_Data.Tables[0].Rows[0]["cglobal"]);
               _Str_ccatproveedor =  Convert.ToString(_Ds_Data.Tables[0].Rows[0]["ccatproveedor"]);
            }
            _P_Str_cglobal = _Str_cglobal;
            _P_Str_ccatproveedor = _Str_ccatproveedor;
        }

        //private decimal _Mtd_ObtenerTotalComprobante(int _P_Int_Reposicion)
        //{
        //    //----------------
        //    Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
        //    var _Var_Datos = from CamposVST_REPOSICIONES_DET in Program._Dat_Vistas.VST_REPOSICIONES_DET
        //                     where CamposVST_REPOSICIONES_DET.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & CamposVST_REPOSICIONES_DET.ccompany == Frm_Padre._Str_Comp & CamposVST_REPOSICIONES_DET.cidreposiciones == _P_Int_Reposicion
        //                     select new { CamposVST_REPOSICIONES_DET.ccuentaexep, CamposVST_REPOSICIONES_DET.cname, CamposVST_REPOSICIONES_DET.c_nomb_abreviado, CamposVST_REPOSICIONES_DET.cfechaemision, Monto = CamposVST_REPOSICIONES_DET.cmontosi + CamposVST_REPOSICIONES_DET.cmontoexento, CamposVST_REPOSICIONES_DET.cmontoimp, CamposVST_REPOSICIONES_DET.cmontototal, CamposVST_REPOSICIONES_DET.cnumdocu, CamposVST_REPOSICIONES_DET.ctipodocument, CamposVST_REPOSICIONES_DET.canticipogasto, CamposVST_REPOSICIONES_DET.ctipodocumentodetalle };
        //    decimal _Dcm_TotalDebe = 0, _Dcm_TotalHaber = 0;
        //    _Dcm_TotalDebe = (decimal)_Var_Datos.Where(c => !Convert.ToBoolean(c.canticipogasto)).Select(c => c.cmontototal).Sum();
        //    if (_Var_Datos.Where(c => Convert.ToBoolean(c.canticipogasto)).Count() > 0)
        //    { _Dcm_TotalHaber = (decimal)_Var_Datos.Where(c => Convert.ToBoolean(c.canticipogasto)).Select(c => c.cmontototal).Sum(); }
        //    decimal _Dcm_TotalBanco = _Dcm_TotalDebe - _Dcm_TotalHaber;
        //    _Dcm_TotalBanco = Math.Round(_Dcm_TotalBanco, 2);
        //    _Dcm_TotalBanco = Math.Abs(_Dcm_TotalBanco);

        //    //--------------------------------------- TOTALES ---------------------------------------//
        //    decimal _Dcm_Totales = 0;
        //    if (_G_Dec_MontoAReponer > 0)
        //        _Dcm_Totales = _Dcm_TotalDebe;
        //    else if (_G_Dec_MontoAReponer < 0)
        //        _Dcm_Totales = _Dcm_TotalDebe + _Dcm_TotalBanco;
        //    else
        //        _Dcm_Totales = _Dcm_TotalDebe;

        //    return _Dcm_Totales;
        //}

        private void _Mtd_FilaBanco(string _P_Str_Banco, string _P_Str_Cuenta)
        {
           
            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            var _Var_Datos = from CamposTCOUNT in Program._Dat_Tablas.TCOUNT
                             join CamposTCUENTBANC in Program._Dat_Tablas.TCUENTBANC on new { ccompany = CamposTCOUNT.ccompany, ccount = CamposTCOUNT.ccount } equals new { ccompany = CamposTCUENTBANC.ccompany, ccount = CamposTCUENTBANC.ccount }
                             where CamposTCUENTBANC.ccompany == Frm_Padre._Str_Comp & CamposTCUENTBANC.cbanco == _P_Str_Banco & CamposTCUENTBANC.cnumcuenta == _P_Str_Cuenta
                             select new { CamposTCOUNT.ccount, CamposTCOUNT.cname };
            if (!CLASES._Cls_Varios_Metodos._Mtd_DebitoBancarioCuentaBancaria())
            {
                _Dg_Comprobante.Rows[_Dg_Comprobante.RowCount - 2].Cells["Cuenta"].Value = _Var_Datos.ToList().Select(c => c.ccount).Single();
            }
            else
            {
                if (_G_Dec_MontoAReponer < 0)
                {
                    _Dg_Comprobante.Rows[_Dg_Comprobante.RowCount - 2].Cells["Cuenta"].Value = _Var_Datos.ToList().Select(c => c.ccount).Single();
                }
                else
                {
                    _Dg_Comprobante.Rows[_Dg_Comprobante.RowCount - 4].Cells["Cuenta"].Value = _Var_Datos.ToList().Select(c => c.ccount).Single();
                }
            }
            var _Str_Descripcion = "";
            if (_G_Dec_MontoAReponer > 0) 
                _Str_Descripcion = _Var_Datos.ToList().Select(c => c.cname).Single();
            else if (_G_Dec_MontoAReponer < 0)
                _Str_Descripcion = _Var_Datos.ToList().Select(c => c.cname).Single() + (_Rb_Cheque.Checked? " CHEQUE" : " TRANSF.") + " #"+ _Txt_NumeroDocumento.Text + " " +  _Dtp_FechaDocumento.Value.Date.ToShortDateString();
            if (!CLASES._Cls_Varios_Metodos._Mtd_DebitoBancarioCuentaBancaria())
            {
                _Dg_Comprobante.Rows[_Dg_Comprobante.RowCount - 2].Cells["Descripcion"].Value = _Str_Descripcion;
            }
            else
            {
                if (_G_Dec_MontoAReponer < 0)
                {
                    _Dg_Comprobante.Rows[_Dg_Comprobante.RowCount - 2].Cells["Descripcion"].Value = _Str_Descripcion;
                }
                else
                {
                    _Dg_Comprobante.Rows[_Dg_Comprobante.RowCount - 4].Cells["Descripcion"].Value = _Str_Descripcion;
                }
            }
            _Dg_Comprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private int _Mtd_CrearComprobante(int _P_Int_Reposicion)
        {
            //----------------
            //decimal _Dcm_Total = _Mtd_ObtenerTotalComprobante(_P_Int_Reposicion);
            //----------------
            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            Clases._Cls_ProcesosCont _Cls_ProcesosCont = new T3.Clases._Cls_ProcesosCont("P_BCO_CHQ_PROVEE");
            string _Str_TipComp = _Cls_ProcesosCont._Field_TipoComprobante;
            int _Int_Comprobante =new _Cls_Consecutivos()._Mtd_Comprobante();
            //----------------
            DataContext.TCOMPROBANC _T_TCOMPROBANC = new T3.DataContext.TCOMPROBANC()
            {
                ccompany = Frm_Padre._Str_Comp,
                cidcomprob = Convert.ToDecimal(_Int_Comprobante),
                ctypcomp = _Str_TipComp,
                cname = _Str_TipoReposicion,
                cyearacco = Convert.ToInt32(Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()))),
                cmontacco = Convert.ToInt32(Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()))),
                cregdate = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate(),
                ctotdebe = 0,
                ctothaber = 0,
                cbalance = 0,
                clvalidado = 0,
                cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ(),
                cuseradd = Frm_Padre._Str_Use,
                csistema = 1,
                cstatus = '9'
            };
            Program._Dat_Tablas.TCOMPROBANC.InsertOnSubmit(_T_TCOMPROBANC);
            //----------------
            DataContext.TCOMPROBAND _T_TCOMPROBAND;
            decimal _Dec_DebeD = 0;
            decimal _Dec_HaberD = 0;
            foreach (DataGridViewRow _Dg_Row in _Dg_Comprobante.Rows)
            {
                if (_Dg_Row.Cells[0].Value != null)
                {
                    //------------------------------------------------------------------------
                    _Dec_DebeD = 0; _Dec_HaberD = 0;
                    if (Convert.ToString(_Dg_Row.Cells["Debe"].Value).Trim().Length > 0)
                    { _Dec_DebeD = Convert.ToDecimal(_Dg_Row.Cells["Debe"].Value); }
                    if (Convert.ToString(_Dg_Row.Cells["Haber"].Value).Trim().Length > 0)
                    { _Dec_HaberD = Convert.ToDecimal(_Dg_Row.Cells["Haber"].Value); }
                    //------------------------------------------------------------------------
                    _T_TCOMPROBAND = new T3.DataContext.TCOMPROBAND()
                    {
                        ccompany = Frm_Padre._Str_Comp,
                        cidcomprob = Convert.ToDecimal(_Int_Comprobante),
                        corder = (_Dg_Row.Index + 1),
                        ccount = Convert.ToString(_Dg_Row.Cells["Cuenta"].Value).Trim(),
                        cdescrip = Convert.ToString(_Dg_Row.Cells["Descripcion"].Value).Trim(),
                        ctdocument = Convert.ToString(_Dg_Row.Cells["TipoDocumento"].Value).Trim(),
                        cnumdocu = Convert.ToString(_Dg_Row.Cells["Documento"].Value).Trim(),
                        ctotdebe = _Dec_DebeD,
                        ctothaber = _Dec_HaberD,
                        cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ(),
                        cuseradd = Frm_Padre._Str_Use
                    };
                    Program._Dat_Tablas.TCOMPROBAND.InsertOnSubmit(_T_TCOMPROBAND);
                }
            }
            Program._Dat_Tablas.SubmitChanges();
            _Mtd_InsertarAuxiliarContable(_Int_Comprobante.ToString());
            string _Str_Cadena = "SELECT ISNULL(SUM(ctotdebe),0) AS ctotdebe,ISNULL(SUM(ctothaber),0) AS ctothaber FROM TCOMPROBAND WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Int_Comprobante + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                var _Dbl_Debe = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctotdebe"]);
                var _Dbl_Haber = Convert.ToDouble(_Ds.Tables[0].Rows[0]["ctothaber"]);
                _Str_Cadena = "UPDATE TCOMPROBANC SET ctotdebe='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Debe) + "',ctothaber='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dbl_Haber) + "' WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _Int_Comprobante + "'";
                Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
            }
            return _Int_Comprobante;
        }

        private void _Mtd_InsertarAuxiliarContable(string _P_Str_Comprobante)
        {
            CLASES._Cls_Varios_Metodos._Mtd_EliminarAuxiliarCont(Frm_Padre._Str_Comp, _P_Str_Comprobante);
            decimal _Dec_Debe = 0, _Dec_Haber = 0;
            string _Str_FechaEmision = "";
            _Dg_Comprobante.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[0].Value != null && x.Cells["Documento"].Value != null).ToList().ForEach(_Row =>
            {
                //------------------------------------------------------------------------
                _Dec_Debe = 0; _Dec_Haber = 0;
                if (Convert.ToString(_Row.Cells["Debe"].Value).Trim().Length > 0)
                { _Dec_Debe = Convert.ToDecimal(_Row.Cells["Debe"].Value); }
                if (Convert.ToString(_Row.Cells["Haber"].Value).Trim().Length > 0)
                { _Dec_Haber = Convert.ToDecimal(_Row.Cells["Haber"].Value); }
                //------------------------------------------------------------------------
                _Str_FechaEmision = _Cls_Formato._Mtd_fecha(Convert.ToDateTime(_Row.Cells["FechaEmision"].Value));
                //------------------------------------------------------------------------
                if (_Dec_Debe > 0)
                { CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_P_Str_Comprobante, Convert.ToString(_Row.Cells["Cuenta"].Value).Trim(), Convert.ToString(_Row.Cells["Proveedor"].Value).Trim(), Convert.ToString(_Row.Cells["Descripcion"].Value).Trim().ToUpper(), Convert.ToString(_Row.Cells["TipoDocumento"].Value).Trim(), Convert.ToString(_Row.Cells["Documento"].Value).Trim(), _Str_FechaEmision, _Str_FechaEmision, CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_Debe), Clases._Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()), Clases._Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()), "D"); }//Aux
                else
                { CLASES._Cls_Varios_Metodos._Mtd_InsertAuxiliarCont(_P_Str_Comprobante, Convert.ToString(_Row.Cells["Cuenta"].Value).Trim(), Convert.ToString(_Row.Cells["Proveedor"].Value).Trim(), Convert.ToString(_Row.Cells["Descripcion"].Value).Trim().ToUpper(), Convert.ToString(_Row.Cells["TipoDocumento"].Value).Trim(), Convert.ToString(_Row.Cells["Documento"].Value).Trim(), _Str_FechaEmision, _Str_FechaEmision, CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(_Dec_Haber), Clases._Cls_ProcesosCont._Mtd_ContableMes(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()), Clases._Cls_ProcesosCont._Mtd_ContableAno(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate().ToShortDateString()), "H"); }//Aux
            });
        }

        public int _Mtd_CrearOrdenPago(int _P_Int_Reposicion)
        {
            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            var _Var_Datos = from CamposTREPOSICIONESM in Program._Dat_Tablas.TREPOSICIONESM
                             join CamposTREPOSICIONESD in Program._Dat_Tablas.TREPOSICIONESD on new { CamposTREPOSICIONESM.cgroupcomp, CamposTREPOSICIONESM.ccompany, CamposTREPOSICIONESM.cidreposiciones } equals new { CamposTREPOSICIONESD.cgroupcomp, CamposTREPOSICIONESD.ccompany, CamposTREPOSICIONESD.cidreposiciones }
                             where CamposTREPOSICIONESM.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & CamposTREPOSICIONESM.ccompany == Frm_Padre._Str_Comp & CamposTREPOSICIONESM.cidreposiciones == _P_Int_Reposicion
                             select new { CamposTREPOSICIONESM.cbeneficiario, CamposTREPOSICIONESD.cmontototal, CamposTREPOSICIONESD.canticipogasto, CamposTREPOSICIONESM.crif };
            //----------------------------------
            decimal _Dcm_TotalDebe = 0, _Dcm_TotalHaber = 0;
            if (_Var_Datos.Where(c => !Convert.ToBoolean(c.canticipogasto)).Count() > 0)
            { _Dcm_TotalDebe = (decimal)_Var_Datos.Where(c => !Convert.ToBoolean(c.canticipogasto)).Select(c => c.cmontototal).Sum(); }
            if (_Var_Datos.Where(c => Convert.ToBoolean(c.canticipogasto)).Count() > 0)
            { _Dcm_TotalHaber = (decimal)_Var_Datos.Where(c => Convert.ToBoolean(c.canticipogasto)).Select(c => c.cmontototal).Sum(); }
            decimal _Dcm_TotalBanco = _Dcm_TotalDebe - _Dcm_TotalHaber;
            //----------------------------------
            string _Str_ctipotrospago = "7"; if (_Str_TipoRep == "G") { _Str_ctipotrospago = "6"; }
            string _Str_cfpago = "CHEQ"; if (_Rb_Transferencia.Checked) { _Str_cfpago = "TRANSF"; }
            int _Int_OrdenPago = new _Cls_Consecutivos()._Mtd_OrdenPago();
            //----------------------------------
            var _Reposicion = _Var_Datos.ToList().First();
            //----------------------------------
            int _Int_Comprobante = _Mtd_CrearComprobante(_P_Int_Reposicion);
            DataContext.TPAGOSCXPM _T_TPAGOSCXPM = new T3.DataContext.TPAGOSCXPM()
            {
                cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp),
                ccompany = Frm_Padre._Str_Comp,
                cidordpago = _Int_OrdenPago,
                cproveedor = "",
                ctipotrospago = Convert.ToDecimal(_Str_ctipotrospago),
                ctippago = "PTOT",
                cfpago = _Str_cfpago,
                cfecha = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate(),
                cuserfirmante = Frm_Padre._Str_Use,
                cmontototal = _Dcm_TotalBanco,
                cbanco = Convert.ToString(_Cmb_Banco.SelectedValue).Trim(),
                cnumcuentad = Convert.ToString(_Cmb_Cuenta.SelectedValue).Trim(),
                cidcomprob = _Int_Comprobante,
                cbeneficiario = _Reposicion.cbeneficiario,
                cconcepto = _Txt_Concepto.Text.Trim().ToUpper(),
                cotrospago = 1,
                canulado = 0,
                ccancelado = 0,
                cidemisioncheq = 0,
                cidemisioncaja = 0,
                crif = _Reposicion.crif
            };
            Program._Dat_Tablas.TPAGOSCXPM.InsertOnSubmit(_T_TPAGOSCXPM);
            //----------------------------------
            DataContext.TREPOSICIONESM _T_TREPOSICIONESM = Program._Dat_Tablas.TREPOSICIONESM.Single(Campos => Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidreposiciones == _P_Int_Reposicion);
            _T_TREPOSICIONESM.cidordpago = _Int_OrdenPago;
            _T_TREPOSICIONESM.cbanco = Convert.ToString(_Cmb_Banco.SelectedValue).Trim();
            _T_TREPOSICIONESM.cfpago = "PTOT";
            _T_TREPOSICIONESM.cnumcuenta = Convert.ToString(_Cmb_Cuenta.SelectedValue).Trim();
            _T_TREPOSICIONESM.cordenpaghecha = 1;
            _T_TREPOSICIONESM.cestatusfirma = 1;
            _T_TREPOSICIONESM.cdateupd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _T_TREPOSICIONESM.cuserupd = Frm_Padre._Str_Use;
            _T_TREPOSICIONESM.cidcomprob = _Int_Comprobante;
            //----------------------------------
            Program._Dat_Tablas.SubmitChanges();
            _Mtd_ActivarComprobante(_Int_Comprobante);
            return _Int_OrdenPago;
        }
        public void _Mtd_CrearReintegro(int _P_Int_Reposicion)
        {
            //----------------------------------
            int _Int_Comprobante = _Mtd_CrearComprobante(_P_Int_Reposicion);
            //----------------------------------
            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            DataContext.TREPOSICIONESM _T_TREPOSICIONESM = Program._Dat_Tablas.TREPOSICIONESM.Single(Campos => Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidreposiciones == _P_Int_Reposicion);
            _T_TREPOSICIONESM.cbanco = Convert.ToString(_Cmb_Banco.SelectedValue).Trim();
            _T_TREPOSICIONESM.cnumcuenta = Convert.ToString(_Cmb_Cuenta.SelectedValue).Trim();
            _T_TREPOSICIONESM.cestatusfirma = 1;
            _T_TREPOSICIONESM.cdateupd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _T_TREPOSICIONESM.cuserupd = Frm_Padre._Str_Use;
            _T_TREPOSICIONESM.cidcomprob = _Int_Comprobante;
            //----------------------------------
            Program._Dat_Tablas.SubmitChanges();
            //Saldamos las retenciones
            _Mtd_SaldarRetenciones(_P_Int_Reposicion.ToString());
            //Activamos el comprobante
            _Mtd_ActivarComprobante(_Int_Comprobante);
            //Imprimimos el Comprobante
            _Mtd_ImprimirComprobante(_Int_Comprobante);
        }

        /// <summary>
        /// Salda las retenciones de la reposición si esta proviene de una y tiene retenciones cargadas
        /// </summary>
        /// <param name="_P_Str_cidreposiciones"></param>
        private void _Mtd_SaldarRetenciones(string _P_Str_cidreposiciones)
        {
            var _Str_Sql = "SELECT TREPOSICIONESD.cproveedor, TREPOSICIONESD.ctipodocument, TREPOSICIONESD.cnumdocu " +
                       "FROM TREPOSICIONESD INNER JOIN TCONFIGCXP ON TREPOSICIONESD.ccompany = TCONFIGCXP.ccompany AND (TREPOSICIONESD.ctipodocument = TCONFIGCXP.ctipdocretiva OR TREPOSICIONESD.ctipodocument = TCONFIGCXP.ctipdocretISLR) " +
                       "WHERE TREPOSICIONESD.cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND TREPOSICIONESD.ccompany='" + Frm_Padre._Str_Comp + "' AND TREPOSICIONESD.cidreposiciones='" + _P_Str_cidreposiciones + "'";
            var _Ds_Retenciones = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Sql);
            if (_Ds_Retenciones.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _DRow in _Ds_Retenciones.Tables[0].Rows)
                {
                    //Datos
                    var _Str_Proveedor = _DRow["cproveedor"].ToString();
                    //Saldamos
                    _Str_Sql = "UPDATE TFACTPPAGARM SET csaldo=0,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_Proveedor + "' AND ctipodocument='" + _DRow[1].ToString() + "' AND cnumdocu='" + _DRow[2].ToString() + "' AND csaldo<>0";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                    _Str_Sql = "UPDATE TMOVCXPM SET csaldo=0,cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cproveedor='" + _Str_Proveedor + "' AND ctipodocument='" + _DRow[1].ToString() + "' AND cnumdocu='" + _DRow[2].ToString() + "' AND csaldo<>0";
                    Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
                }
            }
        }

        private void _Mtd_ImprimirComprobante(int _P_Str_Comprobante)
        {
            try
            {
                PrintDialog _Print = new PrintDialog();
            _PrintComprob:
                if (_Print.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    REPORTESS _Frm = new REPORTESS(new[] { "vst_reportecomprobante" }, "", "T3.Report.rcomprobante", "Section1", "cabecera", "rif", "nit", "ccompany='" + Frm_Padre._Str_Comp + "' and cidcomprob='" + _P_Str_Comprobante + "'", _Print, true);
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

        private void _Mtd_ActivarComprobante(int _P_Int_Comprobante)
        {
            string _Str_Cadena = "UPDATE TCOMPROBANC SET cstatus='0',cdateupd=getdate() WHERE ccompany='" + Frm_Padre._Str_Comp + "' AND cidcomprob='" + _P_Int_Comprobante.ToString() + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }

        private bool _Mtd_FacturaIvaCredNoComp(int _P_Int_Reposicion, int _P_Int_ReposicionDetalle)
        {
            string _Str_Cadena = "SELECT civacrednocomp FROM TREPOSICIONESD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidreposiciones='" + _P_Int_Reposicion + "' AND ciddreposiciones='" + _P_Int_ReposicionDetalle + "' AND civacrednocomp='1'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        private void Frm_ReposicionCxP_Aprobacion_Load(object sender, EventArgs e)
        {
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Mtd_Sorted(_Dg_Comprobante);
        }

        private void _Cmb_Banco_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarBanco();
        }

        private void _Cmb_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Banco.SelectedIndex > 0)
            {
                _Mtd_CargarCtaBanco(Convert.ToString(_Cmb_Banco.SelectedValue));
                _Cmb_Cuenta.Enabled = true; }
            else
            { _Dg_Comprobante.Rows.Clear(); _Bt_Aprobar.Enabled = false; _Txt_Concepto.Enabled = false; _Cmb_Cuenta.Enabled = false; _Cmb_Cuenta.DataSource = null; }
        }

        private void _Cmb_Cuenta_DropDown(object sender, EventArgs e)
        {
            _Dg_Comprobante.Rows.Clear();
            _Bt_Aprobar.Enabled = false;
            _Txt_Concepto.Enabled = false;
            _Mtd_CargarCtaBanco(Convert.ToString(_Cmb_Banco.SelectedValue));
        }

        private void _Cmb_Cuenta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _Bt_Aprobar.Enabled = _Cmb_Cuenta.SelectedIndex > 0;
            _Txt_Concepto.Enabled = _Cmb_Cuenta.SelectedIndex > 0;
            if (_Cmb_Cuenta.SelectedIndex > 0)
            { Cursor = Cursors.WaitCursor; _Dg_Comprobante.Rows.Clear(); _Mtd_MostrarComprobante(_Int_Reposicion); _Mtd_FilaBanco(Convert.ToString(_Cmb_Banco.SelectedValue).Trim(), Convert.ToString(_Cmb_Cuenta.SelectedValue).Trim()); Cursor = Cursors.Default; }
            else
            { _Dg_Comprobante.Rows.Clear(); }
        }

        private void _Bt_Aprobar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            var _Bol_Error = false;
            if (_G_Dec_MontoAReponer > 0)
            {
                if (_Txt_Concepto.Text.Trim().Length == 0)
                {
                    _Er_Error.SetError(_Txt_Concepto, "Información requerida!!!");
                    _Bol_Error = true;
                }
                if (_Cmb_Banco.SelectedIndex == -1 || _Cmb_Banco.SelectedIndex == 0)
                {
                    _Er_Error.SetError(_Cmb_Banco, "Información requerida!!!");
                    _Bol_Error = true;
                }
                if (_Cmb_Cuenta.SelectedIndex == -1 || _Cmb_Cuenta.SelectedIndex == 0)
                {
                    _Er_Error.SetError(_Cmb_Cuenta, "Información requerida!!!");
                    _Bol_Error = true;
                }
            }
            else if (_G_Dec_MontoAReponer < 0)
            {
                if (_Cmb_Banco.SelectedIndex == -1 || _Cmb_Banco.SelectedIndex == 0)
                {
                    _Er_Error.SetError(_Cmb_Banco, "Información requerida!!!");
                    _Bol_Error = true;
                }
                if (_Cmb_Cuenta.SelectedIndex == -1 || _Cmb_Cuenta.SelectedIndex == 0)
                {
                    _Er_Error.SetError(_Cmb_Cuenta, "Información requerida!!!");
                    _Bol_Error = true;
                }
                if (_Txt_NumeroDocumento.Text.Trim().Length == 0)
                {
                    _Er_Error.SetError(_Txt_NumeroDocumento, "Información requerida!!!");
                    _Bol_Error = true;
                }
            }

            //Verificamos las cuentas del comprobante
            if (_Mtd_ComprobanteConCuentasVacias())
            {
                MessageBox.Show(
                    "El comprobante esta errado, por favor envie un ticket con un captura de pantalla de este error",
                    "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Bol_Error = true;
            }

            if (_Bol_Error)
                return;

            //Si todo va bien
            _Pnl_Clave.Visible = true;
        }

        private bool _Mtd_ComprobanteConCuentasVacias()
        {
            var _Int_Filas = 0;
            foreach (DataGridViewRow _Fila in _Dg_Comprobante.Rows)
            {
                //Vemos si es la fila de totales
                if (!((_Fila.Cells[0].Value == null) && (_Fila.Cells[2].Value.ToString().Trim() == "TOTAL")))
                {
                    if (_Fila.Cells[0].Value.ToString().Trim() == "")
                    {
                        _Int_Filas++;
                    }
                }
            }
            return _Int_Filas > 0;
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Pnl_Superior.Enabled = false; _Dg_Comprobante.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Pnl_Superior.Enabled = true; _Dg_Comprobante.Enabled = true; }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                Cursor = Cursors.WaitCursor;

                if (_G_Dec_MontoAReponer > 0)
                {
                    int _Int_OrdenPago = _Mtd_CrearOrdenPago(_Int_Reposicion);
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                    Cursor = Cursors.Default;
                    MessageBox.Show("La operación ha sido realizada correctamente.\nSe ha creado la orden de pago número " + _Int_OrdenPago.ToString() + ".", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (_G_Dec_MontoAReponer < 0)
                {
                    _Mtd_CrearReintegro(_Int_Reposicion);
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                    Cursor = Cursors.Default;
                    MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _Mtd_CrearReintegro(_Int_Reposicion);
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                    Cursor = Cursors.Default;
                    MessageBox.Show("La operación ha sido realizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Txt_NumeroDocumento_TextChanged(object sender, EventArgs e)
        {
            if (_G_Dec_MontoAReponer != 0 && _Dg_Comprobante.Rows.Count > 0) _Mtd_FilaBanco(Convert.ToString(_Cmb_Banco.SelectedValue).Trim(), Convert.ToString(_Cmb_Cuenta.SelectedValue).Trim());
        }

        private void _Dtp_FechaDocumento_ValueChanged(object sender, EventArgs e)
        {
            if (_G_Dec_MontoAReponer != 0 && _Dg_Comprobante.Rows.Count > 0) _Mtd_FilaBanco(Convert.ToString(_Cmb_Banco.SelectedValue).Trim(), Convert.ToString(_Cmb_Cuenta.SelectedValue).Trim());
        }

        private void _Rb_Cheque_CheckedChanged(object sender, EventArgs e)
        {
            if (_G_Dec_MontoAReponer != 0 && _Dg_Comprobante.Rows.Count > 0) _Mtd_FilaBanco(Convert.ToString(_Cmb_Banco.SelectedValue).Trim(), Convert.ToString(_Cmb_Cuenta.SelectedValue).Trim());
        }

        private void _Rb_Transferencia_CheckedChanged(object sender, EventArgs e)
        {
            if (_G_Dec_MontoAReponer != 0 && _Dg_Comprobante.Rows.Count > 0) _Mtd_FilaBanco(Convert.ToString(_Cmb_Banco.SelectedValue).Trim(), Convert.ToString(_Cmb_Cuenta.SelectedValue).Trim());
        }
    }
}
