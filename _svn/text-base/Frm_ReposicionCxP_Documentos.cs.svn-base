using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
namespace T3
{
    public partial class Frm_ReposicionCxP_Documentos : Form
    {
        CLASES._Cls_Varios_Metodos _Cls_VariosMetodos = new CLASES._Cls_Varios_Metodos(true);
        clslibraryconssa._Cls_Formato _Cls_Formato = new clslibraryconssa._Cls_Formato("es-VE");
        Frm_ReposicionCxP _Frm_Reposicion;
        int _Int_ReposicionDetalle = 0;
        public Frm_ReposicionCxP_Documentos()
        {
            InitializeComponent();
        }
        public Frm_ReposicionCxP_Documentos(Frm_ReposicionCxP _P_Frm_Reposicion)
        {
            InitializeComponent();
            _Frm_Reposicion = _P_Frm_Reposicion;
            _Mtd_Color_Estandar(this);
            _Mtd_CargarTipo();
            _Txt_Alicuota.Text = _Mtd_OptenerImpuesto();
        }
        public Frm_ReposicionCxP_Documentos(Frm_ReposicionCxP _P_Frm_Reposicion, int _P_Int_ReposicionDetalle)
        {
            InitializeComponent();
            _Frm_Reposicion = _P_Frm_Reposicion;
            _Int_ReposicionDetalle = _P_Int_ReposicionDetalle;
            _Mtd_Color_Estandar(this);
            _Mtd_CargarTipo();
            _Mtd_CargarFormulario(Convert.ToInt32(_P_Frm_Reposicion._Txt_Reposicion.Text), _P_Int_ReposicionDetalle);
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
                    new CLASES._Cls_Varios_Metodos(new Control[] { _Ctrl })._Mtd_Foco();
                }
            }
        }
        private bool _Mtd_VerifContTextBoxNumeric(TextBox _P_Txt_TextBox)
        {
            if (_P_Txt_TextBox.Text.Trim().Length > 0)
            {
                if (Convert.ToDouble(_P_Txt_TextBox.Text) > 0)
                { return true; }
            }
            return false;
        }
        private void _Mtd_CargarTipo()
        {
            _Cls_CargarCombo _Cls_Cargar = new _Cls_CargarCombo();
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("nulo", "..."));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("0", "SERVICIO"));
            //_Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("1", "MATERIA PRIMA"));
            _Cls_Cargar._List_Lista.Add(new _Cls_CargarCombo("2", "OTROS"));
            _Cmb_TipoProv.DataSource = _Cls_Cargar._List_Lista;
            _Cmb_TipoProv.ValueMember = "Value";
            _Cmb_TipoProv.DisplayMember = "Display";
            _Cmb_TipoProv.SelectedValue = "nulo";
        }
        private void _Mtd_CargarCategProv()
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT ccatproveedor,UPPER(cnombre) AS Nombre FROM TCATPROVEEDOR WHERE cdelete='0'";
            if (_Cmb_TipoProv.SelectedIndex > 0)
            { _Str_Cadena += " AND cglobal='" + _Cmb_TipoProv.SelectedValue.ToString().Trim() + "'"; }
            _Str_Cadena += " ORDER BY Nombre";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_CategProv, _Str_Cadena);
            Cursor = Cursors.Default;
        }
        private void _Mtd_CargarProvee(string _P_Str_Tipo)
        {
            Cursor = Cursors.WaitCursor;
            string _Str_Cadena = "SELECT DISTINCT TPROVEEDOR.cproveedor,TPROVEEDOR.c_nomb_comer FROM TPROVEEDOR LEFT JOIN TGRUPPROVEE ON TPROVEEDOR.cproveedor = TGRUPPROVEE.cproveedor WHERE ISNULL(TPROVEEDOR.cdelete,0)='0' AND ISNULL(TGRUPPROVEE.cdelete,0)='0' AND TPROVEEDOR.c_activo='1'";
            if (_P_Str_Tipo == "0" | _P_Str_Tipo == "2")
            { _Str_Cadena += " AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "' AND TPROVEEDOR.cglobal='" + _P_Str_Tipo + "'"; }
            //else
            //{ _Str_Cadena += " AND TGRUPPROVEE.ccompany='" + Frm_Padre._Str_Comp + "' AND cglobal='" + _P_Str_Tipo + "'"; }
            //-----------
            if (_Cmb_CategProv.SelectedIndex > 0)
            { _Str_Cadena += " AND TPROVEEDOR.ccatproveedor='" + _Cmb_CategProv.SelectedValue.ToString().Trim() + "'"; }
            _Str_Cadena += " ORDER BY TPROVEEDOR.c_nomb_comer";
            _Cls_VariosMetodos._Mtd_CargarCombo(_Cmb_Proveedor, _Str_Cadena);
            Cursor = Cursors.Default;
        }
        private string _Mtd_OptenerImpuesto()
        {
            string _Str_Cadena = "SELECT cpercent FROM TTAX WHERE ctax=(SELECT ctipimpuesto FROM TCONFIGCXP WHERE ccompany='" + Frm_Padre._Str_Comp + "')";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            if (_Ds.Tables[0].Rows[0][0] != System.DBNull.Value)
            { return _Ds.Tables[0].Rows[0][0].ToString().Trim(); }
            else
            { return "0"; }
        }
        private void _Mtd_Ini()
        {
            _Chk_FactMaqFis.Checked = false;
            _Txt_NumDocu.Text = "";
            _Txt_NumCtrl.Text = "";
            _Txt_NumCtrlPref.Text = "";
            _Txt_Concepto.Text = "";
            _Txt_BaseImponible.Text = "";
            _Txt_MontoExento.Text = "";
            _Txt_Impuesto.Text = "";
            _Txt_MontoTotal.Text = "";
            _Txt_Cuenta.Text = "";
            _Dtp_Emision.Value = CLASES._Cls_Varios_Metodos._Mtd_SQLGetDateServ();
            _Rb_ConIva.Checked = !_Chk_NoLibComp.Checked;
        }
        private void _Mtd_Habilitar(bool _P_Bol_Habilitar)
        {
            _Txt_NumDocu.Enabled = _P_Bol_Habilitar;
            _Txt_Alicuota.Enabled = _P_Bol_Habilitar;
            _Chk_FactMaqFis.Enabled = _P_Bol_Habilitar;
            if (_P_Bol_Habilitar)
            { _Txt_NumCtrl.Enabled = !_Chk_FactMaqFis.Checked; _Txt_NumCtrlPref.Enabled = !_Chk_FactMaqFis.Checked; }
            else
            { _Txt_NumCtrl.Enabled = false; _Txt_NumCtrlPref.Enabled = false; }
            _Txt_Concepto.Enabled = _P_Bol_Habilitar;
            _Txt_BaseImponible.Enabled = _P_Bol_Habilitar & !_Chk_NoLibComp.Checked;
            _Txt_MontoExento.Enabled = _P_Bol_Habilitar;
            _Txt_Impuesto.Enabled = _P_Bol_Habilitar;
            _Txt_MontoTotal.Enabled = _P_Bol_Habilitar;
            _Txt_Cuenta.Enabled = _P_Bol_Habilitar;
            _Dtp_Emision.Enabled = _P_Bol_Habilitar;
            _Rb_ConIva.Enabled = _P_Bol_Habilitar & !_Chk_NoLibComp.Checked;
            _Rb_SinIva.Enabled = _P_Bol_Habilitar;
            _Bt_Aceptar.Enabled = _P_Bol_Habilitar;
        }
        private string _Mtd_NumeroControl(string _P_Str_NumCtrlPref, string _P_Str_NumCtrl)
        {
            if (_P_Str_NumCtrl.Trim().Length == 0)
            {
                return "NA";
            }
            else
            {
                string _Str_Pref = _P_Str_NumCtrlPref.Trim();
                string _Str_NumCtrl = "00000000";
                if (_P_Str_NumCtrlPref.Trim().Length == 0)
                {
                    _Str_Pref = "00";
                }
                else if (_P_Str_NumCtrlPref.Trim().Length == 1 & _Cls_VariosMetodos._Mtd_IsNumeric(_P_Str_NumCtrlPref.Trim()))
                {
                    _Str_Pref = "0" + _P_Str_NumCtrlPref.Trim();
                }
                _Str_NumCtrl = _Str_NumCtrl.Remove(0, _P_Str_NumCtrl.Trim().Length) + _P_Str_NumCtrl.Trim();
                return _Str_Pref + "-" + _P_Str_NumCtrl;//_Str_NumCtrl
            }
        }
        private void _Mtd_CalularMontos()
        {
            double _Dbl_BaseImpon = 0;
            double _Dbl_MontoExcento = 0;
            double _Dbl_Alicuota = 0;
            double _Dbl_Impuesto = 0;
            //------------
            if (_Txt_BaseImponible.Text.Trim().Length > 0)
            { _Dbl_BaseImpon = Convert.ToDouble(_Txt_BaseImponible.Text); }
            //------------
            if (_Txt_MontoExento.Text.Trim().Length > 0)
            { _Dbl_MontoExcento = Convert.ToDouble(_Txt_MontoExento.Text); }
            //------------
            if (_Txt_Alicuota.Text.Trim().Length > 0)
            { _Dbl_Alicuota = Convert.ToDouble(_Txt_Alicuota.Text); }
            //------------
            if (_Rb_ConIva.Checked)
            {
                _Dbl_Impuesto = (_Dbl_BaseImpon * _Dbl_Alicuota) / 100;
                _Txt_Impuesto.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(_Dbl_Impuesto).ToString("#,##0.00");
                _Txt_MontoTotal.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(_Dbl_BaseImpon + _Dbl_MontoExcento + _Dbl_Impuesto).ToString("#,##0.00");
            }
            else
            {
                _Txt_Impuesto.Text = "0";
                _Txt_MontoTotal.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(_Dbl_BaseImpon + _Dbl_MontoExcento).ToString("#,##0.00");
            }
        }
        private void _Mtd_CalularMontoTotal()
        {
            double _Dbl_BaseImpon = 0;
            double _Dbl_MontoExcento = 0;
            double _Dbl_Impuesto = 0;
            //------------
            if (_Txt_BaseImponible.Text.Trim().Length > 0)
            { _Dbl_BaseImpon = Convert.ToDouble(_Txt_BaseImponible.Text); }
            //------------
            if (_Txt_MontoExento.Text.Trim().Length > 0)
            { _Dbl_MontoExcento = Convert.ToDouble(_Txt_MontoExento.Text); }
            //------------
            if (_Txt_Impuesto.Text.Trim().Length > 0)
            { _Dbl_Impuesto = Convert.ToDouble(_Txt_Impuesto.Text); }
            //------------
            _Txt_MontoTotal.Text = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(_Dbl_BaseImpon + _Dbl_MontoExcento + _Dbl_Impuesto).ToString("#,##0.00");
        }

        private bool _Mtd_VerificarImpuesto()
        {
            double _Dbl_BaseImpon = 0;
            double _Dbl_Alicuota = 0;
            double _Dbl_ImpuestoCalculado = 0;
            double _Dbl_Impuesto = 0;
            //------------
            if (_Txt_BaseImponible.Text.Trim().Length > 0)
            { _Dbl_BaseImpon = Convert.ToDouble(_Txt_BaseImponible.Text); }
            //------------
            if (_Txt_Alicuota.Text.Trim().Length > 0)
            { _Dbl_Alicuota = Convert.ToDouble(_Txt_Alicuota.Text); }
            //------------
            if (_Txt_Impuesto.Text.Trim().Length > 0)
            { _Dbl_Impuesto = Convert.ToDouble(_Txt_Impuesto.Text); }
            //------------
            _Dbl_ImpuestoCalculado = (_Dbl_BaseImpon * _Dbl_Alicuota) / 100;
            _Dbl_ImpuestoCalculado = CLASES._Cls_Varios_Metodos._Mtd_MontoNumeric2(_Dbl_ImpuestoCalculado);

            if (_Dbl_Impuesto >= Math.Truncate(_Dbl_ImpuestoCalculado) && _Dbl_Impuesto <= Math.Truncate(_Dbl_ImpuestoCalculado) + 0.99)
            {
                return true;
            }
            else
            {
                MessageBox.Show("El impuesto debe estar entre " + Math.Truncate(_Dbl_ImpuestoCalculado).ToString("#,##0.00") + " y " + Convert.ToDouble(Math.Truncate(_Dbl_ImpuestoCalculado) + 0.99).ToString("#,##0.00"), "Requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
      
        }
        private string _Mtd_ObtenerTipoDocument()
        {
            Program._Dat_Tablas =
  new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            return (from campos in Program._Dat_Tablas.TCONFIGCXP
                              where campos.ccompany == Frm_Padre._Str_Comp
                              select campos.ctipdocfact).Single();
        }
        private void _Mtd_InsertarDetalle(int _P_Int_Reposicion, int _P_Int_ReposicionDetalle)
        {
            DataContext.TREPOSICIONESD _T_TREPOSICIONESD = new T3.DataContext.TREPOSICIONESD()
            {
                cgroupcomp = Convert.ToInt32(Frm_Padre._Str_GroupComp),
                ccompany = Frm_Padre._Str_Comp,
                cidreposiciones = _P_Int_Reposicion,
                ciddreposiciones = _P_Int_ReposicionDetalle,
                cproveedor = Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim(),
                cglobal = Convert.ToByte(_Cmb_TipoProv.SelectedValue),
                ccatproveedor = Convert.ToString(_Cmb_CategProv.SelectedValue).Trim(),
                ctipodocument = _Mtd_ObtenerTipoDocument(),
                cnumdocu = _Txt_NumDocu.Text.Trim(),
                cnumdocuctrl = _Mtd_NumeroControl(_Txt_NumCtrlPref.Text.Trim(), _Txt_NumCtrl.Text.Trim()).ToUpper(),
                cfechaemision = _Dtp_Emision.Value,
                cconcepto = _Txt_Concepto.Text.Trim().ToUpper(),
                cfactunolibcomp = Convert.ToByte(Convert.ToInt32(_Chk_NoLibComp.Checked)),
                ccuentaexep = Convert.ToString(_Txt_Cuenta.Tag).Trim(),
                cmontototal = Convert.ToDecimal(_Txt_MontoTotal.Text),
                cmontosi = Convert.ToDecimal(_Txt_BaseImponible.Text),
                cmontoimp = Convert.ToDecimal(_Txt_Impuesto.Text),
                cmontoexento = Convert.ToDecimal(_Txt_MontoExento.Text),
                cimpuesto = Convert.ToDecimal(_Txt_Alicuota.Text),
                canticipogasto = 0
            };
            Program._Dat_Tablas.TREPOSICIONESD.InsertOnSubmit(_T_TREPOSICIONESD);
            Program._Dat_Tablas.SubmitChanges();
            if (_Chk_IvaCredNoCom.Checked)
                _Mtd_ActualizarIvaCredNoComp(_P_Int_Reposicion, _P_Int_ReposicionDetalle);
        }
        private void _Mtd_ModificarDetalle(int _P_Int_Reposicion, int _P_Int_ReposicionDetalle)
        {
            string _Str_Cadena = "UPDATE TREPOSICIONESD SET cproveedor='" + Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim() + "',cglobal='" + Convert.ToByte(_Cmb_TipoProv.SelectedValue) + "'," +
                "ccatproveedor='" + Convert.ToString(_Cmb_CategProv.SelectedValue).Trim() + "',ctipodocument='" + _Mtd_ObtenerTipoDocument() + "'," +
                "cnumdocu='" + _Txt_NumDocu.Text.Trim() + "'," +
                "cnumdocuctrl='" + _Mtd_NumeroControl(_Txt_NumCtrlPref.Text.Trim(), _Txt_NumCtrl.Text.Trim()).ToUpper() + "'," +
                "cfechaemision='" + _Cls_Formato._Mtd_fecha(_Dtp_Emision.Value) + "'," +
                "cconcepto='" + _Txt_Concepto.Text.Trim().ToUpper() + "'," +
                "cfactunolibcomp='" + Convert.ToByte(Convert.ToInt32(_Chk_NoLibComp.Checked)) + "'," +
                "ccuentaexep='" + Convert.ToString(_Txt_Cuenta.Tag).Trim() + "'," +
                "cmontototal='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_MontoTotal.Text)) + "'," +
                "cmontosi='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_BaseImponible.Text)) + "'," +
                "cmontoimp='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Impuesto.Text)) + "'," +
                "cmontoexento='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_MontoExento.Text)) + "'," +
                "cimpuesto='" + CLASES._Cls_Varios_Metodos._Mtd_MontosSQL(Convert.ToDouble(_Txt_Alicuota.Text)) + "'," +
                "canticipogasto='0',civacrednocomp='" + Convert.ToInt32(_Chk_IvaCredNoCom.Checked) + "' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidreposiciones='" + _P_Int_Reposicion + "' AND ciddreposiciones='" + _P_Int_ReposicionDetalle + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);

        }

        private void _Mtd_ActualizarIvaCredNoComp(int _P_Int_Reposicion, int _P_Int_ReposicionDetalle)
        {
            string _Str_Cadena = "UPDATE TREPOSICIONESD SET civacrednocomp='1' WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidreposiciones='" + _P_Int_Reposicion + "' AND ciddreposiciones='" + _P_Int_ReposicionDetalle + "'";
            Program._MyClsCnn._mtd_conexion._Mtd_EjecutarSentencia(_Str_Cadena);
        }
        private void _Mtd_InsertarRegistros()
        {
            if (_Frm_Reposicion._Txt_Reposicion.Text.Trim().Length == 0)
            {
                if (_Txt_BaseImponible.Text.Trim().Length == 0) { _Txt_BaseImponible.Text = "0"; }
                if (_Txt_MontoExento.Text.Trim().Length == 0) { _Txt_MontoExento.Text = "0"; }
                if (_Txt_Impuesto.Text.Trim().Length == 0) { _Txt_Impuesto.Text = "0"; }
                int _Int_Reposicion = new _Cls_Consecutivos()._Mtd_Reposicion();
                _Frm_Reposicion._Mtd_InsertarMaestra(_Int_Reposicion, Convert.ToDecimal(_Txt_MontoTotal.Text), Convert.ToDecimal(_Txt_BaseImponible.Text), Convert.ToDecimal(_Txt_Impuesto.Text), Convert.ToDecimal(_Txt_MontoExento.Text), false);
                _Mtd_InsertarDetalle(_Int_Reposicion, new _Cls_Consecutivos()._Mtd_ReposicionDetalle(_Int_Reposicion));
                _Frm_Reposicion._Txt_Reposicion.Text = _Int_Reposicion.ToString();
            }
            else
            {
                if (_Txt_BaseImponible.Text.Trim().Length == 0) { _Txt_BaseImponible.Text = "0"; }
                if (_Txt_MontoExento.Text.Trim().Length == 0) { _Txt_MontoExento.Text = "0"; }
                if (_Txt_Impuesto.Text.Trim().Length == 0) { _Txt_Impuesto.Text = "0"; }
                int _Int_Reposicion = Convert.ToInt32(_Frm_Reposicion._Txt_Reposicion.Text.Trim());
                if (_Int_ReposicionDetalle == 0)
                { _Mtd_InsertarDetalle(_Int_Reposicion, new _Cls_Consecutivos()._Mtd_ReposicionDetalle(_Int_Reposicion)); }
                else
                { _Mtd_ModificarDetalle(_Int_Reposicion, _Int_ReposicionDetalle); }
                _Frm_Reposicion._Mtd_ModificarMaestra(_Int_Reposicion, false);
            }
        }
        private string _Mtd_DescripCount(string _P_Str_Count)
        {
            Program._Dat_Tablas =
  new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            return (from Campos in Program._Dat_Tablas.TCOUNT
                    where Campos.ccompany == Frm_Padre._Str_Comp & Campos.ccount == _P_Str_Count
                    select Campos.cname).Single();
        }
        private string _Mtd_CuentaProveedor(string _P_Str_Proveedor)
        {
            Program._Dat_Tablas =
  new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            return (from campos in Program._Dat_Tablas.TPROVEEDOR
                    where campos.cproveedor == _P_Str_Proveedor & (campos.ccompany == Frm_Padre._Str_Comp | campos.cglobal == 1)
                    select campos.ctcount).Single();
        }
        private decimal? _Mtd_MontoReposicionDetalle(int _P_Int_Reposicion, int _P_Int_ReposicionDetalle)
        {
            Program._Dat_Tablas =
  new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            return (from Campos in Program._Dat_Tablas.TREPOSICIONESD
                    where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidreposiciones == _P_Int_Reposicion & Campos.ciddreposiciones == _P_Int_ReposicionDetalle
                    select Campos.cmontototal).Single();
        }
        private bool _Mtd_DocumentoRepetido()
        {
            Program._Dat_Tablas =
  new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            if (_Int_ReposicionDetalle > 0)//Si entra aqui quiere decir que estoy editando el registro, de lo contrario verifica en la otra sentencia linq si el documento existe.
            {
                if ((from Campos in Program._Dat_Tablas.TREPOSICIONESD
                     where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cproveedor == Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim() & Campos.cidreposiciones == Convert.ToInt32(_Frm_Reposicion._Txt_Reposicion.Text) & Campos.ciddreposiciones == _Int_ReposicionDetalle & Campos.cnumdocu == _Txt_NumDocu.Text.Trim()
                     select Campos).Count() > 0)
                { return false; }
            }
            return (from Campos in Program._Dat_Tablas.TREPOSICIONESD
                    where Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cproveedor == Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim() & Campos.cnumdocu == _Txt_NumDocu.Text.Trim()
                    select Campos).Count() > 0;
        }
        private bool _Mtd_VerificarMontoUT(decimal _P_Dcm_MontoDocument)
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
            if (_P_Dcm_MontoDocument > _Dcm_Monto)
            { return false; }
            return true;
        }
        private bool _Mtd_MontoValido()
        {
            if (_Frm_Reposicion._Txt_Reposicion.Text.Trim().Length > 0 & _Int_ReposicionDetalle > 0)
            {
                decimal _Dcm_CantidadSumRes = (decimal)_Mtd_MontoReposicionDetalle(Convert.ToInt32(_Frm_Reposicion._Txt_Reposicion.Text), _Int_ReposicionDetalle) - Convert.ToDecimal(_Txt_MontoTotal.Text);//Cantidad que se le esta agregando ó quitando al monto total de una reposición(Maestra). Nota: Esto es cuando se edita el monto. Si no se edita el monto debe dar 0.
                if (_Frm_Reposicion._Mtd_ReposicionNegativa(Convert.ToInt32(_Frm_Reposicion._Txt_Reposicion.Text), _Dcm_CantidadSumRes, 0))
                {
                    return false;
                }
            }
            return true;
        }
        private void _Mtd_CargarFormulario(int _P_Int_Reposicion, int _P_Int_ReposicionDetalle)
        {
            Program._Dat_Tablas =
  new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            DataContext.TREPOSICIONESD _T_TREPOSICIONESD = Program._Dat_Tablas.TREPOSICIONESD.Single(Campos => Campos.cgroupcomp == Convert.ToInt32(Frm_Padre._Str_GroupComp) & Campos.ccompany == Frm_Padre._Str_Comp & Campos.cidreposiciones == _P_Int_Reposicion & Campos.ciddreposiciones == _P_Int_ReposicionDetalle);
            _Cmb_TipoProv.SelectedValue = Convert.ToString(_T_TREPOSICIONESD.cglobal);
            _Cmb_CategProv.SelectedValue = _T_TREPOSICIONESD.ccatproveedor;
            _Cmb_Proveedor.SelectedValue = _T_TREPOSICIONESD.cproveedor;
            _Txt_NumDocu.Text = Convert.ToString(_T_TREPOSICIONESD.cnumdocu).Trim();
            if (_T_TREPOSICIONESD.cnumdocuctrl.Trim() != "NA")
            {
                _Txt_NumCtrlPref.Text = _T_TREPOSICIONESD.cnumdocuctrl.Trim().Substring(0, _T_TREPOSICIONESD.cnumdocuctrl.Trim().IndexOf("-"));
                _Txt_NumCtrl.Text = _T_TREPOSICIONESD.cnumdocuctrl.Trim().Substring(_T_TREPOSICIONESD.cnumdocuctrl.Trim().IndexOf("-") + 1);
            }
            else
            { _Chk_FactMaqFis.Checked = true; }
            _Dtp_Emision.Value = Convert.ToDateTime(_T_TREPOSICIONESD.cfechaemision);
            _Txt_Concepto.Text = _T_TREPOSICIONESD.cconcepto.Trim();
            _Chk_NoLibComp.Checked = Convert.ToBoolean(Convert.ToInt32(_T_TREPOSICIONESD.cfactunolibcomp));
            _Txt_Cuenta.Tag = _T_TREPOSICIONESD.ccuentaexep.Trim();
            _Txt_Cuenta.Text = Convert.ToString(_Txt_Cuenta.Tag).Trim() + " " + _Mtd_DescripCount(_T_TREPOSICIONESD.ccuentaexep.Trim()).ToUpper();
            _Txt_Alicuota.Text = Convert.ToString(_T_TREPOSICIONESD.cimpuesto);
            _Txt_MontoExento.Text = Convert.ToString(_T_TREPOSICIONESD.cmontoexento);
            _Txt_BaseImponible.Text = Convert.ToString(_T_TREPOSICIONESD.cmontosi);
            _Txt_Impuesto.Text=Convert.ToString(_T_TREPOSICIONESD.cmontoimp);
            if (_T_TREPOSICIONESD.cimpuesto > 0)
            { _Rb_ConIva.Checked = true; }
            else
            { _Rb_SinIva.Checked = true; }
            _Mtd_HabilitarIvaCredNoComp();
            _Chk_IvaCredNoCom.Checked = _Mtd_HabilitarIvaCredNoComp(_P_Int_Reposicion, _P_Int_ReposicionDetalle);
        }

        private bool _Mtd_HabilitarIvaCredNoComp(int _P_Int_Reposicion, int _P_Int_ReposicionDetalle)
        {
            string _Str_Cadena = "SELECT civacrednocomp FROM TREPOSICIONESD WHERE cgroupcomp='" + Frm_Padre._Str_GroupComp + "' AND ccompany='" + Frm_Padre._Str_Comp + "' AND cidreposiciones='" + _P_Int_Reposicion + "' AND ciddreposiciones='" + _P_Int_ReposicionDetalle + "' AND civacrednocomp='1'";
            DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
            return _Ds.Tables[0].Rows.Count > 0;
        }

        private void _Mtd_HabilitarIvaCredNoComp()
        {
            _Chk_IvaCredNoCom.Checked = false;
            if (_Cmb_TipoProv.SelectedIndex > 0 && _Cmb_CategProv.SelectedIndex > 0 && _Rb_ConIva.Checked)
            {
                string _Str_Cadena = "SELECT civacrednocomp FROM TCATPROVEEDOR WHERE cglobal='" + _Cmb_TipoProv.SelectedValue.ToString().Trim() + "' AND ccatproveedor='" + _Cmb_CategProv.SelectedValue.ToString().Trim() + "' AND civacrednocomp='1'";
                DataSet _Ds = Program._MyClsCnn._mtd_conexion._Mtd_RetornarDataset(_Str_Cadena);
                if (_Ds.Tables[0].Rows.Count > 0)
                {
                    _Chk_IvaCredNoCom.Enabled = true;
                    return;
                }
            }
            _Chk_IvaCredNoCom.Enabled = false;
        }

        private void Frm_ReposicionCxP_Documentos_Load(object sender, EventArgs e)
        {

        }

        private void _Bt_Visulizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_ReposicionCxP_Documentos_Shown(object sender, EventArgs e)
        {
            _Cmb_TipoProv.Focus();
        }

        private void _Rb_ConIva_CheckedChanged(object sender, EventArgs e)
        {
            if (_Rb_ConIva.Checked)
            { _Txt_BaseImponible.Enabled = _Cmb_Proveedor.SelectedIndex > 0; _Txt_Alicuota.Text = _Mtd_OptenerImpuesto(); _Txt_Impuesto.Enabled = true; }
            else
            { _Txt_Alicuota.Text = "0"; _Txt_Impuesto.Enabled = false; }
            _Mtd_CalularMontos();
            _Mtd_HabilitarIvaCredNoComp();
        }

        private void _Cmb_TipoProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_TipoProv.SelectedIndex > 0)
            { _Mtd_CargarCategProv(); _Cmb_CategProv.Enabled = true; }
            else
            { _Cmb_CategProv.Enabled = false; _Cmb_CategProv.DataSource = null; }
        }

        private void _Cmb_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_Proveedor.SelectedIndex > 0)
            {
                _Mtd_Habilitar(true);
                _Txt_Cuenta.Text = ""; _Txt_Cuenta.Tag = "";
                if (_Chk_NoLibComp.Checked)
                { _Bt_EditarCuenta.Enabled = true; }
                else
                {
                    _Txt_Cuenta.Tag = _Mtd_CuentaProveedor(Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim());
                    if (Convert.ToString(_Txt_Cuenta.Tag).Trim().Length > 0)
                    {
                        _Txt_Cuenta.Text = Convert.ToString(_Txt_Cuenta.Tag).Trim() + " " + _Mtd_DescripCount(Convert.ToString(_Txt_Cuenta.Tag).Trim()).ToUpper();
                        //_Bt_EditarCuenta.Enabled = false;
                    }
                    //else
                    //{
                    _Bt_EditarCuenta.Enabled = true;
                    //}
                }
            }
            else
            {
                _Mtd_Habilitar(false);
                _Bt_EditarCuenta.Enabled = false;
                if (!_Chk_NoLibComp.Checked)
                { _Txt_Cuenta.Text = ""; _Txt_Cuenta.Tag = ""; }
                if (_Int_ReposicionDetalle == 0)
                { _Mtd_Ini(); }
            }
        }

        private void _Txt_NumCtrlPref_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "'" | e.KeyChar.ToString() == "*" | e.KeyChar.ToString() == "-" | e.KeyChar.ToString() == "=" | e.KeyChar.ToString() == "%")
            {
                e.Handled = true;
            }
        }

        private void _Txt_NumCtrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_NumCtrl, e, 8, 0);
        }

        private void _Txt_NumCtrl_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_NumCtrl.Text)) { _Txt_NumCtrl.Text = ""; }
        }

        private void _Txt_BaseImponible_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_BaseImponible, e, 15, 2);
        }

        private void _Txt_MontoExento_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_MontoExento, e, 15, 2);
        }

        private void _Txt_BaseImponible_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_BaseImponible.Text)) { _Txt_BaseImponible.Text = ""; }
            _Mtd_CalularMontos();
        }

        private void _Txt_MontoExento_TextChanged(object sender, EventArgs e)
        {
            if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_MontoExento.Text)) { _Txt_MontoExento.Text = ""; }
            _Mtd_CalularMontos();
        }

        private void _Cmb_Proveedor_DropDown(object sender, EventArgs e)
        {
            _Mtd_CargarProvee(Convert.ToString(_Cmb_TipoProv.SelectedValue));
        }

        private void _Txt_NumDocu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "'" | e.KeyChar.ToString() == "*" | e.KeyChar.ToString() == "=" | e.KeyChar.ToString() == "%")
            {
                e.Handled = true;
            }
        }
        private void _Bt_Aceptar_Click(object sender, EventArgs e)
        {
            if (!_Frm_Reposicion._Mtd_EsValidaLaReposicionActual_NoEstaFinalizada()) return;
            _Er_Error.Dispose();
            if (_Cmb_TipoProv.SelectedIndex > 0 & _Cmb_Proveedor.SelectedIndex > 0 & _Txt_NumDocu.Text.Trim().Length > 0 & _Txt_Concepto.Text.Trim().Length > 0 & (_Mtd_VerifContTextBoxNumeric(_Txt_BaseImponible) | _Mtd_VerifContTextBoxNumeric(_Txt_MontoExento)) & _Txt_Cuenta.Text.Trim().Length > 0 & (_Chk_NoLibComp.Checked | _Chk_FactMaqFis.Checked | (!_Chk_NoLibComp.Checked & !_Chk_FactMaqFis.Checked & _Mtd_VerifContTextBoxNumeric(_Txt_NumCtrl))))
            {
                if (_Txt_BaseImponible.Text.Trim().Length == 0) { _Txt_BaseImponible.Text = "0"; }
                if (_Txt_MontoExento.Text.Trim().Length == 0) { _Txt_MontoExento.Text = "0"; }
                bool _Bol_DocumentoRepetido = _Mtd_DocumentoRepetido();
                bool _Bol_VerificarMontoUT = _Mtd_VerificarMontoUT(Convert.ToDecimal(_Txt_BaseImponible.Text));
                bool _Bol_MontoValido = _Mtd_MontoValido();
                //Si esta activo el swicheo de los reintegros
                if (CLASES._Cls_Varios_Metodos._Mtd_EstaActivoReintegros())
                {
                    _Bol_VerificarMontoUT = true;
                    _Bol_MontoValido = true;
                }
                if (!_Bol_DocumentoRepetido & _Bol_VerificarMontoUT & _Bol_MontoValido)
                {
                    if (!_Mtd_VerificarImpuesto())
                        return;
                    if (_Chk_IvaCredNoCom.Enabled && _Chk_IvaCredNoCom.Checked)
                    {
                        if (MessageBox.Show("¿Esta seguro de que la factura es IVA crédito no compensado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                            return;
                    }
                    else if (_Chk_IvaCredNoCom.Enabled)
                    {
                        if (MessageBox.Show("¿Esta seguro de que la factura no es IVA crédito no compensado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                            return;
                    }
                    _Mtd_InsertarRegistros();
                    //MessageBox.Show("La operación ha sido realizada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Frm_Reposicion._Mtd_Actualizar();
                    _Frm_Reposicion._Mtd_ActualizarDetalle(Convert.ToInt32(_Frm_Reposicion._Txt_Reposicion.Text));
                    this.Close();
                }
                else
                {
                    if (_Bol_DocumentoRepetido) { MessageBox.Show("El documento que esta ingresando ha sido cargado anteriormente.\nPor favor verifique...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else if (!_Bol_VerificarMontoUT) { MessageBox.Show("El monto del documento no es valido debido a que sobrepasa el máximo permitido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else if (!_Bol_MontoValido) { MessageBox.Show("El monto del documento no es válido debido a que el monto de la reposición quedaría en negativo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else
                    { MessageBox.Show("No se puede ingresar el documento. Error desconocido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
            }
            else
            {
                if (_Cmb_TipoProv.SelectedIndex == 0) { _Er_Error.SetError(_Cmb_TipoProv, "Información Requerida!!!"); }
                if (_Cmb_Proveedor.SelectedIndex == 0) { _Er_Error.SetError(_Cmb_Proveedor, "Información Requerida!!!"); }
                if (_Txt_NumDocu.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_NumDocu, "Información Requerida!!!"); }
                if (_Txt_Concepto.Text.Trim().Length == 0) { _Er_Error.SetError(_Txt_Concepto, "Información Requerida!!!"); }
                if (_Rb_ConIva.Checked && !_Mtd_VerifContTextBoxNumeric(_Txt_BaseImponible)) { _Er_Error.SetError(_Txt_BaseImponible, "Información Requerida!!!"); }
                if (_Rb_SinIva.Checked && !_Mtd_VerifContTextBoxNumeric(_Txt_MontoExento)) { _Er_Error.SetError(_Txt_MontoExento, "Información Requerida!!!"); }
                if (_Txt_Cuenta.Text.Trim().Length == 0) { _Er_Error.SetError(_Bt_EditarCuenta, "Información Requerida!!!"); }
                if (!_Chk_NoLibComp.Checked & !_Chk_FactMaqFis.Checked & !_Mtd_VerifContTextBoxNumeric(_Txt_NumCtrl)) { _Er_Error.SetError(_Txt_NumCtrl, "Información Requerida!!!"); }
            }
        }

        private void _Bt_EditarCuenta_Click(object sender, EventArgs e)
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

        private void _Chk_NoLibComp_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chk_NoLibComp.Checked)
            {
                _Txt_Cuenta.Tag = ""; _Txt_Cuenta.Text = ""; 
                _Bt_EditarCuenta.Enabled = _Cmb_Proveedor.SelectedIndex > 0;
                _Rb_ConIva.Enabled = false; _Rb_SinIva.Checked = true;
            }
            else
            {
                _Txt_Cuenta.Tag = ""; _Txt_Cuenta.Text = "";
                _Bt_EditarCuenta.Enabled = false;
                if (_Cmb_Proveedor.SelectedIndex > 0)
                {
                    _Txt_Cuenta.Tag = _Mtd_CuentaProveedor(Convert.ToString(_Cmb_Proveedor.SelectedValue).Trim());
                    if (Convert.ToString(_Txt_Cuenta.Tag).Trim().Length > 0)
                    {
                        _Txt_Cuenta.Text = Convert.ToString(_Txt_Cuenta.Tag).Trim() + " " + _Mtd_DescripCount(Convert.ToString(_Txt_Cuenta.Tag).Trim()).ToUpper();
                        //_Bt_EditarCuenta.Enabled = false;
                    }
                    //else
                    //{
                    _Bt_EditarCuenta.Enabled = true;
                    //}
                    _Rb_ConIva.Enabled = true;
                }
                _Rb_ConIva.Checked = true;//Debe estar en esta linea
            }
        }

        private void _Cmb_CategProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Cmb_CategProv.SelectedIndex > 0)
            { _Mtd_CargarProvee(Convert.ToString(_Cmb_TipoProv.SelectedValue)); _Cmb_Proveedor.Enabled = true; }
            else
            {
                _Cmb_Proveedor.Enabled = false; _Cmb_Proveedor.DataSource = null;
                if (_Int_ReposicionDetalle == 0)
                {
                    _Mtd_Habilitar(false);
                    _Mtd_Ini();
                }
            }
            _Mtd_HabilitarIvaCredNoComp();
        }

        private void _Rb_SinIva_CheckedChanged(object sender, EventArgs e)
        {
            _Txt_BaseImponible.Enabled = false; _Txt_BaseImponible.Text = "0";
        }

        private void _Bt_Alicuota_Click(object sender, EventArgs e)
        {
            string _Str_Alicuota = _Txt_Alicuota.Text.Trim();
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(56, _Txt_Alicuota, 1, "");
            _Frm.ShowDialog();
            if (_Txt_Alicuota.Text.Trim() != _Str_Alicuota)
            { _Mtd_CalularMontos(); }
        }

        private void _Rb_ConIva_EnabledChanged(object sender, EventArgs e)
        {
            _Bt_Alicuota.Enabled = _Rb_ConIva.Enabled;
            _Txt_Alicuota.Enabled = _Rb_ConIva.Enabled;
        }

        private void _Chk_FactMaqFis_CheckedChanged(object sender, EventArgs e)
        {
            if (_Chk_FactMaqFis.Checked)
            {
                _Txt_NumCtrlPref.Enabled = false;
                _Txt_NumCtrl.Enabled = false;
                _Txt_NumCtrlPref.Text = "";
                _Txt_NumCtrl.Text = "";
            }
            else
            {
                _Txt_NumCtrlPref.Enabled = true;
                _Txt_NumCtrl.Enabled = true;
                _Txt_NumCtrl.Text = "";
            }
        }
        private void _Mtd_SeleccionarCombos(string _P_Str_Proveedor)
        {
            Program._Dat_Tablas =
  new DataContext._Dat_CntxTablasDataContext(Program._MyClsCnn._mtd_conexion._g_Str_Stringconex);
            var _Var_Datos = from Campos in Program._Dat_Tablas.TPROVEEDOR
                             where Campos.ccompany == Frm_Padre._Str_Comp & Campos.cglobal != 1 & Campos.cproveedor == _P_Str_Proveedor
                             select new { Campos.cglobal, Campos.ccatproveedor };
            _Cmb_TipoProv.SelectedValue = Convert.ToString(_Var_Datos.Single().cglobal);
            _Cmb_CategProv.SelectedValue = _Var_Datos.Single().ccatproveedor;
            _Cmb_Proveedor.SelectedValue = _P_Str_Proveedor;
        }
        private void _Bt_BuscarProveedor_Click(object sender, EventArgs e)
        {
            TextBox _Txt_Proveedor = new TextBox();
            Cursor = Cursors.WaitCursor;
            Frm_Busqueda2 _Frm = new Frm_Busqueda2(50, _Txt_Proveedor, 0, " AND (cglobal<>'1' AND TPROVEEDOR.ccompany='" + Frm_Padre._Str_Comp + "')");
            Cursor = Cursors.Default;
            _Frm.ShowDialog();
            if (Convert.ToString(_Txt_Proveedor.Tag).Trim().Length > 0)
            { _Mtd_SeleccionarCombos(Convert.ToString(_Txt_Proveedor.Tag).Trim()); }
        }

        private void _Txt_Impuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            _Cls_VariosMetodos._Mtd_Valida_Numeros(_Txt_Impuesto, e, 15, 2);
        }

        private void _Txt_Impuesto_TextChanged(object sender, EventArgs e)
        {
            //Si esta activo el swicheo de los reintegros
            if (!CLASES._Cls_Varios_Metodos._Mtd_EstaActivoReintegros())
            {
                if (!_Cls_VariosMetodos._Mtd_IsNumeric(_Txt_Impuesto.Text)) { _Txt_Impuesto.Text = ""; }
            }
            _Mtd_CalularMontoTotal();
        }
    }
}
