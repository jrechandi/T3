using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.Linq.SqlClient;
namespace T3
{
    public partial class Frm_ReposicionCxP : Form
    {
        public enum _TipoDocumentoReposicion
        {
            Factura = 0,
            Anticipo = 1,
            RetencionISLR = 2,
            RetencionIVA = 3,
            RetencionPatente =4
        }

        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        public Frm_ReposicionCxP()
        {
            InitializeComponent();
            _Mtd_Color_Estandar(this);
            _Mtd_Actualizar();
        }
        public Frm_ReposicionCxP(int _P_Int_Sw)
        {
            InitializeComponent();
            _Mtd_Color_Estandar(this);
            if (_P_Int_Sw == 1)
            { _Rb_Incompletas.Checked = true; }
            else
            { _Rb_PorAprobar.Checked = true; }
        }
        private void _Mtd_Color_Estandar(Control _P_Ctrl_Control)
        {
            foreach (Control _Ctrl in _P_Ctrl_Control.Controls)
            {
                if (_Ctrl.Controls.Count > 0)
                {
                    _Mtd_Color_Estandar(_Ctrl);
                }
                else
                {
                    if (_Ctrl.GetType() != typeof(RadioButton))
                    { new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco(); }
                }
            }
        }
        private void _Mtd_HeaderText(DataGridView _P_Dg_Grid)
        {
            foreach (DataGridViewColumn _Dg_Col in _P_Dg_Grid.Columns)
            {
                _Dg_Col.HeaderText = _Dg_Col.HeaderText.Replace("_", " ");
            }
        }
        private string _Mtd_FormtadoMoneda(decimal? _P_Dec_Monto)
        {
            return Convert.ToDecimal(_P_Dec_Monto).ToString("#,##0.00");
        }
        private void _Mtd_CargarCombo()
        {
            _Cls_CargarCombo _Cls_Cargar = new _Cls_CargarCombo();
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("0", "..."));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("G", "REPOSICIÓN DE GASTOS"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("C", "REPOSICIÓN DE CAJA CHICA"));
            _Cmb_TipoReposicion.DataSource = _Cls_Cargar._List_Lista;
            _Cmb_TipoReposicion.ValueMember = "Value";
            _Cmb_TipoReposicion.DisplayMember = "Display";
            _Cmb_TipoReposicion.SelectedValue = "0";
        }

        private void _Mtd_CargarEntidades()
        {
            _Cls_CargarCombo _Cls_Cargar = new _Cls_CargarCombo();
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("0", "..."));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("1", "VENDEDOR"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("2", "TRANSPORTISTA"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("3", "OTROS"));
            _Cmb_Entidad.DataSource = _Cls_Cargar._List_Lista;
            _Cmb_Entidad.ValueMember = "Value";
            _Cmb_Entidad.DisplayMember = "Display";
            _Cmb_Entidad.SelectedValue = "0";
        }

        public void _Mtd_Actualizar()
        {
            Cursor = Cursors.WaitCursor;
            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            var _Var_Datos = from campos in Program._Dat_Tablas.TREPOSICIONESM
                             where campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & campos.ccompany == Frm_Padre._Str_Comp
                             select new { Reposición = campos.cidreposiciones, Tipo = campos.ctipreposicion == 'G' ? "GASTOS" : "CAJA CHICA", Descripción = campos.cdescripcionrepo, Monto = _Mtd_FormtadoMoneda(campos.cmontocancelar), campos.cestatusreposicion, campos.cestatusfirma };
            //_Ctrl_BusquedaLinq1._Int_Hasta = Convert.ToInt32(_Var_Datos.Count() / 2);
            if (_Rb_Incompletas.Checked)
            { _Var_Datos = _Var_Datos.Where(c => c.cestatusreposicion == 0); }
            else if (_Rb_PorAprobar.Checked)
            { _Var_Datos = _Var_Datos.Where(c => c.cestatusreposicion == 1 & c.cestatusfirma == 0); }
            else if (_Rb_Aprobadas.Checked)
            { _Var_Datos = _Var_Datos.Where(c => c.cestatusreposicion == 1 & c.cestatusfirma == 1); }
            if (_Rb_Rechazadas.Checked)
            { _Var_Datos = _Var_Datos.Where(c => c.cestatusreposicion == 1 & c.cestatusfirma == 9); }
            if (_Ctrl_BusquedaLinq1._Tool_Texto.Text.Trim().Length > 0)
            {
                if (_Ctrl_BusquedaLinq1._Tool_Items.Tag.ToString() == "Reposición")
                { _Var_Datos = _Var_Datos.Where(c => Convert.ToString(c.Reposición).Contains(_Ctrl_BusquedaLinq1._Tool_Texto.Text)); }
                else
                { _Var_Datos = _Var_Datos.Where(c => Convert.ToString(c.Descripción).Contains(_Ctrl_BusquedaLinq1._Tool_Texto.Text)); }
            }
            //.Distinct().Skip(_Ctrl_BusquedaLinq1._Int_Desde).Take(2);
            _Dg_Grid.DataSource = _Var_Datos;
            _Dg_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Dg_Grid.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Grid.Columns["cestatusreposicion"].Visible = false;
            _Dg_Grid.Columns["cestatusfirma"].Visible = false;
            Cursor = Cursors.Default;
        }
        public void _Mtd_ActualizarDetalle(int _P_Int_Reposicion)
        {
            Cursor = Cursors.WaitCursor;
            Program._Dat_Vistas = new DataContext._Dat_CntxVistasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            var _Var_Datos = from CamposVST_REPOSICIONES_DET in Program._Dat_Vistas.VST_REPOSICIONES_DET
                             where CamposVST_REPOSICIONES_DET.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & CamposVST_REPOSICIONES_DET.ccompany == Frm_Padre._Str_Comp & CamposVST_REPOSICIONES_DET.cidreposiciones == _P_Int_Reposicion
                             select new {
                                 TipoDocumento = CamposVST_REPOSICIONES_DET.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionPatente ? "RETENCIÓN PATENTE" : CamposVST_REPOSICIONES_DET.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.Factura ? "FACTURA" : CamposVST_REPOSICIONES_DET.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.Anticipo ? "ANTICIPO" : CamposVST_REPOSICIONES_DET.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionISLR ? "RETENCION ISLR" : CamposVST_REPOSICIONES_DET.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionIVA ? "RETENCION IVA" : "",
                                 Proveedor = CamposVST_REPOSICIONES_DET.c_nomb_comer, 
                                 NºDocumento = CamposVST_REPOSICIONES_DET.cnumdocu,
                                 NºDocumentoAfectado = CamposVST_REPOSICIONES_DET.cnumdocumafec,
                                 NºControl = CamposVST_REPOSICIONES_DET.cnumdocuctrl, 
                                 Concepto = CamposVST_REPOSICIONES_DET.cconcepto, 
                                 Monto = _Mtd_FormtadoMoneda(CamposVST_REPOSICIONES_DET.cmontototal), 
                                 CamposVST_REPOSICIONES_DET.ciddreposiciones, 
                                 CamposVST_REPOSICIONES_DET.cmontototal, 
                                 CamposVST_REPOSICIONES_DET.canticipogasto, 
                                 CamposVST_REPOSICIONES_DET.ctipodocumentodetalle,
                              };
            _Dg_Detalle.DataSource = _Var_Datos;
            _Dg_Detalle.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _Dg_Detalle.Columns["ciddreposiciones"].Visible = false;
            _Dg_Detalle.Columns["cmontototal"].Visible = false;
            _Dg_Detalle.Columns["canticipogasto"].Visible = false;
            _Dg_Detalle.Columns["ctipodocumentodetalle"].Visible = false;

            //Si esta activo el swicheo de los reintegros
            if (!CLASES._Cls_Varios_Metodos._Mtd_EstaActivoReintegros())
            {
                _Dg_Detalle.Columns["NºDocumentoAfectado"].Visible = false;
            }

            _Dg_Detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //----------------------------------
            decimal _Dcm_TotalDebe = 0, _Dcm_TotalHaber = 0, _Dcm_TotalAnticipos = 0, _Dcm_TotalRetencionesISLR = 0, _Dcm_TotalRetecionesIVA = 0, _Dcm_TotalRetecionesPatente=0;
            if (_Var_Datos.Where(c => !Convert.ToBoolean(c.canticipogasto)).Count() > 0)
            { _Dcm_TotalDebe = (decimal)_Var_Datos.Where(c => !Convert.ToBoolean(c.canticipogasto)).Select(c => c.cmontototal).Sum(); }

            if (_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.Anticipo).Any())
            { _Dcm_TotalAnticipos = (decimal)_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.Anticipo).Select(c => c.cmontototal).Sum(); }
            if (_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionISLR).Any())
            { _Dcm_TotalRetencionesISLR = (decimal)_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionISLR).Select(c => c.cmontototal).Sum(); }
            if (_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionIVA).Any())
            { _Dcm_TotalRetecionesIVA = (decimal)_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionIVA).Select(c => c.cmontototal).Sum(); }
            if (_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionPatente).Any())
            { _Dcm_TotalRetecionesPatente = (decimal)_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionPatente).Select(c => c.cmontototal).Sum(); }
            _Dcm_TotalHaber = _Dcm_TotalAnticipos + _Dcm_TotalRetencionesISLR + _Dcm_TotalRetecionesIVA + _Dcm_TotalRetecionesPatente;

            decimal _Dcm_TotalBanco = _Dcm_TotalDebe - _Dcm_TotalHaber;
            //----------------------------------
            _Txt_TotalDocumentos.Text = _Mtd_FormtadoMoneda((decimal?)_Dcm_TotalDebe);
            _Txt_TotalAnticipos.Text = _Mtd_FormtadoMoneda((decimal?)_Dcm_TotalAnticipos);
            _Txt_TotalRetencionesISLR.Text = _Mtd_FormtadoMoneda((decimal?)_Dcm_TotalRetencionesISLR);
            _Txt_TotalRetencionesIVA.Text = _Mtd_FormtadoMoneda((decimal?)_Dcm_TotalRetecionesIVA);
            _Txt_TotalRetencionesPatente.Text = _Mtd_FormtadoMoneda((decimal?)_Dcm_TotalRetecionesPatente);
            _Txt_TotalReponer.Text = _Mtd_FormtadoMoneda((decimal?)_Dcm_TotalBanco);
            Cursor = Cursors.Default;
        }
        private void _Mtd_Habilitar(bool _bol_Boleano)
        {
            _Cmb_TipoReposicion.Enabled = _bol_Boleano;
            _Txt_Motivo.Enabled = _bol_Boleano;
            _Cmb_Entidad.Enabled = _bol_Boleano & Convert.ToString(_Cmb_TipoReposicion.SelectedValue) == "G";
            _Bt_Buscar.Enabled = _bol_Boleano & _Cmb_Entidad.SelectedIndex > 0 & Convert.ToString(_Cmb_Entidad.SelectedValue).Trim() != "3";
            _Bt_EditarMotivo.Enabled = _bol_Boleano;
            _Txt_Beneficiario.Enabled = _bol_Boleano;
            if (_Cmb_Entidad.SelectedValue != null)
            {
                _Txt_Beneficiario.Enabled = false;
            }          
            _Bt_Ingresar.Enabled = _bol_Boleano;
            _Bt_Descontar.Enabled = _bol_Boleano & _Dg_Detalle.RowCount > 0 & Convert.ToString(_Cmb_TipoReposicion.SelectedValue) == "G";
            _Bt_Descontar_RetencionISRL.Enabled = _bol_Boleano;
            _Bt_Descontar_RetencionIVA.Enabled = _bol_Boleano;
            _Bt_Descontar_RetencionPatente.Enabled = _bol_Boleano;
        }
        public void _Mtd_Ini()
        {
            _Mtd_CargarCombo();
            _Mtd_CargarEntidades();
            _Txt_Reposicion.Text = "";
            _Txt_FechaEmision.Text = "";
            _Txt_Motivo.Text = "";
            _Txt_Entidad.Tag = "";
            _Txt_Entidad.Text = "";
            _Txt_Beneficiario.Text = "";
            _Txt_TotalReponer.Text = "";
            _Txt_TotalAnticipos.Text = "";
            _Txt_TotalDocumentos.Text = "";
            _Txt_Rif.Text = "";
            _Dg_Detalle.DataSource = null;
            _Bt_Aprobar.Visible = false;
            _Bt_Rechazar.Visible = false;
        }
        public void _Mtd_Nuevo()
        {
            _Mtd_Ini();
            _Mtd_Habilitar(false);
            _Cmb_TipoReposicion.Enabled = true;
            _Tb_Tab.SelectedIndex = 1;
            _Cmb_TipoReposicion.Focus();
        }
        private bool _Mtd_VerifDetalleReposicion(int _P_Int_Reposicion)
        {
            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            return (from Campos in Program._Dat_Tablas.TREPOSICIONESD
                    where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidreposiciones == _P_Int_Reposicion & Campos.canticipogasto == 0
                    select Campos).Count() > 0;
        }
        private bool _Mtd_VerifDetalleAnticipos(int _P_Int_Reposicion)
        {
            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            return (from Campos in Program._Dat_Tablas.TREPOSICIONESD
                    where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidreposiciones == _P_Int_Reposicion & Campos.canticipogasto == 1
                    select Campos).Count() > 0;
        }
        private bool _Mtd_ReposicionGastos(int _P_Int_Reposicion)
        {
            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            return (from Campos in Program._Dat_Tablas.TREPOSICIONESM
                    where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidreposiciones == _P_Int_Reposicion & Campos.ctipreposicion == 'G'
                    select Campos).Count() > 0;
        }
        public void _Mtd_InsertarMaestra(int _P_Int_Reposicion, decimal _P_Dec_MontoTotal, decimal _P_Dec_BaseImponible, decimal _P_Dec_Impuesto, decimal _P_Dec_MontoExento, bool _P_Bol_Finalizar)
        {
            DataContext.TREPOSICIONESM _T_TREPOSICIONESM = new T3.DataContext.TREPOSICIONESM()
            {
                cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp),
                ccompany = Frm_Padre._Str_Comp,
                cidreposiciones = _P_Int_Reposicion,
                ctipreposicion = Convert.ToChar(_Cmb_TipoReposicion.SelectedValue),
                cfechaemision = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ(),
                cmontacco = Convert.ToInt32(Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()))),
                cyearacco = Convert.ToInt32(Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate()))),
                cdescripcionrepo = _Txt_Motivo.Text.Trim().ToUpper(),
                cmontototal = _P_Dec_MontoTotal,
                cmontosi = _P_Dec_BaseImponible,
                cmontoimp = _P_Dec_Impuesto,
                cmontoexento = _P_Dec_MontoExento,
                cbeneficiario = _Txt_Beneficiario.Text.Trim().ToUpper(),
                cdateadd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ(),
                cuseradd = Frm_Padre._Str_Use,
                cestatusreposicion = Convert.ToByte(_P_Bol_Finalizar),
                cestatusfirma = 0,
                ctipoentidad = Convert.ToByte(Convert.ToInt32(_Cmb_Entidad.SelectedValue)),
                centidad = Convert.ToString(_Txt_Entidad.Tag),
                crif=_Txt_Rif.Text               
            };
            Program._Dat_Tablas.TREPOSICIONESM.InsertOnSubmit(_T_TREPOSICIONESM);
            Program._Dat_Tablas.SubmitChanges();
        }
        public void _Mtd_ModificarMaestra(int _P_Int_Reposicion, bool _P_Bol_Finalizar)
        {
            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            //----------------------
            decimal _Dcm_MontoSin = 0, _Dcm_MontoExento = 0, _Dcm_MontoImp = 0;
            var _Var_Datos = from Campos in Program._Dat_Tablas.TREPOSICIONESD
                             where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidreposiciones == _P_Int_Reposicion
                             select new { Campos.cmontosi, Campos.cmontoexento, Campos.cmontoimp, Campos.cmontototal, Campos.canticipogasto, Campos.ctipodocumentodetalle };
            _Dcm_MontoSin = (decimal)_Var_Datos.ToList().Select(c => c.cmontosi).Sum();
            _Dcm_MontoExento = (decimal)_Var_Datos.ToList().Select(c => c.cmontoexento).Sum();
            _Dcm_MontoImp = (decimal)_Var_Datos.ToList().Select(c => c.cmontoimp).Sum();
            //----------------------
            decimal _Dcm_TotalDebe = 0, _Dcm_TotalHaber = 0, _Dcm_TotalAnticipos = 0, _Dcm_TotalRetencionesISLR = 0, _Dcm_TotalRetecionesIVA = 0, _Dcm_TotalRetecionesPatente = 0;

            if (_Var_Datos.Where(c => !Convert.ToBoolean(c.canticipogasto)).Count() > 0)
            { _Dcm_TotalDebe = (decimal)_Var_Datos.Where(c => !Convert.ToBoolean(c.canticipogasto)).Select(c => c.cmontototal).Sum(); }

            if (_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.Anticipo).Any())
            { _Dcm_TotalAnticipos = (decimal)_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.Anticipo).Select(c => c.cmontototal).Sum(); }
            if (_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionISLR).Any())
            { _Dcm_TotalRetencionesISLR = (decimal)_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionISLR).Select(c => c.cmontototal).Sum(); }
            if (_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionIVA).Any())
            { _Dcm_TotalRetecionesIVA = (decimal)_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionIVA).Select(c => c.cmontototal).Sum(); }
            if (_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionPatente).Any())
            { _Dcm_TotalRetecionesPatente = (decimal)_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionPatente).Select(c => c.cmontototal).Sum(); }

            _Dcm_TotalHaber = _Dcm_TotalAnticipos + _Dcm_TotalRetencionesISLR + _Dcm_TotalRetecionesIVA + _Dcm_TotalRetecionesPatente;
            
            decimal _Dcm_TotalBanco = _Dcm_TotalDebe - _Dcm_TotalHaber;
            //----------------------
            DataContext.TREPOSICIONESM _T_TREPOSICIONESM = Program._Dat_Tablas.TREPOSICIONESM.Single(Campos => Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidreposiciones == _P_Int_Reposicion);
            _T_TREPOSICIONESM.ctipreposicion = Convert.ToChar(_Cmb_TipoReposicion.SelectedValue);
            _T_TREPOSICIONESM.cfechaemision = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _T_TREPOSICIONESM.cmontacco = Convert.ToInt32(Clases._Cls_ProcesosCont._Mtd_ContableMes(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())));
            _T_TREPOSICIONESM.cyearacco = Convert.ToInt32(Clases._Cls_ProcesosCont._Mtd_ContableAno(_Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDate())));
            _T_TREPOSICIONESM.cdescripcionrepo = _Txt_Motivo.Text.Trim().ToUpper();
            _T_TREPOSICIONESM.cmontocancelar = _Dcm_TotalBanco;
            _T_TREPOSICIONESM.cmontototal = _Dcm_MontoSin + _Dcm_MontoExento + _Dcm_MontoImp;
            _T_TREPOSICIONESM.cmontosi = _Dcm_MontoSin;
            _T_TREPOSICIONESM.cmontoimp = _Dcm_MontoImp;
            _T_TREPOSICIONESM.cmontoexento = _Dcm_MontoExento;
            _T_TREPOSICIONESM.cbeneficiario = _Txt_Beneficiario.Text.Trim().ToUpper();
            _T_TREPOSICIONESM.cestatusreposicion = Convert.ToByte(_P_Bol_Finalizar);
            _T_TREPOSICIONESM.cestatusfirma = 0;
            _T_TREPOSICIONESM.cdateupd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _T_TREPOSICIONESM.cuserupd = Frm_Padre._Str_Use;
            _T_TREPOSICIONESM.ctipoentidad = Convert.ToByte(Convert.ToInt32(_Cmb_Entidad.SelectedValue));
            _T_TREPOSICIONESM.centidad = Convert.ToString(_Txt_Entidad.Tag);
            _T_TREPOSICIONESM.crif = Convert.ToString(_Txt_Rif.Text);
            Program._Dat_Tablas.SubmitChanges();
        }
        private void _Mtd_InsertarDetalle(int _P_Int_Reposicion, int _P_Int_ReposicionDetalle, _TipoDocumentoReposicion _P_TipoDocumentoReposicion , int _P_Int_CodigoDocumento, string _P_Str_ccuenta, string _P_Str_concepto)
        {
            //Variblaes
            var _Str_TipoDocument = "";
            var _Str_Document = "";
            var _Str_Cproveedor = "";
            DateTime? _Dt_cfechaEmision = null;
            Decimal? _Dt_cmontototal = null;
            int? _Int_OrdenPago = null;
            var _Str_Cadena = "";
            DataSet _Ds = null;
            var _Str_cnumdocumafec = "";

            //En funcion al tipo de documento a insertar
            switch (_P_TipoDocumentoReposicion)
            {
                case _TipoDocumentoReposicion.Anticipo:
                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    Program._Dat_Vistas = new DataContext._Dat_CntxVistasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
                    _Int_OrdenPago = _Mtd_OrdenPagoEmisionCheq(_P_Int_CodigoDocumento);
                    //--------------
                    var _Var_DatosTemp = from Campos in Program._Dat_Vistas.VST_REPOS_ANTI_COUNT
                                         where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidordpago == _Int_OrdenPago & Campos.ccount == Convert.ToString(_Txt_Cuenta.Tag).Trim()
                                         select new {Campos.ctdocument, Campos.cnumdocu};
                    if (_Var_DatosTemp.Count() > 0)
                    {
                        _Str_TipoDocument = _Var_DatosTemp.ToList().First().ctdocument;
                        _Str_Document = _Var_DatosTemp.ToList().First().cnumdocu;
                    }
                    //--------------
                    var _Var_Datos = (from Campos in Program._Dat_Vistas.VST_CHEQUES_EMITIDOS
                                      where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidemisioncheq == _P_Int_CodigoDocumento
                                      select new {Campos.cfechaemision, Campos.cmontototal}).Single();
                    
                    //Pasamos los valores
                    _Dt_cfechaEmision = _Var_Datos.cfechaemision;
                    _Dt_cmontototal = _Var_Datos.cmontototal;

                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    break;
                case _TipoDocumentoReposicion.RetencionISLR:
                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    _Str_Cadena = "SELECT TCONFIGCXP.ctipdocretislr as ctipodocumento, cidcomprobislr AS cnumdocu, cfechaemiislr AS cfechaemision, ctotretenido As cmontototal, TCOMPROBANISLRC.cproveedor, cnumdocumafec  " +
                                  "FROM TCOMPROBANISLRC INNER JOIN TCONFIGCXP ON TCOMPROBANISLRC.ccompany = TCONFIGCXP.ccompany " +
                                  "WHERE TCOMPROBANISLRC.ccompany='" + Frm_Padre._Str_Comp + "' and TCOMPROBANISLRC.cidcomprobislr='" + _P_Int_CodigoDocumento + "' and TCOMPROBANISLRC.cdelete='0'"; 
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_TipoDocument = _Ds.Tables[0].Rows[0]["ctipodocumento"].ToString();
                        _Str_Document = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString();
                        _Dt_cfechaEmision = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechaemision"]);
                        _Dt_cmontototal = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cmontototal"]);
                        _Str_Cproveedor = _Ds.Tables[0].Rows[0]["cproveedor"].ToString();
                        _Str_cnumdocumafec = _Ds.Tables[0].Rows[0]["cnumdocumafec"].ToString();
                    }
                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    break;
                case _TipoDocumentoReposicion.RetencionIVA:
                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    _Str_Cadena = "SELECT TCONFIGCXP.ctipdocretiva as ctipodocumento, cidcomprobret AS cnumdocu, cfechaemiret AS cfechaemision, cretenido As cmontototal, TCOMPROBANRETC.cproveedor, cnumdocumafec " +
                                  "FROM TCOMPROBANRETC INNER JOIN TCONFIGCXP ON TCOMPROBANRETC.ccompany = TCONFIGCXP.ccompany " +
                                  "WHERE TCOMPROBANRETC.ccompany='" + Frm_Padre._Str_Comp + "' and TCOMPROBANRETC.cidcomprobret='" + _P_Int_CodigoDocumento + "' and TCOMPROBANRETC.cdelete='0'"; 
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_TipoDocument = _Ds.Tables[0].Rows[0]["ctipodocumento"].ToString();
                        _Str_Document = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString();
                        _Dt_cfechaEmision = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechaemision"]);
                        _Dt_cmontototal = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cmontototal"]);
                        _Str_Cproveedor = _Ds.Tables[0].Rows[0]["cproveedor"].ToString();
                        _Str_cnumdocumafec = _Ds.Tables[0].Rows[0]["cnumdocumafec"].ToString();
                    }
                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    break;
                case _TipoDocumentoReposicion.RetencionPatente:
                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    _Str_Cadena = "SELECT TCONFIGCXP.ctipodocretpat as ctipodocumento, cidcomprobret AS cnumdocu, cfechaemiret AS cfechaemision, cretenido As cmontototal, TCOMPROBANRETPAT.cproveedor, cnumdocumafec " +
                                  "FROM TCOMPROBANRETPAT INNER JOIN TCONFIGCXP ON TCOMPROBANRETPAT.ccompany = TCONFIGCXP.ccompany " +
                                  "WHERE TCOMPROBANRETPAT.caprobado='1' and TCOMPROBANRETPAT.ccompany='" + Frm_Padre._Str_Comp + "' and TCOMPROBANRETPAT.cidcomprobret='" + _P_Int_CodigoDocumento + "' and TCOMPROBANRETPAT.cdelete='0'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_TipoDocument = _Ds.Tables[0].Rows[0]["ctipodocumento"].ToString();
                        _Str_Document = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString();
                        _Dt_cfechaEmision = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechaemision"]);
                        _Dt_cmontototal = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cmontototal"]);
                        _Str_Cproveedor = _Ds.Tables[0].Rows[0]["cproveedor"].ToString();
                        _Str_cnumdocumafec = _Ds.Tables[0].Rows[0]["cnumdocumafec"].ToString();
                    }
                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    break;
            }

            //Guardamos el Detalle
            DataContext.TREPOSICIONESD _T_TREPOSICIONESD = new T3.DataContext.TREPOSICIONESD()
            {
                cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp),
                ccompany = Frm_Padre._Str_Comp,
                cidreposiciones = _P_Int_Reposicion,
                ciddreposiciones = _P_Int_ReposicionDetalle,
                ctipodocument = _Str_TipoDocument,
                cnumdocu = _Str_Document,
                cfechaemision = _Dt_cfechaEmision,
                cconcepto = _P_Str_concepto.Trim().ToUpper(),
                ccuentaexep = _P_Str_ccuenta,
                cmontototal = _Dt_cmontototal,
                canticipogasto = 1,
                cidordpagoanticipo = _Int_OrdenPago,
                ctipodocumentodetalle = (byte) _P_TipoDocumentoReposicion,
                cproveedor = _Str_Cproveedor,
                cnumdocumafec = _Str_cnumdocumafec,
            };
            Program._Dat_Tablas.TREPOSICIONESD.InsertOnSubmit(_T_TREPOSICIONESD);
            Program._Dat_Tablas.SubmitChanges();

            //Marcamos las retenciones como usadas
            switch (_P_TipoDocumentoReposicion)
            {
                case _TipoDocumentoReposicion.RetencionIVA:
                case _TipoDocumentoReposicion.RetencionISLR:
                    _Mtd_MarcarRetencion(_Str_Cproveedor, _Str_TipoDocument, _Str_Document, true);
                    break;
            }
        }
        private void _Mtd_ModificarDetalle(int _P_Int_Reposicion, int _P_Int_ReposicionDetalle, _TipoDocumentoReposicion _P_TipoDocumentoReposicion, int _P_Int_CodigoDocumento, string _P_Str_ccuenta, string _P_Str_concepto)
        {
            //Variblaes
            var _Str_TipoDocument = "";
            var _Str_Document = "";
            var _Str_Cproveedor = "";
            DateTime? _Dt_cfechaEmision = null;
            Decimal? _Dt_cmontototal = null;
            int? _Int_OrdenPago = null;
            var _Str_Cadena = "";
            DataSet _Ds = null;
            var _Str_cnumdocumafec = "";

            //En funcion al tipo de documento a insertar
            switch (_P_TipoDocumentoReposicion)
            {
                case _TipoDocumentoReposicion.Anticipo:
                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    Program._Dat_Vistas = new DataContext._Dat_CntxVistasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
                    _Int_OrdenPago = _Mtd_OrdenPagoEmisionCheq(_P_Int_CodigoDocumento);
                    //--------------
                    var _Var_DatosTemp = from Campos in Program._Dat_Vistas.VST_REPOS_ANTI_COUNT
                                         where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidordpago == _Int_OrdenPago & Campos.ccount == Convert.ToString(_Txt_Cuenta.Tag).Trim()
                                         select new { Campos.ctdocument, Campos.cnumdocu };
                    if (_Var_DatosTemp.Count() > 0)
                    {
                        _Str_TipoDocument = _Var_DatosTemp.ToList().First().ctdocument;
                        _Str_Document = _Var_DatosTemp.ToList().First().cnumdocu;
                    }
                    //--------------
                    var _Var_Datos = (from Campos in Program._Dat_Vistas.VST_CHEQUES_EMITIDOS
                                      where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidemisioncheq == _P_Int_CodigoDocumento
                                      select new { Campos.cfechaemision, Campos.cmontototal }).Single();

                    //Pasamos los valores
                    _Dt_cfechaEmision = _Var_Datos.cfechaemision;
                    _Dt_cmontototal = _Var_Datos.cmontototal;

                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    break;
                case _TipoDocumentoReposicion.RetencionISLR:
                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    _Str_Cadena = "SELECT TCONFIGCXP.ctipdocretislr as ctipodocumento, cidcomprobislr AS cnumdocu, cfechaemiislr AS cfechaemision, ctotretenido As cmontototal, TCOMPROBANISLRC.cproveedor, cnumdocumafec  " +
                                      "FROM TCOMPROBANISLRC INNER JOIN TCONFIGCXP ON TCOMPROBANISLRC.ccompany = TCONFIGCXP.ccompany " +
                                      "WHERE TCOMPROBANISLRC.ccompany='" + Frm_Padre._Str_Comp + "' and TCOMPROBANISLRC.cidcomprobislr='" + _P_Int_CodigoDocumento + "' and TCOMPROBANISLRC.cdelete='0'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_TipoDocument = _Ds.Tables[0].Rows[0]["ctipodocumento"].ToString();
                        _Str_Document = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString();
                        _Dt_cfechaEmision = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechaemision"]);
                        _Dt_cmontototal = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cmontototal"]);
                        _Str_Cproveedor = _Ds.Tables[0].Rows[0]["cproveedor"].ToString();
                        _Str_cnumdocumafec = _Ds.Tables[0].Rows[0]["cnumdocumafec"].ToString();
                    }
                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    break;
                case _TipoDocumentoReposicion.RetencionIVA:
                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    _Str_Cadena = "SELECT TCONFIGCXP.ctipdocretiva as ctipodocumento, cidcomprobret AS cnumdocu, cfechaemiret AS cfechaemision, cretenido As cmontototal, TCOMPROBANRETC.cproveedor, cnumdocumafec " +
                                      "FROM TCOMPROBANRETC INNER JOIN TCONFIGCXP ON TCOMPROBANRETC.ccompany = TCONFIGCXP.ccompany " +
                                      "WHERE TCOMPROBANRETC.ccompany='" + Frm_Padre._Str_Comp + "' and TCOMPROBANRETC.cidcomprobret='" + _P_Int_CodigoDocumento + "' and TCOMPROBANRETC.cdelete='0'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_TipoDocument = _Ds.Tables[0].Rows[0]["ctipodocumento"].ToString();
                        _Str_Document = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString();
                        _Dt_cfechaEmision = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechaemision"]);
                        _Dt_cmontototal = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cmontototal"]);
                        _Str_Cproveedor = _Ds.Tables[0].Rows[0]["cproveedor"].ToString();
                        _Str_cnumdocumafec = _Ds.Tables[0].Rows[0]["cnumdocumafec"].ToString();
                    }
                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    break;
                case _TipoDocumentoReposicion.RetencionPatente:
                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    _Str_Cadena = "SELECT TCONFIGCXP.ctipdocretiva as ctipodocumento, cidcomprobret AS cnumdocu, cfechaemiret AS cfechaemision, cretenido As cmontototal, TCOMPROBANRETPAT.cproveedor, cnumdocumafec " +
                                      "FROM TCOMPROBANRETPAT INNER JOIN TCONFIGCXP ON TCOMPROBANRETPAT.ccompany = TCONFIGCXP.ccompany " +
                                      "WHERE TCOMPROBANRETPAT.caprobado='1' and TCOMPROBANRETPAT.ccompany='" + Frm_Padre._Str_Comp + "' and TCOMPROBANRETPAT.cidcomprobret='" + _P_Int_CodigoDocumento + "' and TCOMPROBANRETPAT.cdelete='0'";
                    _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                    if (_Ds.Tables[0].Rows.Count > 0)
                    {
                        _Str_TipoDocument = _Ds.Tables[0].Rows[0]["ctipodocumento"].ToString();
                        _Str_Document = _Ds.Tables[0].Rows[0]["cnumdocu"].ToString();
                        _Dt_cfechaEmision = Convert.ToDateTime(_Ds.Tables[0].Rows[0]["cfechaemision"]);
                        _Dt_cmontototal = Convert.ToDecimal(_Ds.Tables[0].Rows[0]["cmontototal"]);
                        _Str_Cproveedor = _Ds.Tables[0].Rows[0]["cproveedor"].ToString();
                        _Str_cnumdocumafec = _Ds.Tables[0].Rows[0]["cnumdocumafec"].ToString();
                    }
                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    break;
            }

            //Editamos el documento
            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            Program._Dat_Vistas = new DataContext._Dat_CntxVistasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            DataContext.TREPOSICIONESD _T_TREPOSICIONESD = Program._Dat_Tablas.TREPOSICIONESD.Single(c => c.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & c.ccompany == Frm_Padre._Str_Comp & c.cidreposiciones == _P_Int_Reposicion & c.ciddreposiciones == _P_Int_ReposicionDetalle);
            _T_TREPOSICIONESD.cconcepto = _P_Str_concepto.Trim().ToUpper();
            _T_TREPOSICIONESD.ccuentaexep = _P_Str_ccuenta;
            _T_TREPOSICIONESD.ctipodocument = _Str_TipoDocument;
            _T_TREPOSICIONESD.cnumdocu = _Str_Document;
            _T_TREPOSICIONESD.cfechaemision = _Dt_cfechaEmision;
            _T_TREPOSICIONESD.cmontototal = _Dt_cmontototal;
            _T_TREPOSICIONESD.cidordpagoanticipo = _Int_OrdenPago;
            _T_TREPOSICIONESD.ctipodocumentodetalle = (byte) _P_TipoDocumentoReposicion;
            _T_TREPOSICIONESD.cproveedor = _Str_Cproveedor;
            _T_TREPOSICIONESD.cnumdocumafec = _Str_cnumdocumafec;
            Program._Dat_Tablas.SubmitChanges();
        }
        public bool _Mtd_Guardar()
        {
            _Er_Error.Dispose();
            bool _Bol_RegexRif = true;
            if (_Bol_RegexRif && _Txt_Motivo.Text.Trim().Length > 0 && _Txt_Beneficiario.Text.Trim().Length > 0 && _Cmb_Entidad.SelectedIndex > 0 && _Txt_Entidad.Text.Trim().Length > 0 && _Txt_Rif.Text.Trim().Length > 0)
            {
                if (_Txt_Reposicion.Text.Trim().Length > 0)
                {
                    if (_Mtd_VerifDetalleReposicion(Convert.ToInt32(_Txt_Reposicion.Text)))
                    {
                        if (_Mtd_EsValidoDetalle(Convert.ToInt32(_Txt_Reposicion.Text)))
                        {
                            if (MessageBox.Show("Desea finalizar la reposición", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                _Mtd_ModificarMaestra(Convert.ToInt32(_Txt_Reposicion.Text), true);
                            }
                            else
                            {
                                _Mtd_ModificarMaestra(Convert.ToInt32(_Txt_Reposicion.Text), false);
                            }
                            System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                        }
                        else
                        {
                            return false;
                        }

                    }
                    else
                    { _Mtd_ModificarMaestra(Convert.ToInt32(_Txt_Reposicion.Text), false); }
                    MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_Actualizar();
                    _Tb_Tab.SelectedIndex = 0;
                }
                else
                {
                    _Mtd_InsertarMaestra(new _Cls_Consecutivos()._Mtd_Reposicion(), 0, 0, 0, 0, false);
                    MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mtd_Actualizar();
                    _Tb_Tab.SelectedIndex = 0;
                }
                return true;
            }
            else
            {
                if (!_Bol_RegexRif)
                {
                    _Er_Error.SetError(_Txt_Rif, "Por favor verifique que el valor introducido en la cédula o rif sea correcto");
                }
                if (_Txt_Motivo.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_EditarMotivo, "Información Requerida!!!"); }
                if (_Txt_Rif.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Rif, "Información Requerida!!!"); }
                if (_Txt_Beneficiario.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Beneficiario, "Información Requerida!!!"); }
                if (Convert.ToString(_Cmb_TipoReposicion.SelectedValue) == "G" || Convert.ToString(_Cmb_TipoReposicion.SelectedValue) == "C")
                {
                    if (_Cmb_Entidad.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Entidad, "Información Requerida!!!"); }
                    if (_Cmb_Entidad.SelectedIndex > 0)
                    {
                        if (_Txt_Entidad.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_Buscar, "Información Requerida!!!"); }
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Salda las retenciones de la reposición si esta proviene de una y tiene retenciones cargadas
        /// </summary>
        /// <param name="_P_Str_cidreposiciones"></param>
        private void _Mtd_MarcarRetencion(string _Str_cproveedor, string _Str_ctipodocument, string _Str_cnumdocu, bool _P_Bool_Usada)
        {
            var _Str_Usada = _P_Bool_Usada ? "1" : "0";
            var _Str_Sql = "UPDATE TFACTPPAGARM SET cordenpaghecha='" + _Str_Usada + "',cdateupd='" + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ()) + "',cuserupd='" + Frm_Padre._Str_Use + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' " +
                           "AND cproveedor='" + _Str_cproveedor + "' AND ctipodocument='" + _Str_ctipodocument + "' AND cnumdocu='" + _Str_cnumdocu + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Sql);
        }

        private string _Mtd_DescripcionEntidad(int _P_Int_TipoEntidad, string _P_Str_Entidad)
        {
            string _Str_Cadena = "";
            //if (_P_Int_TipoEntidad == 1)
            //{ _Str_Cadena = "SELECT cname FROM TVENDEDOR WHERE cvendedor='" + _P_Str_Entidad + "'"; }
            //else
            //{ _Str_Cadena = "SELECT cnombre FROM TTRANSPORTISTA WHERE cplaca='" + _P_Str_Entidad + "' and cdelete='0'"; }
            _Str_Cadena = "SELECT cnombre + ' ' + capellido from VST_T3_BENEFICIARIOS where crif = '" + _P_Str_Entidad + "'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows.Count > 0)
            {
                return _Ds.Tables[0].Rows[0][0].ToString().ToUpper();
            }
            return "";
        }
        private void _Mtd_CargarFormulario(int _P_Int_Reposicion)
        {
            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            DataContext.TREPOSICIONESM _T_TREPOSICIONESM = Program._Dat_Tablas.TREPOSICIONESM.Single(Campos => Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidreposiciones == _P_Int_Reposicion);
            _Txt_Reposicion.Text = Convert.ToString(_T_TREPOSICIONESM.cidreposiciones);
            _Txt_FechaEmision.Text = Convert.ToDateTime(_T_TREPOSICIONESM.cfechaemision).ToShortDateString();
            _Cmb_TipoReposicion.SelectedValue = Convert.ToString(_T_TREPOSICIONESM.ctipreposicion);
            _Cmb_Entidad.SelectedValue = Convert.ToString(_T_TREPOSICIONESM.ctipoentidad);
            _Txt_Entidad.Tag = Convert.ToString(_T_TREPOSICIONESM.centidad);
            _Txt_Entidad.Text = _Mtd_DescripcionEntidad(Convert.ToInt32(_T_TREPOSICIONESM.ctipoentidad), Convert.ToString(_T_TREPOSICIONESM.centidad));
            _Txt_Motivo.Text = _T_TREPOSICIONESM.cdescripcionrepo;
            _Txt_Beneficiario.Text = _T_TREPOSICIONESM.cbeneficiario;
            _Txt_Rif.Text = _T_TREPOSICIONESM.crif;
            if (Convert.ToString(_T_TREPOSICIONESM.ctipoentidad) == "3")
            {
                _Txt_Entidad.Text = _Txt_Beneficiario.Text;
            }
            _Txt_Beneficiario.Enabled = true;
            _Txt_Beneficiario.Enabled = false;
            _Mtd_ActualizarDetalle(_P_Int_Reposicion);
        }
        private void _Mtd_EliminarDetalleReposicion(int _P_Int_Reposicion, int _P_Int_ReposicionDetalle)
        {
            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            DataContext.TREPOSICIONESD _T_TREPOSICIONESD = Program._Dat_Tablas.TREPOSICIONESD.Single(Campos => Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidreposiciones == _P_Int_Reposicion & Campos.ciddreposiciones == _P_Int_ReposicionDetalle);

            //Marcamos las retenciones como usadas
            if (_T_TREPOSICIONESD != null)
            {
                switch (_T_TREPOSICIONESD.ctipodocument)
                {
                    case "RETIVA":
                    case "RETISLR":
                        _Mtd_MarcarRetencion(_T_TREPOSICIONESD.cproveedor, _T_TREPOSICIONESD.ctipodocument, _T_TREPOSICIONESD.cnumdocu, false);
                        break;
                }
            }
            Program._Dat_Tablas.TREPOSICIONESD.DeleteOnSubmit(_T_TREPOSICIONESD);
            Program._Dat_Tablas.SubmitChanges();
        }
        private bool _Mtd_Finalizado(int _P_Int_Reposicion)
        {
            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            return Convert.ToBoolean((from Campos in Program._Dat_Tablas.TREPOSICIONESM
                                      where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidreposiciones == _P_Int_Reposicion
                                      select Campos.cestatusreposicion).Single());
        }
        private bool _Mtd_AprobadoRechazado(int _P_Int_Reposicion)
        {
            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            return (from Campos in Program._Dat_Tablas.TREPOSICIONESM
                    where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidreposiciones == _P_Int_Reposicion & Campos.cestatusfirma == 1//(Campos.cestatusfirma == 1 | Campos.cestatusfirma == 9)
                    select Campos).Count() > 0;
        }
        private decimal? _Mtd_MontoEmisionCheq(int _P_Int_EmisionCheque)
        {
            Program._Dat_Vistas = new DataContext._Dat_CntxVistasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            return (from Campos in Program._Dat_Vistas.VST_CHEQUES_EMITIDOS
                    where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidemisioncheq == _P_Int_EmisionCheque
                    select Campos.cmontototal).Single();
        }
        private decimal? _Mtd_MontoReposicionDetalle(int _P_Int_Reposicion, int _P_Int_ReposicionDetalle)
        {
            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            return (from Campos in Program._Dat_Tablas.TREPOSICIONESD
                    where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidreposiciones == _P_Int_Reposicion & Campos.ciddreposiciones == _P_Int_ReposicionDetalle
                    select Campos.cmontototal).Single();
        }
        private int _Mtd_OrdenPagoEmisionCheq(int _P_Int_EmisionCheque)
        {
            Program._Dat_Vistas = new DataContext._Dat_CntxVistasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            return (from Campos in Program._Dat_Vistas.VST_CHEQUES_EMITIDOS
                    where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidemisioncheq == _P_Int_EmisionCheque
                    select Campos.cidordpago).Single();
        }
        /// <summary>
        /// Devuelve un valor que indica si el monto de la reposición quería negativo
        /// si se agregara un anticipo o se quitara un documento.
        /// </summary>
        /// <param name="_P_Int_Reposicion">Id de la reposición</param>
        /// <param name="_P_Dec_MontoDocumento">Monto del documento que se desea quitar</param>
        /// <param name="_P_Dec_MontoAnticipo">Monto del anticipo que se desea agregar</param>
        /// <returns></returns>
        public bool _Mtd_ReposicionNegativa(int _P_Int_Reposicion, decimal _P_Dec_MontoDocumento, decimal _P_Dec_MontoAnticipo)
        {
            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            var _Var_Datos = from Campos in Program._Dat_Tablas.TREPOSICIONESD
                             where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidreposiciones == _P_Int_Reposicion
                             select new { Campos.cmontototal, Campos.canticipogasto, Campos.ctipodocumentodetalle };
            //----------------------
            decimal _Dcm_TotalDebe = 0, _Dcm_TotalHaber = 0, _Dcm_TotalAnticipos = 0, _Dcm_TotalRetencionesISLR = 0, _Dcm_TotalRetecionesIVA = 0, _Dcm_TotalRetecionesPatente = 0;

            if (_Var_Datos.Where(c => !Convert.ToBoolean(c.canticipogasto)).Count() > 0)
            { _Dcm_TotalDebe = (decimal)_Var_Datos.Where(c => !Convert.ToBoolean(c.canticipogasto)).Select(c => c.cmontototal).Sum(); }

            if (_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.Anticipo).Any())
            { _Dcm_TotalAnticipos = (decimal)_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.Anticipo).Select(c => c.cmontototal).Sum(); }
            if (_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionISLR).Any())
            { _Dcm_TotalRetencionesISLR = (decimal)_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionISLR).Select(c => c.cmontototal).Sum(); }
            if (_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionIVA).Any())
            { _Dcm_TotalRetecionesIVA = (decimal)_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionIVA).Select(c => c.cmontototal).Sum(); }
            if (_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionPatente).Any())
            { _Dcm_TotalRetecionesPatente = (decimal)_Var_Datos.Where(c => c.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionPatente).Select(c => c.cmontototal).Sum(); }

            _Dcm_TotalHaber = _Dcm_TotalAnticipos + _Dcm_TotalRetencionesISLR + _Dcm_TotalRetecionesIVA + _Dcm_TotalRetecionesPatente;

            decimal _Dcm_TotalBanco = (_Dcm_TotalDebe - _P_Dec_MontoDocumento) - (_Dcm_TotalHaber + _P_Dec_MontoAnticipo);
            //----------------------
            return _Dcm_TotalBanco < 0;
        }
        private void _Mtd_CargarPanelDescontar(int _P_Int_Reposicion, int _P_Int_ReposicionDetalle, _TipoDocumentoReposicion _P_TipoDocumentoReposicion)
        {
            Program._Dat_Vistas = new DataContext._Dat_CntxVistasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            //----------------
            var _Var_Datos = (from CamposVST_REPOSICIONES_DET in Program._Dat_Vistas.VST_REPOSICIONES_DET
                              where CamposVST_REPOSICIONES_DET.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & CamposVST_REPOSICIONES_DET.ccompany == Frm_Padre._Str_Comp & CamposVST_REPOSICIONES_DET.cidreposiciones == _P_Int_Reposicion & CamposVST_REPOSICIONES_DET.ciddreposiciones == _P_Int_ReposicionDetalle
                              select new { CamposVST_REPOSICIONES_DET.cconcepto, CamposVST_REPOSICIONES_DET.ccuentaexep, CamposVST_REPOSICIONES_DET.cname, CamposVST_REPOSICIONES_DET.cmontototal }).Single();
            //----------------
            switch (_P_TipoDocumentoReposicion)
            {
                case _TipoDocumentoReposicion.Anticipo:
                    _Txt_Concepto.Text = _Var_Datos.cconcepto.Trim().ToUpper();
                    _Txt_Cuenta.Tag = _Var_Datos.ccuentaexep.Trim();
                    _Txt_Cuenta.Text = _Var_Datos.ccuentaexep.Trim() + " " + _Var_Datos.cname.Trim().ToUpper();
                    _Txt_Anticipo.Text = _Mtd_FormtadoMoneda(_Var_Datos.cmontototal);
                    break;
                case _TipoDocumentoReposicion.RetencionISLR:
                    _Txt_Concepto_RetencionISLR.Text = _Var_Datos.cconcepto.Trim().ToUpper();
                    _Txt_RetencionISLR.Text = _Mtd_FormtadoMoneda(_Var_Datos.cmontototal);
                    break;
                case _TipoDocumentoReposicion.RetencionIVA:
                    _Txt_Concepto_RetencionIVA.Text = _Var_Datos.cconcepto.Trim().ToUpper();
                    _Txt_RetencionIVA.Text = _Mtd_FormtadoMoneda(_Var_Datos.cmontototal);
                    break;
            }
        }
        private void _Mtd_RechazarReposicion(int _P_Int_Reposicion)
        {
            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            DataContext.TREPOSICIONESM _T_TREPOSICIONESM = Program._Dat_Tablas.TREPOSICIONESM.Single(Campos => Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidreposiciones == _P_Int_Reposicion);
            _T_TREPOSICIONESM.cestatusreposicion = Convert.ToByte("0");
            _T_TREPOSICIONESM.cdateupd = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _T_TREPOSICIONESM.cuserupd = Frm_Padre._Str_Use;
            Program._Dat_Tablas.SubmitChanges();
        }
        private void Frm_ReposicionCxP_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _Pnl_Descontar.Left = (this.Width / 2) - (_Pnl_Descontar.Width / 2);
            _Pnl_Descontar.Top = (this.Height / 2) - (_Pnl_Descontar.Height / 2);
            _Pnl_Clave.Left = (this.Width / 2) - (_Pnl_Clave.Width / 2);
            _Pnl_Clave.Top = (this.Height / 2) - (_Pnl_Clave.Height / 2);
            _Ctrl_BusquedaLinq1._Mtd_Tool_Metodo(this, "_Mtd_Actualizar");
            _Ctrl_BusquedaLinq1._Mtd_Tool_Menu("Reposición");
            _Ctrl_BusquedaLinq1._Mtd_Tool_Menu("Descripción");
            _Pnl_Descontar_RetencionISLR.Left = (this.Width / 2) - (_Pnl_Descontar_RetencionISLR.Width / 2);
            _Pnl_Descontar_RetencionISLR.Top = (this.Height / 2) - (_Pnl_Descontar_RetencionISLR.Height / 2);
            _Pnl_Descontar_RetencionIVA.Left = (this.Width / 2) - (_Pnl_Descontar_RetencionIVA.Width / 2);
            _Pnl_Descontar_RetencionIVA.Top = (this.Height / 2) - (_Pnl_Descontar_RetencionIVA.Height / 2);
            _Pnl_Descontar_RetencionPatente.Left = (this.Width / 2) - (_Pnl_Descontar_RetencionPatente.Width / 2);
            _Pnl_Descontar_RetencionPatente.Top = (this.Height / 2) - (_Pnl_Descontar_RetencionPatente.Height / 2);
            //Si esta activo el swicheo de los reintegros
            if (!CLASES._Cls_Varios_Metodos._Mtd_EstaActivoReintegros())
            {
                //Oculto
                _Bt_Descontar_RetencionISRL.Enabled = false;
                _Bt_Descontar_RetencionISRL.Visible = false;
                _Bt_Descontar_RetencionIVA.Enabled = false;
                _Bt_Descontar_RetencionIVA.Visible = false;
                _Bt_Descontar_RetencionPatente.Enabled = false;
                _Bt_Descontar_RetencionPatente.Visible = false;
                label15.Visible = false;
                label17.Visible = false;
                label5.Visible = false;
                _Txt_TotalRetencionesISLR.Visible = false;
                _Txt_TotalRetencionesIVA.Visible = false;
                if (!CLASES._Cls_Varios_Metodos._Mtd_EstaActivoRetencionesPatente())
                {
                    _Txt_TotalRetencionesPatente.Visible = false;
                    label20.Visible = false;
                }
            }
            if (!CLASES._Cls_Varios_Metodos._Mtd_EstaActivoRetencionesPatente())
            {
                _Bt_Descontar_RetencionPatente.Enabled = false;
                _Bt_Descontar_RetencionPatente.Visible = false;
                _Txt_TotalRetencionesPatente.Visible = false;
                label20.Visible = false;
            }
        }

        private void _Cmb_TipoReposicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (_Cmb_TipoReposicion.SelectedIndex > 0)
            {
                bool _Bol_Validado = true;
                if (_Txt_Reposicion.Text.Trim().Length > 0)
                {
                    if (_Mtd_ReposicionGastos(Convert.ToInt32(_Txt_Reposicion.Text)) & _Mtd_VerifDetalleAnticipos(Convert.ToInt32(_Txt_Reposicion.Text)) & Convert.ToString(_Cmb_TipoReposicion.SelectedValue).Trim() == "C")
                    {
                        MessageBox.Show("No puede seleccionar esta opción porque hay anticipos en el detalle.\nElimine los anticipos si desea seleccionar este tipo de reposición.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Cmb_TipoReposicion.SelectedValue = "G";
                        _Bol_Validado = false;
                    }
                }
                if (_Bol_Validado)
                {
                    _Txt_Beneficiario.Enabled = true;
                    _Mtd_CargarEntidades();
                    _Cmb_Entidad.Enabled = false;
                    if (Convert.ToString(_Cmb_TipoReposicion.SelectedValue) == "G")
                    {
                        _Txt_Motivo.Text = "REPOSICIÓN DE GASTOS " + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ());
                        _Cmb_Entidad.Enabled = true;
                        _Cmb_Entidad.Focus();
                    }
                    else
                    { 
                        _Txt_Motivo.Text = "REPOSICIÓN DE CAJA CHICA " + _Cls_Formato._Mtd_fecha(CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ());
                        _Bt_Buscar.Enabled = true;
                        _Cmb_Entidad.SelectedValue = "3";
                        _Cmb_Entidad.Enabled = false;
                    }
                    _Bt_EditarMotivo.Enabled = true; 
                    _Bt_Ingresar.Enabled = true; 
                    _Bt_Descontar.Enabled = _Dg_Detalle.RowCount > 0 & Convert.ToString(_Cmb_TipoReposicion.SelectedValue) == "G";
                    _Bt_Descontar_RetencionISRL.Enabled = true;
                    _Bt_Descontar_RetencionIVA.Enabled = true;
                    _Bt_Descontar_RetencionPatente.Enabled = true;
                    if (!CLASES._Cls_Varios_Metodos._Mtd_EstaActivoRetencionesPatente())
                    {
                        _Bt_Descontar_RetencionPatente.Enabled = false;
                        _Bt_Descontar_RetencionPatente.Visible = false;
                    }
                }
            }
            else
            {   _Mtd_CargarEntidades(); _Cmb_Entidad.Enabled = false; _Txt_Rif.Text = ""; _Txt_Motivo.Text = ""; _Txt_Beneficiario.Text = ""; _Txt_Beneficiario.Enabled = false; _Bt_EditarMotivo.Enabled = false; _Bt_Ingresar.Enabled = false;
            _Bt_Descontar.Enabled = false; _Bt_Descontar_RetencionISRL.Enabled = false; _Bt_Descontar_RetencionIVA.Enabled = false; _Bt_Descontar_RetencionPatente.Enabled = false;
            }
        }

        private void Frm_ReposicionCxP_Activated(object sender, EventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = true;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Abierto";
            CONTROLES._Ctrl_Buscar._frm_Formulario = this;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_nuevo2.Enabled = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_REPOSICIONES");
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = _Cmb_TipoReposicion.Enabled;
            ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_cancelar2.Enabled = false;
        }

        private void Frm_ReposicionCxP_FormClosing(object sender, FormClosingEventArgs e)
        {
            CONTROLES._Ctrl_Buscar._Bl_Especial = false;
            CONTROLES._Ctrl_Buscar._Bol_SoloNuevo = false;
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "";
            CONTROLES._Ctrl_Buscar._txt_ExistForm.Text = "Cerrado";
        }

        private void _Tb_Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            { e.Cancel = !_Cmb_TipoReposicion.Enabled; }
            else
            {
                _Mtd_Ini();
                _Mtd_Habilitar(false);
                ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
            }
        }

        private void _Bt_EditarMotivo_Click(object sender, EventArgs e)
        {
            if (_Txt_Motivo.Enabled) { _Txt_Motivo.Enabled = false; }
            else
            { _Txt_Motivo.Enabled = true; _Txt_Motivo.Focus(); }
        }

        public bool _Mtd_EsValidaLaReposicionActual_NoEstaFinalizada()
        {
            //Validamos que no este ni finalizada ni aprobada rechazada
            if (_Txt_Reposicion.Text.Trim().Length > 0)
            {
                int _Int_IdReposicion = Convert.ToInt32(_Txt_Reposicion.Text);
                if (_Mtd_Finalizado(_Int_IdReposicion))
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                    MessageBox.Show("Ya reposición actual fue Finalizada por otro usuario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Pnl_Clave.Visible = false;
                    _Pnl_Descontar.Visible = false;
                    _Pnl_Descontar_RetencionISLR.Visible = false;
                    _Pnl_Descontar_RetencionIVA.Visible = false;
                    _Pnl_Descontar_RetencionPatente.Visible = false;
                    _Mtd_Actualizar();
                    _Tb_Tab.SelectedIndex = 0;
                    return false;
                }
            }
            return true;
        }
        public bool _Mtd_EsValidaLaReposicionActual_NoEstaAprobadaRechazada()
        {
            //Validamos que no este ni finalizada ni aprobada rechazada
            if (_Txt_Reposicion.Text.Trim().Length > 0)
            {
                int _Int_IdReposicion = Convert.ToInt32(_Txt_Reposicion.Text);
                if (_Mtd_AprobadoRechazado(_Int_IdReposicion))
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                    MessageBox.Show("Ya reposición actual fue Aprobada o Rechazada por otro usuario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Pnl_Clave.Visible = false;
                    _Pnl_Descontar.Visible = false;
                    _Pnl_Descontar_RetencionISLR.Visible = false;
                    _Pnl_Descontar_RetencionIVA.Visible = false;
                    _Pnl_Descontar_RetencionPatente.Visible = false;
                    _Mtd_Actualizar();
                    _Tb_Tab.SelectedIndex = 0;
                    return false;
                }
            }
            return true;
        }

        private void _Bt_Ingresar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (!_Mtd_EsValidaLaReposicionActual_NoEstaFinalizada()) return;
            if (_Txt_Motivo.Text.Trim().Length > 0 && _Txt_Beneficiario.Text.Trim().Length > 0 && (((_Cmb_Entidad.SelectedIndex > 0 && _Txt_Entidad.Text.Trim().Length > 0) || Convert.ToString(_Cmb_Entidad.SelectedValue).Trim() == "3") | Convert.ToString(_Cmb_TipoReposicion.SelectedValue) == "C"))
            {
                Frm_ReposicionCxP_Documentos _Frm = new Frm_ReposicionCxP_Documentos(this);
                _Frm.ShowDialog(this);
                _Bt_Descontar.Enabled = _Dg_Detalle.RowCount > 0 & Convert.ToString(_Cmb_TipoReposicion.SelectedValue) == "G";
                _Bt_Descontar_RetencionISRL.Enabled = true;
                _Bt_Descontar_RetencionIVA.Enabled = true;
                _Bt_Descontar_RetencionPatente.Enabled = true;
                if (!CLASES._Cls_Varios_Metodos._Mtd_EstaActivoRetencionesPatente())
                {
                    _Bt_Descontar_RetencionPatente.Enabled = false;
                    _Bt_Descontar_RetencionPatente.Visible = false;
                }
            }
            else
            {
                if (_Txt_Motivo.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_EditarMotivo, "Información Requerida!!!"); }
                if (_Txt_Beneficiario.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Beneficiario, "Información Requerida!!!"); }
                if (Convert.ToString(_Cmb_TipoReposicion.SelectedValue) == "G")
                {
                    if (_Cmb_Entidad.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Entidad, "Información Requerida!!!"); }
                    if (_Cmb_Entidad.SelectedIndex > 0 && Convert.ToString(_Cmb_Entidad.SelectedValue).Trim() != "3")
                    {
                        if (_Txt_Entidad.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_Buscar, "Información Requerida!!!"); }
                    }
                }
            }
        }
        private void _Dg_Grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _Mtd_Ini();
            _Txt_Motivo.Enabled = false;
            _Mtd_CargarFormulario(Convert.ToInt32(_Dg_Grid.Rows[e.RowIndex].Cells["Reposición"].Value));
            if (!_Mtd_Finalizado(Convert.ToInt32(_Dg_Grid.Rows[e.RowIndex].Cells["Reposición"].Value)))
            {
                if (_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_REPOSICIONES"))
                { _Mtd_Habilitar(true); ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = true; }
                else
                { _Mtd_Habilitar(false); }
            }
            else
            {
                _Mtd_Habilitar(false); ((Frm_Padre)this.MdiParent)._Ctrl_Buscar1._Bt_guardar2.Enabled = false;
                bool _Bol_Aprobar = _Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N2_REPOSICIONES") & !_Mtd_AprobadoRechazado(Convert.ToInt32(_Dg_Grid.Rows[e.RowIndex].Cells["Reposición"].Value));
                _Bt_Aprobar.Visible = _Bol_Aprobar;
                _Bt_Rechazar.Visible = _Bol_Aprobar;
            }
            _Tb_Tab.Selecting -= new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            _Tb_Tab.SelectedIndex = 1;
            _Tb_Tab.Selecting += new TabControlCancelEventHandler(_Tb_Tab_Selecting);
            Cursor = Cursors.Default;
        }

        private void _Cntx_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (_Dg_Detalle.SelectedRows.Count != 1)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = _Mtd_Finalizado(Convert.ToInt32(_Txt_Reposicion.Text)) | !(_Cls_VariosMetodos._Mtd_ObtenerUsuarioFirma(Frm_Padre._Str_Use) == "1" & _Cls_VariosMetodos._Mtd_UsuarioProceso(Frm_Padre._Str_Use, "F_N1_REPOSICIONES"));

                switch (Convert.ToByte(_Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["ctipodocumentodetalle"].Value.ToString()))
                {
                    case (byte) _TipoDocumentoReposicion.Factura:
                        _Tool_Editar.Text = "Editar documento";
                        _Tool_Eliminar.Text = "Eliminar documento";
                        break;
                    case (byte)_TipoDocumentoReposicion.Anticipo:
                        _Tool_Editar.Text = "Editar anticipo"; 
                        _Tool_Eliminar.Text = "Eliminar anticipo";
                        break;
                    case (byte)_TipoDocumentoReposicion.RetencionISLR:
                        _Tool_Editar.Text = "Editar retención ISLR"; 
                        _Tool_Eliminar.Text = "Eliminar retencion ISLR";
                        break;
                    case (byte)_TipoDocumentoReposicion.RetencionIVA:
                        _Tool_Editar.Text = "Editar retención IVA"; 
                        _Tool_Eliminar.Text = "Eliminar retención IVA";
                        break;

                }
            }
        }

        private void _Rb_Todas_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Todas.Checked) { _Mtd_Actualizar(); }
        }

        private void _Rb_Incompletas_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Incompletas.Checked) { _Mtd_Actualizar(); }
        }

        private void _Rb_PorAprobar_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_PorAprobar.Checked) { _Mtd_Actualizar(); }
        }

        private void _Rb_Aprobadas_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Aprobadas.Checked) { _Mtd_Actualizar(); }
        }

        private void _Rb_Rechazadas_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_Rechazadas.Checked) { _Mtd_Actualizar(); }
        }
        private void _Bt_Aprobar_Click(object sender, EventArgs e)
        {
            if (!_Mtd_EsValidaLaReposicionActual_NoEstaAprobadaRechazada()) return;
            Cursor = Cursors.WaitCursor;
            Frm_ReposicionCxP_Aprobacion _Frm = new Frm_ReposicionCxP_Aprobacion(Convert.ToInt32(_Txt_Reposicion.Text), Convert.ToString(_Cmb_TipoReposicion.SelectedValue).Trim(), Convert.ToDecimal(_Txt_TotalReponer.Text));
            Cursor = Cursors.Default;
            if (_Frm.ShowDialog(this) == DialogResult.Yes)
            {
                _Mtd_Actualizar();
                _Tb_Tab.SelectedIndex = 0;
            }
        }

        private void _Bt_Rechazar_Click(object sender, EventArgs e)
        {
            if (!_Mtd_EsValidaLaReposicionActual_NoEstaAprobadaRechazada()) return;
            if (MessageBox.Show("¿Esta seguro de rechazar la reposición?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { _Pnl_Clave.Visible = true; }
        }

        private void _Tool_Editar_Click(object sender, EventArgs e)
        {
            if (!_Mtd_EsValidaLaReposicionActual_NoEstaFinalizada()) return;
            if (Convert.ToString(_Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["canticipogasto"].Value).Trim() != "1")
            {
                Cursor = Cursors.WaitCursor;
                Frm_ReposicionCxP_Documentos _Frm = new Frm_ReposicionCxP_Documentos(this, Convert.ToInt32(_Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["ciddreposiciones"].Value));
                Cursor = Cursors.Default;
                _Frm.ShowDialog(this);
            }
            else
            {
                var _Byte_ctipodocumentodetalle = Convert.ToByte(_Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["ctipodocumentodetalle"].Value.ToString());
                switch (_Byte_ctipodocumentodetalle)
                {
                    case (byte) _TipoDocumentoReposicion.Anticipo:
                        _Mtd_CargarPanelDescontar(Convert.ToInt32(_Txt_Reposicion.Text), Convert.ToInt32(_Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["ciddreposiciones"].Value), _TipoDocumentoReposicion.Anticipo);
                        _Pnl_Descontar.Tag = Convert.ToInt32(_Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["ciddreposiciones"].Value);
                        _Pnl_Descontar.Visible = true;
                        break;
                    case (byte) _TipoDocumentoReposicion.RetencionISLR:
                        _Mtd_CargarPanelDescontar(Convert.ToInt32(_Txt_Reposicion.Text), Convert.ToInt32(_Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["ciddreposiciones"].Value), _TipoDocumentoReposicion.RetencionISLR);
                        _Pnl_Descontar_RetencionISLR.Tag = Convert.ToInt32(_Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["ciddreposiciones"].Value);
                        _Pnl_Descontar_RetencionISLR.Visible = true;
                        break;
                    case (byte) _TipoDocumentoReposicion.RetencionIVA:
                        _Mtd_CargarPanelDescontar(Convert.ToInt32(_Txt_Reposicion.Text), Convert.ToInt32(_Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["ciddreposiciones"].Value), _TipoDocumentoReposicion.RetencionIVA);
                        _Pnl_Descontar_RetencionIVA.Tag = Convert.ToInt32(_Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["ciddreposiciones"].Value);
                        _Pnl_Descontar_RetencionIVA.Visible = true;
                        break;
                    case (byte)_TipoDocumentoReposicion.RetencionPatente:
                        _Mtd_CargarPanelDescontar(Convert.ToInt32(_Txt_Reposicion.Text), Convert.ToInt32(_Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["ciddreposiciones"].Value), _TipoDocumentoReposicion.RetencionPatente);
                        _Pnl_Descontar_RetencionPatente.Tag = Convert.ToInt32(_Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["ciddreposiciones"].Value);
                        _Pnl_Descontar_RetencionPatente.Visible = true;
                        break;
                }
            }
        }

        private void _Tool_Eliminar_Click(object sender, EventArgs e)
        {
            if (!_Mtd_EsValidaLaReposicionActual_NoEstaFinalizada()) return;
            bool _Bol_Eliminar = true;
            if (Convert.ToString(_Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["canticipogasto"].Value).Trim() != "1")
            {
                if (_Mtd_ReposicionNegativa(Convert.ToInt32(_Txt_Reposicion.Text), Convert.ToDecimal(_Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["Monto"].Value), 0))
                {
                    MessageBox.Show("No se puede eliminar el documento debido a que el monto de la reposición quedaría en negativo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Bol_Eliminar = false;
                }
            }
            if (_Bol_Eliminar)
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_EliminarDetalleReposicion(Convert.ToInt32(_Txt_Reposicion.Text), Convert.ToInt32(_Dg_Detalle.Rows[_Dg_Detalle.CurrentCell.RowIndex].Cells["ciddreposiciones"].Value));
                _Mtd_ModificarMaestra(Convert.ToInt32(_Txt_Reposicion.Text), false);
                _Mtd_Actualizar();
                _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_Reposicion.Text));
                if (_Dg_Detalle.RowCount == 0)
                {
                    _Bt_Descontar.Enabled = false;
                    _Bt_Descontar_RetencionISRL.Enabled = false;
                    _Bt_Descontar_RetencionIVA.Enabled = false;
                    _Bt_Descontar_RetencionPatente.Enabled = false;
                }
                Cursor = Cursors.Default;
            }
        }

        private void _Pnl_Clave_VisibleChanged(object sender, EventArgs e)
        {
            if (_Pnl_Clave.Visible)
            { _Tb_Tab.Enabled = false; _Txt_Clave.Text = ""; _Txt_Clave.Focus(); }
            else
            { _Tb_Tab.Enabled = true; }
        }

        private void _Bt_CancelarClave_Click(object sender, EventArgs e)
        {
            _Pnl_Clave.Visible = false;
        }

        private void _Bt_AceptarClave_Click(object sender, EventArgs e)
        {
            if (!_Mtd_EsValidaLaReposicionActual_NoEstaAprobadaRechazada()) return;
            if (_Cls_VariosMetodos._Mtd_VerificarClaveUsuario(_Txt_Clave.Text.Trim()))
            {
                Cursor = Cursors.WaitCursor;
                _Mtd_RechazarReposicion(Convert.ToInt32(_Txt_Reposicion.Text));
                System.Threading.ThreadPool.QueueUserWorkItem(((Frm_Padre)Application.OpenForms["Frm_Padre"])._Frm_Contenedor._async_Default);
                _Pnl_Clave.Visible = false;
                Cursor = Cursors.Default;
                MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mtd_Actualizar();
                _Tb_Tab.SelectedIndex = 0;
            }
            else { MessageBox.Show(this, "Clave incorrecta!!!", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); _Txt_Clave.Focus(); _Txt_Clave.Select(0, _Txt_Clave.Text.Length); }
        }

        private void _Cmb_Entidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Txt_Entidad.Text = "";
            _Txt_Entidad.Tag = "";
            _Txt_Rif.Text = "";
            _Txt_Beneficiario.Text = "";
            _Bt_Buscar.Enabled = _Cmb_Entidad.SelectedIndex > 0;
        }

        private void _Bt_Buscar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(_Cmb_Entidad.SelectedValue) == 1)
            {
                Cursor = Cursors.WaitCursor;
                Frm_BeneficiarioBusqueda _Frm = new Frm_BeneficiarioBusqueda(_Txt_Rif, _Txt_Beneficiario);
                _Frm.ShowDialog();
                _Txt_Beneficiario.Enabled = false;
                _Txt_Rif.Enabled = false;
                _Txt_Entidad.Tag = _Txt_Rif.Text;
                _Txt_Entidad.Text = _Txt_Beneficiario.Text;
                Cursor = Cursors.Default;     
            }
            else if (Convert.ToInt32(_Cmb_Entidad.SelectedValue) == 2)
            {
                Cursor = Cursors.WaitCursor;
                Frm_BeneficiarioBusqueda _Frm = new Frm_BeneficiarioBusqueda(_Txt_Rif, _Txt_Beneficiario);
                _Frm.ShowDialog();
                _Txt_Beneficiario.Enabled = false;
                _Txt_Rif.Enabled = false;
                _Txt_Entidad.Tag = _Txt_Rif.Text;
                _Txt_Entidad.Text = _Txt_Beneficiario.Text;
                Cursor = Cursors.Default;     
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                Frm_BeneficiarioBusqueda _Frm = new Frm_BeneficiarioBusqueda(_Txt_Rif, _Txt_Beneficiario);
                _Frm.ShowDialog();
                _Txt_Beneficiario.Enabled = false;
                _Txt_Rif.Enabled = false;
                _Txt_Entidad.Tag = _Txt_Rif.Text;
                _Txt_Entidad.Text = _Txt_Beneficiario.Text;
                Cursor = Cursors.Default;                
            }
        }

        #region Botones Descontar

        private void _Bt_Descontar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (!_Mtd_EsValidaLaReposicionActual_NoEstaFinalizada()) return;
            if (_Txt_Motivo.Text.Trim().Length > 0 && _Txt_Beneficiario.Text.Trim().Length > 0 && (((_Cmb_Entidad.SelectedIndex > 0 && _Txt_Entidad.Text.Trim().Length > 0) || Convert.ToString(_Cmb_Entidad.SelectedValue).Trim() == "3") | Convert.ToString(_Cmb_TipoReposicion.SelectedValue) == "C"))
            {
                _Pnl_Descontar.Tag = "";
                _Pnl_Descontar.Visible = true;
            }
            else
            {
                if (_Txt_Motivo.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_EditarMotivo, "Información Requerida!!!"); }
                if (_Txt_Beneficiario.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Beneficiario, "Información Requerida!!!"); }
                if (Convert.ToString(_Cmb_TipoReposicion.SelectedValue) == "G")
                {
                    if (_Cmb_Entidad.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Entidad, "Información Requerida!!!"); }
                    if (_Cmb_Entidad.SelectedIndex > 0 && Convert.ToString(_Cmb_Entidad.SelectedValue).Trim() != "3")
                    {
                        if (_Txt_Entidad.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_Buscar, "Información Requerida!!!"); }
                    }
                }
            }
        }

        private void _Bt_Descontar_RetencionISRL_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (!_Mtd_EsValidaLaReposicionActual_NoEstaFinalizada()) return;
            if (_Txt_Motivo.Text.Trim().Length > 0 && _Txt_Beneficiario.Text.Trim().Length > 0 && (((_Cmb_Entidad.SelectedIndex > 0 && _Txt_Entidad.Text.Trim().Length > 0) || Convert.ToString(_Cmb_Entidad.SelectedValue).Trim() == "3") | Convert.ToString(_Cmb_TipoReposicion.SelectedValue) == "C"))
            {
                _Pnl_Descontar_RetencionISLR.Tag = "";
                _Pnl_Descontar_RetencionISLR.Visible = true;
            }
            else
            {
                if (_Txt_Motivo.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_EditarMotivo, "Información Requerida!!!"); }
                if (_Txt_Beneficiario.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Beneficiario, "Información Requerida!!!"); }
                if (Convert.ToString(_Cmb_TipoReposicion.SelectedValue) == "G")
                {
                    if (_Cmb_Entidad.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Entidad, "Información Requerida!!!"); }
                    if (_Cmb_Entidad.SelectedIndex > 0 && Convert.ToString(_Cmb_Entidad.SelectedValue).Trim() != "3")
                    {
                        if (_Txt_Entidad.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_Buscar, "Información Requerida!!!"); }
                    }
                }
            }
        }

        private void _Bt_Descontar_RetencionIVA_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (!_Mtd_EsValidaLaReposicionActual_NoEstaFinalizada()) return;
            if (_Txt_Motivo.Text.Trim().Length > 0 && _Txt_Beneficiario.Text.Trim().Length > 0 && (((_Cmb_Entidad.SelectedIndex > 0 && _Txt_Entidad.Text.Trim().Length > 0) || Convert.ToString(_Cmb_Entidad.SelectedValue).Trim() == "3") | Convert.ToString(_Cmb_TipoReposicion.SelectedValue) == "C"))
            {
                _Pnl_Descontar_RetencionIVA.Tag = "";
                _Pnl_Descontar_RetencionIVA.Visible = true;
            }
            else
            {
                if (_Txt_Motivo.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_EditarMotivo, "Información Requerida!!!"); }
                if (_Txt_Beneficiario.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Beneficiario, "Información Requerida!!!"); }
                if (Convert.ToString(_Cmb_TipoReposicion.SelectedValue) == "G")
                {
                    if (_Cmb_Entidad.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Entidad, "Información Requerida!!!"); }
                    if (_Cmb_Entidad.SelectedIndex > 0 && Convert.ToString(_Cmb_Entidad.SelectedValue).Trim() != "3")
                    {
                        if (_Txt_Entidad.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_Buscar, "Información Requerida!!!"); }
                    }
                }
            }
        }

        #endregion  

        #region ValidacionDeDocumentos
        private bool _Mtd_EsValidoDetalle(int _P_Int_Reposicion)
        {
            var _Str_Mensaje = "";
            var _Int_CantidadDocumentos = 0;
            var _Bol_Documentos_Validos = true;
            var _Bol_EstaActivoReintegros = CLASES._Cls_Varios_Metodos._Mtd_EstaActivoReintegros();

            Program._Dat_Tablas = new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            var _oDatos = from Campos in Program._Dat_Vistas.VST_REPOSICIONES_DET
                          where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidreposiciones == _P_Int_Reposicion
                          select new
                          {
                              Proveedor = Campos.c_nomb_comer,
                              NºDocumento = Campos.cnumdocu,
                              NºControl = Campos.cnumdocuctrl,
                              Concepto = Campos.cconcepto,
                              Monto = _Mtd_FormtadoMoneda(Campos.cmontototal),
                              Campos.ciddreposiciones,
                              Campos.cmontototal,
                              Campos.canticipogasto,
                              Campos.ctipodocumentodetalle,
                              Campos.cnumdocumafec,
                              Campos.cmontosi,
                              Campos.cmontoimp,
                              Campos.cproveedor,
                          };

            /*  
             * ----------------------------------------------------------------------------------------------------------------------------------------
             *  01
             *  Validamos que todas las retenciones de ISLR tiene un documento al que corresponde
             * ----------------------------------------------------------------------------------------------------------------------------------------
             */

            _Str_Mensaje = "";
            _Int_CantidadDocumentos = 0;
            _Bol_Documentos_Validos = true;
            var _oDocumentos = _oDatos.Where(x => x.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionISLR).ToList();
            _oDocumentos.ForEach(x =>
                {
                    var _Str_cnumdocumafec = x.cnumdocumafec;
                    //Buscamos si existe su factura correspondiente
                    var _Bol_Existe = _oDatos.Any(y => y.cproveedor == x.cproveedor && y.NºDocumento.Trim() == _Str_cnumdocumafec);
                    //Validamos
                    if (!_Bol_Existe)
                    {
                        //Contamos
                        _Int_CantidadDocumentos++;
                        //Cambiamos la bandera
                        _Bol_Documentos_Validos = false;
                        if (_Int_CantidadDocumentos == 1)
                            _Str_Mensaje += "" + x.NºDocumento + "";
                        else
                            _Str_Mensaje += "," + x.NºDocumento + "";
                    }
                });
            //Si esta activo el swicheo de los reintegros
            if (_Bol_EstaActivoReintegros)
            {
                if (!_Bol_Documentos_Validos)
                {
                    if (_Int_CantidadDocumentos == 1)
                        MessageBox.Show("La Retención ISLR # " + _Str_Mensaje + " no tiene su factura correspondiente, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Las Retencioones ISLR # (" + _Str_Mensaje + ") no tienen su factura correspondiente, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            /*  
             * ----------------------------------------------------------------------------------------------------------------------------------------
             *  02
             *  Validamos que todas las retenciones de IVA tiene un documento al que corresponde
             * ----------------------------------------------------------------------------------------------------------------------------------------
             */
            _Str_Mensaje = "";
            _Int_CantidadDocumentos = 0;
            _Bol_Documentos_Validos = true;
            _oDocumentos = _oDatos.Where(x => x.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionIVA).ToList();
            _oDocumentos.ForEach(x =>
            {
                var _Str_cnumdocumafec = x.cnumdocumafec;
                //Buscamos si existe su factura correspondiente
                var _Bol_Existe = _oDatos.Any(y => y.cproveedor == x.cproveedor &&  y.NºDocumento.Trim() == _Str_cnumdocumafec);
                //Validamos
                if (!_Bol_Existe)
                {
                    //Contamos
                    _Int_CantidadDocumentos++;
                    //Cambiamos la bandera
                    _Bol_Documentos_Validos = false;
                    if (_Int_CantidadDocumentos == 1)
                        _Str_Mensaje += "" + x.NºDocumento + "";
                    else
                        _Str_Mensaje += "," + x.NºDocumento + "";
                }
            });
            //Si esta activo el swicheo de los reintegros
            if (_Bol_EstaActivoReintegros)
            {
                if (!_Bol_Documentos_Validos)
                {
                    if (_Int_CantidadDocumentos == 1)
                        MessageBox.Show("La Retención IVA # " + _Str_Mensaje + " no tiene su factura correspondiente, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Las Retencioones IVA # (" + _Str_Mensaje + ") no tienen su factura correspondiente, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            /*  
             * ----------------------------------------------------------------------------------------------------------------------------------------
             *  03
             *  Validamos que todas las retenciones de ISLR tiene un documento con IVA
             * ----------------------------------------------------------------------------------------------------------------------------------------
             */
            _Str_Mensaje = "";
            _Int_CantidadDocumentos = 0;
            _Bol_Documentos_Validos = true;
            _oDocumentos = _oDatos.Where(x => x.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionISLR).ToList();
            _oDocumentos.ForEach(x =>
            {
                var _Str_cnumdocumafec = x.cnumdocumafec;
                //Buscamos si existe su factura correspondiente
                var _oFactura = _oDatos.SingleOrDefault(y => y.cproveedor == x.cproveedor && y.NºDocumento.Trim() == _Str_cnumdocumafec);
                //Validamos
                if (_oFactura != null)
                {
                    //Validamos el IVA
                    if ((_oFactura.cmontoimp == null) || (Math.Round(Convert.ToDecimal(_oFactura.cmontoimp),2) <= 0))
                    {
                        //Contamos
                        _Int_CantidadDocumentos++;
                        //Cambiamos la bandera
                        _Bol_Documentos_Validos = false;
                        if (_Int_CantidadDocumentos == 1)
                            _Str_Mensaje += "" + x.NºDocumento + "";
                        else
                            _Str_Mensaje += "," + x.NºDocumento + "";
                    }
                }
            });
            //Si esta activo el swicheo de los reintegros
            if (_Bol_EstaActivoReintegros)
            {
                if (!_Bol_Documentos_Validos)
                {
                    if (_Int_CantidadDocumentos == 1)
                        MessageBox.Show("La Retención ISLR # " + _Str_Mensaje + " esta asociada a una Factura sin impuesto, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Las Retencioones ISLR # (" + _Str_Mensaje + ") están asociadas a unas Facturas sin impuesto, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            /*  
             * ----------------------------------------------------------------------------------------------------------------------------------------
             *  04
             *  Validamos que todas las retenciones de IVA tiene un documento con IVA
             * ----------------------------------------------------------------------------------------------------------------------------------------
             */
            _Str_Mensaje = "";
            _Int_CantidadDocumentos = 0;
            _Bol_Documentos_Validos = true;
            _oDocumentos = _oDatos.Where(x => x.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionIVA).ToList();
            _oDocumentos.ForEach(x =>
            {
                var _Str_cnumdocumafec = x.cnumdocumafec;
                //Buscamos si existe su factura correspondiente
                var _oFactura = _oDatos.SingleOrDefault(y => y.cproveedor == x.cproveedor && y.NºDocumento.Trim() == _Str_cnumdocumafec);
                //Validamos
                if (_oFactura != null)
                {
                    //Validamos el IVA
                    if ((_oFactura.cmontoimp == null) || (Math.Round(Convert.ToDecimal(_oFactura.cmontoimp), 2) <= 0))
                    {
                        //Contamos
                        _Int_CantidadDocumentos++;
                        //Cambiamos la bandera
                        _Bol_Documentos_Validos = false;
                        if (_Int_CantidadDocumentos == 1)
                            _Str_Mensaje += "" + x.NºDocumento + "";
                        else
                            _Str_Mensaje += "," + x.NºDocumento + "";
                    }
                }
            });
            //Si esta activo el swicheo de los reintegros
            if (_Bol_EstaActivoReintegros)
            {
                if (!_Bol_Documentos_Validos)
                {
                    if (_Int_CantidadDocumentos == 1)
                        MessageBox.Show("La Retención IVA # " + _Str_Mensaje + " esta asociada a una Factura sin impuesto, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Las Retencioones IVA # (" + _Str_Mensaje + ") están asociadas a unas Facturas sin impuesto, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            /*  
             * ----------------------------------------------------------------------------------------------------------------------------------------
             *  05
             *  Validamos que los documentos que tiene relacionado una retencion de ISLR sobre pasen las UT permitidas
             * ----------------------------------------------------------------------------------------------------------------------------------------
             */

            //Validacion mandada eliminar por la Licenciada Sonia el 24-11-2014

            //_Str_Mensaje = "";
            //_Int_CantidadDocumentos = 0;
            //_Bol_Documentos_Validos = true;
            //_oDocumentos = _oDatos.Where(x => x.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionISLR).ToList();
            //_oDocumentos.ForEach(x =>
            //{
            //    var _Str_cnumdocumafec = x.cnumdocumafec;
            //    //Buscamos si existe su factura correspondiente
            //    var _oFactura = _oDatos.SingleOrDefault(y => y.cproveedor == x.cproveedor && y.NºDocumento.Trim() == _Str_cnumdocumafec);
            //    //Validamos
            //    if (_oFactura != null)
            //    {
            //        //Validamos el IVA
            //        if ((_oFactura.cmontoimp != null) && (Math.Round(Convert.ToDecimal(_oFactura.cmontoimp), 2) > 0))
            //        {
            //            //Validamos los montos
            //            var _Dec_MontoFactura = Convert.ToDecimal(_oFactura.cmontototal);
            //            if (_Dec_MontoFactura <= _Dec_MontominimoUT)
            //            {
            //                //Contamos
            //                _Int_CantidadDocumentos++;
            //                //Cambiamos la bandera
            //                _Bol_Documentos_Validos = false;
            //                if (_Int_CantidadDocumentos == 1)
            //                    _Str_Mensaje += "" + _oFactura.NºDocumento + "";
            //                else
            //                    _Str_Mensaje += "," + _oFactura.NºDocumento + "";
            //            }
            //        }
            //    }
            //});
            ////Si esta activo el swicheo de los reintegros
            //if (_Bol_EstaActivoReintegros)
            //{
            //    if (!_Bol_Documentos_Validos)
            //    {
            //        if (_Int_CantidadDocumentos == 1)
            //            MessageBox.Show("La factura # " + _Str_Mensaje + " no tiene el monto mínimo para aplicar una retención ISLR, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        else
            //            MessageBox.Show("Las facturas # (" + _Str_Mensaje + ") no tiene el monto mínimo para aplicar una retención ISLR, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return false;
            //    }
            //}

            /*  
             * ----------------------------------------------------------------------------------------------------------------------------------------
             *  06
             *  Validamos que los documentos que tiene relacionado una retencion de IVA sobre pasen las UT permitidas
             * ----------------------------------------------------------------------------------------------------------------------------------------
             */
            //Calculamos los montos a validar
            var _Dec_MontominimoUT = _Mtd_ObtenerPermitidoMontoUT();

            _Str_Mensaje = "";
            _Int_CantidadDocumentos = 0;
            _Bol_Documentos_Validos = true;
            _oDocumentos = _oDatos.Where(x => x.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionIVA).ToList();
            _oDocumentos.ForEach(x =>
            {
                var _Str_cnumdocumafec = x.cnumdocumafec;
                //Buscamos si existe su factura correspondiente
                var _oFactura = _oDatos.SingleOrDefault(y => y.cproveedor == x.cproveedor && y.NºDocumento.Trim() == _Str_cnumdocumafec);
                //Validamos
                if (_oFactura != null)
                {
                    //Validamos el IVA
                    if ((_oFactura.cmontoimp != null) && (Math.Round(Convert.ToDecimal(_oFactura.cmontoimp), 2) > 0))
                    {
                        //Validamos los montos
                        var _Dec_MontoFactura = Convert.ToDecimal(_oFactura.cmontototal);
                        if (_Dec_MontoFactura <= _Dec_MontominimoUT)
                        {
                            //Contamos
                            _Int_CantidadDocumentos++;
                            //Cambiamos la bandera
                            _Bol_Documentos_Validos = false;
                            if (_Int_CantidadDocumentos == 1)
                                _Str_Mensaje += "" + _oFactura.NºDocumento + "";
                            else
                                _Str_Mensaje += "," + _oFactura.NºDocumento + "";
                        }
                    }
                }
            });
            //Si esta activo el swicheo de los reintegros
            if (_Bol_EstaActivoReintegros)
            {
                if (!_Bol_Documentos_Validos)
                {
                    if (_Int_CantidadDocumentos == 1)
                        MessageBox.Show("La factura # " + _Str_Mensaje + " no tiene el monto mínimo para aplicar una retención IVA, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Las facturas # (" + _Str_Mensaje + ") no tiene el monto mínimo para aplicar una retención IVA, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }


            /*  
             * ----------------------------------------------------------------------------------------------------------------------------------------
             *  07
             *  Validamos que todas las retenciones de ISLR, el monto retenido no sea mayor que el impuesto del documento relacionado
             * ----------------------------------------------------------------------------------------------------------------------------------------
             */
            _Str_Mensaje = "";
            _Int_CantidadDocumentos = 0;
            _Bol_Documentos_Validos = true;
            _oDocumentos = _oDatos.Where(x => x.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionISLR).ToList();
            _oDocumentos.ForEach(x =>
            {
                var _Str_cnumdocumafec = x.cnumdocumafec;
                //Buscamos si existe su factura correspondiente
                var _oFactura = _oDatos.SingleOrDefault(y => y.cproveedor == x.cproveedor && y.NºDocumento.Trim() == _Str_cnumdocumafec);
                //Validamos
                if (_oFactura != null)
                {
                    //Validamos el IVA
                    if ((_oFactura.cmontoimp != null) && (Math.Round(Convert.ToDecimal(_oFactura.cmontoimp), 2) > 0))
                    {
                        //Validamos los montos
                        var _Dec_MontoRetenido = Convert.ToDecimal(x.cmontototal);
                        var _Dec_MontoImpuesto = Convert.ToDecimal(_oFactura.cmontoimp);
                        if (_Dec_MontoRetenido > _Dec_MontoImpuesto)
                        {
                            //Contamos
                            _Int_CantidadDocumentos++;
                            //Cambiamos la bandera
                            _Bol_Documentos_Validos = false;
                            if (_Int_CantidadDocumentos == 1)
                                _Str_Mensaje += "" + x.NºDocumento + "";
                            else
                                _Str_Mensaje += "," + x.NºDocumento + "";
                        }
                    }
                }
            });
            //Si esta activo el swicheo de los reintegros
            if (_Bol_EstaActivoReintegros)
            {
                if (!_Bol_Documentos_Validos)
                {
                    if (_Int_CantidadDocumentos == 1)
                        MessageBox.Show("El monto retenido de la Retención ISLR # " + _Str_Mensaje + " sobrepasa el monto del impuesto de la Factura relacionada, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("El monto retenido de las Retenciones ISLR # (" + _Str_Mensaje + ") sobrepasan el monto del impuesto de sus respectivas Facturas relacionadas, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            /*  
             * ----------------------------------------------------------------------------------------------------------------------------------------
             *  08
             *  Validamos que todas las retenciones de IVA, el monto retenido no sea mayor que el impuesto del documento relacionado
             * ----------------------------------------------------------------------------------------------------------------------------------------
             */
            _Str_Mensaje = "";
            _Int_CantidadDocumentos = 0;
            _Bol_Documentos_Validos = true;
            _oDocumentos = _oDatos.Where(x => x.ctipodocumentodetalle == (byte)_TipoDocumentoReposicion.RetencionIVA).ToList();
            _oDocumentos.ForEach(x =>
            {
                var _Str_cnumdocumafec = x.cnumdocumafec;
                //Buscamos si existe su factura correspondiente
                var _oFactura = _oDatos.SingleOrDefault(y => y.cproveedor == x.cproveedor && y.NºDocumento.Trim() == _Str_cnumdocumafec);
                //Validamos
                if (_oFactura != null)
                {
                    //Validamos el IVA
                    if ((_oFactura.cmontoimp != null) && (Math.Round(Convert.ToDecimal(_oFactura.cmontoimp), 2) > 0))
                    {
                        //Validamos los montos
                        var _Dec_MontoRetenido = Convert.ToDecimal(x.cmontototal);
                        var _Dec_MontoImpuesto = Convert.ToDecimal(_oFactura.cmontoimp);
                        if (_Dec_MontoRetenido > _Dec_MontoImpuesto)
                        {
                            //Contamos
                            _Int_CantidadDocumentos++;
                            //Cambiamos la bandera
                            _Bol_Documentos_Validos = false;
                            if (_Int_CantidadDocumentos == 1)
                                _Str_Mensaje += "" + x.NºDocumento + "";
                            else
                                _Str_Mensaje += "," + x.NºDocumento + "";
                        }
                    }
                }
            });
            //Si esta activo el swicheo de los reintegros
            if (_Bol_EstaActivoReintegros)
            {
                if (!_Bol_Documentos_Validos)
                {
                    if (_Int_CantidadDocumentos == 1)
                        MessageBox.Show("El monto retenido de la Retención IVA # " + _Str_Mensaje + " sobrepasa el monto del impuesto de la Factura relacionada, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("El monto retenido de las Retenciones IVA # (" + _Str_Mensaje + ") sobrepasan el monto del impuesto de sus respectivas Facturas relacionadas, verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            //Todo esta bien
            return true;
        }
        #endregion

        private decimal _Mtd_ObtenerPermitidoMontoUT()
        {
            Program._Dat_Tablas =
              new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            //---------------------
            int _Int_UnidadesTributarias = (int)(from Campos in Program._Dat_Tablas.TCONFIGCXP
                                                 where Campos.ccompany == Frm_Padre._Str_Comp
                                                 select new { Campos.cfactormaxfacrepos }).Single().cfactormaxfacrepos;
            //---------------------
            decimal _Dcm_UT = (decimal)(from Campos in Program._Dat_Tablas.TUNITRIBUT
                                        where Campos.cunitrib == "UT"
                                        select new { Campos.cvalor }).Single().cvalor;
            //---------------------
            decimal _Dcm_Monto = _Int_UnidadesTributarias * _Dcm_UT;
            //---------------------
            return _Dcm_Monto;
        }


        #region Botones Cerrar Panel

        private void _Bt_Cerrar_Click(object sender, EventArgs e)
        {
            _Pnl_Descontar.Visible = false; _Txt_Concepto.Text = ""; _Txt_Cuenta.Text = ""; _Txt_Cuenta.Tag = ""; _Txt_Anticipo.Text = "";
        }

        private void _Bt_Cerrar_RetencionISLR_Click(object sender, EventArgs e)
        {
            _Pnl_Descontar_RetencionISLR.Visible = false; _Txt_Concepto_RetencionISLR.Text = ""; _Txt_RetencionISLR.Text = "";
        }

        private void _Bt_Cerrar_RetencionIVA_Click(object sender, EventArgs e)
        {
            _Pnl_Descontar_RetencionIVA.Visible = false; _Txt_Concepto_RetencionIVA.Text = ""; _Txt_RetencionIVA.Text = "";
        }
    
        #endregion

        #region Botones Buscar Cuenta Contable

        private void _Bt_BuscarCuenta_Click(object sender, EventArgs e)
        {
            TextBox _Txt_Temp = new TextBox();
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(45, _Txt_Temp, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
            if (_Txt_Temp.Text.Trim().Length > 0)
            {
                _Txt_Cuenta.Tag = _Txt_Temp.Text.Trim();
                _Txt_Cuenta.Text = _Txt_Temp.Text.Trim() + " " + Convert.ToString(_Txt_Temp.Tag).Trim().ToUpper();
            }
        }

        #endregion

        #region Botones Buscar Documento

        private void _Bt_BuscarAnticipo_Click(object sender, EventArgs e)
        {
            Frm_ReposicionCxP_Anticipos _Frm = new Frm_ReposicionCxP_Anticipos();
            _Frm.ShowDialog(this);
            if (Convert.ToString(_Frm.Tag).Trim().Length > 0)
            {
                _Txt_Anticipo.Text = _Mtd_FormtadoMoneda(_Mtd_MontoEmisionCheq(Convert.ToInt32(_Frm.Tag)));
                _Txt_Anticipo.Tag = _Frm.Tag;
            }
        }

        private void _Bt_BuscarRetencionISLR_Click(object sender, EventArgs e)
        {
            var _Txt_Temp = new TextBox();
            Cursor = Cursors.WaitCursor;
            var _Frm = new Frm_Busqueda2(102, _Txt_Temp, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
            if (_Txt_Temp.Text.Trim().Length > 0)
            {
                _Txt_RetencionISLR.Tag = _Txt_Temp.Tag;
                _Txt_RetencionISLR.Text = _Txt_Temp.Text.Trim();
            }
        }

        private void _Bt_Buscar_RetencionIVA_Click(object sender, EventArgs e)
        {
            var _Txt_Temp = new TextBox();
            Cursor = Cursors.WaitCursor;
            var _Frm = new Frm_Busqueda2(103, _Txt_Temp, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
            if (_Txt_Temp.Text.Trim().Length > 0)
            {
                _Txt_RetencionIVA.Tag = _Txt_Temp.Tag;
                _Txt_RetencionIVA.Text = _Txt_Temp.Text.Trim();
            }
        }
        
        #endregion

        #region Botones Aceptar Descuento

        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (!_Mtd_EsValidaLaReposicionActual_NoEstaFinalizada()) return;
            if (_Txt_Concepto.Text.Trim().Length > 0 & _Txt_Cuenta.Text.Trim().Length > 0 & _Txt_Anticipo.Text.Trim().Length > 0)
            {
                bool _Bol_Aceptar = true;

                //Si esta activo el swicheo de los reintegros
                if (!CLASES._Cls_Varios_Metodos._Mtd_EstaActivoReintegros())
                {
                    if (Convert.ToString(_Pnl_Descontar.Tag).Trim().Length > 0)
                    {
                        decimal _Dcm_CantidadSumRes = ((decimal)_Mtd_MontoReposicionDetalle(Convert.ToInt32(_Txt_Reposicion.Text), Convert.ToInt32(_Pnl_Descontar.Tag)) * -1) + Convert.ToDecimal(_Txt_Anticipo.Text);
                        if (_Mtd_ReposicionNegativa(Convert.ToInt32(_Txt_Reposicion.Text), 0, _Dcm_CantidadSumRes))
                        { _Bol_Aceptar = false; MessageBox.Show("No se puede ingresar el anticipo debido a que el monto de la reposición quedaría en negativo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                    else
                    {
                        if (_Mtd_ReposicionNegativa(Convert.ToInt32(_Txt_Reposicion.Text), 0, Convert.ToDecimal(_Txt_Anticipo.Text)))
                        { _Bol_Aceptar = false; MessageBox.Show("No se puede ingresar el anticipo debido a que el monto de la reposición quedaría en negativo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                }
                
                if (_Bol_Aceptar)
                {
                    if (_Txt_Reposicion.Text.Trim().Length > 0)
                    {
                        if (Convert.ToString(_Pnl_Descontar.Tag).Trim().Length > 0)
                        { _Mtd_ModificarDetalle(Convert.ToInt32(_Txt_Reposicion.Text), Convert.ToInt32(_Pnl_Descontar.Tag), _TipoDocumentoReposicion.Anticipo, Convert.ToInt32(_Txt_Anticipo.Tag), Convert.ToString(_Txt_Cuenta.Tag).Trim(), _Txt_Concepto.Text); }
                        else
                        { _Mtd_InsertarDetalle(Convert.ToInt32(_Txt_Reposicion.Text), new _Cls_Consecutivos()._Mtd_ReposicionDetalle(Convert.ToInt32(_Txt_Reposicion.Text)), _TipoDocumentoReposicion.Anticipo, Convert.ToInt32(_Txt_Anticipo.Tag), Convert.ToString(_Txt_Cuenta.Tag).Trim(), _Txt_Concepto.Text); }
                        _Mtd_ModificarMaestra(Convert.ToInt32(_Txt_Reposicion.Text), false);
                    }
                    else
                    {
                        int _Int_Reposicion = new _Cls_Consecutivos()._Mtd_Reposicion();
                        _Mtd_InsertarMaestra(_Int_Reposicion, Convert.ToDecimal(_Txt_Anticipo.Text), 0, 0, 0, false);
                        _Mtd_InsertarDetalle(_Int_Reposicion, new _Cls_Consecutivos()._Mtd_ReposicionDetalle(_Int_Reposicion), _TipoDocumentoReposicion.Anticipo, Convert.ToInt32(_Txt_Anticipo.Tag), Convert.ToString(_Txt_Cuenta.Tag).Trim(), _Txt_Concepto.Text);
                        _Txt_Reposicion.Text = _Int_Reposicion.ToString();
                    }
                    //MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Pnl_Descontar.Visible = false; _Txt_Concepto.Text = ""; _Txt_Cuenta.Text = ""; _Txt_Cuenta.Tag = ""; _Txt_Anticipo.Text = "";
                    _Mtd_Actualizar();
                    _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_Reposicion.Text));
                }
            }
            else
            {
                if (_Txt_Concepto.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Concepto, "Información Requerida!!!"); }
                if (_Txt_Cuenta.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_BuscarCuenta, "Información Requerida!!!"); }
                if (_Txt_Anticipo.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_BuscarAnticipo, "Información Requerida!!!"); }
            }
        }

        private void _Bt_Aceptar_RetencionISLR_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (!_Mtd_EsValidaLaReposicionActual_NoEstaFinalizada()) return;
            if (_Txt_Concepto_RetencionISLR.Text.Trim().Length > 0 & _Txt_RetencionISLR.Text.Trim().Length > 0)
            {
                bool _Bol_Aceptar = true;
                if (_Bol_Aceptar)
                {
                    if (_Txt_Reposicion.Text.Trim().Length > 0)
                    {
                        if (Convert.ToString(_Pnl_Descontar_RetencionISLR.Tag).Trim().Length > 0)
                        { _Mtd_ModificarDetalle(Convert.ToInt32(_Txt_Reposicion.Text), Convert.ToInt32(_Pnl_Descontar_RetencionISLR.Tag), _TipoDocumentoReposicion.RetencionISLR, Convert.ToInt32(_Txt_RetencionISLR.Tag), "", _Txt_Concepto_RetencionISLR.Text); }
                        else
                        { _Mtd_InsertarDetalle(Convert.ToInt32(_Txt_Reposicion.Text), new _Cls_Consecutivos()._Mtd_ReposicionDetalle(Convert.ToInt32(_Txt_Reposicion.Text)), _TipoDocumentoReposicion.RetencionISLR, Convert.ToInt32(_Txt_RetencionISLR.Tag), "", _Txt_Concepto_RetencionISLR.Text); }
                        _Mtd_ModificarMaestra(Convert.ToInt32(_Txt_Reposicion.Text), false);
                    }
                    else
                    {
                        int _Int_Reposicion = new _Cls_Consecutivos()._Mtd_Reposicion();
                        _Mtd_InsertarMaestra(_Int_Reposicion, Convert.ToDecimal(_Txt_RetencionISLR.Text), 0, 0, 0, false);
                        _Mtd_InsertarDetalle(_Int_Reposicion, new _Cls_Consecutivos()._Mtd_ReposicionDetalle(_Int_Reposicion), _TipoDocumentoReposicion.RetencionISLR, Convert.ToInt32(_Txt_RetencionISLR.Tag), "", _Txt_Concepto_RetencionISLR.Text);
                        _Txt_Reposicion.Text = _Int_Reposicion.ToString();
                    }
                    //MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Pnl_Descontar_RetencionISLR.Visible = false; _Txt_Concepto_RetencionISLR.Text = ""; _Txt_RetencionISLR.Text = "";
                    _Mtd_Actualizar();
                    _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_Reposicion.Text));
                }
            }
            else
            {
                if (_Txt_Concepto_RetencionISLR.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Concepto_RetencionISLR, "Información Requerida!!!"); }
                if (_Txt_RetencionISLR.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_Buscar_RetencionISLR, "Información Requerida!!!"); }
            }
        }

        private void _Bt_Aceptar_RetencionIVA_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (!_Mtd_EsValidaLaReposicionActual_NoEstaFinalizada()) return;
            if (_Txt_Concepto_RetencionIVA.Text.Trim().Length > 0 & _Txt_RetencionIVA.Text.Trim().Length > 0)
            {
                bool _Bol_Aceptar = true;
                if (_Bol_Aceptar)
                {
                    if (_Txt_Reposicion.Text.Trim().Length > 0)
                    {
                        if (Convert.ToString(_Pnl_Descontar_RetencionIVA.Tag).Trim().Length > 0)
                        { _Mtd_ModificarDetalle(Convert.ToInt32(_Txt_Reposicion.Text), Convert.ToInt32(_Pnl_Descontar_RetencionIVA.Tag), _TipoDocumentoReposicion.RetencionIVA , Convert.ToInt32(_Txt_RetencionIVA.Tag), "", _Txt_Concepto_RetencionIVA.Text); }
                        else
                        { _Mtd_InsertarDetalle(Convert.ToInt32(_Txt_Reposicion.Text), new _Cls_Consecutivos()._Mtd_ReposicionDetalle(Convert.ToInt32(_Txt_Reposicion.Text)), _TipoDocumentoReposicion.RetencionIVA, Convert.ToInt32(_Txt_RetencionIVA.Tag), "", _Txt_Concepto_RetencionIVA.Text); }
                        _Mtd_ModificarMaestra(Convert.ToInt32(_Txt_Reposicion.Text), false);
                    }
                    else
                    {
                        int _Int_Reposicion = new _Cls_Consecutivos()._Mtd_Reposicion();
                        _Mtd_InsertarMaestra(_Int_Reposicion, Convert.ToDecimal(_Txt_RetencionIVA.Text), 0, 0, 0, false);
                        _Mtd_InsertarDetalle(_Int_Reposicion, new _Cls_Consecutivos()._Mtd_ReposicionDetalle(_Int_Reposicion), _TipoDocumentoReposicion.RetencionIVA, Convert.ToInt32(_Txt_RetencionIVA.Tag), "", _Txt_Concepto_RetencionIVA.Text);
                        _Txt_Reposicion.Text = _Int_Reposicion.ToString();
                    }
                    //MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Pnl_Descontar_RetencionIVA.Visible = false; _Txt_Concepto_RetencionIVA.Text = ""; _Txt_RetencionIVA.Text = "";
                    _Mtd_Actualizar();
                    _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_Reposicion.Text));
                }
            }
            else
            {
                if (_Txt_Concepto_RetencionIVA.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Concepto_RetencionIVA, "Información Requerida!!!"); }
                if (_Txt_RetencionIVA.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_Buscar_RetencionIVA, "Información Requerida!!!"); }
            }
        }

        #endregion

        #region Botones Aceptar Descuento

        private void _Bt_Cancelar_Click(object sender, EventArgs e)
        {
            _Pnl_Descontar.Visible = false; _Txt_Concepto.Text = ""; _Txt_Cuenta.Text = ""; _Txt_Cuenta.Tag = ""; _Txt_Anticipo.Text = "";
        }

        private void _Bt_Cancelar_RetencionISLR_Click(object sender, EventArgs e)
        {
            _Pnl_Descontar_RetencionISLR.Visible = false; _Txt_Concepto_RetencionISLR.Text = ""; _Txt_RetencionISLR.Text = "";
        }

        private void _Bt_Cancelar_RetencionIVA_Click(object sender, EventArgs e)
        {
            _Pnl_Descontar_RetencionIVA.Visible = false; _Txt_Concepto_RetencionIVA.Text = ""; _Txt_RetencionIVA.Text = "";
        }

        #endregion

        #region Botones Aceptar Descuento

        private void _Pnl_Descontar_VisibleChanged(object sender, EventArgs e)
        {
            _Tb_Tab.Enabled = !_Pnl_Descontar.Visible;
        }

        private void _Pnl_Descontar_RetencionISRL_VisibleChanged(object sender, EventArgs e)
        {
            _Tb_Tab.Enabled = !_Pnl_Descontar_RetencionISLR.Visible;
        }

        private void _Pnl_Descontar_RetencionIVA_VisibleChanged(object sender, EventArgs e)
        {
            _Tb_Tab.Enabled = !_Pnl_Descontar_RetencionIVA.Visible;
        }

        #endregion

        private void _Bt_Descontar_RetencionPatente_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (!_Mtd_EsValidaLaReposicionActual_NoEstaFinalizada()) return;
            if (_Txt_Motivo.Text.Trim().Length > 0 && _Txt_Beneficiario.Text.Trim().Length > 0 && (((_Cmb_Entidad.SelectedIndex > 0 && _Txt_Entidad.Text.Trim().Length > 0) || Convert.ToString(_Cmb_Entidad.SelectedValue).Trim() == "3") | Convert.ToString(_Cmb_TipoReposicion.SelectedValue) == "C"))
            {
                _Pnl_Descontar_RetencionPatente.Tag = "";
                _Pnl_Descontar_RetencionPatente.Visible = true;
            }
            else
            {
                if (_Txt_Motivo.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_EditarMotivo, "Información Requerida!!!"); }
                if (_Txt_Beneficiario.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Beneficiario, "Información Requerida!!!"); }
                if (Convert.ToString(_Cmb_TipoReposicion.SelectedValue) == "G")
                {
                    if (_Cmb_Entidad.SelectedIndex <= 0) { _Er_Error.SetError(_Cmb_Entidad, "Información Requerida!!!"); }
                    if (_Cmb_Entidad.SelectedIndex > 0 && Convert.ToString(_Cmb_Entidad.SelectedValue).Trim() != "3")
                    {
                        if (_Txt_Entidad.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_Buscar, "Información Requerida!!!"); }
                    }
                }
            }
        }

        private void _Bt_Cerrar_RetencionPatente_Click(object sender, EventArgs e)
        {
            _Pnl_Descontar_RetencionPatente.Visible = false; _Txt_Concepto_RetencionPatente.Text = ""; _Txt_RetencionPatente.Text = "";
        }

        private void _Bt_Cancelar_RetencionPatente_Click(object sender, EventArgs e)
        {
            _Pnl_Descontar_RetencionPatente.Visible = false; _Txt_Concepto_RetencionPatente.Text = ""; _Txt_RetencionPatente.Text = "";
        }

        private void _Bt_Aceptar_RetencionPatente_Click(object sender, EventArgs e)
        {
            _Er_Error.Dispose();
            if (!_Mtd_EsValidaLaReposicionActual_NoEstaFinalizada()) return;
            if (_Txt_Concepto_RetencionPatente.Text.Trim().Length > 0 & _Txt_RetencionPatente.Text.Trim().Length > 0)
            {
                bool _Bol_Aceptar = true;
                if (_Bol_Aceptar)
                {
                    if (_Txt_Reposicion.Text.Trim().Length > 0)
                    {
                        if (Convert.ToString(_Pnl_Descontar_RetencionPatente.Tag).Trim().Length > 0)
                        { _Mtd_ModificarDetalle(Convert.ToInt32(_Txt_Reposicion.Text), Convert.ToInt32(_Pnl_Descontar_RetencionPatente.Tag), _TipoDocumentoReposicion.RetencionPatente, Convert.ToInt32(_Txt_RetencionPatente.Tag), "", _Txt_Concepto_RetencionPatente.Text); }
                        else
                        { _Mtd_InsertarDetalle(Convert.ToInt32(_Txt_Reposicion.Text), new _Cls_Consecutivos()._Mtd_ReposicionDetalle(Convert.ToInt32(_Txt_Reposicion.Text)), _TipoDocumentoReposicion.RetencionPatente, Convert.ToInt32(_Txt_RetencionPatente.Tag), "", _Txt_Concepto_RetencionPatente.Text); }
                        _Mtd_ModificarMaestra(Convert.ToInt32(_Txt_Reposicion.Text), false);
                    }
                    else
                    {
                        int _Int_Reposicion = new _Cls_Consecutivos()._Mtd_Reposicion();
                        _Mtd_InsertarMaestra(_Int_Reposicion, Convert.ToDecimal(_Txt_RetencionPatente.Text), 0, 0, 0, false);
                        _Mtd_InsertarDetalle(_Int_Reposicion, new _Cls_Consecutivos()._Mtd_ReposicionDetalle(_Int_Reposicion), _TipoDocumentoReposicion.RetencionPatente, Convert.ToInt32(_Txt_RetencionPatente.Tag), "", _Txt_Concepto_RetencionPatente.Text);
                        _Txt_Reposicion.Text = _Int_Reposicion.ToString();
                    }
                    //MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Pnl_Descontar_RetencionPatente.Visible = false; _Txt_Concepto_RetencionPatente.Text = ""; _Txt_RetencionPatente.Text = "";
                    _Mtd_Actualizar();
                    _Mtd_ActualizarDetalle(Convert.ToInt32(_Txt_Reposicion.Text));
                }
            }
            else
            {
                if (_Txt_Concepto_RetencionPatente.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Concepto_RetencionPatente, "Información Requerida!!!"); }
                if (_Txt_RetencionPatente.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_Buscar_RetencionPatente, "Información Requerida!!!"); }
            }
        }

        private void _Bt_Buscar_RetencionPatente_Click(object sender, EventArgs e)
        {
            var _Txt_Temp = new TextBox();
            Cursor = Cursors.WaitCursor;
            var _Frm = new Frm_Busqueda2(104, _Txt_Temp, 0, "");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
            if (_Txt_Temp.Text.Trim().Length > 0)
            {
                _Txt_RetencionPatente.Tag = _Txt_Temp.Tag;
                _Txt_RetencionPatente.Text = _Txt_Temp.Text.Trim();
            }
        }


    }
}

